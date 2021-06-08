using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EPolicy.TaskControl;
using EPolicy.XmlCooker;
using System.Xml;

public partial class Comments : System.Web.UI.Page
{

    private Control LeftMenu;
    private int userID;

    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //

        base.OnInit(e);

        Control Banner = new Control();
        Banner = LoadControl(@"TopBanner1.ascx");
        this.Placeholder1.Controls.Add(Banner);

        //Setup Left-side Banner

        /*LeftMenu = new Control();
        LeftMenu = LoadControl(@"LeftMenu.ascx");
        phTopBanner1.Controls.Add(LeftMenu);*/
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
            if (cp == null)
            {
                Response.Redirect("HomePage.aspx?001");
            }
            else
            {
                if (!cp.IsInRole("COMMENTS") && !cp.IsInRole("ADMINISTRATOR") && !cp.IsInRole("ACCOUNTING"))
                {
                    Response.Redirect("MainMenu.aspx");  //Cambio 
                }
            }

            userID = cp.UserID;

            if (!IsPostBack)
            {
                this.SetReferringPage();

                EPolicy.TaskControl.Comment taskControl;

                if (Session["TaskControlComments"] != null)
                {
                    taskControl = (EPolicy.TaskControl.Comment)Session["TaskControlComments"];
                }
                else
                {
                    taskControl = (EPolicy.TaskControl.Comment)Session["TaskControl"];
                    Session.Add("TaskControlComments", taskControl);
                }

                LblCustomerName.Text = "Policy No.: " ;

                FillDataGrid();
                FillTextControl();
            }
            this.litPopUp.Visible = false;
        }
        catch (Exception exp)
        {
            if (exp.InnerException == null)
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
            else if (exp.InnerException.InnerException == null)
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
            else
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                     System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

            this.litPopUp.Visible = true;
        }
        
    }

        public void FillTextControl()
        {
            try
            {
                EPolicy.TaskControl.Comment taskControl = (EPolicy.TaskControl.Comment)Session["TaskControlComments"];

                TxtComments.Enabled = true;
                TxtComments.Text = "";

             
            }

            catch 
            {
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("A problem occured while assigning data to webpage controls.");
                this.litPopUp.Visible = true;
            }
        }
        public void FillDataGrid()
        {
            try
            {
                EPolicy.TaskControl.Comment taskControl = (EPolicy.TaskControl.Comment)Session["TaskControlComments"];
                LblError.Enabled = false;
                searchComments.DataSource = null;
                DataTable DtTask = new DataTable();
                DtTask = Comment.GetComment(taskControl.TaskControlID);
               

               

                if (DtTask.Rows.Count != 0)
                {
                    searchComments.DataSource = DtTask;
                    searchComments.DataBind();
                }
                else
                {
                    searchComments.DataSource = null;
                    searchComments.DataBind();
                    LblError.Text = "Could not find a match for your search criteria, please try again.";
                }

                LblTotalComments.Text = "Total Comments: " + DtTask.Rows.Count.ToString();


                searchComments.Columns[1].Visible = false;

            }
            catch
            {
                this.litPopUp.Text =  EPolicy.Utilities.MakeLiteralPopUpString("A problem occured while assigning data to webpage controls.");
                this.litPopUp.Visible = true;
            }
        }

        private string ReferringPage
        {
            get
            {
                return ((ViewState["referringPage"] != null) ?
                    ViewState["referringPage"].ToString() : "");
            }
            set
            {
                ViewState["referringPage"] = value;
            }
        }

        private void SetReferringPage()
        {
            if ((Session["FromPage"] != null) && (Session["FromPage"].ToString() != ""))
            {
                this.ReferringPage = Session["FromPage"].ToString();
                Session.Remove("FromPage");
            }
        }

        private void ReturnToReferringPage()
        {
            if (this.ReferringPage != "")
            {
                Response.Redirect(this.ReferringPage);
            }
            Response.Redirect("HomePage.aspx");
        }

        private void RemoveSessionLookUp()
        {
            Session.Remove("LookUpTables");
        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            EPolicy.TaskControl.Comment taskControl = (EPolicy.TaskControl.Comment)Session["TaskControlComments"];

            if (Session["TaskControlComments"] != null)
            {
                this.litPopUp.Visible = false;

                Response.Redirect(this.ReferringPage + "?" + taskControl.TaskControlID);
            }
            else
            {
                this.litPopUp.Visible = false;
                Session.Clear();
            }


        }

        protected void btnApply_Comments(object sender, EventArgs e)
        {  
            
            EPolicy.TaskControl.Comment taskControl = (EPolicy.TaskControl.Comment)Session["TaskControlComments"];
            
            TxtComments.Visible = true;

            if (TxtComments.Text == "")
            {
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Cannot save an empty comment.");
                this.litPopUp.Visible = true;
            }
            else 
            {
                
                Comment.InsertComment(userID, taskControl.TaskControlID, TxtComments.Text.ToString().Trim());
                FillDataGrid();
            }

            //Comment.InsertComment(userID, taskControl.TaskControlID, TxtComments.Text.ToString().Trim());

          // Response.Redirect(Request.Url.ToString());
           //FillDataGrid();




        }

        public void EnableControls() 
        {
            EPolicy.TaskControl.Comment taskControl = (EPolicy.TaskControl.Comment)Session["TaskControlComments"];

            searchComments.Visible = true;
            TxtComments.Visible = true;
            LblError.Visible = true;
        }

        public void DisableControls()
        {
            EPolicy.TaskControl.Comment taskControl = (EPolicy.TaskControl.Comment)Session["TaskControlComments"];

            searchComments.Visible = false;
            TxtComments.Visible = false;
            LblError.Visible = false;
        }

        protected void TxtComments_TextChanged(object sender, EventArgs e)
        {
            
                TxtComments.Enabled = true;
            
        }
        protected void searchComments_SelectedIndexChanged(object sender, EventArgs e)
        {
            //EPolicy.TaskControl.Comment taskControl = (EPolicy.TaskControl.Comment)Session["TaskControl"];

           
        }
        protected void searchComments_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            //RPR 2004-05-17
            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
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

            try
            {

                if (e.Item.ItemType.ToString() != "Pager") // Select
                {
                    if (!cp.IsInRole("DELETECOMMENT"))
                    {
                        throw new Exception("You do not have the requierd permissions to delete the comment");
                    }

                    int i = int.Parse(e.Item.Cells[1].Text);
                    DisabledCommentByID(i);
                    FillDataGrid();
                    TxtComments.Text = string.Empty;
                }
                else  // Pager
                {
                    searchComments.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                    searchComments.DataSource = (DataTable)Session["DtTaskPolicy"];
                    searchComments.DataBind();
                }
            }
            catch (Exception ex)
            {
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString(ex.Message);
                this.litPopUp.Visible = true;
            }
        }

        private static void DisabledCommentByID(int CommentsID)
        {
            try
            {

                DbRequestXmlCookRequestItem[] cookItems =
                    new DbRequestXmlCookRequestItem[1];

                DbRequestXmlCooker.AttachCookItem("CommentsID",
                    SqlDbType.Int, 0, CommentsID.ToString(),
                    ref cookItems);

                XmlDocument xmldoc;

                try
                {
                    xmldoc = DbRequestXmlCooker.Cook(cookItems);

                }
                catch (Exception ex)
                {
                    throw new Exception("Could not cook items.", ex);
                }

                Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
                Executor.Insert("DisabledCommentByID", xmldoc);


            }
            catch (Exception xcp)
            {
                throw new Exception("Could not get the comments.", xcp);
            }
        }
        protected void searchComments_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            //e.Item.Cells[1].Visible = false;
        }
}