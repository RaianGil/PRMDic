using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.AutoGuard
{
	public class CartaCancellationNotice : DataDynamics.ActiveReports.ActiveReport3
	{
		//private int index = 0;

		public CartaCancellationNotice()
		{
			InitializeComponent();
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void CartaCancellationNotice_FetchData(object sender, DataDynamics.ActiveReports.ActiveReport3.FetchEventArgs eArgs)
		{
			//eArgs.EOF = true;
	
			//index++;
		}

		private void CartaCancellationNotice_ReportStart(object sender, System.EventArgs eArgs)
		{
			this.Detail.Visible = false;
		}

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Label Label78 = null;
		private DataDynamics.ActiveReports.Line Line61 = null;
		private DataDynamics.ActiveReports.Line Line62 = null;
		private DataDynamics.ActiveReports.Line Line147 = null;
		private DataDynamics.ActiveReports.Line Line148 = null;
		private DataDynamics.ActiveReports.TextBox TxtCustomerCity = null;
		private DataDynamics.ActiveReports.TextBox TxtCustomerAddr2 = null;
		private DataDynamics.ActiveReports.TextBox TxtCustomerAddr1 = null;
		private DataDynamics.ActiveReports.TextBox TxtCustomerName = null;
		private DataDynamics.ActiveReports.TextBox TxtPolicyNO = null;
		private DataDynamics.ActiveReports.TextBox TxtBankCity = null;
		private DataDynamics.ActiveReports.TextBox TxtBankAddr2 = null;
		private DataDynamics.ActiveReports.TextBox TxtBankAddr1 = null;
		private DataDynamics.ActiveReports.TextBox TxtBankName = null;
		private DataDynamics.ActiveReports.Label Label120 = null;
		private DataDynamics.ActiveReports.Line Line196 = null;
		private DataDynamics.ActiveReports.Line Line211 = null;
		private DataDynamics.ActiveReports.Line Line194 = null;
		private DataDynamics.ActiveReports.Line Line193 = null;
		private DataDynamics.ActiveReports.Line Line212 = null;
		private DataDynamics.ActiveReports.Label Label121 = null;
		private DataDynamics.ActiveReports.Line Line150 = null;
		private DataDynamics.ActiveReports.Line Line152 = null;
		private DataDynamics.ActiveReports.Line Line155 = null;
		private DataDynamics.ActiveReports.Line Line156 = null;
		private DataDynamics.ActiveReports.Line Line154 = null;
		private DataDynamics.ActiveReports.Label Label105 = null;
		private DataDynamics.ActiveReports.Label Label122 = null;
		private DataDynamics.ActiveReports.Line Line213 = null;
		private DataDynamics.ActiveReports.TextBox TxtSocialSecurity = null;
		private DataDynamics.ActiveReports.TextBox TxtLoanNumber = null;
		private DataDynamics.ActiveReports.Line Line149 = null;
		private DataDynamics.ActiveReports.Line Line214 = null;
		private DataDynamics.ActiveReports.Label Label123 = null;
		private DataDynamics.ActiveReports.Label Label124 = null;
		private DataDynamics.ActiveReports.Label Label125 = null;
		private DataDynamics.ActiveReports.Label Label126 = null;
		private DataDynamics.ActiveReports.Label Label127 = null;
		private DataDynamics.ActiveReports.Label Label128 = null;
		private DataDynamics.ActiveReports.TextBox txtPrintDate = null;
		private DataDynamics.ActiveReports.TextBox txtCustomerNumber = null;
		private DataDynamics.ActiveReports.TextBox txtAmountDue = null;
		private DataDynamics.ActiveReports.TextBox txtAgent = null;
		private DataDynamics.ActiveReports.TextBox txtDealer = null;
		private DataDynamics.ActiveReports.Line Line215 = null;
		private DataDynamics.ActiveReports.Label Label138 = null;
		private DataDynamics.ActiveReports.Label Label139 = null;
		private DataDynamics.ActiveReports.Label Label129 = null;
		private DataDynamics.ActiveReports.Label Label130 = null;
		private DataDynamics.ActiveReports.Label Label131 = null;
		private DataDynamics.ActiveReports.Label Label132 = null;
		private DataDynamics.ActiveReports.Label Label133 = null;
		private DataDynamics.ActiveReports.Label Label134 = null;
		private DataDynamics.ActiveReports.Line Line216 = null;
		private DataDynamics.ActiveReports.Line Line217 = null;
		private DataDynamics.ActiveReports.Line Line219 = null;
		private DataDynamics.ActiveReports.Line Line220 = null;
		private DataDynamics.ActiveReports.Line Line221 = null;
		private DataDynamics.ActiveReports.Line Line222 = null;
		private DataDynamics.ActiveReports.TextBox TextBox1 = null;
		private DataDynamics.ActiveReports.TextBox txtCompanyDealer = null;
		private DataDynamics.ActiveReports.TextBox txtEffectiveDate = null;
		private DataDynamics.ActiveReports.TextBox txtExpirationDate = null;
		private DataDynamics.ActiveReports.TextBox txtCharge = null;
		private DataDynamics.ActiveReports.Label Label135 = null;
		private DataDynamics.ActiveReports.Line Line223 = null;
		private DataDynamics.ActiveReports.Label Label137 = null;
		private DataDynamics.ActiveReports.TextBox txtBalanceDue = null;
		private DataDynamics.ActiveReports.Line Line218 = null;
		private DataDynamics.ActiveReports.Line Line224 = null;
		private DataDynamics.ActiveReports.Line Line225 = null;
		private DataDynamics.ActiveReports.Label Label75 = null;
		private DataDynamics.ActiveReports.Label Label77 = null;
		private DataDynamics.ActiveReports.Label Label = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.TextBox TextBox2 = null;
		private DataDynamics.ActiveReports.TextBox TextBox3 = null;
		private DataDynamics.ActiveReports.TextBox TextBox4 = null;
		private DataDynamics.ActiveReports.TextBox TextBox5 = null;
		private DataDynamics.ActiveReports.TextBox txtEffecDate = null;
		private DataDynamics.ActiveReports.TextBox TextBox6 = null;
		private DataDynamics.ActiveReports.TextBox TextBox7 = null;
		private DataDynamics.ActiveReports.TextBox TextBox8 = null;
		private DataDynamics.ActiveReports.TextBox TextBox9 = null;
		private DataDynamics.ActiveReports.TextBox TextBox10 = null;
		private DataDynamics.ActiveReports.TextBox TextBox11 = null;
		private DataDynamics.ActiveReports.TextBox TextBox12 = null;
		private DataDynamics.ActiveReports.TextBox txtEffetive = null;
		private DataDynamics.ActiveReports.TextBox TextBox13 = null;
		private DataDynamics.ActiveReports.TextBox TextBox14 = null;
		private DataDynamics.ActiveReports.TextBox TextBox15 = null;
		private DataDynamics.ActiveReports.TextBox TextBox16 = null;
		private DataDynamics.ActiveReports.TextBox TextBox17 = null;
		private DataDynamics.ActiveReports.TextBox TextBox18 = null;
		private DataDynamics.ActiveReports.TextBox TextBox19 = null;
		private DataDynamics.ActiveReports.Label Label84 = null;
		private DataDynamics.ActiveReports.Label Label85 = null;
		private DataDynamics.ActiveReports.Label Label86 = null;
		private DataDynamics.ActiveReports.TextBox TextBox20 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartaCancellationNotice));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label78 = new DataDynamics.ActiveReports.Label();
            this.Line61 = new DataDynamics.ActiveReports.Line();
            this.Line62 = new DataDynamics.ActiveReports.Line();
            this.Line147 = new DataDynamics.ActiveReports.Line();
            this.Line148 = new DataDynamics.ActiveReports.Line();
            this.TxtCustomerCity = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerAddr2 = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerAddr1 = new DataDynamics.ActiveReports.TextBox();
            this.TxtCustomerName = new DataDynamics.ActiveReports.TextBox();
            this.TxtPolicyNO = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankCity = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankAddr2 = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankAddr1 = new DataDynamics.ActiveReports.TextBox();
            this.TxtBankName = new DataDynamics.ActiveReports.TextBox();
            this.Label120 = new DataDynamics.ActiveReports.Label();
            this.Line196 = new DataDynamics.ActiveReports.Line();
            this.Line211 = new DataDynamics.ActiveReports.Line();
            this.Line194 = new DataDynamics.ActiveReports.Line();
            this.Line193 = new DataDynamics.ActiveReports.Line();
            this.Line212 = new DataDynamics.ActiveReports.Line();
            this.Label121 = new DataDynamics.ActiveReports.Label();
            this.Line150 = new DataDynamics.ActiveReports.Line();
            this.Line152 = new DataDynamics.ActiveReports.Line();
            this.Line155 = new DataDynamics.ActiveReports.Line();
            this.Line156 = new DataDynamics.ActiveReports.Line();
            this.Line154 = new DataDynamics.ActiveReports.Line();
            this.Label105 = new DataDynamics.ActiveReports.Label();
            this.Label122 = new DataDynamics.ActiveReports.Label();
            this.Line213 = new DataDynamics.ActiveReports.Line();
            this.TxtSocialSecurity = new DataDynamics.ActiveReports.TextBox();
            this.TxtLoanNumber = new DataDynamics.ActiveReports.TextBox();
            this.Line149 = new DataDynamics.ActiveReports.Line();
            this.Line214 = new DataDynamics.ActiveReports.Line();
            this.Label123 = new DataDynamics.ActiveReports.Label();
            this.Label124 = new DataDynamics.ActiveReports.Label();
            this.Label125 = new DataDynamics.ActiveReports.Label();
            this.Label126 = new DataDynamics.ActiveReports.Label();
            this.Label127 = new DataDynamics.ActiveReports.Label();
            this.Label128 = new DataDynamics.ActiveReports.Label();
            this.txtPrintDate = new DataDynamics.ActiveReports.TextBox();
            this.txtCustomerNumber = new DataDynamics.ActiveReports.TextBox();
            this.txtAmountDue = new DataDynamics.ActiveReports.TextBox();
            this.txtAgent = new DataDynamics.ActiveReports.TextBox();
            this.txtDealer = new DataDynamics.ActiveReports.TextBox();
            this.Line215 = new DataDynamics.ActiveReports.Line();
            this.Label138 = new DataDynamics.ActiveReports.Label();
            this.Label139 = new DataDynamics.ActiveReports.Label();
            this.Label129 = new DataDynamics.ActiveReports.Label();
            this.Label130 = new DataDynamics.ActiveReports.Label();
            this.Label131 = new DataDynamics.ActiveReports.Label();
            this.Label132 = new DataDynamics.ActiveReports.Label();
            this.Label133 = new DataDynamics.ActiveReports.Label();
            this.Label134 = new DataDynamics.ActiveReports.Label();
            this.Line216 = new DataDynamics.ActiveReports.Line();
            this.Line217 = new DataDynamics.ActiveReports.Line();
            this.Line219 = new DataDynamics.ActiveReports.Line();
            this.Line220 = new DataDynamics.ActiveReports.Line();
            this.Line221 = new DataDynamics.ActiveReports.Line();
            this.Line222 = new DataDynamics.ActiveReports.Line();
            this.TextBox1 = new DataDynamics.ActiveReports.TextBox();
            this.txtCompanyDealer = new DataDynamics.ActiveReports.TextBox();
            this.txtEffectiveDate = new DataDynamics.ActiveReports.TextBox();
            this.txtExpirationDate = new DataDynamics.ActiveReports.TextBox();
            this.txtCharge = new DataDynamics.ActiveReports.TextBox();
            this.Label135 = new DataDynamics.ActiveReports.Label();
            this.Line223 = new DataDynamics.ActiveReports.Line();
            this.Label137 = new DataDynamics.ActiveReports.Label();
            this.txtBalanceDue = new DataDynamics.ActiveReports.TextBox();
            this.Line218 = new DataDynamics.ActiveReports.Line();
            this.Line224 = new DataDynamics.ActiveReports.Line();
            this.Line225 = new DataDynamics.ActiveReports.Line();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.TextBox2 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox3 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox4 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox5 = new DataDynamics.ActiveReports.TextBox();
            this.txtEffecDate = new DataDynamics.ActiveReports.TextBox();
            this.TextBox6 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox7 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox8 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox9 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox10 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox11 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox12 = new DataDynamics.ActiveReports.TextBox();
            this.txtEffetive = new DataDynamics.ActiveReports.TextBox();
            this.TextBox13 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox14 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox15 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox16 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox17 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox18 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox19 = new DataDynamics.ActiveReports.TextBox();
            this.Label84 = new DataDynamics.ActiveReports.Label();
            this.Label85 = new DataDynamics.ActiveReports.Label();
            this.Label86 = new DataDynamics.ActiveReports.Label();
            this.TextBox20 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Label78)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerAddr2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerAddr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPolicyNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAddr2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAddr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label120)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label121)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label122)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSocialSecurity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLoanNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label123)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label124)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label125)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label126)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label127)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label128)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountDue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDealer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label138)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label139)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label129)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyDealer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpirationDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCharge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label137)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalanceDue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffecDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffetive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label84)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label85)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label86)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Height = 0F;
            this.Detail.Name = "Detail";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label78,
            this.Line61,
            this.Line62,
            this.Line147,
            this.Line148,
            this.TxtCustomerCity,
            this.TxtCustomerAddr2,
            this.TxtCustomerAddr1,
            this.TxtCustomerName,
            this.TxtPolicyNO,
            this.TxtBankCity,
            this.TxtBankAddr2,
            this.TxtBankAddr1,
            this.TxtBankName,
            this.Label120,
            this.Line196,
            this.Line211,
            this.Line194,
            this.Line193,
            this.Line212,
            this.Label121,
            this.Line150,
            this.Line152,
            this.Line155,
            this.Line156,
            this.Line154,
            this.Label105,
            this.Label122,
            this.Line213,
            this.TxtSocialSecurity,
            this.TxtLoanNumber,
            this.Line149,
            this.Line214,
            this.Label123,
            this.Label124,
            this.Label125,
            this.Label126,
            this.Label127,
            this.Label128,
            this.txtPrintDate,
            this.txtCustomerNumber,
            this.txtAmountDue,
            this.txtAgent,
            this.txtDealer,
            this.Line215,
            this.Label138,
            this.Label139,
            this.Label129,
            this.Label130,
            this.Label131,
            this.Label132,
            this.Label133,
            this.Label134,
            this.Line216,
            this.Line217,
            this.Line219,
            this.Line220,
            this.Line221,
            this.Line222,
            this.TextBox1,
            this.txtCompanyDealer,
            this.txtEffectiveDate,
            this.txtExpirationDate,
            this.txtCharge,
            this.Label135,
            this.Line223,
            this.Label137,
            this.txtBalanceDue,
            this.Line218,
            this.Line224,
            this.Line225,
            this.Label75,
            this.Label77,
            this.Label});
            this.PageHeader.Height = 6.103472F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // Label78
            // 
            this.Label78.Border.BottomColor = System.Drawing.Color.Black;
            this.Label78.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label78.Border.LeftColor = System.Drawing.Color.Black;
            this.Label78.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label78.Border.RightColor = System.Drawing.Color.Black;
            this.Label78.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label78.Border.TopColor = System.Drawing.Color.Black;
            this.Label78.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label78.Height = 0.25F;
            this.Label78.HyperLink = "";
            this.Label78.Left = 0.4375F;
            this.Label78.Name = "Label78";
            this.Label78.Style = "text-align: center; font-weight: bold; background-color: LightGrey; font-size: 9p" +
                "t; vertical-align: middle; ";
            this.Label78.Text = "ASEGURADO  /  INSURED";
            this.Label78.Top = 2.25F;
            this.Label78.Width = 2.875F;
            // 
            // Line61
            // 
            this.Line61.Border.BottomColor = System.Drawing.Color.Black;
            this.Line61.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line61.Border.LeftColor = System.Drawing.Color.Black;
            this.Line61.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line61.Border.RightColor = System.Drawing.Color.Black;
            this.Line61.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line61.Border.TopColor = System.Drawing.Color.Black;
            this.Line61.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line61.Height = 1.3125F;
            this.Line61.Left = 3.3125F;
            this.Line61.LineWeight = 1F;
            this.Line61.Name = "Line61";
            this.Line61.Top = 2.25F;
            this.Line61.Width = 0F;
            this.Line61.X1 = 3.3125F;
            this.Line61.X2 = 3.3125F;
            this.Line61.Y1 = 3.5625F;
            this.Line61.Y2 = 2.25F;
            // 
            // Line62
            // 
            this.Line62.Border.BottomColor = System.Drawing.Color.Black;
            this.Line62.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line62.Border.LeftColor = System.Drawing.Color.Black;
            this.Line62.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line62.Border.RightColor = System.Drawing.Color.Black;
            this.Line62.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line62.Border.TopColor = System.Drawing.Color.Black;
            this.Line62.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line62.Height = 1.3125F;
            this.Line62.Left = 0.4375F;
            this.Line62.LineWeight = 1F;
            this.Line62.Name = "Line62";
            this.Line62.Top = 2.25F;
            this.Line62.Width = 0F;
            this.Line62.X1 = 0.4375F;
            this.Line62.X2 = 0.4375F;
            this.Line62.Y1 = 3.5625F;
            this.Line62.Y2 = 2.25F;
            // 
            // Line147
            // 
            this.Line147.Border.BottomColor = System.Drawing.Color.Black;
            this.Line147.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line147.Border.LeftColor = System.Drawing.Color.Black;
            this.Line147.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line147.Border.RightColor = System.Drawing.Color.Black;
            this.Line147.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line147.Border.TopColor = System.Drawing.Color.Black;
            this.Line147.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line147.Height = 0F;
            this.Line147.Left = 0.4375F;
            this.Line147.LineWeight = 1F;
            this.Line147.Name = "Line147";
            this.Line147.Top = 2.25F;
            this.Line147.Width = 2.875F;
            this.Line147.X1 = 0.4375F;
            this.Line147.X2 = 3.3125F;
            this.Line147.Y1 = 2.25F;
            this.Line147.Y2 = 2.25F;
            // 
            // Line148
            // 
            this.Line148.Border.BottomColor = System.Drawing.Color.Black;
            this.Line148.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line148.Border.LeftColor = System.Drawing.Color.Black;
            this.Line148.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line148.Border.RightColor = System.Drawing.Color.Black;
            this.Line148.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line148.Border.TopColor = System.Drawing.Color.Black;
            this.Line148.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line148.Height = 0F;
            this.Line148.Left = 0.4375F;
            this.Line148.LineWeight = 1F;
            this.Line148.Name = "Line148";
            this.Line148.Top = 2.5F;
            this.Line148.Width = 2.875F;
            this.Line148.X1 = 0.4375F;
            this.Line148.X2 = 3.3125F;
            this.Line148.Y1 = 2.5F;
            this.Line148.Y2 = 2.5F;
            // 
            // TxtCustomerCity
            // 
            this.TxtCustomerCity.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCustomerCity.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerCity.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCustomerCity.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerCity.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCustomerCity.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerCity.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCustomerCity.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerCity.DataField = "Addrress3";
            this.TxtCustomerCity.Height = 0.2F;
            this.TxtCustomerCity.Left = 0.5625F;
            this.TxtCustomerCity.MultiLine = false;
            this.TxtCustomerCity.Name = "TxtCustomerCity";
            this.TxtCustomerCity.OutputFormat = resources.GetString("TxtCustomerCity.OutputFormat");
            this.TxtCustomerCity.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtCustomerCity.Text = null;
            this.TxtCustomerCity.Top = 3F;
            this.TxtCustomerCity.Width = 2.664773F;
            // 
            // TxtCustomerAddr2
            // 
            this.TxtCustomerAddr2.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCustomerAddr2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerAddr2.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCustomerAddr2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerAddr2.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCustomerAddr2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerAddr2.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCustomerAddr2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerAddr2.DataField = "Addrress2";
            this.TxtCustomerAddr2.Height = 0.2F;
            this.TxtCustomerAddr2.Left = 0.5625F;
            this.TxtCustomerAddr2.MultiLine = false;
            this.TxtCustomerAddr2.Name = "TxtCustomerAddr2";
            this.TxtCustomerAddr2.OutputFormat = resources.GetString("TxtCustomerAddr2.OutputFormat");
            this.TxtCustomerAddr2.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtCustomerAddr2.Text = null;
            this.TxtCustomerAddr2.Top = 2.875F;
            this.TxtCustomerAddr2.Width = 2.664773F;
            // 
            // TxtCustomerAddr1
            // 
            this.TxtCustomerAddr1.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCustomerAddr1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerAddr1.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCustomerAddr1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerAddr1.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCustomerAddr1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerAddr1.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCustomerAddr1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerAddr1.DataField = "Addrress1";
            this.TxtCustomerAddr1.Height = 0.2F;
            this.TxtCustomerAddr1.Left = 0.5625F;
            this.TxtCustomerAddr1.MultiLine = false;
            this.TxtCustomerAddr1.Name = "TxtCustomerAddr1";
            this.TxtCustomerAddr1.OutputFormat = resources.GetString("TxtCustomerAddr1.OutputFormat");
            this.TxtCustomerAddr1.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.TxtCustomerAddr1.Text = null;
            this.TxtCustomerAddr1.Top = 2.75F;
            this.TxtCustomerAddr1.Width = 2.664773F;
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
            this.TxtCustomerName.DataField = "CustomerName";
            this.TxtCustomerName.Height = 0.2F;
            this.TxtCustomerName.Left = 0.5625F;
            this.TxtCustomerName.MultiLine = false;
            this.TxtCustomerName.Name = "TxtCustomerName";
            this.TxtCustomerName.OutputFormat = resources.GetString("TxtCustomerName.OutputFormat");
            this.TxtCustomerName.Style = "text-align: left; font-weight: bold; font-size: 9.75pt; ";
            this.TxtCustomerName.Text = "TxtCustomerName";
            this.TxtCustomerName.Top = 2.5625F;
            this.TxtCustomerName.Width = 2.664772F;
            // 
            // TxtPolicyNO
            // 
            this.TxtPolicyNO.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtPolicyNO.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPolicyNO.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtPolicyNO.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPolicyNO.Border.RightColor = System.Drawing.Color.Black;
            this.TxtPolicyNO.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPolicyNO.Border.TopColor = System.Drawing.Color.Black;
            this.TxtPolicyNO.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPolicyNO.DataField = "PolicyNumber";
            this.TxtPolicyNO.Height = 0.1875F;
            this.TxtPolicyNO.Left = 5.875F;
            this.TxtPolicyNO.MultiLine = false;
            this.TxtPolicyNO.Name = "TxtPolicyNO";
            this.TxtPolicyNO.OutputFormat = resources.GetString("TxtPolicyNO.OutputFormat");
            this.TxtPolicyNO.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; vertical-align: top; ";
            this.TxtPolicyNO.Text = null;
            this.TxtPolicyNO.Top = 2.875F;
            this.TxtPolicyNO.Width = 1.75F;
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
            this.TxtBankCity.DataField = "BankAddress";
            this.TxtBankCity.Height = 0.2000003F;
            this.TxtBankCity.Left = 0.5F;
            this.TxtBankCity.MultiLine = false;
            this.TxtBankCity.Name = "TxtBankCity";
            this.TxtBankCity.OutputFormat = resources.GetString("TxtBankCity.OutputFormat");
            this.TxtBankCity.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.TxtBankCity.Text = null;
            this.TxtBankCity.Top = 4.5625F;
            this.TxtBankCity.Width = 2.6875F;
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
            this.TxtBankAddr2.DataField = "BankAddress2";
            this.TxtBankAddr2.Height = 0.2000003F;
            this.TxtBankAddr2.Left = 0.5F;
            this.TxtBankAddr2.MultiLine = false;
            this.TxtBankAddr2.Name = "TxtBankAddr2";
            this.TxtBankAddr2.OutputFormat = resources.GetString("TxtBankAddr2.OutputFormat");
            this.TxtBankAddr2.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.TxtBankAddr2.Text = null;
            this.TxtBankAddr2.Top = 4.4375F;
            this.TxtBankAddr2.Width = 2.6875F;
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
            this.TxtBankAddr1.DataField = "BankAddress1";
            this.TxtBankAddr1.Height = 0.2000003F;
            this.TxtBankAddr1.Left = 0.5F;
            this.TxtBankAddr1.MultiLine = false;
            this.TxtBankAddr1.Name = "TxtBankAddr1";
            this.TxtBankAddr1.OutputFormat = resources.GetString("TxtBankAddr1.OutputFormat");
            this.TxtBankAddr1.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.TxtBankAddr1.Text = null;
            this.TxtBankAddr1.Top = 4.3125F;
            this.TxtBankAddr1.Width = 2.6875F;
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
            this.TxtBankName.DataField = "BankDesc";
            this.TxtBankName.Height = 0.2000003F;
            this.TxtBankName.Left = 0.5F;
            this.TxtBankName.MultiLine = false;
            this.TxtBankName.Name = "TxtBankName";
            this.TxtBankName.OutputFormat = resources.GetString("TxtBankName.OutputFormat");
            this.TxtBankName.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.TxtBankName.Text = null;
            this.TxtBankName.Top = 4.1875F;
            this.TxtBankName.Width = 2.6875F;
            // 
            // Label120
            // 
            this.Label120.Border.BottomColor = System.Drawing.Color.Black;
            this.Label120.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label120.Border.LeftColor = System.Drawing.Color.Black;
            this.Label120.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label120.Border.RightColor = System.Drawing.Color.Black;
            this.Label120.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label120.Border.TopColor = System.Drawing.Color.Black;
            this.Label120.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label120.Height = 0.25F;
            this.Label120.HyperLink = "";
            this.Label120.Left = 0.4375F;
            this.Label120.Name = "Label120";
            this.Label120.Style = "text-align: center; font-weight: bold; background-color: LightGrey; font-size: 9." +
                "75pt; ";
            this.Label120.Text = "BANCO  /  LOSSPAYEE";
            this.Label120.Top = 3.875F;
            this.Label120.Width = 2.875F;
            // 
            // Line196
            // 
            this.Line196.Border.BottomColor = System.Drawing.Color.Black;
            this.Line196.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line196.Border.LeftColor = System.Drawing.Color.Black;
            this.Line196.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line196.Border.RightColor = System.Drawing.Color.Black;
            this.Line196.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line196.Border.TopColor = System.Drawing.Color.Black;
            this.Line196.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line196.Height = 0F;
            this.Line196.Left = 0.4375F;
            this.Line196.LineWeight = 1F;
            this.Line196.Name = "Line196";
            this.Line196.Top = 4.125F;
            this.Line196.Width = 2.875F;
            this.Line196.X1 = 0.4375F;
            this.Line196.X2 = 3.3125F;
            this.Line196.Y1 = 4.125F;
            this.Line196.Y2 = 4.125F;
            // 
            // Line211
            // 
            this.Line211.Border.BottomColor = System.Drawing.Color.Black;
            this.Line211.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line211.Border.LeftColor = System.Drawing.Color.Black;
            this.Line211.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line211.Border.RightColor = System.Drawing.Color.Black;
            this.Line211.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line211.Border.TopColor = System.Drawing.Color.Black;
            this.Line211.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line211.Height = 0F;
            this.Line211.Left = 0.4375F;
            this.Line211.LineWeight = 1F;
            this.Line211.Name = "Line211";
            this.Line211.Top = 3.875F;
            this.Line211.Width = 2.875F;
            this.Line211.X1 = 0.4375F;
            this.Line211.X2 = 3.3125F;
            this.Line211.Y1 = 3.875F;
            this.Line211.Y2 = 3.875F;
            // 
            // Line194
            // 
            this.Line194.Border.BottomColor = System.Drawing.Color.Black;
            this.Line194.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line194.Border.LeftColor = System.Drawing.Color.Black;
            this.Line194.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line194.Border.RightColor = System.Drawing.Color.Black;
            this.Line194.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line194.Border.TopColor = System.Drawing.Color.Black;
            this.Line194.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line194.Height = 1F;
            this.Line194.Left = 0.4375F;
            this.Line194.LineWeight = 1F;
            this.Line194.Name = "Line194";
            this.Line194.Top = 3.875F;
            this.Line194.Width = 0F;
            this.Line194.X1 = 0.4375F;
            this.Line194.X2 = 0.4375F;
            this.Line194.Y1 = 4.875F;
            this.Line194.Y2 = 3.875F;
            // 
            // Line193
            // 
            this.Line193.Border.BottomColor = System.Drawing.Color.Black;
            this.Line193.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line193.Border.LeftColor = System.Drawing.Color.Black;
            this.Line193.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line193.Border.RightColor = System.Drawing.Color.Black;
            this.Line193.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line193.Border.TopColor = System.Drawing.Color.Black;
            this.Line193.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line193.Height = 1F;
            this.Line193.Left = 3.3125F;
            this.Line193.LineWeight = 1F;
            this.Line193.Name = "Line193";
            this.Line193.Top = 3.875F;
            this.Line193.Width = 0F;
            this.Line193.X1 = 3.3125F;
            this.Line193.X2 = 3.3125F;
            this.Line193.Y1 = 4.875F;
            this.Line193.Y2 = 3.875F;
            // 
            // Line212
            // 
            this.Line212.Border.BottomColor = System.Drawing.Color.Black;
            this.Line212.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line212.Border.LeftColor = System.Drawing.Color.Black;
            this.Line212.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line212.Border.RightColor = System.Drawing.Color.Black;
            this.Line212.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line212.Border.TopColor = System.Drawing.Color.Black;
            this.Line212.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line212.Height = 0F;
            this.Line212.Left = 0.4375F;
            this.Line212.LineWeight = 1F;
            this.Line212.Name = "Line212";
            this.Line212.Top = 4.875F;
            this.Line212.Width = 2.875F;
            this.Line212.X1 = 0.4375F;
            this.Line212.X2 = 3.3125F;
            this.Line212.Y1 = 4.875F;
            this.Line212.Y2 = 4.875F;
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
            this.Label121.Height = 0.25F;
            this.Label121.HyperLink = "";
            this.Label121.Left = 4.6875F;
            this.Label121.Name = "Label121";
            this.Label121.Style = "text-align: center; font-weight: bold; background-color: LightGrey; font-size: 9p" +
                "t; vertical-align: middle; ";
            this.Label121.Text = "POLIZA  /  POLICY";
            this.Label121.Top = 2.25F;
            this.Label121.Width = 3.25F;
            // 
            // Line150
            // 
            this.Line150.Border.BottomColor = System.Drawing.Color.Black;
            this.Line150.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line150.Border.LeftColor = System.Drawing.Color.Black;
            this.Line150.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line150.Border.RightColor = System.Drawing.Color.Black;
            this.Line150.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line150.Border.TopColor = System.Drawing.Color.Black;
            this.Line150.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line150.Height = 1.3125F;
            this.Line150.Left = 4.694445F;
            this.Line150.LineWeight = 1F;
            this.Line150.Name = "Line150";
            this.Line150.Top = 2.256944F;
            this.Line150.Width = 0F;
            this.Line150.X1 = 4.694445F;
            this.Line150.X2 = 4.694445F;
            this.Line150.Y1 = 3.569444F;
            this.Line150.Y2 = 2.256944F;
            // 
            // Line152
            // 
            this.Line152.Border.BottomColor = System.Drawing.Color.Black;
            this.Line152.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line152.Border.LeftColor = System.Drawing.Color.Black;
            this.Line152.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line152.Border.RightColor = System.Drawing.Color.Black;
            this.Line152.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line152.Border.TopColor = System.Drawing.Color.Black;
            this.Line152.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line152.Height = 1.0625F;
            this.Line152.Left = 5.819445F;
            this.Line152.LineWeight = 1F;
            this.Line152.Name = "Line152";
            this.Line152.Top = 2.506944F;
            this.Line152.Width = 0F;
            this.Line152.X1 = 5.819445F;
            this.Line152.X2 = 5.819445F;
            this.Line152.Y1 = 3.569444F;
            this.Line152.Y2 = 2.506944F;
            // 
            // Line155
            // 
            this.Line155.Border.BottomColor = System.Drawing.Color.Black;
            this.Line155.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line155.Border.LeftColor = System.Drawing.Color.Black;
            this.Line155.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line155.Border.RightColor = System.Drawing.Color.Black;
            this.Line155.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line155.Border.TopColor = System.Drawing.Color.Black;
            this.Line155.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line155.Height = 0F;
            this.Line155.Left = 4.6875F;
            this.Line155.LineWeight = 1F;
            this.Line155.Name = "Line155";
            this.Line155.Top = 2.5F;
            this.Line155.Width = 3.25F;
            this.Line155.X1 = 4.6875F;
            this.Line155.X2 = 7.9375F;
            this.Line155.Y1 = 2.5F;
            this.Line155.Y2 = 2.5F;
            // 
            // Line156
            // 
            this.Line156.Border.BottomColor = System.Drawing.Color.Black;
            this.Line156.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line156.Border.LeftColor = System.Drawing.Color.Black;
            this.Line156.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line156.Border.RightColor = System.Drawing.Color.Black;
            this.Line156.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line156.Border.TopColor = System.Drawing.Color.Black;
            this.Line156.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line156.Height = 1.3125F;
            this.Line156.Left = 7.944445F;
            this.Line156.LineWeight = 1F;
            this.Line156.Name = "Line156";
            this.Line156.Top = 2.256944F;
            this.Line156.Width = 0F;
            this.Line156.X1 = 7.944445F;
            this.Line156.X2 = 7.944445F;
            this.Line156.Y1 = 3.569444F;
            this.Line156.Y2 = 2.256944F;
            // 
            // Line154
            // 
            this.Line154.Border.BottomColor = System.Drawing.Color.Black;
            this.Line154.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line154.Border.LeftColor = System.Drawing.Color.Black;
            this.Line154.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line154.Border.RightColor = System.Drawing.Color.Black;
            this.Line154.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line154.Border.TopColor = System.Drawing.Color.Black;
            this.Line154.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line154.Height = 0F;
            this.Line154.Left = 4.6875F;
            this.Line154.LineWeight = 1F;
            this.Line154.Name = "Line154";
            this.Line154.Top = 2.25F;
            this.Line154.Width = 3.25F;
            this.Line154.X1 = 4.6875F;
            this.Line154.X2 = 7.9375F;
            this.Line154.Y1 = 2.25F;
            this.Line154.Y2 = 2.25F;
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
            this.Label105.Height = 0.1875F;
            this.Label105.HyperLink = "";
            this.Label105.Left = 0.5625F;
            this.Label105.Name = "Label105";
            this.Label105.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label105.Text = "Social Security";
            this.Label105.Top = 3.25F;
            this.Label105.Width = 0.8125F;
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
            this.Label122.Height = 0.1875F;
            this.Label122.HyperLink = "";
            this.Label122.Left = 0.5625F;
            this.Label122.Name = "Label122";
            this.Label122.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label122.Text = "Loan Number";
            this.Label122.Top = 3.375F;
            this.Label122.Width = 0.8125F;
            // 
            // Line213
            // 
            this.Line213.Border.BottomColor = System.Drawing.Color.Black;
            this.Line213.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line213.Border.LeftColor = System.Drawing.Color.Black;
            this.Line213.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line213.Border.RightColor = System.Drawing.Color.Black;
            this.Line213.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line213.Border.TopColor = System.Drawing.Color.Black;
            this.Line213.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line213.Height = 0.3125F;
            this.Line213.Left = 1.375F;
            this.Line213.LineWeight = 1F;
            this.Line213.Name = "Line213";
            this.Line213.Top = 3.25F;
            this.Line213.Width = 0F;
            this.Line213.X1 = 1.375F;
            this.Line213.X2 = 1.375F;
            this.Line213.Y1 = 3.5625F;
            this.Line213.Y2 = 3.25F;
            // 
            // TxtSocialSecurity
            // 
            this.TxtSocialSecurity.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtSocialSecurity.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSocialSecurity.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtSocialSecurity.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSocialSecurity.Border.RightColor = System.Drawing.Color.Black;
            this.TxtSocialSecurity.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSocialSecurity.Border.TopColor = System.Drawing.Color.Black;
            this.TxtSocialSecurity.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSocialSecurity.DataField = "SocSec";
            this.TxtSocialSecurity.Height = 0.1875F;
            this.TxtSocialSecurity.Left = 1.375F;
            this.TxtSocialSecurity.MultiLine = false;
            this.TxtSocialSecurity.Name = "TxtSocialSecurity";
            this.TxtSocialSecurity.OutputFormat = resources.GetString("TxtSocialSecurity.OutputFormat");
            this.TxtSocialSecurity.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.TxtSocialSecurity.Text = null;
            this.TxtSocialSecurity.Top = 3.25F;
            this.TxtSocialSecurity.Width = 1.5F;
            // 
            // TxtLoanNumber
            // 
            this.TxtLoanNumber.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtLoanNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLoanNumber.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtLoanNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLoanNumber.Border.RightColor = System.Drawing.Color.Black;
            this.TxtLoanNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLoanNumber.Border.TopColor = System.Drawing.Color.Black;
            this.TxtLoanNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLoanNumber.Height = 0.1875F;
            this.TxtLoanNumber.Left = 1.375F;
            this.TxtLoanNumber.MultiLine = false;
            this.TxtLoanNumber.Name = "TxtLoanNumber";
            this.TxtLoanNumber.OutputFormat = resources.GetString("TxtLoanNumber.OutputFormat");
            this.TxtLoanNumber.Style = "text-align: center; font-weight: normal; font-size: 8pt; ";
            this.TxtLoanNumber.Text = null;
            this.TxtLoanNumber.Top = 3.375F;
            this.TxtLoanNumber.Width = 1.5F;
            // 
            // Line149
            // 
            this.Line149.Border.BottomColor = System.Drawing.Color.Black;
            this.Line149.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line149.Border.LeftColor = System.Drawing.Color.Black;
            this.Line149.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line149.Border.RightColor = System.Drawing.Color.Black;
            this.Line149.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line149.Border.TopColor = System.Drawing.Color.Black;
            this.Line149.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line149.Height = 0F;
            this.Line149.Left = 0.4375F;
            this.Line149.LineWeight = 1F;
            this.Line149.Name = "Line149";
            this.Line149.Top = 3.25F;
            this.Line149.Width = 2.875F;
            this.Line149.X1 = 0.4375F;
            this.Line149.X2 = 3.3125F;
            this.Line149.Y1 = 3.25F;
            this.Line149.Y2 = 3.25F;
            // 
            // Line214
            // 
            this.Line214.Border.BottomColor = System.Drawing.Color.Black;
            this.Line214.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line214.Border.LeftColor = System.Drawing.Color.Black;
            this.Line214.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line214.Border.RightColor = System.Drawing.Color.Black;
            this.Line214.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line214.Border.TopColor = System.Drawing.Color.Black;
            this.Line214.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line214.Height = 0F;
            this.Line214.Left = 0.4375F;
            this.Line214.LineWeight = 1F;
            this.Line214.Name = "Line214";
            this.Line214.Top = 3.5625F;
            this.Line214.Width = 2.875F;
            this.Line214.X1 = 0.4375F;
            this.Line214.X2 = 3.3125F;
            this.Line214.Y1 = 3.5625F;
            this.Line214.Y2 = 3.5625F;
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
            this.Label123.Height = 0.1875F;
            this.Label123.HyperLink = "";
            this.Label123.Left = 4.75F;
            this.Label123.Name = "Label123";
            this.Label123.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label123.Text = "Print Date";
            this.Label123.Top = 2.625F;
            this.Label123.Width = 0.8125F;
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
            this.Label124.HyperLink = "";
            this.Label124.Left = 4.75F;
            this.Label124.Name = "Label124";
            this.Label124.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label124.Text = "Customer Number";
            this.Label124.Top = 2.75F;
            this.Label124.Width = 1F;
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
            this.Label125.Height = 0.1875F;
            this.Label125.HyperLink = "";
            this.Label125.Left = 4.75F;
            this.Label125.Name = "Label125";
            this.Label125.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label125.Text = "Policy Number";
            this.Label125.Top = 2.875F;
            this.Label125.Width = 0.9375F;
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
            this.Label126.Height = 0.1875F;
            this.Label126.HyperLink = "";
            this.Label126.Left = 4.75F;
            this.Label126.Name = "Label126";
            this.Label126.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label126.Text = "Amount Due";
            this.Label126.Top = 3F;
            this.Label126.Width = 0.9375F;
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
            this.Label127.Height = 0.1875F;
            this.Label127.HyperLink = "";
            this.Label127.Left = 4.75F;
            this.Label127.Name = "Label127";
            this.Label127.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label127.Text = "Agent";
            this.Label127.Top = 3.125F;
            this.Label127.Width = 0.9375F;
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
            this.Label128.Height = 0.1875F;
            this.Label128.HyperLink = "";
            this.Label128.Left = 4.75F;
            this.Label128.Name = "Label128";
            this.Label128.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label128.Text = "Dealer";
            this.Label128.Top = 3.25F;
            this.Label128.Width = 0.9375F;
            // 
            // txtPrintDate
            // 
            this.txtPrintDate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPrintDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPrintDate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPrintDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPrintDate.Border.RightColor = System.Drawing.Color.Black;
            this.txtPrintDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPrintDate.Border.TopColor = System.Drawing.Color.Black;
            this.txtPrintDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPrintDate.DataField = "PrintDate";
            this.txtPrintDate.Height = 0.1875F;
            this.txtPrintDate.Left = 5.875F;
            this.txtPrintDate.MultiLine = false;
            this.txtPrintDate.Name = "txtPrintDate";
            this.txtPrintDate.OutputFormat = resources.GetString("txtPrintDate.OutputFormat");
            this.txtPrintDate.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; vertical-align: top; ";
            this.txtPrintDate.Text = null;
            this.txtPrintDate.Top = 2.625F;
            this.txtPrintDate.Width = 1.75F;
            // 
            // txtCustomerNumber
            // 
            this.txtCustomerNumber.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCustomerNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomerNumber.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCustomerNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomerNumber.Border.RightColor = System.Drawing.Color.Black;
            this.txtCustomerNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomerNumber.Border.TopColor = System.Drawing.Color.Black;
            this.txtCustomerNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomerNumber.DataField = "CustomerNo";
            this.txtCustomerNumber.Height = 0.1875F;
            this.txtCustomerNumber.Left = 5.875F;
            this.txtCustomerNumber.MultiLine = false;
            this.txtCustomerNumber.Name = "txtCustomerNumber";
            this.txtCustomerNumber.OutputFormat = resources.GetString("txtCustomerNumber.OutputFormat");
            this.txtCustomerNumber.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; vertical-align: top; ";
            this.txtCustomerNumber.Text = null;
            this.txtCustomerNumber.Top = 2.75F;
            this.txtCustomerNumber.Width = 1.75F;
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
            this.txtAmountDue.Left = 5.875F;
            this.txtAmountDue.MultiLine = false;
            this.txtAmountDue.Name = "txtAmountDue";
            this.txtAmountDue.OutputFormat = resources.GetString("txtAmountDue.OutputFormat");
            this.txtAmountDue.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; vertical-align: top; ";
            this.txtAmountDue.Text = null;
            this.txtAmountDue.Top = 3F;
            this.txtAmountDue.Width = 1.75F;
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
            this.txtAgent.DataField = "AgentDesc";
            this.txtAgent.Height = 0.1875F;
            this.txtAgent.Left = 5.875F;
            this.txtAgent.MultiLine = false;
            this.txtAgent.Name = "txtAgent";
            this.txtAgent.OutputFormat = resources.GetString("txtAgent.OutputFormat");
            this.txtAgent.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; vertical-align: top; ";
            this.txtAgent.Text = null;
            this.txtAgent.Top = 3.125F;
            this.txtAgent.Width = 2F;
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
            this.txtDealer.DataField = "CompanyDealerDesc";
            this.txtDealer.Height = 0.1875F;
            this.txtDealer.Left = 5.875F;
            this.txtDealer.MultiLine = false;
            this.txtDealer.Name = "txtDealer";
            this.txtDealer.OutputFormat = resources.GetString("txtDealer.OutputFormat");
            this.txtDealer.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; vertical-align: top; ";
            this.txtDealer.Text = null;
            this.txtDealer.Top = 3.25F;
            this.txtDealer.Width = 2F;
            // 
            // Line215
            // 
            this.Line215.Border.BottomColor = System.Drawing.Color.Black;
            this.Line215.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line215.Border.LeftColor = System.Drawing.Color.Black;
            this.Line215.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line215.Border.RightColor = System.Drawing.Color.Black;
            this.Line215.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line215.Border.TopColor = System.Drawing.Color.Black;
            this.Line215.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line215.Height = 0F;
            this.Line215.Left = 4.6875F;
            this.Line215.LineWeight = 1F;
            this.Line215.Name = "Line215";
            this.Line215.Top = 3.5625F;
            this.Line215.Width = 3.25F;
            this.Line215.X1 = 4.6875F;
            this.Line215.X2 = 7.9375F;
            this.Line215.Y1 = 3.5625F;
            this.Line215.Y2 = 3.5625F;
            // 
            // Label138
            // 
            this.Label138.Border.BottomColor = System.Drawing.Color.Black;
            this.Label138.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label138.Border.LeftColor = System.Drawing.Color.Black;
            this.Label138.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label138.Border.RightColor = System.Drawing.Color.Black;
            this.Label138.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label138.Border.TopColor = System.Drawing.Color.Black;
            this.Label138.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label138.Height = 0.1875F;
            this.Label138.HyperLink = "";
            this.Label138.Left = 2.072917F;
            this.Label138.Name = "Label138";
            this.Label138.Style = "text-align: center; font-weight: bold; font-size: 11pt; ";
            this.Label138.Text = "AVISO DE CANCELACION";
            this.Label138.Top = 1.5625F;
            this.Label138.Width = 4.125F;
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
            this.Label139.Height = 0.1875F;
            this.Label139.HyperLink = "";
            this.Label139.Left = 2.0625F;
            this.Label139.Name = "Label139";
            this.Label139.Style = "text-align: center; font-weight: bold; font-size: 11pt; ";
            this.Label139.Text = "CANCELLATION NOTICE";
            this.Label139.Top = 1.75F;
            this.Label139.Width = 4.125F;
            // 
            // Label129
            // 
            this.Label129.Border.BottomColor = System.Drawing.Color.Black;
            this.Label129.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label129.Border.LeftColor = System.Drawing.Color.Black;
            this.Label129.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label129.Border.RightColor = System.Drawing.Color.Black;
            this.Label129.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label129.Border.TopColor = System.Drawing.Color.Black;
            this.Label129.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label129.Height = 0.25F;
            this.Label129.HyperLink = "";
            this.Label129.Left = 0.4375F;
            this.Label129.Name = "Label129";
            this.Label129.Style = "text-align: center; font-weight: bold; background-color: LightGrey; font-size: 9." +
                "75pt; ";
            this.Label129.Text = "Description";
            this.Label129.Top = 5.1875F;
            this.Label129.Width = 1.75F;
            // 
            // Label130
            // 
            this.Label130.Border.BottomColor = System.Drawing.Color.Black;
            this.Label130.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label130.Border.LeftColor = System.Drawing.Color.Black;
            this.Label130.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label130.Border.RightColor = System.Drawing.Color.Black;
            this.Label130.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label130.Border.TopColor = System.Drawing.Color.Black;
            this.Label130.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label130.Height = 0.25F;
            this.Label130.HyperLink = "";
            this.Label130.Left = 2.1875F;
            this.Label130.Name = "Label130";
            this.Label130.Style = "text-align: center; font-weight: bold; background-color: LightGrey; font-size: 9." +
                "75pt; ";
            this.Label130.Text = "Dealer";
            this.Label130.Top = 5.1875F;
            this.Label130.Width = 1F;
            // 
            // Label131
            // 
            this.Label131.Border.BottomColor = System.Drawing.Color.Black;
            this.Label131.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label131.Border.LeftColor = System.Drawing.Color.Black;
            this.Label131.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label131.Border.RightColor = System.Drawing.Color.Black;
            this.Label131.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label131.Border.TopColor = System.Drawing.Color.Black;
            this.Label131.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label131.Height = 0.25F;
            this.Label131.HyperLink = "";
            this.Label131.Left = 3.1875F;
            this.Label131.Name = "Label131";
            this.Label131.Style = "text-align: center; font-weight: bold; background-color: LightGrey; font-size: 9." +
                "75pt; ";
            this.Label131.Text = "Effective Date";
            this.Label131.Top = 5.1875F;
            this.Label131.Width = 1.1875F;
            // 
            // Label132
            // 
            this.Label132.Border.BottomColor = System.Drawing.Color.Black;
            this.Label132.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label132.Border.LeftColor = System.Drawing.Color.Black;
            this.Label132.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label132.Border.RightColor = System.Drawing.Color.Black;
            this.Label132.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label132.Border.TopColor = System.Drawing.Color.Black;
            this.Label132.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label132.Height = 0.25F;
            this.Label132.HyperLink = "";
            this.Label132.Left = 4.375F;
            this.Label132.Name = "Label132";
            this.Label132.Style = "text-align: center; font-weight: bold; background-color: LightGrey; font-size: 9." +
                "75pt; ";
            this.Label132.Text = "Expiration Date";
            this.Label132.Top = 5.1875F;
            this.Label132.Width = 1.375F;
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
            this.Label133.Height = 0.25F;
            this.Label133.HyperLink = "";
            this.Label133.Left = 5.75F;
            this.Label133.Name = "Label133";
            this.Label133.Style = "text-align: center; font-weight: bold; background-color: LightGrey; font-size: 9." +
                "75pt; ";
            this.Label133.Text = "Charge";
            this.Label133.Top = 5.1875F;
            this.Label133.Width = 1.125F;
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
            this.Label134.Height = 0.25F;
            this.Label134.HyperLink = "";
            this.Label134.Left = 6.875F;
            this.Label134.Name = "Label134";
            this.Label134.Style = "text-align: center; font-weight: bold; background-color: LightGrey; font-size: 9." +
                "75pt; ";
            this.Label134.Text = "Credit";
            this.Label134.Top = 5.1875F;
            this.Label134.Width = 1.0625F;
            // 
            // Line216
            // 
            this.Line216.Border.BottomColor = System.Drawing.Color.Black;
            this.Line216.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line216.Border.LeftColor = System.Drawing.Color.Black;
            this.Line216.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line216.Border.RightColor = System.Drawing.Color.Black;
            this.Line216.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line216.Border.TopColor = System.Drawing.Color.Black;
            this.Line216.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line216.Height = 0.6875F;
            this.Line216.Left = 2.1875F;
            this.Line216.LineWeight = 1F;
            this.Line216.Name = "Line216";
            this.Line216.Top = 5.1875F;
            this.Line216.Width = 0F;
            this.Line216.X1 = 2.1875F;
            this.Line216.X2 = 2.1875F;
            this.Line216.Y1 = 5.875F;
            this.Line216.Y2 = 5.1875F;
            // 
            // Line217
            // 
            this.Line217.Border.BottomColor = System.Drawing.Color.Black;
            this.Line217.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line217.Border.LeftColor = System.Drawing.Color.Black;
            this.Line217.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line217.Border.RightColor = System.Drawing.Color.Black;
            this.Line217.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line217.Border.TopColor = System.Drawing.Color.Black;
            this.Line217.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line217.Height = 0.6875F;
            this.Line217.Left = 3.125F;
            this.Line217.LineWeight = 1F;
            this.Line217.Name = "Line217";
            this.Line217.Top = 5.1875F;
            this.Line217.Width = 0F;
            this.Line217.X1 = 3.125F;
            this.Line217.X2 = 3.125F;
            this.Line217.Y1 = 5.875F;
            this.Line217.Y2 = 5.1875F;
            // 
            // Line219
            // 
            this.Line219.Border.BottomColor = System.Drawing.Color.Black;
            this.Line219.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line219.Border.LeftColor = System.Drawing.Color.Black;
            this.Line219.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line219.Border.RightColor = System.Drawing.Color.Black;
            this.Line219.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line219.Border.TopColor = System.Drawing.Color.Black;
            this.Line219.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line219.Height = 0.6875F;
            this.Line219.Left = 5.75F;
            this.Line219.LineWeight = 1F;
            this.Line219.Name = "Line219";
            this.Line219.Top = 5.1875F;
            this.Line219.Width = 0F;
            this.Line219.X1 = 5.75F;
            this.Line219.X2 = 5.75F;
            this.Line219.Y1 = 5.875F;
            this.Line219.Y2 = 5.1875F;
            // 
            // Line220
            // 
            this.Line220.Border.BottomColor = System.Drawing.Color.Black;
            this.Line220.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line220.Border.LeftColor = System.Drawing.Color.Black;
            this.Line220.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line220.Border.RightColor = System.Drawing.Color.Black;
            this.Line220.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line220.Border.TopColor = System.Drawing.Color.Black;
            this.Line220.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line220.Height = 0.6875F;
            this.Line220.Left = 6.875F;
            this.Line220.LineWeight = 1F;
            this.Line220.Name = "Line220";
            this.Line220.Top = 5.1875F;
            this.Line220.Width = 0F;
            this.Line220.X1 = 6.875F;
            this.Line220.X2 = 6.875F;
            this.Line220.Y1 = 5.875F;
            this.Line220.Y2 = 5.1875F;
            // 
            // Line221
            // 
            this.Line221.Border.BottomColor = System.Drawing.Color.Black;
            this.Line221.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line221.Border.LeftColor = System.Drawing.Color.Black;
            this.Line221.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line221.Border.RightColor = System.Drawing.Color.Black;
            this.Line221.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line221.Border.TopColor = System.Drawing.Color.Black;
            this.Line221.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line221.Height = 0.6875F;
            this.Line221.Left = 0.4375F;
            this.Line221.LineWeight = 1F;
            this.Line221.Name = "Line221";
            this.Line221.Top = 5.1875F;
            this.Line221.Width = 0F;
            this.Line221.X1 = 0.4375F;
            this.Line221.X2 = 0.4375F;
            this.Line221.Y1 = 5.875F;
            this.Line221.Y2 = 5.1875F;
            // 
            // Line222
            // 
            this.Line222.Border.BottomColor = System.Drawing.Color.Black;
            this.Line222.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line222.Border.LeftColor = System.Drawing.Color.Black;
            this.Line222.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line222.Border.RightColor = System.Drawing.Color.Black;
            this.Line222.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line222.Border.TopColor = System.Drawing.Color.Black;
            this.Line222.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line222.Height = 0.875F;
            this.Line222.Left = 7.9375F;
            this.Line222.LineWeight = 1F;
            this.Line222.Name = "Line222";
            this.Line222.Top = 5.1875F;
            this.Line222.Width = 0F;
            this.Line222.X1 = 7.9375F;
            this.Line222.X2 = 7.9375F;
            this.Line222.Y1 = 6.0625F;
            this.Line222.Y2 = 5.1875F;
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
            this.TextBox1.Height = 0.1875F;
            this.TextBox1.Left = 0.5F;
            this.TextBox1.MultiLine = false;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat");
            this.TextBox1.Style = "text-align: center; font-weight: normal; font-size: 10pt; vertical-align: top; ";
            this.TextBox1.Text = "Mechanical Breakdown";
            this.TextBox1.Top = 5.5F;
            this.TextBox1.Width = 1.5F;
            // 
            // txtCompanyDealer
            // 
            this.txtCompanyDealer.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCompanyDealer.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCompanyDealer.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCompanyDealer.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCompanyDealer.Border.RightColor = System.Drawing.Color.Black;
            this.txtCompanyDealer.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCompanyDealer.Border.TopColor = System.Drawing.Color.Black;
            this.txtCompanyDealer.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCompanyDealer.DataField = "CompanyDealerID";
            this.txtCompanyDealer.Height = 0.1875F;
            this.txtCompanyDealer.Left = 2.25F;
            this.txtCompanyDealer.MultiLine = false;
            this.txtCompanyDealer.Name = "txtCompanyDealer";
            this.txtCompanyDealer.OutputFormat = resources.GetString("txtCompanyDealer.OutputFormat");
            this.txtCompanyDealer.Style = "text-align: center; font-weight: normal; font-size: 10pt; vertical-align: top; ";
            this.txtCompanyDealer.Text = null;
            this.txtCompanyDealer.Top = 5.5F;
            this.txtCompanyDealer.Width = 0.8125F;
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
            this.txtEffectiveDate.DataField = "EffectiveDate";
            this.txtEffectiveDate.Height = 0.1875F;
            this.txtEffectiveDate.Left = 3.1875F;
            this.txtEffectiveDate.MultiLine = false;
            this.txtEffectiveDate.Name = "txtEffectiveDate";
            this.txtEffectiveDate.OutputFormat = resources.GetString("txtEffectiveDate.OutputFormat");
            this.txtEffectiveDate.Style = "text-align: center; font-weight: normal; font-size: 10pt; vertical-align: top; ";
            this.txtEffectiveDate.Text = null;
            this.txtEffectiveDate.Top = 5.5F;
            this.txtEffectiveDate.Width = 1.125F;
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
            this.txtExpirationDate.DataField = "ExpirationDate";
            this.txtExpirationDate.Height = 0.1875F;
            this.txtExpirationDate.Left = 4.5F;
            this.txtExpirationDate.MultiLine = false;
            this.txtExpirationDate.Name = "txtExpirationDate";
            this.txtExpirationDate.OutputFormat = resources.GetString("txtExpirationDate.OutputFormat");
            this.txtExpirationDate.Style = "text-align: center; font-weight: normal; font-size: 10pt; vertical-align: top; ";
            this.txtExpirationDate.Text = null;
            this.txtExpirationDate.Top = 5.5F;
            this.txtExpirationDate.Width = 1.125F;
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
            this.txtCharge.DataField = "DueAmount";
            this.txtCharge.Height = 0.1875F;
            this.txtCharge.Left = 5.8125F;
            this.txtCharge.MultiLine = false;
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.OutputFormat = resources.GetString("txtCharge.OutputFormat");
            this.txtCharge.Style = "text-align: center; font-weight: normal; font-size: 10pt; vertical-align: top; ";
            this.txtCharge.Text = null;
            this.txtCharge.Top = 5.5F;
            this.txtCharge.Width = 1F;
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
            this.Label135.Height = 0.1875F;
            this.Label135.HyperLink = "";
            this.Label135.Left = 0.4375F;
            this.Label135.Name = "Label135";
            this.Label135.Style = "text-align: left; font-weight: bold; font-size: 9.75pt; ";
            this.Label135.Text = "Company:";
            this.Label135.Top = 5F;
            this.Label135.Width = 0.75F;
            // 
            // Line223
            // 
            this.Line223.Border.BottomColor = System.Drawing.Color.Black;
            this.Line223.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line223.Border.LeftColor = System.Drawing.Color.Black;
            this.Line223.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line223.Border.RightColor = System.Drawing.Color.Black;
            this.Line223.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line223.Border.TopColor = System.Drawing.Color.Black;
            this.Line223.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line223.Height = 0F;
            this.Line223.Left = 0.4444444F;
            this.Line223.LineWeight = 1F;
            this.Line223.Name = "Line223";
            this.Line223.Top = 5.194445F;
            this.Line223.Width = 7.500001F;
            this.Line223.X1 = 0.4444444F;
            this.Line223.X2 = 7.944445F;
            this.Line223.Y1 = 5.194445F;
            this.Line223.Y2 = 5.194445F;
            // 
            // Label137
            // 
            this.Label137.Border.BottomColor = System.Drawing.Color.Black;
            this.Label137.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label137.Border.LeftColor = System.Drawing.Color.Black;
            this.Label137.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label137.Border.RightColor = System.Drawing.Color.Black;
            this.Label137.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label137.Border.TopColor = System.Drawing.Color.Black;
            this.Label137.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label137.Height = 0.1875F;
            this.Label137.HyperLink = "";
            this.Label137.Left = 4.375F;
            this.Label137.Name = "Label137";
            this.Label137.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label137.Text = "BALANCE DUE";
            this.Label137.Top = 5.875F;
            this.Label137.Width = 1.375F;
            // 
            // txtBalanceDue
            // 
            this.txtBalanceDue.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBalanceDue.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBalanceDue.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBalanceDue.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBalanceDue.Border.RightColor = System.Drawing.Color.Black;
            this.txtBalanceDue.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBalanceDue.Border.TopColor = System.Drawing.Color.Black;
            this.txtBalanceDue.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBalanceDue.DataField = "DueAmount";
            this.txtBalanceDue.Height = 0.1875F;
            this.txtBalanceDue.Left = 5.8125F;
            this.txtBalanceDue.MultiLine = false;
            this.txtBalanceDue.Name = "txtBalanceDue";
            this.txtBalanceDue.OutputFormat = resources.GetString("txtBalanceDue.OutputFormat");
            this.txtBalanceDue.Style = "text-align: center; font-weight: normal; font-size: 10pt; vertical-align: top; ";
            this.txtBalanceDue.Text = null;
            this.txtBalanceDue.Top = 5.875F;
            this.txtBalanceDue.Width = 1F;
            // 
            // Line218
            // 
            this.Line218.Border.BottomColor = System.Drawing.Color.Black;
            this.Line218.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line218.Border.LeftColor = System.Drawing.Color.Black;
            this.Line218.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line218.Border.RightColor = System.Drawing.Color.Black;
            this.Line218.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line218.Border.TopColor = System.Drawing.Color.Black;
            this.Line218.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line218.Height = 0.875F;
            this.Line218.Left = 4.375F;
            this.Line218.LineWeight = 1F;
            this.Line218.Name = "Line218";
            this.Line218.Top = 5.1875F;
            this.Line218.Width = 0F;
            this.Line218.X1 = 4.375F;
            this.Line218.X2 = 4.375F;
            this.Line218.Y1 = 6.0625F;
            this.Line218.Y2 = 5.1875F;
            // 
            // Line224
            // 
            this.Line224.Border.BottomColor = System.Drawing.Color.Black;
            this.Line224.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line224.Border.LeftColor = System.Drawing.Color.Black;
            this.Line224.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line224.Border.RightColor = System.Drawing.Color.Black;
            this.Line224.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line224.Border.TopColor = System.Drawing.Color.Black;
            this.Line224.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line224.Height = 0F;
            this.Line224.Left = 0.4375F;
            this.Line224.LineWeight = 1F;
            this.Line224.Name = "Line224";
            this.Line224.Top = 5.875F;
            this.Line224.Width = 7.5F;
            this.Line224.X1 = 0.4375F;
            this.Line224.X2 = 7.9375F;
            this.Line224.Y1 = 5.875F;
            this.Line224.Y2 = 5.875F;
            // 
            // Line225
            // 
            this.Line225.Border.BottomColor = System.Drawing.Color.Black;
            this.Line225.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line225.Border.LeftColor = System.Drawing.Color.Black;
            this.Line225.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line225.Border.RightColor = System.Drawing.Color.Black;
            this.Line225.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line225.Border.TopColor = System.Drawing.Color.Black;
            this.Line225.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line225.Height = 0F;
            this.Line225.Left = 4.381945F;
            this.Line225.LineWeight = 1F;
            this.Line225.Name = "Line225";
            this.Line225.Top = 6.069445F;
            this.Line225.Width = 3.5625F;
            this.Line225.X1 = 4.381945F;
            this.Line225.X2 = 7.944445F;
            this.Line225.Y1 = 6.069445F;
            this.Line225.Y2 = 6.069445F;
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
            this.Label75.Left = 1.5625F;
            this.Label75.MultiLine = false;
            this.Label75.Name = "Label75";
            this.Label75.Style = "text-align: center; font-weight: bold; font-size: 11.25pt; font-family: Times New" +
                " Roman; ";
            this.Label75.Text = "PUERTO RICO MEDICAL DEFENSE INSURANCE COMPANY";
            this.Label75.Top = 0.625F;
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
            this.Label77.Left = 1.5625F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-align: center; font-weight: bold; font-size: 6pt; font-family: Times New Rom" +
                "an; ";
            this.Label77.Text = "";
            this.Label77.Top = 0.875F;
            this.Label77.Width = 5.125F;
            // 
            // Label
            // 
            this.Label.Border.BottomColor = System.Drawing.Color.Black;
            this.Label.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.LeftColor = System.Drawing.Color.Black;
            this.Label.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.RightColor = System.Drawing.Color.Black;
            this.Label.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.TopColor = System.Drawing.Color.Black;
            this.Label.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Height = 0.1875F;
            this.Label.HyperLink = "";
            this.Label.Left = 1.15625F;
            this.Label.MultiLine = false;
            this.Label.Name = "Label";
            this.Label.Style = "text-align: left; font-weight: bold; font-size: 9.75pt; font-family: Times New Ro" +
                "man; ";
            this.Label.Text = "LAS VISTAS INSURANCE AGENCY, CORP.";
            this.Label.Top = 5F;
            this.Label.Width = 5.125F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TextBox2,
            this.TextBox3,
            this.TextBox4,
            this.TextBox5,
            this.txtEffecDate,
            this.TextBox6,
            this.TextBox7,
            this.TextBox8,
            this.TextBox9,
            this.TextBox10,
            this.TextBox11,
            this.TextBox12,
            this.txtEffetive,
            this.TextBox13,
            this.TextBox14,
            this.TextBox15,
            this.TextBox16,
            this.TextBox17,
            this.TextBox18,
            this.TextBox19,
            this.Label84,
            this.Label85,
            this.Label86,
            this.TextBox20});
            this.PageFooter.Height = 4.009722F;
            this.PageFooter.Name = "PageFooter";
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
            this.TextBox2.Height = 0.1875F;
            this.TextBox2.Left = 0.4375F;
            this.TextBox2.MultiLine = false;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat");
            this.TextBox2.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f" +
                "amily: Arial; vertical-align: top; ";
            this.TextBox2.Text = "Señor(es)";
            this.TextBox2.Top = 0F;
            this.TextBox2.Width = 0.5625F;
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
            this.TextBox3.Height = 0.1875F;
            this.TextBox3.Left = 0.4375F;
            this.TextBox3.MultiLine = false;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat");
            this.TextBox3.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f" +
                "amily: Arial; vertical-align: top; ";
            this.TextBox3.Text = "Sir(s):";
            this.TextBox3.Top = 0.125F;
            this.TextBox3.Width = 0.5625F;
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
            this.TextBox4.Height = 0.25F;
            this.TextBox4.Left = 0.4375F;
            this.TextBox4.MultiLine = false;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat");
            this.TextBox4.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" +
                "ly: Arial; vertical-align: top; ";
            this.TextBox4.Text = "Por este medio se le notifica que de acuaerdo con los términos establecidos en es" +
                "ta póliza, la misma será cancelada";
            this.TextBox4.Top = 0.3125F;
            this.TextBox4.Width = 7.4375F;
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
            this.TextBox5.Height = 0.25F;
            this.TextBox5.Left = 0.4375F;
            this.TextBox5.MultiLine = false;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat");
            this.TextBox5.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" +
                "ly: Arial; vertical-align: top; ";
            this.TextBox5.Text = "efectivo";
            this.TextBox5.Top = 0.4375F;
            this.TextBox5.Width = 0.5F;
            // 
            // txtEffecDate
            // 
            this.txtEffecDate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEffecDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEffecDate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEffecDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEffecDate.Border.RightColor = System.Drawing.Color.Black;
            this.txtEffecDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEffecDate.Border.TopColor = System.Drawing.Color.Black;
            this.txtEffecDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEffecDate.DataField = "CancDate";
            this.txtEffecDate.Height = 0.1875F;
            this.txtEffecDate.Left = 0.875F;
            this.txtEffecDate.MultiLine = false;
            this.txtEffecDate.Name = "txtEffecDate";
            this.txtEffecDate.OutputFormat = resources.GetString("txtEffecDate.OutputFormat");
            this.txtEffecDate.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: Arial; vertical-align: top; ";
            this.txtEffecDate.Text = "txtEffecDate";
            this.txtEffecDate.Top = 0.4375F;
            this.txtEffecDate.Width = 0.875F;
            // 
            // TextBox6
            // 
            this.TextBox6.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox6.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox6.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox6.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox6.Height = 0.25F;
            this.TextBox6.Left = 1.75F;
            this.TextBox6.MultiLine = false;
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat");
            this.TextBox6.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" +
                "ly: Arial; vertical-align: top; ";
            this.TextBox6.Text = " a la misma hora en que la póliza entro en vigor,  de no recibirse";
            this.TextBox6.Top = 0.4375F;
            this.TextBox6.Width = 3.625F;
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
            this.TextBox7.Left = 5.375F;
            this.TextBox7.MultiLine = false;
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat");
            this.TextBox7.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; font-family" +
                ": Arial; vertical-align: top; ";
            this.TextBox7.Text = "la  prima  devengada";
            this.TextBox7.Top = 0.4375F;
            this.TextBox7.Width = 1.375F;
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
            this.TextBox8.Height = 0.1875F;
            this.TextBox8.Left = 6.625F;
            this.TextBox8.MultiLine = false;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.OutputFormat = resources.GetString("TextBox8.OutputFormat");
            this.TextBox8.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" +
                "ly: Arial; vertical-align: top; ";
            this.TextBox8.Text = "con";
            this.TextBox8.Top = 0.4375F;
            this.TextBox8.Width = 0.5F;
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
            this.TextBox9.Height = 0.25F;
            this.TextBox9.Left = 0.4375F;
            this.TextBox9.MultiLine = false;
            this.TextBox9.Name = "TextBox9";
            this.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat");
            this.TextBox9.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" +
                "ly: Arial; vertical-align: top; ";
            this.TextBox9.Text = "anterioridad a la dicha fecha. Este aviso se envía mediante la Forma 3877 de la O" +
                "ficina De Correos de Estados Unidos ";
            this.TextBox9.Top = 0.5625F;
            this.TextBox9.Width = 7.4375F;
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
            this.TextBox10.Height = 0.25F;
            this.TextBox10.Left = 0.4375F;
            this.TextBox10.MultiLine = false;
            this.TextBox10.Name = "TextBox10";
            this.TextBox10.OutputFormat = resources.GetString("TextBox10.OutputFormat");
            this.TextBox10.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" +
                "ly: Arial; vertical-align: top; ";
            this.TextBox10.Text = "retenida en esta oficina. U.S.P.O. la Forma 3877 es retenida en la Oficina Del Ag" +
                "ente según requerido por el ";
            this.TextBox10.Top = 0.6875F;
            this.TextBox10.Width = 7.4375F;
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
            this.TextBox11.Height = 0.25F;
            this.TextBox11.Left = 0.4375F;
            this.TextBox11.MultiLine = false;
            this.TextBox11.Name = "TextBox11";
            this.TextBox11.OutputFormat = resources.GetString("TextBox11.OutputFormat");
            this.TextBox11.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" +
                "ly: Arial; vertical-align: top; ";
            this.TextBox11.Text = "Comisionado Del Seguro.";
            this.TextBox11.Top = 0.8125F;
            this.TextBox11.Width = 7.4375F;
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
            this.TextBox12.Height = 0.25F;
            this.TextBox12.Left = 0.4375F;
            this.TextBox12.MultiLine = false;
            this.TextBox12.Name = "TextBox12";
            this.TextBox12.OutputFormat = resources.GetString("TextBox12.OutputFormat");
            this.TextBox12.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" +
                "ly: Arial; vertical-align: top; ";
            this.TextBox12.Text = "You are hereby  notified that accordance with the terms of the contract,  the pol" +
                "icy will be cancelled effective";
            this.TextBox12.Top = 1F;
            this.TextBox12.Width = 7.4375F;
            // 
            // txtEffetive
            // 
            this.txtEffetive.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEffetive.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEffetive.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEffetive.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEffetive.Border.RightColor = System.Drawing.Color.Black;
            this.txtEffetive.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEffetive.Border.TopColor = System.Drawing.Color.Black;
            this.txtEffetive.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEffetive.DataField = "CancDate";
            this.txtEffetive.Height = 0.1875F;
            this.txtEffetive.Left = 0.4375F;
            this.txtEffetive.MultiLine = false;
            this.txtEffetive.Name = "txtEffetive";
            this.txtEffetive.OutputFormat = resources.GetString("txtEffetive.OutputFormat");
            this.txtEffetive.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; font-family" +
                ": Arial; vertical-align: top; ";
            this.txtEffetive.Text = "txtEffetive";
            this.txtEffetive.Top = 1.125F;
            this.txtEffetive.Width = 0.6875F;
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
            this.TextBox13.Height = 0.125F;
            this.TextBox13.Left = 1.125F;
            this.TextBox13.MultiLine = false;
            this.TextBox13.Name = "TextBox13";
            this.TextBox13.OutputFormat = resources.GetString("TextBox13.OutputFormat");
            this.TextBox13.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" +
                "ly: Arial; vertical-align: top; ";
            this.TextBox13.Text = "at the same time of day as the policy became effective, unless premium in the ful" +
                "l amount due is received";
            this.TextBox13.Top = 1.125F;
            this.TextBox13.Width = 6.75F;
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
            this.TextBox14.Height = 0.25F;
            this.TextBox14.Left = 0.4375F;
            this.TextBox14.MultiLine = false;
            this.TextBox14.Name = "TextBox14";
            this.TextBox14.OutputFormat = resources.GetString("TextBox14.OutputFormat");
            this.TextBox14.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" +
                "ly: Arial; vertical-align: top; ";
            this.TextBox14.Text = "prior to that. This notice is sent by means of the form 3877 of the United States" +
                " Post Office Retained in this Office.";
            this.TextBox14.Top = 1.25F;
            this.TextBox14.Width = 7.4375F;
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
            this.TextBox15.Height = 0.25F;
            this.TextBox15.Left = 0.4375F;
            this.TextBox15.MultiLine = false;
            this.TextBox15.Name = "TextBox15";
            this.TextBox15.OutputFormat = resources.GetString("TextBox15.OutputFormat");
            this.TextBox15.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" +
                "ly: Arial; vertical-align: top; ";
            this.TextBox15.Text = "U.S.P.O form 3877 Retained is Agent\'s Office as Requiered by Commissioner of Insu" +
                "rance.";
            this.TextBox15.Top = 1.375F;
            this.TextBox15.Width = 7.4375F;
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
            this.TextBox16.Height = 0.25F;
            this.TextBox16.Left = 0.4375F;
            this.TextBox16.MultiLine = false;
            this.TextBox16.Name = "TextBox16";
            this.TextBox16.OutputFormat = resources.GetString("TextBox16.OutputFormat");
            this.TextBox16.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" +
                "ly: Arial; vertical-align: top; ";
            this.TextBox16.Text = "Copia de esta notificación se envío a : / Copy of this notice has been sent to:";
            this.TextBox16.Top = 1.625F;
            this.TextBox16.Width = 7.4375F;
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
            this.TextBox17.Left = 0.4375F;
            this.TextBox17.MultiLine = false;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat");
            this.TextBox17.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" +
                "ly: Arial; vertical-align: top; ";
            this.TextBox17.Text = "Acreedor Hipotecario / Mortgage:";
            this.TextBox17.Top = 1.75F;
            this.TextBox17.Width = 1.875F;
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
            this.TextBox18.Height = 0.25F;
            this.TextBox18.Left = 0.4375F;
            this.TextBox18.MultiLine = false;
            this.TextBox18.Name = "TextBox18";
            this.TextBox18.OutputFormat = resources.GetString("TextBox18.OutputFormat");
            this.TextBox18.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" +
                "ly: Arial; vertical-align: top; ";
            this.TextBox18.Text = "Favor de devolver esta hoja con su pago para evitar la cancelación.";
            this.TextBox18.Top = 2.0625F;
            this.TextBox18.Width = 7.4375F;
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
            this.TextBox19.Height = 0.25F;
            this.TextBox19.Left = 0.4375F;
            this.TextBox19.MultiLine = false;
            this.TextBox19.Name = "TextBox19";
            this.TextBox19.OutputFormat = resources.GetString("TextBox19.OutputFormat");
            this.TextBox19.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" +
                "ly: Arial; vertical-align: top; ";
            this.TextBox19.Text = "Please returned this page wiht the payment to avoid cancellation.";
            this.TextBox19.Top = 2.1875F;
            this.TextBox19.Width = 7.4375F;
            // 
            // Label84
            // 
            this.Label84.Border.BottomColor = System.Drawing.Color.Black;
            this.Label84.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label84.Border.LeftColor = System.Drawing.Color.Black;
            this.Label84.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label84.Border.RightColor = System.Drawing.Color.Black;
            this.Label84.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label84.Border.TopColor = System.Drawing.Color.Black;
            this.Label84.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label84.Height = 0.1875F;
            this.Label84.HyperLink = "";
            this.Label84.Left = 4.5F;
            this.Label84.MultiLine = false;
            this.Label84.Name = "Label84";
            this.Label84.Style = "text-decoration: underline; text-align: left; font-weight: bold; font-size: 8pt; " +
                "font-family: Times New Roman; ";
            this.Label84.Text = "Por: ______________________________________";
            this.Label84.Top = 3.375F;
            this.Label84.Width = 2.409091F;
            // 
            // Label85
            // 
            this.Label85.Border.BottomColor = System.Drawing.Color.Black;
            this.Label85.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label85.Border.LeftColor = System.Drawing.Color.Black;
            this.Label85.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label85.Border.RightColor = System.Drawing.Color.Black;
            this.Label85.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label85.Border.TopColor = System.Drawing.Color.Black;
            this.Label85.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label85.Height = 0.1875F;
            this.Label85.HyperLink = "";
            this.Label85.Left = 5F;
            this.Label85.MultiLine = false;
            this.Label85.Name = "Label85";
            this.Label85.Style = "text-decoration: none; text-align: left; font-weight: bold; font-size: 8pt; font-" +
                "family: Times New Roman; ";
            this.Label85.Text = "Representante Autorizado";
            this.Label85.Top = 3.625F;
            this.Label85.Width = 2F;
            // 
            // Label86
            // 
            this.Label86.Border.BottomColor = System.Drawing.Color.Black;
            this.Label86.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label86.Border.LeftColor = System.Drawing.Color.Black;
            this.Label86.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label86.Border.RightColor = System.Drawing.Color.Black;
            this.Label86.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label86.Border.TopColor = System.Drawing.Color.Black;
            this.Label86.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label86.Height = 0.1875F;
            this.Label86.HyperLink = "";
            this.Label86.Left = 5F;
            this.Label86.MultiLine = false;
            this.Label86.Name = "Label86";
            this.Label86.Style = "text-decoration: none; text-align: left; font-weight: bold; font-size: 8pt; font-" +
                "family: Times New Roman; ";
            this.Label86.Text = "en San Juan, Puerto Rico";
            this.Label86.Top = 3.75F;
            this.Label86.Width = 2F;
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
            this.TextBox20.DataField = "BankDesc";
            this.TextBox20.Height = 0.1875F;
            this.TextBox20.Left = 2.375F;
            this.TextBox20.MultiLine = false;
            this.TextBox20.Name = "TextBox20";
            this.TextBox20.OutputFormat = resources.GetString("TextBox20.OutputFormat");
            this.TextBox20.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" +
                "ly: Arial; vertical-align: top; ";
            this.TextBox20.Text = "TextBox20";
            this.TextBox20.Top = 1.75F;
            this.TextBox20.Width = 2.6875F;
            // 
            // CartaCancellationNotice
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.5F;
            this.PageSettings.Margins.Left = 0.2F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.2F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.34375F;
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
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.CartaCancellationNotice_FetchData);
            this.ReportStart += new System.EventHandler(this.CartaCancellationNotice_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.Label78)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerAddr2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerAddr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPolicyNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAddr2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankAddr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label120)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label121)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label122)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSocialSecurity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLoanNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label123)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label124)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label125)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label126)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label127)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label128)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountDue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDealer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label138)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label139)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label129)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyDealer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpirationDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCharge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label137)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalanceDue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffecDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffetive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label84)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label85)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label86)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
