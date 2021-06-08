using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Application7 : System.Web.UI.Page
{
    private Control LeftMenu;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region Web Form Designer generated code
        Control Banner = new Control();
        Banner = LoadControl(@"TopBanner.ascx");
        //((Baldrich.BaldrichWeb.Components.TopBanner)Banner).SelectedOption = (int)Baldrich.HeadBanner.MenuOptions.Home;
        this.Placeholder1.Controls.Add(Banner);

        //Setup Left-side Banner

        LeftMenu = new Control();
        LeftMenu = LoadControl(@"LeftMenu.ascx");
        phTopBanner1.Controls.Add(LeftMenu);
        #endregion

        this.litPopUp.Visible = false;

        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        if (cp == null)
        {
            Response.Redirect("Default.aspx?001");
        }
        else
        {
            if (!cp.IsInRole("APPLICATION") && !cp.IsInRole("ADMINISTRATOR"))
            {
                Response.Redirect("Default.aspx?001");
            }
        }


        if (Session["AutoPostBack"] == null)
        {
            if (!IsPostBack)
            {
                if (Session["TaskControl"] != null)
                {
                    EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

                    switch (taskControl.ApplicationMode)
                    {
                        case "ADD":
                            EnableControls();
                            FillTextControl();

                            rdoMca62.Items[0].Selected = false;
                            rdoMca63.Items[0].Selected = false;
                            rdoMca64.Items[0].Selected = false;
                            rdoMca65.Items[0].Selected = false;
                            rdoMca66.Items[0].Selected = false;
                            rdoMca67.Items[0].Selected = false;
                            rdoMca68.Items[0].Selected = false;
                            rdoMca69.Items[0].Selected = false;
                            rdoMca70.Items[0].Selected = false;
                            rdoMca71.Items[0].Selected = false;
                            rdoMca72.Items[0].Selected = false;
                            rdoMca73a.Items[0].Selected = false;
                            rdoMca73b.Items[0].Selected = false;
                            rdoMca73c.Items[0].Selected = false;
                            rdoMca73d.Items[0].Selected = false;
                            rdoMca73e.Items[0].Selected = false;
                            rdoMca73f.Items[0].Selected = false;
                            break;

                        case "UPDATE":
                            FillTextControl();
                            EnableControls();
                            break;

                        default:
                            FillTextControl();
                            DisableControls();
                            break;
                    }
                }
            }
            else
            {
                if (Session["TaskControl"] != null)
                {
                    EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];
                    if (taskControl.Mode == 4)
                    {
                        //DisableControls();
                    }
                }
            }
        }
        else
        {
            //FillTextControl();
            //EnableControls();
            Session.Remove("AutoPostBack");
        }

    }

    private void EnableControls()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        btnNextBottom.Visible = true;
        btnPrevBottom.Visible = true;
        btnNextTop.Enabled = true;
        btnNextBottom.Enabled = true;

        rdoMca62.Enabled = true;
        rdoMca63.Enabled = true;
        rdoMca64.Enabled = true;
        rdoMca65.Enabled = true;
        rdoMca66.Enabled = true;
        rdoMca67.Enabled = true;
        rdoMca68.Enabled = true;
        rdoMca69.Enabled = true;
        rdoMca70.Enabled = true;
        rdoMca71.Enabled = true;
        rdoMca72.Enabled = true;
        rdoMca73a.Enabled = true;
        rdoMca73b.Enabled = true;
        rdoMca73c.Enabled = true;
        rdoMca73d.Enabled = true;
        rdoMca73e.Enabled = true;
        rdoMca73f.Enabled = true;
    }

    protected void btnNextTop_Click(object sender, EventArgs e)
    {
        Save();
    }
    protected void btnNextBottom_Click(object sender, EventArgs e)
    {
        Save();
    }

    private void Save()
    {
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
            ValidateFields();

            FillProperties();
            EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

            taskControl.Save(userID, 7);  //(userID);
            FillTextControl();
            DisableControls();

            Session["TaskControl"] = taskControl;

            if (taskControl.ApplicationMode == "UPDATE" || taskControl.ApplicationMode == "ADD")
            {
                if (taskControl.ApplicationExist(taskControl.TaskControlID, 7))
                    taskControl.ApplicationMode = "UPDATE";
                else
                    taskControl.ApplicationMode = "ADD";
            }
            else
            {
                if (taskControl.ApplicationExist(taskControl.TaskControlID, 7))
                    taskControl.ApplicationMode = "";
                else
                    taskControl.ApplicationMode = "ADD";
            }

            Response.Redirect("Application8.aspx", false);
            //this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Information saved successfully.");
            //this.litPopUp.Visible = true;
        }
        catch (Exception exp)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Unable to save this Information. " + exp.Message);
            this.litPopUp.Visible = true;
        }
    }

    #region VerifyAccess
    private void VerifyAccess()
    {
        //TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

        //Login.Login cp = HttpContext.Current.User as Login.Login;

        //if (!cp.IsInRole("BTNEDITPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
        //{
        //    this.btnEdit.Visible = false;
        //}
        //else
        //{
        //    this.btnEdit.Visible = true;
        //}
    }
    #endregion

    private void DisableControls()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        btnNextBottom.Visible = true;
        btnPrevBottom.Visible = true;
        btnNextTop.Enabled = true;
        btnNextBottom.Enabled = true;

        rdoMca62.Enabled = false;
        rdoMca63.Enabled = false;
        rdoMca64.Enabled = false;
        rdoMca65.Enabled = false;
        rdoMca66.Enabled = false;
        rdoMca67.Enabled = false;
        rdoMca68.Enabled = false;
        rdoMca69.Enabled = false;
        rdoMca70.Enabled = false;
        rdoMca71.Enabled = false;
        rdoMca72.Enabled = false;
        rdoMca73a.Enabled = false;
        rdoMca73b.Enabled = false;
        rdoMca73c.Enabled = false;
        rdoMca73d.Enabled = false;
        rdoMca73e.Enabled = false;
        rdoMca73f.Enabled = false;

        VerifyAccess();

    }

    private void ValidateFields()
    {
        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        int userID = 0;
        userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

        ArrayList errorMessages = new ArrayList();

        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        try
        {
            if (errorMessages.Count > 0)
            {
                string popUpString = "";

                foreach (string message in errorMessages)
                {
                    popUpString += message + " ";
                }

                throw new Exception(popUpString);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private void FillProperties()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        if (rdoMca62.Items[0].Selected)
        {
            taskControl.Mca62 = true;
        }
        else
        {
            taskControl.Mca62 = false;
        }

        if (rdoMca63.Items[0].Selected)
        {
            taskControl.Mca63 = true;
        }
        else
        {
            taskControl.Mca63 = false;
        }

        if (rdoMca64.Items[0].Selected)
        {
            taskControl.Mca64 = true;
        }
        else
        {
            taskControl.Mca64 = false;
        }

        if (rdoMca65.Items[0].Selected)
        {
            taskControl.Mca65 = true;
        }
        else
        {
            taskControl.Mca65 = false;
        }

        if (rdoMca66.Items[0].Selected)
        {
            taskControl.Mca66 = true;
        }
        else
        {
            taskControl.Mca66 = false;
        }

        if (rdoMca67.Items[0].Selected)
        {
            taskControl.Mca67 = true;
        }
        else
        {
            taskControl.Mca67 = false;
        }

        if (rdoMca68.Items[0].Selected)
        {
            taskControl.Mca68 = true;
        }
        else
        {
            taskControl.Mca68 = false;
        }

        if (rdoMca69.Items[0].Selected)
        {
            taskControl.Mca69 = true;
        }
        else
        {
            taskControl.Mca69 = false;
        }

        if (rdoMca70.Items[0].Selected)
        {
            taskControl.Mca70 = true;
        }
        else
        {
            taskControl.Mca70 = false;
        }

        if (rdoMca71.Items[0].Selected)
        {
            taskControl.Mca71 = true;
        }
        else
        {
            taskControl.Mca71 = false;
        }

        if (rdoMca72.Items[0].Selected)
        {
            taskControl.Mca72 = true;
        }
        else
        {
            taskControl.Mca72 = false;
        }

        if (rdoMca73a.Items[0].Selected)
        {
            taskControl.Mca73a = true;
        }
        else
        {
            taskControl.Mca73a = false;
        }

        if (rdoMca73b.Items[0].Selected)
        {
            taskControl.Mca73b = true;
        }
        else
        {
            taskControl.Mca73b = false;
        }

        if (rdoMca73c.Items[0].Selected)
        {
            taskControl.Mca73c = true;
        }
        else
        {
            taskControl.Mca73c = false;
        }

        if (rdoMca73d.Items[0].Selected)
        {
            taskControl.Mca73d = true;
        }
        else
        {
            taskControl.Mca73d = false;
        }

        if (rdoMca73e.Items[0].Selected)
        {
            taskControl.Mca73e = true;
        }
        else
        {
            taskControl.Mca73e = false;
        }

        if (rdoMca73f.Items[0].Selected)
        {
            taskControl.Mca73f = true;
        }
        else
        {
            taskControl.Mca73f = false;
        }
    }

    private void FillTextControl()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        int userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

        lblTaskControlID.Text = taskControl.TaskControlID.ToString();
        if (taskControl.Mca62)
        {
            rdoMca62.Items[0].Selected = true;
            rdoMca62.Items[1].Selected = false;
        }
        else
        {
            rdoMca62.Items[0].Selected = false;
            rdoMca62.Items[1].Selected = true;
        }

        if (taskControl.Mca63)
        {
            rdoMca63.Items[0].Selected = true;
            rdoMca63.Items[1].Selected = false;
        }
        else
        {
            rdoMca63.Items[0].Selected = false;
            rdoMca63.Items[1].Selected = true;
        }

        if (taskControl.Mca64)
        {
            rdoMca64.Items[0].Selected = true;
            rdoMca64.Items[1].Selected = false;
        }
        else
        {
            rdoMca64.Items[0].Selected = false;
            rdoMca64.Items[1].Selected = true;
        }

        if (taskControl.Mca65)
        {
            rdoMca65.Items[0].Selected = true;
            rdoMca65.Items[1].Selected = false;
        }
        else
        {
            rdoMca65.Items[0].Selected = false;
            rdoMca65.Items[1].Selected = true;
        }

        if (taskControl.Mca66)
        {
            rdoMca66.Items[0].Selected = true;
            rdoMca66.Items[1].Selected = false;
        }
        else
        {
            rdoMca66.Items[0].Selected = false;
            rdoMca66.Items[1].Selected = true;
        }

        if (taskControl.Mca67)
        {
            rdoMca67.Items[0].Selected = true;
            rdoMca67.Items[1].Selected = false;
        }
        else
        {
            rdoMca67.Items[0].Selected = false;
            rdoMca67.Items[1].Selected = true;
        }

        if (taskControl.Mca68)
        {
            rdoMca68.Items[0].Selected = true;
            rdoMca68.Items[1].Selected = false;
        }
        else
        {
            rdoMca68.Items[0].Selected = false;
            rdoMca68.Items[1].Selected = true;
        }

        if (taskControl.Mca69)
        {
            rdoMca69.Items[0].Selected = true;
            rdoMca69.Items[1].Selected = false;
        }
        else
        {
            rdoMca69.Items[0].Selected = false;
            rdoMca69.Items[1].Selected = true;
        }

        if (taskControl.Mca70)
        {
            rdoMca70.Items[0].Selected = true;
            rdoMca70.Items[1].Selected = false;
        }
        else
        {
            rdoMca70.Items[0].Selected = false;
            rdoMca70.Items[1].Selected = true;
        }

        if (taskControl.Mca71)
        {
            rdoMca71.Items[0].Selected = true;
            rdoMca71.Items[1].Selected = false;
        }
        else
        {
            rdoMca71.Items[0].Selected = false;
            rdoMca71.Items[1].Selected = true;
        }

        if (taskControl.Mca72)
        {
            rdoMca72.Items[0].Selected = true;
            rdoMca72.Items[1].Selected = false;
        }
        else
        {
            rdoMca72.Items[0].Selected = false;
            rdoMca72.Items[1].Selected = true;
        }

        if (taskControl.Mca73a)
        {
            rdoMca73a.Items[0].Selected = true;
            rdoMca73a.Items[1].Selected = false;
        }
        else
        {
            rdoMca73a.Items[0].Selected = false;
            rdoMca73a.Items[1].Selected = true;
        }

        if (taskControl.Mca73b)
        {
            rdoMca73b.Items[0].Selected = true;
            rdoMca73b.Items[1].Selected = false;
        }
        else
        {
            rdoMca73b.Items[0].Selected = false;
            rdoMca73b.Items[1].Selected = true;
        }

        if (taskControl.Mca73c)
        {
            rdoMca73c.Items[0].Selected = true;
            rdoMca73c.Items[1].Selected = false;
        }
        else
        {
            rdoMca73c.Items[0].Selected = false;
            rdoMca73c.Items[1].Selected = true;
        }

        if (taskControl.Mca73d)
        {
            rdoMca73d.Items[0].Selected = true;
            rdoMca73d.Items[1].Selected = false;
        }
        else
        {
            rdoMca73d.Items[0].Selected = false;
            rdoMca73d.Items[1].Selected = true;
        }

        if (taskControl.Mca73e)
        {
            rdoMca73e.Items[0].Selected = true;
            rdoMca73e.Items[1].Selected = false;
        }
        else
        {
            rdoMca73e.Items[0].Selected = false;
            rdoMca73e.Items[1].Selected = true;
        }

        if (taskControl.Mca73f)
        {
            rdoMca73f.Items[0].Selected = true;
            rdoMca73f.Items[1].Selected = false;
        }
        else
        {
            rdoMca73f.Items[0].Selected = false;
            rdoMca73f.Items[1].Selected = true;
        }
    }

    protected void btnPrevTop_Click(object sender, EventArgs e)
    {
        Response.Redirect("Application6.aspx", false);
    }
    protected void btnPrevBottom_Click(object sender, EventArgs e)
    {
        Response.Redirect("Application6.aspx", false);
    }
}
