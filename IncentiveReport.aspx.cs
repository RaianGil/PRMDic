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
	/// Summary description for IncentiveReport.
	/// </summary>
	public partial class IncentiveReport : System.Web.UI.Page
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
				if(!cp.IsInRole("INCENTIVEREPORT") && !cp.IsInRole("ADMINISTRATOR"))
				{
					Response.Redirect("HomePage.aspx?001");
				}
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
			
			// Control LeftMenu = new Control();
			// LeftMenu = LoadControl(@"LeftReportMenu.ascx");
			// ((Baldrich.BaldrichWeb.Components.MenuEventControl)LeftMenu).Height = "534px";
			// phTopBanner1.Controls.Add(LeftMenu);


			//Load DownDropList
			DataTable dtPolicyClass		= LookupTables.LookupTables.GetTable("PolicyClass");
			DataTable dtSupplier		= LookupTables.LookupTables.GetTable("Supplier");

			//PolicyClass
			ddlPolicyClass.DataSource = dtPolicyClass;
			ddlPolicyClass.DataTextField = "PolicyClassDesc";
			ddlPolicyClass.DataValueField = "PolicyClassID";
			ddlPolicyClass.DataBind();
			ddlPolicyClass.SelectedIndex = -1;
			ddlPolicyClass.Items.Insert(0,"");

			//Supplier
			ddlSupplier.DataSource = dtSupplier;
			ddlSupplier.DataTextField = "SupplierDesc";
			ddlSupplier.DataValueField = "SupplierID";
			ddlSupplier.DataBind();
			ddlSupplier.SelectedIndex = -1;
			ddlSupplier.Items.Insert(0,"");
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

			switch(rblProspectsReports.SelectedItem.Value)       
			{         
				case "0":   
					IncentiveAgent();
					break;
			}
		}

		private void FieldVerify()
		{
			string errorMessage = String.Empty;
			bool found = false;

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

			//throw the exception.
			if (errorMessage != String.Empty)
			{
				throw new Exception(errorMessage);
			}	
		}

		public void IncentiveAgent()
		{
			EPolicy2.Reports.AutoGuardServicesContractReport appAutoreport = new EPolicy2.Reports.AutoGuardServicesContractReport();
			DataTable dt = appAutoreport.IncentiveReportBySupplier(txtBegDate.Text,TxtEndDate.Text,ddlSupplier.SelectedItem.Value,ddlDateType.SelectedItem.Value,ddlPolicyClass.SelectedItem.Value);

            string CompanyHead = "";
            if (ddlPolicyClass.SelectedItem.Value.Trim() != "")
            {
                if (ddlPolicyClass.SelectedItem.Value == "1")
                {
                    CompanyHead = "PREMIER WARRANTY SERVICES";
                }
                else
                {
                    CompanyHead = "OPTIMA INSURANCE COMPANY";
                }
            }
            else
            {
                CompanyHead = "";
            }

            DataDynamics.ActiveReports.ActiveReport3 rpt = new PremiumWrittenBySupplies(txtBegDate.Text, TxtEndDate.Text, "Incentive Statement by Supplier", false, CompanyHead);
			
			//rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;

			rpt.DataSource = dt;
			rpt.DataMember = "Report";

            rpt.Document.Printer.PrinterName = ""; 

			rpt.Run(false);

			Session.Add("Report",rpt);
			Session.Add("FromPage","IncentiveReport.aspx");
			Response.Redirect("ActiveXViewer.aspx",false);
		}

	}
}
