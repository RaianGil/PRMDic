namespace EPolicy
{
	using System;
	using System.Configuration;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using EPolicy;
	using System.Globalization;

	/// <summary>
	///		Summary description for TopBanner.
	/// </summary>
	public partial  class TopBanner2: System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.ImageButton imgReport;
		//int locationID = 0;

		protected void Page_Load(object sender, System.EventArgs e)
		{		
			LblDate.Text = Utilities.LongDateSpanish(DateTime.Now);
			this.lblUserName.Text = "USER: ";

			Login.Login cp = HttpContext.Current.User as Login.Login;

            if (cp != null && cp.Identity.Name != string.Empty)
            {
                this.lblUserName.Visible = true;
                this.lblUserName.Text = "USER: " + cp.Identity.Name.Split("|".ToCharArray())[0];
                this.Img1.Visible = false;
                //this.Img2.Visible = true;
                //this.Img3.Visible = true;
                //LblOficina.Text = LookupTables.LookupTables.GetDescription("Location",locationID.ToString());
            }
            else
            {
                this.lblUserName.Visible = true;
                this.lblUserName.Text = string.Empty;
                this.Img1.Visible = true;
                //this.Img2.Visible = false;
                //this.Img3.Visible = false;
                //LblOficina.Text = string.Empty;
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
	

	}
}