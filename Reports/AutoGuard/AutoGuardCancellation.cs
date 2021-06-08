using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.TaskControl;
using EPolicy.Customer;
using EPolicy.LookupTables;

namespace EPolicy2.Reports
{
	public class AutoGuardCancellation : DataDynamics.ActiveReports.ActiveReport3
	{
		private int CountDataIndex;
		private EPolicy.TaskControl.AutoGuardServicesContract _policy ;
		public AutoGuardCancellation(EPolicy.TaskControl.AutoGuardServicesContract taskcontrol)
		{
			_policy =  taskcontrol;		
			InitializeComponent();
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void AutoGuardCancellation_FetchData(object sender, DataDynamics.ActiveReports.ActiveReport3.FetchEventArgs eArgs)
		{

			try
			{
				if (this.CountDataIndex ==0)
				{
					TxtPolicyNumber.Text = _policy.PolicyType.ToString().ToUpper().Trim()+" "+_policy.PolicyNo.ToString().Trim()+" "+_policy.Certificate.ToString().Trim()+" "+ _policy.Suffix.Trim();
								
					EPolicy.LookupTables.InsuranceCompany insurancecompany = new InsuranceCompany();
					insurancecompany = insurancecompany.GetInsuranceCompany(_policy.InsuranceCompany);
					TxtInsCo.Text       = insurancecompany.InsuranceCompanyID.ToString().Trim()+" "+ insurancecompany.InsuranceCompanyDesc.ToString();

//					if(_taskcontrol.InsuranceCompany != "099")
//					{
//						Picture4.Visible     = false;
//						LblAutoGuard.Visible = false;
//						lblMbi.Visible       = true;						
//						LblMechanical.Visible = true;
//					}
//					else
//					{
//						Picture4.Visible = true;
//						LblAutoGuard.Visible = true;
//						lblMbi.Visible   = false;
//						LblMechanical.Visible = false;
//					}


					//Customer and Postal Address
					TxtCustomerName.Text = _policy.Customer.FirstName.Trim() +" "+_policy.Customer.Initial.Trim();
					TxtLastName1.Text    = _policy.Customer.LastName1.Trim();
					TxtLastName2.Text    = _policy.Customer.LastName2.Trim();
				
					TxtCustomerAddr1.Text = _policy.Customer.Address1.ToString().Trim();
					TxtCustomerAddr2.Text = _policy.Customer.Address2.ToString().Trim();
					TxtCustomerCity.Text  = _policy.Customer.City.ToString().Trim();
					TxtSTCity.Text        = _policy.Customer.State.ToString()+", "+ _policy.Customer.ZipCode.ToString().Trim();
				
					TxtCustomerNumber.Text = _policy.CustomerNo.ToString().Trim();
					TxtSocialSecurity.Text = "XXX-XX-"+_policy.Customer.SocialSecurity.ToString().Trim().Substring(7,4);
					TxtPhone.Text          = _policy.Customer.HomePhone.ToString().Trim();
					TxtPremium.Text        = _policy.TotalPremium.ToString().Trim();
					TxtEffectiveDate.Text  = _policy.EffectiveDate.ToString().Trim();
					TxtTerm.Text           = _policy.Term.ToString().Trim();
					TxtExpireDate.Text     = _policy.ExpirationDate.ToString().Trim();

					//Bank
					EPolicy.LookupTables.Bank bank = new EPolicy.LookupTables.Bank();
					bank = bank.GetBank(_policy.Bank);
					
					TxtBank.Text = bank.BankID.ToString().Trim()+" "+ bank.BankDesc.Trim().ToUpper();
					TxtDealer.Text = _policy.CompanyDealer.ToString().Trim();

					TxtAgency.Text  = _policy.Agency.ToString().Trim()+" "+_policy.CommissionAgencyPercent.Substring(0,2)+"%";
					TxtAgent.Text   = _policy.Agent.ToString().Trim()+" "+_policy.CommissionAgentPercent.Substring(0,2)+"%";
					TxtPurchaseDate.Text = _policy.PurchaserDate.ToString().Trim();
					TxtOrigGuaranty.Text = _policy.orig_gara.ToString().Trim();
					TxtEntryDate.Text    = _policy.EntryDate.ToShortDateString();
					TxtStatus.Text       = _policy.Status.ToString().Trim();
//					TxtPaymentRef.Text   = _policy.
					TxtEntry.Text        = _policy.TramsDate.ToString();
					TxtAmount.Text       = _policy.PaidAmount.ToString().Trim();
					TxtVin.Text          = _policy.Vin.ToString().Trim();
					TxtMake.Text         = _policy.Make.ToString().Trim();
					TxtModel.Text        = _policy.Model.ToString().Trim();
					TxtYear.Text         = _policy.Year.ToString().Trim();
					TxtCost.Text         = _policy.VehicleCost.ToString("$#,##0").Trim();
					TxtOdometer.Text     = _policy.Odometer.ToString().Trim();
					TxtMiles.Text        = _policy.Mileage.ToString().Trim();
					TxtClass.Text        = _policy.VehicleClass.ToString().Trim();
					TxtCancEntry.Text    = _policy.CancellationEntryDate.Trim().Trim();
					TxtCancDate.Text     = _policy.CancellationDate.Trim().Trim();
					TxtCancType.Text     = _policy.CancellationMethod.ToString().Trim();
					TxtCancReason.Text   = _policy.CancellationReason.ToString().Trim();
					TxtRebatePrem.Text   = "$"+_policy.CancellationAmount.ToString().Trim();
					TxtUnearn.Text       = _policy.CancellationUnearnedPercent.ToString().Trim();
					TxtMadeBy.Text       = _policy.EnteredBy.ToString().Trim();

					DateTime date    = DateTime.Now;
					TxtDate.Text    = date.ToShortDateString().Trim();
					TxtHour.Text    = date.ToShortTimeString();

					double total = _policy.PaidAmount - _policy.TotalPremium;
					TxtOwed.Text = total.ToString();

				    TxtCancType.Text   = LookupTables.GetDescription("CancellationMethod",_policy.CancellationMethod.ToString());
					TxtCancReason.Text = LookupTables.GetDescription("CancellationReason",_policy.CancellationReason.ToString());

					double RetCus = _policy.CancellationAmount - (_policy.TotalPremium - _policy.PaidAmount);
					double CusRet = _policy.CancellationAmount + (_policy.PaidAmount - _policy.TotalPremium);

					if(_policy.CancellationAmount == _policy.TotalPremium)
						TxtReturnCust.Text = _policy.PaidAmount.ToString();
					else
					if(_policy.PaidAmount == 0)
						TxtReturnCust.Text = _policy.PaidAmount.ToString();
					else
					if(_policy.PaidAmount > _policy.TotalPremium)
						TxtReturnCust.Text = CusRet.ToString() ;
					else
					if(_policy.PaidAmount <= _policy.TotalPremium)
						TxtReturnCust.Text = RetCus.ToString();
				
				}
				else
				{
					eArgs.EOF = true;
				}

				this.CountDataIndex++;
			}
			catch (Exception)
			{
				if (eArgs != null)
					eArgs.EOF = true;
			}

//			eArgs.EOF = true;
		}

		#region ActiveReports Designer generated code
		private PageHeader PageHeader = null;
		private Shape Shape2 = null;
		private Shape Shape1 = null;
		private Label Label138 = null;
		private TextBox TxtSocialSecurity = null;
		private TextBox TxtCustomerAddr1 = null;
		private TextBox TxtCustomerAddr2 = null;
		private Label Label105 = null;
		private Label Label139 = null;
		private Label Label140 = null;
		private Label Label141 = null;
		private Label Label142 = null;
		private Label Label143 = null;
		private Label Label144 = null;
		private Label Label145 = null;
		private Label Label146 = null;
		private Label Label147 = null;
		private Label Label148 = null;
		private Label Label149 = null;
		private Label Label150 = null;
		private Label Label151 = null;
		private Label Label152 = null;
		private Label Label153 = null;
		private Label Label154 = null;
		private Label Label155 = null;
		private Label Label156 = null;
		private Label Label157 = null;
		private Label Label158 = null;
		private Line Line1 = null;
		private Line Line2 = null;
		private Line Line3 = null;
		private Line Line4 = null;
		private TextBox TxtCustomerCity = null;
		private TextBox TxtSTCity = null;
		private TextBox TxtPhone = null;
		private TextBox TxtCustomerName = null;
		private TextBox TxtCustomerNumber = null;
		private Label Label159 = null;
		private Label Label160 = null;
		private Line Line5 = null;
		private Label Label161 = null;
		private Label Label162 = null;
		private TextBox TxtPolicyNumber = null;
		private TextBox TxtPremium = null;
		private TextBox TxtTerm = null;
		private TextBox TxtEffectiveDate = null;
		private TextBox TxtInsCo = null;
		private TextBox TxtExpireDate = null;
		private TextBox TxtDealer = null;
		private TextBox TxtAgent = null;
		private TextBox TxtAgency = null;
		private TextBox TxtOrigGuaranty = null;
		private TextBox TxtPurchaseDate = null;
		private TextBox TxtEntryDate = null;
		private TextBox TxtStatus = null;
		private TextBox TxtPaymentRef = null;
		private TextBox TxtEntry = null;
		private TextBox TxtAmount = null;
		private Label Label163 = null;
		private Label Label164 = null;
		private Label Label165 = null;
		private Label Label166 = null;
		private Line Line7 = null;
		private Line Line8 = null;
		private Line Line9 = null;
		private Label Label167 = null;
		private Label Label168 = null;
		private Label Label169 = null;
		private Label Label170 = null;
		private TextBox TxtVin = null;
		private TextBox TxtMake = null;
		private TextBox TxtModel = null;
		private TextBox TxtYear = null;
		private Label Label171 = null;
		private Label Label172 = null;
		private Label Label173 = null;
		private Label Label174 = null;
		private TextBox TxtCost = null;
		private TextBox TxtOdometer = null;
		private TextBox TxtMiles = null;
		private TextBox TxtClass = null;
		private Shape Shape4 = null;
		private Shape Shape5 = null;
		private Line Line10 = null;
		private Line Line11 = null;
		private Line Line12 = null;
		private Label Label175 = null;
		private Label Label176 = null;
		private Label Label177 = null;
		private Label Label178 = null;
		private Label Label179 = null;
		private Label Label180 = null;
		private Label Label181 = null;
		private TextBox TxtCancEntry = null;
		private TextBox TxtCancDate = null;
		private TextBox TxtCancType = null;
		private TextBox TxtCancReason = null;
		private TextBox TxtRebatePrem = null;
		private TextBox TxtOwed = null;
		private TextBox TxtReturnCust = null;
		private Label Label182 = null;
		private TextBox TxtUnearn = null;
		private Label Label183 = null;
		private TextBox TxtMadeBy = null;
		private TextBox TxtDate = null;
		private TextBox TxtHour = null;
		private Line Line6 = null;
		private Line Line13 = null;
		private TextBox TxtBank = null;
		private TextBox TxtLastName1 = null;
		private TextBox TxtLastName2 = null;
		private Label Label75 = null;
		private Label Label77 = null;
		private Detail Detail = null;
		private PageFooter PageFooter = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoGuardCancellation));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Shape2 = new DataDynamics.ActiveReports.Shape();
            this.Shape1 = new DataDynamics.ActiveReports.Shape();
            this.Label138 = new DataDynamics.ActiveReports.Label();
            this.TxtSocialSecurity = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerAddr1 = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerAddr2 = new DataDynamics.ActiveReports.TextBox();
            this.Label105 = new DataDynamics.ActiveReports.Label();
            this.Label139 = new DataDynamics.ActiveReports.Label();
            this.Label140 = new DataDynamics.ActiveReports.Label();
            this.Label141 = new DataDynamics.ActiveReports.Label();
            this.Label142 = new DataDynamics.ActiveReports.Label();
            this.Label143 = new DataDynamics.ActiveReports.Label();
            this.Label144 = new DataDynamics.ActiveReports.Label();
            this.Label145 = new DataDynamics.ActiveReports.Label();
            this.Label146 = new DataDynamics.ActiveReports.Label();
            this.Label147 = new DataDynamics.ActiveReports.Label();
            this.Label148 = new DataDynamics.ActiveReports.Label();
            this.Label149 = new DataDynamics.ActiveReports.Label();
            this.Label150 = new DataDynamics.ActiveReports.Label();
            this.Label151 = new DataDynamics.ActiveReports.Label();
            this.Label152 = new DataDynamics.ActiveReports.Label();
            this.Label153 = new DataDynamics.ActiveReports.Label();
            this.Label154 = new DataDynamics.ActiveReports.Label();
            this.Label155 = new DataDynamics.ActiveReports.Label();
            this.Label156 = new DataDynamics.ActiveReports.Label();
            this.Label157 = new DataDynamics.ActiveReports.Label();
            this.Label158 = new DataDynamics.ActiveReports.Label();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.Line3 = new DataDynamics.ActiveReports.Line();
            this.Line4 = new DataDynamics.ActiveReports.Line();
            this.TxtCustomerCity = new DataDynamics.ActiveReports.TextBox();
            this.TxtSTCity = new DataDynamics.ActiveReports.TextBox();
            this.TxtPhone = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerName = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerNumber = new DataDynamics.ActiveReports.TextBox();
            this.Label159 = new DataDynamics.ActiveReports.Label();
            this.Label160 = new DataDynamics.ActiveReports.Label();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.Label161 = new DataDynamics.ActiveReports.Label();
            this.Label162 = new DataDynamics.ActiveReports.Label();
            this.TxtPolicyNumber = new DataDynamics.ActiveReports.TextBox();
            this.TxtPremium = new DataDynamics.ActiveReports.TextBox();
            this.TxtTerm = new DataDynamics.ActiveReports.TextBox();
            this.TxtEffectiveDate = new DataDynamics.ActiveReports.TextBox();
            this.TxtInsCo = new DataDynamics.ActiveReports.TextBox();
            this.TxtExpireDate = new DataDynamics.ActiveReports.TextBox();
            this.TxtDealer = new DataDynamics.ActiveReports.TextBox();
            this.TxtAgent = new DataDynamics.ActiveReports.TextBox();
            this.TxtAgency = new DataDynamics.ActiveReports.TextBox();
            this.TxtOrigGuaranty = new DataDynamics.ActiveReports.TextBox();
            this.TxtPurchaseDate = new DataDynamics.ActiveReports.TextBox();
            this.TxtEntryDate = new DataDynamics.ActiveReports.TextBox();
            this.TxtStatus = new DataDynamics.ActiveReports.TextBox();
            this.TxtPaymentRef = new DataDynamics.ActiveReports.TextBox();
            this.TxtEntry = new DataDynamics.ActiveReports.TextBox();
            this.TxtAmount = new DataDynamics.ActiveReports.TextBox();
            this.Label163 = new DataDynamics.ActiveReports.Label();
            this.Label164 = new DataDynamics.ActiveReports.Label();
            this.Label165 = new DataDynamics.ActiveReports.Label();
            this.Label166 = new DataDynamics.ActiveReports.Label();
            this.Line7 = new DataDynamics.ActiveReports.Line();
            this.Line8 = new DataDynamics.ActiveReports.Line();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.Label167 = new DataDynamics.ActiveReports.Label();
            this.Label168 = new DataDynamics.ActiveReports.Label();
            this.Label169 = new DataDynamics.ActiveReports.Label();
            this.Label170 = new DataDynamics.ActiveReports.Label();
            this.TxtVin = new DataDynamics.ActiveReports.TextBox();
            this.TxtMake = new DataDynamics.ActiveReports.TextBox();
            this.TxtModel = new DataDynamics.ActiveReports.TextBox();
            this.TxtYear = new DataDynamics.ActiveReports.TextBox();
            this.Label171 = new DataDynamics.ActiveReports.Label();
            this.Label172 = new DataDynamics.ActiveReports.Label();
            this.Label173 = new DataDynamics.ActiveReports.Label();
            this.Label174 = new DataDynamics.ActiveReports.Label();
            this.TxtCost = new DataDynamics.ActiveReports.TextBox();
            this.TxtOdometer = new DataDynamics.ActiveReports.TextBox();
            this.TxtMiles = new DataDynamics.ActiveReports.TextBox();
            this.TxtClass = new DataDynamics.ActiveReports.TextBox();
            this.Shape4 = new DataDynamics.ActiveReports.Shape();
            this.Shape5 = new DataDynamics.ActiveReports.Shape();
            this.Line10 = new DataDynamics.ActiveReports.Line();
            this.Line11 = new DataDynamics.ActiveReports.Line();
            this.Line12 = new DataDynamics.ActiveReports.Line();
            this.Label175 = new DataDynamics.ActiveReports.Label();
            this.Label176 = new DataDynamics.ActiveReports.Label();
            this.Label177 = new DataDynamics.ActiveReports.Label();
            this.Label178 = new DataDynamics.ActiveReports.Label();
            this.Label179 = new DataDynamics.ActiveReports.Label();
            this.Label180 = new DataDynamics.ActiveReports.Label();
            this.Label181 = new DataDynamics.ActiveReports.Label();
            this.TxtCancEntry = new DataDynamics.ActiveReports.TextBox();
            this.TxtCancDate = new DataDynamics.ActiveReports.TextBox();
            this.TxtCancType = new DataDynamics.ActiveReports.TextBox();
            this.TxtCancReason = new DataDynamics.ActiveReports.TextBox();
            this.TxtRebatePrem = new DataDynamics.ActiveReports.TextBox();
            this.TxtOwed = new DataDynamics.ActiveReports.TextBox();
            this.TxtReturnCust = new DataDynamics.ActiveReports.TextBox();
            this.Label182 = new DataDynamics.ActiveReports.Label();
            this.TxtUnearn = new DataDynamics.ActiveReports.TextBox();
            this.Label183 = new DataDynamics.ActiveReports.Label();
            this.TxtMadeBy = new DataDynamics.ActiveReports.TextBox();
            this.TxtDate = new DataDynamics.ActiveReports.TextBox();
            this.TxtHour = new DataDynamics.ActiveReports.TextBox();
            this.Line6 = new DataDynamics.ActiveReports.Line();
            this.Line13 = new DataDynamics.ActiveReports.Line();
            this.TxtBank = new DataDynamics.ActiveReports.TextBox();
            this.TxtLastName1 = new DataDynamics.ActiveReports.TextBox();
            this.TxtLastName2 = new DataDynamics.ActiveReports.TextBox();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.Label138)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSocialSecurity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerAddr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerAddr2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label139)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label140)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label141)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label142)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label143)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label144)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label145)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label146)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label147)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label148)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label149)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label150)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label151)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label152)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label153)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label154)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label155)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label156)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label157)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label158)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSTCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label159)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label160)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label161)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label162)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPolicyNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTerm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEffectiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtInsCo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtExpireDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDealer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAgency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOrigGuaranty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPurchaseDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEntryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPaymentRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label163)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label164)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label165)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label166)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label167)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label168)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label169)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label170)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label171)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label172)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label173)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label174)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOdometer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label175)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label176)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label177)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label178)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label179)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label180)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label181)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCancEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCancDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCancType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCancReason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRebatePrem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOwed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtReturnCust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label182)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUnearn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label183)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMadeBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLastName1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLastName2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Height = 0F;
            this.Detail.Name = "Detail";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Shape2,
            this.Shape1,
            this.Label138,
            this.TxtSocialSecurity,
            this.TxtCustomerAddr1,
            this.TxtCustomerAddr2,
            this.Label105,
            this.Label139,
            this.Label140,
            this.Label141,
            this.Label142,
            this.Label143,
            this.Label144,
            this.Label145,
            this.Label146,
            this.Label147,
            this.Label148,
            this.Label149,
            this.Label150,
            this.Label151,
            this.Label152,
            this.Label153,
            this.Label154,
            this.Label155,
            this.Label156,
            this.Label157,
            this.Label158,
            this.Line1,
            this.Line2,
            this.Line3,
            this.Line4,
            this.TxtCustomerCity,
            this.TxtSTCity,
            this.TxtPhone,
            this.TxtCustomerName,
            this.TxtCustomerNumber,
            this.Label159,
            this.Label160,
            this.Line5,
            this.Label161,
            this.Label162,
            this.TxtPolicyNumber,
            this.TxtPremium,
            this.TxtTerm,
            this.TxtEffectiveDate,
            this.TxtInsCo,
            this.TxtExpireDate,
            this.TxtDealer,
            this.TxtAgent,
            this.TxtAgency,
            this.TxtOrigGuaranty,
            this.TxtPurchaseDate,
            this.TxtEntryDate,
            this.TxtStatus,
            this.TxtPaymentRef,
            this.TxtEntry,
            this.TxtAmount,
            this.Label163,
            this.Label164,
            this.Label165,
            this.Label166,
            this.Line7,
            this.Line8,
            this.Line9,
            this.Label167,
            this.Label168,
            this.Label169,
            this.Label170,
            this.TxtVin,
            this.TxtMake,
            this.TxtModel,
            this.TxtYear,
            this.Label171,
            this.Label172,
            this.Label173,
            this.Label174,
            this.TxtCost,
            this.TxtOdometer,
            this.TxtMiles,
            this.TxtClass,
            this.Shape4,
            this.Shape5,
            this.Line10,
            this.Line11,
            this.Line12,
            this.Label175,
            this.Label176,
            this.Label177,
            this.Label178,
            this.Label179,
            this.Label180,
            this.Label181,
            this.TxtCancEntry,
            this.TxtCancDate,
            this.TxtCancType,
            this.TxtCancReason,
            this.TxtRebatePrem,
            this.TxtOwed,
            this.TxtReturnCust,
            this.Label182,
            this.TxtUnearn,
            this.Label183,
            this.TxtMadeBy,
            this.TxtDate,
            this.TxtHour,
            this.Line6,
            this.Line13,
            this.TxtBank,
            this.TxtLastName1,
            this.TxtLastName2,
            this.Label75,
            this.Label77});
            this.PageHeader.Height = 6.978472F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // Shape2
            // 
            this.Shape2.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape2.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape2.Border.RightColor = System.Drawing.Color.Black;
            this.Shape2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape2.Border.TopColor = System.Drawing.Color.Black;
            this.Shape2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape2.Height = 3.375F;
            this.Shape2.Left = 1F;
            this.Shape2.LineWeight = 2F;
            this.Shape2.Name = "Shape2";
            this.Shape2.RoundingRadius = 9.999999F;
            this.Shape2.Top = 1.9375F;
            this.Shape2.Width = 6.541667F;
            // 
            // Shape1
            // 
            this.Shape1.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.RightColor = System.Drawing.Color.Black;
            this.Shape1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.TopColor = System.Drawing.Color.Black;
            this.Shape1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape1.Height = 0.3125F;
            this.Shape1.Left = 1F;
            this.Shape1.LineWeight = 2F;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = 9.999999F;
            this.Shape1.Top = 1.5625F;
            this.Shape1.Width = 6.541667F;
            // 
            // Label138
            // 
            this.Label138.Border.BottomColor = System.Drawing.Color.Black;
            this.Label138.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label138.Border.LeftColor = System.Drawing.Color.Black;
            this.Label138.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label138.Border.RightColor = System.Drawing.Color.Black;
            this.Label138.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label138.Border.TopColor = System.Drawing.Color.Black;
            this.Label138.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label138.Height = 0.1875F;
            this.Label138.HyperLink = "";
            this.Label138.Left = 2.177083F;
            this.Label138.Name = "Label138";
            this.Label138.Style = "text-align: center; font-weight: bold; font-size: 11pt; ";
            this.Label138.Text = "MECHANICAL BREAKDOWN CANCELLATION";
            this.Label138.Top = 1.625F;
            this.Label138.Width = 4.125F;
            // 
            // TxtSocialSecurity
            // 
            this.TxtSocialSecurity.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtSocialSecurity.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSocialSecurity.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtSocialSecurity.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSocialSecurity.Border.RightColor = System.Drawing.Color.Black;
            this.TxtSocialSecurity.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSocialSecurity.Border.TopColor = System.Drawing.Color.Black;
            this.TxtSocialSecurity.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSocialSecurity.Height = 0.2F;
            this.TxtSocialSecurity.Left = 2.25F;
            this.TxtSocialSecurity.MultiLine = false;
            this.TxtSocialSecurity.Name = "TxtSocialSecurity";
            this.TxtSocialSecurity.OutputFormat = resources.GetString("TxtSocialSecurity.OutputFormat");
            this.TxtSocialSecurity.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtSocialSecurity.Text = null;
            this.TxtSocialSecurity.Top = 2.875F;
            this.TxtSocialSecurity.Width = 2.0625F;
            // 
            // TxtCustomerAddr1
            // 
            this.TxtCustomerAddr1.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCustomerAddr1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerAddr1.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCustomerAddr1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerAddr1.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCustomerAddr1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerAddr1.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCustomerAddr1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerAddr1.Height = 0.2F;
            this.TxtCustomerAddr1.Left = 2.246528F;
            this.TxtCustomerAddr1.MultiLine = false;
            this.TxtCustomerAddr1.Name = "TxtCustomerAddr1";
            this.TxtCustomerAddr1.OutputFormat = resources.GetString("TxtCustomerAddr1.OutputFormat");
            this.TxtCustomerAddr1.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtCustomerAddr1.Text = null;
            this.TxtCustomerAddr1.Top = 3.0625F;
            this.TxtCustomerAddr1.Width = 2.0625F;
            // 
            // TxtCustomerAddr2
            // 
            this.TxtCustomerAddr2.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCustomerAddr2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerAddr2.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCustomerAddr2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerAddr2.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCustomerAddr2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerAddr2.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCustomerAddr2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerAddr2.Height = 0.2F;
            this.TxtCustomerAddr2.Left = 2.246528F;
            this.TxtCustomerAddr2.MultiLine = false;
            this.TxtCustomerAddr2.Name = "TxtCustomerAddr2";
            this.TxtCustomerAddr2.OutputFormat = resources.GetString("TxtCustomerAddr2.OutputFormat");
            this.TxtCustomerAddr2.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtCustomerAddr2.Text = null;
            this.TxtCustomerAddr2.Top = 3.25F;
            this.TxtCustomerAddr2.Width = 2.0625F;
            // 
            // Label105
            // 
            this.Label105.Border.BottomColor = System.Drawing.Color.Black;
            this.Label105.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label105.Border.LeftColor = System.Drawing.Color.Black;
            this.Label105.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label105.Border.RightColor = System.Drawing.Color.Black;
            this.Label105.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label105.Border.TopColor = System.Drawing.Color.Black;
            this.Label105.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label105.Height = 0.1875F;
            this.Label105.HyperLink = "";
            this.Label105.Left = 1.121529F;
            this.Label105.Name = "Label105";
            this.Label105.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label105.Text = "Social Security";
            this.Label105.Top = 2.875F;
            this.Label105.Width = 0.8125F;
            // 
            // Label139
            // 
            this.Label139.Border.BottomColor = System.Drawing.Color.Black;
            this.Label139.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label139.Border.LeftColor = System.Drawing.Color.Black;
            this.Label139.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label139.Border.RightColor = System.Drawing.Color.Black;
            this.Label139.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label139.Border.TopColor = System.Drawing.Color.Black;
            this.Label139.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label139.Height = 0.1875F;
            this.Label139.HyperLink = "";
            this.Label139.Left = 1.121529F;
            this.Label139.Name = "Label139";
            this.Label139.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label139.Text = "Address Line 1:";
            this.Label139.Top = 3.0625F;
            this.Label139.Width = 0.875F;
            // 
            // Label140
            // 
            this.Label140.Border.BottomColor = System.Drawing.Color.Black;
            this.Label140.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label140.Border.LeftColor = System.Drawing.Color.Black;
            this.Label140.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label140.Border.RightColor = System.Drawing.Color.Black;
            this.Label140.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label140.Border.TopColor = System.Drawing.Color.Black;
            this.Label140.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label140.Height = 0.1875F;
            this.Label140.HyperLink = "";
            this.Label140.Left = 1.121529F;
            this.Label140.Name = "Label140";
            this.Label140.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label140.Text = "Address Line 2:";
            this.Label140.Top = 3.25F;
            this.Label140.Width = 0.875F;
            // 
            // Label141
            // 
            this.Label141.Border.BottomColor = System.Drawing.Color.Black;
            this.Label141.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label141.Border.LeftColor = System.Drawing.Color.Black;
            this.Label141.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label141.Border.RightColor = System.Drawing.Color.Black;
            this.Label141.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label141.Border.TopColor = System.Drawing.Color.Black;
            this.Label141.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label141.Height = 0.1875F;
            this.Label141.HyperLink = "";
            this.Label141.Left = 1.121529F;
            this.Label141.Name = "Label141";
            this.Label141.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label141.Text = "City:";
            this.Label141.Top = 3.4375F;
            this.Label141.Width = 0.8125F;
            // 
            // Label142
            // 
            this.Label142.Border.BottomColor = System.Drawing.Color.Black;
            this.Label142.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label142.Border.LeftColor = System.Drawing.Color.Black;
            this.Label142.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label142.Border.RightColor = System.Drawing.Color.Black;
            this.Label142.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label142.Border.TopColor = System.Drawing.Color.Black;
            this.Label142.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label142.Height = 0.1875F;
            this.Label142.HyperLink = "";
            this.Label142.Left = 1.121529F;
            this.Label142.Name = "Label142";
            this.Label142.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label142.Text = "State / Zip:";
            this.Label142.Top = 3.625F;
            this.Label142.Width = 0.8125F;
            // 
            // Label143
            // 
            this.Label143.Border.BottomColor = System.Drawing.Color.Black;
            this.Label143.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label143.Border.LeftColor = System.Drawing.Color.Black;
            this.Label143.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label143.Border.RightColor = System.Drawing.Color.Black;
            this.Label143.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label143.Border.TopColor = System.Drawing.Color.Black;
            this.Label143.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label143.Height = 0.1875F;
            this.Label143.HyperLink = "";
            this.Label143.Left = 1.121529F;
            this.Label143.Name = "Label143";
            this.Label143.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label143.Text = "Phone Number:";
            this.Label143.Top = 3.8125F;
            this.Label143.Width = 0.875F;
            // 
            // Label144
            // 
            this.Label144.Border.BottomColor = System.Drawing.Color.Black;
            this.Label144.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label144.Border.LeftColor = System.Drawing.Color.Black;
            this.Label144.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label144.Border.RightColor = System.Drawing.Color.Black;
            this.Label144.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label144.Border.TopColor = System.Drawing.Color.Black;
            this.Label144.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label144.Height = 0.1875F;
            this.Label144.HyperLink = "";
            this.Label144.Left = 1.121529F;
            this.Label144.Name = "Label144";
            this.Label144.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label144.Text = "Customer Number:";
            this.Label144.Top = 2.125F;
            this.Label144.Width = 1F;
            // 
            // Label145
            // 
            this.Label145.Border.BottomColor = System.Drawing.Color.Black;
            this.Label145.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label145.Border.LeftColor = System.Drawing.Color.Black;
            this.Label145.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label145.Border.RightColor = System.Drawing.Color.Black;
            this.Label145.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label145.Border.TopColor = System.Drawing.Color.Black;
            this.Label145.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label145.Height = 0.1875F;
            this.Label145.HyperLink = "";
            this.Label145.Left = 1.121529F;
            this.Label145.Name = "Label145";
            this.Label145.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label145.Text = "Insured Name:";
            this.Label145.Top = 2.3125F;
            this.Label145.Width = 0.8125F;
            // 
            // Label146
            // 
            this.Label146.Border.BottomColor = System.Drawing.Color.Black;
            this.Label146.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label146.Border.LeftColor = System.Drawing.Color.Black;
            this.Label146.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label146.Border.RightColor = System.Drawing.Color.Black;
            this.Label146.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label146.Border.TopColor = System.Drawing.Color.Black;
            this.Label146.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label146.Height = 0.1875F;
            this.Label146.HyperLink = "";
            this.Label146.Left = 4.746528F;
            this.Label146.Name = "Label146";
            this.Label146.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label146.Text = "Policy Number:";
            this.Label146.Top = 2.125F;
            this.Label146.Width = 0.8125F;
            // 
            // Label147
            // 
            this.Label147.Border.BottomColor = System.Drawing.Color.Black;
            this.Label147.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label147.Border.LeftColor = System.Drawing.Color.Black;
            this.Label147.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label147.Border.RightColor = System.Drawing.Color.Black;
            this.Label147.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label147.Border.TopColor = System.Drawing.Color.Black;
            this.Label147.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label147.Height = 0.1875F;
            this.Label147.HyperLink = "";
            this.Label147.Left = 4.746528F;
            this.Label147.Name = "Label147";
            this.Label147.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label147.Text = "Premium";
            this.Label147.Top = 2.3125F;
            this.Label147.Width = 0.875F;
            // 
            // Label148
            // 
            this.Label148.Border.BottomColor = System.Drawing.Color.Black;
            this.Label148.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label148.Border.LeftColor = System.Drawing.Color.Black;
            this.Label148.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label148.Border.RightColor = System.Drawing.Color.Black;
            this.Label148.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label148.Border.TopColor = System.Drawing.Color.Black;
            this.Label148.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label148.Height = 0.1875F;
            this.Label148.HyperLink = "";
            this.Label148.Left = 4.746528F;
            this.Label148.Name = "Label148";
            this.Label148.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label148.Text = "Effective Date:";
            this.Label148.Top = 2.5F;
            this.Label148.Width = 0.875F;
            // 
            // Label149
            // 
            this.Label149.Border.BottomColor = System.Drawing.Color.Black;
            this.Label149.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label149.Border.LeftColor = System.Drawing.Color.Black;
            this.Label149.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label149.Border.RightColor = System.Drawing.Color.Black;
            this.Label149.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label149.Border.TopColor = System.Drawing.Color.Black;
            this.Label149.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label149.Height = 0.1875F;
            this.Label149.HyperLink = "";
            this.Label149.Left = 4.746528F;
            this.Label149.Name = "Label149";
            this.Label149.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label149.Text = "Term:";
            this.Label149.Top = 2.6875F;
            this.Label149.Width = 0.8125F;
            // 
            // Label150
            // 
            this.Label150.Border.BottomColor = System.Drawing.Color.Black;
            this.Label150.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label150.Border.LeftColor = System.Drawing.Color.Black;
            this.Label150.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label150.Border.RightColor = System.Drawing.Color.Black;
            this.Label150.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label150.Border.TopColor = System.Drawing.Color.Black;
            this.Label150.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label150.Height = 0.1875F;
            this.Label150.HyperLink = "";
            this.Label150.Left = 4.746528F;
            this.Label150.Name = "Label150";
            this.Label150.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label150.Text = "Expire Date:";
            this.Label150.Top = 2.875F;
            this.Label150.Width = 0.8125F;
            // 
            // Label151
            // 
            this.Label151.Border.BottomColor = System.Drawing.Color.Black;
            this.Label151.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label151.Border.LeftColor = System.Drawing.Color.Black;
            this.Label151.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label151.Border.RightColor = System.Drawing.Color.Black;
            this.Label151.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label151.Border.TopColor = System.Drawing.Color.Black;
            this.Label151.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label151.Height = 0.1875F;
            this.Label151.HyperLink = "";
            this.Label151.Left = 4.746528F;
            this.Label151.Name = "Label151";
            this.Label151.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label151.Text = "Ins. Company:";
            this.Label151.Top = 3.0625F;
            this.Label151.Width = 0.875F;
            // 
            // Label152
            // 
            this.Label152.Border.BottomColor = System.Drawing.Color.Black;
            this.Label152.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label152.Border.LeftColor = System.Drawing.Color.Black;
            this.Label152.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label152.Border.RightColor = System.Drawing.Color.Black;
            this.Label152.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label152.Border.TopColor = System.Drawing.Color.Black;
            this.Label152.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label152.Height = 0.1875F;
            this.Label152.HyperLink = "";
            this.Label152.Left = 4.746528F;
            this.Label152.Name = "Label152";
            this.Label152.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label152.Text = "Losspayee:";
            this.Label152.Top = 3.25F;
            this.Label152.Width = 0.8125F;
            // 
            // Label153
            // 
            this.Label153.Border.BottomColor = System.Drawing.Color.Black;
            this.Label153.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label153.Border.LeftColor = System.Drawing.Color.Black;
            this.Label153.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label153.Border.RightColor = System.Drawing.Color.Black;
            this.Label153.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label153.Border.TopColor = System.Drawing.Color.Black;
            this.Label153.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label153.Height = 0.1875F;
            this.Label153.HyperLink = "";
            this.Label153.Left = 4.746528F;
            this.Label153.Name = "Label153";
            this.Label153.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label153.Text = "Dealer:";
            this.Label153.Top = 3.4375F;
            this.Label153.Width = 0.875F;
            // 
            // Label154
            // 
            this.Label154.Border.BottomColor = System.Drawing.Color.Black;
            this.Label154.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label154.Border.LeftColor = System.Drawing.Color.Black;
            this.Label154.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label154.Border.RightColor = System.Drawing.Color.Black;
            this.Label154.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label154.Border.TopColor = System.Drawing.Color.Black;
            this.Label154.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label154.Height = 0.1875F;
            this.Label154.HyperLink = "";
            this.Label154.Left = 4.746528F;
            this.Label154.Name = "Label154";
            this.Label154.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label154.Text = "Agency:";
            this.Label154.Top = 3.625F;
            this.Label154.Width = 0.875F;
            // 
            // Label155
            // 
            this.Label155.Border.BottomColor = System.Drawing.Color.Black;
            this.Label155.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label155.Border.LeftColor = System.Drawing.Color.Black;
            this.Label155.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label155.Border.RightColor = System.Drawing.Color.Black;
            this.Label155.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label155.Border.TopColor = System.Drawing.Color.Black;
            this.Label155.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label155.Height = 0.1875F;
            this.Label155.HyperLink = "";
            this.Label155.Left = 4.746528F;
            this.Label155.Name = "Label155";
            this.Label155.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label155.Text = "Agent:";
            this.Label155.Top = 3.8125F;
            this.Label155.Width = 0.8125F;
            // 
            // Label156
            // 
            this.Label156.Border.BottomColor = System.Drawing.Color.Black;
            this.Label156.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label156.Border.LeftColor = System.Drawing.Color.Black;
            this.Label156.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label156.Border.RightColor = System.Drawing.Color.Black;
            this.Label156.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label156.Border.TopColor = System.Drawing.Color.Black;
            this.Label156.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label156.Height = 0.1875F;
            this.Label156.HyperLink = "";
            this.Label156.Left = 4.746528F;
            this.Label156.Name = "Label156";
            this.Label156.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label156.Text = "Purchase Date:";
            this.Label156.Top = 4F;
            this.Label156.Width = 0.8958333F;
            // 
            // Label157
            // 
            this.Label157.Border.BottomColor = System.Drawing.Color.Black;
            this.Label157.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label157.Border.LeftColor = System.Drawing.Color.Black;
            this.Label157.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label157.Border.RightColor = System.Drawing.Color.Black;
            this.Label157.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label157.Border.TopColor = System.Drawing.Color.Black;
            this.Label157.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label157.Height = 0.1875F;
            this.Label157.HyperLink = "";
            this.Label157.Left = 4.746528F;
            this.Label157.Name = "Label157";
            this.Label157.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; vertical-align: top; ";
            this.Label157.Text = "Orig. Guaranty:";
            this.Label157.Top = 4.1875F;
            this.Label157.Width = 0.875F;
            // 
            // Label158
            // 
            this.Label158.Border.BottomColor = System.Drawing.Color.Black;
            this.Label158.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label158.Border.LeftColor = System.Drawing.Color.Black;
            this.Label158.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label158.Border.RightColor = System.Drawing.Color.Black;
            this.Label158.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label158.Border.TopColor = System.Drawing.Color.Black;
            this.Label158.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label158.Height = 0.1875F;
            this.Label158.HyperLink = "";
            this.Label158.Left = 4.746528F;
            this.Label158.Name = "Label158";
            this.Label158.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label158.Text = "Entry Date:";
            this.Label158.Top = 4.375F;
            this.Label158.Width = 0.875F;
            // 
            // Line1
            // 
            this.Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.RightColor = System.Drawing.Color.Black;
            this.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.TopColor = System.Drawing.Color.Black;
            this.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Height = 3.375F;
            this.Line1.Left = 5.75F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 1.9375F;
            this.Line1.Width = 0F;
            this.Line1.X1 = 5.75F;
            this.Line1.X2 = 5.75F;
            this.Line1.Y1 = 1.9375F;
            this.Line1.Y2 = 5.3125F;
            // 
            // Line2
            // 
            this.Line2.Border.BottomColor = System.Drawing.Color.Black;
            this.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.LeftColor = System.Drawing.Color.Black;
            this.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.RightColor = System.Drawing.Color.Black;
            this.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.TopColor = System.Drawing.Color.Black;
            this.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Height = 2.125F;
            this.Line2.Left = 2.142361F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 1.9375F;
            this.Line2.Width = 0F;
            this.Line2.X1 = 2.142361F;
            this.Line2.X2 = 2.142361F;
            this.Line2.Y1 = 1.9375F;
            this.Line2.Y2 = 4.0625F;
            // 
            // Line3
            // 
            this.Line3.Border.BottomColor = System.Drawing.Color.Black;
            this.Line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.LeftColor = System.Drawing.Color.Black;
            this.Line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.RightColor = System.Drawing.Color.Black;
            this.Line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.TopColor = System.Drawing.Color.Black;
            this.Line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Height = 0F;
            this.Line3.Left = 1F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 4.0625F;
            this.Line3.Width = 3.625F;
            this.Line3.X1 = 4.625F;
            this.Line3.X2 = 1F;
            this.Line3.Y1 = 4.0625F;
            this.Line3.Y2 = 4.0625F;
            // 
            // Line4
            // 
            this.Line4.Border.BottomColor = System.Drawing.Color.Black;
            this.Line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.LeftColor = System.Drawing.Color.Black;
            this.Line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.RightColor = System.Drawing.Color.Black;
            this.Line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.TopColor = System.Drawing.Color.Black;
            this.Line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Height = 0F;
            this.Line4.Left = 1F;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 4.5F;
            this.Line4.Width = 3.625F;
            this.Line4.X1 = 4.625F;
            this.Line4.X2 = 1F;
            this.Line4.Y1 = 4.5F;
            this.Line4.Y2 = 4.5F;
            // 
            // TxtCustomerCity
            // 
            this.TxtCustomerCity.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCustomerCity.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerCity.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCustomerCity.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerCity.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCustomerCity.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerCity.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCustomerCity.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerCity.Height = 0.2F;
            this.TxtCustomerCity.Left = 2.246528F;
            this.TxtCustomerCity.MultiLine = false;
            this.TxtCustomerCity.Name = "TxtCustomerCity";
            this.TxtCustomerCity.OutputFormat = resources.GetString("TxtCustomerCity.OutputFormat");
            this.TxtCustomerCity.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtCustomerCity.Text = null;
            this.TxtCustomerCity.Top = 3.4375F;
            this.TxtCustomerCity.Width = 2.0625F;
            // 
            // TxtSTCity
            // 
            this.TxtSTCity.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtSTCity.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSTCity.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtSTCity.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSTCity.Border.RightColor = System.Drawing.Color.Black;
            this.TxtSTCity.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSTCity.Border.TopColor = System.Drawing.Color.Black;
            this.TxtSTCity.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSTCity.Height = 0.2F;
            this.TxtSTCity.Left = 2.246528F;
            this.TxtSTCity.MultiLine = false;
            this.TxtSTCity.Name = "TxtSTCity";
            this.TxtSTCity.OutputFormat = resources.GetString("TxtSTCity.OutputFormat");
            this.TxtSTCity.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtSTCity.Text = null;
            this.TxtSTCity.Top = 3.625F;
            this.TxtSTCity.Width = 2.0625F;
            // 
            // TxtPhone
            // 
            this.TxtPhone.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtPhone.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhone.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtPhone.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhone.Border.RightColor = System.Drawing.Color.Black;
            this.TxtPhone.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhone.Border.TopColor = System.Drawing.Color.Black;
            this.TxtPhone.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhone.Height = 0.2F;
            this.TxtPhone.Left = 2.25F;
            this.TxtPhone.MultiLine = false;
            this.TxtPhone.Name = "TxtPhone";
            this.TxtPhone.OutputFormat = resources.GetString("TxtPhone.OutputFormat");
            this.TxtPhone.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtPhone.Text = null;
            this.TxtPhone.Top = 3.8125F;
            this.TxtPhone.Width = 2.0625F;
            // 
            // TxtCustomerName
            // 
            this.TxtCustomerName.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCustomerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerName.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCustomerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerName.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCustomerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerName.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCustomerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerName.Height = 0.2F;
            this.TxtCustomerName.Left = 2.25F;
            this.TxtCustomerName.MultiLine = false;
            this.TxtCustomerName.Name = "TxtCustomerName";
            this.TxtCustomerName.OutputFormat = resources.GetString("TxtCustomerName.OutputFormat");
            this.TxtCustomerName.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtCustomerName.Text = null;
            this.TxtCustomerName.Top = 2.3125F;
            this.TxtCustomerName.Width = 2.0625F;
            // 
            // TxtCustomerNumber
            // 
            this.TxtCustomerNumber.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCustomerNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerNumber.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCustomerNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerNumber.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCustomerNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerNumber.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCustomerNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerNumber.Height = 0.2F;
            this.TxtCustomerNumber.Left = 2.246528F;
            this.TxtCustomerNumber.MultiLine = false;
            this.TxtCustomerNumber.Name = "TxtCustomerNumber";
            this.TxtCustomerNumber.OutputFormat = resources.GetString("TxtCustomerNumber.OutputFormat");
            this.TxtCustomerNumber.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtCustomerNumber.Text = null;
            this.TxtCustomerNumber.Top = 2.125F;
            this.TxtCustomerNumber.Width = 2.0625F;
            // 
            // Label159
            // 
            this.Label159.Border.BottomColor = System.Drawing.Color.Black;
            this.Label159.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label159.Border.LeftColor = System.Drawing.Color.Black;
            this.Label159.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label159.Border.RightColor = System.Drawing.Color.Black;
            this.Label159.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label159.Border.TopColor = System.Drawing.Color.Black;
            this.Label159.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label159.Height = 0.1875F;
            this.Label159.HyperLink = "";
            this.Label159.Left = 1.079861F;
            this.Label159.Name = "Label159";
            this.Label159.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label159.Text = "Status";
            this.Label159.Top = 4.125F;
            this.Label159.Width = 0.5F;
            // 
            // Label160
            // 
            this.Label160.Border.BottomColor = System.Drawing.Color.Black;
            this.Label160.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label160.Border.LeftColor = System.Drawing.Color.Black;
            this.Label160.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label160.Border.RightColor = System.Drawing.Color.Black;
            this.Label160.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label160.Border.TopColor = System.Drawing.Color.Black;
            this.Label160.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label160.Height = 0.1875F;
            this.Label160.HyperLink = "";
            this.Label160.Left = 1.704861F;
            this.Label160.MultiLine = false;
            this.Label160.Name = "Label160";
            this.Label160.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label160.Text = "Payment: Reference";
            this.Label160.Top = 4.125F;
            this.Label160.Width = 1.125F;
            // 
            // Line5
            // 
            this.Line5.Border.BottomColor = System.Drawing.Color.Black;
            this.Line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.LeftColor = System.Drawing.Color.Black;
            this.Line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.RightColor = System.Drawing.Color.Black;
            this.Line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.TopColor = System.Drawing.Color.Black;
            this.Line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Height = 0.4375F;
            this.Line5.Left = 1.625F;
            this.Line5.LineWeight = 1F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 4.0625F;
            this.Line5.Width = 0F;
            this.Line5.X1 = 1.625F;
            this.Line5.X2 = 1.625F;
            this.Line5.Y1 = 4.0625F;
            this.Line5.Y2 = 4.5F;
            // 
            // Label161
            // 
            this.Label161.Border.BottomColor = System.Drawing.Color.Black;
            this.Label161.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label161.Border.LeftColor = System.Drawing.Color.Black;
            this.Label161.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label161.Border.RightColor = System.Drawing.Color.Black;
            this.Label161.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label161.Border.TopColor = System.Drawing.Color.Black;
            this.Label161.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label161.Height = 0.1875F;
            this.Label161.HyperLink = "";
            this.Label161.Left = 3.017361F;
            this.Label161.Name = "Label161";
            this.Label161.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label161.Text = "Entry";
            this.Label161.Top = 4.125F;
            this.Label161.Width = 0.375F;
            // 
            // Label162
            // 
            this.Label162.Border.BottomColor = System.Drawing.Color.Black;
            this.Label162.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label162.Border.LeftColor = System.Drawing.Color.Black;
            this.Label162.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label162.Border.RightColor = System.Drawing.Color.Black;
            this.Label162.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label162.Border.TopColor = System.Drawing.Color.Black;
            this.Label162.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label162.Height = 0.1875F;
            this.Label162.HyperLink = "";
            this.Label162.Left = 3.954861F;
            this.Label162.Name = "Label162";
            this.Label162.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label162.Text = "Amount";
            this.Label162.Top = 4.125F;
            this.Label162.Width = 0.5625F;
            // 
            // TxtPolicyNumber
            // 
            this.TxtPolicyNumber.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtPolicyNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPolicyNumber.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtPolicyNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPolicyNumber.Border.RightColor = System.Drawing.Color.Black;
            this.TxtPolicyNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPolicyNumber.Border.TopColor = System.Drawing.Color.Black;
            this.TxtPolicyNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPolicyNumber.Height = 0.2F;
            this.TxtPolicyNumber.Left = 5.767361F;
            this.TxtPolicyNumber.MultiLine = false;
            this.TxtPolicyNumber.Name = "TxtPolicyNumber";
            this.TxtPolicyNumber.OutputFormat = resources.GetString("TxtPolicyNumber.OutputFormat");
            this.TxtPolicyNumber.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtPolicyNumber.Text = null;
            this.TxtPolicyNumber.Top = 2.125F;
            this.TxtPolicyNumber.Width = 1.6875F;
            // 
            // TxtPremium
            // 
            this.TxtPremium.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtPremium.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPremium.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtPremium.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPremium.Border.RightColor = System.Drawing.Color.Black;
            this.TxtPremium.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPremium.Border.TopColor = System.Drawing.Color.Black;
            this.TxtPremium.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPremium.Height = 0.2F;
            this.TxtPremium.Left = 5.767361F;
            this.TxtPremium.MultiLine = false;
            this.TxtPremium.Name = "TxtPremium";
            this.TxtPremium.OutputFormat = resources.GetString("TxtPremium.OutputFormat");
            this.TxtPremium.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtPremium.Text = null;
            this.TxtPremium.Top = 2.3125F;
            this.TxtPremium.Width = 1.6875F;
            // 
            // TxtTerm
            // 
            this.TxtTerm.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtTerm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTerm.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtTerm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTerm.Border.RightColor = System.Drawing.Color.Black;
            this.TxtTerm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTerm.Border.TopColor = System.Drawing.Color.Black;
            this.TxtTerm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTerm.Height = 0.2F;
            this.TxtTerm.Left = 5.767361F;
            this.TxtTerm.MultiLine = false;
            this.TxtTerm.Name = "TxtTerm";
            this.TxtTerm.OutputFormat = resources.GetString("TxtTerm.OutputFormat");
            this.TxtTerm.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtTerm.Text = null;
            this.TxtTerm.Top = 2.6875F;
            this.TxtTerm.Width = 1.6875F;
            // 
            // TxtEffectiveDate
            // 
            this.TxtEffectiveDate.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtEffectiveDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEffectiveDate.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtEffectiveDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEffectiveDate.Border.RightColor = System.Drawing.Color.Black;
            this.TxtEffectiveDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEffectiveDate.Border.TopColor = System.Drawing.Color.Black;
            this.TxtEffectiveDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEffectiveDate.Height = 0.2F;
            this.TxtEffectiveDate.Left = 5.767361F;
            this.TxtEffectiveDate.MultiLine = false;
            this.TxtEffectiveDate.Name = "TxtEffectiveDate";
            this.TxtEffectiveDate.OutputFormat = resources.GetString("TxtEffectiveDate.OutputFormat");
            this.TxtEffectiveDate.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtEffectiveDate.Text = null;
            this.TxtEffectiveDate.Top = 2.5F;
            this.TxtEffectiveDate.Width = 1.6875F;
            // 
            // TxtInsCo
            // 
            this.TxtInsCo.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtInsCo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtInsCo.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtInsCo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtInsCo.Border.RightColor = System.Drawing.Color.Black;
            this.TxtInsCo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtInsCo.Border.TopColor = System.Drawing.Color.Black;
            this.TxtInsCo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtInsCo.Height = 0.2F;
            this.TxtInsCo.Left = 5.767361F;
            this.TxtInsCo.MultiLine = false;
            this.TxtInsCo.Name = "TxtInsCo";
            this.TxtInsCo.OutputFormat = resources.GetString("TxtInsCo.OutputFormat");
            this.TxtInsCo.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtInsCo.Text = null;
            this.TxtInsCo.Top = 3.0625F;
            this.TxtInsCo.Width = 1.6875F;
            // 
            // TxtExpireDate
            // 
            this.TxtExpireDate.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtExpireDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtExpireDate.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtExpireDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtExpireDate.Border.RightColor = System.Drawing.Color.Black;
            this.TxtExpireDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtExpireDate.Border.TopColor = System.Drawing.Color.Black;
            this.TxtExpireDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtExpireDate.Height = 0.2F;
            this.TxtExpireDate.Left = 5.767361F;
            this.TxtExpireDate.MultiLine = false;
            this.TxtExpireDate.Name = "TxtExpireDate";
            this.TxtExpireDate.OutputFormat = resources.GetString("TxtExpireDate.OutputFormat");
            this.TxtExpireDate.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtExpireDate.Text = null;
            this.TxtExpireDate.Top = 2.875F;
            this.TxtExpireDate.Width = 1.6875F;
            // 
            // TxtDealer
            // 
            this.TxtDealer.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtDealer.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDealer.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtDealer.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDealer.Border.RightColor = System.Drawing.Color.Black;
            this.TxtDealer.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDealer.Border.TopColor = System.Drawing.Color.Black;
            this.TxtDealer.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDealer.Height = 0.2F;
            this.TxtDealer.Left = 5.767361F;
            this.TxtDealer.MultiLine = false;
            this.TxtDealer.Name = "TxtDealer";
            this.TxtDealer.OutputFormat = resources.GetString("TxtDealer.OutputFormat");
            this.TxtDealer.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtDealer.Text = null;
            this.TxtDealer.Top = 3.4375F;
            this.TxtDealer.Width = 1.6875F;
            // 
            // TxtAgent
            // 
            this.TxtAgent.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtAgent.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAgent.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtAgent.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAgent.Border.RightColor = System.Drawing.Color.Black;
            this.TxtAgent.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAgent.Border.TopColor = System.Drawing.Color.Black;
            this.TxtAgent.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAgent.Height = 0.2F;
            this.TxtAgent.Left = 5.767361F;
            this.TxtAgent.MultiLine = false;
            this.TxtAgent.Name = "TxtAgent";
            this.TxtAgent.OutputFormat = resources.GetString("TxtAgent.OutputFormat");
            this.TxtAgent.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtAgent.Text = null;
            this.TxtAgent.Top = 3.8125F;
            this.TxtAgent.Width = 1.6875F;
            // 
            // TxtAgency
            // 
            this.TxtAgency.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtAgency.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAgency.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtAgency.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAgency.Border.RightColor = System.Drawing.Color.Black;
            this.TxtAgency.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAgency.Border.TopColor = System.Drawing.Color.Black;
            this.TxtAgency.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAgency.Height = 0.2F;
            this.TxtAgency.Left = 5.767361F;
            this.TxtAgency.MultiLine = false;
            this.TxtAgency.Name = "TxtAgency";
            this.TxtAgency.OutputFormat = resources.GetString("TxtAgency.OutputFormat");
            this.TxtAgency.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtAgency.Text = null;
            this.TxtAgency.Top = 3.625F;
            this.TxtAgency.Width = 1.6875F;
            // 
            // TxtOrigGuaranty
            // 
            this.TxtOrigGuaranty.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtOrigGuaranty.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtOrigGuaranty.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtOrigGuaranty.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtOrigGuaranty.Border.RightColor = System.Drawing.Color.Black;
            this.TxtOrigGuaranty.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtOrigGuaranty.Border.TopColor = System.Drawing.Color.Black;
            this.TxtOrigGuaranty.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtOrigGuaranty.Height = 0.2F;
            this.TxtOrigGuaranty.Left = 5.767361F;
            this.TxtOrigGuaranty.MultiLine = false;
            this.TxtOrigGuaranty.Name = "TxtOrigGuaranty";
            this.TxtOrigGuaranty.OutputFormat = resources.GetString("TxtOrigGuaranty.OutputFormat");
            this.TxtOrigGuaranty.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtOrigGuaranty.Text = null;
            this.TxtOrigGuaranty.Top = 4.1875F;
            this.TxtOrigGuaranty.Width = 1.6875F;
            // 
            // TxtPurchaseDate
            // 
            this.TxtPurchaseDate.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtPurchaseDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPurchaseDate.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtPurchaseDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPurchaseDate.Border.RightColor = System.Drawing.Color.Black;
            this.TxtPurchaseDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPurchaseDate.Border.TopColor = System.Drawing.Color.Black;
            this.TxtPurchaseDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPurchaseDate.Height = 0.2F;
            this.TxtPurchaseDate.Left = 5.767361F;
            this.TxtPurchaseDate.MultiLine = false;
            this.TxtPurchaseDate.Name = "TxtPurchaseDate";
            this.TxtPurchaseDate.OutputFormat = resources.GetString("TxtPurchaseDate.OutputFormat");
            this.TxtPurchaseDate.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtPurchaseDate.Text = null;
            this.TxtPurchaseDate.Top = 4F;
            this.TxtPurchaseDate.Width = 1.6875F;
            // 
            // TxtEntryDate
            // 
            this.TxtEntryDate.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtEntryDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEntryDate.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtEntryDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEntryDate.Border.RightColor = System.Drawing.Color.Black;
            this.TxtEntryDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEntryDate.Border.TopColor = System.Drawing.Color.Black;
            this.TxtEntryDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEntryDate.Height = 0.2F;
            this.TxtEntryDate.Left = 5.767361F;
            this.TxtEntryDate.MultiLine = false;
            this.TxtEntryDate.Name = "TxtEntryDate";
            this.TxtEntryDate.OutputFormat = resources.GetString("TxtEntryDate.OutputFormat");
            this.TxtEntryDate.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtEntryDate.Text = null;
            this.TxtEntryDate.Top = 4.375F;
            this.TxtEntryDate.Width = 1.6875F;
            // 
            // TxtStatus
            // 
            this.TxtStatus.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtStatus.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtStatus.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtStatus.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtStatus.Border.RightColor = System.Drawing.Color.Black;
            this.TxtStatus.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtStatus.Border.TopColor = System.Drawing.Color.Black;
            this.TxtStatus.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtStatus.Height = 0.2F;
            this.TxtStatus.Left = 1.079861F;
            this.TxtStatus.MultiLine = false;
            this.TxtStatus.Name = "TxtStatus";
            this.TxtStatus.OutputFormat = resources.GetString("TxtStatus.OutputFormat");
            this.TxtStatus.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtStatus.Text = null;
            this.TxtStatus.Top = 4.25F;
            this.TxtStatus.Width = 0.5F;
            // 
            // TxtPaymentRef
            // 
            this.TxtPaymentRef.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtPaymentRef.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPaymentRef.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtPaymentRef.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPaymentRef.Border.RightColor = System.Drawing.Color.Black;
            this.TxtPaymentRef.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPaymentRef.Border.TopColor = System.Drawing.Color.Black;
            this.TxtPaymentRef.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPaymentRef.Height = 0.2F;
            this.TxtPaymentRef.Left = 1.704861F;
            this.TxtPaymentRef.MultiLine = false;
            this.TxtPaymentRef.Name = "TxtPaymentRef";
            this.TxtPaymentRef.OutputFormat = resources.GetString("TxtPaymentRef.OutputFormat");
            this.TxtPaymentRef.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtPaymentRef.Text = null;
            this.TxtPaymentRef.Top = 4.25F;
            this.TxtPaymentRef.Width = 1.125F;
            // 
            // TxtEntry
            // 
            this.TxtEntry.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtEntry.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEntry.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtEntry.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEntry.Border.RightColor = System.Drawing.Color.Black;
            this.TxtEntry.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEntry.Border.TopColor = System.Drawing.Color.Black;
            this.TxtEntry.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEntry.Height = 0.2F;
            this.TxtEntry.Left = 2.875F;
            this.TxtEntry.MultiLine = false;
            this.TxtEntry.Name = "TxtEntry";
            this.TxtEntry.OutputFormat = resources.GetString("TxtEntry.OutputFormat");
            this.TxtEntry.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtEntry.Text = null;
            this.TxtEntry.Top = 4.25F;
            this.TxtEntry.Width = 0.6875F;
            // 
            // TxtAmount
            // 
            this.TxtAmount.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtAmount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAmount.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtAmount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAmount.Border.RightColor = System.Drawing.Color.Black;
            this.TxtAmount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAmount.Border.TopColor = System.Drawing.Color.Black;
            this.TxtAmount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAmount.Height = 0.2F;
            this.TxtAmount.Left = 3.875F;
            this.TxtAmount.MultiLine = false;
            this.TxtAmount.Name = "TxtAmount";
            this.TxtAmount.OutputFormat = resources.GetString("TxtAmount.OutputFormat");
            this.TxtAmount.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.TxtAmount.Text = null;
            this.TxtAmount.Top = 4.25F;
            this.TxtAmount.Width = 0.6875F;
            // 
            // Label163
            // 
            this.Label163.Border.BottomColor = System.Drawing.Color.Black;
            this.Label163.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label163.Border.LeftColor = System.Drawing.Color.Black;
            this.Label163.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label163.Border.RightColor = System.Drawing.Color.Black;
            this.Label163.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label163.Border.TopColor = System.Drawing.Color.Black;
            this.Label163.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label163.Height = 0.1875F;
            this.Label163.HyperLink = "";
            this.Label163.Left = 1F;
            this.Label163.Name = "Label163";
            this.Label163.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label163.Text = "A";
            this.Label163.Top = 4.5F;
            this.Label163.Width = 0.125F;
            // 
            // Label164
            // 
            this.Label164.Border.BottomColor = System.Drawing.Color.Black;
            this.Label164.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label164.Border.LeftColor = System.Drawing.Color.Black;
            this.Label164.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label164.Border.RightColor = System.Drawing.Color.Black;
            this.Label164.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label164.Border.TopColor = System.Drawing.Color.Black;
            this.Label164.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label164.Height = 0.1875F;
            this.Label164.HyperLink = "";
            this.Label164.Left = 1F;
            this.Label164.Name = "Label164";
            this.Label164.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label164.Text = "U";
            this.Label164.Top = 4.6875F;
            this.Label164.Width = 0.125F;
            // 
            // Label165
            // 
            this.Label165.Border.BottomColor = System.Drawing.Color.Black;
            this.Label165.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label165.Border.LeftColor = System.Drawing.Color.Black;
            this.Label165.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label165.Border.RightColor = System.Drawing.Color.Black;
            this.Label165.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label165.Border.TopColor = System.Drawing.Color.Black;
            this.Label165.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label165.Height = 0.1875F;
            this.Label165.HyperLink = "";
            this.Label165.Left = 1F;
            this.Label165.Name = "Label165";
            this.Label165.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label165.Text = "T";
            this.Label165.Top = 4.875F;
            this.Label165.Width = 0.125F;
            // 
            // Label166
            // 
            this.Label166.Border.BottomColor = System.Drawing.Color.Black;
            this.Label166.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label166.Border.LeftColor = System.Drawing.Color.Black;
            this.Label166.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label166.Border.RightColor = System.Drawing.Color.Black;
            this.Label166.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label166.Border.TopColor = System.Drawing.Color.Black;
            this.Label166.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label166.Height = 0.1875F;
            this.Label166.HyperLink = "";
            this.Label166.Left = 1F;
            this.Label166.Name = "Label166";
            this.Label166.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label166.Text = "O";
            this.Label166.Top = 5.0625F;
            this.Label166.Width = 0.125F;
            // 
            // Line7
            // 
            this.Line7.Border.BottomColor = System.Drawing.Color.Black;
            this.Line7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7.Border.LeftColor = System.Drawing.Color.Black;
            this.Line7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7.Border.RightColor = System.Drawing.Color.Black;
            this.Line7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7.Border.TopColor = System.Drawing.Color.Black;
            this.Line7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7.Height = 0.8125F;
            this.Line7.Left = 2.881944F;
            this.Line7.LineWeight = 1F;
            this.Line7.Name = "Line7";
            this.Line7.Top = 4.506945F;
            this.Line7.Width = 0F;
            this.Line7.X1 = 2.881944F;
            this.Line7.X2 = 2.881944F;
            this.Line7.Y1 = 4.506945F;
            this.Line7.Y2 = 5.319445F;
            // 
            // Line8
            // 
            this.Line8.Border.BottomColor = System.Drawing.Color.Black;
            this.Line8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8.Border.LeftColor = System.Drawing.Color.Black;
            this.Line8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8.Border.RightColor = System.Drawing.Color.Black;
            this.Line8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8.Border.TopColor = System.Drawing.Color.Black;
            this.Line8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8.Height = 0.8125F;
            this.Line8.Left = 1.131944F;
            this.Line8.LineWeight = 1F;
            this.Line8.Name = "Line8";
            this.Line8.Top = 4.506945F;
            this.Line8.Width = 0F;
            this.Line8.X1 = 1.131944F;
            this.Line8.X2 = 1.131944F;
            this.Line8.Y1 = 4.506945F;
            this.Line8.Y2 = 5.319445F;
            // 
            // Line9
            // 
            this.Line9.Border.BottomColor = System.Drawing.Color.Black;
            this.Line9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9.Border.LeftColor = System.Drawing.Color.Black;
            this.Line9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9.Border.RightColor = System.Drawing.Color.Black;
            this.Line9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9.Border.TopColor = System.Drawing.Color.Black;
            this.Line9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9.Height = 0.8125F;
            this.Line9.Left = 1.694444F;
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 4.506945F;
            this.Line9.Width = 0F;
            this.Line9.X1 = 1.694444F;
            this.Line9.X2 = 1.694444F;
            this.Line9.Y1 = 4.506945F;
            this.Line9.Y2 = 5.319445F;
            // 
            // Label167
            // 
            this.Label167.Border.BottomColor = System.Drawing.Color.Black;
            this.Label167.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label167.Border.LeftColor = System.Drawing.Color.Black;
            this.Label167.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label167.Border.RightColor = System.Drawing.Color.Black;
            this.Label167.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label167.Border.TopColor = System.Drawing.Color.Black;
            this.Label167.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label167.Height = 0.1875F;
            this.Label167.HyperLink = "";
            this.Label167.Left = 1.1875F;
            this.Label167.Name = "Label167";
            this.Label167.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label167.Text = "V.I.N.";
            this.Label167.Top = 4.5625F;
            this.Label167.Width = 0.375F;
            // 
            // Label168
            // 
            this.Label168.Border.BottomColor = System.Drawing.Color.Black;
            this.Label168.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label168.Border.LeftColor = System.Drawing.Color.Black;
            this.Label168.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label168.Border.RightColor = System.Drawing.Color.Black;
            this.Label168.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label168.Border.TopColor = System.Drawing.Color.Black;
            this.Label168.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label168.Height = 0.1875F;
            this.Label168.HyperLink = "";
            this.Label168.Left = 1.1875F;
            this.Label168.Name = "Label168";
            this.Label168.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label168.Text = "Make:";
            this.Label168.Top = 4.75F;
            this.Label168.Width = 0.375F;
            // 
            // Label169
            // 
            this.Label169.Border.BottomColor = System.Drawing.Color.Black;
            this.Label169.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label169.Border.LeftColor = System.Drawing.Color.Black;
            this.Label169.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label169.Border.RightColor = System.Drawing.Color.Black;
            this.Label169.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label169.Border.TopColor = System.Drawing.Color.Black;
            this.Label169.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label169.Height = 0.1875F;
            this.Label169.HyperLink = "";
            this.Label169.Left = 1.1875F;
            this.Label169.Name = "Label169";
            this.Label169.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label169.Text = "Model:";
            this.Label169.Top = 4.9375F;
            this.Label169.Width = 0.375F;
            // 
            // Label170
            // 
            this.Label170.Border.BottomColor = System.Drawing.Color.Black;
            this.Label170.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label170.Border.LeftColor = System.Drawing.Color.Black;
            this.Label170.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label170.Border.RightColor = System.Drawing.Color.Black;
            this.Label170.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label170.Border.TopColor = System.Drawing.Color.Black;
            this.Label170.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label170.Height = 0.1875F;
            this.Label170.HyperLink = "";
            this.Label170.Left = 1.1875F;
            this.Label170.Name = "Label170";
            this.Label170.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label170.Text = "Year:";
            this.Label170.Top = 5.125F;
            this.Label170.Width = 0.375F;
            // 
            // TxtVin
            // 
            this.TxtVin.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtVin.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVin.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtVin.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVin.Border.RightColor = System.Drawing.Color.Black;
            this.TxtVin.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVin.Border.TopColor = System.Drawing.Color.Black;
            this.TxtVin.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVin.Height = 0.2F;
            this.TxtVin.Left = 1.75F;
            this.TxtVin.MultiLine = false;
            this.TxtVin.Name = "TxtVin";
            this.TxtVin.OutputFormat = resources.GetString("TxtVin.OutputFormat");
            this.TxtVin.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtVin.Text = null;
            this.TxtVin.Top = 4.5625F;
            this.TxtVin.Width = 1.125F;
            // 
            // TxtMake
            // 
            this.TxtMake.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtMake.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMake.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtMake.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMake.Border.RightColor = System.Drawing.Color.Black;
            this.TxtMake.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMake.Border.TopColor = System.Drawing.Color.Black;
            this.TxtMake.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMake.Height = 0.2F;
            this.TxtMake.Left = 1.75F;
            this.TxtMake.MultiLine = false;
            this.TxtMake.Name = "TxtMake";
            this.TxtMake.OutputFormat = resources.GetString("TxtMake.OutputFormat");
            this.TxtMake.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtMake.Text = null;
            this.TxtMake.Top = 4.75F;
            this.TxtMake.Width = 1.125F;
            // 
            // TxtModel
            // 
            this.TxtModel.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtModel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtModel.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtModel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtModel.Border.RightColor = System.Drawing.Color.Black;
            this.TxtModel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtModel.Border.TopColor = System.Drawing.Color.Black;
            this.TxtModel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtModel.Height = 0.2F;
            this.TxtModel.Left = 1.75F;
            this.TxtModel.MultiLine = false;
            this.TxtModel.Name = "TxtModel";
            this.TxtModel.OutputFormat = resources.GetString("TxtModel.OutputFormat");
            this.TxtModel.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtModel.Text = null;
            this.TxtModel.Top = 4.9375F;
            this.TxtModel.Width = 1.125F;
            // 
            // TxtYear
            // 
            this.TxtYear.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtYear.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtYear.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtYear.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtYear.Border.RightColor = System.Drawing.Color.Black;
            this.TxtYear.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtYear.Border.TopColor = System.Drawing.Color.Black;
            this.TxtYear.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtYear.Height = 0.2F;
            this.TxtYear.Left = 1.75F;
            this.TxtYear.MultiLine = false;
            this.TxtYear.Name = "TxtYear";
            this.TxtYear.OutputFormat = resources.GetString("TxtYear.OutputFormat");
            this.TxtYear.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtYear.Text = null;
            this.TxtYear.Top = 5.125F;
            this.TxtYear.Width = 1.125F;
            // 
            // Label171
            // 
            this.Label171.Border.BottomColor = System.Drawing.Color.Black;
            this.Label171.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label171.Border.LeftColor = System.Drawing.Color.Black;
            this.Label171.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label171.Border.RightColor = System.Drawing.Color.Black;
            this.Label171.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label171.Border.TopColor = System.Drawing.Color.Black;
            this.Label171.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label171.Height = 0.1875F;
            this.Label171.HyperLink = "";
            this.Label171.Left = 2.9375F;
            this.Label171.Name = "Label171";
            this.Label171.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label171.Text = "Cost:";
            this.Label171.Top = 4.5625F;
            this.Label171.Width = 0.6875F;
            // 
            // Label172
            // 
            this.Label172.Border.BottomColor = System.Drawing.Color.Black;
            this.Label172.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label172.Border.LeftColor = System.Drawing.Color.Black;
            this.Label172.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label172.Border.RightColor = System.Drawing.Color.Black;
            this.Label172.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label172.Border.TopColor = System.Drawing.Color.Black;
            this.Label172.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label172.Height = 0.1875F;
            this.Label172.HyperLink = "";
            this.Label172.Left = 2.9375F;
            this.Label172.Name = "Label172";
            this.Label172.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label172.Text = "Odometer:";
            this.Label172.Top = 4.75F;
            this.Label172.Width = 0.6875F;
            // 
            // Label173
            // 
            this.Label173.Border.BottomColor = System.Drawing.Color.Black;
            this.Label173.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label173.Border.LeftColor = System.Drawing.Color.Black;
            this.Label173.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label173.Border.RightColor = System.Drawing.Color.Black;
            this.Label173.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label173.Border.TopColor = System.Drawing.Color.Black;
            this.Label173.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label173.Height = 0.1875F;
            this.Label173.HyperLink = "";
            this.Label173.Left = 2.9375F;
            this.Label173.Name = "Label173";
            this.Label173.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label173.Text = "Miles:";
            this.Label173.Top = 4.9375F;
            this.Label173.Width = 0.6875F;
            // 
            // Label174
            // 
            this.Label174.Border.BottomColor = System.Drawing.Color.Black;
            this.Label174.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label174.Border.LeftColor = System.Drawing.Color.Black;
            this.Label174.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label174.Border.RightColor = System.Drawing.Color.Black;
            this.Label174.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label174.Border.TopColor = System.Drawing.Color.Black;
            this.Label174.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label174.Height = 0.1875F;
            this.Label174.HyperLink = "";
            this.Label174.Left = 2.9375F;
            this.Label174.Name = "Label174";
            this.Label174.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label174.Text = "Class:";
            this.Label174.Top = 5.125F;
            this.Label174.Width = 0.6875F;
            // 
            // TxtCost
            // 
            this.TxtCost.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCost.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCost.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCost.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCost.Height = 0.2F;
            this.TxtCost.Left = 3.75F;
            this.TxtCost.MultiLine = false;
            this.TxtCost.Name = "TxtCost";
            this.TxtCost.OutputFormat = resources.GetString("TxtCost.OutputFormat");
            this.TxtCost.Style = "text-align: right; font-weight: normal; font-size: 8pt; ";
            this.TxtCost.Text = null;
            this.TxtCost.Top = 4.5625F;
            this.TxtCost.Width = 0.8125F;
            // 
            // TxtOdometer
            // 
            this.TxtOdometer.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtOdometer.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtOdometer.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtOdometer.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtOdometer.Border.RightColor = System.Drawing.Color.Black;
            this.TxtOdometer.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtOdometer.Border.TopColor = System.Drawing.Color.Black;
            this.TxtOdometer.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtOdometer.Height = 0.2F;
            this.TxtOdometer.Left = 3.75F;
            this.TxtOdometer.MultiLine = false;
            this.TxtOdometer.Name = "TxtOdometer";
            this.TxtOdometer.OutputFormat = resources.GetString("TxtOdometer.OutputFormat");
            this.TxtOdometer.Style = "text-align: right; font-weight: normal; font-size: 8pt; ";
            this.TxtOdometer.Text = null;
            this.TxtOdometer.Top = 4.75F;
            this.TxtOdometer.Width = 0.8125F;
            // 
            // TxtMiles
            // 
            this.TxtMiles.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtMiles.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMiles.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtMiles.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMiles.Border.RightColor = System.Drawing.Color.Black;
            this.TxtMiles.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMiles.Border.TopColor = System.Drawing.Color.Black;
            this.TxtMiles.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMiles.Height = 0.2F;
            this.TxtMiles.Left = 3.75F;
            this.TxtMiles.MultiLine = false;
            this.TxtMiles.Name = "TxtMiles";
            this.TxtMiles.OutputFormat = resources.GetString("TxtMiles.OutputFormat");
            this.TxtMiles.Style = "text-align: right; font-weight: normal; font-size: 8pt; ";
            this.TxtMiles.Text = null;
            this.TxtMiles.Top = 4.9375F;
            this.TxtMiles.Width = 0.8125F;
            // 
            // TxtClass
            // 
            this.TxtClass.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtClass.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtClass.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtClass.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtClass.Border.RightColor = System.Drawing.Color.Black;
            this.TxtClass.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtClass.Border.TopColor = System.Drawing.Color.Black;
            this.TxtClass.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtClass.Height = 0.2F;
            this.TxtClass.Left = 3.75F;
            this.TxtClass.MultiLine = false;
            this.TxtClass.Name = "TxtClass";
            this.TxtClass.OutputFormat = resources.GetString("TxtClass.OutputFormat");
            this.TxtClass.Style = "text-align: right; font-weight: normal; font-size: 8pt; ";
            this.TxtClass.Text = null;
            this.TxtClass.Top = 5.125F;
            this.TxtClass.Width = 0.8125F;
            // 
            // Shape4
            // 
            this.Shape4.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape4.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape4.Border.RightColor = System.Drawing.Color.Black;
            this.Shape4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape4.Border.TopColor = System.Drawing.Color.Black;
            this.Shape4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape4.Height = 0.5F;
            this.Shape4.Left = 0.9756944F;
            this.Shape4.LineWeight = 2F;
            this.Shape4.Name = "Shape4";
            this.Shape4.RoundingRadius = 9.999999F;
            this.Shape4.Top = 5.5625F;
            this.Shape4.Width = 4.211805F;
            // 
            // Shape5
            // 
            this.Shape5.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape5.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape5.Border.RightColor = System.Drawing.Color.Black;
            this.Shape5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape5.Border.TopColor = System.Drawing.Color.Black;
            this.Shape5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape5.Height = 0.75F;
            this.Shape5.Left = 5.1875F;
            this.Shape5.LineWeight = 2F;
            this.Shape5.Name = "Shape5";
            this.Shape5.RoundingRadius = 9.999999F;
            this.Shape5.Top = 5.5625F;
            this.Shape5.Width = 2.291666F;
            // 
            // Line10
            // 
            this.Line10.Border.BottomColor = System.Drawing.Color.Black;
            this.Line10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10.Border.LeftColor = System.Drawing.Color.Black;
            this.Line10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10.Border.RightColor = System.Drawing.Color.Black;
            this.Line10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10.Border.TopColor = System.Drawing.Color.Black;
            this.Line10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10.Height = 0.5F;
            this.Line10.Left = 3.756944F;
            this.Line10.LineWeight = 1F;
            this.Line10.Name = "Line10";
            this.Line10.Top = 5.569445F;
            this.Line10.Width = 0F;
            this.Line10.X1 = 3.756944F;
            this.Line10.X2 = 3.756944F;
            this.Line10.Y1 = 5.569445F;
            this.Line10.Y2 = 6.069445F;
            // 
            // Line11
            // 
            this.Line11.Border.BottomColor = System.Drawing.Color.Black;
            this.Line11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11.Border.LeftColor = System.Drawing.Color.Black;
            this.Line11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11.Border.RightColor = System.Drawing.Color.Black;
            this.Line11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11.Border.TopColor = System.Drawing.Color.Black;
            this.Line11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11.Height = 0.5F;
            this.Line11.Left = 2.756944F;
            this.Line11.LineWeight = 1F;
            this.Line11.Name = "Line11";
            this.Line11.Top = 5.569445F;
            this.Line11.Width = 0F;
            this.Line11.X1 = 2.756944F;
            this.Line11.X2 = 2.756944F;
            this.Line11.Y1 = 5.569445F;
            this.Line11.Y2 = 6.069445F;
            // 
            // Line12
            // 
            this.Line12.Border.BottomColor = System.Drawing.Color.Black;
            this.Line12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12.Border.LeftColor = System.Drawing.Color.Black;
            this.Line12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12.Border.RightColor = System.Drawing.Color.Black;
            this.Line12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12.Border.TopColor = System.Drawing.Color.Black;
            this.Line12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12.Height = 0.5F;
            this.Line12.Left = 1.881944F;
            this.Line12.LineWeight = 1F;
            this.Line12.Name = "Line12";
            this.Line12.Top = 5.569445F;
            this.Line12.Width = 0F;
            this.Line12.X1 = 1.881944F;
            this.Line12.X2 = 1.881944F;
            this.Line12.Y1 = 5.569445F;
            this.Line12.Y2 = 6.069445F;
            // 
            // Label175
            // 
            this.Label175.Border.BottomColor = System.Drawing.Color.Black;
            this.Label175.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label175.Border.LeftColor = System.Drawing.Color.Black;
            this.Label175.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label175.Border.RightColor = System.Drawing.Color.Black;
            this.Label175.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label175.Border.TopColor = System.Drawing.Color.Black;
            this.Label175.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label175.Height = 0.1875F;
            this.Label175.HyperLink = "";
            this.Label175.Left = 1.125F;
            this.Label175.Name = "Label175";
            this.Label175.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label175.Text = "Canc. Entry";
            this.Label175.Top = 5.625F;
            this.Label175.Width = 0.6875F;
            // 
            // Label176
            // 
            this.Label176.Border.BottomColor = System.Drawing.Color.Black;
            this.Label176.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label176.Border.LeftColor = System.Drawing.Color.Black;
            this.Label176.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label176.Border.RightColor = System.Drawing.Color.Black;
            this.Label176.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label176.Border.TopColor = System.Drawing.Color.Black;
            this.Label176.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label176.Height = 0.1875F;
            this.Label176.HyperLink = "";
            this.Label176.Left = 2F;
            this.Label176.Name = "Label176";
            this.Label176.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label176.Text = "Canc. Date";
            this.Label176.Top = 5.625F;
            this.Label176.Width = 0.6875F;
            // 
            // Label177
            // 
            this.Label177.Border.BottomColor = System.Drawing.Color.Black;
            this.Label177.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label177.Border.LeftColor = System.Drawing.Color.Black;
            this.Label177.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label177.Border.RightColor = System.Drawing.Color.Black;
            this.Label177.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label177.Border.TopColor = System.Drawing.Color.Black;
            this.Label177.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label177.Height = 0.1875F;
            this.Label177.HyperLink = "";
            this.Label177.Left = 2.8125F;
            this.Label177.Name = "Label177";
            this.Label177.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label177.Text = "ProR/ShortR.";
            this.Label177.Top = 5.625F;
            this.Label177.Width = 0.875F;
            // 
            // Label178
            // 
            this.Label178.Border.BottomColor = System.Drawing.Color.Black;
            this.Label178.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label178.Border.LeftColor = System.Drawing.Color.Black;
            this.Label178.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label178.Border.RightColor = System.Drawing.Color.Black;
            this.Label178.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label178.Border.TopColor = System.Drawing.Color.Black;
            this.Label178.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label178.Height = 0.1875F;
            this.Label178.HyperLink = "";
            this.Label178.Left = 3.8125F;
            this.Label178.Name = "Label178";
            this.Label178.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label178.Text = "Cancel Reason";
            this.Label178.Top = 5.625F;
            this.Label178.Width = 1.3125F;
            // 
            // Label179
            // 
            this.Label179.Border.BottomColor = System.Drawing.Color.Black;
            this.Label179.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label179.Border.LeftColor = System.Drawing.Color.Black;
            this.Label179.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label179.Border.RightColor = System.Drawing.Color.Black;
            this.Label179.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label179.Border.TopColor = System.Drawing.Color.Black;
            this.Label179.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label179.Height = 0.1875F;
            this.Label179.HyperLink = "";
            this.Label179.Left = 5.3125F;
            this.Label179.Name = "Label179";
            this.Label179.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label179.Text = "Rebate Premium:";
            this.Label179.Top = 5.625F;
            this.Label179.Width = 0.9375F;
            // 
            // Label180
            // 
            this.Label180.Border.BottomColor = System.Drawing.Color.Black;
            this.Label180.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label180.Border.LeftColor = System.Drawing.Color.Black;
            this.Label180.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label180.Border.RightColor = System.Drawing.Color.Black;
            this.Label180.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label180.Border.TopColor = System.Drawing.Color.Black;
            this.Label180.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label180.Height = 0.1875F;
            this.Label180.HyperLink = "";
            this.Label180.Left = 5.3125F;
            this.Label180.Name = "Label180";
            this.Label180.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label180.Text = "Owed:";
            this.Label180.Top = 5.8125F;
            this.Label180.Width = 0.9375F;
            // 
            // Label181
            // 
            this.Label181.Border.BottomColor = System.Drawing.Color.Black;
            this.Label181.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label181.Border.LeftColor = System.Drawing.Color.Black;
            this.Label181.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label181.Border.RightColor = System.Drawing.Color.Black;
            this.Label181.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label181.Border.TopColor = System.Drawing.Color.Black;
            this.Label181.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label181.Height = 0.1875F;
            this.Label181.HyperLink = "";
            this.Label181.Left = 5.3125F;
            this.Label181.Name = "Label181";
            this.Label181.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label181.Text = "Return Customer:";
            this.Label181.Top = 6F;
            this.Label181.Width = 0.9375F;
            // 
            // TxtCancEntry
            // 
            this.TxtCancEntry.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCancEntry.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancEntry.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCancEntry.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancEntry.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCancEntry.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancEntry.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCancEntry.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancEntry.Height = 0.2F;
            this.TxtCancEntry.Left = 1.125F;
            this.TxtCancEntry.MultiLine = false;
            this.TxtCancEntry.Name = "TxtCancEntry";
            this.TxtCancEntry.OutputFormat = resources.GetString("TxtCancEntry.OutputFormat");
            this.TxtCancEntry.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.TxtCancEntry.Text = null;
            this.TxtCancEntry.Top = 5.8125F;
            this.TxtCancEntry.Width = 0.6875F;
            // 
            // TxtCancDate
            // 
            this.TxtCancDate.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCancDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancDate.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCancDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancDate.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCancDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancDate.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCancDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancDate.Height = 0.2F;
            this.TxtCancDate.Left = 2F;
            this.TxtCancDate.MultiLine = false;
            this.TxtCancDate.Name = "TxtCancDate";
            this.TxtCancDate.OutputFormat = resources.GetString("TxtCancDate.OutputFormat");
            this.TxtCancDate.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.TxtCancDate.Text = null;
            this.TxtCancDate.Top = 5.8125F;
            this.TxtCancDate.Width = 0.6875F;
            // 
            // TxtCancType
            // 
            this.TxtCancType.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCancType.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancType.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCancType.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancType.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCancType.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancType.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCancType.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancType.Height = 0.2F;
            this.TxtCancType.Left = 2.8125F;
            this.TxtCancType.MultiLine = false;
            this.TxtCancType.Name = "TxtCancType";
            this.TxtCancType.OutputFormat = resources.GetString("TxtCancType.OutputFormat");
            this.TxtCancType.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.TxtCancType.Text = null;
            this.TxtCancType.Top = 5.8125F;
            this.TxtCancType.Width = 0.875F;
            // 
            // TxtCancReason
            // 
            this.TxtCancReason.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCancReason.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancReason.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCancReason.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancReason.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCancReason.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancReason.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCancReason.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancReason.Height = 0.2F;
            this.TxtCancReason.Left = 3.8125F;
            this.TxtCancReason.MultiLine = false;
            this.TxtCancReason.Name = "TxtCancReason";
            this.TxtCancReason.OutputFormat = resources.GetString("TxtCancReason.OutputFormat");
            this.TxtCancReason.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.TxtCancReason.Text = null;
            this.TxtCancReason.Top = 5.8125F;
            this.TxtCancReason.Width = 1.3125F;
            // 
            // TxtRebatePrem
            // 
            this.TxtRebatePrem.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtRebatePrem.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtRebatePrem.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtRebatePrem.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtRebatePrem.Border.RightColor = System.Drawing.Color.Black;
            this.TxtRebatePrem.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtRebatePrem.Border.TopColor = System.Drawing.Color.Black;
            this.TxtRebatePrem.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtRebatePrem.Height = 0.2F;
            this.TxtRebatePrem.Left = 6.25F;
            this.TxtRebatePrem.MultiLine = false;
            this.TxtRebatePrem.Name = "TxtRebatePrem";
            this.TxtRebatePrem.OutputFormat = resources.GetString("TxtRebatePrem.OutputFormat");
            this.TxtRebatePrem.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtRebatePrem.Text = null;
            this.TxtRebatePrem.Top = 5.625F;
            this.TxtRebatePrem.Width = 0.6875F;
            // 
            // TxtOwed
            // 
            this.TxtOwed.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtOwed.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtOwed.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtOwed.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtOwed.Border.RightColor = System.Drawing.Color.Black;
            this.TxtOwed.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtOwed.Border.TopColor = System.Drawing.Color.Black;
            this.TxtOwed.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtOwed.Height = 0.2F;
            this.TxtOwed.Left = 6.25F;
            this.TxtOwed.MultiLine = false;
            this.TxtOwed.Name = "TxtOwed";
            this.TxtOwed.OutputFormat = resources.GetString("TxtOwed.OutputFormat");
            this.TxtOwed.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtOwed.Text = null;
            this.TxtOwed.Top = 5.8125F;
            this.TxtOwed.Width = 0.6875F;
            // 
            // TxtReturnCust
            // 
            this.TxtReturnCust.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtReturnCust.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReturnCust.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtReturnCust.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReturnCust.Border.RightColor = System.Drawing.Color.Black;
            this.TxtReturnCust.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReturnCust.Border.TopColor = System.Drawing.Color.Black;
            this.TxtReturnCust.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReturnCust.Height = 0.2F;
            this.TxtReturnCust.Left = 6.25F;
            this.TxtReturnCust.MultiLine = false;
            this.TxtReturnCust.Name = "TxtReturnCust";
            this.TxtReturnCust.OutputFormat = resources.GetString("TxtReturnCust.OutputFormat");
            this.TxtReturnCust.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtReturnCust.Text = null;
            this.TxtReturnCust.Top = 6F;
            this.TxtReturnCust.Width = 0.6875F;
            // 
            // Label182
            // 
            this.Label182.Border.BottomColor = System.Drawing.Color.Black;
            this.Label182.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label182.Border.LeftColor = System.Drawing.Color.Black;
            this.Label182.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label182.Border.RightColor = System.Drawing.Color.Black;
            this.Label182.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label182.Border.TopColor = System.Drawing.Color.Black;
            this.Label182.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label182.Height = 0.1875F;
            this.Label182.HyperLink = "";
            this.Label182.Left = 7F;
            this.Label182.Name = "Label182";
            this.Label182.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label182.Text = "%Unear.";
            this.Label182.Top = 5.625F;
            this.Label182.Width = 0.5F;
            // 
            // TxtUnearn
            // 
            this.TxtUnearn.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtUnearn.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtUnearn.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtUnearn.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtUnearn.Border.RightColor = System.Drawing.Color.Black;
            this.TxtUnearn.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtUnearn.Border.TopColor = System.Drawing.Color.Black;
            this.TxtUnearn.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtUnearn.Height = 0.2F;
            this.TxtUnearn.Left = 7F;
            this.TxtUnearn.MultiLine = false;
            this.TxtUnearn.Name = "TxtUnearn";
            this.TxtUnearn.OutputFormat = resources.GetString("TxtUnearn.OutputFormat");
            this.TxtUnearn.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtUnearn.Text = null;
            this.TxtUnearn.Top = 5.8125F;
            this.TxtUnearn.Width = 0.5F;
            // 
            // Label183
            // 
            this.Label183.Border.BottomColor = System.Drawing.Color.Black;
            this.Label183.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label183.Border.LeftColor = System.Drawing.Color.Black;
            this.Label183.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label183.Border.RightColor = System.Drawing.Color.Black;
            this.Label183.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label183.Border.TopColor = System.Drawing.Color.Black;
            this.Label183.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label183.Height = 0.1875F;
            this.Label183.HyperLink = "";
            this.Label183.Left = 1.0625F;
            this.Label183.Name = "Label183";
            this.Label183.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label183.Text = "Made By:";
            this.Label183.Top = 6.5F;
            this.Label183.Width = 0.5625F;
            // 
            // TxtMadeBy
            // 
            this.TxtMadeBy.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtMadeBy.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMadeBy.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtMadeBy.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMadeBy.Border.RightColor = System.Drawing.Color.Black;
            this.TxtMadeBy.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMadeBy.Border.TopColor = System.Drawing.Color.Black;
            this.TxtMadeBy.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMadeBy.Height = 0.2F;
            this.TxtMadeBy.Left = 1.6875F;
            this.TxtMadeBy.MultiLine = false;
            this.TxtMadeBy.Name = "TxtMadeBy";
            this.TxtMadeBy.OutputFormat = resources.GetString("TxtMadeBy.OutputFormat");
            this.TxtMadeBy.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtMadeBy.Text = null;
            this.TxtMadeBy.Top = 6.5F;
            this.TxtMadeBy.Width = 2.125F;
            // 
            // TxtDate
            // 
            this.TxtDate.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDate.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDate.Border.RightColor = System.Drawing.Color.Black;
            this.TxtDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDate.Border.TopColor = System.Drawing.Color.Black;
            this.TxtDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDate.Height = 0.2F;
            this.TxtDate.Left = 1.6875F;
            this.TxtDate.MultiLine = false;
            this.TxtDate.Name = "TxtDate";
            this.TxtDate.OutputFormat = resources.GetString("TxtDate.OutputFormat");
            this.TxtDate.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtDate.Text = null;
            this.TxtDate.Top = 6.75F;
            this.TxtDate.Width = 0.6875F;
            // 
            // TxtHour
            // 
            this.TxtHour.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtHour.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtHour.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtHour.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtHour.Border.RightColor = System.Drawing.Color.Black;
            this.TxtHour.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtHour.Border.TopColor = System.Drawing.Color.Black;
            this.TxtHour.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtHour.Height = 0.2F;
            this.TxtHour.Left = 2.5625F;
            this.TxtHour.MultiLine = false;
            this.TxtHour.Name = "TxtHour";
            this.TxtHour.OutputFormat = resources.GetString("TxtHour.OutputFormat");
            this.TxtHour.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtHour.Text = null;
            this.TxtHour.Top = 6.75F;
            this.TxtHour.Width = 0.6875F;
            // 
            // Line6
            // 
            this.Line6.Border.BottomColor = System.Drawing.Color.Black;
            this.Line6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6.Border.LeftColor = System.Drawing.Color.Black;
            this.Line6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6.Border.RightColor = System.Drawing.Color.Black;
            this.Line6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6.Border.TopColor = System.Drawing.Color.Black;
            this.Line6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6.Height = 0.8125F;
            this.Line6.Left = 3.694444F;
            this.Line6.LineWeight = 1F;
            this.Line6.Name = "Line6";
            this.Line6.Top = 4.506945F;
            this.Line6.Width = 0F;
            this.Line6.X1 = 3.694444F;
            this.Line6.X2 = 3.694444F;
            this.Line6.Y1 = 4.506945F;
            this.Line6.Y2 = 5.319445F;
            // 
            // Line13
            // 
            this.Line13.Border.BottomColor = System.Drawing.Color.Black;
            this.Line13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13.Border.LeftColor = System.Drawing.Color.Black;
            this.Line13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13.Border.RightColor = System.Drawing.Color.Black;
            this.Line13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13.Border.TopColor = System.Drawing.Color.Black;
            this.Line13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13.Height = 3.375001F;
            this.Line13.Left = 4.631945F;
            this.Line13.LineWeight = 1F;
            this.Line13.Name = "Line13";
            this.Line13.Top = 1.944444F;
            this.Line13.Width = 0F;
            this.Line13.X1 = 4.631945F;
            this.Line13.X2 = 4.631945F;
            this.Line13.Y1 = 1.944444F;
            this.Line13.Y2 = 5.319445F;
            // 
            // TxtBank
            // 
            this.TxtBank.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtBank.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBank.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtBank.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBank.Border.RightColor = System.Drawing.Color.Black;
            this.TxtBank.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBank.Border.TopColor = System.Drawing.Color.Black;
            this.TxtBank.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBank.Height = 0.2F;
            this.TxtBank.Left = 5.767361F;
            this.TxtBank.MultiLine = false;
            this.TxtBank.Name = "TxtBank";
            this.TxtBank.OutputFormat = resources.GetString("TxtBank.OutputFormat");
            this.TxtBank.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtBank.Text = null;
            this.TxtBank.Top = 3.25F;
            this.TxtBank.Width = 1.6875F;
            // 
            // TxtLastName1
            // 
            this.TxtLastName1.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtLastName1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLastName1.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtLastName1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLastName1.Border.RightColor = System.Drawing.Color.Black;
            this.TxtLastName1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLastName1.Border.TopColor = System.Drawing.Color.Black;
            this.TxtLastName1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLastName1.Height = 0.2F;
            this.TxtLastName1.Left = 2.246528F;
            this.TxtLastName1.MultiLine = false;
            this.TxtLastName1.Name = "TxtLastName1";
            this.TxtLastName1.OutputFormat = resources.GetString("TxtLastName1.OutputFormat");
            this.TxtLastName1.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtLastName1.Text = null;
            this.TxtLastName1.Top = 2.5F;
            this.TxtLastName1.Width = 2.0625F;
            // 
            // TxtLastName2
            // 
            this.TxtLastName2.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtLastName2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLastName2.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtLastName2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLastName2.Border.RightColor = System.Drawing.Color.Black;
            this.TxtLastName2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLastName2.Border.TopColor = System.Drawing.Color.Black;
            this.TxtLastName2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLastName2.Height = 0.2F;
            this.TxtLastName2.Left = 2.246528F;
            this.TxtLastName2.MultiLine = false;
            this.TxtLastName2.Name = "TxtLastName2";
            this.TxtLastName2.OutputFormat = resources.GetString("TxtLastName2.OutputFormat");
            this.TxtLastName2.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtLastName2.Text = null;
            this.TxtLastName2.Top = 2.6875F;
            this.TxtLastName2.Width = 2.0625F;
            // 
            // Label75
            // 
            this.Label75.Border.BottomColor = System.Drawing.Color.Black;
            this.Label75.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label75.Border.LeftColor = System.Drawing.Color.Black;
            this.Label75.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label75.Border.RightColor = System.Drawing.Color.Black;
            this.Label75.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label75.Border.TopColor = System.Drawing.Color.Black;
            this.Label75.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label75.Height = 0.1875F;
            this.Label75.HyperLink = "";
            this.Label75.Left = 1.8125F;
            this.Label75.MultiLine = false;
            this.Label75.Name = "Label75";
            this.Label75.Style = "text-align: center; font-weight: bold; font-size: 11.25pt; font-family: Times New" +
                " Roman; ";
            this.Label75.Text = "PUERTO RICO MEDICAL DEFENSE INSURANCE COMPANY";
            this.Label75.Top = 0.4375F;
            this.Label75.Width = 5.125F;
            // 
            // Label77
            // 
            this.Label77.Border.BottomColor = System.Drawing.Color.Black;
            this.Label77.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label77.Border.LeftColor = System.Drawing.Color.Black;
            this.Label77.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label77.Border.RightColor = System.Drawing.Color.Black;
            this.Label77.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label77.Border.TopColor = System.Drawing.Color.Black;
            this.Label77.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label77.Height = 0.1875F;
            this.Label77.HyperLink = "";
            this.Label77.Left = 1.8125F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-align: center; font-weight: bold; font-size: 6pt; font-family: Times New Rom" +
                "an; ";
            this.Label77.Text = "";
            this.Label77.Top = 0.6875F;
            this.Label77.Width = 5.125F;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0.6756945F;
            this.PageFooter.Name = "PageFooter";
            // 
            // AutoGuardCancellation
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.1F;
            this.PageSettings.Margins.Left = 0.1F;
            this.PageSettings.Margins.Right = 0.1F;
            this.PageSettings.Margins.Top = 0.2F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.479167F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.AutoGuardCancellation_FetchData);
            ((System.ComponentModel.ISupportInitialize)(this.Label138)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSocialSecurity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerAddr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerAddr2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label139)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label140)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label141)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label142)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label143)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label144)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label145)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label146)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label147)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label148)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label149)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label150)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label151)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label152)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label153)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label154)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label155)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label156)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label157)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label158)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSTCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label159)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label160)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label161)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label162)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPolicyNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTerm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEffectiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtInsCo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtExpireDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDealer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAgent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAgency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOrigGuaranty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPurchaseDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEntryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPaymentRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label163)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label164)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label165)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label166)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label167)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label168)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label169)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label170)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label171)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label172)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label173)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label174)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOdometer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label175)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label176)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label177)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label178)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label179)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label180)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label181)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCancEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCancDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCancType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCancReason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRebatePrem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOwed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtReturnCust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label182)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUnearn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label183)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMadeBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLastName1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLastName2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
