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

public partial class Application3 : System.Web.UI.Page
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

                            rdoMcaOtherPhy.Items[0].Selected = false;
                            rdoMcaRefferral.Items[0].Selected = false;
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
        txtHospital1.Text = taskControl.Hospital1;
        txtHospital2.Text = taskControl.Hospital2;
        txtHospital3.Text = taskControl.Hospital3;
        txtHospital4.Text = taskControl.Hospital4;
        txtCity1.Text = taskControl.City1;
        txtCity2.Text = taskControl.City2;
        txtCity3.Text = taskControl.City3;
        txtCity4.Text = taskControl.City4;
        txtPrivileges1.Text = taskControl.Privileges1;
        txtPrivileges2.Text = taskControl.Privileges2;
        txtPrivileges3.Text = taskControl.Privileges3;
        txtPrivileges4.Text = taskControl.Privileges4;
        txtRestrictions1.Text = taskControl.Restrictions1;
        txtRestrictions2.Text = taskControl.Restrictions2;
        txtRestrictions3.Text = taskControl.Restrictions3;
        txtRestrictions4.Text = taskControl.Restrictions4;
        txtOficeAddr1.Text = taskControl.OficeAddr1;
        txtOficeAddr2.Text = taskControl.OficeAddr2;
        txtOficeAddr3.Text = taskControl.OficeAddr3;
        txtOficeCity1.Text = taskControl.OficeCity1;
        txtOficeCity2.Text = taskControl.OficeCity2;
        txtOficeCity3.Text = taskControl.OficeCity3;
        txtOficeCountry1.Text = taskControl.OficeCountry1;
        txtOficeCountry2.Text = taskControl.OficeCountry2;
        txtOficeCountry3.Text = taskControl.OficeCountry3;
        txtEntName1.Text = taskControl.EntName1;
        txtEntName2.Text = taskControl.EntName2;
        txtEntName3.Text = taskControl.EntName3;
        txtEntName4.Text = taskControl.EntName4;
        txtEntName5.Text = taskControl.EntName5;
        txtEntDate1.Text = taskControl.EntDate1;
        txtEntDate2.Text = taskControl.EntDate2;
        txtEntDate3.Text = taskControl.EntDate3;
        txtEntDate4.Text = taskControl.EntDate4;
        txtEntDate5.Text = taskControl.EntDate5;
        txtEntAddr1.Text = taskControl.EntAddr1;
        txtEntAddr2.Text = taskControl.EntAddr2;
        txtEntAddr3.Text = taskControl.EntAddr3;
        txtEntAddr4.Text = taskControl.EntAddr4;
        txtEntAddr5.Text = taskControl.EntAddr5;
        txtEntSpecialty1.Text = taskControl.EntSpecialty1;
        txtEntSpecialty2.Text = taskControl.EntSpecialty2;
        txtEntSpecialty3.Text = taskControl.EntSpecialty3;
        txtEntSpecialty4.Text = taskControl.EntSpecialty4;
        txtEntSpecialty5.Text = taskControl.EntSpecialty5;
        chkMcaPhysician.Checked = taskControl.McaPhysician;
        chkMcaEmpPhysician.Checked = taskControl.McaEmpPhysician;
        chkMcaProfAss.Checked = taskControl.McaProfAss;
        chkMcaOther.Checked = taskControl.McaOther;
        chkMcaPartnership.Checked = taskControl.McaPartnership;
        chkMcaGroup.Checked = taskControl.McaGroup;
        chkMcaProfCorp.Checked = taskControl.McaProfCorp;

        txtPhyEntName.Text = taskControl.PhyEntName;
        txtPhyStatus.Text = taskControl.PhyStatus;
        txtPhyPartners.Text = taskControl.PhyPartners;

        if (taskControl.McaOtherPhy)
        {
            rdoMcaOtherPhy.Items[0].Selected = true;
            rdoMcaOtherPhy.Items[1].Selected = false;
        }
        else
        {
            rdoMcaOtherPhy.Items[0].Selected = false;
            rdoMcaOtherPhy.Items[1].Selected = true;
        }

        txtPhyName.Text = taskControl.PhyName;
        txtPhyAssoc.Text = taskControl.PhyAssoc;

        if (taskControl.McaRefferral)
        {
            rdoMcaRefferral.Items[0].Selected = true;
            rdoMcaRefferral.Items[1].Selected = false;
        }
        else
        {
            rdoMcaRefferral.Items[0].Selected = false;
            rdoMcaRefferral.Items[1].Selected = true;
        }

        txtRefferralDesc.Text = taskControl.RefferralDesc;
    }

    private void EnableControls()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        btnNextBottom.Visible = true;
        btnPrevBottom.Visible = true;
        btnNextTop.Enabled = true;
        btnNextBottom.Enabled = true;

        txtHospital1.Enabled = true;
        txtHospital2.Enabled = true;
        txtHospital3.Enabled = true;
        txtHospital4.Enabled = true;
        txtCity1.Enabled = true;
        txtCity2.Enabled = true;
        txtCity3.Enabled = true;
        txtCity4.Enabled = true;
        txtPrivileges1.Enabled = true;
        txtPrivileges2.Enabled = true;
        txtPrivileges3.Enabled = true;
        txtPrivileges4.Enabled = true;
        txtRestrictions1.Enabled = true;
        txtRestrictions2.Enabled = true;
        txtRestrictions3.Enabled = true;
        txtRestrictions4.Enabled = true;
        txtOficeAddr1.Enabled = true;
        txtOficeAddr2.Enabled = true;
        txtOficeAddr3.Enabled = true;
        txtOficeCity1.Enabled = true;
        txtOficeCity2.Enabled = true;
        txtOficeCity3.Enabled = true;
        txtOficeCountry1.Enabled = true;
        txtOficeCountry2.Enabled = true;
        txtOficeCountry3.Enabled = true;
        txtEntName1.Enabled = true;
        txtEntName2.Enabled = true;
        txtEntName3.Enabled = true;
        txtEntName4.Enabled = true;
        txtEntName5.Enabled = true;
        txtEntDate1.Enabled = true;
        txtEntDate2.Enabled = true;
        txtEntDate3.Enabled = true;
        txtEntDate4.Enabled = true;
        txtEntDate5.Enabled = true;
        txtEntAddr1.Enabled = true;
        txtEntAddr2.Enabled = true;
        txtEntAddr3.Enabled = true;
        txtEntAddr4.Enabled = true;
        txtEntAddr5.Enabled = true;
        txtEntSpecialty1.Enabled = true;
        txtEntSpecialty2.Enabled = true;
        txtEntSpecialty3.Enabled = true;
        txtEntSpecialty4.Enabled = true;
        txtEntSpecialty5.Enabled = true;
        chkMcaPhysician.Enabled = true;
        chkMcaEmpPhysician.Enabled = true;
        chkMcaProfAss.Enabled = true;
        chkMcaOther.Enabled = true;
        chkMcaPartnership.Enabled = true;
        chkMcaGroup.Enabled = true;
        chkMcaProfCorp.Enabled = true;

        txtPhyEntName.Enabled = true;
        txtPhyStatus.Enabled = true;
        txtPhyPartners.Enabled = true;
        rdoMcaOtherPhy.Enabled = true;
        txtPhyName.Enabled = true;
        txtPhyAssoc.Enabled = true;
        rdoMcaRefferral.Enabled = true;

        txtRefferralDesc.Enabled = true; 
    }

    private void DisableControls()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        btnNextBottom.Visible = true;
        btnPrevBottom.Visible = true;
        btnNextTop.Enabled = true;
        btnNextBottom.Enabled = true;


        txtHospital1.Enabled = false;
        txtHospital2.Enabled = false;
        txtHospital3.Enabled = false;
        txtHospital4.Enabled = false;
        txtCity1.Enabled = false;
        txtCity2.Enabled = false;
        txtCity3.Enabled = false;
        txtCity4.Enabled = false;
        txtPrivileges1.Enabled = false;
        txtPrivileges2.Enabled = false;
        txtPrivileges3.Enabled = false;
        txtPrivileges4.Enabled = false;
        txtRestrictions1.Enabled = false;
        txtRestrictions2.Enabled = false;
        txtRestrictions3.Enabled = false;
        txtRestrictions4.Enabled = false;
        txtOficeAddr1.Enabled = false;
        txtOficeAddr2.Enabled = false;
        txtOficeAddr3.Enabled = false;
        txtOficeCity1.Enabled = false;
        txtOficeCity2.Enabled = false;
        txtOficeCity3.Enabled = false;
        txtOficeCountry1.Enabled = false;
        txtOficeCountry2.Enabled = false;
        txtOficeCountry3.Enabled = false;
        txtEntName1.Enabled = false;
        txtEntName2.Enabled = false;
        txtEntName3.Enabled = false;
        txtEntName4.Enabled = false;
        txtEntName5.Enabled = false;
        txtEntDate1.Enabled = false;
        txtEntDate2.Enabled = false;
        txtEntDate3.Enabled = false;
        txtEntDate4.Enabled = false;
        txtEntDate5.Enabled = false;
        txtEntAddr1.Enabled = false;
        txtEntAddr2.Enabled = false;
        txtEntAddr3.Enabled = false;
        txtEntAddr4.Enabled = false;
        txtEntAddr5.Enabled = false;
        txtEntSpecialty1.Enabled = false;
        txtEntSpecialty2.Enabled = false;
        txtEntSpecialty3.Enabled = false;
        txtEntSpecialty4.Enabled = false;
        txtEntSpecialty5.Enabled = false;
        chkMcaPhysician.Enabled = false;
        chkMcaEmpPhysician.Enabled = false;
        chkMcaProfAss.Enabled = false;
        chkMcaOther.Enabled = false;
        chkMcaPartnership.Enabled = false;
        chkMcaGroup.Enabled = false;
        chkMcaProfCorp.Enabled = false;

        txtPhyEntName.Enabled = false;
        txtPhyStatus.Enabled = false;
        txtPhyPartners.Enabled = false;
        rdoMcaOtherPhy.Enabled = false;
        txtPhyName.Enabled = false;
        txtPhyAssoc.Enabled = false;
        rdoMcaRefferral.Enabled = false;

        txtRefferralDesc.Enabled = false; 

        VerifyAccess();
    }

    private void RemoveSessionLookUp()
    {
        Session.Remove("LookUpTables");
    }

    protected void btnPrevTop_Click(object sender, EventArgs e)
    {
        Response.Redirect("Application2.aspx", false);
    }

    protected void btnPrevBottom_Click(object sender, EventArgs e)
    {
        Response.Redirect("Application2.aspx", false);
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

            taskControl.Save(userID, 3);  //(userID);
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

            Response.Redirect("Application4.aspx", false);
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
 
        taskControl.Hospital1= txtHospital1.Text.Trim().ToUpper();
        taskControl.Hospital2= txtHospital2.Text.Trim().ToUpper();
        taskControl.Hospital3= txtHospital3.Text.Trim().ToUpper();
        taskControl.Hospital4= txtHospital4.Text.Trim().ToUpper();
        taskControl.City1= txtCity1.Text.Trim().ToUpper();
        taskControl.City2= txtCity2.Text.Trim().ToUpper();
        taskControl.City3= txtCity3.Text.Trim().ToUpper();
        taskControl.City4= txtCity4.Text.Trim().ToUpper();
        taskControl.Privileges1= txtPrivileges1.Text.Trim().ToUpper();
        taskControl.Privileges2= txtPrivileges2.Text.Trim().ToUpper();
        taskControl.Privileges3= txtPrivileges3.Text.Trim().ToUpper();
        taskControl.Privileges4= txtPrivileges4.Text.Trim().ToUpper();
        taskControl.Restrictions1= txtRestrictions1.Text.Trim().ToUpper();
        taskControl.Restrictions2= txtRestrictions2.Text.Trim().ToUpper();
        taskControl.Restrictions3= txtRestrictions3.Text.Trim().ToUpper();
        taskControl.Restrictions4= txtRestrictions4.Text.Trim().ToUpper();
        taskControl.OficeAddr1= txtOficeAddr1.Text.Trim().ToUpper();
        taskControl.OficeAddr2= txtOficeAddr2.Text.Trim().ToUpper();
        taskControl.OficeAddr3= txtOficeAddr3.Text.Trim().ToUpper();
        taskControl.OficeCity1 = txtOficeCity1.Text.Trim().ToUpper();
        taskControl.OficeCity2 = txtOficeCity2.Text.Trim().ToUpper();
        taskControl.OficeCity3 = txtOficeCity3.Text.Trim().ToUpper();
        taskControl.OficeCountry1 = txtOficeCountry1.Text.Trim().ToUpper();
        taskControl.OficeCountry2 = txtOficeCountry2.Text.Trim().ToUpper();
        taskControl.OficeCountry3 = txtOficeCountry3.Text.Trim().ToUpper();
        taskControl.EntName1= txtEntName1.Text.Trim().ToUpper();
        taskControl.EntName2= txtEntName2.Text.Trim().ToUpper();
        taskControl.EntName3= txtEntName3.Text.Trim().ToUpper();
        taskControl.EntName4= txtEntName4.Text.Trim().ToUpper();
        taskControl.EntName5= txtEntName5.Text.Trim().ToUpper();
        taskControl.EntDate1= txtEntDate1.Text.Trim().ToUpper();
        taskControl.EntDate2= txtEntDate2.Text.Trim().ToUpper();
        taskControl.EntDate3= txtEntDate3.Text.Trim().ToUpper();
        taskControl.EntDate4= txtEntDate4.Text.Trim().ToUpper();
        taskControl.EntDate5= txtEntDate5.Text.Trim().ToUpper();
        taskControl.EntAddr1= txtEntAddr1.Text.Trim().ToUpper();
        taskControl.EntAddr2= txtEntAddr2.Text.Trim().ToUpper();
        taskControl.EntAddr3= txtEntAddr3.Text.Trim().ToUpper();
        taskControl.EntAddr4= txtEntAddr4.Text.Trim().ToUpper();
        taskControl.EntAddr5= txtEntAddr5.Text.Trim().ToUpper();
        taskControl.EntSpecialty1= txtEntSpecialty1.Text.Trim().ToUpper();
        taskControl.EntSpecialty2= txtEntSpecialty2.Text.Trim().ToUpper();
        taskControl.EntSpecialty3= txtEntSpecialty3.Text.Trim().ToUpper();
        taskControl.EntSpecialty4= txtEntSpecialty4.Text.Trim().ToUpper();
        taskControl.EntSpecialty5= txtEntSpecialty5.Text.Trim().ToUpper();
        taskControl.McaPhysician = chkMcaPhysician.Checked;
        taskControl.McaEmpPhysician = chkMcaEmpPhysician.Checked;
        taskControl.McaProfAss = chkMcaProfAss.Checked;
        taskControl.McaOther = chkMcaOther.Checked;
        taskControl.McaPartnership = chkMcaPartnership.Checked;
        taskControl.McaGroup = chkMcaGroup.Checked;
        taskControl.McaProfCorp = chkMcaProfCorp.Checked;

        taskControl.PhyEntName= txtPhyEntName.Text.Trim().ToUpper();
        taskControl.PhyStatus= txtPhyStatus.Text.Trim().ToUpper(); 
        taskControl.PhyPartners=txtPhyPartners.Text.Trim().ToUpper(); 

        if (rdoMcaOtherPhy.Items[0].Selected)
        {
            taskControl.McaOtherPhy = true;
        }
        else
        {
            taskControl.McaOtherPhy = false;
        }

        taskControl.PhyName=        txtPhyName.Text.Trim().ToUpper(); 
        taskControl.PhyAssoc=       txtPhyAssoc.Text.Trim().ToUpper(); 

        if (rdoMcaRefferral.Items[0].Selected)
        {
            taskControl.McaRefferral = true;
        }
        else
        {
            taskControl.McaRefferral = false;
        }

        taskControl.RefferralDesc=txtRefferralDesc.Text.Trim().ToUpper(); 

        Session["TaskControl"] = taskControl;
    }

}
