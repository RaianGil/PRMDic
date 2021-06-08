using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy;

namespace EPolicy2.Reports
{
	public class GapCartaCobro : DataDynamics.ActiveReports.ActiveReport3
	{
		//private int CountDataIndex;
		private string _CopyValue;
		private EPolicy.TaskControl.Policies _taskcontrol;

		public GapCartaCobro(EPolicy.TaskControl.Policies taskcontrol,string CopyValue)
		{
			_taskcontrol = taskcontrol;
			_CopyValue = CopyValue;

			InitializeComponent();
		}

		private void GapCartaCobro_DataInitialize(object sender, System.EventArgs eArgs)
		{
			//TxtEfectiveDate.Text	= "";
			//TxtBankName.Text		= "";
			//TxtBankAdds1.Text		= "";
			//TxtBankAdds2.Text		= "";
			//TxtBankAdds3.Text		= "";
			//TxtNombreAsegurado.Text	= "";
			//TxtPolicyNo.Text		= "";
			//TxtEfective.Text		= "";
			//TxtVehicleYear.Text		= "";
			//TxtMakeModel.Text		= "";
			//TxtVIN.Text				= "";
			//TxtTotPremium.Text		= "";			
		}

		private void GapCartaCobro_ReportStart(object sender, System.EventArgs eArgs)
		{
			TxtEfectiveDate.Text	= _taskcontrol.EffectiveDate;
			
			EPolicy.LookupTables.Bank bank = new EPolicy.LookupTables.Bank();
			bank = bank.GetBank(_taskcontrol.Bank);

			TxtBankName.Text		= bank.BankDesc.Trim().ToUpper();
			TxtBankAdds1.Text		= bank.Address1.Trim().ToUpper();
			TxtBankAdds2.Text		= bank.Address2.Trim().ToUpper();
			TxtBankAdds3.Text		= bank.City.Trim().ToUpper()+" "+bank.State.Trim().ToUpper()+" "+bank.ZipCode.Trim();
			TxtNombreAsegurado.Text	= _taskcontrol.Customer.FirstName.Trim().ToUpper()+" "+_taskcontrol.Customer.LastName1.Trim().ToUpper()+" "+_taskcontrol.Customer.LastName2.Trim().ToUpper();
			TxtPolicyNo.Text		= _taskcontrol.PolicyType.Trim().ToUpper()+" "+ _taskcontrol.PolicyNo.Trim();
			TxtEfective.Text		= _taskcontrol.EffectiveDate +"  Hasta: "+_taskcontrol.ExpirationDate;
			TxtVehicleYear.Text		= EPolicy.LookupTables.LookupTables.GetDescription("VehicleYear",_taskcontrol.VehicleYearID.ToString()).Trim();
			TxtMakeModel.Text		= EPolicy.LookupTables.LookupTables.GetDescription("VehicleMake",_taskcontrol.VehicleMakeID.ToString())+" / "+
									EPolicy.LookupTables.LookupTables.GetDescription("VehicleModel",_taskcontrol.VehicleModelID.ToString());
			TxtVIN.Text				= _taskcontrol.VIN.Trim().ToUpper();
			TxtTotPremium.Text		= _taskcontrol.TotalPremium.ToString("$###,###.00");		
		}

		#region ActiveReports Designer generated code
		private PageHeader PageHeader = null;
		private Picture Picture1 = null;
		private TextBox TxtNombreAsegurado = null;
		private TextBox TxtPolicyNo = null;
		private TextBox TxtEfective = null;
		private TextBox TxtEfectiveDate = null;
		private TextBox TxtBankName = null;
		private TextBox TxtBankAdds1 = null;
		private TextBox TxtBankAdds2 = null;
		private TextBox TxtBankAdds3 = null;
		private TextBox TxtTotPremium = null;
		private TextBox TxtVehicleYear = null;
		private TextBox TxtMakeModel = null;
		private TextBox TxtVIN = null;
		private Detail Detail = null;
		private PageFooter PageFooter = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GapCartaCobro));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Picture1 = new DataDynamics.ActiveReports.Picture();
            this.TxtNombreAsegurado = new DataDynamics.ActiveReports.TextBox();
            this.TxtPolicyNo = new DataDynamics.ActiveReports.TextBox();
            this.TxtEfective = new DataDynamics.ActiveReports.TextBox();
            this.TxtEfectiveDate = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankName = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankAdds1 = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankAdds2 = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankAdds3 = new DataDynamics.ActiveReports.TextBox();
            this.TxtTotPremium = new DataDynamics.ActiveReports.TextBox();
            this.TxtVehicleYear = new DataDynamics.ActiveReports.TextBox();
            this.TxtMakeModel = new DataDynamics.ActiveReports.TextBox();
            this.TxtVIN = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.Picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNombreAsegurado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPolicyNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEfective)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEfectiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAdds1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAdds2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAdds3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVehicleYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMakeModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVIN)).BeginInit();
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
            this.TxtNombreAsegurado,
            this.TxtPolicyNo,
            this.TxtEfective,
            this.TxtEfectiveDate,
            this.TxtBankName,
            this.TxtBankAdds1,
            this.TxtBankAdds2,
            this.TxtBankAdds3,
            this.TxtTotPremium,
            this.TxtVehicleYear,
            this.TxtMakeModel,
            this.TxtVIN});
            this.PageHeader.Height = 10.29167F;
            this.PageHeader.Name = "PageHeader";
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
            this.Picture1.Height = 10.32F;
            this.Picture1.Image = ((System.Drawing.Image)(resources.GetObject("Picture1.Image")));
            this.Picture1.ImageData = ((System.IO.Stream)(resources.GetObject("Picture1.ImageData")));
            this.Picture1.Left = 0.1875F;
            this.Picture1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture1.LineWeight = 0F;
            this.Picture1.Name = "Picture1";
            this.Picture1.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.Picture1.Top = 0.0625F;
            this.Picture1.Width = 7.92F;
            // 
            // TxtNombreAsegurado
            // 
            this.TxtNombreAsegurado.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtNombreAsegurado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtNombreAsegurado.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtNombreAsegurado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtNombreAsegurado.Border.RightColor = System.Drawing.Color.Black;
            this.TxtNombreAsegurado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtNombreAsegurado.Border.TopColor = System.Drawing.Color.Black;
            this.TxtNombreAsegurado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtNombreAsegurado.Height = 0.16F;
            this.TxtNombreAsegurado.Left = 3.4375F;
            this.TxtNombreAsegurado.Name = "TxtNombreAsegurado";
            this.TxtNombreAsegurado.Style = "font-size: 9pt; ";
            this.TxtNombreAsegurado.Text = null;
            this.TxtNombreAsegurado.Top = 4F;
            this.TxtNombreAsegurado.Width = 3.4F;
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
            this.TxtPolicyNo.Left = 3.4375F;
            this.TxtPolicyNo.Name = "TxtPolicyNo";
            this.TxtPolicyNo.Style = "font-weight: normal; font-size: 9pt; ";
            this.TxtPolicyNo.Text = null;
            this.TxtPolicyNo.Top = 4.1875F;
            this.TxtPolicyNo.Width = 3.4F;
            // 
            // TxtEfective
            // 
            this.TxtEfective.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtEfective.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEfective.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtEfective.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEfective.Border.RightColor = System.Drawing.Color.Black;
            this.TxtEfective.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEfective.Border.TopColor = System.Drawing.Color.Black;
            this.TxtEfective.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEfective.Height = 0.16F;
            this.TxtEfective.Left = 3.4375F;
            this.TxtEfective.Name = "TxtEfective";
            this.TxtEfective.Style = "font-size: 9pt; ";
            this.TxtEfective.Text = null;
            this.TxtEfective.Top = 4.375F;
            this.TxtEfective.Width = 3.4F;
            // 
            // TxtEfectiveDate
            // 
            this.TxtEfectiveDate.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtEfectiveDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEfectiveDate.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtEfectiveDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEfectiveDate.Border.RightColor = System.Drawing.Color.Black;
            this.TxtEfectiveDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEfectiveDate.Border.TopColor = System.Drawing.Color.Black;
            this.TxtEfectiveDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEfectiveDate.Height = 0.16F;
            this.TxtEfectiveDate.Left = 1F;
            this.TxtEfectiveDate.Name = "TxtEfectiveDate";
            this.TxtEfectiveDate.OutputFormat = resources.GetString("TxtEfectiveDate.OutputFormat");
            this.TxtEfectiveDate.Style = "font-size: 9pt; ";
            this.TxtEfectiveDate.Text = null;
            this.TxtEfectiveDate.Top = 1.9375F;
            this.TxtEfectiveDate.Width = 1.34F;
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
            this.TxtBankName.Left = 1F;
            this.TxtBankName.Name = "TxtBankName";
            this.TxtBankName.Style = "font-size: 9pt; ";
            this.TxtBankName.Text = null;
            this.TxtBankName.Top = 2.75F;
            this.TxtBankName.Width = 3.4F;
            // 
            // TxtBankAdds1
            // 
            this.TxtBankAdds1.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtBankAdds1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAdds1.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtBankAdds1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAdds1.Border.RightColor = System.Drawing.Color.Black;
            this.TxtBankAdds1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAdds1.Border.TopColor = System.Drawing.Color.Black;
            this.TxtBankAdds1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAdds1.Height = 0.16F;
            this.TxtBankAdds1.Left = 1F;
            this.TxtBankAdds1.Name = "TxtBankAdds1";
            this.TxtBankAdds1.Style = "font-size: 9pt; ";
            this.TxtBankAdds1.Text = null;
            this.TxtBankAdds1.Top = 2.875F;
            this.TxtBankAdds1.Width = 3.4F;
            // 
            // TxtBankAdds2
            // 
            this.TxtBankAdds2.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtBankAdds2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAdds2.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtBankAdds2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAdds2.Border.RightColor = System.Drawing.Color.Black;
            this.TxtBankAdds2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAdds2.Border.TopColor = System.Drawing.Color.Black;
            this.TxtBankAdds2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAdds2.Height = 0.16F;
            this.TxtBankAdds2.Left = 1F;
            this.TxtBankAdds2.Name = "TxtBankAdds2";
            this.TxtBankAdds2.Style = "font-size: 9pt; ";
            this.TxtBankAdds2.Text = null;
            this.TxtBankAdds2.Top = 3F;
            this.TxtBankAdds2.Width = 3.4F;
            // 
            // TxtBankAdds3
            // 
            this.TxtBankAdds3.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtBankAdds3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAdds3.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtBankAdds3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAdds3.Border.RightColor = System.Drawing.Color.Black;
            this.TxtBankAdds3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAdds3.Border.TopColor = System.Drawing.Color.Black;
            this.TxtBankAdds3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAdds3.Height = 0.16F;
            this.TxtBankAdds3.Left = 1F;
            this.TxtBankAdds3.Name = "TxtBankAdds3";
            this.TxtBankAdds3.Style = "font-size: 9pt; ";
            this.TxtBankAdds3.Text = null;
            this.TxtBankAdds3.Top = 3.125F;
            this.TxtBankAdds3.Width = 3.4F;
            // 
            // TxtTotPremium
            // 
            this.TxtTotPremium.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtTotPremium.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotPremium.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtTotPremium.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotPremium.Border.RightColor = System.Drawing.Color.Black;
            this.TxtTotPremium.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotPremium.Border.TopColor = System.Drawing.Color.Black;
            this.TxtTotPremium.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotPremium.Height = 0.1810002F;
            this.TxtTotPremium.Left = 2.4375F;
            this.TxtTotPremium.Name = "TxtTotPremium";
            this.TxtTotPremium.Style = "font-weight: bold; font-size: 9pt; ";
            this.TxtTotPremium.Text = "385.00";
            this.TxtTotPremium.Top = 6.5F;
            this.TxtTotPremium.Width = 0.51F;
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
            this.TxtVehicleYear.Left = 0.9375F;
            this.TxtVehicleYear.Name = "TxtVehicleYear";
            this.TxtVehicleYear.OutputFormat = resources.GetString("TxtVehicleYear.OutputFormat");
            this.TxtVehicleYear.Style = "text-align: center; font-size: 9pt; ";
            this.TxtVehicleYear.Text = null;
            this.TxtVehicleYear.Top = 6.125F;
            this.TxtVehicleYear.Width = 0.7424999F;
            // 
            // TxtMakeModel
            // 
            this.TxtMakeModel.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtMakeModel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMakeModel.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtMakeModel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMakeModel.Border.RightColor = System.Drawing.Color.Black;
            this.TxtMakeModel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMakeModel.Border.TopColor = System.Drawing.Color.Black;
            this.TxtMakeModel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMakeModel.Height = 0.16F;
            this.TxtMakeModel.Left = 1.9375F;
            this.TxtMakeModel.Name = "TxtMakeModel";
            this.TxtMakeModel.Style = "text-align: center; font-size: 9pt; ";
            this.TxtMakeModel.Text = null;
            this.TxtMakeModel.Top = 6.125F;
            this.TxtMakeModel.Width = 2.24F;
            // 
            // TxtVIN
            // 
            this.TxtVIN.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtVIN.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVIN.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtVIN.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVIN.Border.RightColor = System.Drawing.Color.Black;
            this.TxtVIN.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVIN.Border.TopColor = System.Drawing.Color.Black;
            this.TxtVIN.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVIN.Height = 0.16F;
            this.TxtVIN.Left = 4.5625F;
            this.TxtVIN.Name = "TxtVIN";
            this.TxtVIN.Style = "text-align: center; font-size: 9pt; ";
            this.TxtVIN.Text = null;
            this.TxtVIN.Top = 6.125F;
            this.TxtVIN.Width = 1.92F;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0.0625F;
            this.PageFooter.Name = "PageFooter";
            // 
            // GapCartaCobro
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
            this.PrintWidth = 8.145833F;
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
            this.DataInitialize += new System.EventHandler(this.GapCartaCobro_DataInitialize);
            this.ReportStart += new System.EventHandler(this.GapCartaCobro_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.Picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNombreAsegurado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPolicyNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEfective)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEfectiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAdds1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAdds2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAdds3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVehicleYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMakeModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
