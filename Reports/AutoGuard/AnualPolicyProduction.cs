using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.AutoGuard
{
	public class AnualPolicyProduction : DataDynamics.ActiveReports.ActiveReport3
	{
		string _FromDate;
		string _ToDate;
		string _ReportType;
		bool   _Summary = false;
        string _mHeadCompany = "";

        public AnualPolicyProduction(string FromDate, string ToDate, string ReportType, bool Summary, string mHeadCompany)
		{
			_FromDate = FromDate;
			_ToDate = ToDate;
			_ReportType = ReportType;
			_Summary  =  Summary;
            _mHeadCompany = mHeadCompany;

			InitializeComponent();
		}
		private void AnualPolicyProduction_ReportStart(object sender, System.EventArgs eArgs)
		{
            Label236.Text = _mHeadCompany;
			if (_Summary)
			{
				this.Detail.Visible = false;
			}

			this.lblDate.Text = "Date:"+DateTime.Now.ToShortDateString();
			this.lblTime.Text = "Time:"+DateTime.Now.ToShortTimeString();

			if (!_FromDate.Trim().Equals("")||(!_FromDate.Trim().Equals("")))
			{
				this.lblCriterias.Text = _FromDate;
			}
		}

		private void ReportHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		#region ActiveReports Designer generated code
		private ReportHeader ReportHeader = null;
		private Label lblDate = null;
		private Label lblTime = null;
		private TextBox TextBox17 = null;
		private Label Label80 = null;
		private Label lblCriterias = null;
		private Label Label237 = null;
		private Label Label236 = null;
		private PageHeader PageHeader = null;
		private Label Label201 = null;
		private Label Label202 = null;
		private Label Label203 = null;
		private Label Label204 = null;
		private Label Label205 = null;
		private Label Label206 = null;
		private Label Label207 = null;
		private Label Label208 = null;
		private Label Label210 = null;
		private Label Label211 = null;
		private Label Label212 = null;
		private Label Label200 = null;
		private Label Label232 = null;
		private Label Label235 = null;
		private Label Label209 = null;
		private Detail Detail = null;
		private Label Label133 = null;
		private TextBox TextBox32 = null;
		private TextBox TextBox33 = null;
		private TextBox TextBox34 = null;
		private TextBox TextBox35 = null;
		private TextBox TextBox36 = null;
		private TextBox TextBox37 = null;
		private TextBox TextBox38 = null;
		private TextBox TextBox39 = null;
		private TextBox TextBox40 = null;
		private TextBox TextBox41 = null;
		private TextBox TextBox42 = null;
		private TextBox TextBox43 = null;
		private TextBox TextBox63 = null;
		private TextBox TextBox97 = null;
		private PageFooter PageFooter = null;
		private ReportFooter ReportFooter = null;
		private Line Line166 = null;
		private TextBox TextBox65 = null;
		private TextBox TextBox66 = null;
		private TextBox TextBox67 = null;
		private TextBox TextBox68 = null;
		private TextBox TextBox69 = null;
		private TextBox TextBox70 = null;
		private TextBox TextBox71 = null;
		private TextBox TextBox72 = null;
		private TextBox TextBox73 = null;
		private TextBox TextBox74 = null;
		private TextBox TextBox75 = null;
		private TextBox TextBox76 = null;
		private Label Label234 = null;
		private TextBox TextBox96 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnualPolicyProduction));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.Label133 = new DataDynamics.ActiveReports.Label();
            this.TextBox32 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox33 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox34 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox35 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox36 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox37 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox38 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox39 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox40 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox41 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox42 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox43 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox63 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox97 = new DataDynamics.ActiveReports.TextBox();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.lblDate = new DataDynamics.ActiveReports.Label();
            this.lblTime = new DataDynamics.ActiveReports.Label();
            this.TextBox17 = new DataDynamics.ActiveReports.TextBox();
            this.Label80 = new DataDynamics.ActiveReports.Label();
            this.lblCriterias = new DataDynamics.ActiveReports.Label();
            this.Label237 = new DataDynamics.ActiveReports.Label();
            this.Label236 = new DataDynamics.ActiveReports.Label();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.Line166 = new DataDynamics.ActiveReports.Line();
            this.TextBox65 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox66 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox67 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox68 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox69 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox70 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox71 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox72 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox73 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox74 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox75 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox76 = new DataDynamics.ActiveReports.TextBox();
            this.Label234 = new DataDynamics.ActiveReports.Label();
            this.TextBox96 = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label201 = new DataDynamics.ActiveReports.Label();
            this.Label202 = new DataDynamics.ActiveReports.Label();
            this.Label203 = new DataDynamics.ActiveReports.Label();
            this.Label204 = new DataDynamics.ActiveReports.Label();
            this.Label205 = new DataDynamics.ActiveReports.Label();
            this.Label206 = new DataDynamics.ActiveReports.Label();
            this.Label207 = new DataDynamics.ActiveReports.Label();
            this.Label208 = new DataDynamics.ActiveReports.Label();
            this.Label210 = new DataDynamics.ActiveReports.Label();
            this.Label211 = new DataDynamics.ActiveReports.Label();
            this.Label212 = new DataDynamics.ActiveReports.Label();
            this.Label200 = new DataDynamics.ActiveReports.Label();
            this.Label232 = new DataDynamics.ActiveReports.Label();
            this.Label235 = new DataDynamics.ActiveReports.Label();
            this.Label209 = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox97)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label237)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label236)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox67)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox68)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox69)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox72)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox73)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox74)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox76)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label234)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox96)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label201)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label202)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label203)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label204)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label205)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label206)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label207)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label208)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label210)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label211)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label212)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label200)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label232)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label235)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label209)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label133,
            this.TextBox32,
            this.TextBox33,
            this.TextBox34,
            this.TextBox35,
            this.TextBox36,
            this.TextBox37,
            this.TextBox38,
            this.TextBox39,
            this.TextBox40,
            this.TextBox41,
            this.TextBox42,
            this.TextBox43,
            this.TextBox63,
            this.TextBox97});
            this.Detail.Height = 0.21875F;
            this.Detail.Name = "Detail";
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
            this.Label133.DataField = "CompanyDealerDesc";
            this.Label133.Height = 0.2F;
            this.Label133.HyperLink = "";
            this.Label133.Left = 0.8125F;
            this.Label133.Name = "Label133";
            this.Label133.Style = "text-align: left; font-weight: bold; background-color: Gainsboro; font-size: 7pt;" +
                " ";
            this.Label133.Text = "";
            this.Label133.Top = 0F;
            this.Label133.Width = 1.5625F;
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
            this.TextBox32.DataField = "MES_1";
            this.TextBox32.Height = 0.2F;
            this.TextBox32.Left = 2.8125F;
            this.TextBox32.Name = "TextBox32";
            this.TextBox32.Style = "text-align: center; background-color: Gainsboro; font-size: 7pt; ";
            this.TextBox32.Text = null;
            this.TextBox32.Top = 0F;
            this.TextBox32.Width = 0.6875F;
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
            this.TextBox33.DataField = "MES_2";
            this.TextBox33.Height = 0.2F;
            this.TextBox33.Left = 3.5625F;
            this.TextBox33.Name = "TextBox33";
            this.TextBox33.Style = "text-align: center; background-color: Gainsboro; font-size: 7pt; ";
            this.TextBox33.Text = null;
            this.TextBox33.Top = 0F;
            this.TextBox33.Width = 0.6875F;
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
            this.TextBox34.DataField = "MES_3";
            this.TextBox34.Height = 0.2F;
            this.TextBox34.Left = 4.3125F;
            this.TextBox34.Name = "TextBox34";
            this.TextBox34.Style = "text-align: center; background-color: Gainsboro; font-size: 7pt; ";
            this.TextBox34.Text = null;
            this.TextBox34.Top = 0F;
            this.TextBox34.Width = 0.6875F;
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
            this.TextBox35.DataField = "MES_4";
            this.TextBox35.Height = 0.2F;
            this.TextBox35.Left = 5.0625F;
            this.TextBox35.Name = "TextBox35";
            this.TextBox35.Style = "text-align: center; background-color: Gainsboro; font-size: 7pt; ";
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
            this.TextBox36.DataField = "MES_5";
            this.TextBox36.Height = 0.2F;
            this.TextBox36.Left = 5.8125F;
            this.TextBox36.Name = "TextBox36";
            this.TextBox36.Style = "text-align: center; background-color: Gainsboro; font-size: 7pt; ";
            this.TextBox36.Text = null;
            this.TextBox36.Top = 0F;
            this.TextBox36.Width = 0.6875F;
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
            this.TextBox37.DataField = "MES_6";
            this.TextBox37.Height = 0.2F;
            this.TextBox37.Left = 6.5625F;
            this.TextBox37.Name = "TextBox37";
            this.TextBox37.Style = "text-align: center; background-color: Gainsboro; font-size: 7pt; ";
            this.TextBox37.Text = null;
            this.TextBox37.Top = 0F;
            this.TextBox37.Width = 0.6875F;
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
            this.TextBox38.DataField = "MES_7";
            this.TextBox38.Height = 0.2F;
            this.TextBox38.Left = 7.3125F;
            this.TextBox38.Name = "TextBox38";
            this.TextBox38.Style = "text-align: center; background-color: Gainsboro; font-size: 7pt; ";
            this.TextBox38.Text = null;
            this.TextBox38.Top = 0F;
            this.TextBox38.Width = 0.6875F;
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
            this.TextBox39.DataField = "MES_8";
            this.TextBox39.Height = 0.2F;
            this.TextBox39.Left = 8.0625F;
            this.TextBox39.Name = "TextBox39";
            this.TextBox39.Style = "text-align: center; background-color: Gainsboro; font-size: 7pt; ";
            this.TextBox39.Text = null;
            this.TextBox39.Top = 0F;
            this.TextBox39.Width = 0.6875F;
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
            this.TextBox40.DataField = "MES_9";
            this.TextBox40.Height = 0.2F;
            this.TextBox40.Left = 8.8125F;
            this.TextBox40.Name = "TextBox40";
            this.TextBox40.Style = "text-align: center; background-color: Gainsboro; font-size: 7pt; ";
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
            this.TextBox41.DataField = "MES_10";
            this.TextBox41.Height = 0.2F;
            this.TextBox41.Left = 9.5625F;
            this.TextBox41.Name = "TextBox41";
            this.TextBox41.Style = "text-align: center; background-color: Gainsboro; font-size: 7pt; ";
            this.TextBox41.Text = null;
            this.TextBox41.Top = 0F;
            this.TextBox41.Width = 0.6875F;
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
            this.TextBox42.DataField = "MES_11";
            this.TextBox42.Height = 0.2F;
            this.TextBox42.Left = 10.3125F;
            this.TextBox42.Name = "TextBox42";
            this.TextBox42.Style = "text-align: center; background-color: Gainsboro; font-size: 7pt; ";
            this.TextBox42.Text = null;
            this.TextBox42.Top = 0F;
            this.TextBox42.Width = 0.6875F;
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
            this.TextBox43.DataField = "MES_12";
            this.TextBox43.Height = 0.2F;
            this.TextBox43.Left = 11.0625F;
            this.TextBox43.Name = "TextBox43";
            this.TextBox43.Style = "text-align: center; background-color: Gainsboro; font-size: 7pt; ";
            this.TextBox43.Text = null;
            this.TextBox43.Top = 0F;
            this.TextBox43.Width = 0.6875F;
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
            this.TextBox63.DataField = "Total_cantidad";
            this.TextBox63.Height = 0.2F;
            this.TextBox63.Left = 11.8125F;
            this.TextBox63.Name = "TextBox63";
            this.TextBox63.OutputFormat = resources.GetString("TextBox63.OutputFormat");
            this.TextBox63.Style = "text-align: center; background-color: Silver; font-size: 7pt; ";
            this.TextBox63.Text = null;
            this.TextBox63.Top = 0F;
            this.TextBox63.Width = 0.6674995F;
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
            this.TextBox97.DataField = "CompanyDealerID";
            this.TextBox97.Height = 0.2F;
            this.TextBox97.Left = 2.375F;
            this.TextBox97.Name = "TextBox97";
            this.TextBox97.Style = "text-align: center; background-color: Gainsboro; font-size: 7pt; ";
            this.TextBox97.Text = null;
            this.TextBox97.Top = 0F;
            this.TextBox97.Width = 0.3125F;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblDate,
            this.lblTime,
            this.TextBox17,
            this.Label80,
            this.lblCriterias,
            this.Label237,
            this.Label236});
            this.ReportHeader.Height = 1.333333F;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.Format += new System.EventHandler(this.ReportHeader_Format);
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
            this.lblDate.Top = 0.25F;
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
            this.lblTime.Top = 0.4375F;
            this.lblTime.Width = 0.9090909F;
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
            this.TextBox17.Left = 12.16667F;
            this.TextBox17.MultiLine = false;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat");
            this.TextBox17.Style = "text-align: right; font-size: 8pt; vertical-align: top; ";
            this.TextBox17.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox17.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.TextBox17.Text = null;
            this.TextBox17.Top = 0.2541667F;
            this.TextBox17.Width = 0.4333334F;
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
            this.Label80.Height = 0.1875F;
            this.Label80.HyperLink = "";
            this.Label80.Left = 11.6875F;
            this.Label80.Name = "Label80";
            this.Label80.Style = "text-align: right; font-size: 8pt; ";
            this.Label80.Text = "Page";
            this.Label80.Top = 0.25F;
            this.Label80.Width = 0.5F;
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
            this.lblCriterias.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 10pt; ";
            this.lblCriterias.Text = "Criteria Info";
            this.lblCriterias.Top = 0.8125F;
            this.lblCriterias.Width = 5.125F;
            // 
            // Label237
            // 
            this.Label237.Border.BottomColor = System.Drawing.Color.Black;
            this.Label237.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label237.Border.LeftColor = System.Drawing.Color.Black;
            this.Label237.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label237.Border.RightColor = System.Drawing.Color.Black;
            this.Label237.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label237.Border.TopColor = System.Drawing.Color.Black;
            this.Label237.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label237.Height = 0.1875F;
            this.Label237.HyperLink = "";
            this.Label237.Left = 4.0625F;
            this.Label237.MultiLine = false;
            this.Label237.Name = "Label237";
            this.Label237.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 10pt; ";
            this.Label237.Text = "ANNUAL REPORT";
            this.Label237.Top = 0.5625F;
            this.Label237.Width = 5.125F;
            // 
            // Label236
            // 
            this.Label236.Border.BottomColor = System.Drawing.Color.Black;
            this.Label236.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label236.Border.LeftColor = System.Drawing.Color.Black;
            this.Label236.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label236.Border.RightColor = System.Drawing.Color.Black;
            this.Label236.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label236.Border.TopColor = System.Drawing.Color.Black;
            this.Label236.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label236.Height = 0.1875F;
            this.Label236.HyperLink = "";
            this.Label236.Left = 4.08F;
            this.Label236.MultiLine = false;
            this.Label236.Name = "Label236";
            this.Label236.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 12pt; ";
            this.Label236.Text = "";
            this.Label236.Top = 0.32F;
            this.Label236.Width = 5.125F;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line166,
            this.TextBox65,
            this.TextBox66,
            this.TextBox67,
            this.TextBox68,
            this.TextBox69,
            this.TextBox70,
            this.TextBox71,
            this.TextBox72,
            this.TextBox73,
            this.TextBox74,
            this.TextBox75,
            this.TextBox76,
            this.Label234,
            this.TextBox96});
            this.ReportFooter.Height = 0.625F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // Line166
            // 
            this.Line166.Border.BottomColor = System.Drawing.Color.Black;
            this.Line166.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line166.Border.LeftColor = System.Drawing.Color.Black;
            this.Line166.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line166.Border.RightColor = System.Drawing.Color.Black;
            this.Line166.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line166.Border.TopColor = System.Drawing.Color.Black;
            this.Line166.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line166.Height = 0.1875F;
            this.Line166.Left = 11.06944F;
            this.Line166.LineWeight = 1F;
            this.Line166.Name = "Line166";
            this.Line166.Top = 0.006944418F;
            this.Line166.Width = 0F;
            this.Line166.X1 = 11.06944F;
            this.Line166.X2 = 11.06944F;
            this.Line166.Y1 = 0.006944418F;
            this.Line166.Y2 = 0.1944444F;
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
            this.TextBox65.DataField = "MES_1";
            this.TextBox65.Height = 0.2F;
            this.TextBox65.Left = 2.8125F;
            this.TextBox65.Name = "TextBox65";
            this.TextBox65.Style = "text-align: center; background-color: Silver; font-size: 7pt; ";
            this.TextBox65.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox65.Text = null;
            this.TextBox65.Top = 0F;
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
            this.TextBox66.DataField = "MES_2";
            this.TextBox66.Height = 0.2F;
            this.TextBox66.Left = 3.5625F;
            this.TextBox66.Name = "TextBox66";
            this.TextBox66.Style = "text-align: center; background-color: Silver; font-size: 7pt; ";
            this.TextBox66.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox66.Text = null;
            this.TextBox66.Top = 0F;
            this.TextBox66.Width = 0.6875F;
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
            this.TextBox67.DataField = "MES_3";
            this.TextBox67.Height = 0.2F;
            this.TextBox67.Left = 4.3125F;
            this.TextBox67.Name = "TextBox67";
            this.TextBox67.Style = "text-align: center; background-color: Silver; font-size: 7pt; ";
            this.TextBox67.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox67.Text = null;
            this.TextBox67.Top = 0F;
            this.TextBox67.Width = 0.6875F;
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
            this.TextBox68.DataField = "MES_4";
            this.TextBox68.Height = 0.2F;
            this.TextBox68.Left = 5.0625F;
            this.TextBox68.Name = "TextBox68";
            this.TextBox68.Style = "text-align: center; background-color: Silver; font-size: 7pt; ";
            this.TextBox68.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox68.Text = null;
            this.TextBox68.Top = 0F;
            this.TextBox68.Width = 0.6875F;
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
            this.TextBox69.DataField = "MES_5";
            this.TextBox69.Height = 0.2F;
            this.TextBox69.Left = 5.8125F;
            this.TextBox69.Name = "TextBox69";
            this.TextBox69.Style = "text-align: center; background-color: Silver; font-size: 7pt; ";
            this.TextBox69.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox69.Text = null;
            this.TextBox69.Top = 0F;
            this.TextBox69.Width = 0.6875F;
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
            this.TextBox70.DataField = "MES_6";
            this.TextBox70.Height = 0.2F;
            this.TextBox70.Left = 6.5625F;
            this.TextBox70.Name = "TextBox70";
            this.TextBox70.Style = "text-align: center; background-color: Silver; font-size: 7pt; ";
            this.TextBox70.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox70.Text = null;
            this.TextBox70.Top = 0F;
            this.TextBox70.Width = 0.6875F;
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
            this.TextBox71.DataField = "MES_7";
            this.TextBox71.Height = 0.2F;
            this.TextBox71.Left = 7.3125F;
            this.TextBox71.Name = "TextBox71";
            this.TextBox71.Style = "text-align: center; background-color: Silver; font-size: 7pt; ";
            this.TextBox71.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
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
            this.TextBox72.DataField = "MES_8";
            this.TextBox72.Height = 0.2F;
            this.TextBox72.Left = 8.0625F;
            this.TextBox72.Name = "TextBox72";
            this.TextBox72.Style = "text-align: center; background-color: Silver; font-size: 7pt; ";
            this.TextBox72.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox72.Text = null;
            this.TextBox72.Top = 0F;
            this.TextBox72.Width = 0.6875F;
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
            this.TextBox73.DataField = "MES_9";
            this.TextBox73.Height = 0.2F;
            this.TextBox73.Left = 8.8125F;
            this.TextBox73.Name = "TextBox73";
            this.TextBox73.Style = "text-align: center; background-color: Silver; font-size: 7pt; ";
            this.TextBox73.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox73.Text = null;
            this.TextBox73.Top = 0F;
            this.TextBox73.Width = 0.6875F;
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
            this.TextBox74.DataField = "MES_10";
            this.TextBox74.Height = 0.2F;
            this.TextBox74.Left = 9.5625F;
            this.TextBox74.Name = "TextBox74";
            this.TextBox74.Style = "text-align: center; background-color: Silver; font-size: 7pt; ";
            this.TextBox74.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox74.Text = null;
            this.TextBox74.Top = 0F;
            this.TextBox74.Width = 0.6875F;
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
            this.TextBox75.DataField = "MES_11";
            this.TextBox75.Height = 0.2F;
            this.TextBox75.Left = 10.3125F;
            this.TextBox75.Name = "TextBox75";
            this.TextBox75.Style = "text-align: center; background-color: Silver; font-size: 7pt; ";
            this.TextBox75.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox75.Text = null;
            this.TextBox75.Top = 0F;
            this.TextBox75.Width = 0.6875F;
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
            this.TextBox76.DataField = "MES_12";
            this.TextBox76.Height = 0.2F;
            this.TextBox76.Left = 11.0625F;
            this.TextBox76.Name = "TextBox76";
            this.TextBox76.Style = "text-align: center; background-color: Silver; font-size: 7pt; ";
            this.TextBox76.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox76.Text = null;
            this.TextBox76.Top = 0F;
            this.TextBox76.Width = 0.6875F;
            // 
            // Label234
            // 
            this.Label234.Border.BottomColor = System.Drawing.Color.Black;
            this.Label234.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label234.Border.LeftColor = System.Drawing.Color.Black;
            this.Label234.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label234.Border.RightColor = System.Drawing.Color.Black;
            this.Label234.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label234.Border.TopColor = System.Drawing.Color.Black;
            this.Label234.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label234.Height = 0.2F;
            this.Label234.HyperLink = "";
            this.Label234.Left = 0.8125F;
            this.Label234.Name = "Label234";
            this.Label234.Style = "text-align: left; font-weight: bold; background-color: Silver; font-size: 8pt; ";
            this.Label234.Text = "Totals:";
            this.Label234.Top = 0F;
            this.Label234.Width = 1.9075F;
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
            this.TextBox96.DataField = "Total_cantidad";
            this.TextBox96.Height = 0.2F;
            this.TextBox96.Left = 11.8125F;
            this.TextBox96.Name = "TextBox96";
            this.TextBox96.OutputFormat = resources.GetString("TextBox96.OutputFormat");
            this.TextBox96.Style = "text-align: center; background-color: Silver; font-size: 7pt; ";
            this.TextBox96.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox96.Text = null;
            this.TextBox96.Top = 0F;
            this.TextBox96.Width = 0.6674995F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label201,
            this.Label202,
            this.Label203,
            this.Label204,
            this.Label205,
            this.Label206,
            this.Label207,
            this.Label208,
            this.Label210,
            this.Label211,
            this.Label212,
            this.Label200,
            this.Label232,
            this.Label235,
            this.Label209});
            this.PageHeader.Height = 0.21875F;
            this.PageHeader.Name = "PageHeader";
            // 
            // Label201
            // 
            this.Label201.Border.BottomColor = System.Drawing.Color.Black;
            this.Label201.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label201.Border.LeftColor = System.Drawing.Color.Black;
            this.Label201.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label201.Border.RightColor = System.Drawing.Color.Black;
            this.Label201.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label201.Border.TopColor = System.Drawing.Color.Black;
            this.Label201.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label201.Height = 0.2F;
            this.Label201.HyperLink = "";
            this.Label201.Left = 2.8125F;
            this.Label201.MultiLine = false;
            this.Label201.Name = "Label201";
            this.Label201.Style = "text-align: center; font-weight: bold; background-color: Gainsboro; font-size: 8p" +
                "t; ";
            this.Label201.Text = "Enero";
            this.Label201.Top = 0F;
            this.Label201.Width = 0.6875F;
            // 
            // Label202
            // 
            this.Label202.Border.BottomColor = System.Drawing.Color.Black;
            this.Label202.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label202.Border.LeftColor = System.Drawing.Color.Black;
            this.Label202.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label202.Border.RightColor = System.Drawing.Color.Black;
            this.Label202.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label202.Border.TopColor = System.Drawing.Color.Black;
            this.Label202.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label202.Height = 0.2F;
            this.Label202.HyperLink = "";
            this.Label202.Left = 3.5625F;
            this.Label202.MultiLine = false;
            this.Label202.Name = "Label202";
            this.Label202.Style = "text-align: center; font-weight: bold; background-color: Gainsboro; font-size: 8p" +
                "t; ";
            this.Label202.Text = "Febrero";
            this.Label202.Top = 0F;
            this.Label202.Width = 0.6875F;
            // 
            // Label203
            // 
            this.Label203.Border.BottomColor = System.Drawing.Color.Black;
            this.Label203.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label203.Border.LeftColor = System.Drawing.Color.Black;
            this.Label203.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label203.Border.RightColor = System.Drawing.Color.Black;
            this.Label203.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label203.Border.TopColor = System.Drawing.Color.Black;
            this.Label203.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label203.Height = 0.2F;
            this.Label203.HyperLink = "";
            this.Label203.Left = 4.3125F;
            this.Label203.MultiLine = false;
            this.Label203.Name = "Label203";
            this.Label203.Style = "text-align: center; font-weight: bold; background-color: Gainsboro; font-size: 8p" +
                "t; ";
            this.Label203.Text = "Marzo";
            this.Label203.Top = 0F;
            this.Label203.Width = 0.6875F;
            // 
            // Label204
            // 
            this.Label204.Border.BottomColor = System.Drawing.Color.Black;
            this.Label204.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label204.Border.LeftColor = System.Drawing.Color.Black;
            this.Label204.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label204.Border.RightColor = System.Drawing.Color.Black;
            this.Label204.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label204.Border.TopColor = System.Drawing.Color.Black;
            this.Label204.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label204.Height = 0.2F;
            this.Label204.HyperLink = "";
            this.Label204.Left = 5.0625F;
            this.Label204.MultiLine = false;
            this.Label204.Name = "Label204";
            this.Label204.Style = "text-align: center; font-weight: bold; background-color: Gainsboro; font-size: 8p" +
                "t; ";
            this.Label204.Text = "Abril";
            this.Label204.Top = 0F;
            this.Label204.Width = 0.6875F;
            // 
            // Label205
            // 
            this.Label205.Border.BottomColor = System.Drawing.Color.Black;
            this.Label205.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label205.Border.LeftColor = System.Drawing.Color.Black;
            this.Label205.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label205.Border.RightColor = System.Drawing.Color.Black;
            this.Label205.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label205.Border.TopColor = System.Drawing.Color.Black;
            this.Label205.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label205.Height = 0.2F;
            this.Label205.HyperLink = "";
            this.Label205.Left = 5.8125F;
            this.Label205.MultiLine = false;
            this.Label205.Name = "Label205";
            this.Label205.Style = "text-align: center; font-weight: bold; background-color: Gainsboro; font-size: 8p" +
                "t; ";
            this.Label205.Text = "Mayo";
            this.Label205.Top = 0F;
            this.Label205.Width = 0.6875F;
            // 
            // Label206
            // 
            this.Label206.Border.BottomColor = System.Drawing.Color.Black;
            this.Label206.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label206.Border.LeftColor = System.Drawing.Color.Black;
            this.Label206.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label206.Border.RightColor = System.Drawing.Color.Black;
            this.Label206.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label206.Border.TopColor = System.Drawing.Color.Black;
            this.Label206.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label206.Height = 0.2F;
            this.Label206.HyperLink = "";
            this.Label206.Left = 6.5625F;
            this.Label206.MultiLine = false;
            this.Label206.Name = "Label206";
            this.Label206.Style = "text-align: center; font-weight: bold; background-color: Gainsboro; font-size: 8p" +
                "t; ";
            this.Label206.Text = "Junio";
            this.Label206.Top = 0F;
            this.Label206.Width = 0.6875F;
            // 
            // Label207
            // 
            this.Label207.Border.BottomColor = System.Drawing.Color.Black;
            this.Label207.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label207.Border.LeftColor = System.Drawing.Color.Black;
            this.Label207.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label207.Border.RightColor = System.Drawing.Color.Black;
            this.Label207.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label207.Border.TopColor = System.Drawing.Color.Black;
            this.Label207.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label207.Height = 0.2F;
            this.Label207.HyperLink = "";
            this.Label207.Left = 7.3125F;
            this.Label207.MultiLine = false;
            this.Label207.Name = "Label207";
            this.Label207.Style = "text-align: center; font-weight: bold; background-color: Gainsboro; font-size: 8p" +
                "t; ";
            this.Label207.Text = "Julio";
            this.Label207.Top = 0F;
            this.Label207.Width = 0.6875F;
            // 
            // Label208
            // 
            this.Label208.Border.BottomColor = System.Drawing.Color.Black;
            this.Label208.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label208.Border.LeftColor = System.Drawing.Color.Black;
            this.Label208.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label208.Border.RightColor = System.Drawing.Color.Black;
            this.Label208.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label208.Border.TopColor = System.Drawing.Color.Black;
            this.Label208.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label208.Height = 0.2F;
            this.Label208.HyperLink = "";
            this.Label208.Left = 8.0625F;
            this.Label208.MultiLine = false;
            this.Label208.Name = "Label208";
            this.Label208.Style = "text-align: center; font-weight: bold; background-color: Gainsboro; font-size: 8p" +
                "t; ";
            this.Label208.Text = "Agosto";
            this.Label208.Top = 0F;
            this.Label208.Width = 0.6875F;
            // 
            // Label210
            // 
            this.Label210.Border.BottomColor = System.Drawing.Color.Black;
            this.Label210.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label210.Border.LeftColor = System.Drawing.Color.Black;
            this.Label210.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label210.Border.RightColor = System.Drawing.Color.Black;
            this.Label210.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label210.Border.TopColor = System.Drawing.Color.Black;
            this.Label210.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label210.Height = 0.2F;
            this.Label210.HyperLink = "";
            this.Label210.Left = 9.5625F;
            this.Label210.MultiLine = false;
            this.Label210.Name = "Label210";
            this.Label210.Style = "text-align: center; font-weight: bold; background-color: Gainsboro; font-size: 8p" +
                "t; ";
            this.Label210.Text = "Octubre";
            this.Label210.Top = 0F;
            this.Label210.Width = 0.6875F;
            // 
            // Label211
            // 
            this.Label211.Border.BottomColor = System.Drawing.Color.Black;
            this.Label211.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label211.Border.LeftColor = System.Drawing.Color.Black;
            this.Label211.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label211.Border.RightColor = System.Drawing.Color.Black;
            this.Label211.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label211.Border.TopColor = System.Drawing.Color.Black;
            this.Label211.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label211.Height = 0.2F;
            this.Label211.HyperLink = "";
            this.Label211.Left = 10.3125F;
            this.Label211.MultiLine = false;
            this.Label211.Name = "Label211";
            this.Label211.Style = "text-align: center; font-weight: bold; background-color: Gainsboro; font-size: 8p" +
                "t; ";
            this.Label211.Text = "Noviembre";
            this.Label211.Top = 0F;
            this.Label211.Width = 0.6875F;
            // 
            // Label212
            // 
            this.Label212.Border.BottomColor = System.Drawing.Color.Black;
            this.Label212.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label212.Border.LeftColor = System.Drawing.Color.Black;
            this.Label212.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label212.Border.RightColor = System.Drawing.Color.Black;
            this.Label212.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label212.Border.TopColor = System.Drawing.Color.Black;
            this.Label212.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label212.Height = 0.2F;
            this.Label212.HyperLink = "";
            this.Label212.Left = 11.0625F;
            this.Label212.MultiLine = false;
            this.Label212.Name = "Label212";
            this.Label212.Style = "text-align: center; font-weight: bold; background-color: Gainsboro; font-size: 8p" +
                "t; ";
            this.Label212.Text = "Diciembre";
            this.Label212.Top = 0F;
            this.Label212.Width = 0.6875F;
            // 
            // Label200
            // 
            this.Label200.Border.BottomColor = System.Drawing.Color.Black;
            this.Label200.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label200.Border.LeftColor = System.Drawing.Color.Black;
            this.Label200.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label200.Border.RightColor = System.Drawing.Color.Black;
            this.Label200.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label200.Border.TopColor = System.Drawing.Color.Black;
            this.Label200.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label200.Height = 0.2F;
            this.Label200.HyperLink = "";
            this.Label200.Left = 0.8125F;
            this.Label200.Name = "Label200";
            this.Label200.Style = "text-align: left; font-weight: bold; background-color: Gainsboro; font-size: 8pt;" +
                " ";
            this.Label200.Text = "Dealer";
            this.Label200.Top = 0F;
            this.Label200.Width = 1.5475F;
            // 
            // Label232
            // 
            this.Label232.Border.BottomColor = System.Drawing.Color.Black;
            this.Label232.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label232.Border.LeftColor = System.Drawing.Color.Black;
            this.Label232.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label232.Border.RightColor = System.Drawing.Color.Black;
            this.Label232.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label232.Border.TopColor = System.Drawing.Color.Black;
            this.Label232.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label232.Height = 0.2F;
            this.Label232.HyperLink = "";
            this.Label232.Left = 11.8125F;
            this.Label232.MultiLine = false;
            this.Label232.Name = "Label232";
            this.Label232.Style = "text-align: center; font-weight: bold; background-color: Silver; font-size: 8pt; " +
                "vertical-align: top; ";
            this.Label232.Text = "Total";
            this.Label232.Top = 5.960464E-08F;
            this.Label232.Width = 0.6674995F;
            // 
            // Label235
            // 
            this.Label235.Border.BottomColor = System.Drawing.Color.Black;
            this.Label235.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label235.Border.LeftColor = System.Drawing.Color.Black;
            this.Label235.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label235.Border.RightColor = System.Drawing.Color.Black;
            this.Label235.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label235.Border.TopColor = System.Drawing.Color.Black;
            this.Label235.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label235.Height = 0.2F;
            this.Label235.HyperLink = "";
            this.Label235.Left = 2.375F;
            this.Label235.Name = "Label235";
            this.Label235.Style = "text-align: left; font-weight: bold; background-color: Gainsboro; font-size: 8pt;" +
                " ";
            this.Label235.Text = "Code";
            this.Label235.Top = 0F;
            this.Label235.Width = 0.3125F;
            // 
            // Label209
            // 
            this.Label209.Border.BottomColor = System.Drawing.Color.Black;
            this.Label209.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label209.Border.LeftColor = System.Drawing.Color.Black;
            this.Label209.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label209.Border.RightColor = System.Drawing.Color.Black;
            this.Label209.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label209.Border.TopColor = System.Drawing.Color.Black;
            this.Label209.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label209.Height = 0.2F;
            this.Label209.HyperLink = "";
            this.Label209.Left = 8.8125F;
            this.Label209.MultiLine = false;
            this.Label209.Name = "Label209";
            this.Label209.Style = "text-align: center; font-weight: bold; background-color: Gainsboro; font-size: 8p" +
                "t; ";
            this.Label209.Text = "Septiembre";
            this.Label209.Top = 0F;
            this.Label209.Width = 0.6875F;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            // 
            // AnualPolicyProduction
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 13.25F;
            this.Sections.Add(this.ReportHeader);
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.PageFooter);
            this.Sections.Add(this.ReportFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.AnualPolicyProduction_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox97)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label237)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label236)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox67)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox68)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox69)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox72)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox73)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox74)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox76)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label234)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox96)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label201)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label202)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label203)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label204)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label205)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label206)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label207)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label208)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label210)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label211)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label212)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label200)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label232)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label235)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label209)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
