using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports
{
	public class TodayPayments : DataDynamics.ActiveReports.ActiveReport3
	{
		string _ToDate;
		string _ReportType;
		bool   _Summary = false;

		public TodayPayments(string ToDate, string ReportType,bool Summary)
		{	
			_ToDate = ToDate;
			_ReportType = ReportType;
			_Summary  =  Summary;

			InitializeComponent();
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void TodayPayments_ReportStart(object sender, System.EventArgs eArgs)
		{
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

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Label lblDate = null;
		private DataDynamics.ActiveReports.Label lblTime = null;
		private DataDynamics.ActiveReports.Label Label80 = null;
		private DataDynamics.ActiveReports.TextBox TextBox17 = null;
		private DataDynamics.ActiveReports.Label lblCriterias = null;
		private DataDynamics.ActiveReports.Shape Shape3 = null;
		private DataDynamics.ActiveReports.Label Label104 = null;
		private DataDynamics.ActiveReports.Label Label105 = null;
		private DataDynamics.ActiveReports.Label Label106 = null;
		private DataDynamics.ActiveReports.Label Label107 = null;
		private DataDynamics.ActiveReports.Label Label108 = null;
		private DataDynamics.ActiveReports.Label Label109 = null;
		private DataDynamics.ActiveReports.Label Label110 = null;
		private DataDynamics.ActiveReports.Label Label111 = null;
		private DataDynamics.ActiveReports.Label Label112 = null;
		private DataDynamics.ActiveReports.Label Label133 = null;
		private DataDynamics.ActiveReports.Label Label75 = null;
		private DataDynamics.ActiveReports.Label Label77 = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader1 = null;
		private DataDynamics.ActiveReports.Label Label132 = null;
		private DataDynamics.ActiveReports.Label Label131 = null;
		private DataDynamics.ActiveReports.Label Label130 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox TxtPolicyNo = null;
		private DataDynamics.ActiveReports.TextBox txtCustNo = null;
		private DataDynamics.ActiveReports.TextBox txtInsuredName = null;
		private DataDynamics.ActiveReports.TextBox TextBox46 = null;
		private DataDynamics.ActiveReports.TextBox txtBankDesc = null;
		private DataDynamics.ActiveReports.TextBox txtAgency = null;
		private DataDynamics.ActiveReports.TextBox txtAgent = null;
		private DataDynamics.ActiveReports.TextBox txtInsCo = null;
		private DataDynamics.ActiveReports.TextBox TxtTotalPremium = null;
		private DataDynamics.ActiveReports.TextBox txtPaid = null;
		private DataDynamics.ActiveReports.TextBox txtCheck = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1 = null;
		private DataDynamics.ActiveReports.Shape Shape4 = null;
		private DataDynamics.ActiveReports.Label Label134 = null;
		private DataDynamics.ActiveReports.Label Label135 = null;
		private DataDynamics.ActiveReports.TextBox TextBox23 = null;
		private DataDynamics.ActiveReports.TextBox TextBox28 = null;
		private DataDynamics.ActiveReports.TextBox TextBox47 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		private DataDynamics.ActiveReports.Line Line140 = null;
		private DataDynamics.ActiveReports.Label Label139 = null;
		private DataDynamics.ActiveReports.TextBox TextBox27 = null;
		private DataDynamics.ActiveReports.TextBox TextBox26 = null;
		private DataDynamics.ActiveReports.TextBox TextBox48 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TodayPayments));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.GroupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.GroupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.lblDate = new DataDynamics.ActiveReports.Label();
            this.lblTime = new DataDynamics.ActiveReports.Label();
            this.Label80 = new DataDynamics.ActiveReports.Label();
            this.TextBox17 = new DataDynamics.ActiveReports.TextBox();
            this.lblCriterias = new DataDynamics.ActiveReports.Label();
            this.Shape3 = new DataDynamics.ActiveReports.Shape();
            this.Label104 = new DataDynamics.ActiveReports.Label();
            this.Label105 = new DataDynamics.ActiveReports.Label();
            this.Label106 = new DataDynamics.ActiveReports.Label();
            this.Label107 = new DataDynamics.ActiveReports.Label();
            this.Label108 = new DataDynamics.ActiveReports.Label();
            this.Label109 = new DataDynamics.ActiveReports.Label();
            this.Label110 = new DataDynamics.ActiveReports.Label();
            this.Label111 = new DataDynamics.ActiveReports.Label();
            this.Label112 = new DataDynamics.ActiveReports.Label();
            this.Label133 = new DataDynamics.ActiveReports.Label();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.Label132 = new DataDynamics.ActiveReports.Label();
            this.Label131 = new DataDynamics.ActiveReports.Label();
            this.Label130 = new DataDynamics.ActiveReports.Label();
            this.TxtPolicyNo = new DataDynamics.ActiveReports.TextBox();
            this.txtCustNo = new DataDynamics.ActiveReports.TextBox();
            this.txtInsuredName = new DataDynamics.ActiveReports.TextBox();
            this.TextBox46 = new DataDynamics.ActiveReports.TextBox();
            this.txtBankDesc = new DataDynamics.ActiveReports.TextBox();
            this.txtAgency = new DataDynamics.ActiveReports.TextBox();
            this.txtAgent = new DataDynamics.ActiveReports.TextBox();
            this.txtInsCo = new DataDynamics.ActiveReports.TextBox();
            this.TxtTotalPremium = new DataDynamics.ActiveReports.TextBox();
            this.txtPaid = new DataDynamics.ActiveReports.TextBox();
            this.txtCheck = new DataDynamics.ActiveReports.TextBox();
            this.Shape4 = new DataDynamics.ActiveReports.Shape();
            this.Label134 = new DataDynamics.ActiveReports.Label();
            this.Label135 = new DataDynamics.ActiveReports.Label();
            this.TextBox23 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox28 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox47 = new DataDynamics.ActiveReports.TextBox();
            this.Line140 = new DataDynamics.ActiveReports.Line();
            this.Label139 = new DataDynamics.ActiveReports.Label();
            this.TextBox27 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox26 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox48 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label110)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label112)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPolicyNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsuredName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsCo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotalPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label139)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.TxtPolicyNo,
                        this.txtCustNo,
                        this.txtInsuredName,
                        this.TextBox46,
                        this.txtBankDesc,
                        this.txtAgency,
                        this.txtAgent,
                        this.txtInsCo,
                        this.TxtTotalPremium,
                        this.txtPaid,
                        this.txtCheck});
            this.Detail.Height = 0.1979167F;
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
                        this.Label139,
                        this.TextBox27,
                        this.TextBox26,
                        this.TextBox48});
            this.ReportFooter.Height = 0.21875F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.lblDate,
                        this.lblTime,
                        this.Label80,
                        this.TextBox17,
                        this.lblCriterias,
                        this.Shape3,
                        this.Label104,
                        this.Label105,
                        this.Label106,
                        this.Label107,
                        this.Label108,
                        this.Label109,
                        this.Label110,
                        this.Label111,
                        this.Label112,
                        this.Label133,
                        this.Label75,
                        this.Label77});
            this.PageHeader.Height = 1.375F;
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
                        this.Label132,
                        this.Label131,
                        this.Label130});
            this.GroupHeader1.DataField = "InsuranceCompany";
            this.GroupHeader1.Height = 0.2076389F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Shape4,
                        this.Label134,
                        this.Label135,
                        this.TextBox23,
                        this.TextBox28,
                        this.TextBox47});
            this.GroupFooter1.Height = 0.2076389F;
            this.GroupFooter1.Name = "GroupFooter1";
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
            this.lblDate.Left = 1.25F;
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
            this.lblTime.Left = 1.25F;
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
            this.Label80.Left = 7.5F;
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
            this.TextBox17.Left = 7.9375F;
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
            this.lblCriterias.Left = 2.3125F;
            this.lblCriterias.MultiLine = false;
            this.lblCriterias.Name = "lblCriterias";
            this.lblCriterias.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.lblCriterias.Text = "Mechanical Breakdown - Today Payments";
            this.lblCriterias.Top = 0.6875F;
            this.lblCriterias.Width = 5.125F;
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
            this.Shape3.Height = 0.3125F;
            this.Shape3.Left = 0.3125F;
            this.Shape3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Shape3.Name = "Shape3";
            this.Shape3.RoundingRadius = 9.999999F;
            this.Shape3.Top = 1.0625F;
            this.Shape3.Width = 9F;
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
            this.Label105.Left = 3.5625F;
            this.Label105.MultiLine = false;
            this.Label105.Name = "Label105";
            this.Label105.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.Label105.Text = "BANK";
            this.Label105.Top = 1.125F;
            this.Label105.Width = 0.5F;
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
            this.Label106.Left = 1.375F;
            this.Label106.MultiLine = false;
            this.Label106.Name = "Label106";
            this.Label106.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label106.Text = "CUSTNO";
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
            this.Label107.Left = 2.0625F;
            this.Label107.MultiLine = false;
            this.Label107.Name = "Label107";
            this.Label107.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label107.Text = "INSURED NAME";
            this.Label107.Top = 1.125F;
            this.Label107.Width = 1.164063F;
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
            this.Label108.Left = 5.3125F;
            this.Label108.MultiLine = false;
            this.Label108.Name = "Label108";
            this.Label108.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label108.Text = "AGENCY";
            this.Label108.Top = 1.125F;
            this.Label108.Width = 0.625F;
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
            this.Label109.Left = 6F;
            this.Label109.MultiLine = false;
            this.Label109.Name = "Label109";
            this.Label109.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label109.Text = "AGENT";
            this.Label109.Top = 1.125F;
            this.Label109.Width = 0.46875F;
            // 
            // Label110
            // 
            this.Label110.Border.BottomColor = System.Drawing.Color.Black;
            this.Label110.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label110.Border.LeftColor = System.Drawing.Color.Black;
            this.Label110.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label110.Border.RightColor = System.Drawing.Color.Black;
            this.Label110.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label110.Border.TopColor = System.Drawing.Color.Black;
            this.Label110.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label110.Height = 0.2F;
            this.Label110.HyperLink = "";
            this.Label110.Left = 6.4375F;
            this.Label110.MultiLine = false;
            this.Label110.Name = "Label110";
            this.Label110.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label110.Text = "INSCO";
            this.Label110.Top = 1.125F;
            this.Label110.Width = 0.46875F;
            // 
            // Label111
            // 
            this.Label111.Border.BottomColor = System.Drawing.Color.Black;
            this.Label111.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label111.Border.LeftColor = System.Drawing.Color.Black;
            this.Label111.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label111.Border.RightColor = System.Drawing.Color.Black;
            this.Label111.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label111.Border.TopColor = System.Drawing.Color.Black;
            this.Label111.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label111.Height = 0.1875F;
            this.Label111.HyperLink = "";
            this.Label111.Left = 7F;
            this.Label111.MultiLine = false;
            this.Label111.Name = "Label111";
            this.Label111.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label111.Text = "PREMIUM";
            this.Label111.Top = 1.125F;
            this.Label111.Width = 0.59375F;
            // 
            // Label112
            // 
            this.Label112.Border.BottomColor = System.Drawing.Color.Black;
            this.Label112.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label112.Border.LeftColor = System.Drawing.Color.Black;
            this.Label112.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label112.Border.RightColor = System.Drawing.Color.Black;
            this.Label112.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label112.Border.TopColor = System.Drawing.Color.Black;
            this.Label112.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label112.Height = 0.2F;
            this.Label112.HyperLink = "";
            this.Label112.Left = 7.6875F;
            this.Label112.MultiLine = false;
            this.Label112.Name = "Label112";
            this.Label112.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label112.Text = "PAID AMOUNT";
            this.Label112.Top = 1.125F;
            this.Label112.Width = 0.84375F;
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
            this.Label133.Left = 8.5625F;
            this.Label133.MultiLine = false;
            this.Label133.Name = "Label133";
            this.Label133.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label133.Text = "CHECK";
            this.Label133.Top = 1.125F;
            this.Label133.Width = 0.65625F;
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
            this.Label75.Left = 2.3125F;
            this.Label75.MultiLine = false;
            this.Label75.Name = "Label75";
            this.Label75.Style = "text-align: center; font-weight: bold; font-size: 11.25pt; font-family: Times New" +
                " Roman; ";
            this.Label75.Text = "LAS VISTAS INSURANCE AGENCY, CORP.";
            this.Label75.Top = 0.21875F;
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
            this.Label77.Left = 2.3125F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-align: center; font-weight: bold; font-size: 6pt; font-family: Times New Rom" +
                "an; ";
            this.Label77.Text = "P.O. Box 195585 San Juan Puerto Rico, PR  00919-5585 Tel (787) 763-4010 Fax (787)" +
                " 763-3525";
            this.Label77.Top = 0.46875F;
            this.Label77.Width = 5.125F;
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
            this.Label132.Left = 1.625F;
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
            this.Label131.Left = 1.125F;
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
            this.TxtPolicyNo.Height = 0.1875F;
            this.TxtPolicyNo.Left = 0.3854166F;
            this.TxtPolicyNo.Name = "TxtPolicyNo";
            this.TxtPolicyNo.Style = "text-align: left; font-size: 7pt; ";
            this.TxtPolicyNo.Top = 0F;
            this.TxtPolicyNo.Width = 0.9270833F;
            // 
            // txtCustNo
            // 
            this.txtCustNo.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCustNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustNo.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCustNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustNo.Border.RightColor = System.Drawing.Color.Black;
            this.txtCustNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustNo.Border.TopColor = System.Drawing.Color.Black;
            this.txtCustNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustNo.DataField = "CustomerNo";
            this.txtCustNo.Height = 0.1875F;
            this.txtCustNo.Left = 1.322917F;
            this.txtCustNo.Name = "txtCustNo";
            this.txtCustNo.Style = "text-align: left; font-size: 7pt; ";
            this.txtCustNo.Top = 0F;
            this.txtCustNo.Width = 0.6770833F;
            // 
            // txtInsuredName
            // 
            this.txtInsuredName.Border.BottomColor = System.Drawing.Color.Black;
            this.txtInsuredName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInsuredName.Border.LeftColor = System.Drawing.Color.Black;
            this.txtInsuredName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInsuredName.Border.RightColor = System.Drawing.Color.Black;
            this.txtInsuredName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInsuredName.Border.TopColor = System.Drawing.Color.Black;
            this.txtInsuredName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInsuredName.DataField = "CustomerName";
            this.txtInsuredName.Height = 0.1875F;
            this.txtInsuredName.Left = 2.0625F;
            this.txtInsuredName.Name = "txtInsuredName";
            this.txtInsuredName.Style = "text-align: left; font-size: 7pt; ";
            this.txtInsuredName.Top = 0F;
            this.txtInsuredName.Width = 1.427083F;
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
            this.TextBox46.Height = 0.1875F;
            this.TextBox46.Left = 3.5625F;
            this.TextBox46.Name = "TextBox46";
            this.TextBox46.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox46.Top = 0F;
            this.TextBox46.Width = 0.3125F;
            // 
            // txtBankDesc
            // 
            this.txtBankDesc.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBankDesc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBankDesc.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBankDesc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBankDesc.Border.RightColor = System.Drawing.Color.Black;
            this.txtBankDesc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBankDesc.Border.TopColor = System.Drawing.Color.Black;
            this.txtBankDesc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBankDesc.DataField = "BankDesc";
            this.txtBankDesc.Height = 0.1875F;
            this.txtBankDesc.Left = 3.895833F;
            this.txtBankDesc.Name = "txtBankDesc";
            this.txtBankDesc.Style = "text-align: left; font-size: 7pt; ";
            this.txtBankDesc.Top = 0F;
            this.txtBankDesc.Width = 1.489583F;
            // 
            // txtAgency
            // 
            this.txtAgency.Border.BottomColor = System.Drawing.Color.Black;
            this.txtAgency.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAgency.Border.LeftColor = System.Drawing.Color.Black;
            this.txtAgency.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAgency.Border.RightColor = System.Drawing.Color.Black;
            this.txtAgency.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAgency.Border.TopColor = System.Drawing.Color.Black;
            this.txtAgency.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAgency.DataField = "Agency";
            this.txtAgency.Height = 0.1875F;
            this.txtAgency.Left = 5.4375F;
            this.txtAgency.Name = "txtAgency";
            this.txtAgency.Style = "text-align: center; font-size: 7pt; ";
            this.txtAgency.Top = 0F;
            this.txtAgency.Width = 0.3125F;
            // 
            // txtAgent
            // 
            this.txtAgent.Border.BottomColor = System.Drawing.Color.Black;
            this.txtAgent.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAgent.Border.LeftColor = System.Drawing.Color.Black;
            this.txtAgent.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAgent.Border.RightColor = System.Drawing.Color.Black;
            this.txtAgent.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAgent.Border.TopColor = System.Drawing.Color.Black;
            this.txtAgent.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAgent.DataField = "Agent";
            this.txtAgent.Height = 0.1875F;
            this.txtAgent.Left = 6.0625F;
            this.txtAgent.Name = "txtAgent";
            this.txtAgent.Style = "text-align: center; font-size: 7pt; ";
            this.txtAgent.Top = 0F;
            this.txtAgent.Width = 0.3125F;
            // 
            // txtInsCo
            // 
            this.txtInsCo.Border.BottomColor = System.Drawing.Color.Black;
            this.txtInsCo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInsCo.Border.LeftColor = System.Drawing.Color.Black;
            this.txtInsCo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInsCo.Border.RightColor = System.Drawing.Color.Black;
            this.txtInsCo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInsCo.Border.TopColor = System.Drawing.Color.Black;
            this.txtInsCo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInsCo.DataField = "InsuranceCompany";
            this.txtInsCo.Height = 0.1875F;
            this.txtInsCo.Left = 6.5F;
            this.txtInsCo.Name = "txtInsCo";
            this.txtInsCo.Style = "text-align: center; font-size: 7pt; ";
            this.txtInsCo.Top = 0F;
            this.txtInsCo.Width = 0.3125F;
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
            this.TxtTotalPremium.DataField = "TotalPremium";
            this.TxtTotalPremium.Height = 0.1875F;
            this.TxtTotalPremium.Left = 7.0625F;
            this.TxtTotalPremium.MultiLine = false;
            this.TxtTotalPremium.Name = "TxtTotalPremium";
            this.TxtTotalPremium.OutputFormat = resources.GetString("TxtTotalPremium.OutputFormat");
            this.TxtTotalPremium.Style = "text-align: center; font-weight: normal; font-size: 6.75pt; ";
            this.TxtTotalPremium.Top = 0F;
            this.TxtTotalPremium.Width = 0.5625F;
            // 
            // txtPaid
            // 
            this.txtPaid.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPaid.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPaid.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPaid.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPaid.Border.RightColor = System.Drawing.Color.Black;
            this.txtPaid.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPaid.Border.TopColor = System.Drawing.Color.Black;
            this.txtPaid.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPaid.DataField = "PaidAmount";
            this.txtPaid.Height = 0.1875F;
            this.txtPaid.Left = 7.875F;
            this.txtPaid.MultiLine = false;
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.OutputFormat = resources.GetString("txtPaid.OutputFormat");
            this.txtPaid.Style = "text-align: center; font-weight: normal; font-size: 6.75pt; ";
            this.txtPaid.Top = 0F;
            this.txtPaid.Width = 0.625F;
            // 
            // txtCheck
            // 
            this.txtCheck.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCheck.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCheck.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCheck.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCheck.Border.RightColor = System.Drawing.Color.Black;
            this.txtCheck.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCheck.Border.TopColor = System.Drawing.Color.Black;
            this.txtCheck.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCheck.DataField = "CheckNumber";
            this.txtCheck.Height = 0.1875F;
            this.txtCheck.Left = 8.625F;
            this.txtCheck.MultiLine = false;
            this.txtCheck.Name = "txtCheck";
            this.txtCheck.OutputFormat = resources.GetString("txtCheck.OutputFormat");
            this.txtCheck.Style = "text-align: center; font-weight: normal; font-size: 6.75pt; ";
            this.txtCheck.Top = 0F;
            this.txtCheck.Width = 0.5F;
            // 
            // Shape4
            // 
            this.Shape4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(227)))), ((int)(((byte)(234)))));
            this.Shape4.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape4.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape4.Border.RightColor = System.Drawing.Color.Black;
            this.Shape4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape4.Border.TopColor = System.Drawing.Color.Black;
            this.Shape4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape4.Height = 0.1875F;
            this.Shape4.Left = 0.375F;
            this.Shape4.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Shape4.Name = "Shape4";
            this.Shape4.RoundingRadius = 9.999999F;
            this.Shape4.Top = 0F;
            this.Shape4.Width = 8.875F;
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
            this.Label134.Left = 0.5F;
            this.Label134.Name = "Label134";
            this.Label134.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label134.Text = "Total for InsCo.:";
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
            this.Label135.DataField = "InsuranceCompany";
            this.Label135.Height = 0.2F;
            this.Label135.HyperLink = "";
            this.Label135.Left = 1.5625F;
            this.Label135.Name = "Label135";
            this.Label135.Style = "text-align: left; font-weight: bold; font-size: 8pt; white-space: nowrap; ";
            this.Label135.Text = "";
            this.Label135.Top = 0F;
            this.Label135.Width = 0.4375F;
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
            this.TextBox23.SummaryGroup = "GroupHeader1";
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
            this.TextBox28.DataField = "TotalPremium";
            this.TextBox28.Height = 0.1875F;
            this.TextBox28.Left = 7.0625F;
            this.TextBox28.MultiLine = false;
            this.TextBox28.Name = "TextBox28";
            this.TextBox28.OutputFormat = resources.GetString("TextBox28.OutputFormat");
            this.TextBox28.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; ";
            this.TextBox28.SummaryGroup = "GroupHeader1";
            this.TextBox28.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox28.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox28.Top = 0F;
            this.TextBox28.Width = 0.5625F;
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
            this.TextBox47.DataField = "PaidAmount";
            this.TextBox47.Height = 0.1875F;
            this.TextBox47.Left = 7.9375F;
            this.TextBox47.MultiLine = false;
            this.TextBox47.Name = "TextBox47";
            this.TextBox47.OutputFormat = resources.GetString("TextBox47.OutputFormat");
            this.TextBox47.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; ";
            this.TextBox47.SummaryGroup = "GroupHeader1";
            this.TextBox47.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox47.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox47.Top = 0F;
            this.TextBox47.Width = 0.5625F;
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
            this.Line140.Width = 8.9375F;
            this.Line140.X1 = 0.375F;
            this.Line140.X2 = 9.3125F;
            this.Line140.Y1 = 0F;
            this.Line140.Y2 = 0F;
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
            this.Label139.Text = "TOTAL :";
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
            this.TextBox26.DataField = "TotalPremium";
            this.TextBox26.Height = 0.1875F;
            this.TextBox26.Left = 7F;
            this.TextBox26.MultiLine = false;
            this.TextBox26.Name = "TextBox26";
            this.TextBox26.OutputFormat = resources.GetString("TextBox26.OutputFormat");
            this.TextBox26.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; vertical-align: middle;" +
                " ";
            this.TextBox26.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox26.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox26.Top = 0F;
            this.TextBox26.Width = 0.625F;
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
            this.TextBox48.DataField = "PaidAmount";
            this.TextBox48.Height = 0.1875F;
            this.TextBox48.Left = 7.875F;
            this.TextBox48.MultiLine = false;
            this.TextBox48.Name = "TextBox48";
            this.TextBox48.OutputFormat = resources.GetString("TextBox48.OutputFormat");
            this.TextBox48.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; vertical-align: middle;" +
                " ";
            this.TextBox48.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox48.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox48.Top = 0F;
            this.TextBox48.Width = 0.625F;
            // 
            // ActiveReport31
            // 
            this.PageSettings.Margins.Bottom = 0.2F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.1F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 9.802083F;
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
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label110)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label112)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPolicyNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsuredName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsCo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotalPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label139)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
       
			// Attach Report Events
			this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
			this.ReportStart += new System.EventHandler(this.TodayPayments_ReportStart);
		 }

		#endregion
	}
}
