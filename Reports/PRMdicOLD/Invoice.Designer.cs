namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for Invoice.
    /// </summary>
    partial class Invoice
    {
        private DataDynamics.ActiveReports.PageHeader pageHeader;
        private DataDynamics.ActiveReports.Detail detail;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Invoice));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.picture1 = new DataDynamics.ActiveReports.Picture();
            this.txtReceiptPolicyNo = new DataDynamics.ActiveReports.TextBox();
            this.txtEntryDate = new DataDynamics.ActiveReports.TextBox();
            this.TxtIndividualName = new DataDynamics.ActiveReports.TextBox();
            this.txtAddress = new DataDynamics.ActiveReports.TextBox();
            this.txtAddress2 = new DataDynamics.ActiveReports.TextBox();
            this.txtAddress3 = new DataDynamics.ActiveReports.TextBox();
            this.txtPolicyType = new DataDynamics.ActiveReports.TextBox();
            this.txtTotAmountHeader = new DataDynamics.ActiveReports.TextBox();
            this.txtReceiptNoDetail = new DataDynamics.ActiveReports.TextBox();
            this.txtEffectiveDate = new DataDynamics.ActiveReports.TextBox();
            this.txtDesc = new DataDynamics.ActiveReports.TextBox();
            this.txtPremium = new DataDynamics.ActiveReports.TextBox();
            this.TxtTotal = new DataDynamics.ActiveReports.TextBox();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.txtSurchargeDesc = new DataDynamics.ActiveReports.TextBox();
            this.txtSurcharge = new DataDynamics.ActiveReports.TextBox();
            this.txtSurchargeDesc2 = new DataDynamics.ActiveReports.TextBox();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceiptPolicyNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtIndividualName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPolicyType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotAmountHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceiptNoDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurchargeDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurcharge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurchargeDesc2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.picture1,
            this.txtReceiptPolicyNo,
            this.txtEntryDate,
            this.TxtIndividualName,
            this.txtAddress,
            this.txtAddress2,
            this.txtAddress3,
            this.txtPolicyType,
            this.txtTotAmountHeader,
            this.txtReceiptNoDetail,
            this.txtEffectiveDate,
            this.txtDesc,
            this.txtPremium,
            this.TxtTotal,
            this.label1,
            this.label2,
            this.txtSurchargeDesc,
            this.txtSurcharge,
            this.txtSurchargeDesc2,
            this.line1,
            this.line2,
            this.textBox1});
            this.pageHeader.Height = 10.3125F;
            this.pageHeader.Name = "pageHeader";
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
            this.picture1.Height = 10.25F;
            this.picture1.Image = ((System.Drawing.Image)(resources.GetObject("picture1.Image")));
            this.picture1.ImageData = ((System.IO.Stream)(resources.GetObject("picture1.ImageData")));
            this.picture1.Left = 0.1875F;
            this.picture1.LineWeight = 0F;
            this.picture1.Name = "picture1";
            this.picture1.Top = 0.0625F;
            this.picture1.Width = 8F;
            // 
            // txtReceiptPolicyNo
            // 
            this.txtReceiptPolicyNo.Border.BottomColor = System.Drawing.Color.Black;
            this.txtReceiptPolicyNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReceiptPolicyNo.Border.LeftColor = System.Drawing.Color.Black;
            this.txtReceiptPolicyNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReceiptPolicyNo.Border.RightColor = System.Drawing.Color.Black;
            this.txtReceiptPolicyNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReceiptPolicyNo.Border.TopColor = System.Drawing.Color.Black;
            this.txtReceiptPolicyNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReceiptPolicyNo.Height = 0.1875F;
            this.txtReceiptPolicyNo.Left = 6.6875F;
            this.txtReceiptPolicyNo.Name = "txtReceiptPolicyNo";
            this.txtReceiptPolicyNo.Style = "font-size: 9pt; ";
            this.txtReceiptPolicyNo.Text = null;
            this.txtReceiptPolicyNo.Top = 1.177083F;
            this.txtReceiptPolicyNo.Width = 1.25F;
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
            this.txtEntryDate.Height = 0.1875F;
            this.txtEntryDate.Left = 6.6875F;
            this.txtEntryDate.Name = "txtEntryDate";
            this.txtEntryDate.Style = "font-size: 9pt; ";
            this.txtEntryDate.Text = null;
            this.txtEntryDate.Top = 1.427083F;
            this.txtEntryDate.Width = 1.25F;
            // 
            // TxtIndividualName
            // 
            this.TxtIndividualName.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtIndividualName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtIndividualName.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtIndividualName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtIndividualName.Border.RightColor = System.Drawing.Color.Black;
            this.TxtIndividualName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtIndividualName.Border.TopColor = System.Drawing.Color.Black;
            this.TxtIndividualName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtIndividualName.Height = 0.1875F;
            this.TxtIndividualName.Left = 0.5F;
            this.TxtIndividualName.Name = "TxtIndividualName";
            this.TxtIndividualName.Style = "font-size: 9pt; ";
            this.TxtIndividualName.Text = null;
            this.TxtIndividualName.Top = 1.75F;
            this.TxtIndividualName.Width = 2.9375F;
            // 
            // txtAddress
            // 
            this.txtAddress.Border.BottomColor = System.Drawing.Color.Black;
            this.txtAddress.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAddress.Border.LeftColor = System.Drawing.Color.Black;
            this.txtAddress.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAddress.Border.RightColor = System.Drawing.Color.Black;
            this.txtAddress.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAddress.Border.TopColor = System.Drawing.Color.Black;
            this.txtAddress.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAddress.Height = 0.1875F;
            this.txtAddress.Left = 0.5F;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Style = "font-size: 9pt; ";
            this.txtAddress.Text = null;
            this.txtAddress.Top = 2F;
            this.txtAddress.Width = 2.9375F;
            // 
            // txtAddress2
            // 
            this.txtAddress2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtAddress2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAddress2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtAddress2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAddress2.Border.RightColor = System.Drawing.Color.Black;
            this.txtAddress2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAddress2.Border.TopColor = System.Drawing.Color.Black;
            this.txtAddress2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAddress2.CanShrink = true;
            this.txtAddress2.Height = 0.1875F;
            this.txtAddress2.Left = 0.5F;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Style = "font-size: 9pt; ";
            this.txtAddress2.Text = null;
            this.txtAddress2.Top = 2.1875F;
            this.txtAddress2.Width = 2.9375F;
            // 
            // txtAddress3
            // 
            this.txtAddress3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtAddress3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAddress3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtAddress3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAddress3.Border.RightColor = System.Drawing.Color.Black;
            this.txtAddress3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAddress3.Border.TopColor = System.Drawing.Color.Black;
            this.txtAddress3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAddress3.CanShrink = true;
            this.txtAddress3.Height = 0.1875F;
            this.txtAddress3.Left = 0.5F;
            this.txtAddress3.Name = "txtAddress3";
            this.txtAddress3.Style = "font-size: 9pt; ";
            this.txtAddress3.Text = null;
            this.txtAddress3.Top = 2.375F;
            this.txtAddress3.Width = 2.9375F;
            // 
            // txtPolicyType
            // 
            this.txtPolicyType.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPolicyType.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyType.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPolicyType.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyType.Border.RightColor = System.Drawing.Color.Black;
            this.txtPolicyType.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyType.Border.TopColor = System.Drawing.Color.Black;
            this.txtPolicyType.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyType.Height = 0.1875F;
            this.txtPolicyType.Left = 4F;
            this.txtPolicyType.Name = "txtPolicyType";
            this.txtPolicyType.Style = "font-size: 9pt; ";
            this.txtPolicyType.Text = null;
            this.txtPolicyType.Top = 2F;
            this.txtPolicyType.Width = 3.1875F;
            // 
            // txtTotAmountHeader
            // 
            this.txtTotAmountHeader.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotAmountHeader.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotAmountHeader.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotAmountHeader.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotAmountHeader.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotAmountHeader.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotAmountHeader.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotAmountHeader.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotAmountHeader.Height = 0.1875F;
            this.txtTotAmountHeader.Left = 4F;
            this.txtTotAmountHeader.Name = "txtTotAmountHeader";
            this.txtTotAmountHeader.Style = "font-weight: bold; font-size: 9pt; ";
            this.txtTotAmountHeader.Text = null;
            this.txtTotAmountHeader.Top = 2.1875F;
            this.txtTotAmountHeader.Width = 3.1875F;
            // 
            // txtReceiptNoDetail
            // 
            this.txtReceiptNoDetail.Border.BottomColor = System.Drawing.Color.Black;
            this.txtReceiptNoDetail.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReceiptNoDetail.Border.LeftColor = System.Drawing.Color.Black;
            this.txtReceiptNoDetail.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReceiptNoDetail.Border.RightColor = System.Drawing.Color.Black;
            this.txtReceiptNoDetail.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReceiptNoDetail.Border.TopColor = System.Drawing.Color.Black;
            this.txtReceiptNoDetail.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReceiptNoDetail.Height = 0.1875F;
            this.txtReceiptNoDetail.Left = 0.4375F;
            this.txtReceiptNoDetail.Name = "txtReceiptNoDetail";
            this.txtReceiptNoDetail.Style = "font-size: 9pt; ";
            this.txtReceiptNoDetail.Text = null;
            this.txtReceiptNoDetail.Top = 3.4375F;
            this.txtReceiptNoDetail.Width = 1.25F;
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
            this.txtEffectiveDate.Height = 0.1875F;
            this.txtEffectiveDate.Left = 1.8125F;
            this.txtEffectiveDate.Name = "txtEffectiveDate";
            this.txtEffectiveDate.Style = "font-size: 9pt; ";
            this.txtEffectiveDate.Text = null;
            this.txtEffectiveDate.Top = 3.4375F;
            this.txtEffectiveDate.Width = 0.9375F;
            // 
            // txtDesc
            // 
            this.txtDesc.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDesc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDesc.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDesc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDesc.Border.RightColor = System.Drawing.Color.Black;
            this.txtDesc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDesc.Border.TopColor = System.Drawing.Color.Black;
            this.txtDesc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDesc.Height = 0.1875F;
            this.txtDesc.Left = 2.875F;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Style = "font-size: 8.5pt; ";
            this.txtDesc.Text = null;
            this.txtDesc.Top = 3.4375F;
            this.txtDesc.Width = 3.9375F;
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
            this.txtPremium.Height = 0.1875F;
            this.txtPremium.Left = 6.9375F;
            this.txtPremium.Name = "txtPremium";
            this.txtPremium.Style = "text-align: right; font-size: 9pt; ";
            this.txtPremium.Text = null;
            this.txtPremium.Top = 3.4375F;
            this.txtPremium.Width = 0.875F;
            // 
            // TxtTotal
            // 
            this.TxtTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotal.Border.RightColor = System.Drawing.Color.Black;
            this.TxtTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotal.Border.TopColor = System.Drawing.Color.Black;
            this.TxtTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotal.Height = 0.1875F;
            this.TxtTotal.Left = 6.9375F;
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.Style = "text-align: right; font-weight: bold; font-size: 9pt; ";
            this.TxtTotal.Text = null;
            this.TxtTotal.Top = 7.75F;
            this.TxtTotal.Width = 0.875F;
            // 
            // label1
            // 
            this.label1.Border.BottomColor = System.Drawing.Color.Black;
            this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.LeftColor = System.Drawing.Color.Black;
            this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.RightColor = System.Drawing.Color.Black;
            this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.TopColor = System.Drawing.Color.Black;
            this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Height = 0.1875F;
            this.label1.HyperLink = null;
            this.label1.Left = 0.5F;
            this.label1.Name = "label1";
            this.label1.Style = "background-color: White; font-size: 8pt; ";
            this.label1.Text = "Make all checks payable to: Resolve General Agency";
            this.label1.Top = 9.25F;
            this.label1.Width = 4.875F;
            // 
            // label2
            // 
            this.label2.Border.BottomColor = System.Drawing.Color.Black;
            this.label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.LeftColor = System.Drawing.Color.Black;
            this.label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.RightColor = System.Drawing.Color.Black;
            this.label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.TopColor = System.Drawing.Color.Black;
            this.label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Height = 0.1875F;
            this.label2.HyperLink = null;
            this.label2.Left = 6.0625F;
            this.label2.Name = "label2";
            this.label2.Style = "background-color: White; font-size: 8pt; ";
            this.label2.Text = "INVOICE";
            this.label2.Top = 1.177083F;
            this.label2.Width = 0.5625F;
            // 
            // txtSurchargeDesc
            // 
            this.txtSurchargeDesc.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSurchargeDesc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSurchargeDesc.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSurchargeDesc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSurchargeDesc.Border.RightColor = System.Drawing.Color.Black;
            this.txtSurchargeDesc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSurchargeDesc.Border.TopColor = System.Drawing.Color.Black;
            this.txtSurchargeDesc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSurchargeDesc.Height = 0.1875F;
            this.txtSurchargeDesc.Left = 2.875F;
            this.txtSurchargeDesc.Name = "txtSurchargeDesc";
            this.txtSurchargeDesc.Style = "text-align: right; font-size: 8.5pt; ";
            this.txtSurchargeDesc.Text = null;
            this.txtSurchargeDesc.Top = 3.875F;
            this.txtSurchargeDesc.Width = 3.9375F;
            // 
            // txtSurcharge
            // 
            this.txtSurcharge.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSurcharge.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSurcharge.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSurcharge.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSurcharge.Border.RightColor = System.Drawing.Color.Black;
            this.txtSurcharge.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSurcharge.Border.TopColor = System.Drawing.Color.Black;
            this.txtSurcharge.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSurcharge.Height = 0.1875F;
            this.txtSurcharge.Left = 6.9375F;
            this.txtSurcharge.Name = "txtSurcharge";
            this.txtSurcharge.Style = "text-align: right; font-size: 9pt; ";
            this.txtSurcharge.Text = null;
            this.txtSurcharge.Top = 3.875F;
            this.txtSurcharge.Width = 0.875F;
            // 
            // txtSurchargeDesc2
            // 
            this.txtSurchargeDesc2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSurchargeDesc2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSurchargeDesc2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSurchargeDesc2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSurchargeDesc2.Border.RightColor = System.Drawing.Color.Black;
            this.txtSurchargeDesc2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSurchargeDesc2.Border.TopColor = System.Drawing.Color.Black;
            this.txtSurchargeDesc2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSurchargeDesc2.Height = 0.625F;
            this.txtSurchargeDesc2.Left = 0.5F;
            this.txtSurchargeDesc2.Name = "txtSurchargeDesc2";
            this.txtSurchargeDesc2.Style = "";
            this.txtSurchargeDesc2.Text = "textBox1";
            this.txtSurchargeDesc2.Top = 8.375F;
            this.txtSurchargeDesc2.Width = 7.4375F;
            // 
            // line1
            // 
            this.line1.Border.BottomColor = System.Drawing.Color.Black;
            this.line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.LeftColor = System.Drawing.Color.Black;
            this.line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.RightColor = System.Drawing.Color.Black;
            this.line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.TopColor = System.Drawing.Color.Black;
            this.line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Height = 0F;
            this.line1.Left = 0.4375F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 7.989583F;
            this.line1.Width = 6.75F;
            this.line1.X1 = 0.4375F;
            this.line1.X2 = 7.1875F;
            this.line1.Y1 = 7.989583F;
            this.line1.Y2 = 7.989583F;
            // 
            // line2
            // 
            this.line2.Border.BottomColor = System.Drawing.Color.Black;
            this.line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.LeftColor = System.Drawing.Color.Black;
            this.line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.RightColor = System.Drawing.Color.Black;
            this.line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.TopColor = System.Drawing.Color.Black;
            this.line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Height = 0.3125F;
            this.line2.Left = 0.4270833F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 7.677083F;
            this.line2.Width = 0F;
            this.line2.X1 = 0.4270833F;
            this.line2.X2 = 0.4270833F;
            this.line2.Y1 = 7.677083F;
            this.line2.Y2 = 7.989583F;
            // 
            // textBox1
            // 
            this.textBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.RightColor = System.Drawing.Color.Black;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.TopColor = System.Drawing.Color.Black;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Height = 0.1979167F;
            this.textBox1.Left = 5.8125F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "font-weight: bold; background-color: White; ";
            this.textBox1.Text = "TOTAL DUE";
            this.textBox1.Top = 7.75F;
            this.textBox1.Width = 1F;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Height = 0F;
            this.detail.Name = "detail";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0.25F;
            this.pageFooter.Name = "pageFooter";
            // 
            // Invoice
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.375F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.Invoice_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceiptPolicyNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtIndividualName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPolicyType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotAmountHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceiptNoDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurchargeDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurcharge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurchargeDesc2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Picture picture1;
        private DataDynamics.ActiveReports.TextBox txtReceiptPolicyNo;
        private DataDynamics.ActiveReports.TextBox txtEntryDate;
        private DataDynamics.ActiveReports.TextBox TxtIndividualName;
        private DataDynamics.ActiveReports.TextBox txtAddress;
        private DataDynamics.ActiveReports.TextBox txtAddress2;
        private DataDynamics.ActiveReports.TextBox txtAddress3;
        private DataDynamics.ActiveReports.TextBox txtPolicyType;
        private DataDynamics.ActiveReports.TextBox txtTotAmountHeader;
        private DataDynamics.ActiveReports.TextBox txtReceiptNoDetail;
        private DataDynamics.ActiveReports.TextBox txtEffectiveDate;
        private DataDynamics.ActiveReports.TextBox txtDesc;
        private DataDynamics.ActiveReports.TextBox txtPremium;
        private DataDynamics.ActiveReports.TextBox TxtTotal;
        private DataDynamics.ActiveReports.Label label1;
        private DataDynamics.ActiveReports.Label label2;
        private DataDynamics.ActiveReports.TextBox txtSurchargeDesc;
        private DataDynamics.ActiveReports.TextBox txtSurcharge;
        private DataDynamics.ActiveReports.TextBox txtSurchargeDesc2;
        private DataDynamics.ActiveReports.Line line1;
        private DataDynamics.ActiveReports.Line line2;
        private DataDynamics.ActiveReports.TextBox textBox1;
    }
}
