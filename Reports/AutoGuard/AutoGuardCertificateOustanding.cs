using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports
{
	public class AutoGuardCertificateOustanding : DataDynamics.ActiveReports.ActiveReport3
	{
		string _ToDate;
		string _ReportType;
		bool   _Summary = false;
        private Label Label75;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox4;
        private Label label2;
        private Label label4;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox8;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox7;
        private TextBox textBox6;
        private TextBox textBox5;
        string _mHeadCompany;

        public AutoGuardCertificateOustanding(string ToDate, string ReportType, bool Summary, string mHeadCompany)
		{
			_ToDate = ToDate;
			_ReportType = ReportType;
			_Summary  =  Summary;
            _mHeadCompany = mHeadCompany;

			InitializeComponent();
		}

		private void AutoGuardCertificateOustanding_ReportStart(object sender, System.EventArgs eArgs)
		{
            Label75.Text = _mHeadCompany;
			if (_Summary)
			{
				this.Detail.Visible = false;
			}

			this.lblDate.Text = "Date:"+DateTime.Now.ToShortDateString();
			this.lblTime.Text = "Time:"+DateTime.Now.ToShortTimeString();

			if (!_ToDate.Trim().Equals(""))
			{
				this.lblCriterias.Text = _ReportType + " As of: " + _ToDate;
			}
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		#region ActiveReports Designer generated code
		private ReportHeader ReportHeader = null;
		private PageHeader PageHeader = null;
		private Label lblCriterias = null;
		private Label Label80 = null;
		private TextBox TextBox17 = null;
		private Label lblDate = null;
		private Label lblTime = null;
        private Shape Shape3 = null;
		private Label Label108 = null;
		private Label Label109 = null;
		private Label Label113 = null;
		private Label Label122 = null;
		private Label Label125 = null;
        private Label Label126 = null;
		private Label Label137 = null;
		private Label Label138 = null;
		private Label Label139 = null;
        private Label Label140 = null;
		private Label Label144 = null;
		private Label Label145 = null;
		private Label Label146 = null;
		private Label LblCompanyHeader = null;
        private Label Label77 = null;
		private GroupHeader GroupHeader1 = null;
		private Label Label131 = null;
		private Label Label132 = null;
		private Label Label133 = null;
        private Detail Detail = null;
		private TextBox TxtRegCode = null;
		private TextBox txtCustomerName = null;
		private TextBox txtPaidAmount = null;
		private TextBox txtEntryDate = null;
		private TextBox txtEffectiveDate = null;
		private TextBox txtTotalPremium = null;
		private TextBox TextBox30 = null;
		private TextBox TextBox31 = null;
		private TextBox TextBox32 = null;
		private TextBox TextBox33 = null;
        private TextBox TextBox34 = null;
		private TextBox TextBox48 = null;
		private TextBox TextBox49 = null;
		private TextBox TextBox50 = null;
		private GroupFooter GroupFooter1 = null;
		private Label Label134 = null;
		private Label Label135 = null;
		private TextBox TextBox25 = null;
		private TextBox TextBox28 = null;
		private TextBox TextBox29 = null;
		private TextBox TextBox35 = null;
		private TextBox TextBox36 = null;
		private TextBox TextBox37 = null;
		private TextBox TextBox38 = null;
        private TextBox TextBox39 = null;
		private PageFooter PageFooter = null;
		private ReportFooter ReportFooter = null;
		private TextBox TextBox19 = null;
		private Label Label130 = null;
		private TextBox TextBox20 = null;
		private TextBox TextBox21 = null;
		private TextBox TextBox40 = null;
		private TextBox TextBox41 = null;
		private TextBox TextBox42 = null;
		private TextBox TextBox43 = null;
		private TextBox TextBox44 = null;
		private Line Line9 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoGuardCertificateOustanding));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.TxtRegCode = new DataDynamics.ActiveReports.TextBox();
            this.txtCustomerName = new DataDynamics.ActiveReports.TextBox();
            this.txtPaidAmount = new DataDynamics.ActiveReports.TextBox();
            this.txtEntryDate = new DataDynamics.ActiveReports.TextBox();
            this.txtEffectiveDate = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalPremium = new DataDynamics.ActiveReports.TextBox();
            this.TextBox30 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox31 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox32 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox33 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox34 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox48 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox49 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox50 = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.TextBox19 = new DataDynamics.ActiveReports.TextBox();
            this.Label130 = new DataDynamics.ActiveReports.Label();
            this.TextBox20 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox21 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox40 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox41 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox42 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox43 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox44 = new DataDynamics.ActiveReports.TextBox();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.lblCriterias = new DataDynamics.ActiveReports.Label();
            this.Label80 = new DataDynamics.ActiveReports.Label();
            this.TextBox17 = new DataDynamics.ActiveReports.TextBox();
            this.lblDate = new DataDynamics.ActiveReports.Label();
            this.lblTime = new DataDynamics.ActiveReports.Label();
            this.Shape3 = new DataDynamics.ActiveReports.Shape();
            this.Label108 = new DataDynamics.ActiveReports.Label();
            this.Label109 = new DataDynamics.ActiveReports.Label();
            this.Label113 = new DataDynamics.ActiveReports.Label();
            this.Label122 = new DataDynamics.ActiveReports.Label();
            this.Label125 = new DataDynamics.ActiveReports.Label();
            this.Label126 = new DataDynamics.ActiveReports.Label();
            this.Label137 = new DataDynamics.ActiveReports.Label();
            this.Label138 = new DataDynamics.ActiveReports.Label();
            this.Label139 = new DataDynamics.ActiveReports.Label();
            this.Label140 = new DataDynamics.ActiveReports.Label();
            this.Label144 = new DataDynamics.ActiveReports.Label();
            this.Label145 = new DataDynamics.ActiveReports.Label();
            this.Label146 = new DataDynamics.ActiveReports.Label();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label3 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.GroupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.Label131 = new DataDynamics.ActiveReports.Label();
            this.Label132 = new DataDynamics.ActiveReports.Label();
            this.Label133 = new DataDynamics.ActiveReports.Label();
            this.GroupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.Label134 = new DataDynamics.ActiveReports.Label();
            this.Label135 = new DataDynamics.ActiveReports.Label();
            this.TextBox25 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox28 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox29 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox35 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox36 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox37 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox38 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox39 = new DataDynamics.ActiveReports.TextBox();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRegCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaidAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label113)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label122)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label125)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label126)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label137)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label138)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label139)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label140)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label144)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label145)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label146)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TxtRegCode,
            this.txtCustomerName,
            this.txtPaidAmount,
            this.txtEntryDate,
            this.txtEffectiveDate,
            this.txtTotalPremium,
            this.TextBox30,
            this.TextBox31,
            this.TextBox32,
            this.TextBox33,
            this.TextBox34,
            this.TextBox48,
            this.TextBox49,
            this.TextBox50,
            this.textBox1,
            this.textBox2,
            this.textBox4,
            this.textBox3,
            this.textBox8,
            this.textBox7});
            this.Detail.Height = 0.3125F;
            this.Detail.Name = "Detail";
            // 
            // TxtRegCode
            // 
            this.TxtRegCode.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtRegCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtRegCode.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtRegCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtRegCode.Border.RightColor = System.Drawing.Color.Black;
            this.TxtRegCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtRegCode.Border.TopColor = System.Drawing.Color.Black;
            this.TxtRegCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtRegCode.DataField = "PolicyType";
            this.TxtRegCode.Height = 0.125F;
            this.TxtRegCode.Left = 0.1875F;
            this.TxtRegCode.Name = "TxtRegCode";
            this.TxtRegCode.Style = "text-align: left; font-size: 7pt; ";
            this.TxtRegCode.Text = null;
            this.TxtRegCode.Top = 0F;
            this.TxtRegCode.Width = 0.25F;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCustomerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomerName.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCustomerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomerName.Border.RightColor = System.Drawing.Color.Black;
            this.txtCustomerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomerName.Border.TopColor = System.Drawing.Color.Black;
            this.txtCustomerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomerName.DataField = "CustomerName";
            this.txtCustomerName.Height = 0.125F;
            this.txtCustomerName.Left = 1.8125F;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Style = "text-align: left; font-size: 7pt; ";
            this.txtCustomerName.Text = null;
            this.txtCustomerName.Top = 0F;
            this.txtCustomerName.Width = 1.3125F;
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPaidAmount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPaidAmount.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPaidAmount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPaidAmount.Border.RightColor = System.Drawing.Color.Black;
            this.txtPaidAmount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPaidAmount.Border.TopColor = System.Drawing.Color.Black;
            this.txtPaidAmount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPaidAmount.DataField = "PaidAmount";
            this.txtPaidAmount.Height = 0.125F;
            this.txtPaidAmount.Left = 11.125F;
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.OutputFormat = resources.GetString("txtPaidAmount.OutputFormat");
            this.txtPaidAmount.Style = "text-align: right; font-size: 7pt; ";
            this.txtPaidAmount.Text = null;
            this.txtPaidAmount.Top = 0F;
            this.txtPaidAmount.Width = 0.8125F;
            // 
            // txtEntryDate
            // 
            this.txtEntryDate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEntryDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEntryDate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEntryDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEntryDate.Border.RightColor = System.Drawing.Color.Black;
            this.txtEntryDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEntryDate.Border.TopColor = System.Drawing.Color.Black;
            this.txtEntryDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEntryDate.DataField = "EntryDate";
            this.txtEntryDate.Height = 0.125F;
            this.txtEntryDate.Left = 7.25F;
            this.txtEntryDate.Name = "txtEntryDate";
            this.txtEntryDate.OutputFormat = resources.GetString("txtEntryDate.OutputFormat");
            this.txtEntryDate.Style = "text-align: left; font-size: 7pt; ";
            this.txtEntryDate.Text = null;
            this.txtEntryDate.Top = 0F;
            this.txtEntryDate.Width = 0.5625F;
            // 
            // txtEffectiveDate
            // 
            this.txtEffectiveDate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEffectiveDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEffectiveDate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEffectiveDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEffectiveDate.Border.RightColor = System.Drawing.Color.Black;
            this.txtEffectiveDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEffectiveDate.Border.TopColor = System.Drawing.Color.Black;
            this.txtEffectiveDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEffectiveDate.DataField = "EffectiveDate";
            this.txtEffectiveDate.Height = 0.125F;
            this.txtEffectiveDate.Left = 6.5625F;
            this.txtEffectiveDate.Name = "txtEffectiveDate";
            this.txtEffectiveDate.OutputFormat = resources.GetString("txtEffectiveDate.OutputFormat");
            this.txtEffectiveDate.Style = "text-align: left; font-size: 7pt; ";
            this.txtEffectiveDate.Text = null;
            this.txtEffectiveDate.Top = 0F;
            this.txtEffectiveDate.Width = 0.625F;
            // 
            // txtTotalPremium
            // 
            this.txtTotalPremium.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalPremium.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalPremium.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalPremium.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalPremium.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalPremium.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalPremium.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalPremium.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalPremium.DataField = "TotalPremium";
            this.txtTotalPremium.Height = 0.125F;
            this.txtTotalPremium.Left = 9.4375F;
            this.txtTotalPremium.Name = "txtTotalPremium";
            this.txtTotalPremium.OutputFormat = resources.GetString("txtTotalPremium.OutputFormat");
            this.txtTotalPremium.Style = "text-align: right; font-size: 7pt; ";
            this.txtTotalPremium.Text = null;
            this.txtTotalPremium.Top = 0F;
            this.txtTotalPremium.Width = 0.75F;
            // 
            // TextBox30
            // 
            this.TextBox30.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox30.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox30.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox30.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox30.DataField = "DueAmount";
            this.TextBox30.Height = 0.125F;
            this.TextBox30.Left = 12F;
            this.TextBox30.Name = "TextBox30";
            this.TextBox30.OutputFormat = resources.GetString("TextBox30.OutputFormat");
            this.TextBox30.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox30.Text = null;
            this.TextBox30.Top = 0F;
            this.TextBox30.Width = 0.6875F;
            // 
            // TextBox31
            // 
            this.TextBox31.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox31.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox31.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox31.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox31.DataField = "Days30";
            this.TextBox31.Height = 0.125F;
            this.TextBox31.Left = 12.75F;
            this.TextBox31.Name = "TextBox31";
            this.TextBox31.OutputFormat = resources.GetString("TextBox31.OutputFormat");
            this.TextBox31.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox31.Text = null;
            this.TextBox31.Top = 0F;
            this.TextBox31.Width = 0.8125F;
            // 
            // TextBox32
            // 
            this.TextBox32.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.DataField = "Days60";
            this.TextBox32.Height = 0.125F;
            this.TextBox32.Left = 13.625F;
            this.TextBox32.Name = "TextBox32";
            this.TextBox32.OutputFormat = resources.GetString("TextBox32.OutputFormat");
            this.TextBox32.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox32.Text = null;
            this.TextBox32.Top = 0F;
            this.TextBox32.Width = 0.8125F;
            // 
            // TextBox33
            // 
            this.TextBox33.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox33.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox33.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox33.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox33.DataField = "Days90";
            this.TextBox33.Height = 0.125F;
            this.TextBox33.Left = 14.5F;
            this.TextBox33.Name = "TextBox33";
            this.TextBox33.OutputFormat = resources.GetString("TextBox33.OutputFormat");
            this.TextBox33.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox33.Text = null;
            this.TextBox33.Top = 0F;
            this.TextBox33.Width = 0.8125F;
            // 
            // TextBox34
            // 
            this.TextBox34.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox34.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox34.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox34.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox34.DataField = "Over90";
            this.TextBox34.Height = 0.125F;
            this.TextBox34.Left = 15.375F;
            this.TextBox34.Name = "TextBox34";
            this.TextBox34.OutputFormat = resources.GetString("TextBox34.OutputFormat");
            this.TextBox34.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox34.Text = null;
            this.TextBox34.Top = 0F;
            this.TextBox34.Width = 0.8125F;
            // 
            // TextBox48
            // 
            this.TextBox48.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox48.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox48.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox48.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox48.DataField = "status";
            this.TextBox48.Height = 0.125F;
            this.TextBox48.Left = 5F;
            this.TextBox48.Name = "TextBox48";
            this.TextBox48.OutputFormat = resources.GetString("TextBox48.OutputFormat");
            this.TextBox48.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox48.Text = null;
            this.TextBox48.Top = 0F;
            this.TextBox48.Width = 0.75F;
            // 
            // TextBox49
            // 
            this.TextBox49.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox49.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox49.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox49.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox49.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox49.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox49.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox49.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox49.DataField = "CancellationDate";
            this.TextBox49.Height = 0.125F;
            this.TextBox49.Left = 7.9375F;
            this.TextBox49.Name = "TextBox49";
            this.TextBox49.OutputFormat = resources.GetString("TextBox49.OutputFormat");
            this.TextBox49.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox49.Text = null;
            this.TextBox49.Top = 0F;
            this.TextBox49.Width = 0.625F;
            // 
            // TextBox50
            // 
            this.TextBox50.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox50.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox50.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox50.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox50.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox50.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox50.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox50.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox50.DataField = "CancellationEntryDate";
            this.TextBox50.Height = 0.125F;
            this.TextBox50.Left = 8.6875F;
            this.TextBox50.Name = "TextBox50";
            this.TextBox50.OutputFormat = resources.GetString("TextBox50.OutputFormat");
            this.TextBox50.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox50.Text = null;
            this.TextBox50.Top = 0F;
            this.TextBox50.Width = 0.5625F;
            // 
            // textBox1
            // 
            this.textBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.RightColor = System.Drawing.Color.Black;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.TopColor = System.Drawing.Color.Black;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.DataField = "RetroactiveDate";
            this.textBox1.Height = 0.125F;
            this.textBox1.Left = 5.8125F;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "text-align: left; font-size: 7pt; ";
            this.textBox1.Text = null;
            this.textBox1.Top = 0F;
            this.textBox1.Width = 0.625F;
            // 
            // textBox2
            // 
            this.textBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.RightColor = System.Drawing.Color.Black;
            this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.TopColor = System.Drawing.Color.Black;
            this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.DataField = "PolicyNo";
            this.textBox2.Height = 0.125F;
            this.textBox2.Left = 0.5625F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "text-align: left; font-size: 7pt; ";
            this.textBox2.Text = null;
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.5F;
            // 
            // textBox4
            // 
            this.textBox4.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.RightColor = System.Drawing.Color.Black;
            this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.TopColor = System.Drawing.Color.Black;
            this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.DataField = "Sufijo";
            this.textBox4.Height = 0.125F;
            this.textBox4.Left = 1.3125F;
            this.textBox4.Name = "textBox4";
            this.textBox4.Style = "text-align: left; font-size: 7pt; ";
            this.textBox4.Text = null;
            this.textBox4.Top = 0F;
            this.textBox4.Width = 0.25F;
            // 
            // textBox3
            // 
            this.textBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.RightColor = System.Drawing.Color.Black;
            this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.TopColor = System.Drawing.Color.Black;
            this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.DataField = "AgentDesc";
            this.textBox3.Height = 0.125F;
            this.textBox3.Left = 4.125F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "text-align: left; font-size: 7pt; ";
            this.textBox3.Text = null;
            this.textBox3.Top = 0F;
            this.textBox3.Width = 0.75F;
            // 
            // textBox8
            // 
            this.textBox8.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.RightColor = System.Drawing.Color.Black;
            this.textBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.TopColor = System.Drawing.Color.Black;
            this.textBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.DataField = "AgencyDesc";
            this.textBox8.Height = 0.125F;
            this.textBox8.Left = 3.1875F;
            this.textBox8.Name = "textBox8";
            this.textBox8.Style = "text-align: left; font-size: 7pt; ";
            this.textBox8.Text = null;
            this.textBox8.Top = 0F;
            this.textBox8.Width = 0.875F;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Height = 0F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TextBox19,
            this.Label130,
            this.TextBox20,
            this.TextBox21,
            this.TextBox40,
            this.TextBox41,
            this.TextBox42,
            this.TextBox43,
            this.TextBox44,
            this.Line9,
            this.textBox6});
            this.ReportFooter.Height = 0.2076389F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // TextBox19
            // 
            this.TextBox19.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox19.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox19.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox19.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox19.DataField = "TaskControlID";
            this.TextBox19.Height = 0.1875F;
            this.TextBox19.Left = 2.645833F;
            this.TextBox19.Name = "TextBox19";
            this.TextBox19.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox19.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox19.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox19.Text = null;
            this.TextBox19.Top = 0F;
            this.TextBox19.Width = 0.75F;
            // 
            // Label130
            // 
            this.Label130.Border.BottomColor = System.Drawing.Color.Black;
            this.Label130.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label130.Border.LeftColor = System.Drawing.Color.Black;
            this.Label130.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label130.Border.RightColor = System.Drawing.Color.Black;
            this.Label130.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label130.Border.TopColor = System.Drawing.Color.Black;
            this.Label130.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label130.Height = 0.1875F;
            this.Label130.HyperLink = "";
            this.Label130.Left = 0.4375F;
            this.Label130.Name = "Label130";
            this.Label130.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label130.Text = "Grand Total:";
            this.Label130.Top = 0F;
            this.Label130.Width = 1F;
            // 
            // TextBox20
            // 
            this.TextBox20.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox20.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox20.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox20.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox20.DataField = "TotalPremium";
            this.TextBox20.Height = 0.1875F;
            this.TextBox20.Left = 9.4375F;
            this.TextBox20.Name = "TextBox20";
            this.TextBox20.OutputFormat = resources.GetString("TextBox20.OutputFormat");
            this.TextBox20.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox20.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox20.Text = null;
            this.TextBox20.Top = 0F;
            this.TextBox20.Width = 0.75F;
            // 
            // TextBox21
            // 
            this.TextBox21.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox21.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox21.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox21.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox21.DataField = "PaidAmount";
            this.TextBox21.Height = 0.1875F;
            this.TextBox21.Left = 11.125F;
            this.TextBox21.Name = "TextBox21";
            this.TextBox21.OutputFormat = resources.GetString("TextBox21.OutputFormat");
            this.TextBox21.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox21.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox21.Text = null;
            this.TextBox21.Top = 0F;
            this.TextBox21.Width = 0.8125F;
            // 
            // TextBox40
            // 
            this.TextBox40.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox40.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox40.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox40.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox40.DataField = "DueAmount";
            this.TextBox40.Height = 0.1875F;
            this.TextBox40.Left = 12F;
            this.TextBox40.Name = "TextBox40";
            this.TextBox40.OutputFormat = resources.GetString("TextBox40.OutputFormat");
            this.TextBox40.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox40.SummaryGroup = "GroupHeader1";
            this.TextBox40.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox40.Text = null;
            this.TextBox40.Top = 0F;
            this.TextBox40.Width = 0.6875F;
            // 
            // TextBox41
            // 
            this.TextBox41.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox41.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox41.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox41.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox41.DataField = "Days30";
            this.TextBox41.Height = 0.1875F;
            this.TextBox41.Left = 12.75F;
            this.TextBox41.Name = "TextBox41";
            this.TextBox41.OutputFormat = resources.GetString("TextBox41.OutputFormat");
            this.TextBox41.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox41.SummaryGroup = "GroupHeader1";
            this.TextBox41.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox41.Text = null;
            this.TextBox41.Top = 0F;
            this.TextBox41.Width = 0.8125F;
            // 
            // TextBox42
            // 
            this.TextBox42.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox42.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox42.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox42.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox42.DataField = "Days60";
            this.TextBox42.Height = 0.1875F;
            this.TextBox42.Left = 13.625F;
            this.TextBox42.Name = "TextBox42";
            this.TextBox42.OutputFormat = resources.GetString("TextBox42.OutputFormat");
            this.TextBox42.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox42.SummaryGroup = "GroupHeader1";
            this.TextBox42.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox42.Text = null;
            this.TextBox42.Top = 0F;
            this.TextBox42.Width = 0.8125F;
            // 
            // TextBox43
            // 
            this.TextBox43.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox43.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox43.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox43.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox43.DataField = "Days90";
            this.TextBox43.Height = 0.1875F;
            this.TextBox43.Left = 14.5F;
            this.TextBox43.Name = "TextBox43";
            this.TextBox43.OutputFormat = resources.GetString("TextBox43.OutputFormat");
            this.TextBox43.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox43.SummaryGroup = "GroupHeader1";
            this.TextBox43.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox43.Text = null;
            this.TextBox43.Top = 0F;
            this.TextBox43.Width = 0.8125F;
            // 
            // TextBox44
            // 
            this.TextBox44.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox44.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox44.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox44.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox44.DataField = "Over90";
            this.TextBox44.Height = 0.1875F;
            this.TextBox44.Left = 15.375F;
            this.TextBox44.Name = "TextBox44";
            this.TextBox44.OutputFormat = resources.GetString("TextBox44.OutputFormat");
            this.TextBox44.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox44.SummaryGroup = "GroupHeader1";
            this.TextBox44.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox44.Text = null;
            this.TextBox44.Top = 0F;
            this.TextBox44.Width = 0.8125F;
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
            this.Line9.Left = 1.25F;
            this.Line9.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 0F;
            this.Line9.Width = 15F;
            this.Line9.X1 = 1.25F;
            this.Line9.X2 = 16.25F;
            this.Line9.Y1 = 0F;
            this.Line9.Y2 = 0F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblCriterias,
            this.Label80,
            this.TextBox17,
            this.lblDate,
            this.lblTime,
            this.Shape3,
            this.Label108,
            this.Label109,
            this.Label113,
            this.Label122,
            this.Label125,
            this.Label126,
            this.Label137,
            this.Label138,
            this.Label139,
            this.Label140,
            this.Label144,
            this.Label145,
            this.Label146,
            this.Label75,
            this.Label77,
            this.label1,
            this.label2,
            this.label4,
            this.label3,
            this.label5,
            this.label6,
            this.label7});
            this.PageHeader.Height = 1.375F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // lblCriterias
            // 
            this.lblCriterias.Border.BottomColor = System.Drawing.Color.Black;
            this.lblCriterias.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCriterias.Border.LeftColor = System.Drawing.Color.Black;
            this.lblCriterias.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCriterias.Border.RightColor = System.Drawing.Color.Black;
            this.lblCriterias.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCriterias.Border.TopColor = System.Drawing.Color.Black;
            this.lblCriterias.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCriterias.Height = 0.1875F;
            this.lblCriterias.HyperLink = "";
            this.lblCriterias.Left = 4.9375F;
            this.lblCriterias.MultiLine = false;
            this.lblCriterias.Name = "lblCriterias";
            this.lblCriterias.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.lblCriterias.Text = "Policies Certificate Outstanding";
            this.lblCriterias.Top = 0.375F;
            this.lblCriterias.Width = 5.125F;
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
            this.Label80.Height = 0.2F;
            this.Label80.HyperLink = "";
            this.Label80.Left = 12.9375F;
            this.Label80.Name = "Label80";
            this.Label80.Style = "text-align: right; font-size: 8pt; ";
            this.Label80.Text = "Page";
            this.Label80.Top = 0.0625F;
            this.Label80.Width = 0.5F;
            // 
            // TextBox17
            // 
            this.TextBox17.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox17.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox17.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox17.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox17.Height = 0.1875F;
            this.TextBox17.Left = 13.4375F;
            this.TextBox17.MultiLine = false;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat");
            this.TextBox17.Style = "text-align: right; font-size: 8pt; vertical-align: top; ";
            this.TextBox17.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox17.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.TextBox17.Text = null;
            this.TextBox17.Top = 0.0625F;
            this.TextBox17.Width = 0.322917F;
            // 
            // lblDate
            // 
            this.lblDate.Border.BottomColor = System.Drawing.Color.Black;
            this.lblDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDate.Border.LeftColor = System.Drawing.Color.Black;
            this.lblDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDate.Border.RightColor = System.Drawing.Color.Black;
            this.lblDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDate.Border.TopColor = System.Drawing.Color.Black;
            this.lblDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDate.Height = 0.2F;
            this.lblDate.HyperLink = "";
            this.lblDate.Left = 0.25F;
            this.lblDate.Name = "lblDate";
            this.lblDate.Style = "text-align: left; font-size: 8pt; ";
            this.lblDate.Text = "lblDate";
            this.lblDate.Top = 0.0625F;
            this.lblDate.Width = 0.9090909F;
            // 
            // lblTime
            // 
            this.lblTime.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTime.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTime.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTime.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTime.Border.RightColor = System.Drawing.Color.Black;
            this.lblTime.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTime.Border.TopColor = System.Drawing.Color.Black;
            this.lblTime.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTime.Height = 0.2F;
            this.lblTime.HyperLink = "";
            this.lblTime.Left = 0.25F;
            this.lblTime.Name = "lblTime";
            this.lblTime.Style = "text-align: left; font-size: 8pt; ";
            this.lblTime.Text = "lblTime";
            this.lblTime.Top = 0.25F;
            this.lblTime.Width = 0.9090909F;
            // 
            // Shape3
            // 
            this.Shape3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Shape3.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.RightColor = System.Drawing.Color.Black;
            this.Shape3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.TopColor = System.Drawing.Color.Black;
            this.Shape3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Height = 0.3125F;
            this.Shape3.Left = 0.125F;
            this.Shape3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Shape3.Name = "Shape3";
            this.Shape3.RoundingRadius = 9.999999F;
            this.Shape3.Top = 0.6875F;
            this.Shape3.Width = 16.875F;
            // 
            // Label108
            // 
            this.Label108.Border.BottomColor = System.Drawing.Color.Black;
            this.Label108.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label108.Border.LeftColor = System.Drawing.Color.Black;
            this.Label108.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label108.Border.RightColor = System.Drawing.Color.Black;
            this.Label108.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label108.Border.TopColor = System.Drawing.Color.Black;
            this.Label108.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label108.Height = 0.3125F;
            this.Label108.HyperLink = "";
            this.Label108.Left = 0.125F;
            this.Label108.Name = "Label108";
            this.Label108.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label108.Text = "Policy Type";
            this.Label108.Top = 0.6875F;
            this.Label108.Width = 0.4375F;
            // 
            // Label109
            // 
            this.Label109.Border.BottomColor = System.Drawing.Color.Black;
            this.Label109.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Border.LeftColor = System.Drawing.Color.Black;
            this.Label109.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Border.RightColor = System.Drawing.Color.Black;
            this.Label109.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Border.TopColor = System.Drawing.Color.Black;
            this.Label109.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Height = 0.1875F;
            this.Label109.HyperLink = "";
            this.Label109.Left = 7.25F;
            this.Label109.Name = "Label109";
            this.Label109.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label109.Text = "Entry Date";
            this.Label109.Top = 0.6875F;
            this.Label109.Width = 0.6875F;
            // 
            // Label113
            // 
            this.Label113.Border.BottomColor = System.Drawing.Color.Black;
            this.Label113.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label113.Border.LeftColor = System.Drawing.Color.Black;
            this.Label113.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label113.Border.RightColor = System.Drawing.Color.Black;
            this.Label113.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label113.Border.TopColor = System.Drawing.Color.Black;
            this.Label113.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label113.Height = 0.1875F;
            this.Label113.HyperLink = "";
            this.Label113.Left = 1.875F;
            this.Label113.Name = "Label113";
            this.Label113.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label113.Text = "Customer Name";
            this.Label113.Top = 0.6875F;
            this.Label113.Width = 1.0625F;
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
            this.Label122.Left = 9.4375F;
            this.Label122.Name = "Label122";
            this.Label122.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label122.Text = "Tot. Premium";
            this.Label122.Top = 0.6875F;
            this.Label122.Width = 0.875F;
            // 
            // Label125
            // 
            this.Label125.Border.BottomColor = System.Drawing.Color.Black;
            this.Label125.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label125.Border.LeftColor = System.Drawing.Color.Black;
            this.Label125.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label125.Border.RightColor = System.Drawing.Color.Black;
            this.Label125.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label125.Border.TopColor = System.Drawing.Color.Black;
            this.Label125.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label125.Height = 0.1875F;
            this.Label125.HyperLink = "";
            this.Label125.Left = 6.5625F;
            this.Label125.Name = "Label125";
            this.Label125.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label125.Text = "Effec. Date";
            this.Label125.Top = 0.6875F;
            this.Label125.Width = 0.6875F;
            // 
            // Label126
            // 
            this.Label126.Border.BottomColor = System.Drawing.Color.Black;
            this.Label126.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label126.Border.LeftColor = System.Drawing.Color.Black;
            this.Label126.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label126.Border.RightColor = System.Drawing.Color.Black;
            this.Label126.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label126.Border.TopColor = System.Drawing.Color.Black;
            this.Label126.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label126.Height = 0.1875F;
            this.Label126.HyperLink = "";
            this.Label126.Left = 10.4375F;
            this.Label126.Name = "Label126";
            this.Label126.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label126.Text = "Surcharge";
            this.Label126.Top = 0.6875F;
            this.Label126.Width = 0.75F;
            // 
            // Label137
            // 
            this.Label137.Border.BottomColor = System.Drawing.Color.Black;
            this.Label137.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label137.Border.LeftColor = System.Drawing.Color.Black;
            this.Label137.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label137.Border.RightColor = System.Drawing.Color.Black;
            this.Label137.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label137.Border.TopColor = System.Drawing.Color.Black;
            this.Label137.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label137.Height = 0.2F;
            this.Label137.HyperLink = "";
            this.Label137.Left = 13.125F;
            this.Label137.Name = "Label137";
            this.Label137.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label137.Text = "30-Days";
            this.Label137.Top = 0.6875F;
            this.Label137.Width = 0.5F;
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
            this.Label138.Height = 0.2F;
            this.Label138.HyperLink = "";
            this.Label138.Left = 13.9375F;
            this.Label138.Name = "Label138";
            this.Label138.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label138.Text = "60-Days";
            this.Label138.Top = 0.6875F;
            this.Label138.Width = 0.5F;
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
            this.Label139.Height = 0.2F;
            this.Label139.HyperLink = "";
            this.Label139.Left = 14.8125F;
            this.Label139.Name = "Label139";
            this.Label139.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label139.Text = "90-Days";
            this.Label139.Top = 0.6875F;
            this.Label139.Width = 0.5F;
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
            this.Label140.Height = 0.2F;
            this.Label140.HyperLink = "";
            this.Label140.Left = 15.6875F;
            this.Label140.Name = "Label140";
            this.Label140.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label140.Text = "Over-90";
            this.Label140.Top = 0.6875F;
            this.Label140.Width = 0.5F;
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
            this.Label144.Left = 5F;
            this.Label144.Name = "Label144";
            this.Label144.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label144.Text = "Status";
            this.Label144.Top = 0.6875F;
            this.Label144.Width = 0.6875F;
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
            this.Label145.Left = 8F;
            this.Label145.Name = "Label145";
            this.Label145.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label145.Text = "Canc. Date";
            this.Label145.Top = 0.6875F;
            this.Label145.Width = 0.6875F;
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
            this.Label146.Left = 8.75F;
            this.Label146.Name = "Label146";
            this.Label146.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label146.Text = "Canc. Entry";
            this.Label146.Top = 0.6875F;
            this.Label146.Width = 0.6875F;
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
            this.Label75.Left = 4.9375F;
            this.Label75.MultiLine = false;
            this.Label75.Name = "Label75";
            this.Label75.Style = "text-align: center; font-weight: bold; font-size: 11.25pt; font-family: Times New" +
                " Roman; ";
            this.Label75.Text = "PUERTO RICO MEDICAL DEFENSE INSURANCE COMPANY";
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
            this.Label77.Left = 4.9375F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-align: center; font-weight: bold; font-size: 6pt; font-family: Times New Rom" +
                "an; ";
            this.Label77.Text = "";
            this.Label77.Top = 0.25F;
            this.Label77.Width = 5.125F;
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
            this.label1.Left = 5.8125F;
            this.label1.Name = "label1";
            this.label1.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.label1.Text = "Retro. Date";
            this.label1.Top = 0.6875F;
            this.label1.Width = 0.6875F;
            // 
            // label2
            // 
            this.label2.Border.BottomColor = System.Drawing.Color.Black;
            this.label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.LeftColor = System.Drawing.Color.Black;
            this.label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.RightColor = System.Drawing.Color.Black;
            this.label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.TopColor = System.Drawing.Color.Black;
            this.label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Height = 0.3125F;
            this.label2.HyperLink = "";
            this.label2.Left = 0.625F;
            this.label2.Name = "label2";
            this.label2.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.label2.Text = "Policy No.";
            this.label2.Top = 0.6875F;
            this.label2.Width = 0.4375F;
            // 
            // label4
            // 
            this.label4.Border.BottomColor = System.Drawing.Color.Black;
            this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.LeftColor = System.Drawing.Color.Black;
            this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.RightColor = System.Drawing.Color.Black;
            this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.TopColor = System.Drawing.Color.Black;
            this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Height = 0.1875F;
            this.label4.HyperLink = "";
            this.label4.Left = 1.125F;
            this.label4.Name = "label4";
            this.label4.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.label4.Text = "Anniversary";
            this.label4.Top = 0.6875F;
            this.label4.Width = 0.6875F;
            // 
            // label3
            // 
            this.label3.Border.BottomColor = System.Drawing.Color.Black;
            this.label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.LeftColor = System.Drawing.Color.Black;
            this.label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.RightColor = System.Drawing.Color.Black;
            this.label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.TopColor = System.Drawing.Color.Black;
            this.label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Height = 0.1875F;
            this.label3.HyperLink = "";
            this.label3.Left = 4.125F;
            this.label3.Name = "label3";
            this.label3.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.label3.Text = "Agent";
            this.label3.Top = 0.6875F;
            this.label3.Width = 0.625F;
            // 
            // label5
            // 
            this.label5.Border.BottomColor = System.Drawing.Color.Black;
            this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.LeftColor = System.Drawing.Color.Black;
            this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.RightColor = System.Drawing.Color.Black;
            this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.TopColor = System.Drawing.Color.Black;
            this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Height = 0.1875F;
            this.label5.HyperLink = "";
            this.label5.Left = 3.25F;
            this.label5.Name = "label5";
            this.label5.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.label5.Text = "Agency";
            this.label5.Top = 0.6875F;
            this.label5.Width = 0.625F;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label131,
            this.Label132,
            this.Label133});
            this.GroupHeader1.DataField = "AgencyDesc";
            this.GroupHeader1.Height = 0.2076389F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // Label131
            // 
            this.Label131.Border.BottomColor = System.Drawing.Color.Black;
            this.Label131.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label131.Border.LeftColor = System.Drawing.Color.Black;
            this.Label131.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label131.Border.RightColor = System.Drawing.Color.Black;
            this.Label131.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label131.Border.TopColor = System.Drawing.Color.Black;
            this.Label131.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label131.Height = 0.1875F;
            this.Label131.HyperLink = "";
            this.Label131.Left = 0.1875F;
            this.Label131.Name = "Label131";
            this.Label131.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label131.Text = "Agency:";
            this.Label131.Top = 0F;
            this.Label131.Width = 0.5625F;
            // 
            // Label132
            // 
            this.Label132.Border.BottomColor = System.Drawing.Color.Black;
            this.Label132.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label132.Border.LeftColor = System.Drawing.Color.Black;
            this.Label132.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label132.Border.RightColor = System.Drawing.Color.Black;
            this.Label132.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label132.Border.TopColor = System.Drawing.Color.Black;
            this.Label132.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label132.DataField = "Agency";
            this.Label132.Height = 0.1875F;
            this.Label132.HyperLink = "";
            this.Label132.Left = 0.8125F;
            this.Label132.Name = "Label132";
            this.Label132.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label132.Text = "";
            this.Label132.Top = 0F;
            this.Label132.Width = 0.4375F;
            // 
            // Label133
            // 
            this.Label133.Border.BottomColor = System.Drawing.Color.Black;
            this.Label133.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label133.Border.LeftColor = System.Drawing.Color.Black;
            this.Label133.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label133.Border.RightColor = System.Drawing.Color.Black;
            this.Label133.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label133.Border.TopColor = System.Drawing.Color.Black;
            this.Label133.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label133.DataField = "AgencyDesc";
            this.Label133.Height = 0.2F;
            this.Label133.HyperLink = "";
            this.Label133.Left = 1.3125F;
            this.Label133.Name = "Label133";
            this.Label133.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label133.Text = "";
            this.Label133.Top = 0F;
            this.Label133.Width = 2.5625F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label134,
            this.Label135,
            this.TextBox25,
            this.TextBox28,
            this.TextBox29,
            this.TextBox35,
            this.TextBox36,
            this.TextBox37,
            this.TextBox38,
            this.TextBox39,
            this.textBox5});
            this.GroupFooter1.Height = 0.2076389F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // Label134
            // 
            this.Label134.Border.BottomColor = System.Drawing.Color.Black;
            this.Label134.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label134.Border.LeftColor = System.Drawing.Color.Black;
            this.Label134.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label134.Border.RightColor = System.Drawing.Color.Black;
            this.Label134.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label134.Border.TopColor = System.Drawing.Color.Black;
            this.Label134.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label134.Height = 0.1875F;
            this.Label134.HyperLink = "";
            this.Label134.Left = 0.375F;
            this.Label134.Name = "Label134";
            this.Label134.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label134.Text = "Total for Agency:";
            this.Label134.Top = 0F;
            this.Label134.Width = 1F;
            // 
            // Label135
            // 
            this.Label135.Border.BottomColor = System.Drawing.Color.Black;
            this.Label135.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label135.Border.LeftColor = System.Drawing.Color.Black;
            this.Label135.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label135.Border.RightColor = System.Drawing.Color.Black;
            this.Label135.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label135.Border.TopColor = System.Drawing.Color.Black;
            this.Label135.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label135.DataField = "Agency";
            this.Label135.Height = 0.2F;
            this.Label135.HyperLink = "";
            this.Label135.Left = 1.447917F;
            this.Label135.Name = "Label135";
            this.Label135.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label135.Text = "";
            this.Label135.Top = 0F;
            this.Label135.Width = 0.4375F;
            // 
            // TextBox25
            // 
            this.TextBox25.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox25.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox25.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox25.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox25.DataField = "TaskControlID";
            this.TextBox25.Height = 0.1875F;
            this.TextBox25.Left = 2F;
            this.TextBox25.Name = "TextBox25";
            this.TextBox25.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox25.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox25.SummaryGroup = "GroupHeader1";
            this.TextBox25.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox25.Text = null;
            this.TextBox25.Top = 0F;
            this.TextBox25.Width = 0.8958333F;
            // 
            // TextBox28
            // 
            this.TextBox28.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox28.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox28.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox28.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox28.DataField = "TotalPremium";
            this.TextBox28.Height = 0.1875F;
            this.TextBox28.Left = 9.4375F;
            this.TextBox28.Name = "TextBox28";
            this.TextBox28.OutputFormat = resources.GetString("TextBox28.OutputFormat");
            this.TextBox28.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox28.SummaryGroup = "GroupHeader1";
            this.TextBox28.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox28.Text = null;
            this.TextBox28.Top = 0F;
            this.TextBox28.Width = 0.75F;
            // 
            // TextBox29
            // 
            this.TextBox29.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox29.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox29.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox29.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox29.DataField = "PaidAmount";
            this.TextBox29.Height = 0.1875F;
            this.TextBox29.Left = 11.125F;
            this.TextBox29.Name = "TextBox29";
            this.TextBox29.OutputFormat = resources.GetString("TextBox29.OutputFormat");
            this.TextBox29.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox29.SummaryGroup = "GroupHeader1";
            this.TextBox29.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox29.Text = null;
            this.TextBox29.Top = 0F;
            this.TextBox29.Width = 0.8125F;
            // 
            // TextBox35
            // 
            this.TextBox35.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox35.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox35.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox35.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox35.DataField = "DueAmount";
            this.TextBox35.Height = 0.1875F;
            this.TextBox35.Left = 12F;
            this.TextBox35.Name = "TextBox35";
            this.TextBox35.OutputFormat = resources.GetString("TextBox35.OutputFormat");
            this.TextBox35.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox35.SummaryGroup = "GroupHeader1";
            this.TextBox35.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox35.Text = null;
            this.TextBox35.Top = 0F;
            this.TextBox35.Width = 0.6875F;
            // 
            // TextBox36
            // 
            this.TextBox36.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox36.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox36.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox36.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox36.DataField = "Days30";
            this.TextBox36.Height = 0.1875F;
            this.TextBox36.Left = 12.75F;
            this.TextBox36.Name = "TextBox36";
            this.TextBox36.OutputFormat = resources.GetString("TextBox36.OutputFormat");
            this.TextBox36.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox36.SummaryGroup = "GroupHeader1";
            this.TextBox36.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox36.Text = null;
            this.TextBox36.Top = 0F;
            this.TextBox36.Width = 0.8125F;
            // 
            // TextBox37
            // 
            this.TextBox37.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox37.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox37.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox37.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox37.DataField = "Days60";
            this.TextBox37.Height = 0.1875F;
            this.TextBox37.Left = 13.625F;
            this.TextBox37.Name = "TextBox37";
            this.TextBox37.OutputFormat = resources.GetString("TextBox37.OutputFormat");
            this.TextBox37.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox37.SummaryGroup = "GroupHeader1";
            this.TextBox37.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox37.Text = null;
            this.TextBox37.Top = 0F;
            this.TextBox37.Width = 0.8125F;
            // 
            // TextBox38
            // 
            this.TextBox38.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox38.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox38.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox38.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox38.DataField = "Days90";
            this.TextBox38.Height = 0.1875F;
            this.TextBox38.Left = 14.5F;
            this.TextBox38.Name = "TextBox38";
            this.TextBox38.OutputFormat = resources.GetString("TextBox38.OutputFormat");
            this.TextBox38.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox38.SummaryGroup = "GroupHeader1";
            this.TextBox38.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox38.Text = null;
            this.TextBox38.Top = 0F;
            this.TextBox38.Width = 0.8125F;
            // 
            // TextBox39
            // 
            this.TextBox39.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox39.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox39.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox39.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox39.DataField = "Over90";
            this.TextBox39.Height = 0.1875F;
            this.TextBox39.Left = 15.375F;
            this.TextBox39.Name = "TextBox39";
            this.TextBox39.OutputFormat = resources.GetString("TextBox39.OutputFormat");
            this.TextBox39.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox39.SummaryGroup = "GroupHeader1";
            this.TextBox39.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox39.Text = null;
            this.TextBox39.Top = 0F;
            this.TextBox39.Width = 0.8125F;
            // 
            // label6
            // 
            this.label6.Border.BottomColor = System.Drawing.Color.Black;
            this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.LeftColor = System.Drawing.Color.Black;
            this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.RightColor = System.Drawing.Color.Black;
            this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.TopColor = System.Drawing.Color.Black;
            this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Height = 0.1875F;
            this.label6.HyperLink = "";
            this.label6.Left = 11.3125F;
            this.label6.Name = "label6";
            this.label6.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.label6.Text = "Paid Amount";
            this.label6.Top = 0.6875F;
            this.label6.Width = 0.75F;
            // 
            // label7
            // 
            this.label7.Border.BottomColor = System.Drawing.Color.Black;
            this.label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.LeftColor = System.Drawing.Color.Black;
            this.label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.RightColor = System.Drawing.Color.Black;
            this.label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.TopColor = System.Drawing.Color.Black;
            this.label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Height = 0.2F;
            this.label7.HyperLink = "";
            this.label7.Left = 12.1875F;
            this.label7.Name = "label7";
            this.label7.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.label7.Text = "Due Amt.";
            this.label7.Top = 0.6875F;
            this.label7.Width = 0.5625F;
            // 
            // textBox5
            // 
            this.textBox5.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.RightColor = System.Drawing.Color.Black;
            this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.TopColor = System.Drawing.Color.Black;
            this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.DataField = "Charge";
            this.textBox5.Height = 0.1875F;
            this.textBox5.Left = 10.25F;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.textBox5.SummaryGroup = "GroupHeader1";
            this.textBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox5.Text = null;
            this.textBox5.Top = 0F;
            this.textBox5.Width = 0.8125F;
            // 
            // textBox6
            // 
            this.textBox6.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.RightColor = System.Drawing.Color.Black;
            this.textBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.TopColor = System.Drawing.Color.Black;
            this.textBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.DataField = "Charge";
            this.textBox6.Height = 0.1875F;
            this.textBox6.Left = 10.25F;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.textBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox6.Text = null;
            this.textBox6.Top = 0F;
            this.textBox6.Width = 0.8125F;
            // 
            // textBox7
            // 
            this.textBox7.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.RightColor = System.Drawing.Color.Black;
            this.textBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.TopColor = System.Drawing.Color.Black;
            this.textBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.DataField = "Charge";
            this.textBox7.Height = 0.125F;
            this.textBox7.Left = 10.25F;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "text-align: right; font-size: 7pt; ";
            this.textBox7.Text = null;
            this.textBox7.Top = 0F;
            this.textBox7.Width = 0.8125F;
            // 
            // AutoGuardCertificateOustanding
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.1F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0.3F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 17.01042F;
            this.Sections.Add(this.ReportHeader);
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.GroupHeader1);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GroupFooter1);
            this.Sections.Add(this.PageFooter);
            this.Sections.Add(this.ReportFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.AutoGuardCertificateOustanding_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.TxtRegCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaidAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label113)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label122)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label125)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label126)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label137)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label138)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label139)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label140)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label144)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label145)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label146)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
