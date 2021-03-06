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
using System.Configuration;
using System.Collections.Generic;
using System.Globalization;
using Spire.Doc;
using Spire.Doc.Documents;

namespace EPolicy
{
    /// <summary>
    /// Summary description for Policies.
    /// </summary>
    public partial class AHCPrimaryPolicies : System.Web.UI.Page
    {
        private DataTable DtTaskPolicy;
        private DataTable DtEndorsement;
        private int userID;
        private bool prmdicAdmin = false;
        private static int taskControlID = 0;
        private static double previousPremium = 0.00;
        private static double mFactor = 0.0;
        private static double NewProRataTotPrem = 0.0;
        private static double NewShotRateTotPrem = 0.0;


        protected void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                this.litPopUp.Visible = false;
                //btnPrintCertificate.Visible = false;

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

                btnDelete = Utilities.ConfirmDialogBoxPopUp(btnDelete, "document.Pol", "Do you want delete this policy?");

                //this.btnSalvar.Attributes.Add("onclick","validatePage();");
                //this.btnImprimir.Attributes.Add("onclick","validatePage();");
                //this.btnEliminar.Attributes.Add("onclick","validatePage();");

                if (Session["AutoPostBack"] == null)
                {
                    if (!IsPostBack)
                    {
                        section1.Visible = false;
                        btnPrintPolicy.Visible = true;
                        //ddlCiudad.Attributes.Add("onchange", "getExpDt()");
                        TxtTerm.Attributes.Add("onblur", "getExpDt()");
                        TxtTerm.Attributes.Add("onchange", "getExpDt()");

                        //txtEffDt.Attributes.Add("onblur", "getExpDt();SetFieldDate()");
                        //txtEffDt.Attributes.Add("onchange", "getExpDt()");
                        txtEffDt.Attributes.Add("onblur", "getExpDt()");
                        txtEffDt.Attributes.Add("onchange", "getExpDt()");

                        //TxtZip.Attributes.Add("onblur", "SetCiudad()");
                        //ddlCiudad.Attributes.Add("onchange", "SetZipCode()");
                        //ddlCompanyDealer.Attributes.Add("onchange", "SetSupplier()");                    

                        if (Session["TaskControl"] != null)
                        {
                            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

                            if (!taskControl.isEndorsement)
                                taskControlID = taskControl.TaskControlID;

                            switch (taskControl.Mode)
                            {
                                case 1: //ADD
                                    DisableControls();
                                    FillTextControl();
                                    this.ddlPolicyClass.Enabled = false;

                                    btnEdit.Visible = false;
                                    BtnExit.Visible = false;
                                    BtnSave.Visible = true;
                                    btnChargeCalc.Visible = true;
                                    btnCancel.Visible = true;
                                    btnDelete.Visible = false;
                                    btnHistory.Visible = false;
                                    btnPrintPolicy.Visible = false;
                                    btnPrintCertificate.Visible = false;
                                    btnTailQuote.Visible = false;
                                    btnPayments.Visible = false;
                                    btnComissions.Visible = false;
                                    btnReinstatement.Visible = false;
                                    btnCancellation.Visible = false;
                                    btnFinancialCanc.Visible = false;
                                    btnPolicyCert.Visible = false;
                                    btnNew.Visible = false;

                                    ResetDllPolicyClass();
                                    GetOthersRates();
                                    CalculateOthersRates();
                                    btnEnablePrint.Visible = false;
                                    //lblEndor.Visible = false;
                                    //DataGridGroup.Visible = false;
                                    EndorsementControl(false);
                                    break;

                                case 2: //UPDATE

                                    FillTextControl();
                                    EnableControls();

                                    btnPrintCertificate.Visible = false;
                                    btnTailQuote.Visible = false;
                                    //SetControlToDisplay();

                                    if (taskControl.isEndorsement)
                                    {
                                        this.TxtFirstName.Enabled = true;
                                        this.TxtInitial.Enabled = true;
                                        this.txtLastname1.Enabled = true;
                                        this.txtLastname2.Enabled = true;
                                        EndorsementControl(true);

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
                                    FillTextControl();
                                    GetOthersRates();
                                    DisableControls();
                                    EndorsementControl(false);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (Session["TaskControl"] != null)
                        {
                            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
                            if (taskControl.Mode == 4)
                            {
                                DisableControls();
                                //CalculateCharge();
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
                //if (taskControlID == 31180)
                //{
                //    string newlimit = "50,000/100,000";
                //    ddlPrMedicalLimits.SelectedItem.Text = newlimit;
                //    ddlPrMedicalLimits.DataBind();
                //}

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

        #region VerifyAccess
        private void VerifyAccess()
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

            Login.Login cp = HttpContext.Current.User as Login.Login;




            if (cp.IsInRole("BTNHISTORYPOLICIES"))
            {
                this.btnHistory.Visible = false;
            }
            else
            {
                this.btnHistory.Visible = true;
            }

            if (!cp.IsInRole("BTNCOMMISSIONPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnComissions.Visible = false;
            }
            else
            {
                this.btnComissions.Visible = true;
            }



            if (!cp.IsInRole("BTNPAYMENTPOLICIES"))
            {
                this.btnPayments.Visible = false;
            }
            else
            {
                this.btnPayments.Visible = true;
            }

            if (!cp.IsInRole("BTNCANCELLATIONPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnCancellation.Visible = false;
                this.btnFinancialCanc.Visible = false;
            }
            else
            {
                this.btnCancellation.Visible = true;
                this.btnFinancialCanc.Visible = true;
            }

            if (!cp.IsInRole("BTNREINSTATEMENTPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnReinstatement.Visible = false;
            }
            else
            {
                this.btnReinstatement.Visible = true;
            }

            if (!cp.IsInRole("BTNDELETEPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnDelete.Visible = false;
            }
            else
            {
                this.btnDelete.Visible = true;
            }

            if (!cp.IsInRole("BTNADDPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnAdd2.Visible = false;
            }
            else
            {
                this.btnAdd2.Visible = true;
            }

            if (!cp.IsInRole("BTNEDITPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnEdit.Visible = false;
            }
            else
            {
                this.btnEdit.Visible = true;
            }

            if (!cp.IsInRole("BTNPRINTPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnPrintPolicy.Visible = false;
            }
            else
            {
                //this.btnPrintPolicy.Visible = true;
            }

            if (!cp.IsInRole("BTNNEWPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnNew.Visible = false;
            }
            else
            {
                this.btnNew.Visible = false;
            }

            if (!cp.IsInRole("BTNRATEPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnRate.Visible = false;
            }
            else
            {
                this.btnRate.Visible = true;
            }

            if (!cp.IsInRole("BTNRENEWPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnRenew.Visible = false;
            }
            else
            {
                this.btnRenew.Visible = true;
            }

            if (!cp.IsInRole("BTNSAVEPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.BtnSave.Visible = false;
            }
            else
            {
                this.BtnSave.Visible = true;
            }

            if (!cp.IsInRole("BTNDOCUMENTS") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnRegistry.Visible = false;
            }
            else
            {
                this.btnRegistry.Visible = true;
            }

            if (!cp.IsInRole("BTNPRINTCERTIFICATE") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnPrintCertificate.Visible = false;
            }
            else
            {
                //this.btnPrintCertificate.Visible = true;
            }

            if (!cp.IsInRole("DDLAGENT2") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.ddlAgent2.Visible = false;
                this.Label72.Visible = false;
            }
            else
            {
                this.ddlAgent2.Visible = true;
                this.Label72.Visible = true;
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

            if (!cp.IsInRole("BTNENABLEPRINT") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnEnablePrint.Visible = false;
            }
            else
            {
                //this.btnEnablePrint.Visible = taskControl.PrintPolicy;
            }

            if (cp.IsInRole("POWERAGENT") && taskControl.CancellationDate != "")
            {
                btnPrintCertificate.Visible = false;
                btnPrintPolicy.Visible = false;
            }

            if (cp.IsInRole("ACCOUNTING") && taskControl.CancellationDate != "")
            {
                //btnPrintPolicy.Visible = true;
            }

            if (cp.IsInRole("ACCOUNTING"))
            {
                this.btnTailQuote.Visible = true;
            }
            if (cp.IsInRole("ACCOUNTING REPORTING"))
            {
                this.btnTailQuote.Visible = false;
            }
            if (userID == 270) //Override para Hadasha Alamo. 
            {
               // btnEnablePrint.Visible = true;
            }

            if (userID == 198) //History Override button for Blanca Hernandez
            {
                this.btnHistory.Visible = true;
            }

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

                if (Session["LookUpTables"] == null)
                {
                    EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
                    int userID = 0;
                    userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                    TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

                    DataTable dtLocation = LookupTables.LookupTables.GetTable("Location");
                    //DataTable dtBank = LookupTables.LookupTables.GetTable("Bank");
                    DataTable dtAgency = LookupTables.LookupTables.GetTable("Agency");
                    DataTable dtCity = LookupTables.LookupTables.GetTable("Sucursal");
                    DataTable dtAgent = LookupTables.LookupTables.GetTable("Agent");
                    DataTable dtAgent2 = LookupTables.LookupTables.GetTable("PrimaryAgentWithSecondaryCommissions");
                    DataTable dtInsuranceCompany = LookupTables.LookupTables.GetTable("InsuranceCompany");
                    DataTable dtInsuranceCompany2 = LookupTables.LookupTables.GetTable("InsuranceCompany2");
                    DataTable dtPRMedicalLimit = LookupTables.LookupTables.GetTable("PRMedicalLimit");
                    DataTable dtPRPrimaryLimit = LookupTables.LookupTables.GetTable("PRPrimaryLimit");

                    //DataTable dtPRMEDICRATE = LookupTables.LookupTables.GetTable("PRMEDICRATE");
                    DataTable dtFinancial = LookupTables.LookupTables.GetTable("Financial");
                    DataTable dtEndorsementsType = LookupTables.LookupTables.GetTable("EndorsementsType");



                    if (taskControl.PRMedicalLimit != null)
                    {
                        string PrimaryID = taskControl.PRMedicalLimit.ToString(); //ddlPriPolLimits1.SelectedItem.Value;

                        if (PrimaryID.Trim().ToString() == "1,000,000/3,000,000")
                        {
                            PrimaryID = "1";
                        }
                        else if (PrimaryID.Trim().ToString() == "100,000/300,000")
                        {
                            PrimaryID = "10";
                        }
                        else if (PrimaryID.Trim().ToString() == "250,000/500,000")
                        {
                            PrimaryID = "5";
                        }

                        else if (PrimaryID.Trim().ToString() == "500,000/1,000,000")
                        {
                            PrimaryID = "7";
                        }



                       
                        DataTable dtPRMEDICRATE3 = EPolicy.TaskControl.Application.GetPRMEDICPrimaryRATEAHC(int.Parse(PrimaryID));


                        DataTable dtPRMEDICRATE2 = EPolicy.LookupTables.LookupTables.GetTable("PRMEDICSpecialty");
                        ddlOtherSpecialty.Items.Clear();
                        ddlOtherSpecialty.DataSource = dtPRMEDICRATE3;
                        ddlOtherSpecialty.DataTextField = "PRMEDICRATEDesc";
                        ddlOtherSpecialty.DataValueField = "PRMEDICRATEID";
                        ddlOtherSpecialty.DataBind();
                        ddlOtherSpecialty.SelectedIndex = -1;
                        ddlOtherSpecialty.Items.Insert(0, "");
                    }

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

                    //Agent
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

                    //Endorsement Type
                    ddlEndoType.DataSource = dtEndorsementsType;
                    ddlEndoType.DataTextField = "EndorsementType";
                    ddlEndoType.DataValueField = "EndorsementTypeID";
                    ddlEndoType.DataBind();
                    ddlEndoType.SelectedIndex = -1;
                    //ddlEndoType.Items.Insert(0, "");

                    //PRMedicalLimit
                    if (taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "AAE")
                        ddlPrMedicalLimits.DataSource = dtPRMedicalLimit;
                    else
                        ddlPrMedicalLimits.DataSource = dtPRPrimaryLimit;

                    //ddlPrMedicalLimits.DataTextField = "PRMedicalLimitDesc";
                    //ddlPrMedicalLimits.DataValueField = "PRMedicalLimitID";
                    //ddlPrMedicalLimits.DataBind();
                    //ddlPrMedicalLimits.SelectedIndex = -1;
                    //ddlPrMedicalLimits.Items.Insert(0, "");

                    DataTable dtPRPrimaryLimit2 = LookupTables.LookupTables.GetTable("AHCRates");
                    //PRPrimaryLimit
                    ddlPrMedicalLimits.DataSource = dtPRPrimaryLimit2;
                    ddlPrMedicalLimits.DataTextField = "PRMedicalLimitDesc";
                    ddlPrMedicalLimits.DataValueField = "PRMedicalLimitID";
                    ddlPrMedicalLimits.DataBind();
                    ddlPrMedicalLimits.SelectedIndex = -1;
                    ddlPrMedicalLimits.Items.Insert(0, "");


                    ddlPriPolLimits1.DataSource = dtPRMedicalLimit;
                    ddlPriPolLimits1.DataTextField = "PRMedicalLimitDesc";
                    ddlPriPolLimits1.DataValueField = "PRMedicalLimitID";
                    ddlPriPolLimits1.DataBind();
                    ddlPriPolLimits1.SelectedIndex = -1;
                    ddlPriPolLimits1.Items.Insert(0, "");

                    ddlPriPolLimits1.Items.Remove(ddlPriPolLimits1.Items.FindByText("900,000/2,700,000"));
                    ddlPriPolLimits1.Items.Remove(ddlPriPolLimits1.Items.FindByText("400,000/1,200,000"));


                    DataTable dtPRMEDICRATE1 = EPolicy.LookupTables.LookupTables.GetTable("PRMEDICSpecialty");
                    
                    DataTable dtSpecialty = EPolicy.TaskControl.Application.GetPRMEDICPrimaryRATEAHC(int.Parse(dtPRPrimaryLimit.Rows[0]["PRMedicalLimitID"].ToString().Trim()));

                    ddlRate.Items.Clear();
                    ddlRate.DataSource = dtSpecialty;
                    ddlRate.DataTextField = "PRMEDICRATEDesc";
                    ddlRate.DataValueField = "IsoCode";
                    ddlRate.DataBind();
                    ddlRate.SelectedIndex = -1;
                    ddlRate.Items.Insert(0, "");

                    ddlSpecialty.Items.Clear();
                    ddlSpecialty.DataSource = dtSpecialty;
                    ddlSpecialty.DataTextField = "PRMEDICRATEDesc";
                    ddlSpecialty.DataValueField = "IsoCode";
                    ddlSpecialty.DataBind();
                    ddlSpecialty.SelectedIndex = -1;
                    ddlSpecialty.Items.Insert(0, "");

                    ddlIsoCode.Items.Clear();
                    dtSpecialty.DefaultView.Sort = "IsoCode";
                    dtSpecialty = dtSpecialty.DefaultView.ToTable();
                    ddlIsoCode.DataSource = dtSpecialty;
                    ddlIsoCode.DataTextField = "IsoCode";
                    ddlIsoCode.DataValueField = "IsoCode";
                    ddlIsoCode.DataBind();
                    ddlIsoCode.SelectedIndex = -1;
                    ddlIsoCode.Items.Insert(0, "");


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

                DtSearchPayments.Visible = false;
                DtSearchPayments.DataSource = null;
                DtTaskPolicy = null;

                int policyClass = 0;
                string tempPolType = String.Empty;

                TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

                if (taskControl.PolicyType.ToString().Trim().Length >= 3 &&
                    (taskControl.PolicyType.ToString().Trim() != "AAP" && taskControl.PolicyType.ToString().Trim() != "AAE" && taskControl.PolicyType.ToString().Trim() != "PAH"))
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

                //FillDataGrid();
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
                TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

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

                if (taskControl.City != 0)
                {
                    ddlCity.SelectedIndex = ddlCity.Items.IndexOf(
                        ddlCity.Items.FindByValue(taskControl.City.ToString()));
                }

                if (taskControl.Agent != "0")
                    ddlAgent.SelectedIndex = ddlAgent.Items.IndexOf(
                        ddlAgent.Items.FindByValue(taskControl.Agent));

                if (taskControl.Agent2 != "0")
                    ddlAgent2.SelectedIndex = ddlAgent2.Items.IndexOf(
                        ddlAgent2.Items.FindByValue(taskControl.Agent2));

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

                if (taskControl.IsoCode != "")
                    ddlSpecialty.SelectedIndex = ddlSpecialty.Items.IndexOf(
                        ddlSpecialty.Items.FindByValue(taskControl.IsoCode));

                if (taskControl.IsoCode != "")
                    ddlIsoCode.SelectedIndex = ddlIsoCode.Items.IndexOf(
                        ddlIsoCode.Items.FindByValue(taskControl.IsoCode));

                if (taskControl.OtherSpecialtyID != 0)
                    ddlOtherSpecialty.SelectedIndex = ddlOtherSpecialty.Items.IndexOf(
                        ddlOtherSpecialty.Items.FindByValue(taskControl.OtherSpecialtyID.ToString()));
                //if (taskControl.OtherSpecialtyID == 0)
                //{
                //    DataTable dtPRMEDICRATE2 = EPolicy.TaskControl.Application.GetPRMEDICPrimaryRATEAHC(int.Parse(ddlPrMedicalLimits.SelectedItem.Value.ToString()));
                //    ddlOtherSpecialty.Items.Clear();
                //    ddlOtherSpecialty.DataSource = dtPRMEDICRATE2;
                //    ddlOtherSpecialty.DataTextField = "PRMEDICRATEDesc";
                //    ddlOtherSpecialty.DataValueField = "PRMEDICRATEID";
                //    ddlOtherSpecialty.DataBind();
                //    ddlOtherSpecialty.SelectedIndex = -1;
                //    ddlOtherSpecialty.Items.Insert(0, "");
                
                //}

                if (taskControl.PRMedicalLimit != 0)
                    ddlPrMedicalLimits.SelectedIndex = ddlPrMedicalLimits.Items.IndexOf(
                        ddlPrMedicalLimits.Items.FindByValue(taskControl.PRMedicalLimit.ToString()));

                //Aqui los IF

                if(taskControl.PRMedicalLimit != 0)
                {

                    if (taskControl.PRMedicalLimit == 5)
                   ddlPrMedicalLimits.SelectedItem.Text = "250,000/500,000";
                    else if  (taskControl.PRMedicalLimit == 1)
                   ddlPrMedicalLimits.SelectedItem.Text = "1,000,000/3,000,000";
                    else if (taskControl.PRMedicalLimit == 10)
                        ddlPrMedicalLimits.SelectedItem.Text = "100,000/300,000";
                    else if (taskControl.PRMedicalLimit == 7)
                        ddlPrMedicalLimits.SelectedItem.Text = "500,000/1,000,000";
                }

                if (taskControl.PriPolLimits1 != "")
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
                    //else if (taskControl.PriPolLimits1 == "150,000 /450,000")
                    //taskControl.PriPolLimits1 = "150,000/450,000";



                    ddlPriPolLimits1.SelectedIndex = ddlPriPolLimits1.Items.IndexOf(ddlPriPolLimits1.Items.FindByText(
                        taskControl.PriPolLimits1.ToString().Replace(" ", string.Empty)));

                    //if (taskControlID == 31180)
                    //{
                    //    if (taskControl.pr == "1,000,000/3,000,000")
                    //        ddlPrMedicalLimits.SelectedItem.Text = "900,000/2,700,000";

                    //}
                }
                //UpdateForm
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
                if (taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "AAE")
                    taskControl.NumberOfEmployees = txtEQuantityTN6.Text.ToString();
                else
                    taskControl.NumberOfEmployees = txtQuantityTN1.Text.ToString();
                //if (taskControl.NumberOfEmployees == null)
                //    txtNumberOfEmployees.Text = "";
                //else
                //    txtNumberOfEmployees.Text = taskControl.NumberOfEmployees.ToString();

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
                TxtProspectNo.Text = taskControl.Customer.ProspectID.ToString();
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
                txtClaimNumber.Text = taskControl.ClaimNo;
                txtAdditionalName.Text = taskControl.AdditionalName.ToString();
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
                    Label11.Text = "Canc. Date";
                }
                txtEntryDate.Text = taskControl.EntryDate.ToShortDateString();
                TxtComments.Text = taskControl.Comments.ToString();
                ChkAutoAssignPolicy.Checked = taskControl.AutoAssignPolicy;
                chkPending.Checked = taskControl.Pending;
                txtPriCarierName1.Text = taskControl.PriCarierName1;
                txtPriPolEffecDate1.Text = taskControl.PriPolEffecDate1;
                //txtPriPolLimits1.Text = taskControl.PriPolLimits1;
                txtPriClaims1.Text = taskControl.PriClaims1;

                if (taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "AAE")
                    lblCarrier.Text = "Previous Carrier Name";
                else
                    lblCarrier.Text = "Previous Carrier Name";

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

                if (taskControl.PRMedicRATEID != 0)
                {
                    for (int i = 0; i < ddlSpecialty.Items.Count; i++)
                    {
                        if (ddlSpecialty.Items[i].Value.Trim() != "")
                        {
                            string[] array = ddlSpecialty.Items[i].Value.Split('|');
                            if (taskControl.PRMedicRATEID == int.Parse(array[0]))
                            {
                                ddlSpecialty.SelectedIndex = ddlSpecialty.Items.IndexOf(
                                ddlSpecialty.Items.FindByValue(ddlSpecialty.Items[i].Value));
                            }
                        }
                    }
                }

                //if (taskControl.PRMedicRATEID != 0)
                //{
                //    for (int i = 0; i < ddlIsoCode.Items.Count; i++)
                //    {
                //        if (ddlIsoCode.Items[i].Value.Trim() != "")
                //        {
                //            string[] array = ddlIsoCode.Items[i].Value.Split('|');
                //            if (int.Parse(taskControl.IsoCode) == int.Parse(array[0]))
                //            {
                //                ddlIsoCode.SelectedIndex = ddlIsoCode.Items.IndexOf(
                //                ddlIsoCode.Items.FindByValue(ddlIsoCode.Items[i].Value));
                //            }
                //        }
                //    }
                //}

                txtIsoCode.Text = taskControl.IsoCode;
                txtClass.Text = taskControl.Class;
                txtRate1.Text = taskControl.RateYear1.ToString("###,##0.00");
                txtRate2.Text = taskControl.RateYear2.ToString("###,##0.00");
                txtRate3.Text = taskControl.RateYear3.ToString("###,##0.00");
                txtRate4.Text = taskControl.MCMRate.ToString("###,##0.00");

                TxtCharge.Text = taskControl.Charge.ToString("###,##0.00");
                // TxtPremium.Text = taskControl.RateYear1.ToString("###,##0.00");//Nuevo. Antes solo cogia el TotalPremium y lo ponia en txtPremium    Ruben            
                if (taskControl.CancellationAmount > 0) TxtCancAmount.Text = taskControl.CancellationAmount.ToString("-###,##0.00"); else TxtCancAmount.Text = "0.00";
                TxtTotalPremium.Text = ((taskControl.Charge + taskControl.TotalPremium) - taskControl.CancellationAmount).ToString("###,##0.00");
                TxtPremium.Text = taskControl.TotalPremium.ToString("###,##0.00");
                if (taskControl.CancellationAmount > 0)
                {
                    TxtPremium.Text = (taskControl.Charge + taskControl.TotalPremium).ToString("###,##0.00"); //Se agrego para cuando sea C/P Coja la Prima Inicial Alexis
                }
                taskControl.InvoiceNumber = "0"; //Discount
                if (taskControl.Bank != "000") //Bank = Group
                {
                    EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                    master = master.GetMasterPolicyDiscount(taskControl.Bank, taskControl.EffectiveDate);

                    if (taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "AAE") //Excess
                    {
                        taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                        txtRate1.Text = Math.Round(taskControl.RateYear1 - (taskControl.RateYear1 * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                        txtRate2.Text = Math.Round(taskControl.RateYear2 - (taskControl.RateYear2 * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                        txtRate3.Text = Math.Round(taskControl.RateYear3 - (taskControl.RateYear3 * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                        txtRate4.Text = Math.Round(taskControl.MCMRate - (taskControl.MCMRate * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");

                    }
                    else // Primary
                    {
                        taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                        txtRate1.Text = Math.Round(taskControl.RateYear1 - (taskControl.RateYear1 * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                        txtRate2.Text = Math.Round(taskControl.RateYear2 - (taskControl.RateYear2 * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                        txtRate3.Text = Math.Round(taskControl.RateYear3 - (taskControl.RateYear3 * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                        txtRate4.Text = Math.Round(taskControl.MCMRate - (taskControl.MCMRate * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");

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
                //txtERateTN5.Text = taskControl.ERateTN5.ToString();
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

                btnEnablePrint.Visible = taskControl.PrintPolicy;

                FillEndorsementGrid();

                DataTable DtComment = new DataTable();
                DtComment = Comment.GetComment(taskControl.TaskControlID);

                if (DtComment.Rows.Count > 0)//aqui
                {
                    btnComments.BackColor = Color.Yellow;
                    btnComments.ForeColor = Color.Black;
                }

                //if (taskControl.isEndorsement == true)//&& Session["PLEndorsement"] != null)
                //{
                //    TaskControl.Policies taskControl2 = (EPolicy.TaskControl.Policies)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControlID, userID); //(TaskControl.Policies)Session["PLEndorsement"];

                //    if (Session["PLEndorsementDate"] != null)
                //    {
                //        txtEntryDate.Text = (string)Session["PLEndorsementDate"];
                //        //txtActualPremTotal.Text = taskControl.TotalPremium.ToString("###,##0.00");
                //        //txtPreviousPremTotal.Text = taskControl2.TotalPremium.ToString("###,##0.00");
                //        //txtDiffPremTotal.Text = (taskControl.TotalPremium - taskControl2.TotalPremium).ToString("###,##0.00");

                //        Session.Remove("PLEndorsementDate");
                //    }
                //    else
                //    {
                //        if (txtEntryDate.Text.Trim() == "")
                //            txtEntryDate.Text = DateTime.Now.ToShortDateString();

                //txtActualPremTotal.Text = taskControl.TotalPremium.ToString("###,##0.00");
                //txtPreviousPremTotal.Text = taskControl2.TotalPremium.ToString("###,##0.00");
                //txtDiffPremTotal.Text = (taskControl.TotalPremium - taskControl2.TotalPremium).ToString("###,##0.00");
                //}

                //CalculateEndorsementOnlyForQuote();


                //pnlEndorsement.Visible = true;
                //Panel2.Visible = true;
                //btnReturn.Visible = true;
                ///////}

                //CalculateCharge();

                //if (double.Parse(txtTotalExcess.Text) != 0.0 || double.Parse(txtTotalPrimary.Text) != 0.0)
                //{

                //    if (taskControl.PolicyType.Trim() == "PP")
                //        TxtTotalPremium.Text = txtTotalPrimary.Text;
                //    else
                //        TxtTotalPremium.Text = txtTotalExcess.Text;
                //}
                //else
                //    TxtTotalPremium.Text = (taskControl.TotalPremium + taskControl.Charge).ToString("###,##0.00");
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

                //this.litPopUp.Text = Utilities.MakeLiteralPopUpString("A problem occured while assigning data to webpage controls.");
                //this.litPopUp.Visible = true;
            }
        }
        private void EnableControls()
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

            btnAdd2.Visible = false;
            btnNew.Visible = false;
            btnEdit.Visible = false;
            BtnExit.Visible = false;
            BtnSave.Visible = true;
            btnEnablePrint.Visible = false;
            btnChargeCalc.Visible = true;
            btnCancel.Visible = true;
            btnDelete.Visible = false;
            btnHistory.Visible = false;
            btnRegistry.Visible = false;
            //btnPrintPolicy.Visible = false;
            btnPrintCertificate.Visible = false;
            btnPayments.Visible = false;
            btnComissions.Visible = false;
            btnReinstatement.Visible = false;
            btnCancellation.Visible = false;
            btnFinancialCanc.Visible = false;
            btnPolicyCert.Visible = false;
            btnRenew.Visible = false;
            cmdRemove.Enabled = true;
            cmdSelect.Enabled = true;
            btnRate.Visible = true;
            btnPolicyCert.Visible = false;
            btnEndor.Visible = false;
            btnEnablePrint.Visible = false;

            DtSearchPayments.Visible = false;


            //lblEndor.Visible = false;
            //DataGridGroup.Visible = false;

            if (userID == 156) //Temp Override for Kayla
            {
                TxtCustomerNo.Enabled = true;
                txtExpDt.Enabled = true;
                txtExpDt.ForeColor = System.Drawing.ColorTranslator.FromHtml("Black");
            }

            if (taskControl.CancellationDate != String.Empty)
                Label11.Text = "Canc. Date";

            TxtProspectNo.Enabled = false;
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
            txtAdditionalName.Enabled = true;
            rblClaim.Enabled = true;
            txtClaimNumber.Enabled = true;

            txtPriCarierName1.Enabled = true;
            txtPriPolEffecDate1.Enabled = true;
            //txtPriPolLimits1.Enabled = true;
            ddlPriPolLimits1.Enabled = true;
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

            if (!cp.IsInRole("ADMINISTRATOR") && !cp.IsInRole("PRMDIC-USER"))
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
            ////////////////////
            chkUpdateForm.Enabled = true;
            txtGapBegDate.Enabled = true;
            txtGapBegDate2.Enabled = true;
            txtGapBegDate3.Enabled = true;
            txtGapEndDate.Enabled = true;
            txtGapEndDate2.Enabled = true;
            txtGapEndDate3.Enabled = true;
            txtNumberOfEmployees.Enabled = true;
            txtEffDt.Enabled = true;
            txtExpDt.Enabled = true;

            TxtCharge.Enabled = true;
            TxtPremium.Enabled = true;
            TxtTotalPremium.Enabled = true;
            TxtComments.Enabled = true;


            txtClass.Enabled = true;
            txtIsoCode.Enabled = true;
            ddlIsoCode.Enabled = true;
            txtRate1.Enabled = false;
            txtRate2.Enabled = false;
            txtRate3.Enabled = false;
            txtRate4.Enabled = false;
            //Panel1.Visible = false;
            ddlRate.Enabled = true;
            ddlSpecialty.Enabled = true;
            chkPending.Enabled = true;

            ddlAvailableAgent.Enabled = true;
            ddlSelectedAgent.Enabled = true;

            ddlOriginatedAt.Enabled = true;
            ddlInsuranceCompany.Enabled = true;
            ddlAgency.Enabled = true;
            ddlCity.Enabled = true;
            ddlAgent.Enabled = true;
            ddlAgent2.Enabled = true;
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

            if (taskControl.PolicyType.Trim() == "PP" || taskControl.PolicyType.Trim() == "AAP")
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

            btnTailQuote.Visible = false;

            GetOthersRates();

            DisableControlsTail();

            if (!cp.IsInRole("DISABLEBOXES"))
            {
                this.TxtProspectNo.Enabled = false;
                this.TxtFirstName.Enabled = true;
                this.TxtInitial.Enabled = true;
                this.txtLastname1.Enabled = true;
                this.txtLastname2.Enabled = true;
                this.TxtAddrs1.Enabled = true;
                this.TxtAddrs2.Enabled = true;
                this.TxtCity.Enabled = true;
                this.TxtState.Enabled = true;
                this.TxtZip.Enabled = true;
                this.txtLicense.Enabled = true;
                this.ChkAutoAssignPolicy.Enabled = true;
                this.TxtPolicyNo.Enabled = true;
                this.TxtPolicyType.Enabled = true;
                this.TxtSufijo.Enabled = true;
                this.TxtAnniversary.Enabled = true;
                this.TxtTerm.Enabled = true;
                this.TxtRetroactiveDate.Enabled = true;
                this.txtEffDt.Enabled = true;
                this.txtExpDt.Enabled = true;
                this.txtEntryDate.Enabled = true;
                this.TxtCharge.Enabled = true;
                this.TxtPremium.Enabled = true;
                this.TxtTotalPremium.Enabled = true;
                this.txtInvoiceNumber.Enabled = true;
                this.TxtComments.Enabled = true;
                this.ddlPrMedicalLimits.Enabled = true;
                this.chkPaymentGA.Enabled = true;
                this.ddlAgency.Enabled = true;
                this.ddlCity.Enabled = true;
                this.ddlAgent.Enabled = true;
                this.ddlOriginatedAt.Enabled = true;
                this.ddlInsuranceCompany.Enabled = true;
                this.ddlGroup.Enabled = true;
                this.ddlCorparation.Enabled = true;
                this.ddlFinancial.Enabled = true;
                this.ddlOtherSpecialty.Enabled = true;
                this.ddlAgent2.Enabled = true;
                this.rblClaim.Enabled = true;
                this.txtPrimaryTN1.Enabled = true;
                this.txtPrimaryTN2.Enabled = true;
                this.txtPrimaryTN3.Enabled = true;
                this.txtPrimaryTN4.Enabled = true;
                this.txtPrimaryTN5.Enabled = true;
                this.txtRateTN1.Enabled = true;
                this.txtRateTN2.Enabled = true;
                this.txtRateTN3.Enabled = true;
                this.txtRateTN4.Enabled = true;
                this.txtRateTN5.Enabled = true;
                this.txtRateTN6.Enabled = true;
                this.txtPremiumTN1.Enabled = true;
                this.txtPremiumTN2.Enabled = true;
                this.txtPremiumTN3.Enabled = true;
                this.txtPremiumTN4.Enabled = true;
                this.txtPremiumTN5.Enabled = true;
                this.txtQuantityTN1.Enabled = true;
                this.txtQuantityTN2.Enabled = true;
                this.txtQuantityTN3.Enabled = true;
                this.txtQuantityTN4.Enabled = true;
                this.txtQuantityTN5.Enabled = true;
                this.txtQuantityTN6.Enabled = true;
                this.txtTotPremTN1.Enabled = true;
                this.txtTotPremTN2.Enabled = true;
                this.txtTotPremTN3.Enabled = true;
                this.txtTotPremTN4.Enabled = true;
                this.txtTotPremTN5.Enabled = true;
                this.txtTotPremTN6.Enabled = true;
                this.txtTotalPrimary.Enabled = true;
                this.ddlRate.Enabled = true;
                this.ddlSpecialty.Enabled = true;
                this.txtIsoCode.Enabled = true;
                this.ddlIsoCode.Enabled = true;
                this.txtClass.Enabled = true;

            }
            else
            {
                this.TxtProspectNo.Enabled = false;
                this.txtClass.Enabled = false;
                this.txtIsoCode.Enabled = false;
                this.ddlIsoCode.Enabled = false;
                this.ddlRate.Enabled = false;
                this.ddlSpecialty.Enabled = false;
                this.TxtFirstName.Enabled = false;
                this.TxtInitial.Enabled = false;
                this.txtLastname1.Enabled = false;
                this.txtLastname2.Enabled = false;
                this.TxtAddrs1.Enabled = false;
                this.TxtAddrs2.Enabled = false;
                this.TxtCity.Enabled = false;
                this.TxtState.Enabled = false;
                this.TxtZip.Enabled = false;
                this.txtLicense.Enabled = false;
                this.ChkAutoAssignPolicy.Enabled = false;
                this.TxtPolicyNo.Enabled = false;
                this.TxtPolicyType.Enabled = false;
                this.TxtSufijo.Enabled = false;
                this.TxtAnniversary.Enabled = false;
                this.TxtTerm.Enabled = false;
                this.TxtRetroactiveDate.Enabled = false;
                this.txtEffDt.Enabled = false;
                this.txtExpDt.Enabled = false;
                this.txtEntryDate.Enabled = false;
                this.TxtCharge.Enabled = false;
                this.TxtPremium.Enabled = false;
                this.TxtTotalPremium.Enabled = false;
                this.txtInvoiceNumber.Enabled = false;
                this.TxtComments.Enabled = false;
                //this.ddlPrMedicalLimits.Enabled = false;
                this.chkPaymentGA.Enabled = false;
                this.ddlAgency.Enabled = false;
                this.ddlCity.Enabled = false;
                this.ddlAgent.Enabled = false;
                this.ddlOriginatedAt.Enabled = false;
                this.ddlInsuranceCompany.Enabled = false;
                this.ddlGroup.Enabled = false;
                this.ddlCorparation.Enabled = false;
                this.ddlFinancial.Enabled = false;
                this.ddlOtherSpecialty.Enabled = false;
                this.ddlAgent2.Enabled = false;
                this.rblClaim.Enabled = false;
                this.txtPrimaryTN1.Enabled = false;
                this.txtPrimaryTN2.Enabled = false;
                this.txtPrimaryTN3.Enabled = false;
                this.txtPrimaryTN4.Enabled = false;
                this.txtPrimaryTN5.Enabled = false;
                this.txtRateTN1.Enabled = false;
                this.txtRateTN2.Enabled = false;
                this.txtRateTN3.Enabled = false;
                this.txtRateTN4.Enabled = false;
                this.txtRateTN5.Enabled = false;
                this.txtRateTN6.Enabled = false;
                this.txtPremiumTN1.Enabled = false;
                this.txtPremiumTN2.Enabled = false;
                this.txtPremiumTN3.Enabled = false;
                this.txtPremiumTN4.Enabled = false;
                this.txtPremiumTN5.Enabled = false;
                this.txtQuantityTN1.Enabled = false;
                this.txtQuantityTN2.Enabled = false;
                this.txtQuantityTN3.Enabled = false;
                this.txtQuantityTN4.Enabled = false;
                this.txtQuantityTN5.Enabled = false;
                this.txtQuantityTN6.Enabled = false;
                this.txtTotPremTN1.Enabled = false;
                this.txtTotPremTN2.Enabled = false;
                this.txtTotPremTN3.Enabled = false;
                this.txtTotPremTN4.Enabled = false;
                this.txtTotPremTN5.Enabled = false;
                this.txtTotPremTN6.Enabled = false;
                this.txtTotalPrimary.Enabled = false;

            }

            if (cp.IsInRole("DISABLEBOXPOWERAGENT") && cp.IsInRole("POWERAGENT"))
            {
                this.TxtComments.Visible = false;
                this.lblComments.Visible = false;
                this.rblClaim.Visible = false;
                this.Label74.Visible = false;
                DtSearchPayments.Columns[9].Visible = false;
                this.Label53.Visible = false;
                this.txtPrimaryTN1.Visible = false;
                this.txtPrimaryTN2.Visible = false;
                this.txtPrimaryTN3.Visible = false;
                this.txtPrimaryTN4.Visible = false;
                this.txtPrimaryTN5.Visible = false;
                this.Label54.Visible = false;
                this.txtRateTN1.Visible = false;
                this.txtRateTN2.Visible = false;
                this.txtRateTN3.Visible = false;
                this.txtRateTN4.Visible = false;
                this.txtRateTN5.Visible = false;
                this.txtRateTN6.Visible = false;
                this.Label63.Visible = false;
                this.Label55.Visible = false;
                this.txtPremiumTN1.Visible = false;
                this.txtPremiumTN2.Visible = false;
                this.txtPremiumTN3.Visible = false;
                this.txtPremiumTN4.Visible = false;
                this.txtPremiumTN5.Visible = false;

            }

        }
        private void DisableControls()
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

            btnAdd2.Visible = false;
            btnNew.Visible = false;
            btnEdit.Visible = true;
            BtnExit.Visible = true;
            btnDelete.Visible = true;
            btnCancel.Visible = false;
            btnHistory.Visible = true;
            btnRegistry.Visible = true;
            btnPrintPolicy.Visible = true;
            btnPrintCertificate.Visible = true;
            btnPayments.Visible = true;
            btnComissions.Visible = true;
            btnReinstatement.Visible = true;
            btnCancellation.Visible = true;
            btnFinancialCanc.Visible = true;
            btnPolicyCert.Visible = true;
            btnRenew.Visible = true;
            cmdRemove.Enabled = false;
            cmdSelect.Enabled = false;
            btnRate.Visible = true;
            btnPrintCertificate.Visible = true;
            btnTailQuote.Visible = true;
            //btnRefresh.Visible = false;
            btnPolicyCert.Visible = false;
            btnEndor.Visible = true;
            btnEnablePrint.Visible = true;


            //if (!taskControl.isEndorsement || taskControl.Mode != 4)
            //Panel3.Visible = false;

            if (!taskControl.isEndorsement)
            {
                pnlEndorsement.Visible = false;
                lblEndorsementHistory.Visible = true;
                lblEndorsement.Visible = false;
                dtEndorsement.Visible = true;
            }

            //lblEndor.Visible = true;
            //if(DataGridGroup.Items.Count > 0)
            //    lblEndor.Visible = true;

            //DataGridGroup.Visible = true;

            //if (taskControl.Anniversary == "01")
            //    btnEnablePrint.Visible = true;
            //else
            //    btnEnablePrint.Visible = false;

            //if (userID == 1 || userID == 2 || userID == 13 || userID == 156 || userID == 225) 
            //{
            //    btnEnablePrint.Visible = true;//btnPolicyCert.Visible = true;
            //}

            DtSearchPayments.Visible = true;


            //txtEndorDate.Visible = false;
            //lblEndorDate.Visible = false;
            //chkEndorsement.Visible = false;
            txtAdditionalName.Enabled = false;
            txtGapBegDate.Enabled = false;
            txtGapBegDate2.Enabled = false;
            txtGapBegDate3.Enabled = false;
            txtGapEndDate.Enabled = false;
            txtGapEndDate2.Enabled = false;
            txtGapEndDate3.Enabled = false;
            txtNumberOfEmployees.Enabled = false;
            chkUpdateForm.Enabled = false;
            TxtCustomerNo.Enabled = false;
            TxtFirstName.Enabled = false;
            TxtProspectNo.Enabled = false;
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

            rblClaim.Enabled = false;
            txtClaimNumber.Enabled = false;

            txtPriCarierName1.Enabled = false;
            txtPriPolEffecDate1.Enabled = false;
            //txtPriPolLimits1.Enabled = false;
            ddlPriPolLimits1.Enabled = false;
            txtPriClaims1.Enabled = false;

            txtClass.Enabled = false;
            txtIsoCode.Enabled = false;
            ddlIsoCode.Enabled = false;
            txtRate1.Enabled = false;
            txtRate2.Enabled = false;
            txtRate3.Enabled = false;
            txtRate4.Enabled = false;
            chkPending.Enabled = false;

            ddlRate.Enabled = false;
            ddlSpecialty.Enabled = false;
            ddlAvailableAgent.Enabled = false;
            ddlSelectedAgent.Enabled = false;
            ddlOriginatedAt.Enabled = false;
            ddlInsuranceCompany.Enabled = false;
            ddlAgency.Enabled = false;
            ddlCity.Enabled = false;
            ddlAgent.Enabled = false;
            ddlAgent2.Enabled = false;
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

            if (!cp.IsInRole("ADMINISTRATOR") && !cp.IsInRole("PRMDIC-USER"))
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

            if (taskControl.PolicyType.Trim() == "PP" || taskControl.PolicyType.Trim() == "AAP" || taskControl.PolicyType.Trim() == "PAH")
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
                btnPrintCertificate.Visible = false;
            }

            VerifyAccess();

            if (taskControl.CancellationDate != String.Empty)
            {
                Label11.Text = "Canc. Date";
                btnRenew.Visible = false;
            }

            BtnSave.Visible = false;
            btnChargeCalc.Visible = false;

            if (taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "AAE")
            {
                //btnPrintCertificate.Visible = false;
            }

            DisableControlsTail();


        }
        private void DeleteFile(string pathAndFileName)
        {
            if (File.Exists(pathAndFileName))
                File.Delete(pathAndFileName);
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
                TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
                TaskControl.Policies taskControl2 = (TaskControl.Policies)Session["PLEndorsement"];
                EPolicy.TaskControl.Payments payments = new EPolicy.TaskControl.Payments();

                if (!taskControl.isEndorsement)
                {
                    taskControl.SavePolicies(userID);  //(userID);


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
                    PaymentPolicy pp = new PaymentPolicy();

                    FillTextControl();
                    DisableControls();
                    //----------------------------
                    History(taskControl.TaskControlID, userID, "EDIT", "POLICIES", " ");
                    //--------------------------------------
                    Session.Remove("DtPolicyDetail");

                    //Session.Add("TaskControl",taskControl);
                    //Session.Remove("TaskControl");
                    Session["TaskControl"] = taskControl;

                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy information saved successfully.");
                    this.litPopUp.Visible = true;
                }
                else
                {
                    if (txtEndoEffDate.Text != "" && (DateTime.Parse(txtExpDt.Text) < DateTime.Parse(txtEndoEffDate.Text)))
                    {
                        int monthDiference = 0;
                        monthDiference = (DateTime.Parse(txtEndoEffDate.Text).Month - DateTime.Parse(txtEffDt.Text).Month) + 12 * (DateTime.Parse(txtEndoEffDate.Text).Year - DateTime.Parse(txtExpDt.Text).Year);
                        taskControl.Term = int.Parse(TxtTerm.Text) + monthDiference;
                    }
                    taskControl.Endoso = int.Parse(txtEndorsementNo.Text);
                    taskControl.SavePolicies(userID);  //(userID);

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

                    Session.Remove("DtPolicyDetail");

                    History(taskControl.TaskControlID, userID, "ADD", "POLICIES", "ADD ENDORSEMENT");

                    //VerifyChanges(taskControl, userID);
                    AddEndorsement(taskControl.TaskControlID);

                    //ApplyEndorsement(taskControl, userID);
                    //Session["TaskControl"] = (TaskControl.Policies)Session["PLEndorsement"];
                    //taskControl = (TaskControl.Policies)Session["PLEndorsement"];
                    taskControl.isEndorsement = false;

                    FillTextControl();
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


                //}
                //catch (Exception exp)
                //{
                //this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to save this Policy. " + exp.Message);
                //this.litPopUp.Visible = true;
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

                //this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to save policy.  Please verify and try again.");
                this.litPopUp.Visible = true;
            }
        }
        private void ValidateFields()
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = 0;
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

            ArrayList errorMessages = new ArrayList();

            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

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

                if (ddlAgent.SelectedItem.Value.Trim() == "000")
                    errorMessages.Add("Please choose a agent." + "\r\n");
                else if (ddlAgent.SelectedItem.Value.Trim() == "")
                    errorMessages.Add("Please choose a agent." + "\r\n");

                if (taskControl.PolicyType.Trim() == "PP" || taskControl.PolicyType.Trim() == "AAP")
                {
                    if (((ddlGroup.SelectedItem.Value.Trim() == taskControl.Bank && taskControl.Bank != "000") || taskControl.TotalPrimary != taskControl.TotalPremium) && taskControl.isRecalculated == false && taskControl.Mode == 1)
                        //if (taskControl.isRecalculated == false)  
                        errorMessages.Add("Please calculate the premium before saving." + "\r\n");
                }
                else if (taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "AAE")
                {
                    if (((ddlGroup.SelectedItem.Value.Trim() == taskControl.Bank && taskControl.Bank != "000") || taskControl.TotalExcess != taskControl.TotalPremium) && taskControl.isRecalculated == false && taskControl.Mode == 1)
                        //if (taskControl.isRecalculated == false)  
                        errorMessages.Add("Please calculate the premium before saving." + "\r\n");
                }

                DtTaskPolicy = TaskControl.Policy.GetExactPolicies(taskControl.PolicyClassID, TxtPolicyType.Text.Trim(),
                    TxtPolicyNo.Text.Trim(), TxtCertificate.Text.Trim(), TxtSufijo.Text.Trim(),
                    "", "", userID);  //ard

                if (DtTaskPolicy.Rows.Count > 0 && !taskControl.isEndorsement && taskControl.Mode == 1)
                    errorMessages.Add("Policy Number already exists." + "\r\n");

                if (txtLicense.Text == "")
                    errorMessages.Add("License Number is requiered and can not be empty." + "\r\n");

                if (taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "AAE")
                    if (txtPriCarierName1.Text == "" || txtPriClaims1.Text == "" || txtPriPolEffecDate1.Text == "" || ddlPriPolLimits1.SelectedItem.Text == "")
                        errorMessages.Add("Primary Claims information missing." + "\r\n");

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
                TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

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

                if (ddlCity.SelectedIndex > 0 && ddlCity.SelectedIndex != null)
                    taskControl.City = int.Parse(ddlCity.SelectedItem.Value);
                else
                    taskControl.City = 0;

                //Agent
                if (ddlAgent.SelectedIndex > 0 && ddlAgent.SelectedItem != null)
                    taskControl.Agent = ddlAgent.SelectedItem.Value;
                else
                    taskControl.Agent = "000";

                //Agent2
                if (ddlAgent2.SelectedIndex > 0 && ddlAgent2.SelectedItem != null)
                    taskControl.Agent2 = ddlAgent2.SelectedItem.Value;
                else
                    taskControl.Agent2 = "000";

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
                //UpdateForm
                taskControl.UpdateForm = chkUpdateForm.Checked;
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

                if (ddlPriPolLimits1.SelectedIndex > 0 && ddlPriPolLimits1.SelectedIndex != null)
                {
                    taskControl.PriPolLimits1 = ddlPriPolLimits1.SelectedItem.Text;
                }

                //Ciudad
                //if (ddlCiudad.SelectedIndex > 0 && ddlCiudad.SelectedItem != null)
                //    taskControl.Customer.City = ddlCiudad.SelectedItem.Text;
                //else
                //    taskControl.Customer.City = "";

                taskControl.TaskControlID = int.Parse(LblControlNo.Text.Trim());
                taskControl.Customer.CustomerNo = TxtCustomerNo.Text.Trim();
                taskControl.Customer.FirstName = TxtFirstName.Text.ToUpper().Trim();
                //taskControl.Customer.ProspectID = TxtProspectNo.Text;
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
                taskControl.AdditionalName = txtAdditionalName.Text.ToString().Trim();
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
                //taskControl.PriPolLimits1 = txtPriPolLimits1.Text.Trim().ToUpper();
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
                            if (taskControl.Mode == 2 && cp.IsInRole("MODIFICAREXPDATE"))
                            {
                                taskControl.ExpirationDate = DateTime.Parse(this.txtExpDt.Text).ToShortDateString();
                            }
                            else if (taskControl.Mode == 1)
                            {
                                taskControl.ExpirationDate = DateTime.Parse(this.txtEffDt.Text).AddMonths(int.Parse(this.TxtTerm.Text.Trim())).ToShortDateString();
                                this.txtExpDt.Text = taskControl.ExpirationDate;
                            }
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

                taskControl.ClaimNo = txtClaimNumber.Text;
                taskControl.PRMedicRATEID = int.Parse(ddlRate.SelectedItem.Value);

                Session["TaskControl"] = taskControl;
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
            Session.Clear();
            Response.Redirect("MainMenu.aspx");
        }
        protected void btnCancel_Click(object sender, System.EventArgs e)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

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
                if (taskControl.isEndorsement)
                {
                    TaskControl.TaskControl taskControl2 = TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControlID, userID);

                    pnlEndorsement.Visible = false;
                    lblEndorsement.Visible = false;
                    chkUserMod.Checked = false;
                    txtEndoComments.Text = String.Empty;
                    txtEndoEffDate.Text = String.Empty;
                    txtEndoPremium.Text = String.Empty;
                    ddlEndoType.SelectedIndex = -1;
                    taskControl.isEndorsement = false;

                    Session.Clear();
                    Session["TaskControl"] = taskControl2;
                    Response.Redirect("AHCPrimaryPolicies.aspx?" + taskControl.TaskControlID, true);



                }
                Session.Clear();
                Response.Redirect("MainMenu.aspx");
            }
            else
            {
                taskControl = (TaskControl.Policies)TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControl.TaskControlID, userID);
                taskControl.Mode = (int)TaskControl.TaskControl.TaskControlMode.CLEAR;
                Session["TaskControl"] = taskControl;
                FillTextControl();
                DisableControls();

                if (taskControl.PolicyType.ToString().Trim().Length > 2)
                    DisableControlsTail();

            }
        }

        private string PrintRegister(string rdlcDocument)
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
                string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

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
                if (registry.LicenciaDate != "")
                {
                    if (registry.LicenciaDate == "06/31/2016" && taskControl.TaskControlID == 50200)
                    {
                        compareResultLicense = -1;
                    }
                    else
                    {
                        compareResultLicense = DateTime.Compare(DateTime.Parse(registry.LicenciaDate.Trim()), DateTime.Now);
                    }

                    if (compareResultLicense < 0)
                    {
                        licenseexpdate = "(EXP) " + registry.LicenciaDate.Trim();
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
                    return rdlcDocument;

                #endregion

                ReportParameter[] param = new ReportParameter[13];
                param[0] = new ReportParameter("ASSMCADate", assmcadate);
                param[1] = new ReportParameter("JuntaLicenciamiento", juntaLicenciamiento);
                param[2] = new ReportParameter("CDMDate", cdmdate);
                param[3] = new ReportParameter("GStandingDate", gstandingdate);
                param[4] = new ReportParameter("LicenseExpDate", licenseexpdate);
                param[5] = new ReportParameter("CVDate", tp6);
                param[6] = new ReportParameter("DEADate", deadate);

                LookupTables.Agency agency = new LookupTables.Agency();

                agency = agency.GetAgency(taskControl.Agency);

                param[9] = new ReportParameter("Agency", agency.AgencyDesc);

                param[7] = new ReportParameter("Asegurado", taskControl.Customer.FirstName + " " + taskControl.Customer.Initial + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2);
                param[8] = new ReportParameter("PolizaNo", taskControl.PolicyType.Trim() + "-" + taskControl.PolicyNo);
                //param [9] = new ReportParameter("Agency",taskControl.Agency.ToString());
                //param [10] = new ReportParameter("Productor", taskControl.Agent.ToString());
                LookupTables.Agent agent = new LookupTables.Agent();

                agent = agent.GetAgent(taskControl.Agent);

                param[10] = new ReportParameter("Productor", agent.AgentDesc);

                param[11] = new ReportParameter("EffDt", taskControl.EffectiveDate);

                if (TxtPolicyType.Text.Trim() == "PP")
                {
                    param[12] = new ReportParameter("EntryDt", "");
                }
                else
                {
                    param[12] = new ReportParameter("EntryDt", "X"); //AQUI
                }

                if (TxtPolicyType.Text.Trim() == "PE" && taskControl.InsuranceCompany.ToString() == "000")
                {
                    param[12] = new ReportParameter("EntryDt", "");
                }
			    



                DataTable DtTask = TaskControl.TaskControl.GetTaskControlByCustomerNo(taskControl.Customer.CustomerNo);


                viewer.LocalReport.SetParameters(param);
                viewer.LocalReport.Refresh();

                // Variables 
                Warning[] warnings;
                string[] streamIds;
                string mimeType;
                string encoding = string.Empty;
                string extension;
                string _FileName = rdlcDocument + registry.RegistryID.ToString().Trim() + ".pdf";

                if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                    File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }

                return ProcessedPath + _FileName;

            }
            catch (Exception ex)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(ex.Message + " " + ex.InnerException + " " + ex.Source);
                this.litPopUp.Visible = true;
                return rdlcDocument;
            }
        }

        private string PrintUpdateForm(string rdlcDocument)
        {
            try
            {
                TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
                ReportViewer viewer = new ReportViewer();
                string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                viewer.LocalReport.DataSources.Clear();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportPath = Server.MapPath("Reports/" + rdlcDocument);

                viewer.LocalReport.Refresh();

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
        private string PrintInvoiceForm(string rdlcDocument)
        {
            try
            {
                TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
                ReportViewer viewer = new ReportViewer();
                string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                viewer.LocalReport.DataSources.Clear();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportPath = Server.MapPath("Reports/" + rdlcDocument);
                ReportParameter[] param = new ReportParameter[14];
                param[0] = new ReportParameter("Agency", ddlAgency.SelectedItem.Text.ToString());
                param[1] = new ReportParameter("Aniv", taskControl.Anniversary.ToString());
                param[2] = new ReportParameter("CustomerName", taskControl.Customer.FirstName + " " + taskControl.Customer.LastName1.ToString() + " " + taskControl.Customer.LastName2.ToString());
                param[3] = new ReportParameter("Adds1", taskControl.Customer.Address1.ToString());
                param[4] = new ReportParameter("Adds2", taskControl.Customer.Address2.ToString());
                param[5] = new ReportParameter("TotalPremium", TxtTotalPremium.Text.ToString());
                param[6] = new ReportParameter("PolicyNo", taskControl.PolicyType.ToString() + "-" + taskControl.PolicyNo.ToString());
                param[7] = new ReportParameter("EffectiveDate", taskControl.EffectiveDate.ToString());
                param[8] = new ReportParameter("Adds3", taskControl.Customer.City.ToString() + ", " + taskControl.Customer.State.ToString() + "," + taskControl.Customer.ZipCode.ToString());
                if (taskControl.PolicyType.Trim().Contains("A"))
                    param[9] = new ReportParameter("Aspen", "SI");
                else
                    param[9] = new ReportParameter("Aspen", "NO");

                param[10] = new ReportParameter("Premium", TxtPremium.Text.ToString());
                param[11] = new ReportParameter("Descuento", "");
                param[12] = new ReportParameter("DescuentoCantidad", "");
                if (taskControl.Bank != "000") //Bank = Group
                {
                    EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                    master = master.GetMasterPolicyDiscount(taskControl.Bank, taskControl.EffectiveDate);

                    if (taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "AAE") //Excess
                    {
                        param[11] = new ReportParameter("Descuento", (master.DescuentoExcess / 100).ToString());
                        param[12] = new ReportParameter("DescuentoCantidad", Math.Round(Double.Parse(TxtPremium.Text.ToString()) * master.DescuentoExcess / 100).ToString());
                    }
                    else
                    {
                        param[11] = new ReportParameter("Descuento", (master.DescuentoPrimario / 100).ToString());
                        param[12] = new ReportParameter("DescuentoCantidad", Math.Round(Double.Parse(TxtPremium.Text.ToString()) * master.DescuentoExcess / 100).ToString());
                    }
                }
                param[13] = new ReportParameter("GroupName", ddlGroup.SelectedItem.Text.ToString());
                viewer.LocalReport.SetParameters(param);
                viewer.LocalReport.Refresh();

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
        public static DataTable GetAgencyDesc(string AgencyID)
        {
            DataTable dt = new DataTable();

            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("AgencyID",
                SqlDbType.VarChar, 10, AgencyID.ToString(),
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

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

            dt = exec.GetQuery("GetAgencyDesc", xmlDoc);
            return dt;
        }
        public static DataTable GetAgentDesc(int AgentID)
        {
            DataTable dt = new DataTable();

            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("AgentID",
                SqlDbType.Int, 0, AgentID.ToString(),
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

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

            dt = exec.GetQuery("GetAgentByAgentID", xmlDoc);
            return dt;
        }
        private string VerifyFileName(string fileName)
        {
            if (fileName.Contains("/"))
            {
                fileName = fileName.Replace("/", "_");
            }

            if (fileName.Contains("\\"))
            {
                fileName = fileName.Replace("\\", "_");
            }

            if (fileName.Contains("|"))
            {
                fileName = fileName.Replace("|", "_");
            }

            if (fileName.Contains(":"))
            {
                fileName = fileName.Replace(":", "_");
            }

            if (fileName.Contains("*"))
            {
                fileName = fileName.Replace("*", "_");
            }

            if (fileName.Contains("?"))
            {
                fileName = fileName.Replace("?", "_");
            }

            if (fileName.Contains("\""))
            {
                fileName = fileName.Replace("\"", "_");
            }

            if (fileName.Contains("<"))
            {
                fileName = fileName.Replace("<", "_");
            }

            if (fileName.Contains(">"))
            {
                fileName = fileName.Replace(">", "_");
            }

            return fileName;
        }
        private List<string> PrintCertificate(string certID, int counter, List<string> mergePathsCertificate)
        {
            TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
            List<string> mergePaths2 = new List<string>();

            string _FileName = String.Empty;

            try
            {
                string In = "1";
                if (In == "1")
                {
                    string ReportPath = "";
                    if (taskControl.PolicyType.Trim() == "PAH" || taskControl.PolicyType.Trim() == "CPA")
                    {
                        ReportPath = "Reports/Allied/PrimaryAlliedPolicyCertificate.rdlc";
                    }
                    else
                    {
                        ReportPath = "Reports/PrimaryPolicyCertificate.rdlc";
                    }
                    if (taskControl.PolicyType.Trim() == "CLP" || taskControl.PolicyType.Trim() == "CLE")
                    {
                        ReportPath = "Reports/LaboratoryPolicyCertificate.rdlc";
                    }

                    ReportViewer viewer = new ReportViewer();
                    viewer.LocalReport.ReportPath = Server.MapPath(ReportPath);
                    viewer.LocalReport.DataSources.Clear();
                    viewer.ProcessingMode = ProcessingMode.Local;


                    GetCertificateInformationTableAdapters.GetCertificateLocationByCertificateLocationIDTableAdapter ta1 =
                    new GetCertificateInformationTableAdapters.GetCertificateLocationByCertificateLocationIDTableAdapter();
                    GetCertificateInformationTableAdapters.GetCustomerCertificateInfoTableAdapter ta2 =
                    new GetCertificateInformationTableAdapters.GetCustomerCertificateInfoTableAdapter();
                    GetCertificateInformationTableAdapters.GetCertificateHistoryTableAdapter ta3 =
                    new GetCertificateInformationTableAdapters.GetCertificateHistoryTableAdapter();
                    GetCertificateInformationTableAdapters.GetPRMEDICSpecialtyByTaskControlIDTableAdapter ta4 =
                    new GetCertificateInformationTableAdapters.GetPRMEDICSpecialtyByTaskControlIDTableAdapter();

                    GetCertificateInformation.GetCertificateLocationByCertificateLocationIDDataTable certDt =
                    new GetCertificateInformation.GetCertificateLocationByCertificateLocationIDDataTable();
                    GetCertificateInformation.GetCustomerCertificateInfoDataTable cusDt =
                    new GetCertificateInformation.GetCustomerCertificateInfoDataTable();
                    GetCertificateInformation.GetCertificateHistoryDataTable hisDt =
                    new GetCertificateInformation.GetCertificateHistoryDataTable();
                    GetCertificateInformation.GetPRMEDICSpecialtyByTaskControlIDDataTable specDt =
                    new GetCertificateInformation.GetPRMEDICSpecialtyByTaskControlIDDataTable();

                    ta1.Fill(certDt, certID);
                    ta2.Fill(cusDt, taskControl.TaskControlID);
                    ta3.Fill(hisDt);
                    string tempPolType = String.Empty;
                    if (taskControl.PolicyType.Trim() == "AAP")
                        tempPolType = "PP";
                    else if (taskControl.PolicyType.Trim() == "APC")
                        tempPolType = "CP";
                    else
                        tempPolType = taskControl.PolicyType.Trim();

                    ta4.Fill(specDt, tempPolType.Trim(), taskControl.TaskControlID);

                    if (taskControl.PolicyType.ToString().Trim() == "PP" || taskControl.PolicyType.ToString().Trim() == "PE" || taskControl.PolicyType.ToString().Trim() == "AAP" || taskControl.PolicyType.ToString().Trim() == "AAE")
                        cusDt.Rows[0]["CustomerName"] = "Dr. " + cusDt.Rows[0]["CustomerName"];
                    if (taskControl.PolicyType.Trim() == "EMD" || taskControl.PolicyType.Trim() == "EMDT")
                    {

                    }
                    else if (specDt.Rows.Count > 0)
                    {
                        if (specDt.Rows[0]["Other Specialty"].ToString() == "")
                            specDt.Rows[0]["Other Specialty"] = " ";
                        else specDt.Rows[0]["Other Specialty"] += " /";
                    }
                    else { }


                    Microsoft.Reporting.WebForms.ReportDataSource rptDataSource1 =
                    new Microsoft.Reporting.WebForms.ReportDataSource("GetCertificateInformation_GetCertificateLocationByCertificateLocationID", certDt);
                    Microsoft.Reporting.WebForms.ReportDataSource rptDataSource2 =
                    new Microsoft.Reporting.WebForms.ReportDataSource("GetCertificateInformation_GetCustomerCertificateInfo", cusDt);
                    Microsoft.Reporting.WebForms.ReportDataSource rptDataSource3 =
                    new Microsoft.Reporting.WebForms.ReportDataSource("GetCertificateInformation_GetCertificateHistory", hisDt);
                    Microsoft.Reporting.WebForms.ReportDataSource rptDataSource4 =
                    new Microsoft.Reporting.WebForms.ReportDataSource("GetCertificateInformation_GetPRMEDICSpecialtyByTaskControlID", specDt);
                    string agencydesc = "";
                    DataTable dt = new DataTable();
                    dt = GetAgencyDesc(taskControl.Agency);
                    agencydesc = dt.Rows[0]["AgencyDesc"].ToString().Trim();
                    string agentdesc = "";
                    DataTable dtagent = new DataTable();
                    dtagent = GetAgentDesc(int.Parse(taskControl.Agent));
                    agentdesc = dtagent.Rows[0]["AgentDesc"].ToString().Trim();


                    #region Gap Dates
                    if (taskControl.PolicyType.Trim() == "PP" || taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "PPT" || taskControl.PolicyType.Trim() == "PET" || taskControl.PolicyType.Trim() == "AAP" || taskControl.PolicyType.Trim() == "AAPT" || taskControl.PolicyType.Trim() == "PAH")
                    {
                        //-------Initialize reports parameters----
                        ReportParameter[] param = new ReportParameter[11];
                        //--------------------prueba certificado gap dates de PP------------------
                        if (taskControl.GapBegDate == "" || taskControl.GapEndDate == "")
                        {
                            param[0] = new ReportParameter("gapbegdate", "");
                            param[1] = new ReportParameter("gapenddate", "");
                        }
                        else
                        {
                            param[0] = new ReportParameter("gapbegdate", taskControl.GapBegDate.ToString().Trim());
                            param[1] = new ReportParameter("gapenddate", taskControl.GapEndDate.ToString().Trim());
                        }
                        if (taskControl.GapBegDate2 == "" || taskControl.GapEndDate2 == "")
                        {
                            param[2] = new ReportParameter("gapbegdate2", "");
                            param[3] = new ReportParameter("gapenddate2", "");

                        }
                        else
                        {
                            param[2] = new ReportParameter("gapbegdate2", taskControl.GapBegDate2.ToString().Trim());
                            param[3] = new ReportParameter("gapenddate2", taskControl.GapEndDate2.ToString().Trim());
                        }
                        if (taskControl.GapBegDate3 == "" || taskControl.GapEndDate3 == "")
                        {
                            param[4] = new ReportParameter("gapbegdate3", "");
                            param[5] = new ReportParameter("gapenddate3", "");
                        }
                        else
                        {
                            param[4] = new ReportParameter("gapbegdate3", taskControl.GapBegDate3.ToString().Trim());
                            param[5] = new ReportParameter("gapenddate3", taskControl.GapEndDate3.ToString().Trim());
                        }
                        if (taskControl.NumberOfEmployees == "")
                        {
                            param[6] = new ReportParameter("numberEmp", "0");
                        }
                        else
                        {
                            param[6] = new ReportParameter("numberEmp", taskControl.NumberOfEmployees.ToString());
                        }

                        TaskControl.Policies taskControl2 = (TaskControl.Policies)Session["TaskControl"];
                        if (taskControl2.TotPremTN1 <= 0 && taskControl2.TotPremTN2 <= 0 && taskControl2.TotPremTN3 <= 0 && taskControl2.TotPremTN4 <= 0 && taskControl2.TotPremTN5 <= 0)
                        {
                            param[7] = new ReportParameter("otherPersonel", "0");
                        }
                        else
                        {

                            double Equantity1 = taskControl2.TotPremTN1 == 0.0 ? 0.0 : 1.0;
                            double Equantity2 = taskControl2.TotPremTN2 == 0.0 ? 0.0 : 1.0;
                            double Equantity3 = taskControl2.TotPremTN3 == 0.0 ? 0.0 : 1.0;
                            double Equantity4 = taskControl2.TotPremTN4 == 0.0 ? 0.0 : 1.0;
                            double Equantity5 = taskControl2.TotPremTN5 == 0.0 ? 0.0 : 1.0;
                            double Equantity6 = Equantity1 + Equantity2 + Equantity3 + Equantity4 + Equantity5;

                            string ho = Equantity6.ToString();

                            string hi = taskControl2.EQuantityTN6.ToString();
                            param[7] = new ReportParameter("otherPersonel", ho);

                        }
                        param[8] = new ReportParameter("agencydesc", agencydesc);
                        param[9] = new ReportParameter("agentdesc", agentdesc);
                        param[10] = new ReportParameter("addName", taskControl.AdditionalName.ToString().Trim());
                        //---------------------------termina prueba certificado gap dates------------
                        viewer.LocalReport.SetParameters(param);
                        viewer.LocalReport.Refresh();
                    }
                    else if (taskControl.PolicyType.Trim() == "CP" || taskControl.PolicyType.Trim() == "CE" || taskControl.PolicyType.Trim() == "CPT" || taskControl.PolicyType.Trim() == "CET" || taskControl.PolicyType.Trim() == "APC" || taskControl.PolicyType.Trim() == "CPA")
                    {
                        TaskControl.CorporatePolicyQuote taskControlCorporate = (TaskControl.CorporatePolicyQuote)Session["TaskControl"];
                        //-------Initialize reports parameters----
                        ReportParameter[] param = new ReportParameter[11];
                        //--------------------prueba certificado gap dates de CP------------------
                        if (taskControlCorporate.GapBegDate == "" || taskControlCorporate.GapEndDate == "")
                        {
                            param[0] = new ReportParameter("gapbegdate", "");
                            param[1] = new ReportParameter("gapenddate", "");
                        }
                        else
                        {
                            param[0] = new ReportParameter("gapbegdate", taskControlCorporate.GapBegDate.ToString());
                            param[1] = new ReportParameter("gapenddate", taskControlCorporate.GapEndDate.ToString());
                        }
                        if (taskControlCorporate.GapBegDate2 == "" || taskControlCorporate.GapEndDate2 == "")
                        {
                            param[2] = new ReportParameter("gapbegdate2", "");
                            param[3] = new ReportParameter("gapenddate2", "");

                        }
                        else
                        {
                            param[2] = new ReportParameter("gapbegdate2", taskControlCorporate.GapBegDate2.ToString());
                            param[3] = new ReportParameter("gapenddate2", taskControlCorporate.GapEndDate2.ToString());
                        }
                        if (taskControlCorporate.GapBegDate3 == "" || taskControlCorporate.GapEndDate3 == "")
                        {
                            param[4] = new ReportParameter("gapbegdate3", "");
                            param[5] = new ReportParameter("gapenddate3", "");
                        }
                        else
                        {
                            param[4] = new ReportParameter("gapbegdate3", taskControlCorporate.GapBegDate3.ToString());
                            param[5] = new ReportParameter("gapenddate3", taskControlCorporate.GapEndDate3.ToString());
                        }
                        if (taskControlCorporate.NumberOfEmployees == "")
                        {
                            param[6] = new ReportParameter("numberEmp", "");
                        }
                        else
                        {
                            param[6] = new ReportParameter("numberEmp", taskControlCorporate.NumberOfEmployees.ToString());
                        }
                        if (taskControlCorporate.OtherPersonel == "")
                        {
                            param[7] = new ReportParameter("otherPersonel", "0");
                        }
                        else
                        {
                            param[7] = new ReportParameter("otherPersonel", taskControlCorporate.OtherPersonel.ToString());
                        }
                        param[8] = new ReportParameter("agencydesc", agencydesc);
                        param[9] = new ReportParameter("agentdesc", agentdesc);
                        param[10] = new ReportParameter("addName", taskControlCorporate.AdditionalName.ToString().Trim());
                        //---------------------------termina prueba certificado gap dates------------
                        viewer.LocalReport.SetParameters(param);
                        viewer.LocalReport.Refresh();
                    }
                    else if (taskControl.PolicyType.Trim() == "CLP" || taskControl.PolicyType.Trim() == "CLE" || taskControl.PolicyType.Trim() == "CLPT" || taskControl.PolicyType.Trim() == "CLET")
                    {
                        TaskControl.Laboratory taskControlLab = (TaskControl.Laboratory)Session["TaskControl"];
                        //-------Initialize reports parameters----
                        ReportParameter[] param = new ReportParameter[12];

                        //--------------------prueba certificado gap dates de CLP------------------
                        if (taskControlLab.GapBegDate == "" || taskControlLab.GapEndDate == "")
                        {
                            param[0] = new ReportParameter("gapbegdate", "");
                            param[1] = new ReportParameter("gapenddate", "");
                        }
                        else
                        {
                            param[0] = new ReportParameter("gapbegdate", taskControlLab.GapBegDate.ToString());
                            param[1] = new ReportParameter("gapenddate", taskControlLab.GapEndDate.ToString());
                        }
                        if (taskControlLab.GapBegDate2 == "" || taskControlLab.GapEndDate2 == "")
                        {
                            param[2] = new ReportParameter("gapbegdate2", "");
                            param[3] = new ReportParameter("gapenddate2", "");

                        }
                        else
                        {
                            param[2] = new ReportParameter("gapbegdate2", taskControlLab.GapBegDate2.ToString());
                            param[3] = new ReportParameter("gapenddate2", taskControlLab.GapEndDate2.ToString());
                        }
                        if (taskControlLab.GapBegDate3 == "" || taskControlLab.GapEndDate3 == "")
                        {
                            param[4] = new ReportParameter("gapbegdate3", "");
                            param[5] = new ReportParameter("gapenddate3", "");
                        }
                        else
                        {
                            param[4] = new ReportParameter("gapbegdate3", taskControlLab.GapBegDate3.ToString());
                            param[5] = new ReportParameter("gapenddate3", taskControlLab.GapEndDate3.ToString());
                        }
                        if (taskControlLab.NumberOfEmployees == "")
                        {
                            param[6] = new ReportParameter("numberEmp", "");
                        }
                        else
                        {
                            param[6] = new ReportParameter("numberEmp", taskControlLab.NumberOfEmployees.ToString());
                        }

                        param[7] = new ReportParameter("limitDesc1", taskControlLab.LimitsDesc.Split('/')[0].ToString());
                        param[8] = new ReportParameter("limitDesc2", taskControlLab.LimitsDesc.Split('/')[1].ToString());
                        param[9] = new ReportParameter("agencydesc", agencydesc);
                        param[10] = new ReportParameter("agentdesc", agentdesc);
                        param[11] = new ReportParameter("addName", taskControlLab.AdditionalName.ToString().Trim());
                        //---------------------------termina prueba certificado gap dates------------
                        viewer.LocalReport.SetParameters(param);
                        viewer.LocalReport.Refresh();
                    }
                    else
                    {
                        TaskControl.Cyber taskControlCyber = (TaskControl.Cyber)Session["TaskControl"];
                        //-------Initialize reports parameters----
                        ReportParameter[] param = new ReportParameter[9];
                        //--------------------prueba certificado gap dates de PP------------------
                        if (taskControlCyber.GapBegDate == "" || taskControlCyber.GapEndDate == "")
                        {
                            param[0] = new ReportParameter("gapbegdate", "");
                            param[1] = new ReportParameter("gapenddate", "");
                        }
                        else
                        {
                            param[0] = new ReportParameter("gapbegdate", taskControlCyber.GapBegDate.ToString());
                            param[1] = new ReportParameter("gapenddate", taskControlCyber.GapEndDate.ToString());
                        }
                        if (taskControlCyber.GapBegDate2 == "" || taskControlCyber.GapEndDate2 == "")
                        {
                            param[2] = new ReportParameter("gapbegdate2", "");
                            param[3] = new ReportParameter("gapenddate2", "");

                        }
                        else
                        {
                            param[2] = new ReportParameter("gapbegdate2", taskControlCyber.GapBegDate2.ToString());
                            param[3] = new ReportParameter("gapenddate2", taskControlCyber.GapEndDate2.ToString());
                        }
                        if (taskControlCyber.GapBegDate3 == "" || taskControlCyber.GapEndDate3 == "")
                        {
                            param[4] = new ReportParameter("gapbegdate3", "");
                            param[5] = new ReportParameter("gapenddate3", "");
                        }
                        else
                        {
                            param[4] = new ReportParameter("gapbegdate3", taskControlCyber.GapBegDate3.ToString());
                            param[5] = new ReportParameter("gapenddate3", taskControlCyber.GapEndDate3.ToString());
                        }
                        param[6] = new ReportParameter("agencydesc", agencydesc);
                        param[7] = new ReportParameter("agentdesc", agentdesc);
                        param[8] = new ReportParameter("addName", taskControlCyber.AdditionalName.ToString().Trim());
                        //---------------------------termina prueba certificado gap dates------------
                        viewer.LocalReport.SetParameters(param);
                        viewer.LocalReport.Refresh();
                    }
                    #endregion

                    viewer.LocalReport.DataSources.Add(rptDataSource1);
                    viewer.LocalReport.DataSources.Add(rptDataSource2);
                    viewer.LocalReport.DataSources.Add(rptDataSource3);
                    viewer.LocalReport.DataSources.Add(rptDataSource4);
                    viewer.LocalReport.Refresh();

                    ReportParameterInfoCollection paramCol = viewer.LocalReport.GetParameters();
                    ReportParameter rp1 = new ReportParameter(paramCol[0].Name, certID);
                    ReportParameter rp2 = new ReportParameter(paramCol[1].Name, taskControl.InsuranceCompany);

                    viewer.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2 });

                    // Variables 
                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType;
                    string encoding = string.Empty;
                    string extension;
                    string fileName = VerifyFileName(@cusDt.Rows[0]["CustomerName"].ToString().Trim() + counter);
                    _FileName = VerifyFileName(@cusDt.Rows[0]["CustomerName"].ToString().Trim() + counter + ".pdf");

                    //??????
                    if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                        File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

                    byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                    using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }
                    mergePathsCertificate.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

                }


            }
            catch (Exception ecp)
            {
                throw new Exception(ecp.Message + "/" + ecp.InnerException);
            }

            return mergePathsCertificate;
        }

        protected void btnPrintPolicy_Click(object sender, System.EventArgs e)
        {
            try
            {
                TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
                Login.Login cp = HttpContext.Current.User as Login.Login;
                string userName = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();
                string limit = ddlPrMedicalLimits.SelectedItem.Text.ToString().Trim();
                List<string> mergePaths2 = new List<string>();

                if (taskControl.Customer.FirstName.ToUpper().Contains("??") || taskControl.Customer.LastName1.ToUpper().Contains("??") || taskControl.Customer.LastName2.ToUpper().Contains("??"))
                {
                    taskControl.Customer.FirstName = taskControl.Customer.FirstName.Replace("??", "N");
                    taskControl.Customer.LastName1 = taskControl.Customer.LastName1.Replace("??", "N");
                    taskControl.Customer.LastName2 = taskControl.Customer.LastName2.Replace("??", "N");
                }
                if (taskControl.City == 66)
                    taskControl.City = 80;

                if (taskControl.CancellationDate != String.Empty)
                {
                    #region Cancellation Credit
                    ReportViewer viewer = new ReportViewer();
                    viewer.LocalReport.ReportPath = Server.MapPath("Reports/AlliedCancellationCredit.rdlc");
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
                    //??????
                    if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                        File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

                    byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                    using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }

                    History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED CANCELLATION CREDIT");

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + _FileName + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                    #endregion
                }
                else if (taskControl.PolicyType.Trim() == "PAH" || taskControl.PolicyType.Trim() == "PE")
                {
                    if (taskControl.Anniversary == "01")
                    {
                        #region Primary Policy
                        if (!taskControl.PrintPolicy && DateTime.Parse(taskControl.EffectiveDate.Trim()) < DateTime.Parse("08/01/2015"))//&& prmdicAdmin)
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

                            ////////////////Certificado de Estefania///////////////
                            List<string> mergePaths = new List<string>();
                            string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];
                            EPolicy2.Reports.ExportFile expFile = new EPolicy2.Reports.ExportFile();
                            string _FileName = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];
                            ///////////////////////////////////////////////////////

                            rpt = new EPolicy2.Reports.PRMdic.Invoice((EPolicy.TaskControl.Policy)taskControl, false);
                            rpt.Document.Printer.PrinterName = "";
                            rpt.Run(false);
                            //rpt = rpt28;

                            rpt3 = new EPolicy2.Reports.PRMdic.PrimaryPolicy((EPolicy.TaskControl.Policy)taskControl);
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

                            if (DateTime.Parse(taskControl.EffectiveDate.Trim()).ToShortDateString() != DateTime.Parse(taskControl.RetroactiveDate.Trim()).ToShortDateString())
                            {
                                rpt27 = new EPolicy2.Reports.PRMdic.AlliedPrimaryPriorAct((EPolicy.TaskControl.Policy)taskControl, false);
                                rpt27.Document.Printer.PrinterName = "";
                                rpt27.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt27.Document.Pages);
                            }

                            if (taskControl.Charge > 0)//TxtCharge.Text != ".00")
                            {
                                //rpt29 = new EPolicy2.Reports.PRMdic.ChargeEng((EPolicy.TaskControl.Policy)taskControl);
                                //rpt29.Document.Printer.PrinterName = "";
                                //rpt29.Run(false);
                                //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt29.Document.Pages);

                                mergePaths.Add(PrintWordProcessedPath("PolicyType = 'ALL' and FormName = 'ENDOSO DERRAMAS'", false));

                                //aqui
                            }

                            ///////////Estefania Certificados///////////
                            _FileName = _FileName + userName + ".PDF";
                            string invoice = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + "Invoice" + taskControl.TaskControlID + ".pdf";
                            expFile.ExportToPDF(rpt.Document, _FileName);
                            mergePaths.Add(_FileName);
                            //mergePaths2 = PrintCertificate("295", 1, mergePaths);//Certificado Nuevo Pedidio por Estefania
                            CreatePDFBatch mergeFinal = new CreatePDFBatch();
                            string FinalFile = "";
                            FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl.Customer.FirstName + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2);
                            taskControl.PrintPolicy = true;
                            taskControl.PrintDate = DateTime.Now.ToShortDateString();
                            taskControl.Mode = 2;
                            FillProperties();
                            taskControl.SavePolicies(userID);
                            History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY RENOVATION DOCUMENT.");
                            RemoveSessionLookUp();
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                            ///////////////////////////////

                            ////Funtion Print Policy
                            //taskControl.PrintPolicy = true;
                            //taskControl.PrintDate = DateTime.Now.ToShortDateString();
                            //taskControl.Mode = 2;
                            //FillProperties();
                            //History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY.");
                            //taskControl.SavePolicies(userID);

                            //RemoveSessionLookUp();
                            //Session.Add("Report", rpt);
                            //Session.Add("TaskControl", taskControl);
                            //Session.Add("FromPage", "AHCPrimaryPolicies.aspx");
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

                            ////////////////Certificado de Estefania///////////////
                            List<string> mergePaths = new List<string>();
                            string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];
                            EPolicy2.Reports.ExportFile expFile = new EPolicy2.Reports.ExportFile();
                            string _FileName = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];
                            ///////////////////////////////////////////////////////

                            rpt = new EPolicy2.Reports.PRMdic.InvoiceAllied(taskControl, false);
                            rpt.Document.Printer.PrinterName = "";
                            rpt.Run(false); //aqui

                            rpt1 = new EPolicy2.Reports.PRMdic.AlliedPortada((EPolicy.TaskControl.Policy)taskControl, false);
                            rpt1.Document.Printer.PrinterName = "";
                            rpt1.Run();
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt1.Document.Pages);

                            rpt2 = new EPolicy2.Reports.PRMdic.AlliedDeclarations((EPolicy.TaskControl.Policy)taskControl, false);
                            rpt2.Document.Printer.PrinterName = "";
                            rpt2.Run();
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages);

                            rpt3 = new EPolicy2.Reports.PRMdic.AlliedDeclarationsPage2((EPolicy.TaskControl.Policy)taskControl, false);
                            rpt3.Document.Printer.PrinterName = "";
                           // rpt3.Run();
                           // rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages);


                            rpt4 = new EPolicy2.Reports2.PRMdic.AlliedPage1();
                            rpt4.Document.Printer.PrinterName = "";
                            rpt4.Run();
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt4.Document.Pages);

                            rpt5 = new EPolicy2.Reports2.PRMdic.AlliedPage2();
                            rpt5.Document.Printer.PrinterName = "";
                            rpt5.Run();
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt5.Document.Pages);

                            rpt6 = new EPolicy2.Reports2.PRMdic.AlliedPage3();
                            rpt6.Document.Printer.PrinterName = "";
                            rpt6.Run();
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt6.Document.Pages);

                            rpt7 = new EPolicy2.Reports2.PRMdic.AlliedPage4();
                            rpt7.Document.Printer.PrinterName = "";
                            rpt7.Run();
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt7.Document.Pages);

                            rpt8 = new EPolicy2.Reports2.PRMdic.AlliedPage5();
                            rpt8.Document.Printer.PrinterName = "";
                            rpt8.Run();
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt8.Document.Pages);

                            rpt9 = new EPolicy2.Reports2.PRMdic.AlliedPage6();
                            rpt9.Document.Printer.PrinterName = "";
                            rpt9.Run();
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt9.Document.Pages);

                            rpt10 = new EPolicy2.Reports2.PRMdic.AlliedPage7();
                            rpt10.Document.Printer.PrinterName = "";
                            rpt10.Run();
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt10.Document.Pages);

                            rpt11 = new EPolicy2.Reports2.PRMdic.AlliedPage8();
                            rpt11.Document.Printer.PrinterName = "";
                            rpt11.Run();
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt11.Document.Pages);

                            rpt12 = new EPolicy2.Reports2.PRMdic.AlliedPage9();
                            rpt12.Document.Printer.PrinterName = "";
                            rpt12.Run();
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt12.Document.Pages);

                            rpt13 = new EPolicy2.Reports2.PRMdic.AlliedPage10();
                            rpt13.Document.Printer.PrinterName = "";
                            rpt13.Run();
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt13.Document.Pages);

                            rpt14 = new EPolicy2.Reports2.PRMdic.AlliedPage11((EPolicy.TaskControl.Policy)taskControl);
                            rpt14.Document.Printer.PrinterName = "";
                            rpt14.Run();
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt14.Document.Pages);

                            rpt15 = new EPolicy2.Reports2.PRMdic.PrimaryPolicyNew14();
                            rpt15.Document.Printer.PrinterName = "";
                            //rpt15.Run();
                            //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt15.Document.Pages);

                            rpt16 = new EPolicy2.Reports2.PRMdic.PrimaryPolicyNew15((EPolicy.TaskControl.Policy)taskControl);
                            rpt16.Document.Printer.PrinterName = "";
                           // rpt16.Run();
                            //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt16.Document.Pages);

                            rpt17 = new EPolicy2.Reports.PRMdic.AlliedSchedule((EPolicy.TaskControl.Policy)taskControl, false);
                            rpt17.Document.Printer.PrinterName = "";
                            rpt17.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt17.Document.Pages);

                            rpt18 = new EPolicy2.Reports.PRMdic.PrimaryStatementAcceptance((EPolicy.TaskControl.Policy)taskControl, false);
                            rpt18.Document.Printer.PrinterName = "";
                            //rpt18.Run(false);
                            //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt18.Document.Pages);

                            rpt19 = new EPolicy2.Reports2.PRMdic.AlliedMandatoryPage1();
                            rpt19.Document.Printer.PrinterName = "";
                            rpt19.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt19.Document.Pages); //Page 4 

                            rpt20 = new EPolicy2.Reports2.PRMdic.AlliedMandatoryPage2();
                            rpt20.Document.Printer.PrinterName = "";
                            rpt20.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt20.Document.Pages); //Page 5

                            rpt21 = new EPolicy2.Reports.PRMdic.PrimaryMandatory3();
                            rpt21.Document.Printer.PrinterName = "";
                            //rpt21.Run(false);
                            //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt21.Document.Pages);

                            rpt22 = new EPolicy2.Reports.PRMdic.AlliedRenewalEndorsement((EPolicy.TaskControl.Policy)taskControl, false);
                            rpt22.Document.Printer.PrinterName = "";
                            rpt22.Run(false);
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt22.Document.Pages);

                            rpt23 = new EPolicy2.Reports.PRMdic.PrimaryActOfWar((EPolicy.TaskControl.Policy)taskControl, false);
                            rpt23.Document.Printer.PrinterName = "";
                           // rpt23.Run(false);
                           //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt23.Document.Pages);

                            rpt24 = new EPolicy2.Reports.PRMdic.PrimaryNuclearEnergy();
                            rpt24.Document.Printer.PrinterName = "";
                           //rpt24.Run(false);
                           // rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt24.Document.Pages);

                            rpt25 = new EPolicy2.Reports.PRMdic.PrimaryNuclearEnergy2();
                            rpt25.Document.Printer.PrinterName = "";
                            //rpt25.Run(false);
                            //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt25.Document.Pages);

                            if (DateTime.Parse(taskControl.EffectiveDate.Trim()).ToShortDateString() != DateTime.Parse(taskControl.RetroactiveDate.Trim()).ToShortDateString())
                            {
                                rpt26 = new EPolicy2.Reports.PRMdic.AlliedPrimaryPriorAct((EPolicy.TaskControl.Policy)taskControl, false);
                                rpt26.Document.Printer.PrinterName = "";
                                rpt26.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt26.Document.Pages);
                            }

                            //if (taskControl.Charge > 0)//TxtCharge.Text != ".00")
                            //{
                                //rpt27 = new EPolicy2.Reports.PRMdic.ChargeEng((EPolicy.TaskControl.Policy)taskControl);
                                //rpt27.Document.Printer.PrinterName = "";
                                //rpt27.Run(false);
                                //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt27.Document.Pages);
                                //aqui
                            //}
                            //   mergePaths.Add(PrintWordProcessedPath("PolicyType = 'ALL' and FormName = 'ENDOSO DERRAMAS'", false));
                            //}

                            ///////////Estefania Certificados///////////
                            _FileName = _FileName + userName + ".PDF";
                            string invoice = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + "Invoice" + taskControl.TaskControlID + ".pdf";
                            expFile.ExportToPDF(rpt.Document, _FileName);
                            mergePaths.Add(_FileName);
                            //mergePaths2 = PrintCertificate("295", 1, mergePaths);//Certificado Nuevo Pedidio por Estefania
                            CreatePDFBatch mergeFinal = new CreatePDFBatch();
                            string FinalFile = "";

                            if (taskControl.Charge > 0)//TxtCharge.Text != ".00")
                            {
                                mergePaths.Add(PrintWordProcessedPath("PolicyType = 'ALL' and FormName = 'ENDOSO DERRAMAS'", false));
                            }
                            FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl.Customer.FirstName + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2);
                            
                            taskControl.PrintPolicy = true;
                            taskControl.PrintDate = DateTime.Now.ToShortDateString();
                            taskControl.Mode = 2;
                            FillProperties();
                            taskControl.SavePolicies(userID);
                            History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY RENOVATION DOCUMENT.");
                            RemoveSessionLookUp();
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                            ///////////////////////////////

                           
                            //taskControl.PrintPolicy = true;
                            //taskControl.PrintDate = DateTime.Now.ToShortDateString();
                            //taskControl.Mode = 2;
                            //FillProperties();
                            //History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY.");
                            //taskControl.SavePolicies(userID);

                            //RemoveSessionLookUp();
                            //Session.Add("Report", rpt);
                            //Session.Add("TaskControl", taskControl);
                            //Session.Add("FromPage", "AHCPrimaryPolicies.aspx");
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

                            List<string> mergePaths = new List<string>();
                            string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                            DataDynamics.ActiveReports.ActiveReport3 rpt = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt3 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt4 = null;

                            EPolicy2.Reports.ExportFile expFile = new EPolicy2.Reports.ExportFile();
                            string _FileName = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                            //if (taskControl.PolicyType.Trim() != "PAH") 
                            //{
                                //mergePaths.Add(PrintRegister("Report2.rdlc"));
                                mergePaths.Add(PrintWordProcessedPath("PolicyType = 'PAH' and FormName = 'CREDENCIALES RENOVACION'", false));
                            //}

                            rpt = new EPolicy2.Reports.PRMdic.InvoiceAllied(taskControl, false);
                            rpt.Document.Printer.PrinterName = "";
                            rpt.Run(false);

                            rpt2 = new EPolicy2.Reports.PRMdic.AlliedRenewalEndorsement2(taskControl, false);
                            //rpt2 = new EPolicy2.Reports2.PRMdic.AlliedPage1();
                            rpt2.Document.Printer.PrinterName = "";
                            rpt2.Run();
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages);

                            //if (taskControl.Charge > 0)//(TxtCharge.Text != ".00")
                            //{
                                //rpt3 = new EPolicy2.Reports.PRMdic.ChargeEng((EPolicy.TaskControl.Policy)taskControl);
                                //rpt3.Document.Printer.PrinterName = "";
                                //rpt3.Run(false);
                                //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages);
                                //mergePaths.Add(PrintWordProcessedPath("PolicyType = 'ALL' and FormName = 'ENDOSO DERRAMAS'", false));
                            //}
                            if (DateTime.Parse(taskControl.EffectiveDate.Trim()) > DateTime.Parse("08/01/2015") && DateTime.Parse(taskControl.EffectiveDate.Trim()) < DateTime.Parse("08/01/2016"))
                            {
                                rpt4 = new EPolicy2.Reports.PRMdic.P_116New(taskControl);
                                rpt4.Document.Printer.PrinterName = "";
                                rpt4.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt4.Document.Pages);
                            }

                            _FileName = _FileName + userName + ".PDF";
                            string invoice = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + "Invoice" + taskControl.TaskControlID + ".pdf";
                            expFile.ExportToPDF(rpt.Document, _FileName);

                            mergePaths.Add(_FileName);

                            if (taskControl.InsuranceCompany != "002")
                                mergePaths.Add(PrintUpdateForm("Carta_Dept_Defensa.rdlc"));

                            if (chkUpdateForm.Checked && DateTime.Parse(taskControl.EffectiveDate) >= DateTime.Parse("01/01/2015") && taskControl.InsuranceCompany != "002")
                            {
                                //mergePaths.Add(PrintUpdateForm("F102BA.rdlc"));
                                //mergePaths.Add(PrintUpdateForm("F102BB.rdlc"));
                                //mergePaths.Add(PrintUpdateForm("F102BC.rdlc"));
                                //mergePaths.Add(PrintUpdateForm("F102BD.rdlc"));

                                History(taskControl.TaskControlID, userID, "UPDATEFORM", "POLICIES", "PRINT POLICY & MARKED UPDATE FORM.");
                            }

                            //mergePaths2 = PrintCertificate("295", 1, mergePaths);//Certificado Nuevo Pedidio por Estefania

                            CreatePDFBatch mergeFinal = new CreatePDFBatch();
                            string FinalFile = "";
                            if (taskControl.Charge > 0)//(TxtCharge.Text != ".00")
                            {
                                mergePaths.Add(PrintWordProcessedPath("PolicyType = 'ALL' and FormName = 'ENDOSO DERRAMAS'", false));
                            }
                            FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl.Customer.FirstName + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2);

                            taskControl.PrintPolicy = true;
                            taskControl.PrintDate = DateTime.Now.ToShortDateString();
                            taskControl.Mode = 2;
                            FillProperties();
                            taskControl.SavePolicies(userID);

                            History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY RENOVATION DOCUMENT.");


                            RemoveSessionLookUp();

                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                            //taskControl.PrintPolicy = true;
                            //taskControl.PrintDate = DateTime.Now.ToShortDateString();
                            //taskControl.Mode = 2;
                            //FillProperties();
                            //taskControl.SavePolicies(userID);

                            //History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY RENOVATION DOCUMENT.");

                            //RemoveSessionLookUp();
                            //Session.Add("Report", rpt);
                            //Session.Add("TaskControl", taskControl);
                            //Session.Add("Renewal", true);
                            //Session.Add("FromPage", "Policies.aspx");
                            //Response.Redirect("ActiveXViewer.aspx?true");                          
                        }
                        else //Print Policy Lock
                        {
                            this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy Printing has been disabled.  Please contact your supervisor.");
                            this.litPopUp.Visible = true;
                        }
                        #endregion
                    }
                }
                else if (taskControl.PolicyType.Trim() == "PPT")
                {
                    #region Primary Tail
                    DataDynamics.ActiveReports.ActiveReport3 rpt = null;

                    rpt = new EPolicy2.Reports.PRMdic.TailEndorsement((EPolicy.TaskControl.Policy)taskControl);
                    rpt.Document.Printer.PrinterName = "";
                    rpt.Run(false);

                    RemoveSessionLookUp();
                    Session.Add("Report", rpt);
                    Session.Add("TaskControl", taskControl);
                    Session.Add("FromPage", "Policies.aspx");
                    Response.Redirect("ActiveXViewer.aspx");

                    History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED TAIL ENDORSEMENT.");
                    #endregion
                }

                else if (taskControl.PolicyType.Trim() == "PE")//PE
                {
                    if (taskControl.Anniversary == "01")
                    {
                        #region Excess Policy
                        if (!taskControl.PrintPolicy && DateTime.Parse(taskControl.EffectiveDate.Trim()) < DateTime.Parse("08/01/2015"))//&& prmdicAdmin)
                        {
                            List<string> mergePaths = new List<string>();
                            string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];
                            EPolicy2.Reports.ExportFile expFile = new EPolicy2.Reports.ExportFile();
                            string _FileName = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];
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

                            mergePaths.Add(PrintInvoiceForm("Invoice.rdlc"));
                            //rpt32 = new EPolicy2.Reports.PRMdic.Invoice(taskControl, false);//Ruben
                            //rpt32.Document.Printer.PrinterName = "";
                            //rpt32.Run(false);
                            //rpt = rpt32;

                            rpt1 = new EPolicy2.Reports.PRMdic.Poliza((EPolicy.TaskControl.Policy)taskControl);
                            rpt1.Document.Printer.PrinterName = "";
                            rpt1.Run();
                            rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt1.Document.Pages); ;

                            rpt2 = new EPolicy2.Reports.PRMdic.Poliza1(taskControl, false, limit);
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

                            if (DateTime.Parse(taskControl.EffectiveDate.Trim()).ToShortDateString() != DateTime.Parse(taskControl.RetroactiveDate.Trim()).ToShortDateString())
                            {
                                rpt29 = new EPolicy2.Reports.PRMdic.PriorAct(taskControl, false);
                                rpt29.Document.Printer.PrinterName = "";
                                rpt29.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt29.Document.Pages); //Page 3
                            }

                            if (taskControl.Charge > 0)//(TxtCharge.Text != ".00")
                            {
                                rpt33 = new EPolicy2.Reports.PRMdic.ChargeEng((EPolicy.TaskControl.Policy)taskControl);
                                rpt33.Document.Printer.PrinterName = "";
                                rpt33.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt33.Document.Pages);
                            }
                            _FileName = _FileName + userName + ".PDF";
                            string invoice = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + "Invoice" + taskControl.TaskControlID + ".pdf";
                            expFile.ExportToPDF(rpt.Document, _FileName);

                            mergePaths.Add(_FileName);
                            //taskControl.PrintPolicy = true;
                            //taskControl.PrintDate = DateTime.Now.ToShortDateString();
                            //taskControl.Mode = 2;
                            //FillProperties();
                            //History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY.");
                            //taskControl.SavePolicies(userID);


                            CreatePDFBatch mergeFinal = new CreatePDFBatch();
                            string FinalFile = "";
                            FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl.Customer.FirstName + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2);
                            taskControl.PrintPolicy = true;
                            taskControl.PrintDate = DateTime.Now.ToShortDateString();
                            taskControl.Mode = 2;
                            FillProperties();
                            taskControl.SavePolicies(userID);
                            History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY.");
                            RemoveSessionLookUp();

                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);

                            //Session.Add("Report", rpt);
                            //Session.Add("TaskControl", taskControl);
                            //Session.Add("FromPage", "Policies.aspx");
                            //Response.Redirect("ActiveXViewer.aspx");
                        }
                        else if (!taskControl.PrintPolicy && DateTime.Parse(taskControl.EffectiveDate.Trim()) >= DateTime.Parse("08/01/2015"))
                        {
                            List<string> mergePaths = new List<string>();
                            string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];
                            EPolicy2.Reports.ExportFile expFile = new EPolicy2.Reports.ExportFile();
                            string _FileName = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];
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

                            mergePaths.Add(PrintInvoiceForm("Invoice.rdlc"));
                            //rpt = new EPolicy2.Reports.PRMdic.Invoice(taskControl, false);//Ruben
                            //rpt.Document.Printer.PrinterName = "";
                            //rpt.Run(false);

                            rpt = new EPolicy2.Reports2.PRMdic.PolizaNew();
                            rpt.Document.Printer.PrinterName = "";
                            rpt.Run(false);
                            // rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt1.Document.Pages); ;

                            rpt2 = new EPolicy2.Reports.PRMdic.Poliza1(taskControl, false, limit);
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

                            _FileName = _FileName + userName + ".PDF";
                            string invoice = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + "Invoice" + taskControl.TaskControlID + ".pdf";
                            expFile.ExportToPDF(rpt.Document, _FileName);

                            mergePaths.Add(_FileName);
                            CreatePDFBatch mergeFinal = new CreatePDFBatch();
                            string FinalFile = "";
                            FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl.Customer.FirstName + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2);

                            taskControl.PrintPolicy = true;
                            taskControl.PrintDate = DateTime.Now.ToShortDateString();
                            taskControl.Mode = 2;
                            FillProperties();
                            History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY.");
                            taskControl.SavePolicies(userID);

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
                        #region Excess Renovation
                        if (!taskControl.PrintPolicy) //Proof that the renovation was printed.
                        {
                            List<string> mergePaths = new List<string>();
                            string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                            DataDynamics.ActiveReports.ActiveReport3 rpt = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt3 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt4 = null;

                            EPolicy2.Reports.ExportFile expFile = new EPolicy2.Reports.ExportFile();
                            string _FileName = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                           // mergePaths.Add(PrintRegister("Report2.rdlc"));
                            mergePaths.Add(PrintWordProcessedPath("PolicyType = 'PAH' and FormName = 'CREDENCIALES RENOVACION'", false));

                            rpt = new EPolicy2.Reports.PRMdic.Invoice(taskControl, false);//Ruben
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

                            if (DateTime.Parse(taskControl.EffectiveDate.Trim()) > DateTime.Parse("08/01/2015") && DateTime.Parse(taskControl.EffectiveDate.Trim()) < DateTime.Parse("08/01/2016"))
                            {
                                rpt4 = new EPolicy2.Reports.PRMdic.E_116New(taskControl);
                                rpt4.Document.Printer.PrinterName = "";
                                rpt4.Run();
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt4.Document.Pages);
                            }

                            _FileName = _FileName + userName + ".PDF";
                            string invoice = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + "Invoice" + taskControl.TaskControlID + ".pdf";
                            expFile.ExportToPDF(rpt.Document, _FileName);

                            mergePaths.Add(_FileName);

                            if (taskControl.InsuranceCompany != "002")
                                mergePaths.Add(PrintUpdateForm("Carta_Dept_Defensa.rdlc"));

                            if (chkUpdateForm.Checked && DateTime.Parse(taskControl.EffectiveDate) >= DateTime.Parse("01/01/2015") && taskControl.InsuranceCompany != "002")
                            {
                                //mergePaths.Add(PrintUpdateForm("F102BA.rdlc"));
                                //mergePaths.Add(PrintUpdateForm("F102BB.rdlc"));
                                //mergePaths.Add(PrintUpdateForm("F102BC.rdlc"));
                                //mergePaths.Add(PrintUpdateForm("F102BD.rdlc"));

                                History(taskControl.TaskControlID, userID, "UPDATEFORM", "POLICIES", "PRINT POLICY & MARKED UPDATE FORM.");
                            }

                            CreatePDFBatch mergeFinal = new CreatePDFBatch();
                            string FinalFile = "";
                            FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl.Customer.FirstName + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2);


                            taskControl.PrintPolicy = true;
                            taskControl.PrintDate = DateTime.Now.ToShortDateString();
                            taskControl.Mode = 2;
                            FillProperties();
                            taskControl.SavePolicies(userID);

                            History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY RENOVATION DOCUMENT.");

                            RemoveSessionLookUp();

                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                            //Session.Add("Report", rpt);
                            //Session.Add("TaskControl", taskControl);
                            //Session.Add("Renewal", true);
                            //Session.Add("FromPage", "Policies.aspx");
                            //Response.Redirect("ActiveXViewer.aspx?true");
                        }
                        else //Print Policy Lock
                        {
                            this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy Printing has been disabled.  Please contact your supervisor.");
                            this.litPopUp.Visible = true;
                        }
                        #endregion
                    }
                }
                else if (taskControl.PolicyType.Trim() == "PET")
                {
                    #region Excess Tail
                    DataDynamics.ActiveReports.ActiveReport3 rpt = null;

                    rpt = new EPolicy2.Reports.PRMdic.TailEndorsement((EPolicy.TaskControl.Policy)taskControl);
                    rpt.Document.Printer.PrinterName = "";
                    rpt.Run(false);

                    RemoveSessionLookUp();
                    Session.Add("Report", rpt);
                    Session.Add("TaskControl", taskControl);
                    Session.Add("FromPage", "Policies.aspx");
                    Response.Redirect("ActiveXViewer.aspx");

                    History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED TAIL ENDORSEMENT.");
                    #endregion
                }
                else if (taskControl.PolicyType.Trim() == "AAP")
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

                            rpt2 = new EPolicy2.Reports.PRMdic.Invoice((EPolicy.TaskControl.Policy)taskControl, false);//Ruben
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
                            btnEnablePrint.Visible = true;
                            taskControl.Mode = 2;
                            FillProperties();
                            History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY.");
                            taskControl.SavePolicies(userID);

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

                            List<string> mergePaths = new List<string>();
                            string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                            DataDynamics.ActiveReports.ActiveReport3 rpt = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;
                            DataDynamics.ActiveReports.ActiveReport3 rpt3 = null;

                            EPolicy2.Reports.ExportFile expFile = new EPolicy2.Reports.ExportFile();
                            string _FileName = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];


                            rpt = new EPolicy2.Reports.PRMdic.Invoice(taskControl, false);//Ruben
                            rpt.Document.Printer.PrinterName = "";
                            rpt.Run(false);


                            if (taskControl.Charge > 0)//(TxtCharge.Text != ".00")
                            {
                                rpt3 = new EPolicy2.Reports.PRMdic.ChargeEng((EPolicy.TaskControl.Policy)taskControl);
                                rpt3.Document.Printer.PrinterName = "";
                                rpt3.Run(false);
                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt3.Document.Pages);
                            }

                            //Descomentar cuando verifiquen el reporte
                            _FileName = _FileName + userName + ".PDF";
                            string invoice = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + "Invoice" + taskControl.TaskControlID + ".pdf";
                            expFile.ExportToPDF(rpt.Document, _FileName);

                            mergePaths.Add(_FileName);
                            mergePaths.Add(PrintAspenPolicy("RenewalEndorsementAspen1.rdlc"));

                            CreatePDFBatch mergeFinal = new CreatePDFBatch();
                            string FinalFile = "";
                            FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl.Customer.FirstName + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2);
                            ///////////////////////////                            

                            taskControl.PrintPolicy = true;
                            taskControl.PrintDate = DateTime.Now.ToShortDateString();
                            taskControl.Mode = 2;
                            FillProperties();
                            taskControl.SavePolicies(userID);

                            History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY RENOVATION DOCUMENT.");



                            RemoveSessionLookUp();
                            //Comentar cuando verifiquen el reporte de renovaciones Aspen
                            //Session.Add("Report", rpt);
                            //Session.Add("TaskControl", taskControl);
                            //Session.Add("Renewal", true);
                            //Session.Add("FromPage", "Policies.aspx");
                            //Response.Redirect("ActiveXViewer.aspx?true");
                            //Descomentar cuado verifiquen el reporte
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                        }
                        else //Print Policy Lock
                        {
                            this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Policy Printing has been disabled.  Please contact your supervisor.");
                            this.litPopUp.Visible = true;
                        }
                        #endregion
                    }
                }
                else if (taskControl.PolicyType.Trim() == "AAPT")
                {
                    #region Primary Tail ASPEN
                    DataDynamics.ActiveReports.ActiveReport3 rpt = null;

                    rpt = new EPolicy2.Reports.PRMdic.TailEndorsement((EPolicy.TaskControl.Policy)taskControl);
                    rpt.Document.Printer.PrinterName = "";
                    rpt.Run(false);

                    RemoveSessionLookUp();
                    Session.Add("Report", rpt);
                    Session.Add("TaskControl", taskControl);
                    Session.Add("FromPage", "Policies.aspx");
                    Response.Redirect("ActiveXViewer.aspx");

                    History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED TAIL ENDORSEMENT.");
                    #endregion
                }

                else if (taskControl.PolicyType.Trim() == "AAE")//PE
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


                            rpt2 = new EPolicy2.Reports.PRMdic.Invoice((EPolicy.TaskControl.Policy)taskControl, false);//Ruben
                            rpt2.Document.Printer.PrinterName = "";
                            rpt2.Run(false); //Invoice

                            rpt = new EPolicy2.Reports.PRMdic.Poliza1((EPolicy.TaskControl.Policy)taskControl, false, limit);
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
                            btnEnablePrint.Visible = true;
                            taskControl.Mode = 2;
                            FillProperties();
                            History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY.");
                            taskControl.SavePolicies(userID);

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


                            rpt = new EPolicy2.Reports.PRMdic.Invoice(taskControl, false);//Ruben
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
                            taskControl.Mode = 2;
                            FillProperties();
                            taskControl.SavePolicies(userID);

                            History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED POLICY RENOVATION DOCUMENT.");

                            RemoveSessionLookUp();
                            Session.Add("Report", rpt);
                            Session.Add("TaskControl", taskControl);
                            Session.Add("Renewal", true);
                            Session.Add("FromPage", "Policies.aspx");
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
                else if (taskControl.PolicyType.Trim() == "AAET")
                {
                    #region Excess Tail ASPEN
                    DataDynamics.ActiveReports.ActiveReport3 rpt = null;

                    rpt = new EPolicy2.Reports.PRMdic.TailEndorsement((EPolicy.TaskControl.Policy)taskControl);
                    rpt.Document.Printer.PrinterName = "";
                    rpt.Run(false);

                    RemoveSessionLookUp();
                    Session.Add("Report", rpt);
                    Session.Add("TaskControl", taskControl);
                    Session.Add("FromPage", "Policies.aspx");
                    Response.Redirect("ActiveXViewer.aspx");

                    History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED TAIL ENDORSEMENT.");
                    #endregion
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
        protected void btnEdit_Click(object sender, System.EventArgs e)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
            taskControl.Mode = (int)TaskControl.TaskControl.TaskControlMode.UPDATE;
            Login.Login cp = HttpContext.Current.User as Login.Login;

            Session.Add("TaskControl", taskControl);

            GetLastAgentSelected();
            EnableControls();


            if (!cp.IsInRole("ADMINISTRATOR") && !cp.IsInRole("SUBSCRIPTION"))
            {
                this.TxtFirstName.Enabled = false;
                this.TxtInitial.Enabled = false;
                this.txtLastname1.Enabled = false;
                this.txtLastname2.Enabled = false;
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

            btnPrintCertificate.Visible = false;
            btnTailQuote.Visible = false;
            pnlEndorsement.Visible = false;
            dtEndorsement.Visible = false;
            lblEndorsementHistory.Visible = false;
            SetControlToDisplay();
        }
        protected void btnDelete_Click(object sender, System.EventArgs e)
        {
            //if (bool.Parse(ConfirmDialogBoxPopUp.Value.Trim()) == true)
            //{
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
            try
            {
                int i = taskControl.TaskControlID;
                TaskControl.Policies.DeletePoliciesByTaskControlID(i);

                taskControl = new TaskControl.Policies();
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
            //}
        }
        protected void btnReinstatement_Click(object sender, System.EventArgs e)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
            TaskControl.Policy policy = (TaskControl.Policy)Session["TaskControl"];
            TaskControl.Policies policies = new TaskControl.Policies();

            try
            {
                ValidateReinstatement(policies, taskControl);

                policies = taskControl;
                policies.Mode = 2;
                policies.CancellationDate = "";
                policies.CancellationEntryDate = "";
                policies.CancellationUnearnedPercent = 0.00;
                policies.CancellationMethod = 0;
                policies.CancellationReason = 0;
               // policies.EntryDate = DateTime.Now;
                policies.PaidAmount = taskControl.PaidAmount;
                policies.PaidDate = "";
                policies.Ren_Rei = "RI";
                policies.Rein_Amt = taskControl.CancellationAmount;
                policies.PaidDate = taskControl.PaidDate;
                policies.CommissionAgency = taskControl.ReturnCommissionAgency;
                policies.CommissionAgent = taskControl.ReturnCommissionAgent;
                policies.CommissionAgencyPercent = taskControl.CommissionAgencyPercent.Trim();
                policies.CommissionAgentPercent = taskControl.CommissionAgentPercent.Trim();
                //policies.TotalPremium = taskControl.ReturnPremium;
                //policies.Charge = taskControl.ReturnCharge;
                policies.ReturnCharge = 0.00;
                policies.ReturnPremium = 0.00;
                policies.CancellationAmount = 0.00;
                policies.ReturnCommissionAgency = 0.00;
                policies.ReturnCommissionAgent = 0.00;
                //policies.TaskControlID = 0;
                policies.Status = "Inforce";


                if (Session["DtPolicyDetail"] != null)
                {
                    policies.PolicyDetailcs.PolicyDetailTableTemp = (DataTable)Session["DtPolicyDetail"];
                }

                //int msufijo;
                //int sufijo = int.Parse(taskControl.Suffix);
                //msufijo = sufijo + 1;
                //policies.Suffix = "0".ToString() + msufijo.ToString();

                History(taskControl.TaskControlID, userID, "REINST.", "POLICIES", "REINSTATED POLICY.");

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

            if (mStatus != "Cancelled")  //Verifica si la p??liza se encuentra cancelada.
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
        protected void btnCancellation_Click(object sender, System.EventArgs e)
        {
            try
            {
                RemoveSessionLookUp();
                Session.Add("FromUI", "AHCPrimaryPolicies.aspx");
                Response.Redirect("CancellationPolicy.aspx", false);
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }
        }
        protected void btnFinancialCanc_Click(object sender, EventArgs e)
        {
            RemoveSessionLookUp();
            Session.Add("FromUI", "AHCPrimaryPolicies.aspx");
            Response.Redirect("FinancialCancellations.aspx", false);
        }
        protected void btnPayments_Click(object sender, System.EventArgs e)
        {
            RemoveSessionLookUp();
            Session.Add("FromPage", "AHCPrimaryPolicies.aspx");
            Response.Redirect("ViewPayment.aspx");
        }
        protected void btnComissions_Click(object sender, System.EventArgs e)
        {
            RemoveSessionLookUp();
            Session.Add("FromPage", "AHCPrimaryPolicies.aspx");
            Response.Redirect("ViewCommission.aspx");
        }
        protected void btnHistory_Click(object sender, System.EventArgs e)
        {
            if (Session["TaskControl"] != null)
            {
                RemoveSessionLookUp();
                TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
                Response.Redirect("SearchAuditItems.aspx?type=31&taskControlID=" +
                    taskControl.TaskControlID.ToString().Trim());
            }
        }
        private void History(int taskControlID, int userID, string action, string subject, string note)
        {
            Audit.History history = new Audit.History();
            TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];

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
            // Se le A???ade uno para visualizar el pr???ximo nivel a seleccionarse ???
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
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

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
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

            taskControl.AgentSelectedTable = TaskControl.Policy.GetSelectedAgent(taskControl.TaskControlID);

            Session.Add("TaskControl", taskControl);

            SetddlSelectedAgent(taskControl.AgentSelectedTable);
            ddlSelectedAgentOrder();

            VerifyLabelAgent(ddlSelectedAgent.Items.Count, 1, false);
        }

        private void FirstFillDllAgentList()
        {
            VerifyLabelAgent(0, 0, true);
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

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

            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

            if (ddlPolicyClass.SelectedIndex != 0)
            {
                taskControl.AgentList = Policy.GetAgentListByPolicyClassID(int.Parse(ddlPolicyClass.SelectedItem.Value));

                if (taskControl.Mode == 1) //Add
                    this.FillTextDDlAgent();

                Session["TaskControl"] = taskControl;

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

                TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

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
                                //taskControl.InsuranceCompany = "002";
                                taskControl.Agency = "000";
                                taskControl.Bank = "000";
                                taskControl.Dealer = "000";
                                taskControl.CompanyDealer = "000";
                                //taskControl.CompanyDealer = ddlCompanyDealer.SelectedItem.Value.ToString();
                                taskControl.Status = "Inforce";
                                taskControl.TaskStatusID = 23; // int.Parse(LookupTables.LookupTables.GetID("TaskStatus", "Open"));
                                taskControl.TaskControlTypeID = 23; //int.Parse(LookupTables.LookupTables.GetID("TaskControlType", "Policies"));
                                taskControl.CommissionAgencyPercent = "0";
                                //taskControl.TotalPremium     = 0.00; //Ya viene del quote.
                                //taskControl.NewUse			 = 2; //Ya viene del quote.
                                taskControl.AutoAssignPolicy = false; //Para que en VSC aparesca puedan entrar el num de pol manualmente.

                                Session["TaskControl"] = taskControl;
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

                        case 21: //PR MEDICAL
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
                                    taskControl.PolicyClassID = 21;
                                    //taskControl.PolicyType = "PRM";
                                    if (taskControl.InsuranceCompany != "" && taskControl.InsuranceCompany != "002")
                                        taskControl.InsuranceCompany = "001";
                                    else
                                        taskControl.InsuranceCompany = "002";

                                    taskControl.Bank = "000";
                                    //taskControl.Agent          = ddlAvailableAgent.SelectedItem.Value.ToString();
                                    taskControl.Agent = taskControl.Agent;
                                    //taskControl.CompanyDealer = ddlCompanyDealer.SelectedItem.Value.ToString();
                                    taskControl.Status = "Inforce";
                                    taskControl.TaskStatusID = int.Parse(LookupTables.LookupTables.GetID("TaskStatus", "Open"));
                                    taskControl.TaskControlTypeID = 23; //Harcoded para las PAH //int.Parse(LookupTables.LookupTables.GetID("TaskControlType", "Policies"));

                                    taskControl.PrestamoArrenda = true;

                                    taskControl.EffectiveDate = DateTime.Now.ToShortDateString();
                                    taskControl.PurchaseDate = DateTime.Now.ToShortDateString();
                                    taskControl.EffDateCompany = DateTime.Now.ToShortDateString();
                                    taskControl.Term = 12;
                                    taskControl.ExpirationDate = DateTime.Parse(taskControl.EffectiveDate).AddMonths(taskControl.Term).ToShortDateString();
                                    //ddlPrMedicalLimits.SelectedIndex.ToString() = 
                                    //ddlPrMedicalLimits.SelectedItem.Text = taskControl.PRMedicalLimit;
                                }

                                Session["TaskControl"] = taskControl;
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
                                taskControl.TaskControlTypeID = 23; //int.Parse(LookupTables.LookupTables.GetID("TaskControlType", "Policies"));
                                taskControl.CommissionAgencyPercent = "0";
                                //taskControl.TotalPremium     = 0.00; //Ya viene del quote.
                                //taskControl.NewUse			 = 2; //Ya viene del quote.
                                taskControl.AutoAssignPolicy = false; //Para que en VSC aparesca puedan entrar el num de pol manualmente.
                                taskControl.EffectiveDate = DateTime.Now.ToShortDateString();

                                Session["TaskControl"] = taskControl;
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
            TxtPremium.Text = totalcargos.ToString("###,##0.00");
            TxtTotalPremium.Text = totalcargos.ToString("###,##0.00");
        }
        protected void btnIncentives_Click(object sender, System.EventArgs e)
        {
            RemoveSessionLookUp();
            Session.Add("FromPage", "AHCPrimaryPolicies.aspx");
            Response.Redirect("ViewIncentive.aspx");
        }
        protected void btnNew_Click(object sender, System.EventArgs e)
        {
            RemoveSessionLookUp();

            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

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
            taskControl.TaskControlTypeID = 23; //int.Parse(LookupTables.LookupTables.GetID("TaskControlType", "Policies"));
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
            Response.Redirect("AHCPrimaryPolicies.aspx", false);
        }
        protected void btnAdd2_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            TaskControl.Policies taskControl = new TaskControl.Policies();

            taskControl.Mode = 1; //ADD

            Session.Add("TaskControl", taskControl);
            Response.Redirect("AHCPrimaryPolicies.aspx", false);
        }
        protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnBreakdown_Click(object sender, EventArgs e)
        {
            RemoveSessionLookUp();
            Session.Add("FromPage", "AHCPrimaryPolicies.aspx");
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
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
            TaskControl.Policy policy = (TaskControl.Policy)Session["TaskControl"];
            TaskControl.Policies originalPolicy = (TaskControl.Policies)Session["TaskControl"];
            TaskControl.Policies policies = new TaskControl.Policies();


            try
            {
                //DtEndorsement = GetOPPEndorsements(taskControl.TaskControlID);

                //for(int i = 0; i < DtEndorsement.Rows.Count; i++)
                //{
                //    if (DtEndorsement.Rows[i]["EndoEffective"].ToString() != String.Empty)
                //    {
                //        taskControl = (EPolicy.TaskControl.Policies)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(int.Parse(DtEndorsement.Rows[i]["OPPQuotesID"].ToString()), userID);
                //    }
                //}

                //if (!taskControl.PolicyCanRenewDt(taskControl.TaskControlID, int.Parse(taskControl.Suffix)))
                //{
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("The policy has already been renewed.");
                //    this.litPopUp.Visible = true;
                //    return;
                //}

                policies = taskControl;
                policies.RetroactiveDate = originalPolicy.RetroactiveDate;
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
                txtEffDt.Text = policies.EffectiveDate.ToString();
                policies.ExpirationDate = DateTime.Parse(policies.ExpirationDate).AddMonths(12).ToShortDateString();
                txtExpDt.Text = policies.ExpirationDate.ToString();

                Recalculate();
                Calculate();
                CalculateCharge();
                policies.Charge = double.Parse(TxtCharge.Text);//taskControl.Charge;

                policies.ReturnCharge = 0.00;
                policies.ReturnPremium = 0.00;
                policies.CancellationAmount = 0.00;
                policies.ReturnCommissionAgency = 0.00;
                policies.ReturnCommissionAgent = 0.00;

                policies.PrintPolicy = false;
                policies.PrintDate = "";

                int msufijo;
                int sufijo = int.Parse(taskControl.Suffix);
                msufijo = sufijo + 1;
                if (msufijo < 10)
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
                if (policies.Endoso == 0)
                {
                    switch (RetroYear)
                    {
                        case 0:
                            policies.TotalPremium = double.Parse(txtRate1.Text);//taskControl.RateYear1;
                            break;
                        case 1:
                            policies.TotalPremium = double.Parse(txtRate2.Text);//taskControl.RateYear2;
                            break;
                        case 2:
                            policies.TotalPremium = double.Parse(txtRate3.Text);//taskControl.RateYear3;
                            break;
                        default:
                            policies.TotalPremium = double.Parse(txtRate4.Text);//taskControl.MCMRate;
                            break;
                    }
                }

                taskControl.RateYear1 = double.Parse(txtRate1.Text);
                taskControl.RateYear2 = double.Parse(txtRate2.Text);
                taskControl.RateYear3 = double.Parse(txtRate3.Text);
                taskControl.MCMRate = double.Parse(txtRate4.Text);

                // Determina si es necesario Recalcular la prima cuando se grabe la renovaci???n

                if (taskControl.PolicyType.Trim() == "PAH")
                {
                    if ((taskControl.Bank != "" || taskControl.Bank != "000") || (taskControl.TotalPremium != taskControl.TotalPrimary))
                    {
                        policies.isRecalculated = false;

                    }
                }
                else if (taskControl.PolicyType.Trim() == "PE")
                {
                    if ((taskControl.Bank != "" && taskControl.Bank != "000") || (taskControl.TotalPremium != taskControl.TotalExcess))
                    {
                        policies.isRecalculated = false;
                    }
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



                //APLICAR ENDOSOS
                Session.Clear();
                Session.Add("TaskControl", policies);
                Response.Redirect("AHCPrimaryPolicies.aspx", false);


            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }
        }
        private void SetDDLLimit(int LimitID)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

            ////Excess
            //DataTable dtPRMEDICRATE1 = EPolicy.TaskControl.Application.GetPRMEDICRATE(LimitID);
            //ddlRateExcess.Items.Clear();
            //ddlRateExcess.DataSource = dtPRMEDICRATE1;
            //ddlRateExcess.DataTextField = "PRMEDICRATEDesc";
            //ddlRateExcess.DataValueField = "PRMEDICRATEID";
            //ddlRateExcess.DataBind();
            //ddlRateExcess.SelectedIndex = -1;
            //ddlRateExcess.Items.Insert(0, "");

            DataTable dtPRMEDICRATE2 = null;

            dtPRMEDICRATE2 = EPolicy.TaskControl.Application.GetPRMEDICPrimaryRATEAHC(LimitID);
            

            ddlRate.Items.Clear();
            ddlRate.DataSource = dtPRMEDICRATE2;
            ddlRate.DataTextField = "PRMEDICRATEDesc";
            ddlRate.DataValueField = "PRMEDICRATEID";
            ddlRate.DataBind();

            DataTable dtPRMEDICRATEPRIMARY = EPolicy.TaskControl.Application.GetPRMEDICRATEPRIMARYAHCBYISOCODE(taskControl.PRMedicRATEID, taskControl.IsoCode);

                ddlRate.SelectedIndex = ddlRate.Items.IndexOf(
                                  ddlRate.Items.FindByValue(taskControl.PRMedicRATEID.ToString()));
            


            try
            {
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
            }
            catch (Exception)
            {

                throw;
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
                Response.Redirect("AHCPrimaryPolicies.aspx?" + taskControl.TaskControlID, true);
            }
            else  // Pager
            {
                DtSearchPayments.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                DtSearchPayments.DataSource = (DataTable)Session["DtTaskPolicy"];
                DtSearchPayments.DataBind();
            }
        }
        protected void ddlPrMedicalLimits_SelectedIndexChanged(object sender, EventArgs e)
        {
            Recalculate();
            Calculate();
            CalculateCharge();
        }
        private void Recalculate()
        {
            try
            {
                TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

                DataTable dtPRMEDICRATE2 = null;
                DataTable dtPRMEDICRATEPRIMARY2 = null;

                if (txtIsoCode.Text.Trim() == "")
                {
                    throw new Exception("Please Fill the Iso Code Filed.");
                }

                if (taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "AAE")
                    dtPRMEDICRATE2 = EPolicy.TaskControl.Application.GetPRMEDICRATEPRIMARYAHCBYISOCODEDDL(int.Parse(ddlPrMedicalLimits.SelectedItem.Value.ToString().Trim()), txtIsoCode.Text.Trim());
                else
                    dtPRMEDICRATEPRIMARY2 = EPolicy.TaskControl.Application.GetPRMEDICRATEPRIMARYAHCBYISOCODEDDL(int.Parse(ddlPrMedicalLimits.SelectedItem.Value.ToString().Trim()), txtIsoCode.Text.Trim());

                if (taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "AAE")
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

        protected void ddlSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

            txtIsoCode.Text = ddlSpecialty.SelectedItem.Value.Trim();
            //Lleno los dos ddls de especialidad.
            ddlIsoCode.SelectedIndex = ddlIsoCode.Items.IndexOf(ddlIsoCode.Items.FindByValue(txtIsoCode.Text.ToString().Trim()));
            ddlRate.SelectedIndex = ddlRate.Items.IndexOf(ddlRate.Items.FindByValue(txtIsoCode.Text.ToString().Trim()));
            //Lleno Class
            txtClass.Text = taskControl.Class;

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
            Session["TaskControl"] = taskControl;

            taskControl.RateYear1 = double.Parse(txtRate1.Text);
            taskControl.RateYear2 = double.Parse(txtRate2.Text);
            taskControl.RateYear3 = double.Parse(txtRate3.Text);
            taskControl.MCMRate = double.Parse(txtRate4.Text);

            if (ddlGroup.SelectedIndex > 0 && ddlGroup.SelectedItem != null)
                taskControl.Bank = ddlGroup.SelectedItem.Value;
            else
                taskControl.Bank = "000";

            taskControl.InvoiceNumber = "0"; //Discount
            if (taskControl.Bank != "000") //Bank = Group
            {
                EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                master = master.GetMasterPolicyDiscount(taskControl.Bank, taskControl.EffectiveDate);

                if (taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "AAE") //Excess
                {
                    taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                    txtRate1.Text = Math.Round(taskControl.RateYear1 - (taskControl.RateYear1 * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                    txtRate2.Text = Math.Round(taskControl.RateYear2 - (taskControl.RateYear2 * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                    txtRate3.Text = Math.Round(taskControl.RateYear3 - (taskControl.RateYear3 * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                    txtRate4.Text = Math.Round(taskControl.MCMRate - (taskControl.MCMRate * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                }
                else // Primary
                {
                    taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                    txtRate1.Text = Math.Round(taskControl.RateYear1 - (taskControl.RateYear1 * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                    txtRate2.Text = Math.Round(taskControl.RateYear2 - (taskControl.RateYear2 * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                    txtRate3.Text = Math.Round(taskControl.RateYear3 - (taskControl.RateYear3 * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                    txtRate4.Text = Math.Round(taskControl.MCMRate - (taskControl.MCMRate * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                }
            }
            txtInvoiceNumber.Text = taskControl.InvoiceNumber;

            Calculate();
            CalculateCharge();
        }
        protected void ddlIsoCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

            txtIsoCode.Text = ddlIsoCode.SelectedItem.Value.Trim();
            //Lleno los dos ddls de especialidad.
            ddlSpecialty.SelectedIndex = ddlSpecialty.Items.IndexOf(ddlSpecialty.Items.FindByValue(txtIsoCode.Text.ToString().Trim()));
            ddlRate.SelectedIndex = ddlRate.Items.IndexOf(ddlRate.Items.FindByValue(txtIsoCode.Text.ToString().Trim()));
            //Lleno Class
            txtClass.Text = taskControl.Class;

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
            Session["TaskControl"] = taskControl;

            taskControl.RateYear1 = double.Parse(txtRate1.Text);
            taskControl.RateYear2 = double.Parse(txtRate2.Text);
            taskControl.RateYear3 = double.Parse(txtRate3.Text);
            taskControl.MCMRate = double.Parse(txtRate4.Text);

            if (ddlGroup.SelectedIndex > 0 && ddlGroup.SelectedItem != null)
                taskControl.Bank = ddlGroup.SelectedItem.Value;
            else
                taskControl.Bank = "000";

            taskControl.InvoiceNumber = "0"; //Discount
            if (taskControl.Bank != "000") //Bank = Group
            {
                EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                master = master.GetMasterPolicyDiscount(taskControl.Bank, taskControl.EffectiveDate);

                if (taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "AAE") //Excess
                {
                    taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                    txtRate1.Text = Math.Round(taskControl.RateYear1 - (taskControl.RateYear1 * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                    txtRate2.Text = Math.Round(taskControl.RateYear2 - (taskControl.RateYear2 * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                    txtRate3.Text = Math.Round(taskControl.RateYear3 - (taskControl.RateYear3 * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                    txtRate4.Text = Math.Round(taskControl.MCMRate - (taskControl.MCMRate * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                }
                else // Primary
                {
                    taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                    txtRate1.Text = Math.Round(taskControl.RateYear1 - (taskControl.RateYear1 * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                    txtRate2.Text = Math.Round(taskControl.RateYear2 - (taskControl.RateYear2 * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                    txtRate3.Text = Math.Round(taskControl.RateYear3 - (taskControl.RateYear3 * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                    txtRate4.Text = Math.Round(taskControl.MCMRate - (taskControl.MCMRate * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                }
            }
            txtInvoiceNumber.Text = taskControl.InvoiceNumber;

            Calculate();
            CalculateCharge();
        }
        protected void ddlRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

            DataTable dtIsoCode = GetIsoCodeByRateID(int.Parse(ddlRate.SelectedItem.Value.Trim()));
            DataTable dtPRMEDICRATEPRIMARY = EPolicy.TaskControl.Application.GetPRMEDICRATEPRIMARYAHCBYISOCODE(int.Parse(ddlRate.SelectedItem.Value.Trim()), dtIsoCode.Rows[0]["IsoCode"].ToString());

            if (taskControl.PRMedicRATEID != 0)
            {
                for (int i = 0; i < dtPRMEDICRATEPRIMARY.Rows.Count; i++)
                {
                    //if (ddlRate.Items[i].Value.Trim() != "")
                    //{
                        string[] array = dtPRMEDICRATEPRIMARY.Rows[i]["PRMedicRATEID"].ToString().Split('|');
                        if (int.Parse(ddlRate.SelectedItem.Value.Trim()) == int.Parse(array[0]) && ddlPrMedicalLimits.SelectedItem.Value.Trim() == array[7])
                        {
                            ddlRate.SelectedIndex = ddlRate.Items.IndexOf(
                            ddlRate.Items.FindByValue(ddlRate.SelectedItem.Value.Trim()));

                            this.txtIsoCode.Text = array[1];
                            this.txtClass.Text = array[2];
                            this.txtRate1.Text = array[3];
                            this.txtRate2.Text = array[4];
                            this.txtRate3.Text = array[5];
                            this.txtRate4.Text = array[6];
                        }
                    }
               // }
            }

            //txtIsoCode.Text = ddlRate.SelectedItem.Value.Trim();

            //Lleno los dos ddls de especialidad.
            //ddlSpecialty.SelectedIndex = ddlSpecialty.Items.IndexOf(ddlSpecialty.Items.FindByValue(txtIsoCode.Text.ToString().Trim()));
            //ddlRate.SelectedIndex = ddlRate.Items.IndexOf(ddlRate.Items.FindByValue(txtIsoCode.Text.ToString().Trim()));
            //ddlIsoCode.SelectedIndex = ddlIsoCode.Items.IndexOf(ddlIsoCode.Items.FindByValue(txtIsoCode.Text.ToString().Trim()));
            ////Lleno Class
            //txtClass.Text = taskControl.Class;

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
            Session["TaskControl"] = taskControl;

            taskControl.RateYear1 = double.Parse(txtRate1.Text);
            taskControl.RateYear2 = double.Parse(txtRate2.Text);
            taskControl.RateYear3 = double.Parse(txtRate3.Text);
            taskControl.MCMRate = double.Parse(txtRate4.Text);

            if (ddlGroup.SelectedIndex > 0 && ddlGroup.SelectedItem != null)
                taskControl.Bank = ddlGroup.SelectedItem.Value;
            else
                taskControl.Bank = "000";

            taskControl.InvoiceNumber = "0"; //Discount
            if (taskControl.Bank != "000") //Bank = Group
            {
                EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                master = master.GetMasterPolicyDiscount(taskControl.Bank, taskControl.EffectiveDate);

                if (taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "AAE") //Excess
                {
                    taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                    txtRate1.Text = Math.Round(taskControl.RateYear1 - (taskControl.RateYear1 * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                    txtRate2.Text = Math.Round(taskControl.RateYear2 - (taskControl.RateYear2 * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                    txtRate3.Text = Math.Round(taskControl.RateYear3 - (taskControl.RateYear3 * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                    txtRate4.Text = Math.Round(taskControl.MCMRate - (taskControl.MCMRate * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                }
                else // Primary
                {
                    taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                    txtRate1.Text = Math.Round(taskControl.RateYear1 - (taskControl.RateYear1 * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                    txtRate2.Text = Math.Round(taskControl.RateYear2 - (taskControl.RateYear2 * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                    txtRate3.Text = Math.Round(taskControl.RateYear3 - (taskControl.RateYear3 * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                    txtRate4.Text = Math.Round(taskControl.MCMRate - (taskControl.MCMRate * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                }
            }
            txtInvoiceNumber.Text = taskControl.InvoiceNumber;

            Calculate();
            CalculateCharge();
            taskControl.PRMedicRATEID = int.Parse(ddlRate.SelectedItem.Value);

    }

        protected void ddlRate_SelectedIndexChanged2(object sender, EventArgs e)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
 
            DataTable dtIsoCode = GetIsoCodeByRateID(int.Parse(ddlRate.SelectedItem.Value.Trim()));
            DataTable dtPRMEDICRATEPRIMARY = EPolicy.TaskControl.Application.GetPRMEDICRATEPRIMARYAHCBYISOCODE(int.Parse(ddlRate.SelectedItem.Value.Trim()), dtIsoCode.Rows[0]["IsoCode"].ToString());

            DataTable dtPRMEDICRATE2 = null;
            dtPRMEDICRATE2 = EPolicy.TaskControl.Application.GetPRMEDICPrimaryRATEAHC(int.Parse(ddlPrMedicalLimits.SelectedItem.Value.Trim()));
            ddlRate.Items.Clear();
            ddlRate.DataSource = dtPRMEDICRATE2;
            ddlRate.DataTextField = "PRMEDICRATEDesc";
            ddlRate.DataValueField = "PRMEDICRATEID";
            ddlRate.DataBind();

            if (taskControl.PRMedicRATEID != 0)
            {
                for (int i = 0; i < dtPRMEDICRATEPRIMARY.Rows.Count; i++)
                {
                    //if (ddlRate.Items[i].Value.Trim() != "")
                    //{
                    string[] array = dtPRMEDICRATEPRIMARY.Rows[i]["PRMedicRATEID"].ToString().Split('|');
                    if (ddlPrMedicalLimits.SelectedItem.Value.Trim() == array[7])
                    {
                        ddlRate.SelectedIndex = ddlRate.Items.IndexOf(
                        ddlRate.Items.FindByValue(array[0].Trim()));

                        this.txtIsoCode.Text = array[1];
                        this.txtClass.Text = array[2];
                        this.txtRate1.Text = array[3];
                        this.txtRate2.Text = array[4];
                        this.txtRate3.Text = array[5];
                        this.txtRate4.Text = array[6];
                    }
                }
                // }
            }

            //txtIsoCode.Text = ddlRate.SelectedItem.Value.Trim();

            //Lleno los dos ddls de especialidad.
            //ddlSpecialty.SelectedIndex = ddlSpecialty.Items.IndexOf(ddlSpecialty.Items.FindByValue(txtIsoCode.Text.ToString().Trim()));
            //ddlRate.SelectedIndex = ddlRate.Items.IndexOf(ddlRate.Items.FindByValue(txtIsoCode.Text.ToString().Trim()));
            //ddlIsoCode.SelectedIndex = ddlIsoCode.Items.IndexOf(ddlIsoCode.Items.FindByValue(txtIsoCode.Text.ToString().Trim()));
            ////Lleno Class
            //txtClass.Text = taskControl.Class;

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
            Session["TaskControl"] = taskControl;

            taskControl.RateYear1 = double.Parse(txtRate1.Text);
            taskControl.RateYear2 = double.Parse(txtRate2.Text);
            taskControl.RateYear3 = double.Parse(txtRate3.Text);
            taskControl.MCMRate = double.Parse(txtRate4.Text);

            if (ddlGroup.SelectedIndex > 0 && ddlGroup.SelectedItem != null)
                taskControl.Bank = ddlGroup.SelectedItem.Value;
            else
                taskControl.Bank = "000";

            taskControl.InvoiceNumber = "0"; //Discount
            if (taskControl.Bank != "000") //Bank = Group
            {
                EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                master = master.GetMasterPolicyDiscount(taskControl.Bank, taskControl.EffectiveDate);

                if (taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "AAE") //Excess
                {
                    taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                    txtRate1.Text = Math.Round(taskControl.RateYear1 - (taskControl.RateYear1 * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                    txtRate2.Text = Math.Round(taskControl.RateYear2 - (taskControl.RateYear2 * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                    txtRate3.Text = Math.Round(taskControl.RateYear3 - (taskControl.RateYear3 * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                    txtRate4.Text = Math.Round(taskControl.MCMRate - (taskControl.MCMRate * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                }
                else // Primary
                {
                    taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                    txtRate1.Text = Math.Round(taskControl.RateYear1 - (taskControl.RateYear1 * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                    txtRate2.Text = Math.Round(taskControl.RateYear2 - (taskControl.RateYear2 * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                    txtRate3.Text = Math.Round(taskControl.RateYear3 - (taskControl.RateYear3 * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                    txtRate4.Text = Math.Round(taskControl.MCMRate - (taskControl.MCMRate * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                }
            }
            txtInvoiceNumber.Text = taskControl.InvoiceNumber;

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
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
            Login.Login cp = HttpContext.Current.User as Login.Login;

            if (taskControl.CancellationEntryDate != "" && !cp.IsInRole("PRINTCERTIFICATE"))
            {
                lblRecHeader.Text = "For Certificate of Insurance please contact the Company.";
                mpeSeleccion.Show();
            }
            else
            {
                string js = "<script language=javascript> javascript:popwindow=window.open('PrintCertificate.aspx','popwindow','toolbar=no,location=center,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width=850,height=450');popwindow.focus(); </script>";

                //Session.Clear();
                //Session["TaskControl"] = taskControl;
                //Response.Redirect("Policies.aspx?" + taskControl.TaskControlID, true);

                Response.Write(js);
            }
        }
        protected void btnTailQuote_Click(object sender, EventArgs e)
        {
            //TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
            //taskControl.Mode = 5;
            //Session["TaskControl"] = taskControl;

            FillProperties();

            string js = "<script language=javascript> javascript:popwindow=window.open('TailQuote.aspx','popwindow','modal=yes,toolbar=no,location=center,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,copyhistory=no,width=445,height=300');popwindow.focus(); </script>";
            //string js = "<script language=javascript> window.showModalDialog('TailQuote.aspx','scrollbars:no,resizable:no,dialogWidth:430px,dialogHeight:270px');</script>";
            //string js = "<script language=javascript> javascript:popwindow=window.open('TailQuote.aspx','null,width=430,height=270,modal=yes,alwaysRaised=yes,null);</script>";
            //window.open("modal.htm", null, "width=200,height=200,left=300,modal=yes,alwaysRaised=yes", null);
            //Session.Clear();
            //Session["TaskControl"] = taskControl;
            //Response.Redirect("Policies.aspx?" + taskControl.TaskControlID, true);

            btnRefresh.Visible = true;
            Response.Write(js);
        }
        protected void DisableControlsTail()
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

            if (taskControl.PolicyType.Contains("T"))
            {
                btnRenew.Visible = false;
                btnReinstatement.Visible = false;
                btnPrintCertificate.Visible = false;
                btnCancellation.Visible = false;
                btnFinancialCanc.Visible = false;
                btnPolicyCert.Visible = false;
                btnTailQuote.Visible = false;
                btnEndor.Visible = false;
                btnEnablePrint.Visible = false;

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
                btnPolicyCert.Visible = false;
            }


        }
        protected void CalculateCharge(object sender, EventArgs e)
        {
            EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];

            try
            {
                //if (!chkUserMod.Checked)
                //{
                //    CalculateCharge();
                //}

                //if (txtEndoEffDate.Text != "")
                //{
                //    CalculateCharge();
                //    CalculateEndorsement();
                //}

                //if (!chkUserMod.Checked)
                //{
                //    ResetValues();
                //    Calculate();
                //    CalculateCharge();
                //}

                ResetValues();
                Calculate();
                CalculateCharge();

                if (txtEndoEffDate.Text != "")// && taskControl.isEndorsement)
                {
                    chkUserMod.Checked = false;
                    //ResetValues();
                    //Calculate();
                    //CalculateCharge();


                    CalculateEndorsement();
                }

                if (taskControl.isRecalculated == false)
                    taskControl.isRecalculated = true;
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
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            FillGrid();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];
            try
            {
                //ResetValues();
                //Calculate();
                //CalculateCharge();

                //if (txtEndoEffDate.Text != "")
                //    CalculateEndorsement();

                //if (!chkUserMod.Checked)
                //{
                ResetValues();
                Calculate();
                CalculateCharge();
                //}

                if (txtEndoEffDate.Text != "")// && taskControl.isEndorsement)
                {
                    chkUserMod.Checked = false;
                    //ResetValues();
                    //Calculate();
                    //CalculateCharge();

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
        private void Calculate()
        {
            EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];

            CalculateOthersRates();

            DateTime effectiveDate;

            if (TxtRetroactiveDate.Text != String.Empty)
            {
                DateTime retroActiveDate = new DateTime();

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
                    txtEQuantityTN3.Text = "0";//txtQuantityTN3.Text.Trim();

                if (txtQuantityTN4.Text.Trim() == "")
                    txtQuantityTN4.Text = "0";

                if (txtEQuantityTN4.Text.Trim() == "")
                    txtEQuantityTN4.Text = "0";//txtQuantityTN4.Text.Trim();

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

                //Primary
                int quantity1 = int.Parse(txtQuantityTN1.Text.Trim());
                int quantity2 = int.Parse(txtQuantityTN2.Text.Trim());
                int quantity3 = int.Parse(txtQuantityTN3.Text.Trim());
                int quantity4 = int.Parse(txtQuantityTN4.Text.Trim());
                int quantity5 = int.Parse(txtQuantityTN5.Text.Trim());
                int quantity6 = quantity1 + quantity2 + quantity3 + quantity4 + quantity5;
                txtQuantityTN6.Text = quantity6.ToString();


                double tot1 = Math.Round(double.Parse(txtPremiumTN1.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtQuantityTN1.Text) * mcmRate, 0);
                txtTotPremTN1.Text = tot1.ToString("###,###,##0.00");

                double tot2 = Math.Round(double.Parse(txtPremiumTN2.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtQuantityTN2.Text) * mcmRate, 0);
                txtTotPremTN2.Text = tot2.ToString("###,###,##0.00");

                double tot3 = Math.Round(double.Parse(txtPremiumTN3.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtQuantityTN3.Text) * mcmRate, 0);
                txtTotPremTN3.Text = tot3.ToString("###,###,##0.00");

                double tot4 = Math.Round(double.Parse(txtPremiumTN4.Text.Replace(".00", "").Replace(",", "")) * int.Parse(txtQuantityTN4.Text) * mcmRate, 0);
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
                //Result Total Exccess
                txtTotalExcess.Text = txtETotPremTN6.Text;



                int totPrimaryPremium = int.Parse(taskControl.TotalPremium.ToString()) + int.Parse(P1.ToString());
                txtTotalPrimary.Text = totPrimaryPremium.ToString("###,###,##0.00");

                int totExcessPremium = int.Parse(taskControl.TotalPremium.ToString()) + int.Parse(P2.ToString());
                txtTotalExcess.Text = totExcessPremium.ToString("###,###,##0.00");

                if (taskControl.PolicyType.Trim() == "PP" || taskControl.PolicyType.Trim() == "AAP")
                {
                    //TxtPremium.Text = (totPrimaryPremium - double.Parse(TxtCharge.Text)).ToString("###,###,##0.00");
                    TxtPremium.Text = (totPrimaryPremium - P1).ToString("###,###,##0.00");
                    TxtTotalPremium.Text = (double.Parse(TxtCharge.Text) + totPrimaryPremium - double.Parse(TxtCancAmount.Text)).ToString("###,###,##0.00");
                    //txtRate4.Text = totPrimaryPremium.ToString("###,###,##0.00"); 

                }
                else
                {
                    //TxtPremium.Text = (totExcessPremium - double.Parse(TxtCharge.Text)).ToString("###,###,##0.00");
                    TxtPremium.Text = (totExcessPremium - P2).ToString("###,###,##0.00");
                    TxtTotalPremium.Text = (double.Parse(TxtCharge.Text) + totExcessPremium - double.Parse(TxtCancAmount.Text)).ToString("###,###,##0.00");
                    //txtRate4.Text = totExcessPremium.ToString("###,###,##0.00");
                }
                //CalculateEndorsementOnlyForQuote();
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
        private void GetOthersRates()
        {
            EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];

            try
            {
                if (ddlPrMedicalLimits.SelectedItem.Value.Trim() != "")
                {
                    //Primary
                    DataTable dt1 = TaskControl.Policies.GetPRMEDICRATEPRIMARYByClassAndLimitID("1", int.Parse(taskControl.PRMedicalLimit.ToString()));
                    DataTable dt2 = TaskControl.Policies.GetPRMEDICRATEPRIMARYByClassAndLimitID("7", int.Parse(taskControl.PRMedicalLimit.ToString()));
                    //DataTable dt2 = TaskControl.Policies.GetPRMEDICRATEPRIMARYByClassAndLimitID("7", int.Parse(ddlPrMedicalLimits.SelectedItem.Value.Trim()));

                    DataTable dt3 = TaskControl.Policies.GetPRMEDICRATEPRIMARYByClassAndLimitID("3A", int.Parse(taskControl.PRMedicalLimit.ToString()));

                    if (dt1.Rows.Count > 0 && dt2.Rows.Count > 0 && dt3.Rows.Count > 0)
                    {
                        txtPrimaryTN1.Text = (double.Parse(dt1.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                        txtPrimaryTN2.Text = (double.Parse(dt2.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                        txtPrimaryTN3.Text = (double.Parse(dt3.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                        txtPrimaryTN4.Text = (double.Parse(dt1.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                        txtPrimaryTN5.Text = (double.Parse(dt1.Rows[0]["MCMRate"].ToString())).ToString("###,##0.00");
                    }


                    //Excess
                    DataTable dt4 = TaskControl.Policies.GetPRMEDICRATEByClassAndLimitID("1", int.Parse(taskControl.PRMedicalLimit.ToString()));
                    DataTable dt5 = TaskControl.Policies.GetPRMEDICRATEByClassAndLimitID("7", int.Parse(taskControl.PRMedicalLimit.ToString()));
                    DataTable dt6 = TaskControl.Policies.GetPRMEDICRATEByClassAndLimitID("3A", int.Parse(taskControl.PRMedicalLimit.ToString()));

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
            catch (Exception ex)
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
            EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];

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

            txtTotalPrimary.Text = "";
            txtTotalExcess.Text = "";

            //CalculateEndorsementOnlyForQuote();
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
                if (Session["TaskControl"] != null)
                {
                    TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
                    //FillProperties();
                    DataTable dtCharge = LookupTables.LookupTables.GetTable("Charge");
                    int result = 0;
                    double additionalPremium = 0.0;

                    if (taskControl.PolicyType.Trim() == "PP" || taskControl.PolicyType.Trim() == "AAP")
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
                            if (TxtUserPremium.Text != "")
                            {
                                taskControl.TotalPremium = double.Parse(TxtUserPremium.Text);
                                //else
                                //{
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
                            //}
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

                                //Screen Calculate
                                TxtCharge.Text = rounded.ToString("###,###.#0").Trim();
                                TxtPremium.Text = totalpremium.ToString("###,###.#0").Trim();
                                TxtCancAmount.Text = cancellationAmount.ToString("-###,###.#0").Trim();
                                TxtTotalPremium.Text = ((totalpremium + rounded) - taskControl.CancellationAmount).ToString("###,###.#0").Trim();
                                txtTotalPrimary.Text = (totalpremium + rounded).ToString("###,###.#0").Trim();
                                txtTotalExcess.Text = (totalpremium + rounded).ToString("###,###.#0").Trim();
                                taskControl.Charge = double.Parse(rounded.ToString("###,###.#0").Trim());
                                lblCharge.Visible = true;
                                lblCharge.Text = "(" + chargePercent.ToString() + ")";
                                //double chargePercent = double.Parse(dtCharge.Rows[i]["chargePercent"].ToString());
                                //var decPlaces = (((taskControl.TotalPremium) * chargePercent) % 1) * 100;
                                //int rounded = 0;

                                //if (decPlaces >= 50)
                                //    rounded = (int)Math.Ceiling((taskControl.TotalPremium) * chargePercent);
                                //else
                                //    rounded = (int)Math.Floor((taskControl.TotalPremium) * chargePercent);

                                //TxtCharge.Text = rounded.ToString("###,###.#0").Trim();
                                //TxtPremium.Text = taskControl.TotalPremium.ToString("###,###.#0").Trim();
                                //TxtCancAmount.Text = taskControl.CancellationAmount.ToString("-###,###.#0").Trim();
                                //TxtTotalPremium.Text = ((taskControl.TotalPremium + rounded) - taskControl.CancellationAmount).ToString("###,###.#0").Trim();
                                //txtTotalPrimary.Text = (taskControl.TotalPremium + rounded).ToString("###,###.#0").Trim();
                                //txtTotalExcess.Text = (taskControl.TotalPremium + rounded).ToString("###,###.#0").Trim();
                                //taskControl.Charge = double.Parse(rounded.ToString("###,###.#0").Trim());
                                //lblCharge.Visible = true;
                                //lblCharge.Text = "(" + chargePercent.ToString() + ")";
                                break;
                            }
                            else
                            {
                                TxtCharge.Text = "0.00";
                                TxtPremium.Text = taskControl.TotalPremium.ToString("###,###.#0").Trim();
                                TxtCancAmount.Text = taskControl.CancellationAmount.ToString("-###,###.#0").Trim();
                                TxtTotalPremium.Text = ((taskControl.TotalPremium + 0) - taskControl.CancellationAmount).ToString("###,###.#0").Trim();
                                txtTotalPrimary.Text = (taskControl.TotalPremium + 0).ToString("###,###.#0").Trim();
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


                                //Screen Calculate
                                TxtCharge.Text = rounded.ToString("###,###.#0").Trim();
                                TxtPremium.Text = totalpremium.ToString("###,###.#0").Trim();
                                TxtCancAmount.Text = cancellationAmount.ToString("-###,###.#0").Trim();
                                TxtTotalPremium.Text = ((totalpremium + rounded) - taskControl.CancellationAmount).ToString("###,###.#0").Trim();
                                txtTotalPrimary.Text = (totalpremium + rounded).ToString("###,###.#0").Trim();
                                txtTotalExcess.Text = (totalpremium + rounded).ToString("###,###.#0").Trim();
                                taskControl.Charge = double.Parse(rounded.ToString("###,###.#0").Trim());
                                lblCharge.Visible = true;
                                lblCharge.Text = "(" + chargePercent.ToString() + ")";
                               
                                //double chargePercent = double.Parse(dtCharge.Rows[i]["chargePercent"].ToString());
                                //var decPlaces = (((taskControl.TotalPremium) * chargePercent) % 1) * 100;
                                //int rounded = 0;

                                //if (decPlaces >= 50)
                                //    rounded = (int)Math.Ceiling((taskControl.TotalPremium) * chargePercent);
                                //else
                                //    rounded = (int)Math.Floor((taskControl.TotalPremium) * chargePercent);

                                //TxtCharge.Text = rounded.ToString("###,##0.00").Trim();
                                //TxtPremium.Text = (taskControl.TotalPremium).ToString("###,##0.00").Trim();
                                //TxtCancAmount.Text = taskControl.CancellationAmount.ToString("-###,###.#0").Trim();
                                //TxtTotalPremium.Text = ((taskControl.TotalPremium + rounded) - taskControl.CancellationAmount).ToString("###,##0.00").Trim();
                                //txtTotalPrimary.Text = (taskControl.TotalPremium + rounded).ToString("###,###.#0").Trim();
                                //txtTotalExcess.Text = (taskControl.TotalPremium + rounded).ToString("###,###.#0").Trim();
                                //taskControl.Charge = double.Parse(rounded.ToString("###,##0.00").Trim());
                                //lblCharge.Visible = true;
                                //lblCharge.Text = "(" + chargePercent.ToString() + ")";
                                break;
                            }
                            else
                            {
                                TxtCharge.Text = "0.00";
                                TxtPremium.Text = taskControl.TotalPremium.ToString("###,###.#0").Trim();
                                TxtCancAmount.Text = taskControl.CancellationAmount.ToString("-###,###.#0").Trim();
                                TxtTotalPremium.Text = ((taskControl.TotalPremium + 0) - taskControl.CancellationAmount).ToString("###,###.#0").Trim();
                                txtTotalPrimary.Text = (taskControl.TotalPremium + 0).ToString("###,###.#0").Trim();
                                txtTotalExcess.Text = (taskControl.TotalPremium + 0).ToString("###,###.#0").Trim();

                            }
                        }
                        taskControl.isRecalculated = true;
                    }
                }
            }
        }
        protected void btnPolicyCert_Click(object sender, EventArgs e)
        {
            try
            {
                TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

                if (taskControl.PolicyType.Trim() == "PP")
                {
                    DataDynamics.ActiveReports.ActiveReport3 rpt = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt1 = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt3 = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt4 = null;
                    DataDynamics.ActiveReports.ActiveReport3 rpt5 = null;

                    rpt = new EPolicy2.Reports.PRMdic.PrimaryPolicy((EPolicy.TaskControl.Policy)taskControl);
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
                    Session.Add("FromPage", "AHCPrimaryPolicies.aspx");
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

                    rpt = new EPolicy2.Reports.PRMdic.Poliza((EPolicy.TaskControl.Policy)taskControl);
                    rpt.Document.Printer.PrinterName = "";
                    rpt.Run(false);

                    rpt1 = new EPolicy2.Reports.PRMdic.Poliza1(taskControl, true, taskControl.PRMedicalLimit.ToString());
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
                    Session.Add("FromPage", "AHCPrimaryPolicies.aspx");
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
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
            double additionalPremium = 0.0;

            if (taskControl.PolicyType.Trim() == "PP" || taskControl.PolicyType.Trim() == "AAP")
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
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

            //txtRate1.Text = taskControl.RateYear1.ToString("###,##0.00");
            //txtRate2.Text = taskControl.RateYear2.ToString("###,##0.00");
            //txtRate3.Text = taskControl.RateYear3.ToString("###,##0.00");
            //txtRate4.Text = taskControl.MCMRate.ToString("###,##0.00");
            Recalculate();

            taskControl.RateYear1 = double.Parse(txtRate1.Text);
            taskControl.RateYear2 = double.Parse(txtRate2.Text);
            taskControl.RateYear3 = double.Parse(txtRate3.Text);
            taskControl.MCMRate = double.Parse(txtRate4.Text);

            if (ddlGroup.SelectedIndex > 0 && ddlGroup.SelectedItem != null)
                taskControl.Bank = ddlGroup.SelectedItem.Value;
            else
                taskControl.Bank = "000";

            taskControl.InvoiceNumber = "0"; //Discount
            if (taskControl.Bank != "000") //Bank = Group
            {
                EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                master = master.GetMasterPolicyDiscount(taskControl.Bank, taskControl.EffectiveDate);

                if (taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "AAE") //Excess
                {
                    taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                    txtRate1.Text = Math.Round(taskControl.RateYear1 - (taskControl.RateYear1 * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                    txtRate2.Text = Math.Round(taskControl.RateYear2 - (taskControl.RateYear2 * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                    txtRate3.Text = Math.Round(taskControl.RateYear3 - (taskControl.RateYear3 * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                    txtRate4.Text = Math.Round(taskControl.MCMRate - (taskControl.MCMRate * ((master.DescuentoExcess / 100))), 0).ToString("###,##0.00");
                }
                else // Primary
                {
                    taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                    txtRate1.Text = Math.Round(taskControl.RateYear1 - (taskControl.RateYear1 * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                    txtRate2.Text = Math.Round(taskControl.RateYear2 - (taskControl.RateYear2 * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                    txtRate3.Text = Math.Round(taskControl.RateYear3 - (taskControl.RateYear3 * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                    txtRate4.Text = Math.Round(taskControl.MCMRate - (taskControl.MCMRate * ((master.DescuentoPrimario / 100))), 0).ToString("###,##0.00");
                }
            }
            txtInvoiceNumber.Text = taskControl.InvoiceNumber;

            ResetValues();
            Calculate();
            CalculateCharge();

            //TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

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
                TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

                taskControl.PrintPolicy = false;
                taskControl.Mode = 2;
                FillProperties();
                History(taskControl.TaskControlID, userID, "LOCK", "POLICIES", "ENABLED POLICY PRINTING.");
                taskControl.SavePolicies(userID);

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
        protected void btnRegistry_Click(object sender, EventArgs e)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

            RemoveSessionLookUp();
            Session.Add("FromUI", "AHCPrimaryPolicies.aspx");
            Response.Redirect("AHCRegistry.aspx", false);

            //string js = "<script language=javascript> javascript:popwindow=window.open('Registry.aspx','popwindow','toolbar=no,location=center,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width=850,height=720');popwindow.focus(); </script>";

            //Session.Clear();
            //Session["TaskControl"] = taskControl;
            //Response.Redirect("Policies.aspx?" + taskControl.TaskControlID, true);

            //Response.Write(js);
        }

        #region Old Endorsement Features

        //protected void DataGridGroup_ItemCommand(object source, DataGridCommandEventArgs e)
        //{
        //    try
        //    {
        //        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        //        int userID = 0;
        //        userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

        //        switch (e.CommandName)
        //        {
        //            case "Update":
        //                DataGridGroup.DataSource = null;
        //                //btnReturn.Visible = true;
        //                //Panel3.Visible = true;

        //                int i = int.Parse(e.Item.Cells[2].Text);
        //                EPolicy.TaskControl.Policies opp = (EPolicy.TaskControl.Policies)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(i, userID);
        //                opp.Mode = (int)EPolicy.TaskControl.TaskControl.TaskControlMode.CLEAR;
        //                opp.isEndorsement = true;

        //                if (Session["TaskControl"] != null)
        //                {
        //                    EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];
        //                    Session.Clear();
        //                    Session.Add("PLEndorsement", taskControl);
        //                    Session.Add("Original", taskControl);
        //                    Session.Add("PLEndorUpdate", "Update");
        //                    Session.Remove("TaskControl");
        //                }

        //                Session.Add("TaskControl", opp);
        //                Response.Redirect("Policies.aspx");
        //                break;

        //            case "Apply":
        //                DataGridGroup.DataSource = null;

        //                string date = e.Item.Cells[3].Text.Trim();
        //                if (date.ToString().Trim() != " ")
        //                {
        //                    throw new Exception("This Endorsement is already Applied.");
        //                }

        //                int a = int.Parse(e.Item.Cells[2].Text);
        //                EPolicy.TaskControl.Policies newOPP = (EPolicy.TaskControl.Policies)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(a, userID);

        //                int OPPEndorsementID = int.Parse(e.Item.Cells[1].Text);
        //                Session.Add("PLEndorsementID", OPPEndorsementID);
        //                //Buscar Quotes para endosar
        //                Panel1.Visible = true;
        //                txtEffDtEndorsement.Text = DateTime.Now.ToShortDateString();//e.Item.Cells[4].Text.Trim();
        //                txtFactor.Text = e.Item.Cells[5].Text.Trim();
        //                txtProRata.Text = e.Item.Cells[6].Text.Trim();
        //                txtShortRate.Text = e.Item.Cells[7].Text.Trim();
        //                txtActualPremTotal.Text = e.Item.Cells[16].Text.Trim();
        //                txtPreviousPremTotal.Text = e.Item.Cells[21].Text.Trim();
        //                txtDiffPremTotal.Text = e.Item.Cells[26].Text.Trim(); //(double.Parse(txtActualPremTotal.Text) - double.Parse(txtPreviousPremTotal.Text)).ToString();
        //                txtAdditionalPremium.Text = e.Item.Cells[27].Text.Trim();

        //                CalculateEndorsement(newOPP);
        //                VerifyChanges(newOPP, userID);
        //                Session.Add("ApplyEndorsement", a);
        //                ApplyEndorsement(newOPP, userID);
        //                break;

        //            case "Select":
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
        //                //Panel2.Visible = true;
        //                Panel3.Visible = true;
        //                pnlEndorsement.Visible = true;
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

        //                //EPolicy.TaskControl.Policies taskControl2 = (EPolicy.TaskControl.Policies)Session["TaskControl"];

        //                //int s = int.Parse(e.Item.Cells[2].Text);
        //                //string comments = e.Item.Cells[10].Text.Trim();
        //                //EPolicy.TaskControl.Policies newOPP2 = (EPolicy.TaskControl.Policies)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(s, userID);
        //                //int OPPEndorID = int.Parse(e.Item.Cells[1].Text);

        //                ////Print Document
        //                //try
        //                //{
        //                //    EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];

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
        //                //    string fileName = taskControl.Prospect.FirstName.Trim().Replace("???", "n").Replace("???", "N") + taskControl.Prospect.LastName1.Trim().Replace("???", "n").Replace("???", "N") + taskControl.TaskControlID.ToString().Trim() + OPPEndorID.ToString().Trim();
        //                //    string _FileName = taskControl.Prospect.FirstName.Trim().Replace("???", "n").Replace("???", "N") + taskControl.Prospect.LastName1.Trim().Replace("???", "n").Replace("???", "N") + taskControl.TaskControlID.ToString().Trim() + OPPEndorID.ToString().Trim() + ".pdf";
        //                //    //??????
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
        //    TaskControl.TaskControl taskControl = TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControlID, userID);

        //    Session.Clear();
        //    Session["TaskControl"] = taskControl;
        //    Response.Redirect("Policies.aspx?" + taskControl.TaskControlID, true);

        //    Panel3.Visible = false;
        //    Panel2.Visible = false;
        //    lblEndor.Visible = true;
        //    DataGridGroup.Visible = true;
        //    btnReturn.Visible = false;

        //}

        //protected void Button5_Click(object sender, EventArgs e)
        //{
        //    EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        //    int userID = 0;
        //    userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

        //    if (Session["PLEndorUpdate"] == null)
        //    {
        //        // Salvar el num. de Endo en Policy
        //        EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];
        //        //int endNum = taskControl.Endoso + 1;
        //        //taskControl.Endoso = endNum;
        //        taskControl.SaveOnlyPolicy(userID);
        //        Session["TaskControl"] = taskControl;
        //    }

        //    if (Session["ApplyEndorsement"] != null)
        //    {
        //        int a = (int)Session["ApplyEndorsement"];
        //        EPolicy.TaskControl.Policies newOPP2 = (EPolicy.TaskControl.Policies)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(a, userID);

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

        //private void CalculateEndorsement(EPolicy.TaskControl.Policies OpptaskControl)
        //{
        //    EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];

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

        //private double SetEndorsementToCalculateDifference(EPolicy.TaskControl.Policies taskControl, EPolicy.TaskControl.Policies OpptaskControl)
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
        //    TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
        //    TaskControl.Policies taskControl2 = (TaskControl.Policies)Session["PLEndorsement"];

        //    DbRequestXmlCookRequestItem[] cookItems =
        //        new DbRequestXmlCookRequestItem[24];

        //    DbRequestXmlCooker.AttachCookItem("OPPTaskControlID", SqlDbType.Int, 0, OPPTaskControlID.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("OPPQuotesID", SqlDbType.Int, 0, OPPQuotesID.ToString(), ref cookItems);

        //    if(txtEndorDate.Text != "")
        //        DbRequestXmlCooker.AttachCookItem("EndoEffective", SqlDbType.DateTime, 0, txtEndorDate.Text.Trim(), ref cookItems);
        //    else
        //        DbRequestXmlCooker.AttachCookItem("EndoEffective", SqlDbType.DateTime, 0, DateTime.Now.ToShortDateString(), ref cookItems);

        //    DbRequestXmlCooker.AttachCookItem("Factor", SqlDbType.Float, 0, mFactor.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ProRataPremium", SqlDbType.Float, 0, NewProRataTotPrem.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ShortRatePremium", SqlDbType.Float, 0, NewShotRateTotPrem.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ActualPremPropeties", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ActualPremLiability", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ActualPremAuto", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ActualPremUmbrella", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("ActualPremTotal", SqlDbType.Float, 0, taskControl.TotalPremium.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("PreviousPremProperties", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("PreviousPremLiability", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("PreviousPremAuto", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("PreviousPremUmbrella", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("PreviousPremTotal", SqlDbType.Float, 0, taskControl2.TotalPremium.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("DiffPremProperties", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("DiffPremLiability", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("DiffPremAuto", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("DiffPremUmbrella", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("DiffPremTotal", SqlDbType.Float, 0, (taskControl.TotalPremium - taskControl2.TotalPremium).ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("AdditionalPremium", SqlDbType.Float, 0, txtAdditionalPremium.Text.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("EndoNum", SqlDbType.Char, 4, (taskControl.Endoso + 1).ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("Cambios", SqlDbType.VarChar, 5000, txtEndoComments.Text.Trim(), ref cookItems);


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
        //        DbRequestXmlCookRequestItem[] cookItems =
        //        new DbRequestXmlCookRequestItem[22];

        //    EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];
        //    TaskControl.Policies taskControl2 = (TaskControl.Policies)Session["PLEndorsement"];
        //    DataTable DtEndorsement = GetOPPEndorsements(taskControl2.TaskControlID);
        //    int OPPEndorsementID = int.Parse(DtEndorsement.Rows[DtEndorsement.Rows.Count - 1]["OPPEndorsementID"].ToString());

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
        //    DbRequestXmlCooker.AttachCookItem("ActualPremTotal", SqlDbType.Float, 0, taskControl.TotalPremium.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("PreviousPremProperties", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("PreviousPremLiability", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("PreviousPremAuto", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("PreviousPremUmbrella", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("PreviousPremTotal", SqlDbType.Float, 0, taskControl2.TotalPremium.ToString(), ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("DiffPremProperties", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("DiffPremLiability", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("DiffPremAuto", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("DiffPremUmbrella", SqlDbType.Float, 0, "0.00", ref cookItems);
        //    DbRequestXmlCooker.AttachCookItem("DiffPremTotal", SqlDbType.Float, 0, (taskControl.TotalPremium - taskControl2.TotalPremium).ToString(), ref cookItems);
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

        //private void VerifyChanges(EPolicy.TaskControl.Policies newOPP, int userID)
        //{
        //    EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["PLEndorsement"];
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
        //    history.BuildNotesForHistory("LastName 2", taskControl.Customer.LastName2, newOPP.Customer.LastName2, mode);
        //    history.BuildNotesForHistory("Address 1", taskControl.Customer.Address1, newOPP.Customer.Address1, mode);
        //    history.BuildNotesForHistory("Address 2", taskControl.Customer.Address2, newOPP.Customer.Address2, mode);
        //    history.BuildNotesForHistory("City", taskControl.Customer.City, newOPP.Customer.City, mode);
        //    history.BuildNotesForHistory("State", taskControl.Customer.State, newOPP.Customer.State, mode);
        //    history.BuildNotesForHistory("Zip Code", taskControl.Customer.ZipCode, newOPP.Customer.ZipCode, mode);
        //    history.BuildNotesForHistory("Home Phone Number", taskControl.Customer.HomePhone, newOPP.Customer.HomePhone, mode);
        //    history.BuildNotesForHistory("Work Phone Number", taskControl.Customer.JobPhone, newOPP.Customer.JobPhone, mode);
        //    history.BuildNotesForHistory("Cellphone Number", taskControl.Customer.Cellular, newOPP.Customer.Cellular, mode);
        //    history.BuildNotesForHistory("Email", taskControl.Customer.Email, newOPP.Customer.Email, mode);
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

        //    //Campos de Empleados
        //    history.BuildNotesForHistory("Phys. Assitant Qty.", taskControl.QuantityTN1.ToString(), newOPP.QuantityTN1.ToString(), mode);
        //    history.BuildNotesForHistory("Nurse Midwife Qty.", taskControl.QuantityTN2.ToString(), newOPP.QuantityTN2.ToString(), mode);
        //    history.BuildNotesForHistory("Nurse Anesthetist Qty.", taskControl.QuantityTN3.ToString(), newOPP.QuantityTN3.ToString(), mode);
        //    history.BuildNotesForHistory("Nurse Practicioner Qty.", taskControl.QuantityTN4.ToString(), newOPP.QuantityTN4.ToString(), mode);
        //    history.BuildNotesForHistory("Other Personel Qty.", taskControl.QuantityTN5.ToString(), newOPP.QuantityTN5.ToString(), mode);

        //    history.BuildNotesForHistory("Phys. Assitant Qty.", taskControl.EQuantityTN1.ToString(), newOPP.EQuantityTN1.ToString(), mode);
        //    history.BuildNotesForHistory("Nurse Midwife Qty.", taskControl.EQuantityTN2.ToString(), newOPP.EQuantityTN2.ToString(), mode);
        //    history.BuildNotesForHistory("Nurse Anesthetist Qty.", taskControl.EQuantityTN3.ToString(), newOPP.EQuantityTN3.ToString(), mode);
        //    history.BuildNotesForHistory("Nurse Practicioner Qty.", taskControl.EQuantityTN4.ToString(), newOPP.EQuantityTN4.ToString(), mode);
        //    history.BuildNotesForHistory("Other Personel Qty.", taskControl.EQuantityTN5.ToString(), newOPP.EQuantityTN5.ToString(), mode);
        //    //Terminan Campos de Empleados

        //    history.Actions = "EDIT";

        //    //history.KeyID = this.TaskControlID.ToString();
        //    //history.Subject = "POLICIES";
        //    //history.UsersID = userID;
        //    //history.GetNotes();
        //    history.GetSaveHistory();
        //    txtEndoComments.Text = history.Notes.ToUpper().Trim();

        //}

        //private void FillEndorsementGrid()
        //{
        //    EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];

        //    if(taskControl.isEndorsement)
        //        taskControl = (EPolicy.TaskControl.Policies)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControlID, userID); //(EPolicy.TaskControl.Policies)Session["Original"];

        //    DataGridGroup.DataSource = null;
        //    DtEndorsement = null;

        //    DtEndorsement = GetOPPEndorsements(taskControl.TaskControlID);//taskControl.EndorsementCollection;

        //    Session.Remove("DtEndorsement");
        //    Session.Add("DtEndorsement", DtEndorsement);

        //    if (DtEndorsement != null)
        //    {
        //        if (DtEndorsement.Rows.Count != 0)
        //        {
        //            DataGridGroup.DataSource = DtEndorsement;
        //            DataGridGroup.DataBind();
        //            lblEndor.Visible = true;
        //            DataGridGroup.Visible = true;
        //            chkUserMod.Checked = true;
        //            TxtUserPremium.Text = taskControl.TotalPremium.ToString("###,##0.00");
        //        }
        //    }
        //    else
        //    {
        //        lblEndor.Visible = false;
        //        chkUserMod.Checked = false;
        //        DataGridGroup.DataSource = null;
        //        DataGridGroup.DataBind();
        //    }
        //}

        //private void ApplyEndorsement(EPolicy.TaskControl.Policies newOPP, int userID)
        //{
        //    EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];
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
        //    EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];

        //    //Session.Clear();
        //    //EPolicy.TaskControl.Policies taskControlQuote = new EPolicy.TaskControl.Policies();
        //    //taskControlQuote.isEndorsement = true;

        //    //int tcID = taskControl.TaskControlID;
        //    //taskControlQuote = taskControl;
        //    //taskControlQuote.Customer = taskControl.Customer;
        //    //taskControlQuote.Prospect = taskControl.Prospect;

        //    ////Para aplicar el ultimo endoso, sino a la poliza original
        //    ////DataTable endososList = EPolicy.TaskControl.OptimaPersonalPackage.GetEndorsementByEndoNum(tcID);
        //    ////if (endososList.Rows.Count == 0)
        //    ////{


        //    //taskControlQuote.Mode = 1; //ADD
        //    //taskControlQuote.TaskControlID = tcID;
        //    ////taskControlQuote.IsQuote = true;
        //    //taskControlQuote.isEndorsement = true;
        //    //taskControlQuote.TaskControlTypeID = int.Parse(EPolicy.LookupTables.LookupTables.GetID("TaskControlType", "CorporatePolicyQuote"));

        //    //taskControlQuote.TCIDQuotes = 0;

        //    //string EndoDateTemp = DateTime.Now.ToShortDateString();
        //    EPolicy.TaskControl.Policies taskControl2 = (EPolicy.TaskControl.Policies)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControlID, userID);
        //    //Session.Remove("TaskControl");
        //    //Session.Add("TaskControl", taskControlQuote);
        //    Session.Add("PLEndorsement", taskControl2);
        //    //Session.Add("Original", taskControl2);
        //    //Session.Add("PLEndorsementDate", EndoDateTemp);
        //    //Session.Add("TaskControlOriginal", taskControl);

        //    Session.Add("TaskControl", taskControl);
        //    taskControl.isEndorsement = true;
        //    taskControl.Mode = (int)TaskControl.TaskControl.TaskControlMode.UPDATE;
        //    Session.Add("TaskControl", taskControl);
        //    //pnlEndorsement.Visible = true;
        //    Panel3.Visible = false;
        //    Panel2.Visible = true;
        //    lblEndor.Visible = false;
        //    DataGridGroup.Visible = false;
        //    lblEndorDate.Visible = true;
        //    txtEndorDate.Visible = true;

        //    RemoveSessionLookUp();
        //    Response.Redirect("Policies.aspx");
        //}

        //private void CalculateEndorsementOnlyForQuote()
        //{
        //    EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];
        //    EPolicy.TaskControl.Policies OldOPP = (EPolicy.TaskControl.Policies)Session["PLEndorsement"];

        //    if (taskControl.isEndorsement)
        //    {
        //        double totprem = SetEndorsementToCalculateDifferenceOnlyForQuote(OldOPP, taskControl);

        //        mFactor = 0.0;
        //        NewProRataTotPrem = 0.0;
        //        NewShotRateTotPrem = 0.0;
        //        string EndorDate = "";
        //        if(txtEndorDate.Text != "")
        //            EndorDate = txtEndorDate.Text.Trim();//DateTime.Now.ToShortDateString();//txtEntryDate.Text.Trim();
        //        else
        //            EndorDate = DateTime.Now.ToShortDateString();

        //        //Si no es Flat no hace calculo de prima prorrateada.
        //        if (taskControl.EffectiveDate != EndorDate.Trim())
        //        {
        //            TimeSpan tsDAYS1 = DateTime.Parse(txtExpDt.Text) - DateTime.Parse(EndorDate.Trim());
        //            TimeSpan tsDAYS2 = DateTime.Parse(txtExpDt.Text) - DateTime.Parse(txtEffDt.Text);

        //            int mDAYS1 = tsDAYS1.Days;
        //            int mDAYS2 = tsDAYS2.Days;

        //            mFactor = double.Parse(mDAYS1.ToString()) / double.Parse(mDAYS2.ToString());
        //            mFactor = Math.Round(mFactor, 3);
        //            NewProRataTotPrem = Math.Round(totprem * mFactor, 0);
        //            NewShotRateTotPrem = Math.Round(NewProRataTotPrem * 0.9, 0);

        //            txtOriginalPremiumQuote.Text = OldOPP.TotalPremium.ToString("###,##0.00");
        //            txtFactorQuote.Text = mFactor.ToString().Trim();
        //            txtProRataQuote.Text = NewProRataTotPrem.ToString("###,###,##0.00");
        //            //txtShortRate.Text = NewShotRateTotPrem.ToString().Trim();
        //            txtAdditionalPremium.Text = NewProRataTotPrem.ToString("###,###,##0.00");

        //            double totpremTemp = OldOPP.TotalPremium;
        //            if (!chkEndorsement.Checked)
        //            {
        //                txtProRataPremium.Text = (totpremTemp + double.Parse(txtAdditionalPremium.Text.Trim())).ToString("###,##0.00");
        //                chkUserMod.Checked = true;
        //                TxtPremium.Text = txtProRataPremium.Text;
        //                TxtUserPremium.Text = txtProRataPremium.Text;
        //                TxtTotalPremium.Text = txtProRataPremium.Text;
        //                txtTotalPrimary.Text = txtProRataPremium.Text;
        //                txtTotalExcess.Text = txtProRataPremium.Text;
        //            }
        //            else
        //            {
        //                txtProRataPremium.Text = (totpremTemp - double.Parse(txtAdditionalPremium.Text.Trim())).ToString("###,##0.00");
        //                chkUserMod.Checked = true;
        //                TxtPremium.Text = txtProRataPremium.Text;
        //                TxtUserPremium.Text = txtProRataPremium.Text;
        //                TxtTotalPremium.Text = txtProRataPremium.Text;
        //                txtTotalPrimary.Text = txtProRataPremium.Text;
        //                txtTotalExcess.Text = txtProRataPremium.Text;
        //            }
        //        }
        //        else
        //        {
        //            txtOriginalPremiumQuote.Text = OldOPP.TotalPremium.ToString("###,##0.00");
        //            txtFactorQuote.Text = "0";
        //            txtProRataQuote.Text = "0.00";
        //            txtAdditionalPremium.Text = "0.00";
        //            txtProRataPremium.Text = OldOPP.TotalPremium.ToString("###,###,##0.00");
        //        }
        //    }
        //}

        //private double SetEndorsementToCalculateDifferenceOnlyForQuote(EPolicy.TaskControl.Policies taskControl, EPolicy.TaskControl.Policies OpptaskControl)
        //{
        //    string _ActualPremTotal = OpptaskControl.TotalPremium.ToString("###,###,##0.00");
        //    string _PreviousPremTotal = taskControl.TotalPremium.ToString("###,###,##0.00");

        //    //Calculate Difference

        //    double totalPrev = taskControl.TotalPremium + taskControl.Charge;
        //    double totalActual = OpptaskControl.TotalPremium + OpptaskControl.Charge;

        //    string _DiffPremTotal = CalculateEndorsementDifferenceOnlyForQuote(totalActual.ToString(), totalPrev.ToString());

        //    if (double.Parse(_DiffPremTotal) > 0)
        //        return double.Parse(_DiffPremTotal);
        //    else
        //        return totalActual;
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

        //public static DataTable GetOPPEndorsements(int taskControlID)
        //{
        //    DbRequestXmlCookRequestItem[] cookItems =
        //        new DbRequestXmlCookRequestItem[1];

        //    DbRequestXmlCooker.AttachCookItem("OPPTaskControlID",
        //        SqlDbType.Int, 0, taskControlID.ToString(),
        //        ref cookItems);

        //    Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
        //    XmlDocument xmlDoc;

        //    try
        //    {
        //        xmlDoc = DbRequestXmlCooker.Cook(cookItems);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Could not cook items.", ex);
        //    }

        //    DataTable dt = exec.GetQuery("GetOPPEndorsementsByTaskControlID", xmlDoc);

        //    return dt;
        //}

        //private void ApplyEndorsementsToRenewal()
        //{
        //    EPolicy.TaskControl.Policies OldOPP = (EPolicy.TaskControl.Policies)Session["TaskControl"];
        //    EPolicy.TaskControl.Policies taskControl = new EPolicy.TaskControl.Policies();



        //}

        //protected void txtEndorDate_TextChanged(object sender, EventArgs e)
        //{
        //    if(txtEndorDate.Text != "")
        //        CalculateEndorsementOnlyForQuote();
        //}

        //

        //protected void chkEndorsement_CheckedChanged(object sender, EventArgs e)
        //{
        //    EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];

        //    if (chkEndorsement.Checked)
        //    {
        //        if (taskControl.PolicyType.Trim() == "PP")
        //        {
        //            Label52.Visible = false;
        //            Label70.Visible = false;
        //            txtTotalPrimary.Visible = false;
        //            pnlPrimary.Visible = false;
        //            Button3.Visible = false;

        //            CalculateEndorsementOnlyForQuote();
        //        }
        //        else
        //        {
        //            Label71.Visible = false;
        //            txtTotalExcess.Visible = false;
        //            Label64.Visible = false;
        //            pnlExcess.Visible = false;
        //            Button3.Visible = false;
        //            CalculateEndorsementOnlyForQuote();
        //        }
        //    }
        //    else
        //    {
        //        if (taskControl.PolicyType.Trim() == "PP")
        //        {
        //            Label52.Visible = true;
        //            Label70.Visible = true;
        //            txtTotalPrimary.Visible = true;
        //            pnlPrimary.Visible = true;
        //            Button3.Visible = true;
        //            CalculateEndorsementOnlyForQuote();
        //        }
        //        else
        //        {
        //            Label71.Visible = true;
        //            txtTotalExcess.Visible = true;
        //            Label64.Visible = true;
        //            pnlExcess.Visible = true;
        //            Button3.Visible = true;
        //            CalculateEndorsementOnlyForQuote();
        //        }
        //    }
        //}

        //public void InsertEndorsementPayment()
        //{
        //    Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
        //    try
        //    {
        //        Executor.BeginTrans();
        //        int _PartialPaymentID = Executor.Insert("AddPartialPayments", this.GetInsertEndorsementPaymentXml());
        //        Executor.CommitTrans();
        //    }
        //    catch (Exception xcp)
        //    {
        //        Executor.RollBackTrans();
        //        throw new Exception("Error while trying to save the Endorsement Payment for this Policy. " + xcp.Message, xcp);
        //    }
        //}

        //private XmlDocument GetInsertEndorsementPaymentXml()
        //{
        //    TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

        //    int creditDebitID = 1;
        //    double totprem = NewProRataTotPrem * -1;

        //    DbRequestXmlCookRequestItem[] cookItems =
        //        new DbRequestXmlCookRequestItem[12];

        //    DbRequestXmlCooker.AttachCookItem("TaskControlID",
        //        SqlDbType.Int, 0, taskControl.TaskControlID.ToString(),
        //        ref cookItems);

        //    DbRequestXmlCooker.AttachCookItem("PaymentDate",
        //        SqlDbType.DateTime, 8, DateTime.Now.ToString(),
        //        ref cookItems);

        //    DbRequestXmlCooker.AttachCookItem("TransactionAmount",
        //        SqlDbType.Money, 8, totprem.ToString(),
        //        ref cookItems);

        //    string checkNumber = "Endorsement";
        //    DbRequestXmlCooker.AttachCookItem("CheckNumber",
        //        SqlDbType.Char, 10, checkNumber.ToString(),
        //        ref cookItems);

        //    DbRequestXmlCooker.AttachCookItem("onitDebitID",
        //        SqlDbType.Int, 0, creditDebitID.ToString(),
        //        ref cookItems);

        //    DbRequestXmlCooker.AttachCookItem("TransactionDate",
        //        SqlDbType.DateTime, 8, DateTime.Now.ToString(),
        //        ref cookItems);

        //    float commAgency = 0.00F;
        //    DbRequestXmlCooker.AttachCookItem("CommissionAgency",
        //        SqlDbType.Float, 8, commAgency.ToString(),
        //        ref cookItems);

        //    float commPrem = 0.00F;
        //    DbRequestXmlCooker.AttachCookItem("CommissionPrem",
        //        SqlDbType.Float, 8, commPrem.ToString(),
        //        ref cookItems);

        //    bool lic = false;
        //    DbRequestXmlCooker.AttachCookItem("License",
        //        SqlDbType.Bit, 1, lic.ToString(),
        //        ref cookItems);

        //    DbRequestXmlCooker.AttachCookItem("PolicyClass",
        //        SqlDbType.Int, 0, taskControl.PolicyClassID.ToString(),
        //        ref cookItems);

        //    string paymentReference = "Endorsement";
        //    DbRequestXmlCooker.AttachCookItem("PaymentReference",
        //        SqlDbType.VarChar, 30, paymentReference.ToString(),
        //        ref cookItems);

        //    int taskpaymentID = 0;
        //    DbRequestXmlCooker.AttachCookItem("TaskPaymentID",
        //        SqlDbType.Int, 0, taskpaymentID.ToString(),
        //        ref cookItems);
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
        //protected void TxtTerm_TextChanged(object sender, EventArgs e)
        //{
        //    if (TxtTerm.Text != "")
        //        CalculateEndorsementOnlyForQuote();
        #endregion

        #region Endorsement Features

        protected void btnEndor_Click(object sender, EventArgs e)
        {
            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
            int userID = 0;
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
            EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];
            //EPolicy.TaskControl.Policies taskControl2 = (EPolicy.TaskControl.Policies)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControlID, userID);

            Session.Add("PreviousPremium", taskControl.TotalPremium);
            Session.Add("OriginalPolicy", taskControl);

            taskControl.isEndorsement = true;
            previousPremium = taskControl.TotalPremium;
            taskControl.Mode = (int)TaskControl.TaskControl.TaskControlMode.UPDATE;
            txtEndorsementID.Text = "";

            Session.Add("TaskControl", taskControl);

            RemoveSessionLookUp();
            Response.Redirect("AHCPrimaryPolicies.aspx");
        }

        private void CalculateEndorsement()
        {
            EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];
            EPolicy.TaskControl.Policies OldOPP = (EPolicy.TaskControl.Policies)Session["OriginalPolicy"];
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

        private double CalculateDifference(EPolicy.TaskControl.Policies taskControl)
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

        private string VerifyChanges(EPolicy.TaskControl.Policies newOPP, int userID)
        {
            EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["OriginalPolicy"];
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

            history.KeyID = taskControl.TaskControlID.ToString();
            history.Subject = "POLICIES";
            history.UsersID = userID;
            //history.GetNotes();
            history.GetSaveHistory();
            return history.Notes.ToUpper().Trim();

        }

        private XmlDocument GetInsertEndorsementsXml(int TaskControlID)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
            TaskControl.Policies taskControl2 = (TaskControl.Policies)Session["OriginalPolicy"];

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

        private XmlDocument GetUpdateEndorsementsXml(int TaskControlID)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
            TaskControl.Policies taskControl2 = (TaskControl.Policies)Session["OriginalPolicy"];

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

        private void FillEndorsementGrid()
        {
            EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];

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
                EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];
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
                        txtRetroEffDate.Text = e.Item.Cells[5].Text.Trim().Replace("&nbsp;", "");
                        txtRetroEffDate.Enabled = false;
                        txtEndoPremium.Text = e.Item.Cells[7].Text.Trim();
                        txtEndoPremium.Enabled = false;
                        ddlEndoType.SelectedIndex = ddlEndoType.Items.IndexOf(
                        ddlEndoType.Items.FindByText(e.Item.Cells[6].Text.Trim()));
                        ddlEndoType.Enabled = false;
                        txtEndoComments.Enabled = false;
                        if (e.Item.Cells[8].Text.Trim() != " ")
                            txtEndoComments.Text = e.Item.Cells[8].Text.Trim();

                        if (e.Item.Cells[9].Text.Trim() != " ")
                            txtEndoComments.Text = e.Item.Cells[8].Text.Trim() + System.Environment.NewLine + e.Item.Cells[9].Text.Trim();

                        btnTailQuote.Visible = false;
                        break;
                    case "Delete":
                        taskControl.Endoso = taskControl.Endoso - 1;

                        if (e.Item.Cells[6].Text.Trim() != "&nbsp;" && e.Item.Cells[6].Text.Trim() != String.Empty && e.Item.Cells[6].Text.Trim() != null)
                            TxtPremium.Text = (double.Parse(TxtPremium.Text) - double.Parse(e.Item.Cells[6].Text)).ToString("###,##0.00");
                        TxtTotalPremium.Text = TxtPremium.Text;
                        chkUserMod.Checked = true;
                        txtEndoEffDate.Text = "";

                        FillProperties();

                        taskControl.SavePolicies(userID);  //(userID);

                        //Update Inception Payment Amount
                        UpdateInceptionPartialPayments(taskControl.TaskControlID, (taskControl.TotalPremium + taskControl.Charge));
                        PaymentPolicy pp = new PaymentPolicy();

                        Session.Remove("DtPolicyDetail");

                        //Session.Add("TaskControl",taskControl);
                        //Session.Remove("TaskControl");
                        taskControl.Mode = 4;
                        Session["TaskControl"] = taskControl;

                        DeleteEndorsements(int.Parse(e.Item.Cells[1].Text.Trim()));

                        FillTextControl();
                        DisableControls();

                        this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Endorsement deleted successfully.");
                        this.litPopUp.Visible = true;

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
                        taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];
                        //EPolicy.TaskControl.Policies taskControl2 = (EPolicy.TaskControl.Policies)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControlID, userID);

                        Session.Add("PreviousPremium", taskControl.TotalPremium);
                        Session.Add("OriginalPolicy", taskControl);

                        taskControl.isEndorsement = true;
                        previousPremium = taskControl.TotalPremium;
                        taskControl.Mode = (int)TaskControl.TaskControl.TaskControlMode.UPDATE;

                        Session.Add("TaskControl", taskControl);

                        EnableControls();

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
                        //    string fileName = taskControl.Prospect.FirstName.Trim().Replace("???", "n").Replace("???", "N") + taskControl.Prospect.LastName1.Trim().Replace("???", "n").Replace("???", "N") + taskControl.TaskControlID.ToString().Trim() + OPPEndorID.ToString().Trim();
                        //    string _FileName = taskControl.Prospect.FirstName.Trim().Replace("???", "n").Replace("???", "N") + taskControl.Prospect.LastName1.Trim().Replace("???", "n").Replace("???", "N") + taskControl.TaskControlID.ToString().Trim() + OPPEndorID.ToString().Trim() + ".pdf";
                        //    //??????
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

        protected void btnHideEndoPanel_Click(object sender, EventArgs e)
        {
            btnHideEndoPanel.Visible = false;
            pnlEndorsement.Visible = false;
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

        private string PrintAspenPolicy(string rdlcDocument)
        {
            try
            {
                TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
                ReportViewer viewer = new ReportViewer();
                string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                string specialtyABDC = "";
                string otherSpecialtyISOCode = "";

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
                    ReportParameter[] param = new ReportParameter[6];
                    param[0] = new ReportParameter("effectiveDate", DateTime.Parse(taskControl.EffectiveDate).ToShortDateString());
                    param[1] = new ReportParameter("policyType", taskControl.PolicyType);
                    param[2] = new ReportParameter("policyNo", taskControl.PolicyNo);
                    param[3] = new ReportParameter("retroDate", DateTime.Parse(taskControl.RetroactiveDate).ToShortDateString());
                    param[4] = new ReportParameter("entryDate", taskControl.EntryDate.ToShortDateString());
                    param[5] = new ReportParameter("agency", taskControl.Agency);
                    viewer.LocalReport.SetParameters(param);
                    viewer.LocalReport.Refresh();
                }

                if (rdlcDocument == "RenewalEndorsementAspen1.rdlc")
                {

                    if (ddlRate.SelectedItem.Text.Trim().ToUpper().Contains("NS") || ddlRate.SelectedItem.Text.Trim().ToUpper().Contains("NO SURGERY"))
                        specialtyABDC = "N/A";
                    else if (ddlRate.SelectedItem.Text.Trim().ToUpper().Contains("MS") || ddlRate.SelectedItem.Text.Trim().ToUpper().Contains("NO MAJOR"))
                        specialtyABDC = "D";
                    else if (ddlRate.SelectedItem.Text.Trim().ToUpper().Contains("SURGERY"))
                        specialtyABDC = "C,D";
                    else if (ddlRate.SelectedItem.Text.Trim().ToUpper().Contains("MAJOR SURGERY"))
                        specialtyABDC = "N/A";
                    else if (ddlRate.SelectedItem.Text.Trim().ToUpper().Contains("ANGIOGRAPHY, ARTERIOGRAPHY, CATHE."))
                        specialtyABDC = "D";
                    else
                        specialtyABDC = "N/A";

                    //DataTable dt = new DataTable();


                    //dt = TaskControl.Policy.GetOtherSpecialtyByISOCode(int.Parse(ddlOtherSpecialty.SelectedItem.Value));

                    //if (dt.Rows.Count > 0)
                    //{
                    //    otherSpecialtyISOCode = dt.Rows[0]["IsoCode"].ToString();
                    //}


                    ReportParameter[] param = new ReportParameter[19];
                    param[0] = new ReportParameter("policyNo", taskControl.PolicyType + "-" + taskControl.PolicyNo);
                    param[1] = new ReportParameter("retroDate", DateTime.Parse(taskControl.RetroactiveDate).ToString("MMMM dd yyyy"));
                    param[2] = new ReportParameter("effectiveDate", DateTime.Parse(taskControl.EffectiveDate).ToString("MMMM dd yyyy"));
                    param[3] = new ReportParameter("licenseNumber", txtLicense.Text.ToString());
                    param[4] = new ReportParameter("specialty", ddlRate.SelectedItem.ToString() + "/" + ddlOtherSpecialty.SelectedItem.ToString());
                    param[5] = new ReportParameter("advancePremium", taskControl.TotalPremium.ToString("$###,###.00"));
                    param[6] = new ReportParameter("limits1", ddlPrMedicalLimits.SelectedItem.ToString());
                    param[7] = new ReportParameter("expirationDate", DateTime.Parse(taskControl.ExpirationDate).ToString("MMMM dd yyyy"));
                    param[8] = new ReportParameter("insuredAddress", TxtAddrs1.Text.ToString());
                    param[9] = new ReportParameter("insuredName", TxtFirstName.Text.ToString() + " " + TxtInitial.Text.ToString() + " " + txtLastname1.Text.ToString());
                    param[10] = new ReportParameter("numeroEmpleados", txtPrimaryTN1.Text.ToString() + txtPrimaryTN2.Text.ToString() + txtPrimaryTN3.Text.ToString()
                    + txtPrimaryTN4.Text.ToString() + txtPrimaryTN5.Text.ToString());
                    param[11] = new ReportParameter("empleadoAdicional", txtExcessTN1.Text.ToString() + txtExcessTN2.Text.ToString() + txtExcessTN3.Text.ToString()
                    + txtExcessTN4.Text.ToString() + txtExcessTN5.Text.ToString());
                    param[12] = new ReportParameter("todaydate", DateTime.Today.ToShortDateString());
                    param[13] = new ReportParameter("address2", TxtCity.Text.ToString() + ", " + TxtState.Text.ToString() + ", " + TxtZip.Text.ToString());
                    param[14] = new ReportParameter("isocode", ddlRate.SelectedItem.Value.ToString()); //otherSpecialtyISOCode.ToString() + "/" + 
                    param[15] = new ReportParameter("agent", ddlAgent.SelectedItem.ToString().Trim());
                    param[16] = new ReportParameter("agency", ddlAgency.SelectedItem.ToString().Trim());
                    param[17] = new ReportParameter("insuredAddress2", TxtAddrs2.Text.ToString());
                    param[18] = new ReportParameter("specialtyABCD", specialtyABDC.ToString());




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

        protected string  PrintWordProcessedPath(string whereclause, bool IncludeCert)
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

           // PrintMW_PDFMerge(mergePaths, ProcessedPath);
            return mergePaths[0].ToString(); ;
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
            string FinalFile = ProcessedPath + LblControlNo.Text.ToString().Trim() + Filename + "_" + DateTime.Now.ToString().Replace("/", "-").Replace(":", "").Replace(" ", "") + ".pdf";
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

            if (taskControl.Charge == 0.00)
            {
                whereClause += " and (FormName != 'ENDOSO DERRAMAS') ";
            }

            return whereClause;
        }

        protected void ddlInsuranceCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlAgency_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlAgency_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
        protected void ddlPriPolLimits1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnComments_Click1(object sender, EventArgs e)
        {
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];
            EPolicy.TaskControl.Comment comment = new EPolicy.TaskControl.Comment();

            comment.TaskControlID = taskControl.TaskControlID;
            comment.PolicyNo = taskControl.PolicyNo;
            Session.Add("TaskControlComments", comment);

            //RemoveSessionLookUp();

            //Response.Redirect("Comments.aspx");

            RemoveSessionLookUp();
            Session.Add("FromPage", "AHCPrimaryPolicies.aspx");
            Response.Redirect("Comments.aspx");
        }
        protected void txtLastname1_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtClaimNumber_TextChanged(object sender, EventArgs e)
        {

        }

        public static DataTable GetIsoCodeByRateID(int prmrateid)
        {
            DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("prmrateid",
            SqlDbType.Int, 0, prmrateid.ToString(),
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
                dt = exec.GetQuery("GetIsoCodeByRateID", xmlDoc);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }

        public static DataTable GetReportMasterDocumentsByCriteria(string PolicyType, string TransactionType, string FormName, string EffectiveDate)
        {
            DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[4];

            DbRequestXmlCooker.AttachCookItem("PolicyType",
            SqlDbType.Int, 0, PolicyType.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("TransactionType",
            SqlDbType.Int, 0, TransactionType.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("FormName",
            SqlDbType.Int, 0, FormName.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EffectiveDate",
            SqlDbType.Int, 0, EffectiveDate.ToString(),
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

        public static void AddChargePartialPayments(TaskControl.Policies taskControl)
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