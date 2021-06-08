using System;
using System.Data;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Text.RegularExpressions;
using EPolicy.Customer;


namespace EPolicy2.Reports
{
	public class CustomersLabels : DataDynamics.ActiveReports.ActiveReport3
	{
		private DataTable _dt;
    	private int iSkipLabels = 0;
//		private string [] _CustomersLabels = new string[6];
//		private DataView _myDataView;
		private int index = 0;
		private int Counter = 1;

		public CustomersLabels(DataTable dt)//DataView myDataView
		{
			_dt = dt;
			InitializeComponent();
		}

		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
			if (iSkipLabels > 0)
			{
				iSkipLabels = iSkipLabels -1;
				LayoutAction = LayoutAction.MoveLayout;
			}
		}

		private void CustomersLabels_FetchData(object sender, DataDynamics.ActiveReports.ActiveReport3.FetchEventArgs eArgs)
		{
			
			if (index <= _dt.Rows.Count-1)
			{
				iSkipLabels = Convert.ToInt32(_dt.Rows[index]["Position"]) - Counter;		
										
				eArgs.EOF = false;

				this.Fields["Name"].Value = _dt.Rows[index]["FirstName"].ToString() + " " + _dt.Rows[index]["Initial"].ToString() + " " + _dt.Rows[index]["LastName1"].ToString() + " " + _dt.Rows[index]["LastName2"].ToString();
				this.Fields["Address1"].Value = _dt.Rows[index]["Address1"].ToString(); 
				this.Fields["Address2"].Value = _dt.Rows[index]["Address2"].ToString(); 
				this.Fields["City"].Value	  = _dt.Rows[index]["City"].ToString().Trim()+ " " + _dt.Rows[index]["State"].ToString().Trim() + " " + _dt.Rows[index]["ZipCode"].ToString().Trim(); 

				
				if(_dt.Rows[index]["Address2"].ToString().Trim() == "")
				{
					this.Fields["Address2"].Value = _dt.Rows[index]["City"].ToString().Trim()+ " " + _dt.Rows[index]["State"].ToString().Trim() + " " + _dt.Rows[index]["ZipCode"].ToString().Trim();
				    this.Fields["City"].Value = "";
				}

				

			Counter = Convert.ToInt32(_dt.Rows[index]["Position"]) + 1;
			
			}
			else
			{
				eArgs.EOF = true;
			}	
			index ++;
			
		}

		private void CustomersLabels_DataInitialize(object sender, System.EventArgs eArgs)
		{
			
			TextBox1.Text = "";
			TextBox2.Text = "";
			TextBox3.Text = "";
			TextBox4.Text = "";
			this.Fields.Clear();
			this.Fields.Add ("Name");
			this.Fields.Add("Address1");
			this.Fields.Add ("Address2");
			this.Fields.Add("City");
   
		}

		#region ActiveReports Designer generated code
		private Detail Detail = null;
		private TextBox TextBox1 = null;
		private TextBox TextBox2 = null;
		private TextBox TextBox3 = null;
		private TextBox TextBox4 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomersLabels));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.TextBox1 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox2 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox3 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox4 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanGrow = false;
            this.Detail.ColumnCount = 2;
            this.Detail.ColumnDirection = DataDynamics.ActiveReports.ColumnDirection.AcrossDown;
            this.Detail.ColumnSpacing = 1F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.TextBox1,
                        this.TextBox2,
                        this.TextBox3,
                        this.TextBox4});
            this.Detail.Height = 3.25F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
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
            this.TextBox1.DataField = "Name";
            this.TextBox1.Height = 0.2F;
            this.TextBox1.Left = 0.5625F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "";
            this.TextBox1.Text = "TextBox1";
            this.TextBox1.Top = 2F;
            this.TextBox1.Width = 2.875F;
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
            this.TextBox2.DataField = "Address1";
            this.TextBox2.Height = 0.2F;
            this.TextBox2.Left = 0.5625F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Style = "";
            this.TextBox2.Text = "TextBox2";
            this.TextBox2.Top = 2.1875F;
            this.TextBox2.Width = 2.875F;
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
            this.TextBox3.DataField = "Address2";
            this.TextBox3.Height = 0.2F;
            this.TextBox3.Left = 0.5625F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Style = "";
            this.TextBox3.Text = "TextBox3";
            this.TextBox3.Top = 2.375F;
            this.TextBox3.Width = 2.875F;
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
            this.TextBox4.DataField = "City";
            this.TextBox4.Height = 0.2F;
            this.TextBox4.Left = 0.5625F;
            this.TextBox4.MultiLine = false;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Style = "";
            this.TextBox4.Text = "TextBox4";
            this.TextBox4.Top = 2.5625F;
            this.TextBox4.Width = 2.875F;
            // 
            // ActiveReport31
            // 
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.5F;
            this.PageSettings.Margins.Left = 0.3F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 4F;
            this.PrintWidth = 8.177083F;
            this.Sections.Add(this.Detail);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
       
			// Attach Report Events
			this.Detail.Format += new System.EventHandler(this.Detail_Format);
			this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.CustomersLabels_FetchData);
			this.DataInitialize += new System.EventHandler(this.CustomersLabels_DataInitialize);
		 }

		#endregion
	}
}
