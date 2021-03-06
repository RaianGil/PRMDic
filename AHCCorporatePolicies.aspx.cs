using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using EPolicy.TaskControl;
using Baldrich.DBRequest;
using EPolicy.XmlCooker;
using System.Xml;
using Microsoft.Reporting.WebForms;
using System.IO;
using EPolicy2.Reports;
using EPolicy.LookupTables;
using EPolicy;
using System.Collections.Generic;
using System.Globalization;
using DataDynamics.ActiveReports;
using Spire.Doc;
using Spire.Doc.Documents;

namespace EPolicy
{

    public partial class CorporatePolicyQuote : System.Web.UI.Page
    {
        private DataTable DtTaskPolicy;
        private DataTable DtEndorsement;
        private static bool convert = false;
        private static int oldTaskControlID = 0;
        private int userID = 0;
        private bool prmdicAdmin = false;
        private static int taskControlID = 0;
        private static double previousPremium = 0.00;
        private static double mFactor = 0.0;
        private static double NewProRataTotPrem = 0.0;
        private static double NewShotRateTotPrem = 0.0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.litPopUp.Visible = false;

                Control Banner = new Control();
                Banner = LoadControl(@"TopBanner.ascx");
                this.Placeholder1.Controls.Add(Banner);

                //Setup Left-side Banner			
                //Control LeftMenu = new Control();
                //LeftMenu = LoadControl(@"LeftMenu.ascx");
                //phTopBanner1.Controls.Add(LeftMenu);

                if (Session["AutoPostBack"] == null)
                {
                    if (!IsPostBack)
                    {
                        if (Session["TaskControl"] != null)
                        {

                            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];

                            //ddlCiudad.Attributes.Add("onchange", "getExpDt()");
                            TxtTerm.Attributes.Add("onblur", "getExpDt()");
                            TxtTerm.Attributes.Add("onchange", "getExpDt()");
                            //txtEffDt.Attributes.Add("onblur", "getExpDt();SetFieldDate()");
                            //txtEffDt.Attributes.Add("onchange", "getExpDt();SetFieldDate()");
                            txtEffDt.Attributes.Add("onblur", "getExpDt()");
                            //txtEffDt.Attributes.Add("onchange", "getExpDt()");
                            //TxtZip.Attributes.Add("onblur", "SetCiudad()");
                            //ddlCiudad.Attributes.Add("onchange", "SetZipCode()");

                            LookupTables.MasterPolicy master = new LookupTables.MasterPolicy();
                            DataTable dtCorporation = master.GetMasterPolicyByIsGroup(false);
                            DataTable dtPRMedicalLimit = LookupTables.LookupTables.GetTable("PRMedicalLimit");
                            
                            DataTable dtPRPrimaryLimit = LookupTables.LookupTables.GetTable("PRPrimaryLimit");
                            DataTable dtCiudad = LookupTables.LookupTables.GetTable("Ciudad");
                            DataTable dtLocation = LookupTables.LookupTables.GetTable("Location");
                            DataTable dtAgency = LookupTables.LookupTables.GetTable("Agency");
                            DataTable dtCity = LookupTables.LookupTables.GetTable("Sucursal");
                            DataTable dtAgent = LookupTables.LookupTables.GetTable("Agent");
                            DataTable dtAgent2 = LookupTables.LookupTables.GetTable("CorporateAgentWithSecondaryCommissions");
                            DataTable dtInsuranceCompany = LookupTables.LookupTables.GetTable("InsuranceCompany");
                            DataTable dtFinancial = LookupTables.LookupTables.GetTable("Financial");
                            DataTable dtPRMEDICRATE2 = EPolicy.LookupTables.LookupTables.GetTable("PRMEDICSpecialty");
                            DataTable dtGroup = master.GetMasterPolicyByIsGroup(true);
                            DataTable dtEndorsementsType = LookupTables.LookupTables.GetTable("EndorsementsType");

                            //Corporation
                            ddlCorparation.DataSource = dtCorporation;
                            ddlCorparation.DataTextField = "MasterPolicyDesc";
                            ddlCorparation.DataValueField = "MasterPolicyID";
                            ddlCorparation.DataBind();
                            ddlCorparation.SelectedIndex = -1;
                            ddlCorparation.Items.Insert(0, "");

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

                            //Branch
                            ddlCity.DataSource = dtCity;
                            ddlCity.DataTextField = "SucursalCity";
                            ddlCity.DataValueField = "SucursalID";
                            ddlCity.DataBind();
                            ddlCity.SelectedIndex = -1;
                            ddlCity.Items.Insert(0, "");

                            //Agent
                            ddlAgent.DataSource = dtAgent;
                            ddlAgent.DataTextField = "AgentDesc";
                            ddlAgent.DataValueField = "AgentID";
                            ddlAgent.DataBind();
                            ddlAgent.SelectedIndex = -1;
                            ddlAgent.Items.Insert(0, "");

                            ddlAgent0.DataSource = dtAgent;
                            ddlAgent0.DataTextField = "AgentDesc";
                            ddlAgent0.DataValueField = "AgentID";
                            ddlAgent0.DataBind();
                            ddlAgent0.SelectedIndex = -1;
                            ddlAgent0.Items.Insert(0, "");

                            ddlAgent2.DataSource = dtAgent2;
                            ddlAgent2.DataTextField = "AgentDesc";
                            ddlAgent2.DataValueField = "AgentID";
                            ddlAgent2.DataBind();
                            ddlAgent2.SelectedIndex = -1;
                            ddlAgent2.Items.Insert(0, "");

                            //InsuranceCompany
                            ddlInsuranceCompany.DataSource = dtInsuranceCompany;
                            ddlInsuranceCompany.DataTextField = "InsuranceCompanyDesc";
                            ddlInsuranceCompany.DataValueField = "InsuranceCompanyID";
                            ddlInsuranceCompany.DataBind();
                            ddlInsuranceCompany.SelectedIndex = -1;
                            ddlInsuranceCompany.Items.Insert(0, "");

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

                            //Endorsement Type
                            ddlEndoType.DataSource = dtEndorsementsType;
                            ddlEndoType.DataTextField = "EndorsementType";
                            ddlEndoType.DataValueField = "EndorsementTypeID";
                            ddlEndoType.DataBind();
                            ddlEndoType.SelectedIndex = -1;
                            //ddlEndoType.Items.Insert(0, "");

                            //Main Specialty
                            ddlMainSpecialty.Items.Clear();
                            ddlMainSpecialty.DataSource = dtPRMEDICRATE2;
                            ddlMainSpecialty.DataTextField = "PRMEDICSpecialtyDesc";
                            ddlMainSpecialty.DataValueField = "PRMEDICSpecialtyID";
                            ddlMainSpecialty.DataBind();
                            ddlMainSpecialty.SelectedIndex = -1;
                            ddlMainSpecialty.Items.Insert(0, "");

                            //Other SpecialtyA
                            ddlOtherSpecialtyA.Items.Clear();
                            ddlOtherSpecialtyA.DataSource = dtPRMEDICRATE2;
                            ddlOtherSpecialtyA.DataTextField = "PRMEDICSpecialtyDesc";
                            ddlOtherSpecialtyA.DataValueField = "PRMEDICSpecialtyID";
                            ddlOtherSpecialtyA.DataBind();
                            ddlOtherSpecialtyA.SelectedIndex = -1;
                            ddlOtherSpecialtyA.Items.Insert(0, "");

                            //Other SpecialtyB
                            ddlOtherSpecialtyB.Items.Clear();
                            ddlOtherSpecialtyB.DataSource = dtPRMEDICRATE2;
                            ddlOtherSpecialtyB.DataTextField = "PRMEDICSpecialtyDesc";
                            ddlOtherSpecialtyB.DataValueField = "PRMEDICSpecialtyID";
                            ddlOtherSpecialtyB.DataBind();
                            ddlOtherSpecialtyB.SelectedIndex = -1;
                            ddlOtherSpecialtyB.Items.Insert(0, "");

                            //PRPrimaryLimit
                            ddlPrimaryLimits1.DataSource = dtPRPrimaryLimit;
                            ddlPrimaryLimits1.DataTextField = "PRMedicalLimitDesc";
                            ddlPrimaryLimits1.DataValueField = "PRMedicalLimitID";
                            ddlPrimaryLimits1.DataBind();
                            ddlPrimaryLimits1.SelectedIndex = -1;
                            ddlPrimaryLimits1.Items.Insert(0, "");

                            //PRMedicalLimit
                            ddlLimits.DataSource = dtPRMedicalLimit;
                            ddlLimits.DataTextField = "PRMedicalLimitDesc";
                            ddlLimits.DataValueField = "PRMedicalLimitID";
                            ddlLimits.DataBind();
                            ddlLimits.SelectedIndex = -1;
                            ddlLimits.Items.Insert(0, "");
                            ddlLimits.Items.Remove(ddlLimits.Items.FindByValue("6")); //300,000/1,000,000 Ya no se ofrece.

                          
                           
                            //Group(Poliza)
                            ddlGroup.DataSource = dtGroup;
                            ddlGroup.DataTextField = "MasterPolicyDesc";
                            ddlGroup.DataValueField = "MasterPolicyID";
                            ddlGroup.DataBind();
                            ddlGroup.SelectedIndex = -1;
                            ddlGroup.Items.Insert(0, "");

                            //Group(Quote)
                            ddlGroup2.DataSource = dtGroup;
                            ddlGroup2.DataTextField = "MasterPolicyDesc";
                            ddlGroup2.DataValueField = "MasterPolicyID";
                            ddlGroup2.DataBind();
                            ddlGroup2.SelectedIndex = -1;
                            ddlGroup2.Items.Insert(0, "");

                            //PRMedicalLimit  
                            if (taskControl.PolicyType.Trim() == "CE" || taskControl.PolicyType.Trim() == "AEC")
                                ddlPrMedicalLimits.DataSource = dtPRMedicalLimit;
                            else
                                ddlPrMedicalLimits.DataSource = dtPRPrimaryLimit;
                            

                            ddlPrMedicalLimits.DataTextField = "PRMedicalLimitDesc";
                            ddlPrMedicalLimits.DataValueField = "PRMedicalLimitID";
                            ddlPrMedicalLimits.DataBind();
                            ddlPrMedicalLimits.SelectedIndex = -1;
                            //ddlPrMedicalLimits.Items.Insert(0, "");

                            //PRPriPolLimits1
                            ddlPriPolLimits1.DataSource = dtPRMedicalLimit;
                            ddlPriPolLimits1.DataTextField = "PRMedicalLimitDesc";
                            ddlPriPolLimits1.DataValueField = "PRMedicalLimitID";
                            ddlPriPolLimits1.DataBind();
                            ddlPriPolLimits1.SelectedIndex = -1;
                            ddlPriPolLimits1.Items.Insert(0, "");

                            //Solicitud de Estefan?a Gonzalez para un l?mite que no exist?a 12/21/2015
                            if (taskControl.PolicyType.ToString().Trim() == "AEC" && taskControl.PolicyNo.ToString().Trim() == "40000")
                            {
                                ddlPriPolLimits1.DataSource = dtPRMedicalLimit;
                                ddlPriPolLimits1.DataTextField = "PRMedicalLimitDesc";
                                ddlPriPolLimits1.DataValueField = "PRMedicalLimitID";
                                ddlPriPolLimits1.DataBind();
                                ddlPriPolLimits1.SelectedIndex = -1;
                                ddlPriPolLimits1.Items.Insert(0, "");
                                
                            }

                            if (taskControl.PolicyType.ToString().Trim() == "CE" && taskControl.PolicyNo.ToString().Trim() == "10145")
                            {
                                ddlPriPolLimits1.DataSource = dtPRMedicalLimit;
                                ddlPriPolLimits1.DataTextField = "PRMedicalLimitDesc";
                                ddlPriPolLimits1.DataValueField = "PRMedicalLimitID";
                                ddlPriPolLimits1.DataBind();
                                ddlPriPolLimits1.SelectedIndex = -1;
                                ddlPriPolLimits1.Items.Insert(0, "");

                            }
                            else
                            {
                                ddlPriPolLimits1.Items.Remove(ddlPriPolLimits1.Items.FindByText("900,000/2,700,000"));
                            }

                            if(taskControl.PolicyType.ToString().Trim() == "CE"  && taskControl.PolicyNo.ToString().Trim() == "10118")
                            {
                                ddlPriPolLimits1.DataSource = dtPRMedicalLimit;
                                ddlPriPolLimits1.DataTextField = "PRMedicalLimitDesc";
                                ddlPriPolLimits1.DataValueField = "PRMedicalLimitID";
                                ddlPriPolLimits1.DataBind();
                                ddlPriPolLimits1.SelectedIndex = -1;
                                ddlPriPolLimits1.Items.Insert(0, "");
                            }
                            else
                            {
                                ddlPriPolLimits1.Items.Remove(ddlPriPolLimits1.Items.FindByText("150,000/2,700,000"));
                            }


                            if (taskControl.PolicyNo != "10094")
                                ddlPriPolLimits1.Items.Remove(ddlPriPolLimits1.Items.FindByText("400,000/1,200,000"));
                            
                            
                             

                            switch (taskControl.Mode)
                            {
                                case 1: //ADD
                                    FillTextControl();
                                    if (!taskControl.IsPolicy)
                                        SetDefaulValue();
                                    FillCorporatePolicyGrid();
                                    EnableControls();
                                    EndorsementControl(false);
                                    break;

                                case 2: //UPDATE
                                    FillTextControl();
                                    EnableControls();

                                    if (taskControl.isEndorsement)
                                    {
                                        this.TxtFirstName.Enabled = true;
                                        pnlEndorsement.Visible = true;
                                        pnlEndorsement.Enabled = true;
                                        txtDatePrepared.Text = DateTime.Now.ToShortDateString();
                                        txtDatePrepared.Enabled = false;

                                        txtEndorsementNo.Text = (taskControl.Endoso + 1).ToString();

                                        lblEndorsement.Visible = false;
                                        
                                        dtEndorsement.Visible = false;

                                        EndorsementControl(true);
                                    }
                                    else
                                        EndorsementControl(false);
                                    break;

                                default:
                                    FillTextControl();
                                    FillGrid();
                                    FillCorporatePolicyGrid();
                                    DisableControls();
                                    //btnConvert.Visible = false;
                                    //btnConvertPrimary.Visible = false;
                                    EndorsementControl(false);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (Session["TaskControl"] != null)
                        {
                            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
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
                    FillGrid();
                    Session.Remove("AutoPostBack");
                }
                
                DisableControlsTail();
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
        private void SetDefaulValue()
        {
            txtDiscountP.Text = "25%";
            txtDiscount.Text = "15%";
            //Primary
            txtRateTN1.Text = "25%";
            txtRateTN2.Text = "50%";
            txtRateTN3.Text = "75%";
            txtRateTN4.Text = "20%";
            txtRateTN5.Text = "10%";
            txtRateTN6.Text = "100%";

            //Excess
            txtERateTN1.Text = "15%";
            txtERateTN2.Text = "50%";
            txtERateTN3.Text = "50%";
            txtERateTN4.Text = "10%";
            txtERateTN5.Text = "2.5%";
            txtERateTN6.Text = "100%";
        }
        private void EnableControls()
        {
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];

            Login.Login cp = HttpContext.Current.User as Login.Login;
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

            
            btnCalendar.Visible = true;
            //btnFoward.Enabled = true;
           // btnBack.Enabled = true;
           // btnBack.Visible = false;
            //btnFoward.Visible = false;
            btnEdit.Visible = false;
            BtnExit.Visible = false;
            btnPrint.Visible = false;
            btnHistory.Visible = false;
            btnPayments.Visible = false;
            btnComissions.Visible = false;
            btnReinstatement.Visible = false;
            btnPrintCertificate.Visible = false;
            btnAddNew.Visible = false;
            BtnSave.Visible = true;
            btnCalcCharge.Visible = true;
            cmdCancel.Visible = true;
            Label68.Visible = true;
            TxtAddQuantity.Visible = true;
            Button2.Visible = true;
            Button3.Visible = true;
            Button4.Visible = true;
            btnCancellation.Visible = false;
            btnFinancialCanc.Visible = false;
            btnDelete.Visible = true;
            btnTailQuote.Visible = false;
            btnPolicyCert.Visible = false;
            btnEnablePrint.Visible = false;
            btnEndor.Visible = false;

            if (userID == 156) //Temp Override for Kayla
            {
                TxtCustomerNo.Enabled = true;
                txtExpDt.Enabled = true;
                txtExpDt.ForeColor = System.Drawing.ColorTranslator.FromHtml("Black");
            }

            //if (userID == 114) //servimed Print
            //{
            //    BtnSave.Enabled = false;
            //}

            if (taskControl.IsPolicy)
            {
                btnConvert.Visible = false;
                btnConvertPrimary.Visible = false;
                btnRenew.Visible = false;
                txtCorporation.Visible = false;
                txtQuoteRetroDate.Visible = false;
                Label70.Visible = false;
                ddlGroup2.Visible = false;
                ddlAgent0.Visible = false;
                Label72.Visible = false;
                Label74.Visible = false;
                txtCustomerName2.Visible = true;
                pnlPolicy.Visible = true;
                pnlHistory.Visible = true;
                ddlSelectedAgent.Visible = false;
                Label8.Visible = false;
                Label18.Visible = true;
                //btnPayments.Visible = true;
                //btnHistory.Visible = true;

                VerifyAssignPolicyFields();

                if (taskControl.PolicyType.Trim().Substring(0, 2) == "CP")
                {
                    pnlPrimary.Visible = true;
                    pnlExcess.Visible = false;
                    Label40.Visible = true;
                    Label16.Visible = false;
                    Label17.Visible = true;
                    Label15.Visible = false;
                    Label7.Visible = true;
                    Label39.Visible = false;

                    txtDiscountP.Visible = true;
                    txtDiscount.Visible = false;
                    txtTotalPrimaryPremium.Visible = true;
                    txtTotalExcessPremium.Visible = false;
                    Label13.Visible = true;
                    Label9.Visible = false;
                    txtTotalPrimaryCorporate.Visible = true;
                    txtTotalExcessCorporate.Visible = false;
                }
                else
                {
                    pnlPrimary.Visible = false;
                    pnlExcess.Visible = true;
                    Label40.Visible = false;
                    Label16.Visible = true;
                    Label17.Visible = false;
                    Label15.Visible = true;
                    Label7.Visible = false;
                    Label39.Visible = true;

                    txtDiscountP.Visible = false;
                    txtDiscount.Visible = true;
                    txtTotalPrimaryPremium.Visible = false;
                    txtTotalExcessPremium.Visible = true;
                    Label13.Visible = false;
                    Label9.Visible = true;
                    txtTotalPrimaryCorporate.Visible = false;
                    txtTotalExcessCorporate.Visible = true;
                    btnPrintCertificate.Visible = false;
                }
            }
            else
            {
                btnEnablePrint.Visible = false;
                btnConvert.Visible = false;
                btnConvertPrimary.Visible = false;
                btnRenew.Visible = false;
                btnPayments.Visible = false;
                btnComissions.Visible = false;
                btnHistory.Visible = false;
                ddlAgent0.Enabled = true;
                txtCorporation.Visible = true;
                txtCustomerName2.Visible = true;
                pnlPolicy.Visible = false;
                pnlHistory.Visible = false;
                pnlPrimary.Visible = true;
                pnlExcess.Visible = true;
                Label40.Visible = true;
                Label16.Visible = true;
                Label17.Visible = true;
                Label15.Visible = true;
                Label7.Visible = true;
                Label39.Visible = true;
                Label8.Visible = true;
                Label18.Visible = true;
                txtDiscountP.Visible = true;
                txtDiscount.Visible = true;
                txtTotalPrimaryPremium.Visible = true;
                txtTotalExcessPremium.Visible = true;
                Label13.Visible = true;
                Label9.Visible = true;
                txtTotalPrimaryCorporate.Visible = true;
                txtTotalExcessCorporate.Visible = true;
            }

            if (cp.IsInRole("ADMINISTRATOR"))
                TxtCustomerNo.Enabled = true;
            else
                TxtCustomerNo.Enabled = false;

            TxtFirstName.Enabled = true;
            //TxtInitial.Enabled = true;
            //txtLastname1.Enabled = true;
            //txtLastname2.Enabled = true;
            TxtAddrs1.Enabled = true;
            TxtAddrs2.Enabled = true;
            TxtCity.Enabled = true;
            TxtState.Enabled = true;
            TxtZip.Enabled = true;
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
            TxtTerm.Enabled = true;
            ddlCorparation.Enabled = true;
            ddlSelectedAgent.Enabled = true;
            ddlGroup.Enabled = true;
            TxtRetroactiveDate.Enabled = true;
            txtEffDt.Enabled = true;
            txtExpDt.Enabled = true;
            txtEntryDate.Enabled = true;
            TxtCharge.Enabled = true;
            TxtTotalPremium.Enabled = true;
            TxtPremium.Enabled = true;
            TxtComments.Enabled = true;
            txtPriCarierName1.Enabled = true;
            txtPriClaims1.Enabled = true;
            txtPriPolEffecDate1.Enabled = true;
            //txtPriPolLimits1.Enabled = true;
            ddlPriPolLimits1.Enabled = true;

            rblClaim.Enabled = true;
            txtClaimNumber.Enabled = true;
            chkUpdateForm.Enabled = true;
            txtGapBegDate.Enabled = true;
            txtGapBegDate2.Enabled = true;
            txtGapBegDate3.Enabled = true;
            txtGapEndDate.Enabled = true;
            txtGapEndDate2.Enabled = true;
            txtGapEndDate3.Enabled = true;
            txtNumberOfEmployees.Enabled = true;
            ddlOriginatedAt.Enabled = true;
            ddlInsuranceCompany.Enabled = true;
            ddlAgency.Enabled = true;
            ddlCity.Enabled = true;
            ddlAgent.Enabled = true;
            ddlAgent2.Enabled = true;

            ddlFinancial.Enabled = true;
            ddlMainSpecialty.Enabled = true;
            ddlOtherSpecialtyA.Enabled = true;
            ddlOtherSpecialtyB.Enabled = true;
            ddlPolicyClass.Enabled = false;
            chkPaymentGA.Enabled = true;
            //ddlCiudad.Enabled = true;
            ChkAutoAssignPolicy.Enabled = true;

            ddlPrMedicalLimits.Enabled = true;

            txtCorporation.Enabled = true;
            txtQuoteRetroDate.Enabled = true;
            ddlGroup2.Enabled = true;
            txtCustomerName2.Enabled = true;
            ddlPrimaryLimits1.Enabled = true;
            ddlLimits.Enabled = true;
            ddlPolicyClass.Enabled = true;
            txtIsoCode.Enabled = true;
            txtPRate4.Enabled = true;
            txtRate4.Enabled = true;

            txtCorporation.Enabled = true;
            txtDiscountP.Enabled = true;
            txtDiscount.Enabled = true;
            txtTotalPrimaryPremium.Enabled = false;
            txtTotalExcessPremium.Enabled = false;

            txtRateTN1.Enabled = true;
            txtRateTN2.Enabled = true;
            txtRateTN3.Enabled = true;
            txtRateTN4.Enabled = true;
            txtRateTN5.Enabled = true;
            txtRateTN6.Enabled = true;
            txtPrimaryTN1.Enabled = false;
            txtPrimaryTN2.Enabled = false;
            txtPrimaryTN3.Enabled = false;
            txtPrimaryTN4.Enabled = false;
            txtPrimaryTN5.Enabled = false;
            txtPremiumTN1.Enabled = false;
            txtPremiumTN2.Enabled = false;
            txtPremiumTN3.Enabled = false;
            txtPremiumTN4.Enabled = false;
            txtPremiumTN5.Enabled = false;
            txtQuantityTN1.Enabled = true;
            txtQuantityTN2.Enabled = true;
            txtQuantityTN3.Enabled = true;
            txtQuantityTN4.Enabled = true;
            txtQuantityTN5.Enabled = true;
            txtQuantityTN6.Enabled = true;
            txtTotPremTN1.Enabled = false;
            txtTotPremTN2.Enabled = false;
            txtTotPremTN3.Enabled = false;
            txtTotPremTN4.Enabled = false;
            txtTotPremTN5.Enabled = false;
            txtTotPremTN6.Enabled = false;

            txtERateTN1.Enabled = true;
            txtERateTN2.Enabled = true;
            txtERateTN3.Enabled = true;
            txtERateTN4.Enabled = true;
            txtERateTN5.Enabled = true;
            txtERateTN6.Enabled = true;
            txtExcessTN1.Enabled = false;
            txtExcessTN2.Enabled = false;
            txtExcessTN3.Enabled = false;
            txtExcessTN4.Enabled = false;
            txtExcessTN5.Enabled = false;
            txtEPremiumTN1.Enabled = false;
            txtEPremiumTN2.Enabled = false;
            txtEPremiumTN3.Enabled = false;
            txtEPremiumTN4.Enabled = false;
            txtEPremiumTN5.Enabled = false;
            txtEQuantityTN1.Enabled = true;
            txtEQuantityTN2.Enabled = true;
            txtEQuantityTN3.Enabled = true;
            txtEQuantityTN4.Enabled = true;
            txtEQuantityTN5.Enabled = true;
            txtEQuantityTN6.Enabled = true;
            txtETotPremTN1.Enabled = false;
            txtETotPremTN2.Enabled = false;
            txtETotPremTN3.Enabled = false;
            txtETotPremTN4.Enabled = false;
            txtETotPremTN5.Enabled = false;
            txtETotPremTN6.Enabled = false;

            txtTotalPrimaryCorporate.Enabled = false;
            txtTotalExcessCorporate.Enabled = false;

            this.DtGridCorpaoratePol.Columns[0].Visible = true;
            this.DtGridCorpaoratePol.Columns[9].Visible = true;

            //if (cp.IsInRole("MODIFYCORPORATE"))
            //{
            //    this.DtGridCorpaoratePol.Columns[0].Visible = true;
            //    this.DtGridCorpaoratePol.Columns[9].Visible = true;
            //}

            if (convert)
            {
                DataTable dt = taskControl.CorporatePolicyDetailCollection;

                this.DtGridCorpaoratePol.CurrentPageIndex = 0;
                this.DtGridCorpaoratePol.Visible = true;
                this.DtGridCorpaoratePol.DataSource = dt;
                this.DtGridCorpaoratePol.DataBind();

                DtGridCorpaoratePol.Visible = true;
                lblQuantity.Text = DtGridCorpaoratePol.Items.Count.ToString();
            }
          
        }
        private void DisableControls()
        {
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];

            try
            {
                Login.Login cp = HttpContext.Current.User as Login.Login;
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                btnCalendar.Visible = false;
               // btnFoward.Visible = false;
                //btnBack.Visible = false;
                btnEdit.Visible = true;
                BtnExit.Visible = true;
                btnPrint.Visible = true;
                btnHistory.Visible = true;
                btnPayments.Visible = true;
                btnComissions.Visible = true;
                btnReinstatement.Visible = true;
                btnTailQuote.Visible = true;
                btnPrintCertificate.Visible = false;
                btnAddNew.Visible = true;
                BtnSave.Visible = false;
                btnCalcCharge.Visible = false;
                cmdCancel.Visible = false;
                Label68.Visible = false;
                TxtAddQuantity.Visible = false;
                Button2.Visible = false;
                Button3.Visible = false;
                Button4.Visible = false;
                btnCancellation.Visible = true;
                btnFinancialCanc.Visible = true;
                btnDelete.Visible = false;
                txtExpDt.Enabled = false;
                btnPolicyCert.Visible = false;
                btnEndor.Visible = true;
                btnEnablePrint.Visible = true;

                //if (taskControl.Anniversary == "01")
                //    btnEnablePrint.Visible = true;
                //else
                //    btnEnablePrint.Visible = false;

                //if (userID == 1 || userID == 2 || userID == 13 || userID == 156 || userID == 240)
                //{
                //   //btnPolicyCert.Visible = true;
                //}

                if (taskControl.IsPolicy)
                {
                    
                    btnConvert.Visible = false;
                    btnConvertPrimary.Visible = false;
                    btnRenew.Visible = true;
                    txtCorporation.Visible = false;
                    txtQuoteRetroDate.Visible = false;
                    Label70.Visible = false;
                    ddlAgent0.Visible = false;
                    ddlGroup2.Visible = false;
                    Label72.Visible = false;
                    Label74.Visible = false;
                    txtCustomerName2.Visible = true;
                    pnlPolicy.Visible = true;
                    pnlHistory.Visible = true;
                    ddlSelectedAgent.Visible = false;
                    Label8.Visible = false;
                    Label18.Visible = true;

                    if (taskControl.PolicyType.Trim().Substring(0, 2) == "CP")
                    {
                        
                        btnPrintCertificate.Visible = true;
                        pnlPrimary.Visible = true;
                        pnlExcess.Visible = false;
                        Label40.Visible = true;
                        Label16.Visible = false;
                        Label17.Visible = true;
                        Label15.Visible = false;
                        Label7.Visible = true;
                        Label39.Visible = false;
                        txtDiscountP.Visible = true;
                        txtDiscount.Visible = false;
                        txtTotalPrimaryPremium.Visible = true;
                        txtTotalExcessPremium.Visible = false;
                        Label13.Visible = true;
                        Label9.Visible = false;
                        txtTotalPrimaryCorporate.Visible = true;
                        txtTotalExcessCorporate.Visible = false;
                    }
                    else
                    {
                        btnPrintCertificate.Visible = false;
                        pnlPrimary.Visible = false;
                        pnlExcess.Visible = true;
                        Label40.Visible = false;
                        Label16.Visible = true;
                        Label17.Visible = false;
                        Label15.Visible = true;
                        Label7.Visible = false;
                        Label39.Visible = true;
                        txtDiscountP.Visible = false;
                        txtDiscount.Visible = true;
                        txtTotalPrimaryPremium.Visible = false;
                        txtTotalExcessPremium.Visible = true;
                        Label13.Visible = false;
                        Label9.Visible = true;
                        txtTotalPrimaryCorporate.Visible = false;
                        txtTotalExcessCorporate.Visible = true;
                        btnPrintCertificate.Visible = false;
                    }
                }
                else
                {
                    
                    btnEnablePrint.Visible = false;
                    //btnConvert.Visible = true;
                    btnConvertPrimary.Visible = true;
                    btnHistory.Visible = false;
                    btnPayments.Visible = false;
                    btnComissions.Visible = false;
                    btnCancellation.Visible = false;
                    //btnPrint.Visible = false;
                    btnTailQuote.Visible = false;
                    btnFinancialCanc.Visible = false;
                    btnPolicyCert.Visible = false;
                    btnRenew.Visible = false;
                    txtCorporation.Visible = true;
                    txtCustomerName2.Visible = true;
                    pnlPolicy.Visible = false;
                    pnlHistory.Visible = false;
                    pnlPrimary.Visible = true;
                    pnlExcess.Visible = true;
                    Label40.Visible = true;
                    Label16.Visible = true;
                    Label17.Visible = true;
                    Label15.Visible = true;
                    Label8.Visible = true;
                    Label18.Visible = true;
                    Label7.Visible = true;
                    Label39.Visible = true;
                    txtDiscountP.Visible = true;
                    txtDiscount.Visible = true;
                    txtTotalPrimaryPremium.Visible = true;
                    txtTotalExcessPremium.Visible = true;
                    Label13.Visible = true;
                    Label9.Visible = true;
                    txtTotalPrimaryCorporate.Visible = true;
                    txtTotalExcessCorporate.Visible = true;
                }

                TxtProspectNo.Enabled = false;
                TxtCustomerNo.Enabled = false;
                TxtFirstName.Enabled = false;
                //TxtInitial.Enabled = false;
                //txtLastname1.Enabled = false;
                //txtLastname2.Enabled = false;
                TxtAddrs1.Enabled = false;
                TxtAddrs2.Enabled = false;
                TxtCity.Enabled = false;
                TxtState.Enabled = false;
                TxtZip.Enabled = false;
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
                TxtTerm.Enabled = false;
                ddlCorparation.Enabled = false;
                ddlGroup.Enabled = false;
                ddlSelectedAgent.Enabled = false;
                TxtRetroactiveDate.Enabled = false;
                txtEffDt.Enabled = false;
                txtExpDt.Enabled = false;
                txtEntryDate.Enabled = false;
                TxtCharge.Enabled = false;
                TxtTotalPremium.Enabled = false;
                TxtPremium.Enabled = false;
                TxtComments.Enabled = false;
                txtPriCarierName1.Enabled = false;
                txtPriClaims1.Enabled = false;
                txtPriPolEffecDate1.Enabled = false;
                //txtPriPolLimits1.Enabled = false;
                ddlPriPolLimits1.Enabled = false;

                rblClaim.Enabled = false;
                txtClaimNumber.Enabled = false;
                chkUpdateForm.Enabled = false;
                //----Gaps
                txtGapBegDate.Enabled = false;
                txtGapBegDate2.Enabled = false;
                txtGapBegDate3.Enabled = false;
                txtGapEndDate.Enabled = false;
                txtGapEndDate2.Enabled = false;
                txtGapEndDate3.Enabled = false;
                txtNumberOfEmployees.Enabled = false;
                //----
                ddlOriginatedAt.Enabled = false;
                ddlInsuranceCompany.Enabled = false;
                ddlAgency.Enabled = false;
                ddlCity.Enabled = false;
                ddlAgent.Enabled = false;
                ddlAgent0.Enabled = false;
                ddlAgent2.Enabled = false;
                ddlPolicyClass.Enabled = false;
                ddlFinancial.Enabled = false;
                ddlMainSpecialty.Enabled = false;
                ddlOtherSpecialtyA.Enabled = false;
                ddlOtherSpecialtyB.Enabled = false;
                chkPaymentGA.Enabled = false;
                //ddlCiudad.Enabled = false;
                ChkAutoAssignPolicy.Enabled = false;
                ddlPrMedicalLimits.Enabled = false;

                txtCorporation.Enabled = false;
                txtQuoteRetroDate.Enabled = false;
                ddlGroup2.Enabled = false;
                txtCustomerName2.Enabled = false;
                ddlPrimaryLimits1.Enabled = false;
                ddlLimits.Enabled = false;
                ddlPolicyClass.Enabled = false;
                txtIsoCode.Enabled = false;
                txtPRate4.Enabled = false;
                txtRate4.Enabled = false;

                txtCorporation.Enabled = false;
                txtDiscountP.Enabled = false;
                txtDiscount.Enabled = false;
                txtTotalPrimaryPremium.Enabled = false;
                txtTotalExcessPremium.Enabled = false;

                txtRateTN1.Enabled = false;
                txtRateTN2.Enabled = false;
                txtRateTN3.Enabled = false;
                txtRateTN4.Enabled = false;
                txtRateTN5.Enabled = false;
                txtRateTN6.Enabled = false;
                txtPrimaryTN1.Enabled = false;
                txtPrimaryTN2.Enabled = false;
                txtPrimaryTN3.Enabled = false;
                txtPrimaryTN4.Enabled = false;
                txtPrimaryTN5.Enabled = false;
                txtPremiumTN1.Enabled = false;
                txtPremiumTN2.Enabled = false;
                txtPremiumTN3.Enabled = false;
                txtPremiumTN4.Enabled = false;
                txtPremiumTN5.Enabled = false;
                txtQuantityTN1.Enabled = false;
                txtQuantityTN2.Enabled = false;
                txtQuantityTN3.Enabled = false;
                txtQuantityTN4.Enabled = false;
                txtQuantityTN5.Enabled = false;
                txtQuantityTN6.Enabled = false;
                txtTotPremTN1.Enabled = false;
                txtTotPremTN2.Enabled = false;
                txtTotPremTN3.Enabled = false;
                txtTotPremTN4.Enabled = false;
                txtTotPremTN5.Enabled = false;
                txtTotPremTN6.Enabled = false;

                txtERateTN1.Enabled = false;
                txtERateTN2.Enabled = false;
                txtERateTN3.Enabled = false;
                txtERateTN4.Enabled = false;
                txtERateTN5.Enabled = false;
                txtERateTN6.Enabled = false;
                txtExcessTN1.Enabled = false;
                txtExcessTN2.Enabled = false;
                txtExcessTN3.Enabled = false;
                txtExcessTN4.Enabled = false;
                txtExcessTN5.Enabled = false;
                txtEPremiumTN1.Enabled = false;
                txtEPremiumTN2.Enabled = false;
                txtEPremiumTN3.Enabled = false;
                txtEPremiumTN4.Enabled = false;
                txtEPremiumTN5.Enabled = false;
                txtEQuantityTN1.Enabled = false;
                txtEQuantityTN2.Enabled = false;
                txtEQuantityTN3.Enabled = false;
                txtEQuantityTN4.Enabled = false;
                txtEQuantityTN5.Enabled = false;
                txtEQuantityTN6.Enabled = false;
                txtETotPremTN1.Enabled = false;
                txtETotPremTN2.Enabled = false;
                txtETotPremTN3.Enabled = false;
                txtETotPremTN4.Enabled = false;
                txtETotPremTN5.Enabled = false;
                txtETotPremTN6.Enabled = false;

                txtTotalPrimaryCorporate.Enabled = false;
                txtTotalExcessCorporate.Enabled = false;

                this.DtGridCorpaoratePol.Columns[0].Visible = false;
                this.DtGridCorpaoratePol.Columns[9].Visible = false;

                if (taskControl.IsPolicy)
                {
                    VerifyAccess();
                    if (taskControl.PolicyType.Trim() == "CE" || taskControl.PolicyType.Trim() == "AEC")
                    {
                        btnPrintCertificate.Visible = false;
                    }
                }

                if (!taskControl.isEndorsement)
                {
                    pnlEndorsement.Visible = false;
                    lblEndorsementHistory.Visible = true;
                    dtEndorsement.Visible = true;
                }

                if (taskControl.CancellationDate != String.Empty)
                {
                    Label58.Text = "Canc. Date";
                    btnRenew.Visible = false;
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

        #region VerifyAccess
        private void VerifyAccess()
        {
            TaskControl.CorporatePolicyQuote taskControl = (TaskControl.CorporatePolicyQuote)Session["TaskControl"];

            Login.Login cp = HttpContext.Current.User as Login.Login;

            
            if (cp.IsInRole("BTNHISTORYCORPORATE"))
            {
                this.btnHistory.Visible = false;
            }
            else
            {
                this.btnHistory.Visible = true;
            }

            if (userID == 198) //History Override button for Blanca Hernandez
            {
                this.btnHistory.Visible = true;
            }

          

            if (!taskControl.IsPolicy)
            {
                if (!cp.IsInRole("BTNCONVERTPRIMARYCORPORATE") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    this.btnConvertPrimary.Visible = false;
                }
                else
                {
                    this.btnConvertPrimary.Visible = true;
                }

                if (!cp.IsInRole("BTNCONVERTCORPORATE") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    this.btnConvert.Visible = false;
                }
                else
                {
                    this.btnConvert.Visible = true;
                }
              
            }

            if (!cp.IsInRole("BTNPAYMENTCORPORATE"))
            {
                this.btnPayments.Visible = false;
                this.btnComissions.Visible = false;
            }
            else
            {
                this.btnPayments.Visible = true;
            }

            if (cp.IsInRole("BTNCOMMISSIONSNOVISIBLE"))
            {
                this.btnComissions.Visible = false;
            }

            if (!cp.IsInRole("BTNCANCELLATIONCORPORATE") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnCancellation.Visible = false;
                this.btnFinancialCanc.Visible = false;
            }
            else
            {
                this.btnCancellation.Visible = true;
                this.btnFinancialCanc.Visible = true;
            }

            //Agregar bot?n en la base de datos en la tabla AuthenticatedPermission
            if (!cp.IsInRole("BTNREINSTATEMENTCORPORATE") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnReinstatement.Visible = true;
            }
            else
            {
                this.btnReinstatement.Visible = false;
            }

            if (!cp.IsInRole("BTNREINSTATEMENTCORPORATE") && !cp.IsInRole("MARKETING"))
            {
                this.btnReinstatement.Visible = true;
            }
            else
            {
                this.btnReinstatement.Visible = false;
            }

            if (cp.IsInRole("DISABLEBOXPOWERAGENT") && cp.IsInRole("POWERAGENT"))
            {
                this.TxtComments.Visible = false;
                this.lblComments.Visible = false;
                this.rblClaim.Visible = false;
                this.Label77.Visible = false;               
                DtSearchPayments.Columns[9].Visible = false;
            }

            if (!cp.IsInRole("BTNDELETECORPORATE") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnDelete.Visible = false;
            }
            else
            {
                this.btnDelete.Visible = true;
            }

            if (!cp.IsInRole("BTNADDCORPORATE") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnAddNew.Visible = false;
            }
            else
            {
                this.btnAddNew.Visible = true;
            }

            if (!cp.IsInRole("BTNEDITCORPORATE") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnEdit.Visible = false;
            }
            else
            {
                this.btnEdit.Visible = true;
            }

            if (!cp.IsInRole("BTNPRINTCORPORATE") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnPrint.Visible = false;
            }
            else
            {
                this.btnPrint.Visible = true;
            }

            if (!cp.IsInRole("BTNRENEWCORPORATE") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnRenew.Visible = false;
            }
            else
            {
                this.btnRenew.Visible = true;
            }

            if (cp.IsInRole("BTNRENEWCORPORATE") && cp.IsInRole("MARKETING"))
            {
                this.btnRenew.Visible = false;
            }            
         

            if (!cp.IsInRole("BTNENABLEPRINT") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnEnablePrint.Visible = false;
            }
            else
            {
                this.btnEnablePrint.Visible = taskControl.PrintPolicy;
            }

            if (!cp.IsInRole("BTNPRINTCERTIFICATE") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnPrintCertificate.Visible = false;
            }
            else
            {
                this.btnPrintCertificate.Visible = true;
            }

            if (!cp.IsInRole("DDLAGENT2") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.ddlAgent2.Visible = false;
                this.Label75.Visible = false;
            }
            else
            {
                this.ddlAgent2.Visible = true;
                this.Label75.Visible = true;
            }
            if (userID == 270) //Override para Hadasha Alamo. 
            {
                btnEnablePrint.Visible = true;
            }
     


            if (cp.IsInRole("ADMINISTRATOR"))
            {
                prmdicAdmin = true;
                Label8.Visible = true;
                txtCorporation.Visible = true;
                Label70.Visible = true;
                txtQuoteRetroDate.Visible = true;
                Label72.Visible = true;
                Label72.Visible = true;
                ddlGroup2.Visible = true;
                ddlAgent0.Visible = true;
                Label18.Visible = true;
                txtCustomerName2.Visible = true;
                Label3.Visible = true;
                ddlPrimaryLimits1.Visible = true;
                Label10.Visible = true;
                ddlLimits.Visible = true;
                Label11.Visible = true;
                ddlPolicyClass.Visible = true;
                Label12.Visible = true;
                txtIsoCode.Visible = true;
                Label19.Visible = true;
                txtPRate4.Visible = true;
                Label20.Visible = true;
                txtRate4.Visible = true;
                btnTailQuote.Visible = true;

                Label68.Visible = true;
                TxtAddQuantity.Visible = true;
                //Button2.Visible = true;

                DtGridCorpaoratePol.Visible = true;

                //Button4.Visible = true;

                Label7.Visible = true;

                Label2.Visible = true;
                Label4.Visible = true;
                Label14.Visible = true;
                Label22.Visible = true;
                Label23.Visible = true;
                Label24.Visible = true;
                Label25.Visible = true;
                Label26.Visible = true;
                Label27.Visible = true;

                Label28.Visible = true;
                Label29.Visible = true;
                Label30.Visible = true;
                Label33.Visible = true;
                Label34.Visible = true;
                Label35.Visible = true;
                Label36.Visible = true;
                Label37.Visible = true;
                Label38.Visible = true;

                txtRateTN1.Visible = true;
                txtRateTN2.Visible = true;
                txtRateTN3.Visible = true;
                txtRateTN4.Visible = true;
                txtRateTN5.Visible = true;
                txtRateTN6.Visible = true;
                txtPrimaryTN1.Visible = true;
                txtPrimaryTN2.Visible = true;
                txtPrimaryTN3.Visible = true;
                txtPrimaryTN4.Visible = true;
                txtPrimaryTN5.Visible = true;
                txtPremiumTN1.Visible = true;
                txtPremiumTN2.Visible = true;
                txtPremiumTN3.Visible = true;
                txtPremiumTN4.Visible = true;
                txtPremiumTN5.Visible = true;

                txtERateTN1.Visible = true;
                txtERateTN2.Visible = true;
                txtERateTN3.Visible = true;
                txtERateTN4.Visible = true;
                txtERateTN5.Visible = true;
                txtERateTN6.Visible = true;
                txtExcessTN1.Visible = true;
                txtExcessTN2.Visible = true;
                txtExcessTN3.Visible = true;
                txtExcessTN4.Visible = true;
                txtExcessTN5.Visible = true;
                txtEPremiumTN1.Visible = true;
                txtEPremiumTN2.Visible = true;
                txtEPremiumTN3.Visible = true;
                txtEPremiumTN4.Visible = true;
                txtEPremiumTN5.Visible = true;
            }
            else
            {
                Label8.Visible = false;
                txtCorporation.Visible = false;
                Label70.Visible = false;
                txtQuoteRetroDate.Visible = false;
                Label72.Visible = false;
                Label74.Visible = false;
                ddlGroup2.Visible = false;
                ddlAgent0.Visible = false;
                Label18.Visible = false;
                txtCustomerName2.Visible = false;
                Label3.Visible = false;
                ddlPrimaryLimits1.Visible = false;
                Label10.Visible = false;
                ddlLimits.Visible = false;
                Label11.Visible = false;
                ddlPolicyClass.Visible = false;
                Label12.Visible = false;
                txtIsoCode.Visible = false;
                Label19.Visible = false;
                txtPRate4.Visible = false;
                Label20.Visible = false;
                txtRate4.Visible = false;
                btnTailQuote.Visible = false;

                Label68.Visible = false;
                TxtAddQuantity.Visible = false;
                Button2.Visible = false;

                DtGridCorpaoratePol.Visible = true;

                Button4.Visible = false;

                Label7.Visible = false;

                Label2.Visible = false;
                Label4.Visible = false;
                Label14.Visible = false;
                Label22.Visible = true;
                Label23.Visible = true;
                Label24.Visible = true;
                Label25.Visible = true;
                Label26.Visible = true;
                Label27.Visible = false;

                Label28.Visible = false;
                Label29.Visible = false;
                Label30.Visible = false;
                Label33.Visible = true;
                Label34.Visible = true;
                Label35.Visible = true;
                Label36.Visible = true;
                Label37.Visible = true;
                Label38.Visible = false;

                txtRateTN1.Visible = false;
                txtRateTN2.Visible = false;
                txtRateTN3.Visible = false;
                txtRateTN4.Visible = false;
                txtRateTN5.Visible = false;
                txtRateTN6.Visible = false;
                txtPrimaryTN1.Visible = false;
                txtPrimaryTN2.Visible = false;
                txtPrimaryTN3.Visible = false;
                txtPrimaryTN4.Visible = false;
                txtPrimaryTN5.Visible = false;
                txtPremiumTN1.Visible = false;
                txtPremiumTN2.Visible = false;
                txtPremiumTN3.Visible = false;
                txtPremiumTN4.Visible = false;
                txtPremiumTN5.Visible = false;

                txtERateTN1.Visible = false;
                txtERateTN2.Visible = false;
                txtERateTN3.Visible = false;
                txtERateTN4.Visible = false;
                txtERateTN5.Visible = false;
                txtERateTN6.Visible = false;
                txtExcessTN1.Visible = false;
                txtExcessTN2.Visible = false;
                txtExcessTN3.Visible = false;
                txtExcessTN4.Visible = false;
                txtExcessTN5.Visible = false;
                txtEPremiumTN1.Visible = false;
                txtEPremiumTN2.Visible = false;
                txtEPremiumTN3.Visible = false;
                txtEPremiumTN4.Visible = false;
                txtEPremiumTN5.Visible = false;

            }

            if (!cp.IsInRole("ADMINISTRATOR") && !cp.IsInRole("SUBSCRIPTION"))
            {
                this.TxtFirstName.Enabled = false;
                //this.TxtInitial.Enabled = false;
                //this.txtLastname1.Enabled = false;
                //this.txtLastname2.Enabled = false;
            }

            if (cp.IsInRole("BTNEDITENDORSEMENT"))
            {
                this.btnTailQuote.Visible = false;
                this.btnEndor.Visible = true;
                //dtEndorsement.Columns[9].Visible = true;
                //dtEndorsement.Columns[10].Visible = false;
            }
            else if (!cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnTailQuote.Visible = false;
                this.btnEndor.Visible = false;
                //dtEndorsement.Columns[9].Visible = false;
                //dtEndorsement.Columns[10].Visible = false;
            }
            else
            {
                this.btnTailQuote.Visible = true;
                this.btnEndor.Visible = true;
                //dtEndorsement.Columns[9].Visible = true;
                //dtEndorsement.Columns[10].Visible = true;
                prmdicAdmin = true;
            }

            if (!cp.IsInRole("BTNENDORSEMENT") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnEndor.Visible = false;
            }
            else
            {
                this.btnEndor.Visible = true;
            }


            if (cp.IsInRole("SUBSCRIPTION"))
            {
                Label8.Visible = true;
                txtCorporation.Visible = true;
                Label70.Visible = true;
                txtQuoteRetroDate.Visible = true;
                Label72.Visible = true;
                Label74.Visible = true;
                ddlGroup2.Visible = true;
                ddlAgent0.Visible = true;
                Label18.Visible = true;
                txtCustomerName2.Visible = true;
                Label3.Visible = true;
                ddlPrimaryLimits1.Visible = true;
                Label10.Visible = true;
                ddlLimits.Visible = true;
                Label11.Visible = true;
                ddlPolicyClass.Visible = true;
                Label12.Visible = true;
                txtIsoCode.Visible = true;
                Label19.Visible = true;
                txtPRate4.Visible = true;
                Label20.Visible = true;
                txtRate4.Visible = true;
                Label2.Visible = true;
                txtPrimaryTN1.Visible = true;
                txtPrimaryTN2.Visible = true;
                txtPrimaryTN3.Visible = true;
                txtPrimaryTN4.Visible = true;
                txtPrimaryTN5.Visible = true;
                Label4.Visible = true;
                txtRateTN1.Visible = true;
                txtRateTN2.Visible = true;
                txtRateTN3.Visible = true;
                txtRateTN4.Visible = true;
                txtRateTN5.Visible = true;
                txtRateTN6.Visible = true;
                Label27.Visible = true;
                Label14.Visible = true;
                txtPremiumTN1.Visible = true;
                txtPremiumTN2.Visible = true;
                txtPremiumTN3.Visible = true;
                txtPremiumTN4.Visible = true;
                txtPremiumTN5.Visible = true;

            }

            if (cp.IsInRole("POWERAGENT") && taskControl.CancellationDate != "")
            {
                btnPrintCertificate.Visible = false;
                btnPrint.Visible = false;
            }

            if (cp.IsInRole("ACCOUNTING"))
            {
                this.btnTailQuote.Visible = true;
            }
            if (cp.IsInRole("ACCOUNTING REPORTING"))
            {
                this.btnTailQuote.Visible = false;
            }
            if (cp.IsInRole("ACCOUNTING") && taskControl.CancellationDate != "")
            {
                btnPrint.Visible = true;
            }
        }
        #endregion

        private void FillTextDDlAgent()
        {
            TaskControl.CorporatePolicyQuote taskControl = (TaskControl.CorporatePolicyQuote)Session["TaskControl"];

            taskControl.AgentSelectedTable = TaskControl.Policy.GetSelectedAgent(taskControl.TaskControlID);

            Session.Add("TaskControl", taskControl);

            SetddlSelectedAgent(taskControl.AgentSelectedTable);
            ddlSelectedAgentOrder();

            VerifyLabelAgent(ddlSelectedAgent.Items.Count, 1, false);
        }
        private void FillTextControl()
        {
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            try
            {
                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                if (taskControl.IsPolicy)
                {
                    if (taskControl.Mode != 1)
                        FillTextDDlAgent();

                    if (taskControl.OriginatedAt != 0)
                        ddlOriginatedAt.SelectedIndex = ddlOriginatedAt.Items.IndexOf(
                            ddlOriginatedAt.Items.FindByValue(taskControl.OriginatedAt.ToString()));

                    if (taskControl.InsuranceCompany != "0")
                        ddlInsuranceCompany.SelectedIndex = ddlInsuranceCompany.Items.IndexOf(
                            ddlInsuranceCompany.Items.FindByValue(taskControl.InsuranceCompany.ToString()));

                    if (taskControl.Agency != "0")
                        ddlAgency.SelectedIndex = ddlAgency.Items.IndexOf(
                            ddlAgency.Items.FindByValue(taskControl.Agency));

                    if (taskControl.City != 0)
                    {
                        ddlCity.SelectedIndex = ddlCity.Items.IndexOf(
                            ddlCity.Items.FindByValue(taskControl.City.ToString()));
                    }

                    if (taskControl.Agent != "0")
                    {
                        ddlAgent.SelectedIndex = ddlAgent.Items.IndexOf(
                            ddlAgent.Items.FindByValue(taskControl.Agent));
                    }

                    if (taskControl.Agent2 != "0")
                    {
                        ddlAgent2.SelectedIndex = ddlAgent2.Items.IndexOf(
                            ddlAgent2.Items.FindByValue(taskControl.Agent2));
                    }

                    if (taskControl.CompanyDealer != "0")
                        ddlCorparation.SelectedIndex = ddlCorparation.Items.IndexOf(
                            ddlCorparation.Items.FindByValue(taskControl.CompanyDealer));

                    if (taskControl.FinancialID != 0)
                        ddlFinancial.SelectedIndex = ddlFinancial.Items.IndexOf(
                            ddlFinancial.Items.FindByValue(taskControl.FinancialID.ToString()));

                    if (taskControl.MainSpecialtyID != 0)
                        ddlMainSpecialty.SelectedIndex = ddlMainSpecialty.Items.IndexOf(
                            ddlMainSpecialty.Items.FindByValue(taskControl.MainSpecialtyID.ToString()));

                    if (taskControl.OtherSpecialtyIDA != 0)
                        ddlOtherSpecialtyA.SelectedIndex = ddlOtherSpecialtyA.Items.IndexOf(
                            ddlOtherSpecialtyA.Items.FindByValue(taskControl.OtherSpecialtyIDA.ToString()));

                    if (taskControl.OtherSpecialtyIDB != 0)
                        ddlOtherSpecialtyB.SelectedIndex = ddlOtherSpecialtyB.Items.IndexOf(
                            ddlOtherSpecialtyB.Items.FindByValue(taskControl.OtherSpecialtyIDB.ToString()));

                    if (taskControl.Bank != "0")
                        ddlGroup.SelectedIndex = ddlGroup.Items.IndexOf(
                            ddlGroup.Items.FindByValue(taskControl.Bank));

                    if (taskControl.PriPolLimits1 != "" && taskControl.PriPolLimits1 != null)
                    {
                        if (taskControl.PriPolLimits1 == "1M/3M")
                            taskControl.PriPolLimits1 = "1,000,000/3,000,000";
                        else if (taskControl.PriPolLimits1 == "100,000-300,000")
                            taskControl.PriPolLimits1 = "100,000/300,000";
                        else if (taskControl.PriPolLimits1 == "150/200")
                            taskControl.PriPolLimits1 = "150,000/200,000";
                        else if (taskControl.PriPolLimits1 == "100300")
                            taskControl.PriPolLimits1 = "100,000/300,000";
                        else if (taskControl.PriPolLimits1 == "250/500")
                            taskControl.PriPolLimits1 = "250,000/500,000";
                        else if (taskControl.PriPolLimits1 == "100/300")
                            taskControl.PriPolLimits1 = "100,000/300,000";
                        else if (taskControl.PriPolLimits1 == "400/700")
                            taskControl.PriPolLimits1 = "400,000/700,000";

                        ddlPriPolLimits1.SelectedIndex = ddlPriPolLimits1.Items.IndexOf(ddlPriPolLimits1.Items.FindByText(
                            taskControl.PriPolLimits1.ToString().Replace(" ", string.Empty)));
                    }

                    if (taskControl.Notification30Flag && taskControl.Notification15Flag && taskControl.CancellationFlag)
                        chkPaymentGA.Checked = true;
                    ///////////
                    if (taskControl.UpdateForm == true)
                    {
                        chkUpdateForm.Checked = true;
                    }
                    else 
                    {
                        chkUpdateForm.Checked = false;
                    }
                    //Gaps
                    if (taskControl.GapBegDate == null)
                    {
                        txtGapBegDate.Text = "";
                        txtGapEndDate.Text = "";
                    }
                    else
                    {
                        txtGapBegDate.Text = taskControl.GapBegDate;
                        txtGapEndDate.Text = taskControl.GapEndDate;
                    }
                    if (taskControl.GapBegDate2 == null)
                    {
                        txtGapBegDate2.Text = "";
                        txtGapEndDate2.Text = "";
                    }
                    else
                    {
                        txtGapBegDate2.Text = taskControl.GapBegDate2;
                        txtGapEndDate2.Text = taskControl.GapEndDate2;
                    }
                    if (taskControl.GapBegDate3 == null)
                    {
                        txtGapEndDate3.Text = "";
                        txtGapBegDate3.Text = "";
                    }
                    else
                    {
                        txtGapEndDate3.Text = taskControl.GapEndDate3;
                        txtGapBegDate3.Text = taskControl.GapBegDate3;
                    }
                    if (taskControl.NumberOfEmployees == null)                    
                        txtNumberOfEmployees.Text = "";                    
                    else
                        txtNumberOfEmployees.Text = taskControl.NumberOfEmployees.ToString();
                    /////////////////
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

                    LblStatus.Text = taskControl.Status;

                    TxtCustomerNo.Text = taskControl.Customer.CustomerNo;
                    TxtProspectNo.Text = taskControl.Customer.ProspectID.ToString();
                    TxtFirstName.Text = taskControl.Customer.FirstName + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2;
                    //TxtInitial.Text = taskControl.Customer.Initial;
                    //txtLastname1.Text = taskControl.Customer.LastName1;
                    //txtLastname2.Text = taskControl.Customer.LastName2;
                    TxtAddrs1.Text = taskControl.Customer.Address1;
                    TxtAddrs2.Text = taskControl.Customer.Address2;
                    TxtCity.Text = taskControl.Customer.City;
                    TxtState.Text = taskControl.Customer.State;
                    TxtZip.Text = taskControl.Customer.ZipCode;
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
                    TxtTerm.Text = taskControl.Term.ToString();
                    TxtRetroactiveDate.Text = taskControl.RetroactiveDate;
                    txtQuoteRetroDate.Text = taskControl.RetroactiveDate;
                    txtEffDt.Text = taskControl.EffectiveDate;
                    txtExpDt.Text = taskControl.ExpirationDate;
                    txtEntryDate.Text = taskControl.EntryDate.ToShortDateString();
                    TxtCharge.Text = taskControl.Charge.ToString("###,##0.00");
                    TxtPremium.Text = taskControl.TotalPremium.ToString("###,##0.00");
                    if (taskControl.CancellationAmount > 0) TxtCancAmount.Text = taskControl.CancellationAmount.ToString("-###,##0.00"); else TxtCancAmount.Text = "0.00";
                    TxtTotalPremium.Text = ((taskControl.TotalPremium + taskControl.Charge) - taskControl.CancellationAmount).ToString("###,##0.00");
                    TxtComments.Text = taskControl.Comments.ToString();

                    if (taskControl.ClaimNo != "")
                    {
                        txtClaimNumber.Text = taskControl.ClaimNo;
                        lblClaimNo.Visible = true;
                        txtClaimNumber.Visible = true;
                        rblClaim.SelectedIndex = 0;
                    }
                    else
                    {
                        txtClaimNumber.Text = "";
                        lblClaimNo.Visible = false;
                        txtClaimNumber.Visible = false;
                        rblClaim.SelectedIndex = 1;
                    }

                    if (rblClaim.SelectedItem.Value == "0")
                        lblClaimNo.Visible = true;
                    else
                        lblClaimNo.Visible = false;

                    if (taskControl.CancellationDate == String.Empty)
                        txtExpDt.Text = taskControl.ExpirationDate;
                    else
                    {
                        txtExpDt.Text = taskControl.CancellationDate;
                        Label58.Text = "Canc. Date";
                    }

                    ChkAutoAssignPolicy.Checked = taskControl.AutoAssignPolicy;

                    txtPriCarierName1.Text = taskControl.PriCarierName1;
                    txtPriPolEffecDate1.Text = taskControl.PriPolEffecDate1;
                    //txtPriPolLimits1.Text = taskControl.PriPolLimits1;
                    txtPriClaims1.Text = taskControl.PriClaims1;

                    FillEndorsementGrid();
                }

                if (taskControl.Customer.CustomerNo != "")
                    TxtCustomerNo.Text = taskControl.Customer.CustomerNo;

                if (taskControl.Customer.FirstName != "")
                {
                    TxtFirstName.Text = taskControl.Customer.FirstName;
                    txtCorporation.Text = taskControl.Customer.FirstName;
                }
                else
                {
                    txtCorporation.Text = taskControl.Corporate.ToString();
                }
                


                lblTCID.Text = taskControl.TaskControlID.ToString();               
                txtQuoteRetroDate.Text = taskControl.RetroDate.ToString().Trim();

                if (taskControl.Agent != "000")
                {
                    ddlAgent0.SelectedIndex = ddlAgent0.Items.IndexOf(
                       ddlAgent0.Items.FindByValue(taskControl.Agent));
                }

                if (taskControl.Bank != "000")
                    ddlGroup2.SelectedIndex = ddlGroup2.Items.IndexOf(
                        ddlGroup2.Items.FindByValue(taskControl.Bank));

                txtDiscountP.Text = taskControl.DiscountP.ToString();
                txtDiscount.Text = taskControl.Discount.ToString();
                txtTotalPrimaryPremium.Text = taskControl.TotalPrimaryPremium.ToString();
                txtTotalExcessPremium.Text = taskControl.TotalExcessPremium.ToString();

                txtRateTN1.Text = taskControl.RateTN1.ToString("###,##0");
                txtRateTN2.Text = taskControl.RateTN2.ToString("###,##0");
                txtRateTN3.Text = taskControl.RateTN3.ToString("###,##0");
                txtRateTN4.Text = taskControl.RateTN4.ToString("###,##0");
                txtRateTN5.Text = taskControl.RateTN5.ToString("###,##0");
                txtRateTN6.Text = taskControl.RateTN6.ToString("###,##0");
                txtPrimaryTN1.Text = taskControl.PrimaryTN1.ToString("###,###.##");
                txtPrimaryTN2.Text = taskControl.PrimaryTN2.ToString("###,###.##");
                txtPrimaryTN3.Text = taskControl.PrimaryTN3.ToString("###,###.##");
                txtPrimaryTN4.Text = taskControl.PrimaryTN4.ToString("###,###.##");
                txtPrimaryTN5.Text = taskControl.PrimaryTN5.ToString("###,###.##");
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

                txtERateTN1.Text = taskControl.ERateTN1.ToString("###,##0");
                txtERateTN2.Text = taskControl.ERateTN2.ToString("###,##0");
                txtERateTN3.Text = taskControl.ERateTN3.ToString("###,##0");
                txtERateTN4.Text = taskControl.ERateTN4.ToString("###,##0");
                txtERateTN5.Text = taskControl.ERateTN5.ToString();
                txtERateTN6.Text = taskControl.ERateTN6.ToString("###,##0");
                txtExcessTN1.Text = taskControl.ExcessTN1.ToString("###,###.##");
                txtExcessTN2.Text = taskControl.ExcessTN2.ToString("###,###.##");
                txtExcessTN3.Text = taskControl.ExcessTN3.ToString("###,###.##");
                txtExcessTN4.Text = taskControl.ExcessTN4.ToString("###,###.##");
                txtExcessTN5.Text = taskControl.ExcessTN5.ToString("###,###.##");
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

                txtTotalPrimaryCorporate.Text = taskControl.TotalPrimaryCorporate.ToString("###,##0.00");
                txtTotalExcessCorporate.Text = taskControl.TotalExcessCorporate.ToString("###,##0.00");

                btnEnablePrint.Visible = taskControl.PrintPolicy;

                if (taskControl.Mode != 1)
                {

                    FillCorporatePolicyGrid();

                    if (taskControl.PolicyType.Trim() == "CE" && taskControl.PolicyNo.Trim() == "10026")
                        ddlPrMedicalLimits.SelectedIndex = ddlPrMedicalLimits.Items.IndexOf(ddlPrMedicalLimits.Items.FindByText("1,000,000/1,000,000"));
                    else if (taskControl.PolicyType.Trim() == "AEC" && taskControl.PolicyNo.Trim() == "40000")
                        ddlPrMedicalLimits.SelectedIndex = ddlPrMedicalLimits.Items.IndexOf(ddlPrMedicalLimits.Items.FindByText("900,000/2,700,000"));
                    else if (taskControl.PolicyType.Trim() == "CE" && taskControl.PolicyNo.Trim() == "10118")
                        ddlPrMedicalLimits.SelectedIndex = ddlPrMedicalLimits.Items.IndexOf(ddlPrMedicalLimits.Items.FindByText("150,000/2,700,000"));
                    else if (taskControl.PolicyType.Trim() == "CE" && taskControl.PolicyNo.Trim() == "10118")
                        ddlPrMedicalLimits.SelectedIndex = ddlPrMedicalLimits.Items.IndexOf(ddlPrMedicalLimits.Items.FindByText("500,000/1,000,000"));
                    //else if (taskControl.PolicyType.Trim() == "CP" && taskControl.PolicyNo.Trim() == "60347")
                    //    ddlPrMedicalLimits.SelectedIndex = ddlPrMedicalLimits.Items.IndexOf(ddlPrMedicalLimits.Items.FindByText("100,000/300,000"));
                        //
                    else if ((taskControl.PolicyType.Trim() == "CP" || taskControl.PolicyType.Trim() == "APC") && DtGridCorpaoratePol.Items.Count > 0)
                        ddlPrMedicalLimits.SelectedIndex = ddlPrMedicalLimits.Items.IndexOf(ddlPrMedicalLimits.Items.FindByText(DtGridCorpaoratePol.Items[0].Cells[3].Text.Trim()));
                    else
                    {
                        DataTable dtSetLimit = TaskControl.CorporatePolicyQuote.GetCorporatePolicyDetailByTaskControlID(taskControl.TaskControlID, taskControl.IsPolicy);
                        if (dtSetLimit.Rows.Count > 0) 
                        { 
                                  
                            if (taskControl.IsPolicy) 
                        { 
                                    if (taskControl.PolicyType.Trim().Contains("E"))
                                        //ddlPrMedicalLimits.SelectedIndex = ddlPrMedicalLimits.Items.IndexOf(ddlPrMedicalLimits.Items.FindByText(
                                        //    dtSetLimit.Rows[0]["ExcessRate"].ToString().Trim()));
                                        ddlPrMedicalLimits.SelectedIndex = ddlPrMedicalLimits.Items.IndexOf(ddlPrMedicalLimits.Items.FindByText(
                                            taskControl.PrMedicalLimit.ToString()));
                                        //taskControl.PrMedicalLimit.ToString();//ddlPrMedicalLimits.Items.IndexOf(ddlPrMedicalLimits.Items.FindByText(ddlLimits.SelectedItem.Text));
                                    else
                                        ddlPrMedicalLimits.SelectedIndex = ddlPrMedicalLimits.Items.IndexOf(ddlPrMedicalLimits.Items.FindByText(
                                            dtSetLimit.Rows[0]["PrimaryRate"].ToString().Trim()));//taskControl.PrMedicalLimit.ToString();
                                                              //PrimaryRate 3/7/17
                            }      
                       }


                    }
                        //ddlPrMedicalLimits.SelectedItem.Value = taskControl.PrMedicalLimit.ToString();
                       // ddlPrMedicalLimits.SelectedIndex = ddlPrMedicalLimits.Items.IndexOf(
                            //ddlPrMedicalLimits.Items.FindByText(taskControl.PrMedicalLimit.ToString()));

                }
                else
                {

                    if (taskControl.PrMedicalLimit != null) //Para el error de que llega null
                    {
                        ddlPrMedicalLimits.SelectedIndex = ddlPrMedicalLimits.Items.IndexOf(
                               ddlPrMedicalLimits.Items.FindByText(taskControl.PrMedicalLimit.ToString()));
                    }

                }

                if (taskControl.PolicyType.Trim() == "CE" || taskControl.PolicyType.Trim() == "AEC")
                    lblCarrier.Text = "Primary Carrier Name";
                else
                    lblCarrier.Text = "Excess Carrier Name";

                lblQuantity.Text = DtGridCorpaoratePol.Items.Count.ToString();

                if (taskControl.isEndorsement == true && Session["PLEndorsement"] != null)
                {
                    if (Session["PLEndorsementDate"] != null)
                    {
                        txtEntryDate.Text = (string)Session["PLEndorsementDate"];
                        Session.Remove("PLEndorsementDate");
                    }
                    else
                    {
                        if (txtEntryDate.Text.Trim() == "")
                            txtEntryDate.Text = DateTime.Now.ToShortDateString();
                    }

                    //CalculateEndorsementOnlyForQuote();

                    //pnlEndorsement.Visible = true;
                    //Panel2.Visible = true;
                }
                	DataTable DtComment = new DataTable();
                DtComment = Comment.GetComment(taskControl.TaskControlID);

                if (DtComment.Rows.Count > 0)//aqui
                {
                    btnComment.BackColor = Color.Yellow;
                    btnComment.ForeColor = Color.Black;
                }

                //ddlPrimaryLimits1.Items.Remove(ddlPrimaryLimits1.Items.FindByText("900,000/2,700,000"));
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
        private void FillProperties()
        {
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];

            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

            if (taskControl.IsPolicy)
            {
                taskControl.LbxAgentSelected = ddlSelectedAgent;
                if (ddlSelectedAgent.Items.Count != 0)
                {
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

                //Branch
                if (ddlCity.SelectedIndex > 0 && ddlCity.SelectedIndex != null)
                    taskControl.City = int.Parse(ddlCity.SelectedItem.Value);
                else
                    taskControl.City = 0;

                //Agent
                if ((ddlAgent.SelectedIndex > 0 && ddlAgent.SelectedItem != null))
                    taskControl.Agent = ddlAgent.SelectedItem.Value;
                else
                    taskControl.Agent = "000";

                //if (chkUpdateForm.Checked)
                //{
                //    taskControl.UpdateForm = 1;

                //}
                //else
                //{
                //    taskControl.UpdateForm = 0;
                //}
                //Gaps
                if (txtGapBegDate.Text == "" || txtGapEndDate.Text == "") //Gap1
                {
                    taskControl.GapBegDate = "";
                    taskControl.GapEndDate = "";
                }
                else
                {
                    taskControl.GapBegDate = txtGapBegDate.Text.ToString();
                    taskControl.GapEndDate = txtGapEndDate.Text.ToString();
                }
                if (txtGapBegDate2.Text == "" || txtGapEndDate2.Text == "") //Gap2
                {
                    taskControl.GapBegDate2 = "";
                    taskControl.GapEndDate2 = "";
                }
                else
                {
                    taskControl.GapBegDate2 = txtGapBegDate2.Text.ToString();
                    taskControl.GapEndDate2 = txtGapEndDate2.Text.ToString();
                }
                if (txtGapBegDate3.Text == "" || txtGapEndDate3.Text == "") //Gap3
                {
                    taskControl.GapBegDate3 = "";
                    taskControl.GapEndDate3 = "";
                }
                else
                {
                    taskControl.GapBegDate3 = txtGapBegDate3.Text.ToString();
                    taskControl.GapEndDate3 = txtGapEndDate3.Text.ToString();
                }
                int numOfMedics = 0;
                foreach (DataGridItem row in DtGridCorpaoratePol.Items)
                {
                    numOfMedics = numOfMedics + 1;
                }
                taskControl.NumberOfEmployees = numOfMedics.ToString();

                if(taskControl.PolicyType.Trim() == "CE" || taskControl.PolicyType.Trim() == "AEC")
                    taskControl.OtherPersonel = txtEQuantityTN6.Text.ToString().Trim();
                else
                    taskControl.OtherPersonel = txtQuantityTN6.Text.ToString().Trim();
                
                //Agent
                if ((ddlAgent2.SelectedIndex > 0 && ddlAgent2.SelectedItem != null))
                    taskControl.Agent2 = ddlAgent2.SelectedItem.Value;
                else
                    taskControl.Agent2 = "000";
                
                //Corporation
                if (ddlCorparation.SelectedIndex > 0 && ddlCorparation.SelectedItem != null)
                    taskControl.CompanyDealer = ddlCorparation.SelectedItem.Value;
                else
                    taskControl.CompanyDealer = "000";

                //InsuranceCompany
                if (ddlInsuranceCompany.SelectedIndex > 0 && ddlInsuranceCompany.SelectedItem != null)
                    taskControl.InsuranceCompany = ddlInsuranceCompany.SelectedItem.Value;
                else
                    taskControl.InsuranceCompany = "000";

                //Corparation
                if (ddlCorparation.SelectedIndex > 0 && ddlCorparation.SelectedItem != null)
                    taskControl.CompanyDealer = ddlCorparation.SelectedItem.Value;
                else
                    taskControl.CompanyDealer = "000";

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

                //MainSpecialty
                if (ddlMainSpecialty.SelectedIndex > 0 && ddlMainSpecialty.SelectedItem != null)
                {
                    taskControl.MainSpecialtyID = int.Parse(ddlMainSpecialty.SelectedItem.Value.ToString());
                }
                else { taskControl.MainSpecialtyID = 0; }

                //OtherSpecialtyA
                if (ddlOtherSpecialtyA.SelectedIndex > 0 && ddlOtherSpecialtyA.SelectedItem != null)
                {
                    taskControl.OtherSpecialtyIDA = int.Parse(ddlOtherSpecialtyA.SelectedItem.Value.ToString());
                }
                else { taskControl.OtherSpecialtyIDA = 0; }

                //OtherSpecialtyB
                if (ddlOtherSpecialtyB.SelectedIndex > 0 && ddlOtherSpecialtyB.SelectedItem != null)
                {
                    taskControl.OtherSpecialtyIDB = int.Parse(ddlOtherSpecialtyB.SelectedItem.Value.ToString());
                }
                else { taskControl.OtherSpecialtyIDB = 0; }

                //Group
                if (ddlGroup.Visible)
                {
                    if (ddlGroup.SelectedIndex > 0 && ddlGroup.SelectedItem != null)
                        taskControl.Bank = ddlGroup.SelectedItem.Value;
                    else
                        taskControl.Bank = "000";
                }

                if (ddlPriPolLimits1.SelectedIndex > 0 && ddlPriPolLimits1.SelectedIndex != null)
                {
                    taskControl.PriPolLimits1 = ddlPriPolLimits1.SelectedItem.Text;
                }

                //Check Payments by GA
                taskControl.Notification30Flag = chkPaymentGA.Checked;
                taskControl.Notification15Flag = chkPaymentGA.Checked;
                taskControl.CancellationFlag = chkPaymentGA.Checked;
                ////////////
                taskControl.UpdateForm = chkUpdateForm.Checked;
                ///////////////

                //Ciudad
                //if (ddlCiudad.SelectedIndex > 0 && ddlCiudad.SelectedItem != null)
                //    taskControl.Customer.City = ddlCiudad.SelectedItem.Text;
                //else
                //    taskControl.Customer.City = "";

                taskControl.SupplierID = "000";

             //   taskControl.Customer.ProspectID = TxtProspectNo.Text.Trim();
                taskControl.Customer.CustomerNo = TxtCustomerNo.Text.Trim();
                taskControl.Customer.FirstName = TxtFirstName.Text.ToUpper().Trim();
                taskControl.Customer.Initial = "";//TxtInitial.Text.ToUpper().Trim();
                taskControl.Customer.LastName1 = "";// txtLastname1.Text.ToUpper().Trim();
                taskControl.Customer.LastName2 = "";// txtLastname2.Text.ToUpper().Trim();
                taskControl.Customer.Address1 = TxtAddrs1.Text.ToUpper().Trim();
                taskControl.Customer.Address2 = TxtAddrs2.Text.ToUpper().Trim();
                taskControl.Customer.City = TxtCity.Text.ToUpper().Trim();
                taskControl.Customer.State = TxtState.Text.ToUpper().Trim();
                taskControl.Customer.ZipCode = TxtZip.Text.ToUpper().Trim();
                taskControl.Customer.HomePhone = txtHomePhone.Text.Trim();
                taskControl.Customer.JobPhone = txtWorkPhone.Text.Trim();
                taskControl.Customer.Cellular = TxtCellular.Text.Trim();
                taskControl.Customer.Email = txtEmail.Text.Trim();
                taskControl.Customer.License = txtLicense.Text.Trim();
                taskControl.Comments = TxtComments.Text.Trim().ToUpper();
                taskControl.ClaimNo = txtClaimNumber.Text.Trim();

                taskControl.PolicyNo = TxtPolicyNo.Text.Trim().ToUpper().Replace(" ", "");
                taskControl.Certificate = TxtCertificate.Text.Trim().ToUpper();
                taskControl.PolicyType = TxtPolicyType.Text.Trim().ToUpper();
                taskControl.Suffix = TxtSufijo.Text.Trim();
                taskControl.Anniversary = TxtAnniversary.Text.Trim();
                taskControl.Term = int.Parse(TxtTerm.Text.Trim());
                taskControl.EffectiveDate = txtEffDt.Text.Trim();

                if (TxtRetroactiveDate.Text != String.Empty)
                    taskControl.RetroactiveDate = TxtRetroactiveDate.Text;

                if (userID == 156) //txtExpDt Override for Kayla
                {
                    taskControl.ExpirationDate = DateTime.Parse(this.txtExpDt.Text).ToShortDateString();
                }
                else if (taskControl.ExpirationDate.Trim() == string.Empty) // && this.TxtTerm.Text.Trim() != string.Empty)
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
                        if (taskControl.Mode == 2 && cp.IsInRole("MODIFICAREXPDATE"))
                        {
                            taskControl.ExpirationDate = DateTime.Parse(this.txtExpDt.Text).ToShortDateString();
                        }
                        else if (taskControl.Mode == 1)
                        {
                            taskControl.ExpirationDate = DateTime.Parse(taskControl.ExpirationDate).ToShortDateString();//.AddMonths(int.Parse(this.TxtTerm.Text.Trim())).ToShortDateString();//this.txtEffDt.Text
                            this.txtExpDt.Text = taskControl.ExpirationDate;
                        }
                    }
                }

                if (taskControl.CancellationDate == "")
                    taskControl.EntryDate = DateTime.Parse(txtEntryDate.Text);


                if (TxtCharge.Text.Trim() == "")
                    taskControl.Charge = 0.00;
                else
                    taskControl.Charge = double.Parse(TxtCharge.Text.ToString().Trim());

                if (TxtPremium.Text.Trim() == "")
                    taskControl.TotalPremium = 0.00;
                else
                    taskControl.TotalPremium = double.Parse(TxtPremium.Text.ToString().Trim());

                if (ChkAutoAssignPolicy.Checked)
                    taskControl.AutoAssignPolicy = true;
                else
                    taskControl.AutoAssignPolicy = false;

                taskControl.InvoiceNumber = "0";
                if (taskControl.Bank != "000") //Bank = Group
                {
                    EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                    master = master.GetMasterPolicyDiscount(taskControl.Bank, taskControl.EffectiveDate);

                    if (taskControl.PolicyType.Trim() == "CE" || taskControl.PolicyType.Trim() == "AEC") //Excess
                    {
                        taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                        double totprem = Math.Round(taskControl.TotalPremium - (taskControl.TotalPremium * (master.DescuentoExcess / 100)), 0);
                        taskControl.TotalPremium = totprem;
                    }
                    else // Primary
                    {
                        taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                        double totprem = Math.Round(taskControl.TotalPremium - (taskControl.TotalPremium * (master.DescuentoPrimario / 100)), 0);
                        taskControl.TotalPremium = totprem;
                    }
                }
            }

            if (txtQuoteRetroDate.Text != String.Empty)
            {
                taskControl.RetroactiveDate = txtQuoteRetroDate.Text;
                taskControl.RetroDate = txtQuoteRetroDate.Text;
            }

            if (!taskControl.IsPolicy)
            {
                if ((ddlAgent0.SelectedIndex > 0 && ddlAgent0.SelectedItem != null))
                    taskControl.Agent = ddlAgent0.SelectedItem.Value;
                else
                    taskControl.Agent = "000";
            }

            if (ddlGroup2.SelectedIndex > 0 && ddlGroup2.SelectedItem != null)
                taskControl.Bank = ddlGroup2.SelectedItem.Value;
            else
                taskControl.Bank = "000";

            taskControl.Corporate = txtCorporation.Text.Trim().ToUpper();
            taskControl.DiscountP = double.Parse(txtDiscountP.Text.Replace("%", ""));
            taskControl.Discount = double.Parse(txtDiscount.Text.Replace("%", ""));
            taskControl.TotalPrimaryPremium = double.Parse(txtTotalPrimaryPremium.Text);
            taskControl.TotalExcessPremium = double.Parse(txtTotalExcessPremium.Text);

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
            taskControl.TotalPrimaryCorporate = double.Parse(txtTotalPrimaryCorporate.Text);
            taskControl.TotalExcessCorporate = double.Parse(txtTotalExcessCorporate.Text);

            taskControl.PriCarierName1 = txtPriCarierName1.Text.Trim().ToUpper();
            taskControl.PriPolEffecDate1 = txtPriPolEffecDate1.Text.Trim().ToUpper();
            //taskControl.PriPolLimits1 = txtPriPolLimits1.Text.Trim().ToUpper();
            taskControl.PriPolLimits1 = ddlPriPolLimits1.SelectedItem.Text.Trim().ToUpper();
            taskControl.PriClaims1 = txtPriClaims1.Text.Trim().ToUpper();
            taskControl.PrMedicalLimit = ddlPrMedicalLimits.SelectedItem.Text.Trim().ToUpper();
        }
        private void FillGrid()
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = 0;
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

            DtSearchPayments.Visible = false;
            DtSearchPayments.DataSource = null;
            DtTaskPolicy = null;

            int policyClass = 0;
            string tempPolType = String.Empty;

            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];

            if (taskControl.PolicyType.ToString().Trim().Length >= 3 && !taskControl.PolicyType.Contains("A"))
                tempPolType = taskControl.PolicyType.Remove(taskControl.PolicyType.IndexOf('T'));
            else
                tempPolType = taskControl.PolicyType.Trim();

            DtTaskPolicy = TaskControl.Policy.GetPolicies(policyClass, /*tempPolType*/ "",
                /*taskControl.PolicyNo*/ "", taskControl.CustomerNo, "", "", "", "", userID);

            DataView dv = DtTaskPolicy.DefaultView;
            dv.Sort = "PolicyType, Sufijo asc";
            DataTable sortedDT = dv.ToTable();

            DtTaskPolicy = sortedDT;

            Session.Remove("DtTaskPolicy");
            Session.Add("DtTaskPolicy", DtTaskPolicy);

            if (DtTaskPolicy.Rows.Count != 0)
            {
                DtSearchPayments.Visible = true;
                DtSearchPayments.DataSource = DtTaskPolicy;
                DtSearchPayments.DataBind();
            }
            else
            {
                DtSearchPayments.DataSource = null;
                DtSearchPayments.DataBind();
            }
        }
        private void FillCorporatePolicyGrid()
        {
            DataTable dt = new DataTable();
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            bool flag = false;

            if (taskControl.TaskControlID == 0)
            {
                taskControl.TaskControlID = oldTaskControlID;
                flag = true;
            }

            if (convert)
            {
                dt = EPolicy.TaskControl.CorporatePolicyQuote.GetCorporatePolicyDetailByTaskControlID(taskControl.TaskControlID, false);
            }
            else
                dt = EPolicy.TaskControl.CorporatePolicyQuote.GetCorporatePolicyDetailByTaskControlID(taskControl.TaskControlID, taskControl.IsPolicy);

            if (dt.Rows.Count != 0)
            {
                DtGridCorpaoratePol.DataSource = dt;
                DtGridCorpaoratePol.DataBind();
                DtGridCorpaoratePol.Visible = true;
                lblQuantity.Text = DtGridCorpaoratePol.Items.Count.ToString();
            }
            else
            {
                this.DtGridCorpaoratePol.DataSource = null;
                this.DtGridCorpaoratePol.DataBind();
            }
            convert = false;
            if (flag)
                taskControl.TaskControlID = 0;
        }
        private DataTable SearchPolicy(string policyType, string policyNo)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("PolicyType", SqlDbType.VarChar, 3, policyType.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PolicyNo", SqlDbType.VarChar, 11, policyNo.ToString(), ref cookItems);

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
                dt = exec.GetQuery("GetPolicyByPolicyTypeAndPolicyNo", xmlDoc);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not find the Policy.", ex);
            }

            return dt;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
            DateTime effectiveDate;

            if (txtQuoteRetroDate.Text == String.Empty && !taskControl.IsPolicy)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Please add a retroactive date.");
                this.litPopUp.Visible = true;
            }

            if (TxtRetroactiveDate.Text != "" && txtQuoteRetroDate.Text == "")
                txtQuoteRetroDate.Text = TxtRetroactiveDate.Text;

            if (TxtAddQuantity.Text != "1" && txtCustomerName2.Text != String.Empty) //AQUI
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to add multiple physicians with the same name.");
                this.litPopUp.Visible = true;
            }
            else
            {
                for (int n = 0; n < int.Parse(TxtAddQuantity.Text); n++)
                {
                    try
                    {

                        if (txtCorporatePolicyQuoteID.Text.Trim() != "")
                        {
                            taskControl.CorporatePolicyDetailCollection.Rows.RemoveAt(int.Parse(txtCorporatePolicyQuoteID.Text));
                            taskControl.CorporatePolicyDetailCollection.AcceptChanges();
                            txtCorporatePolicyQuoteID.Text = "";
                        }

                        //Add temp Table
                        DataTable dt = null;
                        DataRow myRow = taskControl.CorporatePolicyDetailCollection.NewRow();

                        myRow["TaskControlID"] = "0";
                        myRow["CustomerName"] = txtCustomerName2.Text.Trim().ToUpper();
                        myRow["PrimaryRate"] = ddlPrimaryLimits1.SelectedItem.Text.Trim();
                        myRow["ExcessRate"] = ddlLimits.SelectedItem.Text.Trim();
                        myRow["Specialty"] = ddlPolicyClass.SelectedItem.Text.Trim();
                        myRow["IsoCode"] = txtIsoCode.Text.Trim();
                        myRow["TotalPrimaryPremium"] = txtPRate4.Text.Trim();
                        myRow["TotalExcessPremium"] = txtRate4.Text.Trim();

                        taskControl.CorporatePolicyDetailCollection.Rows.Add(myRow);
                        taskControl.CorporatePolicyDetailCollection.AcceptChanges();
                        dt = taskControl.CorporatePolicyDetailCollection;

                        this.DtGridCorpaoratePol.CurrentPageIndex = 0;
                        this.DtGridCorpaoratePol.Visible = true;
                        this.DtGridCorpaoratePol.DataSource = dt;
                        this.DtGridCorpaoratePol.DataBind();

                        //Calculate Premium
                        double totPprem = 0.00;
                        double totEprem = 0.00;
                        for (int i = 0; i <= DtGridCorpaoratePol.Items.Count - 1; i++)
                        {
                            totPprem = totPprem + double.Parse(DtGridCorpaoratePol.Items[i].Cells[7].Text);
                            totEprem = totEprem + double.Parse(DtGridCorpaoratePol.Items[i].Cells[8].Text);
                        }

                        //Aplicar Descuento corporativo.
                        //Discount       
                        if (txtDiscountP.Text.Trim() == "")
                            txtDiscountP.Text = "0";

                        if (txtDiscount.Text.Trim() == "")
                            txtDiscount.Text = "0";

                        double disc = 0.00;
                        double totprem2 = 0.00;

                        DateTime retroActiveDate = Convert.ToDateTime(txtQuoteRetroDate.Text.Trim());
                        if (txtEffDt.Text == String.Empty)
                            effectiveDate = DateTime.Now;
                        else
                            effectiveDate = Convert.ToDateTime(txtEffDt.Text.Trim());
                        TimeSpan result = effectiveDate - retroActiveDate;
                        double days = (result.TotalDays + 1);
                        double mcmRate = 0.0;

                        if (days < 366)
                            mcmRate = 0.6;
                        else if (days < 731)
                            mcmRate = 0.8;
                        else if (days < 1096)
                            mcmRate = 0.9;
                        else
                            mcmRate = 1;

                        totPprem = totPprem * mcmRate;
                        totEprem = totEprem * mcmRate;

                        if (txtDiscountP.Text == "0")
                        {
                            disc = double.Parse(txtDiscountP.Text.Replace("%", "").Trim());
                            totprem2 = totPprem;
                            txtTotalPrimaryPremium.Text = totprem2.ToString("###,##0.00");
                        }
                        else
                        {
                            disc = double.Parse(txtDiscountP.Text.Replace("%", "").Trim());
                            totprem2 = Math.Round((totPprem * (Math.Round(disc / 100, 2))), 0);
                            txtTotalPrimaryPremium.Text = totprem2.ToString("###,##0.00");
                        }

                        if (ddlGroup2.SelectedIndex != 0) //Bank = Group
                        {

                            master = master.GetMasterPolicyDiscount(ddlGroup2.SelectedValue, DateTime.Now.ToShortDateString());

                            double totprem = Math.Round(totprem2 - (totprem2 * (master.DescuentoPrimario / 100)), 0);
                            this.txtTotalPrimaryPremium.Text = totprem.ToString("###,###,##0.00");
                        }

                        if (txtDiscount.Text == "0")
                        {
                            disc = double.Parse(txtDiscount.Text.Replace("%", "").Trim());
                            totprem2 = totEprem;
                            txtTotalExcessPremium.Text = totprem2.ToString("###,##0.00");
                        }
                        else
                        {
                            disc = double.Parse(txtDiscount.Text.Replace("%", "").Trim());
                            totprem2 = Math.Round((totEprem * (Math.Round(disc / 100, 2))), 0);
                            txtTotalExcessPremium.Text = totprem2.ToString("###,##0.00");
                        }

                        if (ddlGroup2.SelectedIndex != 0) //Bank = Group
                        {
                            master = master.GetMasterPolicyDiscount(ddlGroup2.SelectedValue, DateTime.Now.ToShortDateString());

                            double totprem = Math.Round(totprem2 - (totprem2 * (master.DescuentoExcess / 100)), 0);
                            this.txtTotalExcessPremium.Text = totprem.ToString("###,###,##0.00");
                        }

                        DataTable dtSetLimit = TaskControl.CorporatePolicyQuote.GetCorporatePolicyDetailByTaskControlID(taskControl.TaskControlID, taskControl.IsPolicy);
                        if (taskControl.IsPolicy)
                        {
                            if (taskControl.PolicyType.Trim().Contains("E"))
                                ddlPrMedicalLimits.SelectedIndex = ddlPrMedicalLimits.Items.IndexOf(ddlPrMedicalLimits.Items.FindByText(
                                    dtSetLimit.Rows[0]["ExcessRate"].ToString().Trim()));//taskControl.PrMedicalLimit.ToString();//ddlPrMedicalLimits.Items.IndexOf(ddlPrMedicalLimits.Items.FindByText(ddlLimits.SelectedItem.Text));
                            else
                                ddlPrMedicalLimits.SelectedIndex = ddlPrMedicalLimits.Items.IndexOf(ddlPrMedicalLimits.Items.FindByText(
                                    dtSetLimit.Rows[0]["PrimaryRate"].ToString().Trim()));//taskControl.PrMedicalLimit.ToString();
                        }

                    }
                    catch (Exception exp)
                    {
                        this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to save this Quote. " + exp.Message);
                        this.litPopUp.Visible = true;
                    }
                }
                this.Button2.Text = "Add";
                txtCustomerName2.Text = "";
                ddlPrimaryLimits1.SelectedIndex = -1;
                ddlLimits.SelectedIndex = -1;
                ddlPolicyClass.SelectedIndex = -1;
                txtIsoCode.Text = "";
                txtPRate4.Text = "";
                txtRate4.Text = "";
                TxtAddQuantity.Text = "1";

                ddlPolicyClass.Items.Clear();
                ddPrimarylPolicyClass.Items.Clear();

                lblQuantity.Text = DtGridCorpaoratePol.Items.Count.ToString();
                
                Session["TaskControl"] = taskControl;
            }
        }
        protected void DtGridCorpaoratePol_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "Select": //Edit
                        this.Button2.Text = "Update";

                        //FillTextBox
                        if (e.Item.Cells[2].Text.ToString().Trim() == " ")
                            txtCustomerName2.Text = "";
                        else
                            txtCustomerName2.Text = e.Item.Cells[2].Text.ToString().Trim();
                        ddlPrimaryLimits1.SelectedIndex = ddlPrimaryLimits1.Items.IndexOf(ddlPrimaryLimits1.Items.FindByText(e.Item.Cells[3].Text.Trim()));
                        ddlLimits.SelectedIndex = ddlLimits.Items.IndexOf(ddlLimits.Items.FindByText(e.Item.Cells[4].Text.Trim()));

                        SetDDLLimit(int.Parse(ddlLimits.SelectedItem.Value), int.Parse(ddlPrimaryLimits1.SelectedItem.Value));

                        ddlPolicyClass.SelectedIndex = ddlPolicyClass.Items.IndexOf(ddlPolicyClass.Items.FindByText(e.Item.Cells[5].Text.Trim()));
                        txtIsoCode.Text = e.Item.Cells[6].Text.ToString().Trim();
                        txtPRate4.Text = e.Item.Cells[7].Text.ToString().Trim();
                        txtRate4.Text = e.Item.Cells[8].Text.ToString().Trim();
                        txtCorporatePolicyQuoteID.Text = e.Item.ItemIndex.ToString();

                        break;
                    case "Delete":
                        DeleteCorporatePolicy(e.Item.ItemIndex);
                        lblQuantity.Text = DtGridCorpaoratePol.Items.Count.ToString();
                        CalculatePhysicians();
                        break;
                    default: //Page
                        if ((int.Parse(e.CommandArgument.ToString()) - 1) >= 0 &&
                            (int.Parse(e.CommandArgument.ToString()) - 1) <= this.DtGridCorpaoratePol.PageCount)
                        {
                            this.DtGridCorpaoratePol.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;
                            this.DtGridCorpaoratePol.DataSource = (DataTable)Session["DTCampaign"];
                            this.DtGridCorpaoratePol.DataBind();

                            this.DtGridCorpaoratePol.SelectedIndex = -1;
                        }
                        break;
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

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("A problem occured while executing the command.");
                this.litPopUp.Visible = true;
            }
        }
        private void DeleteCorporatePolicy(int CorporatePolicyQuoteID)
        {
            try
            {
                EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];

                DataTable dt = null;

                taskControl.CorporatePolicyDetailCollection.Rows.RemoveAt(CorporatePolicyQuoteID);
                taskControl.CorporatePolicyDetailCollection.AcceptChanges();
                dt = taskControl.CorporatePolicyDetailCollection;

                this.DtGridCorpaoratePol.CurrentPageIndex = 0;
                this.DtGridCorpaoratePol.Visible = true;
                this.DtGridCorpaoratePol.DataSource = dt;
                this.DtGridCorpaoratePol.DataBind();
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to delete this Quote. " + exp.Message);
                this.litPopUp.Visible = true;
            }
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            try
            {
                Login.Login cp = HttpContext.Current.User as Login.Login;
               // ArrayList errorMessages = new ArrayList();
                string userName = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();
                string limit = ddlPrMedicalLimits.SelectedItem.Text.ToString();
                //DataTable dt = TaskControl.Policies.GetAgentLicDate(taskControl.Agent.ToString()); // Para cuando ese expirada la poliza no haga print. (Kayla)
                //string AgentLicDate = "";

                //if (dt.Rows.Count != 0)
                //{
                //    AgentLicDate = dt.Rows[0]["agt_licensenumexpdate"].ToString();
                //}
                //if (AgentLicDate.ToString() != "")
                //{
                    
                //    if (DateTime.Parse(AgentLicDate) < DateTime.Parse(DateTime.Now.ToShortDateString().ToString()))
                //    {
                //        errorMessages.Add("The policy License has expired");
                //        throw new Exception("The policy License has expired.");

                //    }
                //}

                if (taskControl.CancellationDate != String.Empty && !taskControl.PolicyType.Trim().Contains("T"))
                {

                    ReportViewer viewer = new ReportViewer();
                    viewer.LocalReport.ReportPath = Server.MapPath("Reports/CancellationCredit.rdlc");
                    viewer.LocalReport.DataSources.Clear();
                    viewer.ProcessingMode = ProcessingMode.Local;

                    ReportParameter[] param = new ReportParameter[15];
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
                    param[8] = new ReportParameter("ReturnPremium", (taskControl.ReturnPremium + taskControl.ReturnCharge).ToString("$###,##0.00"));
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

                    param[14] = new ReportParameter("insuranceCompany", taskControl.InsuranceCompany.ToString());

                    viewer.LocalReport.SetParameters(param);
                    viewer.LocalReport.Refresh();

                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType;
                    string encoding = string.Empty;
                    string extension;
                    string fileName = userName;
                    string _FileName = userName + ".pdf";

                    _FileName = _FileName.Replace(",", "");
                    _FileName = _FileName.Replace("&", "");
                    _FileName = _FileName.Replace("/", "");
                    
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
                else if (taskControl.IsPolicy)
                {
                     if (taskControl.PolicyType.Trim() == "CP")
                    {
                        #region Primary Policy
                        if (taskControl.Anniversary == "01")
                        {
                            if (!taskControl.PrintPolicy && DateTime.Parse(taskControl.EffectiveDate.Trim()) < DateTime.Parse("08/01/2015"))// && prmdicAdmin)
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

                                rpt3 = new EPolicy2.Reports.PRMdic.PrimaryPolicy((EPolicy.TaskControl.Policy)taskControl);
                                rpt3.Document.Printer.PrinterName = "";
                                rpt3.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages);

                                rpt1 = new EPolicy2.Reports.PRMdic.PrimaryPolicy1((EPolicy.TaskControl.Policy)taskControl, false);
                                rpt1.Document.Printer.PrinterName = "";
                                rpt1.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt1.Document.Pages);

                                rpt2 = new EPolicy2.Reports.PRMdic.PrimaryPolicy2((EPolicy.TaskControl.Policy)taskControl, false);
                                rpt2.Document.Printer.PrinterName = "";
                                rpt2.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages);

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
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt20.Document.Pages);

                                rpt21 = new EPolicy2.Reports.PRMdic.PrimaryMandatory2();
                                rpt21.Document.Printer.PrinterName = "";
                                rpt21.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt21.Document.Pages);

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

                                if (taskControl.Charge > 0)//(TxtCharge.Text != ".00")
                                {
                                    rpt29 = new EPolicy2.Reports.PRMdic.ChargeEng((EPolicy.TaskControl.Policy)taskControl);
                                    rpt29.Document.Printer.PrinterName = "";
                                    rpt29.Run(false);
                                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt29.Document.Pages);
                                }

                                taskControl.PrintPolicy = true;
                                taskControl.PrintDate = DateTime.Now.ToShortDateString();
                                FillProperties();
                                History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY.");
                                taskControl.SaveOnlyPolicy(userID);
                                
                                //Export Report CPE-102 Exclusion 2 Endorsement.pdf
                                DataDynamics.ActiveReports.ActiveReport3 rptNew = rpt;

                                string _FileName = ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                                ExportFile expFile = new ExportFile();

                                List<string> mergePaths = new List<string>();

                                // string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                                _FileName = _FileName + taskControl.PolicyType + taskControl.PolicyNo + ".PDF";

                                //string _NameFile = _FilaName + taskControl.PolicyType + taskControl.PolicyNo + ".PDF";

                                expFile.ExportToPDF(rptNew.Document, _FileName);

                                PrintNewEndorsement(_FileName, true);

                                //RemoveSessionLookUp();
                                //Session.Add("Report", rpt);
                                //Session.Add("FromPage", "CorporatePolicyQuote.aspx");
                                //Response.Redirect("ActiveXViewer.aspx");

                            }
                            else if (!taskControl.PrintPolicy && DateTime.Parse(taskControl.EffectiveDate.Trim()) >= DateTime.Parse("08/01/2015"))
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

                                rpt = new EPolicy2.Reports.PRMdic.Invoice(taskControl, false);
                                rpt.Document.Printer.PrinterName = "";
                                rpt.Run(false);

                                rpt1 = new EPolicy2.Reports2.PRMdic.PrimaryPolicyNew();
                                rpt1.Document.Printer.PrinterName = "";
                                rpt1.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt1.Document.Pages);

                                rpt2 = new EPolicy2.Reports.PRMdic.PrimaryPolicy1((EPolicy.TaskControl.Policy)taskControl, false);
                                rpt2.Document.Printer.PrinterName = "";
                                rpt2.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages);

                                rpt3 = new EPolicy2.Reports.PRMdic.PrimaryPolicy2((EPolicy.TaskControl.Policy)taskControl, false);
                                rpt3.Document.Printer.PrinterName = "";
                                rpt3.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages);

                                rpt4 = new EPolicy2.Reports2.PRMdic.PrimaryPolicyNew3();
                                rpt4.Document.Printer.PrinterName = "";
                                rpt4.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt4.Document.Pages);

                                rpt5 = new EPolicy2.Reports2.PRMdic.PrimaryPolicyNew4();
                                rpt5.Document.Printer.PrinterName = "";
                                rpt5.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt5.Document.Pages);

                                rpt6 = new EPolicy2.Reports2.PRMdic.PrimaryPolicyNew5();
                                rpt6.Document.Printer.PrinterName = "";
                                rpt6.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt6.Document.Pages);

                                rpt7 = new EPolicy2.Reports2.PRMdic.PrimaryPolicyNew6();
                                rpt7.Document.Printer.PrinterName = "";
                                rpt7.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt7.Document.Pages);

                                rpt8 = new EPolicy2.Reports2.PRMdic.PrimaryPolicyNew7();
                                rpt8.Document.Printer.PrinterName = "";
                                rpt8.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt8.Document.Pages);

                                rpt9 = new EPolicy2.Reports2.PRMdic.PrimaryPolicyNew8();
                                rpt9.Document.Printer.PrinterName = "";
                                rpt9.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt9.Document.Pages);

                                rpt10 = new EPolicy2.Reports2.PRMdic.PrimaryPolicyNew9();
                                rpt10.Document.Printer.PrinterName = "";
                                rpt10.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt10.Document.Pages);

                                rpt11 = new EPolicy2.Reports2.PRMdic.PrimaryPolicyNew10();
                                rpt11.Document.Printer.PrinterName = "";
                                rpt11.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt11.Document.Pages);

                                rpt12 = new EPolicy2.Reports2.PRMdic.PrimaryPolicyNew11();
                                rpt12.Document.Printer.PrinterName = "";
                                rpt12.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt12.Document.Pages);

                                rpt13 = new EPolicy2.Reports2.PRMdic.PrimaryPolicyNew12();
                                rpt13.Document.Printer.PrinterName = "";
                                rpt13.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt13.Document.Pages);

                                rpt14 = new EPolicy2.Reports2.PRMdic.PrimaryPolicyNew13();
                                rpt14.Document.Printer.PrinterName = "";
                                rpt14.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt14.Document.Pages);

                                rpt15 = new EPolicy2.Reports2.PRMdic.PrimaryPolicyNew14();
                                rpt15.Document.Printer.PrinterName = "";
                                rpt15.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt15.Document.Pages);

                                rpt16 = new EPolicy2.Reports2.PRMdic.PrimaryPolicyNew15((EPolicy.TaskControl.Policy)taskControl);
                                rpt16.Document.Printer.PrinterName = "";
                                rpt16.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt16.Document.Pages);

                                rpt17 = new EPolicy2.Reports.PRMdic.PrimarySchedulerEndorsement((EPolicy.TaskControl.Policy)taskControl, false);
                                rpt17.Document.Printer.PrinterName = "";
                                rpt17.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt17.Document.Pages);

                                rpt18 = new EPolicy2.Reports.PRMdic.PrimaryStatementAcceptance((EPolicy.TaskControl.Policy)taskControl, false);
                                rpt18.Document.Printer.PrinterName = "";
                                rpt18.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt18.Document.Pages);

                                rpt19 = new EPolicy2.Reports.PRMdic.PrimaryMandatory1();
                                rpt19.Document.Printer.PrinterName = "";
                                rpt19.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt19.Document.Pages); //Page 4 

                                rpt20 = new EPolicy2.Reports.PRMdic.PrimaryMandatory2();
                                rpt20.Document.Printer.PrinterName = "";
                                rpt20.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt20.Document.Pages); //Page 5

                                rpt21 = new EPolicy2.Reports.PRMdic.PrimaryMandatory3();
                                rpt21.Document.Printer.PrinterName = "";
                                rpt21.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt21.Document.Pages);

                                rpt22 = new EPolicy2.Reports.PRMdic.PrimaryContinuousRenewal();
                                rpt22.Document.Printer.PrinterName = "";
                                rpt22.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt22.Document.Pages);

                                rpt23 = new EPolicy2.Reports.PRMdic.PrimaryActOfWar((EPolicy.TaskControl.Policy)taskControl, false);
                                rpt23.Document.Printer.PrinterName = "";
                                rpt23.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt23.Document.Pages);

                                rpt24 = new EPolicy2.Reports.PRMdic.PrimaryNuclearEnergy();
                                rpt24.Document.Printer.PrinterName = "";
                                rpt24.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt24.Document.Pages);

                                rpt25 = new EPolicy2.Reports.PRMdic.PrimaryNuclearEnergy2();
                                rpt25.Document.Printer.PrinterName = "";
                                rpt25.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt25.Document.Pages);

                                if (DateTime.Parse(taskControl.EffectiveDate.Trim()).ToShortDateString() != DateTime.Parse(taskControl.RetroactiveDate.Trim()).ToShortDateString())
                                {
                                    rpt26 = new EPolicy2.Reports.PRMdic.PrimaryPriorAct((EPolicy.TaskControl.Policy)taskControl, false);
                                    rpt26.Document.Printer.PrinterName = "";
                                    rpt26.Run(false);
                                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt26.Document.Pages);
                                }

                                if (taskControl.Charge > 0)//TxtCharge.Text != ".00")
                                {
                                    rpt27 = new EPolicy2.Reports.PRMdic.ChargeEng((EPolicy.TaskControl.Policy)taskControl);
                                    rpt27.Document.Printer.PrinterName = "";
                                    rpt27.Run(false);
                                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt27.Document.Pages);
                                }

                                taskControl.PrintPolicy = true;
                                taskControl.PrintDate = DateTime.Now.ToShortDateString();
                                taskControl.Mode = 2;
                                FillProperties();
                                History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY.");
                                taskControl.SaveOnlyPolicy(userID);

                                
                                DataDynamics.ActiveReports.ActiveReport3 rptNew = rpt;

                                string _FileName = ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                                ExportFile expFile = new ExportFile();

                                List<string> mergePaths = new List<string>();

                                _FileName = _FileName + taskControl.PolicyType + taskControl.PolicyNo + ".pdf";

                                expFile.ExportToPDF(rptNew.Document, _FileName);

                                PrintNewEndorsement(_FileName, true);

                                //RemoveSessionLookUp();
                                //Session.Add("Report", rpt);
                                //Session.Add("TaskControl", taskControl);
                                //Session.Add("FromPage", "CorporatePolicyQuote.aspx");
                                //Response.Redirect("ActiveXViewer.aspx");

                            }
                            else //Print Policy Lock
                            {
                                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy Printing has been disabled.  Please contact your supervisor.");
                                this.litPopUp.Visible = true;
                            }
                        #endregion
                        }

                        else //Renovacion.
                        {
                            #region Primary Renovation
                            if (!taskControl.PrintPolicy) //Proof that the renovation was printed.
                            {
                                DataDynamics.ActiveReports.ActiveReport3 rpt = null;
                                DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;
                                DataDynamics.ActiveReports.ActiveReport3 rpt3 = null;
                                DataDynamics.ActiveReports.ActiveReport3 rpt4 = null;

                                rpt = new EPolicy2.Reports.PRMdic.Invoice(taskControl, false);
                                rpt.Document.Printer.PrinterName = "";
                                rpt.Run(false);

                                rpt2 = new EPolicy2.Reports.PRMdic.RenewalEndorsement((EPolicy.TaskControl.Policy)taskControl, DtGridCorpaoratePol.Items.Count, limit);
                                rpt2.Document.Printer.PrinterName = "";
                                rpt2.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages);

                                if (taskControl.Charge > 0)//(TxtCharge.Text != ".00")
                                {
                                    rpt3 = new EPolicy2.Reports.PRMdic.ChargeEng((EPolicy.TaskControl.Policy)taskControl);
                                    rpt3.Document.Printer.PrinterName = "";
                                    rpt3.Run(false);
                                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages);
                                }

                                if (DateTime.Parse(taskControl.EffectiveDate.Trim()) > DateTime.Parse("08/01/2015") && DateTime.Parse(taskControl.EffectiveDate.Trim()) < DateTime.Parse("08/01/2016"))
                                {
                                    rpt4 = new EPolicy2.Reports.PRMdic.P_116New(taskControl);
                                    rpt4.Document.Printer.PrinterName = "";
                                    rpt4.Run();
                                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt4.Document.Pages);
                                }

                                taskControl.PrintPolicy = true;
                                taskControl.PrintDate = DateTime.Now.ToShortDateString();
                                FillProperties();
                                taskControl.SaveOnlyPolicy(userID);


                                History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY RENOVATION DOCUMENT.");

                                ExportFileFromActiveXViewer(rpt);

                                DataDynamics.ActiveReports.ActiveReport3 rptNew = rpt;
                                 
                                string _FileName = ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                				ExportFile expFile = new ExportFile();
                      
                                List<string> mergePaths = new List<string>();
                          
                               // string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                                //_FileName =_FileName + taskControl.PolicyType.ToString() + taskControl.PolicyNo + ".PDF";

                                _FileName = _FileName + userName.ToString().Replace(" ", "") + "-" + taskControl.TaskControlID.ToString() + ".PDF"; 
                                //expFile.ExportToPDF(rptNew.Document, _FileName);
                                
                                PrintNewEndorsement(_FileName, false);
                                
                                //RemoveSessionLookUp();
                                //Session.Add("Report", rpt);
                                //Session.Add("FromPage", "CorporatePolicyQuote.aspx");
                                //Response.Redirect("ActiveXViewer.aspx");

                            }
                            else //Print Policy Lock
                            {
                                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy Printing has been disabled.  Please contact your supervisor.");
                                this.litPopUp.Visible = true;
                            }
                            #endregion
                        }
                    }
                    else if (taskControl.PolicyType.Trim() == "CPT")
                    {
                        #region Primary Tail
                        DataDynamics.ActiveReports.ActiveReport3 rpt = null;

                        rpt = new EPolicy2.Reports.PRMdic.TailEndorsement((EPolicy.TaskControl.Policy)taskControl);
                        rpt.Document.Printer.PrinterName = "";
                        rpt.Run(false);

                        History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED TAIL ENDORSEMENT.");

                        RemoveSessionLookUp();
                        Session.Add("Report", rpt);
                        Session.Add("FromPage", "CorporatePolicyQuote.aspx");
                        Response.Redirect("ActiveXViewer.aspx");
                        #endregion
                    }
                    else if (taskControl.PolicyType.Trim() == "CE")//CE
                    {
                        if (taskControl.Anniversary == "01")
                        {
                            #region Excess Policy
                            if (!taskControl.PrintPolicy && DateTime.Parse(taskControl.EffectiveDate.Trim()) < DateTime.Parse("08/01/2015"))// && prmdicAdmin)
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

                                rpt1 = new EPolicy2.Reports.PRMdic.Poliza((EPolicy.TaskControl.Policy)taskControl); //este 
                                rpt1.Document.Printer.PrinterName = "";
                                rpt1.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt1.Document.Pages);

                                rpt2 = new EPolicy2.Reports.PRMdic.Poliza1((EPolicy.TaskControl.Policy)taskControl, false, taskControl.PrMedicalLimit);
                                rpt2.Document.Printer.PrinterName = "";
                                rpt2.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages);

                                rpt26 = new EPolicy2.Reports.PRMdic.Poliza2B((EPolicy.TaskControl.Policy)taskControl, false);
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

                                rpt20 = new EPolicy2.Reports.PRMdic.Poliza19((EPolicy.TaskControl.Policy)taskControl);//
                                rpt20.Document.Printer.PrinterName = "";
                                rpt20.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt20.Document.Pages);

                                rpt30 = new EPolicy2.Reports.PRMdic.SchedulerEndorsement((EPolicy.TaskControl.Policy)taskControl, false); //Scheduler of Endorsement
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

                                rpt21 = new EPolicy2.Reports.PRMdic.ActOfWar((EPolicy.TaskControl.Policy)taskControl);
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
                                    rpt29 = new EPolicy2.Reports.PRMdic.PriorAct((EPolicy.TaskControl.Policy)taskControl, false);
                                    rpt29.Document.Printer.PrinterName = "";
                                    rpt29.Run(false);
                                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt29.Document.Pages);
                                }

                                if (taskControl.Charge > 0)//(TxtCharge.Text != ".00")
                                {
                                    rpt33 = new EPolicy2.Reports.PRMdic.ChargeEng((EPolicy.TaskControl.Policy)taskControl);
                                    rpt33.Document.Printer.PrinterName = "";
                                    rpt33.Run(false);
                                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt33.Document.Pages);
                                }

                                taskControl.PrintPolicy = true;
                                taskControl.PrintDate = DateTime.Now.ToShortDateString();
                                FillProperties();
                                History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY.");
                                taskControl.SaveOnlyPolicy(userID);

                                //Export Report CEE-102 Exclusion 2
                                DataDynamics.ActiveReports.ActiveReport3 rptNew = rpt;

                                string _FileName = ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                                ExportFile expFile = new ExportFile();

                                List<string> mergePaths = new List<string>();

                                // string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                                _FileName = _FileName + taskControl.PolicyType + taskControl.PolicyNo + ".PDF";

                                //string _NameFile = taskControl.PolicyType + taskControl.PolicyNo + ".PDF";

                                expFile.ExportToPDF(rptNew.Document, _FileName);

                                PrintNewEndorsement(_FileName, false);


                                //RemoveSessionLookUp();
                                //Session.Add("Report", rpt);
                                //Session.Add("FromPage", "CorporatePolicyQuote.aspx");
                                //Response.Redirect("ActiveXViewer.aspx");
                            }
                            else if (!taskControl.PrintPolicy && DateTime.Parse(taskControl.EffectiveDate.Trim()) >= DateTime.Parse("08/01/2015"))
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

                                rpt = new EPolicy2.Reports.PRMdic.Invoice(taskControl, false);
                                rpt.Document.Printer.PrinterName = "";
                                rpt.Run(false);

                                rpt1 = new EPolicy2.Reports2.PRMdic.PolizaNew();
                                rpt1.Document.Printer.PrinterName = "";
                                rpt1.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt1.Document.Pages); ;

                                rpt2 = new EPolicy2.Reports.PRMdic.Poliza1(taskControl, false, taskControl.PrMedicalLimit);
                                rpt2.Document.Printer.PrinterName = "";
                                rpt2.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages);

                                rpt3 = new EPolicy2.Reports.PRMdic.Poliza2B(taskControl, false);
                                rpt3.Document.Printer.PrinterName = "";
                                rpt3.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages);

                                //rpt3 = new EPolicy2.Reports.PRMdic.Poliza2(taskControl);
                                //rpt3.Document.Printer.PrinterName = "";
                                //rpt3.Run(false);
                                //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages);

                                rpt4 = new EPolicy2.Reports2.PRMdic.PolizaNew3();
                                rpt4.Document.Printer.PrinterName = "";
                                rpt4.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt4.Document.Pages);

                                rpt5 = new EPolicy2.Reports2.PRMdic.PolizaNew4();
                                rpt5.Document.Printer.PrinterName = "";
                                rpt5.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt5.Document.Pages);

                                rpt6 = new EPolicy2.Reports2.PRMdic.PolizaNew5();
                                rpt6.Document.Printer.PrinterName = "";
                                rpt6.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt6.Document.Pages);

                                rpt7 = new EPolicy2.Reports2.PRMdic.PolizaNew6();
                                rpt7.Document.Printer.PrinterName = "";
                                rpt7.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt7.Document.Pages);

                                rpt8 = new EPolicy2.Reports2.PRMdic.PolizaNew7();
                                rpt8.Document.Printer.PrinterName = "";
                                rpt8.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt8.Document.Pages);

                                rpt9 = new EPolicy2.Reports2.PRMdic.PolizaNew8();
                                rpt9.Document.Printer.PrinterName = "";
                                rpt9.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt9.Document.Pages);

                                rpt10 = new EPolicy2.Reports2.PRMdic.PolizaNew9();
                                rpt10.Document.Printer.PrinterName = "";
                                rpt10.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt10.Document.Pages);

                                rpt11 = new EPolicy2.Reports2.PRMdic.PolizaNew10();
                                rpt11.Document.Printer.PrinterName = "";
                                rpt11.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt11.Document.Pages);

                                rpt12 = new EPolicy2.Reports2.PRMdic.PolizaNew11();
                                rpt12.Document.Printer.PrinterName = "";
                                rpt12.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt12.Document.Pages);

                                rpt13 = new EPolicy2.Reports2.PRMdic.PolizaNew12();
                                rpt13.Document.Printer.PrinterName = "";
                                rpt13.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt13.Document.Pages);

                                rpt14 = new EPolicy2.Reports2.PRMdic.PolizaNew13();
                                rpt14.Document.Printer.PrinterName = "";
                                rpt14.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt14.Document.Pages);

                                rpt15 = new EPolicy2.Reports2.PRMdic.PolizaNew14();
                                rpt15.Document.Printer.PrinterName = "";
                                rpt15.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt15.Document.Pages);

                                rpt16 = new EPolicy2.Reports2.PRMdic.PolizaNew15();
                                rpt16.Document.Printer.PrinterName = "";
                                rpt16.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt16.Document.Pages);

                                rpt17 = new EPolicy2.Reports2.PRMdic.PolizaNew16();
                                rpt17.Document.Printer.PrinterName = "";
                                rpt17.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt17.Document.Pages);

                                rpt18 = new EPolicy2.Reports2.PRMdic.PolizaNew17();
                                rpt18.Document.Printer.PrinterName = "";
                                rpt18.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt18.Document.Pages);

                                rpt19 = new EPolicy2.Reports2.PRMdic.PolizaNew18((EPolicy.TaskControl.Policy)taskControl);
                                rpt19.Document.Printer.PrinterName = "";
                                rpt19.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt19.Document.Pages);

                                rpt20 = new EPolicy2.Reports.PRMdic.SchedulerEndorsement(taskControl, false); //Scheduler of Endorsement
                                rpt20.Document.Printer.PrinterName = "";
                                rpt20.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt20.Document.Pages);

                                rpt21 = new EPolicy2.Reports.PRMdic.StatementAcceptance((EPolicy.TaskControl.Policy)taskControl, false);//StatementOfRepe.And Acceptance
                                rpt21.Document.Printer.PrinterName = "";
                                rpt21.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt21.Document.Pages);

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

                                rpt26 = new EPolicy2.Reports.PRMdic.ActOfWar((EPolicy.TaskControl.Policy)taskControl);
                                rpt26.Document.Printer.PrinterName = "";
                                rpt26.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt26.Document.Pages);

                                rpt27 = new EPolicy2.Reports.PRMdic.NuclearEnergy();
                                rpt27.Document.Printer.PrinterName = "";
                                rpt27.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt27.Document.Pages);

                                rpt28 = new EPolicy2.Reports.PRMdic.NuclearEnergy2();
                                rpt28.Document.Printer.PrinterName = "";
                                rpt28.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt28.Document.Pages);

                                if (DateTime.Parse(taskControl.EffectiveDate.Trim()).ToShortDateString() != DateTime.Parse(taskControl.RetroactiveDate.Trim()).ToShortDateString())
                                {
                                    rpt29 = new EPolicy2.Reports.PRMdic.PriorAct(taskControl, false);
                                    rpt29.Document.Printer.PrinterName = "";
                                    rpt29.Run(false);
                                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt29.Document.Pages); //Page 3
                                }

                                if (taskControl.Charge > 0)//(TxtCharge.Text != ".00")
                                {
                                    rpt30 = new EPolicy2.Reports.PRMdic.ChargeEng((EPolicy.TaskControl.Policy)taskControl);
                                    rpt30.Document.Printer.PrinterName = "";
                                    rpt30.Run(false);
                                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt30.Document.Pages);
                                }

                                taskControl.PrintPolicy = true;
                                taskControl.PrintDate = DateTime.Now.ToShortDateString();
                                taskControl.Mode = 2;
                                FillProperties();

                                History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY.");
                                taskControl.SaveOnlyPolicy(userID);

                                //Export Report CEE-102 Exclusion 2 >= 8/1/2015
                                DataDynamics.ActiveReports.ActiveReport3 rptNew = rpt;

                                string _FileName = ConfigurationSettings.AppSettings["ExportsFilesPathName"];
                                ExportFile expFile = new ExportFile();
                                List<string> mergePaths = new List<string>();
                                _FileName = _FileName + taskControl.PolicyType + taskControl.PolicyNo + ".PDF";
                                expFile.ExportToPDF(rptNew.Document, _FileName);
                                PrintNewEndorsement(_FileName, false);


                                //RemoveSessionLookUp();
                                //Session.Add("Report", rpt);
                                //Session.Add("TaskControl", taskControl);
                                //Session.Add("FromPage", "CorporatePolicyQuote.aspx");
                                //Response.Redirect("ActiveXViewer.aspx");
                            }
                            else //Print Policy Lock
                            {
                                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy Printing has been disabled.  Please contact your supervisor.");
                                this.litPopUp.Visible = true;
                            }
                            #endregion
                        }

                        else if (taskControl.PolicyType.Trim() == "CET")
                        {
                            #region Excess Tail
                            DataDynamics.ActiveReports.ActiveReport3 rpt = null;

                            rpt = new EPolicy2.Reports.PRMdic.TailEndorsement((EPolicy.TaskControl.Policy)taskControl);
                            rpt.Document.Printer.PrinterName = "";
                            rpt.Run(false);

                            RemoveSessionLookUp();
                            Session.Add("Report", rpt);
                            Session.Add("FromPage", "CorporatePolicyQuote.aspx");
                            Response.Redirect("ActiveXViewer.aspx");
                            #endregion
                        }

                        else //Renovacion.
                        {
                            #region Excess Renovation
                            if (!taskControl.PrintPolicy) //Proof that the renovation was printed.
                            {
                                DataDynamics.ActiveReports.ActiveReport3 rpt = null;
                                DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;
                                DataDynamics.ActiveReports.ActiveReport3 rpt3 = null;
                                DataDynamics.ActiveReports.ActiveReport3 rpt4 = null;

                                rpt = new EPolicy2.Reports.PRMdic.Invoice(taskControl, false);
                                rpt.Document.Printer.PrinterName = "";
                                rpt.Run(false);

                                rpt2 = new EPolicy2.Reports.PRMdic.RenewalEndorsement((EPolicy.TaskControl.Policy)taskControl, DtGridCorpaoratePol.Items.Count, limit);
                                rpt2.Document.Printer.PrinterName = "";
                                rpt2.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages);

                                if (taskControl.Charge > 0)//(TxtCharge.Text != ".00")
                                {
                                    rpt3 = new EPolicy2.Reports.PRMdic.ChargeEng((EPolicy.TaskControl.Policy)taskControl);
                                    rpt3.Document.Printer.PrinterName = "";
                                    rpt3.Run(false);
                                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages);
                                }

                                if (DateTime.Parse(taskControl.EffectiveDate.Trim()) > DateTime.Parse("08/01/2015") && DateTime.Parse(taskControl.EffectiveDate.Trim()) < DateTime.Parse("08/01/2016"))
                                {
                                    rpt4 = new EPolicy2.Reports.PRMdic.P_116New(taskControl);
                                    rpt4.Document.Printer.PrinterName = "";
                                    rpt4.Run();
                                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt4.Document.Pages);
                                }

                                taskControl.PrintPolicy = true;
                                taskControl.PrintDate = DateTime.Now.ToShortDateString();
                                FillProperties();
                                taskControl.SaveOnlyPolicy(userID);


                                History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY RENOVATION DOCUMENT.");

                                ExportFileFromActiveXViewer(rpt);

                                DataDynamics.ActiveReports.ActiveReport3 rptNew = rpt;

                                string _FileName = ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                                ExportFile expFile = new ExportFile();

                                List<string> mergePaths = new List<string>();

                                // string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                                //_FileName =_FileName + taskControl.PolicyType.ToString() + taskControl.PolicyNo + ".PDF";

                                _FileName = _FileName + userName.ToString().Replace(" ", "") + "-" + taskControl.TaskControlID.ToString() + ".PDF";
                                //expFile.ExportToPDF(rptNew.Document, _FileName);

                                PrintNewEndorsement(_FileName, false);

                                //RemoveSessionLookUp();
                                //Session.Add("Report", rpt);
                                //Session.Add("FromPage", "CorporatePolicyQuote.aspx");
                                //Response.Redirect("ActiveXViewer.aspx");

                            }
                            else //Print Policy Lock
                            {
                                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy Printing has been disabled.  Please contact your supervisor.");
                                this.litPopUp.Visible = true;
                            }
                            //if (!taskControl.PrintPolicy) //Proof that the renovation was printed.
                            //{
                            //    DataDynamics.ActiveReports.ActiveReport3 rpt = null;
                            //    DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;
                            //    //DataDynamics.ActiveReports.ActiveReport3 rpt3 = null;
                            //    DataDynamics.ActiveReports.ActiveReport3 rpt4 = null;
                            //    DataDynamics.ActiveReports.ActiveReport3 rpt5 = null;

                            //    rpt = new EPolicy2.Reports.PRMdic.Invoice(taskControl, false);
                            //    rpt.Document.Printer.PrinterName = "";
                            //    rpt.Run(false);


                            //    rpt2 = new EPolicy2.Reports.PRMdic.RenewalEndorsement((EPolicy.TaskControl.Policy)taskControl, DtGridCorpaoratePol.Items.Count, limit);
                            //    rpt2.Document.Printer.PrinterName = "";
                            //    rpt2.Run();
                            //    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages);

                            //    //if (taskControl.EffectiveDate.Trim() != taskControl.RetroactiveDate.Trim())
                            //    //{
                            //    //    rpt3 = new EPolicy2.Reports.PRMdic.PriorAct((EPolicy.TaskControl.Policy)taskControl);
                            //    //    rpt3.Document.Printer.PrinterName = "";
                            //    //    rpt3.Run(false);
                            //    //    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages);
                            //    //}

                            //    if (taskControl.Charge > 0)//(TxtCharge.Text != ".00")
                            //    {
                            //        rpt4 = new EPolicy2.Reports.PRMdic.ChargeEng((EPolicy.TaskControl.Policy)taskControl);
                            //        rpt4.Document.Printer.PrinterName = "";
                            //        rpt4.Run(false);
                            //        rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt4.Document.Pages);
                            //    }

                            //    if (DateTime.Parse(taskControl.EffectiveDate.Trim()) > DateTime.Parse("08/01/2015") && DateTime.Parse(taskControl.EffectiveDate.Trim()) < DateTime.Parse("08/01/2016"))
                            //    {
                            //        rpt5 = new EPolicy2.Reports.PRMdic.E_116New(taskControl);
                            //        rpt5.Document.Printer.PrinterName = "";
                            //        rpt5.Run();
                            //        rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt5.Document.Pages);
                            //    }

                            //    taskControl.PrintPolicy = true;
                            //    taskControl.PrintDate = DateTime.Now.ToShortDateString();
                            //    FillProperties();
                            //    History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY.");
                                
                            //    taskControl.SaveOnlyPolicy(userID);
                                                                
                            //    RemoveSessionLookUp();
                            //    Session.Add("Report", rpt);
                            //    Session.Add("FromPage", "CorporatePolicyQuote.aspx");
                            //    Response.Redirect("ActiveXViewer.aspx");
                            //}
                            //else //Print Policy Lock
                            //{
                            //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy Printing has been disabled.  Please contact your supervisor.");
                            //    this.litPopUp.Visible = true;
                            //}
                            #endregion
                        }
                    }

                    else if (taskControl.PolicyType.Trim() == "APC")
                    {
                        if (taskControl.Anniversary == "01")
                        {
                            #region Primary Policy ASPEN
                            if (!taskControl.PrintPolicy)//&& prmdicAdmin)
                            {
                                List<string> mergePaths = new List<string>();
                                string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                                DataDynamics.ActiveReports.ActiveReport3 rpt = null;
                                DataDynamics.ActiveReports.ActiveReport3 rpt1 = null;
                                DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;
                                EPolicy2.Reports.ExportFile expFile = new EPolicy2.Reports.ExportFile();
                                string _FileName = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                                rpt2 = new EPolicy2.Reports.PRMdic.Invoice((EPolicy.TaskControl.Policy)taskControl, false);
                                rpt2.Document.Printer.PrinterName = "";
                                rpt2.Run(false);

                                rpt = new EPolicy2.Reports.PRMdic.PrimaryPolicy1((EPolicy.TaskControl.Policy)taskControl, false);
                                rpt.Document.Printer.PrinterName = "";
                                rpt.Run(false); //Page 1

                                rpt1 = new EPolicy2.Reports.PRMdic.PrimaryPolicy2((EPolicy.TaskControl.Policy)taskControl, false);
                                rpt1.Document.Printer.PrinterName = "";
                                rpt1.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt1.Document.Pages); //Page 2

                                _FileName = _FileName + userName + ".PDF";
                                string invoice = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + "Invoice" + taskControl.TaskControlID + ".pdf";
                                expFile.ExportToPDF(rpt.Document, _FileName);
                                expFile.ExportToPDF(rpt2.Document, invoice);

                                mergePaths.Add(invoice);
                                mergePaths.Add(PrintAspenPolicy("Primary1.rdlc"));
                                mergePaths.Add(_FileName);
                                mergePaths.Add(PrintAspenPolicy("Primary2.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Primary3.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Primary4.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Primary5.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Primary6.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Primary7.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Primary8.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Primary9.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Primary10.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Primary11.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Primary12.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Primary13.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Primary14.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("SCHEDULE OF ENDORSEMENTS.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("STATEMENT OF REPRESENTATIONS AND ACCEPTANCE.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("MANDATORY PREMIUM AND COVERAGE CONDITIONS ENDORSEMENT 1.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("MANDATORY PREMIUM AND COVERAGE CONDITIONS ENDORSEMENT 2.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("MANDATORY PREMIUM AND COVERAGE CONDITIONS ENDORSEMENT 3.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("CONTINUOUS RENEWAL ENDORSEMENT.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("ACTS OF WAR - TERRORISM EXCLUSION.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("NUCLEAR ENERGY EXCLUSION 1.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("NUCLEAR ENERGY EXCLUSION 2.rdlc"));

                                if (DateTime.Parse(taskControl.EffectiveDate.Trim()).ToShortDateString() != DateTime.Parse(taskControl.RetroactiveDate.Trim()).ToShortDateString())
                                    mergePaths.Add(PrintAspenPolicy("PRIOR ACTS ENDORSEMENT.rdlc"));

                                CreatePDFBatch mergeFinal = new CreatePDFBatch();
                                string FinalFile = "";
                                FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl.Customer.FirstName + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2);

                                taskControl.PrintPolicy = true;
                                taskControl.PrintDate = DateTime.Now.ToShortDateString();
                                taskControl.Mode = 2;
                                FillProperties();
                                History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY.");
                                taskControl.SaveOnlyPolicy(userID);

                                RemoveSessionLookUp();
                                //Session.Add("Report", rpt);
                                //Session.Add("TaskControl", taskControl);
                                //Session.Add("FromPage", "Policies.aspx");
                                //Response.Redirect("ActiveXViewer.aspx");

                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                            }
                            else //Print Policy Lock
                            {
                                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy Printing has been disabled.  Please contact your supervisor.");
                                this.litPopUp.Visible = true;
                            }
                            #endregion
                        }
                        else //Renovacion.
                        {
                            #region Primary Renovation ASPEN
                            if (!taskControl.PrintPolicy) //Proof that the renovation was printed.
                            {
                                DataDynamics.ActiveReports.ActiveReport3 rpt = null;
                                DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;
                                DataDynamics.ActiveReports.ActiveReport3 rpt3 = null;

                                rpt = new EPolicy2.Reports.PRMdic.Invoice(taskControl, false);
                                rpt.Document.Printer.PrinterName = "";
                                rpt.Run(false);


                                rpt2 = new EPolicy2.Reports.PRMdic.RenewalEndorsement(taskControl, 0, limit);
                                rpt2.Document.Printer.PrinterName = "";
                                rpt2.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages);

                                if (taskControl.Charge > 0)//(TxtCharge.Text != ".00")
                                {
                                    rpt3 = new EPolicy2.Reports.PRMdic.ChargeEng((EPolicy.TaskControl.Policy)taskControl);
                                    rpt3.Document.Printer.PrinterName = "";
                                    rpt3.Run(false);
                                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages);
                                }


                                taskControl.PrintPolicy = true;
                                taskControl.PrintDate = DateTime.Now.ToShortDateString();
                                //taskControl.Mode = 2;
                                FillProperties();
                                taskControl.SaveOnlyPolicy(userID);

                                History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY RENOVATION DOCUMENT.");


                                RemoveSessionLookUp();
                                Session.Add("Report", rpt);
                                Session.Add("TaskControl", taskControl);
                                Session.Add("Renewal", true);
                                Session.Add("FromPage", "CorporatePolicyQuote.aspx");
                                Response.Redirect("ActiveXViewer.aspx?true");
                            }
                            else //Print Policy Lock
                            {
                                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy Printing has been disabled.  Please contact your supervisor.");
                                this.litPopUp.Visible = true;
                            }
                            #endregion
                        }
                    }
                    else if (taskControl.PolicyType.Trim() == "APCT")
                    {
                        #region Primary Tail ASPEN
                        DataDynamics.ActiveReports.ActiveReport3 rpt = null;

                        rpt = new EPolicy2.Reports.PRMdic.TailEndorsement((EPolicy.TaskControl.Policy)taskControl);
                        rpt.Document.Printer.PrinterName = "";
                        rpt.Run(false);

                        RemoveSessionLookUp();
                        Session.Add("Report", rpt);
                        Session.Add("TaskControl", taskControl);
                        Session.Add("FromPage", "CorporatePolicyQuote.aspx");
                        Response.Redirect("ActiveXViewer.aspx");

                        History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED TAIL ENDORSEMENT.");
                        #endregion
                    }

                    else if (taskControl.PolicyType.Trim() == "AEC")//PE
                    {
                        if (taskControl.Anniversary == "01")
                        {
                            #region Excess Policy ASPEN
                            if (!taskControl.PrintPolicy)//&& prmdicAdmin)
                            {
                                List<string> mergePaths = new List<string>();
                                string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                                DataDynamics.ActiveReports.ActiveReport3 rpt = null;
                                DataDynamics.ActiveReports.ActiveReport3 rpt1 = null;
                                DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;
                                EPolicy2.Reports.ExportFile expFile = new EPolicy2.Reports.ExportFile();
                                string _FileName = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];


                                rpt2 = new EPolicy2.Reports.PRMdic.Invoice((EPolicy.TaskControl.Policy)taskControl, false);
                                rpt2.Document.Printer.PrinterName = "";
                                rpt2.Run(false); //Invoice

                                rpt = new EPolicy2.Reports.PRMdic.Poliza1((EPolicy.TaskControl.Policy)taskControl, false, taskControl.PrMedicalLimit);
                                rpt.Document.Printer.PrinterName = "";
                                rpt.Run(false); //Page 1

                                rpt1 = new EPolicy2.Reports.PRMdic.Poliza2B((EPolicy.TaskControl.Policy)taskControl, false);
                                rpt1.Document.Printer.PrinterName = "";
                                rpt1.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt1.Document.Pages); //Page 2

                                _FileName = _FileName + userName + ".PDF";
                                string invoice = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + "Invoice" + taskControl.TaskControlID + ".pdf";
                                expFile.ExportToPDF(rpt.Document, _FileName);
                                expFile.ExportToPDF(rpt2.Document, invoice);

                                mergePaths.Add(invoice);
                                mergePaths.Add(PrintAspenPolicy("Excess1.rdlc"));
                                mergePaths.Add(_FileName);
                                mergePaths.Add(PrintAspenPolicy("Excess2.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Excess3.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Excess4.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Excess5.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Excess6.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Excess7.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Excess8.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Excess9.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Excess10.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Excess11.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Excess12.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Excess13.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Excess14.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Excess15.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("Excess16.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("SCHEDULE OF ENDORSEMENTS.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("STATEMENT OF REPRESENTATIONS AND ACCEPTANCE.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("CONTINUOUS RENEWAL ENDORSEMENT.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("MANDATORY PREMIUM AND COVERAGE CONDITIONS ENDORSEMENT 1.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("MANDATORY PREMIUM AND COVERAGE CONDITIONS ENDORSEMENT 2.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("MANDATORY PREMIUM AND COVERAGE CONDITIONS ENDORSEMENT 3.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("ACTS OF WAR - TERRORISM EXCLUSION.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("NUCLEAR ENERGY EXCLUSION 1.rdlc"));
                                mergePaths.Add(PrintAspenPolicy("NUCLEAR ENERGY EXCLUSION 2.rdlc"));

                                if (DateTime.Parse(taskControl.EffectiveDate.Trim()).ToShortDateString() != DateTime.Parse(taskControl.RetroactiveDate.Trim()).ToShortDateString())
                                    mergePaths.Add(PrintAspenPolicy("PRIOR ACTS ENDORSEMENT.rdlc"));

                                CreatePDFBatch mergeFinal = new CreatePDFBatch();
                                string FinalFile = "";
                                FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl.Customer.FirstName + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2);

                                taskControl.PrintPolicy = true;
                                taskControl.PrintDate = DateTime.Now.ToShortDateString();
                                taskControl.Mode = 2;
                                FillProperties();
                                History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY.");
                                taskControl.SaveOnlyPolicy(userID);

                                RemoveSessionLookUp();
                                //Session.Add("Report", rpt);
                                //Session.Add("TaskControl", taskControl);
                                //Session.Add("FromPage", "Policies.aspx");
                                //Response.Redirect("ActiveXViewer.aspx");

                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                            }
                            else //Print Policy Lock
                            {
                                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy Printing has been disabled.  Please contact your supervisor.");
                                this.litPopUp.Visible = true;
                            }
                            #endregion
                        }
                        else //Renovacion.
                        {
                            #region Excess Renovation ASPEN
                            if (!taskControl.PrintPolicy) //Proof that the renovation was printed.
                            {
                                DataDynamics.ActiveReports.ActiveReport3 rpt = null;
                                DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;
                                DataDynamics.ActiveReports.ActiveReport3 rpt3 = null;


                                rpt = new EPolicy2.Reports.PRMdic.Invoice(taskControl, false);
                                rpt.Document.Printer.PrinterName = "";
                                rpt.Run(false);

                                rpt2 = new EPolicy2.Reports.PRMdic.RenewalEndorsement(taskControl, 0, limit);
                                rpt2.Document.Printer.PrinterName = "";
                                rpt2.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages);

                                if (taskControl.Charge > 0)//(TxtCharge.Text != ".00")
                                {
                                    rpt3 = new EPolicy2.Reports.PRMdic.ChargeEng((EPolicy.TaskControl.Policy)taskControl);
                                    rpt3.Document.Printer.PrinterName = "";
                                    rpt3.Run(false);
                                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages);
                                }

                                taskControl.PrintPolicy = true;
                                taskControl.PrintDate = DateTime.Now.ToShortDateString();
                                //taskControl.Mode = 2;
                                FillProperties();
                                taskControl.SaveOnlyPolicy(userID);

                                History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY RENOVATION DOCUMENT.");

                                RemoveSessionLookUp();
                                Session.Add("Report", rpt);
                                Session.Add("TaskControl", taskControl);
                                Session.Add("Renewal", true);
                                Session.Add("FromPage", "CorporatePolicyQuote.aspx");
                                Response.Redirect("ActiveXViewer.aspx?true");
                            }
                            else //Print Policy Lock
                            {
                                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy Printing has been disabled.  Please contact your supervisor.");
                                this.litPopUp.Visible = true;
                            }
                            #endregion
                        }
                    }
                    else if (taskControl.PolicyType.Trim() == "AECT")
                    {
                        #region Excess Tail ASPEN
                        DataDynamics.ActiveReports.ActiveReport3 rpt = null;

                        rpt = new EPolicy2.Reports.PRMdic.TailEndorsement((EPolicy.TaskControl.Policy)taskControl);
                        rpt.Document.Printer.PrinterName = "";
                        rpt.Run(false);

                        RemoveSessionLookUp();
                        Session.Add("Report", rpt);
                        Session.Add("TaskControl", taskControl);
                        Session.Add("FromPage", "CorporatePolicyQuote.aspx");
                        Response.Redirect("ActiveXViewer.aspx");

                        History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED TAIL ENDORSEMENT.");
                        #endregion
                    }
                }
                    else
                    {
                        if (DtGridCorpaoratePol.Items.Count > 0)
                        {
                            ObtainTotalPremiumsForReport();

                            string specialty = DtGridCorpaoratePol.Items[0].Cells[5].Text.Trim();
                            string isoCode = DtGridCorpaoratePol.Items[0].Cells[6].Text.Trim();

                            if (ddlGroup2.SelectedIndex != 0) //Bank = Group
                            {
                                EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                                master = master.GetMasterPolicyDiscount(ddlGroup2.SelectedValue, DateTime.Now.ToShortDateString());

                                txtERate150_200.Text = Math.Round(double.Parse(txtERate150_200.Text) - (double.Parse(txtERate150_200.Text) * (master.DescuentoPrimario / 100)), 0).ToString();
                                txtERate1M_3M.Text = Math.Round(double.Parse(txtERate1M_3M.Text) - (double.Parse(txtERate1M_3M.Text) * (master.DescuentoPrimario / 100)), 0).ToString();
                                txtERate250_500.Text = Math.Round(double.Parse(txtERate250_500.Text) - (double.Parse(txtERate250_500.Text) * (master.DescuentoPrimario / 100)), 0).ToString();
                                txtERate400_700.Text = Math.Round(double.Parse(txtERate400_700.Text) - (double.Parse(txtERate400_700.Text) * (master.DescuentoPrimario / 100)), 0).ToString();
                                txtERate500_1M.Text = Math.Round(double.Parse(txtERate500_1M.Text) - (double.Parse(txtERate500_1M.Text) * (master.DescuentoPrimario / 100)), 0).ToString();
                                txtPRate.Text = Math.Round(double.Parse(txtPRate.Text) - (double.Parse(txtPRate.Text) * (master.DescuentoPrimario / 100)), 0).ToString();
                            }

                            DataDynamics.ActiveReports.ActiveReport3 rpt = new EPolicy2.Reports.PRMdic.CorporateQuotes(taskControl, txtERate150_200.Text,
                                txtERate1M_3M.Text, txtERate250_500.Text, txtERate400_700.Text, txtERate500_1M.Text,
                                txtPRate.Text, txtTotPremTN6.Text, txtETotPremTN6.Text, txtDiscountP.Text, txtDiscount.Text,
                                DtGridCorpaoratePol.Items.Count, specialty, isoCode);
                            rpt.Document.Printer.PrinterName = "";
                            rpt.Run(false);

                            RemoveSessionLookUp();
                            Session.Add("Report", rpt);
                            Session.Add("FromPage", "CorporatePolicyQuote.aspx");
                            Response.Redirect("ActiveXViewer.aspx");

                            txtERate150_200.Text = "";
                            txtERate1M_3M.Text = "";
                            txtERate250_500.Text = "";
                            txtERate400_700.Text = "";
                            txtERate500_1M.Text = "";
                            txtPRate.Text = "";
                        }
                        else
                            throw new Exception();
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

               // if (exp.Message.ToString() == "The policy License has expired.") Alexis Polizas Expiradas
               // {
               //     this.litPopUp.Text = Utilities.MakeLiteralPopUpString("The policy License has expired.");
              //  }
               // else
                //{
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("A problem occured while generating the report.");
                //}
                this.litPopUp.Visible = true;
            }

            Login.Login cp1 = HttpContext.Current.User as Login.Login;
            if (!cp1.IsInRole("BTNENABLEPRINT") && !cp1.IsInRole("ADMINISTRATOR"))
            {
                this.btnEnablePrint.Visible = false;
            }
            else
            {
                this.btnEnablePrint.Visible = taskControl.PrintPolicy;
            }
        }

        private void ExportFileFromActiveXViewer(ActiveReport3 rpt)
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
            string _userID = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();
            string _file = _userID.ToString().Replace(" ", "");
            string _FileName = ConfigurationSettings.AppSettings["ExportsFilesPathName"];
            TaskControl.TaskControl taskControl = (TaskControl.TaskControl)Session["TaskControl"];
            TaskControl.Policy task = new TaskControl.Policy();

            if (taskControl != null)
                if (taskControl.TaskControlTypeID == 12 || taskControl.TaskControlTypeID == 18)
                    task = (TaskControl.Policy)Session["TaskControl"];

            _FileName = _FileName + _file;

            ActiveReport3 doc = rpt; //(ActiveReport3)Session["Report"];

            ExportFile expFile = new ExportFile();

                try
                {
                    List<string> mergePaths = new List<string>();
                    string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];


                    _FileName = _FileName + ".PDF";
                    expFile.ExportToPDF(doc.Document, _FileName);

                    if ((task.PolicyType.Trim() == "PP" || task.PolicyType.Trim() == "PE") && task.Anniversary != "01")
                    {
                        _FileName = PrintRegistryDocument(_FileName);
                    }


                    if (int.Parse(task.Suffix) > 0)
                    {
                        mergePaths.Add(_FileName);

                        if (task.InsuranceCompany != "002") //vira
                            mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + ImprimirCartaDeptDefensa());

                        if (task.Anniversary != "01")
                        {
                            //-------------------------------------------------
                            if (chkUpdateForm.Checked)
                            {
                                if (DateTime.Parse(task.EffectiveDate) >= DateTime.Parse("01/01/2015") && task.InsuranceCompany != "002")
                                {
                                    mergePaths.Add(imprimirF102B("F102BA"));
                                    mergePaths.Add(imprimirF102B("F102BB"));
                                    mergePaths.Add(imprimirF102B("F102BC"));
                                    mergePaths.Add(imprimirF102B("F102BD"));

                                    History(taskControl.TaskControlID, userID, "UPDATEFORM", "POLICIES", "PRINT POLICY & MARKED UPDATE FORM.");
                                }
                            }
                            
                        }

                        CreatePDFBatch mergeFinal = new CreatePDFBatch();
                        string FinalFile = "";
                        FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, _file + "-" + taskControl.TaskControlID.ToString());

                        FinalFile = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + FinalFile;

                        //if (isEmail)
                        //    SendEmail(FinalFile);
                        //else
                        //    DownLoadFile(FinalFile);
                    }
                    else
                    {
                        //if (isEmail)
                        //    SendEmail(_FileName);
                        //else
                        //    DownLoadFile(_FileName);
                    }
                }
                catch (Exception exp)
                {
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
                    this.litPopUp.Visible = true;
                    return;
                }


            //this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Export File Sucessffully...");
            //this.litPopUp.Visible = true;
            return;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
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
                EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
                ValidateFields();
                FillProperties();

                taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];

                if (!taskControl.isEndorsement)
                {
                    taskControl.SaveCorporatePolicy(userID);  //(userID);

                    if (taskControl.IsPolicy) //Si es poliza entra aqui
                    {
                        //Update Inception Payment Amount
                        UpdateInceptionPartialPayments(taskControl.TaskControlID, (taskControl.TotalPremium + taskControl.Charge));
                        //History(taskControl.TaskControlID, userID, "EDIT", "POLICIES", " ");
                    }
                }
                else //si es endoso entra aqui
                {
                    if (txtEndoEffDate.Text != "" && (DateTime.Parse(txtExpDt.Text) < DateTime.Parse(txtEndoEffDate.Text)))
                    {
                        int monthDiference = 0;
                        monthDiference = (DateTime.Parse(txtEndoEffDate.Text).Month - DateTime.Parse(txtEffDt.Text).Month) + 12 * (DateTime.Parse(txtEndoEffDate.Text).Year - DateTime.Parse(txtExpDt.Text).Year);
                        taskControl.Term = int.Parse(TxtTerm.Text) + monthDiference;
                    }
                    taskControl.Endoso = int.Parse(txtEndorsementNo.Text);
                    taskControl.SaveCorporatePolicy(userID);  //(userID);
                    //History(taskControl.TaskControlID, userID, "ADD", "ENDORSEMENT", " ");
                    if (taskControl.IsPolicy)
                    {
                        //Update Inception Payment Amount
                        UpdateInceptionPartialPayments(taskControl.TaskControlID, (taskControl.TotalPremium + taskControl.Charge));
                    }

                    //VerifyChanges(taskControl, userID);
                    AddEndorsement(taskControl.TaskControlID);
                    //History(taskControl.TaskControlID, userID, "ADD", "ENDORSEMENT", " ");

                    //ApplyEndorsement(taskControl, userID);
                    //Session["TaskControl"] = (TaskControl.Policies)Session["PLEndorsement"];
                    //taskControl = (TaskControl.Policies)Session["PLEndorsement"];
                    taskControl.isEndorsement = false;

                    FillTextControl();
                    FillGrid();
                    DisableControls();

                    Session.Remove("DtPolicyDetail");

                    //Session.Add("TaskControl",taskControl);
                    //Session.Remove("TaskControl");
                    Session["TaskControl"] = taskControl;

                    //if (pnlEndorsement.Visible)
                    //    pnlEndorsement.Visible = false;

                    //if (Panel3.Visible)
                    //    Panel3.Visible = false;

                    //if (Panel2.Visible)
                    //    Panel2.Visible = false;

                    //if (DataGridGroup.Visible)
                    //    DataGridGroup.Visible = false;

                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy endorsement information saved successfully.");
                    this.litPopUp.Visible = true;
                }
                Session["TaskControl"] = taskControl;

                FillTextControl();
                FillGrid();
                DisableControls();

                if (!taskControl.IsPolicy)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Quote Saved Successfully.");
                else
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy Saved Successfully.");

                this.litPopUp.Visible = true;
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }
        }
        private void ValidateFields()
        {
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            ArrayList errorMessages = new ArrayList();
            bool IsError = false;


            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = 0;
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

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
                if (this.txtCorporation.Text == "")
                {
                    errorMessages.Add("The Corporate Field is missing." + "\r\n");
                    IsError = true;
                }


                // 4/11/17 se comenta a peticion de Kayla Para poder salvar sin que tenga Physician - Alexis Rosado

                //if (this.txtTotalPrimaryPremium.Text.Trim() == "" || double.Parse(this.txtTotalPrimaryPremium.Text.Trim()) == 0)
                //{
                //    errorMessages.Add("You have to add at least at Physician to list." + "\r\n");
                //}

                if (this.txtTotalPrimaryCorporate.Text.Trim() == "" || double.Parse(this.txtTotalPrimaryCorporate.Text.Trim()) == 0)
                {
                    errorMessages.Add("Yor have to calculate or Verify the fileds. " + "\r\n");
                }

                if (taskControl.IsPolicy)
                {
                    if (ddlAgency.SelectedItem.Value.Trim() == "")
                        errorMessages.Add("Please choose a agency." + "\r\n");

                    if (ddlAgency.SelectedItem.Value.Trim() == "000")
                        errorMessages.Add("Please choose a agency." + "\r\n");

                    if (ddlAgent.SelectedItem.Value.Trim() == "")
                        errorMessages.Add("Please choose a agent." + "\r\n");

                    if (ddlAgent.SelectedItem.Value.Trim() == "000")
                        errorMessages.Add("Please choose a agent." + "\r\n");
                }
                if (taskControl.IsPolicy) //ard
                {
                    DtTaskPolicy = TaskControl.Policy.GetPolicies(taskControl.PolicyClassID, TxtPolicyType.Text.Trim(),
                        TxtPolicyNo.Text.Trim(), TxtCertificate.Text.Trim(), TxtSufijo.Text.Trim(),
                        "", "", userID); //ARD

                    if (DtTaskPolicy.Rows.Count > 0 && !taskControl.isEndorsement && taskControl.Mode == 1)
                        errorMessages.Add("Policy Number already exists." + "\r\n"); //ARD
                }
                //if (DtTaskPolicy.Rows.Count > 0)
                //    errorMessages.Add("Policy Number already exists." + "\r\n");

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
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
                Login.Login cp = HttpContext.Current.User as Login.Login;
                FillTextControl();
                taskControl.Mode = (int)EPolicy.TaskControl.TaskControl.TaskControlMode.UPDATE;

                if (!cp.IsInRole("ADMINISTRATOR") && !cp.IsInRole("SUBSCRIPTION"))
                {
                    this.TxtFirstName.Enabled = false;
                    this.TxtInitial.Enabled = false;
                    this.txtLastname1.Enabled = false;
                    this.txtLastname2.Enabled = false;
                }                              

                Session.Add("TaskControl", taskControl);
                EnableControls();
                pnlHistory.Visible = false;

                if (cp.IsInRole("BTNEDITENDORSEMENT"))
                {

                    dtEndorsement.Columns[9].Visible = true;
                    dtEndorsement.Columns[10].Visible = true;
                }
                if (cp.IsInRole("UPDATEFORM") && cp.IsInRole("UPDATEFORM"))
                {
                    this.chkUpdateForm.Enabled = true;
                    this.lblUpdateForm.Enabled = true;
                }
                else
                {
                    this.lblUpdateForm.Enabled = false;
                    this.chkUpdateForm.Enabled = false;
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
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Session.Clear();
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = new EPolicy.TaskControl.CorporatePolicyQuote(true);

            taskControl.Mode = 1; //ADD

            Session.Add("TaskControl", taskControl);

            Response.Redirect("CorporatePolicyQuote.aspx", false);
        }
        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
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

                if (taskControl.TaskControlID == 0) //ADD
                {
                    if (taskControl.isEndorsement)
                    {
                        TaskControl.TaskControl taskControl2 = TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControlID, userID);

                        pnlEndorsement.Visible = false;
                        lblEndorsement.Visible = false;
                        //chkUserMod.Checked = false;
                        txtEndoComments.Text = String.Empty;
                        txtEndoEffDate.Text = String.Empty;
                        txtEndoPremium.Text = String.Empty;
                        ddlEndoType.SelectedIndex = -1;
                        taskControl.isEndorsement = false;

                        Session.Clear();
                        Session["TaskControl"] = taskControl2;
                        Response.Redirect("Policies.aspx?" + taskControl.TaskControlID, true);

                    }
                    Session.Clear();
                    Response.Redirect("MainMenu.aspx");
                }
                else
                {
                    taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControl.TaskControlID, userID);
                    taskControl.Mode = (int)EPolicy.TaskControl.TaskControl.TaskControlMode.CLEAR;
                    Session["TaskControl"] = taskControl;
                    FillTextControl();
                    FillGrid();
                    DisableControls();
                }

                if (taskControl.PolicyType.ToString().Trim().Length > 2)
                    DisableControlsTail();
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
        protected void BtnExit_Click(object sender, EventArgs e)
        {
            RemoveSessionLookUp();
            this.litPopUp.Visible = false;
            Session.Clear();
            Response.Redirect("MainMenu.aspx");
        }
        private void RemoveSessionLookUp()
        {
            Session.Remove("LookUpTables");
        }
        protected void ddlCorparation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlPrimaryLimits1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetAllRate();
           // SetRatesWhenChangeOfRate();
        }
        protected void ddlLimits_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            SetAllRate();
            //SetRatesWhenChangeOfRate();
            
        }
        private void SetRatesWhenChangeOfRate()
        {
            ddPrimarylPolicyClass.SelectedIndex = ddPrimarylPolicyClass.Items.IndexOf(
               ddPrimarylPolicyClass.Items.FindByText(this.ddlPolicyClass.SelectedItem.Text.Trim()));

            string myStringPrimary = this.ddPrimarylPolicyClass.SelectedValue.Trim();
            string[] myPrimaryRateList = myStringPrimary.Split('|');

            this.HIPrimeryRateID.Value = myPrimaryRateList[0];

            string myString = this.ddlPolicyClass.SelectedValue.Trim();
            string[] myRateList = myString.Split('|');

            this.txtPrateID.Value = myRateList[0];
            this.txtIsoCode.Text = myRateList[1];

            this.txtRate4.Text = int.Parse(myRateList[6]).ToString("###,###,##0.00");

            DataTable dtPRMEDICRATE2 = EPolicy.TaskControl.Application.GetPRMEDICRATEBYISOCODE(int.Parse(txtPrateID.Value), txtIsoCode.Text.Trim());

            if (dtPRMEDICRATE2.Rows.Count > 0)
            {
                int index = 1;
                for (int i = 0; dtPRMEDICRATE2.Rows.Count > i; i++)
                {
                    myString = dtPRMEDICRATE2.Rows[i]["PRMEDICRATEID"].ToString().Trim();
                    myRateList = myString.Split('|');

                    if (int.Parse(txtPrateID.Value.Trim()) != int.Parse(myRateList[0].Trim()))
                    {
                        //SetOtherRateFields(index, myRateList);
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
        }
        private void SetAllRate()
        {
            try
            {

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
            try
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

                //this.txtPRate4.Text = "";
                //this.txtIsoCode.Text = "";
                //this.txtRate4.Text = "";
                
                /*txtPrimaryTN1.Text = "";
                txtPrimaryTN2.Text = "";
                txtPrimaryTN3.Text = "";
                txtPrimaryTN4.Text = "";
                txtPrimaryTN5.Text = "";
                txtPremiumTN1.Text = "";
                txtPremiumTN2.Text = "";
                txtPremiumTN3.Text = "";
                txtPremiumTN4.Text = "";
                txtPremiumTN5.Text = "";
                txtQuantityTN1.Text = "";
                txtQuantityTN2.Text = "";
                txtQuantityTN3.Text = "";
                txtQuantityTN4.Text = "";
                txtQuantityTN5.Text = "";
                txtQuantityTN6.Text = "";
                txtTotPremTN1.Text = "";
                txtTotPremTN2.Text = "";
                txtTotPremTN3.Text = "";
                txtTotPremTN4.Text = "";
                txtTotPremTN5.Text = "";
                txtTotPremTN6.Text = "";

                txtExcessTN1.Text = "";
                txtExcessTN2.Text = "";
                txtExcessTN3.Text = "";
                txtExcessTN4.Text = "";
                txtExcessTN5.Text = "";
                txtEPremiumTN1.Text = "";
                txtEPremiumTN2.Text = "";
                txtEPremiumTN3.Text = "";
                txtEPremiumTN4.Text = "";
                txtEPremiumTN5.Text = "";
                txtEQuantityTN1.Text = "";
                txtEQuantityTN2.Text = "";
                txtEQuantityTN3.Text = "";
                txtEQuantityTN4.Text = "";
                txtEQuantityTN5.Text = "";
                txtEQuantityTN6.Text = "";
                txtETotPremTN1.Text = "";
                txtETotPremTN2.Text = "";
                txtETotPremTN3.Text = "";
                txtETotPremTN4.Text = "";
                txtETotPremTN5.Text = "";
                txtETotPremTN6.Text = "";

                txtTotalPrimaryCorporate.Text = "";
                txtTotalExcessCorporate.Text = "";*/

                //Primary
                //this.txtPRate4.Text = "";

                //int ddlPolClassIndex = ddlPolicyClass.SelectedIndex;

                SetDDLLimit(limit, primaryLimit);

                //ddlPolicyClass.SelectedIndex = ddlPolClassIndex;
                
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

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("A problem occured while obtaining rate data.");
                this.litPopUp.Visible = true;
            }
        }
        protected void ddlPolicyClass_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //SetddlPimaryPolicyClass
            ddPrimarylPolicyClass.SelectedIndex = ddPrimarylPolicyClass.Items.IndexOf(
                ddPrimarylPolicyClass.Items.FindByText(this.ddlPolicyClass.SelectedItem.Text.Trim()));

            string myStringPrimary = this.ddPrimarylPolicyClass.SelectedValue.Trim();
            string[] myPrimaryRateList = myStringPrimary.Split('|');

            this.HIPrimeryRateID.Value = myPrimaryRateList[0];

            string myString = this.ddlPolicyClass.SelectedValue.Trim();
            string[] myRateList = myString.Split('|');

            this.txtPrateID.Value = myRateList[0];
            this.txtIsoCode.Text = myRateList[1];

            this.txtRate4.Text = int.Parse(myRateList[6]).ToString("###,###,##0.00");

            DataTable dtPRMEDICRATE2 = EPolicy.TaskControl.Application.GetPRMEDICRATEBYISOCODE(int.Parse(txtPrateID.Value), txtIsoCode.Text.Trim());

            if (dtPRMEDICRATE2.Rows.Count > 0)
            {
                int index = 1;
                for (int i = 0; dtPRMEDICRATE2.Rows.Count > i; i++)
                {
                    myString = dtPRMEDICRATE2.Rows[i]["PRMEDICRATEID"].ToString().Trim();
                    myRateList = myString.Split('|');

                    if (int.Parse(txtPrateID.Value.Trim()) != int.Parse(myRateList[0].Trim()))
                    {
                        //SetOtherRateFields(index, myRateList);
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

            GetOthersRates();
        }
        private void GetOthersRates()
        {
            try
            {
                //Primary
                DataTable dt1 = TaskControl.CorporatePolicyQuote.GetPRMEDICRATEPRIMARYByClassAndLimitID("1", int.Parse(ddlPrimaryLimits1.SelectedItem.Value.Trim()));
                DataTable dt2 = TaskControl.CorporatePolicyQuote.GetPRMEDICRATEPRIMARYByClassAndLimitID("7", int.Parse(ddlPrimaryLimits1.SelectedItem.Value.Trim()));
                DataTable dt3 = TaskControl.CorporatePolicyQuote.GetPRMEDICRATEPRIMARYByClassAndLimitID("3A", int.Parse(ddlPrimaryLimits1.SelectedItem.Value.Trim()));

                txtPrimaryTN1.Text = (double.Parse(dt1.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                txtPrimaryTN2.Text = (double.Parse(dt2.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                txtPrimaryTN3.Text = (double.Parse(dt3.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                txtPrimaryTN4.Text = (double.Parse(dt1.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                txtPrimaryTN5.Text = (double.Parse(dt1.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");


                //Excess
                DataTable dt4 = TaskControl.CorporatePolicyQuote.GetPRMEDICRATEByClassAndLimitID("1", int.Parse(ddlLimits.SelectedItem.Value.Trim()));
                DataTable dt5 = TaskControl.CorporatePolicyQuote.GetPRMEDICRATEByClassAndLimitID("7", int.Parse(ddlLimits.SelectedItem.Value.Trim()));
                DataTable dt6 = TaskControl.CorporatePolicyQuote.GetPRMEDICRATEByClassAndLimitID("3A", int.Parse(ddlLimits.SelectedItem.Value.Trim()));

                txtExcessTN1.Text = (double.Parse(dt4.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                txtExcessTN2.Text = (double.Parse(dt5.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                txtExcessTN3.Text = (double.Parse(dt6.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                txtExcessTN4.Text = (double.Parse(dt4.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                txtExcessTN5.Text = (double.Parse(dt4.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");

                CalculateOthersRates();
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

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("A problem occured while obtaining rate data.");
                this.litPopUp.Visible = true;
            }
        }
        private void CalculateOthersRates()
        {
            try
            {
                //DateTime effectiveDate;

                //if (txtQuoteRetroDate.Text != String.Empty || TxtRetroactiveDate.Text != String.Empty)
                //{
                //    DateTime retroActiveDate = new DateTime();

                //    if(txtQuoteRetroDate.Text != String.Empty)
                //        retroActiveDate = Convert.ToDateTime(txtQuoteRetroDate.Text.Trim());
                //    else
                //        retroActiveDate = Convert.ToDateTime(TxtRetroactiveDate.Text.Trim());

                //    if (txtEffDt.Text == String.Empty)
                //        effectiveDate = DateTime.Now;
                //    else
                //        effectiveDate = Convert.ToDateTime(txtEffDt.Text.Trim());
                //    TimeSpan result = effectiveDate - retroActiveDate;
                //    double days = (result.TotalDays + 1);
                //    double mcmRate = 0.0;

                //    if (days < 366)
                //        mcmRate = 0.6;
                //    else if (days < 731)
                //        mcmRate = 0.8;
                //    else if (days < 1096)
                //        mcmRate = 0.9;
                //    else
                //        mcmRate = 1;

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

                    double P1 = Math.Round((double.Parse(txtPrimaryTN1.Text) * (double.Parse(txtRateTN1.Text.Replace("%", "")) / 100)));// * mcmRate, 0);
                    double P2 = Math.Round((double.Parse(txtPrimaryTN2.Text) * (double.Parse(txtRateTN2.Text.Replace("%", "")) / 100)));// * mcmRate, 0);
                    double P3 = Math.Round((double.Parse(txtPrimaryTN3.Text) * (double.Parse(txtRateTN3.Text.Replace("%", "")) / 100)));// * mcmRate, 0);
                    double P4 = Math.Round((double.Parse(txtPrimaryTN4.Text) * (double.Parse(txtRateTN4.Text.Replace("%", "")) / 100)));// * mcmRate, 0);
                    double P5 = Math.Round((double.Parse(txtPrimaryTN5.Text) * (double.Parse(txtRateTN5.Text.Replace("%", "")) / 100)));// * mcmRate, 0);

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

                    double E1 = Math.Round((double.Parse(txtExcessTN1.Text) * (double.Parse(txtERateTN1.Text.Replace("%", "")) / 100)));// * mcmRate, 0);
                    double E2 = Math.Round((double.Parse(txtExcessTN2.Text) * (double.Parse(txtERateTN2.Text.Replace("%", "")) / 100)));// * mcmRate, 0);
                    double E3 = Math.Round((double.Parse(txtExcessTN3.Text) * (double.Parse(txtERateTN3.Text.Replace("%", "")) / 100)));// * mcmRate, 0);
                    double E4 = Math.Round((double.Parse(txtExcessTN4.Text) * (double.Parse(txtERateTN4.Text.Replace("%", "")) / 100)));// * mcmRate, 0);
                    double E5 = Math.Round((double.Parse(txtExcessTN5.Text) * (double.Parse(txtERateTN5.Text.Replace("%", "")) / 100)));// * mcmRate, 0);

                    txtEPremiumTN1.Text = E1.ToString("###,##0.00");
                    txtEPremiumTN2.Text = E2.ToString("###,##0.00");
                    txtEPremiumTN3.Text = E3.ToString("###,##0.00");
                    txtEPremiumTN4.Text = E4.ToString("###,##0.00");
                    txtEPremiumTN5.Text = E5.ToString("###,##0.00");
                //}
                //else
                //{
                //    this.litPopUp.Text = "Please introduce a retroactive date.";
                //    this.litPopUp.Visible = true;
                //}
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

                //this.litPopUp.Text = Utilities.MakeLiteralPopUpString("A problem occured while calculating other rates.");
                //this.litPopUp.Visible = true;
            }
        }
        private void SetPrimaryRates(int index, string[] myRateList)
        {
            if (index == 1)
            {
                ddlPrimaryLimits1.SelectedIndex = ddlPrimaryLimits1.Items.IndexOf(
                        ddlPrimaryLimits1.Items.FindByValue(myRateList[7].ToString()));

                this.txtPRate4.Text = int.Parse(myRateList[6]).ToString("###,###,##0.00");
            }
        }
        private void SetDDLLimit(int LimitID, int primaryLimit) //aqui 
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
            ddlPolicyClass.SelectedIndex = ddlPolicyClass.Items.IndexOf(
                ddlPolicyClass.Items.FindByText(this.ddlMainSpecialty.SelectedItem.Text.Trim()));
        
            

            
            

            //Primary
            DataTable dtPRMEDICRATE2 = EPolicy.TaskControl.Application.GetPRMEDICPrimaryRATE(primaryLimit);
            ddPrimarylPolicyClass.Items.Clear();
            ddPrimarylPolicyClass.DataSource = dtPRMEDICRATE2;
            ddPrimarylPolicyClass.DataTextField = "PRMEDICRATEDesc";
            ddPrimarylPolicyClass.DataValueField = "PRMEDICRATEID";
            ddPrimarylPolicyClass.DataBind();
            ddPrimarylPolicyClass.SelectedIndex = -1;
            ddPrimarylPolicyClass.Items.Insert(0, "");
            ddlPolicyClass.SelectedIndex = ddlPolicyClass.Items.IndexOf(
                ddlPolicyClass.Items.FindByText(this.ddlMainSpecialty.SelectedItem.Text.Trim()));
            
            
            
            
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];

            try
            {
                //ResetValues();
                //Calculate();

                //if (taskControl.Mode != 1)
                //{
                //    CalculateCharge();
                //}

                //if (txtEndoEffDate.Text != "")
                //{
                //    //chkUserMod.Checked = false;
                //    ResetValues();
                //    Calculate();
                //    CalculateCharge();

                //    CalculateEndorsement();
                //}

                //if (!chkUserMod.Checked)
                //{
                //ResetValues();
                Calculate();
                CalculateCharge();
                //}

                if (txtEndoEffDate.Text != "")// && taskControl.isEndorsement)
                {
                    chkUserMod.Checked = false;
                    //ResetValues();
                    Calculate();
                    CalculateCharge();

                    CalculateEndorsement();
                }

            }
            catch (Exception exp)
            {

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }

        }
        private void Calculate()
        {
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];

            CalculateOthersRates();

            DateTime effectiveDate;

            if (txtQuoteRetroDate.Text != String.Empty || TxtRetroactiveDate.Text != String.Empty)
            {
                DateTime retroActiveDate = new DateTime();

                if (txtQuoteRetroDate.Text != String.Empty)
                    retroActiveDate = Convert.ToDateTime(txtQuoteRetroDate.Text.Trim());
                else
                    retroActiveDate = Convert.ToDateTime(TxtRetroactiveDate.Text.Trim());

                if (txtEffDt.Text == String.Empty)
                    effectiveDate = DateTime.Now;
                else
                    effectiveDate = Convert.ToDateTime(txtEffDt.Text.Trim());
                TimeSpan result = effectiveDate - retroActiveDate;
                double days = (result.TotalDays + 1);
                double mcmRate = 0.0;

                if (days < 366)
                    mcmRate = 0.6;
                else if (days < 731)
                    mcmRate = 0.8;
                else if (days < 1096)
                    mcmRate = 0.9;
                else
                    mcmRate = 1;

                if (txtQuantityTN1.Text.Trim() == "")
                    txtQuantityTN1.Text = "0";

                if (txtEQuantityTN1.Text.Trim() == "")
                    txtEQuantityTN1.Text = "0";//txtQuantityTN1.Text.Trim();

                if (txtQuantityTN2.Text.Trim() == "")
                    txtQuantityTN2.Text = "0";

                if (txtEQuantityTN2.Text.Trim() == "")
                    txtEQuantityTN2.Text = "0";//txtQuantityTN2.Text.Trim();

                if (txtQuantityTN3.Text.Trim() == "")
                    txtQuantityTN3.Text = "0";

                if (txtEQuantityTN3.Text.Trim() == "")
                    txtEQuantityTN3.Text = "0";//xtQuantityTN3.Text.Trim();

                if (txtQuantityTN4.Text.Trim() == "")
                    txtQuantityTN4.Text = "0";

                if (txtEQuantityTN4.Text.Trim() == "")
                    txtEQuantityTN4.Text = "0";// txtQuantityTN4.Text.Trim();

                if (txtQuantityTN5.Text.Trim() == "")
                    txtQuantityTN5.Text = "0";

                if (txtEQuantityTN5.Text.Trim() == "")
                    txtEQuantityTN5.Text = "0";//txtQuantityTN5.Text.Trim();

                if (txtQuantityTN6.Text.Trim() == "")
                    txtQuantityTN6.Text = "0";

                if (txtEQuantityTN6.Text.Trim() == "")
                    txtEQuantityTN6.Text = "0";//txtQuantityTN6.Text.Trim();

                if (txtEQuantityTN1.Text.Trim() == "")
                    txtEQuantityTN1.Text = "0";

                if (txtQuantityTN1.Text.Trim() == "0")
                    txtQuantityTN1.Text = "0";//txtEQuantityTN1.Text.Trim();

                if (txtEQuantityTN2.Text.Trim() == "")
                    txtEQuantityTN2.Text = "0";

                if (txtQuantityTN2.Text.Trim() == "0")
                    txtQuantityTN2.Text = "0";//txtEQuantityTN2.Text.Trim();

                if (txtEQuantityTN3.Text.Trim() == "")
                    txtEQuantityTN3.Text = "0";

                if (txtQuantityTN3.Text.Trim() == "0")
                    txtQuantityTN3.Text = "0";//txtEQuantityTN3.Text.Trim();

                if (txtEQuantityTN4.Text.Trim() == "")
                    txtEQuantityTN4.Text = "0";

                if (txtQuantityTN4.Text.Trim() == "0")
                    txtQuantityTN4.Text = "0";//txtEQuantityTN4.Text.Trim();

                if (txtEQuantityTN5.Text.Trim() == "")
                    txtEQuantityTN5.Text = "0";

                if (txtQuantityTN5.Text.Trim() == "0")
                    txtQuantityTN5.Text = "0";//txtEQuantityTN5.Text.Trim();

                if (txtEQuantityTN6.Text.Trim() == "")
                    txtEQuantityTN6.Text = "0";

                if (txtQuantityTN6.Text.Trim() == "0")
                    txtQuantityTN6.Text = "0";//txtEQuantityTN6.Text.Trim();

                if (txtPremiumTN1.Text.Trim() == "0")
                    txtPremiumTN1.Text = "0";//txtEPremiumTN1.Text.Trim();

                if (txtPremiumTN2.Text.Trim() == "0")
                    txtPremiumTN2.Text = "0";//txtEPremiumTN2.Text.Trim();

                if (txtPremiumTN3.Text.Trim() == "0")
                    txtPremiumTN3.Text = "0";//txtEPremiumTN3.Text.Trim();

                if (txtPremiumTN4.Text.Trim() == "0")
                    txtPremiumTN4.Text = "0";//txtEPremiumTN4.Text.Trim();

                if (txtPremiumTN5.Text.Trim() == "0")
                    txtPremiumTN5.Text = "0";//txtEPremiumTN5.Text.Trim();

                

                //Primary
                int quantity1 = int.Parse(txtQuantityTN1.Text.Trim());
                int quantity2 = int.Parse(txtQuantityTN2.Text.Trim());
                int quantity3 = int.Parse(txtQuantityTN3.Text.Trim());
                int quantity4 = int.Parse(txtQuantityTN4.Text.Trim());
                int quantity5 = int.Parse(txtQuantityTN5.Text.Trim());
                int quantity6 = quantity1 + quantity2 + quantity3 + quantity4 + quantity5;
                txtQuantityTN6.Text = quantity6.ToString();

                double tot1 = Math.Round(double.Parse(txtPremiumTN1.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtQuantityTN1.Text) * mcmRate,0);
                txtTotPremTN1.Text = tot1.ToString("###,###,##0.00");
                

                double tot2 = Math.Round(double.Parse(txtPremiumTN2.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtQuantityTN2.Text) * mcmRate,0);
                txtTotPremTN2.Text = tot2.ToString("###,###,##0.00");

                double tot3 = Math.Round(double.Parse(txtPremiumTN3.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtQuantityTN3.Text) * mcmRate,0);
                txtTotPremTN3.Text = tot3.ToString("###,###,##0.00");

                double tot4 = Math.Round(double.Parse(txtPremiumTN4.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtQuantityTN4.Text) * mcmRate,0);
                txtTotPremTN4.Text = tot4.ToString("###,###,##0.00");

                double tot5 = Math.Round(double.Parse(txtPremiumTN5.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtQuantityTN5.Text) * mcmRate, 0);
                txtTotPremTN5.Text = tot5.ToString("###,###,##0.00");

                double tot6 = tot1 + tot2 + tot3 + tot4 + tot5;
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

                double tot10 = Math.Round(double.Parse(txtEPremiumTN1.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtEQuantityTN1.Text) * mcmRate, 0);
                txtETotPremTN1.Text = tot10.ToString("###,###,##0.00");

                double tot20 = Math.Round(double.Parse(txtEPremiumTN2.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtEQuantityTN2.Text) * mcmRate, 0);
                txtETotPremTN2.Text = tot20.ToString("###,###,##0.00");

                double tot30 = Math.Round(double.Parse(txtEPremiumTN3.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtEQuantityTN3.Text) * mcmRate, 0);
                txtETotPremTN3.Text = tot30.ToString("###,###,##0.00");

                double tot40 = Math.Round(double.Parse(txtEPremiumTN4.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtEQuantityTN4.Text) * mcmRate, 0);
                txtETotPremTN4.Text = tot40.ToString("###,###,##0.00");

                double tot50 = Math.Round(double.Parse(txtEPremiumTN5.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtEQuantityTN5.Text) * mcmRate, 0);
                txtETotPremTN5.Text = tot50.ToString("###,###,##0.00");

                double tot60 = tot10 + tot20 + tot30 + tot40 + tot50;
                double P2 = Math.Round(double.Parse(tot60.ToString()) * (double.Parse(txtERateTN6.Text.Replace("%", "")) / 100), 0);
                txtETotPremTN6.Text = P2.ToString("###,###,##0.00");

                int totPrimaryPremium = int.Parse(txtTotalPrimaryPremium.Text.Trim().Replace(".00", "").Replace(",", "")) + int.Parse(P1.ToString());
                txtTotalPrimaryCorporate.Text = totPrimaryPremium.ToString("###,###,##0.00");

                int totExcessPremium = int.Parse(txtTotalExcessPremium.Text.Trim().Replace(".00", "").Replace(",", "")) + int.Parse(P2.ToString());
                txtTotalExcessCorporate.Text = totExcessPremium.ToString("###,###,##0.00");

                if (taskControl.IsPolicy)
                {
                    if (taskControl.PolicyType.Trim() == "CP")
                    {
                        TxtTotalPremium.Text = ((double.Parse(totPrimaryPremium.ToString()) + taskControl.Charge)).ToString("###,###,##0.00");
                        TxtPremium.Text = totPrimaryPremium.ToString("###,###,##0.00");
                    }
                    else
                    {
                        TxtTotalPremium.Text = ((double.Parse(totExcessPremium.ToString()) + taskControl.Charge)).ToString("###,###,##0.00");
                        TxtPremium.Text = totExcessPremium.ToString("###,###,##0.00");
                    }
                }
            }
            else
            {
                this.litPopUp.Text = "Please introduce a retroactive date.";
                this.litPopUp.Visible = true;
            }
        }
        private void ResetValues()
        {
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];

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
                TxtTotalPremium.Text = ((taskControl.TotalPremium + taskControl.Charge) - taskControl.CancellationAmount).ToString("###,###,##0.00");

                //if (this.TxtPolicyType.Text.Trim() == "PP")
                //{
                //    //TxtPremium.Text = ((double.Parse(TxtPremium.Text) - double.Parse(TxtCharge.Text)) - totPrimaryPremium).ToString("###,###,##0.00");
                //    TxtTotalPremium.Text = (double.Parse(TxtPremium.Text) + double.Parse(TxtCharge.Text)).ToString("###,###,##0.00");
                //    //txtRate4.Text = (double.Parse(txtRate4.Text) - totPrimaryPremium).ToString("###,###,##0.00");

                //}
                ////else
                ////{
                ////    //TxtPremium.Text = ((double.Parse(TxtPremium.Text) - double.Parse(TxtCharge.Text)) - totExcessPremium).ToString("###,###,##0.00");
                ////    TxtTotalPremium.Text = (double.Parse(TxtTotalPremium.Text) - totExcessPremium).ToString("###,###,##0.00");
                ////    //txtRate4.Text = (double.Parse(txtRate4.Text) - totExcessPremium).ToString("###,###,##0.00");
                ////}
            }

            txtTotPremTN6.Text = "";
            txtETotPremTN6.Text = "";

            txtTotalPrimaryCorporate.Text = "";
            txtTotalExcessCorporate.Text = "";

        }
        protected void btnConvertPrimary_Click(object sender, EventArgs e)
        {
            EPolicy.TaskControl.CorporatePolicyQuote taskControlQuote = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = new EPolicy.TaskControl.CorporatePolicyQuote(true);
            try
            {
                taskControl = taskControlQuote;
                taskControl.Mode = 1; //ADD
                taskControl.PolicyClassID = 15;
                taskControl.TaskControlTypeID = 18;
                taskControl.IsPolicy = true;
                taskControl.Agency = taskControlQuote.Agency;
                taskControl.Agent = taskControlQuote.Agent;
                taskControl.AutoAssignPolicy = false;
                taskControl.EntryDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                if(taskControl.InsuranceCompany != "002")
                    taskControl.InsuranceCompany = "001";

                taskControl.OriginatedAt = 1;
                taskControl.Term = 12;

                //taskControl.TaskControlID = 0;
                taskControl.Customer.ProspectID = taskControlQuote.Prospect.ProspectID;
                taskControl.Customer.CustomerNo = taskControlQuote.Customer.CustomerNo;
                taskControl.Customer.FirstName = (taskControlQuote.Customer.FirstName == "") ? txtCorporation.Text : taskControlQuote.Customer.FirstName;
                taskControl.Customer.Initial = taskControlQuote.Customer.Initial;
                taskControl.Customer.LastName1 = taskControlQuote.Customer.LastName1;
                taskControl.Customer.LastName2 = taskControlQuote.Customer.LastName2;
                taskControl.Customer.Description = taskControlQuote.Customer.Description;
                taskControl.Customer.Sex = taskControlQuote.Customer.Sex;
                taskControl.Customer.Address1 = taskControlQuote.Customer.Address1;
                taskControl.Customer.Address2 = taskControlQuote.Customer.Address2;
                taskControl.Customer.City = taskControlQuote.Customer.City;
                taskControl.Customer.State = taskControlQuote.Customer.State;
                taskControl.Customer.ZipCode = taskControlQuote.Customer.ZipCode;
                taskControl.Customer.HomePhone = taskControlQuote.Customer.HomePhone;
                taskControl.Customer.JobPhone = taskControlQuote.Customer.JobPhone;
                taskControl.Customer.Cellular = taskControlQuote.Customer.Cellular;
                taskControl.Customer.Email = taskControlQuote.Customer.Email;
                taskControl.Customer.License = taskControlQuote.Customer.License;
                

                if(taskControl.InsuranceCompany == "001")
                    taskControl.PolicyType = "CP";
                else
                    taskControl.PolicyType = "APC";

                taskControl.TotalPremium = taskControlQuote.TotalPrimaryCorporate;
                ddlMainSpecialty.SelectedIndex = ddlMainSpecialty.Items.IndexOf(
                            ddlMainSpecialty.Items.FindByText(DtGridCorpaoratePol.Items[0].Cells[5].Text.Trim()));

                if (ddlMainSpecialty.SelectedValue != "")
                    taskControl.MainSpecialtyID = int.Parse(ddlMainSpecialty.SelectedValue);

                if (txtQuoteRetroDate.Text != "")
                    taskControl.RetroactiveDate = txtQuoteRetroDate.Text.Trim();

                if (ddlGroup2.SelectedValue != "")
                    taskControl.Bank = ddlGroup2.SelectedValue;

                convert = true;

                Session.Clear();
                Session.Add("TaskControl", taskControl);
                try
                {
                    Response.Redirect("CorporatePolicyQuote.aspx", true);
                }
                catch
                {
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
        protected void btnConvert_Click(object sender, EventArgs e)
        {
            EPolicy.TaskControl.CorporatePolicyQuote taskControlQuote = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = new EPolicy.TaskControl.CorporatePolicyQuote(true);

            try
            {
                taskControl = taskControlQuote;
                taskControl.Mode = 1; //ADD
                taskControl.PolicyClassID = 15;
                taskControl.TaskControlTypeID = 18;
                taskControl.IsPolicy = true;
                taskControl.Agency = taskControlQuote.Agency;
                taskControl.Agent = taskControlQuote.Agent;
                taskControl.AutoAssignPolicy = false;
                taskControl.EntryDate = DateTime.Parse(DateTime.Now.ToShortDateString());

                if (taskControl.InsuranceCompany != "002")
                    taskControl.InsuranceCompany = "001";

                taskControl.OriginatedAt = 1;
                taskControl.Term = 12;
                taskControl.PrMedicalLimit = taskControlQuote.CorporatePolicyDetailCollection.Rows[0]["ExcessRate"].ToString();
                //taskControl.TaskControlID = 0;
                taskControl.Customer.ProspectID = taskControlQuote.Prospect.ProspectID;
                taskControl.Customer.CustomerNo = taskControlQuote.Customer.CustomerNo;
                taskControl.Customer.FirstName = (taskControlQuote.Customer.FirstName == "") ? txtCorporation.Text : taskControlQuote.Customer.FirstName;
                taskControl.Customer.Initial = taskControlQuote.Customer.Initial;
                taskControl.Customer.LastName1 = taskControlQuote.Customer.LastName1;
                taskControl.Customer.LastName2 = taskControlQuote.Customer.LastName2;
                taskControl.Customer.Description = taskControlQuote.Customer.Description;
                taskControl.Customer.Sex = taskControlQuote.Customer.Sex;
                taskControl.Customer.Address1 = taskControlQuote.Customer.Address1;
                taskControl.Customer.Address2 = taskControlQuote.Customer.Address2;
                taskControl.Customer.City = taskControlQuote.Customer.City;
                taskControl.Customer.State = taskControlQuote.Customer.State;
                taskControl.Customer.ZipCode = taskControlQuote.Customer.ZipCode;
                taskControl.Customer.HomePhone = taskControlQuote.Customer.HomePhone;
                taskControl.Customer.JobPhone = taskControlQuote.Customer.JobPhone;
                taskControl.Customer.Cellular = taskControlQuote.Customer.Cellular;
                taskControl.Customer.Email = taskControlQuote.Customer.Email;
                taskControl.Customer.License = taskControlQuote.Customer.License;

                if (taskControl.InsuranceCompany == "001")
                    taskControl.PolicyType = "CE";
                else
                    taskControl.PolicyType = "AEC";

                taskControl.TotalPremium = taskControlQuote.TotalExcessCorporate;
                ddlMainSpecialty.SelectedIndex = ddlMainSpecialty.Items.IndexOf(
                            ddlMainSpecialty.Items.FindByText(DtGridCorpaoratePol.Items[0].Cells[5].Text.Trim()));

               

                if (ddlMainSpecialty.SelectedValue != "")
                    taskControl.MainSpecialtyID = int.Parse(ddlMainSpecialty.SelectedValue);

                if (txtQuoteRetroDate.Text != "")
                    taskControl.RetroactiveDate = txtQuoteRetroDate.Text.Trim();

                if (ddlGroup2.SelectedValue != "")
                    taskControl.Bank = ddlGroup2.SelectedValue;

                convert = true;

                Session.Clear();
                Session.Add("TaskControl", taskControl);
                try
                {
                    Response.Redirect("CorporatePolicyQuote.aspx", true);
                }
                catch
                {
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
        protected void btnRenew_Click(object sender, EventArgs e)
        {
            TaskControl.CorporatePolicyQuote taskControl = (TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            TaskControl.Policy policy = (TaskControl.Policy)Session["TaskControl"];
            TaskControl.CorporatePolicyQuote CorporatePolicyQuote = new TaskControl.CorporatePolicyQuote(true);
            Login.Login cp = HttpContext.Current.User as Login.Login;

            try
            {
                CorporatePolicyQuote = taskControl;
                CorporatePolicyQuote.Corporate = taskControl.Corporate;
                CorporatePolicyQuote.CorporatePolicyDetailCollection = taskControl.CorporatePolicyDetailCollection;
                CorporatePolicyQuote.Mode = 1;
                CorporatePolicyQuote.CancellationDate = "";
                CorporatePolicyQuote.CancellationEntryDate = "";
                CorporatePolicyQuote.CancellationUnearnedPercent = 0.00;
                CorporatePolicyQuote.CancellationMethod = 0;
                CorporatePolicyQuote.CancellationReason = 0;
                CorporatePolicyQuote.PaidAmount = 0.00; // taskControl.PaidAmount;
                CorporatePolicyQuote.PaidDate = "";
                CorporatePolicyQuote.Ren_Rei = "RN";
                CorporatePolicyQuote.Rein_Amt = taskControl.CancellationAmount;
                CorporatePolicyQuote.PaidDate = taskControl.PaidDate;
                CorporatePolicyQuote.CommissionAgency = 0.00; // taskControl.ReturnCommissionAgency;
                CorporatePolicyQuote.CommissionAgent = 0.00; // taskControl.ReturnCommissionAgent;
                CorporatePolicyQuote.CommissionAgencyPercent = ""; // taskControl.CommissionAgencyPercent.Trim();
                CorporatePolicyQuote.CommissionAgentPercent = "";  //taskControl.CommissionAgentPercent.Trim();
                oldTaskControlID = taskControl.TaskControlID;
                CorporatePolicyQuote.TaskControlID = 0;
                CorporatePolicyQuote.Status = "Inforce";


                CorporatePolicyQuote.PrMedicalLimit = taskControl.PrMedicalLimit;
               
                CorporatePolicyQuote.EntryDate = DateTime.Now;
                txtEntryDate.Text = CorporatePolicyQuote.EntryDate.ToShortDateString();
                CorporatePolicyQuote.EffectiveDate = (DateTime.Parse(CorporatePolicyQuote.EffectiveDate).AddMonths(12)).ToShortDateString();
                txtEffDt.Text = CorporatePolicyQuote.EffectiveDate.ToString();
                txtExpDt.Text = "";
                CorporatePolicyQuote.ExpirationDate = DateTime.Parse(taskControl.ExpirationDate).AddMonths(12).ToShortDateString();//DateTime.Parse(CorporatePolicyQuote.ExpirationDate).AddMonths(12).ToShortDateString();
                txtExpDt.Text = CorporatePolicyQuote.ExpirationDate.ToString();

                CalculateCharge();
                CorporatePolicyQuote.Charge = double.Parse(TxtCharge.Text);//taskControl.Charge;

                CorporatePolicyQuote.ReturnCharge = 0.00;
                CorporatePolicyQuote.ReturnPremium = 0.00;
                CorporatePolicyQuote.CancellationAmount = 0.00;
                CorporatePolicyQuote.ReturnCommissionAgency = 0.00;
                CorporatePolicyQuote.ReturnCommissionAgent = 0.00;

                taskControl.PrintPolicy = false;
                taskControl.PrintDate = "";

                int msufijo;
                int sufijo = int.Parse(taskControl.Suffix);
                msufijo = sufijo + 1;
                if (msufijo < 10)
                    CorporatePolicyQuote.Suffix = "0".ToString() + msufijo.ToString();
                else
                    CorporatePolicyQuote.Suffix = msufijo.ToString();

                int mAniv;
                int aniv = int.Parse(taskControl.Anniversary);
                mAniv = aniv + 1;

                if (mAniv < 10)
                    CorporatePolicyQuote.Anniversary = "0".ToString() + mAniv.ToString();
                else
                    CorporatePolicyQuote.Anniversary = mAniv.ToString();
                if (cp.IsInRole("BTNEDITENDORSEMENT"))
                {

                    dtEndorsement.Columns[9].Visible = true;
                    dtEndorsement.Columns[10].Visible = true;
                }

                Session.Clear();
                Session.Add("TaskControl", CorporatePolicyQuote);
                Response.Redirect("CorporatePolicyQuote.aspx", false);
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }
        }
        protected void btnReinstatement_Click(object sender, EventArgs e)
        {
            TaskControl.CorporatePolicyQuote taskControl = (TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            TaskControl.Policy policy = (TaskControl.Policy)Session["TaskControl"];
            TaskControl.CorporatePolicyQuote CorporatePolicyQuote = new TaskControl.CorporatePolicyQuote(true);

            try
            {
                ValidateReinstatement(CorporatePolicyQuote, taskControl);

                CorporatePolicyQuote = taskControl;
                CorporatePolicyQuote.Mode = 2;
                CorporatePolicyQuote.CancellationDate = "";
                CorporatePolicyQuote.CancellationEntryDate = "";
                CorporatePolicyQuote.CancellationUnearnedPercent = 0.00;
                CorporatePolicyQuote.CancellationMethod = 0;
                CorporatePolicyQuote.CancellationReason = 0;
                CorporatePolicyQuote.EntryDate = DateTime.Now;
                CorporatePolicyQuote.PaidAmount = taskControl.PaidAmount;
                CorporatePolicyQuote.PaidDate = "";
                CorporatePolicyQuote.Ren_Rei = "RI";
                CorporatePolicyQuote.Rein_Amt = taskControl.CancellationAmount;
                CorporatePolicyQuote.PaidDate = taskControl.PaidDate;
                CorporatePolicyQuote.CommissionAgency = taskControl.ReturnCommissionAgency;
                CorporatePolicyQuote.CommissionAgent = taskControl.ReturnCommissionAgent;
                CorporatePolicyQuote.CommissionAgencyPercent = taskControl.CommissionAgencyPercent.Trim();
                CorporatePolicyQuote.CommissionAgentPercent = taskControl.CommissionAgentPercent.Trim();
                //policies.TotalPremium = taskControl.ReturnPremium;
                //policies.Charge = taskControl.ReturnCharge;
                CorporatePolicyQuote.ReturnCharge = 0.00;
                CorporatePolicyQuote.ReturnPremium = 0.00;
                CorporatePolicyQuote.CancellationAmount = 0.00;
                CorporatePolicyQuote.ReturnCommissionAgency = 0.00;
                CorporatePolicyQuote.ReturnCommissionAgent = 0.00;
                //policies.TaskControlID = 0;
                CorporatePolicyQuote.Status = "Inforce";

               

                //int msufijo;
                //int sufijo = int.Parse(taskControl.Suffix);
                //msufijo = sufijo + 1;
                //policies.Suffix = "0".ToString() + msufijo.ToString();

                Session.Add("TaskControl", CorporatePolicyQuote);

                FillTextControl();
                EnableControls();
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }
        }
        private void ValidateReinstatement(TaskControl.CorporatePolicyQuote policies, TaskControl.CorporatePolicyQuote Oldpolicies)
        {
            string errorMessage = String.Empty;
            bool found = false;

            string mStatus = Oldpolicies.Status.Split("/".ToCharArray())[0];

            if (mStatus != "Cancelled")  //Verifica si la p?liza se encuentra cancelada.
            {
                throw new Exception("The Policy is Not Cancelled, Please verify...");
                //errorMessage = "The Policy is Not Cancelled, Please verify...";
                found = true;
            }
            if (found == true)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(errorMessage);
                this.litPopUp.Visible = true;
            }
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
        protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        private void VerifyLabelAgent(int level, int CurrentLevel, bool firstTime)
        {
            // Se le A?ade uno para visualizar el pr?ximo nivel a seleccionarse ?
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
                //LblSelectAgent.Text = "Available Agent - Level " + level.ToString().Trim();
            }
            else
            {
                if (firstTime)
                {
                    level = 1;
                    //LblSelectAgent.Text = "Available Agent - Level 1";
                }
                else
                {
                    //LblSelectAgent.Text = "Available Agent - Level ";
                }
            }

            //Actulizo el DropdownList con los agentes del nivel para seleccionarse. - ddlAvailableAgent.
            TaskControl.CorporatePolicyQuote taskControl = (TaskControl.CorporatePolicyQuote)Session["TaskControl"];

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
                //LblSelectAgent.Text = "Available Agent - Level ";
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
        protected void btnPayments_Click(object sender, EventArgs e)
        {
            RemoveSessionLookUp();
            Session.Add("FromPage", "CorporatePolicyQuote.aspx");
            Response.Redirect("ViewPayment.aspx");
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
                throw new Exception("Could not update Partial Payment.", ex);
            }
        }
        protected void btnCancellation_Click(object sender, EventArgs e)
        {
            RemoveSessionLookUp();
            Session.Add("FromUI", "CorporatePolicyQuote.aspx");
            Response.Redirect("CancellationPolicy.aspx", false);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            TaskControl.CorporatePolicyQuote taskControl = (TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            try
            {
                int i = taskControl.TaskControlID;
                TaskControl.CorporatePolicyQuote.DeleteCorporatePolicyByTaskControlID(i, taskControl.IsPolicy);
                taskControl = new TaskControl.CorporatePolicyQuote(false);
                taskControl.Mode = 4; //Clear

                Session["TaskControl"] = taskControl;
                Session.Clear();
                Response.Redirect("MainMenu.aspx");
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
            }
        }
        protected void btnPrintCertificate_Click(object sender, EventArgs e)
        {
            string js = "<script language=javascript> javascript:popwindow=window.open('PrintCertificate.aspx?','popwindow','toolbar=no,location=center,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,copyhistory=no,width=850,height=450');popwindow.focus(); </script>";
            Response.Write(js);
            DisableControls();
        }
        protected void CalculateCharge(object sender, EventArgs e)
        {
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            try
            {
            //EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            //if (taskControl.Mode != 1)
            //{

            //if (!chkUserMod.Checked)
            //{
            ResetValues();
            Calculate();
            CalculateCharge();
            //}

            if (txtEndoEffDate.Text != "")//  && taskControl.isEndorsement)
            {
                chkUserMod.Checked = false;
                ResetValues();
                Calculate();
                CalculateCharge();

                CalculateEndorsement();
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
        protected void CalculateCharge()
        {
            try
            {
                if (Session["TaskControl"] != null)
                {
                    TaskControl.CorporatePolicyQuote taskControl = (TaskControl.CorporatePolicyQuote)Session["TaskControl"];
                    FillProperties();
                    DataTable dtCharge = LookupTables.LookupTables.GetTable("Charge");
                    int result = 0;

                    if (taskControl.Anniversary == "01")
                    {
                        for (int i = 0; i < dtCharge.Rows.Count; i++)
                        {
                            if (txtEffDt.Text != "")
                            {
                                result = DateTime.Compare(DateTime.Parse(txtEffDt.Text.ToString().Trim()),
                                         DateTime.Parse(dtCharge.Rows[i]["effectiveDate"].ToString()));

                                if (result == 0 || result == 1)
                                {

                                    double totalpremium = 0.00, cancellationAmount = 0.00;

                                    if (chkUserMod.Checked && TxtUserPremium.Text != "")
                                    {
                                        totalpremium = double.Parse(TxtUserPremium.Text.Trim());
                                    }
                                    else
                                    {
                                        if (TxtTotalPremium.Text != "")
                                            totalpremium = double.Parse(TxtTotalPremium.Text.Trim());
                                        else
                                            totalpremium = 0.00;
                                    }

                                    if (TxtCancAmount.Text != "")
                                        cancellationAmount = double.Parse(TxtCancAmount.Text.Trim());
                                    else
                                        cancellationAmount = 0.00;


                                    double chargePercent = double.Parse(dtCharge.Rows[i]["chargePercent"].ToString());
                                    var decPlaces = ((totalpremium * chargePercent) % 1) * 100;
                                    int rounded = 0;

                                    if (decPlaces >= 50)
                                        rounded = (int)Math.Ceiling(totalpremium * chargePercent);
                                    else
                                        rounded = (int)Math.Floor(totalpremium * chargePercent);

                                    TxtCharge.Text = rounded.ToString("###,###.#0").Trim();
                                    TxtPremium.Text = totalpremium.ToString("###,###.#0").Trim();
                                    TxtTotalPremium.Text = ((totalpremium + rounded) - taskControl.CancellationAmount).ToString("###,###.#0").Trim();
                                    taskControl.Charge = double.Parse(rounded.ToString("###,###.#0").Trim());
                                    Label60.Visible = true;
                                    Label60.Text = "Charge (" + chargePercent.ToString() + ")";

                                    //double chargePercent = double.Parse(dtCharge.Rows[i]["chargePercent"].ToString());
                                    //var decPlaces = ((taskControl.TotalPremium * chargePercent) % 1) * 100;
                                    //int rounded = 0;

                                    //if (decPlaces >= 50)
                                    //    rounded = (int)Math.Ceiling(taskControl.TotalPremium * chargePercent);
                                    //else
                                    //    rounded = (int)Math.Floor(taskControl.TotalPremium * chargePercent);

                                    //TxtCharge.Text = rounded.ToString("###,###.#0").Trim();
                                    //TxtTotalPremium.Text = ((taskControl.TotalPremium + rounded) - taskControl.CancellationAmount).ToString("###,###.#0").Trim();
                                    //taskControl.Charge = double.Parse(rounded.ToString("###,###.#0").Trim());
                                    //Label60.Visible = true;
                                    //Label60.Text = "Charge (" + chargePercent.ToString() + ")";
                                    break;
                                }
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

                                    double totalpremium = 0.00, cancellationAmount = 0.00;

                                    if (chkUserMod.Checked && TxtUserPremium.Text != "")
                                    {
                                        totalpremium = double.Parse(TxtUserPremium.Text.Trim());
                                    }
                                    else
                                    {
                                        if (TxtTotalPremium.Text != "")
                                            totalpremium = double.Parse(TxtTotalPremium.Text.Trim());
                                        else
                                            totalpremium = 0.00;
                                    }

                                    if (TxtCancAmount.Text != "")
                                        cancellationAmount = double.Parse(TxtCancAmount.Text.Trim());
                                    else
                                        cancellationAmount = 0.00;


                                    double chargePercent = double.Parse(dtCharge.Rows[i]["chargePercent"].ToString());
                                    var decPlaces = ((totalpremium * chargePercent) % 1) * 100;
                                    int rounded = 0;

                                    if (decPlaces >= 50)
                                        rounded = (int)Math.Ceiling(totalpremium * chargePercent);
                                    else
                                        rounded = (int)Math.Floor(totalpremium * chargePercent);

                                    TxtCharge.Text = rounded.ToString("###,###.#0").Trim();
                                    TxtPremium.Text = totalpremium.ToString("###,###.#0").Trim();
                                    TxtTotalPremium.Text = ((totalpremium + rounded) - taskControl.CancellationAmount).ToString("###,###.#0").Trim();
                                    taskControl.Charge = double.Parse(rounded.ToString("###,###.#0").Trim());
                                    Label60.Visible = true;
                                    Label60.Text = "Charge (" + chargePercent.ToString() + ")";

                                    //double chargePercent = double.Parse(dtCharge.Rows[i]["chargePercent"].ToString());
                                    //var decPlaces = ((taskControl.TotalPremium * chargePercent) % 1) * 100;
                                    //int rounded = 0;

                                    //if (decPlaces >= 50)
                                    //    rounded = (int)Math.Ceiling(taskControl.TotalPremium * chargePercent);
                                    //else
                                    //    rounded = (int)Math.Floor(taskControl.TotalPremium * chargePercent);

                                    //TxtCharge.Text = rounded.ToString("###,###.#0").Trim();
                                    //TxtPremium.Text = taskControl.TotalPremium.ToString("###,###.#0").Trim();
                                    //TxtTotalPremium.Text = ((taskControl.TotalPremium + rounded) - taskControl.CancellationAmount).ToString("###,###.#0").Trim();
                                    //taskControl.Charge = double.Parse(rounded.ToString("###,###.#0").Trim());
                                    //Label60.Visible = true;
                                    //Label60.Text = "(" + chargePercent.ToString() + ")";
                                    break;
                                }
                                else
                                    TxtCharge.Text = ".00";
                        }
                    }
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

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("An error ocurred while calculating charge.");
                this.litPopUp.Visible = true;
            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            CalculatePhysicians();
        }

        protected void CalculatePhysicians()
        {
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
            DateTime effectiveDate;

            double totPprem = 0.00;
            double totEprem = 0.00;
            for (int i = 0; i <= DtGridCorpaoratePol.Items.Count - 1; i++)
            {
                totPprem = totPprem + double.Parse(DtGridCorpaoratePol.Items[i].Cells[7].Text);
                totEprem = totEprem + double.Parse(DtGridCorpaoratePol.Items[i].Cells[8].Text);
            }

            if (txtDiscountP.Text.Trim() == "")
                txtDiscountP.Text = "0";

            if (txtDiscount.Text.Trim() == "")
                txtDiscount.Text = "0";

            double disc = 0.00;
            double totprem2 = 0.00;

            if (TxtRetroactiveDate.Text != "" && txtQuoteRetroDate.Text == "")
                txtQuoteRetroDate.Text = TxtRetroactiveDate.Text;

            DateTime retroActiveDate = Convert.ToDateTime(txtQuoteRetroDate.Text.Trim());
            if (txtEffDt.Text == String.Empty)
                effectiveDate = DateTime.Now;
            else
                effectiveDate = Convert.ToDateTime(txtEffDt.Text.Trim());
            TimeSpan result = effectiveDate - retroActiveDate;
            double days = (result.TotalDays + 1);
            double mcmRate = 0.0;

            if (days < 366)
                mcmRate = 0.6;
            else if (days < 731)
                mcmRate = 0.8;
            else if (days < 1096)
                mcmRate = 0.9;
            else
                mcmRate = 1;

            totPprem = totPprem * mcmRate;
            totEprem = totEprem * mcmRate;

            if (txtDiscountP.Text == "0")
            {
                disc = double.Parse(txtDiscountP.Text.Replace("%", "").Trim());
                totprem2 = totPprem;
                txtTotalPrimaryPremium.Text = totprem2.ToString("###,##0.00");
            }
            else
            {
                disc = double.Parse(txtDiscountP.Text.Replace("%", "").Trim());
                totprem2 = Math.Round((totPprem * (Math.Round(disc / 100, 2))), 0);
                txtTotalPrimaryPremium.Text = totprem2.ToString("###,##0.00");
            }

            if (ddlGroup2.SelectedIndex != 0) //Bank = Group
            {

                master = master.GetMasterPolicyDiscount(ddlGroup2.SelectedValue, DateTime.Now.ToShortDateString());

                double totprem = Math.Round(totprem2 - (totprem2 * (master.DescuentoPrimario / 100)), 0);
                this.txtTotalPrimaryPremium.Text = totprem.ToString("###,###,##0.00");
            }

            if (txtDiscount.Text == "0")
            {
                disc = double.Parse(txtDiscount.Text.Replace("%", "").Trim());
                totprem2 = totEprem;
                txtTotalExcessPremium.Text = totprem2.ToString("###,##0.00");
            }
            else
            {
                disc = double.Parse(txtDiscount.Text.Replace("%", "").Trim());
                totprem2 = Math.Round((totEprem * (Math.Round(disc / 100, 2))), 0);
                txtTotalExcessPremium.Text = totprem2.ToString("###,##0.00");
            }

            if (ddlGroup2.SelectedIndex != 0) //Bank = Group
            {
                master = master.GetMasterPolicyDiscount(ddlGroup2.SelectedValue, DateTime.Now.ToShortDateString());

                double totprem = Math.Round(totprem2 - (totprem2 * (master.DescuentoExcess / 100)), 0);
                this.txtTotalExcessPremium.Text = totprem.ToString("###,###,##0.00");
            }

            int quantity1 = 0;
            int quantity2 = 0;
            int quantity3 = 0;
            int quantity4 = 0;
            int quantity5 = 0;

            int Equantity1 = 0;
            int Equantity2 = 0;
            int Equantity3 = 0;
            int Equantity4 = 0;
            int Equantity5 = 0;

            if (txtQuantityTN1.Text.Trim() != "")
                quantity1 = int.Parse(txtQuantityTN1.Text.Trim());

            if (txtQuantityTN2.Text.Trim() != "")
                quantity2 = int.Parse(txtQuantityTN2.Text.Trim());

            if (txtQuantityTN3.Text.Trim() != "")
                quantity3 = int.Parse(txtQuantityTN3.Text.Trim());

            if (txtQuantityTN4.Text.Trim() != "")
                quantity4 = int.Parse(txtQuantityTN4.Text.Trim());

            if (txtQuantityTN5.Text.Trim() != "")
                quantity5 = int.Parse(txtQuantityTN5.Text.Trim());

            int quantity6 = quantity1 + quantity2 + quantity3 + quantity4 + quantity5;

            if (txtEQuantityTN1.Text.Trim() != "")
                Equantity1 = int.Parse(txtEQuantityTN1.Text.Trim());
            if (txtEQuantityTN2.Text.Trim() != "")
                Equantity2 = int.Parse(txtEQuantityTN2.Text.Trim());
            if (txtEQuantityTN3.Text.Trim() != "")
                Equantity3 = int.Parse(txtEQuantityTN3.Text.Trim());
            if (txtEQuantityTN4.Text.Trim() != "")
                Equantity4 = int.Parse(txtEQuantityTN4.Text.Trim());
            if (txtEQuantityTN5.Text.Trim() != "")
                Equantity5 = int.Parse(txtEQuantityTN5.Text.Trim());

            int Equantity6 = Equantity1 + Equantity2 + Equantity3 + Equantity4 + Equantity5;

            if (taskControl.Mode != 1)
            {
                if (quantity6 == 0 && Equantity6 == 0)
                {
                    if (TxtPolicyType.Text.Trim() == "CP")
                    {
                        TxtTotalPremium.Text = (double.Parse(txtTotalPrimaryPremium.Text.ToString()) + double.Parse(TxtCharge.Text.Trim())).ToString("###,###,##0.00");
                        TxtPremium.Text = double.Parse(txtTotalPrimaryPremium.Text).ToString("###,###,##0.00");
                    }
                    else
                    {
                        TxtTotalPremium.Text = (double.Parse(txtTotalExcessPremium.Text.ToString()) + double.Parse(TxtCharge.Text.Trim())).ToString("###,###,##0.00");
                        TxtPremium.Text = double.Parse(txtTotalExcessPremium.Text.ToString()).ToString("###,###,##0.00");
                    }
                }
            }
            else
            {
                if (quantity6 == 0 && Equantity6 == 0)
                {
                    if (TxtPolicyType.Text.Trim() == "CP")
                    {
                        TxtTotalPremium.Text = (double.Parse(txtTotalPrimaryPremium.Text.ToString())).ToString("###,###,##0.00");
                        TxtPremium.Text = double.Parse(txtTotalPrimaryPremium.Text).ToString("###,###,##0.00");
                    }
                    else
                    {
                        TxtTotalPremium.Text = (double.Parse(txtTotalExcessPremium.Text.ToString())).ToString("###,###,##0.00");
                        TxtPremium.Text = double.Parse(txtTotalExcessPremium.Text.ToString()).ToString("###,###,##0.00");
                    }
                }
            }
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
                Session["TaskControl"] = taskControl;
                Response.Redirect("CorporatePolicyQuote.aspx?" + taskControl.TaskControlID, true);
            }
            else  // Pager
            {
                DtSearchPayments.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                DtSearchPayments.DataSource = (DataTable)Session["DtTaskPolicy"];
                DtSearchPayments.DataBind();
            }
        }
        protected void btnHistory_Click(object sender, System.EventArgs e)
        {
            if (Session["TaskControl"] != null)
            {
                RemoveSessionLookUp();
                TaskControl.CorporatePolicyQuote taskControl = (TaskControl.CorporatePolicyQuote)Session["TaskControl"];
                Response.Redirect("SearchAuditItems.aspx?type=24&taskControlID=" +
                    taskControl.TaskControlID.ToString().Trim());
            }
        }
        protected void btnFinancialCanc_Click(object sender, EventArgs e)
        {
            RemoveSessionLookUp();
            Session.Add("FromUI", "CorporatePolicyQuote.aspx");
            Response.Redirect("FinancialCancellations.aspx", false);
        }
        protected void btnTailQuote_Click(object sender, EventArgs e)
        {
            //TaskControl.CorporatePolicyQuote taskControl = (TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            //taskControl.Mode = 5;
            //Session["TaskControl"] = taskControl;

            FillProperties();

            string js = "<script language=javascript> javascript:popwindow=window.open('TailQuote.aspx','popwindow','modal=yes,toolbar=no,location=center,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,copyhistory=no,width=445,height=300');popwindow.focus(); </script>";
            //string js = "<script language=javascript> window.showModalDialog('TailQuote.aspx','scrollbars:no,resizable:no,dialogWidth:430px,dialogHeight:270px');</script>";
            //string js = "<script language=javascript> javascript:popwindow=window.open('TailQuote.aspx','null,width=430,height=270,modal=yes,alwaysRaised=yes,null);</script>";
            //window.open("modal.htm", null, "width=200,height=200,left=300,modal=yes,alwaysRaised=yes", null);
            //Session.Clear();
            //Session["TaskControl"] = taskControl;
            //Response.Redirect("CorporatePolicyQuote.aspx?" + taskControl.TaskControlID, true);

            btnRefresh.Visible = true;
            Response.Write(js);
        }
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            FillGrid();
        }
        protected void DisableControlsTail()
        {
            TaskControl.CorporatePolicyQuote taskControl = (TaskControl.CorporatePolicyQuote)Session["TaskControl"];

            if (taskControl.PolicyType.Contains("T"))
            {
                btnRenew.Visible = false;
                //btnReinstatement.Visible = false;
                btnPrintCertificate.Visible = false;
                btnCancellation.Visible = false;
                btnFinancialCanc.Visible = false;
                btnTailQuote.Visible = false;
                btnEndor.Visible = false;

                Label5.Visible = false;
                TxtTerm.Visible = false;
                Label11.Visible = true;
                txtExpDt.Visible = true;
                //lblDiscount.Visible = false;
                //txtInvoiceNumber.Visible = false;
                ddlFinancial.Visible = false;
                lblFinancial.Visible = false;

                Label52.Visible = false;
                Label64.Visible = false;
                Button3.Visible = false;
                Label70.Visible = false;
                Label71.Visible = false;
                //txtTotalPrimary.Visible = false;
                //txtTotalExcess.Visible = false;
                pnlExcess.Visible = false;
                pnlPrimary.Visible = false;
                btnPolicyCert.Visible = false;
                btnEnablePrint.Visible = false;
            }
        }
        protected void btnPolicyCert_Click(object sender, EventArgs e)
        {
            TaskControl.CorporatePolicyQuote taskControl = (TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            try
            {
                if (taskControl.PolicyType.Trim() == "CP")
                {
                    DataDynamics.ActiveReports.ActiveReport3 rpt = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt1 = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt3 = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt4 = null;

                    rpt = new EPolicy2.Reports.PRMdic.PrimaryPolicy1((EPolicy.TaskControl.Policy)taskControl, true);
                    rpt.Document.Printer.PrinterName = "";
                    rpt.Run(false);

                    rpt1 = new EPolicy2.Reports.PRMdic.PrimaryPolicy2((EPolicy.TaskControl.Policy)taskControl, true);
                    rpt1.Document.Printer.PrinterName = "";
                    rpt1.Run(false);
                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt1.Document.Pages);

                    if (taskControl.EffectiveDate.Trim() != taskControl.RetroactiveDate.Trim())
                    {
                        rpt2 = new EPolicy2.Reports.PRMdic.PrimaryPriorAct((EPolicy.TaskControl.Policy)taskControl, true);
                        rpt2.Document.Printer.PrinterName = "";
                        rpt2.Run(false);
                        rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages);
                    }

                    rpt3 = new EPolicy2.Reports.PRMdic.PrimarySchedulerEndorsement((EPolicy.TaskControl.Policy)taskControl, true);
                    rpt3.Document.Printer.PrinterName = "";
                    rpt3.Run(false);
                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages);

                    rpt4 = new EPolicy2.Reports.PRMdic.PrimaryStatementAcceptance((EPolicy.TaskControl.Policy)taskControl, true);
                    rpt4.Document.Printer.PrinterName = "";
                    rpt4.Run(false);
                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt4.Document.Pages);

                    History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY CERT. DOCUMENT.");

                    RemoveSessionLookUp();
                    Session.Add("Report", rpt);
                    Session.Add("FromPage", "CorporatePolicyQuote.aspx");
                    Response.Redirect("ActiveXViewer.aspx");

                }
                else //CE.
                {
                    DataDynamics.ActiveReports.ActiveReport3 rpt = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt1 = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt3 = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt4 = null;

                    rpt = new EPolicy2.Reports.PRMdic.Poliza1(taskControl, true, taskControl.PrMedicalLimit);
                    rpt.Document.Printer.PrinterName = "";
                    rpt.Run(false);

                    rpt1 = new EPolicy2.Reports.PRMdic.Poliza2B(taskControl, true);
                    rpt1.Document.Printer.PrinterName = "";
                    rpt1.Run();
                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt1.Document.Pages);

                    if (taskControl.EffectiveDate.Trim() != taskControl.RetroactiveDate.Trim())
                    {
                        rpt2 = new EPolicy2.Reports.PRMdic.PriorAct(taskControl, true);
                        rpt2.Document.Printer.PrinterName = "";
                        rpt2.Run(false);
                        rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages); //Page 3
                    }

                    rpt3 = new EPolicy2.Reports.PRMdic.SchedulerEndorsement((EPolicy.TaskControl.Policy)taskControl, true);
                    rpt3.Document.Printer.PrinterName = "";
                    rpt3.Run(false);
                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages);

                    rpt4 = new EPolicy2.Reports.PRMdic.StatementAcceptance((EPolicy.TaskControl.Policy)taskControl, true);
                    rpt4.Document.Printer.PrinterName = "";
                    rpt4.Run(false);
                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt4.Document.Pages);

                    History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY CERT. DOCUMENT.");

                    RemoveSessionLookUp();
                    Session.Add("Report", rpt);
                    Session.Add("FromPage", "CorporatePolicyQuote.aspx");
                    Response.Redirect("ActiveXViewer.aspx");
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
        protected void btnComissions_Click(object sender, EventArgs e)
        {
            RemoveSessionLookUp();
            Session.Add("FromPage", "CorporatePolicyQuote.aspx");
            Response.Redirect("ViewCommission.aspx");
        }
        private void History(int taskControlID, int userID, string action, string subject, string note)
        {
            Audit.History history = new Audit.History();
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];

            history.Actions = action;
            history.KeyID = taskControlID.ToString();
            history.Subject = subject;
            //history.BuildNotesForHistory("TaskControlID.", "", taskControlID.ToString(), 7);  //7 = mode NOTICEOFCANC
            history.UsersID = userID;
            history.Notes = note + "\r\n";
            history.GetSaveHistory();
        }
        protected void btnEnablePrint_Click(object sender, EventArgs e)
        {
            try
            {
                EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];

                taskControl.PrintPolicy = false;
                FillProperties();
                History(taskControl.TaskControlID, userID, "LOCK", "POLICIES", "ENABLED POLICY PRINTING.");
                taskControl.SaveOnlyPolicy(userID);

                btnEnablePrint.Visible = false;
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

        //Print New Endorsement Report 
        private void PrintNewEndorsement(string FileName, bool CP)
        {
            try
            {
                Login.Login cp = HttpContext.Current.User as Login.Login;
                string _userID = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();
                _userID = _userID.ToString().Replace(" ", "");

                List<string> mergePaths = new List<string>();

                string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];

                string _FileName =  FileName;

                mergePaths.Add(_FileName);

                ReportParameter[] param = new ReportParameter[4];
                param[0] = new ReportParameter("PolicyNo", taskControl.PolicyType.Trim() + taskControl.PolicyNo.Trim());
                param[1] = new ReportParameter("Customer", taskControl.Customer.FirstName + taskControl.Customer.Initial + taskControl.Customer.LastName1 + taskControl.Customer.LastName2);                
                param[2] = new ReportParameter("Agency", taskControl.Agency);
                param[3] = new ReportParameter("City", taskControl.City.ToString());
                

                ReportViewer viewer = new ReportViewer();
                viewer.ProcessingMode = ProcessingMode.Local;
                if(CP)
                    viewer.LocalReport.ReportPath = Server.MapPath("Reports/ExclusionEndorsement2.rdlc");
                else
                    viewer.LocalReport.ReportPath = Server.MapPath("Reports/ExclusionEndorsement2CE.rdlc");

                viewer.LocalReport.SetParameters(param);

                Warning[] warnings;
                string[] streamIds;
                string mimeType;
                string encoding = string.Empty;
                string extension;

                string _FileNameNew = "ExclusionEndorsement2.PDF";
                

                if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileNameNew))
                    File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileNameNew);

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileNameNew, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
                mergePaths.Add(ProcessedPath+_FileNameNew);

                EPolicy.CreatePDFBatch mergeFinal = new CreatePDFBatch();

                string _FinalFile = "";

                _FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl.TaskControlID.ToString());

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + _FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);

            }
            catch (Exception ex)
            {

            }
        }
        protected void ObtainTotalPremiumsForReport()
        {
            for (int n = 0; n < DtGridCorpaoratePol.Items.Count; n++)
            {
                ddlPrimaryLimits1.SelectedIndex = ddlPrimaryLimits1.Items.IndexOf(ddlPrimaryLimits1.Items.FindByText(DtGridCorpaoratePol.Items[n].Cells[3].Text.Trim()));
                ddlLimits.SelectedIndex = ddlLimits.Items.IndexOf(ddlLimits.Items.FindByText(DtGridCorpaoratePol.Items[n].Cells[4].Text.Trim()));

                SetDDLLimit(int.Parse(ddlLimits.SelectedItem.Value), int.Parse(ddlPrimaryLimits1.SelectedItem.Value));

                ddPrimarylPolicyClass.SelectedIndex = ddPrimarylPolicyClass.Items.IndexOf(
                    ddPrimarylPolicyClass.Items.FindByText(DtGridCorpaoratePol.Items[n].Cells[5].Text.Trim()));

                ddlPolicyClass.SelectedIndex = ddlPolicyClass.Items.IndexOf(
                    ddlPolicyClass.Items.FindByText(DtGridCorpaoratePol.Items[n].Cells[5].Text.Trim()));

                string myStringPrimary = this.ddPrimarylPolicyClass.SelectedValue.Trim();
                string[] myPrimaryRateList = myStringPrimary.Split('|');

                this.HIPrimeryRateID.Value = myPrimaryRateList[0];

                string myString = this.ddlPolicyClass.SelectedValue.Trim();
                string[] myRateList = myString.Split('|');

                this.txtPrateID.Value = myRateList[0];
                this.txtIsoCode.Text = myRateList[1];

                this.txtRate4.Text = int.Parse(myRateList[6]).ToString("###,###,##0.00");

                //Sum Primary Premium of all the the doctors in the list.
                if (txtPRate.Text == "")
                    this.txtPRate.Text = (int.Parse(myPrimaryRateList[6])).ToString();
                else
                    this.txtPRate.Text = ((int.Parse(txtPRate.Text)) + (int.Parse(myPrimaryRateList[6]))).ToString();

                DataTable dtPRMEDICRATE2 = EPolicy.TaskControl.Application.GetPRMEDICRATEBYISOCODE(int.Parse(txtPrateID.Value), txtIsoCode.Text.Trim());

                if (dtPRMEDICRATE2.Rows.Count > 0)
                {
                    int index = 1;
                    for (int i = 0; dtPRMEDICRATE2.Rows.Count > i; i++)
                    {
                        myString = dtPRMEDICRATE2.Rows[i]["PRMEDICRATEID"].ToString().Trim();
                        myRateList = myString.Split('|');

                        if (dtPRMEDICRATE2.Rows[i]["PRMedicalLimitDesc"].ToString().Trim() == "150,000/200,000")
                        {
                            if (txtERate150_200.Text == "")
                                this.txtERate150_200.Text = (int.Parse(myRateList[6])).ToString();
                            else
                                this.txtERate150_200.Text = ((int.Parse(txtERate150_200.Text)) + (int.Parse(myRateList[6]))).ToString();
                        }
                        if (dtPRMEDICRATE2.Rows[i]["PRMedicalLimitDesc"].ToString().Trim() == "250,000/500,000")
                        {
                            if (txtERate250_500.Text == "")
                                this.txtERate250_500.Text = (int.Parse(myRateList[6])).ToString();
                            else
                                this.txtERate250_500.Text = ((int.Parse(txtERate250_500.Text)) + (int.Parse(myRateList[6]))).ToString();
                        }
                        if (dtPRMEDICRATE2.Rows[i]["PRMedicalLimitDesc"].ToString().Trim() == "400,000/700,000")
                        {
                            if (txtERate400_700.Text == "")
                                this.txtERate400_700.Text = (int.Parse(myRateList[6])).ToString();
                            else
                                this.txtERate400_700.Text = ((int.Parse(txtERate400_700.Text)) + (int.Parse(myRateList[6]))).ToString();
                        }
                        if (dtPRMEDICRATE2.Rows[i]["PRMedicalLimitDesc"].ToString().Trim() == "500,000/1,000,000")
                        {
                            if (txtERate500_1M.Text == "")
                                this.txtERate500_1M.Text = (int.Parse(myRateList[6])).ToString();
                            else
                                this.txtERate500_1M.Text = ((int.Parse(txtERate500_1M.Text)) + (int.Parse(myRateList[6]))).ToString();
                        }
                        if (dtPRMEDICRATE2.Rows[i]["PRMedicalLimitDesc"].ToString().Trim() == "1,000,000/3,000,000")
                        {
                            if (txtERate1M_3M.Text == "")
                                this.txtERate1M_3M.Text = (int.Parse(myRateList[6])).ToString();
                            else
                                this.txtERate1M_3M.Text = ((int.Parse(txtERate1M_3M.Text)) + (int.Parse(myRateList[6]))).ToString();
                        }

                        if (int.Parse(txtPrateID.Value.Trim()) != int.Parse(myRateList[0].Trim()))
                        {
                            //SetOtherRateFields(index, myRateList);
                            index = index + 1;
                        }
                    }
                }
            }

            ddlPolicyClass.SelectedIndex = -1;
            ddPrimarylPolicyClass.SelectedIndex = -1;
            ddlPrimaryLimits1.SelectedIndex = -1;
            ddlLimits.SelectedIndex = -1;

            txtIsoCode.Text = "";
            txtRate4.Text = "";
            txtPRate4.Text = "";
        }

        #region Old Endorsement

        //protected void DataGridGroup_ItemCommand(object source, DataGridCommandEventArgs e)
        //{
        //    try
        //    {
        //        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        //        int userID = 0;
        //        userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

        //        switch (e.CommandName)
        //        {
        //            case "Select":
        //                DataGridGroup.DataSource = null;

        //                int i = int.Parse(e.Item.Cells[2].Text);
        //                EPolicy.TaskControl.CorporatePolicyQuote opp = (EPolicy.TaskControl.CorporatePolicyQuote)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(i, userID);
        //                opp.Mode = (int)EPolicy.TaskControl.TaskControl.TaskControlMode.CLEAR;
        //                opp.isEndorsement = true;

        //                if (Session["TaskControl"] != null)
        //                {
        //                    EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
        //                    Session.Clear();
        //                    Session.Add("PLEndorsement", taskControl);
        //                    Session.Add("PLEndorUpdate", "Update");
        //                    Session.Remove("TaskControl");
        //                }

        //                Session.Add("TaskControl", opp);
        //                Response.Redirect("CorporatePolicyQuote.aspx");
        //                break;

        //            case "Apply":
        //                DataGridGroup.DataSource = null;

        //                string date = e.Item.Cells[3].Text.Trim();
        //                if (date.ToString().Trim() != " ")
        //                {
        //                    throw new Exception("This Endorsement is already Applied.");
        //                }

        //                int a = int.Parse(e.Item.Cells[2].Text);
        //                EPolicy.TaskControl.CorporatePolicyQuote newOPP = (EPolicy.TaskControl.CorporatePolicyQuote)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(a, userID);

        //                int OPPEndorsementID = int.Parse(e.Item.Cells[1].Text);
        //                Session.Add("PLEndorsementID", OPPEndorsementID);
        //                //Buscar Quotes para endosar
        //                Panel3.Visible = true;
        //                txtEffDtEndorsement.Text = e.Item.Cells[4].Text.Trim(); //DateTime.Now.ToShortDateString();
        //                txtFactor.Text = e.Item.Cells[5].Text.Trim();
        //                txtProRata.Text = e.Item.Cells[6].Text.Trim();
        //                txtShortRate.Text = e.Item.Cells[7].Text.Trim();
        //                txtActualPremTotal.Text = e.Item.Cells[16].Text.Trim();
        //                txtPreviousPremTotal.Text = e.Item.Cells[21].Text.Trim();
        //                txtDiffPremTotal.Text = e.Item.Cells[26].Text.Trim();
        //                txtAdditionalPremium.Text = e.Item.Cells[27].Text.Trim();

        //                CalculateEndorsement(newOPP);
        //                VerifyChanges(newOPP, userID);
        //                Session.Add("ApplyEndorsement", a);
        //                //ApplyEndorsement(newOPP, userID);
        //                break;

        //            case "Update":
        //                DataGridGroup.DataSource = null;

        //                string date3 = e.Item.Cells[4].Text.Trim();
        //                if (date3.ToString().Trim() == " ")
        //                {
        //                    throw new Exception("This Endorsement is not Applied.");
        //                }

        //                //int a = int.Parse(e.Item.Cells[2].Text);
        //                //EPolicy.TaskControl.Dwelling newOPP = (EPolicy.TaskControl.Dwelling)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(a, userID);

        //                int OPPEndorsement3ID = int.Parse(e.Item.Cells[1].Text);
        //                Session.Add("PLEndorsementID", OPPEndorsement3ID);
        //                Session.Add("PLEndorUpdate", "Update");
        //                //Buscar Quotes para endosar
        //                Panel3.Visible = true;
        //                txtEffDtEndorsement.Text = e.Item.Cells[4].Text.Trim();
        //                txtFactor.Text = e.Item.Cells[5].Text.Trim();
        //                txtProRata.Text = e.Item.Cells[6].Text.Trim();
        //                txtShortRate.Text = e.Item.Cells[7].Text.Trim();
        //                txtEndoComments.Text = e.Item.Cells[10].Text.Trim();
        //                txtActualPremTotal.Text = e.Item.Cells[16].Text.Trim();
        //                txtPreviousPremTotal.Text = e.Item.Cells[21].Text.Trim();
        //                txtDiffPremTotal.Text = e.Item.Cells[26].Text.Trim();
        //                txtAdditionalPremium.Text = e.Item.Cells[27].Text.Trim();
        //                break;

        //            case "Print":
        //                //DataGridGroup.DataSource = null;

        //                //string date2 = e.Item.Cells[4].Text.Trim();
        //                //if (date2.ToString().Trim() == " ")
        //                //{
        //                //    throw new Exception("This Endorsement is not Applied.");
        //                //}

        //                //EPolicy.TaskControl.CorporatePolicyQuote taskControl2 = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];

        //                //int s = int.Parse(e.Item.Cells[2].Text);
        //                //string comments = e.Item.Cells[10].Text.Trim();
        //                //EPolicy.TaskControl.CorporatePolicyQuote newOPP2 = (EPolicy.TaskControl.CorporatePolicyQuote)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(s, userID);
        //                //int OPPEndorID = int.Parse(e.Item.Cells[1].Text);

        //                ////Print Document
        //                //try
        //                //{
        //                //    EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];

        //                //    GetReportEndosoTableAdapters.GetReportEndosoTableAdapter ds = new GetReportEndosoTableAdapters.GetReportEndosoTableAdapter();
        //                //    ReportDataSource rds = new ReportDataSource("GetReportEndoso_GetReportEndoso", ds.GetData(OPPEndorID));

        //                //    ReportViewer viewer = new ReportViewer();
        //                //    viewer.LocalReport.DataSources.Clear();
        //                //    viewer.ProcessingMode = ProcessingMode.Local;
        //                //    viewer.LocalReport.ReportPath = Server.MapPath("Reports/Endoso.rdlc");
        //                //    viewer.LocalReport.DataSources.Add(rds);
        //                //    viewer.LocalReport.Refresh();

        //                //    //viewer.LocalReport.DataSources.Add(rds);

        //                //    // Variables 
        //                //    Warning[] warnings;
        //                //    string[] streamIds;
        //                //    string mimeType;
        //                //    string encoding = string.Empty;
        //                //    string extension;
        //                //    string fileName = taskControl.Prospect.FirstName.Trim().Replace("?", "n").Replace("?", "N") + taskControl.Prospect.LastName1.Trim().Replace("?", "n").Replace("?", "N") + taskControl.TaskControlID.ToString().Trim() + OPPEndorID.ToString().Trim();
        //                //    string _FileName = taskControl.Prospect.FirstName.Trim().Replace("?", "n").Replace("?", "N") + taskControl.Prospect.LastName1.Trim().Replace("?", "n").Replace("?", "N") + taskControl.TaskControlID.ToString().Trim() + OPPEndorID.ToString().Trim() + ".pdf";
        //                //    //??
        //                //    if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
        //                //        File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

        //                //    byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

        //                //    using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
        //                //    {
        //                //        fs.Write(bytes, 0, bytes.Length);
        //                //    }

        //                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + _FileName + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);

        //                //}
        //                //catch (Exception ecp)
        //                //{

        //                //}

        //                break;

        //            default: //Page
        //                DataGridGroup.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

        //                DataGridGroup.DataSource = (DataTable)Session["dtPermission"];
        //                DataGridGroup.DataBind();
        //                break;
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
        //        this.litPopUp.Visible = true;

        //        //lblRecHeader.Text = exp.Message;
        //        //mpeSeleccion.Show();
        //    }
        //}

        //protected void DataGridGroup_ItemDataBound(object sender, DataGridItemEventArgs e)
        //{
        //    DataTable dtCol = (DataTable)Session["DtEndorsement"];
        //    DataColumnCollection dc = dtCol.Columns;

        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        DateTime EndoEffectiveField;

        //        if (DataBinder.Eval(e.Item.DataItem, "EndoEffective") != System.DBNull.Value)
        //        {
        //            EndoEffectiveField = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "EndoEffective", "{0:MM/dd/yyyy}"));
        //            e.Item.Cells[4].Text = EndoEffectiveField.ToShortDateString();
        //        }
        //    }
        //}

        //protected void Button6_Click(object sender, EventArgs e)
        //{
        //    Session.Remove("PLEndorUpdate");
        //    Session.Remove("PLEndorsementID");
        //    Session.Remove("ApplyEndorsement");
        //    Panel3.Visible = false;
        //}

        //protected void Button5_Click(object sender, EventArgs e)
        //{
        //    EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        //    int userID = 0;
        //    userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

        //    if (Session["PLEndorUpdate"] == null)
        //    {
        //        // Salvar el num. de Endo en Policy
        //        EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
        //        //int endNum = taskControl.Endoso + 1;
        //        //taskControl.Endoso = endNum;
        //        taskControl.SaveOnlyPolicy(userID);
        //        Session["TaskControl"] = taskControl;
        //    }

        //    if (Session["ApplyEndorsement"] != null)
        //    {
        //        int a = (int)Session["ApplyEndorsement"];
        //        EPolicy.TaskControl.CorporatePolicyQuote newOPP2 = (EPolicy.TaskControl.CorporatePolicyQuote)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(a, userID);

        //        ApplyEndorsement(newOPP2, userID);
        //    }

        //    // Salvar la info en OPP Endorsement.
        //    UpdateOPPEndorsement();

        //    Session.Remove("PLEndorsementID");
        //    Session.Remove("PLEndorUpdate");
        //    Session.Remove("ApplyEndorsement");
        //    Panel3.Visible = false;

        //    FillDataGrid();
        //}

        //private void CalculateEndorsement(EPolicy.TaskControl.CorporatePolicyQuote OpptaskControl)
        //{
        //    EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];

        //    double totprem = SetEndorsementToCalculateDifference(taskControl, OpptaskControl);

        //    double mFactor = 0.0;
        //    double NewProRataTotPrem = 0.0;
        //    double NewShotRateTotPrem = 0.0;
        //    string EndorDate = txtEffDtEndorsement.Text.Trim();
        //    //Si no es Flat no hace calculo de prima prorrateada.
        //    if (taskControl.EffectiveDate != EndorDate.Trim())
        //    {
        //        TimeSpan tsDAYS1 = DateTime.Parse(taskControl.ExpirationDate) - DateTime.Parse(EndorDate.Trim());
        //        TimeSpan tsDAYS2 = DateTime.Parse(taskControl.ExpirationDate) - DateTime.Parse(taskControl.EffectiveDate);

        //        int mDAYS1 = tsDAYS1.Days;
        //        int mDAYS2 = tsDAYS2.Days;

        //        mFactor = double.Parse(mDAYS1.ToString()) / double.Parse(mDAYS2.ToString());
        //        mFactor = Math.Round(mFactor, 3);
        //        NewProRataTotPrem = Math.Round(totprem * mFactor, 0);
        //        NewShotRateTotPrem = Math.Round(NewProRataTotPrem * 0.9, 0);

        //        txtFactor.Text = mFactor.ToString().Trim();
        //        txtProRata.Text = NewProRataTotPrem.ToString().Trim();
        //        txtShortRate.Text = NewShotRateTotPrem.ToString().Trim();
        //        txtAdditionalPremium.Text = NewProRataTotPrem.ToString("###,###,##0.00");
        //    }
        //    else
        //    {

        //        txtAdditionalPremium.Text = "0.0";
        //    }
        //}

        //private double SetEndorsementToCalculateDifference(EPolicy.TaskControl.CorporatePolicyQuote taskControl, EPolicy.TaskControl.CorporatePolicyQuote OpptaskControl)
        //{
        //    txtPreviousPremTotal.Text = taskControl.TotalPremium.ToString("###,###,##0.00");
        //    txtActualPremTotal.Text = OpptaskControl.TotalPremium.ToString("###,###,##0.00");

        //    //Calculate Difference
        //    double totalPrev = taskControl.TotalPremium + taskControl.Charge;
        //    double totalActual = OpptaskControl.TotalPremium + OpptaskControl.Charge;

        //    txtDiffPremTotal.Text = CalculateEndorsementDifference(totalActual.ToString(), totalPrev.ToString());

        //    return double.Parse(txtDiffPremTotal.Text);
        //}

        //private string CalculateEndorsementDifference(string ActualValue, string PreviousValue)
        //{
        //    double actual = 0.0;
        //    double previous = 0.0;
        //    double result = 0.0;

        //    actual = double.Parse(ActualValue);
        //    previous = double.Parse(PreviousValue);
        //    result = actual - previous;

        //    return result.ToString("###,###,##0.00");
        //}

        //private void AddOPPEndorsement(int OPPTaskControlID, int OPPQuotesID, double mFactor, double NewProRataTotPrem, double NewShotRateTotPrem)
        //{
        //    Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
        //    try
        //    {
        //        Executor.BeginTrans();
        //        int a = Executor.Insert("AddOPPEndorsement", this.GetInsertOPPEndorsementXml(OPPTaskControlID, OPPQuotesID, mFactor, NewProRataTotPrem, NewShotRateTotPrem));
        //        Executor.CommitTrans();
        //    }
        //    catch (Exception xcp)
        //    {
        //        Executor.RollBackTrans();
        //        throw new Exception("Error while trying to save Endorsement Quote. " + xcp.Message, xcp);
        //    }
        //}

        //private void UpdateOPPEndorsement()
        //{
        //    Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
        //    try
        //    {
        //        Executor.BeginTrans();
        //        Executor.Update("UpdateOPPEndorsement", this.GetUpdateOPPEndorsementXml());
        //        Executor.CommitTrans();
        //    }
        //    catch (Exception xcp)
        //    {
        //        Executor.RollBackTrans();
        //        throw new Exception("Error while trying to save Endorsement Quote. " + xcp.Message, xcp);
        //    }
        //}

        //private XmlDocument GetInsertOPPEndorsementXml(int OPPTaskControlID, int OPPQuotesID, double mFactor, double NewProRataTotPrem, double NewShotRateTotPrem)
        //{
        //    DbRequestXmlCookRequestItem[] cookItems =
        //        new DbRequestXmlCookRequestItem[22];

        //    DbRequestXmlCooker.AttachCookItem("OPPTaskControlID", SqlDbType.Int, 0, OPPTaskControlID.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("OPPQuotesID", SqlDbType.Int, 0, OPPQuotesID.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("EndoEffective", SqlDbType.DateTime, 0, txtEntryDate.Text, ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("Factor", SqlDbType.Float, 0, mFactor.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ProRataPremium", SqlDbType.Float, 0, NewProRataTotPrem.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ShortRatePremium", SqlDbType.Float, 0, NewShotRateTotPrem.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ActualPremPropeties", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ActualPremLiability", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ActualPremAuto", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ActualPremUmbrella", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ActualPremTotal", SqlDbType.Float, 0, txtActualPremTotal.Text.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("PreviousPremProperties", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("PreviousPremLiability", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("PreviousPremAuto", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("PreviousPremUmbrella", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("PreviousPremTotal", SqlDbType.Float, 0, txtPreviousPremTotal.Text.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("DiffPremProperties", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("DiffPremLiability", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("DiffPremAuto", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("DiffPremUmbrella", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("DiffPremTotal", SqlDbType.Float, 0, txtDiffPremTotal.Text.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("AdditionalPremium", SqlDbType.Float, 0, txtAdditionalPremium.Text.ToString(), ref cookItems);

        //    XmlDocument xmlDoc;

        //    try
        //    {
        //        xmlDoc = DbRequestXmlCooker.Cook(cookItems);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Could not cook items.", ex);
        //    }

        //    return xmlDoc;
        //}

        //private XmlDocument GetUpdateOPPEndorsementXml()
        //{
        //    DbRequestXmlCookRequestItem[] cookItems =
        //        new DbRequestXmlCookRequestItem[23];

        //    EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
        //    int OPPEndorsementID = (int)Session["PLEndorsementID"];

        //    DbRequestXmlCooker.AttachCookItem("OPPEndorsementID", SqlDbType.Int, 0, OPPEndorsementID.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("EndoEffective", SqlDbType.DateTime, 0, txtEffDtEndorsement.Text.Trim(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("EndoNum", SqlDbType.Char, 4, taskControl.Endoso.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("Cambios", SqlDbType.VarChar, 5000, txtEndoComments.Text.Trim(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("Factor", SqlDbType.Float, 0, txtFactor.Text.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ProRataPremium", SqlDbType.Float, 0, txtProRata.Text.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ShortRatePremium", SqlDbType.Float, 0, txtShortRate.Text.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ActualPremPropeties", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ActualPremLiability", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ActualPremAuto", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ActualPremUmbrella", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ActualPremTotal", SqlDbType.Float, 0, txtActualPremTotal.Text.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("PreviousPremProperties", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("PreviousPremLiability", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("PreviousPremAuto", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("PreviousPremUmbrella", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("PreviousPremTotal", SqlDbType.Float, 0, txtPreviousPremTotal.Text.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("DiffPremProperties", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("DiffPremLiability", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("DiffPremAuto", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("DiffPremUmbrella", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("DiffPremTotal", SqlDbType.Float, 0, txtDiffPremTotal.Text.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("AdditionalPremium", SqlDbType.Float, 0, txtAdditionalPremium.Text.ToString(), ref cookItems);
        //    XmlDocument xmlDoc;

        //    try
        //    {
        //        xmlDoc = DbRequestXmlCooker.Cook(cookItems);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Could not cook items.", ex);
        //    }

        //    return xmlDoc;
        //}

        //private void VerifyChanges(EPolicy.TaskControl.CorporatePolicyQuote newOPP, int userID)
        //{
        //    EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
        //    EPolicy.Audit.History history = new EPolicy.Audit.History();
        //    int mode = 2; //Update

        //    // Campos de TaskControl
        //    //history.BuildNotesForHistory("Agency", taskControl.Agency, newOPP.Agency, mode);
        //    //history.BuildNotesForHistory("Agent", taskControl.Agent, newOPP.Agent, mode);
        //    history.BuildNotesForHistory("InsuranceCompany",
        //        EPolicy.LookupTables.LookupTables.GetDescription("InsuranceCompany", taskControl.InsuranceCompany.ToString()),
        //        EPolicy.LookupTables.LookupTables.GetDescription("InsuranceCompany", newOPP.InsuranceCompany.ToString()),
        //        mode);
        //    // Terminan Campos TaskControl

        //    //Campos de Customer
        //    history.BuildNotesForHistory("Name", taskControl.Customer.FirstName, newOPP.Customer.FirstName, mode);
        //    history.BuildNotesForHistory("Initial", taskControl.Customer.Initial, newOPP.Customer.Initial, mode);
        //    history.BuildNotesForHistory("LastName", taskControl.Customer.LastName1, newOPP.Customer.LastName1, mode);
        //    history.BuildNotesForHistory("LastName2", taskControl.Customer.LastName2, newOPP.Customer.LastName2, mode);
        //    history.BuildNotesForHistory("Address1", taskControl.Customer.Address1, newOPP.Customer.Address1, mode);
        //    history.BuildNotesForHistory("Address2", taskControl.Customer.Address2, newOPP.Customer.Address2, mode);
        //    history.BuildNotesForHistory("City", taskControl.Customer.City, newOPP.Customer.City, mode);
        //    history.BuildNotesForHistory("State", taskControl.Customer.State, newOPP.Customer.State, mode);
        //    history.BuildNotesForHistory("ZipCode", taskControl.Customer.ZipCode, newOPP.Customer.ZipCode, mode);
        //    // Terminan Campos Customer

        //    // Campos de Policy
        //    history.BuildNotesForHistory("PolicyType", taskControl.PolicyType, newOPP.PolicyType, mode);
        //    history.BuildNotesForHistory("PolicyNo", taskControl.PolicyNo, newOPP.PolicyNo, mode);
        //    history.BuildNotesForHistory("Certificate", taskControl.Certificate, newOPP.Certificate, mode);
        //    history.BuildNotesForHistory("Suffix", taskControl.Suffix, newOPP.Suffix, mode);
        //    history.BuildNotesForHistory("LoanNo", taskControl.LoanNo.ToString(), newOPP.LoanNo.ToString(), mode);
        //    history.BuildNotesForHistory("Term", taskControl.Term.ToString(), newOPP.Term.ToString(), mode);
        //    history.BuildNotesForHistory("EffectiveDate", taskControl.EffectiveDate.ToString(), newOPP.EffectiveDate.ToString(), mode);
        //    history.BuildNotesForHistory("ExpirationDate", taskControl.ExpirationDate.ToString(), newOPP.ExpirationDate.ToString(), mode);
        //    history.BuildNotesForHistory("Charge", taskControl.Charge.ToString(), newOPP.Charge.ToString(), mode);
        //    history.BuildNotesForHistory("TotalPremium", taskControl.TotalPremium.ToString(), newOPP.TotalPremium.ToString(), mode);
        //    // Terminan Campos Policy

        //    history.Actions = "EDIT";

        //    //history.KeyID = this.TaskControlID.ToString();
        //    //history.Subject = "CorporatePolicyQuote";
        //    //history.UsersID = userID;
        //    //history.GetNotes();
        //    txtEndoComments.Text = history.Notes.ToUpper().Trim();
        //    history.GetSaveHistory();
        //}

        //private void FillDataGrid()
        //{
        //    EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];

        //    DataGridGroup.DataSource = null;
        //    DtEndorsement = null;

        //    DtEndorsement = taskControl.EndorsementCollection;

        //    Session.Remove("DtEndorsement");
        //    Session.Add("DtEndorsement", DtEndorsement);

        //    if (DtEndorsement != null)
        //    {
        //        if (DtEndorsement.Rows.Count != 0)
        //        {
        //            DataGridGroup.DataSource = DtEndorsement;
        //            DataGridGroup.DataBind();
        //        }
        //    }
        //    else
        //    {
        //        DataGridGroup.DataSource = null;
        //        DataGridGroup.DataBind();
        //    }
        //}

        //private void ApplyEndorsement(EPolicy.TaskControl.CorporatePolicyQuote newOPP, int userID)
        //{
        //    EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
        //    taskControl.Mode = 2; //EDIT
        //    int endNum = taskControl.Endoso + 1;
        //    taskControl.Endoso = endNum;
        //    Session["TaskControl"] = taskControl;
        //    taskControl.SaveOnlyPolicy(userID);

        //    UpdateOPPEndorsement();

        //    FillDataGrid();
        //    Session["TaskControl"] = taskControl;
        //}

        //protected void btnEndor_Click(object sender, EventArgs e)
        //{
        //    EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        //    int userID = 0;
        //    userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
        //    EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];

        //    //Session.Clear();
        //    EPolicy.TaskControl.CorporatePolicyQuote taskControlQuote = new EPolicy.TaskControl.CorporatePolicyQuote(true);
        //    taskControlQuote.isEndorsement = true;

        //    int tcID = taskControl.TaskControlID;
        //    taskControlQuote = taskControl;
        //    taskControlQuote.Customer = taskControl.Customer;
        //    taskControlQuote.Prospect = taskControl.Prospect;

        //    //Para aplicar el ultimo endoso, sino a la poliza original
        //    //DataTable endososList = EPolicy.TaskControl.OptimaPersonalPackage.GetEndorsementByEndoNum(tcID);
        //    //if (endososList.Rows.Count == 0)
        //    //{
        //        taskControlQuote = taskControl;
        //        taskControlQuote.Customer = taskControl.Customer;
        //        taskControlQuote.Prospect = taskControl.Prospect;

        //        taskControlQuote.Mode = 1; //ADD
        //        taskControlQuote.TaskControlID = 0;
        //        taskControlQuote.isEndorsement = true;
        //        taskControlQuote.TaskControlTypeID = int.Parse(EPolicy.LookupTables.LookupTables.GetID("TaskControlType", "CorporatePolicyQuote"));
        ////    }
        ////    else
        ////    {
        ////        //Aplica al Ultimo endoso
        ////        bool isExistEndo = false;
        ////        EPolicy.TaskControl.Policies taskControlEndo = null; ;
        ////        for (int s = 1; s <= endososList.Rows.Count; s++)
        ////        {
        ////            if ((int)endososList.Rows[endososList.Rows.Count - s]["OPPQuotesID"] != 0)
        ////            {
        ////                taskControlEndo = EPolicy.TaskControl.Policies.GetPolicies((int)endososList.Rows[endososList.Rows.Count - s]["OPPQuotesID"], true);
        ////                isExistEndo = true;
        ////                s = endososList.Rows.Count;
        ////            }
        ////        }

        ////        if (!isExistEndo)
        ////        {
        ////            taskControlQuote = taskControl;
        ////            taskControlQuote.Customer = taskControl.Customer;
        ////            taskControlQuote.Prospect = taskControl.Prospect;

        ////            taskControlQuote.Mode = 1; //ADD
        ////            taskControlQuote.TaskControlID = 0;
        ////            taskControlQuote.isEndorsement = true;
        ////            taskControlQuote.TaskControlTypeID = int.Parse(EPolicy.LookupTables.LookupTables.GetID("TaskControlType", "CorporatePolicyQuote"));
        ////        }
        ////        else
        ////        {
        ////            taskControlQuote = taskControlEndo;
        ////            taskControlQuote.Customer = taskControl.Customer;
        ////            taskControlQuote.Prospect = taskControl.Prospect;

        ////            taskControlQuote.Mode = 1; //ADD
        ////            taskControlQuote.TaskControlID = 0;
        ////            taskControlQuote.isEndorsement = true;
        ////            taskControlQuote.TaskControlTypeID = int.Parse(EPolicy.LookupTables.LookupTables.GetID("TaskControlType", "CorporatePolicyQuote"));
        ////        }
        ////    }

        //        taskControlQuote.Mode = 1; //ADD
        //        taskControlQuote.TaskControlID = 0;
        //        //taskControlQuote.IsQuote = true;
        //        taskControlQuote.isEndorsement = true;
        //        taskControlQuote.TaskControlTypeID = int.Parse(EPolicy.LookupTables.LookupTables.GetID("TaskControlType", "CorporatePolicyQuote"));

        //        taskControlQuote.TCIDQuotes = 0;

        //        string EndoDateTemp = DateTime.Now.ToShortDateString();
        //        EPolicy.TaskControl.CorporatePolicyQuote taskControl2 = (EPolicy.TaskControl.CorporatePolicyQuote)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(tcID, userID);
        //        Session.Remove("TaskControl");
        //        Session.Add("TaskControl", taskControlQuote);
        //        Session.Add("PLEndorsement", taskControl2);
        //        Session.Add("PLEndorsementDate", EndoDateTemp);

        //        pnlEndorsement.Visible = true;
        //        Panel3.Visible = false;
        //        Panel2.Visible = true;
        //        DataGridGroup.Visible = false;

        //        RemoveSessionLookUp();
        //        Response.Redirect("CorporatePolicyQuote.aspx");
        //}

        //private void CalculateEndorsementOnlyForQuote()
        //{
        //    EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
        //    EPolicy.TaskControl.CorporatePolicyQuote OldOPP = (EPolicy.TaskControl.CorporatePolicyQuote)Session["PLEndorsement"];

        //    double totprem = SetEndorsementToCalculateDifferenceOnlyForQuote(OldOPP, taskControl);

        //    double mFactor = 0.0;
        //    double NewProRataTotPrem = 0.0;
        //    double NewShotRateTotPrem = 0.0;
        //    string EndorDate = txtEntryDate.Text.Trim();
        //    //Si no es Flat no hace calculo de prima prorrateada.
        //    if (taskControl.EffectiveDate != EndorDate.Trim())
        //    {
        //        TimeSpan tsDAYS1 = DateTime.Parse(taskControl.ExpirationDate) - DateTime.Parse(EndorDate.Trim());
        //        TimeSpan tsDAYS2 = DateTime.Parse(taskControl.ExpirationDate) - DateTime.Parse(taskControl.EffectiveDate);

        //        int mDAYS1 = tsDAYS1.Days;
        //        int mDAYS2 = tsDAYS2.Days;

        //        mFactor = double.Parse(mDAYS1.ToString()) / double.Parse(mDAYS2.ToString());
        //        mFactor = Math.Round(mFactor, 4);
        //        NewProRataTotPrem = Math.Round(totprem * mFactor, 0);
        //        NewShotRateTotPrem = Math.Round(NewProRataTotPrem * 0.9, 0);

        //        txtOriginalPremiumQuote.Text = OldOPP.TotalPremium.ToString("###,##0.00");
        //        txtFactorQuote.Text = mFactor.ToString().Trim();
        //        txtProRataQuote.Text = NewProRataTotPrem.ToString("###,###,##0.00");
        //        //txtShortRate.Text = NewShotRateTotPrem.ToString().Trim();
        //        txtAdditionalPremium.Text = NewProRataTotPrem.ToString("###,###,##0.00");

        //        double totpremTemp = OldOPP.TotalPremium;
        //        txtProRataPremium.Text = (totpremTemp + double.Parse(txtAdditionalPremium.Text.Trim())).ToString("###,##0.00");
        //    }
        //    else
        //    {
        //        txtOriginalPremiumQuote.Text = OldOPP.TotalPremium.ToString("###,##0.00");
        //        txtFactorQuote.Text = "0";
        //        txtProRataQuote.Text = "0.00";
        //        txtAdditionalPremium.Text = "0.00";
        //        txtProRataPremium.Text = OldOPP.TotalPremium.ToString("###,###,##0.00");
        //    }
        //}

        //private double SetEndorsementToCalculateDifferenceOnlyForQuote(EPolicy.TaskControl.CorporatePolicyQuote taskControl, EPolicy.TaskControl.CorporatePolicyQuote OpptaskControl)
        //{
        //    string _ActualPremTotal = OpptaskControl.TotalPremium.ToString("###,###,##0.00");
        //    string _PreviousPremTotal = taskControl.TotalPremium.ToString("###,###,##0.00");

        //    //Calculate Difference

        //    double totalPrev = taskControl.TotalPremium + taskControl.Charge;
        //    double totalActual = OpptaskControl.TotalPremium + OpptaskControl.Charge;

        //    string _DiffPremTotal = CalculateEndorsementDifferenceOnlyForQuote(totalActual.ToString(), totalPrev.ToString());

        //    return double.Parse(_DiffPremTotal);
        //}

        //private string CalculateEndorsementDifferenceOnlyForQuote(string ActualValue, string PreviousValue)
        //{
        //    double actual = 0.0;
        //    double previous = 0.0;
        //    double result = 0.0;

        //    actual = double.Parse(ActualValue);
        //    previous = double.Parse(PreviousValue);
        //    result = actual - previous;

        //    return result.ToString("###,###,##0.00");
        //}

        #endregion

        #region Endorsements
        protected void btnEndor_Click(object sender, EventArgs e)
        {
            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
            int userID = 0;
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            //EPolicy.TaskControl.Policies taskControl2 = (EPolicy.TaskControl.Policies)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControlID, userID);

            Session.Add("PreviousPremium", taskControl.TotalPremium);
            Session.Add("OriginalPolicy", taskControl);

            taskControl.isEndorsement = true;
            previousPremium = taskControl.TotalPremium;
            taskControl.Mode = (int)TaskControl.TaskControl.TaskControlMode.UPDATE;

            Session.Add("TaskControl", taskControl);

            RemoveSessionLookUp();
            Response.Redirect("CorporatePolicyQuote.aspx");
        }

        private void CalculateEndorsement()
        {
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            EPolicy.TaskControl.CorporatePolicyQuote OldOPP = (EPolicy.TaskControl.CorporatePolicyQuote)Session["OriginalPolicy"];
            previousPremium = (double)Session["PreviousPremium"];

            double number = 0;
            bool result = false;

            if (txtEndoPremium.Text != "")
            {
                result = Double.TryParse(txtEndoPremium.Text, out number);
                if (!result)
                    throw new Exception("Invalid value entered in endorsement value.  Please verify.");
            }

            if (taskControl.isEndorsement && ddlEndoType.SelectedItem.Value != "4")
            {
                double totprem = CalculateDifference(taskControl);

                mFactor = 0.0;
                NewProRataTotPrem = 0.0;
                NewShotRateTotPrem = 0.0;
                string EndorDate = "";
                if (txtEndoEffDate.Text != "")
                    EndorDate = txtEndoEffDate.Text.Trim();//DateTime.Now.ToShortDateString();//txtEntryDate.Text.Trim();
                else
                    EndorDate = DateTime.Now.ToShortDateString();

                //Si no es Flat no hace calculo de prima prorrateada.
                //if (taskControl.EffectiveDate != EndorDate.Trim())
                //{
                TimeSpan tsDAYS1 = DateTime.Parse(OldOPP.ExpirationDate/*txtExpDt.Text*/) - DateTime.Parse(EndorDate.Trim());
                TimeSpan tsDAYS2 = DateTime.Parse(OldOPP.ExpirationDate/*txtExpDt.Text*/) - DateTime.Parse(OldOPP.EffectiveDate/*txtExpDt.Text*/);

                int mDAYS1 = tsDAYS1.Days;
                int mDAYS2 = tsDAYS2.Days;

                mFactor = double.Parse(mDAYS1.ToString()) / double.Parse(mDAYS2.ToString());
                mFactor = Math.Round(mFactor, 3);
                NewProRataTotPrem = Math.Round(totprem * mFactor, 0);
                NewShotRateTotPrem = Math.Round(NewProRataTotPrem * 0.9, 0);

                double totpremTemp = previousPremium;//OldOPP.TotalPremium;
                if (ddlEndoType.SelectedItem.Value != "3")
                {
                    if (!chkUserModEndo.Checked)
                    {
                        TxtPremium.Text = (totpremTemp + NewProRataTotPrem).ToString("###,##0.00");
                        TxtTotalPremium.Text = TxtPremium.Text;
                        TxtUserPremium.Text = TxtPremium.Text;
                        txtEndoPremium.Text = NewProRataTotPrem.ToString("###,##0.00");
                        chkUserMod.Checked = true;
                    }
                    else
                    {
                        TxtPremium.Text = (totpremTemp + double.Parse(txtEndoPremium.Text)).ToString("###,##0.00");
                        TxtTotalPremium.Text = TxtPremium.Text;
                        TxtUserPremium.Text = TxtPremium.Text;
                        txtEndoPremium.Text = double.Parse(txtEndoPremium.Text).ToString("###,##0.00");
                        chkUserMod.Checked = true;
                    }

                }
                else
                {
                    if (!chkUserModEndo.Checked)
                    {
                        TxtPremium.Text = (totpremTemp - NewProRataTotPrem).ToString("###,##0.00");
                        TxtTotalPremium.Text = TxtPremium.Text;
                        TxtUserPremium.Text = TxtPremium.Text;
                        txtEndoPremium.Text = NewProRataTotPrem.ToString("###,##0.00");
                        chkUserMod.Checked = true;
                    }
                    else
                    {
                        if (txtEndoPremium.Text.Contains("-"))
                        {
                            double tempEndoPremium = double.Parse(txtEndoPremium.Text.Replace('-', ' '));
                            TxtPremium.Text = (totpremTemp - tempEndoPremium).ToString("###,##0.00");
                            TxtTotalPremium.Text = TxtPremium.Text;
                            TxtUserPremium.Text = TxtPremium.Text;
                            txtEndoPremium.Text = tempEndoPremium.ToString("-###,##0.00");
                            chkUserMod.Checked = true;
                        }
                        else
                        {
                            double tempEndoPremium = double.Parse(txtEndoPremium.Text);
                            TxtPremium.Text = (totpremTemp + tempEndoPremium).ToString("###,##0.00");
                            TxtTotalPremium.Text = TxtPremium.Text;
                            TxtUserPremium.Text = TxtPremium.Text;
                            txtEndoPremium.Text = tempEndoPremium.ToString("###,##0.00");
                            chkUserMod.Checked = true;
                        }
                    }
                }
            }
            else
            {
                TxtPremium.Text = previousPremium.ToString("###,##0.00");
                TxtTotalPremium.Text = TxtPremium.Text;
                TxtUserPremium.Text = TxtPremium.Text;
                txtEndoPremium.Text = "0.00";
                chkUserMod.Checked = true;
            }
            //else
            //{
            //    txtOriginalPremiumQuote.Text = OldOPP.TotalPremium.ToString("###,##0.00");
            //    txtFactorQuote.Text = "0";
            //    txtProRataQuote.Text = "0.00";
            //    txtAdditionalPremium.Text = "0.00";
            //    txtProRataPremium.Text = OldOPP.TotalPremium.ToString("###,###,##0.00");
            //}
        }

        //private void CalculateEndorsement()
        //{
        //    EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
        //    EPolicy.TaskControl.CorporatePolicyQuote OldOPP = (EPolicy.TaskControl.CorporatePolicyQuote)Session["OriginalPolicy"];
        //    previousPremium = (double)Session["PreviousPremium"];

        //    double number = 0;
        //    bool result = false;

        //    if (txtEndoPremium.Text != "")
        //    {
        //        result = Double.TryParse(txtEndoPremium.Text, out number);
        //        if (!result)
        //            throw new Exception("Invalid value entered in endorsement value.  Please verify.");
        //    }

        //    if (taskControl.isEndorsement && ddlEndoType.SelectedItem.Value != "4")
        //    {
        //        double totprem = CalculateDifference(taskControl);

        //        mFactor = 0.0;
        //        NewProRataTotPrem = 0.0;
        //        NewShotRateTotPrem = 0.0;
        //        string EndorDate = "";
        //        if (txtEndoEffDate.Text != "")
        //            EndorDate = txtEndoEffDate.Text.Trim();//DateTime.Now.ToShortDateString();//txtEntryDate.Text.Trim();
        //        else
        //            EndorDate = DateTime.Now.ToShortDateString();

        //        //Si no es Flat no hace calculo de prima prorrateada.
        //        //if (taskControl.EffectiveDate != EndorDate.Trim())
        //        //{
        //        TimeSpan tsDAYS1 = DateTime.Parse(OldOPP.ExpirationDate/*txtExpDt.Text*/) - DateTime.Parse(EndorDate.Trim());
        //        TimeSpan tsDAYS2 = DateTime.Parse(OldOPP.ExpirationDate/*txtExpDt.Text*/) - DateTime.Parse(OldOPP.EffectiveDate/*txtExpDt.Text*/);

        //        int mDAYS1 = tsDAYS1.Days;
        //        int mDAYS2 = tsDAYS2.Days;

        //        mFactor = double.Parse(mDAYS1.ToString()) / double.Parse(mDAYS2.ToString());
        //        mFactor = Math.Round(mFactor, 3);
        //        NewProRataTotPrem = Math.Round(totprem * mFactor, 0);
        //        NewShotRateTotPrem = Math.Round(NewProRataTotPrem * 0.9, 0);

        //        double totpremTemp = previousPremium;//OldOPP.TotalPremium;
        //        if (ddlEndoType.SelectedItem.Value != "3")
        //        {
        //            TxtPremium.Text = (totpremTemp + NewProRataTotPrem).ToString("###,##0.00");
        //            TxtTotalPremium.Text = TxtPremium.Text;
        //            //TxtUserPremium.Text = TxtPremium.Text;
        //            txtEndoPremium.Text = NewProRataTotPrem.ToString("###,##0.00");
        //            //chkUserMod.Checked = true;
        //        }
        //        else
        //        {
        //            TxtPremium.Text = (totpremTemp - NewProRataTotPrem).ToString("###,##0.00");
        //            TxtTotalPremium.Text = TxtPremium.Text;
        //            //TxtUserPremium.Text = TxtPremium.Text;
        //            txtEndoPremium.Text = NewProRataTotPrem.ToString("-###,##0.00");
        //            //chkUserMod.Checked = true;
        //        }
        //    }
        //    else
        //    {
        //        TxtPremium.Text = previousPremium.ToString("###,##0.00");
        //        TxtTotalPremium.Text = TxtPremium.Text;
        //        //TxtUserPremium.Text = TxtPremium.Text;
        //        txtEndoPremium.Text = "0.00";
        //        //chkUserMod.Checked = true;
        //    }
        //    //else
        //    //{
        //    //    txtOriginalPremiumQuote.Text = OldOPP.TotalPremium.ToString("###,##0.00");
        //    //    txtFactorQuote.Text = "0";
        //    //    txtProRataQuote.Text = "0.00";
        //    //    txtAdditionalPremium.Text = "0.00";
        //    //    txtProRataPremium.Text = OldOPP.TotalPremium.ToString("###,###,##0.00");
        //    //}
        //}

        private double CalculateDifference(EPolicy.TaskControl.CorporatePolicyQuote taskControl)
        {
            string _ActualPremTotal = taskControl.TotalPremium.ToString("###,###,##0.00");
            //string _PreviousPremTotal = OriginalTaskControl.TotalPremium.ToString("###,###,##0.00");

            //Calculate Difference

            double totalActual = taskControl.TotalPremium + taskControl.Charge;
            double totalPrev = previousPremium;//OriginalTaskControl.TotalPremium + OriginalTaskControl.Charge;

            string _DiffPremTotal = (totalActual - totalPrev).ToString();

            if (double.Parse(_DiffPremTotal) != 0)
                return double.Parse(_DiffPremTotal);
            else
                return totalActual;
        }

        private string VerifyChanges(EPolicy.TaskControl.CorporatePolicyQuote newOPP, int userID)
        {
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["OriginalPolicy"];
            EPolicy.Audit.History history = new EPolicy.Audit.History();
            int mode = 2; //Update

            // Campos de TaskControl
            //history.BuildNotesForHistory("Agency", taskControl.Agency, newOPP.Agency, mode);
            //history.BuildNotesForHistory("Agent", taskControl.Agent, newOPP.Agent, mode);
            history.BuildNotesForHistory("InsuranceCompany",
                EPolicy.LookupTables.LookupTables.GetDescription("InsuranceCompany", taskControl.InsuranceCompany.ToString()),
                EPolicy.LookupTables.LookupTables.GetDescription("InsuranceCompany", newOPP.InsuranceCompany.ToString()),
                mode);
            // Terminan Campos TaskControl

            //Campos de Customer
            history.BuildNotesForHistory("Name", taskControl.Customer.FirstName, newOPP.Customer.FirstName, mode);
            history.BuildNotesForHistory("Initial", taskControl.Customer.Initial, newOPP.Customer.Initial, mode);
            history.BuildNotesForHistory("LastName", taskControl.Customer.LastName1, newOPP.Customer.LastName1, mode);
            history.BuildNotesForHistory("LastName 2", taskControl.Customer.LastName2, newOPP.Customer.LastName2, mode);
            history.BuildNotesForHistory("Address 1", taskControl.Customer.Address1, newOPP.Customer.Address1, mode);
            history.BuildNotesForHistory("Address 2", taskControl.Customer.Address2, newOPP.Customer.Address2, mode);
            history.BuildNotesForHistory("City", taskControl.Customer.City, newOPP.Customer.City, mode);
            history.BuildNotesForHistory("State", taskControl.Customer.State, newOPP.Customer.State, mode);
            history.BuildNotesForHistory("Zip Code", taskControl.Customer.ZipCode, newOPP.Customer.ZipCode, mode);
            history.BuildNotesForHistory("Home Phone Number", taskControl.Customer.HomePhone, newOPP.Customer.HomePhone, mode);
            history.BuildNotesForHistory("Work Phone Number", taskControl.Customer.JobPhone, newOPP.Customer.JobPhone, mode);
            history.BuildNotesForHistory("Cellphone Number", taskControl.Customer.Cellular, newOPP.Customer.Cellular, mode);
            history.BuildNotesForHistory("Email", taskControl.Customer.Email, newOPP.Customer.Email, mode);
            // Terminan Campos Customer

            // Campos de Policy
            history.BuildNotesForHistory("PolicyType", taskControl.PolicyType, newOPP.PolicyType, mode);
            history.BuildNotesForHistory("PolicyNo", taskControl.PolicyNo, newOPP.PolicyNo, mode);
            history.BuildNotesForHistory("Certificate", taskControl.Certificate, newOPP.Certificate, mode);
            history.BuildNotesForHistory("Suffix", taskControl.Suffix, newOPP.Suffix, mode);
            history.BuildNotesForHistory("LoanNo", taskControl.LoanNo.ToString(), newOPP.LoanNo.ToString(), mode);
            history.BuildNotesForHistory("Term", taskControl.Term.ToString(), newOPP.Term.ToString(), mode);
            history.BuildNotesForHistory("EffectiveDate", taskControl.EffectiveDate.ToString(), newOPP.EffectiveDate.ToString(), mode);
            history.BuildNotesForHistory("ExpirationDate", taskControl.ExpirationDate.ToString(), newOPP.ExpirationDate.ToString(), mode);
            history.BuildNotesForHistory("Charge", taskControl.Charge.ToString(), newOPP.Charge.ToString(), mode);
            history.BuildNotesForHistory("TotalPremium", taskControl.TotalPremium.ToString(), newOPP.TotalPremium.ToString(), mode);
            // Terminan Campos Policy

            //Campos de Empleados
            history.BuildNotesForHistory("Phys. Assitant Qty.", taskControl.QuantityTN1.ToString(), newOPP.QuantityTN1.ToString(), mode);
            history.BuildNotesForHistory("Nurse Midwife Qty.", taskControl.QuantityTN2.ToString(), newOPP.QuantityTN2.ToString(), mode);
            history.BuildNotesForHistory("Nurse Anesthetist Qty.", taskControl.QuantityTN3.ToString(), newOPP.QuantityTN3.ToString(), mode);
            history.BuildNotesForHistory("Nurse Practicioner Qty.", taskControl.QuantityTN4.ToString(), newOPP.QuantityTN4.ToString(), mode);
            history.BuildNotesForHistory("Other Personel Qty.", taskControl.QuantityTN5.ToString(), newOPP.QuantityTN5.ToString(), mode);

            history.BuildNotesForHistory("Phys. Assitant Qty.", taskControl.EQuantityTN1.ToString(), newOPP.EQuantityTN1.ToString(), mode);
            history.BuildNotesForHistory("Nurse Midwife Qty.", taskControl.EQuantityTN2.ToString(), newOPP.EQuantityTN2.ToString(), mode);
            history.BuildNotesForHistory("Nurse Anesthetist Qty.", taskControl.EQuantityTN3.ToString(), newOPP.EQuantityTN3.ToString(), mode);
            history.BuildNotesForHistory("Nurse Practicioner Qty.", taskControl.EQuantityTN4.ToString(), newOPP.EQuantityTN4.ToString(), mode);
            history.BuildNotesForHistory("Other Personel Qty.", taskControl.EQuantityTN5.ToString(), newOPP.EQuantityTN5.ToString(), mode);
            //Terminan Campos de Empleados

            history.Actions = "EDIT";

            //history.KeyID = this.TaskControlID.ToString();
            //history.Subject = "POLICIES";
            //history.UsersID = userID;
            //history.GetNotes();
            history.GetSaveHistory();
            return history.Notes.ToUpper().Trim();

        }

        private XmlDocument GetInsertEndorsementsXml(int TaskControlID)
        {
            TaskControl.CorporatePolicyQuote taskControl = (TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            TaskControl.CorporatePolicyQuote taskControl2 = (TaskControl.CorporatePolicyQuote)Session["OriginalPolicy"];

            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[9];

            DbRequestXmlCooker.AttachCookItem("EndorsementID", SqlDbType.Int, 0, (txtEndorsementID.Text == "") ? "0" : txtEndorsementID.Text, ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, TaskControlID.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EndorsementNo", SqlDbType.Int, 0, txtEndorsementNo.Text.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntryDate", SqlDbType.DateTime, 0, txtDatePrepared.Text.Trim(), ref cookItems);

            if (txtEndoEffDate.Text != "")
                DbRequestXmlCooker.AttachCookItem("EffectiveDate", SqlDbType.DateTime, 0, txtEndoEffDate.Text.Trim(), ref cookItems);
            else
                DbRequestXmlCooker.AttachCookItem("EffectiveDate", SqlDbType.DateTime, 0, DateTime.Now.ToShortDateString(), ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndorsementPremium", SqlDbType.Float, 0, txtEndoPremium.Text.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EndorsementTypeID", SqlDbType.Int, 0, ddlEndoType.SelectedItem.Value.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EndorsementComment", SqlDbType.VarChar, 500, txtEndoComments.Text.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EndorsementHistory", SqlDbType.VarChar, 500, VerifyChanges(taskControl, userID), ref cookItems);


            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            return xmlDoc;
        }

        private XmlDocument GetUpdateEndorsementsXml(int TaskControlID)
        {
            TaskControl.CorporatePolicyQuote taskControl = (TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            TaskControl.CorporatePolicyQuote taskControl2 = (TaskControl.CorporatePolicyQuote)Session["OriginalPolicy"];

            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[9];

            DbRequestXmlCooker.AttachCookItem("EndorsementID", SqlDbType.Int, 0, TaskControlID.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, TaskControlID.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EndorsementNo", SqlDbType.Int, 0, txtEndorsementNo.Text.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntryDate", SqlDbType.DateTime, 0, txtDatePrepared.Text.Trim(), ref cookItems);

            if (txtEndoEffDate.Text != "")
                DbRequestXmlCooker.AttachCookItem("EffectiveDate", SqlDbType.DateTime, 0, txtEndoEffDate.Text.Trim(), ref cookItems);
            else
                DbRequestXmlCooker.AttachCookItem("EffectiveDate", SqlDbType.DateTime, 0, DateTime.Now.ToShortDateString(), ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndorsementPremium", SqlDbType.Float, 0, txtEndoPremium.Text.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EndorsementTypeID", SqlDbType.Int, 0, ddlEndoType.SelectedItem.Value.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EndorsementComment", SqlDbType.VarChar, 500, txtEndoComments.Text.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EndorsementHistory", SqlDbType.VarChar, 500, VerifyChanges(taskControl, userID), ref cookItems);


            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            return xmlDoc;
        }

        private void AddEndorsement(int taskControlID)
        {
            Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
            try
            {
                Executor.BeginTrans();
                int a = Executor.Insert("AddEndorsements", this.GetInsertEndorsementsXml(taskControlID));
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error while trying to save Endorsement. " + xcp.Message, xcp);
            }
        }

        private void UpdateOPPEndorsement()
        {
            Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
            try
            {
                Executor.BeginTrans();
                Executor.Update("UpdateEndorsements", this.GetUpdateEndorsementsXml(taskControlID));
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error while trying to save Endorsement Quote. " + xcp.Message, xcp);
            }
        }


        protected void btnHideEndoPanel_Click(object sender, EventArgs e)
        {
            btnHideEndoPanel.Visible = false;
            pnlEndorsement.Visible = false;
        }

        public static DataTable GetEndorsements(int taskControlID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, taskControlID.ToString(),
                ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            DataTable dt = exec.GetQuery("GetEndorsementsByTaskControlID", xmlDoc);

            return dt;
        }
        protected void dtEndorsement_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
                EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
                int userID = 0;
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                switch (e.CommandName)
                {
                    case "Select":

                        lblEndorsement.Visible = true;
                        pnlEndorsement.Visible = true;
                        btnHideEndoPanel.Enabled = true;
                        btnHideEndoPanel.Visible = true;
                        txtEndorsementNo.Text = e.Item.Cells[2].Text.Trim();
                        txtEndorsementNo.Enabled = false;
                        txtDatePrepared.Text = e.Item.Cells[3].Text.Trim();
                        txtDatePrepared.Enabled = false;
                        txtEndoEffDate.Text = e.Item.Cells[4].Text.Trim();
                        txtEndoEffDate.Enabled = false;
                        txtEndoPremium.Text = e.Item.Cells[6].Text.Trim();
                        txtEndoPremium.Enabled = false;
                        ddlEndoType.SelectedIndex = ddlEndoType.Items.IndexOf(
                        ddlEndoType.Items.FindByText(e.Item.Cells[5].Text.Trim()));
                        ddlEndoType.Enabled = false;
                        txtEndoComments.Enabled = false;
                        if (e.Item.Cells[7].Text.Trim() != " ")
                            txtEndoComments.Text = e.Item.Cells[7].Text.Trim();

                        if (e.Item.Cells[8].Text.Trim() != " ")
                            txtEndoComments.Text = e.Item.Cells[7].Text.Trim() + System.Environment.NewLine + e.Item.Cells[8].Text.Trim();
                        break;
                    case "Edit":
                        lblEndorsement.Visible = true;
                        pnlEndorsement.Visible = true;
                        //btnHideEndoPanel.Enabled = true;
                        //btnHideEndoPanel.Visible = true;
                        dtEndorsement.Visible = false;
                        txtEndorsementID.Text = e.Item.Cells[1].Text.Trim();
                        txtEndorsementID.Enabled = false;
                        txtEndorsementID.Visible = false;
                        txtEndorsementNo.Text = e.Item.Cells[2].Text.Trim();
                        txtEndorsementNo.Enabled = true;
                        txtDatePrepared.Text = e.Item.Cells[3].Text.Trim();
                        txtDatePrepared.Enabled = true;
                        txtEndoEffDate.Text = e.Item.Cells[4].Text.Trim();
                        txtEndoEffDate.Enabled = true;
                        txtEndoPremium.Text = e.Item.Cells[6].Text.Trim();
                        txtEndoPremium.Enabled = true;
                        ddlEndoType.SelectedIndex = ddlEndoType.Items.IndexOf(
                        ddlEndoType.Items.FindByText(e.Item.Cells[5].Text.Trim()));
                        ddlEndoType.Enabled = true;
                        txtEndoComments.Enabled = true;
                        if (e.Item.Cells[7].Text.Trim() != " ")
                            txtEndoComments.Text = e.Item.Cells[7].Text.Trim();

                        if (e.Item.Cells[8].Text.Trim() != " ")
                            txtEndoComments.Text = e.Item.Cells[7].Text.Trim() + System.Environment.NewLine + e.Item.Cells[8].Text.Trim();

                        userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
                        taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
                        //EPolicy.TaskControl.Policies taskControl2 = (EPolicy.TaskControl.Policies)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControlID, userID);

                        Session.Add("PreviousPremium", taskControl.TotalPremium);
                        Session.Add("OriginalPolicy", taskControl);

                        taskControl.isEndorsement = true;
                        previousPremium = taskControl.TotalPremium;
                        taskControl.Mode = (int)TaskControl.TaskControl.TaskControlMode.UPDATE;

                        Session.Add("TaskControl", taskControl);

                        EnableControls();

                        break;
                    case "Delete":
                        taskControl.Endoso = taskControl.Endoso - 1;

                        if (e.Item.Cells[6].Text.Trim() != "&nbsp;" && e.Item.Cells[6].Text.Trim() != String.Empty && e.Item.Cells[6].Text.Trim() != null)
                        TxtPremium.Text = (double.Parse(TxtPremium.Text) - double.Parse(e.Item.Cells[6].Text)).ToString("###,##0.00");
                        TxtTotalPremium.Text = TxtPremium.Text;
                        txtEndoEffDate.Text = "";
                        chkUserMod.Checked = true;

                        FillProperties();

                        taskControl.SaveCorporatePolicy(userID);  //(userID);

                        //Update Inception Payment Amount
                        UpdateInceptionPartialPayments(taskControl.TaskControlID, (taskControl.TotalPremium + taskControl.Charge));
                        PaymentPolicy pp = new PaymentPolicy();

                        FillTextControl();
                        //DisableControls();

                        Session.Remove("DtPolicyDetail");

                        //Session.Add("TaskControl",taskControl);
                        //Session.Remove("TaskControl");
                        taskControl.Mode = 4;
                        Session["TaskControl"] = taskControl;

                        DeleteEndorsements(int.Parse(e.Item.Cells[1].Text.Trim()));
                        FillEndorsementGrid();

                        this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Endorsement deleted successfully.");
                        this.litPopUp.Visible = true;

                        break;
                    case "Print":
                        //DataGridGroup.DataSource = null;

                        //string date2 = e.Item.Cells[4].Text.Trim();
                        //if (date2.ToString().Trim() == " ")
                        //{
                        //    throw new Exception("This Endorsement is not Applied.");
                        //}

                        //EPolicy.TaskControl.Policies taskControl2 = (EPolicy.TaskControl.Policies)Session["TaskControl"];

                        //int s = int.Parse(e.Item.Cells[2].Text);
                        //string comments = e.Item.Cells[10].Text.Trim();
                        //EPolicy.TaskControl.Policies newOPP2 = (EPolicy.TaskControl.Policies)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(s, userID);
                        //int OPPEndorID = int.Parse(e.Item.Cells[1].Text);

                        ////Print Document
                        //try
                        //{
                        //    EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];

                        //    GetReportEndosoTableAdapters.GetReportEndosoTableAdapter ds = new GetReportEndosoTableAdapters.GetReportEndosoTableAdapter();
                        //    ReportDataSource rds = new ReportDataSource("GetReportEndoso_GetReportEndoso", ds.GetData(OPPEndorID));

                        //    ReportViewer viewer = new ReportViewer();
                        //    viewer.LocalReport.DataSources.Clear();
                        //    viewer.ProcessingMode = ProcessingMode.Local;
                        //    viewer.LocalReport.ReportPath = Server.MapPath("Reports/Endoso.rdlc");
                        //    viewer.LocalReport.DataSources.Add(rds);
                        //    viewer.LocalReport.Refresh();

                        //    //viewer.LocalReport.DataSources.Add(rds);

                        //    // Variables 
                        //    Warning[] warnings;
                        //    string[] streamIds;
                        //    string mimeType;
                        //    string encoding = string.Empty;
                        //    string extension;
                        //    string fileName = taskControl.Prospect.FirstName.Trim().Replace("?", "n").Replace("?", "N") + taskControl.Prospect.LastName1.Trim().Replace("?", "n").Replace("?", "N") + taskControl.TaskControlID.ToString().Trim() + OPPEndorID.ToString().Trim();
                        //    string _FileName = taskControl.Prospect.FirstName.Trim().Replace("?", "n").Replace("?", "N") + taskControl.Prospect.LastName1.Trim().Replace("?", "n").Replace("?", "N") + taskControl.TaskControlID.ToString().Trim() + OPPEndorID.ToString().Trim() + ".pdf";
                        //    //??
                        //    if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                        //        File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

                        //    byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                        //    using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
                        //    {
                        //        fs.Write(bytes, 0, bytes.Length);
                        //    }

                        //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + _FileName + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);

                        //}
                        //catch (Exception ecp)
                        //{

                        //}

                        break;

                    default: //Page
                        dtEndorsement.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                        dtEndorsement.DataSource = (DataTable)Session["DtEndorsement"];
                        dtEndorsement.DataBind();
                        break;
                }
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;

                //lblRecHeader.Text = exp.Message;
                //mpeSeleccion.Show();
            }
        }

        private void FillEndorsementGrid()
        {
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];

            //if (taskControl.isEndorsement)
            //    taskControl = (EPolicy.TaskControl.Policies)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControlID, userID); //(EPolicy.TaskControl.Policies)Session["Original"];

            dtEndorsement.DataSource = null;
            DtEndorsement = null;

            DtEndorsement = GetEndorsements(taskControl.TaskControlID);//taskControl.EndorsementCollection;

            Session.Remove("DtEndorsement");
            Session.Add("DtEndorsement", DtEndorsement);

            if (DtEndorsement != null)
            {
                if (DtEndorsement.Rows.Count != 0)
                {
                    dtEndorsement.DataSource = DtEndorsement;
                    dtEndorsement.DataBind();
                    lblEndorsementHistory.Visible = true;
                    dtEndorsement.Visible = true;
                    chkUserMod.Checked = true;
                    TxtUserPremium.Text = taskControl.TotalPremium.ToString("###,##0.00");
                }
                else
                {
                    lblEndorsementHistory.Visible = false;
                    chkUserMod.Checked = false;
                    dtEndorsement.DataSource = null;
                    dtEndorsement.DataBind();
                }
            }
            else
            {
                lblEndorsementHistory.Visible = false;
                chkUserMod.Checked = false;
                dtEndorsement.DataSource = null;
                dtEndorsement.DataBind();
            }
        }

        public static void DeleteEndorsements(int endorsementID)
        {
            DBRequest Executor = new DBRequest();

            try
            {
                Executor.BeginTrans();
                Executor.Update("DeleteEndorsements", DeleteEndorsementXml(endorsementID));
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error, Please try again. " + xcp.Message, xcp);
            }
        }

        private static XmlDocument DeleteEndorsementXml(int endorsementID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("EndorsementID",
                SqlDbType.Int, 0, endorsementID.ToString(),
                ref cookItems);

            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            return xmlDoc;
        }
        #endregion

        protected void txtEndoPremium_TextChanged(object sender, EventArgs e)
        {
            if (txtEndoPremium.Text != "" && txtEndoPremium.Text != (NewProRataTotPrem.ToString("###,##0.00")))
            {
                chkUserMod.Checked = true;
                chkUserModEndo.Checked = true;
            }
            else
            {
                chkUserMod.Checked = false;
                chkUserModEndo.Checked = false;
                txtEndoPremium.Text = "";
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblClaim.SelectedItem.Value == "0")
            {
                lblClaimNo.Visible = true;
                txtClaimNumber.Visible = true;
            }
            else
            {
                lblClaimNo.Visible = false;
                txtClaimNumber.Visible = false;
            }
        }
        protected void TxtPremium_TextChanged(object sender, EventArgs e)
        {
            TaskControl.CorporatePolicyQuote taskControl = (TaskControl.CorporatePolicyQuote)Session["TaskControl"];
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

        private string PrintAspenPolicy(string rdlcDocument)
        {
            try
            {
                TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
                ReportViewer viewer = new ReportViewer();
                string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                viewer.LocalReport.DataSources.Clear();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportPath = Server.MapPath("Reports/ASPEN/" + rdlcDocument);

                if (rdlcDocument == "SCHEDULE OF ENDORSEMENTS.rdlc")
                {
                    ReportParameter[] param = new ReportParameter[3];
                    param[0] = new ReportParameter("effectiveDate", DateTime.Parse(taskControl.EffectiveDate).ToShortDateString());
                    param[1] = new ReportParameter("policyType", taskControl.PolicyType);
                    param[2] = new ReportParameter("policyNo", taskControl.PolicyNo);
                    viewer.LocalReport.SetParameters(param);
                    viewer.LocalReport.Refresh();
                }

                if (rdlcDocument == "PRIOR ACTS ENDORSEMENT.rdlc")
                {
                    ReportParameter[] param = new ReportParameter[5];
                    param[0] = new ReportParameter("effectiveDate", DateTime.Parse(taskControl.EffectiveDate).ToShortDateString());
                    param[1] = new ReportParameter("policyType", taskControl.PolicyType);
                    param[2] = new ReportParameter("policyNo", taskControl.PolicyNo);
                    param[3] = new ReportParameter("retroDate", DateTime.Parse(taskControl.RetroactiveDate).ToShortDateString());
                    param[4] = new ReportParameter("entryDate", taskControl.EntryDate.ToShortDateString());
                    viewer.LocalReport.SetParameters(param);
                    viewer.LocalReport.Refresh();
                }

                // Variables 
                Warning[] warnings;
                string[] streamIds;
                string mimeType;
                string encoding = string.Empty;
                string extension;
                string _FileName = rdlcDocument + "-" + taskControl.TaskControlID + ".pdf";

                if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                    File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }

                return ProcessedPath + _FileName;
            }
            catch (Exception exp)
            {
                return "";
            }
        }

        private string PrintRegistryDocument(string fileName)
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
            string _userID = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();
            string _file = _userID.ToString().Replace(" ", "");
            TaskControl.TaskControl taskControl = (TaskControl.TaskControl)Session["TaskControl"];
            Customer.Registry registry = Customer.Registry.GetRegistryByCustomerNo(int.Parse(taskControl.CustomerNo));
            TaskControl.Policy policy = new TaskControl.Policy();
            policy = TaskControl.Policy.GetPolicyByTaskControlID(taskControl.TaskControlID, policy);

            List<string> mergePaths = new List<string>();
            string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

            mergePaths = imprimirRegister(mergePaths);

            //FileInfo mFileIndex = new FileInfo("C:\\Inetpub\\wwwroot\\PRMDic\\Reports\\Registry.pdf");

            mergePaths.Add(fileName);

            //if (DateTime.Parse(policy.EffectiveDate) >= DateTime.Parse("01/01/2015"))
            //{
            //    mergePaths.Add(imprimirF102B("F102BA"));
            //    mergePaths.Add(imprimirF102B("F102BB"));
            //    mergePaths.Add(imprimirF102B("F102BC"));
            //    mergePaths.Add(imprimirF102B("F102BD"));
            //}

            CreatePDFBatch mergeFinal = new CreatePDFBatch();
            string FinalFile = "";
            FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, "F102B");

            return System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + FinalFile;

        }

        private List<string> imprimirRegister(List<string> mergePaths)
        {

            int compareResultASSMCA = 0;
            int compareResultTribunal = 0;
            int compareResultCDM = 0;
            int compareResultGS = 0;
            int compareResultLicense = 0;
            int compareResultDEA = 0;
            string tp6 = "";
            string assmcadate = "";
            string juntaLicenciamiento = "";
            string cdmdate = "";
            string gstandingdate = "";
            string licenseexpdate = "";
            string deadate = "";

            try
            {

                TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
                Customer.Registry registry = Customer.Registry.GetRegistryByCustomerNo(int.Parse(taskControl.CustomerNo));

                ReportViewer viewer = new ReportViewer();

                viewer.LocalReport.DataSources.Clear();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportPath = Server.MapPath("Reports/Report2.rdlc");


                #region values for parameters
                if (registry.ASSMCAExpDate != "")
                {
                    compareResultASSMCA = DateTime.Compare(DateTime.Parse(registry.ASSMCAExpDate.Trim()), DateTime.Now);

                    if (compareResultASSMCA < 0)
                    {
                        assmcadate = "(EXP) " + registry.ASSMCAExpDate.Trim();
                    }
                }
                else
                    assmcadate = "X";
                //if (registry.TribunalExpDate != "")
                //{
                //    compareResultTribunal = DateTime.Compare(DateTime.Parse(registry.TribunalExpDate.Trim()), DateTime.Now);

                //    if (compareResultTribunal < 0)
                //    {
                //        tribunaldate = "(EXP) " + registry.TribunalExpDate.Trim();
                //    }
                //}
                //else
                //    tribunaldate = "X";

                if (registry.JuntaLicenciamiento == true)
                {
                    juntaLicenciamiento = "";
                }
                else
                {
                    juntaLicenciamiento = "X";
                }

                if (registry.CDMExpDate != "")
                {
                    compareResultCDM = DateTime.Compare(DateTime.Parse(registry.CDMExpDate.Trim()), DateTime.Now);

                    if (compareResultCDM < 0)
                    {
                        cdmdate = "(EXP) " + registry.CDMExpDate.Trim();
                    }
                }
                else
                    cdmdate = "X";
                if (registry.GoodStandingExpDate != "")
                {
                    compareResultGS = DateTime.Compare(DateTime.Parse(registry.GoodStandingExpDate.Trim()), DateTime.Now);

                    if (compareResultGS < 0)
                    {
                        gstandingdate = "(EXP) " + registry.GoodStandingExpDate.Trim();
                    }
                }
                else
                    gstandingdate = "X";
                if (registry.LicenseExpDate != "")
                {
                    compareResultLicense = DateTime.Compare(DateTime.Parse(registry.LicenseExpDate.Trim()), DateTime.Now);

                    if (compareResultLicense < 0)
                    {
                        licenseexpdate = "(EXP) " + registry.LicenseExpDate.Trim();
                    }
                }
                else
                    licenseexpdate = "X";
                if (registry.DEAExpDate != "")
                {
                    compareResultDEA = DateTime.Compare(DateTime.Parse(registry.DEAExpDate.Trim()), DateTime.Now);

                    if (compareResultDEA < 0)
                    {
                        deadate = "(EXP) " + registry.DEAExpDate.Trim();
                    }
                }
                else
                    deadate = "X";
                if (!registry.CV)
                {
                    tp6 = "X";
                }

                if (compareResultASSMCA > 0 && compareResultTribunal > 0 && compareResultCDM > 0 && compareResultGS > 0 && compareResultLicense > 0 && compareResultDEA > 0)
                    return mergePaths;

                #endregion

                ReportParameter p1 = new ReportParameter("ASSMCADate", assmcadate);
                ReportParameter p2 = new ReportParameter("JuntaLicenciamiento", juntaLicenciamiento);
                ReportParameter p3 = new ReportParameter("CDMDate", cdmdate);
                ReportParameter p4 = new ReportParameter("GStandingDate", gstandingdate);
                ReportParameter p5 = new ReportParameter("LicenseExpDate", licenseexpdate);
                ReportParameter p6 = new ReportParameter("CVDate", tp6);
                ReportParameter p7 = new ReportParameter("DEADate", deadate);

                ReportParameter p8 = new ReportParameter("Asegurado", taskControl.Customer.FirstName + " " + taskControl.Customer.Initial + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2);
                ReportParameter p9 = new ReportParameter("PolizaNo", taskControl.PolicyType.Trim() + "-" + taskControl.PolicyNo);

                LookupTables.Agency agency = new LookupTables.Agency();

                agency = agency.GetAgency(taskControl.Agency);

                ReportParameter p10 = new ReportParameter("Agency", agency.AgencyDesc);

                LookupTables.Agent agent = new LookupTables.Agent();

                agent = agent.GetAgent(taskControl.Agent);

                ReportParameter p11 = new ReportParameter("Productor", agent.AgentDesc);
                ReportParameter p12 = new ReportParameter("EffDt", taskControl.EffectiveDate);

                DataTable DtTask = TaskControl.TaskControl.GetTaskControlByCustomerNo(taskControl.Customer.CustomerNo);
                bool validate = true;

                for (int i = 0; i < DtTask.Rows.Count; i++)
                {
                    if (DtTask.Rows[i][1].ToString().Trim() == "PP")
                        validate = false;
                }

                ReportParameter p13 = new ReportParameter();

                if (validate)
                    p13 = new ReportParameter("EntryDt", "X");
                else
                    p13 = new ReportParameter("EntryDt", "");



                agent = agent.GetAgent(taskControl.Agent);

                viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13 });
                viewer.LocalReport.Refresh();

                // Variables 
                Warning[] warnings;
                string[] streamIds;
                string mimeType;
                string encoding = string.Empty;
                string extension;
                string _FileName = "Registry-" + registry.RegistryID.ToString().Trim() + ".pdf";

                if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                    File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }

                mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);
                return mergePaths;
            }
            catch (Exception ex)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(ex.Message + " " + ex.InnerException + " " + ex.Source);
                this.litPopUp.Visible = true;
                return mergePaths;
            }
        }

        private string ImprimirCartaDeptDefensa()
        {
            try
            {
                TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
                Customer.Registry registry = Customer.Registry.GetRegistryByCustomerNo(int.Parse(taskControl.CustomerNo));
                ReportViewer viewer = new ReportViewer();

                viewer.LocalReport.DataSources.Clear();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportPath = Server.MapPath("Reports/Carta_Dept_Defensa.rdlc");

                // Variables 
                Warning[] warnings;
                string[] streamIds;
                string mimeType;
                string encoding = string.Empty;
                string extension;
                string _FileName = "CDD-" + registry.RegistryID.ToString().Trim() + ".pdf";

                if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                    File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }

                return _FileName;
            }
            catch (Exception exp)
            {
                return "";
            }
        }

        private string imprimirF102B(string rdlcReport)
        {
            TaskControl.TaskControl taskControl = (TaskControl.TaskControl)Session["TaskControl"];
            ReportViewer viewer = new ReportViewer();

            viewer.LocalReport.DataSources.Clear();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = Server.MapPath("Reports/" + rdlcReport + ".rdlc");
            viewer.LocalReport.Refresh();

            Warning[] warnings;
            string[] streamIds;
            string mimeType;
            string encoding = string.Empty;
            string extension;
            string _FileName = rdlcReport + taskControl.TaskControlID + ".pdf";

            if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

            byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }

            return System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName;
        }

        protected void PrintWord(string whereclause, bool IncludeCert)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
            List<string> mergePaths = new List<string>();
            string ProcessedPath = ConfigurationManager.AppSettings["ExportsFilesPathName"];

            //DataTable reports = GetReportMasterDocumentsByCriteria("(FormName = 'policy' or FormName = 'DECLARATIONS PAGE') and PolicyType = 'PP'");
            DataTable reports = GetReportMasterDocumentsByCriteria(whereclause);
            for (int i = 0; i < reports.Rows.Count; i++)
            {
                if (reports.Rows[i]["WordDocument"].ToString().Contains(".pdf"))
                {
                    var currentApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath.ToString();
                    string fullFilePath = currentApplicationPath + "Reports\\Word\\Files\\" + reports.Rows[i]["WordDocument"].ToString();
                    string copyToPath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + reports.Rows[i]["WordDocument"].ToString();
                    File.Copy(fullFilePath, copyToPath, true);
                    mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + reports.Rows[i]["WordDocument"].ToString());

                }
                else
                {
                    mergePaths = PrintMSWord(reports.Rows[i]["WordDocument"].ToString(), mergePaths, ProcessedPath);
                }

            }
            //if (IncludeCert == true && taskControl.PolicyType.Trim() == "PP" || taskControl.PolicyType.Trim() == "CP")
            //{
            //    mergePaths = PrintCertificateReports("295", 1, mergePaths);
            //}

            PrintMW_PDFMerge(mergePaths, ProcessedPath);
        }

        protected void PrintMW_PDFMerge(List<string> mergePaths, string ProcessedPath)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
            CreatePDFBatch mergeFinal = new CreatePDFBatch();
            string FinalFile = "";
            FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, (taskControl.Customer.FirstName + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2).Trim().Replace(".", "").Replace("\\", "").Replace(@"\", "").Replace("/", ""));
            taskControl.PrintPolicy = true;
            taskControl.PrintDate = DateTime.Now.ToShortDateString();
            taskControl.Mode = 2;
            FillProperties();
            taskControl.SavePolicies(userID);
            History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY RENOVATION DOCUMENT.");
            RemoveSessionLookUp();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
        }
        private List<string> PrintMSWord(string Filename, List<string> mergePaths, string ProcessedPath)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
            string BookMarkName = "";
            string BookMarkValue = "";
            System.Drawing.Image image;
            //Load document  
            Spire.Doc.Document document = new Spire.Doc.Document();
            string FilePath = @"C:\inetpub\wwwroot\PRMdic\Reports\Word\Files\" + Filename;
            document.LoadFromFile(FilePath); //@"Bookmark.docx"


            for (int i = 0; i < document.Bookmarks.Count; i++)
            {
                BookMarkName = document.Bookmarks[i].Name.ToString().Trim();

                //Add a section to the document and two paragraphs to the section  
                Spire.Doc.Section sec = document.AddSection();
                BookMarkValue = GetBookMarkValue(BookMarkName);

                if (BookMarkValue.Contains(".jpeg") || BookMarkValue.Contains(".jpg") || BookMarkValue.Contains(".png"))
                {
                    image = System.Drawing.Image.FromFile(BookMarkValue);
                    //image = resizeImage(image, new Size(200, 60)); //125,81
                    image = ImageResizeSelector(image, BookMarkValue);
                    sec.AddParagraph().AppendPicture(image);
                }
                else
                    sec.AddParagraph().AppendText(BookMarkValue);


                //Get the text body part of the two paragraphs

                Spire.Doc.Fields.ParagraphBase firstReplacementParagraph = sec.Paragraphs[0].Items.FirstItem as Spire.Doc.Fields.ParagraphBase;
                Spire.Doc.Fields.ParagraphBase lastReplacementParagraph = sec.Paragraphs[sec.Paragraphs.Count - 1].Items.LastItem as Spire.Doc.Fields.ParagraphBase;
                TextBodySelection selection = new TextBodySelection(firstReplacementParagraph, lastReplacementParagraph);
                TextBodyPart part = new TextBodyPart(selection);

                BookmarksNavigator bookmarkNavigator = new BookmarksNavigator(document);
                bookmarkNavigator.MoveToBookmark(BookMarkName);
                bookmarkNavigator.ReplaceBookmarkContent(part);

                //Remove the section   
                document.Sections.Remove(sec);

            }
            //save the document
            string FinalFile = ProcessedPath + lblTCID.Text.ToString().Trim() + Filename + "_" + DateTime.Now.ToString().Replace("/", "-").Replace(":", "").Replace(" ", "") + ".pdf";
            //Convert Word to PDF
            document.SaveToFile(FinalFile);
            mergePaths.Add(FinalFile);

            return mergePaths;
        }

        //public static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size) 
        //{
        //    return (System.Drawing.Image)(new Bitmap(imgToResize, size));
        //}
        public static System.Drawing.Image ImageResizeSelector(System.Drawing.Image image, string name)
        {
            if (name.Contains("firma+estef.png"))
                image = ResizeImage(image, 100, 80);
            else if (name.Contains("firmaAdrianOrtiz.png"))
                image = ResizeImage(image, 100, 80);
            else if (name.Contains("EribelCasadoColonialSanJuan.png"))
                image = ResizeImage(image, 100, 100);
            else if (name.Contains("FIRMA+LUCYLL-1.jpeg"))
                image = ResizeImage(image, 1000, 300);


            return image;
        }
        public static System.Drawing.Image ResizeImage(System.Drawing.Image image, int width, int height)
        {
            //https://stackoverflow.com/questions/1922040/how-to-resize-an-image-c-sharp
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return (System.Drawing.Image)destImage;
        }



        private string GetBookMarkValue(string BookMarkName)
        {

            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

            DataTable dt = GetReportMasterInformationByTaskcontrolID(taskControl.TaskControlID);
            string value = "";
            string Limit1 = ddlPrMedicalLimits.SelectedItem.Text.Trim();
            string Limit2 = "";
            Limit2 = ddlPriPolLimits1.SelectedItem.Text.Trim();
            string[] split = Limit1.Split('/');
            string[] split2 = Limit2.Split('/');


            if (BookMarkName == "LimitA")
            { value = split[0]; }

            else if (BookMarkName == "LimitA2")
            {
                if (split2[0].Trim() == "")
                {
                    value = "N/A";
                }
                else
                {
                    value = split2[0];
                }

            }

            else if (BookMarkName == "AggregateA")
            { value = split[1]; }
            else if (BookMarkName == "AggregateA2")
            {
                if (split2.Length > 1)
                {
                    if (split2[1].Trim() == "")
                    {
                        value = "N/A";
                    }
                    else
                    {
                        value = split2[1];
                    }
                }
                else
                {
                    value = "N/A";
                }
            }

            //else if (BookMarkName == "InvoiceDiscount")
            //{ 
            //    value = CalculateInvoiceDiscount(taskControl,"Discount");
            //}

            //else if (BookMarkName == "InvoiceAssist")
            //{ 
            //    value = CalculateInvoiceDiscount(taskControl, "Assist");
            //}

            else
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (BookMarkName == dt.Columns[i].ColumnName)
                    {
                        value = dt.Rows[0][i].ToString().Trim();
                        break;
                    }
                }
            }

            return value;
        }



        public string CalculateInvoiceDiscount(TaskControl.Policies taskControl, string ReturnType)
        {
            TaskControl.Policies taskcontrol2 = TaskControl.Policies.GetPolicies(taskControl.TaskControlID);
            if (taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "AAE" || taskControl.PolicyType.Trim() == "PP" || taskControl.PolicyType.Trim() == "AAP" || taskControl.PolicyType.Trim() == "IF")
            {
                double totPrem = taskControl.TotalPremium;
                double InvoiceDiscount = 0.00;
                if (taskControl.InvoiceNumber != "")
                    InvoiceDiscount = (double.Parse(taskControl.InvoiceNumber));

                //double OriginalPremium = taskcontrol2.MCMRate;

                double discount = Math.Round((InvoiceDiscount / 100.0) * totPrem, 0);


                double Assit = 0.0; //taskcontrol2.TotPremTN6;
                double prima = taskControl.TotalPremium;
                double discountTN6 = Math.Round((totPrem - taskcontrol2.TotPremTN6) * (InvoiceDiscount / 100.0), 0);

                double Prima_Employee = 0.0;

                if (taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "AAE")
                {
                    Prima_Employee = taskcontrol2.ETotPremTN6;
                    Assit = taskcontrol2.ETotPremTN6;
                }
                else if (taskControl.PolicyType.Trim() == "PP" || taskControl.PolicyType.Trim() == "AAP" || taskControl.PolicyType.Trim() == "IF")
                {
                    Prima_Employee = taskcontrol2.TotPremTN6;
                    Assit = taskcontrol2.TotPremTN6;
                }

                double NueveCinco = ((100.0 - InvoiceDiscount) / 100.0);
                double OriginalPremium = Math.Round(((prima - Prima_Employee) / NueveCinco), 0);
                double Dcount = Math.Round((OriginalPremium - (prima - Prima_Employee)), 0);



                if (taskControl.PolicyType.Contains("E"))
                {
                    if (ReturnType == "Discount")
                    {
                        if (Dcount != 0)
                        {
                            return Dcount.ToString("C", CultureInfo.CurrentCulture);
                        }
                        else
                            return "";
                    }
                    else
                    {
                        if (Assit != 0)
                        {
                            return Assit.ToString("C", CultureInfo.CurrentCulture);
                        }
                        else
                            return "";
                    }

                }

                else
                {

                    if (ReturnType == "Discount")
                    {
                        if (Dcount != 0)
                        {
                            return Dcount.ToString("C", CultureInfo.CurrentCulture);
                        }
                        else
                            return "";
                    }
                    else
                    {
                        if (Assit != 0)
                        {
                            return Assit.ToString("C", CultureInfo.CurrentCulture);
                        }
                        else
                            return "";
                    }

                }
            }

            else
            {

                if (ReturnType == "Discount")
                    return "";
                else
                    return "";
            }

        }


        public static DataTable GetReportMasterDocumentsByCriteria(string WhereClause)
        {
            DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("WhereClause",
            SqlDbType.VarChar, 3000, WhereClause.ToString(),
            ref cookItems);


            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
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
                dt = exec.GetQuery("GetReportMasterDocumentsByCriteria", xmlDoc);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }

        public static DataTable GetReportMasterInformationByTaskcontrolID(int TaskcontrolID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("TaskcontrolID",
            SqlDbType.Int, 0, TaskcontrolID.ToString(),
            ref cookItems);


            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
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
                dt = exec.GetQuery("GetReportMasterInformationByTaskcontrolID", xmlDoc);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }

        public string ConstructWhereClauseForReport()
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

            string whereClause = "";


            whereClause = " (PolicyType = '" + taskControl.PolicyType + "' ";

            whereClause += "  or PolicyType = 'ALL') ";

            if (taskControl.Anniversary == "01")
            {
                whereClause += " and (TransactionType = 'ALL' or TransactionType = 'NEW') ";
            }
            else
            {
                whereClause += " and (TransactionType = 'ALL' or TransactionType = 'RENEWAL') ";
            }


            if (taskControl.CyberEndorsementPremium == 0.00)
            {
                whereClause += " and (FormName != 'eMed Defense Cyber Endorsement') ";
            }

            if (taskControl.EffectiveDate == taskControl.RetroactiveDate)
            {
                whereClause = whereClause + " and FormName != 'PRIOR ACT ENDORSEMENT (NOSE)' ";
            }

            return whereClause;
        }

        protected void ddlPriPolLimits1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TxtPolicyNo_TextChanged(object sender, EventArgs e)
        {

        }
        protected void ddlPrMedicalLimits_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void btnBack_Click(object sender, EventArgs e)
        
            {
                if (TxtPolicyNo.Text != "")
                {
                    TxtPolicyNo.Text = (int.Parse(TxtPolicyNo.Text) - 1).ToString();
                }
            }


        protected void btnFoward_Click(object sender, EventArgs e)
        {
            
                if (TxtPolicyNo.Text != "")
                {
                    TxtPolicyNo.Text = (int.Parse(TxtPolicyNo.Text) + 1).ToString();
                }
            

        }
        protected void btnComment_Click(object sender, EventArgs e)
        {
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            TaskControl.Comment comment = (TaskControl.Comment) new TaskControl.Comment();

            comment.TaskControlID = taskControl.TaskControlID;
            comment.PolicyNo = taskControl.PolicyNo;
            Session.Add("TaskControlComments", comment);
            RemoveSessionLookUp();
            Session.Add("FromPage", "CorporatePolicyQuote.aspx");
            Response.Redirect("Comments.aspx");


        }
        protected void DtGridCorpaoratePol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void dtEndorsement_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TaskControl.CorporatePolicyQuote taskControl = (TaskControl.CorporatePolicyQuote)Session["TaskControl"]; // Kayla lo mando hacer para los ddl
            //DataTable dtAgent = TaskControl.CorporatePolicyQuote.GetAgentByAgency(ddlAgency.SelectedItem.Value);
            //DataTable dt = TaskControl.CorporatePolicyQuote.GetAgent();
            //DataTable dtnull = null;


            //   if (dtAgent.Rows.Count > 0 && taskControl.EntryDate >= DateTime.Parse("05/25/2017"))
                   
            //    {
            //        //Agent
            //        ddlAgent.DataSource = dtAgent;
            //        ddlAgent.DataTextField = "AgentDesc";
            //        ddlAgent.DataValueField = "AgentID";
            //        ddlAgent.DataBind();
            //        ddlAgent.SelectedIndex = -1;
            //        ddlAgent.Items.Insert(0, "");

            //    }
            //    else
            //    {
            //        ////Agent 
            //        ddlAgent.DataSource = dt;
            //        ddlAgent.DataTextField = "AgentDesc";
            //        ddlAgent.DataValueField = "AgentID";
            //        ddlAgent.DataBind();
            //        ddlAgent.SelectedIndex = -1;
            //        ddlAgent.Items.Insert(0, "");
            //        // ddlAgent.Items.Clear(); Si agency no tiene agent usar esto

            //    }
            
           
        }
        private void EndorsementControl(bool Enable)
        {
            lblDatePrepared.Enabled = Enable;
            txtDatePrepared.Enabled = Enable;
            lblEndoEffDate.Enabled = Enable;
            txtEndoEffDate.Enabled = Enable;
            //lblEndoRetroDate.Enabled = Enable;
            //txtRetroEffDate.Enabled = Enable;
            lblEndoPremium.Enabled = Enable;
            txtEndoPremium.Enabled = Enable;
            lblEndoType.Enabled = Enable;
            ddlEndoType.Enabled = Enable;
            lblEndoComments.Enabled = Enable;
            txtEndoComments.Enabled = Enable;
            txtEndorsementNo.Enabled = Enable;
            lblEndorsementNo.Enabled = Enable;

            lblDatePrepared.Visible = Enable;
            txtDatePrepared.Visible = Enable;
            lblEndoEffDate.Visible = Enable;
            txtEndoEffDate.Visible = Enable;
            //lblEndoRetroDate.Visible = Enable;
            //txtRetroEffDate.Visible = Enable;
            lblEndoPremium.Visible = Enable;
            txtEndoPremium.Visible = Enable;
            lblEndoType.Visible = Enable;
            ddlEndoType.Visible = Enable;
            lblEndoComments.Visible = Enable;
            txtEndoComments.Visible = Enable;
            txtEndorsementNo.Visible = Enable;
            lblEndorsementNo.Visible = Enable;
        }
}
}
