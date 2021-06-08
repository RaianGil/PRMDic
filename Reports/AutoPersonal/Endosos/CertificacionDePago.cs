using System;
using System.Data;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using DataDynamics;
using System.Drawing;
using EPolicy.TaskControl;
using EPolicy.Quotes;
using EPolicy.Customer;
using EPolicy.LookupTables;

namespace EPolicy2.Reports
{
	public class CertificacionDePago : DataDynamics.ActiveReports.ActiveReport3
	{
		//private int     CountDataIndex;
		//private int     index;
		private  PaymentCertificationLetter _taskcontrol ;


		public CertificacionDePago(PaymentCertificationLetter taskcontrol)//, string copyValue)
		{
			_taskcontrol =  taskcontrol;			

			InitializeComponent();
		}

		private void CertificacionDePago_ReportStart(object sender, System.EventArgs eArgs)
		{
			TxtEffectiveDate.Text  = _taskcontrol.EffectiveDate.Trim();
			TxtPolicyNo.Text       = _taskcontrol.PolicyType+" "+_taskcontrol.PolicyNo;
			TxtCustID.Text		   = _taskcontrol.CustomerNo;
			TxtEffectiveDate.Text  = _taskcontrol.EffectiveDate;
			TxtExpirationDate.Text = _taskcontrol.ExpirationDate;
			TxtMakeBy.Text         = _taskcontrol.EnteredBy;

			//Customer
			TxtCustomerName.Text = _taskcontrol.FirstName.Trim() +" "+
				_taskcontrol.LastName1.Trim()+ " "+_taskcontrol.LastName2.Trim();
			
			DateTime date   = DateTime.Now;
			TxtDate.Text    = date.ToShortDateString().Trim();

			decimal totprem = _taskcontrol.TotalPremium;
			TxtPrima.Text   = totprem.ToString("$#,##0.00").Trim();

			//	Bank
			EPolicy.LookupTables.Bank bank = new Bank();
			bank = bank.GetBank(_taskcontrol.Bank);
			//bank = bank.GetBank(_policy.Bank);

			TxtBankName.Text = bank.BankDesc.Trim().ToUpper();						
		
			if (bank.Address1 != "")
			{								
				TxtBankAddr1.Text = bank.Address1.Trim().ToUpper();	
				if(bank.Address2.Trim().ToUpper() == "")
				{
					TxtBankAddr2.Text = bank.City.Trim().ToUpper()+" "+
						bank.State.Trim().ToUpper()+" "+
						bank.ZipCode.Trim().ToUpper();
					TxtBankCity.Text = "";
				}
				else
				{
					TxtBankAddr2.Text = bank.Address2.Trim().ToUpper();
					TxtBankCity.Text  = bank.City.Trim().ToUpper()+" "+
						bank.State.Trim().ToUpper()+" "+
						bank.ZipCode.Trim().ToUpper();
				}
			}

		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.TextBox TxtDate = null;
		private DataDynamics.ActiveReports.TextBox TxtBankName = null;
		private DataDynamics.ActiveReports.TextBox TxtBankAddr1 = null;
		private DataDynamics.ActiveReports.TextBox TxtBankAddr2 = null;
		private DataDynamics.ActiveReports.TextBox TxtBankCity = null;
		private DataDynamics.ActiveReports.TextBox TextBox12 = null;
		private DataDynamics.ActiveReports.TextBox TextBox13 = null;
		private DataDynamics.ActiveReports.TextBox TextBox14 = null;
		private DataDynamics.ActiveReports.TextBox TxtPolicyNo = null;
		private DataDynamics.ActiveReports.TextBox TextBox16 = null;
		private DataDynamics.ActiveReports.TextBox TxtCustID = null;
		private DataDynamics.ActiveReports.TextBox TextBox18 = null;
		private DataDynamics.ActiveReports.TextBox TextBox19 = null;
		private DataDynamics.ActiveReports.TextBox TxtEffectiveDate = null;
		private DataDynamics.ActiveReports.TextBox TextBox21 = null;
		private DataDynamics.ActiveReports.TextBox TxtExpirationDate = null;
		private DataDynamics.ActiveReports.TextBox TextBox22 = null;
		private DataDynamics.ActiveReports.TextBox TextBox23 = null;
		private DataDynamics.ActiveReports.TextBox TextBox24 = null;
		private DataDynamics.ActiveReports.TextBox TextBox25 = null;
		private DataDynamics.ActiveReports.TextBox TextBox4 = null;
		private DataDynamics.ActiveReports.TextBox TextBox5 = null;
		private DataDynamics.ActiveReports.TextBox TxtCustomerName = null;
		private DataDynamics.ActiveReports.TextBox TextBox28 = null;
		private DataDynamics.ActiveReports.TextBox TextBox29 = null;
		private DataDynamics.ActiveReports.TextBox TxtPrima = null;
		private DataDynamics.ActiveReports.TextBox TextBox1 = null;
		private DataDynamics.ActiveReports.Label Label75 = null;
		private DataDynamics.ActiveReports.Label Label77 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.TextBox TextBox26 = null;
		private DataDynamics.ActiveReports.TextBox TextBox27 = null;
		private DataDynamics.ActiveReports.TextBox TxtMakeBy = null;
		private DataDynamics.ActiveReports.TextBox TextBox30 = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CertificacionDePago));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.TxtDate = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankName = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankAddr1 = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankAddr2 = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankCity = new DataDynamics.ActiveReports.TextBox();
            this.TextBox12 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox13 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox14 = new DataDynamics.ActiveReports.TextBox();
            this.TxtPolicyNo = new DataDynamics.ActiveReports.TextBox();
            this.TextBox16 = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustID = new DataDynamics.ActiveReports.TextBox();
            this.TextBox18 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox19 = new DataDynamics.ActiveReports.TextBox();
            this.TxtEffectiveDate = new DataDynamics.ActiveReports.TextBox();
            this.TextBox21 = new DataDynamics.ActiveReports.TextBox();
            this.TxtExpirationDate = new DataDynamics.ActiveReports.TextBox();
            this.TextBox22 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox23 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox24 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox25 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox4 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox5 = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerName = new DataDynamics.ActiveReports.TextBox();
            this.TextBox28 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox29 = new DataDynamics.ActiveReports.TextBox();
            this.TxtPrima = new DataDynamics.ActiveReports.TextBox();
            this.TextBox1 = new DataDynamics.ActiveReports.TextBox();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.TextBox26 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox27 = new DataDynamics.ActiveReports.TextBox();
            this.TxtMakeBy = new DataDynamics.ActiveReports.TextBox();
            this.TextBox30 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAddr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAddr2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPolicyNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEffectiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtExpirationDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPrima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMakeBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Height = 0F;
            this.Detail.Name = "Detail";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Height = 0F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Height = 0F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.TxtDate,
                        this.TxtBankName,
                        this.TxtBankAddr1,
                        this.TxtBankAddr2,
                        this.TxtBankCity,
                        this.TextBox12,
                        this.TextBox13,
                        this.TextBox14,
                        this.TxtPolicyNo,
                        this.TextBox16,
                        this.TxtCustID,
                        this.TextBox18,
                        this.TextBox19,
                        this.TxtEffectiveDate,
                        this.TextBox21,
                        this.TxtExpirationDate,
                        this.TextBox22,
                        this.TextBox23,
                        this.TextBox24,
                        this.TextBox25,
                        this.TextBox4,
                        this.TextBox5,
                        this.TxtCustomerName,
                        this.TextBox28,
                        this.TextBox29,
                        this.TxtPrima,
                        this.TextBox1,
                        this.Label75,
                        this.Label77});
            this.PageHeader.Height = 5.46875F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.TextBox26,
                        this.TextBox27,
                        this.TxtMakeBy,
                        this.TextBox30});
            this.PageFooter.Height = 4.208333F;
            this.PageFooter.Name = "PageFooter";
            // 
            // TxtDate
            // 
            this.TxtDate.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDate.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDate.Border.RightColor = System.Drawing.Color.Black;
            this.TxtDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDate.Border.TopColor = System.Drawing.Color.Black;
            this.TxtDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtDate.Height = 0.2F;
            this.TxtDate.Left = 0.9375F;
            this.TxtDate.Name = "TxtDate";
            this.TxtDate.Style = "font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TxtDate.Text = "TxtDate";
            this.TxtDate.Top = 2F;
            this.TxtDate.Width = 1.5F;
            // 
            // TxtBankName
            // 
            this.TxtBankName.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtBankName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankName.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtBankName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankName.Border.RightColor = System.Drawing.Color.Black;
            this.TxtBankName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankName.Border.TopColor = System.Drawing.Color.Black;
            this.TxtBankName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankName.Height = 0.2000003F;
            this.TxtBankName.Left = 0.3977272F;
            this.TxtBankName.MultiLine = false;
            this.TxtBankName.Name = "TxtBankName";
            this.TxtBankName.OutputFormat = resources.GetString("TxtBankName.OutputFormat");
            this.TxtBankName.Style = "text-align: left; font-weight: normal; font-size: 9.75pt; font-family: Microsoft " +
                "Sans Serif; vertical-align: middle; ";
            this.TxtBankName.Text = "TxtBankName";
            this.TxtBankName.Top = 2.3125F;
            this.TxtBankName.Width = 3.102273F;
            // 
            // TxtBankAddr1
            // 
            this.TxtBankAddr1.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtBankAddr1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddr1.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtBankAddr1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddr1.Border.RightColor = System.Drawing.Color.Black;
            this.TxtBankAddr1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddr1.Border.TopColor = System.Drawing.Color.Black;
            this.TxtBankAddr1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddr1.Height = 0.2000003F;
            this.TxtBankAddr1.Left = 0.3977272F;
            this.TxtBankAddr1.MultiLine = false;
            this.TxtBankAddr1.Name = "TxtBankAddr1";
            this.TxtBankAddr1.OutputFormat = resources.GetString("TxtBankAddr1.OutputFormat");
            this.TxtBankAddr1.Style = "text-align: left; font-weight: normal; font-size: 9pt; font-family: Microsoft San" +
                "s Serif; vertical-align: middle; ";
            this.TxtBankAddr1.Top = 2.5F;
            this.TxtBankAddr1.Width = 3.102273F;
            // 
            // TxtBankAddr2
            // 
            this.TxtBankAddr2.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtBankAddr2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddr2.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtBankAddr2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddr2.Border.RightColor = System.Drawing.Color.Black;
            this.TxtBankAddr2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddr2.Border.TopColor = System.Drawing.Color.Black;
            this.TxtBankAddr2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankAddr2.Height = 0.2000003F;
            this.TxtBankAddr2.Left = 0.3977272F;
            this.TxtBankAddr2.MultiLine = false;
            this.TxtBankAddr2.Name = "TxtBankAddr2";
            this.TxtBankAddr2.OutputFormat = resources.GetString("TxtBankAddr2.OutputFormat");
            this.TxtBankAddr2.Style = "text-align: left; font-weight: normal; font-size: 9pt; font-family: Microsoft San" +
                "s Serif; vertical-align: middle; ";
            this.TxtBankAddr2.Top = 2.6875F;
            this.TxtBankAddr2.Width = 3.102273F;
            // 
            // TxtBankCity
            // 
            this.TxtBankCity.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtBankCity.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankCity.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtBankCity.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankCity.Border.RightColor = System.Drawing.Color.Black;
            this.TxtBankCity.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankCity.Border.TopColor = System.Drawing.Color.Black;
            this.TxtBankCity.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBankCity.Height = 0.2000003F;
            this.TxtBankCity.Left = 0.3977272F;
            this.TxtBankCity.MultiLine = false;
            this.TxtBankCity.Name = "TxtBankCity";
            this.TxtBankCity.OutputFormat = resources.GetString("TxtBankCity.OutputFormat");
            this.TxtBankCity.Style = "text-align: left; font-weight: normal; font-size: 9pt; font-family: Microsoft San" +
                "s Serif; vertical-align: middle; ";
            this.TxtBankCity.Top = 2.875F;
            this.TxtBankCity.Width = 3.102273F;
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
            this.TextBox12.Height = 0.2F;
            this.TextBox12.Left = 0.75F;
            this.TextBox12.Name = "TextBox12";
            this.TextBox12.Style = "font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TextBox12.Text = "Póliza";
            this.TextBox12.Top = 3.375F;
            this.TextBox12.Width = 1.0625F;
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
            this.TextBox13.Height = 0.2F;
            this.TextBox13.Left = 2.3125F;
            this.TextBox13.Name = "TextBox13";
            this.TextBox13.Style = "text-align: center; font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TextBox13.Text = ":";
            this.TextBox13.Top = 3.375F;
            this.TextBox13.Width = 0.125F;
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
            this.TextBox14.Height = 0.2F;
            this.TextBox14.Left = 0.75F;
            this.TextBox14.Name = "TextBox14";
            this.TextBox14.Style = "font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TextBox14.Text = "Expediente";
            this.TextBox14.Top = 3.75F;
            this.TextBox14.Width = 1.0625F;
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
            this.TxtPolicyNo.Height = 0.2F;
            this.TxtPolicyNo.Left = 2.6875F;
            this.TxtPolicyNo.Name = "TxtPolicyNo";
            this.TxtPolicyNo.Style = "font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TxtPolicyNo.Text = "TxtPolicyNo";
            this.TxtPolicyNo.Top = 3.375F;
            this.TxtPolicyNo.Width = 2.625F;
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
            this.TextBox16.Height = 0.2F;
            this.TextBox16.Left = 2.3125F;
            this.TextBox16.Name = "TextBox16";
            this.TextBox16.Style = "text-align: center; font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TextBox16.Text = ":";
            this.TextBox16.Top = 3.75F;
            this.TextBox16.Width = 0.125F;
            // 
            // TxtCustID
            // 
            this.TxtCustID.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCustID.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustID.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCustID.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustID.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCustID.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustID.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCustID.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustID.Height = 0.2F;
            this.TxtCustID.Left = 2.6875F;
            this.TxtCustID.Name = "TxtCustID";
            this.TxtCustID.Style = "font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TxtCustID.Text = "TxtCustID";
            this.TxtCustID.Top = 3.75F;
            this.TxtCustID.Width = 2.625F;
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
            this.TextBox18.Height = 0.2F;
            this.TextBox18.Left = 0.75F;
            this.TextBox18.Name = "TextBox18";
            this.TextBox18.Style = "font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TextBox18.Text = "Fecha Efectiva";
            this.TextBox18.Top = 3.9375F;
            this.TextBox18.Width = 1.0625F;
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
            this.TextBox19.Height = 0.2F;
            this.TextBox19.Left = 2.3125F;
            this.TextBox19.Name = "TextBox19";
            this.TextBox19.Style = "text-align: center; font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TextBox19.Text = ":";
            this.TextBox19.Top = 3.9375F;
            this.TextBox19.Width = 0.125F;
            // 
            // TxtEffectiveDate
            // 
            this.TxtEffectiveDate.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtEffectiveDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEffectiveDate.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtEffectiveDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEffectiveDate.Border.RightColor = System.Drawing.Color.Black;
            this.TxtEffectiveDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEffectiveDate.Border.TopColor = System.Drawing.Color.Black;
            this.TxtEffectiveDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEffectiveDate.Height = 0.2F;
            this.TxtEffectiveDate.Left = 2.6875F;
            this.TxtEffectiveDate.MultiLine = false;
            this.TxtEffectiveDate.Name = "TxtEffectiveDate";
            this.TxtEffectiveDate.OutputFormat = resources.GetString("TxtEffectiveDate.OutputFormat");
            this.TxtEffectiveDate.Style = "font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TxtEffectiveDate.Text = "TxtEffectiveDate";
            this.TxtEffectiveDate.Top = 3.9375F;
            this.TxtEffectiveDate.Width = 0.6875F;
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
            this.TextBox21.Height = 0.2F;
            this.TextBox21.Left = 3.375F;
            this.TextBox21.Name = "TextBox21";
            this.TextBox21.Style = "text-align: left; font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TextBox21.Text = "a";
            this.TextBox21.Top = 3.9375F;
            this.TextBox21.Width = 0.125F;
            // 
            // TxtExpirationDate
            // 
            this.TxtExpirationDate.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtExpirationDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtExpirationDate.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtExpirationDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtExpirationDate.Border.RightColor = System.Drawing.Color.Black;
            this.TxtExpirationDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtExpirationDate.Border.TopColor = System.Drawing.Color.Black;
            this.TxtExpirationDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtExpirationDate.Height = 0.2F;
            this.TxtExpirationDate.Left = 3.5625F;
            this.TxtExpirationDate.MultiLine = false;
            this.TxtExpirationDate.Name = "TxtExpirationDate";
            this.TxtExpirationDate.OutputFormat = resources.GetString("TxtExpirationDate.OutputFormat");
            this.TxtExpirationDate.Style = "font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TxtExpirationDate.Text = "TxtExpirationDate";
            this.TxtExpirationDate.Top = 3.9375F;
            this.TxtExpirationDate.Width = 1.1875F;
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
            this.TextBox22.Height = 0.2F;
            this.TextBox22.Left = 0.375F;
            this.TextBox22.Name = "TextBox22";
            this.TextBox22.Style = "font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TextBox22.Text = "RE :";
            this.TextBox22.Top = 3.1875F;
            this.TextBox22.Width = 0.375F;
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
            this.TextBox23.Height = 0.2F;
            this.TextBox23.Left = 0.375F;
            this.TextBox23.Name = "TextBox23";
            this.TextBox23.Style = "font-weight: normal; font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TextBox23.Text = "Estimados Señores :";
            this.TextBox23.Top = 4.625F;
            this.TextBox23.Width = 1.625F;
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
            this.TextBox24.Height = 0.2F;
            this.TextBox24.Left = 0.375F;
            this.TextBox24.Name = "TextBox24";
            this.TextBox24.Style = "font-weight: normal; font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TextBox24.Text = "Certificamos por la presente que la póliza de referencia ha sido pagada en su tot" +
                "alidad y no ha sido financiada.";
            this.TextBox24.Top = 4.875F;
            this.TextBox24.Width = 6.625F;
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
            this.TextBox25.Height = 0.2F;
            this.TextBox25.Left = 0.375F;
            this.TextBox25.Name = "TextBox25";
            this.TextBox25.Style = "font-weight: normal; font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TextBox25.Text = "Sin nada más por el momento, quedo a sus órdenes.";
            this.TextBox25.Top = 5.25F;
            this.TextBox25.Width = 6.5F;
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
            this.TextBox4.Height = 0.2F;
            this.TextBox4.Left = 0.75F;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Style = "font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TextBox4.Text = "Asegurado";
            this.TextBox4.Top = 3.1875F;
            this.TextBox4.Width = 1.0625F;
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
            this.TextBox5.Left = 2.3125F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Style = "text-align: center; font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TextBox5.Text = ":";
            this.TextBox5.Top = 3.1875F;
            this.TextBox5.Width = 0.125F;
            // 
            // TxtCustomerName
            // 
            this.TxtCustomerName.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCustomerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerName.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCustomerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerName.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCustomerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerName.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCustomerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerName.Height = 0.2F;
            this.TxtCustomerName.Left = 2.6875F;
            this.TxtCustomerName.Name = "TxtCustomerName";
            this.TxtCustomerName.Style = "font-size: 9.75pt; font-family: Microsoft Sans Serif; ";
            this.TxtCustomerName.Text = "TxtCustomerName";
            this.TxtCustomerName.Top = 3.1875F;
            this.TxtCustomerName.Width = 2.875F;
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
            this.TextBox28.Height = 0.2F;
            this.TextBox28.Left = 0.75F;
            this.TextBox28.Name = "TextBox28";
            this.TextBox28.Style = "font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TextBox28.Text = "Prima";
            this.TextBox28.Top = 3.5625F;
            this.TextBox28.Width = 1.0625F;
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
            this.TextBox29.Height = 0.2F;
            this.TextBox29.Left = 2.3125F;
            this.TextBox29.Name = "TextBox29";
            this.TextBox29.Style = "text-align: center; font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TextBox29.Text = ":";
            this.TextBox29.Top = 3.5625F;
            this.TextBox29.Width = 0.125F;
            // 
            // TxtPrima
            // 
            this.TxtPrima.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtPrima.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPrima.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtPrima.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPrima.Border.RightColor = System.Drawing.Color.Black;
            this.TxtPrima.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPrima.Border.TopColor = System.Drawing.Color.Black;
            this.TxtPrima.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPrima.Height = 0.2F;
            this.TxtPrima.Left = 2.6875F;
            this.TxtPrima.Name = "TxtPrima";
            this.TxtPrima.OutputFormat = resources.GetString("TxtPrima.OutputFormat");
            this.TxtPrima.Style = "font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TxtPrima.Text = "TxtPrima";
            this.TxtPrima.Top = 3.5625F;
            this.TxtPrima.Width = 2.625F;
            // 
            // TextBox1
            // 
            this.TextBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Height = 0.2F;
            this.TextBox1.Left = 0.4375F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "font-size: 9pt; font-family: Microsoft Sans Serif; ";
            this.TextBox1.Text = "Fecha :";
            this.TextBox1.Top = 2F;
            this.TextBox1.Width = 0.5F;
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
            this.Label75.Left = 1.4375F;
            this.Label75.MultiLine = false;
            this.Label75.Name = "Label75";
            this.Label75.Style = "text-align: center; font-weight: bold; font-size: 11.25pt; font-family: Times New" +
                " Roman; ";
            this.Label75.Text = "LAS VISTAS INSURANCE AGENCY, CORP.";
            this.Label75.Top = 0.375F;
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
            this.Label77.Left = 1.4375F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-align: center; font-weight: bold; font-size: 6pt; font-family: Times New Rom" +
                "an; ";
            this.Label77.Text = "P.O. Box 195585 San Juan Puerto Rico, PR  00919-5585 Tel (787) 763-4010 Fax (787)" +
                " 763-3525";
            this.Label77.Top = 0.625F;
            this.Label77.Width = 5.125F;
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
            this.TextBox26.Height = 0.2F;
            this.TextBox26.Left = 0.375F;
            this.TextBox26.Name = "TextBox26";
            this.TextBox26.Style = "font-weight: normal; font-size: 9pt; ";
            this.TextBox26.Text = "Cordialmente,";
            this.TextBox26.Top = 0F;
            this.TextBox26.Width = 1.1875F;
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
            this.TextBox27.Height = 0.2F;
            this.TextBox27.Left = 0.375F;
            this.TextBox27.Name = "TextBox27";
            this.TextBox27.Style = "font-weight: normal; font-size: 9pt; ";
            this.TextBox27.Text = "Depto. De Contabilidad";
            this.TextBox27.Top = 1F;
            this.TextBox27.Width = 2.1875F;
            // 
            // TxtMakeBy
            // 
            this.TxtMakeBy.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtMakeBy.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMakeBy.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtMakeBy.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMakeBy.Border.RightColor = System.Drawing.Color.Black;
            this.TxtMakeBy.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMakeBy.Border.TopColor = System.Drawing.Color.Black;
            this.TxtMakeBy.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMakeBy.Height = 0.1875F;
            this.TxtMakeBy.Left = 1F;
            this.TxtMakeBy.Name = "TxtMakeBy";
            this.TxtMakeBy.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.TxtMakeBy.Top = 4F;
            this.TxtMakeBy.Width = 2F;
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
            this.TextBox30.Height = 0.1875F;
            this.TextBox30.Left = 0.375F;
            this.TextBox30.Name = "TextBox30";
            this.TextBox30.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.TextBox30.Text = "Make By :";
            this.TextBox30.Top = 4F;
            this.TextBox30.Width = 0.625F;
            // 
            // ActiveReport31
            // 
            this.PageSettings.Margins.Bottom = 0.5F;
            this.PageSettings.Margins.Left = 0.3F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.4F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.989583F;
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
            ((System.ComponentModel.ISupportInitialize)(this.TxtDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAddr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAddr2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPolicyNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEffectiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtExpirationDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPrima)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMakeBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
       
			// Attach Report Events
			this.ReportStart += new System.EventHandler(this.CertificacionDePago_ReportStart);
			this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
		 }

		#endregion
	}
}
