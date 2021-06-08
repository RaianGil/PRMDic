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
using System.Collections.Generic;


namespace EPolicy
{
    /// <summary>
    /// Summary description for Agent.
    /// </summary>
    public partial class Agent : System.Web.UI.Page
    {
        private Control LeftMenu;

        #region Enumerations

        public enum UserAction { ADD = 1, VIEW = 2, SAVE = 3, EDIT = 4, CANCEL = 5 };

        #endregion


        private void SetCertificateLocationNumerationLabel()
        {
            LookupTables.CertificateLocation certificateLocation =
                (LookupTables.CertificateLocation)Session["CertificateLocation"];

            this.lblCertificateID.Text = (certificateLocation.CertificateLocationID != "") ?
                certificateLocation.CertificateLocationID.ToString() :
                String.Empty;
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
            if (cp == null)
            {
                Response.Redirect("HomePage.aspx?001");
            }
            else
            {
                if (!cp.IsInRole("LIMITEDLOOKUPTABLE"))
                {
                    if (!cp.IsInRole("AGENT") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        Response.Redirect("HomePage.aspx?001");
                    }
                }
            }

            if (!Page.IsPostBack)
            {
                LookupTables.CertificateLocation certificateLocation = new LookupTables.CertificateLocation();

                if (Request.QueryString["item"] != null &&
                    Request.QueryString["item"].ToString() != String.Empty)
                {
                    try
                    {
                        certificateLocation.GetCertificateLocation(Request.QueryString["item"].ToString());
                        certificateLocation.ActionMode = 2; //UPDATE
                        certificateLocation.NavigationViewModelTable =
                            (DataTable)Session["DtRecordsForNonValuePairLookupTable"];
                        Session["CertificateLocation"] = certificateLocation;
                    }
                    catch (Exception ex)
                    {
                        this.ShowMessage("There is no Certificate Location for the supplied " +
                            "ID. " + ex.Message);
                    }
                }
                else
                {
                    certificateLocation.ActionMode = 1; //ADD
                    Session["CertificateLocation"] = certificateLocation;
                }

            }

            if (Session["CertificateLocation"] != null)
            {
                LookupTables.CertificateLocation certificateLocation =
                    (LookupTables.CertificateLocation)Session["CertificateLocation"];

                this.InitializeControls();

                switch (certificateLocation.ActionMode)
                {
                    case 1: //ADD
                        this.SetControlState((int)UserAction.ADD);
                        if (!Page.IsPostBack)
                        {
                            this.FillControls();
                        }
                        break;

                    default: //UPDATE
                        if (!Page.IsPostBack)
                        {
                            this.FillControls();
                            this.SetControlState((int)UserAction.VIEW);
                        }
                      
                        break;
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
            this.Placeholder1.Controls.Add(Banner);

            //Setup Left-side Banner

            /*LeftMenu = new Control();
            LeftMenu = LoadControl(@"LeftMenu.ascx");
            phTopBanner1.Controls.Add(LeftMenu);*/
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEdit1.Click += new System.Web.UI.ImageClickEventHandler(this.btnEdit_Click);
            this.BtnSave1.Click += new System.Web.UI.ImageClickEventHandler(this.BtnSave_Click);
            this.btnSearch1.Click += new System.Web.UI.ImageClickEventHandler(this.btnSearch_Click);
            this.cmdCancel1.Click += new System.Web.UI.ImageClickEventHandler(this.cmdCancel_Click);
            this.btnPrint1.Click += new System.Web.UI.ImageClickEventHandler(this.btnPrint_Click);
            this.btnAuditTrail1.Click += new System.Web.UI.ImageClickEventHandler(this.btnAuditTrail_Click);
            this.BtnExit1.Click += new System.Web.UI.ImageClickEventHandler(this.BtnExit_Click);

        }
        #endregion




        private void InitializeControls()
        {
            this.SetCertificateLocationNumerationLabel();
            this.litPopUp.Visible = false;
        }

        private void SetControlState(int Action)
        {
            switch (Action)
            {
                case 1: //ADD ACTION
                    this.EnableInputControls(true);
                    this.btnEdit.Visible = false;
                    this.BtnSave.Visible = true;
                    this.cmdCancel.Visible = true;
                    this.btnAddNew.Visible = false;
                    this.btnPrint.Visible = false;
                    this.btnSearch.Visible = false;
                    this.BtnExit.Visible = false;
                    break;
                case 2: //VIEW ACTION
                    this.EnableInputControls(false);
                    this.btnEdit.Visible = true;
                    this.BtnSave.Visible = false;
                    this.cmdCancel.Visible = false;
                    this.btnAddNew.Visible = true;
                    this.btnSearch.Visible = true;
                    this.BtnExit.Visible = true;
                    break;
                case 3: //SAVE ACTION
                    this.SetControlState((int)UserAction.VIEW);
                    break;
                case 4: //EDIT ACTION
                    this.EnableInputControls(true);
                    this.btnEdit.Visible = false;
                    this.BtnSave.Visible = true;
                    this.cmdCancel.Visible = true;
                    this.btnAddNew.Visible = false;
                    this.btnSearch.Visible = false;
                    this.BtnExit.Visible = false;
                    break;
                default: //CANCEL ACTION
                    LookupTables.CertificateLocation certificateLocation =
                        (LookupTables.CertificateLocation)Session["CertificateLocation"];
                    if (certificateLocation.ActionMode == 0) //ADD
                    {
                        Session["CertificateLocation"] = null;
                        Response.Redirect("SearchLookupTableDescriptions.aspx");
                    }
                    else
                    {
                        this.SetControlState((int)UserAction.VIEW);
                    }
                    break;
            }
        }// End SetControlState

        private void EnableInputControls(bool State)
        {
            if (State)
            {
                this.txtCertificateLocationDesc.Enabled = true;
                this.txtAddress1.Enabled = true;
                this.txtAddress2.Enabled = true;
                this.txtCity.Enabled = true;
                this.txtSt.Enabled = true;
                this.txtZipCode.Enabled = true;
                this.txtPhone.Enabled = true;
                this.txtEmail.Enabled = true;
                this.txtEmail2.Enabled = true;
                this.txtEmail3.Enabled = true;
            }
            else
            {
                this.txtCertificateLocationDesc.Enabled = false;
                this.txtAddress1.Enabled = false;
                this.txtAddress2.Enabled = false;
                this.txtCity.Enabled = false;
                this.txtSt.Enabled = false;
                this.txtZipCode.Enabled = false;
                this.txtPhone.Enabled = false;
                this.txtEmail.Enabled = false;
                this.txtEmail2.Enabled = false;
                this.txtEmail3.Enabled = false;
            }
        }

        private void FillControls()
        {
            LookupTables.CertificateLocation certificateLocation =
                (LookupTables.CertificateLocation)Session["CertificateLocation"];


            this.txtCertificateLocationDesc.Text = (certificateLocation.CertificateLocationDesc != "" ?
                certificateLocation.CertificateLocationDesc.ToString() :
                String.Empty);

            this.txtAddress1.Text =
                certificateLocation.certificateLocationaddr1.Trim();

            this.txtAddress2.Text =
                certificateLocation.certificateLocationaddr2.Trim();

            this.txtCity.Text =
                certificateLocation.certificateLocationcity.Trim();

            this.txtSt.Text =
                certificateLocation.certificateLocationst.Trim();

            this.txtZipCode.Text =
                certificateLocation.certificateLocationzip.Trim();

            this.txtPhone.Text =
                certificateLocation.certificateLocationphone.Trim();
            this.txtEmail.Text =
                certificateLocation.certificateLocationEmail.Trim();
            this.txtEmail2.Text =
                certificateLocation.certificateLocationEmail2.Trim();
            this.txtEmail3.Text =
                certificateLocation.certificateLocationEmail3.Trim();
        }

        protected void BtnSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = 0;

            try
            {
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Could not parse user id from cp.Identity.Name.", ex);
            }

            LookupTables.CertificateLocation certificateLocation =
                (LookupTables.CertificateLocation)Session["CertificateLocation"];
            try
            {
                switch (certificateLocation.ActionMode)
                {
                    case 1: //ADD
                        this.FillProperties(ref certificateLocation);
                        certificateLocation.Save(userID);
                        break;
                    case 3: //DELETE
                        break;
                    case 4: //CLEAR
                        break;
                    default: //UPDATE
                        this.FillProperties(ref certificateLocation);
                        certificateLocation.Save(userID);
                        Session["CertificateLocation"] = certificateLocation;
                        this.SetControlState((int)UserAction.VIEW);
                        break;
                }
                this.litPopUp.Text =
                    Utilities.MakeLiteralPopUpString(
                    "The Certificate Location information saved successfully.");
                this.litPopUp.Visible = true;
                this.SetCertificateLocationNumerationLabel();
                this.SetControlState((int)UserAction.SAVE);

                Session["CertificateLocation"] = certificateLocation;
            }
            catch (Exception xcp)
            {
                this.ShowMessage("Unable to save or modify Agent. " + xcp.Message);
            }
        }//End BtnSave_Click



        private void ShowMessage(string MessageText)
        {
            this.litPopUp.Text =
                Utilities.MakeLiteralPopUpString(MessageText);
            this.litPopUp.Visible = true;
        }

        private void FillProperties(ref LookupTables.CertificateLocation certificateLocation)
        {
            try
            {
                certificateLocation.CertificateLocationDesc = (this.txtCertificateLocationDesc.Text.ToString().ToUpper());
            }
            catch
            {
                this.ShowMessage("Could not fill 'CertificateLocationID' property. " +
                    "Please enter a valid value for this field.");
            }
            certificateLocation.certificateLocationaddr1 = this.txtAddress1.Text.ToString().ToUpper();
            certificateLocation.certificateLocationaddr2 = this.txtAddress2.Text.ToString().ToUpper();
            certificateLocation.certificateLocationcity = this.txtCity.Text.ToString().ToUpper();
            certificateLocation.certificateLocationst = this.txtSt.Text.ToString().ToUpper();
            certificateLocation.certificateLocationzip = this.txtZipCode.Text;
            certificateLocation.certificateLocationphone = this.txtPhone.Text;
            try
            {
                certificateLocation.certificateLocationEmail = this.txtEmail.Text.ToString();
                certificateLocation.certificateLocationEmail2 = this.txtEmail2.Text.ToString();
                certificateLocation.certificateLocationEmail3 = this.txtEmail3.Text.ToString();
            }
            catch
            {
                this.ShowMessage("Could not fill Email List. " +
                                                        "Please enter a valid value for this field.");
                return;
            }
            
           string[] emailList = {txtEmail.Text.ToString(), txtEmail2.Text.ToString(), txtEmail3.Text.ToString()};
           bool isEmaill = false;

           for (int i = 0; i < emailList.Length; i++)
           {
               if (emailList[i].ToString() != "")
               {
                   isEmaill = isEmail(emailList[i].ToString());

                   
                   if (!isEmaill)
                   {
                       this.ShowMessage("Could not fill Email List. " +
                                         "Please enter a valid value for this field.");
                   }

               }
           }
        }



        protected void BtnExit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            LookupTables.CertificateLocation certificateLocation =
                (LookupTables.CertificateLocation)Session["CertificateLocation"];

            if (certificateLocation.ActionMode == 1) //ADD
                Response.Redirect("LookupTableMaintenance.aspx");
            else
            {
                Response.Redirect(
                    "SearchLookupTableDescriptions.aspx?SelectedItem=" +
                    LookupTables.LookupTables.GetLookupTableIdFromTableName(
                    "CertificateLocation").ToString());
            }
        }

        private bool isEmail(string inputEmail)
        {

            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";



            System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(strRegex);



            if (re.IsMatch(inputEmail.Trim()))

                return (true);

            else

                return (false);

        }
        protected void cmdCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            this.SetControlState((int)UserAction.CANCEL);
        }

        protected void btnEdit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            LookupTables.CertificateLocation certificateLocation =
                (LookupTables.CertificateLocation)Session["CertificateLocation"];
            certificateLocation.ActionMode = 2;
            Session["CertificateLocation"] = certificateLocation;
            this.SetControlState((int)UserAction.EDIT);
        }

        private bool IsNavigationTableNull()
        {
            LookupTables.CertificateLocation certificateLocation =
                (LookupTables.CertificateLocation)Session["CertificateLocation"];
            if (certificateLocation.NavigationViewModelTable == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnAddNew_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("CertificateLocation.aspx");
        }

        protected void btnSearch_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect(
                "SearchLookupTableDescriptions.aspx?SelectedItem=" +
                LookupTables.LookupTables.GetLookupTableIdFromTableName(
                "CertificateLocation").ToString());
        }

        protected void btnPrint_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            EPolicy2.Reports.AdministrativeTools atreport = new EPolicy2.Reports.AdministrativeTools();
            DataTable dt = atreport.AgentList();

            DataDynamics.ActiveReports.ActiveReport3 rpt = new GeneralList("CertificateLocation");

            //rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;

            rpt.DataSource = dt;
            rpt.DataMember = "Report";
            rpt.Run(false);

            Session.Add("Report", rpt);
            Session.Add("FromPage", LookupTables.LookupTables.GetTableMaintenancePathFromTableID(26) + "?item=" + this.lblCertificateID.Text);
            Response.Redirect("ActiveXViewer.aspx", false);
        }

        protected void btnAddNew_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("CertificateLocation.aspx");
        }

        protected void btnEdit_Click(object sender, System.EventArgs e)
        {
            LookupTables.CertificateLocation certificateLocation =
                (LookupTables.CertificateLocation)Session["CertificateLocation"];
            certificateLocation.ActionMode = 2;
            Session["CertificateLocation"] = certificateLocation;
            this.SetControlState((int)UserAction.EDIT);
        }

        protected void BtnSave_Click(object sender, System.EventArgs e)
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = 0;

            try
            {
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Could not parse user id from cp.Identity.Name.", ex);
            }

            LookupTables.CertificateLocation certificateLocation =
                (LookupTables.CertificateLocation)Session["CertificateLocation"];
            try
            {
                switch (certificateLocation.ActionMode)
                {
                    case 1: //ADD
                        this.FillProperties(ref certificateLocation);
                        certificateLocation.Save(userID);
                        break;
                    case 3: //DELETE
                        break;
                    case 4: //CLEAR
                        break;
                    default: //UPDATE
                        this.FillProperties(ref certificateLocation);
                        certificateLocation.Save(userID);
                        Session["CertificateLocation"] = certificateLocation;
                        this.SetControlState((int)UserAction.VIEW);
                        break;
                }
                this.litPopUp.Text =
                    Utilities.MakeLiteralPopUpString(
                    "The Certificate Location information was saved successfully.");
                this.litPopUp.Visible = true;
                this.SetCertificateLocationNumerationLabel();
                this.SetControlState((int)UserAction.SAVE);

                Session["CertificateLocation"] = certificateLocation;
            }
            catch (Exception xcp)
            {
                this.ShowMessage("Unable to save or modify Certificate Location. " + xcp.Message);
            }
        }

        protected void btnSearch_Click(object sender, System.EventArgs e)
        {
            Response.Redirect(
                "SearchLookupTableDescriptions.aspx?SelectedItem=" +
                LookupTables.LookupTables.GetLookupTableIdFromTableName(
                "CertificateLocation").ToString());
        }

        protected void cmdCancel_Click(object sender, System.EventArgs e)
        {
            LookupTables.CertificateLocation certificateLocation = (LookupTables.CertificateLocation)Session["CertificateLocation"];

            if (certificateLocation.ActionMode == 1) //ADD
                Response.Redirect("LookupTableMaintenance.aspx");
            else
            {
                this.SetControlState((int)UserAction.CANCEL);
            }
        }

        protected void btnAuditTrail_Click(object sender, System.EventArgs e)
        {
            if (Session["CertificateLocation"] != null)
            {
                LookupTables.CertificateLocation certificateLocation = (LookupTables.CertificateLocation)Session["CertificateLocation"];
                Response.Redirect("SearchAuditItems.aspx?type=4&agentID=" +
                    certificateLocation.CertificateLocationID.Trim());
            }
        }

        protected void BtnExit_Click(object sender, System.EventArgs e)
        {
            LookupTables.CertificateLocation certificateLocation =
                (LookupTables.CertificateLocation)Session["CertificateLocation"];

            if (certificateLocation.ActionMode == 1) //ADD
                Response.Redirect("LookupTableMaintenance.aspx");
            else
            {
                Response.Redirect(
                    "SearchLookupTableDescriptions.aspx?SelectedItem=" +
                    LookupTables.LookupTables.GetLookupTableIdFromTableName(
                    "CertificateLocation").ToString());
            }
        }

        protected void btnAuditTrail_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (Session["Agent"] != null)
            {
                LookupTables.Agent agent = (LookupTables.Agent)Session["Agent"];
                Response.Redirect("SearchAuditItems.aspx?type=4&agentID=" +
                    agent.AgentID.Trim());
            }
        }

        protected void btnCommission_Click(object sender, System.EventArgs e)
        {
            LookupTables.Agent agent = (LookupTables.Agent)Session["Agent"];
            Response.Redirect("CommissionAgent.aspx?" + agent.AgentID);
        }

        protected void btnPrint_Click(object sender, System.EventArgs e)
        {
            EPolicy2.Reports.AdministrativeTools atreport = new EPolicy2.Reports.AdministrativeTools();
            DataTable dt = atreport.AgentList();

            DataDynamics.ActiveReports.ActiveReport3 rpt = new GeneralList("Agent");

            //rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;

            rpt.DataSource = dt;
            rpt.DataMember = "Report";
            rpt.Run(false);

            Session.Add("Report", rpt);
            Session.Add("FromPage", LookupTables.LookupTables.GetTableMaintenancePathFromTableID(26) + "?item=" + this.lblCertificateID.Text);
            Response.Redirect("ActiveXViewer.aspx", false);
        }

    }
}




