namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for CLAUSULAHURACAN.
    /// </summary>
    partial class CLAUSULAHURACAN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CLAUSULAHURACAN));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.picture1 = new DataDynamics.ActiveReports.Picture();
            this.txtPolicyNo = new DataDynamics.ActiveReports.TextBox();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPolicyNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.picture1,
            this.txtPolicyNo});
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
            this.picture1.Top = 0F;
            this.picture1.Width = 8F;
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
            this.txtPolicyNo.Left = 1.9375F;
            this.txtPolicyNo.Name = "txtPolicyNo";
            this.txtPolicyNo.Style = "font-size: 9pt; vertical-align: bottom; ";
            this.txtPolicyNo.Text = null;
            this.txtPolicyNo.Top = 0.5104167F;
            this.txtPolicyNo.Width = 2.3125F;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Height = 0F;
            this.detail.Name = "detail";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0.1458333F;
            this.pageFooter.Name = "pageFooter";
            // 
            // CLAUSULAHURACAN
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
            this.PrintWidth = 8.40625F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.CLAUSULAHURACAN_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPolicyNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Picture picture1;
        private DataDynamics.ActiveReports.TextBox txtPolicyNo;
    }
}
