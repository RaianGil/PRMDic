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
using EPolicy;
using EPolicy.TaskControl;
using Baldrich.DBRequest;
using EPolicy.XmlCooker;
using System.Xml;
using Microsoft.Reporting.WebForms;
using System.IO;
using EPolicy2.Reports;
using EPolicy.LookupTables;
using System.Collections.Generic;
using System.Globalization;

namespace EPolicy
{
    public partial class CyberApplication : System.Web.UI.Page
    {

        private DataTable DtTaskPolicy;
        private DataTable DtEndorsement;
        private static bool convert = false;
        private static int oldTaskControlID = 0;
        private int userID = 0;
        private bool prmdicAdmin = false;
        //private static int taskControlID = 0;
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
                Banner = LoadControl(@"TopBanner1.ascx");
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
                            EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
                            

                            TxtTerm.Attributes.Add("onblur", "getExpDt()");
                            TxtTerm.Attributes.Add("onchange", "getExpDt()");

                            txtEffDt.Attributes.Add("onblur", "getExpDt()");
                            txtEffDt.Attributes.Add("onchange", "getExpDt()");

                            LookupTables.MasterPolicy master = new LookupTables.MasterPolicy();
                            DataTable dtCorporation = master.GetMasterPolicyByIsGroup(false);
                            //DataTable dtPRPrimaryLimit = LookupTables.LookupTables.GetTable("PRPrimaryLimit");
                            DataTable dtCiudad = LookupTables.LookupTables.GetTable("Ciudad");
                            DataTable dtCyberLimit = LookupTables.LookupTables.GetTable("CyberLimits");
                            DataTable dtCyberEnity = LookupTables.LookupTables.GetTable("CyberEnity");
                            DataTable dtCyberPracticeHistory = LookupTables.LookupTables.GetTable("CyberPracticeHistory");
                            DataTable dtCyberNumberOfPhysicians = LookupTables.LookupTables.GetTable("CyberNumberOfPhysicians");
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

                            //City
                            ddlCity.DataSource = dtCity;
                            ddlCity.DataTextField = "SucursalCity";
                            ddlCity.DataValueField = "SucursalID";
                            ddlCity.DataBind();
                            ddlCity.SelectedIndex = -1;
                            ddlCity.Items.Insert(0, "");

                            //Enity
                            ddlEnity.DataSource = dtCyberEnity;
                            ddlEnity.DataTextField = "EnityDesc";
                            ddlEnity.DataValueField = "EnityID";
                            ddlEnity.DataBind();
                            ddlEnity.SelectedIndex = -1;
                            ddlEnity.Items.Insert(0, "");

                            //Practice History
                            ddlPracticeHistory.DataSource = dtCyberPracticeHistory;
                            ddlPracticeHistory.DataTextField = "PracticeDesc";
                            ddlPracticeHistory.DataValueField = "PracticeID";
                            ddlPracticeHistory.DataBind();
                            ddlPracticeHistory.SelectedIndex = -1;
                            ddlPracticeHistory.Items.Insert(0, "");

                            //Number of Physicians
                            ddlNumOfPhysicians.DataSource = dtCyberNumberOfPhysicians;
                            ddlNumOfPhysicians.DataTextField = "NumberOfPhysiciansDesc";
                            ddlNumOfPhysicians.DataValueField = "NumberOfPhysiciansID";
                            ddlNumOfPhysicians.DataBind();
                            ddlNumOfPhysicians.SelectedIndex = -1;
                            ddlNumOfPhysicians.Items.Insert(0, "");

                            //Agent
                            ddlAgent.DataSource = dtAgent;
                            ddlAgent.DataTextField = "AgentDesc";
                            ddlAgent.DataValueField = "AgentID";
                            ddlAgent.DataBind();
                            ddlAgent.SelectedIndex = -1;
                            ddlAgent.Items.Insert(0, "");

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

                            //Main Specialty
                            //ddlMainSpecialty.Items.Clear();
                            //ddlMainSpecialty.DataSource = dtPRMEDICRATE2;
                            //ddlMainSpecialty.DataTextField = "PRMEDICSpecialtyDesc";
                            //ddlMainSpecialty.DataValueField = "PRMEDICSpecialtyID";
                            //ddlMainSpecialty.DataBind();
                            //ddlMainSpecialty.SelectedIndex = -1;
                            //ddlMainSpecialty.Items.Insert(0, "");

                            //ddlMainSpecialty.Items.Clear();
                            //ddlMainSpecialty.Items.Add(new ListItem("Medical or X-Ray cyber", "1"));

                            ddlMainSpecialty.Items.Clear();
                            ddlMainSpecialty.Items.Add(new ListItem("Clinical Cyber", "138"));
                            ddlMainSpecialty.Items.Add(new ListItem("Imaging Center", "139"));

                            //Other SpecialtyA
                            //ddlOtherSpecialtyA.Items.Clear();
                            //ddlOtherSpecialtyA.DataSource = dtPRMEDICRATE2;
                            //ddlOtherSpecialtyA.DataTextField = "PRMEDICSpecialtyDesc";
                            //ddlOtherSpecialtyA.DataValueField = "PRMEDICSpecialtyID";
                            //ddlOtherSpecialtyA.DataBind();
                            //ddlOtherSpecialtyA.SelectedIndex = -1;
                            //ddlOtherSpecialtyA.Items.Insert(0, "");

                            //Other SpecialtyB
                            ddlOtherSpecialtyB.Items.Clear();
                            ddlOtherSpecialtyB.DataSource = dtPRMEDICRATE2;
                            ddlOtherSpecialtyB.DataTextField = "PRMEDICSpecialtyDesc";
                            ddlOtherSpecialtyB.DataValueField = "PRMEDICSpecialtyID";
                            ddlOtherSpecialtyB.DataBind();
                            ddlOtherSpecialtyB.SelectedIndex = -1;
                            ddlOtherSpecialtyB.Items.Insert(0, "");

                            //CyberLimit
                            ddlCyberLimits.DataSource = dtCyberLimit;
                            ddlCyberLimits.DataTextField = "LimitDesc";
                            ddlCyberLimits.DataValueField = "LimitID";
                            ddlCyberLimits.DataBind();
                            ddlCyberLimits.SelectedIndex = -1;
                            ddlCyberLimits.Items.Insert(0, "");
                            //ddlCyberLimits.Items.Clear();
                            //ddlCyberLimits.Items.Add(new ListItem("", "0"));
                            //ddlCyberLimits.Items.Add(new ListItem("50,000/1,000", "1"));
                            //ddlCyberLimits.Items.Add(new ListItem("100,000/1,500", "2"));
                            //ddlCyberLimits.Items.Add(new ListItem("250,000/2,500", "3"));
                            //ddlCyberLimits.Items.Add(new ListItem("500,000/2,5000", "4"));
                            //ddlCyberLimits.Items.Add(new ListItem("1,000,000/5,000", "5"));

                            //PolicyLimits
                            ddlLimitsPolicyInfo.DataSource = dtCyberLimit;
                            ddlLimitsPolicyInfo.DataTextField = "LimitDesc";
                            ddlLimitsPolicyInfo.DataValueField = "LimitID";
                            ddlLimitsPolicyInfo.DataBind();
                            ddlLimitsPolicyInfo.SelectedIndex = -1;
                            ddlLimitsPolicyInfo.Items.Insert(0, "");



                            //Group(Poliza)
                            ddlGroup.DataSource = dtGroup;
                            ddlGroup.DataTextField = "MasterPolicyDesc";
                            ddlGroup.DataValueField = "MasterPolicyID";
                            ddlGroup.DataBind();
                            ddlGroup.SelectedIndex = -1;
                            ddlGroup.Items.Insert(0, "");

                            switch (taskControl.Mode)
                            {
                                case 1: //ADD
                                    EnableControls();
                                    FillTextControl();
                                    if (taskControl.IsPolicy)
                                    {
                                        EnableQuestions();
                                        //DisableQuestions();
                                    }
                                    EndorsementControl(false);
                                    break;

                                case 2: //UPDATE
                                    DisableControls();
                                    FillTextControl();

                                    if (taskControl.isEndorsement)
                                    {
                                        EndorsementControl(true);
                                        this.TxtFirstName.Enabled = true;
                                        pnlEndorsement.Visible = true;
                                        pnlEndorsement.Enabled = true;
                                        txtDatePrepared.Text = DateTime.Now.ToShortDateString();
                                        txtDatePrepared.Enabled = false;

                                        txtEndorsementNo.Text = (taskControl.Endoso + 1).ToString();

                                        lblEndorsement.Visible = false;
                                        dtEndorsement.Visible = false;
                                    }
                                    else
                                        EndorsementControl(false);
                                    break;

                                default:
                                    DisableControls();
                                    FillTextControl();
                                    FillGrid();
                                    EndorsementControl(false);
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    FillTextControl();
                    EnableControls();
                    FillGrid();
                    //FillDataGridInsurance();
                    Session.Remove("AutoPostBack");
                }
                HideControl();

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void FillTextControl()
        {
            try
            {
                EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
                Login.Login cp = HttpContext.Current.User as Login.Login;
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                TxtCustomerNo.Text = taskControl.Customer.CustomerNo;
                TxtProspectNo.Text = taskControl.Customer.ProspectID.ToString();
                lblTCID.Text = taskControl.TaskControlID.ToString();
                TxtFirstName.Text = taskControl.Customer.FirstName.Trim();
                TxtCellular.Text = taskControl.Customer.Cellular.Trim();
                //txtLastname1.Text = taskControl.Customer.LastName1.Trim();
                //txtLastname2.Text = taskControl.Customer.LastName2.Trim();
                txtLicense.Text = taskControl.Customer.Licence.Trim();
                TxtAddrs1.Text = taskControl.Customer.Address1.Trim();
                TxtAddrs2.Text = taskControl.Customer.Address2.Trim();
                TxtCity.Text = taskControl.Customer.City.Trim();
                TxtState.Text = taskControl.Customer.State.Trim();
                TxtZip.Text = taskControl.Customer.ZipCode.Trim();
                TxtCustomerNo.Text = taskControl.Customer.CustomerNo.Trim();
                txtHomePhone.Text = taskControl.Customer.HomePhone.Trim();
                TxtCellular.Text = taskControl.Customer.Cellular.Trim();
                txtWorkPhone.Text = taskControl.Customer.JobPhone.Trim();
                txtEmail.Text = taskControl.Customer.Email.Trim();

                LblStatus.Text = taskControl.Status;

                txtNumOfPatients.Text = taskControl.numberPatients.Trim();
                ChkAutoAssignPolicy.Checked = taskControl.AutoAssignPolicy;
                TxtPolicyNo.Text = taskControl.PolicyNo.Trim();
                TxtCertificate.Text = taskControl.Certificate.Trim();
                TxtPolicyType.Text = taskControl.PolicyType.Trim();
                TxtSufijo.Text = taskControl.Suffix.Trim();
                TxtAnniversary.Text = taskControl.Anniversary.Trim();
                TxtTerm.Text = taskControl.Term.ToString().Trim();
                TxtRetroactiveDate.Text = taskControl.RetroDate;//taskControl.RetroactiveDate.Trim();
                txtEffDt.Text = taskControl.EffectiveDate.Trim();
                txtTotalDebit.Text = taskControl.totalDebit.ToString();
                txtTotalCredit.Text = taskControl.totalCredit.ToString();
                txtTotalCreditDebit.Text = taskControl.totalCreditDebit.ToString();

                if (taskControl.CancellationDate == String.Empty)
                    txtExpDt.Text = taskControl.ExpirationDate.Trim();
                else
                {
                    txtExpDt.Text = taskControl.CancellationDate;
                    lblExpDate.Text = "Canc. Date";
                }

                txtEntryDate.Text = taskControl.EntryDate.ToShortDateString().ToString().Trim();
                txtCoverage.Text = taskControl.Coverage.Trim();
                txtCode.Text = taskControl.Code.Trim();

                // txtEstGrossReceipt.Text = taskControl.EstimatedGrossReceipts.ToString("###,###.00").Trim();
                TxtCharge.Text = taskControl.Charge.ToString("###,###.00").Trim();
                TxtPremium.Text = taskControl.Premium.ToString("###,###.00").Trim();
                TxtCancAmount.Text = taskControl.CancellationAmount.ToString("###,###.00").Trim();
                TxtTotalPremium.Text = taskControl.TotalPremium.ToString("###,###.00").Trim();
                txtOtherEnity.Text = taskControl.otherEnity.ToString().Trim();

                ddlEnity.SelectedIndex = ddlEnity.Items.IndexOf(ddlEnity.Items.FindByValue(taskControl.EnityID.ToString().Trim()));
                ddlNumOfPhysicians.SelectedIndex = ddlNumOfPhysicians.Items.IndexOf(ddlNumOfPhysicians.Items.FindByValue(taskControl.numberPhysiciansID.ToString().Trim()));
                ddlPracticeHistory.SelectedIndex = ddlPracticeHistory.Items.IndexOf(ddlPracticeHistory.Items.FindByValue(taskControl.practiceHistoryID.ToString().Trim()));
                ddlCyberLimits.SelectedIndex = ddlCyberLimits.Items.IndexOf(ddlCyberLimits.Items.FindByValue(taskControl.LimitsID.ToString().Trim()));
                ddlAgency.SelectedIndex = ddlAgency.Items.IndexOf(ddlAgency.Items.FindByValue(taskControl.Agency.Trim()));

                if (taskControl.City != 0)
                {
                    ddlCity.SelectedIndex = ddlCity.Items.IndexOf(
                        ddlCity.Items.FindByValue(taskControl.City.ToString()));
                }

                ddlAgent.SelectedIndex = ddlAgent.Items.IndexOf(ddlAgent.Items.FindByValue(taskControl.Agent.Trim()));
                ddlAgent2.SelectedIndex = ddlAgent2.Items.IndexOf(ddlAgent2.Items.FindByValue(taskControl.Agent2.Trim()));
                ddlCorparation.SelectedIndex = ddlCorparation.Items.IndexOf(ddlCorparation.Items.FindByValue(taskControl.CompanyDealer.Trim()));
                ddlInsuranceCompany.SelectedIndex = ddlInsuranceCompany.Items.IndexOf(ddlInsuranceCompany.Items.FindByValue(taskControl.InsuranceCompany.Trim()));
                ddlGroup.SelectedIndex = ddlGroup.Items.IndexOf(ddlGroup.Items.FindByValue(taskControl.Bank.Trim()));

                if (taskControl.FinancialID != 0)
                    ddlFinancial.SelectedIndex = ddlFinancial.Items.IndexOf(
                        ddlFinancial.Items.FindByValue(taskControl.FinancialID.ToString()));

                ddlMainSpecialty.SelectedIndex = ddlMainSpecialty.Items.IndexOf(ddlMainSpecialty.Items.FindByValue(taskControl.SpecialtyID.ToString().Trim()));
                //ddlOtherSpecialtyA.SelectedIndex = ddlOtherSpecialtyA.Items.IndexOf(ddlOtherSpecialtyA.Items.FindByValue(taskControl.OtherSpecialtyID.ToString().Trim()));
                ddlOtherSpecialtyB.SelectedIndex = ddlOtherSpecialtyB.Items.IndexOf(ddlOtherSpecialtyB.Items.FindByValue(taskControl.OtherSpecialty2ID.ToString().Trim()));

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


                TxtComments.Text = taskControl.Comment.Trim();

                //taskControl.Premium = TxtPremium.Text.ToString();
                //_TotalPremium1.Value = taskControl.TotalPremium1.ToString();
                //_TotalPremium2.Value = taskControl.TotalPremium2.ToString();
                //_TotalPremium3.Value = taskControl.TotalPremium3.ToString();
                //_TotalPremium4.Value = taskControl.TotalPremium4.ToString();
                //_Factor.Value = taskControl.Factor.ToString();
                ///////////////////
                if (taskControl.privacyOfficer)
                {
                    rblPrivacyOfficer.SelectedIndex = 0;
                }
                else
                {
                    rblPrivacyOfficer.SelectedIndex = 1;
                }
                if (taskControl.privacyPractice)
                {
                    rblPrivacyPractice.SelectedIndex = 0;
                }
                else
                {
                    rblPrivacyPractice.SelectedIndex = 1;
                }
                if (taskControl.awerenessTrain)
                {
                    rblAwerenessTrain.SelectedIndex = 0;
                }
                else
                {
                    rblAwerenessTrain.SelectedIndex = 1;
                }
                if (taskControl.techPerson)
                {
                    rblTechPerson.SelectedIndex = 0;
                }
                else
                {
                    rblTechPerson.SelectedIndex = 1;
                }
                if (taskControl.privacyBreach)
                {
                    rblPrivacyBreach.SelectedIndex = 0;
                }
                else
                {
                    rblPrivacyBreach.SelectedIndex = 1;
                }
                if (taskControl.gmail)
                {
                    rblGmail.SelectedIndex = 0;
                }
                else
                {
                    rblGmail.SelectedIndex = 1;
                }
                if (taskControl.lockedCab)
                {
                    rblLockedCab.SelectedIndex = 0;
                }
                else
                {
                    rblLockedCab.SelectedIndex = 1;
                }
                if (taskControl.paperRetention)
                {
                    rblPaperRet.SelectedIndex = 0;
                }
                else
                {
                    rblPaperRet.SelectedIndex = 1;
                }
                if (taskControl.shredDoc)
                {
                    rblShredDoc.SelectedIndex = 0;
                }
                else
                {
                    rblShredDoc.SelectedIndex = 1;
                }
                if (taskControl.itNetworkEncrypted)
                {
                    rblITEncrypted.SelectedIndex = 0;
                }
                else
                {
                    rblITEncrypted.SelectedIndex = 1;
                }
                if (taskControl.itNetworkAccesible)
                {
                    rblITNetwork.SelectedIndex = 0;
                }
                else
                {
                    rblITNetwork.SelectedIndex = 1;
                }
                if (taskControl.elecRecOnline)
                {
                    rblElecRecOnline.SelectedIndex = 0;
                }
                else
                {
                    rblElecRecOnline.SelectedIndex = 1;
                }
                if (taskControl.elecRecWeb)
                {
                    rblElecRecWebBase.SelectedIndex = 0;
                }
                else
                {
                    rblElecRecWebBase.SelectedIndex = 1;
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
                {
                    txtNumberOfEmployees.Text = "";                    
                }
                else
                {
                    txtNumberOfEmployees.Text = taskControl.NumberOfEmployees.ToString();                    
                }
                if (cp.IsInRole("POWERAGENT"))
                {
                    VisibleQuestions();

                }


                ///////////////
                FillEndorsementGrid();
                FillDataGridInsurance();

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
                    

                }


                DataTable DtComment = new DataTable();
                DtComment = Comment.GetComment(taskControl.TaskControlID);

                if (DtComment.Rows.Count > 0 && taskControl.TaskControlID != 0)
                {
                    btnComment.BackColor = System.Drawing.Color.Yellow;
                    btnComment.ForeColor = System.Drawing.Color.Black;
                }



            }

            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void FillProperties()
        {
            try
            {
                EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
                Login.Login cp = HttpContext.Current.User as Login.Login;
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                taskControl.Customer.FirstName = TxtFirstName.Text.ToString().Trim().ToUpper();
                //taskControl.Customer.LastName1 = txtLastname1.Text.ToString().Trim().ToUpper();
                //taskControl.Customer.LastName2 = txtLastname2.Text.ToString().Trim().ToUpper();
                //taskControl.Customer.Initial = TxtInitial.Text.ToString().Trim().ToUpper();
                taskControl.Customer.Address1 = TxtAddrs1.Text.ToString().Trim().ToUpper();
                taskControl.Customer.Address2 = TxtAddrs2.Text.ToString().Trim().ToUpper();
                taskControl.Customer.City = TxtCity.Text.ToString().Trim().ToUpper();
                taskControl.Customer.State = TxtState.Text.ToString().Trim().ToUpper();
                taskControl.Customer.ZipCode = TxtZip.Text.ToString().Trim().ToUpper();
                taskControl.Customer.HomePhone = txtHomePhone.Text.ToString().Trim().ToUpper();
                taskControl.Customer.JobPhone = txtWorkPhone.Text.ToString().Trim().ToUpper();
                taskControl.Customer.Email = txtEmail.Text.ToString().Trim().ToUpper();
                taskControl.Customer.Cellular = TxtCellular.Text.ToString().Trim();
                taskControl.Customer.Licence = txtLicense.Text.ToString().Trim();

                if (txtTotalDebit.Text != "")
                    taskControl.totalDebit = int.Parse(txtTotalDebit.Text.ToString());
                else
                    taskControl.totalDebit = 0;
                if (txtTotalCredit.Text != "")
                    taskControl.totalCredit = int.Parse(txtTotalCredit.Text.ToString());
                else
                    taskControl.totalCredit = 0;
                if (txtTotalCreditDebit.Text != "")
                    taskControl.totalCreditDebit = int.Parse(txtTotalCreditDebit.Text.ToString());
                else
                    taskControl.totalCreditDebit = 0;

                if (ddlAgency.SelectedItem.Value.ToString().Trim() != "" && ddlAgency.SelectedItem.Value.ToString().Trim() != null)
                    taskControl.Agency = ddlAgency.SelectedItem.Value.ToString().Trim();
                else
                    taskControl.Agency = "000";

                if (ddlCity.SelectedIndex > 0 && ddlCity.SelectedIndex != null)
                    taskControl.City = int.Parse(ddlCity.SelectedItem.Value);
                else
                    taskControl.City = 0;

                taskControl.LbxAgentSelected = ddlSelectedAgent;

                if (ddlAgent.SelectedItem.Value.ToString().Trim() != null && ddlAgent.SelectedItem.Value.ToString().Trim() != "")
                    taskControl.Agent = ddlAgent.SelectedItem.Value.ToString().Trim();
                else
                    taskControl.Agent = "000";

                if (ddlAgent2.SelectedItem.Value.ToString().Trim() != null && ddlAgent2.SelectedItem.Value.ToString().Trim() != "")
                    taskControl.Agent2 = ddlAgent2.SelectedItem.Value.ToString().Trim();
                else
                    taskControl.Agent2 = "000";

                if (ddlInsuranceCompany.SelectedItem.Value.ToString().Trim() != null && ddlInsuranceCompany.SelectedItem.Value.ToString().Trim() != "")
                    taskControl.InsuranceCompany = ddlInsuranceCompany.SelectedItem.Value.ToString().Trim();
                else
                    taskControl.InsuranceCompany = "000";

                taskControl.ClaimNo = txtClaimNumber.Text.ToString().Trim();

                if (ddlCorparation.SelectedItem.Value.ToString().Trim() != null && ddlCorparation.SelectedItem.Value.ToString().Trim() != "")
                    taskControl.CompanyDealer = ddlCorparation.SelectedItem.Value.ToString().Trim();
                else
                    taskControl.CompanyDealer = "000";

                if (ddlGroup.SelectedItem.Value.ToString().Trim() != null && ddlGroup.SelectedItem.Value.ToString().Trim() != "")
                    taskControl.Bank = ddlGroup.SelectedItem.Value.ToString().Trim();
                else
                    taskControl.Bank = "000";

                //Policy Information

                taskControl.PolicyNo = TxtPolicyNo.Text.ToString().Trim();
                taskControl.AutoAssignPolicy = false;//ChkAutoAssignPolicy.Checked;
                taskControl.Certificate = TxtCertificate.Text.ToString().Trim();
                taskControl.PolicyType = TxtPolicyType.Text.ToString().Trim();
                taskControl.Suffix = TxtSufijo.Text.ToString().Trim();

                if (TxtTerm.Text.ToString().Trim() != "")
                    taskControl.Term = int.Parse(TxtTerm.Text.ToString().Trim());
                else
                    taskControl.Term = 0;

                taskControl.Anniversary = TxtAnniversary.Text.ToString().Trim();

                if (txtEntryDate.Text.ToString().Trim() != "")
                    taskControl.EntryDate = DateTime.Parse(txtEntryDate.Text.ToString().Trim());
                else
                    taskControl.EntryDate = DateTime.Now;

                taskControl.EffectiveDate = txtEffDt.Text.ToString().Trim();
                if (taskControl.CancellationDate == String.Empty)
                    taskControl.ExpirationDate = txtExpDt.Text.ToString().Trim();
                taskControl.RetroactiveDate = TxtRetroactiveDate.Text.ToString().Trim();
                taskControl.RetroDate = TxtRetroactiveDate.Text.ToString().Trim();
                if (TxtComments.Text.ToString() != "")
                {
                    taskControl.Comment = TxtComments.Text.ToString().Trim();
                }
                taskControl.CommissionAgencyPercent = "000";

                if (ddlMainSpecialty.SelectedItem.Value != "" && ddlMainSpecialty.SelectedItem.Value != null)
                {
                    taskControl.SpecialtyID = int.Parse(ddlMainSpecialty.SelectedItem.Value.ToString());
                    taskControl.SpecialtyDesc = ddlMainSpecialty.SelectedItem.Text.ToString().Trim();
                }
                else
                {
                    taskControl.SpecialtyID = 0;
                    taskControl.SpecialtyDesc = "";
                }

                if (ddlFinancial.SelectedItem.Value != null && ddlFinancial.SelectedItem.Value != "")
                {
                    taskControl.FinancialID = int.Parse(ddlFinancial.SelectedItem.Value.ToString().Trim());
                    taskControl.FinancialDesc = ddlFinancial.SelectedItem.Text.ToString().Trim();
                }
                else
                {
                    taskControl.FinancialID = 0;
                    taskControl.FinancialDesc = "";
                }

                //if (ddlOtherSpecialtyA.SelectedItem.Value != "" && ddlOtherSpecialtyA.SelectedItem.Value != null)
                //{
                //    taskControl.OtherSpecialtyID = int.Parse(ddlOtherSpecialtyA.SelectedItem.Value.ToString().Trim());
                //    taskControl.OtherSpecialtyDesc = ddlOtherSpecialtyA.SelectedItem.Text.ToString().Trim();
                //}
                //else
                //{
                //    taskControl.OtherSpecialtyID = 0;
                //    taskControl.OtherSpecialtyDesc = "";
                //}

                if (ddlOtherSpecialtyB.SelectedItem.Value != "" && ddlOtherSpecialtyB.SelectedItem.Value != null)
                {
                    taskControl.OtherSpecialty2ID = int.Parse(ddlOtherSpecialtyB.SelectedItem.Value.ToString().Trim());
                    taskControl.OtherSpecialtyDesc2 = ddlOtherSpecialtyB.SelectedItem.Text.ToString().Trim();
                }
                else
                {
                    taskControl.OtherSpecialty2ID = 0;
                    taskControl.OtherSpecialtyDesc2 = "";
                }

                if (ddlPriorAct.SelectedItem.Value != "" && taskControl.Anniversary == "01" && taskControl.Mode == 1 && taskControl.IsPolicy)
                {
                    taskControl.limitReduced = ddlPriorAct.SelectedItem.Value.ToString().Trim().Equals("1");
                }

                taskControl.ProfessionalLiabilityCoverage = "";

                if (txtEstGrossReceipt.Text.ToString().Trim() != "")
                    taskControl.EstimatedGrossReceipts = double.Parse(txtEstGrossReceipt.Text.ToString().Trim());
                else
                    taskControl.EstimatedGrossReceipts = 0;

                if (ddlCyberLimits.SelectedItem.Value != "" && ddlCyberLimits.SelectedItem.Value != null)
                {
                    if (int.Parse(ddlCyberLimits.SelectedItem.Value.ToString().Trim()) < taskControl.LimitsID)
                        taskControl.limitReduced = true;

                    taskControl.LimitsID = int.Parse(ddlCyberLimits.SelectedItem.Value.ToString().Trim());
                    taskControl.LimitsDesc = ddlCyberLimits.SelectedItem.Text.ToString().Trim();


                }
                else
                {
                    taskControl.LimitsID = 0;
                    taskControl.LimitsDesc = "";
                }

                if (TxtCharge.Text.ToString().Trim() != "")
                    taskControl.Charge = double.Parse(TxtCharge.Text.ToString().Trim());
                else
                    taskControl.Charge = 0;

                if (TxtPremium.Text.ToString().Trim() != "")
                    taskControl.Premium = double.Parse(TxtPremium.Text.ToString().Trim());
                else
                    taskControl.Premium = 0;

                if (TxtTotalPremium.Text.ToString().Trim() != "")
                    taskControl.TotalPremium = double.Parse(TxtTotalPremium.Text.ToString().Trim());
                else
                    taskControl.TotalPremium = 0;

                if (TxtCancAmount.Text.ToString().Trim() != "")
                    taskControl.CancellationAmount = double.Parse(TxtCancAmount.Text.ToString().Trim());
                else
                    taskControl.CancellationAmount = 0;

                if (ddlEnity.SelectedItem.Value != "")
                {
                    taskControl.EnityDesc = ddlEnity.SelectedItem.Text.ToString().Trim();
                    taskControl.EnityID = int.Parse(ddlEnity.SelectedItem.Value.ToString().Trim());
                }
                else
                {
                    taskControl.EnityID = 0;
                    taskControl.EnityDesc = "";
                }

                if (txtOtherEnity.Text != "")
                    taskControl.otherEnity = txtOtherEnity.Text.ToString().Trim();
                else
                    taskControl.otherEnity = "";

                if (ddlPracticeHistory.SelectedItem.Value != "")
                {
                    taskControl.practiceHistoryDesc = ddlPracticeHistory.SelectedItem.Text.ToString().Trim();
                    taskControl.practiceHistoryID = int.Parse(ddlPracticeHistory.SelectedItem.Value.ToString().Trim());
                }
                else
                {
                    taskControl.practiceHistoryID = 0;
                    taskControl.practiceHistoryDesc = "";
                }

                if (txtNumOfPatients.Text != "")
                    taskControl.numberPatients = txtNumOfPatients.Text.ToString().Trim();
                else
                    taskControl.numberPatients = "";
                if (ddlNumOfPhysicians.SelectedItem.Value != "")
                {
                    taskControl.numberPhysiciansID = int.Parse(ddlNumOfPhysicians.SelectedItem.Value.ToString().Trim());
                    taskControl.numberPhysiciansDesc = ddlNumOfPhysicians.SelectedItem.Text.ToString().Trim();
                }
                else
                {
                    taskControl.numberPhysiciansID = 0;
                    taskControl.numberPhysiciansDesc = "";
                }



                taskControl.SupplierID = "000";

                taskControl.Code = txtCode.Text.Trim();
                taskControl.Coverage = txtCoverage.Text.Trim();

                //taskControl.Premium = TxtPremium.Text.ToString();
                //taskControl.TotalPremium = TxtPremium.Text.ToString();
                //taskControl.TotalPremium1 = double.Parse(_TotalPremium1.Value.ToString().Trim());
                //taskControl.TotalPremium2 = double.Parse(_TotalPremium2.Value.ToString().Trim());
                //taskControl.TotalPremium3 = double.Parse(_TotalPremium3.Value.ToString().Trim());
                //taskControl.TotalPremium4 = double.Parse(_TotalPremium4.Value.ToString().Trim());
                //taskControl.Factor = double.Parse(_Factor.Value.ToString().Trim());

                if (rblPrivacyOfficer.SelectedIndex == 0)
                {
                    taskControl.privacyOfficer = true;

                }
                else
                {
                    taskControl.privacyOfficer = false;

                }
                if (rblPrivacyPractice.SelectedIndex == 0)
                {
                    taskControl.privacyPractice = true;
                }
                else
                {
                    taskControl.privacyPractice = false;
                }
                if (rblAwerenessTrain.SelectedIndex == 0)
                {
                    taskControl.awerenessTrain = true;
                }
                else
                {
                    taskControl.awerenessTrain = false;
                }
                if (rblTechPerson.SelectedIndex == 0)
                {
                    taskControl.techPerson = true;
                }
                else
                {
                    taskControl.techPerson = false;
                }
                if (rblPrivacyBreach.SelectedIndex == 0)
                {
                    taskControl.privacyBreach = true;
                }
                else
                {
                    taskControl.privacyBreach = false;
                }
                if (rblGmail.SelectedIndex == 0)
                {
                    taskControl.gmail = true;
                }
                else
                {
                    taskControl.gmail = false;
                }
                if (rblLockedCab.SelectedIndex == 0)
                {
                    taskControl.lockedCab = true;
                }
                else
                {
                    taskControl.lockedCab = false;
                }
                if (rblPaperRet.SelectedIndex == 0)
                {
                    taskControl.paperRetention = true;
                }
                else
                {
                    taskControl.paperRetention = false;
                }
                if (rblShredDoc.SelectedIndex == 0)
                {
                    taskControl.shredDoc = true;
                }
                else
                {
                    taskControl.shredDoc = false;
                }
                if (rblITEncrypted.SelectedIndex == 0)
                {
                    taskControl.itNetworkEncrypted = true;
                }
                else
                {
                    taskControl.itNetworkEncrypted = false;
                }
                if (rblITNetwork.SelectedIndex == 0)
                {
                    taskControl.itNetworkAccesible = true;
                }
                else
                {
                    taskControl.itNetworkAccesible = false;
                }
                if (rblElecRecOnline.SelectedIndex == 0)
                {
                    taskControl.elecRecOnline = true;
                }
                else
                {
                    taskControl.elecRecOnline = false;
                }
                if (rblElecRecWebBase.SelectedIndex == 0)
                {
                    taskControl.elecRecWeb = true;
                }
                else
                {
                    taskControl.elecRecWeb = false;
                }
                
                if (txtInsuranceCarrier.Text != "" && txtEffectiveDates.Text != "" && ddlLimitsPolicyInfo.SelectedItem.Text != "" && txtPolicyNumberInfo.Text != "")
                {
                    Cyber.InsertInsuranceHistory(taskControl.UserID, taskControl.TaskControlID, txtInsuranceCarrier.Text.ToString().Trim(), txtEffectiveDates.Text.ToString().Trim(), ddlLimitsPolicyInfo.SelectedItem.Text.ToString().Trim(), txtPolicyNumberInfo.Text.ToString().Trim());
                    //this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Cannot save an empty comment.");
                    //this.litPopUp.Visible = true;
                    FillDataGridInsurance();
                }
                else
                {



                }
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
                if (txtNumberOfEmployees.Text == "")
                {
                    taskControl.NumberOfEmployees = "";
                }
                else
                {
                    taskControl.NumberOfEmployees = txtNumberOfEmployees.Text.ToString();
                }
                Session["TaskControl"] = taskControl;

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void EnableControls()
        {
            EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
            Login.Login cp = HttpContext.Current.User as Login.Login;
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

            bool visible = false;
            bool enabled = true;

            btnAddNew.Visible = visible;
            btnCancellation.Visible = visible;
            btnComissions.Visible = visible;
            btnConvert.Visible = visible;
            btnConvertPrimary.Visible = visible;
           // btnConvert.Visible = visible;
            btnDelete.Visible = visible;
            btnEdit.Visible = visible;
            btnEnablePrint.Visible = visible;
            btnEndor.Visible = visible;
            BtnExit.Visible = visible;
            btnFinancialCanc.Visible = visible;
            btnHistory.Visible = visible;
            btnPayments.Visible = visible;
            btnPolicyCert.Visible = visible;
            btnPrint.Visible = visible;
            btnPrintCertificate.Visible = visible;
            btnReinstatement.Visible = visible;
            btnRenew.Visible = visible;
            btnTailQuote.Visible = visible;

            lblPolicyInfo.Visible = visible;
            txtInsuranceCarrier.Visible = visible;
            txtEffectiveDates.Visible = visible;
            ddlLimitsPolicyInfo.Visible = visible;
            txtPolicyNumberInfo.Visible = visible;
            dtCyberPolicyInfo.Visible = visible;
            lblInsuranceCarrier.Visible = visible;
            lblPolicyEfDates.Visible = visible;
            lblPolicyLimits.Visible = visible;
            lblPolicyNumberInfo.Visible = visible;

            if (taskControl.IsPolicy)
                visible = true;

            TxtPolicyNo.Visible = visible;
            lblPolicyNo.Visible = visible;
            lblPolicyType.Visible = visible;
            TxtPolicyType.Visible = visible;
            TxtSufijo.Visible = visible;
            lblAnniversary.Visible = visible;
            TxtAnniversary.Visible = visible;
            lblSufijo.Visible = visible;
            //prueba Gap
            txtGapBegDate.Enabled = true;
            txtGapBegDate2.Enabled = true;
            txtGapBegDate3.Enabled = true;
            txtGapEndDate.Enabled = true;
            txtGapEndDate2.Enabled = true;
            txtGapEndDate3.Enabled = true;
            txtNumberOfEmployees.Enabled = true;
            rblAwerenessTrain.Enabled = true;
            rblClaim.Enabled = true;
            rblElecRecOnline.Enabled = true;
            rblElecRecWebBase.Enabled = true;
            rblGmail.Enabled = true;
            rblITEncrypted.Enabled = true;
            rblITNetwork.Enabled = true;
            rblLockedCab.Enabled = true;
            rblPaperRet.Enabled = true;
            rblPrivacyBreach.Enabled = true;
            rblPrivacyOfficer.Enabled = true;
            rblPrivacyPractice.Enabled = true;
            rblShredDoc.Enabled = true;
            rblTechPerson.Enabled = true;

            lblTerm.Visible = visible;
            //lblRetro.Visible = visible;
            lblEntryDate.Visible = visible;
            lblEffDate.Visible = visible;

            lblExpDate.Visible = visible;

            Label77.Visible = visible;
            rblClaim.Visible = visible;
            lblClaimNo.Visible = visible;
            txtClaimNumber.Visible = visible;

            //Cyber Liability Insurance Info
            lblPolicyInfo.Visible = visible;
            txtInsuranceCarrier.Visible = visible;
            txtEffectiveDates.Visible = visible;
            ddlLimitsPolicyInfo.Visible = visible;
            txtPolicyNumberInfo.Visible = visible;
            dtCyberPolicyInfo.Visible = visible;
            lblInsuranceCarrier.Visible = visible;
            lblPolicyEfDates.Visible = visible;
            lblPolicyLimits.Visible = visible;
            lblPolicyNumberInfo.Visible = visible;

            pnlHistory.Visible = visible;

            if (taskControl.CancellationDate != String.Empty)
                lblExpDate.Text = "Canc. Date";

            lblOthAgent.Visible = visible;
            lblOrigin.Visible = visible;
            lblInsComp.Visible = visible;
            //lblGroup.Visible = visible;
            lblCorp.Visible = visible;
            lblFinancial.Visible = visible;
            lblComments.Visible = visible;
            TxtTerm.Visible = visible;
            //TxtRetroactiveDate.Visible = visible;
            txtEntryDate.Visible = visible;
            txtEffDt.Visible = visible;
            txtExpDt.Visible = visible;
            ddlAgent2.Visible = visible;
            ddlOriginatedAt.Visible = visible;
            ddlInsuranceCompany.Visible = visible;
            //ddlGroup.Visible = visible;
            ddlCorparation.Visible = visible;
            ddlFinancial.Visible = visible;
            TxtComments.Visible = visible;


            //if (taskControl.Anniversary == "01" && taskControl.IsPolicy && taskControl.Mode == 1)
            //{
            //    lblPriorAct.Visible = visible;
            //    ddlPriorAct.Visible = visible;


            //}
            //else
            //{
            //}

            // btn Control visible true
            visible = true;
            BtnSave.Visible = visible;
            cmdCancel.Visible = visible;
            BtnExit.Visible = visible;
            btnCalculatePremium.Visible = visible;

            // disable control Enabled=true
            TxtFirstName.Enabled = enabled;
            txtHomePhone.Enabled = enabled;
            //TxtInitial.Enabled = enabled;
            //txtLastname1.Enabled = enabled;
            //txtLastname2.Enabled = enabled;
            //txtLicense.Enabled = enabled;
            TxtPolicyNo.Enabled = enabled;
            //txtLicense.Enabled = enabled;
            TxtPolicyType.Enabled = enabled;
            TxtPremium.Enabled = enabled;
            txtPriCarierName1.Enabled = enabled;
            txtPriClaims1.Enabled = enabled;
            txtPriPolEffecDate1.Enabled = enabled;
            txtPriPolLimits1.Enabled = enabled;
            TxtRetroactiveDate.Enabled = enabled;
            ///////////
            ddlEnity.Enabled = enabled;
            txtAlternateEmail.Enabled = enabled;
            txtOtherEnity.Enabled = enabled;
            ddlPracticeHistory.Enabled = enabled;
            txtNumOfPatients.Enabled = enabled;
            ddlNumOfPhysicians.Enabled = enabled;
            txtInsuranceCarrier.Enabled = enabled;
            txtEffectiveDates.Enabled = enabled;
            ddlLimitsPolicyInfo.Enabled = enabled;
            txtPolicyNumberInfo.Enabled = enabled;
            //////
            TxtState.Enabled = enabled;
            TxtSufijo.Enabled = enabled;
            TxtTerm.Enabled = enabled;
            TxtTotalPremium.Enabled = enabled;
            TxtUserPremium.Enabled = enabled;
            txtWorkPhone.Enabled = enabled;
            TxtZip.Enabled = enabled;
            TxtAddrs1.Enabled = enabled;
            TxtAddrs2.Enabled = enabled;
            TxtAnniversary.Enabled = enabled;
            TxtCancAmount.Enabled = enabled;
            TxtCellular.Enabled = enabled;
            TxtCertificate.Enabled = enabled;
            TxtCharge.Enabled = enabled;
            TxtCity.Enabled = enabled;
            txtClaimNumber.Enabled = enabled;
            TxtComments.Enabled = enabled;
            TxtCustomerNo.Enabled = enabled;
            txtDatePrepared.Enabled = enabled;
            txtEffDt.Enabled = enabled;

            if (cp.IsInRole("ADMINISTRATOR"))
            {
                txtExpDt.Enabled = true;
            }
            else
            {
                txtExpDt.Enabled = false;
            }


            txtEmail.Enabled = enabled;
            txtEndoComments.Enabled = enabled;
            txtEndoEffDate.Enabled = enabled;
            txtEndoPremium.Enabled = enabled;
            txtEndorsementID.Enabled = enabled;
            txtEndorsementNo.Enabled = enabled;
            txtEntryDate.Enabled = enabled;
            txtExpDt.Enabled = enabled;
            //txtEstGrossReceipt.Enabled = enabled;

            ddlAgency.Enabled = enabled;
            ddlCity.Enabled = enabled;
            ddlAgent.Enabled = enabled;
            ddlAgent2.Enabled = enabled;
            ddlAvailableAgent.Enabled = enabled;
            ddlCorparation.Enabled = enabled;
            ddlEndoType.Enabled = enabled;
            ddlFinancial.Enabled = enabled;
            ddlGroup.Enabled = enabled;
            ddlInsuranceCompany.Enabled = enabled;
            ddlMainSpecialty.Enabled = enabled;
            ddlOriginatedAt.Enabled = enabled;
            //ddlOtherSpecialtyA.Enabled = enabled;
            ddlOtherSpecialtyB.Enabled = enabled;
            ddlCyberLimits.Enabled = true;
            ddlSelectedAgent.Enabled = enabled;
            ddlPriorAct.Enabled = enabled;

            rblClaim.Enabled = enabled;

            txtCode.Enabled = enabled;
            txtCoverage.Enabled = enabled;


            if (!taskControl.isEndorsement)
            {
                pnlEndorsement.Visible = false;
                lblEndorsementHistory.Visible = true;
                lblEndorsement.Visible = false;
                dtEndorsement.Visible = true;
            }

            if (taskControl.IsPolicy == true)
                DisableControlQuotes(true);
            else
                DisableControlQuotes(false);


            if (!cp.IsInRole("ADMINISTRATOR") && !cp.IsInRole("PRMDIC-USER"))
            {
                btnEnablePrint.Visible = false;

            }
            else
            {
                btnEnablePrint.Visible = true;

            }



        }
        private void DisableQuestions()
        {
            bool enabled = false;
            rblPrivacyOfficer.Enabled = enabled;
            rblPrivacyPractice.Enabled = enabled;
            rblAwerenessTrain.Enabled = enabled;
            rblTechPerson.Enabled = enabled;
            rblPrivacyBreach.Enabled = enabled;
            rblGmail.Enabled = enabled;
            rblLockedCab.Enabled = enabled;
            rblPaperRet.Enabled = enabled;
            rblShredDoc.Enabled = enabled;
            rblITEncrypted.Enabled = enabled;
            rblITNetwork.Enabled = enabled;
            rblElecRecOnline.Enabled = enabled;
            rblElecRecWebBase.Enabled = enabled;
            txtTotalCredit.Enabled = enabled;
            txtTotalCreditDebit.Enabled = enabled;
            txtTotalDebit.Enabled = enabled;
        }

        private void EnableQuestions()
        {
            //bool enabled = true;
            //rblPrivacyOfficer.Enabled = enabled;
            //rblPrivacyPractice.Enabled = enabled;
            //rblAwerenessTrain.Enabled = enabled;
            //rblTechPerson.Enabled = enabled;
            //rblPrivacyBreach.Enabled = enabled;
            //rblGmail.Enabled = enabled;
            //rblLockedCab.Enabled = enabled;
            //rblPaperRet.Enabled = enabled;
            //rblShredDoc.Enabled = enabled;
            //rblITEncrypted.Enabled = enabled;
            //rblITNetwork.Enabled = enabled;
            //rblElecRecOnline.Enabled = enabled;
            //rblElecRecWebBase.Enabled = enabled;
            //txtTotalCredit.Enabled = enabled;
            //txtTotalCreditDebit.Enabled = enabled;
            //txtTotalDebit.Enabled = enabled;

            //txtGapBegDate.Enabled = true;
            //txtGapBegDate2.Enabled = true;
            //txtGapBegDate3.Enabled = true;
            //txtGapEndDate.Enabled = true;
            //txtGapEndDate2.Enabled = true;
            //txtGapEndDate3.Enabled = true;
            //txtNumberOfEmployees.Enabled = true;
            rblAwerenessTrain.Enabled = true;
            rblClaim.Enabled = true;
            rblElecRecOnline.Enabled = true;
            rblElecRecWebBase.Enabled = true;
            rblGmail.Enabled = true;
            rblITEncrypted.Enabled = true;
            rblITNetwork.Enabled = true;
            rblLockedCab.Enabled = true;
            rblPaperRet.Enabled = true;
            rblPrivacyBreach.Enabled = true;
            rblPrivacyOfficer.Enabled = true;
            rblPrivacyPractice.Enabled = true;
            rblShredDoc.Enabled = true;
            rblTechPerson.Enabled = true;
        }

        private void VisibleQuestions() // Alexis 
        {
            bool enabled = false;
            //lblGeneralInfo.Visible = enabled;
            //lblHippa.Visible = enabled;
            //lblPrivacyOfficer0.Visible = enabled;
            //lblPrivacyOfficer.Visible = enabled;
            //rblPrivacyOfficer.Visible = enabled;
            //Label79.Visible = enabled;
            //lblPrivacyPractice.Visible = enabled;
            //rblPrivacyPractice.Visible = enabled;
            //Label80.Visible = enabled;
            //lblAwerenessTrain.Visible = enabled;
            //rblAwerenessTrain.Visible = enabled;
            //Label81.Visible = enabled;
            //lblTechPerson.Visible = enabled;
            //rblTechPerson.Visible = enabled;
            //Label82.Visible = enabled;
            //lblPrivacyBreach.Visible = enabled;
            //rblPrivacyBreach.Visible = enabled;
            //Label83.Visible = enabled;
            //lblGmail.Visible = enabled;
            //rblGmail.Visible = enabled;
            //Label84.Visible = enabled;
            //lblRegardRec.Visible = enabled;
            //lblPaperRec.Visible = enabled;
            //lblLockedCab.Visible = enabled;
            //rblLockedCab.Visible = enabled;
            //Label85.Visible = enabled;
            //lblPaperRet.Visible = enabled;
            //rblPaperRet.Visible = enabled;
            //Label86.Visible = enabled;
            //lblShredDoc.Visible = enabled;
            //rblShredDoc.Visible = enabled;
            //Label87.Visible = enabled;
            //lblElecRec.Visible = enabled;
            //lblITEncrypted.Visible = enabled;
            //rblITEncrypted.Visible = enabled;
            //Label88.Visible = enabled;
            //lblITNetwork.Visible = enabled;
            //rblITNetwork.Visible = enabled;
            //Label89.Visible = enabled;
            //lblElecRecOnline.Visible = enabled;
            //rblElecRecOnline.Visible = enabled;
            //lblElecRecWebBase.Visible = enabled;
            //rblElecRecWebBase.Visible = enabled;
            //txtTotalCredit.Visible = enabled;
            //txtTotalDebit.Visible = enabled;
            //lblCreditDebitPercent.Visible = enabled;
            //lblCreditDebitTotal.Visible = enabled;
            //txtTotalCreditDebit.Visible = enabled;

            pnlGeneralInfo.Visible = enabled;


        }
        private void DisableControls()
        {
            EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
            Login.Login cp = HttpContext.Current.User as Login.Login;
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

            bool visible = true;
            bool enabled = false;

            if (taskControl.IsPolicy)
            {
                btnAddNew.Visible = visible;
                btnCancellation.Visible = visible;
                btnComissions.Visible = visible;
                btnDelete.Visible = visible;
                btnEdit.Visible = visible;
                btnEndor.Visible = visible;
                BtnExit.Visible = visible;
                btnFinancialCanc.Visible = visible;
                btnHistory.Visible = visible;
                btnPayments.Visible = visible;
                btnPolicyCert.Visible = visible;
                btnPrint.Visible = visible;
                btnPrintCertificate.Visible = visible;
                btnReinstatement.Visible = visible;
                btnRenew.Visible = visible;
                btnTailQuote.Visible = visible;
                cmdCancel.Visible = visible;
                //lblCertificate.Visible = visible;
                //TxtCertificate.Visible = visible;
                TxtPolicyNo.Visible = visible;
                lblPolicyNo.Visible = visible;
                lblPolicyType.Visible = visible;
                TxtPolicyType.Visible = visible;
                TxtSufijo.Visible = visible;
                lblAnniversary.Visible = visible;
                TxtAnniversary.Visible = visible;
                lblSufijo.Visible = visible;

                lblTerm.Visible = visible;
                //lblRetro.Visible = visible;
                lblEntryDate.Visible = visible;
                lblEffDate.Visible = visible;
                lblExpDate.Visible = visible;
                //prueba Gap
                txtGapBegDate.Visible = visible;
                txtGapBegDate2.Visible = visible;
                txtGapBegDate3.Visible = visible;
                txtGapEndDate.Visible = visible;
                txtGapEndDate2.Visible = visible;
                txtGapEndDate3.Visible = visible;
                txtNumberOfEmployees.Visible = visible;
                

                if (taskControl.CancellationDate != String.Empty)
                {
                    lblExpDate.Text = "Canc. Date";
                    btnRenew.Visible = false;
                }
                else
                {
                    lblExpDate.Text = "Exp. Date";
                    btnRenew.Visible = true;
                }

                lblOthAgent.Visible = visible;
                lblOrigin.Visible = visible;
                lblInsComp.Visible = visible;
                lblGroup.Visible = visible;
                lblCorp.Visible = visible;
                lblComments.Visible = visible;
                TxtTerm.Visible = visible;
                //TxtRetroactiveDate.Visible = visible;
                txtEntryDate.Visible = visible;
                txtEffDt.Visible = visible;
                txtExpDt.Visible = visible;
                ddlAgent2.Visible = visible;
                ddlOriginatedAt.Visible = visible;
                ddlInsuranceCompany.Visible = visible;
                ddlGroup.Visible = visible;
                ddlCorparation.Visible = visible;
                ddlFinancial.Visible = visible;
                TxtComments.Visible = visible;

                pnlHistory.Visible = visible;

                visible = false;
                //btnConvert.Visible = visible;
                btnConvertPrimary.Visible = visible;
                //btnConvert.Visible = visible;
                btnEnablePrint.Visible = visible;
                //btnTailQuote.Visible = visible;
                btnCalculatePremium.Visible = visible;
                BtnSave.Visible = visible;

                if (!taskControl.isEndorsement)
                    pnlEndorsement.Visible = visible;

                //lblPriorAct.Visible = visible;
                //ddlPriorAct.Visible = visible;

            }
            else
            {
                btnPrint.Visible = visible;
                btnConvertPrimary.Visible = visible;
                //btnConvert.Visible = visible;
                btnEdit.Visible = visible;
                BtnExit.Visible = visible;
                cmdCancel.Visible = visible;
                btnAddNew.Visible = visible;

                visible = false;
                btnAddNew.Visible = visible;
                BtnSave.Visible = visible;
                btnCancellation.Visible = visible;
                btnComissions.Visible = visible;

                btnDelete.Visible = visible;
                btnEnablePrint.Visible = visible;
                btnEndor.Visible = visible;
                btnFinancialCanc.Visible = visible;
                btnHistory.Visible = visible;
                btnPayments.Visible = visible;
                btnPolicyCert.Visible = visible;
                btnPrintCertificate.Visible = visible;
                btnReinstatement.Visible = visible;
                btnRenew.Visible = visible;
                btnTailQuote.Visible = visible;
                btnCalculatePremium.Visible = visible;
                cmdCancel.Visible = visible;
                lblHomePhone.Visible = visible;
                txtHomePhone.Visible = visible;
                txtLicense.Visible = visible;
                Label51.Visible = visible;
                rblClaim.Visible = visible;
                lblClaimNo.Visible = visible;
                Label67.Visible = visible;
                txtClaimNumber.Visible = visible;
                lblFinancial.Visible = visible;
                ddlFinancial.Visible = visible;
                TxtPolicyNo.Visible = visible;
                lblPolicyNo.Visible = visible;
                lblPolicyType.Visible = visible;
                TxtPolicyType.Visible = visible;
                TxtSufijo.Visible = visible;
                lblAnniversary.Visible = visible;
                TxtAnniversary.Visible = visible;
                lblSufijo.Visible = visible;
                //lblCertificate.Visible = visible;
                //TxtCertificate.Visible = visible;

                lblTerm.Visible = visible;
                //lblRetro.Visible = visible;
                lblEntryDate.Visible = visible;
                lblEffDate.Visible = visible;
                lblExpDate.Visible = visible;
                lblOthAgent.Visible = visible;
                lblOrigin.Visible = visible;
                lblInsComp.Visible = visible;
                lblGroup.Visible = visible;
                lblCorp.Visible = visible;
                lblComments.Visible = visible;
                TxtTerm.Visible = visible;
                //TxtRetroactiveDate.Visible = visible;
                txtEntryDate.Visible = visible;
                txtEffDt.Visible = visible;
                txtExpDt.Visible = visible;
                ddlAgent2.Visible = visible;
                ddlOriginatedAt.Visible = visible;
                ddlInsuranceCompany.Visible = visible;
                ddlGroup.Visible = visible;
                ddlCorparation.Visible = visible;
                TxtComments.Visible = visible;

                Label77.Visible = visible;
                rblClaim.Visible = visible;
                lblClaimNo.Visible = visible;
                txtClaimNumber.Visible = visible;

                pnlHistory.Visible = visible;
            }

            // disable control Enabled=false
            txtGapBegDate.Enabled = enabled;
            txtGapEndDate.Enabled = enabled;
            txtGapBegDate2.Enabled = enabled;
            txtGapEndDate2.Enabled = enabled;
            txtGapBegDate3.Enabled = enabled;
            txtGapEndDate3.Enabled = enabled;
            txtNumberOfEmployees.Enabled = enabled;
            rblAwerenessTrain.Enabled = enabled;
            rblClaim.Enabled = enabled;
            rblElecRecOnline.Enabled = enabled;
            rblElecRecWebBase.Enabled = enabled;
            rblGmail.Enabled = enabled;
            rblITEncrypted.Enabled = enabled;
            rblITNetwork.Enabled = enabled;
            rblLockedCab.Enabled = enabled;
            rblPaperRet.Enabled = enabled;
            rblPrivacyBreach.Enabled = enabled;
            rblPrivacyOfficer.Enabled = enabled;
            rblPrivacyPractice.Enabled = enabled;
            rblShredDoc.Enabled = enabled;
            rblTechPerson.Enabled = enabled;

            txtAlternateEmail.Enabled = enabled;
            ddlEnity.Enabled = enabled;
            txtOtherEnity.Enabled = enabled;
            ddlPracticeHistory.Enabled = enabled;
            txtNumOfPatients.Enabled = enabled;
            ddlNumOfPhysicians.Enabled = enabled;
            txtInsuranceCarrier.Enabled = enabled;
            txtEffectiveDates.Enabled = enabled;
            ddlLimitsPolicyInfo.Enabled = enabled;
            txtPolicyNumberInfo.Enabled = enabled;

            rblPrivacyOfficer.Enabled = enabled;
            rblPrivacyPractice.Enabled = enabled;
            rblAwerenessTrain.Enabled = enabled;
            rblTechPerson.Enabled = enabled;
            rblPrivacyBreach.Enabled = enabled;
            rblGmail.Enabled = enabled;
            rblLockedCab.Enabled = enabled;
            rblPaperRet.Enabled = enabled;
            rblShredDoc.Enabled = enabled;
            rblITEncrypted.Enabled = enabled;
            rblITNetwork.Enabled = enabled;
            rblElecRecOnline.Enabled = enabled;
            rblElecRecWebBase.Enabled = enabled;
            txtTotalCredit.Enabled = enabled;
            txtTotalDebit.Enabled = enabled;
            txtTotalCreditDebit.Enabled = enabled;

            TxtFirstName.Enabled = enabled;
            txtHomePhone.Enabled = enabled;
            //TxtInitial.Enabled = enabled;
            //txtLastname1.Enabled = enabled;
            //txtLastname2.Enabled = enabled;
            txtLicense.Enabled = enabled;
            TxtPolicyNo.Enabled = enabled;
            txtLicense.Enabled = enabled;
            TxtPolicyType.Enabled = enabled;
            TxtPremium.Enabled = enabled;
            txtPriCarierName1.Enabled = enabled;
            txtPriClaims1.Enabled = enabled;
            txtPriPolEffecDate1.Enabled = enabled;
            txtPriPolLimits1.Enabled = enabled;
            TxtRetroactiveDate.Enabled = enabled;
            TxtState.Enabled = enabled;
            TxtSufijo.Enabled = enabled;
            TxtTerm.Enabled = enabled;
            TxtTotalPremium.Enabled = enabled;
            TxtUserPremium.Enabled = enabled;
            txtWorkPhone.Enabled = enabled;
            TxtZip.Enabled = enabled;
            TxtAddrs1.Enabled = enabled;
            TxtAddrs2.Enabled = enabled;
            TxtAnniversary.Enabled = enabled;
            TxtCancAmount.Enabled = enabled;
            TxtCellular.Enabled = enabled;
            TxtCertificate.Enabled = enabled;
            TxtCharge.Enabled = enabled;
            TxtCity.Enabled = enabled;
            txtClaimNumber.Enabled = enabled;
            TxtComments.Enabled = enabled;
            TxtCustomerNo.Enabled = enabled;
            txtDatePrepared.Enabled = enabled;
            txtEffDt.Enabled = enabled;
            txtEmail.Enabled = enabled;
            txtEndoComments.Enabled = enabled;
            txtEndoEffDate.Enabled = enabled;
            txtEndoPremium.Enabled = enabled;
            txtEndorsementID.Enabled = enabled;
            txtEndorsementNo.Enabled = enabled;
            txtEntryDate.Enabled = enabled;
            txtExpDt.Enabled = enabled;
            //txtEstGrossReceipt.Enabled = enabled;

            ddlAgency.Enabled = enabled;
            ddlCity.Enabled = enabled;
            ddlAgent.Enabled = enabled;
            ddlAgent2.Enabled = enabled;
            ddlAvailableAgent.Enabled = enabled;
            ddlCorparation.Enabled = enabled;
            ddlEndoType.Enabled = enabled;
            ddlFinancial.Enabled = enabled;
            ddlGroup.Enabled = enabled;
            ddlInsuranceCompany.Enabled = enabled;
            ddlMainSpecialty.Enabled = enabled;
            ddlOriginatedAt.Enabled = enabled;
            //ddlOtherSpecialtyA.Enabled = enabled;
            ddlOtherSpecialtyB.Enabled = enabled;
            ddlCyberLimits.Enabled = enabled;
            ddlSelectedAgent.Enabled = enabled;
            ddlPriorAct.Enabled = enabled;

            txtCode.Enabled = enabled;
            txtCoverage.Enabled = enabled;

            rblClaim.Enabled = enabled;

            if (taskControl.IsPolicy)
            {
                VerifyAccess();
            }


            if (!cp.IsInRole("ADMINISTRATOR") && !cp.IsInRole("SUBSCRIPTION"))
            {
                btnEnablePrint.Visible = false;
            }
            else
            {
                btnEnablePrint.Visible = true;
            }


            if (!taskControl.isEndorsement)
            {
                pnlEndorsement.Visible = false;
                lblEndorsementHistory.Visible = true;
                dtEndorsement.Visible = true;
            }
            

            //if (taskControl.isEndorsement)
            //    ShowEndorsementSection(true);
            //else
            //    ShowEndorsementSection(false);
           

            DisableControlQuotes(false);

        }

        #region Verify Access
        private void VerifyAccess()
        {
            EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
            Login.Login cp = HttpContext.Current.User as Login.Login;

            if (userID == 198) //History Override button for Blanca Hernandez
            {
                this.btnHistory.Visible = true;
            }

            if (userID == 270) //Override para Hadasha Alamo. 
            {
                btnEnablePrint.Visible = true;
            }

            if (cp.IsInRole("BTNCOMMISSIONSNOVISIBLE"))
            {
                this.btnComissions.Visible = false;
            }

            else
            {
                this.btnPayments.Visible = true;
                this.btnComissions.Visible = true;
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
                this.lblOthAgent.Visible = false;
            }
            else
            {
                this.ddlAgent2.Visible = true;
                this.lblOthAgent.Visible = true;
            }

            if (cp.IsInRole("ADMINISTRATOR"))
            {
                prmdicAdmin = true;
                btnTailQuote.Visible = true;
            }
            else
            {
                btnTailQuote.Visible = false;
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
                dtEndorsement.Columns[9].Visible = true;
                dtEndorsement.Columns[10].Visible = false;
            }
            else if (!cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnTailQuote.Visible = false;
                this.btnEndor.Visible = false;
                dtEndorsement.Columns[9].Visible = false;
                dtEndorsement.Columns[10].Visible = false;
                dtCyberPolicyInfo.Columns[7].Visible = false;
            }
            else
            {
                this.btnTailQuote.Visible = true;
                this.btnEndor.Visible = true;
                dtEndorsement.Columns[9].Visible = true;
                dtEndorsement.Columns[10].Visible = true;
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

            if (cp.IsInRole("DISABLEBOXPOWERAGENT") && cp.IsInRole("POWERAGENT"))
            {
                this.TxtComments.Visible = false;
                this.lblComments.Visible = false;
                this.rblClaim.Visible = false;
                this.Label77.Visible = false;
                DtSearchPayments.Columns[9].Visible = false;
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

            if (cp.IsInRole("ACCOUNTING") && taskControl.CancellationDate != "")
            {
                btnPrint.Visible = true;
            }
        }
        #endregion

        private void HideControl()
        {
            bool visible = false;
            lblCarrier.Visible = visible;
            txtPriCarierName1.Visible = visible;
            Label65.Visible = visible;
            txtPriPolEffecDate1.Visible = visible;
            Label66.Visible = visible;
            txtPriPolLimits1.Visible = visible;
            Label67.Visible = visible;
            txtPriCarierName1.Visible = visible;
            txtPriClaims1.Visible = visible;
            ddlSelectedAgent.Visible = visible;
            //LblStatus.Visible = visible;
            chkPaymentGA.Visible = visible;
            //ddlOtherSpecialtyA.Visible = visible;
            ddlOtherSpecialtyB.Visible = visible;
            lblOtherSpecialty.Visible = visible;
            //lblOtherSpecialty0.Visible = visible;
            //Label60.Visible = visible;
            //TxtCharge.Visible = visible;
            //lblPremium0.Visible = visible;
            //TxtPremium.Visible = visible;
            //TxtCancAmount.Visible = visible;
            //lblPremum.Visible = visible;
            btnCalcCharge.Visible = visible;
            ChkAutoAssignPolicy.Visible = visible;
            //btnTailQuote.Visible = visible;
            //btnPrintCertificate.Visible = visible;
            btnPolicyCert.Visible = visible;
        }

        private void ShowEndorsementSection(bool visible)
        {
            pnlEndorsement.Visible = visible;
            lblEndorsement.Visible = visible;
            lblEndorsementNo.Visible = visible;
            txtEndorsementNo.Visible = visible;
            lblDatePrepared.Visible = visible;
            txtDatePrepared.Visible = visible;
            lblEndoEffDate.Visible = visible;
            txtEndoEffDate.Visible = visible;
            lblEndoPremium.Visible = visible;
            txtEndoPremium.Visible = visible;
            lblEndoType.Visible = visible;
            ddlEndoType.Visible = visible;
            btnHideEndoPanel.Visible = visible;
            lblEndoComments.Visible = visible;
            txtEndoComments.Visible = visible;
            lblEndorsementHistory.Visible = visible;
        }

        private void DisableControlQuotes(bool isPolicy)
        {
            TxtPolicyNo.Enabled = isPolicy;
            TxtPolicyType.Enabled = isPolicy;
            TxtCustomerNo.Enabled = isPolicy;
            TxtCertificate.Enabled = isPolicy;
            TxtSufijo.Enabled = isPolicy;
            TxtAnniversary.Enabled = isPolicy;

            ChkAutoAssignPolicy.Enabled = isPolicy;
            ChkAutoAssignPolicy.Checked = isPolicy;

            lblHomePhone.Visible = false;
            txtHomePhone.Visible = false;
        }

        private bool ValidateField()
        {
            try
            {
                EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
                bool process = true;


                EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
                int userID = 0; //ard
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                ArrayList errorMessage = new ArrayList();

                if (TxtFirstName.Text.Trim() == "")
                    errorMessage.Add("The Name is missing or wrong.");
                if (TxtAddrs1.Text.Trim() == "")
                    errorMessage.Add("The Address 1 is missing or wrong.");
                if (TxtCity.Text.Trim() == "")
                    errorMessage.Add("The City is missing or wrong.");
                if (TxtState.Text.Trim() == "")
                    errorMessage.Add("The state is missing or wrong.");
                if (TxtZip.Text.Trim() == "")
                    errorMessage.Add("The Zip Code is missing or wrong.");
                if (TxtTerm.Text.Trim() == "")
                    errorMessage.Add("The Term is missing or wrong.");
                //if (TxtRetroactiveDate.Text.Trim() == "")
                //    errorMessage.Add("The Retro Date is missing or wrong.");
                if (txtEffDt.Text.Trim() == "")
                    errorMessage.Add("The Effective Date is missing or wrong.");
                if (txtExpDt.Text.Trim() == "")
                    errorMessage.Add("The Expiration Date is missing or wrong.");
                if (txtEntryDate.Text.Trim() == "")
                    errorMessage.Add("The Entry Date is missing or wrong.");
                if (ddlEnity.SelectedItem.Value == "")
                    errorMessage.Add("The Enity is missing or wrong.");
                if (ddlPracticeHistory.SelectedItem.Value == "")
                    errorMessage.Add("The Practice History is missing or wrong.");
                if (ddlNumOfPhysicians.SelectedItem.Value == "")
                    errorMessage.Add("The Number of Physicians is missing or worng.");
                if (ddlCyberLimits.SelectedItem.Value == "" && ddlCyberLimits.SelectedItem.Value == null)
                    errorMessage.Add("The Limit is missing or wrong.");
                if (ddlAgent.SelectedItem.Value.Trim() == "")
                    errorMessage.Add("Please choose a agent.");
                if (ddlAgent.SelectedItem.Value.Trim() == "000")
                    errorMessage.Add("Please choose a agent.");
                double _temp = 0;

                //if (!(double.TryParse(txtEstGrossReceipt.Text.Trim(), out _temp)))
                //    errorMessage.Add("The Estiated Gross Receipts is missing or wrong");
                //else
                //{ if (_temp <= 0) errorMessage.Add("The Estimated Gross Receipts could no be less than 0."); }

                if (!(double.TryParse(TxtTotalPremium.Text.Trim(), out _temp)))
                    errorMessage.Add("The Total Premium is missing or wrong");
                else
                { if (_temp <= 0) errorMessage.Add("The Total Premium could no be less than 0."); }

                if (taskControl.IsPolicy)
                {
                    if (TxtPolicyNo.Text.Trim() == "")
                        errorMessage.Add("The Policy No. is missing or wrong");

                    if (taskControl.Anniversary == "01" && taskControl.Mode != 2) //Verify is policy number exist with a new policy
                    {
                        DataTable dt = new DataTable();
                        dt = EPolicy.TaskControl.Cyber.VerifiPolicyNo(TxtPolicyNo.Text.ToString());

                        if (dt.Rows.Count > 0)
                        {
                            errorMessage.Add("The Policy No. already exist");
                        }
                    }

                    if ((rblClaim.SelectedIndex != -1))
                    {
                        if (rblClaim.SelectedItem.Value.Trim() == "0")
                        {
                            if (txtClaimNumber.Text.Trim() == "")
                                errorMessage.Add("The Claim No is missing or wrong");
                        }
                    }
                }


                if (taskControl.IsPolicy) //ard
                {
                    DtTaskPolicy = TaskControl.Policy.GetPolicies(taskControl.PolicyClassID, TxtPolicyType.Text.Trim(),
                        TxtPolicyNo.Text.Trim(), TxtCertificate.Text.Trim(), TxtSufijo.Text.Trim(),
                        "", "", userID); //ARD

                    if (DtTaskPolicy.Rows.Count > 0 && !taskControl.isEndorsement && taskControl.Mode == 1)
                        errorMessage.Add("Policy Number already exists." + "\r\n"); //ARD
                }


                if (errorMessage.Count > 0)
                {
                    process = false;
                    string message = "";
                    for (int i = 0; i < errorMessage.Count; i++)
                    {
                        message += errorMessage[i] + "\\n";
                    }
                    throw new Exception(message);
                }
                return process;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CalculateCharge()
        {
            //EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
            DataTable dt = new DataTable();
            int creditdebit = GetCalculateQuestions();

            txtTotalCreditDebit.Text = creditdebit.ToString();

            dt = EPolicy.TaskControl.Cyber.GetCyberPremium(ddlNumOfPhysicians.SelectedItem.Text.ToString().Trim(), ddlCyberLimits.SelectedItem.Text.ToString().Trim(), int.Parse(ddlPracticeHistory.SelectedItem.Value));

            if (dt.Rows.Count > 0)
            {
                TxtTotalPremium.Text = Math.Round((double.Parse(dt.Rows[0]["Premium"].ToString()) * ((100.0 + creditdebit) / 100.0))).ToString();

            }

            if (Session["TaskControl"] != null)
            {
                TaskControl.Cyber taskControl = (TaskControl.Cyber)Session["TaskControl"];
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

                                //if (decPlaces >= 50)
                                //    rounded = (int)Math.Ceiling(totalpremium * chargePercent);
                                //else
                                //    rounded = (int)Math.Floor(totalpremium * chargePercent);

                                double dec = double.Parse((totalpremium * chargePercent).ToString());
                                if (dec < 1.00)
                                    rounded = 0;
                                else
                                    rounded = (int)Math.Round(dec, 0);


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

                            //if (decPlaces >= 50)
                            //    rounded = (int)Math.Ceiling(totalpremium * chargePercent);
                            //else
                            //    rounded = (int)Math.Floor(totalpremium * chargePercent);

                            double dec = double.Parse((totalpremium * chargePercent).ToString());
                            if (dec < 1.00)
                                rounded = 0;
                            else
                                rounded = (int)Math.Round(dec, 0);


                            TxtCharge.Text = rounded.ToString("###,###.#0").Trim();
                            TxtPremium.Text = totalpremium.ToString("###,###.#0").Trim();
                            TxtTotalPremium.Text = ((totalpremium + rounded) - cancellationAmount).ToString("###,###.#0").Trim();
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

            // double[] Factor = { 0, 1.83, 2.19, 2.48, 3.06 };

            //int valueLimit = 0;

            //if (ddlCyberLimits.SelectedItem.Value.Trim() != null && ddlCyberLimits.SelectedItem.Value.Trim() != "")
            //{
            //    valueLimit = int.Parse(ddlCyberLimits.SelectedItem.Value.Trim());
            //}

            //if (valueLimit > 0)
            //{
            //    double EstGross = 0;
            //    double _premiumTemp = 0;
            //    double TotalPremium1 = 0, TotalPremium2 = 0, TotalPremium3 = 0, TotalPremium4 = 0;

            //    if (double.TryParse(txtEstGrossReceipt.Text.Trim(), out EstGross))
            //    {
            //        TotalPremium1 = ((EstGross / 1000) * Math.Round((Factor[1] * 2.3), 2));
            //        TotalPremium2 = ((EstGross / 1000) * Math.Round((Factor[2] * 2.3), 2));
            //        TotalPremium3 = ((EstGross / 1000) * Math.Round((Factor[3] * 2.3), 2));
            //        TotalPremium4 = ((EstGross / 1000) * Math.Round((Factor[4] * 2.3), 2));
            //    }

            //    if (double.TryParse(txtEstGrossReceipt.Text.Trim(), out EstGross))
            //    {
            //        _premiumTemp = ((EstGross / 1000.0) * Math.Round((Factor[valueLimit] * 2.3), 2));

            //        double _p = 1;

            //        if (TxtRetroactiveDate.Text != "")
            //        {
            //            DateTime zeroTime = new DateTime(1 / 1 / 1);

            //            TimeSpan span = DateTime.Parse(txtEffDt.Text.Trim()) - DateTime.Parse(TxtRetroactiveDate.Text.Trim());

            //            int years = (zeroTime + span).Year - 1;

            //            if (years == 0)
            //            {
            //                _p = 0.60; // = 60%
            //                _premiumTemp = _premiumTemp * _p;
            //            }
            //            else if (years == 1)
            //            {
            //                _p = 0.80; // = 80%
            //                _premiumTemp = _premiumTemp * _p;
            //            }
            //            else if (years == 2)
            //            {
            //                _p = 0.90; // = 90%
            //                _premiumTemp = _premiumTemp * _p;
            //            }
            //            else if (years >= 3)
            //            {
            //                _p = 1; // = 100%
            //                _premiumTemp = _premiumTemp * _p;
            //            }
            //        }

            //        _premiumTemp = Math.Round(_premiumTemp, 0);
            //        TxtTotalPremium.Text = _premiumTemp.ToString("###,###.00");
            //        _Factor.Value = Factor[valueLimit].ToString();
            //        _TotalPremium1.Value = Math.Round(Math.Round(TotalPremium1, 1), 0).ToString();
            //        _TotalPremium2.Value = Math.Round(Math.Round(TotalPremium2, 1), 0).ToString();
            //        _TotalPremium3.Value = Math.Round(Math.Round(TotalPremium3, 1), 0).ToString();
            //        _TotalPremium4.Value = Math.Round(Math.Round(TotalPremium4, 1), 0).ToString();
            //    }
            //    else
            //        throw new Exception("The Estimated Gross Receipts is missong or wrong.");
            //}
            //else
            //{
            //    throw new Exception("The limit is missing or wrong.");
            //}
        }
        private int GetCalculateQuestions()
        {
            int creditdebit = 0;
            int credit = 0;
            int debit = 0;
            

            if (rblPrivacyOfficer.SelectedIndex == 0) //Question 6a
            {
                creditdebit += 2;
                debit += 2;
            }
            if (rblPrivacyPractice.SelectedIndex == 0) //Question 6b
            {
                creditdebit += 4;
                debit += 4;
            }
            else
            {
                creditdebit += -4;
                credit += -4;
            }
            if (rblAwerenessTrain.SelectedIndex == 0)  //Question 6c
            {
                creditdebit += 1;
                debit += 1;
            }
            else
            {
                creditdebit += -1;
                credit += -1;
            }
            if (rblTechPerson.SelectedIndex == 0) //Question 7
            {
                creditdebit += 2;
                debit += 2;
            }
            else
            {
                creditdebit += -2;
                credit += -2;
            }
            if (rblPrivacyBreach.SelectedIndex == 0) //Question 8
            {
                creditdebit += 2;
                debit += 2;
            }
            else
            {
                creditdebit += -3;
                credit += -3;
            }
            if (rblGmail.SelectedIndex == 0) //Question 9
            {
                creditdebit += 2;
                debit += 2;
            }
            else
            {
                creditdebit += -4;
                credit += -4;
            }
            if (rblLockedCab.SelectedIndex == 0) //Question 10ai
            {
                creditdebit += 3;
                debit += 3;
            }
            else
            {
                creditdebit += -2;
                credit += -2;
            }
            if (rblPaperRet.SelectedIndex == 0) //Question 10aii
            {
                creditdebit += 1;
                debit += 1;
            }
            else
            {
                creditdebit += -1;
                credit += -1;
            }
            if (rblShredDoc.SelectedIndex == 0) //Question 10aiii
            {
                creditdebit += 2;
                debit += 2;
            }
            else
            {
                creditdebit += -2;
                credit += -2;
            }
            if (rblITEncrypted.SelectedIndex == 0) //Question 10bi
            {
                creditdebit += 4;
                debit += 4;
            }
            else
            {
                creditdebit += -4;
                credit += -4;
            }
            if (rblITNetwork.SelectedIndex == 0) //Question 10bii
            {
                creditdebit += 2;
                debit += 2;
            }
            else
            {
                creditdebit += -2;
                credit += -2;
            }

            txtTotalDebit.Text = debit.ToString();
            txtTotalCredit.Text = credit.ToString();
            return creditdebit;
        }


        public void ShowMessage(string Message)
        {
            ClientScriptManager script = this.Page.ClientScript;
            if (!script.IsClientScriptBlockRegistered(this.GetType(), "Alert"))
            {
                script.RegisterClientScriptBlock(this.GetType(), "Alert", "<script type=text/javascript>alert('" + Message + "')</script>");
            }
        }

        //private List<string> WriteRdlcToPDF(ReportViewer viewer, EPolicy.TaskControl.Cyber taskControl, List<string> mergePaths, int index)
        //{
        //    Warning[] warnings = null;
        //    string[] streamIds = null;
        //    string mimeType = string.Empty;
        //    string encoding = string.Empty;
        //    string extension = string.Empty;
        //    string filetype = string.Empty;
        //}

        private void History(int taskControlID, int userID, string action, string subject, string note)
        {
            Audit.History history = new Audit.History();
            EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];

            history.Actions = action;
            history.KeyID = taskControlID.ToString();
            history.Subject = subject;
            //history.BuildNotesForHistory("TaskControlID.", "", taskControlID.ToString(), 7);  //7 = mode NOTICEOFCANC
            history.UsersID = userID;
            history.Notes = note + "\r\n";
            history.GetSaveHistory();
        }

        private void DeleteFile(string pathAndFileName)
        {
            if (File.Exists(pathAndFileName))
                File.Delete(pathAndFileName);
        }

        protected void btnEnablePrint_Click(object sender, EventArgs e)
        {
            try
            {
                EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];



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
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to unlock policy printing feature.");
                this.litPopUp.Visible = true;
            }
        }

        protected void btnRenew_Click(object sender, EventArgs e)
        {
            TaskControl.Cyber taskControl = (TaskControl.Cyber)Session["TaskControl"];
            TaskControl.Policy originalPolicy = (TaskControl.Policy)Session["TaskControl"];
            TaskControl.Cyber cyber = new TaskControl.Cyber();

            try
            {
                if (!taskControl.PolicyCanRenewDt(taskControl.TaskControlID, int.Parse(taskControl.Suffix)))
                {
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("The policy has already been renewed.");
                    this.litPopUp.Visible = true;
                    return;
                }
                taskControl.isEndorsement = false;
                cyber = taskControl;
                cyber.RetroactiveDate = taskControl.RetroactiveDate;
                cyber.Mode = 1;
                cyber.CancellationDate = "";
                cyber.CancellationEntryDate = "";
                cyber.CancellationUnearnedPercent = 0.00;
                cyber.CancellationReason = 0;
                cyber.CancellationMethod = 0;
                cyber.PaidAmount = 0.00;
                cyber.PaidDate = taskControl.PaidDate;
                cyber.Ren_Rei = "RN";
                cyber.Rein_Amt = taskControl.CancellationAmount;
                cyber.Coverage = taskControl.Coverage;

                cyber.CommissionAgency = 0.00;
                cyber.CommissionAgent = 0.00;
                cyber.CommissionAgencyPercent = "";
                cyber.CommissionAgentPercent = "";
                ////////////
                oldTaskControlID = taskControl.TaskControlID;
                cyber.TaskControlID = 0;
                cyber.Status = "Inforce";

                cyber.EntryDate = DateTime.Now;
                cyber.EffectiveDate = (DateTime.Parse(cyber.EffectiveDate).AddMonths(12)).ToShortDateString();
                txtEffDt.Text = cyber.EffectiveDate;
                cyber.ExpirationDate = (DateTime.Parse(cyber.ExpirationDate).AddMonths(12)).ToShortDateString();
                txtExpDt.Text = cyber.ExpirationDate;

                //Recalculate();
                //Calculate();
                CalculateCharge();
                cyber.Charge = double.Parse(TxtCharge.Text);

                cyber.ReturnCharge = 0.00;
                cyber.ReturnPremium = 0.00;
                cyber.CancellationAmount = 0.00;
                cyber.ReturnCommissionAgency = 0.00;
                cyber.ReturnCommissionAgent = 0.00;

                cyber.PrintPolicy = false;
                cyber.PrintDate = "";

                int msufijo;
                int sufijo = int.Parse(taskControl.Suffix);
                msufijo = sufijo + 1;

                if (msufijo < 10)
                    cyber.Suffix = "0".ToString() + msufijo.ToString();
                else
                    cyber.Suffix = msufijo.ToString();

                int mAniv;
                int aniv = int.Parse(taskControl.Anniversary);
                mAniv = aniv + 1;

                if (mAniv < 10)
                    cyber.Anniversary = "0".ToString() + mAniv.ToString();
                else
                    cyber.Anniversary = mAniv.ToString();

                int RetroYear = 0;
                RetroYear = DateTime.Parse(cyber.EffectiveDate).Year - DateTime.Parse(cyber.RetroactiveDate).Year;
                if (cyber.Endoso == 0)
                {
                    switch (RetroYear)
                    {
                        case 0:
                            cyber.TotalPremium = double.Parse(TxtTotalPremium.Text);
                            break;
                        case 1:
                            cyber.TotalPremium = double.Parse(TxtTotalPremium.Text);
                            break;
                        case 2:
                            cyber.TotalPremium = double.Parse(TxtTotalPremium.Text);
                            break;
                        default:
                            cyber.TotalPremium = double.Parse(TxtTotalPremium.Text);
                            break;
                    }
                }

                EnableQuestions();

                Session.Clear();
                Session.Add("TaskControl", cyber);
                Response.Redirect("CyberApplication.aspx", false);
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }
        }

        protected void btnReinstatement_Click(object sender, EventArgs e)
        {
            TaskControl.Cyber taskControl = (TaskControl.Cyber)Session["TaskControl"];
            TaskControl.Policy policy = (TaskControl.Policy)Session["TaskControl"];
            TaskControl.Cyber cyber = new TaskControl.Cyber(true);
            taskControl.isEndorsement = false;
            try
            {
                ValidateReinstatement(cyber, taskControl);

                cyber = taskControl;
                cyber.Mode = 2;
                cyber.CancellationDate = "";
                cyber.CancellationEntryDate = "";
                cyber.CancellationUnearnedPercent = 0.00;
                cyber.CancellationMethod = 0;
                cyber.CancellationReason = 0;
                cyber.EntryDate = DateTime.Now;
                cyber.PaidAmount = taskControl.PaidAmount;
                cyber.PaidDate = "";
                cyber.Ren_Rei = "RI";
                cyber.Rein_Amt = taskControl.CancellationAmount;
                cyber.PaidDate = taskControl.PaidDate;
                cyber.CommissionAgency = taskControl.ReturnCommissionAgency;
                cyber.CommissionAgent = taskControl.ReturnCommissionAgent;
                cyber.CommissionAgencyPercent = taskControl.CommissionAgencyPercent.Trim();
                cyber.CommissionAgentPercent = taskControl.CommissionAgentPercent.Trim();
                //policies.TotalPremium = taskControl.ReturnPremium;
                //policies.Charge = taskControl.ReturnCharge;
                cyber.ReturnCharge = 0.00;
                cyber.ReturnPremium = 0.00;
                cyber.CancellationAmount = 0.00;
                cyber.ReturnCommissionAgency = 0.00;
                cyber.ReturnCommissionAgent = 0.00;
                //policies.TaskControlID = 0;
                cyber.Status = "Inforce";



                //int msufijo;
                //int sufijo = int.Parse(taskControl.Suffix);
                //msufijo = sufijo + 1;
                //policies.Suffix = "0".ToString() + msufijo.ToString();

                Session.Add("TaskControl", cyber);

                FillTextControl();
                lblExpDate.Text = "Exp. Date";
                EnableControls();
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }
        }

        private void ValidateReinstatement(TaskControl.Cyber policies, TaskControl.Cyber Oldpolicies)
        {
            string errorMessage = String.Empty;
            bool found = false;

            string mStatus = Oldpolicies.Status.Split("/".ToCharArray())[0];

            if (mStatus != "Cancelled")  //Verifica si la póliza se encuentra cancelada.
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

        protected void btnCancellation_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveSessionLookUp();
                Session.Add("FromUI", "CyberApplication.aspx");
                Response.Redirect("CancellationPolicy.aspx", false);
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }
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
                if (ValidateField())
                {
                    FillProperties();
                    EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
                    taskControl.UserID = userID;

                    if (taskControl.isEndorsement)
                    {
                        taskControl.Endoso = int.Parse(txtEndorsementNo.Text);
                        taskControl.SaveCyber();  //(userID);

                        if (taskControl.IsPolicy)
                        {
                            //Update Inception Payment Amount
                            UpdateInceptionPartialPayments(taskControl.TaskControlID, (taskControl.TotalPremium + taskControl.Charge));
                            //UpdateInceptionPartialPayments(taskControl.TaskControlID, (taskControl.TotalPremium));

                            //if (taskControl.Charge != 0.00)
                            //{
                            //    EPolicy.TaskControl.PaymentPolicy payments2 = new EPolicy.TaskControl.PaymentPolicy();
                            //    payments2 = PaymentPolicy.GetPaymentsByTaskControlID(taskControl);

                            //    bool HasCharge = false;
                            //    double chargePremium = 0.00;

                            //    for (int i = 0; i < payments2.PaymentsCollection.Rows.Count; i++)
                            //    {
                            //        if (payments2.PaymentsCollection.Rows[i]["CheckNumber"].ToString().Contains("Inception Charge"))
                            //        {
                            //            HasCharge = true;
                            //            chargePremium = double.Parse(payments2.PaymentsCollection.Rows[i]["TransactionAmount"].ToString());
                            //        }
                            //    }

                            //    if (!HasCharge)
                            //    {
                            //        AddChargePartialPayments(taskControl);
                            //    }
                            //    else
                            //    {
                            //        if (taskControl.Charge != chargePremium)
                            //        {
                            //            UpdateInceptionChargePartialPayments(taskControl.TaskControlID, (taskControl.Charge));
                            //        }
                            //    }
                            //}
                        }


                        AddEndorsement(taskControl.TaskControlID);

                        taskControl.isEndorsement = false;


                        FillTextControl();

                        DisableControls();

                        Session.Remove("DtPolicyDetail");


                        Session["TaskControl"] = taskControl;



                        ShowMessage("Policy endorsement information saved successfully.");
                    }
                    else
                    {
                        taskControl.SaveCyber();

                        UpdateInceptionPartialPayments(taskControl.TaskControlID, (taskControl.TotalPremium + taskControl.Charge));
                        //UpdateInceptionPartialPayments(taskControl.TaskControlID, (taskControl.TotalPremium));

                        //if (taskControl.Charge != 0.00)
                        //{
                        //    EPolicy.TaskControl.PaymentPolicy payments2 = new EPolicy.TaskControl.PaymentPolicy();
                        //    payments2 = PaymentPolicy.GetPaymentsByTaskControlID(taskControl);

                        //    bool HasCharge = false;
                        //    double chargePremium = 0.00;

                        //    for (int i = 0; i < payments2.PaymentsCollection.Rows.Count; i++)
                        //    {
                        //        if (payments2.PaymentsCollection.Rows[i]["CheckNumber"].ToString().Contains("Inception Charge"))
                        //        {
                        //            HasCharge = true;
                        //            chargePremium = double.Parse(payments2.PaymentsCollection.Rows[i]["TransactionAmount"].ToString());
                        //        }
                        //    }

                        //    if (!HasCharge)
                        //    {
                        //        AddChargePartialPayments(taskControl);
                        //    }
                        //    else
                        //    {
                        //        if (taskControl.Charge != chargePremium)
                        //        {
                        //            UpdateInceptionChargePartialPayments(taskControl.TaskControlID, (taskControl.Charge));
                        //        }
                        //    }
                        //}

                        FillTextControl();
                        FillGrid();
                        FillDataGridInsurance();
                        DisableControls();

                        if (taskControl.IsPolicy)
                            ShowMessage("The Policy was saved successfully");
                        else
                            ShowMessage("The Quotes was saved successfully");
                    }


                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
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

        private XmlDocument GetInsertEndorsementsXml(int TaskControlID)
        {
            TaskControl.Cyber taskControl = (TaskControl.Cyber)Session["TaskControl"];
            TaskControl.Cyber taskControl2 = (TaskControl.Cyber)Session["OriginalPolicy"];

            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[10];

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

            if (txtRetroEffDate.Text != "")
                DbRequestXmlCooker.AttachCookItem("RetroactiveDate", SqlDbType.DateTime, 0, txtRetroEffDate.Text.Trim(), ref cookItems);
            else
                DbRequestXmlCooker.AttachCookItem("RetroactiveDate", SqlDbType.DateTime, 0, DateTime.Now.ToShortDateString(), ref cookItems);

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

        private string VerifyChanges(EPolicy.TaskControl.Cyber newOPP, int userID)
        {
            EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["OriginalPolicy"];
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

            history.Actions = "EDIT";

            //history.KeyID = this.TaskControlID.ToString();
            //history.Subject = "POLICIES";
            //history.UsersID = userID;
            //history.GetNotes();
            history.GetSaveHistory();
            return history.Notes.ToUpper().Trim();

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

            EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];

            //if (taskControl.PolicyType.ToString().Trim().Length >= 3 && !taskControl.PolicyType.Contains("A") && !taskControl.PolicyType.Contains("L"))
            //    tempPolType = taskControl.PolicyType.Remove(taskControl.PolicyType.IndexOf('T'));
            //else
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

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
            Login.Login cp = HttpContext.Current.User as Login.Login;
            FillTextControl();
            taskControl.Mode = (int)EPolicy.TaskControl.TaskControl.TaskControlMode.UPDATE;

            Session.Add("TaskControl", taskControl);
            txtInsuranceCarrier.Text = "";
            txtEffectiveDates.Text = "";
            ddlLimitsPolicyInfo.SelectedIndex = -1;
            txtPolicyNumberInfo.Text = "";
            taskControl.isEndorsement = false;
            EnableControls();
            pnlHistory.Visible = false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            TaskControl.Cyber taskControl = (TaskControl.Cyber)Session["TaskControl"];
            try
            {
                int id = taskControl.TaskControlID;
                TaskControl.Cyber.DeleteCyberPolicyByTaskControlID(id, taskControl.IsPolicy);
                taskControl = new TaskControl.Cyber(false);
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

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Cyber taskControl = new Cyber(false);
            taskControl.Mode = 1;
            Session.Add("TaskControl", taskControl);
            Response.Redirect("CyberApplication.aspx", true);

        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
            
            if (taskControl.TaskControlID == 0)
            {
                TaskControl.TaskControl _oldTaskControlID = TaskControl.TaskControl.GetTaskControlByTaskControlID(oldTaskControlID, userID);
                Cyber taskControl2 = new Cyber(false);
                taskControl.Mode = 1;
                Session.Add("TaskControl", _oldTaskControlID);
                Response.Redirect("CyberApplication.aspx", true);
                //Response.Redirect("MainMenu.aspx", true);
            }
            else
            {
                //TaskControl.TaskControl taskControl2 = TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControl.TaskControlID, userID);
                Session["TaskControl"] = taskControl;
                FillTextControl();
                DisableControls();
                // Response.Redirect("CyberApplication.aspx", true);
                TxtFirstName.Enabled = false;
            }
        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("MainMenu.aspx", true);
        }

        private void RemoveSessionLookUp()
        {
            Session.Remove("LookUpTables");
        }

        protected void btnHistory_Click(object sender, EventArgs e)
        {
            if (Session["TaskControl"] != null)
            {
                RemoveSessionLookUp();
                TaskControl.Cyber taskControl = (TaskControl.Cyber)Session["TaskControl"];
                Response.Redirect("SearchAuditItems.aspx?type=30&taskControlID=" +
                    taskControl.TaskControlID.ToString().Trim());
            }
        }

        protected void btnEndor_Click(object sender, EventArgs e)
        {
            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
            int userID = 0;
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
            EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
            //EPolicy.TaskControl.Policies taskControl2 = (EPolicy.TaskControl.Policies)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControlID, userID);

            Session.Add("PreviousPremium", taskControl.TotalPremium);
            Session.Add("OriginalPolicy", taskControl);

            taskControl.isEndorsement = true;
            previousPremium = taskControl.TotalPremium;
            taskControl.Mode = (int)TaskControl.TaskControl.TaskControlMode.UPDATE;

            Session.Add("TaskControl", taskControl);

            this.TxtFirstName.Enabled = true;
            pnlEndorsement.Visible = true;
            pnlEndorsement.Enabled = true;
            txtDatePrepared.Text = DateTime.Now.ToShortDateString();
            txtDatePrepared.Enabled = false;

            txtEndorsementNo.Text = (taskControl.Endoso + 1).ToString();

            lblEndorsement.Visible = false;
            dtEndorsement.Visible = false;

            EnableControls();
            //ShowEndorsementSection(true);
        }

        protected void btnFinancialCanc_Click(object sender, EventArgs e)
        {
            RemoveSessionLookUp();
            Session.Add("FromUI", "CyberApplication.aspx");
            Response.Redirect("FinancialCancellations.aspx", false);
        }

        protected void btnTailQuote_Click(object sender, EventArgs e)
        {
            FillProperties();

            string js = "<script language=javascript> javascript:popwindow=window.open('TailQuote.aspx','popwindow','modal=yes,toolbar=no,location=center,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,copyhistory=no,width=445,height=300');popwindow.focus(); </script>";

            Response.Write(js);
        }

        protected void btnPrintCertificate_Click(object sender, EventArgs e)
        {
            string js = "<script language=javascript> javascript:popwindow=window.open('PrintCertificate.aspx?','popwindow','toolbar=no,location=center,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,copyhistory=no,width=850,height=450');popwindow.focus(); </script>";
            Response.Write(js);
            //DisableControl();
        }

        protected void btnPayments_Click(object sender, EventArgs e)
        {
            RemoveSessionLookUp();
            Session.Add("FromPage", "CyberApplication.aspx");
            Response.Redirect("ViewPayment.aspx");
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
                EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
                int userID = 0;
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                switch (e.CommandName)
                {
                    case "Select":

                        lblEndorsement.Visible = true;
                        pnlEndorsement.Visible = true;
                        btnHideEndoPanel.Enabled = true;
                        btnHideEndoPanel.Visible = true;
                        txtEndorsementNo.Text = e.Item.Cells[2].Text.Trim().Replace("&nbsp;", "");
                        txtEndorsementNo.Enabled = false;
                        txtDatePrepared.Text = e.Item.Cells[3].Text.Trim().Replace("&nbsp;", "");
                        txtDatePrepared.Enabled = false;
                        txtEndoEffDate.Text = e.Item.Cells[4].Text.Trim().Replace("&nbsp;", "");
                        txtEndoEffDate.Enabled = false;
                        txtRetroEffDate.Text = e.Item.Cells[5].Text.Trim().Replace("&nbsp;", "");
                        txtRetroEffDate.Enabled = false;
                        txtEndoPremium.Text = e.Item.Cells[7].Text.Trim().Replace("&nbsp;", "");
                        txtEndoPremium.Enabled = false;
                        ddlEndoType.SelectedIndex = ddlEndoType.Items.IndexOf(
                        ddlEndoType.Items.FindByText(e.Item.Cells[6].Text.Trim()));
                        ddlEndoType.Enabled = false;
                        txtEndoComments.Enabled = false;
                        if (e.Item.Cells[8].Text.Trim() != " ")
                            txtEndoComments.Text = e.Item.Cells[8].Text.Trim();

                        if (e.Item.Cells[9].Text.Trim() != " ")
                            txtEndoComments.Text = e.Item.Cells[8].Text.Trim() + System.Environment.NewLine + e.Item.Cells[9].Text.Trim();
                        break;
                    case "Edit":
                        lblEndorsement.Visible = true;
                        pnlEndorsement.Visible = true;
                        //btnHideEndoPanel.Enabled = true;
                        //btnHideEndoPanel.Visible = true;
                        dtEndorsement.Visible = false;
                        txtEndorsementID.Text = e.Item.Cells[1].Text.Trim().Replace("&nbsp;", "");
                        txtEndorsementID.Enabled = false;
                        txtEndorsementID.Visible = false;
                        txtEndorsementNo.Text = e.Item.Cells[2].Text.Trim().Replace("&nbsp;", "");
                        txtEndorsementNo.Enabled = true;
                        txtDatePrepared.Text = e.Item.Cells[3].Text.Trim().Replace("&nbsp;", "");
                        txtDatePrepared.Enabled = true;
                        txtEndoEffDate.Text = e.Item.Cells[4].Text.Trim().Replace("&nbsp;", "");
                        txtEndoEffDate.Enabled = true;
                        txtRetroEffDate.Text = e.Item.Cells[5].Text.Trim().Replace("&nbsp;", "");
                        txtRetroEffDate.Enabled = true;
                        txtEndoPremium.Text = e.Item.Cells[7].Text.Trim().Replace("&nbsp;", "");
                        txtEndoPremium.Enabled = true;
                        ddlEndoType.SelectedIndex = ddlEndoType.Items.IndexOf(
                        ddlEndoType.Items.FindByText(e.Item.Cells[6].Text.Trim()));
                        ddlEndoType.Enabled = true;
                        txtEndoComments.Enabled = true;
                        if (e.Item.Cells[8].Text.Trim() != " ")
                            txtEndoComments.Text = e.Item.Cells[8].Text.Trim().Replace("&nbsp;", "");

                        if (e.Item.Cells[9].Text.Trim() != " ")
                            txtEndoComments.Text = e.Item.Cells[8].Text.Trim().Replace("&nbsp;", "") + System.Environment.NewLine + e.Item.Cells[9].Text.Trim().Replace("&nbsp;", "");


                        userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
                        taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
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

                        taskControl.SaveCyber();  //(userID);

                        //Update Inception Payment Amount
                        UpdateInceptionPartialPayments(taskControl.TaskControlID, (taskControl.TotalPremium + taskControl.Charge));
                        PaymentPolicy pp = new PaymentPolicy();

                        FillTextControl();
                        //DisableControls();

                        Session.Remove("DtPolicyDetail");


                        taskControl.Mode = 4;
                        Session["TaskControl"] = taskControl;

                        DeleteEndorsements(int.Parse(e.Item.Cells[1].Text.Trim()));
                        FillEndorsementGrid();

                        this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Endorsement deleted successfully.");
                        this.litPopUp.Visible = true;

                        break;
                    case "Print":

                        break;

                    default: //Page
                        dtEndorsement.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                        dtEndorsement.DataSource = (DataTable)Session["dtPermission"];
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
                Response.Redirect("CyberApplication.aspx?" + taskControl.TaskControlID, true);
            }
            else  // Pager
            {
                DtSearchPayments.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                DtSearchPayments.DataSource = (DataTable)Session["DtTaskPolicy"];
                DtSearchPayments.DataBind();
            }
        }

        private void FillEndorsementGrid()
        {
            EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];

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
                    //chkUserMod.Checked = false;
                    dtEndorsement.DataSource = null;
                    dtEndorsement.DataBind();
                }
            }
            else
            {
                lblEndorsementHistory.Visible = false;
                //chkUserMod.Checked = false;
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

        private double CalculateDifference(EPolicy.TaskControl.Cyber taskControl)
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

        private void CalculateEndorsement()
        {
            EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
            EPolicy.TaskControl.Cyber OldOPP = (EPolicy.TaskControl.Cyber)Session["OriginalPolicy"];
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
            //ShowEndorsementSection(true);
        }

        protected void btnCalculatePremium_Click(object sender, EventArgs e)
        {
            try
            {
                CalculateCharge();
                EnableQuestions();
                //DisableQuestions();

                if (txtEndoEffDate.Text != "")//  && taskControl.isEndorsement)
                {
                    chkUserMod.Checked = false;
                    //ResetValues();
                    //Calculate();
                    CalculateCharge();

                    CalculateEndorsement();
                    
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
            TaskControl.Cyber taskControl = (TaskControl.Cyber)Session["TaskControl"];
            TaskControl.Comment comment = (TaskControl.Comment)new EPolicy.TaskControl.Comment();

            comment.TaskControlID = taskControl.TaskControlID;
            comment.PolicyNo = taskControl.PolicyNo;
            Session.Add("TaskControlComments", comment);

            RemoveSessionLookUp();
            Session.Add("FromPage", "CyberApplication.aspx");
            Response.Redirect("Comments.aspx");
        }

        protected void btnAddPolicyInfo_Click(object sender, EventArgs e)
        {
            EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];

            EPolicy.TaskControl.Cyber.UpdateCyberInsuranceHistory(int.Parse(txtLiabilityID.Text.ToString()), taskControl.TaskControlID, taskControl.UserID, txtInsuranceCarrier.Text.ToString().Trim(), txtEffectiveDates.Text.ToString().Trim(), ddlLimitsPolicyInfo.SelectedItem.Text.ToString().Trim(), txtPolicyNumberInfo.Text.ToString().Trim());
            
            FillDataGridInsurance();
          
        }

        public void FillDataGridInsurance()
        {
            try
            {
                EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
                // LblError.Enabled = false;
                dtCyberPolicyInfo.DataSource = null;
                DataTable DtTask = new DataTable();
                DtTask = Cyber.GetInsuranceHistory(taskControl.TaskControlID);

                if (DtTask.Rows.Count != 0)
                {
                    dtCyberPolicyInfo.DataSource = DtTask;
                    dtCyberPolicyInfo.DataBind();
                }
                else
                {
                    dtCyberPolicyInfo.DataSource = null;
                    dtCyberPolicyInfo.DataBind();
                }

            }
            catch
            {
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("A problem occured while assigning data to webpage controls.");
                this.litPopUp.Visible = true;
            }

        }


        protected void btnConvert_Click(object sender, EventArgs e)
        {
            EPolicy.TaskControl.Cyber taskControlOld = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
            EPolicy.TaskControl.Cyber taskControlNew = new EPolicy.TaskControl.Cyber(true);
            taskControlNew = taskControlOld;
            taskControlNew.IsPolicy = true;
            taskControlNew.TaskControlTypeID = 22;
            //taskControlNew.TaskControlID = 0;
            taskControlNew.Mode = 1; //Add
            //taskControlNew._Mode = 1;
            taskControlNew.PolicyType = "ICE";
            taskControlNew.PolicyClassID = 19;


            taskControlNew.Term = 12;

            convert = true;

            Session.Clear();
            Session.Add("TaskControl", taskControlNew);
            Response.Redirect("CyberApplication.aspx", true);

        }
        protected void btnConvertPrimary_Click1(object sender, EventArgs e)
        {
            EPolicy.TaskControl.Cyber taskControlOld = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
            EPolicy.TaskControl.Cyber taskControlNew = new EPolicy.TaskControl.Cyber(true);
            taskControlNew = taskControlOld;
            taskControlNew.IsPolicy = true;
            taskControlNew.TaskControlTypeID = 22;
            //taskControlNew.TaskControlID = 0;
            taskControlNew.Mode = 1; //Add
            //taskControlNew._Mode = 1;
            taskControlNew.PolicyType = "EMD";
            taskControlNew.PolicyClassID = 19;

           
            taskControlNew.Term = 12;

            convert = true;

            Session.Clear();
            Session.Add("TaskControl", taskControlNew);
            Response.Redirect("CyberApplication.aspx", true);
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            TaskControl.Cyber taskControl = (TaskControl.Cyber)Session["TaskControl"];
            Login.Login cp = HttpContext.Current.User as Login.Login;
            string userName = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();
            try
            {

                //Cancelation Region
                #region Cancellation
                if (taskControl.CancellationDate != String.Empty && !taskControl.PolicyType.Trim().Contains("B"))
                {
                    //EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
                    //Login.Login cp = HttpContext.Current.User as Login.Login;
                    //string userName = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();

                    List<string> mergePaths = new List<string>();
                    string ProcessedPath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"];
                    string PathReport = MapPath("Reports/Cyber/");
                    string FileNamePdf = "";

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
                    taskControl.PrintPolicy = true;
                    btnEnablePrint.Visible = true;
                }
                #endregion
                #region Cyber Policy
                //Check Permition User
                else if (!taskControl.PrintPolicy && taskControl.Anniversary == "01") //Cyber Policy
                {
                    List<string> mergePaths = new List<string>();
                    string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                    EPolicy2.Reports.ExportFile expFile = new EPolicy2.Reports.ExportFile();
                    string _FileName = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                    //mergePaths.Add(_FileName);
                    mergePaths.Add(PrintCyberPolicy("CyberCover.rdlc"));
                    mergePaths.Add(PrintCyberPolicy("CyberDeclarations1.rdlc"));
                    mergePaths.Add(PrintCyberPolicy("CyberDeclarations2.rdlc"));                    
                    mergePaths.Add(PrintCyberPolicy("CyberPolicy1.rdlc"));
                    mergePaths.Add(PrintCyberPolicy("CyberPolicy2.rdlc"));
                    mergePaths.Add(PrintCyberPolicy("CyberPolicy3.rdlc"));
                    mergePaths.Add(PrintCyberPolicy("CyberPolicy4.rdlc"));
                    mergePaths.Add(PrintCyberPolicy("CyberPolicy5.rdlc"));
                    mergePaths.Add(PrintCyberPolicy("CyberPolicy6.rdlc"));
                    mergePaths.Add(PrintCyberPolicy("CyberPolicy7.rdlc"));
                    mergePaths.Add(PrintCyberPolicy("CyberPolicy8.rdlc"));
                    mergePaths.Add(PrintCyberPolicy("CyberPolicy9.rdlc"));
                    mergePaths.Add(PrintCyberPolicy("CyberPolicy10.rdlc"));
                    mergePaths.Add(PrintCyberPolicy("CyberPolicy11.rdlc"));
                    mergePaths.Add(PrintCyberPolicy("CyberPolicy12.rdlc"));
                    mergePaths.Add(PrintCyberPolicy("CyberPolicy13.rdlc"));
                    mergePaths.Add(PrintCyberPolicy("CyberPolicy14.rdlc"));
                    mergePaths.Add(PrintCyberPolicy("CyberPolicy15.rdlc"));
                    mergePaths.Add(PrintCyberPolicy("CyberPolicy16.rdlc"));
                    mergePaths.Add(PrintCyberPolicy("CyberPolicy17.rdlc"));

                    FileInfo info;
                    //FileInfo info = new FileInfo(MapPath("Reports/Cyber/CyberMandatoryPremiumEndorsement.pdf"));
                    if (File.Exists(MapPath("Reports/Cyber/CyberMandatoryPremiumEndorsement.pdf")))
                    {
                        info = new FileInfo(MapPath("Reports/Cyber/CyberMandatoryPremiumEndorsement.pdf"));
                        info.CopyTo(ProcessedPath + "CyberMandatoryPremiumEndorsement.pdf", true);
                        mergePaths.Add(ProcessedPath + "CyberMandatoryPremiumEndorsement.pdf");
                    }
                    //mergePaths.Add(MapPath("Reports/Cyber/CyberMandatoryPremiumEndorsement.pdf"));
                    if (File.Exists(MapPath("Reports/Cyber/CyberContinuousRenewalEndorsement.pdf")))
                    {
                        info = new FileInfo(MapPath("Reports/Cyber/CyberContinuousRenewalEndorsement.pdf"));
                        info.CopyTo(ProcessedPath + "CyberContinuousRenewalEndorsement.pdf", true);
                        mergePaths.Add(ProcessedPath + "CyberContinuousRenewalEndorsement.pdf");
                    }


                    //if (File.Exists(ProcessedPath + taskControl.TaskControlID.ToString() + ".pdf"))
                    //    File.Delete(ProcessedPath + taskControl.TaskControlID.ToString() + ".pdf");

                    //Generar PDF
                    EPolicy.CreatePDFBatch mergeFinal = new EPolicy.CreatePDFBatch();
                    string FinalFile = "";

                    if (taskControl.Charge > 0)//TxtCharge.Text != ".00")
                    {
                        var currentApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath.ToString();
                        string fullFilePath = currentApplicationPath + "Reports\\Word\\Files\\CN-2021-299-D_ENDOSO_DERRAMAS.pdf";
                        string copyToPath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + "CN-2021-299-D_ENDOSO_DERRAMAS.pdf";
                        File.Copy(fullFilePath, copyToPath, true);
                        mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + "CN-2021-299-D_ENDOSO_DERRAMAS.pdf");
                    }

                    FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl.TaskControlID.ToString());

                    taskControl.PrintPolicy = true;
                    taskControl.PrintDate = DateTime.Now.ToShortDateString();
                    taskControl.Mode = 2;
                    FillProperties();
                    //taskControl.SaveCyber();

                    History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY RENOVATION DOCUMENT.");

                    RemoveSessionLookUp();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                    taskControl.PrintPolicy = true;
                    btnEnablePrint.Visible = true;
                }
                #endregion
                #region Cyber Renovation
                else if (!taskControl.PrintPolicy) //Cyber Renovation
                {
                    List<string> mergePaths = new List<string>();
                    string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                    EPolicy2.Reports.ExportFile expFile = new EPolicy2.Reports.ExportFile();
                    string _FileName = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                    //mergePaths.Add(_FileName);
                    mergePaths.Add(PrintCyberPolicy("CyberRenewalEndorsement1.rdlc"));
                    mergePaths.Add(PrintCyberPolicy("CyberRenewalEndorsement2.rdlc"));


                    //if (File.Exists(ProcessedPath + taskControl.TaskControlID.ToString() + ".pdf"))
                    //    File.Delete(ProcessedPath + taskControl.TaskControlID.ToString() + ".pdf");

                    //Generar PDF
                    EPolicy.CreatePDFBatch mergeFinal = new EPolicy.CreatePDFBatch();
                    string FinalFile = "";

                    if (taskControl.Charge > 0)//TxtCharge.Text != ".00")
                    {
                        var currentApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath.ToString();
                        string fullFilePath = currentApplicationPath + "Reports\\Word\\Files\\CN-2021-299-D_ENDOSO_DERRAMAS.pdf";
                        string copyToPath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + "CN-2021-299-D_ENDOSO_DERRAMAS.pdf";
                        File.Copy(fullFilePath, copyToPath, true);
                        mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + "CN-2021-299-D_ENDOSO_DERRAMAS.pdf");
                    }

                    FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl.TaskControlID.ToString());

                    taskControl.PrintPolicy = true;
                    taskControl.PrintDate = DateTime.Now.ToShortDateString();

                    //taskControl.SaveCyber(userID);
                    History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY RENOVATION DOCUMENT.");

                    RemoveSessionLookUp();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                    taskControl.PrintPolicy = true;
                    btnEnablePrint.Visible = true;
                }
                #endregion
                else
                {
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy Printing has been disabled.  Please contact your supervisor.");
                    this.litPopUp.Visible = true;
                }

                taskControl.PrintDate = DateTime.Now.ToShortDateString();
                FillProperties();
                History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY.");
                taskControl.SaveOnlyPolicy(userID);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private string PrintCyberPolicy(string rdlcDocument)
        {
            try
            {
                TaskControl.Cyber taskControl = (TaskControl.Cyber)Session["TaskControl"];
                ReportViewer viewer = new ReportViewer();
                string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                viewer.LocalReport.DataSources.Clear();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportPath = Server.MapPath("Reports/Cyber/" + rdlcDocument);

                string _individual = "";
                string _corporation = "";

                if (ddlEnity.SelectedItem.Text == "Solo Physician")
                    _individual = "x";
                else
                    _individual = "";
                if (ddlEnity.SelectedItem.Text != "Solo Physician")
                    _corporation = "x";
                else
                    _corporation = "";


                if (rdlcDocument == "CyberDeclarations1.rdlc")
                {
                    ReportParameter[] param = new ReportParameter[11];
                    param[0] = new ReportParameter("effectiveDate", DateTime.Parse(taskControl.EffectiveDate).ToShortDateString());
                    param[1] = new ReportParameter("expirationDate", taskControl.ExpirationDate);
                    param[2] = new ReportParameter("policyNo", taskControl.PolicyNo);
                    param[3] = new ReportParameter("agency", ddlAgency.SelectedItem.Text.ToString().Trim() + " / " + ddlAgent.SelectedItem.Text.ToString().Trim());
                    param[4] = new ReportParameter("limitAggregate", ddlCyberLimits.SelectedItem.Text.ToString().Split('/')[0]);
                    param[5] = new ReportParameter("nameInsurred", TxtFirstName.Text.ToString().Trim().ToUpper());
                    param[6] = new ReportParameter("address1", TxtAddrs1.Text.ToString().ToUpper());
                    param[7] = new ReportParameter("address2", TxtAddrs2.Text.ToString().ToUpper());
                    param[8] = new ReportParameter("zip", TxtCity.Text.ToString() + "," + TxtState.Text.ToString() + "," + TxtZip.Text.ToString());
                    param[9] = new ReportParameter("individual", _individual);
                    param[10] = new ReportParameter("corporation", _corporation);

                    viewer.LocalReport.SetParameters(param);
                    viewer.LocalReport.Refresh();
                }
                if (rdlcDocument == "CyberDeclarations2.rdlc")
                {
                    ReportParameter[] param = new ReportParameter[4];
                    param[0] = new ReportParameter("retroDate", DateTime.Parse(taskControl.RetroactiveDate).ToShortDateString());
                    param[1] = new ReportParameter("totalPrem", taskControl.TotalPremium.ToString("###,###.00"));
                    param[2] = new ReportParameter("limitDeductible", ddlCyberLimits.SelectedItem.Text.ToString().Split('/')[1]);
                    param[3] = new ReportParameter("todayDate", DateTime.Today.ToShortDateString());

                    viewer.LocalReport.SetParameters(param);
                    viewer.LocalReport.Refresh();
                }
                if (rdlcDocument == "CyberRenewalEndorsement1.rdlc")
                {
                    ReportParameter[] param = new ReportParameter[11];
                    param[0] = new ReportParameter("effectiveDate", DateTime.Parse(taskControl.EffectiveDate).ToShortDateString());
                    param[1] = new ReportParameter("expirationDate", taskControl.ExpirationDate);
                    param[2] = new ReportParameter("policyNo", taskControl.PolicyNo);
                    param[3] = new ReportParameter("agency", ddlAgency.SelectedItem.Text.ToString().Trim() + " / " + ddlAgent.SelectedItem.Text.ToString().Trim());
                    param[4] = new ReportParameter("limitAggregate", ddlCyberLimits.SelectedItem.Text.ToString().Split('/')[0]);
                    param[5] = new ReportParameter("nameInsurred", TxtFirstName.Text.ToString().Trim().ToUpper());
                    param[6] = new ReportParameter("address1", TxtAddrs1.Text.ToString().ToUpper());
                    param[7] = new ReportParameter("address2", TxtAddrs2.Text.ToString().ToUpper());
                    param[8] = new ReportParameter("zip", TxtCity.Text.ToString() + "," + TxtState.Text.ToString() + "," + TxtZip.Text.ToString());
                    param[9] = new ReportParameter("individual", _individual);
                    param[10] = new ReportParameter("corporation", _corporation);

                    viewer.LocalReport.SetParameters(param);
                    viewer.LocalReport.Refresh();
                }
                if (rdlcDocument == "CyberRenewalEndorsement2.rdlc")
                {
                    ReportParameter[] param = new ReportParameter[4];
                    param[0] = new ReportParameter("retroDate", DateTime.Parse(taskControl.RetroactiveDate).ToShortDateString());
                    param[1] = new ReportParameter("totalPrem", taskControl.TotalPremium.ToString("###,###.00"));
                    param[2] = new ReportParameter("limitDeductible", ddlCyberLimits.SelectedItem.Text.ToString().Split('/')[1]);
                    param[3] = new ReportParameter("todayDate", DateTime.Today.ToShortDateString());

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
        protected void dtCyberPolicyInfo_ItemCommand(object source, DataGridCommandEventArgs e)
        {
           
            try
            {
                EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
                EPolicy.TaskControl.Cyber taskControl = (EPolicy.TaskControl.Cyber)Session["TaskControl"];
                int userID = 0;
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                switch (e.CommandName)
                {
                    case "Modify":
                        btnAddPolicyInfo.Visible = true;
                        txtInsuranceCarrier.Enabled = true;
                        txtEffectiveDates.Enabled = true;
                        ddlLimitsPolicyInfo.Enabled = true;
                        txtPolicyNumberInfo.Enabled = true;
                        txtLiabilityID.Text = e.Item.Cells[1].Text.ToString();
                        txtInsuranceCarrier.Text = e.Item.Cells[3].Text.ToString();
                        txtEffectiveDates.Text = e.Item.Cells[4].Text.ToString();
                        //ddlLimitsPolicyInfo.Items.FindByText(ddlLimitsPolicyInfo.SelectedItem.Text = e.Item.Cells[5].Text.ToString());
                        txtPolicyNumberInfo.Text = e.Item.Cells[6].Text.ToString();
                        

                        break;                   

                    case "Delete":

                        FillProperties();

                        taskControl.SaveCyber();  //(userID);                                         

                        FillTextControl();

                        Session.Remove("DtPolicyDetail");

                        taskControl.Mode = 4;
                        Session["TaskControl"] = taskControl;

                        DeleteInsuranceHistory(int.Parse(e.Item.Cells[1].Text.Trim()));
                        FillDataGridInsurance();

                        this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Profesional Liability deleted successfully.");
                        this.litPopUp.Visible = true;

                        break;

                    default:
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

        public static void DeleteInsuranceHistory(int liabilityID)
        {
            DBRequest Executor = new DBRequest();

            try
            {
                Executor.BeginTrans();
                Executor.Update("DeleteCyberInsuranceHistory", DeleteInsuranceXml(liabilityID));
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error, Please try again. " + xcp.Message, xcp);
            }
        }
        private static XmlDocument DeleteInsuranceXml(int liabilityID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("LiabilityID",
                SqlDbType.Int, 0, liabilityID.ToString(),
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
        protected void btnComissions_Click(object sender, EventArgs e)
        {
            RemoveSessionLookUp();
            Session.Add("FromPage", "CyberApplication.aspx");
            Response.Redirect("ViewCommission.aspx");
        }
        protected void ddlAgency_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void TxtPremium_TextChanged(object sender, EventArgs e)
        {
            TaskControl.Cyber taskControl = (TaskControl.Cyber)Session["TaskControl"];
            if (TxtPremium.Text != "" && TxtPremium.Text != (taskControl.TotalPremium).ToString())
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

        public static void AddChargePartialPayments(TaskControl.Cyber taskControl)
        {
            DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[12];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
            SqlDbType.Int, 0, taskControl.TaskControlID.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PaymentDate",
            SqlDbType.SmallDateTime, 0, DateTime.Now.ToShortDateString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("TransactionAmount",
            SqlDbType.Money, 0, taskControl.Charge.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CheckNumber",
            SqlDbType.Char, 10, "Inception Charge",
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CreditDebitID",
            SqlDbType.Int, 0, "2",
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("TransactionDate",
            SqlDbType.DateTime, 0, DateTime.Now.ToShortDateString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CommissionAgency",
            SqlDbType.Float, 0, "0",
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CommissionPrem",
            SqlDbType.Float, 0, "0",
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("License",
            SqlDbType.Bit, 0, "false",
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyClass",
            SqlDbType.Int, 0, taskControl.PolicyClassID.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PaymentReference",
            SqlDbType.VarChar, 30, "Inception",
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("TaskPaymentID",
            SqlDbType.Int, 0, "0",
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
                dt = exec.GetQuery("AddChargePartialPayments", xmlDoc);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }

        }

        private void UpdateInceptionChargePartialPayments(int taskControlID, double totprem)
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
            System.Data.DataTable dt = null;
            try
            {
                exec.Update("UpdateInceptionChargePartialPayments", xmlDoc);
            }
            catch (Exception ex)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Could not update Partial Payment.");
                this.litPopUp.Visible = true;
                //throw new Exception("Could not update Partial Payment.", ex);
            }
        }
        private void EndorsementControl(bool Enable)
        {
            lblDatePrepared.Enabled = Enable;
            txtDatePrepared.Enabled = Enable;
            lblEndoEffDate.Enabled = Enable;
            txtEndoEffDate.Enabled = Enable;
            lblEndoRetroDate.Enabled = Enable;
            txtRetroEffDate.Enabled = Enable;
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
            lblEndoRetroDate.Visible = Enable;
            txtRetroEffDate.Visible = Enable;
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
