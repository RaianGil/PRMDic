using System;
using System.Data;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.Customer;
using EPolicy.LookupTables;
using EPolicy.TaskControl;

namespace EPolicy2.Reports
{
	public class CancellationCredit : DataDynamics.ActiveReports.ActiveReport3
	{
		private string _CopyValue;
		private EPolicy.TaskControl.AutoGuardServicesContract _taskcontrol;

		public CancellationCredit(EPolicy.TaskControl.AutoGuardServicesContract taskcontrol,string CopyValue)
		{
			_taskcontrol = taskcontrol;
			_CopyValue = CopyValue;

			InitializeComponent();
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void CancellationCredit_ReportStart(object sender, System.EventArgs eArgs)
		{
				TxtPolicyNumber.Text = _taskcontrol.PolicyType.ToString().ToUpper().Trim()+" "+_taskcontrol.PolicyNo.ToString().Trim()+" "+_taskcontrol.Certificate.ToString().Trim()+" "+ _taskcontrol.Suffix.Trim();
													
					EPolicy.LookupTables.InsuranceCompany insurancecompany = new EPolicy.LookupTables.InsuranceCompany();
					insurancecompany = insurancecompany.GetInsuranceCompany(_taskcontrol.InsuranceCompany);
					TxtInsuranceCompany.Text = insurancecompany.InsuranceCompanyDesc.ToString();

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
			TxtCustomerName.Text = _taskcontrol.Customer.FirstName.Trim() +" "+_taskcontrol.Customer.Initial.Trim()+" "+
				_taskcontrol.Customer.LastName1.Trim()+ " "+_taskcontrol.Customer.LastName2.Trim();
				
				
			TxtCustomerAddr1.Text = _taskcontrol.Customer.Address1.Trim().ToUpper();
			if(_taskcontrol.Customer.Address2.Trim().ToUpper() == "")
			{
				TxtCustomerAddr2.Text = _taskcontrol.Customer.City.Trim().ToUpper()+" "+
					_taskcontrol.Customer.State.Trim().ToUpper()+" "+
					_taskcontrol.Customer.ZipCode.Trim().ToUpper();
				TxtCustomerCity.Text  = "";
			}
			else
			{
				TxtCustomerAddr2.Text = _taskcontrol.Customer.Address2.Trim().ToUpper();
				TxtCustomerCity.Text  = _taskcontrol.Customer.City.Trim().ToUpper()+" "+
					_taskcontrol.Customer.State.Trim().ToUpper()+" "+
					_taskcontrol.Customer.ZipCode.Trim().ToUpper();
			}
 				
					//Bank
					EPolicy.LookupTables.Bank bank = new Bank();
					bank = bank.GetBank(_taskcontrol.Bank);
					//			bank = bank.GetBank(_policy.Bank);

					TxtBankName.Text = bank.BankDesc.Trim().ToUpper();
								
					if (bank.Address1 != "")
					{								
						TxtBankAddr1.Text = bank.Address1.Trim().ToUpper();	
						if(bank.Address2.Trim().ToUpper() == "")
						{
							TxtBankAddr2.Text = bank.City.Trim().ToUpper()+" "+
								bank.State.Trim().ToUpper()+" "+
								bank.ZipCode.Trim().ToUpper();
							TxtBankCity.Text = "";
						
						}
						else
						{
							TxtBankAddr2.Text = bank.Address2.Trim().ToUpper();
							TxtBankCity.Text  = bank.City.Trim().ToUpper()+" "+
								bank.State.Trim().ToUpper()+" "+
								bank.ZipCode.Trim().ToUpper();
						}
					}


					TxtTakeEffective.Text  = _taskcontrol.CancellationDate.ToString().Trim();
					//TxtCertificate.Text
					TxtEffectiveDate.Text  = _taskcontrol.EffectiveDate.ToString().Trim();
					TxtExpirationDate.Text = _taskcontrol.ExpirationDate.ToString().Trim();
					TxtDeductibles.Text    = _taskcontrol.Deductible.ToString().Trim();
					TxtTotalPremium.Text   = _taskcontrol.TotalPremium.ToString().Trim();
					TxtTotalPremium1.Text  = _taskcontrol.TotalPremium.ToString().Trim();
					TxtReturnPremium.Text  = _taskcontrol.ReturnPremium.ToString("#,##0.00").Trim();
					TxtReturnPremium1.Text = _taskcontrol.ReturnPremium.ToString("#,##0.00").Trim();
			        TxtReasonCancellation.Text = LookupTables.GetDescription("CancellationMethod",_taskcontrol.CancellationMethod.ToString());
			        TxtCancellationMethod.Text = LookupTables.GetDescription("CancellationReason",_taskcontrol.CancellationReason.ToString());

					TxtCancellationMethod.Text   = LookupTables.GetDescription("CancellationMethod",_taskcontrol.CancellationMethod.ToString()).ToUpper();
					TxtReasonCancellation.Text = LookupTables.GetDescription("CancellationReason",_taskcontrol.CancellationReason.ToString()).ToUpper();

					DateTime date    = DateTime.Now;
					TxtDate.Text    = date.ToShortDateString().Trim();

					EPolicy.LookupTables.Agency agy = new Agency();
					agy = agy.GetAgency(_taskcontrol.Agency);
					TxtAgency.Text = agy.AgencyID.ToString().Trim()+ " "+ agy.AgencyDesc.Trim().ToUpper();

					EPolicy.LookupTables.Agent agt = new Agent();
					agt = agt.GetAgent(_taskcontrol.Agent);
					TxtAgent.Text = agt.AgentID.ToString().Trim()+ " "+ agt.AgentDesc.Trim().ToUpper();

					TxtCustomer.Text = _taskcontrol.CustomerNo.ToString().Trim();

					EPolicy.LookupTables.CompanyDealer CD = new CompanyDealer();
					CD = CD.GetCompanyDealer(_taskcontrol.CompanyDealer);
					TxtDealer.Text = CD.CompanyDealerID.ToString().Trim()+ " "+ CD.CompanyDealerDesc.Trim().ToUpper();

					TxtSocSec.Text             = _taskcontrol.Customer.SocialSecurity.ToString().Trim();
					TxtAmountPaid.Text         = _taskcontrol.PaidAmount.ToString().Trim();
					TxtLoan.Text               = _taskcontrol.LoanNo.ToString().Trim();
					TxtReturnCancellation.Text  = _taskcontrol.CancellationAmount.ToString().Trim();
					TxtEnteredBy.Text          = _taskcontrol.EnteredBy.ToString().Trim();
					
					double total = _taskcontrol.PaidAmount - _taskcontrol.TotalPremium;
					TxtOwed.Text = total.ToString();
				
			if(_taskcontrol.PaidAmount - _taskcontrol.TotalPremium > 0)
			{
				lblOverPayment.Visible = true;
				lblOwed.Visible        = false;
			}
			else
			{
				lblOverPayment.Visible = false;
				lblOwed.Visible        = true;
			}

		}

		#region ActiveReports Designer generated code
		private ReportHeader ReportHeader = null;
		private PageHeader PageHeader = null;
		private Label lblCancellation = null;
		private Label Label78 = null;
		private Label Label138 = null;
		private Label Label139 = null;
		private Line Line61 = null;
		private Line Line62 = null;
		private Line Line147 = null;
		private Line Line148 = null;
		private Label Label105 = null;
		private Label Label122 = null;
		private Line Line213 = null;
		private Line Line149 = null;
		private Line Line214 = null;
		private TextBox TxtCustomerName = null;
		private TextBox TxtCustomerAddr1 = null;
		private TextBox TxtCustomerAddr2 = null;
		private TextBox TxtCustomerCity = null;
		private Line Line215 = null;
		private Line Line216 = null;
		private Line Line217 = null;
		private Line Line218 = null;
		private Line Line219 = null;
		private Label Label140 = null;
		private Label Label141 = null;
		private Line Line220 = null;
		private Line Line221 = null;
		private Line Line222 = null;
		private TextBox TxtBankCity = null;
		private TextBox TxtBankAddr2 = null;
		private TextBox TxtBankAddr1 = null;
		private TextBox TxtBankName = null;
		private Label Label120 = null;
		private Line Line196 = null;
		private Line Line211 = null;
		private Line Line194 = null;
		private Line Line193 = null;
		private Line Line212 = null;
		private Shape Shape1 = null;
		private Label Label142 = null;
		private Label Label143 = null;
		private Label Label144 = null;
		private Label Label145 = null;
		private Label Label146 = null;
		private Label Label147 = null;
		private TextBox TxtReasonCancellation = null;
		private Label Label148 = null;
		private TextBox TxtTakeEffective = null;
		private TextBox TxtCancellationTo = null;
		private TextBox TxtCertificate = null;
		private TextBox TxtPolicyNumber = null;
		private Line Line223 = null;
		private Line Line224 = null;
		private Label Label149 = null;
		private Line Line225 = null;
		private Line Line226 = null;
		private Line Line227 = null;
		private TextBox TxtEffectiveDate = null;
		private Line Line228 = null;
		private Line Line229 = null;
		private Label Label150 = null;
		private Line Line230 = null;
		private Line Line231 = null;
		private Line Line232 = null;
		private TextBox TxtExpirationDate = null;
		private Line Line233 = null;
		private Line Line235 = null;
		private Label Label151 = null;
		private Label Label152 = null;
		private Line Line236 = null;
		private Label Label153 = null;
		private Line Line237 = null;
		private Label Label154 = null;
		private Line Line238 = null;
		private Label Label155 = null;
		private Line Line239 = null;
		private Line Line234 = null;
		private Line Line240 = null;
		private Label Label156 = null;
		private TextBox TxtTotalPremium1 = null;
		private TextBox TxtReturnPremium1 = null;
		private TextBox TxtReturnPremium = null;
		private TextBox TxtTotalPremium = null;
		private Line Line241 = null;
		private Line Line242 = null;
		private Line Line244 = null;
		private Line Line245 = null;
		private Label Label157 = null;
		private Line Line246 = null;
		private TextBox TxtDate = null;
		private Label Label158 = null;
		private Line Line243 = null;
		private Label Label159 = null;
		private Label Label160 = null;
		private Label Label161 = null;
		private Line Line248 = null;
		private Line Line249 = null;
		private TextBox TxtInsuranceCompany = null;
		private Line Line247 = null;
		private TextBox TxtAgency = null;
		private TextBox TxtCustomer = null;
		private Line Line250 = null;
		private Line Line251 = null;
		private Label Label162 = null;
		private Label Label163 = null;
		private Label Label164 = null;
		private Line Line252 = null;
		private Line Line253 = null;
		private TextBox TxtAgent = null;
		private Line Line254 = null;
		private TextBox TxtDealer = null;
		private TextBox TxtSocSec = null;
		private Line Line255 = null;
		private Line Line256 = null;
		private Label Label165 = null;
		private Label lblOwed = null;
		private Label Label167 = null;
		private Line Line257 = null;
		private Line Line258 = null;
		private TextBox TxtReturnCancellation = null;
		private Line Line259 = null;
		private TextBox TxtOwed = null;
		private TextBox TxtReturn = null;
		private Line Line260 = null;
		private Line Line261 = null;
		private Label Label168 = null;
		private Label Label169 = null;
		private Line Line262 = null;
		private Line Line263 = null;
		private TextBox TxtAmountPaid = null;
		private Line Line264 = null;
		private TextBox TxtLoan = null;
		private Line Line266 = null;
		private Label Label170 = null;
		private TextBox TxtEnteredBy = null;
		private Line Line265 = null;
		private TextBox TxtDeductibles = null;
		private TextBox TxtCancellationMethod = null;
		private Label lblOverPayment = null;
		private Label Label75 = null;
		private Label Label77 = null;
		private Detail Detail = null;
		private PageFooter PageFooter = null;
		private ReportFooter ReportFooter = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CancellationCredit));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.lblCancellation = new DataDynamics.ActiveReports.Label();
            this.Label78 = new DataDynamics.ActiveReports.Label();
            this.Label138 = new DataDynamics.ActiveReports.Label();
            this.Label139 = new DataDynamics.ActiveReports.Label();
            this.Line61 = new DataDynamics.ActiveReports.Line();
            this.Line62 = new DataDynamics.ActiveReports.Line();
            this.Line147 = new DataDynamics.ActiveReports.Line();
            this.Line148 = new DataDynamics.ActiveReports.Line();
            this.Label105 = new DataDynamics.ActiveReports.Label();
            this.Label122 = new DataDynamics.ActiveReports.Label();
            this.Line213 = new DataDynamics.ActiveReports.Line();
            this.Line149 = new DataDynamics.ActiveReports.Line();
            this.Line214 = new DataDynamics.ActiveReports.Line();
            this.TxtCustomerName = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerAddr1 = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerAddr2 = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerCity = new DataDynamics.ActiveReports.TextBox();
            this.Line215 = new DataDynamics.ActiveReports.Line();
            this.Line216 = new DataDynamics.ActiveReports.Line();
            this.Line217 = new DataDynamics.ActiveReports.Line();
            this.Line218 = new DataDynamics.ActiveReports.Line();
            this.Line219 = new DataDynamics.ActiveReports.Line();
            this.Label140 = new DataDynamics.ActiveReports.Label();
            this.Label141 = new DataDynamics.ActiveReports.Label();
            this.Line220 = new DataDynamics.ActiveReports.Line();
            this.Line221 = new DataDynamics.ActiveReports.Line();
            this.Line222 = new DataDynamics.ActiveReports.Line();
            this.TxtBankCity = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankAddr2 = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankAddr1 = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankName = new DataDynamics.ActiveReports.TextBox();
            this.Label120 = new DataDynamics.ActiveReports.Label();
            this.Line196 = new DataDynamics.ActiveReports.Line();
            this.Line211 = new DataDynamics.ActiveReports.Line();
            this.Line194 = new DataDynamics.ActiveReports.Line();
            this.Line193 = new DataDynamics.ActiveReports.Line();
            this.Line212 = new DataDynamics.ActiveReports.Line();
            this.Shape1 = new DataDynamics.ActiveReports.Shape();
            this.Label142 = new DataDynamics.ActiveReports.Label();
            this.Label143 = new DataDynamics.ActiveReports.Label();
            this.Label144 = new DataDynamics.ActiveReports.Label();
            this.Label145 = new DataDynamics.ActiveReports.Label();
            this.Label146 = new DataDynamics.ActiveReports.Label();
            this.Label147 = new DataDynamics.ActiveReports.Label();
            this.TxtReasonCancellation = new DataDynamics.ActiveReports.TextBox();
            this.Label148 = new DataDynamics.ActiveReports.Label();
            this.TxtTakeEffective = new DataDynamics.ActiveReports.TextBox();
            this.TxtCancellationTo = new DataDynamics.ActiveReports.TextBox();
            this.TxtCertificate = new DataDynamics.ActiveReports.TextBox();
            this.TxtPolicyNumber = new DataDynamics.ActiveReports.TextBox();
            this.Line223 = new DataDynamics.ActiveReports.Line();
            this.Line224 = new DataDynamics.ActiveReports.Line();
            this.Label149 = new DataDynamics.ActiveReports.Label();
            this.Line225 = new DataDynamics.ActiveReports.Line();
            this.Line226 = new DataDynamics.ActiveReports.Line();
            this.Line227 = new DataDynamics.ActiveReports.Line();
            this.TxtEffectiveDate = new DataDynamics.ActiveReports.TextBox();
            this.Line228 = new DataDynamics.ActiveReports.Line();
            this.Line229 = new DataDynamics.ActiveReports.Line();
            this.Label150 = new DataDynamics.ActiveReports.Label();
            this.Line230 = new DataDynamics.ActiveReports.Line();
            this.Line231 = new DataDynamics.ActiveReports.Line();
            this.Line232 = new DataDynamics.ActiveReports.Line();
            this.TxtExpirationDate = new DataDynamics.ActiveReports.TextBox();
            this.Line233 = new DataDynamics.ActiveReports.Line();
            this.Line235 = new DataDynamics.ActiveReports.Line();
            this.Label151 = new DataDynamics.ActiveReports.Label();
            this.Label152 = new DataDynamics.ActiveReports.Label();
            this.Line236 = new DataDynamics.ActiveReports.Line();
            this.Label153 = new DataDynamics.ActiveReports.Label();
            this.Line237 = new DataDynamics.ActiveReports.Line();
            this.Label154 = new DataDynamics.ActiveReports.Label();
            this.Line238 = new DataDynamics.ActiveReports.Line();
            this.Label155 = new DataDynamics.ActiveReports.Label();
            this.Line239 = new DataDynamics.ActiveReports.Line();
            this.Line234 = new DataDynamics.ActiveReports.Line();
            this.Line240 = new DataDynamics.ActiveReports.Line();
            this.Label156 = new DataDynamics.ActiveReports.Label();
            this.TxtTotalPremium1 = new DataDynamics.ActiveReports.TextBox();
            this.TxtReturnPremium1 = new DataDynamics.ActiveReports.TextBox();
            this.TxtReturnPremium = new DataDynamics.ActiveReports.TextBox();
            this.TxtTotalPremium = new DataDynamics.ActiveReports.TextBox();
            this.Line241 = new DataDynamics.ActiveReports.Line();
            this.Line242 = new DataDynamics.ActiveReports.Line();
            this.Line244 = new DataDynamics.ActiveReports.Line();
            this.Line245 = new DataDynamics.ActiveReports.Line();
            this.Label157 = new DataDynamics.ActiveReports.Label();
            this.Line246 = new DataDynamics.ActiveReports.Line();
            this.TxtDate = new DataDynamics.ActiveReports.TextBox();
            this.Label158 = new DataDynamics.ActiveReports.Label();
            this.Line243 = new DataDynamics.ActiveReports.Line();
            this.Label159 = new DataDynamics.ActiveReports.Label();
            this.Label160 = new DataDynamics.ActiveReports.Label();
            this.Label161 = new DataDynamics.ActiveReports.Label();
            this.Line248 = new DataDynamics.ActiveReports.Line();
            this.Line249 = new DataDynamics.ActiveReports.Line();
            this.TxtInsuranceCompany = new DataDynamics.ActiveReports.TextBox();
            this.Line247 = new DataDynamics.ActiveReports.Line();
            this.TxtAgency = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomer = new DataDynamics.ActiveReports.TextBox();
            this.Line250 = new DataDynamics.ActiveReports.Line();
            this.Line251 = new DataDynamics.ActiveReports.Line();
            this.Label162 = new DataDynamics.ActiveReports.Label();
            this.Label163 = new DataDynamics.ActiveReports.Label();
            this.Label164 = new DataDynamics.ActiveReports.Label();
            this.Line252 = new DataDynamics.ActiveReports.Line();
            this.Line253 = new DataDynamics.ActiveReports.Line();
            this.TxtAgent = new DataDynamics.ActiveReports.TextBox();
            this.Line254 = new DataDynamics.ActiveReports.Line();
            this.TxtDealer = new DataDynamics.ActiveReports.TextBox();
            this.TxtSocSec = new DataDynamics.ActiveReports.TextBox();
            this.Line255 = new DataDynamics.ActiveReports.Line();
            this.Line256 = new DataDynamics.ActiveReports.Line();
            this.Label165 = new DataDynamics.ActiveReports.Label();
            this.lblOwed = new DataDynamics.ActiveReports.Label();
            this.Label167 = new DataDynamics.ActiveReports.Label();
            this.Line257 = new DataDynamics.ActiveReports.Line();
            this.Line258 = new DataDynamics.ActiveReports.Line();
            this.TxtReturnCancellation = new DataDynamics.ActiveReports.TextBox();
            this.Line259 = new DataDynamics.ActiveReports.Line();
            this.TxtOwed = new DataDynamics.ActiveReports.TextBox();
            this.TxtReturn = new DataDynamics.ActiveReports.TextBox();
            this.Line260 = new DataDynamics.ActiveReports.Line();
            this.Line261 = new DataDynamics.ActiveReports.Line();
            this.Label168 = new DataDynamics.ActiveReports.Label();
            this.Label169 = new DataDynamics.ActiveReports.Label();
            this.Line262 = new DataDynamics.ActiveReports.Line();
            this.Line263 = new DataDynamics.ActiveReports.Line();
            this.TxtAmountPaid = new DataDynamics.ActiveReports.TextBox();
            this.Line264 = new DataDynamics.ActiveReports.Line();
            this.TxtLoan = new DataDynamics.ActiveReports.TextBox();
            this.Line266 = new DataDynamics.ActiveReports.Line();
            this.Label170 = new DataDynamics.ActiveReports.Label();
            this.TxtEnteredBy = new DataDynamics.ActiveReports.TextBox();
            this.Line265 = new DataDynamics.ActiveReports.Line();
            this.TxtDeductibles = new DataDynamics.ActiveReports.TextBox();
            this.TxtCancellationMethod = new DataDynamics.ActiveReports.TextBox();
            this.lblOverPayment = new DataDynamics.ActiveReports.Label();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.lblCancellation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label78)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label138)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label139)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label122)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerAddr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerAddr2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label140)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label141)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAddr2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAddr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label120)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label142)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label143)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label144)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label145)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label146)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label147)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtReasonCancellation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label148)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTakeEffective)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCancellationTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCertificate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPolicyNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label149)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEffectiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label150)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtExpirationDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label151)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label152)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label153)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label154)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label155)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label156)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotalPremium1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtReturnPremium1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtReturnPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotalPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label157)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label158)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label159)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label160)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label161)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtInsuranceCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAgency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label162)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label163)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label164)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDealer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSocSec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label165)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOwed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label167)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtReturnCancellation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOwed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label168)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label169)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAmountPaid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label170)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEnteredBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDeductibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCancellationMethod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOverPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Height = 0.15625F;
            this.Detail.Name = "Detail";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Height = 0F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Height = 0.2291667F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblCancellation,
            this.Label78,
            this.Label138,
            this.Label139,
            this.Line61,
            this.Line62,
            this.Line147,
            this.Line148,
            this.Label105,
            this.Label122,
            this.Line213,
            this.Line149,
            this.Line214,
            this.TxtCustomerName,
            this.TxtCustomerAddr1,
            this.TxtCustomerAddr2,
            this.TxtCustomerCity,
            this.Line215,
            this.Line216,
            this.Line217,
            this.Line218,
            this.Line219,
            this.Label140,
            this.Label141,
            this.Line220,
            this.Line221,
            this.Line222,
            this.TxtBankCity,
            this.TxtBankAddr2,
            this.TxtBankAddr1,
            this.TxtBankName,
            this.Label120,
            this.Line196,
            this.Line211,
            this.Line194,
            this.Line193,
            this.Line212,
            this.Shape1,
            this.Label142,
            this.Label143,
            this.Label144,
            this.Label145,
            this.Label146,
            this.Label147,
            this.TxtReasonCancellation,
            this.Label148,
            this.TxtTakeEffective,
            this.TxtCancellationTo,
            this.TxtCertificate,
            this.TxtPolicyNumber,
            this.Line223,
            this.Line224,
            this.Label149,
            this.Line225,
            this.Line226,
            this.Line227,
            this.TxtEffectiveDate,
            this.Line228,
            this.Line229,
            this.Label150,
            this.Line230,
            this.Line231,
            this.Line232,
            this.TxtExpirationDate,
            this.Line233,
            this.Line235,
            this.Label151,
            this.Label152,
            this.Line236,
            this.Label153,
            this.Line237,
            this.Label154,
            this.Line238,
            this.Label155,
            this.Line239,
            this.Line234,
            this.Line240,
            this.Label156,
            this.TxtTotalPremium1,
            this.TxtReturnPremium1,
            this.TxtReturnPremium,
            this.TxtTotalPremium,
            this.Line241,
            this.Line242,
            this.Line244,
            this.Line245,
            this.Label157,
            this.Line246,
            this.TxtDate,
            this.Label158,
            this.Line243,
            this.Label159,
            this.Label160,
            this.Label161,
            this.Line248,
            this.Line249,
            this.TxtInsuranceCompany,
            this.Line247,
            this.TxtAgency,
            this.TxtCustomer,
            this.Line250,
            this.Line251,
            this.Label162,
            this.Label163,
            this.Label164,
            this.Line252,
            this.Line253,
            this.TxtAgent,
            this.Line254,
            this.TxtDealer,
            this.TxtSocSec,
            this.Line255,
            this.Line256,
            this.Label165,
            this.lblOwed,
            this.Label167,
            this.Line257,
            this.Line258,
            this.TxtReturnCancellation,
            this.Line259,
            this.TxtOwed,
            this.TxtReturn,
            this.Line260,
            this.Line261,
            this.Label168,
            this.Label169,
            this.Line262,
            this.Line263,
            this.TxtAmountPaid,
            this.Line264,
            this.TxtLoan,
            this.Line266,
            this.Label170,
            this.TxtEnteredBy,
            this.Line265,
            this.TxtDeductibles,
            this.TxtCancellationMethod,
            this.lblOverPayment,
            this.Label75,
            this.Label77});
            this.PageHeader.Height = 8.363194F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // lblCancellation
            // 
            this.lblCancellation.Border.BottomColor = System.Drawing.Color.Black;
            this.lblCancellation.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCancellation.Border.LeftColor = System.Drawing.Color.Black;
            this.lblCancellation.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCancellation.Border.RightColor = System.Drawing.Color.Black;
            this.lblCancellation.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCancellation.Border.TopColor = System.Drawing.Color.Black;
            this.lblCancellation.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCancellation.Height = 0.25F;
            this.lblCancellation.HyperLink = "";
            this.lblCancellation.Left = 6F;
            this.lblCancellation.MultiLine = false;
            this.lblCancellation.Name = "lblCancellation";
            this.lblCancellation.Style = "text-align: left; font-weight: bold; font-size: 15.75pt; ";
            this.lblCancellation.Text = "Cancellation";
            this.lblCancellation.Top = 0.1875F;
            this.lblCancellation.Width = 1.4375F;
            // 
            // Label78
            // 
            this.Label78.Border.BottomColor = System.Drawing.Color.Black;
            this.Label78.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label78.Border.LeftColor = System.Drawing.Color.Black;
            this.Label78.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label78.Border.RightColor = System.Drawing.Color.Black;
            this.Label78.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label78.Border.TopColor = System.Drawing.Color.Black;
            this.Label78.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label78.Height = 0.25F;
            this.Label78.HyperLink = "";
            this.Label78.Left = 6F;
            this.Label78.MultiLine = false;
            this.Label78.Name = "Label78";
            this.Label78.Style = "text-align: center; font-weight: bold; font-size: 15.75pt; ";
            this.Label78.Text = "Credit";
            this.Label78.Top = 0.375F;
            this.Label78.Width = 1.4375F;
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
            this.Label138.Left = 1.947917F;
            this.Label138.Name = "Label138";
            this.Label138.Style = "text-align: center; font-weight: bold; font-size: 11pt; ";
            this.Label138.Text = "AUTO GAP POLICY";
            this.Label138.Top = 1.3125F;
            this.Label138.Width = 4.125F;
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
            this.Label139.Height = 0.25F;
            this.Label139.HyperLink = "";
            this.Label139.Left = 0.3125F;
            this.Label139.Name = "Label139";
            this.Label139.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; font-family: Microsof" +
                "t Sans Serif; vertical-align: middle; ";
            this.Label139.Text = "NAME INSURED";
            this.Label139.Top = 2.3125F;
            this.Label139.Width = 2.875F;
            // 
            // Line61
            // 
            this.Line61.Border.BottomColor = System.Drawing.Color.Black;
            this.Line61.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line61.Border.LeftColor = System.Drawing.Color.Black;
            this.Line61.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line61.Border.RightColor = System.Drawing.Color.Black;
            this.Line61.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line61.Border.TopColor = System.Drawing.Color.Black;
            this.Line61.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line61.Height = 0.375F;
            this.Line61.Left = 3.1875F;
            this.Line61.LineWeight = 1F;
            this.Line61.Name = "Line61";
            this.Line61.Top = 1.6875F;
            this.Line61.Width = 0F;
            this.Line61.X1 = 3.1875F;
            this.Line61.X2 = 3.1875F;
            this.Line61.Y1 = 2.0625F;
            this.Line61.Y2 = 1.6875F;
            // 
            // Line62
            // 
            this.Line62.Border.BottomColor = System.Drawing.Color.Black;
            this.Line62.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line62.Border.LeftColor = System.Drawing.Color.Black;
            this.Line62.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line62.Border.RightColor = System.Drawing.Color.Black;
            this.Line62.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line62.Border.TopColor = System.Drawing.Color.Black;
            this.Line62.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line62.Height = 0.375F;
            this.Line62.Left = 0.3125F;
            this.Line62.LineWeight = 1F;
            this.Line62.Name = "Line62";
            this.Line62.Top = 1.6875F;
            this.Line62.Width = 0F;
            this.Line62.X1 = 0.3125F;
            this.Line62.X2 = 0.3125F;
            this.Line62.Y1 = 2.0625F;
            this.Line62.Y2 = 1.6875F;
            // 
            // Line147
            // 
            this.Line147.Border.BottomColor = System.Drawing.Color.Black;
            this.Line147.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line147.Border.LeftColor = System.Drawing.Color.Black;
            this.Line147.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line147.Border.RightColor = System.Drawing.Color.Black;
            this.Line147.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line147.Border.TopColor = System.Drawing.Color.Black;
            this.Line147.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line147.Height = 0F;
            this.Line147.Left = 0.3125F;
            this.Line147.LineWeight = 1F;
            this.Line147.Name = "Line147";
            this.Line147.Top = 2.3125F;
            this.Line147.Width = 2.875F;
            this.Line147.X1 = 0.3125F;
            this.Line147.X2 = 3.1875F;
            this.Line147.Y1 = 2.3125F;
            this.Line147.Y2 = 2.3125F;
            // 
            // Line148
            // 
            this.Line148.Border.BottomColor = System.Drawing.Color.Black;
            this.Line148.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line148.Border.LeftColor = System.Drawing.Color.Black;
            this.Line148.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line148.Border.RightColor = System.Drawing.Color.Black;
            this.Line148.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line148.Border.TopColor = System.Drawing.Color.Black;
            this.Line148.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line148.Height = 0F;
            this.Line148.Left = 0.3125F;
            this.Line148.LineWeight = 1F;
            this.Line148.Name = "Line148";
            this.Line148.Top = 2.5625F;
            this.Line148.Width = 2.875F;
            this.Line148.X1 = 0.3125F;
            this.Line148.X2 = 3.1875F;
            this.Line148.Y1 = 2.5625F;
            this.Line148.Y2 = 2.5625F;
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
            this.Label105.Left = 0.375F;
            this.Label105.Name = "Label105";
            this.Label105.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label105.Text = "CANCELLATION TO";
            this.Label105.Top = 1.6875F;
            this.Label105.Width = 1.125F;
            // 
            // Label122
            // 
            this.Label122.Border.BottomColor = System.Drawing.Color.Black;
            this.Label122.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label122.Border.LeftColor = System.Drawing.Color.Black;
            this.Label122.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label122.Border.RightColor = System.Drawing.Color.Black;
            this.Label122.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label122.Border.TopColor = System.Drawing.Color.Black;
            this.Label122.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label122.Height = 0.1875F;
            this.Label122.HyperLink = "";
            this.Label122.Left = 0.375F;
            this.Label122.Name = "Label122";
            this.Label122.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label122.Text = "TAKE EFFECTIVE AT";
            this.Label122.Top = 1.875F;
            this.Label122.Width = 1.1875F;
            // 
            // Line213
            // 
            this.Line213.Border.BottomColor = System.Drawing.Color.Black;
            this.Line213.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line213.Border.LeftColor = System.Drawing.Color.Black;
            this.Line213.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line213.Border.RightColor = System.Drawing.Color.Black;
            this.Line213.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line213.Border.TopColor = System.Drawing.Color.Black;
            this.Line213.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line213.Height = 0.375F;
            this.Line213.Left = 1.5F;
            this.Line213.LineWeight = 1F;
            this.Line213.Name = "Line213";
            this.Line213.Top = 1.6875F;
            this.Line213.Width = 0F;
            this.Line213.X1 = 1.5F;
            this.Line213.X2 = 1.5F;
            this.Line213.Y1 = 2.0625F;
            this.Line213.Y2 = 1.6875F;
            // 
            // Line149
            // 
            this.Line149.Border.BottomColor = System.Drawing.Color.Black;
            this.Line149.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line149.Border.LeftColor = System.Drawing.Color.Black;
            this.Line149.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line149.Border.RightColor = System.Drawing.Color.Black;
            this.Line149.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line149.Border.TopColor = System.Drawing.Color.Black;
            this.Line149.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line149.Height = 0F;
            this.Line149.Left = 0.3125F;
            this.Line149.LineWeight = 1F;
            this.Line149.Name = "Line149";
            this.Line149.Top = 3.3125F;
            this.Line149.Width = 2.875F;
            this.Line149.X1 = 0.3125F;
            this.Line149.X2 = 3.1875F;
            this.Line149.Y1 = 3.3125F;
            this.Line149.Y2 = 3.3125F;
            // 
            // Line214
            // 
            this.Line214.Border.BottomColor = System.Drawing.Color.Black;
            this.Line214.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line214.Border.LeftColor = System.Drawing.Color.Black;
            this.Line214.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line214.Border.RightColor = System.Drawing.Color.Black;
            this.Line214.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line214.Border.TopColor = System.Drawing.Color.Black;
            this.Line214.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line214.Height = 0F;
            this.Line214.Left = 0.3125F;
            this.Line214.LineWeight = 1F;
            this.Line214.Name = "Line214";
            this.Line214.Top = 2.0625F;
            this.Line214.Width = 2.875F;
            this.Line214.X1 = 0.3125F;
            this.Line214.X2 = 3.1875F;
            this.Line214.Y1 = 2.0625F;
            this.Line214.Y2 = 2.0625F;
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
            this.TxtCustomerName.DataField = "CustomerName";
            this.TxtCustomerName.Height = 0.2F;
            this.TxtCustomerName.Left = 0.4375F;
            this.TxtCustomerName.MultiLine = false;
            this.TxtCustomerName.Name = "TxtCustomerName";
            this.TxtCustomerName.OutputFormat = resources.GetString("TxtCustomerName.OutputFormat");
            this.TxtCustomerName.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; font-family: Microsoft " +
                "Sans Serif; ";
            this.TxtCustomerName.Text = "TxtCustomerName";
            this.TxtCustomerName.Top = 2.625F;
            this.TxtCustomerName.Width = 2.664772F;
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
            this.TxtCustomerAddr1.DataField = "Addrress1";
            this.TxtCustomerAddr1.Height = 0.2F;
            this.TxtCustomerAddr1.Left = 0.4375F;
            this.TxtCustomerAddr1.MultiLine = false;
            this.TxtCustomerAddr1.Name = "TxtCustomerAddr1";
            this.TxtCustomerAddr1.OutputFormat = resources.GetString("TxtCustomerAddr1.OutputFormat");
            this.TxtCustomerAddr1.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtCustomerAddr1.Text = null;
            this.TxtCustomerAddr1.Top = 2.8125F;
            this.TxtCustomerAddr1.Width = 2.664773F;
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
            this.TxtCustomerAddr2.DataField = "Addrress2";
            this.TxtCustomerAddr2.Height = 0.2F;
            this.TxtCustomerAddr2.Left = 0.4375F;
            this.TxtCustomerAddr2.MultiLine = false;
            this.TxtCustomerAddr2.Name = "TxtCustomerAddr2";
            this.TxtCustomerAddr2.OutputFormat = resources.GetString("TxtCustomerAddr2.OutputFormat");
            this.TxtCustomerAddr2.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtCustomerAddr2.Text = null;
            this.TxtCustomerAddr2.Top = 2.9375F;
            this.TxtCustomerAddr2.Width = 2.664773F;
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
            this.TxtCustomerCity.DataField = "Addrress3";
            this.TxtCustomerCity.Height = 0.2F;
            this.TxtCustomerCity.Left = 0.4375F;
            this.TxtCustomerCity.MultiLine = false;
            this.TxtCustomerCity.Name = "TxtCustomerCity";
            this.TxtCustomerCity.OutputFormat = resources.GetString("TxtCustomerCity.OutputFormat");
            this.TxtCustomerCity.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtCustomerCity.Text = null;
            this.TxtCustomerCity.Top = 3.0625F;
            this.TxtCustomerCity.Width = 2.664773F;
            // 
            // Line215
            // 
            this.Line215.Border.BottomColor = System.Drawing.Color.Black;
            this.Line215.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line215.Border.LeftColor = System.Drawing.Color.Black;
            this.Line215.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line215.Border.RightColor = System.Drawing.Color.Black;
            this.Line215.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line215.Border.TopColor = System.Drawing.Color.Black;
            this.Line215.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line215.Height = 1F;
            this.Line215.Left = 3.1875F;
            this.Line215.LineWeight = 1F;
            this.Line215.Name = "Line215";
            this.Line215.Top = 2.3125F;
            this.Line215.Width = 0F;
            this.Line215.X1 = 3.1875F;
            this.Line215.X2 = 3.1875F;
            this.Line215.Y1 = 3.3125F;
            this.Line215.Y2 = 2.3125F;
            // 
            // Line216
            // 
            this.Line216.Border.BottomColor = System.Drawing.Color.Black;
            this.Line216.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line216.Border.LeftColor = System.Drawing.Color.Black;
            this.Line216.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line216.Border.RightColor = System.Drawing.Color.Black;
            this.Line216.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line216.Border.TopColor = System.Drawing.Color.Black;
            this.Line216.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line216.Height = 1F;
            this.Line216.Left = 0.3125F;
            this.Line216.LineWeight = 1F;
            this.Line216.Name = "Line216";
            this.Line216.Top = 2.3125F;
            this.Line216.Width = 0F;
            this.Line216.X1 = 0.3125F;
            this.Line216.X2 = 0.3125F;
            this.Line216.Y1 = 3.3125F;
            this.Line216.Y2 = 2.3125F;
            // 
            // Line217
            // 
            this.Line217.Border.BottomColor = System.Drawing.Color.Black;
            this.Line217.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line217.Border.LeftColor = System.Drawing.Color.Black;
            this.Line217.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line217.Border.RightColor = System.Drawing.Color.Black;
            this.Line217.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line217.Border.TopColor = System.Drawing.Color.Black;
            this.Line217.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line217.Height = 0F;
            this.Line217.Left = 0.3125F;
            this.Line217.LineWeight = 1F;
            this.Line217.Name = "Line217";
            this.Line217.Top = 1.6875F;
            this.Line217.Width = 2.875F;
            this.Line217.X1 = 0.3125F;
            this.Line217.X2 = 3.1875F;
            this.Line217.Y1 = 1.6875F;
            this.Line217.Y2 = 1.6875F;
            // 
            // Line218
            // 
            this.Line218.Border.BottomColor = System.Drawing.Color.Black;
            this.Line218.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line218.Border.LeftColor = System.Drawing.Color.Black;
            this.Line218.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line218.Border.RightColor = System.Drawing.Color.Black;
            this.Line218.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line218.Border.TopColor = System.Drawing.Color.Black;
            this.Line218.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line218.Height = 0.375F;
            this.Line218.Left = 7.625F;
            this.Line218.LineWeight = 1F;
            this.Line218.Name = "Line218";
            this.Line218.Top = 1.6875F;
            this.Line218.Width = 0F;
            this.Line218.X1 = 7.625F;
            this.Line218.X2 = 7.625F;
            this.Line218.Y1 = 2.0625F;
            this.Line218.Y2 = 1.6875F;
            // 
            // Line219
            // 
            this.Line219.Border.BottomColor = System.Drawing.Color.Black;
            this.Line219.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line219.Border.LeftColor = System.Drawing.Color.Black;
            this.Line219.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line219.Border.RightColor = System.Drawing.Color.Black;
            this.Line219.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line219.Border.TopColor = System.Drawing.Color.Black;
            this.Line219.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line219.Height = 0.375F;
            this.Line219.Left = 4.75F;
            this.Line219.LineWeight = 1F;
            this.Line219.Name = "Line219";
            this.Line219.Top = 1.6875F;
            this.Line219.Width = 0F;
            this.Line219.X1 = 4.75F;
            this.Line219.X2 = 4.75F;
            this.Line219.Y1 = 2.0625F;
            this.Line219.Y2 = 1.6875F;
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
            this.Label140.Left = 4.8125F;
            this.Label140.Name = "Label140";
            this.Label140.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label140.Text = "POLICY NUMBER";
            this.Label140.Top = 1.6875F;
            this.Label140.Width = 1F;
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
            this.Label141.Left = 4.8125F;
            this.Label141.Name = "Label141";
            this.Label141.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label141.Text = "CERTIFICATE";
            this.Label141.Top = 1.875F;
            this.Label141.Width = 1F;
            // 
            // Line220
            // 
            this.Line220.Border.BottomColor = System.Drawing.Color.Black;
            this.Line220.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line220.Border.LeftColor = System.Drawing.Color.Black;
            this.Line220.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line220.Border.RightColor = System.Drawing.Color.Black;
            this.Line220.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line220.Border.TopColor = System.Drawing.Color.Black;
            this.Line220.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line220.Height = 0.375F;
            this.Line220.Left = 5.9375F;
            this.Line220.LineWeight = 1F;
            this.Line220.Name = "Line220";
            this.Line220.Top = 1.6875F;
            this.Line220.Width = 0F;
            this.Line220.X1 = 5.9375F;
            this.Line220.X2 = 5.9375F;
            this.Line220.Y1 = 2.0625F;
            this.Line220.Y2 = 1.6875F;
            // 
            // Line221
            // 
            this.Line221.Border.BottomColor = System.Drawing.Color.Black;
            this.Line221.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line221.Border.LeftColor = System.Drawing.Color.Black;
            this.Line221.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line221.Border.RightColor = System.Drawing.Color.Black;
            this.Line221.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line221.Border.TopColor = System.Drawing.Color.Black;
            this.Line221.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line221.Height = 0F;
            this.Line221.Left = 4.75F;
            this.Line221.LineWeight = 1F;
            this.Line221.Name = "Line221";
            this.Line221.Top = 2.0625F;
            this.Line221.Width = 2.875F;
            this.Line221.X1 = 4.75F;
            this.Line221.X2 = 7.625F;
            this.Line221.Y1 = 2.0625F;
            this.Line221.Y2 = 2.0625F;
            // 
            // Line222
            // 
            this.Line222.Border.BottomColor = System.Drawing.Color.Black;
            this.Line222.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line222.Border.LeftColor = System.Drawing.Color.Black;
            this.Line222.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line222.Border.RightColor = System.Drawing.Color.Black;
            this.Line222.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line222.Border.TopColor = System.Drawing.Color.Black;
            this.Line222.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line222.Height = 0F;
            this.Line222.Left = 4.75F;
            this.Line222.LineWeight = 1F;
            this.Line222.Name = "Line222";
            this.Line222.Top = 1.6875F;
            this.Line222.Width = 2.875F;
            this.Line222.X1 = 4.75F;
            this.Line222.X2 = 7.625F;
            this.Line222.Y1 = 1.6875F;
            this.Line222.Y2 = 1.6875F;
            // 
            // TxtBankCity
            // 
            this.TxtBankCity.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtBankCity.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankCity.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtBankCity.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankCity.Border.RightColor = System.Drawing.Color.Black;
            this.TxtBankCity.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankCity.Border.TopColor = System.Drawing.Color.Black;
            this.TxtBankCity.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankCity.DataField = "BankAddress";
            this.TxtBankCity.Height = 0.2000003F;
            this.TxtBankCity.Left = 4.8125F;
            this.TxtBankCity.MultiLine = false;
            this.TxtBankCity.Name = "TxtBankCity";
            this.TxtBankCity.OutputFormat = resources.GetString("TxtBankCity.OutputFormat");
            this.TxtBankCity.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.TxtBankCity.Text = null;
            this.TxtBankCity.Top = 3F;
            this.TxtBankCity.Width = 2.6875F;
            // 
            // TxtBankAddr2
            // 
            this.TxtBankAddr2.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtBankAddr2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddr2.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtBankAddr2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddr2.Border.RightColor = System.Drawing.Color.Black;
            this.TxtBankAddr2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddr2.Border.TopColor = System.Drawing.Color.Black;
            this.TxtBankAddr2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddr2.DataField = "BankAddress2";
            this.TxtBankAddr2.Height = 0.2000003F;
            this.TxtBankAddr2.Left = 4.8125F;
            this.TxtBankAddr2.MultiLine = false;
            this.TxtBankAddr2.Name = "TxtBankAddr2";
            this.TxtBankAddr2.OutputFormat = resources.GetString("TxtBankAddr2.OutputFormat");
            this.TxtBankAddr2.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.TxtBankAddr2.Text = null;
            this.TxtBankAddr2.Top = 2.875F;
            this.TxtBankAddr2.Width = 2.6875F;
            // 
            // TxtBankAddr1
            // 
            this.TxtBankAddr1.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtBankAddr1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddr1.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtBankAddr1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddr1.Border.RightColor = System.Drawing.Color.Black;
            this.TxtBankAddr1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddr1.Border.TopColor = System.Drawing.Color.Black;
            this.TxtBankAddr1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddr1.DataField = "BankAddress1";
            this.TxtBankAddr1.Height = 0.2000003F;
            this.TxtBankAddr1.Left = 4.8125F;
            this.TxtBankAddr1.MultiLine = false;
            this.TxtBankAddr1.Name = "TxtBankAddr1";
            this.TxtBankAddr1.OutputFormat = resources.GetString("TxtBankAddr1.OutputFormat");
            this.TxtBankAddr1.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.TxtBankAddr1.Text = null;
            this.TxtBankAddr1.Top = 2.75F;
            this.TxtBankAddr1.Width = 2.6875F;
            // 
            // TxtBankName
            // 
            this.TxtBankName.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtBankName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankName.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtBankName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankName.Border.RightColor = System.Drawing.Color.Black;
            this.TxtBankName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankName.Border.TopColor = System.Drawing.Color.Black;
            this.TxtBankName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankName.DataField = "BankDesc";
            this.TxtBankName.Height = 0.2000003F;
            this.TxtBankName.Left = 4.8125F;
            this.TxtBankName.MultiLine = false;
            this.TxtBankName.Name = "TxtBankName";
            this.TxtBankName.OutputFormat = resources.GetString("TxtBankName.OutputFormat");
            this.TxtBankName.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.TxtBankName.Text = null;
            this.TxtBankName.Top = 2.625F;
            this.TxtBankName.Width = 2.6875F;
            // 
            // Label120
            // 
            this.Label120.Border.BottomColor = System.Drawing.Color.Black;
            this.Label120.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label120.Border.LeftColor = System.Drawing.Color.Black;
            this.Label120.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label120.Border.RightColor = System.Drawing.Color.Black;
            this.Label120.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label120.Border.TopColor = System.Drawing.Color.Black;
            this.Label120.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label120.Height = 0.25F;
            this.Label120.HyperLink = "";
            this.Label120.Left = 4.75F;
            this.Label120.Name = "Label120";
            this.Label120.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; font-family: Microsof" +
                "t Sans Serif; vertical-align: middle; ";
            this.Label120.Text = "LIENHOLDER (LOSS PAYEE)";
            this.Label120.Top = 2.3125F;
            this.Label120.Width = 2.875F;
            // 
            // Line196
            // 
            this.Line196.Border.BottomColor = System.Drawing.Color.Black;
            this.Line196.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line196.Border.LeftColor = System.Drawing.Color.Black;
            this.Line196.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line196.Border.RightColor = System.Drawing.Color.Black;
            this.Line196.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line196.Border.TopColor = System.Drawing.Color.Black;
            this.Line196.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line196.Height = 0F;
            this.Line196.Left = 4.75F;
            this.Line196.LineWeight = 1F;
            this.Line196.Name = "Line196";
            this.Line196.Top = 2.5625F;
            this.Line196.Width = 2.875F;
            this.Line196.X1 = 4.75F;
            this.Line196.X2 = 7.625F;
            this.Line196.Y1 = 2.5625F;
            this.Line196.Y2 = 2.5625F;
            // 
            // Line211
            // 
            this.Line211.Border.BottomColor = System.Drawing.Color.Black;
            this.Line211.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line211.Border.LeftColor = System.Drawing.Color.Black;
            this.Line211.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line211.Border.RightColor = System.Drawing.Color.Black;
            this.Line211.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line211.Border.TopColor = System.Drawing.Color.Black;
            this.Line211.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line211.Height = 0F;
            this.Line211.Left = 4.75F;
            this.Line211.LineWeight = 1F;
            this.Line211.Name = "Line211";
            this.Line211.Top = 2.3125F;
            this.Line211.Width = 2.875F;
            this.Line211.X1 = 4.75F;
            this.Line211.X2 = 7.625F;
            this.Line211.Y1 = 2.3125F;
            this.Line211.Y2 = 2.3125F;
            // 
            // Line194
            // 
            this.Line194.Border.BottomColor = System.Drawing.Color.Black;
            this.Line194.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line194.Border.LeftColor = System.Drawing.Color.Black;
            this.Line194.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line194.Border.RightColor = System.Drawing.Color.Black;
            this.Line194.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line194.Border.TopColor = System.Drawing.Color.Black;
            this.Line194.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line194.Height = 1F;
            this.Line194.Left = 4.75F;
            this.Line194.LineWeight = 1F;
            this.Line194.Name = "Line194";
            this.Line194.Top = 2.3125F;
            this.Line194.Width = 0F;
            this.Line194.X1 = 4.75F;
            this.Line194.X2 = 4.75F;
            this.Line194.Y1 = 3.3125F;
            this.Line194.Y2 = 2.3125F;
            // 
            // Line193
            // 
            this.Line193.Border.BottomColor = System.Drawing.Color.Black;
            this.Line193.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line193.Border.LeftColor = System.Drawing.Color.Black;
            this.Line193.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line193.Border.RightColor = System.Drawing.Color.Black;
            this.Line193.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line193.Border.TopColor = System.Drawing.Color.Black;
            this.Line193.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line193.Height = 1F;
            this.Line193.Left = 7.625F;
            this.Line193.LineWeight = 1F;
            this.Line193.Name = "Line193";
            this.Line193.Top = 2.3125F;
            this.Line193.Width = 0F;
            this.Line193.X1 = 7.625F;
            this.Line193.X2 = 7.625F;
            this.Line193.Y1 = 3.3125F;
            this.Line193.Y2 = 2.3125F;
            // 
            // Line212
            // 
            this.Line212.Border.BottomColor = System.Drawing.Color.Black;
            this.Line212.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line212.Border.LeftColor = System.Drawing.Color.Black;
            this.Line212.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line212.Border.RightColor = System.Drawing.Color.Black;
            this.Line212.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line212.Border.TopColor = System.Drawing.Color.Black;
            this.Line212.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line212.Height = 0F;
            this.Line212.Left = 4.75F;
            this.Line212.LineWeight = 1F;
            this.Line212.Name = "Line212";
            this.Line212.Top = 3.3125F;
            this.Line212.Width = 2.875F;
            this.Line212.X1 = 4.75F;
            this.Line212.X2 = 7.625F;
            this.Line212.Y1 = 3.3125F;
            this.Line212.Y2 = 3.3125F;
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
            this.Shape1.Height = 1.4375F;
            this.Shape1.Left = 0.3125F;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = 9.999999F;
            this.Shape1.Top = 3.5F;
            this.Shape1.Width = 7.3125F;
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
            this.Label142.Left = 0.375F;
            this.Label142.Name = "Label142";
            this.Label142.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.Label142.Text = "YOU ARE HEREBY NOTICE IN ACCORDANCE WITH THE TEMRS AND CONDITIONS OF THE ABOVE ME" +
                "NTIONED POLICY, THAT YOUR";
            this.Label142.Top = 3.5625F;
            this.Label142.Width = 7.125F;
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
            this.Label143.Left = 0.375F;
            this.Label143.Name = "Label143";
            this.Label143.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.Label143.Text = "INSURANCE CEASE AT AND FROM THE HOUR AND DATE MENTIONED ABOVE.";
            this.Label143.Top = 3.6875F;
            this.Label143.Width = 7.125F;
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
            this.Label144.Left = 0.375F;
            this.Label144.Name = "Label144";
            this.Label144.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.Label144.Text = "YOE ARE HEREBY NOTIFIED THAT THE AGREEMENT UNDER LOSS PAYABLE CLAUSE PAYABLE TO Y" +
                "OU AS LIENHOLDER, WICH IS";
            this.Label144.Top = 3.9375F;
            this.Label144.Width = 7.125F;
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
            this.Label145.Left = 0.375F;
            this.Label145.Name = "Label145";
            this.Label145.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.Label145.Text = "A PART OF THE ABOVE POLICY,INSSUED TO THE ABOVE INSURED,IS HEREBY CANCELLED IN AC" +
                "CORDANCE WITH THE CONDITIONS";
            this.Label145.Top = 4.0625F;
            this.Label145.Width = 7.3125F;
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
            this.Label146.Left = 0.375F;
            this.Label146.Name = "Label146";
            this.Label146.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.Label146.Text = "OF THE POLICY, SAID CANCELLATION TO BE EFECTIVE ON AND AFTER THE HOUR AND DATE ME" +
                "NTIONED ABOVE.";
            this.Label146.Top = 4.1875F;
            this.Label146.Width = 6.25F;
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
            this.Label147.Left = 0.375F;
            this.Label147.Name = "Label147";
            this.Label147.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.Label147.Text = "REASON FOR THE CANCELLATION";
            this.Label147.Top = 4.4375F;
            this.Label147.Width = 1.9375F;
            // 
            // TxtReasonCancellation
            // 
            this.TxtReasonCancellation.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtReasonCancellation.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReasonCancellation.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtReasonCancellation.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReasonCancellation.Border.RightColor = System.Drawing.Color.Black;
            this.TxtReasonCancellation.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReasonCancellation.Border.TopColor = System.Drawing.Color.Black;
            this.TxtReasonCancellation.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReasonCancellation.Height = 0.2F;
            this.TxtReasonCancellation.Left = 2.3125F;
            this.TxtReasonCancellation.MultiLine = false;
            this.TxtReasonCancellation.Name = "TxtReasonCancellation";
            this.TxtReasonCancellation.OutputFormat = resources.GetString("TxtReasonCancellation.OutputFormat");
            this.TxtReasonCancellation.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtReasonCancellation.Text = null;
            this.TxtReasonCancellation.Top = 4.4375F;
            this.TxtReasonCancellation.Width = 1.75F;
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
            this.Label148.Left = 0.375F;
            this.Label148.Name = "Label148";
            this.Label148.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.Label148.Text = "FOR INFORMATION OR QUESTIONS REGARDING THIS NOTICE PLEASE CALL BALDRICH & ASSOCIA" +
                "TES, INC. (787) 622-4000.";
            this.Label148.Top = 4.6875F;
            this.Label148.Width = 6.75F;
            // 
            // TxtTakeEffective
            // 
            this.TxtTakeEffective.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtTakeEffective.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTakeEffective.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtTakeEffective.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTakeEffective.Border.RightColor = System.Drawing.Color.Black;
            this.TxtTakeEffective.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTakeEffective.Border.TopColor = System.Drawing.Color.Black;
            this.TxtTakeEffective.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTakeEffective.Height = 0.2F;
            this.TxtTakeEffective.Left = 1.5625F;
            this.TxtTakeEffective.MultiLine = false;
            this.TxtTakeEffective.Name = "TxtTakeEffective";
            this.TxtTakeEffective.OutputFormat = resources.GetString("TxtTakeEffective.OutputFormat");
            this.TxtTakeEffective.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtTakeEffective.Text = null;
            this.TxtTakeEffective.Top = 1.875F;
            this.TxtTakeEffective.Width = 1.5625F;
            // 
            // TxtCancellationTo
            // 
            this.TxtCancellationTo.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCancellationTo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancellationTo.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCancellationTo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancellationTo.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCancellationTo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancellationTo.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCancellationTo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancellationTo.Height = 0.2F;
            this.TxtCancellationTo.Left = 1.5625F;
            this.TxtCancellationTo.MultiLine = false;
            this.TxtCancellationTo.Name = "TxtCancellationTo";
            this.TxtCancellationTo.OutputFormat = resources.GetString("TxtCancellationTo.OutputFormat");
            this.TxtCancellationTo.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtCancellationTo.Text = "12:01  AM";
            this.TxtCancellationTo.Top = 1.6875F;
            this.TxtCancellationTo.Width = 1.5625F;
            // 
            // TxtCertificate
            // 
            this.TxtCertificate.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCertificate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCertificate.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCertificate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCertificate.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCertificate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCertificate.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCertificate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCertificate.Height = 0.2F;
            this.TxtCertificate.Left = 6F;
            this.TxtCertificate.MultiLine = false;
            this.TxtCertificate.Name = "TxtCertificate";
            this.TxtCertificate.OutputFormat = resources.GetString("TxtCertificate.OutputFormat");
            this.TxtCertificate.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtCertificate.Text = null;
            this.TxtCertificate.Top = 1.875F;
            this.TxtCertificate.Width = 1.5625F;
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
            this.TxtPolicyNumber.Left = 6F;
            this.TxtPolicyNumber.MultiLine = false;
            this.TxtPolicyNumber.Name = "TxtPolicyNumber";
            this.TxtPolicyNumber.OutputFormat = resources.GetString("TxtPolicyNumber.OutputFormat");
            this.TxtPolicyNumber.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtPolicyNumber.Text = null;
            this.TxtPolicyNumber.Top = 1.6875F;
            this.TxtPolicyNumber.Width = 1.5625F;
            // 
            // Line223
            // 
            this.Line223.Border.BottomColor = System.Drawing.Color.Black;
            this.Line223.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line223.Border.LeftColor = System.Drawing.Color.Black;
            this.Line223.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line223.Border.RightColor = System.Drawing.Color.Black;
            this.Line223.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line223.Border.TopColor = System.Drawing.Color.Black;
            this.Line223.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line223.Height = 0.3125F;
            this.Line223.Left = 3.1875F;
            this.Line223.LineWeight = 1F;
            this.Line223.Name = "Line223";
            this.Line223.Top = 5.125F;
            this.Line223.Width = 0F;
            this.Line223.X1 = 3.1875F;
            this.Line223.X2 = 3.1875F;
            this.Line223.Y1 = 5.4375F;
            this.Line223.Y2 = 5.125F;
            // 
            // Line224
            // 
            this.Line224.Border.BottomColor = System.Drawing.Color.Black;
            this.Line224.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line224.Border.LeftColor = System.Drawing.Color.Black;
            this.Line224.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line224.Border.RightColor = System.Drawing.Color.Black;
            this.Line224.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line224.Border.TopColor = System.Drawing.Color.Black;
            this.Line224.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line224.Height = 0.3125F;
            this.Line224.Left = 0.3125F;
            this.Line224.LineWeight = 1F;
            this.Line224.Name = "Line224";
            this.Line224.Top = 5.125F;
            this.Line224.Width = 0F;
            this.Line224.X1 = 0.3125F;
            this.Line224.X2 = 0.3125F;
            this.Line224.Y1 = 5.4375F;
            this.Line224.Y2 = 5.125F;
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
            this.Label149.Left = 0.375F;
            this.Label149.Name = "Label149";
            this.Label149.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label149.Text = "EFFECTIVE DATE";
            this.Label149.Top = 5.1875F;
            this.Label149.Width = 1.0625F;
            // 
            // Line225
            // 
            this.Line225.Border.BottomColor = System.Drawing.Color.Black;
            this.Line225.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line225.Border.LeftColor = System.Drawing.Color.Black;
            this.Line225.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line225.Border.RightColor = System.Drawing.Color.Black;
            this.Line225.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line225.Border.TopColor = System.Drawing.Color.Black;
            this.Line225.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line225.Height = 0.3125F;
            this.Line225.Left = 1.5F;
            this.Line225.LineWeight = 1F;
            this.Line225.Name = "Line225";
            this.Line225.Top = 5.125F;
            this.Line225.Width = 0F;
            this.Line225.X1 = 1.5F;
            this.Line225.X2 = 1.5F;
            this.Line225.Y1 = 5.4375F;
            this.Line225.Y2 = 5.125F;
            // 
            // Line226
            // 
            this.Line226.Border.BottomColor = System.Drawing.Color.Black;
            this.Line226.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line226.Border.LeftColor = System.Drawing.Color.Black;
            this.Line226.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line226.Border.RightColor = System.Drawing.Color.Black;
            this.Line226.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line226.Border.TopColor = System.Drawing.Color.Black;
            this.Line226.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line226.Height = 0F;
            this.Line226.Left = 0.3125F;
            this.Line226.LineWeight = 1F;
            this.Line226.Name = "Line226";
            this.Line226.Top = 5.4375F;
            this.Line226.Width = 2.875F;
            this.Line226.X1 = 0.3125F;
            this.Line226.X2 = 3.1875F;
            this.Line226.Y1 = 5.4375F;
            this.Line226.Y2 = 5.4375F;
            // 
            // Line227
            // 
            this.Line227.Border.BottomColor = System.Drawing.Color.Black;
            this.Line227.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line227.Border.LeftColor = System.Drawing.Color.Black;
            this.Line227.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line227.Border.RightColor = System.Drawing.Color.Black;
            this.Line227.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line227.Border.TopColor = System.Drawing.Color.Black;
            this.Line227.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line227.Height = 0F;
            this.Line227.Left = 0.3125F;
            this.Line227.LineWeight = 1F;
            this.Line227.Name = "Line227";
            this.Line227.Top = 5.125F;
            this.Line227.Width = 2.875F;
            this.Line227.X1 = 0.3125F;
            this.Line227.X2 = 3.1875F;
            this.Line227.Y1 = 5.125F;
            this.Line227.Y2 = 5.125F;
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
            this.TxtEffectiveDate.Left = 1.5625F;
            this.TxtEffectiveDate.MultiLine = false;
            this.TxtEffectiveDate.Name = "TxtEffectiveDate";
            this.TxtEffectiveDate.OutputFormat = resources.GetString("TxtEffectiveDate.OutputFormat");
            this.TxtEffectiveDate.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtEffectiveDate.Text = null;
            this.TxtEffectiveDate.Top = 5.1875F;
            this.TxtEffectiveDate.Width = 1.5625F;
            // 
            // Line228
            // 
            this.Line228.Border.BottomColor = System.Drawing.Color.Black;
            this.Line228.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line228.Border.LeftColor = System.Drawing.Color.Black;
            this.Line228.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line228.Border.RightColor = System.Drawing.Color.Black;
            this.Line228.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line228.Border.TopColor = System.Drawing.Color.Black;
            this.Line228.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line228.Height = 0.3125F;
            this.Line228.Left = 7.625F;
            this.Line228.LineWeight = 1F;
            this.Line228.Name = "Line228";
            this.Line228.Top = 5.125F;
            this.Line228.Width = 0F;
            this.Line228.X1 = 7.625F;
            this.Line228.X2 = 7.625F;
            this.Line228.Y1 = 5.4375F;
            this.Line228.Y2 = 5.125F;
            // 
            // Line229
            // 
            this.Line229.Border.BottomColor = System.Drawing.Color.Black;
            this.Line229.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line229.Border.LeftColor = System.Drawing.Color.Black;
            this.Line229.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line229.Border.RightColor = System.Drawing.Color.Black;
            this.Line229.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line229.Border.TopColor = System.Drawing.Color.Black;
            this.Line229.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line229.Height = 0.3125F;
            this.Line229.Left = 4.75F;
            this.Line229.LineWeight = 1F;
            this.Line229.Name = "Line229";
            this.Line229.Top = 5.125F;
            this.Line229.Width = 0F;
            this.Line229.X1 = 4.75F;
            this.Line229.X2 = 4.75F;
            this.Line229.Y1 = 5.4375F;
            this.Line229.Y2 = 5.125F;
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
            this.Label150.Left = 4.8125F;
            this.Label150.Name = "Label150";
            this.Label150.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label150.Text = "EXPIRATION DATE";
            this.Label150.Top = 5.1875F;
            this.Label150.Width = 1.0625F;
            // 
            // Line230
            // 
            this.Line230.Border.BottomColor = System.Drawing.Color.Black;
            this.Line230.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line230.Border.LeftColor = System.Drawing.Color.Black;
            this.Line230.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line230.Border.RightColor = System.Drawing.Color.Black;
            this.Line230.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line230.Border.TopColor = System.Drawing.Color.Black;
            this.Line230.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line230.Height = 0.3125F;
            this.Line230.Left = 5.9375F;
            this.Line230.LineWeight = 1F;
            this.Line230.Name = "Line230";
            this.Line230.Top = 5.125F;
            this.Line230.Width = 0F;
            this.Line230.X1 = 5.9375F;
            this.Line230.X2 = 5.9375F;
            this.Line230.Y1 = 5.4375F;
            this.Line230.Y2 = 5.125F;
            // 
            // Line231
            // 
            this.Line231.Border.BottomColor = System.Drawing.Color.Black;
            this.Line231.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line231.Border.LeftColor = System.Drawing.Color.Black;
            this.Line231.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line231.Border.RightColor = System.Drawing.Color.Black;
            this.Line231.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line231.Border.TopColor = System.Drawing.Color.Black;
            this.Line231.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line231.Height = 0F;
            this.Line231.Left = 4.75F;
            this.Line231.LineWeight = 1F;
            this.Line231.Name = "Line231";
            this.Line231.Top = 5.4375F;
            this.Line231.Width = 2.875F;
            this.Line231.X1 = 4.75F;
            this.Line231.X2 = 7.625F;
            this.Line231.Y1 = 5.4375F;
            this.Line231.Y2 = 5.4375F;
            // 
            // Line232
            // 
            this.Line232.Border.BottomColor = System.Drawing.Color.Black;
            this.Line232.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line232.Border.LeftColor = System.Drawing.Color.Black;
            this.Line232.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line232.Border.RightColor = System.Drawing.Color.Black;
            this.Line232.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line232.Border.TopColor = System.Drawing.Color.Black;
            this.Line232.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line232.Height = 0F;
            this.Line232.Left = 4.75F;
            this.Line232.LineWeight = 1F;
            this.Line232.Name = "Line232";
            this.Line232.Top = 5.125F;
            this.Line232.Width = 2.875F;
            this.Line232.X1 = 4.75F;
            this.Line232.X2 = 7.625F;
            this.Line232.Y1 = 5.125F;
            this.Line232.Y2 = 5.125F;
            // 
            // TxtExpirationDate
            // 
            this.TxtExpirationDate.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtExpirationDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtExpirationDate.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtExpirationDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtExpirationDate.Border.RightColor = System.Drawing.Color.Black;
            this.TxtExpirationDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtExpirationDate.Border.TopColor = System.Drawing.Color.Black;
            this.TxtExpirationDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtExpirationDate.Height = 0.2F;
            this.TxtExpirationDate.Left = 6F;
            this.TxtExpirationDate.MultiLine = false;
            this.TxtExpirationDate.Name = "TxtExpirationDate";
            this.TxtExpirationDate.OutputFormat = resources.GetString("TxtExpirationDate.OutputFormat");
            this.TxtExpirationDate.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtExpirationDate.Text = null;
            this.TxtExpirationDate.Top = 5.1875F;
            this.TxtExpirationDate.Width = 1.5625F;
            // 
            // Line233
            // 
            this.Line233.Border.BottomColor = System.Drawing.Color.Black;
            this.Line233.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line233.Border.LeftColor = System.Drawing.Color.Black;
            this.Line233.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line233.Border.RightColor = System.Drawing.Color.Black;
            this.Line233.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line233.Border.TopColor = System.Drawing.Color.Black;
            this.Line233.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line233.Height = 0F;
            this.Line233.Left = 0.3125F;
            this.Line233.LineWeight = 1F;
            this.Line233.Name = "Line233";
            this.Line233.Top = 5.625F;
            this.Line233.Width = 7.3125F;
            this.Line233.X1 = 0.3125F;
            this.Line233.X2 = 7.625F;
            this.Line233.Y1 = 5.625F;
            this.Line233.Y2 = 5.625F;
            // 
            // Line235
            // 
            this.Line235.Border.BottomColor = System.Drawing.Color.Black;
            this.Line235.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line235.Border.LeftColor = System.Drawing.Color.Black;
            this.Line235.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line235.Border.RightColor = System.Drawing.Color.Black;
            this.Line235.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line235.Border.TopColor = System.Drawing.Color.Black;
            this.Line235.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line235.Height = 0.625F;
            this.Line235.Left = 0.3125F;
            this.Line235.LineWeight = 1F;
            this.Line235.Name = "Line235";
            this.Line235.Top = 5.625F;
            this.Line235.Width = 0F;
            this.Line235.X1 = 0.3125F;
            this.Line235.X2 = 0.3125F;
            this.Line235.Y1 = 6.25F;
            this.Line235.Y2 = 5.625F;
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
            this.Label151.Left = 1.0625F;
            this.Label151.Name = "Label151";
            this.Label151.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label151.Text = "COVERAGES";
            this.Label151.Top = 5.6875F;
            this.Label151.Width = 1.0625F;
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
            this.Label152.Left = 0.4375F;
            this.Label152.Name = "Label152";
            this.Label152.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label152.Text = "MECHANICAL BREAKDOWN";
            this.Label152.Top = 5.9375F;
            this.Label152.Width = 1.5625F;
            // 
            // Line236
            // 
            this.Line236.Border.BottomColor = System.Drawing.Color.Black;
            this.Line236.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line236.Border.LeftColor = System.Drawing.Color.Black;
            this.Line236.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line236.Border.RightColor = System.Drawing.Color.Black;
            this.Line236.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line236.Border.TopColor = System.Drawing.Color.Black;
            this.Line236.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line236.Height = 1F;
            this.Line236.Left = 3.1875F;
            this.Line236.LineWeight = 1F;
            this.Line236.Name = "Line236";
            this.Line236.Top = 5.625F;
            this.Line236.Width = 0F;
            this.Line236.X1 = 3.1875F;
            this.Line236.X2 = 3.1875F;
            this.Line236.Y1 = 6.625F;
            this.Line236.Y2 = 5.625F;
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
            this.Label153.Left = 3.375F;
            this.Label153.Name = "Label153";
            this.Label153.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label153.Text = "DEDUCIBLES";
            this.Label153.Top = 5.6875F;
            this.Label153.Width = 1.0625F;
            // 
            // Line237
            // 
            this.Line237.Border.BottomColor = System.Drawing.Color.Black;
            this.Line237.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line237.Border.LeftColor = System.Drawing.Color.Black;
            this.Line237.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line237.Border.RightColor = System.Drawing.Color.Black;
            this.Line237.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line237.Border.TopColor = System.Drawing.Color.Black;
            this.Line237.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line237.Height = 1F;
            this.Line237.Left = 4.625F;
            this.Line237.LineWeight = 1F;
            this.Line237.Name = "Line237";
            this.Line237.Top = 5.625F;
            this.Line237.Width = 0F;
            this.Line237.X1 = 4.625F;
            this.Line237.X2 = 4.625F;
            this.Line237.Y1 = 6.625F;
            this.Line237.Y2 = 5.625F;
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
            this.Label154.Left = 4.75F;
            this.Label154.Name = "Label154";
            this.Label154.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label154.Text = "ORIGINAL PREMIUM";
            this.Label154.Top = 5.6875F;
            this.Label154.Width = 1.1875F;
            // 
            // Line238
            // 
            this.Line238.Border.BottomColor = System.Drawing.Color.Black;
            this.Line238.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line238.Border.LeftColor = System.Drawing.Color.Black;
            this.Line238.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line238.Border.RightColor = System.Drawing.Color.Black;
            this.Line238.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line238.Border.TopColor = System.Drawing.Color.Black;
            this.Line238.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line238.Height = 1F;
            this.Line238.Left = 6.125F;
            this.Line238.LineWeight = 1F;
            this.Line238.Name = "Line238";
            this.Line238.Top = 5.625F;
            this.Line238.Width = 0F;
            this.Line238.X1 = 6.125F;
            this.Line238.X2 = 6.125F;
            this.Line238.Y1 = 6.625F;
            this.Line238.Y2 = 5.625F;
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
            this.Label155.Left = 6.1875F;
            this.Label155.Name = "Label155";
            this.Label155.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label155.Text = "RETURN PREMIUM";
            this.Label155.Top = 5.6875F;
            this.Label155.Width = 1.1875F;
            // 
            // Line239
            // 
            this.Line239.Border.BottomColor = System.Drawing.Color.Black;
            this.Line239.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line239.Border.LeftColor = System.Drawing.Color.Black;
            this.Line239.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line239.Border.RightColor = System.Drawing.Color.Black;
            this.Line239.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line239.Border.TopColor = System.Drawing.Color.Black;
            this.Line239.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line239.Height = 1F;
            this.Line239.Left = 7.625F;
            this.Line239.LineWeight = 1F;
            this.Line239.Name = "Line239";
            this.Line239.Top = 5.625F;
            this.Line239.Width = 0F;
            this.Line239.X1 = 7.625F;
            this.Line239.X2 = 7.625F;
            this.Line239.Y1 = 6.625F;
            this.Line239.Y2 = 5.625F;
            // 
            // Line234
            // 
            this.Line234.Border.BottomColor = System.Drawing.Color.Black;
            this.Line234.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line234.Border.LeftColor = System.Drawing.Color.Black;
            this.Line234.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line234.Border.RightColor = System.Drawing.Color.Black;
            this.Line234.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line234.Border.TopColor = System.Drawing.Color.Black;
            this.Line234.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line234.Height = 0F;
            this.Line234.Left = 0.3125F;
            this.Line234.LineWeight = 1F;
            this.Line234.Name = "Line234";
            this.Line234.Top = 5.875F;
            this.Line234.Width = 7.3125F;
            this.Line234.X1 = 0.3125F;
            this.Line234.X2 = 7.625F;
            this.Line234.Y1 = 5.875F;
            this.Line234.Y2 = 5.875F;
            // 
            // Line240
            // 
            this.Line240.Border.BottomColor = System.Drawing.Color.Black;
            this.Line240.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line240.Border.LeftColor = System.Drawing.Color.Black;
            this.Line240.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line240.Border.RightColor = System.Drawing.Color.Black;
            this.Line240.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line240.Border.TopColor = System.Drawing.Color.Black;
            this.Line240.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line240.Height = 0F;
            this.Line240.Left = 0.3125F;
            this.Line240.LineWeight = 1F;
            this.Line240.Name = "Line240";
            this.Line240.Top = 6.25F;
            this.Line240.Width = 7.3125F;
            this.Line240.X1 = 0.3125F;
            this.Line240.X2 = 7.625F;
            this.Line240.Y1 = 6.25F;
            this.Line240.Y2 = 6.25F;
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
            this.Label156.Left = 3.375F;
            this.Label156.Name = "Label156";
            this.Label156.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label156.Text = "TOTAL";
            this.Label156.Top = 6.3125F;
            this.Label156.Width = 1.0625F;
            // 
            // TxtTotalPremium1
            // 
            this.TxtTotalPremium1.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtTotalPremium1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotalPremium1.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtTotalPremium1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotalPremium1.Border.RightColor = System.Drawing.Color.Black;
            this.TxtTotalPremium1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotalPremium1.Border.TopColor = System.Drawing.Color.Black;
            this.TxtTotalPremium1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotalPremium1.Height = 0.2F;
            this.TxtTotalPremium1.Left = 4.8125F;
            this.TxtTotalPremium1.MultiLine = false;
            this.TxtTotalPremium1.Name = "TxtTotalPremium1";
            this.TxtTotalPremium1.OutputFormat = resources.GetString("TxtTotalPremium1.OutputFormat");
            this.TxtTotalPremium1.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.TxtTotalPremium1.Text = null;
            this.TxtTotalPremium1.Top = 6.3125F;
            this.TxtTotalPremium1.Width = 1F;
            // 
            // TxtReturnPremium1
            // 
            this.TxtReturnPremium1.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtReturnPremium1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReturnPremium1.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtReturnPremium1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReturnPremium1.Border.RightColor = System.Drawing.Color.Black;
            this.TxtReturnPremium1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReturnPremium1.Border.TopColor = System.Drawing.Color.Black;
            this.TxtReturnPremium1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReturnPremium1.Height = 0.2F;
            this.TxtReturnPremium1.Left = 6.3125F;
            this.TxtReturnPremium1.MultiLine = false;
            this.TxtReturnPremium1.Name = "TxtReturnPremium1";
            this.TxtReturnPremium1.OutputFormat = resources.GetString("TxtReturnPremium1.OutputFormat");
            this.TxtReturnPremium1.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.TxtReturnPremium1.Text = null;
            this.TxtReturnPremium1.Top = 6.3125F;
            this.TxtReturnPremium1.Width = 1F;
            // 
            // TxtReturnPremium
            // 
            this.TxtReturnPremium.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtReturnPremium.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReturnPremium.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtReturnPremium.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReturnPremium.Border.RightColor = System.Drawing.Color.Black;
            this.TxtReturnPremium.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReturnPremium.Border.TopColor = System.Drawing.Color.Black;
            this.TxtReturnPremium.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReturnPremium.Height = 0.2F;
            this.TxtReturnPremium.Left = 6.3125F;
            this.TxtReturnPremium.MultiLine = false;
            this.TxtReturnPremium.Name = "TxtReturnPremium";
            this.TxtReturnPremium.OutputFormat = resources.GetString("TxtReturnPremium.OutputFormat");
            this.TxtReturnPremium.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.TxtReturnPremium.Text = null;
            this.TxtReturnPremium.Top = 5.9375F;
            this.TxtReturnPremium.Width = 1F;
            // 
            // TxtTotalPremium
            // 
            this.TxtTotalPremium.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtTotalPremium.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotalPremium.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtTotalPremium.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotalPremium.Border.RightColor = System.Drawing.Color.Black;
            this.TxtTotalPremium.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotalPremium.Border.TopColor = System.Drawing.Color.Black;
            this.TxtTotalPremium.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotalPremium.Height = 0.2F;
            this.TxtTotalPremium.Left = 4.8125F;
            this.TxtTotalPremium.MultiLine = false;
            this.TxtTotalPremium.Name = "TxtTotalPremium";
            this.TxtTotalPremium.OutputFormat = resources.GetString("TxtTotalPremium.OutputFormat");
            this.TxtTotalPremium.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.TxtTotalPremium.Text = null;
            this.TxtTotalPremium.Top = 5.9375F;
            this.TxtTotalPremium.Width = 1F;
            // 
            // Line241
            // 
            this.Line241.Border.BottomColor = System.Drawing.Color.Black;
            this.Line241.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line241.Border.LeftColor = System.Drawing.Color.Black;
            this.Line241.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line241.Border.RightColor = System.Drawing.Color.Black;
            this.Line241.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line241.Border.TopColor = System.Drawing.Color.Black;
            this.Line241.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line241.Height = 0F;
            this.Line241.Left = 3.1875F;
            this.Line241.LineWeight = 1F;
            this.Line241.Name = "Line241";
            this.Line241.Top = 6.625F;
            this.Line241.Width = 4.4375F;
            this.Line241.X1 = 3.1875F;
            this.Line241.X2 = 7.625F;
            this.Line241.Y1 = 6.625F;
            this.Line241.Y2 = 6.625F;
            // 
            // Line242
            // 
            this.Line242.Border.BottomColor = System.Drawing.Color.Black;
            this.Line242.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line242.Border.LeftColor = System.Drawing.Color.Black;
            this.Line242.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line242.Border.RightColor = System.Drawing.Color.Black;
            this.Line242.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line242.Border.TopColor = System.Drawing.Color.Black;
            this.Line242.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line242.Height = 0F;
            this.Line242.Left = 0.6875F;
            this.Line242.LineWeight = 1F;
            this.Line242.Name = "Line242";
            this.Line242.Top = 6.75F;
            this.Line242.Width = 6.3125F;
            this.Line242.X1 = 0.6875F;
            this.Line242.X2 = 7F;
            this.Line242.Y1 = 6.75F;
            this.Line242.Y2 = 6.75F;
            // 
            // Line244
            // 
            this.Line244.Border.BottomColor = System.Drawing.Color.Black;
            this.Line244.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line244.Border.LeftColor = System.Drawing.Color.Black;
            this.Line244.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line244.Border.RightColor = System.Drawing.Color.Black;
            this.Line244.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line244.Border.TopColor = System.Drawing.Color.Black;
            this.Line244.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line244.Height = 0.25F;
            this.Line244.Left = 0.6875F;
            this.Line244.LineWeight = 1F;
            this.Line244.Name = "Line244";
            this.Line244.Top = 6.75F;
            this.Line244.Width = 0F;
            this.Line244.X1 = 0.6875F;
            this.Line244.X2 = 0.6875F;
            this.Line244.Y1 = 7F;
            this.Line244.Y2 = 6.75F;
            // 
            // Line245
            // 
            this.Line245.Border.BottomColor = System.Drawing.Color.Black;
            this.Line245.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line245.Border.LeftColor = System.Drawing.Color.Black;
            this.Line245.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line245.Border.RightColor = System.Drawing.Color.Black;
            this.Line245.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line245.Border.TopColor = System.Drawing.Color.Black;
            this.Line245.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line245.Height = 0.25F;
            this.Line245.Left = 7F;
            this.Line245.LineWeight = 1F;
            this.Line245.Name = "Line245";
            this.Line245.Top = 6.75F;
            this.Line245.Width = 0F;
            this.Line245.X1 = 7F;
            this.Line245.X2 = 7F;
            this.Line245.Y1 = 7F;
            this.Line245.Y2 = 6.75F;
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
            this.Label157.Left = 0.75F;
            this.Label157.Name = "Label157";
            this.Label157.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label157.Text = "COUNTERSIGNATURE";
            this.Label157.Top = 6.8125F;
            this.Label157.Width = 1.5625F;
            // 
            // Line246
            // 
            this.Line246.Border.BottomColor = System.Drawing.Color.Black;
            this.Line246.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line246.Border.LeftColor = System.Drawing.Color.Black;
            this.Line246.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line246.Border.RightColor = System.Drawing.Color.Black;
            this.Line246.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line246.Border.TopColor = System.Drawing.Color.Black;
            this.Line246.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line246.Height = 0.25F;
            this.Line246.Left = 2.4375F;
            this.Line246.LineWeight = 1F;
            this.Line246.Name = "Line246";
            this.Line246.Top = 6.75F;
            this.Line246.Width = 0F;
            this.Line246.X1 = 2.4375F;
            this.Line246.X2 = 2.4375F;
            this.Line246.Y1 = 7F;
            this.Line246.Y2 = 6.75F;
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
            this.TxtDate.Left = 2.6875F;
            this.TxtDate.MultiLine = false;
            this.TxtDate.Name = "TxtDate";
            this.TxtDate.OutputFormat = resources.GetString("TxtDate.OutputFormat");
            this.TxtDate.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.TxtDate.Text = null;
            this.TxtDate.Top = 6.8125F;
            this.TxtDate.Width = 1.4375F;
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
            this.Label158.Left = 4.3125F;
            this.Label158.Name = "Label158";
            this.Label158.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label158.Text = "ISSUED AT SAN JUAN,PUERTO RICO";
            this.Label158.Top = 6.8125F;
            this.Label158.Width = 2.3125F;
            // 
            // Line243
            // 
            this.Line243.Border.BottomColor = System.Drawing.Color.Black;
            this.Line243.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line243.Border.LeftColor = System.Drawing.Color.Black;
            this.Line243.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line243.Border.RightColor = System.Drawing.Color.Black;
            this.Line243.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line243.Border.TopColor = System.Drawing.Color.Black;
            this.Line243.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line243.Height = 0F;
            this.Line243.Left = 0.6875F;
            this.Line243.LineWeight = 1F;
            this.Line243.Name = "Line243";
            this.Line243.Top = 7F;
            this.Line243.Width = 6.3125F;
            this.Line243.X1 = 0.6875F;
            this.Line243.X2 = 7F;
            this.Line243.Y1 = 7F;
            this.Line243.Y2 = 7F;
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
            this.Label159.Left = 0.4375F;
            this.Label159.Name = "Label159";
            this.Label159.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label159.Text = "COMPANY";
            this.Label159.Top = 7.125F;
            this.Label159.Width = 0.625F;
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
            this.Label160.Left = 0.4375F;
            this.Label160.Name = "Label160";
            this.Label160.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label160.Text = "AGENCY";
            this.Label160.Top = 7.25F;
            this.Label160.Width = 0.625F;
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
            this.Label161.Left = 0.4375F;
            this.Label161.Name = "Label161";
            this.Label161.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label161.Text = "CUSTOMER";
            this.Label161.Top = 7.375F;
            this.Label161.Width = 0.6875F;
            // 
            // Line248
            // 
            this.Line248.Border.BottomColor = System.Drawing.Color.Black;
            this.Line248.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line248.Border.LeftColor = System.Drawing.Color.Black;
            this.Line248.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line248.Border.RightColor = System.Drawing.Color.Black;
            this.Line248.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line248.Border.TopColor = System.Drawing.Color.Black;
            this.Line248.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line248.Height = 0.4375F;
            this.Line248.Left = 1.125F;
            this.Line248.LineWeight = 1F;
            this.Line248.Name = "Line248";
            this.Line248.Top = 7.125F;
            this.Line248.Width = 0F;
            this.Line248.X1 = 1.125F;
            this.Line248.X2 = 1.125F;
            this.Line248.Y1 = 7.5625F;
            this.Line248.Y2 = 7.125F;
            // 
            // Line249
            // 
            this.Line249.Border.BottomColor = System.Drawing.Color.Black;
            this.Line249.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line249.Border.LeftColor = System.Drawing.Color.Black;
            this.Line249.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line249.Border.RightColor = System.Drawing.Color.Black;
            this.Line249.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line249.Border.TopColor = System.Drawing.Color.Black;
            this.Line249.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line249.Height = 0.4375F;
            this.Line249.Left = 0.3125F;
            this.Line249.LineWeight = 1F;
            this.Line249.Name = "Line249";
            this.Line249.Top = 7.125F;
            this.Line249.Width = 0F;
            this.Line249.X1 = 0.3125F;
            this.Line249.X2 = 0.3125F;
            this.Line249.Y1 = 7.5625F;
            this.Line249.Y2 = 7.125F;
            // 
            // TxtInsuranceCompany
            // 
            this.TxtInsuranceCompany.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtInsuranceCompany.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtInsuranceCompany.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtInsuranceCompany.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtInsuranceCompany.Border.RightColor = System.Drawing.Color.Black;
            this.TxtInsuranceCompany.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtInsuranceCompany.Border.TopColor = System.Drawing.Color.Black;
            this.TxtInsuranceCompany.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtInsuranceCompany.Height = 0.1999998F;
            this.TxtInsuranceCompany.Left = 1.1875F;
            this.TxtInsuranceCompany.MultiLine = false;
            this.TxtInsuranceCompany.Name = "TxtInsuranceCompany";
            this.TxtInsuranceCompany.OutputFormat = resources.GetString("TxtInsuranceCompany.OutputFormat");
            this.TxtInsuranceCompany.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtInsuranceCompany.Text = null;
            this.TxtInsuranceCompany.Top = 7.125F;
            this.TxtInsuranceCompany.Width = 1.875F;
            // 
            // Line247
            // 
            this.Line247.Border.BottomColor = System.Drawing.Color.Black;
            this.Line247.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line247.Border.LeftColor = System.Drawing.Color.Black;
            this.Line247.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line247.Border.RightColor = System.Drawing.Color.Black;
            this.Line247.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line247.Border.TopColor = System.Drawing.Color.Black;
            this.Line247.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line247.Height = 0F;
            this.Line247.Left = 0.3125F;
            this.Line247.LineWeight = 1F;
            this.Line247.Name = "Line247";
            this.Line247.Top = 7.125F;
            this.Line247.Width = 2.75F;
            this.Line247.X1 = 0.3125F;
            this.Line247.X2 = 3.0625F;
            this.Line247.Y1 = 7.125F;
            this.Line247.Y2 = 7.125F;
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
            this.TxtAgency.Height = 0.1999998F;
            this.TxtAgency.Left = 1.1875F;
            this.TxtAgency.MultiLine = false;
            this.TxtAgency.Name = "TxtAgency";
            this.TxtAgency.OutputFormat = resources.GetString("TxtAgency.OutputFormat");
            this.TxtAgency.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtAgency.Text = null;
            this.TxtAgency.Top = 7.25F;
            this.TxtAgency.Width = 1.875F;
            // 
            // TxtCustomer
            // 
            this.TxtCustomer.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCustomer.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomer.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCustomer.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomer.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCustomer.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomer.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCustomer.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomer.Height = 0.1999998F;
            this.TxtCustomer.Left = 1.1875F;
            this.TxtCustomer.MultiLine = false;
            this.TxtCustomer.Name = "TxtCustomer";
            this.TxtCustomer.OutputFormat = resources.GetString("TxtCustomer.OutputFormat");
            this.TxtCustomer.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtCustomer.Text = null;
            this.TxtCustomer.Top = 7.375F;
            this.TxtCustomer.Width = 1.875F;
            // 
            // Line250
            // 
            this.Line250.Border.BottomColor = System.Drawing.Color.Black;
            this.Line250.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line250.Border.LeftColor = System.Drawing.Color.Black;
            this.Line250.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line250.Border.RightColor = System.Drawing.Color.Black;
            this.Line250.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line250.Border.TopColor = System.Drawing.Color.Black;
            this.Line250.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line250.Height = 0F;
            this.Line250.Left = 0.3125F;
            this.Line250.LineWeight = 1F;
            this.Line250.Name = "Line250";
            this.Line250.Top = 7.5625F;
            this.Line250.Width = 2.75F;
            this.Line250.X1 = 0.3125F;
            this.Line250.X2 = 3.0625F;
            this.Line250.Y1 = 7.5625F;
            this.Line250.Y2 = 7.5625F;
            // 
            // Line251
            // 
            this.Line251.Border.BottomColor = System.Drawing.Color.Black;
            this.Line251.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line251.Border.LeftColor = System.Drawing.Color.Black;
            this.Line251.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line251.Border.RightColor = System.Drawing.Color.Black;
            this.Line251.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line251.Border.TopColor = System.Drawing.Color.Black;
            this.Line251.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line251.Height = 0.4375F;
            this.Line251.Left = 3.0625F;
            this.Line251.LineWeight = 1F;
            this.Line251.Name = "Line251";
            this.Line251.Top = 7.125F;
            this.Line251.Width = 0F;
            this.Line251.X1 = 3.0625F;
            this.Line251.X2 = 3.0625F;
            this.Line251.Y1 = 7.5625F;
            this.Line251.Y2 = 7.125F;
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
            this.Label162.Left = 5F;
            this.Label162.Name = "Label162";
            this.Label162.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label162.Text = "AGENT";
            this.Label162.Top = 7.125F;
            this.Label162.Width = 0.625F;
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
            this.Label163.Left = 5F;
            this.Label163.Name = "Label163";
            this.Label163.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label163.Text = "DEALER";
            this.Label163.Top = 7.25F;
            this.Label163.Width = 0.625F;
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
            this.Label164.Left = 5F;
            this.Label164.Name = "Label164";
            this.Label164.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label164.Text = "SOC.SEC.";
            this.Label164.Top = 7.375F;
            this.Label164.Width = 0.6875F;
            // 
            // Line252
            // 
            this.Line252.Border.BottomColor = System.Drawing.Color.Black;
            this.Line252.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line252.Border.LeftColor = System.Drawing.Color.Black;
            this.Line252.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line252.Border.RightColor = System.Drawing.Color.Black;
            this.Line252.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line252.Border.TopColor = System.Drawing.Color.Black;
            this.Line252.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line252.Height = 0.4375F;
            this.Line252.Left = 5.6875F;
            this.Line252.LineWeight = 1F;
            this.Line252.Name = "Line252";
            this.Line252.Top = 7.125F;
            this.Line252.Width = 0F;
            this.Line252.X1 = 5.6875F;
            this.Line252.X2 = 5.6875F;
            this.Line252.Y1 = 7.5625F;
            this.Line252.Y2 = 7.125F;
            // 
            // Line253
            // 
            this.Line253.Border.BottomColor = System.Drawing.Color.Black;
            this.Line253.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line253.Border.LeftColor = System.Drawing.Color.Black;
            this.Line253.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line253.Border.RightColor = System.Drawing.Color.Black;
            this.Line253.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line253.Border.TopColor = System.Drawing.Color.Black;
            this.Line253.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line253.Height = 0.4375F;
            this.Line253.Left = 4.875F;
            this.Line253.LineWeight = 1F;
            this.Line253.Name = "Line253";
            this.Line253.Top = 7.125F;
            this.Line253.Width = 0F;
            this.Line253.X1 = 4.875F;
            this.Line253.X2 = 4.875F;
            this.Line253.Y1 = 7.5625F;
            this.Line253.Y2 = 7.125F;
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
            this.TxtAgent.Left = 5.75F;
            this.TxtAgent.MultiLine = false;
            this.TxtAgent.Name = "TxtAgent";
            this.TxtAgent.OutputFormat = resources.GetString("TxtAgent.OutputFormat");
            this.TxtAgent.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtAgent.Text = null;
            this.TxtAgent.Top = 7.125F;
            this.TxtAgent.Width = 1.875F;
            // 
            // Line254
            // 
            this.Line254.Border.BottomColor = System.Drawing.Color.Black;
            this.Line254.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line254.Border.LeftColor = System.Drawing.Color.Black;
            this.Line254.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line254.Border.RightColor = System.Drawing.Color.Black;
            this.Line254.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line254.Border.TopColor = System.Drawing.Color.Black;
            this.Line254.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line254.Height = 0F;
            this.Line254.Left = 4.875F;
            this.Line254.LineWeight = 1F;
            this.Line254.Name = "Line254";
            this.Line254.Top = 7.125F;
            this.Line254.Width = 2.75F;
            this.Line254.X1 = 4.875F;
            this.Line254.X2 = 7.625F;
            this.Line254.Y1 = 7.125F;
            this.Line254.Y2 = 7.125F;
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
            this.TxtDealer.Left = 5.75F;
            this.TxtDealer.MultiLine = false;
            this.TxtDealer.Name = "TxtDealer";
            this.TxtDealer.OutputFormat = resources.GetString("TxtDealer.OutputFormat");
            this.TxtDealer.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtDealer.Text = null;
            this.TxtDealer.Top = 7.25F;
            this.TxtDealer.Width = 1.875F;
            // 
            // TxtSocSec
            // 
            this.TxtSocSec.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtSocSec.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSocSec.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtSocSec.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSocSec.Border.RightColor = System.Drawing.Color.Black;
            this.TxtSocSec.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSocSec.Border.TopColor = System.Drawing.Color.Black;
            this.TxtSocSec.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSocSec.Height = 0.2F;
            this.TxtSocSec.Left = 5.75F;
            this.TxtSocSec.MultiLine = false;
            this.TxtSocSec.Name = "TxtSocSec";
            this.TxtSocSec.OutputFormat = resources.GetString("TxtSocSec.OutputFormat");
            this.TxtSocSec.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtSocSec.Text = null;
            this.TxtSocSec.Top = 7.375F;
            this.TxtSocSec.Width = 1.875F;
            // 
            // Line255
            // 
            this.Line255.Border.BottomColor = System.Drawing.Color.Black;
            this.Line255.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line255.Border.LeftColor = System.Drawing.Color.Black;
            this.Line255.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line255.Border.RightColor = System.Drawing.Color.Black;
            this.Line255.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line255.Border.TopColor = System.Drawing.Color.Black;
            this.Line255.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line255.Height = 0F;
            this.Line255.Left = 4.875F;
            this.Line255.LineWeight = 1F;
            this.Line255.Name = "Line255";
            this.Line255.Top = 7.5625F;
            this.Line255.Width = 2.75F;
            this.Line255.X1 = 4.875F;
            this.Line255.X2 = 7.625F;
            this.Line255.Y1 = 7.5625F;
            this.Line255.Y2 = 7.5625F;
            // 
            // Line256
            // 
            this.Line256.Border.BottomColor = System.Drawing.Color.Black;
            this.Line256.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line256.Border.LeftColor = System.Drawing.Color.Black;
            this.Line256.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line256.Border.RightColor = System.Drawing.Color.Black;
            this.Line256.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line256.Border.TopColor = System.Drawing.Color.Black;
            this.Line256.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line256.Height = 0.4375F;
            this.Line256.Left = 7.625F;
            this.Line256.LineWeight = 1F;
            this.Line256.Name = "Line256";
            this.Line256.Top = 7.125F;
            this.Line256.Width = 0F;
            this.Line256.X1 = 7.625F;
            this.Line256.X2 = 7.625F;
            this.Line256.Y1 = 7.5625F;
            this.Line256.Y2 = 7.125F;
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
            this.Label165.Left = 5F;
            this.Label165.Name = "Label165";
            this.Label165.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label165.Text = "RETURN PREMIUM";
            this.Label165.Top = 7.6875F;
            this.Label165.Width = 1.3125F;
            // 
            // lblOwed
            // 
            this.lblOwed.Border.BottomColor = System.Drawing.Color.Black;
            this.lblOwed.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblOwed.Border.LeftColor = System.Drawing.Color.Black;
            this.lblOwed.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblOwed.Border.RightColor = System.Drawing.Color.Black;
            this.lblOwed.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblOwed.Border.TopColor = System.Drawing.Color.Black;
            this.lblOwed.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblOwed.Height = 0.1875F;
            this.lblOwed.HyperLink = "";
            this.lblOwed.Left = 5F;
            this.lblOwed.Name = "lblOwed";
            this.lblOwed.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.lblOwed.Text = "OWED BY CUSTOMER";
            this.lblOwed.Top = 7.8125F;
            this.lblOwed.Width = 1.3125F;
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
            this.Label167.Left = 5F;
            this.Label167.Name = "Label167";
            this.Label167.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label167.Text = "RETURN PREMIUM";
            this.Label167.Top = 7.9375F;
            this.Label167.Width = 1.3125F;
            // 
            // Line257
            // 
            this.Line257.Border.BottomColor = System.Drawing.Color.Black;
            this.Line257.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line257.Border.LeftColor = System.Drawing.Color.Black;
            this.Line257.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line257.Border.RightColor = System.Drawing.Color.Black;
            this.Line257.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line257.Border.TopColor = System.Drawing.Color.Black;
            this.Line257.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line257.Height = 0.4375F;
            this.Line257.Left = 6.375F;
            this.Line257.LineWeight = 1F;
            this.Line257.Name = "Line257";
            this.Line257.Top = 7.6875F;
            this.Line257.Width = 0F;
            this.Line257.X1 = 6.375F;
            this.Line257.X2 = 6.375F;
            this.Line257.Y1 = 8.125F;
            this.Line257.Y2 = 7.6875F;
            // 
            // Line258
            // 
            this.Line258.Border.BottomColor = System.Drawing.Color.Black;
            this.Line258.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line258.Border.LeftColor = System.Drawing.Color.Black;
            this.Line258.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line258.Border.RightColor = System.Drawing.Color.Black;
            this.Line258.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line258.Border.TopColor = System.Drawing.Color.Black;
            this.Line258.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line258.Height = 0.4375F;
            this.Line258.Left = 4.875F;
            this.Line258.LineWeight = 1F;
            this.Line258.Name = "Line258";
            this.Line258.Top = 7.6875F;
            this.Line258.Width = 0F;
            this.Line258.X1 = 4.875F;
            this.Line258.X2 = 4.875F;
            this.Line258.Y1 = 8.125F;
            this.Line258.Y2 = 7.6875F;
            // 
            // TxtReturnCancellation
            // 
            this.TxtReturnCancellation.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtReturnCancellation.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReturnCancellation.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtReturnCancellation.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReturnCancellation.Border.RightColor = System.Drawing.Color.Black;
            this.TxtReturnCancellation.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReturnCancellation.Border.TopColor = System.Drawing.Color.Black;
            this.TxtReturnCancellation.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReturnCancellation.Height = 0.2F;
            this.TxtReturnCancellation.Left = 6.4375F;
            this.TxtReturnCancellation.MultiLine = false;
            this.TxtReturnCancellation.Name = "TxtReturnCancellation";
            this.TxtReturnCancellation.OutputFormat = resources.GetString("TxtReturnCancellation.OutputFormat");
            this.TxtReturnCancellation.Style = "text-align: right; font-weight: normal; font-size: 8pt; ";
            this.TxtReturnCancellation.Text = null;
            this.TxtReturnCancellation.Top = 7.6875F;
            this.TxtReturnCancellation.Width = 1.0625F;
            // 
            // Line259
            // 
            this.Line259.Border.BottomColor = System.Drawing.Color.Black;
            this.Line259.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line259.Border.LeftColor = System.Drawing.Color.Black;
            this.Line259.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line259.Border.RightColor = System.Drawing.Color.Black;
            this.Line259.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line259.Border.TopColor = System.Drawing.Color.Black;
            this.Line259.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line259.Height = 0F;
            this.Line259.Left = 4.875F;
            this.Line259.LineWeight = 1F;
            this.Line259.Name = "Line259";
            this.Line259.Top = 7.6875F;
            this.Line259.Width = 2.75F;
            this.Line259.X1 = 4.875F;
            this.Line259.X2 = 7.625F;
            this.Line259.Y1 = 7.6875F;
            this.Line259.Y2 = 7.6875F;
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
            this.TxtOwed.Left = 6.4375F;
            this.TxtOwed.MultiLine = false;
            this.TxtOwed.Name = "TxtOwed";
            this.TxtOwed.OutputFormat = resources.GetString("TxtOwed.OutputFormat");
            this.TxtOwed.Style = "text-align: right; font-weight: normal; font-size: 8pt; ";
            this.TxtOwed.Text = null;
            this.TxtOwed.Top = 7.8125F;
            this.TxtOwed.Width = 1.0625F;
            // 
            // TxtReturn
            // 
            this.TxtReturn.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtReturn.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReturn.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtReturn.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReturn.Border.RightColor = System.Drawing.Color.Black;
            this.TxtReturn.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReturn.Border.TopColor = System.Drawing.Color.Black;
            this.TxtReturn.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtReturn.Height = 0.2F;
            this.TxtReturn.Left = 6.4375F;
            this.TxtReturn.MultiLine = false;
            this.TxtReturn.Name = "TxtReturn";
            this.TxtReturn.OutputFormat = resources.GetString("TxtReturn.OutputFormat");
            this.TxtReturn.Style = "text-align: right; font-weight: normal; font-size: 8pt; ";
            this.TxtReturn.Text = null;
            this.TxtReturn.Top = 7.9375F;
            this.TxtReturn.Width = 1.0625F;
            // 
            // Line260
            // 
            this.Line260.Border.BottomColor = System.Drawing.Color.Black;
            this.Line260.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line260.Border.LeftColor = System.Drawing.Color.Black;
            this.Line260.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line260.Border.RightColor = System.Drawing.Color.Black;
            this.Line260.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line260.Border.TopColor = System.Drawing.Color.Black;
            this.Line260.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line260.Height = 0F;
            this.Line260.Left = 4.875F;
            this.Line260.LineWeight = 1F;
            this.Line260.Name = "Line260";
            this.Line260.Top = 8.125F;
            this.Line260.Width = 2.75F;
            this.Line260.X1 = 4.875F;
            this.Line260.X2 = 7.625F;
            this.Line260.Y1 = 8.125F;
            this.Line260.Y2 = 8.125F;
            // 
            // Line261
            // 
            this.Line261.Border.BottomColor = System.Drawing.Color.Black;
            this.Line261.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line261.Border.LeftColor = System.Drawing.Color.Black;
            this.Line261.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line261.Border.RightColor = System.Drawing.Color.Black;
            this.Line261.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line261.Border.TopColor = System.Drawing.Color.Black;
            this.Line261.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line261.Height = 0.4375F;
            this.Line261.Left = 7.625F;
            this.Line261.LineWeight = 1F;
            this.Line261.Name = "Line261";
            this.Line261.Top = 7.6875F;
            this.Line261.Width = 0F;
            this.Line261.X1 = 7.625F;
            this.Line261.X2 = 7.625F;
            this.Line261.Y1 = 8.125F;
            this.Line261.Y2 = 7.6875F;
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
            this.Label168.Left = 0.4375F;
            this.Label168.Name = "Label168";
            this.Label168.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label168.Text = "AMOUNT PAID";
            this.Label168.Top = 7.6875F;
            this.Label168.Width = 0.9375F;
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
            this.Label169.Left = 0.4375F;
            this.Label169.Name = "Label169";
            this.Label169.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label169.Text = "LOAN NUMBER";
            this.Label169.Top = 7.8125F;
            this.Label169.Width = 0.9375F;
            // 
            // Line262
            // 
            this.Line262.Border.BottomColor = System.Drawing.Color.Black;
            this.Line262.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line262.Border.LeftColor = System.Drawing.Color.Black;
            this.Line262.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line262.Border.RightColor = System.Drawing.Color.Black;
            this.Line262.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line262.Border.TopColor = System.Drawing.Color.Black;
            this.Line262.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line262.Height = 0.3125F;
            this.Line262.Left = 1.625F;
            this.Line262.LineWeight = 1F;
            this.Line262.Name = "Line262";
            this.Line262.Top = 7.6875F;
            this.Line262.Width = 0F;
            this.Line262.X1 = 1.625F;
            this.Line262.X2 = 1.625F;
            this.Line262.Y1 = 8F;
            this.Line262.Y2 = 7.6875F;
            // 
            // Line263
            // 
            this.Line263.Border.BottomColor = System.Drawing.Color.Black;
            this.Line263.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line263.Border.LeftColor = System.Drawing.Color.Black;
            this.Line263.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line263.Border.RightColor = System.Drawing.Color.Black;
            this.Line263.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line263.Border.TopColor = System.Drawing.Color.Black;
            this.Line263.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line263.Height = 0.3125F;
            this.Line263.Left = 0.3125F;
            this.Line263.LineWeight = 1F;
            this.Line263.Name = "Line263";
            this.Line263.Top = 7.6875F;
            this.Line263.Width = 0F;
            this.Line263.X1 = 0.3125F;
            this.Line263.X2 = 0.3125F;
            this.Line263.Y1 = 8F;
            this.Line263.Y2 = 7.6875F;
            // 
            // TxtAmountPaid
            // 
            this.TxtAmountPaid.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtAmountPaid.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAmountPaid.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtAmountPaid.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAmountPaid.Border.RightColor = System.Drawing.Color.Black;
            this.TxtAmountPaid.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAmountPaid.Border.TopColor = System.Drawing.Color.Black;
            this.TxtAmountPaid.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAmountPaid.Height = 0.1999998F;
            this.TxtAmountPaid.Left = 1.6875F;
            this.TxtAmountPaid.MultiLine = false;
            this.TxtAmountPaid.Name = "TxtAmountPaid";
            this.TxtAmountPaid.OutputFormat = resources.GetString("TxtAmountPaid.OutputFormat");
            this.TxtAmountPaid.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtAmountPaid.Text = null;
            this.TxtAmountPaid.Top = 7.6875F;
            this.TxtAmountPaid.Width = 1.25F;
            // 
            // Line264
            // 
            this.Line264.Border.BottomColor = System.Drawing.Color.Black;
            this.Line264.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line264.Border.LeftColor = System.Drawing.Color.Black;
            this.Line264.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line264.Border.RightColor = System.Drawing.Color.Black;
            this.Line264.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line264.Border.TopColor = System.Drawing.Color.Black;
            this.Line264.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line264.Height = 0F;
            this.Line264.Left = 0.3125F;
            this.Line264.LineWeight = 1F;
            this.Line264.Name = "Line264";
            this.Line264.Top = 7.6875F;
            this.Line264.Width = 2.75F;
            this.Line264.X1 = 0.3125F;
            this.Line264.X2 = 3.0625F;
            this.Line264.Y1 = 7.6875F;
            this.Line264.Y2 = 7.6875F;
            // 
            // TxtLoan
            // 
            this.TxtLoan.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtLoan.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLoan.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtLoan.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLoan.Border.RightColor = System.Drawing.Color.Black;
            this.TxtLoan.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLoan.Border.TopColor = System.Drawing.Color.Black;
            this.TxtLoan.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLoan.Height = 0.1999998F;
            this.TxtLoan.Left = 1.6875F;
            this.TxtLoan.MultiLine = false;
            this.TxtLoan.Name = "TxtLoan";
            this.TxtLoan.OutputFormat = resources.GetString("TxtLoan.OutputFormat");
            this.TxtLoan.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtLoan.Text = null;
            this.TxtLoan.Top = 7.8125F;
            this.TxtLoan.Width = 1.25F;
            // 
            // Line266
            // 
            this.Line266.Border.BottomColor = System.Drawing.Color.Black;
            this.Line266.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line266.Border.LeftColor = System.Drawing.Color.Black;
            this.Line266.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line266.Border.RightColor = System.Drawing.Color.Black;
            this.Line266.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line266.Border.TopColor = System.Drawing.Color.Black;
            this.Line266.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line266.Height = 0.3125F;
            this.Line266.Left = 3.0625F;
            this.Line266.LineWeight = 1F;
            this.Line266.Name = "Line266";
            this.Line266.Top = 7.6875F;
            this.Line266.Width = 0F;
            this.Line266.X1 = 3.0625F;
            this.Line266.X2 = 3.0625F;
            this.Line266.Y1 = 8F;
            this.Line266.Y2 = 7.6875F;
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
            this.Label170.Left = 0.375F;
            this.Label170.Name = "Label170";
            this.Label170.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label170.Text = "BY:";
            this.Label170.Top = 8.125F;
            this.Label170.Width = 0.25F;
            // 
            // TxtEnteredBy
            // 
            this.TxtEnteredBy.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtEnteredBy.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEnteredBy.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtEnteredBy.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEnteredBy.Border.RightColor = System.Drawing.Color.Black;
            this.TxtEnteredBy.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEnteredBy.Border.TopColor = System.Drawing.Color.Black;
            this.TxtEnteredBy.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEnteredBy.Height = 0.1999998F;
            this.TxtEnteredBy.Left = 0.625F;
            this.TxtEnteredBy.MultiLine = false;
            this.TxtEnteredBy.Name = "TxtEnteredBy";
            this.TxtEnteredBy.OutputFormat = resources.GetString("TxtEnteredBy.OutputFormat");
            this.TxtEnteredBy.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtEnteredBy.Text = null;
            this.TxtEnteredBy.Top = 8.125F;
            this.TxtEnteredBy.Width = 1.25F;
            // 
            // Line265
            // 
            this.Line265.Border.BottomColor = System.Drawing.Color.Black;
            this.Line265.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line265.Border.LeftColor = System.Drawing.Color.Black;
            this.Line265.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line265.Border.RightColor = System.Drawing.Color.Black;
            this.Line265.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line265.Border.TopColor = System.Drawing.Color.Black;
            this.Line265.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line265.Height = 0F;
            this.Line265.Left = 0.3125F;
            this.Line265.LineWeight = 1F;
            this.Line265.Name = "Line265";
            this.Line265.Top = 8F;
            this.Line265.Width = 2.75F;
            this.Line265.X1 = 0.3125F;
            this.Line265.X2 = 3.0625F;
            this.Line265.Y1 = 8F;
            this.Line265.Y2 = 8F;
            // 
            // TxtDeductibles
            // 
            this.TxtDeductibles.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtDeductibles.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDeductibles.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtDeductibles.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDeductibles.Border.RightColor = System.Drawing.Color.Black;
            this.TxtDeductibles.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDeductibles.Border.TopColor = System.Drawing.Color.Black;
            this.TxtDeductibles.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDeductibles.Height = 0.2F;
            this.TxtDeductibles.Left = 3.4375F;
            this.TxtDeductibles.MultiLine = false;
            this.TxtDeductibles.Name = "TxtDeductibles";
            this.TxtDeductibles.OutputFormat = resources.GetString("TxtDeductibles.OutputFormat");
            this.TxtDeductibles.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.TxtDeductibles.Text = null;
            this.TxtDeductibles.Top = 5.9375F;
            this.TxtDeductibles.Width = 1F;
            // 
            // TxtCancellationMethod
            // 
            this.TxtCancellationMethod.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCancellationMethod.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancellationMethod.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCancellationMethod.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancellationMethod.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCancellationMethod.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancellationMethod.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCancellationMethod.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCancellationMethod.Height = 0.2F;
            this.TxtCancellationMethod.Left = 4.0625F;
            this.TxtCancellationMethod.MultiLine = false;
            this.TxtCancellationMethod.Name = "TxtCancellationMethod";
            this.TxtCancellationMethod.OutputFormat = resources.GetString("TxtCancellationMethod.OutputFormat");
            this.TxtCancellationMethod.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtCancellationMethod.Text = null;
            this.TxtCancellationMethod.Top = 4.4375F;
            this.TxtCancellationMethod.Width = 1.75F;
            // 
            // lblOverPayment
            // 
            this.lblOverPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.lblOverPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblOverPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.lblOverPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblOverPayment.Border.RightColor = System.Drawing.Color.Black;
            this.lblOverPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblOverPayment.Border.TopColor = System.Drawing.Color.Black;
            this.lblOverPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblOverPayment.Height = 0.1875F;
            this.lblOverPayment.HyperLink = "";
            this.lblOverPayment.Left = 5F;
            this.lblOverPayment.Name = "lblOverPayment";
            this.lblOverPayment.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.lblOverPayment.Text = "OVER PAYMENT";
            this.lblOverPayment.Top = 7.8125F;
            this.lblOverPayment.Width = 1.3125F;
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
            this.Label75.Left = 1.421875F;
            this.Label75.MultiLine = false;
            this.Label75.Name = "Label75";
            this.Label75.Style = "text-align: center; font-weight: bold; font-size: 11.25pt; font-family: Times New" +
                " Roman; ";
            this.Label75.Text = "PUERTO RICO MEDICAL DEFENSE INSURANCE COMPANY";
            this.Label75.Top = 0.625F;
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
            this.Label77.Left = 1.421875F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-align: center; font-weight: bold; font-size: 6pt; font-family: Times New Rom" +
                "an; ";
            this.Label77.Text = "";
            this.Label77.Top = 0.875F;
            this.Label77.Width = 5.125F;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            // 
            // CancellationCredit
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.1F;
            this.PageSettings.Margins.Left = 0.2F;
            this.PageSettings.Margins.Right = 0.1F;
            this.PageSettings.Margins.Top = 0.2F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.020833F;
            this.Sections.Add(this.ReportHeader);
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.PageFooter);
            this.Sections.Add(this.ReportFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.CancellationCredit_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.lblCancellation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label78)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label138)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label139)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label122)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerAddr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerAddr2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label140)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label141)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAddr2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAddr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label120)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label142)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label143)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label144)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label145)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label146)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label147)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtReasonCancellation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label148)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTakeEffective)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCancellationTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCertificate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPolicyNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label149)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEffectiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label150)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtExpirationDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label151)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label152)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label153)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label154)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label155)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label156)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotalPremium1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtReturnPremium1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtReturnPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotalPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label157)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label158)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label159)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label160)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label161)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtInsuranceCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAgency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label162)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label163)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label164)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAgent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDealer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSocSec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label165)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOwed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label167)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtReturnCancellation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOwed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label168)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label169)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAmountPaid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label170)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEnteredBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDeductibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCancellationMethod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOverPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
