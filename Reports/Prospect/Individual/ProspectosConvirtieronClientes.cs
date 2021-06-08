using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports
{
	public class ProspectosConvirtieronClientes : DataDynamics.ActiveReports.ActiveReport3
	{
		string _FromDate;
		string _ToDate;
		
		public ProspectosConvirtieronClientes(string FromDate,string ToDate)
		{
			_FromDate = FromDate;
			_ToDate = ToDate;
			InitializeComponent();
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void ProspectosConvirtieronClientes_ReportStart(object sender, System.EventArgs eArgs)
		{
			this.lblDate.Text = "Date:"+DateTime.Now.ToShortDateString();
			this.lblTime.Text = "Time:"+DateTime.Now.ToShortTimeString();
			this.lblCriterias.Text = this.lblCriterias.Text + " From: " + _FromDate +" To: " + _ToDate;
		}

		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		#region ActiveReports Designer generated code
		private ReportHeader ReportHeader = null;
		private PageHeader PageHeader = null;
		private Label lblCriterias = null;
		private Label lblDate = null;
		private Label lblTime = null;
		private Shape Shape3 = null;
		private Label Label110 = null;
		private Label Label111 = null;
		private Label Label114 = null;
		private Label Label116 = null;
		private Label Label80 = null;
		private TextBox TextBox17 = null;
		private Label Label125 = null;
		private Label Label126 = null;
		private Label Label127 = null;
		private Label Label128 = null;
		private Label Label75 = null;
		private Label Label77 = null;
		private Detail Detail = null;
		private TextBox TextBox3 = null;
		private TextBox TextBox4 = null;
		private TextBox TextBox5 = null;
		private TextBox TextBox15 = null;
		private TextBox TextBox19 = null;
		private TextBox TextBox20 = null;
		private TextBox TextBox21 = null;
		private TextBox TextBox22 = null;
		private PageFooter PageFooter = null;
		private ReportFooter ReportFooter = null;
		private TextBox TextBox18 = null;
		private Line Line10 = null;
		private Label Label124 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProspectosConvirtieronClientes));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.lblCriterias = new DataDynamics.ActiveReports.Label();
            this.lblDate = new DataDynamics.ActiveReports.Label();
            this.lblTime = new DataDynamics.ActiveReports.Label();
            this.Shape3 = new DataDynamics.ActiveReports.Shape();
            this.Label110 = new DataDynamics.ActiveReports.Label();
            this.Label111 = new DataDynamics.ActiveReports.Label();
            this.Label114 = new DataDynamics.ActiveReports.Label();
            this.Label116 = new DataDynamics.ActiveReports.Label();
            this.Label80 = new DataDynamics.ActiveReports.Label();
            this.TextBox17 = new DataDynamics.ActiveReports.TextBox();
            this.Label125 = new DataDynamics.ActiveReports.Label();
            this.Label126 = new DataDynamics.ActiveReports.Label();
            this.Label127 = new DataDynamics.ActiveReports.Label();
            this.Label128 = new DataDynamics.ActiveReports.Label();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.TextBox3 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox4 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox5 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox15 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox19 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox20 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox21 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox22 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox18 = new DataDynamics.ActiveReports.TextBox();
            this.Line10 = new DataDynamics.ActiveReports.Line();
            this.Label124 = new DataDynamics.ActiveReports.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label110)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label114)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label116)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label125)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label126)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label127)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label128)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label124)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.TextBox3,
                        this.TextBox4,
                        this.TextBox5,
                        this.TextBox15,
                        this.TextBox19,
                        this.TextBox20,
                        this.TextBox21,
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
                        this.TextBox18,
                        this.Line10,
                        this.Label124});
            this.ReportFooter.Height = 0.375F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.lblCriterias,
                        this.lblDate,
                        this.lblTime,
                        this.Shape3,
                        this.Label110,
                        this.Label111,
                        this.Label114,
                        this.Label116,
                        this.Label80,
                        this.TextBox17,
                        this.Label125,
                        this.Label126,
                        this.Label127,
                        this.Label128,
                        this.Label75,
                        this.Label77});
            this.PageHeader.Height = 1.21875F;
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
            this.lblCriterias.Left = 1.6875F;
            this.lblCriterias.MultiLine = false;
            this.lblCriterias.Name = "lblCriterias";
            this.lblCriterias.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.lblCriterias.Text = "Prospects (Individual) Converted To Clients";
            this.lblCriterias.Top = 0.5625F;
            this.lblCriterias.Width = 5.125F;
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
            this.lblDate.Top = 0F;
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
            this.Shape3.Left = 0.25F;
            this.Shape3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Shape3.Name = "Shape3";
            this.Shape3.RoundingRadius = 9.999999F;
            this.Shape3.Top = 0.875F;
            this.Shape3.Width = 7.875F;
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
            this.Label110.Left = 3.5F;
            this.Label110.Name = "Label110";
            this.Label110.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label110.Text = "Conversion Date";
            this.Label110.Top = 0.9375F;
            this.Label110.Width = 1.0625F;
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
            this.Label111.Left = 1.875F;
            this.Label111.Name = "Label111";
            this.Label111.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label111.Text = "Name";
            this.Label111.Top = 0.9375F;
            this.Label111.Width = 1.3125F;
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
            this.Label114.Left = 0.375F;
            this.Label114.Name = "Label114";
            this.Label114.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label114.Text = "Client No";
            this.Label114.Top = 0.875F;
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
            this.Label116.Left = 0.375F;
            this.Label116.Name = "Label116";
            this.Label116.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label116.Text = "Prospect ID";
            this.Label116.Top = 1F;
            this.Label116.Width = 1.375F;
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
            this.Label80.Top = 0F;
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
            this.TextBox17.Left = 7.802083F;
            this.TextBox17.MultiLine = false;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat");
            this.TextBox17.Style = "text-align: right; font-size: 8pt; vertical-align: top; ";
            this.TextBox17.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox17.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.TextBox17.Top = 0F;
            this.TextBox17.Width = 0.322917F;
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
            this.Label125.Height = 0.2F;
            this.Label125.HyperLink = "";
            this.Label125.Left = 4.8125F;
            this.Label125.Name = "Label125";
            this.Label125.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label125.Text = "Home Phone";
            this.Label125.Top = 0.875F;
            this.Label125.Width = 0.875F;
            // 
            // Label126
            // 
            this.Label126.Border.BottomColor = System.Drawing.Color.Black;
            this.Label126.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label126.Border.LeftColor = System.Drawing.Color.Black;
            this.Label126.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label126.Border.RightColor = System.Drawing.Color.Black;
            this.Label126.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label126.Border.TopColor = System.Drawing.Color.Black;
            this.Label126.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label126.Height = 0.2F;
            this.Label126.HyperLink = "";
            this.Label126.Left = 4.8125F;
            this.Label126.Name = "Label126";
            this.Label126.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label126.Text = "Work Phone";
            this.Label126.Top = 1F;
            this.Label126.Width = 0.875F;
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
            this.Label127.Height = 0.2F;
            this.Label127.HyperLink = "";
            this.Label127.Left = 6.1875F;
            this.Label127.Name = "Label127";
            this.Label127.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label127.Text = "Cellular";
            this.Label127.Top = 0.875F;
            this.Label127.Width = 0.5625F;
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
            this.Label128.Height = 0.2F;
            this.Label128.HyperLink = "";
            this.Label128.Left = 6.1875F;
            this.Label128.Name = "Label128";
            this.Label128.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label128.Text = "E-mail";
            this.Label128.Top = 1F;
            this.Label128.Width = 0.5625F;
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
            this.Label75.Left = 1.6875F;
            this.Label75.MultiLine = false;
            this.Label75.Name = "Label75";
            this.Label75.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 12pt; font-fam" +
                "ily: Times New Roman; ";
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
            this.Label77.Left = 1.6875F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-align: center; font-weight: bold; font-size: 6pt; font-family: Times New Rom" +
                "an; ";
            this.Label77.Text = "P.O. Box 195585 San Juan Puerto Rico, PR  00919-5585 Tel (787) 763-4010 Fax (787)" +
                " 763-3525";
            this.Label77.Top = 0.25F;
            this.Label77.Width = 5.125F;
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
            this.TextBox3.DataField = "CustomerNo";
            this.TextBox3.Height = 0.125F;
            this.TextBox3.Left = 0.375F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox3.Top = 0F;
            this.TextBox3.Width = 1.3125F;
            // 
            // TextBox4
            // 
            this.TextBox4.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox4.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox4.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox4.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox4.DataField = "Name";
            this.TextBox4.Height = 0.125F;
            this.TextBox4.Left = 1.875F;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Style = "font-size: 7pt; ";
            this.TextBox4.Top = 0F;
            this.TextBox4.Width = 1.5F;
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
            this.TextBox5.DataField = "ConvertToClient";
            this.TextBox5.Height = 0.125F;
            this.TextBox5.Left = 3.5F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat");
            this.TextBox5.Style = "font-size: 7pt; ";
            this.TextBox5.Top = 0F;
            this.TextBox5.Width = 1.125F;
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
            this.TextBox15.DataField = "ProspectID";
            this.TextBox15.Height = 0.125F;
            this.TextBox15.Left = 0.375F;
            this.TextBox15.Name = "TextBox15";
            this.TextBox15.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox15.Top = 0.125F;
            this.TextBox15.Width = 1.3125F;
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
            this.TextBox19.DataField = "Homeph";
            this.TextBox19.Height = 0.125F;
            this.TextBox19.Left = 4.8125F;
            this.TextBox19.Name = "TextBox19";
            this.TextBox19.OutputFormat = resources.GetString("TextBox19.OutputFormat");
            this.TextBox19.Style = "font-size: 7pt; ";
            this.TextBox19.Top = 0F;
            this.TextBox19.Width = 1.125F;
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
            this.TextBox20.DataField = "Jobph";
            this.TextBox20.Height = 0.125F;
            this.TextBox20.Left = 4.8125F;
            this.TextBox20.Name = "TextBox20";
            this.TextBox20.OutputFormat = resources.GetString("TextBox20.OutputFormat");
            this.TextBox20.Style = "font-size: 7pt; ";
            this.TextBox20.Top = 0.125F;
            this.TextBox20.Width = 1.125F;
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
            this.TextBox21.DataField = "Cellular";
            this.TextBox21.Height = 0.125F;
            this.TextBox21.Left = 6.1875F;
            this.TextBox21.Name = "TextBox21";
            this.TextBox21.OutputFormat = resources.GetString("TextBox21.OutputFormat");
            this.TextBox21.Style = "font-size: 7pt; ";
            this.TextBox21.Top = 0F;
            this.TextBox21.Width = 1.125F;
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
            this.TextBox22.DataField = "Email";
            this.TextBox22.Height = 0.125F;
            this.TextBox22.Left = 6.1875F;
            this.TextBox22.Name = "TextBox22";
            this.TextBox22.OutputFormat = resources.GetString("TextBox22.OutputFormat");
            this.TextBox22.Style = "font-size: 7pt; ";
            this.TextBox22.Top = 0.125F;
            this.TextBox22.Width = 1.5625F;
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
            this.TextBox18.DataField = "CustomerNo";
            this.TextBox18.Height = 0.2F;
            this.TextBox18.Left = 1F;
            this.TextBox18.Name = "TextBox18";
            this.TextBox18.Style = "font-weight: bold; font-size: 7pt; ";
            this.TextBox18.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox18.SummaryGroup = "GroupHeader1";
            this.TextBox18.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TextBox18.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox18.Top = 0.125F;
            this.TextBox18.Width = 1F;
            // 
            // Line10
            // 
            this.Line10.Border.BottomColor = System.Drawing.Color.Black;
            this.Line10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10.Border.LeftColor = System.Drawing.Color.Black;
            this.Line10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10.Border.RightColor = System.Drawing.Color.Black;
            this.Line10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10.Border.TopColor = System.Drawing.Color.Black;
            this.Line10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10.Height = 0F;
            this.Line10.Left = 0.25F;
            this.Line10.LineWeight = 1F;
            this.Line10.Name = "Line10";
            this.Line10.Top = 0.0625F;
            this.Line10.Width = 7.875F;
            this.Line10.X1 = 0.25F;
            this.Line10.X2 = 8.125F;
            this.Line10.Y1 = 0.0625F;
            this.Line10.Y2 = 0.0625F;
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
            this.Label124.Height = 0.2F;
            this.Label124.HyperLink = "";
            this.Label124.Left = 0.375F;
            this.Label124.Name = "Label124";
            this.Label124.Style = "font-weight: bold; font-size: 7pt; ";
            this.Label124.Text = "Grand Total:";
            this.Label124.Top = 0.125F;
            this.Label124.Width = 0.625F;
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
            ((System.ComponentModel.ISupportInitialize)(this.Label110)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label114)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label116)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label125)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label126)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label127)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label128)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label124)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
       
			// Attach Report Events
			this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
			this.ReportStart += new System.EventHandler(this.ProspectosConvirtieronClientes_ReportStart);
			this.Detail.Format += new System.EventHandler(this.Detail_Format);
		 }

		#endregion
	}
}
