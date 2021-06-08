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
using EPolicy2.Reports;
using EPolicy.LookupTables;
using EPolicy;
using System.Globalization;
using System.Threading;

public partial class QuoteAspen : System.Web.UI.Page
{
    private Control LeftMenu;
    private static bool sentEmail = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region Web Form Designer generated code
        Control Banner = new Control();
        Banner = LoadControl(@"TopBanner1.ascx");
        //((Baldrich.BaldrichWeb.Components.TopBanner)Banner).SelectedOption = (int)Baldrich.HeadBanner.MenuOptions.Home;
        this.Placeholder1.Controls.Add(Banner);

        //Setup Left-side Banner

        /*LeftMenu = new Control();
        LeftMenu = LoadControl(@"LeftMenu.ascx");
        phTopBanner1.Controls.Add(LeftMenu);*/

        if (!IsPostBack)
        {
            //Esto se hace para cada limite
            //DataTable dtPRMEDICRATE1 = EPolicy.TaskControl.Application.GetPRMEDICRATE(1);
            //DataTable dtPRMEDICRATE2 = EPolicy.TaskControl.Application.GetPRMEDICRATE(2);
            //DataTable dtPRMEDICRATE3 = EPolicy.TaskControl.Application.GetPRMEDICRATE(3);
            //DataTable dtPRMEDICRATE4 = EPolicy.TaskControl.Application.GetPRMEDICRATE(4);
            //DataTable dtPRMEDICRATE5 = EPolicy.TaskControl.Application.GetPRMEDICRATE(5);
            //DataTable dtPRMEDICRATE6 = EPolicy.TaskControl.Application.GetPRMEDICRATE(6);

            DataTable dtStatus = LookupTables.GetTable("STATUS");
            DataTable dtPRMedicalLimit = LookupTables.GetTable("PRMedicalLimit");
            DataTable dtAgency = LookupTables.GetTable("Agency");
            DataTable dtAgent = LookupTables.GetTable("Agent");
            DataTable dtPRPrimaryLimit = LookupTables.GetTable("PRPrimaryLimit");

            //Agency
            ddlAgency.DataSource = dtAgency;
            ddlAgency.DataTextField = "AgencyDesc";
            ddlAgency.DataValueField = "AgencyID";
            ddlAgency.DataBind();
            ddlAgency.SelectedIndex = -1;
            ddlAgency.Items.Insert(0, "");

            //Agent
            ddlAgent.DataSource = dtAgent;
            ddlAgent.DataTextField = "AgentDesc";
            ddlAgent.DataValueField = "AgentID";
            ddlAgent.DataBind();
            ddlAgent.SelectedIndex = -1;
            ddlAgent.Items.Insert(0, "");

            //STATUS
            ddlStatus.DataSource = dtStatus;
            ddlStatus.DataTextField = "StatusDesc";
            ddlStatus.DataValueField = "StatusID";
            ddlStatus.DataBind();
            ddlStatus.SelectedIndex = -1;
            ddlStatus.Items.Insert(0, "");

            //PRMedicalLimit
            ddlLimits.DataSource = dtPRMedicalLimit;
            ddlLimits.DataTextField = "PRMedicalLimitDesc";
            ddlLimits.DataValueField = "PRMedicalLimitID";
            ddlLimits.DataBind();
            ddlLimits.SelectedIndex = -1;
            ddlLimits.Items.Insert(0, "");
            ddlLimits.Items.Remove(ddlLimits.Items.FindByValue("6")); //300,000/1,000,000 Ya no se ofrece.

            ddlLimits2.DataSource = dtPRMedicalLimit;
            ddlLimits2.DataTextField = "PRMedicalLimitDesc";
            ddlLimits2.DataValueField = "PRMedicalLimitID";
            ddlLimits2.DataBind();
            ddlLimits2.SelectedIndex = -1;
            ddlLimits2.Items.Insert(0, "");

            ddlLimits3.DataSource = dtPRMedicalLimit;
            ddlLimits3.DataTextField = "PRMedicalLimitDesc";
            ddlLimits3.DataValueField = "PRMedicalLimitID";
            ddlLimits3.DataBind();
            ddlLimits3.SelectedIndex = -1;
            ddlLimits3.Items.Insert(0, "");

            ddlLimits4.DataSource = dtPRMedicalLimit;
            ddlLimits4.DataTextField = "PRMedicalLimitDesc";
            ddlLimits4.DataValueField = "PRMedicalLimitID";
            ddlLimits4.DataBind();
            ddlLimits4.SelectedIndex = -1;
            ddlLimits4.Items.Insert(0, "");

            ddlLimits5.DataSource = dtPRMedicalLimit;
            ddlLimits5.DataTextField = "PRMedicalLimitDesc";
            ddlLimits5.DataValueField = "PRMedicalLimitID";
            ddlLimits5.DataBind();
            ddlLimits5.SelectedIndex = -1;
            ddlLimits5.Items.Insert(0, "");

            ddlLimits6.DataSource = dtPRMedicalLimit;
            ddlLimits6.DataTextField = "PRMedicalLimitDesc";
            ddlLimits6.DataValueField = "PRMedicalLimitID";
            ddlLimits6.DataBind();
            ddlLimits6.SelectedIndex = -1;
            ddlLimits6.Items.Insert(0, "");

            //PRPrimaryLimit
            ddlPrimaryLimits1.DataSource = dtPRPrimaryLimit;
            ddlPrimaryLimits1.DataTextField = "PRMedicalLimitDesc";
            ddlPrimaryLimits1.DataValueField = "PRMedicalLimitID";
            ddlPrimaryLimits1.DataBind();
            ddlPrimaryLimits1.SelectedIndex = -1;
            ddlPrimaryLimits1.Items.Insert(0, "");
        }
        #endregion

        this.litPopUp.Visible = false;
        this.ddlPolicyClass.Attributes.Add("onchange", "parseRate()");

        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        if (cp == null)
        {
            Response.Redirect("Default.aspx?001");
        }
        else
        {
            if (!cp.IsInRole("APPLICATION") && !cp.IsInRole("ADMINISTRATOR"))
            {
                Response.Redirect("Default.aspx?001");
            }
        }

        btnDelete = EPolicy.Utilities.ConfirmDialogBoxPopUp(btnDelete, "document.Form1", "Do you want delete this application?");

        if (Session["AutoPostBack"] == null)
        {
            if (!IsPostBack)
            {
                if (Session["TaskControl"] != null)
                {
                    EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

                    switch (taskControl.ApplicationMode)
                    {
                        case "ADD":
                            EnableControls();
                            FillTextControl();

                            //EPolicy.Login.Login cp2 = HttpContext.Current.User as EPolicy.Login.Login;
                            int userID = 0;
                            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                            ddlAgency.SelectedIndex = ddlAgency.Items.IndexOf(ddlAgency.Items.FindByValue(EPolicy.Login.Login.GetAgencyByUserID(userID).ToString()));
                            ddlAgent.SelectedIndex = ddlAgent.Items.IndexOf(ddlAgent.Items.FindByValue(EPolicy.Login.Login.GetAgentByUserID(userID).ToString()));

                            rdoMcaInsuranceCia.Items[0].Selected = false;
                            rdoMcaInsuranceCia.Items[1].Selected = false;
                            rdoMcaCertified.Items[0].Selected = false;
                            rdoMcaCertified.Items[1].Selected = false;
                            rdoMcaResTraining.Items[0].Selected = false;
                            rdoMcaResTraining.Items[1].Selected = false;
                            rdoGender.Items[0].Selected = false;
                            rdoGender.Items[1].Selected = false;
                            break;

                        case "UPDATE":
                            FillTextControl();
                            EnableControls();
                            break;

                        default:
                            FillTextControl();
                            DisableControls();
                            break;
                    }
                }
            }
            else
            {
                if (Session["TaskControl"] != null)
                {
                    EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];
                    if (taskControl.Mode == 4)
                    {
                        DisableControls();
                    }
                }
            }
        }
        else
        {
            FillTextControl();
            EnableControls();
            Session.Remove("AutoPostBack");
        }
    }

    #region VerifyAccess
    private void VerifyAccess()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;

        if (!cp.IsInRole("BTNEDITAPPLICATION") && !cp.IsInRole("ADMINISTRATOR"))
        {
            this.btnEdit.Visible = false;
        }
        else
        {
            this.btnEdit.Visible = true;
        }

        if (!cp.IsInRole("BTNCONVERTAPPLICATION") && !cp.IsInRole("ADMINISTRATOR"))
        {
            this.btnConvert.Visible = false;
            this.btnConvertPrimary.Visible = false;
        }
        else
        {
            this.btnConvert.Visible = true;
            this.btnConvertPrimary.Visible = true;
        }

        if (!cp.IsInRole("BTNDELETEAPPLICATION") && !cp.IsInRole("ADMINISTRATOR"))
        {
            this.btnDelete.Visible = false;
        }
        else
        {
            this.btnDelete.Visible = true;
        }

        if (!cp.IsInRole("BTNSAVEAPPLICATION") && !cp.IsInRole("ADMINISTRATOR"))
        {
            this.BtnSave.Visible = false;
        }
        else
        {
            //this.BtnSave.Visible = true;
        }

        if (!cp.IsInRole("BTNCANCELAPPLICATION") && !cp.IsInRole("ADMINISTRATOR"))
        {
            this.btnCancel.Visible = false;
        }
        else
        {
            this.btnCancel.Visible = true;
        }

        if (!cp.IsInRole("APPLICATIONCOMMENTS") && !cp.IsInRole("ADMINISTRATOR"))
        {
            this.txtComments.Visible = false;
            this.TxtCustomerNo.Visible = false;
            this.ddlStatus.Visible = false;
            this.ddlAgency.Visible = false;
            this.ddlAgent.Visible = false;

            this.Label1.Visible = false;
            this.Label50.Visible = false;
            this.Label52.Visible = false;
            this.Label53.Visible = false;
            this.Label48.Visible = false;
        }
        else
        {
            this.txtComments.Visible = true;
            this.TxtCustomerNo.Visible = true;
            this.ddlStatus.Visible = true;
            this.ddlAgency.Visible = true;
            this.ddlAgent.Visible = true;

            this.Label1.Visible = true;
            this.Label50.Visible = true;
            this.Label52.Visible = true;
            this.Label53.Visible = true;
            this.Label48.Visible = true;
        }

        if (!cp.IsInRole("BTNPRINTAPPLICATION") && !cp.IsInRole("ADMINISTRATOR"))
        {
            this.btnPrint.Visible = false;
        }
        else
        {
            this.btnPrint.Visible = true;
        }

    }
    #endregion

    private void FillTextControl()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        int userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

        if (taskControl.Status != 0)
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(
                ddlStatus.Items.FindByValue(taskControl.Status.ToString()));

        if (taskControl.PRMedicalLimitID != 0)
            ddlLimits.SelectedIndex = ddlLimits.Items.IndexOf(
                ddlLimits.Items.FindByValue(taskControl.PRMedicalLimitID.ToString()));

        if (taskControl.PRMedicalLimitID != 0)
        {
            SetDDLLimit(taskControl.PRMedicalLimitID, taskControl.PRPrimaryLimitID);
        }

        if (taskControl.Agency != "0")
            ddlAgency.SelectedIndex = ddlAgency.Items.IndexOf(
                ddlAgency.Items.FindByValue(taskControl.Agency));

        if (taskControl.Agent != "0")
            ddlAgent.SelectedIndex = ddlAgent.Items.IndexOf(
                ddlAgent.Items.FindByValue(taskControl.Agent));

        lblTaskControlID.Text = taskControl.TaskControlID.ToString();
        TxtCustomerNo.Text = taskControl.Customer.CustomerNo;
        TxtFirstName.Text = taskControl.Customer.FirstName;
        TxtInitial.Text = taskControl.Customer.Initial;
        txtLastname1.Text = taskControl.Customer.LastName1;
        txtLastname2.Text = taskControl.Customer.LastName2;
        txtDateBirth.Text = taskControl.Customer.Birthday;
        txtBirthPlace.Text = taskControl.Customer.Description;

        if (taskControl.Customer.Sex == "F")//Female
        {
            rdoGender.Items[0].Selected = true;
            rdoGender.Items[1].Selected = false;
        }
        else
        {
            rdoGender.Items[0].Selected = false;
            rdoGender.Items[1].Selected = true;
        }

        txtSocialSecurity.Text = taskControl.Customer.SocialSecurity;
        TxtAddrs1.Text = taskControl.Customer.Address1;
        TxtAddrs2.Text = taskControl.Customer.Address2;
        TxtCity.Text = taskControl.Customer.City;
        TxtState.Text = taskControl.Customer.State;
        TxtZip.Text = taskControl.Customer.ZipCode;
        txtHomePhone.Text = taskControl.Customer.HomePhone;
        txtWorkPhone.Text = taskControl.Customer.JobPhone;
        TxtCellular.Text = taskControl.Customer.Cellular; //Fax
        txtEmail.Text = taskControl.Customer.Email;
        txtLicense.Text = taskControl.Customer.License;

        txtComments.Text = taskControl.Comments;
        txtPriCarierName1.Text = taskControl.PriCarierName1;
        txtPriPolEffecDate1.Text = taskControl.PriPolEffecDate1;
        txtPriPolLimits1.Text = taskControl.PriPolLimits1;
        txtPriClaims1.Text = taskControl.PriClaims1;
        txtPriCarierName2.Text = taskControl.PriCarierName2;
        txtPriPolEffecDate2.Text = taskControl.PriPolEffecDate2;
        txtPriPolLimits2.Text = taskControl.PriPolLimits2;
        txtPriClaims2.Text = taskControl.PriClaims2;
        txtPriCarierName3.Text = taskControl.PriCarierName3;
        txtPriPolEffecDate3.Text = taskControl.PriPolEffecDate3;
        txtPriPolLimits3.Text = taskControl.PriPolLimits3;
        txtPriClaims3.Text = taskControl.PriClaims3;
        txtExcCarierName1.Text = taskControl.ExcCarierName1;
        txtExcPolEffecDate1.Text = taskControl.ExcPolEffecDate1;
        txtExcPolLimits1.Text = taskControl.ExcPolLimits1;
        txtExcClaims1.Text = taskControl.ExcClaims1;
        txtExcCarierName2.Text = taskControl.ExcCarierName2;
        txtExcPolEffecDate2.Text = taskControl.ExcPolEffecDate2;
        txtExcPolLimits2.Text = taskControl.ExcPolLimits2;
        txtExcClaims2.Text = taskControl.ExcClaims2;
        txtExcCarierName3.Text = taskControl.ExcCarierName3;
        txtExcPolEffecDate3.Text = taskControl.ExcPolEffecDate3;
        txtExcPolLimits3.Text = taskControl.ExcPolLimits3;
        txtExcClaims3.Text = taskControl.ExcClaims3;
        txtInsuranceCiaDesc.Text = taskControl.InsuranceCiaDesc;
        txtMedSchool.Text = taskControl.MedSchool;
        txtMedCity.Text = taskControl.MedCity;
        txtMedFrom.Text = taskControl.MedFrom;
        txtMedDegree.Text = taskControl.MedDegree;
        txtIntSchool.Text = taskControl.IntSchool;
        txtIntCity.Text = taskControl.IntCity;
        txtIntFrom.Text = taskControl.IntFrom;
        txtIntDegree.Text = taskControl.IntDegree;
        txtResSchool.Text = taskControl.ResSchool;
        txtResCity.Text = taskControl.ResCity;
        txtResFrom.Text = taskControl.ResFrom;
        txtResDegree.Text = taskControl.ResDegree;
        txtFellSchool.Text = taskControl.FellSchool;
        txtFellCity.Text = taskControl.FellCity;
        txtFellFrom.Text = taskControl.FellFrom;
        txtFellDegree.Text = taskControl.FellDegree;
        txtOSchool.Text = taskControl.OSchool;
        txtOCity.Text = taskControl.OCity;
        txtOFrom.Text = taskControl.OFrom;
        txtODegree.Text = taskControl.ODegree;
        txtResidency.Text = taskControl.Residency;
        txtPrimaryRetroDate.Text = taskControl.PrimaryRetroDate;
        txtExcessRetroDate.Text = taskControl.ExcessRetroDate;

        if (taskControl.IsPrimary)
        {
            RadioButton1.Checked = true;
            RadioButton2.Checked = false;
        }
        else
        {
            RadioButton1.Checked = false;
            RadioButton2.Checked = true;
        }

        if (taskControl.McaInsuranceCia)
        {
            rdoMcaInsuranceCia.Items[0].Selected = true;
            rdoMcaInsuranceCia.Items[1].Selected = false;
        }
        else
        {
            rdoMcaInsuranceCia.Items[0].Selected = false;
            rdoMcaInsuranceCia.Items[1].Selected = true;
        }

        if (taskControl.McaCertified)
        {
            rdoMcaCertified.Items[0].Selected = true;
            rdoMcaCertified.Items[1].Selected = false;
        }
        else
        {
            rdoMcaCertified.Items[0].Selected = false;
            rdoMcaCertified.Items[1].Selected = true;
        }

        if (taskControl.McaResTraining)
        {
            rdoMcaResTraining.Items[0].Selected = true;
            rdoMcaResTraining.Items[1].Selected = false;
        }
        else
        {
            rdoMcaResTraining.Items[0].Selected = false;
            rdoMcaResTraining.Items[1].Selected = true;
        }

        if (taskControl.PRMEDICRATEID != 0)
        {
            for (int i = 0; i < ddlPolicyClass.Items.Count; i++)
            {
                if (ddlPolicyClass.Items[i].Value.Trim() != "")
                {
                    string[] array = ddlPolicyClass.Items[i].Value.Split('|');
                    if (taskControl.PRMEDICRATEID == int.Parse(array[0]))
                    {
                        ddlPolicyClass.SelectedIndex = ddlPolicyClass.Items.IndexOf(
                        ddlPolicyClass.Items.FindByValue(ddlPolicyClass.Items[i].Value));
                    }
                }
            }
        }

        if (taskControl.PRPrimeryRateID != 0)
        {
            for (int i = 0; i < ddPrimarylPolicyClass.Items.Count; i++)
            {
                if (ddPrimarylPolicyClass.Items[i].Value.Trim() != "")
                {
                    string[] array = ddPrimarylPolicyClass.Items[i].Value.Split('|');
                    if (taskControl.PRPrimeryRateID == int.Parse(array[0]))
                    {
                        ddPrimarylPolicyClass.SelectedIndex = ddPrimarylPolicyClass.Items.IndexOf(
                        ddPrimarylPolicyClass.Items.FindByValue(ddPrimarylPolicyClass.Items[i].Value));
                    }
                }
            }
        }

        HIIsoCode.Value = taskControl.IsoCode;
        HIClass.Value = taskControl.ClassRate;
        HIRate1.Value = taskControl.RateYear1.ToString("###,##0.00");
        HIRate2.Value = taskControl.RateYear2.ToString("###,##0.00");
        HIRate3.Value = taskControl.RateYear3.ToString("###,##0.00");
        HIRate4.Value = taskControl.MCMRate.ToString("###,##0.00");

        txtPrateID.Value = taskControl.PRMEDICRATEID.ToString();
        txtIsoCode.Text = taskControl.IsoCode;
        txtClass.Text = taskControl.ClassRate;
        txtRate1.Text = taskControl.RateYear1.ToString("###,##0.00");
        txtRate2.Text = taskControl.RateYear2.ToString("###,##0.00");
        txtRate3.Text = taskControl.RateYear3.ToString("###,##0.00");
        txtRate4.Text = taskControl.MCMRate.ToString("###,##0.00");

        HIRate12.Value = taskControl.RateYear12.ToString("###,##0.00");
        HIRate22.Value = taskControl.RateYear22.ToString("###,##0.00");
        HIRate32.Value = taskControl.RateYear32.ToString("###,##0.00");
        HIRate42.Value = taskControl.RateYear42.ToString("###,##0.00");
        txtRate12.Text = taskControl.RateYear12.ToString("###,##0.00");
        txtRate22.Text = taskControl.RateYear22.ToString("###,##0.00");
        txtRate32.Text = taskControl.RateYear32.ToString("###,##0.00");
        txtRate42.Text = taskControl.RateYear42.ToString("###,##0.00");

        HIRate13.Value = taskControl.RateYear13.ToString("###,##0.00");
        HIRate23.Value = taskControl.RateYear23.ToString("###,##0.00");
        HIRate33.Value = taskControl.RateYear33.ToString("###,##0.00");
        HIRate43.Value = taskControl.RateYear43.ToString("###,##0.00");
        txtRate13.Text = taskControl.RateYear13.ToString("###,##0.00");
        txtRate23.Text = taskControl.RateYear23.ToString("###,##0.00");
        txtRate33.Text = taskControl.RateYear33.ToString("###,##0.00");
        txtRate43.Text = taskControl.RateYear43.ToString("###,##0.00");

        HIRate14.Value = taskControl.RateYear14.ToString("###,##0.00");
        HIRate24.Value = taskControl.RateYear24.ToString("###,##0.00");
        HIRate34.Value = taskControl.RateYear34.ToString("###,##0.00");
        HIRate44.Value = taskControl.RateYear44.ToString("###,##0.00");
        txtRate14.Text = taskControl.RateYear14.ToString("###,##0.00");
        txtRate24.Text = taskControl.RateYear24.ToString("###,##0.00");
        txtRate34.Text = taskControl.RateYear34.ToString("###,##0.00");
        txtRate44.Text = taskControl.RateYear44.ToString("###,##0.00");

        HIRate15.Value = taskControl.RateYear15.ToString("###,##0.00");
        HIRate25.Value = taskControl.RateYear25.ToString("###,##0.00");
        HIRate35.Value = taskControl.RateYear35.ToString("###,##0.00");
        HIRate45.Value = taskControl.RateYear45.ToString("###,##0.00");
        txtRate15.Text = taskControl.RateYear15.ToString("###,##0.00");
        txtRate25.Text = taskControl.RateYear25.ToString("###,##0.00");
        txtRate35.Text = taskControl.RateYear35.ToString("###,##0.00");
        txtRate45.Text = taskControl.RateYear45.ToString("###,##0.00");

        HIRate16.Value = taskControl.RateYear16.ToString("###,##0.00");
        HIRate26.Value = taskControl.RateYear26.ToString("###,##0.00");
        HIRate36.Value = taskControl.RateYear36.ToString("###,##0.00");
        HIRate46.Value = taskControl.RateYear46.ToString("###,##0.00");
        txtRate16.Text = taskControl.RateYear16.ToString("###,##0.00");
        txtRate26.Text = taskControl.RateYear26.ToString("###,##0.00");
        txtRate36.Text = taskControl.RateYear36.ToString("###,##0.00");
        txtRate46.Text = taskControl.RateYear46.ToString("###,##0.00");

        //Primary
        HIPrimeryRateID.Value = taskControl.PRPrimeryRateID.ToString();
        HIrimeryRate1.Value = taskControl.PRateYear1.ToString("###,##0.00");
        HIrimeryRate2.Value = taskControl.PRateYear2.ToString("###,##0.00");
        HIrimeryRate3.Value = taskControl.PRateYear3.ToString("###,##0.00");
        HIrimeryRate4.Value = taskControl.PRateYear4.ToString("###,##0.00");
        txtPRate1.Text = taskControl.PRateYear1.ToString("###,##0.00");
        txtPRate2.Text = taskControl.PRateYear2.ToString("###,##0.00");
        txtPRate3.Text = taskControl.PRateYear3.ToString("###,##0.00");
        txtPRate4.Text = taskControl.PRateYear4.ToString("###,##0.00");

        if (taskControl.PRMedicalLimit2ID != 0)
            ddlLimits2.SelectedIndex = ddlLimits2.Items.IndexOf(
                ddlLimits2.Items.FindByValue(taskControl.PRMedicalLimit2ID.ToString()));

        if (taskControl.PRMedicalLimit3ID != 0)
            ddlLimits3.SelectedIndex = ddlLimits3.Items.IndexOf(
                ddlLimits3.Items.FindByValue(taskControl.PRMedicalLimit3ID.ToString()));

        if (taskControl.PRMedicalLimit4ID != 0)
            ddlLimits4.SelectedIndex = ddlLimits4.Items.IndexOf(
                ddlLimits4.Items.FindByValue(taskControl.PRMedicalLimit4ID.ToString()));

        if (taskControl.PRMedicalLimit5ID != 0)
            ddlLimits5.SelectedIndex = ddlLimits5.Items.IndexOf(
                ddlLimits5.Items.FindByValue(taskControl.PRMedicalLimit5ID.ToString()));

        if (taskControl.PRMedicalLimit6ID != 0)
            ddlLimits6.SelectedIndex = ddlLimits6.Items.IndexOf(
                ddlLimits6.Items.FindByValue(taskControl.PRMedicalLimit6ID.ToString()));

        if (taskControl.PRPrimaryLimitID != 0)
            ddlPrimaryLimits1.SelectedIndex = ddlPrimaryLimits1.Items.IndexOf(
                ddlPrimaryLimits1.Items.FindByValue(taskControl.PRPrimaryLimitID.ToString()));

        if (taskControl.Mode != 1)
            SetPremiumByRetroDate(taskControl.EntryDate);
    }

    private void EnableControls()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        btnEdit.Visible = false;
        BtnExit.Visible = false;
        btnCancel.Visible = true;
        btnDelete.Visible = false;
        btnPrint.Visible = false;
        btnNextTop.Enabled = true;
        btnNextBottom.Enabled = true;
        btnConvert.Visible = false;
        btnConvertPrimary.Visible = false;
        btnRate.Visible = true;
        BtnSave.Visible = true;

        ddlStatus.Enabled = true;
        ddlAgency.Enabled = true;
        ddlAgent.Enabled = true;
        ddlLimits2.Enabled = false;
        ddlLimits3.Enabled = false;
        ddlLimits4.Enabled = false;
        ddlLimits5.Enabled = false;
        ddlLimits6.Enabled = false;

        ddlPrimaryLimits1.Enabled = true;

        TxtCustomerNo.Enabled = false;
        TxtFirstName.Enabled = true;
        TxtInitial.Enabled = true;
        txtLastname1.Enabled = true;
        txtLastname2.Enabled = true;
        txtDateBirth.Enabled = true;
        txtBirthPlace.Enabled = true;
        TxtAddrs1.Enabled = true;
        TxtAddrs2.Enabled = true;
        TxtCity.Enabled = true;
        TxtState.Enabled = true;
        TxtZip.Enabled = true;
        txtSocialSecurity.Enabled = true;
        txtHomePhone.Enabled = true;
        txtWorkPhone.Enabled = true;
        TxtCellular.Enabled = true;
        txtEmail.Enabled = true;
        txtLicense.Enabled = true;

        txtComments.Enabled = true;
        txtPriCarierName1.Enabled = true;
        txtPriPolEffecDate1.Enabled = true;
        txtPriPolLimits1.Enabled = true;
        txtPriClaims1.Enabled = true;
        txtPriCarierName2.Enabled = true;
        txtPriPolEffecDate2.Enabled = true;
        txtPriPolLimits2.Enabled = true;
        txtPriClaims2.Enabled = true;
        txtPriCarierName3.Enabled = true;
        txtPriPolEffecDate3.Enabled = true;
        txtPriPolLimits3.Enabled = true;
        txtPriClaims3.Enabled = true;
        txtExcCarierName1.Enabled = true;
        txtExcPolEffecDate1.Enabled = true;
        txtExcPolLimits1.Enabled = true;
        txtExcClaims1.Enabled = true;
        txtExcCarierName2.Enabled = true;
        txtExcPolEffecDate2.Enabled = true;
        txtExcPolLimits2.Enabled = true;
        txtExcClaims2.Enabled = true;
        txtExcCarierName3.Enabled = true;
        txtExcPolEffecDate3.Enabled = true;
        txtExcPolLimits3.Enabled = true;
        txtExcClaims3.Enabled = true;
        txtInsuranceCiaDesc.Enabled = true;
        txtMedSchool.Enabled = true;
        txtMedCity.Enabled = true;
        txtMedFrom.Enabled = true;
        txtMedDegree.Enabled = true;
        txtIntSchool.Enabled = true;
        txtIntCity.Enabled = true;
        txtIntFrom.Enabled = true;
        txtIntDegree.Enabled = true;
        txtResSchool.Enabled = true;
        txtResCity.Enabled = true;
        txtResFrom.Enabled = true;
        txtResDegree.Enabled = true;
        txtFellSchool.Enabled = true;
        txtFellCity.Enabled = true;
        txtFellFrom.Enabled = true;
        txtFellDegree.Enabled = true;
        txtOSchool.Enabled = true;
        txtOCity.Enabled = true;
        txtOFrom.Enabled = true;
        txtODegree.Enabled = true;
        txtResidency.Enabled = true;
        rdoMcaInsuranceCia.Enabled = true;
        rdoMcaCertified.Enabled = true;
        rdoMcaResTraining.Enabled = true;
        rdoGender.Enabled = true;

        ddlPolicyClass.Visible = true;

        txtPrimaryRetroDate.Enabled = true;
        txtExcessRetroDate.Enabled = true;

        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;

        if (!cp.IsInRole("APPLICATIONCOMMENTS") && !cp.IsInRole("ADMINISTRATOR"))
        {
            this.txtComments.Visible = false;
            this.TxtCustomerNo.Visible = false;
            this.ddlStatus.Visible = false;
            this.ddlAgency.Visible = false;
            this.ddlAgent.Visible = false;

            this.Label1.Visible = false;
            this.Label50.Visible = false;
            this.Label52.Visible = false;
            this.Label53.Visible = false;
            this.Label48.Visible = false;
        }
        else
        {
            this.txtComments.Visible = true;
            this.TxtCustomerNo.Visible = true;
            this.ddlStatus.Visible = true;
            this.ddlAgency.Visible = true;
            this.ddlAgent.Visible = true;

            this.Label1.Visible = true;
            this.Label50.Visible = true;
            this.Label52.Visible = true;
            this.Label53.Visible = true;
            this.Label48.Visible = true;
        }

        if (!cp.IsInRole("ADMINISTRATOR"))
        {
            this.txtRate1.Enabled = false;
            this.txtRate2.Enabled = false;
            this.txtRate3.Enabled = false;
            this.txtRate4.Enabled = false;

            this.txtPRate1.Enabled = false;
            this.txtPRate2.Enabled = false;
            this.txtPRate3.Enabled = false;
            this.txtPRate4.Enabled = false;
        }
        else
        {
            this.txtRate1.Enabled = true;
            this.txtRate2.Enabled = true;
            this.txtRate3.Enabled = true;
            this.txtRate4.Enabled = true;

            this.txtPRate1.Enabled = true;
            this.txtPRate2.Enabled = true;
            this.txtPRate3.Enabled = true;
            this.txtPRate4.Enabled = true;
        }
    }

    private void DisableControls()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        btnEdit.Visible = true;
        BtnExit.Visible = true;
        btnCancel.Visible = false;
        btnDelete.Visible = true;
        btnPrint.Visible = true;
        btnNextTop.Enabled = true;
        btnNextBottom.Enabled = true;
        btnConvert.Visible = true;
        btnConvertPrimary.Visible = true;
        btnRate.Visible = false;
        BtnSave.Visible = false;

        ddlStatus.Enabled = false;
        ddlAgency.Enabled = false;
        ddlAgent.Enabled = false;
        ddlLimits2.Enabled = false;
        ddlLimits3.Enabled = false;
        ddlLimits4.Enabled = false;
        ddlLimits5.Enabled = false;
        ddlLimits6.Enabled = false;

        ddlLimits6.Enabled = false;

        TxtCustomerNo.Enabled = false;
        TxtFirstName.Enabled = false;
        TxtInitial.Enabled = false;
        txtLastname1.Enabled = false;
        txtLastname2.Enabled = false;
        txtDateBirth.Enabled = false;
        txtBirthPlace.Enabled = false;
        TxtAddrs1.Enabled = false;
        TxtAddrs2.Enabled = false;
        TxtCity.Enabled = false;
        TxtState.Enabled = false;
        TxtZip.Enabled = false;
        txtSocialSecurity.Enabled = false;
        txtHomePhone.Enabled = false;
        txtWorkPhone.Enabled = false;
        TxtCellular.Enabled = false;
        txtEmail.Enabled = false;
        txtLicense.Enabled = false;

        txtComments.Enabled = false;
        txtPriCarierName1.Enabled = false;
        txtPriPolEffecDate1.Enabled = false;
        txtPriPolLimits1.Enabled = false;
        txtPriClaims1.Enabled = false;
        txtPriCarierName2.Enabled = false;
        txtPriPolEffecDate2.Enabled = false;
        txtPriPolLimits2.Enabled = false;
        txtPriClaims2.Enabled = false;
        txtPriCarierName3.Enabled = false;
        txtPriPolEffecDate3.Enabled = false;
        txtPriPolLimits3.Enabled = false;
        txtPriClaims3.Enabled = false;
        txtExcCarierName1.Enabled = false;
        txtExcPolEffecDate1.Enabled = false;
        txtExcPolLimits1.Enabled = false;
        txtExcClaims1.Enabled = false;
        txtExcCarierName2.Enabled = false;
        txtExcPolEffecDate2.Enabled = false;
        txtExcPolLimits2.Enabled = false;
        txtExcClaims2.Enabled = false;
        txtExcCarierName3.Enabled = false;
        txtExcPolEffecDate3.Enabled = false;
        txtExcPolLimits3.Enabled = false;
        txtExcClaims3.Enabled = false;
        txtInsuranceCiaDesc.Enabled = false;
        txtMedSchool.Enabled = false;
        txtMedCity.Enabled = false;
        txtMedFrom.Enabled = false;
        txtMedDegree.Enabled = false;
        txtIntSchool.Enabled = false;
        txtIntCity.Enabled = false;
        txtIntFrom.Enabled = false;
        txtIntDegree.Enabled = false;
        txtResSchool.Enabled = false;
        txtResCity.Enabled = false;
        txtResFrom.Enabled = false;
        txtResDegree.Enabled = false;
        txtFellSchool.Enabled = false;
        txtFellCity.Enabled = false;
        txtFellFrom.Enabled = false;
        txtFellDegree.Enabled = false;
        txtOSchool.Enabled = false;
        txtOCity.Enabled = false;
        txtOFrom.Enabled = false;
        txtODegree.Enabled = false;
        txtResidency.Enabled = false;
        rdoMcaInsuranceCia.Enabled = false;
        rdoMcaCertified.Enabled = false;
        rdoMcaResTraining.Enabled = false;
        rdoGender.Enabled = false;
        txtPrimaryRetroDate.Enabled = true;
        txtExcessRetroDate.Enabled = true;

        VerifyAccess();
    }

    private void RemoveSessionLookUp()
    {
        Session.Remove("LookUpTables");
    }

    protected void btnNextTop_Click(object sender, EventArgs e)
    {
        Save(true);
    }

    protected void btnNextBottom_Click(object sender, EventArgs e)
    {
        Save(true);
    }

    private void Save(bool IsNavigation)
    {
        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
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

        try
        {
            ValidateFields();

            if ((double.Parse(txtRate1.Text.Trim()) == 0.0 || txtRate1.Text.Trim() == "") &&
                (double.Parse(txtPRate1.Text.Trim()) == 0.0 || txtPRate1.Text.Trim() == ""))
            {
                throw new Exception("The Rate is Missing or wrong." + "\r\n");
            }
            if (ddlPolicyClass.SelectedItem.Value.Trim() == "")
            {
                throw new Exception("Please select one Specialty." + "\r\n");
            }

            FillProperties();
            EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];


            taskControl.Save(userID, 1);  //(userID);

            FillTextControl();
            DisableControls();

            Session["TaskControl"] = taskControl;

            if (taskControl.ApplicationMode == "UPDATE")
                taskControl.Prospect.SaveProspect(userID);

            if (taskControl.ApplicationMode == "UPDATE" || taskControl.ApplicationMode == "ADD")
            {
                if (taskControl.ApplicationExist(taskControl.TaskControlID, 2))
                    taskControl.ApplicationMode = "UPDATE";
                else
                    taskControl.ApplicationMode = "ADD";
            }
            else
            {
                if (taskControl.ApplicationExist(taskControl.TaskControlID, 2))
                    taskControl.ApplicationMode = "";
                else
                    taskControl.ApplicationMode = "ADD";
            }



            this.HIState.Value = "0";

            if (IsNavigation)
            {
                Response.Redirect("Application2.aspx", false);
            }
            else
            {
                taskControl.ApplicationMode = "";
                Response.Redirect("QuoteAspen.aspx", false);
            }
            //this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Information saved successfully.");
            //this.litPopUp.Visible = true;
        }
        catch (Exception exp)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Unable to save this Information. " + exp.Message);
            this.litPopUp.Visible = true;
        }
    }

    private void ValidateFields()
    {
        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        int userID = 0;
        userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

        ArrayList errorMessages = new ArrayList();

        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        try
        {
            if (TxtFirstName.Text.Trim() == "")
            {
                errorMessages.Add("The Firstname is Missing or wrong." + "\r\n");
            }

            if (txtLastname1.Text.Trim() == "")
            {
                errorMessages.Add("The Firstname is Missing or wrong." + "\r\n");
            }

            //if (txtDateBirth.Text.Trim() == "")
            //{
            //    errorMessages.Add("The Date of Birthday is Missing or wrong." + "\r\n");
            //}

            //if (TxtAddrs1.Text.Trim() == "")
            //{
            //    errorMessages.Add("The Address is Missing or wrong." + "\r\n");
            //}

            //if (TxtCity.Text.Trim() == "")
            //{
            //    errorMessages.Add("The City is Missing or wrong." + "\r\n");
            //}

            if (txtHomePhone.Text.Trim() == "" && txtWorkPhone.Text.Trim() == "")
            {
                errorMessages.Add("The Work Phone or Cell Phone is Missing or wrong, please fill one." + "\r\n");
            }

            if (txtPrimaryRetroDate.Text.Trim() == "")
            {
                errorMessages.Add("The Primary Retro Date is Missing or wrong." + "\r\n");
            }

            if (txtExcessRetroDate.Text.Trim() == "")
            {
                errorMessages.Add("The Escess Retro Date is Missing or wrong." + "\r\n");
            }

            //if (txtWorkPhone.Text.Trim() == "")
            //{
            //    errorMessages.Add("The Work Phone is Missing or wrong." + "\r\n");
            //}

            //if (txtEmail.Text.Trim() == "")
            //{
            //    errorMessages.Add("The email is Missing or wrong." + "\r\n");
            //}


            if (ddlAgency.SelectedItem.Value.Trim() == "")
                errorMessages.Add("Please choose a agency." + "\r\n");

            if (ddlAgency.SelectedItem.Value.Trim() == "000")
                errorMessages.Add("Please choose a agency." + "\r\n");


            if (errorMessages.Count > 0)
            {
                string popUpString = "";

                foreach (string message in errorMessages)
                {
                    popUpString += message + " ";
                }

                throw new Exception(popUpString);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private void FillProperties()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        //Properties For Application1
        if (taskControl.Mode == 1)
        {
            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
            taskControl.EnteredBy = cp.Identity.Name.Split("|".ToCharArray())[0];
        }

        //Status
        if (ddlStatus.SelectedIndex > 0 && ddlStatus.SelectedItem != null)
            taskControl.Status = int.Parse(ddlStatus.SelectedItem.Value);
        else
            taskControl.Status = 0;

        //Agency
        if (ddlAgency.SelectedIndex > 0 && ddlAgency.SelectedItem != null)
            taskControl.Agency = ddlAgency.SelectedItem.Value;
        else
            taskControl.Agency = "000";

        //Agent
        if (ddlAgent.SelectedIndex > 0 && ddlAgent.SelectedItem != null)
            taskControl.Agent = ddlAgent.SelectedItem.Value;
        else
            taskControl.Agent = "000";

        //PrMedicalLimits
        if (ddlLimits.SelectedIndex > 0 && ddlLimits.SelectedItem != null)
        {
            taskControl.PRMedicalLimitID = int.Parse(ddlLimits.SelectedItem.Value.ToString());
        }

        //PrMedicalLimits
        if (ddlPrimaryLimits1.SelectedIndex > 0 && ddlPrimaryLimits1.SelectedItem != null)
        {
            taskControl.PRPrimaryLimitID = int.Parse(ddlPrimaryLimits1.SelectedItem.Value.ToString());
        }

        taskControl.Customer.CustomerNo = TxtCustomerNo.Text.Trim().ToUpper();
        taskControl.Customer.FirstName = TxtFirstName.Text.Trim().ToUpper();
        taskControl.Customer.Initial = TxtInitial.Text.Trim().ToUpper();
        taskControl.Customer.LastName1 = txtLastname1.Text.Trim().ToUpper();
        taskControl.Customer.LastName2 = txtLastname2.Text.Trim().ToUpper();
        taskControl.Customer.Birthday = txtDateBirth.Text;
        taskControl.Customer.Description = txtBirthPlace.Text.Trim().ToUpper(); ;

        if (rdoGender.Items[0].Selected)
        {
            taskControl.Customer.Sex = "F";
        }
        else
        {
            taskControl.Customer.Sex = "M";
        }

        taskControl.Customer.Address1 = TxtAddrs1.Text.Trim().ToUpper();
        taskControl.Customer.Address2 = TxtAddrs2.Text.Trim().ToUpper();
        taskControl.Customer.City = TxtCity.Text.Trim().ToUpper();
        taskControl.Customer.State = TxtState.Text.Trim().ToUpper();
        taskControl.Customer.ZipCode = TxtZip.Text.Trim().ToUpper();
        taskControl.Customer.SocialSecurity = txtSocialSecurity.Text.Trim().ToUpper();
        taskControl.Customer.HomePhone = txtHomePhone.Text.Trim().ToUpper();
        taskControl.Customer.JobPhone = txtWorkPhone.Text.Trim().ToUpper();
        taskControl.Customer.Cellular = TxtCellular.Text.Trim().ToUpper();
        taskControl.Customer.Email = txtEmail.Text.Trim().ToUpper();
        taskControl.Customer.License = txtLicense.Text.Trim();

        taskControl.Comments = txtComments.Text.Trim().ToUpper();
        taskControl.PriCarierName1 = txtPriCarierName1.Text.Trim().ToUpper();
        taskControl.PriPolEffecDate1 = txtPriPolEffecDate1.Text.Trim().ToUpper();
        taskControl.PriPolLimits1 = txtPriPolLimits1.Text.Trim().ToUpper();
        taskControl.PriClaims1 = txtPriClaims1.Text.Trim().ToUpper();
        taskControl.PriCarierName2 = txtPriCarierName2.Text.Trim().ToUpper();
        taskControl.PriPolEffecDate2 = txtPriPolEffecDate2.Text.Trim().ToUpper();
        taskControl.PriPolLimits2 = txtPriPolLimits2.Text.Trim().ToUpper();
        taskControl.PriClaims2 = txtPriClaims2.Text.Trim().ToUpper();
        taskControl.PriCarierName3 = txtPriCarierName3.Text.Trim().ToUpper();
        taskControl.PriPolEffecDate3 = txtPriPolEffecDate3.Text.Trim().ToUpper();
        taskControl.PriPolLimits3 = txtPriPolLimits3.Text.Trim().ToUpper();
        taskControl.PriClaims3 = txtPriClaims3.Text.Trim().ToUpper();
        taskControl.ExcCarierName1 = txtExcCarierName1.Text.Trim().ToUpper();
        taskControl.ExcPolEffecDate1 = txtExcPolEffecDate1.Text.Trim().ToUpper();
        taskControl.ExcPolLimits1 = txtExcPolLimits1.Text.Trim().ToUpper();
        taskControl.ExcClaims1 = txtExcClaims1.Text.Trim().ToUpper();
        taskControl.ExcCarierName2 = txtExcCarierName2.Text.Trim().ToUpper();
        taskControl.ExcPolEffecDate2 = txtExcPolEffecDate2.Text.Trim().ToUpper();
        taskControl.ExcPolLimits2 = txtExcPolLimits2.Text.Trim().ToUpper();
        taskControl.ExcClaims2 = txtExcClaims2.Text.Trim().ToUpper();
        taskControl.ExcCarierName3 = txtExcCarierName3.Text.Trim().ToUpper();
        taskControl.ExcPolEffecDate3 = txtExcPolEffecDate3.Text.Trim().ToUpper();
        taskControl.ExcPolLimits3 = txtExcPolLimits3.Text.Trim().ToUpper();
        taskControl.ExcClaims3 = txtExcClaims3.Text.Trim().ToUpper();
        taskControl.InsuranceCiaDesc = txtInsuranceCiaDesc.Text.Trim().ToUpper();
        taskControl.MedSchool = txtMedSchool.Text.Trim().ToUpper();
        taskControl.MedCity = txtMedCity.Text.Trim().ToUpper();
        taskControl.MedFrom = txtMedFrom.Text.Trim().ToUpper();
        taskControl.MedDegree = txtMedDegree.Text.Trim().ToUpper();
        taskControl.IntSchool = txtIntSchool.Text.Trim().ToUpper();
        taskControl.IntCity = txtIntCity.Text.Trim().ToUpper();
        taskControl.IntFrom = txtIntFrom.Text.Trim().ToUpper();
        taskControl.IntDegree = txtIntDegree.Text.Trim().ToUpper();
        taskControl.ResSchool = txtResSchool.Text.Trim().ToUpper();
        taskControl.ResCity = txtResCity.Text.Trim().ToUpper();
        taskControl.ResFrom = txtResFrom.Text.Trim().ToUpper();
        taskControl.ResDegree = txtResDegree.Text.Trim().ToUpper();
        taskControl.FellSchool = txtFellSchool.Text.Trim().ToUpper();
        taskControl.FellCity = txtFellCity.Text.Trim().ToUpper();
        taskControl.FellFrom = txtFellFrom.Text.Trim().ToUpper();
        taskControl.FellDegree = txtFellDegree.Text.Trim().ToUpper();
        taskControl.OSchool = txtOSchool.Text.Trim().ToUpper();
        taskControl.OCity = txtOCity.Text.Trim().ToUpper();
        taskControl.OFrom = txtOFrom.Text.Trim().ToUpper();
        taskControl.ODegree = txtODegree.Text.Trim().ToUpper();
        taskControl.Residency = txtResidency.Text.Trim().ToUpper();

        if (RadioButton1.Checked)
        {
            taskControl.IsPrimary = true;
        }
        else
        {
            taskControl.IsPrimary = false;
        }

        if (rdoMcaInsuranceCia.Items[0].Selected)
        {
            taskControl.McaInsuranceCia = true;
        }
        else
        {
            taskControl.McaInsuranceCia = false;
        }

        if (rdoMcaCertified.Items[0].Selected)
        {
            taskControl.McaCertified = true;
        }
        else
        {
            taskControl.McaCertified = false;
        }

        if (rdoMcaResTraining.Items[0].Selected)
        {
            taskControl.McaResTraining = true;
        }
        else
        {
            taskControl.McaResTraining = false;
        }

        taskControl.IsoCode = HIIsoCode.Value.ToUpper().Trim();
        taskControl.ClassRate = HIClass.Value.ToUpper().Trim();


        // Si hay cambio de prima manual set la variable para que la carge con la prima
        // que se entro manualmente.
        if (HIRate1.Value.Trim() != txtRate1.Text.Trim())
        {
            HIRate1.Value = txtRate1.Text.Trim();
        }
        if (HIRate2.Value.Trim() != txtRate2.Text.Trim())
        {
            HIRate2.Value = txtRate2.Text.Trim();
        }
        if (HIRate3.Value.Trim() != txtRate3.Text.Trim())
        {
            HIRate3.Value = txtRate3.Text.Trim();
        }
        if (HIRate4.Value.Trim() != txtRate4.Text.Trim())
        {
            HIRate4.Value = txtRate4.Text.Trim();
        }
        /////////////////

        if (HIRate1.Value.Trim() == "")
            taskControl.RateYear1 = 0.00;
        else
            taskControl.RateYear1 = double.Parse(HIRate1.Value);

        if (HIRate2.Value.Trim() == "")
            taskControl.RateYear2 = 0.00;
        else
            taskControl.RateYear2 = double.Parse(HIRate2.Value);

        if (HIRate3.Value.Trim() == "")
            taskControl.RateYear3 = 0.00;
        else
            taskControl.RateYear3 = double.Parse(HIRate3.Value);

        if (HIRate4.Value.Trim() == "")
            taskControl.MCMRate = 0.00;
        else
            taskControl.MCMRate = double.Parse(HIRate4.Value);

        if (txtPrateID.Value.Trim() != "")
        {
            taskControl.PRMEDICRATEID = int.Parse(txtPrateID.Value);
        }
        else
            taskControl.PRMEDICRATEID = 0;


        if (HIRate12.Value.Trim() == "")
            taskControl.RateYear12 = 0.00;
        else
            taskControl.RateYear12 = double.Parse(HIRate12.Value);

        if (HIRate22.Value.Trim() == "")
            taskControl.RateYear22 = 0.00;
        else
            taskControl.RateYear22 = double.Parse(HIRate22.Value);

        if (HIRate32.Value.Trim() == "")
            taskControl.RateYear32 = 0.00;
        else
            taskControl.RateYear32 = double.Parse(HIRate32.Value);

        if (HIRate42.Value.Trim() == "")
            taskControl.RateYear42 = 0.00;
        else
            taskControl.RateYear42 = double.Parse(HIRate42.Value);

        if (ddlLimits2.SelectedIndex > 0 && ddlLimits2.SelectedItem != null)
            taskControl.PRMedicalLimit2ID = int.Parse(ddlLimits2.SelectedItem.Value.ToString());
        else
            taskControl.PRMedicalLimit2ID = 0;


        if (HIRate13.Value.Trim() == "")
            taskControl.RateYear13 = 0.00;
        else
            taskControl.RateYear13 = double.Parse(HIRate13.Value);

        if (HIRate23.Value.Trim() == "")
            taskControl.RateYear23 = 0.00;
        else
            taskControl.RateYear23 = double.Parse(HIRate23.Value);

        if (HIRate33.Value.Trim() == "")
            taskControl.RateYear33 = 0.00;
        else
            taskControl.RateYear33 = double.Parse(HIRate33.Value);

        if (HIRate43.Value.Trim() == "")
            taskControl.RateYear43 = 0.00;
        else
            taskControl.RateYear43 = double.Parse(HIRate43.Value);

        if (ddlLimits3.SelectedIndex > 0 && ddlLimits3.SelectedItem != null)
            taskControl.PRMedicalLimit3ID = int.Parse(ddlLimits3.SelectedItem.Value.ToString());
        else
            taskControl.PRMedicalLimit3ID = 0;

        if (HIRate14.Value.Trim() == "")
            taskControl.RateYear14 = 0.00;
        else
            taskControl.RateYear14 = double.Parse(HIRate14.Value);

        if (HIRate24.Value.Trim() == "")
            taskControl.RateYear24 = 0.00;
        else
            taskControl.RateYear24 = double.Parse(HIRate24.Value);

        if (HIRate34.Value.Trim() == "")
            taskControl.RateYear34 = 0.00;
        else
            taskControl.RateYear34 = double.Parse(HIRate34.Value);

        if (HIRate44.Value.Trim() == "")
            taskControl.RateYear44 = 0.00;
        else
            taskControl.RateYear44 = double.Parse(HIRate44.Value);

        if (ddlLimits4.SelectedIndex > 0 && ddlLimits4.SelectedItem != null)
            taskControl.PRMedicalLimit4ID = int.Parse(ddlLimits4.SelectedItem.Value.ToString());
        else
            taskControl.PRMedicalLimit4ID = 0;

        if (HIRate15.Value.Trim() == "")
            taskControl.RateYear15 = 0.00;
        else
            taskControl.RateYear15 = double.Parse(HIRate15.Value);

        if (HIRate25.Value.Trim() == "")
            taskControl.RateYear25 = 0.00;
        else
            taskControl.RateYear25 = double.Parse(HIRate25.Value);

        if (HIRate35.Value.Trim() == "")
            taskControl.RateYear35 = 0.00;
        else
            taskControl.RateYear35 = double.Parse(HIRate35.Value);

        if (HIRate45.Value.Trim() == "")
            taskControl.RateYear45 = 0.00;
        else
            taskControl.RateYear45 = double.Parse(HIRate45.Value);

        if (ddlLimits5.SelectedIndex > 0 && ddlLimits5.SelectedItem != null)
            taskControl.PRMedicalLimit5ID = int.Parse(ddlLimits5.SelectedItem.Value.ToString());
        else
            taskControl.PRMedicalLimit5ID = 0;

        if (HIRate16.Value.Trim() == "")
            taskControl.RateYear16 = 0.00;
        else
            taskControl.RateYear16 = double.Parse(HIRate16.Value);

        if (HIRate26.Value.Trim() == "")
            taskControl.RateYear26 = 0.00;
        else
            taskControl.RateYear26 = double.Parse(HIRate26.Value);

        if (HIRate36.Value.Trim() == "")
            taskControl.RateYear36 = 0.00;
        else
            taskControl.RateYear36 = double.Parse(HIRate36.Value);

        if (HIRate46.Value.Trim() == "")
            taskControl.RateYear46 = 0.00;
        else
            taskControl.RateYear46 = double.Parse(HIRate46.Value);

        if (ddlLimits6.SelectedIndex > 0 && ddlLimits6.SelectedItem != null)
            taskControl.PRMedicalLimit6ID = int.Parse(ddlLimits6.SelectedItem.Value.ToString());
        else
            taskControl.PRMedicalLimit6ID = 0;

        ///Primary
        if (HIPrimeryRateID.Value.Trim() != "")
        {
            taskControl.PRPrimeryRateID = int.Parse(HIPrimeryRateID.Value);
        }
        else
            taskControl.PRPrimeryRateID = 0;

        if (HIrimeryRate1.Value.Trim() == "")
            taskControl.PRateYear1 = 0.00;
        else
            taskControl.PRateYear1 = double.Parse(HIrimeryRate1.Value);

        if (HIrimeryRate2.Value.Trim() == "")
            taskControl.PRateYear2 = 0.00;
        else
            taskControl.PRateYear2 = double.Parse(HIrimeryRate2.Value);

        if (HIrimeryRate3.Value.Trim() == "")
            taskControl.PRateYear3 = 0.00;
        else
            taskControl.PRateYear3 = double.Parse(HIrimeryRate3.Value);

        if (HIrimeryRate4.Value.Trim() == "")
            taskControl.PRateYear4 = 0.00;
        else
            taskControl.PRateYear4 = double.Parse(HIrimeryRate4.Value);

        if (ddlPrimaryLimits1.SelectedIndex > 0 && ddlPrimaryLimits1.SelectedItem != null)
            taskControl.PRPrimaryLimitID = int.Parse(ddlPrimaryLimits1.SelectedItem.Value.ToString());
        else
            taskControl.PRPrimaryLimitID = 0;

        taskControl.PrimaryRetroDate = txtPrimaryRetroDate.Text.Trim();
        taskControl.ExcessRetroDate = txtExcessRetroDate.Text.Trim();

        Session["TaskControl"] = taskControl;
    }

    protected void BtnExit_Click(object sender, EventArgs e)
    {
        RemoveSessionLookUp();
        this.litPopUp.Visible = false;
        Session.Clear();
        Response.Redirect("MainMenu.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];
        try
        {
            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
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

            this.HIState.Value = "0";
            if (taskControl.TaskControlID == 0) //ADD
            {
                Session.Clear();
                Response.Redirect("MainMenu.aspx");
            }
            else
            {
                taskControl = (EPolicy.TaskControl.Application)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControl.TaskControlID, userID);
                taskControl.Mode = (int)EPolicy.TaskControl.TaskControl.TaskControlMode.CLEAR;
                Session["TaskControl"] = taskControl;
                FillTextControl();
                DisableControls();
            }
        }
        catch (Exception exp)
        {
            //if (exp.InnerException == null)
            //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
            //else if (exp.InnerException.InnerException == null)
            //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
            //else
            //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
            //         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

            this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
            this.litPopUp.Visible = true;
        }

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        DataDynamics.ActiveReports.ActiveReport3 rpt = null;

        rpt = new EPolicy2.Reports.PRMdic.PrmdicQuotes(taskControl);
        rpt.Document.Printer.PrinterName = "";
        rpt.Run();

        RemoveSessionLookUp();
        Session.Add("Report", rpt);
        Session.Add("FromPage", "Application1.aspx");
        Response.Redirect("ActiveXViewer.aspx");


        //DataTable dtPRMEDICRATE1 = EPolicy.LookupTables.LookupTables.GetTable("PRMEDICSpecialty");


        //DataDynamics.ActiveReports.ActiveReport3[] rpt = new DataDynamics.ActiveReports.ActiveReport3[dtPRMEDICRATE1.Rows.Count];
        //for (int i = 0; i < dtPRMEDICRATE1.Rows.Count; i++)
        //{
        //    EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];
        //    DataTable dt = EPolicy.TaskControl.Application.GetPRMEDICRATEByPRMEDICRATEID(int.Parse(dtPRMEDICRATE1.Rows[i]["PRMEDICRATEID"].ToString()));
        //    taskControl.Customer.FirstName = dtPRMEDICRATE1.Rows[i]["PRMEDICRATEDesc"].ToString();
        //    taskControl.Customer.LastName1 = "";
        //    taskControl.Customer.LastName2 = "";
        //    GetAllRates();
        //    taskControl.IsoCode = dt.Rows[0]["ISOCode"].ToString();

        //    rpt[i] = new EPolicy2.Reports.PRMdic.PrmdicQuotes(taskControl);
        //    rpt[i].Document.Printer.PrinterName = "";
        //    rpt[i].Run();

        //    if (i > 0)
        //        rpt[0].Document.Pages.InsertRange(rpt[0].Document.Pages.Count, rpt[i].Document.Pages);
        //}

        //RemoveSessionLookUp();
        //Session.Add("Report", rpt[0]);
        //Session.Add("FromPage", "Application1.aspx");
        //Response.Redirect("ActiveXViewer.aspx");

        //DataDynamics.ActiveReports.ActiveReport3 rpt = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt1 = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt3 = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt4 = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt5 = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt6 = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt7 = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt8 = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt9 = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt10 = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt11 = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt12 = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt13 = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt14 = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt15 = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt16 = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt17 = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt18 = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt19 = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt20 = null;

        //rpt1 = new EPolicy2.Reports.PRMdic.Solicitud1(taskControl);
        //rpt1.Document.Printer.PrinterName = "";
        //rpt1.Run();
        //rpt = rpt1;

        //rpt2 = new EPolicy2.Reports.PRMdic.Solicitud2(taskControl);
        //rpt2.Document.Printer.PrinterName = "";
        //rpt2.Run(false);
        //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages);

        //rpt3 = new EPolicy2.Reports.PRMdic.Solicitud3(taskControl);
        //rpt3.Document.Printer.PrinterName = "";
        //rpt3.Run(false);
        //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages);

        //rpt4 = new EPolicy2.Reports.PRMdic.Solicitud4(taskControl);
        //rpt4.Document.Printer.PrinterName = "";
        //rpt4.Run(false);
        //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt4.Document.Pages);

        //rpt5 = new EPolicy2.Reports.PRMdic.Solicitud5(taskControl);
        //rpt5.Document.Printer.PrinterName = "";
        //rpt5.Run(false);
        //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt5.Document.Pages);

        //rpt6 = new EPolicy2.Reports.PRMdic.Solicitud6(taskControl);
        //rpt6.Document.Printer.PrinterName = "";
        //rpt6.Run(false);
        //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt6.Document.Pages);

        //rpt7 = new EPolicy2.Reports.PRMdic.Solicitud7(taskControl);
        //rpt7.Document.Printer.PrinterName = "";
        //rpt7.Run(false);
        //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt7.Document.Pages);

        //rpt8 = new EPolicy2.Reports.PRMdic.Solicitud8(taskControl);
        //rpt8.Document.Printer.PrinterName = "";
        //rpt8.Run(false);
        //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt8.Document.Pages);

        //rpt9 = new EPolicy2.Reports.PRMdic.Solicitud9(taskControl);
        //rpt9.Document.Printer.PrinterName = "";
        //rpt9.Run(false);
        //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt9.Document.Pages);

        //rpt10 = new EPolicy2.Reports.PRMdic.Solicitud10(taskControl);
        //rpt10.Document.Printer.PrinterName = "";
        //rpt10.Run(false);
        //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt10.Document.Pages);

        //rpt11 = new EPolicy2.Reports.PRMdic.Solicitud11(taskControl);
        //rpt11.Document.Printer.PrinterName = "";
        //rpt11.Run(false);
        //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt11.Document.Pages);

        //rpt12 = new EPolicy2.Reports.PRMdic.Solicitud12(taskControl);
        //rpt12.Document.Printer.PrinterName = "";
        //rpt12.Run(false);
        //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt12.Document.Pages);

        //rpt13 = new EPolicy2.Reports.PRMdic.Solicitud13(taskControl);
        //rpt13.Document.Printer.PrinterName = "";
        //rpt13.Run(false);
        //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt13.Document.Pages);

        //rpt14 = new EPolicy2.Reports.PRMdic.Solicitud14(taskControl);
        //rpt14.Document.Printer.PrinterName = "";
        //rpt14.Run(false);
        //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt14.Document.Pages);

        //rpt15 = new EPolicy2.Reports.PRMdic.Solicitud15(taskControl);
        //rpt15.Document.Printer.PrinterName = "";
        //rpt15.Run(false);
        //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt15.Document.Pages);

        //rpt16 = new EPolicy2.Reports.PRMdic.Solicitud16(taskControl);
        //rpt16.Document.Printer.PrinterName = "";
        //rpt16.Run(false);
        //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt16.Document.Pages);

        //rpt17 = new EPolicy2.Reports.PRMdic.Solicitud17(taskControl);
        //rpt17.Document.Printer.PrinterName = "";
        //rpt17.Run(false);
        //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt17.Document.Pages);

        //rpt18 = new EPolicy2.Reports.PRMdic.Solicitud18(taskControl);
        //rpt18.Document.Printer.PrinterName = "";
        //rpt18.Run(false);
        //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt18.Document.Pages);

        //rpt19 = new EPolicy2.Reports.PRMdic.Solicitud19(taskControl);
        //rpt19.Document.Printer.PrinterName = "";
        //rpt19.Run(false);
        //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt19.Document.Pages);

        //rpt20 = new EPolicy2.Reports.PRMdic.Solicitud20(taskControl);
        //rpt20.Document.Printer.PrinterName = "";
        //rpt20.Run(false);
        //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt20.Document.Pages);

        //RemoveSessionLookUp();
        //Session.Add("Report", rpt);
        //Session.Add("FromPage", "Application1.aspx");
        //Response.Redirect("ActiveXViewer.aspx");
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];
        FillTextControl();
        taskControl.Mode = (int)EPolicy.TaskControl.TaskControl.TaskControlMode.UPDATE;

        taskControl.ApplicationMode = "UPDATE";

        Session.Add("TaskControl", taskControl);
        //this.HIState.Value = "1";
        EnableControls();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //if (bool.Parse(ConfirmDialogBoxPopUp.Value.Trim()) == true)
        //{
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];
        try
        {
            int i = taskControl.TaskControlID;
            EPolicy.TaskControl.Application.DeleteApplicationByTaskControlID(i);

            taskControl = new EPolicy.TaskControl.Application();
            taskControl.Mode = 4; //Clear

            Session["TaskControl"] = taskControl;
            Session.Clear();
            Response.Redirect("MainMenu.aspx");
        }
        catch (Exception exp)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("" + exp.Message);
            this.litPopUp.Visible = true;
        }
        //}
    }
    protected void btnConvert_Click(object sender, EventArgs e)
    {
        EPolicy.TaskControl.Application taskControlQuote = (EPolicy.TaskControl.Application)Session["TaskControl"];
        EPolicy.TaskControl.Policies taskControl = new EPolicy.TaskControl.Policies();

        taskControl.Mode = 1; //ADD
        taskControl.PolicyClassID = 9;

        taskControl.Agency = taskControlQuote.Agency;
        taskControl.Agent = taskControlQuote.Agent;

        taskControl.Customer.ProspectID = taskControlQuote.Prospect.ProspectID;
        taskControl.Customer.CustomerNo = taskControlQuote.Customer.CustomerNo;
        taskControl.Customer.FirstName = taskControlQuote.Customer.FirstName;
        taskControl.Customer.Initial = taskControlQuote.Customer.Initial;
        taskControl.Customer.LastName1 = taskControlQuote.Customer.LastName1;
        taskControl.Customer.LastName2 = taskControlQuote.Customer.LastName2;
        taskControl.Customer.Birthday = taskControlQuote.Customer.Birthday;
        taskControl.Customer.Description = taskControlQuote.Customer.Description;
        taskControl.Customer.Sex = taskControlQuote.Customer.Sex;
        taskControl.Customer.Address1 = taskControlQuote.Customer.Address1;
        taskControl.Customer.Address2 = taskControlQuote.Customer.Address2;
        taskControl.Customer.City = taskControlQuote.Customer.City;
        taskControl.Customer.State = taskControlQuote.Customer.State;
        taskControl.Customer.ZipCode = taskControlQuote.Customer.ZipCode;
        taskControl.Customer.SocialSecurity = taskControlQuote.Customer.SocialSecurity;
        taskControl.Customer.HomePhone = taskControlQuote.Customer.HomePhone;
        taskControl.Customer.JobPhone = taskControlQuote.Customer.JobPhone;
        taskControl.Customer.Cellular = taskControlQuote.Customer.Cellular;
        taskControl.Customer.Email = taskControlQuote.Customer.Email;
        taskControl.Customer.License = taskControlQuote.Customer.License;

        taskControl.PolicyType = "APE";
        taskControl.InsuranceCompany = "002";
        taskControl.ApplicationID = taskControlQuote.TaskControlID;
        taskControl.TotalPremium = taskControlQuote.RateYear1;
        taskControl.PRMedicRATEID = taskControlQuote.PRMEDICRATEID;
        taskControl.PRMedicalLimit = taskControlQuote.PRMedicalLimitID;
        taskControl.IsoCode = taskControlQuote.IsoCode;
        taskControl.Class = taskControlQuote.ClassRate;
        taskControl.RateYear1 = taskControlQuote.RateYear1;
        taskControl.RateYear2 = taskControlQuote.RateYear2;
        taskControl.RateYear3 = taskControlQuote.RateYear3;
        taskControl.MCMRate = taskControlQuote.MCMRate;

        taskControl.PriCarierName1 = taskControlQuote.PriCarierName1;
        taskControl.PriPolEffecDate1 = taskControlQuote.PriPolEffecDate1;
        taskControl.PriPolLimits1 = taskControlQuote.PriPolLimits1;
        taskControl.PriClaims1 = taskControlQuote.PriClaims1;

        //Update Status
        taskControlQuote.Status = 2; //Close
        taskControlQuote.UpdateStatusByTaskControlID(taskControlQuote.TaskControlID, taskControlQuote.Status);

        Session.Clear();
        Session.Add("TaskControl", taskControl);
        Response.Redirect("Policies.aspx", false);
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        if (taskControl.ApplicationMode == "UPDATE")
            taskControl.EntryDate = DateTime.Now;

        taskControl.TaskControlTypeID = 19;
        taskControl.InsuranceCompany = "002";

        Save(false);
        string dateBuffer = txtPrimaryRetroDate.Text;
        string date = Convert.ToDateTime(dateBuffer).ToString("MMMM dd yyyy");

        CultureInfo SpanishCI = new CultureInfo("es-PR");
        Thread.CurrentThread.CurrentCulture = SpanishCI;
        date = DateTime.Parse(date).ToString("d MMMM, yyyy");

        date = date.ToUpper().Substring(0, 1) + date.Substring(1);

        string specialty = ddlPolicyClass.SelectedItem.Text.ToString();
        if (!sentEmail)
        {
            taskControl.SendEmail(date, specialty);
            sentEmail = true;
        }
    }
    protected void ddlLimits_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetAllRate();
    }

    private void SetAllRate()
    {
        try
        {
            if (RadioButton1.Checked == false && RadioButton2.Checked == false)
            {
                throw new Exception("Please select The Rate Type (Primary or Excess).");
            }

            GetAllRates();
        }
        catch (Exception ex)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString(ex.Message);
            this.litPopUp.Visible = true;
        }
    }

    private void GetAllRates()
    {
        int limit = 0;
        if (ddlLimits.SelectedItem.Value.Trim() == "")
            limit = 0;
        else
            limit = int.Parse(ddlLimits.SelectedItem.Value);

        int primaryLimit = 0;
        if (ddlPrimaryLimits1.SelectedItem.Value.Trim() == "")
            primaryLimit = 0;
        else
            primaryLimit = int.Parse(ddlPrimaryLimits1.SelectedItem.Value);

        this.txtPrateID.Value = "";
        this.HIIsoCode.Value = "";
        this.HIClass.Value = "";
        this.HIRate1.Value = "";
        this.HIRate2.Value = "";
        this.HIRate3.Value = "";
        this.HIRate4.Value = "";

        this.txtPrate2ID.Value = "";
        this.HIIsoCode2.Value = "";
        this.HIClass2.Value = "";
        this.HIRate12.Value = "";
        this.HIRate22.Value = "";
        this.HIRate32.Value = "";
        this.HIRate42.Value = "";

        this.txtPrate3ID.Value = "";
        this.HIIsoCode3.Value = "";
        this.HIClass3.Value = "";
        this.HIRate13.Value = "";
        this.HIRate23.Value = "";
        this.HIRate33.Value = "";
        this.HIRate43.Value = "";

        this.txtPrate4ID.Value = "";
        this.HIIsoCode4.Value = "";
        this.HIClass4.Value = "";
        this.HIRate14.Value = "";
        this.HIRate24.Value = "";
        this.HIRate34.Value = "";
        this.HIRate44.Value = "";

        this.txtPrate5ID.Value = "";
        this.HIIsoCode5.Value = "";
        this.HIClass5.Value = "";
        this.HIRate15.Value = "";
        this.HIRate25.Value = "";
        this.HIRate35.Value = "";
        this.HIRate45.Value = "";

        this.txtPrate6ID.Value = "";
        this.HIIsoCode6.Value = "";
        this.HIClass6.Value = "";
        this.HIRate16.Value = "";
        this.HIRate26.Value = "";
        this.HIRate36.Value = "";
        this.HIRate46.Value = "";

        this.txtIsoCode.Text = "";
        this.txtClass.Text = "";
        this.txtRate1.Text = "";
        this.txtRate2.Text = "";
        this.txtRate3.Text = "";
        this.txtRate4.Text = "";

        this.txtRate12.Text = "";
        this.txtRate22.Text = "";
        this.txtRate32.Text = "";
        this.txtRate42.Text = "";

        this.txtRate13.Text = "";
        this.txtRate23.Text = "";
        this.txtRate33.Text = "";
        this.txtRate43.Text = "";

        this.txtRate14.Text = "";
        this.txtRate24.Text = "";
        this.txtRate34.Text = "";
        this.txtRate44.Text = "";

        this.txtRate15.Text = "";
        this.txtRate25.Text = "";
        this.txtRate35.Text = "";
        this.txtRate46.Text = "";

        this.txtRate16.Text = "";
        this.txtRate26.Text = "";
        this.txtRate36.Text = "";
        this.txtRate46.Text = "";

        ddlLimits2.SelectedIndex = -1;
        ddlLimits3.SelectedIndex = -1;
        ddlLimits4.SelectedIndex = -1;
        ddlLimits5.SelectedIndex = -1;
        ddlLimits6.SelectedIndex = -1;

        //Primary
        this.HIPrimeryRateID.Value = "";
        this.HIrimeryRate1.Value = "";
        this.HIrimeryRate2.Value = "";
        this.HIrimeryRate3.Value = "";
        this.HIrimeryRate4.Value = "";

        //ddlPrimaryLimits1.SelectedIndex = -1;
        this.txtPRate1.Text = "";
        this.txtPRate2.Text = "";
        this.txtPRate3.Text = "";
        this.txtPRate4.Text = "";

        if (SaveBeforeRate(false))
        {
            SetDDLLimit(limit, primaryLimit);
        }
        else
        {
            ddlLimits.SelectedIndex = -1;
            ddlLimits2.SelectedIndex = -1;
            ddlLimits3.SelectedIndex = -1;
            ddlLimits4.SelectedIndex = -1;
            ddlLimits5.SelectedIndex = -1;
            ddlLimits6.SelectedIndex = -1;
        }
    }

    private bool SaveBeforeRate(bool IsNavigation)
    {
        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
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

        try
        {
            if (!cp.IsInRole("NOREQUIREDFIELDS"))
            {
                ValidateFields();
            }

            FillProperties();
            EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

            taskControl.Save(userID, 1);  //(userID);
            FillTextControl();
            EnableControls();

            taskControl.Mode = (int)EPolicy.TaskControl.TaskControl.TaskControlMode.UPDATE;

            taskControl.ApplicationMode = "UPDATE";
            Session["TaskControl"] = taskControl;

            return true;
        }
        catch (Exception exp)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Please, fill the following fields to continue with the rate. " + "\r\n" + exp.Message);
            this.litPopUp.Visible = true;
            return false;
        }
    }

    private void SetDDLLimit(int LimitID, int primaryLimit)
    {
        //Excess
        DataTable dtPRMEDICRATE1 = EPolicy.TaskControl.Application.GetPRMEDICRATE(LimitID);
        ddlPolicyClass.Items.Clear();
        ddlPolicyClass.DataSource = dtPRMEDICRATE1;
        ddlPolicyClass.DataTextField = "PRMEDICRATEDesc";
        ddlPolicyClass.DataValueField = "PRMEDICRATEID";
        ddlPolicyClass.DataBind();
        ddlPolicyClass.SelectedIndex = -1;
        ddlPolicyClass.Items.Insert(0, "");

        //Primary
        DataTable dtPRMEDICRATE2 = EPolicy.TaskControl.Application.GetPRMEDICPrimaryRATE(primaryLimit);
        ddPrimarylPolicyClass.Items.Clear();
        ddPrimarylPolicyClass.DataSource = dtPRMEDICRATE2;
        ddPrimarylPolicyClass.DataTextField = "PRMEDICRATEDesc";
        ddPrimarylPolicyClass.DataValueField = "PRMEDICRATEID";
        ddPrimarylPolicyClass.DataBind();
        ddPrimarylPolicyClass.SelectedIndex = -1;
        ddPrimarylPolicyClass.Items.Insert(0, "");

    }

    protected void ddlPolicyClass_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //SetddlPimaryPolicyClass
        ddPrimarylPolicyClass.SelectedIndex = ddPrimarylPolicyClass.Items.IndexOf(
            ddPrimarylPolicyClass.Items.FindByText(this.ddlPolicyClass.SelectedItem.Text.Trim()));

        string myStringPrimary = this.ddPrimarylPolicyClass.SelectedValue.Trim();

        //if (myStringPrimary.Trim() == "")
        //    myStringPrimary = "0|" + myRateList[1].ToString() + "|" + myRateList[2].ToString() + "|0|0|0|0|01/01/2011";

        string[] myPrimaryRateList = myStringPrimary.Split('|');
        this.HIPrimeryRateID.Value = myPrimaryRateList[0];

        //SetDDLLimit Excess
        string myString = this.ddlPolicyClass.SelectedValue.Trim();
        string[] myRateList = myString.Split('|');
        //alert(myRateList[0]+"-"+myRateList[1])

        this.txtPrateID.Value = myRateList[0];
        this.HIIsoCode.Value = myRateList[1];
        this.HIClass.Value = myRateList[2];
        this.HIRate1.Value = myRateList[3];
        this.HIRate2.Value = myRateList[4];
        this.HIRate3.Value = myRateList[5];
        this.HIRate4.Value = myRateList[6];

        this.txtIsoCode.Text = myRateList[1];
        this.txtClass.Text = myRateList[2];
        this.txtRate1.Text = myRateList[3];
        this.txtRate2.Text = myRateList[4];
        this.txtRate3.Text = myRateList[5];
        this.txtRate4.Text = myRateList[6];

        DataTable dtPRMEDICRATE2 = EPolicy.TaskControl.Application.GetPRMEDICRATEBYISOCODE(int.Parse(txtPrateID.Value), txtIsoCode.Text.Trim());

        if (dtPRMEDICRATE2.Rows.Count > 0)
        {
            int index = 1;
            for (int i = 0; dtPRMEDICRATE2.Rows.Count > i; i++)
            {
                myString = dtPRMEDICRATE2.Rows[i]["PRMEDICRATEID"].ToString().Trim();
                myRateList = myString.Split('|');

                if (int.Parse(txtPrateID.Value.Trim()) != int.Parse(myRateList[0].Trim()) &&
                (myRateList[7].ToString() != "6")) //Ya no se ofrecen polizas con 300M/1,000M
                {
                    SetOtherRateFields(index, myRateList);
                    index = index + 1;
                }
            }
        }

        //Primary
        DataTable dtPRMEDICRATEPRIMARY2 = EPolicy.TaskControl.Application.GetPRMEDICRATEPRIMARYBYISOCODE(int.Parse(HIPrimeryRateID.Value), txtIsoCode.Text.Trim());
        if (dtPRMEDICRATEPRIMARY2.Rows.Count > 0)
        {
            int index = 1;
            for (int i = 0; dtPRMEDICRATEPRIMARY2.Rows.Count > i; i++)
            {
                myString = dtPRMEDICRATEPRIMARY2.Rows[i]["PRMEDICRATEID"].ToString().Trim();
                myRateList = myString.Split('|');

                if (int.Parse(myRateList[0].Trim()) != 0)
                {
                    SetPrimaryRates(index, myRateList);
                    index = index + 1;
                }
            }
        }

        SaveBeforeRate(false);

        SetPremiumByRetroDate(DateTime.Now);
    }

    private void SetPremiumByRetroDate(DateTime entrydate)
    {
        //Set Premium by Retro Date
        txtPRate1.BackColor = Color.White;
        txtPRate1.ForeColor = Color.Black;
        txtPRate1.Font.Bold = false;
        txtPRate2.BackColor = Color.White;
        txtPRate2.ForeColor = Color.Black;
        txtPRate2.Font.Bold = false;
        txtPRate3.BackColor = Color.White;
        txtPRate3.ForeColor = Color.Black;
        txtPRate3.Font.Bold = false;
        txtPRate4.BackColor = Color.White;
        txtPRate4.ForeColor = Color.Black;
        txtPRate4.Font.Bold = false;

        txtRate1.BackColor = Color.White;
        txtRate1.ForeColor = Color.Black;
        txtRate1.Font.Bold = false;
        txtRate2.BackColor = Color.White;
        txtRate2.ForeColor = Color.Black;
        txtRate2.Font.Bold = false;
        txtRate3.BackColor = Color.White;
        txtRate3.ForeColor = Color.Black;
        txtRate3.Font.Bold = false;
        txtRate4.BackColor = Color.White;
        txtRate4.ForeColor = Color.Black;
        txtRate4.Font.Bold = false;

        int PrimaryRetroYear = 0;
        int ExcessRetroYear = 0;
        PrimaryRetroYear = entrydate.Year - DateTime.Parse(txtPrimaryRetroDate.Text.Trim()).Year;
        ExcessRetroYear = entrydate.Year - DateTime.Parse(txtExcessRetroDate.Text.Trim()).Year;

        switch (PrimaryRetroYear)
        {
            case 0:
                txtPRate1.BackColor = Color.Navy;
                txtPRate1.ForeColor = Color.White;
                txtPRate1.Font.Bold = true;
                break;
            case 1:
                txtPRate2.BackColor = Color.Navy;
                txtPRate2.ForeColor = Color.White;
                txtPRate2.Font.Bold = true;
                break;
            case 2:
                txtPRate3.BackColor = Color.Navy;
                txtPRate3.ForeColor = Color.White;
                txtPRate3.Font.Bold = true;
                break;
            default:
                txtPRate4.BackColor = Color.Navy;
                txtPRate4.ForeColor = Color.White;
                txtPRate4.Font.Bold = true;
                break;
        }

        switch (ExcessRetroYear)
        {
            case 0:
                txtRate1.BackColor = Color.Navy;
                txtRate1.ForeColor = Color.White;
                txtRate1.Font.Bold = true;
                break;
            case 1:
                txtRate2.BackColor = Color.Navy;
                txtRate2.ForeColor = Color.White;
                txtRate2.Font.Bold = true;
                break;
            case 2:
                txtRate3.BackColor = Color.Navy;
                txtRate3.ForeColor = Color.White;
                txtRate3.Font.Bold = true;
                break;
            default:
                txtRate4.BackColor = Color.Navy;
                txtRate4.ForeColor = Color.White;
                txtRate4.Font.Bold = true;
                break;
        }
    }

    private void SetPrimaryRates(int index, string[] myRateList)
    {
        if (index == 1)
        {
            ddlPrimaryLimits1.SelectedIndex = ddlPrimaryLimits1.Items.IndexOf(
                    ddlPrimaryLimits1.Items.FindByValue(myRateList[7].ToString()));

            this.HIrimeryRate1.Value = myRateList[3];
            this.HIrimeryRate2.Value = myRateList[4];
            this.HIrimeryRate3.Value = myRateList[5];
            this.HIrimeryRate4.Value = myRateList[6];

            this.txtPRate1.Text = myRateList[3];
            this.txtPRate2.Text = myRateList[4];
            this.txtPRate3.Text = myRateList[5];
            this.txtPRate4.Text = myRateList[6];
        }
    }

    private void SetOtherRateFields(int index, string[] myRateList)
    {

        if (index == 1)
        {
            ddlLimits2.SelectedIndex = ddlLimits2.Items.IndexOf(
                    ddlLimits2.Items.FindByValue(myRateList[7].ToString()));

            this.HIRate12.Value = myRateList[3];
            this.HIRate22.Value = myRateList[4];
            this.HIRate32.Value = myRateList[5];
            this.HIRate42.Value = myRateList[6];

            this.txtRate12.Text = myRateList[3];
            this.txtRate22.Text = myRateList[4];
            this.txtRate32.Text = myRateList[5];
            this.txtRate42.Text = myRateList[6];
        }

        if (index == 2)
        {
            ddlLimits3.SelectedIndex = ddlLimits3.Items.IndexOf(
                ddlLimits3.Items.FindByValue(myRateList[7].ToString()));

            this.HIRate13.Value = myRateList[3];
            this.HIRate23.Value = myRateList[4];
            this.HIRate33.Value = myRateList[5];
            this.HIRate43.Value = myRateList[6];

            this.txtRate13.Text = myRateList[3];
            this.txtRate23.Text = myRateList[4];
            this.txtRate33.Text = myRateList[5];
            this.txtRate43.Text = myRateList[6];
        }

        if (index == 3)
        {
            ddlLimits4.SelectedIndex = ddlLimits4.Items.IndexOf(
                ddlLimits4.Items.FindByValue(myRateList[7].ToString()));

            this.HIRate14.Value = myRateList[3];
            this.HIRate24.Value = myRateList[4];
            this.HIRate34.Value = myRateList[5];
            this.HIRate44.Value = myRateList[6];

            this.txtRate14.Text = myRateList[3];
            this.txtRate24.Text = myRateList[4];
            this.txtRate34.Text = myRateList[5];
            this.txtRate44.Text = myRateList[6];
        }

        if (index == 4)
        {
            ddlLimits5.SelectedIndex = ddlLimits5.Items.IndexOf(
                ddlLimits5.Items.FindByValue(myRateList[7].ToString()));

            this.HIRate15.Value = myRateList[3];
            this.HIRate25.Value = myRateList[4];
            this.HIRate35.Value = myRateList[5];
            this.HIRate45.Value = myRateList[6];

            this.txtRate15.Text = myRateList[3];
            this.txtRate25.Text = myRateList[4];
            this.txtRate35.Text = myRateList[5];
            this.txtRate45.Text = myRateList[6];
        }


        if (index == 5)
        {
            ddlLimits6.SelectedIndex = ddlLimits6.Items.IndexOf(
                ddlLimits6.Items.FindByValue(myRateList[7].ToString()));

            this.HIRate16.Value = myRateList[3];
            this.HIRate26.Value = myRateList[4];
            this.HIRate36.Value = myRateList[5];
            this.HIRate46.Value = myRateList[6];

            this.txtRate16.Text = myRateList[3];
            this.txtRate26.Text = myRateList[4];
            this.txtRate36.Text = myRateList[5];
            this.txtRate46.Text = myRateList[6];
        }
    }
    protected void ddlLimits4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlPrimaryLimits1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetAllRate();
    }
    protected void btnConvertPrimary_Click(object sender, EventArgs e)
    {
        EPolicy.TaskControl.Application taskControlQuote = (EPolicy.TaskControl.Application)Session["TaskControl"];
        EPolicy.TaskControl.Policies taskControl = new EPolicy.TaskControl.Policies();

        taskControl.Mode = 1; //ADD
        taskControl.PolicyClassID = 9;

        taskControl.Agency = taskControlQuote.Agency;
        taskControl.Agent = taskControlQuote.Agent;

        taskControl.Customer.ProspectID = taskControlQuote.Prospect.ProspectID;
        taskControl.Customer.CustomerNo = taskControlQuote.Customer.CustomerNo;
        taskControl.Customer.FirstName = taskControlQuote.Customer.FirstName;
        taskControl.Customer.Initial = taskControlQuote.Customer.Initial;
        taskControl.Customer.LastName1 = taskControlQuote.Customer.LastName1;
        taskControl.Customer.LastName2 = taskControlQuote.Customer.LastName2;
        taskControl.Customer.Birthday = taskControlQuote.Customer.Birthday;
        taskControl.Customer.Description = taskControlQuote.Customer.Description;
        taskControl.Customer.Sex = taskControlQuote.Customer.Sex;
        taskControl.Customer.Address1 = taskControlQuote.Customer.Address1;
        taskControl.Customer.Address2 = taskControlQuote.Customer.Address2;
        taskControl.Customer.City = taskControlQuote.Customer.City;
        taskControl.Customer.State = taskControlQuote.Customer.State;
        taskControl.Customer.ZipCode = taskControlQuote.Customer.ZipCode;
        taskControl.Customer.SocialSecurity = taskControlQuote.Customer.SocialSecurity;
        taskControl.Customer.HomePhone = taskControlQuote.Customer.HomePhone;
        taskControl.Customer.JobPhone = taskControlQuote.Customer.JobPhone;
        taskControl.Customer.Cellular = taskControlQuote.Customer.Cellular;
        taskControl.Customer.Email = taskControlQuote.Customer.Email;
        taskControl.Customer.License = taskControlQuote.Customer.License;

        taskControl.PolicyType = "APP";
        taskControl.InsuranceCompany = "002";
        taskControl.ApplicationID = taskControlQuote.TaskControlID;
        taskControl.TotalPremium = taskControlQuote.PRateYear1;
        taskControl.PRMedicRATEID = taskControlQuote.PRPrimeryRateID;
        taskControl.PRMedicalLimit = taskControlQuote.PRPrimaryLimitID;
        taskControl.IsoCode = taskControlQuote.IsoCode;
        taskControl.Class = taskControlQuote.ClassRate;
        taskControl.RateYear1 = taskControlQuote.PRateYear1;
        taskControl.RateYear2 = taskControlQuote.PRateYear2;
        taskControl.RateYear3 = taskControlQuote.PRateYear3;
        taskControl.MCMRate = taskControlQuote.PRateYear4;


        taskControl.PriCarierName1 = taskControlQuote.PriCarierName1;
        taskControl.PriPolEffecDate1 = taskControlQuote.PriPolEffecDate1;
        taskControl.PriPolLimits1 = taskControlQuote.PriPolLimits1;
        taskControl.PriClaims1 = taskControlQuote.PriClaims1;

        //Update Status
        taskControlQuote.Status = 2; //Close
        taskControlQuote.UpdateStatusByTaskControlID(taskControlQuote.TaskControlID, taskControlQuote.Status);

        Session.Clear();
        Session.Add("TaskControl", taskControl);
        Response.Redirect("Policies.aspx", false);
    }
    protected void ddPrimarylPolicyClass_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButton1.Checked)
        {
            RadioButton1.Checked = true;
            RadioButton2.Checked = false;
        }
        else
        {
            RadioButton1.Checked = false;
            RadioButton2.Checked = true;
        }
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButton2.Checked)
        {
            RadioButton1.Checked = false;
            RadioButton2.Checked = true;
        }
        else
        {
            RadioButton1.Checked = true;
            RadioButton2.Checked = false;
        }
    }
    protected void txtPrimaryRetroDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtPrimaryRetroDate.Text.Trim() == "")
            {
                throw new Exception("The Primary Retro Date is Missing or wrong.");
            }

            GetAllRates();
        }
        catch (Exception ex)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString(ex.Message);
            this.litPopUp.Visible = true;
        }
    }
    protected void txtExcessRetroDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtExcessRetroDate.Text.Trim() == "")
            {
                throw new Exception("The Excess Retro Date is Missing or wrong.");
            }

            GetAllRates();
        }
        catch (Exception ex)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString(ex.Message);
            this.litPopUp.Visible = true;
        }
    }
}

