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
	/// Summary description for PaymentsReport.
	/// </summary>
	public partial class PaymentsReport : System.Web.UI.Page
	{
		private const string FILE_NAME = "BankFile.txt";
		//private const string FILE_NAME = "http://webdev//SAMS//DownloadFile//BankFile.txt";								  		 

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
				if(!cp.IsInRole("PAYMENTSREPORT") && !cp.IsInRole("ADMINISTRATOR"))
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


			//Load DownDropList
			DataTable dtPolicyClass		= LookupTables.LookupTables.GetTable("PolicyClass");
			DataTable dtBank			= LookupTables.LookupTables.GetTable("Bank");

			//PolicyClass
			ddlPolicyClass.DataSource = dtPolicyClass;
			ddlPolicyClass.DataTextField = "PolicyClassDesc";
			ddlPolicyClass.DataValueField = "PolicyClassID";
			ddlPolicyClass.DataBind();
			ddlPolicyClass.SelectedIndex = -1;
			ddlPolicyClass.Items.Insert(0,"");

			//Bank
			ddlBank.DataSource = dtBank;
			ddlBank.DataTextField = "BankDesc";
			ddlBank.DataValueField = "BankID";
			ddlBank.DataBind();
			ddlBank.SelectedIndex = -1;
			ddlBank.Items.Insert(0,"");
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		private void btnPrint_Click(object sender, System.Web.UI.ImageClickEventArgs e)
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
					PaymentsList();
					break;

				case "1":   
					PaymentsApplied();
					break; 
                 
				case "2":     
					PaymentsUnapplied();
					break;  
    
				case "3":     
					PaymentsDeposited();
					break;  

				case "4":     
					PaymentsByCheckNo();
					break;  

				case "6":     
					PaymentsSRO();
					break;  
			}
		}

		public void PaymentsList()
		{
			EPolicy2.Reports.PaymentsReports appAutoreport = new EPolicy2.Reports.PaymentsReports();
			DataTable dt = appAutoreport.PaymentsList(txtBegDate.Text,TxtEndDate.Text,ddlPolicyClass.SelectedItem.Value,"O");

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

            DataDynamics.ActiveReports.ActiveReport3 rpt = new PaymentsList(txtBegDate.Text, TxtEndDate.Text, "Payments List", CompanyHead);
			
			//rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;

			rpt.DataSource = dt;
			rpt.DataMember = "Report";

            rpt.Document.Printer.PrinterName = ""; 

			rpt.Run(false);

			Session.Add("Report",rpt);
			Session.Add("FromPage","PaymentsReport.aspx");
			Response.Redirect("ActiveXViewer.aspx",false);
		}

		public void PaymentsApplied()
		{
			EPolicy2.Reports.PaymentsReports appAutoreport = new EPolicy2.Reports.PaymentsReports();
			DataTable dt = appAutoreport.PaymentsList(txtBegDate.Text,TxtEndDate.Text,ddlPolicyClass.SelectedItem.Value,"A");

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

            DataDynamics.ActiveReports.ActiveReport3 rpt = new PaymentsList(txtBegDate.Text, TxtEndDate.Text, "Payments Applied", CompanyHead);

			//rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;

			rpt.DataSource = dt;
			rpt.DataMember = "Report";

            rpt.Document.Printer.PrinterName = ""; 

			rpt.Run(false);

			Session.Add("Report",rpt);
			Session.Add("FromPage","PaymentsReport.aspx");
			Response.Redirect("ActiveXViewer.aspx",false);
		}

		public void PaymentsUnapplied()
		{
			EPolicy2.Reports.PaymentsReports appAutoreport = new EPolicy2.Reports.PaymentsReports();
			DataTable dt = appAutoreport.PaymentsList(txtBegDate.Text,TxtEndDate.Text,ddlPolicyClass.SelectedItem.Value,"U");

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

            DataDynamics.ActiveReports.ActiveReport3 rpt = new PaymentsList(txtBegDate.Text, TxtEndDate.Text, "Payments Unapplied", CompanyHead);
			//rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
			
			rpt.DataSource = dt;
			rpt.DataMember = "Report";

            rpt.Document.Printer.PrinterName = "";

			rpt.Run(false);

			Session.Add("Report",rpt);
			Session.Add("FromPage","PaymentsReport.aspx");
			Response.Redirect("ActiveXViewer.aspx",false);
		}

		public void PaymentsDeposited()
		{
			EPolicy2.Reports.PaymentsReports appAutoreport = new EPolicy2.Reports.PaymentsReports();
			DataTable dt = appAutoreport.PaymentsList(txtBegDate.Text,TxtEndDate.Text,ddlPolicyClass.SelectedItem.Value,"D");

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

            DataDynamics.ActiveReports.ActiveReport3 rpt = new PaymentsList(txtBegDate.Text, TxtEndDate.Text, "Payments Deposited", CompanyHead);
			//rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
			
			rpt.DataSource = dt;
			rpt.DataMember = "Report";

            rpt.Document.Printer.PrinterName = ""; 

			rpt.Run(false);

			Session.Add("Report",rpt);
			Session.Add("FromPage","PaymentsReport.aspx");
			Response.Redirect("ActiveXViewer.aspx",false);
		}

		public void PaymentsByCheckNo()
		{
			EPolicy2.Reports.PaymentsReports appAutoreport = new EPolicy2.Reports.PaymentsReports();
			DataTable dt = appAutoreport.PaymentsByCheckNo(txtBegDate.Text,TxtEndDate.Text,TxtCheckNo.Text);

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

            DataDynamics.ActiveReports.ActiveReport3 rpt = new PaymentsList(txtBegDate.Text, TxtEndDate.Text, "Payments By Check No", CompanyHead);
			//rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
			
			rpt.DataSource = dt;
			rpt.DataMember = "Report";

            rpt.Document.Printer.PrinterName = ""; 

			rpt.Run(false);

			Session.Add("Report",rpt);
			Session.Add("FromPage","PaymentsReport.aspx");
			Response.Redirect("ActiveXViewer.aspx",false);
		}

		public void PaymentsSRO()
		{
			EPolicy2.Reports.PaymentsReports appAutoreport = new EPolicy2.Reports.PaymentsReports();
			DataTable dt = appAutoreport.PaymentsSRO(txtBegDate.Text,TxtEndDate.Text,true);

            DataDynamics.ActiveReports.ActiveReport3 rpt = new PaymentsList(txtBegDate.Text, TxtEndDate.Text, "Payments SRO", "");
			
			//rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;

			rpt.DataSource = dt;
			rpt.DataMember = "Report";

            rpt.Document.Printer.PrinterName = ""; 

			rpt.Run(false);

			Session.Add("Report",rpt);
			Session.Add("FromPage","PaymentsReport.aspx");
			Response.Redirect("ActiveXViewer.aspx",false);
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

			if (rblProspectsReports.SelectedItem.Value == "4") //Payment By Cehck No
			{
				if (this.TxtCheckNo.Text == "" && found == false)
				{
					errorMessage = "Please enter the Check No.";
					found = true;
				}
			}

			//throw the exception.
			if (errorMessage != String.Empty)
			{
				throw new Exception(errorMessage);
			}	
		}

		protected void rblProspectsReports_SelectedIndexChanged(object sender, System.EventArgs e)
		{
				switch(rblProspectsReports.SelectedItem.Value)       
			{         
				case "4":     
					LblBank.Visible = false;
					ddlBank.Visible = false;
					LblLineOfBusiness.Visible = true;
					ddlPolicyClass.Visible	  = true;
					LblCheckNo.Visible  = true;
					TxtCheckNo.Visible  = true;
					Button2.Visible    = true;
					break;  

				case "5":     
					LblBank.Visible = true;
					ddlBank.Visible = true;
					LblLineOfBusiness.Visible = false;
					ddlPolicyClass.Visible	  = false;
					LblCheckNo.Visible = false;
					TxtCheckNo.Visible = false;
					Button2.Visible    = false;
					break;  

				case "6":     
					LblBank.Visible = false;
					ddlBank.Visible = false;
					LblLineOfBusiness.Visible = false;
					ddlPolicyClass.Visible	  = false;
					LblCheckNo.Visible = false;
					TxtCheckNo.Visible = false;
					Button2.Visible    = true;
					break;

				default:
					LblBank.Visible = false;
					ddlBank.Visible = false;
					LblLineOfBusiness.Visible = true;
					ddlPolicyClass.Visible	  = true;
					LblCheckNo.Visible = false;
					TxtCheckNo.Visible = false;
					Button2.Visible    = true;
					break;
			}
		}

		private void DownLoadFile()
		{
			string FileNameOf = "BankFile.txt";
			string ContentTypeOf = "Text/TXT";
				
			//Get File Size------------------------------------ 
			FileStream sourceFile = new FileStream(FILE_NAME,FileMode.Open);
			long SizeOf;
			SizeOf = sourceFile.Length;
			//-------------------------------------------------

			//Header and Cache---------------------------------
			Response.ClearHeaders();
			Response.Expires = 0;
			Response.Buffer = true;
			Response.Clear();
			Response.ContentType = ContentTypeOf;
			Response.AddHeader("Content-type", "Text/TXT");
			Response.AddHeader("content-disposition", "inline; filename=" + FileNameOf);
			Response.AddHeader("Content-Length", SizeOf.ToString());
			Response.Charset = "UTF-8";
			Response.Flush();
			
			//Loop through blocks of data and send-------------
			byte[] getContent = new byte[(int)SizeOf];
			sourceFile.Read(getContent,0,(int)sourceFile.Length);
				
			Response.BinaryWrite(getContent);  //BlockOf
			Response.Flush();			
			sourceFile.Close();
			Response.End();
		}

		private void BuildTextFile()
		{
			StreamWriter sr;
				
			TaskControl.Payments payments = new TaskControl.Payments();
			DataTable dt = payments.GetPaymentFileForBank(ddlBank.SelectedItem.Value.Trim(),txtBegDate.Text,TxtEndDate.Text);
			
			sr = File.CreateText(FILE_NAME);
	
			for (int i = 0; i <= dt.Rows.Count-1; i++)
			{
				string rowString="";

				string var1 = dt.Rows[i]["Bank"].ToString(); //3
				var1 = var1.Trim();
				var1 = var1.PadRight(3,' ');

				string var2 = dt.Rows[i]["PolicyType"].ToString(); //3
				var2 = var2.Trim();
				var2 = var2.PadRight(3,' ');

				string var3 = dt.Rows[i]["OriginalPolicyNo"].ToString(); //11
				var3 = var3.Trim();
				var3 = var3.PadRight(11,' ');

				string var4 = dt.Rows[i]["PolicyNo"].ToString(); //11
				var4 = var4.Trim();
				var4 = var4.PadRight(11,' ');

				string var5 = dt.Rows[i]["Certificate"].ToString(); //10
				var5 = var5.Trim();
				var5 = var5.PadRight(10,' ');

				DateTime vardate1 = DateTime.Parse(rowString + dt.Rows[i]["PaymentDate"].ToString()); 
				string var6 = vardate1.ToString("yyyyMMdd");   //8

				string var7 = dt.Rows[i]["Sufijo"].ToString(); //2
				var7 = var7.Trim();
				var7 = var7.PadRight(2,' ');

				string var8 = dt.Rows[i]["LoanNo"].ToString(); //15
				var8 = var8.Trim();
				var8 = var8.PadRight(15,' ');

				string var9 = dt.Rows[i]["CheckNo"].ToString(); //10
				var9 = var9.Trim();
				var9 = var9.PadRight(10,' ');

				string var10 = ((decimal) dt.Rows[i]["PaymentAmount"]).ToString("########.00"); //10
				var10 = var10.Trim();
				var10 = var10.PadLeft(10,' ');
				
				rowString = var1+var2+var3+var4+var5+var6+var7+var8+var9+var10;  //+"\r\n";

				sr.WriteLine(rowString);
			}
			sr.WriteLine();
			sr.Close();

		}

		private void BtnDownload_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				FieldVerify();
				
				BuildTextFile();
				DownLoadFile();
			}
			catch (Exception exp)
			{
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
				this.litPopUp.Visible = true;
				return;
			}
		}

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
					PaymentsList();
					break;

				case "1":   
					PaymentsApplied();
					break; 
                 
				case "2":     
					PaymentsUnapplied();
					break;  
    
				case "3":     
					PaymentsDeposited();
					break;  

				case "4":     
					PaymentsByCheckNo();
					break;  

				case "6":     
					PaymentsSRO();
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
