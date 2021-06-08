using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports
{
	public class AutoGuardPremiumAndComissionEarned : DataDynamics.ActiveReports.ActiveReport3
	{
		string _FromDate;
		string _ToDate;
		string _ReportType;
		string _cancDate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
		bool   _Summary = false;

		public AutoGuardPremiumAndComissionEarned(string FromDate,string ToDate, string ReportType, string cancDate, bool Summary)
		{
			_FromDate = FromDate;
			_ToDate = ToDate;
			_ReportType = ReportType;
			_cancDate = cancDate;
			_Summary  =  Summary;

			InitializeComponent();
		}

		private void GroupHeader1_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void AutoGuardPremiumAndComissionEarned_ReportStart(object sender, System.EventArgs eArgs)
		{
			if (_Summary)
			{
				this.Detail.Visible = false;
			}
			this.lblDate.Text = "Date:"+DateTime.Now.ToShortDateString();
			this.lblTime.Text = "Time:"+DateTime.Now.ToShortTimeString();
			this.LblAsOff.Text = "As Off: "+_cancDate+"  -  Cancellation Method: ProRata";
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
		private DataDynamics.ActiveReports.Label Label129 = null;
		private DataDynamics.ActiveReports.Label Label122 = null;
		private DataDynamics.ActiveReports.Label Label128 = null;
		private DataDynamics.ActiveReports.Label Label146 = null;
		private DataDynamics.ActiveReports.Label Label149 = null;
		private DataDynamics.ActiveReports.Label Label150 = null;
		private DataDynamics.ActiveReports.Label Label151 = null;
		private DataDynamics.ActiveReports.Label Label152 = null;
		private DataDynamics.ActiveReports.Label Label153 = null;
		private DataDynamics.ActiveReports.Label Label154 = null;
		private DataDynamics.ActiveReports.Label Label155 = null;
		private DataDynamics.ActiveReports.Label Label156 = null;
		private DataDynamics.ActiveReports.Label LblAsOff = null;
		private DataDynamics.ActiveReports.Label Label172 = null;
		private DataDynamics.ActiveReports.Label Label173 = null;
		private DataDynamics.ActiveReports.Label Label174 = null;
		private DataDynamics.ActiveReports.Label Label175 = null;
		private DataDynamics.ActiveReports.Label Label75 = null;
        private DataDynamics.ActiveReports.Label Label77 = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader2 = null;
		private DataDynamics.ActiveReports.Label Label130 = null;
		private DataDynamics.ActiveReports.Label Label131 = null;
		private DataDynamics.ActiveReports.Label Label132 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox txtEntryDate = null;
		private DataDynamics.ActiveReports.TextBox txtEffectiveDate = null;
		private DataDynamics.ActiveReports.TextBox TextBox53 = null;
		private DataDynamics.ActiveReports.TextBox TextBox22 = null;
		private DataDynamics.ActiveReports.TextBox txtTotalPremium = null;
		private DataDynamics.ActiveReports.TextBox TextBox20 = null;
		private DataDynamics.ActiveReports.TextBox TextBox75 = null;
		private DataDynamics.ActiveReports.TextBox TextBox76 = null;
		private DataDynamics.ActiveReports.TextBox TextBox77 = null;
		private DataDynamics.ActiveReports.TextBox TextBox78 = null;
		private DataDynamics.ActiveReports.TextBox txtTaskControlID = null;
		private DataDynamics.ActiveReports.TextBox TxtRegCode = null;
		private DataDynamics.ActiveReports.TextBox txtCustomerName = null;
		private DataDynamics.ActiveReports.TextBox TextBox80 = null;
		private DataDynamics.ActiveReports.TextBox TextBox81 = null;
		private DataDynamics.ActiveReports.TextBox TextBox93 = null;
		private DataDynamics.ActiveReports.TextBox TextBox94 = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter2 = null;
		private DataDynamics.ActiveReports.Label Label134 = null;
		private DataDynamics.ActiveReports.Label Label135 = null;
		private DataDynamics.ActiveReports.Label Label164 = null;
		private DataDynamics.ActiveReports.Label Label165 = null;
		private DataDynamics.ActiveReports.TextBox TextBox70 = null;
		private DataDynamics.ActiveReports.TextBox TextBox74 = null;
		private DataDynamics.ActiveReports.TextBox TextBox72 = null;
		private DataDynamics.ActiveReports.TextBox TextBox82 = null;
		private DataDynamics.ActiveReports.TextBox TextBox83 = null;
		private DataDynamics.ActiveReports.TextBox TextBox84 = null;
		private DataDynamics.ActiveReports.TextBox TextBox71 = null;
		private DataDynamics.ActiveReports.TextBox TextBox95 = null;
        private DataDynamics.ActiveReports.TextBox TextBox96 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		private DataDynamics.ActiveReports.Line Line9 = null;
		private DataDynamics.ActiveReports.Label Label147 = null;
		private DataDynamics.ActiveReports.TextBox TextBox18 = null;
		private DataDynamics.ActiveReports.TextBox TextBox21 = null;
		private DataDynamics.ActiveReports.TextBox TextBox88 = null;
		private DataDynamics.ActiveReports.TextBox TextBox89 = null;
		private DataDynamics.ActiveReports.TextBox TextBox90 = null;
		private DataDynamics.ActiveReports.Label Label170 = null;
		private DataDynamics.ActiveReports.Label Label171 = null;
		private DataDynamics.ActiveReports.TextBox TextBox91 = null;
		private DataDynamics.ActiveReports.TextBox TextBox92 = null;
		private DataDynamics.ActiveReports.TextBox TextBox97 = null;
		private DataDynamics.ActiveReports.TextBox TextBox98 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoGuardPremiumAndComissionEarned));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.txtEntryDate = new DataDynamics.ActiveReports.TextBox();
            this.txtEffectiveDate = new DataDynamics.ActiveReports.TextBox();
            this.TextBox53 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox22 = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalPremium = new DataDynamics.ActiveReports.TextBox();
            this.TextBox20 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox75 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox76 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox77 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox78 = new DataDynamics.ActiveReports.TextBox();
            this.txtTaskControlID = new DataDynamics.ActiveReports.TextBox();
            this.TxtRegCode = new DataDynamics.ActiveReports.TextBox();
            this.txtCustomerName = new DataDynamics.ActiveReports.TextBox();
            this.TextBox80 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox81 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox93 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox94 = new DataDynamics.ActiveReports.TextBox();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.Label147 = new DataDynamics.ActiveReports.Label();
            this.TextBox18 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox21 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox88 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox89 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox90 = new DataDynamics.ActiveReports.TextBox();
            this.Label170 = new DataDynamics.ActiveReports.Label();
            this.Label171 = new DataDynamics.ActiveReports.Label();
            this.TextBox91 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox92 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox97 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox98 = new DataDynamics.ActiveReports.TextBox();
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
            this.Label129 = new DataDynamics.ActiveReports.Label();
            this.Label122 = new DataDynamics.ActiveReports.Label();
            this.Label128 = new DataDynamics.ActiveReports.Label();
            this.Label146 = new DataDynamics.ActiveReports.Label();
            this.Label149 = new DataDynamics.ActiveReports.Label();
            this.Label150 = new DataDynamics.ActiveReports.Label();
            this.Label151 = new DataDynamics.ActiveReports.Label();
            this.Label152 = new DataDynamics.ActiveReports.Label();
            this.Label153 = new DataDynamics.ActiveReports.Label();
            this.Label154 = new DataDynamics.ActiveReports.Label();
            this.Label155 = new DataDynamics.ActiveReports.Label();
            this.Label156 = new DataDynamics.ActiveReports.Label();
            this.LblAsOff = new DataDynamics.ActiveReports.Label();
            this.Label172 = new DataDynamics.ActiveReports.Label();
            this.Label173 = new DataDynamics.ActiveReports.Label();
            this.Label174 = new DataDynamics.ActiveReports.Label();
            this.Label175 = new DataDynamics.ActiveReports.Label();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.GroupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.Label130 = new DataDynamics.ActiveReports.Label();
            this.Label131 = new DataDynamics.ActiveReports.Label();
            this.Label132 = new DataDynamics.ActiveReports.Label();
            this.GroupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.Label134 = new DataDynamics.ActiveReports.Label();
            this.Label135 = new DataDynamics.ActiveReports.Label();
            this.Label164 = new DataDynamics.ActiveReports.Label();
            this.Label165 = new DataDynamics.ActiveReports.Label();
            this.TextBox70 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox74 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox72 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox82 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox83 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox84 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox71 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox95 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox96 = new DataDynamics.ActiveReports.TextBox();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.label3 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox76)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox78)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaskControlID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRegCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox81)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox93)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox94)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label147)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox88)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox89)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox90)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label170)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label171)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox91)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox92)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox97)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox98)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.Label129)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label122)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label128)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label146)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label149)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label150)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label151)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label152)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label153)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label154)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label155)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label156)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblAsOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label172)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label173)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label174)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label175)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label164)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label165)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox74)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox72)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox82)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox83)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox84)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox95)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox96)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtEntryDate,
            this.txtEffectiveDate,
            this.TextBox53,
            this.TextBox22,
            this.txtTotalPremium,
            this.TextBox20,
            this.TextBox75,
            this.TextBox76,
            this.TextBox77,
            this.TextBox78,
            this.txtTaskControlID,
            this.TxtRegCode,
            this.txtCustomerName,
            this.TextBox80,
            this.TextBox81,
            this.TextBox93,
            this.TextBox94});
            this.Detail.Height = 0.2708333F;
            this.Detail.Name = "Detail";
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
            this.txtEntryDate.Left = 5.3125F;
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
            this.txtEffectiveDate.Left = 3.9375F;
            this.txtEffectiveDate.Name = "txtEffectiveDate";
            this.txtEffectiveDate.OutputFormat = resources.GetString("txtEffectiveDate.OutputFormat");
            this.txtEffectiveDate.Style = "text-align: left; font-size: 7pt; ";
            this.txtEffectiveDate.Text = null;
            this.txtEffectiveDate.Top = 0F;
            this.txtEffectiveDate.Width = 0.625F;
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
            this.TextBox53.Left = 4.625F;
            this.TextBox53.Name = "TextBox53";
            this.TextBox53.OutputFormat = resources.GetString("TextBox53.OutputFormat");
            this.TextBox53.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox53.Text = null;
            this.TextBox53.Top = 0F;
            this.TextBox53.Width = 0.625F;
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
            this.TextBox22.Left = 6F;
            this.TextBox22.Name = "TextBox22";
            this.TextBox22.OutputFormat = resources.GetString("TextBox22.OutputFormat");
            this.TextBox22.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox22.Text = null;
            this.TextBox22.Top = 0F;
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
            this.txtTotalPremium.Left = 6.75F;
            this.txtTotalPremium.Name = "txtTotalPremium";
            this.txtTotalPremium.OutputFormat = resources.GetString("txtTotalPremium.OutputFormat");
            this.txtTotalPremium.Style = "text-align: right; font-size: 7pt; ";
            this.txtTotalPremium.Text = null;
            this.txtTotalPremium.Top = 0F;
            this.txtTotalPremium.Width = 0.6354167F;
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
            this.TextBox20.Left = 7.5F;
            this.TextBox20.Name = "TextBox20";
            this.TextBox20.OutputFormat = resources.GetString("TextBox20.OutputFormat");
            this.TextBox20.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox20.Text = null;
            this.TextBox20.Top = 0F;
            this.TextBox20.Width = 0.5F;
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
            this.TextBox75.DataField = "CancellationDate";
            this.TextBox75.Height = 0.125F;
            this.TextBox75.Left = 8.0625F;
            this.TextBox75.Name = "TextBox75";
            this.TextBox75.OutputFormat = resources.GetString("TextBox75.OutputFormat");
            this.TextBox75.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox75.Text = null;
            this.TextBox75.Top = 0F;
            this.TextBox75.Width = 0.5625F;
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
            this.TextBox76.DataField = "Prm_Earn";
            this.TextBox76.Height = 0.125F;
            this.TextBox76.Left = 8.6875F;
            this.TextBox76.Name = "TextBox76";
            this.TextBox76.OutputFormat = resources.GetString("TextBox76.OutputFormat");
            this.TextBox76.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox76.Text = null;
            this.TextBox76.Top = 0F;
            this.TextBox76.Width = 0.5F;
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
            this.TextBox77.DataField = "Com_Earn";
            this.TextBox77.Height = 0.125F;
            this.TextBox77.Left = 9.375F;
            this.TextBox77.Name = "TextBox77";
            this.TextBox77.OutputFormat = resources.GetString("TextBox77.OutputFormat");
            this.TextBox77.Style = "text-align: right; font-size: 7pt; ";
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
            this.TextBox78.DataField = "GrossCom";
            this.TextBox78.Height = 0.125F;
            this.TextBox78.Left = 10.3125F;
            this.TextBox78.Name = "TextBox78";
            this.TextBox78.OutputFormat = resources.GetString("TextBox78.OutputFormat");
            this.TextBox78.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox78.Text = null;
            this.TextBox78.Top = 0F;
            this.TextBox78.Width = 0.645833F;
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
            this.txtTaskControlID.Left = 0.3125F;
            this.txtTaskControlID.Name = "txtTaskControlID";
            this.txtTaskControlID.Style = "text-align: left; font-size: 7pt; ";
            this.txtTaskControlID.Text = null;
            this.txtTaskControlID.Top = 0F;
            this.txtTaskControlID.Width = 0.4895833F;
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
            this.TxtRegCode.Left = 1F;
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
            this.txtCustomerName.Left = 2.239583F;
            this.txtCustomerName.MultiLine = false;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Style = "text-align: left; font-size: 7pt; ";
            this.txtCustomerName.Text = null;
            this.txtCustomerName.Top = 0F;
            this.txtCustomerName.Width = 1.635417F;
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
            this.TextBox80.DataField = "Status";
            this.TextBox80.Height = 0.125F;
            this.TextBox80.Left = 13.3125F;
            this.TextBox80.Name = "TextBox80";
            this.TextBox80.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox80.Text = null;
            this.TextBox80.Top = 0F;
            this.TextBox80.Width = 0.4895833F;
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
            this.TextBox81.DataField = "Dea_Com";
            this.TextBox81.Height = 0.125F;
            this.TextBox81.Left = 9.875F;
            this.TextBox81.Name = "TextBox81";
            this.TextBox81.OutputFormat = resources.GetString("TextBox81.OutputFormat");
            this.TextBox81.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox81.Text = null;
            this.TextBox81.Top = 0F;
            this.TextBox81.Width = 0.375F;
            // 
            // TextBox93
            // 
            this.TextBox93.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox93.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox93.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox93.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox93.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox93.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox93.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox93.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox93.DataField = "Com_Canc";
            this.TextBox93.Height = 0.125F;
            this.TextBox93.Left = 11.5F;
            this.TextBox93.Name = "TextBox93";
            this.TextBox93.OutputFormat = resources.GetString("TextBox93.OutputFormat");
            this.TextBox93.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox93.Text = null;
            this.TextBox93.Top = 0F;
            this.TextBox93.Width = 0.645833F;
            // 
            // TextBox94
            // 
            this.TextBox94.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox94.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox94.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox94.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox94.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox94.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox94.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox94.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox94.DataField = "Com_Net";
            this.TextBox94.Height = 0.125F;
            this.TextBox94.Left = 12.4375F;
            this.TextBox94.Name = "TextBox94";
            this.TextBox94.OutputFormat = resources.GetString("TextBox94.OutputFormat");
            this.TextBox94.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox94.Text = null;
            this.TextBox94.Top = 0F;
            this.TextBox94.Width = 0.645833F;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Height = 0F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line9,
            this.Label147,
            this.TextBox18,
            this.TextBox21,
            this.TextBox88,
            this.TextBox89,
            this.TextBox90,
            this.Label170,
            this.Label171,
            this.TextBox91,
            this.TextBox92,
            this.TextBox97,
            this.TextBox98});
            this.ReportFooter.Height = 0.4472222F;
            this.ReportFooter.Name = "ReportFooter";
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
            this.Line9.Width = 13.29167F;
            this.Line9.X1 = 0.3958333F;
            this.Line9.X2 = 13.6875F;
            this.Line9.Y1 = 0F;
            this.Line9.Y2 = 0F;
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
            this.TextBox18.Left = 6.6875F;
            this.TextBox18.Name = "TextBox18";
            this.TextBox18.OutputFormat = resources.GetString("TextBox18.OutputFormat");
            this.TextBox18.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: Arial; ";
            this.TextBox18.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox18.Text = null;
            this.TextBox18.Top = 0F;
            this.TextBox18.Width = 0.75F;
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
            this.TextBox21.Left = 7.625F;
            this.TextBox21.Name = "TextBox21";
            this.TextBox21.OutputFormat = resources.GetString("TextBox21.OutputFormat");
            this.TextBox21.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: Arial; ";
            this.TextBox21.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox21.Text = null;
            this.TextBox21.Top = 0F;
            this.TextBox21.Width = 0.6875F;
            // 
            // TextBox88
            // 
            this.TextBox88.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox88.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox88.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox88.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox88.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox88.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox88.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox88.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox88.DataField = "Prm_Earn";
            this.TextBox88.Height = 0.1875F;
            this.TextBox88.Left = 8.4375F;
            this.TextBox88.Name = "TextBox88";
            this.TextBox88.OutputFormat = resources.GetString("TextBox88.OutputFormat");
            this.TextBox88.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: Arial; ";
            this.TextBox88.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox88.Text = null;
            this.TextBox88.Top = 0F;
            this.TextBox88.Width = 0.75F;
            // 
            // TextBox89
            // 
            this.TextBox89.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox89.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox89.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox89.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox89.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox89.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox89.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox89.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox89.DataField = "Com_Earn";
            this.TextBox89.Height = 0.1875F;
            this.TextBox89.Left = 9.1875F;
            this.TextBox89.Name = "TextBox89";
            this.TextBox89.OutputFormat = resources.GetString("TextBox89.OutputFormat");
            this.TextBox89.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: Arial; ";
            this.TextBox89.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox89.Text = null;
            this.TextBox89.Top = 0F;
            this.TextBox89.Width = 0.6875F;
            // 
            // TextBox90
            // 
            this.TextBox90.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox90.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox90.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox90.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox90.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox90.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox90.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox90.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox90.DataField = "GrossCom";
            this.TextBox90.Height = 0.1875F;
            this.TextBox90.Left = 10.125F;
            this.TextBox90.Name = "TextBox90";
            this.TextBox90.OutputFormat = resources.GetString("TextBox90.OutputFormat");
            this.TextBox90.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: Arial; ";
            this.TextBox90.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox90.Text = null;
            this.TextBox90.Top = 0F;
            this.TextBox90.Width = 0.8333333F;
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
            this.Label170.Left = 3.5625F;
            this.Label170.Name = "Label170";
            this.Label170.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label170.Text = "Cancellations";
            this.Label170.Top = 0.125F;
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
            this.Label171.Left = 3.5625F;
            this.Label171.Name = "Label171";
            this.Label171.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label171.Text = "New Policies";
            this.Label171.Top = 0F;
            this.Label171.Width = 0.9375F;
            // 
            // TextBox91
            // 
            this.TextBox91.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox91.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox91.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox91.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox91.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox91.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox91.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox91.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox91.DataField = "CancellationEntryDate";
            this.TextBox91.Height = 0.1875F;
            this.TextBox91.Left = 4.5625F;
            this.TextBox91.Name = "TextBox91";
            this.TextBox91.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox91.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox91.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox91.Text = null;
            this.TextBox91.Top = 0.125F;
            this.TextBox91.Width = 0.625F;
            // 
            // TextBox92
            // 
            this.TextBox92.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox92.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox92.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox92.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox92.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox92.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox92.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox92.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox92.Height = 0.1875F;
            this.TextBox92.Left = 4.5625F;
            this.TextBox92.Name = "TextBox92";
            this.TextBox92.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox92.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox92.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox92.Text = null;
            this.TextBox92.Top = 0F;
            this.TextBox92.Width = 0.625F;
            // 
            // TextBox97
            // 
            this.TextBox97.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox97.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox97.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox97.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox97.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox97.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox97.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox97.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox97.DataField = "Com_Canc";
            this.TextBox97.Height = 0.1875F;
            this.TextBox97.Left = 11.3125F;
            this.TextBox97.Name = "TextBox97";
            this.TextBox97.OutputFormat = resources.GetString("TextBox97.OutputFormat");
            this.TextBox97.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: Arial; ";
            this.TextBox97.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox97.Text = null;
            this.TextBox97.Top = 0F;
            this.TextBox97.Width = 0.8333333F;
            // 
            // TextBox98
            // 
            this.TextBox98.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox98.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox98.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox98.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox98.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox98.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox98.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox98.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox98.DataField = "Com_Net";
            this.TextBox98.Height = 0.1875F;
            this.TextBox98.Left = 12.25F;
            this.TextBox98.Name = "TextBox98";
            this.TextBox98.OutputFormat = resources.GetString("TextBox98.OutputFormat");
            this.TextBox98.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: Arial; ";
            this.TextBox98.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox98.Text = null;
            this.TextBox98.Top = 0F;
            this.TextBox98.Width = 0.8333333F;
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
            this.Label129,
            this.Label122,
            this.Label128,
            this.Label146,
            this.Label149,
            this.Label150,
            this.Label151,
            this.Label152,
            this.Label153,
            this.Label154,
            this.Label155,
            this.Label156,
            this.LblAsOff,
            this.Label172,
            this.Label173,
            this.Label174,
            this.Label175,
            this.Label75,
            this.Label77,
            this.label1,
            this.label2,
            this.label3,
            this.label4});
            this.PageHeader.Height = 1.134722F;
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
            this.lblCriterias.Left = 3.90625F;
            this.lblCriterias.MultiLine = false;
            this.lblCriterias.Name = "lblCriterias";
            this.lblCriterias.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.lblCriterias.Text = "Auto Guard Premium & Commission Earned";
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
            this.Label80.Left = 11.375F;
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
            this.TextBox17.Left = 11.875F;
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
            this.Shape3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Shape3.Name = "Shape3";
            this.Shape3.RoundingRadius = 9.999999F;
            this.Shape3.Top = 0.8125F;
            this.Shape3.Width = 13.625F;
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
            this.Label107.Top = 0.8125F;
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
            this.Label108.Top = 0.8125F;
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
            this.Label109.Left = 5.3125F;
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
            this.Label113.Left = 2.4375F;
            this.Label113.Name = "Label113";
            this.Label113.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label113.Text = "Customer Name";
            this.Label113.Top = 0.8125F;
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
            this.Label125.Left = 4F;
            this.Label125.Name = "Label125";
            this.Label125.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label125.Text = "Effec. Date";
            this.Label125.Top = 0.8125F;
            this.Label125.Width = 0.6875F;
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
            this.Label129.Left = 6F;
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
            this.Label122.Left = 6.75F;
            this.Label122.Name = "Label122";
            this.Label122.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label122.Text = "Premium";
            this.Label122.Top = 0.8125F;
            this.Label122.Width = 0.5625F;
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
            this.Label128.Left = 7.1875F;
            this.Label128.MultiLine = false;
            this.Label128.Name = "Label128";
            this.Label128.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label128.Text = "Amount";
            this.Label128.Top = 0.9375F;
            this.Label128.Width = 0.5F;
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
            this.Label146.Left = 7.25F;
            this.Label146.Name = "Label146";
            this.Label146.Style = "text-align: center; font-weight: bold; font-size: 9pt; white-space: nowrap; verti" +
                "cal-align: top; ";
            this.Label146.Text = "Cancellation";
            this.Label146.Top = 0.8125F;
            this.Label146.Width = 0.875F;
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
            this.Label149.Left = 4.6875F;
            this.Label149.Name = "Label149";
            this.Label149.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label149.Text = "Exp. Date";
            this.Label149.Top = 0.8125F;
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
            this.Label150.Left = 7.8125F;
            this.Label150.MultiLine = false;
            this.Label150.Name = "Label150";
            this.Label150.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label150.Text = "Date";
            this.Label150.Top = 0.9375F;
            this.Label150.Width = 0.375F;
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
            this.Label151.Left = 8.3125F;
            this.Label151.Name = "Label151";
            this.Label151.Style = "text-align: center; font-weight: bold; font-size: 9pt; white-space: nowrap; verti" +
                "cal-align: top; ";
            this.Label151.Text = "-----------Earned-----------";
            this.Label151.Top = 0.8125F;
            this.Label151.Width = 1.625F;
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
            this.Label152.Left = 8.375F;
            this.Label152.Name = "Label152";
            this.Label152.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label152.Text = "Premium";
            this.Label152.Top = 0.9375F;
            this.Label152.Width = 0.625F;
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
            this.Label153.Height = 0.1875F;
            this.Label153.HyperLink = "";
            this.Label153.Left = 8.9375F;
            this.Label153.Name = "Label153";
            this.Label153.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label153.Text = "Commission      %";
            this.Label153.Top = 0.9375F;
            this.Label153.Width = 1.0625F;
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
            this.Label154.Height = 0.1875F;
            this.Label154.HyperLink = "";
            this.Label154.Left = 10.3125F;
            this.Label154.Name = "Label154";
            this.Label154.Style = "text-align: center; font-weight: bold; font-size: 9pt; white-space: nowrap; verti" +
                "cal-align: top; ";
            this.Label154.Text = "Gross";
            this.Label154.Top = 0.8125F;
            this.Label154.Width = 0.875F;
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
            this.Label155.Height = 0.125F;
            this.Label155.HyperLink = "";
            this.Label155.Left = 10.375F;
            this.Label155.Name = "Label155";
            this.Label155.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label155.Text = "Commission";
            this.Label155.Top = 1F;
            this.Label155.Width = 0.75F;
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
            this.Label156.Height = 0.125F;
            this.Label156.HyperLink = "";
            this.Label156.Left = 13.1875F;
            this.Label156.Name = "Label156";
            this.Label156.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label156.Text = "Status";
            this.Label156.Top = 1F;
            this.Label156.Width = 0.5F;
            // 
            // LblAsOff
            // 
            this.LblAsOff.Border.BottomColor = System.Drawing.Color.Black;
            this.LblAsOff.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblAsOff.Border.LeftColor = System.Drawing.Color.Black;
            this.LblAsOff.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblAsOff.Border.RightColor = System.Drawing.Color.Black;
            this.LblAsOff.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblAsOff.Border.TopColor = System.Drawing.Color.Black;
            this.LblAsOff.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblAsOff.Height = 0.125F;
            this.LblAsOff.HyperLink = "";
            this.LblAsOff.Left = 3.90625F;
            this.LblAsOff.MultiLine = false;
            this.LblAsOff.Name = "LblAsOff";
            this.LblAsOff.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.LblAsOff.Text = "As Off:";
            this.LblAsOff.Top = 0.5F;
            this.LblAsOff.Width = 5.125F;
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
            this.Label172.Height = 0.1875F;
            this.Label172.HyperLink = "";
            this.Label172.Left = 11.375F;
            this.Label172.Name = "Label172";
            this.Label172.Style = "text-align: center; font-weight: bold; font-size: 9pt; white-space: nowrap; verti" +
                "cal-align: top; ";
            this.Label172.Text = "Cancellation";
            this.Label172.Top = 0.8125F;
            this.Label172.Width = 0.8125F;
            // 
            // Label173
            // 
            this.Label173.Border.BottomColor = System.Drawing.Color.Black;
            this.Label173.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label173.Border.LeftColor = System.Drawing.Color.Black;
            this.Label173.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label173.Border.RightColor = System.Drawing.Color.Black;
            this.Label173.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label173.Border.TopColor = System.Drawing.Color.Black;
            this.Label173.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label173.Height = 0.125F;
            this.Label173.HyperLink = "";
            this.Label173.Left = 11.375F;
            this.Label173.Name = "Label173";
            this.Label173.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label173.Text = "Commission";
            this.Label173.Top = 1F;
            this.Label173.Width = 0.75F;
            // 
            // Label174
            // 
            this.Label174.Border.BottomColor = System.Drawing.Color.Black;
            this.Label174.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label174.Border.LeftColor = System.Drawing.Color.Black;
            this.Label174.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label174.Border.RightColor = System.Drawing.Color.Black;
            this.Label174.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label174.Border.TopColor = System.Drawing.Color.Black;
            this.Label174.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label174.Height = 0.1875F;
            this.Label174.HyperLink = "";
            this.Label174.Left = 12.3125F;
            this.Label174.Name = "Label174";
            this.Label174.Style = "text-align: center; font-weight: bold; font-size: 9pt; white-space: nowrap; verti" +
                "cal-align: top; ";
            this.Label174.Text = "Net";
            this.Label174.Top = 0.8125F;
            this.Label174.Width = 0.8125F;
            // 
            // Label175
            // 
            this.Label175.Border.BottomColor = System.Drawing.Color.Black;
            this.Label175.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label175.Border.LeftColor = System.Drawing.Color.Black;
            this.Label175.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label175.Border.RightColor = System.Drawing.Color.Black;
            this.Label175.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label175.Border.TopColor = System.Drawing.Color.Black;
            this.Label175.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label175.Height = 0.125F;
            this.Label175.HyperLink = "";
            this.Label175.Left = 12.3125F;
            this.Label175.Name = "Label175";
            this.Label175.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label175.Text = "Commission";
            this.Label175.Top = 1F;
            this.Label175.Width = 0.75F;
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
            this.Label75.Left = 3.90625F;
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
            this.Label77.Left = 3.90625F;
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
            this.PageFooter.Height = 0.01041667F;
            this.PageFooter.Name = "PageFooter";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label130,
            this.Label131,
            this.Label132});
            this.GroupHeader2.DataField = "AgenctDesc";
            this.GroupHeader2.Height = 0.2291667F;
            this.GroupHeader2.Name = "GroupHeader2";
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
            this.Label130.Left = 0.3125F;
            this.Label130.Name = "Label130";
            this.Label130.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label130.Text = "Agency:";
            this.Label130.Top = 0F;
            this.Label130.Width = 0.5625F;
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
            this.Label131.Height = 0.1875F;
            this.Label131.HyperLink = "";
            this.Label131.Left = 0.9270833F;
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
            this.Label132.Left = 1.427083F;
            this.Label132.Name = "Label132";
            this.Label132.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label132.Text = "";
            this.Label132.Top = 0F;
            this.Label132.Width = 2.5625F;
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label134,
            this.Label135,
            this.Label164,
            this.Label165,
            this.TextBox70,
            this.TextBox74,
            this.TextBox72,
            this.TextBox82,
            this.TextBox83,
            this.TextBox84,
            this.TextBox71,
            this.TextBox95,
            this.TextBox96});
            this.GroupFooter2.Height = 0.3243056F;
            this.GroupFooter2.Name = "GroupFooter2";
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
            this.Label134.Left = 0.3125F;
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
            this.Label135.Left = 1.75F;
            this.Label135.Name = "Label135";
            this.Label135.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label135.Text = "";
            this.Label135.Top = 0F;
            this.Label135.Width = 0.4375F;
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
            this.Label164.Left = 3.5625F;
            this.Label164.Name = "Label164";
            this.Label164.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label164.Text = "New Policies";
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
            this.Label165.Left = 3.5625F;
            this.Label165.Name = "Label165";
            this.Label165.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label165.Text = "Cancellations";
            this.Label165.Top = 0.125F;
            this.Label165.Width = 0.9375F;
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
            this.TextBox70.Left = 4.5625F;
            this.TextBox70.Name = "TextBox70";
            this.TextBox70.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox70.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox70.SummaryGroup = "GroupHeader2";
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
            this.TextBox74.Height = 0.1875F;
            this.TextBox74.Left = 4.5625F;
            this.TextBox74.Name = "TextBox74";
            this.TextBox74.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.TextBox74.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox74.SummaryGroup = "GroupHeader2";
            this.TextBox74.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox74.Text = null;
            this.TextBox74.Top = 0F;
            this.TextBox74.Width = 0.625F;
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
            this.TextBox72.Left = 7.5625F;
            this.TextBox72.Name = "TextBox72";
            this.TextBox72.OutputFormat = resources.GetString("TextBox72.OutputFormat");
            this.TextBox72.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox72.SummaryGroup = "GroupHeader2";
            this.TextBox72.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox72.Text = null;
            this.TextBox72.Top = 0F;
            this.TextBox72.Width = 0.6875F;
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
            this.TextBox82.DataField = "Prm_Earn";
            this.TextBox82.Height = 0.1875F;
            this.TextBox82.Left = 8.5F;
            this.TextBox82.Name = "TextBox82";
            this.TextBox82.OutputFormat = resources.GetString("TextBox82.OutputFormat");
            this.TextBox82.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox82.SummaryGroup = "GroupHeader2";
            this.TextBox82.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox82.Text = null;
            this.TextBox82.Top = 0F;
            this.TextBox82.Width = 0.6875F;
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
            this.TextBox83.DataField = "Com_Earn";
            this.TextBox83.Height = 0.1875F;
            this.TextBox83.Left = 9.1875F;
            this.TextBox83.Name = "TextBox83";
            this.TextBox83.OutputFormat = resources.GetString("TextBox83.OutputFormat");
            this.TextBox83.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox83.SummaryGroup = "GroupHeader2";
            this.TextBox83.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox83.Text = null;
            this.TextBox83.Top = 0F;
            this.TextBox83.Width = 0.6875F;
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
            this.TextBox84.DataField = "GrossCom";
            this.TextBox84.Height = 0.1875F;
            this.TextBox84.Left = 10.1875F;
            this.TextBox84.Name = "TextBox84";
            this.TextBox84.OutputFormat = resources.GetString("TextBox84.OutputFormat");
            this.TextBox84.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox84.SummaryGroup = "GroupHeader2";
            this.TextBox84.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox84.Text = null;
            this.TextBox84.Top = 0F;
            this.TextBox84.Width = 0.7708333F;
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
            this.TextBox71.Left = 6.75F;
            this.TextBox71.Name = "TextBox71";
            this.TextBox71.OutputFormat = resources.GetString("TextBox71.OutputFormat");
            this.TextBox71.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox71.SummaryGroup = "GroupHeader2";
            this.TextBox71.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox71.Text = null;
            this.TextBox71.Top = 0F;
            this.TextBox71.Width = 0.6875F;
            // 
            // TextBox95
            // 
            this.TextBox95.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox95.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox95.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox95.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox95.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox95.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox95.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox95.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox95.DataField = "Com_Canc";
            this.TextBox95.Height = 0.1875F;
            this.TextBox95.Left = 11.375F;
            this.TextBox95.Name = "TextBox95";
            this.TextBox95.OutputFormat = resources.GetString("TextBox95.OutputFormat");
            this.TextBox95.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox95.SummaryGroup = "GroupHeader2";
            this.TextBox95.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox95.Text = null;
            this.TextBox95.Top = 0F;
            this.TextBox95.Width = 0.7708333F;
            // 
            // TextBox96
            // 
            this.TextBox96.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox96.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox96.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox96.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox96.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox96.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox96.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox96.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox96.DataField = "Com_Net";
            this.TextBox96.Height = 0.1875F;
            this.TextBox96.Left = 12.3125F;
            this.TextBox96.Name = "TextBox96";
            this.TextBox96.OutputFormat = resources.GetString("TextBox96.OutputFormat");
            this.TextBox96.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox96.SummaryGroup = "GroupHeader2";
            this.TextBox96.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox96.Text = null;
            this.TextBox96.Top = 0F;
            this.TextBox96.Width = 0.7708333F;
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
            this.label1.Left = 7.75F;
            this.label1.Name = "label1";
            this.label1.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.label1.Text = "Commission      %";
            this.label1.Top = 0.9375F;
            this.label1.Width = 1.0625F;
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
            this.label2.Left = 7.1875F;
            this.label2.Name = "label2";
            this.label2.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.label2.Text = "Premium";
            this.label2.Top = 0.9375F;
            this.label2.Width = 0.625F;
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
            this.label3.Left = 7.1875F;
            this.label3.Name = "label3";
            this.label3.Style = "text-align: center; font-weight: bold; font-size: 9pt; white-space: nowrap; verti" +
                "cal-align: top; ";
            this.label3.Text = "-----------Earned-----------";
            this.label3.Top = 0.8125F;
            this.label3.Width = 1.625F;
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
            this.label4.Left = 7.25F;
            this.label4.Name = "label4";
            this.label4.Style = "text-align: center; font-weight: bold; font-size: 9pt; white-space: nowrap; verti" +
                "cal-align: top; ";
            this.label4.Text = "Cancellation";
            this.label4.Top = 0.8125F;
            this.label4.Width = 0.875F;
            // 
            // AutoGuardPremiumAndComissionEarned
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0.1F;
            this.PageSettings.Margins.Right = 0.1F;
            this.PageSettings.Margins.Top = 0.3F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 14F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Legal;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 14.0625F;
            this.Sections.Add(this.ReportHeader);
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.GroupHeader2);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GroupFooter2);
            this.Sections.Add(this.PageFooter);
            this.Sections.Add(this.ReportFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.AutoGuardPremiumAndComissionEarned_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox76)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox78)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaskControlID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRegCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox81)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox93)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox94)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label147)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox88)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox89)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox90)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label170)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label171)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox91)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox92)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox97)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox98)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.Label129)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label122)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label128)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label146)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label149)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label150)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label151)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label152)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label153)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label154)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label155)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label156)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblAsOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label172)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label173)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label174)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label175)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label164)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label165)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox74)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox72)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox82)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox83)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox84)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox95)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox96)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
