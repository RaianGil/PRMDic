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
using Spire.Doc;
using Spire.Doc.Documents;


namespace EPolicy
{
    public partial class LaboratoryApplication1 : System.Web.UI.Page
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
                Banner = LoadControl(@"TopBanner1.ascx");
                this.Placeholder1.Controls.Add(Banner);

                /*//Setup Left-side Banner			
                Control LeftMenu = new Control();
                LeftMenu = LoadControl(@"LeftMenu.ascx");
                phTopBanner1.Controls.Add(LeftMenu);*/

                if (Session["AutoPostBack"] == null)
                {
                    if (!IsPostBack)
                    {
                        

                        if (Session["TaskControl"] != null)
                        {
                            EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];

                            TxtTerm.Attributes.Add("onblur", "getExpDt()");
                            TxtTerm.Attributes.Add("onchange", "getExpDt()");

                            txtEffDt.Attributes.Add("onblur", "getExpDt()");
                            txtEffDt.Attributes.Add("onchange", "getExpDt()");

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

                            //City
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
                            //ddlMainSpecialty.Items.Add(new ListItem("Medical or X-Ray Laboratory", "1"));

                            ddlMainSpecialty.Items.Clear();
                            ddlMainSpecialty.Items.Add(new ListItem("Clinical Laboratory", "138"));
                            ddlMainSpecialty.Items.Add(new ListItem("Imaging Center", "139"));

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

                            ddlPrMedicalLimits.Items.Clear();
                            if (taskControl.TaskControlID == 62701)
                            {
                                ddlPrMedicalLimits.Items.Add(new ListItem("", "0"));
                                ddlPrMedicalLimits.Items.Add(new ListItem("100,000/300,000", "1"));
                                ddlPrMedicalLimits.Items.Add(new ListItem("250,000/500,000", "2"));
                                ddlPrMedicalLimits.Items.Add(new ListItem("500,000/1,000,000", "3"));
                                ddlPrMedicalLimits.Items.Add(new ListItem("500,000/1,500,000", "4"));
                                ddlPrMedicalLimits.Items.Add(new ListItem("1,000,000/3,000,000", "5"));
                            }
                            else
                            {
                                ddlPrMedicalLimits.Items.Add(new ListItem("", "0"));
                                ddlPrMedicalLimits.Items.Add(new ListItem("100,000/300,000", "1"));
                                ddlPrMedicalLimits.Items.Add(new ListItem("250,000/500,000", "2"));
                                ddlPrMedicalLimits.Items.Add(new ListItem("500,000/1,000,000", "3"));
                                ddlPrMedicalLimits.Items.Add(new ListItem("1,000,000/3,000,000", "4"));
                            }


                            if (taskControl.PolicyType.Trim() == "CLE")
                                ddlPrMedicalLimits.Items.Remove(ddlPrMedicalLimits.Items.FindByValue("1"));
                            

                            

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
                                    EnableControl();
                                    FillTextControl();
                                    break;

                                case 2: //UPDATE
                                    DisableControl();
                                    FillTextControl();

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
                                    }
                                    break;

                                default:
                                    DisableControl();
                                    FillTextControl();
                                    FillGrid();
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    FillTextControl();
                    EnableControl();
                    FillGrid();
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
                EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
                Login.Login cp = HttpContext.Current.User as Login.Login;
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                lblTCID.Text = taskControl.TaskControlID.ToString();
                TxtFirstName.Text = taskControl.Customer.FirstName.Trim();
                //TxtProspectNo.Text = taskControl.Customer.ProspectID.ToString(); //Lo pidieron para ver el Prospect ID en las Polizas.
                txtLastname1.Text = taskControl.Customer.LastName1.Trim();
                txtLastname2.Text = taskControl.Customer.LastName2.Trim();
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
                 if (taskControl.TaskControlID == 50203)
                    LblStatus.Text = "Inforce/Paid";
                

                ChkAutoAssignPolicy.Checked = taskControl.AutoAssignPolicy;
                TxtPolicyNo.Text = taskControl.PolicyNo.Trim();
                TxtCertificate.Text = taskControl.Certificate.Trim();
                TxtPolicyType.Text = taskControl.PolicyType.Trim();
                TxtSufijo.Text = taskControl.Suffix.Trim();
                TxtAnniversary.Text = taskControl.Anniversary.Trim();
                TxtTerm.Text = taskControl.Term.ToString().Trim();
                TxtRetroactiveDate.Text = taskControl.RetroDate;//taskControl.RetroactiveDate.Trim();
                txtEffDt.Text = taskControl.EffectiveDate.Trim();

                if (taskControl.CancellationDate == String.Empty)
                    txtExpDt.Text = taskControl.ExpirationDate.Trim();
                else
                {
                    txtExpDt.Text = taskControl.CancellationDate;
                    lblExpDate.Text = "Canc. Date";
                }

                txtEntryDate.Text = taskControl.EntryDate.ToShortDateString().ToString().Trim();

                if (taskControl.Coverage != null)
                    txtCoverage.Text = taskControl.Coverage.Trim();
                else
                    txtCoverage.Text = "";

                if (taskControl.Code != null)
                    txtCode.Text = taskControl.Code.Trim();
                else
                    txtCode.Text = "";

                txtEstGrossReceipt.Text = taskControl.EstimatedGrossReceipts.ToString("###,###.00").Trim();
                TxtCharge.Text = taskControl.Charge.ToString("###,###.00").Trim();
                //TxtPremium.Text = taskControl.TotalPremium.ToString("###,###.00").Trim();
                TxtPremium.Text = taskControl.Premium.ToString("###,###.00").Trim();
                TxtCancAmount.Text = taskControl.CancellationAmount.ToString("###,###.00").Trim();
                TxtTotalPremium.Text = (double.Parse(TxtCharge.Text) + taskControl.Premium - double.Parse(TxtCancAmount.Text)).ToString("###,###,##0.00");
                //TxtTotalPremium.Text = taskControl.TotalPremium.ToString("###,###.00").Trim();

                ddlPrMedicalLimits.SelectedIndex = ddlPrMedicalLimits.Items.IndexOf(ddlPrMedicalLimits.Items.FindByValue(taskControl.LimitsID.ToString().Trim()));
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
                ddlOtherSpecialtyA.SelectedIndex = ddlOtherSpecialtyA.Items.IndexOf(ddlOtherSpecialtyA.Items.FindByValue(taskControl.OtherSpecialtyID.ToString().Trim()));
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
                    txtNumberOfEmployees.Text = taskControl.NumberOfEmployees.Trim();

                if (taskControl.Comment == null)
                    TxtComments.Text = "";
                else
                    TxtComments.Text = taskControl.Comment.Trim();

                _TotalPremium1.Value = taskControl.TotalPremium1.ToString();
                _TotalPremium2.Value = taskControl.TotalPremium2.ToString();
                _TotalPremium3.Value = taskControl.TotalPremium3.ToString();
                _TotalPremium4.Value = taskControl.TotalPremium4.ToString();
                _Factor.Value = taskControl.Factor.ToString();

                FillEndorsementGrid();

                btnEnablePrint.Visible = taskControl.PrintPolicy;

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

                if (DtComment.Rows.Count > 0 && taskControl.TaskControlID != 0)//aqui
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
                EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
                Login.Login cp = HttpContext.Current.User as Login.Login;
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                // Section Customer
                taskControl.Customer.CustomerNo = TxtCustomerNo.Text.Trim();
                taskControl.Customer.FirstName = TxtFirstName.Text.ToString().Trim().ToUpper();
                taskControl.Customer.LastName1 = txtLastname1.Text.ToString().Trim().ToUpper();
                taskControl.Customer.LastName2 = txtLastname2.Text.ToString().Trim().ToUpper();
                taskControl.Customer.Initial = TxtInitial.Text.ToString().Trim().ToUpper();
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
                taskControl.Comment = TxtComments.Text.ToString().Trim();
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

                if (ddlOtherSpecialtyA.SelectedItem.Value != "" && ddlOtherSpecialtyA.SelectedItem.Value != null)
                {
                    taskControl.OtherSpecialtyID = int.Parse(ddlOtherSpecialtyA.SelectedItem.Value.ToString().Trim());
                    taskControl.OtherSpecialtyDesc = ddlOtherSpecialtyA.SelectedItem.Text.ToString().Trim();
                }
                else
                {
                    taskControl.OtherSpecialtyID = 0;
                    taskControl.OtherSpecialtyDesc = "";
                }

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

                if (ddlPrMedicalLimits.SelectedItem.Value != "" && ddlPrMedicalLimits.SelectedItem.Value != null)
                {
                    if (int.Parse(ddlPrMedicalLimits.SelectedItem.Value.ToString().Trim()) < taskControl.LimitsID)
                        taskControl.limitReduced = true;

                    taskControl.LimitsID = int.Parse(ddlPrMedicalLimits.SelectedItem.Value.ToString().Trim());
                    taskControl.LimitsDesc = ddlPrMedicalLimits.SelectedItem.Text.ToString().Trim();

                    
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

                if (TxtPremium.Text.ToString().Trim() != "") //if (TxtTotalPremium.Text.ToString().Trim() != "")
                    taskControl.TotalPremium = double.Parse(TxtPremium.Text.ToString().Trim());//double.Parse(TxtTotalPremium.Text.ToString().Trim());
                else
                    taskControl.TotalPremium = 0;

                if (TxtCancAmount.Text.ToString().Trim() != "")
                    taskControl.CancellationAmount = double.Parse(TxtCancAmount.Text.ToString().Trim());
                else
                    taskControl.CancellationAmount = 0;
                
                taskControl.SupplierID = "000";

                taskControl.Code = txtCode.Text.Trim();
                taskControl.Coverage = txtCoverage.Text.Trim();

                taskControl.TotalPremium1 = double.Parse(_TotalPremium1.Value.ToString().Trim());
                taskControl.TotalPremium2 = double.Parse(_TotalPremium2.Value.ToString().Trim());
                taskControl.TotalPremium3 = double.Parse(_TotalPremium3.Value.ToString().Trim());
                taskControl.TotalPremium4 = double.Parse(_TotalPremium4.Value.ToString().Trim());
                taskControl.Factor = double.Parse(_Factor.Value.ToString().Trim());

                Session["TaskControl"] = taskControl;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void EnableControl()
        {
            EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
            Login.Login cp = HttpContext.Current.User as Login.Login;
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

            bool visible = false;
            bool enabled = true;

            // btn Control visible false
            btnAddNew.Visible = visible;
            btnCancellation.Visible = visible;
            btnComissions.Visible = visible;
            btnConvertExcess.Visible = visible;
            btnConvertPrimary.Visible = visible;
            //btnConvertExcess.Visible = visible;
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

            if (taskControl.IsPolicy)
                visible = true;

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
            //prueba Gap
            txtGapBegDate.Enabled = true;
            txtGapBegDate2.Enabled = true;
            txtGapBegDate3.Enabled = true;
            txtGapEndDate.Enabled = true;
            txtGapEndDate2.Enabled = true;
            txtGapEndDate3.Enabled = true;
            txtNumberOfEmployees.Enabled = true;
            lblTerm.Visible = visible;
            //lblRetro.Visible = visible;
            lblEntryDate.Visible = visible;
            lblEffDate.Visible = visible;

            lblExpDate.Visible = visible;

            Label77.Visible = visible;
            rblClaim.Visible = visible;
            lblClaimNo.Visible = visible;
            txtClaimNumber.Visible = visible;

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

            if (taskControl.Anniversary == "01" && taskControl.IsPolicy && taskControl.Mode == 1)
            {
                lblPriorAct.Visible = visible;
                ddlPriorAct.Visible = visible;
            }
            else
            {
            }

            // btn Control visible true
            visible = true;
            BtnSave.Visible = visible;
            cmdCancel.Visible = visible;
            BtnExit.Visible = visible;
            btnCalculatePremium.Visible = visible;

            // disable control Enabled=true
            TxtFirstName.Enabled = enabled;
            txtHomePhone.Enabled = enabled;
            TxtInitial.Enabled = enabled;
            txtLastname1.Enabled = enabled;
            txtLastname2.Enabled = enabled;
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
            txtEstGrossReceipt.Enabled = enabled;

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
            ddlOtherSpecialtyA.Enabled = enabled;
            ddlOtherSpecialtyB.Enabled = enabled;
            ddlPrMedicalLimits.Enabled = true;
            ddlSelectedAgent.Enabled = enabled;
            ddlPriorAct.Enabled = enabled;

            rblClaim.Enabled = enabled;

            txtCode.Enabled = enabled;
            txtCoverage.Enabled = enabled;

            // if (taskControl.isEndorsement)
            //    ShowEndorsementSection(true);
            //else
            //    ShowEndorsementSection(false);

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

        private void DisableControl()
        {
            EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
            Login.Login cp = HttpContext.Current.User as Login.Login;
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

            bool visible = true;
            bool enabled = false;
            
            // btn Control visible true

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
                btnConvertExcess.Visible = visible;
                btnConvertPrimary.Visible = visible;
               // btnConvertExcess.Visible = visible;
                btnEnablePrint.Visible = visible;
                //btnTailQuote.Visible = visible;
                btnCalculatePremium.Visible = visible;
                BtnSave.Visible = visible;

                if (!taskControl.isEndorsement)
                    pnlEndorsement.Visible = visible;

                lblPriorAct.Visible = visible;
                ddlPriorAct.Visible = visible;

            
            }
            else
            {
                btnPrint.Visible = visible;
                btnConvertPrimary.Visible = visible;
                btnConvertExcess.Visible = visible;
                btnEdit.Visible = visible;
                BtnExit.Visible = visible;
                cmdCancel.Visible = visible;
                btnAddNew.Visible = visible;

                visible = false;
                btnAddNew.Visible = visible;
                BtnSave.Visible = visible;
                btnCancellation.Visible = visible;
                btnComissions.Visible = visible;
                //btnConvertExcess.Visible = visible;
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

            //prueba Gap
            txtGapBegDate.Enabled = visible;
            txtGapBegDate2.Enabled = visible;
            txtGapBegDate3.Enabled = visible;
            txtGapEndDate.Enabled = visible;
            txtGapEndDate2.Enabled = visible;
            txtGapEndDate3.Enabled = visible;
            txtNumberOfEmployees.Enabled = visible;
            TxtFirstName.Enabled = enabled;
            txtHomePhone.Enabled = enabled;
            TxtInitial.Enabled = enabled;
            txtLastname1.Enabled = enabled;
            txtLastname2.Enabled = enabled;
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
            txtEstGrossReceipt.Enabled = enabled;

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
            ddlOtherSpecialtyA.Enabled = enabled;
            ddlOtherSpecialtyB.Enabled = enabled;
            ddlPrMedicalLimits.Enabled = enabled;
            ddlSelectedAgent.Enabled = enabled;
            ddlPriorAct.Enabled = enabled;

            txtCode.Enabled = enabled;
            txtCoverage.Enabled = enabled;

            rblClaim.Enabled = enabled;

            if (taskControl.IsPolicy)
            {
                VerifyAccess();
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
            TaskControl.Laboratory taskControl = (TaskControl.Laboratory)Session["TaskControl"];

            Login.Login cp = HttpContext.Current.User as Login.Login;

            //Se Agregó condición de BTNHISTORYLABORATORY en LaboratoryApplication1.aspx.cs

            if (cp.IsInRole("BTNHISTORYLABORATORY"))
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
                if (!cp.IsInRole("BTNCONVERTPRIMARYLABORATORY") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    this.btnConvertPrimary.Visible = false;
                    this.btnConvertExcess.Visible = false;
                }
                else
                {
                    this.btnConvertPrimary.Visible = true;
                    this.btnConvertExcess.Visible = true;
                }

                //if (!cp.IsInRole("BTNCONVERTLABORATORY") && !cp.IsInRole("ADMINISTRATOR"))
                //{
                //    this.btnConvertExcess.Visible = false;
                //}
                //else
                //{
                //    this.btnConvertExcess.Visible = true;
                //}
            }
            if (!cp.IsInRole("SUBSCRIPTION") && !cp.IsInRole("ADMINISTRATOR"))
            {
                btnEnablePrint.Visible = false;
            }
            else
            {
                btnEnablePrint.Visible = true;
            }

            if (!cp.IsInRole("BTNPAYMENTLABORATORY"))
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

            else
            {
                this.btnPayments.Visible = true;
                this.btnComissions.Visible = true;
            }

            //if (!cp.IsInRole("BTNPAYMENTLAB") && !cp.IsInRole("ADMINISTRATOR"))
            //{
            //    this.btnPayments.Visible = false;
            //}
            //else 
            //{
            //    this.btnPayments.Visible = true;
            //}

            /*if (!cp.IsInRole("BTNPRINTLAB") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnPrint.Visible = false;
            }
            else 
            {
                this.btnPrint.Visible = true;
            }*/
            
            //Power Agent no lo tiene
            if (!cp.IsInRole("BTNCANCELLATIONLABORATORY") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnCancellation.Visible = false;
                this.btnFinancialCanc.Visible = false;
            }
            else
            {
                this.btnCancellation.Visible = true;
                this.btnFinancialCanc.Visible = true;
            }

            //Se agregó función de condición en los botones con Reinstatement Laboratory BTNREINSTATEMENTLABORATORY
            if (!cp.IsInRole("BTNREINSTATEMENTLABORATORY") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnReinstatement.Visible = false;
            }
            else
            {
                this.btnReinstatement.Visible = true;
            }

            
            if (!cp.IsInRole("BTNDELETELABORATORY") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnDelete.Visible = false;
            }
            else
            {
                this.btnDelete.Visible = true;
            }

            if (!cp.IsInRole("BTNADDLABORATORY") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnAddNew.Visible = false;
            }
            else
            {
                this.btnAddNew.Visible = true;
            }

            if (!cp.IsInRole("BTNEDITLABORATORY") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnEdit.Visible = false;
            }
            else
            {
                this.btnEdit.Visible = true;
            }

            if (!cp.IsInRole("BTNPRINTLABORATORY") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnPrint.Visible = false;
            }
            else
            {
                this.btnPrint.Visible = true;
            }

            if (!cp.IsInRole("BTNRENEWLABORATORY") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnRenew.Visible = false;
            }
            else
            {
                this.btnRenew.Visible = true;
            }
            /*if (userID != 1 && userID != 13 && userID != 156 && userID != 240 && userID != 2 && userID != 238)
            {
                this.btnEnablePrint.Visible = false;
            }
            else
            {
                this.btnEnablePrint.Visible = taskControl.PrintPolicy;
            }*/

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

            //if (!cp.IsInRole("BTNSAVECORPORATE") && !cp.IsInRole("ADMINISTRATOR"))
            //{
            //    this.BtnSave.Visible = false;
            //}
            //else
            //{
            //    this.BtnSave.Visible = true;
            //}


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
            if (cp.IsInRole("ACCOUNTING REPORTING"))
            {
                this.btnTailQuote.Visible = false;
            }
            if (cp.IsInRole("ACCOUNTING") && taskControl.CancellationDate != "")
            {
                btnPrint.Visible = true;
            }
            if (userID == 270) //Override para Hadasha Alamo. 
            {
                btnEnablePrint.Visible = true;
            }
        }
        #endregion

        // Ocultar controles que no se van a utilizar
        private void HideControl()
        {
            EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
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
            ddlOtherSpecialtyA.Visible = visible;
            ddlOtherSpecialtyB.Visible = visible;
            lblOtherSpecialty.Visible = visible;
            lblOtherSpecialty0.Visible = visible;
            //Label60.Visible = visible;
            //TxtCharge.Visible = visible;
            TxtCancAmount.Visible = visible;
            TxtPremium.Visible = visible;
            lblPremium0.Visible = visible;
            lblPremum.Visible = visible;
            btnCalcCharge.Visible = visible;
            //btnCalcCharge.Visible = true;
            ChkAutoAssignPolicy.Visible = visible;
            //btnTailQuote.Visible = visible;
            //btnPrintCertificate.Visible = visible;

            btnPolicyCert.Visible = visible;
           
            //if (taskControl.CancellationAmount != 0)
            //{
                lblPremium0.Visible = true;
                TxtCancAmount.Visible = true;
                TxtPremium.Visible = true;
                lblPremum.Visible = true;
            //}
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
            //lblCertificate.Visible = isPolicy;
            //TxtCertificate.Visible = isPolicy;
            //TxtPolicyNo.Visible = isPolicy;
            //lblPolicyNo.Visible = isPolicy;
            //lblPolicyType.Visible = isPolicy;
            //TxtPolicyType.Visible = isPolicy;
            //TxtSufijo.Visible = isPolicy;
            //lblAnniversary.Visible = isPolicy;
            //TxtAnniversary.Visible = isPolicy;
            //lblSufijo.Visible = isPolicy;
            ChkAutoAssignPolicy.Enabled = isPolicy;
            ChkAutoAssignPolicy.Checked = isPolicy;

            lblHomePhone.Visible = false;
            txtHomePhone.Visible = false;
            //txtLicense.Visible = isPolicy;
            //Label51.Visible = isPolicy;
            //rblClaim.Visible = isPolicy;
            //lblClaimNo.Visible = isPolicy;
            //Label77.Visible = isPolicy;
            //txtClaimNumber.Visible = isPolicy;
            //lblFinancial.Visible = isPolicy;
            //ddlFinancial.Visible = isPolicy;
        }
        private bool ValidateField()
        {
            try
            {
                EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
                bool process = true;

                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = 0;
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
                if (TxtRetroactiveDate.Text.Trim() == "")
                    errorMessage.Add("The Retro Date is missing or wrong.");
                if (txtEffDt.Text.Trim() == "")
                    errorMessage.Add("The Effective Date is missing or wrong.");
                if (txtExpDt.Text.Trim() == "")
                    errorMessage.Add("The Expiration Date is missing or wrong.");
                if (txtEntryDate.Text.Trim() == "")
                    errorMessage.Add("The Entry Date is missing or wrong.");
                if (ddlPrMedicalLimits.SelectedItem.Value == "" && ddlPrMedicalLimits.SelectedItem.Value == null)
                    errorMessage.Add("The Limit is missing or wrong.");
				if (ddlAgent.SelectedItem.Value.Trim() == "000")
                    errorMessage.Add("Please choose a agent.");

                 else if (ddlAgent.SelectedItem.Value.Trim() == "")
                    errorMessage.Add("Please choose a agent.");
                double _temp = 0;                

                if (!(double.TryParse(txtEstGrossReceipt.Text.Trim(), out _temp)))
                    errorMessage.Add("The Estiated Gross Receipts is missing or wrong");
                else
                { if (_temp <= 0) errorMessage.Add("The Estimated Gross Receipts could no be less than 0."); }

                if (!(double.TryParse(TxtTotalPremium.Text.Trim(), out _temp)))
                    errorMessage.Add("The Total Premium is missing or wrong");
                else
                { if (_temp <= 0) errorMessage.Add("The Total Premium could no be less than 0."); }

                if (taskControl.IsPolicy)
                {
                    if (TxtPolicyNo.Text.Trim() == "")
                        errorMessage.Add("The Policy No. is missing or wrong");

                    if ((rblClaim.SelectedIndex != -1))
                    {
                        if (rblClaim.SelectedItem.Value.Trim() == "0")
                        {
                            if (txtClaimNumber.Text.Trim() == "")
                                errorMessage.Add("The Claim No is missing or wrong");
                        }
                    }
                }


                if (taskControl.IsPolicy) 
                {
                    DtTaskPolicy = TaskControl.Policy.GetPolicies(taskControl.PolicyClassID, TxtPolicyType.Text.Trim(),
                        TxtPolicyNo.Text.Trim(), TxtCertificate.Text.Trim(), TxtSufijo.Text.Trim(),
                        "", "", userID);

                    if (DtTaskPolicy.Rows.Count > 0 && !taskControl.isEndorsement && taskControl.Mode == 1)
                        errorMessage.Add("Policy Number already exists." + "\r\n"); 
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
            if (Session["TaskControl"] != null)
            {
                TaskControl.Laboratory taskControl = (TaskControl.Laboratory)Session["TaskControl"];
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
                                        totalpremium = double.Parse(TxtPremium.Text.Trim()); 
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
                                if (TxtPremium.Text != "")
                                    totalpremium = double.Parse(TxtPremium.Text.Trim()); 
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
            //double[] Factor = { 0, 1.83, 2.19, 2.48, 3.06 };

            //int valueLimit = 0;

            //if (ddlPrMedicalLimits.SelectedItem.Value.Trim() != null && ddlPrMedicalLimits.SelectedItem.Value.Trim() != "")
            //{
            //    valueLimit = int.Parse(ddlPrMedicalLimits.SelectedItem.Value.Trim());
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

            //        //switch (TxtAnniversary.Text.Trim())
            //        //{

            //        //    case "01":
            //        //        _p = 0.60; // = 60%
            //        //        _premiumTemp = _premiumTemp * _p;
            //        //        break;
            //        //    case "02":
            //        //        _p = 0.80; // = 80%
            //        //        _premiumTemp = _premiumTemp * _p;
            //        //        break;
            //        //    case "03":
            //        //        _p = 0.90; // = 90%
            //        //        _premiumTemp = _premiumTemp * _p;
            //        //        break;
            //        //    default:
            //        //        _p = 1;
            //        //        _premiumTemp = _premiumTemp * _p;
            //        //        break;
            //        //}

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

        public void ShowMessage(string Message)
        {
            ClientScriptManager script = this.Page.ClientScript;
            if (!script.IsClientScriptBlockRegistered(this.GetType(), "Alert"))
            {
                script.RegisterClientScriptBlock(this.GetType(), "Alert", "<script type=text/javascript>alert('" + Message + "')</script>");
            }
        }
        private List<string> WriteRdlcToPDF(ReportViewer viewer, EPolicy.TaskControl.Laboratory taskControl, List<string> mergePaths, int index)
        {
                    Warning[] warnings = null;
                    string[] streamIds = null;
                    string mimeType = string.Empty;
                    string encoding = string.Empty;
                    string extension = string.Empty;
                    string filetype = string.Empty;


                    string fileName1 = "FileNo-" + index.ToString();
                    string _FileName1 = "FileNo-" + index.ToString()+ ".pdf";

                    if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName1))
                        File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName1);

                    byte[] bytes1 = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                    using (FileStream fs1 = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName1, FileMode.Create))
                    {
                        fs1.Write(bytes1, 0, bytes1.Length);
                    }

                    try
                    {
                        mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName1);
                    }
                    catch (Exception ecp)
                    {
                        ShowMessage(ecp.Message);
                        
                    }
                    return mergePaths;
        }
        protected void btnConvertPrimary_Click(object sender, EventArgs e)
        {
            EPolicy.TaskControl.Laboratory taskControlOld = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
            EPolicy.TaskControl.Laboratory taskControlNew = new EPolicy.TaskControl.Laboratory(true);
            taskControlNew = taskControlOld;
            taskControlNew.IsPolicy = true;
            taskControlNew.TaskControlTypeID = 20;
            //taskControlNew.TaskControlID = 0;
            taskControlNew.Mode = 1; //Add
            //taskControlNew._Mode = 1;
            if (taskControlNew.InsuranceCompany == "002")
                taskControlNew.PolicyType = "ALP";
            else
                taskControlNew.PolicyType = "CLP";
            taskControlNew.PolicyClassID = 17;
            taskControlNew.EntryDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            taskControlNew.Term = 12;

            convert = true;

            Session.Clear();
            Session.Add("TaskControl", taskControlNew);
            Response.Redirect("LaboratoryApplication1.aspx",true);
        }
        protected void btnConvertExcess_Click(object sender, EventArgs e)
        {
            EPolicy.TaskControl.Laboratory taskControlOld = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
            EPolicy.TaskControl.Laboratory taskControlNew = new EPolicy.TaskControl.Laboratory(true);
            taskControlNew = taskControlOld;
            taskControlNew.IsPolicy = true;
            taskControlNew.TaskControlTypeID = 20;
            //taskControlNew.TaskControlID = 0;
            taskControlNew.Mode = 1; //Add
            //taskControlNew._Mode = 1;
            if (taskControlNew.InsuranceCompany == "002")
                taskControlNew.PolicyType = "ALE";
            else
                taskControlNew.PolicyType = "CLE";
            taskControlNew.PolicyClassID = 17;
            taskControlNew.EntryDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            taskControlNew.Term = 12;

            convert = true;

            Session.Clear();
            Session.Add("TaskControl", taskControlNew);
            Response.Redirect("LaboratoryApplication1.aspx", true);
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //TaskControl.Policies policy = (TaskControl.Policies)Session["TaskControl"];
                EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
                Login.Login cp = HttpContext.Current.User as Login.Login;
                string userName = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();
                string limit = ddlPrMedicalLimits.SelectedItem.Text.ToString().Trim();

                if (taskControl.Customer.FirstName.ToUpper().Contains("Ñ") || taskControl.Customer.LastName1.ToUpper().Contains("Ñ") || taskControl.Customer.LastName2.ToUpper().Contains("Ñ"))
                {
                    taskControl.Customer.FirstName = taskControl.Customer.FirstName.Replace("Ñ", "N");
                    taskControl.Customer.LastName1 = taskControl.Customer.LastName1.Replace("Ñ", "N");
                    taskControl.Customer.LastName2 = taskControl.Customer.LastName2.Replace("Ñ", "N");
                }

                List<string> mergePaths = new List<string>();
                string ProcessedPath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"];
                //EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
                string PathReport = MapPath("Reports/Laboratory/");
                string PathReportNew = MapPath("Reports/");
                string FileNamePdf = "";
                string PathReportAspen = MapPath("Reports/AspenLab/");
                if (taskControl.IsPolicy)
                {
                    //Cancelation Region
                    #region Cancellation
                    if (taskControl.CancellationDate != String.Empty && !taskControl.PolicyType.Trim().Contains("T"))
                    {
                        try
                        {

                        ReportViewer viewer = new ReportViewer();
                        viewer.LocalReport.ReportPath = Server.MapPath("Reports/LabCancellationCredit.rdlc");
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

                        if (taskControl.Charge > 0)
                        {
                            //mergePaths.Add(PrintWordProcessedPath("PolicyType = 'ALL' and FormName = 'ENDOSO DERRAMAS'", false));
                            var currentApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath.ToString();
                            string fullFilePath = currentApplicationPath + "Reports\\Word\\Files\\CN-2021-299-D_ENDOSO_DERRAMAS.pdf";
                            string copyToPath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + "CN-2021-299-D_ENDOSO_DERRAMAS.pdf";
                            File.Copy(fullFilePath, copyToPath, true);
                            mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + "CN-2021-299-D_ENDOSO_DERRAMAS.pdf");
                        }
              

                        mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 0);

                        //viewer = new ReportViewer();
                        //viewer.LocalReport.DataSources.Clear();
                        //viewer.ProcessingMode = ProcessingMode.Local;
                        //viewer.LocalReport.ReportPath = Server.MapPath("Reports/ExtendedReportingPeriodQuote.rdlc");
                        //viewer.LocalReport.SetParameters(param);
                        //viewer.LocalReport.Refresh();
                        // mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 1);

                        EPolicy.CreatePDFBatch mergeFinal = new EPolicy.CreatePDFBatch();
                        string FinalFile = "";
                        DateTime Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl.PolicyType.ToString() + " " + taskControl.PolicyNo.ToString() + " Cancellation Credit " + "" + DateTime.Now.ToShortDateString().Replace('/', '-') + "" );
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/"  + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);

                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + _FileName + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                    #endregion
                    //Check Permition User
                    else if (!taskControl.PrintPolicy && taskControl.Anniversary == "01")
                    {
                        #region Laboratory
                        if (taskControl.PolicyType.Trim() == "CLP" || taskControl.PolicyType.Trim() == "CLE")
                        {
                            FileNamePdf = "Lab - Cover Page.pdf";
                            DeleteFile(ProcessedPath + FileNamePdf);
                            FileInfo file = new FileInfo(PathReport + FileNamePdf);
                            file.CopyTo(ProcessedPath + FileNamePdf);
                            mergePaths.Add(ProcessedPath + FileNamePdf);

                            GetReportLaboratoryPolicyTableAdapters.GetReportLaboratoryPolicyTableAdapter ds = new GetReportLaboratoryPolicyTableAdapters.GetReportLaboratoryPolicyTableAdapter();
                            ReportDataSource rpd = new ReportDataSource("GetReportLaboratoryPolicy_GetReportLaboratoryPolicy", (DataTable)ds.GetData(taskControl.TaskControlID));

                            ReportViewer viewer = new ReportViewer();
                            viewer.LocalReport.DataSources.Clear();
                            viewer.ProcessingMode = ProcessingMode.Local;
                            viewer.LocalReport.ReportPath = PathReport + "LPL0031.rdlc";
                            viewer.LocalReport.DataSources.Add(rpd);
                            viewer.LocalReport.Refresh();
                            mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 0);

                            viewer = new ReportViewer();
                            viewer.LocalReport.DataSources.Clear();
                            viewer.ProcessingMode = ProcessingMode.Local;
                            viewer.LocalReport.ReportPath = PathReport + "LPL0031-2.rdlc";
                            viewer.LocalReport.DataSources.Add(rpd);
                            viewer.LocalReport.Refresh();
                            mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 1);

                            FileNamePdf = "PL-001-1.pdf";
                            DeleteFile(ProcessedPath + FileNamePdf);
                            file = new FileInfo(PathReport + FileNamePdf);
                            file.CopyTo(ProcessedPath + FileNamePdf);
                            mergePaths.Add(ProcessedPath + FileNamePdf);

                            viewer = new ReportViewer();
                            viewer.LocalReport.DataSources.Clear();
                            viewer.ProcessingMode = ProcessingMode.Local;
                            viewer.LocalReport.ReportPath = PathReport + "PL-001-2.rdlc";
                            viewer.LocalReport.DataSources.Add(rpd);
                            viewer.LocalReport.Refresh();
                            mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 2);

                            FileNamePdf = "HPL -002 Hospital Professional Liability Insurance.pdf";
                            DeleteFile(ProcessedPath + FileNamePdf);
                            file = new FileInfo(PathReport + FileNamePdf);
                            file.CopyTo(ProcessedPath + FileNamePdf);
                            mergePaths.Add(ProcessedPath + FileNamePdf);

                            FileNamePdf = "LPL - 003.2 P.R. Mandatory Endorsement.pdf";
                            DeleteFile(ProcessedPath + FileNamePdf);
                            file = new FileInfo(PathReport + FileNamePdf);
                            file.CopyTo(ProcessedPath + FileNamePdf);
                            mergePaths.Add(ProcessedPath + FileNamePdf);

                            FileNamePdf = "LPL – 003.3 Continuous Renewal Endorsement.pdf";
                            DeleteFile(ProcessedPath + FileNamePdf);
                            file = new FileInfo(PathReport + FileNamePdf);
                            file.CopyTo(ProcessedPath + FileNamePdf);
                            mergePaths.Add(ProcessedPath + FileNamePdf);

                            FileNamePdf = "LPL – 003.4  Statement of Representation and Acceptance.pdf";
                            DeleteFile(ProcessedPath + FileNamePdf);
                            file = new FileInfo(PathReport + FileNamePdf);
                            file.CopyTo(ProcessedPath + FileNamePdf);
                            mergePaths.Add(ProcessedPath + FileNamePdf);

                            FileNamePdf = "Medical or X-Ray Laboratories LPL-003.pdf";
                            DeleteFile(ProcessedPath + FileNamePdf);
                            file = new FileInfo(PathReport + FileNamePdf);
                            file.CopyTo(ProcessedPath + FileNamePdf);
                            mergePaths.Add(ProcessedPath + FileNamePdf);


                            if (taskControl.limitReduced)
                            {
                                // Limited Prior Acts
                                viewer = new ReportViewer();
                                viewer.LocalReport.DataSources.Clear();
                                viewer.ProcessingMode = ProcessingMode.Local;
                                viewer.LocalReport.ReportPath = PathReport + "LOL0039.rdlc";
                                viewer.LocalReport.DataSources.Add(rpd);
                                viewer.LocalReport.Refresh();
                                mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 3);
                            }
                            else
                            {
                                // Prior Acts
                                viewer = new ReportViewer();
                                viewer.LocalReport.DataSources.Clear();
                                viewer.ProcessingMode = ProcessingMode.Local;
                                viewer.LocalReport.ReportPath = PathReport + "LPL0037.rdlc";
                                viewer.LocalReport.DataSources.Add(rpd);
                                viewer.LocalReport.Refresh();
                                mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 3);
                            }

                            if (taskControl.Charge > 0)
                            {
                                //mergePaths.Add(PrintWordProcessedPath("PolicyType = 'ALL' and FormName = 'ENDOSO DERRAMAS'", false)); 
                                var currentApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath.ToString();
                                string fullFilePath = currentApplicationPath + "Reports\\Word\\Files\\CN-2021-299-D_ENDOSO_DERRAMAS.pdf";
                                string copyToPath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + "CN-2021-299-D_ENDOSO_DERRAMAS.pdf";
                                File.Copy(fullFilePath, copyToPath, true);
                                mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + "CN-2021-299-D_ENDOSO_DERRAMAS.pdf");
                            }
                           

                            if (File.Exists(ProcessedPath + taskControl.TaskControlID.ToString() + ".pdf"))
                                File.Delete(ProcessedPath + taskControl.TaskControlID.ToString() + ".pdf");

                            //Generar PDF
                            EPolicy.CreatePDFBatch mergeFinal = new EPolicy.CreatePDFBatch();
                            string FinalFile = "";
                            FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl.TaskControlID.ToString());
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                            taskControl.PrintPolicy = true;
                            btnEnablePrint.Visible = true;
                        }
                        #endregion
                        #region Aspen Laboratry
                        else if (taskControl.PolicyType.Trim() == "ALP" || taskControl.PolicyType.Trim() == "ALE")
                        {
                            //GetReportLaboratoryPolicyTableAdapters.GetReportLaboratoryPolicyTableAdapter ds = new GetReportLaboratoryPolicyTableAdapters.GetReportLaboratoryPolicyTableAdapter();
                            //ReportDataSource rpd = new ReportDataSource("GetReportLaboratoryPolicy_GetReportLaboratoryPolicy", (DataTable)ds.GetData(taskControl.TaskControlID));

                            //FileNamePdf = "COVERPAGE.pdf";
                            //DeleteFile(ProcessedPath + FileNamePdf);
                            //FileInfo file = new FileInfo(PathReportAspen + FileNamePdf);
                            //file.CopyTo(ProcessedPath + FileNamePdf);
                            //mergePaths.Add(ProcessedPath + FileNamePdf);

                            //ReportViewer viewer = new ReportViewer();
                            //viewer.LocalReport.DataSources.Clear();
                            //viewer.ProcessingMode = ProcessingMode.Local;
                            //viewer.LocalReport.ReportPath = PathReportAspen + "ASPCX001 0715 - MEDICAL OR X-RAY LABORATORIES PROFESSIONAL LIABILITY POLICY DECLARATIONSPage1.rdlc";
                            //viewer.LocalReport.DataSources.Add(rpd);
                            //viewer.LocalReport.Refresh();
                            //mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 0); // cambiar el protocolo de los numeros.

                            //viewer = new ReportViewer();
                            //viewer.LocalReport.DataSources.Clear();
                            //viewer.ProcessingMode = ProcessingMode.Local;
                            //viewer.LocalReport.ReportPath = PathReportAspen + "ASPCX001 0715 - MEDICAL OR X-RAY LABORATORIES PROFESSIONAL LIABILITY POLICY DECLARATIONSPage2.rdlc";
                            //viewer.LocalReport.DataSources.Add(rpd);
                            //viewer.LocalReport.Refresh();
                            //mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 0);

                            //FileNamePdf = "ASPCX002 1015 - PROFESSIONAL LIABILITY INSURANCE POLICY.pdf";
                            //DeleteFile(ProcessedPath + FileNamePdf);
                            //file = new FileInfo(PathReportAspen + FileNamePdf);
                            //file.CopyTo(ProcessedPath + FileNamePdf);
                            //mergePaths.Add(ProcessedPath + FileNamePdf);

                            //FileNamePdf = "ASPCX002 1015 - PROFESSIONAL LIABILITY INSURANCE POLICYPage1-8.pdf";
                            //DeleteFile(ProcessedPath + FileNamePdf);
                            //file = new FileInfo(PathReportAspen + FileNamePdf);
                            //file.CopyTo(ProcessedPath + FileNamePdf);
                            //mergePaths.Add(ProcessedPath + FileNamePdf);

                            //FileNamePdf = "ASPCX003 1015 - HOSPITAL PROFESSIONAL LIABILITY INSURANCE.pdf";
                            //DeleteFile(ProcessedPath + FileNamePdf);
                            //file = new FileInfo(PathReportAspen + FileNamePdf);
                            //file.CopyTo(ProcessedPath + FileNamePdf);
                            //mergePaths.Add(ProcessedPath + FileNamePdf);

                            //FileNamePdf = "ASPCX003 1015 - HOSPITAL PROFESSIONAL LIABILITY INSURANCEPage1-7.pdf";
                            //DeleteFile(ProcessedPath + FileNamePdf);
                            //file = new FileInfo(PathReportAspen + FileNamePdf);
                            //file.CopyTo(ProcessedPath + FileNamePdf);
                            //mergePaths.Add(ProcessedPath + FileNamePdf);

                            //viewer = new ReportViewer();
                            //viewer.LocalReport.DataSources.Clear();
                            //viewer.ProcessingMode = ProcessingMode.Local;
                            //viewer.LocalReport.ReportPath = PathReportAspen + "ASPCX004 0615 - MANDATORY PREMIUM AND COVERAGE CONDITIONS ENDORSEMENTPage1.rdlc";
                            //viewer.LocalReport.DataSources.Add(rpd);
                            //viewer.LocalReport.Refresh();
                            //mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 0);

                            //FileNamePdf = "ASPCX004 0615 - MANDATORY PREMIUM AND COVERAGE CONDITIONS ENDORSEMENTPage2-3.pdf";
                            //DeleteFile(ProcessedPath + FileNamePdf);
                            //file = new FileInfo(PathReportAspen + FileNamePdf);
                            //file.CopyTo(ProcessedPath + FileNamePdf);
                            //mergePaths.Add(ProcessedPath + FileNamePdf);

                            //viewer = new ReportViewer();
                            //viewer.LocalReport.DataSources.Clear();
                            //viewer.ProcessingMode = ProcessingMode.Local;
                            //viewer.LocalReport.ReportPath = PathReportAspen + "ASPCX007 0615 - MEDICAL OR X-RAY LABORATORIES ENDORSEMENT.rdlc";
                            //viewer.LocalReport.DataSources.Add(rpd);
                            //viewer.LocalReport.Refresh();
                            //mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 0);

                            //FileNamePdf = "ASPCX007 0615 - MEDICAL OR X-RAY LABORATORIES ENDORSEMENTPage2.pdf";
                            //DeleteFile(ProcessedPath + FileNamePdf);
                            //file = new FileInfo(PathReportAspen + FileNamePdf);
                            //file.CopyTo(ProcessedPath + FileNamePdf);
                            //mergePaths.Add(ProcessedPath + FileNamePdf);

                            //viewer = new ReportViewer();
                            //viewer.LocalReport.DataSources.Clear();
                            //viewer.ProcessingMode = ProcessingMode.Local;
                            //viewer.LocalReport.ReportPath = PathReportAspen + "ASPCX013 0615 - NUCLEAR ENERGY LIABILITY ENDORSEMENT (BROAD FORM)Page1.rdlc";
                            //viewer.LocalReport.DataSources.Add(rpd);
                            //viewer.LocalReport.Refresh();
                            //mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 0);

                            //FileNamePdf = "ASPCX013 0615 - NUCLEAR ENERGY LIABILITY ENDORSEMENT (BROAD FORM)Page2-3.pdf";
                            //DeleteFile(ProcessedPath + FileNamePdf);
                            //file = new FileInfo(PathReportAspen + FileNamePdf);
                            //file.CopyTo(ProcessedPath + FileNamePdf);
                            //mergePaths.Add(ProcessedPath + FileNamePdf);


                            //if (File.Exists(ProcessedPath + taskControl.TaskControlID.ToString() + ".pdf"))
                            //    File.Delete(ProcessedPath + taskControl.TaskControlID.ToString() + ".pdf");

                            ////Generar PDF
                            //EPolicy.CreatePDFBatch mergeFinal = new EPolicy.CreatePDFBatch();
                            //string FinalFile = "";
                            //FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl.TaskControlID.ToString());
                            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                            //taskControl.PrintPolicy = true;
                            //btnEnablePrint.Visible = true;

                            GetReportLaboratoryPolicyTableAdapters.GetReportLaboratoryPolicyTableAdapter ds = new GetReportLaboratoryPolicyTableAdapters.GetReportLaboratoryPolicyTableAdapter();
                            ReportDataSource rpd = new ReportDataSource("GetReportLaboratoryPolicy_GetReportLaboratoryPolicy", (DataTable)ds.GetData(taskControl.TaskControlID));

                            FileNamePdf = "COVERPAGE.pdf";
                            DeleteFile(ProcessedPath + FileNamePdf);
                            FileInfo file = new FileInfo(PathReportAspen + FileNamePdf);
                            file.CopyTo(ProcessedPath + FileNamePdf);
                            mergePaths.Add(ProcessedPath + FileNamePdf);

                            ReportViewer viewer = new ReportViewer();
                            viewer.LocalReport.DataSources.Clear();
                            viewer.ProcessingMode = ProcessingMode.Local;
                            viewer.LocalReport.ReportPath = PathReportAspen + "AspenPage1.rdlc";
                            viewer.LocalReport.DataSources.Add(rpd);
                            viewer.LocalReport.Refresh();
                            mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 0);

                            viewer = new ReportViewer();
                            viewer.LocalReport.DataSources.Clear();
                            viewer.ProcessingMode = ProcessingMode.Local;
                            viewer.LocalReport.ReportPath = PathReportAspen + "ASPCX001 0715 - MEDICAL OR X-RAY LABORATORIES PROFESSIONAL LIABILITY POLICY DECLARATIONSPage2.rdlc";
                            viewer.LocalReport.DataSources.Add(rpd);
                            viewer.LocalReport.Refresh();
                            mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 1);

                            //viewer = new ReportViewer();
                            //viewer.LocalReport.DataSources.Clear();
                            //viewer.ProcessingMode = ProcessingMode.Local;
                            //viewer.LocalReport.ReportPath = PathReportAspen + "ASPCX011-0615LABORATORIESRENEWALENDORSEMENT.rdlc";
                            //viewer.LocalReport.DataSources.Add(rpd);
                            //viewer.LocalReport.Refresh();
                            //mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 2);


                            //viewer = new ReportViewer();
                            //viewer.LocalReport.DataSources.Clear();
                            //viewer.ProcessingMode = ProcessingMode.Local;
                            //viewer.LocalReport.ReportPath = PathReportAspen + "renewalpage2.rdlc";
                            //viewer.LocalReport.DataSources.Add(rpd);
                            //viewer.LocalReport.Refresh();
                            //mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 3);

                            FileNamePdf = "ASPCX002 1015 - PROFESSIONAL LIABILITY INSURANCE POLICYPage1-8.pdf";
                            DeleteFile(ProcessedPath + FileNamePdf);
                            file = new FileInfo(PathReportAspen + FileNamePdf);
                            file.CopyTo(ProcessedPath + FileNamePdf);
                            mergePaths.Add(ProcessedPath + FileNamePdf);

                            viewer = new ReportViewer();
                            viewer.LocalReport.DataSources.Clear();
                            viewer.ProcessingMode = ProcessingMode.Local;
                            viewer.LocalReport.ReportPath = PathReportAspen + "Copy of MedicalPage1.rdlc";
                            viewer.LocalReport.DataSources.Add(rpd);
                            viewer.LocalReport.Refresh();
                            mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 2); //kk


                            FileNamePdf = "ASPCX003 1015 - HOSPITAL PROFESSIONAL LIABILITY INSURANCEPage1-7.pdf";
                            DeleteFile(ProcessedPath + FileNamePdf);
                            file = new FileInfo(PathReportAspen + FileNamePdf);
                            file.CopyTo(ProcessedPath + FileNamePdf);
                            mergePaths.Add(ProcessedPath + FileNamePdf);

                            viewer = new ReportViewer();
                            viewer.LocalReport.DataSources.Clear();
                            viewer.ProcessingMode = ProcessingMode.Local;
                            viewer.LocalReport.ReportPath = PathReportAspen + "Copy of Copy of MedicalPage1.rdlc";
                            viewer.LocalReport.DataSources.Add(rpd);
                            viewer.LocalReport.Refresh();
                            mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 3);

                            viewer = new ReportViewer();
                            viewer.LocalReport.DataSources.Clear();
                            viewer.ProcessingMode = ProcessingMode.Local;
                            viewer.LocalReport.ReportPath = PathReportAspen + "MedicalPage1.rdlc";
                            viewer.LocalReport.DataSources.Add(rpd);
                            viewer.LocalReport.Refresh();
                            mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 4);

                            FileNamePdf = "ASPCX007 0615 - MEDICAL OR X-RAY LABORATORIES ENDORSEMENTPage2.pdf";
                            DeleteFile(ProcessedPath + FileNamePdf);
                            file = new FileInfo(PathReportAspen + FileNamePdf);
                            file.CopyTo(ProcessedPath + FileNamePdf);
                            mergePaths.Add(ProcessedPath + FileNamePdf);


                            viewer = new ReportViewer();
                            viewer.LocalReport.DataSources.Clear();
                            viewer.ProcessingMode = ProcessingMode.Local;
                            viewer.LocalReport.ReportPath = PathReportAspen + "ASPCX004 0615 - MANDATORY PREMIUM AND COVERAGE CONDITIONS ENDORSEMENTPage1.rdlc";
                            viewer.LocalReport.DataSources.Add(rpd);
                            viewer.LocalReport.Refresh();
                            mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 5);

                            FileNamePdf = "ASPCX004 0615 - MANDATORY PREMIUM AND COVERAGE CONDITIONS ENDORSEMENTPage2-3.pdf";
                            DeleteFile(ProcessedPath + FileNamePdf);
                            file = new FileInfo(PathReportAspen + FileNamePdf);
                            file.CopyTo(ProcessedPath + FileNamePdf);
                            mergePaths.Add(ProcessedPath + FileNamePdf);

                            viewer = new ReportViewer();
                            viewer.LocalReport.DataSources.Clear();
                            viewer.ProcessingMode = ProcessingMode.Local;
                            viewer.LocalReport.ReportPath = PathReportAspen + "ASPCX013 0615 - NUCLEAR ENERGY LIABILITY ENDORSEMENT (BROAD FORM)Page1.rdlc";
                            viewer.LocalReport.DataSources.Add(rpd);
                            viewer.LocalReport.Refresh();
                            mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 6);

                            FileNamePdf = "ASPCX013 0615 - NUCLEAR ENERGY LIABILITY ENDORSEMENT (BROAD FORM)Page2-3.pdf";
                            DeleteFile(ProcessedPath + FileNamePdf);
                            file = new FileInfo(PathReportAspen + FileNamePdf);
                            file.CopyTo(ProcessedPath + FileNamePdf);
                            mergePaths.Add(ProcessedPath + FileNamePdf);

                            if (taskControl.Charge > 0)
                            {
                               // mergePaths.Add(PrintWordProcessedPath("PolicyType = 'ALL' and FormName = 'ENDOSO DERRAMAS'", false));
                                var currentApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath.ToString();
                                string fullFilePath = currentApplicationPath + "Reports\\Word\\Files\\CN-2021-299-D_ENDOSO_DERRAMAS.pdf";
                                string copyToPath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + "CN-2021-299-D_ENDOSO_DERRAMAS.pdf";
                                File.Copy(fullFilePath, copyToPath, true);
                                mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + "CN-2021-299-D_ENDOSO_DERRAMAS.pdf");
                            }


                            viewer = new ReportViewer();
                            viewer.LocalReport.DataSources.Clear();
                            viewer.ProcessingMode = ProcessingMode.Local;
                            viewer.LocalReport.ReportPath = PathReportAspen + "CONTINUOUS RENEWAL ENDORSEMENT2.rdlc";
                            viewer.LocalReport.DataSources.Add(rpd);
                            viewer.LocalReport.Refresh();
                            mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 7);



                            if (File.Exists(ProcessedPath + taskControl.TaskControlID.ToString() + ".pdf"))
                                File.Delete(ProcessedPath + taskControl.TaskControlID.ToString() + ".pdf");

                            //Generar PDF
                            EPolicy.CreatePDFBatch mergeFinal = new EPolicy.CreatePDFBatch();
                            string FinalFile = "";
                            FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl.TaskControlID.ToString());
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                            taskControl.PrintPolicy = true;
                            btnEnablePrint.Visible = true;
                        }
                        #endregion

                    }

                    #region Aspen Laboratory Anniv2 o mas //eskeit
                    else if (!taskControl.PrintPolicy && taskControl.Anniversary == "02" || taskControl.Anniversary == "03" || taskControl.Anniversary == "04" || taskControl.Anniversary == "05" || taskControl.Anniversary == "06"
                        || taskControl.Anniversary == "07" || taskControl.Anniversary == "08" || taskControl.Anniversary == "09" || taskControl.Anniversary == "10" || taskControl.Anniversary == "11" || taskControl.Anniversary == "12")
                    {
                        if (taskControl.PolicyType.Trim() == "ALP" || taskControl.PolicyType.Trim() == "ALE")
                        {
                            GetReportLaboratoryPolicyTableAdapters.GetReportLaboratoryPolicyTableAdapter ds = new GetReportLaboratoryPolicyTableAdapters.GetReportLaboratoryPolicyTableAdapter();
                            ReportDataSource rpd = new ReportDataSource("GetReportLaboratoryPolicy_GetReportLaboratoryPolicy", (DataTable)ds.GetData(taskControl.TaskControlID));

                            FileNamePdf = "COVERPAGE.pdf";
                            DeleteFile(ProcessedPath + FileNamePdf);
                            FileInfo file = new FileInfo(PathReportAspen + FileNamePdf);
                            file.CopyTo(ProcessedPath + FileNamePdf);
                            mergePaths.Add(ProcessedPath + FileNamePdf);

                            //ReportViewer viewer = new ReportViewer();
                            //viewer.LocalReport.DataSources.Clear();
                            //viewer.ProcessingMode = ProcessingMode.Local;
                            //viewer.LocalReport.ReportPath = PathReportAspen + "AspenPage1.rdlc"; 
                            //viewer.LocalReport.DataSources.Add(rpd);
                            //viewer.LocalReport.Refresh();
                            //mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 0);

                            //viewer = new ReportViewer();
                            //viewer.LocalReport.DataSources.Clear();
                            //viewer.ProcessingMode = ProcessingMode.Local;
                            //viewer.LocalReport.ReportPath = PathReportAspen + "ASPCX001 0715 - MEDICAL OR X-RAY LABORATORIES PROFESSIONAL LIABILITY POLICY DECLARATIONSPage2.rdlc"; 
                            //viewer.LocalReport.DataSources.Add(rpd);
                            //viewer.LocalReport.Refresh();
                            //mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 1);

                            ReportViewer viewer = new ReportViewer();
                            viewer = new ReportViewer();
                            viewer.LocalReport.DataSources.Clear();
                            viewer.ProcessingMode = ProcessingMode.Local;
                            viewer.LocalReport.ReportPath = PathReportAspen + "ASPCX011-0615LABORATORIESRENEWALENDORSEMENT.rdlc";
                            viewer.LocalReport.DataSources.Add(rpd);
                            viewer.LocalReport.Refresh();
                            mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 0);


                            viewer = new ReportViewer();
                            viewer.LocalReport.DataSources.Clear();
                            viewer.ProcessingMode = ProcessingMode.Local;
                            viewer.LocalReport.ReportPath = PathReportAspen + "renewalpage2.rdlc";
                            viewer.LocalReport.DataSources.Add(rpd);
                            viewer.LocalReport.Refresh();
                            mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 1);

                            //FileNamePdf = "ASPCX002 1015 - PROFESSIONAL LIABILITY INSURANCE POLICY.pdf";
                            //DeleteFile(ProcessedPath + FileNamePdf);
                            //file = new FileInfo(PathReportAspen + FileNamePdf);
                            //file.CopyTo(ProcessedPath + FileNamePdf);
                            //mergePaths.Add(ProcessedPath + FileNamePdf);


                            //FileNamePdf = "ASPCX003 1015 - HOSPITAL PROFESSIONAL LIABILITY INSURANCE.pdf";
                            //DeleteFile(ProcessedPath + FileNamePdf);
                            //file = new FileInfo(PathReportAspen + FileNamePdf);
                            //file.CopyTo(ProcessedPath + FileNamePdf);
                            //mergePaths.Add(ProcessedPath + FileNamePdf);

                            //viewer = new ReportViewer();
                            //viewer.LocalReport.DataSources.Clear();
                            //viewer.ProcessingMode = ProcessingMode.Local;
                            //viewer.LocalReport.ReportPath = PathReportAspen + "MedicalPage1.rdlc";
                            //viewer.LocalReport.DataSources.Add(rpd);
                            //viewer.LocalReport.Refresh();
                            //mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 4);

                            //FileNamePdf = "ASPCX007 0615 - MEDICAL OR X-RAY LABORATORIES ENDORSEMENTPage2.pdf";
                            //DeleteFile(ProcessedPath + FileNamePdf);
                            //file = new FileInfo(PathReportAspen + FileNamePdf);
                            //file.CopyTo(ProcessedPath + FileNamePdf);
                            //mergePaths.Add(ProcessedPath + FileNamePdf);


                            //viewer = new ReportViewer();
                            //viewer.LocalReport.DataSources.Clear();
                            //viewer.ProcessingMode = ProcessingMode.Local;
                            //viewer.LocalReport.ReportPath = PathReportAspen + "ASPCX004 0615 - MANDATORY PREMIUM AND COVERAGE CONDITIONS ENDORSEMENTPage1.rdlc"; 
                            //viewer.LocalReport.DataSources.Add(rpd);
                            //viewer.LocalReport.Refresh();
                            //mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 5);

                            //FileNamePdf = "ASPCX004 0615 - MANDATORY PREMIUM AND COVERAGE CONDITIONS ENDORSEMENTPage2-3.pdf";
                            //DeleteFile(ProcessedPath + FileNamePdf);
                            //file = new FileInfo(PathReportAspen + FileNamePdf);
                            //file.CopyTo(ProcessedPath + FileNamePdf);
                            //mergePaths.Add(ProcessedPath + FileNamePdf);

                            //viewer = new ReportViewer();
                            //viewer.LocalReport.DataSources.Clear();
                            //viewer.ProcessingMode = ProcessingMode.Local;
                            //viewer.LocalReport.ReportPath = PathReportAspen + "ASPCX013 0615 - NUCLEAR ENERGY LIABILITY ENDORSEMENT (BROAD FORM)Page1.rdlc";
                            //viewer.LocalReport.DataSources.Add(rpd);
                            //viewer.LocalReport.Refresh();
                            //mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 6);

                            //FileNamePdf = "ASPCX013 0615 - NUCLEAR ENERGY LIABILITY ENDORSEMENT (BROAD FORM)Page2-3.pdf";
                            //DeleteFile(ProcessedPath + FileNamePdf);
                            //file = new FileInfo(PathReportAspen + FileNamePdf);
                            //file.CopyTo(ProcessedPath + FileNamePdf);
                            //mergePaths.Add(ProcessedPath + FileNamePdf);


                            //viewer = new ReportViewer();
                            //viewer.LocalReport.DataSources.Clear();
                            //viewer.ProcessingMode = ProcessingMode.Local;
                            //viewer.LocalReport.ReportPath = PathReportAspen + "CONTINUOUS RENEWAL ENDORSEMENT2.rdlc"; 
                            //viewer.LocalReport.DataSources.Add(rpd);
                            //viewer.LocalReport.Refresh();
                            //mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 7);



                            if (File.Exists(ProcessedPath + taskControl.TaskControlID.ToString() + ".pdf"))
                                File.Delete(ProcessedPath + taskControl.TaskControlID.ToString() + ".pdf");

                            //Generar PDF
                            EPolicy.CreatePDFBatch mergeFinal = new EPolicy.CreatePDFBatch();
                            string FinalFile = "";
                            FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl.TaskControlID.ToString());
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                            taskControl.PrintPolicy = true;
                            btnEnablePrint.Visible = true;
                        }
                    #endregion

                        #region CLPT
                        else if (taskControl.PolicyType.ToString() == "CLPT")
                        {
                            EPolicy.TaskControl.Laboratory taskControl2 = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
                            //EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
                            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
                            //string userName = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();
                           //List<string> mergePaths = new List<string>();
                            //string ProcessedPath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"];

                            //DataTable dtAgency = GetAgencyDesc(taskControlVali.Agency.ToString());
                           // DataTable dtAgent = GetAgentDesc(int.Parse(taskControlVali.Agent.ToString()));

                            ReportViewer viewer = new ReportViewer();
                            viewer.LocalReport.ReportPath = Server.MapPath("Reports/ExtendedReportingPeriodQuote.rdlc");
                            viewer.LocalReport.DataSources.Clear();
                            viewer.ProcessingMode = ProcessingMode.Local;


                            ReportParameter[] param = new ReportParameter[15];
                            param[0] = new ReportParameter("PolicyID", taskControl2.PolicyNo.ToString().Trim());
                            param[1] = new ReportParameter("EffectiveDate", DateTime.Parse(taskControl2.EffectiveDate).ToString("MMMM dd, yyyy"));
                            param[2] = new ReportParameter("ExpirationDate", DateTime.Parse(taskControl2.ExpirationDate).ToString("MMMM dd, yyyy"));
                            param[3] = new ReportParameter("Agency", ddlAgency.SelectedItem.ToString());
                            param[4] = new ReportParameter("Agent", ddlAgent.SelectedItem.ToString());
                            param[5] = new ReportParameter("Customer", taskControl2.Customer.FirstName + " " + taskControl2.Customer.LastName1 + " " + taskControl2.Customer.LastName2);

                            if (taskControl2.Customer.Address2 != String.Empty)
                                param[6] = new ReportParameter("Address", taskControl2.Customer.Address1 + " \r\n" + taskControl2.Customer.Address2 + " \r\n" +
                                                           taskControl2.Customer.City + " " + taskControl2.Customer.State + " " + taskControl2.Customer.ZipCode);
                            else
                                param[6] = new ReportParameter("Address", taskControl2.Customer.Address1 + " \r\n" +
                                                               taskControl2.Customer.City + " " + taskControl2.Customer.State + " " + taskControl2.Customer.ZipCode);

                            param[7] = new ReportParameter("CancellationDate", DateTime.Parse(taskControl2.CancellationDate).ToString("MMMM dd, yyyy"));
                            param[8] = new ReportParameter("ReturnPremium", (taskControl2.ReturnPremium + taskControl2.ReturnCharge).ToString("$###,##0.00"));
                            param[9] = new ReportParameter("PolicyType", taskControl2.PolicyType.ToString().Trim());

                            if (taskControl2.CancellationMethod == 1)
                            {
                                param[10] = new ReportParameter("MOC3", "X");
                                param[11] = new ReportParameter("MOC5Exp", "");
                            }
                            else if (taskControl2.CancellationMethod == 2)
                            {
                                param[10] = new ReportParameter("MOC2", "X");
                                param[11] = new ReportParameter("MOC5Exp", "");
                            }
                            else if (taskControl2.CancellationMethod == 3)
                            {
                                param[10] = new ReportParameter("MOC1", "X");
                                param[11] = new ReportParameter("MOC5Exp", "");
                            }
                            else if (taskControl2.CancellationMethod == 4)
                            {
                                param[10] = new ReportParameter("MOC4", "X");
                                param[11] = new ReportParameter("MOC5Exp", "");
                            }
                            else
                            {
                                param[10] = new ReportParameter("MOC5", "X");
                                param[11] = new ReportParameter("MOC5Exp", taskControl2.CancellationMethodDesc.ToString());
                            }

                            if (taskControl2.CancellationReason == 6)
                            {
                                param[12] = new ReportParameter("RSC1", "X");
                                param[13] = new ReportParameter("RSC4Date", "");
                            }
                            else if (taskControl2.CancellationReason == 5 || taskControl2.CancellationReason == 10
                                     || taskControl2.CancellationReason == 14)
                            {
                                param[12] = new ReportParameter("RSC2", "X");
                                param[13] = new ReportParameter("RSC4Date", "");
                            }
                            else if (taskControl2.CancellationReason == 26)
                            {
                                param[12] = new ReportParameter("RSC3", "X");
                                param[13] = new ReportParameter("RSC3Date", DateTime.Parse(taskControl2.CancellationReasonDesc).ToString("MMMM dd, yyyy"));
                            }
                            else if (taskControl2.CancellationReason == 27)
                            {
                                param[12] = new ReportParameter("RSC4", "X");
                                param[13] = new ReportParameter("RSC4Date", DateTime.Parse(taskControl2.CancellationReasonDesc).ToString("MMMM dd, yyyy"));
                            }
                            else
                            {
                                param[12] = new ReportParameter("RSC5", "X");
                                param[13] = new ReportParameter("RSC5Exp", taskControl2.CancellationReasonDesc.ToString());
                            }

                            param[14] = new ReportParameter("insuranceCompany", taskControl2.InsuranceCompany.ToString());

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


                            mergePaths = WriteRdlcToPDF(viewer, taskControl2, mergePaths, 0);

                            //viewer = new ReportViewer();
                            //viewer.LocalReport.DataSources.Clear();
                            //viewer.ProcessingMode = ProcessingMode.Local;
                            //viewer.LocalReport.ReportPath = Server.MapPath("Reports/ExtendedReportingPeriodQuote.rdlc");
                            //viewer.LocalReport.SetParameters(param);
                            //viewer.LocalReport.Refresh();
                            // mergePaths = WriteRdlcToPDF(viewer, taskControl2, mergePaths, 1);

                            EPolicy.CreatePDFBatch mergeFinal = new EPolicy.CreatePDFBatch();
                            string FinalFile = "";
                            DateTime Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl2.PolicyType.ToString() + " " + taskControl2.PolicyNo.ToString() + " Tail Quote " + "" + DateTime.Now.ToShortDateString().Replace('/', '-') + "");
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);

                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + _FileName + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                            //return _FileName;
                        }
                        #endregion

                        #region
                        else if (!taskControl.PrintPolicy && Convert.ToDateTime(taskControl.EffectiveDate.ToString().Trim()).Year - Convert.ToDateTime(taskControl.RetroactiveDate.ToString().Trim()).Year > 0)
                        {
                            //FileNamePdf = "Lab - Cover Page.pdf";
                            //DeleteFile(ProcessedPath + FileNamePdf);
                            //FileInfo file = new FileInfo(PathReport + FileNamePdf);
                            //file.CopyTo(ProcessedPath + FileNamePdf);
                            //mergePaths.Add(ProcessedPath + FileNamePdf);
                            if (taskControl.PolicyType.Trim() == "CLP" || taskControl.PolicyType.Trim() == "CLE")
                            {
                                GetReportLaboratoryPolicyTableAdapters.GetReportLaboratoryPolicyTableAdapter ds = new GetReportLaboratoryPolicyTableAdapters.GetReportLaboratoryPolicyTableAdapter();
                                ReportDataSource rpd = new ReportDataSource("GetReportLaboratoryPolicy_GetReportLaboratoryPolicy", (DataTable)ds.GetData(taskControl.TaskControlID));

                                ReportViewer viewer = new ReportViewer();
                                viewer.LocalReport.DataSources.Clear();
                                viewer.ProcessingMode = ProcessingMode.Local;
                                viewer.LocalReport.ReportPath = PathReport + "InvoiceLab.rdlc";
                                ReportParameter[] param = new ReportParameter[11];
                                param[0] = new ReportParameter("Agency", ddlAgency.SelectedItem.Text.ToString());
                                param[1] = new ReportParameter("Aniv", taskControl.Anniversary.ToString());
                                param[2] = new ReportParameter("CustomerName", taskControl.Customer.FirstName + " " + taskControl.Customer.LastName1.ToString() + " " + taskControl.Customer.LastName2.ToString());
                                param[3] = new ReportParameter("Adds1", taskControl.Customer.Address1.ToString());
                                param[4] = new ReportParameter("Adds2", taskControl.Customer.Address2.ToString());
                                param[5] = new ReportParameter("TotalPremium", (taskControl.Premium + taskControl.Charge).ToString());
                                param[6] = new ReportParameter("PolicyNo", taskControl.PolicyType.ToString() + "-" + taskControl.PolicyNo.ToString());
                                param[7] = new ReportParameter("EffectiveDate", taskControl.EffectiveDate.ToString());
                                param[8] = new ReportParameter("Adds3", taskControl.Customer.City.ToString() + ", " + taskControl.Customer.State.ToString() + "," + taskControl.Customer.ZipCode.ToString());
                                param[9] = new ReportParameter("Charge",taskControl.Charge.ToString());
                                param[10] = new ReportParameter("Premium", taskControl.Premium.ToString());
                                viewer.LocalReport.DataSources.Add(rpd);
                                viewer.LocalReport.SetParameters(param);
                                viewer.LocalReport.Refresh();
                                mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 4);

                                viewer = new ReportViewer();
                                viewer.LocalReport.DataSources.Clear();
                                viewer.ProcessingMode = ProcessingMode.Local;
                                viewer.LocalReport.ReportPath = PathReport + "LPL0038.rdlc";
                                viewer.LocalReport.DataSources.Add(rpd);
                                viewer.LocalReport.Refresh();
                                mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 5);

                                viewer = new ReportViewer();
                                viewer.LocalReport.DataSources.Clear();
                                viewer.ProcessingMode = ProcessingMode.Local;
                                viewer.LocalReport.ReportPath = PathReport + "LPL0038-2.rdlc";
                                viewer.LocalReport.DataSources.Add(rpd);
                                viewer.LocalReport.Refresh();
                                mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 6);//Carta_Dept_Defensa

                                viewer = new ReportViewer();
                                viewer.LocalReport.DataSources.Clear();
                                viewer.ProcessingMode = ProcessingMode.Local;
                                viewer.LocalReport.ReportPath = PathReportNew + "Carta_Dept_Defensa.rdlc";
                                viewer.LocalReport.Refresh();
                                mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 7);

                                if (taskControl.Charge > 0 )
                                {
                                //mergePaths.Add(PrintWordProcessedPath("PolicyType = 'ALL' and FormName = 'ENDOSO DERRAMAS'", false)); 
                                var currentApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath.ToString();
                                string fullFilePath = currentApplicationPath + "Reports\\Word\\Files\\CN-2021-299-D_ENDOSO_DERRAMAS.pdf";
                                string copyToPath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + "CN-2021-299-D_ENDOSO_DERRAMAS.pdf";
                                File.Copy(fullFilePath, copyToPath, true);
                                mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + "CN-2021-299-D_ENDOSO_DERRAMAS.pdf");
                                }
                            }
                            if (File.Exists(ProcessedPath + taskControl.TaskControlID.ToString() + ".pdf"))
                                File.Delete(ProcessedPath + taskControl.TaskControlID.ToString() + ".pdf");

                            //Generar PDF
                            EPolicy.CreatePDFBatch mergeFinal = new EPolicy.CreatePDFBatch();
                            string FinalFile = "";
                            FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl.TaskControlID.ToString());
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                            taskControl.PrintPolicy = true;
                            btnEnablePrint.Visible = true;


                        }
                        else
                        {
                            this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy Printing has been disabled.  Please contact your supervisor.");
                            this.litPopUp.Visible = true;
                        }

                    }
                    else
                    {
                        GetReportLaboratoryQuotesTableAdapters.GetReportLaboratoryQuotesTableAdapter ds = new GetReportLaboratoryQuotesTableAdapters.GetReportLaboratoryQuotesTableAdapter();
                        ReportDataSource rpd = new ReportDataSource("GetReportLaboratoryQuotes_GetReportLaboratoryQuotes", (DataTable)ds.GetData(taskControl.TaskControlID));

                        ReportViewer viewer = new ReportViewer();
                        viewer.LocalReport.DataSources.Clear();
                        viewer.ProcessingMode = ProcessingMode.Local;
                        viewer.LocalReport.ReportPath = PathReport + "LaboratoryQuotes.rdlc";
                        viewer.LocalReport.DataSources.Add(rpd);
                        viewer.LocalReport.Refresh();

                        mergePaths = WriteRdlcToPDF(viewer, taskControl, mergePaths, 0);

                        if (File.Exists(ProcessedPath + taskControl.TaskControlID.ToString() + ".pdf"))
                            File.Delete(ProcessedPath + taskControl.TaskControlID.ToString() + ".pdf");

                        //Generar PDF
                        EPolicy.CreatePDFBatch mergeFinal = new EPolicy.CreatePDFBatch();
                        string FinalFile = "";
                        FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl.TaskControlID.ToString());
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                        taskControl.PrintPolicy = true;

                    }


                    //taskControl.PrintPolicy = true;
                    taskControl.PrintDate = DateTime.Now.ToShortDateString();
                    FillProperties();
                    History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY.");
                    taskControl.SaveOnlyPolicy(userID);


                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
                        #endregion
        }

        protected void btnPrintPolicyWord_Click(object sender, System.EventArgs e)
        {
            EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
            List<string> mergePaths = new List<string>();
            string ProcessedPath = ConfigurationManager.AppSettings["ExportsFilesPathName"];
            if (!taskControl.PrintPolicy)
            {

                //DataTable reports = GetReportMasterDocumentsByCriteria("(FormName = 'policy' or FormName = 'DECLARATIONS PAGE') and PolicyType = 'PP'");
                DataTable reports = GetReportMasterDocumentsByCriteria(ConstructWhereClauseForReport());
                for (int i = 0; i < reports.Rows.Count; i++)
                {
                    if (reports.Rows[i]["WordDocument"].ToString().Contains(".pdf"))
                    {
                        var currentApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath.ToString();
                        string fullFilePath = currentApplicationPath + "Reports\\Word\\Files\\LAB\\" + reports.Rows[i]["WordDocument"].ToString();
                        string copyToPath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + reports.Rows[i]["WordDocument"].ToString();
                        File.Copy(fullFilePath, copyToPath, true);
                        mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + reports.Rows[i]["WordDocument"].ToString());

                    }
                    else
                    {
                        mergePaths = PrintMSWord(reports.Rows[i]["WordDocument"].ToString(), mergePaths, ProcessedPath);
                    }

                }

                PrintMW_PDFMerge(mergePaths, ProcessedPath);
            }

            else
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy Printing has been disabled.  Please contact your supervisor.");
                this.litPopUp.Visible = true;
            }
        }


        private void History(int taskControlID, int userID, string action, string subject, string note)
        {
            Audit.History history = new Audit.History();
            EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];

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
                EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];

          

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
            TaskControl.Laboratory taskControl = (TaskControl.Laboratory)Session["TaskControl"];
            TaskControl.Policy originalPolicy = (TaskControl.Policy)Session["TaskControl"];
            TaskControl.Laboratory laboratory = new TaskControl.Laboratory();

            try
            {
                if (!taskControl.PolicyCanRenewDt(taskControl.TaskControlID, int.Parse(taskControl.Suffix)))
                {
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("The policy has already been renewed.");
                    this.litPopUp.Visible = true;
                    return;
                }
                
                laboratory = taskControl;
                laboratory.RetroactiveDate = taskControl.RetroactiveDate;
                laboratory.Mode = 1;
                laboratory.CancellationDate = "";
                laboratory.CancellationEntryDate = "";
                laboratory.CancellationUnearnedPercent = 0.00;
                laboratory.CancellationReason = 0;
                laboratory.CancellationMethod = 0;
                laboratory.PaidAmount = 0.00;
                laboratory.PaidDate = taskControl.PaidDate;
                laboratory.Ren_Rei = "RN";
                laboratory.Rein_Amt = taskControl.CancellationAmount;
                laboratory.Coverage = taskControl.Coverage;

                laboratory.CommissionAgency = 0.00;
                laboratory.CommissionAgent = 0.00;
                laboratory.CommissionAgencyPercent = "";
                laboratory.CommissionAgentPercent = "";
                laboratory.TaskControlID = 0;
                laboratory.Status = "Inforce";

                laboratory.EntryDate = DateTime.Now;
                laboratory.EffectiveDate = (DateTime.Parse(laboratory.EffectiveDate).AddMonths(12)).ToShortDateString();
                txtEffDt.Text = laboratory.EffectiveDate;
                laboratory.ExpirationDate = (DateTime.Parse(laboratory.ExpirationDate).AddMonths(12)).ToShortDateString();
                txtExpDt.Text = laboratory.ExpirationDate;

                //Recalculate();
                //Calculate();
                CalculateCharge();
                laboratory.Charge = double.Parse(TxtCharge.Text);

                laboratory.ReturnCharge = 0.00;
                laboratory.ReturnPremium = 0.00;
                laboratory.CancellationAmount = 0.00;
                laboratory.ReturnCommissionAgency = 0.00;
                laboratory.ReturnCommissionAgent = 0.00;

                laboratory.PrintPolicy = false;
                laboratory.PrintDate = "";

                int msufijo;
                int sufijo = int.Parse(taskControl.Suffix);
                msufijo = sufijo + 1;

                if (msufijo < 10)
                    laboratory.Suffix = "0".ToString() + msufijo.ToString();
                else
                    laboratory.Suffix = msufijo.ToString();

                int mAniv;
                int aniv = int.Parse(taskControl.Anniversary);
                mAniv = aniv + 1;

                if (mAniv < 10)
                    laboratory.Anniversary = "0".ToString() + mAniv.ToString();
                else
                    laboratory.Anniversary = mAniv.ToString();

                int RetroYear = 0;
                RetroYear = DateTime.Parse(laboratory.EffectiveDate).Year - DateTime.Parse(laboratory.RetroactiveDate).Year;
                if (laboratory.Endoso == 0)
                {
                    switch (RetroYear)
                    {
                        case 0:
                            laboratory.TotalPremium = double.Parse(TxtTotalPremium.Text);
                            break;
                        case 1:
                            laboratory.TotalPremium = double.Parse(TxtTotalPremium.Text);
                            break;
                        case 2:
                            laboratory.TotalPremium = double.Parse(TxtTotalPremium.Text);
                            break;
                        default:
                            laboratory.TotalPremium = double.Parse(TxtTotalPremium.Text);
                            break;
                    }
                }
                laboratory.isEndorsement = false;
                Session.Clear();
                Session.Add("TaskControl", laboratory);
                Response.Redirect("LaboratoryApplication1.aspx", false);
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }
        }
        protected void btnReinstatement_Click(object sender, EventArgs e)
        {
            TaskControl.Laboratory taskControl = (TaskControl.Laboratory)Session["TaskControl"];
            TaskControl.Policy policy = (TaskControl.Policy)Session["TaskControl"];
            TaskControl.Laboratory laboratory = new TaskControl.Laboratory(true);

            try
            {
                ValidateReinstatement(laboratory, taskControl);

                laboratory = taskControl;
                laboratory.Mode = 2;
                laboratory.CancellationDate = "";
                laboratory.CancellationEntryDate = "";
                laboratory.CancellationUnearnedPercent = 0.00;
                laboratory.CancellationMethod = 0;
                laboratory.CancellationReason = 0;
                //laboratory.EntryDate = DateTime.Now;
                laboratory.PaidAmount = taskControl.PaidAmount;
                laboratory.PaidDate = "";
                laboratory.Ren_Rei = "RI";
                laboratory.Rein_Amt = taskControl.CancellationAmount;
                laboratory.PaidDate = taskControl.PaidDate;
                laboratory.CommissionAgency = taskControl.ReturnCommissionAgency;
                laboratory.CommissionAgent = taskControl.ReturnCommissionAgent;
                laboratory.CommissionAgencyPercent = taskControl.CommissionAgencyPercent.Trim();
                laboratory.CommissionAgentPercent = taskControl.CommissionAgentPercent.Trim();
                //policies.TotalPremium = taskControl.ReturnPremium;
                //policies.Charge = taskControl.ReturnCharge;
                laboratory.ReturnCharge = 0.00;
                laboratory.ReturnPremium = 0.00;
                laboratory.CancellationAmount = 0.00;
                laboratory.ReturnCommissionAgency = 0.00;
                laboratory.ReturnCommissionAgent = 0.00;
                //policies.TaskControlID = 0;
                laboratory.Status = "Inforce";



                //int msufijo;
                //int sufijo = int.Parse(taskControl.Suffix);
                //msufijo = sufijo + 1;
                //policies.Suffix = "0".ToString() + msufijo.ToString();

                Session.Add("TaskControl", laboratory);

                FillTextControl();
                lblExpDate.Text = "Exp. Date";
                EnableControl();
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }
        }

        private void ValidateReinstatement(TaskControl.Laboratory policies, TaskControl.Laboratory Oldpolicies)
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
                Session.Add("FromUI", "LaboratoryApplication1.aspx");
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
                    EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
                    taskControl.UserID = userID;

                    if (taskControl.isEndorsement)
                    {
                        if (txtEndoEffDate.Text != "" && (DateTime.Parse(txtExpDt.Text) < DateTime.Parse(txtEndoEffDate.Text)))
                        {
                            int monthDiference = 0;
                            monthDiference = (DateTime.Parse(txtEndoEffDate.Text).Month - DateTime.Parse(txtEffDt.Text).Month) + 12 * (DateTime.Parse(txtEndoEffDate.Text).Year - DateTime.Parse(txtExpDt.Text).Year);
                            taskControl.Term = int.Parse(TxtTerm.Text) + monthDiference;
                        }

                        taskControl.Endoso = int.Parse(txtEndorsementNo.Text);                        
                        taskControl.SaveLaboratory();  //(userID);

                        if (taskControl.IsPolicy)
                        {
                            //Update Inception Payment Amount
                            UpdateInceptionPartialPayments(taskControl.TaskControlID, (taskControl.TotalPremium + taskControl.Charge));
                        }

                        //VerifyChanges(taskControl, userID);
                        AddEndorsement(taskControl.TaskControlID);

                        //ApplyEndorsement(taskControl, userID);
                        //Session["TaskControl"] = (TaskControl.Policies)Session["PLEndorsement"];
                        //taskControl = (TaskControl.Policies)Session["PLEndorsement"];
                        taskControl.isEndorsement = false;

                        
                        FillTextControl();
                        //FillGrid();
                        DisableControl();

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

                        ShowMessage("Policy endorsement information saved successfully.");
                    }
                    else
                    {
                        taskControl.SaveLaboratory();
                        UpdateInceptionPartialPayments(taskControl.TaskControlID, (taskControl.TotalPremium + taskControl.Charge));

                        FillTextControl();
                        FillGrid();
                        DisableControl();

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
            TaskControl.Laboratory taskControl = (TaskControl.Laboratory)Session["TaskControl"];
            TaskControl.Laboratory taskControl2 = (TaskControl.Laboratory)Session["OriginalPolicy"];

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

        private string VerifyChanges(EPolicy.TaskControl.Laboratory newOPP, int userID)
        {
            EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["OriginalPolicy"];
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

            EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];

            if (taskControl.PolicyType.ToString().Trim().Length >= 3 && !taskControl.PolicyType.Contains("A") && !taskControl.PolicyType.Contains("L"))
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
            EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
            Login.Login cp = HttpContext.Current.User as Login.Login;
            FillTextControl();
            taskControl.Mode = (int)EPolicy.TaskControl.TaskControl.TaskControlMode.UPDATE;
            //btnCalcCharge.Visible = true;
            Session.Add("TaskControl", taskControl);
            taskControl.isEndorsement = false;
            EnableControl();
            pnlHistory.Visible = false;
            
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            TaskControl.Laboratory taskControl = (TaskControl.Laboratory)Session["TaskControl"];
            try
            {
                int id = taskControl.TaskControlID;
                TaskControl.Laboratory.DeleteLaboratoryPolicyByTaskControlID(id, taskControl.IsPolicy);
                taskControl = new TaskControl.Laboratory(false);
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
            Laboratory taskControl = new Laboratory(false);
            taskControl.Mode = 1;
            Session.Add("TaskControl", taskControl);
            Response.Redirect("LaboratoryApplication1.aspx", true);

        }
        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
            if (taskControl.TaskControlID == 0)
            {
                Laboratory taskControl2 = new Laboratory(false);
                taskControl.Mode = 1;
                Session.Add("TaskControl", taskControl2);
                Response.Redirect("LaboratoryApplication1.aspx", true);
            }
            else
            {
                DisableControl();
                FillTextControl();
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
                TaskControl.Laboratory taskControl = (TaskControl.Laboratory)Session["TaskControl"];
                Response.Redirect("SearchAuditItems.aspx?type=28&taskControlID=" +
                    taskControl.TaskControlID.ToString().Trim());
            }
        }
        protected void btnEndor_Click(object sender, EventArgs e)
        {
            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
            int userID = 0;
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
            EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
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

            EnableControl();

            //RemoveSessionLookUp();
            //Response.Redirect("LaboratoryApplication1.aspx");
        }
        protected void btnComissions_Click(object sender, EventArgs e)
        {

        }
        protected void btnFinancialCanc_Click(object sender, EventArgs e)
        {
            RemoveSessionLookUp();
            Session.Add("FromUI", "LaboratoryApplication1.aspx");
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

            //btnRefresh.Visible = true;
            Response.Write(js);
        }
        protected void btnPrintCertificate_Click(object sender, EventArgs e)
        {
            string js = "<script language=javascript> javascript:popwindow=window.open('PrintCertificate.aspx?','popwindow','toolbar=no,location=center,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,copyhistory=no,width=850,height=450');popwindow.focus(); </script>";
            Response.Write(js);
            //DisableControl();
        }
        protected void btnPolicyCert_Click(object sender, EventArgs e)
        {

        }
        protected void btnPayments_Click(object sender, EventArgs e)
        {
            RemoveSessionLookUp();
            Session.Add("FromPage", "LaboratoryApplication1.aspx");
            Response.Redirect("ViewPayment.aspx");
        }
        protected void btnHideEndoPanel_Click(object sender, EventArgs e)
        {

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
                EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
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
                        taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
                        //EPolicy.TaskControl.Policies taskControl2 = (EPolicy.TaskControl.Policies)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControlID, userID);

                        Session.Add("PreviousPremium", taskControl.TotalPremium);
                        Session.Add("OriginalPolicy", taskControl);

                        taskControl.isEndorsement = true;
                        previousPremium = taskControl.TotalPremium;
                        taskControl.Mode = (int)TaskControl.TaskControl.TaskControlMode.UPDATE;

                        Session.Add("TaskControl", taskControl);

                        EnableControl();

                        break;
                    case "Delete":
                        taskControl.Endoso = taskControl.Endoso - 1;

                        if (e.Item.Cells[6].Text.Trim() != "&nbsp;" && e.Item.Cells[6].Text.Trim() != String.Empty && e.Item.Cells[6].Text.Trim() != null)
                        TxtPremium.Text = (double.Parse(TxtPremium.Text) - double.Parse(e.Item.Cells[6].Text)).ToString("###,##0.00");
                        TxtTotalPremium.Text = TxtPremium.Text;
                        txtEndoEffDate.Text = "";
                        chkUserMod.Checked = true;

                        FillProperties();

                        taskControl.SaveLaboratory();  //(userID);

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
                        //    string fileName = taskControl.Prospect.FirstName.Trim().Replace("ñ", "n").Replace("Ñ", "N") + taskControl.Prospect.LastName1.Trim().Replace("ñ", "n").Replace("Ñ", "N") + taskControl.TaskControlID.ToString().Trim() + OPPEndorID.ToString().Trim();
                        //    string _FileName = taskControl.Prospect.FirstName.Trim().Replace("ñ", "n").Replace("Ñ", "N") + taskControl.Prospect.LastName1.Trim().Replace("ñ", "n").Replace("Ñ", "N") + taskControl.TaskControlID.ToString().Trim() + OPPEndorID.ToString().Trim() + ".pdf";
                        //    //Ññ
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
                Response.Redirect("LaboratoryApplication1.aspx?" + taskControl.TaskControlID, true);
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
            EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];

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

        private double CalculateDifference(EPolicy.TaskControl.Laboratory taskControl)
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
            EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
            EPolicy.TaskControl.Laboratory OldOPP = (EPolicy.TaskControl.Laboratory)Session["OriginalPolicy"];
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

        protected void btnCalcCharge_Click(object sender, EventArgs e)
        {

        }
        protected void chkUserMod_CheckedChanged(object sender, EventArgs e)
        {

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
        protected void chkUserModEndo_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void ChkAutoAssignPolicy_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void TxtPremium_TextChanged(object sender, EventArgs e)
        {
            TaskControl.Laboratory taskControl = (TaskControl.Laboratory)Session["TaskControl"];
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
        protected void btnCalculatePremium_Click(object sender, EventArgs e)
        {
            try
            {
                CalculateCharge();

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
        protected void btnRefresh_Click(object sender, EventArgs e)
        {

        }
        protected void btnComment_Click(object sender, EventArgs e)
        {
            TaskControl.Laboratory taskControl = (TaskControl.Laboratory)Session["TaskControl"];
            TaskControl.Comment comment = (TaskControl.Comment) new EPolicy.TaskControl.Comment();

            comment.TaskControlID = taskControl.TaskControlID;
            comment.PolicyNo = taskControl.PolicyNo;
            Session.Add("TaskControlComments", comment);

            RemoveSessionLookUp();
            Session.Add("FromPage", "LaboratoryApplication1.aspx");
            Response.Redirect("Comments.aspx");
        }


        protected void PrintMW_PDFMerge(List<string> mergePaths, string ProcessedPath)
        {
            EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
            CreatePDFBatch mergeFinal = new CreatePDFBatch();
            string FinalFile = "";
            FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl.Customer.FirstName + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2);
            taskControl.PrintPolicy = true;
            taskControl.PrintDate = DateTime.Now.ToShortDateString();
            taskControl.Mode = 2;
            FillProperties();
            taskControl.SaveLaboratory();
            History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY RENOVATION DOCUMENT.");
            RemoveSessionLookUp();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
        }


        private List<string> PrintMSWord(string Filename, List<string> mergePaths, string ProcessedPath)
        {
            EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
            string BookMarkName = "";
            string BookMarkValue = "";
            System.Drawing.Image image;
            //Load document  
            Spire.Doc.Document document = new Spire.Doc.Document();
            string FilePath = @"C:\inetpub\wwwroot\PRMdic\Reports\Word\Files\LAB\" + Filename;
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

            EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];

            DataTable dt = GetReportMasterInformationByTaskcontrolID(taskControl.TaskControlID);
            string value = "";
            string Limit1 = ddlPrMedicalLimits.SelectedItem.Text.Trim(); 
            string Limit2 = "";
            Limit2 = ddlPrMedicalLimits.SelectedItem.Text.Trim();//ddlPriPolLimits1.SelectedItem.Text.Trim();
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



        //public string CalculateInvoiceDiscount(TaskControl.Policies taskControl, string ReturnType)
        //{
            //TaskControl.Laboratory taskcontrol2 = TaskControl.Laboratory.GetPolicies(taskControl.TaskControlID);
            //if (taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "AAE" || taskControl.PolicyType.Trim() == "PP" || taskControl.PolicyType.Trim() == "AAP" || taskControl.PolicyType.Trim() == "IF")
            //{
            //    double totPrem = taskControl.TotalPremium;
            //    double InvoiceDiscount = 0.00;
            //    if (taskControl.InvoiceNumber != "")
            //        InvoiceDiscount = (double.Parse(taskControl.InvoiceNumber));

            //    //double OriginalPremium = taskcontrol2.MCMRate;

            //    double discount = Math.Round((InvoiceDiscount / 100.0) * totPrem, 0);


            //    double Assit = 0.0; //taskcontrol2.TotPremTN6;
            //    double prima = taskControl.TotalPremium;
            //    double discountTN6 = Math.Round((totPrem - taskcontrol2.TotPremTN6) * (InvoiceDiscount / 100.0), 0);

            //    double Prima_Employee = 0.0;

            //    if (taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "AAE")
            //    {
            //        Prima_Employee = taskcontrol2.ETotPremTN6;
            //        Assit = taskcontrol2.ETotPremTN6;
            //    }
            //    else if (taskControl.PolicyType.Trim() == "PP" || taskControl.PolicyType.Trim() == "AAP" || taskControl.PolicyType.Trim() == "IF")
            //    {
            //        Prima_Employee = taskcontrol2.TotPremTN6;
            //        Assit = taskcontrol2.TotPremTN6;
            //    }

            //    double NueveCinco = ((100.0 - InvoiceDiscount) / 100.0);
            //    double OriginalPremium = Math.Round(((prima - Prima_Employee) / NueveCinco), 0);
            //    double Dcount = Math.Round((OriginalPremium - (prima - Prima_Employee)), 0);



            //    if (taskControl.PolicyType.Contains("E"))
            //    {
            //        if (ReturnType == "Discount")
            //        {
            //            if (Dcount != 0)
            //            {
            //                return Dcount.ToString("C", CultureInfo.CurrentCulture);
            //            }
            //            else
            //                return "";
            //        }
            //        else
            //        {
            //            if (Assit != 0)
            //            {
            //                return Assit.ToString("C", CultureInfo.CurrentCulture);
            //            }
            //            else
            //                return "";
            //        }

            //    }

            //    else
            //    {

            //        if (ReturnType == "Discount")
            //        {
            //            if (Dcount != 0)
            //            {
            //                return Dcount.ToString("C", CultureInfo.CurrentCulture);
            //            }
            //            else
            //                return "";
            //        }
            //        else
            //        {
            //            if (Assit != 0)
            //            {
            //                return Assit.ToString("C", CultureInfo.CurrentCulture);
            //            }
            //            else
            //                return "";
            //        }

            //    }
            //}

            //else
            //{

            //    if (ReturnType == "Discount")
            //        return "";
            //    else
            //        return "";
            //}

        //}


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
            EPolicy.TaskControl.Laboratory taskControl = (EPolicy.TaskControl.Laboratory )Session["TaskControl"]; 

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


            if (taskControl.Charge == 0.00)
            {
                whereClause += " and (FormName != 'ENDOSO DERRAMAS') ";
            }

            whereClause = whereClause + " and FormName != 'Reporte Reclamacion' ";

            return whereClause;
        }
        
    

       /* private string ReferringPage
        {
            get
            {
                return ((ViewState["referringPage"] != null) ?
                    ViewState["referringPage"].ToString() : "");
            }
            set
            {
                ViewState["referringPage"] = value;
            }
        }


        private void SetReferringPage()
        {
            if ((Session["FromPage"] != null) && (Session["FromPage"].ToString() != ""))
            {
                this.ReferringPage = Session["FromPage"].ToString();
                Session.Remove("FromPage");
            }
        }

        private void ReturnToReferringPage()
        {
            if (this.ReferringPage != "")
            {
                Response.Redirect(this.ReferringPage);
            }
            Response.Redirect("HomePage.aspx");
        }
        */


}

}