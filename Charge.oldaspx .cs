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

namespace EPolicy
{
    /// <summary>
    /// Summary description for Charge.
    /// </summary>
    public partial class Agent : System.Web.UI.Page
    {
        private Control LeftMenu;

        #region Enumerations

        public enum UserAction { ADD = 1, VIEW = 2, SAVE = 3, EDIT = 4, CANCEL = 5 };

        #endregion


        private void SetChargeNumerationLabel()
        {
            LookupTables.Charge charge=
                (LookupTables.Charge)Session["Charge"];

            this.lblChargeDate.Text = (charge.EffectiveDate.ToString().Trim() != "") ?
                DateTime.Parse(charge.EffectiveDate.ToString().Trim()).ToShortDateString() :
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
                if (!cp.IsInRole("AGENT") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    Response.Redirect("HomePage.aspx?001");
                }
            }

            if (!Page.IsPostBack)
            {
                LookupTables.Charge charge = new LookupTables.Charge();

                if (Request.QueryString["item"] != null &&
                    Request.QueryString["item"].ToString() != String.Empty)
                {
                    try
                    {
                        charge.GetCharge(Request.QueryString["item"].ToString());
                        charge.ActionMode = 2; //UPDATE
                        charge.NavigationViewModelTable =
                            (DataTable)Session["DtRecordsForNonValuePairLookupTable"];
                        Session["Charge"] = charge;
                    }
                    catch (Exception ex)
                    {
                        this.ShowMessage("There is no Charge for the supplied " +
                            "ID. " + ex.Message);
                    }
                }
                else
                {
                    charge.ActionMode = 1; //ADD
                    Session["Charge"] = charge;
                }

            }

            if (Session["Charge"] != null)
            {
                LookupTables.Charge charge =
                    (LookupTables.Charge)Session["Charge"];

                this.InitializeControls();

                switch (charge.ActionMode)
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
            Banner = LoadControl(@"TopBanner.ascx");
            this.Placeholder1.Controls.Add(Banner);

            //Setup Left-side Banner

            LeftMenu = new Control();
            LeftMenu = LoadControl(@"LeftMenu.ascx");
            phTopBanner1.Controls.Add(LeftMenu);
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
            this.btnAuditTrail1.Click += new System.Web.UI.ImageClickEventHandler(this.btnAuditTrail_Click);
            this.BtnExit1.Click += new System.Web.UI.ImageClickEventHandler(this.BtnExit_Click);

        }
        #endregion




        private void InitializeControls()
        {
            this.SetChargeNumerationLabel();
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
                    LookupTables.Charge charge =
                        (LookupTables.Charge)Session["Charge"];
                    if (charge.ActionMode == 0) //ADD
                    {
                        Session["Charge"] = null;
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
                this.txtEffectiveDate.Enabled = true;
                this.txtChargePercent.Enabled = true;
                this.ddlPolicyType.Enabled = true;
                this.chkRenewals.Enabled = true;

            }
            else
            {
                this.txtEffectiveDate.Enabled = false;
                this.txtChargePercent.Enabled = false;
                this.ddlPolicyType.Enabled = false;
                this.chkRenewals.Enabled = false;
            }
        }

        private void FillControls()
        {
            LookupTables.Charge charge =
                (LookupTables.Charge)Session["Charge"];


            this.txtEffectiveDate.Text = (charge.EffectiveDate.ToString() != "" ?
                DateTime.Parse(charge.EffectiveDate.Trim()).ToShortDateString() :
                String.Empty);

            this.txtChargePercent.Text =
                charge.ChargePercent.ToString().Trim();

            if (charge.PolicyType != 0)
                ddlPolicyType.SelectedIndex = ddlPolicyType.Items.IndexOf(
                    ddlPolicyType.Items.FindByValue(charge.PolicyType.ToString()));

                chkRenewals.Checked = charge.RenewalsOnly;
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

            LookupTables.Charge charge =
                (LookupTables.Charge)Session["Charge"];
            try
            {
                switch (charge.ActionMode)
                {
                    case 1: //ADD
                        this.FillProperties(ref charge);
                        charge.Save(userID);
                        break;
                    case 3: //DELETE
                        break;
                    case 4: //CLEAR
                        break;
                    default: //UPDATE
                        this.FillProperties(ref charge);
                        charge.Save(userID);
                        Session["Charge"] = charge;
                        this.SetControlState((int)UserAction.VIEW);
                        break;
                }
                this.litPopUp.Text =
                    Utilities.MakeLiteralPopUpString(
                    "The Charge information was saved successfully.");
                this.litPopUp.Visible = true;
                this.SetChargeNumerationLabel();
                this.SetControlState((int)UserAction.SAVE);

                Session["Charge"] = charge;
            }
            catch (Exception xcp)
            {
                this.ShowMessage("Unable to save or modify Charge. " + xcp.Message);
            }
        }//End BtnSave_Click



        private void ShowMessage(string MessageText)
        {
            this.litPopUp.Text =
                Utilities.MakeLiteralPopUpString(MessageText);
            this.litPopUp.Visible = true;
        }

        private void FillProperties(ref LookupTables.Charge charge)
        {
            charge.EffectiveDate = this.txtEffectiveDate.Text.Trim();
            charge.ChargePercent = float.Parse(this.txtChargePercent.Text.Trim());
            charge.PolicyType = int.Parse(ddlPolicyType.SelectedItem.Value);
            charge.RenewalsOnly = chkRenewals.Checked;
        }



        protected void BtnExit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            LookupTables.Agent agent =
                (LookupTables.Agent)Session["Agent"];

            if (agent.ActionMode == 1) //ADD
                Response.Redirect("LookupTableMaintenance.aspx");
            else
            {
                Response.Redirect(
                    "SearchLookupTableDescriptions.aspx?SelectedItem=" +
                    LookupTables.LookupTables.GetLookupTableIdFromTableName(
                    "Agent").ToString());
            }
        }


        protected void cmdCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            this.SetControlState((int)UserAction.CANCEL);
        }

        protected void btnEdit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            LookupTables.Agent agent =
                (LookupTables.Agent)Session["Agent"];
            agent.ActionMode = 2;
            Session["Agent"] = agent;
            this.SetControlState((int)UserAction.EDIT);
        }

        private bool IsNavigationTableNull()
        {
            LookupTables.Agent agent =
                (LookupTables.Agent)Session["agent"];
            if (agent.NavigationViewModelTable == null)
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
            Response.Redirect("Charge.aspx");
        }

        protected void btnAddNew_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("Charge.aspx");
        }

        protected void btnSearch_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect(
                "SearchLookupTableDescriptions.aspx?SelectedItem=" +
                LookupTables.LookupTables.GetLookupTableIdFromTableName(
                "Charge").ToString());
        }

        protected void btnEdit_Click(object sender, System.EventArgs e)
        {
            LookupTables.Charge charge =
                (LookupTables.Charge)Session["Charge"];
            charge.ActionMode = 2;
            Session["Charge"] = charge;
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

            LookupTables.Charge charge =
                (LookupTables.Charge)Session["Charge"];
            try
            {
                switch (charge.ActionMode)
                {
                    case 1: //ADD
                        this.FillProperties(ref charge);
                        charge.Save(userID);
                        break;
                    case 3: //DELETE
                        break;
                    case 4: //CLEAR
                        break;
                    default: //UPDATE
                        this.FillProperties(ref charge);
                        charge.Save(userID);
                        Session["Charge"] = charge;
                        this.SetControlState((int)UserAction.VIEW);
                        break;
                }
                this.litPopUp.Text =
                    Utilities.MakeLiteralPopUpString(
                    "The Charge information was saved successfully.");
                this.litPopUp.Visible = true;
                this.SetChargeNumerationLabel();
                this.SetControlState((int)UserAction.SAVE);

                Session["Charge"] = charge;
            }
            catch (Exception xcp)
            {
                this.ShowMessage("Unable to save or modify Charge. " + xcp.Message);
            }
        }

        protected void btnSearch_Click(object sender, System.EventArgs e)
        {
            Response.Redirect(
                "SearchLookupTableDescriptions.aspx?SelectedItem=" +
                LookupTables.LookupTables.GetLookupTableIdFromTableName(
                "Charge").ToString());
        }

        protected void cmdCancel_Click(object sender, System.EventArgs e)
        {
            LookupTables.Charge charge = (LookupTables.Charge)Session["Charge"];

            if (charge.ActionMode == 1) //ADD
                Response.Redirect("LookupTableMaintenance.aspx");
            else
            {
                this.SetControlState((int)UserAction.CANCEL);
            }
        }

        protected void btnAuditTrail_Click(object sender, System.EventArgs e)
        {
            if (Session["Charge"] != null)
            {
                LookupTables.Charge charge = (LookupTables.Charge)Session["Charge"];
                Response.Redirect("SearchAuditItems.aspx?type=4&chargeID=" +
                    charge.ChargeID.ToString().Trim());
            }
        }

        protected void BtnExit_Click(object sender, System.EventArgs e)
        {
            LookupTables.Charge charge = (LookupTables.Charge)Session["Charge"];

            if (charge.ActionMode == 1) //ADD
                Response.Redirect("LookupTableMaintenance.aspx");
            else
            {
                Response.Redirect(
                    "SearchLookupTableDescriptions.aspx?SelectedItem=" +
                    LookupTables.LookupTables.GetLookupTableIdFromTableName(
                    "Charge").ToString());
            }
        }
}
}




