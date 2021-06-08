namespace EPolicy.EPolicyWeb.Components
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
    using EPolicy;

	/// <summary>
	///		Summary description for LeftReportMenu.
	/// </summary>
	public partial  class LeftReportMenu : System.Web.UI.UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
			if (cp == null)
			{
				Response.Redirect("Default.aspx?001");
                
			}
			else
			{
				VerifyAccess(cp);

			}
		}

		private void VerifyAccess(EPolicy.Login.Login cp)
		{
    		if(!cp.IsInRole("BTNCLIENTREPORTSLEFTREPORTMENU") && !cp.IsInRole("ADMINISTRATOR"))
			{
				this.btnClientReport.Visible = false;
			}
			else
			{
				this.btnClientReport.Visible = true;
			}

			if(!cp.IsInRole("BTNPAYMENTREPORTSLEFTREPORTMENU") && !cp.IsInRole("ADMINISTRATOR"))
			{
				this.btnPaymentReports.Visible = false;
			}
			else
			{
				this.btnPaymentReports.Visible = true;
			}

            if (!cp.IsInRole("BTNRENEWALREPORTSLEFTREPORTMENU") && !cp.IsInRole("ADMINISTRATOR"))
            {
                this.btnRenewalReport.Visible = false;
            }
            else
            {
                this.btnRenewalReport.Visible = true;
            }

			if(!cp.IsInRole("BTNCOMMISSIONREPORTSLEFTREPORTMENU") && !cp.IsInRole("ADMINISTRATOR"))
			{
				this.btnCommissionReport.Visible = false;
			}
			else
			{
				this.btnCommissionReport.Visible = true;
			}
            if (cp.IsInRole("REPORTRENEWAL"))
            {
                btnQueriesGroupReport.Enabled = false;
                btnQueriesGroupReport.Visible = false;
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
		
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion

		protected void Button3_Click(object sender, System.EventArgs e)
		{
			Session.Clear();
			Response.Redirect("MainMenu.aspx");
		}

		protected void Button10_Click(object sender, System.EventArgs e)
		{
			Session.Clear();
			Response.Redirect("ClientReport.aspx");
		}

		protected void Button11_Click(object sender, System.EventArgs e)
		{
			Session.Clear();
			Response.Redirect("PoliciesReports.aspx");
		}

        protected void btnRenewalReport_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Response.Redirect("RenewalReport.aspx");
        }

		protected void Button12_Click(object sender, System.EventArgs e)
		{
			Session.Clear();
			Response.Redirect("PaymentsReport.aspx");
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			Session.Clear();
			Response.Redirect("CommissionReport.aspx");
		}

		protected void Button2_Click(object sender, System.EventArgs e)
		{
			Session.Clear();
			Response.Redirect("IncentiveReport.aspx");
		}

		protected void btnPoliciesReports_Click(object sender, System.EventArgs e)
		{
			Session.Clear();
			Response.Redirect("QueriesGroupReports.aspx");
		}
	}
}
