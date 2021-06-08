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
using EPolicy.TaskControl;
using System.Web.Security;

namespace EPolicy
{
	/// <summary>
	/// Summary description for MainMenu.
	/// </summary>
	public partial class MainMenu : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Login.Login cp = HttpContext.Current.User as Login.Login;
			if (cp == null)
			{
				Response.Redirect("Default.aspx?001");
			}
			else
			{
				VerifyAccess(cp);
			}

            //Button1 = Utilities.ConfirmDialogBoxPopUp(Button1, "document.Main", "Does the customer have policy with PR Medical Defense Insurance Company?");

            if (!IsPostBack)
            {
                if (Request.QueryString["SigData"] != null)
                {
                    //private Topaz.SigPlusNET sp;
                    Topaz.SigPlusNET sp = new Topaz.SigPlusNET();

                    sp.AutoKeyStart();
                    sp.SetImageXSize(200); //Witdh
                    sp.SetImageYSize(50); //Height
                    sp.SetSigCompressionMode(1);
                    sp.SetDisplayPenWidth(5);
                    sp.SetJustifyMode(5);
                    sp.SetImageFileFormat(0);
                    sp.AutoKeyFinish();
                    sp.SetEncryptionMode(2);
                    sp.SetSigString(Request.QueryString["SigData"].ToString());


                    GC.Collect();
                    System.Drawing.Image im = sp.GetSigImage();

                    string filename = cp.Identity.Name.Split("|".ToCharArray())[0].ToString().Trim().Replace(" ", "") + "2.bmp";
                    filename = "C:\\Webs\\prmdic.net\\Sign\\" + filename;

                    if (System.IO.File.Exists(filename))
                         System.IO.File.Delete(filename);

                    im.Save(filename);
                    GC.Collect();               
                }
            }
		}

		private void VerifyAccess(Login.Login cp)
		{
            if (cp.IsInRole("POWERAGENT"))
            {
                this.btnLabQuote.Visible = false;
                this.btnAspenLab.Visible = false;
                this.Button4.Visible = false;
            }
            if (cp.IsInRole("AGENT"))
            {
                btnLabQuote.Visible = false;
                btnCyberQuote.Visible = false;
                Button2.Visible = false;
            }
            if (!cp.IsInRole("READ-ONLY"))
            {
                this.Button1.Visible = true;
                this.Button2.Visible = true;
                this.Button3.Visible = true;
                this.Button4.Visible = true;
                this.btnApplicationRequirements.Visible = true;
                
            }
            else
            {
                this.Button1.Visible = false;
                this.Button2.Visible = false;
                this.Button3.Visible = false;
                this.Button4.Visible = false;
                this.btnApplicationRequirements.Visible = false;
                this.btnLabQuote.Visible = false;
            }

            if (!cp.IsInRole("BTNLABQUOTE") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnLabQuote.Visible = false;
                this.btnCyberQuote.Visible = false;
            }
            else 
            {
                this.btnLabQuote.Visible = true;
                this.btnCyberQuote.Visible = true;
            }           

			if(!cp.IsInRole("BTNPROSPECTMAINMENU") && !cp.IsInRole("ADMINISTRATOR"))
			{
				this.btnProspect.Visible = false;
			}
			else
			{
				this.btnProspect.Visible = true;
			}

			if(!cp.IsInRole("BTNCUSTOMERMAINMENU") && !cp.IsInRole("ADMINISTRATOR"))
			{
				this.btnCustomer.Visible = false;
			}
			else
			{
				this.btnCustomer.Visible = true;
			}

            if (!cp.IsInRole("BTNQUOTESMAINMENU") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.Button1.Visible = false;
            }
            else
            {
                this.Button1.Visible = true;
            }
            if (cp.IsInRole("BTNQUOTESMAINMENU") && cp.IsInRole("APPLICATION"))
            {
                this.Button4.Visible = false;
                this.btnAspenLab.Visible = false;
            }
           
            
            
            if (!cp.IsInRole("BTNCORPORATEQUOTESMAINMENU") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.Button2.Visible = false;
            }
            else
            {
                this.Button2.Visible = true;
            }

            if (!cp.IsInRole("BTNASPENMAINMENU") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.Button3.Visible = false;
            }
            else
            {
                this.Button3.Visible = true;
            }

            if (!cp.IsInRole("BTNASPENQUOTESMAINMENU") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.Button4.Visible = false;
            }
            else
            {
                this.Button4.Visible = true;
            }
            if (cp.UserID == 198)
            {
                btnLabQuote.Visible = true;
            }
            if (!cp.IsInRole("BTNASPENLABQUOTESMAINMENU") && cp.IsInRole("APPLICATION"))
            {
                this.Button4.Visible = false;
            }
            if (!cp.IsInRole("BTNASPENLABQUOTESMAINMENU") && !cp.IsInRole("ACCOUNTING REPORTING"))
            {
                this.Button4.Visible = true;
            }
            else
            {
                this.Button4.Visible = false;
            }
            if (!cp.IsInRole("BTNASPENLABQUOTESMAINMENU") && cp.IsInRole("APPLICATION"))
            {
                this.Button4.Visible = false;
                this.btnApplicationRequirements.Visible = false;
            }

            if (!cp.IsInRole("CYBER") && !cp.IsInRole("ADMINISTRATOR"))
            {                
                this.btnCyberQuote.Visible = false;
            }
            else
            {               
                this.btnCyberQuote.Visible = true;
            }
            if (cp.IsInRole("BTNASPENLABQUOTESMAINMENU") && !cp.IsInRole("ADMINISTRATOR")) //Alexis
            {
                this.btnLabQuote.Visible = false;

            }
            else
            {
                this.btnLabQuote.Visible = true;
                this.btnAspenLab.Visible = true;
            
            }

            if (!cp.IsInRole("BTNASPENLABQUOTESMAINMENU") && !cp.IsInRole("ADMINISTRATOR")) 
            {
                 this.btnLabQuote.Visible = false;
            
            }
            else
            {
                this.btnLabQuote.Visible = true;
                this.btnAspenLab.Visible = true;
            
            }

            if (!cp.IsInRole("BTNASPENLABQUOTESMAINMENU") && cp.IsInRole("SUBSCRIPTION"))
            {
                this.btnLabQuote.Visible = true;

            }
            //else

            //{
            //    this.btnLabQuote.Visible = false;
            
            //}
            //if (int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]) != 1)
            //{
            //    this.btnSign.Visible = false;
            //}
            //else
            //{
            //    this.btnSign.Visible = true;
            //}            
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);

			//Setup top Banner
			Control Banner = new Control();
			Banner = LoadControl(@"TopBanner1.ascx");
			this.phTopBanner.Controls.Add(Banner);

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
            Session.Clear();
            HttpCookie authCookies = new HttpCookie(FormsAuthentication.FormsCookieName, null);
            Response.Cookies.Add(authCookies);
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx", false);
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			Session.Clear();
			TaskControl.QuoteAuto QA = new TaskControl.QuoteAuto(false);

            QA.IsMaster = true;
            QA.MasterPolicyID = "0004";
            QA.FileNumber = "10";
            QA.PolicyType = "MFC";

            QA.PolicyClassID = 3;
            QA.Policy.IsMaster = true;
            QA.Policy.MasterPolicyID = "0004";
            QA.Policy.FileNumber = "10";
            QA.Policy.PolicyType = "MFC";
            QA.IsPolicy = false;
			QA.Mode = 1; //ADD

			Session.Add("TaskControl",QA);
			Response.Redirect("ExpressAutoQuote.aspx",false);
		}

		protected void BtnLogIn_Click(object sender, System.EventArgs e)
		{
			Session.Clear();

			Customer.Customer customer = new Customer.Customer();
			customer.Mode = (int) Customer.Customer.CustomerMode.ADD;
			Session.Add("Customer",customer);

			Response.Redirect("ClientIndividual.aspx");
		}

		protected void Button5_Click(object sender, System.EventArgs e)
		{
			Session.Clear();
			Customer.Prospect prospect = new Customer.Prospect();
			prospect.Mode = 1;
			prospect.IsBusiness = false;
			Session["Prospect"] = prospect;
			Response.Redirect("ProspectIndividual.aspx");
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			Session.Clear();

			TaskControl.AutoGap autoGap = new TaskControl.AutoGap();
			autoGap.Mode = 1;
			Session.Add("AutoGap",autoGap);

			Response.Redirect("AutoGap.aspx");
		}

		protected void BtnSalir_Click(object sender, System.EventArgs e)
		{
			Session.Clear();
			Response.Redirect("PoliciesReports.aspx");
		}

		protected void Button4_Click(object sender, System.EventArgs e)
		{
            //Session.Clear();
            //TaskControl.OptimaPersonalPackage taskControl = new TaskControl.OptimaPersonalPackage(true);

            //taskControl.Mode = 1; //ADD
            //taskControl.IsOPPQuote = true;
            //taskControl.TaskControlTypeID = int.Parse(LookupTables.LookupTables.GetID("TaskControlType", "Optima Personal Package Quote"));

            //Session.Add("TaskControl", taskControl);
            //Response.Redirect("OptimaPersonalPackage.aspx");
		}

		protected void btnAutoGap_Click(object sender, System.EventArgs e)
		{
			Session.Clear();
			TaskControl.Policies taskControl = new TaskControl.Policies();

			taskControl.Mode = 1; //ADD
			taskControl.PolicyClassID = 9;

			Session.Add("TaskControl",taskControl);
			Response.Redirect("Policies.aspx",false);		
		}

		protected void btnVSC_Click(object sender, System.EventArgs e)
		{
            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = 0;
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

            Session.Clear();
            EPolicy.TaskControl.VehicleServiceContractQuote taskControl = new EPolicy.TaskControl.VehicleServiceContractQuote();

            taskControl.Mode = 1; //ADD
            taskControl.CompanyDealer = Login.Login.GetDealerByUserID(userID).ToString();

            Session.Add("TaskControl", taskControl);
            Response.Redirect("VehicleServiceContractQuote.aspx", false);
		}
        protected void btnAutoGapMaster_Click(object sender, EventArgs e)
        {
            Session.Clear();
            TaskControl.Policies taskControl = new TaskControl.Policies();

            taskControl.Mode = 1; //ADD
            taskControl.PolicyClassID = 9;
            taskControl.IsMaster = true;

            Session.Add("TaskControl", taskControl);
            Response.Redirect("Policies.aspx", false);
        }
        protected void btnEtch_Click(object sender, EventArgs e)
        {
            Session.Clear();
            TaskControl.Policies taskControl = new TaskControl.Policies();

            taskControl.Mode = 1; //ADD
            taskControl.PolicyClassID = 13;

            Session.Add("TaskControl", taskControl);
            Response.Redirect("Policies.aspx", false);
        }
        protected void btnFBMasterEmpleado_Click(object sender, EventArgs e)
        {
            Session.Clear();
            TaskControl.QuoteAuto QA = new TaskControl.QuoteAuto(false);

            QA.IsMaster = true;
            QA.MasterPolicyID = "0006";
            QA.FileNumber = "10";
            QA.PolicyType = "MFE";

            QA.PolicyClassID = 3;
            QA.Policy.IsMaster = true;
            QA.Policy.MasterPolicyID = "0006";
            QA.Policy.FileNumber = "10";
            QA.Policy.PolicyType = "MFE";
            QA.IsPolicy = false;
            QA.Mode = 1; //ADD

            Session.Add("TaskControl", QA);
            Response.Redirect("ExpressAutoQuote.aspx", false);
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            //if (bool.Parse(ConfirmDialogBoxPopUp.Value.Trim()) == false)
            //{
                Session.Clear();
                EPolicy.TaskControl.Application taskControl = new EPolicy.TaskControl.Application();

                taskControl.Mode = 1; //ADD
                taskControl.ApplicationMode = "ADD";
                taskControl.Residency = "001";

                Session.Add("TaskControl", taskControl);
                Response.Redirect("Application1.aspx", false);
            //}
            //else
            //{
                //Session.Clear();
                //Response.Redirect("SearchClient.aspx");
            //}
        }

        protected void btnFirstDollarQuote_Click(object sender, EventArgs e)
        {
            //if (bool.Parse(ConfirmDialogBoxPopUp.Value.Trim()) == false)
            //{
            Session.Clear();
            EPolicy.TaskControl.Application taskControl = new EPolicy.TaskControl.Application();

            taskControl.Mode = 1; //ADD
            taskControl.ApplicationMode = "ADD";
            taskControl.Residency = "001";
            taskControl.TaskControlTypeID = 26;

            Session.Add("TaskControl", taskControl);
            Response.Redirect("FirstDollarQuotes.aspx", false);
            //}
            //else
            //{
            //Session.Clear();
            //Response.Redirect("SearchClient.aspx");
            //}
        }

        protected void btnFirstDollarCorporate_Click(object sender, EventArgs e)
        {
            Session.Clear();
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = new EPolicy.TaskControl.CorporatePolicyQuote(false);

            taskControl.Mode = 1; //ADD
            taskControl.InsuranceCompany = "001";
            taskControl.TaskControlTypeID = 28;

            Session.Add("TaskControl", taskControl);

            Response.Redirect("FirstDollarCorporate.aspx", false);
        }

        

        protected void btnAlliedHealth_Click(object sender, EventArgs e)
        {
            //if (bool.Parse(ConfirmDialogBoxPopUp.Value.Trim()) == false)
            //{
            Session.Clear();
            EPolicy.TaskControl.Application taskControl = new EPolicy.TaskControl.Application();

            taskControl.Mode = 1; //ADD
            taskControl.ApplicationMode = "ADD";
            taskControl.Residency = "001";
            taskControl.TaskControlTypeID = 96;


            Session.Add("TaskControl", taskControl);
            Response.Redirect("AHCPrimaryQuotes.aspx", false);
            //}
            //else
            //{
            //Session.Clear();
            //Response.Redirect("SearchClient.aspx");
            //}
        }

        protected void btnAlliedHealthCorp_Click(object sender, EventArgs e)
        {
            Session.Clear();
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = new EPolicy.TaskControl.CorporatePolicyQuote(false);

            taskControl.Mode = 1; //ADD
            taskControl.InsuranceCompany = "001";
            taskControl.TaskControlTypeID = 96;


            Session.Add("TaskControl", taskControl);

            Response.Redirect("AHCCorporateQuotes.aspx", false);
        }

        protected void btnApplicationRequirements_Click(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.ActiveReport3 rpt = new EPolicy2.Reports.PRMdic.Requisitos();
            //DataDynamics.ActiveReports.ActiveReport3 rpt = new EPolicy2.Reports.PersonalPackageQuote(taskControl);
            //rpt.DataSource = dt;
            //rpt.DataMember = "Report";
            rpt.Document.Printer.PrinterName = "";
            rpt.Run(false);

            Session.Add("Report", rpt);
            Session.Add("FromPage", "MainMenu.aspx");
            Response.Redirect("ActiveXViewer.aspx");
        }
        protected void btnSign_Click(object sender, EventArgs e)
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
            string filename = cp.Identity.Name.Split("|".ToCharArray())[0].ToString().Trim().Replace(" ", "") + ".bmp";
            string js = "<script language=javascript> javascript:popwindow=window.open('CustomerSign.htm?Sign=" + filename +
                    "','popwindow','toolbar=no,modalpopup=yes,location=no,directories=no,status=no,menubar,scrollbars=no,resizable=no,copyhistory=no,width=350,height=300,left=435, top=200');popwindow.focus(); </script>";
            Response.Write(js);
        }
        protected void Button2_Click1(object sender, EventArgs e)
        {
            Session.Clear();
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = new EPolicy.TaskControl.CorporatePolicyQuote(false);

            taskControl.Mode = 1; //ADD
            taskControl.InsuranceCompany = "001";

            Session.Add("TaskControl", taskControl);

            Response.Redirect("CorporatePolicyQuote.aspx", false);
        }
        protected void Button4_Click1(object sender, EventArgs e)
        {
            Session.Clear();
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = new EPolicy.TaskControl.CorporatePolicyQuote(false);

            taskControl.Mode = 1; //ADD
            taskControl.InsuranceCompany = "002";

            Session.Add("TaskControl", taskControl);

            Response.Redirect("CorporatePolicyQuote.aspx", false);
        }
        protected void Button3_Click1(object sender, EventArgs e)
        {
            //if (bool.Parse(ConfirmDialogBoxPopUp.Value.Trim()) == false)
            //{
            Session.Clear();
            EPolicy.TaskControl.Application taskControl = new EPolicy.TaskControl.Application();

            taskControl.Mode = 1; //ADD
            taskControl.ApplicationMode = "ADD";
            taskControl.Residency = "002";

            Session.Add("TaskControl", taskControl);
            Response.Redirect("Application1.aspx", false);
            //}
            //else
            //{
            //Session.Clear();
            //Response.Redirect("SearchClient.aspx");
            //}
        }
        protected void BtnLabPolicy_Click(object sender, EventArgs e)
        {
            Session.Clear();
            EPolicy.TaskControl.Laboratory taskControl = new EPolicy.TaskControl.Laboratory(false);

            taskControl.Mode = 1; 
            taskControl.TaskControlTypeID = 19;

            Session.Add("TaskControl", taskControl);
            Response.Redirect("LaboratoryApplication1.aspx", false);
        }
        protected void btnCyberQuote_Click1(object sender, EventArgs e)
        {
            Session.Clear();
            EPolicy.TaskControl.Cyber taskControl = new EPolicy.TaskControl.Cyber(false);

            taskControl.Mode = 1;
            taskControl.TaskControlTypeID = 21;

            Session.Add("TaskControl", taskControl);
            Response.Redirect("CyberApplication.aspx", false);
        }
        protected void btnAspenLab_Click(object sender, EventArgs e)
        {
            Session.Clear();
            EPolicy.TaskControl.Laboratory taskControl = new EPolicy.TaskControl.Laboratory(false);

            taskControl.Mode = 1; //ADD
            taskControl.InsuranceCompany = "002";
            taskControl.TaskControlTypeID = 19;

            Session.Add("TaskControl", taskControl);

            Response.Redirect("LaboratoryApplication1.aspx", false);
        }
}
}
