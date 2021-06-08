using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
//using Epolicy.Reports;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.TaskControl;
using EPolicy;


using Baldrich.DBRequest;
using EPolicy.XmlCooker;
using System.Xml;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Globalization;

namespace EPolicy
{
	/// <summary>
	/// Summary description for CancellationPolicy.
	/// </summary>
    public partial class CancellationPolicy : System.Web.UI.Page
    {
        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);

            Control Banner = new Control();
            Banner = LoadControl(@"TopBanner1.ascx");
            this.Placeholder1.Controls.Add(Banner);

            //Setup Left-side Banner
            ////Control LeftMenu = new Control();
            ////LeftMenu = LoadControl(@"LeftMenu.ascx");
            ////this.phTopBanner1.Controls.Add(LeftMenu);

            //DropDownList
            DataTable dtCancellationMethod = EPolicy.LookupTables.LookupTables.GetTable("CancellationMethod");
            DataTable dtCancellationReason = EPolicy.LookupTables.LookupTables.GetTable("CancellationReason");

            //CancellationMethod
            ddlCancellationMethod.DataSource = dtCancellationMethod;
            ddlCancellationMethod.DataTextField = "CancellationMethodDesc";
            ddlCancellationMethod.DataValueField = "CancellationMethodID";
            ddlCancellationMethod.DataBind();
            ddlCancellationMethod.SelectedIndex = -1;
            ddlCancellationMethod.Items.Insert(0, "");

            //CancellationReason
            ddlCancellationReason.DataSource = dtCancellationReason;
            ddlCancellationReason.DataTextField = "CancellationReasonDesc";
            ddlCancellationReason.DataValueField = "CancellationReasonID";
            ddlCancellationReason.DataBind();
            ddlCancellationReason.SelectedIndex = -1;
            ddlCancellationReason.Items.Insert(0, "");
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion

        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.litPopUp.Visible = false;

            Login.Login cp = HttpContext.Current.User as Login.Login;
            if (cp == null)
            {
                Response.Redirect("HomePage.aspx?001");
            }
            else
            {
                if (!cp.IsInRole("CANCELLATIONPOLICY") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    Response.Redirect("HomePage.aspx?001");
                }
            }

            BtnSave = EPolicy.Utilities.ConfirmDialogBoxPopUp(BtnSave, "document.CancPol", "Are you sure you want to save this info?");

            if (!IsPostBack)
            {
                this.SetReferringPage();

                TxtReturnCharge.Attributes.Add("onblur", "addCharges()");
                TxtReturnPremium.Attributes.Add("onblur", "addCharges()");

                if (Session["TaskControl"] != null)
                {
                    if (Session["CancellationEdit"] != null)
                    {
                        int mmode = (int)Session["CancellationEdit"];

                        switch (mmode)
                        {
                            case 1: //Add
                                FillTextControl();
                                EnableControls();
                                break;
                            case 2: //Update
                                FillTextControl();
                                EnableControls();
                                break;

                            default:
                                FillTextControl();
                                DisableControls();
                                break;
                        }
                    }
                    else
                    {
                        FillTextControl();
                        DisableControls();
                    }
                }
            }
            else
            {
                if (Session["CancellationEdit"] != null)
                    if ((int)Session["CancellationEdit"] != 1 && (int)Session["CancellationEdit"] != 2)
                        DisableControls();
            }
        }

        private void EnableControls()
        {
            BtnCalculate.Visible = true;
            btnEdit.Visible = false;
            BtnSave.Visible = true;
            btnCancel.Visible = true;
            BtnExit.Visible = false;
            btnPrint.Visible = false;

            ddlCancellationMethod.Enabled = true;
            ddlCancellationReason.Enabled = true;

            txtCancellationDate.Enabled = true;
            TxtUnearnedPercent.Enabled = true;
            TxtReturnPremium.Enabled = true;
            TxtReturnCharge.Enabled = true;
            TxtTotalReturnPremium.Enabled = false;
            TxtCancellationEntryDate.Enabled = true;
            txtComment.Enabled = true;

            txtMOCDesc.Enabled = true;
            txtRSCDate.Enabled = true;
        }

        private void DisableControls()
        {
            TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];

            BtnCalculate.Visible = false;
            btnEdit.Visible = true;
            BtnSave.Visible = false;
            btnCancel.Visible = false;
            BtnExit.Visible = true;

            //if (txtCancellationDate.Text.Trim() != "")
            //    btnPrint.Visible = true;
            //else
            //    btnPrint.Visible = false;

            ddlCancellationMethod.Enabled = false;
            ddlCancellationReason.Enabled = false;

            txtCancellationDate.Enabled = false;
            TxtUnearnedPercent.Enabled = false;
            TxtReturnPremium.Enabled = false;
            TxtReturnCharge.Enabled = false;
            TxtTotalReturnPremium.Enabled = false;
            TxtCancellationEntryDate.Enabled = false;
            txtComment.Enabled = false;

            txtMOCDesc.Enabled = false;
            txtRSCDate.Enabled = false;

            if (ddlCancellationReason.SelectedItem.ToString() == "Insured Property Sold" || ddlCancellationReason.SelectedItem.ToString() == "Other Insurance Purchased" || ddlCancellationReason.SelectedItem.ToString() == "Finance Request")
            {
                Label27.Visible = true;
                txtRSCDate.Visible = true;
            }
            else
            {
                Label27.Visible = false;
                txtRSCDate.Visible = false;
            }

            if (ddlCancellationMethod.SelectedIndex == 2)
            {
                Label28.Visible = true;
                txtMOCDesc.Visible = true;
            }
            else
            {
                Label28.Visible = false;
                txtMOCDesc.Visible = false;
            }
        }

        private void FillTextControl()
        {
            TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];

            ddlCancellationMethod.SelectedIndex = 0;
            if (taskControl.CancellationMethod != 0)
            {
                for (int i = 0; ddlCancellationMethod.Items.Count - 1 >= i; i++)
                {
                    if (ddlCancellationMethod.Items[i].Value == taskControl.CancellationMethod.ToString())
                    {
                        ddlCancellationMethod.SelectedIndex = i;
                        i = ddlCancellationMethod.Items.Count - 1;
                    }
                }
            }

            ddlCancellationReason.SelectedIndex = 0;
            if (taskControl.CancellationReason != 0)
            {
                for (int i = 0; ddlCancellationReason.Items.Count - 1 >= i; i++)
                {
                    if (ddlCancellationReason.Items[i].Value == taskControl.CancellationReason.ToString())
                    {
                        ddlCancellationReason.SelectedIndex = i;
                        i = ddlCancellationReason.Items.Count - 1;
                    }
                }
            }

            txtCancellationDate.Text = taskControl.CancellationDate;
            TxtUnearnedPercent.Text = taskControl.CancellationUnearnedPercent.ToString("###,###.00");
            TxtReturnPremium.Text = taskControl.ReturnPremium.ToString("###,###.00");
            TxtReturnCharge.Text = taskControl.ReturnCharge.ToString("###,###.00");
            TxtTotalReturnPremium.Text = taskControl.CancellationAmount.ToString("###,###.00");
            TxtCancellationEntryDate.Text = taskControl.CancellationEntryDate;

            double amt = taskControl.ReturnCharge + taskControl.ReturnPremium;

            TxtTotalReturnPremium.Text = amt.ToString("###,###.00");

            //			DateTime date   = DateTime.Now;
            //			TxtCancellationEntryDate.Text    = date.ToShortDateString().Trim();

            txtRSCDate.Text = taskControl.CancellationReasonDesc.ToString();
            txtMOCDesc.Text = taskControl.CancellationMethodDesc.ToString();
            txtComment.Text = taskControl.CancellationComments.ToString();

        }

        private void SetReferringPage()
        {
            if ((Session["FromUI"] != null) && (Session["FromUI"].ToString() != ""))
            {
                this.ReferringPage = Session["FromUI"].ToString();
                //Session.Remove("FromUI");
            }
        }

        private string ReferringPage
        {
            get
            {
                return ((ViewState["referringPage"] != null) ?
                    ViewState["referringPage"].ToString() : "");
            }
            set
            {
                ViewState["referringPage"] = value;
            }
        }


        private void ReturnToReferringPage()
        {
            if (this.ReferringPage != "")
            {
                Response.Redirect(this.ReferringPage);
            }
            Response.Redirect("HomePage.aspx");
        }

        protected void BtnExit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Session.Remove("CancellationEdit");
            ReturnToReferringPage();
        }

        protected void btnEdit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            int mmode = 1;
            Session.Add("CancellationEdit", mmode);

            DefaultValue();
            EnableControls();
        }

        private void DefaultValue()
        {
            //			TaskControl.Policy taskControl = (TaskControl.Policy) Session["TaskControl"];

            //			switch(taskControl.PolicyClassID) 
            //			{	
            //				case 1:				//AutoGuard
            //					break;
            //				
            //				case 3:				//AutoPersonal
            //					break;
            //				
            //				case 9:				//AutoGap
            //					break;
            //
            //				case 10:			//Etch
            //					if(taskControl.CancellationAmount == 0)
            //					{
            //						this.txtCancellationDate.Text	= taskControl.EffectiveDate;
            //						ddlCancellationMethod.SelectedIndex = ddlCancellationMethod.Items.IndexOf(
            //							ddlCancellationMethod.Items.FindByValue("3"));
            //						ddlCancellationReason.SelectedIndex = ddlCancellationReason.Items.IndexOf(
            //							ddlCancellationReason.Items.FindByValue("7"));
            //						this.TxtCancellationEntryDate.Text	= DateTime.Now.ToShortDateString();
            //					}
            //					break;
            //			}
        }

        protected void btnCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = 0;

            try
            {
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Could not parse user id from cp.Identity.Name.", ex);
            }

            TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];

            TaskControl.TaskControl tc = TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControl.TaskControlID, userID);

            Session["TaskControl"] = tc;
            FillTextControl();

            int mmode = 0;
            Session.Add("CancellationEdit", mmode);
            DisableControls();
        }

        protected void BtnSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (bool.Parse(ConfirmDialogBoxPopUp.Value.Trim()) == true)
            {
                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = 0;

                try
                {
                    userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        "Could not parse user id from cp.Identity.Name.", ex);
                }

                try
                {
                    CalculatedCancellation(true);

                    FillProperties();
                    TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];

                    taskControl.SaveCancellation(userID);  //(userID);
                    FillTextControl();
                    DisableControls();

                    int mmode = 0;
                    Session.Add("CancellationEdit", mmode);

                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Cancellation information saved successfully.");
                    this.litPopUp.Visible = true;
                }
                catch (Exception exp)
                {
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to save this Cancellation. " + exp.Message);
                    this.litPopUp.Visible = true;
                }
            }
            else
            {
                //				string js="";
                //				js = "<script language=javascript>alert('No Pudo Salvar.');</script>";
                //				Response.Write(js);
            }
        }

        public void FillProperties()
        {
            TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];

            taskControl.CancellationMethod = ddlCancellationMethod.SelectedItem.Value != "" ? int.Parse(ddlCancellationMethod.SelectedItem.Value) : 0;
            taskControl.CancellationReason = ddlCancellationReason.SelectedItem.Value != "" ? int.Parse(ddlCancellationReason.SelectedItem.Value) : 0;
            taskControl.CancellationUnearnedPercent = double.Parse(TxtUnearnedPercent.Text);
            taskControl.CancellationDate = txtCancellationDate.Text;

            if (TxtReturnPremium.Text.Trim() == "")
                taskControl.ReturnPremium = 0.00;
            else
                taskControl.ReturnPremium = double.Parse(TxtReturnPremium.Text);

            if (TxtReturnCharge.Text.Trim() == "")
                taskControl.ReturnCharge = 0.00;
            else
                taskControl.ReturnCharge = double.Parse(TxtReturnCharge.Text);

            double amt = taskControl.ReturnCharge + taskControl.ReturnPremium;
            TxtTotalReturnPremium.Text = amt.ToString("###,###.00");

            taskControl.CancellationAmount = double.Parse(TxtTotalReturnPremium.Text);
            taskControl.CancellationEntryDate = TxtCancellationEntryDate.Text;

            if (ddlCancellationReason.SelectedItem.ToString() == "Insured Property Sold" || ddlCancellationReason.SelectedItem.ToString() == "Other Insurance Purchased" || ddlCancellationReason.SelectedItem.ToString() == "Finance Request")
                taskControl.CancellationReasonDesc = txtRSCDate.Text;
            else
                taskControl.CancellationReasonDesc = ddlCancellationReason.SelectedItem.ToString();

            if (ddlCancellationMethod.SelectedIndex == 2)
                taskControl.CancellationMethodDesc = txtMOCDesc.Text;

            taskControl.CancellationComments = txtComment.Text;

            Session.Add("TaskControl", taskControl);
        }

        protected void BtnCalculate_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            CalculatedCancellation(false);
        }

        protected void btnPrint_Click(object sender, System.EventArgs e)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

            ActiveReport3 rpt = new ActiveReport3();

            rpt = new EPolicy2.Reports.AutoGuard.CancellationNote(taskControl, "");
            rpt.Run();

            Session.Add("Report", rpt);
            Session.Add("FromPage", "CancellationPolicy.aspx");
            Response.Redirect("ActiveXViewer.aspx", false);
        }

        protected void BtnExit_Click(object sender, System.EventArgs e)
        {
            Session.Remove("FromUI");
            Session.Remove("CancellationEdit");
            ReturnToReferringPage();
        }

        protected void btnCancel_Click(object sender, System.EventArgs e)
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = 0;

            try
            {
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Could not parse user id from cp.Identity.Name.", ex);
            }

            TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];

            TaskControl.TaskControl tc = TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControl.TaskControlID, userID);

            Session["TaskControl"] = tc;
            FillTextControl();

            int mmode = 0;
            Session.Add("CancellationEdit", mmode);
            DisableControls();
        }

        public static DataTable GetAgencyDesc(string AgencyID)
        {
            DataTable dt = new DataTable();

            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("AgencyID",
                SqlDbType.VarChar, 10, AgencyID.ToString(),
                ref cookItems);


            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

            dt = exec.GetQuery("GetAgencyDesc", xmlDoc);
            return dt;
        }
        public static DataTable GetAgentDesc(int AgentID)
        {
            DataTable dt = new DataTable();

            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("AgentID",
                SqlDbType.Int, 0, AgentID.ToString(),
                ref cookItems);


            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

            dt = exec.GetQuery("GetAgentByAgentID", xmlDoc);
            return dt;
        }

        protected void BtnSave_Click(object sender, System.EventArgs e)
        {

            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = 0;

            try
            {
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Could not parse user id from cp.Identity.Name.", ex);
            }

            try
            {
                if (!cp.IsInRole("FREECANCELLATION"))  //Permission to apply cancellation on expired policy
                {
                    validateCalculate();
                }


                TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];

                if (DateTime.Parse(taskControl.EffectiveDate.Trim().ToString()) != DateTime.Parse(txtCancellationDate.Text.Trim()) && ddlCancellationMethod.SelectedItem.Value.ToString() == "3")
                {
                    throw new Exception("Cancellation Date (" +txtCancellationDate.Text.Trim()+ ") doesn't match policy Effective Date ("+ taskControl.EffectiveDate.Trim().ToString() + ").");
                }

                //if(taskControl.PolicyClassID != 1) //No aplica para VSC. Entran manualmente la prima.
                //    CalculatedCancellation(true);

                FillProperties();

                taskControl = (TaskControl.Policy)Session["TaskControl"];

                taskControl.SaveCancellation(userID);  //(userID);
                FillTextControl();
                DisableControls();

                //if (taskControl.CancellationDate == "")
                    History(taskControl.TaskControlID, userID, "CANC.", "POLICIES", "CANCELLED POLICY."); //antes

                    int mmode = 0;
                Session.Add("CancellationEdit", mmode);
                TaskControl.Policy taskControl2 = (TaskControl.Policy)Session["TaskControl"];
                
                if (taskControl.PolicyType.ToString().Trim() == "EMD")
                {
                     taskControl2 = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
                }
                else if (taskControl.PolicyType.ToString().Trim() == "CP" || taskControl.PolicyType.ToString().Trim() == "CPA"
                  || taskControl.PolicyType.ToString().Trim() == "CE" || taskControl.PolicyType.ToString().Trim() == "CLP"
                    || taskControl.PolicyType.ToString().Trim() == "CLE" || taskControl.PolicyType.ToString().Trim() == "CPT"
                    || taskControl.PolicyType.ToString().Trim() == "APC" || taskControl.PolicyType.ToString().Trim() == "AEC"
                    || taskControl.PolicyType.ToString().Trim() == "CF" || taskControl.PolicyType.ToString().Trim() == "CFT")
                {
                     taskControl2 = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
                }
                else
                {
                    taskControl2 = (TaskControl.Policies)Session["TaskControl"];
                }
                string userName = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();
                string limit = ""; //ddlPrMedicalLimits.SelectedItem.Text.ToString().Trim();
                List<string> mergePaths2 = new List<string>();

                if (taskControl2.Customer.FirstName.ToUpper().Contains("Ñ") || taskControl2.Customer.LastName1.ToUpper().Contains("Ñ") || taskControl2.Customer.LastName2.ToUpper().Contains("Ñ"))
                {
                    taskControl2.Customer.FirstName = taskControl2.Customer.FirstName.Replace("Ñ", "N");
                    taskControl2.Customer.LastName1 = taskControl2.Customer.LastName1.Replace("Ñ", "N");
                    taskControl2.Customer.LastName2 = taskControl2.Customer.LastName2.Replace("Ñ", "N");
                }
                if (taskControl2.City == 66)
                    taskControl2.City = 80;

                if (taskControl2.CancellationDate != String.Empty)
                {
                    #region Cancellation Credit
                    ReportViewer viewer = new ReportViewer();
                    if (taskControl.PolicyType.ToString().Trim() == "CPA" || taskControl.PolicyType.ToString().Trim() == "PAH")
                    viewer.LocalReport.ReportPath = Server.MapPath("Reports/AlliedCancellationCredit.rdlc");
                    else 
                     viewer.LocalReport.ReportPath = Server.MapPath("Reports/CancellationCredit.rdlc");


                    viewer.LocalReport.DataSources.Clear();
                    viewer.ProcessingMode = ProcessingMode.Local;
                    DataTable dt = new DataTable();
                    DataTable dt2 = new DataTable();
                    dt = GetAgencyDesc(taskControl.Agency);
                    dt2 = GetAgentDesc(int.Parse(taskControl.Agent));


                    ReportParameter[] param = new ReportParameter[15];
                    param[0] = new ReportParameter("PolicyID", taskControl2.PolicyNo.ToString().Trim());
                    param[1] = new ReportParameter("EffectiveDate", DateTime.Parse(taskControl2.EffectiveDate).ToString("MMMM dd, yyyy"));
                    param[2] = new ReportParameter("ExpirationDate", DateTime.Parse(taskControl2.ExpirationDate).ToString("MMMM dd, yyyy"));
                    //param[3] = new ReportParameter("Agency", ddlAgency.SelectedItem.ToString());
                    //param[4] = new ReportParameter("Agent", ddlAgent.SelectedItem.ToString());
                    param[3] = new ReportParameter("Agency", dt.Rows[0]["AgencyDesc"].ToString().Trim());
                    param[4] = new ReportParameter("Agent", dt2.Rows[0]["AgentDesc"].ToString().Trim());
                    param[5] = new ReportParameter("Customer", taskControl2.Customer.FirstName + " " + taskControl2.Customer.LastName1 + " " + taskControl2.Customer.LastName2);

                    if (taskControl2.Customer.Address2 != String.Empty)
                        param[6] = new ReportParameter("Address", taskControl2.Customer.Address1 + " \r\n" + taskControl2.Customer.Address2 + " \r\n" +
                                                   taskControl2.Customer.City + " " + taskControl2.Customer.State + " " + taskControl2.Customer.ZipCode);
                    else
                        param[6] = new ReportParameter("Address", taskControl2.Customer.Address1 + " \r\n" +
                                                       taskControl2.Customer.City + " " + taskControl2.Customer.State + " " + taskControl2.Customer.ZipCode);

                    param[7] = new ReportParameter("CancellationDate", DateTime.Parse(taskControl2.CancellationDate).ToString("MMMM dd, yyyy"));
                    param[8] = new ReportParameter("ReturnPremium", (taskControl2.ReturnPremium + taskControl2.ReturnCharge).ToString("$###,##0.00"));
                    param[9] = new ReportParameter("PolicyType", taskControl2.PolicyType.ToString().Trim());

                    if (taskControl2.CancellationMethod == 1)
                    {
                        param[10] = new ReportParameter("MOC3", "X");
                        param[11] = new ReportParameter("MOC5Exp", "");
                    }
                    else if (taskControl2.CancellationMethod == 2)
                    {
                        param[10] = new ReportParameter("MOC2", "X");
                        param[11] = new ReportParameter("MOC5Exp", "");
                    }
                    else if (taskControl2.CancellationMethod == 3)
                    {
                        param[10] = new ReportParameter("MOC1", "X");
                        param[11] = new ReportParameter("MOC5Exp", "");
                    }
                    else if (taskControl2.CancellationMethod == 4)
                    {
                        param[10] = new ReportParameter("MOC4", "X");
                        param[11] = new ReportParameter("MOC5Exp", "");
                    }
                    else
                    {
                        param[10] = new ReportParameter("MOC5", "X");
                        param[11] = new ReportParameter("MOC5Exp", taskControl2.CancellationMethodDesc.ToString());
                    }

                    if (taskControl2.CancellationReason == 6)
                    {
                        param[12] = new ReportParameter("RSC1", "X");
                        param[13] = new ReportParameter("RSC4Date", "");
                    }
                    else if (taskControl2.CancellationReason == 5 || taskControl2.CancellationReason == 10
                             || taskControl2.CancellationReason == 14)
                    {
                        param[12] = new ReportParameter("RSC2", "X");
                        param[13] = new ReportParameter("RSC4Date", "");
                    }
                    else if (taskControl2.CancellationReason == 26)
                    {
                        param[12] = new ReportParameter("RSC3", "X");
                        param[13] = new ReportParameter("RSC3Date", DateTime.Parse(taskControl2.CancellationReasonDesc).ToString("MMMM dd, yyyy"));
                    }
                    else if (taskControl2.CancellationReason == 27)
                    {
                        param[12] = new ReportParameter("RSC4", "X");
                        param[13] = new ReportParameter("RSC4Date", DateTime.Parse(taskControl2.CancellationReasonDesc).ToString("MMMM dd, yyyy"));
                    }
                    else
                    {
                        param[12] = new ReportParameter("RSC5", "X");
                        param[13] = new ReportParameter("RSC5Exp", taskControl2.CancellationReasonDesc.ToString());
                    }

                    param[14] = new ReportParameter("insuranceCompany", taskControl2.InsuranceCompany.ToString());


                    viewer.LocalReport.SetParameters(param);
                    viewer.LocalReport.Refresh();

                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType;
                    string encoding = string.Empty;
                    string extension;
                    string fileName = userName;
                    string _FileName = userName + ".pdf";
                    //Ññ
                    if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                        File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

                    byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                    using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }

                    //History(taskControl2.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED CANCELLATION CREDIT");

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + _FileName + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                    #endregion
                }

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Cancellation information saved successfully.");
                this.litPopUp.Visible = true;
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to save this Cancellation. " + exp.Message);
                this.litPopUp.Visible = true;
            }
        }

        protected void btnEdit_Click(object sender, System.EventArgs e)
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;

            try
            {
                TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
                int result;

                result = DateTime.Compare(DateTime.Parse(taskControl.ExpirationDate), DateTime.Now);

                if (taskControl.CancellationEntryDate == "" && result < 0 && cp.IsInRole("OVERRIDEEXPDATE"))
                {
                    int mmode = 1;
                    Session.Add("CancellationEdit", mmode);

                    DefaultValue();
                    EnableControls();
                }
                else if (taskControl.CancellationEntryDate == "" && result < 0 && !cp.IsInRole("FREECANCELLATION")) //Permission to apply cancellation on expired policy
                {
                    throw new Exception(
                    "Unable to apply cancellations on an expired policy.");
                }
                else if (taskControl.CancellationDate != "")
                {
                    int mmode = 2;
                    Session.Add("CancellationEdit", mmode);

                    DefaultValue();
                    EnableControls();
                }
                else
                {
                    int mmode = 1;
                    Session.Add("CancellationEdit", mmode);

                    DefaultValue();
                    EnableControls();
                }
                if (taskControl.PolicyType.Trim() == "EMD" || taskControl.PolicyType.Trim() == "EMDT")
                {
                    TxtCancellationEntryDate.Text = DateTime.Today.ToShortDateString();
                    TxtCancellationEntryDate.Enabled = false;
                }
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }
        }

        public void CalculatedCancellation(bool FromSave)
        {
            try
            {
                validateCalculate();

                TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];

                taskControl.CalculateReturnPremium(DateTime.Parse(txtCancellationDate.Text), int.Parse(ddlCancellationMethod.SelectedItem.Value), int.Parse(ddlCancellationReason.SelectedItem.Value.ToString()));

                Session.Add("TaskControl", taskControl);

                //if (FromSave == true)
                //FillTextControl();
                TxtCancellationEntryDate.Text = taskControl.CancellationEntryDate.Trim();
                TxtUnearnedPercent.Text = taskControl.CancellationUnearnedPercent.ToString("###,###.00");
                TxtReturnPremium.Text = taskControl.ReturnPremium.ToString("###,###.00");
                TxtReturnCharge.Text = taskControl.ReturnCharge.ToString("###,###.00");
                TxtTotalReturnPremium.Text = taskControl.CancellationAmount.ToString("###,###.00");
            }
            catch (Exception xcp)
            {
                if (FromSave)
                {
                    throw new Exception(xcp.Message);
                }
                else
                {
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(xcp.Message);
                    this.litPopUp.Visible = true;
                }
            }
        }

        public void validateCalculate()
        {
            TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];

            string errorMessage = String.Empty;

           
            if (this.txtCancellationDate.Text == "")
                errorMessage = "Cancellation Date is missing or wrong.";
            //if (this.txtRSCDate.Text == "")
               // errorMessage = "Date is missing or wrong";
            //else
                if (this.ddlCancellationMethod.SelectedItem.Value == "")
                    errorMessage = "Cancellation Method is missing or wrong.";
                else
                    if (this.ddlCancellationReason.SelectedItem.Value == "")
                        errorMessage = "Cancellation Reason is missing or wrong.";
                    else
                        if (DateTime.Parse(this.txtCancellationDate.Text) < DateTime.Parse(taskControl.EffectiveDate))//> DateTime.Parse(DateTime.Now.ToShortDateString()))
                            errorMessage = "The Cancellation Date date must be equal or later than the Effective Date.";
                        else
                            if (DateTime.Parse(this.txtCancellationDate.Text + " 00:00:00.000") > DateTime.Parse(taskControl.ExpirationDate))
                                errorMessage = "The Cancellation Date date must be equal or earlier than the Expiration Date.";

            //throw the exception.
            if (errorMessage != String.Empty)
            {
                throw new Exception(errorMessage);
            }
        }

        protected void btnPrint_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            TaskControl.AutoGap taskControl = (TaskControl.AutoGap)Session["TaskControl"];

            ActiveReport3 rpt = new ActiveReport3();

            //rpt = new AutoGapCancellation(taskControl);
            //rpt.Run();

            for (int i = 1; i <= 4; i++)
            {
                //CancellationCredit rpt1 = new CancellationCredit(taskControl,txtCancellationDate.Text);				
                //rpt1.Run(false);

                //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count,rpt1.Document.Pages);		

            }

            Session.Add("Report", rpt);
            Session.Add("FromPage", "CancellationPolicy.aspx");
            Response.Redirect("ActiveXViewer.aspx", false);
        }

        protected void BtnCalculate_Click(object sender, System.EventArgs e)
        {
            CalculatedCancellation(false);
        }
        protected void ddlCancellationReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCancellationReason.SelectedItem.ToString() == "Insured Property Sold" || ddlCancellationReason.SelectedItem.ToString() == "Other Insurance Purchased" || ddlCancellationReason.SelectedItem.ToString() == "Finance Request")
            {
                Label27.Visible = true;
                txtRSCDate.Visible = true;
                
            }
            else
            {
                Label27.Visible = false;
                txtRSCDate.Visible = false;
            }
        }
        protected void ddlCancellationMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCancellationMethod.SelectedIndex == 2)
            {
                Label28.Visible = true;
                txtMOCDesc.Visible = true;
                
            }
            else
            {
                Label28.Visible = false;
                txtMOCDesc.Visible = false;
            }
        }

        private void History(int taskControlID, int userID, string action, string subject, string note)
        {
            Audit.History history = new Audit.History();
            TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];

            history.Actions = action;
            history.KeyID = taskControlID.ToString();
            history.Subject = subject;
            //history.BuildNotesForHistory("TaskControlID.", "", taskControlID.ToString(), 7);  //7 = mode NOTICEOFCANC
            history.UsersID = userID;
            history.Notes = note + "\r\n";
            history.GetSaveHistory();
        }
     
        protected void txtMOCDesc_TextChanged(object sender, EventArgs e)
        {

        }
}
}
