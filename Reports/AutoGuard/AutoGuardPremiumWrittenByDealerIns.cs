using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.AutoGuard
{
	public class AutoGuardPremiumWrittenByDealerIns : DataDynamics.ActiveReports.ActiveReport3
	{
		string _FromDate;
		string _ToDate;
		string _ReportType;
		bool   _Summary = false;
        string _mHeadCompany;

        public AutoGuardPremiumWrittenByDealerIns(string FromDate, string ToDate, string ReportType, bool Summary, string mHeadCompany)
		{
			_FromDate = FromDate;
			_ToDate = ToDate;
			_ReportType = ReportType;
			_Summary  =  Summary;
            _mHeadCompany = mHeadCompany;
             

			InitializeComponent();
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void AutoGuardPremiumWrittenByDealerIns_ReportStart(object sender, System.EventArgs eArgs)
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
		private DataDynamics.ActiveReports.Label Label115 = null;
		private DataDynamics.ActiveReports.Label Label116 = null;
		private DataDynamics.ActiveReports.Label Label118 = null;
		private DataDynamics.ActiveReports.Label Label120 = null;
		private DataDynamics.ActiveReports.Label Label122 = null;
		private DataDynamics.ActiveReports.Label Label124 = null;
		private DataDynamics.ActiveReports.Label Label125 = null;
		private DataDynamics.ActiveReports.Label Label128 = null;
		private DataDynamics.ActiveReports.Label Label129 = null;
		private DataDynamics.ActiveReports.Label Label113 = null;
		private DataDynamics.ActiveReports.Label Label135 = null;
		private DataDynamics.ActiveReports.Label Label75 = null;
		private DataDynamics.ActiveReports.Label Label77 = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader1 = null;
		private DataDynamics.ActiveReports.Label Label130 = null;
		private DataDynamics.ActiveReports.Label Label131 = null;
		private DataDynamics.ActiveReports.Label Label132 = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader2 = null;
		private DataDynamics.ActiveReports.Label Label159 = null;
		private DataDynamics.ActiveReports.Label Label160 = null;
		private DataDynamics.ActiveReports.Label Label161 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox txtTaskControlID = null;
		private DataDynamics.ActiveReports.TextBox TxtRegCode = null;
		private DataDynamics.ActiveReports.TextBox txtCustomerNo = null;
		private DataDynamics.ActiveReports.TextBox txtEntryDate = null;
		private DataDynamics.ActiveReports.TextBox txtEffectiveDate = null;
		private DataDynamics.ActiveReports.TextBox txtTerm = null;
		private DataDynamics.ActiveReports.TextBox txtMake = null;
		private DataDynamics.ActiveReports.TextBox txtModel = null;
		private DataDynamics.ActiveReports.TextBox txtYear = null;
		private DataDynamics.ActiveReports.TextBox txtVin = null;
		private DataDynamics.ActiveReports.TextBox txtTotalPremium = null;
		private DataDynamics.ActiveReports.TextBox TextBox20 = null;
		private DataDynamics.ActiveReports.TextBox TextBox22 = null;
		private DataDynamics.ActiveReports.TextBox TextBox38 = null;
		private DataDynamics.ActiveReports.TextBox TextBox70 = null;
		private DataDynamics.ActiveReports.TextBox TextBox39 = null;
		private DataDynamics.ActiveReports.TextBox TextBox61 = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter2 = null;
		private DataDynamics.ActiveReports.Label Label162 = null;
		private DataDynamics.ActiveReports.Label Label163 = null;
		private DataDynamics.ActiveReports.TextBox TextBox69 = null;
		private DataDynamics.ActiveReports.TextBox TextBox24 = null;
		private DataDynamics.ActiveReports.TextBox TextBox41 = null;
		private DataDynamics.ActiveReports.Label Label164 = null;
		private DataDynamics.ActiveReports.Label Label165 = null;
		private DataDynamics.ActiveReports.Label Label166 = null;
		private DataDynamics.ActiveReports.TextBox TextBox71 = null;
		private DataDynamics.ActiveReports.TextBox TextBox74 = null;
		private DataDynamics.ActiveReports.TextBox TextBox76 = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1 = null;
		private DataDynamics.ActiveReports.Label Label133 = null;
		private DataDynamics.ActiveReports.Label Label134 = null;
		private DataDynamics.ActiveReports.TextBox TextBox23 = null;
		private DataDynamics.ActiveReports.TextBox TextBox77 = null;
		private DataDynamics.ActiveReports.TextBox TextBox79 = null;
		private DataDynamics.ActiveReports.Label Label167 = null;
		private DataDynamics.ActiveReports.Label Label168 = null;
		private DataDynamics.ActiveReports.Label Label169 = null;
		private DataDynamics.ActiveReports.TextBox TextBox80 = null;
		private DataDynamics.ActiveReports.TextBox TextBox81 = null;
		private DataDynamics.ActiveReports.TextBox TextBox82 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		private DataDynamics.ActiveReports.TextBox TextBox19 = null;
		private DataDynamics.ActiveReports.Label Label127 = null;
		private DataDynamics.ActiveReports.Line Line9 = null;
		private DataDynamics.ActiveReports.TextBox TextBox18 = null;
		private DataDynamics.ActiveReports.TextBox TextBox21 = null;
		private DataDynamics.ActiveReports.Label Label170 = null;
		private DataDynamics.ActiveReports.Label Label171 = null;
		private DataDynamics.ActiveReports.Label Label172 = null;
		private DataDynamics.ActiveReports.TextBox TextBox37 = null;
		private DataDynamics.ActiveReports.TextBox TextBox68 = null;
		private DataDynamics.ActiveReports.TextBox TextBox83 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoGuardPremiumWrittenByDealerIns));
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
            this.Label80 = new DataDynamics.ActiveReports.Label();
            this.TextBox17 = new DataDynamics.ActiveReports.TextBox();
            this.lblDate = new DataDynamics.ActiveReports.Label();
            this.lblTime = new DataDynamics.ActiveReports.Label();
            this.Shape3 = new DataDynamics.ActiveReports.Shape();
            this.Label107 = new DataDynamics.ActiveReports.Label();
            this.Label108 = new DataDynamics.ActiveReports.Label();
            this.Label109 = new DataDynamics.ActiveReports.Label();
            this.Label115 = new DataDynamics.ActiveReports.Label();
            this.Label116 = new DataDynamics.ActiveReports.Label();
            this.Label118 = new DataDynamics.ActiveReports.Label();
            this.Label120 = new DataDynamics.ActiveReports.Label();
            this.Label122 = new DataDynamics.ActiveReports.Label();
            this.Label124 = new DataDynamics.ActiveReports.Label();
            this.Label125 = new DataDynamics.ActiveReports.Label();
            this.Label128 = new DataDynamics.ActiveReports.Label();
            this.Label129 = new DataDynamics.ActiveReports.Label();
            this.Label113 = new DataDynamics.ActiveReports.Label();
            this.Label135 = new DataDynamics.ActiveReports.Label();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.Label130 = new DataDynamics.ActiveReports.Label();
            this.Label131 = new DataDynamics.ActiveReports.Label();
            this.Label132 = new DataDynamics.ActiveReports.Label();
            this.Label159 = new DataDynamics.ActiveReports.Label();
            this.Label160 = new DataDynamics.ActiveReports.Label();
            this.Label161 = new DataDynamics.ActiveReports.Label();
            this.txtTaskControlID = new DataDynamics.ActiveReports.TextBox();
            this.TxtRegCode = new DataDynamics.ActiveReports.TextBox();
            this.txtCustomerNo = new DataDynamics.ActiveReports.TextBox();
            this.txtEntryDate = new DataDynamics.ActiveReports.TextBox();
            this.txtEffectiveDate = new DataDynamics.ActiveReports.TextBox();
            this.txtTerm = new DataDynamics.ActiveReports.TextBox();
            this.txtMake = new DataDynamics.ActiveReports.TextBox();
            this.txtModel = new DataDynamics.ActiveReports.TextBox();
            this.txtYear = new DataDynamics.ActiveReports.TextBox();
            this.txtVin = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalPremium = new DataDynamics.ActiveReports.TextBox();
            this.TextBox20 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox22 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox38 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox70 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox39 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox61 = new DataDynamics.ActiveReports.TextBox();
            this.Label162 = new DataDynamics.ActiveReports.Label();
            this.Label163 = new DataDynamics.ActiveReports.Label();
            this.TextBox69 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox24 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox41 = new DataDynamics.ActiveReports.TextBox();
            this.Label164 = new DataDynamics.ActiveReports.Label();
            this.Label165 = new DataDynamics.ActiveReports.Label();
            this.Label166 = new DataDynamics.ActiveReports.Label();
            this.TextBox71 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox74 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox76 = new DataDynamics.ActiveReports.TextBox();
            this.Label133 = new DataDynamics.ActiveReports.Label();
            this.Label134 = new DataDynamics.ActiveReports.Label();
            this.TextBox23 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox77 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox79 = new DataDynamics.ActiveReports.TextBox();
            this.Label167 = new DataDynamics.ActiveReports.Label();
            this.Label168 = new DataDynamics.ActiveReports.Label();
            this.Label169 = new DataDynamics.ActiveReports.Label();
            this.TextBox80 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox81 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox82 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox19 = new DataDynamics.ActiveReports.TextBox();
            this.Label127 = new DataDynamics.ActiveReports.Label();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.TextBox18 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox21 = new DataDynamics.ActiveReports.TextBox();
            this.Label170 = new DataDynamics.ActiveReports.Label();
            this.Label171 = new DataDynamics.ActiveReports.Label();
            this.Label172 = new DataDynamics.ActiveReports.Label();
            this.TextBox37 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox68 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox83 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label115)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label116)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label118)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label120)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label122)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label124)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label125)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label128)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label129)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label113)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label159)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label160)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label161)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaskControlID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRegCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTerm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label162)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label163)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox69)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label164)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label165)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label166)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox74)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox76)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox79)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label167)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label168)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label169)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox81)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox82)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label127)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label170)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label171)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label172)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox68)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox83)).BeginInit();
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
                        this.txtTerm,
                        this.txtMake,
                        this.txtModel,
                        this.txtYear,
                        this.txtVin,
                        this.txtTotalPremium,
                        this.TextBox20,
                        this.TextBox22,
                        this.TextBox38,
                        this.TextBox70,
                        this.TextBox39,
                        this.TextBox61});
            this.Detail.Height = 0.3125F;
            this.Detail.KeepTogether = true;
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
                        this.TextBox19,
                        this.Label127,
                        this.Line9,
                        this.TextBox18,
                        this.TextBox21,
                        this.Label170,
                        this.Label171,
                        this.Label172,
                        this.TextBox37,
                        this.TextBox68,
                        this.TextBox83});
            this.ReportFooter.Height = 0.5104167F;
            this.ReportFooter.KeepTogether = true;
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
                        this.Label115,
                        this.Label116,
                        this.Label118,
                        this.Label120,
                        this.Label122,
                        this.Label124,
                        this.Label125,
                        this.Label128,
                        this.Label129,
                        this.Label113,
                        this.Label135,
                        this.Label75,
                        this.Label77});
            this.PageHeader.Height = 1.197222F;
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
            this.GroupHeader1.Height = 0.2076389F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Label133,
                        this.Label134,
                        this.TextBox23,
                        this.TextBox77,
                        this.TextBox79,
                        this.Label167,
                        this.Label168,
                        this.Label169,
                        this.TextBox80,
                        this.TextBox81,
                        this.TextBox82});
            this.GroupFooter1.Height = 0.4784722F;
            this.GroupFooter1.KeepTogether = true;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Label159,
                        this.Label160,
                        this.Label161});
            this.GroupHeader2.DataField = "InsuranceCompany";
            this.GroupHeader2.Height = 0.1979167F;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Label162,
                        this.Label163,
                        this.TextBox69,
                        this.TextBox24,
                        this.TextBox41,
                        this.Label164,
                        this.Label165,
                        this.Label166,
                        this.TextBox71,
                        this.TextBox74,
                        this.TextBox76});
            this.GroupFooter2.Height = 0.4895833F;
            this.GroupFooter2.KeepTogether = true;
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
            this.lblCriterias.Left = 4.5F;
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
            this.Label80.Left = 11.6875F;
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
            this.TextBox17.Left = 12.1875F;
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
            this.Shape3.Top = 0.875F;
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
            this.Label107.Top = 0.875F;
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
            this.Label108.Height = 0.1875F;
            this.Label108.HyperLink = "";
            this.Label108.Left = 1.1875F;
            this.Label108.Name = "Label108";
            this.Label108.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label108.Text = "PolicyNo.";
            this.Label108.Top = 0.875F;
            this.Label108.Width = 0.6875F;
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
            this.Label109.Left = 3.875F;
            this.Label109.Name = "Label109";
            this.Label109.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label109.Text = "Entry Date";
            this.Label109.Top = 0.875F;
            this.Label109.Width = 0.6875F;
            // 
            // Label115
            // 
            this.Label115.Border.BottomColor = System.Drawing.Color.Black;
            this.Label115.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label115.Border.LeftColor = System.Drawing.Color.Black;
            this.Label115.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label115.Border.RightColor = System.Drawing.Color.Black;
            this.Label115.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label115.Border.TopColor = System.Drawing.Color.Black;
            this.Label115.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label115.Height = 0.1875F;
            this.Label115.HyperLink = "";
            this.Label115.Left = 5.25F;
            this.Label115.Name = "Label115";
            this.Label115.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label115.Text = "Term";
            this.Label115.Top = 0.875F;
            this.Label115.Width = 0.5F;
            // 
            // Label116
            // 
            this.Label116.Border.BottomColor = System.Drawing.Color.Black;
            this.Label116.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label116.Border.LeftColor = System.Drawing.Color.Black;
            this.Label116.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label116.Border.RightColor = System.Drawing.Color.Black;
            this.Label116.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label116.Border.TopColor = System.Drawing.Color.Black;
            this.Label116.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label116.Height = 0.1875F;
            this.Label116.HyperLink = "";
            this.Label116.Left = 5.75F;
            this.Label116.Name = "Label116";
            this.Label116.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label116.Text = "Make";
            this.Label116.Top = 0.875F;
            this.Label116.Width = 0.625F;
            // 
            // Label118
            // 
            this.Label118.Border.BottomColor = System.Drawing.Color.Black;
            this.Label118.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label118.Border.LeftColor = System.Drawing.Color.Black;
            this.Label118.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label118.Border.RightColor = System.Drawing.Color.Black;
            this.Label118.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label118.Border.TopColor = System.Drawing.Color.Black;
            this.Label118.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label118.Height = 0.1875F;
            this.Label118.HyperLink = "";
            this.Label118.Left = 7.875F;
            this.Label118.Name = "Label118";
            this.Label118.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label118.Text = "Year";
            this.Label118.Top = 0.875F;
            this.Label118.Width = 0.3125F;
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
            this.Label120.Height = 0.1875F;
            this.Label120.HyperLink = "";
            this.Label120.Left = 8.25F;
            this.Label120.Name = "Label120";
            this.Label120.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label120.Text = "VIN";
            this.Label120.Top = 0.875F;
            this.Label120.Width = 0.9375F;
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
            this.Label122.Left = 11.75F;
            this.Label122.Name = "Label122";
            this.Label122.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label122.Text = "Premium";
            this.Label122.Top = 0.875F;
            this.Label122.Width = 0.6875F;
            // 
            // Label124
            // 
            this.Label124.Border.BottomColor = System.Drawing.Color.Black;
            this.Label124.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label124.Border.LeftColor = System.Drawing.Color.Black;
            this.Label124.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label124.Border.RightColor = System.Drawing.Color.Black;
            this.Label124.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label124.Border.TopColor = System.Drawing.Color.Black;
            this.Label124.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label124.Height = 0.1875F;
            this.Label124.HyperLink = "";
            this.Label124.Left = 6.8125F;
            this.Label124.Name = "Label124";
            this.Label124.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label124.Text = "Model";
            this.Label124.Top = 0.875F;
            this.Label124.Width = 0.75F;
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
            this.Label125.Left = 4.625F;
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
            this.Label128.Left = 11.75F;
            this.Label128.MultiLine = false;
            this.Label128.Name = "Label128";
            this.Label128.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label128.Text = "Canc. Amount";
            this.Label128.Top = 1F;
            this.Label128.Width = 0.8125F;
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
            this.Label129.Left = 10.8125F;
            this.Label129.Name = "Label129";
            this.Label129.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; vertica" +
                "l-align: top; ";
            this.Label129.Text = "Canc.Date";
            this.Label129.Top = 0.875F;
            this.Label129.Width = 0.6875F;
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
            this.Label113.Left = 2.3125F;
            this.Label113.Name = "Label113";
            this.Label113.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label113.Text = "Customer Name";
            this.Label113.Top = 0.875F;
            this.Label113.Width = 1.3125F;
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
            this.Label135.Height = 0.3125F;
            this.Label135.HyperLink = "";
            this.Label135.Left = 9.875F;
            this.Label135.Name = "Label135";
            this.Label135.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label135.Text = "Canc. Entry Date";
            this.Label135.Top = 0.875F;
            this.Label135.Width = 0.6875F;
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
            this.Label75.Left = 4.5F;
            this.Label75.MultiLine = false;
            this.Label75.Name = "Label75";
            this.Label75.Style = "text-align: center; font-weight: bold; font-size: 11.25pt; font-family: Times New" +
                " Roman; ";
            this.Label75.Text = "LAS VISTAS INSURANCE AGENCY, CORP.";
            this.Label75.Top = 0.125F;
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
            this.Label77.Left = 4.5F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-align: center; font-weight: bold; font-size: 6pt; font-family: Times New Rom" +
                "an; ";
            this.Label77.Text = "P.O. Box 195585 San Juan Puerto Rico, PR  00919-5585 Tel (787) 763-4010 Fax (787)" +
                " 763-3525";
            this.Label77.Top = 0.375F;
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
            this.Label130.Left = 0.2708333F;
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
            this.Label159.Height = 0.2F;
            this.Label159.HyperLink = "";
            this.Label159.Left = 0.3125F;
            this.Label159.Name = "Label159";
            this.Label159.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label159.Text = "Insurance Company:";
            this.Label159.Top = 0F;
            this.Label159.Width = 1.229167F;
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
            this.Label160.DataField = "InsuranceCompany";
            this.Label160.Height = 0.2F;
            this.Label160.HyperLink = "";
            this.Label160.Left = 1.5625F;
            this.Label160.Name = "Label160";
            this.Label160.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label160.Text = "";
            this.Label160.Top = 0F;
            this.Label160.Width = 0.4375F;
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
            this.Label161.DataField = "InsuranceCompanyDesc";
            this.Label161.Height = 0.2F;
            this.Label161.HyperLink = "";
            this.Label161.Left = 2.0625F;
            this.Label161.Name = "Label161";
            this.Label161.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label161.Text = "";
            this.Label161.Top = 0F;
            this.Label161.Width = 2.5625F;
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
            this.txtTaskControlID.Left = 0.2604166F;
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
            this.TxtRegCode.Left = 1.1875F;
            this.TxtRegCode.Name = "TxtRegCode";
            this.TxtRegCode.Style = "text-align: center; font-size: 7pt; ";
            this.TxtRegCode.Top = 0F;
            this.TxtRegCode.Width = 1F;
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
            this.txtCustomerNo.Height = 0.125F;
            this.txtCustomerNo.Left = 2.3125F;
            this.txtCustomerNo.MultiLine = false;
            this.txtCustomerNo.Name = "txtCustomerNo";
            this.txtCustomerNo.Style = "text-align: left; font-size: 7pt; ";
            this.txtCustomerNo.Top = 0F;
            this.txtCustomerNo.Width = 1.4375F;
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
            this.txtEntryDate.Left = 3.875F;
            this.txtEntryDate.Name = "txtEntryDate";
            this.txtEntryDate.OutputFormat = resources.GetString("txtEntryDate.OutputFormat");
            this.txtEntryDate.Style = "text-align: left; font-size: 7pt; ";
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
            this.txtEffectiveDate.Left = 4.5625F;
            this.txtEffectiveDate.Name = "txtEffectiveDate";
            this.txtEffectiveDate.OutputFormat = resources.GetString("txtEffectiveDate.OutputFormat");
            this.txtEffectiveDate.Style = "text-align: left; font-size: 7pt; ";
            this.txtEffectiveDate.Top = 0F;
            this.txtEffectiveDate.Width = 0.625F;
            // 
            // txtTerm
            // 
            this.txtTerm.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTerm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTerm.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTerm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTerm.Border.RightColor = System.Drawing.Color.Black;
            this.txtTerm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTerm.Border.TopColor = System.Drawing.Color.Black;
            this.txtTerm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTerm.DataField = "Term";
            this.txtTerm.Height = 0.125F;
            this.txtTerm.Left = 5.25F;
            this.txtTerm.Name = "txtTerm";
            this.txtTerm.Style = "text-align: left; font-size: 7pt; ";
            this.txtTerm.Top = 0F;
            this.txtTerm.Width = 0.4375F;
            // 
            // txtMake
            // 
            this.txtMake.Border.BottomColor = System.Drawing.Color.Black;
            this.txtMake.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMake.Border.LeftColor = System.Drawing.Color.Black;
            this.txtMake.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMake.Border.RightColor = System.Drawing.Color.Black;
            this.txtMake.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMake.Border.TopColor = System.Drawing.Color.Black;
            this.txtMake.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMake.DataField = "make";
            this.txtMake.Height = 0.125F;
            this.txtMake.Left = 5.75F;
            this.txtMake.Name = "txtMake";
            this.txtMake.Style = "text-align: left; font-size: 7pt; ";
            this.txtMake.Top = 0F;
            this.txtMake.Width = 1F;
            // 
            // txtModel
            // 
            this.txtModel.Border.BottomColor = System.Drawing.Color.Black;
            this.txtModel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtModel.Border.LeftColor = System.Drawing.Color.Black;
            this.txtModel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtModel.Border.RightColor = System.Drawing.Color.Black;
            this.txtModel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtModel.Border.TopColor = System.Drawing.Color.Black;
            this.txtModel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtModel.DataField = "model";
            this.txtModel.Height = 0.125F;
            this.txtModel.Left = 6.75F;
            this.txtModel.MultiLine = false;
            this.txtModel.Name = "txtModel";
            this.txtModel.Style = "text-align: left; font-size: 7pt; ";
            this.txtModel.Top = 0F;
            this.txtModel.Width = 1.0625F;
            // 
            // txtYear
            // 
            this.txtYear.Border.BottomColor = System.Drawing.Color.Black;
            this.txtYear.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtYear.Border.LeftColor = System.Drawing.Color.Black;
            this.txtYear.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtYear.Border.RightColor = System.Drawing.Color.Black;
            this.txtYear.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtYear.Border.TopColor = System.Drawing.Color.Black;
            this.txtYear.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtYear.DataField = "yr";
            this.txtYear.Height = 0.125F;
            this.txtYear.Left = 7.875F;
            this.txtYear.Name = "txtYear";
            this.txtYear.Style = "text-align: left; font-size: 7pt; ";
            this.txtYear.Top = 0F;
            this.txtYear.Width = 0.3125F;
            // 
            // txtVin
            // 
            this.txtVin.Border.BottomColor = System.Drawing.Color.Black;
            this.txtVin.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVin.Border.LeftColor = System.Drawing.Color.Black;
            this.txtVin.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVin.Border.RightColor = System.Drawing.Color.Black;
            this.txtVin.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVin.Border.TopColor = System.Drawing.Color.Black;
            this.txtVin.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVin.DataField = "VIN";
            this.txtVin.Height = 0.125F;
            this.txtVin.Left = 8.25F;
            this.txtVin.Name = "txtVin";
            this.txtVin.Style = "text-align: left; font-size: 7pt; ";
            this.txtVin.Top = 0F;
            this.txtVin.Width = 1.125F;
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
            this.txtTotalPremium.Left = 11.73958F;
            this.txtTotalPremium.Name = "txtTotalPremium";
            this.txtTotalPremium.OutputFormat = resources.GetString("txtTotalPremium.OutputFormat");
            this.txtTotalPremium.Style = "text-align: right; font-size: 7pt; ";
            this.txtTotalPremium.Top = 0F;
            this.txtTotalPremium.Width = 0.635417F;
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
            this.TextBox20.Left = 11.73958F;
            this.TextBox20.Name = "TextBox20";
            this.TextBox20.OutputFormat = resources.GetString("TextBox20.OutputFormat");
            this.TextBox20.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox20.Top = 0.125F;
            this.TextBox20.Width = 0.6979167F;
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
            this.TextBox22.Left = 10.9375F;
            this.TextBox22.Name = "TextBox22";
            this.TextBox22.OutputFormat = resources.GetString("TextBox22.OutputFormat");
            this.TextBox22.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox22.Top = 0F;
            this.TextBox22.Width = 0.5625F;
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
            this.TextBox38.DataField = "CancellatioEntryDate";
            this.TextBox38.Height = 0.125F;
            this.TextBox38.Left = 9.9375F;
            this.TextBox38.Name = "TextBox38";
            this.TextBox38.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox38.Top = 0F;
            this.TextBox38.Width = 0.5625F;
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
            this.TextBox70.DataField = "PrmCount";
            this.TextBox70.Height = 0.125F;
            this.TextBox70.Left = 9.4375F;
            this.TextBox70.Name = "TextBox70";
            this.TextBox70.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox70.Text = "PrmCount";
            this.TextBox70.Top = 0F;
            this.TextBox70.Visible = false;
            this.TextBox70.Width = 0.5625F;
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
            this.TextBox39.Left = 9.4375F;
            this.TextBox39.Name = "TextBox39";
            this.TextBox39.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox39.Text = "CancCount";
            this.TextBox39.Top = 0.125F;
            this.TextBox39.Visible = false;
            this.TextBox39.Width = 0.5625F;
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
            this.TextBox61.Left = 9.3125F;
            this.TextBox61.Name = "TextBox61";
            this.TextBox61.OutputFormat = resources.GetString("TextBox61.OutputFormat");
            this.TextBox61.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox61.Text = "PremNet";
            this.TextBox61.Top = 0.1875F;
            this.TextBox61.Visible = false;
            this.TextBox61.Width = 0.6979167F;
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
            this.Label162.Height = 0.2F;
            this.Label162.HyperLink = "";
            this.Label162.Left = 0.375F;
            this.Label162.Name = "Label162";
            this.Label162.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label162.Text = "Total for Ins. Company:";
            this.Label162.Top = 0F;
            this.Label162.Width = 1.4375F;
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
            this.Label163.DataField = "InsuranceCompany";
            this.Label163.Height = 0.2F;
            this.Label163.HyperLink = "";
            this.Label163.Left = 1.9375F;
            this.Label163.Name = "Label163";
            this.Label163.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label163.Text = "";
            this.Label163.Top = 0F;
            this.Label163.Width = 0.4375F;
            // 
            // TextBox69
            // 
            this.TextBox69.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox69.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox69.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox69.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox69.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox69.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox69.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox69.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox69.DataField = "TaskControlID";
            this.TextBox69.Height = 0.1875F;
            this.TextBox69.Left = 2.489583F;
            this.TextBox69.Name = "TextBox69";
            this.TextBox69.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox69.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox69.SummaryGroup = "GroupHeader2";
            this.TextBox69.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox69.Top = 0F;
            this.TextBox69.Width = 0.8958333F;
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
            this.TextBox24.Left = 11.75F;
            this.TextBox24.Name = "TextBox24";
            this.TextBox24.OutputFormat = resources.GetString("TextBox24.OutputFormat");
            this.TextBox24.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox24.SummaryGroup = "GroupHeader2";
            this.TextBox24.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox24.Top = 0F;
            this.TextBox24.Width = 0.6875F;
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
            this.TextBox41.DataField = "CancellationAmount";
            this.TextBox41.Height = 0.1875F;
            this.TextBox41.Left = 11.75F;
            this.TextBox41.Name = "TextBox41";
            this.TextBox41.OutputFormat = resources.GetString("TextBox41.OutputFormat");
            this.TextBox41.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox41.SummaryGroup = "GroupHeader2";
            this.TextBox41.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox41.Top = 0.125F;
            this.TextBox41.Width = 0.6875F;
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
            this.Label164.Left = 8.4375F;
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
            this.Label165.Left = 8.4375F;
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
            this.Label166.Left = 8.4375F;
            this.Label166.Name = "Label166";
            this.Label166.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label166.Text = "Net >>>>>>>";
            this.Label166.Top = 0.25F;
            this.Label166.Width = 0.9375F;
            // 
            // TextBox71
            // 
            this.TextBox71.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox71.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox71.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox71.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox71.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox71.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox71.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox71.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox71.DataField = "CancCount";
            this.TextBox71.Height = 0.1875F;
            this.TextBox71.Left = 9.375F;
            this.TextBox71.Name = "TextBox71";
            this.TextBox71.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox71.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox71.SummaryGroup = "GroupHeader2";
            this.TextBox71.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox71.Top = 0.125F;
            this.TextBox71.Width = 0.625F;
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
            this.TextBox74.Left = 9.375F;
            this.TextBox74.Name = "TextBox74";
            this.TextBox74.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox74.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox74.SummaryGroup = "GroupHeader2";
            this.TextBox74.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
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
            this.TextBox76.Left = 11.75F;
            this.TextBox76.Name = "TextBox76";
            this.TextBox76.OutputFormat = resources.GetString("TextBox76.OutputFormat");
            this.TextBox76.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox76.SummaryGroup = "GroupHeader2";
            this.TextBox76.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox76.Top = 0.25F;
            this.TextBox76.Width = 0.6875F;
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
            this.Label133.Left = 0.3125F;
            this.Label133.Name = "Label133";
            this.Label133.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label133.Text = "Total for Company Dealer:";
            this.Label133.Top = 0F;
            this.Label133.Width = 1.4375F;
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
            this.Label134.DataField = "CompanyDealer";
            this.Label134.Height = 0.2F;
            this.Label134.HyperLink = "";
            this.Label134.Left = 1.9375F;
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
            this.TextBox23.DataField = "TaskControlID";
            this.TextBox23.Height = 0.1875F;
            this.TextBox23.Left = 2.489583F;
            this.TextBox23.Name = "TextBox23";
            this.TextBox23.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.TextBox23.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox23.SummaryGroup = "GroupHeader1";
            this.TextBox23.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox23.Top = 0F;
            this.TextBox23.Width = 0.8958333F;
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
            this.TextBox77.DataField = "TotalPremium";
            this.TextBox77.Height = 0.1875F;
            this.TextBox77.Left = 11.75F;
            this.TextBox77.Name = "TextBox77";
            this.TextBox77.OutputFormat = resources.GetString("TextBox77.OutputFormat");
            this.TextBox77.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox77.SummaryGroup = "GroupHeader1";
            this.TextBox77.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox77.Top = 0F;
            this.TextBox77.Width = 0.6875F;
            // 
            // TextBox79
            // 
            this.TextBox79.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox79.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox79.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox79.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox79.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox79.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox79.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox79.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox79.DataField = "CancellationAmount";
            this.TextBox79.Height = 0.1875F;
            this.TextBox79.Left = 11.75F;
            this.TextBox79.Name = "TextBox79";
            this.TextBox79.OutputFormat = resources.GetString("TextBox79.OutputFormat");
            this.TextBox79.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox79.SummaryGroup = "GroupHeader1";
            this.TextBox79.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox79.Top = 0.125F;
            this.TextBox79.Width = 0.6875F;
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
            this.Label167.Left = 8.4375F;
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
            this.Label168.Left = 8.4375F;
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
            this.Label169.Left = 8.4375F;
            this.Label169.Name = "Label169";
            this.Label169.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label169.Text = "Net >>>>>>>";
            this.Label169.Top = 0.25F;
            this.Label169.Width = 0.9375F;
            // 
            // TextBox80
            // 
            this.TextBox80.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox80.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox80.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox80.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox80.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox80.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox80.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox80.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox80.DataField = "CancCount";
            this.TextBox80.Height = 0.1875F;
            this.TextBox80.Left = 9.375F;
            this.TextBox80.Name = "TextBox80";
            this.TextBox80.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox80.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox80.SummaryGroup = "GroupHeader1";
            this.TextBox80.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox80.Top = 0.125F;
            this.TextBox80.Width = 0.625F;
            // 
            // TextBox81
            // 
            this.TextBox81.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox81.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox81.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox81.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox81.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox81.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox81.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox81.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox81.DataField = "PrmCount";
            this.TextBox81.Height = 0.1875F;
            this.TextBox81.Left = 9.375F;
            this.TextBox81.Name = "TextBox81";
            this.TextBox81.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox81.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox81.SummaryGroup = "GroupHeader1";
            this.TextBox81.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox81.Top = 0F;
            this.TextBox81.Width = 0.625F;
            // 
            // TextBox82
            // 
            this.TextBox82.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox82.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox82.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox82.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox82.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox82.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox82.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox82.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox82.DataField = "PremNet";
            this.TextBox82.Height = 0.1875F;
            this.TextBox82.Left = 11.75F;
            this.TextBox82.Name = "TextBox82";
            this.TextBox82.OutputFormat = resources.GetString("TextBox82.OutputFormat");
            this.TextBox82.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox82.SummaryGroup = "GroupHeader1";
            this.TextBox82.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox82.Top = 0.25F;
            this.TextBox82.Width = 0.6875F;
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
            this.TextBox19.Left = 2.489583F;
            this.TextBox19.Name = "TextBox19";
            this.TextBox19.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Microsoft Sa" +
                "ns Serif; ";
            this.TextBox19.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox19.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox19.Top = 0F;
            this.TextBox19.Width = 0.8958333F;
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
            this.Label127.Left = 0.375F;
            this.Label127.Name = "Label127";
            this.Label127.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label127.Text = "Grand Total:";
            this.Label127.Top = 0F;
            this.Label127.Width = 1F;
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
            this.TextBox18.Left = 11.5625F;
            this.TextBox18.Name = "TextBox18";
            this.TextBox18.OutputFormat = resources.GetString("TextBox18.OutputFormat");
            this.TextBox18.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: Microsoft S" +
                "ans Serif; ";
            this.TextBox18.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
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
            this.TextBox21.Left = 11.5625F;
            this.TextBox21.Name = "TextBox21";
            this.TextBox21.OutputFormat = resources.GetString("TextBox21.OutputFormat");
            this.TextBox21.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: Microsoft S" +
                "ans Serif; ";
            this.TextBox21.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox21.Top = 0.125F;
            this.TextBox21.Width = 0.875F;
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
            this.Label170.Height = 0.2F;
            this.Label170.HyperLink = "";
            this.Label170.Left = 8.4375F;
            this.Label170.Name = "Label170";
            this.Label170.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label170.Text = "New Contracts";
            this.Label170.Top = 0F;
            this.Label170.Width = 0.9375F;
            // 
            // Label171
            // 
            this.Label171.Border.BottomColor = System.Drawing.Color.Black;
            this.Label171.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label171.Border.LeftColor = System.Drawing.Color.Black;
            this.Label171.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label171.Border.RightColor = System.Drawing.Color.Black;
            this.Label171.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label171.Border.TopColor = System.Drawing.Color.Black;
            this.Label171.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label171.Height = 0.2F;
            this.Label171.HyperLink = "";
            this.Label171.Left = 8.4375F;
            this.Label171.Name = "Label171";
            this.Label171.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label171.Text = "Cancellations";
            this.Label171.Top = 0.125F;
            this.Label171.Width = 0.9375F;
            // 
            // Label172
            // 
            this.Label172.Border.BottomColor = System.Drawing.Color.Black;
            this.Label172.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label172.Border.LeftColor = System.Drawing.Color.Black;
            this.Label172.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label172.Border.RightColor = System.Drawing.Color.Black;
            this.Label172.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label172.Border.TopColor = System.Drawing.Color.Black;
            this.Label172.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label172.Height = 0.2F;
            this.Label172.HyperLink = "";
            this.Label172.Left = 8.4375F;
            this.Label172.Name = "Label172";
            this.Label172.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label172.Text = "Net >>>>>>>";
            this.Label172.Top = 0.25F;
            this.Label172.Width = 0.9375F;
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
            this.TextBox37.Left = 9.395833F;
            this.TextBox37.Name = "TextBox37";
            this.TextBox37.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox37.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox37.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
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
            this.TextBox68.Left = 9.395833F;
            this.TextBox68.Name = "TextBox68";
            this.TextBox68.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox68.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox68.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox68.Top = 0F;
            this.TextBox68.Width = 0.6875F;
            // 
            // TextBox83
            // 
            this.TextBox83.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox83.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox83.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox83.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox83.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox83.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox83.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox83.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox83.DataField = "PremNet";
            this.TextBox83.Height = 0.1875F;
            this.TextBox83.Left = 11.5625F;
            this.TextBox83.Name = "TextBox83";
            this.TextBox83.OutputFormat = resources.GetString("TextBox83.OutputFormat");
            this.TextBox83.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox83.SummaryGroup = "GroupHeader1";
            this.TextBox83.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox83.Top = 0.25F;
            this.TextBox83.Width = 0.875F;
            // 
            // ActiveReport31
            // 
            this.PageSettings.Margins.Bottom = 0.1F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0.3F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 13.52083F;
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
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label115)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label116)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label118)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label120)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label122)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label124)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label125)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label128)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label129)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label113)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label159)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label160)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label161)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaskControlID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRegCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTerm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label162)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label163)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox69)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label164)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label165)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label166)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox74)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox76)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox79)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label167)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label168)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label169)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox81)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox82)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label127)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label170)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label171)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label172)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox68)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox83)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
       
			// Attach Report Events
			this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
			this.ReportStart += new System.EventHandler(this.AutoGuardPremiumWrittenByDealerIns_ReportStart);
		 }

		#endregion
	}
}
