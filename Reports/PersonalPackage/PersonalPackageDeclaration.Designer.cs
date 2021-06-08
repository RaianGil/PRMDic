namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for PersonalPackageDeclaration.
    /// </summary>
    partial class PersonalPackageDeclaration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonalPackageDeclaration));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.picture1 = new DataDynamics.ActiveReports.Picture();
            this.txtPolicyNo = new DataDynamics.ActiveReports.TextBox();
            this.txtCustomerName = new DataDynamics.ActiveReports.TextBox();
            this.txtAdds1 = new DataDynamics.ActiveReports.TextBox();
            this.txtAdds2 = new DataDynamics.ActiveReports.TextBox();
            this.txtCustomerNo = new DataDynamics.ActiveReports.TextBox();
            this.txtEffectiveDate = new DataDynamics.ActiveReports.TextBox();
            this.txtExpirationDate = new DataDynamics.ActiveReports.TextBox();
            this.txtPropertiesPremium = new DataDynamics.ActiveReports.TextBox();
            this.txtLiabilityPremium = new DataDynamics.ActiveReports.TextBox();
            this.txtAutoPremium = new DataDynamics.ActiveReports.TextBox();
            this.txtUmbrellaPremium = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalPremium = new DataDynamics.ActiveReports.TextBox();
            this.txtEmision = new DataDynamics.ActiveReports.TextBox();
            this.txtAgent = new DataDynamics.ActiveReports.TextBox();
            this.txtAgency = new DataDynamics.ActiveReports.TextBox();
            this.picture2 = new DataDynamics.ActiveReports.Picture();
            this.lblEnteredBy = new DataDynamics.ActiveReports.Label();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPolicyNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdds1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdds2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpirationDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPropertiesPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLiabilityPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUmbrellaPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEnteredBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.picture1,
            this.txtPolicyNo,
            this.txtCustomerName,
            this.txtAdds1,
            this.txtAdds2,
            this.txtCustomerNo,
            this.txtEffectiveDate,
            this.txtExpirationDate,
            this.txtPropertiesPremium,
            this.txtLiabilityPremium,
            this.txtAutoPremium,
            this.txtUmbrellaPremium,
            this.txtTotalPremium,
            this.txtEmision,
            this.txtAgent,
            this.txtAgency,
            this.picture2,
            this.lblEnteredBy});
            this.pageHeader.Height = 10.34375F;
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Format += new System.EventHandler(this.pageHeader_Format);
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
            this.picture1.Left = 0.1875F;
            this.picture1.LineWeight = 0F;
            this.picture1.Name = "picture1";
            this.picture1.Top = 0.1875F;
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
            this.txtPolicyNo.Left = 2.0625F;
            this.txtPolicyNo.Name = "txtPolicyNo";
            this.txtPolicyNo.Style = "font-size: 9pt; vertical-align: bottom; ";
            this.txtPolicyNo.Text = null;
            this.txtPolicyNo.Top = 1.5F;
            this.txtPolicyNo.Width = 2.0625F;
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
            this.txtCustomerName.DataField = "CustomerName";
            this.txtCustomerName.Height = 0.1875F;
            this.txtCustomerName.Left = 2.0625F;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Style = "font-size: 9pt; ";
            this.txtCustomerName.Text = null;
            this.txtCustomerName.Top = 1.875F;
            this.txtCustomerName.Width = 3.375F;
            // 
            // txtAdds1
            // 
            this.txtAdds1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtAdds1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAdds1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtAdds1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAdds1.Border.RightColor = System.Drawing.Color.Black;
            this.txtAdds1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAdds1.Border.TopColor = System.Drawing.Color.Black;
            this.txtAdds1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAdds1.DataField = "Adds1";
            this.txtAdds1.Height = 0.1875F;
            this.txtAdds1.Left = 2.4375F;
            this.txtAdds1.Name = "txtAdds1";
            this.txtAdds1.Style = "font-size: 8.25pt; ";
            this.txtAdds1.Text = null;
            this.txtAdds1.Top = 2.0625F;
            this.txtAdds1.Width = 3.125F;
            // 
            // txtAdds2
            // 
            this.txtAdds2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtAdds2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAdds2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtAdds2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAdds2.Border.RightColor = System.Drawing.Color.Black;
            this.txtAdds2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAdds2.Border.TopColor = System.Drawing.Color.Black;
            this.txtAdds2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAdds2.DataField = "Adds2";
            this.txtAdds2.Height = 0.1875F;
            this.txtAdds2.Left = 2.4375F;
            this.txtAdds2.Name = "txtAdds2";
            this.txtAdds2.Style = "font-size: 8.25pt; ";
            this.txtAdds2.Text = null;
            this.txtAdds2.Top = 2.25F;
            this.txtAdds2.Width = 3.125F;
            // 
            // txtCustomerNo
            // 
            this.txtCustomerNo.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCustomerNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomerNo.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCustomerNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomerNo.Border.RightColor = System.Drawing.Color.Black;
            this.txtCustomerNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomerNo.Border.TopColor = System.Drawing.Color.Black;
            this.txtCustomerNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomerNo.DataField = "CustomerNo";
            this.txtCustomerNo.Height = 0.1875F;
            this.txtCustomerNo.Left = 6.5F;
            this.txtCustomerNo.Name = "txtCustomerNo";
            this.txtCustomerNo.Style = "font-size: 9pt; vertical-align: top; ";
            this.txtCustomerNo.Text = null;
            this.txtCustomerNo.Top = 2.0625F;
            this.txtCustomerNo.Width = 1.4375F;
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
            this.txtEffectiveDate.Left = 3.8125F;
            this.txtEffectiveDate.Name = "txtEffectiveDate";
            this.txtEffectiveDate.OutputFormat = resources.GetString("txtEffectiveDate.OutputFormat");
            this.txtEffectiveDate.Style = "font-size: 9pt; ";
            this.txtEffectiveDate.Text = null;
            this.txtEffectiveDate.Top = 2.8125F;
            this.txtEffectiveDate.Width = 0.9375F;
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
            this.txtExpirationDate.Left = 5.625F;
            this.txtExpirationDate.Name = "txtExpirationDate";
            this.txtExpirationDate.OutputFormat = resources.GetString("txtExpirationDate.OutputFormat");
            this.txtExpirationDate.Style = "font-size: 9pt; ";
            this.txtExpirationDate.Text = null;
            this.txtExpirationDate.Top = 2.8125F;
            this.txtExpirationDate.Width = 0.9375F;
            // 
            // txtPropertiesPremium
            // 
            this.txtPropertiesPremium.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPropertiesPremium.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPropertiesPremium.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPropertiesPremium.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPropertiesPremium.Border.RightColor = System.Drawing.Color.Black;
            this.txtPropertiesPremium.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPropertiesPremium.Border.TopColor = System.Drawing.Color.Black;
            this.txtPropertiesPremium.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPropertiesPremium.DataField = "PropertiesPremium";
            this.txtPropertiesPremium.Height = 0.1875F;
            this.txtPropertiesPremium.Left = 5.25F;
            this.txtPropertiesPremium.Name = "txtPropertiesPremium";
            this.txtPropertiesPremium.OutputFormat = resources.GetString("txtPropertiesPremium.OutputFormat");
            this.txtPropertiesPremium.Style = "text-align: right; font-size: 9pt; ";
            this.txtPropertiesPremium.Text = null;
            this.txtPropertiesPremium.Top = 4.125F;
            this.txtPropertiesPremium.Width = 1.5625F;
            // 
            // txtLiabilityPremium
            // 
            this.txtLiabilityPremium.Border.BottomColor = System.Drawing.Color.Black;
            this.txtLiabilityPremium.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLiabilityPremium.Border.LeftColor = System.Drawing.Color.Black;
            this.txtLiabilityPremium.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLiabilityPremium.Border.RightColor = System.Drawing.Color.Black;
            this.txtLiabilityPremium.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLiabilityPremium.Border.TopColor = System.Drawing.Color.Black;
            this.txtLiabilityPremium.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLiabilityPremium.DataField = "LiabilityPremium";
            this.txtLiabilityPremium.Height = 0.1875F;
            this.txtLiabilityPremium.Left = 5.25F;
            this.txtLiabilityPremium.Name = "txtLiabilityPremium";
            this.txtLiabilityPremium.OutputFormat = resources.GetString("txtLiabilityPremium.OutputFormat");
            this.txtLiabilityPremium.Style = "text-align: right; font-size: 9pt; ";
            this.txtLiabilityPremium.Text = null;
            this.txtLiabilityPremium.Top = 4.6875F;
            this.txtLiabilityPremium.Width = 1.5625F;
            // 
            // txtAutoPremium
            // 
            this.txtAutoPremium.Border.BottomColor = System.Drawing.Color.Black;
            this.txtAutoPremium.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAutoPremium.Border.LeftColor = System.Drawing.Color.Black;
            this.txtAutoPremium.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAutoPremium.Border.RightColor = System.Drawing.Color.Black;
            this.txtAutoPremium.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAutoPremium.Border.TopColor = System.Drawing.Color.Black;
            this.txtAutoPremium.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAutoPremium.DataField = "AutoPremium";
            this.txtAutoPremium.Height = 0.1875F;
            this.txtAutoPremium.Left = 5.25F;
            this.txtAutoPremium.Name = "txtAutoPremium";
            this.txtAutoPremium.OutputFormat = resources.GetString("txtAutoPremium.OutputFormat");
            this.txtAutoPremium.Style = "text-align: right; font-size: 9pt; ";
            this.txtAutoPremium.Text = null;
            this.txtAutoPremium.Top = 5.25F;
            this.txtAutoPremium.Width = 1.5625F;
            // 
            // txtUmbrellaPremium
            // 
            this.txtUmbrellaPremium.Border.BottomColor = System.Drawing.Color.Black;
            this.txtUmbrellaPremium.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtUmbrellaPremium.Border.LeftColor = System.Drawing.Color.Black;
            this.txtUmbrellaPremium.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtUmbrellaPremium.Border.RightColor = System.Drawing.Color.Black;
            this.txtUmbrellaPremium.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtUmbrellaPremium.Border.TopColor = System.Drawing.Color.Black;
            this.txtUmbrellaPremium.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtUmbrellaPremium.DataField = "UmbrellaPremium";
            this.txtUmbrellaPremium.Height = 0.1875F;
            this.txtUmbrellaPremium.Left = 5.25F;
            this.txtUmbrellaPremium.Name = "txtUmbrellaPremium";
            this.txtUmbrellaPremium.OutputFormat = resources.GetString("txtUmbrellaPremium.OutputFormat");
            this.txtUmbrellaPremium.Style = "text-align: right; font-size: 9pt; ";
            this.txtUmbrellaPremium.Text = null;
            this.txtUmbrellaPremium.Top = 5.875F;
            this.txtUmbrellaPremium.Width = 1.5625F;
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
            this.txtTotalPremium.DataField = "TotalPremium";
            this.txtTotalPremium.Height = 0.1875F;
            this.txtTotalPremium.Left = 5.25F;
            this.txtTotalPremium.Name = "txtTotalPremium";
            this.txtTotalPremium.OutputFormat = resources.GetString("txtTotalPremium.OutputFormat");
            this.txtTotalPremium.Style = "text-align: right; font-size: 9pt; vertical-align: top; ";
            this.txtTotalPremium.Text = null;
            this.txtTotalPremium.Top = 7.3125F;
            this.txtTotalPremium.Width = 1.5625F;
            // 
            // txtEmision
            // 
            this.txtEmision.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEmision.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEmision.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEmision.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEmision.Border.RightColor = System.Drawing.Color.Black;
            this.txtEmision.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEmision.Border.TopColor = System.Drawing.Color.Black;
            this.txtEmision.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEmision.DataField = "EffectiveDate";
            this.txtEmision.Height = 0.1875F;
            this.txtEmision.Left = 1.25F;
            this.txtEmision.Name = "txtEmision";
            this.txtEmision.OutputFormat = resources.GetString("txtEmision.OutputFormat");
            this.txtEmision.Style = "font-size: 9pt; ";
            this.txtEmision.Text = null;
            this.txtEmision.Top = 9.375F;
            this.txtEmision.Width = 0.9375F;
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
            this.txtAgent.Left = 1.8125F;
            this.txtAgent.Name = "txtAgent";
            this.txtAgent.Style = "font-size: 9pt; ";
            this.txtAgent.Text = null;
            this.txtAgent.Top = 9F;
            this.txtAgent.Width = 3F;
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
            this.txtAgency.Left = 1.8125F;
            this.txtAgency.Name = "txtAgency";
            this.txtAgency.Style = "font-size: 9pt; ";
            this.txtAgency.Text = null;
            this.txtAgency.Top = 9.1875F;
            this.txtAgency.Width = 3F;
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
            this.picture2.Height = 0.5F;
            this.picture2.Image = ((System.Drawing.Image)(resources.GetObject("picture2.Image")));
            this.picture2.ImageData = ((System.IO.Stream)(resources.GetObject("picture2.ImageData")));
            this.picture2.Left = 5.25F;
            this.picture2.LineWeight = 0F;
            this.picture2.Name = "picture2";
            this.picture2.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.picture2.Top = 8.8125F;
            this.picture2.Width = 2.0625F;
            // 
            // lblEnteredBy
            // 
            this.lblEnteredBy.Border.BottomColor = System.Drawing.Color.Black;
            this.lblEnteredBy.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblEnteredBy.Border.LeftColor = System.Drawing.Color.Black;
            this.lblEnteredBy.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblEnteredBy.Border.RightColor = System.Drawing.Color.Black;
            this.lblEnteredBy.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblEnteredBy.Border.TopColor = System.Drawing.Color.Black;
            this.lblEnteredBy.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblEnteredBy.Height = 0.1875F;
            this.lblEnteredBy.HyperLink = null;
            this.lblEnteredBy.Left = 5.875F;
            this.lblEnteredBy.Name = "lblEnteredBy";
            this.lblEnteredBy.Style = "text-align: right; font-size: 8pt; ";
            this.lblEnteredBy.Text = "";
            this.lblEnteredBy.Top = 9.9375F;
            this.lblEnteredBy.Width = 2.0625F;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Height = 0.01041667F;
            this.detail.Name = "detail";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0.125F;
            this.pageFooter.Name = "pageFooter";
            // 
            // PersonalPackageDeclaration
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
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.PersonalPackageDeclaration_FetchData);
            this.DataInitialize += new System.EventHandler(this.PersonalPackageDeclaration_DataInitialize);
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPolicyNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdds1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdds2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpirationDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPropertiesPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLiabilityPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUmbrellaPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEnteredBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Picture picture1;
        private DataDynamics.ActiveReports.TextBox txtPolicyNo;
        private DataDynamics.ActiveReports.TextBox txtCustomerName;
        private DataDynamics.ActiveReports.TextBox txtAdds1;
        private DataDynamics.ActiveReports.TextBox txtAdds2;
        private DataDynamics.ActiveReports.TextBox txtCustomerNo;
        private DataDynamics.ActiveReports.TextBox txtEffectiveDate;
        private DataDynamics.ActiveReports.TextBox txtExpirationDate;
        private DataDynamics.ActiveReports.TextBox txtPropertiesPremium;
        private DataDynamics.ActiveReports.TextBox txtLiabilityPremium;
        private DataDynamics.ActiveReports.TextBox txtAutoPremium;
        private DataDynamics.ActiveReports.TextBox txtUmbrellaPremium;
        private DataDynamics.ActiveReports.TextBox txtTotalPremium;
        private DataDynamics.ActiveReports.TextBox txtEmision;
        private DataDynamics.ActiveReports.TextBox txtAgent;
        private DataDynamics.ActiveReports.TextBox txtAgency;
        private DataDynamics.ActiveReports.Picture picture2;
        private DataDynamics.ActiveReports.Label lblEnteredBy;
    }
}
