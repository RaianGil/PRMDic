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
using EPolicy.LookupTables;
using EPolicy.Login;
using Baldrich.DBRequest;
using EPolicy.XmlCooker;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Validation;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.IO;
using System.IO.Compression;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using EPolicy.TaskControl;

namespace EPolicy
{
	/// <summary>
	/// Summary description for UserPropertiesList.
	/// </summary>
    public partial class RenewPolicies : System.Web.UI.Page
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{

            //Label2.Visible = false;
            //txtFrom.Visible = false;

            //Label3.Visible = false;
            //txtTo.Visible = false;

			Login.Login cp = HttpContext.Current.User as Login.Login;
			if (cp == null)
			{
				Response.Redirect("Default.aspx?001");
			}
			else
			{
				if(!cp.IsInRole("ADMINISTRATOR"))
				{
					Response.Redirect("Default.aspx?001");
				}
			}

			if(!IsPostBack)
			{
                //if (cp.UserID == 1)
                //{
                //    txtInupt.Visible = true;
                //    BtnEncrypt.Visible = true;
                //    BtnDecrypt.Visible = true;
                //    txtResult.Visible = true;
                //}
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

            System.Web.UI.Control Banner = new System.Web.UI.Control();
			Banner = LoadControl(@"TopBanner1.ascx");
			this.Placeholder1.Controls.Add(Banner);

			/*//Setup Left-side Banner
            System.Web.UI.Control LeftMenu = new System.Web.UI.Control();
			LeftMenu = LoadControl(@"LeftMenu.ascx");
			this.phTopBanner1.Controls.Add(LeftMenu);*/
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.ToRenew.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ToRenew_ItemCommand);
            this.PreviewRenew.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.PreviewRenew_ItemCommand);
            

		}
		#endregion


        protected void RenewPolicy(System.Data.DataTable dt)
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = 0;
            try
            {

                System.Data.DataTable FinishedPolicies = new System.Data.DataTable();
                FinishedPolicies.Clear();
                FinishedPolicies.Columns.Add("TaskcontrolID");
                FinishedPolicies.Columns.Add("PolicyNumber");
                FinishedPolicies.Columns.Add("Anniversary");
                FinishedPolicies.Columns.Add("EffectiveDate");
                FinishedPolicies.Columns.Add("ExpirationDate");
                FinishedPolicies.Columns.Add("Customer");
                FinishedPolicies.Columns.Add("MedicalLimit");
                FinishedPolicies.Columns.Add("IsoCode");
                
                FinishedPolicies.Columns.Add("Premium");
                FinishedPolicies.Columns.Add("Charge");

                for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["TaskControlTypeID"].ToString() == "12" //Polices
                 || dt.Rows[i]["TaskControlTypeID"].ToString() == "23" //Allied
                 || dt.Rows[i]["TaskControlTypeID"].ToString() == "27" //First Dollar
                    ) 
	            {
                    TaskControl.Policies taskControl = (TaskControl.Policies)TaskControl.Policies.GetTaskControlByTaskControlID(int.Parse(dt.Rows[i]["taskcontrolID"].ToString()), userID);
                    TaskControl.Policies policies = new TaskControl.Policies();
                    EPolicy.TaskControl.Payments payments = new EPolicy.TaskControl.Payments();

                    policies = taskControl;


                    cmdSelect_Click();
                    System.Web.UI.WebControls.ListBox listtest = new System.Web.UI.WebControls.ListBox();
                    listtest = ddlSelectedAgent;
                    listtest.Items.Clear();
                    policies.LbxAgentSelected = listtest;

                    ListItem list = new ListItem("1" + " |" + taskControl.SupplierID.ToString(), "1" + " |" + taskControl.SupplierID.ToString());
                    System.Web.UI.WebControls.ListBox ls = new System.Web.UI.WebControls.ListBox();
                    policies.LbxSupplierSelected = ls;
                    policies.LbxSupplierSelected.Items.Add(list);
                    //Verifica si existen mas Supplier en la tabla de GroupSupplier con el MasterSupplier.
                    System.Data.DataTable dts = LookupTables.Supplier.GetGroupSupplierBySupplierID(taskControl.SupplierID.ToString());

                    int level = 3;
                    if (dts.Rows.Count != 0)
                    {
                        for (int a = 0; a <= dts.Rows.Count - 1; a++)
                        {
                            if (a == 0)
                            {
                                list = new ListItem("2" + " |" + dts.Rows[a]["SupplierID"].ToString(), "2" + " |" + dts.Rows[a]["SupplierID"].ToString());
                            }
                            else
                            {
                                list = new ListItem(level.ToString() + " |" + dts.Rows[a]["SupplierID"].ToString(), level.ToString() + " |" + dts.Rows[a]["SupplierID"].ToString());
                                level = level + 1;
                            }
                            policies.LbxSupplierSelected.Items.Add(list);
                        }
                    }

                    policies.SupplierID = taskControl.SupplierID;

                    policies.RetroactiveDate = taskControl.RetroactiveDate;
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


                    System.Data.DataTable dtLimit = new System.Data.DataTable();
                    string limit = "";
                    if (taskControl.PolicyType.Contains("E") || taskControl.PolicyType.Contains("PAH"))
                        dtLimit = LookupTables.LookupTables.GetTable("PRMedicalLimit");
                    else if (taskControl.PolicyType.Contains("F"))
                        dtLimit = GetPRFirstDollarLimit();
                    else
                        dtLimit = LookupTables.LookupTables.GetTable("PRPrimaryLimit");

                    for (int j   = 0; j < dtLimit.Rows.Count; j++)
                    {
                        if (dtLimit.Rows[j]["PRMedicalLimitID"].ToString().Trim() == taskControl.PRMedicalLimit.ToString().Trim())
	                    {
                            limit = dtLimit.Rows[j]["PRMedicalLimitDesc"].ToString().Trim();
	                    }  
                    }

                    System.Data.DataTable dtRate = new System.Data.DataTable();
                    string rate = "";
                    if (taskControl.PolicyType.Contains("E"))
                        dtRate = EPolicy.TaskControl.Application.GetPRMEDICRATEBYISOCODE(0, taskControl.IsoCode.Trim());
                    else if (taskControl.PolicyType.Contains("PAH"))
                        dtRate = EPolicy.TaskControl.Application.GetPRMEDICRATEPRIMARYAHCBYISOCODE(0, taskControl.IsoCode.Trim());
                    else if (taskControl.PolicyType.Contains("F"))
                        dtRate = GetPRMEDICRATEFIRSTDOLLARBYISOCODE("0", taskControl.IsoCode.Trim());
                    else
                        dtRate = EPolicy.TaskControl.Application.GetPRMEDICRATEPRIMARYBYISOCODE(0, taskControl.IsoCode.Trim());

                    for (int j = 0; j < dtRate.Rows.Count; j++)
                    {
                        if (dtRate.Rows[j]["PRMedicalLimitDesc"].ToString().Trim() == limit)
	                    {
                            rate = dtRate.Rows[j]["PRMEDICRATEID"].ToString().Trim();
	                    }  
                    }

                    int RetroYear = 0;
                    RetroYear = DateTime.Parse(policies.EffectiveDate).Year - DateTime.Parse(policies.RetroactiveDate).Year;

                    string[] array = rate.Split('|');

                        switch (RetroYear)
                        {
                            case 0:
                                policies.TotalPremium = double.Parse(array[3]);//taskControl.RateYear1;
                                break;
                            case 1:
                                policies.TotalPremium = double.Parse(array[4]);//taskControl.RateYear2;
                                break;
                            case 2:
                                policies.TotalPremium = double.Parse(array[5]);//taskControl.RateYear3;
                                break;
                            default:
                                policies.TotalPremium = double.Parse(array[6]);//taskControl.MCMRate;
                                break;
                        }

                        policies.Charge = CalculateCharge(policies.TotalPremium + policies.TotPremTN6, policies.CyberEndorsementPremium, policies.CancellationAmount, policies.EffectiveDate, policies.Anniversary);

                        policies.RateYear1 = double.Parse(array[3]);
                        policies.RateYear2 = double.Parse(array[4]);
                        policies.RateYear3 = double.Parse(array[5]);
                        policies.MCMRate = double.Parse(array[6]);

                        policies.SavePolicies(userID);  //(userID);
                        UpdateInceptionPartialPayments(policies.TaskControlID, (policies.TotalPremium + policies.Charge));

                        if (policies.CyberEndorsementPremium != 0.00)
                        {
                            EPolicy.TaskControl.PaymentPolicy payments2 = new EPolicy.TaskControl.PaymentPolicy();
                            payments2 = PaymentPolicy.GetPaymentsByTaskControlID(taskControl);
                            System.Data.DataTable dtend = GetLastPolicyCyberEndorsementByTaskcontrolID(policies.PolicyNo, policies.PolicyType);


                            bool HasCyberPayment = false;
                            bool HasCyberEndorsement = false;

                            for (int j = 0; j < payments2.PaymentsCollection.Rows.Count; j++)
                            {
                                if (payments2.PaymentsCollection.Rows[j]["CheckNumber"].ToString().Contains("Inception Cyber End."))
                                {
                                    HasCyberPayment = true;
                                }
                            }
                            for (int j = 0; j < dtend.Rows.Count; j++)
                            {
                                if (dtend.Rows[j]["taskcontrolid"].ToString().Trim() == policies.TaskControlID.ToString().Trim() && dtend.Rows[j]["EndorsementTypeID"].ToString().Trim() == "5")
                                {
                                    HasCyberEndorsement = true;
                                }
                            }

                            if (!HasCyberPayment)
                            {
                                AddCyberEndorsmentPartialPayments(policies);
                            }

                            if (!HasCyberEndorsement)
                            {
                                policies.Endoso = taskControl.Endoso + 1;
                                policies.SavePolicies(userID);
                                //txtEndorsementNo.Text = taskControl.Endoso.ToString();
                                AddEndorsementCyber(policies.PolicyNo, policies.PolicyType);
                            }
                        }

                        FinishedPolicies = AddToDataTable(FinishedPolicies, taskControl.TaskControlID.ToString(), taskControl.PolicyNo, taskControl.Anniversary, taskControl.EffectiveDate, taskControl.ExpirationDate,
                                                          taskControl.CustomerNo, limit, taskControl.IsoCode, taskControl.TotalPremium.ToString(), taskControl.Charge.ToString());
                        

	            }
                else
                    if (dt.Rows[i]["TaskControlTypeID"].ToString() == "18"//Corporate
                 || dt.Rows[i]["TaskControlTypeID"].ToString() == "24" //Allied Corp
                 || dt.Rows[i]["TaskControlTypeID"].ToString() == "27" //FirstDollar Corp
                    ) 
                {
                    TaskControl.CorporatePolicyQuote taskControl = (TaskControl.CorporatePolicyQuote)TaskControl.CorporatePolicyQuote.GetTaskControlByTaskControlID(int.Parse(dt.Rows[i]["taskcontrolID"].ToString()), userID);
                    TaskControl.CorporatePolicyQuote policies = new EPolicy.TaskControl.CorporatePolicyQuote(true);
                    policies = taskControl;
                    policies.RetroactiveDate = taskControl.RetroactiveDate;
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


                    policies.Charge = CalculateCharge(policies.TotalPremium, policies.CyberEndorsementPremium, policies.CancellationAmount, policies.EffectiveDate, policies.Anniversary);


                    policies.SaveCorporatePolicy(userID);
                    UpdateInceptionPartialPayments(policies.TaskControlID, (policies.TotalPremium + policies.Charge));
                    //UpdateInceptionPartialPayments(policies.TaskControlID, (policies.TotalPremium));


                  
                }
                    else if (dt.Rows[i]["TaskControlTypeID"].ToString() == "20") //Laboratory
                {
                    TaskControl.Laboratory taskControl = (TaskControl.Laboratory)TaskControl.Laboratory.GetTaskControlByTaskControlID(int.Parse(dt.Rows[i]["taskcontrolID"].ToString()), userID);
                    TaskControl.Laboratory policies = new TaskControl.Laboratory();

                    policies = taskControl;
                    policies.RetroactiveDate = taskControl.RetroactiveDate;
                    policies.Mode = 1;
                    policies.CancellationDate = "";
                    policies.CancellationEntryDate = "";
                    policies.CancellationUnearnedPercent = 0.00;
                    policies.CancellationReason = 0;
                    policies.CancellationMethod = 0;
                    policies.PaidAmount = 0.00;
                    policies.PaidDate = taskControl.PaidDate;
                    policies.Ren_Rei = "RN";
                    policies.Rein_Amt = taskControl.CancellationAmount;
                    policies.Coverage = taskControl.Coverage;

                    policies.CommissionAgency = 0.00;
                    policies.CommissionAgent = 0.00;
                    policies.CommissionAgencyPercent = "";
                    policies.CommissionAgentPercent = "";
                    policies.TaskControlID = 0;
                    policies.Status = "Inforce";

                    policies.EntryDate = DateTime.Now;
                    policies.EffectiveDate = (DateTime.Parse(policies.EffectiveDate).AddMonths(12)).ToShortDateString();
                    
                    policies.ExpirationDate = (DateTime.Parse(policies.ExpirationDate).AddMonths(12)).ToShortDateString();


                    policies = CalculateLaboratory(policies);
                    

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


                    policies.SaveLaboratory();
                    UpdateInceptionPartialPayments(policies.TaskControlID, (policies.TotalPremium + policies.Charge));
                    //UpdateInceptionPartialPayments(policies.TaskControlID, (policies.TotalPremium));
                    
                }
                    else if (dt.Rows[i]["TaskControlTypeID"].ToString() == "22") //Cyber
                {
                    TaskControl.Cyber taskControl = (TaskControl.Cyber)TaskControl.Cyber.GetTaskControlByTaskControlID(int.Parse(dt.Rows[i]["taskcontrolID"].ToString()), userID);
                    TaskControl.Cyber policies = new TaskControl.Cyber();


                    taskControl.isEndorsement = false;
                    policies = taskControl;
                    policies.RetroactiveDate = taskControl.RetroactiveDate;
                    policies.Mode = 1;
                    policies.CancellationDate = "";
                    policies.CancellationEntryDate = "";
                    policies.CancellationUnearnedPercent = 0.00;
                    policies.CancellationReason = 0;
                    policies.CancellationMethod = 0;
                    policies.PaidAmount = 0.00;
                    policies.PaidDate = taskControl.PaidDate;
                    policies.Ren_Rei = "RN";
                    policies.Rein_Amt = taskControl.CancellationAmount;
                    policies.Coverage = taskControl.Coverage;

                    policies.CommissionAgency = 0.00;
                    policies.CommissionAgent = 0.00;
                    policies.CommissionAgencyPercent = "";
                    policies.CommissionAgentPercent = "";
                    ////////////
                   
                    policies.TaskControlID = 0;
                    policies.Status = "Inforce";

                    policies.EntryDate = DateTime.Now;
                    policies.EffectiveDate = (DateTime.Parse(policies.EffectiveDate).AddMonths(12)).ToShortDateString();
                    
                    policies.ExpirationDate = (DateTime.Parse(policies.ExpirationDate).AddMonths(12)).ToShortDateString();
                    

                    //Recalculate();
                    //Calculate();
                    //CalculateCharge();
                    //policies.Charge = double.Parse(TxtCharge.Text);

                    policies.TotalPremium = taskControl.TotalPremium;
                    policies.Charge = CalculateCharge(policies.TotalPremium, policies.CyberEndorsementPremium, policies.CancellationAmount, policies.EffectiveDate, policies.Anniversary);

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

                    int RetroYear = 0;
                    RetroYear = DateTime.Parse(policies.EffectiveDate).Year - DateTime.Parse(policies.RetroactiveDate).Year;


                        policies.SaveCyber();
                        UpdateInceptionPartialPayments(policies.TaskControlID, (policies.TotalPremium + policies.Charge));
                        //UpdateInceptionPartialPayments(policies.TaskControlID, (policies.TotalPremium));
                    
                }


                ExportResult(FinishedPolicies);

               }

               
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }
        }

        protected System.Data.DataTable PreviewRenewPolicy(System.Data.DataTable dt)
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = 0;
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["TaskControlTypeID"].ToString() == "12" //Polices
                     || dt.Rows[i]["TaskControlTypeID"].ToString() == "23" //Allied
                     || dt.Rows[i]["TaskControlTypeID"].ToString() == "27" //First Dollar
                        )
                    {
                        TaskControl.Policies taskControl = (TaskControl.Policies)TaskControl.Policies.GetTaskControlByTaskControlID(int.Parse(dt.Rows[i]["taskcontrolID"].ToString()), userID);


                        dt.Rows[i]["EffectiveDate"] = DateTime.Parse(taskControl.EffectiveDate).AddMonths(12).ToShortDateString();

                        dt.Rows[i]["ExpirationDate"] = DateTime.Parse(taskControl.ExpirationDate).AddMonths(12).ToShortDateString();




                        int msufijo;
                        int sufijo = int.Parse(taskControl.Suffix);
                        msufijo = sufijo + 1;
                        if (msufijo < 10)
                            dt.Rows[i]["Sufijo"] = "0".ToString() + msufijo.ToString();
                        else
                            dt.Rows[i]["Sufijo"] = msufijo.ToString();

                        int mAniv;
                        int aniv = int.Parse(taskControl.Anniversary);
                        mAniv = aniv + 1;

                        if (mAniv < 10)
                            dt.Rows[i]["Anniversary"] = "0".ToString() + mAniv.ToString();
                        else
                            dt.Rows[i]["Anniversary"] = mAniv.ToString();


                        System.Data.DataTable dtLimit = new System.Data.DataTable();
                        string limit = "";
                        if (taskControl.PolicyType.Contains("E") || taskControl.PolicyType.Contains("PAH"))
                            dtLimit = LookupTables.LookupTables.GetTable("PRMedicalLimit");
                        else if (taskControl.PolicyType.Contains("F"))
                            dtLimit = GetPRFirstDollarLimit();
                        else
                            dtLimit = LookupTables.LookupTables.GetTable("PRPrimaryLimit");

                        for (int j = 0; j < dtLimit.Rows.Count; j++)
                        {
                            if (dtLimit.Rows[j]["PRMedicalLimitID"].ToString().Trim() == taskControl.PRMedicalLimit.ToString().Trim())
                            {
                                limit = dtLimit.Rows[j]["PRMedicalLimitDesc"].ToString().Trim();
                                break;
                            }
                        }

                        System.Data.DataTable dtRate = new System.Data.DataTable();
                        string rate = "";
                        if (taskControl.PolicyType.Contains("E"))
                            dtRate = EPolicy.TaskControl.Application.GetPRMEDICRATEBYISOCODE(0, taskControl.IsoCode.Trim());
                        else if(taskControl.PolicyType.Contains("PAH"))
                            dtRate = EPolicy.TaskControl.Application.GetPRMEDICRATEPRIMARYAHCBYISOCODE(0, taskControl.IsoCode.Trim());
                        else if (taskControl.PolicyType.Contains("F"))
                            dtRate = GetPRMEDICRATEFIRSTDOLLARBYISOCODE("0", taskControl.IsoCode.Trim());
                        else
                            dtRate = EPolicy.TaskControl.Application.GetPRMEDICRATEPRIMARYBYISOCODE(0, taskControl.IsoCode.Trim());

                        for (int j = 0; j < dtRate.Rows.Count; j++)
                        {
                            if (dtRate.Rows[j]["PRMedicalLimitDesc"].ToString().Trim() == limit)
                            {
                                rate = dtRate.Rows[j]["PRMEDICRATEID"].ToString().Trim();
                                break;
                            }
                        }

                        int RetroYear = 0;
                        RetroYear = DateTime.Parse(dt.Rows[i]["EffectiveDate"].ToString()).Year - DateTime.Parse(dt.Rows[i]["RetroactiveDate"].ToString()).Year;

                        string[] array = rate.Split('|');

                        switch (RetroYear)
                        {
                            case 0:
                                dt.Rows[i]["Premium"] = double.Parse(array[3]);//taskControl.RateYear1;
                                break;
                            case 1:
                                dt.Rows[i]["Premium"] = double.Parse(array[4]);//taskControl.RateYear2;
                                break;
                            case 2:
                                dt.Rows[i]["Premium"] = double.Parse(array[5]);//taskControl.RateYear3;
                                break;
                            default:
                                dt.Rows[i]["Premium"] = double.Parse(array[6]);//taskControl.MCMRate;
                                break;
                        }

                        dt.Rows[i]["Charge"] = CalculateCharge(double.Parse(dt.Rows[i]["Premium"].ToString()), taskControl.CyberEndorsementPremium, taskControl.CancellationAmount, dt.Rows[i]["EffectiveDate"].ToString(), dt.Rows[i]["Anniversary"].ToString());
                        dt.Rows[i]["RateYear1"] = double.Parse(array[3]);
                        dt.Rows[i]["RateYear2"] = double.Parse(array[4]);
                        dt.Rows[i]["RateYear3"] = double.Parse(array[5]);
                        dt.Rows[i]["MCMRate"] = double.Parse(array[6]);


                    }
                    else
                        if (dt.Rows[i]["TaskControlTypeID"].ToString() == "18"//Corporate
                        || dt.Rows[i]["TaskControlTypeID"].ToString() == "24" //Allied Corp
                        || dt.Rows[i]["TaskControlTypeID"].ToString() == "27" //FirstDollar Corp
                           )
                        {
                         TaskControl.CorporatePolicyQuote taskControl = (TaskControl.CorporatePolicyQuote)TaskControl.CorporatePolicyQuote.GetTaskControlByTaskControlID(int.Parse(dt.Rows[i]["taskcontrolID"].ToString()), userID);
                           
                        dt.Rows[i]["EffectiveDate"] = DateTime.Parse(taskControl.EffectiveDate).AddMonths(12).ToShortDateString();

                        dt.Rows[i]["ExpirationDate"] = DateTime.Parse(taskControl.ExpirationDate).AddMonths(12).ToShortDateString();




                        int msufijo;
                        int sufijo = int.Parse(taskControl.Suffix);
                        msufijo = sufijo + 1;
                        if (msufijo < 10)
                            dt.Rows[i]["Sufijo"] = "0".ToString() + msufijo.ToString();
                        else
                            dt.Rows[i]["Sufijo"] = msufijo.ToString();

                        int mAniv;
                        int aniv = int.Parse(taskControl.Anniversary);
                        mAniv = aniv + 1;

                        if (mAniv < 10)
                            dt.Rows[i]["Anniversary"] = "0".ToString() + mAniv.ToString();
                        else
                            dt.Rows[i]["Anniversary"] = mAniv.ToString();



                        dt.Rows[i]["Charge"] = CalculateCharge(double.Parse(dt.Rows[i]["Premium"].ToString()), taskControl.CyberEndorsementPremium, taskControl.CancellationAmount, dt.Rows[i]["EffectiveDate"].ToString(), dt.Rows[i]["Anniversary"].ToString());

                        }
                        else if (dt.Rows[i]["TaskControlTypeID"].ToString() == "20") //Laboratory
                        {
                            TaskControl.Laboratory taskControl = (TaskControl.Laboratory)TaskControl.Laboratory.GetTaskControlByTaskControlID(int.Parse(dt.Rows[i]["taskcontrolID"].ToString()), userID);
                            dt.Rows[i]["EffectiveDate"] = DateTime.Parse(taskControl.EffectiveDate).AddMonths(12).ToShortDateString();

                            dt.Rows[i]["ExpirationDate"] = DateTime.Parse(taskControl.ExpirationDate).AddMonths(12).ToShortDateString();




                            int msufijo;
                            int sufijo = int.Parse(taskControl.Suffix);
                            msufijo = sufijo + 1;
                            if (msufijo < 10)
                                dt.Rows[i]["Sufijo"] = "0".ToString() + msufijo.ToString();
                            else
                                dt.Rows[i]["Sufijo"] = msufijo.ToString();

                            int mAniv;
                            int aniv = int.Parse(taskControl.Anniversary);
                            mAniv = aniv + 1;

                            if (mAniv < 10)
                                dt.Rows[i]["Anniversary"] = "0".ToString() + mAniv.ToString();
                            else
                                dt.Rows[i]["Anniversary"] = mAniv.ToString();



                            dt.Rows[i]["Charge"] = CalculateCharge(double.Parse(dt.Rows[i]["Premium"].ToString()), taskControl.CyberEndorsementPremium, taskControl.CancellationAmount, dt.Rows[i]["EffectiveDate"].ToString(), dt.Rows[i]["Anniversary"].ToString());


                        }
                        else if (dt.Rows[i]["TaskControlTypeID"].ToString() == "22") //Cyber
                        {
                            TaskControl.Cyber taskControl = (TaskControl.Cyber)TaskControl.Cyber.GetTaskControlByTaskControlID(int.Parse(dt.Rows[i]["taskcontrolID"].ToString()), userID);


                            dt.Rows[i]["EffectiveDate"] = DateTime.Parse(taskControl.EffectiveDate).AddMonths(12).ToShortDateString();

                            dt.Rows[i]["ExpirationDate"] = DateTime.Parse(taskControl.ExpirationDate).AddMonths(12).ToShortDateString();




                            int msufijo;
                            int sufijo = int.Parse(taskControl.Suffix);
                            msufijo = sufijo + 1;
                            if (msufijo < 10)
                                dt.Rows[i]["Sufijo"] = "0".ToString() + msufijo.ToString();
                            else
                                dt.Rows[i]["Sufijo"] = msufijo.ToString();

                            int mAniv;
                            int aniv = int.Parse(taskControl.Anniversary);
                            mAniv = aniv + 1;

                            if (mAniv < 10)
                                dt.Rows[i]["Anniversary"] = "0".ToString() + mAniv.ToString();
                            else
                                dt.Rows[i]["Anniversary"] = mAniv.ToString();

                            dt.Rows[i]["Charge"] = CalculateCharge(double.Parse(dt.Rows[i]["Premium"].ToString()), taskControl.CyberEndorsementPremium, taskControl.CancellationAmount, dt.Rows[i]["EffectiveDate"].ToString(), dt.Rows[i]["Anniversary"].ToString());
                        }
                }

                
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }

            return dt;
        }


        private double CalculateCharge(double premium, double cyberEndorsment, double cancellationAmount, string effectiveDate, string anniversary)
        {
            System.Data.DataTable dtCharge = LookupTables.LookupTables.GetTable("Charge");
            int result = 0;

            if (anniversary == "01")
            {
                for (int i = 0; i < dtCharge.Rows.Count; i++)
                {
                    result = DateTime.Compare(DateTime.Parse(effectiveDate.Trim()),
                             DateTime.Parse(dtCharge.Rows[i]["effectiveDate"].ToString()));

                    if (result == 0 || result == 1)
                    {
                        double  totalpremium = 0.00;

                        totalpremium = premium + cyberEndorsment;


                        double chargePercent = double.Parse(dtCharge.Rows[i]["chargePercent"].ToString());
                        var decPlaces = (((totalpremium) * chargePercent) % 1) * 100;
                        int rounded = 0;

                        double dec = double.Parse((totalpremium * chargePercent).ToString());
                        if (dec < 1.00)
                            rounded = 0;
                        else
                            rounded = (int)Math.Round(dec, 0);

                        return rounded;
                    }
                    else
                        return 0.00;
                }
            }
            else
            {
                for (int i = 0; i < dtCharge.Rows.Count; i++)
                {
                    result = DateTime.Compare(DateTime.Parse(effectiveDate),
                             DateTime.Parse(dtCharge.Rows[i]["effectiveDate"].ToString()));

                    if ((result == 0 || result == 1) && bool.Parse(dtCharge.Rows[i]["renewalsOnly"].ToString()))
                    {
                        double totalpremium = 0.00;



                        totalpremium = premium + cyberEndorsment;


                        double chargePercent = double.Parse(dtCharge.Rows[i]["chargePercent"].ToString());
                        var decPlaces = (((totalpremium) * chargePercent) % 1) * 100;
                        int rounded = 0;

                        double dec = double.Parse((totalpremium * chargePercent).ToString());
                        if (dec < 1.00)
                            rounded = 0;
                        else
                            rounded = (int)Math.Round(dec, 0);


                        return rounded;
                        
                    }
                    else
                    {
                        return 0.00;
                    }
                }
            }
            return result;
        }

        private TaskControl.Laboratory CalculateLaboratory(TaskControl.Laboratory taskControl)
        {
                int result = 0;

                double[] Factor = { 0, 1.83, 2.19, 2.48, 3.06 };

                int valueLimit = 0;

                
                {
                    valueLimit = taskControl.LimitsID;
                }

                if (valueLimit > 0)
                {
                    double EstGross = 0;
                    double _premiumTemp = 0;
                    double TotalPremium1 = 0, TotalPremium2 = 0, TotalPremium3 = 0, TotalPremium4 = 0;

                    if (taskControl.EstimatedGrossReceipts != null)
                    {
                        TotalPremium1 = ((EstGross / 1000) * Math.Round((Factor[1] * 2.3), 2));
                        TotalPremium2 = ((EstGross / 1000) * Math.Round((Factor[2] * 2.3), 2));
                        TotalPremium3 = ((EstGross / 1000) * Math.Round((Factor[3] * 2.3), 2));
                        TotalPremium4 = ((EstGross / 1000) * Math.Round((Factor[4] * 2.3), 2));
                    }

                    if (taskControl.EstimatedGrossReceipts != null)
                    {
                        _premiumTemp = ((EstGross / 1000.0) * Math.Round((Factor[valueLimit] * 2.3), 2));

                        double _p = 1;

                        //switch (TxtAnniversary.Text.Trim())
                        //{

                        //    case "01":
                        //        _p = 0.60; // = 60%
                        //        _premiumTemp = _premiumTemp * _p;
                        //        break;
                        //    case "02":
                        //        _p = 0.80; // = 80%
                        //        _premiumTemp = _premiumTemp * _p;
                        //        break;
                        //    case "03":
                        //        _p = 0.90; // = 90%
                        //        _premiumTemp = _premiumTemp * _p;
                        //        break;
                        //    default:
                        //        _p = 1;
                        //        _premiumTemp = _premiumTemp * _p;
                        //        break;
                        //}

                        if (taskControl.RetroactiveDate != "") 
                        {
                            DateTime zeroTime = new DateTime(1 / 1 / 1);

                            TimeSpan span = DateTime.Parse(taskControl.EffectiveDate) - DateTime.Parse(taskControl.RetroactiveDate);

                            int years = (zeroTime + span).Year - 1;

                            if (years == 0)
                            {
                                _p = 0.60; // = 60%
                                _premiumTemp = _premiumTemp * _p;
                            }
                            else if (years == 1)
                            {
                                _p = 0.80; // = 80%
                                _premiumTemp = _premiumTemp * _p;
                            }
                            else if (years == 2)
                            {
                                _p = 0.90; // = 90%
                                _premiumTemp = _premiumTemp * _p;
                            }
                            else if (years >= 3)
                            {
                                _p = 1; // = 100%
                                _premiumTemp = _premiumTemp * _p;
                            }
                        }

                        _premiumTemp = Math.Round(_premiumTemp, 0);
                        taskControl.TotalPremium = _premiumTemp;
                        taskControl.Factor = Factor[valueLimit];
                        taskControl.TotalPremium1 = Math.Round(Math.Round(TotalPremium1, 1), 0);
                        taskControl.TotalPremium2 = Math.Round(Math.Round(TotalPremium2, 1), 0);
                        taskControl.TotalPremium3 = Math.Round(Math.Round(TotalPremium3, 1), 0);
                        taskControl.TotalPremium4 = Math.Round(Math.Round(TotalPremium4, 1), 0);

                        taskControl.Charge = CalculateCharge(taskControl.Premium, taskControl.CyberEndorsementPremium, taskControl.CancellationAmount, taskControl.EffectiveDate, taskControl.Anniversary);

                        return taskControl;
                        
                    }
                    else
                        throw new Exception("The Estimated Gross Receipts is missong or wrong.");
                }
                else
                {
                    throw new Exception("The limit is missing or wrong.");
                }

        
        
        }

        
        private void FillGridToRenew(System.Data.DataTable dt)
		{
            ToRenew.DataSource = null;
            ToRenew.CurrentPageIndex = 0;


            if (dt.Rows.Count != 0)
            {
                ToRenew.DataSource = dt;
                ToRenew.DataBind();
            }
            else
            {
                ToRenew.DataSource = null;
                ToRenew.DataBind();
            }
		}


        private void FillGridPreviewRenew(System.Data.DataTable dt)
        {
            PreviewRenew.DataSource = null;
            PreviewRenew.CurrentPageIndex = 0;


            if (dt.Rows.Count != 0)
            {
                PreviewRenew.DataSource = dt;
                PreviewRenew.DataBind();
            }
            else
            {
                PreviewRenew.DataSource = null;
                PreviewRenew.DataBind();
            }
        }


        private System.Data.DataTable AddToDataTable
            (System.Data.DataTable dt,string TaskcontrolID, string PolicyNumber, string Anniversary,
            string EffectiveDate,string ExpirationDate,string Customer,string MedicalLimit,
            string IsoCode,string Premium,string Charge)
        {

            System.Data.DataRow row = dt.NewRow();
            row["TaskcontrolID"] = TaskcontrolID;
            row["PolicyNumber"] = PolicyNumber;
             row["Anniversary"] = Anniversary;
             row["EffectiveDate"] = EffectiveDate;
             row["ExpirationDate"] = ExpirationDate;
             row["Customer"] = Customer;
             row["MedicalLimit"] = MedicalLimit;
             row["IsoCode"] = IsoCode;
             
             row["Premium"] = Premium;
             row["Charge"] = Charge;

             dt.Rows.Add(row);


             return dt;

        }


        private void PreviewRenew_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.Item.ItemType.ToString() != "Pager") // Select
            {

            }
            else  // Pager
            {
                PreviewRenew.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                PreviewRenew.DataSource = (System.Data.DataTable)Session["dtErrorCases"];
                PreviewRenew.DataBind();
            }
        }
        private void ToRenew_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.Item.ItemType.ToString() != "Pager") // Select
            {

            }
            else  // Pager
            {
                ToRenew.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                ToRenew.DataSource = (System.Data.DataTable)Session["dtErrorCases"];
                ToRenew.DataBind();
            }
        }

		protected void BtnExit_Click(object sender, System.EventArgs e)
		{
			Session.Clear();
			Response.Redirect("MainMenu.aspx");
		}

        protected void BtnGetPoliciesToRenew_Click(object sender, System.EventArgs e)
		{
            try 
	        {
                if (txtFrom.Text.Trim() == "")
                {
                    throw new Exception("From Date is missing");
                }
                if (txtTo.Text.Trim() == "")
                {
                    throw new Exception("To Date is missing");
                }

                FillGridToRenew(GetPoliciesToRenew(txtFrom.Text.Trim(), txtTo.Text.Trim()));

                FillGridPreviewRenew(PreviewRenewPolicy(GetPoliciesToRenew(txtFrom.Text.Trim(), txtTo.Text.Trim())));

                Label4.Visible = true;
                Label6.Visible = true;

                BtnExportToRenew.Visible = true;
                BtnExportPreview.Visible = true;
                BtnRenewPolicies.Visible = true;

	        }
	        catch (Exception ex)
	        {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(ex.Message);
                this.litPopUp.Visible = true;
	        }
           
		}
        protected void BtnRenewPolicies_Click(object sender, System.EventArgs e)
		{
            try
            {
                RenewPolicy(GetPoliciesToRenew(txtFrom.Text.Trim(), txtTo.Text.Trim()));



                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("The policies where rewnewd");
                this.litPopUp.Visible = true;
            }
            catch (Exception ex)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(ex.Message);
                this.litPopUp.Visible = true;
            }
        }

        

        protected void BtnExportToRenew_Click(object sender, System.EventArgs e)
        {
            try
            {
                string Path = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"].ToString()
                                        + "PoliciesToRenew" + DateTime.Now.ToShortDateString().Replace("/", "-") + "-"
                                        + DateTime.Now.Hour.ToString()
                                        + DateTime.Now.Minute.ToString()
                                        + DateTime.Now.Second.ToString()
                                        + ".xlsx";

                System.Data.DataTable dt = new System.Data.DataTable();
                dt = null;
                dt = GetPoliciesToRenew(txtFrom.Text.Trim(), txtTo.Text.Trim()); //(System.Data.DataTable)ToRenew.DataSource;
                System.Data.DataSet ds = new DataSet();




                int desiredSize = dt.Columns["CyberEndorsementPremium"].Ordinal + 1;//CyberEndorsementPremium ultima columna visible

                dt.Constraints.Clear();
                while (dt.Columns.Count > desiredSize)
                {
                    dt.Columns.RemoveAt(desiredSize);
                }

                while (ds.Tables.Count > 0)
                {
                    System.Data.DataTable table = ds.Tables[0];
                    if (ds.Tables.CanRemove(table))
                    {
                        ds.Tables.Remove(table);
                    }
                }

                ds.Tables.Add(dt.Copy());
                ExportDataSet(ds, Path);
                DownLoadFile(Path);
            }


            catch (Exception exc)
            {
                LogError(exc);
                throw;
            }

        }

        protected void BtnExportPreview_Click(object sender, System.EventArgs e)
        {
            try
            {
                string Path = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"].ToString()
                                        + "PoliciesRenewPreview" + DateTime.Now.ToShortDateString().Replace("/", "-") + "-"
                                        + DateTime.Now.Hour.ToString()
                                        + DateTime.Now.Minute.ToString()
                                        + DateTime.Now.Second.ToString()
                                        + ".xlsx";

                System.Data.DataTable dt = new System.Data.DataTable();
                dt = null;
                dt = PreviewRenewPolicy(GetPoliciesToRenew(txtFrom.Text.Trim(), txtTo.Text.Trim())); //(System.Data.DataTable)PreviewRenew.DataSource
                System.Data.DataSet ds = new DataSet();



                int desiredSize = dt.Columns["CyberEndorsementPremium"].Ordinal + 1; //CyberEndorsementPremium ultima columna visible

                dt.Constraints.Clear();
                while (dt.Columns.Count > desiredSize)
                {
                    dt.Columns.RemoveAt(desiredSize);
                }


                while (ds.Tables.Count > 0)
                {
                    System.Data.DataTable table = ds.Tables[0];
                    if (ds.Tables.CanRemove(table))
                    {
                        ds.Tables.Remove(table);
                    }
                }

                ds.Tables.Add(dt.Copy());
                ExportDataSet(ds, Path);
                DownLoadFile(Path);
            }

            catch (Exception exc)
            {
                LogError(exc);
                throw;
            }

        }

        protected void ExportResult(System.Data.DataTable dt)
        {
            try
            {
                string Path = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"].ToString()
                                        + "PoliciesRenewResult" + DateTime.Now.ToShortDateString().Replace("/", "-") + "-"
                                        + DateTime.Now.Hour.ToString()
                                        + DateTime.Now.Minute.ToString()
                                        + DateTime.Now.Second.ToString()
                                        + ".xlsx";

                System.Data.DataSet ds = new DataSet();

                ds.Tables.Add(dt.Copy());
                ExportDataSet(ds, Path);
                //DownLoadFile(Path);
            }

            catch (Exception exc)
            {
                LogError(exc);
                throw;
            }

        }


        
        protected void BtnExportResult_Click(object sender, System.EventArgs e)
        {
            string CsvPath = System.Configuration.ConfigurationManager.AppSettings["ExcelFilesPathName"].ToString()
                                     + "SocSecErrorCases" + DateTime.Now.ToShortDateString().Replace("/", "-") + "-"
                                     + DateTime.Now.Hour.ToString()
                                     + DateTime.Now.Minute.ToString()
                                     + DateTime.Now.Second.ToString()
                                     + ".csv";

            //CreateCSV(GetSocSecUpdateErrorCases(), CsvPath);
            DownLoadFile(CsvPath);
        }        

        protected string ClearString(string value)
        {
            byte[] tempBytes;
            tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(value.ToString().Trim().Replace(",", "").Replace("\n", "").Replace("\r", "")); // Remueve acentos 
            value = System.Text.Encoding.UTF8.GetString(tempBytes);
            value = value.Replace(" ", "").Replace("-", "").Replace(".", "").Replace("(", "").Replace(")", "").Replace("@", "").Replace("*", "").ToUpper().Trim();
            return value;
        }

        protected string ClearString2(string value)
        {
            byte[] tempBytes;
            tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(value.ToString().Trim().Replace(",", "").Replace("\n", "").Replace("\r", "")); // Remueve acentos 
            value = System.Text.Encoding.UTF8.GetString(tempBytes);
            value = value.Replace("-", "").Replace(".", "").Replace("(", "").Replace(")", "").Replace("@", "").Replace("*", "").Replace("&", " and ").Replace("/", " ").Replace(@"\", " ").ToUpper().Trim();
            return value;
        }

        #region OpenXml
        //private System.Data.DataTable ImportToDataTable(string destination, string sheetname)
        //{
        //    System.Data.DataTable dt = new System.Data.DataTable();

        //    using (DocumentFormat.OpenXml.Packaging.SpreadsheetDocument spreadSheetDocument = DocumentFormat.OpenXml.Packaging.SpreadsheetDocument.Open(destination, false))
        //    {

        //        WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
        //        System.Collections.Generic.IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>().Elements<Sheet>();
        //        string relationshipId = workbookPart.Workbook.Descendants<Sheet>().First(s => sheetname.Equals(s.Name)).Id; //sheets.First().Id.Value;
        //        WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
        //        DocumentFormat.OpenXml.Spreadsheet.Worksheet workSheet = worksheetPart.Worksheet;
        //        SheetData sheetData = workSheet.GetFirstChild<SheetData>();
        //        System.Collections.Generic.IEnumerable<Row> rows = sheetData.Descendants<Row>();

        //        int test = rows.Count();

        //        int starting_point = 0;
        //        string Ending_Col = "";

        //        //if (sheetname == "CLAIMS PRMD 05-20")
        //        //{
        //        //    starting_point = 1;
        //        //    Ending_Col = "RESVDATE";
        //        //}
        //        //else if (sheetname == "Reserve Adjustment PRMD")
        //        //{
        //        //    starting_point = 3;
        //        //    Ending_Col = "";//txtReserveDate.Text.Trim();
        //        //}



        //        foreach (Cell cell in rows.ElementAt(starting_point))//0
        //        {
        //            string ColumName = ""; //aqui

        //            if (GetCellValue(spreadSheetDocument, cell) != "")
        //            {

        //                ColumName = GetCellValue(spreadSheetDocument, cell);//ConvertExcelDate(ClearString(GetCellValue(spreadSheetDocument, cell).ToString()));
        //            }
        //            else
        //            {
        //                if (ColumName == "")
        //                {
        //                    ColumName = "BLANKSPACE" + cell.GetEnumerator().ToString(); 
        //                }
                       
        //            }
        //            dt.Columns.Add(ColumName);

        //            if (ColumName == Ending_Col)
        //            {
        //                break;
        //            }
        //        }

        //        DataColumnCollection columns = dt.Columns;

        //        foreach (Row row in rows) //this will also include your header row...
        //        {
        //            DataRow tempRow = dt.NewRow();

        //            for (int i = 0; i < dt.Columns.Count; i++) // row.Descendants<Cell>().Count()= Columnas completas  
        //            {
        //                tempRow[i] = GetCellValue(spreadSheetDocument, row.Descendants<Cell>().ElementAt(i));//ValueConverter(GetCellValue(spreadSheetDocument, row.Descendants<Cell>().ElementAt(i)), columns[i].ColumnName); //i-1 
        //            }
        //            //if (sheetname == "Reserve Adjustment PRMD" && tempRow[0].ToString() == "TOTAL")
        //            //{
        //            //    break;
        //            //}
        //            dt.Rows.Add(tempRow);
        //        }

        //    }
        //    dt.Rows.RemoveAt(0);//removes header
        //    //if (sheetname == "CLAIMS PRMD 05-20")
        //    //{
        //    //    dt.Rows.RemoveAt(0);
        //    //}
        //    //else if (sheetname == "Reserve Adjustment PRMD")
        //    //{
        //    //    for (int i = 0; i < 4; i++)
        //    //    {
        //    //        dt.Rows.RemoveAt(0);
        //    //    }
        //    //    dt.Rows.RemoveAt(dt.Rows.Count - 1);

        //    //}


        //    return dt;
        //}

        //public static string GetCellValue(SpreadsheetDocument document, Cell cell)
        //{
        //    SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
        //    if (cell.CellValue != null)
        //    {
        //        string value = cell.CellValue.InnerXml;

        //        if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
        //        {
        //            if (stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText != null)
        //            {
        //                value = stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
        //            }
        //            else
        //            {
        //                value = "";
        //            }

        //            return value;
        //        }
        //        else
        //        {
        //            return value;
        //        }
        //    }
        //    else return "";
        //}
        #endregion OpenXml


        private void CreateCSV(System.Data.DataTable dt, string filename)
        {
            StringBuilder sb = new StringBuilder();

            DataColumnCollection Colums = dt.Columns;
            string[] columnNames = new string[Colums.Count];

            for (int i = 0; i < Colums.Count; i++)
            {
                columnNames[i] = Colums[i].ColumnName;
            }

            sb.AppendLine(string.Join(",", columnNames));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string[] fields = new string[dt.Columns.Count]; 
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    {
                        fields[j] = dt.Rows[i][j].ToString().Trim().Replace(",", "");
                    }

                }
                sb.AppendLine(string.Join(",", fields));
            }
            File.WriteAllText(filename, sb.ToString());
        }

        private void ExportDataSet(DataSet ds, string destination)
        {
            try
            {
                EncryptClass.EncryptClass encrypt = new EncryptClass.EncryptClass();
                string text="";

                using (var workbook = SpreadsheetDocument.Create(destination, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
                //using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(destination, true)) //To open existing file
                {
                    var workbookPart = workbook.AddWorkbookPart(); //Comment line if using existing file

                    workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();

                    workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();

                    foreach (System.Data.DataTable table in ds.Tables)
                    {

                        var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                        var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();
                        sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);

                        DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
                        string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                        uint sheetId = 1;
                        if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
                        {
                            sheetId =
                                sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                        }

                        DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipId, SheetId = sheetId, Name = table.TableName };
                        sheets.Append(sheet);

                        DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

                        List<String> columns = new List<string>();
                        foreach (System.Data.DataColumn column in table.Columns)
                        {
                            columns.Add(column.ColumnName);

                            DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);
                            headerRow.AppendChild(cell);
                        }

                        sheetData.AppendChild(headerRow);

                        foreach (System.Data.DataRow dsrow in table.Rows)
                        {
                            DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                            //foreach (String col in columns)
                            for (int i = 0; i < table.Columns.Count; i++)
                            {
                                DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                                cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;

                                cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[i].ToString().Replace(",", ""));

                                newRow.AppendChild(cell);
                            }

                            sheetData.AppendChild(newRow);
                        }

                    }
                }
            }
            catch (Exception exp)
            {
                LogError(exp);
                throw new Exception(exp.InnerException.Message);
            }
        }

        private void DownLoadFile(string filename)
        {
            string FileNameOf = filename;//Request.MapPath("ExportFiles")+"/"+filename;
            FileInfo myFile = new FileInfo(FileNameOf);

            Response.ClearHeaders();
            Response.Expires = 0;
            Response.Buffer = true;
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + myFile.Name.Replace(".resources", ""));
            Response.AddHeader("Content-Length", myFile.Length.ToString());
            Response.ContentType = "application/octet-stream";

            Response.Flush();

            Response.WriteFile(myFile.FullName);
            Response.Flush();
            Response.End();
        }


        # region Agent Action

        protected void cmdSelect_Click()//(object sender, System.EventArgs e)
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

        protected void cmdSelect_Click(object sender, System.EventArgs e) //overload for aspx
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
            TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

            System.Data.DataTable dtAvail = taskControl.AgentList;
            System.Data.DataTable dt = dtAvail.Clone();
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

        private void SetddlAvailableAgent(System.Data.DataTable dt)
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

        private void SetddlSelectedAgent(System.Data.DataTable dt)
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
        protected void ddlSelectedAgent_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        #endregion

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["PRMDICConnectionString"].ConnectionString;
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
            System.Data.DataTable dt = null;
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


        public static System.Data.DataTable GetPoliciesToRenew(string From ,string To)
        {
            DbRequestXmlCookRequestItem[] cookItems =
           new DbRequestXmlCookRequestItem[2];

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            DbRequestXmlCooker.AttachCookItem("From", SqlDbType.DateTime, 0, From, ref cookItems);
            DbRequestXmlCooker.AttachCookItem("To", SqlDbType.DateTime, 0, To, ref cookItems);

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
                dt = exec.GetQuery("GetPoliciesToRenew", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }
        public static System.Data.DataTable GetPRMEDICRATEFIRSTDOLLARBYISOCODE(string prmedicrateid, string Isocode)
        {
            DbRequestXmlCookRequestItem[] cookItems =
           new DbRequestXmlCookRequestItem[2];

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            DbRequestXmlCooker.AttachCookItem("prmedicrateid", SqlDbType.DateTime, 0, prmedicrateid, ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Isocode2", SqlDbType.DateTime, 0, Isocode, ref cookItems);

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
                dt = exec.GetQuery("GetPRMEDICRATEFIRSTDOLLARBYISOCODE", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }

        public static System.Data.DataTable GetPRFirstDollarLimit()
        {
            DbRequestXmlCookRequestItem[] cookItems =
           new DbRequestXmlCookRequestItem[0];

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
            System.Data.DataTable dt = null;
            try
            {
                dt = exec.GetQuery("GetPRFirstDollarLimit", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }

        public static System.Data.DataTable GetLastPolicyCyberEndorsementByTaskcontrolID(string PolicyNo, string PolicyType)
        {
            DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("PolicyNo",
            SqlDbType.VarChar, 25, PolicyNo,
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyType",
            SqlDbType.VarChar, 25, PolicyType,
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
            System.Data.DataTable dt = null;
            try
            {
                return dt = exec.GetQuery("GetLastPolicyCyberEndorsementByTaskcontrolID", xmlDoc);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }

        }
        public static void AddCyberEndorsmentPartialPayments(TaskControl.Policies taskControl)
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
            SqlDbType.Money, 0, taskControl.CyberEndorsementPremium.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CheckNumber",
            SqlDbType.Char, 10, "Inception Cyber End.",
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
            System.Data.DataTable dt = null;
            try
            {
                dt = exec.GetQuery("AddCyberEndorsmentPartialPayments", xmlDoc);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }

        }

        private void AddEndorsementCyber(string PolicyNo, string PolicyType)
        {
            Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
            try
            {
                Executor.BeginTrans();
                int a = Executor.Insert("AddEndorsements", this.GetInsertEndorsementsCyberXml(PolicyNo, PolicyType));
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error while trying to save Endorsement. " + xcp.Message, xcp);
            }
        }

        private XmlDocument GetInsertEndorsementsCyberXml(string PolicyNo, string PolicyType)
        {

            System.Data.DataTable endorsement = GetLastPolicyCyberEndorsementByTaskcontrolID(PolicyNo, PolicyType);

            int endnum = int.Parse(endorsement.Rows[0]["EndorsementNo"].ToString()) + 1;
            
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[10];

            DbRequestXmlCooker.AttachCookItem("EndorsementID", SqlDbType.Int, 0, "0", ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, endorsement.Rows[0]["TaskControlID"].ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EndorsementNo", SqlDbType.Int, 0, endnum.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntryDate", SqlDbType.DateTime, 0, DateTime.Now.ToShortDateString(), ref cookItems);

            if (endorsement.Rows[0]["EffectiveDate"].ToString() != "")
                DbRequestXmlCooker.AttachCookItem("EffectiveDate", SqlDbType.DateTime, 0, endorsement.Rows[0]["EffectiveDate"].ToString(), ref cookItems);
            else
                DbRequestXmlCooker.AttachCookItem("EffectiveDate", SqlDbType.DateTime, 0, DateTime.Now.ToShortDateString(), ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndorsementPremium", SqlDbType.Float, 0, endorsement.Rows[0]["EndorsementPremium"].ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EndorsementTypeID", SqlDbType.Int, 0, "5", ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EndorsementComment", SqlDbType.VarChar, 500, "", ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EndorsementHistory", SqlDbType.VarChar, 500, "", ref cookItems);

            if (endorsement.Rows[0]["RetroactiveDate"].ToString() != "")
                DbRequestXmlCooker.AttachCookItem("RetroactiveDate", SqlDbType.DateTime, 0, endorsement.Rows[0]["RetroactiveDate"].ToString(), ref cookItems);
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

        private void LogError(Exception exp)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", exp.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", exp.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", exp.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", exp.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = Server.MapPath("~/ErrorLog/ErrorLog.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

	}
}
