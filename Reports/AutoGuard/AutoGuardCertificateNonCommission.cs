using System;
using System.Data;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.LookupTables;
using EPolicy.TaskControl;


namespace EPolicy2.Reports
{
	public class AutoGuardCertificateNonCommission : DataDynamics.ActiveReports.ActiveReport3
	{
		private string _FromDate;
		private string _ToDate;
		private string _ReportType;
		private bool   _Summary = false;
        string _mHeadCompany = "";
		//private decimal totprem = 0;
		//private decimal cancAmt = 0;
		//private string mdealer = "";
		//private decimal a = 0;
		private DataTable _dt = null;
		//private int index = 1;


        public AutoGuardCertificateNonCommission(string FromDate, string ToDate, string ReportType, bool Summary, DataTable table, string mHeadCompany)
		{
			_FromDate   = FromDate;
			_ToDate     = ToDate;
			_ReportType = ReportType;
			_Summary    =  Summary;
			_dt			= table;
            _mHeadCompany = mHeadCompany;

			InitializeComponent();
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void AutoGuardCertificateNonCommission_ReportStart(object sender, System.EventArgs eArgs)
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

		
		private void GroupFooter2_Format(object sender, System.EventArgs eArgs)
		{
			
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
		private DataDynamics.ActiveReports.Label Label146 = null;
		private DataDynamics.ActiveReports.Label Label148 = null;
		private DataDynamics.ActiveReports.Label Label149 = null;
		private DataDynamics.ActiveReports.Label Label167 = null;
		private DataDynamics.ActiveReports.Label Label168 = null;
		private DataDynamics.ActiveReports.Label Label170 = null;
		private DataDynamics.ActiveReports.Label Label171 = null;
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
		private DataDynamics.ActiveReports.TextBox txtCustomerName = null;
		private DataDynamics.ActiveReports.TextBox txtEffectiveDate = null;
		private DataDynamics.ActiveReports.TextBox txtEntryDate = null;
		private DataDynamics.ActiveReports.TextBox TextBox22 = null;
		private DataDynamics.ActiveReports.TextBox txtTotalPremium = null;
		private DataDynamics.ActiveReports.TextBox TextBox20 = null;
		private DataDynamics.ActiveReports.TextBox TextBox50 = null;
		private DataDynamics.ActiveReports.TextBox TextBox46 = null;
		private DataDynamics.ActiveReports.TextBox TextBox47 = null;
		private DataDynamics.ActiveReports.TextBox TextBox51 = null;
		private DataDynamics.ActiveReports.TextBox TextBox52 = null;
		private DataDynamics.ActiveReports.TextBox TextBox53 = null;
		private DataDynamics.ActiveReports.TextBox TextBox61 = null;
		private DataDynamics.ActiveReports.TextBox TextBox75 = null;
		private DataDynamics.ActiveReports.TextBox TextBox76 = null;
		private DataDynamics.ActiveReports.TextBox TextBox77 = null;
		private DataDynamics.ActiveReports.TextBox TextBox78 = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter2 = null;
		private DataDynamics.ActiveReports.Label Label162 = null;
		private DataDynamics.ActiveReports.Label Label163 = null;
		private DataDynamics.ActiveReports.TextBox TextBox69 = null;
		private DataDynamics.ActiveReports.TextBox TextBox70 = null;
		private DataDynamics.ActiveReports.TextBox TextBox71 = null;
		private DataDynamics.ActiveReports.TextBox TextBox72 = null;
		private DataDynamics.ActiveReports.Label Label164 = null;
		private DataDynamics.ActiveReports.Label Label165 = null;
		private DataDynamics.ActiveReports.TextBox TextBox73 = null;
		private DataDynamics.ActiveReports.Label Label166 = null;
		private DataDynamics.ActiveReports.TextBox TextBox74 = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1 = null;
		private DataDynamics.ActiveReports.Label Label134 = null;
		private DataDynamics.ActiveReports.Label Label135 = null;
		private DataDynamics.ActiveReports.TextBox TextBox25 = null;
		private DataDynamics.ActiveReports.TextBox TextBox36 = null;
		private DataDynamics.ActiveReports.TextBox TextBox24 = null;
		private DataDynamics.ActiveReports.TextBox TextBox48 = null;
		private DataDynamics.ActiveReports.Label Label153 = null;
		private DataDynamics.ActiveReports.Label Label154 = null;
		private DataDynamics.ActiveReports.TextBox TxtNetPrem = null;
		private DataDynamics.ActiveReports.Label Label155 = null;
		private DataDynamics.ActiveReports.TextBox TextBox67 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		private DataDynamics.ActiveReports.TextBox TextBox37 = null;
		private DataDynamics.ActiveReports.TextBox TextBox18 = null;
		private DataDynamics.ActiveReports.TextBox TextBox21 = null;
		private DataDynamics.ActiveReports.Line Line9 = null;
		private DataDynamics.ActiveReports.TextBox TextBox19 = null;
		private DataDynamics.ActiveReports.Label Label147 = null;
		private DataDynamics.ActiveReports.TextBox TextBox63 = null;
		private DataDynamics.ActiveReports.Label Label156 = null;
		private DataDynamics.ActiveReports.Label Label157 = null;
		private DataDynamics.ActiveReports.Label Label158 = null;
		private DataDynamics.ActiveReports.TextBox TextBox68 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoGuardCertificateNonCommission));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.txtTaskControlID = new DataDynamics.ActiveReports.TextBox();
            this.TxtRegCode = new DataDynamics.ActiveReports.TextBox();
            this.txtCustomerName = new DataDynamics.ActiveReports.TextBox();
            this.txtEffectiveDate = new DataDynamics.ActiveReports.TextBox();
            this.txtEntryDate = new DataDynamics.ActiveReports.TextBox();
            this.TextBox22 = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalPremium = new DataDynamics.ActiveReports.TextBox();
            this.TextBox20 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox50 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox46 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox47 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox51 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox52 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox53 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox61 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox75 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox76 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox77 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox78 = new DataDynamics.ActiveReports.TextBox();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.TextBox37 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox18 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox21 = new DataDynamics.ActiveReports.TextBox();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.TextBox19 = new DataDynamics.ActiveReports.TextBox();
            this.Label147 = new DataDynamics.ActiveReports.Label();
            this.TextBox63 = new DataDynamics.ActiveReports.TextBox();
            this.Label156 = new DataDynamics.ActiveReports.Label();
            this.Label157 = new DataDynamics.ActiveReports.Label();
            this.Label158 = new DataDynamics.ActiveReports.Label();
            this.TextBox68 = new DataDynamics.ActiveReports.TextBox();
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
            this.Label113 = new DataDynamics.ActiveReports.Label();
            this.Label125 = new DataDynamics.ActiveReports.Label();
            this.Label142 = new DataDynamics.ActiveReports.Label();
            this.Label143 = new DataDynamics.ActiveReports.Label();
            this.Label144 = new DataDynamics.ActiveReports.Label();
            this.Label129 = new DataDynamics.ActiveReports.Label();
            this.Label122 = new DataDynamics.ActiveReports.Label();
            this.Label128 = new DataDynamics.ActiveReports.Label();
            this.Label146 = new DataDynamics.ActiveReports.Label();
            this.Label148 = new DataDynamics.ActiveReports.Label();
            this.Label149 = new DataDynamics.ActiveReports.Label();
            this.Label167 = new DataDynamics.ActiveReports.Label();
            this.Label168 = new DataDynamics.ActiveReports.Label();
            this.Label170 = new DataDynamics.ActiveReports.Label();
            this.Label171 = new DataDynamics.ActiveReports.Label();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.GroupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.Label130 = new DataDynamics.ActiveReports.Label();
            this.Label131 = new DataDynamics.ActiveReports.Label();
            this.Label132 = new DataDynamics.ActiveReports.Label();
            this.GroupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.Label134 = new DataDynamics.ActiveReports.Label();
            this.Label135 = new DataDynamics.ActiveReports.Label();
            this.TextBox25 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox36 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox24 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox48 = new DataDynamics.ActiveReports.TextBox();
            this.Label153 = new DataDynamics.ActiveReports.Label();
            this.Label154 = new DataDynamics.ActiveReports.Label();
            this.TxtNetPrem = new DataDynamics.ActiveReports.TextBox();
            this.Label155 = new DataDynamics.ActiveReports.Label();
            this.TextBox67 = new DataDynamics.ActiveReports.TextBox();
            this.GroupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.Label159 = new DataDynamics.ActiveReports.Label();
            this.Label160 = new DataDynamics.ActiveReports.Label();
            this.Label161 = new DataDynamics.ActiveReports.Label();
            this.GroupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.Label162 = new DataDynamics.ActiveReports.Label();
            this.Label163 = new DataDynamics.ActiveReports.Label();
            this.TextBox69 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox70 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox71 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox72 = new DataDynamics.ActiveReports.TextBox();
            this.Label164 = new DataDynamics.ActiveReports.Label();
            this.Label165 = new DataDynamics.ActiveReports.Label();
            this.TextBox73 = new DataDynamics.ActiveReports.TextBox();
            this.Label166 = new DataDynamics.ActiveReports.Label();
            this.TextBox74 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaskControlID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRegCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox76)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox78)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label147)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label156)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label157)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label158)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox68)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.Label146)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label148)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label149)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label167)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label168)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label170)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label171)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label153)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label154)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNetPrem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label155)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox67)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label159)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label160)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label161)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label162)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label163)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox69)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox72)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label164)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label165)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox73)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label166)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox74)).BeginInit();
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
            this.TextBox50,
            this.TextBox46,
            this.TextBox47,
            this.TextBox51,
            this.TextBox52,
            this.TextBox53,
            this.TextBox61,
            this.TextBox75,
            this.TextBox76,
            this.TextBox77,
            this.TextBox78});
            this.Detail.Height = 0.2909722F;
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
            this.txtTaskControlID.Left = 0.3229166F;
            this.txtTaskControlID.Name = "txtTaskControlID";
            this.txtTaskControlID.Style = "text-align: left; font-size: 7pt; ";
            this.txtTaskControlID.Text = null;
            this.txtTaskControlID.Top = 0F;
            this.txtTaskControlID.Width = 0.7395833F;
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
            this.TxtRegCode.MultiLine = false;
            this.TxtRegCode.Name = "TxtRegCode";
            this.TxtRegCode.Style = "text-align: left; font-size: 7pt; ";
            this.TxtRegCode.Text = null;
            this.TxtRegCode.Top = 0F;
            this.TxtRegCode.Width = 1.1875F;
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
            this.txtCustomerName.Left = 2.427083F;
            this.txtCustomerName.MultiLine = false;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Style = "text-align: left; font-size: 7pt; ";
            this.txtCustomerName.Text = null;
            this.txtCustomerName.Top = 0F;
            this.txtCustomerName.Width = 1.635417F;
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
            this.txtEffectiveDate.Left = 9.6875F;
            this.txtEffectiveDate.Name = "txtEffectiveDate";
            this.txtEffectiveDate.OutputFormat = resources.GetString("txtEffectiveDate.OutputFormat");
            this.txtEffectiveDate.Style = "text-align: left; font-size: 7pt; ";
            this.txtEffectiveDate.Text = null;
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
            this.txtEntryDate.Left = 10.375F;
            this.txtEntryDate.Name = "txtEntryDate";
            this.txtEntryDate.OutputFormat = resources.GetString("txtEntryDate.OutputFormat");
            this.txtEntryDate.Style = "text-align: left; font-size: 7pt; ";
            this.txtEntryDate.Text = null;
            this.txtEntryDate.Top = 0F;
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
            this.TextBox22.Left = 11.0625F;
            this.TextBox22.Name = "TextBox22";
            this.TextBox22.OutputFormat = resources.GetString("TextBox22.OutputFormat");
            this.TextBox22.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox22.Text = null;
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
            this.txtTotalPremium.Left = 12.4375F;
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
            this.TextBox20.Left = 12.4375F;
            this.TextBox20.Name = "TextBox20";
            this.TextBox20.OutputFormat = resources.GetString("TextBox20.OutputFormat");
            this.TextBox20.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox20.Text = null;
            this.TextBox20.Top = 0.125F;
            this.TextBox20.Width = 0.6979167F;
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
            this.TextBox50.Left = 11.75F;
            this.TextBox50.Name = "TextBox50";
            this.TextBox50.OutputFormat = resources.GetString("TextBox50.OutputFormat");
            this.TextBox50.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox50.Text = null;
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
            this.TextBox46.Left = 8.5F;
            this.TextBox46.Name = "TextBox46";
            this.TextBox46.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox46.Text = null;
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
            this.TextBox47.Left = 8.5F;
            this.TextBox47.Name = "TextBox47";
            this.TextBox47.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox47.Text = null;
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
            this.TextBox51.Left = 9.072917F;
            this.TextBox51.Name = "TextBox51";
            this.TextBox51.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox51.Text = null;
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
            this.TextBox52.Left = 9.072917F;
            this.TextBox52.Name = "TextBox52";
            this.TextBox52.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox52.Text = null;
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
            this.TextBox53.Left = 11.0625F;
            this.TextBox53.Name = "TextBox53";
            this.TextBox53.OutputFormat = resources.GetString("TextBox53.OutputFormat");
            this.TextBox53.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox53.Text = null;
            this.TextBox53.Top = 0F;
            this.TextBox53.Width = 0.625F;
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
            this.TextBox61.Left = 12.5625F;
            this.TextBox61.Name = "TextBox61";
            this.TextBox61.OutputFormat = resources.GetString("TextBox61.OutputFormat");
            this.TextBox61.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox61.Text = "PremNet";
            this.TextBox61.Top = 0.0625F;
            this.TextBox61.Visible = false;
            this.TextBox61.Width = 0.6979167F;
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
            this.TextBox75.DataField = "make";
            this.TextBox75.Height = 0.125F;
            this.TextBox75.Left = 4.125F;
            this.TextBox75.Name = "TextBox75";
            this.TextBox75.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox75.Text = null;
            this.TextBox75.Top = 0F;
            this.TextBox75.Width = 1.125F;
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
            this.TextBox76.DataField = "model";
            this.TextBox76.Height = 0.125F;
            this.TextBox76.Left = 5.3125F;
            this.TextBox76.Name = "TextBox76";
            this.TextBox76.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox76.Text = null;
            this.TextBox76.Top = 0F;
            this.TextBox76.Width = 1.1875F;
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
            this.TextBox77.DataField = "yr";
            this.TextBox77.Height = 0.125F;
            this.TextBox77.Left = 6.5625F;
            this.TextBox77.Name = "TextBox77";
            this.TextBox77.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox77.Text = null;
            this.TextBox77.Top = 0F;
            this.TextBox77.Width = 0.5F;
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
            this.TextBox78.DataField = "vin";
            this.TextBox78.Height = 0.125F;
            this.TextBox78.Left = 7.125F;
            this.TextBox78.Name = "TextBox78";
            this.TextBox78.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox78.Text = null;
            this.TextBox78.Top = 0F;
            this.TextBox78.Width = 1.3125F;
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
            this.Label156,
            this.Label157,
            this.Label158,
            this.TextBox68});
            this.ReportFooter.Height = 0.4493056F;
            this.ReportFooter.KeepTogether = true;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.NewPage = DataDynamics.ActiveReports.NewPage.Before;
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
            this.TextBox37.Left = 11.375F;
            this.TextBox37.Name = "TextBox37";
            this.TextBox37.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox37.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox37.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox37.Text = null;
            this.TextBox37.Top = 0.125F;
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
            this.TextBox18.Left = 12.4375F;
            this.TextBox18.Name = "TextBox18";
            this.TextBox18.OutputFormat = resources.GetString("TextBox18.OutputFormat");
            this.TextBox18.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: Arial; ";
            this.TextBox18.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox18.Text = null;
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
            this.TextBox21.Left = 12.4375F;
            this.TextBox21.Name = "TextBox21";
            this.TextBox21.OutputFormat = resources.GetString("TextBox21.OutputFormat");
            this.TextBox21.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: Arial; ";
            this.TextBox21.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox21.Text = null;
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
            this.Line9.Width = 12.91667F;
            this.Line9.X1 = 0.3958333F;
            this.Line9.X2 = 13.3125F;
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
            this.TextBox19.Text = null;
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
            this.TextBox63.Left = 12.4375F;
            this.TextBox63.Name = "TextBox63";
            this.TextBox63.OutputFormat = resources.GetString("TextBox63.OutputFormat");
            this.TextBox63.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox63.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox63.Text = null;
            this.TextBox63.Top = 0.25F;
            this.TextBox63.Width = 0.6875F;
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
            this.Label156.Left = 10.375F;
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
            this.Label157.Left = 10.375F;
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
            this.Label158.Left = 10.375F;
            this.Label158.Name = "Label158";
            this.Label158.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label158.Text = "Net >>>>>>>";
            this.Label158.Top = 0.25F;
            this.Label158.Width = 0.9375F;
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
            this.TextBox68.DataField = "CommissionDate";
            this.TextBox68.Height = 0.1875F;
            this.TextBox68.Left = 11.375F;
            this.TextBox68.Name = "TextBox68";
            this.TextBox68.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox68.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox68.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox68.Text = null;
            this.TextBox68.Top = 0F;
            this.TextBox68.Width = 0.6875F;
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
            this.Label146,
            this.Label148,
            this.Label149,
            this.Label167,
            this.Label168,
            this.Label170,
            this.Label171,
            this.Label75,
            this.Label77});
            this.PageHeader.Height = 1F;
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
            this.lblCriterias.Left = 4.125F;
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
            this.Label80.Left = 12.1875F;
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
            this.TextBox17.Left = 12.6875F;
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
            this.Label109.Left = 10.375F;
            this.Label109.Name = "Label109";
            this.Label109.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label109.Text = "Entry Date";
            this.Label109.Top = 0.6875F;
            this.Label109.Width = 0.625F;
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
            this.Label113.Left = 2.4375F;
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
            this.Label125.Left = 9.625F;
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
            this.Label142.Left = 8.4375F;
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
            this.Label143.Left = 8.4375F;
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
            this.Label144.Left = 9.0625F;
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
            this.Label129.Left = 11.0625F;
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
            this.Label122.Left = 12.5625F;
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
            this.Label128.Left = 12.5F;
            this.Label128.MultiLine = false;
            this.Label128.Name = "Label128";
            this.Label128.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label128.Text = "Canc. Amount";
            this.Label128.Top = 0.8125F;
            this.Label128.Width = 0.8125F;
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
            this.Label146.Left = 11.6875F;
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
            this.Label148.Left = 8.9375F;
            this.Label148.Name = "Label148";
            this.Label148.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label148.Text = "Co. Dealer";
            this.Label148.Top = 0.8125F;
            this.Label148.Width = 0.6875F;
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
            this.Label149.Left = 11.0625F;
            this.Label149.Name = "Label149";
            this.Label149.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label149.Text = "Exp. Date";
            this.Label149.Top = 0.6875F;
            this.Label149.Width = 0.6875F;
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
            this.Label167.Height = 0.1875F;
            this.Label167.HyperLink = "";
            this.Label167.Left = 4.125F;
            this.Label167.Name = "Label167";
            this.Label167.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label167.Text = "Make";
            this.Label167.Top = 0.6875F;
            this.Label167.Width = 0.4375F;
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
            this.Label168.Height = 0.1875F;
            this.Label168.HyperLink = "";
            this.Label168.Left = 5.3125F;
            this.Label168.Name = "Label168";
            this.Label168.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label168.Text = "Model";
            this.Label168.Top = 0.6875F;
            this.Label168.Width = 0.4375F;
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
            this.Label170.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label170.Text = "Year";
            this.Label170.Top = 0.6875F;
            this.Label170.Width = 0.375F;
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
            this.Label171.Left = 7.1875F;
            this.Label171.Name = "Label171";
            this.Label171.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label171.Text = "VIN";
            this.Label171.Top = 0.6875F;
            this.Label171.Width = 0.5F;
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
            this.Label75.Left = 4.125F;
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
            this.Label77.Left = 4.125F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-align: center; font-weight: bold; font-size: 6pt; font-family: Times New Rom" +
                "an; ";
            this.Label77.Text = "";
            this.Label77.Top = 0.25F;
            this.Label77.Width = 5.125F;
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
            this.GroupHeader1.KeepTogether = true;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.NewPage = DataDynamics.ActiveReports.NewPage.Before;
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
            this.Label130.Width = 1.229167F;
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
            this.Label131.Left = 1.4375F;
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
            this.Label132.Left = 1.9375F;
            this.Label132.Name = "Label132";
            this.Label132.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label132.Text = "";
            this.Label132.Top = 0F;
            this.Label132.Width = 2.5625F;
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
            this.Label153,
            this.Label154,
            this.TxtNetPrem,
            this.Label155,
            this.TextBox67});
            this.GroupFooter1.Height = 0.4493056F;
            this.GroupFooter1.KeepTogether = true;
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
            this.Label134.Height = 0.2F;
            this.Label134.HyperLink = "";
            this.Label134.Left = 0.2083333F;
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
            this.TextBox25.Text = null;
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
            this.TextBox36.Left = 11.375F;
            this.TextBox36.Name = "TextBox36";
            this.TextBox36.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox36.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox36.SummaryGroup = "GroupHeader1";
            this.TextBox36.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox36.Text = null;
            this.TextBox36.Top = 0.125F;
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
            this.TextBox24.Left = 12.4375F;
            this.TextBox24.Name = "TextBox24";
            this.TextBox24.OutputFormat = resources.GetString("TextBox24.OutputFormat");
            this.TextBox24.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox24.SummaryGroup = "GroupHeader1";
            this.TextBox24.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox24.Text = null;
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
            this.TextBox48.Left = 12.4375F;
            this.TextBox48.Name = "TextBox48";
            this.TextBox48.OutputFormat = resources.GetString("TextBox48.OutputFormat");
            this.TextBox48.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox48.SummaryGroup = "GroupHeader1";
            this.TextBox48.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox48.Text = null;
            this.TextBox48.Top = 0.125F;
            this.TextBox48.Width = 0.6875F;
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
            this.Label153.Left = 10.375F;
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
            this.Label154.Left = 10.375F;
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
            this.TxtNetPrem.Left = 12.4375F;
            this.TxtNetPrem.Name = "TxtNetPrem";
            this.TxtNetPrem.OutputFormat = resources.GetString("TxtNetPrem.OutputFormat");
            this.TxtNetPrem.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TxtNetPrem.SummaryGroup = "GroupHeader1";
            this.TxtNetPrem.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TxtNetPrem.Text = null;
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
            this.Label155.Left = 10.375F;
            this.Label155.Name = "Label155";
            this.Label155.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label155.Text = "Net >>>>>>>";
            this.Label155.Top = 0.25F;
            this.Label155.Width = 0.9375F;
            // 
            // TextBox67
            // 
            this.TextBox67.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox67.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox67.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox67.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox67.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox67.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox67.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox67.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox67.DataField = "CommissionDate";
            this.TextBox67.Height = 0.1875F;
            this.TextBox67.Left = 11.375F;
            this.TextBox67.Name = "TextBox67";
            this.TextBox67.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox67.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox67.SummaryGroup = "GroupHeader1";
            this.TextBox67.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox67.Text = null;
            this.TextBox67.Top = 0F;
            this.TextBox67.Width = 0.625F;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label159,
            this.Label160,
            this.Label161});
            this.GroupHeader2.DataField = "InsuranceCompany";
            this.GroupHeader2.Height = 0.2076389F;
            this.GroupHeader2.Name = "GroupHeader2";
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
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label162,
            this.Label163,
            this.TextBox69,
            this.TextBox70,
            this.TextBox71,
            this.TextBox72,
            this.Label164,
            this.Label165,
            this.TextBox73,
            this.Label166,
            this.TextBox74});
            this.GroupFooter2.Height = 0.4493056F;
            this.GroupFooter2.KeepTogether = true;
            this.GroupFooter2.Name = "GroupFooter2";
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
            this.TextBox69.Text = null;
            this.TextBox69.Top = 0F;
            this.TextBox69.Width = 0.8958333F;
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
            this.TextBox70.DataField = "CancellationEntryDate";
            this.TextBox70.Height = 0.1875F;
            this.TextBox70.Left = 11.375F;
            this.TextBox70.Name = "TextBox70";
            this.TextBox70.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox70.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox70.SummaryGroup = "GroupHeader2";
            this.TextBox70.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox70.Text = null;
            this.TextBox70.Top = 0.125F;
            this.TextBox70.Width = 0.625F;
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
            this.TextBox71.DataField = "TotalPremium";
            this.TextBox71.Height = 0.1875F;
            this.TextBox71.Left = 12.4375F;
            this.TextBox71.Name = "TextBox71";
            this.TextBox71.OutputFormat = resources.GetString("TextBox71.OutputFormat");
            this.TextBox71.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox71.SummaryGroup = "GroupHeader2";
            this.TextBox71.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox71.Text = null;
            this.TextBox71.Top = 0F;
            this.TextBox71.Width = 0.6875F;
            // 
            // TextBox72
            // 
            this.TextBox72.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox72.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox72.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox72.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox72.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox72.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox72.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox72.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox72.DataField = "CancellationAmount";
            this.TextBox72.Height = 0.1875F;
            this.TextBox72.Left = 12.4375F;
            this.TextBox72.Name = "TextBox72";
            this.TextBox72.OutputFormat = resources.GetString("TextBox72.OutputFormat");
            this.TextBox72.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox72.SummaryGroup = "GroupHeader2";
            this.TextBox72.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox72.Text = null;
            this.TextBox72.Top = 0.125F;
            this.TextBox72.Width = 0.6875F;
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
            this.Label164.Left = 10.375F;
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
            this.Label165.Left = 10.375F;
            this.Label165.Name = "Label165";
            this.Label165.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label165.Text = "Cancellations";
            this.Label165.Top = 0.125F;
            this.Label165.Width = 0.9375F;
            // 
            // TextBox73
            // 
            this.TextBox73.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox73.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox73.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox73.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox73.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox73.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox73.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox73.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox73.DataField = "PremNet";
            this.TextBox73.Height = 0.1875F;
            this.TextBox73.Left = 12.4375F;
            this.TextBox73.Name = "TextBox73";
            this.TextBox73.OutputFormat = resources.GetString("TextBox73.OutputFormat");
            this.TextBox73.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox73.SummaryGroup = "GroupHeader2";
            this.TextBox73.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox73.Text = null;
            this.TextBox73.Top = 0.25F;
            this.TextBox73.Width = 0.6875F;
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
            this.Label166.Left = 10.375F;
            this.Label166.Name = "Label166";
            this.Label166.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label166.Text = "Net >>>>>>>";
            this.Label166.Top = 0.25F;
            this.Label166.Width = 0.9375F;
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
            this.TextBox74.DataField = "CommissionDate";
            this.TextBox74.Height = 0.1875F;
            this.TextBox74.Left = 11.375F;
            this.TextBox74.Name = "TextBox74";
            this.TextBox74.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox74.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox74.SummaryGroup = "GroupHeader2";
            this.TextBox74.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox74.Text = null;
            this.TextBox74.Top = 0F;
            this.TextBox74.Width = 0.625F;
            // 
            // AutoGuardCertificateNonCommission
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.1F;
            this.PageSettings.Margins.Left = 0.1F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.1F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 14F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Legal;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 13.53125F;
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
            this.ReportStart += new System.EventHandler(this.AutoGuardCertificateNonCommission_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.txtTaskControlID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRegCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox76)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox78)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label147)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label156)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label157)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label158)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox68)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.Label146)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label148)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label149)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label167)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label168)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label170)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label171)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label153)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label154)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNetPrem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label155)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox67)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label159)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label160)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label161)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label162)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label163)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox69)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox72)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label164)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label165)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox73)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label166)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox74)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

		#endregion
	}
}
