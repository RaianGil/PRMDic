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
using System.Web.Security;

using EPolicy.Login;

namespace EPolicy
{
	/// <summary>
	/// Summary description for ChangePassword.
	/// </summary>
	public partial class ChangePassword : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
//			Login.Login cp = HttpContext.Current.User as Login.Login;
//			if (cp == null)
//			{
//				Response.Redirect("Default.aspx?001");
//			}
//			else
//			{
//				if(!cp.IsInRole("CHANGEPASSWORD") && !cp.IsInRole("ADMINISTRATOR"))
//				{
//					Response.Redirect("Default.aspx?001");
//				}
//			}
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
			this.Placeholder1.Controls.Add(Banner);

			/*//Setup Left-side Banner
			Control LeftMenu = new Control();
			LeftMenu = LoadControl(@"LeftMenu.ascx");
			this.phTopBanner1.Controls.Add(LeftMenu);*/
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		protected void BtnSave_Click(object sender, System.EventArgs e)
		{
			Login.Login login = new Login.Login();

			try
			{
				Validate();
			
				if(IsValid)
				{
					string encrypt = FormsAuthentication.HashPasswordForStoringInConfigFile(TxtPassword.Text.Trim(),"SHA1");
					string newPasswordText = TxtPassword.Text;
					TxtPassword.Text = "";

					if(login.GetAuthenticatedUser(TxtUserName.Text,encrypt))
					{
						string encryptNewPassword     = FormsAuthentication.HashPasswordForStoringInConfigFile(TxtNewPassword.Text.Trim(),"SHA1");
						string encryptConfirmPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(TxtConfirmPassword.Text.Trim(),"SHA1");

						login.SavePasword(encryptNewPassword,encryptConfirmPassword,encrypt,newPasswordText);
					}

					TxtUserName.Text = "";
					TxtPassword.Text = "";
					TxtNewPassword.Text = "";
					TxtConfirmPassword.Text = "";

					this.litPopUp.Text = Utilities.MakeLiteralPopUpString("User information saved successfully.");
					this.litPopUp.Visible = true;
				}
			}
			catch (Exception exp)
			{
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
				this.litPopUp.Visible = true;
			}
		}

		protected void BtnExit_Click(object sender, System.EventArgs e)
		{
			Session.Clear();
			Response.Redirect("HomePage.aspx");
		}

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
