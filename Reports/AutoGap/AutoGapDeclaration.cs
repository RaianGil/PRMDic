using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.Customer;
using EPolicy.LookupTables;
using EPolicy.TaskControl;

namespace EPolicy2.Reports
{
	public class AutoGapDeclaration : DataDynamics.ActiveReports.ActiveReport3
	{
		private string _CopyValue;
        private Label lblAutoLoan;
        private Label lblLeasing;
        private Picture Picture1;
		private EPolicy.TaskControl.Policies _taskcontrol;

		public AutoGapDeclaration(EPolicy.TaskControl.Policies taskcontrol,string CopyValue)
		{
			_taskcontrol = taskcontrol;
			_CopyValue = CopyValue;
			InitializeComponent();
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void AutoGapDeclaration_ReportStart(object sender, System.EventArgs eArgs)
		{
			TxtPolicyNo.Text		=	_taskcontrol.PolicyType.Trim().ToUpper()+" "+_taskcontrol.PolicyNo.Trim().ToUpper();
			TxtTotalPremium.Text	=	_taskcontrol.TotalPremium.ToString("$##,###.00");
			TxtEffectiveDate.Text	=	_taskcontrol.EffectiveDate;
			TxtExpirationDate.Text	=	_taskcontrol.ExpirationDate;
			TxtTerm.Text			=	_taskcontrol.Term.ToString();
            TxtCustomerName.Text = _taskcontrol.Customer.FirstName.Trim().ToUpper() + " " + _taskcontrol.Customer.Initial.Trim().ToUpper() + " " + _taskcontrol.Customer.LastName1.Trim().ToUpper() + " " + _taskcontrol.Customer.LastName2.Trim().ToUpper();
			TxtSocialSecurity.Text  =   _taskcontrol.Customer.SocialSecurity;
			TxtAdds1.Text			=   _taskcontrol.Customer.Address1.Trim().ToUpper()+" "+_taskcontrol.Customer.Address2.Trim().ToUpper();
			TxtCity.Text			=	_taskcontrol.Customer.City.Trim().ToUpper();
			TxtState.Text			=   _taskcontrol.Customer.State.Trim().ToUpper();
			TxtZipCode.Text			=   _taskcontrol.Customer.ZipCode;
			TxtTelefono.Text		=   _taskcontrol.Customer.HomePhone.Trim();

			EPolicy.LookupTables.Bank bank = new EPolicy.LookupTables.Bank();
			bank = bank.GetBank(_taskcontrol.Bank);

			TxtBankName.Text		= bank.BankDesc.Trim().ToUpper();
			TxtBankAds1.Text		= bank.Address1.Trim().ToUpper()+" "+bank.Address2.Trim().ToUpper();
			TxtBankCity.Text		= bank.City.Trim().ToUpper();
			TxtBankState.Text		= bank.State.Trim().ToUpper();
			TxtBankZip.Text			= bank.ZipCode.Trim();
			TxtBankTel.Text			= bank.Phone.Trim();
			TxtPurchaserDate.Text	= _taskcontrol.PurchaseDate.Trim();
			TxtTerm2.Text			= _taskcontrol.Term.ToString();
			TxtFinanceAmt.Text		= _taskcontrol.FinanceAmt.ToString("$###,###.00");

			TxtCost.Text			= _taskcontrol.Cost.ToString("$###,###.00");
			TxtVehicleYear.Text		= EPolicy.LookupTables.LookupTables.GetDescription("VehicleYear",_taskcontrol.VehicleYearID.ToString()).Trim();
			TxtVehicleMake.Text		= EPolicy.LookupTables.LookupTables.GetDescription("VehicleMake",_taskcontrol.VehicleMakeID.ToString());
			TxtVehicleModel.Text	= EPolicy.LookupTables.LookupTables.GetDescription("VehicleModel",_taskcontrol.VehicleModelID.ToString());
			TxtVin.Text				= _taskcontrol.VIN.Trim().ToUpper();
			TxtMilleage.Text		= _taskcontrol.Milleages.ToString().Trim().ToUpper();

			EPolicy.LookupTables.CompanyDealer cd = new EPolicy.LookupTables.CompanyDealer();
			cd = cd.GetCompanyDealer(_taskcontrol.CompanyDealer);

			TxtDealerNAme.Text		= cd.CompanyDealerDesc.Trim().ToUpper();
			TxtDealerID.Text		= cd.CompanyDealerID.Trim().ToUpper();

			TxtInsCompany.Text		= LookupTables.GetDescription("InsuranceCompany2",_taskcontrol.InsuranceCompanyPrimaria.Trim());
			TxtCompanyPolicyNo.Text = _taskcontrol.NumeroPolizaPrimaria.Trim();

			TxtEntryDate.Text		= DateTime.Now.ToShortDateString();

            EPolicy.LookupTables.Agent ag = new EPolicy.LookupTables.Agent();
            ag = ag.GetAgent(_taskcontrol.Agent);
			TxtAgentID.Text			= ag.CarsID.Trim();

            if (_taskcontrol.PrestamoArrenda)
            {
                lblAutoLoan.Visible = true;
                lblLeasing.Visible = false;
            }
            else
            {
                lblLeasing.Visible = true;
                lblAutoLoan.Visible = false;
            }

			TxtCopyName.Text		= _CopyValue;
		}

		#region ActiveReports Designer generated code
        private PageHeader PageHeader = null;
		private TextBox TxtPolicyNo = null;
		private TextBox TxtTotalPremium = null;
		private TextBox TxtEffectiveDate = null;
		private TextBox TxtExpirationDate = null;
		private TextBox TxtTerm = null;
		private TextBox TxtCustomerName = null;
		private TextBox TxtSocialSecurity = null;
		private TextBox TxtAdds1 = null;
		private TextBox TxtCity = null;
		private TextBox TxtState = null;
		private TextBox TxtZipCode = null;
		private TextBox TxtTelefono = null;
		private TextBox TxtBankName = null;
		private TextBox TxtBankAds1 = null;
		private TextBox TxtBankCity = null;
		private TextBox TxtBankState = null;
		private TextBox TxtBankZip = null;
		private TextBox TxtBankTel = null;
		private TextBox TxtPurchaserDate = null;
		private TextBox TxtTerm2 = null;
		private TextBox TxtFinanceAmt = null;
		private TextBox TxtCost = null;
		private TextBox TxtVehicleYear = null;
		private TextBox TxtVehicleMake = null;
		private TextBox TxtVehicleModel = null;
		private TextBox TxtDealerNAme = null;
		private TextBox TxtDealerID = null;
		private TextBox TxtInsCompany = null;
		private TextBox TxtCompanyPolicyNo = null;
		private TextBox TxtEntryDate = null;
		private TextBox TxtAgentID = null;
		private TextBox TxtCopyName = null;
		private TextBox TxtVin = null;
		private TextBox TxtMilleage = null;
		private Detail Detail = null;
		private PageFooter PageFooter = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoGapDeclaration));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.TxtPolicyNo = new DataDynamics.ActiveReports.TextBox();
            this.TxtTotalPremium = new DataDynamics.ActiveReports.TextBox();
            this.TxtEffectiveDate = new DataDynamics.ActiveReports.TextBox();
            this.TxtExpirationDate = new DataDynamics.ActiveReports.TextBox();
            this.TxtTerm = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerName = new DataDynamics.ActiveReports.TextBox();
            this.TxtSocialSecurity = new DataDynamics.ActiveReports.TextBox();
            this.TxtAdds1 = new DataDynamics.ActiveReports.TextBox();
            this.TxtCity = new DataDynamics.ActiveReports.TextBox();
            this.TxtState = new DataDynamics.ActiveReports.TextBox();
            this.TxtZipCode = new DataDynamics.ActiveReports.TextBox();
            this.TxtTelefono = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankName = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankAds1 = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankCity = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankState = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankZip = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankTel = new DataDynamics.ActiveReports.TextBox();
            this.TxtPurchaserDate = new DataDynamics.ActiveReports.TextBox();
            this.TxtTerm2 = new DataDynamics.ActiveReports.TextBox();
            this.TxtFinanceAmt = new DataDynamics.ActiveReports.TextBox();
            this.TxtCost = new DataDynamics.ActiveReports.TextBox();
            this.TxtVehicleYear = new DataDynamics.ActiveReports.TextBox();
            this.TxtVehicleMake = new DataDynamics.ActiveReports.TextBox();
            this.TxtVehicleModel = new DataDynamics.ActiveReports.TextBox();
            this.TxtDealerNAme = new DataDynamics.ActiveReports.TextBox();
            this.TxtDealerID = new DataDynamics.ActiveReports.TextBox();
            this.TxtInsCompany = new DataDynamics.ActiveReports.TextBox();
            this.TxtCompanyPolicyNo = new DataDynamics.ActiveReports.TextBox();
            this.TxtEntryDate = new DataDynamics.ActiveReports.TextBox();
            this.TxtAgentID = new DataDynamics.ActiveReports.TextBox();
            this.TxtCopyName = new DataDynamics.ActiveReports.TextBox();
            this.TxtVin = new DataDynamics.ActiveReports.TextBox();
            this.TxtMilleage = new DataDynamics.ActiveReports.TextBox();
            this.lblAutoLoan = new DataDynamics.ActiveReports.Label();
            this.lblLeasing = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Picture1 = new DataDynamics.ActiveReports.Picture();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPolicyNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotalPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEffectiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtExpirationDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTerm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSocialSecurity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAdds1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtZipCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTelefono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAds1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankZip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankTel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPurchaserDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTerm2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFinanceAmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVehicleYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVehicleMake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVehicleModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDealerNAme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDealerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtInsCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCompanyPolicyNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEntryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAgentID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCopyName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMilleage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAutoLoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeasing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture1)).BeginInit();
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
            this.Picture1,
            this.TxtPolicyNo,
            this.TxtTotalPremium,
            this.TxtEffectiveDate,
            this.TxtExpirationDate,
            this.TxtTerm,
            this.TxtCustomerName,
            this.TxtSocialSecurity,
            this.TxtAdds1,
            this.TxtCity,
            this.TxtState,
            this.TxtZipCode,
            this.TxtTelefono,
            this.TxtBankName,
            this.TxtBankAds1,
            this.TxtBankCity,
            this.TxtBankState,
            this.TxtBankZip,
            this.TxtBankTel,
            this.TxtPurchaserDate,
            this.TxtTerm2,
            this.TxtFinanceAmt,
            this.TxtCost,
            this.TxtVehicleYear,
            this.TxtVehicleMake,
            this.TxtVehicleModel,
            this.TxtDealerNAme,
            this.TxtDealerID,
            this.TxtInsCompany,
            this.TxtCompanyPolicyNo,
            this.TxtEntryDate,
            this.TxtAgentID,
            this.TxtCopyName,
            this.TxtVin,
            this.TxtMilleage,
            this.lblAutoLoan,
            this.lblLeasing});
            this.PageHeader.Height = 10.52014F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // TxtPolicyNo
            // 
            this.TxtPolicyNo.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtPolicyNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPolicyNo.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtPolicyNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPolicyNo.Border.RightColor = System.Drawing.Color.Black;
            this.TxtPolicyNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPolicyNo.Border.TopColor = System.Drawing.Color.Black;
            this.TxtPolicyNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPolicyNo.Height = 0.16F;
            this.TxtPolicyNo.Left = 6.28F;
            this.TxtPolicyNo.Name = "TxtPolicyNo";
            this.TxtPolicyNo.Style = "font-size: 9pt; ";
            this.TxtPolicyNo.Text = null;
            this.TxtPolicyNo.Top = 2.1375F;
            this.TxtPolicyNo.Width = 1.36F;
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
            this.TxtTotalPremium.Height = 0.16F;
            this.TxtTotalPremium.Left = 1.5825F;
            this.TxtTotalPremium.Name = "TxtTotalPremium";
            this.TxtTotalPremium.Style = "font-size: 9pt; ";
            this.TxtTotalPremium.Text = null;
            this.TxtTotalPremium.Top = 2.6575F;
            this.TxtTotalPremium.Width = 0.76F;
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
            this.TxtEffectiveDate.Height = 0.16F;
            this.TxtEffectiveDate.Left = 3.5825F;
            this.TxtEffectiveDate.Name = "TxtEffectiveDate";
            this.TxtEffectiveDate.Style = "font-size: 9pt; ";
            this.TxtEffectiveDate.Text = null;
            this.TxtEffectiveDate.Top = 2.6575F;
            this.TxtEffectiveDate.Width = 0.6574998F;
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
            this.TxtExpirationDate.Height = 0.16F;
            this.TxtExpirationDate.Left = 5.52F;
            this.TxtExpirationDate.Name = "TxtExpirationDate";
            this.TxtExpirationDate.Style = "font-size: 9pt; ";
            this.TxtExpirationDate.Text = null;
            this.TxtExpirationDate.Top = 2.6575F;
            this.TxtExpirationDate.Width = 0.6799999F;
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
            this.TxtTerm.Height = 0.16F;
            this.TxtTerm.Left = 7.2075F;
            this.TxtTerm.Name = "TxtTerm";
            this.TxtTerm.Style = "font-size: 9pt; ";
            this.TxtTerm.Text = null;
            this.TxtTerm.Top = 2.6575F;
            this.TxtTerm.Width = 0.4724998F;
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
            this.TxtCustomerName.Height = 0.16F;
            this.TxtCustomerName.Left = 2.5825F;
            this.TxtCustomerName.Name = "TxtCustomerName";
            this.TxtCustomerName.Style = "font-size: 9pt; ";
            this.TxtCustomerName.Text = null;
            this.TxtCustomerName.Top = 3.345F;
            this.TxtCustomerName.Width = 3.4575F;
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
            this.TxtSocialSecurity.Height = 0.16F;
            this.TxtSocialSecurity.Left = 6.52F;
            this.TxtSocialSecurity.Name = "TxtSocialSecurity";
            this.TxtSocialSecurity.Style = "font-size: 9pt; ";
            this.TxtSocialSecurity.Text = null;
            this.TxtSocialSecurity.Top = 3.345F;
            this.TxtSocialSecurity.Width = 1.16F;
            // 
            // TxtAdds1
            // 
            this.TxtAdds1.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtAdds1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAdds1.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtAdds1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAdds1.Border.RightColor = System.Drawing.Color.Black;
            this.TxtAdds1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAdds1.Border.TopColor = System.Drawing.Color.Black;
            this.TxtAdds1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAdds1.Height = 0.16F;
            this.TxtAdds1.Left = 1.4575F;
            this.TxtAdds1.Name = "TxtAdds1";
            this.TxtAdds1.Style = "font-size: 9pt; ";
            this.TxtAdds1.Text = null;
            this.TxtAdds1.Top = 3.595F;
            this.TxtAdds1.Width = 6.222499F;
            // 
            // TxtCity
            // 
            this.TxtCity.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCity.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCity.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCity.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCity.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCity.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCity.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCity.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCity.Height = 0.16F;
            this.TxtCity.Left = 1.4575F;
            this.TxtCity.Name = "TxtCity";
            this.TxtCity.Style = "font-size: 9pt; ";
            this.TxtCity.Text = null;
            this.TxtCity.Top = 3.7825F;
            this.TxtCity.Width = 1.5425F;
            // 
            // TxtState
            // 
            this.TxtState.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtState.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtState.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtState.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtState.Border.RightColor = System.Drawing.Color.Black;
            this.TxtState.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtState.Border.TopColor = System.Drawing.Color.Black;
            this.TxtState.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtState.Height = 0.16F;
            this.TxtState.Left = 3.5825F;
            this.TxtState.Name = "TxtState";
            this.TxtState.Style = "font-size: 9pt; ";
            this.TxtState.Text = null;
            this.TxtState.Top = 3.7825F;
            this.TxtState.Width = 0.6174999F;
            // 
            // TxtZipCode
            // 
            this.TxtZipCode.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtZipCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtZipCode.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtZipCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtZipCode.Border.RightColor = System.Drawing.Color.Black;
            this.TxtZipCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtZipCode.Border.TopColor = System.Drawing.Color.Black;
            this.TxtZipCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtZipCode.Height = 0.16F;
            this.TxtZipCode.Left = 5.145F;
            this.TxtZipCode.Name = "TxtZipCode";
            this.TxtZipCode.Style = "font-size: 9pt; ";
            this.TxtZipCode.Text = null;
            this.TxtZipCode.Top = 3.7825F;
            this.TxtZipCode.Width = 0.6149998F;
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtTelefono.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTelefono.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtTelefono.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTelefono.Border.RightColor = System.Drawing.Color.Black;
            this.TxtTelefono.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTelefono.Border.TopColor = System.Drawing.Color.Black;
            this.TxtTelefono.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTelefono.Height = 0.16F;
            this.TxtTelefono.Left = 6.7075F;
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.Style = "font-size: 9pt; ";
            this.TxtTelefono.Text = null;
            this.TxtTelefono.Top = 3.7825F;
            this.TxtTelefono.Width = 1.0125F;
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
            this.TxtBankName.Height = 0.16F;
            this.TxtBankName.Left = 2.145F;
            this.TxtBankName.Name = "TxtBankName";
            this.TxtBankName.Style = "font-size: 9pt; ";
            this.TxtBankName.Text = null;
            this.TxtBankName.Top = 4.595F;
            this.TxtBankName.Width = 5.575F;
            // 
            // TxtBankAds1
            // 
            this.TxtBankAds1.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtBankAds1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAds1.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtBankAds1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAds1.Border.RightColor = System.Drawing.Color.Black;
            this.TxtBankAds1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAds1.Border.TopColor = System.Drawing.Color.Black;
            this.TxtBankAds1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAds1.Height = 0.16F;
            this.TxtBankAds1.Left = 1.4575F;
            this.TxtBankAds1.Name = "TxtBankAds1";
            this.TxtBankAds1.Style = "font-size: 9pt; ";
            this.TxtBankAds1.Text = null;
            this.TxtBankAds1.Top = 4.845F;
            this.TxtBankAds1.Width = 6.2625F;
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
            this.TxtBankCity.Height = 0.16F;
            this.TxtBankCity.Left = 1.3325F;
            this.TxtBankCity.Name = "TxtBankCity";
            this.TxtBankCity.Style = "font-size: 9pt; ";
            this.TxtBankCity.Text = null;
            this.TxtBankCity.Top = 5.095F;
            this.TxtBankCity.Width = 1.7475F;
            // 
            // TxtBankState
            // 
            this.TxtBankState.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtBankState.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankState.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtBankState.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankState.Border.RightColor = System.Drawing.Color.Black;
            this.TxtBankState.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankState.Border.TopColor = System.Drawing.Color.Black;
            this.TxtBankState.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankState.Height = 0.16F;
            this.TxtBankState.Left = 3.5825F;
            this.TxtBankState.Name = "TxtBankState";
            this.TxtBankState.Style = "font-size: 9pt; ";
            this.TxtBankState.Text = null;
            this.TxtBankState.Top = 5.095F;
            this.TxtBankState.Width = 0.6174999F;
            // 
            // TxtBankZip
            // 
            this.TxtBankZip.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtBankZip.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankZip.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtBankZip.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankZip.Border.RightColor = System.Drawing.Color.Black;
            this.TxtBankZip.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankZip.Border.TopColor = System.Drawing.Color.Black;
            this.TxtBankZip.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankZip.Height = 0.16F;
            this.TxtBankZip.Left = 4.8325F;
            this.TxtBankZip.Name = "TxtBankZip";
            this.TxtBankZip.Style = "font-size: 9pt; ";
            this.TxtBankZip.Text = null;
            this.TxtBankZip.Top = 5.095F;
            this.TxtBankZip.Width = 0.6149998F;
            // 
            // TxtBankTel
            // 
            this.TxtBankTel.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtBankTel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankTel.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtBankTel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankTel.Border.RightColor = System.Drawing.Color.Black;
            this.TxtBankTel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankTel.Border.TopColor = System.Drawing.Color.Black;
            this.TxtBankTel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankTel.Height = 0.16F;
            this.TxtBankTel.Left = 6.7075F;
            this.TxtBankTel.Name = "TxtBankTel";
            this.TxtBankTel.Style = "font-size: 9pt; ";
            this.TxtBankTel.Text = null;
            this.TxtBankTel.Top = 5.095F;
            this.TxtBankTel.Width = 1.0125F;
            // 
            // TxtPurchaserDate
            // 
            this.TxtPurchaserDate.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtPurchaserDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPurchaserDate.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtPurchaserDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPurchaserDate.Border.RightColor = System.Drawing.Color.Black;
            this.TxtPurchaserDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPurchaserDate.Border.TopColor = System.Drawing.Color.Black;
            this.TxtPurchaserDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPurchaserDate.Height = 0.16F;
            this.TxtPurchaserDate.Left = 2.3325F;
            this.TxtPurchaserDate.Name = "TxtPurchaserDate";
            this.TxtPurchaserDate.Style = "font-size: 9pt; ";
            this.TxtPurchaserDate.Text = null;
            this.TxtPurchaserDate.Top = 5.47F;
            this.TxtPurchaserDate.Width = 0.7475F;
            // 
            // TxtTerm2
            // 
            this.TxtTerm2.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtTerm2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTerm2.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtTerm2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTerm2.Border.RightColor = System.Drawing.Color.Black;
            this.TxtTerm2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTerm2.Border.TopColor = System.Drawing.Color.Black;
            this.TxtTerm2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTerm2.Height = 0.16F;
            this.TxtTerm2.Left = 4.77F;
            this.TxtTerm2.Name = "TxtTerm2";
            this.TxtTerm2.Style = "font-size: 9pt; ";
            this.TxtTerm2.Text = null;
            this.TxtTerm2.Top = 5.47F;
            this.TxtTerm2.Width = 0.6149998F;
            // 
            // TxtFinanceAmt
            // 
            this.TxtFinanceAmt.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtFinanceAmt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtFinanceAmt.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtFinanceAmt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtFinanceAmt.Border.RightColor = System.Drawing.Color.Black;
            this.TxtFinanceAmt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtFinanceAmt.Border.TopColor = System.Drawing.Color.Black;
            this.TxtFinanceAmt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtFinanceAmt.Height = 0.16F;
            this.TxtFinanceAmt.Left = 6.895F;
            this.TxtFinanceAmt.Name = "TxtFinanceAmt";
            this.TxtFinanceAmt.Style = "font-size: 9pt; ";
            this.TxtFinanceAmt.Text = null;
            this.TxtFinanceAmt.Top = 5.47F;
            this.TxtFinanceAmt.Width = 0.825F;
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
            this.TxtCost.Height = 0.16F;
            this.TxtCost.Left = 1.4F;
            this.TxtCost.Name = "TxtCost";
            this.TxtCost.Style = "font-size: 9pt; ";
            this.TxtCost.Text = null;
            this.TxtCost.Top = 6.0125F;
            this.TxtCost.Width = 1.085F;
            // 
            // TxtVehicleYear
            // 
            this.TxtVehicleYear.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtVehicleYear.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVehicleYear.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtVehicleYear.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVehicleYear.Border.RightColor = System.Drawing.Color.Black;
            this.TxtVehicleYear.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVehicleYear.Border.TopColor = System.Drawing.Color.Black;
            this.TxtVehicleYear.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVehicleYear.Height = 0.16F;
            this.TxtVehicleYear.Left = 3.4F;
            this.TxtVehicleYear.Name = "TxtVehicleYear";
            this.TxtVehicleYear.Style = "font-size: 9pt; ";
            this.TxtVehicleYear.Text = null;
            this.TxtVehicleYear.Top = 6.0125F;
            this.TxtVehicleYear.Width = 0.845F;
            // 
            // TxtVehicleMake
            // 
            this.TxtVehicleMake.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtVehicleMake.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVehicleMake.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtVehicleMake.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVehicleMake.Border.RightColor = System.Drawing.Color.Black;
            this.TxtVehicleMake.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVehicleMake.Border.TopColor = System.Drawing.Color.Black;
            this.TxtVehicleMake.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVehicleMake.Height = 0.16F;
            this.TxtVehicleMake.Left = 4.9625F;
            this.TxtVehicleMake.Name = "TxtVehicleMake";
            this.TxtVehicleMake.Style = "font-size: 9pt; ";
            this.TxtVehicleMake.Text = null;
            this.TxtVehicleMake.Top = 6.0125F;
            this.TxtVehicleMake.Width = 1.2025F;
            // 
            // TxtVehicleModel
            // 
            this.TxtVehicleModel.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtVehicleModel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVehicleModel.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtVehicleModel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVehicleModel.Border.RightColor = System.Drawing.Color.Black;
            this.TxtVehicleModel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVehicleModel.Border.TopColor = System.Drawing.Color.Black;
            this.TxtVehicleModel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVehicleModel.Height = 0.16F;
            this.TxtVehicleModel.Left = 6.775F;
            this.TxtVehicleModel.Name = "TxtVehicleModel";
            this.TxtVehicleModel.Style = "font-size: 9pt; ";
            this.TxtVehicleModel.Text = null;
            this.TxtVehicleModel.Top = 6.0125F;
            this.TxtVehicleModel.Width = 0.99F;
            // 
            // TxtDealerNAme
            // 
            this.TxtDealerNAme.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtDealerNAme.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDealerNAme.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtDealerNAme.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDealerNAme.Border.RightColor = System.Drawing.Color.Black;
            this.TxtDealerNAme.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDealerNAme.Border.TopColor = System.Drawing.Color.Black;
            this.TxtDealerNAme.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDealerNAme.Height = 0.16F;
            this.TxtDealerNAme.Left = 1.77F;
            this.TxtDealerNAme.Name = "TxtDealerNAme";
            this.TxtDealerNAme.Style = "font-size: 9pt; ";
            this.TxtDealerNAme.Text = null;
            this.TxtDealerNAme.Top = 6.47F;
            this.TxtDealerNAme.Width = 3.19F;
            // 
            // TxtDealerID
            // 
            this.TxtDealerID.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtDealerID.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDealerID.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtDealerID.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDealerID.Border.RightColor = System.Drawing.Color.Black;
            this.TxtDealerID.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDealerID.Border.TopColor = System.Drawing.Color.Black;
            this.TxtDealerID.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDealerID.Height = 0.16F;
            this.TxtDealerID.Left = 6.645F;
            this.TxtDealerID.Name = "TxtDealerID";
            this.TxtDealerID.Style = "font-size: 9pt; ";
            this.TxtDealerID.Text = null;
            this.TxtDealerID.Top = 6.47F;
            this.TxtDealerID.Width = 0.99F;
            // 
            // TxtInsCompany
            // 
            this.TxtInsCompany.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtInsCompany.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtInsCompany.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtInsCompany.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtInsCompany.Border.RightColor = System.Drawing.Color.Black;
            this.TxtInsCompany.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtInsCompany.Border.TopColor = System.Drawing.Color.Black;
            this.TxtInsCompany.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtInsCompany.Height = 0.16F;
            this.TxtInsCompany.Left = 2.645F;
            this.TxtInsCompany.Name = "TxtInsCompany";
            this.TxtInsCompany.Style = "font-size: 9pt; ";
            this.TxtInsCompany.Text = null;
            this.TxtInsCompany.Top = 6.9075F;
            this.TxtInsCompany.Width = 2.315F;
            // 
            // TxtCompanyPolicyNo
            // 
            this.TxtCompanyPolicyNo.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCompanyPolicyNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCompanyPolicyNo.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCompanyPolicyNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCompanyPolicyNo.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCompanyPolicyNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCompanyPolicyNo.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCompanyPolicyNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCompanyPolicyNo.Height = 0.16F;
            this.TxtCompanyPolicyNo.Left = 6.215001F;
            this.TxtCompanyPolicyNo.Name = "TxtCompanyPolicyNo";
            this.TxtCompanyPolicyNo.Style = "font-size: 9pt; ";
            this.TxtCompanyPolicyNo.Text = null;
            this.TxtCompanyPolicyNo.Top = 6.9075F;
            this.TxtCompanyPolicyNo.Width = 1.504999F;
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
            this.TxtEntryDate.Height = 0.16F;
            this.TxtEntryDate.Left = 2.395F;
            this.TxtEntryDate.Name = "TxtEntryDate";
            this.TxtEntryDate.Style = "font-size: 9pt; ";
            this.TxtEntryDate.Text = null;
            this.TxtEntryDate.Top = 7.4075F;
            this.TxtEntryDate.Width = 1.405F;
            // 
            // TxtAgentID
            // 
            this.TxtAgentID.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtAgentID.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAgentID.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtAgentID.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAgentID.Border.RightColor = System.Drawing.Color.Black;
            this.TxtAgentID.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAgentID.Border.TopColor = System.Drawing.Color.Black;
            this.TxtAgentID.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtAgentID.Height = 0.16F;
            this.TxtAgentID.Left = 2.395F;
            this.TxtAgentID.Name = "TxtAgentID";
            this.TxtAgentID.Style = "font-size: 9pt; ";
            this.TxtAgentID.Text = null;
            this.TxtAgentID.Top = 7.72F;
            this.TxtAgentID.Width = 1.405F;
            // 
            // TxtCopyName
            // 
            this.TxtCopyName.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCopyName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCopyName.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCopyName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCopyName.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCopyName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCopyName.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCopyName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCopyName.Height = 0.16F;
            this.TxtCopyName.Left = 4.36F;
            this.TxtCopyName.Name = "TxtCopyName";
            this.TxtCopyName.Style = "font-weight: bold; font-size: 9pt; ";
            this.TxtCopyName.Text = null;
            this.TxtCopyName.Top = 9.13F;
            this.TxtCopyName.Width = 1.3025F;
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
            this.TxtVin.Height = 0.16F;
            this.TxtVin.Left = 2.395F;
            this.TxtVin.Name = "TxtVin";
            this.TxtVin.Style = "font-size: 9pt; ";
            this.TxtVin.Text = null;
            this.TxtVin.Top = 6.2825F;
            this.TxtVin.Width = 1.965F;
            // 
            // TxtMilleage
            // 
            this.TxtMilleage.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtMilleage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMilleage.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtMilleage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMilleage.Border.RightColor = System.Drawing.Color.Black;
            this.TxtMilleage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMilleage.Border.TopColor = System.Drawing.Color.Black;
            this.TxtMilleage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMilleage.Height = 0.16F;
            this.TxtMilleage.Left = 6.02F;
            this.TxtMilleage.Name = "TxtMilleage";
            this.TxtMilleage.Style = "font-size: 9pt; ";
            this.TxtMilleage.Text = null;
            this.TxtMilleage.Top = 6.2825F;
            this.TxtMilleage.Width = 1.5F;
            // 
            // lblAutoLoan
            // 
            this.lblAutoLoan.Border.BottomColor = System.Drawing.Color.Black;
            this.lblAutoLoan.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblAutoLoan.Border.LeftColor = System.Drawing.Color.Black;
            this.lblAutoLoan.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblAutoLoan.Border.RightColor = System.Drawing.Color.Black;
            this.lblAutoLoan.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblAutoLoan.Border.TopColor = System.Drawing.Color.Black;
            this.lblAutoLoan.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblAutoLoan.Height = 0.1875F;
            this.lblAutoLoan.HyperLink = null;
            this.lblAutoLoan.Left = 2.5625F;
            this.lblAutoLoan.Name = "lblAutoLoan";
            this.lblAutoLoan.Style = "font-size: 9pt; ";
            this.lblAutoLoan.Text = "X";
            this.lblAutoLoan.Top = 4.375F;
            this.lblAutoLoan.Visible = false;
            this.lblAutoLoan.Width = 0.125F;
            // 
            // lblLeasing
            // 
            this.lblLeasing.Border.BottomColor = System.Drawing.Color.Black;
            this.lblLeasing.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLeasing.Border.LeftColor = System.Drawing.Color.Black;
            this.lblLeasing.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLeasing.Border.RightColor = System.Drawing.Color.Black;
            this.lblLeasing.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLeasing.Border.TopColor = System.Drawing.Color.Black;
            this.lblLeasing.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLeasing.Height = 0.1875F;
            this.lblLeasing.HyperLink = null;
            this.lblLeasing.Left = 4.5F;
            this.lblLeasing.Name = "lblLeasing";
            this.lblLeasing.Style = "font-size: 9pt; ";
            this.lblLeasing.Text = "X";
            this.lblLeasing.Top = 4.375F;
            this.lblLeasing.Visible = false;
            this.lblLeasing.Width = 0.125F;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0.1034722F;
            this.PageFooter.Name = "PageFooter";
            // 
            // Picture1
            // 
            this.Picture1.Border.BottomColor = System.Drawing.Color.Black;
            this.Picture1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture1.Border.LeftColor = System.Drawing.Color.Black;
            this.Picture1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture1.Border.RightColor = System.Drawing.Color.Black;
            this.Picture1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture1.Border.TopColor = System.Drawing.Color.Black;
            this.Picture1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture1.Height = 10.44F;
            this.Picture1.Image = ((System.Drawing.Image)(resources.GetObject("Picture1.Image")));
            this.Picture1.ImageData = ((System.IO.Stream)(resources.GetObject("Picture1.ImageData")));
            this.Picture1.Left = 0.24F;
            this.Picture1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture1.LineWeight = 0F;
            this.Picture1.Name = "Picture1";
            this.Picture1.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.Picture1.Top = 0.04F;
            this.Picture1.Width = 7.92F;
            // 
            // AutoGapDeclaration
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0.1F;
            this.PageSettings.Margins.Right = 0.1F;
            this.PageSettings.Margins.Top = 0F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.1875F;
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
            this.ReportStart += new System.EventHandler(this.AutoGapDeclaration_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.TxtPolicyNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotalPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEffectiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtExpirationDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTerm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSocialSecurity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAdds1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtZipCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTelefono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAds1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankZip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankTel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPurchaserDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTerm2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFinanceAmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVehicleYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVehicleMake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVehicleModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDealerNAme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDealerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtInsCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCompanyPolicyNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEntryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAgentID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCopyName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMilleage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAutoLoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeasing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
