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

public partial class Directory : System.Web.UI.Page
{
    private DataTable DtDirectory = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.litPopUp.Visible = false;

        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        if (cp == null)
        {
            Response.Redirect("Default.aspx?001");
        }
        else
        {
            if (!cp.IsInRole("DIRECTORY") && !cp.IsInRole("ADMINISTRATOR"))
            {
                Response.Redirect("Default.aspx?001");
            }
        }

        btnDelete = EPolicy.Utilities.ConfirmDialogBoxPopUp(btnDelete, "Directory", "Do you want DELETE this Information?");

        Control Banner = new Control();
        Banner = LoadControl(@"TopBanner.ascx");
        this.Placeholder1.Controls.Add(Banner);

        //Setup Left-side Banner			
        Control LeftMenu = new Control();
        LeftMenu = LoadControl(@"LeftMenu.ascx");
        phTopBanner1.Controls.Add(LeftMenu);

        

        if (Session["AutoPostBack"] == null)
        {
            if (!IsPostBack)
            {
                //Load DownDropList
                DataTable dtCity = EPolicy.LookupTables.LookupTables.GetTable("City");
                DataTable dtPRMEDICSpecialty = EPolicy.LookupTables.LookupTables.GetTable("PRMEDICSpecialty");
                DataTable dtCiudad = EPolicy.LookupTables.LookupTables.GetTable("Ciudad");
                DataTable dtLocationMed = EPolicy.LookupTables.LookupTables.GetTable("LocationMed");

                ddlCiudad.DataSource = dtCiudad;
                ddlCiudad.DataTextField = "Ciudad";
                ddlCiudad.DataValueField = "ZipCode";
                ddlCiudad.DataBind();
                ddlCiudad.SelectedIndex = -1;
                ddlCiudad.Items.Insert(0, "");

                ddlCiudad2.DataSource = dtCiudad;
                ddlCiudad2.DataTextField = "Ciudad";
                ddlCiudad2.DataValueField = "ZipCode";
                ddlCiudad2.DataBind();
                ddlCiudad2.SelectedIndex = -1;
                ddlCiudad2.Items.Insert(0, "");

                ddlCiudad3.DataSource = dtCiudad;
                ddlCiudad3.DataTextField = "Ciudad";
                ddlCiudad3.DataValueField = "ZipCode";
                ddlCiudad3.DataBind();
                ddlCiudad3.SelectedIndex = -1;
                ddlCiudad3.Items.Insert(0, "");

                //Location
                ddlLocation.DataSource = dtLocationMed;
                ddlLocation.DataTextField = "LocationMedDesc";
                ddlLocation.DataValueField = "LocationMedID";
                ddlLocation.DataBind();
                ddlLocation.SelectedIndex = -1;
                ddlLocation.Items.Insert(0, "");

                //Location - Search
                ddlLocation2.DataSource = dtLocationMed;
                ddlLocation2.DataTextField = "LocationMedDesc";
                ddlLocation2.DataValueField = "LocationMedID";
                ddlLocation2.DataBind();
                ddlLocation2.SelectedIndex = -1;
                ddlLocation2.Items.Insert(0, "");

                //PRMEDICSpecialty
                ddlSpecialty.DataSource = dtPRMEDICSpecialty;
                ddlSpecialty.DataTextField = "PRMEDICSpecialtyDesc";
                ddlSpecialty.DataValueField = "PRMEDICSpecialtyID";
                ddlSpecialty.DataBind();
                ddlSpecialty.SelectedIndex = -1;
                ddlSpecialty.Items.Insert(0, "");

                //PRMEDICSpecialty - Search
                ddlSpecialty2.DataSource = dtPRMEDICSpecialty;
                ddlSpecialty2.DataTextField = "PRMEDICSpecialtyDesc";
                ddlSpecialty2.DataValueField = "PRMEDICSpecialtyID";
                ddlSpecialty2.DataBind();
                ddlSpecialty2.SelectedIndex = -1;
                ddlSpecialty2.Items.Insert(0, "");

                if (Session["Directorycs"] != null)
                {
                    Directorycs directorycs = (Directorycs)Session["Directorycs"];

                    switch (directorycs.Mode)
                    {
                        case 1: //ADD
                            FillTextControl();
                            EnableControls();
                            break;

                        case 2: //UPDATE
                            FillTextControl();
                            EnableControls();
                            break;

                        default:
                            FillTextControl();

                            if (ddlCiudad2.SelectedItem.Value.ToString().Trim() != "")
                            {
                                FillDataGrid();
                            }
                            DisableControls();
                            break;
                    }
                }
            }
            else
            {
                if (Session["Directorycs"] != null)
                {
                    Directorycs directorycs = (Directorycs)Session["Directorycs"];
                    if (directorycs.Mode == 4)
                    {
                        DisableControls();
                    }
                }
            }
        }
        else
        {
            FillTextControl();
            EnableControls();
            Session.Remove("AutoPostBack");
        }

    }

    #region Private Method
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillDataGrid();
    }

    private void FillDataGrid()
    {
        try
        {
            FieldVerify();
        }
        catch (Exception exp)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("" + exp.Message);
            this.litPopUp.Visible = true;
            return;
        }

        LblError.Visible = false;
        searchDirectory.DataSource = null;
        DtDirectory = null;

        searchDirectory.CurrentPageIndex = 0;
        searchDirectory.Visible = false;

        DtDirectory = Directorycs.GetDirectoryByCriteria(ddlCiudad2.SelectedItem.Text.Trim(),
            ddlLocation2.SelectedItem.Text.ToString().Trim(), ddlSpecialty2.SelectedItem.Text.Trim(),
            TxtSearchFirstName.Text.Trim(), txtSearchLastName.Text.Trim());

        Session.Remove("DtDirectory");
        Session.Add("DtDirectory", DtDirectory);

        if (DtDirectory.Rows.Count != 0)
        {
            searchDirectory.Visible = true;

            searchDirectory.DataSource = DtDirectory;
            searchDirectory.DataBind();
        }
        else
        {
            searchDirectory.DataSource = null;
            searchDirectory.DataBind();

            LblError.Visible = true;
            LblError.Text = "Could not find a match for your search criteria, please try again.";
        }

        LblTotalCases.Text = "Total Cases: " + DtDirectory.Rows.Count.ToString();
    }

    private void FieldVerify()
    {
        string errorMessage = String.Empty;
        bool found = false;

        if (this.ddlSpecialty2.SelectedItem.Text.Trim() == "" &&
            this.ddlLocation2.SelectedItem.Text.Trim() == "" &&
            this.ddlCiudad2.SelectedItem.Text.Trim() == "" &&
            this.TxtSearchFirstName.Text.Trim() == "" &&
            this.txtLastname1.Text.Trim() == "" && found == false)
        {
            errorMessage = "Please enter the information for at least one criteria for search.";
            found = true;
        }

        //throw the exception.
        if (errorMessage != String.Empty)
        {
            throw new Exception(errorMessage);
        }
    }
    #endregion


    protected void searchDirectory_ItemCommand(object source, DataGridCommandEventArgs e)
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

        if (e.CommandName == "Select") // Select
        {
            int i = int.Parse(e.Item.Cells[1].Text);
            Directorycs directorycs = Directorycs.GetDirectoryByDirectoryID(i);

            if (Session["DtDirectory"] != null)
            {
                if (Session["Directorycs"] == null)
                    Session.Add("Directorycs", directorycs);
                else
                    Session["Directorycs"] = directorycs;

                FillTextControl();
                DisableControls();
            }
        }
        else  // Pager
        {
            searchDirectory.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

            searchDirectory.DataSource = (DataTable)Session["DtDirectory"];
            searchDirectory.DataBind();
        }
    }

    private void FillTextControl()
    {
        Directorycs directorycs = (Directorycs)Session["Directorycs"];

        //Location
        ddlLocation.SelectedIndex = 0;
        if (directorycs.LocationID != 0)
        {
            for (int i = 0; ddlLocation.Items.Count - 1 >= i; i++)
            {
                if (ddlLocation.Items[i].Value == directorycs.LocationID.ToString())
                {
                    ddlLocation.SelectedIndex = i;
                    i = ddlLocation.Items.Count - 1;
                }
            }
        }

        //Specialty
        ddlSpecialty.SelectedIndex = 0;
        if (directorycs.Specialty != 0)
        {
            for (int i = 0; ddlSpecialty.Items.Count - 1 >= i; i++)
            {
                if (ddlSpecialty.Items[i].Value == directorycs.Specialty.ToString())
                {
                    ddlSpecialty.SelectedIndex = i;
                    i = ddlSpecialty.Items.Count - 1;
                }
            }
        }

        ddlCiudad.SelectedIndex = 0;
        if (directorycs.City != "")
        {
            for (int i = 0; ddlCiudad.Items.Count - 1 >= i; i++)
            {
                if (ddlCiudad.Items[i].Text.Trim() == directorycs.City.ToString().Trim())
                {
                    ddlCiudad.SelectedIndex = i;
                    i = ddlCiudad.Items.Count - 1;
                }
            }
        }

        ddlCiudad3.SelectedIndex = 0;
        if (directorycs.CityPostal != "")
        {
            for (int i = 0; ddlCiudad3.Items.Count - 1 >= i; i++)
            {
                if (ddlCiudad3.Items[i].Text.Trim() == directorycs.CityPostal.ToString().Trim())
                {
                    ddlCiudad3.SelectedIndex = i;
                    i = ddlCiudad3.Items.Count - 1;
                }
            }
        }

        txtFirstName.Text = directorycs.FirstName.Trim().ToUpper();
        txtLastname1.Text = directorycs.LastName.Trim().ToUpper();
        txtSalutation.Text = directorycs.Salutation.Trim().ToUpper();
        txtTitle.Text = directorycs.Title.Trim().ToUpper();
        txtAdds1.Text = directorycs.Adds1.Trim().ToUpper();
        txtAdds2.Text = directorycs.Adds2.Trim().ToUpper();
        txtState.Text = directorycs.State.Trim().ToUpper();
        txtZip.Text = directorycs.Zip.Trim().ToUpper();
        TxtPhone1.Text = directorycs.Phone1;
        txtExt.Text = directorycs.Ext1;
        txtPhone2.Text = directorycs.Phone2;
        txtEmail.Text = directorycs.Email.Trim().ToUpper();
        txtPostalAdds1.Text = directorycs.Adds1Postal.Trim().ToUpper();
        txtPostalAdds2.Text = directorycs.Adds2Postal.Trim().ToUpper();
        txtPostalState.Text = directorycs.StatePostal.Trim().ToUpper();
        txtPostalZip.Text = directorycs.ZipPostal.Trim().ToUpper();
        txtComments.Text = directorycs.Comments.Trim().ToUpper();
    }

    private void FillProperties()
    {
        Directorycs directorycs = (Directorycs)Session["Directorycs"];

        //Ciudad
        if (ddlCiudad.SelectedIndex > 0 && ddlCiudad.SelectedItem != null)
            directorycs.City = ddlCiudad.SelectedItem.Text;
        else
            directorycs.City = "";

        //Ciudad
        if (ddlCiudad3.SelectedIndex > 0 && ddlCiudad3.SelectedItem != null)
            directorycs.CityPostal = ddlCiudad3.SelectedItem.Text;
        else
            directorycs.CityPostal = "";

        if (ddlLocation.SelectedIndex > 0 && ddlLocation.SelectedItem != null)
            directorycs.LocationID = int.Parse(ddlLocation.SelectedItem.Value.ToString());
        else
            directorycs.LocationID = 0;

        //Specialty
        if (ddlSpecialty.SelectedIndex > 0 && ddlSpecialty.SelectedItem != null)
            directorycs.Specialty = int.Parse(ddlSpecialty.SelectedItem.Value);
        else
            directorycs.Specialty = 0;

        directorycs.FirstName = txtFirstName.Text.Trim().ToUpper();
        directorycs.LastName = txtLastname1.Text.Trim().ToUpper();
        directorycs.Salutation = txtSalutation.Text.Trim().ToUpper();
        directorycs.Title = txtTitle.Text.Trim().ToUpper();
        directorycs.Adds1 = txtAdds1.Text.Trim().ToUpper();
        directorycs.Adds2 = txtAdds2.Text.Trim().ToUpper();
        directorycs.State = txtState.Text.Trim().ToUpper();
        directorycs.Zip = txtZip.Text.Trim().ToUpper();
        directorycs.Phone1 = TxtPhone1.Text.Trim().ToUpper();
        directorycs.Ext1 = txtExt.Text.Trim().ToUpper();
        directorycs.Phone2 = txtPhone2.Text.Trim().ToUpper();
        directorycs.Email = txtEmail.Text.Trim().ToUpper();
        directorycs.Adds1Postal = txtPostalAdds1.Text.Trim().ToUpper();
        directorycs.Adds2Postal = txtPostalAdds2.Text.Trim().ToUpper();
        directorycs.StatePostal = txtPostalState.Text.Trim().ToUpper();
        directorycs.ZipPostal = txtPostalZip.Text.Trim().ToUpper();
        directorycs.Comments = txtComments.Text.Trim().ToUpper();

        Session.Add("Directorycs", directorycs);
    }

    private void EnableControls()
    {
        btnEdit.Visible = false;
        BtnExit.Visible = false;
        BtnSave.Visible = true;
        btnCancel.Visible = true;
        btnAdd2.Visible = false;
        btnSearch.Visible = false;
        btnDelete.Visible = false;

        txtFirstName.Enabled = true;
        txtLastname1.Enabled = true;
        txtSalutation.Enabled = true;
        txtTitle.Enabled = true;
        txtAdds1.Enabled = true;
        txtAdds2.Enabled = true;
        txtState.Enabled = true;
        txtZip.Enabled = true;
        TxtPhone1.Enabled = true;
        txtExt.Enabled = true;
        txtPhone2.Enabled = true;
        txtEmail.Enabled = true;
        txtPostalAdds1.Enabled = true;
        txtPostalAdds2.Enabled = true;
        txtPostalState.Enabled = true;
        txtPostalZip.Enabled = true;
        txtComments.Enabled = true;

        ddlSpecialty.Enabled = true;
        ddlCiudad.Enabled = true;
        ddlCiudad3.Enabled = true;
        ddlLocation.Enabled = true;

        lblSpecialty.Visible = false;
        lblCity.Visible = false;
        lblLocation.Visible = false;
        lblFirstName.Visible = false;
        lblLastName.Visible = false;

        ddlSpecialty2.Visible = false;
        ddlCiudad2.Visible = false;
        ddlLocation2.Visible = false;
        TxtSearchFirstName.Visible = false;
        txtSearchLastName.Visible = false;
        searchDirectory.Visible = false;
        LblTotalCases.Visible = false;

    }

    private void DisableControls()
    {
        btnEdit.Visible = true;
        BtnExit.Visible = true;
        BtnSave.Visible = false;
        btnCancel.Visible = false;
        btnAdd2.Visible = true;
        btnSearch.Visible = true;
        btnDelete.Visible = true;

        txtFirstName.Enabled = false;
        txtLastname1.Enabled = false;
        txtSalutation.Enabled = false;
        txtTitle.Enabled = false;
        txtAdds1.Enabled = false;
        txtAdds2.Enabled = false;
        txtState.Enabled = false;
        txtZip.Enabled = false;
        TxtPhone1.Enabled = false;
        txtExt.Enabled = false;
        txtPhone2.Enabled = false;
        txtEmail.Enabled = false;
        txtPostalAdds1.Enabled = false;
        txtPostalAdds2.Enabled = false;
        txtPostalState.Enabled = false;
        txtPostalZip.Enabled = false;
        txtComments.Enabled = false;

        ddlSpecialty.Enabled = false;
        ddlCiudad.Enabled = false;
        ddlCiudad3.Enabled = false;
        ddlLocation.Enabled = false;

        lblSpecialty.Visible = true;
        lblCity.Visible = true;
        lblLocation.Visible = true;
        lblFirstName.Visible = true;
        lblLastName.Visible = true;

        ddlSpecialty2.Visible = true;
        ddlCiudad2.Visible = true;
        ddlLocation2.Visible = true;
        TxtSearchFirstName.Visible = true;
        txtSearchLastName.Visible = true;
        searchDirectory.Visible = true;
        LblTotalCases.Visible = true;
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Directorycs directorycs = (Directorycs)Session["Directorycs"];
        try
        {
            if (directorycs.DirectoryID != 0)
            {
                directorycs.Mode = (int)Directorycs.DirectoryMode.UPDATE;

                Session.Add("Directorycs", directorycs);
                EnableControls();
            }
            else
            {
                throw new Exception("Please select first one detail to modify it.");
            }
        }
        catch (Exception exp)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("" + exp.Message);
            this.litPopUp.Visible = true;
        }
    }
    protected void btnAdd2_Click(object sender, EventArgs e)
    {
        Directorycs directorycs = new Directorycs();
        directorycs.Mode = 1; //Add

        Session["Directorycs"] = directorycs;
        Response.Redirect("Directory.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        int userID = 0;
        userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

        Directorycs directorycs = (Directorycs)Session["Directorycs"];

        if (directorycs.Mode == 1) //ADD
        {
            Session.Clear();
            Response.Redirect("MainMenu.aspx");
        }
        else
        {
            directorycs = Directorycs.GetDirectoryByDirectoryID(directorycs.DirectoryID);
            directorycs.Mode = (int)Directorycs.DirectoryMode.CLEAR;
            Session["Directorycs"] = directorycs;
            FillTextControl();
            DisableControls();
        }
    }
    protected void BtnExit_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("MainMenu.aspx");
    }
    protected void BtnSave_Click(object sender, EventArgs e)
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
            ValidFields();
            FillProperties();
            Directorycs directorycs = (Directorycs)Session["Directorycs"];

            directorycs.SaveDirectory(userID);  //(userID);
            FillTextControl();
            DisableControls();

            if (ddlLocation2.SelectedItem.Value.ToString().Trim() != "")
            {
                FillDataGrid();
            }

            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Information saved successfully.");
            this.litPopUp.Visible = true;
        }
        catch (Exception exp)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Unable to save this Information. " + exp.Message);
            this.litPopUp.Visible = true;
        }
    }

    private void ValidFields()
    {
        //if (this.ddlLocation.SelectedItem.Text.Trim() == "")
        //    throw new Exception("Please select one Customer.");

        //if (this.TxtCustomerPO.Text.Trim() == "")
        //    throw new Exception("Please fill the Customer PO Number.");

        //if (this.TxtPHCPO.Text.Trim() == "")
        //    throw new Exception("Please fill the PHC PO Number.");

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (bool.Parse(ConfirmDialogBoxPopUp.Value.Trim()) == true)
        {
            Directorycs directorycs = (Directorycs)Session["Directorycs"];
            try
            {
                if (directorycs.DirectoryID != 0)
                {
                    int i = directorycs.DirectoryID;
                    Directorycs.DeleteDirectoryByDirectoryID(i);
                    FillDataGrid();

                    directorycs = new Directorycs();
                    directorycs.Mode = 4; //Clear

                    Session["Directorycs"] = directorycs;
                    FillTextControl();
                }
                else
                {
                    throw new Exception("Please select first one order to delete it.");
                }
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= searchDirectory.Items.Count - 1; i++)
        {
            ((CheckBox)searchDirectory.Items[i].Cells[9].FindControl("CheckBox1")).Checked = true;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= searchDirectory.Items.Count - 1; i++)
        {
            ((CheckBox)searchDirectory.Items[i].Cells[9].FindControl("CheckBox1")).Checked = false;
        }
    }

    protected void btnMessages_Click(object sender, EventArgs e)
    {
        this.pnlMessage.Visible = true;
        this.txtMessage.Text = "";
        this.TxtSubject.Text = "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.pnlMessage.Visible = false;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            int recCount = 0;
            for (int i = 0; searchDirectory.Items.Count > i; i++)
            {
                if (((CheckBox)searchDirectory.Items[i].Cells[9].FindControl("CheckBox1")).Checked)
                {
                    recCount++;
                }
            }
            if (recCount > 0)
            {
                SendEmail();
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("The Message has been sent successfuly.");
                this.litPopUp.Visible = true;
            }
            else
            {
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Please choose the email from the list.");
                this.litPopUp.Visible = true;
            }             
        }
        catch (Exception exc)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("" + exc.Message);
            this.litPopUp.Visible = true;
        }
    }

    private string SetMailTo()
    {
        string mailto = "";

        if (Session["DtDirectory"] != null)
        {
            DataTable dt = (DataTable)Session["DtDirectory"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; searchDirectory.Items.Count > i; i++)
                {
                    if (((CheckBox)searchDirectory.Items[i].Cells[9].FindControl("CheckBox1")).Checked)
                    {
                        if (searchDirectory.Items[i].Cells[10].Text.Trim() != "" && searchDirectory.Items[i].Cells[10].Text.Trim() != " ")
                        {
                            mailto = mailto + searchDirectory.Items[i].Cells[10].Text.Trim() + "; "; //dt.Rows[i]["Email"].ToString().Trim() + "; ";
                        }
                    }
                }
            }
        }

        return mailto;
    }

    private void SendEmail()
    {
        string msg = "";
        try
        {
            EPolicy.TaskControl.Mail SM = new EPolicy.TaskControl.Mail();
            SM.MailTo = SetMailTo();//"resolve@prmdic.com; jterrassa@prtc.net; dhanft@prmdic.com; victor@drrecord.com";
           
            SM.MailFrom = "system@prmdic.net";
            SM.MailSubject = TxtSubject.Text.Trim();
            SM.MailBody = "\r\n" + txtMessage.Text.Trim() + " " + "\r\n" + "\r\n" + "\r\n" +

                "Este es un mensaje enviado por el Sistema Automático de mensaje de ePMS." + "\r\n" + "\r\n" + "\r\n" +
            "AVISO DE CONFIDENCIALIDAD: Esta comunicación contiene  informacion  propiedad  de  Puerto Rico Medical Defense Insurance Company." + "\r\n" +
            "clasificada como privilegiada, confidencial y exenta de divulgación. La información es para uso exclusivo del individuo o entidad" + "\r\n" +
            "a quien está dirigida. Si usted no es el destinatario, el empleado o el agente a quien se  le  confió la responsabilidad de hacer" + "\r\n" +
            "llegar el mensaje al destinatario, debe percatarse que la divulgación, copia, distribución o accion tomaba basada en el contenido" + "\r\n" +
            "de esta transmisión está estrictamente prohibida. Si ha recibido esta comunicación por error,  favor de borrarla  y  notificar al" + "\r\n" +
            "remitente inmediatamente.  Cualquier uso indebido  de  la  información contenida  en  este mensaje será sancionado bajo las leyes" + "\r\n" +
            "aplicables." + "\r\n" + "\r\n" +
            "CONFIDENTIALITY NOTE: This communication and any attachments hereto contain information property  of  Puerto Rico Medical Defense" + "\r\n" +
            "Insurance Company, classified as privileged, confidential and exempt from disclosure. The information is intended solely  for the" + "\r\n" +
            "use of the individual  or  entity to which it is addressed.  If you  are  not the intended  recipient  or  the  employee or agent" + "\r\n" +
            "entrusted with the responsibility of delivering the message  to  the intended recipient,  be aware that any disclosure,  copying," + "\r\n" +
            "distribution  or  action taken in based on the contents  of  this transmission  is  strictly  prohibited. If  you  have received" + "\r\n" +
            "this communication by mistake,  please  delete and notify  the  sender  immediately.  Any unauthorized  use  of  the information" + "\r\n" +
            "contained herein will be sanctioned under applicable laws.";

            msg = SM.SendMail();
        }
        catch (Exception exc)
        {
            string a = msg + " " + exc.InnerException.ToString();
        }
    }
}
