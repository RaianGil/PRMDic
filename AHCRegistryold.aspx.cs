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
    public partial class AHCRegistry : System.Web.UI.Page
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
                //btnPrint.Visible = true;
            }
 
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
            if (chkLicenseExoDptoDate.Checked)            
                txtLicenseExoDptoDate.Enabled = true;  
            else            
                txtLicenseExoDptoDate.Enabled = false;               
            
            if (chkGraduationCertificate.Checked)            
                txtGraduationCertificate.Enabled = true;  
            else            
                txtGraduationCertificate.Enabled = false;

            if (chkGradeCopyDate.Checked)
                txtGradeCopyDate.Enabled = true;
            else
                txtGradeCopyDate.Enabled = false;

            if (chkRegisterCertificateDate.Checked)
                txtRegisterCertificateDate.Enabled = true;
            else
                txtRegisterCertificateDate.Enabled = false;
            //Nuevos

            if (chkRegisterCertificateDate2.Checked)
                txtRegisterCertificateDate2.Enabled = true;
            else
                txtRegisterCertificateDate2.Enabled = false;

            if (chkColCertificateDate.Checked)
                txtColCertificateDate.Enabled = true;
            else
                txtColCertificateDate.Enabled = false;

            if (chkDptoLicenseDate.Checked)
                txtDptoLicenseDate.Enabled = true;
            else
                txtDptoLicenseDate.Enabled = false;

            if (chkGradeCopyDate2.Checked)
                txtGradeCopyDate2.Enabled = true;
            else
                txtGradeCopyDate2.Enabled = false;

            if (chkAudioLicenseDate.Checked)
                txtAudioLicenseDate.Enabled = true;
            else
                txtAudioLicenseDate.Enabled = false;

            if (chkJuntaCertificateDate.Checked)
                txtJuntaCertificateDate.Enabled = true;
            else
                txtJuntaCertificateDate.Enabled = false;

            if (chkGradeCopyDate3.Checked)
                txtGradeCopyDate3.Enabled = true;
            else
                txtGradeCopyDate3.Enabled = false;

            if (chkDegreeDate.Checked)
                txtDegreeDate.Enabled = true;
            else
                txtDegreeDate.Enabled = false;

            if (chkRegisterCertificateDate3.Checked)
                txtRegisterCertificateDate3.Enabled = true;
            else
                txtRegisterCertificateDate3.Enabled = false;

            if (chkNutriLicenseDate.Checked)
                txtNutriLicenseDate.Enabled = true;
            else
                txtNutriLicenseDate.Enabled = false;

            if (chkGradeCopyDate4.Checked)
                txtGradeCopyDate4.Enabled = true;
            else
                txtGradeCopyDate4.Enabled = false;

            if (chkNutriCertificateDate.Checked)
                txtNutriCertificateDate.Enabled = true;
            else
                txtNutriCertificateDate.Enabled = false;

            if (chkCertificateCopyDate.Checked)
                txtCertificateCopyDate.Enabled = true;
            else
                txtCertificateCopyDate.Enabled = false;

            if (chkRegisterCertificateDate4.Checked)
                txtRegisterCertificateDate4.Enabled = true;
            else
                txtRegisterCertificateDate4.Enabled = false;

            if (chkPsicoLicenseDate.Checked)
                txtPsicoLicenseDate.Enabled = true;
            else
                txtPsicoLicenseDate.Enabled = false;

            if (chkGradeCopyDate5.Checked)
                txtGradeCopyDate5.Enabled = true;
            else
                txtGradeCopyDate5.Enabled = false;

            if (chkCredentialsDate.Checked)
              txtCredentialsDate.Enabled = true;
            else
                txtCredentialsDate.Enabled = false;

            if (chkOptoDate.Checked)
                txtOptoDate.Enabled = true;
            else
                txtOptoDate.Enabled = false;

            if (chkPermanentDate.Checked)
                txtPermanentDate.Enabled = true;
            else
                txtPermanentDate.Enabled = false;

            if (chkRegisterCertificateDate5.Checked)
                txtRegisterCertificateDate5.Enabled = true;
            else
                txtRegisterCertificateDate5.Enabled = false;

            if (chkCredentialsDate2.Checked)
                txtCredentialsDate2.Enabled = true;
            else
                txtCredentialsDate2.Enabled = false;

            

            //if (chkTribunal.Checked)
            //    txtTribunalDate.Text = DateTime.Now.ToShortDateString();
            //else
            //    txtTribunalDate.Text = "";
            //aqui hello
            if (chkRegisterCertificateDate.Checked)
            {
                txtRegisterCertificateDate.Enabled = true;
                txtRegisterCertificateDate.Enabled = true;
            }
            else
            {
                txtRegisterCertificateDate.Enabled = false;
                txtRegisterCertificateDate.Enabled = false;
            }       
    
            //////////////////
            if (chkRegisterCertificateDate2.Checked)
            {
                txtRegisterCertificateDate2.Enabled = true;
                txtRegisterCertificateDate2.Enabled = true;
            }
            else
            {
                txtRegisterCertificateDate2.Enabled = false;
                txtRegisterCertificateDate2.Enabled = false;
            }

            if (chkRegisterCertificateDate3.Checked)
            {
                txtRegisterCertificateDate3.Enabled = true;
                txtRegisterCertificateDate3.Enabled = true;
            }
            else
            {
                txtRegisterCertificateDate3.Enabled = false;
                txtRegisterCertificateDate3.Enabled = false;
            }

            if (chkRegisterCertificateDate4.Checked)
            {
                txtRegisterCertificateDate4.Enabled = true;
                txtRegisterCertificateDate4.Enabled = true;
            }
            else
            {
                txtRegisterCertificateDate4.Enabled = false;
                txtRegisterCertificateDate4.Enabled = false;
            }

            if (chkRegisterCertificateDate5.Checked)
            {
                txtRegisterCertificateDate5.Enabled = true;
                txtRegisterCertificateDate5.Enabled = true;
            }
            else
            {
                txtRegisterCertificateDate5.Enabled = false;
                txtRegisterCertificateDate5.Enabled = false;
            }


            if (chkDegreeDate.Checked)
            {
                txtDegreeDate.Enabled = true;
                txtDegreeDate.Enabled = true;
            }
            else
            {
                txtDegreeDate.Enabled = false;
                txtDegreeDate.Enabled = false;
            }    

            /////////////////

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

            if (chkTecLicenseDatte.Checked)
            {
                txtTecLicenseDate.Enabled = true;                
            }
            else
            {
                txtTecLicenseDate.Enabled = false;                
            }
            if (chkMedicalPractice.Items[6].Selected)
                txtOther.Enabled = true;
            else
            {
                txtOther.Enabled = false;
                txtOther.Text = "";
            }

            //if (chkMedicalPractice.Items[0].Selected)
            //{
            //    chkLicenseExoDptoDate.Enabled = true;
            //    chkGraduationCertificate.Enabled = true;
            
            //}

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

            chkLicenseExoDptoDate.Enabled = true;
            chkGraduationCertificate.Enabled = true;
            //chkTribunal.Enabled = true;
            chkColCertificateDate.Enabled = true;
            chkRegisterCertificateDate.Enabled = true;
            chkGradeCopyDate.Enabled = true;
            chkShareHolder.Enabled = true;
            chkTecLicenseDatte.Enabled = true;
            chkCV.Enabled = true;
            chkRegisterCertificateDate.Enabled = true;
            ////////////
            chkRegisterCertificateDate.Enabled = true;
            chkRegisterCertificateDate2.Enabled = true;
            chkDegreeDate.Enabled = true;
            chkDptoLicenseDate.Enabled = true;
            chkGradeCopyDate2.Enabled = true;
            chkAudioLicenseDate.Enabled = true;
            chkJuntaCertificateDate.Enabled = true;
            chkGradeCopyDate3.Enabled = true;
            chkRegisterCertificateDate3.Enabled = true;
            chkNutriLicenseDate.Enabled = true;
            chkGradeCopyDate4.Enabled = true;
            chkNutriCertificateDate.Enabled = true;
            chkCertificateCopyDate.Enabled = true;
            chkRegisterCertificateDate4.Enabled = true;
            chkPsicoLicenseDate.Enabled = true;
            chkGradeCopyDate5.Enabled = true;
            chkCredentialsDate.Enabled = true;
            chkOptoDate.Enabled = true;
            chkRegisterCertificateDate5.Enabled = true;
            chkPermanentDate.Enabled = true;
            chkCole.Enabled = true;
            chkCredentialsDate2.Enabled = true;



            ////////////
            if (chkLicenseExoDptoDate.Checked)
            {
                txtLicenseExoDptoDate.Enabled = true;                
            }
            if (chkGraduationCertificate.Checked)
            {
                txtGraduationCertificate.Enabled = true;                
            }
          
            //if (chkJDL.Checked)
            //{
            //    txtTribunalDate.Enabled = true;
            //}
            if (chkRegisterCertificateDate.Checked)
            {
                txtRegisterCertificateDate.Enabled = true;
                txtLicencia.Enabled = true;
            }

            if (chkGradeCopyDate.Checked)
            {
                txtGradeCopyDate.Enabled = true;
                //txtMDSGradDate.Enabled = true;
            }
            if (chkRegisterCertificateDate.Checked)
            {
                txtRegisterCertificateDate2.Enabled = true;
            }


            //Nuevos
            if (chkColCertificateDate.Checked)
            {
                txtColCertificateDate.Enabled = true;
            }
            if (chkDptoLicenseDate.Checked)
            {
                txtDptoLicenseDate.Enabled = true;
            }

            if (chkGradeCopyDate2.Checked)
            {
                txtGradeCopyDate2.Enabled = true;
            }

            if (chkAudioLicenseDate.Checked)
            {
                txtAudioLicenseDate.Enabled = true;
            }

            if (chkJuntaCertificateDate.Checked)
            {
                txtJuntaCertificateDate.Enabled = true;
            }

            if (chkGradeCopyDate3.Checked)
            {
                txtGradeCopyDate3.Enabled = true;
            }

            if (chkDegreeDate.Checked)
            {
                txtDegreeDate.Enabled = true;
            }

            if (chkRegisterCertificateDate3.Checked)
            {

                txtRegisterCertificateDate3.Enabled = true;
            }

            if (chkCertificateCopyDate.Checked)
            {
                txtCertificateCopyDate.Enabled = true;
            }


            if (chkNutriLicenseDate.Checked)
            {
                txtNutriLicenseDate.Enabled = true;
            }

            if (chkGradeCopyDate4.Checked)
            {
                txtGradeCopyDate4.Enabled = true;
            }

            if (chkNutriCertificateDate.Checked)
            {
                txtNutriCertificateDate.Enabled = true;
            }

            if (chkRegisterCertificateDate4.Checked)
            {
                txtRegisterCertificateDate4.Enabled = true;
            }

            if (chkPsicoLicenseDate.Checked)
            {
                txtPsicoLicenseDate.Enabled = true;
            }

            if (chkGradeCopyDate5.Checked)
            {
                txtGradeCopyDate5.Enabled = true;
            }

            if (chkCredentialsDate.Checked)
            {

                txtCredentialsDate.Enabled = true;
            }

            if (chkRegisterCertificateDate5.Checked)
            {
                txtRegisterCertificateDate5.Enabled = true;
            }

            if (chkCredentialsDate2.Checked)
            {
                txtCredentialsDate2.Enabled = true;
            }

            if (chkShareHolder.Checked)
            {
                txtShareholder.Enabled = true;
                txtShareholderNo.Enabled = true;
            }
            
            if (chkTecLicenseDatte.Checked)
            {
                txtTecLicenseDate.Enabled = true;                
            }
            if(chkGradeCopyDate5.Checked)
            {
                txtGradeCopyDate5.Enabled = true;
            }
            if (chkOptoDate.Checked)
            {
                txtOptoDate.Enabled = true;
            }
            if (chkPermanentDate.Checked)
            {
                txtPermanentDate.Enabled = true;
            }
            
          
            if (chkRegisterCertificateDate.Checked)
                txtRegisterCertificateDate.Enabled = true;
         
            if (chkMedicalPractice.Items[6].Selected)
                txtOther.Enabled = true;

            chkMedicalSchool.Enabled = true;
            chkInternship.Enabled = true;
            chkResidency.Enabled = true;
            chkFellowship.Enabled = true;
            chkCole.Enabled = true;

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
            //btnPrint.Visible = true;

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
            chkRegisterCertificateDate.Enabled = false;
            chkLicenseExoDptoDate.Enabled = false;
            chkGraduationCertificate.Enabled = false;
            chkTribunal.Enabled = false;
            chkRegisterCertificateDate.Enabled = false;
            chkGradeCopyDate.Enabled = false;
            chkShareHolder.Enabled = false;
            chkTecLicenseDatte.Enabled = false;
            chkColCertificateDate.Enabled = false;
            chkCV.Enabled = false;
            chkRegisterCertificateDate.Enabled = false;
            chkDptoLicenseDate.Enabled = false;
            chkGradeCopyDate2.Enabled = false;
            chkAudioLicenseDate.Enabled = false;
            chkJuntaCertificateDate.Enabled = false;
            chkGradeCopyDate3.Enabled = false;
            chkDegreeDate.Enabled = false;
            chkRegisterCertificateDate3.Enabled = false;
            chkNutriLicenseDate.Enabled = false;
            chkGradeCopyDate4.Enabled = false;
            chkNutriCertificateDate.Enabled = false;
            chkCertificateCopyDate.Enabled = false;
            chkRegisterCertificateDate4.Enabled = false;
            chkPsicoLicenseDate.Enabled = false;
            chkGradeCopyDate5.Enabled = false;
            chkCredentialsDate.Enabled = false;
            chkOptoDate.Enabled = false;
            chkPermanentDate.Enabled = false;
            chkRegisterCertificateDate5.Enabled = false;
            chkRegisterCertificateDate2.Enabled = false;
            chkCole.Enabled = false;
            chkCredentialsDate2.Enabled = false;


            txtRegisterCertificateDate2.Enabled = false;
            txtLicenseExoDptoDate.Enabled = false;
            txtInternGradDate.Enabled = false;
            txtGraduationCertificate.Enabled = false;
            //Nuevos
            txtColCertificateDate.Enabled = false;
            txtDptoLicenseDate.Enabled = false;
            txtGradeCopyDate2.Enabled = false;
            txtAudioLicenseDate.Enabled = false;
            txtJuntaCertificateDate.Enabled = false;
            txtGradeCopyDate3.Enabled = false;
            txtDegreeDate.Enabled = false;
            txtRegisterCertificateDate3.Enabled = false;
            txtNutriLicenseDate.Enabled = false;
            txtGradeCopyDate4.Enabled = false;
            txtNutriCertificateDate.Enabled = false;
            txtCertificateCopyDate.Enabled = false;
            txtRegisterCertificateDate4.Enabled = false;
            txtPsicoLicenseDate.Enabled = false;
            txtGradeCopyDate5.Enabled = false;
            txtCredentialsDate.Enabled = false;
            txtOptoDate.Enabled = false;
            txtPermanentDate.Enabled = false;
            txtRegisterCertificateDate5.Enabled = false;
            txtCredentialsDate2.Enabled = false;
            

            //txtTribunalDate.Enabled = false;
            txtRegisterCertificateDate.Enabled = false;
            txtLicencia.Enabled = false;
            txtGradeCopyDate.Enabled = false;
            txtMDSGradDate.Enabled = false;
            txtShareholder.Enabled = false;
            txtShareholderNo.Enabled = false;
            txtTecLicenseDate.Enabled = false;
            txtFelloshipGradDate.Enabled = false;
            ///////////////
            txtInternGradDate.Enabled = false;
            
            //txtTribunalDate.Enabled = false;
            txtMDSGradDate.Enabled = false;
            txtRegisterCertificateDate.Enabled = false;
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
                registry.LicenseExoDptoDate = txtLicenseExoDptoDate.Text.Trim();
                
                registry.GraduationCertificateDate = txtGraduationCertificate.Text.Trim();                
                //registry.TribunalExpDate = txtTribunalDate.Text.Trim();
                registry.RegisterCertificateDate = txtRegisterCertificateDate.Text.Trim();
                registry.Licencia = txtLicencia.Text.Trim();
                registry.GradeCopyDate = txtGradeCopyDate.Text;                
                registry.TecLicenseDate = txtTecLicenseDate.Text;               
                registry.LicenseExpDate = txtLicenseExpDate.Text;
                registry.MedicalSchool = txtMedicalSchool.Text;
                registry.MDSGradDate = txtMDSGradDate.Text.Trim();
                registry.Internship = txtInternship.Text;
                registry.InternGradDate = txtInternGradDate.Text.Trim();                
                registry.Residency = txtResidency.Text;
                registry.ResidencyGradDate = txtResidencyGradDate.Text.Trim();
                registry.Fellowship = txtFellowship.Text;
                registry.FellowshipGradDate = txtFelloshipGradDate.Text.Trim();
                registry.CannabisDate = txtRegisterCertificateDate2.Text.Trim();
                //Nuevos
                registry.ColCertificateDate = txtColCertificateDate.Text.Trim();
                registry.DptoLicenseDate = txtDptoLicenseDate.Text.Trim();
                registry.GradeCopyDate2 = txtGradeCopyDate2.Text.Trim();
                registry.AudioLicenseDate = txtAudioLicenseDate.Text.Trim();
                registry.JuntaCertificateDate = txtJuntaCertificateDate.Text.Trim();
                registry.GradeCopyDate3 = txtGradeCopyDate3.Text.Trim();
                registry.DegreeDate = txtDegreeDate.Text.Trim();
                registry.RegisterCertificateDate3 = txtRegisterCertificateDate3.Text.Trim();
                registry.NutriLicenseDate = txtNutriLicenseDate.Text.Trim();
                registry.GradeCopyDate4 = txtGradeCopyDate4.Text.Trim();
                registry.NutriCertificateDate = txtNutriCertificateDate.Text.Trim();
                registry.CertificateCopyDate = txtCertificateCopyDate.Text.Trim();
                registry.RegisterCertificateDate4 = txtRegisterCertificateDate4.Text.Trim();
                registry.PsicoLicenseDate = txtPsicoLicenseDate.Text.Trim();
                registry.GradeCopyDate5 = txtGradeCopyDate5.Text.Trim();
                registry.CredentialsDate = txtCredentialsDate.Text.Trim();
                registry.OptoDate = txtOptoDate.Text.Trim();
                registry.PermanentDate = txtPermanentDate.Text.Trim();
                registry.RegisterCertificateDate5 = txtRegisterCertificateDate5.Text.Trim();
                registry.CredentialsDate2 = txtCredentialsDate2.Text.Trim();
                


                


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
                        registry.MedicalPractice = chkMedicalPractice.Items[6].Value;
                    else
                        registry.MedicalPractice += "|" + chkMedicalPractice.Items[6].Value;
                        

                registry.PreviousClaims = rblPreviousClaims.SelectedIndex;
                registry.BoardCertified = rblBoardCertified.SelectedIndex;
                registry.CV = chkCV.Checked;
                registry.ColeDate = chkCole.Checked;
               // registry.JuntaLicenciamiento = chkColCertificateDate.Checked;
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
                txtLicenseExoDptoDate.Text = registry.LicenseExoDptoDate;
                txtInternGradDate.Text = registry.InternGradDate;
                if (txtLicenseExoDptoDate.Text != "")
                    chkLicenseExoDptoDate.Checked = true;

                txtGraduationCertificate.Text = registry.GraduationCertificateDate;
                txtResidencyGradDate.Text = registry.ResidencyGradDate;
                if (txtGraduationCertificate.Text != "")
                    chkGraduationCertificate.Checked = true;

                txtRegisterCertificateDate2.Text = registry.RegisterCertificateDate2;
                if (txtRegisterCertificateDate2.Text != "")
                    chkRegisterCertificateDate.Checked = true;

                //Nuevos

                txtColCertificateDate.Text = registry.ColCertificateDate;
                if (txtColCertificateDate.Text != "")
                    chkColCertificateDate.Checked = true;

                txtDptoLicenseDate.Text = registry.DptoLicenseDate;
                if (txtDptoLicenseDate.Text != "")
                    chkDptoLicenseDate.Checked = true;

                txtGradeCopyDate2.Text = registry.GradeCopyDate2;
                if (txtGradeCopyDate2.Text != "")
                    chkGradeCopyDate2.Checked = true;


                txtAudioLicenseDate.Text = registry.AudioLicenseDate;
                if (txtAudioLicenseDate.Text != "")
                    chkAudioLicenseDate.Checked = true;

                txtJuntaCertificateDate.Text = registry.JuntaCertificateDate;
                if (txtJuntaCertificateDate.Text != "")
                    chkJuntaCertificateDate.Checked = true;

                txtGradeCopyDate3.Text = registry.GradeCopyDate3;
                if (txtGradeCopyDate3.Text != "")
                    chkGradeCopyDate3.Checked = true;

                txtDegreeDate.Text = registry.DegreeDate;
                if (txtDegreeDate.Text != "")
                    chkDegreeDate.Checked = true;

                txtRegisterCertificateDate3.Text = registry.RegisterCertificateDate3;
                if (txtRegisterCertificateDate3.Text != "")
                    chkRegisterCertificateDate3.Checked = true;


                txtNutriLicenseDate.Text = registry.NutriLicenseDate;
                if (txtNutriLicenseDate.Text != "")
                    chkNutriLicenseDate.Checked = true;


                txtGradeCopyDate4.Text = registry.GradeCopyDate4;
                if (txtGradeCopyDate4.Text != "")
                    chkGradeCopyDate4.Checked = true;

                txtNutriCertificateDate.Text = registry.NutriCertificateDate;
                if (txtNutriCertificateDate.Text != "")
                    chkNutriCertificateDate.Checked = true;

                txtCertificateCopyDate.Text = registry.CertificateCopyDate;
                if (txtCertificateCopyDate.Text != "")
                    chkCertificateCopyDate.Checked = true;


                txtRegisterCertificateDate4.Text = registry.RegisterCertificateDate4;
                if (txtRegisterCertificateDate4.Text != "")
                    chkRegisterCertificateDate4.Checked = true;

                txtPsicoLicenseDate.Text = registry.PsicoLicenseDate;
                if (txtPsicoLicenseDate.Text != "")
                    chkPsicoLicenseDate.Checked = true;

                txtGradeCopyDate5.Text = registry.GradeCopyDate5;
                if (txtGradeCopyDate5.Text != "")
                    chkGradeCopyDate5.Checked = true;

                txtCredentialsDate.Text = registry.CredentialsDate;
                if (txtCredentialsDate.Text != "")
                    chkCredentialsDate.Checked = true;


                txtOptoDate.Text = registry.OptoDate;
                if (txtOptoDate.Text != "")
                    chkOptoDate.Checked = true;

                txtPermanentDate.Text = registry.PermanentDate;
                if (txtPermanentDate.Text != "")
                    chkPermanentDate.Checked = true;


                txtRegisterCertificateDate2.Text = registry.RegisterCertificateDate2;
                if (txtRegisterCertificateDate2.Text != "")
                    chkRegisterCertificateDate2.Checked = true;

                txtRegisterCertificateDate5.Text = registry.RegisterCertificateDate5;
                if (txtRegisterCertificateDate5.Text != "")
                    chkRegisterCertificateDate5.Checked = true;


                txtCredentialsDate2.Text = registry.CredentialsDate2;
                if (txtCredentialsDate2.Text != "")
                    chkCredentialsDate2.Checked = true;


                txtRegisterCertificateDate.Text = registry.RegisterCertificateDate;
                txtLicencia.Text = registry.RegisterCertificateDate;
                if (txtRegisterCertificateDate.Text != "")
                    chkRegisterCertificateDate.Checked = true;

                txtGradeCopyDate.Text = registry.GradeCopyDate;
                if (txtGradeCopyDate.Text != "")
                    chkGradeCopyDate.Checked = true;

                txtMDSGradDate.Text = registry.MDSGradDate;


                txtTecLicenseDate.Text = registry.TecLicenseDate;
                txtFelloshipGradDate.Text = registry.TecLicenseDate;
                if (txtTecLicenseDate.Text != "")
                    chkTecLicenseDatte.Checked = true;

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

                if (registry.MedicalPractice.Contains("Enfermeras Graduadas"))
                    chkMedicalPractice.Items[0].Selected = true;
                else
                    chkMedicalPractice.Items[0].Selected = false;

                if (registry.MedicalPractice.Contains("Tecnólogos Médicos"))
                    chkMedicalPractice.Items[1].Selected = true;
                else
                    chkMedicalPractice.Items[1].Selected = false;

                if (registry.MedicalPractice.Contains("Técnicos de Rayos X"))
                    chkMedicalPractice.Items[2].Selected = true;
                else
                    chkMedicalPractice.Items[2].Selected = false;

                if (registry.MedicalPractice.Contains("Audiológos y Patólogos del Habla"))
                    chkMedicalPractice.Items[3].Selected = true;
                else
                    chkMedicalPractice.Items[3].Selected = false;

                if (registry.MedicalPractice.Contains("Nutricionistas y Dietistas"))
                    chkMedicalPractice.Items[4].Selected = true;
                else
                    chkMedicalPractice.Items[4].Selected = false;

                if (registry.MedicalPractice.Contains("Psicólogos"))
                    chkMedicalPractice.Items[5].Selected = true;
                else
                    chkMedicalPractice.Items[5].Selected = false;

                if (registry.MedicalPractice.Contains("Optómetras"))
                    chkMedicalPractice.Items[6].Selected = true;
                else
                    chkMedicalPractice.Items[6].Selected = false;


                //string[] line = registry.MedicalPractice.Split('|');
                //int size = line.Length - 1;

                //if (line[size] != "Solo Physician" &&
                //    line[size] != "Employed Physician" &&
                //    line[size] != "Partnership" &&
                //    line[size] != "Group Member" &&
                //    line[size] != "Professional Association" &&
                //    line[size] != "Professional Corporation" &&
                //    line[size] != "")
                //{
                //    chkMedicalPractice.Items[6].Selected = true;
                //    txtOther.Text = line[size];
                //}
                //else
                //    chkMedicalPractice.Items[6].Selected = false;

                rblPreviousClaims.SelectedIndex = registry.PreviousClaims;
                rblBoardCertified.SelectedIndex = registry.BoardCertified;

                chkCV.Checked = registry.CV;
                chkColCertificateDate.Checked = registry.JuntaLicenciamiento;
                chkCole.Checked = registry.ColeDate;

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
                if (txtLicenseExoDptoDate.Text != "")
                {
                    compareResult = DateTime.Compare(DateTime.Parse(txtLicenseExoDptoDate.Text.Trim()), DateTime.Now);

                    if (compareResult < 0)
                    {
                        assmcadate = "(EXP) " + txtLicenseExoDptoDate.Text.Trim();
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
                if (chkColCertificateDate.Checked)
                    juntaLicenciamiento = "";
                else
                    juntaLicenciamiento = "X";

                if (txtGradeCopyDate.Text != "")
                {
                    compareResult = DateTime.Compare(DateTime.Parse(txtGradeCopyDate.Text.Trim()), DateTime.Now);

                    if (compareResult < 0)
                    {
                        cdmdate = "(EXP) " + txtGradeCopyDate.Text.Trim();
                    }
                }
                else
                    cdmdate = "X";
                if (txtTecLicenseDate.Text != "")
                {
                    compareResult = DateTime.Compare(DateTime.Parse(txtTecLicenseDate.Text.Trim()), DateTime.Now);

                    if (compareResult < 0)
                    {
                        gstandingdate = "(EXP) " + txtTecLicenseDate.Text.Trim();
                    }
                }
                else
                    gstandingdate = "X";
                if (txtRegisterCertificateDate.Text != "")
                {
                    compareResult = DateTime.Compare(DateTime.Parse(txtRegisterCertificateDate.Text.Trim()), DateTime.Now);

                    if (compareResult < 0)
                    {
                        licenseexpdate = "(EXP) " + txtRegisterCertificateDate.Text.Trim();
                    }
                }
                else
                    licenseexpdate = "X";
                if (txtGraduationCertificate.Text != "")
                {
                    compareResult = DateTime.Compare(DateTime.Parse(txtGraduationCertificate.Text.Trim()), DateTime.Now);

                    if (compareResult < 0)
                    {
                        deadate = "(EXP) " + txtGraduationCertificate.Text.Trim();
                    }
                }
                else
                    deadate = "X";

                if (txtRegisterCertificateDate.Text != "")
                {
                    compareResult = DateTime.Compare(DateTime.Parse(txtRegisterCertificateDate.Text.Trim()), DateTime.Now);

                    if (compareResult < 0)
                    {
                        registroMedico = "(EXP) " + txtRegisterCertificateDate.Text.Trim();
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

            if (txtLicenseExoDptoDate.Text != "") 
            {
                if (DateTime.TryParse(txtLicenseExoDptoDate.Text, out temp))
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

            if (txtGraduationCertificate.Text != "") 
            {
                if (DateTime.TryParse(txtGraduationCertificate.Text, out temp))
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

            if (txtGradeCopyDate.Text != "")
            {
                if (DateTime.TryParse(txtGradeCopyDate.Text, out temp))
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

            if (txtTecLicenseDate.Text != "") 
            {
                if (DateTime.TryParse(txtTecLicenseDate.Text, out temp))
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

            if (txtLicenseExpDate.Text == "" && txtLicenseExoDptoDate.Text == "" && txtGraduationCertificate.Text == "" && txtGradeCopyDate.Text == "" && txtTecLicenseDate.Text == "")
                validated = true;

            return validated;
        }
}

}
