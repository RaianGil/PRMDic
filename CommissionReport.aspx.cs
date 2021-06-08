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
using EPolicy2.Reports;
using System.IO;
using System.Net;
using System.Text;

namespace EPolicy
{
	/// <summary>
	/// Summary description for CommissionReport.
	/// </summary>
    public partial class CommissionReport : System.Web.UI.Page
    {

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
                if (!cp.IsInRole("BTNREPORTLEFTMENU") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    Response.Redirect("HomePage.aspx?001");
                }
            }

            if (!IsPostBack)
            {
                FillDDLAgents();
            }
        }

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
            //((Baldrich.BaldrichWeb.Components.TopBanner)Banner).SelectedOption = (int)Baldrich.HeadBanner.MenuOptions.Home;
            this.Placeholder1.Controls.Add(Banner);

            //Setup Left-side Banner

            /*Control LeftMenu = new Control();
            LeftMenu = LoadControl(@"LeftReportMenu.ascx");
            //((Baldrich.BaldrichWeb.Components.MenuEventControl)LeftMenu).Height = "534px";
            phTopBanner1.Controls.Add(LeftMenu);*/


            //Load DownDropList
            DataTable dtPolicyClass = LookupTables.LookupTables.GetTable("PolicyClass");
            DataTable dtAgency = LookupTables.LookupTables.GetTable("Agency");
            
            //PolicyClass
            ddlPolicyClass.DataSource = dtPolicyClass;
            ddlPolicyClass.DataTextField = "PolicyClassDesc";
            ddlPolicyClass.DataValueField = "PolicyClassID";
            ddlPolicyClass.DataBind();
            ddlPolicyClass.SelectedIndex = -1;
            ddlPolicyClass.Items.Insert(0, "");

            //Agency
            ddlAgency.DataSource = dtAgency;
            ddlAgency.DataTextField = "AgencyDesc";
            ddlAgency.DataValueField = "AgencyID";
            ddlAgency.DataBind();
            ddlAgency.SelectedIndex = -1;
            ddlAgency.Items.Insert(0, "");

            //Agent
            
            //((DropDownList)dtGridAgents.Items[0].Cells[0].FindControl("ddlAgent")).Items.Insert(0, "");
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion

        protected void Button2_Click(object sender, System.EventArgs e)
        {
            try
            {
                FieldVerify();
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
                return;
            }

            switch (rblProspectsReports.SelectedItem.Value)
            {
                case "0":
                    CommissionAgency();
                    break;

                case "1":
                    CommissionAgent();
                    break;

                case "2":
                    CommissionAging();
                    break;
            }
        }

        private void FieldVerify()
        {
            string errorMessage = String.Empty;
            bool found = false;

            if (this.txtBegDate.Text == "" && this.TxtEndDate.Text != "" &&
                found == false)
            {
                errorMessage = "Please enter the beginning date.";
                found = true;
            }
            if (this.txtBegDate.Text != "" && this.TxtEndDate.Text == "" &&
                found == false)
            {
                errorMessage = "Please enter the ending date.";
                found = true;
            }
            else if (this.txtBegDate.Text == "" && this.TxtEndDate.Text == "" &&
                found == false)
            {
                errorMessage = "Please enter the beginning date and ending date.";
                found = true;
            }
            else if ((this.txtBegDate.Text != "" && this.TxtEndDate.Text != "" &&
                DateTime.Parse(this.txtBegDate.Text) > DateTime.Parse(this.TxtEndDate.Text)) && found == false)
            {
                errorMessage = "The Ending Date must be later than beginning date.";
                found = true;
            }

            if (rblProspectsReports.SelectedItem.Value == "2" && this.txtBegDate.Text == "")
            {
                errorMessage = "Please enter the beginning date.";
                found = true;
            }

            if (rblProspectsReports.SelectedItem.Value == "2" && ddlAgency.SelectedItem.Value == "")
            {
                errorMessage = "Please select an Agency.";
                found = true;
            }

            if (rblProspectsReports.SelectedItem.Value == "2" && this.txtBegDate.Text != "" && ddlAgency.SelectedItem.Value != "")
            {
                errorMessage = "";
                found = false;
            }

            //throw the exception.
            if (errorMessage != String.Empty)
            {
                throw new Exception(errorMessage);
            }
        }

        public void CommissionAgency()
        {
            EPolicy2.Reports.AutoGuardServicesContractReport appAutoreport = new EPolicy2.Reports.AutoGuardServicesContractReport();
            DataTable dt = appAutoreport.CommissionReportByAgency(txtBegDate.Text, TxtEndDate.Text, ddlAgency.SelectedItem.Value, ddlDateType.SelectedItem.Value, "9", chkAccountType.SelectedValue);

            string CompanyHead = "";

            if (ddlAgency.SelectedItem.Value.Trim() != "")
            {
                if (dt.Rows.Count != 0)
                {
                    CompanyHead = ddlAgency.SelectedItem.Text.ToString().ToUpper();//dt.Rows[0]["InsuranceCompanyDesc"].ToString().Trim();
                }
            }
            else
            {
                CompanyHead = "PUERTO RICO MEDICAL DEFENSE INSURANCE COMPANY";
            }


            DataDynamics.ActiveReports.ActiveReport3 rpt = new PremiumWrittenbyAgent(txtBegDate.Text, TxtEndDate.Text, "Commission Statement by Agency", false, CompanyHead);

            //rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;

            rpt.DataSource = dt;
            rpt.DataMember = "Report";

            rpt.Document.Printer.PrinterName = "";

            rpt.Run(false);

            Session.Add("Report", rpt);
            Session.Add("FromPage", "CommissionReport.aspx");
            Response.Redirect("ActiveXViewer.aspx", false);
        }

        public void CommissionAgent()
        {
            DataDynamics.ActiveReports.ActiveReport3[] rptArray = new DataDynamics.ActiveReports.ActiveReport3[int.Parse(txtNumAgents.Text)];
            DataDynamics.ActiveReports.ActiveReport3 rpt = null;

            for (int i = 0; i < int.Parse(txtNumAgents.Text); i++)
            {
                EPolicy2.Reports.AutoGuardServicesContractReport appAutoreport = new EPolicy2.Reports.AutoGuardServicesContractReport();
                DataTable dt = appAutoreport.CommissionReportByAgent(txtBegDate.Text, TxtEndDate.Text, ((DropDownList)dtGridAgents.Items[i].Cells[0].FindControl("ddlAgent")).SelectedValue, ddlDateType.SelectedItem.Value, "9", int.Parse(rblAgentLevel.SelectedItem.Value));

                string CompanyHead = "";

                if (ddlPolicyClass.SelectedItem.Value.Trim() != "")
                {
                    if (dt.Rows.Count != 0)
                    {
                        CompanyHead = dt.Rows[0]["InsuranceCompanyDesc"].ToString().Trim();
                    }
                }
                else
                {
                    CompanyHead = "PUERTO RICO MEDICAL DEFENSE INSURANCE COMPANY";
                }


                rptArray[i] = new PremiumWrittenbyAgent2(txtBegDate.Text, TxtEndDate.Text, "Commission Statement for " + ((DropDownList)dtGridAgents.Items[i].Cells[0].FindControl("ddlAgent")).SelectedItem.ToString(), false, CompanyHead);

                //rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;

                rptArray[i].DataSource = dt;
                rptArray[i].DataMember = "Report";

                rptArray[i].Document.Printer.PrinterName = "";

                rptArray[i].Run(false);

                if (i == 0)
                    rpt = rptArray[0];
                else
                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rptArray[i].Document.Pages);
            }
            Session.Add("Report", rpt);
            Session.Add("FromPage", "CommissionReport.aspx");
            Response.Redirect("ActiveXViewer.aspx", false);
        }

        public void CommissionAging()
        {
            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
            string userName = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();
            if (cp == null)
            {
                Response.Redirect("Default.aspx?001");
            }
            else
            {
                if (!cp.IsInRole("POLICIESREPORTS") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    Response.Redirect("Default.aspx?001");
                }
            }

            Session.Add("dateFrom", txtBegDate.Text);
            //Session.Add("dateTo", TxtEndDate.Text);
            Session.Add("agency", ddlAgency.SelectedItem.Value.ToString());
            Session.Add("userName", userName);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('RDLCReport.aspx','Reports','addressbar=no,status=1,menubar=0,scrollbars=0,resizable=0,copyhistory=no,width=900,height=640');", true);


        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("MainMenu.aspx", false);
        }
        protected void rblProspectsReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableControl();
        }

        private void EnableControl()
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
            if (cp == null)
            {
                Response.Redirect("HomePage.aspx?001");
            }
            else
            {
                if (!cp.IsInRole("POLICIESREPORTS") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    Response.Redirect("HomePage.aspx?001");
                }
            }

            switch (rblProspectsReports.SelectedItem.Value)
            {
                case "0":			//Agency
                    ddlAgency.Visible = true;
                    dtGridAgents.Visible = false;
                    LblAgency.Visible = true;
                    lblAgent.Visible = false;
                    txtNumAgents.Visible = false;
                    LblNumAgents.Visible = false;
                    btnUpdate.Visible = false;
                    lblAgentLevel.Visible = false;
                    rblAgentLevel.Visible = false;
                    Label2.Visible = true;
                    TxtEndDate.Visible = true;
                    chkAccountType.Visible = true;
                    break;

                case "1":			//Agent
                    ddlAgency.Visible = false;
                    dtGridAgents.Visible = true;
                    LblAgency.Visible = false;
                    lblAgent.Visible = true;
                    txtNumAgents.Visible = true;
                    LblNumAgents.Visible = true;
                    btnUpdate.Visible = true;
                    Label2.Visible = true;
                    TxtEndDate.Visible = true;
                    chkAccountType.Visible = false;
                    if (!cp.IsInRole("PRMDIC-USER") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        lblAgentLevel.Visible = false;
                        rblAgentLevel.Visible = false;
                    }
                    else
                    {
                        lblAgentLevel.Visible = true;
                        rblAgentLevel.Visible = true;
                    }
                    break;

                case "2":			//Aging
                    ddlAgency.Visible = true;
                    dtGridAgents.Visible = false;
                    LblAgency.Visible = true;
                    lblAgent.Visible = false;
                    txtNumAgents.Visible = false;
                    LblNumAgents.Visible = false;
                    btnUpdate.Visible = false;
                    lblAgentLevel.Visible = false;
                    rblAgentLevel.Visible = false;
                    Label2.Visible = false;
                    TxtEndDate.Visible = false;
                    lblAgentLevel.Visible = false;
                    rblAgentLevel.Visible = false;
                    LblDataType.Visible = false;
                    ddlDateType.Visible = false;
                    chkAccountType.Visible = false;
                    break;                   
            }
        }

        private void FillDDLAgents()
        {
            DataTable dtAgent = LookupTables.LookupTables.GetTable("Agent");

            DataTable dt = new DataTable();

            for (int i = 0; i < int.Parse(txtNumAgents.Text); i++)
                dt.Rows.Add();

            this.dtGridAgents.DataSource = dt;
            this.dtGridAgents.DataBind();

            for (int i = 0; i <= int.Parse(txtNumAgents.Text); i++)
            {
                ((DropDownList)dtGridAgents.Items[0].Cells[0].FindControl("ddlAgent")).DataSource = dtAgent;
                ((DropDownList)dtGridAgents.Items[0].Cells[0].FindControl("ddlAgent")).DataTextField = "AgentDesc";
                ((DropDownList)dtGridAgents.Items[0].Cells[0].FindControl("ddlAgent")).DataValueField = "AgentID";
                ((DropDownList)dtGridAgents.Items[0].Cells[0].FindControl("ddlAgent")).DataBind();
                ((DropDownList)dtGridAgents.Items[0].Cells[0].FindControl("ddlAgent")).SelectedIndex = -1;
            }
        }
        protected void btnUpdate_Click(object sender, System.EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Agents");

            DataTable dtAgent = LookupTables.LookupTables.GetTable("Agent");

            try
            {
                int index = int.Parse(txtNumAgents.Text.Trim());

                for (int i = 0; i < index; i++)
                    dt.Rows.Add();
                
                this.dtGridAgents.DataSource = dt;
                this.dtGridAgents.DataBind();

                for (int i = 0; i < index; i++)
                {
                    ((DropDownList)dtGridAgents.Items[i].Cells[0].FindControl("ddlAgent")).DataSource = dtAgent;
                    ((DropDownList)dtGridAgents.Items[i].Cells[0].FindControl("ddlAgent")).DataTextField = "AgentDesc";
                    ((DropDownList)dtGridAgents.Items[i].Cells[0].FindControl("ddlAgent")).DataValueField = "AgentID";
                    ((DropDownList)dtGridAgents.Items[i].Cells[0].FindControl("ddlAgent")).DataBind();
                    ((DropDownList)dtGridAgents.Items[i].Cells[0].FindControl("ddlAgent")).SelectedIndex = -1;
                }
                txtNumAgents.Text = index.ToString();
                
            }
            catch
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Empty or unknown number of agents.");
                this.litPopUp.Visible = true;
                return;
            }
         }
    }
}
