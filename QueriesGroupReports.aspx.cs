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

namespace EPolicy
{
	/// <summary>
	/// Summary description for QueriesGroupReports.
	/// </summary>
	public partial class QueriesGroupReports : System.Web.UI.Page
	{
	
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
				if(!cp.IsInRole("QUERIESGROUPREPORTS") && !cp.IsInRole("ADMINISTRATOR"))
				{
					Response.Redirect("Default.aspx?001");
				}
			}

			if(!IsPostBack)
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
			DataTable dtPolicyClass		 =    LookupTables.LookupTables.GetTable("PolicyClass");
			
			//Policy Class
			ddlPolicyClass.DataSource = dtPolicyClass;
			ddlPolicyClass.DataTextField = "PolicyClassDesc";
			ddlPolicyClass.DataValueField = "PolicyClassID";
			ddlPolicyClass.DataBind();
			ddlPolicyClass.SelectedIndex = -1;
			ddlPolicyClass.Items.Insert(0,"");
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

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

			switch(rblAutoGuardReports.SelectedItem.Value)       
			{         
				case "0":   
					AutoGuardPremiumWritten();
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

			switch(rblAutoGuardReports.SelectedItem.Value)       
			{         
				case "0":   
					AutoGuardPremiumWritten();
					break; 
			}
		}

		private void AutoGuardPremiumWritten()
		{
            //try
            //{
            //    Login.Login cp = HttpContext.Current.User as Login.Login;
            //    int userID = 0;
            //    userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

            //    EPolicy2.Reports.AutoGuardServicesContractReport appAutoreport = new EPolicy2.Reports.AutoGuardServicesContractReport();
            //    DataTable dt = null;
            //    DataDynamics.ActiveReports.ActiveReport3 rpt = null;

            //    string dateType = ddlDateType.SelectedItem.Value.Trim();
            //    string mHead = "";
            //    string CompanyHead = "";

            //    if (ddlDateType.SelectedItem.Value.Trim() == "E")
            //        mHead = "Premium written & Cancellations - Entry Date Criteria";
            //    else
            //        mHead = "Premium written & Cancellations - Effective Date Criteria";

            //    dt = appAutoreport.AutoGuardPremiumWrittenToDealer(txtBegDate.Text, TxtEndDate.Text, "", dateType, ddlPolicyClass.SelectedItem.Value.Trim(), userID);

            //    if (ddlPolicyClass.SelectedItem.Value.Trim() != "")
            //    {
            //        if (dt.Rows.Count != 0)
            //        {
            //            CompanyHead = dt.Rows[0]["InsuranceCompanyDesc"].ToString().Trim();
            //        }
            //    }
            //    else
            //    {
            //        CompanyHead = "";
            //    }

            //    rpt = new EPolicy2.Reports.AutoGuard.VSCProductionDealer(txtBegDate.Text, TxtEndDate.Text, mHead, ChkSummary.Checked, CompanyHead);


            //    if (dt.Rows.Count == 0)
            //    {
            //        throw new Exception("Don't exist any information for this report");
            //    }

            //    DataDynamics.ActiveReports.ActiveReport rpt = new AutoGuardPremiumWritten(txtBegDate.Text, TxtEndDate.Text, "Premium written & Cancellations", ChkSummary.Checked);

            //    rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;

            //    rpt.DataSource = dt;
            //    rpt.DataMember = "Report";

            //    rpt.Document.Printer.PrinterName = "";

            //    rpt.Run(false);

            //    Session.Add("Report", rpt);
            //    Session.Add("FromPage", "QueriesGroupReports.aspx");
            //    Response.Redirect("ActiveXViewer.aspx", false);
            //}
            //catch (Exception exp)
            //{
            //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
            //    this.litPopUp.Visible = true;
            //    return;
            //}
		}

		private void EnableControl()
		{		
			switch(rblAutoGuardReports.SelectedItem.Value)     
			{    
				case "0":			//AutoGuardPremiumWrittenReport
					rblPremWrittenOrder.SelectedIndex = 0;
					txtBegDate.Visible         = true;
					TxtEndDate.Visible         = true;
					Label1.Visible		       = true;
					Label2.Visible		       = true;
					LblDataType.Visible		   = true;
					ddlDateType.Visible		   = true;
					// btnCalendar01.Visible        = true;
					// btnCalendar21.Visible       = true;
					ChkSummary.Visible		   = true;
					btnPrint.Visible           = true;
					//					BtnDownload.Visible		   = false;

					lblOutstanding.Visible     = false;
					txtOutstandingDate.Visible = false;
					// btnCalendar31.Visible       = false;
					break;  
			}
		}

		protected void BtnExit_Click(object sender, System.EventArgs e)
		{
			Session.Clear();
			Response.Redirect("MainMenu.aspx",false);		
		}

		private void FieldVerify()
		{
			string errorMessage = String.Empty;
			bool found = false;

			if (this.rblAutoGuardReports.SelectedItem.Value == "0" || this.rblAutoGuardReports.SelectedItem.Value == "2")
			{
				if (this.txtBegDate.Text == "" &&  this.TxtEndDate.Text != "" &&
					found == false)
				{
					errorMessage = "Please enter the beginning date.";
					found = true;
				}
				if (this.txtBegDate.Text != "" &&  this.TxtEndDate.Text == "" &&
					found == false)
				{
					errorMessage = "Please enter the ending date.";
					found = true;
				}
				else if (this.txtBegDate.Text == "" &&  this.TxtEndDate.Text == "" && 
					found == false)
				{
					errorMessage = "Please enter the beginning date and ending date.";
					found = true;
				}
				else if ((this.txtBegDate.Text != "" && this.TxtEndDate.Text != "" &&
					DateTime.Parse(this.txtBegDate.Text) > DateTime.Parse(this.TxtEndDate.Text)) && found == false)
				{
					errorMessage = "The Ending Date must be great than beginning date.";
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
	}
}