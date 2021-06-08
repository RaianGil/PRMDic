using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports
{
	public class CartaAutoGuard : DataDynamics.ActiveReports.ActiveReport3
	{
        private EPolicy.TaskControl.AutoGuardServicesContract _autoGuard;
		private string  _CopyValue;

        public CartaAutoGuard(EPolicy.TaskControl.AutoGuardServicesContract autoGuard, string copyValue)
		{
			_autoGuard    = autoGuard;
			_CopyValue = copyValue;

			InitializeComponent();
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void CartaAutoGuard_ReportStart(object sender, System.EventArgs eArgs)
		{
			TxtDate.Text    = DateTime.Now.ToShortDateString();

			TxtPolicyNo.Text       = _autoGuard.PolicyType+" "+_autoGuard.PolicyNo+" "+_autoGuard.Certificate.Trim()+" "+_autoGuard.Suffix.Trim();

			if(_autoGuard.InsuranceCompany != "099")
			{
				//Picture4.Visible     = false;
				//LblAutoGuard.Visible = false;
				//lblMbi.Visible       = true;						
				LblMechanical.Visible = true;
			}
			else
			{
				//Picture4.Visible = true;
				//LblAutoGuard.Visible = true;
				//lblMbi.Visible   = false;
				LblMechanical.Visible = false;
			}

			//Customer and Postal Address
			TxtCustomerName.Text = _autoGuard.Customer.FirstName.Trim() +" "+_autoGuard.Customer.Initial.Trim()+" "+
				_autoGuard.Customer.LastName1.Trim()+ " "+_autoGuard.Customer.LastName2.Trim();
				
				
			TxtCustomerAddr1.Text = _autoGuard.Customer.Address1.Trim().ToUpper();
			if(_autoGuard.Customer.Address2.Trim().ToUpper() == "")
			{
				TxtCustomerAddr2.Text = _autoGuard.Customer.City.Trim().ToUpper()+" "+
					_autoGuard.Customer.State.Trim().ToUpper()+" "+
					_autoGuard.Customer.ZipCode.Trim().ToUpper();
				TxtCustomerCity.Text  = "";
			}
			else
			{
				TxtCustomerAddr2.Text = _autoGuard.Customer.Address2.Trim().ToUpper();
				TxtCustomerCity.Text  = _autoGuard.Customer.City.Trim().ToUpper()+" "+
					_autoGuard.Customer.State.Trim().ToUpper()+" "+
					_autoGuard.Customer.ZipCode.Trim().ToUpper();
			}
		}

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.TextBox TxtDate = null;
		private DataDynamics.ActiveReports.TextBox TxtCustomerName = null;
		private DataDynamics.ActiveReports.TextBox TxtCustomerAddr1 = null;
		private DataDynamics.ActiveReports.TextBox TxtCustomerAddr2 = null;
		private DataDynamics.ActiveReports.TextBox TxtCustomerCity = null;
		private DataDynamics.ActiveReports.Label LblUniversal1 = null;
		private DataDynamics.ActiveReports.TextBox TxtPolicyNo = null;
		private DataDynamics.ActiveReports.Label Label6 = null;
		private DataDynamics.ActiveReports.Label Label7 = null;
		private DataDynamics.ActiveReports.Label Label8 = null;
		private DataDynamics.ActiveReports.Label Label9 = null;
		private DataDynamics.ActiveReports.Label Label10 = null;
		private DataDynamics.ActiveReports.Label Label11 = null;
		private DataDynamics.ActiveReports.Label Label12 = null;
		private DataDynamics.ActiveReports.Label Label13 = null;
		private DataDynamics.ActiveReports.Label Label14 = null;
		private DataDynamics.ActiveReports.Label Label15 = null;
		private DataDynamics.ActiveReports.Label Label16 = null;
		private DataDynamics.ActiveReports.Label Label17 = null;
		private DataDynamics.ActiveReports.Label Label18 = null;
		private DataDynamics.ActiveReports.Label Label19 = null;
		private DataDynamics.ActiveReports.Label Label20 = null;
		private DataDynamics.ActiveReports.Label Label85 = null;
		private DataDynamics.ActiveReports.Label LblMechanical = null;
		private DataDynamics.ActiveReports.Label Label90 = null;
		private DataDynamics.ActiveReports.Label Label75 = null;
		private DataDynamics.ActiveReports.Label Label77 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.Label Label88 = null;
		private DataDynamics.ActiveReports.Label Label89 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartaAutoGuard));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.TxtDate = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerName = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerAddr1 = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerAddr2 = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerCity = new DataDynamics.ActiveReports.TextBox();
            this.LblUniversal1 = new DataDynamics.ActiveReports.Label();
            this.TxtPolicyNo = new DataDynamics.ActiveReports.TextBox();
            this.Label6 = new DataDynamics.ActiveReports.Label();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.Label8 = new DataDynamics.ActiveReports.Label();
            this.Label9 = new DataDynamics.ActiveReports.Label();
            this.Label10 = new DataDynamics.ActiveReports.Label();
            this.Label11 = new DataDynamics.ActiveReports.Label();
            this.Label12 = new DataDynamics.ActiveReports.Label();
            this.Label13 = new DataDynamics.ActiveReports.Label();
            this.Label14 = new DataDynamics.ActiveReports.Label();
            this.Label15 = new DataDynamics.ActiveReports.Label();
            this.Label16 = new DataDynamics.ActiveReports.Label();
            this.Label17 = new DataDynamics.ActiveReports.Label();
            this.Label18 = new DataDynamics.ActiveReports.Label();
            this.Label19 = new DataDynamics.ActiveReports.Label();
            this.Label20 = new DataDynamics.ActiveReports.Label();
            this.Label85 = new DataDynamics.ActiveReports.Label();
            this.LblMechanical = new DataDynamics.ActiveReports.Label();
            this.Label90 = new DataDynamics.ActiveReports.Label();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.Label88 = new DataDynamics.ActiveReports.Label();
            this.Label89 = new DataDynamics.ActiveReports.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerAddr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerAddr2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblUniversal1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPolicyNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label85)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblMechanical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label90)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label88)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label89)).BeginInit();
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
                        this.TxtDate,
                        this.TxtCustomerName,
                        this.TxtCustomerAddr1,
                        this.TxtCustomerAddr2,
                        this.TxtCustomerCity,
                        this.LblUniversal1,
                        this.TxtPolicyNo,
                        this.Label6,
                        this.Label7,
                        this.Label8,
                        this.Label9,
                        this.Label10,
                        this.Label11,
                        this.Label12,
                        this.Label13,
                        this.Label14,
                        this.Label15,
                        this.Label16,
                        this.Label17,
                        this.Label18,
                        this.Label19,
                        this.Label20,
                        this.Label85,
                        this.LblMechanical,
                        this.Label90,
                        this.Label75,
                        this.Label77});
            this.PageHeader.Height = 8.5625F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Label88,
                        this.Label89});
            this.PageFooter.Height = 0.3534722F;
            this.PageFooter.Name = "PageFooter";
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
            this.TxtDate.Height = 0.1875F;
            this.TxtDate.Left = 0.1534091F;
            this.TxtDate.Name = "TxtDate";
            this.TxtDate.Style = "font-size: 9pt; ";
            this.TxtDate.Text = "TxtDate";
            this.TxtDate.Top = 1.1875F;
            this.TxtDate.Width = 1.8125F;
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
            this.TxtCustomerName.Left = 0.1534091F;
            this.TxtCustomerName.MultiLine = false;
            this.TxtCustomerName.Name = "TxtCustomerName";
            this.TxtCustomerName.OutputFormat = resources.GetString("TxtCustomerName.OutputFormat");
            this.TxtCustomerName.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtCustomerName.Text = "TxtCustomerName";
            this.TxtCustomerName.Top = 1.5F;
            this.TxtCustomerName.Width = 2.977272F;
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
            this.TxtCustomerAddr1.Left = 0.1534091F;
            this.TxtCustomerAddr1.MultiLine = false;
            this.TxtCustomerAddr1.Name = "TxtCustomerAddr1";
            this.TxtCustomerAddr1.OutputFormat = resources.GetString("TxtCustomerAddr1.OutputFormat");
            this.TxtCustomerAddr1.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtCustomerAddr1.Text = "TxtCustomerAddr1";
            this.TxtCustomerAddr1.Top = 1.625F;
            this.TxtCustomerAddr1.Width = 2.977273F;
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
            this.TxtCustomerAddr2.Left = 0.1534091F;
            this.TxtCustomerAddr2.MultiLine = false;
            this.TxtCustomerAddr2.Name = "TxtCustomerAddr2";
            this.TxtCustomerAddr2.OutputFormat = resources.GetString("TxtCustomerAddr2.OutputFormat");
            this.TxtCustomerAddr2.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtCustomerAddr2.Text = "TxtCustomerAddr2";
            this.TxtCustomerAddr2.Top = 1.75F;
            this.TxtCustomerAddr2.Width = 2.977273F;
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
            this.TxtCustomerCity.Left = 0.1534091F;
            this.TxtCustomerCity.MultiLine = false;
            this.TxtCustomerCity.Name = "TxtCustomerCity";
            this.TxtCustomerCity.OutputFormat = resources.GetString("TxtCustomerCity.OutputFormat");
            this.TxtCustomerCity.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtCustomerCity.Text = "TxtCustomerCity";
            this.TxtCustomerCity.Top = 1.875F;
            this.TxtCustomerCity.Width = 2.977273F;
            // 
            // LblUniversal1
            // 
            this.LblUniversal1.Border.BottomColor = System.Drawing.Color.Black;
            this.LblUniversal1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblUniversal1.Border.LeftColor = System.Drawing.Color.Black;
            this.LblUniversal1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblUniversal1.Border.RightColor = System.Drawing.Color.Black;
            this.LblUniversal1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblUniversal1.Border.TopColor = System.Drawing.Color.Black;
            this.LblUniversal1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblUniversal1.Height = 0.1875F;
            this.LblUniversal1.HyperLink = "";
            this.LblUniversal1.Left = 0.1875F;
            this.LblUniversal1.Name = "LblUniversal1";
            this.LblUniversal1.Style = "text-align: left; font-weight: normal; font-size: 9pt; font-family: Microsoft San" +
                "s Serif; ";
            this.LblUniversal1.Text = "Asunto:     Contrato de Servicio Número:";
            this.LblUniversal1.Top = 2.3125F;
            this.LblUniversal1.Width = 2.125F;
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
            this.TxtPolicyNo.Height = 0.1875F;
            this.TxtPolicyNo.Left = 2.3125F;
            this.TxtPolicyNo.MultiLine = false;
            this.TxtPolicyNo.Name = "TxtPolicyNo";
            this.TxtPolicyNo.OutputFormat = resources.GetString("TxtPolicyNo.OutputFormat");
            this.TxtPolicyNo.Style = "text-align: left; font-weight: normal; font-size: 9pt; font-family: Microsoft San" +
                "s Serif; ";
            this.TxtPolicyNo.Text = "TxtPolicyNo";
            this.TxtPolicyNo.Top = 2.3125F;
            this.TxtPolicyNo.Width = 1.852273F;
            // 
            // Label6
            // 
            this.Label6.Border.BottomColor = System.Drawing.Color.Black;
            this.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.LeftColor = System.Drawing.Color.Black;
            this.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.RightColor = System.Drawing.Color.Black;
            this.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.TopColor = System.Drawing.Color.Black;
            this.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Height = 0.1875F;
            this.Label6.HyperLink = "";
            this.Label6.Left = 0.1875F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "text-align: left; font-weight: normal; font-size: 9pt; font-family: Microsoft San" +
                "s Serif; ";
            this.Label6.Text = "Estimado(a) Cliente:";
            this.Label6.Top = 2.625F;
            this.Label6.Width = 1.3125F;
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
            this.Label7.Height = 0.1875F;
            this.Label7.HyperLink = "";
            this.Label7.Left = 0.1875F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "text-align: left; font-weight: normal; font-size: 9pt; font-family: Microsoft San" +
                "s Serif; ";
            this.Label7.Text = "Le felicitamos por haber adquirido nuestro innovador contrato de servicio para ve" +
                "hículo de motor. ";
            this.Label7.Top = 3F;
            this.Label7.Width = 6.0625F;
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
            this.Label8.Height = 0.1875F;
            this.Label8.HyperLink = "";
            this.Label8.Left = 0.1875F;
            this.Label8.Name = "Label8";
            this.Label8.Style = "text-align: left; font-weight: normal; font-size: 9pt; font-family: Microsoft San" +
                "s Serif; ";
            this.Label8.Text = "Este contrato le ayudará a proteger su inversión en su vehículo.";
            this.Label8.Top = 3.1875F;
            this.Label8.Width = 6.0625F;
            // 
            // Label9
            // 
            this.Label9.Border.BottomColor = System.Drawing.Color.Black;
            this.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.LeftColor = System.Drawing.Color.Black;
            this.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.RightColor = System.Drawing.Color.Black;
            this.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.TopColor = System.Drawing.Color.Black;
            this.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Height = 0.1875F;
            this.Label9.HyperLink = "";
            this.Label9.Left = 0.1875F;
            this.Label9.Name = "Label9";
            this.Label9.Style = "text-align: left; font-weight: normal; font-size: 9pt; font-family: Microsoft San" +
                "s Serif; ";
            this.Label9.Text = "Junto  con  esta  carta  incluimos su copia del contrato de servicio.  Sugerimos " +
                "que  la  mantenga  en  un";
            this.Label9.Top = 3.625F;
            this.Label9.Width = 6.125F;
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
            this.Label10.Height = 0.1875F;
            this.Label10.HyperLink = "";
            this.Label10.Left = 0.1875F;
            this.Label10.Name = "Label10";
            this.Label10.Style = "text-align: left; font-weight: normal; font-size: 9pt; font-family: Microsoft San" +
                "s Serif; ";
            this.Label10.Text = "lugar seguro y accesible en caso de emergencia. Recuerde que además  de la protec" +
                "ción contra averías";
            this.Label10.Top = 3.8125F;
            this.Label10.Width = 6.125F;
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
            this.Label11.Height = 0.1875F;
            this.Label11.HyperLink = "";
            this.Label11.Left = 0.1875F;
            this.Label11.Name = "Label11";
            this.Label11.Style = "text-align: left; font-weight: normal; font-size: 9pt; font-family: Microsoft San" +
                "s Serif; ";
            this.Label11.Text = "mecánicas,  nuestro  contrato  de  servicio  también  le brinda asistencia en la " +
                "carretera.  Esta asistencia";
            this.Label11.Top = 4F;
            this.Label11.Width = 6.125F;
            // 
            // Label12
            // 
            this.Label12.Border.BottomColor = System.Drawing.Color.Black;
            this.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label12.Border.LeftColor = System.Drawing.Color.Black;
            this.Label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label12.Border.RightColor = System.Drawing.Color.Black;
            this.Label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label12.Border.TopColor = System.Drawing.Color.Black;
            this.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label12.Height = 0.1875F;
            this.Label12.HyperLink = "";
            this.Label12.Left = 0.1875F;
            this.Label12.Name = "Label12";
            this.Label12.Style = "text-align: left; font-weight: normal; font-size: 9pt; font-family: Microsoft San" +
                "s Serif; ";
            this.Label12.Text = "incluye reembolso por los siguientes servicios:";
            this.Label12.Top = 4.1875F;
            this.Label12.Width = 3.3125F;
            // 
            // Label13
            // 
            this.Label13.Border.BottomColor = System.Drawing.Color.Black;
            this.Label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.LeftColor = System.Drawing.Color.Black;
            this.Label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.RightColor = System.Drawing.Color.Black;
            this.Label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.TopColor = System.Drawing.Color.Black;
            this.Label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Height = 0.1875F;
            this.Label13.HyperLink = "";
            this.Label13.Left = 2.875F;
            this.Label13.Name = "Label13";
            this.Label13.Style = "text-align: left; font-weight: bold; font-size: 9pt; font-family: Microsoft Sans " +
                "Serif; ";
            this.Label13.Text = "Servicio  de  Remolque - $50 por incidente; Servicio";
            this.Label13.Top = 4.1875F;
            this.Label13.Width = 3.4375F;
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
            this.Label14.Left = 0.1875F;
            this.Label14.Name = "Label14";
            this.Label14.Style = "text-align: left; font-weight: bold; font-size: 9pt; font-family: Microsoft Sans " +
                "Serif; ";
            this.Label14.Text = "de   Neumáticos  -  $15  por  incidente  por  cualquier  neumático  desinflado  a" +
                "ccidentalmente;  y";
            this.Label14.Top = 4.375F;
            this.Label14.Width = 6.125F;
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
            this.Label15.Left = 0.1875F;
            this.Label15.Name = "Label15";
            this.Label15.Style = "text-align: left; font-weight: bold; font-size: 9pt; font-family: Microsoft Sans " +
                "Serif; ";
            this.Label15.Text = "Servicio de Cerrajero - $35 por incidente por los servicios de un cerrajero.";
            this.Label15.Top = 4.5625F;
            this.Label15.Width = 6.125F;
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
            this.Label16.Height = 0.1875F;
            this.Label16.HyperLink = "";
            this.Label16.Left = 0.1875F;
            this.Label16.Name = "Label16";
            this.Label16.Style = "text-align: left; font-weight: normal; font-size: 9pt; font-family: Microsoft San" +
                "s Serif; ";
            this.Label16.Text = "Para detalles sobre su protección y los límites y exclusiones de la misma, por fa" +
                "vor refiérase al contrato";
            this.Label16.Top = 5F;
            this.Label16.Width = 6.125F;
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
            this.Label17.Height = 0.1875F;
            this.Label17.HyperLink = "";
            this.Label17.Left = 0.1875F;
            this.Label17.Name = "Label17";
            this.Label17.Style = "text-align: left; font-weight: normal; font-size: 9pt; font-family: Microsoft San" +
                "s Serif; ";
            this.Label17.Text = "de servicio  adjunto. Estamos seguros de que quedará satisfecho con este programa" +
                ".  De  tener alguna";
            this.Label17.Top = 5.1875F;
            this.Label17.Width = 6.125F;
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
            this.Label18.Height = 0.1875F;
            this.Label18.HyperLink = "";
            this.Label18.Left = 0.1875F;
            this.Label18.Name = "Label18";
            this.Label18.Style = "text-align: left; font-weight: normal; font-size: 9pt; font-family: Microsoft San" +
                "s Serif; ";
            this.Label18.Text = "pregunta, favor  comunicarse con uno de nuestros Representantes de Servicio al (7" +
                "87) 622-4000. Será";
            this.Label18.Top = 5.375F;
            this.Label18.Width = 6.125F;
            // 
            // Label19
            // 
            this.Label19.Border.BottomColor = System.Drawing.Color.Black;
            this.Label19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label19.Border.LeftColor = System.Drawing.Color.Black;
            this.Label19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label19.Border.RightColor = System.Drawing.Color.Black;
            this.Label19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label19.Border.TopColor = System.Drawing.Color.Black;
            this.Label19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label19.Height = 0.1875F;
            this.Label19.HyperLink = "";
            this.Label19.Left = 0.1875F;
            this.Label19.Name = "Label19";
            this.Label19.Style = "text-align: left; font-weight: normal; font-size: 9pt; font-family: Microsoft San" +
                "s Serif; ";
            this.Label19.Text = "un placer servirle.";
            this.Label19.Top = 5.5625F;
            this.Label19.Width = 1.875F;
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
            this.Label20.Height = 0.1875F;
            this.Label20.HyperLink = "";
            this.Label20.Left = 0.1875F;
            this.Label20.MultiLine = false;
            this.Label20.Name = "Label20";
            this.Label20.Style = "text-align: left; font-size: 10pt; ";
            this.Label20.Text = "Cordialmente,";
            this.Label20.Top = 6.125F;
            this.Label20.Width = 0.9375F;
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
            this.Label85.Height = 0.1875F;
            this.Label85.HyperLink = "";
            this.Label85.Left = 0.1875F;
            this.Label85.MultiLine = false;
            this.Label85.Name = "Label85";
            this.Label85.Style = "text-decoration: none; text-align: left; font-weight: bold; font-size: 8pt; font-" +
                "family: Times New Roman; ";
            this.Label85.Text = "Presidente";
            this.Label85.Top = 6.9375F;
            this.Label85.Width = 0.75F;
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
            this.LblMechanical.Left = 2.625F;
            this.LblMechanical.MultiLine = false;
            this.LblMechanical.Name = "LblMechanical";
            this.LblMechanical.Style = "text-align: left; font-weight: bold; font-size: 12pt; ";
            this.LblMechanical.Text = "Mechanical Breakdown";
            this.LblMechanical.Top = 1F;
            this.LblMechanical.Width = 2.3125F;
            // 
            // Label90
            // 
            this.Label90.Border.BottomColor = System.Drawing.Color.Black;
            this.Label90.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label90.Border.LeftColor = System.Drawing.Color.Black;
            this.Label90.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label90.Border.RightColor = System.Drawing.Color.Black;
            this.Label90.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label90.Border.TopColor = System.Drawing.Color.Black;
            this.Label90.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label90.Height = 0.1875F;
            this.Label90.HyperLink = "";
            this.Label90.Left = 0.1875F;
            this.Label90.MultiLine = false;
            this.Label90.Name = "Label90";
            this.Label90.Style = "text-align: left; font-size: 10pt; ";
            this.Label90.Text = "Anejo";
            this.Label90.Top = 7.5625F;
            this.Label90.Width = 0.9375F;
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
            this.Label75.Left = 1.078125F;
            this.Label75.MultiLine = false;
            this.Label75.Name = "Label75";
            this.Label75.Style = "text-align: center; font-weight: bold; font-size: 11.25pt; font-family: Times New" +
                " Roman; ";
            this.Label75.Text = "LAS VISTAS INSURANCE AGENCY, CORP.";
            this.Label75.Top = 0F;
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
            this.Label77.Left = 1.078125F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-align: center; font-weight: bold; font-size: 6pt; font-family: Times New Rom" +
                "an; ";
            this.Label77.Text = "P.O. Box 195585 San Juan Puerto Rico, PR  00919-5585 Tel (787) 763-4010 Fax (787)" +
                " 763-3525";
            this.Label77.Top = 0.25F;
            this.Label77.Width = 5.125F;
            // 
            // Label88
            // 
            this.Label88.Border.BottomColor = System.Drawing.Color.Black;
            this.Label88.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label88.Border.LeftColor = System.Drawing.Color.Black;
            this.Label88.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label88.Border.RightColor = System.Drawing.Color.Black;
            this.Label88.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label88.Border.TopColor = System.Drawing.Color.Black;
            this.Label88.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label88.Height = 0.2F;
            this.Label88.HyperLink = "";
            this.Label88.Left = 1.1875F;
            this.Label88.MultiLine = false;
            this.Label88.Name = "Label88";
            this.Label88.Style = "text-align: center; font-weight: bold; font-size: 9pt; ";
            this.Label88.Text = "P.O. Box 195585 San Juan Puerto Rico, PR  00919-5585";
            this.Label88.Top = 0F;
            this.Label88.Width = 3.875F;
            // 
            // Label89
            // 
            this.Label89.Border.BottomColor = System.Drawing.Color.Black;
            this.Label89.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label89.Border.LeftColor = System.Drawing.Color.Black;
            this.Label89.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label89.Border.RightColor = System.Drawing.Color.Black;
            this.Label89.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label89.Border.TopColor = System.Drawing.Color.Black;
            this.Label89.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label89.Height = 0.2F;
            this.Label89.HyperLink = "";
            this.Label89.Left = 1.5625F;
            this.Label89.MultiLine = false;
            this.Label89.Name = "Label89";
            this.Label89.Style = "text-align: center; font-weight: bold; font-size: 9pt; ";
            this.Label89.Text = "Tel (787) 763-4010 Fax (787) 763-3525";
            this.Label89.Top = 0.1458334F;
            this.Label89.Width = 3.125F;
            // 
            // ActiveReport31
            // 
            this.PageSettings.Margins.Bottom = 0.4F;
            this.PageSettings.Margins.Left = 0.7F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.479167F;
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
            ((System.ComponentModel.ISupportInitialize)(this.TxtDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerAddr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerAddr2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblUniversal1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPolicyNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label85)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblMechanical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label90)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label88)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label89)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
       
			// Attach Report Events
			this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
			this.ReportStart += new System.EventHandler(this.CartaAutoGuard_ReportStart);
		 }

		#endregion
	}
}
