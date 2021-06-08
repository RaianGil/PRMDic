using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Threading;

namespace EPolicy
{
	/// <summary>
	/// Summary description for selectDate.
	/// </summary>
	public partial class selectDate : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{


			Login.Login cp = HttpContext.Current.User as Login.Login;
			if (cp == null)
			{
				Response.Redirect("Default.aspx?001");
			}
			else
			{
				if(!cp.IsInRole("SELECTDATE") && !cp.IsInRole("ADMINISTRATOR"))
				{
					Response.Redirect("Default.aspx?001");
				}
			}

			CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
			Thread.CurrentThread.CurrentCulture = culture;
			Thread.CurrentThread.CurrentUICulture = culture;
			DateTimeFormatInfo dtf = DateTimeFormatInfo.CurrentInfo;
			/*this.cboMonths.DataSource = dtf.MonthNames;
			this.cboMonths.DataBind();*/

			if(!IsPostBack)
			{
				int year = DateTime.Today.Year;
				for(int i=0;i<150;i++)
				{
					cboYears.Items.Add(year.ToString());
					year--;
				}
				cboMonths.SelectedIndex = DateTime.Today.Month - 1;
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		protected void cboMonths_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			calSelectDay.VisibleDate 
				= new DateTime(int.Parse(cboYears.SelectedItem.Value),
							   int.Parse(cboMonths.SelectedItem.Value),1);
		}

		protected void cboYears_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			calSelectDay.VisibleDate 
				= new DateTime(int.Parse(cboYears.SelectedItem.Value),
				int.Parse(cboMonths.SelectedItem.Value),1);
		}

		protected void calSelectDay_SelectionChanged(Object sender, System.EventArgs e)
		{
			CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
			Thread.CurrentThread.CurrentCulture = culture;
			Thread.CurrentThread.CurrentUICulture = culture;
			DateTimeFormatInfo dtf = DateTimeFormatInfo.CurrentInfo;
			string strjscript = "<script language='javascript'>";
			strjscript += "window.opener." + HttpContext.Current.Request.QueryString["formname"];
			strjscript += ".value = '" + calSelectDay.SelectedDate.ToString("MM/dd/yyyy") + "';window.close();";
			strjscript += "</script" + ">"; //Don't ask, tool bug.
			Literal1.Text = strjscript;
		}
		    
		    
		protected void calSelectDay_DayRender(Object source, DayRenderEventArgs e)
		{
			if (e.Day.Date.ToString("d") == DateTime.Now.ToString("d"))
			{
				e.Cell.BackColor = System.Drawing.Color.LightGray;
			}
		    
		}
	}
}
