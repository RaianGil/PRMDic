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
using Baldrich.DBRequest;
using EPolicy.XmlCooker;
using System.IO;
using System.Net;
using System.Text;
using EPolicy.LookupTables;
using EPolicy.TaskControl;
using EPolicy2.Reports;
using EPolicy;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Xml;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;

namespace EPolicy
{
	/// <summary>
	/// Summary description for AutoGuardServicesContractReport.
	/// </summary>
    public partial class PoliciesReports : System.Web.UI.Page
    {
        private string FileName;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.litPopUp.Visible = false;

            Login.Login cp = HttpContext.Current.User as Login.Login;
            if (cp == null)
            {
                Response.Redirect("Default.aspx?001");
            }
            else
            {

                if (cp.IsInRole("REPORTRENEWAL"))
                {
                    Response.Redirect("RenewalReport.aspx");

                }

                else
                {
                    if (!cp.IsInRole("POLICIESREPORTS") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        Response.Redirect("Default.aspx?001");
                    }

                }
            }

            if (!IsPostBack)
            {
                EnableControl();
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

            /*Control LeftMenu = new Control();
            LeftMenu = LoadControl(@"LeftReportMenu.ascx");
            //((Baldrich.BaldrichWeb.Components.MenuEventControl)LeftMenu).Height = "534px";
            phTopBanner1.Controls.Add(LeftMenu);*/

            //Load DownDropList
            DataTable dtInsuranceCompany = LookupTables.LookupTables.GetTable("InsuranceCompany");
            DataTable dtPolicyClass = LookupTables.LookupTables.GetTable("PolicyClass");
            DataTable dtAgency = LookupTables.LookupTables.GetTable("Agency");
            DataTable dtAgent = LookupTables.LookupTables.GetTable("Agent");
           
            EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
            DataTable dtGroup = master.GetMasterPolicyByIsGroup(true);
 
            //Group
            ddlGroup.DataSource = dtGroup;
            ddlGroup.DataTextField = "MasterPolicyDesc";
            ddlGroup.DataValueField = "MasterPolicyID";
            ddlGroup.DataBind();
            ddlGroup.SelectedIndex = -1;
            ddlGroup.Items.Insert(0, "");

            //Agency
            ddlAgent.DataSource = dtAgency;
            ddlAgent.DataTextField = "AgencyDesc";
            ddlAgent.DataValueField = "AgencyID";
            ddlAgent.DataBind();
            ddlAgent.SelectedIndex = -1;
            ddlAgent.Items.Insert(0, "");

            //Agent
            ddlAgent0.DataSource = dtAgent;
            ddlAgent0.DataTextField = "AgentDesc";
            ddlAgent0.DataValueField = "AgentID";
            ddlAgent0.DataBind();
            ddlAgent0.SelectedIndex = -1;
            ddlAgent0.Items.Insert(0, "");

            //InsuranceCompany
            ddlInsuranceCompany.DataSource = dtInsuranceCompany;
            ddlInsuranceCompany.DataTextField = "InsuranceCompanyDesc";
            ddlInsuranceCompany.DataValueField = "InsuranceCompanyID";
            ddlInsuranceCompany.DataBind();
            ddlInsuranceCompany.SelectedIndex = -1;
            ddlInsuranceCompany.Items.Insert(0, "");

            //Policy Class
            ddlPolicyClass.DataSource = dtPolicyClass;
            ddlPolicyClass.DataTextField = "PolicyClassDesc";
            ddlPolicyClass.DataValueField = "PolicyClassID";
            ddlPolicyClass.DataBind();
            ddlPolicyClass.SelectedIndex = -1;
            ddlPolicyClass.Items.Insert(0, "");

        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPrint1.Click += new System.Web.UI.ImageClickEventHandler(this.btnPrint_Click);

        }
        #endregion

        protected void btnPrint_Click(object sender, System.Web.UI.ImageClickEventArgs e)
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

            switch (rblAutoGuardReports.SelectedItem.Value)
            {
                case "0":
                    AutoGuardPremiumWritten();
                    break;

                case "1":
                    AutoGuardCertificateOutstanding();
                    break;

                case "2":
                    AutoGuardCertificatePaid();
                    break;

                case "3":
                    MonthlyPolicyProduction();
                    //CancellationNotice();
                    break;

                case "4":
                    AnualPolicyProduction();   //FollowUpCancellation();
                    break;

                case "5":
                    //AutoGuardTodayPayments();
                    break;

                case "6":
                    CertificatePaidAndEffectivity();
                    break;

            }
        }

        protected void BtnExit_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Response.Redirect("MainMenu.aspx", false);

        }

        private void FieldVerify()
        {
            string errorMessage = String.Empty;
            bool found = false;

            if (this.rblAutoGuardReports.SelectedItem.Value == "0" || this.rblAutoGuardReports.SelectedItem.Value == "2"
                || this.rblAutoGuardReports.SelectedItem.Value == "5")
            {
                if (this.TxtEndDate.Text == "" &&
                    found == false)
                {
                    errorMessage = "Please enter the ending date.";
                    found = true;
                }
            }

            //throw the exception.
            if (errorMessage != String.Empty)
            {
                throw new Exception(errorMessage);
            }

            if (this.rblAutoGuardReports.SelectedItem.Value == "1")
            {
                if (this.txtOutstandingDate.Text == "")
                {
                    errorMessage = "Please enter the outstanding date.";
                    found = true;
                }

                //throw the exception.
                if (errorMessage != String.Empty)
                {
                    throw new Exception(errorMessage);
                }
            }
        }


        private void AutoGuardPremiumWritten()
        {
            try
            {
                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = 0;
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                EPolicy2.Reports.AutoGuardServicesContractReport appAutoreport = new EPolicy2.Reports.AutoGuardServicesContractReport();
                DataTable dt = null;
                DataDynamics.ActiveReports.ActiveReport3 rpt = null;

                string dateType = ddlDateType.SelectedItem.Value.Trim();
                string mHead = "";
                string CompanyHead = "";

                if (ddlDateType.SelectedItem.Value.Trim() == "E")
                    mHead = "Premium written & Cancellations - Entry Date Criteria";
                else if (ddlDateType.SelectedItem.Value.Trim() == "C")
                    mHead = "Premium written & Cancellations - Cancellation Date Criteria";
                else if (ddlDateType.SelectedItem.Value.Trim() == "F")
                    mHead = "Premium written & Cancellations - Effective Date Criteria";
                else
                    mHead = "Premium written & Cancellations - Cancellation Entry Date Criteria";

                if(rblFilterBy.SelectedItem.Value == "A")
                    dt = appAutoreport.AutoGuardPremiumWritten(txtBegDate.Text, TxtEndDate.Text, ddlAgent.SelectedItem.Value.Trim(),
                    ddlDateType.SelectedItem.Value.Trim(), ddlPolicyType.SelectedItem.Value, userID, "A", ddlGroup.SelectedItem.Value);
                else
                    dt = appAutoreport.AutoGuardPremiumWritten(txtBegDate.Text, TxtEndDate.Text, ddlAgent0.SelectedItem.Value.Trim(),
                    ddlDateType.SelectedItem.Value.Trim(), ddlPolicyType.SelectedItem.Value, userID, "B", ddlGroup.SelectedItem.Value);

                if(ChkEndorsement.Checked)
                  dt = appAutoreport.AutoGuardPremiumWrittenEndorsement(txtBegDate.Text, TxtEndDate.Text, ddlAgent.SelectedItem.Value.Trim(),
                                      ddlDateType.SelectedItem.Value.Trim(), ddlPolicyType.SelectedItem.Value, userID, "A", ddlGroup.SelectedItem.Value);
                

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

                rpt = new EPolicy2.Reports.AutoGuard.AutoGuardPremiumWritten(txtBegDate.Text, TxtEndDate.Text, mHead, ChkSummary.Checked, CompanyHead);

                if (ChkEndorsement.Checked)
                   rpt = new EPolicy2.Reports.AutoGuard.AutoGuardPremiumWrittenEndorsement(txtBegDate.Text, TxtEndDate.Text, mHead, ChkSummary.Checked, CompanyHead);


                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No information exists for this report");
                }

                rpt.DataSource = dt;
                rpt.DataMember = "Report";
                rpt.Name = "PremiumWritten";

                rpt.Document.Printer.PrinterName = "";

                rpt.Run(false);

                Session.Add("Report", rpt);
                Session.Add("FromPage", "PoliciesReports.aspx");
                Response.Redirect("ActiveXViewer.aspx", false);
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
                return;
            }
        }

        private void PolicyPremiumEarned()
        {
            try
            {
                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = 0;
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                EPolicy2.Reports.AutoGuardServicesContractReport appAutoreport = new EPolicy2.Reports.AutoGuardServicesContractReport();
                DataTable dt = null;
                DataDynamics.ActiveReports.ActiveReport3 rpt = null;

                string dateType = ddlDateType.SelectedItem.Value.Trim();
                string mHead = "";
                string CompanyHead = "";

                mHead = "Premium Earned";

                dt = appAutoreport.AutoGuardPremiumAndCommissionEarned(txtBegDate.Text, TxtEndDate.Text,
                    txtFollowUpCancellation.Text.Trim(),ddlPolicyType.SelectedItem.Value);

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

                //rpt = new EPolicy2.Reports.AutoGuardPremiumAndComissionEarned(txtBegDate.Text, TxtEndDate.Text, mHead, txtFollowUpCancellation.Text.Trim(), ChkSummary.Checked);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("Don't exist any information for this report");
                }
                else
                {
                    CreateVSCExcellFile(dt);
                }

                //rpt.DataSource = dt;
                //rpt.DataMember = "Report";

                //rpt.Document.Printer.PrinterName = "";

                //rpt.Run(false);

                //Session.Add("Report", rpt);
                //Session.Add("FromPage", "PoliciesReports.aspx");
                //Response.Redirect("ActiveXViewer.aspx", false);
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
                return;
            }
        }

        private void Renewal()
        {
            try
            {
                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = 0;
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                EPolicy2.Reports.AutoGuardServicesContractReport appAutoreport = new EPolicy2.Reports.AutoGuardServicesContractReport();
                DataTable dt = null;
                DataDynamics.ActiveReports.ActiveReport3 rpt = null;

                string dateType = ddlDateType.SelectedItem.Value.Trim();
                string mHead = "";
                string CompanyHead = "";
                mHead = "Renewals - Expiration Date Criteria";

                string PolicyType = "";
                int actualPolicies = 0;

                if (ChkActualPolicies.Checked)
                    actualPolicies = 1;

                if (rblFilterBy.SelectedItem.Value == "A")
                    dt = appAutoreport.AutoGuardPremiumRenewal(txtBegDate.Text.Trim(), TxtEndDate.Text.Trim(), ddlAgent.SelectedItem.Value.Trim(),
                    ddlPolicyType.SelectedItem.Value, 1);//, actualPolicies);
                else
                    dt = appAutoreport.AutoGuardPremiumRenewal(txtBegDate.Text.Trim(), TxtEndDate.Text.Trim(), ddlAgent0.SelectedItem.Value.Trim(),
                    ddlPolicyType.SelectedItem.Value, 2);//, actualPolicies);

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

                rpt = new EPolicy2.Reports.PRMdic.Renewal("", "", mHead, ChkSummary.Checked, CompanyHead);

                if (dt.Rows.Count == 0)
                {
                    throw new Exception("Unable to generate this report.");
                }

                rpt.DataSource = dt;
                rpt.DataMember = "Report";

                rpt.Document.Printer.PrinterName = "";

                rpt.Run(false);

                Session.Add("Report", rpt);
                Session.Add("FromPage", "PoliciesReports.aspx");
                Response.Redirect("ActiveXViewer.aspx", false);
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
                return;
            }
        }

        private void AutoGuardCertificateOutstanding()
        {
            try
            {
                EPolicy2.Reports.AutoGuardServicesContractReport appAutoreport = new EPolicy2.Reports.AutoGuardServicesContractReport();
                string CompanyHead = "";
                DataTable dt = null;
                DataDynamics.ActiveReports.ActiveReport3 rpt = null;

                if(rblFilterBy.SelectedItem.Value == "A")
                    dt = appAutoreport.AutoGuardCertificateOutstanding(txtOutstandingDate.Text, 1, ddlAgent.SelectedItem.Value.Trim(),chkPartialPayments.Checked,int.Parse(rblOutstandingStatus.SelectedItem.Value.ToString()));
                else
                    dt = appAutoreport.AutoGuardCertificateOutstanding(txtOutstandingDate.Text, 2, ddlAgent0.SelectedItem.Value.Trim(), chkPartialPayments.Checked, int.Parse(rblOutstandingStatus.SelectedItem.Value.ToString()));
                
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

                rpt = new AutoGuardCertificateOustanding(txtOutstandingDate.Text, "Policies Outstanding", ChkSummary.Checked, CompanyHead);


                if (dt.Rows.Count == 0)
                {
                    throw new Exception("Don't exist any information for this report");
                }

                //rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;

                rpt.DataSource = dt;
                rpt.DataMember = "Report";

                rpt.Document.Printer.PrinterName = "";

                rpt.Run(false);

                Session.Add("Report", rpt);
                Session.Add("FromPage", "PoliciesReports.aspx");
                Response.Redirect("ActiveXViewer.aspx", false);
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
                return;
            }
        }

        private void AutoGuardCertificatePaid()
        {
            try
            {
                //TaskControl.AutoGuardServicesContract taskControl = new TaskControl.AutoGuardServicesContract();// (TaskControl.AutoGuardServicesContract) Session["TaskControl"];
                EPolicy2.Reports.AutoGuardServicesContractReport appAutoreport = new EPolicy2.Reports.AutoGuardServicesContractReport();
                DataTable dt = null;
                DataDynamics.ActiveReports.ActiveReport3 rpt = null;
                string CompanyHead = "";


                dt = appAutoreport.AutoGuardCertificatePaid(txtBegDate.Text, TxtEndDate.Text, ddlAgent.SelectedItem.Value.Trim());

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

                rpt = new AutoGuardCertificatePaid(txtBegDate.Text, TxtEndDate.Text, "Policies & Cancellations Paid", ChkSummary.Checked, dt, CompanyHead);

                
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("Don't exist any information for this report");
                }

                //rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;

                rpt.DataSource = dt;
                rpt.DataMember = "Report";

                rpt.Document.Printer.PrinterName = "";

                rpt.Run(false);

                Session.Add("Report", rpt);
                Session.Add("FromPage", "PoliciesReports.aspx");
                Response.Redirect("ActiveXViewer.aspx", false);
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
                return;
            }

            //			EPolicy2.Reports.AutoGuardServicesContractReport appAutoreport = new EPolicy2.Reports.AutoGuardServicesContractReport();
            //			DataTable dt = appAutoreport.AutoGuardCertificatePaid(txtBegDate.Text,TxtEndDate.Text,ddlDealer.SelectedItem.Value.Trim(),ddlInsuranceCompany.SelectedItem.Value.Trim());
            //	
            //			try
            //			{
            //				if (dt.Rows.Count == 0)
            //				{
            //					throw new Exception("Don't exist any information for this report");
            //				}
            //
            //				DataDynamics.ActiveReports.ActiveReport rpt = new AutoGuardCertificatePaid(txtBegDate.Text,TxtEndDate.Text,"Certificate Paid & Cancellations",ChkSummary.Checked, dt);
            //
            //				rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            //			
            //				rpt.DataSource = dt;
            //				rpt.DataMember = "Report";
            //				rpt.Run(false);
            //
            //				Session.Add("Report",rpt);
            //				Session.Add("FromPage","PoliciesReports.aspx");
            //				Response.Redirect("ActiveXViewer.aspx",false);
            //			}
            //			catch (Exception exp)
            //			{
            //				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
            //				this.litPopUp.Visible = true;
            //				return;
            //			}
        }

        private void CancellationNotice()
        {
            //Login.Login cp = HttpContext.Current.User as Login.Login;
            //int userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

            //EPolicy2.Reports.AutoGuardServicesContractReport appAutoreport = new EPolicy2.Reports.AutoGuardServicesContractReport();
            //DataTable dt = appAutoreport.CancellationNotice();

            ////Filtrar tabla para que salgan todos los que tengan bancos.
            //DataTable dtbank = new DataTable();
            //dtbank = dt.Copy();

            //for (int i = 0; i <= dtbank.Rows.Count - 1; i++)
            //{
            //    if (dtbank.Rows[i]["BankID"].ToString().Trim() == "000")
            //        dtbank.Rows[i].Delete();
            //}
            //dtbank.AcceptChanges();
            //// Filtrar tabla.

            //ActiveReport3 rpt = new ActiveReport3();

            //try
            //{
            //    if (dt.Rows.Count == 0)
            //    {
            //        throw new Exception("Don't exist any information for this report");
            //    }

            //    //Address for Ins.
            //    rpt = new EPolicy2.Reports.AutoGuard.CancellationNotice();
            //    rpt.DataSource = dt;

            //    rpt.Document.Printer.PrinterName = "";

            //    rpt.Run();

            //    //Address for bank
            //    ActiveReport3 rpt1 = new ActiveReport3();

            //    rpt1 = new EPolicy2.Reports.AutoGuard.CancellationNoticeForBank();
            //    rpt1.DataSource = dtbank;

            //    rpt1.Document.Printer.PrinterName = "";

            //    rpt1.Run();
            //    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt1.Document.Pages);

            //    for (int a = 0; a <= dt.Rows.Count - 1; a++)
            //    {
            //        DataTable dt1 = GetAutoGuardDetailInfo(int.Parse(dt.Rows[a]["TaskControlID"].ToString()));

            //        //4 copias de aviso de canc.
            //        for (int e = 1; e <= 4; e++)
            //        {
            //            rpt1 = new EPolicy2.Reports.AutoGuard.CartaCancellationNotice();
            //            rpt1.DataSource = dt1;
            //            rpt1.Run();

            //            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt1.Document.Pages);
            //        }

            //        this.History(int.Parse(dt.Rows[a]["TaskControlID"].ToString()), userID);
            //    }

            //    Session.Add("Report", rpt);
            //    Session.Add("FromPage", "PoliciesReports.aspx");
            //    Response.Redirect("ActiveXViewer.aspx", false);
            //}
            //catch (Exception exp)
            //{
            //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
            //    this.litPopUp.Visible = true;
            //    return;
            //}
        }

        //		private void FollowUpCancellation()
        //		{
        //			EPolicy2.Reports.AutoGuardServicesContractReport appAutoreport = new EPolicy2.Reports.AutoGuardServicesContractReport();
        //			DataTable dt = appAutoreport.AutoGuardFollowUpCancellation(txtFollowUpCancellation.Text);
        //	
        //			try
        //			{
        //				if (dt.Rows.Count == 0)
        //				{
        //					throw new Exception("Don't exist any information for this report");
        //				}
        //
        //				DataDynamics.ActiveReports.ActiveReport rpt = new FollowUpCancellation(txtFollowUpCancellation.Text,"Follow Up Cancellation",ChkSummary.Checked);
        //
        //				rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
        //			
        //				rpt.DataSource = dt;
        //				rpt.DataMember = "Report";
        //				rpt.Run(false);
        //
        //				Session.Add("Report",rpt);
        //				Session.Add("FromPage","PoliciesReports.aspx");
        //				Response.Redirect("ActiveXViewer.aspx",false);
        //			}
        //			catch (Exception exp)
        //			{
        //				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
        //				this.litPopUp.Visible = true;
        //				return;
        //			}
        //		}

        //		private void AutoGuardTodayPayments()
        //		{
        //			EPolicy2.Reports.AutoGuardServicesContractReport appAutoreport = new EPolicy2.Reports.AutoGuardServicesContractReport();
        //			DataTable dt = appAutoreport.AutoGuardTodayPayments(txtFollowUpCancellation.Text);
        //	
        //			try
        //			{
        //				if (dt.Rows.Count == 0)
        //				{
        //					throw new Exception("Don't exist any information for this report");
        //				}
        //
        //				DataDynamics.ActiveReports.ActiveReport rpt = new TodayPayments(txtFollowUpCancellation.Text,"Today Payments",ChkSummary.Checked);
        //
        //				rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
        //			
        //				rpt.DataSource = dt;
        //				rpt.DataMember = "Report";
        //				rpt.Run(false);
        //
        //				Session.Add("Report",rpt);
        //				Session.Add("FromPage","PoliciesReports.aspx");
        //				Response.Redirect("ActiveXViewer.aspx",false);
        //			}
        //			catch (Exception exp)
        //			{
        //				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
        //				this.litPopUp.Visible = true;
        //				return;
        //			}
        //		}

        private DataTable GetAutoGuardDetailInfo(int taskControlID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, taskControlID.ToString(),
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
            DataTable dt = null;
            try
            {
                dt = exec.GetQuery("GetAutoGuardCancellationNotice2", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not validated the Auto Guard Report.", ex);
            }
        }

        private void CertificatePaidAndEffectivity()
        {
            EPolicy2.Reports.AutoGuardServicesContractReport appAutoreport = new EPolicy2.Reports.AutoGuardServicesContractReport();
            DataTable dt = appAutoreport.AutoGuardCertificatePaidAndEffectivity(txtBegDate.Text, TxtEndDate.Text, ddlDealer.SelectedItem.Value.Trim(), "");
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
                CompanyHead = "";
            }

            try
            {
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("Don't exist any information for this report");
                }

                DataDynamics.ActiveReports.ActiveReport3 rpt = new AutoGuardCertificatePaidEffective(txtBegDate.Text, TxtEndDate.Text, "Certificate Paid & Effectivity", ChkSummary.Checked, CompanyHead);

                //rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;

                rpt.DataSource = dt;
                rpt.DataMember = "Report";

                rpt.Document.Printer.PrinterName = "";

                rpt.Run(false);

                Session.Add("Report", rpt);
                Session.Add("FromPage", "PoliciesReports.aspx");
                Response.Redirect("ActiveXViewer.aspx", false);
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
                return;
            }
        }

        private void MonthlyPolicyProduction()
        {
            try
            {
                EPolicy2.Reports.AutoGuardServicesContractReport appAutoreport = new EPolicy2.Reports.AutoGuardServicesContractReport();
                DataTable dt = null;
                DataDynamics.ActiveReports.ActiveReport3 rpt = null;

                string dateType = ddlDateType.SelectedItem.Value.Trim();
                string mHead = "";
                string CompanyHead = "";

                if (ddlDateType.SelectedItem.Value.Trim() == "E")
                    mHead = "Premium written & Cancellations - Entry Date Criteria";
                else
                    mHead = "Premium written & Cancellations - Effective Date Criteria";


                dt = appAutoreport.MonthlyPolicyProduction(ddlMonths.SelectedItem.Value.Trim(), ddlYears.SelectedItem.Value.Trim(), ddlPolicyClass.SelectedItem.Value.Trim());
                //rpt = new EPolicy2.Reports.AutoGuard.MonthlyPolicyProduction(ddlPolicyClass.SelectedItem.Text.Trim() + " - Month: " + ddlMonths.SelectedItem.Text.Trim(), ddlYears.SelectedItem.Value.Trim(), mHead, ChkSummary.Checked, CompanyHead);

                if (dt.Rows.Count == 0)
                {
                    throw new Exception("Don't exist any information for this report");
                }

                //DataDynamics.ActiveReports.ActiveReport rpt = new AutoGuardPremiumWritten(txtBegDate.Text,TxtEndDate.Text,"Premium written & Cancellations",ChkSummary.Checked);

                //rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;

                rpt.DataSource = dt;
                rpt.DataMember = "Report";

                rpt.Document.Printer.PrinterName = "";

                rpt.Run(false);

                Session.Add("Report", rpt);
                Session.Add("FromPage", "PoliciesReports.aspx");
                Response.Redirect("ActiveXViewer.aspx", false);
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
                return;
            }
        }

        private void AnualPolicyProduction()
        {
            try
            {
                EPolicy2.Reports.AutoGuardServicesContractReport appAutoreport = new EPolicy2.Reports.AutoGuardServicesContractReport();
                DataTable dt = null;
                DataDynamics.ActiveReports.ActiveReport3 rpt = null;

                string dateType = ddlDateType.SelectedItem.Value.Trim();
                string mHead = "";
                string CompanyHead = "";

                if (ddlDateType.SelectedItem.Value.Trim() == "E")
                    mHead = "Premium written & Cancellations - Entry Date Criteria";
                else
                    mHead = "Premium written & Cancellations - Effective Date Criteria";


                dt = appAutoreport.AnualPolicyProduction(ddlYears.SelectedItem.Value.Trim(), ddlPolicyClass.SelectedItem.Value.Trim());
                //rpt = new EPolicy2.Reports.AutoGuard.AnualPolicyProduction(ddlPolicyClass.SelectedItem.Text.Trim() + " - Year: " + ddlYears.SelectedItem.Value.Trim(), ddlYears.SelectedItem.Value.Trim(), mHead, ChkSummary.Checked, CompanyHead);

                if (dt.Rows.Count == 0)
                {
                    throw new Exception("Don't exist any information for this report");
                }

                //DataDynamics.ActiveReports.ActiveReport rpt = new AutoGuardPremiumWritten(txtBegDate.Text,TxtEndDate.Text,"Premium written & Cancellations",ChkSummary.Checked);

                //rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;

                rpt.DataSource = dt;
                rpt.DataMember = "Report";

                rpt.Document.Printer.PrinterName = "";

                rpt.Run(false);

                Session.Add("Report", rpt);
                Session.Add("FromPage", "PoliciesReports.aspx");
                Response.Redirect("ActiveXViewer.aspx", false);
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
                return;
            }
        }

        private void History(int taskControlID, int userID)
        {
            Audit.History history = new Audit.History();

            history.Actions = "PRINT";
            history.KeyID = taskControlID.ToString();
            history.Subject = "AUTOGUARDSERVICESCONTRACT";
            history.BuildNotesForHistory("TaskControlID.", "", taskControlID.ToString(), 7);  //7 = mode NOTICEOFCANC
            history.UsersID = userID;
            history.GetSaveHistory();
        }

        protected void rblAutoGuardReports_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            EnableControl();
        }

        private void EnableControl()
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
            rblFilterBy.SelectedIndex = 0;
            ChkSummary.Text = "Summary";
            switch (rblAutoGuardReports.SelectedItem.Value)
            {
                case "0":			//AutoGuardPremiumWrittenReport
                    lblOutstandingStatus.Visible = false;
                    rblOutstandingStatus.Visible = false;
                    lblPolicyClass.Visible = false;
                    ddlPolicyClass.Visible = false;
                    rblPremWrittenOrder.SelectedIndex = 0;
                    lblMonth.Visible = false;
                    ddlMonths.Visible = false;
                    lblYear.Visible = false;
                    ddlYears.Visible = false;
                    txtBegDate.Visible = true;
                    TxtEndDate.Visible = true;
                    Label1.Visible = true;
                    Label2.Visible = true;
                    lblInsuranceCompany.Visible = false;
                    ddlInsuranceCompany.Visible = false;
                    LblDataType.Visible = true;
                    ddlDateType.Visible = true;
                    lblCompanyDealer.Visible = false;
                    lblCompanyDealer.Text = "CompanyDealer";
                    ddlDealer.Visible = false;
                    ddlBank.Visible = false;
                    ChkSummary.Visible = true;
                    ChkActualPolicies.Visible = false;
                    btnPrint.Visible = true;
                    BtnPrint2.Visible = false;
                    btnDownLoad.Visible = false;
                    rblFilterBy.Visible = true;
                    lblFilterBy.Visible = true;
                    ddlAgent.Visible = true;
                    lblAgent.Visible = true;
                    ddlAgent0.Visible = false;
                    lblAgent0.Visible = false;
                    ddlVSCPending.Visible = false;
                    lblPending.Visible = false;
                    ddlPolicyType.Visible = true;
                    lblPolicyType.Visible = true;

                    lblOutstanding.Visible = false;
                    txtOutstandingDate.Visible = false;
                    rblPremWrittenOrder.Visible = false;

                    lblGroup.Visible = true;
                    ddlGroup.Visible = true;

                    //lblFollowUpCancellation.Visible = false;
                    txtFollowUpCancellation.Visible = false;

                    lblPaidEntry.Visible = false;

                    chkPartialPayments.Visible = false;

                    //rblCertificatePaidOrder.Visible = false;
                    break;

                case "1":			//AutoGuardCertificateOustandingReport
                    lblOutstandingStatus.Visible = true;
                    rblOutstandingStatus.Visible = true;
                    lblPolicyClass.Visible = false;
                    ddlPolicyClass.Visible = false;
                    lblMonth.Visible = false;
                    ddlMonths.Visible = false;
                    lblYear.Visible = false;
                    ddlYears.Visible = false;
                    txtBegDate.Visible = false;
                    TxtEndDate.Visible = false;
                    Label1.Visible = false;
                    Label2.Visible = false;
                    lblInsuranceCompany.Visible = false;
                    ddlInsuranceCompany.Visible = false;
                    LblDataType.Visible = false;
                    ddlDateType.Visible = false;
                    lblCompanyDealer.Visible = false;
                    lblCompanyDealer.Text = "CompanyDealer";
                    ddlDealer.Visible = false;
                    ddlBank.Visible = false;
                    ChkSummary.Visible = true;
                    ChkActualPolicies.Visible = false;
                    btnPrint.Visible = true;
                    BtnPrint2.Visible = false;
                    btnDownLoad.Visible = false;
                    rblFilterBy.Visible = true;
                    lblFilterBy.Visible = true;
                    ddlAgent.Visible = true;
                    lblAgent.Visible = true;
                    ddlAgent0.Visible = false;
                    lblAgent0.Visible = false;
                    ddlVSCPending.Visible = false;
                    lblPending.Visible = false;
                    ddlPolicyType.Visible = false;
                    lblPolicyType.Visible = false;

                    lblOutstanding.Visible = true;
                    txtOutstandingDate.Visible = true;
                    lblOutstanding.Text = "Policies Outstanding as of:";
                    rblPremWrittenOrder.Visible = false;

                    //lblFollowUpCancellation.Visible = false;
                    txtFollowUpCancellation.Visible = false;

                    lblGroup.Visible = false;
                    ddlGroup.Visible = false;

                    lblPaidEntry.Visible = false;

                    chkPartialPayments.Visible = true;

                    //rblCertificatePaidOrder.Visible = false;
                    break;

                case "2":			//AutoGuardCertificatePaid
                    lblOutstandingStatus.Visible = false;
                    rblOutstandingStatus.Visible = false;
                    lblPolicyClass.Visible = false;
                    ddlPolicyClass.Visible = false;
                    lblMonth.Visible = false;
                    ddlMonths.Visible = false;
                    lblYear.Visible = false;
                    ddlYears.Visible = false;
                    txtBegDate.Visible = true;
                    TxtEndDate.Visible = true;
                    Label1.Visible = true;
                    Label2.Visible = true;
                    lblInsuranceCompany.Visible = false;
                    ddlInsuranceCompany.Visible = false;
                    LblDataType.Visible = false;
                    ddlDateType.Visible = false;
                    lblCompanyDealer.Visible = false;
                    lblCompanyDealer.Text = "CompanyDealer";
                    ddlDealer.Visible = false;
                    ChkSummary.Visible = true;
                    ChkActualPolicies.Visible = false;
                    btnPrint.Visible = true;
                    BtnPrint2.Visible = false;
                    btnDownLoad.Visible = false;
                    rblFilterBy.Visible = false;
                    lblFilterBy.Visible = false;
                    ddlAgent.Visible = false;
                    lblAgent.Visible = false;
                    ddlAgent0.Visible = false ;
                    lblAgent0.Visible = false;
                    ddlVSCPending.Visible = false;
                    lblPending.Visible = false;
                    ddlPolicyType.Visible = false;
                    lblPolicyType.Visible = false;

                    lblOutstanding.Visible = false;
                    txtOutstandingDate.Visible = false;
                    rblPremWrittenOrder.Visible = false;

                    //lblFollowUpCancellation.Visible = false;
                    txtFollowUpCancellation.Visible = false;

                    lblGroup.Visible = false;
                    ddlGroup.Visible = false;

                    lblPaidEntry.Visible = false;

                    chkPartialPayments.Visible = false;
                    //rblCertificatePaidOrder.Visible = true;
                    break;

                case "3":			//Renewal
                    lblOutstandingStatus.Visible = false;
                    rblOutstandingStatus.Visible = false;
                    lblPolicyClass.Visible = false;
                    ddlPolicyClass.Visible = false;
                    lblMonth.Visible = false;
                    ddlMonths.Visible = false;
                    lblYear.Visible = false;
                    ddlYears.Visible = false;
                    txtBegDate.Visible = true;
                    TxtEndDate.Visible = true;
                    Label1.Visible = true;
                    Label2.Visible = true;
                    lblInsuranceCompany.Visible = false;
                    ddlInsuranceCompany.Visible = false;
                    LblDataType.Visible = false;
                    ddlDateType.Visible = false;
                    lblCompanyDealer.Visible = false;
                    ddlDealer.Visible = false;
                    ChkSummary.Visible = false;
                    ChkActualPolicies.Visible = true;
                    btnPrint.Visible = true;
                    BtnPrint2.Visible = false;
                    btnDownLoad.Visible = false;
                    rblFilterBy.Visible = true;
                    lblFilterBy.Visible = true;
                    ddlAgent.Visible = true;
                    lblAgent.Visible = true;
                    ddlAgent0.Visible = false;
                    lblAgent0.Visible = false;
                    ddlVSCPending.Visible = false;
                    lblPending.Visible = false;
                    ddlPolicyType.Visible = true;
                    lblPolicyType.Visible = true;

                    lblOutstanding.Visible = false;
                    txtOutstandingDate.Visible = false;
                    rblPremWrittenOrder.Visible = false;

                    //lblFollowUpCancellation.Visible = false;
                    txtFollowUpCancellation.Visible = false;

                    lblGroup.Visible = false;
                    ddlGroup.Visible = false;

                    lblPaidEntry.Visible = false;

                    chkPartialPayments.Visible = false;
                    //rblCertificatePaidOrder.Visible = false;
                    break;

                case "4":			//Anual Production 
                    lblOutstandingStatus.Visible = false;
                    rblOutstandingStatus.Visible = false;
                    lblPolicyClass.Visible = false;
                    ddlPolicyClass.Visible = false;
                    lblYear.Visible = false;
                    ddlYears.Visible = false;
                    lblMonth.Visible = false;
                    ddlMonths.Visible = false;

                    txtBegDate.Visible = true;
                    TxtEndDate.Visible = true;
                    Label1.Visible = true;
                    Label2.Visible = true;
                    lblInsuranceCompany.Visible = false;
                    ddlInsuranceCompany.Visible = false;
                    LblDataType.Visible = false;
                    ddlDateType.Visible = false;
                    lblCompanyDealer.Visible = false;
                    ddlDealer.Visible = false;
                    ChkSummary.Visible = false;
                    ChkActualPolicies.Visible = false;
                    btnPrint.Visible = true;
                    BtnPrint2.Visible = false;
                    btnDownLoad.Visible = false;
                    rblFilterBy.Visible = false;
                    lblFilterBy.Visible = false;
                    ddlAgent.Visible = false;
                    lblAgent.Visible = false;
                    ddlAgent0.Visible = false;
                    lblAgent0.Visible = false;
                    ddlVSCPending.Visible = false;
                    lblPending.Visible = false;
                    ddlPolicyType.Visible = true;
                    lblPolicyType.Visible = true;

                    lblOutstanding.Visible = false;
                    txtOutstandingDate.Visible = false;
                    rblPremWrittenOrder.Visible = false;

                    txtFollowUpCancellation.Visible = true;
                    lblPaidEntry.Visible = true;
                    lblPaidEntry.Text = "Canc. Date";

                    chkPartialPayments.Visible = false;
                    //rblCertificatePaidOrder.Visible = false;

                    lblGroup.Visible = false;
                    ddlGroup.Visible = false;

                    break;

                case "5":			//PremiumEarned
                    lblOutstandingStatus.Visible = false;
                    rblOutstandingStatus.Visible = false;
                    lblMonth.Visible = false;
                    ddlMonths.Visible = false;
                    txtBegDate.Visible = false;
                    TxtEndDate.Visible = true;
                    Label1.Visible = false;
                    Label2.Visible = true;
                    lblInsuranceCompany.Visible = false;
                    ddlInsuranceCompany.Visible = false;
                    LblDataType.Visible = false;
                    ddlDateType.Visible = false;
                    lblCompanyDealer.Visible = false;
                    ddlDealer.Visible = false;
                    ChkSummary.Visible = false;
                    ChkActualPolicies.Visible = false;
                    btnPrint.Visible = false;
                    BtnPrint2.Visible = true;
                    btnDownLoad.Visible = true;
                    rblFilterBy.Visible = false;
                    lblFilterBy.Visible = false;
                    ddlAgent.Visible = false;
                    lblAgent.Visible = false;
                    ddlAgent0.Visible = false;
                    lblAgent0.Visible = false;
                    ddlVSCPending.Visible = false;
                    lblPending.Visible = false;
                    ddlPolicyType.Visible = true;
                    lblPolicyType.Visible = true;

                    lblYear.Visible = false;
                    ddlYears.Visible = false;
                    lblPolicyClass.Visible = false;
                    ddlPolicyClass.Visible = false;
                    lblOutstanding.Visible = false;
                    txtOutstandingDate.Visible = false;
                    txtFollowUpCancellation.Visible = false;
                    lblPaidEntry.Visible = false;
                    lblPaidEntry.Text = "Canc. Date";
                    ddlAgent.Visible = false;
                    lblAgent.Visible = false;

                    chkPartialPayments.Visible = false;

                    lblGroup.Visible = false;
                    ddlGroup.Visible = false;

                    break;

                case "6":			//VSCBreakdown
                    lblOutstandingStatus.Visible = false;
                    rblOutstandingStatus.Visible = false;
                    lblPolicyClass.Visible = false;
                    ddlPolicyClass.Visible = false;
                    rblPremWrittenOrder.SelectedIndex = 0;
                    lblMonth.Visible = false;
                    ddlMonths.Visible = false;
                    lblYear.Visible = false;
                    ddlYears.Visible = false;
                    txtBegDate.Visible = true;
                    TxtEndDate.Visible = true;
                    Label1.Visible = true;
                    Label2.Visible = true;
                    lblInsuranceCompany.Visible = false;
                    ddlInsuranceCompany.Visible = false;
                    LblDataType.Visible = true;
                    ddlDateType.Visible = true;
                    lblCompanyDealer.Visible = true;
                    lblCompanyDealer.Text = "CompanyDealer";
                    ddlDealer.Visible = true;
                    ddlBank.Visible = false;
                    ChkSummary.Visible = true;
                    ChkActualPolicies.Visible = false;
                    btnPrint.Visible = true;
                    BtnPrint2.Visible = false;
                    btnDownLoad.Visible = false;
                    lblOutstanding.Visible = false;
                    txtOutstandingDate.Visible = false;
                    txtFollowUpCancellation.Visible = false;
                    lblPaidEntry.Visible = false;
                    ddlAgent.Visible = false;
                    lblAgent.Visible = false;
                    ddlAgent0.Visible = false;
                    lblAgent0.Visible = false;
                    ddlVSCPending.Visible = false;
                    lblPending.Visible = false;
                    ddlPolicyType.Visible = false;
                    lblPolicyType.Visible = false;
                    rblPremWrittenOrder.Visible = false;

                    lblGroup.Visible = false;
                    ddlGroup.Visible = false;

                    chkPartialPayments.Visible = false;
                    break;

                case "7":			//QuotesList
                    lblOutstandingStatus.Visible = false;
                    rblOutstandingStatus.Visible = false;
                    lblPolicyClass.Visible = false;
                    ddlPolicyClass.Visible = false;
                    rblPremWrittenOrder.SelectedIndex = 0;
                    lblMonth.Visible = false;
                    ddlMonths.Visible = false;
                    lblYear.Visible = false;
                    ddlYears.Visible = false;
                    txtBegDate.Visible = true;
                    TxtEndDate.Visible = true;
                    Label1.Visible = true;
                    Label2.Visible = true;
                    lblInsuranceCompany.Visible = false;
                    ddlInsuranceCompany.Visible = false;
                    LblDataType.Visible = false;
                    ddlDateType.Visible = false;
                    lblCompanyDealer.Visible = false;
                    lblCompanyDealer.Text = "CompanyDealer";
                    ddlDealer.Visible = false;
                    ddlBank.Visible = false;
                    ChkSummary.Visible = true;
                    ChkActualPolicies.Visible = false;
                    btnPrint.Visible = true;
                    BtnPrint2.Visible = false;
                    btnDownLoad.Visible = false;
                    lblOutstanding.Visible = false;
                    txtOutstandingDate.Visible = false;
                    txtFollowUpCancellation.Visible = false;
                    lblPaidEntry.Visible = false;
                    ddlAgent.Visible = false;
                    lblAgent.Visible = false;
                    ddlAgent0.Visible = false;
                    lblAgent0.Visible = false;
                    ddlVSCPending.Visible = false;
                    lblPending.Visible = false;
                    ddlPolicyType.Visible = false;
                    lblPolicyType.Visible = false;
                    rblPremWrittenOrder.Visible = false;
                    rblFilterBy.Visible = false;
                    lblFilterBy.Visible = false;

                    lblGroup.Visible = false;
                    ddlGroup.Visible = false;

                    chkPartialPayments.Visible = false;
                    break;

                case "8":			//Endorsements Report
                    lblOutstandingStatus.Visible = false;
                    rblOutstandingStatus.Visible = false;
                    lblMonth.Visible = false;
                    ddlMonths.Visible = false;
                    txtBegDate.Visible = true;
                    TxtEndDate.Visible = true;
                    Label1.Visible = true;
                    Label2.Visible = true;
                    lblInsuranceCompany.Visible = false;
                    ddlInsuranceCompany.Visible = false;
                    LblDataType.Visible = false;
                    ddlDateType.Visible = false;
                    lblCompanyDealer.Visible = false;
                    ddlDealer.Visible = false;
                    ChkSummary.Visible = false;
                    ChkActualPolicies.Visible = false;
                    btnPrint.Visible = true;
                    BtnPrint2.Visible = false;
                    btnDownLoad.Visible = false;

                    lblYear.Visible = false;
                    ddlYears.Visible = false;
                    lblPolicyClass.Visible = false;
                    ddlPolicyClass.Visible = false;
                    lblOutstanding.Visible = false;
                    txtOutstandingDate.Visible = false;
                    txtFollowUpCancellation.Visible = false;
                    lblPaidEntry.Visible = false;
                    ddlAgent.Visible = false;
                    lblAgent.Visible = false;
                    ddlVSCPending.Visible = false;
                    lblPending.Visible = false;
                    ddlPolicyType.Visible = false;
                    lblPolicyType.Visible = false;
                    rblPremWrittenOrder.Visible = false;

                    lblGroup.Visible = false;
                    ddlGroup.Visible = false;

                    LblTotalCases.Visible = false;
                    lblFilterBy.Visible = false;
                    rblFilterBy.Visible = false;

                    chkPartialPayments.Visible = false;
                    break;

                case "9":			//VSCSunGuard
                    lblOutstandingStatus.Visible = false;
                    rblOutstandingStatus.Visible = false;
                    lblMonth.Visible = false;
                    ddlMonths.Visible = false;
                    txtBegDate.Visible = true;
                    TxtEndDate.Visible = true;
                    Label1.Visible = true;
                    Label2.Visible = true;
                    lblInsuranceCompany.Visible = false;
                    ddlInsuranceCompany.Visible = false;
                    LblDataType.Visible = false;
                    ddlDateType.Visible = false;
                    lblCompanyDealer.Visible = false;
                    ddlDealer.Visible = false;
                    ChkSummary.Visible = false;
                    ChkActualPolicies.Visible = false;
                    btnPrint.Visible = false;
                    BtnPrint2.Visible = false;
                    btnDownLoad.Visible = true;

                    lblYear.Visible = false;
                    ddlYears.Visible = false;
                    lblPolicyClass.Visible = false;
                    ddlPolicyClass.Visible = false;
                    lblOutstanding.Visible = false;
                    txtOutstandingDate.Visible = false;
                    txtFollowUpCancellation.Visible = false;
                    lblPaidEntry.Visible = false;
                    ddlAgent.Visible = false;
                    lblAgent.Visible = false;
                    ddlVSCPending.Visible = false;
                    lblPending.Visible = false;
                    ddlPolicyType.Visible = false;
                    lblPolicyType.Visible = false;
                    rblPremWrittenOrder.Visible = false;

                    lblGroup.Visible = false;
                    ddlGroup.Visible = false;

                    chkPartialPayments.Visible = false;
                    break;

                case "10":			//PremiumCancellation
                    lblOutstandingStatus.Visible = false;
                    rblOutstandingStatus.Visible = false;
                    lblPolicyClass.Visible = true;
                    ddlPolicyClass.Visible = true;
                    rblPremWrittenOrder.SelectedIndex = 0;
                    lblMonth.Visible = false;
                    ddlMonths.Visible = false;
                    lblYear.Visible = false;
                    ddlYears.Visible = false;
                    txtBegDate.Visible = true;
                    TxtEndDate.Visible = true;
                    Label1.Visible = true;
                    Label2.Visible = true;
                    lblInsuranceCompany.Visible = false;
                    ddlInsuranceCompany.Visible = false;
                    LblDataType.Visible = true;
                    ddlDateType.Visible = true;
                    lblCompanyDealer.Visible = true;
                    lblCompanyDealer.Text = "CompanyDealer";
                    ddlDealer.Visible = true;
                    ddlBank.Visible = false;
                    ChkSummary.Visible = true;
                    ChkActualPolicies.Visible = false;
                    btnPrint.Visible = true;
                    BtnPrint2.Visible = false;
                    btnDownLoad.Visible = false;
                    ddlAgent.Visible = true;
                    lblAgent.Visible = true;
                    ddlVSCPending.Visible = false;
                    lblPending.Visible = false;
                    ddlPolicyType.Visible = false;
                    lblPolicyType.Visible = false;

                    lblGroup.Visible = false;
                    ddlGroup.Visible = false;

                    lblOutstanding.Visible = false;
                    txtOutstandingDate.Visible = false;
                    rblPremWrittenOrder.Visible = false;

                    //lblFollowUpCancellation.Visible = false;
                    txtFollowUpCancellation.Visible = false;

                    lblPaidEntry.Visible = false;

                    //rblCertificatePaidOrder.Visible = false;

                    chkPartialPayments.Visible = false;
                    break;

                case "11":			//ETCHBreakdown
                    lblOutstandingStatus.Visible = false;
                    rblOutstandingStatus.Visible = false;
                    lblPolicyClass.Visible = false;
                    ddlPolicyClass.Visible = false;
                    rblPremWrittenOrder.SelectedIndex = 0;
                    lblMonth.Visible = false;
                    ddlMonths.Visible = false;
                    lblYear.Visible = false;
                    ddlYears.Visible = false;
                    txtBegDate.Visible = true;
                    TxtEndDate.Visible = true;
                    Label1.Visible = true;
                    Label2.Visible = true;
                    lblInsuranceCompany.Visible = false;
                    ddlInsuranceCompany.Visible = false;
                    LblDataType.Visible = true;
                    ddlDateType.Visible = true;
                    lblCompanyDealer.Visible = true;
                    lblCompanyDealer.Text = "CompanyDealer";
                    ddlDealer.Visible = true;
                    ddlBank.Visible = false;
                    ChkSummary.Visible = true;
                    ChkActualPolicies.Visible = false;
                    btnPrint.Visible = true;
                    BtnPrint2.Visible = false;
                    btnDownLoad.Visible = false;
                    lblOutstanding.Visible = false;
                    txtOutstandingDate.Visible = false;
                    txtFollowUpCancellation.Visible = false;
                    lblPaidEntry.Visible = false;
                    ddlAgent.Visible = false;
                    lblAgent.Visible = false;
                    ddlVSCPending.Visible = false;
                    lblPending.Visible = false;
                    ddlPolicyType.Visible = false;
                    lblPolicyType.Visible = false;
                    rblPremWrittenOrder.Visible = false;
                    chkPartialPayments.Visible = false;

                    lblGroup.Visible = false;
                    ddlGroup.Visible = false;
                    break;

                case "12":
                    lblOutstandingStatus.Visible = false;
                    rblOutstandingStatus.Visible = false;
                    lblPolicyClass.Visible = false;
                    ddlPolicyClass.Visible = false;
                    rblPremWrittenOrder.SelectedIndex = 0;
                    lblMonth.Visible = false;
                    ddlMonths.Visible = false;
                    lblYear.Visible = false;
                    ddlYears.Visible = false;
                    txtBegDate.Visible = false;
                    TxtEndDate.Visible = false;
                    Label1.Visible = false;
                    Label2.Visible = false;
                    lblInsuranceCompany.Visible = false;
                    ddlInsuranceCompany.Visible = false;
                    LblDataType.Visible = false;
                    ddlDateType.Visible = false;
                    lblCompanyDealer.Visible = false;
                    lblCompanyDealer.Text = "CompanyDealer";
                    ddlDealer.Visible = false;
                    ddlBank.Visible = false;
                    ChkSummary.Visible = false;
                    ChkActualPolicies.Visible = false;
                    btnPrint.Visible = true;
                    BtnPrint2.Visible = false;
                    btnDownLoad.Visible = false;
                    lblOutstanding.Visible = false;
                    txtOutstandingDate.Visible = false;
                    txtFollowUpCancellation.Visible = false;
                    lblPaidEntry.Visible = false;
                    ddlAgent.Visible = false;
                    lblAgent.Visible = false;
                    ddlAgent0.Visible = false;
                    lblAgent0.Visible = false;
                    ddlVSCPending.Visible = false;
                    lblPending.Visible = false;
                    ddlPolicyType.Visible = false;
                    lblPolicyType.Visible = false;
                    rblPremWrittenOrder.Visible = false;
                    rblFilterBy.Visible = false;
                    lblFilterBy.Visible = false;
                    LblTotalCases.Visible = false;
                    lblGroup.Visible = false;
                    ddlGroup.Visible = false;

                    chkPartialPayments.Visible = false;
                    break;

                case "13":
                    lblOutstandingStatus.Visible = false;
                    rblOutstandingStatus.Visible = false;
                    lblMonth.Visible = false;
                    ddlMonths.Visible = false;
                    txtBegDate.Visible = true;
                    TxtEndDate.Visible = true;
                    Label1.Visible = true;
                    Label2.Visible = true;
                    lblInsuranceCompany.Visible = false;
                    ddlInsuranceCompany.Visible = false;
                    LblDataType.Visible = false;
                    ddlDateType.Visible = false;
                    lblCompanyDealer.Visible = false;
                    ddlDealer.Visible = false;
                    ChkSummary.Visible = false;
                    ChkActualPolicies.Visible = false;
                    btnPrint.Visible = true;
                    BtnPrint2.Visible = false;
                    btnDownLoad.Visible = false;

                    lblYear.Visible = false;
                    ddlYears.Visible = false;
                    lblPolicyClass.Visible = false;
                    ddlPolicyClass.Visible = false;
                    lblOutstanding.Visible = false;
                    txtOutstandingDate.Visible = false;
                    txtFollowUpCancellation.Visible = false;
                    lblPaidEntry.Visible = false;
                    ddlAgent.Visible = false;
                    lblAgent.Visible = false;
                    ddlVSCPending.Visible = false;
                    lblPending.Visible = false;
                    ddlPolicyType.Visible = false;
                    lblPolicyType.Visible = false;
                    rblPremWrittenOrder.Visible = false;

                    lblGroup.Visible = false;
                    ddlGroup.Visible = false;

                    LblTotalCases.Visible = false;
                    lblFilterBy.Visible = false;
                    rblFilterBy.Visible = false;

                    chkPartialPayments.Visible = false;
                    break;
            }

            if (!cp.IsInRole("DISABLERADIOBUTTONREPORTS") && !cp.IsInRole("ADMINISTRATOR"))
            {
                rblAutoGuardReports.Items[1].Enabled = false;
                rblAutoGuardReports.Items[2].Enabled = false;
                rblAutoGuardReports.Items[3].Enabled = false;
                rblAutoGuardReports.Items[4].Enabled = false;
                rblAutoGuardReports.Items[6].Enabled = false;
                rblAutoGuardReports.Items[7].Enabled = false;
                
            }
            else
            {
                rblAutoGuardReports.Items[1].Enabled = true;
                rblAutoGuardReports.Items[2].Enabled = true;
                rblAutoGuardReports.Items[3].Enabled = true;
                rblAutoGuardReports.Items[4].Enabled = true;
                rblAutoGuardReports.Items[6].Enabled = true;
                rblAutoGuardReports.Items[7].Enabled = true;
                
            }
            if (!cp.IsInRole("ACCOUNTING REPORTING"))
            {
                rblAutoGuardReports.Items[1].Enabled = true;
                rblAutoGuardReports.Items[2].Enabled = true;
                rblAutoGuardReports.Items[3].Enabled = true;
                rblAutoGuardReports.Items[4].Enabled = true;
                rblAutoGuardReports.Items[6].Enabled = true;
                rblAutoGuardReports.Items[7].Enabled = true;
            }

            
        }

        protected void rblPremWrittenOrder_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (rblPremWrittenOrder.SelectedItem.Value)
            {
                case "0":
                    ddlDealer.Visible = true;
                    ddlBank.Visible = false;
                    lblCompanyDealer.Text = "CompanyDealer";
                    lblInsuranceCompany.Visible = false;
                    ddlInsuranceCompany.Visible = false;
                    break;

                case "1":
                    ddlDealer.Visible = false;
                    ddlBank.Visible = true;
                    lblCompanyDealer.Text = "Bank";
                    lblInsuranceCompany.Visible = false;
                    ddlInsuranceCompany.Visible = false;
                    break;

                case "2":
                    ddlDealer.Visible = true;
                    ddlBank.Visible = false;
                    lblCompanyDealer.Text = "CompanyDealer";
                    lblInsuranceCompany.Visible = true;
                    ddlInsuranceCompany.Visible = true;
                    break;


            }
        }

        protected void rblCertificatePaidOrder_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            switch (rblCertificatePaidOrder.SelectedItem.Value)
            {
                case "0":
                    ddlDealer.Visible = true;
                    ddlBank.Visible = false;
                    lblCompanyDealer.Text = "CompanyDealer";
                    lblInsuranceCompany.Visible = true;
                    ddlInsuranceCompany.Visible = true;
                    break;


                case "1":
                    ddlDealer.Visible = true;
                    ddlBank.Visible = false;
                    lblCompanyDealer.Text = "CompanyDealer";
                    lblInsuranceCompany.Visible = false;
                    ddlInsuranceCompany.Visible = false;
                    break;


                case "2":
                    ddlDealer.Visible = true;
                    ddlBank.Visible = false;
                    lblCompanyDealer.Text = "CompanyDealer";
                    lblInsuranceCompany.Visible = true;
                    ddlInsuranceCompany.Visible = true;
                    break;
            }
        }

        protected void btnPrint_Click(object sender, System.EventArgs e)
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

            switch (rblAutoGuardReports.SelectedItem.Value)
            {
                case "0":
                    AutoGuardPremiumWritten();
                    break;

                case "1":
                    AutoGuardCertificateOutstanding();
                    break;

                case "2":
                    AutoGuardCertificatePaid();
                    break;

                case "3":
                    Renewal();
                    break;

                case "4":
                    PolicyPremiumEarned();  //FollowUpCancellation();
                    break;

                case "5":
                    //PrintVSCReport();
                    break;

                case "6":
                    //VSCTotalPriceBreakdown();
                    //CertificatePaidAndEffectivity();
                    break;

                case "7":
                    QuotesList();
                    break;

                case "8":
                    EndorsementsReport();
                    break;

                case "10":
                    //PremiumCancellation();
                    break;

                case "11":
                    //ETCHBreakdown();
                    break;

                case "12":
                    Financial_Notice_Method();
                   
                    break;
                case "13":
                    NoticeCancellationReport();
                    break;


            }
        }

        //--------------------------------------------------------------------------------------
        private void NoticeCancellationReport()
        {
            List<string> mergePaths = new List<string>();
            string ProcessedPath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"];
            EPolicy2.Reports.ExportFile expFile = new EPolicy2.Reports.ExportFile();
            string _FileName = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"];

            DataTable dt = GetNoticeCancellation(txtBegDate.Text.ToString(), TxtEndDate.Text.ToString());

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                mergePaths.Add(PrintAvisoCanc("AvisoCancelacion.rdlc", dt.Rows[i]));
            }

            string NameFile = "AvisosDeCancelacion" + dt.Rows[0]["TaskControlID"].ToString();
            EPolicy.CreatePDFBatch mergeFinal = new EPolicy.CreatePDFBatch();
            string FinalFile = "";

            FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, NameFile);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
        }
        private DataTable GetNoticeCancellation(string dateFrom, string dateTo)
        {
            DbRequestXmlCookRequestItem[] cookItems = new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("BegDate",
                SqlDbType.VarChar, 10, dateFrom.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndDate",
                SqlDbType.VarChar, 10, dateTo.ToString(),
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
            DataTable dt = exec.GetQuery("GetCancellationNoticeWhereClause", xmlDoc);

            return dt;
        }
        private string PrintAvisoCanc(string rdlcDoc, DataRow dr)
        {
            try
            {
                EPolicy.TaskControl.Policy taskControl = (EPolicy.TaskControl.Policy)Session["TaskControl"];
                ReportViewer viewer = new ReportViewer();
                string ProcessedPath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"];

                viewer.LocalReport.DataSources.Clear();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportPath = Server.MapPath("Reports/" + rdlcDoc);


                if (rdlcDoc == "AvisoCancelacion.rdlc")
                {
                    ReportParameter[] param = new ReportParameter[5];
                    param[0] = new ReportParameter("PolicyNo", dr["PolicyType"].ToString());
                    param[1] = new ReportParameter("EffectiveDate", DateTime.Parse(dr["EffectiveDate"].ToString()).ToShortDateString());
                    param[2] = new ReportParameter("CustomerName", dr["CustomerName"].ToString());
                    param[3] = new ReportParameter("CancellationDate", dr["CancellationEntryDate"].ToString());
                    param[4] = new ReportParameter("CertificateLocationDesc", dr["CertificateLocationDesc"].ToString().ToUpper());

                    viewer.LocalReport.SetParameters(param);
                    viewer.LocalReport.Refresh();
                }
                Warning[] warnings;
                string[] streamIds;
                string mimeType;
                string encoding = string.Empty;
                string extension;

                string _FileName = rdlcDoc + dr["NoticeIndex"].ToString() + ".pdf";

                if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                    File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    //fs.Close();
                }
                Session.Add("PDFPath", _FileName);
                return ProcessedPath + _FileName;

            }
            catch
            {
                return "";
            }
        }
        private void Financial_Notice_Method()
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
            Session.Add("dateTo", TxtEndDate.Text);
            Session.Add("userName", userName);
            Session.Add("agency", "financialcancellation");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('RDLCReport.aspx','Reports','addressbar=no,status=1,menubar=0,scrollbars=0,resizable=0,copyhistory=no,width=900,height=640');", true);
        }

        private int GetSeqNo()
        {
            //string file = @"Z:\VSCSequenceFile.txt";
            string file = @"C:\Inetpub\Optima Page\Optima\VSCSequenceFile.txt";
            //string file = @"C:\Inetpub\wwwroot\Optima\VSCSequenceFile.txt";
            StreamWriter sr2;
            string varYear = DateTime.Now.Year.ToString().Substring(2, 2);
            string varMonth = DateTime.Now.Month.ToString();
            string varDay = DateTime.Now.Day.ToString();
            string date = varYear + varMonth.PadLeft(2, '0') + varDay.PadLeft(2, '0');
            int seq = 1;

            if (File.Exists(file))
            {
                StreamReader sr = File.OpenText(file);
                string a = sr.ReadToEnd();
                sr.Close();

                if (a.Trim() != "")
                {
                    if (a.Substring(0, 6) == date)
                    {
                        seq = int.Parse(a.Substring(6, 1));

                        File.Delete(file);
                        sr2 = File.CreateText(file);
                        seq = seq + 1;
                        string mdata = date + seq.ToString();


                        sr2.WriteLine(mdata);
                        sr2.WriteLine();
                        sr2.Close();
                    }
                    else
                    {
                        File.Delete(file);
                        sr2 = File.CreateText(file);
                        string mdata = date + seq.ToString();


                        sr2.WriteLine(mdata);
                        sr2.WriteLine();
                        sr2.Close();
                    }
                }
                else
                {
                    File.Delete(file);
                    sr2 = File.CreateText(file);
                    string mdata = date + seq.ToString();

                    sr2.WriteLine(mdata);
                    sr2.WriteLine();
                    sr2.Close();
                }
            }
            else
            {
                sr2 = File.CreateText(file);
                string mdata = date + seq.ToString();

                sr2.WriteLine(mdata);
                sr2.WriteLine();
                sr2.Close();
            }

            return seq;
        }

        private void VSCSunGuard()
        {
            StreamWriter sr;
            DataTable dt = TaskControl.Policies.GetVSCSunGuardInterfase(1, txtBegDate.Text, TxtEndDate.Text);

            string varYear = DateTime.Now.Year.ToString().Substring(2, 2);
            string varMonth = DateTime.Now.Month.ToString();
            string varDay = DateTime.Now.Day.ToString();
            string file = varYear + varMonth.PadLeft(2, '0') + varDay.PadLeft(2, '0');
            file = file.Trim();
            file = file.PadRight(8, ' ');

            FileName = @"C:\Inetpub\Optima Page\Optima\VSC\VSCSunGuard" + file.Trim() + ".txt";
            //FileName = @"C:\Inetpub\wwwroot\Optima\VSC\VSCSunGuard" + file.Trim() + ".txt";

            sr = File.CreateText(FileName);

            if (dt.Rows.Count == 0)
            {
                throw new Exception("Don't exist any information for this file.");
            }

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                sr = SetDataTOSunGuard(dt, i, sr);
            }

            sr.Close();
            DownLoadFile();
        }

        private StreamWriter SetDataTOSunGuard(DataTable dt, int index, StreamWriter sr)
        {

            for (int a = 1; a <= 6; a++)
            {
                string rowString = "";
                string val = "";
                string var1 = "";
                string var2 = "";
                string var3 = "";
                string var4 = "";
                string var5 = "";
                string var6 = "";
                string var7 = "";
                string var8 = "";
                string var9 = "";
                string var10 = "";
                string var11 = "";
                string var12 = "";
                string var13 = "";
                string var14 = "";

                switch (a)
                {
                    case 1:     //A/R SERV CONTRACT
                        var1 = "1120-010";
                        val = dt.Rows[index]["Price"].ToString().Trim() + ".00";
                        var5 = val.PadLeft(9, ' ');
                        var6 = "D";
                        break;
                    case 2:     //LOSS FUND
                        var1 = "2010-000";
                        val = dt.Rows[index]["LossFund"].ToString().Trim() + ".00";
                        var5 = val.PadLeft(9, ' ');
                        var6 = "C";
                        break;
                    case 3:     //BANK FEE
                        var1 = "2040-010";
                        val = dt.Rows[index]["BankFee"].ToString() + ".00";
                        var5 = val.PadLeft(9, ' ');
                        var6 = "C";
                        break;
                    case 4:     //CANCELLATION RESERVE
                        var1 = "2040-020";
                        val = dt.Rows[index]["CanReserve"].ToString() + ".00";
                        var5 = val.PadLeft(9, ' ');
                        var6 = "C";
                        break;
                    case 5:     //SERV CONT FEE
                        var1 = "2040-000";
                        val = dt.Rows[index]["DealerProfit"].ToString() + ".00";
                        var5 = val.PadLeft(9, ' ');
                        var6 = "C";
                        break;
                    case 6:     //SERV CONT INCOME
                        var1 = "4100-000";
                        val = dt.Rows[index]["Income"].ToString() + ".00";
                        var5 = val.PadLeft(9, ' ');
                        var6 = "C";
                        break;
                }

                var2 = "CASH";
                var3 = TxtEndDate.Text.Substring(0, 2) + TxtEndDate.Text.Substring(3, 2) + TxtEndDate.Text.Substring(6, 4);
                var4 = "PRMWS";
                var7 = "PROD " + TxtEndDate.Text.Substring(6, 4) + TxtEndDate.Text.Substring(3, 2) + TxtEndDate.Text.Substring(0, 2) + " - " + txtBegDate.Text.Substring(6, 4) + txtBegDate.Text.Substring(3, 2) + "-" + txtBegDate.Text.Substring(0, 2);
                var8 = "WGE";
                var9 = TxtEndDate.Text.Substring(3, 2) + TxtEndDate.Text.Substring(6, 4);
                var10 = dt.Rows[index]["Bank"].ToString();
                var11 = dt.Rows[index]["CompanyDealer"].ToString();
                var12 = "010";
                var13 = TxtEndDate.Text.Substring(0, 2) + TxtEndDate.Text.Substring(3, 2) + TxtEndDate.Text.Substring(6, 4);
                var14 = "To record issuance of service contracts";

                rowString = var1 + var2 + var3 + var4 + var5 + var6 + var7 + var8 + var9 + var10 + var11 + var12 + var13 + var14;

                sr.WriteLine(rowString);
            }

            return sr;
        }

        private void EndorsementsReport()
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
            Session.Add("dateTo", TxtEndDate.Text);
            Session.Add("userName", userName);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('RDLCReport.aspx','Reports','addressbar=no,status=1,menubar=0,scrollbars=0,resizable=0,copyhistory=no,width=900,height=640');", true);


        }

        private void VSCSunGuardDeposit()
        {
            StreamWriter sr;
            DataTable dt = TaskControl.Policies.GetVSCSunGuardInterfase(1, txtBegDate.Text, TxtEndDate.Text);

            string varYear = DateTime.Now.Year.ToString().Substring(2, 2);
            string varMonth = DateTime.Now.Month.ToString();
            string varDay = DateTime.Now.Day.ToString();
            string file = varYear + varMonth.PadLeft(2, '0') + varDay.PadLeft(2, '0');
            file = file.Trim();
            file = file.PadRight(8, ' ');

            FileName = @"C:\Inetpub\Optima Page\Optima\VSC\VSCSunGuardDeposit" + file.Trim() + ".txt";
            //FileName = @"C:\Inetpub\wwwroot\Optima\VSC\VSCSunGuardDeposit" + file.Trim() + ".txt";

            sr = File.CreateText(FileName);

            if (dt.Rows.Count == 0)
            {
                throw new Exception("Don't exist any information for this file.");
            }

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                sr = SetDataTOSunGuardDeposit(dt, i, sr);
            }

            sr.Close();
            DownLoadFile();
        }

        private StreamWriter SetDataTOSunGuardDeposit(DataTable dt, int index, StreamWriter sr)
        {

            for (int a = 1; a <= 2; a++)
            {
                string rowString = "";
                string val = "";
                string var1 = "";
                string var2 = "";
                string var3 = "";
                string var4 = "";
                string var5 = "";
                string var6 = "";
                string var7 = "";
                string var8 = "";

                var1 = TxtEndDate.Text.Substring(0, 2) + TxtEndDate.Text.Substring(3, 2) + TxtEndDate.Text.Substring(6, 4);
                switch (a)
                {
                    case 1:     //CONCENTRATION DEPOSIT
                        var2 = "1050-602";
                        val = dt.Rows[index]["Price"].ToString().Trim() + ".00";
                        var3 = val.PadLeft(9, ' ');
                        var4 = "D";
                        var5 = "CONCENTRATION DEPOSIT";
                        var5 = var5.PadRight(25, ' ');
                        break;
                    case 2:     //A/R SERV CONTRACT
                        var2 = "1120-010";
                        val = dt.Rows[index]["Price"].ToString().Trim() + ".00";
                        var3 = val.PadLeft(9, ' ');
                        var4 = "C";
                        var5 = "A/R SERV CONTRACT";
                        var5 = var5.PadRight(25, ' ');
                        break;
                }

                var6 = dt.Rows[index]["Bank"].ToString();
                var7 = dt.Rows[index]["CompanyDealer"].ToString();
                var8 = "010";

                rowString = var1 + var2 + var3 + var4 + var5 + var6 + var7 + var8;

                sr.WriteLine(rowString);
            }

            return sr;
        }

        private void VCSProductionFile()
        {
            try
            {
                StreamWriter sr;

                DataTable dt = TaskControl.Policies.GetVSCProductionHeader(1, txtBegDate.Text, TxtEndDate.Text, true);
                DataTable dtCanc = TaskControl.Policies.GetVSCProductionHeader(1, txtBegDate.Text, TxtEndDate.Text, false);

                //DataTable dt = TaskControl.Policies.GetVSCProductionHeader(1, "5/1/2009", "8/13/2009", true);
                //DataTable dtCanc = TaskControl.Policies.GetVSCProductionHeader(1, "5/1/2009", "8/13/2009", false);

                string varYear = DateTime.Now.Year.ToString().Substring(2, 2);
                string varMonth = DateTime.Now.Month.ToString();
                string varDay = DateTime.Now.Day.ToString();
                string file = varYear + varMonth.PadLeft(2, '0') + varDay.PadLeft(2, '0');
                file = file.Trim();
                file = file.PadRight(8, ' ');

                int seq = GetSeqNo();
                FileName = @"C:\Inetpub\Optima Page\Optima\VSC\OP" + file.Trim() + seq.ToString() + ".txt";
                //FileName = @"C:\Inetpub\wwwroot\Optima\VSC\OP" + file.Trim() + seq.ToString() + ".txt";

                sr = File.CreateText(FileName);

                if (dt.Rows.Count == 0 || dt.Rows[0]["TotalNewPolicies"].ToString().Trim() == "")
                {
                    throw new Exception("Don't exist any information for this report.");
                }

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    string rowString = "";

                    //string var0 = "OPTIMA";
                    string var0 = "OPTPRM";
                    var0 = var0.Trim();
                    var0 = var0.PadRight(8, ' ');

                    string var1 = "H"; //1
                    var1 = var1.Trim();
                    var1 = var1.PadRight(1, ' ');

                    varYear = DateTime.Now.Year.ToString(); //8 (CCYYMMDD)
                    varMonth = DateTime.Now.Month.ToString();
                    varDay = DateTime.Now.Day.ToString();
                    string var2 = varYear + varMonth.PadLeft(2, '0') + varDay.PadLeft(2, '0');
                    var2 = var2.Trim();
                    var2 = var2.PadRight(8, ' ');


                    string varHour = DateTime.Now.Hour.ToString(); //8 (HHMMSS)
                    string varMinute = DateTime.Now.Minute.ToString();
                    string varSecond = DateTime.Now.Second.ToString();
                    string var3 = varHour + varMinute + varSecond;
                    var3 = var3.Trim();
                    var3 = var3.PadRight(6, ' ');

                    string var4 = dt.Rows[i]["SequenceID"].ToString().Trim(); //3
                    var4 = var4.Trim();
                    var4 = var4.PadLeft(3, '0');

                    string var5 = ""; //10
                    var5 = var5.Trim();
                    var5 = var5.PadRight(10, ' ');

                    int CancCount = 0;
                    if (dtCanc.Rows[i]["TotalCancPolicies"].ToString().Trim() != "")
                    {
                        CancCount = int.Parse(dtCanc.Rows[i]["TotalCancPolicies"].ToString());
                    }

                    int tot = int.Parse(dt.Rows[i]["TotalNewPolicies"].ToString()); //+ CancCount;
                    string var6 = tot.ToString().Trim(); //6
                    var6 = var6.Trim();
                    var6 = var6.PadLeft(6, '0');

                    string var7 = dt.Rows[i]["TotalNewPolicies"].ToString(); //5
                    var7 = var7.Trim();
                    var7 = var7.PadLeft(5, '0');

                    string var8 = "0";// CancCount.ToString(); //5
                    var8 = var8.Trim();
                    var8 = var8.PadLeft(5, '0');

                    string var9 = "0"; //5
                    var9 = var9.Trim();
                    var9 = var9.PadLeft(5, '0');

                    double amt = double.Parse(dt.Rows[i]["TotalClientCost"].ToString());
                    string var10 = "0000000";  // amt.ToString().Replace(".", "");
                    var10 = var10.Trim();
                    var10 = var10.PadLeft(7, '0');

                    amt = double.Parse(dt.Rows[i]["TotalCustomerCost"].ToString());
                    string var11 = "0000000";  // amt.ToString().Replace(".", "");
                    var11 = var11.Trim();
                    var11 = var11.PadLeft(7, '0');

                    string var12 = ""; //182
                    var12 = var12.Trim();
                    var12 = var12.PadLeft(182, ' ');

                    amt = double.Parse(dt.Rows[i]["TotalClientCost"].ToString());
                    string var13 = amt.ToString().Replace(".", "");
                    var13 = var13.Trim() + "00";
                    var13 = var13.PadLeft(9, '0');

                    amt = double.Parse(dt.Rows[i]["TotalCustomerCost"].ToString());
                    string var14 = amt.ToString().Replace(".", "");
                    var14 = var14.Trim() + "00";
                    var14 = var14.PadLeft(9, '0');

                    rowString = var0 + var1 + var2 + var3 + var4 + var5 + var6 + var7 + var8 + var9 + var10 + var11 + var12 + var13 + var14;  //+"\r\n";

                    sr.WriteLine(rowString);
                }

                dt = TaskControl.Policies.GetVSCProductionDetail(1, txtBegDate.Text, TxtEndDate.Text, true);
                //dt = TaskControl.Policies.GetVSCProductionDetail(1, "5/1/2009", "8/13/2009", true);
                //dtCanc = TaskControl.Policies.GetVSCProductionDetail(1, txtBegDate.Text, TxtEndDate.Text, false);
                sr = WriteProduction(dt, sr, true);
                sr = WriteProduction(dt, sr, false);

                //sr.WriteLine();
                sr.Close();

                //Actualiza el campo trams_fl de los casos transmitidos.
                TaskControl.Policies.GetVSCProductionUpdate(1, "01/01/2009", TxtEndDate.Text, true);

                if (Session["VSCProductionFile"] != null)
                    Session["VSCProductionFile"] = dt;
                else
                    Session.Add("VSCProductionFile", dt);

                DownLoadFile();
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
                return;
            }
        }


        private StreamWriter WriteProduction(DataTable dt, StreamWriter sr, bool IsPolicies)
        {
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                if (IsPolicies == true && dt.Rows[i]["PrmCount"].ToString().Trim() == "1")
                {
                    sr = WriteLineInStream(dt, sr, IsPolicies, i);
                }

                if (IsPolicies == false && dt.Rows[i]["CancCount"].ToString().Trim() == "1")
                {
                    //sr = WriteLineInStream(dt, sr, IsPolicies, i);
                }
            }
            return sr;
        }

        private StreamWriter WriteLineInStream(DataTable dt, StreamWriter sr, bool IsPolicies, int i)
        {
            string rowString = "";

            //string var1 = "OPTIMA";
            string var1 = "OPTPRM";
            var1 = var1.Trim();
            var1 = var1.PadRight(8, ' ');

            string var2;
            if (IsPolicies)
                var2 = "P"; //1
            else
                var2 = "C"; //1

            var2 = var2.Trim();
            var2 = var2.PadRight(1, ' ');

            LookupTables.CompanyDealer cd = new LookupTables.CompanyDealer();
            cd = cd.GetCompanyDealer(dt.Rows[i]["CompanyDealer"].ToString());
            string var3 = cd.VSCClientID;
            var3 = var3.Trim();
            var3 = var3.PadLeft(8, '0');

            string var4 = "C"; //1
            var4 = var4.Trim();

            string var5 = "";
            if (dt.Rows[0]["VehicleCode"] != System.DBNull.Value)
            {
                var5 = dt.Rows[i]["VehicleCode"].ToString();
            }
            var5 = var5.Trim();
            var5 = var5.PadRight(5, ' ');

            string var6 = dt.Rows[i]["PolicyNumber"].ToString();
            var6 = var6.Trim();
            var6 = var6.PadRight(8, ' ');

            string var7 = "PR0011007";
            var7 = var7.Trim();
            var7 = var7.PadRight(25, ' ');

            string var8 = "";

            switch (int.Parse(dt.Rows[i]["CoveragePlan"].ToString()))
            {
                case 1:     //POWER TRAIN - PT
                    var8 = "PT";
                    break;
                case 2:     //SILVER - SL
                    var8 = "SL";
                    break;
                case 3:     //GOLD - GD
                    var8 = "GD";
                    break;
                case 4:     //PLATINUM - PL
                    var8 = "PL";
                    break;
            }

            var8 = var8.Trim();
            var8 = var8.PadRight(6, ' ');

            string var9 = "WAR";
            var9 = var9.Trim();
            var9 = var9.PadRight(3, ' ');

            string var10 = dt.Rows[i]["Term"].ToString();
            var10 = var10.Trim();
            var10 = var10.PadLeft(3, '0');

            int miles = int.Parse(dt.Rows[i]["Miles"].ToString());
            miles = miles / 1000;
            string var11 = miles.ToString();
            var11 = var11.Trim();
            var11 = var11.PadLeft(3, '0');

            double amt = double.Parse(dt.Rows[i]["LossFund"].ToString());
            string var12 = amt.ToString().Replace(".", "");
            var12 = var12.Trim() + "00";
            var12 = var12.PadLeft(7, '0');

            string var13 = " ";
            var13 = var13.Trim();
            var13 = var13.PadLeft(1, ' ');

            string var14 = dt.Rows[i]["ZipCode"].ToString().Replace("-", "");
            var14 = var14.Trim();
            var14 = var14.PadLeft(13, ' ');

            string var15 = "";
            if (dt.Rows[0]["HomePhone"] != System.DBNull.Value)
            {
                var15 = dt.Rows[i]["HomePhone"].ToString().Substring(1, 3);
            }
            var15 = var15.Trim();
            var15 = var15.PadLeft(3, '0');

            string var16 = "";
            if (dt.Rows[0]["HomePhone"] != System.DBNull.Value)
            {
                var16 = dt.Rows[i]["HomePhone"].ToString().Substring(6, 8);
            }
            var16 = var16.Replace("-", "").Trim();
            var16 = var16.PadLeft(7, '0');

            string varYear = DateTime.Parse(dt.Rows[i]["EffectiveDate"].ToString()).Year.ToString(); //8 (CCYYMMDD)
            string varMonth = DateTime.Parse(dt.Rows[i]["EffectiveDate"].ToString()).Month.ToString();
            string varDay = DateTime.Parse(dt.Rows[i]["EffectiveDate"].ToString()).Day.ToString();
            string var17 = varYear + varMonth.PadLeft(2, '0') + varDay.PadLeft(2, '0');
            var17 = var17.Trim();
            var17 = var17.PadRight(8, '0');

            string var18 = "00000000";
            var18 = var18.Trim();
            var18 = var18.PadRight(8, '0');

            varYear = DateTime.Parse(dt.Rows[i]["EffectiveDate"].ToString()).Year.ToString(); //8 (CCYYMMDD)
            varMonth = DateTime.Parse(dt.Rows[i]["EffectiveDate"].ToString()).Month.ToString();
            varDay = DateTime.Parse(dt.Rows[i]["EffectiveDate"].ToString()).Day.ToString();
            string var19 = varYear + varMonth.PadLeft(2, '0') + varDay.PadLeft(2, '0');
            var19 = var19.Trim();
            var19 = var19.PadRight(8, '0');

            string var20 = dt.Rows[i]["Milleages"].ToString();
            var20 = var20.Trim();
            var20 = var20.PadLeft(6, '0');

            string var21 = dt.Rows[i]["VehicleYearDesc"].ToString();
            var21 = var21.Trim();
            var21 = var21.PadLeft(4, '0');

            string var22 = "";
            if ((double)dt.Rows[i]["Charge"] == 0)
            {
                var22 = "100";
                var22 = var22.Trim();
                var22 = var22.PadLeft(4, '0');
            }
            else
            {
                var22 = "0000";
                var22 = var22.Trim();
                var22 = var22.PadLeft(4, '0');
            }

            string var23 = "N";
            var23 = var23.Trim();

            amt = double.Parse(dt.Rows[i]["TotalPremium"].ToString());
            string var24 = amt.ToString().Replace(".", "");
            var24 = var24.Trim() + "00";
            var24 = var24.PadLeft(7, '0');

            string var25 = "000";
            var25 = var25.Trim();

            string var26 = "0000000";
            var26 = var26.Trim();

            string var27 = "00";
            var27 = var27.Trim();


            //CommercialUse
            string var28 = "N";
            //if ((bool)dt.Rows[i]["CommercialUse"] == true)
            //{
            //    var28 = "Y";
            //}
            //else
            //{
            //    var28 = "N";
            var28 = var28.Trim();
            //}

            string var29 = "N";
            var29 = var29.Trim();

            string var30 = "N";
            var30 = var30.Trim();

            string var31 = dt.Rows[i]["firstna"].ToString().Replace("Ñ", "N");
            var31 = var31.Trim();
            var31 = var31.PadRight(25, ' ');

            string var32 = dt.Rows[i]["Initial"].ToString().Replace("Ñ", "N");
            var32 = var32.Trim();
            var32 = var32.PadRight(1, ' ');

            string var33 = dt.Rows[i]["lastna1"].ToString().Replace("Ñ", "N");
            var33 = var33.Trim();
            var33 = var33.PadRight(25, ' ');

            string var34 = dt.Rows[i]["Adds1"].ToString().Replace("Ñ", "N");
            var34 = var34.Trim();
            var34 = var34.PadRight(30, ' ');

            string var35 = dt.Rows[i]["Adds2"].ToString().Replace("Ñ", "N");
            var35 = var35.Trim();
            var35 = var35.PadRight(30, ' ');

            string var36 = dt.Rows[i]["City"].ToString().Replace("Ñ", "N");
            var36 = var36.Trim();
            var36 = var36.PadRight(30, ' ');

            string var37 = dt.Rows[i]["Vin"].ToString().Replace("Ñ", "N");
            var37 = var37.Trim();
            var37 = var37.PadRight(17, ' ');

            string var38 = "USA";
            var38 = var38.Trim();
            var38 = var38.PadRight(3, ' ');

            string var39 = dt.Rows[i]["State"].ToString().Replace("Ñ", "N");
            var39 = var39.Trim();
            var39 = var39.PadRight(2, ' ');

            string var40 = dt.Rows[i]["VehicleClass"].ToString();
            var40 = var40.Trim();
            var40 = var40.PadLeft(3, ' ');

            string var41 = " ";
            var41 = var41.Trim();
            var41 = var41.PadLeft(1, ' ');

            string var42 = " ";
            var42 = var42.Trim();
            var42 = var42.PadLeft(1, ' ');

            string var43 = " ";
            var43 = var43.Trim();
            var43 = var43.PadLeft(1, ' ');

            string var44 = " ";
            var44 = var44.Trim();
            var44 = var44.PadLeft(1, ' ');

            string var45 = " ";
            var45 = var45.Trim();
            var45 = var45.PadLeft(1, ' ');

            string var46 = " ";
            var46 = var46.Trim();
            var46 = var46.PadLeft(1, ' ');

            string var47 = " ";
            var47 = var47.Trim();
            var47 = var47.PadLeft(1, ' ');

            string var48 = " ";
            var48 = var48.Trim();
            var48 = var48.PadLeft(1, ' ');

            string var49 = "000000000";
            var49 = var49.Trim();
            var49 = var49.PadLeft(9, '0');

            string var50 = "  ";
            var50 = var50.Trim();
            var50 = var50.PadLeft(2, ' ');

            string var51 = "  ";
            var51 = var51.Trim();
            var51 = var51.PadLeft(2, ' ');

            string var52 = "  ";
            var52 = var52.Trim();
            var52 = var52.PadLeft(2, ' ');

            string var53 = "  ";
            var53 = var53.Trim();
            var53 = var53.PadLeft(2, ' ');

            string var54 = "  ";
            var54 = var54.Trim();
            var54 = var54.PadLeft(2, ' ');

            string var55 = "PR";
            var55 = var55.Trim();
            var55 = var55.PadLeft(2, ' ');

            string var56 = "               ";
            var56 = var56.Trim();
            var56 = var56.PadLeft(15, ' ');

            string var57 = "0000000";
            var57 = var57.Trim();
            var57 = var57.PadLeft(7, '0');

            string var58 = "          ";
            var58 = var58.Trim();
            var58 = var58.PadLeft(10, ' ');

            string var59 = "00000000";
            var59 = var59.Trim();
            var59 = var59.PadLeft(8, '0');

            string var60 = "     ";
            var60 = var60.Trim();
            var60 = var60.PadLeft(5, ' ');

            string var61 = "000000";
            var61 = var61.Trim();
            var61 = var61.PadLeft(6, '0');

            string var62 = "000000000000";
            var62 = var62.Trim();
            var62 = var62.PadLeft(12, '0');

            string var63 = dt.Rows[i]["VehicleMakeDesc"].ToString().Trim().Replace("Ñ", "N");
            if (var63.Length > 20)
                var63 = var63.Trim().Substring(0, 20);

            var63 = var63.Trim();
            var63 = var63.PadRight(20, ' ');

            string var64 = dt.Rows[i]["VehicleModelDesc"].ToString().Trim().Replace("Ñ", "N");
            if (var64.Length > 20)
                var64 = var64.Trim().Substring(0, 20);

            var64 = var64.Trim();
            var64 = var64.PadRight(20, ' ');

            string var65 = "      ";
            var65 = var65.Trim();
            var65 = var65.PadLeft(6, ' ');

            string var66 = "        ";
            var66 = var66.Trim();
            var66 = var66.PadLeft(8, ' ');

            string var67 = "0000000";
            var67 = var67.Trim();
            var67 = var67.PadLeft(7, '0');

            string var68 = "000000000";
            var68 = var68.Trim();
            var68 = var68.PadLeft(9, '0');

            string var69 = "000000000";
            var69 = var69.Trim();
            var69 = var69.PadLeft(9, '0');

            string var70 = " ";    //Bank Name
            var70 = var70.Trim();
            var70 = var70.PadLeft(30, ' ');

            string var71 = " ";
            var71 = var71.Trim();
            var71 = var71.PadLeft(30, ' ');

            string var72 = " ";
            var72 = var72.Trim();
            var72 = var72.PadLeft(30, ' ');

            string var73 = " ";
            var73 = var73.Trim();
            var73 = var73.PadLeft(30, ' ');

            string var74 = "  ";
            var74 = var74.Trim();
            var74 = var74.PadLeft(2, ' ');

            string var75 = "0000000000000";
            var75 = var75.Trim();
            var75 = var75.PadLeft(13, '0');

            string var76 = "000";
            var76 = var76.Trim();
            var76 = var76.PadLeft(3, '0');

            string var77 = "0000000";
            var77 = var77.Trim();
            var77 = var77.PadLeft(7, '0');

            string var78 = " ";
            var78 = var78.Trim();
            var78 = var78.PadLeft(15, ' ');

            string var79 = " ";
            var79 = var79.Trim();
            var79 = var79.PadLeft(20, ' ');

            string var80 = "00000000";
            var80 = var80.Trim();
            var80 = var80.PadLeft(8, '0');

            string var81 = "000000000";
            var81 = var81.Trim();
            var81 = var81.PadLeft(9, '0');

            string var82 = " ";
            var82 = var82.Trim();
            var82 = var82.PadLeft(6, ' ');

            string var83 = "00000000000";
            var83 = var83.Trim();
            var83 = var83.PadLeft(11, '0');

            string var84 = "00000000000";
            var84 = var84.Trim();
            var84 = var84.PadLeft(11, '0');

            string var85 = "000";
            var85 = var85.Trim();
            var85 = var85.PadLeft(3, '0');

            string var86 = "00000000";
            var86 = var86.Trim();
            var86 = var86.PadLeft(8, '0');

            string var87 = "0000";
            var87 = var87.Trim();
            var87 = var87.PadLeft(4, '0');

            string var88 = "00000000000";
            var88 = var88.Trim();
            var88 = var88.PadLeft(11, '0');

            string var89 = "00000000000";
            var89 = var89.Trim();
            var89 = var89.PadLeft(11, '0');

            string var90 = "00000000";
            var90 = var90.Trim();
            var90 = var90.PadLeft(8, '0');

            string var91 = "00000000000";
            var91 = var91.Trim();
            var91 = var91.PadLeft(11, '0');

            string var92 = "00000000000";
            var92 = var92.Trim();
            var92 = var92.PadLeft(11, '0');

            string var93 = " ";
            var93 = var93.Trim();
            var93 = var93.PadLeft(5, ' ');

            string var94 = " ";
            var94 = var94.Trim();
            var94 = var94.PadLeft(1, ' ');

            string var95 = " ";
            var95 = var95.Trim();
            var95 = var95.PadLeft(30, ' ');

            string var96 = " ";
            var96 = var96.Trim();
            var96 = var96.PadLeft(30, ' ');

            rowString = var1 + var2 + var3 + var4 + var5 + var6 + var7 + var8 + var9 + var10 + var11 + var12
                + var13 + var14 + var15 + var16 + var17 + var18 + var19 + var20 + var21 + var22 + var23
                + var24 + var25 + var26 + var27 + var28 + var29 + var30 + var31 + var32 + var33 + var34
                + var35 + var36 + var37 + var38 + var39 + var40 + var41 + var42 + var43 + var44 + var45
                + var46 + var47 + var48 + var49 + var50 + var51 + var52 + var53 + var54 + var55 + var56
                + var57 + var58 + var59 + var60 + var61 + var62 + var63 + var64 + var65 + var66 + var67
                + var68 + var69 + var70 + var71 + var72 + var73 + var74 + var75 + var76 + var77 + var78
                + var79 + var80 + var81 + var82 + var83 + var84 + var85 + var86 + var87 + var88 + var89
                + var90 + var91 + var92 + var93 + var94 + var95 + var96;
            sr.WriteLine(rowString);

            return sr;
        }

        private void DownLoadFile()
        {
            string FileNameOf = FileName;
            FileInfo myFile = new FileInfo(FileNameOf);

            Response.ClearHeaders();
            Response.Expires = 0;
            Response.Buffer = true;
            Response.Clear();
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + myFile.Name.Replace(".resources", ""));
            Response.AppendHeader("Content-Length", myFile.Length.ToString());
            Response.ContentType = "Text/TXT"; //= "application/octet-stream";

            Response.Flush();
            Response.WriteFile(myFile.FullName);
            Response.Flush();

            Response.Clear();
            Response.End();
        }

        private void PrintVSCReport()
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = 0;
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

            EPolicy2.Reports.AutoGuardServicesContractReport appAutoreport = new EPolicy2.Reports.AutoGuardServicesContractReport();
            DataTable dt = (DataTable)Session["VSCProductionFile"];
            DataDynamics.ActiveReports.ActiveReport3 rpt = null;

            //string dateType = "E"; //EntryDate
            string mHead = "";
            string CompanyHead = "";

            mHead = "Premium written & Cancellations - Entry Date Criteria";

            //dt = appAutoreport.AutoGuardPremiumWritten(txtBegDate.Text, TxtEndDate.Text, "", dateType, "1", userID);

            if (dt.Rows.Count != 0)
            {
                CompanyHead = dt.Rows[0]["InsuranceCompanyDesc"].ToString().Trim();
            }

            rpt = new EPolicy2.Reports.AutoGuard.AutoGuardPremiumWritten(txtBegDate.Text, TxtEndDate.Text, mHead, ChkSummary.Checked, CompanyHead);

            rpt.DataSource = dt;
            rpt.DataMember = "Report";

            rpt.Document.Printer.PrinterName = "";

            rpt.Run(false);

            Session.Add("Report", rpt);
            Session.Add("FromPage", "PoliciesReports.aspx");
            Response.Redirect("ActiveXViewer.aspx", true);
        }

        private void QuotesList()
        {
            try
            {
                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = 0;
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                DataTable dt = null;
                DataDynamics.ActiveReports.ActiveReport3 rpt = null;

                string dateType = ddlDateType.SelectedItem.Value.Trim();
                string mHead = "";
                string CompanyHead = "";

                if (ddlDateType.SelectedItem.Value.Trim() == "E")
                    mHead = "Quote List";
                else
                    mHead = "Quote List";

                dt = QuotesListDB(txtBegDate.Text, TxtEndDate.Text);

                CompanyHead = "PUERTO RICO MEDICAL DEFENSE INSURANCE COMPANY";

                rpt = new EPolicy2.Reports.PRMdic.QuoteList(txtBegDate.Text, TxtEndDate.Text, mHead, ChkSummary.Checked, CompanyHead);

                if (dt.Rows.Count == 0)
                {
                    throw new Exception("Don't exist any information for this report");
                }

                rpt.DataSource = dt;
                rpt.DataMember = "Report";

                rpt.Document.Printer.PrinterName = "";

                rpt.Run(false);

                Session.Add("Report", rpt);
                Session.Add("FromPage", "PoliciesReports.aspx");
                Response.Redirect("ActiveXViewer.aspx", false);
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
                return;
            }
        }

        protected void btnDownLoad_Click(object sender, EventArgs e)
        {
            try
            {
                FieldVerify();

                switch (rblAutoGuardReports.SelectedItem.Value)
                {
                    case "5":
                        btnPrint.Visible = true;
                        VCSProductionFile();
                        break;

                    case "8":
                        btnPrint.Visible = false;
                        VSCSunGuard();
                        break;

                    case "9":
                        btnPrint.Visible = false;
                        VSCSunGuardDeposit();
                        break;
                }

            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
                return;
            }
        }
        protected void BtnPrint2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["VSCProductionFile"] == null)
                {
                    throw new Exception("Please download the VSC Production File first.");
                }

                //FieldVerify();
                PrintVSCReport();
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
                return;
            }
        }

        private DataTable QuotesListDB(string BegDate, string EndDate)
        {
            DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("BegDate",
            SqlDbType.VarChar, 10, BegDate.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndDate",
            SqlDbType.VarChar, 10, EndDate.ToString(),
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
            DataTable dt = null;
            try
            {
                dt = exec.GetQuery("GetQuotesList", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }

        private void CreateVSCExcellFile(DataTable dt)
        {
            StreamWriter sr;

            //@"C:\Inetpub\Optima Page\Optima\VSC\ImagingDataFile\IM" +
            FileName = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"].ToString()+"PE"+            
            DateTime.Now.Month.ToString().Trim() +
            DateTime.Now.Day.ToString().Trim() +
            DateTime.Now.Year.ToString().Trim() + ".csv";

            sr = File.CreateText(FileName);
            string[] array2 = new string[43];
            array2 = SetHeader(array2);

            sr.WriteLine(array2[0].ToString() + array2[1].ToString() + array2[2].ToString() + array2[3].ToString() + array2[4].ToString() +
            array2[5].ToString() + array2[6].ToString() + array2[7].ToString() + array2[8].ToString() + array2[9].ToString() +
            array2[10].ToString() + array2[11].ToString() + array2[12].ToString() + array2[13].ToString() + array2[14].ToString() +
            array2[15].ToString() + array2[16].ToString() + array2[17].ToString());

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                if (double.Parse(dt.Rows[i]["TotalPremium"].ToString()) != 0.0)
                {
                    array2[0] = dt.Rows[i]["TaskControlID"].ToString() + ",";
                    array2[1] = dt.Rows[i]["PolicyType"].ToString().Replace(',', ' ') + ",";
                    array2[2] = dt.Rows[i]["PolicyNo"].ToString().Replace(',', ' ') + ",";
                    array2[3] = dt.Rows[i]["Certificate"].ToString() + ",";
                    array2[4] = dt.Rows[i]["Sufijo"].ToString().Replace(',', ' ') + ',';
                    array2[5] = dt.Rows[i]["Anniversary"].ToString().Replace(',', ' ') + ',';
                    array2[6] = dt.Rows[i]["CustomerName"].ToString().Replace(',', ' ') + ',';
                    array2[7] = ((DateTime)dt.Rows[i]["EntryDate"]).ToShortDateString() + ",";
                    array2[8] = ((DateTime)dt.Rows[i]["EffectiveDate"]).ToShortDateString() + ",";
                    array2[9] = ((DateTime)dt.Rows[i]["ExpirationDate"]).ToShortDateString() + ",";
                    array2[10] = ((dt.Rows[i]["CancellationDate"] != System.DBNull.Value) ? ((DateTime)dt.Rows[i]["CancellationDate"]).ToShortDateString() : "") + ",";
                    array2[11] = ((dt.Rows[i]["CancellationAmount"] != System.DBNull.Value) ? (((double)dt.Rows[i]["CancellationAmount"]).ToString()) : "0") + ",";
                    array2[12] = dt.Rows[i]["TotalPremium"].ToString() +",";
                    array2[13] = dt.Rows[i]["mcancDate"].ToString() + ",";
                    array2[14] = dt.Rows[i]["Prm_Earn"].ToString() + ",";
                    array2[15] = dt.Rows[i]["MRB"].ToString() + ",";
                    array2[16] = dt.Rows[i]["mdaysPolicy"].ToString() + ",";
                    array2[17] = dt.Rows[i]["mdaysRebate"].ToString();

                    sr.WriteLine(array2[0].ToString() + array2[1].ToString() + array2[2].ToString() + array2[3].ToString() + array2[4].ToString() +
                    array2[5].ToString() + array2[6].ToString() + array2[7].ToString() + array2[8].ToString() + array2[9].ToString() +
                    array2[10].ToString() + array2[11].ToString() + array2[12].ToString() + array2[13].ToString() + array2[14].ToString() +
                    array2[15].ToString() + array2[16].ToString() + array2[17].ToString());
                }
            }
            sr.Close();
            DownLoadFile();
        }

        private string[] SetHeader(string[] array2)
        {
            array2[0] = "TaskControlID,";
            array2[1] = "PolicyType,";
            array2[2] = "PolicyNo,";
            array2[3] = "Certificate,";
            array2[4] = "Suffix,";
            array2[5] = "Anniversary,";
            array2[6] = "CustomerName,";
            array2[7] = "EntryDate,";
            array2[8] = "EffectiveDate,";
            array2[9] = "ExpirationDate,";
            array2[10] = "CancellationDate,";
            array2[11] = "CancellationAmount,";
            array2[12] = "TotalPremium,"; 
            array2[13] = "mcancDate,";
            array2[14] = "Prm_Earn,";
            array2[15] = "MRB,";
            array2[16] = "mdaysPolicy,";
            array2[17] = "mdaysRebate,";

            return array2;
        }
        protected void rblFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblFilterBy.SelectedItem.Value == "A")
            {
                ddlAgent.Visible = true;
                lblAgent.Visible = true;
                ddlAgent0.Visible = false;
                lblAgent0.Visible = false;
            }
            else
            {
                ddlAgent.Visible = false;
                lblAgent.Visible = false;
                lblAgent0.Visible = true;
                ddlAgent0.Visible = true;
            }
        }
        protected void txtOutstandingDate_TextChanged(object sender, EventArgs e)
        {

        }
}

}
