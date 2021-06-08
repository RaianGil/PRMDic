using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports
{
	public class ProspectosConCotizacionesNegocios : DataDynamics.ActiveReports.ActiveReport3
	{
		string _FromDate;
		string _ToDate;

		public ProspectosConCotizacionesNegocios(string FromDate,string ToDate)
		{
			_FromDate = FromDate;
			_ToDate = ToDate;
			InitializeComponent();
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void ProspectosConCotizacionesNegocios_ReportStart(object sender, System.EventArgs eArgs)
		{
			this.lblDate.Text = "Date:"+DateTime.Now.ToShortDateString();
			this.lblTime.Text = "Time:"+DateTime.Now.ToShortTimeString();
			if (!_FromDate.Trim().Equals("")||(!_FromDate.Trim().Equals("")))
			{
				this.Label1.Text = this.Label1.Text + " From: " + _FromDate +" To: " + _ToDate;
			}
		}

		private void GroupHeader1_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		#region ActiveReports Designer generated code
		private ReportHeader ReportHeader = null;
		private PageHeader PageHeader = null;
		private Shape Shape3 = null;
		private Label Label1 = null;
		private Label lblDate = null;
		private Label lblTime = null;
		private Label Label110 = null;
		private Label Label111 = null;
		private Label Label112 = null;
		private Label Label113 = null;
		private Label Label114 = null;
		private Label Label116 = null;
		private Label Label117 = null;
		private Label Label118 = null;
		private Label Label81 = null;
		private TextBox TextBox16 = null;
		private Label Label119 = null;
		private Label Label75 = null;
		private Label Label77 = null;
		private Detail Detail = null;
		private TextBox TextBox2 = null;
		private TextBox TextBox3 = null;
		private TextBox TextBox5 = null;
		private TextBox TextBox8 = null;
		private TextBox TextBox9 = null;
		private TextBox TextBox10 = null;
		private TextBox TextBox11 = null;
		private TextBox TextBox14 = null;
		private TextBox TextBox22 = null;
		private PageFooter PageFooter = null;
		private ReportFooter ReportFooter = null;
		private TextBox TextBox13 = null;
		private Label Label109 = null;
		private Line Line9 = null;
		private TextBox TextBox24 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProspectosConCotizacionesNegocios));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Shape3 = new DataDynamics.ActiveReports.Shape();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.lblDate = new DataDynamics.ActiveReports.Label();
            this.lblTime = new DataDynamics.ActiveReports.Label();
            this.Label110 = new DataDynamics.ActiveReports.Label();
            this.Label111 = new DataDynamics.ActiveReports.Label();
            this.Label112 = new DataDynamics.ActiveReports.Label();
            this.Label113 = new DataDynamics.ActiveReports.Label();
            this.Label114 = new DataDynamics.ActiveReports.Label();
            this.Label116 = new DataDynamics.ActiveReports.Label();
            this.Label117 = new DataDynamics.ActiveReports.Label();
            this.Label118 = new DataDynamics.ActiveReports.Label();
            this.Label81 = new DataDynamics.ActiveReports.Label();
            this.TextBox16 = new DataDynamics.ActiveReports.TextBox();
            this.Label119 = new DataDynamics.ActiveReports.Label();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.TextBox2 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox3 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox5 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox8 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox9 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox10 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox11 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox14 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox22 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox13 = new DataDynamics.ActiveReports.TextBox();
            this.Label109 = new DataDynamics.ActiveReports.Label();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.TextBox24 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label110)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label112)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label113)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label114)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label116)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label117)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label118)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label81)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label119)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.TextBox2,
                        this.TextBox3,
                        this.TextBox5,
                        this.TextBox8,
                        this.TextBox9,
                        this.TextBox10,
                        this.TextBox11,
                        this.TextBox14,
                        this.TextBox22});
            this.Detail.Height = 0.2597222F;
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
                        this.TextBox13,
                        this.Label109,
                        this.Line9,
                        this.TextBox24});
            this.ReportFooter.Height = 0.3534722F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Shape3,
                        this.Label1,
                        this.lblDate,
                        this.lblTime,
                        this.Label110,
                        this.Label111,
                        this.Label112,
                        this.Label113,
                        this.Label114,
                        this.Label116,
                        this.Label117,
                        this.Label118,
                        this.Label81,
                        this.TextBox16,
                        this.Label119,
                        this.Label75,
                        this.Label77});
            this.PageHeader.Height = 1.415972F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            // 
            // Shape3
            // 
            this.Shape3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.Shape3.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.RightColor = System.Drawing.Color.Black;
            this.Shape3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.TopColor = System.Drawing.Color.Black;
            this.Shape3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Height = 0.3125F;
            this.Shape3.Left = 0.1875F;
            this.Shape3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Shape3.Name = "Shape3";
            this.Shape3.RoundingRadius = 9.999999F;
            this.Shape3.Top = 1.0625F;
            this.Shape3.Width = 8.1875F;
            // 
            // Label1
            // 
            this.Label1.Border.BottomColor = System.Drawing.Color.Black;
            this.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.LeftColor = System.Drawing.Color.Black;
            this.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.RightColor = System.Drawing.Color.Black;
            this.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.TopColor = System.Drawing.Color.Black;
            this.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Height = 0.1875F;
            this.Label1.HyperLink = "";
            this.Label1.Left = 1.875F;
            this.Label1.MultiLine = false;
            this.Label1.Name = "Label1";
            this.Label1.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label1.Text = "Prospect (Business) with Quotes";
            this.Label1.Top = 0.6666667F;
            this.Label1.Width = 5.125F;
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
            this.lblDate.Left = 0.1875F;
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
            this.lblTime.Left = 0.1875F;
            this.lblTime.Name = "lblTime";
            this.lblTime.Style = "text-align: left; font-size: 8pt; ";
            this.lblTime.Text = "lblTime";
            this.lblTime.Top = 0.375F;
            this.lblTime.Width = 0.9090909F;
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
            this.Label110.Left = 4.4375F;
            this.Label110.Name = "Label110";
            this.Label110.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label110.Text = "Email";
            this.Label110.Top = 1.1875F;
            this.Label110.Width = 0.875F;
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
            this.Label111.Height = 0.2F;
            this.Label111.HyperLink = "";
            this.Label111.Left = 3.135417F;
            this.Label111.Name = "Label111";
            this.Label111.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label111.Text = "Business Phone";
            this.Label111.Top = 1.0625F;
            this.Label111.Width = 1F;
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
            this.Label112.Left = 4.4375F;
            this.Label112.Name = "Label112";
            this.Label112.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label112.Text = "Referred By";
            this.Label112.Top = 1.0625F;
            this.Label112.Width = 0.9375F;
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
            this.Label113.Left = 0.2604167F;
            this.Label113.Name = "Label113";
            this.Label113.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label113.Text = "Prospect ID";
            this.Label113.Top = 1.125F;
            this.Label113.Width = 0.6875F;
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
            this.Label114.Left = 1F;
            this.Label114.Name = "Label114";
            this.Label114.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label114.Text = "Business Company";
            this.Label114.Top = 1.0625F;
            this.Label114.Width = 1.375F;
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
            this.Label116.Height = 0.2F;
            this.Label116.HyperLink = "";
            this.Label116.Left = 1F;
            this.Label116.Name = "Label116";
            this.Label116.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label116.Text = "Contact Name";
            this.Label116.Top = 1.1875F;
            this.Label116.Width = 1.375F;
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
            this.Label117.Height = 0.2F;
            this.Label117.HyperLink = "";
            this.Label117.Left = 6.4375F;
            this.Label117.Name = "Label117";
            this.Label117.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label117.Text = "QuoteID";
            this.Label117.Top = 1.125F;
            this.Label117.Width = 0.5F;
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
            this.Label118.Left = 7.375F;
            this.Label118.MultiLine = false;
            this.Label118.Name = "Label118";
            this.Label118.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label118.Text = "Total Premium";
            this.Label118.Top = 1.125F;
            this.Label118.Width = 0.875F;
            // 
            // Label81
            // 
            this.Label81.Border.BottomColor = System.Drawing.Color.Black;
            this.Label81.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label81.Border.LeftColor = System.Drawing.Color.Black;
            this.Label81.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label81.Border.RightColor = System.Drawing.Color.Black;
            this.Label81.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label81.Border.TopColor = System.Drawing.Color.Black;
            this.Label81.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label81.Height = 0.2F;
            this.Label81.HyperLink = "";
            this.Label81.Left = 7.5F;
            this.Label81.Name = "Label81";
            this.Label81.Style = "text-align: right; font-size: 8pt; ";
            this.Label81.Text = "Page";
            this.Label81.Top = 0.1875F;
            this.Label81.Width = 0.5F;
            // 
            // TextBox16
            // 
            this.TextBox16.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox16.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox16.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox16.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox16.Height = 0.1875F;
            this.TextBox16.Left = 7.9375F;
            this.TextBox16.MultiLine = false;
            this.TextBox16.Name = "TextBox16";
            this.TextBox16.OutputFormat = resources.GetString("TextBox16.OutputFormat");
            this.TextBox16.Style = "text-align: right; font-size: 8pt; vertical-align: top; ";
            this.TextBox16.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox16.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox16.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.TextBox16.Top = 0.1875F;
            this.TextBox16.Width = 0.4375F;
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
            this.Label119.Left = 3.135417F;
            this.Label119.Name = "Label119";
            this.Label119.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label119.Text = "Cellular";
            this.Label119.Top = 1.1875F;
            this.Label119.Width = 1F;
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
            this.Label75.Left = 1.875F;
            this.Label75.MultiLine = false;
            this.Label75.Name = "Label75";
            this.Label75.Style = "text-align: center; font-weight: bold; font-size: 11.25pt; font-family: Times New" +
                " Roman; ";
            this.Label75.Text = "LAS VISTAS INSURANCE AGENCY, CORP.";
            this.Label75.Top = 0.1875F;
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
            this.Label77.Left = 1.875F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-align: center; font-weight: bold; font-size: 6pt; font-family: Times New Rom" +
                "an; ";
            this.Label77.Text = "P.O. Box 195585 San Juan Puerto Rico, PR  00919-5585 Tel (787) 763-4010 Fax (787)" +
                " 763-3525";
            this.Label77.Top = 0.375F;
            this.Label77.Width = 5.125F;
            // 
            // TextBox2
            // 
            this.TextBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox2.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox2.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox2.DataField = "BusinessName";
            this.TextBox2.Height = 0.125F;
            this.TextBox2.Left = 1F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Style = "font-size: 7pt; ";
            this.TextBox2.Top = 0F;
            this.TextBox2.Width = 2.0625F;
            // 
            // TextBox3
            // 
            this.TextBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox3.DataField = "WorkPhone";
            this.TextBox3.Height = 0.125F;
            this.TextBox3.Left = 3.135417F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat");
            this.TextBox3.Style = "font-size: 7pt; ";
            this.TextBox3.Top = 0F;
            this.TextBox3.Width = 1.114583F;
            // 
            // TextBox5
            // 
            this.TextBox5.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox5.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox5.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox5.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox5.DataField = "Email";
            this.TextBox5.Height = 0.125F;
            this.TextBox5.Left = 4.4375F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Style = "font-size: 7pt; ";
            this.TextBox5.Top = 0.125F;
            this.TextBox5.Width = 1.75F;
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
            this.TextBox8.DataField = "ProspectID";
            this.TextBox8.Height = 0.125F;
            this.TextBox8.Left = 0.2604167F;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox8.Top = 0F;
            this.TextBox8.Width = 0.75F;
            // 
            // TextBox9
            // 
            this.TextBox9.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox9.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox9.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox9.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox9.DataField = "ReferredByDesc";
            this.TextBox9.Height = 0.125F;
            this.TextBox9.Left = 4.4375F;
            this.TextBox9.Name = "TextBox9";
            this.TextBox9.Style = "font-size: 7pt; ";
            this.TextBox9.Top = 0F;
            this.TextBox9.Width = 1.5F;
            // 
            // TextBox10
            // 
            this.TextBox10.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox10.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox10.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox10.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox10.DataField = "Name";
            this.TextBox10.Height = 0.125F;
            this.TextBox10.Left = 1F;
            this.TextBox10.Name = "TextBox10";
            this.TextBox10.Style = "font-size: 7pt; ";
            this.TextBox10.Top = 0.125F;
            this.TextBox10.Width = 2.0625F;
            // 
            // TextBox11
            // 
            this.TextBox11.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox11.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox11.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox11.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox11.DataField = "QuoteID";
            this.TextBox11.Height = 0.125F;
            this.TextBox11.Left = 6.4375F;
            this.TextBox11.Name = "TextBox11";
            this.TextBox11.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox11.Top = 0F;
            this.TextBox11.Width = 0.6041666F;
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
            this.TextBox14.DataField = "TotalPremium";
            this.TextBox14.Height = 0.125F;
            this.TextBox14.Left = 7.375F;
            this.TextBox14.Name = "TextBox14";
            this.TextBox14.OutputFormat = resources.GetString("TextBox14.OutputFormat");
            this.TextBox14.Style = "font-size: 7pt; ";
            this.TextBox14.Top = 0F;
            this.TextBox14.Width = 0.875F;
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
            this.TextBox22.DataField = "Cellular";
            this.TextBox22.Height = 0.125F;
            this.TextBox22.Left = 3.135417F;
            this.TextBox22.Name = "TextBox22";
            this.TextBox22.OutputFormat = resources.GetString("TextBox22.OutputFormat");
            this.TextBox22.Style = "font-size: 7pt; ";
            this.TextBox22.Top = 0.125F;
            this.TextBox22.Width = 1.114583F;
            // 
            // TextBox13
            // 
            this.TextBox13.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox13.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox13.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox13.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox13.DataField = "ProspectID";
            this.TextBox13.Height = 0.2F;
            this.TextBox13.Left = 0.9375F;
            this.TextBox13.Name = "TextBox13";
            this.TextBox13.Style = "color: Black; font-weight: bold; font-size: 7pt; ";
            this.TextBox13.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox13.SummaryGroup = "GroupHeader1";
            this.TextBox13.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TextBox13.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox13.Top = 0.125F;
            this.TextBox13.Width = 0.5625F;
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
            this.Label109.Left = 0.25F;
            this.Label109.Name = "Label109";
            this.Label109.Style = "color: Black; font-weight: bold; font-size: 7pt; ";
            this.Label109.Text = "Grand Total:";
            this.Label109.Top = 0.125F;
            this.Label109.Width = 0.625F;
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
            this.Line9.Left = 0.1875F;
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 0.0625F;
            this.Line9.Width = 8.1875F;
            this.Line9.X1 = 0.1875F;
            this.Line9.X2 = 8.375F;
            this.Line9.Y1 = 0.0625F;
            this.Line9.Y2 = 0.0625F;
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
            this.TextBox24.Height = 0.2F;
            this.TextBox24.Left = 7.375F;
            this.TextBox24.Name = "TextBox24";
            this.TextBox24.OutputFormat = resources.GetString("TextBox24.OutputFormat");
            this.TextBox24.Style = "text-align: center; font-weight: bold; font-size: 7pt; ";
            this.TextBox24.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox24.Text = "TextBox24";
            this.TextBox24.Top = 0.125F;
            this.TextBox24.Width = 0.875F;
            // 
            // ActiveReport31
            // 
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.5F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.458333F;
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
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label110)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label112)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label113)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label114)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label116)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label117)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label118)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label81)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label119)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
       
			// Attach Report Events
			this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
			this.ReportStart += new System.EventHandler(this.ProspectosConCotizacionesNegocios_ReportStart);
		 }

		#endregion
	}
}
