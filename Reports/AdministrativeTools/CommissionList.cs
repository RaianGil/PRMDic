using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports
{
	public class CommissionList : DataDynamics.ActiveReports.ActiveReport3
	{

		string _CommissionType;
		string _Description;
		string _ID;
		
		public CommissionList(string CommissionType, string Description, string ID)
		{

			_CommissionType = CommissionType; 
			_Description    = Description;
			_ID = ID;
			InitializeComponent();
		}

		

		private void GroupHeader1_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void CommissionList_ReportStart(object sender, System.EventArgs eArgs)
		{
			this.lblCriterias.Text = _CommissionType + " List";
			this.LblDesc.Text	   = _Description;
			this.LabelID.Text =  _ID;
			this.lblDate.Text = "Date:"+DateTime.Now.ToShortDateString();
			this.lblTime.Text = "Time:"+DateTime.Now.ToShortTimeString();
		}

		#region ActiveReports Designer generated code
		private PageHeader PageHeader = null;
		private Label lblDate = null;
		private Label lblTime = null;
		private Label Label75 = null;
		private Label Label77 = null;
		private Label lblCriterias = null;
		private Label Label80 = null;
		private TextBox TextBox17 = null;
		private Label Label105 = null;
		private Label Label106 = null;
		private Label Label107 = null;
		private Label Label108 = null;
		private Label Label109 = null;
		private Label Label110 = null;
		private Line Line10 = null;
		private GroupHeader GroupHeader1 = null;
		private Label LabelID = null;
		private Label LblDesc = null;
		private Label Label125 = null;
		private Detail Detail = null;
		private TextBox TextBox8 = null;
		private TextBox TextBox18 = null;
		private TextBox TextBox19 = null;
		private TextBox TextBox20 = null;
		private TextBox TextBox21 = null;
		private TextBox TextBox22 = null;
		private GroupFooter GroupFooter1 = null;
		private PageFooter PageFooter = null;
		private Label Label124 = null;
		private TextBox TextBox12 = null;
		private Line Line9 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommissionList));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.TextBox8 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox18 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox19 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox20 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox21 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox22 = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.lblDate = new DataDynamics.ActiveReports.Label();
            this.lblTime = new DataDynamics.ActiveReports.Label();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.lblCriterias = new DataDynamics.ActiveReports.Label();
            this.Label80 = new DataDynamics.ActiveReports.Label();
            this.TextBox17 = new DataDynamics.ActiveReports.TextBox();
            this.Label105 = new DataDynamics.ActiveReports.Label();
            this.Label106 = new DataDynamics.ActiveReports.Label();
            this.Label107 = new DataDynamics.ActiveReports.Label();
            this.Label108 = new DataDynamics.ActiveReports.Label();
            this.Label109 = new DataDynamics.ActiveReports.Label();
            this.Label110 = new DataDynamics.ActiveReports.Label();
            this.Line10 = new DataDynamics.ActiveReports.Line();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Label124 = new DataDynamics.ActiveReports.Label();
            this.TextBox12 = new DataDynamics.ActiveReports.TextBox();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.GroupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.LabelID = new DataDynamics.ActiveReports.Label();
            this.LblDesc = new DataDynamics.ActiveReports.Label();
            this.Label125 = new DataDynamics.ActiveReports.Label();
            this.GroupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label110)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label124)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LabelID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label125)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TextBox8,
            this.TextBox18,
            this.TextBox19,
            this.TextBox20,
            this.TextBox21,
            this.TextBox22});
            this.Detail.Height = 0.21875F;
            this.Detail.Name = "Detail";
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
            this.TextBox8.DataField = "PolicyClassID";
            this.TextBox8.Height = 0.125F;
            this.TextBox8.Left = 1.5F;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox8.Text = null;
            this.TextBox8.Top = 0.0625F;
            this.TextBox8.Width = 0.5F;
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
            this.TextBox18.DataField = "PolicyType";
            this.TextBox18.Height = 0.125F;
            this.TextBox18.Left = 2.8125F;
            this.TextBox18.Name = "TextBox18";
            this.TextBox18.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox18.Text = null;
            this.TextBox18.Top = 0.0625F;
            this.TextBox18.Width = 0.375F;
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
            this.TextBox19.DataField = "InsuranceCompanyID";
            this.TextBox19.Height = 0.125F;
            this.TextBox19.Left = 3.75F;
            this.TextBox19.Name = "TextBox19";
            this.TextBox19.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox19.Text = null;
            this.TextBox19.Top = 0.0625F;
            this.TextBox19.Width = 0.5F;
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
            this.TextBox20.DataField = "CommissionRate";
            this.TextBox20.Height = 0.125F;
            this.TextBox20.Left = 4.8125F;
            this.TextBox20.Name = "TextBox20";
            this.TextBox20.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox20.Text = null;
            this.TextBox20.Top = 0.0625F;
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
            this.TextBox21.DataField = "EffectiveDate";
            this.TextBox21.Height = 0.125F;
            this.TextBox21.Left = 5.625F;
            this.TextBox21.Name = "TextBox21";
            this.TextBox21.OutputFormat = resources.GetString("TextBox21.OutputFormat");
            this.TextBox21.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox21.Text = null;
            this.TextBox21.Top = 0.0625F;
            this.TextBox21.Width = 0.9375F;
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
            this.TextBox22.DataField = "CommissionEntryDate";
            this.TextBox22.Height = 0.125F;
            this.TextBox22.Left = 6.75F;
            this.TextBox22.Name = "TextBox22";
            this.TextBox22.OutputFormat = resources.GetString("TextBox22.OutputFormat");
            this.TextBox22.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox22.Text = null;
            this.TextBox22.Top = 0.0625F;
            this.TextBox22.Width = 0.75F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblDate,
            this.lblTime,
            this.Label75,
            this.Label77,
            this.lblCriterias,
            this.Label80,
            this.TextBox17,
            this.Label105,
            this.Label106,
            this.Label107,
            this.Label108,
            this.Label109,
            this.Label110,
            this.Line10});
            this.PageHeader.Height = 1.478472F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
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
            this.lblDate.Left = 0.625F;
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
            this.lblTime.Left = 0.625F;
            this.lblTime.Name = "lblTime";
            this.lblTime.Style = "text-align: left; font-size: 8pt; ";
            this.lblTime.Text = "lblTime";
            this.lblTime.Top = 0.375F;
            this.lblTime.Width = 0.9090909F;
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
            this.Label75.Left = 1.567708F;
            this.Label75.MultiLine = false;
            this.Label75.Name = "Label75";
            this.Label75.Style = "text-align: center; font-weight: bold; font-size: 11.25pt; font-family: Times New" +
                " Roman; ";
            this.Label75.Text = "PUERTO RICO MEDICAL DEFENSE INSURANCE COMPANY";
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
            this.Label77.Left = 1.567708F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-align: center; font-weight: bold; font-size: 6pt; font-family: Times New Rom" +
                "an; ";
            this.Label77.Text = "";
            this.Label77.Top = 0.4375F;
            this.Label77.Width = 5.125F;
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
            this.lblCriterias.Left = 1.567708F;
            this.lblCriterias.MultiLine = false;
            this.lblCriterias.Name = "lblCriterias";
            this.lblCriterias.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.lblCriterias.Text = "Commission  List";
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
            this.Label80.Left = 6.8125F;
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
            this.TextBox17.Left = 7.3125F;
            this.TextBox17.MultiLine = false;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat");
            this.TextBox17.Style = "text-align: right; font-size: 8pt; vertical-align: top; ";
            this.TextBox17.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox17.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.TextBox17.Text = null;
            this.TextBox17.Top = 0.1875F;
            this.TextBox17.Width = 0.322917F;
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
            this.Label105.Left = 1.3125F;
            this.Label105.Name = "Label105";
            this.Label105.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label105.Text = "Line of Business";
            this.Label105.Top = 1.125F;
            this.Label105.Width = 1.0625F;
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
            this.Label106.Left = 2.625F;
            this.Label106.Name = "Label106";
            this.Label106.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label106.Text = "Policy Type";
            this.Label106.Top = 1.125F;
            this.Label106.Width = 0.75F;
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
            this.Label107.Left = 3.625F;
            this.Label107.Name = "Label107";
            this.Label107.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label107.Text = "Insurance Co.";
            this.Label107.Top = 1.125F;
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
            this.Label108.Left = 4.75F;
            this.Label108.Name = "Label108";
            this.Label108.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label108.Text = "Rate";
            this.Label108.Top = 1.125F;
            this.Label108.Width = 0.5625F;
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
            this.Label109.Left = 5.5625F;
            this.Label109.Name = "Label109";
            this.Label109.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label109.Text = "Effective Date";
            this.Label109.Top = 1.125F;
            this.Label109.Width = 0.8125F;
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
            this.Label110.Left = 6.625F;
            this.Label110.Name = "Label110";
            this.Label110.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label110.Text = "Entry Date";
            this.Label110.Top = 1.125F;
            this.Label110.Width = 0.625F;
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
            this.Line10.Left = 0.6944444F;
            this.Line10.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Line10.LineWeight = 1F;
            this.Line10.Name = "Line10";
            this.Line10.Top = 1.131944F;
            this.Line10.Width = 7.250001F;
            this.Line10.X1 = 0.6944444F;
            this.Line10.X2 = 7.944445F;
            this.Line10.Y1 = 1.131944F;
            this.Line10.Y2 = 1.131944F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label124,
            this.TextBox12,
            this.Line9});
            this.PageFooter.Height = 0.3243056F;
            this.PageFooter.Name = "PageFooter";
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
            this.Label124.Left = 0.625F;
            this.Label124.Name = "Label124";
            this.Label124.Style = "font-weight: bold; font-size: 7pt; ";
            this.Label124.Text = "Grand Total:";
            this.Label124.Top = 0.125F;
            this.Label124.Width = 0.625F;
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
            this.TextBox12.DataField = "PolicyClassID";
            this.TextBox12.Height = 0.2F;
            this.TextBox12.Left = 1.3125F;
            this.TextBox12.Name = "TextBox12";
            this.TextBox12.Style = "font-weight: bold; font-size: 7pt; ";
            this.TextBox12.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox12.SummaryGroup = "GroupHeader1";
            this.TextBox12.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox12.Text = null;
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
            this.Line9.Left = 0.5625F;
            this.Line9.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 0.0625F;
            this.Line9.Width = 7.25F;
            this.Line9.X1 = 0.5625F;
            this.Line9.X2 = 7.8125F;
            this.Line9.Y1 = 0.0625F;
            this.Line9.Y2 = 0.0625F;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.LabelID,
            this.LblDesc,
            this.Label125});
            this.GroupHeader1.Height = 0.34375F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.Format += new System.EventHandler(this.GroupHeader1_Format);
            // 
            // LabelID
            // 
            this.LabelID.Border.BottomColor = System.Drawing.Color.Black;
            this.LabelID.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LabelID.Border.LeftColor = System.Drawing.Color.Black;
            this.LabelID.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LabelID.Border.RightColor = System.Drawing.Color.Black;
            this.LabelID.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LabelID.Border.TopColor = System.Drawing.Color.Black;
            this.LabelID.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LabelID.Height = 0.2F;
            this.LabelID.HyperLink = "";
            this.LabelID.Left = 0.8125F;
            this.LabelID.Name = "LabelID";
            this.LabelID.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.LabelID.Text = "Agency:";
            this.LabelID.Top = 0.0625F;
            this.LabelID.Width = 0.5F;
            // 
            // LblDesc
            // 
            this.LblDesc.Border.BottomColor = System.Drawing.Color.Black;
            this.LblDesc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblDesc.Border.LeftColor = System.Drawing.Color.Black;
            this.LblDesc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblDesc.Border.RightColor = System.Drawing.Color.Black;
            this.LblDesc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblDesc.Border.TopColor = System.Drawing.Color.Black;
            this.LblDesc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblDesc.Height = 0.2F;
            this.LblDesc.HyperLink = "";
            this.LblDesc.Left = 1.375F;
            this.LblDesc.Name = "LblDesc";
            this.LblDesc.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.LblDesc.Text = "";
            this.LblDesc.Top = 0.0625F;
            this.LblDesc.Width = 2F;
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
            this.Label125.Left = 0.625F;
            this.Label125.Name = "Label125";
            this.Label125.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label125.Text = "ID:";
            this.Label125.Top = 0.0625F;
            this.Label125.Width = 0.1875F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Height = 0F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // CommissionList
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.5F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.260417F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.GroupHeader1);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GroupFooter1);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.CommissionList_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label110)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label124)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LabelID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label125)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
