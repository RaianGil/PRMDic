using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;
using System.Text;
//using System.Windows.Forms;
using EPolicy;

namespace EPolicy
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public partial class FollowUp : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			this.litPopUp.Visible = false;

			if (!IsPostBack)
			{	
				//Login.Login cp = HttpContext.Current.User as Login.Login;
				//TxtMailFrom.Text = cp.Identity.Name.Split("|".ToCharArray())[0].ToString().Trim();

				if (Session["FileNameEmail"] != null)
				{
                    TxtMailFrom.Enabled = false;
					TxtAttachment.Text = ((string) Session["FileNameEmail"]).Substring(45).ToLower(); //47
					TxtAttachment.Enabled = false;
                    TxtAttachment.Visible = false;
                    LblAttachment.Visible = false;
				}
				else
				{
                    TxtMailFrom.Enabled = false;
					TxtAttachment.Enabled = false;
					TxtAttachment.Visible = false;
					LblAttachment.Visible = false;
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
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		//private const string FILE_NAME = @"c:\inetpub\wwwroot\SAMS\BankFile.txt";
        private const string FILE_NAME = @"C:\\Webs\\Prmdic.net\exportfiles\\";

		//this.ddlCollision.Attributes.Add("onchange", "SetCompCollValue()");	

		private void SendEmail(string filename, string mailfrom)
		{	
			string msg = "";
			string mailToList = "";
			string[] listtemp = TxtMailTo.Text.Trim().Split(";".ToCharArray());
			string[] listmail  = new string[listtemp.Length];
				
			try
			{
				for (int i=0; i < listtemp.Length; i++)
				{
					string mailtempo = listtemp[i].ToString().Trim();
					if(this.isEmail(mailtempo.Trim()))
					{
						listmail[i] = mailtempo.Trim();
						if(mailToList.Trim() != "")
							mailToList = mailToList.Trim() + ";\r\n"+mailtempo.Trim();
						else
							mailToList = mailtempo.Trim();
					}
					else
					{
						throw new Exception("Por favor entre un correo electrónico válido ("+listtemp[i].ToString().Trim()+").");
					}
				}

				if(filename != "") 
				{
					FileList.Items.Add(filename); 
				}
				
				Mail SM = new Mail();
				SM.MailTo = TxtMailTo.Text.Trim();			     
				//SM.MailToCollection = listmail;
				SM.MailFrom    = TxtMailFrom.Text.Trim();
				SM.MailSubject = TxtMailSubject.Text.Trim(); 
				SM.MailAttach = FileList;
				SM.MailBody = this.TxtBody.Text.Trim()+ "\r\n"+"\r\n"+
					"Para poder visualizar este documento debes de tener instalado el acrobat reader,"+"\r\n"+
					"si no lo tienes instalado lo puedes bajar desde el internet haciendo click a la siguiente dirección."+"\r\n"+
                    "http://get.adobe.com/reader/" + "\r\n" + "\r\n";
				//SM.SendMailbyCDO();

				msg = SM.SendMail();
			
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString(msg); //("Sent e-mail successfully.");
				this.litPopUp.Visible = true;
			}
			catch (Exception exp)
			{
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString(msg+ " " + exp.Message);
				this.litPopUp.Visible = true;
				return;
			}
		}

		private bool isEmail(string inputEmail)
		{
			//inputEmail  = NulltoString(inputEmail);
			string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
			System.Text.RegularExpressions.Regex re = 
				new System.Text.RegularExpressions.Regex (strRegex);
			if (re.IsMatch(inputEmail.Trim()))
				return (true);
			else
				return (false);
		}

		private void btnClose_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Session.Remove("FileNameEmail");
			string js = "<script language=javascript> window.opener.location.href = window.opener.location.href; window.close(); </script>";
			Response.Write(js);
		}

	
		private string DecodeEmail(string _FullName)
		{
			string email= "";

			DataTable dt = LookupTables.LookupTables.GetTable("AddressBook");

			if (dt.Rows.Count != 0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					if(_FullName.ToUpper() == dt.Rows[i]["AddressBookDesc"].ToString().Trim().ToUpper())
					{
						email = dt.Rows[i]["Email"].ToString().Trim();
					}
				}

				if (email == "")
					email = _FullName;
			}
			return email;
		}

		protected void btnEnviar_Click(object sender, System.EventArgs e)
		{
			if (TxtMailTo.Text.Trim() != "")
			{
				if (TxtMailFrom.Text.Trim() != "")
				{
					string mailfrom = TxtMailFrom.Text.Trim(); //this.DecodeEmail(TxtMailFrom.Text.Trim());

					if(this.isEmail(TxtMailFrom.Text.Trim()))
					{
						string mailFilename = (string) Session["FileNameEmail"];
						SendEmail(mailFilename, mailfrom);
					}
					else
					{
						this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Por favor entre un correo electrónico válido ("+TxtMailFrom.Text.Trim()+").");
						this.litPopUp.Visible = true;
					}
				}
				else
				{
					this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Por favor entre un correo electrónico válido en el campo Desde.");
					this.litPopUp.Visible = true;
				}
			}
			else
			{
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Por favor entre un correo electrónico válido en el campo Para.");
				this.litPopUp.Visible = true;
			}
		}

		protected void btnSalir_Click(object sender, System.EventArgs e)
		{
			Session.Remove("FileNameEmail");
			string js = "<script language=javascript> window.opener.location.href = window.opener.location.href; window.close(); </script>";
			Response.Write(js);
		}
	}
}

