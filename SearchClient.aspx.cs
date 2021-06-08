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
using EPolicy.Customer;

namespace EPolicy
{
	/// <summary>
	/// Summary description for SearchClient.
	/// </summary>
	public partial class SearchClient: System.Web.UI.Page
	{
		//protected System.Web.UI.WebControls.DataGrid searchBusiness;
		private DataTable DtCustomers;

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
			this.phTopBanner1.Controls.Add(LeftMenu);*/
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.searchIndividual.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.searchIndividual_ItemCommand);
			this.searchBusiness.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.searchBusiness_ItemCommand);

		}
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
            try
            {
                Page.Form.DefaultButton = btnSearch.UniqueID;
                this.litPopUp.Visible = false;

                Login.Login cp = HttpContext.Current.User as Login.Login;
                if (cp == null)
                {
                    Response.Redirect("Default.aspx?001");
                }
                else
                {
                    if (!cp.IsInRole("SEARCHCLIENT") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        Response.Redirect("Default.aspx?001");
                    }
                }
            }
            catch (Exception exp)
            {
                if (exp.InnerException == null)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
                else if (exp.InnerException.InnerException == null)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
                else
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

                this.litPopUp.Visible = true;
            }
		}

		protected void RdbBusiness_CheckedChanged(object sender, System.EventArgs e)
		{
            //lblFirstName.Text = "Contact First Name";
            //lblLastName1.Text = "Contact Last Name";
            //lblLastName2.Text = "Business Name";
            //lblSocialSecurity.Text = "Employer Social Security";

			ClearTextBox();
		}

		protected void RdbIndividual_CheckedChanged(object sender, System.EventArgs e)
		{
            //lblFirstName.Text = "First Name";
            //lblLastName1.Text = "Last Name 1";
            //lblLastName2.Text = "Last Name 2";
            //lblSocialSecurity.Text = "Social Security";

			ClearTextBox();
		}

		private void ClearTextBox()
		{
			searchIndividual.Visible = false;
			searchBusiness.Visible   = false;

			searchBusiness.DataSource = null;
			searchIndividual.DataSource = null;

			LblTotalCases.Text				= "Total Cases: 0";

			TxtCustomerNo.Text				= "";
			txtFirstName.Text				= "";
			txtLastName1.Text				= "";
			txtLastName2.Text			    = "";
			txtSocialSecurity.Text			= "";
			TxtPhone.Text					= "";
		}

		private void GoToSpecificWebPage(bool isBusiness)
		{
            try
            {
                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = 0;

                try
                {
                    userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        "Could not parse user id from cp.Identity.Name.", ex);
                }

                DataTable dtSpec = (DataTable)Session["DtCustomers"];

                string i = dtSpec.Rows[0]["CustomerNo"].ToString().Trim();

                Customer.Customer customer = Customer.Customer.GetCustomer(i, userID);

                customer.NavegationCustomerTable = (DataTable)Session["DtCustomers"];

                string ToPage;

                if (isBusiness)
                {
                    if (Session["ToPage"] == null)
                    {
                        ToPage = "ClientBusiness.aspx";
                    }
                    else
                    {
                        ToPage = Session["ToPage"].ToString();
                    }
                }
                else
                {
                    if (Session["ToPage"] == null)
                    {
                        ToPage = "ClientIndividual.aspx";
                    }
                    else
                    {
                        ToPage = Session["ToPage"].ToString();
                    }
                }

                if (Session["Customer"] == null)
                    Session.Add("Customer", customer);
                else
                    Session["Customer"] = customer;

                Session.Remove("DtCustomers");

                Response.Redirect(ToPage + "?" + customer.CustomerNo);
            }
            catch (Exception exp)
            {
                if (exp.InnerException == null)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
                else if (exp.InnerException.InnerException == null)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
                else
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

                this.litPopUp.Visible = true;
            }
		}

		private void searchIndividual_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
            try
            {
                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = 0;

                try
                {
                    userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        "Could not parse user id from cp.Identity.Name.", ex);
                }

                if (e.Item.ItemType.ToString() != "Pager") // Select
                {
                    string i = e.Item.Cells[1].Text;
                    Customer.Customer customer = Customer.Customer.GetCustomer(i, userID);

                    customer.NavegationCustomerTable = (DataTable)Session["DtCustomers"];

                    string ToPage;

                    if (Session["ToPage"] == null)
                    {
                        ToPage = "ClientIndividual.aspx";
                    }
                    else
                    {
                        ToPage = Session["ToPage"].ToString();
                    }

                    if (Session["Customer"] == null)
                        Session.Add("Customer", customer);
                    else
                        Session["Customer"] = customer;

                    Session.Remove("DtCustomers");

                    Response.Redirect(ToPage + "?" + customer.CustomerNo);
                }
                else  // Pager
                {
                    searchIndividual.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                    searchIndividual.DataSource = (DataTable)Session["DtCustomers"];
                    searchIndividual.DataBind();
                }
            }
            catch (Exception exp)
            {
                if (exp.InnerException == null)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
                else if (exp.InnerException.InnerException == null)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
                else
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

                this.litPopUp.Visible = true;
            }
		}

		private void searchBusiness_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
            try
            {
                //RPR 2004-05-17
                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = 0;

                try
                {
                    userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        "Could not parse user id from cp.Identity.Name.", ex);
                }

                if (e.Item.ItemType.ToString() != "Pager") // Select
                {
                    int i = int.Parse(e.Item.Cells[1].Text);
                    Customer.Customer customer = Customer.Customer.GetCustomer(i.ToString(),
                        userID);

                    customer.NavegationCustomerTable = (DataTable)Session["DtCustomers"];

                    string ToPage;

                    if (Session["ToPage"] == null)
                    {
                        ToPage = "ClientBusiness.aspx";
                    }
                    else
                    {
                        ToPage = Session["ToPage"].ToString();
                    }

                    if (Session["Customer"] == null)
                        Session.Add("Customer", customer);
                    else
                        Session["Customer"] = customer;

                    Session.Remove("DtCustomers");

                    Response.Redirect(ToPage + "?" + customer.CustomerNo);
                }
                else  // Pager
                {
                    searchBusiness.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                    searchBusiness.DataSource = (DataTable)Session["DtCustomers"];
                    searchBusiness.DataBind();
                }
            }
            catch (Exception exp)
            {
                if (exp.InnerException == null)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
                else if (exp.InnerException.InnerException == null)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
                else
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

                this.litPopUp.Visible = true;
            }
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
            try
            {
                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                LblError.Visible = false;
                searchBusiness.DataSource = null;
                searchIndividual.DataSource = null;
                DtCustomers = null;

                searchIndividual.CurrentPageIndex = 0;
                searchBusiness.CurrentPageIndex = 0;

                searchIndividual.Visible = false;
                searchBusiness.Visible = false;

                //LblPleaseWait.Visible = true;

                bool business = RdbBusiness.Checked;

                DtCustomers = Customer.Customer.GetCustomerByCriteria(TxtCustomerNo.Text.Trim(),
                    txtFirstName.Text.Trim().ToLower().Replace('ñ', 'n').Replace('á', 'a').Replace('í','i').Replace('ó','o').Replace('ú','u').Replace('é', 'e'),
                    txtLastName1.Text.Trim().ToLower().Replace('ñ', 'n').Replace('á', 'a').Replace('í', 'i').Replace('ó', 'o').Replace('ú', 'u').Replace('é', 'e'),
                    txtLastName2.Text.Trim().ToLower().Replace('ñ', 'n').Replace('á', 'a').Replace('í', 'i').Replace('ó', 'o').Replace('ú', 'u').Replace('é', 'e'),
                    txtSocialSecurity.Text.Trim(),
                    TxtPhone.Text.Trim(), business, false, txtSocialSecurity.Text.Trim(),
                    txtLastName2.Text.Trim(), userID);

                Session.Remove("DtCustomers");
                Session.Add("DtCustomers", DtCustomers);

                if (DtCustomers.Rows.Count != 0)
                {
                    if (RdbBusiness.Checked == true)
                    {
                        searchIndividual.Visible = false;
                        searchBusiness.Visible = true;

                        searchBusiness.DataSource = DtCustomers;
                        searchBusiness.DataBind();
                    }
                    else
                    {
                        searchIndividual.Visible = true;
                        searchBusiness.Visible = false;

                        searchIndividual.DataSource = DtCustomers;
                        searchIndividual.DataBind();
                    }
                }
                else
                {
                    if (RdbBusiness.Checked == true)
                    {
                        searchBusiness.DataSource = null;
                        searchBusiness.DataBind();
                    }
                    else
                    {
                        searchIndividual.DataSource = null;
                        searchIndividual.DataBind();
                    }
                    LblError.Visible = true;
                    LblError.Text = "Could not find a match for your search criteria, please try again.";
                }

                LblTotalCases.Text = "Total Cases: " + DtCustomers.Rows.Count.ToString();

                //Si tiene un solo record se va a dirigir a la pantalla correspondiente.
                if (DtCustomers.Rows.Count == 1)
                    GoToSpecificWebPage(RdbBusiness.Checked);
            }
            catch (Exception exp)
            {
                if (exp.InnerException == null)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
                else if (exp.InnerException.InnerException == null)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
                else
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

                this.litPopUp.Visible = true;
            }
		}

		protected void btnClear_Click(object sender, System.EventArgs e)
		{
			ClearTextBox();
		}

		private void BtnNewIndProspect_Click(object sender, System.EventArgs e)
		{
            try
            {
                Session.Clear();
                Customer.Customer customer = new Customer.Customer();
                customer.Mode = (int)Customer.Customer.CustomerMode.ADD;
                Session.Add("Customer", customer);

                Response.Redirect("ClientIndividual.aspx");
            }
            catch (Exception exp)
            {
                if (exp.InnerException == null)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
                else if (exp.InnerException.InnerException == null)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
                else
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

                this.litPopUp.Visible = true;
            }
		}

		private void BtnNewBusProspect_Click(object sender, System.EventArgs e)
		{
            try
            {
                Session.Clear();

                Customer.Customer customer = new Customer.Customer();
                customer.Mode = (int)Customer.Customer.CustomerMode.ADD;
                customer.IsBusiness = true;
                Session.Add("Customer", customer);

                Response.Redirect("ClientBusiness.aspx");
            }
            catch (Exception exp)
            {
                if (exp.InnerException == null)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
                else if (exp.InnerException.InnerException == null)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
                else
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

                this.litPopUp.Visible = true;
            }
		}
	}
}