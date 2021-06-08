namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for PrimaryActOfWar.
    /// </summary>
    partial class PrimaryActOfWar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrimaryActOfWar));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.picture1 = new DataDynamics.ActiveReports.Picture();
            this.picture2 = new DataDynamics.ActiveReports.Picture();
            this.shape1 = new DataDynamics.ActiveReports.Shape();
            this.lblCertificate = new DataDynamics.ActiveReports.Label();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCertificate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.picture1,
            this.picture2,
            this.shape1});
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
            // picture2
            // 
            this.picture2.Border.BottomColor = System.Drawing.Color.Black;
            this.picture2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.picture2.Border.LeftColor = System.Drawing.Color.Black;
            this.picture2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.picture2.Border.RightColor = System.Drawing.Color.Black;
            this.picture2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.picture2.Border.TopColor = System.Drawing.Color.Black;
            this.picture2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.picture2.Height = 0.5625F;
            this.picture2.Image = ((System.Drawing.Image)(resources.GetObject("picture2.Image")));
            this.picture2.ImageData = ((System.IO.Stream)(resources.GetObject("picture2.ImageData")));
            this.picture2.Left = 3.364583F;
            this.picture2.LineWeight = 0F;
            this.picture2.Name = "picture2";
            this.picture2.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.picture2.Top = 0.0625F;
            this.picture2.Width = 1.625F;
            // 
            // shape1
            // 
            this.shape1.BackColor = System.Drawing.Color.White;
            this.shape1.Border.BottomColor = System.Drawing.Color.Black;
            this.shape1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shape1.Border.LeftColor = System.Drawing.Color.Black;
            this.shape1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shape1.Border.RightColor = System.Drawing.Color.Black;
            this.shape1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shape1.Border.TopColor = System.Drawing.Color.Black;
            this.shape1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shape1.Height = 0.625F;
            this.shape1.Left = 0.8125F;
            this.shape1.LineColor = System.Drawing.Color.White;
            this.shape1.Name = "shape1";
            this.shape1.RoundingRadius = 9.999999F;
            this.shape1.Top = 0F;
            this.shape1.Width = 2.0625F;
            // 
            // lblCertificate
            // 
            this.lblCertificate.Border.BottomColor = System.Drawing.Color.Black;
            this.lblCertificate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCertificate.Border.LeftColor = System.Drawing.Color.Black;
            this.lblCertificate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCertificate.Border.RightColor = System.Drawing.Color.Black;
            this.lblCertificate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCertificate.Border.TopColor = System.Drawing.Color.Black;
            this.lblCertificate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCertificate.Height = 0.375F;
            this.lblCertificate.HyperLink = null;
            this.lblCertificate.Left = 0.5833335F;
            this.lblCertificate.Name = "lblCertificate";
            this.lblCertificate.Style = "text-align: center; font-weight: bold; font-size: 9pt; ";
            this.lblCertificate.Text = "Hereby it is certified that this is an exact and true copy of the original policy" +
                " no. PP- 50667 issued by PRMDIC in favor of Dr. Horacio Colon Esteva.";
            this.lblCertificate.Top = 0F;
            this.lblCertificate.Visible = false;
            this.lblCertificate.Width = 7.1875F;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Height = 0F;
            this.detail.Name = "detail";
            // 
            // pageFooter
            // 
            this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblCertificate});
            this.pageFooter.Height = 0.375F;
            this.pageFooter.Name = "pageFooter";
            // 
            // PrimaryActOfWar
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
            this.PrintWidth = 8.354167F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCertificate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Picture picture1;
        private DataDynamics.ActiveReports.Picture picture2;
        private DataDynamics.ActiveReports.Shape shape1;
        private DataDynamics.ActiveReports.Label lblCertificate;
    }
}
