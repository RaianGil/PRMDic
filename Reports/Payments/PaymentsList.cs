using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports
{
	public class PaymentsList : DataDynamics.ActiveReports.ActiveReport3
	{
		string _FromDate;
		string _ToDate;
		string _ReportType;
        string _mHeadCompany = "";

        public PaymentsList(string FromDate, string ToDate, string ReportType, string mHeadCompany)
		{
			_FromDate = FromDate;
			_ToDate = ToDate;
			_ReportType = ReportType;
            _mHeadCompany = mHeadCompany;

			InitializeComponent();
		}

		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void GroupFooter1_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void PaymentsList_PageStart(object sender, System.EventArgs eArgs)
		{
            this.Label75.Text = _mHeadCompany;
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
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Label lblCriterias = null;
		private DataDynamics.ActiveReports.Shape Shape3 = null;
		private DataDynamics.ActiveReports.Label lblDate = null;
		private DataDynamics.ActiveReports.Label lblTime = null;
		private DataDynamics.ActiveReports.Label Label104 = null;
		private DataDynamics.ActiveReports.Label Label107 = null;
		private DataDynamics.ActiveReports.Label Label108 = null;
		private DataDynamics.ActiveReports.Label Label109 = null;
		private DataDynamics.ActiveReports.Label Label110 = null;
		private DataDynamics.ActiveReports.Label Label80 = null;
		private DataDynamics.ActiveReports.TextBox TextBox17 = null;
		private DataDynamics.ActiveReports.Label Label111 = null;
		private DataDynamics.ActiveReports.Label Label112 = null;
		private DataDynamics.ActiveReports.Label Label113 = null;
		private DataDynamics.ActiveReports.Label Label114 = null;
		private DataDynamics.ActiveReports.Label Label115 = null;
		private DataDynamics.ActiveReports.Label Label116 = null;
		private DataDynamics.ActiveReports.Label Label117 = null;
		private DataDynamics.ActiveReports.Label Label118 = null;
		private DataDynamics.ActiveReports.Label Label119 = null;
		private DataDynamics.ActiveReports.Label Label123 = null;
        private DataDynamics.ActiveReports.Label Label75 = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader1 = null;
		private DataDynamics.ActiveReports.Label Label120 = null;
		private DataDynamics.ActiveReports.TextBox TextBox33 = null;
		private DataDynamics.ActiveReports.TextBox TextBox18 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox TextBox8 = null;
		private DataDynamics.ActiveReports.TextBox TextBox19 = null;
		private DataDynamics.ActiveReports.TextBox TextBox20 = null;
		private DataDynamics.ActiveReports.TextBox TextBox21 = null;
		private DataDynamics.ActiveReports.TextBox TextBox22 = null;
		private DataDynamics.ActiveReports.TextBox TextBox23 = null;
		private DataDynamics.ActiveReports.TextBox TextBox24 = null;
		private DataDynamics.ActiveReports.TextBox TextBox25 = null;
		private DataDynamics.ActiveReports.TextBox TextBox26 = null;
		private DataDynamics.ActiveReports.TextBox TextBox27 = null;
		private DataDynamics.ActiveReports.TextBox TextBox28 = null;
		private DataDynamics.ActiveReports.TextBox TextBox29 = null;
		private DataDynamics.ActiveReports.TextBox TextBox30 = null;
		private DataDynamics.ActiveReports.TextBox TextBox31 = null;
		private DataDynamics.ActiveReports.TextBox TextBox37 = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1 = null;
		private DataDynamics.ActiveReports.Label Label121 = null;
		private DataDynamics.ActiveReports.TextBox TextBox32 = null;
		private DataDynamics.ActiveReports.TextBox TextBox34 = null;
		private DataDynamics.ActiveReports.TextBox TextBox36 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		private DataDynamics.ActiveReports.Line Line9 = null;
		private DataDynamics.ActiveReports.TextBox TextBox14 = null;
		private DataDynamics.ActiveReports.Label Label122 = null;
		private DataDynamics.ActiveReports.TextBox TextBox35 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentsList));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.TextBox8 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox19 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox20 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox21 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox22 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox23 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox24 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox25 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox26 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox27 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox28 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox29 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox30 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox31 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox37 = new DataDynamics.ActiveReports.TextBox();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.TextBox14 = new DataDynamics.ActiveReports.TextBox();
            this.Label122 = new DataDynamics.ActiveReports.Label();
            this.TextBox35 = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.lblCriterias = new DataDynamics.ActiveReports.Label();
            this.Shape3 = new DataDynamics.ActiveReports.Shape();
            this.lblDate = new DataDynamics.ActiveReports.Label();
            this.lblTime = new DataDynamics.ActiveReports.Label();
            this.Label104 = new DataDynamics.ActiveReports.Label();
            this.Label107 = new DataDynamics.ActiveReports.Label();
            this.Label108 = new DataDynamics.ActiveReports.Label();
            this.Label109 = new DataDynamics.ActiveReports.Label();
            this.Label110 = new DataDynamics.ActiveReports.Label();
            this.Label80 = new DataDynamics.ActiveReports.Label();
            this.TextBox17 = new DataDynamics.ActiveReports.TextBox();
            this.Label111 = new DataDynamics.ActiveReports.Label();
            this.Label112 = new DataDynamics.ActiveReports.Label();
            this.Label113 = new DataDynamics.ActiveReports.Label();
            this.Label114 = new DataDynamics.ActiveReports.Label();
            this.Label115 = new DataDynamics.ActiveReports.Label();
            this.Label116 = new DataDynamics.ActiveReports.Label();
            this.Label117 = new DataDynamics.ActiveReports.Label();
            this.Label118 = new DataDynamics.ActiveReports.Label();
            this.Label119 = new DataDynamics.ActiveReports.Label();
            this.Label123 = new DataDynamics.ActiveReports.Label();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.GroupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.Label120 = new DataDynamics.ActiveReports.Label();
            this.TextBox33 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox18 = new DataDynamics.ActiveReports.TextBox();
            this.GroupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.Label121 = new DataDynamics.ActiveReports.Label();
            this.TextBox32 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox34 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox36 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label122)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label110)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label112)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label113)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label114)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label115)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label116)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label117)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label118)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label119)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label123)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label120)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label121)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TextBox8,
            this.TextBox19,
            this.TextBox20,
            this.TextBox21,
            this.TextBox22,
            this.TextBox23,
            this.TextBox24,
            this.TextBox25,
            this.TextBox26,
            this.TextBox27,
            this.TextBox28,
            this.TextBox29,
            this.TextBox30,
            this.TextBox31,
            this.TextBox37});
            this.Detail.Height = 0.125F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // TextBox8
            // 
            this.TextBox8.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox8.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox8.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox8.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox8.DataField = "TaskControlID";
            this.TextBox8.Height = 0.125F;
            this.TextBox8.Left = 0.1875F;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox8.Text = null;
            this.TextBox8.Top = 0F;
            this.TextBox8.Width = 0.625F;
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
            this.TextBox19.DataField = "Name";
            this.TextBox19.Height = 0.125F;
            this.TextBox19.Left = 0.875F;
            this.TextBox19.Name = "TextBox19";
            this.TextBox19.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox19.Text = null;
            this.TextBox19.Top = 0F;
            this.TextBox19.Width = 1.75F;
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
            this.TextBox20.DataField = "PolicyType";
            this.TextBox20.Height = 0.125F;
            this.TextBox20.Left = 2.6875F;
            this.TextBox20.Name = "TextBox20";
            this.TextBox20.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox20.Text = null;
            this.TextBox20.Top = 0F;
            this.TextBox20.Width = 0.4375F;
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
            this.TextBox21.DataField = "PolicyNo";
            this.TextBox21.Height = 0.125F;
            this.TextBox21.Left = 3.3125F;
            this.TextBox21.Name = "TextBox21";
            this.TextBox21.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox21.Text = null;
            this.TextBox21.Top = 0F;
            this.TextBox21.Width = 0.75F;
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
            this.TextBox22.DataField = "Certificate";
            this.TextBox22.Height = 0.125F;
            this.TextBox22.Left = 4F;
            this.TextBox22.Name = "TextBox22";
            this.TextBox22.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox22.Text = null;
            this.TextBox22.Top = 0F;
            this.TextBox22.Width = 0.75F;
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
            this.TextBox23.DataField = "Sufijo";
            this.TextBox23.Height = 0.125F;
            this.TextBox23.Left = 4.8125F;
            this.TextBox23.Name = "TextBox23";
            this.TextBox23.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox23.Text = null;
            this.TextBox23.Top = 0F;
            this.TextBox23.Width = 0.427083F;
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
            this.TextBox24.DataField = "LoanNo";
            this.TextBox24.Height = 0.125F;
            this.TextBox24.Left = 5.375F;
            this.TextBox24.Name = "TextBox24";
            this.TextBox24.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox24.Text = "LoanNo";
            this.TextBox24.Top = 0F;
            this.TextBox24.Width = 0.6770834F;
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
            this.TextBox25.DataField = "InvoiceNo";
            this.TextBox25.Height = 0.125F;
            this.TextBox25.Left = 6.125F;
            this.TextBox25.Name = "TextBox25";
            this.TextBox25.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox25.Text = "InvoiceNo";
            this.TextBox25.Top = 0F;
            this.TextBox25.Width = 0.7395833F;
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
            this.TextBox26.DataField = "CheckNo";
            this.TextBox26.Height = 0.125F;
            this.TextBox26.Left = 7F;
            this.TextBox26.Name = "TextBox26";
            this.TextBox26.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox26.Text = "CheckNo";
            this.TextBox26.Top = 0F;
            this.TextBox26.Width = 0.7395833F;
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
            this.TextBox27.DataField = "PaymentDate";
            this.TextBox27.Height = 0.125F;
            this.TextBox27.Left = 7.875F;
            this.TextBox27.Name = "TextBox27";
            this.TextBox27.OutputFormat = resources.GetString("TextBox27.OutputFormat");
            this.TextBox27.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox27.Text = "PaymentDate";
            this.TextBox27.Top = 0F;
            this.TextBox27.Width = 0.6770834F;
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
            this.TextBox28.DataField = "PaymentAmount";
            this.TextBox28.Height = 0.125F;
            this.TextBox28.Left = 8.6875F;
            this.TextBox28.Name = "TextBox28";
            this.TextBox28.OutputFormat = resources.GetString("TextBox28.OutputFormat");
            this.TextBox28.Style = "text-align: right; font-size: 7pt; ";
            this.TextBox28.Text = "PaymentAmount";
            this.TextBox28.Top = 0F;
            this.TextBox28.Width = 0.875F;
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
            this.TextBox29.DataField = "AppliedDate";
            this.TextBox29.Height = 0.125F;
            this.TextBox29.Left = 9.625F;
            this.TextBox29.Name = "TextBox29";
            this.TextBox29.OutputFormat = resources.GetString("TextBox29.OutputFormat");
            this.TextBox29.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox29.Text = "AppliedDate";
            this.TextBox29.Top = 0F;
            this.TextBox29.Width = 0.7395833F;
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
            this.TextBox30.DataField = "DepositDate";
            this.TextBox30.Height = 0.125F;
            this.TextBox30.Left = 10.5625F;
            this.TextBox30.Name = "TextBox30";
            this.TextBox30.OutputFormat = resources.GetString("TextBox30.OutputFormat");
            this.TextBox30.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox30.Text = "DepositDate";
            this.TextBox30.Top = 0F;
            this.TextBox30.Width = 0.7395833F;
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
            this.TextBox31.DataField = "EntryDate";
            this.TextBox31.Height = 0.125F;
            this.TextBox31.Left = 11.4375F;
            this.TextBox31.MultiLine = false;
            this.TextBox31.Name = "TextBox31";
            this.TextBox31.OutputFormat = resources.GetString("TextBox31.OutputFormat");
            this.TextBox31.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox31.Text = "EntryDate";
            this.TextBox31.Top = 0F;
            this.TextBox31.Width = 0.6875F;
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
            this.TextBox37.CanShrink = true;
            this.TextBox37.DataField = "Comments";
            this.TextBox37.Height = 0.125F;
            this.TextBox37.Left = 12.25F;
            this.TextBox37.Name = "TextBox37";
            this.TextBox37.OutputFormat = resources.GetString("TextBox37.OutputFormat");
            this.TextBox37.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox37.Text = "Comments";
            this.TextBox37.Top = 0F;
            this.TextBox37.Width = 1.0625F;
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
            this.TextBox14,
            this.Label122,
            this.TextBox35});
            this.ReportFooter.Height = 0.4159722F;
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
            this.Line9.Left = 0.25F;
            this.Line9.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 0.0625F;
            this.Line9.Width = 13.125F;
            this.Line9.X1 = 0.25F;
            this.Line9.X2 = 13.375F;
            this.Line9.Y1 = 0.0625F;
            this.Line9.Y2 = 0.0625F;
            // 
            // TextBox14
            // 
            this.TextBox14.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox14.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox14.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox14.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox14.DataField = "TaskControlID";
            this.TextBox14.Height = 0.2F;
            this.TextBox14.Left = 1.125F;
            this.TextBox14.Name = "TextBox14";
            this.TextBox14.Style = "font-weight: bold; font-size: 8pt; ";
            this.TextBox14.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox14.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TextBox14.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox14.Text = "TaskControlID";
            this.TextBox14.Top = 0.125F;
            this.TextBox14.Width = 1F;
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
            this.Label122.Height = 0.2F;
            this.Label122.HyperLink = "";
            this.Label122.Left = 0.25F;
            this.Label122.Name = "Label122";
            this.Label122.Style = "font-weight: bold; font-size: 8pt; ";
            this.Label122.Text = "Grand Total:";
            this.Label122.Top = 0.125F;
            this.Label122.Width = 0.75F;
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
            this.TextBox35.DataField = "PaymentAmount";
            this.TextBox35.Height = 0.2F;
            this.TextBox35.Left = 8.5625F;
            this.TextBox35.Name = "TextBox35";
            this.TextBox35.OutputFormat = resources.GetString("TextBox35.OutputFormat");
            this.TextBox35.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox35.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox35.Text = "PaymentAmount";
            this.TextBox35.Top = 0.125F;
            this.TextBox35.Width = 1F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblCriterias,
            this.Shape3,
            this.lblDate,
            this.lblTime,
            this.Label104,
            this.Label107,
            this.Label108,
            this.Label109,
            this.Label110,
            this.Label80,
            this.TextBox17,
            this.Label111,
            this.Label112,
            this.Label113,
            this.Label114,
            this.Label115,
            this.Label116,
            this.Label117,
            this.Label118,
            this.Label119,
            this.Label123,
            this.Label75});
            this.PageHeader.Height = 1.302083F;
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
            this.lblCriterias.Left = 4.1875F;
            this.lblCriterias.MultiLine = false;
            this.lblCriterias.Name = "lblCriterias";
            this.lblCriterias.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.lblCriterias.Text = "Payments List";
            this.lblCriterias.Top = 0.5625F;
            this.lblCriterias.Width = 5.125F;
            // 
            // Shape3
            // 
            this.Shape3.BackColor = System.Drawing.Color.LightGray;
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
            this.Shape3.Top = 0.875F;
            this.Shape3.Width = 13.3125F;
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
            this.Label104.Left = 5.25F;
            this.Label104.Name = "Label104";
            this.Label104.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label104.Text = "Loan No.";
            this.Label104.Top = 0.875F;
            this.Label104.Width = 0.75F;
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
            this.Label107.Left = 0.25F;
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
            this.Label108.Left = 0.9375F;
            this.Label108.Name = "Label108";
            this.Label108.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label108.Text = "Customer Name";
            this.Label108.Top = 0.875F;
            this.Label108.Width = 0.9375F;
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
            this.Label109.Left = 11.375F;
            this.Label109.Name = "Label109";
            this.Label109.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label109.Text = "Entry Date";
            this.Label109.Top = 0.875F;
            this.Label109.Width = 0.6875F;
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
            this.Label110.Left = 6F;
            this.Label110.Name = "Label110";
            this.Label110.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label110.Text = "Invoice No";
            this.Label110.Top = 0.875F;
            this.Label110.Width = 0.875F;
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
            this.Label80.Left = 11.5F;
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
            this.TextBox17.Left = 12.0625F;
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
            this.Label111.Height = 0.3125F;
            this.Label111.HyperLink = "";
            this.Label111.Left = 2.625F;
            this.Label111.Name = "Label111";
            this.Label111.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label111.Text = "Policy Type";
            this.Label111.Top = 0.875F;
            this.Label111.Width = 0.5625F;
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
            this.Label112.Left = 3.25F;
            this.Label112.Name = "Label112";
            this.Label112.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label112.Text = "PolicyNo";
            this.Label112.Top = 0.875F;
            this.Label112.Width = 0.6875F;
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
            this.Label113.Height = 0.2F;
            this.Label113.HyperLink = "";
            this.Label113.Left = 4F;
            this.Label113.Name = "Label113";
            this.Label113.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label113.Text = "Certificate";
            this.Label113.Top = 0.875F;
            this.Label113.Width = 0.75F;
            // 
            // Label114
            // 
            this.Label114.Border.BottomColor = System.Drawing.Color.Black;
            this.Label114.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label114.Border.LeftColor = System.Drawing.Color.Black;
            this.Label114.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label114.Border.RightColor = System.Drawing.Color.Black;
            this.Label114.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label114.Border.TopColor = System.Drawing.Color.Black;
            this.Label114.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label114.Height = 0.2F;
            this.Label114.HyperLink = "";
            this.Label114.Left = 4.8125F;
            this.Label114.Name = "Label114";
            this.Label114.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label114.Text = "Sufijo";
            this.Label114.Top = 0.875F;
            this.Label114.Width = 0.375F;
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
            this.Label115.Height = 0.2F;
            this.Label115.HyperLink = "";
            this.Label115.Left = 6.875F;
            this.Label115.Name = "Label115";
            this.Label115.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label115.Text = "CheckNo";
            this.Label115.Top = 0.875F;
            this.Label115.Width = 0.875F;
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
            this.Label116.Height = 0.3125F;
            this.Label116.HyperLink = "";
            this.Label116.Left = 7.8125F;
            this.Label116.Name = "Label116";
            this.Label116.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label116.Text = "Payment Date";
            this.Label116.Top = 0.875F;
            this.Label116.Width = 0.75F;
            // 
            // Label117
            // 
            this.Label117.Border.BottomColor = System.Drawing.Color.Black;
            this.Label117.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label117.Border.LeftColor = System.Drawing.Color.Black;
            this.Label117.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label117.Border.RightColor = System.Drawing.Color.Black;
            this.Label117.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label117.Border.TopColor = System.Drawing.Color.Black;
            this.Label117.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label117.Height = 0.3125F;
            this.Label117.HyperLink = "";
            this.Label117.Left = 8.625F;
            this.Label117.Name = "Label117";
            this.Label117.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label117.Text = "Payment Amount";
            this.Label117.Top = 0.875F;
            this.Label117.Width = 0.8125F;
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
            this.Label118.Height = 0.2F;
            this.Label118.HyperLink = "";
            this.Label118.Left = 9.5F;
            this.Label118.Name = "Label118";
            this.Label118.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label118.Text = "Applied Date";
            this.Label118.Top = 0.875F;
            this.Label118.Width = 0.875F;
            // 
            // Label119
            // 
            this.Label119.Border.BottomColor = System.Drawing.Color.Black;
            this.Label119.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label119.Border.LeftColor = System.Drawing.Color.Black;
            this.Label119.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label119.Border.RightColor = System.Drawing.Color.Black;
            this.Label119.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label119.Border.TopColor = System.Drawing.Color.Black;
            this.Label119.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label119.Height = 0.2F;
            this.Label119.HyperLink = "";
            this.Label119.Left = 10.4375F;
            this.Label119.Name = "Label119";
            this.Label119.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label119.Text = "Deposit Date";
            this.Label119.Top = 0.875F;
            this.Label119.Width = 0.875F;
            // 
            // Label123
            // 
            this.Label123.Border.BottomColor = System.Drawing.Color.Black;
            this.Label123.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label123.Border.LeftColor = System.Drawing.Color.Black;
            this.Label123.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label123.Border.RightColor = System.Drawing.Color.Black;
            this.Label123.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label123.Border.TopColor = System.Drawing.Color.Black;
            this.Label123.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label123.Height = 0.2F;
            this.Label123.HyperLink = "";
            this.Label123.Left = 12.25F;
            this.Label123.Name = "Label123";
            this.Label123.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label123.Text = "Comments";
            this.Label123.Top = 0.875F;
            this.Label123.Width = 0.6875F;
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
            this.Label75.Left = 4.1875F;
            this.Label75.MultiLine = false;
            this.Label75.Name = "Label75";
            this.Label75.Style = "text-align: center; font-weight: bold; font-size: 11.25pt; font-family: Times New" +
                " Roman; ";
            this.Label75.Text = "PUERTO RICO MEDICAL DEFENSE INSURANCE COMPANY";
            this.Label75.Top = 0.1875F;
            this.Label75.Width = 5.125F;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label120,
            this.TextBox33,
            this.TextBox18});
            this.GroupHeader1.DataField = "PolicyClassDesc";
            this.GroupHeader1.Height = 0.21875F;
            this.GroupHeader1.KeepTogether = true;
            this.GroupHeader1.Name = "GroupHeader1";
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
            this.Label120.Height = 0.2F;
            this.Label120.HyperLink = "";
            this.Label120.Left = 0.25F;
            this.Label120.Name = "Label120";
            this.Label120.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label120.Text = "Line Of business";
            this.Label120.Top = 0F;
            this.Label120.Width = 1.0625F;
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
            this.TextBox33.DataField = "PolicyClassDesc";
            this.TextBox33.Height = 0.1875F;
            this.TextBox33.HyperLink = "ProspectIndividual.aspx";
            this.TextBox33.Left = 2F;
            this.TextBox33.Name = "TextBox33";
            this.TextBox33.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.TextBox33.Text = "LineOfBusiness";
            this.TextBox33.Top = 0.875F;
            this.TextBox33.Width = 2.364583F;
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
            this.TextBox18.DataField = "PolicyClassDesc";
            this.TextBox18.Height = 0.1875F;
            this.TextBox18.HyperLink = "ProspectIndividual.aspx";
            this.TextBox18.Left = 1.375F;
            this.TextBox18.Name = "TextBox18";
            this.TextBox18.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.TextBox18.Text = "LineOfBusiness";
            this.TextBox18.Top = 0F;
            this.TextBox18.Width = 2.364583F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label121,
            this.TextBox32,
            this.TextBox34,
            this.TextBox36});
            this.GroupFooter1.Height = 0.2291667F;
            this.GroupFooter1.KeepTogether = true;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.Format += new System.EventHandler(this.GroupFooter1_Format);
            // 
            // Label121
            // 
            this.Label121.Border.BottomColor = System.Drawing.Color.Black;
            this.Label121.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label121.Border.LeftColor = System.Drawing.Color.Black;
            this.Label121.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label121.Border.RightColor = System.Drawing.Color.Black;
            this.Label121.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label121.Border.TopColor = System.Drawing.Color.Black;
            this.Label121.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label121.Height = 0.2F;
            this.Label121.HyperLink = "";
            this.Label121.Left = 0.4375F;
            this.Label121.Name = "Label121";
            this.Label121.Style = "font-weight: bold; font-size: 8pt; ";
            this.Label121.Text = "Sub Total for Line of Business:";
            this.Label121.Top = 0F;
            this.Label121.Width = 1.75F;
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
            this.TextBox32.DataField = "TaskControlID";
            this.TextBox32.Height = 0.2F;
            this.TextBox32.Left = 4.6875F;
            this.TextBox32.Name = "TextBox32";
            this.TextBox32.Style = "font-weight: bold; font-size: 8pt; ";
            this.TextBox32.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox32.SummaryGroup = "GroupHeader1";
            this.TextBox32.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TextBox32.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox32.Text = "TaskControlID";
            this.TextBox32.Top = 0F;
            this.TextBox32.Width = 0.875F;
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
            this.TextBox34.DataField = "PolicyClassDesc";
            this.TextBox34.Height = 0.1875F;
            this.TextBox34.HyperLink = "ProspectIndividual.aspx";
            this.TextBox34.Left = 2.1875F;
            this.TextBox34.Name = "TextBox34";
            this.TextBox34.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.TextBox34.Text = "LineOfBusiness";
            this.TextBox34.Top = 0F;
            this.TextBox34.Width = 2.364583F;
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
            this.TextBox36.DataField = "PaymentAmount";
            this.TextBox36.Height = 0.2F;
            this.TextBox36.Left = 8.5625F;
            this.TextBox36.Name = "TextBox36";
            this.TextBox36.OutputFormat = resources.GetString("TextBox36.OutputFormat");
            this.TextBox36.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TextBox36.SummaryGroup = "GroupHeader1";
            this.TextBox36.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TextBox36.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox36.Text = "PaymentAmount";
            this.TextBox36.Top = 0F;
            this.TextBox36.Width = 1F;
            // 
            // PaymentsList
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.1F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0.3F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 14F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Legal;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 13.92708F;
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
            this.PageStart += new System.EventHandler(this.PaymentsList_PageStart);
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label122)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label110)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label112)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label113)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label114)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label115)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label116)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label117)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label118)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label119)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label123)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label120)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label121)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
