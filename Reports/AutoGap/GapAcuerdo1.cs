using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports
{
	public class GapAcuerdo1 : DataDynamics.ActiveReports.ActiveReport3
	{
		//private int CountDataIndex;
		private string _CopyValue;
		private EPolicy.TaskControl.Policies _taskcontrol;

		public GapAcuerdo1(EPolicy.TaskControl.Policies taskcontrol, string CopyValue)
		{
			_taskcontrol = taskcontrol;
			_CopyValue = CopyValue;

			InitializeComponent();
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		#region ActiveReports Designer generated code
		private PageHeader PageHeader = null;
		private Picture Picture1 = null;
		private Detail Detail = null;
		private PageFooter PageFooter = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GapAcuerdo1));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Picture1 = new DataDynamics.ActiveReports.Picture();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.Picture1)).BeginInit();
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
            this.Picture1});
            this.PageHeader.Height = 10.58264F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // Picture1
            // 
            this.Picture1.Border.BottomColor = System.Drawing.Color.Black;
            this.Picture1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture1.Border.LeftColor = System.Drawing.Color.Black;
            this.Picture1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture1.Border.RightColor = System.Drawing.Color.Black;
            this.Picture1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture1.Border.TopColor = System.Drawing.Color.Black;
            this.Picture1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture1.Height = 10.48F;
            this.Picture1.Image = ((System.Drawing.Image)(resources.GetObject("Picture1.Image")));
            this.Picture1.ImageData = ((System.IO.Stream)(resources.GetObject("Picture1.ImageData")));
            this.Picture1.Left = 0.24F;
            this.Picture1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture1.LineWeight = 0F;
            this.Picture1.Name = "Picture1";
            this.Picture1.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.Picture1.Top = 0.04F;
            this.Picture1.Width = 7.92F;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0.0625F;
            this.PageFooter.Name = "PageFooter";
            // 
            // GapAcuerdo1
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
            this.PrintWidth = 8.416667F;
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
            ((System.ComponentModel.ISupportInitialize)(this.Picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
