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

public partial class Application5 : System.Web.UI.Page
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
        CheckBox1.Checked = taskControl.McaAngio;
        CheckBox2.Checked = taskControl.McaAngioPTA;
        CheckBox3.Checked = taskControl.McaAorto;
        CheckBox4.Checked = taskControl.McaBiopsy;
        CheckBox5.Checked = taskControl.McaBreast;
        CheckBox6.Checked = taskControl.McaBreastImpl;
        CheckBox7.Checked = taskControl.McaCardiac;
        CheckBox8.Checked = taskControl.McaCoronary;
        CheckBox9.Checked = taskControl.McaCholangio;
        CheckBox10.Checked = taskControl.McaContrast;
        CheckBox11.Checked = taskControl.McaEndo;
        CheckBox12.Checked = taskControl.McaHexa;
        CheckBox13.Checked = taskControl.McaIntraO;
        CheckBox14.Checked = taskControl.McaIntraG;
        CheckBox15.Checked = taskControl.McaIvp;
        CheckBox16.Checked = taskControl.McaKidney;
        CheckBox17.Checked = taskControl.McaLiver;
        CheckBox18.Checked = taskControl.McaLipo;
        CheckBox19.Checked = taskControl.McaLung;
        CheckBox20.Checked = taskControl.McaMyelo;
        CheckBox21.Checked = taskControl.McaPaceT;
        CheckBox22.Checked = taskControl.McaPaceP;
        CheckBox23.Checked = taskControl.McaPercuT;
        CheckBox24.Checked = taskControl.McaPercuG;
        CheckBox25.Checked = taskControl.McaPerio;
        CheckBox26.Checked = taskControl.McaProstate;
        CheckBox27.Checked = taskControl.McaRadio;
        CheckBox28.Checked = taskControl.McaSilicone;
        CheckBox29.Checked = taskControl.McaSaline;
        CheckBox30.Checked = taskControl.McaThera;
        CheckBox31.Checked = taskControl.McaUseL;
        CheckBox32.Checked = taskControl.McaUseC;

        TextBox1.Text = taskControl.AngioNumber;
        TextBox2.Text = taskControl.AngioPTANumber;
        TextBox3.Text = taskControl.AortoNumber;
        TextBox4.Text = taskControl.BiopsyNumber;
        TextBox5.Text = taskControl.BreastNumber;
        TextBox6.Text = taskControl.BreastImplNumber;
        TextBox7.Text = taskControl.CardiacNumber;
        TextBox8.Text = taskControl.CoronaryNumber;
        TextBox9.Text = taskControl.CholangioNumber;
        TextBox10.Text = taskControl.ContrastNumber;
        TextBox11.Text = taskControl.EndoNumber;
        TextBox12.Text = taskControl.HexaNumber;
        TextBox13.Text = taskControl.IntraONumber;
        TextBox14.Text = taskControl.IntraGNumber;
        TextBox15.Text = taskControl.IvpNumber;
        TextBox16.Text = taskControl.KidneyNumber;
        TextBox17.Text = taskControl.LiverNumber;
        TextBox18.Text = taskControl.LipoNumber;
        TextBox19.Text = taskControl.LungNumber;
        TextBox20.Text = taskControl.MyeloNumber;
        TextBox21.Text = taskControl.PaceNumberT;
        TextBox22.Text = taskControl.PaceNumberP;
        TextBox23.Text = taskControl.PercuNumberT;
        TextBox24.Text = taskControl.PercuNumberG;
        TextBox25.Text = taskControl.PerioNumber;
        TextBox26.Text = taskControl.ProstateNumber;
        TextBox27.Text = taskControl.RadioNumber;
        TextBox28.Text = taskControl.SiliconeNumber;
        TextBox29.Text = taskControl.SalineNumber;
        TextBox30.Text = taskControl.TheraNumber;
        TextBox31.Text = taskControl.UseNumberL;
        TextBox32.Text = taskControl.UseNumberC;
    }

    private void EnableControls()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        btnNextBottom.Visible = true;
        btnPrevBottom.Visible = true;
        btnNextTop.Enabled = true;
        btnNextBottom.Enabled = true;

        CheckBox1.Enabled = true;
        CheckBox2.Enabled = true;
        CheckBox3.Enabled = true;
        CheckBox4.Enabled = true;
        CheckBox5.Enabled = true;
        CheckBox6.Enabled = true;
        CheckBox7.Enabled = true;
        CheckBox8.Enabled = true;
        CheckBox9.Enabled = true;
        CheckBox10.Enabled = true;
        CheckBox11.Enabled = true;
        CheckBox12.Enabled = true;
        CheckBox13.Enabled = true;
        CheckBox14.Enabled = true;
        CheckBox15.Enabled = true;
        CheckBox16.Enabled = true;
        CheckBox17.Enabled = true;
        CheckBox18.Enabled = true;
        CheckBox19.Enabled = true;
        CheckBox20.Enabled = true;
        CheckBox21.Enabled = true;
        CheckBox22.Enabled = true;
        CheckBox23.Enabled = true;
        CheckBox24.Enabled = true;
        CheckBox25.Enabled = true;
        CheckBox26.Enabled = true;
        CheckBox27.Enabled = true;
        CheckBox28.Enabled = true;
        CheckBox29.Enabled = true;
        CheckBox30.Enabled = true;
        CheckBox31.Enabled = true;
        CheckBox32.Enabled = true;

        TextBox1.Enabled = true;
        TextBox2.Enabled = true;
        TextBox3.Enabled = true;
        TextBox4.Enabled = true;
        TextBox5.Enabled = true;
        TextBox6.Enabled = true;
        TextBox7.Enabled = true;
        TextBox8.Enabled = true;
        TextBox9.Enabled = true;
        TextBox10.Enabled = true;
        TextBox11.Enabled = true;
        TextBox12.Enabled = true;
        TextBox13.Enabled = true;
        TextBox14.Enabled = true;
        TextBox15.Enabled = true;
        TextBox16.Enabled = true;
        TextBox17.Enabled = true;
        TextBox18.Enabled = true;
        TextBox19.Enabled = true;
        TextBox20.Enabled = true;
        TextBox21.Enabled = true;
        TextBox22.Enabled = true;
        TextBox23.Enabled = true;
        TextBox24.Enabled = true;
        TextBox25.Enabled = true;
        TextBox26.Enabled = true;
        TextBox27.Enabled = true;
        TextBox28.Enabled = true;
        TextBox29.Enabled = true;
        TextBox30.Enabled = true;
        TextBox31.Enabled = true;
        TextBox32.Enabled = true;
    }

    private void DisableControls()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        btnNextBottom.Visible = true;
        btnPrevBottom.Visible = true;
        btnNextTop.Enabled = true;
        btnNextBottom.Enabled = true;

        CheckBox1.Enabled = false;
        CheckBox2.Enabled = false;
        CheckBox3.Enabled = false;
        CheckBox4.Enabled = false;
        CheckBox5.Enabled = false;
        CheckBox6.Enabled = false;
        CheckBox7.Enabled = false;
        CheckBox8.Enabled = false;
        CheckBox9.Enabled = false;
        CheckBox10.Enabled = false;
        CheckBox11.Enabled = false;
        CheckBox12.Enabled = false;
        CheckBox13.Enabled = false;
        CheckBox14.Enabled = false;
        CheckBox15.Enabled = false;
        CheckBox16.Enabled = false;
        CheckBox17.Enabled = false;
        CheckBox18.Enabled = false;
        CheckBox19.Enabled = false;
        CheckBox20.Enabled = false;
        CheckBox21.Enabled = false;
        CheckBox22.Enabled = false;
        CheckBox23.Enabled = false;
        CheckBox24.Enabled = false;
        CheckBox25.Enabled = false;
        CheckBox26.Enabled = false;
        CheckBox27.Enabled = false;
        CheckBox28.Enabled = false;
        CheckBox29.Enabled = false;
        CheckBox30.Enabled = false;
        CheckBox31.Enabled = false;
        CheckBox32.Enabled = false;

        TextBox1.Enabled = false;
        TextBox2.Enabled = false;
        TextBox3.Enabled = false;
        TextBox4.Enabled = false;
        TextBox5.Enabled = false;
        TextBox6.Enabled = false;
        TextBox7.Enabled = false;
        TextBox8.Enabled = false;
        TextBox9.Enabled = false;
        TextBox10.Enabled = false;
        TextBox11.Enabled = false;
        TextBox12.Enabled = false;
        TextBox13.Enabled = false;
        TextBox14.Enabled = false;
        TextBox15.Enabled = false;
        TextBox16.Enabled = false;
        TextBox17.Enabled = false;
        TextBox18.Enabled = false;
        TextBox19.Enabled = false;
        TextBox20.Enabled = false;
        TextBox21.Enabled = false;
        TextBox22.Enabled = false;
        TextBox23.Enabled = false;
        TextBox24.Enabled = false;
        TextBox25.Enabled = false;
        TextBox26.Enabled = false;
        TextBox27.Enabled = false;
        TextBox28.Enabled = false;
        TextBox29.Enabled = false;
        TextBox30.Enabled = false;
        TextBox31.Enabled = false;
        TextBox32.Enabled = false;

        VerifyAccess();
    }

    private void RemoveSessionLookUp()
    {
        Session.Remove("LookUpTables");
    }

    protected void btnPrevTop_Click(object sender, EventArgs e)
    {
        Response.Redirect("Application4.aspx", false);
    }

    protected void btnPrevBottom_Click(object sender, EventArgs e)
    {
        Response.Redirect("Application4.aspx", false);
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

            taskControl.Save(userID, 5);  //(userID);
            FillTextControl();
            DisableControls();

            Session["TaskControl"] = taskControl;

            if (taskControl.ApplicationMode == "UPDATE" || taskControl.ApplicationMode == "ADD")
            {
                if (taskControl.ApplicationExist(taskControl.TaskControlID, 5))
                    taskControl.ApplicationMode = "UPDATE";
                else
                    taskControl.ApplicationMode = "ADD";
            }
            else
            {
                if (taskControl.ApplicationExist(taskControl.TaskControlID, 5))
                    taskControl.ApplicationMode = "";
                else
                    taskControl.ApplicationMode = "ADD";
            }

            Response.Redirect("Application6.aspx", false);
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

        taskControl.McaAngio = CheckBox1.Checked;
        taskControl.McaAngioPTA = CheckBox2.Checked; 
        taskControl.McaAorto = CheckBox3.Checked; 
        taskControl.McaBiopsy = CheckBox4.Checked; 
        taskControl.McaBreast = CheckBox5.Checked; 
        taskControl.McaBreastImpl = CheckBox6.Checked; 
        taskControl.McaCardiac = CheckBox7.Checked; 
        taskControl.McaCoronary = CheckBox8.Checked; 
        taskControl.McaCholangio = CheckBox9.Checked; 
        taskControl.McaContrast = CheckBox10.Checked; 
        taskControl.McaEndo = CheckBox11.Checked; 
        taskControl.McaHexa = CheckBox12.Checked; 
        taskControl.McaIntraO = CheckBox13.Checked; 
        taskControl.McaIntraG = CheckBox14.Checked; 
        taskControl.McaIvp = CheckBox15.Checked; 
        taskControl.McaKidney = CheckBox16.Checked; 
        taskControl.McaLiver = CheckBox17.Checked; 
        taskControl.McaLipo = CheckBox18.Checked; 
        taskControl.McaLung = CheckBox19.Checked; 
        taskControl.McaMyelo = CheckBox20.Checked; 
        taskControl.McaPaceT = CheckBox21.Checked; 
        taskControl.McaPaceP = CheckBox22.Checked; 
        taskControl.McaPercuT = CheckBox23.Checked; 
        taskControl.McaPercuG = CheckBox24.Checked; 
        taskControl.McaPerio = CheckBox25.Checked; 
        taskControl.McaProstate = CheckBox26.Checked; 
        taskControl.McaRadio = CheckBox27.Checked; 
        taskControl.McaSilicone = CheckBox28.Checked; 
        taskControl.McaSaline = CheckBox29.Checked; 
        taskControl.McaThera = CheckBox30.Checked; 
        taskControl.McaUseL = CheckBox31.Checked; 
        taskControl.McaUseC =  CheckBox32.Checked;


        taskControl.AngioNumber = TextBox1.Text.ToUpper().Trim();
        taskControl.AngioPTANumber = TextBox2.Text.ToUpper().Trim();
        taskControl.AortoNumber = TextBox3.Text.ToUpper().Trim();
        taskControl.BiopsyNumber = TextBox4.Text.ToUpper().Trim();
        taskControl.BreastNumber = TextBox5.Text.ToUpper().Trim();
        taskControl.BreastImplNumber = TextBox6.Text.ToUpper().Trim();
        taskControl.CardiacNumber = TextBox7.Text.ToUpper().Trim();
        taskControl.CoronaryNumber = TextBox8.Text.ToUpper().Trim();
        taskControl.CholangioNumber = TextBox9.Text.ToUpper().Trim();
        taskControl.ContrastNumber = TextBox10.Text.ToUpper().Trim();
        taskControl.EndoNumber = TextBox11.Text.ToUpper().Trim();
        taskControl.HexaNumber = TextBox12.Text.ToUpper().Trim();
        taskControl.IntraONumber = TextBox13.Text.ToUpper().Trim();
        taskControl.IntraGNumber = TextBox14.Text.ToUpper().Trim();
        taskControl.IvpNumber = TextBox15.Text.ToUpper().Trim();
        taskControl.KidneyNumber = TextBox16.Text.ToUpper().Trim();
        taskControl.LiverNumber = TextBox17.Text.ToUpper().Trim();
        taskControl.LipoNumber = TextBox18.Text.ToUpper().Trim();
        taskControl.LungNumber = TextBox19.Text.ToUpper().Trim();
        taskControl.MyeloNumber = TextBox20.Text.ToUpper().Trim();
        taskControl.PaceNumberT = TextBox21.Text.ToUpper().Trim();
        taskControl.PaceNumberP = TextBox22.Text.ToUpper().Trim();
        taskControl.PercuNumberT = TextBox23.Text.ToUpper().Trim();
        taskControl.PercuNumberG = TextBox24.Text.ToUpper().Trim();
        taskControl.PerioNumber = TextBox25.Text.ToUpper().Trim();
        taskControl.ProstateNumber = TextBox26.Text.ToUpper().Trim();
        taskControl.RadioNumber = TextBox27.Text.ToUpper().Trim();
        taskControl.SiliconeNumber = TextBox28.Text.ToUpper().Trim();
        taskControl.SalineNumber = TextBox29.Text.ToUpper().Trim();
        taskControl.TheraNumber = TextBox30.Text.ToUpper().Trim();
        taskControl.UseNumberL = TextBox31.Text.ToUpper().Trim();
        taskControl.UseNumberC = TextBox32.Text.ToUpper().Trim(); 

        Session["TaskControl"] = taskControl;
    }
}
