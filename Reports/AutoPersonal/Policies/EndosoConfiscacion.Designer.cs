namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for EndosoConfiscacion.
    /// </summary>
    partial class EndosoConfiscacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndosoConfiscacion));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.picture1 = new DataDynamics.ActiveReports.Picture();
            this.txtEffectiveDate = new DataDynamics.ActiveReports.TextBox();
            this.txtCustomerName = new DataDynamics.ActiveReports.TextBox();
            this.txtPolicyNo = new DataDynamics.ActiveReports.TextBox();
            this.txtBank = new DataDynamics.ActiveReports.TextBox();
            this.txtCertificate = new DataDynamics.ActiveReports.TextBox();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPolicyNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCertificate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.picture1,
            this.txtEffectiveDate,
            this.txtCustomerName,
            this.txtPolicyNo,
            this.txtBank,
            this.txtCertificate});
            this.pageHeader.Height = 10.0625F;
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
            this.picture1.Height = 10.0625F;
            this.picture1.Image = ((System.Drawing.Image)(resources.GetObject("picture1.Image")));
            this.picture1.ImageData = ((System.IO.Stream)(resources.GetObject("picture1.ImageData")));
            this.picture1.Left = 0F;
            this.picture1.LineWeight = 0F;
            this.picture1.Name = "picture1";
            this.picture1.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.picture1.Top = 0F;
            this.picture1.Width = 8F;
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
            this.txtEffectiveDate.Left = 5.84375F;
            this.txtEffectiveDate.Name = "txtEffectiveDate";
            this.txtEffectiveDate.OutputFormat = resources.GetString("txtEffectiveDate.OutputFormat");
            this.txtEffectiveDate.Style = "font-size: 9pt; ";
            this.txtEffectiveDate.Text = null;
            this.txtEffectiveDate.Top = 8.5625F;
            this.txtEffectiveDate.Width = 0.75F;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCustomerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomerName.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCustomerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomerName.Border.RightColor = System.Drawing.Color.Black;
            this.txtCustomerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomerName.Border.TopColor = System.Drawing.Color.Black;
            this.txtCustomerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomerName.DataField = "PolicyNumber";
            this.txtCustomerName.Height = 0.1875F;
            this.txtCustomerName.Left = 3F;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Style = "font-size: 9pt; vertical-align: bottom; ";
            this.txtCustomerName.Text = null;
            this.txtCustomerName.Top = 8.5625F;
            this.txtCustomerName.Width = 2.5625F;
            // 
            // txtPolicyNo
            // 
            this.txtPolicyNo.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPolicyNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyNo.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPolicyNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyNo.Border.RightColor = System.Drawing.Color.Black;
            this.txtPolicyNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyNo.Border.TopColor = System.Drawing.Color.Black;
            this.txtPolicyNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyNo.DataField = "PolicyNumber";
            this.txtPolicyNo.Height = 0.1875F;
            this.txtPolicyNo.Left = 2F;
            this.txtPolicyNo.Name = "txtPolicyNo";
            this.txtPolicyNo.Style = "font-size: 9pt; vertical-align: bottom; ";
            this.txtPolicyNo.Text = null;
            this.txtPolicyNo.Top = 8.4375F;
            this.txtPolicyNo.Width = 0.8125F;
            // 
            // txtBank
            // 
            this.txtBank.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBank.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBank.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBank.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBank.Border.RightColor = System.Drawing.Color.Black;
            this.txtBank.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBank.Border.TopColor = System.Drawing.Color.Black;
            this.txtBank.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBank.DataField = "Agent";
            this.txtBank.Height = 0.1875F;
            this.txtBank.Left = 2.677083F;
            this.txtBank.Name = "txtBank";
            this.txtBank.Style = "text-decoration: underline; font-size: 9pt; ";
            this.txtBank.Text = null;
            this.txtBank.Top = 7.197917F;
            this.txtBank.Width = 3F;
            // 
            // txtCertificate
            // 
            this.txtCertificate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCertificate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCertificate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCertificate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCertificate.Border.RightColor = System.Drawing.Color.Black;
            this.txtCertificate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCertificate.Border.TopColor = System.Drawing.Color.Black;
            this.txtCertificate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCertificate.Height = 0.1875F;
            this.txtCertificate.Left = 2F;
            this.txtCertificate.Name = "txtCertificate";
            this.txtCertificate.Style = "font-size: 8pt; ";
            this.txtCertificate.Text = null;
            this.txtCertificate.Top = 8.625F;
            this.txtCertificate.Width = 0.875F;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Height = 0.01041667F;
            this.detail.Name = "detail";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0.25F;
            this.pageFooter.Name = "pageFooter";
            // 
            // EndosoConfiscacion
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.270833F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.EndosoConfiscacion_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPolicyNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCertificate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Picture picture1;
        private DataDynamics.ActiveReports.TextBox txtEffectiveDate;
        private DataDynamics.ActiveReports.TextBox txtCustomerName;
        private DataDynamics.ActiveReports.TextBox txtPolicyNo;
        private DataDynamics.ActiveReports.TextBox txtBank;
        private DataDynamics.ActiveReports.TextBox txtCertificate;
    }
}
