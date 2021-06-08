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
using EPolicy.LookupTables;
using EPolicy.Login;

namespace EPolicy
{
    /// <summary>
    /// Summary description for UserPropertiesList.
    /// </summary>
    public partial class UserPropertiesList : System.Web.UI.Page
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
                if (!cp.IsInRole("USERPROPERTIESLIST") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    Response.Redirect("Default.aspx?001");
                }
            }

            if (!IsPostBack)
            {
                DataTable AuthenticatedUser = LookupTables.LookupTables.GetTable("AuthenticatedUser");

                FillGrid(AuthenticatedUser);
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
            //this.searchIndividual.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.searchIndividual_ItemCommand);

        }
        #endregion

        private void FillGrid(DataTable dt)
        {
            searchIndividual.DataSource = null;
            //searchIndividual.CurrentPageIndex = 0;

            Session.Add("DtLogin", dt);

            if (dt.Rows.Count != 0)
            {
                searchIndividual.DataSource = dt;
                searchIndividual.DataBind();
                searchIndividual.UseAccessibleHeader = true;
                searchIndividual.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                searchIndividual.DataSource = null;
                searchIndividual.DataBind();
            }

            LblTotalCases.Text = "Total Users: " + dt.Rows.Count.ToString();
        }

        private void searchIndividual_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.Item.ItemType.ToString() != "Pager") // Select
            {
                int i = int.Parse(e.Item.Cells[1].Text);
                Login.Login login = Login.Login.GetUser(i);

                string ToPage;

                if (Session["ToPage"] == null)
                {
                    ToPage = "UsersProperties.aspx";
                }
                else
                {
                    ToPage = Session["ToPage"].ToString();
                }

                if (Session["Login"] == null)
                    Session.Add("Login", login);
                else
                    Session["Login"] = login;

                Session.Remove("DtLogin");

                Response.Redirect(ToPage + "?" + login.UserID);
            }
            else  // Pager
            {
                //searchIndividual.CurrentPageIndex = int.Parse(e.CommandArgument.ToString())-1;

                searchIndividual.DataSource = (DataTable)Session["DtLogin"];
                searchIndividual.DataBind();
            }
        }

        protected void BtnExit_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Response.Redirect("MainMenu.aspx");
        }
        protected void searchIndividual_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName.ToString() != "Pager") // Select
            {
                int i = int.Parse(searchIndividual.DataKeys[rowIndex].Values["UserID"].ToString());
                //int i = int.Parse(e.Item.Cells[1].Text);
                Login.Login login = Login.Login.GetUser(i);

                string ToPage;

                if (Session["ToPage"] == null)
                {
                    ToPage = "UsersProperties.aspx";
                }
                else
                {
                    ToPage = Session["ToPage"].ToString();
                }

                if (Session["Login"] == null)
                    Session.Add("Login", login);
                else
                    Session["Login"] = login;

                Session.Remove("DtLogin");

                Response.Redirect(ToPage + "?" + login.UserID);
            }
            else  // Pager
            {
                searchIndividual.DataSource = (DataTable)Session["DtLogin"];
                searchIndividual.DataBind();
            }
        }
    }
}
