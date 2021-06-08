using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy;

namespace EPolicy2.Reports.AutoGuard
{
	public class CancellationNote : DataDynamics.ActiveReports.ActiveReport3
	{
		private string _CopyValue;
        private Label label1;
        private TextBox txtPolicyNo;
        private Line line9;
		private EPolicy.TaskControl.Policies _taskcontrol;

		public CancellationNote(EPolicy.TaskControl.Policies taskcontrol,string CopyValue)
		{
			_taskcontrol = taskcontrol;
			_CopyValue = CopyValue;

			InitializeComponent();
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void CancellationNote_ReportStart(object sender, System.EventArgs eArgs)
		{
			txtPolicyNo.Text = _taskcontrol.PolicyNo.ToString().Trim()+" "+_taskcontrol.Certificate.ToString().Trim();					

			txtCancellationDate.Text  = _taskcontrol.CancellationDate.ToString().Trim();	
			txtProductionDate.Text  = _taskcontrol.EffectiveDate.ToString().Trim();		
		
			EPolicy.LookupTables.CompanyDealer CD = new EPolicy.LookupTables.CompanyDealer();
			CD = CD.GetCompanyDealer(_taskcontrol.CompanyDealer);
			txtDealerName.Text =CD.CompanyDealerDesc.Trim().ToUpper();

			//Vendedor
			if(_taskcontrol.SupplierID.Trim() != "000") 
			{
				EPolicy.LookupTables.Supplier SP = new EPolicy.LookupTables.Supplier();
				SP = SP.GetSupplier(_taskcontrol.SupplierID);
				txtNombreVendedor.Text = SP.SupplierDesc.Trim().ToUpper();
			}
			else
			{
				txtNombreVendedor.Text = "";
			}

			//Customer Info
			txtInsureName.Text = _taskcontrol.Customer.FirstName.Trim() +" "+_taskcontrol.Customer.Initial.Trim()+" "+
				_taskcontrol.Customer.LastName1.Trim()+ " "+_taskcontrol.Customer.LastName2.Trim();		

			txtVehicleMake.Text = EPolicy.LookupTables.LookupTables.GetDescription("VehicleMake",_taskcontrol.VehicleMakeID.ToString()).ToUpper();

			EPolicy.LookupTables.InsuranceCompany insurancecompany = new EPolicy.LookupTables.InsuranceCompany();
			insurancecompany = insurancecompany.GetInsuranceCompany(_taskcontrol.InsuranceCompany);
			txtInsuranceCompanyName.Text = insurancecompany.InsuranceCompanyDesc.ToString();
				 				
			CancellationReason.Text = EPolicy.LookupTables.LookupTables.GetDescription("CancellationReason",_taskcontrol.CancellationReason.ToString()).ToUpper();

			DateTime date    = DateTime.Now;
			TxtDate.Text    = date.ToShortDateString().Trim();
			TxtTaskControl.Text = "Control No.: "+_taskcontrol.TaskControlID.ToString().Trim();
		}

		#region ActiveReports Designer generated code
		private PageHeader PageHeader = null;
		private Label Label236 = null;
		private Label Label237 = null;
		private Label lblCancellationDate = null;
		private Label lblCancellationReason = null;
		private Label lblInsuranceCompanyName = null;
		private Label lblVehicleMake = null;
		private Label lblInsureName = null;
		private Label lblNombreVendedor = null;
		private Label lblDealerName = null;
		private Label lblProductionDate = null;
		private TextBox txtCancellationDate = null;
		private TextBox CancellationReason = null;
		private TextBox txtInsuranceCompanyName = null;
		private TextBox txtVehicleMake = null;
		private TextBox txtInsureName = null;
		private TextBox txtNombreVendedor = null;
		private TextBox txtDealerName = null;
		private TextBox txtProductionDate = null;
		private Line Line1 = null;
		private Line Line2 = null;
		private Line Line3 = null;
		private Line Line4 = null;
		private Line Line5 = null;
		private Line Line6 = null;
		private Line Line7 = null;
		private Line Line8 = null;
		private TextBox TxtDate = null;
		private Label Label238 = null;
		private Detail Detail = null;
        private PageFooter PageFooter = null;
		private TextBox TxtTaskControl = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CancellationNote));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label236 = new DataDynamics.ActiveReports.Label();
            this.Label237 = new DataDynamics.ActiveReports.Label();
            this.lblCancellationDate = new DataDynamics.ActiveReports.Label();
            this.lblCancellationReason = new DataDynamics.ActiveReports.Label();
            this.lblInsuranceCompanyName = new DataDynamics.ActiveReports.Label();
            this.lblVehicleMake = new DataDynamics.ActiveReports.Label();
            this.lblInsureName = new DataDynamics.ActiveReports.Label();
            this.lblNombreVendedor = new DataDynamics.ActiveReports.Label();
            this.lblDealerName = new DataDynamics.ActiveReports.Label();
            this.lblProductionDate = new DataDynamics.ActiveReports.Label();
            this.txtCancellationDate = new DataDynamics.ActiveReports.TextBox();
            this.CancellationReason = new DataDynamics.ActiveReports.TextBox();
            this.txtInsuranceCompanyName = new DataDynamics.ActiveReports.TextBox();
            this.txtVehicleMake = new DataDynamics.ActiveReports.TextBox();
            this.txtInsureName = new DataDynamics.ActiveReports.TextBox();
            this.txtNombreVendedor = new DataDynamics.ActiveReports.TextBox();
            this.txtDealerName = new DataDynamics.ActiveReports.TextBox();
            this.txtProductionDate = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.Line3 = new DataDynamics.ActiveReports.Line();
            this.Line4 = new DataDynamics.ActiveReports.Line();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.Line6 = new DataDynamics.ActiveReports.Line();
            this.Line7 = new DataDynamics.ActiveReports.Line();
            this.Line8 = new DataDynamics.ActiveReports.Line();
            this.TxtDate = new DataDynamics.ActiveReports.TextBox();
            this.Label238 = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.txtPolicyNo = new DataDynamics.ActiveReports.TextBox();
            this.line9 = new DataDynamics.ActiveReports.Line();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.TxtTaskControl = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Label236)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label237)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCancellationDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCancellationReason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInsuranceCompanyName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVehicleMake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInsureName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNombreVendedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDealerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProductionDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCancellationDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CancellationReason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsuranceCompanyName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehicleMake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsureName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreVendedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDealerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductionDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label238)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPolicyNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTaskControl)).BeginInit();
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
            this.Label236,
            this.Label237,
            this.lblCancellationDate,
            this.lblCancellationReason,
            this.lblInsuranceCompanyName,
            this.lblVehicleMake,
            this.lblInsureName,
            this.lblNombreVendedor,
            this.lblDealerName,
            this.lblProductionDate,
            this.txtCancellationDate,
            this.CancellationReason,
            this.txtInsuranceCompanyName,
            this.txtVehicleMake,
            this.txtInsureName,
            this.txtNombreVendedor,
            this.txtDealerName,
            this.txtProductionDate,
            this.Line1,
            this.Line2,
            this.Line3,
            this.Line4,
            this.Line5,
            this.Line6,
            this.Line7,
            this.Line8,
            this.TxtDate,
            this.Label238,
            this.label1,
            this.txtPolicyNo,
            this.line9});
            this.PageHeader.Height = 5.15625F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // Label236
            // 
            this.Label236.Border.BottomColor = System.Drawing.Color.Black;
            this.Label236.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label236.Border.LeftColor = System.Drawing.Color.Black;
            this.Label236.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label236.Border.RightColor = System.Drawing.Color.Black;
            this.Label236.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label236.Border.TopColor = System.Drawing.Color.Black;
            this.Label236.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label236.Height = 0.1875F;
            this.Label236.HyperLink = "";
            this.Label236.Left = 1.619792F;
            this.Label236.MultiLine = false;
            this.Label236.Name = "Label236";
            this.Label236.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 12pt; ";
            this.Label236.Text = "PUERTO RICO MEDICAL DEFENSE INSURANCE COMPANY";
            this.Label236.Top = 0.25F;
            this.Label236.Width = 5.125F;
            // 
            // Label237
            // 
            this.Label237.Border.BottomColor = System.Drawing.Color.Black;
            this.Label237.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label237.Border.LeftColor = System.Drawing.Color.Black;
            this.Label237.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label237.Border.RightColor = System.Drawing.Color.Black;
            this.Label237.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label237.Border.TopColor = System.Drawing.Color.Black;
            this.Label237.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label237.Height = 0.1875F;
            this.Label237.HyperLink = "";
            this.Label237.Left = 1.625F;
            this.Label237.MultiLine = false;
            this.Label237.Name = "Label237";
            this.Label237.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 12pt; ";
            this.Label237.Text = "Hoja de Cancelación";
            this.Label237.Top = 0.6875F;
            this.Label237.Width = 5.125F;
            // 
            // lblCancellationDate
            // 
            this.lblCancellationDate.Border.BottomColor = System.Drawing.Color.Black;
            this.lblCancellationDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCancellationDate.Border.LeftColor = System.Drawing.Color.Black;
            this.lblCancellationDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCancellationDate.Border.RightColor = System.Drawing.Color.Black;
            this.lblCancellationDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCancellationDate.Border.TopColor = System.Drawing.Color.Black;
            this.lblCancellationDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCancellationDate.Height = 0.1875F;
            this.lblCancellationDate.HyperLink = "";
            this.lblCancellationDate.Left = 1.8125F;
            this.lblCancellationDate.Name = "lblCancellationDate";
            this.lblCancellationDate.Style = "";
            this.lblCancellationDate.Text = "Fecha de la Cancelación:";
            this.lblCancellationDate.Top = 1.625F;
            this.lblCancellationDate.Width = 1.8125F;
            // 
            // lblCancellationReason
            // 
            this.lblCancellationReason.Border.BottomColor = System.Drawing.Color.Black;
            this.lblCancellationReason.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCancellationReason.Border.LeftColor = System.Drawing.Color.Black;
            this.lblCancellationReason.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCancellationReason.Border.RightColor = System.Drawing.Color.Black;
            this.lblCancellationReason.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCancellationReason.Border.TopColor = System.Drawing.Color.Black;
            this.lblCancellationReason.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCancellationReason.Height = 0.1875F;
            this.lblCancellationReason.HyperLink = "";
            this.lblCancellationReason.Left = 1.8125F;
            this.lblCancellationReason.Name = "lblCancellationReason";
            this.lblCancellationReason.Style = "";
            this.lblCancellationReason.Text = "Razones de la Cancelación:";
            this.lblCancellationReason.Top = 4.0625F;
            this.lblCancellationReason.Width = 1.8125F;
            // 
            // lblInsuranceCompanyName
            // 
            this.lblInsuranceCompanyName.Border.BottomColor = System.Drawing.Color.Black;
            this.lblInsuranceCompanyName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblInsuranceCompanyName.Border.LeftColor = System.Drawing.Color.Black;
            this.lblInsuranceCompanyName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblInsuranceCompanyName.Border.RightColor = System.Drawing.Color.Black;
            this.lblInsuranceCompanyName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblInsuranceCompanyName.Border.TopColor = System.Drawing.Color.Black;
            this.lblInsuranceCompanyName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblInsuranceCompanyName.Height = 0.1875F;
            this.lblInsuranceCompanyName.HyperLink = "";
            this.lblInsuranceCompanyName.Left = 1.8125F;
            this.lblInsuranceCompanyName.Name = "lblInsuranceCompanyName";
            this.lblInsuranceCompanyName.Style = "";
            this.lblInsuranceCompanyName.Text = "Compañía de Seguro:";
            this.lblInsuranceCompanyName.Top = 3.5F;
            this.lblInsuranceCompanyName.Width = 1.8125F;
            // 
            // lblVehicleMake
            // 
            this.lblVehicleMake.Border.BottomColor = System.Drawing.Color.Black;
            this.lblVehicleMake.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblVehicleMake.Border.LeftColor = System.Drawing.Color.Black;
            this.lblVehicleMake.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblVehicleMake.Border.RightColor = System.Drawing.Color.Black;
            this.lblVehicleMake.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblVehicleMake.Border.TopColor = System.Drawing.Color.Black;
            this.lblVehicleMake.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblVehicleMake.Height = 0.1875F;
            this.lblVehicleMake.HyperLink = "";
            this.lblVehicleMake.Left = 1.8125F;
            this.lblVehicleMake.Name = "lblVehicleMake";
            this.lblVehicleMake.Style = "";
            this.lblVehicleMake.Text = "Marca del Auto:";
            this.lblVehicleMake.Top = 3.1875F;
            this.lblVehicleMake.Width = 1.8125F;
            // 
            // lblInsureName
            // 
            this.lblInsureName.Border.BottomColor = System.Drawing.Color.Black;
            this.lblInsureName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblInsureName.Border.LeftColor = System.Drawing.Color.Black;
            this.lblInsureName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblInsureName.Border.RightColor = System.Drawing.Color.Black;
            this.lblInsureName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblInsureName.Border.TopColor = System.Drawing.Color.Black;
            this.lblInsureName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblInsureName.Height = 0.1875F;
            this.lblInsureName.HyperLink = "";
            this.lblInsureName.Left = 1.8125F;
            this.lblInsureName.Name = "lblInsureName";
            this.lblInsureName.Style = "";
            this.lblInsureName.Text = "Nombre del Asegurado:";
            this.lblInsureName.Top = 2.875F;
            this.lblInsureName.Width = 1.8125F;
            // 
            // lblNombreVendedor
            // 
            this.lblNombreVendedor.Border.BottomColor = System.Drawing.Color.Black;
            this.lblNombreVendedor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNombreVendedor.Border.LeftColor = System.Drawing.Color.Black;
            this.lblNombreVendedor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNombreVendedor.Border.RightColor = System.Drawing.Color.Black;
            this.lblNombreVendedor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNombreVendedor.Border.TopColor = System.Drawing.Color.Black;
            this.lblNombreVendedor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNombreVendedor.Height = 0.1875F;
            this.lblNombreVendedor.HyperLink = "";
            this.lblNombreVendedor.Left = 1.8125F;
            this.lblNombreVendedor.Name = "lblNombreVendedor";
            this.lblNombreVendedor.Style = "";
            this.lblNombreVendedor.Text = "Nombre del Vendedor:";
            this.lblNombreVendedor.Top = 2.5625F;
            this.lblNombreVendedor.Width = 1.8125F;
            // 
            // lblDealerName
            // 
            this.lblDealerName.Border.BottomColor = System.Drawing.Color.Black;
            this.lblDealerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDealerName.Border.LeftColor = System.Drawing.Color.Black;
            this.lblDealerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDealerName.Border.RightColor = System.Drawing.Color.Black;
            this.lblDealerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDealerName.Border.TopColor = System.Drawing.Color.Black;
            this.lblDealerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDealerName.Height = 0.1875F;
            this.lblDealerName.HyperLink = "";
            this.lblDealerName.Left = 1.8125F;
            this.lblDealerName.Name = "lblDealerName";
            this.lblDealerName.Style = "";
            this.lblDealerName.Text = "Nombre del Dealer:";
            this.lblDealerName.Top = 2.25F;
            this.lblDealerName.Width = 1.8125F;
            // 
            // lblProductionDate
            // 
            this.lblProductionDate.Border.BottomColor = System.Drawing.Color.Black;
            this.lblProductionDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblProductionDate.Border.LeftColor = System.Drawing.Color.Black;
            this.lblProductionDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblProductionDate.Border.RightColor = System.Drawing.Color.Black;
            this.lblProductionDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblProductionDate.Border.TopColor = System.Drawing.Color.Black;
            this.lblProductionDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblProductionDate.Height = 0.1875F;
            this.lblProductionDate.HyperLink = "";
            this.lblProductionDate.Left = 1.8125F;
            this.lblProductionDate.Name = "lblProductionDate";
            this.lblProductionDate.Style = "";
            this.lblProductionDate.Text = "Fecha de la Producción:";
            this.lblProductionDate.Top = 1.9375F;
            this.lblProductionDate.Width = 1.8125F;
            // 
            // txtCancellationDate
            // 
            this.txtCancellationDate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCancellationDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCancellationDate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCancellationDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCancellationDate.Border.RightColor = System.Drawing.Color.Black;
            this.txtCancellationDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCancellationDate.Border.TopColor = System.Drawing.Color.Black;
            this.txtCancellationDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCancellationDate.DataField = "CancellationDate";
            this.txtCancellationDate.Height = 0.1875F;
            this.txtCancellationDate.Left = 3.875F;
            this.txtCancellationDate.Name = "txtCancellationDate";
            this.txtCancellationDate.Style = "text-align: left; font-size: 8pt; ";
            this.txtCancellationDate.Text = null;
            this.txtCancellationDate.Top = 1.625F;
            this.txtCancellationDate.Width = 2.485F;
            // 
            // CancellationReason
            // 
            this.CancellationReason.Border.BottomColor = System.Drawing.Color.Black;
            this.CancellationReason.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CancellationReason.Border.LeftColor = System.Drawing.Color.Black;
            this.CancellationReason.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CancellationReason.Border.RightColor = System.Drawing.Color.Black;
            this.CancellationReason.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CancellationReason.Border.TopColor = System.Drawing.Color.Black;
            this.CancellationReason.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CancellationReason.DataField = "CancellationReason";
            this.CancellationReason.Height = 0.1875F;
            this.CancellationReason.Left = 3.875F;
            this.CancellationReason.Name = "CancellationReason";
            this.CancellationReason.Style = "text-align: left; font-size: 8pt; ";
            this.CancellationReason.Text = null;
            this.CancellationReason.Top = 4.0625F;
            this.CancellationReason.Width = 2.485F;
            // 
            // txtInsuranceCompanyName
            // 
            this.txtInsuranceCompanyName.Border.BottomColor = System.Drawing.Color.Black;
            this.txtInsuranceCompanyName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInsuranceCompanyName.Border.LeftColor = System.Drawing.Color.Black;
            this.txtInsuranceCompanyName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInsuranceCompanyName.Border.RightColor = System.Drawing.Color.Black;
            this.txtInsuranceCompanyName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInsuranceCompanyName.Border.TopColor = System.Drawing.Color.Black;
            this.txtInsuranceCompanyName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInsuranceCompanyName.DataField = "InsuranceCompanyName";
            this.txtInsuranceCompanyName.Height = 0.1875F;
            this.txtInsuranceCompanyName.Left = 3.875F;
            this.txtInsuranceCompanyName.Name = "txtInsuranceCompanyName";
            this.txtInsuranceCompanyName.Style = "text-align: left; font-size: 8pt; ";
            this.txtInsuranceCompanyName.Text = null;
            this.txtInsuranceCompanyName.Top = 3.5F;
            this.txtInsuranceCompanyName.Width = 2.485F;
            // 
            // txtVehicleMake
            // 
            this.txtVehicleMake.Border.BottomColor = System.Drawing.Color.Black;
            this.txtVehicleMake.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVehicleMake.Border.LeftColor = System.Drawing.Color.Black;
            this.txtVehicleMake.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVehicleMake.Border.RightColor = System.Drawing.Color.Black;
            this.txtVehicleMake.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVehicleMake.Border.TopColor = System.Drawing.Color.Black;
            this.txtVehicleMake.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVehicleMake.DataField = "VehicleMake";
            this.txtVehicleMake.Height = 0.1875F;
            this.txtVehicleMake.Left = 3.875F;
            this.txtVehicleMake.Name = "txtVehicleMake";
            this.txtVehicleMake.Style = "text-align: left; font-size: 8pt; ";
            this.txtVehicleMake.Text = null;
            this.txtVehicleMake.Top = 3.1875F;
            this.txtVehicleMake.Width = 2.485F;
            // 
            // txtInsureName
            // 
            this.txtInsureName.Border.BottomColor = System.Drawing.Color.Black;
            this.txtInsureName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInsureName.Border.LeftColor = System.Drawing.Color.Black;
            this.txtInsureName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInsureName.Border.RightColor = System.Drawing.Color.Black;
            this.txtInsureName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInsureName.Border.TopColor = System.Drawing.Color.Black;
            this.txtInsureName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInsureName.DataField = "InsureName";
            this.txtInsureName.Height = 0.1875F;
            this.txtInsureName.Left = 3.875F;
            this.txtInsureName.Name = "txtInsureName";
            this.txtInsureName.Style = "text-align: left; font-size: 8pt; ";
            this.txtInsureName.Text = null;
            this.txtInsureName.Top = 2.875F;
            this.txtInsureName.Width = 2.485F;
            // 
            // txtNombreVendedor
            // 
            this.txtNombreVendedor.Border.BottomColor = System.Drawing.Color.Black;
            this.txtNombreVendedor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNombreVendedor.Border.LeftColor = System.Drawing.Color.Black;
            this.txtNombreVendedor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNombreVendedor.Border.RightColor = System.Drawing.Color.Black;
            this.txtNombreVendedor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNombreVendedor.Border.TopColor = System.Drawing.Color.Black;
            this.txtNombreVendedor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNombreVendedor.DataField = "NombreVendedor";
            this.txtNombreVendedor.Height = 0.1875F;
            this.txtNombreVendedor.Left = 3.875F;
            this.txtNombreVendedor.Name = "txtNombreVendedor";
            this.txtNombreVendedor.Style = "text-align: left; font-size: 8pt; ";
            this.txtNombreVendedor.Text = null;
            this.txtNombreVendedor.Top = 2.5625F;
            this.txtNombreVendedor.Width = 2.485F;
            // 
            // txtDealerName
            // 
            this.txtDealerName.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDealerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDealerName.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDealerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDealerName.Border.RightColor = System.Drawing.Color.Black;
            this.txtDealerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDealerName.Border.TopColor = System.Drawing.Color.Black;
            this.txtDealerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDealerName.DataField = "DealerName";
            this.txtDealerName.Height = 0.1875F;
            this.txtDealerName.Left = 3.875F;
            this.txtDealerName.Name = "txtDealerName";
            this.txtDealerName.Style = "text-align: left; font-size: 8pt; ";
            this.txtDealerName.Text = null;
            this.txtDealerName.Top = 2.25F;
            this.txtDealerName.Width = 2.485F;
            // 
            // txtProductionDate
            // 
            this.txtProductionDate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtProductionDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProductionDate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtProductionDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProductionDate.Border.RightColor = System.Drawing.Color.Black;
            this.txtProductionDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProductionDate.Border.TopColor = System.Drawing.Color.Black;
            this.txtProductionDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProductionDate.DataField = "ProductionDate";
            this.txtProductionDate.Height = 0.1875F;
            this.txtProductionDate.Left = 3.875F;
            this.txtProductionDate.Name = "txtProductionDate";
            this.txtProductionDate.Style = "text-align: left; font-size: 8pt; ";
            this.txtProductionDate.Text = null;
            this.txtProductionDate.Top = 1.9375F;
            this.txtProductionDate.Width = 2.485F;
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
            this.Line1.Left = 3.8125F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 1.8125F;
            this.Line1.Width = 2.5625F;
            this.Line1.X1 = 3.8125F;
            this.Line1.X2 = 6.375F;
            this.Line1.Y1 = 1.8125F;
            this.Line1.Y2 = 1.8125F;
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
            this.Line2.Height = 0F;
            this.Line2.Left = 3.8125F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 2.125F;
            this.Line2.Width = 2.5625F;
            this.Line2.X1 = 3.8125F;
            this.Line2.X2 = 6.375F;
            this.Line2.Y1 = 2.125F;
            this.Line2.Y2 = 2.125F;
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
            this.Line3.Left = 3.8125F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 2.4375F;
            this.Line3.Width = 2.5625F;
            this.Line3.X1 = 3.8125F;
            this.Line3.X2 = 6.375F;
            this.Line3.Y1 = 2.4375F;
            this.Line3.Y2 = 2.4375F;
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
            this.Line4.Left = 3.8125F;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 4.25F;
            this.Line4.Width = 2.5625F;
            this.Line4.X1 = 3.8125F;
            this.Line4.X2 = 6.375F;
            this.Line4.Y1 = 4.25F;
            this.Line4.Y2 = 4.25F;
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
            this.Line5.Left = 3.8125F;
            this.Line5.LineWeight = 1F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 3.6875F;
            this.Line5.Width = 2.5625F;
            this.Line5.X1 = 3.8125F;
            this.Line5.X2 = 6.375F;
            this.Line5.Y1 = 3.6875F;
            this.Line5.Y2 = 3.6875F;
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
            this.Line6.Height = 0F;
            this.Line6.Left = 3.8125F;
            this.Line6.LineWeight = 1F;
            this.Line6.Name = "Line6";
            this.Line6.Top = 3.375F;
            this.Line6.Width = 2.5625F;
            this.Line6.X1 = 3.8125F;
            this.Line6.X2 = 6.375F;
            this.Line6.Y1 = 3.375F;
            this.Line6.Y2 = 3.375F;
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
            this.Line7.Height = 0F;
            this.Line7.Left = 3.8125F;
            this.Line7.LineWeight = 1F;
            this.Line7.Name = "Line7";
            this.Line7.Top = 3.0625F;
            this.Line7.Width = 2.5625F;
            this.Line7.X1 = 3.8125F;
            this.Line7.X2 = 6.375F;
            this.Line7.Y1 = 3.0625F;
            this.Line7.Y2 = 3.0625F;
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
            this.Line8.Height = 0F;
            this.Line8.Left = 3.8125F;
            this.Line8.LineWeight = 1F;
            this.Line8.Name = "Line8";
            this.Line8.Top = 2.75F;
            this.Line8.Width = 2.5625F;
            this.Line8.X1 = 3.8125F;
            this.Line8.X2 = 6.375F;
            this.Line8.Y1 = 2.75F;
            this.Line8.Y2 = 2.75F;
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
            this.TxtDate.Left = 4.25F;
            this.TxtDate.MultiLine = false;
            this.TxtDate.Name = "TxtDate";
            this.TxtDate.OutputFormat = resources.GetString("TxtDate.OutputFormat");
            this.TxtDate.Style = "text-align: center; font-weight: normal; font-size: 9pt; ";
            this.TxtDate.Text = null;
            this.TxtDate.Top = 4.75F;
            this.TxtDate.Width = 1.4375F;
            // 
            // Label238
            // 
            this.Label238.Border.BottomColor = System.Drawing.Color.Black;
            this.Label238.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label238.Border.LeftColor = System.Drawing.Color.Black;
            this.Label238.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label238.Border.RightColor = System.Drawing.Color.Black;
            this.Label238.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label238.Border.TopColor = System.Drawing.Color.Black;
            this.Label238.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label238.Height = 0.1875F;
            this.Label238.HyperLink = "";
            this.Label238.Left = 1.8125F;
            this.Label238.Name = "Label238";
            this.Label238.Style = "";
            this.Label238.Text = "Fecha:";
            this.Label238.Top = 4.75F;
            this.Label238.Width = 1.8125F;
            // 
            // label1
            // 
            this.label1.Border.BottomColor = System.Drawing.Color.Black;
            this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.LeftColor = System.Drawing.Color.Black;
            this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.RightColor = System.Drawing.Color.Black;
            this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.TopColor = System.Drawing.Color.Black;
            this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Height = 0.1875F;
            this.label1.HyperLink = "";
            this.label1.Left = 1.8125F;
            this.label1.Name = "label1";
            this.label1.Style = "";
            this.label1.Text = "Número de Póliza:";
            this.label1.Top = 1.3125F;
            this.label1.Width = 1.8125F;
            // 
            // txtPolicyNo
            // 
            this.txtPolicyNo.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPolicyNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyNo.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPolicyNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyNo.Border.RightColor = System.Drawing.Color.Black;
            this.txtPolicyNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyNo.Border.TopColor = System.Drawing.Color.Black;
            this.txtPolicyNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyNo.DataField = "PolicyNo";
            this.txtPolicyNo.Height = 0.1875F;
            this.txtPolicyNo.Left = 3.875F;
            this.txtPolicyNo.Name = "txtPolicyNo";
            this.txtPolicyNo.Style = "text-align: left; font-size: 8pt; ";
            this.txtPolicyNo.Text = null;
            this.txtPolicyNo.Top = 1.3125F;
            this.txtPolicyNo.Width = 2.485F;
            // 
            // line9
            // 
            this.line9.Border.BottomColor = System.Drawing.Color.Black;
            this.line9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.LeftColor = System.Drawing.Color.Black;
            this.line9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.RightColor = System.Drawing.Color.Black;
            this.line9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.TopColor = System.Drawing.Color.Black;
            this.line9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Height = 0F;
            this.line9.Left = 3.8125F;
            this.line9.LineWeight = 1F;
            this.line9.Name = "line9";
            this.line9.Top = 1.5F;
            this.line9.Width = 2.5625F;
            this.line9.X1 = 3.8125F;
            this.line9.X2 = 6.375F;
            this.line9.Y1 = 1.5F;
            this.line9.Y2 = 1.5F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TxtTaskControl});
            this.PageFooter.Height = 1F;
            this.PageFooter.Name = "PageFooter";
            // 
            // TxtTaskControl
            // 
            this.TxtTaskControl.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtTaskControl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTaskControl.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtTaskControl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTaskControl.Border.RightColor = System.Drawing.Color.Black;
            this.TxtTaskControl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTaskControl.Border.TopColor = System.Drawing.Color.Black;
            this.TxtTaskControl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTaskControl.Height = 0.2F;
            this.TxtTaskControl.Left = 6.2675F;
            this.TxtTaskControl.MultiLine = false;
            this.TxtTaskControl.Name = "TxtTaskControl";
            this.TxtTaskControl.OutputFormat = resources.GetString("TxtTaskControl.OutputFormat");
            this.TxtTaskControl.Style = "text-align: right; font-weight: normal; font-size: 8pt; ";
            this.TxtTaskControl.Text = null;
            this.TxtTaskControl.Top = 0.6424999F;
            this.TxtTaskControl.Width = 1.76F;
            // 
            // CancellationNote
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.364583F;
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
            this.ReportStart += new System.EventHandler(this.CancellationNote_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.Label236)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label237)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCancellationDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCancellationReason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInsuranceCompanyName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVehicleMake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInsureName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNombreVendedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDealerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProductionDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCancellationDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CancellationReason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsuranceCompanyName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehicleMake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsureName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreVendedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDealerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductionDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label238)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPolicyNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTaskControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
