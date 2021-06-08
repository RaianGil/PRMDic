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
using EPolicy;
using EPolicy.TaskControl;

namespace EPolicy
{
	/// <summary>
	/// Summary description for ViewIncentive.
	/// </summary>
	public partial class ViewIncentive : System.Web.UI.Page
	{
		private DataTable DtTask;
		private Control LeftMenu;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			Login.Login cp = HttpContext.Current.User as Login.Login;
			if (cp == null)
			{
				Response.Redirect("HomePage.aspx?001");
			}
			else
			{
				if(!cp.IsInRole("VIEWINCENTIVE") && !cp.IsInRole("ADMINISTRATOR"))
				{
					Response.Redirect("HomePage.aspx?001");
				}
			}

			if(!IsPostBack)
			{
				this.SetReferringPage();

				TaskControl.Policy taskControl = (TaskControl.Policy) Session["TaskControl"];
				// JP01 LblCustomerName.Text = "Policy No.: "+ taskControl.PolicyType.Trim()+" "+ taskControl.PolicyNo.Trim()+" "+taskControl.Certificate.Trim()+" "+taskControl.Suffix.Trim();

				FillDataGrid();
				FillTextControl();
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

			Control Banner = new Control();
			Banner = LoadControl(@"TopBanner1.ascx");
			this.Placeholder1.Controls.Add(Banner);

			//Setup Left-side Banner
			
            //LeftMenu = new Control();
            //LeftMenu = LoadControl(@"LeftMenu.ascx");
            //phTopBanner1.Controls.Add(LeftMenu);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.searchIndividual.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.searchIndividual_ItemDataBound);

		}
		#endregion

		private string ReferringPage
		{
			get
			{
				return ((ViewState["referringPage"] != null)?
					ViewState["referringPage"].ToString():"");
			}
			set
			{
				ViewState["referringPage"] = value;
			}
		}

		private void SetReferringPage()
		{
			if((Session["FromPage"] != null) && (Session["FromPage"].ToString() != ""))
			{
				this.ReferringPage = Session["FromPage"].ToString();
				Session.Remove("FromPage");
			}
		}

		private void ReturnToReferringPage()
		{
			if(this.ReferringPage != "")
			{
				Response.Redirect(this.ReferringPage);
			}
			Response.Redirect("HomePage.aspx");
		}

		private void btnClose_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ReturnToReferringPage();
		}

		private void FillTextControl()
		{
			TaskControl.Policy taskControl = (TaskControl.Policy) Session["TaskControl"];

			/* JP01 LblStatus.Text				= taskControl.Status;*/
		}

		private void FillDataGrid()
		{
			TaskControl.Policy taskControl = (TaskControl.Policy) Session["TaskControl"];

			LblError.Visible = false;
			searchIndividual.DataSource = null;
			DtTask = null;

			/* JP01 taskControl.SupplierSelectedTable = TaskControl.Policy.GetSelectedSupplier(taskControl.TaskControlID);
			DtTask = taskControl.SupplierSelectedTable;
				
			Session.Remove("DtTask");
			Session.Add("DtTask",DtTask);

			if (DtTask.Rows.Count != 0)
			{
				searchIndividual.DataSource = DtTask;
				searchIndividual.DataBind();
			}
			else
			{
				searchIndividual.DataSource = null;
				searchIndividual.DataBind();

				//LblError.Visible = true;
				LblError.Text = "Could not find a match for your search criteria, please try again.";
			}

			LblTotalCases.Text = "Total Cases: "+DtTask.Rows.Count.ToString();	*/
		}

		private void searchIndividual_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			TaskControl.Policy taskControl = (TaskControl.Policy) Session["TaskControl"];
			DataTable dtCol =  taskControl.SupplierSelectedTable;
			
			DataColumnCollection dc = dtCol.Columns;

			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				DateTime IncentiveDateField;
				double IncentivePercentField;

				if (DataBinder.Eval(e.Item.DataItem,"IncentiveDate") != "" &&
					DataBinder.Eval(e.Item.DataItem,"IncentiveDate") != System.DBNull.Value)
				{
					IncentiveDateField = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem,"IncentiveDate","{0:MM/dd/yyyy}"));
					e.Item.Cells[4].Text = IncentiveDateField.ToShortDateString();
				}

				if (DataBinder.Eval(e.Item.DataItem,"IncentiveSupplierPercent") != "")
				{
					if (DataBinder.Eval(e.Item.DataItem,"IncentiveSupplierPercent") != System.DBNull.Value)
					{														   
						double commPerc = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem,"IncentiveSupplierPercent"));
						commPerc = commPerc/10;
						IncentivePercentField = commPerc;
						e.Item.Cells[5].Text = IncentivePercentField.ToString().Trim()+"%";
					}
				}
			}
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			ReturnToReferringPage();
		}
	}
}
