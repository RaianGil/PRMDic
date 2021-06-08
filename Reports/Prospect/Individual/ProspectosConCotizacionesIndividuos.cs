using System;
using System.Web;
using System.Web.UI;
using System.Web.Configuration;
using System.Web.SessionState;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.Customer;

namespace EPolicy2.Reports
{
	public class ProspectosConCotizacionesIndividuos : DataDynamics.ActiveReports.ActiveReport3
	{
		string _FromDate;
		string _ToDate;

		public ProspectosConCotizacionesIndividuos(string FromDate,string ToDate)
		{
			_FromDate = FromDate;
			_ToDate = ToDate;
			InitializeComponent();
		}

		private void ProspectosConCotizacionesIndividuos_ReportStart(object sender, System.EventArgs eArgs)
		{
			this.lblDate.Text = "Date:"+DateTime.Now.ToShortDateString();
			this.lblTime.Text = "Time:"+DateTime.Now.ToShortTimeString();
			if (!_FromDate.Trim().Equals("")||(!_FromDate.Trim().Equals("")))
			{
				this.lblCriterias.Text = this.lblCriterias.Text + " From: " + _FromDate +" To: " + _ToDate;
			}
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void ProspectosConCotizacionesIndividuos_DataInitialize(object sender, System.EventArgs eArgs)
		{
			this.Fields.Add("phone1");
			this.Fields.Add("phone2");
			this.Fields.Add("Gender");
		}

		private void ProspectosConCotizacionesIndividuos_FetchData(object sender, DataDynamics.ActiveReports.ActiveReport3.FetchEventArgs eArgs)
		{
			
		}

		private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
		{
			this.TextBox11.HyperLink = this.TextBox11.Text;		
		}

		private void Detail_AfterPrint(object sender, System.EventArgs eArgs)
		{
			
		}

		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
//			System.Web.UI.Page page =  new System.Web.UI.Page();
//		
//			Customer.Prospect prospect = new Customer.Prospect();
//			prospect.GetProspect(int.Parse(TextBox11.Text));
//			
//			page.Session.Add("Prospect",prospect);
//			page.Response.Redirect("ProspectIndividual.aspx",false);
		}

		#region ActiveReports Designer generated code
		private ReportHeader ReportHeader = null;
		private PageHeader PageHeader = null;
		private Label lblCriterias = null;
		private Shape Shape3 = null;
		private Label lblDate = null;
		private Label lblTime = null;
		private Label Label102 = null;
		private Label Label103 = null;
		private Label Label104 = null;
		private Label Label105 = null;
		private Label Label106 = null;
		private Label Label107 = null;
		private Label Label108 = null;
		private Label Label109 = null;
		private Label Label110 = null;
		private Label Label80 = null;
		private TextBox TextBox17 = null;
		private Label Label75 = null;
		private Label Label77 = null;
		private Detail Detail = null;
		private TextBox TextBox2 = null;
		private TextBox TextBox3 = null;
		private TextBox TextBox5 = null;
		private TextBox TextBox7 = null;
		private TextBox TextBox8 = null;
		private TextBox TextBox9 = null;
		private TextBox TextBox10 = null;
		private TextBox TextBox11 = null;
		private TextBox TextBox12 = null;
		private PageFooter PageFooter = null;
		private ReportFooter ReportFooter = null;
		private Line Line9 = null;
		private TextBox TextBox14 = null;
		private Label Label116 = null;
		private TextBox TextBox23 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProspectosConCotizacionesIndividuos));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.lblCriterias = new DataDynamics.ActiveReports.Label();
            this.Shape3 = new DataDynamics.ActiveReports.Shape();
            this.lblDate = new DataDynamics.ActiveReports.Label();
            this.lblTime = new DataDynamics.ActiveReports.Label();
            this.Label102 = new DataDynamics.ActiveReports.Label();
            this.Label103 = new DataDynamics.ActiveReports.Label();
            this.Label104 = new DataDynamics.ActiveReports.Label();
            this.Label105 = new DataDynamics.ActiveReports.Label();
            this.Label106 = new DataDynamics.ActiveReports.Label();
            this.Label107 = new DataDynamics.ActiveReports.Label();
            this.Label108 = new DataDynamics.ActiveReports.Label();
            this.Label109 = new DataDynamics.ActiveReports.Label();
            this.Label110 = new DataDynamics.ActiveReports.Label();
            this.Label80 = new DataDynamics.ActiveReports.Label();
            this.TextBox17 = new DataDynamics.ActiveReports.TextBox();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.TextBox2 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox3 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox5 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox7 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox8 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox9 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox10 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox11 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox12 = new DataDynamics.ActiveReports.TextBox();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.TextBox14 = new DataDynamics.ActiveReports.TextBox();
            this.Label116 = new DataDynamics.ActiveReports.Label();
            this.TextBox23 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label103)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label110)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label116)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.TextBox2,
                        this.TextBox3,
                        this.TextBox5,
                        this.TextBox7,
                        this.TextBox8,
                        this.TextBox9,
                        this.TextBox10,
                        this.TextBox11,
                        this.TextBox12});
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
                        this.Line9,
                        this.TextBox14,
                        this.Label116,
                        this.TextBox23});
            this.ReportFooter.Height = 0.3534722F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.lblCriterias,
                        this.Shape3,
                        this.lblDate,
                        this.lblTime,
                        this.Label102,
                        this.Label103,
                        this.Label104,
                        this.Label105,
                        this.Label106,
                        this.Label107,
                        this.Label108,
                        this.Label109,
                        this.Label110,
                        this.Label80,
                        this.TextBox17,
                        this.Label75,
                        this.Label77});
            this.PageHeader.Height = 1.25F;
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
            this.lblCriterias.Left = 1.75F;
            this.lblCriterias.MultiLine = false;
            this.lblCriterias.Name = "lblCriterias";
            this.lblCriterias.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.lblCriterias.Text = "Prospects (Individual) With Quotes";
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
            this.Shape3.Left = 0.25F;
            this.Shape3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Shape3.Name = "Shape3";
            this.Shape3.RoundingRadius = 9.999999F;
            this.Shape3.Top = 0.875F;
            this.Shape3.Width = 8.0625F;
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
            this.lblDate.Top = 0.125F;
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
            // Label102
            // 
            this.Label102.Border.BottomColor = System.Drawing.Color.Black;
            this.Label102.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label102.Border.LeftColor = System.Drawing.Color.Black;
            this.Label102.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label102.Border.RightColor = System.Drawing.Color.Black;
            this.Label102.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label102.Border.TopColor = System.Drawing.Color.Black;
            this.Label102.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label102.Height = 0.2F;
            this.Label102.HyperLink = "";
            this.Label102.Left = 3.46875F;
            this.Label102.Name = "Label102";
            this.Label102.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label102.Text = "Cellular";
            this.Label102.Top = 0.875F;
            this.Label102.Width = 1.0625F;
            // 
            // Label103
            // 
            this.Label103.Border.BottomColor = System.Drawing.Color.Black;
            this.Label103.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label103.Border.LeftColor = System.Drawing.Color.Black;
            this.Label103.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label103.Border.RightColor = System.Drawing.Color.Black;
            this.Label103.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label103.Border.TopColor = System.Drawing.Color.Black;
            this.Label103.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label103.Height = 0.2F;
            this.Label103.HyperLink = "";
            this.Label103.Left = 2.5F;
            this.Label103.Name = "Label103";
            this.Label103.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label103.Text = "Home Phone";
            this.Label103.Top = 0.875F;
            this.Label103.Width = 0.875F;
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
            this.Label104.Left = 5.0625F;
            this.Label104.Name = "Label104";
            this.Label104.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label104.Text = "Referred By";
            this.Label104.Top = 0.9375F;
            this.Label104.Width = 1.1875F;
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
            this.Label105.Left = 3.46875F;
            this.Label105.Name = "Label105";
            this.Label105.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label105.Text = "Email";
            this.Label105.Top = 1F;
            this.Label105.Width = 1.125F;
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
            this.Label106.Left = 2.5F;
            this.Label106.Name = "Label106";
            this.Label106.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label106.Text = "Work Phone";
            this.Label106.Top = 1F;
            this.Label106.Width = 0.875F;
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
            this.Label107.Left = 0.2604167F;
            this.Label107.Name = "Label107";
            this.Label107.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label107.Text = "Prospect ID";
            this.Label107.Top = 0.9375F;
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
            this.Label108.Height = 0.2F;
            this.Label108.HyperLink = "";
            this.Label108.Left = 1.03125F;
            this.Label108.Name = "Label108";
            this.Label108.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label108.Text = "Name";
            this.Label108.Top = 0.9375F;
            this.Label108.Width = 1.375F;
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
            this.Label109.Left = 6.375F;
            this.Label109.Name = "Label109";
            this.Label109.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label109.Text = "Quote ID";
            this.Label109.Top = 0.9375F;
            this.Label109.Width = 0.5625F;
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
            this.Label110.Left = 7.3125F;
            this.Label110.Name = "Label110";
            this.Label110.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label110.Text = "Total Premium";
            this.Label110.Top = 0.9375F;
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
            this.Label80.Left = 7.5F;
            this.Label80.Name = "Label80";
            this.Label80.Style = "text-align: right; font-size: 8pt; ";
            this.Label80.Text = "Page";
            this.Label80.Top = 0.125F;
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
            this.TextBox17.Left = 7.989583F;
            this.TextBox17.MultiLine = false;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat");
            this.TextBox17.Style = "text-align: right; font-size: 8pt; vertical-align: top; ";
            this.TextBox17.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox17.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.TextBox17.Top = 0.125F;
            this.TextBox17.Width = 0.322917F;
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
            this.Label75.Left = 1.75F;
            this.Label75.MultiLine = false;
            this.Label75.Name = "Label75";
            this.Label75.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 12pt; font-fam" +
                "ily: Times New Roman; ";
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
            this.Label77.Left = 1.75F;
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
            this.TextBox2.DataField = "Name";
            this.TextBox2.Height = 0.125F;
            this.TextBox2.Left = 1.03125F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Style = "font-size: 7pt; ";
            this.TextBox2.Top = 0F;
            this.TextBox2.Width = 1.40625F;
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
            this.TextBox3.DataField = "HomePhone";
            this.TextBox3.Height = 0.125F;
            this.TextBox3.Left = 2.5F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat");
            this.TextBox3.Style = "font-size: 7pt; ";
            this.TextBox3.Top = 0F;
            this.TextBox3.Width = 0.875F;
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
            this.TextBox5.DataField = "Cellular";
            this.TextBox5.Height = 0.125F;
            this.TextBox5.Left = 3.46875F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Style = "font-size: 7pt; ";
            this.TextBox5.Top = 0F;
            this.TextBox5.Width = 1.15625F;
            // 
            // TextBox7
            // 
            this.TextBox7.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox7.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox7.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox7.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox7.DataField = "ReferredByDesc";
            this.TextBox7.Height = 0.125F;
            this.TextBox7.Left = 5.0625F;
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.Style = "font-size: 7pt; ";
            this.TextBox7.Top = 0F;
            this.TextBox7.Width = 1.166667F;
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
            this.TextBox8.HyperLink = "ProspectIndividual.aspx";
            this.TextBox8.Left = 0.2604167F;
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
            this.TextBox9.DataField = "WorkPhone";
            this.TextBox9.Height = 0.125F;
            this.TextBox9.Left = 2.5F;
            this.TextBox9.Name = "TextBox9";
            this.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat");
            this.TextBox9.Style = "font-size: 7pt; ";
            this.TextBox9.Top = 0.125F;
            this.TextBox9.Width = 0.875F;
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
            this.TextBox10.DataField = "Email";
            this.TextBox10.Height = 0.125F;
            this.TextBox10.Left = 3.46875F;
            this.TextBox10.Name = "TextBox10";
            this.TextBox10.Style = "font-size: 7pt; ";
            this.TextBox10.Top = 0.125F;
            this.TextBox10.Width = 1.71875F;
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
            this.TextBox11.HyperLink = "QuoteID";
            this.TextBox11.Left = 6.375F;
            this.TextBox11.Name = "TextBox11";
            this.TextBox11.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox11.Top = 0F;
            this.TextBox11.Width = 0.53125F;
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
            this.TextBox12.DataField = "TotalPremium";
            this.TextBox12.Height = 0.125F;
            this.TextBox12.Left = 7.3125F;
            this.TextBox12.Name = "TextBox12";
            this.TextBox12.OutputFormat = resources.GetString("TextBox12.OutputFormat");
            this.TextBox12.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox12.Top = 0F;
            this.TextBox12.Width = 0.875F;
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
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 0.0625F;
            this.Line9.Width = 8.0625F;
            this.Line9.X1 = 0.25F;
            this.Line9.X2 = 8.3125F;
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
            this.TextBox14.DataField = "ProspectID";
            this.TextBox14.Height = 0.2F;
            this.TextBox14.Left = 0.875F;
            this.TextBox14.Name = "TextBox14";
            this.TextBox14.Style = "font-weight: bold; font-size: 7pt; ";
            this.TextBox14.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox14.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TextBox14.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox14.Top = 0.125F;
            this.TextBox14.Width = 1F;
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
            this.Label116.Left = 0.25F;
            this.Label116.Name = "Label116";
            this.Label116.Style = "font-weight: bold; font-size: 7pt; ";
            this.Label116.Text = "Grand Total:";
            this.Label116.Top = 0.125F;
            this.Label116.Width = 0.625F;
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
            this.TextBox23.DataField = "TotalPremium";
            this.TextBox23.Height = 0.2F;
            this.TextBox23.Left = 7.3125F;
            this.TextBox23.Name = "TextBox23";
            this.TextBox23.OutputFormat = resources.GetString("TextBox23.OutputFormat");
            this.TextBox23.Style = "text-align: center; font-weight: bold; font-size: 7pt; ";
            this.TextBox23.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox23.Text = "TextBox23";
            this.TextBox23.Top = 0.125F;
            this.TextBox23.Width = 0.875F;
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
            ((System.ComponentModel.ISupportInitialize)(this.Label102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label103)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label110)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label116)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
       
			// Attach Report Events
			this.ReportStart += new System.EventHandler(this.ProspectosConCotizacionesIndividuos_ReportStart);
			this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
			this.DataInitialize += new System.EventHandler(this.ProspectosConCotizacionesIndividuos_DataInitialize);
			this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.ProspectosConCotizacionesIndividuos_FetchData);
			this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
			this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
			this.Detail.Format += new System.EventHandler(this.Detail_Format);
		 }

		#endregion
	}
}
