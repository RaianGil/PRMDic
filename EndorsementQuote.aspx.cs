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
using Baldrich.DBRequest;
using EPolicy.XmlCooker;
using System.Xml;
using Microsoft.Reporting.WebForms;
using System.IO;

namespace EPolicy
{
    /// <summary>
    /// Summary description for Policies.
    /// </summary>
    public partial class EndorsementQuote : System.Web.UI.Page
    {
        private DataTable DtTaskPolicy;
        private DataTable DtEndorsement;
        private int userID;
        private int toEditID;
        private bool prmdicAdmin = false;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                this.litPopUp.Visible = false;

                Login.Login cp = HttpContext.Current.User as Login.Login;
                userID = cp.UserID;
                if (cp == null)
                {
                    Response.Redirect("Default.aspx?001");
                }
                else
                {
                    if (!cp.IsInRole("POLICIES") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        Response.Redirect("Default.aspx?001");
                    }
                }

                

                //this.btnSalvar.Attributes.Add("onclick","validatePage();");
                //this.btnImprimir.Attributes.Add("onclick","validatePage();");
                //this.btnEliminar.Attributes.Add("onclick","validatePage();");

                if (Session["AutoPostBack"] == null)
                {
                    if (!IsPostBack)
                    {
                        //ddlCiudad.Attributes.Add("onchange", "getExpDt()");
                        TxtTerm.Attributes.Add("onblur", "getExpDt()");
                        txtEffDt.Attributes.Add("onblur", "getExpDt();SetFieldDate()");
                        //TxtZip.Attributes.Add("onblur", "SetCiudad()");
                        //ddlCiudad.Attributes.Add("onchange", "SetZipCode()");
                        //ddlCompanyDealer.Attributes.Add("onchange", "SetSupplier()");                    

                        if (Session["EndorsementQuote"] != null)
                        {
                            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

                            switch (taskControl.Mode)
                            {
                                case 1: //ADD
                                    DisableControls();
                                    FillTextControl();
                                    this.ddlPolicyClass.Enabled = false;

                                    //btnEdit.Visible = false;
                                    BtnExit.Visible = false;
                                    BtnSave.Visible = true;
                                    //btnChargeCalc.Visible = true;
                                    //btnCancel.Visible = true;
                                    //btnDelete.Visible = false;
                                    //btnHistory.Visible = false;
                                    //btnPrintPolicy.Visible = false;
                                    //btnPrintCertificate.Visible = false;
                                    //btnTailQuote.Visible = false;
                                    //btnPayments.Visible = false;
                                    //btnComissions.Visible = false;
                                    //btnReinstatement.Visible = false;
                                    //btnCancellation.Visible = false;
                                    //btnFinancialCanc.Visible = false;
                                    //btnPolicyCert.Visible = false;
                                    //btnNew.Visible = false;

                                    ResetDllPolicyClass();
                                    GetOthersRates();
                                    CalculateOthersRates();
                                    break;

                                case 2: //UPDATE
                                    FillTextControl();
                                    EnableControls();
                                    //btnPrintCertificate.Visible = false;
                                    //btnTailQuote.Visible = false;
                                    //SetControlToDisplay();
                                    break;

                                default:
                                    FillTextControl();
                                    GetOthersRates();
                                    DisableControls();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (Session["EndorsementQuote"] != null)
                        {
                            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];
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

                DisableControlsTail();

                BtnExit.Visible = true;
            }
            catch (Exception exp)
            {
                if (exp.InnerException == null)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
                else if (exp.InnerException.InnerException == null)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
                else
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

                this.litPopUp.Visible = true;
            }
        }

        #region VerifyAccess
        private void VerifyAccess()
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

            Login.Login cp = HttpContext.Current.User as Login.Login;

            //if (!cp.IsInRole("BTNHISTORYPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            //{
            //    this.btnHistory.Visible = false;
            //}
            //else
            //{
            //    this.btnHistory.Visible = true;
            //}

            //if (!cp.IsInRole("BTNCOMMISSIONPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            //{
            //    this.btnComissions.Visible = false;
            //}
            //else
            //{
            //    this.btnComissions.Visible = true;
            //}

            //if (!cp.IsInRole("BTNPAYMENTPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            //{
            //    this.btnPayments.Visible = false;
            //}
            //else
            //{
            //    this.btnPayments.Visible = true;
            //}

            //if (!cp.IsInRole("BTNCANCELLATIONPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            //{
            //    this.btnCancellation.Visible = false;
            //    this.btnFinancialCanc.Visible = false;
            //}
            //else
            //{
            //    this.btnCancellation.Visible = true;
            //    this.btnFinancialCanc.Visible = true;
            //}

            //if (!cp.IsInRole("BTNREINSTATEMENTPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            //{
            //    this.btnReinstatement.Visible = false;
            //}
            //else
            //{
            //    this.btnReinstatement.Visible = true;
            //}

            //if (!cp.IsInRole("BTNDELETEPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            //{
            //    this.btnDelete.Visible = false;
            //}
            //else
            //{
            //    this.btnDelete.Visible = true;
            //}

            //if (!cp.IsInRole("BTNADDPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            //{
            //    this.btnAdd2.Visible = false;
            //}
            //else
            //{
            //    this.btnAdd2.Visible = true;
            //}

            //if (!cp.IsInRole("BTNEDITPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            //{
            //    this.btnEdit.Visible = false;
            //}
            //else
            //{
            //    this.btnEdit.Visible = true;
            //}

            //if (!cp.IsInRole("BTNPRINTPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            //{
            //    this.btnPrintPolicy.Visible = false;
            //}
            //else
            //{
            //    this.btnPrintPolicy.Visible = true;
            //}

            //if (!cp.IsInRole("BTNNEWPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            //{
            //    this.btnNew.Visible = false;
            //}
            //else
            //{
            //    this.btnNew.Visible = false;
            //}

            //if (!cp.IsInRole("BTNRATEPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            //{
            //    this.btnRate.Visible = false;
            //}
            //else
            //{
            //    this.btnRate.Visible = true;
            //}

            //if (!cp.IsInRole("BTNRENEWPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            //{
            //    this.btnRenew.Visible = false;
            //}
            //else
            //{
            //    this.btnRenew.Visible = true;
            //}

            if (!cp.IsInRole("BTNSAVEPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.BtnSave.Visible = false;
            }
            else
            {
                this.BtnSave.Visible = true;
            }

            //if (!cp.IsInRole("ADMINISTRATOR"))
            //{
            //    this.btnTailQuote.Visible = false;
            //}
            //else
            //{
            //    this.btnTailQuote.Visible = true;
            //    prmdicAdmin = true;
            //}

            //if (userID != 1 && userID != 13 && userID != 156 && userID != 240 && userID != 2)
            //{
            //    this.btnEnablePrint.Visible = false;
            //}
            //else
            //{
            //    this.btnEnablePrint.Visible = taskControl.PrintPolicy;
            //}                

        }
        #endregion

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            try
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
                phTopBanner1.Controls.Add(LeftMenu);*/

                if (Session["LookUpTables"] == null)
                {
                    EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
                    int userID = 0;
                    userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                    TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

                    DataTable dtLocation = LookupTables.LookupTables.GetTable("Location");
                    //DataTable dtBank = LookupTables.LookupTables.GetTable("Bank");
                    DataTable dtAgency = LookupTables.LookupTables.GetTable("Agency");
                    DataTable dtAgent = LookupTables.LookupTables.GetTable("Agent");
                    DataTable dtInsuranceCompany = LookupTables.LookupTables.GetTable("InsuranceCompany");
                    DataTable dtInsuranceCompany2 = LookupTables.LookupTables.GetTable("InsuranceCompany2");
                    DataTable dtPRMedicalLimit = LookupTables.LookupTables.GetTable("PRMedicalLimit");
                    DataTable dtPRPrimaryLimit = LookupTables.LookupTables.GetTable("PRPrimaryLimit");
                    //DataTable dtPRMEDICRATE = LookupTables.LookupTables.GetTable("PRMEDICRATE");
                    DataTable dtFinancial = LookupTables.LookupTables.GetTable("Financial");


                    //DataTable dtEndorsementType = EPolicy.LookupTables.LookupTables.GetTable("EndorsementType");
                    ////EndorsementType
                    //ddlEndorsementType.DataSource = dtEndorsementType;
                    //ddlEndorsementType.DataTextField = "Ciudad";
                    //ddlEndorsementType.DataValueField = "ZipCode";
                    //ddlEndorsementType.DataBind();
                    //ddlEndorsementType.SelectedIndex = -1;
                    //ddlEndorsementType.Items.Insert(0, "");


                    DataTable dtPRMEDICRATE1 = EPolicy.LookupTables.LookupTables.GetTable("PRMEDICSpecialty");
                    ddlRate.Items.Clear();
                    ddlRate.DataSource = dtPRMEDICRATE1;
                    ddlRate.DataTextField = "PRMEDICSpecialtyDesc";
                    ddlRate.DataValueField = "IsoCode";
                    ddlRate.DataBind();
                    ddlRate.SelectedIndex = -1;
                    ddlRate.Items.Insert(0, "");

                    DataTable dtPRMEDICRATE2 = EPolicy.LookupTables.LookupTables.GetTable("PRMEDICSpecialty");
                    ddlOtherSpecialty.Items.Clear();
                    ddlOtherSpecialty.DataSource = dtPRMEDICRATE2;
                    ddlOtherSpecialty.DataTextField = "PRMEDICSpecialtyDesc";
                    ddlOtherSpecialty.DataValueField = "PRMEDICSpecialtyID";
                    ddlOtherSpecialty.DataBind();
                    ddlOtherSpecialty.SelectedIndex = -1;
                    ddlOtherSpecialty.Items.Insert(0, "");

                    //PRMEDICRATE
                    //ddlRate.DataSource = dtPRMEDICRATE;
                    //ddlRate.DataTextField = "PRMEDICRATEDesc";
                    //ddlRate.DataValueField = "PRMEDICRATEID";
                    //ddlRate.DataBind();
                    //ddlRate.SelectedIndex = -1;
                    //ddlRate.Items.Insert(0, "");

                    //DataTable dtModel				= LookupTables.LookupTables.GetTable("VehicleModel");
                    DataTable dtPolicyClass = LookupTables.LookupTables.GetTable("PolicyClass");
                    //DataTable dtSupplier = LookupTables.LookupTables.GetTable("Supplier");
                    //DataTable dtCiudad = LookupTables.LookupTables.GetTable("Ciudad");
                    //DataTable dtDealer = EPolicy.Login.Login.GetGroupDealerByUserID(userID);

                    //if (dtDealer.Rows.Count == 0)
                    //{
                    //dtDealer = EPolicy.LookupTables.LookupTables.GetTable("CompanyDealer");
                    //}

                    ddlSupplier.Items.Insert(0, "");

                    LookupTables.MasterPolicy master = new LookupTables.MasterPolicy();
                    DataTable dtCorporation = master.GetMasterPolicyByIsGroup(false);
                    DataTable dtGroup = master.GetMasterPolicyByIsGroup(true);

                    //Corporation
                    ddlCorparation.DataSource = dtCorporation;
                    ddlCorparation.DataTextField = "MasterPolicyDesc";
                    ddlCorparation.DataValueField = "MasterPolicyID";
                    ddlCorparation.DataBind();
                    ddlCorparation.SelectedIndex = -1;
                    ddlCorparation.Items.Insert(0, "");

                    //Group
                    ddlGroup.DataSource = dtGroup;
                    ddlGroup.DataTextField = "MasterPolicyDesc";
                    ddlGroup.DataValueField = "MasterPolicyID";
                    ddlGroup.DataBind();
                    ddlGroup.SelectedIndex = -1;
                    ddlGroup.Items.Insert(0, "");

                    //Location
                    ddlOriginatedAt.DataSource = dtLocation;
                    ddlOriginatedAt.DataTextField = "locationDesc";
                    ddlOriginatedAt.DataValueField = "locationID";
                    ddlOriginatedAt.DataBind();
                    ddlOriginatedAt.SelectedIndex = -1;
                    ddlOriginatedAt.Items.Insert(0, "");

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

                    //InsuranceCompany
                    ddlInsuranceCompany.DataSource = dtInsuranceCompany;
                    ddlInsuranceCompany.DataTextField = "InsuranceCompanyDesc";
                    ddlInsuranceCompany.DataValueField = "InsuranceCompanyID";
                    ddlInsuranceCompany.DataBind();
                    ddlInsuranceCompany.SelectedIndex = -1;
                    ddlInsuranceCompany.Items.Insert(0, "");

                    //PolicyClass
                    ddlPolicyClass.DataSource = dtPolicyClass;
                    ddlPolicyClass.DataTextField = "PolicyClassDesc";
                    ddlPolicyClass.DataValueField = "PolicyClassID";
                    ddlPolicyClass.DataBind();
                    ddlPolicyClass.SelectedIndex = -1;
                    ddlPolicyClass.Items.Insert(0, "");
                    //Set default PrMedical
                    //ddlPolicyClass.SelectedIndex = ddlPolicyClass.Items.IndexOf(ddlPolicyClass.Items.FindByValue(taskControl.PolicyClassID.ToString()));
                    ddlPolicyClass.SelectedIndex = ddlPolicyClass.Items.IndexOf(ddlPolicyClass.Items.FindByValue("9"));

                    ////Ciudad
                    //ddlCiudad.DataSource = dtCiudad;
                    //ddlCiudad.DataTextField = "Ciudad";
                    //ddlCiudad.DataValueField = "ZipCode";
                    //ddlCiudad.DataBind();
                    //ddlCiudad.SelectedIndex = -1;
                    //ddlCiudad.Items.Insert(0, "");

                    //Financial
                    ddlFinancial.DataSource = dtFinancial;
                    ddlFinancial.DataTextField = "FinancialDesc";
                    ddlFinancial.DataValueField = "FinancialID";
                    ddlFinancial.DataBind();
                    ddlFinancial.SelectedIndex = -1;
                    ddlFinancial.Items.Insert(0, "");

                    //PRMedicalLimit
                    if (taskControl.PolicyType.Trim() == "PE")
                        ddlPrMedicalLimits.DataSource = dtPRMedicalLimit;
                    else
                        ddlPrMedicalLimits.DataSource = dtPRPrimaryLimit;

                    ddlPrMedicalLimits.DataTextField = "PRMedicalLimitDesc";
                    ddlPrMedicalLimits.DataValueField = "PRMedicalLimitID";
                    ddlPrMedicalLimits.DataBind();
                    ddlPrMedicalLimits.SelectedIndex = -1;
                    ddlPrMedicalLimits.Items.Insert(0, "");

                    Session.Add("LookUpTables", "In");
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion

        private void FillGrid()
        {
            try
            {
                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = 0;
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                //DtSearchPayments.Visible = false;
                //DtSearchPayments.DataSource = null;
                DtTaskPolicy = null;

                int policyClass = 0;
                string tempPolType = String.Empty;

                TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

                if (taskControl.PolicyType.ToString().Trim().Length >= 3)
                    tempPolType = taskControl.PolicyType.Remove(taskControl.PolicyType.IndexOf('T'));
                else
                    tempPolType = taskControl.PolicyType.Trim();

                DtTaskPolicy = TaskControl.Policy.GetPolicies(policyClass, tempPolType,
                    taskControl.PolicyNo, /*taskControl.Certificate*/ "", "", "", "", "", userID);

                Session.Remove("DtTaskPolicy");
                Session.Add("DtTaskPolicy", DtTaskPolicy);

                if (DtTaskPolicy.Rows.Count != 0)
                {
                    //DtSearchPayments.Visible = true;
                    //DtSearchPayments.DataSource = DtTaskPolicy;
                    //DtSearchPayments.DataBind();
                }
                else
                {
                    //DtSearchPayments.DataSource = null;
                    //DtSearchPayments.DataBind();
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

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("A problem occured while obtaining data for the grids.");
                this.litPopUp.Visible = true;
            }
        }
        private void FillTextControl()
        {
            try
            {
                TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

                FillGrid();

                if (taskControl.Mode != 1)
                    FillTextDDlAgent();

                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                //ChkAutoAssignPolicy.Checked = taskControl.AutoAssignPolicy;

                if (taskControl.OriginatedAt != 0)
                    ddlOriginatedAt.SelectedIndex = ddlOriginatedAt.Items.IndexOf(
                        ddlOriginatedAt.Items.FindByValue(taskControl.OriginatedAt.ToString()));

                if (taskControl.FinancialID != 0)
                    ddlFinancial.SelectedIndex = ddlFinancial.Items.IndexOf(
                        ddlFinancial.Items.FindByValue(taskControl.FinancialID.ToString()));

                if (taskControl.InsuranceCompany != "0")
                    ddlInsuranceCompany.SelectedIndex = ddlInsuranceCompany.Items.IndexOf(
                        ddlInsuranceCompany.Items.FindByValue(taskControl.InsuranceCompany.ToString()));

                if (taskControl.Agency != "0")
                    ddlAgency.SelectedIndex = ddlAgency.Items.IndexOf(
                        ddlAgency.Items.FindByValue(taskControl.Agency));

                if (taskControl.Agent != "0")
                    ddlAgent.SelectedIndex = ddlAgent.Items.IndexOf(
                        ddlAgent.Items.FindByValue(taskControl.Agent));

                if (taskControl.Bank != "0")
                    ddlGroup.SelectedIndex = ddlGroup.Items.IndexOf(
                        ddlGroup.Items.FindByValue(taskControl.Bank));

                if (taskControl.CompanyDealer != "0")
                    ddlCorparation.SelectedIndex = ddlCorparation.Items.IndexOf(
                        ddlCorparation.Items.FindByValue(taskControl.CompanyDealer));

                if (taskControl.PolicyClassID != 0)
                    ddlPolicyClass.SelectedIndex = ddlPolicyClass.Items.IndexOf(
                        ddlPolicyClass.Items.FindByValue(taskControl.PolicyClassID.ToString()));

                if (taskControl.IsoCode != "")
                    ddlRate.SelectedIndex = ddlRate.Items.IndexOf(
                        ddlRate.Items.FindByValue(taskControl.IsoCode));

                if (taskControl.OtherSpecialtyID != 0)
                    ddlOtherSpecialty.SelectedIndex = ddlOtherSpecialty.Items.IndexOf(
                        ddlOtherSpecialty.Items.FindByValue(taskControl.OtherSpecialtyID.ToString()));

                if (taskControl.PRMedicalLimit != 0)
                    ddlPrMedicalLimits.SelectedIndex = ddlPrMedicalLimits.Items.IndexOf(
                        ddlPrMedicalLimits.Items.FindByValue(taskControl.PRMedicalLimit.ToString()));

                if (taskControl.Notification30Flag && taskControl.Notification15Flag && taskControl.CancellationFlag)
                    chkPaymentGA.Checked = true;


                if (taskControl.PRMedicalLimit != 0)
                {
                    SetDDLLimit(taskControl.PRMedicalLimit);
                }

                //ddlCiudad.SelectedIndex = 0;
                //if (taskControl.Customer.City != "")
                //{
                //    for (int i = 0; ddlCiudad.Items.Count - 1 >= i; i++)
                //    {
                //        if (ddlCiudad.Items[i].Text.Trim() == taskControl.Customer.City.ToString().Trim())
                //        {
                //            ddlCiudad.SelectedIndex = i;
                //            i = ddlCiudad.Items.Count - 1;
                //        }
                //    }
                //}
                if (taskControl.Mode != 1) //Modify
                    ResetDllPolicyClass();

                LblStatus.Text = taskControl.Status;

                if (taskControl.Ren_Rei == "RI")
                    LblStatus.Text = LblStatus.Text + " Reinst.";

                LblControlNo.Text = taskControl.TaskControlID.ToString();
                TxtCustomerNo.Text = taskControl.Customer.CustomerNo;
                TxtFirstName.Text = taskControl.Customer.FirstName;
                TxtInitial.Text = taskControl.Customer.Initial;
                txtLastname1.Text = taskControl.Customer.LastName1;
                txtLastname2.Text = taskControl.Customer.LastName2;
                TxtAddrs1.Text = taskControl.Customer.Address1;
                TxtAddrs2.Text = taskControl.Customer.Address2;
                TxtCity.Text = taskControl.Customer.City;
                TxtState.Text = taskControl.Customer.State;
                TxtZip.Text = taskControl.Customer.ZipCode;
                txtSocialSecurity.Text = taskControl.Customer.SocialSecurity;
                txtHomePhone.Text = taskControl.Customer.HomePhone;
                txtWorkPhone.Text = taskControl.Customer.JobPhone;
                TxtCellular.Text = taskControl.Customer.Cellular;
                txtEmail.Text = taskControl.Customer.Email;
                txtLicense.Text = taskControl.Customer.License;
                TxtPolicyNo.Text = taskControl.PolicyNo;
                TxtCertificate.Text = taskControl.Certificate;
                TxtPolicyType.Text = taskControl.PolicyType;
                TxtSufijo.Text = taskControl.Suffix;
                TxtAnniversary.Text = taskControl.Anniversary;
                txtApplicationID.Text = taskControl.ApplicationID.ToString();
                TxtTerm.Text = taskControl.Term.ToString();
                TxtRetroactiveDate.Text = taskControl.RetroactiveDate;
                txtEffDt.Text = taskControl.EffectiveDate;

                if (taskControl.CancellationDate == String.Empty)
                    txtExpDt.Text = taskControl.ExpirationDate;
                else
                {
                    txtExpDt.Text = taskControl.CancellationDate;
                    Label11.Text = "Canc. Date";
                }
                txtEntryDate.Text = taskControl.EntryDate.ToShortDateString();
                TxtCharge.Text = taskControl.Charge.ToString("###,##0.00");
                TxtPremium.Text = taskControl.TotalPremium.ToString("###,##0.00");
                TxtTotalPremium.Text = (taskControl.Charge + taskControl.TotalPremium).ToString("###,##0.00");

                TxtComments.Text = taskControl.Comments.ToString();
                ChkAutoAssignPolicy.Checked = taskControl.AutoAssignPolicy;
                chkPending.Checked = taskControl.Pending;

                txtPriCarierName1.Text = taskControl.PriCarierName1;
                txtPriPolEffecDate1.Text = taskControl.PriPolEffecDate1;
                txtPriPolLimits1.Text = taskControl.PriPolLimits1;
                txtPriClaims1.Text = taskControl.PriClaims1;

                if (taskControl.PolicyType.Trim() == "PE")
                    lblCarrier.Text = "Primary Carrier Name";
                else
                    lblCarrier.Text = "Excess Carrier Name";

                if (taskControl.PRMedicRATEID != 0)
                {
                    for (int i = 0; i < ddlRate.Items.Count; i++)
                    {
                        if (ddlRate.Items[i].Value.Trim() != "")
                        {
                            string[] array = ddlRate.Items[i].Value.Split('|');
                            if (taskControl.PRMedicRATEID == int.Parse(array[0]))
                            {
                                ddlRate.SelectedIndex = ddlRate.Items.IndexOf(
                                ddlRate.Items.FindByValue(ddlRate.Items[i].Value));
                            }
                        }
                    }
                }

                txtIsoCode.Text = taskControl.IsoCode;
                txtClass.Text = taskControl.Class;
                txtRate1.Text = taskControl.RateYear1.ToString("###,##0.00");
                txtRate2.Text = taskControl.RateYear2.ToString("###,##0.00");
                txtRate3.Text = taskControl.RateYear3.ToString("###,##0.00");
                txtRate4.Text = taskControl.MCMRate.ToString("###,##0.00");

                taskControl.InvoiceNumber = "0"; //Discount
                if (taskControl.Bank != "000") //Bank = Group
                {
                    EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                    master = master.GetMasterPolicyDiscount(taskControl.Bank, taskControl.EffectiveDate);

                    if (taskControl.PolicyType.Trim() == "PE") //Excess
                    {
                        taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                        txtRate1.Text = Math.Round(taskControl.RateYear1 - (taskControl.RateYear1 * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
                        txtRate2.Text = Math.Round(taskControl.RateYear2 - (taskControl.RateYear2 * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
                        txtRate3.Text = Math.Round(taskControl.RateYear3 - (taskControl.RateYear3 * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
                        txtRate4.Text = Math.Round(taskControl.MCMRate - (taskControl.MCMRate * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
                    }
                    else // Primary
                    {
                        taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                        txtRate1.Text = Math.Round(taskControl.RateYear1 - (taskControl.RateYear1 * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
                        txtRate2.Text = Math.Round(taskControl.RateYear2 - (taskControl.RateYear2 * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
                        txtRate3.Text = Math.Round(taskControl.RateYear3 - (taskControl.RateYear3 * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
                        txtRate4.Text = Math.Round(taskControl.MCMRate - (taskControl.MCMRate * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
                    }
                }
                txtInvoiceNumber.Text = taskControl.InvoiceNumber;

                //txtRateTN1.Text = taskControl.RateTN1.ToString("###,##0");
                //txtRateTN2.Text = taskControl.RateTN2.ToString("###,##0");
                //txtRateTN3.Text = taskControl.RateTN3.ToString("###,##0");
                //txtRateTN4.Text = taskControl.RateTN4.ToString("###,##0");
                //txtRateTN5.Text = taskControl.RateTN5.ToString("###,##0");
                //txtRateTN6.Text = taskControl.RateTN6.ToString("###,##0");
                txtPrimaryTN1.Text = taskControl.PrimaryTN1.ToString("###,##0.00");
                txtPrimaryTN2.Text = taskControl.PrimaryTN2.ToString("###,##0.00");
                txtPrimaryTN3.Text = taskControl.PrimaryTN3.ToString("###,##0.00");
                txtPrimaryTN4.Text = taskControl.PrimaryTN4.ToString("###,##0.00");
                txtPrimaryTN5.Text = taskControl.PrimaryTN5.ToString("###,##0.00");
                txtPremiumTN1.Text = taskControl.PremiumTN1.ToString("###,##0.00");
                txtPremiumTN2.Text = taskControl.PremiumTN2.ToString("###,##0.00");
                txtPremiumTN3.Text = taskControl.PremiumTN3.ToString("###,##0.00");
                txtPremiumTN4.Text = taskControl.PremiumTN4.ToString("###,##0.00");
                txtPremiumTN5.Text = taskControl.PremiumTN5.ToString("###,##0.00");
                txtQuantityTN1.Text = taskControl.QuantityTN1.ToString();
                txtQuantityTN2.Text = taskControl.QuantityTN2.ToString();
                txtQuantityTN3.Text = taskControl.QuantityTN3.ToString();
                txtQuantityTN4.Text = taskControl.QuantityTN4.ToString();
                txtQuantityTN5.Text = taskControl.QuantityTN5.ToString();
                txtQuantityTN6.Text = taskControl.QuantityTN6.ToString();
                txtTotPremTN1.Text = taskControl.TotPremTN1.ToString("###,##0.00");
                txtTotPremTN2.Text = taskControl.TotPremTN2.ToString("###,##0.00");
                txtTotPremTN3.Text = taskControl.TotPremTN3.ToString("###,##0.00");
                txtTotPremTN4.Text = taskControl.TotPremTN4.ToString("###,##0.00");
                txtTotPremTN5.Text = taskControl.TotPremTN5.ToString("###,##0.00");
                txtTotPremTN6.Text = taskControl.TotPremTN6.ToString("###,##0.00");

                //txtERateTN1.Text = taskControl.ERateTN1.ToString("###,##0");
                //txtERateTN2.Text = taskControl.ERateTN2.ToString("###,##0");
                //txtERateTN3.Text = taskControl.ERateTN3.ToString("###,##0");
                //txtERateTN4.Text = taskControl.ERateTN4.ToString("###,##0");
                //txtERateTN5.Text = taskControl.ERateTN5.ToString("###,##0");
                //txtERateTN6.Text = taskControl.ERateTN6.ToString("###,##0");
                txtExcessTN1.Text = taskControl.ExcessTN1.ToString("###,##0.00");
                txtExcessTN2.Text = taskControl.ExcessTN2.ToString("###,##0.00");
                txtExcessTN3.Text = taskControl.ExcessTN3.ToString("###,##0.00");
                txtExcessTN4.Text = taskControl.ExcessTN4.ToString("###,##0.00");
                txtExcessTN5.Text = taskControl.ExcessTN5.ToString("###,##0.00");
                txtEPremiumTN1.Text = taskControl.EPremiumTN1.ToString("###,##0.00");
                txtEPremiumTN2.Text = taskControl.EPremiumTN2.ToString("###,##0.00");
                txtEPremiumTN3.Text = taskControl.EPremiumTN3.ToString("###,##0.00");
                txtEPremiumTN4.Text = taskControl.EPremiumTN4.ToString("###,##0.00");
                txtEPremiumTN5.Text = taskControl.EPremiumTN5.ToString("###,##0.00");
                txtEQuantityTN1.Text = taskControl.EQuantityTN1.ToString();
                txtEQuantityTN2.Text = taskControl.EQuantityTN2.ToString();
                txtEQuantityTN3.Text = taskControl.EQuantityTN3.ToString();
                txtEQuantityTN4.Text = taskControl.EQuantityTN4.ToString();
                txtEQuantityTN5.Text = taskControl.EQuantityTN5.ToString();
                txtEQuantityTN6.Text = taskControl.EQuantityTN6.ToString();
                txtETotPremTN1.Text = taskControl.ETotPremTN1.ToString("###,##0.00");
                txtETotPremTN2.Text = taskControl.ETotPremTN2.ToString("###,##0.00");
                txtETotPremTN3.Text = taskControl.ETotPremTN3.ToString("###,##0.00");
                txtETotPremTN4.Text = taskControl.ETotPremTN4.ToString("###,##0.00");
                txtETotPremTN5.Text = taskControl.ETotPremTN5.ToString("###,##0.00");
                txtETotPremTN6.Text = taskControl.ETotPremTN6.ToString("###,##0.00");

                txtTotalPrimary.Text = taskControl.TotalPrimary.ToString("###,##0.00");
                txtTotalExcess.Text = taskControl.TotalExcess.ToString("###,##0.00");

                //btnEnablePrint.Visible = taskControl.PrintPolicy;

                //if (double.Parse(txtTotalExcess.Text) != 0.0 || double.Parse(txtTotalPrimary.Text) != 0.0)
                //{

                //    if (taskControl.PolicyType.Trim() == "PP")
                //        TxtTotalPremium.Text = txtTotalPrimary.Text;
                //    else
                //        TxtTotalPremium.Text = txtTotalExcess.Text;
                //}
                //else
                //    TxtTotalPremium.Text = (taskControl.TotalPremium + taskControl.Charge).ToString("###,###.00");
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

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("A problem occured while assigning data to webpage controls.");
                this.litPopUp.Visible = true;
            }
        }
        private void EnableControls()
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

            //btnAdd2.Visible = false;
            //btnNew.Visible = false;
            //btnEdit.Visible = false;
            BtnExit.Visible = false;
            BtnSave.Visible = true;
            //btnAddEndorsement.Visible = true;
            //BtnCancelEndorsement.Visible = true;
            //btnEnablePrint.Visible = false;
            //btnChargeCalc.Visible = true;
            //btnCancel.Visible = true;
            //btnDelete.Visible = false;
            //btnHistory.Visible = false;
            //btnPrintPolicy.Visible = false;
            //btnPrintCertificate.Visible = false;
            //btnPayments.Visible = false;
            //btnComissions.Visible = false;
            //btnReinstatement.Visible = false;
            //btnCancellation.Visible = false;
            //btnFinancialCanc.Visible = false;
            //btnPolicyCert.Visible = false;
            //btnRenew.Visible = false;
            cmdRemove.Enabled = true;
            cmdSelect.Enabled = true;
            //btnRate.Visible = true;
            //btnPolicyCert.Visible = false;

            //DtSearchPayments.Visible = false;

            if (userID == 156) //Temp Override for Kayla
            {
                TxtCustomerNo.Enabled = true;
                txtExpDt.Enabled = true;
                txtExpDt.ForeColor = System.Drawing.ColorTranslator.FromHtml("Black");
            }

            if (taskControl.CancellationDate != String.Empty)
                Label11.Text = "Canc. Date";

            TxtFirstName.Enabled = true;
            TxtInitial.Enabled = true;
            txtLastname1.Enabled = true;
            txtLastname2.Enabled = true;
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
            TxtPolicyNo.Enabled = true;
            TxtCertificate.Enabled = true;
            TxtPolicyType.Enabled = true;
            TxtSufijo.Enabled = true;
            TxtAnniversary.Enabled = true;
            txtApplicationID.Enabled = false;
            TxtTerm.Enabled = true;

            txtPriCarierName1.Enabled = true;
            txtPriPolEffecDate1.Enabled = true;
            txtPriPolLimits1.Enabled = true;
            txtPriClaims1.Enabled = true;

            ddlGroup.Visible = false;
            ddlCorparation.Visible = false;
            ddlGroup.Enabled = false;
            ddlCorparation.Enabled = false;
            ddlFinancial.Enabled = false;
            ddlOtherSpecialty.Enabled = false;
            chkPaymentGA.Enabled = false;
            Label28.Visible = false;
            Label42.Visible = false;

            //txtEndorseNo.Enabled       = true;
            //txtEndorsePrepDate.Enabled = true;
            //txtEndorseEffDt.Enabled    = true;
            //txtEndorsePrem.Enabled     = true;
            //txtEndorseComment.Enabled  = true;
            //ddlEndorsementType.Enabled = true;

            //DtEndorsementGrid.Columns[0].Visible = true;
            //DtEndorsementGrid.Columns[9].Visible = true;

            if (!cp.IsInRole("ADMINISTRATOR"))
            {
                if (taskControl.Mode == 1)
                    TxtRetroactiveDate.Enabled = true;
                else
                {
                    TxtRetroactiveDate.Enabled = false;
                }

                txtEntryDate.Enabled = false;
                ddlGroup.Enabled = false;
                ddlCorparation.Enabled = false;
                ddlGroup.Visible = false;
                ddlCorparation.Visible = false;
                ddlFinancial.Enabled = false;
                ddlOtherSpecialty.Enabled = false;
                chkPaymentGA.Enabled = false;
                Label28.Visible = false;
                Label42.Visible = false;
                lblDiscount.Visible = false;
                txtInvoiceNumber.Visible = false;
                txtInvoiceNumber.Enabled = false;
            }
            else
            {
                TxtRetroactiveDate.Enabled = true;
                txtEntryDate.Enabled = true;
                ddlGroup.Visible = true;
                ddlCorparation.Visible = true;
                ddlGroup.Enabled = true;
                ddlCorparation.Enabled = true;
                ddlFinancial.Enabled = true;
                ddlOtherSpecialty.Enabled = true;
                chkPaymentGA.Enabled = true;
                Label28.Visible = true;
                Label42.Visible = true;
                lblDiscount.Visible = true;
                txtInvoiceNumber.Visible = true;
                txtInvoiceNumber.Enabled = true;
            }

            txtEffDt.Enabled = true;
            //txtExpDt.Enabled = true;

            TxtCharge.Enabled = true;
            TxtPremium.Enabled = true;
            TxtTotalPremium.Enabled = true;
            TxtComments.Enabled = true;

            txtClass.Enabled = true;
            txtIsoCode.Enabled = true;
            txtRate1.Enabled = false;
            txtRate2.Enabled = false;
            txtRate3.Enabled = false;
            txtRate4.Enabled = false;
            //Panel1.Visible = false;
            ddlRate.Enabled = true;
            chkPending.Enabled = true;

            ddlAvailableAgent.Enabled = true;
            ddlSelectedAgent.Enabled = true;

            ddlOriginatedAt.Enabled = true;
            ddlInsuranceCompany.Enabled = true;
            ddlAgency.Enabled = true;
            ddlAgent.Enabled = true;
            ddlSupplier.Enabled = true;
            ddlPolicyClass.Enabled = false;
            ddlFinancial.Enabled = true;
            ddlOtherSpecialty.Enabled = true;
            chkPaymentGA.Enabled = true;
            //ddlCiudad.Enabled = true;
            ddlPrMedicalLimits.Enabled = true;

            ChkAutoAssignPolicy.Enabled = true;

            VerifyAssignPolicyFields();

            //Si es para editar la poliza el usuario no podra cambiar el tipo de negocio.
            if (taskControl.Mode != 1)
                ddlPolicyClass.Enabled = false;

            //if (taskControl.PolicyType.Trim() == "PP")
            //    btnPrintCertificate.Visible = true;
            //else btnPrintCertificate.Visible = false;
            //Si esta pagada la poliza no dispone el policyType, la agencia, agentes y supplier y el totalPremium + Charge.
            //if ((double)taskControl.PaymentsDetail.TotalPaid > 0 && (double)taskControl.PaymentsDetail.TotalPaid >= taskControl.TotalPremium + taskControl.Charge)
            //{
            //    cmdRemove.Enabled = false;
            //    cmdSelect.Enabled = false;
            //    ddlAvailableAgent.Enabled = false;
            //    ddlSelectedAgent.Enabled = false;
            //    ddlAgency.Enabled = false;
            //    ddlAgent.Enabled = false;
            //    ddlSupplier.Enabled = false;
            //    ddlPolicyClass.Enabled = false;
            //    ddlBank.Enabled = false;
            //    ddlCompanyDealer.Enabled = false;
            //    ddlInsuranceCompany.Enabled = false;
            //    TxtTotalPremium.Enabled = true;
            //    TxtCharge.Enabled = false;
            //}

            if (taskControl.PolicyType.Trim() == "PP")
            {
                Label52.Visible = true;
                Label70.Visible = true;
                txtTotalPrimary.Visible = true;
                pnlPrimary.Visible = true;

                Label52.Enabled = true;
                Label70.Enabled = true;
                txtTotalPrimary.Enabled = true;
                pnlPrimary.Enabled = true;

                Label64.Visible = false;
                Label71.Visible = false;
                txtTotalExcess.Visible = false;
                pnlExcess.Visible = false;

                Button3.Visible = true;
            }
            else
            {
                Label52.Visible = false;
                Label70.Visible = false;
                txtTotalPrimary.Visible = false;
                pnlPrimary.Visible = false;

                Label64.Visible = true;
                Label71.Visible = true;
                txtTotalExcess.Visible = true;
                pnlExcess.Visible = true;

                Label64.Enabled = true;
                Label71.Enabled = true;
                txtTotalExcess.Enabled = true;
                pnlExcess.Enabled = true;

                Button3.Visible = true;
                //btnPrintCertificate.Visible = false;
            }      

            GetOthersRates();

            DisableControlsTail();

        }
        private void DisableControls()
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

            //btnAdd2.Visible = false;
            //btnNew.Visible = false;
            //btnEdit.Visible = true;
            BtnExit.Visible = true;
            //btnDelete.Visible = true;
            //btnCancel.Visible = false;
            //btnAddEndorsement.Visible = false;
            //BtnCancelEndorsement.Visible = false;
            //btnHistory.Visible = true;
            //btnPrintPolicy.Visible = true;
            //btnPrintCertificate.Visible = true;
            //btnPayments.Visible = true;
            //btnComissions.Visible = true;
            //btnReinstatement.Visible = true;
            //btnCancellation.Visible = true;
            //btnFinancialCanc.Visible = true;
            //btnPolicyCert.Visible = true;
            //btnRenew.Visible = true;
            cmdRemove.Enabled = false;
            cmdSelect.Enabled = false;
            //btnRate.Visible = true;
            //btnPrintCertificate.Visible = true;
            //btnTailQuote.Visible = true;
            //btnRefresh.Visible = false;
            //btnPolicyCert.Visible = false;

            //if (taskControl.Anniversary == "01")
            //    btnEnablePrint.Visible = true;
            //else
            //    btnEnablePrint.Visible = false;

            //if (userID == 1 || userID == 2 || userID == 13 || userID == 156 || userID == 225) 
            //{
            //    btnEnablePrint.Visible = true;//btnPolicyCert.Visible = true;
            //}

            //DtSearchPayments.Visible = true;

            TxtCustomerNo.Enabled = false;
            TxtFirstName.Enabled = false;
            TxtInitial.Enabled = false;
            txtLastname1.Enabled = false;
            txtLastname2.Enabled = false;
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
            TxtPolicyNo.Enabled = false;
            TxtCertificate.Enabled = false;
            TxtPolicyType.Enabled = false;
            TxtSufijo.Enabled = false;
            TxtAnniversary.Enabled = false;
            txtApplicationID.Enabled = false;
            TxtTerm.Enabled = false;
            TxtRetroactiveDate.Enabled = false;
            txtEffDt.Enabled = false;
            txtExpDt.Enabled = false;
            txtEntryDate.Enabled = false;
            TxtCharge.Enabled = false;
            TxtPremium.Enabled = false;
            TxtTotalPremium.Enabled = false;
            TxtComments.Enabled = false;

            txtPriCarierName1.Enabled = false;
            txtPriPolEffecDate1.Enabled = false;
            txtPriPolLimits1.Enabled = false;
            txtPriClaims1.Enabled = false;

            txtClass.Enabled = false;
            txtIsoCode.Enabled = false;
            txtRate1.Enabled = false;
            txtRate2.Enabled = false;
            txtRate3.Enabled = false;
            txtRate4.Enabled = false;
            chkPending.Enabled = false;

            ddlRate.Enabled = false;
            ddlAvailableAgent.Enabled = false;
            ddlSelectedAgent.Enabled = false;
            ddlOriginatedAt.Enabled = false;
            ddlInsuranceCompany.Enabled = false;
            ddlAgency.Enabled = false;
            ddlAgent.Enabled = false;
            ddlSupplier.Enabled = false;
            ddlPolicyClass.Enabled = false;
            ddlFinancial.Enabled = false;
            ddlOtherSpecialty.Enabled = false;
            chkPaymentGA.Enabled = false;
            //ddlCiudad.Enabled = false;
            ddlPrMedicalLimits.Enabled = false;
            ddlGroup.Enabled = false;
            ddlCorparation.Enabled = false;
            txtInvoiceNumber.Enabled = false;


            //txtEndorseNo.Enabled = false;
            //txtEndorsePrepDate.Enabled = false;
            //txtEndorseEffDt.Enabled = false;
            //txtEndorsePrem.Enabled = false;
            //txtEndorseComment.Enabled = false;
            //ddlEndorsementType.Enabled = false;

            //DtEndorsementGrid.Columns[0].Visible = false;
            //DtEndorsementGrid.Columns[9].Visible = false;

            if (!cp.IsInRole("ADMINISTRATOR"))
            {
                ddlGroup.Visible = false;
                ddlCorparation.Visible = false;
                lblDiscount.Visible = false;
                txtInvoiceNumber.Visible = false;
                Label28.Visible = false;
                Label42.Visible = false;
            }
            else
            {
                ddlGroup.Visible = true;
                ddlCorparation.Visible = true;
                lblDiscount.Visible = true;
                txtInvoiceNumber.Visible = true;
                Label28.Visible = true;
                Label42.Visible = true;
            }

            ChkAutoAssignPolicy.Enabled = false;

            if (taskControl.PolicyType.Trim() == "PP")
            {
                Label52.Visible = true;
                Label70.Visible = true;
                txtTotalPrimary.Visible = true;
                pnlPrimary.Visible = true;

                Label52.Enabled = false;
                Label70.Enabled = false;
                txtTotalPrimary.Enabled = false;
                pnlPrimary.Enabled = false;

                Label64.Visible = false;
                Label71.Visible = false;
                txtTotalExcess.Visible = false;
                pnlExcess.Visible = false;

                Button3.Visible = false;
            }
            else
            {
                Label52.Visible = false;
                Label70.Visible = false;
                txtTotalPrimary.Visible = false;
                pnlPrimary.Visible = false;

                Label64.Visible = true;
                Label71.Visible = true;
                txtTotalExcess.Visible = true;
                pnlExcess.Visible = true;

                Label64.Enabled = false;
                Label71.Enabled = false;
                txtTotalExcess.Enabled = false;
                pnlExcess.Enabled = false;

                Button3.Visible = false;
                //btnPrintCertificate.Visible = false;
            }

            if (taskControl.CancellationDate != String.Empty)
                Label11.Text = "Canc. Date";

            VerifyAccess();
            BtnSave.Visible = false;
            //btnChargeCalc.Visible = false;

            DisableControlsTail();
        }
        private void RemoveSessionLookUp()
        {
            Session.Remove("LookUpTables");
        }
        protected void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
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

                //try
                //{
                ValidateFields();

                FillProperties();
                //TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

                //taskControl.SavePolicies(userID);  //(userID);

                ////Update Inception Payment Amount
                //UpdateInceptionPartialPayments(taskControl.TaskControlID, (taskControl.TotalPremium + taskControl.Charge));

                FillTextControl();
                DisableControls();

                Session.Remove("DtPolicyDetail");

                //Session.Add("TaskControl",taskControl);
                //Session.Remove("TaskControl");
                //Session["EndorsementQuote"] = taskControl;

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy information saved successfully.");
                this.litPopUp.Visible = true;
                //}
                //catch (Exception exp)
                //{
                //this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to save this Policy. " + exp.Message);
                //this.litPopUp.Visible = true;
                //}
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

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to save policy.  Please verify and try again.");
                this.litPopUp.Visible = true;
            }
        }
        private void ValidateFields()
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = 0;
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

            ArrayList errorMessages = new ArrayList();

            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

            try
            {
                if (taskControl.PolicyClassID == 9) //PRMedical
                {
                    if (DateTime.Parse(this.txtEffDt.Text) < DateTime.Today)
                    {
                        DateTime date = DateTime.Parse(this.txtEffDt.Text).AddDays(30);
                        if (date < DateTime.Today)
                        {
                            if (!cp.IsInRole("GAPPOLICIESEFFECTIVEDATERETRO") && !cp.IsInRole("ADMINISTRATOR"))
                            {
                                errorMessages.Add("Effective date cannot be older than 30 days retroactive." + "\r\n");
                            }
                        }
                    }

                    if (ddlPrMedicalLimits.SelectedItem.Value.Trim() == "")
                        errorMessages.Add("The Limit is missing or wrong." + "\r\n");
                }

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
            try
            {
                TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                taskControl.LbxAgentSelected = ddlSelectedAgent;
                if (ddlSelectedAgent.Items.Count != 0)
                {
                    //taskControl.Policy.Agent = ddlSelectedAgent.Items[0].Value.Split("|".ToCharArray())[1];
                    taskControl.Agent = ddlSelectedAgent.Items[0].Value.Split("|".ToCharArray())[1];
                }
                else
                {
                    taskControl.Agent = "000";
                }

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

                //Group
                if (ddlGroup.SelectedIndex > 0 && ddlGroup.SelectedItem != null)
                    taskControl.Bank = ddlGroup.SelectedItem.Value;
                else
                    taskControl.Bank = "000";

                //Corporation
                if (ddlCorparation.SelectedIndex > 0 && ddlCorparation.SelectedItem != null)
                    taskControl.CompanyDealer = ddlCorparation.SelectedItem.Value;
                else
                    taskControl.CompanyDealer = "000";

                //Rate
                //if (ddlRate.SelectedIndex > 0 && ddlRate.SelectedItem != null)
                //    taskControl.PRMedicRATEID = int.Parse(ddlRate.SelectedItem.Value);
                //else
                //    taskControl.PRMedicRATEID = 0;

                //Supplier
                //if (taskControl.PolicyClassID == 1) //VSC
                //{
                //    ddlSupplier.SelectedIndex = int.Parse(this.inputSupplierIndex.Value);
                //}

                if (ddlSupplier.SelectedIndex > 0 && ddlSupplier.SelectedItem != null)
                {
                    //ListItem list = new ListItem(ddlSupplier.SelectedItem.Value+" |"+ddlSupplier.SelectedItem.Value,ddlSupplier.SelectedItem.Value+" |"+ddlSupplier.SelectedItem.Value);

                    ListItem list = new ListItem("1" + " |" + ddlSupplier.SelectedItem.Value, "1" + " |" + ddlSupplier.SelectedItem.Value);
                    ListBox ls = new ListBox();
                    taskControl.LbxSupplierSelected = ls;
                    taskControl.LbxSupplierSelected.Items.Add(list);

                    //Verifica si existen mas Supplier en la tabla de GroupSupplier con el MasterSupplier.
                    DataTable dt = LookupTables.Supplier.GetGroupSupplierBySupplierID(ddlSupplier.SelectedItem.Value.Trim());

                    int level = 3;
                    if (dt.Rows.Count != 0)
                    {
                        for (int a = 0; a <= dt.Rows.Count - 1; a++)
                        {
                            if (a == 0)
                            {
                                list = new ListItem("2" + " |" + dt.Rows[a]["SupplierID"].ToString(), "2" + " |" + dt.Rows[a]["SupplierID"].ToString());
                            }
                            else
                            {
                                list = new ListItem(level.ToString() + " |" + dt.Rows[a]["SupplierID"].ToString(), level.ToString() + " |" + dt.Rows[a]["SupplierID"].ToString());
                                level = level + 1;
                            }
                            taskControl.LbxSupplierSelected.Items.Add(list);
                        }
                    }

                    taskControl.SupplierID = ddlSupplier.SelectedItem.Value;
                }
                else
                {
                    taskControl.SupplierID = "000";
                }

                //InsuranceCompany
                if (ddlInsuranceCompany.SelectedIndex > 0 && ddlInsuranceCompany.SelectedItem != null)
                    taskControl.InsuranceCompany = ddlInsuranceCompany.SelectedItem.Value;
                else
                    taskControl.InsuranceCompany = "000";

                ////Bank
                //if (ddlBank.SelectedIndex > 0 && ddlBank.SelectedItem != null)
                //    taskControl.Bank = ddlBank.SelectedItem.Value;
                //else
                //    taskControl.Bank = "000";

                //CompanyDealer
                if (ddlCorparation.SelectedIndex > 0 && ddlCorparation.SelectedItem != null)
                    taskControl.CompanyDealer = ddlCorparation.SelectedItem.Value;
                else
                    taskControl.CompanyDealer = "000";

                if (taskControl.IsMaster)
                {
                    LookupTables.CompanyDealer dealer = new LookupTables.CompanyDealer();
                    dealer = dealer.GetCompanyDealer(taskControl.CompanyDealer);

                    taskControl.MasterPolicyID = dealer.MasterPolicyID;
                }

                //Originated At
                if (ddlOriginatedAt.SelectedIndex > 0 && ddlOriginatedAt.SelectedItem != null)
                {
                    taskControl.OriginatedAt = int.Parse(ddlOriginatedAt.SelectedItem.Value.ToString());
                }

                //Financial
                if (ddlFinancial.SelectedIndex > 0 && ddlFinancial.SelectedItem != null)
                {
                    taskControl.FinancialID = int.Parse(ddlFinancial.SelectedItem.Value.ToString());
                }
                else { taskControl.FinancialID = 0; }

                //OtherSpecialty
                if (ddlOtherSpecialty.SelectedIndex > 0 && ddlOtherSpecialty.SelectedItem != null)
                {
                    taskControl.OtherSpecialtyID = int.Parse(ddlOtherSpecialty.SelectedItem.Value.ToString());
                }
                else { taskControl.OtherSpecialtyID = 0; }

                //Check Payments by GA
                taskControl.Notification30Flag = chkPaymentGA.Checked;
                taskControl.Notification15Flag = chkPaymentGA.Checked;
                taskControl.CancellationFlag = chkPaymentGA.Checked;


                //PolicyClass
                if (ddlPolicyClass.SelectedIndex > 0 && ddlPolicyClass.SelectedItem != null)
                {
                    taskControl.PolicyClassID = int.Parse(ddlPolicyClass.SelectedItem.Value.ToString());
                }

                //PrMedicalLimits
                if (ddlPrMedicalLimits.SelectedIndex > 0 && ddlPrMedicalLimits.SelectedItem != null)
                {
                    taskControl.PRMedicalLimit = int.Parse(ddlPrMedicalLimits.SelectedItem.Value.ToString());
                }

                //Ciudad
                //if (ddlCiudad.SelectedIndex > 0 && ddlCiudad.SelectedItem != null)
                //    taskControl.Customer.City = ddlCiudad.SelectedItem.Text;
                //else
                //    taskControl.Customer.City = "";

                taskControl.TaskControlID = int.Parse(LblControlNo.Text.Trim());
                taskControl.Customer.CustomerNo = TxtCustomerNo.Text.Trim();
                taskControl.Customer.FirstName = TxtFirstName.Text.ToUpper().Trim();
                taskControl.Customer.Initial = TxtInitial.Text.ToUpper().Trim();
                taskControl.Customer.LastName1 = txtLastname1.Text.ToUpper().Trim();
                taskControl.Customer.LastName2 = txtLastname2.Text.ToUpper().Trim();
                taskControl.Customer.Address1 = TxtAddrs1.Text.ToUpper().Trim();
                taskControl.Customer.Address2 = TxtAddrs2.Text.ToUpper().Trim();
                taskControl.Customer.City = TxtCity.Text.ToUpper().Trim();
                taskControl.Customer.State = TxtState.Text.ToUpper().Trim();
                taskControl.Customer.ZipCode = TxtZip.Text.ToUpper().Trim();
                taskControl.Customer.SocialSecurity = txtSocialSecurity.Text.Trim();
                taskControl.Customer.HomePhone = txtHomePhone.Text.Trim();
                taskControl.Customer.JobPhone = txtWorkPhone.Text.Trim();
                taskControl.Customer.Cellular = TxtCellular.Text.Trim();
                taskControl.Customer.Email = txtEmail.Text.Trim();
                taskControl.Customer.License = txtLicense.Text.Trim();

                taskControl.PolicyNo = TxtPolicyNo.Text.Trim().ToUpper().Replace(" ", "");
                taskControl.Certificate = TxtCertificate.Text.Trim().ToUpper();
                taskControl.PolicyType = TxtPolicyType.Text.Trim().ToUpper();
                taskControl.Suffix = TxtSufijo.Text.Trim();
                taskControl.Anniversary = TxtAnniversary.Text.Trim();
                taskControl.Term = int.Parse(TxtTerm.Text.Trim());
                taskControl.EffectiveDate = txtEffDt.Text.Trim();
                taskControl.Pending = chkPending.Checked;

                taskControl.PriCarierName1 = txtPriCarierName1.Text.Trim().ToUpper();
                taskControl.PriPolEffecDate1 = txtPriPolEffecDate1.Text.Trim().ToUpper();
                taskControl.PriPolLimits1 = txtPriPolLimits1.Text.Trim().ToUpper();
                taskControl.PriClaims1 = txtPriClaims1.Text.Trim().ToUpper();


                taskControl.RetroactiveDate = TxtRetroactiveDate.Text;
                //if (taskControl.Anniversary == "01") //Siempre el retroactive date es la misma fecha para todos los aniversarios.
                //    taskControl.RetroactiveDate = taskControl.EffectiveDate;
                //else
                //    taskControl.RetroactiveDate = taskControl.RetroactiveDate;

                //if (this.txtExpDt.Text.Trim() == string.Empty) // && this.TxtTerm.Text.Trim() != string.Empty)
                // && this.TxtTerm.Text.Trim() != string.Empty)

                if (taskControl.CancellationDate == String.Empty)
                {
                    if (userID == 156) //txtExpDt Override for Kayla
                    {
                        taskControl.ExpirationDate = DateTime.Parse(this.txtExpDt.Text).ToShortDateString();
                    }
                    else if (taskControl.ExpirationDate.Trim() == string.Empty)
                    {
                        if (this.TxtTerm.Text.Trim() == string.Empty)
                        {
                            this.TxtTerm.Text = "0";
                        }
                        taskControl.ExpirationDate = DateTime.Parse(this.txtEffDt.Text).AddMonths(int.Parse(this.TxtTerm.Text.Trim())).ToShortDateString();
                        this.txtExpDt.Text = taskControl.ExpirationDate;
                    }
                    else
                    {
                        if (this.txtExpDt.Text.Trim() != string.Empty)
                        {
                            taskControl.ExpirationDate = DateTime.Parse(this.txtEffDt.Text).AddMonths(int.Parse(this.TxtTerm.Text.Trim())).ToShortDateString();
                            this.txtExpDt.Text = taskControl.ExpirationDate;
                        }
                    }
                }
                taskControl.EntryDate = DateTime.Parse(txtEntryDate.Text);
                taskControl.Class = txtClass.Text.Trim();
                taskControl.IsoCode = txtIsoCode.Text.Trim();

                //if (txtRate1.Text.Trim() == "")
                //    taskControl.RateYear1 = 0.00;
                //else
                //    taskControl.RateYear1 = double.Parse(txtRate1.Text.ToString().Trim());

                //if (txtRate2.Text.Trim() == "")
                //    taskControl.RateYear2 = 0.00;
                //else
                //    taskControl.RateYear2 = double.Parse(txtRate2.Text.ToString().Trim());

                //if (txtRate3.Text.Trim() == "")
                //    taskControl.RateYear3 = 0.00;
                //else
                //    taskControl.RateYear3 = double.Parse(txtRate3.Text.ToString().Trim());

                //if (txtRate4.Text.Trim() == "")
                //    taskControl.MCMRate = 0.00;
                //else
                //    taskControl.MCMRate = double.Parse(txtRate4.Text.ToString().Trim());

                if (TxtCharge.Text.Trim() == "")
                    taskControl.Charge = 0.00;
                else
                    taskControl.Charge = double.Parse(TxtCharge.Text.ToString().Trim());

                if (TxtPremium.Text.Trim() == "")
                    taskControl.TotalPremium = 0.00;
                else
                    taskControl.TotalPremium = double.Parse(TxtPremium.Text.ToString().Trim());

                if (TxtCharge.Text.Trim() == "")
                    taskControl.Charge = 0.00;
                else
                    taskControl.Charge = double.Parse(TxtCharge.Text.ToString().Trim());

                //if (!TxtPolicyType.Text.Contains("T"))
                //{
                //    int RetroYear = 0;
                //    RetroYear = DateTime.Parse(taskControl.EffectiveDate).Year - DateTime.Parse(taskControl.RetroactiveDate).Year;
                //    switch (RetroYear)
                //    {
                //        case 0:
                //            taskControl.TotalPremium = taskControl.RateYear1;
                //            break;
                //        case 1:
                //            taskControl.TotalPremium = taskControl.RateYear2;
                //            break;
                //        case 2:
                //            taskControl.TotalPremium = taskControl.RateYear3;
                //            break;
                //        default:
                //            taskControl.TotalPremium = taskControl.MCMRate;
                //            break;
                //    }
                //}

                //Aplicar Descuento de Grupo en la renovacion.
                //debe cunplir con la cuota de Members
                //taskControl.InvoiceNumber = "0"; //Discount
                //if (taskControl.Bank != "000") //Bank = Group
                //{
                //    EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                //    master = master.GetMasterPolicyDiscount(taskControl.Bank, taskControl.EffectiveDate);

                //    if (taskControl.PolicyType.Trim() == "PE") //Excess
                //    {
                //        taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                //        double totprem = Math.Round(taskControl.TotalPremium - (taskControl.TotalPremium * (Math.Round(master.DescuentoExcess / 100, 2))), 0);
                //        taskControl.TotalPremium = totprem;
                //    }
                //    else // Primary
                //    {
                //        taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                //        double totprem = Math.Round(taskControl.TotalPremium - (taskControl.TotalPremium * (Math.Round(master.DescuentoPrimario / 100, 2))), 0);
                //        taskControl.TotalPremium = totprem;
                //    }
                //}

                //if (taskControl.Bank != "000") //Revert Discount changes to Rates.
                //{
                //    EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                //    master = master.GetMasterPolicyDiscount(taskControl.Bank, taskControl.EffectiveDate);

                //    taskControl.RateYear1 = Math.Round(taskControl.RateYear1 + (taskControl.RateYear1 * (Math.Round(master.DescuentoPrimario / 100, 2))), 0);
                //    taskControl.RateYear2 = Math.Round(taskControl.RateYear2 + (taskControl.RateYear2 * (Math.Round(master.DescuentoPrimario / 100, 2))), 0);
                //    taskControl.RateYear3 = Math.Round(taskControl.RateYear3 + (taskControl.RateYear3 * (Math.Round(master.DescuentoPrimario / 100, 2))), 0);
                //    taskControl.MCMRate = Math.Round(taskControl.MCMRate + (taskControl.MCMRate * (Math.Round(master.DescuentoPrimario / 100, 2))), 0);      
                //}

                taskControl.Comments = TxtComments.Text.Trim().ToUpper();
                if (ChkAutoAssignPolicy.Checked)
                    taskControl.AutoAssignPolicy = true;
                else
                    taskControl.AutoAssignPolicy = false;

                if (taskControl.Mode == 1)
                {
                    cp = HttpContext.Current.User as Login.Login;
                    taskControl.EnteredBy = cp.Identity.Name.Split("|".ToCharArray())[0];
                }

                if (Session["DtPolicyDetail"] != null)
                {
                    taskControl.PolicyDetailcs.PolicyDetailTableTemp = (DataTable)Session["DtPolicyDetail"];
                }

                taskControl.RateTN1 = double.Parse(txtRateTN1.Text.Replace("%", ""));
                taskControl.RateTN2 = double.Parse(txtRateTN2.Text.Replace("%", ""));
                taskControl.RateTN3 = double.Parse(txtRateTN3.Text.Replace("%", ""));
                taskControl.RateTN4 = double.Parse(txtRateTN4.Text.Replace("%", ""));
                taskControl.RateTN5 = double.Parse(txtRateTN5.Text.Replace("%", ""));
                taskControl.RateTN6 = double.Parse(txtRateTN6.Text.Replace("%", ""));
                taskControl.PrimaryTN1 = double.Parse(txtPrimaryTN1.Text);
                taskControl.PrimaryTN2 = double.Parse(txtPrimaryTN2.Text);
                taskControl.PrimaryTN3 = double.Parse(txtPrimaryTN3.Text);
                taskControl.PrimaryTN4 = double.Parse(txtPrimaryTN4.Text);
                taskControl.PrimaryTN5 = double.Parse(txtPrimaryTN5.Text);
                taskControl.PremiumTN1 = double.Parse(txtPremiumTN1.Text);
                taskControl.PremiumTN2 = double.Parse(txtPremiumTN2.Text);
                taskControl.PremiumTN3 = double.Parse(txtPremiumTN3.Text);
                taskControl.PremiumTN4 = double.Parse(txtPremiumTN4.Text);
                taskControl.PremiumTN5 = double.Parse(txtPremiumTN5.Text);
                taskControl.QuantityTN1 = int.Parse(txtQuantityTN1.Text);
                taskControl.QuantityTN2 = int.Parse(txtQuantityTN2.Text);
                taskControl.QuantityTN3 = int.Parse(txtQuantityTN3.Text);
                taskControl.QuantityTN4 = int.Parse(txtQuantityTN4.Text);
                taskControl.QuantityTN5 = int.Parse(txtQuantityTN5.Text);
                taskControl.QuantityTN6 = int.Parse(txtQuantityTN6.Text);
                taskControl.TotPremTN1 = double.Parse(txtTotPremTN1.Text);
                taskControl.TotPremTN2 = double.Parse(txtTotPremTN2.Text);
                taskControl.TotPremTN3 = double.Parse(txtTotPremTN3.Text);
                taskControl.TotPremTN4 = double.Parse(txtTotPremTN4.Text);
                taskControl.TotPremTN5 = double.Parse(txtTotPremTN5.Text);
                taskControl.TotPremTN6 = double.Parse(txtTotPremTN6.Text);
                taskControl.ERateTN1 = double.Parse(txtERateTN1.Text.Replace("%", ""));
                taskControl.ERateTN2 = double.Parse(txtERateTN2.Text.Replace("%", ""));
                taskControl.ERateTN3 = double.Parse(txtERateTN3.Text.Replace("%", ""));
                taskControl.ERateTN4 = double.Parse(txtERateTN4.Text.Replace("%", ""));
                taskControl.ERateTN5 = double.Parse(txtERateTN5.Text.Replace("%", ""));
                taskControl.ERateTN6 = double.Parse(txtERateTN6.Text.Replace("%", ""));
                taskControl.ExcessTN1 = double.Parse(txtExcessTN1.Text);
                taskControl.ExcessTN2 = double.Parse(txtExcessTN2.Text);
                taskControl.ExcessTN3 = double.Parse(txtExcessTN3.Text);
                taskControl.ExcessTN4 = double.Parse(txtExcessTN4.Text);
                taskControl.ExcessTN5 = double.Parse(txtExcessTN5.Text);
                taskControl.EPremiumTN1 = double.Parse(txtEPremiumTN1.Text);
                taskControl.EPremiumTN2 = double.Parse(txtEPremiumTN2.Text);
                taskControl.EPremiumTN3 = double.Parse(txtEPremiumTN3.Text);
                taskControl.EPremiumTN4 = double.Parse(txtEPremiumTN4.Text);
                taskControl.EPremiumTN5 = double.Parse(txtEPremiumTN5.Text);
                taskControl.EQuantityTN1 = int.Parse(txtEQuantityTN1.Text);
                taskControl.EQuantityTN2 = int.Parse(txtEQuantityTN2.Text);
                taskControl.EQuantityTN3 = int.Parse(txtEQuantityTN3.Text);
                taskControl.EQuantityTN4 = int.Parse(txtEQuantityTN4.Text);
                taskControl.EQuantityTN5 = int.Parse(txtEQuantityTN5.Text);
                taskControl.EQuantityTN6 = int.Parse(txtEQuantityTN6.Text);
                taskControl.ETotPremTN1 = double.Parse(txtETotPremTN1.Text);
                taskControl.ETotPremTN2 = double.Parse(txtETotPremTN2.Text);
                taskControl.ETotPremTN3 = double.Parse(txtETotPremTN3.Text);
                taskControl.ETotPremTN4 = double.Parse(txtETotPremTN4.Text);
                taskControl.ETotPremTN5 = double.Parse(txtETotPremTN5.Text);
                taskControl.ETotPremTN6 = double.Parse(txtETotPremTN6.Text);
                taskControl.TotalPrimary = double.Parse(txtTotalPrimary.Text);
                taskControl.TotalExcess = double.Parse(txtTotalExcess.Text);

                Session["EndorsementQuote"] = taskControl;
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

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("A problem occured filling class properties.");
                this.litPopUp.Visible = true;
            }
        }
        protected void BtnExit_Click(object sender, System.EventArgs e)
        {
            RemoveSessionLookUp();
            this.litPopUp.Visible = false;
            //Session.Clear();
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
            taskControl.Mode = 3;
            Response.Redirect("Policies.aspx");
        }
        protected void btnCancel_Click(object sender, System.EventArgs e)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

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

            if (taskControl.Mode == 1) //ADD
            {
                Session.Clear();
                Response.Redirect("MainMenu.aspx");
            }
            else
            {
                taskControl = (TaskControl.Policies)TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControl.TaskControlID, userID);
                taskControl.Mode = (int)TaskControl.TaskControl.TaskControlMode.CLEAR;
                Session["EndorsementQuote"] = taskControl;
                FillTextControl();
                DisableControls();

                if (taskControl.PolicyType.ToString().Trim().Length > 2)
                    DisableControlsTail();

            }
        }
        protected void btnPrintPolicy_Click(object sender, System.EventArgs e)
        {
            try
            {
                TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

                if (taskControl.CancellationDate != String.Empty)
                {
                    ReportViewer viewer = new ReportViewer();
                    viewer.LocalReport.ReportPath = Server.MapPath("Reports/CancellationCredit.rdlc");
                    viewer.LocalReport.DataSources.Clear();
                    viewer.ProcessingMode = ProcessingMode.Local;

                    ReportParameter[] param = new ReportParameter[14];
                    param[0] = new ReportParameter("PolicyID", taskControl.PolicyNo.ToString().Trim());
                    param[1] = new ReportParameter("EffectiveDate", DateTime.Parse(taskControl.EffectiveDate).ToString("MMMM dd, yyyy"));
                    param[2] = new ReportParameter("ExpirationDate", DateTime.Parse(taskControl.ExpirationDate).ToString("MMMM dd, yyyy"));
                    param[3] = new ReportParameter("Agency", ddlAgency.SelectedItem.ToString());
                    param[4] = new ReportParameter("Agent", ddlAgent.SelectedItem.ToString());
                    param[5] = new ReportParameter("Customer", taskControl.Customer.FirstName + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2);

                    if (taskControl.Customer.Address2 != String.Empty)
                        param[6] = new ReportParameter("Address", taskControl.Customer.Address1 + " \r\n" + taskControl.Customer.Address2 + " \r\n" +
                                                   taskControl.Customer.City + " " + taskControl.Customer.State + " " + taskControl.Customer.ZipCode);
                    else
                        param[6] = new ReportParameter("Address", taskControl.Customer.Address1 + " \r\n" +
                                                       taskControl.Customer.City + " " + taskControl.Customer.State + " " + taskControl.Customer.ZipCode);

                    param[7] = new ReportParameter("CancellationDate", DateTime.Parse(taskControl.CancellationDate).ToString("MMMM dd, yyyy"));
                    param[8] = new ReportParameter("ReturnPremium", taskControl.ReturnPremium.ToString("$###,##0.00"));
                    param[9] = new ReportParameter("PolicyType", taskControl.PolicyType.ToString().Trim());

                    if (taskControl.CancellationMethod == 1)
                    {
                        param[10] = new ReportParameter("MOC3", "X");
                        param[11] = new ReportParameter("MOC5Exp", "");
                    }
                    else if (taskControl.CancellationMethod == 2)
                    {
                        param[10] = new ReportParameter("MOC2", "X");
                        param[11] = new ReportParameter("MOC5Exp", "");
                    }
                    else if (taskControl.CancellationMethod == 3)
                    {
                        param[10] = new ReportParameter("MOC1", "X");
                        param[11] = new ReportParameter("MOC5Exp", "");
                    }
                    else if (taskControl.CancellationMethod == 4)
                    {
                        param[10] = new ReportParameter("MOC4", "X");
                        param[11] = new ReportParameter("MOC5Exp", "");
                    }
                    else
                    {
                        param[10] = new ReportParameter("MOC5", "X");
                        param[11] = new ReportParameter("MOC5Exp", taskControl.CancellationMethodDesc.ToString());
                    }

                    if (taskControl.CancellationReason == 6)
                    {
                        param[12] = new ReportParameter("RSC1", "X");
                        param[13] = new ReportParameter("RSC4Date", "");
                    }
                    else if (taskControl.CancellationReason == 5 || taskControl.CancellationReason == 10
                             || taskControl.CancellationReason == 14)
                    {
                        param[12] = new ReportParameter("RSC2", "X");
                        param[13] = new ReportParameter("RSC4Date", "");
                    }
                    else if (taskControl.CancellationReason == 26)
                    {
                        param[12] = new ReportParameter("RSC3", "X");
                        param[13] = new ReportParameter("RSC3Date", DateTime.Parse(taskControl.CancellationReasonDesc).ToString("MMMM dd, yyyy"));
                    }
                    else if (taskControl.CancellationReason == 27)
                    {
                        param[12] = new ReportParameter("RSC4", "X");
                        param[13] = new ReportParameter("RSC4Date", DateTime.Parse(taskControl.CancellationReasonDesc).ToString("MMMM dd, yyyy"));
                    }
                    else
                    {
                        param[12] = new ReportParameter("RSC5", "X");
                        param[13] = new ReportParameter("RSC5Exp", taskControl.CancellationReasonDesc.ToString());
                    }

                    viewer.LocalReport.SetParameters(param);
                    viewer.LocalReport.Refresh();

                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType;
                    string encoding = string.Empty;
                    string extension;
                    string fileName = taskControl.Customer.FirstName + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2;
                    string _FileName = taskControl.Customer.FirstName + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2 + ".pdf";
                    //��
                    if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                        File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

                    byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                    using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }

                    History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED CANCELLATION CREDIT");

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + _FileName + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                }
                else if (taskControl.PolicyType.Trim() == "PP")
                {
                    if (taskControl.Anniversary == "01")
                    {
                        if (!taskControl.PrintPolicy )//&& prmdicAdmin)
                        {
                            DataDynamics.ActiveReports.ActiveReport3 rpt = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt1 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt3 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt4 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt5 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt6 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt7 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt8 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt9 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt10 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt11 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt12 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt13 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt14 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt15 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt16 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt17 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt18 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt19 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt20 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt21 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt22 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt23 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt24 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt25 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt26 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt27 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt28 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt29 = null;

                            rpt28 = new EPolicy2.Reports.PRMdic.Invoice((EPolicy.TaskControl.Policy)taskControl, false);
                            rpt28.Document.Printer.PrinterName = "";
                            rpt28.Run(false);
                            rpt = rpt28;

                            rpt3 = new EPolicy2.Reports.PRMdic.PrimaryPolicy(taskControl);
                            rpt3.Document.Printer.PrinterName = "";
                            rpt3.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages);

                            rpt1 = new EPolicy2.Reports.PRMdic.PrimaryPolicy1((EPolicy.TaskControl.Policy)taskControl, false);
                            rpt1.Document.Printer.PrinterName = "";
                            rpt1.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt1.Document.Pages); //Page 1

                            rpt2 = new EPolicy2.Reports.PRMdic.PrimaryPolicy2((EPolicy.TaskControl.Policy)taskControl, false);
                            rpt2.Document.Printer.PrinterName = "";
                            rpt2.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages); //Page 2

                            rpt4 = new EPolicy2.Reports.PRMdic.PrimaryPolicy3();
                            rpt4.Document.Printer.PrinterName = "";
                            rpt4.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt4.Document.Pages);

                            rpt5 = new EPolicy2.Reports.PRMdic.PrimaryPolicy4();
                            rpt5.Document.Printer.PrinterName = "";
                            rpt5.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt5.Document.Pages);

                            rpt6 = new EPolicy2.Reports.PRMdic.PrimaryPolicy5();
                            rpt6.Document.Printer.PrinterName = "";
                            rpt6.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt6.Document.Pages);

                            rpt7 = new EPolicy2.Reports.PRMdic.PrimaryPolicy6();
                            rpt7.Document.Printer.PrinterName = "";
                            rpt7.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt7.Document.Pages);

                            rpt8 = new EPolicy2.Reports.PRMdic.PrimaryPolicy7();
                            rpt8.Document.Printer.PrinterName = "";
                            rpt8.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt8.Document.Pages);
                       

                            rpt9 = new EPolicy2.Reports.PRMdic.PrimaryPolicy8();
                            rpt9.Document.Printer.PrinterName = "";
                            rpt9.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt9.Document.Pages);

                            rpt10 = new EPolicy2.Reports.PRMdic.PrimaryPolicy9();
                            rpt10.Document.Printer.PrinterName = "";
                            rpt10.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt10.Document.Pages);

                            rpt11 = new EPolicy2.Reports.PRMdic.PrimaryPolicy10();
                            rpt11.Document.Printer.PrinterName = "";
                            rpt11.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt11.Document.Pages);

                            rpt12 = new EPolicy2.Reports.PRMdic.PrimaryPolicy11();
                            rpt12.Document.Printer.PrinterName = "";
                            rpt12.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt12.Document.Pages);

                            rpt13 = new EPolicy2.Reports.PRMdic.PrimaryPolicy12();
                            rpt13.Document.Printer.PrinterName = "";
                            rpt13.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt13.Document.Pages);

                            rpt14 = new EPolicy2.Reports.PRMdic.PrimaryPolicy13();
                            rpt14.Document.Printer.PrinterName = "";
                            rpt14.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt14.Document.Pages);

                            rpt15 = new EPolicy2.Reports.PRMdic.PrimaryPolicy14();
                            rpt15.Document.Printer.PrinterName = "";
                            rpt15.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt15.Document.Pages);

                            rpt16 = new EPolicy2.Reports.PRMdic.PrimaryPolicy15();
                            rpt16.Document.Printer.PrinterName = "";
                            rpt16.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt16.Document.Pages);

                            rpt17 = new EPolicy2.Reports.PRMdic.PrimaryPolicy16((EPolicy.TaskControl.Policy)taskControl);
                            rpt17.Document.Printer.PrinterName = "";
                            rpt17.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt17.Document.Pages);

                            rpt18 = new EPolicy2.Reports.PRMdic.PrimarySchedulerEndorsement((EPolicy.TaskControl.Policy)taskControl, false);
                            rpt18.Document.Printer.PrinterName = "";
                            rpt18.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt18.Document.Pages);

                            rpt19 = new EPolicy2.Reports.PRMdic.PrimaryStatementAcceptance((EPolicy.TaskControl.Policy)taskControl, false);
                            rpt19.Document.Printer.PrinterName = "";
                            rpt19.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt19.Document.Pages);

                            rpt20 = new EPolicy2.Reports.PRMdic.PrimaryMandatory1();
                            rpt20.Document.Printer.PrinterName = "";
                            rpt20.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt20.Document.Pages); //Page 4 

                            rpt21 = new EPolicy2.Reports.PRMdic.PrimaryMandatory2();
                            rpt21.Document.Printer.PrinterName = "";
                            rpt21.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt21.Document.Pages); //Page 5

                            rpt22 = new EPolicy2.Reports.PRMdic.PrimaryMandatory3();
                            rpt22.Document.Printer.PrinterName = "";
                            rpt22.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt22.Document.Pages);

                            rpt23 = new EPolicy2.Reports.PRMdic.PrimaryContinuousRenewal();
                            rpt23.Document.Printer.PrinterName = "";
                            rpt23.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt23.Document.Pages);

                            rpt24 = new EPolicy2.Reports.PRMdic.PrimaryActOfWar((EPolicy.TaskControl.Policy)taskControl, false);
                            rpt24.Document.Printer.PrinterName = "";
                            rpt24.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt24.Document.Pages);

                            rpt25 = new EPolicy2.Reports.PRMdic.PrimaryNuclearEnergy();
                            rpt25.Document.Printer.PrinterName = "";
                            rpt25.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt25.Document.Pages);

                            rpt26 = new EPolicy2.Reports.PRMdic.PrimaryNuclearEnergy2();
                            rpt26.Document.Printer.PrinterName = "";
                            rpt26.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt26.Document.Pages);

                            if (taskControl.EffectiveDate.Trim() != taskControl.RetroactiveDate.Trim())
                            {
                                rpt27 = new EPolicy2.Reports.PRMdic.PrimaryPriorAct((EPolicy.TaskControl.Policy)taskControl, false);
                                rpt27.Document.Printer.PrinterName = "";
                                rpt27.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt27.Document.Pages);
                            }

                            if (taskControl.Charge > 0)
                            {
                                rpt29 = new EPolicy2.Reports.PRMdic.ChargeEng((EPolicy.TaskControl.Policy)taskControl);
                                rpt29.Document.Printer.PrinterName = "";
                                rpt29.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt29.Document.Pages);
                            }

                            taskControl.PrintPolicy = true;
                            taskControl.PrintDate = DateTime.Now.ToShortDateString();
                            taskControl.Mode = 2;
                            FillProperties(); 
                            History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY.");
                            taskControl.SavePolicies(userID);

                            RemoveSessionLookUp();
                            Session.Add("Report", rpt);
                            Session.Add("FromPage", "Policies.aspx");
                            Response.Redirect("ActiveXViewer.aspx");
                        }
                        else //Print Policy Lock
                        {
                            this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy Printing has been disabled.  Please contact your supervisor.");
                            this.litPopUp.Visible = true;
                        }
                    }
                    else //Renovacion.
                    {
                        if (!taskControl.PrintPolicy) //Proof that the renovation was printed.
                        {
                            DataDynamics.ActiveReports.ActiveReport3 rpt = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt3 = null;

                            rpt = new EPolicy2.Reports.PRMdic.Invoice(taskControl, false);
                            rpt.Document.Printer.PrinterName = "";
                            rpt.Run(false);


                            rpt2 = new EPolicy2.Reports.PRMdic.RenewalEndorsement(taskControl, 0, ddlPrMedicalLimits.SelectedItem.Text.ToString());
                            rpt2.Document.Printer.PrinterName = "";
                            rpt2.Run();
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages);

                            if (taskControl.Charge > 0)
                            {
                                rpt3 = new EPolicy2.Reports.PRMdic.ChargeEng((EPolicy.TaskControl.Policy)taskControl);
                                rpt3.Document.Printer.PrinterName = "";
                                rpt3.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages);
                            }


                            taskControl.PrintPolicy = true;
                            taskControl.PrintDate = DateTime.Now.ToShortDateString();
                            taskControl.Mode = 2;
                            FillProperties();
                            taskControl.SavePolicies(userID);

                            History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY RENOVATION DOCUMENT.");


                            RemoveSessionLookUp();
                            Session.Add("Report", rpt);
                            Session.Add("FromPage", "Policies.aspx");
                            Response.Redirect("ActiveXViewer.aspx");
                        }
                        else //Print Policy Lock
                        {
                            this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy Printing has been disabled.  Please contact your supervisor.");
                            this.litPopUp.Visible = true;
                        }

                    }
                }
                else if (taskControl.PolicyType.Trim() == "PPT")
                {
                    DataDynamics.ActiveReports.ActiveReport3 rpt = null;

                    rpt = new EPolicy2.Reports.PRMdic.TailEndorsement((EPolicy.TaskControl.Policy)taskControl);
                    rpt.Document.Printer.PrinterName = "";
                    rpt.Run(false);

                    RemoveSessionLookUp();
                    Session.Add("Report", rpt);
                    Session.Add("FromPage", "Policies.aspx");
                    Response.Redirect("ActiveXViewer.aspx");

                    History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED TAIL ENDORSEMENT.");
                }

                else if (taskControl.PolicyType.Trim() == "PE")//PE
                {
                    if (taskControl.Anniversary == "01")
                    {
                        if (!taskControl.PrintPolicy)//&& prmdicAdmin)
                        {
                            DataDynamics.ActiveReports.ActiveReport3 rpt = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt1 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt3 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt4 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt5 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt6 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt7 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt8 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt9 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt10 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt11 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt12 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt13 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt14 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt15 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt16 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt17 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt18 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt19 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt20 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt21 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt22 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt23 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt24 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt25 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt26 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt27 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt28 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt29 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt30 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt31 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt32 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt33 = null;

                            rpt32 = new EPolicy2.Reports.PRMdic.Invoice(taskControl, false);
                            rpt32.Document.Printer.PrinterName = "";
                            rpt32.Run(false);
                            rpt = rpt32;

                            rpt1 = new EPolicy2.Reports.PRMdic.Poliza(taskControl);
                            rpt1.Document.Printer.PrinterName = "";
                            rpt1.Run();
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt1.Document.Pages); ;

                            rpt2 = new EPolicy2.Reports.PRMdic.Poliza1(taskControl, false, ddlPrMedicalLimits.SelectedItem.Text.ToString());
                            rpt2.Document.Printer.PrinterName = "";
                            rpt2.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages);

                            rpt26 = new EPolicy2.Reports.PRMdic.Poliza2B(taskControl, false);
                            rpt26.Document.Printer.PrinterName = "";
                            rpt26.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt26.Document.Pages);

                            //rpt3 = new EPolicy2.Reports.PRMdic.Poliza2(taskControl);
                            //rpt3.Document.Printer.PrinterName = "";
                            //rpt3.Run(false);
                            //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages);

                            rpt4 = new EPolicy2.Reports.PRMdic.Poliza3();
                            rpt4.Document.Printer.PrinterName = "";
                            rpt4.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt4.Document.Pages);

                            rpt5 = new EPolicy2.Reports.PRMdic.Poliza4();
                            rpt5.Document.Printer.PrinterName = "";
                            rpt5.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt5.Document.Pages);

                            rpt6 = new EPolicy2.Reports.PRMdic.Poliza5();
                            rpt6.Document.Printer.PrinterName = "";
                            rpt6.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt6.Document.Pages);

                            rpt7 = new EPolicy2.Reports.PRMdic.Poliza6();
                            rpt7.Document.Printer.PrinterName = "";
                            rpt7.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt7.Document.Pages);

                            rpt8 = new EPolicy2.Reports.PRMdic.Poliza7();
                            rpt8.Document.Printer.PrinterName = "";
                            rpt8.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt8.Document.Pages);

                            rpt9 = new EPolicy2.Reports.PRMdic.Poliza8();
                            rpt9.Document.Printer.PrinterName = "";
                            rpt9.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt9.Document.Pages);

                            rpt10 = new EPolicy2.Reports.PRMdic.Poliza9();
                            rpt10.Document.Printer.PrinterName = "";
                            rpt10.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt10.Document.Pages);

                            rpt11 = new EPolicy2.Reports.PRMdic.Poliza10();
                            rpt11.Document.Printer.PrinterName = "";
                            rpt11.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt11.Document.Pages);

                            rpt12 = new EPolicy2.Reports.PRMdic.Poliza11();
                            rpt12.Document.Printer.PrinterName = "";
                            rpt12.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt12.Document.Pages);

                            rpt13 = new EPolicy2.Reports.PRMdic.Poliza12();
                            rpt13.Document.Printer.PrinterName = "";
                            rpt13.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt13.Document.Pages);

                            rpt14 = new EPolicy2.Reports.PRMdic.Poliza13();
                            rpt14.Document.Printer.PrinterName = "";
                            rpt14.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt14.Document.Pages);

                            rpt15 = new EPolicy2.Reports.PRMdic.Poliza14();
                            rpt15.Document.Printer.PrinterName = "";
                            rpt15.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt15.Document.Pages);

                            rpt16 = new EPolicy2.Reports.PRMdic.Poliza15();
                            rpt16.Document.Printer.PrinterName = "";
                            rpt16.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt16.Document.Pages);

                            rpt17 = new EPolicy2.Reports.PRMdic.Poliza16();
                            rpt17.Document.Printer.PrinterName = "";
                            rpt17.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt17.Document.Pages);

                            rpt18 = new EPolicy2.Reports.PRMdic.Poliza17();
                            rpt18.Document.Printer.PrinterName = "";
                            rpt18.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt18.Document.Pages);

                            rpt19 = new EPolicy2.Reports.PRMdic.Poliza18();
                            rpt19.Document.Printer.PrinterName = "";
                            rpt19.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt19.Document.Pages);

                            rpt20 = new EPolicy2.Reports.PRMdic.Poliza19(taskControl);//
                            rpt20.Document.Printer.PrinterName = "";
                            rpt20.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt20.Document.Pages);

                            rpt30 = new EPolicy2.Reports.PRMdic.SchedulerEndorsement(taskControl, false); //Scheduler of Endorsement
                            rpt30.Document.Printer.PrinterName = "";
                            rpt30.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt30.Document.Pages);

                            rpt31 = new EPolicy2.Reports.PRMdic.StatementAcceptance((EPolicy.TaskControl.Policy)taskControl, false);//StatementOfRepe.And Acceptance
                            rpt31.Document.Printer.PrinterName = "";
                            rpt31.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt31.Document.Pages);

                            rpt22 = new EPolicy2.Reports.PRMdic.ContinuousRenewal();
                            rpt22.Document.Printer.PrinterName = "";
                            rpt22.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt22.Document.Pages);

                            rpt23 = new EPolicy2.Reports.PRMdic.MandatoryPremium1();
                            rpt23.Document.Printer.PrinterName = "";
                            rpt23.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt23.Document.Pages);

                            rpt24 = new EPolicy2.Reports.PRMdic.MandatoryPremium2();
                            rpt24.Document.Printer.PrinterName = "";
                            rpt24.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt24.Document.Pages);

                            rpt25 = new EPolicy2.Reports.PRMdic.MandatoryPremium3();
                            rpt25.Document.Printer.PrinterName = "";
                            rpt25.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt25.Document.Pages);

                         
                       

                            rpt21 = new EPolicy2.Reports.PRMdic.ActOfWar(taskControl);
                            rpt21.Document.Printer.PrinterName = "";
                            rpt21.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt21.Document.Pages);

                            rpt27 = new EPolicy2.Reports.PRMdic.NuclearEnergy();
                            rpt27.Document.Printer.PrinterName = "";
                            rpt27.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt27.Document.Pages);

                            rpt28 = new EPolicy2.Reports.PRMdic.NuclearEnergy2();
                            rpt28.Document.Printer.PrinterName = "";
                            rpt28.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt28.Document.Pages);

                            if (taskControl.EffectiveDate.Trim() != taskControl.RetroactiveDate.Trim())
                            {
                                rpt29 = new EPolicy2.Reports.PRMdic.PriorAct(taskControl, false);
                                rpt29.Document.Printer.PrinterName = "";
                                rpt29.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt29.Document.Pages); //Page 3
                            }

                            if (taskControl.Charge > 0)//TxtCharge.Text != ".00")
                            {
                                rpt33 = new EPolicy2.Reports.PRMdic.ChargeEng((EPolicy.TaskControl.Policy)taskControl);
                                rpt33.Document.Printer.PrinterName = "";
                                rpt33.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt33.Document.Pages);
                            }

                            taskControl.PrintPolicy = true;
                            taskControl.PrintDate = DateTime.Now.ToShortDateString();
                            taskControl.Mode = 2;
                            FillProperties();
                            History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY.");
                            taskControl.SavePolicies(userID);

                            RemoveSessionLookUp();
                            Session.Add("Report", rpt);
                            Session.Add("FromPage", "Policies.aspx");
                            Response.Redirect("ActiveXViewer.aspx");
                        }
                        else //Print Policy Lock
                        {
                            this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy Printing has been disabled.  Please contact your supervisor.");
                            this.litPopUp.Visible = true;
                        }
                    }
                    else //Renovacion.
                    {
                        if (!taskControl.PrintPolicy) //Proof that the renovation was printed.
                        {
                            DataDynamics.ActiveReports.ActiveReport3 rpt = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt3 = null;


                            rpt = new EPolicy2.Reports.PRMdic.Invoice(taskControl, false);
                            rpt.Document.Printer.PrinterName = "";
                            rpt.Run(false);

                            rpt2 = new EPolicy2.Reports.PRMdic.RenewalEndorsement(taskControl, 0, ddlPrMedicalLimits.SelectedItem.Text.ToString());
                            rpt2.Document.Printer.PrinterName = "";
                            rpt2.Run();
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages);

                            if (taskControl.Charge > 0)
                            {
                                rpt3 = new EPolicy2.Reports.PRMdic.ChargeEng((EPolicy.TaskControl.Policy)taskControl);
                                rpt3.Document.Printer.PrinterName = "";
                                rpt3.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages);
                            }

                            taskControl.PrintPolicy = true;
                            taskControl.PrintDate = DateTime.Now.ToShortDateString();
                            taskControl.Mode = 2;
                            FillProperties();
                            taskControl.SavePolicies(userID);

                            History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY RENOVATION DOCUMENT.");

                            RemoveSessionLookUp();
                            Session.Add("Report", rpt);
                            Session.Add("FromPage", "Policies.aspx");
                            Response.Redirect("ActiveXViewer.aspx");
                        }
                        else //Print Policy Lock
                        {
                            this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy Printing has been disabled.  Please contact your supervisor.");
                            this.litPopUp.Visible = true;
                        }
                    }
                }
                else if (taskControl.PolicyType.Trim() == "PET")
                {
                    DataDynamics.ActiveReports.ActiveReport3 rpt = null;

                    rpt = new EPolicy2.Reports.PRMdic.TailEndorsement((EPolicy.TaskControl.Policy)taskControl);
                    rpt.Document.Printer.PrinterName = "";
                    rpt.Run(false);

                    RemoveSessionLookUp();
                    Session.Add("Report", rpt);
                    Session.Add("FromPage", "Policies.aspx");
                    Response.Redirect("ActiveXViewer.aspx");

                    History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED TAIL ENDORSEMENT.");
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

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("A problem occured while generating report.");
                this.litPopUp.Visible = true;
            }
        }
        protected void btnEdit_Click(object sender, System.EventArgs e)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];
            taskControl.Mode = (int)TaskControl.TaskControl.TaskControlMode.UPDATE;

            Session.Add("TaskControl", taskControl);

            GetLastAgentSelected();
            EnableControls();
            //btnPrintCertificate.Visible = false;
            //btnTailQuote.Visible = false;
            SetControlToDisplay();
        }
        protected void btnDelete_Click(object sender, System.EventArgs e)
        {
            //if (bool.Parse(ConfirmDialogBoxPopUp.Value.Trim()) == true)
            //{
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];
            try
            {
                int i = taskControl.TaskControlID;
                TaskControl.Policies.DeletePoliciesByTaskControlID(i);

                taskControl = new TaskControl.Policies();
                taskControl.Mode = 4; //Clear

                Session["EndorsementQuote"] = taskControl;
                Session.Clear();
                Response.Redirect("MainMenu.aspx");
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
            }
            //}
        }
        protected void btnReinstatement_Click(object sender, System.EventArgs e)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];
            TaskControl.Policy policy = (TaskControl.Policy)Session["EndorsementQuote"];
            TaskControl.Policies policies = new TaskControl.Policies();

            try
            {
                ValidateReinstatement(policies, taskControl);

                policies = taskControl;
                policies.Mode = 1;
                policies.CancellationDate = "";
                policies.CancellationEntryDate = "";
                policies.CancellationUnearnedPercent = 0.00;
                policies.CancellationMethod = 0;
                policies.CancellationReason = 0;
                policies.EntryDate = DateTime.Now;
                policies.PaidAmount = taskControl.PaidAmount;
                policies.PaidDate = "";
                policies.Ren_Rei = "RI";
                policies.Rein_Amt = taskControl.CancellationAmount;
                policies.PaidDate = taskControl.PaidDate;
                policies.CommissionAgency = taskControl.ReturnCommissionAgency;
                policies.CommissionAgent = taskControl.ReturnCommissionAgent;
                policies.CommissionAgencyPercent = taskControl.CommissionAgencyPercent.Trim();
                policies.CommissionAgentPercent = taskControl.CommissionAgentPercent.Trim();
                policies.TotalPremium = taskControl.ReturnPremium;
                policies.Charge = taskControl.ReturnCharge;
                policies.ReturnCharge = 0.00;
                policies.ReturnPremium = 0.00;
                policies.CancellationAmount = 0.00;
                policies.ReturnCommissionAgency = 0.00;
                policies.ReturnCommissionAgent = 0.00;
                policies.TaskControlID = 0;
                policies.Status = "Inforce";

                if (Session["DtPolicyDetail"] != null)
                {
                    policies.PolicyDetailcs.PolicyDetailTableTemp = (DataTable)Session["DtPolicyDetail"];
                }

                int msufijo;
                int sufijo = int.Parse(taskControl.Suffix);
                msufijo = sufijo + 1;
                policies.Suffix = "0".ToString() + msufijo.ToString();

                Session.Add("TaskControl", policies);

                FillTextControl();
                EnableControls();
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }
        }
        private void ValidateReinstatement(TaskControl.Policies policies, TaskControl.Policies Oldpolicies)
        {
            string errorMessage = String.Empty;
            bool found = false;

            string mStatus = Oldpolicies.Status.Split("/".ToCharArray())[0];

            if (mStatus != "Cancelled")  //Verifica si la p�liza se encuentra cancelada.
            {
                errorMessage = "The Policy is Not Cancelled, Please verify...";
                found = true;
            }
            if (found == true)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(errorMessage);
                this.litPopUp.Visible = true;
            }
        }
        protected void btnCancellation_Click(object sender, System.EventArgs e)
        {
            RemoveSessionLookUp();
            Session.Add("FromUI", "Policies.aspx");
            Response.Redirect("CancellationPolicy.aspx", false);
        }
        protected void btnFinancialCanc_Click(object sender, EventArgs e)
        {
            RemoveSessionLookUp();
            Session.Add("FromUI", "Policies.aspx");
            Response.Redirect("FinancialCancellations.aspx", false);
        }
        protected void btnPayments_Click(object sender, System.EventArgs e)
        {
            RemoveSessionLookUp();
            Session.Add("FromPage", "Policies.aspx");
            Response.Redirect("ViewPayment.aspx");
        }
        protected void btnComissions_Click(object sender, System.EventArgs e)
        {
            RemoveSessionLookUp();
            Session.Add("FromPage", "Policies.aspx");
            Response.Redirect("ViewCommission.aspx");
        }
        protected void btnHistory_Click(object sender, System.EventArgs e)
        {
            if (Session["EndorsementQuote"] != null)
            {
                RemoveSessionLookUp();
                TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];
                Response.Redirect("SearchAuditItems.aspx?type=23&taskControlID=" +
                    taskControl.TaskControlID.ToString().Trim());
            }
        }
        private void History(int taskControlID, int userID, string action, string subject,string note)
        {
            Audit.History history = new Audit.History();
            TaskControl.Policy taskControl = (TaskControl.Policy)Session["EndorsementQuote"];

            history.Actions = action;
            history.KeyID = taskControlID.ToString();
            history.Subject = subject;
            //history.BuildNotesForHistory("TaskControlID.", "", taskControlID.ToString(), 7);  //7 = mode NOTICEOFCANC
            history.UsersID = userID;
            history.Notes = note + "\r\n";
            history.GetSaveHistory();
        }

        # region Agent Action

        protected void cmdSelect_Click(object sender, System.EventArgs e)
        {
            int levelCount = 0;
            for (int i = 0; i < ddlAvailableAgent.Items.Count; i++)
            {
                if (ddlAvailableAgent.Items[i].Selected)
                {
                    levelCount = int.Parse(ddlAvailableAgent.Items[i].Value.Split("|".ToCharArray())[0]);

                    ListItem list = new ListItem(ddlAvailableAgent.Items[i].Value.Split("|".ToCharArray())[0] +
                        " |" + ddlAvailableAgent.Items[i].Text.Split("|".ToCharArray())[1],
                        ddlAvailableAgent.Items[i].Value.Split("|".ToCharArray())[0] +
                        " |" + ddlAvailableAgent.Items[i].Value.Split("|".ToCharArray())[1]);
                    ddlSelectedAgent.Items.Add(list);
                    ddlAvailableAgent.Items.Remove(ddlAvailableAgent.Items[i]);

                    cmdRemove.Enabled = true;
                    VerifyLabelAgent(ddlSelectedAgent.Items.Count, 0, false);

                    ddlSelectedAgentOrder();
                }
            }
        }

        private void ddlSelectedAgentOrder()
        {
            ListItemCollection lst = (ListItemCollection)ddlSelectedAgent.Items;

            for (int i = 0; i < lst.Count; i++)
            {
                for (int a = 0; a < lst.Count - 1; a++)
                {
                    int order = int.Parse(lst[a].Text.Split("|".ToCharArray())[0]);
                    if (order == i + 1)
                    {
                        ListItem list = new ListItem(lst[a].Text, lst[a].Value);
                        ddlSelectedAgent.Items.Add(list);
                        ddlSelectedAgent.Items.Remove(lst[a]);

                        a = lst.Count - 1;
                    }
                }
            }
            lst = null;
        }

        protected void cmdRemove_Click(object sender, System.EventArgs e)
        {
            try
            {
                VerifyRemoveAgent();


                int CurrentLevel = 0;

                for (int i = 0; i < ddlSelectedAgent.Items.Count; i++)
                {
                    if (ddlSelectedAgent.Items[i].Selected)
                    {
                        CurrentLevel = int.Parse(ddlSelectedAgent.Items[i].Text.Split("|".ToCharArray())[0]);

                        ListItem list = new ListItem(ddlSelectedAgent.Items[i].Text.Split("|".ToCharArray())[0] +
                            " |" + ddlSelectedAgent.Items[i].Text.Split("|".ToCharArray())[1],
                            ddlSelectedAgent.Items[i].Text.Split("|".ToCharArray())[0] +
                            " |" + ddlSelectedAgent.Items[i].Value.Split("|".ToCharArray())[1]);
                        ddlAvailableAgent.Items.Add(list);
                        ddlSelectedAgent.Items.Remove(ddlSelectedAgent.Items[i]);
                    }

                    if (ddlSelectedAgent.Items.Count + 1 == CurrentLevel)
                        cmdRemove.Enabled = true;
                    else
                        if (ddlSelectedAgent.Items.Count == 0)
                            cmdRemove.Enabled = false;

                    VerifyLabelAgent(ddlSelectedAgent.Items.Count, CurrentLevel, false);
                }
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }
        }

        private void VerifyRemoveAgent()
        {
            string errorMessage = String.Empty;

            if (this.ddlSelectedAgent != null)
            {
                if (this.ddlSelectedAgent.Items.Count != 0)
                {
                    bool LevelError = false;
                    for (int i = 0; this.ddlSelectedAgent.Items.Count - 1 >= i; i++)
                    {
                        if (int.Parse(this.ddlSelectedAgent.SelectedItem.Value.Split("|".ToCharArray())[0]) != this.ddlSelectedAgent.Items.Count && !LevelError)
                        {
                            LevelError = true;
                            int level = i + 1;
                            errorMessage = "The Agent level " +
                                level.ToString().Trim() +
                                " is required, Please verify...";
                        }
                    }
                }
            }

            if (errorMessage != String.Empty)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(errorMessage);
                this.litPopUp.Visible = true;
            }
        }

        private void GetLastAgentSelected()
        {
            int CurrentLevel = 0;

            for (int i = 0; i < ddlSelectedAgent.Items.Count; i++)
            {
                if (ddlSelectedAgent.Items[i].Selected)
                {
                    CurrentLevel = int.Parse(ddlSelectedAgent.Items[i].Text.Split("|".ToCharArray())[0]);
                }
            }

            VerifyLabelAgent(ddlSelectedAgent.Items.Count, CurrentLevel, false);
        }

        private void VerifyLabelAgent(int level, int CurrentLevel, bool firstTime)
        {
            // Se le A�ade uno para visualizar el pr�ximo nivel a seleccionarse �
            // Posiciona el nivel dependiendo el orden de los agentes seleccionados.

            if (CurrentLevel != 0)
            {
                level = CurrentLevel;
            }
            else
            {
                if (level != 0)
                {
                    level = level + 1;
                }
            }

            if (level != 0)
            {
                LblSelectAgent.Text = "Available Agent - Level " + level.ToString().Trim();
            }
            else
            {
                if (firstTime)
                {
                    level = 1;
                    LblSelectAgent.Text = "Available Agent - Level 1";
                }
                else
                {
                    LblSelectAgent.Text = "Available Agent - Level ";
                }
            }

            //Actulizo el DropdownList con los agentes del nivel para seleccionarse. - ddlAvailableAgent.
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

            DataTable dtAvail = taskControl.AgentList;
            DataTable dt = dtAvail.Clone();
            DataRow[] DrAvail = dtAvail.Select("AgentLevel = " + level, "AgentDesc");

            for (int i = 0; i <= DrAvail.Length - 1; i++)
            {
                DataRow myRow = dt.NewRow();
                myRow["AgentID"] = DrAvail[i].ItemArray[0].ToString();
                myRow["AgentDesc"] = DrAvail[i].ItemArray[1].ToString();
                myRow["AgentLevel"] = (int)DrAvail[i].ItemArray[2];

                dt.Rows.Add(myRow);
                dt.AcceptChanges();
            }

            SetddlAvailableAgent(dt);

            if (ddlAvailableAgent.Items.Count == 0)
            {
                LblSelectAgent.Text = "Available Agent - Level ";
            }
        }

        private void SetddlAvailableAgent(DataTable dt)
        {
            ddlAvailableAgent.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlAvailableAgent.Items.Add(dt.Rows[i]["AgentLevel"].ToString().Trim() +
                    " |" + dt.Rows[i]["AgentDesc"].ToString().Trim());
                ddlAvailableAgent.Items[i].Value = dt.Rows[i]["AgentLevel"].ToString().Trim() +
                    " |" + dt.Rows[i]["AgentID"].ToString().Trim();
            }
        }

        private void SetddlSelectedAgent(DataTable dt)
        {
            ddlSelectedAgent.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlSelectedAgent.Items.Add(dt.Rows[i]["CommissionLevel"].ToString().Trim() +
                    " |" + dt.Rows[i]["AgentDesc"].ToString().Trim());
                ddlSelectedAgent.Items[i].Value = dt.Rows[i]["CommissionLevel"].ToString().Trim() +
                    " |" + dt.Rows[i]["AgentID"].ToString();
            }
        }

        private void FillTextDDlAgent()
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

            taskControl.AgentSelectedTable = TaskControl.Policy.GetSelectedAgent(taskControl.TaskControlID);

            Session.Add("TaskControl", taskControl);

            SetddlSelectedAgent(taskControl.AgentSelectedTable);
            ddlSelectedAgentOrder();

            VerifyLabelAgent(ddlSelectedAgent.Items.Count, 1, false);
        }

        private void FirstFillDllAgentList()
        {
            VerifyLabelAgent(0, 0, true);
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

            SetSelectedAgent(taskControl, taskControl.Agent.Trim());		//El agente por default que tiene el usuario es el primer Agente en este producto.
        }

        private void SetSelectedAgent(TaskControl.Policies taskControl, string companyDealerID)
        {
            ddlAvailableAgent.SelectedIndex = 0;
            //			if(taskControl.Agent != "000")
            //			{
            for (int i = 0; ddlAvailableAgent.Items.Count - 1 >= i; i++)
            {
                if (ddlAvailableAgent.Items[i].Value.Split("|".ToCharArray())[1] == companyDealerID)
                {
                    ddlAvailableAgent.SelectedIndex = i;
                    i = ddlAvailableAgent.Items.Count - 1;
                }
            }
            //			}

            for (int i = 0; i < ddlAvailableAgent.Items.Count; i++)
            {
                if (ddlAvailableAgent.Items[i].Selected)
                {
                    ListItem list = new ListItem(ddlAvailableAgent.Items[i].Value.Split("|".ToCharArray())[0] +
                        " |" + ddlAvailableAgent.Items[i].Text.Split("|".ToCharArray())[1],
                        ddlAvailableAgent.Items[i].Value.Split("|".ToCharArray())[0] +
                        " |" + ddlAvailableAgent.Items[i].Value.Split("|".ToCharArray())[1]);
                    ddlSelectedAgent.Items.Add(list);
                    ddlAvailableAgent.Items.Remove(ddlAvailableAgent.Items[i]);
                }
            }

            VerifyLabelAgent(ddlSelectedAgent.Items.Count, 0, false);
            //VerifyLabelAgent(0, 2,false);
        }

        #endregion

        protected void ddlPolicyClass_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ResetDllPolicyClass();
        }
        private void ResetDllPolicyClass()
        {
            //PolicyClass
            EnableControls();

            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

            if (ddlPolicyClass.SelectedIndex != 0)
            {
                taskControl.AgentList = Policy.GetAgentListByPolicyClassID(int.Parse(ddlPolicyClass.SelectedItem.Value));

                if (taskControl.Mode == 1) //Add
                    this.FillTextDDlAgent();

                Session["EndorsementQuote"] = taskControl;

                //Se comento para que el performance sea mas rapido ya que en AutoGAp y VSC no se usa.
                ////Year
                //DataTable dtYear = LookupTables.LookupTables.GetTable("Year");
                //ddlYear.DataSource = dtYear;
                //ddlYear.DataTextField = "YearDesc";
                //ddlYear.DataValueField = "YearID";
                //ddlYear.DataBind();
                //ddlYear.SelectedIndex = -1;
                //ddlYear.Items.Insert(0,"0");

                ////Covers
                //DataTable dtCovers = TaskControl.Policies.GetCoversByPolicyClassID(int.Parse(ddlPolicyClass.SelectedItem.Value));
                //ddlCovers.DataSource = dtCovers;
                //ddlCovers.DataTextField = "CoversDesc";
                //ddlCovers.DataValueField = "CoversID";
                //ddlCovers.DataBind();
                //ddlCovers.SelectedIndex = -1;
                //ddlCovers.Items.Insert(0,"");

                //ddlLimits.Items.Clear();
            }

            SetControlToDisplay();
        }
        private void SetControlToDisplay()
        {
            try
            {
                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = 0;
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

                if (ddlPolicyClass.SelectedItem.Value.Trim() != "")
                {
                    switch (int.Parse(ddlPolicyClass.SelectedItem.Value))
                    {
                        case 1: //VehicleServiceContract
                            TxtTerm.Visible = true;
                            lblPolicyNo.Text = "Contract No";
                            lblTotPremum.Text = "Total Price";
                            TxtPolicyNo.Enabled = false;
                            TxtCertificate.Enabled = false;
                            TxtPolicyType.Enabled = false;
                            TxtSufijo.Enabled = false;
                            TxtAnniversary.Enabled = true;
                            txtApplicationID.Enabled = false;
                            TxtTerm.Enabled = false;
                            TxtTotalPremium.Enabled = false;
                            TxtPremium.Enabled = false;

                            cp = HttpContext.Current.User as Login.Login;
                            if (!cp.IsInRole("VSCADMINFIELDS") && !cp.IsInRole("ADMINISTRATOR"))
                            {
                                chkPending.Visible = false;
                            }
                            else
                            {
                                chkPending.Visible = true;
                            }

                            TxtCertificate.Visible = false;
                            lblCertificate.Visible = false;

                            cmdRemove.Visible = false;
                            cmdSelect.Visible = false;
                            ddlAvailableAgent.Visible = false;
                            ddlSelectedAgent.Visible = false;
                            LblSelectAgent.Visible = false;
                            lblSelectedAgent.Visible = false;

                            if (taskControl.Mode == 1)
                            {
                                ddlOriginatedAt.SelectedIndex = ddlOriginatedAt.Items.IndexOf(ddlOriginatedAt.Items.FindByValue(Login.Login.GetLocationByUserID(userID).ToString()));
                                //ddlCompanyDealer.SelectedIndex = ddlCompanyDealer.Items.IndexOf(ddlCompanyDealer.Items.FindByValue(Login.Login.GetDealerByUserID(userID).ToString()));

                                //Aplica el supplier segun el dealer.
                                //DataTable dt = LookupTables.CompanyDealer.GetSupplierIDByCompanyDealerID(ddlCompanyDealer.SelectedItem.Value.ToString());
                                //if (dt.Rows.Count != 0)
                                //{
                                //    taskControl.SupplierID = dt.Rows[0]["SupplierID"].ToString();
                                //}
                                //else
                                //{
                                //    taskControl.SupplierID = "000";
                                //}

                                taskControl.SupplierID = "000";
                                taskControl.DepartmentID = 4;
                                taskControl.PolicyClassID = 1;
                                taskControl.PolicyType = "VSC";
                                taskControl.InsuranceCompany = "002";
                                taskControl.Agency = "000";
                                taskControl.Bank = "000";
                                taskControl.Dealer = "000";
                                taskControl.CompanyDealer = "000";
                                //taskControl.CompanyDealer = ddlCompanyDealer.SelectedItem.Value.ToString();
                                taskControl.Status = "Inforce";
                                taskControl.TaskStatusID = 23; // int.Parse(LookupTables.LookupTables.GetID("TaskStatus", "Open"));
                                taskControl.TaskControlTypeID = int.Parse(LookupTables.LookupTables.GetID("TaskControlType", "Policies"));
                                taskControl.CommissionAgencyPercent = "0";
                                //taskControl.TotalPremium     = 0.00; //Ya viene del quote.
                                //taskControl.NewUse			 = 2; //Ya viene del quote.
                                taskControl.AutoAssignPolicy = false; //Para que en VSC aparesca puedan entrar el num de pol manualmente.

                                Session["EndorsementQuote"] = taskControl;
                                FillTextControl();

                                //Se comento para que el performance sea mas rapido ya que en AutoGAp y VSC no se usa.
                                //ddlCovers.SelectedIndex = ddlCovers.Items.IndexOf(
                                //    ddlCovers.Items.FindByValue("1"));

                                //ddlLimits.Items.Clear();
                                //FillLimits();
                                //ddlLimits.SelectedIndex = ddlLimits.Items.IndexOf(
                                //    ddlLimits.Items.FindByText("100"));
                            }
                            VerifyAssignPolicyFields();
                            break;

                        case 9: //PR MEDICAL
                            TxtTerm.Visible = true;
                            lblPolicyNo.Text = "Policy No.";
                            lblTotPremum.Text = "Tot. Premium";
                            TxtPolicyNo.Enabled = false;
                            TxtCertificate.Enabled = false;
                            TxtPolicyType.Enabled = false;
                            TxtSufijo.Enabled = false;
                            TxtAnniversary.Enabled = true;
                            txtApplicationID.Enabled = false;
                            TxtTotalPremium.Enabled = true;
                            TxtPremium.Enabled = true;
                            Label19.Visible = false;
                            ddlSupplier.Visible = false;

                            chkPending.Visible = false;
                            lblCertificate.Text = "Certificate";

                            cmdRemove.Visible = false;
                            cmdSelect.Visible = false;
                            ddlAvailableAgent.Visible = false;
                            ddlSelectedAgent.Visible = false;
                            LblSelectAgent.Visible = false;
                            lblSelectedAgent.Visible = false;

                            if (taskControl.IsMaster)
                            {
                                TxtCertificate.Visible = true;
                                lblCertificate.Visible = true;
                            }
                            else
                            {
                                TxtCertificate.Visible = false;
                                lblCertificate.Visible = false;
                            }

                            if (taskControl.Mode == 1)
                            {
                                if (taskControl.Anniversary == "01")
                                {
                                    ddlOriginatedAt.SelectedIndex = ddlOriginatedAt.Items.IndexOf(ddlOriginatedAt.Items.FindByValue(Login.Login.GetLocationByUserID(userID).ToString()));
                                    ddlCorparation.SelectedIndex = ddlCorparation.Items.IndexOf(ddlCorparation.Items.FindByValue(Login.Login.GetDealerByUserID(userID).ToString()));
                                    //taskControl.Agent = Login.Login.GetAgentByUserID(userID).ToString();
                                    //taskControl.Agency = Login.Login.GetAgencyByUserID(userID).ToString();
                                    if (taskControl.Agent != "000")
                                        ddlAvailableAgent.SelectedIndex = ddlAvailableAgent.Items.IndexOf(ddlAvailableAgent.Items.FindByValue("1 |" + Login.Login.GetAgentByUserID(userID).ToString()));

                                    if (taskControl.Agency == "")
                                        taskControl.Agency = "000";

                                    taskControl.DepartmentID = 5;
                                    taskControl.PolicyClassID = 9;
                                    //taskControl.PolicyType = "PRM";
                                    taskControl.InsuranceCompany = "001";

                                    taskControl.Bank = "000";
                                    //taskControl.Agent          = ddlAvailableAgent.SelectedItem.Value.ToString();
                                    taskControl.Agent = taskControl.Agent;
                                    //taskControl.CompanyDealer = ddlCompanyDealer.SelectedItem.Value.ToString();
                                    taskControl.Status = "Inforce";
                                    taskControl.TaskStatusID = int.Parse(LookupTables.LookupTables.GetID("TaskStatus", "Open"));
                                    taskControl.TaskControlTypeID = int.Parse(LookupTables.LookupTables.GetID("TaskControlType", "Policies"));

                                    taskControl.PrestamoArrenda = true;

                                    taskControl.EffectiveDate = DateTime.Now.ToShortDateString();
                                    taskControl.PurchaseDate = DateTime.Now.ToShortDateString();
                                    taskControl.EffDateCompany = DateTime.Now.ToShortDateString();
                                    taskControl.Term = 12;
                                    taskControl.ExpirationDate = DateTime.Parse(taskControl.EffectiveDate).AddMonths(taskControl.Term).ToShortDateString();
                                }

                                Session["EndorsementQuote"] = taskControl;
                                FillTextControl();
                            }
                            VerifyAssignPolicyFields();

                            //if (taskControl.Mode == 1)
                            //{
                            //    if (taskControl.Agent != "000")
                            //        FirstFillDllAgentList();
                            //}
                            break;

                        case 13: //Etch
                            TxtTerm.Visible = true;
                            lblPolicyNo.Text = "Contract No";
                            lblTotPremum.Text = "Total Price";
                            TxtPolicyNo.Enabled = false;
                            TxtCertificate.Enabled = false;
                            TxtPolicyType.Enabled = false;
                            TxtSufijo.Enabled = false;
                            TxtAnniversary.Enabled = false;
                            txtApplicationID.Enabled = false;
                            TxtTerm.Enabled = false;
                            TxtTotalPremium.Enabled = true;
                            TxtPremium.Enabled = true;

                            chkPending.Visible = false;
                            TxtCertificate.Visible = true;
                            lblCertificate.Visible = true;
                            lblCertificate.Text = "Etch Num.";

                            cmdRemove.Visible = false;
                            cmdSelect.Visible = false;
                            ddlAvailableAgent.Visible = false;
                            ddlSelectedAgent.Visible = false;
                            LblSelectAgent.Visible = false;
                            lblSelectedAgent.Visible = false;

                            if (taskControl.Mode == 1)
                            {
                                ddlOriginatedAt.SelectedIndex = ddlOriginatedAt.Items.IndexOf(ddlOriginatedAt.Items.FindByValue(Login.Login.GetLocationByUserID(userID).ToString()));
                                ddlCorparation.SelectedIndex = ddlCorparation.Items.IndexOf(ddlCorparation.Items.FindByValue(Login.Login.GetDealerByUserID(userID).ToString()));

                                //Aplica el supplier segun el dealer.
                                //DataTable dt = LookupTables.CompanyDealer.GetSupplierIDByCompanyDealerID(ddlCompanyDealer.SelectedItem.Value.ToString());
                                //if (dt.Rows.Count != 0)
                                //{
                                //    taskControl.SupplierID = dt.Rows[0]["SupplierID"].ToString();
                                //}
                                //else
                                //{
                                //    taskControl.SupplierID = "000";
                                //}

                                taskControl.SupplierID = "000";
                                taskControl.DepartmentID = 6;
                                taskControl.PolicyClassID = 13;
                                taskControl.PolicyType = "ETC";
                                taskControl.InsuranceCompany = "002";
                                taskControl.Agency = "000";
                                taskControl.Bank = "000";
                                taskControl.Dealer = "000";
                                taskControl.CompanyDealer = ddlCorparation.SelectedItem.Value.ToString();
                                taskControl.Status = "Inforce";
                                taskControl.TaskStatusID = 23; // int.Parse(LookupTables.LookupTables.GetID("TaskStatus", "Open"));
                                taskControl.TaskControlTypeID = int.Parse(LookupTables.LookupTables.GetID("TaskControlType", "Policies"));
                                taskControl.CommissionAgencyPercent = "0";
                                //taskControl.TotalPremium     = 0.00; //Ya viene del quote.
                                //taskControl.NewUse			 = 2; //Ya viene del quote.
                                taskControl.AutoAssignPolicy = false; //Para que en VSC aparesca puedan entrar el num de pol manualmente.
                                taskControl.EffectiveDate = DateTime.Now.ToShortDateString();

                                Session["EndorsementQuote"] = taskControl;
                                FillTextControl();

                                //Se comento para que el performance sea mas rapido ya que en AutoGAp y VSC no se usa.
                                //ddlCovers.SelectedIndex = ddlCovers.Items.IndexOf(
                                //    ddlCovers.Items.FindByValue("1"));

                                //ddlLimits.Items.Clear();
                                //FillLimits();
                                //ddlLimits.SelectedIndex = ddlLimits.Items.IndexOf(
                                //    ddlLimits.Items.FindByText("100"));
                            }
                            VerifyAssignPolicyFields();
                            break;

                        default:
                            TxtTerm.Visible = true;
                            lblPolicyNo.Text = "Policy No.";
                            lblTotPremum.Text = "Tot. Premium";

                            chkPending.Visible = false;
                            VerifyAssignPolicyFields();

                            break;
                    }
                }
                else
                {
                    //lo mismo del default que esta arriba.
                    lblPolicyNo.Text = "Policy No.";
                    lblTotPremum.Text = "Tot. Premium";
                }
            }
            catch
            {
                //if (exp.InnerException == null)
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
                //else if (exp.InnerException.InnerException == null)
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
                //else
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                //         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("A problem occured while obtaining data. Please try again");
                this.litPopUp.Visible = true;
            }
        }
        protected void ddlSelectedAgent_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
        private void Calculate(DataTable dt)
        {
            double totalcargos = 0.00;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double precio = (double)dt.Rows[i]["Premium"];
                double subtotal = precio;
                totalcargos = totalcargos + subtotal;
            }
            TxtPremium.Text = totalcargos.ToString("###,###.00");
            TxtTotalPremium.Text = totalcargos.ToString("###,###.00");
        }
        protected void btnIncentives_Click(object sender, System.EventArgs e)
        {
            RemoveSessionLookUp();
            Session.Add("FromPage", "Policies.aspx");
            Response.Redirect("ViewIncentive.aspx");
        }
        protected void btnNew_Click(object sender, System.EventArgs e)
        {
            RemoveSessionLookUp();

            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

            taskControl.AgentList = Policy.GetAgentListByPolicyClassID(0);
            taskControl.DepartmentID = 0;
            taskControl.PolicyClassID = 0;
            taskControl.PolicyType = "";
            taskControl.InsuranceCompany = "";
            taskControl.Agency = "";
            taskControl.Agent = "";
            taskControl.SupplierID = "";
            taskControl.Bank = "000";
            taskControl.Dealer = "000";
            taskControl.CompanyDealer = "000";
            taskControl.TaskStatusID = int.Parse(LookupTables.LookupTables.GetID("TaskStatus", "Open"));
            taskControl.TaskControlTypeID = int.Parse(LookupTables.LookupTables.GetID("TaskControlType", "Policies"));
            taskControl.Status = "Inforce";
            taskControl.Mode = 1; //ADD
            taskControl.Suffix = "00";
            taskControl.CancellationDate = "";
            taskControl.CancellationEntryDate = "";
            taskControl.CancellationUnearnedPercent = 0.00;
            taskControl.CancellationMethod = 0;
            taskControl.CancellationReason = 0;
            taskControl.PaidAmount = 0.00;
            taskControl.PaidDate = "";
            taskControl.Ren_Rei = "";
            taskControl.Rein_Amt = 0.00;
            taskControl.PaidDate = "";
            taskControl.CommissionAgency = 0.00;
            taskControl.CommissionAgent = 0.00;
            taskControl.CommissionAgencyPercent = "";
            taskControl.CommissionAgentPercent = "";
            taskControl.TotalPremium = 0.00;
            taskControl.Charge = 0.00;
            taskControl.ReturnCharge = 0.00;
            taskControl.ReturnPremium = 0.00;
            taskControl.CancellationAmount = 0.00;
            taskControl.ReturnCommissionAgency = 0.00;
            taskControl.ReturnCommissionAgent = 0.00;
            taskControl.TaskControlID = 0;
            taskControl.Comments = "";
            taskControl.PolicyNo = "";
            taskControl.Certificate = "";
            taskControl.PolicyType = "";
            taskControl.Term = 0;
            taskControl.EffectiveDate = "";
            taskControl.ExpirationDate = "";

            taskControl.PolicyDetailcs.PolicyDetailTableTemp = null;
            Session.Add("TaskControl", taskControl);
            Response.Redirect("Policies.aspx", false);
        }
        protected void btnAdd2_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            TaskControl.Policies taskControl = new TaskControl.Policies();

            taskControl.Mode = 1; //ADD

            Session.Add("TaskControl", taskControl);
            Response.Redirect("Policies.aspx", false);
        }
        protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnBreakdown_Click(object sender, EventArgs e)
        {
            RemoveSessionLookUp();
            Session.Add("FromPage", "Policies.aspx");
            Response.Redirect("VSCBreakdown.aspx");
        }
        protected void ChkAutoAssignPolicy_CheckedChanged(object sender, EventArgs e)
        {
            VerifyAssignPolicyFields();
        }
        private void VerifyAssignPolicyFields()
        {
            if (this.ChkAutoAssignPolicy.Checked)
            {
                TxtPolicyType.Enabled = false;
                TxtPolicyNo.Enabled = false;
                TxtCertificate.Enabled = false;
                TxtSufijo.Enabled = false;
            }
            else
            {
                TxtPolicyType.Enabled = true;
                TxtPolicyNo.Enabled = true;
                TxtCertificate.Enabled = true;
                TxtSufijo.Enabled = true;
            }
        }
        protected void btnRenew_Click(object sender, EventArgs e)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];
            TaskControl.Policy policy = (TaskControl.Policy)Session["EndorsementQuote"];
            TaskControl.Policies policies = new TaskControl.Policies();

            try
            {
                policies = taskControl;
                policies.Mode = 1;
                policies.CancellationDate = "";
                policies.CancellationEntryDate = "";
                policies.CancellationUnearnedPercent = 0.00;
                policies.CancellationMethod = 0;
                policies.CancellationReason = 0;
                policies.PaidAmount = 0.00; // taskControl.PaidAmount;
                policies.PaidDate = "";
                policies.Ren_Rei = "RN";
                policies.Rein_Amt = taskControl.CancellationAmount;
                policies.PaidDate = taskControl.PaidDate;
                policies.CommissionAgency = 0.00; // taskControl.ReturnCommissionAgency;
                policies.CommissionAgent = 0.00; // taskControl.ReturnCommissionAgent;
                policies.CommissionAgencyPercent = ""; // taskControl.CommissionAgencyPercent.Trim();
                policies.CommissionAgentPercent = "";  //taskControl.CommissionAgentPercent.Trim();
                policies.TaskControlID = 0;
                policies.Status = "Inforce";

                policies.EntryDate = DateTime.Now;
                policies.EffectiveDate = (DateTime.Parse(policies.EffectiveDate).AddMonths(12)).ToShortDateString();
                policies.ExpirationDate = DateTime.Parse(policies.ExpirationDate).AddMonths(12).ToShortDateString();

                //CalculateCharge(true);
                policies.Charge = taskControl.Charge;
                policies.ReturnCharge = 0.00;
                policies.ReturnPremium = 0.00;
                policies.CancellationAmount = 0.00;
                policies.ReturnCommissionAgency = 0.00;
                policies.ReturnCommissionAgent = 0.00;

                int msufijo;
                int sufijo = int.Parse(taskControl.Suffix);
                msufijo = sufijo + 1;
                if(msufijo < 10)
                    policies.Suffix = "0".ToString() + msufijo.ToString();
                else
                    policies.Suffix = msufijo.ToString();

                int mAniv;
                int aniv = int.Parse(taskControl.Anniversary);
                mAniv = aniv + 1;

                if (mAniv < 10)
                    policies.Anniversary = "0".ToString() + mAniv.ToString();
                else
                    policies.Anniversary = mAniv.ToString();

                //TotalPremium segun edel ano del retrodate

                int RetroYear = 0;
                RetroYear = DateTime.Parse(policies.EffectiveDate).Year - DateTime.Parse(policies.RetroactiveDate).Year;
                switch (RetroYear)
                {
                    case 0:
                        policies.TotalPremium = taskControl.RateYear1;
                        break;
                    case 1:
                        policies.TotalPremium = taskControl.RateYear2;
                        break;
                    case 2:
                        policies.TotalPremium = taskControl.RateYear3;
                        break;
                    default:
                        policies.TotalPremium = taskControl.MCMRate;
                        break;
                }

                //Aplicar Descuento de Grupo en la renovacion.
                //debe cunplir con la cuota de Members
                //policies.InvoiceNumber = "0"; //Discount
                //if (policies.Bank != "000") //Bank = Group
                //{
                //    EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                //    master = master.GetMasterPolicyDiscount(taskControl.Bank, taskControl.EffectiveDate);

                //    if (policies.PolicyType.Trim() == "PE") //Excess
                //    {
                //        policies.InvoiceNumber = master.DescuentoExcess.ToString();
                //        double totprem = Math.Round(policies.TotalPremium - (policies.TotalPremium * (Math.Round(master.DescuentoExcess / 100, 2))), 0);
                //        policies.TotalPremium = totprem;
                //    }
                //    else // Primary
                //    {
                //        policies.InvoiceNumber = master.DescuentoExcess.ToString();
                //        double totprem = Math.Round(policies.TotalPremium - (policies.TotalPremium * (Math.Round(master.DescuentoPrimario / 100, 2))), 0);
                //        policies.TotalPremium = totprem;
                //    }
                //}

                Session.Clear();
                Session.Add("TaskControl", policies);
                Response.Redirect("Policies.aspx", false);
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }
        }
        private void SetDDLLimit(int LimitID)
        {
            //DataTable dtPRMEDICRATE1 = EPolicy.TaskControl.Application.GetPRMEDICRATE(LimitID);
            //DataTable dtPRMEDICRATE1 = EPolicy.LookupTables.LookupTables.GetTable("PRMEDICSpecialty");
            //ddlRate.Items.Clear();
            //ddlRate.DataSource = dtPRMEDICRATE1;
            //ddlRate.DataTextField = "PRMEDICSpecialtyDesc";
            //ddlRate.DataValueField = "IsoCode";
            //ddlRate.DataBind();
            //ddlRate.SelectedIndex = -1;
            //ddlRate.Items.Insert(0, "");
        }
        protected void DtSearchPayments_ItemCommand1(object source, DataGridCommandEventArgs e)
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

            if (e.Item.ItemType.ToString() != "Pager") // Select
            {
                int i = int.Parse(e.Item.Cells[1].Text);
                TaskControl.TaskControl taskControl = TaskControl.TaskControl.GetTaskControlByTaskControlID(i, userID);

                Session.Clear();
                Session["EndorsementQuote"] = taskControl;
                Response.Redirect("Policies.aspx?" + taskControl.TaskControlID, true);
            }
            else  // Pager
            {
                //DtSearchPayments.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                //DtSearchPayments.DataSource = (DataTable)Session["DtTaskPolicy"];
                //DtSearchPayments.DataBind();
            }
        }
        protected void ddlPrMedicalLimits_SelectedIndexChanged(object sender, EventArgs e)
        {
            Recalculate();
        }
        private void Recalculate()
        {
            try
            {
                TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

                DataTable dtPRMEDICRATE2 = null;
                DataTable dtPRMEDICRATEPRIMARY2 = null;

                if (txtIsoCode.Text.Trim() == "")
                {
                    throw new Exception("Please Fill the Iso Code Filed.");
                }

                if (taskControl.PolicyType.Trim() == "PE")
                    dtPRMEDICRATE2 = EPolicy.TaskControl.Application.GetPRMEDICRATEBYISOCODE(0, txtIsoCode.Text.Trim());
                else
                    dtPRMEDICRATEPRIMARY2 = EPolicy.TaskControl.Application.GetPRMEDICRATEPRIMARYBYISOCODE(0, txtIsoCode.Text.Trim());

                if (taskControl.PolicyType.Trim() == "PE")
                {
                    if (dtPRMEDICRATE2.Rows.Count > 0)
                    {
                        int index = 1;
                        for (int i = 0; dtPRMEDICRATE2.Rows.Count > i; i++)
                        {
                            string myString = dtPRMEDICRATE2.Rows[i]["PRMEDICRATEID"].ToString().Trim();
                            string[] myRateList = myString.Split('|');

                            if (int.Parse(ddlPrMedicalLimits.SelectedItem.Value) == int.Parse(myRateList[7].Trim()))
                            {
                                SetOtherRateFields(index, myRateList);
                                index = index + 1;
                            }
                        }
                    }
                }
                else
                {
                    if (dtPRMEDICRATEPRIMARY2.Rows.Count > 0)
                    {
                        int index = 1;
                        for (int i = 0; dtPRMEDICRATEPRIMARY2.Rows.Count > i; i++)
                        {
                            string myString = dtPRMEDICRATEPRIMARY2.Rows[i]["PRMEDICRATEID"].ToString().Trim();
                            string[] myRateList = myString.Split('|');

                            if (int.Parse(myRateList[0].Trim()) != 0)
                            {
                                if (int.Parse(ddlPrMedicalLimits.SelectedItem.Value) == int.Parse(myRateList[7].Trim()))
                                {
                                    SetPrimaryRates(index, myRateList);
                                    index = index + 1;
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(ex.Message);
                this.litPopUp.Visible = true;
            }
        }
        private void SetOtherRateFields(int index, string[] myRateList)
        {
            if (index == 1)
            {
                this.txtRate1.Text = myRateList[3];
                this.txtRate2.Text = myRateList[4];
                this.txtRate3.Text = myRateList[5];
                this.txtRate4.Text = myRateList[6];
            }
        }
        private void SetPrimaryRates(int index, string[] myRateList)
        {
            if (index == 1)
            {
                this.txtRate1.Text = myRateList[3];
                this.txtRate2.Text = myRateList[4];
                this.txtRate3.Text = myRateList[5];
                this.txtRate4.Text = myRateList[6];
            }
        }
        protected void ddlRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

            txtIsoCode.Text = ddlRate.SelectedItem.Value.Trim();
            Recalculate();

            if (!TxtPolicyType.Text.Contains("T"))
            {
                int RetroYear = 0;
                RetroYear = DateTime.Parse(txtEffDt.Text).Year - DateTime.Parse(TxtRetroactiveDate.Text).Year;
                switch (RetroYear)
                {
                    case 0:
                        taskControl.RateYear1 = double.Parse(txtRate1.Text);
                        break;
                    case 1:
                        taskControl.RateYear2 = double.Parse(txtRate2.Text);
                        break;
                    case 2:
                        taskControl.RateYear3 = double.Parse(txtRate3.Text);
                        break;
                    default:
                       taskControl.MCMRate = double.Parse(txtRate4.Text);
                        break;
                }
            }
            Session["EndorsementQuote"] = taskControl;

            Calculate();
            CalculateCharge();
        }
        private void UpdateInceptionPartialPayments(int taskControlID, double totprem)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            decimal prem = decimal.Parse(totprem.ToString());
            prem = prem * -1;

            DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, taskControlID.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TransactionAmount", SqlDbType.Money, 0, prem.ToString(), ref cookItems);

            DBRequest exec = new DBRequest();

            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
            DataTable dt = null;
            try
            {
                exec.Update("UpdateInceptionPartialPayments", xmlDoc);
            }
            catch (Exception ex)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Could not update Partial Payment.");
                this.litPopUp.Visible = true;
                //throw new Exception("Could not update Partial Payment.", ex);
            }
        }
        protected void btnPrintCertificate_Click(object sender, System.EventArgs e)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];
            string js = "<script language=javascript> javascript:popwindow=window.open('PrintCertificate.aspx','popwindow','toolbar=no,location=center,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width=850,height=450');popwindow.focus(); </script>";

            //Session.Clear();
            //Session["EndorsementQuote"] = taskControl;
            //Response.Redirect("Policies.aspx?" + taskControl.TaskControlID, true);

            Response.Write(js);
        }
        protected void btnTailQuote_Click(object sender, EventArgs e)
        {
            //TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];
            //taskControl.Mode = 5;
            //Session["EndorsementQuote"] = taskControl;

            FillProperties();

            string js = "<script language=javascript> javascript:popwindow=window.open('TailQuote.aspx','popwindow','modal=yes,toolbar=no,location=center,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,copyhistory=no,width=445,height=300');popwindow.focus(); </script>";
            //string js = "<script language=javascript> window.showModalDialog('TailQuote.aspx','scrollbars:no,resizable:no,dialogWidth:430px,dialogHeight:270px');</script>";
            //string js = "<script language=javascript> javascript:popwindow=window.open('TailQuote.aspx','null,width=430,height=270,modal=yes,alwaysRaised=yes,null);</script>";
            //window.open("modal.htm", null, "width=200,height=200,left=300,modal=yes,alwaysRaised=yes", null);
            //Session.Clear();
            //Session["EndorsementQuote"] = taskControl;
            //Response.Redirect("Policies.aspx?" + taskControl.TaskControlID, true);

            //btnRefresh.Visible = true;
            Response.Write(js);
        }
        protected void DisableControlsTail()
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

            if (taskControl.PolicyType.Contains("T"))
            {
                //btnRenew.Visible = false;
                //btnReinstatement.Visible = false;
                //btnPrintCertificate.Visible = false;
                //btnCancellation.Visible = false;
                //btnFinancialCanc.Visible = false;
                //btnPolicyCert.Visible = false;
                //btnTailQuote.Visible = false;

                Label5.Visible = false;
                TxtTerm.Visible = false;
                Label11.Visible = true;
                txtExpDt.Visible = true;
                lblDiscount.Visible = false;
                txtInvoiceNumber.Visible = false;
                ddlFinancial.Visible = false;
                lblFinancial.Visible = false;

                Label52.Visible = false;
                Label64.Visible = false;
                Button3.Visible = false;
                Label70.Visible = false;
                Label71.Visible = false;
                txtTotalPrimary.Visible = false;
                txtTotalExcess.Visible = false;
                pnlExcess.Visible = false;
                pnlPrimary.Visible = false;
                //btnPolicyCert.Visible = false;
            }
        }
        protected void CalculateCharge(object sender, EventArgs e)
        {
            CalculateCharge();
        }
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            FillGrid();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            ResetValues();
            Calculate();
            CalculateCharge();
        }
        private void Calculate()
        {
            EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["EndorsementQuote"];

            CalculateOthersRates();

            if (txtQuantityTN1.Text.Trim() == "")
                txtQuantityTN1.Text = "0";

            if (txtEQuantityTN1.Text.Trim() == "")
                txtEQuantityTN1.Text = txtQuantityTN1.Text.Trim();

            if (txtQuantityTN2.Text.Trim() == "")
                txtQuantityTN2.Text = "0";

            if (txtEQuantityTN2.Text.Trim() == "")
                txtEQuantityTN2.Text = txtQuantityTN2.Text.Trim();

            if (txtQuantityTN3.Text.Trim() == "")
                txtQuantityTN3.Text = "0";

            if (txtEQuantityTN3.Text.Trim() == "")
                txtEQuantityTN3.Text = txtQuantityTN3.Text.Trim();

            if (txtQuantityTN4.Text.Trim() == "")
                txtQuantityTN4.Text = "0";

            if (txtEQuantityTN4.Text.Trim() == "")
                txtEQuantityTN4.Text = txtQuantityTN4.Text.Trim();

            if (txtQuantityTN5.Text.Trim() == "")
                txtQuantityTN5.Text = "0";

            if (txtEQuantityTN5.Text.Trim() == "")
                txtEQuantityTN5.Text = txtQuantityTN5.Text.Trim();

            if (txtQuantityTN6.Text.Trim() == "")
                txtQuantityTN6.Text = "0";

            if (txtEQuantityTN6.Text.Trim() == "")
                txtEQuantityTN6.Text = txtQuantityTN6.Text.Trim();

            if (txtEQuantityTN1.Text.Trim() == "")
                txtEQuantityTN1.Text = "0";

            if (txtQuantityTN1.Text.Trim() == "0")
                txtQuantityTN1.Text = txtEQuantityTN1.Text.Trim();

            if (txtEQuantityTN2.Text.Trim() == "")
                txtEQuantityTN2.Text = "0";

            if (txtQuantityTN2.Text.Trim() == "0")
                txtQuantityTN2.Text = txtEQuantityTN2.Text.Trim();

            if (txtEQuantityTN3.Text.Trim() == "")
                txtEQuantityTN3.Text = "0";

            if (txtQuantityTN3.Text.Trim() == "0")
                txtQuantityTN3.Text = txtEQuantityTN3.Text.Trim();

            if (txtEQuantityTN4.Text.Trim() == "")
                txtEQuantityTN4.Text = "0";

            if (txtQuantityTN4.Text.Trim() == "0")
                txtQuantityTN4.Text = txtEQuantityTN4.Text.Trim();

            if (txtEQuantityTN5.Text.Trim() == "")
                txtEQuantityTN5.Text = "0";

            if (txtQuantityTN5.Text.Trim() == "0")
                txtQuantityTN5.Text = txtEQuantityTN5.Text.Trim();

            if (txtEQuantityTN6.Text.Trim() == "")
                txtEQuantityTN6.Text = "0";

            if (txtQuantityTN6.Text.Trim() == "0")
                txtQuantityTN6.Text = txtEQuantityTN6.Text.Trim();

            //Primary
            int quantity1 = int.Parse(txtQuantityTN1.Text.Trim());
            int quantity2 = int.Parse(txtQuantityTN2.Text.Trim());
            int quantity3 = int.Parse(txtQuantityTN3.Text.Trim());
            int quantity4 = int.Parse(txtQuantityTN4.Text.Trim());
            int quantity5 = int.Parse(txtQuantityTN5.Text.Trim());
            int quantity6 = quantity1 + quantity2 + quantity3 + quantity4 + quantity5;
            txtQuantityTN6.Text = quantity6.ToString();

            int tot1 = int.Parse(txtPremiumTN1.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtQuantityTN1.Text);
            txtTotPremTN1.Text = tot1.ToString("###,###,##0.00");

            int tot2 = int.Parse(txtPremiumTN2.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtQuantityTN2.Text);
            txtTotPremTN2.Text = tot2.ToString("###,###,##0.00");

            int tot3 = int.Parse(txtPremiumTN3.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtQuantityTN3.Text);
            txtTotPremTN3.Text = tot3.ToString("###,###,##0.00");

            int tot4 = int.Parse(txtPremiumTN4.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtQuantityTN4.Text);
            txtTotPremTN4.Text = tot4.ToString("###,###,##0.00");

            int tot5 = int.Parse(txtPremiumTN5.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtQuantityTN5.Text);
            txtTotPremTN5.Text = tot5.ToString("###,###,##0.00");

            int tot6 = tot1 + tot2 + tot3 + tot4 + tot5;
            double P1 = Math.Round(double.Parse(tot6.ToString()) * (double.Parse(txtRateTN6.Text.Replace("%", "")) / 100), 0);
            txtTotPremTN6.Text = P1.ToString("###,###,##0.00");

            //Excess
            int Equantity1 = int.Parse(txtEQuantityTN1.Text.Trim());
            int Equantity2 = int.Parse(txtEQuantityTN2.Text.Trim());
            int Equantity3 = int.Parse(txtEQuantityTN3.Text.Trim());
            int Equantity4 = int.Parse(txtEQuantityTN4.Text.Trim());
            int Equantity5 = int.Parse(txtEQuantityTN5.Text.Trim());
            int Equantity6 = Equantity1 + Equantity2 + Equantity3 + Equantity4 + Equantity5;
            txtEQuantityTN6.Text = Equantity6.ToString();

            int tot10 = int.Parse(txtEPremiumTN1.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtEQuantityTN1.Text);
            txtETotPremTN1.Text = tot10.ToString("###,###,##0.00");

            int tot20 = int.Parse(txtEPremiumTN2.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtEQuantityTN2.Text);
            txtETotPremTN2.Text = tot20.ToString("###,###,##0.00");

            int tot30 = int.Parse(txtEPremiumTN3.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtEQuantityTN3.Text);
            txtETotPremTN3.Text = tot30.ToString("###,###,##0.00");

            int tot40 = int.Parse(txtEPremiumTN4.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtEQuantityTN4.Text);
            txtETotPremTN4.Text = tot40.ToString("###,###,##0.00");

            int tot50 = int.Parse(txtEPremiumTN5.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtEQuantityTN5.Text);
            txtETotPremTN5.Text = tot50.ToString("###,###,##0.00");

            int tot60 = tot10 + tot20 + tot30 + tot40 + tot50;
            double P2 = Math.Round(double.Parse(tot60.ToString()) * (double.Parse(txtERateTN6.Text.Replace("%", "")) / 100), 0);
            txtETotPremTN6.Text = P2.ToString("###,###,##0.00");

            int totPrimaryPremium = int.Parse(taskControl.TotalPremium.ToString()) + int.Parse(P1.ToString());
            txtTotalPrimary.Text = totPrimaryPremium.ToString("###,###,##0.00");

            int totExcessPremium = int.Parse(taskControl.TotalPremium.ToString()) + int.Parse(P2.ToString());
            txtTotalExcess.Text = totExcessPremium.ToString("###,###,##0.00");

            if (taskControl.PolicyType.Trim() == "PP")
            {
                //TxtPremium.Text = (totPrimaryPremium - double.Parse(TxtCharge.Text)).ToString("###,###,###.00");
                TxtPremium.Text = (totPrimaryPremium - P1).ToString("###,###,##0.00");
                TxtTotalPremium.Text = (double.Parse(TxtCharge.Text) + totPrimaryPremium).ToString("###,###,##0.00");
                //txtRate4.Text = totPrimaryPremium.ToString("###,###,###.00"); 

            }
            else
            {
                //TxtPremium.Text = (totExcessPremium - double.Parse(TxtCharge.Text)).ToString("###,###,###.00");
                TxtPremium.Text = (totExcessPremium - P2).ToString("###,###,##0.00");
                TxtTotalPremium.Text = (double.Parse(TxtCharge.Text) + totExcessPremium).ToString("###,###,##0.00");
                //txtRate4.Text = totExcessPremium.ToString("###,###,###.00");
            }
        }
        private void CalculateOthersRates()
        {
            if (TxtRetroactiveDate.Text != String.Empty)
            {
                DateTime retroActiveDate = Convert.ToDateTime(TxtRetroactiveDate.Text.Trim());
                TimeSpan result = DateTime.Now - retroActiveDate;
                double days = result.TotalDays;
                double mcmRate = 0.0;

                if (days <= 365)
                    mcmRate = 0.6;
                else if (days > 365 && days <= 730)
                    mcmRate = 0.8;
                else if (days > 730 && days <= 1095)
                    mcmRate = 0.9;
                else
                    mcmRate = 1;

                //Primary
                if (txtRateTN1.Text.Trim() == "")
                    txtRateTN1.Text = "0";
                if (txtRateTN2.Text.Trim() == "")
                    txtRateTN2.Text = "0";
                if (txtRateTN3.Text.Trim() == "")
                    txtRateTN3.Text = "0";
                if (txtRateTN4.Text.Trim() == "")
                    txtRateTN4.Text = "0";
                if (txtRateTN5.Text.Trim() == "")
                    txtRateTN5.Text = "0";
                if (txtRateTN6.Text.Trim() == "")
                    txtRateTN6.Text = "0";

                double P1 = Math.Round((double.Parse(txtPrimaryTN1.Text) * (double.Parse(txtRateTN1.Text.Replace("%", "")) / 100)) * mcmRate, 0);
                double P2 = Math.Round((double.Parse(txtPrimaryTN2.Text) * (double.Parse(txtRateTN2.Text.Replace("%", "")) / 100)) * mcmRate, 0);
                double P3 = Math.Round((double.Parse(txtPrimaryTN3.Text) * (double.Parse(txtRateTN3.Text.Replace("%", "")) / 100)) * mcmRate, 0);
                double P4 = Math.Round((double.Parse(txtPrimaryTN4.Text) * (double.Parse(txtRateTN4.Text.Replace("%", "")) / 100)) * mcmRate, 0);
                double P5 = Math.Round((double.Parse(txtPrimaryTN5.Text) * (double.Parse(txtRateTN5.Text.Replace("%", "")) / 100)) * mcmRate, 0);

                txtPremiumTN1.Text = P1.ToString("###,##0.00");
                txtPremiumTN2.Text = P2.ToString("###,##0.00");
                txtPremiumTN3.Text = P3.ToString("###,##0.00");
                txtPremiumTN4.Text = P4.ToString("###,##0.00");
                txtPremiumTN5.Text = P5.ToString("###,##0.00");

                //Excess
                if (txtERateTN1.Text.Trim() == "")
                    txtERateTN1.Text = "0";
                if (txtERateTN2.Text.Trim() == "")
                    txtERateTN2.Text = "0";
                if (txtERateTN3.Text.Trim() == "")
                    txtERateTN3.Text = "0";
                if (txtERateTN4.Text.Trim() == "")
                    txtERateTN4.Text = "0";
                if (txtERateTN5.Text.Trim() == "")
                    txtERateTN5.Text = "0";
                if (txtERateTN6.Text.Trim() == "")
                    txtERateTN6.Text = "0";

                double E1 = Math.Round((double.Parse(txtExcessTN1.Text) * (double.Parse(txtERateTN1.Text.Replace("%", "")) / 100)) * mcmRate, 0);
                double E2 = Math.Round((double.Parse(txtExcessTN2.Text) * (double.Parse(txtERateTN2.Text.Replace("%", "")) / 100)) * mcmRate, 0);
                double E3 = Math.Round((double.Parse(txtExcessTN3.Text) * (double.Parse(txtERateTN3.Text.Replace("%", "")) / 100)) * mcmRate, 0);
                double E4 = Math.Round((double.Parse(txtExcessTN4.Text) * (double.Parse(txtERateTN4.Text.Replace("%", "")) / 100)) * mcmRate, 0);
                double E5 = Math.Round((double.Parse(txtExcessTN5.Text) * (double.Parse(txtERateTN5.Text.Replace("%", "")) / 100)) * mcmRate, 0);

                txtEPremiumTN1.Text = E1.ToString("###,##0.00");
                txtEPremiumTN2.Text = E2.ToString("###,##0.00");
                txtEPremiumTN3.Text = E3.ToString("###,##0.00");
                txtEPremiumTN4.Text = E4.ToString("###,##0.00");
                txtEPremiumTN5.Text = E5.ToString("###,##0.00");
            }
            //else
            //{
            //    this.litPopUp.Text = "Please introduce a retroactive date.";
            //    this.litPopUp.Visible = true;
            //}
        }
        private void GetOthersRates()
        {
            try
            {
                if (ddlPrMedicalLimits.SelectedItem.Value.Trim() != "")
                {
                    //Primary
                    DataTable dt1 = TaskControl.Policies.GetPRMEDICRATEPRIMARYByClassAndLimitID("1", int.Parse(ddlPrMedicalLimits.SelectedItem.Value.Trim()));
                    DataTable dt2 = TaskControl.Policies.GetPRMEDICRATEPRIMARYByClassAndLimitID("7", int.Parse(ddlPrMedicalLimits.SelectedItem.Value.Trim()));
                    DataTable dt3 = TaskControl.Policies.GetPRMEDICRATEPRIMARYByClassAndLimitID("3A", int.Parse(ddlPrMedicalLimits.SelectedItem.Value.Trim()));

                    if (dt1.Rows.Count > 0 && dt2.Rows.Count > 0 && dt3.Rows.Count > 0)
                    {
                        txtPrimaryTN1.Text = (double.Parse(dt1.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                        txtPrimaryTN2.Text = (double.Parse(dt2.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                        txtPrimaryTN3.Text = (double.Parse(dt3.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                        txtPrimaryTN4.Text = (double.Parse(dt1.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                        txtPrimaryTN5.Text = (double.Parse(dt1.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                    }


                    //Excess
                    DataTable dt4 = TaskControl.Policies.GetPRMEDICRATEByClassAndLimitID("1", int.Parse(ddlPrMedicalLimits.SelectedItem.Value.Trim()));
                    DataTable dt5 = TaskControl.Policies.GetPRMEDICRATEByClassAndLimitID("7", int.Parse(ddlPrMedicalLimits.SelectedItem.Value.Trim()));
                    DataTable dt6 = TaskControl.Policies.GetPRMEDICRATEByClassAndLimitID("3A", int.Parse(ddlPrMedicalLimits.SelectedItem.Value.Trim()));

                    if (dt4.Rows.Count > 0 && dt5.Rows.Count > 0 && dt6.Rows.Count > 0)
                    {
                        txtExcessTN1.Text = (double.Parse(dt4.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                        txtExcessTN2.Text = (double.Parse(dt5.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                        txtExcessTN3.Text = (double.Parse(dt6.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                        txtExcessTN4.Text = (double.Parse(dt4.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                        txtExcessTN5.Text = (double.Parse(dt4.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                    }

                    CalculateOthersRates();
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

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to obtain rates.");
                this.litPopUp.Visible = true;
            }
        }
        private void ResetValues()
        {
            EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["EndorsementQuote"];

            if (!pnlPrimary.Visible)
            {
                txtQuantityTN1.Text = "";
                txtQuantityTN2.Text = "";
                txtQuantityTN3.Text = "";
                txtQuantityTN4.Text = "";
                txtQuantityTN5.Text = "";
                txtQuantityTN6.Text = "";
            }

            if (!pnlExcess.Visible)
            {
                txtEQuantityTN1.Text = "";
                txtEQuantityTN2.Text = "";
                txtEQuantityTN3.Text = "";
                txtEQuantityTN4.Text = "";
                txtEQuantityTN5.Text = "";
                txtEQuantityTN6.Text = "";
            }

            txtTotPremTN1.Text = "";
            txtTotPremTN2.Text = "";
            txtTotPremTN3.Text = "";
            txtTotPremTN4.Text = "";
            txtTotPremTN5.Text = "";


            txtETotPremTN1.Text = "";
            txtETotPremTN2.Text = "";
            txtETotPremTN3.Text = "";
            txtETotPremTN4.Text = "";
            txtETotPremTN5.Text = "";

            if (txtTotPremTN6.Text == "")
                txtTotPremTN6.Text = "0";

            if (txtETotPremTN6.Text == "")
                txtETotPremTN6.Text = "0";

            double totPrimaryPremium = double.Parse(txtTotPremTN6.Text);
            double totExcessPremium = double.Parse(txtETotPremTN6.Text);

            if (totPrimaryPremium != 0.0 || totExcessPremium != 0.0)
            {
                TxtTotalPremium.Text = (taskControl.TotalPremium + taskControl.Charge).ToString("###,###,##0.00");

                //if (this.TxtPolicyType.Text.Trim() == "PP")
                //{
                //    //TxtPremium.Text = ((double.Parse(TxtPremium.Text) - double.Parse(TxtCharge.Text)) - totPrimaryPremium).ToString("###,###,###.00");
                //    TxtTotalPremium.Text = (double.Parse(TxtPremium.Text) + double.Parse(TxtCharge.Text)).ToString("###,###,##0.00");
                //    //txtRate4.Text = (double.Parse(txtRate4.Text) - totPrimaryPremium).ToString("###,###,###.00");

                //}
                ////else
                ////{
                ////    //TxtPremium.Text = ((double.Parse(TxtPremium.Text) - double.Parse(TxtCharge.Text)) - totExcessPremium).ToString("###,###,###.00");
                ////    TxtTotalPremium.Text = (double.Parse(TxtTotalPremium.Text) - totExcessPremium).ToString("###,###,##0.00");
                ////    //txtRate4.Text = (double.Parse(txtRate4.Text) - totExcessPremium).ToString("###,###,###.00");
                ////}
            }

            txtTotPremTN6.Text = "";
            txtETotPremTN6.Text = "";

            txtTotalPrimary.Text = "";
            txtTotalExcess.Text = "";

        }
        protected void CalculateCharge()
        {
            DateTime effDateBuffer;
            DateTime retroDateBuffer;

            if (!DateTime.TryParse(txtEffDt.Text, out effDateBuffer) || !DateTime.TryParse(TxtRetroactiveDate.Text, out retroDateBuffer)
                || txtEffDt.Text == "" || TxtRetroactiveDate.Text == "")
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Error found in Effective Date or Retroactive Date.");
                this.litPopUp.Visible = true;
            }
            else
            {
                if (Session["EndorsementQuote"] != null)
                {
                    TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];
                    //FillProperties();
                    DataTable dtCharge = LookupTables.LookupTables.GetTable("Charge");
                    int result = 0;
                    double additionalPremium = 0.0;

                    if (taskControl.PolicyType.Trim() == "PP")
                        additionalPremium = double.Parse(txtTotPremTN6.Text);
                    else
                        additionalPremium = double.Parse(txtETotPremTN6.Text);

                    if (!TxtPolicyType.Text.Contains("T"))
                    {
                        if (!chkUserMod.Checked)
                        {
                            int RetroYear = 0;
                            RetroYear = DateTime.Parse(txtEffDt.Text).Year - DateTime.Parse(TxtRetroactiveDate.Text).Year;
                            switch (RetroYear)
                            {
                                case 0:
                                    taskControl.TotalPremium = double.Parse(txtRate1.Text) + additionalPremium;//taskControl.RateYear1;                                    
                                    break;
                                case 1:
                                    taskControl.TotalPremium = double.Parse(txtRate2.Text) + additionalPremium;//taskControl.RateYear2;                                    
                                    break;
                                case 2:
                                    taskControl.TotalPremium = double.Parse(txtRate3.Text) + additionalPremium;//taskControl.RateYear3;                                    
                                    break;
                                default:
                                    taskControl.TotalPremium = double.Parse(txtRate4.Text) + additionalPremium;//taskControl.MCMRate;                                    
                                    break;
                            }
                        }
                        else
                        {
                            taskControl.TotalPremium = double.Parse(TxtUserPremium.Text);
                        }
                    }


                    //if (!chkUserMod.Checked)
                    //{
                    //    //Aplicar Descuento de Grupo en la renovacion.
                    //    //debe cunplir con la cuota de Members
                    //    taskControl.InvoiceNumber = "0"; //Discount
                    //    if (taskControl.Bank != "000") //Bank = Group
                    //    {
                    //        EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                    //        master = master.GetMasterPolicyDiscount(taskControl.Bank, taskControl.EffectiveDate);

                    //        if (taskControl.PolicyType.Trim() == "PE") //Excess
                    //        {
                    //            taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                    //            double totprem = Math.Round(taskControl.TotalPremium - (taskControl.TotalPremium * (Math.Round(master.DescuentoExcess / 100, 2))), 0);
                    //            taskControl.TotalPremium = totprem;
                    //        }
                    //        else // Primary
                    //        {
                    //            taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                    //            double totprem = Math.Round(taskControl.TotalPremium - (taskControl.TotalPremium * (Math.Round(master.DescuentoPrimario / 100, 2))), 0);
                    //            taskControl.TotalPremium = totprem;
                    //        }
                    //    }
                    //}

                    if (taskControl.Anniversary == "01")
                    {
                        for (int i = 0; i < dtCharge.Rows.Count; i++)
                        {
                            result = DateTime.Compare(DateTime.Parse(txtEffDt.Text.ToString().Trim()),
                                     DateTime.Parse(dtCharge.Rows[i]["effectiveDate"].ToString()));

                            if (result == 0 || result == 1)
                            {
                                double chargePercent = double.Parse(dtCharge.Rows[i]["chargePercent"].ToString());
                                var decPlaces = (((taskControl.TotalPremium) * chargePercent) % 1) * 100;
                                int rounded = 0;

                                if (decPlaces >= 50)
                                    rounded = (int)Math.Ceiling((taskControl.TotalPremium) * chargePercent);
                                else
                                    rounded = (int)Math.Floor((taskControl.TotalPremium) * chargePercent);

                                TxtCharge.Text = rounded.ToString("###,###.#0").Trim();
                                TxtPremium.Text = taskControl.TotalPremium.ToString("###,###.#0").Trim();
                                TxtTotalPremium.Text = (taskControl.TotalPremium + rounded).ToString("###,###.#0").Trim();
                                txtTotalPrimary.Text = (taskControl.TotalPremium + rounded).ToString("###,###.#0").Trim();
                                txtTotalExcess.Text = (taskControl.TotalPremium + rounded).ToString("###,###.#0").Trim();
                                taskControl.Charge = double.Parse(rounded.ToString("###,###.#0").Trim());
                                lblCharge.Visible = true;
                                lblCharge.Text = "(" + chargePercent.ToString() + ")";
                                break;
                            }
                            else
                            {
                                TxtCharge.Text = "0.00";
                                TxtPremium.Text = taskControl.TotalPremium.ToString("###,###.#0").Trim();
                                TxtTotalPremium.Text = (taskControl.TotalPremium + 0).ToString("###,###.#0").Trim();
                                txtTotalPrimary.Text = (taskControl.TotalPremium +  0).ToString("###,###.#0").Trim();
                                txtTotalExcess.Text = (taskControl.TotalPremium + 0).ToString("###,###.#0").Trim();
                                
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dtCharge.Rows.Count; i++)
                        {
                            result = DateTime.Compare(DateTime.Parse(txtEffDt.Text.ToString().Trim()),
                                     DateTime.Parse(dtCharge.Rows[i]["effectiveDate"].ToString()));

                            if ((result == 0 || result == 1) && bool.Parse(dtCharge.Rows[i]["renewalsOnly"].ToString()))
                            {
                                double chargePercent = double.Parse(dtCharge.Rows[i]["chargePercent"].ToString());
                                var decPlaces = (((taskControl.TotalPremium) * chargePercent) % 1) * 100;
                                int rounded = 0;

                                if (decPlaces >= 50)
                                    rounded = (int)Math.Ceiling((taskControl.TotalPremium) * chargePercent);
                                else
                                    rounded = (int)Math.Floor((taskControl.TotalPremium ) * chargePercent);

                                TxtCharge.Text = rounded.ToString("###,##0.00").Trim();
                                TxtPremium.Text = (taskControl.TotalPremium).ToString("###,##0.00").Trim();
                                TxtTotalPremium.Text = (taskControl.TotalPremium + rounded).ToString("###,##0.00").Trim();
                                txtTotalPrimary.Text = (taskControl.TotalPremium + rounded).ToString("###,###.#0").Trim();
                                txtTotalExcess.Text = (taskControl.TotalPremium + rounded).ToString("###,###.#0").Trim();
                                taskControl.Charge = double.Parse(rounded.ToString("###,##0.00").Trim());
                                lblCharge.Visible = true;
                                lblCharge.Text = "(" + chargePercent.ToString() + ")";
                                break;
                            }
                            else
                            {
                                TxtCharge.Text = "0.00";
                                TxtPremium.Text = taskControl.TotalPremium.ToString("###,###.#0").Trim();
                                TxtTotalPremium.Text = (taskControl.TotalPremium + 0).ToString("###,###.#0").Trim();
                                txtTotalPrimary.Text = (taskControl.TotalPremium + 0).ToString("###,###.#0").Trim();
                                txtTotalExcess.Text = (taskControl.TotalPremium + 0).ToString("###,###.#0").Trim();
                                
                            }
                        }
                    }
                }
            }
        }
        protected void btnPolicyCert_Click(object sender, EventArgs e)
        {
            try
            {
                TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

                if (taskControl.PolicyType.Trim() == "PP")
                {
                    DataDynamics.ActiveReports.ActiveReport3 rpt = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt1 = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt3 = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt4 = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt5 = null;

                    rpt = new EPolicy2.Reports.PRMdic.PrimaryPolicy(taskControl);
                    rpt.Document.Printer.PrinterName = "";
                    rpt.Run(false);

                    rpt1 = new EPolicy2.Reports.PRMdic.PrimaryPolicy1((EPolicy.TaskControl.Policy)taskControl, true);
                    rpt1.Document.Printer.PrinterName = "";
                    rpt1.Run(false);
                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt1.Document.Pages);

                    rpt2 = new EPolicy2.Reports.PRMdic.PrimaryPolicy2((EPolicy.TaskControl.Policy)taskControl, true);
                    rpt2.Document.Printer.PrinterName = "";
                    rpt2.Run(false);
                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages);

                    if (taskControl.EffectiveDate.Trim() != taskControl.RetroactiveDate.Trim())
                    {
                        rpt3 = new EPolicy2.Reports.PRMdic.PrimaryPriorAct((EPolicy.TaskControl.Policy)taskControl, true);
                        rpt3.Document.Printer.PrinterName = "";
                        rpt3.Run(false);
                        rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages);
                    }

                    rpt4 = new EPolicy2.Reports.PRMdic.PrimarySchedulerEndorsement((EPolicy.TaskControl.Policy)taskControl, true);
                    rpt4.Document.Printer.PrinterName = "";
                    rpt4.Run(false);
                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt4.Document.Pages);

                    rpt5 = new EPolicy2.Reports.PRMdic.PrimaryStatementAcceptance((EPolicy.TaskControl.Policy)taskControl, true);
                    rpt5.Document.Printer.PrinterName = "";
                    rpt5.Run(false);
                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt5.Document.Pages);

                    History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY CERT. DOCUMENT.");

                    RemoveSessionLookUp();
                    Session.Add("Report", rpt);
                    Session.Add("FromPage", "Policies.aspx");
                    Response.Redirect("ActiveXViewer.aspx");

                }
                else //PE.
                {
                    DataDynamics.ActiveReports.ActiveReport3 rpt = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt1 = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt3 = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt4 = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt5 = null;

                    rpt = new EPolicy2.Reports.PRMdic.Poliza(taskControl);
                    rpt.Document.Printer.PrinterName = "";
                    rpt.Run(false);

                    rpt1 = new EPolicy2.Reports.PRMdic.Poliza1(taskControl, true, ddlPrMedicalLimits.SelectedItem.Text.ToString());
                    rpt1.Document.Printer.PrinterName = "";
                    rpt1.Run(false);
                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt1.Document.Pages);

                    rpt2 = new EPolicy2.Reports.PRMdic.Poliza2B(taskControl, true);
                    rpt2.Document.Printer.PrinterName = "";
                    rpt2.Run();
                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages);

                    if (taskControl.EffectiveDate.Trim() != taskControl.RetroactiveDate.Trim())
                    {
                        rpt3 = new EPolicy2.Reports.PRMdic.PriorAct(taskControl, true);
                        rpt3.Document.Printer.PrinterName = "";
                        rpt3.Run(false);
                        rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages); //Page 3
                    }

                    rpt4 = new EPolicy2.Reports.PRMdic.SchedulerEndorsement((EPolicy.TaskControl.Policy)taskControl, true);
                    rpt4.Document.Printer.PrinterName = "";
                    rpt4.Run(false);
                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt4.Document.Pages);

                    rpt5 = new EPolicy2.Reports.PRMdic.StatementAcceptance((EPolicy.TaskControl.Policy)taskControl, true);
                    rpt5.Document.Printer.PrinterName = "";
                    rpt5.Run(false);
                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt5.Document.Pages);

                    History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY CERT. DOCUMENT.");

                    RemoveSessionLookUp();
                    Session.Add("Report", rpt);
                    Session.Add("FromPage", "Policies.aspx");
                    Response.Redirect("ActiveXViewer.aspx");
                }
            }
            catch (Exception ex)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("A problem occured while generating the report.");
                this.litPopUp.Visible = true;
                //throw new Exception("Could not update Partial Payment.", ex);
            }
        }
        protected void TxtPremium_TextChanged(object sender, EventArgs e)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];
            double additionalPremium = 0.0;

            if (taskControl.PolicyType.Trim() == "PP")
                additionalPremium = taskControl.TotPremTN6;
            else
                additionalPremium = taskControl.ETotPremTN6;

            if (TxtPremium.Text != "" && TxtPremium.Text != (taskControl.TotalPremium + additionalPremium).ToString())
            {
                chkUserMod.Checked = true;
                TxtUserPremium.Text = TxtPremium.Text;
            }
            else
            {
                chkUserMod.Checked = false;
                TxtUserPremium.Text = "";
            }
        }
        protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

            txtRate1.Text = taskControl.RateYear1.ToString("###,##0.00");
            txtRate2.Text = taskControl.RateYear2.ToString("###,##0.00");
            txtRate3.Text = taskControl.RateYear3.ToString("###,##0.00");
            txtRate4.Text = taskControl.MCMRate.ToString("###,##0.00");

            if (ddlGroup.SelectedIndex > 0 && ddlGroup.SelectedItem != null)
                taskControl.Bank = ddlGroup.SelectedItem.Value;
            else
                taskControl.Bank = "000";

            taskControl.InvoiceNumber = "0"; //Discount
            if (taskControl.Bank != "000") //Bank = Group
            {
                EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                master = master.GetMasterPolicyDiscount(taskControl.Bank, taskControl.EffectiveDate);

                if (taskControl.PolicyType.Trim() == "PE") //Excess
                {
                    taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                    txtRate1.Text = Math.Round(taskControl.RateYear1 - (taskControl.RateYear1 * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
                    txtRate2.Text = Math.Round(taskControl.RateYear2 - (taskControl.RateYear2 * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
                    txtRate3.Text = Math.Round(taskControl.RateYear3 - (taskControl.RateYear3 * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
                    txtRate4.Text = Math.Round(taskControl.MCMRate - (taskControl.MCMRate * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
                }
                else // Primary
                {
                    taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                    txtRate1.Text = Math.Round(taskControl.RateYear1 - (taskControl.RateYear1 * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
                    txtRate2.Text = Math.Round(taskControl.RateYear2 - (taskControl.RateYear2 * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
                    txtRate3.Text = Math.Round(taskControl.RateYear3 - (taskControl.RateYear3 * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
                    txtRate4.Text = Math.Round(taskControl.MCMRate - (taskControl.MCMRate * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
                }
            }
            txtInvoiceNumber.Text = taskControl.InvoiceNumber;

            //TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

            //if (ddlGroup.SelectedIndex > 0 && ddlGroup.SelectedItem != null)
            //    taskControl.Bank = ddlGroup.SelectedItem.Value;
            //else
            //    taskControl.Bank = "000";

            //taskControl.InvoiceNumber = "0"; //Discount
            //if (taskControl.Bank != "000") //Bank = Group
            //{
            //    EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
            //    master = master.GetMasterPolicyDiscount(taskControl.Bank, taskControl.EffectiveDate);

            //    if (taskControl.PolicyType.Trim() == "PE") //Excess
            //    {
            //        taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
            //        txtRate1.Text = Math.Round(taskControl.RateYear1 - (taskControl.RateYear1 * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
            //        txtRate2.Text = Math.Round(taskControl.RateYear2 - (taskControl.RateYear2 * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
            //        txtRate3.Text = Math.Round(taskControl.RateYear3 - (taskControl.RateYear3 * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
            //        txtRate4.Text = Math.Round(taskControl.MCMRate - (taskControl.MCMRate * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
            //    }
            //    else // Primary
            //    {
            //        taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
            //        txtRate1.Text = Math.Round(taskControl.RateYear1 - (taskControl.RateYear1 * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
            //        txtRate2.Text = Math.Round(taskControl.RateYear2 - (taskControl.RateYear2 * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
            //        txtRate3.Text = Math.Round(taskControl.RateYear3 - (taskControl.RateYear3 * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
            //        txtRate4.Text = Math.Round(taskControl.MCMRate - (taskControl.MCMRate * (Math.Round(master.DescuentoExcess / 100, 2))), 0).ToString("###,##0.00");
            //    }
            //}
            //txtInvoiceNumber.Text = taskControl.InvoiceNumber;
        }
        protected void btnEnablePrint_Click(object sender, EventArgs e)
        {
            try
            {
                TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

                taskControl.PrintPolicy = false;
                taskControl.Mode = 2;
                FillProperties();
                History(taskControl.TaskControlID, userID, "LOCK", "POLICIES", "ENABLED POLICY PRINTING.");
                taskControl.SavePolicies(userID);

                //btnEnablePrint.Visible = false;
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Enabled Policy Printing");
                this.litPopUp.Visible = true;
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

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to unlock policy printing feature.");
                this.litPopUp.Visible = true;
            }
        }
        protected void btnRegistry_Click(object sender, EventArgs e)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];

            RemoveSessionLookUp();
            Session.Add("FromUI", "Policies.aspx");
            Response.Redirect("Registry.aspx", false);

            //string js = "<script language=javascript> javascript:popwindow=window.open('Registry.aspx','popwindow','toolbar=no,location=center,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width=850,height=720');popwindow.focus(); </script>";

            //Session.Clear();
            //Session["EndorsementQuote"] = taskControl;
            //Response.Redirect("Policies.aspx?" + taskControl.TaskControlID, true);

            //Response.Write(js);
        }



        #region EndorsementDetail
        protected void BtnCancelEndorsement_Click(object sender, EventArgs e)
        {
            //txtEndorseNo.Text       = "";
            //txtEndorsePrepDate.Text = "";
            //txtEndorseEffDt.Text    = "";
            //txtEndorsePrem.Text     = "";
            //txtEndorseComment.Text  = "";
            //ddlEndorsementType.SelectedIndex = 0;
        }

        //protected void btnAddEndorsement_Click(object sender, EventArgs e)
        //{
        //    TaskControl.Policies taskControl = (TaskControl.Policies)Session["EndorsementQuote"];
        //    try
        //    {
        //        if (txtEndorseNo.Text.Trim() == "")
        //        {
        //            throw new Exception("Must enter an endorsement number.");
        //        }
        //        if (txtEndorsePrepDate.Text.Trim() == "")
        //        {
        //            throw new Exception("Must enter an endorsement preparation date.");
        //        }
        //        if (txtEndorseEffDt.Text.Trim() == "")
        //        {
        //            throw new Exception("Must enter an endorsement effective date.");
        //        }
        //        if (txtEndorsePrem.Text.Trim() == "")
        //        {
        //            throw new Exception("Must enter a premium per endorsement.");
        //        }
        //        if (ddlEndorsementType.SelectedValue == "")
        //        {
        //            throw new Exception("Must choose an endorsement type.");
        //        }

        //        if (txtEndorsementDetailID.Text.Trim() != "" && taskControl.EndorsementCollection.Rows.Count != 0)
        //        {
        //            taskControl.EndorsementCollection.Rows[toEditID]["EndorseNo"]      = txtEndorseNo.Text.Trim();
        //            taskControl.EndorsementCollection.Rows[toEditID]["EndorsePrepDt"]  = txtEndorsePrepDate.Text.Trim();
        //            taskControl.EndorsementCollection.Rows[toEditID]["EndorseEffDt"]   = txtEndorseEffDt.Text.Trim();
        //            taskControl.EndorsementCollection.Rows[toEditID]["EndorsePrem"]    = txtEndorsePrem.Text.Trim();
        //            taskControl.EndorsementCollection.Rows[toEditID]["EndorseType"]    = ddlEndorsementType.SelectedIndex;
        //            taskControl.EndorsementCollection.Rows[toEditID]["EndorseComment"] = txtEndorseComment.Text.Trim();

        //            taskControl.EndorsementCollection.AcceptChanges();
        //        }
        //        else
        //        {
        //            DataRow myRow = taskControl.EndorsementCollection.NewRow();

        //            myRow["TaskControlID"]  = taskControl.TaskControlID;
        //            myRow["EndorseNo"]      = txtEndorseNo.Text;
        //            myRow["EndorsePrepDt"]  = txtEndorsePrepDate.Text;
        //            myRow["EndorseEffDt"]   = txtEndorseEffDt.Text;
        //            myRow["EndorsePrem"]    = txtEndorsePrem.Text;
        //            myRow["EndorseType"]    = ddlEndorsementType.SelectedValue;
        //            myRow["EndorseComment"] = txtEndorseComment.Text.Trim();

        //            taskControl.EndorsementCollection.Rows.Add(myRow);
        //            taskControl.EndorsementCollection.AcceptChanges();
        //        }

        //        DtEndorsement = taskControl.EndorsementCollection;

        //        FillEndorsementCollectionDataGrid();

        //        toEditID = 0;

        //        txtEndorseNo.Text       = "";
        //        txtEndorsePrepDate.Text = "";
        //        txtEndorseEffDt.Text    = "";
        //        txtEndorsePrem.Text     = "";
        //        ddlEndorsementType.SelectedIndex = 0;
        //        txtEndorseComment.Text      = "";
        //        txtEndorsementDetailID.Text = "";
        //    }
        //    catch (Exception exp)
        //    {
        //        this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
        //        this.litPopUp.Visible = true;
        //    }
        //}

        protected void DtEndorsements_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["EndorsementQuote"];

            try
            {
                EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
                int userID = 0;
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                switch (e.CommandName)
                {
                    case "Select":
                        //this.btnAddEndorsement.Text      = "Save";
                        //txtEndorseNo.Text                = e.Item.Cells[2].Text.ToString().Trim();
                        //txtEndorsePrepDate.Text          = e.Item.Cells[3].Text.ToString().Trim();
                        //txtEndorseEffDt.Text             = e.Item.Cells[4].Text.ToString().Trim();
                        //txtEndorsePrem.Text              = e.Item.Cells[5].Text.ToString().Trim();
                        //ddlEndorsementType.SelectedValue = e.Item.Cells[6].Text.ToString().Trim();
                        //TxtComments.Text                 = e.Item.Cells[7].Text.ToString().Trim();
                        //txtEndorsementDetailID.Text      = e.Item.Cells[8].Text.ToString();

                        toEditID = e.Item.ItemIndex;
                        break;

                    case "Delete":
                        toEditID = int.Parse(e.Item.Cells[8].Text.ToString());
                        DeleteEndorse(e.Item.ItemIndex, toEditID);
                        toEditID = 0;
                        break;
                }
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }
        }

        private void DeleteEndorse(int index, int toEditID)
        {
            try
            {
                DBRequest Executor = new DBRequest();

                EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["EndorsementQuote"];

                taskControl.EndorsementCollection.Rows.RemoveAt(index);

                //declare data table
                DtEndorsement = taskControl.EndorsementCollection;
                //refresh datagrid
                //FillEndorsementCollectionDataGrid();
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }
        }

        //private void FillEndorsementCollectionDataGrid()
        //{
        //    EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["EndorsementQuote"];

        //    DtEndorsementGrid.DataSource = null;
        //    DtEndorsement = null;

        //    DtEndorsement = taskControl.EndorsementCollection;

        //    Session.Remove("DtEndorsement");
        //    Session.Add("DtEndorsement", DtEndorsement);

        //    if (DtEndorsement != null)
        //    {
        //        if (DtEndorsement.Rows.Count != 0)
        //        {
        //            DtEndorsementGrid.DataSource = DtEndorsement;
        //            DtEndorsementGrid.DataBind();
        //        }
        //        else
        //        {
        //            DtEndorsementGrid.DataSource = null;
        //            DtEndorsementGrid.DataBind();
        //        }
        //    }
        //    else
        //    {
        //        DtEndorsementGrid.DataSource = null;
        //        DtEndorsementGrid.DataBind();
        //    }
        //}
        #endregion

       
}
}
