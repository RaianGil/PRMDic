namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for ActOfWar.
    /// </summary>
    partial class ActOfWar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActOfWar));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.picture1 = new DataDynamics.ActiveReports.Picture();
            this.picture2 = new DataDynamics.ActiveReports.Picture();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.picture1,
            this.picture2,
            this.textBox1});
            this.pageHeader.Height = 10.39583F;
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
            this.picture1.Height = 10.375F;
            this.picture1.Image = ((System.Drawing.Image)(resources.GetObject("picture1.Image")));
            this.picture1.ImageData = ((System.IO.Stream)(resources.GetObject("picture1.ImageData")));
            this.picture1.Left = 0.25F;
            this.picture1.LineWeight = 0F;
            this.picture1.Name = "picture1";
            this.picture1.Top = 0.0625F;
            this.picture1.Width = 7.75F;
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
            this.picture2.Height = 1.375F;
            this.picture2.Image = ((System.Drawing.Image)(resources.GetObject("picture2.Image")));
            this.picture2.ImageData = ((System.IO.Stream)(resources.GetObject("picture2.ImageData")));
            this.picture2.Left = 2.90625F;
            this.picture2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.picture2.LineWeight = 0F;
            this.picture2.Name = "picture2";
            this.picture2.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.picture2.Top = 0.125F;
            this.picture2.Visible = false;
            this.picture2.Width = 2.4375F;
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
            this.textBox1.Height = 0.1875F;
            this.textBox1.Left = 0.8125F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "background-color: White; ";
            this.textBox1.Text = "ASPMM087 0814";
            this.textBox1.Top = 9.875F;
            this.textBox1.Visible = false;
            this.textBox1.Width = 1.4375F;
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
            // ActOfWar
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
            this.PrintWidth = 8.322917F;
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Picture picture1;
        private DataDynamics.ActiveReports.Picture picture2;
        private DataDynamics.ActiveReports.TextBox textBox1;
    }
}
