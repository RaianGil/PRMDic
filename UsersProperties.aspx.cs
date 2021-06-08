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

namespace EPolicy
{
    /// <summary>
    /// Summary description for UsersProperties.
    /// </summary>
    public partial class UsersProperties : System.Web.UI.Page
    {
        private DataTable DtGroup;
        private DataTable DtDealer;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.litPopUp.Visible = false;

            Login.Login cp = HttpContext.Current.User as Login.Login;
            if (cp == null)
            {
                Response.Redirect("LoginPage.aspx?001");
            }
            else
            {
                if (!cp.IsInRole("USERSPROPERTIES") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    Response.Redirect("LoginPage.aspx?001");
                }
            }

            if (Session["AutoPostBack"] == null)
            {
                if (!IsPostBack)
                {
                    if (Session["Login"] != null)
                    {
                        Login.Login login = (Login.Login)Session["Login"];

                        if (login.Mode == 1)  //ADD
                        {
                            FillTextControl();
                            EnableControls();
                        }
                        else
                        {
                            FillTextControl();
                            DisableControls();
                        }
                    }
                }
                else
                {
                    if (Session["Login"] != null)
                    {
                        Login.Login login = (Login.Login)Session["Login"];
                        if (login.Mode == 4)
                        {
                            DisableControls();
                        }
                    }
                }
            }
            else
            {
                FillTextControl();
                DisableControls();
                Session.Remove("AutoPostBack");
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

            //Setup top Banner
            Control Banner = new Control();
            Banner = LoadControl(@"TopBanner1.ascx");
            this.Placeholder1.Controls.Add(Banner);

            /*//Setup Left-side Banner
            Control LeftMenu = new Control();
            LeftMenu = LoadControl(@"LeftMenu.ascx");
            this.phTopBanner1.Controls.Add(LeftMenu);*/

            //Load DownDropList
            DataTable dtLocation = LookupTables.LookupTables.GetTable("Location");
            DataTable dtDealer = LookupTables.LookupTables.GetTable("CompanyDealer");
            DataTable dtAgent  = LookupTables.LookupTables.GetTable("Agent");
            DataTable dtAgency = LookupTables.LookupTables.GetTable("Agency");

            //Location
            ddlLocation.DataSource = dtLocation;
            ddlLocation.DataTextField = "LocationDesc";
            ddlLocation.DataValueField = "LocationID";
            ddlLocation.DataBind();
            ddlLocation.SelectedIndex = -1;
            ddlLocation.Items.Insert(0, "");

            //Dealer
            ddlDealer.DataSource = dtDealer;
            ddlDealer.DataTextField = "CompanyDealerDesc";
            ddlDealer.DataValueField = "CompanyDealerID";
            ddlDealer.DataBind();
            ddlDealer.SelectedIndex = -1;
            ddlDealer.Items.Insert(0, "");

            //Agent
            ddlAgent.DataSource = dtAgent;
            ddlAgent.DataTextField = "AgentDesc";
            ddlAgent.DataValueField = "AgentID";
            ddlAgent.DataBind();
            ddlAgent.SelectedIndex = -1;
            ddlAgent.Items.Insert(0, "");

            //Agency
            ddlAgency.DataSource = dtAgency;
            ddlAgency.DataTextField = "AgencyDesc";
            ddlAgency.DataValueField = "AgencyID";
            ddlAgency.DataBind();
            ddlAgency.SelectedIndex = -1;
            ddlAgency.Items.Insert(0, "");

            //Dealer2
            ddlDealer2.DataSource = dtDealer;
            ddlDealer2.DataTextField = "CompanyDealerDesc";
            ddlDealer2.DataValueField = "CompanyDealerID";
            ddlDealer2.DataBind();
            ddlDealer2.SelectedIndex = -1;
            ddlDealer2.Items.Insert(0, "");
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataGridGroup.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridGroup_ItemCommand);
            this.dgDealer.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgDealer_ItemCommand);

        }
        #endregion

        private void FillTextControl()
        {
            Login.Login login = (Login.Login)Session["Login"];

            lblUserName.Text = login.FirstName.Trim() + " " + login.LastName.Trim();
            TxtUserName.Text = login.UserName;
            TxtFirstName.Text = login.FirstName;
            txtLastname.Text = login.LastName;
            TxtPassword.Text = login.Password;
            TxtComments.Text = login.Comments;
            TxtConfirmPassword.Text = login.ConfirmPassword;
            ChkAccountDisable.Checked = login.AccountDisable;
            ChkChangePassword.Checked = login.ChangePassword;
            TxtEntryDate.Text = login.EntryDate.ToShortDateString();
            ChkTodoDia.Checked = login.AllDay;

            ChkLunes.Checked = login.Lunes;
            ChkMartes.Checked = login.Martes;
            ChkMiercoles.Checked = login.Miercoles;
            ChkJueves.Checked = login.Jueves;
            ChkViernes.Checked = login.Viernes;
            ChkSabado.Checked = login.Sabado;
            ChkDomingo.Checked = login.Domingo;

            chkAgent.Checked = login.FilterAgent;
            chkDealer.Checked = login.FilterDealer;

            //Location
            ddlLocation.SelectedIndex = 0;
            if (login.LocationID != 0)
            {
                for (int i = 0; ddlLocation.Items.Count - 1 >= i; i++)
                {
                    if (ddlLocation.Items[i].Value == login.LocationID.ToString())
                    {
                        ddlLocation.SelectedIndex = i;
                        i = ddlLocation.Items.Count - 1;
                    }
                }
            }

            //Dealer
            ddlDealer.SelectedIndex = 0;
            if (login.DealerID != "0")
            {
                for (int i = 0; ddlDealer.Items.Count - 1 >= i; i++)
                {
                    if (ddlDealer.Items[i].Value == login.DealerID.ToString())
                    {
                        ddlDealer.SelectedIndex = i;
                        i = ddlDealer.Items.Count - 1;
                    }
                }
            }

            //Agent
            ddlAgent.SelectedIndex = 0;
            if (login.Agent != "000")
            {
                for (int i = 0; ddlAgent.Items.Count - 1 >= i; i++)
                {
                    if (ddlAgent.Items[i].Value == login.Agent.ToString())
                    {
                        ddlAgent.SelectedIndex = i;
                        i = ddlAgent.Items.Count - 1;
                    }
                }
            }

            //Agency
            ddlAgency.SelectedIndex = 0;
            if (login.Agency != "000")
            {
                for (int i = 0; ddlAgency.Items.Count - 1 >= i; i++)
                {
                    if (ddlAgency.Items[i].Value == login.Agency.ToString())
                    {
                        ddlAgency.SelectedIndex = i;
                        i = ddlAgency.Items.Count - 1;
                    }
                }
            }

            //Time1
            ddlTime1.SelectedIndex = 0;
            if (login.Time1 != "")
            {
                for (int i = 0; ddlTime1.Items.Count - 1 >= i; i++)
                {
                    if (ddlTime1.Items[i].Value == login.Time1.ToString())
                    {
                        ddlTime1.SelectedIndex = i;
                        i = ddlTime1.Items.Count - 1;
                    }
                }
            }

            //Time2
            ddlTime2.SelectedIndex = 0;
            if (login.Time2 != "")
            {
                for (int i = 0; ddlTime2.Items.Count - 1 >= i; i++)
                {
                    if (ddlTime2.Items[i].Value == login.Time2.ToString())
                    {
                        ddlTime2.SelectedIndex = i;
                        i = ddlTime2.Items.Count - 1;
                    }
                }
            }

            FillDataGrid();
            FillDataGridDealer();
        }

        private void FillDataGrid()
        {
            Login.Login login = (Login.Login)Session["Login"];

            DataGridGroup.DataSource = null;
            DtGroup = null;

            DtGroup = login.GroupTable;

            Session.Remove("DtGroup");
            Session.Add("DtGroup", DtGroup);

            if (DtGroup != null)
            {
                if (DtGroup.Rows.Count != 0)
                {
                    LblTotalCases.Visible = true;
                    DataGridGroup.DataSource = DtGroup;
                    DataGridGroup.DataBind();
                }
            }
            else
            {
                LblTotalCases.Visible = false;
                DataGridGroup.DataSource = null;
                DataGridGroup.DataBind();
            }
        }

        private void FillDataGridDealer()
        {
            Login.Login login = (Login.Login)Session["Login"];

            dgDealer.DataSource = null;
            DtDealer = null;

            DtDealer = Login.Login.GetGroupDealerByUserID(login.UserID);

            Session.Remove("DtDealer");
            Session.Add("DtDealer", DtDealer);

            if (DtDealer != null)
            {
                if (DtDealer.Rows.Count != 0)
                {
                    LblTotalCases.Visible = true;
                    dgDealer.DataSource = DtDealer;
                    dgDealer.DataBind();
                }
                else
                {
                    LblTotalCases.Visible = false;
                    dgDealer.DataSource = null;
                    dgDealer.DataBind();
                }
            }
            else
            {
                LblTotalCases.Visible = false;
                dgDealer.DataSource = null;
                dgDealer.DataBind();
            }
        }

        private void EnableControls()
        {
            btnEdit.Visible = false;
            btnAdd.Visible = false;
            BtnExit.Visible = false;
            BtnSave.Visible = true;
            btnCancel.Visible = true;
            btnAdd2.Visible = false;

            lblAddDealer.Visible = false;

            TxtUserName.Enabled = true;
            TxtFirstName.Enabled = true;
            txtLastname.Enabled = true;
            TxtPassword.Enabled = true;
            ddlLocation.Enabled = true;
            ddlDealer.Enabled = true;
            ddlAgent.Enabled = true;
            ddlAgency.Enabled = true;
            ddlTime1.Enabled = true;
            ddlTime2.Enabled = true;
            ChkTodoDia.Enabled = true;
            ChkLunes.Enabled = true;
            ChkMartes.Enabled = true;
            ChkMiercoles.Enabled = true;
            ChkJueves.Enabled = true;
            ChkViernes.Enabled = true;
            ChkSabado.Enabled = true;
            ChkDomingo.Enabled = true;
            TxtComments.Enabled = true;
            TxtConfirmPassword.Enabled = true;
            ChkAccountDisable.Enabled = true;
            ChkChangePassword.Enabled = true;
            TxtEntryDate.Enabled = false;
            ddlDealer2.Visible = false;

            chkAgent.Enabled = true;
            chkDealer.Enabled = true;
        }

        private void DisableControls()
        {
            btnEdit.Visible = true;
            btnAdd.Visible = true;
            BtnExit.Visible = true;
            BtnSave.Visible = false;
            btnCancel.Visible = false;
            //btnAdd2.Visible = true;

            //lblAddDealer.Visible = true;

            TxtUserName.Enabled = false;
            TxtFirstName.Enabled = false;
            txtLastname.Enabled = false;
            TxtPassword.Enabled = false;
            ddlLocation.Enabled = false;
            ddlDealer.Enabled = false;
            ddlAgent.Enabled = false;
            ddlAgency.Enabled = false;
            ddlTime1.Enabled = false;
            ddlTime2.Enabled = false;
            ChkTodoDia.Enabled = false;
            ChkLunes.Enabled = false;
            ChkMartes.Enabled = false;
            ChkMiercoles.Enabled = false;
            ChkJueves.Enabled = false;
            ChkViernes.Enabled = false;
            ChkSabado.Enabled = false;
            ChkDomingo.Enabled = false;
            TxtComments.Enabled = false;
            TxtConfirmPassword.Enabled = false;
            ChkAccountDisable.Enabled = false;
            ChkChangePassword.Enabled = false;
            TxtEntryDate.Enabled = false;
            //ddlDealer2.Visible = true;

            chkAgent.Enabled = false;
            chkDealer.Enabled = false;
        }

        protected void btnEdit_Click(object sender, System.EventArgs e)
        {
            Login.Login login = (Login.Login)Session["Login"];
            login.Mode = (int)Login.Login.LoginMode.UPDATE;

            Session.Add("Login", login);

            EnableControls();
        }

        protected void btnCancel_Click(object sender, System.EventArgs e)
        {
            Login.Login login = (Login.Login)Session["Login"];

            if (login.Mode == 1) //ADD
            {
                Session.Clear();
                Response.Redirect("UserPropertiesList.aspx");
            }
            else
            {
                login.Mode = (int)Login.Login.LoginMode.CLEAR;

                int userId = login.UserID;
                login = Login.Login.GetUser(userId);

                Session["Login"] = login;

                FillTextControl();
                DisableControls();
            }
        }

        protected void BtnExit_Click(object sender, System.EventArgs e)
        {
            this.litPopUp.Visible = false;
            Session.Clear();
            Response.Redirect("UserPropertiesList.aspx");
        }

        protected void BtnSave_Click(object sender, System.EventArgs e)
        {
            FillProperties();
            Login.Login login = (Login.Login)Session["Login"];

            try
            {
                Validate();

                if (IsValid)
                {
                    bool password = false;
                    if (TxtPassword.Text.Trim() != "" && TxtConfirmPassword.Text.Trim() != "")
                    {
                        password = true;
                    }
                    else
                    {
                        password = false;
                    }

                    login.Save(password);
                    FillTextControl();
                    DisableControls();


                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Usuario salvado satisfactoriamente.");
                    this.litPopUp.Visible = true;
                }
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("No pudo salvar el usuario. " + exp.Message);
                this.litPopUp.Visible = true;
            }
        }

        private void FillProperties()
        {
            Login.Login login = (Login.Login)Session["Login"];

            login.UserName = TxtUserName.Text.Trim();
            login.FirstName = TxtFirstName.Text.Trim().ToUpper();
            login.LastName = txtLastname.Text.Trim().ToUpper();
            login.Comments = TxtComments.Text.ToString().Trim().ToUpper();
            login.AllDay = ChkTodoDia.Checked;
            login.Lunes = ChkLunes.Checked;
            login.Martes = ChkMartes.Checked;
            login.Miercoles = ChkMiercoles.Checked;
            login.Jueves = ChkJueves.Checked;
            login.Viernes = ChkViernes.Checked;
            login.Sabado = ChkSabado.Checked;
            login.Domingo = ChkDomingo.Checked;
            login.Time1 = this.ddlTime1.SelectedItem.Value != "" ? ddlTime1.SelectedItem.Value : "";
            login.Time2 = this.ddlTime2.SelectedItem.Value != "" ? ddlTime2.SelectedItem.Value : "";
            login.LocationID = this.ddlLocation.SelectedItem.Value != "" ? int.Parse(ddlLocation.SelectedItem.Value) : 0;
            login.DealerID = this.ddlDealer.SelectedItem.Value != "" ? ddlDealer.SelectedItem.Value.ToString() : "000";
            login.Agent = this.ddlAgent.SelectedItem.Value != "" ? ddlAgent.SelectedItem.Value.ToString() : "000";
            login.Agency = this.ddlAgency.SelectedItem.Value != "" ? ddlAgency.SelectedItem.Value.ToString() : "000";

            login.FilterAgent = this.chkAgent.Checked;
            login.FilterDealer = this.chkDealer.Checked;

            if (TxtPassword.Text.Trim() != "")
            {
                string encryptPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(TxtPassword.Text.Trim(), "SHA1");
                string encryptConfirmPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(TxtConfirmPassword.Text.Trim(), "SHA1");

                login.Password = encryptPassword;
                login.ConfirmPassword = encryptConfirmPassword;
            }
            login.AccountDisable = ChkAccountDisable.Checked;
            login.ChangePassword = ChkChangePassword.Checked;

            Session.Add("Login", login);
        }

        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            Session.Clear();

            Login.Login login = new Login.Login();
            login.Mode = (int)Login.Login.LoginMode.ADD;
            Session.Add("Login", login);

            Response.Redirect("UsersProperties.aspx");
        }

        private void ChkTodoDia_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void TxtUserName_TextChanged(object sender, System.EventArgs e)
        {

        }

        protected void btnAdd2_Click(object sender, System.EventArgs e)
        {
            Login.Login login = (Login.Login)Session["Login"];

            try
            {
                if (ddlDealer2.SelectedIndex > 0 && ddlDealer2.SelectedItem != null)
                {
                    login.SaveDealer(login.UserID, ddlDealer2.SelectedItem.Value.ToString());
                    FillTextControl();
                    DisableControls();

                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Dealer saved successfully.");
                    this.litPopUp.Visible = true;
                }
                else
                {
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Must choose one dealer.");
                    this.litPopUp.Visible = true;
                }

            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to save this dealer. " + exp.Message);
                this.litPopUp.Visible = true;
            }
        }
        protected void dgDealer_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    try
                    {
                        Login.Login login = (Login.Login)Session["Login"];
                        login.DeleteGroupDealerByGroupDealerID(int.Parse(e.Item.Cells[3].Text));

                        int mode = login.Mode;
                        login.Mode = (int)Login.Login.LoginMode.CLEAR;

                        login = Login.Login.GetUser(login.UserID);
                        login.Mode = mode;

                        Session["Login"] = login;

                        FillTextControl();

                        this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Dealer " + e.Item.Cells[2].Text + " has been deleted.");
                        this.litPopUp.Visible = true;
                    }
                    catch (Exception exp)
                    {
                        this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                        this.litPopUp.Visible = true;

                    }
                    break;

                default: //Page
                    dgDealer.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                    dgDealer.DataSource = (DataTable)Session["DtDealer"];
                    dgDealer.DataBind();
                    break;
            }
        }
        protected void DataGridGroup_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Select":
                    DataGridPermission.DataSource = null;

                    int i = int.Parse(e.Item.Cells[1].Text);
                    DataTable dtPermission = Login.Login.GetPermissionByGroupID(i);

                    Session.Remove("dtPermission");
                    Session.Add("dtPermission", dtPermission);

                    if (dtPermission.Rows.Count != 0)
                    {
                        DataGridPermission.DataSource = dtPermission;
                        DataGridPermission.DataBind();

                        LblPermissionType.Visible = true;
                        LblPermissionType.Text = "Permission Types: " + e.Item.Cells[2].Text.Trim();
                    }
                    else
                    {
                        LblPermissionType.Visible = false;
                        DataGridPermission.DataSource = null;
                        DataGridPermission.DataBind();
                    }
                    break;

                case "Delete":
                    try
                    {
                        if (e.Item.Cells[2].Text.Trim().ToUpper() == "Users".ToUpper())
                        {
                            throw new Exception("The member Users can not be removed");
                        }

                        Login.Login login = (Login.Login)Session["Login"];
                        login.DeleteAuthenticatedGroupUse(int.Parse(e.Item.Cells[4].Text));

                        int mode = login.Mode;
                        login.Mode = (int)Login.Login.LoginMode.CLEAR;

                        login = Login.Login.GetUser(login.UserID);
                        login.Mode = mode;

                        Session["Login"] = login;

                        FillTextControl();

                        this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Member " + e.Item.Cells[2].Text + " has been deleted.");
                        this.litPopUp.Visible = true;
                    }
                    catch (Exception exp)
                    {
                        this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                        this.litPopUp.Visible = true;

                    }
                    break;

                case "Add":
                    string js = "<script language=javascript> javascript:popwindow=window.open('UserPropertiesGroup.aspx','popwindow','toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,copyhistory=no,width=855,height=675');popwindow.focus(); </script>";
                    Response.Write(js);
                    break;

                default: //Page
                    DataGridPermission.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                    DataGridPermission.DataSource = (DataTable)Session["dtPermission"];
                    DataGridPermission.DataBind();
                    break;
            }
        }
        protected void DataGridPermission_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            DataGridPermission.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

            DataGridPermission.DataSource = (DataTable)Session["dtPermission"];
            DataGridPermission.DataBind();
        }
    }
}
