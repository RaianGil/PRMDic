using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.AutoGuard
{
	public class CancellationNoticeForBank : DataDynamics.ActiveReports.ActiveReport3
	{
		public CancellationNoticeForBank()
		{
			InitializeComponent();
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Line Line140 = null;
		private DataDynamics.ActiveReports.Label Label99 = null;
		private DataDynamics.ActiveReports.Label Label100 = null;
		private DataDynamics.ActiveReports.Label Label101 = null;
		private DataDynamics.ActiveReports.Line Line144 = null;
		private DataDynamics.ActiveReports.Line Line145 = null;
		private DataDynamics.ActiveReports.Line Line146 = null;
		private DataDynamics.ActiveReports.Line Line147 = null;
		private DataDynamics.ActiveReports.Label Label105 = null;
		private DataDynamics.ActiveReports.Label Label106 = null;
		private DataDynamics.ActiveReports.Label Label107 = null;
		private DataDynamics.ActiveReports.Label Label108 = null;
		private DataDynamics.ActiveReports.Label Label109 = null;
		private DataDynamics.ActiveReports.Label Label110 = null;
		private DataDynamics.ActiveReports.Label Label111 = null;
		private DataDynamics.ActiveReports.Label Label112 = null;
		private DataDynamics.ActiveReports.Label Label113 = null;
		private DataDynamics.ActiveReports.Label Label114 = null;
		private DataDynamics.ActiveReports.Label Label115 = null;
		private DataDynamics.ActiveReports.Label Label116 = null;
		private DataDynamics.ActiveReports.Label Label117 = null;
		private DataDynamics.ActiveReports.Line Line149 = null;
		private DataDynamics.ActiveReports.Label Label118 = null;
		private DataDynamics.ActiveReports.Label Label119 = null;
		private DataDynamics.ActiveReports.Label Label120 = null;
		private DataDynamics.ActiveReports.Label Label121 = null;
		private DataDynamics.ActiveReports.Label Label122 = null;
		private DataDynamics.ActiveReports.Line Line141 = null;
		private DataDynamics.ActiveReports.Label Label123 = null;
		private DataDynamics.ActiveReports.Label Label124 = null;
		private DataDynamics.ActiveReports.Label Label125 = null;
		private DataDynamics.ActiveReports.Label Label126 = null;
		private DataDynamics.ActiveReports.Label Label127 = null;
		private DataDynamics.ActiveReports.Label Label128 = null;
		private DataDynamics.ActiveReports.Label Label129 = null;
		private DataDynamics.ActiveReports.Label Label130 = null;
		private DataDynamics.ActiveReports.Label Label131 = null;
		private DataDynamics.ActiveReports.Label Label132 = null;
		private DataDynamics.ActiveReports.Label Label133 = null;
		private DataDynamics.ActiveReports.Label Label134 = null;
		private DataDynamics.ActiveReports.Label Label135 = null;
		private DataDynamics.ActiveReports.Label Label136 = null;
		private DataDynamics.ActiveReports.Label Label137 = null;
		private DataDynamics.ActiveReports.Label Label138 = null;
		private DataDynamics.ActiveReports.Label Label139 = null;
		private DataDynamics.ActiveReports.Label Label140 = null;
		private DataDynamics.ActiveReports.Label Label141 = null;
		private DataDynamics.ActiveReports.Label Label142 = null;
		private DataDynamics.ActiveReports.Label Label143 = null;
		private DataDynamics.ActiveReports.Line Line151 = null;
		private DataDynamics.ActiveReports.Line Line143 = null;
		private DataDynamics.ActiveReports.Line Line152 = null;
		private DataDynamics.ActiveReports.Line Line153 = null;
		private DataDynamics.ActiveReports.Line Line154 = null;
		private DataDynamics.ActiveReports.Line Line155 = null;
		private DataDynamics.ActiveReports.Line Line156 = null;
		private DataDynamics.ActiveReports.Line Line157 = null;
		private DataDynamics.ActiveReports.Line Line148 = null;
		private DataDynamics.ActiveReports.Line Line158 = null;
		private DataDynamics.ActiveReports.Line Line159 = null;
		private DataDynamics.ActiveReports.Line Line160 = null;
		private DataDynamics.ActiveReports.Line Line161 = null;
		private DataDynamics.ActiveReports.Line Line142 = null;
		private DataDynamics.ActiveReports.Line Line167 = null;
		private DataDynamics.ActiveReports.Line Line168 = null;
		private DataDynamics.ActiveReports.Label Label102 = null;
		private DataDynamics.ActiveReports.Label Label103 = null;
		private DataDynamics.ActiveReports.Label Label104 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.Line Line162 = null;
		private DataDynamics.ActiveReports.Line Line163 = null;
		private DataDynamics.ActiveReports.Line Line165 = null;
		private DataDynamics.ActiveReports.TextBox txtNameAddrs = null;
		private DataDynamics.ActiveReports.Line Line166 = null;
		private DataDynamics.ActiveReports.TextBox txtPolicyNo = null;
		private DataDynamics.ActiveReports.Line Line164 = null;
		private DataDynamics.ActiveReports.Line Line169 = null;
		private DataDynamics.ActiveReports.Line Line170 = null;
		private DataDynamics.ActiveReports.Line Line171 = null;
		private DataDynamics.ActiveReports.Line Line172 = null;
		private DataDynamics.ActiveReports.Line Line173 = null;
		private DataDynamics.ActiveReports.Line Line174 = null;
		private DataDynamics.ActiveReports.Line Line175 = null;
		private DataDynamics.ActiveReports.Line Line176 = null;
		private DataDynamics.ActiveReports.Line Line177 = null;
		private DataDynamics.ActiveReports.Line Line178 = null;
		private DataDynamics.ActiveReports.Line Line179 = null;
		private DataDynamics.ActiveReports.TextBox TextBox1 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.Label Label144 = null;
		private DataDynamics.ActiveReports.Label Label145 = null;
		private DataDynamics.ActiveReports.Label Label146 = null;
		private DataDynamics.ActiveReports.Label Label147 = null;
		private DataDynamics.ActiveReports.Label Label148 = null;
		private DataDynamics.ActiveReports.Label Label149 = null;
		private DataDynamics.ActiveReports.Label Label150 = null;
		private DataDynamics.ActiveReports.Label Label151 = null;
		private DataDynamics.ActiveReports.Label Label152 = null;
		private DataDynamics.ActiveReports.Label Label153 = null;
		private DataDynamics.ActiveReports.Label Label154 = null;
		private DataDynamics.ActiveReports.Label Label155 = null;
		private DataDynamics.ActiveReports.Label Label156 = null;
		private DataDynamics.ActiveReports.Line Line180 = null;
		private DataDynamics.ActiveReports.Line Line181 = null;
		private DataDynamics.ActiveReports.Line Line183 = null;
		private DataDynamics.ActiveReports.Line Line184 = null;
		private DataDynamics.ActiveReports.Line Line186 = null;
		private DataDynamics.ActiveReports.Line Line188 = null;
		private DataDynamics.ActiveReports.Label Label157 = null;
		private DataDynamics.ActiveReports.Label Label158 = null;
		private DataDynamics.ActiveReports.Line Line190 = null;
		private DataDynamics.ActiveReports.Line Line191 = null;
		private DataDynamics.ActiveReports.Line Line192 = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CancellationNoticeForBank));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Line140 = new DataDynamics.ActiveReports.Line();
            this.Label99 = new DataDynamics.ActiveReports.Label();
            this.Label100 = new DataDynamics.ActiveReports.Label();
            this.Label101 = new DataDynamics.ActiveReports.Label();
            this.Line144 = new DataDynamics.ActiveReports.Line();
            this.Line145 = new DataDynamics.ActiveReports.Line();
            this.Line146 = new DataDynamics.ActiveReports.Line();
            this.Line147 = new DataDynamics.ActiveReports.Line();
            this.Label105 = new DataDynamics.ActiveReports.Label();
            this.Label106 = new DataDynamics.ActiveReports.Label();
            this.Label107 = new DataDynamics.ActiveReports.Label();
            this.Label108 = new DataDynamics.ActiveReports.Label();
            this.Label109 = new DataDynamics.ActiveReports.Label();
            this.Label110 = new DataDynamics.ActiveReports.Label();
            this.Label111 = new DataDynamics.ActiveReports.Label();
            this.Label112 = new DataDynamics.ActiveReports.Label();
            this.Label113 = new DataDynamics.ActiveReports.Label();
            this.Label114 = new DataDynamics.ActiveReports.Label();
            this.Label115 = new DataDynamics.ActiveReports.Label();
            this.Label116 = new DataDynamics.ActiveReports.Label();
            this.Label117 = new DataDynamics.ActiveReports.Label();
            this.Line149 = new DataDynamics.ActiveReports.Line();
            this.Label118 = new DataDynamics.ActiveReports.Label();
            this.Label119 = new DataDynamics.ActiveReports.Label();
            this.Label120 = new DataDynamics.ActiveReports.Label();
            this.Label121 = new DataDynamics.ActiveReports.Label();
            this.Label122 = new DataDynamics.ActiveReports.Label();
            this.Line141 = new DataDynamics.ActiveReports.Line();
            this.Label123 = new DataDynamics.ActiveReports.Label();
            this.Label124 = new DataDynamics.ActiveReports.Label();
            this.Label125 = new DataDynamics.ActiveReports.Label();
            this.Label126 = new DataDynamics.ActiveReports.Label();
            this.Label127 = new DataDynamics.ActiveReports.Label();
            this.Label128 = new DataDynamics.ActiveReports.Label();
            this.Label129 = new DataDynamics.ActiveReports.Label();
            this.Label130 = new DataDynamics.ActiveReports.Label();
            this.Label131 = new DataDynamics.ActiveReports.Label();
            this.Label132 = new DataDynamics.ActiveReports.Label();
            this.Label133 = new DataDynamics.ActiveReports.Label();
            this.Label134 = new DataDynamics.ActiveReports.Label();
            this.Label135 = new DataDynamics.ActiveReports.Label();
            this.Label136 = new DataDynamics.ActiveReports.Label();
            this.Label137 = new DataDynamics.ActiveReports.Label();
            this.Label138 = new DataDynamics.ActiveReports.Label();
            this.Label139 = new DataDynamics.ActiveReports.Label();
            this.Label140 = new DataDynamics.ActiveReports.Label();
            this.Label141 = new DataDynamics.ActiveReports.Label();
            this.Label142 = new DataDynamics.ActiveReports.Label();
            this.Label143 = new DataDynamics.ActiveReports.Label();
            this.Line151 = new DataDynamics.ActiveReports.Line();
            this.Line143 = new DataDynamics.ActiveReports.Line();
            this.Line152 = new DataDynamics.ActiveReports.Line();
            this.Line153 = new DataDynamics.ActiveReports.Line();
            this.Line154 = new DataDynamics.ActiveReports.Line();
            this.Line155 = new DataDynamics.ActiveReports.Line();
            this.Line156 = new DataDynamics.ActiveReports.Line();
            this.Line157 = new DataDynamics.ActiveReports.Line();
            this.Line148 = new DataDynamics.ActiveReports.Line();
            this.Line158 = new DataDynamics.ActiveReports.Line();
            this.Line159 = new DataDynamics.ActiveReports.Line();
            this.Line160 = new DataDynamics.ActiveReports.Line();
            this.Line161 = new DataDynamics.ActiveReports.Line();
            this.Line142 = new DataDynamics.ActiveReports.Line();
            this.Line167 = new DataDynamics.ActiveReports.Line();
            this.Line168 = new DataDynamics.ActiveReports.Line();
            this.Label102 = new DataDynamics.ActiveReports.Label();
            this.Label103 = new DataDynamics.ActiveReports.Label();
            this.Label104 = new DataDynamics.ActiveReports.Label();
            this.Line162 = new DataDynamics.ActiveReports.Line();
            this.Line163 = new DataDynamics.ActiveReports.Line();
            this.Line165 = new DataDynamics.ActiveReports.Line();
            this.txtNameAddrs = new DataDynamics.ActiveReports.TextBox();
            this.Line166 = new DataDynamics.ActiveReports.Line();
            this.txtPolicyNo = new DataDynamics.ActiveReports.TextBox();
            this.Line164 = new DataDynamics.ActiveReports.Line();
            this.Line169 = new DataDynamics.ActiveReports.Line();
            this.Line170 = new DataDynamics.ActiveReports.Line();
            this.Line171 = new DataDynamics.ActiveReports.Line();
            this.Line172 = new DataDynamics.ActiveReports.Line();
            this.Line173 = new DataDynamics.ActiveReports.Line();
            this.Line174 = new DataDynamics.ActiveReports.Line();
            this.Line175 = new DataDynamics.ActiveReports.Line();
            this.Line176 = new DataDynamics.ActiveReports.Line();
            this.Line177 = new DataDynamics.ActiveReports.Line();
            this.Line178 = new DataDynamics.ActiveReports.Line();
            this.Line179 = new DataDynamics.ActiveReports.Line();
            this.TextBox1 = new DataDynamics.ActiveReports.TextBox();
            this.Label144 = new DataDynamics.ActiveReports.Label();
            this.Label145 = new DataDynamics.ActiveReports.Label();
            this.Label146 = new DataDynamics.ActiveReports.Label();
            this.Label147 = new DataDynamics.ActiveReports.Label();
            this.Label148 = new DataDynamics.ActiveReports.Label();
            this.Label149 = new DataDynamics.ActiveReports.Label();
            this.Label150 = new DataDynamics.ActiveReports.Label();
            this.Label151 = new DataDynamics.ActiveReports.Label();
            this.Label152 = new DataDynamics.ActiveReports.Label();
            this.Label153 = new DataDynamics.ActiveReports.Label();
            this.Label154 = new DataDynamics.ActiveReports.Label();
            this.Label155 = new DataDynamics.ActiveReports.Label();
            this.Label156 = new DataDynamics.ActiveReports.Label();
            this.Line180 = new DataDynamics.ActiveReports.Line();
            this.Line181 = new DataDynamics.ActiveReports.Line();
            this.Line183 = new DataDynamics.ActiveReports.Line();
            this.Line184 = new DataDynamics.ActiveReports.Line();
            this.Line186 = new DataDynamics.ActiveReports.Line();
            this.Line188 = new DataDynamics.ActiveReports.Line();
            this.Label157 = new DataDynamics.ActiveReports.Label();
            this.Label158 = new DataDynamics.ActiveReports.Label();
            this.Line190 = new DataDynamics.ActiveReports.Line();
            this.Line191 = new DataDynamics.ActiveReports.Line();
            this.Line192 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.Label99)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label110)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label112)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label113)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label114)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label115)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label116)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label117)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label118)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label119)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label120)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label121)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label122)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label123)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label124)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label125)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label126)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label127)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label128)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label129)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label136)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label137)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label138)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label139)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label140)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label141)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label142)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label143)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label103)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameAddrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPolicyNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label144)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label145)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label146)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label147)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label148)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label149)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label150)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label151)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label152)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label153)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label154)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label155)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label156)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label157)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label158)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Line162,
                        this.Line163,
                        this.Line165,
                        this.txtNameAddrs,
                        this.Line166,
                        this.txtPolicyNo,
                        this.Line164,
                        this.Line169,
                        this.Line170,
                        this.Line171,
                        this.Line172,
                        this.Line173,
                        this.Line174,
                        this.Line175,
                        this.Line176,
                        this.Line177,
                        this.Line178,
                        this.Line179,
                        this.TextBox1});
            this.Detail.Height = 0.34375F;
            this.Detail.KeepTogether = true;
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
                        this.Line140,
                        this.Label99,
                        this.Label100,
                        this.Label101,
                        this.Line144,
                        this.Line145,
                        this.Line146,
                        this.Line147,
                        this.Label105,
                        this.Label106,
                        this.Label107,
                        this.Label108,
                        this.Label109,
                        this.Label110,
                        this.Label111,
                        this.Label112,
                        this.Label113,
                        this.Label114,
                        this.Label115,
                        this.Label116,
                        this.Label117,
                        this.Line149,
                        this.Label118,
                        this.Label119,
                        this.Label120,
                        this.Label121,
                        this.Label122,
                        this.Line141,
                        this.Label123,
                        this.Label124,
                        this.Label125,
                        this.Label126,
                        this.Label127,
                        this.Label128,
                        this.Label129,
                        this.Label130,
                        this.Label131,
                        this.Label132,
                        this.Label133,
                        this.Label134,
                        this.Label135,
                        this.Label136,
                        this.Label137,
                        this.Label138,
                        this.Label139,
                        this.Label140,
                        this.Label141,
                        this.Label142,
                        this.Label143,
                        this.Line151,
                        this.Line143,
                        this.Line152,
                        this.Line153,
                        this.Line154,
                        this.Line155,
                        this.Line156,
                        this.Line157,
                        this.Line148,
                        this.Line158,
                        this.Line159,
                        this.Line160,
                        this.Line161,
                        this.Line142,
                        this.Line167,
                        this.Line168,
                        this.Label102,
                        this.Label103,
                        this.Label104});
            this.PageHeader.Height = 1.384722F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Label144,
                        this.Label145,
                        this.Label146,
                        this.Label147,
                        this.Label148,
                        this.Label149,
                        this.Label150,
                        this.Label151,
                        this.Label152,
                        this.Label153,
                        this.Label154,
                        this.Label155,
                        this.Label156,
                        this.Line180,
                        this.Line181,
                        this.Line183,
                        this.Line184,
                        this.Line186,
                        this.Line188,
                        this.Label157,
                        this.Label158,
                        this.Line190,
                        this.Line191,
                        this.Line192});
            this.PageFooter.Height = 1.572222F;
            this.PageFooter.Name = "PageFooter";
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
            this.Line140.Left = 0.1875F;
            this.Line140.LineWeight = 3F;
            this.Line140.Name = "Line140";
            this.Line140.Top = 0.25F;
            this.Line140.Width = 9.1875F;
            this.Line140.X1 = 0.1875F;
            this.Line140.X2 = 9.375F;
            this.Line140.Y1 = 0.25F;
            this.Line140.Y2 = 0.25F;
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
            this.Label99.Height = 0.1875F;
            this.Label99.HyperLink = "";
            this.Label99.Left = 0.3125F;
            this.Label99.Name = "Label99";
            this.Label99.Style = "text-align: left; font-weight: normal; font-size: 9pt; ";
            this.Label99.Text = "Name and";
            this.Label99.Top = 0.375F;
            this.Label99.Width = 0.625F;
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
            this.Label100.Height = 0.1875F;
            this.Label100.HyperLink = "";
            this.Label100.Left = 0.3125F;
            this.Label100.Name = "Label100";
            this.Label100.Style = "text-align: left; font-weight: normal; font-size: 9pt; ";
            this.Label100.Text = "Address";
            this.Label100.Top = 0.5F;
            this.Label100.Width = 0.625F;
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
            this.Label101.Height = 0.1875F;
            this.Label101.HyperLink = "";
            this.Label101.Left = 0.3125F;
            this.Label101.Name = "Label101";
            this.Label101.Style = "text-align: left; font-weight: normal; font-size: 9pt; ";
            this.Label101.Text = "of Sender";
            this.Label101.Top = 0.625F;
            this.Label101.Width = 0.625F;
            // 
            // Line144
            // 
            this.Line144.Border.BottomColor = System.Drawing.Color.Black;
            this.Line144.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line144.Border.LeftColor = System.Drawing.Color.Black;
            this.Line144.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line144.Border.RightColor = System.Drawing.Color.Black;
            this.Line144.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line144.Border.TopColor = System.Drawing.Color.Black;
            this.Line144.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line144.Height = 0.25F;
            this.Line144.Left = 1.0625F;
            this.Line144.LineWeight = 3F;
            this.Line144.Name = "Line144";
            this.Line144.Top = 0.4375F;
            this.Line144.Width = 0F;
            this.Line144.X1 = 1.0625F;
            this.Line144.X2 = 1.0625F;
            this.Line144.Y1 = 0.6875F;
            this.Line144.Y2 = 0.4375F;
            // 
            // Line145
            // 
            this.Line145.Border.BottomColor = System.Drawing.Color.Black;
            this.Line145.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line145.Border.LeftColor = System.Drawing.Color.Black;
            this.Line145.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line145.Border.RightColor = System.Drawing.Color.Black;
            this.Line145.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line145.Border.TopColor = System.Drawing.Color.Black;
            this.Line145.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line145.Height = 0.125F;
            this.Line145.Left = 1.0625F;
            this.Line145.LineWeight = 3F;
            this.Line145.Name = "Line145";
            this.Line145.Top = 0.4375F;
            this.Line145.Width = 0.1875F;
            this.Line145.X1 = 1.25F;
            this.Line145.X2 = 1.0625F;
            this.Line145.Y1 = 0.5625F;
            this.Line145.Y2 = 0.4375F;
            // 
            // Line146
            // 
            this.Line146.Border.BottomColor = System.Drawing.Color.Black;
            this.Line146.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line146.Border.LeftColor = System.Drawing.Color.Black;
            this.Line146.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line146.Border.RightColor = System.Drawing.Color.Black;
            this.Line146.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line146.Border.TopColor = System.Drawing.Color.Black;
            this.Line146.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line146.Height = 0.125F;
            this.Line146.Left = 1.0625F;
            this.Line146.LineWeight = 3F;
            this.Line146.Name = "Line146";
            this.Line146.Top = 0.5625F;
            this.Line146.Width = 0.1875F;
            this.Line146.X1 = 1.0625F;
            this.Line146.X2 = 1.25F;
            this.Line146.Y1 = 0.6875F;
            this.Line146.Y2 = 0.5625F;
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
            this.Line147.Height = 0.75F;
            this.Line147.Left = 3.375F;
            this.Line147.LineWeight = 3F;
            this.Line147.Name = "Line147";
            this.Line147.Top = 0.25F;
            this.Line147.Width = 0F;
            this.Line147.X1 = 3.375F;
            this.Line147.X2 = 3.375F;
            this.Line147.Y1 = 1F;
            this.Line147.Y2 = 0.25F;
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
            this.Label105.Height = 0.125F;
            this.Label105.HyperLink = "";
            this.Label105.Left = 3.4375F;
            this.Label105.Name = "Label105";
            this.Label105.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label105.Text = "Indicate type of mail";
            this.Label105.Top = 0.3125F;
            this.Label105.Width = 1.125F;
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
            this.Label106.Height = 0.1875F;
            this.Label106.HyperLink = "";
            this.Label106.Left = 3.4375F;
            this.Label106.Name = "Label106";
            this.Label106.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label106.Text = "(  ) Registered";
            this.Label106.Top = 0.4375F;
            this.Label106.Width = 0.8125F;
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
            this.Label107.Height = 0.1875F;
            this.Label107.HyperLink = "";
            this.Label107.Left = 3.4375F;
            this.Label107.Name = "Label107";
            this.Label107.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label107.Text = "(  ) Insured";
            this.Label107.Top = 0.5625F;
            this.Label107.Width = 0.75F;
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
            this.Label108.Height = 0.1875F;
            this.Label108.HyperLink = "";
            this.Label108.Left = 3.4375F;
            this.Label108.Name = "Label108";
            this.Label108.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label108.Text = "(  ) COD";
            this.Label108.Top = 0.6875F;
            this.Label108.Width = 0.75F;
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
            this.Label109.Height = 0.1875F;
            this.Label109.HyperLink = "";
            this.Label109.Left = 3.4375F;
            this.Label109.Name = "Label109";
            this.Label109.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label109.Text = "(  ) Certified";
            this.Label109.Top = 0.8125F;
            this.Label109.Width = 0.75F;
            // 
            // Label110
            // 
            this.Label110.Border.BottomColor = System.Drawing.Color.Black;
            this.Label110.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label110.Border.LeftColor = System.Drawing.Color.Black;
            this.Label110.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label110.Border.RightColor = System.Drawing.Color.Black;
            this.Label110.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label110.Border.TopColor = System.Drawing.Color.Black;
            this.Label110.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label110.Height = 0.125F;
            this.Label110.HyperLink = "";
            this.Label110.Left = 4.1875F;
            this.Label110.Name = "Label110";
            this.Label110.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label110.Text = "(  ) Return Receipt";
            this.Label110.Top = 0.4375F;
            this.Label110.Width = 1F;
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
            this.Label111.Height = 0.125F;
            this.Label111.HyperLink = "";
            this.Label111.Left = 4.1875F;
            this.Label111.Name = "Label111";
            this.Label111.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label111.Text = "for Merchandise";
            this.Label111.Top = 0.5625F;
            this.Label111.Width = 1F;
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
            this.Label112.Height = 0.125F;
            this.Label112.HyperLink = "";
            this.Label112.Left = 4.1875F;
            this.Label112.Name = "Label112";
            this.Label112.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label112.Text = "(  ) Int\'l Recorded Del.";
            this.Label112.Top = 0.6875F;
            this.Label112.Width = 1.125F;
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
            this.Label113.Height = 0.125F;
            this.Label113.HyperLink = "";
            this.Label113.Left = 4.1875F;
            this.Label113.Name = "Label113";
            this.Label113.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label113.Text = "(  ) Express Mail";
            this.Label113.Top = 0.8125F;
            this.Label113.Width = 1.125F;
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
            this.Label114.Height = 0.125F;
            this.Label114.HyperLink = "";
            this.Label114.Left = 5.25F;
            this.Label114.Name = "Label114";
            this.Label114.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label114.Text = "Check appropiate block for";
            this.Label114.Top = 0.3125F;
            this.Label114.Width = 1.5F;
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
            this.Label115.Height = 0.125F;
            this.Label115.HyperLink = "";
            this.Label115.Left = 5.25F;
            this.Label115.Name = "Label115";
            this.Label115.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label115.Text = "Registered mail:";
            this.Label115.Top = 0.4375F;
            this.Label115.Width = 1.5F;
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
            this.Label116.Height = 0.125F;
            this.Label116.HyperLink = "";
            this.Label116.Left = 5.25F;
            this.Label116.Name = "Label116";
            this.Label116.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label116.Text = "(  ) With Postal Insurance";
            this.Label116.Top = 0.6875F;
            this.Label116.Width = 1.375F;
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
            this.Label117.Height = 0.125F;
            this.Label117.HyperLink = "";
            this.Label117.Left = 5.25F;
            this.Label117.Name = "Label117";
            this.Label117.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label117.Text = "(  ) Without Postal Insurance";
            this.Label117.Top = 0.8125F;
            this.Label117.Width = 1.5F;
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
            this.Line149.Height = 0.75F;
            this.Line149.Left = 6.75F;
            this.Line149.LineWeight = 3F;
            this.Line149.Name = "Line149";
            this.Line149.Top = 0.25F;
            this.Line149.Width = 0F;
            this.Line149.X1 = 6.75F;
            this.Line149.X2 = 6.75F;
            this.Line149.Y1 = 1F;
            this.Line149.Y2 = 0.25F;
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
            this.Label118.Height = 0.125F;
            this.Label118.HyperLink = "";
            this.Label118.Left = 6.875F;
            this.Label118.Name = "Label118";
            this.Label118.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label118.Text = "Affix stamp here if issued as";
            this.Label118.Top = 0.3125F;
            this.Label118.Width = 1.5F;
            // 
            // Label119
            // 
            this.Label119.Border.BottomColor = System.Drawing.Color.Black;
            this.Label119.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label119.Border.LeftColor = System.Drawing.Color.Black;
            this.Label119.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label119.Border.RightColor = System.Drawing.Color.Black;
            this.Label119.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label119.Border.TopColor = System.Drawing.Color.Black;
            this.Label119.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label119.Height = 0.125F;
            this.Label119.HyperLink = "";
            this.Label119.Left = 6.875F;
            this.Label119.Name = "Label119";
            this.Label119.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label119.Text = "certificated of mailing or for";
            this.Label119.Top = 0.4375F;
            this.Label119.Width = 1.5F;
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
            this.Label120.Height = 0.125F;
            this.Label120.HyperLink = "";
            this.Label120.Left = 6.875F;
            this.Label120.Name = "Label120";
            this.Label120.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label120.Text = "additional copies of this bill.";
            this.Label120.Top = 0.5625F;
            this.Label120.Width = 1.5F;
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
            this.Label121.Height = 0.125F;
            this.Label121.HyperLink = "";
            this.Label121.Left = 6.875F;
            this.Label121.Name = "Label121";
            this.Label121.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label121.Text = "Postmark and Date Receipt";
            this.Label121.Top = 0.8125F;
            this.Label121.Width = 1.5F;
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
            this.Label122.Left = 0.25F;
            this.Label122.Name = "Label122";
            this.Label122.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label122.Text = "Line";
            this.Label122.Top = 1.1875F;
            this.Label122.Width = 0.3125F;
            // 
            // Line141
            // 
            this.Line141.Border.BottomColor = System.Drawing.Color.Black;
            this.Line141.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line141.Border.LeftColor = System.Drawing.Color.Black;
            this.Line141.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line141.Border.RightColor = System.Drawing.Color.Black;
            this.Line141.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line141.Border.TopColor = System.Drawing.Color.Black;
            this.Line141.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line141.Height = 0F;
            this.Line141.Left = 0.1875F;
            this.Line141.LineWeight = 3F;
            this.Line141.Name = "Line141";
            this.Line141.Top = 1F;
            this.Line141.Width = 9.1875F;
            this.Line141.X1 = 0.1875F;
            this.Line141.X2 = 9.375F;
            this.Line141.Y1 = 1F;
            this.Line141.Y2 = 1F;
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
            this.Label123.Left = 0.8125F;
            this.Label123.Name = "Label123";
            this.Label123.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label123.Text = "Number";
            this.Label123.Top = 1.1875F;
            this.Label123.Width = 0.4375F;
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
            this.Label124.Left = 0.8125F;
            this.Label124.Name = "Label124";
            this.Label124.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label124.Text = "Article";
            this.Label124.Top = 1.0625F;
            this.Label124.Width = 0.4375F;
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
            this.Label125.Left = 1.5625F;
            this.Label125.Name = "Label125";
            this.Label125.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label125.Text = "Name of Adressee, Street an Post Office Address";
            this.Label125.Top = 1.1875F;
            this.Label125.Width = 2.75F;
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
            this.Label126.Left = 4.375F;
            this.Label126.Name = "Label126";
            this.Label126.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label126.Text = "Postage";
            this.Label126.Top = 1.1875F;
            this.Label126.Width = 0.5F;
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
            this.Label127.Left = 4.875F;
            this.Label127.Name = "Label127";
            this.Label127.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label127.Text = "Fee";
            this.Label127.Top = 1.1875F;
            this.Label127.Width = 0.3125F;
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
            this.Label128.Left = 5.1875F;
            this.Label128.Name = "Label128";
            this.Label128.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label128.Text = "Handling";
            this.Label128.Top = 1.0625F;
            this.Label128.Width = 0.5F;
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
            this.Label129.Height = 0.1875F;
            this.Label129.HyperLink = "";
            this.Label129.Left = 5.1875F;
            this.Label129.Name = "Label129";
            this.Label129.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label129.Text = "Charge";
            this.Label129.Top = 1.1875F;
            this.Label129.Width = 0.4375F;
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
            this.Label130.Height = 0.1875F;
            this.Label130.HyperLink = "";
            this.Label130.Left = 5.6875F;
            this.Label130.Name = "Label130";
            this.Label130.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label130.Text = "Act. Value";
            this.Label130.Top = 1.0625F;
            this.Label130.Width = 0.5625F;
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
            this.Label131.Height = 0.1875F;
            this.Label131.HyperLink = "";
            this.Label131.Left = 5.6875F;
            this.Label131.Name = "Label131";
            this.Label131.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label131.Text = "(If Regist.)";
            this.Label131.Top = 1.1875F;
            this.Label131.Width = 0.5625F;
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
            this.Label132.Height = 0.1875F;
            this.Label132.HyperLink = "";
            this.Label132.Left = 6.25F;
            this.Label132.Name = "Label132";
            this.Label132.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label132.Text = "Insured";
            this.Label132.Top = 1.0625F;
            this.Label132.Width = 0.5F;
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
            this.Label133.Height = 0.1875F;
            this.Label133.HyperLink = "";
            this.Label133.Left = 6.25F;
            this.Label133.Name = "Label133";
            this.Label133.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label133.Text = "Value";
            this.Label133.Top = 1.1875F;
            this.Label133.Width = 0.5F;
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
            this.Label134.Height = 0.1875F;
            this.Label134.HyperLink = "";
            this.Label134.Left = 6.8125F;
            this.Label134.Name = "Label134";
            this.Label134.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label134.Text = "Due Sender";
            this.Label134.Top = 1.0625F;
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
            this.Label135.Height = 0.1875F;
            this.Label135.HyperLink = "";
            this.Label135.Left = 6.8125F;
            this.Label135.Name = "Label135";
            this.Label135.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label135.Text = "If COD";
            this.Label135.Top = 1.1875F;
            this.Label135.Width = 0.5F;
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
            this.Label136.Height = 0.1875F;
            this.Label136.HyperLink = "";
            this.Label136.Left = 7.5F;
            this.Label136.Name = "Label136";
            this.Label136.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label136.Text = "R.R";
            this.Label136.Top = 1.0625F;
            this.Label136.Width = 0.25F;
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
            this.Label137.Left = 7.5F;
            this.Label137.Name = "Label137";
            this.Label137.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label137.Text = "Fee";
            this.Label137.Top = 1.1875F;
            this.Label137.Width = 0.25F;
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
            this.Label138.Left = 7.75F;
            this.Label138.Name = "Label138";
            this.Label138.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label138.Text = "S.D";
            this.Label138.Top = 1.0625F;
            this.Label138.Width = 0.25F;
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
            this.Label139.Left = 7.75F;
            this.Label139.Name = "Label139";
            this.Label139.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label139.Text = "Fee";
            this.Label139.Top = 1.1875F;
            this.Label139.Width = 0.25F;
            // 
            // Label140
            // 
            this.Label140.Border.BottomColor = System.Drawing.Color.Black;
            this.Label140.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label140.Border.LeftColor = System.Drawing.Color.Black;
            this.Label140.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label140.Border.RightColor = System.Drawing.Color.Black;
            this.Label140.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label140.Border.TopColor = System.Drawing.Color.Black;
            this.Label140.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label140.Height = 0.1875F;
            this.Label140.HyperLink = "";
            this.Label140.Left = 8.0625F;
            this.Label140.Name = "Label140";
            this.Label140.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label140.Text = "S.H";
            this.Label140.Top = 1.0625F;
            this.Label140.Width = 0.25F;
            // 
            // Label141
            // 
            this.Label141.Border.BottomColor = System.Drawing.Color.Black;
            this.Label141.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label141.Border.LeftColor = System.Drawing.Color.Black;
            this.Label141.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label141.Border.RightColor = System.Drawing.Color.Black;
            this.Label141.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label141.Border.TopColor = System.Drawing.Color.Black;
            this.Label141.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label141.Height = 0.1875F;
            this.Label141.HyperLink = "";
            this.Label141.Left = 8.0625F;
            this.Label141.Name = "Label141";
            this.Label141.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; ";
            this.Label141.Text = "Fee";
            this.Label141.Top = 1.1875F;
            this.Label141.Width = 0.25F;
            // 
            // Label142
            // 
            this.Label142.Border.BottomColor = System.Drawing.Color.Black;
            this.Label142.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label142.Border.LeftColor = System.Drawing.Color.Black;
            this.Label142.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label142.Border.RightColor = System.Drawing.Color.Black;
            this.Label142.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label142.Border.TopColor = System.Drawing.Color.Black;
            this.Label142.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label142.Height = 0.125F;
            this.Label142.HyperLink = "";
            this.Label142.Left = 8.4375F;
            this.Label142.Name = "Label142";
            this.Label142.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label142.Text = "Rest.Del.Fee";
            this.Label142.Top = 1.0625F;
            this.Label142.Width = 0.75F;
            // 
            // Label143
            // 
            this.Label143.Border.BottomColor = System.Drawing.Color.Black;
            this.Label143.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label143.Border.LeftColor = System.Drawing.Color.Black;
            this.Label143.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label143.Border.RightColor = System.Drawing.Color.Black;
            this.Label143.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label143.Border.TopColor = System.Drawing.Color.Black;
            this.Label143.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label143.Height = 0.125F;
            this.Label143.HyperLink = "";
            this.Label143.Left = 8.4375F;
            this.Label143.Name = "Label143";
            this.Label143.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.Label143.Text = "Remarks";
            this.Label143.Top = 1.1875F;
            this.Label143.Width = 0.75F;
            // 
            // Line151
            // 
            this.Line151.Border.BottomColor = System.Drawing.Color.Black;
            this.Line151.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line151.Border.LeftColor = System.Drawing.Color.Black;
            this.Line151.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line151.Border.RightColor = System.Drawing.Color.Black;
            this.Line151.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line151.Border.TopColor = System.Drawing.Color.Black;
            this.Line151.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line151.Height = 0F;
            this.Line151.Left = 0.1875F;
            this.Line151.LineWeight = 3F;
            this.Line151.Name = "Line151";
            this.Line151.Top = 1.375F;
            this.Line151.Width = 9.1875F;
            this.Line151.X1 = 0.1875F;
            this.Line151.X2 = 9.375F;
            this.Line151.Y1 = 1.375F;
            this.Line151.Y2 = 1.375F;
            // 
            // Line143
            // 
            this.Line143.Border.BottomColor = System.Drawing.Color.Black;
            this.Line143.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line143.Border.LeftColor = System.Drawing.Color.Black;
            this.Line143.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line143.Border.RightColor = System.Drawing.Color.Black;
            this.Line143.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line143.Border.TopColor = System.Drawing.Color.Black;
            this.Line143.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line143.Height = 1.125F;
            this.Line143.Left = 9.375F;
            this.Line143.LineWeight = 3F;
            this.Line143.Name = "Line143";
            this.Line143.Top = 0.25F;
            this.Line143.Width = 0F;
            this.Line143.X1 = 9.375F;
            this.Line143.X2 = 9.375F;
            this.Line143.Y1 = 1.375F;
            this.Line143.Y2 = 0.25F;
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
            this.Line152.Height = 0.375F;
            this.Line152.Left = 8.3125F;
            this.Line152.LineWeight = 3F;
            this.Line152.Name = "Line152";
            this.Line152.Top = 1F;
            this.Line152.Width = 0F;
            this.Line152.X1 = 8.3125F;
            this.Line152.X2 = 8.3125F;
            this.Line152.Y1 = 1.375F;
            this.Line152.Y2 = 1F;
            // 
            // Line153
            // 
            this.Line153.Border.BottomColor = System.Drawing.Color.Black;
            this.Line153.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line153.Border.LeftColor = System.Drawing.Color.Black;
            this.Line153.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line153.Border.RightColor = System.Drawing.Color.Black;
            this.Line153.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line153.Border.TopColor = System.Drawing.Color.Black;
            this.Line153.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line153.Height = 0.375F;
            this.Line153.Left = 8F;
            this.Line153.LineWeight = 3F;
            this.Line153.Name = "Line153";
            this.Line153.Top = 1F;
            this.Line153.Width = 0F;
            this.Line153.X1 = 8F;
            this.Line153.X2 = 8F;
            this.Line153.Y1 = 1.375F;
            this.Line153.Y2 = 1F;
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
            this.Line154.Height = 0.375F;
            this.Line154.Left = 8F;
            this.Line154.LineWeight = 3F;
            this.Line154.Name = "Line154";
            this.Line154.Top = 1F;
            this.Line154.Width = 0F;
            this.Line154.X1 = 8F;
            this.Line154.X2 = 8F;
            this.Line154.Y1 = 1.375F;
            this.Line154.Y2 = 1F;
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
            this.Line155.Height = 0.375F;
            this.Line155.Left = 7.75F;
            this.Line155.LineWeight = 3F;
            this.Line155.Name = "Line155";
            this.Line155.Top = 1F;
            this.Line155.Width = 0F;
            this.Line155.X1 = 7.75F;
            this.Line155.X2 = 7.75F;
            this.Line155.Y1 = 1.375F;
            this.Line155.Y2 = 1F;
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
            this.Line156.Height = 0.375F;
            this.Line156.Left = 7.4375F;
            this.Line156.LineWeight = 3F;
            this.Line156.Name = "Line156";
            this.Line156.Top = 1F;
            this.Line156.Width = 0F;
            this.Line156.X1 = 7.4375F;
            this.Line156.X2 = 7.4375F;
            this.Line156.Y1 = 1.375F;
            this.Line156.Y2 = 1F;
            // 
            // Line157
            // 
            this.Line157.Border.BottomColor = System.Drawing.Color.Black;
            this.Line157.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line157.Border.LeftColor = System.Drawing.Color.Black;
            this.Line157.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line157.Border.RightColor = System.Drawing.Color.Black;
            this.Line157.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line157.Border.TopColor = System.Drawing.Color.Black;
            this.Line157.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line157.Height = 0.375F;
            this.Line157.Left = 6.75F;
            this.Line157.LineWeight = 3F;
            this.Line157.Name = "Line157";
            this.Line157.Top = 1F;
            this.Line157.Width = 0F;
            this.Line157.X1 = 6.75F;
            this.Line157.X2 = 6.75F;
            this.Line157.Y1 = 1.375F;
            this.Line157.Y2 = 1F;
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
            this.Line148.Height = 1.125F;
            this.Line148.Left = 5.1875F;
            this.Line148.LineWeight = 3F;
            this.Line148.Name = "Line148";
            this.Line148.Top = 0.25F;
            this.Line148.Width = 0F;
            this.Line148.X1 = 5.1875F;
            this.Line148.X2 = 5.1875F;
            this.Line148.Y1 = 1.375F;
            this.Line148.Y2 = 0.25F;
            // 
            // Line158
            // 
            this.Line158.Border.BottomColor = System.Drawing.Color.Black;
            this.Line158.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line158.Border.LeftColor = System.Drawing.Color.Black;
            this.Line158.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line158.Border.RightColor = System.Drawing.Color.Black;
            this.Line158.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line158.Border.TopColor = System.Drawing.Color.Black;
            this.Line158.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line158.Height = 0.375F;
            this.Line158.Left = 4.875F;
            this.Line158.LineWeight = 3F;
            this.Line158.Name = "Line158";
            this.Line158.Top = 1F;
            this.Line158.Width = 0F;
            this.Line158.X1 = 4.875F;
            this.Line158.X2 = 4.875F;
            this.Line158.Y1 = 1.375F;
            this.Line158.Y2 = 1F;
            // 
            // Line159
            // 
            this.Line159.Border.BottomColor = System.Drawing.Color.Black;
            this.Line159.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line159.Border.LeftColor = System.Drawing.Color.Black;
            this.Line159.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line159.Border.RightColor = System.Drawing.Color.Black;
            this.Line159.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line159.Border.TopColor = System.Drawing.Color.Black;
            this.Line159.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line159.Height = 0.375F;
            this.Line159.Left = 4.375F;
            this.Line159.LineWeight = 3F;
            this.Line159.Name = "Line159";
            this.Line159.Top = 1F;
            this.Line159.Width = 0F;
            this.Line159.X1 = 4.375F;
            this.Line159.X2 = 4.375F;
            this.Line159.Y1 = 1.375F;
            this.Line159.Y2 = 1F;
            // 
            // Line160
            // 
            this.Line160.Border.BottomColor = System.Drawing.Color.Black;
            this.Line160.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line160.Border.LeftColor = System.Drawing.Color.Black;
            this.Line160.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line160.Border.RightColor = System.Drawing.Color.Black;
            this.Line160.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line160.Border.TopColor = System.Drawing.Color.Black;
            this.Line160.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line160.Height = 0.375F;
            this.Line160.Left = 1.4375F;
            this.Line160.LineWeight = 3F;
            this.Line160.Name = "Line160";
            this.Line160.Top = 1F;
            this.Line160.Width = 0F;
            this.Line160.X1 = 1.4375F;
            this.Line160.X2 = 1.4375F;
            this.Line160.Y1 = 1.375F;
            this.Line160.Y2 = 1F;
            // 
            // Line161
            // 
            this.Line161.Border.BottomColor = System.Drawing.Color.Black;
            this.Line161.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line161.Border.LeftColor = System.Drawing.Color.Black;
            this.Line161.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line161.Border.RightColor = System.Drawing.Color.Black;
            this.Line161.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line161.Border.TopColor = System.Drawing.Color.Black;
            this.Line161.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line161.Height = 0.375F;
            this.Line161.Left = 0.625F;
            this.Line161.LineWeight = 3F;
            this.Line161.Name = "Line161";
            this.Line161.Top = 1F;
            this.Line161.Width = 0F;
            this.Line161.X1 = 0.625F;
            this.Line161.X2 = 0.625F;
            this.Line161.Y1 = 1.375F;
            this.Line161.Y2 = 1F;
            // 
            // Line142
            // 
            this.Line142.Border.BottomColor = System.Drawing.Color.Black;
            this.Line142.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line142.Border.LeftColor = System.Drawing.Color.Black;
            this.Line142.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line142.Border.RightColor = System.Drawing.Color.Black;
            this.Line142.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line142.Border.TopColor = System.Drawing.Color.Black;
            this.Line142.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line142.Height = 1.125F;
            this.Line142.Left = 0.1875F;
            this.Line142.LineWeight = 3F;
            this.Line142.Name = "Line142";
            this.Line142.Top = 0.25F;
            this.Line142.Width = 0F;
            this.Line142.X1 = 0.1875F;
            this.Line142.X2 = 0.1875F;
            this.Line142.Y1 = 1.375F;
            this.Line142.Y2 = 0.25F;
            // 
            // Line167
            // 
            this.Line167.Border.BottomColor = System.Drawing.Color.Black;
            this.Line167.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line167.Border.LeftColor = System.Drawing.Color.Black;
            this.Line167.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line167.Border.RightColor = System.Drawing.Color.Black;
            this.Line167.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line167.Border.TopColor = System.Drawing.Color.Black;
            this.Line167.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line167.Height = 0.375F;
            this.Line167.Left = 5.6875F;
            this.Line167.LineWeight = 3F;
            this.Line167.Name = "Line167";
            this.Line167.Top = 1F;
            this.Line167.Width = 0F;
            this.Line167.X1 = 5.6875F;
            this.Line167.X2 = 5.6875F;
            this.Line167.Y1 = 1.375F;
            this.Line167.Y2 = 1F;
            // 
            // Line168
            // 
            this.Line168.Border.BottomColor = System.Drawing.Color.Black;
            this.Line168.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line168.Border.LeftColor = System.Drawing.Color.Black;
            this.Line168.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line168.Border.RightColor = System.Drawing.Color.Black;
            this.Line168.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line168.Border.TopColor = System.Drawing.Color.Black;
            this.Line168.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line168.Height = 0.375F;
            this.Line168.Left = 6.25F;
            this.Line168.LineWeight = 3F;
            this.Line168.Name = "Line168";
            this.Line168.Top = 1F;
            this.Line168.Width = 0F;
            this.Line168.X1 = 6.25F;
            this.Line168.X2 = 6.25F;
            this.Line168.Y1 = 1.375F;
            this.Line168.Y2 = 1F;
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
            this.Label102.Height = 0.1875F;
            this.Label102.HyperLink = "";
            this.Label102.Left = 1.3125F;
            this.Label102.Name = "Label102";
            this.Label102.Style = "text-align: left; font-weight: normal; font-size: 7pt; ";
            this.Label102.Text = "LAS VISTAS INSURANCE AGENCY, CORP";
            this.Label102.Top = 0.34375F;
            this.Label102.Width = 2.0625F;
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
            this.Label103.Height = 0.1875F;
            this.Label103.HyperLink = "";
            this.Label103.Left = 1.3125F;
            this.Label103.Name = "Label103";
            this.Label103.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.Label103.Text = "P.O. Box 195585";
            this.Label103.Top = 0.5625F;
            this.Label103.Width = 2.0625F;
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
            this.Label104.Height = 0.1875F;
            this.Label104.HyperLink = "";
            this.Label104.Left = 1.3125F;
            this.Label104.Name = "Label104";
            this.Label104.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.Label104.Text = "San Juan Puerto Rico, PR  00919-558";
            this.Label104.Top = 0.75F;
            this.Label104.Width = 1.9375F;
            // 
            // Line162
            // 
            this.Line162.Border.BottomColor = System.Drawing.Color.Black;
            this.Line162.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line162.Border.LeftColor = System.Drawing.Color.Black;
            this.Line162.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line162.Border.RightColor = System.Drawing.Color.Black;
            this.Line162.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line162.Border.TopColor = System.Drawing.Color.Black;
            this.Line162.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line162.Height = 0.4375F;
            this.Line162.Left = 0.625F;
            this.Line162.LineWeight = 3F;
            this.Line162.Name = "Line162";
            this.Line162.Top = 0F;
            this.Line162.Width = 0F;
            this.Line162.X1 = 0.625F;
            this.Line162.X2 = 0.625F;
            this.Line162.Y1 = 0.4375F;
            this.Line162.Y2 = 0F;
            // 
            // Line163
            // 
            this.Line163.Border.BottomColor = System.Drawing.Color.Black;
            this.Line163.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line163.Border.LeftColor = System.Drawing.Color.Black;
            this.Line163.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line163.Border.RightColor = System.Drawing.Color.Black;
            this.Line163.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line163.Border.TopColor = System.Drawing.Color.Black;
            this.Line163.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line163.Height = 0.4375F;
            this.Line163.Left = 1.4375F;
            this.Line163.LineWeight = 3F;
            this.Line163.Name = "Line163";
            this.Line163.Top = 0F;
            this.Line163.Width = 0F;
            this.Line163.X1 = 1.4375F;
            this.Line163.X2 = 1.4375F;
            this.Line163.Y1 = 0.4375F;
            this.Line163.Y2 = 0F;
            // 
            // Line165
            // 
            this.Line165.Border.BottomColor = System.Drawing.Color.Black;
            this.Line165.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line165.Border.LeftColor = System.Drawing.Color.Black;
            this.Line165.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line165.Border.RightColor = System.Drawing.Color.Black;
            this.Line165.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line165.Border.TopColor = System.Drawing.Color.Black;
            this.Line165.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line165.Height = 0.4375F;
            this.Line165.Left = 0.1875F;
            this.Line165.LineWeight = 3F;
            this.Line165.Name = "Line165";
            this.Line165.Top = 0F;
            this.Line165.Width = 0F;
            this.Line165.X1 = 0.1875F;
            this.Line165.X2 = 0.1875F;
            this.Line165.Y1 = 0.4375F;
            this.Line165.Y2 = 0F;
            // 
            // txtNameAddrs
            // 
            this.txtNameAddrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtNameAddrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNameAddrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtNameAddrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNameAddrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtNameAddrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNameAddrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtNameAddrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNameAddrs.DataField = "LossCustomerName";
            this.txtNameAddrs.Height = 0.1875F;
            this.txtNameAddrs.Left = 1.489583F;
            this.txtNameAddrs.MultiLine = false;
            this.txtNameAddrs.Name = "txtNameAddrs";
            this.txtNameAddrs.Style = "text-align: left; font-size: 7pt; ";
            this.txtNameAddrs.Top = 0F;
            this.txtNameAddrs.Width = 2.822917F;
            // 
            // Line166
            // 
            this.Line166.Border.BottomColor = System.Drawing.Color.Black;
            this.Line166.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line166.Border.LeftColor = System.Drawing.Color.Black;
            this.Line166.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line166.Border.RightColor = System.Drawing.Color.Black;
            this.Line166.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line166.Border.TopColor = System.Drawing.Color.Black;
            this.Line166.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line166.Height = 0.1875F;
            this.Line166.Left = 4.375F;
            this.Line166.LineWeight = 3F;
            this.Line166.Name = "Line166";
            this.Line166.Top = 0F;
            this.Line166.Width = 0F;
            this.Line166.X1 = 4.375F;
            this.Line166.X2 = 4.375F;
            this.Line166.Y1 = 0.1875F;
            this.Line166.Y2 = 0F;
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
            this.txtPolicyNo.Left = 8.3125F;
            this.txtPolicyNo.Name = "txtPolicyNo";
            this.txtPolicyNo.Style = "text-align: left; font-size: 7pt; ";
            this.txtPolicyNo.Top = 0F;
            this.txtPolicyNo.Width = 1F;
            // 
            // Line164
            // 
            this.Line164.Border.BottomColor = System.Drawing.Color.Black;
            this.Line164.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line164.Border.LeftColor = System.Drawing.Color.Black;
            this.Line164.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line164.Border.RightColor = System.Drawing.Color.Black;
            this.Line164.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line164.Border.TopColor = System.Drawing.Color.Black;
            this.Line164.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line164.Height = 0F;
            this.Line164.Left = 0.1875F;
            this.Line164.LineWeight = 3F;
            this.Line164.Name = "Line164";
            this.Line164.Top = 0.3333333F;
            this.Line164.Width = 9.1875F;
            this.Line164.X1 = 0.1875F;
            this.Line164.X2 = 9.375F;
            this.Line164.Y1 = 0.3333333F;
            this.Line164.Y2 = 0.3333333F;
            // 
            // Line169
            // 
            this.Line169.Border.BottomColor = System.Drawing.Color.Black;
            this.Line169.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line169.Border.LeftColor = System.Drawing.Color.Black;
            this.Line169.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line169.Border.RightColor = System.Drawing.Color.Black;
            this.Line169.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line169.Border.TopColor = System.Drawing.Color.Black;
            this.Line169.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line169.Height = 0.4375F;
            this.Line169.Left = 8.3125F;
            this.Line169.LineWeight = 3F;
            this.Line169.Name = "Line169";
            this.Line169.Top = 0F;
            this.Line169.Width = 0F;
            this.Line169.X1 = 8.3125F;
            this.Line169.X2 = 8.3125F;
            this.Line169.Y1 = 0.4375F;
            this.Line169.Y2 = 0F;
            // 
            // Line170
            // 
            this.Line170.Border.BottomColor = System.Drawing.Color.Black;
            this.Line170.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line170.Border.LeftColor = System.Drawing.Color.Black;
            this.Line170.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line170.Border.RightColor = System.Drawing.Color.Black;
            this.Line170.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line170.Border.TopColor = System.Drawing.Color.Black;
            this.Line170.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line170.Height = 0.4375F;
            this.Line170.Left = 8F;
            this.Line170.LineWeight = 3F;
            this.Line170.Name = "Line170";
            this.Line170.Top = 0F;
            this.Line170.Width = 0F;
            this.Line170.X1 = 8F;
            this.Line170.X2 = 8F;
            this.Line170.Y1 = 0.4375F;
            this.Line170.Y2 = 0F;
            // 
            // Line171
            // 
            this.Line171.Border.BottomColor = System.Drawing.Color.Black;
            this.Line171.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line171.Border.LeftColor = System.Drawing.Color.Black;
            this.Line171.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line171.Border.RightColor = System.Drawing.Color.Black;
            this.Line171.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line171.Border.TopColor = System.Drawing.Color.Black;
            this.Line171.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line171.Height = 0.4375F;
            this.Line171.Left = 7.75F;
            this.Line171.LineWeight = 3F;
            this.Line171.Name = "Line171";
            this.Line171.Top = 0F;
            this.Line171.Width = 0F;
            this.Line171.X1 = 7.75F;
            this.Line171.X2 = 7.75F;
            this.Line171.Y1 = 0.4375F;
            this.Line171.Y2 = 0F;
            // 
            // Line172
            // 
            this.Line172.Border.BottomColor = System.Drawing.Color.Black;
            this.Line172.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line172.Border.LeftColor = System.Drawing.Color.Black;
            this.Line172.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line172.Border.RightColor = System.Drawing.Color.Black;
            this.Line172.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line172.Border.TopColor = System.Drawing.Color.Black;
            this.Line172.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line172.Height = 0.4375F;
            this.Line172.Left = 7.4375F;
            this.Line172.LineWeight = 3F;
            this.Line172.Name = "Line172";
            this.Line172.Top = 0F;
            this.Line172.Width = 0F;
            this.Line172.X1 = 7.4375F;
            this.Line172.X2 = 7.4375F;
            this.Line172.Y1 = 0.4375F;
            this.Line172.Y2 = 0F;
            // 
            // Line173
            // 
            this.Line173.Border.BottomColor = System.Drawing.Color.Black;
            this.Line173.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line173.Border.LeftColor = System.Drawing.Color.Black;
            this.Line173.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line173.Border.RightColor = System.Drawing.Color.Black;
            this.Line173.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line173.Border.TopColor = System.Drawing.Color.Black;
            this.Line173.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line173.Height = 0.4375F;
            this.Line173.Left = 6.75F;
            this.Line173.LineWeight = 3F;
            this.Line173.Name = "Line173";
            this.Line173.Top = 0F;
            this.Line173.Width = 0F;
            this.Line173.X1 = 6.75F;
            this.Line173.X2 = 6.75F;
            this.Line173.Y1 = 0.4375F;
            this.Line173.Y2 = 0F;
            // 
            // Line174
            // 
            this.Line174.Border.BottomColor = System.Drawing.Color.Black;
            this.Line174.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line174.Border.LeftColor = System.Drawing.Color.Black;
            this.Line174.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line174.Border.RightColor = System.Drawing.Color.Black;
            this.Line174.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line174.Border.TopColor = System.Drawing.Color.Black;
            this.Line174.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line174.Height = 0.4375F;
            this.Line174.Left = 6.25F;
            this.Line174.LineWeight = 3F;
            this.Line174.Name = "Line174";
            this.Line174.Top = 0F;
            this.Line174.Width = 0F;
            this.Line174.X1 = 6.25F;
            this.Line174.X2 = 6.25F;
            this.Line174.Y1 = 0.4375F;
            this.Line174.Y2 = 0F;
            // 
            // Line175
            // 
            this.Line175.Border.BottomColor = System.Drawing.Color.Black;
            this.Line175.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line175.Border.LeftColor = System.Drawing.Color.Black;
            this.Line175.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line175.Border.RightColor = System.Drawing.Color.Black;
            this.Line175.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line175.Border.TopColor = System.Drawing.Color.Black;
            this.Line175.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line175.Height = 0.4375F;
            this.Line175.Left = 5.6875F;
            this.Line175.LineWeight = 3F;
            this.Line175.Name = "Line175";
            this.Line175.Top = 0F;
            this.Line175.Width = 0F;
            this.Line175.X1 = 5.6875F;
            this.Line175.X2 = 5.6875F;
            this.Line175.Y1 = 0.4375F;
            this.Line175.Y2 = 0F;
            // 
            // Line176
            // 
            this.Line176.Border.BottomColor = System.Drawing.Color.Black;
            this.Line176.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line176.Border.LeftColor = System.Drawing.Color.Black;
            this.Line176.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line176.Border.RightColor = System.Drawing.Color.Black;
            this.Line176.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line176.Border.TopColor = System.Drawing.Color.Black;
            this.Line176.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line176.Height = 0.4375F;
            this.Line176.Left = 5.1875F;
            this.Line176.LineWeight = 3F;
            this.Line176.Name = "Line176";
            this.Line176.Top = 0F;
            this.Line176.Width = 0F;
            this.Line176.X1 = 5.1875F;
            this.Line176.X2 = 5.1875F;
            this.Line176.Y1 = 0.4375F;
            this.Line176.Y2 = 0F;
            // 
            // Line177
            // 
            this.Line177.Border.BottomColor = System.Drawing.Color.Black;
            this.Line177.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line177.Border.LeftColor = System.Drawing.Color.Black;
            this.Line177.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line177.Border.RightColor = System.Drawing.Color.Black;
            this.Line177.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line177.Border.TopColor = System.Drawing.Color.Black;
            this.Line177.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line177.Height = 0.4375F;
            this.Line177.Left = 4.875F;
            this.Line177.LineWeight = 3F;
            this.Line177.Name = "Line177";
            this.Line177.Top = 0F;
            this.Line177.Width = 0F;
            this.Line177.X1 = 4.875F;
            this.Line177.X2 = 4.875F;
            this.Line177.Y1 = 0.4375F;
            this.Line177.Y2 = 0F;
            // 
            // Line178
            // 
            this.Line178.Border.BottomColor = System.Drawing.Color.Black;
            this.Line178.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line178.Border.LeftColor = System.Drawing.Color.Black;
            this.Line178.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line178.Border.RightColor = System.Drawing.Color.Black;
            this.Line178.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line178.Border.TopColor = System.Drawing.Color.Black;
            this.Line178.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line178.Height = 0.4375F;
            this.Line178.Left = 4.375F;
            this.Line178.LineWeight = 3F;
            this.Line178.Name = "Line178";
            this.Line178.Top = 0F;
            this.Line178.Width = 0F;
            this.Line178.X1 = 4.375F;
            this.Line178.X2 = 4.375F;
            this.Line178.Y1 = 0.4375F;
            this.Line178.Y2 = 0F;
            // 
            // Line179
            // 
            this.Line179.Border.BottomColor = System.Drawing.Color.Black;
            this.Line179.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line179.Border.LeftColor = System.Drawing.Color.Black;
            this.Line179.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line179.Border.RightColor = System.Drawing.Color.Black;
            this.Line179.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line179.Border.TopColor = System.Drawing.Color.Black;
            this.Line179.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line179.Height = 0.4375F;
            this.Line179.Left = 9.375F;
            this.Line179.LineWeight = 3F;
            this.Line179.Name = "Line179";
            this.Line179.Top = 0F;
            this.Line179.Width = 0F;
            this.Line179.X1 = 9.375F;
            this.Line179.X2 = 9.375F;
            this.Line179.Y1 = 0.4375F;
            this.Line179.Y2 = 0F;
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
            this.TextBox1.CanGrow = false;
            this.TextBox1.DataField = "LossFullAddrres";
            this.TextBox1.Height = 0.1875F;
            this.TextBox1.Left = 1.489583F;
            this.TextBox1.MultiLine = false;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "text-align: left; font-size: 7pt; white-space: inherit; ";
            this.TextBox1.Top = 0.125F;
            this.TextBox1.Width = 2.822917F;
            // 
            // Label144
            // 
            this.Label144.Border.BottomColor = System.Drawing.Color.Black;
            this.Label144.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label144.Border.LeftColor = System.Drawing.Color.Black;
            this.Label144.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label144.Border.RightColor = System.Drawing.Color.Black;
            this.Label144.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label144.Border.TopColor = System.Drawing.Color.Black;
            this.Label144.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label144.Height = 0.1875F;
            this.Label144.HyperLink = "";
            this.Label144.Left = 5.125F;
            this.Label144.Name = "Label144";
            this.Label144.Style = "text-align: left; font-weight: normal; font-size: 6.75pt; ";
            this.Label144.Text = "The full declaration of value is required on all domestic and international regis" +
                "tered mail. The";
            this.Label144.Top = 0.125F;
            this.Label144.Width = 3.875F;
            // 
            // Label145
            // 
            this.Label145.Border.BottomColor = System.Drawing.Color.Black;
            this.Label145.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label145.Border.LeftColor = System.Drawing.Color.Black;
            this.Label145.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label145.Border.RightColor = System.Drawing.Color.Black;
            this.Label145.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label145.Border.TopColor = System.Drawing.Color.Black;
            this.Label145.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label145.Height = 0.1875F;
            this.Label145.HyperLink = "";
            this.Label145.Left = 5.125F;
            this.Label145.Name = "Label145";
            this.Label145.Style = "text-align: left; font-weight: normal; font-size: 6.75pt; ";
            this.Label145.Text = "maximum indemnity payable for the reconstruction of nonnegotiable documents under" +
                "";
            this.Label145.Top = 0.25F;
            this.Label145.Width = 3.875F;
            // 
            // Label146
            // 
            this.Label146.Border.BottomColor = System.Drawing.Color.Black;
            this.Label146.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label146.Border.LeftColor = System.Drawing.Color.Black;
            this.Label146.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label146.Border.RightColor = System.Drawing.Color.Black;
            this.Label146.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label146.Border.TopColor = System.Drawing.Color.Black;
            this.Label146.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label146.Height = 0.1875F;
            this.Label146.HyperLink = "";
            this.Label146.Left = 5.125F;
            this.Label146.Name = "Label146";
            this.Label146.Style = "text-align: left; font-weight: normal; font-size: 6.75pt; ";
            this.Label146.Text = "Express Mail document reconstruction insurance is $ 50,000 per piece subject to a" +
                " limit of ";
            this.Label146.Top = 0.375F;
            this.Label146.Width = 3.875F;
            // 
            // Label147
            // 
            this.Label147.Border.BottomColor = System.Drawing.Color.Black;
            this.Label147.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label147.Border.LeftColor = System.Drawing.Color.Black;
            this.Label147.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label147.Border.RightColor = System.Drawing.Color.Black;
            this.Label147.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label147.Border.TopColor = System.Drawing.Color.Black;
            this.Label147.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label147.Height = 0.1875F;
            this.Label147.HyperLink = "";
            this.Label147.Left = 5.125F;
            this.Label147.Name = "Label147";
            this.Label147.Style = "text-align: left; font-weight: normal; font-size: 6.75pt; ";
            this.Label147.Text = "$ 500,000 per occurrence. The maximum indemnity payable on Express Mail merchandi" +
                "se";
            this.Label147.Top = 0.5F;
            this.Label147.Width = 3.875F;
            // 
            // Label148
            // 
            this.Label148.Border.BottomColor = System.Drawing.Color.Black;
            this.Label148.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label148.Border.LeftColor = System.Drawing.Color.Black;
            this.Label148.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label148.Border.RightColor = System.Drawing.Color.Black;
            this.Label148.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label148.Border.TopColor = System.Drawing.Color.Black;
            this.Label148.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label148.Height = 0.1875F;
            this.Label148.HyperLink = "";
            this.Label148.Left = 5.125F;
            this.Label148.Name = "Label148";
            this.Label148.Style = "text-align: left; font-weight: normal; font-size: 6.75pt; ";
            this.Label148.Text = "insurance is $500. The maximum indemnity payable is $ 25,000 for registered mail," +
                " sent with";
            this.Label148.Top = 0.625F;
            this.Label148.Width = 3.9375F;
            // 
            // Label149
            // 
            this.Label149.Border.BottomColor = System.Drawing.Color.Black;
            this.Label149.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label149.Border.LeftColor = System.Drawing.Color.Black;
            this.Label149.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label149.Border.RightColor = System.Drawing.Color.Black;
            this.Label149.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label149.Border.TopColor = System.Drawing.Color.Black;
            this.Label149.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label149.Height = 0.1875F;
            this.Label149.HyperLink = "";
            this.Label149.Left = 5.125F;
            this.Label149.Name = "Label149";
            this.Label149.Style = "text-align: left; font-weight: normal; font-size: 6.75pt; ";
            this.Label149.Text = "original postal insurance.See Domestic Mail Manual R900,S913,and S921 for limitat" +
                "ions of";
            this.Label149.Top = 0.75F;
            this.Label149.Width = 3.875F;
            // 
            // Label150
            // 
            this.Label150.Border.BottomColor = System.Drawing.Color.Black;
            this.Label150.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label150.Border.LeftColor = System.Drawing.Color.Black;
            this.Label150.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label150.Border.RightColor = System.Drawing.Color.Black;
            this.Label150.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label150.Border.TopColor = System.Drawing.Color.Black;
            this.Label150.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label150.Height = 0.1875F;
            this.Label150.HyperLink = "";
            this.Label150.Left = 5.125F;
            this.Label150.Name = "Label150";
            this.Label150.Style = "text-align: left; font-weight: normal; font-size: 6.75pt; ";
            this.Label150.Text = "coverage on insured and COD mail. See International Mail Manual for limitations o" +
                "f coverage";
            this.Label150.Top = 0.875F;
            this.Label150.Width = 3.9375F;
            // 
            // Label151
            // 
            this.Label151.Border.BottomColor = System.Drawing.Color.Black;
            this.Label151.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label151.Border.LeftColor = System.Drawing.Color.Black;
            this.Label151.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label151.Border.RightColor = System.Drawing.Color.Black;
            this.Label151.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label151.Border.TopColor = System.Drawing.Color.Black;
            this.Label151.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label151.Height = 0.1875F;
            this.Label151.HyperLink = "";
            this.Label151.Left = 5.125F;
            this.Label151.Name = "Label151";
            this.Label151.Style = "text-align: left; font-weight: normal; font-size: 6.75pt; ";
            this.Label151.Text = "on international mail. Special handling charges apply to only third and fourth cl" +
                "ass parcels.";
            this.Label151.Top = 1F;
            this.Label151.Width = 3.9375F;
            // 
            // Label152
            // 
            this.Label152.Border.BottomColor = System.Drawing.Color.Black;
            this.Label152.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label152.Border.LeftColor = System.Drawing.Color.Black;
            this.Label152.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label152.Border.RightColor = System.Drawing.Color.Black;
            this.Label152.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label152.Border.TopColor = System.Drawing.Color.Black;
            this.Label152.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label152.Height = 0.1875F;
            this.Label152.HyperLink = "";
            this.Label152.Left = 0.25F;
            this.Label152.Name = "Label152";
            this.Label152.Style = "text-align: left; font-weight: normal; font-size: 6.75pt; ";
            this.Label152.Text = "Listed by Sender";
            this.Label152.Top = 0.125F;
            this.Label152.Width = 0.75F;
            // 
            // Label153
            // 
            this.Label153.Border.BottomColor = System.Drawing.Color.Black;
            this.Label153.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label153.Border.LeftColor = System.Drawing.Color.Black;
            this.Label153.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label153.Border.RightColor = System.Drawing.Color.Black;
            this.Label153.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label153.Border.TopColor = System.Drawing.Color.Black;
            this.Label153.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label153.Height = 0.1875F;
            this.Label153.HyperLink = "";
            this.Label153.Left = 0.25F;
            this.Label153.Name = "Label153";
            this.Label153.Style = "text-align: left; font-weight: normal; font-size: 6.75pt; ";
            this.Label153.Text = "Total Number of Pieces";
            this.Label153.Top = 0.25F;
            this.Label153.Width = 1.0625F;
            // 
            // Label154
            // 
            this.Label154.Border.BottomColor = System.Drawing.Color.Black;
            this.Label154.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label154.Border.LeftColor = System.Drawing.Color.Black;
            this.Label154.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label154.Border.RightColor = System.Drawing.Color.Black;
            this.Label154.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label154.Border.TopColor = System.Drawing.Color.Black;
            this.Label154.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label154.Height = 0.1875F;
            this.Label154.HyperLink = "";
            this.Label154.Left = 1.375F;
            this.Label154.Name = "Label154";
            this.Label154.Style = "text-align: center; font-weight: normal; font-size: 6.75pt; ";
            this.Label154.Text = "Received at Post Office";
            this.Label154.Top = 0.125F;
            this.Label154.Width = 1.0625F;
            // 
            // Label155
            // 
            this.Label155.Border.BottomColor = System.Drawing.Color.Black;
            this.Label155.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label155.Border.LeftColor = System.Drawing.Color.Black;
            this.Label155.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label155.Border.RightColor = System.Drawing.Color.Black;
            this.Label155.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label155.Border.TopColor = System.Drawing.Color.Black;
            this.Label155.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label155.Height = 0.1875F;
            this.Label155.HyperLink = "";
            this.Label155.Left = 1.375F;
            this.Label155.Name = "Label155";
            this.Label155.Style = "text-align: center; font-weight: normal; font-size: 6.75pt; ";
            this.Label155.Text = "Total Number of Pieces";
            this.Label155.Top = 0.25F;
            this.Label155.Width = 1.0625F;
            // 
            // Label156
            // 
            this.Label156.Border.BottomColor = System.Drawing.Color.Black;
            this.Label156.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label156.Border.LeftColor = System.Drawing.Color.Black;
            this.Label156.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label156.Border.RightColor = System.Drawing.Color.Black;
            this.Label156.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label156.Border.TopColor = System.Drawing.Color.Black;
            this.Label156.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label156.Height = 0.1875F;
            this.Label156.HyperLink = "";
            this.Label156.Left = 2.5F;
            this.Label156.Name = "Label156";
            this.Label156.Style = "text-align: center; font-weight: normal; font-size: 6.75pt; ";
            this.Label156.Text = "Postmaster,Per(Name of Receiving Employee";
            this.Label156.Top = 0.125F;
            this.Label156.Width = 2.4375F;
            // 
            // Line180
            // 
            this.Line180.Border.BottomColor = System.Drawing.Color.Black;
            this.Line180.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line180.Border.LeftColor = System.Drawing.Color.Black;
            this.Line180.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line180.Border.RightColor = System.Drawing.Color.Black;
            this.Line180.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line180.Border.TopColor = System.Drawing.Color.Black;
            this.Line180.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line180.Height = 1F;
            this.Line180.Left = 1.375F;
            this.Line180.LineWeight = 3F;
            this.Line180.Name = "Line180";
            this.Line180.Top = 0.125F;
            this.Line180.Width = 0F;
            this.Line180.X1 = 1.375F;
            this.Line180.X2 = 1.375F;
            this.Line180.Y1 = 1.125F;
            this.Line180.Y2 = 0.125F;
            // 
            // Line181
            // 
            this.Line181.Border.BottomColor = System.Drawing.Color.Black;
            this.Line181.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line181.Border.LeftColor = System.Drawing.Color.Black;
            this.Line181.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line181.Border.RightColor = System.Drawing.Color.Black;
            this.Line181.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line181.Border.TopColor = System.Drawing.Color.Black;
            this.Line181.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line181.Height = 1F;
            this.Line181.Left = 2.4375F;
            this.Line181.LineWeight = 3F;
            this.Line181.Name = "Line181";
            this.Line181.Top = 0.125F;
            this.Line181.Width = 0F;
            this.Line181.X1 = 2.4375F;
            this.Line181.X2 = 2.4375F;
            this.Line181.Y1 = 1.125F;
            this.Line181.Y2 = 0.125F;
            // 
            // Line183
            // 
            this.Line183.Border.BottomColor = System.Drawing.Color.Black;
            this.Line183.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line183.Border.LeftColor = System.Drawing.Color.Black;
            this.Line183.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line183.Border.RightColor = System.Drawing.Color.Black;
            this.Line183.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line183.Border.TopColor = System.Drawing.Color.Black;
            this.Line183.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line183.Height = 1F;
            this.Line183.Left = 4.9375F;
            this.Line183.LineWeight = 3F;
            this.Line183.Name = "Line183";
            this.Line183.Top = 0.125F;
            this.Line183.Width = 0F;
            this.Line183.X1 = 4.9375F;
            this.Line183.X2 = 4.9375F;
            this.Line183.Y1 = 1.125F;
            this.Line183.Y2 = 0.125F;
            // 
            // Line184
            // 
            this.Line184.Border.BottomColor = System.Drawing.Color.Black;
            this.Line184.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line184.Border.LeftColor = System.Drawing.Color.Black;
            this.Line184.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line184.Border.RightColor = System.Drawing.Color.Black;
            this.Line184.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line184.Border.TopColor = System.Drawing.Color.Black;
            this.Line184.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line184.Height = 0F;
            this.Line184.Left = 0.1875F;
            this.Line184.LineWeight = 3F;
            this.Line184.Name = "Line184";
            this.Line184.Top = 0.125F;
            this.Line184.Width = 9.1875F;
            this.Line184.X1 = 0.1875F;
            this.Line184.X2 = 9.375F;
            this.Line184.Y1 = 0.125F;
            this.Line184.Y2 = 0.125F;
            // 
            // Line186
            // 
            this.Line186.Border.BottomColor = System.Drawing.Color.Black;
            this.Line186.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line186.Border.LeftColor = System.Drawing.Color.Black;
            this.Line186.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line186.Border.RightColor = System.Drawing.Color.Black;
            this.Line186.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line186.Border.TopColor = System.Drawing.Color.Black;
            this.Line186.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line186.Height = 1F;
            this.Line186.Left = 1.375F;
            this.Line186.LineWeight = 3F;
            this.Line186.Name = "Line186";
            this.Line186.Top = 0.125F;
            this.Line186.Width = 0F;
            this.Line186.X1 = 1.375F;
            this.Line186.X2 = 1.375F;
            this.Line186.Y1 = 1.125F;
            this.Line186.Y2 = 0.125F;
            // 
            // Line188
            // 
            this.Line188.Border.BottomColor = System.Drawing.Color.Black;
            this.Line188.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line188.Border.LeftColor = System.Drawing.Color.Black;
            this.Line188.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line188.Border.RightColor = System.Drawing.Color.Black;
            this.Line188.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line188.Border.TopColor = System.Drawing.Color.Black;
            this.Line188.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line188.Height = 1F;
            this.Line188.Left = 4.9375F;
            this.Line188.LineWeight = 3F;
            this.Line188.Name = "Line188";
            this.Line188.Top = 0.125F;
            this.Line188.Width = 0F;
            this.Line188.X1 = 4.9375F;
            this.Line188.X2 = 4.9375F;
            this.Line188.Y1 = 1.125F;
            this.Line188.Y2 = 0.125F;
            // 
            // Label157
            // 
            this.Label157.Border.BottomColor = System.Drawing.Color.Black;
            this.Label157.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label157.Border.LeftColor = System.Drawing.Color.Black;
            this.Label157.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label157.Border.RightColor = System.Drawing.Color.Black;
            this.Label157.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label157.Border.TopColor = System.Drawing.Color.Black;
            this.Label157.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label157.Height = 0.1875F;
            this.Label157.HyperLink = "";
            this.Label157.Left = 0.1875F;
            this.Label157.Name = "Label157";
            this.Label157.Style = "text-align: left; font-weight: normal; font-size: 6.75pt; ";
            this.Label157.Text = "PS Form 3877, February 1994";
            this.Label157.Top = 1.125F;
            this.Label157.Width = 1.3125F;
            // 
            // Label158
            // 
            this.Label158.Border.BottomColor = System.Drawing.Color.Black;
            this.Label158.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label158.Border.LeftColor = System.Drawing.Color.Black;
            this.Label158.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label158.Border.RightColor = System.Drawing.Color.Black;
            this.Label158.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label158.Border.TopColor = System.Drawing.Color.Black;
            this.Label158.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label158.Height = 0.1875F;
            this.Label158.HyperLink = "";
            this.Label158.Left = 3.3125F;
            this.Label158.Name = "Label158";
            this.Label158.Style = "text-align: left; font-weight: bold; font-size: 6.75pt; ";
            this.Label158.Text = "For Must Be Completed By Typrwriter, Ink or Ball Point Pen";
            this.Label158.Top = 1.1875F;
            this.Label158.Width = 2.8125F;
            // 
            // Line190
            // 
            this.Line190.Border.BottomColor = System.Drawing.Color.Black;
            this.Line190.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line190.Border.LeftColor = System.Drawing.Color.Black;
            this.Line190.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line190.Border.RightColor = System.Drawing.Color.Black;
            this.Line190.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line190.Border.TopColor = System.Drawing.Color.Black;
            this.Line190.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line190.Height = 0F;
            this.Line190.Left = 0.1875F;
            this.Line190.LineWeight = 3F;
            this.Line190.Name = "Line190";
            this.Line190.Top = 1.125F;
            this.Line190.Width = 9.1875F;
            this.Line190.X1 = 0.1875F;
            this.Line190.X2 = 9.375F;
            this.Line190.Y1 = 1.125F;
            this.Line190.Y2 = 1.125F;
            // 
            // Line191
            // 
            this.Line191.Border.BottomColor = System.Drawing.Color.Black;
            this.Line191.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line191.Border.LeftColor = System.Drawing.Color.Black;
            this.Line191.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line191.Border.RightColor = System.Drawing.Color.Black;
            this.Line191.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line191.Border.TopColor = System.Drawing.Color.Black;
            this.Line191.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line191.Height = 1F;
            this.Line191.Left = 9.375F;
            this.Line191.LineWeight = 3F;
            this.Line191.Name = "Line191";
            this.Line191.Top = 0.125F;
            this.Line191.Width = 0F;
            this.Line191.X1 = 9.375F;
            this.Line191.X2 = 9.375F;
            this.Line191.Y1 = 1.125F;
            this.Line191.Y2 = 0.125F;
            // 
            // Line192
            // 
            this.Line192.Border.BottomColor = System.Drawing.Color.Black;
            this.Line192.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line192.Border.LeftColor = System.Drawing.Color.Black;
            this.Line192.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line192.Border.RightColor = System.Drawing.Color.Black;
            this.Line192.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line192.Border.TopColor = System.Drawing.Color.Black;
            this.Line192.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line192.Height = 1F;
            this.Line192.Left = 0.1875F;
            this.Line192.LineWeight = 3F;
            this.Line192.Name = "Line192";
            this.Line192.Top = 0.125F;
            this.Line192.Width = 0F;
            this.Line192.X1 = 0.1875F;
            this.Line192.X2 = 0.1875F;
            this.Line192.Y1 = 1.125F;
            this.Line192.Y2 = 0.125F;
            // 
            // ActiveReport31
            // 
            this.PageSettings.Margins.Bottom = 0.2F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.1F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 9.895833F;
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
            ((System.ComponentModel.ISupportInitialize)(this.Label99)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label110)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label112)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label113)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label114)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label115)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label116)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label117)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label118)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label119)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label120)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label121)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label122)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label123)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label124)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label125)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label126)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label127)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label128)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label129)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label136)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label137)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label138)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label139)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label140)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label141)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label142)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label143)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label103)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameAddrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPolicyNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label144)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label145)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label146)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label147)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label148)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label149)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label150)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label151)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label152)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label153)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label154)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label155)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label156)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label157)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label158)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
       
			// Attach Report Events
			this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
		 }

		#endregion
	}
}
