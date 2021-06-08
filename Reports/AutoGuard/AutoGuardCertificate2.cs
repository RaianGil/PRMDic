using System;
using System.Data;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.LookupTables;
using EPolicy.TaskControl;

namespace EPolicy2.Reports
{
	public class AutoGuardCertificate2 : DataDynamics.ActiveReports.ActiveReport3
	{

		private string _FromDate;
		private string _ToDate;
		private string _ReportType;
		private bool   _Summary = false;
		private DataTable _dt = null;
        string _mHeadCompany = "";

        public AutoGuardCertificate2(string FromDate, string ToDate, string ReportType, bool Summary, DataTable table, string mHeadCompany)
		{
			_FromDate   = FromDate;
			_ToDate     = ToDate;
			_ReportType = ReportType;
			_Summary    =  Summary;
			_dt			= table;
            _mHeadCompany = mHeadCompany;

			InitializeComponent();
		}

		private void AutoGuardCertificate2_ReportStart(object sender, System.EventArgs eArgs)
		{
            Label75.Text = _mHeadCompany;
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

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Label lblCriterias = null;
		private DataDynamics.ActiveReports.Label Label80 = null;
		private DataDynamics.ActiveReports.TextBox TextBox17 = null;
		private DataDynamics.ActiveReports.Label lblDate = null;
		private DataDynamics.ActiveReports.Label lblTime = null;
		private DataDynamics.ActiveReports.Shape Shape3 = null;
		private DataDynamics.ActiveReports.Label Label107 = null;
		private DataDynamics.ActiveReports.Label Label108 = null;
		private DataDynamics.ActiveReports.Label Label109 = null;
		private DataDynamics.ActiveReports.Label Label113 = null;
		private DataDynamics.ActiveReports.Label Label125 = null;
		private DataDynamics.ActiveReports.Label Label142 = null;
		private DataDynamics.ActiveReports.Label Label143 = null;
		private DataDynamics.ActiveReports.Label Label144 = null;
		private DataDynamics.ActiveReports.Label Label129 = null;
		private DataDynamics.ActiveReports.Label Label122 = null;
		private DataDynamics.ActiveReports.Label Label128 = null;
		private DataDynamics.ActiveReports.Label Label145 = null;
		private DataDynamics.ActiveReports.Label Label146 = null;
		private DataDynamics.ActiveReports.Label Label148 = null;
		private DataDynamics.ActiveReports.Label Label149 = null;
		private DataDynamics.ActiveReports.Label Label150 = null;
		private DataDynamics.ActiveReports.Label Label151 = null;
		private DataDynamics.ActiveReports.Label Label152 = null;
		private DataDynamics.ActiveReports.Label Label75 = null;
		private DataDynamics.ActiveReports.Label Label77 = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader1 = null;
		private DataDynamics.ActiveReports.Label Label130 = null;
		private DataDynamics.ActiveReports.Label Label131 = null;
		private DataDynamics.ActiveReports.Label Label132 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox txtTaskControlID = null;
		private DataDynamics.ActiveReports.TextBox TxtRegCode = null;
		private DataDynamics.ActiveReports.TextBox txtCustomerName = null;
		private DataDynamics.ActiveReports.TextBox txtEffectiveDate = null;
		private DataDynamics.ActiveReports.TextBox txtEntryDate = null;
		private DataDynamics.ActiveReports.TextBox TextBox22 = null;
		private DataDynamics.ActiveReports.TextBox txtTotalPremium = null;
		private DataDynamics.ActiveReports.TextBox TextBox20 = null;
		private DataDynamics.ActiveReports.TextBox TextBox49 = null;
		private DataDynamics.ActiveReports.TextBox TextBox50 = null;
		private DataDynamics.ActiveReports.TextBox TextBox46 = null;
		private DataDynamics.ActiveReports.TextBox TextBox47 = null;
		private DataDynamics.ActiveReports.TextBox TextBox51 = null;
		private DataDynamics.ActiveReports.TextBox TextBox52 = null;
		private DataDynamics.ActiveReports.TextBox TextBox53 = null;
		private DataDynamics.ActiveReports.TextBox TextBox54 = null;
		private DataDynamics.ActiveReports.TextBox TextBox55 = null;
		private DataDynamics.ActiveReports.TextBox TextBox56 = null;
		private DataDynamics.ActiveReports.TextBox TextBox61 = null;
		private DataDynamics.ActiveReports.TextBox TextBox62 = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1 = null;
		private DataDynamics.ActiveReports.Label Label134 = null;
		private DataDynamics.ActiveReports.Label Label135 = null;
		private DataDynamics.ActiveReports.TextBox TextBox25 = null;
		private DataDynamics.ActiveReports.TextBox TextBox36 = null;
		private DataDynamics.ActiveReports.TextBox TextBox24 = null;
		private DataDynamics.ActiveReports.TextBox TextBox48 = null;
		private DataDynamics.ActiveReports.TextBox TextBox57 = null;
		private DataDynamics.ActiveReports.TextBox TextBox58 = null;
		private DataDynamics.ActiveReports.Label Label153 = null;
		private DataDynamics.ActiveReports.Label Label154 = null;
		private DataDynamics.ActiveReports.TextBox TxtNetPrem = null;
		private DataDynamics.ActiveReports.Label Label155 = null;
		private DataDynamics.ActiveReports.TextBox TextBox60 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		private DataDynamics.ActiveReports.TextBox TextBox37 = null;
		private DataDynamics.ActiveReports.TextBox TextBox18 = null;
		private DataDynamics.ActiveReports.TextBox TextBox21 = null;
		private DataDynamics.ActiveReports.Line Line9 = null;
		private DataDynamics.ActiveReports.TextBox TextBox19 = null;
		private DataDynamics.ActiveReports.Label Label147 = null;
		private DataDynamics.ActiveReports.TextBox TextBox63 = null;
		private DataDynamics.ActiveReports.TextBox TextBox64 = null;
		private DataDynamics.ActiveReports.TextBox TextBox65 = null;
		private DataDynamics.ActiveReports.TextBox TextBox66 = null;
		private DataDynamics.ActiveReports.Label Label156 = null;
		private DataDynamics.ActiveReports.Label Label157 = null;
		private DataDynamics.ActiveReports.Label Label158 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoGuardCertificate2));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.GroupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.GroupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.lblCriterias = new DataDynamics.ActiveReports.Label();
            this.Label80 = new DataDynamics.ActiveReports.Label();
            this.TextBox17 = new DataDynamics.ActiveReports.TextBox();
            this.lblDate = new DataDynamics.ActiveReports.Label();
            this.lblTime = new DataDynamics.ActiveReports.Label();
            this.Shape3 = new DataDynamics.ActiveReports.Shape();
            this.Label107 = new DataDynamics.ActiveReports.Label();
            this.Label108 = new DataDynamics.ActiveReports.Label();
            this.Label109 = new DataDynamics.ActiveReports.Label();
            this.Label113 = new DataDynamics.ActiveReports.Label();
            this.Label125 = new DataDynamics.ActiveReports.Label();
            this.Label142 = new DataDynamics.ActiveReports.Label();
            this.Label143 = new DataDynamics.ActiveReports.Label();
            this.Label144 = new DataDynamics.ActiveReports.Label();
            this.Label129 = new DataDynamics.ActiveReports.Label();
            this.Label122 = new DataDynamics.ActiveReports.Label();
            this.Label128 = new DataDynamics.ActiveReports.Label();
            this.Label145 = new DataDynamics.ActiveReports.Label();
            this.Label146 = new DataDynamics.ActiveReports.Label();
            this.Label148 = new DataDynamics.ActiveReports.Label();
            this.Label149 = new DataDynamics.ActiveReports.Label();
            this.Label150 = new DataDynamics.ActiveReports.Label();
            this.Label151 = new DataDynamics.ActiveReports.Label();
            this.Label152 = new DataDynamics.ActiveReports.Label();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.Label130 = new DataDynamics.ActiveReports.Label();
            this.Label131 = new DataDynamics.ActiveReports.Label();
            this.Label132 = new DataDynamics.ActiveReports.Label();
            this.txtTaskControlID = new DataDynamics.ActiveReports.TextBox();
            this.TxtRegCode = new DataDynamics.ActiveReports.TextBox();
            this.txtCustomerName = new DataDynamics.ActiveReports.TextBox();
            this.txtEffectiveDate = new DataDynamics.ActiveReports.TextBox();
            this.txtEntryDate = new DataDynamics.ActiveReports.TextBox();
            this.TextBox22 = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalPremium = new DataDynamics.ActiveReports.TextBox();
            this.TextBox20 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox49 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox50 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox46 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox47 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox51 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox52 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox53 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox54 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox55 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox56 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox61 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox62 = new DataDynamics.ActiveReports.TextBox();
            this.Label134 = new DataDynamics.ActiveReports.Label();
            this.Label135 = new DataDynamics.ActiveReports.Label();
            this.TextBox25 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox36 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox24 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox48 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox57 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox58 = new DataDynamics.ActiveReports.TextBox();
            this.Label153 = new DataDynamics.ActiveReports.Label();
            this.Label154 = new DataDynamics.ActiveReports.Label();
            this.TxtNetPrem = new DataDynamics.ActiveReports.TextBox();
            this.Label155 = new DataDynamics.ActiveReports.Label();
            this.TextBox60 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox37 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox18 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox21 = new DataDynamics.ActiveReports.TextBox();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.TextBox19 = new DataDynamics.ActiveReports.TextBox();
            this.Label147 = new DataDynamics.ActiveReports.Label();
            this.TextBox63 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox64 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox65 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox66 = new DataDynamics.ActiveReports.TextBox();
            this.Label156 = new DataDynamics.ActiveReports.Label();
            this.Label157 = new DataDynamics.ActiveReports.Label();
            this.Label158 = new DataDynamics.ActiveReports.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label113)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label125)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label142)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label143)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label144)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label129)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label122)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label128)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label145)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label146)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label148)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label149)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label150)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label151)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label152)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaskControlID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRegCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label153)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label154)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNetPrem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label155)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label147)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label156)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label157)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label158)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.txtTaskControlID,
                        this.TxtRegCode,
                        this.txtCustomerName,
                        this.txtEffectiveDate,
                        this.txtEntryDate,
                        this.TextBox22,
                        this.txtTotalPremium,
                        this.TextBox20,
                        this.TextBox49,
                        this.TextBox50,
                        this.TextBox46,
                        this.TextBox47,
                        this.TextBox51,
                        this.TextBox52,
                        this.TextBox53,
                        this.TextBox54,
                        this.TextBox55,
                        this.TextBox56,
                        this.TextBox61,
                        this.TextBox62});
            this.Detail.Height = 0.2708333F;
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
                        this.TextBox37,
                        this.TextBox18,
                        this.TextBox21,
                        this.Line9,
                        this.TextBox19,
                        this.Label147,
                        this.TextBox63,
                        this.TextBox64,
                        this.TextBox65,
                        this.TextBox66,
                        this.Label156,
                        this.Label157,
                        this.Label158});
            this.ReportFooter.Height = 0.4493056F;
            this.ReportFooter.Name = "ReportFooter";
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
                        this.Label113,
                        this.Label125,
                        this.Label142,
                        this.Label143,
                        this.Label144,
                        this.Label129,
                        this.Label122,
                        this.Label128,
                        this.Label145,
                        this.Label146,
                        this.Label148,
                        this.Label149,
                        this.Label150,
                        this.Label151,
                        this.Label152,
                        this.Label75,
                        this.Label77});
            this.PageHeader.Height = 1F;
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
                        this.Label130,
                        this.Label131,
                        this.Label132});
            this.GroupHeader1.DataField = "CompanyDealer";
            this.GroupHeader1.Height = 0.25F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Label134,
                        this.Label135,
                        this.TextBox25,
                        this.TextBox36,
                        this.TextBox24,
                        this.TextBox48,
                        this.TextBox57,
                        this.TextBox58,
                        this.Label153,
                        this.Label154,
                        this.TxtNetPrem,
                        this.Label155,
                        this.TextBox60});
            this.GroupFooter1.Height = 0.4493056F;
            this.GroupFooter1.Name = "GroupFooter1";
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
            this.lblCriterias.Left = 4.0625F;
            this.lblCriterias.MultiLine = false;
            this.lblCriterias.Name = "lblCriterias";
            this.lblCriterias.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.lblCriterias.Text = "Auto Guard Certificate Outstanding";
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
            this.Label80.Left = 10.875F;
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
            this.TextBox17.Left = 11.375F;
            this.TextBox17.MultiLine = false;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat");
            this.TextBox17.Style = "text-align: right; font-size: 8pt; vertical-align: top; ";
            this.TextBox17.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox17.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
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
            this.Shape3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(227)))), ((int)(((byte)(234)))));
            this.Shape3.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.RightColor = System.Drawing.Color.Black;
            this.Shape3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.TopColor = System.Drawing.Color.Black;
            this.Shape3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Height = 0.313F;
            this.Shape3.Left = 0.125F;
            this.Shape3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Shape3.Name = "Shape3";
            this.Shape3.RoundingRadius = 9.999999F;
            this.Shape3.Top = 0.6875F;
            this.Shape3.Width = 13.3125F;
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
            this.Label107.Left = 0.25F;
            this.Label107.Name = "Label107";
            this.Label107.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label107.Text = "Task Control ID";
            this.Label107.Top = 0.6875F;
            this.Label107.Width = 0.875F;
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
            this.Label108.Left = 1.1875F;
            this.Label108.Name = "Label108";
            this.Label108.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label108.Text = "PolicyNo.";
            this.Label108.Top = 0.6875F;
            this.Label108.Width = 1F;
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
            this.Label109.Left = 5.75F;
            this.Label109.Name = "Label109";
            this.Label109.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label109.Text = "Entry Date";
            this.Label109.Top = 0.8125F;
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
            this.Label113.Left = 2.25F;
            this.Label113.Name = "Label113";
            this.Label113.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label113.Text = "Customer Name";
            this.Label113.Top = 0.6875F;
            this.Label113.Width = 1.375F;
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
            this.Label125.Left = 5.75F;
            this.Label125.Name = "Label125";
            this.Label125.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label125.Text = "Effec. Date";
            this.Label125.Top = 0.6875F;
            this.Label125.Width = 0.6875F;
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
            this.Label142.Left = 4.1875F;
            this.Label142.Name = "Label142";
            this.Label142.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label142.Text = "Bank";
            this.Label142.Top = 0.6875F;
            this.Label142.Width = 0.4375F;
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
            this.Label143.Left = 4.1875F;
            this.Label143.Name = "Label143";
            this.Label143.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label143.Text = "Ins.Co.";
            this.Label143.Top = 0.8125F;
            this.Label143.Width = 0.4375F;
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
            this.Label144.Left = 4.9375F;
            this.Label144.Name = "Label144";
            this.Label144.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label144.Text = "Agent";
            this.Label144.Top = 0.6875F;
            this.Label144.Width = 0.4375F;
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
            this.Label129.Left = 6.625F;
            this.Label129.Name = "Label129";
            this.Label129.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; vertica" +
                "l-align: top; ";
            this.Label129.Text = "Canc. Entry";
            this.Label129.Top = 0.8125F;
            this.Label129.Width = 0.6875F;
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
            this.Label122.Left = 8.5F;
            this.Label122.Name = "Label122";
            this.Label122.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label122.Text = "Premium";
            this.Label122.Top = 0.6875F;
            this.Label122.Width = 0.6875F;
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
            this.Label128.Left = 8.4375F;
            this.Label128.MultiLine = false;
            this.Label128.Name = "Label128";
            this.Label128.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label128.Text = "Canc. Amount";
            this.Label128.Top = 0.8125F;
            this.Label128.Width = 0.8125F;
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
            this.Label145.Left = 11.125F;
            this.Label145.MultiLine = false;
            this.Label145.Name = "Label145";
            this.Label145.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label145.Text = "Canc. Reason";
            this.Label145.Top = 0.6875F;
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
            this.Label146.Left = 7.5625F;
            this.Label146.Name = "Label146";
            this.Label146.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; vertica" +
                "l-align: top; ";
            this.Label146.Text = "Paid Entry";
            this.Label146.Top = 0.6875F;
            this.Label146.Width = 0.6875F;
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
            this.Label148.Left = 4.8125F;
            this.Label148.Name = "Label148";
            this.Label148.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label148.Text = "Co. Dealer";
            this.Label148.Top = 0.8125F;
            this.Label148.Width = 0.75F;
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
            this.Label149.Left = 6.625F;
            this.Label149.Name = "Label149";
            this.Label149.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label149.Text = "Exp. Date";
            this.Label149.Top = 0.6875F;
            this.Label149.Width = 0.6875F;
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
            this.Label150.Left = 9.375F;
            this.Label150.Name = "Label150";
            this.Label150.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label150.Text = "Rate %";
            this.Label150.Top = 0.6875F;
            this.Label150.Width = 0.625F;
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
            this.Label151.Left = 10.125F;
            this.Label151.Name = "Label151";
            this.Label151.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label151.Text = "Comm. Amt.";
            this.Label151.Top = 0.6875F;
            this.Label151.Width = 0.8125F;
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
            this.Label152.Left = 10.125F;
            this.Label152.Name = "Label152";
            this.Label152.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label152.Text = "Cancel Amt.";
            this.Label152.Top = 0.8125F;
            this.Label152.Width = 0.8125F;
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
            this.Label75.Left = 4.067708F;
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
            this.Label77.Left = 4.067708F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-align: center; font-weight: bold; font-size: 6pt; font-family: Times New Rom" +
                "an; ";
            this.Label77.Text = "P.O. Box 195585 San Juan Puerto Rico, PR  00919-5585 Tel (787) 763-4010 Fax (787)" +
                " 763-3525";
            this.Label77.Top = 0.25F;
            this.Label77.Width = 5.125F;
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
            this.Label130.Left = 0.2083333F;
            this.Label130.Name = "Label130";
            this.Label130.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label130.Text = "Company Dealer:";
            this.Label130.Top = 0F;
            this.Label130.Width = 1F;
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
            this.Label131.DataField = "CompanyDealer";
            this.Label131.Height = 0.2F;
            this.Label131.HyperLink = "";
            this.Label131.Left = 1.25F;
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
            this.Label132.DataField = "CompanyDealerDesc";
            this.Label132.Height = 0.2F;
            this.Label132.HyperLink = "";
            this.Label132.Left = 1.75F;
            this.Label132.Name = "Label132";
            this.Label132.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label132.Text = "";
            this.Label132.Top = 0F;
            this.Label132.Width = 2.5625F;
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
            this.txtTaskControlID.Left = 0.3229166F;
            this.txtTaskControlID.Name = "txtTaskControlID";
            this.txtTaskControlID.Style = "text-align: left; font-size: 7pt; ";
            this.txtTaskControlID.Top = 0F;
            this.txtTaskControlID.Width = 0.75F;
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
            this.TxtRegCode.DataField = "PolicyNumber";
            this.TxtRegCode.Height = 0.125F;
            this.TxtRegCode.Left = 1.25F;
            this.TxtRegCode.Name = "TxtRegCode";
            this.TxtRegCode.Style = "text-align: left; font-size: 7pt; ";
            this.TxtRegCode.Top = 0F;
            this.TxtRegCode.Width = 0.9375F;
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
            this.txtCustomerName.Left = 2.239583F;
            this.txtCustomerName.MultiLine = false;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Style = "text-align: left; font-size: 7pt; ";
            this.txtCustomerName.Top = 0F;
            this.txtCustomerName.Width = 1.822917F;
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
            this.txtEffectiveDate.Left = 5.8125F;
            this.txtEffectiveDate.Name = "txtEffectiveDate";
            this.txtEffectiveDate.OutputFormat = resources.GetString("txtEffectiveDate.OutputFormat");
            this.txtEffectiveDate.Style = "text-align: left; font-size: 7pt; ";
            this.txtEffectiveDate.Top = 0F;
            this.txtEffectiveDate.Width = 0.625F;
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
            this.txtEntryDate.Left = 5.8125F;
            this.txtEntryDate.Name = "txtEntryDate";
            this.txtEntryDate.OutputFormat = resources.GetString("txtEntryDate.OutputFormat");
            this.txtEntryDate.Style = "text-align: left; font-size: 7pt; ";
            this.txtEntryDate.Top = 0.125F;
            this.txtEntryDate.Width = 0.625F;
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
            this.TextBox22.DataField = "CancellationEntryDate";
            this.TextBox22.Height = 0.125F;
            this.TextBox22.Left = 6.625F;
            this.TextBox22.Name = "TextBox22";
            this.TextBox22.OutputFormat = resources.GetString("TextBox22.OutputFormat");
            this.TextBox22.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox22.Top = 0.125F;
            this.TextBox22.Width = 0.625F;
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
            this.txtTotalPremium.Left = 8.4375F;
            this.txtTotalPremium.Name = "txtTotalPremium";
            this.txtTotalPremium.OutputFormat = resources.GetString("txtTotalPremium.OutputFormat");
            this.txtTotalPremium.Style = "text-align: right; font-size: 7pt; ";
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
            this.TextBox20.Left = 8.4375F;
            this.TextBox20.Name = "TextBox20";
            this.TextBox20.OutputFormat = resources.GetString("TextBox20.OutputFormat");
            this.TextBox20.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox20.Top = 0.125F;
            this.TextBox20.Width = 0.6979167F;
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
            this.TextBox49.DataField = "CancellationReasonDesc";
            this.TextBox49.Height = 0.125F;
            this.TextBox49.Left = 11.11458F;
            this.TextBox49.MultiLine = false;
            this.TextBox49.Name = "TextBox49";
            this.TextBox49.OutputFormat = resources.GetString("TextBox49.OutputFormat");
            this.TextBox49.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox49.Top = 0F;
            this.TextBox49.Width = 1.197917F;
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
            this.TextBox50.DataField = "CommissionDate";
            this.TextBox50.Height = 0.125F;
            this.TextBox50.Left = 7.625F;
            this.TextBox50.Name = "TextBox50";
            this.TextBox50.OutputFormat = resources.GetString("TextBox50.OutputFormat");
            this.TextBox50.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox50.Top = 0F;
            this.TextBox50.Width = 0.5625F;
            // 
            // TextBox46
            // 
            this.TextBox46.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox46.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox46.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox46.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox46.DataField = "Bank";
            this.TextBox46.Height = 0.125F;
            this.TextBox46.Left = 4.25F;
            this.TextBox46.Name = "TextBox46";
            this.TextBox46.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox46.Top = 0F;
            this.TextBox46.Width = 0.3125F;
            // 
            // TextBox47
            // 
            this.TextBox47.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox47.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox47.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox47.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox47.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox47.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox47.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox47.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox47.DataField = "InsuranceCompany";
            this.TextBox47.Height = 0.125F;
            this.TextBox47.Left = 4.25F;
            this.TextBox47.Name = "TextBox47";
            this.TextBox47.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox47.Top = 0.125F;
            this.TextBox47.Width = 0.3125F;
            // 
            // TextBox51
            // 
            this.TextBox51.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox51.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox51.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox51.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox51.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox51.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox51.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox51.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox51.DataField = "Agent";
            this.TextBox51.Height = 0.125F;
            this.TextBox51.Left = 4.947917F;
            this.TextBox51.Name = "TextBox51";
            this.TextBox51.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox51.Top = 0F;
            this.TextBox51.Width = 0.375F;
            // 
            // TextBox52
            // 
            this.TextBox52.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox52.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox52.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox52.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox52.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox52.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox52.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox52.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox52.DataField = "CompanyDealer";
            this.TextBox52.Height = 0.125F;
            this.TextBox52.Left = 4.947917F;
            this.TextBox52.Name = "TextBox52";
            this.TextBox52.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox52.Top = 0.125F;
            this.TextBox52.Width = 0.375F;
            // 
            // TextBox53
            // 
            this.TextBox53.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox53.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox53.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox53.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox53.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox53.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox53.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox53.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox53.DataField = "ExpirationDate";
            this.TextBox53.Height = 0.125F;
            this.TextBox53.Left = 6.625F;
            this.TextBox53.Name = "TextBox53";
            this.TextBox53.OutputFormat = resources.GetString("TextBox53.OutputFormat");
            this.TextBox53.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox53.Top = 0F;
            this.TextBox53.Width = 0.625F;
            // 
            // TextBox54
            // 
            this.TextBox54.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox54.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox54.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox54.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox54.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox54.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox54.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox54.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox54.DataField = "commissionAgentPercent";
            this.TextBox54.Height = 0.125F;
            this.TextBox54.Left = 9.4375F;
            this.TextBox54.Name = "TextBox54";
            this.TextBox54.OutputFormat = resources.GetString("TextBox54.OutputFormat");
            this.TextBox54.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox54.Top = 0F;
            this.TextBox54.Width = 0.5625F;
            // 
            // TextBox55
            // 
            this.TextBox55.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox55.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox55.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox55.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox55.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox55.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox55.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox55.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox55.DataField = "CommissionAgent";
            this.TextBox55.Height = 0.125F;
            this.TextBox55.Left = 10.1875F;
            this.TextBox55.Name = "TextBox55";
            this.TextBox55.OutputFormat = resources.GetString("TextBox55.OutputFormat");
            this.TextBox55.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox55.Top = 0F;
            this.TextBox55.Width = 0.6979167F;
            // 
            // TextBox56
            // 
            this.TextBox56.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox56.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox56.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox56.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox56.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox56.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox56.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox56.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox56.DataField = "ReturnCommissionAgent";
            this.TextBox56.Height = 0.125F;
            this.TextBox56.Left = 10.1875F;
            this.TextBox56.Name = "TextBox56";
            this.TextBox56.OutputFormat = resources.GetString("TextBox56.OutputFormat");
            this.TextBox56.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox56.Top = 0.125F;
            this.TextBox56.Width = 0.6979167F;
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
            this.TextBox61.Left = 8.5625F;
            this.TextBox61.Name = "TextBox61";
            this.TextBox61.OutputFormat = resources.GetString("TextBox61.OutputFormat");
            this.TextBox61.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox61.Text = "PremNet";
            this.TextBox61.Top = 0.0625F;
            this.TextBox61.Visible = false;
            this.TextBox61.Width = 0.6979167F;
            // 
            // TextBox62
            // 
            this.TextBox62.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox62.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox62.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox62.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox62.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox62.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox62.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox62.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox62.DataField = "CommNet";
            this.TextBox62.Height = 0.125F;
            this.TextBox62.Left = 10.3125F;
            this.TextBox62.Name = "TextBox62";
            this.TextBox62.OutputFormat = resources.GetString("TextBox62.OutputFormat");
            this.TextBox62.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox62.Text = "PremNet";
            this.TextBox62.Top = 0.0625F;
            this.TextBox62.Visible = false;
            this.TextBox62.Width = 0.6979167F;
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
            this.Label134.Height = 0.2F;
            this.Label134.HyperLink = "";
            this.Label134.Left = 0.375F;
            this.Label134.Name = "Label134";
            this.Label134.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label134.Text = "Total for Company Dealer:";
            this.Label134.Top = 0F;
            this.Label134.Width = 1.4375F;
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
            this.Label135.DataField = "CompanyDealer";
            this.Label135.Height = 0.2F;
            this.Label135.HyperLink = "";
            this.Label135.Left = 1.9375F;
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
            this.TextBox25.Left = 2.489583F;
            this.TextBox25.Name = "TextBox25";
            this.TextBox25.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox25.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox25.SummaryGroup = "GroupHeader1";
            this.TextBox25.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox25.Top = 0F;
            this.TextBox25.Width = 0.8958333F;
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
            this.TextBox36.DataField = "CancellationEntryDate";
            this.TextBox36.Height = 0.1875F;
            this.TextBox36.Left = 7.5F;
            this.TextBox36.Name = "TextBox36";
            this.TextBox36.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox36.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox36.SummaryGroup = "GroupHeader1";
            this.TextBox36.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox36.Top = 0F;
            this.TextBox36.Width = 0.625F;
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
            this.TextBox24.Left = 8.4375F;
            this.TextBox24.Name = "TextBox24";
            this.TextBox24.OutputFormat = resources.GetString("TextBox24.OutputFormat");
            this.TextBox24.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox24.SummaryGroup = "GroupHeader1";
            this.TextBox24.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox24.Top = 0F;
            this.TextBox24.Width = 0.6875F;
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
            this.TextBox48.DataField = "CancellationAmount";
            this.TextBox48.Height = 0.1875F;
            this.TextBox48.Left = 8.4375F;
            this.TextBox48.Name = "TextBox48";
            this.TextBox48.OutputFormat = resources.GetString("TextBox48.OutputFormat");
            this.TextBox48.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox48.SummaryGroup = "GroupHeader1";
            this.TextBox48.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox48.Top = 0.125F;
            this.TextBox48.Width = 0.6875F;
            // 
            // TextBox57
            // 
            this.TextBox57.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox57.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox57.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox57.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox57.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox57.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox57.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox57.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox57.DataField = "CommissionAgent";
            this.TextBox57.Height = 0.1875F;
            this.TextBox57.Left = 10.1875F;
            this.TextBox57.Name = "TextBox57";
            this.TextBox57.OutputFormat = resources.GetString("TextBox57.OutputFormat");
            this.TextBox57.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox57.SummaryGroup = "GroupHeader1";
            this.TextBox57.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox57.Top = 0F;
            this.TextBox57.Width = 0.6875F;
            // 
            // TextBox58
            // 
            this.TextBox58.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox58.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox58.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox58.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox58.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox58.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox58.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox58.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox58.DataField = "ReturnCommissionAgent";
            this.TextBox58.Height = 0.1875F;
            this.TextBox58.Left = 10.1875F;
            this.TextBox58.Name = "TextBox58";
            this.TextBox58.OutputFormat = resources.GetString("TextBox58.OutputFormat");
            this.TextBox58.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox58.SummaryGroup = "GroupHeader1";
            this.TextBox58.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox58.Top = 0.125F;
            this.TextBox58.Width = 0.6875F;
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
            this.Label153.Height = 0.2F;
            this.Label153.HyperLink = "";
            this.Label153.Left = 6.5F;
            this.Label153.Name = "Label153";
            this.Label153.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label153.Text = "New Contracts";
            this.Label153.Top = 0F;
            this.Label153.Width = 0.9375F;
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
            this.Label154.Height = 0.2F;
            this.Label154.HyperLink = "";
            this.Label154.Left = 6.5F;
            this.Label154.Name = "Label154";
            this.Label154.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label154.Text = "Cancellations";
            this.Label154.Top = 0.125F;
            this.Label154.Width = 0.9375F;
            // 
            // TxtNetPrem
            // 
            this.TxtNetPrem.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtNetPrem.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtNetPrem.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtNetPrem.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtNetPrem.Border.RightColor = System.Drawing.Color.Black;
            this.TxtNetPrem.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtNetPrem.Border.TopColor = System.Drawing.Color.Black;
            this.TxtNetPrem.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtNetPrem.DataField = "PremNet";
            this.TxtNetPrem.Height = 0.1875F;
            this.TxtNetPrem.Left = 8.4375F;
            this.TxtNetPrem.Name = "TxtNetPrem";
            this.TxtNetPrem.OutputFormat = resources.GetString("TxtNetPrem.OutputFormat");
            this.TxtNetPrem.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TxtNetPrem.SummaryGroup = "GroupHeader1";
            this.TxtNetPrem.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TxtNetPrem.Top = 0.25F;
            this.TxtNetPrem.Width = 0.6875F;
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
            this.Label155.Height = 0.2F;
            this.Label155.HyperLink = "";
            this.Label155.Left = 6.5F;
            this.Label155.Name = "Label155";
            this.Label155.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label155.Text = "Net >>>>>>>";
            this.Label155.Top = 0.25F;
            this.Label155.Width = 0.9375F;
            // 
            // TextBox60
            // 
            this.TextBox60.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox60.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox60.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox60.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox60.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox60.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox60.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox60.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox60.DataField = "CommNet";
            this.TextBox60.Height = 0.1875F;
            this.TextBox60.Left = 10.1875F;
            this.TextBox60.Name = "TextBox60";
            this.TextBox60.OutputFormat = resources.GetString("TextBox60.OutputFormat");
            this.TextBox60.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox60.SummaryGroup = "GroupHeader1";
            this.TextBox60.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox60.Top = 0.25F;
            this.TextBox60.Width = 0.6875F;
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
            this.TextBox37.DataField = "CancellationEntryDate";
            this.TextBox37.Height = 0.1875F;
            this.TextBox37.Left = 7.5F;
            this.TextBox37.Name = "TextBox37";
            this.TextBox37.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox37.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox37.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox37.Top = 0F;
            this.TextBox37.Width = 0.6979167F;
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
            this.TextBox18.Left = 8.4375F;
            this.TextBox18.Name = "TextBox18";
            this.TextBox18.OutputFormat = resources.GetString("TextBox18.OutputFormat");
            this.TextBox18.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: Arial; ";
            this.TextBox18.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox18.Top = 0F;
            this.TextBox18.Width = 0.6875F;
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
            this.TextBox21.Left = 8.4375F;
            this.TextBox21.Name = "TextBox21";
            this.TextBox21.OutputFormat = resources.GetString("TextBox21.OutputFormat");
            this.TextBox21.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: Arial; ";
            this.TextBox21.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox21.Top = 0.125F;
            this.TextBox21.Width = 0.6875F;
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
            this.Line9.Width = 12.97917F;
            this.Line9.X1 = 0.3958333F;
            this.Line9.X2 = 13.375F;
            this.Line9.Y1 = 0F;
            this.Line9.Y2 = 0F;
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
            this.TextBox19.Top = 0F;
            this.TextBox19.Width = 0.75F;
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
            this.Label147.Left = 0.4375F;
            this.Label147.Name = "Label147";
            this.Label147.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label147.Text = "Grand Total:";
            this.Label147.Top = 0F;
            this.Label147.Width = 1F;
            // 
            // TextBox63
            // 
            this.TextBox63.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox63.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox63.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox63.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox63.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox63.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox63.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox63.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox63.DataField = "PremNet";
            this.TextBox63.Height = 0.1875F;
            this.TextBox63.Left = 8.4375F;
            this.TextBox63.Name = "TextBox63";
            this.TextBox63.OutputFormat = resources.GetString("TextBox63.OutputFormat");
            this.TextBox63.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox63.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox63.Top = 0.25F;
            this.TextBox63.Width = 0.6875F;
            // 
            // TextBox64
            // 
            this.TextBox64.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox64.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox64.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox64.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox64.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox64.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox64.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox64.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox64.DataField = "CommissionAgent";
            this.TextBox64.Height = 0.1875F;
            this.TextBox64.Left = 10.1875F;
            this.TextBox64.Name = "TextBox64";
            this.TextBox64.OutputFormat = resources.GetString("TextBox64.OutputFormat");
            this.TextBox64.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox64.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox64.Top = 0F;
            this.TextBox64.Width = 0.6875F;
            // 
            // TextBox65
            // 
            this.TextBox65.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox65.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox65.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox65.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox65.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox65.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox65.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox65.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox65.DataField = "ReturnCommissionAgent";
            this.TextBox65.Height = 0.1875F;
            this.TextBox65.Left = 10.1875F;
            this.TextBox65.Name = "TextBox65";
            this.TextBox65.OutputFormat = resources.GetString("TextBox65.OutputFormat");
            this.TextBox65.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox65.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox65.Top = 0.125F;
            this.TextBox65.Width = 0.6875F;
            // 
            // TextBox66
            // 
            this.TextBox66.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox66.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox66.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox66.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox66.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox66.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox66.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox66.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox66.DataField = "CommNet";
            this.TextBox66.Height = 0.1875F;
            this.TextBox66.Left = 10.1875F;
            this.TextBox66.Name = "TextBox66";
            this.TextBox66.OutputFormat = resources.GetString("TextBox66.OutputFormat");
            this.TextBox66.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox66.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox66.Top = 0.25F;
            this.TextBox66.Width = 0.6875F;
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
            this.Label156.Height = 0.2F;
            this.Label156.HyperLink = "";
            this.Label156.Left = 6.5F;
            this.Label156.Name = "Label156";
            this.Label156.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label156.Text = "New Contracts";
            this.Label156.Top = 0F;
            this.Label156.Width = 0.9375F;
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
            this.Label157.Height = 0.2F;
            this.Label157.HyperLink = "";
            this.Label157.Left = 6.5F;
            this.Label157.Name = "Label157";
            this.Label157.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label157.Text = "Cancellations";
            this.Label157.Top = 0.125F;
            this.Label157.Width = 0.9375F;
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
            this.Label158.Height = 0.2F;
            this.Label158.HyperLink = "";
            this.Label158.Left = 6.5F;
            this.Label158.Name = "Label158";
            this.Label158.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label158.Text = "Net >>>>>>>";
            this.Label158.Top = 0.25F;
            this.Label158.Width = 0.9375F;
            // 
            // ActiveReport31
            // 
            this.PageSettings.Margins.Bottom = 0.1F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0.3F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 13.51042F;
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
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label113)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label125)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label142)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label143)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label144)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label129)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label122)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label128)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label145)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label146)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label148)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label149)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label150)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label151)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label152)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaskControlID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRegCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label153)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label154)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNetPrem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label155)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label147)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label156)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label157)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label158)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }

		#endregion
	}
}
