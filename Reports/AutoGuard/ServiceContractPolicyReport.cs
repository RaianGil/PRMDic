using System;
using System.Data;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
//using EPolicy.ClientManager;
//using EPolicy.PolicyManager;
using EPolicy.Customer;
using EPolicy.LookupTables;
using EPolicy.TaskControl;

namespace EPolicy2.Reports
{
	public class ServiceContractPolicyReport : DataDynamics.ActiveReports.ActiveReport3
	{
		private int CountDataIndex;
		private string _CopyValue;
		private EPolicy.TaskControl.AutoGuardServicesContract _taskcontrol;

		public ServiceContractPolicyReport(EPolicy.TaskControl.AutoGuardServicesContract taskcontrol,string CopyValue)
		{	
			_taskcontrol = taskcontrol;
			_CopyValue = CopyValue;
			InitializeComponent();
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{

		}

		private void Detail_Format(object sender, System.EventArgs eArgs)
		{

		} 

		private void ServiceContractPolicyReport_FetchData(object sender, DataDynamics.ActiveReports.ActiveReport3.FetchEventArgs eArgs)
		{
			try
			{
				if (this.CountDataIndex ==0)
				{
					TxtpolicyNo.Text = _taskcontrol.PolicyType.ToString().ToUpper().Trim()+" "+_taskcontrol.PolicyNo.ToString().Trim()+" "+_taskcontrol.Certificate.ToString().Trim()+" "+ _taskcontrol.Suffix.Trim();
					
					//Seller
					TxtSellerName.Text    = _taskcontrol.SellerName.ToString();
					TxtSellerAddress.Text = _taskcontrol.SellerAddress1.Trim()+" "+ _taskcontrol.SellerAddress2.Trim();
					TxtSellerCity.Text    = _taskcontrol.SellerCity.ToString().Trim().ToUpper();
					TxtSellerState.Text	  = _taskcontrol.SellerState.ToString().Trim().ToUpper();
					TxtSellerZip.Text	  = _taskcontrol.SellerZipCode.ToString().Trim();
					
					EPolicy.LookupTables.InsuranceCompany insurancecompany = new InsuranceCompany();
					insurancecompany = insurancecompany.GetInsuranceCompany(_taskcontrol.InsuranceCompany);
					LblCompany.Text       = insurancecompany.InsuranceCompanyDesc.ToString();

					if(_taskcontrol.InsuranceCompany == "099")
					{
						//Picture4.Visible = true;
						LblAutoGuard.Visible = true;
						//lblMbi.Visible   = false;
						LblMechanical.Visible = false;
					}
					else
					{
						if(_taskcontrol.InsuranceCompany == "097")//Federal Warranty
						{
							//Picture4.Visible = false;
							LblAutoGuard.Visible = false;
							//lblMbi.Visible   = true;
							LblMechanical.Visible = true;
							Label1.Text = "Información Del Tenedor Del Contrato";
							Label2.Text = "Prima y Comisión";
							LblMechanical.Text = "Mechanical Breakdown Information";
							//Label6.Visible = false;
							Label7.Visible = false;
							Label8.Visible = false;
							//Picture2.Visible = false;
							//Label75.Visible = false;
							//Label35.Visible = false;
							//Picture5.Visible = false;
							//Label79.Visible = false;
							Label80.Visible = false;
							Label81.Visible = false;
							//Label88.Visible = true;
						}
						else //
						{
							//Picture4.Visible     = false;
							LblAutoGuard.Visible = false;
							//lblMbi.Visible       = true;						
							LblMechanical.Visible = true;
						}
					}


					//Customer and Postal Address
					TxtCustomerName.Text = _taskcontrol.Customer.FirstName.Trim() +" "+_taskcontrol.Customer.Initial.Trim()+" "+
						_taskcontrol.Customer.LastName1.Trim()+ " "+_taskcontrol.Customer.LastName2.Trim();
				
				
					TxtCustomerAddress.Text = _taskcontrol.Customer.Address1.Trim().ToUpper();
					if(_taskcontrol.Customer.Address2.Trim().ToUpper() == "")
					{
						TxtCustomerCity.Text  = _taskcontrol.Customer.City.Trim().ToUpper();
						TxtCustomerState.Text = _taskcontrol.Customer.State.ToString().Trim().ToUpper();
						TxtCustomerZip.Text   = _taskcontrol.Customer.ZipCode.Trim().ToUpper();
						TxtCustomerCity.Text  = _taskcontrol.Customer.City.ToString().Trim().ToUpper(); 
					}
					else
					{
						TxtCustomerAddress.Text = _taskcontrol.Customer.Address2.Trim().ToUpper();
						TxtCustomerCity.Text    = _taskcontrol.Customer.City.Trim().ToUpper();
						TxtCustomerState.Text   = _taskcontrol.Customer.State.Trim().ToUpper();
						TxtCustomerZip.Text     = _taskcontrol.Customer.ZipCode.Trim().ToUpper();

					}
 
				
					//Bank
					EPolicy.LookupTables.Bank bank = new Bank();
					bank = bank.GetBank(_taskcontrol.Bank);
					//			bank = bank.GetBank(_policy.Bank);

					TxtBankName.Text = bank.BankDesc.Trim().ToUpper();
								
		
					if (bank.Address1 != "")
					{								
						TxtBankAddress1.Text = bank.Address1.Trim().ToUpper();	
						if(bank.Address2.Trim().ToUpper() == "")
						{
							TxtBankAddress2.Text = bank.City.Trim().ToUpper()+" "+
								bank.State.Trim().ToUpper()+" "+
								bank.ZipCode.Trim().ToUpper();
							TxtBankCity.Text = "";
							TxtBankPhone.Text = bank.Phone.ToString().Trim();
						}
						else
						{
							TxtBankAddress2.Text = bank.Address2.Trim().ToUpper();
							TxtBankCity.Text  = bank.City.Trim().ToUpper()+" "+
								bank.State.Trim().ToUpper()+" "+
								bank.ZipCode.Trim().ToUpper();
						}
					}
					
					TxtYear.Text   = _taskcontrol.Year.ToString();
					TxtMake.Text   = _taskcontrol.Make.ToString().ToUpper();
					TxtModel.Text  = _taskcontrol.Model.ToString().ToUpper();
					TxtVinNo.Text  = _taskcontrol.Vin.ToString().ToUpper();
					TxtVehicleCost.Text   = _taskcontrol.VehicleCost.ToString("$#,##0.00");
					TxtpurchaseDate.Text  = _taskcontrol.PurchaserDate.ToString();
					Txtodometer.Text      = _taskcontrol.Odometer.ToString();
					TxteffectiveDate.Text = _taskcontrol.EffectiveDate.ToString();
					TxtTerm.Text          = _taskcontrol.Term.ToString();
					TxtMileage.Text       = _taskcontrol.Mileage.ToString();
					TxtDeductible.Text    = _taskcontrol.Deductible.ToString();
					TxtClasification.Text = _taskcontrol.VehicleClass;
					TxtTotalPremium.Text   = _taskcontrol.TotalPremium.ToString("$#,##0.00");
					Txtmileage2.Text       = _taskcontrol.Mileage.ToString();
					TxtEffectiveDate2.Text = _taskcontrol.EffectiveDate.ToString();
					TxtExpirationDate.Text = _taskcontrol.ExpirationDate.ToString();
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
		}

	
		private void ServiceContractPolicyReport_DataInitialize(object sender, System.EventArgs eArgs)
		{
			TxtpolicyNo.Text        = "";
			TxtSellerName.Text      = "";
			TxtSellerAddress.Text   = "";
			TxtSellerCity.Text      = "";
			TxtSellerState.Text	    = "";
			TxtSellerZip.Text	    = "";
			TxtBankAddress1.Text    = "";
			TxtBankAddress2.Text    = "";
			TxtBankCity.Text        = "";
			TxtBankPhone.Text       = "";
			TxtCustomerCity.Text    = "";
			TxtCustomerState.Text   = "";
			TxtCustomerZip.Text     = "";
			TxtCustomerCity.Text    = "";
			TxtCustomerAddress.Text = "";
			TxtYear.Text            = "";
			TxtMake.Text            = "";
			TxtModel.Text           = "";
			TxtVinNo.Text           = "";
			TxtVehicleCost.Text     = "";
			TxtpurchaseDate.Text    = "";
			Txtodometer.Text        = "";
			TxteffectiveDate.Text   = "";
			TxtTerm.Text            = "";
			TxtMileage.Text         = "";
			TxtDeductible.Text      = "";
			TxtClasification.Text   = "";
			TxtTotalPremium.Text    = "";
			Txtmileage2.Text        = "";
			TxtEffectiveDate2.Text  = "";
			TxtExpirationDate.Text  = "";
			CountDataIndex          = 0;
		}

		#region ActiveReports Designer generated code
		private PageHeader PageHeader = null;
		private Label Label1 = null;
		private Label Label2 = null;
		private Label Label3 = null;
		private Label Label4 = null;
		private Label LblAutoGuard = null;
		private Label Label7 = null;
		private Label Label8 = null;
		private TextBox TxtpolicyNo = null;
		private Label LblMechanical = null;
		private Detail Detail = null;
		private Shape Shape5 = null;
		private Shape Shape9 = null;
		private Label LblCompany = null;
		private Label Label10 = null;
		private Label Label11 = null;
		private Label Label14 = null;
		private Label Label15 = null;
		private Line Line1 = null;
		private Line Line3 = null;
		private Line Line4 = null;
		private Label Label16 = null;
		private Label Label17 = null;
		private Label Label18 = null;
		private Shape Shape10 = null;
		private Label Label20 = null;
		private Label Label21 = null;
		private Line Line5 = null;
		private Line Line6 = null;
		private Line Line7 = null;
		private Line Line8 = null;
		private Label Label22 = null;
		private Label Label23 = null;
		private Label Label24 = null;
		private Label Label25 = null;
		private Shape Shape11 = null;
		private Label Label26 = null;
		private Label Label27 = null;
		private Line Line9 = null;
		private Line Line10 = null;
		private Line Line11 = null;
		private Line Line12 = null;
		private Label Label28 = null;
		private Label Label29 = null;
		private Label Label30 = null;
		private Label Label31 = null;
		private Label Label32 = null;
		private Line Line13 = null;
		private Line Line14 = null;
		private Label Label33 = null;
		private Label Label34 = null;
		private Label Label36 = null;
		private Line Line17 = null;
		private Label Label37 = null;
		private Line Line18 = null;
		private Label Label38 = null;
		private Label Label39 = null;
		private Label Label40 = null;
		private Label Label41 = null;
		private Label Label42 = null;
		private Label Label43 = null;
		private Label Label44 = null;
		private Label Label45 = null;
		private Shape Shape13 = null;
		private Line Line19 = null;
		private Line Line20 = null;
		private Label Label46 = null;
		private Label Label47 = null;
		private Label Label48 = null;
		private Label Label49 = null;
		private Label Label50 = null;
		private Label Label51 = null;
		private Shape Shape14 = null;
		private Label Label52 = null;
		private Label Label53 = null;
		private Line Line21 = null;
		private Label Label54 = null;
		private Label Label55 = null;
		private Label Label56 = null;
		private Line Line22 = null;
		private Line Line23 = null;
		private Label Label57 = null;
		private Label Label58 = null;
		private Label Label59 = null;
		private Shape Shape16 = null;
		private Label Label60 = null;
		private Label Label61 = null;
		private Label Label62 = null;
		private Label Label63 = null;
		private Label Label64 = null;
		private Label Label65 = null;
		private Label Label66 = null;
		private Label Label67 = null;
		private Label Label68 = null;
		private Label Label69 = null;
		private Label Label70 = null;
		private Label Label71 = null;
		private Label Label72 = null;
		private Label Label73 = null;
		private Label Label74 = null;
		private Label Label77 = null;
		private Label Label78 = null;
		private Line Line24 = null;
		private Line Line25 = null;
		private Label Label80 = null;
		private Label Label81 = null;
		private Label Label83 = null;
		private Label Label82 = null;
		private Label Label84 = null;
		private Label Label85 = null;
		private TextBox TxtSellerName = null;
		private TextBox TxtSellerAddress = null;
		private TextBox TxtSellerCity = null;
		private TextBox TxtSellerState = null;
		private TextBox TxtSellerZip = null;
		private TextBox TxtCustomerCity = null;
		private TextBox TxtCustomerState = null;
		private TextBox TxtCustomerZip = null;
		private TextBox TxtCustomerName = null;
		private TextBox TxtCustomerAddress = null;
		private TextBox TxtYear = null;
		private TextBox TxtMake = null;
		private TextBox TxtModel = null;
		private TextBox TxtVinNo = null;
		private TextBox TxtVehicleCost = null;
		private TextBox TxtpurchaseDate = null;
		private TextBox TxteffectiveDate = null;
		private TextBox Txtodometer = null;
		private Label Label86 = null;
		private TextBox TxtTerm = null;
		private TextBox TxtMileage = null;
		private TextBox TxtDeductible = null;
		private TextBox TxtClasification = null;
		private TextBox TxtTotalPremium = null;
		private TextBox TxtBankName = null;
		private TextBox TxtBankPhone = null;
		private TextBox TxtBankAddress1 = null;
		private TextBox TxtBankAddress2 = null;
		private TextBox TxtBankCity = null;
		private TextBox TxtEffectiveDate2 = null;
		private TextBox TxtExpirationDate = null;
		private TextBox Txtmileage2 = null;
		private Label Label87 = null;
		private Line Line26 = null;
		private Line Line2 = null;
		private Shape Shape12 = null;
		private Label Label = null;
		private Shape Shape1 = null;
		private PageFooter PageFooter = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceContractPolicyReport));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.LblAutoGuard = new DataDynamics.ActiveReports.Label();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.Label8 = new DataDynamics.ActiveReports.Label();
            this.TxtpolicyNo = new DataDynamics.ActiveReports.TextBox();
            this.LblMechanical = new DataDynamics.ActiveReports.Label();
            this.Shape5 = new DataDynamics.ActiveReports.Shape();
            this.Shape9 = new DataDynamics.ActiveReports.Shape();
            this.LblCompany = new DataDynamics.ActiveReports.Label();
            this.Label10 = new DataDynamics.ActiveReports.Label();
            this.Label11 = new DataDynamics.ActiveReports.Label();
            this.Label14 = new DataDynamics.ActiveReports.Label();
            this.Label15 = new DataDynamics.ActiveReports.Label();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Line3 = new DataDynamics.ActiveReports.Line();
            this.Line4 = new DataDynamics.ActiveReports.Line();
            this.Label16 = new DataDynamics.ActiveReports.Label();
            this.Label17 = new DataDynamics.ActiveReports.Label();
            this.Label18 = new DataDynamics.ActiveReports.Label();
            this.Shape10 = new DataDynamics.ActiveReports.Shape();
            this.Label20 = new DataDynamics.ActiveReports.Label();
            this.Label21 = new DataDynamics.ActiveReports.Label();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.Line6 = new DataDynamics.ActiveReports.Line();
            this.Line7 = new DataDynamics.ActiveReports.Line();
            this.Line8 = new DataDynamics.ActiveReports.Line();
            this.Label22 = new DataDynamics.ActiveReports.Label();
            this.Label23 = new DataDynamics.ActiveReports.Label();
            this.Label24 = new DataDynamics.ActiveReports.Label();
            this.Label25 = new DataDynamics.ActiveReports.Label();
            this.Shape11 = new DataDynamics.ActiveReports.Shape();
            this.Label26 = new DataDynamics.ActiveReports.Label();
            this.Label27 = new DataDynamics.ActiveReports.Label();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.Line10 = new DataDynamics.ActiveReports.Line();
            this.Line11 = new DataDynamics.ActiveReports.Line();
            this.Line12 = new DataDynamics.ActiveReports.Line();
            this.Label28 = new DataDynamics.ActiveReports.Label();
            this.Label29 = new DataDynamics.ActiveReports.Label();
            this.Label30 = new DataDynamics.ActiveReports.Label();
            this.Label31 = new DataDynamics.ActiveReports.Label();
            this.Label32 = new DataDynamics.ActiveReports.Label();
            this.Line13 = new DataDynamics.ActiveReports.Line();
            this.Line14 = new DataDynamics.ActiveReports.Line();
            this.Label33 = new DataDynamics.ActiveReports.Label();
            this.Label34 = new DataDynamics.ActiveReports.Label();
            this.Label36 = new DataDynamics.ActiveReports.Label();
            this.Line17 = new DataDynamics.ActiveReports.Line();
            this.Label37 = new DataDynamics.ActiveReports.Label();
            this.Line18 = new DataDynamics.ActiveReports.Line();
            this.Label38 = new DataDynamics.ActiveReports.Label();
            this.Label39 = new DataDynamics.ActiveReports.Label();
            this.Label40 = new DataDynamics.ActiveReports.Label();
            this.Label41 = new DataDynamics.ActiveReports.Label();
            this.Label42 = new DataDynamics.ActiveReports.Label();
            this.Label43 = new DataDynamics.ActiveReports.Label();
            this.Label44 = new DataDynamics.ActiveReports.Label();
            this.Label45 = new DataDynamics.ActiveReports.Label();
            this.Shape13 = new DataDynamics.ActiveReports.Shape();
            this.Line19 = new DataDynamics.ActiveReports.Line();
            this.Line20 = new DataDynamics.ActiveReports.Line();
            this.Label46 = new DataDynamics.ActiveReports.Label();
            this.Label47 = new DataDynamics.ActiveReports.Label();
            this.Label48 = new DataDynamics.ActiveReports.Label();
            this.Label49 = new DataDynamics.ActiveReports.Label();
            this.Label50 = new DataDynamics.ActiveReports.Label();
            this.Label51 = new DataDynamics.ActiveReports.Label();
            this.Shape14 = new DataDynamics.ActiveReports.Shape();
            this.Label52 = new DataDynamics.ActiveReports.Label();
            this.Label53 = new DataDynamics.ActiveReports.Label();
            this.Line21 = new DataDynamics.ActiveReports.Line();
            this.Label54 = new DataDynamics.ActiveReports.Label();
            this.Label55 = new DataDynamics.ActiveReports.Label();
            this.Label56 = new DataDynamics.ActiveReports.Label();
            this.Line22 = new DataDynamics.ActiveReports.Line();
            this.Line23 = new DataDynamics.ActiveReports.Line();
            this.Label57 = new DataDynamics.ActiveReports.Label();
            this.Label58 = new DataDynamics.ActiveReports.Label();
            this.Label59 = new DataDynamics.ActiveReports.Label();
            this.Shape16 = new DataDynamics.ActiveReports.Shape();
            this.Label60 = new DataDynamics.ActiveReports.Label();
            this.Label61 = new DataDynamics.ActiveReports.Label();
            this.Label62 = new DataDynamics.ActiveReports.Label();
            this.Label63 = new DataDynamics.ActiveReports.Label();
            this.Label64 = new DataDynamics.ActiveReports.Label();
            this.Label65 = new DataDynamics.ActiveReports.Label();
            this.Label66 = new DataDynamics.ActiveReports.Label();
            this.Label67 = new DataDynamics.ActiveReports.Label();
            this.Label68 = new DataDynamics.ActiveReports.Label();
            this.Label69 = new DataDynamics.ActiveReports.Label();
            this.Label70 = new DataDynamics.ActiveReports.Label();
            this.Label71 = new DataDynamics.ActiveReports.Label();
            this.Label72 = new DataDynamics.ActiveReports.Label();
            this.Label73 = new DataDynamics.ActiveReports.Label();
            this.Label74 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.Label78 = new DataDynamics.ActiveReports.Label();
            this.Line24 = new DataDynamics.ActiveReports.Line();
            this.Line25 = new DataDynamics.ActiveReports.Line();
            this.Label80 = new DataDynamics.ActiveReports.Label();
            this.Label81 = new DataDynamics.ActiveReports.Label();
            this.Label83 = new DataDynamics.ActiveReports.Label();
            this.Label82 = new DataDynamics.ActiveReports.Label();
            this.Label84 = new DataDynamics.ActiveReports.Label();
            this.Label85 = new DataDynamics.ActiveReports.Label();
            this.TxtSellerName = new DataDynamics.ActiveReports.TextBox();
            this.TxtSellerAddress = new DataDynamics.ActiveReports.TextBox();
            this.TxtSellerCity = new DataDynamics.ActiveReports.TextBox();
            this.TxtSellerState = new DataDynamics.ActiveReports.TextBox();
            this.TxtSellerZip = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerCity = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerState = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerZip = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerName = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerAddress = new DataDynamics.ActiveReports.TextBox();
            this.TxtYear = new DataDynamics.ActiveReports.TextBox();
            this.TxtMake = new DataDynamics.ActiveReports.TextBox();
            this.TxtModel = new DataDynamics.ActiveReports.TextBox();
            this.TxtVinNo = new DataDynamics.ActiveReports.TextBox();
            this.TxtVehicleCost = new DataDynamics.ActiveReports.TextBox();
            this.TxtpurchaseDate = new DataDynamics.ActiveReports.TextBox();
            this.TxteffectiveDate = new DataDynamics.ActiveReports.TextBox();
            this.Txtodometer = new DataDynamics.ActiveReports.TextBox();
            this.Label86 = new DataDynamics.ActiveReports.Label();
            this.TxtTerm = new DataDynamics.ActiveReports.TextBox();
            this.TxtMileage = new DataDynamics.ActiveReports.TextBox();
            this.TxtDeductible = new DataDynamics.ActiveReports.TextBox();
            this.TxtClasification = new DataDynamics.ActiveReports.TextBox();
            this.TxtTotalPremium = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankName = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankPhone = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankAddress1 = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankAddress2 = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankCity = new DataDynamics.ActiveReports.TextBox();
            this.TxtEffectiveDate2 = new DataDynamics.ActiveReports.TextBox();
            this.TxtExpirationDate = new DataDynamics.ActiveReports.TextBox();
            this.Txtmileage2 = new DataDynamics.ActiveReports.TextBox();
            this.Label87 = new DataDynamics.ActiveReports.Label();
            this.Line26 = new DataDynamics.ActiveReports.Line();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.Shape12 = new DataDynamics.ActiveReports.Shape();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.Shape1 = new DataDynamics.ActiveReports.Shape();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblAutoGuard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtpolicyNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblMechanical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label67)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label68)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label69)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label72)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label73)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label74)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label78)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label81)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label83)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label82)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label84)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label85)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSellerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSellerAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSellerCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSellerState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSellerZip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerZip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVinNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVehicleCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtpurchaseDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxteffectiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtodometer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label86)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTerm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMileage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDeductible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtClasification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotalPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAddress1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAddress2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEffectiveDate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtExpirationDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtmileage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label87)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Shape5,
                        this.Shape9,
                        this.LblCompany,
                        this.Label10,
                        this.Label11,
                        this.Label14,
                        this.Label15,
                        this.Line1,
                        this.Line3,
                        this.Line4,
                        this.Label16,
                        this.Label17,
                        this.Label18,
                        this.Shape10,
                        this.Label20,
                        this.Label21,
                        this.Line5,
                        this.Line6,
                        this.Line7,
                        this.Line8,
                        this.Label22,
                        this.Label23,
                        this.Label24,
                        this.Label25,
                        this.Shape11,
                        this.Label26,
                        this.Label27,
                        this.Line9,
                        this.Line10,
                        this.Line11,
                        this.Line12,
                        this.Label28,
                        this.Label29,
                        this.Label30,
                        this.Label31,
                        this.Label32,
                        this.Line13,
                        this.Line14,
                        this.Label33,
                        this.Label34,
                        this.Label36,
                        this.Line17,
                        this.Label37,
                        this.Line18,
                        this.Label38,
                        this.Label39,
                        this.Label40,
                        this.Label41,
                        this.Label42,
                        this.Label43,
                        this.Label44,
                        this.Label45,
                        this.Shape13,
                        this.Line19,
                        this.Line20,
                        this.Label46,
                        this.Label47,
                        this.Label48,
                        this.Label49,
                        this.Label50,
                        this.Label51,
                        this.Shape14,
                        this.Label52,
                        this.Label53,
                        this.Line21,
                        this.Label54,
                        this.Label55,
                        this.Label56,
                        this.Line22,
                        this.Line23,
                        this.Label57,
                        this.Label58,
                        this.Label59,
                        this.Shape16,
                        this.Label60,
                        this.Label61,
                        this.Label62,
                        this.Label63,
                        this.Label64,
                        this.Label65,
                        this.Label66,
                        this.Label67,
                        this.Label68,
                        this.Label69,
                        this.Label70,
                        this.Label71,
                        this.Label72,
                        this.Label73,
                        this.Label74,
                        this.Label77,
                        this.Label78,
                        this.Line24,
                        this.Line25,
                        this.Label80,
                        this.Label81,
                        this.Label83,
                        this.Label82,
                        this.Label84,
                        this.Label85,
                        this.TxtSellerName,
                        this.TxtSellerAddress,
                        this.TxtSellerCity,
                        this.TxtSellerState,
                        this.TxtSellerZip,
                        this.TxtCustomerCity,
                        this.TxtCustomerState,
                        this.TxtCustomerZip,
                        this.TxtCustomerName,
                        this.TxtCustomerAddress,
                        this.TxtYear,
                        this.TxtMake,
                        this.TxtModel,
                        this.TxtVinNo,
                        this.TxtVehicleCost,
                        this.TxtpurchaseDate,
                        this.TxteffectiveDate,
                        this.Txtodometer,
                        this.Label86,
                        this.TxtTerm,
                        this.TxtMileage,
                        this.TxtDeductible,
                        this.TxtClasification,
                        this.TxtTotalPremium,
                        this.TxtBankName,
                        this.TxtBankPhone,
                        this.TxtBankAddress1,
                        this.TxtBankAddress2,
                        this.TxtBankCity,
                        this.TxtEffectiveDate2,
                        this.TxtExpirationDate,
                        this.Txtmileage2,
                        this.Label87,
                        this.Line26,
                        this.Line2,
                        this.Shape12,
                        this.Label,
                        this.Shape1});
            this.Detail.Height = 8.84375F;
            this.Detail.Name = "Detail";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Label1,
                        this.Label2,
                        this.Label3,
                        this.Label4,
                        this.LblAutoGuard,
                        this.Label7,
                        this.Label8,
                        this.TxtpolicyNo,
                        this.LblMechanical});
            this.PageHeader.Height = 1.3875F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0.03125F;
            this.PageFooter.Name = "PageFooter";
            // 
            // Label1
            // 
            this.Label1.Border.BottomColor = System.Drawing.Color.Black;
            this.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.LeftColor = System.Drawing.Color.Black;
            this.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.RightColor = System.Drawing.Color.Black;
            this.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.TopColor = System.Drawing.Color.Black;
            this.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Height = 0.2F;
            this.Label1.HyperLink = "";
            this.Label1.Left = 2.686553F;
            this.Label1.MultiLine = false;
            this.Label1.Name = "Label1";
            this.Label1.Style = "text-align: center; font-weight: bold; font-size: 9pt; ";
            this.Label1.Text = "Contrato de Servicio sobre Vehículo / Declaraciones";
            this.Label1.Top = 0.1875F;
            this.Label1.Width = 3.272727F;
            // 
            // Label2
            // 
            this.Label2.Border.BottomColor = System.Drawing.Color.Black;
            this.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.LeftColor = System.Drawing.Color.Black;
            this.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.RightColor = System.Drawing.Color.Black;
            this.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.TopColor = System.Drawing.Color.Black;
            this.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = "";
            this.Label2.Left = 2.686553F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "text-align: center; font-weight: bold; font-size: 9pt; ";
            this.Label2.Text = "Motor Vehicle Service Contract / Declaration";
            this.Label2.Top = 0.3125F;
            this.Label2.Width = 3.272727F;
            // 
            // Label3
            // 
            this.Label3.Border.BottomColor = System.Drawing.Color.Black;
            this.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.LeftColor = System.Drawing.Color.Black;
            this.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.RightColor = System.Drawing.Color.Black;
            this.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.TopColor = System.Drawing.Color.Black;
            this.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Height = 0.2F;
            this.Label3.HyperLink = "";
            this.Label3.Left = 4.875F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label3.Text = "Número de Contrato de Servicio/Service Contract Number";
            this.Label3.Top = 1F;
            this.Label3.Width = 3.090909F;
            // 
            // Label4
            // 
            this.Label4.Border.BottomColor = System.Drawing.Color.Black;
            this.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.LeftColor = System.Drawing.Color.Black;
            this.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.RightColor = System.Drawing.Color.Black;
            this.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.TopColor = System.Drawing.Color.Black;
            this.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Height = 0.2F;
            this.Label4.HyperLink = "";
            this.Label4.Left = 0.0625F;
            this.Label4.MultiLine = false;
            this.Label4.Name = "Label4";
            this.Label4.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label4.Text = "Información del Proveedor del Contrato / Contract Provider Information";
            this.Label4.Top = 1.1875F;
            this.Label4.Width = 4F;
            // 
            // LblAutoGuard
            // 
            this.LblAutoGuard.Border.BottomColor = System.Drawing.Color.Black;
            this.LblAutoGuard.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblAutoGuard.Border.LeftColor = System.Drawing.Color.Black;
            this.LblAutoGuard.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblAutoGuard.Border.RightColor = System.Drawing.Color.Black;
            this.LblAutoGuard.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblAutoGuard.Border.TopColor = System.Drawing.Color.Black;
            this.LblAutoGuard.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblAutoGuard.Height = 0.2F;
            this.LblAutoGuard.HyperLink = "";
            this.LblAutoGuard.Left = 0.078125F;
            this.LblAutoGuard.MultiLine = false;
            this.LblAutoGuard.Name = "LblAutoGuard";
            this.LblAutoGuard.Style = "text-align: left; font-weight: bold; font-size: 9pt; ";
            this.LblAutoGuard.Text = "LAS VISTAS INSURANCE AGENCY, CORP.";
            this.LblAutoGuard.Top = 0.625F;
            this.LblAutoGuard.Width = 2.9375F;
            // 
            // Label7
            // 
            this.Label7.Border.BottomColor = System.Drawing.Color.Black;
            this.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.LeftColor = System.Drawing.Color.Black;
            this.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.RightColor = System.Drawing.Color.Black;
            this.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.TopColor = System.Drawing.Color.Black;
            this.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Height = 0.2F;
            this.Label7.HyperLink = "";
            this.Label7.Left = 0.078125F;
            this.Label7.MultiLine = false;
            this.Label7.Name = "Label7";
            this.Label7.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.Label7.Text = "P.O. Box 195585";
            this.Label7.Top = 0.828125F;
            this.Label7.Width = 2F;
            // 
            // Label8
            // 
            this.Label8.Border.BottomColor = System.Drawing.Color.Black;
            this.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.LeftColor = System.Drawing.Color.Black;
            this.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.RightColor = System.Drawing.Color.Black;
            this.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.TopColor = System.Drawing.Color.Black;
            this.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Height = 0.2F;
            this.Label8.HyperLink = "";
            this.Label8.Left = 0.078125F;
            this.Label8.MultiLine = false;
            this.Label8.Name = "Label8";
            this.Label8.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.Label8.Text = "San Juan Puerto Rico, PR  00919-5585";
            this.Label8.Top = 0.9739583F;
            this.Label8.Width = 2F;
            // 
            // TxtpolicyNo
            // 
            this.TxtpolicyNo.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtpolicyNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtpolicyNo.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtpolicyNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtpolicyNo.Border.RightColor = System.Drawing.Color.Black;
            this.TxtpolicyNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtpolicyNo.Border.TopColor = System.Drawing.Color.Black;
            this.TxtpolicyNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtpolicyNo.DataField = "policyNo";
            this.TxtpolicyNo.Height = 0.1875F;
            this.TxtpolicyNo.Left = 5.6875F;
            this.TxtpolicyNo.Name = "TxtpolicyNo";
            this.TxtpolicyNo.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TxtpolicyNo.Text = "TxtpolicyNo";
            this.TxtpolicyNo.Top = 1.1875F;
            this.TxtpolicyNo.Width = 1.5F;
            // 
            // LblMechanical
            // 
            this.LblMechanical.Border.BottomColor = System.Drawing.Color.Black;
            this.LblMechanical.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblMechanical.Border.LeftColor = System.Drawing.Color.Black;
            this.LblMechanical.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblMechanical.Border.RightColor = System.Drawing.Color.Black;
            this.LblMechanical.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblMechanical.Border.TopColor = System.Drawing.Color.Black;
            this.LblMechanical.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblMechanical.Height = 0.2F;
            this.LblMechanical.HyperLink = "";
            this.LblMechanical.Left = 0.75F;
            this.LblMechanical.MultiLine = false;
            this.LblMechanical.Name = "LblMechanical";
            this.LblMechanical.Style = "text-align: left; font-weight: bold; font-size: 9pt; ";
            this.LblMechanical.Text = "Mechanical Breakdown";
            this.LblMechanical.Top = 0.375F;
            this.LblMechanical.Width = 2.4375F;
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
            this.Shape5.Height = 0.3125F;
            this.Shape5.Left = 0.0625F;
            this.Shape5.Name = "Shape5";
            this.Shape5.RoundingRadius = 9.999999F;
            this.Shape5.Top = 3.5F;
            this.Shape5.Width = 7.9375F;
            // 
            // Shape9
            // 
            this.Shape9.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape9.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape9.Border.RightColor = System.Drawing.Color.Black;
            this.Shape9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape9.Border.TopColor = System.Drawing.Color.Black;
            this.Shape9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape9.Height = 2.583333F;
            this.Shape9.Left = 5.426137F;
            this.Shape9.Name = "Shape9";
            this.Shape9.RoundingRadius = 9.999999F;
            this.Shape9.Top = 4.979167F;
            this.Shape9.Width = 2.573863F;
            // 
            // LblCompany
            // 
            this.LblCompany.Border.BottomColor = System.Drawing.Color.Black;
            this.LblCompany.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblCompany.Border.LeftColor = System.Drawing.Color.Black;
            this.LblCompany.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblCompany.Border.RightColor = System.Drawing.Color.Black;
            this.LblCompany.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblCompany.Border.TopColor = System.Drawing.Color.Black;
            this.LblCompany.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblCompany.Height = 0.2F;
            this.LblCompany.HyperLink = "";
            this.LblCompany.Left = 2.551136F;
            this.LblCompany.MultiLine = false;
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Style = "text-align: left; font-weight: bold; font-size: 9pt; ";
            this.LblCompany.Text = "AUTO GUARD, INC.";
            this.LblCompany.Top = 0F;
            this.LblCompany.Width = 3.147727F;
            // 
            // Label10
            // 
            this.Label10.Border.BottomColor = System.Drawing.Color.Black;
            this.Label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.LeftColor = System.Drawing.Color.Black;
            this.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.RightColor = System.Drawing.Color.Black;
            this.Label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.TopColor = System.Drawing.Color.Black;
            this.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Height = 0.2F;
            this.Label10.HyperLink = "";
            this.Label10.Left = 0.0625F;
            this.Label10.MultiLine = false;
            this.Label10.Name = "Label10";
            this.Label10.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label10.Text = "Información del Vendedor del Contrato / Contract Seller Information";
            this.Label10.Top = 0.625F;
            this.Label10.Width = 4F;
            // 
            // Label11
            // 
            this.Label11.Border.BottomColor = System.Drawing.Color.Black;
            this.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.LeftColor = System.Drawing.Color.Black;
            this.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.RightColor = System.Drawing.Color.Black;
            this.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.TopColor = System.Drawing.Color.Black;
            this.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Height = 0.2F;
            this.Label11.HyperLink = "";
            this.Label11.Left = 0.0625F;
            this.Label11.MultiLine = false;
            this.Label11.Name = "Label11";
            this.Label11.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label11.Text = "Información del Tenedor del Contrato / Contract Holder Information";
            this.Label11.Top = 1.5F;
            this.Label11.Width = 3.727273F;
            // 
            // Label14
            // 
            this.Label14.Border.BottomColor = System.Drawing.Color.Black;
            this.Label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.LeftColor = System.Drawing.Color.Black;
            this.Label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.RightColor = System.Drawing.Color.Black;
            this.Label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.TopColor = System.Drawing.Color.Black;
            this.Label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Height = 0.1875F;
            this.Label14.HyperLink = "";
            this.Label14.Left = 0.125F;
            this.Label14.Name = "Label14";
            this.Label14.Style = "color: Gray; font-size: 8pt; ";
            this.Label14.Text = "Nombre del Proveedor / Name Provider";
            this.Label14.Top = 0F;
            this.Label14.Width = 2.028409F;
            // 
            // Label15
            // 
            this.Label15.Border.BottomColor = System.Drawing.Color.Black;
            this.Label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.LeftColor = System.Drawing.Color.Black;
            this.Label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.RightColor = System.Drawing.Color.Black;
            this.Label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.TopColor = System.Drawing.Color.Black;
            this.Label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Height = 0.1875F;
            this.Label15.HyperLink = "";
            this.Label15.Left = 0.0909091F;
            this.Label15.Name = "Label15";
            this.Label15.Style = "color: Gray; font-size: 8pt; ";
            this.Label15.Text = "Dirección / Address";
            this.Label15.Top = 0.25F;
            this.Label15.Width = 1.090909F;
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
            this.Line1.Height = 0F;
            this.Line1.Left = 0.0625F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0.25F;
            this.Line1.Width = 7.9375F;
            this.Line1.X1 = 0.0625F;
            this.Line1.X2 = 8F;
            this.Line1.Y1 = 0.25F;
            this.Line1.Y2 = 0.25F;
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
            this.Line3.Height = 0.375F;
            this.Line3.Left = 5.545455F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 0.25F;
            this.Line3.Width = 0F;
            this.Line3.X1 = 5.545455F;
            this.Line3.X2 = 5.545455F;
            this.Line3.Y1 = 0.625F;
            this.Line3.Y2 = 0.25F;
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
            this.Line4.Height = 0.375F;
            this.Line4.Left = 6.727273F;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 0.25F;
            this.Line4.Width = 0F;
            this.Line4.X1 = 6.727273F;
            this.Line4.X2 = 6.727273F;
            this.Line4.Y1 = 0.625F;
            this.Line4.Y2 = 0.25F;
            // 
            // Label16
            // 
            this.Label16.Border.BottomColor = System.Drawing.Color.Black;
            this.Label16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label16.Border.LeftColor = System.Drawing.Color.Black;
            this.Label16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label16.Border.RightColor = System.Drawing.Color.Black;
            this.Label16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label16.Border.TopColor = System.Drawing.Color.Black;
            this.Label16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label16.Height = 0.2F;
            this.Label16.HyperLink = "";
            this.Label16.Left = 4.392046F;
            this.Label16.Name = "Label16";
            this.Label16.Style = "color: Gray; text-align: center; font-size: 8pt; ";
            this.Label16.Text = "Ciudad / City";
            this.Label16.Top = 0.25F;
            this.Label16.Width = 1.181818F;
            // 
            // Label17
            // 
            this.Label17.Border.BottomColor = System.Drawing.Color.Black;
            this.Label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label17.Border.LeftColor = System.Drawing.Color.Black;
            this.Label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label17.Border.RightColor = System.Drawing.Color.Black;
            this.Label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label17.Border.TopColor = System.Drawing.Color.Black;
            this.Label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label17.Height = 0.2F;
            this.Label17.HyperLink = "";
            this.Label17.Left = 5.573863F;
            this.Label17.Name = "Label17";
            this.Label17.Style = "color: Gray; text-align: center; font-size: 8pt; ";
            this.Label17.Text = "Estado / State";
            this.Label17.Top = 0.25F;
            this.Label17.Width = 1.181818F;
            // 
            // Label18
            // 
            this.Label18.Border.BottomColor = System.Drawing.Color.Black;
            this.Label18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label18.Border.LeftColor = System.Drawing.Color.Black;
            this.Label18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label18.Border.RightColor = System.Drawing.Color.Black;
            this.Label18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label18.Border.TopColor = System.Drawing.Color.Black;
            this.Label18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label18.Height = 0.2F;
            this.Label18.HyperLink = "";
            this.Label18.Left = 6.755682F;
            this.Label18.Name = "Label18";
            this.Label18.Style = "color: Gray; text-align: center; font-size: 8pt; ";
            this.Label18.Text = "Zip Code";
            this.Label18.Top = 0.25F;
            this.Label18.Width = 1.244319F;
            // 
            // Shape10
            // 
            this.Shape10.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape10.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape10.Border.RightColor = System.Drawing.Color.Black;
            this.Shape10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape10.Border.TopColor = System.Drawing.Color.Black;
            this.Shape10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape10.Height = 0.75F;
            this.Shape10.Left = 0.0625F;
            this.Shape10.Name = "Shape10";
            this.Shape10.RoundingRadius = 9.999999F;
            this.Shape10.Top = 0.7604167F;
            this.Shape10.Width = 7.9375F;
            // 
            // Label20
            // 
            this.Label20.Border.BottomColor = System.Drawing.Color.Black;
            this.Label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label20.Border.LeftColor = System.Drawing.Color.Black;
            this.Label20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label20.Border.RightColor = System.Drawing.Color.Black;
            this.Label20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label20.Border.TopColor = System.Drawing.Color.Black;
            this.Label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label20.Height = 0.125F;
            this.Label20.HyperLink = "";
            this.Label20.Left = 0.125F;
            this.Label20.Name = "Label20";
            this.Label20.Style = "color: Gray; font-size: 8pt; ";
            this.Label20.Text = "Nombre del Vendedor / Name of Seller";
            this.Label20.Top = 0.8125F;
            this.Label20.Width = 2.028409F;
            // 
            // Label21
            // 
            this.Label21.Border.BottomColor = System.Drawing.Color.Black;
            this.Label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.LeftColor = System.Drawing.Color.Black;
            this.Label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.RightColor = System.Drawing.Color.Black;
            this.Label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.TopColor = System.Drawing.Color.Black;
            this.Label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Height = 0.2F;
            this.Label21.HyperLink = "";
            this.Label21.Left = 0.1534091F;
            this.Label21.Name = "Label21";
            this.Label21.Style = "color: Gray; font-size: 8pt; ";
            this.Label21.Text = "Dirección / Address";
            this.Label21.Top = 1.125F;
            this.Label21.Width = 1.090909F;
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
            this.Line5.Height = 0F;
            this.Line5.Left = 0.0625F;
            this.Line5.LineWeight = 1F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 1.125F;
            this.Line5.Width = 7.9375F;
            this.Line5.X1 = 0.0625F;
            this.Line5.X2 = 8F;
            this.Line5.Y1 = 1.125F;
            this.Line5.Y2 = 1.125F;
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
            this.Line6.Height = 0.375F;
            this.Line6.Left = 4.363637F;
            this.Line6.LineWeight = 1F;
            this.Line6.Name = "Line6";
            this.Line6.Top = 1.125F;
            this.Line6.Width = 0F;
            this.Line6.X1 = 4.363637F;
            this.Line6.X2 = 4.363637F;
            this.Line6.Y1 = 1.5F;
            this.Line6.Y2 = 1.125F;
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
            this.Line7.Height = 0.375F;
            this.Line7.Left = 5.545455F;
            this.Line7.LineWeight = 1F;
            this.Line7.Name = "Line7";
            this.Line7.Top = 1.125F;
            this.Line7.Width = 0F;
            this.Line7.X1 = 5.545455F;
            this.Line7.X2 = 5.545455F;
            this.Line7.Y1 = 1.5F;
            this.Line7.Y2 = 1.125F;
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
            this.Line8.Height = 0.375F;
            this.Line8.Left = 6.727273F;
            this.Line8.LineWeight = 1F;
            this.Line8.Name = "Line8";
            this.Line8.Top = 1.125F;
            this.Line8.Width = 0F;
            this.Line8.X1 = 6.727273F;
            this.Line8.X2 = 6.727273F;
            this.Line8.Y1 = 1.5F;
            this.Line8.Y2 = 1.125F;
            // 
            // Label22
            // 
            this.Label22.Border.BottomColor = System.Drawing.Color.Black;
            this.Label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.LeftColor = System.Drawing.Color.Black;
            this.Label22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.RightColor = System.Drawing.Color.Black;
            this.Label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.TopColor = System.Drawing.Color.Black;
            this.Label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Height = 0.2F;
            this.Label22.HyperLink = "";
            this.Label22.Left = 4.454546F;
            this.Label22.Name = "Label22";
            this.Label22.Style = "color: Gray; text-align: center; font-size: 8pt; ";
            this.Label22.Text = "Ciudad / City";
            this.Label22.Top = 1.125F;
            this.Label22.Width = 1.181818F;
            // 
            // Label23
            // 
            this.Label23.Border.BottomColor = System.Drawing.Color.Black;
            this.Label23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.LeftColor = System.Drawing.Color.Black;
            this.Label23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.RightColor = System.Drawing.Color.Black;
            this.Label23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.TopColor = System.Drawing.Color.Black;
            this.Label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Height = 0.2F;
            this.Label23.HyperLink = "";
            this.Label23.Left = 5.636363F;
            this.Label23.Name = "Label23";
            this.Label23.Style = "color: Gray; text-align: center; font-size: 8pt; ";
            this.Label23.Text = "Estado / State";
            this.Label23.Top = 1.125F;
            this.Label23.Width = 1.181818F;
            // 
            // Label24
            // 
            this.Label24.Border.BottomColor = System.Drawing.Color.Black;
            this.Label24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.LeftColor = System.Drawing.Color.Black;
            this.Label24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.RightColor = System.Drawing.Color.Black;
            this.Label24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.TopColor = System.Drawing.Color.Black;
            this.Label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Height = 0.2F;
            this.Label24.HyperLink = "";
            this.Label24.Left = 6.818182F;
            this.Label24.Name = "Label24";
            this.Label24.Style = "color: Gray; text-align: center; font-size: 8pt; ";
            this.Label24.Text = "Zip Code";
            this.Label24.Top = 1.125F;
            this.Label24.Width = 1.181819F;
            // 
            // Label25
            // 
            this.Label25.Border.BottomColor = System.Drawing.Color.Black;
            this.Label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.LeftColor = System.Drawing.Color.Black;
            this.Label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.RightColor = System.Drawing.Color.Black;
            this.Label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.TopColor = System.Drawing.Color.Black;
            this.Label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Height = 0.2F;
            this.Label25.HyperLink = "";
            this.Label25.Left = 0.0625F;
            this.Label25.MultiLine = false;
            this.Label25.Name = "Label25";
            this.Label25.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label25.Text = "Información del Vehículo / Vehicle Information";
            this.Label25.Top = 2.375F;
            this.Label25.Width = 2.727273F;
            // 
            // Shape11
            // 
            this.Shape11.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape11.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape11.Border.RightColor = System.Drawing.Color.Black;
            this.Shape11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape11.Border.TopColor = System.Drawing.Color.Black;
            this.Shape11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape11.Height = 0.6875F;
            this.Shape11.Left = 0.0625F;
            this.Shape11.Name = "Shape11";
            this.Shape11.RoundingRadius = 9.999999F;
            this.Shape11.Top = 1.6875F;
            this.Shape11.Width = 7.9375F;
            // 
            // Label26
            // 
            this.Label26.Border.BottomColor = System.Drawing.Color.Black;
            this.Label26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.LeftColor = System.Drawing.Color.Black;
            this.Label26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.RightColor = System.Drawing.Color.Black;
            this.Label26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.TopColor = System.Drawing.Color.Black;
            this.Label26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Height = 0.125F;
            this.Label26.HyperLink = "";
            this.Label26.Left = 0.125F;
            this.Label26.Name = "Label26";
            this.Label26.Style = "color: Gray; font-size: 8pt; ";
            this.Label26.Text = "Nombre del Tenedor / Name of Holder";
            this.Label26.Top = 1.6875F;
            this.Label26.Width = 2.028409F;
            // 
            // Label27
            // 
            this.Label27.Border.BottomColor = System.Drawing.Color.Black;
            this.Label27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.LeftColor = System.Drawing.Color.Black;
            this.Label27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.RightColor = System.Drawing.Color.Black;
            this.Label27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.TopColor = System.Drawing.Color.Black;
            this.Label27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Height = 0.2F;
            this.Label27.HyperLink = "";
            this.Label27.Left = 0.1534091F;
            this.Label27.Name = "Label27";
            this.Label27.Style = "color: Gray; font-size: 8pt; ";
            this.Label27.Text = "Dirección / Address";
            this.Label27.Top = 2F;
            this.Label27.Width = 1.090909F;
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
            this.Line9.Height = 0F;
            this.Line9.Left = 0.0625F;
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 2F;
            this.Line9.Width = 7.9375F;
            this.Line9.X1 = 0.0625F;
            this.Line9.X2 = 8F;
            this.Line9.Y1 = 2F;
            this.Line9.Y2 = 2F;
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
            this.Line10.Height = 0.375F;
            this.Line10.Left = 4.363637F;
            this.Line10.LineWeight = 1F;
            this.Line10.Name = "Line10";
            this.Line10.Top = 2F;
            this.Line10.Width = 0F;
            this.Line10.X1 = 4.363637F;
            this.Line10.X2 = 4.363637F;
            this.Line10.Y1 = 2.375F;
            this.Line10.Y2 = 2F;
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
            this.Line11.Height = 0.375F;
            this.Line11.Left = 5.545455F;
            this.Line11.LineWeight = 1F;
            this.Line11.Name = "Line11";
            this.Line11.Top = 2F;
            this.Line11.Width = 0F;
            this.Line11.X1 = 5.545455F;
            this.Line11.X2 = 5.545455F;
            this.Line11.Y1 = 2.375F;
            this.Line11.Y2 = 2F;
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
            this.Line12.Height = 0.375F;
            this.Line12.Left = 6.727273F;
            this.Line12.LineWeight = 1F;
            this.Line12.Name = "Line12";
            this.Line12.Top = 2F;
            this.Line12.Width = 0F;
            this.Line12.X1 = 6.727273F;
            this.Line12.X2 = 6.727273F;
            this.Line12.Y1 = 2.375F;
            this.Line12.Y2 = 2F;
            // 
            // Label28
            // 
            this.Label28.Border.BottomColor = System.Drawing.Color.Black;
            this.Label28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label28.Border.LeftColor = System.Drawing.Color.Black;
            this.Label28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label28.Border.RightColor = System.Drawing.Color.Black;
            this.Label28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label28.Border.TopColor = System.Drawing.Color.Black;
            this.Label28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label28.Height = 0.2F;
            this.Label28.HyperLink = "";
            this.Label28.Left = 4.454546F;
            this.Label28.Name = "Label28";
            this.Label28.Style = "color: Gray; text-align: center; font-size: 8pt; ";
            this.Label28.Text = "Ciudad / City";
            this.Label28.Top = 2F;
            this.Label28.Width = 1.181818F;
            // 
            // Label29
            // 
            this.Label29.Border.BottomColor = System.Drawing.Color.Black;
            this.Label29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label29.Border.LeftColor = System.Drawing.Color.Black;
            this.Label29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label29.Border.RightColor = System.Drawing.Color.Black;
            this.Label29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label29.Border.TopColor = System.Drawing.Color.Black;
            this.Label29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label29.Height = 0.2F;
            this.Label29.HyperLink = "";
            this.Label29.Left = 5.607955F;
            this.Label29.Name = "Label29";
            this.Label29.Style = "color: Gray; text-align: center; font-size: 8pt; ";
            this.Label29.Text = "Estado / State";
            this.Label29.Top = 2F;
            this.Label29.Width = 1.181818F;
            // 
            // Label30
            // 
            this.Label30.Border.BottomColor = System.Drawing.Color.Black;
            this.Label30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label30.Border.LeftColor = System.Drawing.Color.Black;
            this.Label30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label30.Border.RightColor = System.Drawing.Color.Black;
            this.Label30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label30.Border.TopColor = System.Drawing.Color.Black;
            this.Label30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label30.Height = 0.2F;
            this.Label30.HyperLink = "";
            this.Label30.Left = 6.789773F;
            this.Label30.Name = "Label30";
            this.Label30.Style = "color: Gray; text-align: center; font-size: 8pt; ";
            this.Label30.Text = "Zip Code";
            this.Label30.Top = 2F;
            this.Label30.Width = 1.210227F;
            // 
            // Label31
            // 
            this.Label31.Border.BottomColor = System.Drawing.Color.Black;
            this.Label31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label31.Border.LeftColor = System.Drawing.Color.Black;
            this.Label31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label31.Border.RightColor = System.Drawing.Color.Black;
            this.Label31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label31.Border.TopColor = System.Drawing.Color.Black;
            this.Label31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label31.Height = 0.15625F;
            this.Label31.HyperLink = "";
            this.Label31.Left = 0.1534091F;
            this.Label31.Name = "Label31";
            this.Label31.Style = "color: Gray; text-align: center; font-size: 8pt; ";
            this.Label31.Text = "Año / Year";
            this.Label31.Top = 2.59375F;
            this.Label31.Width = 0.8181819F;
            // 
            // Label32
            // 
            this.Label32.Border.BottomColor = System.Drawing.Color.Black;
            this.Label32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label32.Border.LeftColor = System.Drawing.Color.Black;
            this.Label32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label32.Border.RightColor = System.Drawing.Color.Black;
            this.Label32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label32.Border.TopColor = System.Drawing.Color.Black;
            this.Label32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label32.Height = 0.2F;
            this.Label32.HyperLink = "";
            this.Label32.Left = 0.1534091F;
            this.Label32.Name = "Label32";
            this.Label32.Style = "color: Gray; font-size: 8pt; ";
            this.Label32.Text = "Precio de Compra del Vehículo";
            this.Label32.Top = 2.9375F;
            this.Label32.Width = 1.755682F;
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
            this.Line13.Height = 0F;
            this.Line13.Left = 0.0625F;
            this.Line13.LineWeight = 1F;
            this.Line13.Name = "Line13";
            this.Line13.Top = 2.9375F;
            this.Line13.Width = 7.9375F;
            this.Line13.X1 = 0.0625F;
            this.Line13.X2 = 8F;
            this.Line13.Y1 = 2.9375F;
            this.Line13.Y2 = 2.9375F;
            // 
            // Line14
            // 
            this.Line14.Border.BottomColor = System.Drawing.Color.Black;
            this.Line14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14.Border.LeftColor = System.Drawing.Color.Black;
            this.Line14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14.Border.RightColor = System.Drawing.Color.Black;
            this.Line14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14.Border.TopColor = System.Drawing.Color.Black;
            this.Line14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14.Height = 0.375F;
            this.Line14.Left = 0.9090909F;
            this.Line14.LineWeight = 1F;
            this.Line14.Name = "Line14";
            this.Line14.Top = 2.5625F;
            this.Line14.Width = 0F;
            this.Line14.X1 = 0.9090909F;
            this.Line14.X2 = 0.9090909F;
            this.Line14.Y1 = 2.9375F;
            this.Line14.Y2 = 2.5625F;
            // 
            // Label33
            // 
            this.Label33.Border.BottomColor = System.Drawing.Color.Black;
            this.Label33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label33.Border.LeftColor = System.Drawing.Color.Black;
            this.Label33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label33.Border.RightColor = System.Drawing.Color.Black;
            this.Label33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label33.Border.TopColor = System.Drawing.Color.Black;
            this.Label33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label33.Height = 0.2000001F;
            this.Label33.HyperLink = "";
            this.Label33.Left = 3.068182F;
            this.Label33.Name = "Label33";
            this.Label33.Style = "color: Gray; text-align: left; font-size: 8pt; ";
            this.Label33.Text = "Fecha de Compra del Vehículo";
            this.Label33.Top = 2.9375F;
            this.Label33.Width = 1.8125F;
            // 
            // Label34
            // 
            this.Label34.Border.BottomColor = System.Drawing.Color.Black;
            this.Label34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label34.Border.LeftColor = System.Drawing.Color.Black;
            this.Label34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label34.Border.RightColor = System.Drawing.Color.Black;
            this.Label34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label34.Border.TopColor = System.Drawing.Color.Black;
            this.Label34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label34.Height = 0.2F;
            this.Label34.HyperLink = "";
            this.Label34.Left = 5.034091F;
            this.Label34.Name = "Label34";
            this.Label34.Style = "color: Gray; text-align: left; font-size: 8pt; ";
            this.Label34.Text = "Fecha Original que el Vehículo entra en Servicio";
            this.Label34.Top = 2.9375F;
            this.Label34.Width = 2.636364F;
            // 
            // Label36
            // 
            this.Label36.Border.BottomColor = System.Drawing.Color.Black;
            this.Label36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label36.Border.LeftColor = System.Drawing.Color.Black;
            this.Label36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label36.Border.RightColor = System.Drawing.Color.Black;
            this.Label36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label36.Border.TopColor = System.Drawing.Color.Black;
            this.Label36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label36.Height = 0.15625F;
            this.Label36.HyperLink = "";
            this.Label36.Left = 0.9715909F;
            this.Label36.Name = "Label36";
            this.Label36.Style = "color: Gray; text-align: center; font-size: 8pt; ";
            this.Label36.Text = "Marca / Make";
            this.Label36.Top = 2.59375F;
            this.Label36.Width = 2F;
            // 
            // Line17
            // 
            this.Line17.Border.BottomColor = System.Drawing.Color.Black;
            this.Line17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line17.Border.LeftColor = System.Drawing.Color.Black;
            this.Line17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line17.Border.RightColor = System.Drawing.Color.Black;
            this.Line17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line17.Border.TopColor = System.Drawing.Color.Black;
            this.Line17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line17.Height = 0.9375F;
            this.Line17.Left = 2.909091F;
            this.Line17.LineWeight = 1F;
            this.Line17.Name = "Line17";
            this.Line17.Top = 2.5625F;
            this.Line17.Width = 0F;
            this.Line17.X1 = 2.909091F;
            this.Line17.X2 = 2.909091F;
            this.Line17.Y1 = 3.5F;
            this.Line17.Y2 = 2.5625F;
            // 
            // Label37
            // 
            this.Label37.Border.BottomColor = System.Drawing.Color.Black;
            this.Label37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label37.Border.LeftColor = System.Drawing.Color.Black;
            this.Label37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label37.Border.RightColor = System.Drawing.Color.Black;
            this.Label37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label37.Border.TopColor = System.Drawing.Color.Black;
            this.Label37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label37.Height = 0.15625F;
            this.Label37.HyperLink = "";
            this.Label37.Left = 2.971591F;
            this.Label37.Name = "Label37";
            this.Label37.Style = "color: Gray; text-align: center; font-size: 8pt; ";
            this.Label37.Text = "Modelo / Model";
            this.Label37.Top = 2.59375F;
            this.Label37.Width = 2F;
            // 
            // Line18
            // 
            this.Line18.Border.BottomColor = System.Drawing.Color.Black;
            this.Line18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line18.Border.LeftColor = System.Drawing.Color.Black;
            this.Line18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line18.Border.RightColor = System.Drawing.Color.Black;
            this.Line18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line18.Border.TopColor = System.Drawing.Color.Black;
            this.Line18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line18.Height = 0.9375F;
            this.Line18.Left = 4.909091F;
            this.Line18.LineWeight = 1F;
            this.Line18.Name = "Line18";
            this.Line18.Top = 2.5625F;
            this.Line18.Width = 0F;
            this.Line18.X1 = 4.909091F;
            this.Line18.X2 = 4.909091F;
            this.Line18.Y1 = 3.5F;
            this.Line18.Y2 = 2.5625F;
            // 
            // Label38
            // 
            this.Label38.Border.BottomColor = System.Drawing.Color.Black;
            this.Label38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label38.Border.LeftColor = System.Drawing.Color.Black;
            this.Label38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label38.Border.RightColor = System.Drawing.Color.Black;
            this.Label38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label38.Border.TopColor = System.Drawing.Color.Black;
            this.Label38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label38.Height = 0.15625F;
            this.Label38.HyperLink = "";
            this.Label38.Left = 4.971591F;
            this.Label38.Name = "Label38";
            this.Label38.Style = "color: Gray; text-align: center; font-size: 8pt; ";
            this.Label38.Text = "Número Identificación del Vehículo / Vehicle Information";
            this.Label38.Top = 2.59375F;
            this.Label38.Width = 3.028409F;
            // 
            // Label39
            // 
            this.Label39.Border.BottomColor = System.Drawing.Color.Black;
            this.Label39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label39.Border.LeftColor = System.Drawing.Color.Black;
            this.Label39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label39.Border.RightColor = System.Drawing.Color.Black;
            this.Label39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label39.Border.TopColor = System.Drawing.Color.Black;
            this.Label39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label39.Height = 0.2F;
            this.Label39.HyperLink = "";
            this.Label39.Left = 0.1534091F;
            this.Label39.Name = "Label39";
            this.Label39.Style = "color: Gray; font-size: 8pt; ";
            this.Label39.Text = "Vehicle Purchase Price";
            this.Label39.Top = 3.0625F;
            this.Label39.Width = 1.755682F;
            // 
            // Label40
            // 
            this.Label40.Border.BottomColor = System.Drawing.Color.Black;
            this.Label40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label40.Border.LeftColor = System.Drawing.Color.Black;
            this.Label40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label40.Border.RightColor = System.Drawing.Color.Black;
            this.Label40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label40.Border.TopColor = System.Drawing.Color.Black;
            this.Label40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label40.Height = 0.2000001F;
            this.Label40.HyperLink = "";
            this.Label40.Left = 3.068182F;
            this.Label40.Name = "Label40";
            this.Label40.Style = "color: Gray; text-align: left; font-size: 8pt; ";
            this.Label40.Text = "Vehicle Purchase Date";
            this.Label40.Top = 3.0625F;
            this.Label40.Width = 1.8125F;
            // 
            // Label41
            // 
            this.Label41.Border.BottomColor = System.Drawing.Color.Black;
            this.Label41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label41.Border.LeftColor = System.Drawing.Color.Black;
            this.Label41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label41.Border.RightColor = System.Drawing.Color.Black;
            this.Label41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label41.Border.TopColor = System.Drawing.Color.Black;
            this.Label41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label41.Height = 0.2F;
            this.Label41.HyperLink = "";
            this.Label41.Left = 5.034091F;
            this.Label41.Name = "Label41";
            this.Label41.Style = "color: Gray; text-align: left; font-size: 8pt; ";
            this.Label41.Text = "(Fecha de Comienzo de la Garantía)";
            this.Label41.Top = 3.0625F;
            this.Label41.Width = 2.636364F;
            // 
            // Label42
            // 
            this.Label42.Border.BottomColor = System.Drawing.Color.Black;
            this.Label42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label42.Border.LeftColor = System.Drawing.Color.Black;
            this.Label42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label42.Border.RightColor = System.Drawing.Color.Black;
            this.Label42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label42.Border.TopColor = System.Drawing.Color.Black;
            this.Label42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label42.Height = 0.2F;
            this.Label42.HyperLink = "";
            this.Label42.Left = 5.034091F;
            this.Label42.Name = "Label42";
            this.Label42.Style = "color: Gray; text-align: left; font-size: 8pt; ";
            this.Label42.Text = "Original In-Service Date (Coverage Start Date)";
            this.Label42.Top = 3.1875F;
            this.Label42.Width = 2.636364F;
            // 
            // Label43
            // 
            this.Label43.Border.BottomColor = System.Drawing.Color.Black;
            this.Label43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label43.Border.LeftColor = System.Drawing.Color.Black;
            this.Label43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label43.Border.RightColor = System.Drawing.Color.Black;
            this.Label43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label43.Border.TopColor = System.Drawing.Color.Black;
            this.Label43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label43.Height = 0.2F;
            this.Label43.HyperLink = "";
            this.Label43.Left = 0.1534091F;
            this.Label43.Name = "Label43";
            this.Label43.Style = "color: Black; font-size: 8pt; ";
            this.Label43.Text = "Millaje en el Odómetro ( A la Fecha de Compra del Contrato)";
            this.Label43.Top = 3.5F;
            this.Label43.Width = 3.090909F;
            // 
            // Label44
            // 
            this.Label44.Border.BottomColor = System.Drawing.Color.Black;
            this.Label44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label44.Border.LeftColor = System.Drawing.Color.Black;
            this.Label44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label44.Border.RightColor = System.Drawing.Color.Black;
            this.Label44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label44.Border.TopColor = System.Drawing.Color.Black;
            this.Label44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label44.Height = 0.2F;
            this.Label44.HyperLink = "";
            this.Label44.Left = 0.1534091F;
            this.Label44.Name = "Label44";
            this.Label44.Style = "color: Black; font-size: 8pt; ";
            this.Label44.Text = "Odometer Mileage (At date of Purchase of Contract)";
            this.Label44.Top = 3.625F;
            this.Label44.Width = 3.090909F;
            // 
            // Label45
            // 
            this.Label45.Border.BottomColor = System.Drawing.Color.Black;
            this.Label45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label45.Border.LeftColor = System.Drawing.Color.Black;
            this.Label45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label45.Border.RightColor = System.Drawing.Color.Black;
            this.Label45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label45.Border.TopColor = System.Drawing.Color.Black;
            this.Label45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label45.Height = 0.2F;
            this.Label45.HyperLink = "";
            this.Label45.Left = 2.90767F;
            this.Label45.MultiLine = false;
            this.Label45.Name = "Label45";
            this.Label45.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label45.Text = "Información de la Cobertura / Coverage Information";
            this.Label45.Top = 3.8125F;
            this.Label45.Width = 2.830493F;
            // 
            // Shape13
            // 
            this.Shape13.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape13.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape13.Border.RightColor = System.Drawing.Color.Black;
            this.Shape13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape13.Border.TopColor = System.Drawing.Color.Black;
            this.Shape13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape13.Height = 0.3125F;
            this.Shape13.Left = 0.0625F;
            this.Shape13.Name = "Shape13";
            this.Shape13.RoundingRadius = 9.999999F;
            this.Shape13.Top = 4F;
            this.Shape13.Width = 7.9375F;
            // 
            // Line19
            // 
            this.Line19.Border.BottomColor = System.Drawing.Color.Black;
            this.Line19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line19.Border.LeftColor = System.Drawing.Color.Black;
            this.Line19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line19.Border.RightColor = System.Drawing.Color.Black;
            this.Line19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line19.Border.TopColor = System.Drawing.Color.Black;
            this.Line19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line19.Height = 0.3125F;
            this.Line19.Left = 2.909091F;
            this.Line19.LineWeight = 1F;
            this.Line19.Name = "Line19";
            this.Line19.Top = 4F;
            this.Line19.Width = 0F;
            this.Line19.X1 = 2.909091F;
            this.Line19.X2 = 2.909091F;
            this.Line19.Y1 = 4.3125F;
            this.Line19.Y2 = 4F;
            // 
            // Line20
            // 
            this.Line20.Border.BottomColor = System.Drawing.Color.Black;
            this.Line20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line20.Border.LeftColor = System.Drawing.Color.Black;
            this.Line20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line20.Border.RightColor = System.Drawing.Color.Black;
            this.Line20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line20.Border.TopColor = System.Drawing.Color.Black;
            this.Line20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line20.Height = 0.3125F;
            this.Line20.Left = 5.818182F;
            this.Line20.LineWeight = 1F;
            this.Line20.Name = "Line20";
            this.Line20.Top = 4F;
            this.Line20.Width = 0F;
            this.Line20.X1 = 5.818182F;
            this.Line20.X2 = 5.818182F;
            this.Line20.Y1 = 4.3125F;
            this.Line20.Y2 = 4F;
            // 
            // Label46
            // 
            this.Label46.Border.BottomColor = System.Drawing.Color.Black;
            this.Label46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label46.Border.LeftColor = System.Drawing.Color.Black;
            this.Label46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label46.Border.RightColor = System.Drawing.Color.Black;
            this.Label46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label46.Border.TopColor = System.Drawing.Color.Black;
            this.Label46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label46.Height = 0.125F;
            this.Label46.HyperLink = "";
            this.Label46.Left = 0.1534091F;
            this.Label46.Name = "Label46";
            this.Label46.Style = "color: Gray; font-size: 8pt; ";
            this.Label46.Text = "Cubierta Seleccionada / Coverage Selected";
            this.Label46.Top = 4F;
            this.Label46.Width = 2.272728F;
            // 
            // Label47
            // 
            this.Label47.Border.BottomColor = System.Drawing.Color.Black;
            this.Label47.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label47.Border.LeftColor = System.Drawing.Color.Black;
            this.Label47.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label47.Border.RightColor = System.Drawing.Color.Black;
            this.Label47.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label47.Border.TopColor = System.Drawing.Color.Black;
            this.Label47.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label47.Height = 0.125F;
            this.Label47.HyperLink = "";
            this.Label47.Left = 2.971591F;
            this.Label47.Name = "Label47";
            this.Label47.Style = "color: Gray; text-align: center; font-size: 8pt; ";
            this.Label47.Text = "Plan Seleccionado / Plan Selected";
            this.Label47.Top = 4F;
            this.Label47.Width = 2.909091F;
            // 
            // Label48
            // 
            this.Label48.Border.BottomColor = System.Drawing.Color.Black;
            this.Label48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label48.Border.LeftColor = System.Drawing.Color.Black;
            this.Label48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label48.Border.RightColor = System.Drawing.Color.Black;
            this.Label48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label48.Border.TopColor = System.Drawing.Color.Black;
            this.Label48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label48.Height = 0.2F;
            this.Label48.HyperLink = "";
            this.Label48.Left = 3.454545F;
            this.Label48.Name = "Label48";
            this.Label48.Style = "color: Gray; font-size: 8pt; ";
            this.Label48.Text = "Meses / Month -";
            this.Label48.Top = 4.125F;
            this.Label48.Width = 0.8181826F;
            // 
            // Label49
            // 
            this.Label49.Border.BottomColor = System.Drawing.Color.Black;
            this.Label49.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label49.Border.LeftColor = System.Drawing.Color.Black;
            this.Label49.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label49.Border.RightColor = System.Drawing.Color.Black;
            this.Label49.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label49.Border.TopColor = System.Drawing.Color.Black;
            this.Label49.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label49.Height = 0.2F;
            this.Label49.HyperLink = "";
            this.Label49.Left = 4.727273F;
            this.Label49.Name = "Label49";
            this.Label49.Style = "color: Gray; font-size: 8pt; ";
            this.Label49.Text = ",000 Millas / Miles";
            this.Label49.Top = 4.125F;
            this.Label49.Width = 1F;
            // 
            // Label50
            // 
            this.Label50.Border.BottomColor = System.Drawing.Color.Black;
            this.Label50.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label50.Border.LeftColor = System.Drawing.Color.Black;
            this.Label50.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label50.Border.RightColor = System.Drawing.Color.Black;
            this.Label50.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label50.Border.TopColor = System.Drawing.Color.Black;
            this.Label50.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label50.Height = 0.125F;
            this.Label50.HyperLink = "";
            this.Label50.Left = 5.880682F;
            this.Label50.Name = "Label50";
            this.Label50.Style = "color: Gray; text-align: center; font-size: 8pt; ";
            this.Label50.Text = "Deducible / Deductible";
            this.Label50.Top = 4F;
            this.Label50.Width = 2.119319F;
            // 
            // Label51
            // 
            this.Label51.Border.BottomColor = System.Drawing.Color.Black;
            this.Label51.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label51.Border.LeftColor = System.Drawing.Color.Black;
            this.Label51.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label51.Border.RightColor = System.Drawing.Color.Black;
            this.Label51.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label51.Border.TopColor = System.Drawing.Color.Black;
            this.Label51.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label51.Height = 0.2F;
            this.Label51.HyperLink = "";
            this.Label51.Left = 2.90767F;
            this.Label51.MultiLine = false;
            this.Label51.Name = "Label51";
            this.Label51.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label51.Text = "Información del Precio / Contract Price Information";
            this.Label51.Top = 4.3125F;
            this.Label51.Width = 2.830493F;
            // 
            // Shape14
            // 
            this.Shape14.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape14.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape14.Border.RightColor = System.Drawing.Color.Black;
            this.Shape14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape14.Border.TopColor = System.Drawing.Color.Black;
            this.Shape14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape14.Height = 0.3020835F;
            this.Shape14.Left = 0.0625F;
            this.Shape14.Name = "Shape14";
            this.Shape14.RoundingRadius = 9.999999F;
            this.Shape14.Top = 4.510417F;
            this.Shape14.Width = 7.9375F;
            // 
            // Label52
            // 
            this.Label52.Border.BottomColor = System.Drawing.Color.Black;
            this.Label52.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label52.Border.LeftColor = System.Drawing.Color.Black;
            this.Label52.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label52.Border.RightColor = System.Drawing.Color.Black;
            this.Label52.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label52.Border.TopColor = System.Drawing.Color.Black;
            this.Label52.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label52.Height = 0.125F;
            this.Label52.HyperLink = "";
            this.Label52.Left = 0.1534091F;
            this.Label52.Name = "Label52";
            this.Label52.Style = "color: Gray; font-size: 8pt; ";
            this.Label52.Text = "Clasificación";
            this.Label52.Top = 4.5F;
            this.Label52.Width = 0.8181819F;
            // 
            // Label53
            // 
            this.Label53.Border.BottomColor = System.Drawing.Color.Black;
            this.Label53.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label53.Border.LeftColor = System.Drawing.Color.Black;
            this.Label53.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label53.Border.RightColor = System.Drawing.Color.Black;
            this.Label53.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label53.Border.TopColor = System.Drawing.Color.Black;
            this.Label53.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label53.Height = 0.125F;
            this.Label53.HyperLink = "";
            this.Label53.Left = 0.1534091F;
            this.Label53.Name = "Label53";
            this.Label53.Style = "color: Gray; font-size: 8pt; ";
            this.Label53.Text = "Clasification";
            this.Label53.Top = 4.625F;
            this.Label53.Width = 0.8181819F;
            // 
            // Line21
            // 
            this.Line21.Border.BottomColor = System.Drawing.Color.Black;
            this.Line21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line21.Border.LeftColor = System.Drawing.Color.Black;
            this.Line21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line21.Border.RightColor = System.Drawing.Color.Black;
            this.Line21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line21.Border.TopColor = System.Drawing.Color.Black;
            this.Line21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line21.Height = 0.3125F;
            this.Line21.Left = 4.181818F;
            this.Line21.LineWeight = 1F;
            this.Line21.Name = "Line21";
            this.Line21.Top = 4.5F;
            this.Line21.Width = 0F;
            this.Line21.X1 = 4.181818F;
            this.Line21.X2 = 4.181818F;
            this.Line21.Y1 = 4.8125F;
            this.Line21.Y2 = 4.5F;
            // 
            // Label54
            // 
            this.Label54.Border.BottomColor = System.Drawing.Color.Black;
            this.Label54.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label54.Border.LeftColor = System.Drawing.Color.Black;
            this.Label54.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label54.Border.RightColor = System.Drawing.Color.Black;
            this.Label54.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label54.Border.TopColor = System.Drawing.Color.Black;
            this.Label54.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label54.Height = 0.125F;
            this.Label54.HyperLink = "";
            this.Label54.Left = 4.363637F;
            this.Label54.Name = "Label54";
            this.Label54.Style = "color: Gray; font-size: 8pt; ";
            this.Label54.Text = "Total Price";
            this.Label54.Top = 4.625F;
            this.Label54.Width = 0.8181819F;
            // 
            // Label55
            // 
            this.Label55.Border.BottomColor = System.Drawing.Color.Black;
            this.Label55.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label55.Border.LeftColor = System.Drawing.Color.Black;
            this.Label55.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label55.Border.RightColor = System.Drawing.Color.Black;
            this.Label55.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label55.Border.TopColor = System.Drawing.Color.Black;
            this.Label55.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label55.Height = 0.125F;
            this.Label55.HyperLink = "";
            this.Label55.Left = 4.363637F;
            this.Label55.Name = "Label55";
            this.Label55.Style = "color: Gray; font-size: 8pt; ";
            this.Label55.Text = "PrecioTotal";
            this.Label55.Top = 4.5F;
            this.Label55.Width = 0.8181819F;
            // 
            // Label56
            // 
            this.Label56.Border.BottomColor = System.Drawing.Color.Black;
            this.Label56.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label56.Border.LeftColor = System.Drawing.Color.Black;
            this.Label56.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label56.Border.RightColor = System.Drawing.Color.Black;
            this.Label56.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label56.Border.TopColor = System.Drawing.Color.Black;
            this.Label56.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label56.Height = 0.2F;
            this.Label56.HyperLink = "";
            this.Label56.Left = 0.0625F;
            this.Label56.MultiLine = false;
            this.Label56.Name = "Label56";
            this.Label56.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label56.Text = "Información del Tenedor del Gravamen / Lienholder Information";
            this.Label56.Top = 4.8125F;
            this.Label56.Width = 3.636364F;
            // 
            // Line22
            // 
            this.Line22.Border.BottomColor = System.Drawing.Color.Black;
            this.Line22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line22.Border.LeftColor = System.Drawing.Color.Black;
            this.Line22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line22.Border.RightColor = System.Drawing.Color.Black;
            this.Line22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line22.Border.TopColor = System.Drawing.Color.Black;
            this.Line22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line22.Height = 0.625F;
            this.Line22.Left = 2.727273F;
            this.Line22.LineWeight = 1F;
            this.Line22.Name = "Line22";
            this.Line22.Top = 5F;
            this.Line22.Width = 0F;
            this.Line22.X1 = 2.727273F;
            this.Line22.X2 = 2.727273F;
            this.Line22.Y1 = 5.625F;
            this.Line22.Y2 = 5F;
            // 
            // Line23
            // 
            this.Line23.Border.BottomColor = System.Drawing.Color.Black;
            this.Line23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line23.Border.LeftColor = System.Drawing.Color.Black;
            this.Line23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line23.Border.RightColor = System.Drawing.Color.Black;
            this.Line23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line23.Border.TopColor = System.Drawing.Color.Black;
            this.Line23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line23.Height = 0F;
            this.Line23.Left = 0.0625F;
            this.Line23.LineWeight = 1F;
            this.Line23.Name = "Line23";
            this.Line23.Top = 5.3125F;
            this.Line23.Width = 2.6875F;
            this.Line23.X1 = 2.75F;
            this.Line23.X2 = 0.0625F;
            this.Line23.Y1 = 5.3125F;
            this.Line23.Y2 = 5.3125F;
            // 
            // Label57
            // 
            this.Label57.Border.BottomColor = System.Drawing.Color.Black;
            this.Label57.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label57.Border.LeftColor = System.Drawing.Color.Black;
            this.Label57.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label57.Border.RightColor = System.Drawing.Color.Black;
            this.Label57.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label57.Border.TopColor = System.Drawing.Color.Black;
            this.Label57.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label57.Height = 0.125F;
            this.Label57.HyperLink = "";
            this.Label57.Left = 0.1534091F;
            this.Label57.Name = "Label57";
            this.Label57.Style = "color: Gray; font-size: 8pt; ";
            this.Label57.Text = "Nombre / Name";
            this.Label57.Top = 5F;
            this.Label57.Width = 0.9090909F;
            // 
            // Label58
            // 
            this.Label58.Border.BottomColor = System.Drawing.Color.Black;
            this.Label58.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label58.Border.LeftColor = System.Drawing.Color.Black;
            this.Label58.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label58.Border.RightColor = System.Drawing.Color.Black;
            this.Label58.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label58.Border.TopColor = System.Drawing.Color.Black;
            this.Label58.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label58.Height = 0.125F;
            this.Label58.HyperLink = "";
            this.Label58.Left = 0.1534091F;
            this.Label58.Name = "Label58";
            this.Label58.Style = "color: Gray; font-size: 8pt; ";
            this.Label58.Text = "Teléfono / Telephone";
            this.Label58.Top = 5.3125F;
            this.Label58.Width = 1.090909F;
            // 
            // Label59
            // 
            this.Label59.Border.BottomColor = System.Drawing.Color.Black;
            this.Label59.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label59.Border.LeftColor = System.Drawing.Color.Black;
            this.Label59.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label59.Border.RightColor = System.Drawing.Color.Black;
            this.Label59.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label59.Border.TopColor = System.Drawing.Color.Black;
            this.Label59.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label59.Height = 0.2F;
            this.Label59.HyperLink = "";
            this.Label59.Left = 2.909091F;
            this.Label59.Name = "Label59";
            this.Label59.Style = "color: Gray; font-size: 8pt; ";
            this.Label59.Text = "Dirección / Address";
            this.Label59.Top = 5F;
            this.Label59.Width = 1.0625F;
            // 
            // Shape16
            // 
            this.Shape16.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape16.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape16.Border.RightColor = System.Drawing.Color.Black;
            this.Shape16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape16.Border.TopColor = System.Drawing.Color.Black;
            this.Shape16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape16.Height = 2.5625F;
            this.Shape16.Left = 0.0625F;
            this.Shape16.Name = "Shape16";
            this.Shape16.RoundingRadius = 9.999999F;
            this.Shape16.Top = 5F;
            this.Shape16.Width = 5.272728F;
            // 
            // Label60
            // 
            this.Label60.Border.BottomColor = System.Drawing.Color.Black;
            this.Label60.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label60.Border.LeftColor = System.Drawing.Color.Black;
            this.Label60.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label60.Border.RightColor = System.Drawing.Color.Black;
            this.Label60.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label60.Border.TopColor = System.Drawing.Color.Black;
            this.Label60.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label60.Height = 0.6750001F;
            this.Label60.HyperLink = "";
            this.Label60.Left = 0.1534091F;
            this.Label60.Name = "Label60";
            this.Label60.Style = "color: Gray; font-size: 8pt; ";
            this.Label60.Text = resources.GetString("Label60.Text");
            this.Label60.Top = 5.6875F;
            this.Label60.Width = 5.119318F;
            // 
            // Label61
            // 
            this.Label61.Border.BottomColor = System.Drawing.Color.Black;
            this.Label61.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label61.Border.LeftColor = System.Drawing.Color.Black;
            this.Label61.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label61.Border.RightColor = System.Drawing.Color.Black;
            this.Label61.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label61.Border.TopColor = System.Drawing.Color.Black;
            this.Label61.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label61.Height = 0.1875F;
            this.Label61.HyperLink = "";
            this.Label61.Left = 2.909091F;
            this.Label61.Name = "Label61";
            this.Label61.Style = "color: Black; font-size: 8pt; vertical-align: middle; ";
            this.Label61.Text = "refund resulting from cancellation.";
            this.Label61.Top = 6.1875F;
            this.Label61.Width = 1.880682F;
            // 
            // Label62
            // 
            this.Label62.Border.BottomColor = System.Drawing.Color.Black;
            this.Label62.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label62.Border.LeftColor = System.Drawing.Color.Black;
            this.Label62.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label62.Border.RightColor = System.Drawing.Color.Black;
            this.Label62.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label62.Border.TopColor = System.Drawing.Color.Black;
            this.Label62.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label62.Height = 0.5625F;
            this.Label62.HyperLink = "";
            this.Label62.Left = 0.1534091F;
            this.Label62.Name = "Label62";
            this.Label62.Style = "color: Gray; font-size: 8pt; ";
            this.Label62.Text = resources.GetString("Label62.Text");
            this.Label62.Top = 6.375F;
            this.Label62.Width = 5.119318F;
            // 
            // Label63
            // 
            this.Label63.Border.BottomColor = System.Drawing.Color.Black;
            this.Label63.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label63.Border.LeftColor = System.Drawing.Color.Black;
            this.Label63.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label63.Border.RightColor = System.Drawing.Color.Black;
            this.Label63.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label63.Border.TopColor = System.Drawing.Color.Black;
            this.Label63.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label63.Height = 0.1875F;
            this.Label63.HyperLink = "";
            this.Label63.Left = 0.1534091F;
            this.Label63.Name = "Label63";
            this.Label63.Style = "color: Black; font-size: 8pt; ";
            this.Label63.Text = "The benefits provided  may duplicate  express  manufacturer\'s  or  seller\'s warra" +
                "nties  and  / or";
            this.Label63.Top = 6.9375F;
            this.Label63.Width = 5F;
            // 
            // Label64
            // 
            this.Label64.Border.BottomColor = System.Drawing.Color.Black;
            this.Label64.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label64.Border.LeftColor = System.Drawing.Color.Black;
            this.Label64.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label64.Border.RightColor = System.Drawing.Color.Black;
            this.Label64.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label64.Border.TopColor = System.Drawing.Color.Black;
            this.Label64.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label64.Height = 0.1875F;
            this.Label64.HyperLink = "";
            this.Label64.Left = 4.857955F;
            this.Label64.Name = "Label64";
            this.Label64.Style = "color: Gray; font-size: 8pt; ";
            this.Label64.Text = "implied";
            this.Label64.Top = 6.9375F;
            this.Label64.Width = 0.3863636F;
            // 
            // Label65
            // 
            this.Label65.Border.BottomColor = System.Drawing.Color.Black;
            this.Label65.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label65.Border.LeftColor = System.Drawing.Color.Black;
            this.Label65.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label65.Border.RightColor = System.Drawing.Color.Black;
            this.Label65.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label65.Border.TopColor = System.Drawing.Color.Black;
            this.Label65.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label65.Height = 0.4375F;
            this.Label65.HyperLink = "";
            this.Label65.Left = 0.1534091F;
            this.Label65.Name = "Label65";
            this.Label65.Style = "color: Gray; font-size: 8pt; ";
            this.Label65.Text = resources.GetString("Label65.Text");
            this.Label65.Top = 7.0625F;
            this.Label65.Width = 5.119318F;
            // 
            // Label66
            // 
            this.Label66.Border.BottomColor = System.Drawing.Color.Black;
            this.Label66.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label66.Border.LeftColor = System.Drawing.Color.Black;
            this.Label66.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label66.Border.RightColor = System.Drawing.Color.Black;
            this.Label66.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label66.Border.TopColor = System.Drawing.Color.Black;
            this.Label66.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label66.Height = 0.2F;
            this.Label66.HyperLink = "";
            this.Label66.Left = 5.517045F;
            this.Label66.Name = "Label66";
            this.Label66.Style = "color: Gray; font-size: 8pt; ";
            this.Label66.Text = "Desde / From:";
            this.Label66.Top = 5.0625F;
            this.Label66.Width = 0.8181819F;
            // 
            // Label67
            // 
            this.Label67.Border.BottomColor = System.Drawing.Color.Black;
            this.Label67.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label67.Border.LeftColor = System.Drawing.Color.Black;
            this.Label67.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label67.Border.RightColor = System.Drawing.Color.Black;
            this.Label67.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label67.Border.TopColor = System.Drawing.Color.Black;
            this.Label67.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label67.Height = 0.2F;
            this.Label67.HyperLink = "";
            this.Label67.Left = 5.426137F;
            this.Label67.MultiLine = false;
            this.Label67.Name = "Label67";
            this.Label67.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label67.Text = "Período de la Póliza / Policy Period";
            this.Label67.Top = 4.8125F;
            this.Label67.Width = 1.909091F;
            // 
            // Label68
            // 
            this.Label68.Border.BottomColor = System.Drawing.Color.Black;
            this.Label68.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label68.Border.LeftColor = System.Drawing.Color.Black;
            this.Label68.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label68.Border.RightColor = System.Drawing.Color.Black;
            this.Label68.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label68.Border.TopColor = System.Drawing.Color.Black;
            this.Label68.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label68.Height = 0.2F;
            this.Label68.HyperLink = "";
            this.Label68.Left = 5.517045F;
            this.Label68.Name = "Label68";
            this.Label68.Style = "color: Gray; font-size: 8pt; ";
            this.Label68.Text = "Fecha de Emisión / Effective Date";
            this.Label68.Top = 5.25F;
            this.Label68.Width = 1.727272F;
            // 
            // Label69
            // 
            this.Label69.Border.BottomColor = System.Drawing.Color.Black;
            this.Label69.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label69.Border.LeftColor = System.Drawing.Color.Black;
            this.Label69.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label69.Border.RightColor = System.Drawing.Color.Black;
            this.Label69.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label69.Border.TopColor = System.Drawing.Color.Black;
            this.Label69.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label69.Height = 0.2F;
            this.Label69.HyperLink = "";
            this.Label69.Left = 5.517045F;
            this.Label69.Name = "Label69";
            this.Label69.Style = "color: Gray; font-size: 8pt; ";
            this.Label69.Text = "Fecha de Expiración / Expiration Date";
            this.Label69.Top = 5.75F;
            this.Label69.Width = 2.181818F;
            // 
            // Label70
            // 
            this.Label70.Border.BottomColor = System.Drawing.Color.Black;
            this.Label70.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label70.Border.LeftColor = System.Drawing.Color.Black;
            this.Label70.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label70.Border.RightColor = System.Drawing.Color.Black;
            this.Label70.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label70.Border.TopColor = System.Drawing.Color.Black;
            this.Label70.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label70.Height = 0.2F;
            this.Label70.HyperLink = "";
            this.Label70.Left = 5.517045F;
            this.Label70.Name = "Label70";
            this.Label70.Style = "color: Gray; font-size: 8pt; ";
            this.Label70.Text = "Hasta / To:";
            this.Label70.Top = 5.5625F;
            this.Label70.Width = 0.8181819F;
            // 
            // Label71
            // 
            this.Label71.Border.BottomColor = System.Drawing.Color.Black;
            this.Label71.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label71.Border.LeftColor = System.Drawing.Color.Black;
            this.Label71.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label71.Border.RightColor = System.Drawing.Color.Black;
            this.Label71.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label71.Border.TopColor = System.Drawing.Color.Black;
            this.Label71.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label71.Height = 0.1875F;
            this.Label71.HyperLink = "";
            this.Label71.Left = 6.454546F;
            this.Label71.Name = "Label71";
            this.Label71.Style = "color: Gray; font-size: 8pt; ";
            this.Label71.Text = "o / or";
            this.Label71.Top = 5.9375F;
            this.Label71.Width = 0.3579545F;
            // 
            // Label72
            // 
            this.Label72.Border.BottomColor = System.Drawing.Color.Black;
            this.Label72.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label72.Border.LeftColor = System.Drawing.Color.Black;
            this.Label72.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label72.Border.RightColor = System.Drawing.Color.Black;
            this.Label72.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label72.Border.TopColor = System.Drawing.Color.Black;
            this.Label72.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label72.Height = 0.2F;
            this.Label72.HyperLink = "";
            this.Label72.Left = 6.181818F;
            this.Label72.Name = "Label72";
            this.Label72.Style = "color: Gray; text-align: center; font-size: 8pt; ";
            this.Label72.Text = "Millaje de Expiración";
            this.Label72.Top = 6.3125F;
            this.Label72.Width = 1.09091F;
            // 
            // Label73
            // 
            this.Label73.Border.BottomColor = System.Drawing.Color.Black;
            this.Label73.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label73.Border.LeftColor = System.Drawing.Color.Black;
            this.Label73.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label73.Border.RightColor = System.Drawing.Color.Black;
            this.Label73.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label73.Border.TopColor = System.Drawing.Color.Black;
            this.Label73.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label73.Height = 0.2F;
            this.Label73.HyperLink = "";
            this.Label73.Left = 6.181818F;
            this.Label73.Name = "Label73";
            this.Label73.Style = "color: Gray; text-align: center; font-size: 8pt; ";
            this.Label73.Text = "Expiration Mileage";
            this.Label73.Top = 6.4375F;
            this.Label73.Width = 1.09091F;
            // 
            // Label74
            // 
            this.Label74.Border.BottomColor = System.Drawing.Color.Black;
            this.Label74.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label74.Border.LeftColor = System.Drawing.Color.Black;
            this.Label74.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label74.Border.RightColor = System.Drawing.Color.Black;
            this.Label74.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label74.Border.TopColor = System.Drawing.Color.Black;
            this.Label74.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label74.Height = 0.9375F;
            this.Label74.HyperLink = "";
            this.Label74.Left = 5.517045F;
            this.Label74.Name = "Label74";
            this.Label74.Style = "color: Gray; font-size: 8pt; ";
            this.Label74.Text = resources.GetString("Label74.Text");
            this.Label74.Top = 6.625F;
            this.Label74.Width = 2.363636F;
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
            this.Label77.Left = 2.971591F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-decoration: none; text-align: center; font-weight: bold; font-size: 8pt; fon" +
                "t-family: Times New Roman; ";
            this.Label77.Text = "Vendedor del Contrato / Contract Seller";
            this.Label77.Top = 8.375F;
            this.Label77.Width = 2.493371F;
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
            this.Label78.Height = 0.1875F;
            this.Label78.HyperLink = "";
            this.Label78.Left = 5.744318F;
            this.Label78.MultiLine = false;
            this.Label78.Name = "Label78";
            this.Label78.Style = "text-align: center; font-weight: bold; font-size: 8pt; font-family: Times New Rom" +
                "an; ";
            this.Label78.Text = "Tenedor del Contrato / Contract Holder";
            this.Label78.Top = 8.375F;
            this.Label78.Width = 2.255681F;
            // 
            // Line24
            // 
            this.Line24.Border.BottomColor = System.Drawing.Color.Black;
            this.Line24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line24.Border.LeftColor = System.Drawing.Color.Black;
            this.Line24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line24.Border.RightColor = System.Drawing.Color.Black;
            this.Line24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line24.Border.TopColor = System.Drawing.Color.Black;
            this.Line24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line24.Height = 0F;
            this.Line24.Left = 2.909091F;
            this.Line24.LineWeight = 1F;
            this.Line24.Name = "Line24";
            this.Line24.Top = 8.375F;
            this.Line24.Width = 2.454546F;
            this.Line24.X1 = 2.909091F;
            this.Line24.X2 = 5.363637F;
            this.Line24.Y1 = 8.375F;
            this.Line24.Y2 = 8.375F;
            // 
            // Line25
            // 
            this.Line25.Border.BottomColor = System.Drawing.Color.Black;
            this.Line25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line25.Border.LeftColor = System.Drawing.Color.Black;
            this.Line25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line25.Border.RightColor = System.Drawing.Color.Black;
            this.Line25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line25.Border.TopColor = System.Drawing.Color.Black;
            this.Line25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line25.Height = 0F;
            this.Line25.Left = 5.727273F;
            this.Line25.LineWeight = 1F;
            this.Line25.Name = "Line25";
            this.Line25.Top = 8.375F;
            this.Line25.Width = 2.272727F;
            this.Line25.X1 = 5.727273F;
            this.Line25.X2 = 8F;
            this.Line25.Y1 = 8.375F;
            this.Line25.Y2 = 8.375F;
            // 
            // Label80
            // 
            this.Label80.Border.BottomColor = System.Drawing.Color.Black;
            this.Label80.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label80.Border.LeftColor = System.Drawing.Color.Black;
            this.Label80.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label80.Border.RightColor = System.Drawing.Color.Black;
            this.Label80.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label80.Border.TopColor = System.Drawing.Color.Black;
            this.Label80.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label80.Height = 0.1875F;
            this.Label80.HyperLink = "";
            this.Label80.Left = 0.0625F;
            this.Label80.MultiLine = false;
            this.Label80.Name = "Label80";
            this.Label80.Style = "text-decoration: none; text-align: left; font-weight: bold; font-size: 8pt; font-" +
                "family: Times New Roman; ";
            this.Label80.Text = "Representante Autorizado";
            this.Label80.Top = 8.5F;
            this.Label80.Width = 2F;
            // 
            // Label81
            // 
            this.Label81.Border.BottomColor = System.Drawing.Color.Black;
            this.Label81.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label81.Border.LeftColor = System.Drawing.Color.Black;
            this.Label81.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label81.Border.RightColor = System.Drawing.Color.Black;
            this.Label81.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label81.Border.TopColor = System.Drawing.Color.Black;
            this.Label81.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label81.Height = 0.1875F;
            this.Label81.HyperLink = "";
            this.Label81.Left = 0.0625F;
            this.Label81.MultiLine = false;
            this.Label81.Name = "Label81";
            this.Label81.Style = "text-decoration: none; text-align: left; font-weight: bold; font-size: 8pt; font-" +
                "family: Times New Roman; ";
            this.Label81.Text = "en San Juan, Puerto Rico";
            this.Label81.Top = 8.65625F;
            this.Label81.Width = 2F;
            // 
            // Label83
            // 
            this.Label83.Border.BottomColor = System.Drawing.Color.Black;
            this.Label83.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label83.Border.LeftColor = System.Drawing.Color.Black;
            this.Label83.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label83.Border.RightColor = System.Drawing.Color.Black;
            this.Label83.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label83.Border.TopColor = System.Drawing.Color.Black;
            this.Label83.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label83.Height = 0.2F;
            this.Label83.HyperLink = "";
            this.Label83.Left = 0.0909091F;
            this.Label83.MultiLine = false;
            this.Label83.Name = "Label83";
            this.Label83.Style = "font-weight: bold; font-size: 8pt; ";
            this.Label83.Text = "117 Eleanor Roosevelt Ave., Suite 302";
            this.Label83.Top = 0.4375F;
            this.Label83.Width = 2.335228F;
            // 
            // Label82
            // 
            this.Label82.Border.BottomColor = System.Drawing.Color.Black;
            this.Label82.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label82.Border.LeftColor = System.Drawing.Color.Black;
            this.Label82.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label82.Border.RightColor = System.Drawing.Color.Black;
            this.Label82.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label82.Border.TopColor = System.Drawing.Color.Black;
            this.Label82.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label82.Height = 0.2F;
            this.Label82.HyperLink = "";
            this.Label82.Left = 4.426137F;
            this.Label82.MultiLine = false;
            this.Label82.Name = "Label82";
            this.Label82.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label82.Text = "San Juan";
            this.Label82.Top = 0.4375F;
            this.Label82.Width = 1.181818F;
            // 
            // Label84
            // 
            this.Label84.Border.BottomColor = System.Drawing.Color.Black;
            this.Label84.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label84.Border.LeftColor = System.Drawing.Color.Black;
            this.Label84.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label84.Border.RightColor = System.Drawing.Color.Black;
            this.Label84.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label84.Border.TopColor = System.Drawing.Color.Black;
            this.Label84.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label84.Height = 0.2F;
            this.Label84.HyperLink = "";
            this.Label84.Left = 5.607955F;
            this.Label84.MultiLine = false;
            this.Label84.Name = "Label84";
            this.Label84.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label84.Text = "PR";
            this.Label84.Top = 0.4375F;
            this.Label84.Width = 1.181818F;
            // 
            // Label85
            // 
            this.Label85.Border.BottomColor = System.Drawing.Color.Black;
            this.Label85.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label85.Border.LeftColor = System.Drawing.Color.Black;
            this.Label85.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label85.Border.RightColor = System.Drawing.Color.Black;
            this.Label85.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label85.Border.TopColor = System.Drawing.Color.Black;
            this.Label85.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label85.Height = 0.2F;
            this.Label85.HyperLink = "";
            this.Label85.Left = 6.789773F;
            this.Label85.MultiLine = false;
            this.Label85.Name = "Label85";
            this.Label85.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label85.Text = "00918";
            this.Label85.Top = 0.4375F;
            this.Label85.Width = 1.210227F;
            // 
            // TxtSellerName
            // 
            this.TxtSellerName.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtSellerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSellerName.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtSellerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSellerName.Border.RightColor = System.Drawing.Color.Black;
            this.TxtSellerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSellerName.Border.TopColor = System.Drawing.Color.Black;
            this.TxtSellerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSellerName.Height = 0.2F;
            this.TxtSellerName.Left = 0.125F;
            this.TxtSellerName.MultiLine = false;
            this.TxtSellerName.Name = "TxtSellerName";
            this.TxtSellerName.Style = "font-weight: bold; font-size: 8pt; ";
            this.TxtSellerName.Text = "TxtSellerName";
            this.TxtSellerName.Top = 0.9375F;
            this.TxtSellerName.Width = 3.392045F;
            // 
            // TxtSellerAddress
            // 
            this.TxtSellerAddress.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtSellerAddress.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSellerAddress.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtSellerAddress.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSellerAddress.Border.RightColor = System.Drawing.Color.Black;
            this.TxtSellerAddress.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSellerAddress.Border.TopColor = System.Drawing.Color.Black;
            this.TxtSellerAddress.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSellerAddress.Height = 0.2F;
            this.TxtSellerAddress.Left = 0.1534091F;
            this.TxtSellerAddress.MultiLine = false;
            this.TxtSellerAddress.Name = "TxtSellerAddress";
            this.TxtSellerAddress.Style = "font-weight: bold; font-size: 8pt; ";
            this.TxtSellerAddress.Text = "TxtSellerAddress";
            this.TxtSellerAddress.Top = 1.3125F;
            this.TxtSellerAddress.Width = 3.392045F;
            // 
            // TxtSellerCity
            // 
            this.TxtSellerCity.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtSellerCity.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSellerCity.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtSellerCity.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSellerCity.Border.RightColor = System.Drawing.Color.Black;
            this.TxtSellerCity.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSellerCity.Border.TopColor = System.Drawing.Color.Black;
            this.TxtSellerCity.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSellerCity.Height = 0.2F;
            this.TxtSellerCity.Left = 4.426137F;
            this.TxtSellerCity.MultiLine = false;
            this.TxtSellerCity.Name = "TxtSellerCity";
            this.TxtSellerCity.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TxtSellerCity.Text = "TxtSellerCity";
            this.TxtSellerCity.Top = 1.3125F;
            this.TxtSellerCity.Width = 1.181818F;
            // 
            // TxtSellerState
            // 
            this.TxtSellerState.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtSellerState.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSellerState.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtSellerState.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSellerState.Border.RightColor = System.Drawing.Color.Black;
            this.TxtSellerState.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSellerState.Border.TopColor = System.Drawing.Color.Black;
            this.TxtSellerState.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSellerState.Height = 0.2F;
            this.TxtSellerState.Left = 5.607955F;
            this.TxtSellerState.MultiLine = false;
            this.TxtSellerState.Name = "TxtSellerState";
            this.TxtSellerState.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TxtSellerState.Text = "TxtSellerState";
            this.TxtSellerState.Top = 1.3125F;
            this.TxtSellerState.Width = 1.181818F;
            // 
            // TxtSellerZip
            // 
            this.TxtSellerZip.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtSellerZip.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSellerZip.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtSellerZip.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSellerZip.Border.RightColor = System.Drawing.Color.Black;
            this.TxtSellerZip.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSellerZip.Border.TopColor = System.Drawing.Color.Black;
            this.TxtSellerZip.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSellerZip.Height = 0.2F;
            this.TxtSellerZip.Left = 6.789773F;
            this.TxtSellerZip.MultiLine = false;
            this.TxtSellerZip.Name = "TxtSellerZip";
            this.TxtSellerZip.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TxtSellerZip.Text = "TxtSellerZip";
            this.TxtSellerZip.Top = 1.3125F;
            this.TxtSellerZip.Width = 1.210228F;
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
            this.TxtCustomerCity.Left = 4.426137F;
            this.TxtCustomerCity.MultiLine = false;
            this.TxtCustomerCity.Name = "TxtCustomerCity";
            this.TxtCustomerCity.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TxtCustomerCity.Text = "TxtCustomerCity";
            this.TxtCustomerCity.Top = 2.1875F;
            this.TxtCustomerCity.Width = 1.181818F;
            // 
            // TxtCustomerState
            // 
            this.TxtCustomerState.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCustomerState.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerState.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCustomerState.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerState.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCustomerState.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerState.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCustomerState.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerState.Height = 0.2F;
            this.TxtCustomerState.Left = 5.607955F;
            this.TxtCustomerState.MultiLine = false;
            this.TxtCustomerState.Name = "TxtCustomerState";
            this.TxtCustomerState.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TxtCustomerState.Text = "TxtCustomerState";
            this.TxtCustomerState.Top = 2.1875F;
            this.TxtCustomerState.Width = 1.181818F;
            // 
            // TxtCustomerZip
            // 
            this.TxtCustomerZip.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCustomerZip.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerZip.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCustomerZip.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerZip.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCustomerZip.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerZip.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCustomerZip.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerZip.Height = 0.2F;
            this.TxtCustomerZip.Left = 6.789773F;
            this.TxtCustomerZip.MultiLine = false;
            this.TxtCustomerZip.Name = "TxtCustomerZip";
            this.TxtCustomerZip.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TxtCustomerZip.Text = "TxtCustomerZip";
            this.TxtCustomerZip.Top = 2.1875F;
            this.TxtCustomerZip.Width = 1.210227F;
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
            this.TxtCustomerName.Left = 0.125F;
            this.TxtCustomerName.MultiLine = false;
            this.TxtCustomerName.Name = "TxtCustomerName";
            this.TxtCustomerName.Style = "font-weight: bold; font-size: 8pt; ";
            this.TxtCustomerName.Text = "TxtCustomerName";
            this.TxtCustomerName.Top = 1.8125F;
            this.TxtCustomerName.Width = 3.392045F;
            // 
            // TxtCustomerAddress
            // 
            this.TxtCustomerAddress.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCustomerAddress.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerAddress.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCustomerAddress.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerAddress.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCustomerAddress.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerAddress.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCustomerAddress.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerAddress.Height = 0.2F;
            this.TxtCustomerAddress.Left = 0.1534091F;
            this.TxtCustomerAddress.MultiLine = false;
            this.TxtCustomerAddress.Name = "TxtCustomerAddress";
            this.TxtCustomerAddress.Style = "font-weight: bold; font-size: 8pt; ";
            this.TxtCustomerAddress.Text = "TxtCustomerAddress";
            this.TxtCustomerAddress.Top = 2.1875F;
            this.TxtCustomerAddress.Width = 3.392045F;
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
            this.TxtYear.Left = 0.0625F;
            this.TxtYear.MultiLine = false;
            this.TxtYear.Name = "TxtYear";
            this.TxtYear.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TxtYear.Text = "TxtYear";
            this.TxtYear.Top = 2.75F;
            this.TxtYear.Width = 0.9090909F;
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
            this.TxtMake.Left = 0.9715909F;
            this.TxtMake.MultiLine = false;
            this.TxtMake.Name = "TxtMake";
            this.TxtMake.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TxtMake.Text = "TxtMake";
            this.TxtMake.Top = 2.75F;
            this.TxtMake.Width = 2F;
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
            this.TxtModel.Left = 2.971591F;
            this.TxtModel.MultiLine = false;
            this.TxtModel.Name = "TxtModel";
            this.TxtModel.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TxtModel.Text = "TxtModel";
            this.TxtModel.Top = 2.75F;
            this.TxtModel.Width = 2F;
            // 
            // TxtVinNo
            // 
            this.TxtVinNo.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtVinNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVinNo.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtVinNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVinNo.Border.RightColor = System.Drawing.Color.Black;
            this.TxtVinNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVinNo.Border.TopColor = System.Drawing.Color.Black;
            this.TxtVinNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVinNo.Height = 0.2F;
            this.TxtVinNo.Left = 4.971591F;
            this.TxtVinNo.MultiLine = false;
            this.TxtVinNo.Name = "TxtVinNo";
            this.TxtVinNo.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TxtVinNo.Text = "TxtVinNo";
            this.TxtVinNo.Top = 2.75F;
            this.TxtVinNo.Width = 3.028409F;
            // 
            // TxtVehicleCost
            // 
            this.TxtVehicleCost.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtVehicleCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVehicleCost.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtVehicleCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVehicleCost.Border.RightColor = System.Drawing.Color.Black;
            this.TxtVehicleCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVehicleCost.Border.TopColor = System.Drawing.Color.Black;
            this.TxtVehicleCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVehicleCost.Height = 0.2F;
            this.TxtVehicleCost.Left = 0.1875F;
            this.TxtVehicleCost.MultiLine = false;
            this.TxtVehicleCost.Name = "TxtVehicleCost";
            this.TxtVehicleCost.OutputFormat = resources.GetString("TxtVehicleCost.OutputFormat");
            this.TxtVehicleCost.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TxtVehicleCost.Text = "TxtVehicleCost";
            this.TxtVehicleCost.Top = 3.3125F;
            this.TxtVehicleCost.Width = 2.693182F;
            // 
            // TxtpurchaseDate
            // 
            this.TxtpurchaseDate.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtpurchaseDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtpurchaseDate.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtpurchaseDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtpurchaseDate.Border.RightColor = System.Drawing.Color.Black;
            this.TxtpurchaseDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtpurchaseDate.Border.TopColor = System.Drawing.Color.Black;
            this.TxtpurchaseDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtpurchaseDate.Height = 0.2F;
            this.TxtpurchaseDate.Left = 3.0625F;
            this.TxtpurchaseDate.MultiLine = false;
            this.TxtpurchaseDate.Name = "TxtpurchaseDate";
            this.TxtpurchaseDate.OutputFormat = resources.GetString("TxtpurchaseDate.OutputFormat");
            this.TxtpurchaseDate.Style = "font-weight: bold; font-size: 8pt; ";
            this.TxtpurchaseDate.Text = "TxtpurchaseDate";
            this.TxtpurchaseDate.Top = 3.3125F;
            this.TxtpurchaseDate.Width = 1.909091F;
            // 
            // TxteffectiveDate
            // 
            this.TxteffectiveDate.Border.BottomColor = System.Drawing.Color.Black;
            this.TxteffectiveDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxteffectiveDate.Border.LeftColor = System.Drawing.Color.Black;
            this.TxteffectiveDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxteffectiveDate.Border.RightColor = System.Drawing.Color.Black;
            this.TxteffectiveDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxteffectiveDate.Border.TopColor = System.Drawing.Color.Black;
            this.TxteffectiveDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxteffectiveDate.Height = 0.2F;
            this.TxteffectiveDate.Left = 5.034091F;
            this.TxteffectiveDate.MultiLine = false;
            this.TxteffectiveDate.Name = "TxteffectiveDate";
            this.TxteffectiveDate.OutputFormat = resources.GetString("TxteffectiveDate.OutputFormat");
            this.TxteffectiveDate.Style = "font-weight: bold; font-size: 8pt; ";
            this.TxteffectiveDate.Text = "TxteffectiveDate";
            this.TxteffectiveDate.Top = 3.3125F;
            this.TxteffectiveDate.Width = 1.181818F;
            // 
            // Txtodometer
            // 
            this.Txtodometer.Border.BottomColor = System.Drawing.Color.Black;
            this.Txtodometer.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Txtodometer.Border.LeftColor = System.Drawing.Color.Black;
            this.Txtodometer.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Txtodometer.Border.RightColor = System.Drawing.Color.Black;
            this.Txtodometer.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Txtodometer.Border.TopColor = System.Drawing.Color.Black;
            this.Txtodometer.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Txtodometer.Height = 0.2F;
            this.Txtodometer.Left = 3.971591F;
            this.Txtodometer.MultiLine = false;
            this.Txtodometer.Name = "Txtodometer";
            this.Txtodometer.Style = "font-weight: bold; font-size: 8pt; ";
            this.Txtodometer.Text = "Txtodometer";
            this.Txtodometer.Top = 3.625F;
            this.Txtodometer.Width = 1.545455F;
            // 
            // Label86
            // 
            this.Label86.Border.BottomColor = System.Drawing.Color.Black;
            this.Label86.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label86.Border.LeftColor = System.Drawing.Color.Black;
            this.Label86.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label86.Border.RightColor = System.Drawing.Color.Black;
            this.Label86.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label86.Border.TopColor = System.Drawing.Color.Black;
            this.Label86.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label86.Height = 0.2F;
            this.Label86.HyperLink = "";
            this.Label86.Left = 0.1534091F;
            this.Label86.MultiLine = false;
            this.Label86.Name = "Label86";
            this.Label86.Style = "font-weight: bold; font-size: 8pt; ";
            this.Label86.Text = "Contrato de Servicio";
            this.Label86.Top = 4.125F;
            this.Label86.Width = 1.636364F;
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
            this.TxtTerm.Left = 2.971591F;
            this.TxtTerm.MultiLine = false;
            this.TxtTerm.Name = "TxtTerm";
            this.TxtTerm.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TxtTerm.Text = "TxtTerm";
            this.TxtTerm.Top = 4.125F;
            this.TxtTerm.Width = 0.4545455F;
            // 
            // TxtMileage
            // 
            this.TxtMileage.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtMileage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMileage.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtMileage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMileage.Border.RightColor = System.Drawing.Color.Black;
            this.TxtMileage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMileage.Border.TopColor = System.Drawing.Color.Black;
            this.TxtMileage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMileage.Height = 0.2F;
            this.TxtMileage.Left = 4.392045F;
            this.TxtMileage.MultiLine = false;
            this.TxtMileage.Name = "TxtMileage";
            this.TxtMileage.OutputFormat = resources.GetString("TxtMileage.OutputFormat");
            this.TxtMileage.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TxtMileage.Text = "TxtMileage";
            this.TxtMileage.Top = 4.125F;
            this.TxtMileage.Width = 0.3636364F;
            // 
            // TxtDeductible
            // 
            this.TxtDeductible.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtDeductible.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDeductible.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtDeductible.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDeductible.Border.RightColor = System.Drawing.Color.Black;
            this.TxtDeductible.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDeductible.Border.TopColor = System.Drawing.Color.Black;
            this.TxtDeductible.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDeductible.Height = 0.2F;
            this.TxtDeductible.Left = 5.880682F;
            this.TxtDeductible.MultiLine = false;
            this.TxtDeductible.Name = "TxtDeductible";
            this.TxtDeductible.OutputFormat = resources.GetString("TxtDeductible.OutputFormat");
            this.TxtDeductible.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TxtDeductible.Text = "TxtDeductible";
            this.TxtDeductible.Top = 4.125F;
            this.TxtDeductible.Width = 2.119319F;
            // 
            // TxtClasification
            // 
            this.TxtClasification.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtClasification.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtClasification.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtClasification.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtClasification.Border.RightColor = System.Drawing.Color.Black;
            this.TxtClasification.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtClasification.Border.TopColor = System.Drawing.Color.Black;
            this.TxtClasification.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtClasification.Height = 0.2F;
            this.TxtClasification.Left = 1.125F;
            this.TxtClasification.MultiLine = false;
            this.TxtClasification.Name = "TxtClasification";
            this.TxtClasification.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TxtClasification.Text = "TxtClasification";
            this.TxtClasification.Top = 4.5625F;
            this.TxtClasification.Width = 0.5454546F;
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
            this.TxtTotalPremium.Left = 6.153409F;
            this.TxtTotalPremium.MultiLine = false;
            this.TxtTotalPremium.Name = "TxtTotalPremium";
            this.TxtTotalPremium.OutputFormat = resources.GetString("TxtTotalPremium.OutputFormat");
            this.TxtTotalPremium.Style = "font-weight: bold; font-size: 8pt; ";
            this.TxtTotalPremium.Text = "TxtTotalPremium";
            this.TxtTotalPremium.Top = 4.5625F;
            this.TxtTotalPremium.Width = 1.636364F;
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
            this.TxtBankName.Height = 0.2F;
            this.TxtBankName.Left = 0.1534091F;
            this.TxtBankName.MultiLine = false;
            this.TxtBankName.Name = "TxtBankName";
            this.TxtBankName.Style = "font-weight: bold; font-size: 8pt; ";
            this.TxtBankName.Text = "TxtBankName";
            this.TxtBankName.Top = 5.125F;
            this.TxtBankName.Width = 2.636364F;
            // 
            // TxtBankPhone
            // 
            this.TxtBankPhone.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtBankPhone.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankPhone.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtBankPhone.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankPhone.Border.RightColor = System.Drawing.Color.Black;
            this.TxtBankPhone.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankPhone.Border.TopColor = System.Drawing.Color.Black;
            this.TxtBankPhone.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankPhone.Height = 0.2F;
            this.TxtBankPhone.Left = 0.1534091F;
            this.TxtBankPhone.MultiLine = false;
            this.TxtBankPhone.Name = "TxtBankPhone";
            this.TxtBankPhone.Style = "font-weight: bold; font-size: 8pt; ";
            this.TxtBankPhone.Text = "TxtBankPhone";
            this.TxtBankPhone.Top = 5.4375F;
            this.TxtBankPhone.Width = 2.636364F;
            // 
            // TxtBankAddress1
            // 
            this.TxtBankAddress1.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtBankAddress1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddress1.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtBankAddress1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddress1.Border.RightColor = System.Drawing.Color.Black;
            this.TxtBankAddress1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddress1.Border.TopColor = System.Drawing.Color.Black;
            this.TxtBankAddress1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddress1.Height = 0.2F;
            this.TxtBankAddress1.Left = 2.909091F;
            this.TxtBankAddress1.MultiLine = false;
            this.TxtBankAddress1.Name = "TxtBankAddress1";
            this.TxtBankAddress1.Style = "font-weight: bold; font-size: 8pt; ";
            this.TxtBankAddress1.Text = "TxtBankAddress1";
            this.TxtBankAddress1.Top = 5.1875F;
            this.TxtBankAddress1.Width = 2.426137F;
            // 
            // TxtBankAddress2
            // 
            this.TxtBankAddress2.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtBankAddress2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddress2.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtBankAddress2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddress2.Border.RightColor = System.Drawing.Color.Black;
            this.TxtBankAddress2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddress2.Border.TopColor = System.Drawing.Color.Black;
            this.TxtBankAddress2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddress2.Height = 0.2F;
            this.TxtBankAddress2.Left = 2.909091F;
            this.TxtBankAddress2.MultiLine = false;
            this.TxtBankAddress2.Name = "TxtBankAddress2";
            this.TxtBankAddress2.Style = "font-weight: bold; font-size: 8pt; ";
            this.TxtBankAddress2.Text = "TxtBankAddress2";
            this.TxtBankAddress2.Top = 5.3125F;
            this.TxtBankAddress2.Width = 2.426137F;
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
            this.TxtBankCity.Height = 0.2F;
            this.TxtBankCity.Left = 2.909091F;
            this.TxtBankCity.MultiLine = false;
            this.TxtBankCity.Name = "TxtBankCity";
            this.TxtBankCity.Style = "font-weight: bold; font-size: 8pt; ";
            this.TxtBankCity.Text = "TxtBankCity";
            this.TxtBankCity.Top = 5.4375F;
            this.TxtBankCity.Width = 2.426137F;
            // 
            // TxtEffectiveDate2
            // 
            this.TxtEffectiveDate2.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtEffectiveDate2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEffectiveDate2.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtEffectiveDate2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEffectiveDate2.Border.RightColor = System.Drawing.Color.Black;
            this.TxtEffectiveDate2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEffectiveDate2.Border.TopColor = System.Drawing.Color.Black;
            this.TxtEffectiveDate2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEffectiveDate2.Height = 0.2F;
            this.TxtEffectiveDate2.Left = 6.335227F;
            this.TxtEffectiveDate2.MultiLine = false;
            this.TxtEffectiveDate2.Name = "TxtEffectiveDate2";
            this.TxtEffectiveDate2.OutputFormat = resources.GetString("TxtEffectiveDate2.OutputFormat");
            this.TxtEffectiveDate2.Style = "font-weight: bold; font-size: 8pt; ";
            this.TxtEffectiveDate2.Text = "TxtEffectiveDate2";
            this.TxtEffectiveDate2.Top = 5.0625F;
            this.TxtEffectiveDate2.Width = 1.181818F;
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
            this.TxtExpirationDate.Left = 6.335227F;
            this.TxtExpirationDate.MultiLine = false;
            this.TxtExpirationDate.Name = "TxtExpirationDate";
            this.TxtExpirationDate.OutputFormat = resources.GetString("TxtExpirationDate.OutputFormat");
            this.TxtExpirationDate.Style = "font-weight: bold; font-size: 8pt; ";
            this.TxtExpirationDate.Text = "TxtExpirationDate";
            this.TxtExpirationDate.Top = 5.5625F;
            this.TxtExpirationDate.Width = 1.181818F;
            // 
            // Txtmileage2
            // 
            this.Txtmileage2.Border.BottomColor = System.Drawing.Color.Black;
            this.Txtmileage2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Txtmileage2.Border.LeftColor = System.Drawing.Color.Black;
            this.Txtmileage2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Txtmileage2.Border.RightColor = System.Drawing.Color.Black;
            this.Txtmileage2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Txtmileage2.Border.TopColor = System.Drawing.Color.Black;
            this.Txtmileage2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Txtmileage2.Height = 0.2F;
            this.Txtmileage2.Left = 6.073864F;
            this.Txtmileage2.MultiLine = false;
            this.Txtmileage2.Name = "Txtmileage2";
            this.Txtmileage2.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.Txtmileage2.Text = "Txtmileage2";
            this.Txtmileage2.Top = 6.125F;
            this.Txtmileage2.Width = 0.6363636F;
            // 
            // Label87
            // 
            this.Label87.Border.BottomColor = System.Drawing.Color.Black;
            this.Label87.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label87.Border.LeftColor = System.Drawing.Color.Black;
            this.Label87.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label87.Border.RightColor = System.Drawing.Color.Black;
            this.Label87.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label87.Border.TopColor = System.Drawing.Color.Black;
            this.Label87.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label87.Height = 0.2F;
            this.Label87.HyperLink = "";
            this.Label87.Left = 6.704546F;
            this.Label87.Name = "Label87";
            this.Label87.Style = "color: Gray; font-size: 8pt; ";
            this.Label87.Text = ",000";
            this.Label87.Top = 6.125F;
            this.Label87.Width = 0.3579545F;
            // 
            // Line26
            // 
            this.Line26.Border.BottomColor = System.Drawing.Color.Black;
            this.Line26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line26.Border.LeftColor = System.Drawing.Color.Black;
            this.Line26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line26.Border.RightColor = System.Drawing.Color.Black;
            this.Line26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line26.Border.TopColor = System.Drawing.Color.Black;
            this.Line26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line26.Height = 0F;
            this.Line26.Left = 0.0625F;
            this.Line26.LineWeight = 1F;
            this.Line26.Name = "Line26";
            this.Line26.Top = 5.625F;
            this.Line26.Width = 5.25F;
            this.Line26.X1 = 0.0625F;
            this.Line26.X2 = 5.3125F;
            this.Line26.Y1 = 5.625F;
            this.Line26.Y2 = 5.625F;
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
            this.Line2.Height = 0.375F;
            this.Line2.Left = 4.363637F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0.25F;
            this.Line2.Width = 0F;
            this.Line2.X1 = 4.363637F;
            this.Line2.X2 = 4.363637F;
            this.Line2.Y1 = 0.625F;
            this.Line2.Y2 = 0.25F;
            // 
            // Shape12
            // 
            this.Shape12.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape12.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape12.Border.RightColor = System.Drawing.Color.Black;
            this.Shape12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape12.Border.TopColor = System.Drawing.Color.Black;
            this.Shape12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape12.Height = 0.9375F;
            this.Shape12.Left = 0.0625F;
            this.Shape12.Name = "Shape12";
            this.Shape12.RoundingRadius = 9.999999F;
            this.Shape12.Top = 2.5625F;
            this.Shape12.Width = 7.9375F;
            // 
            // Label
            // 
            this.Label.Border.BottomColor = System.Drawing.Color.Black;
            this.Label.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.LeftColor = System.Drawing.Color.Black;
            this.Label.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.RightColor = System.Drawing.Color.Black;
            this.Label.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.TopColor = System.Drawing.Color.Black;
            this.Label.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Height = 0.2F;
            this.Label.HyperLink = "";
            this.Label.Left = 0.0625F;
            this.Label.MultiLine = false;
            this.Label.Name = "Label";
            this.Label.Style = "text-align: left; font-weight: bold; font-size: 9pt; ";
            this.Label.Text = "LAS VISTAS INSURANCE AGENCY, CORP.";
            this.Label.Top = 7.75F;
            this.Label.Width = 2.9375F;
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
            this.Shape1.Height = 0.625F;
            this.Shape1.Left = 0.0625F;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = 9.999999F;
            this.Shape1.Top = 0F;
            this.Shape1.Width = 7.9375F;
            // 
            // ActiveReport31
            // 
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0.2F;
            this.PageSettings.Margins.Right = 0.1F;
            this.PageSettings.Margins.Top = 0F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.09375F;
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
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblAutoGuard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtpolicyNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblMechanical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label67)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label68)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label69)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label72)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label73)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label74)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label78)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label81)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label83)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label82)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label84)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label85)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSellerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSellerAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSellerCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSellerState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSellerZip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerZip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVinNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVehicleCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtpurchaseDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxteffectiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtodometer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label86)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTerm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMileage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDeductible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtClasification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotalPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAddress1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAddress2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEffectiveDate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtExpirationDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtmileage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label87)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
       
			// Attach Report Events
			this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
			this.Detail.Format += new System.EventHandler(this.Detail_Format);
			this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.ServiceContractPolicyReport_FetchData);
			this.DataInitialize += new System.EventHandler(this.ServiceContractPolicyReport_DataInitialize);
		 }

		#endregion
	}
}
