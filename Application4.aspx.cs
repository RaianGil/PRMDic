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

public partial class Application4 : System.Web.UI.Page
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

                            rdoMcaExtendedCov1.Items[0].Selected = false;
                            rdoMcaExtendedCov.Items[0].Selected = false;
                            rdoMcaFullTimeCov.Items[0].Selected = false;
                            rdoMcaProfLiab1.Items[0].Selected = false;
                            rdoMcaPartTimeCov.Items[0].Selected = false;
                            rdoMcaProfLiab.Items[0].Selected = false;
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

        chkMcaLab.Checked= taskControl.McaLab;
        txtLabHours.Text = taskControl.LabHours;
        txtLabEmp.Text = taskControl.LabEmp;
        chkMcaPhy.Checked = taskControl.McaPhy;
        txtPhyHours.Text = taskControl.PhyHours;
        txtPhyEmp.Text = taskControl.PhyEmp;
        chkMcaXray.Checked = taskControl.McaXray;
        txtXrayHours.Text = taskControl.XrayHours;
        txtXrayEmp.Text = taskControl.XrayEmp;
        chkMcaOther.Checked = taskControl.McaOther;
        txtOtherHours.Text = taskControl.OtherHours;
        txtOtherEmp.Text = taskControl.OtherEmp;
        chkMcaNurseAnes.Checked = taskControl.McaNurseAnes;
        txtNurseAnesHours.Text = taskControl.NurseAnesHours;
        txtNurseAnesEmp.Text = taskControl.NurseAnesEmp;
        chkMcaNurseMid.Checked = taskControl.McaNurseMid;
        txtNurseMidHours.Text = taskControl.NurseMidHours;
        txtNurseMidEmp.Text = taskControl.NurseMidEmp;
        chkMcaNursePerf.Checked = taskControl.McaNursePerf;
        txtNursePerfHours.Text = taskControl.NursePerfHours;
        txtNursePerfEmp.Text = taskControl.NursePerfEmp;
        chkMcaNursePrac.Checked = taskControl.McaNursePrac;
        txtNursePracHours.Text = taskControl.NursePracHours;
        txtNursePracEmp.Text = taskControl.NursePracEmp;
        chkMcaOpto.Checked = taskControl.McaOpto;
        txtOptoHours.Text = taskControl.OptoHours;
        txtOptoEmp.Text = taskControl.OptoEmp;
        chkMcaPhyAss.Checked = taskControl.McaPhyAss;
        txtPhyAssHours.Text = taskControl.PhyAssHours;
        txtPhyAssEmp.Text = taskControl.PhyAssEmp;
        chkMcaPsych.Checked = taskControl.McaPsych;
        txtPsychHours.Text = taskControl.PsychHours;
        txtPsychEmp.Text = taskControl.PsychEmp;
        chkMcaScrub.Checked = taskControl.McaScrub;
        txtScrubHours.Text = taskControl.ScrubHours;
        txtScrubEmp.Text = taskControl.ScrubEmp;
        chkMcaSurgical.Checked = taskControl.McaSurgical;
        txtSurgicalHours.Text = taskControl.SurgicalHours;
        txtSurgicalEmp.Text = taskControl.SurgicalEmp;
        chkOtherDesc.Checked = taskControl.McaOtherDesc;
        txtOtherDescHours.Text = taskControl.OtherDescHours;
        txtOtherDescEmp.Text = taskControl.OtherDescEmp;
        txtHCName1.Text = taskControl.HCName1;
        txtHCSpeciality1.Text = taskControl.HCSpeciality1;
        txtHCInsured1.Text = taskControl.HCInsured1;
        txtHCLimits1.Text = taskControl.HCLimits1;
        txtHCName2.Text = taskControl.HCName2;
        txtHCSpecialty2.Text = taskControl.HCSpecialty2;
        txtHCInsured2.Text = taskControl.HCInsured2;
        txtHCLimits2.Text = taskControl.HCLimits2;
        txtHCName3.Text = taskControl.HCName3;
        txtHCSpecialty3.Text = taskControl.HCSpecialty3;
        txtHCInsured3.Text = taskControl.HCInsured3;
        txtHCLimits3.Text = taskControl.HCLimits3;
        chkMcaNone.Checked = taskControl.McaNone;
        chkMcaBlood.Checked = taskControl.McaBlood;
        chkMcaBirthing.Checked = taskControl.McaBirthing;
        chkMcaCity.Checked = taskControl.McaCity;
        chkMcaClinic.Checked = taskControl.McaClinic;
        chkMcaEmergency.Checked = taskControl.McaEmergency;
        chkMcaEmerHospital.Checked = taskControl.McaEmerHospital;
        chkMcaFreeStanding.Checked = taskControl.McaFreeStanding;
        chkMcaHospital.Checked = taskControl.McaHospital;
        chkMcaConva.Checked = taskControl.McaConva;
        chkMcaPsy.Checked = taskControl.McaPsy;
        chkMcaInd.Checked = taskControl.McaInd;
        chkMcaLaboratory.Checked = taskControl.McaLaboratory;
        chkMcaNursing.Checked = taskControl.McaNursing;
        chkMcaSanitarium.Checked = taskControl.McaSanitarium;
        chkMcaUrgent.Checked = taskControl.McaUrgent;
        chkMcaXrayFacility.Checked = taskControl.McaXrayFacility;
        chkMcaOtherHC.Checked = taskControl.McaOtherHC;
        txtFacilityName1.Text = taskControl.FacilityName1;
        txtFacilityAddr1.Text = taskControl.FacilityAddr1;
        txtFacilityType1.Text = taskControl.FacilityType1;
        txtFacilityDuties1.Text = taskControl.FacilityDuties1;
        txtFacilityNumbers1.Text = taskControl.FacilityNumbers1;

        if (taskControl.McaProfLiab1)
        {
            rdoMcaProfLiab1.Items[0].Selected = true;
            rdoMcaProfLiab1.Items[1].Selected = false;
        }
        else
        {
            rdoMcaProfLiab1.Items[0].Selected = false;
            rdoMcaProfLiab1.Items[1].Selected = true;
        }

        if (taskControl.McaExtendedCov1)
        {
            rdoMcaExtendedCov1.Items[0].Selected = true;
            rdoMcaExtendedCov1.Items[1].Selected = false;
        }
        else
        {
            rdoMcaExtendedCov1.Items[0].Selected = false;
            rdoMcaExtendedCov1.Items[1].Selected = true;
        }

        txtFacilityName2.Text = taskControl.FacilityName2;
        txtFacilityAddr2.Text = taskControl.FacilityAddr2;
        txtFacilityType2.Text = taskControl.FacilityType2;
        txtFacilityDuties2.Text = taskControl.FacilityDuties2;
        txtFacilityNumbers2.Text = taskControl.FacilityNumbers2;

        if (taskControl.McaProfLiab)
        {
            rdoMcaProfLiab.Items[0].Selected = true;
            rdoMcaProfLiab.Items[1].Selected = false;
        }
        else
        {
            rdoMcaProfLiab.Items[0].Selected = false;
            rdoMcaProfLiab.Items[1].Selected = true;
        }

        if (taskControl.McaExtendedCov)
        {
            rdoMcaExtendedCov.Items[0].Selected = true;
            rdoMcaExtendedCov.Items[1].Selected = false;
        }
        else
        {
            rdoMcaExtendedCov.Items[0].Selected = false;
            rdoMcaExtendedCov.Items[1].Selected = true;
        }
        
        if (taskControl.McaFullTimeCov)
        {
            rdoMcaFullTimeCov.Items[0].Selected = true;
            rdoMcaFullTimeCov.Items[1].Selected = false;
        }
        else
        {
            rdoMcaFullTimeCov.Items[0].Selected = false;
            rdoMcaFullTimeCov.Items[1].Selected = true;
        }
                
        if (taskControl.McaPartTimeCov)
        {
            rdoMcaPartTimeCov.Items[0].Selected = true;
            rdoMcaPartTimeCov.Items[1].Selected = false;
        }
        else
        {
            rdoMcaPartTimeCov.Items[0].Selected = false;
            rdoMcaPartTimeCov.Items[1].Selected = true;
        }

        txtDaysPWeek.Text = taskControl.DaysPWeek;
        txtHoursPDayOffice.Text = taskControl.HoursPDayOffice;
        txtPatienPWeek.Text = taskControl.PatienPWeek;
        txtHoursPDayHosp.Text = taskControl.HoursPDayHosp;
        txtActDesc.Text = taskControl.ActDesc;
        txtapp339Number1.Text = taskControl.App339Number1;
        txtapp339Hours1.Text = taskControl.App339Hours1;
        txtapp339Number2.Text = taskControl.App339Number2;
        txtapp339Hours2.Text = taskControl.App339Hours2;
        txtapp339Number3.Text = taskControl.App339Number3;
        txtapp339Hours3.Text = taskControl.App339Hours3;
        txtapp339Number4.Text = taskControl.App339Number4;
        txtapp339Hours4.Text = taskControl.App339Hours4;
        txtapp339Number5.Text = taskControl.App339Number5;
        txtapp339Hours5.Text = taskControl.App339Hours5;
        txtapp339Number6.Text = taskControl.App339Number6;
        txtapp339Hours6.Text = taskControl.App339Hours6;
    }

    private void EnableControls()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        btnNextBottom.Visible = true;
        btnPrevBottom.Visible = true;
        btnNextTop.Enabled = true;
        btnNextBottom.Enabled = true;

        chkMcaLab.Enabled = true;
        txtLabHours.Enabled = true;
        txtLabEmp.Enabled = true;
        chkMcaPhy.Enabled = true;
        txtPhyHours.Enabled = true;
        txtPhyEmp.Enabled = true;
        chkMcaXray.Enabled = true;
        txtXrayHours.Enabled = true;
        txtXrayEmp.Enabled = true;
        chkMcaOther.Enabled = true;
        txtOtherHours.Enabled = true;
        txtOtherEmp.Enabled = true;
        chkMcaNurseAnes.Enabled = true;
        txtNurseAnesHours.Enabled = true;
        txtNurseAnesEmp.Enabled = true;
        chkMcaNurseMid.Enabled = true;
        txtNurseMidHours.Enabled = true;
        txtNurseMidEmp.Enabled = true;
        chkMcaNursePerf.Enabled = true;
        txtNursePerfHours.Enabled = true;
        txtNursePerfEmp.Enabled = true;
        chkMcaNursePrac.Enabled = true;
        txtNursePracHours.Enabled = true;
        txtNursePracEmp.Enabled = true;
        chkMcaOpto.Enabled = true;
        txtOptoHours.Enabled = true;
        txtOptoEmp.Enabled = true;
        chkMcaPhyAss.Enabled = true;
        txtPhyAssHours.Enabled = true;
        txtPhyAssEmp.Enabled = true;
        chkMcaPsych.Enabled = true;
        txtPsychHours.Enabled = true;
        txtPsychEmp.Enabled = true;
        chkMcaScrub.Enabled = true;
        txtScrubHours.Enabled = true;
        txtScrubEmp.Enabled = true;
        chkMcaSurgical.Enabled = true;
        txtSurgicalHours.Enabled = true;
        txtSurgicalEmp.Enabled = true;
        chkOtherDesc.Enabled = true;
        txtOtherDescHours.Enabled = true;
        txtOtherDescEmp.Enabled = true;
        txtHCName1.Enabled = true;
        txtHCSpeciality1.Enabled = true;
        txtLabHours.Enabled = true;
        txtHCLimits1.Enabled = true;
        txtHCName2.Enabled = true;
        txtHCSpecialty2.Enabled = true;
        txtHCInsured2.Enabled = true;
        txtHCLimits2.Enabled = true;
        txtHCName3.Enabled = true;
        txtHCSpecialty3.Enabled = true;
        txtHCInsured3.Enabled = true;
        txtHCLimits3.Enabled = true;
        chkMcaNone.Enabled = true;
        chkMcaBlood.Enabled = true;
        chkMcaBirthing.Enabled = true;
        chkMcaCity.Enabled = true;
        chkMcaClinic.Enabled = true;
        chkMcaEmergency.Enabled = true;
        chkMcaEmerHospital.Enabled = true;
        chkMcaFreeStanding.Enabled = true;
        chkMcaHospital.Enabled = true;
        chkMcaConva.Enabled = true;
        chkMcaPsy.Enabled = true;
        chkMcaInd.Enabled = true;
        chkMcaLaboratory.Enabled = true;
        chkMcaNursing.Enabled = true;
        chkMcaSanitarium.Enabled = true;
        chkMcaUrgent.Enabled = true;
        chkMcaXrayFacility.Enabled = true;
        chkMcaOtherHC.Enabled = true;
        txtFacilityName1.Enabled = true;
        txtFacilityAddr1.Enabled = true;
        txtFacilityType1.Enabled = true;
        txtFacilityDuties1.Enabled = true;
        txtFacilityNumbers1.Enabled = true;     
        rdoMcaProfLiab1.Enabled = true;     
        rdoMcaExtendedCov1.Enabled = true;
        txtFacilityName2.Enabled = true;
        txtFacilityAddr2.Enabled = true;
        txtFacilityType2.Enabled = true;
        txtFacilityDuties2.Enabled = true;
        txtFacilityNumbers2.Enabled = true;
        rdoMcaProfLiab.Enabled = true;
        rdoMcaExtendedCov.Enabled = true;
        rdoMcaFullTimeCov.Enabled = true;  
        rdoMcaPartTimeCov.Enabled = true;
        txtDaysPWeek.Enabled = true;
        txtHoursPDayOffice.Enabled = true;
        txtPatienPWeek.Enabled = true;
        txtHoursPDayHosp.Enabled = true;
        txtActDesc.Enabled = true;
        txtapp339Number1.Enabled = true;
        txtapp339Hours1.Enabled = true;
        txtapp339Number2.Enabled = true;
        txtapp339Hours2.Enabled = true;
        txtapp339Number3.Enabled = true;
        txtapp339Hours3.Enabled = true;
        txtapp339Number4.Enabled = true;
        txtapp339Hours4.Enabled = true;
        txtapp339Number5.Enabled = true;
        txtapp339Hours5.Enabled = true;
        txtapp339Number6.Enabled = true;
        txtapp339Hours6.Enabled = true;
    }

    private void DisableControls()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        btnNextBottom.Visible = true;
        btnPrevBottom.Visible = true;
        btnNextTop.Enabled = true;
        btnNextBottom.Enabled = true;

        chkMcaLab.Enabled = false;
        txtLabHours.Enabled = false;
        txtLabEmp.Enabled = false;
        chkMcaPhy.Enabled = false;
        txtPhyHours.Enabled = false;
        txtPhyEmp.Enabled = false;
        chkMcaXray.Enabled = false;
        txtXrayHours.Enabled = false;
        txtXrayEmp.Enabled = false;
        chkMcaOther.Enabled = false;
        txtOtherHours.Enabled = false;
        txtOtherEmp.Enabled = false;
        chkMcaNurseAnes.Enabled = false;
        txtNurseAnesHours.Enabled = false;
        txtNurseAnesEmp.Enabled = false;
        chkMcaNurseMid.Enabled = false;
        txtNurseMidHours.Enabled = false;
        txtNurseMidEmp.Enabled = false;
        chkMcaNursePerf.Enabled = false;
        txtNursePerfHours.Enabled = false;
        txtNursePerfEmp.Enabled = false;
        chkMcaNursePrac.Enabled = false;
        txtNursePracHours.Enabled = false;
        txtNursePracEmp.Enabled = false;
        chkMcaOpto.Enabled = false;
        txtOptoHours.Enabled = false;
        txtOptoEmp.Enabled = false;
        chkMcaPhyAss.Enabled = false;
        txtPhyAssHours.Enabled = false;
        txtPhyAssEmp.Enabled = false;
        chkMcaPsych.Enabled = false;
        txtPsychHours.Enabled = false;
        txtPsychEmp.Enabled = false;
        chkMcaScrub.Enabled = false;
        txtScrubHours.Enabled = false;
        txtScrubEmp.Enabled = false;
        chkMcaSurgical.Enabled = false;
        txtSurgicalHours.Enabled = false;
        txtSurgicalEmp.Enabled = false;
        chkOtherDesc.Enabled = false;
        txtOtherDescHours.Enabled = false;
        txtOtherDescEmp.Enabled = false;
        txtHCName1.Enabled = false;
        txtHCSpeciality1.Enabled = false;
        txtLabHours.Enabled = false;
        txtHCLimits1.Enabled = false;
        txtHCName2.Enabled = false;
        txtHCSpecialty2.Enabled = false;
        txtHCInsured2.Enabled = false;
        txtHCLimits2.Enabled = false;
        txtHCName3.Enabled = false;
        txtHCSpecialty3.Enabled = false;
        txtHCInsured3.Enabled = false;
        txtHCLimits3.Enabled = false;
        chkMcaNone.Enabled = false;
        chkMcaBlood.Enabled = false;
        chkMcaBirthing.Enabled = false;
        chkMcaCity.Enabled = false;
        chkMcaClinic.Enabled = false;
        chkMcaEmergency.Enabled = false;
        chkMcaEmerHospital.Enabled = false;
        chkMcaFreeStanding.Enabled = false;
        chkMcaHospital.Enabled = false;
        chkMcaConva.Enabled = false;
        chkMcaPsy.Enabled = false;
        chkMcaInd.Enabled = false;
        chkMcaLaboratory.Enabled = false;
        chkMcaNursing.Enabled = false;
        chkMcaSanitarium.Enabled = false;
        chkMcaUrgent.Enabled = false;
        chkMcaXrayFacility.Enabled = false;
        chkMcaOtherHC.Enabled = false;
        txtFacilityName1.Enabled = false;
        txtFacilityAddr1.Enabled = false;
        txtFacilityType1.Enabled = false;
        txtFacilityDuties1.Enabled = false;
        txtFacilityNumbers1.Enabled = false;
        rdoMcaProfLiab1.Enabled = false;
        rdoMcaExtendedCov1.Enabled = false;
        txtFacilityName2.Enabled = false;
        txtFacilityAddr2.Enabled = false;
        txtFacilityType2.Enabled = false;
        txtFacilityDuties2.Enabled = false;
        txtFacilityNumbers2.Enabled = false;
        rdoMcaProfLiab.Enabled = false;
        rdoMcaExtendedCov.Enabled = false;
        rdoMcaFullTimeCov.Enabled = false;
        rdoMcaPartTimeCov.Enabled = false;
        txtDaysPWeek.Enabled = false;
        txtHoursPDayOffice.Enabled = false;
        txtPatienPWeek.Enabled = false;
        txtHoursPDayHosp.Enabled = false;
        txtActDesc.Enabled = false;
        txtapp339Number1.Enabled = false;
        txtapp339Hours1.Enabled = false;
        txtapp339Number2.Enabled = false;
        txtapp339Hours2.Enabled = false;
        txtapp339Number3.Enabled = false;
        txtapp339Hours3.Enabled = false;
        txtapp339Number4.Enabled = false;
        txtapp339Hours4.Enabled = false;
        txtapp339Number5.Enabled = false;
        txtapp339Hours5.Enabled = false;
        txtapp339Number6.Enabled = false;
        txtapp339Hours6.Enabled = false;

        VerifyAccess();
    }

    private void RemoveSessionLookUp()
    {
        Session.Remove("LookUpTables");
    }

    protected void btnPrevTop_Click(object sender, EventArgs e)
    {
        Response.Redirect("Application3.aspx", false);
    }

    protected void btnPrevBottom_Click(object sender, EventArgs e)
    {
        Response.Redirect("Application3.aspx", false);
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

            taskControl.Save(userID, 4);  //(userID);
            FillTextControl();
            DisableControls();

            Session["TaskControl"] = taskControl;

            if (taskControl.ApplicationMode == "UPDATE" || taskControl.ApplicationMode == "ADD")
            {
                if (taskControl.ApplicationExist(taskControl.TaskControlID, 4))
                    taskControl.ApplicationMode = "UPDATE";
                else
                    taskControl.ApplicationMode = "ADD";
            }
            else
            {
                if (taskControl.ApplicationExist(taskControl.TaskControlID, 4))
                    taskControl.ApplicationMode = "";
                else
                    taskControl.ApplicationMode = "ADD";
            }

            Response.Redirect("Application5.aspx", false);
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

        taskControl.McaLab = chkMcaLab.Checked;
        taskControl.LabHours = txtLabHours.Text.Trim().ToUpper();
        taskControl.LabEmp = txtLabEmp.Text.Trim().ToUpper();
        taskControl.McaPhy = chkMcaPhy.Checked;
        taskControl.PhyHours = txtPhyHours.Text.Trim().ToUpper();
        taskControl.PhyEmp = txtPhyEmp.Text.Trim().ToUpper();
        taskControl.McaXray = chkMcaXray.Checked;
        taskControl.XrayHours = txtXrayHours.Text.Trim().ToUpper();
        taskControl.XrayEmp = txtXrayEmp.Text.Trim().ToUpper();
        taskControl.McaOther = chkMcaOther.Checked;
        taskControl.OtherHours = txtOtherHours.Text.Trim().ToUpper();;
        taskControl.OtherEmp = txtOtherEmp.Text.Trim().ToUpper();
        taskControl.McaNurseAnes = chkMcaNurseAnes.Checked;
        taskControl.NurseAnesHours=txtNurseAnesHours.Text.Trim().ToUpper(); 
        taskControl.NurseAnesEmp=txtNurseAnesEmp.Text.Trim().ToUpper(); 
        taskControl.McaNurseMid=chkMcaNurseMid.Checked ;
        taskControl.NurseMidHours = txtNurseMidHours.Text.Trim().ToUpper();
        taskControl.NurseMidEmp = txtNurseMidEmp.Text.Trim().ToUpper();
        taskControl.McaNursePerf = chkMcaNursePerf.Checked;
        taskControl.NursePerfHours = txtNursePerfHours.Text.Trim().ToUpper();
        taskControl.NursePerfEmp = txtNursePerfEmp.Text.Trim().ToUpper();
        taskControl.McaNursePrac = chkMcaNursePrac.Checked;
        taskControl.NursePracHours = txtNursePracHours.Text.Trim().ToUpper();
        taskControl.NursePracEmp = txtNursePracEmp.Text.Trim().ToUpper();
        taskControl.McaOpto = chkMcaOpto.Checked;
        taskControl.OptoHours = txtOptoHours.Text.Trim().ToUpper();
        taskControl.OptoEmp = txtOptoEmp.Text.Trim().ToUpper();
        taskControl.McaPhyAss = chkMcaPhyAss.Checked;
        taskControl.PhyAssHours = txtPhyAssHours.Text.Trim().ToUpper();
        taskControl.PhyAssEmp = txtPhyAssEmp.Text.Trim().ToUpper();
        taskControl.McaPsych = chkMcaPsych.Checked;
        taskControl.PsychHours = txtPsychHours.Text.Trim().ToUpper();
        taskControl.PsychEmp = txtPsychEmp.Text.Trim().ToUpper();
        taskControl.McaScrub = chkMcaScrub.Checked;
        taskControl.ScrubHours = txtScrubHours.Text.Trim().ToUpper();
        taskControl.ScrubEmp = txtScrubEmp.Text.Trim().ToUpper();
        taskControl.McaSurgical = chkMcaSurgical.Checked;
        taskControl.SurgicalHours = txtSurgicalHours.Text.Trim().ToUpper();
        taskControl.SurgicalEmp = txtSurgicalEmp.Text.Trim().ToUpper();
        taskControl.McaOtherDesc = chkOtherDesc.Checked;
        taskControl.OtherDescHours = txtOtherDescHours.Text.Trim().ToUpper();
        taskControl.OtherDescEmp = txtOtherDescEmp.Text.Trim().ToUpper();
        taskControl.HCName1 = txtHCName1.Text.Trim().ToUpper();
        taskControl.HCSpeciality1 = txtHCSpeciality1.Text.Trim().ToUpper();
        taskControl.HCInsured1 = txtHCInsured1.Text.Trim().ToUpper();
        taskControl.HCLimits1 = txtHCLimits1.Text.Trim().ToUpper();
        taskControl.HCName2 = txtHCName2.Text.Trim().ToUpper();
        taskControl.HCSpecialty2 = txtHCSpecialty2.Text.Trim().ToUpper();
        taskControl.HCInsured2 = txtHCInsured2.Text.Trim().ToUpper();
        taskControl.HCLimits2 = txtHCLimits2.Text.Trim().ToUpper();
        taskControl.HCName3 = txtHCName3.Text.Trim().ToUpper();
        taskControl.HCSpecialty3 = txtHCSpecialty3.Text.Trim().ToUpper();
        taskControl.HCInsured3 = txtHCInsured3.Text.Trim().ToUpper();
        taskControl.HCLimits3 = txtHCLimits3.Text.Trim().ToUpper();
        taskControl.McaNone=chkMcaNone.Checked; 
        taskControl.McaBlood=chkMcaBlood.Checked; 
        taskControl.McaBirthing=chkMcaBirthing.Checked; 
        taskControl.McaCity=chkMcaCity.Checked; 
        taskControl.McaClinic=chkMcaClinic.Checked; 
        taskControl.McaEmergency=chkMcaEmergency.Checked; 
        taskControl.McaEmerHospital=chkMcaEmerHospital.Checked; 
        taskControl.McaFreeStanding=chkMcaFreeStanding.Checked; 
        taskControl.McaHospital=chkMcaHospital.Checked; 
        taskControl.McaConva=chkMcaConva.Checked; 
        taskControl.McaPsy=chkMcaPsy.Checked; 
        taskControl.McaInd=chkMcaInd.Checked; 
        taskControl.McaLaboratory=chkMcaLaboratory.Checked; 
        taskControl.McaNursing=chkMcaNursing.Checked; 
        taskControl.McaSanitarium=chkMcaSanitarium.Checked; 
        taskControl.McaUrgent=chkMcaUrgent.Checked; 
        taskControl.McaXrayFacility=chkMcaXrayFacility.Checked; 
        taskControl.McaOtherHC=chkMcaOtherHC.Checked; 
        taskControl.FacilityName1=txtFacilityName1.Text.Trim().ToUpper(); 
        taskControl.FacilityAddr1=txtFacilityAddr1.Text.Trim().ToUpper(); 
        taskControl.FacilityType1=txtFacilityType1.Text.Trim().ToUpper(); 
        taskControl.FacilityDuties1=txtFacilityDuties1.Text.Trim().ToUpper();
        taskControl.FacilityNumbers1 = txtFacilityNumbers1.Text.Trim().ToUpper();

        if (rdoMcaProfLiab1.Items[0].Selected)
        {
            taskControl.McaProfLiab1 = true;
        }
        else
        {
            taskControl.McaProfLiab1 = false;
        }

        if (rdoMcaExtendedCov1.Items[0].Selected)
        {
            taskControl.McaExtendedCov1 = true;
        }
        else
        {
            taskControl.McaExtendedCov1 = false;
        }

        taskControl.FacilityName2=txtFacilityName2.Text.Trim().ToUpper(); 
        taskControl.FacilityAddr2= txtFacilityAddr2.Text.Trim().ToUpper(); 
        taskControl.FacilityType2=txtFacilityType2.Text.Trim().ToUpper(); 
        taskControl.FacilityDuties2=txtFacilityDuties2.Text.Trim().ToUpper();
        taskControl.FacilityNumbers2 = txtFacilityNumbers2.Text.Trim().ToUpper();

        if (rdoMcaProfLiab.Items[0].Selected)
        {
            taskControl.McaProfLiab = true;
        }
        else
        {
            taskControl.McaProfLiab = false;
        }

        if (rdoMcaExtendedCov.Items[0].Selected)
        {
            taskControl.McaExtendedCov = true;
        }
        else
        {
            taskControl.McaExtendedCov = false;
        }

        if (rdoMcaFullTimeCov.Items[0].Selected)
        {
            taskControl.McaFullTimeCov = true;
        }
        else
        {
            taskControl.McaFullTimeCov = false;
        }

        if (rdoMcaPartTimeCov.Items[0].Selected)
        {
            taskControl.McaPartTimeCov = true;
        }
        else
        {
            taskControl.McaPartTimeCov = false;
        }

        taskControl.DaysPWeek = txtDaysPWeek.Text.Trim().ToUpper();
        taskControl.HoursPDayOffice = txtHoursPDayOffice.Text.Trim().ToUpper();
        taskControl.PatienPWeek = txtPatienPWeek.Text.Trim().ToUpper();
        taskControl.HoursPDayHosp = txtHoursPDayHosp.Text.Trim().ToUpper();
        taskControl.ActDesc = txtActDesc.Text.Trim().ToUpper();
        taskControl.App339Number1 = txtapp339Number1.Text.Trim().ToUpper();
        taskControl.App339Hours1 = txtapp339Hours1.Text.Trim().ToUpper();
        taskControl.App339Number2 = txtapp339Number2.Text.Trim().ToUpper();
        taskControl.App339Hours2 = txtapp339Hours2.Text.Trim().ToUpper();
        taskControl.App339Number3 = txtapp339Number3.Text.Trim().ToUpper();
        taskControl.App339Hours3 = txtapp339Hours3.Text.Trim().ToUpper();
        taskControl.App339Number4 = txtapp339Number4.Text.Trim().ToUpper();
        taskControl.App339Hours4 = txtapp339Hours4.Text.Trim().ToUpper();
        taskControl.App339Number5 = txtapp339Number5.Text.Trim().ToUpper();
        taskControl.App339Hours5 = txtapp339Hours5.Text.Trim().ToUpper();
        taskControl.App339Number6 = txtapp339Number6.Text.Trim().ToUpper();
        taskControl.App339Hours6 = txtapp339Hours6.Text.Trim().ToUpper();   

        Session["TaskControl"] = taskControl;
    }
}
