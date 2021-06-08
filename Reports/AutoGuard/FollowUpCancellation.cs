using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports
{
	public class FollowUpCancellation : DataDynamics.ActiveReports.ActiveReport3
	{
		string _ToDate;
		string _ReportType;
		bool   _Summary = false;

		public FollowUpCancellation(string ToDate, string ReportType,bool Summary)
		{
			_ToDate = ToDate;
			_ReportType = ReportType;
			_Summary  =  Summary;


			InitializeComponent();
		}

		private void FollowUpCancellation_ReportStart(object sender, System.EventArgs eArgs)
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

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
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
		private DataDynamics.ActiveReports.Label Label111 = null;
		private DataDynamics.ActiveReports.Label Label112 = null;
		private DataDynamics.ActiveReports.Label Label133 = null;
		private DataDynamics.ActiveReports.Label Label134 = null;
		private DataDynamics.ActiveReports.Label Label135 = null;
		private DataDynamics.ActiveReports.Label Label136 = null;
		private DataDynamics.ActiveReports.Label Label75 = null;
		private DataDynamics.ActiveReports.Label Label77 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox TxtPolicyNo = null;
		private DataDynamics.ActiveReports.TextBox txtCustNo = null;
		private DataDynamics.ActiveReports.TextBox txtInsuredName = null;
		private DataDynamics.ActiveReports.TextBox txtEffDate = null;
		private DataDynamics.ActiveReports.TextBox txtExpDate = null;
		private DataDynamics.ActiveReports.TextBox txtNoticeDt = null;
		private DataDynamics.ActiveReports.TextBox txtCancDate = null;
		private DataDynamics.ActiveReports.TextBox txtAmountDue = null;
		private DataDynamics.ActiveReports.TextBox TextBox46 = null;
		private DataDynamics.ActiveReports.TextBox txtAgency = null;
		private DataDynamics.ActiveReports.TextBox txtAgent = null;
		private DataDynamics.ActiveReports.TextBox txtDealer = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		private DataDynamics.ActiveReports.Line Line140 = null;
		private DataDynamics.ActiveReports.Label Label139 = null;
		private DataDynamics.ActiveReports.TextBox TextBox27 = null;
		private DataDynamics.ActiveReports.TextBox TextBox26 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FollowUpCancellation));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.TxtPolicyNo = new DataDynamics.ActiveReports.TextBox();
            this.txtCustNo = new DataDynamics.ActiveReports.TextBox();
            this.txtInsuredName = new DataDynamics.ActiveReports.TextBox();
            this.txtEffDate = new DataDynamics.ActiveReports.TextBox();
            this.txtExpDate = new DataDynamics.ActiveReports.TextBox();
            this.txtNoticeDt = new DataDynamics.ActiveReports.TextBox();
            this.txtCancDate = new DataDynamics.ActiveReports.TextBox();
            this.txtAmountDue = new DataDynamics.ActiveReports.TextBox();
            this.TextBox46 = new DataDynamics.ActiveReports.TextBox();
            this.txtAgency = new DataDynamics.ActiveReports.TextBox();
            this.txtAgent = new DataDynamics.ActiveReports.TextBox();
            this.txtDealer = new DataDynamics.ActiveReports.TextBox();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.Line140 = new DataDynamics.ActiveReports.Line();
            this.Label139 = new DataDynamics.ActiveReports.Label();
            this.TextBox27 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox26 = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
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
            this.Label111 = new DataDynamics.ActiveReports.Label();
            this.Label112 = new DataDynamics.ActiveReports.Label();
            this.Label133 = new DataDynamics.ActiveReports.Label();
            this.Label134 = new DataDynamics.ActiveReports.Label();
            this.Label135 = new DataDynamics.ActiveReports.Label();
            this.Label136 = new DataDynamics.ActiveReports.Label();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPolicyNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsuredName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoticeDt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCancDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountDue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDealer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label139)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox26)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.Label111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label112)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label136)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TxtPolicyNo,
            this.txtCustNo,
            this.txtInsuredName,
            this.txtEffDate,
            this.txtExpDate,
            this.txtNoticeDt,
            this.txtCancDate,
            this.txtAmountDue,
            this.TextBox46,
            this.txtAgency,
            this.txtAgent,
            this.txtDealer});
            this.Detail.Height = 0.2076389F;
            this.Detail.Name = "Detail";
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
            this.TxtPolicyNo.Text = null;
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
            this.txtCustNo.Left = 1.458333F;
            this.txtCustNo.Name = "txtCustNo";
            this.txtCustNo.Style = "text-align: center; font-size: 7pt; ";
            this.txtCustNo.Text = null;
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
            this.txtInsuredName.Left = 2.322917F;
            this.txtInsuredName.Name = "txtInsuredName";
            this.txtInsuredName.Style = "text-align: left; font-size: 7pt; ";
            this.txtInsuredName.Text = null;
            this.txtInsuredName.Top = 0F;
            this.txtInsuredName.Width = 1.614583F;
            // 
            // txtEffDate
            // 
            this.txtEffDate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEffDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEffDate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEffDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEffDate.Border.RightColor = System.Drawing.Color.Black;
            this.txtEffDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEffDate.Border.TopColor = System.Drawing.Color.Black;
            this.txtEffDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEffDate.DataField = "EffectiveDate";
            this.txtEffDate.Height = 0.1875F;
            this.txtEffDate.Left = 4.0625F;
            this.txtEffDate.Name = "txtEffDate";
            this.txtEffDate.OutputFormat = resources.GetString("txtEffDate.OutputFormat");
            this.txtEffDate.Style = "text-align: left; font-size: 7pt; ";
            this.txtEffDate.Text = null;
            this.txtEffDate.Top = 0F;
            this.txtEffDate.Width = 0.6875F;
            // 
            // txtExpDate
            // 
            this.txtExpDate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtExpDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtExpDate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtExpDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtExpDate.Border.RightColor = System.Drawing.Color.Black;
            this.txtExpDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtExpDate.Border.TopColor = System.Drawing.Color.Black;
            this.txtExpDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtExpDate.DataField = "ExpirationDate";
            this.txtExpDate.Height = 0.1875F;
            this.txtExpDate.Left = 4.760417F;
            this.txtExpDate.Name = "txtExpDate";
            this.txtExpDate.OutputFormat = resources.GetString("txtExpDate.OutputFormat");
            this.txtExpDate.Style = "text-align: left; font-size: 7pt; ";
            this.txtExpDate.Text = null;
            this.txtExpDate.Top = 0F;
            this.txtExpDate.Width = 0.625F;
            // 
            // txtNoticeDt
            // 
            this.txtNoticeDt.Border.BottomColor = System.Drawing.Color.Black;
            this.txtNoticeDt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNoticeDt.Border.LeftColor = System.Drawing.Color.Black;
            this.txtNoticeDt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNoticeDt.Border.RightColor = System.Drawing.Color.Black;
            this.txtNoticeDt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNoticeDt.Border.TopColor = System.Drawing.Color.Black;
            this.txtNoticeDt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNoticeDt.DataField = "can_follow";
            this.txtNoticeDt.Height = 0.1875F;
            this.txtNoticeDt.Left = 5.447917F;
            this.txtNoticeDt.Name = "txtNoticeDt";
            this.txtNoticeDt.OutputFormat = resources.GetString("txtNoticeDt.OutputFormat");
            this.txtNoticeDt.Style = "text-align: left; font-size: 7pt; ";
            this.txtNoticeDt.Text = null;
            this.txtNoticeDt.Top = 0F;
            this.txtNoticeDt.Width = 0.5625F;
            // 
            // txtCancDate
            // 
            this.txtCancDate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCancDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCancDate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCancDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCancDate.Border.RightColor = System.Drawing.Color.Black;
            this.txtCancDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCancDate.Border.TopColor = System.Drawing.Color.Black;
            this.txtCancDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCancDate.DataField = "EffecDate";
            this.txtCancDate.Height = 0.1875F;
            this.txtCancDate.Left = 6.135417F;
            this.txtCancDate.Name = "txtCancDate";
            this.txtCancDate.OutputFormat = resources.GetString("txtCancDate.OutputFormat");
            this.txtCancDate.Style = "text-align: center; font-size: 7pt; ";
            this.txtCancDate.Text = null;
            this.txtCancDate.Top = 0F;
            this.txtCancDate.Width = 0.625F;
            // 
            // txtAmountDue
            // 
            this.txtAmountDue.Border.BottomColor = System.Drawing.Color.Black;
            this.txtAmountDue.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAmountDue.Border.LeftColor = System.Drawing.Color.Black;
            this.txtAmountDue.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAmountDue.Border.RightColor = System.Drawing.Color.Black;
            this.txtAmountDue.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAmountDue.Border.TopColor = System.Drawing.Color.Black;
            this.txtAmountDue.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAmountDue.DataField = "DueAmount";
            this.txtAmountDue.Height = 0.1875F;
            this.txtAmountDue.Left = 6.885417F;
            this.txtAmountDue.Name = "txtAmountDue";
            this.txtAmountDue.OutputFormat = resources.GetString("txtAmountDue.OutputFormat");
            this.txtAmountDue.Style = "text-align: right; font-size: 7pt; ";
            this.txtAmountDue.Text = null;
            this.txtAmountDue.Top = 0F;
            this.txtAmountDue.Width = 0.75F;
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
            this.TextBox46.Left = 7.75F;
            this.TextBox46.Name = "TextBox46";
            this.TextBox46.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox46.Text = null;
            this.TextBox46.Top = 0F;
            this.TextBox46.Width = 0.3125F;
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
            this.txtAgency.Left = 8.3125F;
            this.txtAgency.Name = "txtAgency";
            this.txtAgency.Style = "text-align: center; font-size: 7pt; ";
            this.txtAgency.Text = null;
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
            this.txtAgent.Left = 8.8125F;
            this.txtAgent.Name = "txtAgent";
            this.txtAgent.Style = "text-align: center; font-size: 7pt; ";
            this.txtAgent.Text = null;
            this.txtAgent.Top = 0F;
            this.txtAgent.Width = 0.3125F;
            // 
            // txtDealer
            // 
            this.txtDealer.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDealer.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDealer.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDealer.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDealer.Border.RightColor = System.Drawing.Color.Black;
            this.txtDealer.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDealer.Border.TopColor = System.Drawing.Color.Black;
            this.txtDealer.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDealer.DataField = "CompanyDealer";
            this.txtDealer.Height = 0.1875F;
            this.txtDealer.Left = 9.25F;
            this.txtDealer.Name = "txtDealer";
            this.txtDealer.Style = "text-align: center; font-size: 7pt; ";
            this.txtDealer.Text = null;
            this.txtDealer.Top = 0F;
            this.txtDealer.Width = 0.3125F;
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
            this.TextBox26});
            this.ReportFooter.Height = 0.2076389F;
            this.ReportFooter.Name = "ReportFooter";
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
            this.Line140.Width = 9.3125F;
            this.Line140.X1 = 0.375F;
            this.Line140.X2 = 9.6875F;
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
            this.TextBox27.DataField = "PolicyNo";
            this.TextBox27.Height = 0.1875F;
            this.TextBox27.Left = 2.125F;
            this.TextBox27.Name = "TextBox27";
            this.TextBox27.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.TextBox27.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox27.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox27.Text = null;
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
            this.TextBox26.DataField = "DueAmount";
            this.TextBox26.Height = 0.1875F;
            this.TextBox26.Left = 6.885417F;
            this.TextBox26.MultiLine = false;
            this.TextBox26.Name = "TextBox26";
            this.TextBox26.OutputFormat = resources.GetString("TextBox26.OutputFormat");
            this.TextBox26.Style = "text-align: right; font-weight: bold; font-size: 6.75pt; vertical-align: middle; " +
                "";
            this.TextBox26.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox26.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox26.Text = null;
            this.TextBox26.Top = 0F;
            this.TextBox26.Width = 0.75F;
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
            this.Label111,
            this.Label112,
            this.Label133,
            this.Label134,
            this.Label135,
            this.Label136,
            this.Label75,
            this.Label77});
            this.PageHeader.Height = 1.375F;
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
            this.TextBox17.Text = null;
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
            this.lblCriterias.Text = "Mechanical Breakdown - Follow Up Cancellation As Of:";
            this.lblCriterias.Top = 0.6875F;
            this.lblCriterias.Width = 5.125F;
            // 
            // Shape3
            // 
            this.Shape3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
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
            this.Shape3.Width = 9.5F;
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
            this.Label104.Width = 0.625F;
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
            this.Label105.Left = 4F;
            this.Label105.MultiLine = false;
            this.Label105.Name = "Label105";
            this.Label105.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.Label105.Text = "EFF.DATE";
            this.Label105.Top = 1.125F;
            this.Label105.Width = 0.6875F;
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
            this.Label107.Left = 2.25F;
            this.Label107.MultiLine = false;
            this.Label107.Name = "Label107";
            this.Label107.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label107.Text = "INSURED NAME";
            this.Label107.Top = 1.125F;
            this.Label107.Width = 1.351563F;
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
            this.Label108.Left = 5.375F;
            this.Label108.MultiLine = false;
            this.Label108.Name = "Label108";
            this.Label108.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label108.Text = "NOTICE DT.";
            this.Label108.Top = 1.125F;
            this.Label108.Width = 0.6875F;
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
            this.Label109.Left = 6.0625F;
            this.Label109.MultiLine = false;
            this.Label109.Name = "Label109";
            this.Label109.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label109.Text = "CANC.DATE";
            this.Label109.Top = 1.125F;
            this.Label109.Width = 0.78125F;
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
            this.Label111.Left = 6.875F;
            this.Label111.MultiLine = false;
            this.Label111.Name = "Label111";
            this.Label111.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label111.Text = "AMOUNT DUE";
            this.Label111.Top = 1.125F;
            this.Label111.Width = 0.84375F;
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
            this.Label112.Left = 7.75F;
            this.Label112.MultiLine = false;
            this.Label112.Name = "Label112";
            this.Label112.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label112.Text = "BANK";
            this.Label112.Top = 1.125F;
            this.Label112.Width = 0.40625F;
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
            this.Label133.Left = 8.1875F;
            this.Label133.MultiLine = false;
            this.Label133.Name = "Label133";
            this.Label133.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label133.Text = "AGENCY";
            this.Label133.Top = 1.125F;
            this.Label133.Width = 0.53125F;
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
            this.Label134.Left = 4.6875F;
            this.Label134.MultiLine = false;
            this.Label134.Name = "Label134";
            this.Label134.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.Label134.Text = "EXP.DATE";
            this.Label134.Top = 1.125F;
            this.Label134.Width = 0.6875F;
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
            this.Label135.Height = 0.2F;
            this.Label135.HyperLink = "";
            this.Label135.Left = 8.6875F;
            this.Label135.MultiLine = false;
            this.Label135.Name = "Label135";
            this.Label135.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label135.Text = "AGENT";
            this.Label135.Top = 1.125F;
            this.Label135.Width = 0.53125F;
            // 
            // Label136
            // 
            this.Label136.Border.BottomColor = System.Drawing.Color.Black;
            this.Label136.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label136.Border.LeftColor = System.Drawing.Color.Black;
            this.Label136.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label136.Border.RightColor = System.Drawing.Color.Black;
            this.Label136.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label136.Border.TopColor = System.Drawing.Color.Black;
            this.Label136.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label136.Height = 0.2F;
            this.Label136.HyperLink = "";
            this.Label136.Left = 9.1875F;
            this.Label136.MultiLine = false;
            this.Label136.Name = "Label136";
            this.Label136.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label136.Text = "DEALER";
            this.Label136.Top = 1.125F;
            this.Label136.Width = 0.53125F;
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
            this.Label75.Text = "PUERTO RICO MEDICAL DEFENSE INSURANCE COMPANY";
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
            this.Label77.Left = 2.3125F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-align: center; font-weight: bold; font-size: 6pt; font-family: Times New Rom" +
                "an; ";
            this.Label77.Text = "";
            this.Label77.Top = 0.375F;
            this.Label77.Width = 5.125F;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            // 
            // FollowUpCancellation
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.2F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.1F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 9.875F;
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
            this.ReportStart += new System.EventHandler(this.FollowUpCancellation_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.TxtPolicyNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsuredName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoticeDt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCancDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountDue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDealer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label139)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox26)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.Label111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label112)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label136)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
