using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.TaskControl;
using EPolicy.Customer;

namespace EPolicy2.Reports
{
	public class AutoPolicyReport : DataDynamics.ActiveReports.ActiveReport3
	{
		string  _FromDate;
		string  _ToDate;
		string  _ReportType;
		bool    _Summary = false;

		public AutoPolicyReport(string FromDate,string ToDate, string ReportType, bool Summary)
		{
			_FromDate   = FromDate;
			_ToDate     = ToDate;
			_ReportType = ReportType;
			_Summary    =  Summary;

			InitializeComponent();
		}

		private void AutoPolicyReport_ReportStart(object sender, System.EventArgs eArgs)
		{
			if (_Summary)
			{
				this.Detail.Visible = false;
			}

			this.lblDate.Text = "Date:"+DateTime.Now.ToShortDateString();
			this.lblTime.Text = "Time:"+DateTime.Now.ToShortTimeString();

			if (!_FromDate.Trim().Equals("")||(!_FromDate.Trim().Equals("")))
			{
				this.lblCriterias.Text = _ReportType + " From: " + _FromDate +" To: " + _ToDate;
			}

		}

		private void GroupFooter2_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Label lblCriterias = null;
		private DataDynamics.ActiveReports.Label lblDate = null;
		private DataDynamics.ActiveReports.Label lblTime = null;
		private DataDynamics.ActiveReports.Label Label80 = null;
		private DataDynamics.ActiveReports.TextBox TextBox17 = null;
		private DataDynamics.ActiveReports.Label Label104 = null;
		private DataDynamics.ActiveReports.Label Label105 = null;
		private DataDynamics.ActiveReports.Label Label106 = null;
		private DataDynamics.ActiveReports.Label Label107 = null;
		private DataDynamics.ActiveReports.Label Label108 = null;
		private DataDynamics.ActiveReports.Label Label109 = null;
		private DataDynamics.ActiveReports.Label Label135 = null;
		private DataDynamics.ActiveReports.Line Line142 = null;
		private DataDynamics.ActiveReports.Label Label75 = null;
		private DataDynamics.ActiveReports.Label Label77 = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader1 = null;
		private DataDynamics.ActiveReports.Label Label136 = null;
		private DataDynamics.ActiveReports.Label Label137 = null;
		private DataDynamics.ActiveReports.Label Label138 = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader2 = null;
		private DataDynamics.ActiveReports.Label Label132 = null;
		private DataDynamics.ActiveReports.Label Label131 = null;
		private DataDynamics.ActiveReports.Label Label130 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox txtCustomerName = null;
		private DataDynamics.ActiveReports.TextBox txtCustomerNo = null;
		private DataDynamics.ActiveReports.TextBox TxtPolicyNo = null;
		private DataDynamics.ActiveReports.TextBox TxtLoanNo = null;
		private DataDynamics.ActiveReports.TextBox TxtTotalPremium = null;
		private DataDynamics.ActiveReports.TextBox TxtEntryDate = null;
		private DataDynamics.ActiveReports.TextBox TxtEffectiveDate = null;
		private DataDynamics.ActiveReports.TextBox TextBox24 = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter2 = null;
		private DataDynamics.ActiveReports.Label Label133 = null;
		private DataDynamics.ActiveReports.Label Label134 = null;
		private DataDynamics.ActiveReports.TextBox TextBox23 = null;
		private DataDynamics.ActiveReports.TextBox TextBox28 = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1 = null;
		private DataDynamics.ActiveReports.TextBox TextBox25 = null;
		private DataDynamics.ActiveReports.Label Label142 = null;
		private DataDynamics.ActiveReports.TextBox TextBox29 = null;
		private DataDynamics.ActiveReports.Label Label143 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		private DataDynamics.ActiveReports.Line Line140 = null;
		private DataDynamics.ActiveReports.TextBox TextBox26 = null;
		private DataDynamics.ActiveReports.Line Line141 = null;
		private DataDynamics.ActiveReports.Label Label139 = null;
		private DataDynamics.ActiveReports.TextBox TextBox27 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoPolicyReport));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.GroupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.GroupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.GroupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.GroupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.lblCriterias = new DataDynamics.ActiveReports.Label();
            this.lblDate = new DataDynamics.ActiveReports.Label();
            this.lblTime = new DataDynamics.ActiveReports.Label();
            this.Label80 = new DataDynamics.ActiveReports.Label();
            this.TextBox17 = new DataDynamics.ActiveReports.TextBox();
            this.Label104 = new DataDynamics.ActiveReports.Label();
            this.Label105 = new DataDynamics.ActiveReports.Label();
            this.Label106 = new DataDynamics.ActiveReports.Label();
            this.Label107 = new DataDynamics.ActiveReports.Label();
            this.Label108 = new DataDynamics.ActiveReports.Label();
            this.Label109 = new DataDynamics.ActiveReports.Label();
            this.Label135 = new DataDynamics.ActiveReports.Label();
            this.Line142 = new DataDynamics.ActiveReports.Line();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.Label136 = new DataDynamics.ActiveReports.Label();
            this.Label137 = new DataDynamics.ActiveReports.Label();
            this.Label138 = new DataDynamics.ActiveReports.Label();
            this.Label132 = new DataDynamics.ActiveReports.Label();
            this.Label131 = new DataDynamics.ActiveReports.Label();
            this.Label130 = new DataDynamics.ActiveReports.Label();
            this.txtCustomerName = new DataDynamics.ActiveReports.TextBox();
            this.txtCustomerNo = new DataDynamics.ActiveReports.TextBox();
            this.TxtPolicyNo = new DataDynamics.ActiveReports.TextBox();
            this.TxtLoanNo = new DataDynamics.ActiveReports.TextBox();
            this.TxtTotalPremium = new DataDynamics.ActiveReports.TextBox();
            this.TxtEntryDate = new DataDynamics.ActiveReports.TextBox();
            this.TxtEffectiveDate = new DataDynamics.ActiveReports.TextBox();
            this.TextBox24 = new DataDynamics.ActiveReports.TextBox();
            this.Label133 = new DataDynamics.ActiveReports.Label();
            this.Label134 = new DataDynamics.ActiveReports.Label();
            this.TextBox23 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox28 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox25 = new DataDynamics.ActiveReports.TextBox();
            this.Label142 = new DataDynamics.ActiveReports.Label();
            this.TextBox29 = new DataDynamics.ActiveReports.TextBox();
            this.Label143 = new DataDynamics.ActiveReports.Label();
            this.Line140 = new DataDynamics.ActiveReports.Line();
            this.TextBox26 = new DataDynamics.ActiveReports.TextBox();
            this.Line141 = new DataDynamics.ActiveReports.Line();
            this.Label139 = new DataDynamics.ActiveReports.Label();
            this.TextBox27 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label136)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label137)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label138)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPolicyNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLoanNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotalPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEntryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEffectiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label142)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label143)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label139)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.txtCustomerName,
                        this.txtCustomerNo,
                        this.TxtPolicyNo,
                        this.TxtLoanNo,
                        this.TxtTotalPremium,
                        this.TxtEntryDate,
                        this.TxtEffectiveDate,
                        this.TextBox24});
            this.Detail.Height = 0.3125F;
            this.Detail.Name = "Detail";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Height = 0F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Line140,
                        this.TextBox26,
                        this.Line141,
                        this.Label139,
                        this.TextBox27});
            this.ReportFooter.Height = 0.2708333F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.lblCriterias,
                        this.lblDate,
                        this.lblTime,
                        this.Label80,
                        this.TextBox17,
                        this.Label104,
                        this.Label105,
                        this.Label106,
                        this.Label107,
                        this.Label108,
                        this.Label109,
                        this.Label135,
                        this.Line142,
                        this.Label75,
                        this.Label77});
            this.PageHeader.Height = 1.384722F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Label136,
                        this.Label137,
                        this.Label138});
            this.GroupHeader1.DataField = "CompanyDealer";
            this.GroupHeader1.Height = 0.2076389F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.TextBox25,
                        this.Label142,
                        this.TextBox29,
                        this.Label143});
            this.GroupFooter1.Height = 0.1979167F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Label132,
                        this.Label131,
                        this.Label130});
            this.GroupHeader2.DataField = "InsuranceCompany";
            this.GroupHeader2.Height = 0.2F;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Label133,
                        this.Label134,
                        this.TextBox23,
                        this.TextBox28});
            this.GroupFooter2.Height = 0.2076389F;
            this.GroupFooter2.Name = "GroupFooter2";
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
            this.lblCriterias.Left = 1.432292F;
            this.lblCriterias.MultiLine = false;
            this.lblCriterias.Name = "lblCriterias";
            this.lblCriterias.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.lblCriterias.Text = "Auto Policy Report By InsuranceCompany/CompanyDealer";
            this.lblCriterias.Top = 0.6875F;
            this.lblCriterias.Width = 5.125F;
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
            this.lblDate.Left = 0.5625F;
            this.lblDate.Name = "lblDate";
            this.lblDate.Style = "text-align: left; font-size: 8pt; ";
            this.lblDate.Text = "lblDate";
            this.lblDate.Top = 0.1875F;
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
            this.lblTime.Left = 0.5625F;
            this.lblTime.Name = "lblTime";
            this.lblTime.Style = "text-align: left; font-size: 8pt; ";
            this.lblTime.Text = "lblTime";
            this.lblTime.Top = 0.375F;
            this.lblTime.Width = 0.9090909F;
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
            this.Label80.Left = 6.8125F;
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
            this.TextBox17.Left = 7.25F;
            this.TextBox17.MultiLine = false;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat");
            this.TextBox17.Style = "text-align: right; font-size: 8pt; vertical-align: top; ";
            this.TextBox17.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox17.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.TextBox17.Top = 0.1875F;
            this.TextBox17.Width = 0.322917F;
            // 
            // Label104
            // 
            this.Label104.Border.BottomColor = System.Drawing.Color.Black;
            this.Label104.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label104.Border.LeftColor = System.Drawing.Color.Black;
            this.Label104.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label104.Border.RightColor = System.Drawing.Color.Black;
            this.Label104.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label104.Border.TopColor = System.Drawing.Color.Black;
            this.Label104.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label104.Height = 0.2F;
            this.Label104.HyperLink = "";
            this.Label104.Left = 0.375F;
            this.Label104.Name = "Label104";
            this.Label104.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label104.Text = "POLICY";
            this.Label104.Top = 1.125F;
            this.Label104.Width = 0.5625F;
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
            this.Label105.Height = 0.2F;
            this.Label105.HyperLink = "";
            this.Label105.Left = 3.75F;
            this.Label105.MultiLine = false;
            this.Label105.Name = "Label105";
            this.Label105.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label105.Text = "TOTAL PREMIUM";
            this.Label105.Top = 1.125F;
            this.Label105.Width = 1.0625F;
            // 
            // Label106
            // 
            this.Label106.Border.BottomColor = System.Drawing.Color.Black;
            this.Label106.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label106.Border.LeftColor = System.Drawing.Color.Black;
            this.Label106.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label106.Border.RightColor = System.Drawing.Color.Black;
            this.Label106.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label106.Border.TopColor = System.Drawing.Color.Black;
            this.Label106.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label106.Height = 0.2F;
            this.Label106.HyperLink = "";
            this.Label106.Left = 2.1875F;
            this.Label106.MultiLine = false;
            this.Label106.Name = "Label106";
            this.Label106.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label106.Text = "CUSTOMER";
            this.Label106.Top = 1.125F;
            this.Label106.Width = 0.6875F;
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
            this.Label107.Height = 0.2F;
            this.Label107.HyperLink = "";
            this.Label107.Left = 3.023438F;
            this.Label107.MultiLine = false;
            this.Label107.Name = "Label107";
            this.Label107.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label107.Text = "LOAN NO.";
            this.Label107.Top = 1.125F;
            this.Label107.Width = 0.625F;
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
            this.Label108.Height = 0.2F;
            this.Label108.HyperLink = "";
            this.Label108.Left = 4.9375F;
            this.Label108.MultiLine = false;
            this.Label108.Name = "Label108";
            this.Label108.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label108.Text = "ENTRY DATE";
            this.Label108.Top = 1.125F;
            this.Label108.Width = 0.875F;
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
            this.Label109.Height = 0.2F;
            this.Label109.HyperLink = "";
            this.Label109.Left = 5.90625F;
            this.Label109.MultiLine = false;
            this.Label109.Name = "Label109";
            this.Label109.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label109.Text = "EFFECTIVE DATE";
            this.Label109.Top = 1.125F;
            this.Label109.Width = 1.0625F;
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
            this.Label135.Height = 0.2F;
            this.Label135.HyperLink = "";
            this.Label135.Left = 7.03125F;
            this.Label135.Name = "Label135";
            this.Label135.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label135.Text = "TERM";
            this.Label135.Top = 1.125F;
            this.Label135.Width = 0.5625F;
            // 
            // Line142
            // 
            this.Line142.Border.BottomColor = System.Drawing.Color.Black;
            this.Line142.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line142.Border.LeftColor = System.Drawing.Color.Black;
            this.Line142.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line142.Border.RightColor = System.Drawing.Color.Black;
            this.Line142.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line142.Border.TopColor = System.Drawing.Color.Black;
            this.Line142.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line142.Height = 0F;
            this.Line142.Left = 0.1944447F;
            this.Line142.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Line142.LineWeight = 1F;
            this.Line142.Name = "Line142";
            this.Line142.Top = 1.319444F;
            this.Line142.Width = 7.625F;
            this.Line142.X1 = 7.819445F;
            this.Line142.X2 = 0.1944447F;
            this.Line142.Y1 = 1.319444F;
            this.Line142.Y2 = 1.319444F;
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
            this.Label75.Left = 1.5625F;
            this.Label75.MultiLine = false;
            this.Label75.Name = "Label75";
            this.Label75.Style = "text-align: center; font-weight: bold; font-size: 11.25pt; font-family: Times New" +
                " Roman; ";
            this.Label75.Text = "LAS VISTAS INSURANCE AGENCY, CORP.";
            this.Label75.Top = 0.0625F;
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
            this.Label77.Left = 1.5625F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-align: center; font-weight: bold; font-size: 6pt; font-family: Times New Rom" +
                "an; ";
            this.Label77.Text = "P.O. Box 195585 San Juan Puerto Rico, PR  00919-5585 Tel (787) 763-4010 Fax (787)" +
                " 763-3525";
            this.Label77.Top = 0.3125F;
            this.Label77.Width = 5.125F;
            // 
            // Label136
            // 
            this.Label136.Border.BottomColor = System.Drawing.Color.Black;
            this.Label136.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label136.Border.LeftColor = System.Drawing.Color.Black;
            this.Label136.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label136.Border.RightColor = System.Drawing.Color.Black;
            this.Label136.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label136.Border.TopColor = System.Drawing.Color.Black;
            this.Label136.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label136.Height = 0.2F;
            this.Label136.HyperLink = "";
            this.Label136.Left = 0.3958334F;
            this.Label136.Name = "Label136";
            this.Label136.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label136.Text = "CODEALER.:";
            this.Label136.Top = 0F;
            this.Label136.Width = 0.7291667F;
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
            this.Label137.DataField = "CompanyDealer";
            this.Label137.Height = 0.2F;
            this.Label137.HyperLink = "";
            this.Label137.Left = 1.125F;
            this.Label137.Name = "Label137";
            this.Label137.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label137.Text = "";
            this.Label137.Top = 0F;
            this.Label137.Width = 0.4375F;
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
            this.Label138.DataField = "CompanyDealerDesc";
            this.Label138.Height = 0.2F;
            this.Label138.HyperLink = "";
            this.Label138.Left = 1.625F;
            this.Label138.Name = "Label138";
            this.Label138.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label138.Text = "";
            this.Label138.Top = 0F;
            this.Label138.Width = 2.5625F;
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
            this.Label132.DataField = "InsuranceCompanyDesc";
            this.Label132.Height = 0.2F;
            this.Label132.HyperLink = "";
            this.Label132.Left = 1.75F;
            this.Label132.Name = "Label132";
            this.Label132.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label132.Text = "";
            this.Label132.Top = 0F;
            this.Label132.Width = 2.5625F;
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
            this.Label131.DataField = "InsuranceCompany";
            this.Label131.Height = 0.2F;
            this.Label131.HyperLink = "";
            this.Label131.Left = 1.25F;
            this.Label131.Name = "Label131";
            this.Label131.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label131.Text = "";
            this.Label131.Top = 0F;
            this.Label131.Width = 0.4375F;
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
            this.Label130.Height = 0.2F;
            this.Label130.HyperLink = "";
            this.Label130.Left = 0.5208334F;
            this.Label130.Name = "Label130";
            this.Label130.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label130.Text = "INSCO.:";
            this.Label130.Top = 0F;
            this.Label130.Width = 0.4791667F;
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
            this.txtCustomerName.DataField = "CustomerNo";
            this.txtCustomerName.Height = 0.125F;
            this.txtCustomerName.Left = 2.1875F;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Style = "text-align: center; font-size: 7pt; ";
            this.txtCustomerName.Top = 0F;
            this.txtCustomerName.Width = 0.6875F;
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
            this.txtCustomerNo.Height = 0.1875F;
            this.txtCustomerNo.Left = 0.5625F;
            this.txtCustomerNo.Name = "txtCustomerNo";
            this.txtCustomerNo.Style = "text-align: left; font-size: 7pt; ";
            this.txtCustomerNo.Top = 0.125F;
            this.txtCustomerNo.Width = 1.625F;
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
            this.TxtPolicyNo.DataField = "PolicyNumber";
            this.TxtPolicyNo.Height = 0.125F;
            this.TxtPolicyNo.Left = 0.5729166F;
            this.TxtPolicyNo.Name = "TxtPolicyNo";
            this.TxtPolicyNo.Style = "text-align: left; font-size: 7pt; ";
            this.TxtPolicyNo.Top = 0F;
            this.TxtPolicyNo.Width = 1.489583F;
            // 
            // TxtLoanNo
            // 
            this.TxtLoanNo.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtLoanNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLoanNo.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtLoanNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLoanNo.Border.RightColor = System.Drawing.Color.Black;
            this.TxtLoanNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLoanNo.Border.TopColor = System.Drawing.Color.Black;
            this.TxtLoanNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLoanNo.DataField = "LoanNo";
            this.TxtLoanNo.Height = 0.125F;
            this.TxtLoanNo.Left = 2.921875F;
            this.TxtLoanNo.Name = "TxtLoanNo";
            this.TxtLoanNo.Style = "text-align: left; font-size: 7pt; ";
            this.TxtLoanNo.Top = 0F;
            this.TxtLoanNo.Width = 0.828125F;
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
            this.TxtTotalPremium.DataField = "TotalPrem";
            this.TxtTotalPremium.Height = 0.125F;
            this.TxtTotalPremium.Left = 3.75F;
            this.TxtTotalPremium.MultiLine = false;
            this.TxtTotalPremium.Name = "TxtTotalPremium";
            this.TxtTotalPremium.OutputFormat = resources.GetString("TxtTotalPremium.OutputFormat");
            this.TxtTotalPremium.Style = "text-align: center; font-weight: normal; font-size: 6.75pt; ";
            this.TxtTotalPremium.Top = 0F;
            this.TxtTotalPremium.Width = 1.0625F;
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
            this.TxtEntryDate.DataField = "EntryDate";
            this.TxtEntryDate.Height = 0.125F;
            this.TxtEntryDate.Left = 5F;
            this.TxtEntryDate.Name = "TxtEntryDate";
            this.TxtEntryDate.OutputFormat = resources.GetString("TxtEntryDate.OutputFormat");
            this.TxtEntryDate.Style = "text-align: center; font-size: 7pt; ";
            this.TxtEntryDate.Top = 0F;
            this.TxtEntryDate.Width = 0.75F;
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
            this.TxtEffectiveDate.DataField = "EffectiveDate";
            this.TxtEffectiveDate.Height = 0.125F;
            this.TxtEffectiveDate.Left = 6.0625F;
            this.TxtEffectiveDate.Name = "TxtEffectiveDate";
            this.TxtEffectiveDate.OutputFormat = resources.GetString("TxtEffectiveDate.OutputFormat");
            this.TxtEffectiveDate.Style = "text-align: center; font-size: 7pt; ";
            this.TxtEffectiveDate.Top = 0F;
            this.TxtEffectiveDate.Width = 0.75F;
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
            this.TextBox24.DataField = "Term";
            this.TextBox24.Height = 0.125F;
            this.TextBox24.Left = 7.0625F;
            this.TextBox24.Name = "TextBox24";
            this.TextBox24.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox24.Top = 0F;
            this.TextBox24.Width = 0.5F;
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
            this.Label133.Height = 0.2F;
            this.Label133.HyperLink = "";
            this.Label133.Left = 0.5F;
            this.Label133.Name = "Label133";
            this.Label133.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label133.Text = "Total for InsCo.:";
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
            this.Label134.DataField = "InsuranceCompany";
            this.Label134.Height = 0.2F;
            this.Label134.HyperLink = "";
            this.Label134.Left = 1.5625F;
            this.Label134.Name = "Label134";
            this.Label134.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label134.Text = "";
            this.Label134.Top = 0F;
            this.Label134.Width = 0.4375F;
            // 
            // TextBox23
            // 
            this.TextBox23.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox23.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox23.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox23.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox23.DataField = "InsuranceCompany";
            this.TextBox23.Height = 0.1875F;
            this.TextBox23.Left = 2.125F;
            this.TextBox23.Name = "TextBox23";
            this.TextBox23.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.TextBox23.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox23.SummaryGroup = "GroupHeader2";
            this.TextBox23.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox23.Top = 0F;
            this.TextBox23.Width = 0.5625F;
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
            this.TextBox28.DataField = "TotalPrem";
            this.TextBox28.Height = 0.1875F;
            this.TextBox28.Left = 3.75F;
            this.TextBox28.MultiLine = false;
            this.TextBox28.Name = "TextBox28";
            this.TextBox28.OutputFormat = resources.GetString("TextBox28.OutputFormat");
            this.TextBox28.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; ";
            this.TextBox28.SummaryGroup = "GroupHeader2";
            this.TextBox28.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox28.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox28.Top = 0F;
            this.TextBox28.Width = 1.0625F;
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
            this.TextBox25.DataField = "TotalPrem";
            this.TextBox25.Height = 0.1875F;
            this.TextBox25.Left = 3.739583F;
            this.TextBox25.MultiLine = false;
            this.TextBox25.Name = "TextBox25";
            this.TextBox25.OutputFormat = resources.GetString("TextBox25.OutputFormat");
            this.TextBox25.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; ";
            this.TextBox25.SummaryGroup = "GroupHeader1";
            this.TextBox25.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox25.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox25.Top = 0F;
            this.TextBox25.Width = 1.0625F;
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
            this.Label142.Height = 0.2F;
            this.Label142.HyperLink = "";
            this.Label142.Left = 0.3958334F;
            this.Label142.Name = "Label142";
            this.Label142.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; vertica" +
                "l-align: middle; ";
            this.Label142.Text = "Total for CoDealer.:";
            this.Label142.Top = 0F;
            this.Label142.Width = 1.0625F;
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
            this.TextBox29.DataField = "CompanyDealer";
            this.TextBox29.Height = 0.1875F;
            this.TextBox29.Left = 2.125F;
            this.TextBox29.Name = "TextBox29";
            this.TextBox29.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.TextBox29.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox29.SummaryGroup = "GroupHeader1";
            this.TextBox29.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox29.Top = 0F;
            this.TextBox29.Width = 0.5625F;
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
            this.Label143.DataField = "CompanyDealer";
            this.Label143.Height = 0.2F;
            this.Label143.HyperLink = "";
            this.Label143.Left = 1.5625F;
            this.Label143.Name = "Label143";
            this.Label143.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; vertica" +
                "l-align: middle; ";
            this.Label143.Text = "";
            this.Label143.Top = 0F;
            this.Label143.Width = 0.4375F;
            // 
            // Line140
            // 
            this.Line140.Border.BottomColor = System.Drawing.Color.Black;
            this.Line140.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line140.Border.LeftColor = System.Drawing.Color.Black;
            this.Line140.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line140.Border.RightColor = System.Drawing.Color.Black;
            this.Line140.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line140.Border.TopColor = System.Drawing.Color.Black;
            this.Line140.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line140.Height = 0F;
            this.Line140.Left = 0.375F;
            this.Line140.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line140.LineWeight = 3F;
            this.Line140.Name = "Line140";
            this.Line140.Top = 0F;
            this.Line140.Width = 7.375F;
            this.Line140.X1 = 0.375F;
            this.Line140.X2 = 7.75F;
            this.Line140.Y1 = 0F;
            this.Line140.Y2 = 0F;
            // 
            // TextBox26
            // 
            this.TextBox26.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox26.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox26.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox26.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox26.DataField = "TotalPrem";
            this.TextBox26.Height = 0.1875F;
            this.TextBox26.Left = 3.75F;
            this.TextBox26.MultiLine = false;
            this.TextBox26.Name = "TextBox26";
            this.TextBox26.OutputFormat = resources.GetString("TextBox26.OutputFormat");
            this.TextBox26.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; vertical-align: middle;" +
                " ";
            this.TextBox26.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox26.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox26.Top = 0F;
            this.TextBox26.Width = 1.0625F;
            // 
            // Line141
            // 
            this.Line141.Border.BottomColor = System.Drawing.Color.Black;
            this.Line141.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line141.Border.LeftColor = System.Drawing.Color.Black;
            this.Line141.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line141.Border.RightColor = System.Drawing.Color.Black;
            this.Line141.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line141.Border.TopColor = System.Drawing.Color.Black;
            this.Line141.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line141.Height = 0F;
            this.Line141.Left = 0.375F;
            this.Line141.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line141.LineWeight = 3F;
            this.Line141.Name = "Line141";
            this.Line141.Top = 0.25F;
            this.Line141.Width = 7.375F;
            this.Line141.X1 = 0.375F;
            this.Line141.X2 = 7.75F;
            this.Line141.Y1 = 0.25F;
            this.Line141.Y2 = 0.25F;
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
            this.Label139.Left = 0.3958334F;
            this.Label139.Name = "Label139";
            this.Label139.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; vertica" +
                "l-align: middle; ";
            this.Label139.Text = "Grand Total :";
            this.Label139.Top = 0F;
            this.Label139.Width = 1.0625F;
            // 
            // TextBox27
            // 
            this.TextBox27.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox27.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox27.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox27.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox27.DataField = "CompnayDealer";
            this.TextBox27.Height = 0.1875F;
            this.TextBox27.Left = 2.125F;
            this.TextBox27.Name = "TextBox27";
            this.TextBox27.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.TextBox27.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox27.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox27.Top = 0F;
            this.TextBox27.Width = 0.5625F;
            // 
            // ActiveReport31
            // 
            this.PageSettings.Margins.Bottom = 0.2F;
            this.PageSettings.Margins.Left = 0.1F;
            this.PageSettings.Margins.Right = 0.1F;
            this.PageSettings.Margins.Top = 0.2F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.989583F;
            this.Sections.Add(this.ReportHeader);
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.GroupHeader1);
            this.Sections.Add(this.GroupHeader2);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GroupFooter2);
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
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label136)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label137)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label138)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPolicyNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLoanNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotalPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEntryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEffectiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label142)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label143)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label139)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
       
			// Attach Report Events
			this.ReportStart += new System.EventHandler(this.AutoPolicyReport_ReportStart);
			this.GroupFooter2.Format += new System.EventHandler(this.GroupFooter2_Format);
			this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
		 }

		#endregion
	}
}
