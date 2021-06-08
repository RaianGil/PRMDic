using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports
{
	public class GeneralList : DataDynamics.ActiveReports.ActiveReport3
	{

		string _IDType;

		public GeneralList(string IDType)
		{
			_IDType = IDType; 

			InitializeComponent();
		}

		
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
										
		}

		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void GeneralList_ReportStart(object sender, System.EventArgs eArgs)
		{
			//int a = _IDType.IndexOf(" ",1);
			//this.Label104.Text = _IDType.Substring(0,a) + " ID";;
			//this.lblCriterias.Text = _IDType;
			
			this.Label104.Text = _IDType + " ID";
			this.lblCriterias.Text = _IDType + " List";
			this.lblDate.Text = "Date:"+DateTime.Now.ToShortDateString();
			this.lblTime.Text = "Time:"+DateTime.Now.ToShortTimeString();
		}

	#region ActiveReports Designer generated code
		private PageHeader PageHeader = null;
		private Label lblCriterias = null;
		private Label lblDate = null;
		private Label lblTime = null;
		private Label Label80 = null;
		private TextBox TextBox17 = null;
		private Label Label104 = null;
		private Label Label105 = null;
		private Label Label77 = null;
		private Label Label75 = null;
		private Line Line10 = null;
		private Detail Detail = null;
		private TextBox TextBox8 = null;
		private TextBox TextBox2 = null;
		private PageFooter PageFooter = null;
		private Line Line9 = null;
		private Label Label124 = null;
		private TextBox TextBox12 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralList));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.TextBox8 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox2 = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.lblCriterias = new DataDynamics.ActiveReports.Label();
            this.lblDate = new DataDynamics.ActiveReports.Label();
            this.lblTime = new DataDynamics.ActiveReports.Label();
            this.Label80 = new DataDynamics.ActiveReports.Label();
            this.TextBox17 = new DataDynamics.ActiveReports.TextBox();
            this.Label104 = new DataDynamics.ActiveReports.Label();
            this.Label105 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Line10 = new DataDynamics.ActiveReports.Line();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.Label124 = new DataDynamics.ActiveReports.Label();
            this.TextBox12 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label124)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TextBox8,
            this.TextBox2});
            this.Detail.Height = 0.2076389F;
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
            this.TextBox8.DataField = "ID";
            this.TextBox8.Height = 0.125F;
            this.TextBox8.Left = 1.4375F;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox8.Text = null;
            this.TextBox8.Top = 0F;
            this.TextBox8.Width = 0.75F;
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
            this.TextBox2.DataField = "Description";
            this.TextBox2.Height = 0.125F;
            this.TextBox2.Left = 3.9375F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Style = "font-size: 7pt; ";
            this.TextBox2.Text = null;
            this.TextBox2.Top = 0F;
            this.TextBox2.Width = 3.0625F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblCriterias,
            this.lblDate,
            this.lblTime,
            this.Label80,
            this.TextBox17,
            this.Label104,
            this.Label105,
            this.Label77,
            this.Label75,
            this.Line10});
            this.PageHeader.Height = 1.5625F;
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
            this.lblCriterias.Left = 1.552083F;
            this.lblCriterias.MultiLine = false;
            this.lblCriterias.Name = "lblCriterias";
            this.lblCriterias.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.lblCriterias.Text = "Bank  List";
            this.lblCriterias.Top = 0.625F;
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
            this.lblDate.Left = 0.5625F;
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
            this.lblTime.Left = 0.5625F;
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
            this.TextBox17.Left = 7.25F;
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
            this.Label104.Left = 1.25F;
            this.Label104.Name = "Label104";
            this.Label104.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label104.Text = "Bank ID";
            this.Label104.Top = 1.125F;
            this.Label104.Width = 1.5625F;
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
            this.Label105.Left = 3.9375F;
            this.Label105.Name = "Label105";
            this.Label105.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label105.Text = "Description";
            this.Label105.Top = 1.125F;
            this.Label105.Width = 1.375F;
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
            this.Label77.Left = 1.5625F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-align: center; font-weight: bold; font-size: 6pt; font-family: Times New Rom" +
                "an; ";
            this.Label77.Text = "";
            this.Label77.Top = 0.4375F;
            this.Label77.Width = 5.125F;
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
            this.Label75.Left = 1.552083F;
            this.Label75.MultiLine = false;
            this.Label75.Name = "Label75";
            this.Label75.Style = "text-align: center; font-weight: bold; font-size: 11.25pt; font-family: Times New" +
                " Roman; ";
            this.Label75.Text = "PUERTO RICO MEDICAL DEFENSE INSURANCE COMPANY";
            this.Label75.Top = 0.1875F;
            this.Label75.Width = 5.125F;
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
            this.Line10.Left = 0.5625F;
            this.Line10.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Line10.LineWeight = 1F;
            this.Line10.Name = "Line10";
            this.Line10.Top = 1.4375F;
            this.Line10.Width = 7.3125F;
            this.Line10.X1 = 7.875F;
            this.Line10.X2 = 0.5625F;
            this.Line10.Y1 = 1.4375F;
            this.Line10.Y2 = 1.4375F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line9,
            this.Label124,
            this.TextBox12});
            this.PageFooter.Height = 0.3333333F;
            this.PageFooter.Name = "PageFooter";
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
            this.Line9.Left = 0.375F;
            this.Line9.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 0F;
            this.Line9.Width = 7.3125F;
            this.Line9.X1 = 0.375F;
            this.Line9.X2 = 7.6875F;
            this.Line9.Y1 = 0F;
            this.Line9.Y2 = 0F;
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
            this.Label124.Left = 0.75F;
            this.Label124.Name = "Label124";
            this.Label124.Style = "font-weight: bold; font-size: 7pt; ";
            this.Label124.Text = "Grand Total:";
            this.Label124.Top = 0.0625F;
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
            this.TextBox12.DataField = "ID";
            this.TextBox12.Height = 0.2F;
            this.TextBox12.Left = 1.4375F;
            this.TextBox12.Name = "TextBox12";
            this.TextBox12.Style = "font-weight: bold; font-size: 7pt; ";
            this.TextBox12.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox12.SummaryGroup = "GroupHeader1";
            this.TextBox12.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox12.Text = null;
            this.TextBox12.Top = 0.0625F;
            this.TextBox12.Width = 1F;
            // 
            // GeneralList
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.5F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.229167F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.GeneralList_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label124)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
