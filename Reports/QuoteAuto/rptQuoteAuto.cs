using System;
using System.Configuration;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.TaskControl;
using EPolicy.Quotes;
using EPolicy.LookupTables;
using EPolicy;

namespace EPolicy2.Reports
{
	/// <summary>
	/// Summary description for rptQuoteAuto.
	/// </summary>
	public class rptQuoteAuto : DataDynamics.ActiveReports.ActiveReport3
	{
        private System.Collections.ArrayList _autoCovers = null;
        private Picture picture1;
        private EPolicy.TaskControl.QuoteAuto _policy;

        public rptQuoteAuto(EPolicy.TaskControl.QuoteAuto AutoQuote, string UserName)
        {
            InitializeComponent();
            _policy = AutoQuote;
            this._autoCovers = AutoQuote.AutoCovers;
            this.FillFields(AutoQuote, UserName);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
			}
			base.Dispose( disposing );
		}

		#region Report Designer generated code

        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.SubReport subCovers;
        private DataDynamics.ActiveReports.PageHeader PageHeader;
        private DataDynamics.ActiveReports.Label lblDate;
        private DataDynamics.ActiveReports.Label lblTime;
        private DataDynamics.ActiveReports.Label Label80;
        private DataDynamics.ActiveReports.TextBox txtPageNumber;
        private DataDynamics.ActiveReports.Label Label1;
        private DataDynamics.ActiveReports.Label Label9;
        private DataDynamics.ActiveReports.TextBox txtQuotation;
        private DataDynamics.ActiveReports.Label Label97;
        private DataDynamics.ActiveReports.TextBox txtPreparedBy;
        private DataDynamics.ActiveReports.TextBox TextBox7;
        private DataDynamics.ActiveReports.TextBox TextBox8;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
        private DataDynamics.ActiveReports.Label Label124;
        private DataDynamics.ActiveReports.GroupHeader ghAutoQuote;
        private DataDynamics.ActiveReports.Shape Shape3;
        private DataDynamics.ActiveReports.Label Label87;
        private DataDynamics.ActiveReports.TextBox TextBox5;
        private DataDynamics.ActiveReports.TextBox txtEffectiveDate;
        private DataDynamics.ActiveReports.Label Label98;
        private DataDynamics.ActiveReports.TextBox txtTerm;
        private DataDynamics.ActiveReports.Label Label99;
        private DataDynamics.ActiveReports.TextBox txtExpirationDate;
        private DataDynamics.ActiveReports.Label Label100;
        private DataDynamics.ActiveReports.TextBox txtEntryDate;
        private DataDynamics.ActiveReports.Label Label101;
        private DataDynamics.ActiveReports.TextBox txtPremium;
        private DataDynamics.ActiveReports.Label Label102;
        private DataDynamics.ActiveReports.TextBox txtCharge;
        private DataDynamics.ActiveReports.TextBox txtTotalPremium;
        private DataDynamics.ActiveReports.Label Label103;
        private DataDynamics.ActiveReports.Label Label111;
        private DataDynamics.ActiveReports.TextBox txtCollision;
        private DataDynamics.ActiveReports.Label Label112;
        private DataDynamics.ActiveReports.TextBox txtBodilyInjury;
        private DataDynamics.ActiveReports.Label Label113;
        private DataDynamics.ActiveReports.TextBox txtPropertyDmg;
        private DataDynamics.ActiveReports.TextBox txtComprehensive;
        private DataDynamics.ActiveReports.Label Label114;
        private DataDynamics.ActiveReports.Label Label115;
        private DataDynamics.ActiveReports.TextBox txtLeaseLoanGap;
        private DataDynamics.ActiveReports.TextBox txtPAR;
        private DataDynamics.ActiveReports.Label Label116;
        private DataDynamics.ActiveReports.Label Label117;
        private DataDynamics.ActiveReports.TextBox txtAssist;
        private DataDynamics.ActiveReports.Label Label118;
        private DataDynamics.ActiveReports.Label Label121;
        private DataDynamics.ActiveReports.Label Label122;
        private DataDynamics.ActiveReports.Label Label123;
        private DataDynamics.ActiveReports.TextBox txtTowing;
        private DataDynamics.ActiveReports.TextBox TxtSeatBelt;
        private DataDynamics.ActiveReports.TextBox TxtRental;
        private DataDynamics.ActiveReports.Line Line1;
        private DataDynamics.ActiveReports.GroupFooter GroupFooter1;

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptQuoteAuto));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.subCovers = new DataDynamics.ActiveReports.SubReport();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.lblDate = new DataDynamics.ActiveReports.Label();
            this.lblTime = new DataDynamics.ActiveReports.Label();
            this.Label80 = new DataDynamics.ActiveReports.Label();
            this.txtPageNumber = new DataDynamics.ActiveReports.TextBox();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.Label9 = new DataDynamics.ActiveReports.Label();
            this.txtQuotation = new DataDynamics.ActiveReports.TextBox();
            this.Label97 = new DataDynamics.ActiveReports.Label();
            this.txtPreparedBy = new DataDynamics.ActiveReports.TextBox();
            this.TextBox7 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox8 = new DataDynamics.ActiveReports.TextBox();
            this.picture1 = new DataDynamics.ActiveReports.Picture();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Label124 = new DataDynamics.ActiveReports.Label();
            this.ghAutoQuote = new DataDynamics.ActiveReports.GroupHeader();
            this.Shape3 = new DataDynamics.ActiveReports.Shape();
            this.Label87 = new DataDynamics.ActiveReports.Label();
            this.TextBox5 = new DataDynamics.ActiveReports.TextBox();
            this.txtEffectiveDate = new DataDynamics.ActiveReports.TextBox();
            this.Label98 = new DataDynamics.ActiveReports.Label();
            this.txtTerm = new DataDynamics.ActiveReports.TextBox();
            this.Label99 = new DataDynamics.ActiveReports.Label();
            this.txtExpirationDate = new DataDynamics.ActiveReports.TextBox();
            this.Label100 = new DataDynamics.ActiveReports.Label();
            this.txtEntryDate = new DataDynamics.ActiveReports.TextBox();
            this.Label101 = new DataDynamics.ActiveReports.Label();
            this.txtPremium = new DataDynamics.ActiveReports.TextBox();
            this.Label102 = new DataDynamics.ActiveReports.Label();
            this.txtCharge = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalPremium = new DataDynamics.ActiveReports.TextBox();
            this.Label103 = new DataDynamics.ActiveReports.Label();
            this.Label111 = new DataDynamics.ActiveReports.Label();
            this.txtCollision = new DataDynamics.ActiveReports.TextBox();
            this.Label112 = new DataDynamics.ActiveReports.Label();
            this.txtBodilyInjury = new DataDynamics.ActiveReports.TextBox();
            this.Label113 = new DataDynamics.ActiveReports.Label();
            this.txtPropertyDmg = new DataDynamics.ActiveReports.TextBox();
            this.txtComprehensive = new DataDynamics.ActiveReports.TextBox();
            this.Label114 = new DataDynamics.ActiveReports.Label();
            this.Label115 = new DataDynamics.ActiveReports.Label();
            this.txtLeaseLoanGap = new DataDynamics.ActiveReports.TextBox();
            this.txtPAR = new DataDynamics.ActiveReports.TextBox();
            this.Label116 = new DataDynamics.ActiveReports.Label();
            this.Label117 = new DataDynamics.ActiveReports.Label();
            this.txtAssist = new DataDynamics.ActiveReports.TextBox();
            this.Label118 = new DataDynamics.ActiveReports.Label();
            this.Label121 = new DataDynamics.ActiveReports.Label();
            this.Label122 = new DataDynamics.ActiveReports.Label();
            this.Label123 = new DataDynamics.ActiveReports.Label();
            this.txtTowing = new DataDynamics.ActiveReports.TextBox();
            this.TxtSeatBelt = new DataDynamics.ActiveReports.TextBox();
            this.TxtRental = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.GroupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label97)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreparedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label124)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label87)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label98)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTerm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label99)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpirationDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCharge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label103)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCollision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label112)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBodilyInjury)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label113)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPropertyDmg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComprehensive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label114)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label115)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeaseLoanGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label116)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label117)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAssist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label118)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label121)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label122)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label123)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTowing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSeatBelt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRental)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.subCovers});
            this.Detail.Height = 3.548611F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // subCovers
            // 
            this.subCovers.Border.BottomColor = System.Drawing.Color.Black;
            this.subCovers.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subCovers.Border.LeftColor = System.Drawing.Color.Black;
            this.subCovers.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subCovers.Border.RightColor = System.Drawing.Color.Black;
            this.subCovers.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subCovers.Border.TopColor = System.Drawing.Color.Black;
            this.subCovers.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subCovers.CloseBorder = false;
            this.subCovers.Height = 3.4F;
            this.subCovers.Left = 0F;
            this.subCovers.Name = "subCovers";
            this.subCovers.Report = null;
            this.subCovers.Top = 0F;
            this.subCovers.Width = 7F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblDate,
            this.lblTime,
            this.Label80,
            this.txtPageNumber,
            this.Label1,
            this.Label9,
            this.txtQuotation,
            this.Label97,
            this.txtPreparedBy,
            this.TextBox7,
            this.TextBox8,
            this.picture1});
            this.PageHeader.Height = 1.681944F;
            this.PageHeader.Name = "PageHeader";
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
            this.lblDate.HyperLink = null;
            this.lblDate.Left = 0F;
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
            this.lblTime.HyperLink = null;
            this.lblTime.Left = 0F;
            this.lblTime.Name = "lblTime";
            this.lblTime.Style = "text-align: left; font-size: 8pt; ";
            this.lblTime.Text = "lblTime";
            this.lblTime.Top = 0.1875F;
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
            this.Label80.HyperLink = null;
            this.Label80.Left = 6F;
            this.Label80.Name = "Label80";
            this.Label80.Style = "text-align: right; font-size: 8pt; ";
            this.Label80.Text = "Page:";
            this.Label80.Top = 0F;
            this.Label80.Width = 0.4375F;
            // 
            // txtPageNumber
            // 
            this.txtPageNumber.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPageNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPageNumber.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPageNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPageNumber.Border.RightColor = System.Drawing.Color.Black;
            this.txtPageNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPageNumber.Border.TopColor = System.Drawing.Color.Black;
            this.txtPageNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPageNumber.Height = 0.1875F;
            this.txtPageNumber.Left = 6.4375F;
            this.txtPageNumber.MultiLine = false;
            this.txtPageNumber.Name = "txtPageNumber";
            this.txtPageNumber.OutputFormat = resources.GetString("txtPageNumber.OutputFormat");
            this.txtPageNumber.Style = "text-align: left; font-size: 8pt; vertical-align: top; ";
            this.txtPageNumber.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.txtPageNumber.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtPageNumber.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtPageNumber.Text = "#";
            this.txtPageNumber.Top = 0F;
            this.txtPageNumber.Width = 0.25F;
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
            this.Label1.Height = 0.2F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 2.308333F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.Label1.Text = "Personal Auto Quote";
            this.Label1.Top = 1F;
            this.Label1.Width = 2.375F;
            // 
            // Label9
            // 
            this.Label9.Border.BottomColor = System.Drawing.Color.Black;
            this.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.LeftColor = System.Drawing.Color.Black;
            this.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.RightColor = System.Drawing.Color.Black;
            this.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.TopColor = System.Drawing.Color.Black;
            this.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Height = 0.2F;
            this.Label9.HyperLink = null;
            this.Label9.Left = 0F;
            this.Label9.Name = "Label9";
            this.Label9.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label9.Text = "Quotation  No:";
            this.Label9.Top = 1F;
            this.Label9.Width = 0.9375F;
            // 
            // txtQuotation
            // 
            this.txtQuotation.Border.BottomColor = System.Drawing.Color.Black;
            this.txtQuotation.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtQuotation.Border.LeftColor = System.Drawing.Color.Black;
            this.txtQuotation.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtQuotation.Border.RightColor = System.Drawing.Color.Black;
            this.txtQuotation.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtQuotation.Border.TopColor = System.Drawing.Color.Black;
            this.txtQuotation.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtQuotation.Height = 0.2F;
            this.txtQuotation.Left = 0.9375F;
            this.txtQuotation.Name = "txtQuotation";
            this.txtQuotation.Style = "font-size: 8.25pt; ";
            this.txtQuotation.Text = "txtQuotation";
            this.txtQuotation.Top = 1F;
            this.txtQuotation.Width = 0.75F;
            // 
            // Label97
            // 
            this.Label97.Border.BottomColor = System.Drawing.Color.Black;
            this.Label97.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label97.Border.LeftColor = System.Drawing.Color.Black;
            this.Label97.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label97.Border.RightColor = System.Drawing.Color.Black;
            this.Label97.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label97.Border.TopColor = System.Drawing.Color.Black;
            this.Label97.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label97.Height = 0.2F;
            this.Label97.HyperLink = null;
            this.Label97.Left = 0F;
            this.Label97.Name = "Label97";
            this.Label97.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label97.Text = "Prepared By:";
            this.Label97.Top = 1.25F;
            this.Label97.Width = 0.9375F;
            // 
            // txtPreparedBy
            // 
            this.txtPreparedBy.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPreparedBy.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPreparedBy.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPreparedBy.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPreparedBy.Border.RightColor = System.Drawing.Color.Black;
            this.txtPreparedBy.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPreparedBy.Border.TopColor = System.Drawing.Color.Black;
            this.txtPreparedBy.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPreparedBy.Height = 0.2F;
            this.txtPreparedBy.Left = 0.9375F;
            this.txtPreparedBy.Name = "txtPreparedBy";
            this.txtPreparedBy.Style = "font-size: 8.25pt; ";
            this.txtPreparedBy.Text = "txtPreparedBy";
            this.txtPreparedBy.Top = 1.25F;
            this.txtPreparedBy.Width = 2.9375F;
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
            this.TextBox7.Height = 0.1875F;
            this.TextBox7.Left = 6.75F;
            this.TextBox7.MultiLine = false;
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat");
            this.TextBox7.Style = "text-align: left; font-size: 8pt; vertical-align: top; ";
            this.TextBox7.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox7.SummaryGroup = "ghAutoQuote";
            this.TextBox7.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.TextBox7.Text = "##";
            this.TextBox7.Top = 0F;
            this.TextBox7.Width = 0.1875F;
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
            this.TextBox8.Height = 0.2F;
            this.TextBox8.Left = 6.5625F;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.Style = "font-size: 8.25pt; ";
            this.TextBox8.Text = "of";
            this.TextBox8.Top = 0F;
            this.TextBox8.Width = 0.1875F;
            // 
            // picture1
            // 
            this.picture1.Border.BottomColor = System.Drawing.Color.Black;
            this.picture1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.picture1.Border.LeftColor = System.Drawing.Color.Black;
            this.picture1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.picture1.Border.RightColor = System.Drawing.Color.Black;
            this.picture1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.picture1.Border.TopColor = System.Drawing.Color.Black;
            this.picture1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.picture1.Height = 0.8125F;
            this.picture1.Image = ((System.Drawing.Image)(resources.GetObject("picture1.Image")));
            this.picture1.ImageData = ((System.IO.Stream)(resources.GetObject("picture1.ImageData")));
            this.picture1.Left = 2.308333F;
            this.picture1.LineWeight = 0F;
            this.picture1.Name = "picture1";
            this.picture1.Top = 0F;
            this.picture1.Width = 2.375F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label124});
            this.PageFooter.Height = 0.3243056F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
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
            this.Label124.Height = 0.1875F;
            this.Label124.HyperLink = null;
            this.Label124.Left = 0.0625F;
            this.Label124.Name = "Label124";
            this.Label124.Style = "font-size: 6pt; ";
            this.Label124.Text = "Esta cotización es válida por 30 días y está sujeta a inspección satisfactoria.  " +
                "Su póliza será emitida tan pronto recibamos su pago según la Regla 29.";
            this.Label124.Top = 0F;
            this.Label124.Width = 6.4375F;
            // 
            // ghAutoQuote
            // 
            this.ghAutoQuote.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Shape3,
            this.Label87,
            this.TextBox5,
            this.txtEffectiveDate,
            this.Label98,
            this.txtTerm,
            this.Label99,
            this.txtExpirationDate,
            this.Label100,
            this.txtEntryDate,
            this.Label101,
            this.txtPremium,
            this.Label102,
            this.txtCharge,
            this.txtTotalPremium,
            this.Label103,
            this.Label111,
            this.txtCollision,
            this.Label112,
            this.txtBodilyInjury,
            this.Label113,
            this.txtPropertyDmg,
            this.txtComprehensive,
            this.Label114,
            this.Label115,
            this.txtLeaseLoanGap,
            this.txtPAR,
            this.Label116,
            this.Label117,
            this.txtAssist,
            this.Label118,
            this.Label121,
            this.Label122,
            this.Label123,
            this.txtTowing,
            this.TxtSeatBelt,
            this.TxtRental,
            this.Line1});
            this.ghAutoQuote.Height = 2.145139F;
            this.ghAutoQuote.Name = "ghAutoQuote";
            // 
            // Shape3
            // 
            this.Shape3.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.RightColor = System.Drawing.Color.Black;
            this.Shape3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.TopColor = System.Drawing.Color.Black;
            this.Shape3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Height = 0.8125F;
            this.Shape3.Left = 5.125F;
            this.Shape3.Name = "Shape3";
            this.Shape3.RoundingRadius = 9.999999F;
            this.Shape3.Top = 1.25F;
            this.Shape3.Width = 1.75F;
            // 
            // Label87
            // 
            this.Label87.Border.BottomColor = System.Drawing.Color.Black;
            this.Label87.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label87.Border.LeftColor = System.Drawing.Color.Black;
            this.Label87.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label87.Border.RightColor = System.Drawing.Color.Black;
            this.Label87.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label87.Border.TopColor = System.Drawing.Color.Black;
            this.Label87.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label87.Height = 0.2F;
            this.Label87.HyperLink = null;
            this.Label87.Left = 0.0625F;
            this.Label87.Name = "Label87";
            this.Label87.Style = "color: Black; font-weight: bold; ";
            this.Label87.Text = "General Policy Information";
            this.Label87.Top = 0.0625F;
            this.Label87.Width = 1.875F;
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
            this.TextBox5.Height = 0.2F;
            this.TextBox5.Left = 0F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.TextBox5.Text = "Effective Date:";
            this.TextBox5.Top = 0.375F;
            this.TextBox5.Width = 0.9375F;
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
            this.txtEffectiveDate.Height = 0.2F;
            this.txtEffectiveDate.Left = 0.9375F;
            this.txtEffectiveDate.Name = "txtEffectiveDate";
            this.txtEffectiveDate.Style = "font-size: 8.25pt; ";
            this.txtEffectiveDate.Text = "txtEffectiveDate";
            this.txtEffectiveDate.Top = 0.375F;
            this.txtEffectiveDate.Width = 1F;
            // 
            // Label98
            // 
            this.Label98.Border.BottomColor = System.Drawing.Color.Black;
            this.Label98.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label98.Border.LeftColor = System.Drawing.Color.Black;
            this.Label98.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label98.Border.RightColor = System.Drawing.Color.Black;
            this.Label98.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label98.Border.TopColor = System.Drawing.Color.Black;
            this.Label98.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label98.Height = 0.2F;
            this.Label98.HyperLink = null;
            this.Label98.Left = 0F;
            this.Label98.Name = "Label98";
            this.Label98.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label98.Text = "Term:";
            this.Label98.Top = 0.625F;
            this.Label98.Width = 0.938F;
            // 
            // txtTerm
            // 
            this.txtTerm.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTerm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTerm.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTerm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTerm.Border.RightColor = System.Drawing.Color.Black;
            this.txtTerm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTerm.Border.TopColor = System.Drawing.Color.Black;
            this.txtTerm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTerm.Height = 0.2F;
            this.txtTerm.Left = 0.9375F;
            this.txtTerm.Name = "txtTerm";
            this.txtTerm.Style = "font-size: 8.25pt; ";
            this.txtTerm.Text = "txtTerm";
            this.txtTerm.Top = 0.625F;
            this.txtTerm.Width = 1F;
            // 
            // Label99
            // 
            this.Label99.Border.BottomColor = System.Drawing.Color.Black;
            this.Label99.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label99.Border.LeftColor = System.Drawing.Color.Black;
            this.Label99.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label99.Border.RightColor = System.Drawing.Color.Black;
            this.Label99.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label99.Border.TopColor = System.Drawing.Color.Black;
            this.Label99.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label99.Height = 0.2F;
            this.Label99.HyperLink = null;
            this.Label99.Left = 0F;
            this.Label99.Name = "Label99";
            this.Label99.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label99.Text = "Expiration Date:";
            this.Label99.Top = 0.8791667F;
            this.Label99.Width = 0.938F;
            // 
            // txtExpirationDate
            // 
            this.txtExpirationDate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtExpirationDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtExpirationDate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtExpirationDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtExpirationDate.Border.RightColor = System.Drawing.Color.Black;
            this.txtExpirationDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtExpirationDate.Border.TopColor = System.Drawing.Color.Black;
            this.txtExpirationDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtExpirationDate.Height = 0.2F;
            this.txtExpirationDate.Left = 0.9375F;
            this.txtExpirationDate.Name = "txtExpirationDate";
            this.txtExpirationDate.Style = "font-size: 8.25pt; ";
            this.txtExpirationDate.Text = "txtExpirationDate";
            this.txtExpirationDate.Top = 0.875F;
            this.txtExpirationDate.Width = 1F;
            // 
            // Label100
            // 
            this.Label100.Border.BottomColor = System.Drawing.Color.Black;
            this.Label100.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label100.Border.LeftColor = System.Drawing.Color.Black;
            this.Label100.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label100.Border.RightColor = System.Drawing.Color.Black;
            this.Label100.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label100.Border.TopColor = System.Drawing.Color.Black;
            this.Label100.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label100.Height = 0.2F;
            this.Label100.HyperLink = null;
            this.Label100.Left = 0F;
            this.Label100.Name = "Label100";
            this.Label100.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label100.Text = "Entry Date:";
            this.Label100.Top = 1.129167F;
            this.Label100.Width = 0.9375F;
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
            this.txtEntryDate.Height = 0.2F;
            this.txtEntryDate.Left = 0.9375F;
            this.txtEntryDate.Name = "txtEntryDate";
            this.txtEntryDate.Style = "font-size: 8.25pt; ";
            this.txtEntryDate.Text = "txtEntryDate";
            this.txtEntryDate.Top = 1.125F;
            this.txtEntryDate.Width = 1F;
            // 
            // Label101
            // 
            this.Label101.Border.BottomColor = System.Drawing.Color.Black;
            this.Label101.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label101.Border.LeftColor = System.Drawing.Color.Black;
            this.Label101.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label101.Border.RightColor = System.Drawing.Color.Black;
            this.Label101.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label101.Border.TopColor = System.Drawing.Color.Black;
            this.Label101.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label101.Height = 0.2F;
            this.Label101.HyperLink = null;
            this.Label101.Left = 5F;
            this.Label101.Name = "Label101";
            this.Label101.Style = "text-align: right; font-weight: bold; font-size: 9pt; ";
            this.Label101.Text = "Premium:";
            this.Label101.Top = 1.375F;
            this.Label101.Width = 0.875F;
            // 
            // txtPremium
            // 
            this.txtPremium.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPremium.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPremium.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPremium.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPremium.Border.RightColor = System.Drawing.Color.Black;
            this.txtPremium.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPremium.Border.TopColor = System.Drawing.Color.Black;
            this.txtPremium.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPremium.Height = 0.2F;
            this.txtPremium.Left = 5.875F;
            this.txtPremium.Name = "txtPremium";
            this.txtPremium.Style = "text-align: right; font-size: 9pt; ";
            this.txtPremium.Text = "txtPremium";
            this.txtPremium.Top = 1.375F;
            this.txtPremium.Width = 0.9375F;
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
            this.Label102.HyperLink = null;
            this.Label102.Left = 5F;
            this.Label102.Name = "Label102";
            this.Label102.Style = "text-align: right; font-weight: bold; font-size: 9pt; ";
            this.Label102.Text = "Charge:";
            this.Label102.Top = 1.5625F;
            this.Label102.Width = 0.875F;
            // 
            // txtCharge
            // 
            this.txtCharge.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCharge.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCharge.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCharge.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCharge.Border.RightColor = System.Drawing.Color.Black;
            this.txtCharge.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCharge.Border.TopColor = System.Drawing.Color.Black;
            this.txtCharge.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCharge.Height = 0.2F;
            this.txtCharge.Left = 5.875F;
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.Style = "text-align: right; font-size: 9pt; ";
            this.txtCharge.Text = "txtCharge";
            this.txtCharge.Top = 1.5625F;
            this.txtCharge.Width = 0.9375F;
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
            this.txtTotalPremium.Height = 0.3125F;
            this.txtTotalPremium.Left = 5.875F;
            this.txtTotalPremium.Name = "txtTotalPremium";
            this.txtTotalPremium.Style = "text-align: right; font-weight: bold; font-size: 12pt; font-family: Microsoft San" +
                "s Serif; ";
            this.txtTotalPremium.Text = "$9,999.00";
            this.txtTotalPremium.Top = 1.75F;
            this.txtTotalPremium.Width = 0.9375F;
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
            this.Label103.Height = 0.3125F;
            this.Label103.HyperLink = null;
            this.Label103.Left = 4.4375F;
            this.Label103.Name = "Label103";
            this.Label103.Style = "text-align: right; font-weight: bold; font-size: 12pt; font-family: Microsoft San" +
                "s Serif; ";
            this.Label103.Text = "Total :";
            this.Label103.Top = 1.7625F;
            this.Label103.Width = 1.4375F;
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
            this.Label111.HyperLink = null;
            this.Label111.Left = 2.3125F;
            this.Label111.Name = "Label111";
            this.Label111.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label111.Text = "Collision:";
            this.Label111.Top = 0.3791668F;
            this.Label111.Width = 0.9375F;
            // 
            // txtCollision
            // 
            this.txtCollision.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCollision.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCollision.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCollision.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCollision.Border.RightColor = System.Drawing.Color.Black;
            this.txtCollision.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCollision.Border.TopColor = System.Drawing.Color.Black;
            this.txtCollision.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCollision.Height = 0.2F;
            this.txtCollision.Left = 3.25F;
            this.txtCollision.Name = "txtCollision";
            this.txtCollision.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtCollision.Text = "txtCollision";
            this.txtCollision.Top = 0.375F;
            this.txtCollision.Width = 1F;
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
            this.Label112.HyperLink = null;
            this.Label112.Left = 2.375F;
            this.Label112.Name = "Label112";
            this.Label112.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label112.Text = "Bodily Injury:";
            this.Label112.Top = 0.8791667F;
            this.Label112.Width = 0.875F;
            // 
            // txtBodilyInjury
            // 
            this.txtBodilyInjury.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBodilyInjury.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBodilyInjury.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBodilyInjury.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBodilyInjury.Border.RightColor = System.Drawing.Color.Black;
            this.txtBodilyInjury.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBodilyInjury.Border.TopColor = System.Drawing.Color.Black;
            this.txtBodilyInjury.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBodilyInjury.Height = 0.2F;
            this.txtBodilyInjury.Left = 3.25F;
            this.txtBodilyInjury.Name = "txtBodilyInjury";
            this.txtBodilyInjury.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtBodilyInjury.Text = "txtBodilyInjury";
            this.txtBodilyInjury.Top = 0.875F;
            this.txtBodilyInjury.Width = 1F;
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
            this.Label113.HyperLink = null;
            this.Label113.Left = 2.1875F;
            this.Label113.Name = "Label113";
            this.Label113.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label113.Text = "Property Damage:";
            this.Label113.Top = 1.129167F;
            this.Label113.Width = 1.0625F;
            // 
            // txtPropertyDmg
            // 
            this.txtPropertyDmg.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPropertyDmg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPropertyDmg.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPropertyDmg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPropertyDmg.Border.RightColor = System.Drawing.Color.Black;
            this.txtPropertyDmg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPropertyDmg.Border.TopColor = System.Drawing.Color.Black;
            this.txtPropertyDmg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPropertyDmg.Height = 0.2F;
            this.txtPropertyDmg.Left = 3.25F;
            this.txtPropertyDmg.Name = "txtPropertyDmg";
            this.txtPropertyDmg.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtPropertyDmg.Text = "txtPropertyDmg";
            this.txtPropertyDmg.Top = 1.125F;
            this.txtPropertyDmg.Width = 1F;
            // 
            // txtComprehensive
            // 
            this.txtComprehensive.Border.BottomColor = System.Drawing.Color.Black;
            this.txtComprehensive.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtComprehensive.Border.LeftColor = System.Drawing.Color.Black;
            this.txtComprehensive.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtComprehensive.Border.RightColor = System.Drawing.Color.Black;
            this.txtComprehensive.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtComprehensive.Border.TopColor = System.Drawing.Color.Black;
            this.txtComprehensive.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtComprehensive.Height = 0.2F;
            this.txtComprehensive.Left = 3.25F;
            this.txtComprehensive.Name = "txtComprehensive";
            this.txtComprehensive.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtComprehensive.Text = "txtComprehensive";
            this.txtComprehensive.Top = 0.625F;
            this.txtComprehensive.Width = 1F;
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
            this.Label114.HyperLink = null;
            this.Label114.Left = 2.3125F;
            this.Label114.Name = "Label114";
            this.Label114.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label114.Text = "Comprehensive:";
            this.Label114.Top = 0.625F;
            this.Label114.Width = 0.9375F;
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
            this.Label115.HyperLink = null;
            this.Label115.Left = 2.25F;
            this.Label115.Name = "Label115";
            this.Label115.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label115.Text = "Lease Loan Gap:";
            this.Label115.Top = 1.379167F;
            this.Label115.Width = 1F;
            // 
            // txtLeaseLoanGap
            // 
            this.txtLeaseLoanGap.Border.BottomColor = System.Drawing.Color.Black;
            this.txtLeaseLoanGap.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLeaseLoanGap.Border.LeftColor = System.Drawing.Color.Black;
            this.txtLeaseLoanGap.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLeaseLoanGap.Border.RightColor = System.Drawing.Color.Black;
            this.txtLeaseLoanGap.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLeaseLoanGap.Border.TopColor = System.Drawing.Color.Black;
            this.txtLeaseLoanGap.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLeaseLoanGap.Height = 0.2F;
            this.txtLeaseLoanGap.Left = 3.25F;
            this.txtLeaseLoanGap.Name = "txtLeaseLoanGap";
            this.txtLeaseLoanGap.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtLeaseLoanGap.Text = "txtLeaseLoanGap";
            this.txtLeaseLoanGap.Top = 1.375F;
            this.txtLeaseLoanGap.Width = 1F;
            // 
            // txtPAR
            // 
            this.txtPAR.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPAR.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPAR.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPAR.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPAR.Border.RightColor = System.Drawing.Color.Black;
            this.txtPAR.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPAR.Border.TopColor = System.Drawing.Color.Black;
            this.txtPAR.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPAR.Height = 0.2F;
            this.txtPAR.Left = 5.1875F;
            this.txtPAR.Name = "txtPAR";
            this.txtPAR.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtPAR.Text = "txtPAR";
            this.txtPAR.Top = 0.375F;
            this.txtPAR.Width = 1F;
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
            this.Label116.HyperLink = null;
            this.Label116.Left = 4.3125F;
            this.Label116.Name = "Label116";
            this.Label116.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label116.Text = "PAR:";
            this.Label116.Top = 0.3791668F;
            this.Label116.Width = 0.875F;
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
            this.Label117.HyperLink = null;
            this.Label117.Left = 2.375F;
            this.Label117.Name = "Label117";
            this.Label117.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label117.Text = "Assistance:";
            this.Label117.Top = 1.879167F;
            this.Label117.Width = 0.875F;
            // 
            // txtAssist
            // 
            this.txtAssist.Border.BottomColor = System.Drawing.Color.Black;
            this.txtAssist.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAssist.Border.LeftColor = System.Drawing.Color.Black;
            this.txtAssist.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAssist.Border.RightColor = System.Drawing.Color.Black;
            this.txtAssist.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAssist.Border.TopColor = System.Drawing.Color.Black;
            this.txtAssist.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAssist.Height = 0.2F;
            this.txtAssist.Left = 3.25F;
            this.txtAssist.Name = "txtAssist";
            this.txtAssist.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtAssist.Text = "txtAssist";
            this.txtAssist.Top = 1.875F;
            this.txtAssist.Width = 1F;
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
            this.Label118.HyperLink = null;
            this.Label118.Left = 2.375F;
            this.Label118.Name = "Label118";
            this.Label118.Style = "color: Black; font-weight: bold; ";
            this.Label118.Text = "Premium Breakdown";
            this.Label118.Top = 0.0625F;
            this.Label118.Width = 1.875F;
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
            this.Label121.HyperLink = null;
            this.Label121.Left = 4.3125F;
            this.Label121.Name = "Label121";
            this.Label121.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label121.Text = "Seatbelt:";
            this.Label121.Top = 0.625F;
            this.Label121.Width = 0.875F;
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
            this.Label122.HyperLink = null;
            this.Label122.Left = 4.3125F;
            this.Label122.Name = "Label122";
            this.Label122.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label122.Text = "Rental:";
            this.Label122.Top = 0.8791667F;
            this.Label122.Width = 0.875F;
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
            this.Label123.HyperLink = null;
            this.Label123.Left = 2.375F;
            this.Label123.Name = "Label123";
            this.Label123.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label123.Text = "Towing:";
            this.Label123.Top = 1.629167F;
            this.Label123.Width = 0.875F;
            // 
            // txtTowing
            // 
            this.txtTowing.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTowing.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTowing.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTowing.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTowing.Border.RightColor = System.Drawing.Color.Black;
            this.txtTowing.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTowing.Border.TopColor = System.Drawing.Color.Black;
            this.txtTowing.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTowing.Height = 0.2F;
            this.txtTowing.Left = 3.25F;
            this.txtTowing.Name = "txtTowing";
            this.txtTowing.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtTowing.Text = "txtTowing";
            this.txtTowing.Top = 1.625F;
            this.txtTowing.Width = 1F;
            // 
            // TxtSeatBelt
            // 
            this.TxtSeatBelt.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtSeatBelt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSeatBelt.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtSeatBelt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSeatBelt.Border.RightColor = System.Drawing.Color.Black;
            this.TxtSeatBelt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSeatBelt.Border.TopColor = System.Drawing.Color.Black;
            this.TxtSeatBelt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSeatBelt.Height = 0.2F;
            this.TxtSeatBelt.Left = 5.1875F;
            this.TxtSeatBelt.Name = "TxtSeatBelt";
            this.TxtSeatBelt.Style = "text-align: right; font-size: 8.25pt; ";
            this.TxtSeatBelt.Text = "TxtSeatBelt";
            this.TxtSeatBelt.Top = 0.625F;
            this.TxtSeatBelt.Width = 1F;
            // 
            // TxtRental
            // 
            this.TxtRental.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtRental.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtRental.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtRental.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtRental.Border.RightColor = System.Drawing.Color.Black;
            this.TxtRental.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtRental.Border.TopColor = System.Drawing.Color.Black;
            this.TxtRental.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtRental.Height = 0.2F;
            this.TxtRental.Left = 5.1875F;
            this.TxtRental.Name = "TxtRental";
            this.TxtRental.Style = "text-align: right; font-size: 8.25pt; ";
            this.TxtRental.Text = "TxtRental";
            this.TxtRental.Top = 0.875F;
            this.TxtRental.Width = 1F;
            // 
            // Line1
            // 
            this.Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.RightColor = System.Drawing.Color.Black;
            this.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.TopColor = System.Drawing.Color.Black;
            this.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Height = 0F;
            this.Line1.Left = 0F;
            this.Line1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0.3125F;
            this.Line1.Width = 6.875F;
            this.Line1.X1 = 6.875F;
            this.Line1.X2 = 0F;
            this.Line1.Y1 = 0.3125F;
            this.Line1.Y2 = 0.3125F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Height = 0.2909722F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // rptQuoteAuto
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.7F;
            this.PageSettings.Margins.Left = 0.8F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 6.991667F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ghAutoQuote);
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
            this.ReportStart += new System.EventHandler(this.rptQuoteAuto_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label97)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreparedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label124)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label87)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label98)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTerm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label99)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpirationDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCharge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label103)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCollision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label112)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBodilyInjury)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label113)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPropertyDmg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComprehensive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label114)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label115)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeaseLoanGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label116)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label117)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAssist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label118)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label121)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label122)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label123)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTowing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSeatBelt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRental)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
		#endregion

        private void Detail_Format(object sender, EventArgs e)
        {             
            rptQuoteAutoCover rptAC = new rptQuoteAutoCover(this._autoCovers, _policy);
            this.subCovers.Report = rptAC;
        }

        private void FillFields(EPolicy.TaskControl.QuoteAuto AutoQuote,
    string UserName)
        {
            TaskControl tc = new TaskControl();


            EPolicy.Quotes.AutoDriver mainProspectDriver =
                (EPolicy.Quotes.AutoDriver)AutoQuote.Drivers[0];
            DateTime birthDate =
                DateTime.Parse(mainProspectDriver.BirthDate.Trim());
            decimal charges = 0.0m;
            decimal totalPremium = 0.0m;

            this.lblDate.Text = DateTime.Today.ToShortDateString();
            this.lblTime.Text = DateTime.Now.ToShortTimeString();
            //this.txtPageNumber.Text = ;
            this.txtQuotation.Text = AutoQuote.TaskControlID.ToString();
            this.txtPreparedBy.Text = AutoQuote.EnteredBy.Trim();	//UserName.Trim();

            /*this.txtName.Text = AutoQuote.Prospect.FirstName.Trim() +
                " " + AutoQuote.Prospect.LastName1.Trim() + 
                " " + AutoQuote.Prospect.LastName2.Trim();
            this.txtBirthdate.Text = birthDate.ToShortDateString();
            this.txtAge.Text = 
                Customer.Customer.GetAge(birthDate).ToString();
            this.txtMaritalStatus.Text = 
                LookupTables.GetDescription("MaritalStatus",
                mainProspectDriver.MaritalStatus.ToString());
            this.txtGender.Text = 
                LookupTables.GetDescription("Gender",
                mainProspectDriver.Gender.ToString());*/

            this.txtEffectiveDate.Text =
                AutoQuote.EffectiveDate.Trim();
            this.txtTerm.Text = AutoQuote.Term.ToString() + " months";
            this.txtExpirationDate.Text = AutoQuote.ExpirationDate.Trim();
            this.txtEntryDate.Text = AutoQuote.EntryDate.ToShortDateString();

            this.txtCollision.Text = String.Format("{0:c}",
                this.GetPremiumTotal(AutoQuote,
                (int)EPolicy.Quotes.Enumerators.Premiums.Collision));
            this.txtComprehensive.Text =
                String.Format("{0:c}", this.GetPremiumTotal(AutoQuote,
                (int)EPolicy.Quotes.Enumerators.Premiums.Comprehensive));
            this.txtBodilyInjury.Text = String.Format("{0:c}",
                this.GetPremiumTotal(AutoQuote,
                (int)EPolicy.Quotes.Enumerators.Premiums.BodilyInjury));
            this.txtPropertyDmg.Text = String.Format("{0:c}",
                this.GetPremiumTotal(AutoQuote,
                (int)EPolicy.Quotes.Enumerators.Premiums.PropertyDamage));
            this.txtLeaseLoanGap.Text = String.Format("{0:c}",
                this.GetPremiumTotal(AutoQuote,
                (int)EPolicy.Quotes.Enumerators.Premiums.LeaseLoanGap));
            this.txtPAR.Text = String.Format("{0:c}",
                this.GetPremiumTotal(AutoQuote,
                (int)
                EPolicy.Quotes.Enumerators.Premiums.PersonalAccidentRider));
            this.txtAssist.Text = String.Format("{0:c}",
                this.GetPremiumTotal(AutoQuote,
                (int)EPolicy.Quotes.Enumerators.Premiums.Assistance));

            this.txtTowing.Text = String.Format("{0:c}",
                this.GetPremiumTotal(AutoQuote,
                (int)EPolicy.Quotes.Enumerators.Premiums.Towing));
            this.TxtSeatBelt.Text = String.Format("{0:c}",
                this.GetPremiumTotal(AutoQuote,
                (int)EPolicy.Quotes.Enumerators.Premiums.SeatBelt));
            this.TxtRental.Text = String.Format("{0:c}",
                this.GetPremiumTotal(AutoQuote,
                (int)EPolicy.Quotes.Enumerators.Premiums.VehicleRental));

            this.txtLeaseLoanGap.Text = String.Format("{0:c}",
                this.GetPremiumTotal(AutoQuote,
                (int)EPolicy.Quotes.Enumerators.Premiums.LeaseLoanGap));

            this.txtPremium.Text =
                String.Format("{0:c}",
                this.GetPremium(AutoQuote));

            charges = this.GetCharges(AutoQuote);
            this.txtCharge.Text = String.Format("{0:c}",
                charges);

            totalPremium = charges + AutoQuote.TotalPremium;

            this.txtTotalPremium.Text = String.Format("{0:c}",
                totalPremium);

            //			this.txtTotalToPay.Text = String.Format("{0:c}", 
            //				totalPremium);
        }

        private decimal GetPremiumTotal(
            EPolicy.TaskControl.QuoteAuto AutoQuote, int Type)
        {
            decimal collTotal = 0.0m;
            EPolicy.Quotes.AutoCover cover = null;
            System.Collections.ArrayList breakdownList = null;
            EPolicy.Quotes.CoverBreakdown breakdown = null;


            for (int i = 0; i < AutoQuote.AutoCovers.Count; i++)
            {
                cover = (EPolicy.Quotes.AutoCover)AutoQuote.AutoCovers[i];
                breakdownList = cover.Breakdown;

                for (int j = 0; j < breakdownList.Count; j++)
                {
                    breakdown = (EPolicy.Quotes.CoverBreakdown)breakdownList[j];
                    if (breakdown.Type == Type)
                    {
                        for (int k = 0; k < breakdown.Breakdown.Count; k++)
                        {
                            collTotal += Math.Round(decimal.Parse(breakdown.Breakdown.GetByIndex(k).ToString()), 0);
                        }
                    }
                }
            }
            return collTotal;
        }

        private decimal GetPremium(EPolicy.TaskControl.QuoteAuto AutoQuote)
        {
            decimal premium = 0.0m;
            EPolicy.Quotes.AutoCover cover = null;

            for (int i = 0; i < AutoQuote.AutoCovers.Count; i++)
            {
                cover = (EPolicy.Quotes.AutoCover)AutoQuote.AutoCovers[i];
                premium += cover.TotalAmount;
            }
            return premium;
        }

        private decimal GetCharges(EPolicy.TaskControl.QuoteAuto AutoQuote)
        {
            decimal charges = 0.0m;
            EPolicy.Quotes.AutoCover cover = null;

            for (int i = 0; i < AutoQuote.AutoCovers.Count; i++)
            {
                cover = (EPolicy.Quotes.AutoCover)AutoQuote.AutoCovers[i];
                charges += cover.Charge;
            }
            return charges;
        }

        private void rptQuoteAuto_ReportStart(object sender, EventArgs e)
        {

        }

        private void PageFooter_Format(object sender, EventArgs e)
        {
            if (_policy.InsuranceCompany != "000")
            {
                //Insurance Company
                EPolicy.LookupTables.InsuranceCompany ins = new InsuranceCompany();
                ins = ins.GetInsuranceCompany(_policy.InsuranceCompany);
            }
            else
            {
                //this.LblQuoteBy.Visible = false;
            }

            //string Version = ConfigurationSettings.AppSettings["Version"];
            //this.Label119.Text = Version.Trim();
        }
	}
}
