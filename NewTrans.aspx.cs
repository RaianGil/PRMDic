using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using EPolicy;

namespace EPolicy
{
	/// <summary>
	/// Summary description for NewTask.
	/// </summary>
	public partial class NewTask : System.Web.UI.Page
	{

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

			/*//Setup Left-side Banner
			Control LeftMenu = new Control();
			LeftMenu = LoadControl(@"LeftMenu.ascx");
			this.phTopBanner1.Controls.Add(LeftMenu);
			//Load DownDropList*/
	
			DataTable dtTaskControlType	= LookupTables.LookupTables.GetTable("TaskControlType");

			//TaskControlType
			ddlTaskControlType.DataSource = dtTaskControlType;
			ddlTaskControlType.DataTextField = "TaskControlTypeDesc";
			ddlTaskControlType.DataValueField = "TaskControlTypeID";
			ddlTaskControlType.DataBind();
			ddlTaskControlType.SelectedIndex = -1;
			ddlTaskControlType.Items.Insert(0,"");
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			Login.Login cp = HttpContext.Current.User as Login.Login;
			if (cp == null)
			{
				Response.Redirect("Default.aspx?001");
			}
			else
			{
				if(!cp.IsInRole("NEWTASK") && !cp.IsInRole("ADMINISTRATOR"))
				{
					Response.Redirect("Default.aspx?001");
				}
			}
		}

		protected void ddlTaskControlType_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		}

		protected void btnEdit_Click(object sender, System.EventArgs e)
		{
			Login.Login cp = HttpContext.Current.User as Login.Login;
			int userID = 0;

			try
			{
				userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
			}
			catch(Exception ex)
			{
				throw new Exception(
					"Could not parse user id from cp.Identity.Name.", ex);
			}

			string TaskTypeForm = ddlTaskControlType.SelectedItem.Text.Replace(" ","").Trim();
			int TaskTypeFormID = int.Parse(ddlTaskControlType.SelectedItem.Value);

			bool found = false;

			System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(1);

			TaskControl.TaskControl taskControl = null;
			System.Runtime.Remoting.ObjectHandle OhType;
			try
			{
				switch (TaskTypeFormID)
				{
					case 4:				// Quote Auto

						OhType = Activator.CreateInstance("TaskControl","EPolicy.TaskControl."+TaskTypeForm,
							false,BindingFlags.Public | BindingFlags.CreateInstance |BindingFlags.Instance,null,
							new object[1] {false},culture,new object[0] {},null);
						break;

					case 10:			// Auto Personal Policy
						TaskTypeForm = "QuoteAuto";
						OhType = Activator.CreateInstance("TaskControl","EPolicy.TaskControl."+TaskTypeForm,
							false,BindingFlags.Public | BindingFlags.CreateInstance |BindingFlags.Instance,null,
							new object[1] {true},culture,new object[0] {},null);
						break;

					default:			// Etch, ApplicationAuto, Payment, Cert Letter, Endorsement Auto.
						OhType = Activator.CreateInstance("TaskControl","EPolicy.TaskControl."+TaskTypeForm);
						break;
						
				}

				taskControl = (TaskControl.TaskControl) OhType.Unwrap();

			}
			catch (Exception exp)
			{
				EPolicy.TaskControl.AutoGap tc = new EPolicy.TaskControl.AutoGap();
				string d = exp.ToString();
				found = true;
			}

			if (found)
			{
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString(ddlTaskControlType.SelectedItem.Text.Trim()+" is under construction! ");
				this.litPopUp.Visible = true;	
			}
			else
			{
				if(Session["Prospect"] != null)
				{
					taskControl.ProspectID =((Customer.Prospect)  Session["Prospect"]).ProspectID;
					
					if(((Customer.Prospect)  Session["Prospect"]).CustomerNumber != "None")
					{
						taskControl.CustomerNo = ((Customer.Prospect)  Session["Prospect"]).CustomerNumber;
						taskControl.Customer   = Customer.Customer.GetCustomer(taskControl.CustomerNo, userID);						
					}
				}

				if(Session["Customer"] != null)
				{
					taskControl.Customer =((Customer.Customer)  Session["Customer"]);
					taskControl.CustomerNo = taskControl.Customer.CustomerNo;
					taskControl.ProspectID = taskControl.Customer.ProspectID;
				}
				
				if (Session["Prospect"] == null && Session["Customer"] == null 
					&& (TaskTypeForm == "ApplicationAuto" || TaskTypeForm == "Etch"))
				{
					switch(TaskTypeForm)
					{
						case "ApplicationAuto":
							this.litPopUp.Text = Utilities.MakeLiteralPopUpString("The prospect or customer information is empty. This information is required for Application Auto.");
							this.litPopUp.Visible = true;	
							break;
						case "Etch":
							this.litPopUp.Text = Utilities.MakeLiteralPopUpString("The customer information is empty. This information is required for Etch.");
							this.litPopUp.Visible = true;	
							break;
					}
				}
				else
				{
					taskControl.Mode = 1; //ADD

					Session["TaskControl"] = taskControl;

					if (TaskTypeFormID==4)
					{
						Response.Redirect("ExpressAutoQuote.aspx",false);
					}
					else
					{
						Response.Redirect(TaskTypeForm+".aspx",false);
					}
				}
			}
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
