using System;
using System.Data;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports
{
	public class PremiumWrittenBySupplies : DataDynamics.ActiveReports.ActiveReport3
	{
		string _FromDate;
		string _ToDate;
		string _ReportType;
		bool   _Summary = false;
        string _mHeadCompany = "";

        public PremiumWrittenBySupplies(string FromDate, string ToDate, string ReportType, bool Summary, string mHeadCompany)
		{
			_FromDate = FromDate;
			_ToDate = ToDate;
			_ReportType = ReportType;
			_Summary  =  Summary;
            _mHeadCompany = mHeadCompany;

			InitializeComponent();
		}

		private void PremiumWrittenBySupplies_ReportStart(object sender, System.EventArgs eArgs)
		{
			if (_Summary)
			{
				this.Detail.Visible = false;
			}
            this.Label75.Text = _mHeadCompany;

			this.lblDate.Text = "Date:"+DateTime.Now.ToShortDateString();
			this.lblTime.Text = "Time:"+DateTime.Now.ToShortTimeString();

			if (!_FromDate.Trim().Equals("")||(!_FromDate.Trim().Equals("")))
			{
				this.lblCriterias.Text = _ReportType + " From: " + _FromDate +" To: " + _ToDate;
			}
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
		private Label Label75 = null;
		private Label Label77 = null;
        private Label Label171 = null;
		private Label lblComissions = null;
		private Label Label176 = null;
		private Label Label177 = null;
		private GroupHeader GroupHeader1 = null;
		private Label lblSupplies = null;
		private Label lblSupplyCode = null;
		private Label lblSuplyName = null;
		private GroupHeader GroupHeader2 = null;
		private Label Label178 = null;
		private Label Label179 = null;
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
        private TextBox TextBox78 = null;
		private TextBox txtComission = null;
		private TextBox TextBox84 = null;
		private TextBox TextBox85 = null;
		private GroupFooter GroupFooter2 = null;
		private Label Label180 = null;
		private Label Label181 = null;
		private Label Label186 = null;
		private Label Label187 = null;
		private Label Label188 = null;
		private TextBox TextBox107 = null;
		private TextBox TextBox108 = null;
		private TextBox TextBox109 = null;
		private TextBox TextBox110 = null;
		private TextBox TextBox111 = null;
		private TextBox TextBox112 = null;
		private TextBox TextBox113 = null;
		private TextBox TextBox114 = null;
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
		private TextBox TextBox101 = null;
		private TextBox TextBox102 = null;
		private TextBox TextBox103 = null;
		private PageFooter PageFooter = null;
		private ReportFooter ReportFooter = null;
		private Label Label127 = null;
		private TextBox TextBox18 = null;
		private TextBox TextBox21 = null;
		private Label Label167 = null;
		private Label Label168 = null;
		private Label Label169 = null;
		private TextBox TextBox37 = null;
		private TextBox TextBox68 = null;
		private TextBox TextBox77 = null;
		private TextBox TextBox104 = null;
		private TextBox TextBox105 = null;
		private TextBox TextBox106 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PremiumWrittenBySupplies));
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
            this.TextBox78 = new DataDynamics.ActiveReports.TextBox();
            this.txtComission = new DataDynamics.ActiveReports.TextBox();
            this.TextBox84 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox85 = new DataDynamics.ActiveReports.TextBox();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.Label127 = new DataDynamics.ActiveReports.Label();
            this.TextBox18 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox21 = new DataDynamics.ActiveReports.TextBox();
            this.Label167 = new DataDynamics.ActiveReports.Label();
            this.Label168 = new DataDynamics.ActiveReports.Label();
            this.Label169 = new DataDynamics.ActiveReports.Label();
            this.TextBox37 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox68 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox77 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox104 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox105 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox106 = new DataDynamics.ActiveReports.TextBox();
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
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.Label171 = new DataDynamics.ActiveReports.Label();
            this.lblComissions = new DataDynamics.ActiveReports.Label();
            this.Label176 = new DataDynamics.ActiveReports.Label();
            this.Label177 = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.GroupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.lblSupplies = new DataDynamics.ActiveReports.Label();
            this.lblSupplyCode = new DataDynamics.ActiveReports.Label();
            this.lblSuplyName = new DataDynamics.ActiveReports.Label();
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
            this.TextBox101 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox102 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox103 = new DataDynamics.ActiveReports.TextBox();
            this.GroupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.Label178 = new DataDynamics.ActiveReports.Label();
            this.Label179 = new DataDynamics.ActiveReports.Label();
            this.GroupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.Label180 = new DataDynamics.ActiveReports.Label();
            this.Label181 = new DataDynamics.ActiveReports.Label();
            this.Label186 = new DataDynamics.ActiveReports.Label();
            this.Label187 = new DataDynamics.ActiveReports.Label();
            this.Label188 = new DataDynamics.ActiveReports.Label();
            this.TextBox107 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox108 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox109 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox110 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox111 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox112 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox113 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox114 = new DataDynamics.ActiveReports.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.TextBox78)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox84)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox85)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label127)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label167)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label168)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label169)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox68)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox106)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label171)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblComissions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label176)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label177)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSupplies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSupplyCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuplyName)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.TextBox101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox103)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label178)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label179)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label180)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label181)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label186)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label187)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label188)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox110)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox112)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox113)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox114)).BeginInit();
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
            this.TextBox78,
            this.txtComission,
            this.TextBox84,
            this.TextBox85});
            this.Detail.Height = 0.375F;
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
            this.txtTaskControlID.Left = 0.2604166F;
            this.txtTaskControlID.Name = "txtTaskControlID";
            this.txtTaskControlID.Style = "text-align: left; font-size: 7pt; ";
            this.txtTaskControlID.Text = null;
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
            this.TxtRegCode.Text = null;
            this.TxtRegCode.Top = 0F;
            this.TxtRegCode.Width = 1.2125F;
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
            this.txtCustomerNo.Left = 2.5F;
            this.txtCustomerNo.MultiLine = false;
            this.txtCustomerNo.Name = "txtCustomerNo";
            this.txtCustomerNo.Style = "text-align: left; font-size: 7pt; ";
            this.txtCustomerNo.Text = null;
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
            this.txtEntryDate.Left = 4.0625F;
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
            this.txtEffectiveDate.Left = 5.125F;
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
            this.txtTotalPremium.Left = 8.302083F;
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
            this.TextBox20.Left = 8.302083F;
            this.TextBox20.Name = "TextBox20";
            this.TextBox20.OutputFormat = resources.GetString("TextBox20.OutputFormat");
            this.TextBox20.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox20.Text = null;
            this.TextBox20.Top = 0.125F;
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
            this.TextBox38.Left = 10.5F;
            this.TextBox38.Name = "TextBox38";
            this.TextBox38.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox38.Text = "PrmCount";
            this.TextBox38.Top = 0F;
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
            this.TextBox39.Left = 10.5F;
            this.TextBox39.Name = "TextBox39";
            this.TextBox39.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox39.Text = "CancCount";
            this.TextBox39.Top = 0.125F;
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
            this.TextBox22.Left = 6.625F;
            this.TextBox22.Name = "TextBox22";
            this.TextBox22.OutputFormat = resources.GetString("TextBox22.OutputFormat");
            this.TextBox22.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox22.Text = null;
            this.TextBox22.Top = 0.125F;
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
            this.TextBox75.Left = 6.625F;
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
            this.TextBox61.Left = 10.375F;
            this.TextBox61.Name = "TextBox61";
            this.TextBox61.OutputFormat = resources.GetString("TextBox61.OutputFormat");
            this.TextBox61.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox61.Text = "PremNet";
            this.TextBox61.Top = 0.1875F;
            this.TextBox61.Visible = false;
            this.TextBox61.Width = 0.6979167F;
            // 
            // TextBox78
            // 
            this.TextBox78.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox78.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox78.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox78.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox78.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox78.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox78.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox78.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox78.DataField = "EffectiveDate";
            this.TextBox78.Height = 0.125F;
            this.TextBox78.Left = 5.125F;
            this.TextBox78.Name = "TextBox78";
            this.TextBox78.OutputFormat = resources.GetString("TextBox78.OutputFormat");
            this.TextBox78.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox78.Text = null;
            this.TextBox78.Top = 0.125F;
            this.TextBox78.Width = 0.625F;
            // 
            // txtComission
            // 
            this.txtComission.Border.BottomColor = System.Drawing.Color.Black;
            this.txtComission.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtComission.Border.LeftColor = System.Drawing.Color.Black;
            this.txtComission.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtComission.Border.RightColor = System.Drawing.Color.Black;
            this.txtComission.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtComission.Border.TopColor = System.Drawing.Color.Black;
            this.txtComission.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtComission.DataField = "PremComm";
            this.txtComission.Height = 0.125F;
            this.txtComission.Left = 9.9375F;
            this.txtComission.Name = "txtComission";
            this.txtComission.OutputFormat = resources.GetString("txtComission.OutputFormat");
            this.txtComission.Style = "text-align: center; font-size: 7pt; ";
            this.txtComission.Text = null;
            this.txtComission.Top = 0F;
            this.txtComission.Width = 0.5625F;
            // 
            // TextBox84
            // 
            this.TextBox84.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox84.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox84.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox84.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox84.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox84.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox84.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox84.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox84.DataField = "CancComm";
            this.TextBox84.Height = 0.125F;
            this.TextBox84.Left = 9.9375F;
            this.TextBox84.Name = "TextBox84";
            this.TextBox84.OutputFormat = resources.GetString("TextBox84.OutputFormat");
            this.TextBox84.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox84.Text = null;
            this.TextBox84.Top = 0.125F;
            this.TextBox84.Width = 0.5625F;
            // 
            // TextBox85
            // 
            this.TextBox85.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox85.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox85.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox85.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox85.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox85.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox85.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox85.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox85.DataField = "CommNet";
            this.TextBox85.Height = 0.125F;
            this.TextBox85.Left = 9.9375F;
            this.TextBox85.Name = "TextBox85";
            this.TextBox85.OutputFormat = resources.GetString("TextBox85.OutputFormat");
            this.TextBox85.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox85.Text = null;
            this.TextBox85.Top = 0.25F;
            this.TextBox85.Width = 0.5625F;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Height = 0.25F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label127,
            this.TextBox18,
            this.TextBox21,
            this.Label167,
            this.Label168,
            this.Label169,
            this.TextBox37,
            this.TextBox68,
            this.TextBox77,
            this.TextBox104,
            this.TextBox105,
            this.TextBox106});
            this.ReportFooter.Height = 0.4493056F;
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
            this.Label127.Left = 0.375F;
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
            this.TextBox18.Left = 8.125F;
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
            this.TextBox21.Left = 8.125F;
            this.TextBox21.Name = "TextBox21";
            this.TextBox21.OutputFormat = resources.GetString("TextBox21.OutputFormat");
            this.TextBox21.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: Microsoft S" +
                "ans Serif; ";
            this.TextBox21.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox21.Text = null;
            this.TextBox21.Top = 0.125F;
            this.TextBox21.Width = 0.875F;
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
            this.Label167.Left = 5.5F;
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
            this.Label168.Left = 5.5F;
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
            this.Label169.Left = 5.5F;
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
            this.TextBox37.Left = 6.489583F;
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
            this.TextBox68.Left = 6.5F;
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
            this.TextBox77.Left = 8.125F;
            this.TextBox77.Name = "TextBox77";
            this.TextBox77.OutputFormat = resources.GetString("TextBox77.OutputFormat");
            this.TextBox77.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox77.SummaryGroup = "GroupHeader1";
            this.TextBox77.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox77.Text = null;
            this.TextBox77.Top = 0.25F;
            this.TextBox77.Width = 0.875F;
            // 
            // TextBox104
            // 
            this.TextBox104.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox104.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox104.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox104.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox104.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox104.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox104.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox104.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox104.DataField = "PremComm";
            this.TextBox104.Height = 0.125F;
            this.TextBox104.Left = 9.6F;
            this.TextBox104.Name = "TextBox104";
            this.TextBox104.OutputFormat = resources.GetString("TextBox104.OutputFormat");
            this.TextBox104.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.TextBox104.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox104.Text = null;
            this.TextBox104.Top = 0F;
            this.TextBox104.Width = 0.9F;
            // 
            // TextBox105
            // 
            this.TextBox105.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox105.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox105.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox105.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox105.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox105.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox105.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox105.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox105.DataField = "CancComm";
            this.TextBox105.Height = 0.125F;
            this.TextBox105.Left = 9.6F;
            this.TextBox105.Name = "TextBox105";
            this.TextBox105.OutputFormat = resources.GetString("TextBox105.OutputFormat");
            this.TextBox105.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.TextBox105.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox105.Text = null;
            this.TextBox105.Top = 0.125F;
            this.TextBox105.Width = 0.9F;
            // 
            // TextBox106
            // 
            this.TextBox106.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox106.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox106.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox106.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox106.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox106.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox106.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox106.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox106.DataField = "CommNet";
            this.TextBox106.Height = 0.125F;
            this.TextBox106.Left = 9.6F;
            this.TextBox106.Name = "TextBox106";
            this.TextBox106.OutputFormat = resources.GetString("TextBox106.OutputFormat");
            this.TextBox106.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.TextBox106.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox106.Text = null;
            this.TextBox106.Top = 0.25F;
            this.TextBox106.Width = 0.9F;
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
            this.Label75,
            this.Label77,
            this.Label171,
            this.lblComissions,
            this.Label176,
            this.Label177});
            this.PageHeader.Height = 1.3125F;
            this.PageHeader.Name = "PageHeader";
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
            this.lblCriterias.Left = 3.151042F;
            this.lblCriterias.MultiLine = false;
            this.lblCriterias.Name = "lblCriterias";
            this.lblCriterias.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.lblCriterias.Text = "Incentive Statement By Supplies - Effective Date Criteria";
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
            this.Label80.Left = 9.875F;
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
            this.TextBox17.Left = 10.375F;
            this.TextBox17.MultiLine = false;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat");
            this.TextBox17.Style = "text-align: right; font-size: 8pt; vertical-align: top; ";
            this.TextBox17.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox17.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.TextBox17.Text = null;
            this.TextBox17.Top = 0.0625F;
            this.TextBox17.Width = 0.4549999F;
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
            this.Shape3.Height = 0.405F;
            this.Shape3.Left = 0.125F;
            this.Shape3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Shape3.Name = "Shape3";
            this.Shape3.RoundingRadius = 9.999999F;
            this.Shape3.Top = 0.875F;
            this.Shape3.Width = 10.875F;
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
            this.Label109.Left = 4.0625F;
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
            this.Label122.Left = 8.3125F;
            this.Label122.Name = "Label122";
            this.Label122.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
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
            this.Label125.Left = 5.1875F;
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
            this.Label128.Left = 8.3125F;
            this.Label128.MultiLine = false;
            this.Label128.Name = "Label128";
            this.Label128.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label128.Text = "Canc. Amount";
            this.Label128.Top = 1F;
            this.Label128.Width = 0.8125F;
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
            this.Label113.Left = 2.5F;
            this.Label113.Name = "Label113";
            this.Label113.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label113.Text = "Customer Name";
            this.Label113.Top = 0.875F;
            this.Label113.Width = 1.3125F;
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
            this.Label129.Left = 6.5F;
            this.Label129.Name = "Label129";
            this.Label129.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; vertica" +
                "l-align: top; ";
            this.Label129.Text = "Canc.Date";
            this.Label129.Top = 1F;
            this.Label129.Width = 0.6300001F;
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
            this.Label170.Height = 0.1875F;
            this.Label170.HyperLink = "";
            this.Label170.Left = 6.5F;
            this.Label170.Name = "Label170";
            this.Label170.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: inherit; vertic" +
                "al-align: top; ";
            this.Label170.Text = "Canc. Entry Date";
            this.Label170.Top = 0.875F;
            this.Label170.Width = 0.9450001F;
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
            this.Label75.Left = 3.151042F;
            this.Label75.MultiLine = false;
            this.Label75.Name = "Label75";
            this.Label75.Style = "text-align: center; font-weight: bold; font-size: 11.25pt; font-family: Times New" +
                " Roman; ";
            this.Label75.Text = "PUERTO RICO MEDICAL DEFENSE INSURANCE COMPANY";
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
            this.Label77.Left = 3.151042F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-align: center; font-weight: bold; font-size: 6pt; font-family: Times New Rom" +
                "an; ";
            this.Label77.Text = "";
            this.Label77.Top = 0.3125F;
            this.Label77.Width = 5.125F;
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
            this.Label171.Height = 0.1875F;
            this.Label171.HyperLink = "";
            this.Label171.Left = 5.1875F;
            this.Label171.Name = "Label171";
            this.Label171.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label171.Text = "Exp. Date";
            this.Label171.Top = 1F;
            this.Label171.Width = 0.5875001F;
            // 
            // lblComissions
            // 
            this.lblComissions.Border.BottomColor = System.Drawing.Color.Black;
            this.lblComissions.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblComissions.Border.LeftColor = System.Drawing.Color.Black;
            this.lblComissions.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblComissions.Border.RightColor = System.Drawing.Color.Black;
            this.lblComissions.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblComissions.Border.TopColor = System.Drawing.Color.Black;
            this.lblComissions.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblComissions.Height = 0.1875F;
            this.lblComissions.HyperLink = "";
            this.lblComissions.Left = 9.8125F;
            this.lblComissions.MultiLine = false;
            this.lblComissions.Name = "lblComissions";
            this.lblComissions.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.lblComissions.Text = "Incentive";
            this.lblComissions.Top = 0.875F;
            this.lblComissions.Width = 0.8125F;
            // 
            // Label176
            // 
            this.Label176.Border.BottomColor = System.Drawing.Color.Black;
            this.Label176.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label176.Border.LeftColor = System.Drawing.Color.Black;
            this.Label176.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label176.Border.RightColor = System.Drawing.Color.Black;
            this.Label176.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label176.Border.TopColor = System.Drawing.Color.Black;
            this.Label176.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label176.Height = 0.1875F;
            this.Label176.HyperLink = "";
            this.Label176.Left = 9.8125F;
            this.Label176.MultiLine = false;
            this.Label176.Name = "Label176";
            this.Label176.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label176.Text = "Return Incentive";
            this.Label176.Top = 1F;
            this.Label176.Width = 1.085F;
            // 
            // Label177
            // 
            this.Label177.Border.BottomColor = System.Drawing.Color.Black;
            this.Label177.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label177.Border.LeftColor = System.Drawing.Color.Black;
            this.Label177.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label177.Border.RightColor = System.Drawing.Color.Black;
            this.Label177.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label177.Border.TopColor = System.Drawing.Color.Black;
            this.Label177.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label177.Height = 0.1875F;
            this.Label177.HyperLink = "";
            this.Label177.Left = 9.8125F;
            this.Label177.MultiLine = false;
            this.Label177.Name = "Label177";
            this.Label177.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label177.Text = "Net Incentive";
            this.Label177.Top = 1.125F;
            this.Label177.Width = 1.085F;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblSupplies,
            this.lblSupplyCode,
            this.lblSuplyName});
            this.GroupHeader1.DataField = "SupplierID";
            this.GroupHeader1.Height = 0.25F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // lblSupplies
            // 
            this.lblSupplies.Border.BottomColor = System.Drawing.Color.Black;
            this.lblSupplies.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSupplies.Border.LeftColor = System.Drawing.Color.Black;
            this.lblSupplies.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSupplies.Border.RightColor = System.Drawing.Color.Black;
            this.lblSupplies.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSupplies.Border.TopColor = System.Drawing.Color.Black;
            this.lblSupplies.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSupplies.DataField = "Supplies";
            this.lblSupplies.Height = 0.2F;
            this.lblSupplies.HyperLink = "";
            this.lblSupplies.Left = 0.28F;
            this.lblSupplies.Name = "lblSupplies";
            this.lblSupplies.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.lblSupplies.Text = "Supplier:";
            this.lblSupplies.Top = 0F;
            this.lblSupplies.Width = 1F;
            // 
            // lblSupplyCode
            // 
            this.lblSupplyCode.Border.BottomColor = System.Drawing.Color.Black;
            this.lblSupplyCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSupplyCode.Border.LeftColor = System.Drawing.Color.Black;
            this.lblSupplyCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSupplyCode.Border.RightColor = System.Drawing.Color.Black;
            this.lblSupplyCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSupplyCode.Border.TopColor = System.Drawing.Color.Black;
            this.lblSupplyCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSupplyCode.DataField = "SupplierID";
            this.lblSupplyCode.Height = 0.2F;
            this.lblSupplyCode.HyperLink = "";
            this.lblSupplyCode.Left = 1.259167F;
            this.lblSupplyCode.Name = "lblSupplyCode";
            this.lblSupplyCode.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.lblSupplyCode.Text = "";
            this.lblSupplyCode.Top = 0F;
            this.lblSupplyCode.Width = 0.4375F;
            // 
            // lblSuplyName
            // 
            this.lblSuplyName.Border.BottomColor = System.Drawing.Color.Black;
            this.lblSuplyName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSuplyName.Border.LeftColor = System.Drawing.Color.Black;
            this.lblSuplyName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSuplyName.Border.RightColor = System.Drawing.Color.Black;
            this.lblSuplyName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSuplyName.Border.TopColor = System.Drawing.Color.Black;
            this.lblSuplyName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSuplyName.DataField = "SupplierDesc";
            this.lblSuplyName.Height = 0.2F;
            this.lblSuplyName.HyperLink = "";
            this.lblSuplyName.Left = 1.759167F;
            this.lblSuplyName.Name = "lblSuplyName";
            this.lblSuplyName.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.lblSuplyName.Text = "";
            this.lblSuplyName.Top = 0F;
            this.lblSuplyName.Width = 2.5625F;
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
            this.TextBox101,
            this.TextBox102,
            this.TextBox103});
            this.GroupFooter1.Height = 0.4493056F;
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
            this.Label133.Height = 0.2F;
            this.Label133.HyperLink = "";
            this.Label133.Left = 0.3125F;
            this.Label133.Name = "Label133";
            this.Label133.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label133.Text = "Total for Supplier:";
            this.Label133.Top = 0F;
            this.Label133.Width = 1.0875F;
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
            this.Label134.DataField = "SupplierID";
            this.Label134.Height = 0.2F;
            this.Label134.HyperLink = "";
            this.Label134.Left = 1.875F;
            this.Label134.Name = "Label134";
            this.Label134.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label134.Text = "";
            this.Label134.Top = 0F;
            this.Label134.Width = 0.4375F;
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
            this.TextBox24.Left = 8.1F;
            this.TextBox24.Name = "TextBox24";
            this.TextBox24.OutputFormat = resources.GetString("TextBox24.OutputFormat");
            this.TextBox24.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox24.SummaryGroup = "GroupHeader1";
            this.TextBox24.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox24.Text = null;
            this.TextBox24.Top = 0F;
            this.TextBox24.Width = 0.9F;
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
            this.TextBox25.Left = 8.1F;
            this.TextBox25.Name = "TextBox25";
            this.TextBox25.OutputFormat = resources.GetString("TextBox25.OutputFormat");
            this.TextBox25.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox25.SummaryGroup = "GroupHeader1";
            this.TextBox25.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox25.Text = null;
            this.TextBox25.Top = 0.125F;
            this.TextBox25.Width = 0.9F;
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
            this.Label164.Left = 5.5F;
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
            this.Label165.Left = 5.5F;
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
            this.Label166.Left = 5.5F;
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
            this.TextBox70.Left = 6.5625F;
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
            this.TextBox74.Left = 6.5625F;
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
            this.TextBox76.Left = 8.1F;
            this.TextBox76.Name = "TextBox76";
            this.TextBox76.OutputFormat = resources.GetString("TextBox76.OutputFormat");
            this.TextBox76.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox76.SummaryGroup = "GroupHeader1";
            this.TextBox76.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox76.Text = null;
            this.TextBox76.Top = 0.25F;
            this.TextBox76.Width = 0.9F;
            // 
            // TextBox101
            // 
            this.TextBox101.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox101.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox101.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox101.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox101.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox101.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox101.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox101.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox101.DataField = "PremComm";
            this.TextBox101.Height = 0.125F;
            this.TextBox101.Left = 9.6F;
            this.TextBox101.Name = "TextBox101";
            this.TextBox101.OutputFormat = resources.GetString("TextBox101.OutputFormat");
            this.TextBox101.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox101.SummaryGroup = "GroupHeader1";
            this.TextBox101.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox101.Text = null;
            this.TextBox101.Top = 0F;
            this.TextBox101.Width = 0.9F;
            // 
            // TextBox102
            // 
            this.TextBox102.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox102.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox102.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox102.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox102.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox102.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox102.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox102.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox102.DataField = "CancComm";
            this.TextBox102.Height = 0.125F;
            this.TextBox102.Left = 9.6F;
            this.TextBox102.Name = "TextBox102";
            this.TextBox102.OutputFormat = resources.GetString("TextBox102.OutputFormat");
            this.TextBox102.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox102.SummaryGroup = "GroupHeader1";
            this.TextBox102.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox102.Text = null;
            this.TextBox102.Top = 0.125F;
            this.TextBox102.Width = 0.9F;
            // 
            // TextBox103
            // 
            this.TextBox103.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox103.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox103.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox103.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox103.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox103.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox103.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox103.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox103.DataField = "CommNet";
            this.TextBox103.Height = 0.125F;
            this.TextBox103.Left = 9.6F;
            this.TextBox103.Name = "TextBox103";
            this.TextBox103.OutputFormat = resources.GetString("TextBox103.OutputFormat");
            this.TextBox103.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox103.SummaryGroup = "GroupHeader1";
            this.TextBox103.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox103.Text = null;
            this.TextBox103.Top = 0.25F;
            this.TextBox103.Width = 0.9F;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label178,
            this.Label179});
            this.GroupHeader2.DataField = "PolicyClassID";
            this.GroupHeader2.Height = 0.25F;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // Label178
            // 
            this.Label178.Border.BottomColor = System.Drawing.Color.Black;
            this.Label178.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label178.Border.LeftColor = System.Drawing.Color.Black;
            this.Label178.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label178.Border.RightColor = System.Drawing.Color.Black;
            this.Label178.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label178.Border.TopColor = System.Drawing.Color.Black;
            this.Label178.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label178.Height = 0.2F;
            this.Label178.HyperLink = "";
            this.Label178.Left = 0.4479167F;
            this.Label178.Name = "Label178";
            this.Label178.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label178.Text = "Line of Business:";
            this.Label178.Top = 0F;
            this.Label178.Width = 1F;
            // 
            // Label179
            // 
            this.Label179.Border.BottomColor = System.Drawing.Color.Black;
            this.Label179.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label179.Border.LeftColor = System.Drawing.Color.Black;
            this.Label179.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label179.Border.RightColor = System.Drawing.Color.Black;
            this.Label179.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label179.Border.TopColor = System.Drawing.Color.Black;
            this.Label179.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label179.DataField = "PolicyClassDesc";
            this.Label179.Height = 0.2F;
            this.Label179.HyperLink = "";
            this.Label179.Left = 1.6F;
            this.Label179.Name = "Label179";
            this.Label179.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label179.Text = "";
            this.Label179.Top = 0F;
            this.Label179.Width = 2.7225F;
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label180,
            this.Label181,
            this.Label186,
            this.Label187,
            this.Label188,
            this.TextBox107,
            this.TextBox108,
            this.TextBox109,
            this.TextBox110,
            this.TextBox111,
            this.TextBox112,
            this.TextBox113,
            this.TextBox114});
            this.GroupFooter2.Height = 0.4493056F;
            this.GroupFooter2.Name = "GroupFooter2";
            // 
            // Label180
            // 
            this.Label180.Border.BottomColor = System.Drawing.Color.Black;
            this.Label180.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label180.Border.LeftColor = System.Drawing.Color.Black;
            this.Label180.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label180.Border.RightColor = System.Drawing.Color.Black;
            this.Label180.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label180.Border.TopColor = System.Drawing.Color.Black;
            this.Label180.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label180.Height = 0.2F;
            this.Label180.HyperLink = "";
            this.Label180.Left = 0.4479167F;
            this.Label180.Name = "Label180";
            this.Label180.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label180.Text = "Total for Line of Business:";
            this.Label180.Top = 0F;
            this.Label180.Width = 1.4475F;
            // 
            // Label181
            // 
            this.Label181.Border.BottomColor = System.Drawing.Color.Black;
            this.Label181.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label181.Border.LeftColor = System.Drawing.Color.Black;
            this.Label181.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label181.Border.RightColor = System.Drawing.Color.Black;
            this.Label181.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label181.Border.TopColor = System.Drawing.Color.Black;
            this.Label181.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label181.DataField = "PolicyClassDesc";
            this.Label181.Height = 0.2F;
            this.Label181.HyperLink = "";
            this.Label181.Left = 2.0625F;
            this.Label181.Name = "Label181";
            this.Label181.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label181.Text = "";
            this.Label181.Top = 0F;
            this.Label181.Width = 2.7225F;
            // 
            // Label186
            // 
            this.Label186.Border.BottomColor = System.Drawing.Color.Black;
            this.Label186.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label186.Border.LeftColor = System.Drawing.Color.Black;
            this.Label186.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label186.Border.RightColor = System.Drawing.Color.Black;
            this.Label186.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label186.Border.TopColor = System.Drawing.Color.Black;
            this.Label186.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label186.Height = 0.2F;
            this.Label186.HyperLink = "";
            this.Label186.Left = 5.5F;
            this.Label186.Name = "Label186";
            this.Label186.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label186.Text = "New Contracts";
            this.Label186.Top = 0F;
            this.Label186.Width = 0.9375F;
            // 
            // Label187
            // 
            this.Label187.Border.BottomColor = System.Drawing.Color.Black;
            this.Label187.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label187.Border.LeftColor = System.Drawing.Color.Black;
            this.Label187.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label187.Border.RightColor = System.Drawing.Color.Black;
            this.Label187.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label187.Border.TopColor = System.Drawing.Color.Black;
            this.Label187.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label187.Height = 0.2F;
            this.Label187.HyperLink = "";
            this.Label187.Left = 5.5F;
            this.Label187.Name = "Label187";
            this.Label187.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label187.Text = "Cancellations";
            this.Label187.Top = 0.125F;
            this.Label187.Width = 0.9375F;
            // 
            // Label188
            // 
            this.Label188.Border.BottomColor = System.Drawing.Color.Black;
            this.Label188.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label188.Border.LeftColor = System.Drawing.Color.Black;
            this.Label188.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label188.Border.RightColor = System.Drawing.Color.Black;
            this.Label188.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label188.Border.TopColor = System.Drawing.Color.Black;
            this.Label188.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label188.Height = 0.2F;
            this.Label188.HyperLink = "";
            this.Label188.Left = 5.5F;
            this.Label188.Name = "Label188";
            this.Label188.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label188.Text = "Net >>>>>>>";
            this.Label188.Top = 0.25F;
            this.Label188.Width = 0.9375F;
            // 
            // TextBox107
            // 
            this.TextBox107.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox107.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox107.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox107.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox107.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox107.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox107.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox107.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox107.DataField = "CancCount";
            this.TextBox107.Height = 0.1875F;
            this.TextBox107.Left = 6.5625F;
            this.TextBox107.Name = "TextBox107";
            this.TextBox107.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox107.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox107.SummaryGroup = "GroupHeader2";
            this.TextBox107.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox107.Text = null;
            this.TextBox107.Top = 0.125F;
            this.TextBox107.Width = 0.625F;
            // 
            // TextBox108
            // 
            this.TextBox108.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox108.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox108.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox108.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox108.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox108.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox108.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox108.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox108.DataField = "PrmCount";
            this.TextBox108.Height = 0.1875F;
            this.TextBox108.Left = 6.5625F;
            this.TextBox108.Name = "TextBox108";
            this.TextBox108.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox108.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox108.SummaryGroup = "GroupHeader2";
            this.TextBox108.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox108.Text = null;
            this.TextBox108.Top = 0F;
            this.TextBox108.Width = 0.625F;
            // 
            // TextBox109
            // 
            this.TextBox109.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox109.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox109.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox109.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox109.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox109.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox109.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox109.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox109.DataField = "TotalPremium";
            this.TextBox109.Height = 0.1875F;
            this.TextBox109.Left = 8.12F;
            this.TextBox109.Name = "TextBox109";
            this.TextBox109.OutputFormat = resources.GetString("TextBox109.OutputFormat");
            this.TextBox109.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox109.SummaryGroup = "GroupHeader2";
            this.TextBox109.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox109.Text = null;
            this.TextBox109.Top = 0F;
            this.TextBox109.Width = 0.88F;
            // 
            // TextBox110
            // 
            this.TextBox110.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox110.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox110.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox110.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox110.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox110.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox110.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox110.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox110.DataField = "CancellationAmount";
            this.TextBox110.Height = 0.1925F;
            this.TextBox110.Left = 8.12F;
            this.TextBox110.Name = "TextBox110";
            this.TextBox110.OutputFormat = resources.GetString("TextBox110.OutputFormat");
            this.TextBox110.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox110.SummaryGroup = "GroupHeader2";
            this.TextBox110.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox110.Text = null;
            this.TextBox110.Top = 0.12F;
            this.TextBox110.Width = 0.88F;
            // 
            // TextBox111
            // 
            this.TextBox111.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox111.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox111.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox111.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox111.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox111.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox111.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox111.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox111.DataField = "PremNet";
            this.TextBox111.Height = 0.1975F;
            this.TextBox111.Left = 8.12F;
            this.TextBox111.Name = "TextBox111";
            this.TextBox111.OutputFormat = resources.GetString("TextBox111.OutputFormat");
            this.TextBox111.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox111.SummaryGroup = "GroupHeader2";
            this.TextBox111.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox111.Text = null;
            this.TextBox111.Top = 0.24F;
            this.TextBox111.Width = 0.88F;
            // 
            // TextBox112
            // 
            this.TextBox112.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox112.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox112.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox112.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox112.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox112.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox112.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox112.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox112.DataField = "PremComm";
            this.TextBox112.Height = 0.125F;
            this.TextBox112.Left = 9.6F;
            this.TextBox112.Name = "TextBox112";
            this.TextBox112.OutputFormat = resources.GetString("TextBox112.OutputFormat");
            this.TextBox112.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox112.SummaryGroup = "GroupHeader2";
            this.TextBox112.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox112.Text = null;
            this.TextBox112.Top = 0F;
            this.TextBox112.Width = 0.9F;
            // 
            // TextBox113
            // 
            this.TextBox113.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox113.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox113.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox113.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox113.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox113.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox113.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox113.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox113.DataField = "CancComm";
            this.TextBox113.Height = 0.125F;
            this.TextBox113.Left = 9.6F;
            this.TextBox113.Name = "TextBox113";
            this.TextBox113.OutputFormat = resources.GetString("TextBox113.OutputFormat");
            this.TextBox113.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox113.SummaryGroup = "GroupHeader2";
            this.TextBox113.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox113.Text = null;
            this.TextBox113.Top = 0.125F;
            this.TextBox113.Width = 0.9F;
            // 
            // TextBox114
            // 
            this.TextBox114.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox114.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox114.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox114.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox114.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox114.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox114.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox114.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox114.DataField = "CommNet";
            this.TextBox114.Height = 0.125F;
            this.TextBox114.Left = 9.6F;
            this.TextBox114.Name = "TextBox114";
            this.TextBox114.OutputFormat = resources.GetString("TextBox114.OutputFormat");
            this.TextBox114.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox114.SummaryGroup = "GroupHeader2";
            this.TextBox114.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox114.Text = null;
            this.TextBox114.Top = 0.25F;
            this.TextBox114.Width = 0.9F;
            // 
            // PremiumWrittenBySupplies
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
            this.PrintWidth = 11.33333F;
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
            this.ReportStart += new System.EventHandler(this.PremiumWrittenBySupplies_ReportStart);
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
            ((System.ComponentModel.ISupportInitialize)(this.TextBox78)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox84)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox85)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label127)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label167)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label168)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label169)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox68)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox106)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label171)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblComissions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label176)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label177)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSupplies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSupplyCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuplyName)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.TextBox101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox103)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label178)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label179)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label180)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label181)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label186)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label187)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label188)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox110)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox112)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox113)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox114)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
