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
using EPolicy.TaskControl;
using EPolicy2.Reports;

public partial class Application2 : System.Web.UI.Page
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

                            rdoMcaBoardCertified.Items[0].Selected = false;
                            rdoMcaBoardExam.Items[0].Selected = false;
                            rdoMcaFailedBoardExam.Items[0].Selected = false;
                            rdoMcaLocalMedSocieties.Items[0].Selected = false;
                            rdoMcaMedSocieties.Items[0].Selected = false;
                            rdoMcaMilitary.Items[0].Selected = false;
                            rdoMcaMilitaryReserve.Items[0].Selected = false;
                            rdoMcaNationalSocieties.Items[0].Selected = false;
                            rdoMcaOralExam.Items[0].Selected = false;
                            rdoMcaPracticeLimit.Items[0].Selected = false;
                            rdoMcaStateMedSocieties.Items[0].Selected = false;
                            rdoMcaWrittenExam.Items[0].Selected = false;
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

    private void FillTextControl()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        int userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

        lblTaskControlID.Text = taskControl.TaskControlID.ToString();
        txtPriSpecialty.Text = taskControl.PriSpecialty;
        txtSecSpecialty.Text = taskControl.SecSpecialty;
        txtPriPractice.Text = taskControl.PriPractice;
        txtSecPractice.Text = taskControl.SecPractice;

        if (taskControl.McaPracticeLimit)
        {
            rdoMcaPracticeLimit.Items[0].Selected = true;
            rdoMcaPracticeLimit.Items[1].Selected = false;
        }
        else
        {
            rdoMcaPracticeLimit.Items[0].Selected = false;
            rdoMcaPracticeLimit.Items[1].Selected = true;
        }

        txtPracticeLimitDesc.Text = taskControl.PracticeLimitDesc;

        if (taskControl.McaBoardCertified)
        {
            rdoMcaBoardCertified.Items[0].Selected = true;
            rdoMcaBoardCertified.Items[1].Selected = false;
        }
        else
        {
            rdoMcaBoardCertified.Items[0].Selected = false;
            rdoMcaBoardCertified.Items[1].Selected = true;
        }

        txtBoardCertifiedDesc1.Text = taskControl.BoardCertifiedDesc1;
        txtBoardCertifiedDesc2.Text = taskControl.BoardCertifiedDesc2;
        txtBoardCertifiedDesc3.Text = taskControl.BoardCertifiedDesc3;
        txtBoardCertifiedDesc4.Text = taskControl.BoardCertifiedDesc4;
        txtBoardCertifiedDesc5.Text = taskControl.BoardCertifiedDesc5;
        txtBoardCertifiedDesc6.Text = taskControl.BoardCertifiedDesc6;
        txtBoardCertifiedDesc7.Text = taskControl.BoardCertifiedDesc7;
        txtBoardCertifiedDesc8.Text = taskControl.BoardCertifiedDesc8;
        txtBoardCertifiedDesc9.Text = taskControl.BoardCertifiedDesc9;
        txtBoardCertifiedDesc10.Text = taskControl.BoardCertifiedDesc10;
        txtBoardCertifiedDesc11.Text = taskControl.BoardCertifiedDesc11;
        txtBoardCertifiedDesc12.Text = taskControl.BoardCertifiedDesc12;
        txtEleExpDate.Text = taskControl.EleExpDate;
        txtExpiredWhy.Text = taskControl.ExpiredWhy;

        if (taskControl.McaBoardExam)
        {
            rdoMcaBoardExam.Items[0].Selected = true;
            rdoMcaBoardExam.Items[1].Selected = false;
        }
        else
        {
            rdoMcaBoardExam.Items[0].Selected = false;
            rdoMcaBoardExam.Items[1].Selected = true;
        }

        txtBoardExamDesc.Text = taskControl.BoardExamDesc;

        if (taskControl.McaWrittenExam)
        {
            rdoMcaWrittenExam.Items[0].Selected = true;
            rdoMcaWrittenExam.Items[1].Selected = false;
        }
        else
        {
            rdoMcaWrittenExam.Items[0].Selected = false;
            rdoMcaWrittenExam.Items[1].Selected = true;
        }

        txtWrittenWhen.Text = taskControl.WrittenWhen;
        txtWrittenResult.Text = taskControl.WrittenResult;

        if (taskControl.McaOralExam)
        {
            rdoMcaOralExam.Items[0].Selected = true;
            rdoMcaOralExam.Items[1].Selected = false;
        }
        else
        {
            rdoMcaOralExam.Items[0].Selected = false;
            rdoMcaOralExam.Items[1].Selected = true;
        }

        txtOralWhen.Text = taskControl.OralWhen;
        txtOralResult.Text = taskControl.OralResult;

        if (taskControl.McaFailedBoardExam)
        {
            rdoMcaFailedBoardExam.Items[0].Selected = true;
            rdoMcaFailedBoardExam.Items[1].Selected = false;
        }
        else
        {
            rdoMcaFailedBoardExam.Items[0].Selected = false;
            rdoMcaFailedBoardExam.Items[1].Selected = true;
        }

        txtBoardFailedSpecialty.Text = taskControl.BoardFailedSpecialty;
        txtBoardDate.Text = taskControl.BoardDate;

        if (taskControl.McaMilitary)
        {
            rdoMcaMilitary.Items[0].Selected = true;
            rdoMcaMilitary.Items[1].Selected = false;
        }
        else
        {
            rdoMcaMilitary.Items[0].Selected = false;
            rdoMcaMilitary.Items[1].Selected = true;
        }

        txtMilitaryDesc.Text = taskControl.MilitaryDesc;

        if (taskControl.McaMilitaryReserve)
        {
            rdoMcaMilitaryReserve.Items[0].Selected = true;
            rdoMcaMilitaryReserve.Items[1].Selected = false;
        }
        else
        {
            rdoMcaMilitaryReserve.Items[0].Selected = false;
            rdoMcaMilitaryReserve.Items[1].Selected = true;
        }

        txtLicState1.Text = taskControl.LicState1;
        txtLicState2.Text = taskControl.LicState2;
        txtLicState3.Text = taskControl.LicState3;
        txtLicYear1.Text = taskControl.LicYear1;
        txtLicYear2.Text = taskControl.LicYear2;
        txtLicYear3.Text = taskControl.LicYear3;
        txtLicNumber1.Text = taskControl.LicNumber1;
        txtLicNumber2.Text = taskControl.LicNumber2;
        txtLicNumber3.Text = taskControl.LicNumber3;
        txtLicStatus1.Text = taskControl.LicStatus1;
        txtLicStatus2.Text = taskControl.LicStatus2;
        txtLicStatus3.Text = taskControl.LicStatus3;
        txtLicInactive.Text = taskControl.LicInactive;

        if (taskControl.McaMedSocieties)
        {
            rdoMcaMedSocieties.Items[0].Selected = true;
            rdoMcaMedSocieties.Items[1].Selected = false;
        }
        else
        {
            rdoMcaMedSocieties.Items[0].Selected = false;
            rdoMcaMedSocieties.Items[1].Selected = true;
        }

        txtMedSocietiesDesc.Text = taskControl.MedSocietiesDesc;

        if (taskControl.McaNationalSocieties)
        {
            rdoMcaNationalSocieties.Items[0].Selected = true;
            rdoMcaNationalSocieties.Items[1].Selected = false;
        }
        else
        {
            rdoMcaNationalSocieties.Items[0].Selected = false;
            rdoMcaNationalSocieties.Items[1].Selected = true;
        }

        txtNationalSocietiesDesc.Text = taskControl.NationalSocietiesDesc;

        if (taskControl.McaStateMedSocieties)
        {
            rdoMcaStateMedSocieties.Items[0].Selected = true;
            rdoMcaStateMedSocieties.Items[1].Selected = false;
        }
        else
        {
            rdoMcaStateMedSocieties.Items[0].Selected = false;
            rdoMcaStateMedSocieties.Items[1].Selected = true;
        }

        if (taskControl.McaLocalMedSocieties)
        {
            rdoMcaLocalMedSocieties.Items[0].Selected = true;
            rdoMcaLocalMedSocieties.Items[1].Selected = false;
        }
        else
        {
            rdoMcaLocalMedSocieties.Items[0].Selected = false;
            rdoMcaLocalMedSocieties.Items[1].Selected = true;
        }
    }

    private void EnableControls()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        btnNextBottom.Visible = true;
        btnPrevBottom.Visible = true;
        btnNextTop.Enabled = true;
        btnNextBottom.Enabled = true;

        txtPriSpecialty.Enabled = true;
        txtSecSpecialty.Enabled = true;
        txtPriPractice.Enabled = true;
        txtSecPractice.Enabled = true;
        rdoMcaPracticeLimit.Enabled = true;
        txtPracticeLimitDesc.Enabled = true;
        rdoMcaBoardCertified.Enabled = true;

        txtBoardCertifiedDesc1.Enabled = true;
        txtBoardCertifiedDesc2.Enabled = true;
        txtBoardCertifiedDesc3.Enabled = true;
        txtBoardCertifiedDesc4.Enabled = true;
        txtBoardCertifiedDesc5.Enabled = true;
        txtBoardCertifiedDesc6.Enabled = true;
        txtBoardCertifiedDesc7.Enabled = true;
        txtBoardCertifiedDesc8.Enabled = true;
        txtBoardCertifiedDesc9.Enabled = true;
        txtBoardCertifiedDesc10.Enabled = true;
        txtBoardCertifiedDesc11.Enabled = true;
        txtBoardCertifiedDesc12.Enabled = true;
        txtEleExpDate.Enabled = true;
        txtExpiredWhy.Enabled = true;
        rdoMcaBoardExam.Enabled = true;
        txtBoardExamDesc.Enabled = true;      
        rdoMcaWrittenExam.Enabled = true;
        txtWrittenWhen.Enabled = true;
        txtWrittenResult.Enabled = true;            
        rdoMcaOralExam.Enabled = true;
        txtOralWhen.Enabled = true;
        txtOralResult.Enabled = true;
        rdoMcaFailedBoardExam.Enabled = true;
        txtBoardFailedSpecialty.Enabled = true;
        txtBoardDate.Enabled = true;
        rdoMcaMilitary.Enabled = true;
        txtMilitaryDesc.Enabled = true;
        rdoMcaMilitaryReserve.Enabled = true;
        txtLicState1.Enabled = true;
        txtLicState2.Enabled = true;
        txtLicState3.Enabled = true;
        txtLicYear1.Enabled = true;
        txtLicYear2.Enabled = true;
        txtLicYear3.Enabled = true;
        txtLicNumber1.Enabled = true;
        txtLicNumber2.Enabled = true;
        txtLicNumber3.Enabled = true;
        txtLicStatus1.Enabled = true;
        txtLicStatus2.Enabled = true;
        txtLicStatus3.Enabled = true;
        txtLicInactive.Enabled = true;
        rdoMcaMedSocieties.Enabled = true;
        txtMedSocietiesDesc.Enabled = true;
        rdoMcaNationalSocieties.Enabled = true;
        txtNationalSocietiesDesc.Enabled = true;
        rdoMcaStateMedSocieties.Enabled = true;
        rdoMcaLocalMedSocieties.Enabled = true;        
    }

    private void DisableControls()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        btnNextBottom.Visible = true;
        btnPrevBottom.Visible = true;
        btnNextTop.Enabled = true;
        btnNextBottom.Enabled = true;

        txtPriSpecialty.Enabled = false;
        txtSecSpecialty.Enabled = false;
        txtPriPractice.Enabled = false;
        txtSecPractice.Enabled = false;
        rdoMcaPracticeLimit.Enabled = false;
        txtPracticeLimitDesc.Enabled = false;
        rdoMcaBoardCertified.Enabled = false;

        txtBoardCertifiedDesc1.Enabled = false;
        txtBoardCertifiedDesc2.Enabled = false;
        txtBoardCertifiedDesc3.Enabled = false;
        txtBoardCertifiedDesc4.Enabled = false;
        txtBoardCertifiedDesc5.Enabled = false;
        txtBoardCertifiedDesc6.Enabled = false;
        txtBoardCertifiedDesc7.Enabled = false;
        txtBoardCertifiedDesc8.Enabled = false;
        txtBoardCertifiedDesc9.Enabled = false;
        txtBoardCertifiedDesc10.Enabled = false;
        txtBoardCertifiedDesc11.Enabled = false;
        txtBoardCertifiedDesc12.Enabled = false;
        txtEleExpDate.Enabled = false;
        txtExpiredWhy.Enabled = false;
        rdoMcaBoardExam.Enabled = false;
        txtBoardExamDesc.Enabled = false;
        rdoMcaWrittenExam.Enabled = false;
        txtWrittenWhen.Enabled = false;
        txtWrittenResult.Enabled = false;
        rdoMcaOralExam.Enabled = false;
        txtOralWhen.Enabled = false;
        txtOralResult.Enabled = false;
        rdoMcaFailedBoardExam.Enabled = false;
        txtBoardFailedSpecialty.Enabled = false;
        txtBoardDate.Enabled = false;
        rdoMcaMilitary.Enabled = false;
        txtMilitaryDesc.Enabled = false;
        rdoMcaMilitaryReserve.Enabled = false;
        txtLicState1.Enabled = false;
        txtLicState2.Enabled = false;
        txtLicState3.Enabled = false;
        txtLicYear1.Enabled = false;
        txtLicYear2.Enabled = false;
        txtLicYear3.Enabled = false;
        txtLicNumber1.Enabled = false;
        txtLicNumber2.Enabled = false;
        txtLicNumber3.Enabled = false;
        txtLicStatus1.Enabled = false;
        txtLicStatus2.Enabled = false;
        txtLicStatus3.Enabled = false;
        txtLicInactive.Enabled = false;
        rdoMcaMedSocieties.Enabled = false;
        txtMedSocietiesDesc.Enabled = false;
        rdoMcaNationalSocieties.Enabled = false;
        txtNationalSocietiesDesc.Enabled = false;
        rdoMcaStateMedSocieties.Enabled = false;
        rdoMcaLocalMedSocieties.Enabled = false;            
        
        VerifyAccess();
    }

    private void RemoveSessionLookUp()
    {
        Session.Remove("LookUpTables");
    }

    protected void btnPrevTop_Click(object sender, EventArgs e)
    {
        Response.Redirect("Application1.aspx", false);
    }

    protected void btnPrevBottom_Click(object sender, EventArgs e)
    {
        Response.Redirect("Application1.aspx", false);
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

            taskControl.Save(userID, 2);  //(userID);
            FillTextControl();
            DisableControls();

            Session["TaskControl"] = taskControl;

            if (taskControl.ApplicationMode == "UPDATE" || taskControl.ApplicationMode == "ADD")
            {
                if (taskControl.ApplicationExist(taskControl.TaskControlID, 2))
                    taskControl.ApplicationMode = "UPDATE";
                else
                    taskControl.ApplicationMode = "ADD";
            }
            else
            {
                if (taskControl.ApplicationExist(taskControl.TaskControlID, 2))
                    taskControl.ApplicationMode = "";
                else
                    taskControl.ApplicationMode = "ADD";
            }

            Response.Redirect("Application3.aspx", false);
            //this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Information saved successfully.");
            //this.litPopUp.Visible = true;
        }
        catch (Exception exp)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Unable to save this Information. " + exp.Message);
            this.litPopUp.Visible = true;
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

    private void FillProperties()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        taskControl.PriSpecialty = txtPriSpecialty.Text.Trim().ToUpper();
        taskControl.SecSpecialty = txtSecSpecialty.Text.Trim().ToUpper();
        taskControl.PriPractice = txtPriPractice.Text.Trim().ToUpper();
        taskControl.SecPractice = txtSecPractice.Text.Trim().ToUpper();

        if (rdoMcaPracticeLimit.Items[0].Selected)
        {
            taskControl.McaPracticeLimit = true;
        }
        else
        {
            taskControl.McaPracticeLimit = false;
        }

        taskControl.PracticeLimitDesc = txtPracticeLimitDesc.Text.Trim().ToUpper();

        if (rdoMcaBoardCertified.Items[0].Selected)
        {
            taskControl.McaBoardCertified = true;
        }
        else
        {
            taskControl.McaBoardCertified = false;
        }

        taskControl.BoardCertifiedDesc1 = txtBoardCertifiedDesc1.Text.Trim().ToUpper();
        taskControl.BoardCertifiedDesc2 = txtBoardCertifiedDesc2.Text.Trim().ToUpper();
        taskControl.BoardCertifiedDesc3 = txtBoardCertifiedDesc3.Text.Trim().ToUpper();
        taskControl.BoardCertifiedDesc4 = txtBoardCertifiedDesc4.Text.Trim().ToUpper();
        taskControl.BoardCertifiedDesc5 = txtBoardCertifiedDesc5.Text.Trim().ToUpper();
        taskControl.BoardCertifiedDesc6 = txtBoardCertifiedDesc6.Text.Trim().ToUpper();
        taskControl.BoardCertifiedDesc7 = txtBoardCertifiedDesc7.Text.Trim().ToUpper();
        taskControl.BoardCertifiedDesc8 = txtBoardCertifiedDesc8.Text.Trim().ToUpper();
        taskControl.BoardCertifiedDesc9 = txtBoardCertifiedDesc9.Text.Trim().ToUpper();
        taskControl.BoardCertifiedDesc10 = txtBoardCertifiedDesc10.Text.Trim().ToUpper();
        taskControl.BoardCertifiedDesc11 = txtBoardCertifiedDesc11.Text.Trim().ToUpper();
        taskControl.BoardCertifiedDesc12 = txtBoardCertifiedDesc12.Text.Trim().ToUpper();
        taskControl.EleExpDate = txtEleExpDate.Text.Trim().ToUpper();
        taskControl.ExpiredWhy = txtExpiredWhy.Text.Trim().ToUpper();

        if (rdoMcaBoardExam.Items[0].Selected)
        {
            taskControl.McaBoardExam = true;
        }
        else
        {
            taskControl.McaBoardExam = false;
        }

        taskControl.BoardExamDesc = txtBoardExamDesc.Text.Trim().ToUpper();

        if (rdoMcaWrittenExam.Items[0].Selected)
        {
            taskControl.McaWrittenExam = true;
        }
        else
        {
            taskControl.McaWrittenExam = false;
        }

        taskControl.WrittenWhen = txtWrittenWhen.Text.Trim().ToUpper();
        taskControl.WrittenResult = txtWrittenResult.Text.Trim().ToUpper();

        if (rdoMcaOralExam.Items[0].Selected)
        {
            taskControl.McaOralExam = true;
        }
        else
        {
            taskControl.McaOralExam = false;
        }

        taskControl.OralWhen = txtOralWhen.Text.Trim().ToUpper();
        taskControl.OralResult = txtOralResult.Text.Trim().ToUpper();

        if (rdoMcaFailedBoardExam.Items[0].Selected)
        {
            taskControl.McaFailedBoardExam = true;
        }
        else
        {
            taskControl.McaFailedBoardExam = false;
        }

        taskControl.BoardFailedSpecialty = txtBoardFailedSpecialty.Text.Trim().ToUpper();
        taskControl.BoardDate = txtBoardDate.Text.Trim().ToUpper();

        if (rdoMcaMilitary.Items[0].Selected)
        {
            taskControl.McaMilitary = true;
        }
        else
        {
            taskControl.McaMilitary = false;
        }

        taskControl.MilitaryDesc = txtMilitaryDesc.Text.Trim().ToUpper();

        if (rdoMcaMilitaryReserve.Items[0].Selected)
        {
            taskControl.McaMilitaryReserve = true;
        }
        else
        {
            taskControl.McaMilitaryReserve = false;
        }

        taskControl.LicState1 = txtLicState1.Text.Trim().ToUpper();
        taskControl.LicState2 = txtLicState2.Text.Trim().ToUpper();
        taskControl.LicState3 = txtLicState3.Text.Trim().ToUpper();
        taskControl.LicYear1 = txtLicYear1.Text.Trim().ToUpper();
        taskControl.LicYear2 = txtLicYear2.Text.Trim().ToUpper();
        taskControl.LicYear3 = txtLicYear3.Text.Trim().ToUpper();
        taskControl.LicNumber1 = txtLicNumber1.Text.Trim().ToUpper();
        taskControl.LicNumber2 = txtLicNumber2.Text.Trim().ToUpper();
        taskControl.LicNumber3 = txtLicNumber3.Text.Trim().ToUpper();
        taskControl.LicStatus1 = txtLicStatus1.Text.Trim().ToUpper();
        taskControl.LicStatus2 = txtLicStatus2.Text.Trim().ToUpper();
        taskControl.LicStatus3 = txtLicStatus3.Text.Trim().ToUpper();
        taskControl.LicInactive = txtLicInactive.Text.Trim().ToUpper();

        if (rdoMcaMedSocieties.Items[0].Selected)
        {
            taskControl.McaMedSocieties = true;
        }
        else
        {
            taskControl.McaMedSocieties = false;
        }

        taskControl.MedSocietiesDesc = txtMedSocietiesDesc.Text.Trim().ToUpper();

        if (rdoMcaNationalSocieties.Items[0].Selected)
        {
            taskControl.McaNationalSocieties = true;
        }
        else
        {
            taskControl.McaNationalSocieties = false;
        }

        taskControl.NationalSocietiesDesc = txtNationalSocietiesDesc.Text.Trim().ToUpper();

        if (rdoMcaStateMedSocieties.Items[0].Selected)
        {
            taskControl.McaStateMedSocieties = true;
        }
        else
        {
            taskControl.McaStateMedSocieties = false;
        }

        if (rdoMcaLocalMedSocieties.Items[0].Selected)
        {
            taskControl.McaLocalMedSocieties = true;
        }
        else
        {
            taskControl.McaLocalMedSocieties = false;
        }

        Session["TaskControl"] = taskControl;
    }
}
