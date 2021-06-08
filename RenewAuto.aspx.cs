using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using EPolicy.TaskControl;
using Baldrich.DBRequest;
using EPolicy.XmlCooker;
using System.Xml;

namespace EPolicy
{
    public partial class RenewAuto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			Control Banner = new Control();
			Banner = LoadControl(@"TopBanner1.ascx");
			this.Placeholder1.Controls.Add(Banner);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
            //TaskControl.Policy policy = (TaskControl.Policy)Session["TaskControl"];
            TaskControl.Policies policies = null;

            DataTable dtOld;
            DataTable dtNew = GetNewPolicy();

            for (int i = 0; dtNew.Rows.Count > i; i++)
            {
                dtOld = GetOldPolicy(dtNew.Rows[i]["PolicyNo"].ToString().Trim());
                if (dtOld.Rows.Count > 0)
                {
                    TaskControl.Policies taskControl = (TaskControl.Policies)TaskControl.TaskControl.GetTaskControlByTaskControlID(int.Parse(dtOld.Rows[0]["TaskControlID"].ToString().Trim()), 1);
                    policies = new TaskControl.Policies();

                    try
                    {
                        policies = taskControl;
                        policies.Mode = 1;
                        policies.CancellationDate = "";
                        policies.CancellationEntryDate = "";
                        policies.CancellationUnearnedPercent = 0.00;
                        policies.CancellationMethod = 0;
                        policies.CancellationReason = 0;
                        policies.PaidAmount = taskControl.PaidAmount;
                        policies.PaidDate = "";
                        policies.Ren_Rei = "RN";
                        policies.Rein_Amt = taskControl.CancellationAmount;
                        policies.PaidDate = taskControl.PaidDate;
                        policies.CommissionAgency = 0.00; // taskControl.ReturnCommissionAgency;
                        policies.CommissionAgent = 0.00; // taskControl.ReturnCommissionAgent;
                        policies.CommissionAgencyPercent = ""; // taskControl.CommissionAgencyPercent.Trim();
                        policies.CommissionAgentPercent = "";  //taskControl.CommissionAgentPercent.Trim();
                        policies.TaskControlID = 0;
                        policies.Status = "Inforce";

                        policies.Charge = taskControl.Charge;
                        policies.ReturnCharge = 0.00;
                        policies.ReturnPremium = 0.00;
                        policies.CancellationAmount = 0.00;
                        policies.ReturnCommissionAgency = 0.00;
                        policies.ReturnCommissionAgent = 0.00;

                        int msufijo;
                        int sufijo = int.Parse(taskControl.Suffix);
                        msufijo = sufijo + 1;
                        policies.Suffix = "0".ToString() + msufijo.ToString();

                        int mAniv;
                        int aniv = int.Parse(taskControl.Anniversary);
                        mAniv = aniv + 1;
                        policies.Anniversary = "0".ToString() + mAniv.ToString();

                        policies.EffectiveDate = dtNew.Rows[i]["Eff"].ToString().Trim();
                        policies.ExpirationDate = dtNew.Rows[i]["Exp"].ToString().Trim();
                        policies.Agency = dtNew.Rows[i]["Agent"].ToString().Trim();
                        policies.TotalPremium = (double)dtNew.Rows[i]["Premium"];

                        SetSelectedAgent(policies, policies.Agent.Trim());
                        taskControl.LbxAgentSelected = ddlSelectedAgent;

                        taskControl.SavePolicies(1);

                        //Session.Clear();
                        //Session.Add("TaskControl", policies);
                        //Response.Redirect("Policies.aspx", false);
                    }
                    catch (Exception exp)
                    {
                        //this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                        //this.litPopUp.Visible = true;
                    }
                }
            }
        }
        private void SetSelectedAgent(TaskControl.Policies taskControl, string companyDealerID)
        {
            ddlAvailableAgent.SelectedIndex = 0;
            //			if(taskControl.Agent != "000")
            //			{
            for (int i = 0; ddlAvailableAgent.Items.Count - 1 >= i; i++)
            {
                if (ddlAvailableAgent.Items[i].Value.Split("|".ToCharArray())[1] == companyDealerID)
                {
                    ddlAvailableAgent.SelectedIndex = i;
                    i = ddlAvailableAgent.Items.Count - 1;
                }
            }
            //			}

            for (int i = 0; i < ddlAvailableAgent.Items.Count; i++)
            {
                if (ddlAvailableAgent.Items[i].Selected)
                {
                    ListItem list = new ListItem(ddlAvailableAgent.Items[i].Value.Split("|".ToCharArray())[0] +
                        " |" + ddlAvailableAgent.Items[i].Text.Split("|".ToCharArray())[1],
                        ddlAvailableAgent.Items[i].Value.Split("|".ToCharArray())[0] +
                        " |" + ddlAvailableAgent.Items[i].Value.Split("|".ToCharArray())[1]);
                    ddlSelectedAgent.Items.Add(list);
                    ddlAvailableAgent.Items.Remove(ddlAvailableAgent.Items[i]);
                }
            }

        }

        private DataTable GetOldPolicy(string policyNo)
        {
            DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("PolicyNo",
                SqlDbType.Char, 11, policyNo.ToString(),
                ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            DataTable dt = exec.GetQuery("GetOldPolicy", xmlDoc);
            return dt;
        }

        private DataTable GetNewPolicy()
        {
            DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[0];

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            DataTable dt = exec.GetQuery("GetNewPolicy", xmlDoc);
            return dt;
        }
    }
}