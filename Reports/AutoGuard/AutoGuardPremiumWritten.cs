using System;
using System.Data;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.AutoGuard
{
	public class AutoGuardPremiumWritten : DataDynamics.ActiveReports.ActiveReport3
	{
		string _FromDate;
		string _ToDate;
		string _ReportType;
		bool   _Summary = false;
        private TextBox textBox1;
        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label5;
        private Label label6;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private Label label7;
        private Label label9;
        private TextBox textBox9;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox8;
        private Label label8;
        private TextBox textBox10;
        private Label label10;
        private TextBox txtExpDate;
        private Label label11;
        private TextBox textBox11;
        private Label label12;
        private TextBox textBox12;
        private Label lblTerm;
        private Label label13;
        private TextBox textBox13;
        private TextBox textBox15;
        private TextBox textBox14;
        string _mHeadCompany = "";

		public AutoGuardPremiumWritten(string FromDate,string ToDate, string ReportType, bool Summary, string mHeadCompany)
		{
			_FromDate = FromDate;
			_ToDate = ToDate;
			_ReportType = ReportType;
			_Summary  =  Summary;
            _mHeadCompany = mHeadCompany;

			InitializeComponent();
		}

		private void AutoGuardPremiumWritten_ReportStart(object sender, System.EventArgs eArgs)
		{
			if (_Summary)
			{
				this.Detail.Visible = false;
			}

            this.LblCompanyHeader.Text = _mHeadCompany;
			this.lblDate.Text = "Date:"+DateTime.Now.ToShortDateString();
			this.lblTime.Text = "Time:"+DateTime.Now.ToShortTimeString();

			if (!_FromDate.Trim().Equals("")||(!_FromDate.Trim().Equals("")))
			{
				this.lblCriterias.Text = _ReportType + " From: " + _FromDate +" To: " + _ToDate;
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
		private Label Label107 = null;
		private Label Label108 = null;
        private Label Label109 = null;
        private Label Label122 = null;
		private Label Label125 = null;
		private Label Label128 = null;
		private Label Label113 = null;
		private Label Label129 = null;
		private Label Label170 = null;
		private Label LblCompanyHeader = null;
        private Label Label77 = null;
		private GroupHeader GroupHeader1 = null;
		private Label Label131 = null;
		private Label Label132 = null;
		private Label Label130 = null;
		private Detail Detail = null;
		private TextBox txtTaskControlID = null;
		private TextBox TxtRegCode = null;
		private TextBox txtCustomerNo = null;
		private TextBox txtEntryDate = null;
        private TextBox txtEffectiveDate = null;
		private TextBox txtTotalPremium = null;
		private TextBox TextBox20 = null;
		private TextBox TextBox38 = null;
		private TextBox TextBox39 = null;
		private TextBox TextBox22 = null;
		private TextBox TextBox75 = null;
		private TextBox TextBox61 = null;
		private GroupFooter GroupFooter1 = null;
		private Label Label133 = null;
		private Label Label134 = null;
		private TextBox TextBox24 = null;
		private TextBox TextBox25 = null;
		private Label Label164 = null;
		private Label Label165 = null;
		private Label Label166 = null;
		private TextBox TextBox70 = null;
		private TextBox TextBox74 = null;
        private TextBox TextBox76 = null;
		private PageFooter PageFooter = null;
		private ReportFooter ReportFooter = null;
		private Label Label127 = null;
		private TextBox TextBox18 = null;
		private TextBox TextBox21 = null;
		private Line Line9 = null;
		private Label Label167 = null;
		private Label Label168 = null;
		private Label Label169 = null;
		private TextBox TextBox37 = null;
		private TextBox TextBox68 = null;
		private TextBox TextBox77 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoGuardPremiumWritten));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.txtTaskControlID = new DataDynamics.ActiveReports.TextBox();
            this.TxtRegCode = new DataDynamics.ActiveReports.TextBox();
            this.txtCustomerNo = new DataDynamics.ActiveReports.TextBox();
            this.txtEntryDate = new DataDynamics.ActiveReports.TextBox();
            this.txtEffectiveDate = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalPremium = new DataDynamics.ActiveReports.TextBox();
            this.TextBox20 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox38 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox39 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox22 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox75 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox61 = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.txtExpDate = new DataDynamics.ActiveReports.TextBox();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.Label127 = new DataDynamics.ActiveReports.Label();
            this.TextBox18 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox21 = new DataDynamics.ActiveReports.TextBox();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.Label167 = new DataDynamics.ActiveReports.Label();
            this.Label168 = new DataDynamics.ActiveReports.Label();
            this.Label169 = new DataDynamics.ActiveReports.Label();
            this.TextBox37 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox68 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox77 = new DataDynamics.ActiveReports.TextBox();
            this.textBox15 = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.lblCriterias = new DataDynamics.ActiveReports.Label();
            this.Label80 = new DataDynamics.ActiveReports.Label();
            this.TextBox17 = new DataDynamics.ActiveReports.TextBox();
            this.lblDate = new DataDynamics.ActiveReports.Label();
            this.lblTime = new DataDynamics.ActiveReports.Label();
            this.Shape3 = new DataDynamics.ActiveReports.Shape();
            this.Label107 = new DataDynamics.ActiveReports.Label();
            this.Label108 = new DataDynamics.ActiveReports.Label();
            this.Label109 = new DataDynamics.ActiveReports.Label();
            this.Label122 = new DataDynamics.ActiveReports.Label();
            this.Label125 = new DataDynamics.ActiveReports.Label();
            this.Label128 = new DataDynamics.ActiveReports.Label();
            this.Label113 = new DataDynamics.ActiveReports.Label();
            this.Label129 = new DataDynamics.ActiveReports.Label();
            this.Label170 = new DataDynamics.ActiveReports.Label();
            this.LblCompanyHeader = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label3 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.lblTerm = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.GroupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.Label131 = new DataDynamics.ActiveReports.Label();
            this.Label132 = new DataDynamics.ActiveReports.Label();
            this.Label130 = new DataDynamics.ActiveReports.Label();
            this.GroupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.Label133 = new DataDynamics.ActiveReports.Label();
            this.Label134 = new DataDynamics.ActiveReports.Label();
            this.TextBox24 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox25 = new DataDynamics.ActiveReports.TextBox();
            this.Label164 = new DataDynamics.ActiveReports.Label();
            this.Label165 = new DataDynamics.ActiveReports.Label();
            this.Label166 = new DataDynamics.ActiveReports.Label();
            this.TextBox70 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox74 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox76 = new DataDynamics.ActiveReports.TextBox();
            this.textBox14 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaskControlID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRegCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label127)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label167)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label168)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label169)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox68)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label122)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label125)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label128)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label113)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label129)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label170)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblCompanyHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTerm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label164)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label165)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label166)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox74)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox76)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtTaskControlID,
            this.TxtRegCode,
            this.txtCustomerNo,
            this.txtEntryDate,
            this.txtEffectiveDate,
            this.txtTotalPremium,
            this.TextBox20,
            this.TextBox38,
            this.TextBox39,
            this.TextBox22,
            this.TextBox75,
            this.TextBox61,
            this.textBox1,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox9,
            this.textBox2,
            this.textBox8,
            this.textBox10,
            this.txtExpDate,
            this.textBox11,
            this.textBox12,
            this.textBox13});
            this.Detail.Height = 0.3125F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            // 
            // txtTaskControlID
            // 
            this.txtTaskControlID.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTaskControlID.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTaskControlID.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTaskControlID.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTaskControlID.Border.RightColor = System.Drawing.Color.Black;
            this.txtTaskControlID.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTaskControlID.Border.TopColor = System.Drawing.Color.Black;
            this.txtTaskControlID.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTaskControlID.DataField = "TaskControlID";
            this.txtTaskControlID.Height = 0.125F;
            this.txtTaskControlID.Left = 0.25F;
            this.txtTaskControlID.Name = "txtTaskControlID";
            this.txtTaskControlID.Style = "text-align: left; font-size: 7pt; ";
            this.txtTaskControlID.Text = null;
            this.txtTaskControlID.Top = 0F;
            this.txtTaskControlID.Width = 0.6875F;
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
            this.TxtRegCode.Left = 1.8125F;
            this.TxtRegCode.Name = "TxtRegCode";
            this.TxtRegCode.Style = "text-align: left; font-size: 7pt; ";
            this.TxtRegCode.Text = null;
            this.TxtRegCode.Top = 0F;
            this.TxtRegCode.Width = 0.25F;
            // 
            // txtCustomerNo
            // 
            this.txtCustomerNo.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCustomerNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomerNo.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCustomerNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomerNo.Border.RightColor = System.Drawing.Color.Black;
            this.txtCustomerNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomerNo.Border.TopColor = System.Drawing.Color.Black;
            this.txtCustomerNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomerNo.DataField = "CustomerName";
            this.txtCustomerNo.Height = 0.25F;
            this.txtCustomerNo.Left = 6.125F;
            this.txtCustomerNo.Name = "txtCustomerNo";
            this.txtCustomerNo.Style = "text-align: left; font-size: 7pt; ";
            this.txtCustomerNo.Text = null;
            this.txtCustomerNo.Top = 0F;
            this.txtCustomerNo.Width = 2.875F;
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
            this.txtEntryDate.Left = 10.75F;
            this.txtEntryDate.Name = "txtEntryDate";
            this.txtEntryDate.OutputFormat = resources.GetString("txtEntryDate.OutputFormat");
            this.txtEntryDate.Style = "text-align: left; font-size: 7pt; ";
            this.txtEntryDate.Text = null;
            this.txtEntryDate.Top = 0F;
            this.txtEntryDate.Width = 0.625F;
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
            this.txtEffectiveDate.Left = 12.25F;
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
            this.txtTotalPremium.Left = 15.875F;
            this.txtTotalPremium.Name = "txtTotalPremium";
            this.txtTotalPremium.OutputFormat = resources.GetString("txtTotalPremium.OutputFormat");
            this.txtTotalPremium.Style = "text-align: right; font-size: 7pt; ";
            this.txtTotalPremium.Text = null;
            this.txtTotalPremium.Top = 0F;
            this.txtTotalPremium.Width = 0.6979167F;
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
            this.TextBox20.DataField = "CancellationAmount";
            this.TextBox20.Height = 0.125F;
            this.TextBox20.Left = 17.5F;
            this.TextBox20.Name = "TextBox20";
            this.TextBox20.OutputFormat = resources.GetString("TextBox20.OutputFormat");
            this.TextBox20.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox20.Text = null;
            this.TextBox20.Top = 0F;
            this.TextBox20.Width = 0.6979167F;
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
            this.TextBox38.DataField = "PrmCount";
            this.TextBox38.Height = 0.125F;
            this.TextBox38.Left = 13.25F;
            this.TextBox38.Name = "TextBox38";
            this.TextBox38.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox38.Text = "PrmCount";
            this.TextBox38.Top = 0.1875F;
            this.TextBox38.Visible = false;
            this.TextBox38.Width = 0.5625F;
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
            this.TextBox39.DataField = "CancCount";
            this.TextBox39.Height = 0.125F;
            this.TextBox39.Left = 12.6875F;
            this.TextBox39.Name = "TextBox39";
            this.TextBox39.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox39.Text = "CancCount";
            this.TextBox39.Top = 0.1875F;
            this.TextBox39.Visible = false;
            this.TextBox39.Width = 0.5625F;
            // 
            // TextBox22
            // 
            this.TextBox22.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox22.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox22.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox22.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox22.DataField = "CancellationDate";
            this.TextBox22.Height = 0.125F;
            this.TextBox22.Left = 15.125F;
            this.TextBox22.Name = "TextBox22";
            this.TextBox22.OutputFormat = resources.GetString("TextBox22.OutputFormat");
            this.TextBox22.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox22.Text = null;
            this.TextBox22.Top = 0F;
            this.TextBox22.Width = 0.5625F;
            // 
            // TextBox75
            // 
            this.TextBox75.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox75.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox75.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox75.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox75.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox75.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox75.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox75.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox75.DataField = "CancellationEntryDate";
            this.TextBox75.Height = 0.125F;
            this.TextBox75.Left = 14.3125F;
            this.TextBox75.Name = "TextBox75";
            this.TextBox75.OutputFormat = resources.GetString("TextBox75.OutputFormat");
            this.TextBox75.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox75.Text = null;
            this.TextBox75.Top = 0F;
            this.TextBox75.Width = 0.5625F;
            // 
            // TextBox61
            // 
            this.TextBox61.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox61.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox61.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox61.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox61.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox61.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox61.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox61.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox61.DataField = "PremNet";
            this.TextBox61.Height = 0.125F;
            this.TextBox61.Left = 13.8125F;
            this.TextBox61.Name = "TextBox61";
            this.TextBox61.OutputFormat = resources.GetString("TextBox61.OutputFormat");
            this.TextBox61.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox61.Text = "PremNet";
            this.TextBox61.Top = 0.1875F;
            this.TextBox61.Visible = false;
            this.TextBox61.Width = 0.6979167F;
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
            this.textBox1.Left = 11.4375F;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "text-align: left; font-size: 7pt; ";
            this.textBox1.Text = null;
            this.textBox1.Top = 0F;
            this.textBox1.Width = 0.625F;
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
            this.textBox3.DataField = "PRMedicalLimitDesc";
            this.textBox3.Height = 0.125F;
            this.textBox3.Left = 9.6875F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "text-align: left; font-size: 7pt; ";
            this.textBox3.Text = null;
            this.textBox3.Top = 0F;
            this.textBox3.Width = 1F;
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
            this.textBox4.DataField = "Anniversary";
            this.textBox4.Height = 0.125F;
            this.textBox4.Left = 2.9375F;
            this.textBox4.Name = "textBox4";
            this.textBox4.Style = "text-align: left; font-size: 7pt; ";
            this.textBox4.Text = null;
            this.textBox4.Top = 0F;
            this.textBox4.Width = 0.25F;
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
            this.textBox5.DataField = "IsoCode";
            this.textBox5.Height = 0.125F;
            this.textBox5.Left = 9.125F;
            this.textBox5.Name = "textBox5";
            this.textBox5.Style = "text-align: left; font-size: 7pt; ";
            this.textBox5.Text = null;
            this.textBox5.Top = 0F;
            this.textBox5.Width = 0.375F;
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
            this.textBox6.DataField = "PremNet";
            this.textBox6.Height = 0.125F;
            this.textBox6.Left = 18.3125F;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "text-align: right; font-weight: normal; font-size: 7pt; ";
            this.textBox6.Text = null;
            this.textBox6.Top = 0F;
            this.textBox6.Width = 0.6875F;
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
            this.textBox7.DataField = "PolicyNo";
            this.textBox7.Height = 0.125F;
            this.textBox7.Left = 2.25F;
            this.textBox7.Name = "textBox7";
            this.textBox7.Style = "text-align: left; font-size: 7pt; ";
            this.textBox7.Text = null;
            this.textBox7.Top = 0F;
            this.textBox7.Width = 0.5625F;
            // 
            // textBox9
            // 
            this.textBox9.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.RightColor = System.Drawing.Color.Black;
            this.textBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.TopColor = System.Drawing.Color.Black;
            this.textBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.DataField = "AgentDesc";
            this.textBox9.Height = 0.125F;
            this.textBox9.Left = 4.6875F;
            this.textBox9.Name = "textBox9";
            this.textBox9.Style = "text-align: left; font-size: 7pt; ";
            this.textBox9.Text = null;
            this.textBox9.Top = 0F;
            this.textBox9.Width = 1.3125F;
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
            this.textBox2.DataField = "AgencyDesc";
            this.textBox2.Height = 0.125F;
            this.textBox2.Left = 3.3125F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "text-align: left; font-size: 7pt; ";
            this.textBox2.Text = null;
            this.textBox2.Top = 0F;
            this.textBox2.Width = 1.3125F;
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
            this.textBox8.DataField = "CustomerNo";
            this.textBox8.Height = 0.125F;
            this.textBox8.Left = 1F;
            this.textBox8.Name = "textBox8";
            this.textBox8.Style = "text-align: left; font-size: 7pt; ";
            this.textBox8.Text = null;
            this.textBox8.Top = 0F;
            this.textBox8.Width = 0.6875F;
            // 
            // textBox10
            // 
            this.textBox10.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.Border.RightColor = System.Drawing.Color.Black;
            this.textBox10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.Border.TopColor = System.Drawing.Color.Black;
            this.textBox10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.DataField = "status";
            this.textBox10.Height = 0.125F;
            this.textBox10.Left = 19.1875F;
            this.textBox10.Name = "textBox10";
            this.textBox10.Style = "text-align: left; font-size: 7pt; ";
            this.textBox10.Text = null;
            this.textBox10.Top = 0F;
            this.textBox10.Width = 0.3125F;
            // 
            // txtExpDate
            // 
            this.txtExpDate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtExpDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtExpDate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtExpDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtExpDate.Border.RightColor = System.Drawing.Color.Black;
            this.txtExpDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtExpDate.Border.TopColor = System.Drawing.Color.Black;
            this.txtExpDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtExpDate.DataField = "ExpirationDate";
            this.txtExpDate.Height = 0.125F;
            this.txtExpDate.Left = 13F;
            this.txtExpDate.Name = "txtExpDate";
            this.txtExpDate.OutputFormat = resources.GetString("txtExpDate.OutputFormat");
            this.txtExpDate.Style = "text-align: left; font-size: 7pt; ";
            this.txtExpDate.Text = null;
            this.txtExpDate.Top = 0F;
            this.txtExpDate.Width = 0.625F;
            // 
            // textBox11
            // 
            this.textBox11.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.RightColor = System.Drawing.Color.Black;
            this.textBox11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.TopColor = System.Drawing.Color.Black;
            this.textBox11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.DataField = "CancelMethod";
            this.textBox11.Height = 0.125F;
            this.textBox11.Left = 19.6875F;
            this.textBox11.Name = "textBox11";
            this.textBox11.Style = "text-align: center; font-size: 7pt; ";
            this.textBox11.Text = null;
            this.textBox11.Top = 0F;
            this.textBox11.Width = 0.6875F;
            // 
            // textBox12
            // 
            this.textBox12.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.RightColor = System.Drawing.Color.Black;
            this.textBox12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.TopColor = System.Drawing.Color.Black;
            this.textBox12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.DataField = "Term";
            this.textBox12.Height = 0.125F;
            this.textBox12.Left = 13.75F;
            this.textBox12.Name = "textBox12";
            this.textBox12.Style = "text-align: left; font-size: 7pt; ";
            this.textBox12.Text = null;
            this.textBox12.Top = 0F;
            this.textBox12.Width = 0.3125F;
            // 
            // textBox13
            // 
            this.textBox13.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.RightColor = System.Drawing.Color.Black;
            this.textBox13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.TopColor = System.Drawing.Color.Black;
            this.textBox13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.DataField = "Charge";
            this.textBox13.Height = 0.125F;
            this.textBox13.Left = 16.6875F;
            this.textBox13.Name = "textBox13";
            this.textBox13.OutputFormat = resources.GetString("textBox13.OutputFormat");
            this.textBox13.Style = "text-align: right; font-size: 7pt; ";
            this.textBox13.Text = null;
            this.textBox13.Top = 0F;
            this.textBox13.Width = 0.6979167F;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Height = 0F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label127,
            this.TextBox18,
            this.TextBox21,
            this.Line9,
            this.Label167,
            this.Label168,
            this.Label169,
            this.TextBox37,
            this.TextBox68,
            this.TextBox77,
            this.textBox15});
            this.ReportFooter.Height = 0.6041667F;
            this.ReportFooter.KeepTogether = true;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // Label127
            // 
            this.Label127.Border.BottomColor = System.Drawing.Color.Black;
            this.Label127.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label127.Border.LeftColor = System.Drawing.Color.Black;
            this.Label127.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label127.Border.RightColor = System.Drawing.Color.Black;
            this.Label127.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label127.Border.TopColor = System.Drawing.Color.Black;
            this.Label127.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label127.Height = 0.1875F;
            this.Label127.HyperLink = "";
            this.Label127.Left = 0.34375F;
            this.Label127.Name = "Label127";
            this.Label127.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label127.Text = "Grand Total:";
            this.Label127.Top = 0F;
            this.Label127.Width = 1F;
            // 
            // TextBox18
            // 
            this.TextBox18.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox18.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox18.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox18.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox18.DataField = "TotalPremium";
            this.TextBox18.Height = 0.1875F;
            this.TextBox18.Left = 15.6875F;
            this.TextBox18.Name = "TextBox18";
            this.TextBox18.OutputFormat = resources.GetString("TextBox18.OutputFormat");
            this.TextBox18.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: Microsoft S" +
                "ans Serif; ";
            this.TextBox18.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox18.Text = null;
            this.TextBox18.Top = 0F;
            this.TextBox18.Width = 0.875F;
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
            this.TextBox21.DataField = "CancellationAmount";
            this.TextBox21.Height = 0.1875F;
            this.TextBox21.Left = 17.5F;
            this.TextBox21.Name = "TextBox21";
            this.TextBox21.OutputFormat = resources.GetString("TextBox21.OutputFormat");
            this.TextBox21.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: Microsoft S" +
                "ans Serif; ";
            this.TextBox21.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox21.Text = null;
            this.TextBox21.Top = 0F;
            this.TextBox21.Width = 0.75F;
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
            this.Line9.Left = 0.3958333F;
            this.Line9.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 0F;
            this.Line9.Width = 21.41667F;
            this.Line9.X1 = 0.3958333F;
            this.Line9.X2 = 21.8125F;
            this.Line9.Y1 = 0F;
            this.Line9.Y2 = 0F;
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
            this.Label167.Height = 0.2F;
            this.Label167.HyperLink = "";
            this.Label167.Left = 6.09375F;
            this.Label167.Name = "Label167";
            this.Label167.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label167.Text = "New Contracts";
            this.Label167.Top = 0F;
            this.Label167.Width = 0.9375F;
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
            this.Label168.Height = 0.2F;
            this.Label168.HyperLink = "";
            this.Label168.Left = 6.09375F;
            this.Label168.Name = "Label168";
            this.Label168.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label168.Text = "Cancellations";
            this.Label168.Top = 0.125F;
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
            this.Label169.Height = 0.2F;
            this.Label169.HyperLink = "";
            this.Label169.Left = 6.09375F;
            this.Label169.Name = "Label169";
            this.Label169.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label169.Text = "Net >>>>>>>";
            this.Label169.Top = 0.25F;
            this.Label169.Width = 0.9375F;
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
            this.TextBox37.DataField = "CancCount";
            this.TextBox37.Height = 0.1875F;
            this.TextBox37.Left = 7.03125F;
            this.TextBox37.Name = "TextBox37";
            this.TextBox37.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox37.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox37.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox37.Text = null;
            this.TextBox37.Top = 0.125F;
            this.TextBox37.Width = 0.6979167F;
            // 
            // TextBox68
            // 
            this.TextBox68.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox68.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox68.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox68.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox68.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox68.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox68.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox68.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox68.DataField = "PrmCount";
            this.TextBox68.Height = 0.1875F;
            this.TextBox68.Left = 7.03125F;
            this.TextBox68.Name = "TextBox68";
            this.TextBox68.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox68.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox68.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox68.Text = null;
            this.TextBox68.Top = 0F;
            this.TextBox68.Width = 0.6875F;
            // 
            // TextBox77
            // 
            this.TextBox77.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox77.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox77.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox77.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox77.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox77.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox77.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox77.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox77.DataField = "PremNet";
            this.TextBox77.Height = 0.1875F;
            this.TextBox77.Left = 18.375F;
            this.TextBox77.Name = "TextBox77";
            this.TextBox77.OutputFormat = resources.GetString("TextBox77.OutputFormat");
            this.TextBox77.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox77.SummaryGroup = "GroupHeader1";
            this.TextBox77.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox77.Text = null;
            this.TextBox77.Top = 0F;
            this.TextBox77.Width = 0.625F;
            // 
            // textBox15
            // 
            this.textBox15.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.RightColor = System.Drawing.Color.Black;
            this.textBox15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.TopColor = System.Drawing.Color.Black;
            this.textBox15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.DataField = "Charge";
            this.textBox15.Height = 0.1875F;
            this.textBox15.Left = 16.6875F;
            this.textBox15.Name = "textBox15";
            this.textBox15.OutputFormat = resources.GetString("textBox15.OutputFormat");
            this.textBox15.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: Microsoft S" +
                "ans Serif; ";
            this.textBox15.SummaryGroup = "GroupHeader1";
            this.textBox15.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox15.Text = null;
            this.textBox15.Top = 0F;
            this.textBox15.Width = 0.75F;
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
            this.Label107,
            this.Label108,
            this.Label109,
            this.Label122,
            this.Label125,
            this.Label128,
            this.Label113,
            this.Label129,
            this.Label170,
            this.LblCompanyHeader,
            this.Label77,
            this.label1,
            this.label3,
            this.label4,
            this.label5,
            this.label6,
            this.label7,
            this.label9,
            this.label2,
            this.label8,
            this.label10,
            this.label11,
            this.label12,
            this.lblTerm,
            this.label13});
            this.PageHeader.Height = 1.4375F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format_1);
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
            this.lblCriterias.Left = 4.729162F;
            this.lblCriterias.MultiLine = false;
            this.lblCriterias.Name = "lblCriterias";
            this.lblCriterias.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.lblCriterias.Text = "Premium Written & Cancelltions - Effective Date Criteria";
            this.lblCriterias.Top = 0.5625F;
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
            this.Label80.Left = 12.8125F;
            this.Label80.Name = "Label80";
            this.Label80.Style = "text-align: right; font-size: 8pt; ";
            this.Label80.Text = "Page";
            this.Label80.Top = 0.1875F;
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
            this.TextBox17.Left = 13.3125F;
            this.TextBox17.MultiLine = false;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat");
            this.TextBox17.Style = "text-align: right; font-size: 8pt; vertical-align: top; ";
            this.TextBox17.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox17.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.TextBox17.Text = null;
            this.TextBox17.Top = 0.1875F;
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
            this.lblDate.Top = 0.1458333F;
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
            this.lblTime.Top = 0.3333333F;
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
            this.Shape3.Top = 0.875F;
            this.Shape3.Width = 21.6875F;
            // 
            // Label107
            // 
            this.Label107.Border.BottomColor = System.Drawing.Color.Black;
            this.Label107.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label107.Border.LeftColor = System.Drawing.Color.Black;
            this.Label107.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label107.Border.RightColor = System.Drawing.Color.Black;
            this.Label107.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label107.Border.TopColor = System.Drawing.Color.Black;
            this.Label107.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label107.Height = 0.1875F;
            this.Label107.HyperLink = "";
            this.Label107.Left = 0.21875F;
            this.Label107.Name = "Label107";
            this.Label107.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label107.Text = "Control ID";
            this.Label107.Top = 0.875F;
            this.Label107.Width = 0.6875F;
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
            this.Label108.Left = 1.739583F;
            this.Label108.Name = "Label108";
            this.Label108.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label108.Text = "Policy Type";
            this.Label108.Top = 0.875F;
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
            this.Label109.Left = 10.8125F;
            this.Label109.Name = "Label109";
            this.Label109.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label109.Text = "Entry Date";
            this.Label109.Top = 0.875F;
            this.Label109.Width = 0.6875F;
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
            this.Label122.Left = 15.875F;
            this.Label122.Name = "Label122";
            this.Label122.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label122.Text = "Premium";
            this.Label122.Top = 0.875F;
            this.Label122.Width = 0.6875F;
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
            this.Label125.Left = 12.25F;
            this.Label125.Name = "Label125";
            this.Label125.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label125.Text = "Effec. Date";
            this.Label125.Top = 0.875F;
            this.Label125.Width = 0.625F;
            // 
            // Label128
            // 
            this.Label128.Border.BottomColor = System.Drawing.Color.Black;
            this.Label128.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label128.Border.LeftColor = System.Drawing.Color.Black;
            this.Label128.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label128.Border.RightColor = System.Drawing.Color.Black;
            this.Label128.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label128.Border.TopColor = System.Drawing.Color.Black;
            this.Label128.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label128.Height = 0.1875F;
            this.Label128.HyperLink = "";
            this.Label128.Left = 17.625F;
            this.Label128.MultiLine = false;
            this.Label128.Name = "Label128";
            this.Label128.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label128.Text = "Canc. Amt";
            this.Label128.Top = 0.875F;
            this.Label128.Width = 0.6875F;
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
            this.Label113.Left = 6.1875F;
            this.Label113.Name = "Label113";
            this.Label113.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label113.Text = "Customer Name";
            this.Label113.Top = 0.875F;
            this.Label113.Width = 0.9375F;
            // 
            // Label129
            // 
            this.Label129.Border.BottomColor = System.Drawing.Color.Black;
            this.Label129.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label129.Border.LeftColor = System.Drawing.Color.Black;
            this.Label129.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label129.Border.RightColor = System.Drawing.Color.Black;
            this.Label129.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label129.Border.TopColor = System.Drawing.Color.Black;
            this.Label129.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label129.Height = 0.1875F;
            this.Label129.HyperLink = "";
            this.Label129.Left = 15.125F;
            this.Label129.Name = "Label129";
            this.Label129.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; vertica" +
                "l-align: top; ";
            this.Label129.Text = "Canc.Date";
            this.Label129.Top = 0.875F;
            this.Label129.Width = 0.6875F;
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
            this.Label170.Height = 0.25F;
            this.Label170.HyperLink = "";
            this.Label170.Left = 14.375F;
            this.Label170.Name = "Label170";
            this.Label170.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: inherit; vertic" +
                "al-align: top; ";
            this.Label170.Text = "Canc. Entry Date";
            this.Label170.Top = 0.875F;
            this.Label170.Width = 0.6875F;
            // 
            // LblCompanyHeader
            // 
            this.LblCompanyHeader.Border.BottomColor = System.Drawing.Color.Black;
            this.LblCompanyHeader.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblCompanyHeader.Border.LeftColor = System.Drawing.Color.Black;
            this.LblCompanyHeader.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblCompanyHeader.Border.RightColor = System.Drawing.Color.Black;
            this.LblCompanyHeader.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblCompanyHeader.Border.TopColor = System.Drawing.Color.Black;
            this.LblCompanyHeader.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblCompanyHeader.Height = 0.1875F;
            this.LblCompanyHeader.HyperLink = "";
            this.LblCompanyHeader.Left = 4.729162F;
            this.LblCompanyHeader.MultiLine = false;
            this.LblCompanyHeader.Name = "LblCompanyHeader";
            this.LblCompanyHeader.Style = "text-align: center; font-weight: bold; font-size: 11.25pt; font-family: Times New" +
                " Roman; ";
            this.LblCompanyHeader.Text = "PUERTO RICO MEDICAL DEFENSE INSURANCE COMPANY";
            this.LblCompanyHeader.Top = 0.1354167F;
            this.LblCompanyHeader.Width = 5.125F;
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
            this.Label77.Left = 4.729162F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-align: center; font-weight: bold; font-size: 6pt; font-family: Times New Rom" +
                "an; ";
            this.Label77.Text = "";
            this.Label77.Top = 0.3125F;
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
            this.label1.Left = 11.5F;
            this.label1.Name = "label1";
            this.label1.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.label1.Text = "Retro. Date";
            this.label1.Top = 0.875F;
            this.label1.Width = 0.6875F;
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
            this.label3.Left = 18.5F;
            this.label3.MultiLine = false;
            this.label3.Name = "label3";
            this.label3.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.label3.Text = "Net";
            this.label3.Top = 0.875F;
            this.label3.Width = 0.375F;
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
            this.label4.Left = 9.75F;
            this.label4.Name = "label4";
            this.label4.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.label4.Text = "Limits";
            this.label4.Top = 0.875F;
            this.label4.Width = 0.4375F;
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
            this.label5.Left = 2.875F;
            this.label5.Name = "label5";
            this.label5.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.label5.Text = "Anniv.";
            this.label5.Top = 0.875F;
            this.label5.Width = 0.4375F;
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
            this.label6.Left = 9.125F;
            this.label6.Name = "label6";
            this.label6.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.label6.Text = "Iso Code";
            this.label6.Top = 0.875F;
            this.label6.Width = 0.5625F;
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
            this.label7.Height = 0.25F;
            this.label7.HyperLink = "";
            this.label7.Left = 2.25F;
            this.label7.Name = "label7";
            this.label7.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.label7.Text = "Policy No";
            this.label7.Top = 0.875F;
            this.label7.Width = 0.5F;
            // 
            // label9
            // 
            this.label9.Border.BottomColor = System.Drawing.Color.Black;
            this.label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.LeftColor = System.Drawing.Color.Black;
            this.label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.RightColor = System.Drawing.Color.Black;
            this.label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.TopColor = System.Drawing.Color.Black;
            this.label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Height = 0.1875F;
            this.label9.HyperLink = "";
            this.label9.Left = 4.6875F;
            this.label9.Name = "label9";
            this.label9.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.label9.Text = "Agent";
            this.label9.Top = 0.875F;
            this.label9.Width = 0.375F;
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
            this.label2.Height = 0.1875F;
            this.label2.HyperLink = "";
            this.label2.Left = 3.375F;
            this.label2.Name = "label2";
            this.label2.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.label2.Text = "Agency";
            this.label2.Top = 0.875F;
            this.label2.Width = 0.4375F;
            // 
            // label8
            // 
            this.label8.Border.BottomColor = System.Drawing.Color.Black;
            this.label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.LeftColor = System.Drawing.Color.Black;
            this.label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.RightColor = System.Drawing.Color.Black;
            this.label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.TopColor = System.Drawing.Color.Black;
            this.label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Height = 0.1875F;
            this.label8.HyperLink = "";
            this.label8.Left = 1.041667F;
            this.label8.Name = "label8";
            this.label8.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.label8.Text = "Cust. #";
            this.label8.Top = 0.875F;
            this.label8.Width = 0.5625F;
            // 
            // label10
            // 
            this.label10.Border.BottomColor = System.Drawing.Color.Black;
            this.label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.LeftColor = System.Drawing.Color.Black;
            this.label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.RightColor = System.Drawing.Color.Black;
            this.label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.TopColor = System.Drawing.Color.Black;
            this.label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Height = 0.1875F;
            this.label10.HyperLink = "";
            this.label10.Left = 19.125F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.label10.Text = "Status";
            this.label10.Top = 0.875F;
            this.label10.Width = 0.375F;
            // 
            // label11
            // 
            this.label11.Border.BottomColor = System.Drawing.Color.Black;
            this.label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.LeftColor = System.Drawing.Color.Black;
            this.label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.RightColor = System.Drawing.Color.Black;
            this.label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.TopColor = System.Drawing.Color.Black;
            this.label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Height = 0.1875F;
            this.label11.HyperLink = "";
            this.label11.Left = 13F;
            this.label11.Name = "label11";
            this.label11.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.label11.Text = "Exp. Date";
            this.label11.Top = 0.875F;
            this.label11.Width = 0.625F;
            // 
            // label12
            // 
            this.label12.Border.BottomColor = System.Drawing.Color.Black;
            this.label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.LeftColor = System.Drawing.Color.Black;
            this.label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.RightColor = System.Drawing.Color.Black;
            this.label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.TopColor = System.Drawing.Color.Black;
            this.label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Height = 0.1875F;
            this.label12.HyperLink = "";
            this.label12.Left = 19.6875F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.label12.Text = "Cancel Method";
            this.label12.Top = 0.875F;
            this.label12.Width = 0.875F;
            // 
            // lblTerm
            // 
            this.lblTerm.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTerm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTerm.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTerm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTerm.Border.RightColor = System.Drawing.Color.Black;
            this.lblTerm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTerm.Border.TopColor = System.Drawing.Color.Black;
            this.lblTerm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTerm.Height = 0.1875F;
            this.lblTerm.HyperLink = "";
            this.lblTerm.Left = 13.75F;
            this.lblTerm.MultiLine = false;
            this.lblTerm.Name = "lblTerm";
            this.lblTerm.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.lblTerm.Text = "Term";
            this.lblTerm.Top = 0.875F;
            this.lblTerm.Width = 0.375F;
            // 
            // label13
            // 
            this.label13.Border.BottomColor = System.Drawing.Color.Black;
            this.label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.LeftColor = System.Drawing.Color.Black;
            this.label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.RightColor = System.Drawing.Color.Black;
            this.label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.TopColor = System.Drawing.Color.Black;
            this.label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Height = 0.1875F;
            this.label13.HyperLink = "";
            this.label13.Left = 16.75F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.label13.Text = "Charge";
            this.label13.Top = 0.875F;
            this.label13.Width = 0.6875F;
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
            this.Label130});
            this.GroupHeader1.DataField = "AgencyDesc";
            this.GroupHeader1.Height = 0.2076389F;
            this.GroupHeader1.KeepTogether = true;
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
            this.Label131.DataField = "Agency";
            this.Label131.Height = 0.2F;
            this.Label131.HyperLink = "";
            this.Label131.Left = 0.8958333F;
            this.Label131.Name = "Label131";
            this.Label131.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label131.Text = "";
            this.Label131.Top = 0F;
            this.Label131.Width = 0.4375F;
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
            this.Label132.DataField = "AgencyDesc";
            this.Label132.Height = 0.2F;
            this.Label132.HyperLink = "";
            this.Label132.Left = 1.395833F;
            this.Label132.Name = "Label132";
            this.Label132.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label132.Text = "";
            this.Label132.Top = 0F;
            this.Label132.Width = 2.5625F;
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
            this.Label130.Left = 0.25F;
            this.Label130.Name = "Label130";
            this.Label130.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label130.Text = "Agency:";
            this.Label130.Top = 0F;
            this.Label130.Width = 0.5625F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label133,
            this.Label134,
            this.TextBox24,
            this.TextBox25,
            this.Label164,
            this.Label165,
            this.Label166,
            this.TextBox70,
            this.TextBox74,
            this.TextBox76,
            this.textBox14});
            this.GroupFooter1.Height = 0.4895833F;
            this.GroupFooter1.KeepTogether = true;
            this.GroupFooter1.Name = "GroupFooter1";
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
            this.Label133.Height = 0.1875F;
            this.Label133.HyperLink = "";
            this.Label133.Left = 0.28125F;
            this.Label133.Name = "Label133";
            this.Label133.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label133.Text = "Total for Agency:";
            this.Label133.Top = 0F;
            this.Label133.Width = 1F;
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
            this.Label134.DataField = "Agency";
            this.Label134.Height = 0.1875F;
            this.Label134.HyperLink = "";
            this.Label134.Left = 1.375F;
            this.Label134.Name = "Label134";
            this.Label134.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label134.Text = "";
            this.Label134.Top = 0F;
            this.Label134.Width = 0.5F;
            // 
            // TextBox24
            // 
            this.TextBox24.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox24.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox24.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox24.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox24.DataField = "TotalPremium";
            this.TextBox24.Height = 0.1875F;
            this.TextBox24.Left = 15.875F;
            this.TextBox24.Name = "TextBox24";
            this.TextBox24.OutputFormat = resources.GetString("TextBox24.OutputFormat");
            this.TextBox24.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox24.SummaryGroup = "GroupHeader1";
            this.TextBox24.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox24.Text = null;
            this.TextBox24.Top = 0F;
            this.TextBox24.Width = 0.6875F;
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
            this.TextBox25.DataField = "CancellationAmount";
            this.TextBox25.Height = 0.1875F;
            this.TextBox25.Left = 17.5F;
            this.TextBox25.Name = "TextBox25";
            this.TextBox25.OutputFormat = resources.GetString("TextBox25.OutputFormat");
            this.TextBox25.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox25.SummaryGroup = "GroupHeader1";
            this.TextBox25.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox25.Text = null;
            this.TextBox25.Top = 0F;
            this.TextBox25.Width = 0.6875F;
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
            this.Label164.Height = 0.2F;
            this.Label164.HyperLink = "";
            this.Label164.Left = 6.09375F;
            this.Label164.Name = "Label164";
            this.Label164.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label164.Text = "New Contracts";
            this.Label164.Top = 0F;
            this.Label164.Width = 0.9375F;
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
            this.Label165.Height = 0.2F;
            this.Label165.HyperLink = "";
            this.Label165.Left = 6.09375F;
            this.Label165.Name = "Label165";
            this.Label165.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label165.Text = "Cancellations";
            this.Label165.Top = 0.125F;
            this.Label165.Width = 0.9375F;
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
            this.Label166.Height = 0.2F;
            this.Label166.HyperLink = "";
            this.Label166.Left = 6.09375F;
            this.Label166.Name = "Label166";
            this.Label166.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label166.Text = "Net >>>>>>>";
            this.Label166.Top = 0.25F;
            this.Label166.Width = 0.9375F;
            // 
            // TextBox70
            // 
            this.TextBox70.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox70.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox70.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox70.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox70.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox70.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox70.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox70.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox70.DataField = "CancCount";
            this.TextBox70.Height = 0.1875F;
            this.TextBox70.Left = 7.03125F;
            this.TextBox70.Name = "TextBox70";
            this.TextBox70.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox70.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox70.SummaryGroup = "GroupHeader1";
            this.TextBox70.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox70.Text = null;
            this.TextBox70.Top = 0.125F;
            this.TextBox70.Width = 0.625F;
            // 
            // TextBox74
            // 
            this.TextBox74.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox74.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox74.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox74.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox74.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox74.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox74.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox74.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox74.DataField = "PrmCount";
            this.TextBox74.Height = 0.1875F;
            this.TextBox74.Left = 7.03125F;
            this.TextBox74.Name = "TextBox74";
            this.TextBox74.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox74.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox74.SummaryGroup = "GroupHeader1";
            this.TextBox74.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox74.Text = null;
            this.TextBox74.Top = 0F;
            this.TextBox74.Width = 0.625F;
            // 
            // TextBox76
            // 
            this.TextBox76.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox76.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox76.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox76.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox76.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox76.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox76.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox76.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox76.DataField = "PremNet";
            this.TextBox76.Height = 0.1875F;
            this.TextBox76.Left = 18.3125F;
            this.TextBox76.Name = "TextBox76";
            this.TextBox76.OutputFormat = resources.GetString("TextBox76.OutputFormat");
            this.TextBox76.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox76.SummaryGroup = "GroupHeader1";
            this.TextBox76.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox76.Text = null;
            this.TextBox76.Top = 0F;
            this.TextBox76.Width = 0.6875F;
            // 
            // textBox14
            // 
            this.textBox14.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.RightColor = System.Drawing.Color.Black;
            this.textBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.TopColor = System.Drawing.Color.Black;
            this.textBox14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.DataField = "Charge";
            this.textBox14.Height = 0.1875F;
            this.textBox14.Left = 16.6875F;
            this.textBox14.Name = "textBox14";
            this.textBox14.OutputFormat = resources.GetString("textBox14.OutputFormat");
            this.textBox14.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.textBox14.SummaryGroup = "GroupHeader1";
            this.textBox14.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox14.Text = null;
            this.textBox14.Top = 0F;
            this.textBox14.Width = 0.6875F;
            // 
            // AutoGuardPremiumWritten
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 20.77083F;
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
            this.ReportStart += new System.EventHandler(this.AutoGuardPremiumWritten_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.txtTaskControlID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRegCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label127)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label167)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label168)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label169)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox68)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label122)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label125)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label128)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label113)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label129)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label170)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblCompanyHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTerm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label164)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label165)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label166)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox74)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox76)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

		#endregion

        private void PageHeader_Format_1(object sender, EventArgs e)
        {

        }
	}
}
