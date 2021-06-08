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
using Baldrich.DBRequest;
using EPolicy.XmlCooker;
using System.Xml;
using EPolicy;
using Microsoft.Reporting.WebForms;
using System.ComponentModel;
using System.Web.SessionState;
using System.Data.SqlClient;
using System.Text;

public partial class Directorio : System.Web.UI.Page
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
        Banner = LoadControl(@"TopBanner1.ascx");
        this.Placeholder1.Controls.Add(Banner);

        // //Setup Left-side Banner			
        // Control LeftMenu = new Control();
        // LeftMenu = LoadControl(@"LeftMenu.ascx");
        // phTopBanner1.Controls.Add(LeftMenu);

        //searchDirectory.Columns[9].Visible = false;

        //if (ddlDateType.SelectedValue != "")
        //{
        //    //lblDate.Visible = true;
        //    lblDateFrom.Visible = true;
        //    txtDateFrom.Visible = true;
        //    lblDateTo.Visible = true;
        //    txtDateTo.Visible = true;
        //}
        //else
        //{
        //    //lblDate.Visible = false;
        //    lblDateFrom.Visible = false;
        //    txtDateFrom.Visible = false;
        //    lblDateTo.Visible = false;
        //    txtDateTo.Visible = false;
        //}


        if (Session["AutoPostBack"] == null)
        {
            if (!IsPostBack)
            {
                //Load DownDropList
                DataTable dtCity = EPolicy.LookupTables.LookupTables.GetTable("City");
                DataTable dtPRMEDICSpecialty = EPolicy.LookupTables.LookupTables.GetTable("PRMEDICSpecialty");
                DataTable dtCiudad = EPolicy.LookupTables.LookupTables.GetTable("Ciudad");
                DataTable dtLocationMed = EPolicy.LookupTables.LookupTables.GetTable("LocationMed");
                DataTable dtAgency = EPolicy.LookupTables.LookupTables.GetTable("Agency");
                DataTable dtAgent = EPolicy.LookupTables.LookupTables.GetTable("Agent");
                DataTable dtHospital = EPolicy.LookupTables.LookupTables.GetTable("Hospital");

                //ddlCiudad.DataSource = dtCiudad;
                //ddlCiudad.DataTextField = "Ciudad";
                //ddlCiudad.DataValueField = "ZipCode";
                //ddlCiudad.DataBind();
                //ddlCiudad.SelectedIndex = -1;
                //ddlCiudad.Items.Insert(0, "");

                ddlCiudad2.DataSource = dtCiudad;
                ddlCiudad2.DataTextField = "Ciudad";
                ddlCiudad2.DataValueField = "ZipCode";
                ddlCiudad2.DataBind();
                ddlCiudad2.SelectedIndex = -1;
                ddlCiudad2.Items.Insert(0, "");

                //ddlCiudad3.DataSource = dtCiudad;
                //ddlCiudad3.DataTextField = "Ciudad";
                //ddlCiudad3.DataValueField = "ZipCode";
                //ddlCiudad3.DataBind();
                //ddlCiudad3.SelectedIndex = -1;
                //ddlCiudad3.Items.Insert(0, "");

                //Policy Type
                ddlPolicyType.SelectedIndex = -1;
                ddlPolicyType.Items.Insert(0, "");


                //Date
                ddlDateType.SelectedIndex = -1;
                ddlDateType.Items.Insert(0, "");

                //PRMEDICSpecialty
                ddlSpecialty2.DataSource = dtPRMEDICSpecialty;
                ddlSpecialty2.DataTextField = "PRMEDICSpecialtyDesc";
                ddlSpecialty2.DataValueField = "PRMEDICSpecialtyID";
                ddlSpecialty2.DataBind();
                ddlSpecialty2.SelectedIndex = -1;
                ddlSpecialty2.Items.Insert(0, "");

                //PRMEDICSpecialty - Search
                ddlSpecialty2.DataSource = dtPRMEDICSpecialty;
                ddlSpecialty2.DataTextField = "PRMEDICSpecialtyDesc";
                ddlSpecialty2.DataValueField = "PRMEDICSpecialtyID";
                ddlSpecialty2.DataBind();
                ddlSpecialty2.SelectedIndex = -1;
                ddlSpecialty2.Items.Insert(0, "");

                //Agency
                ddlAgency.DataSource = dtAgency;
                ddlAgency.DataTextField = "AgencyDesc";
                ddlAgency.DataValueField = "AgencyID";
                ddlAgency.DataBind();
                ddlAgency.SelectedIndex = -1;
                ddlAgency.Items.Insert(0, "");

                //Agent
                ddlAgent.DataSource = dtAgent;
                ddlAgent.DataTextField = "AgentDesc";
                ddlAgent.DataValueField = "AgentID";
                ddlAgent.DataBind();
                ddlAgent.SelectedIndex = -1;
                ddlAgent.Items.Insert(0, "");

                //Medical Practice Type
                DataTable dtMedicalPracticeType = new DataTable();
                dtMedicalPracticeType.Clear();
                dtMedicalPracticeType.Columns.Add("MedicalPracticeDesc");

                DataRow dtMedicalPracticeTypeRow = dtMedicalPracticeType.NewRow();
                dtMedicalPracticeTypeRow["MedicalPracticeDesc"] = "SOLO PHYSICIAN";
                dtMedicalPracticeType.Rows.Add(dtMedicalPracticeTypeRow);

                dtMedicalPracticeTypeRow = dtMedicalPracticeType.NewRow();
                dtMedicalPracticeTypeRow["MedicalPracticeDesc"] = "EMPLOYED PHYSICIAN";
                dtMedicalPracticeType.Rows.Add(dtMedicalPracticeTypeRow);

                dtMedicalPracticeTypeRow = dtMedicalPracticeType.NewRow();
                dtMedicalPracticeTypeRow["MedicalPracticeDesc"] = "PARTNERSHIP";
                dtMedicalPracticeType.Rows.Add(dtMedicalPracticeTypeRow);

                dtMedicalPracticeTypeRow = dtMedicalPracticeType.NewRow();
                dtMedicalPracticeTypeRow["MedicalPracticeDesc"] = "GROUP MEMBER";
                dtMedicalPracticeType.Rows.Add(dtMedicalPracticeTypeRow);

                dtMedicalPracticeTypeRow = dtMedicalPracticeType.NewRow();
                dtMedicalPracticeTypeRow["MedicalPracticeDesc"] = "PROFESSIONAL ASSOCIATION";
                dtMedicalPracticeType.Rows.Add(dtMedicalPracticeTypeRow);

                dtMedicalPracticeTypeRow = dtMedicalPracticeType.NewRow();
                dtMedicalPracticeTypeRow["MedicalPracticeDesc"] = "PROFESSIONAL CORPORATION";
                dtMedicalPracticeType.Rows.Add(dtMedicalPracticeTypeRow);

                dtMedicalPracticeTypeRow = dtMedicalPracticeType.NewRow();
                dtMedicalPracticeTypeRow["MedicalPracticeDesc"] = "OTHER";
                dtMedicalPracticeType.Rows.Add(dtMedicalPracticeTypeRow);

                //Medical Practice Type
                //MultipleSelection1.CreateCheckBox(dtMedicalPracticeType, "MedicalPracticeDesc", "MedicalPracticeDesc");
                //MultipleSelection2.CreateCheckBox(dtHospital, "HospitalDesc", "HospitalDesc");

                

                //        if (Session["Directorycs"] != null)
                //        {
                //            Directorycs directorycs = (Directorycs)Session["Directorycs"];

                //            switch (directorycs.Mode)
                //            {
                //                case 1: //ADD
                //                    FillTextControl();
                //                    EnableControls();
                //                    break;

                //                case 2: //UPDATE
                //                    FillTextControl();
                //                    EnableControls();
                //                    break;

                //                default:
                //                    FillTextControl();

                //                    if (ddlCiudad2.SelectedItem.Value.ToString().Trim() != "")
                //                    {
                //                        FillDataGrid();
                //                    }
                //                    DisableControls();
                //                    break;
                //            }
                //        }
                //    }
                //    else
                //    {
                //        if (Session["Directorycs"] != null)
                //        {
                //            Directorycs directorycs = (Directorycs)Session["Directorycs"];
                //            if (directorycs.Mode == 4)
                //            {
                //                DisableControls();
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    FillTextControl();
                //    EnableControls();
                //    Session.Remove("AutoPostBack");
                //}
            }
        }
    }

    #region Private Method
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //pnlCustomerInfo.Visible = false;
        //pnlAdditionalCustInfo.Visible = false;
        //FillDataGrid();
    }

    private void FillDataGrid()
    {
    //    try
    //    {
    //        FieldVerify();
    //    }
    //    catch (Exception exp)
    //    {
    //        this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("" + exp.Message);
    //        this.litPopUp.Visible = true;
    //        return;
    //    }

    //    LblError.Visible = false;
    //    searchDirectory.DataSource = null;
    //    DtDirectory = null;

    //    searchDirectory.CurrentPageIndex = 0;
    //    searchDirectory.Visible = false;

    //    DtDirectory = GetDirectorioByCriteria();
    //    //Directorycs.GetDirectoryByCriteria(ddlCiudad2.SelectedItem.Text.Trim(),
    //    //    ddlLocation2.SelectedItem.Text.ToString().Trim(), ddlSpecialty2.SelectedItem.Text.Trim(),
    //    //    TxtSearchFirstName.Text.Trim(), txtSearchLastName.Text.Trim());

    //    Session.Remove("DtDirectory");
    //    Session.Add("DtDirectory", DtDirectory);

    //    if (DtDirectory.Rows.Count != 0)
    //    {
    //        searchDirectory.Visible = true;

    //        searchDirectory.DataSource = DtDirectory;
    //        searchDirectory.DataBind();
    //        pnlSearchResults.Visible = true;
    //    }
    //    else
    //    {
    //        searchDirectory.DataSource = null;
    //        searchDirectory.DataBind();
    //        pnlSearchResults.Visible = true;

    //        LblError.Visible = true;
    //        LblError.Text = "Could not find a match for your search criteria, please try again.";
    //    }

    //    LblTotalCases.Text = "Total Cases: " + DtDirectory.Rows.Count.ToString();
    }

    private void FieldVerify()
    {
        string errorMessage = String.Empty;
        bool found = false;

        if (ddlDateType.SelectedItem.Value != "")
        {
            if (txtDateTo.Text == "" || txtDateFrom.Text == "")
            {
                errorMessage = "Please enter a date range to search by dates.";
                found = true;
            }
        }

        //throw the exception.
        if (errorMessage != String.Empty)
        {
            throw new Exception(errorMessage);
        }
    }
    #endregion


    //protected void searchDirectory_ItemCommand(object source, DataGridCommandEventArgs e)
    //{
    //    EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
    //    int userID = 0;

    //    try
    //    {
    //        userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(
    //            "Could not parse user id from cp.Identity.Name.", ex);
    //    }

    //    if (e.CommandName == "Select") // Select
    //    {
    //        int i = int.Parse(e.Item.Cells[1].Text);
    //        //Directorycs directorycs = Directorycs.GetDirectoryByDirectoryID(i);
    //        EPolicy.Customer.Customer customer = EPolicy.Customer.Customer.GetCustomer(e.Item.Cells[1].Text, 0);
    //        DataTable dtPolicies = EPolicy.TaskControl.Policy.GetPoliciesByCustomerNo(e.Item.Cells[1].Text);
    //        EPolicy.Customer.Registry registry = EPolicy.Customer.Registry.GetRegistryByCustomerNo(int.Parse(e.Item.Cells[1].Text));

    //        //if (Session["DtDirectory"] != null)
    //        //{
    //        //    if (Session["Directorycs"] == null)
    //        //        Session.Add("Directorycs", directorycs);
    //        //    else
    //        //        Session["Directorycs"] = directorycs;

    //            FillTextControlCustomer(customer);
    //            FillTextControlPolicyGrid(customer);
    //            FillTextControlRegistry(registry);
    //            //DisableControls();
    //    }
    //    else  // Pager
    //    {
    //        searchDirectory.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

    //        searchDirectory.DataSource = (DataTable)Session["DtDirectory"];
    //        searchDirectory.DataBind();
    //    }
    //}

    //private void FillTextControlCustomer(EPolicy.Customer.Customer customer)
    //{
    //    if (customer != null)
    //    {
    //        txtFirstName.Text = customer.FirstName;
    //        txtLastname1.Text = customer.LastName1;
    //        txtLastname2.Text = customer.LastName2;
    //        txtBirthdate.Text = customer.Birthday;
    //        TxtLicence.Text = customer.Licence;
    //        txtHomePhone.Text = customer.HomePhone;
    //        txtWorkPhone.Text = customer.JobPhone;
    //        TxtCellular.Text = customer.Cellular;
    //        txtEmail0.Text = customer.Email;
    //        txtComments.Text = customer.Comments;

    //        txtAdds1.Text = customer.AddressPhysical1;
    //        txtAdds2.Text = customer.AddressPhysical2;
    //        txtCiudad.Text = customer.CityPhysical;
    //        txtState.Text = customer.StatePhysical;
    //        txtZip.Text = customer.ZipPhysical;

    //        txtPostalAdds1.Text = customer.Address1;
    //        txtPostalAdds2.Text = customer.Address2;
    //        txtCiudad3.Text = customer.City;
    //        txtPostalState.Text = customer.State;
    //        txtPostalZip.Text = customer.ZipCode;
    //        pnlCustomerInfo.Visible = true;
    //    }
    //}

    //private void FillTextControlPolicyGrid(EPolicy.Customer.Customer customer)
    //{
    //    LblError.Visible = false;
    //    searchIndividual.DataSource = null;
    //    DataTable DtTask = null;

    //    DtTask = EPolicy.TaskControl.TaskControl.GetTaskControlByCustomerNo(customer.CustomerNo);

    //    Session.Remove("DtTask");
    //    Session.Add("DtTask", DtTask);

    //    if (DtTask.Rows.Count != 0)
    //    {
    //        searchIndividual.DataSource = DtTask;
    //        searchIndividual.DataBind();
    //        pnlAdditionalCustInfo.Visible = true;
    //    }
    //    else
    //    {
    //        searchIndividual.DataSource = null;
    //        searchIndividual.DataBind();
    //        pnlAdditionalCustInfo.Visible = true;

    //        //LblError.Visible = true;
    //        LblError.Text = "Could not find a match for your search criteria, please try again.";
    //    }

    //    LblTotalCasesPolicies.Text = "Total Cases: " + DtTask.Rows.Count.ToString();
        

    //}

    //private void FillTextControlRegistry(EPolicy.Customer.Registry registry)
    //{
    //    txtASSMCADate.Text = registry.ASSMCAExpDate;
    //    txtDEADate.Text = registry.DEAExpDate;
    //    txtTribunalDate.Text = registry.TribunalExpDate;
    //    txtCDMDate.Text = registry.CDMExpDate;
    //    txtGStandingDate.Text = registry.GoodStandingExpDate;
    //    txtLicenseExpDate.Text = registry.LicenseExpDate;
    //    txtMedicalSchool.Text = registry.MedicalSchool;
    //    txtInternship.Text = registry.Internship;
    //    txtResidency.Text = registry.Residency;
    //    txtFellowship.Text = registry.Fellowship;
    //    txtShareholder.Text = registry.ShareholderQty.ToString();
    //    txtShareholderNo.Text = registry.ShareholderNo;

    //    if (registry.MedicalPractice.Contains("Solo Physician"))
    //        chkMedicalPractice.Items[0].Selected = true;
    //    else
    //        chkMedicalPractice.Items[0].Selected = false;

    //    if (registry.MedicalPractice.Contains("Employed Physician"))
    //        chkMedicalPractice.Items[1].Selected = true;
    //    else
    //        chkMedicalPractice.Items[1].Selected = false;

    //    if (registry.MedicalPractice.Contains("Partnership"))
    //        chkMedicalPractice.Items[2].Selected = true;
    //    else
    //        chkMedicalPractice.Items[2].Selected = false;

    //    if (registry.MedicalPractice.Contains("Group Member"))
    //        chkMedicalPractice.Items[3].Selected = true;
    //    else
    //        chkMedicalPractice.Items[3].Selected = false;

    //    if (registry.MedicalPractice.Contains("Professional Association"))
    //        chkMedicalPractice.Items[4].Selected = true;
    //    else
    //        chkMedicalPractice.Items[4].Selected = false;

    //    if (registry.MedicalPractice.Contains("Professional Corporation"))
    //        chkMedicalPractice.Items[5].Selected = true;
    //    else
    //        chkMedicalPractice.Items[5].Selected = false;

    //    string[] line = registry.MedicalPractice.Split('|');
    //    int size = line.Length - 1;

    //    if (line[size] != "Solo Physician" &&
    //        line[size] != "Employed Physician" &&
    //        line[size] != "Partnership" &&
    //        line[size] != "Group Member" &&
    //        line[size] != "Professional Association" &&
    //        line[size] != "Professional Corporation" &&
    //        line[size] != "")
    //    {
    //        chkMedicalPractice.Items[6].Selected = true;
    //        txtOther.Text = line[size];
    //    }
    //    else
    //        chkMedicalPractice.Items[6].Selected = false;

    //    rblPreviousClaims.SelectedIndex = registry.PreviousClaims;
    //    rblBoardCertified.SelectedIndex = registry.BoardCertified;

    //    if (registry.CV)
    //        rblCV.SelectedIndex = 1;
    //    else
    //        rblCV.SelectedIndex = 0;

    //    txtPriPolEffecDate.Text = registry.EffectiveDate;
    //    txtPriCarierName.Text = registry.CarrierName;
    //    txtPriClaims.Text = registry.PolicyNo;
    //    txtPriPolLimits.Text = registry.PolicyLimits;

    //    txtComments.Text = registry.Comments;

    //    FillGridRegistry(registry);
    //}

    //private void FillTextControl()
    //{
    //    Directorycs directorycs = (Directorycs)Session["Directorycs"];

    //    //Specialty
    //    ddlSpecialty2.SelectedIndex = 0;
    //    if (directorycs.Specialty != 0)
    //    {
    //        for (int i = 0; ddlSpecialty2.Items.Count - 1 >= i; i++)
    //        {
    //            if (ddlSpecialty2.Items[i].Value == directorycs.Specialty.ToString())
    //            {
    //                ddlSpecialty2.SelectedIndex = i;
    //                i = ddlSpecialty2.Items.Count - 1;
    //            }
    //        }
    //    }

    //    //ddlCiudad.SelectedIndex = 0;
    //    //if (directorycs.City != "")
    //    //{
    //    //    for (int i = 0; ddlCiudad.Items.Count - 1 >= i; i++)
    //    //    {
    //    //        if (ddlCiudad.Items[i].Text.Trim() == directorycs.City.ToString().Trim())
    //    //        {
    //    //            ddlCiudad.SelectedIndex = i;
    //    //            i = ddlCiudad.Items.Count - 1;
    //    //        }
    //    //    }
    //    //}

    //    //ddlCiudad3.SelectedIndex = 0;
    //    //if (directorycs.CityPostal != "")
    //    //{
    //    //    for (int i = 0; ddlCiudad3.Items.Count - 1 >= i; i++)
    //    //    {
    //    //        if (ddlCiudad3.Items[i].Text.Trim() == directorycs.CityPostal.ToString().Trim())
    //    //        {
    //    //            ddlCiudad3.SelectedIndex = i;
    //    //            i = ddlCiudad3.Items.Count - 1;
    //    //        }
    //    //    }
    //    //}

    //    txtFirstName.Text = directorycs.FirstName.Trim().ToUpper();
    //    txtLastname1.Text = directorycs.LastName.Trim().ToUpper();
    //    //txtSalutation.Text = directorycs.Salutation.Trim().ToUpper();
    //    //txtTitle.Text = directorycs.Title.Trim().ToUpper();
    //    txtAdds1.Text = directorycs.Adds1.Trim().ToUpper();
    //    txtAdds2.Text = directorycs.Adds2.Trim().ToUpper();
    //    txtState.Text = directorycs.State.Trim().ToUpper();
    //    txtZip.Text = directorycs.Zip.Trim().ToUpper();
    //    //TxtPhone1.Text = directorycs.Phone1;
    //    //txtExt.Text = directorycs.Ext1;
    //    //txtPhone2.Text = directorycs.Phone2;
    //    //txtEmail.Text = directorycs.Email.Trim().ToUpper();
    //    txtPostalAdds1.Text = directorycs.Adds1Postal.Trim().ToUpper();
    //    txtPostalAdds2.Text = directorycs.Adds2Postal.Trim().ToUpper();
    //    txtPostalState.Text = directorycs.StatePostal.Trim().ToUpper();
    //    txtPostalZip.Text = directorycs.ZipPostal.Trim().ToUpper();
    //    txtComments.Text = directorycs.Comments.Trim().ToUpper();
    //}

    //private void FillProperties()
    //{
    //    Directorycs directorycs = (Directorycs)Session["Directorycs"];

    //    //Ciudad
    //    if (ddlCiudad.SelectedIndex > 0 && ddlCiudad.SelectedItem != null)
    //        directorycs.City = ddlCiudad.SelectedItem.Text;
    //    else
    //        directorycs.City = "";

    //    //Ciudad
    //    if (ddlCiudad3.SelectedIndex > 0 && ddlCiudad3.SelectedItem != null)
    //        directorycs.CityPostal = ddlCiudad3.SelectedItem.Text;
    //    else
    //        directorycs.CityPostal = "";

    //    //if (ddlLocation.SelectedIndex > 0 && ddlLocation.SelectedItem != null)
    //    //    directorycs.LocationID = int.Parse(ddlLocation.SelectedItem.Value.ToString());
    //    //else
    //    //    directorycs.LocationID = 0;

    //    ////Specialty
    //    //if (ddlSpecialty.SelectedIndex > 0 && ddlSpecialty.SelectedItem != null)
    //    //    directorycs.Specialty = int.Parse(ddlSpecialty.SelectedItem.Value);
    //    //else
    //    //    directorycs.Specialty = 0;

    //    directorycs.FirstName = txtFirstName.Text.Trim().ToUpper();
    //    directorycs.LastName = txtLastname1.Text.Trim().ToUpper();
    //    //directorycs.Salutation = txtSalutation.Text.Trim().ToUpper();
    //    //directorycs.Title = txtTitle.Text.Trim().ToUpper();
    //    directorycs.Adds1 = txtAdds1.Text.Trim().ToUpper();
    //    directorycs.Adds2 = txtAdds2.Text.Trim().ToUpper();
    //    directorycs.State = txtState.Text.Trim().ToUpper();
    //    directorycs.Zip = txtZip.Text.Trim().ToUpper();
    //    //directorycs.Phone1 = TxtPhone1.Text.Trim().ToUpper();
    //    //directorycs.Ext1 = txtExt.Text.Trim().ToUpper();
    //    //directorycs.Phone2 = txtPhone2.Text.Trim().ToUpper();
    //    //directorycs.Email = txtEmail.Text.Trim().ToUpper();
    //    directorycs.Adds1Postal = txtPostalAdds1.Text.Trim().ToUpper();
    //    directorycs.Adds2Postal = txtPostalAdds2.Text.Trim().ToUpper();
    //    directorycs.StatePostal = txtPostalState.Text.Trim().ToUpper();
    //    directorycs.ZipPostal = txtPostalZip.Text.Trim().ToUpper();
    //    directorycs.Comments = txtComments.Text.Trim().ToUpper();

    //    Session.Add("Directorycs", directorycs);
    //}

    //private void EnableControls()
    //{
    //    btnEdit.Visible = false;
    //    BtnExit.Visible = false;
    //    BtnSave.Visible = true;
    //    btnCancel.Visible = true;
    //    btnAdd2.Visible = false;
    //    btnSearch.Visible = false;
    //    btnDelete.Visible = false;

    //    txtFirstName.Enabled = true;
    //    txtLastname1.Enabled = true;
    //    //txtSalutation.Enabled = true;
    //    //txtTitle.Enabled = true;
    //    txtAdds1.Enabled = true;
    //    txtAdds2.Enabled = true;
    //    txtState.Enabled = true;
    //    txtZip.Enabled = true;
    //    //TxtPhone1.Enabled = true;
    //    //txtExt.Enabled = true;
    //    //txtPhone2.Enabled = true;
    //    //txtEmail.Enabled = true;
    //    txtPostalAdds1.Enabled = true;
    //    txtPostalAdds2.Enabled = true;
    //    txtPostalState.Enabled = true;
    //    txtPostalZip.Enabled = true;
    //    txtComments.Enabled = true;

    //    //ddlSpecialty.Enabled = true;
    //    ddlCiudad.Enabled = true;
    //    ddlCiudad3.Enabled = true;
    //    //ddlLocation.Enabled = true;

    //    lblSpecialty.Visible = false;
    //    lblCity.Visible = false;
    //    //lblLocation.Visible = false;
    //    lblFirstName.Visible = false;
    //    lblLastName.Visible = false;

    //    ddlSpecialty2.Visible = false;
    //    ddlCiudad2.Visible = false;
    //    //ddlLocation2.Visible = false;
    //    TxtSearchFirstName.Visible = false;
    //    txtSearchLastName.Visible = false;
    //    searchDirectory.Visible = false;
    //    LblTotalCases.Visible = false;

    //}

    //private void DisableControls()
    //{
    //    btnEdit.Visible = true;
    //    BtnExit.Visible = true;
    //    BtnSave.Visible = false;
    //    btnCancel.Visible = false;
    //    btnAdd2.Visible = true;
    //    btnSearch.Visible = true;
    //    btnDelete.Visible = true;

    //    txtFirstName.Enabled = false;
    //    txtLastname1.Enabled = false;
    //    //txtSalutation.Enabled = false;
    //    //txtTitle.Enabled = false;
    //    txtAdds1.Enabled = false;
    //    txtAdds2.Enabled = false;
    //    txtState.Enabled = false;
    //    txtZip.Enabled = false;
    //    //TxtPhone1.Enabled = false;
    //    //txtExt.Enabled = false;
    //    //txtPhone2.Enabled = false;
    //    //txtEmail.Enabled = false;
    //    txtPostalAdds1.Enabled = false;
    //    txtPostalAdds2.Enabled = false;
    //    txtPostalState.Enabled = false;
    //    txtPostalZip.Enabled = false;
    //    txtComments.Enabled = false;

    //    //ddlSpecialty.Enabled = false;
    //    ddlCiudad.Enabled = false;
    //    ddlCiudad3.Enabled = false;
    //    //ddlLocation.Enabled = false;

    //    lblSpecialty.Visible = true;
    //    lblCity.Visible = true;
    //    //lblLocation.Visible = true;
    //    lblFirstName.Visible = true;
    //    lblLastName.Visible = true;

    //    ddlSpecialty2.Visible = true;
    //    ddlCiudad2.Visible = true;
    //    //ddlLocation2.Visible = true;
    //    TxtSearchFirstName.Visible = true;
    //    txtSearchLastName.Visible = true;
    //    searchDirectory.Visible = true;
    //    LblTotalCases.Visible = true;
    //}

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        //Directorycs directorycs = (Directorycs)Session["Directorycs"];
        //try
        //{
        //    if (directorycs.DirectoryID != 0)
        //    {
        //        directorycs.Mode = (int)Directorycs.DirectoryMode.UPDATE;

        //        Session.Add("Directorycs", directorycs);
        //        EnableControls();
        //    }
        //    else
        //    {
        //        throw new Exception("Please select first one detail to modify it.");
        //    }
        //}
        //catch (Exception exp)
        //{
        //    this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("" + exp.Message);
        //    this.litPopUp.Visible = true;
        //}
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
        //EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        //int userID = 0;
        //userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

        //Directorycs directorycs = (Directorycs)Session["Directorycs"];

        //if (directorycs.Mode == 1) //ADD
        //{
            Session.Clear();
            Response.Redirect("MainMenu.aspx");
        //}
        //else
        //{
        //    directorycs = Directorycs.GetDirectoryByDirectoryID(directorycs.DirectoryID);
        //    directorycs.Mode = (int)Directorycs.DirectoryMode.CLEAR;
        //    Session["Directorycs"] = directorycs;
        //    FillTextControl();
        //    DisableControls();
        //}
    }
    protected void BtnExit_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("MainMenu.aspx");
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        //EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        //int userID = 0;

        //try
        //{
        //    userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
        //}
        //catch (Exception ex)
        //{
        //    throw new Exception(
        //        "Could not parse user id from cp.Identity.Name.", ex);
        //}

        //try
        //{
        //    ValidFields();
        //    FillProperties();
        //    Directorycs directorycs = (Directorycs)Session["Directorycs"];

        //    directorycs.SaveDirectory(userID);  //(userID);
        //    FillTextControl();
        //    DisableControls();

        //    //if (ddlLocation2.SelectedItem.Value.ToString().Trim() != "")
        //    //{
        //    //    FillDataGrid();
        //    //}

        //    this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Information saved successfully.");
        //    this.litPopUp.Visible = true;
        //}
        //catch (Exception exp)
        //{
        //    this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Unable to save this Information. " + exp.Message);
        //    this.litPopUp.Visible = true;
        //}
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
                    //FillTextControl();
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
        //for (int i = 0; i <= searchDirectory.Items.Count - 1; i++)
        //{
        //    ((CheckBox)searchDirectory.Items[i].Cells[9].FindControl("CheckBox1")).Checked = true;
        //}
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //for (int i = 0; i <= searchDirectory.Items.Count - 1; i++)
        //{
        //    ((CheckBox)searchDirectory.Items[i].Cells[9].FindControl("CheckBox1")).Checked = false;
        //}
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    int recCount = 0;
        //    for (int i = 0; searchDirectory.Items.Count > i; i++)
        //    {
        //        if (((CheckBox)searchDirectory.Items[i].Cells[9].FindControl("CheckBox1")).Checked)
        //        {
        //            recCount++;
        //        }
        //    }
        //    if (recCount > 0)
        //    {
        //        SendEmail();
        //        this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("The Message has been sent successfuly.");
        //        this.litPopUp.Visible = true;
        //    }
        //    else
        //    {
        //        this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Please choose the email from the list.");
        //        this.litPopUp.Visible = true;
        //    }
        //}
        //catch (Exception exc)
        //{
        //    this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("" + exc.Message);
        //    this.litPopUp.Visible = true;
        //}
    }

    private string SetMailTo()
    {
        string mailto = "";

        //if (Session["DtDirectory"] != null)
        //{
        //    DataTable dt = (DataTable)Session["DtDirectory"];
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; searchDirectory.Items.Count > i; i++)
        //        {
        //            if (((CheckBox)searchDirectory.Items[i].Cells[9].FindControl("CheckBox1")).Checked)
        //            {
        //                if (searchDirectory.Items[i].Cells[10].Text.Trim() != "" && searchDirectory.Items[i].Cells[10].Text.Trim() != " ")
        //                {
        //                    mailto = mailto + searchDirectory.Items[i].Cells[10].Text.Trim() + "; "; //dt.Rows[i]["Email"].ToString().Trim() + "; ";
        //                }
        //            }
        //        }
        //    }
        //}

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
            //SM.MailSubject = TxtSubject.Text.Trim();
            //SM.MailBody = "\r\n" + txtMessage.Text.Trim() + " " + "\r\n" + "\r\n" + "\r\n" +

            //    "Este es un mensaje enviado por el Sistema Automático de mensaje de ePMS." + "\r\n" + "\r\n" + "\r\n" +
            //"AVISO DE CONFIDENCIALIDAD: Esta comunicación contiene  informacion  propiedad  de  Puerto Rico Medical Defense Insurance Company." + "\r\n" +
            //"clasificada como privilegiada, confidencial y exenta de divulgación. La información es para uso exclusivo del individuo o entidad" + "\r\n" +
            //"a quien está dirigida. Si usted no es el destinatario, el empleado o el agente a quien se  le  confió la responsabilidad de hacer" + "\r\n" +
            //"llegar el mensaje al destinatario, debe percatarse que la divulgación, copia, distribución o accion tomaba basada en el contenido" + "\r\n" +
            //"de esta transmisión está estrictamente prohibida. Si ha recibido esta comunicación por error,  favor de borrarla  y  notificar al" + "\r\n" +
            //"remitente inmediatamente.  Cualquier uso indebido  de  la  información contenida  en  este mensaje será sancionado bajo las leyes" + "\r\n" +
            //"aplicables." + "\r\n" + "\r\n" +
            //"CONFIDENTIALITY NOTE: This communication and any attachments hereto contain information property  of  Puerto Rico Medical Defense" + "\r\n" +
            //"Insurance Company, classified as privileged, confidential and exempt from disclosure. The information is intended solely  for the" + "\r\n" +
            //"use of the individual  or  entity to which it is addressed.  If you  are  not the intended  recipient  or  the  employee or agent" + "\r\n" +
            //"entrusted with the responsibility of delivering the message  to  the intended recipient,  be aware that any disclosure,  copying," + "\r\n" +
            //"distribution  or  action taken in based on the contents  of  this transmission  is  strictly  prohibited. If  you  have received" + "\r\n" +
            //"this communication by mistake,  please  delete and notify  the  sender  immediately.  Any unauthorized  use  of  the information" + "\r\n" +
            //"contained herein will be sanctioned under applicable laws.";

            msg = SM.SendMail();
        }
        catch (Exception exc)
        {
            string a = msg + " " + exc.InnerException.ToString();
        }
    }
    protected void ddlDateType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDateType.SelectedValue != "")
        {
            //lblDate.Visible = true;
            lblDateFrom.Visible = true;
            txtDateFrom.Visible = true;
            lblDateTo.Visible = true;
            txtDateTo.Visible = true;
        }
        else
        {
            //lblDate.Visible = false;
            lblDateFrom.Visible = false;
            txtDateFrom.Visible = false;
            lblDateTo.Visible = false;
            txtDateTo.Visible = false;
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("Directorio.aspx");
    }

    protected void searchIndividual_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        //EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        //int userID = 0;

        //try
        //{
        //    userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
        //}
        //catch (Exception ex)
        //{
        //    throw new Exception(
        //        "Could not parse user id from cp.Identity.Name.", ex);
        //}

        //if (e.Item.ItemType.ToString() != "Pager") // Select
        //{
        //    int i = int.Parse(e.Item.Cells[1].Text);
        //    EPolicy.TaskControl.TaskControl taskControl =
        //        EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(i, userID);

        //    DataTable dtFilter = (DataTable)Session["DtTask"];

        //    DataTable dt = dtFilter.Clone();

        //    DataRow[] dr = dtFilter.Select("TaskControlTypeID = " + taskControl.TaskControlTypeID, "TaskControlID");

        //    for (int rec = 0; rec <= dr.Length - 1; rec++)
        //    {
        //        DataRow myRow = dt.NewRow();
        //        myRow["TaskControlID"] = (int)dr[rec].ItemArray[0];
        //        myRow["TaskControlTypeID"] = (int)dr[rec].ItemArray[7];

        //        dt.Rows.Add(myRow);
        //        dt.AcceptChanges();
        //    }

        //    taskControl.NavegationTaskControlTable = dt;

        //    string ToPage;

        //    if (Session["ToPage"] == null)
        //    {
        //        if (taskControl.TaskControlTypeID == 4)
        //        {
        //            ToPage = "ExpressAutoQuote.aspx";
        //        }
        //        else
        //        {
        //            ToPage = taskControl.GetType().Name.Trim() + ".aspx";
        //        }
        //    }
        //    else
        //    {
        //        ToPage = Session["ToPage"].ToString();
        //    }

        //    if (Session["TaskControl"] == null)
        //        Session.Add("TaskControl", taskControl);
        //    else
        //        Session["TaskControl"] = taskControl;

        //    Session.Remove("DtTaskControl");

        //    Response.Redirect(ToPage + "?" + taskControl.TaskControlID);
        //}
        //else  // Pager
        //{
        //    searchIndividual.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

        //    searchIndividual.DataSource = (DataTable)Session["DtTask"];
        //    searchIndividual.DataBind();
        //}
    }
    protected void FillGridRegistry(EPolicy.Customer.Registry registry)
    {
        //DataTable dt = new DataTable();
        //DataTable dtPrivileges = GetPrivileges(registry.RegistryID);

        //if (dtPrivileges.Rows.Count != 0)
        //{
        //    dtGridCertificateLocations0.Visible = true;

        //    dt.Columns.Add("PrivilegeID");
        //    dt.Columns.Add("Hospital");

        //    for (int i = 0; i < dtPrivileges.Rows.Count; i++)
        //    {
        //        dt.Rows.Add();
        //        dt.Rows[i]["PrivilegeID"] = dtPrivileges.Rows[i]["PrivilegeID"];
        //    }

        //    this.dtGridCertificateLocations0.DataSource = dt;
        //    this.dtGridCertificateLocations0.DataBind();

        //    for (int i = 0; i < dtPrivileges.Rows.Count; i++)
        //    {
        //        ((DropDownList)dtGridCertificateLocations0.Items[i].Cells[1].FindControl("ddlCertificateLocation")).SelectedIndex =
        //        ((DropDownList)dtGridCertificateLocations0.Items[i].Cells[1].FindControl("ddlCertificateLocation")).Items.IndexOf
        //        (((DropDownList)dtGridCertificateLocations0.Items[i].Cells[1].FindControl("ddlCertificateLocation")).Items.FindByValue
        //        (dtPrivileges.Rows[i]["HospitalID"].ToString()));
        //    }

        //}
        //else
        //{
        //    dtGridCertificateLocations0.Visible = false;
        //}
        //LblTotalCasesPrivileges.Text = "Total Cases: " + dtGridCertificateLocations0.Items.Count.ToString();

        ////if (dtPrivileges.Rows.Count > 0)
        ////    dtGridCertificateLocations.Visible = true;
        ////else
        ////    dtGridCertificateLocations.Visible = false;

    }

    private DataTable GetPrivileges(int registryID)
    {
        EPolicy.Customer.Registry registry = new EPolicy.Customer.Registry();
        return registry.GetPrivileges(registryID);
    }

    public DataTable GetDirectorioByCriteria()
    {
        DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[13];

        DbRequestXmlCooker.AttachCookItem("CustomerNo",
            SqlDbType.Char, 10, TxtCustomerNo.Text.ToString(),
            ref cookItems);
        DbRequestXmlCooker.AttachCookItem("FirstNa",
            SqlDbType.VarChar, 50, TxtSearchFirstName.Text.ToString(),
            ref cookItems);
        DbRequestXmlCooker.AttachCookItem("LastNa",
            SqlDbType.VarChar, 50, txtSearchLastName.Text.ToString(),
            ref cookItems);
        DbRequestXmlCooker.AttachCookItem("PolicyType",
            SqlDbType.Char, 3, ddlPolicyType.SelectedItem.Value.ToString(),
            ref cookItems);
        DbRequestXmlCooker.AttachCookItem("City",
            SqlDbType.Char, 14, ddlCiudad2.SelectedItem.Value.ToString(),
            ref cookItems);
        DbRequestXmlCooker.AttachCookItem("PRMDICSpecialtyID",
            SqlDbType.Char, 3, ddlSpecialty2.SelectedItem.Value.ToString(),
            ref cookItems);
        DbRequestXmlCooker.AttachCookItem("Agent",
            SqlDbType.Char, 3, ddlAgent.SelectedItem.Value.ToString(),
            ref cookItems);
        DbRequestXmlCooker.AttachCookItem("Agency",
            SqlDbType.Char, 3, ddlAgency.SelectedItem.Value.ToString(),
            ref cookItems);
        DbRequestXmlCooker.AttachCookItem("Status",
            SqlDbType.Char, 1, (rblInForce.SelectedItem.Value == "2" ? "":rblInForce.SelectedItem.Value).ToString(),
            ref cookItems);
        DbRequestXmlCooker.AttachCookItem("BoardCertified",
            SqlDbType.Char, 1, (rblBoardCert.SelectedItem.Value == "2" ? "" : rblBoardCert.SelectedItem.Value).ToString(),
            ref cookItems);
        DbRequestXmlCooker.AttachCookItem("DateType",
            SqlDbType.Char, 1, ddlDateType.SelectedItem.Value.ToString(),
            ref cookItems);
        DbRequestXmlCooker.AttachCookItem("DateFrom",
            SqlDbType.VarChar, 14, txtDateFrom.Text.ToString(),
            ref cookItems);
        DbRequestXmlCooker.AttachCookItem("DateTo",
            SqlDbType.VarChar, 14, txtDateTo.Text.ToString(),
            ref cookItems);

        Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
        XmlDocument xmlDoc;

        try
        {
            xmlDoc = DbRequestXmlCooker.Cook(cookItems);
        }
        catch (Exception ex)
        {
            throw new Exception("Could not cook items.", ex);
        }
        
        DataTable dt = exec.GetQuery("GetDirectorioReportByCriteria", xmlDoc);
        
        return dt;
    }

    protected DataTable ExecuteDirectorioReportByCriteria()
    {
        #region Trash
        //    DataTable dt = null;

    //    using (SqlConnection con = new SqlConnection("user id=prmdic;password=hLcoG28V;data source=sql2k5.prmdic.net;initial catalog=prmdic;"))
    //    {
    //using (SqlCommand cmd = new SqlCommand("GetDirectorioReportByCriteria", con)) {
    //  cmd.CommandType = CommandType.StoredProcedure;

    //  cmd.Parameters.Add("@CustomerNo", SqlDbType.VarChar).Value = TxtCustomerNo.Text.ToString();
    //  cmd.Parameters.Add("@FirstNa", SqlDbType.VarChar).Value = TxtSearchFirstName.Text.ToString();
    //  cmd.Parameters.Add("@LastNa", SqlDbType.VarChar).Value = txtSearchLastName.Text.ToString();
    //  cmd.Parameters.Add("@PolicyType", SqlDbType.VarChar).Value = ddlPolicyType.SelectedItem.Value.ToString();
    //  cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = ddlCiudad2.SelectedItem.Value.ToString();
    //  cmd.Parameters.Add("@PRMDICSpecialtyID", SqlDbType.VarChar).Value = ddlSpecialty2.SelectedItem.Value.ToString();
    //  cmd.Parameters.Add("@Agent", SqlDbType.VarChar).Value = ddlAgent.SelectedItem.Value.ToString();
    //  cmd.Parameters.Add("@Agency", SqlDbType.VarChar).Value = ddlAgency.SelectedItem.Value.ToString();
    //  cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = (rblInForce.SelectedItem.Value == "2" ? "":rblInForce.SelectedItem.Value).ToString();
    //  cmd.Parameters.Add("@BoardCertified", SqlDbType.VarChar).Value = (rblBoardCert.SelectedItem.Value == "2" ? "" : rblBoardCert.SelectedItem.Value).ToString();
    //  cmd.Parameters.Add("@DateType", SqlDbType.VarChar).Value = ddlDateType.SelectedItem.Value.ToString();
    //  cmd.Parameters.Add("@DateFrom", SqlDbType.VarChar).Value = txtDateFrom.Text.ToString();
    //  cmd.Parameters.Add("@DateTo", SqlDbType.VarChar).Value = txtDateTo.Text.ToString();

    //  con.Open();
    //  cmd.CommandTimeout = 0;
    //  cmd.ExecuteNonQuery();
    //        }
        //    }
        #endregion

        var connString = System.Configuration.ConfigurationManager.ConnectionStrings["PRMDICConnectionString"];//"data source=DESKTOP-L3NRH5E;initial catalog=prmdic;Integrated Security=True;";
        //string connString = "user id=prmdic;password=hLcoG28V;data source=sql2k5.prmdic.net;connect timeout=0;initial catalog=prmdic;";
         string sql = "GetDirectorioReportByCriteria";

        DataTable dt = null;

        using (SqlConnection conn = new SqlConnection(connString.ToString()))
        {
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = new SqlCommand(sql, conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@CustomerNo", SqlDbType.VarChar).Value = TxtCustomerNo.Text.ToString();
                    da.SelectCommand.Parameters.Add("@FirstNa", SqlDbType.VarChar).Value = TxtSearchFirstName.Text.ToString();
                    da.SelectCommand.Parameters.Add("@LastNa", SqlDbType.VarChar).Value = txtSearchLastName.Text.ToString();
                    da.SelectCommand.Parameters.Add("@PolicyType", SqlDbType.VarChar).Value = ddlPolicyType.SelectedItem.Value.ToString();
                    da.SelectCommand.Parameters.Add("@City", SqlDbType.VarChar).Value = ddlCiudad2.SelectedItem.Value.ToString();
                    da.SelectCommand.Parameters.Add("@PRMDICSpecialtyID", SqlDbType.VarChar).Value = ddlSpecialty2.SelectedItem.Value.ToString();
                    da.SelectCommand.Parameters.Add("@Agent", SqlDbType.VarChar).Value = ddlAgent.SelectedItem.Value.ToString();
                    da.SelectCommand.Parameters.Add("@Agency", SqlDbType.VarChar).Value = ddlAgency.SelectedItem.Value.ToString();
                    da.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = (rblInForce.SelectedItem.Value == "2" ? "" : rblInForce.SelectedItem.Value).ToString();
                    da.SelectCommand.Parameters.Add("@BoardCertified", SqlDbType.VarChar).Value = (rblBoardCert.SelectedItem.Value == "2" ? "" : rblBoardCert.SelectedItem.Value).ToString();
                    da.SelectCommand.Parameters.Add("@DateType", SqlDbType.VarChar).Value = ddlDateType.SelectedItem.Value.ToString();
                    da.SelectCommand.Parameters.Add("@DateFrom", SqlDbType.VarChar).Value = txtDateFrom.Text.ToString();
                    da.SelectCommand.Parameters.Add("@DateTo", SqlDbType.VarChar).Value = txtDateTo.Text.ToString();

                    

                    da.SelectCommand.CommandTimeout = 0;

                    DataSet ds = new DataSet();
                    da.Fill(ds, "result_name");

                    dt = ds.Tables["result_name"];

                    foreach (DataRow row in dt.Rows)
                    {
                        //manipulate your data
                    }
                }
            }

             
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
            return dt;
        }
    }

    protected void dtGridCertificateLocations_ItemCommand(object source, DataGridCommandEventArgs e)
    {

    }

    protected void cmdSelect_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < lbxAvailable.Items.Count; i++)
        {
            if (lbxAvailable.Items[i].Selected)
            {
                ListItem list = new ListItem(lbxAvailable.Items[i].Text, lbxAvailable.Items[i].Value);
                lbxSelected.Items.Add(list);
                lbxAvailable.Items.Remove(lbxAvailable.Items[i]);
            }
        }
    }
    protected void cmdRemove_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < lbxSelected.Items.Count; i++)
        {
            if (lbxSelected.Items[i].Selected)
            {
                ListItem list = new ListItem(lbxSelected.Items[i].Text, lbxSelected.Items[i].Value);
                lbxAvailable.Items.Add(list);
                lbxSelected.Items.Remove(lbxSelected.Items[i]);
            }
        }	
    }
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            if (lbxSelected.Items.Count <= 0)
                throw new Exception("Please select select one or multiple columns before printing.");

            int c = 0;
            DataTable dt = new DataTable();
            //DtDirectory = GetDirectorioByCriteria();
            DtDirectory = ExecuteDirectorioReportByCriteria();
            dt.Clear();

            for (int i = 0; i < 160/*lbxSelected.Items.Count*/; i++)
                dt.Columns.Add("Col" + (i +1).ToString());

            DataRow dtRow = dt.NewRow();

            for (int i = 0; i < 160/*lbxSelected.Items.Count*/; i++)
            {
                if (i < lbxSelected.Items.Count)
                    dtRow["Col" + (i + 1).ToString()] = lbxSelected.Items[i].Text;
                else
                    dtRow["Col" + (i + 1).ToString()] = "?";
            }

            dt.Rows.Add(dtRow);

            for (int i = 0; i < DtDirectory.Rows.Count; i++)
            {
                dtRow = dt.NewRow();
                c = 0;
                for (int n = 0; n < 160 /*DtDirectory.Columns.Count*/; n++)
                {
                    if (c < lbxSelected.Items.Count)
                    {
                        if (lbxSelected.Items[c].Value == DtDirectory.Columns[n].ColumnName)
                        {
                            int x = 0;
                            if (DtDirectory.Columns[n].ColumnName == "SpecialityLabLimit1")
                                x = 1;
                                
                            dtRow["Col" + (c + 1).ToString()] = DtDirectory.Rows[i][n].ToString();
                            c++;
                            n = -1;
                        }
                    }
                }

                for (int l = c; l < 160 /*DtDirectory.Columns.Count*/; l++) //PRBLEMA AQUO
                    dtRow["Col" + (l + 1).ToString()] = "?";

                dt.Rows.Add(dtRow);
            }

            Session.Add("Directory", dt);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('DirectoryRDLC.aspx','Reports','addressbar=no,status=1,menubar=0,scrollbars=0,resizable=0,copyhistory=no,width=1520,height=640');", true);
        }
        catch (Exception exp)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("" + exp.Message);
            this.litPopUp.Visible = true;
        }

    }
    protected void cmdSelectAll_Click(object sender, EventArgs e)
    {
        int items = lbxAvailable.Items.Count;

        for (int i = 0; i < items; i++)
        {
            ListItem list = new ListItem(lbxAvailable.Items[0].Text, lbxAvailable.Items[0].Value);
            lbxSelected.Items.Add(list);
            lbxAvailable.Items.Remove(lbxAvailable.Items[0]);
        }
    }
    protected void cmdRemoveAll_Click(object sender, EventArgs e)
    {
        int items = lbxSelected.Items.Count;

        for (int i = 0; i < items; i++)
        {
            ListItem list = new ListItem(lbxSelected.Items[0].Text, lbxSelected.Items[0].Value);
            lbxAvailable.Items.Add(list);
            lbxSelected.Items.Remove(lbxSelected.Items[0]);
        }	
    }
    protected void lbxAvailable_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    //GOML J.NIEVES GLHFb
    protected void BtnExport_Click(object sender, EventArgs e)
    {

        string FileName = "Directorio" + " " + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Year.ToString() + ".csv";

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
        Response.Charset = "";
        Response.ContentType = "application/text";
        StringBuilder sBuilder = new System.Text.StringBuilder();

        DataTable DtDirectory = ExecuteDirectorioReportByCriteria();

        for (int i = 0; i < lbxSelected.Items.Count; i++)
        {
            sBuilder.Append(lbxSelected.Items[i].Text.ToString().Replace("\r\n","").Replace(",","") + ',');
        }

        sBuilder.Append("\r\n");

        int SelectedItem = 0;
        int CurrentRow = 0;
        for (int i = 0; i < DtDirectory.Rows.Count; i++)
        {
            for (int x = 0; x < lbxSelected.Items.Count; x++)
            {
                sBuilder.Append(DtDirectory.Rows[i][lbxSelected.Items[x].Value.ToString().Trim()].ToString().Trim().Replace("\r\n", "").Replace(",", "") + ",");
            }
            sBuilder.Append("\r\n");
        }
        #region JIC
        //for (int i = 0; i < DtDirectory.Rows.Count; i++)
        //{
        //    if (SelectedItem != lbxSelected.Items.Count && CurrentRow != DtDirectory.Rows.Count)
        //    {
        //        sBuilder.Append(DtDirectory.Rows[CurrentRow][lbxSelected.Items[SelectedItem].Value.ToString().Trim()].ToString().Trim().Replace("\r\n", "").Replace(",", "") + ",");
        //        SelectedItem++;
        //    }
        //    else if (CurrentRow == DtDirectory.Rows.Count)
        //    {
        //        break;
        //    }
        //    else
        //    {
        //        CurrentRow++;
        //        SelectedItem = 0;
        //        i = -1;
        //        sBuilder.Append("\r\n");
        //    }
        //}
        #endregion JIC
        Response.Output.Write(sBuilder.ToString());
        Response.Flush();
        Response.End();


    }
}
