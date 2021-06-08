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
using EPolicy.Customer;
using Baldrich.DBRequest;
using EPolicy.XmlCooker;
using System.Xml;
using System.Windows.Forms;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace EPolicy
{
    public partial class Registry : System.Web.UI.Page
    {
        override protected void OnInit(EventArgs e)
        {
            try
            {
                //
                // CODEGEN: This call is required by the ASP.NET Web Form Designer.
                //
                base.OnInit(e);

                System.Web.UI.Control Banner = new System.Web.UI.Control();
                Banner = LoadControl(@"TopBanner.ascx");
                this.Placeholder1.Controls.Add(Banner);

                //Setup Left-side Banner			
                System.Web.UI.Control LeftMenu = new System.Web.UI.Control();
                LeftMenu = LoadControl(@"LeftMenu.ascx");
                phTopBanner1.Controls.Add(LeftMenu);

                }
            catch (Exception exp)
            {
                //if (exp.InnerException == null)
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
                //else if (exp.InnerException.InnerException == null)
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
                //else
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                //         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }

        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            try
            {

                this.litPopUp.Visible = false;

                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = cp.UserID;
                if (cp == null)
                {
                    Response.Redirect("Default.aspx?001");
                }

                if (Session["AutoPostBack"] == null)
                {
                    if (!IsPostBack)
                    {
                        if (Session["TaskControl"] != null)
                        {

                            TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
                            Customer.Registry registry = Customer.Registry.GetRegistryByCustomerNo(int.Parse(taskControl.CustomerNo));
                            Session["Registry"] = registry;

                            this.SetReferringPage();

                            switch (registry.Mode)
                            {
                                case 1: //ADD
                                    DisableControls();
                                    FillTextControl();
                                    break;

                                case 2: //UPDATE
                                    FillTextControl();
                                    EnableControls();
                                    break;

                                default:
                                    FillTextControl();
                                    DisableControls();                                   
                                    break;
                            }
                        }
                        VerifyAccess();
                    }
                }
                else
                {
                    Session.Remove("AutoPostBack");
                }
            }
            catch (Exception exp)
            {
                if (exp.InnerException == null)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
                else if (exp.InnerException.InnerException == null)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
                else
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

                this.litPopUp.Visible = true;
            }
        }

        private void VerifyAccess()
        {
            EPolicy.TaskControl.Policy taskControl  = (EPolicy.TaskControl.Policy)Session["TaskControl"];
            Customer.Registry registry = (Customer.Registry)Session["Registry"];
            Login.Login cp = HttpContext.Current.User as Login.Login;




            if (cp.IsInRole("MARKETING") && cp.UserID != 331)
            {
                btnPrint.Visible = false;
            }
            else
            {
                btnPrint.Visible = true;
            }
            //331 y 318 Rene, 324 mio de Prueba,337 Neysa,336 Jose Crespo
            if (cp.UserID == 331 || cp.UserID == 318 || cp.UserID == 337 || cp.UserID == 336 || cp.UserID == 324)
                btnPrint.Visible = true;
 
        }

        protected void btnUpdate_Click(object sender, System.EventArgs e)
        {
            Customer.Registry registry = (Customer.Registry)Session["Registry"];
            DataTable dt = new DataTable();
            DataTable dtPrivileges = GetPrivileges(registry.RegistryID);

            dt.Columns.Add("PrivilegeID");
            dt.Columns.Add("Hospital");

            try
            {
                dtGridCertificateLocations.Visible = true;
                int index = int.Parse(txtGridCount.Text.Trim());

                if (dtPrivileges.Rows.Count > 0)
                {
                    for (int i = 0; i < dtPrivileges.Rows.Count; i++)
                    {
                        dt.Rows.Add();
                        dt.Rows[i]["PrivilegeID"] = dtPrivileges.Rows[i]["PrivilegeID"];
                    }
                    for (int n = 0; n < index; n++)
                    {
                        dt.Rows.Add();
                        dt.Rows[n + dtPrivileges.Rows.Count]["PrivilegeID"] = "0";
                    }
                    this.dtGridCertificateLocations.DataSource = dt;
                    this.dtGridCertificateLocations.DataBind();

                    for (int i = 0; i < dtPrivileges.Rows.Count; i++)
                    {
                        ((DropDownList)dtGridCertificateLocations.Items[i].Cells[1].FindControl("ddlCertificateLocation")).SelectedIndex =
                        ((DropDownList)dtGridCertificateLocations.Items[i].Cells[1].FindControl("ddlCertificateLocation")).Items.IndexOf
                        (((DropDownList)dtGridCertificateLocations.Items[i].Cells[1].FindControl("ddlCertificateLocation")).Items.FindByValue
                        (dtPrivileges.Rows[i]["HospitalID"].ToString()));
                    }

                    txtGridCount.Text = String.Empty;
                }
                else
                {
                    for (int n = 0; n < index; n++)
                    {
                        dt.Rows.Add();
                        dt.Rows[n]["PrivilegeID"] = "0";
                    }
                    this.dtGridCertificateLocations.DataSource = dt;
                    this.dtGridCertificateLocations.DataBind();

                    txtGridCount.Text = String.Empty;
                }
            }
            catch(Exception ex)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(ex.Message);
                this.litPopUp.Visible = true;
                return;
            }
        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Session.Remove("FromUI");
            Session.Remove("CancellationEdit");
            ReturnToReferringPage();
        }
        private void PrintCertificateReports(string certID, int counter)
        {
            
        }
        private void History(int taskControlID, int userID)
        {
            //Audit.History history = new Audit.History();
            //TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
            //DataTable historyDt = Policy.GetCertificateHistoryByTaskControlID(taskControl.TaskControlID);
            //string subject;

            //history.Actions = "PRINT";
            //subject = "PRINT CERTIFICATE " + "\r\n"
            //        + "COPIES: " + txtGridCount.Text.Trim() + "\r\n"
            //        + "CERTIFICATE IDs: " + "\r\n";

            //if (true)
            //    for (int i = 0; i < int.Parse(txtGridCount.Text.ToString().Trim()); i++)
            //        subject += ((DropDownList)dtGridCertificateLocations.Items[0].Cells[0].FindControl("ddlCertificateLocation")).SelectedValue.ToString().Trim() + " " + ((DropDownList)dtGridCertificateLocations.Items[0].Cells[0].FindControl("ddlCertificateLocation")).SelectedItem.ToString().Trim() + "\r\n";
            //else
            //    for (int i = 0; i < int.Parse(txtGridCount.Text.ToString().Trim()); i++)
            //        subject += ((DropDownList)dtGridCertificateLocations.Items[i].Cells[0].FindControl("ddlCertificateLocation")).SelectedValue.ToString().Trim() + " " + ((DropDownList)dtGridCertificateLocations.Items[i].Cells[0].FindControl("ddlCertificateLocation")).SelectedItem.ToString().Trim() + "\r\n";

            //history.KeyID = taskControlID.ToString();
            //history.Subject = "POLICIES";
            //history.BuildNotesForHistory("TaskControlID.", "", taskControlID.ToString(), 7);  //7 = mode NOTICEOFCANC
            //history.UsersID = userID;
            //history.Notes = "[CERTIFICATE] " + subject + "\r\n";
            //history.GetSaveHistory();
        }
        protected void chkShareHolder_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShareHolder.Checked)
            {
                txtShareholder.Enabled = true;
                txtShareholderNo.Visible = true;
                LblShareholderNo.Visible = true;
                Label9.Visible = true;
                txtShareholder.Visible = true;
                txtShareholderNo.Enabled = true;
                LblShareholderNo.Enabled = true;
            }
            else
            {
                txtShareholder.Enabled = false;
                txtShareholderNo.Visible = false;
                LblShareholderNo.Visible = false;
                Label9.Visible = false;
                txtShareholder.Visible = false;
                txtShareholderNo.Enabled = false;
                LblShareholderNo.Enabled = false;
                txtShareholder.Text = "";
                txtShareholderNo.Text = "";
            }
        }

        protected void RevealControls(object sender, EventArgs e)
        {
            RevealControls();            
        }

        protected void RevealControls()
        {
            if (chkASSMCA.Checked)            
                txtASSMCADate.Enabled = true;  
            else            
                txtASSMCADate.Enabled = false;               
            
            if (chkDEA.Checked)            
                txtDEADate.Enabled = true;  
            else            
                txtDEADate.Enabled = false;

            if (chkCDM.Checked)
                txtCDMDate.Enabled = true;
            else
                txtCDMDate.Enabled = false;

            if (chkCannabis.Checked)
                txtCannabisDate.Enabled = true;
            else
                txtCannabisDate.Enabled = false;


            //if (chkTribunal.Checked)
            //    txtTribunalDate.Text = DateTime.Now.ToShortDateString();
            //else
            //    txtTribunalDate.Text = "";

            if (chkRegistroMedico.Checked)
            {
                txtLicenciaDate.Enabled = true;
                txtLicencia.Enabled = true;
            }
            else
            {
                txtLicenciaDate.Enabled = false;
                txtLicencia.Enabled = false;
            }           

            if (chkMedicalSchool.Checked)
            {
                txtMDSGradDate.Enabled = true;
                txtMedicalSchool.Enabled = true;
            }
            else
            {
                txtMedicalSchool.Enabled = false;
                txtMDSGradDate.Enabled = false;
            }

            if (chkInternship.Checked)
            {
                txtInternship.Enabled = true;
                txtInternGradDate.Enabled = true;
            }
            else
            {
                txtInternship.Enabled = false;
                txtInternGradDate.Enabled = false;
            }
            if (chkResidency.Checked)
            {
                txtResidency.Enabled = true;
                txtResidencyGradDate.Enabled = true;
            }
            else
            {
                txtResidencyGradDate.Enabled = false;
                txtResidency.Enabled = false;
            }
            if (chkFellowship.Checked)
            {
                txtFellowship.Enabled = true;
                txtFelloshipGradDate.Enabled = true;
            }
            else
            {
                txtFellowship.Enabled = false;
                txtFelloshipGradDate.Enabled = false;
            }
            //if (chkJDL.Checked)
            //{
            //    txtTribunalDate.Enabled = true;
            //}
            //else
            //{
            //    txtTribunalDate.Enabled = false; 
            //}

            if (chkGStanding.Checked)
            {
                txtGStandingDate.Enabled = true;                
            }
            else
            {
                txtGStandingDate.Enabled = false;                
            }
            if (chkMedicalPractice.Items[6].Selected)
                txtOther.Enabled = true;
            else
            {
                txtOther.Enabled = false;
                txtOther.Text = "";
            }

            if (rblPreviousClaims.SelectedValue == "NO")
            {
                lblCarrier.Visible = false;
                Label30.Visible = false;
                Label25.Visible = false;
                Label24.Visible = false;
                txtPriCarierName.Visible = false;
                txtPriCarierName.Text = String.Empty;
                txtPriClaims.Visible = false;
                txtPriClaims.Text = String.Empty;
                txtPriPolLimits.Visible = false;
                txtPriPolLimits.Text = String.Empty;
                txtPriPolEffecDate.Visible = false;
                txtPriPolEffecDate.Text = String.Empty;
            }
            else
            {
                lblCarrier.Visible = true;
                Label30.Visible = true;
                Label25.Visible = true;
                Label24.Visible = true;
                txtPriCarierName.Visible = true;
                txtPriClaims.Visible = true;
                txtPriPolLimits.Visible = true;
                txtPriPolEffecDate.Visible = true;
            }
        }
        protected void dtGridCertificateLocations_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
            Customer.Registry registry = (Customer.Registry)Session["Registry"];
            int userID = 0;
            try
            {
                try
                {
                    userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        "Could not parse user id from cp.Identity.Name.", ex);
                }

                if (e.Item.ItemType.ToString() != "Delete")
                {
                    int index = int.Parse(e.Item.ItemIndex.ToString());

                    if (dtGridCertificateLocations.Items[e.Item.ItemIndex].Cells[0].Text != "0")
                        registry.DeletePrivileges(int.Parse(dtGridCertificateLocations.Items[e.Item.ItemIndex].Cells[0].Text));
                    else
                        throw new Exception("Unable to delete unsaved privilege.");

                        FillGrid();
                }
            }
            catch (Exception ex)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(ex.Message); 
                this.litPopUp.Visible = true;
            }
        }
        protected void rblPreviousClaims_SelectedIndexChanged(object sender, EventArgs e)
        {
            RevealControls();   
        }

        protected void EnableControls()
        {
            dtGridCertificateLocations.Columns[2].Visible = true;
            dtGridCertificateLocations.Enabled = true;
            btnHistory.Visible = false;
            btnEdit.Visible = false;
            BtnExit.Visible = false;
            btnPrint.Visible = false;

            btnSave.Visible = true;
            btnCancel.Visible = true;

            if (rblPreviousClaims.SelectedValue != "NO")
            {
                lblCarrier.Visible = true;
                lblCarrier.Enabled = true;
                Label30.Visible = true;
                Label30.Enabled = true;
                Label25.Visible = true;
                Label25.Enabled = true;
                Label24.Visible = true;
                Label24.Enabled = true;
                txtPriCarierName.Visible = true;
                txtPriCarierName.Enabled = true;
                txtPriClaims.Visible = true;
                txtPriClaims.Enabled = true;
                txtPriPolLimits.Visible = true;
                txtPriPolLimits.Enabled = true;
                txtPriPolEffecDate.Visible = true;
                txtPriPolEffecDate.Enabled = true;
            }
            else
            {
                lblCarrier.Visible = false;
                lblCarrier.Enabled = false;
                Label30.Visible = false;
                Label30.Enabled = false;
                Label25.Visible = false;
                Label25.Enabled = false;
                Label24.Visible = false;
                Label24.Enabled = false;
                txtPriCarierName.Visible = false;
                txtPriCarierName.Enabled = false;
                txtPriClaims.Visible = false;
                txtPriClaims.Enabled = false;
                txtPriPolLimits.Visible = false;
                txtPriPolLimits.Enabled = false;
                txtPriPolEffecDate.Visible = false;
                txtPriPolEffecDate.Enabled = false;
            }

            chkASSMCA.Enabled = true;
            chkDEA.Enabled = true;
            //chkTribunal.Enabled = true;
            chkJDL.Enabled = true;
            chkRegistroMedico.Enabled = true;
            chkCDM.Enabled = true;
            chkShareHolder.Enabled = true;
            chkGStanding.Enabled = true;
            chkCV.Enabled = true;
            chkCannabis.Enabled = true;
            ////////////
            chkRegistroMedico.Enabled = true;
            ////////////
            if (chkASSMCA.Checked)
            {
                txtASSMCADate.Enabled = true;                
            }
            if (chkDEA.Checked)
            {
                txtDEADate.Enabled = true;                
            }
          
            //if (chkJDL.Checked)
            //{
            //    txtTribunalDate.Enabled = true;
            //}
            if (chkRegistroMedico.Checked)
            {
                txtLicenciaDate.Enabled = true;
                txtLicencia.Enabled = true;
            }

            if (chkCDM.Checked)
            {
                txtCDMDate.Enabled = true;
                //txtMDSGradDate.Enabled = true;
            }
            if (chkCannabis.Checked)
            {
                txtCannabisDate.Enabled = true;
            }
            if (chkShareHolder.Checked)
            {
                txtShareholder.Enabled = true;
                txtShareholderNo.Enabled = true;
            }

            if (chkGStanding.Checked)
            {
                txtGStandingDate.Enabled = true;                
            }
          
            if (chkRegistroMedico.Checked)
                txtLicenciaDate.Enabled = true;
         
            if (chkMedicalPractice.Items[6].Selected)
                txtOther.Enabled = true;

            chkMedicalSchool.Enabled = true;
            chkInternship.Enabled = true;
            chkResidency.Enabled = true;
            chkFellowship.Enabled = true;

            if (chkMedicalSchool.Checked)
            {
                txtMedicalSchool.Enabled = true;
                txtMDSGradDate.Enabled = true;
            }

            if (chkInternship.Checked)
            {
                txtInternship.Enabled = true;
                txtInternGradDate.Enabled = true;
            }

            if (chkResidency.Checked)
            {
                txtResidency.Enabled = true;
                txtResidencyGradDate.Enabled = true;
            }
            if (chkFellowship.Checked)
            {
                txtFellowship.Enabled = true;
                txtFelloshipGradDate.Enabled = true;
            }

            txtLicenseExpDate.Enabled = true;

            chkMedicalPractice.Enabled = true;

            rblBoardCertified.Enabled = true;
            rblPreviousClaims.Enabled = true;

            txtPriCarierName.Enabled = true;
            txtPriClaims.Enabled = true;
            txtPriPolEffecDate.Enabled = true;
            txtPriPolLimits.Enabled = true;

            txtComment.Enabled = true;

            txtGridCount.Visible = true;
            btnUpdate.Visible = true;
            LblDate0.Visible = true;

            dtGridCertificateLocations.Enabled = true;
        }

        protected void DisableControls()
        {
            dtGridCertificateLocations.Columns[0].Visible = false;
            dtGridCertificateLocations.Columns[2].Visible = false;
            dtGridCertificateLocations.Enabled = false;
            btnHistory.Visible = true;
            btnEdit.Visible = true;
            BtnExit.Visible = true;
            btnPrint.Visible = true;

            btnSave.Visible = false;
            btnCancel.Visible = false;

            if (rblPreviousClaims.SelectedValue != "NO")
            {
                lblCarrier.Visible = true;
                lblCarrier.Enabled = false;
                Label30.Visible = true;
                Label30.Enabled = false;
                Label25.Visible = true;
                Label25.Enabled = false;
                Label24.Visible = true;
                Label24.Enabled = false;
                txtPriCarierName.Visible = true;
                txtPriCarierName.Enabled = false;
                txtPriClaims.Visible = true;
                txtPriClaims.Enabled = false;
                txtPriPolLimits.Visible = true;
                txtPriPolLimits.Enabled = false;
                txtPriPolEffecDate.Visible = true;
                txtPriPolEffecDate.Enabled = false;
            }
            else
            {
                lblCarrier.Visible = false;
                lblCarrier.Enabled = false;
                Label30.Visible = false;
                Label30.Enabled = false;
                Label25.Visible = false;
                Label25.Enabled = false;
                Label24.Visible = false;
                Label24.Enabled = false;
                txtPriCarierName.Visible = false;
                txtPriCarierName.Enabled = false;
                txtPriClaims.Visible = false;
                txtPriClaims.Enabled = false;
                txtPriPolLimits.Visible = false;
                txtPriPolLimits.Enabled = false;
                txtPriPolEffecDate.Visible = false;
                txtPriPolEffecDate.Enabled = false;
            }
            chkCannabis.Enabled = false;
            chkASSMCA.Enabled = false;
            chkDEA.Enabled = false;
            chkTribunal.Enabled = false;
            chkRegistroMedico.Enabled = false;
            chkCDM.Enabled = false;
            chkShareHolder.Enabled = false;
            chkGStanding.Enabled = false;
            chkJDL.Enabled = false;
            chkCV.Enabled = false;
            chkRegistroMedico.Enabled = false;

            txtCannabisDate.Enabled = false;
            txtASSMCADate.Enabled = false;
            txtInternGradDate.Enabled = false;
            txtDEADate.Enabled = false;
            
            //txtTribunalDate.Enabled = false;
            txtLicenciaDate.Enabled = false;
            txtLicencia.Enabled = false;
            txtCDMDate.Enabled = false;
            txtMDSGradDate.Enabled = false;
            txtShareholder.Enabled = false;
            txtShareholderNo.Enabled = false;
            txtGStandingDate.Enabled = false;
            txtFelloshipGradDate.Enabled = false;
            ///////////////
            txtInternGradDate.Enabled = false;
            
            //txtTribunalDate.Enabled = false;
            txtMDSGradDate.Enabled = false;
            txtLicenciaDate.Enabled = false;
            txtFelloshipGradDate.Enabled = false;
            /////////


            chkMedicalSchool.Enabled = false;
            chkInternship.Enabled = false;
            chkResidency.Enabled = false;
            chkFellowship.Enabled = false;

            txtMDSGradDate.Enabled = false;
            txtMedicalSchool.Enabled = false;
            txtInternship.Enabled = false;
            txtInternGradDate.Enabled = false;
            txtResidency.Enabled = false;
            txtResidencyGradDate.Enabled = false;
            txtFellowship.Enabled = false;
            txtFelloshipGradDate.Enabled = false;
            txtOther.Enabled = false;

            txtLicenseExpDate.Enabled = false;

            chkMedicalPractice.Enabled = false;

            rblBoardCertified.Enabled = false;
            rblPreviousClaims.Enabled = false;

            txtComment.Enabled = false;

            txtGridCount.Visible = false;
            btnUpdate.Visible = false;
            LblDate0.Visible = false;
            
        }

        private void FillProperties()
        {
            try
            {
                Customer.Registry registry = (Customer.Registry)Session["Registry"];
                TaskControl.TaskControl taskControl = (TaskControl.TaskControl)Session["TaskControl"];

                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                registry.CustomerNo = taskControl.CustomerNo;
                registry.ASSMCAExpDate = txtASSMCADate.Text.Trim();
                
                registry.DEAExpDate = txtDEADate.Text.Trim();                
                //registry.TribunalExpDate = txtTribunalDate.Text.Trim();
                registry.LicenciaDate = txtLicenciaDate.Text.Trim();
                registry.Licencia = txtLicencia.Text.Trim();
                registry.CDMExpDate = txtCDMDate.Text;                
                registry.GoodStandingExpDate = txtGStandingDate.Text;               
                registry.LicenseExpDate = txtLicenseExpDate.Text;
                registry.MedicalSchool = txtMedicalSchool.Text;
                registry.MDSGradDate = txtMDSGradDate.Text.Trim();
                registry.Internship = txtInternship.Text;
                registry.InternGradDate = txtInternGradDate.Text.Trim();                
                registry.Residency = txtResidency.Text;
                registry.ResidencyGradDate = txtResidencyGradDate.Text.Trim();
                registry.Fellowship = txtFellowship.Text;
                registry.FellowshipGradDate = txtFelloshipGradDate.Text.Trim();
                registry.CannabisDate = txtCannabisDate.Text.Trim();
                if (txtShareholder.Text != "")
                    registry.ShareholderQty = int.Parse(txtShareholder.Text);
                else
                    registry.ShareholderQty = 0;

                registry.ShareholderNo = txtShareholderNo.Text;
                registry.MedicalPractice = "";

                if (chkMedicalPractice.Items[0].Selected)
                    if (registry.MedicalPractice == "")
                        registry.MedicalPractice = chkMedicalPractice.Items[0].Value;

                if (chkMedicalPractice.Items[1].Selected)
                    if(registry.MedicalPractice == "")
                        registry.MedicalPractice = chkMedicalPractice.Items[1].Value;
                    else
                        registry.MedicalPractice += "|" + chkMedicalPractice.Items[1].Value;

                if (chkMedicalPractice.Items[2].Selected)
                    if (registry.MedicalPractice == "")
                        registry.MedicalPractice = chkMedicalPractice.Items[2].Value;
                    else
                        registry.MedicalPractice += "|" + chkMedicalPractice.Items[2].Value;

                if (chkMedicalPractice.Items[3].Selected)
                    if (registry.MedicalPractice == "")
                        registry.MedicalPractice = chkMedicalPractice.Items[3].Value;
                    else
                        registry.MedicalPractice += "|" + chkMedicalPractice.Items[3].Value;

                if (chkMedicalPractice.Items[4].Selected)
                    if (registry.MedicalPractice == "")
                        registry.MedicalPractice = chkMedicalPractice.Items[4].Value;
                    else
                        registry.MedicalPractice += "|" + chkMedicalPractice.Items[4].Value;

                if (chkMedicalPractice.Items[5].Selected)
                    if (registry.MedicalPractice == "")
                        registry.MedicalPractice = chkMedicalPractice.Items[5].Value;
                    else
                        registry.MedicalPractice += "|" + chkMedicalPractice.Items[5].Value;

                if (chkMedicalPractice.Items[6].Selected)
                    if (registry.MedicalPractice == "")
                        registry.MedicalPractice = txtOther.Text;
                    else
                        registry.MedicalPractice += "|" + txtOther.Text;

                registry.PreviousClaims = rblPreviousClaims.SelectedIndex;
                registry.BoardCertified = rblBoardCertified.SelectedIndex;
                registry.CV = chkCV.Checked;
                registry.JuntaLicenciamiento = chkJDL.Checked;
                registry.EffectiveDate = txtPriPolEffecDate.Text;
                registry.CarrierName = txtPriCarierName.Text;
                registry.PolicyNo = txtPriClaims.Text;
                registry.PolicyLimits = txtPriPolLimits.Text;
                registry.Comments = txtComment.Text;

                Session["Registry"] = registry;
            }
            catch (Exception exp)
            {
                //if (exp.InnerException == null)
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
                //else if (exp.InnerException.InnerException == null)
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
                //else
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                //         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("A problem occured filling class properties.");
                this.litPopUp.Visible = true;
            }
        }

        protected void FillTextControl()
        {
            try
            {
                Customer.Registry registry = (Customer.Registry)Session["Registry"];
                TaskControl.TaskControl taskControl = (TaskControl.TaskControl)Session["TaskControl"];

                lblPolicyNo.Text = "Name: " + taskControl.Customer.FirstName + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2;
                txtASSMCADate.Text = registry.ASSMCAExpDate;
                txtInternGradDate.Text = registry.InternGradDate;
                if (txtASSMCADate.Text != "")
                    chkASSMCA.Checked = true;

                txtDEADate.Text = registry.DEAExpDate;
                txtResidencyGradDate.Text = registry.ResidencyGradDate;
                if (txtDEADate.Text != "")
                    chkDEA.Checked = true;

                txtCannabisDate.Text = registry.CannabisDate;
                if (txtCannabisDate.Text != "")
                    chkCannabis.Checked = true;

               // txtTribunalDate.Text = registry.TribunalExpDate;
                //if (txtTribunalDate.Text != "")
                //    chkJDL.Checked = true;
                

                txtLicenciaDate.Text = registry.LicenciaDate;
                txtLicencia.Text = registry.Licencia;
                if (txtLicenciaDate.Text != "")
                    chkRegistroMedico.Checked = true;

                txtCDMDate.Text = registry.CDMExpDate;
                txtMDSGradDate.Text = registry.MDSGradDate;
                if (txtCDMDate.Text != "")
                    chkCDM.Checked = true;

                txtGStandingDate.Text = registry.GoodStandingExpDate;
                txtFelloshipGradDate.Text = registry.FellowshipGradDate;
                if (txtGStandingDate.Text != "")
                    chkGStanding.Checked = true;

                txtLicenseExpDate.Text = registry.LicenseExpDate;

                txtMedicalSchool.Text = registry.MedicalSchool;
                if (txtMedicalSchool.Text != "")
                    chkMedicalSchool.Checked = true;

                txtInternship.Text = registry.Internship;
                if (txtInternship.Text != "")
                    chkInternship.Checked = true;

                txtResidency.Text = registry.Residency;
                if (txtResidency.Text != "")
                    chkResidency.Checked = true;

                txtFellowship.Text = registry.Fellowship;
                if (txtFellowship.Text != "")
                    chkFellowship.Checked = true;

                if (registry.ShareholderQty != 0)
                {
                    txtShareholder.Text = registry.ShareholderQty.ToString();
                    txtShareholderNo.Text = registry.ShareholderNo;
                }
                else
                {
                    txtShareholder.Text = "";
                }

                if (txtShareholder.Text != "" || txtShareholderNo.Text != "")
                {
                    chkShareHolder.Checked = true;
                    txtShareholderNo.Visible = true;
                    LblShareholderNo.Visible = true;
                    Label9.Visible = true;
                    txtShareholder.Visible = true;
                }
                else
                {
                    chkShareHolder.Checked = false;
                    txtShareholderNo.Visible = false;
                    LblShareholderNo.Visible = false;
                    Label9.Visible = false;
                    txtShareholder.Visible = false;
                }

                if (registry.MedicalPractice.Contains("Solo Physician"))
                    chkMedicalPractice.Items[0].Selected = true;
                else
                    chkMedicalPractice.Items[0].Selected = false;

                if (registry.MedicalPractice.Contains("Employed Physician"))
                    chkMedicalPractice.Items[1].Selected = true;
                else
                    chkMedicalPractice.Items[1].Selected = false;

                if (registry.MedicalPractice.Contains("Partnership"))
                    chkMedicalPractice.Items[2].Selected = true;
                else
                    chkMedicalPractice.Items[2].Selected = false;

                if (registry.MedicalPractice.Contains("Group Member"))
                    chkMedicalPractice.Items[3].Selected = true;
                else
                    chkMedicalPractice.Items[3].Selected = false;

                if (registry.MedicalPractice.Contains("Professional Association"))
                    chkMedicalPractice.Items[4].Selected = true;
                else
                    chkMedicalPractice.Items[4].Selected = false;

                if (registry.MedicalPractice.Contains("Professional Corporation"))
                    chkMedicalPractice.Items[5].Selected = true;
                else
                    chkMedicalPractice.Items[5].Selected = false;


                string[] line = registry.MedicalPractice.Split('|');
                int size = line.Length - 1;

                if (line[size] != "Solo Physician" &&
                    line[size] != "Employed Physician" &&
                    line[size] != "Partnership" &&
                    line[size] != "Group Member" &&
                    line[size] != "Professional Association" &&
                    line[size] != "Professional Corporation" &&
                    line[size] != "")
                {
                    chkMedicalPractice.Items[6].Selected = true;
                    txtOther.Text = line[size];
                }
                else
                    chkMedicalPractice.Items[6].Selected = false;

                rblPreviousClaims.SelectedIndex = registry.PreviousClaims;
                rblBoardCertified.SelectedIndex = registry.BoardCertified;

                chkCV.Checked = registry.CV;
                chkJDL.Checked = registry.JuntaLicenciamiento;

                txtPriPolEffecDate.Text = registry.EffectiveDate;
                txtPriCarierName.Text = registry.CarrierName;
                txtPriClaims.Text = registry.PolicyNo;
                txtPriPolLimits.Text = registry.PolicyLimits;

                txtComment.Text = registry.Comments;

                FillGrid();
                RevealControls();
            }
            catch (Exception xp)
            {
                throw new Exception("Could not validate all fields. Please verify."); 
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            FillTextControl();
            DisableControls();
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            EnableControls();
        }
        protected void btnHistory_Click(object sender, EventArgs e)
        {
            TaskControl.TaskControl taskControl = (TaskControl.TaskControl)Session["TaskControl"];

            if (Session["TaskControl"] != null)
            {
                RemoveSessionLookUp();
                Response.Redirect("SearchAuditItems.aspx?type=27&taskControlID=" +
                taskControl.TaskControlID.ToString().Trim());
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Customer.Registry registry = (Customer.Registry)Session["Registry"];
                TaskControl.TaskControl taskControl = (TaskControl.TaskControl)Session["TaskControl"];
                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                bool validate = ValidateDates();

                if (validate)
                {
                    if (registry.RegistryID == 0)
                        registry.Mode = 1;
                    else
                        registry.Mode = 2;

                    FillProperties();
                    registry.SaveRegistry(userID, taskControl.TaskControlID);

                    registry = Customer.Registry.GetRegistryByCustomerNo(int.Parse(taskControl.CustomerNo));
                    Session["Registry"] = registry;

                    if (dtGridCertificateLocations.Items.Count > 0)
                    {
                        for (int i = 0; i < dtGridCertificateLocations.Items.Count; i++)
                            registry.SavePrivileges(int.Parse(dtGridCertificateLocations.Items[i].Cells[0].Text),
                            registry.RegistryID, int.Parse(((DropDownList)dtGridCertificateLocations.Items[i].Cells[1].FindControl("ddlCertificateLocation")).SelectedValue));
                    }

                    FillTextControl();
                    DisableControls();


                    registry = Customer.Registry.GetRegistryByCustomerNo(int.Parse(registry.CustomerNo));
                    registry.Mode = 4;

                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Saved Registry Successfully.");
                    this.litPopUp.Visible = true;
                }
                else
                    throw new Exception("Error found in provided dates.  Please verify.");
            }
            catch (Exception exp)
            {
                //if (exp.InnerException == null)
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
                //else if (exp.InnerException.InnerException == null)
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
                //else
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                //         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }
        }

        protected void FillGrid()
        {
            Customer.Registry registry = (Customer.Registry)Session["Registry"];
            DataTable dt = new DataTable();
            DataTable dtPrivileges = GetPrivileges(registry.RegistryID);

            if (dtPrivileges.Rows.Count != 0)
            {
                dtGridCertificateLocations.Visible = true;

                dt.Columns.Add("PrivilegeID");
                dt.Columns.Add("Hospital");

                for (int i = 0; i < dtPrivileges.Rows.Count; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[i]["PrivilegeID"] = dtPrivileges.Rows[i]["PrivilegeID"];                    
                }

                this.dtGridCertificateLocations.DataSource = dt;
                this.dtGridCertificateLocations.DataBind();

                for (int i = 0; i < dtPrivileges.Rows.Count; i++)
                {
                    ((DropDownList)dtGridCertificateLocations.Items[i].Cells[1].FindControl("ddlCertificateLocation")).SelectedIndex =
                    ((DropDownList)dtGridCertificateLocations.Items[i].Cells[1].FindControl("ddlCertificateLocation")).Items.IndexOf
                    (((DropDownList)dtGridCertificateLocations.Items[i].Cells[1].FindControl("ddlCertificateLocation")).Items.FindByValue
                    (dtPrivileges.Rows[i]["HospitalID"].ToString()));
                }

            }
            else
            {
                dtGridCertificateLocations.Visible = false;
            }

            //if (dtPrivileges.Rows.Count > 0)
            //    dtGridCertificateLocations.Visible = true;
            //else
            //    dtGridCertificateLocations.Visible = false;

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
        protected void btnPrint_Click(object sender, System.EventArgs e)
        {
            Customer.Registry registry = (Customer.Registry)Session["Registry"];
            TaskControl.TaskControl taskControl = (TaskControl.TaskControl)Session["TaskControl"];

            bool validate = ValidateDates();

            if (validate)
            {
                List<string> mergePaths = new List<string>();
                string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

                DisableControls();

                mergePaths = imprimirRegister(mergePaths);

                FileInfo mFileIndex = new FileInfo("C:\\Inetpub\\wwwroot\\PRMDic\\Reports\\Registry.pdf");

                CreatePDFBatch mergeFinal = new CreatePDFBatch();
                string FinalFile = "";
                FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, "Registry" + taskControl.TaskControlID.ToString().Trim());
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
            }
            else
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Error found in provided dates.  Please verify.");
                this.litPopUp.Visible = true;
            }
                
        }
        private List<string> imprimirRegister(List<string> mergePaths)
        {
            int compareResult = 0;

            string tp6 = "";
            string assmcadate = "";
            string juntaLicenciamiento = "";
            string cdmdate = "";
            string gstandingdate = "";
            string licenseexpdate = "";
            string deadate = "";
            string registroMedico = "";

            try
            {
                Customer.Registry registry = (Customer.Registry)Session["Registry"];
                TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];

                ReportViewer viewer = new ReportViewer();

                viewer.LocalReport.DataSources.Clear();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportPath = Server.MapPath("Reports/Report2.rdlc");

                #region values for parameters
                if (txtASSMCADate.Text != "")
                {
                    compareResult = DateTime.Compare(DateTime.Parse(txtASSMCADate.Text.Trim()), DateTime.Now);

                    if (compareResult < 0)
                    {
                        assmcadate = "(EXP) " + txtASSMCADate.Text.Trim();
                    }
                }
                else
                    assmcadate = "X";
                //if (txtTribunalDate.Text != "")
                //{
                //    compareResult = DateTime.Compare(DateTime.Parse(txtTribunalDate.Text.Trim()), DateTime.Now);

                //    if (compareResult < 0)
                //    {
                //        tribunaldate = "(EXP) " + txtTribunalDate.Text.Trim();
                //    }
                //}
                //else
                if (chkJDL.Checked)
                    juntaLicenciamiento = "";
                else
                    juntaLicenciamiento = "X";

                if (txtCDMDate.Text != "")
                {
                    compareResult = DateTime.Compare(DateTime.Parse(txtCDMDate.Text.Trim()), DateTime.Now);

                    if (compareResult < 0)
                    {
                        cdmdate = "(EXP) " + txtCDMDate.Text.Trim();
                    }
                }
                else
                    cdmdate = "X";
                if (txtGStandingDate.Text != "")
                {
                    compareResult = DateTime.Compare(DateTime.Parse(txtGStandingDate.Text.Trim()), DateTime.Now);

                    if (compareResult < 0)
                    {
                        gstandingdate = "(EXP) " + txtGStandingDate.Text.Trim();
                    }
                }
                else
                    gstandingdate = "X";
                if (txtLicenciaDate.Text != "")
                {
                    compareResult = DateTime.Compare(DateTime.Parse(txtLicenciaDate.Text.Trim()), DateTime.Now);

                    if (compareResult < 0)
                    {
                        licenseexpdate = "(EXP) " + txtLicenciaDate.Text.Trim();
                    }
                }
                else
                    licenseexpdate = "X";
                if (txtDEADate.Text != "")
                {
                    compareResult = DateTime.Compare(DateTime.Parse(txtDEADate.Text.Trim()), DateTime.Now);

                    if (compareResult < 0)
                    {
                        deadate = "(EXP) " + txtDEADate.Text.Trim();
                    }
                }
                else
                    deadate = "X";

                if (txtLicenciaDate.Text != "")
                {
                    compareResult = DateTime.Compare(DateTime.Parse(txtLicenciaDate.Text.Trim()), DateTime.Now);

                    if (compareResult < 0)
                    {
                        registroMedico = "(EXP) " + txtLicenciaDate.Text.Trim();
                    }
                }
                else
                    registroMedico = "X";

                if (!chkCV.Checked)
                {
                    tp6 = "X";
                }
                #endregion

                ReportParameter p1 = new ReportParameter("ASSMCADate", assmcadate);
                ReportParameter p2 = new ReportParameter("JuntaLicenciamiento", juntaLicenciamiento);
                ReportParameter p3 = new ReportParameter("CDMDate", cdmdate);
                ReportParameter p4 = new ReportParameter("GStandingDate", gstandingdate);
                ReportParameter p5 = new ReportParameter("LicenseExpDate", licenseexpdate);
                ReportParameter p6 = new ReportParameter("CVDate", tp6);
                ReportParameter p7 = new ReportParameter("DEADate", deadate);

                ReportParameter p8 = new ReportParameter("Asegurado", taskControl.Customer.FirstName + " " + taskControl.Customer.Initial + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2);
                ReportParameter p9 = new ReportParameter("PolizaNo", taskControl.PolicyType.Trim() + "-" + taskControl.PolicyNo);

                LookupTables.Agency agency = new LookupTables.Agency();

                agency = agency.GetAgency(taskControl.Agency);

                ReportParameter p10 = new ReportParameter("Agency", agency.AgencyDesc);

                LookupTables.Agent agent = new LookupTables.Agent();

                agent = agent.GetAgent(taskControl.Agent);

                ReportParameter p11 = new ReportParameter("Productor", agent.AgentDesc);
                ReportParameter p12 = new ReportParameter("EffDt", taskControl.EffectiveDate);
                
                DataTable DtTask = TaskControl.TaskControl.GetTaskControlByCustomerNo(taskControl.Customer.CustomerNo);
                bool validate = true;

                for (int i = 0; i < DtTask.Rows.Count; i++)
                {
                    if (DtTask.Rows[i][1].ToString().Trim() == "PP")
                        validate = false;
                }

                ReportParameter p13 = new ReportParameter();

                if(validate)
                    p13 = new ReportParameter("EntryDt", "X");
                else
                    p13 = new ReportParameter("EntryDt", "");

                

                agent = agent.GetAgent(taskControl.Agent);

                viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13 });
                viewer.LocalReport.Refresh();

                // Variables 
                Warning[] warnings;
                string[] streamIds;
                string mimeType;
                string encoding = string.Empty;
                string extension;
                string _FileName = "Registry-" + registry.RegistryID.ToString().Trim() + ".pdf";

                if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                    File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }

                mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);
                return mergePaths;
            }
            catch (Exception exp)
            {
                return mergePaths;
            }
        }
        private DataTable GetPrivileges(int registryID)
        {
            Customer.Registry registry = (Customer.Registry)Session["Registry"];
            return registry.GetPrivileges(registry.RegistryID);
        }

        private void SetReferringPage()
        {
            if ((Session["FromUI"] != null) && (Session["FromUI"].ToString() != ""))
            {
                this.ReferringPage = Session["FromUI"].ToString();
                //Session.Remove("FromUI");
            }
        }

        private void ReturnToReferringPage()
        {
            if (this.ReferringPage != "")
            {
                Response.Redirect(this.ReferringPage);
            }
            Response.Redirect("Default.aspx");
        }

        private void RemoveSessionLookUp()
        {
            Session.Remove("LookUpTables");
        }
        protected void chkMedicalPractice_SelectedIndexChanged(object sender, EventArgs e)
        {
            RevealControls();
        }

        private bool ValidateDates()
        {
            bool validated = false;
            DateTime temp = new DateTime();

            if (txtLicenseExpDate.Text != "")
            {
                if (DateTime.TryParse(txtLicenseExpDate.Text, out temp))
                    validated = true;
                else
                    throw new Exception("Error found in provided dates.  Please verify.");
            }

            if (txtASSMCADate.Text != "") 
            {
                if (DateTime.TryParse(txtASSMCADate.Text, out temp))
                    validated = true;
                else
                    throw new Exception("Error found in provided dates.  Please verify.");
            }
            if (txtInternGradDate.Text != "")
            {
                if (DateTime.TryParse(txtInternGradDate.Text, out temp))
                    validated = true;
                else
                    throw new Exception("Error found in provided dates.  Please verify.");
            }

            if (txtDEADate.Text != "") 
            {
                if (DateTime.TryParse(txtDEADate.Text, out temp))
                    validated = true;
                else
                    throw new Exception("Error found in provided dates.  Please verify.");
            }
            if (txtResidencyGradDate.Text != "")
            {
                if (DateTime.TryParse(txtResidencyGradDate.Text, out temp))
                    validated = true;
                else
                    throw new Exception("Error found in provided dates.  Please verify.");
            }

            //if (txtTribunalDate.Text != "") 
            //{
            //    if (DateTime.TryParse(txtTribunalDate.Text, out temp))
            //        validated = true;
            //    else
            //        throw new Exception("Error found in provided dates.  Please verify.");
            //}

            if (txtCDMDate.Text != "")
            {
                if (DateTime.TryParse(txtCDMDate.Text, out temp))
                    validated = true;
                else
                    throw new Exception("Error found in provided dates.  Please verify.");
            }
            if (txtMDSGradDate.Text != "")
            {
                if (DateTime.TryParse(txtMDSGradDate.Text, out temp))
                    validated = true;
                else
                    throw new Exception("Error found in provided dates.  Please verify.");
            }

            if (txtGStandingDate.Text != "") 
            {
                if (DateTime.TryParse(txtGStandingDate.Text, out temp))
                    validated = true;
                else
                    throw new Exception("Error found in provided dates.  Please verify.");
            }
            if (txtFelloshipGradDate.Text != "")
            {
                if (DateTime.TryParse(txtFelloshipGradDate.Text, out temp))
                    validated = true;
                else
                    throw new Exception("Error found in provided dates.  Please verify.");
            }

            if (txtLicenseExpDate.Text == "" && txtASSMCADate.Text == "" && txtDEADate.Text == "" && txtCDMDate.Text == "" && txtGStandingDate.Text == "")
                validated = true;

            return validated;
        }
}

}
