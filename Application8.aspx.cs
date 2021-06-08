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

public partial class Application8 : System.Web.UI.Page
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

            taskControl.Save(userID, 8);  //(userID);
            FillTextControl();
            DisableControls();

            Session["TaskControl"] = taskControl;

            if (taskControl.ApplicationMode == "UPDATE" || taskControl.ApplicationMode == "ADD")
            {
                if (taskControl.ApplicationExist(taskControl.TaskControlID, 8))
                    taskControl.ApplicationMode = "UPDATE";
                else
                    taskControl.ApplicationMode = "ADD";
            }
            else
            {
                if (taskControl.ApplicationExist(taskControl.TaskControlID, 8))
                    taskControl.ApplicationMode = "";
                else
                    taskControl.ApplicationMode = "ADD";
            }

            Response.Redirect("Application1.aspx", false);
            //this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Information saved successfully.");
            //this.litPopUp.Visible = true;
        }
        catch (Exception exp)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Unable to save this Information. " + exp.Message);
            this.litPopUp.Visible = true;
        }
    }


    private void FillProperties()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        taskControl.PatientName = txtPatientName.Text.ToUpper().Trim();
        taskControl.DateOfIncident = txtDateOfIncident.Text.ToUpper().Trim();
        taskControl.DateReported = txtDateReported.Text.ToUpper().Trim();
        taskControl.InsuranceNameCarrier = txtInsuranceNameCarrier.Text.ToUpper().Trim();
        taskControl.Allegation = txtAllegation.Text.ToUpper().Trim();
        taskControl.ConditionPatient = txtConditionPatient.Text.ToUpper().Trim();
        taskControl.App88ePayment = Convert.ToDecimal(txtapp88ePayment.Text);
        taskControl.App88fDate = txtapp88fDate.Text.ToUpper().Trim();
        taskControl.App88fPaid = Convert.ToDecimal(txtapp88fPaid.Text);
        txtMPayment.Text = "";
        taskControl.App89Desc = txtapp89Desc.Text.ToUpper().Trim();

        taskControl.Mca8f = chkMca8f.Checked;
        taskControl.Mca8g = chkMca8g.Checked;
        taskControl.Mca8h = chkMca8h.Checked;
        taskControl.Mca8i = chkMca8i.Checked;
        taskControl.Mca8j = chkMca8j.Checked;
        taskControl.Mca8k = chkMca8k.Checked;
        taskControl.Mca8a = chkMca8a.Checked;
        taskControl.Mca8b = chkMca8b.Checked;
        taskControl.Mca8c = chkMca8c.Checked;
        taskControl.Mca8d = chkMca8d.Checked;
        taskControl.Mca8e = chkMca8e.Checked;

        if (rdoMca8fc.Items[0].Selected)
        {
            taskControl.Mca8fc = true;
        }
        else
        {
            taskControl.Mca8fc = false;
        }

        if (rdoMca8l.Items[0].Selected)
        {
            taskControl.Mca8l = true;
        }
        else
        {
            taskControl.Mca8l = false;
        }

        if (rdoMca8m.Items[0].Selected)
        {
            taskControl.Mca8m = true;
        }
        else
        {
            taskControl.Mca8m = false;
        }

        if (rdoMca7.Items[0].Selected)
        {
            taskControl.Mca7 = true;
        }
        else
        {
            taskControl.Mca7 = false;
        }
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

    private void DisableControls()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        //btnNextBottom.Visible = true;
        //btnPrevBottom.Visible = true;
        btnNextTop.Enabled = true;
        //btnNextBottom.Enabled = true;

        txtPatientName.Enabled = false;
        txtDateOfIncident.Enabled = false;
        txtDateReported.Enabled = false;
        txtInsuranceNameCarrier.Enabled = false;
        txtAllegation.Enabled = false;
        txtConditionPatient.Enabled = false;
        rdoMca7.Enabled = false;
        chkMca8a.Enabled = false;
        chkMca8b.Enabled = false;
        chkMca8c.Enabled = false;
        chkMca8d.Enabled = false;
        chkMca8e.Enabled = false;
        txtapp88ePayment.Enabled = false;
        chkMca8f.Enabled = false;
        txtapp88fDate.Enabled = false;
        txtapp88fPaid.Enabled = false;
        txtMPayment.Enabled = false;
        chkMca8g.Enabled = false;
        chkMca8h.Enabled = false;
        chkMca8i.Enabled = false;
        chkMca8j.Enabled = false;
        chkMca8k.Enabled = false;
        rdoMca8fc.Enabled = false;
        rdoMca8l.Enabled = false;
        rdoMca8m.Enabled = false;
        txtapp89Desc.Enabled = false;
    }

    private void EnableControls()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        //btnNextBottom.Visible = true;
        //btnPrevBottom.Visible = true;
        btnNextTop.Enabled = true;
        //btnNextBottom.Enabled = true;

        txtPatientName.Enabled = true;
        txtDateOfIncident.Enabled = true;
        txtDateReported.Enabled = true;
        txtInsuranceNameCarrier.Enabled = true;
        txtAllegation.Enabled = true;
        txtConditionPatient.Enabled = true;
        rdoMca7.Enabled = true;
        chkMca8a.Enabled = true;
        chkMca8b.Enabled = true;
        chkMca8c.Enabled = true;
        chkMca8d.Enabled = true;
        chkMca8e.Enabled = true;
        txtapp88ePayment.Enabled = true;
        chkMca8f.Enabled = true;
        txtapp88fDate.Enabled = true;
        txtapp88fPaid.Enabled = true;
        txtMPayment.Enabled = true;
        chkMca8g.Enabled = true;
        chkMca8h.Enabled = true;
        chkMca8i.Enabled = true;
        chkMca8j.Enabled = true;
        chkMca8k.Enabled = true;
        rdoMca8fc.Enabled = true;
        rdoMca8l.Enabled = true;
        rdoMca8m.Enabled = true;
        txtapp89Desc.Enabled = true;
    }

    private void FillTextControl()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        int userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

        lblTaskControlID.Text = taskControl.TaskControlID.ToString();
        txtPatientName.Text = taskControl.PatientName;
        txtDateOfIncident.Text = taskControl.DateOfIncident;
        txtDateReported.Text = taskControl.DateReported;
        txtInsuranceNameCarrier.Text = taskControl.InsuranceNameCarrier;
        txtAllegation.Text = taskControl.Allegation;
        txtConditionPatient.Text = taskControl.ConditionPatient;
        txtapp88ePayment.Text = taskControl.App88ePayment.ToString();        
        txtapp88fDate.Text = taskControl.App88fDate;
        txtapp88fPaid.Text = taskControl.App88fPaid.ToString();
        txtMPayment.Text = "";
        txtapp89Desc.Text = taskControl.App89Desc;

        chkMca8f.Checked = taskControl.Mca8f;
        chkMca8g.Checked = taskControl.Mca8g;
        chkMca8h.Checked = taskControl.Mca8g;
        chkMca8i.Checked = taskControl.Mca8i;
        chkMca8j.Checked = taskControl.Mca8j;
        chkMca8k.Checked = taskControl.Mca8k;
        chkMca8a.Checked = taskControl.Mca8a;
        chkMca8b.Checked = taskControl.Mca8b;
        chkMca8c.Checked = taskControl.Mca8c;
        chkMca8d.Checked = taskControl.Mca8d;
        chkMca8e.Checked = taskControl.Mca8e;

        if (taskControl.Mca8fc)
        {
            rdoMca8fc.Items[0].Selected = true;
            rdoMca8fc.Items[1].Selected = false;
        }
        else
        {
            rdoMca8fc.Items[0].Selected = false;
            rdoMca8fc.Items[1].Selected = true;
        }

        if (taskControl.Mca8l)
        {
            rdoMca8l.Items[0].Selected = true;
            rdoMca8l.Items[1].Selected = false;
        }
        else
        {
            rdoMca8l.Items[0].Selected = false;
            rdoMca8l.Items[1].Selected = true;
        }

        if (taskControl.Mca8m)
        {
            rdoMca8m.Items[0].Selected = true;
            rdoMca8m.Items[1].Selected = false;
        }
        else
        {
            rdoMca8m.Items[0].Selected = false;
            rdoMca8m.Items[1].Selected = true;
        }

        if (taskControl.Mca7)
        {
            rdoMca7.Items[0].Selected = true;
            rdoMca7.Items[1].Selected = false;
        }
        else
        {
            rdoMca7.Items[0].Selected = false;
            rdoMca7.Items[1].Selected = true;
        }

    }
    protected void btnNextTop_Click(object sender, EventArgs e)
    {
        Save();
    }
    protected void btnPrevTop_Click(object sender, EventArgs e)
    {
        Response.Redirect("Application7.aspx", false);
    }
}
