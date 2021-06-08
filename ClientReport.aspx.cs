using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServerControls = System.Web.UI.WebControls; 
using System.Web.UI.HtmlControls;
using EPolicy2.Reports;
using System.Text;

namespace EPolicy
{
	/// <summary>
	/// Summary description for ClientReport.
	/// </summary>
	public partial class ClientReport : System.Web.UI.Page
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
				if(!cp.IsInRole("CLIENTREPORT") && !cp.IsInRole("ADMINISTRATOR"))
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
			
			/*Control LeftMenu = new Control();
			LeftMenu = LoadControl(@"LeftReportMenu.ascx");
			//((Baldrich.BaldrichWeb.Components.MenuEventControl)LeftMenu).Height = "534px";
			phTopBanner1.Controls.Add(LeftMenu);*/
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		protected void rblReportList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (rblReportList.SelectedItem.Value == "2")
			{
				Label2.Visible = false;
				Label4.Visible = false;
				Label5.Visible = false;
				ddlCustType.Visible = false;
				txtBegDate.Visible  = false;
				TxtEndDate.Visible  = false;
							
			}
			else
			{
				Label2.Visible = true;
				Label4.Visible = true;
				Label5.Visible = true;
				ddlCustType.Visible = true;
				txtBegDate.Visible  = true;
				TxtEndDate.Visible  = true;	
				
			}

		}

		private void btnPrint_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				//FieldVerify();
			}
			catch (Exception exp)
			{
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
				this.litPopUp.Visible = true;
				return;
			}

			bool IsBusiness = false;

			if (ddlCustType.SelectedItem.Value == "B")
			{
				IsBusiness = true;
			}
			else
			{
				IsBusiness = false;
			}
			
			switch(rblReportList.SelectedItem.Value)       
			{         
				case "0":   
					ClienttWithActivePolices(IsBusiness);
					break;

				case "1":   
					ClienttWithoutPolices(IsBusiness);
					break;  
			}
		}

		private void ClienttWithActivePolices(bool IsBusiness)
		{

		}

		private void ClienttWithoutPolices(bool IsBusiness)
		{

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
				errorMessage = "The Ending Date must be great than beginning date .";
				found = true;
			}

			//throw the exception.
			if (errorMessage != String.Empty)
			{
				throw new Exception(errorMessage);
			}	
		}

		protected void Button2_Click(object sender, System.EventArgs e)
		{
			try
			{
				//FieldVerify();
			}
			catch (Exception exp)
			{
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
				this.litPopUp.Visible = true;
				return;
			}

			bool IsBusiness = false;

			if (ddlCustType.SelectedItem.Value == "B")
			{
				IsBusiness = true;
			}
			else
			{
				IsBusiness = false;
			}
			
			switch(rblReportList.SelectedItem.Value)       
			{         
				case "0":   
					ClienttWithActivePolices(IsBusiness);
					break;

				case "1":   
					ClienttWithoutPolices(IsBusiness);
					break;   
			}
		}

		protected void BtnExit_Click(object sender, System.EventArgs e)
		{
			Session.Clear();
			Response.Redirect("MainMenu.aspx");
		}
	}
}
