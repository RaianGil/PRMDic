namespace EPolicy.EPolicyWeb.Components
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    using EPolicy;

    /// <summary>
    ///		Summary description for MenuTaskControl.
    /// </summary>
    public partial class MenuTaskControl : System.Web.UI.UserControl
    {
        bool enableCharge;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
            if (cp == null)
            {
                Response.Redirect("Default.aspx?001");
            }
            else
            {
                VerifyAccess(cp);
                if (!IsPostBack)
                    enableCharge = true;
            }
            this.litPopUp.Visible = false;
        }

        private void VerifyAccess(EPolicy.Login.Login cp)
        {
            if (!cp.IsInRole("BTNREPORTLEFTMENU") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.Button12.Visible = false;
            }
            else
            {
                this.Button12.Visible = true;
            }

            if (!cp.IsInRole("BTNPROSPECTLEFTMENU") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.Button5.Visible = false;
            }
            else
            {
                this.Button5.Visible = true;
            }

            if (!cp.IsInRole("BTNPOLICYLEFTMENU") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.Button7.Visible = false;
            }
            else
            {
                this.Button7.Visible = true;
            }

            if (!cp.IsInRole("BTNCUSTOMERLEFTMENU") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.Button6.Visible = false;
            }
            else
            {
                this.Button6.Visible = true;
            }

            if (!cp.IsInRole("BTNLOOKUPTABLELEFTMENU") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.Button1.Visible = false;
                this.Label5.Visible = false;
            }
            else
            {
                this.Button1.Visible = true;
                this.Label5.Visible = true;
            }

            if (!cp.IsInRole("BTNUSERPROPERTIESLISTLEFTMENU") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.Button2.Visible = false;
            }
            else
            {
                this.Button2.Visible = true;
            }

            if (!cp.IsInRole("BTNADDUSERLEFTMENU") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.Button4.Visible = false;
            }
            else
            {
                this.Button4.Visible = true;
            }

            //if (!cp.IsInRole("BTNGROUPPERMISSIONLEFTMENU") && !cp.IsInRole("ADMINISTRATOR"))
            //{
            //    this.Button3.Visible = false;
            //}
            //else
            //{
            //    this.Button3.Visible = true;
            //}
            if (!cp.IsInRole("ADMINISTRATOR"))
            {
                this.BtnUploadSS.Visible = false;
            }
            else
            {
                this.BtnUploadSS.Visible = true;
            }


            if (!cp.IsInRole("BTNCLAIMSLEFTMENU") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnClaim.Visible = false;
                this.btnSearchClaim.Visible = false;
                this.Label3.Visible = false;
            }
            else
            {
                this.btnClaim.Visible = true;
                this.btnSearchClaim.Visible = true;
                this.Label3.Visible = true;
            }

            if (!cp.IsInRole("BTNDIRECTORYLEFTMENU") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnDirectory.Visible = false;
            }
            else
            {
                this.btnDirectory.Visible = true;
            }

            if (!cp.IsInRole("BTNSEARCHGROUPLEFTMENU") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnGroup.Visible = false;
            }
            else
            {
                this.btnGroup.Visible = true;
            }

            if (!cp.IsInRole("BTNPAYMENTEXPRESSLEFTMENU") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.Button10.Visible = false;
            }
            else
            {
                this.Button10.Visible = true;
            }

            if (!cp.IsInRole("BTNPROCESS") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnProcess.Visible = false;
            }
            else
            {
                this.btnProcess.Visible = true;
            }

            if (!cp.IsInRole("ADMINISTRATOR") && !cp.IsInRole("ACCOUNTING"))
            {
                this.btnImportPayments.Visible = false;
            }
            else
            {
                this.btnImportPayments.Visible = true;
            }
            if(cp.IsInRole("MARKETING")&& cp.UserID != 331)
            {
                Button2.Visible = false;
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

        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion


        private void BtnProspect_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Page.Response.Redirect("SearchProspect.aspx");
        }

        private void BtnHome_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Response.Redirect("HomePage.aspx");
        }

        private void BtnCustomer_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Page.Response.Redirect("SearchClient.aspx");
        }

        private void BtnSystemAdmin_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Page.Response.Redirect("LookupTableMaintenance.aspx");
        }

        private void BtnSuperSearch_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Page.Response.Redirect("TaskControl.aspx");
        }

        private void BtnAutoQuote_Click(object sender, System.EventArgs e)
        {
            Session.Clear();

            TaskControl.QuoteAuto QA = new TaskControl.QuoteAuto(false);

            QA.Mode = 1; //ADD

            Session.Add("TaskControl", QA);
            Response.Redirect("ExpressAutoQuote.aspx", false);
        }

        private void BtnPolicy_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Response.Redirect("SearchPolicies.aspx");
        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Response.Redirect("LookupTableMaintenance.aspx");
        }

        protected void Button3_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Response.Redirect("GroupAndPermissions.aspx");
        }

        protected void BtnUploadSS_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Response.Redirect("UploadSS.aspx");
        }

        protected void btnProcess_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Response.Redirect("PolicyReport.aspx");
        }

        protected void Button2_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Response.Redirect("UserPropertiesList.aspx");
        }

        protected void Button5_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Response.Redirect("SearchProspect.aspx");
        }

        protected void Button6_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Response.Redirect("SearchClient.aspx");
        }

        protected void Button7_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Response.Redirect("SearchPolicies.aspx");
        }

        protected void Button12_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Response.Redirect("PoliciesReports.aspx");
        }

        protected void Button4_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            EPolicy.Login.Login login = new EPolicy.Login.Login();
            login.Mode = (int)EPolicy.Login.Login.LoginMode.ADD;
            Session.Add("Login", login);
            Response.Redirect("UsersProperties.aspx");
        }

        protected void Button9_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Search.aspx");
        }

        protected void Button11_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            TaskControl.QuoteAuto QA = new TaskControl.QuoteAuto(false);

            QA.Mode = 1; //ADD

            Session.Add("TaskControl", QA);
            Response.Redirect("ExpressAutoQuote.aspx");
        }

        protected void Button8_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Response.Redirect("MainMenu.aspx");
        }

        protected void btnQueriesGroupLeftMenu_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Response.Redirect("QueriesGroupReports.aspx");
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        protected void btnVSCRate_Click(object sender, EventArgs e)
        {
            Session.Clear();
            EPolicy.LookupTables.VSCRate vscRate = new EPolicy.LookupTables.VSCRate();
            vscRate.Mode = 4; //Clear

            Session["VSCRate"] = vscRate;
            Response.Redirect("VSCRate.aspx");
        }
        protected void Button13_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("VSCAddMakeModel.aspx");
        }
        protected void Button14_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("VSCAddExceptionRateByDealer.aspx");
        }
        protected void Button15_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("VSCPending.aspx");
        }
        protected void btnDirectory_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Directorio.aspx");
        }
        protected void btnGroup_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("SearchGroup.aspx");
        }
        protected void Button10_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("PaymentVSC.aspx");
        }
        protected void btnImportPayments_Click(object sender, EventArgs e)
        {
            Response.Redirect("CertificateFileUpload.aspx");

        }
        protected void btnFinancial_Click(object sender, EventArgs e)
        {

        }
}
}
