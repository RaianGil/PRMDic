using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports
{
	public class ProspectosSinCotizacionesNegocios : DataDynamics.ActiveReports.ActiveReport3
	{
		string _FromDate;
		string _ToDate;

		public ProspectosSinCotizacionesNegocios(string FromDate,string ToDate)
		{
			_FromDate = FromDate;
			_ToDate = ToDate;
			InitializeComponent();
		}

		private void GroupHeader1_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void ProspectosSinCotizacionesNegocios_ReportStart(object sender, System.EventArgs eArgs)
		{
			this.lblDate.Text = "Date:"+DateTime.Now.ToShortDateString();
			this.lblTime.Text = "Time:"+DateTime.Now.ToShortTimeString();
			if (!_FromDate.Trim().Equals("")||(!_FromDate.Trim().Equals("")))
			{
				this.lblCriterias.Text = this.lblCriterias.Text + " From: " + _FromDate +" To: " + _ToDate;
			}
		}

		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		#region ActiveReports Designer generated code
		private ReportHeader ReportHeader = null;
		private PageHeader PageHeader = null;
		private Label lblCriterias = null;
		private Shape Shape3 = null;
		private Label lblDate = null;
		private Label lblTime = null;
		private Label Label108 = null;
		private Label Label109 = null;
		private Label Label110 = null;
		private Label Label111 = null;
		private Label Label112 = null;
		private Label Label113 = null;
		private Label Label80 = null;
		private TextBox TextBox14 = null;
		private Label Label75 = null;
		private Label Label77 = null;
		private Detail Detail = null;
		private TextBox TextBox2 = null;
		private TextBox TextBox3 = null;
		private TextBox TextBox5 = null;
		private TextBox TextBox8 = null;
		private TextBox TextBox9 = null;
		private TextBox TextBox10 = null;
		private TextBox TextBox15 = null;
		private PageFooter PageFooter = null;
		private ReportFooter ReportFooter = null;
		private TextBox TextBox12 = null;
		private Line Line9 = null;
		private Label Label116 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProspectosSinCotizacionesNegocios));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.lblCriterias = new DataDynamics.ActiveReports.Label();
            this.Shape3 = new DataDynamics.ActiveReports.Shape();
            this.lblDate = new DataDynamics.ActiveReports.Label();
            this.lblTime = new DataDynamics.ActiveReports.Label();
            this.Label108 = new DataDynamics.ActiveReports.Label();
            this.Label109 = new DataDynamics.ActiveReports.Label();
            this.Label110 = new DataDynamics.ActiveReports.Label();
            this.Label111 = new DataDynamics.ActiveReports.Label();
            this.Label112 = new DataDynamics.ActiveReports.Label();
            this.Label113 = new DataDynamics.ActiveReports.Label();
            this.Label80 = new DataDynamics.ActiveReports.Label();
            this.TextBox14 = new DataDynamics.ActiveReports.TextBox();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.TextBox2 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox3 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox5 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox8 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox9 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox10 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox15 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox12 = new DataDynamics.ActiveReports.TextBox();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.Label116 = new DataDynamics.ActiveReports.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label110)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label112)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label113)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label116)).BeginInit();
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
                        this.TextBox15});
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
                        this.TextBox12,
                        this.Line9,
                        this.Label116});
            this.ReportFooter.Height = 0.3333333F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.lblCriterias,
                        this.Shape3,
                        this.lblDate,
                        this.lblTime,
                        this.Label108,
                        this.Label109,
                        this.Label110,
                        this.Label111,
                        this.Label112,
                        this.Label113,
                        this.Label80,
                        this.TextBox14,
                        this.Label75,
                        this.Label77});
            this.PageHeader.Height = 1.239583F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
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
            this.lblCriterias.Left = 1.697917F;
            this.lblCriterias.MultiLine = false;
            this.lblCriterias.Name = "lblCriterias";
            this.lblCriterias.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.lblCriterias.Text = "Prospects (Business) Without Quotes";
            this.lblCriterias.Top = 0.5625F;
            this.lblCriterias.Width = 5.125F;
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
            this.Shape3.Left = 0.3125F;
            this.Shape3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Shape3.Name = "Shape3";
            this.Shape3.RoundingRadius = 9.999999F;
            this.Shape3.Top = 0.875F;
            this.Shape3.Width = 7.8125F;
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
            this.lblDate.Left = 0.3125F;
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
            this.lblTime.Left = 0.3125F;
            this.lblTime.Name = "lblTime";
            this.lblTime.Style = "text-align: left; font-size: 8pt; ";
            this.lblTime.Text = "lblTime";
            this.lblTime.Top = 0.25F;
            this.lblTime.Width = 0.9090909F;
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
            this.Label108.Left = 5.6875F;
            this.Label108.Name = "Label108";
            this.Label108.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label108.Text = "Email";
            this.Label108.Top = 0.875F;
            this.Label108.Width = 1.0625F;
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
            this.Label109.Left = 4.0625F;
            this.Label109.Name = "Label109";
            this.Label109.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label109.Text = "Business Phone";
            this.Label109.Top = 0.9375F;
            this.Label109.Width = 1F;
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
            this.Label110.Left = 5.6875F;
            this.Label110.Name = "Label110";
            this.Label110.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label110.Text = "Referred By";
            this.Label110.Top = 1F;
            this.Label110.Width = 1.1875F;
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
            this.Label111.Left = 0.375F;
            this.Label111.Name = "Label111";
            this.Label111.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label111.Text = "Prospect ID";
            this.Label111.Top = 0.9375F;
            this.Label111.Width = 0.6875F;
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
            this.Label112.Left = 1.25F;
            this.Label112.Name = "Label112";
            this.Label112.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label112.Text = "Business Company";
            this.Label112.Top = 0.875F;
            this.Label112.Width = 1.375F;
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
            this.Label113.Left = 1.25F;
            this.Label113.Name = "Label113";
            this.Label113.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label113.Text = "Contact Name";
            this.Label113.Top = 1F;
            this.Label113.Width = 1.375F;
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
            this.Label80.Left = 7.3125F;
            this.Label80.Name = "Label80";
            this.Label80.Style = "text-align: right; font-size: 8pt; ";
            this.Label80.Text = "Page";
            this.Label80.Top = 0.0625F;
            this.Label80.Width = 0.5F;
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
            this.TextBox14.Height = 0.1875F;
            this.TextBox14.Left = 7.802083F;
            this.TextBox14.MultiLine = false;
            this.TextBox14.Name = "TextBox14";
            this.TextBox14.OutputFormat = resources.GetString("TextBox14.OutputFormat");
            this.TextBox14.Style = "text-align: right; font-size: 8pt; vertical-align: top; ";
            this.TextBox14.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox14.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox14.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.TextBox14.Top = 0.0625F;
            this.TextBox14.Width = 0.322917F;
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
            this.Label75.Left = 1.697917F;
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
            this.Label77.Left = 1.697917F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-align: center; font-weight: bold; font-size: 6pt; font-family: Times New Rom" +
                "an; ";
            this.Label77.Text = "P.O. Box 195585 San Juan Puerto Rico, PR  00919-5585 Tel (787) 763-4010 Fax (787)" +
                " 763-3525";
            this.Label77.Top = 0.25F;
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
            this.TextBox2.Left = 1.25F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Style = "font-size: 7pt; ";
            this.TextBox2.Top = 0F;
            this.TextBox2.Width = 2.75F;
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
            this.TextBox3.Left = 4.0625F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat");
            this.TextBox3.Style = "font-size: 7pt; ";
            this.TextBox3.Top = 0F;
            this.TextBox3.Width = 1.5625F;
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
            this.TextBox5.Left = 5.6875F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Style = "font-size: 7pt; ";
            this.TextBox5.Top = 0F;
            this.TextBox5.Width = 1.5625F;
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
            this.TextBox8.DataField = "prospectID";
            this.TextBox8.Height = 0.125F;
            this.TextBox8.Left = 0.375F;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.Style = "text-align: left; font-size: 7pt; ";
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
            this.TextBox9.Left = 5.6875F;
            this.TextBox9.Name = "TextBox9";
            this.TextBox9.Style = "font-size: 7pt; ";
            this.TextBox9.Top = 0.125F;
            this.TextBox9.Width = 1.5625F;
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
            this.TextBox10.Left = 1.25F;
            this.TextBox10.Name = "TextBox10";
            this.TextBox10.Style = "font-size: 7pt; ";
            this.TextBox10.Top = 0.125F;
            this.TextBox10.Width = 2.75F;
            // 
            // TextBox15
            // 
            this.TextBox15.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox15.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox15.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox15.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox15.DataField = "Cellular";
            this.TextBox15.Height = 0.125F;
            this.TextBox15.Left = 4.0625F;
            this.TextBox15.Name = "TextBox15";
            this.TextBox15.OutputFormat = resources.GetString("TextBox15.OutputFormat");
            this.TextBox15.Style = "font-size: 7pt; ";
            this.TextBox15.Top = 0.125F;
            this.TextBox15.Width = 1.5625F;
            // 
            // TextBox12
            // 
            this.TextBox12.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox12.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox12.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox12.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox12.DataField = "prospectID";
            this.TextBox12.Height = 0.2F;
            this.TextBox12.Left = 1.125F;
            this.TextBox12.Name = "TextBox12";
            this.TextBox12.Style = "font-weight: bold; font-size: 7pt; ";
            this.TextBox12.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox12.SummaryGroup = "GroupHeader1";
            this.TextBox12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TextBox12.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox12.Top = 0.125F;
            this.TextBox12.Width = 1F;
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
            this.Line9.Left = 0.3125F;
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 0.0625F;
            this.Line9.Width = 7.8125F;
            this.Line9.X1 = 0.3125F;
            this.Line9.X2 = 8.125F;
            this.Line9.Y1 = 0.0625F;
            this.Line9.Y2 = 0.0625F;
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
            this.Label116.Left = 0.375F;
            this.Label116.Name = "Label116";
            this.Label116.Style = "font-weight: bold; font-size: 7pt; ";
            this.Label116.Text = "Grand Total:";
            this.Label116.Top = 0.125F;
            this.Label116.Width = 0.75F;
            // 
            // ActiveReport31
            // 
            this.PageSettings.Margins.Bottom = 0.5F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.489583F;
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
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label110)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label112)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label113)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label116)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
       
			// Attach Report Events
			this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
			this.ReportStart += new System.EventHandler(this.ProspectosSinCotizacionesNegocios_ReportStart);
			this.Detail.Format += new System.EventHandler(this.Detail_Format);
		 }

		#endregion
	}
}
