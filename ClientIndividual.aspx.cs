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
//using CalendarButton;
using EPolicy.Customer;
using EPolicy;
using Baldrich.DBRequest;
using EPolicy2.Reports;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.LookupTables;
using System.Text.RegularExpressions;
using Baldrich.DBRequest;
using EPolicy.XmlCooker;
using System.Xml;

namespace EPolicy
{
	/// <summary>
	/// Summary description for ClientIndividual.
	/// </summary>
	public partial class ClientIndividual : System.Web.UI.Page
	{
		protected string today = DateTime.Now.ToString("MM/dd/yyyy");
		protected System.Web.UI.WebControls.Label lblHomeUrb1;
		
        private DataTable DtTask;

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);

			Control Banner = new Control();
			Banner = LoadControl(@"TopBanner1.ascx");
			this.Placeholder1.Controls.Add(Banner);

			/*//Setup Left-side Banner
			Control LeftMenu = new Control();
			LeftMenu = LoadControl(@"LeftMenu.ascx");
			this.phTopBanner1.Controls.Add(LeftMenu);*/

			//Load DownDropList
	
			DataTable dtMaritalStatus	= LookupTables.LookupTables.GetTable("MaritalStatus");
			DataTable dtMasterCustomer	= LookupTables.LookupTables.GetTable("MasterCustomer");
			DataTable dtOccupations		= LookupTables.LookupTables.GetTable("Occupations");
			DataTable dtHouseHoldIncome = LookupTables.LookupTables.GetTable("HouseHoldIncome");
			DataTable dtLocation		= LookupTables.LookupTables.GetTable("Location");
			DataTable dtRelatedTo       = LookupTables.LookupTables.GetTable("RelatedTo");
			DataTable dtGender          = LookupTables.LookupTables.GetTable("Gender");

			//MaritalStatus
			ddlMaritalStatus.DataSource = dtMaritalStatus;
			ddlMaritalStatus.DataTextField = "MaritalStatusDesc";
			ddlMaritalStatus.DataValueField = "MaritalStatusID";
			ddlMaritalStatus.DataBind();
			ddlMaritalStatus.SelectedIndex = -1;
			ddlMaritalStatus.Items.Insert(0,"");

			//Occupations
			ddlOccupation.DataSource = dtOccupations;
			ddlOccupation.DataTextField  = "OccupationsDesc";
			ddlOccupation.DataValueField = "OccupationsID";
			ddlOccupation.DataBind();
			ddlOccupation.SelectedIndex = -1;
			ddlOccupation.Items.Insert(0,"");
	
			//MasterCustomer
			ddlMasterCustomer.DataSource = dtMasterCustomer;
			ddlMasterCustomer.DataTextField = "MasterCustomerDesc";
			ddlMasterCustomer.DataValueField = "MasterCustomerID";
			ddlMasterCustomer.DataBind();
			ddlMasterCustomer.SelectedIndex = -1;
			ddlMasterCustomer.Items.Insert(0,"");

			//HouseHoldIncome
			ddlHouseIncome.DataSource = dtHouseHoldIncome;
			ddlHouseIncome.DataTextField = "HouseholdIncomeDesc";
			ddlHouseIncome.DataValueField = "HouseholdIncomeID";
			ddlHouseIncome.DataBind();
			ddlHouseIncome.SelectedIndex = -1;
			ddlHouseIncome.Items.Insert(0,"");

			//Location (Originated At)
			ddlOriginatedAt.DataSource = dtLocation;
			ddlOriginatedAt.DataTextField = "LocationDesc";
			ddlOriginatedAt.DataValueField = "LocationID";
			ddlOriginatedAt.DataBind();

			//RelatedTo
			ddlRelatedTo.DataSource = dtRelatedTo;
			ddlRelatedTo.DataTextField  = "RelatedToDesc";
			ddlRelatedTo.DataValueField = "RelatedToID";
			ddlRelatedTo.DataBind();
			ddlRelatedTo.SelectedIndex = -1;
			ddlRelatedTo.Items.Insert(0,"");

			//Gender
			ddlGender.DataSource = dtGender;
			ddlGender.DataTextField = "GenderDesc";
			ddlGender.DataValueField = "GenderID";
			ddlGender.DataBind();
			ddlGender.SelectedIndex = -1;
			ddlGender.Items.Insert(0,"");

            txtInsuredtype.SelectedIndex = -1;
            txtInsuredtype.Items.Insert(0, "");
                                            
            ddlreferredby.SelectedIndex = -1;
            ddlreferredby.Items.Insert(0, "");

            ddlstatus.SelectedIndex = -1;
            ddlstatus.Items.Insert(0, "");

            ddlprostatus.SelectedIndex = -1;
            ddlprostatus.Items.Insert(0, "");
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			Login.Login cp = HttpContext.Current.User as Login.Login;
            if (cp == null)
            {
                Response.Redirect("Default.aspx?001");
            }
            else
            {
                if (!cp.IsInRole("CLIENTINDIVIDUAL") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    Response.Redirect("Default.aspx?001");
                }
            }


			txtBirthdate.Attributes.Add("onchange","getAge()");

			this.litPopUp.Visible = false;

			if(Session["AutoPostBack"] == null)
			{
				if(!IsPostBack)
				{
					if(Session["Customer"] != null)
					{
						Customer.Customer customer = (Customer.Customer) Session["Customer"];

						switch(customer.Mode)
						{
							case 1: //ADD
								FillTextControl();
								EnableControls();
								DisableAutomaticCustNo();
								break;
							
							case 2: //UPDATE
								FillTextControl();
								EnableControls();
								break;

							default: //UPDATE
								if (customer.NavegationCustomerTable == null)
								{
									FillTextControl();
								}
								else
								{
									NavegationCustomers("");
								}

								DisableControls();
								break;
						}
					}
				}
				else
				{
					if(Session["Customer"] != null)
					{
						Customer.Customer customer = (Customer.Customer) Session["Customer"];
						if(customer.Mode == 4)
						{
							DisableControls();
						}
					}
				}
			}
			else
			{
				if(Session["AutoPostBack"] == null)
				{
					NavegationCustomers("");
				}

				FillTextControl();				
				EnableControls();
				Session.Remove("AutoPostBack");
			}
		}

        private void FillDataGrid()
        {
            Customer.Customer customer = (Customer.Customer)Session["Customer"];

            LblError.Visible = false;
            searchIndividual.DataSource = null;
            DtTask = null;

            DtTask = TaskControl.TaskControl.GetTaskControlByCustomerNo(customer.CustomerNo);

            Session.Remove("DtTask");
            Session.Add("DtTask", DtTask);

            if (DtTask.Rows.Count != 0)
            {
                searchIndividual.DataSource = DtTask;
                searchIndividual.DataBind();
            }
            else
            {
                searchIndividual.DataSource = null;
                searchIndividual.DataBind();

                //LblError.Visible = true;
                LblError.Text = "Could not find a match for your search criteria, please try again.";
            }

            LblTotalCases.Text = "Total Cases: " + DtTask.Rows.Count.ToString();
        }

		private void FillTextControl()
		{
			Customer.Customer customer = (Customer.Customer) Session["Customer"];

            if (customer.SocialSecurity == "" && customer.EmployerSocialSecurity == "")
                btnShow.Visible = false;
            else
                btnShow.Visible = true;

            BtnActivateDeleteSoSec.Visible = false;
                

            FillDataGrid();

			//MaritalStatus
			ddlMaritalStatus.SelectedIndex = 0;
			if(customer.MaritalStatus != 0)
			{
				for(int i = 0;ddlMaritalStatus.Items.Count-1 >= i ;i++)
				{
					if (ddlMaritalStatus.Items[i].Value == customer.MaritalStatus.ToString())
					{
						ddlMaritalStatus.SelectedIndex = i;
						i = ddlMaritalStatus.Items.Count-1;
					}
				}
			}
				
			//Occupations
			ddlOccupation.SelectedIndex = 0;
			if(customer.OccupationID != 0)
			{
				for(int i = 0;ddlOccupation.Items.Count-1 >= i ;i++)
				{
					if(ddlOccupation.Items[i].Value == customer.OccupationID.ToString())
					{
						ddlOccupation.SelectedIndex = i;
						i = ddlOccupation.Items.Count-1;
					}
				}

				if(customer.OccupationID == 40) //Others
				{
					txtOtherOccupation.Visible  = true;
					txtOtherOccupation.Text		= customer.Occupation;
				}
				else
				{
					txtOtherOccupation.Visible  = false;
					txtOtherOccupation.Text		= "";
				}
			}

			//MasterCustomer
			ddlMasterCustomer.SelectedIndex = 0;
			if(customer.MasterCustomer != 0)
			{
				for(int i = 0;ddlMasterCustomer.Items.Count-1 >= i ;i++)
				{
					if (ddlMasterCustomer.Items[i].Value == customer.MasterCustomer.ToString())
					{
						ddlMasterCustomer.SelectedIndex = i;
						i = ddlMasterCustomer.Items.Count-1;
					}
				}
			}

			//HouseHoldIncome
			ddlHouseIncome.SelectedIndex = 0;
			if(customer.HouseHoldIncome != 0)
			{
				for(int i = 0;ddlHouseIncome.Items.Count-1 >= i ;i++)
				{
					if (ddlHouseIncome.Items[i].Value == customer.HouseHoldIncome.ToString())
					{
						ddlHouseIncome.SelectedIndex = i;
						i = ddlHouseIncome.Items.Count-1;
					}
				}
			}

			//Location (Originated At)
			ddlOriginatedAt.SelectedIndex = -1;
			if(customer.LocationID != 0)
			{
				for(int i = 0;ddlOriginatedAt.Items.Count-1 >= i ;i++)
				{
					if (ddlOriginatedAt.Items[i].Value == customer.LocationID.ToString())
					{
						ddlOriginatedAt.SelectedIndex = i;
						i = ddlOriginatedAt.Items.Count-1;
					}
				}				
			}

			//RelatedTo
			ddlRelatedTo.SelectedIndex = 0;
			if(customer.RelatedToID != 0)
			{
				for(int i = 0;ddlRelatedTo.Items.Count-1 >= i ;i++)
				{
					if (ddlRelatedTo.Items[i].Value == customer.RelatedToID.ToString())
					{
						ddlRelatedTo.SelectedIndex = i;
						i = ddlRelatedTo.Items.Count-1;
					}
				}
			}

					
			int mSex =0;
			if (customer.Sex !="")
			{
				if (customer.Sex == "M")
				{
					mSex = 1;
				}
				else
				{
					mSex = 2;
				}
			}
			else
			{
				mSex = 0;
			}

			//Gender
			ddlGender.SelectedIndex = 0;
			if(mSex != 0)
			{
				for(int i = 0;ddlGender.Items.Count-1 >= i ;i++)
				{
					if (ddlGender.Items[i].Value == mSex.ToString())
					{
						ddlGender.SelectedIndex = i;
						i = ddlGender.Items.Count-1;
					}
				}
			}

			if (customer.NoticeCancellation)
			{
				ChkNoticeOfCancellation.Checked = true;
			}
			else
			{
				ChkNoticeOfCancellation.Checked = false;
			}
			
			ChkOptOut.Checked		= customer.OptOut;

			if(customer.ProspectID != 0)
			{
				LblProspectID.Text		= "Prospect: " + customer.ProspectID.ToString();
			}
			else
			{
				LblProspectID.Text		= "Prospect: None";
			}

			lblCustNumber.Text		= customer.CustomerNo;
			TxtFirstName.Text		= customer.FirstName;
			TxtInitial.Text			= customer.Initial;
			txtLastname1.Text		= customer.LastName1;
			txtLastname2.Text		= customer.LastName2;
	 					
			bool skip = false;
  
			/*if (LoadVerifyAddress())
			{
				skip = true;
			}
	*/
			if (skip==false)
			{
				customer = (Customer.Customer) Session["Customer"];
				txtHomeUrb1.Text		= customer.Address1.Trim();
				txtAddress1.Text     	= customer.Address2.Trim();
				txtCity.Text			= customer.City.Trim();
				txtState.Text			= customer.State.Trim();
				txtZipCode.Text			= customer.ZipCode.Trim();
			}

			txtAddress1Phys.Text	= customer.AddressPhysical1.Trim();
			txtAddress2Phys.Text	= customer.AddressPhysical2.Trim();
			txtCityPhys.Text    = customer.CityPhysical.Trim();
			txtStatePhys.Text   = customer.StatePhysical.Trim();
			txtZipCodePhys.Text		= customer.ZipPhysical.Trim();

			if(txtAddress2Phys.Text.Trim() == txtAddress1.Text.Trim() && (txtAddress2Phys.Text.Trim() != "" && txtAddress1.Text.Trim() != ""))
			{
				chkSameAddr.Checked = true;
			}
			else
			{
				chkSameAddr.Checked = false;
			}

			//txtSocialSecurity.Text	= customer.SocialSecurity;
			txtBirthdate.Text		= customer.Birthday;
			TxtAge.Text				= customer.Age;
			txtWorkName.Text		= customer.EmplName;
			TxtWorkCity.Text		= customer.EmplCity;
			txtHomePhone.Text		= customer.HomePhone;
			txtWorkPhone.Text		= customer.JobPhone;
			TxtCellular.Text		= customer.Cellular;
			txtEmail.Text			= customer.Email;
			txtComments.Text		= customer.Comments;
			TxtLicence.Text			= customer.Licence;
            TxtCustomerNo.Text      = customer.CustomerNo;
            TxtProspectID.Text      = customer.ProspectID.ToString();
            //----
            
            txtCustPreferedCommID.Text = customer.Communication;
            txtWebsite2.Text = customer.Website;
            txtInsuredtype.Text = customer.Insuredtype;
            txtCorpName.Text = customer.CorpName;
            ddlAmscaOrDEA2.Text = customer.AmscaOrDEA;
            txtNPI.Text = customer.NPI;

            txtemail2.Text = customer.Email2;
            txtquoted.Text = customer.Quoted2;
            txtlicexpdate.Text = customer.Licexpdate;
            txtfax.Text = customer.Fax;
            txtcontoclient.Text = customer.Convertto;
            ddlreferredby.Text = customer.Referedby;
            ddlstatus.Text = customer.Status;
            txtleadid.Text = customer.Leadid;
            txtagentid.Text = customer.Agentid;
            txtinterestedin.Text = customer.InterestedIN;
     
            ddlprostatus.Text = customer.Prostatus;

            if (customer.Ssnselect == "")
                chkssnselect.SelectedIndex = -1;
            if (customer.Ssnselect == "0")
                chkssnselect.SelectedIndex = 0;
            if (customer.Ssnselect == "1")
                chkssnselect.SelectedIndex = 1;


            //chkssnselect.Text = customer.Ssnselect;
            txtssnpin.Text = customer.Ssnpin;

            ddlAmscaOrDEA3.Text = customer.AmscaorDea3;
            //------

            EncryptClass.EncryptClass encrypt = new EncryptClass.EncryptClass();
            //if (customer.SocialSecurity.Trim() != "")
            //{
            //    txtSocialSecurity.Text = encrypt.Decrypt(customer.SocialSecurity);
            //    txtSocialSecurity.Text = new string('*', txtSocialSecurity.Text.Trim().Length - 4) + txtSocialSecurity.Text.Trim().Substring(txtSocialSecurity.Text.Trim().Length - 4);
            //    MaskedEditExtenderSS.Mask = "???-??-9999";

            //}
            //else
            //    txtSocialSecurity.Text = "";

            //if (customer.EmployerSocialSecurity.Trim() != "")
            //{
            //    txtEmployerSocSec.Text = encrypt.Decrypt(customer.EmployerSocialSecurity);
            //    txtEmployerSocSec.Text = new string('*', txtEmployerSocSec.Text.Trim().Length - 4) + txtEmployerSocSec.Text.Trim().Substring(txtEmployerSocSec.Text.Trim().Length - 4);
            //    MaskedEditExtenderSS2.Mask = "???-??-9999";

            //}
            //else
            //    txtEmployerSocSec.Text = "";
		}

		protected void ddlOccupation_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(ddlOccupation.SelectedItem.Value == "40") //Others
			{
				txtOtherOccupation.Visible  = true;
				txtOtherOccupation.Text		= "";
			}
			else
			{
				txtOtherOccupation.Visible  = false;
				txtOtherOccupation.Text		= "";
			}
		}

		private void UpdatedProspectData(Customer.Prospect prospect, Customer.Customer customer, int userID)
		{
			//Actualizo la data del prospecto.
			prospect.ConvertToClient = DateTime.Now;
			prospect.FirstName	= customer.FirstName;
			prospect.LastName1	= customer.LastName1;
			prospect.LastName2	= customer.LastName2;
			prospect.WorkPhone	= customer.JobPhone;
			prospect.HomePhone	= customer.HomePhone;
			prospect.Cellular	= customer.Cellular;
			prospect.Email		= customer.Email;

			prospect.SaveProspect(userID);
		}

		private void FillProperties()
		{
			Customer.Customer customer = (Customer.Customer) Session["Customer"];

			//Asigna el customer no. manualmente.
			if (ChkDisableAutomaticCustNo.Checked)
			{
				customer.DisableAutomaticCustNo = ChkDisableAutomaticCustNo.Checked;
				customer.CustomerNo			= TxtCustomerNo.Text.Trim().ToUpper();
			}
			else
			{
				customer.DisableAutomaticCustNo = ChkDisableAutomaticCustNo.Checked;
			}

			if(Session["Prospect"] !=null)
			{
				Customer.Prospect prospect = (Customer.Prospect) Session["Prospect"];

				customer.ProspectID		= prospect.ProspectID;
				
				Session["Prospect"]		= prospect;
			}

			customer.FirstName			= TxtFirstName.Text.Trim().ToUpper();
			customer.Initial			= TxtInitial.Text.Trim().ToUpper();
			customer.LastName1			= txtLastname1.Text.Trim().ToUpper();
			customer.LastName2			= txtLastname2.Text.Trim().ToUpper();
			customer.Address1			= txtHomeUrb1.Text.Trim().ToUpper();
			customer.Address2			= txtAddress1.Text.Trim().ToUpper();
			customer.City				= txtCity.Text.Trim().ToUpper();
			customer.State				= txtState.Text.Trim().ToUpper();
			customer.ZipCode			= txtZipCode.Text.Trim().ToUpper();
			customer.AddressPhysical1	= txtAddress1Phys.Text.Trim().ToUpper();
			customer.AddressPhysical2	= txtAddress2Phys.Text.Trim().ToUpper();
			customer.CityPhysical		= txtCityPhys.Text.Trim().ToUpper();
			customer.StatePhysical		= txtStatePhys.Text.Trim().ToUpper();
			customer.ZipPhysical		= txtZipCodePhys.Text.Trim();

            
            customer.Communication      = txtCustPreferedCommID.Text.Trim().ToUpper();
            customer.Website            = txtWebsite2.Text.Trim().ToUpper();
            customer.Insuredtype = txtInsuredtype.Text.Trim();
            customer.CorpName           = txtCorpName.Text.Trim().ToUpper();
            customer.AmscaOrDEA = ddlAmscaOrDEA2.Text.Trim();
            customer.NPI                = txtNPI.Text.Trim().ToUpper();

            customer.Prostatus = ddlprostatus.Text.Trim();
            customer.Ssnpin = txtssnpin.Text.Trim();

            if (chkssnselect.SelectedItem != null)
                customer.Ssnselect = chkssnselect.SelectedItem.Value.Trim();
            else
                customer.Ssnselect = "";

            customer.Email2 = txtemail2.Text.Trim();
            customer.Quoted2 = txtquoted.Text.Trim();
            customer.Licexpdate = txtlicexpdate.Text.Trim();
            customer.Fax = txtfax.Text.Trim();
            customer.Convertto = txtcontoclient.Text.Trim();
            customer.Referedby = ddlreferredby.Text.Trim();
            customer.Status = ddlstatus.Text.Trim();
            customer.Leadid = txtleadid.Text.Trim();
            customer.Agentid = txtagentid.Text.Trim();
            customer.InterestedIN = txtinterestedin.Text.Trim();
            customer.AmscaorDea3 = ddlAmscaOrDEA3.Text.Trim();

//			switch (ddlGender.SelectedItem.Text)
//			{
//				case "MALE":
//					customer.Sex = "M";  //1
//					break;
//
//				case "FEMALE":
//					customer.Sex = "F"; //2
//					break;
//
//				case "":
//					customer.Sex = "";
//					break;
//			}

			string gen;
			if (ddlGender.SelectedItem.Value == "")
			{
				gen = "0";
			}
			else				
			{
				gen = ddlGender.SelectedItem.Value;
			}

			switch (int.Parse(gen))
			{
				case 1:
					customer.Sex = "M";  //1
					break;

				case 2:
					customer.Sex = "F"; //2
					break;

				default:
					customer.Sex = "";
					break;
			}

			//= System.DBNull.Value)?(int) customer._dtCustomer.Rows[0]["HouseHoldIncome"]:0;
			
            customer.OccupationID   = ddlOccupation.SelectedItem.Value != "" ? int.Parse(ddlOccupation.SelectedItem.Value):0;
			customer.Occupation		= txtOtherOccupation.Text.Trim().ToUpper();
			customer.HouseHoldIncome= ddlHouseIncome.SelectedItem.Value != "" ?int.Parse(ddlHouseIncome.SelectedItem.Value):0;
			customer.MaritalStatus	= ddlMaritalStatus.SelectedItem.Value != "" ?int.Parse(ddlMaritalStatus.SelectedItem.Value):0;
			customer.MasterCustomer = ddlMasterCustomer.SelectedItem.Value != "" ?int.Parse(ddlMasterCustomer.SelectedItem.Value):0;
			//customer.SocialSecurity	= txtSocialSecurity.Text.Trim();
			customer.Birthday		= txtBirthdate.Text;
			customer.Age			= TxtAge.Text.Trim();
			customer.EmplName		= txtWorkName.Text.Trim().ToUpper();
			customer.EmplCity		= TxtWorkCity.Text.Trim().ToUpper();
			customer.HomePhone		= txtHomePhone.Text.Trim();
			customer.JobPhone		= txtWorkPhone.Text.Trim();
			customer.Cellular		= TxtCellular.Text.Trim();
			customer.Email			= txtEmail.Text.Trim().ToUpper();
            //------
            customer.Communication  = txtCustPreferedCommID.Text.Trim().ToUpper();
            customer.Website        = txtWebsite2.Text.Trim().ToUpper();
            customer.Insuredtype = txtInsuredtype.Text.Trim();
            customer.CorpName       = txtCorpName.Text.Trim().ToUpper();
            customer.AmscaOrDEA = ddlAmscaOrDEA2.Text.Trim();
            customer.NPI            = txtNPI.Text.Trim().ToUpper();

            //-------
			customer.Comments		= txtComments.Text.Trim().ToUpper();
			customer.LocationID		= ddlOriginatedAt.SelectedItem.Value != "" ?int.Parse(ddlOriginatedAt.SelectedItem.Value):0;	
			customer.OptOut			= ChkOptOut.Checked;
			customer.RelatedToID    = ddlRelatedTo.SelectedItem.Value != "" ? int.Parse(ddlRelatedTo.SelectedItem.Value):0;
			customer.Licence		= TxtLicence.Text.Trim();

            customer.Prostatus = ddlprostatus.Text.Trim();
            customer.Ssnselect = chkssnselect.Text.Trim();
            customer.Ssnpin = txtssnpin.Text.Trim();

            customer.Email2 = txtemail2.Text.Trim();
            customer.Quoted2 = txtquoted.Text.Trim();
            customer.Licexpdate = txtlicexpdate.Text.Trim();
            customer.Fax = txtfax.Text.Trim();
            customer.Convertto = txtcontoclient.Text.Trim();
            customer.Referedby = ddlreferredby.Text.Trim();
            customer.Status = ddlstatus.Text.Trim();
            customer.Leadid = txtleadid.Text.Trim();
            customer.Agentid = txtagentid.Text.Trim();
            customer.InterestedIN = txtinterestedin.Text.Trim();
            customer.AmscaorDea3 = ddlAmscaOrDEA3.Text.Trim(); 


			if (ChkNoticeOfCancellation.Checked)
			{
				customer.NoticeCancellation = true;
			}
			else
			{
				customer.NoticeCancellation = false;
			}

            EncryptClass.EncryptClass encrypt = new EncryptClass.EncryptClass();
            //--------------------------------------------------------------------------
            if (customer.SocialSecurity != "")
            {
                if (txtSocialSecurity.Text.Replace("_", "").Replace("(", "").Replace(")", "").Replace("-", "") != "" && !txtSocialSecurity.Text.Contains("*"))
                {
                    string emp2 = txtSocialSecurity.Text.Replace("-", "").Trim();

                    if (emp2.Trim() == encrypt.Decrypt(customer.SocialSecurity))
                    {
                        customer.SocialSecurity = customer.SocialSecurity.Trim();

                    }

                    else
                    {
                        customer.SocialSecurity = encrypt.Encrypt(emp2.Trim());
                    }
                }
            }
            else
            {
                if (txtSocialSecurity.Text.Trim().Replace("_", "").Replace("(", "").Replace(")", "").Replace("-", "") != "")
                {
                    string encryptString = txtSocialSecurity.Text.Replace("-", "").Trim();
                    customer.SocialSecurity = encrypt.Encrypt(encryptString);
                }
                else
                    customer.SocialSecurity = "";
            }
            //--------------------------------------------------------------------------
            if (customer.EmployerSocialSecurity != "" && !txtSocialSecurity.Text.Contains("*"))
            {
                if (txtEmployerSocSec.Text.Replace("_", "").Replace("(", "").Replace(")", "").Replace("-", "") != "")
                {
                    string emp = txtEmployerSocSec.Text.Replace("-", "").Trim();

                    if (emp.Trim() == encrypt.Decrypt(customer.EmployerSocialSecurity))
                    {
                      customer.EmployerSocialSecurity = customer.EmployerSocialSecurity.Trim();

                    }
                    
                    else
                    {
                        customer.EmployerSocialSecurity = encrypt.Encrypt(emp.Trim());
                    }
                }


            }
            else
            {
                if (txtEmployerSocSec.Text.Replace("_", "").Replace("(", "").Replace(")", "").Replace("-", "") != "")
                {
                    string encryptString = txtEmployerSocSec.Text.Replace("-", "").Trim();
                    customer.EmployerSocialSecurity = encrypt.Encrypt(encryptString);
                }
                else
                    customer.EmployerSocialSecurity = "";
            }

			Session.Add("Customer",customer);
		}

		private bool LoadVerifyAddress()
		{
			if ((Convert.ToString(Session["Address1"])!= ""))
			{
				if(Convert.ToString(Session["ZipCode"]) != "") 
				{
					//this.txtAddress1.Text = Convert.ToString(Session["Address1"]);
					//this.txtAddress2.Text = Convert.ToString(Session["Address2"]);
					this.txtAddress1.Text = Convert.ToString(Session["Address2"]);
					this.txtAddress2.Text = Convert.ToString(Session["Address2"]);
					this.txtCity.Text     = Convert.ToString(Session["CityName"]);
					this.txtState.Text    = "PR";
					this.txtZipCode.Text  = Convert.ToString(Session["ZipCode"]);
					this.txtHomeUrb1.Text = Convert.ToString(Session["UrbName"]);
					//this.txtZipCode.Text  = oAddressLookup.MemoryZipCode + "-" + oAddressLookup.Zip4;
			
					//Session.Remove("Address1");
					Session.Remove("Address2");
					Session.Remove("CityName");
					Session.Remove("ZipCode");
					Session.Remove("AddressType");
					Session.Remove("UrbName");
				}
				return (true);
			}
			return (false);
		}

		protected void chkSameAddr_CheckedChanged(object sender, System.EventArgs e)
		{
			SameAsPostal();
		}

		private void SameAsPostal()
		{
			if(chkSameAddr.Checked == true)
			{
				txtAddress1Phys.Text	= txtHomeUrb1.Text.Trim();
				txtAddress2Phys.Text	= txtAddress1.Text.Trim(); //txtAddress2.Text.Trim();
				txtCityPhys.Text		= txtCity.Text.Trim();
				txtStatePhys.Text		= txtState.Text.Trim();
				txtZipCodePhys.Text		= txtZipCode.Text.Trim();
			}
		}

		private void EnableControls()
		{
            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

			ChkDisableAutomaticCustNo.Visible = false;
			TxtCustomerNo.Visible			  = false;

			btnEdit.Visible		  = false;
            btnDelete.Visible = false;
            btnNew.Visible = false;
            if (userID == 156 || userID == 1 || userID == 238 || userID == 271 || userID == 314) //Temp Override for Kayla
            {
                BtnUpdate.Visible = true;
                Label22.Visible = false;
                Label23.Visible = false;
                TxtCustomerNo.Visible = false;
                TxtProspectID.Visible = false;
            }

            btnCancel.Visible     = true;
			BtnExit.Visible		  = false;
			btnProfile.Visible	  = false;
			BtnSave.Visible		  = true;
			btnAuditTrail.Visible = false;
			BtnViewTask.Visible   = false;
            btnQuotes.Visible = false;
            btnAssignCustNo.Visible = false;
            txtControlNo.Visible = false;

			ChkOptOut.Enabled		= true;
			ChkNoticeOfCancellation.Enabled = true;
			chkSameAddr.Enabled		= true;

			ddlGender.Enabled         = true;
			ddlMaritalStatus.Enabled  = true;
			ddlOccupation.Enabled     = true;
			ddlHouseIncome.Enabled    = true;
			ddlOriginatedAt.Enabled   = true;
			ddlMasterCustomer.Enabled = true;
			ddlRelatedTo.Enabled      = true;

			txtOtherOccupation.Enabled = true;
			TxtFirstName.Enabled	= true;
			TxtInitial.Enabled		= true;
			txtLastname1.Enabled	= true;
			txtLastname2.Enabled	= true;
			txtBirthdate.Enabled	= true;
			TxtAge.Enabled			= true;
			txtComments.Enabled	    = true;
			txtHomePhone.Enabled	= true;
			txtWorkPhone.Enabled	= true;
			TxtCellular.Enabled  	= true;
			txtEmail.Enabled		= true;
            //----------
            txtCustPreferedCommID.Enabled = true;
            txtWebsite2.Enabled = true;
            txtInsuredtype.Enabled = true;
            txtCorpName.Enabled = true;
            ddlAmscaOrDEA2.Enabled = true;
            txtNPI.Enabled = true;

            ddlprostatus.Enabled = true;
            chkssnselect.Enabled = true;
            txtssnpin.Enabled = true;

            txtemail2.Enabled = true;
            txtquoted.Enabled = true;
            txtlicexpdate.Enabled = true;
            txtfax.Enabled = true;
            txtcontoclient.Enabled = true;
            ddlreferredby.Enabled = true;
            ddlstatus.Enabled = true;
            txtleadid.Enabled = true;
            txtagentid.Enabled = true;
            txtinterestedin.Enabled = true;
            ddlAmscaOrDEA3.Enabled = true;
            //-----------
			txtWorkName.Enabled	    = true;
			TxtWorkCity.Enabled	    = true;
			txtSocialSecurity.Enabled = true;
            txtEmployerSocSec.Enabled = true;
 
			txtHomeUrb1.Enabled	    = true;
			txtAddress1.Enabled	    = true;
			txtAddress2.Enabled	    = true;
			txtCity.Enabled		    = true;
			txtState.Enabled		= true;
			txtZipCode.Enabled		= true;
			txtAddress1Phys.Enabled = true;
			txtAddress2Phys.Enabled = true;
			txtCityPhys.Enabled	    = true;
			txtStatePhys.Enabled	= true;
			txtZipCodePhys.Enabled	= true;
			TxtLicence.Enabled		= true;
		}

		private void DisableControls()
		{
            Login.Login cp = HttpContext.Current.User as Login.Login;

            VerifyAccess(cp);
		}

        private void VerifyAccess(Login.Login cp)
        {
            int userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

            if (!cp.IsInRole("READ-ONLY"))
            {
                ChkDisableAutomaticCustNo.Visible = false;
                TxtCustomerNo.Visible = false;

                btnEdit.Visible = true;
                btnDelete.Visible = true;
                btnNew.Visible = true;

                BtnUpdate.Visible = false;
                Label22.Visible = false;
                Label23.Visible = false;
                TxtCustomerNo.Visible = false;
                TxtProspectID.Visible = false;

                btnCancel.Visible = true;
                BtnExit.Visible = true;
                btnProfile.Visible = true;
                BtnSave.Visible = false;
                btnCancel.Visible = false;
                btnAuditTrail.Visible = true;
                BtnViewTask.Visible = false;
                btnQuotes.Visible = true;
                btnAssignCustNo.Visible = true;
                txtControlNo.Visible = true;

                ChkOptOut.Enabled = false;
                ChkNoticeOfCancellation.Enabled = false;
                chkSameAddr.Enabled = false;

                ddlGender.Enabled = false;
                ddlMaritalStatus.Enabled = false;
                ddlOccupation.Enabled = false;
                ddlHouseIncome.Enabled = false;
                ddlOriginatedAt.Enabled = false;
                ddlMasterCustomer.Enabled = false;
                ddlRelatedTo.Enabled = false;

                txtOtherOccupation.Enabled = false;
                TxtFirstName.Enabled = false;
                TxtInitial.Enabled = false;
                txtLastname1.Enabled = false;
                txtLastname2.Enabled = false;
                txtBirthdate.Enabled = false;
                TxtAge.Enabled = false;
                txtComments.Enabled = false;
                txtHomePhone.Enabled = false;
                txtWorkPhone.Enabled = false;
                TxtCellular.Enabled = false;
                txtEmail.Enabled = false;
                txtWorkName.Enabled = false;
                TxtWorkCity.Enabled = false;
                txtSocialSecurity.Enabled = false;
                txtEmployerSocSec.Enabled = false;
                //----------
                txtCustPreferedCommID.Enabled = false;
                txtWebsite2.Enabled = false;
                txtInsuredtype.Enabled = false;
                txtCorpName.Enabled = false;
                ddlAmscaOrDEA2.Enabled = false;
                txtNPI.Enabled = false;

                ddlprostatus.Enabled = false;
                chkssnselect.Enabled = false;
                txtssnpin.Enabled = false;

                txtemail2.Enabled = false;
                txtquoted.Enabled = false;
                txtlicexpdate.Enabled = false;
                txtfax.Enabled = false;
                txtcontoclient.Enabled = false;
                ddlreferredby.Enabled = false;
                ddlstatus.Enabled = false;
                txtleadid.Enabled = false;
                txtagentid.Enabled = false;
                txtinterestedin.Enabled = false;
                ddlAmscaOrDEA3.Enabled = false;
                //------------

                txtHomeUrb1.Enabled = false;
                txtAddress1.Enabled = false;
                txtAddress2.Enabled = false;
                txtCity.Enabled = false;
                txtState.Enabled = false;
                txtZipCode.Enabled = false;
                txtAddress1Phys.Enabled = false;
                txtAddress2Phys.Enabled = false;
                txtCityPhys.Enabled = false;
                txtStatePhys.Enabled = false;
                txtZipCodePhys.Enabled = false;
                TxtLicence.Enabled = false;
            }
            else
            {
                ChkDisableAutomaticCustNo.Visible = false;
                TxtCustomerNo.Visible = false;

                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnNew.Visible = false;

                BtnUpdate.Visible = false;
                Label22.Visible = false;
                Label23.Visible = false;
                TxtCustomerNo.Visible = false;
                TxtProspectID.Visible = false;

                btnCancel.Visible = false;
                BtnExit.Visible = true;
                btnProfile.Visible = false;
                BtnSave.Visible = false;
                btnCancel.Visible = false;
                btnAuditTrail.Visible = false;
                BtnViewTask.Visible = false;
                btnQuotes.Visible = false;
                btnAssignCustNo.Enabled = false;
                txtControlNo.Visible = true;
                txtControlNo.Enabled = false;

                ChkOptOut.Enabled = false;
                ChkNoticeOfCancellation.Enabled = false;
                chkSameAddr.Enabled = false;

                ddlGender.Enabled = false;
                ddlMaritalStatus.Enabled = false;
                ddlOccupation.Enabled = false;
                ddlHouseIncome.Enabled = false;
                ddlOriginatedAt.Enabled = false;
                ddlMasterCustomer.Enabled = false;
                ddlRelatedTo.Enabled = false;

                txtOtherOccupation.Enabled = false;
                TxtFirstName.Enabled = false;
                TxtInitial.Enabled = false;
                txtLastname1.Enabled = false;
                txtLastname2.Enabled = false;
                txtBirthdate.Enabled = false;
                TxtAge.Enabled = false;
                txtComments.Enabled = false;
                txtHomePhone.Enabled = false;
                txtWorkPhone.Enabled = false;
                TxtCellular.Enabled = false;
                txtEmail.Enabled = false;
                //---------------
                txtCustPreferedCommID.Enabled = false;
                txtWebsite2.Enabled = false;
                txtInsuredtype.Enabled = false;
                txtCorpName.Enabled = false;
                ddlAmscaOrDEA2.Enabled = false;
                txtNPI.Enabled = false;

                ddlprostatus.Enabled = false;
                chkssnselect.Enabled = false;
                txtssnpin.Enabled = false;


                txtemail2.Enabled = false;
                txtquoted.Enabled = false;
                txtlicexpdate.Enabled = false;
                txtfax.Enabled = false;
                txtcontoclient.Enabled = false;
                ddlreferredby.Enabled = false;
                ddlstatus.Enabled = false;
                txtleadid.Enabled = false;
                txtagentid.Enabled = false;
                txtinterestedin.Enabled = false;
                ddlAmscaOrDEA3.Enabled = false;
                //---------------
                txtWorkName.Enabled = false;
                TxtWorkCity.Enabled = false;
                txtSocialSecurity.Enabled = false;
                txtEmployerSocSec.Enabled = false;

                txtHomeUrb1.Enabled = false;
                txtAddress1.Enabled = false;
                txtAddress2.Enabled = false;
                txtCity.Enabled = false;
                txtState.Enabled = false;
                txtZipCode.Enabled = false;
                txtAddress1Phys.Enabled = false;
                txtAddress2Phys.Enabled = false;
                txtCityPhys.Enabled = false;
                txtStatePhys.Enabled = false;
                txtZipCodePhys.Enabled = false;
                TxtLicence.Enabled = false;
            }
        }

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			if(Session["Customer"] != null)
			{
				Customer.Customer customer = (Customer.Customer) Session["Customer"];
				Response.Redirect("SearchAuditItems.aspx?type=1&customerNo=" + 
					customer.CustomerNo.Trim());
			}
		}

		private void DisableAutomaticCustNo()
		{
			Login.Login cp = HttpContext.Current.User as Login.Login;
			if (cp == null)
			{
				Response.Redirect("HomePage.aspx?001");
			}
			else
			{
				if(cp.IsInRole("DISABLEAUTOMATICCUSTNO") || cp.IsInRole("ADMINISTRATOR"))
				{
					ChkDisableAutomaticCustNo.Visible = true;
				}
			}
		}

		private void ChkDisableAutomaticCustNo_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ChkDisableAutomaticCustNo.Checked)
			{
				TxtCustomerNo.Visible			  = false;
			}
			else
			{
				TxtCustomerNo.Visible			  = false;
			}
		}

		protected void btnEdit_Click(object sender, System.EventArgs e)
		{
			Customer.Customer customer = (Customer.Customer) Session["Customer"];
			customer.Mode		= (int) Customer.Customer.CustomerMode.UPDATE;

			Session.Add("Customer",customer);

			EnableControls();

            //EncryptClass.EncryptClass encrypt = new EncryptClass.EncryptClass();

            //txtSocialSecurity.Enabled = true;

            //if (customer.SocialSecurity.Trim() != "")
            //    txtSocialSecurity.Text = encrypt.Decrypt(customer.SocialSecurity);
            //else
            //    txtSocialSecurity.Text = "";

            //MaskedEditExtenderSS.Mask = "999-99-9999";


            //txtEmployerSocSec.Enabled = true;

            //if (customer.EmployerSocialSecurity.Trim() != "")
            //    txtEmployerSocSec.Text = encrypt.Decrypt(customer.EmployerSocialSecurity);
            //else
            //    txtEmployerSocSec.Text = "";

            //MaskedEditExtenderSS2.Mask = "999-99-9999";


                    //EncryptClass.EncryptClass encrypt = new EncryptClass.EncryptClass();
                    //if (customer.SocialSecurity.Trim() != "")
                    //{
                    //    txtSocialSecurity.Text = encrypt.Decrypt(customer.SocialSecurity);
                    //    //txtSocialSecurity.Text = "***-**-****";
                    //    //MaskedEditExtenderSS.Mask = "???-??-????";
                    //    txtSocialSecurity.Enabled = false;

                    //}

                    //if (customer.EmployerSocialSecurity.Trim() != "")
                    //{
                    //    txtEmployerSocSec.Text = encrypt.Decrypt(customer.EmployerSocialSecurity);
                    //    //txtEmployerSocSec.Text = "***-**-****";
                    //    //MaskedEditExtenderSS2.Mask = "???-??-????";
                    //    txtEmployerSocSec.Enabled = false;

                    //}

		}

		protected void BtnSave_Click(object sender, System.EventArgs e)
		{
			Login.Login cp = HttpContext.Current.User as Login.Login;
			int userID = 0;

			try
			{
				userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
			}
			catch(Exception ex)
			{
				throw new Exception(
					"Could not parse user id from cp.Identity.Name.", ex);
			}

			FillProperties();
			Customer.Customer customer = (Customer.Customer) Session["Customer"];
			try
			{
				customer.Save(userID);
				FillTextControl();
				DisableControls();
	
				if(Session["Prospect"] !=null) 
				{
					Customer.Prospect prospect = (Customer.Prospect) Session["Prospect"];
					UpdatedProspectData(prospect,customer,userID);
				}
				else
				{
					if(customer.ProspectID != 0)
					{
						Customer.Prospect prospect = new Customer.Prospect();
						prospect.GetProspect(customer.ProspectID);

						UpdatedProspectData(prospect,customer,userID);
					}
				}

                if (Session["QuoteAuto"] != null)
				{
					TaskControl.QuoteAuto taskControl = (TaskControl.QuoteAuto) Session["TaskControl"];
					taskControl.Customer = customer;
					taskControl.CustomerNo = customer.CustomerNo;
					//taskControl.Prospect.CustomerNumber = customer.CustomerNo;
					//taskControl.Mode = 2;	//Update
					//taskControl.Save(userID);
					//taskControl.Mode = (int) EPolicy.TaskControl.TaskControl.TaskControlMode.CLEAR;
					
					Session["TaskControl"] = taskControl;

                    Session.Remove("QuoteAuto");
                    Response.Redirect("QuoteAuto.aspx", false);
				}

				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Customer information saved successfully." + "\r\n" + customer.Warning.Trim());
				this.litPopUp.Visible = true;
			}
			catch (Exception exp)
			{
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to save customer. " + exp.Message);
				this.litPopUp.Visible = true;
			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Customer.Customer customer = (Customer.Customer) Session["Customer"];

			if(customer.Mode == 1) //ADD
			{
				Session.Clear();
				Response.Redirect("SearchClient.aspx");
			}
			else
			{
				customer.Mode		= (int) Customer.Customer.CustomerMode.CLEAR;
				Session["Customer"] = customer;

				Session.Remove("Address1");
				NavegationCustomers("");
				DisableControls();
			}
		}

		protected void BtnExit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.litPopUp.Visible = false;
			Session.Clear();
			Response.Redirect("SearchClient.aspx");
		}

		protected void btnNew_Click(object sender, System.EventArgs e)
		{
			Session.Clear();

			Customer.Customer customer = new Customer.Customer();
			customer.Mode = (int) Customer.Customer.CustomerMode.ADD;
			Session.Add("Customer",customer);

			Response.Redirect("ClientIndividual.aspx");
		}

		protected void TxtFirstName_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void btnProfile_Click(object sender, System.EventArgs e)
		{
			Customer.Customer customer = (Customer.Customer) Session["Customer"];

			EPolicy2.Reports.CustomerProfile rpt = new EPolicy2.Reports.CustomerProfile(customer);				
			rpt.Run(false);

			Session.Add("Report",rpt);

			Session.Add("FromPage","ClientIndividual.aspx");

			Response.Redirect("ActiveXViewer.aspx",false);
		}

		protected void BtnViewTask_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ClientTasks.aspx");
		}		

		private void NavegationCustomers(string Case)
		{
			//RPR 2004-05-17
			Login.Login cp = HttpContext.Current.User as Login.Login;
			int userID = 0;

			try
			{
				userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
			}
			catch(Exception ex)
			{
				throw new Exception(
					"Could not parse user id from cp.Identity.Name.", ex);
			}

			Customer.Customer customer = (Customer.Customer) Session["Customer"];

			string customerNo = customer.CustomerNo;
		 
			int rec =0;

			if(customer.NavegationCustomerTable != null)
			{
				for(int i=0;i<=customer.NavegationCustomerTable.Rows.Count-1;i++)
				{
					if (customerNo.Trim() == customer.NavegationCustomerTable.Rows[i]["CustomerNo"].ToString().Trim())
					{
						if (Case == "")
						{
							rec = i+1;
							//LblRecordCount.Text = rec.ToString()+" of " + customer.NavegationCustomerTable.Rows.Count;
						}
						else if (Case == "Previous" || Case == "Begin")
						{
							rec = 1;
							if (i>0)
							{
								switch(Case)
								{
									case "Previous":
										customerNo = customer.NavegationCustomerTable.Rows[i-1]["CustomerNo"].ToString();
										rec = i;
										break;
									case "Begin":
										customerNo = customer.NavegationCustomerTable.Rows[0]["CustomerNo"].ToString();
										rec = 1;
										break;
								}
								//LblRecordCount.Text = rec.ToString()+" of " + customer.NavegationCustomerTable.Rows.Count;
								i = customer.NavegationCustomerTable.Rows.Count-1; // Para salir del loop.
							}
							else
							{
								//MessageBox.Show(this,"Beginning of the records selected","Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);				
							}
						}
						else if (Case == "Next" || Case == "End")
						{
							if (customer.NavegationCustomerTable.Rows.Count-1>i)
							{					
								switch(Case)
								{
									case "Next":
										customerNo = customer.NavegationCustomerTable.Rows[i+1]["CustomerNo"].ToString();
										rec = i+2;
										break;
									case "End":
										customerNo = customer.NavegationCustomerTable.Rows[customer.NavegationCustomerTable.Rows.Count-1]["CustomerNo"].ToString();
										rec = customer.NavegationCustomerTable.Rows.Count;
										break;
								}
								//LblRecordCount.Text = rec.ToString()+" of " + customer.NavegationCustomerTable.Rows.Count;
								i = customer.NavegationCustomerTable.Rows.Count-1; // Para salir del loop.
							}
							else
							{
								//MessageBox.Show(this,"End of the records selected","Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
							}
						}
					}
				}																
		
				DataTable dtCustomer = customer.NavegationCustomerTable;
				int mode  = customer.Mode;

				customer  = Customer.Customer.GetCustomer(customerNo, userID);
			
				customer.Mode = mode;
				customer.NavegationCustomerTable = dtCustomer;

				Session.Add("Customer",customer);

				FillTextControl();
			}
			else
			{
				customer  = Customer.Customer.GetCustomer(customerNo, userID);	
				Session.Add("Customer",customer);
				FillTextControl();
			}
		}

		protected void BtnExit_Click(object sender, System.EventArgs e)
		{
            if (Session["QuoteAuto"] != null)
            {
                this.litPopUp.Visible = false;
                Session.Remove("QuoteAuto");
                Response.Redirect("QuoteAuto.aspx", false);
            }
            else
            {
                this.litPopUp.Visible = false;
                Session.Clear();
                Response.Redirect("SearchClient.aspx");
            }
		}
        protected void btnQuotes_Click(object sender, EventArgs e)
        {
            Customer.Customer customer = (Customer.Customer)Session["Customer"];
            try
            {

                if (ddlQuote.SelectedItem.Text.Trim() == "")
                {
                    throw new Exception("Please select the type of quote");
                }

                if (ddlQuote.SelectedItem.Text == "Quote")
                {
                    EPolicy.TaskControl.Application taskControl = new EPolicy.TaskControl.Application();

                    taskControl.Mode = 1; //ADD
                    taskControl.ApplicationMode = "ADD";
                    taskControl.Residency = "001";
                    taskControl.CustomerNo = customer.CustomerNo;
                    taskControl.Customer = customer;
                    taskControl.ProspectID = customer.ProspectID;

                    Session.Clear();
                    Session.Add("TaskControl", taskControl);
                    Response.Redirect("Application1.aspx", false);
                }
                else if (ddlQuote.SelectedItem.Text == "Corporate")
                {
                    EPolicy.TaskControl.CorporatePolicyQuote taskControl = new EPolicy.TaskControl.CorporatePolicyQuote(false);

                    taskControl.Mode = 1; //ADD


                    taskControl.CustomerNo = customer.CustomerNo;
                    taskControl.Customer = customer;
                    taskControl.ProspectID = customer.ProspectID;
                    taskControl.InsuranceCompany = "001";

                    Session.Clear();
                    Session.Add("TaskControl", taskControl);
                    Response.Redirect("CorporatePolicyQuote.aspx", false);
                }
                else if (ddlQuote.SelectedItem.Text == "Laboratory")
                {
                    EPolicy.TaskControl.Laboratory taskControl = new EPolicy.TaskControl.Laboratory(false);

                    taskControl.Mode = 1;
                    taskControl.TaskControlTypeID = 19;

                    taskControl.CustomerNo = customer.CustomerNo;
                    taskControl.Customer = customer;
                    taskControl.ProspectID = customer.ProspectID;
                    // taskControl.EffectiveDate = DateTime.Now.ToShortDateString();

                    Session.Clear();
                    Session.Add("TaskControl", taskControl);
                    Response.Redirect("LaboratoryApplication1.aspx", false);
                }
                else if (ddlQuote.SelectedItem.Text == "Cyber") //CyberPolicy
                {
                    EPolicy.TaskControl.Cyber taskControl = new EPolicy.TaskControl.Cyber(false);

                    taskControl.Mode = 1;
                    taskControl.TaskControlTypeID = 21;

                    taskControl.CustomerNo = customer.CustomerNo;
                    taskControl.Customer = customer;
                    taskControl.ProspectID = customer.ProspectID;

                    Session.Clear();
                    Session.Add("TaskControl", taskControl);
                    Response.Redirect("CyberApplication.aspx", false);
                }
                else if (ddlQuote.SelectedItem.Text == "Aspen") //CyberPolicy
                {
                    EPolicy.TaskControl.Application taskControl = new EPolicy.TaskControl.Application();

                    taskControl.Mode = 1; //ADD
                    taskControl.ApplicationMode = "ADD";
                    taskControl.Residency = "002";
                    taskControl.CustomerNo = customer.CustomerNo;
                    taskControl.Customer = customer;
                    taskControl.ProspectID = customer.ProspectID;

                    Session.Clear();
                    Session.Add("TaskControl", taskControl);
                    Response.Redirect("Application1.aspx", false);
                }
                else if (ddlQuote.SelectedItem.Text == "First Dollar")
                {
                    EPolicy.TaskControl.Application taskControl = new EPolicy.TaskControl.Application();

                    taskControl.Mode = 1; //ADD
                    taskControl.ApplicationMode = "ADD";
                    taskControl.Residency = "001";
                    taskControl.CustomerNo = customer.CustomerNo;
                    taskControl.Customer = customer;
                    taskControl.ProspectID = customer.ProspectID;
                    taskControl.TaskControlTypeID = 26;

                    Session.Add("TaskControl", taskControl);
                    Response.Redirect("FirstDollarQuotes.aspx", false);
                }
                else if (ddlQuote.SelectedItem.Text == "Allied")
                {
                    EPolicy.TaskControl.Application taskControl = new EPolicy.TaskControl.Application();

                    taskControl.Mode = 1; //ADD
                    taskControl.ApplicationMode = "ADD";
                    taskControl.Residency = "001";
                    taskControl.CustomerNo = customer.CustomerNo;
                    taskControl.Customer = customer;
                    taskControl.ProspectID = customer.ProspectID;
                    taskControl.TaskControlTypeID = 96;

                    Session.Add("TaskControl", taskControl);
                    Response.Redirect("AHCPrimaryQuotes.aspx", false);
                }
                else if (ddlQuote.SelectedItem.Text == "Allied Corporate")
                {
                    EPolicy.TaskControl.CorporatePolicyQuote taskControl = new EPolicy.TaskControl.CorporatePolicyQuote(false);

                    taskControl.Mode = 1; //ADD
                    taskControl.CustomerNo = customer.CustomerNo;
                    taskControl.Customer = customer;
                    taskControl.ProspectID = customer.ProspectID;
                    taskControl.TaskControlTypeID = 96;

                    Session.Add("TaskControl", taskControl);
                    Response.Redirect("AHCCorporateQuotes.aspx", false);
                }
            }

            catch (Exception ex)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(ex.Message.ToString());
                this.litPopUp.Visible = true;
            }
        }
        protected void searchIndividual_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
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

            if (e.Item.ItemType.ToString() != "Pager") // Select
            {
                int i = int.Parse(e.Item.Cells[1].Text);
                TaskControl.TaskControl taskControl =
                    TaskControl.TaskControl.GetTaskControlByTaskControlID(i, userID);

                DataTable dtFilter = (DataTable)Session["DtTask"];

                DataTable dt = dtFilter.Clone();

                DataRow[] dr = dtFilter.Select("TaskControlTypeID = " + taskControl.TaskControlTypeID, "TaskControlID");

                for (int rec = 0; rec <= dr.Length - 1; rec++)
                {
                    DataRow myRow = dt.NewRow();
                    myRow["TaskControlID"] = (int)dr[rec].ItemArray[0];
                    myRow["TaskControlTypeID"] = (int)dr[rec].ItemArray[7];

                    dt.Rows.Add(myRow);
                    dt.AcceptChanges();
                }

                taskControl.NavegationTaskControlTable = dt;

                string ToPage;

                if (Session["ToPage"] == null)
                {
                    if (taskControl.TaskControlTypeID == 4)
                    {
                        ToPage = "ExpressAutoQuote.aspx";
                    }
                    else if (taskControl.TaskControlTypeID == 20)
                    {
                        ToPage = "LaboratoryApplication1.aspx";
                    }
                    else if (taskControl.TaskControlTypeID == 22)
                    {
                        ToPage = "CyberApplication.aspx";
                    }
                    else if (taskControl.TaskControlTypeID == 23)
                    {
                        ToPage = "AHCPrimaryPolicies.aspx";
                    }
                    else if (taskControl.TaskControlTypeID == 24)
                    {
                        ToPage = "AHCCorporateQuotes.aspx";
                    }
                    else
                    {
                        ToPage = taskControl.GetType().Name.Trim() + ".aspx";
                    }
                }
                else
                {
                    ToPage = Session["ToPage"].ToString();
                }

                if (Session["TaskControl"] == null)
                    Session.Add("TaskControl", taskControl);
                else
                    Session["TaskControl"] = taskControl;

                Session.Remove("DtTaskControl");

                Response.Redirect(ToPage + "?" + taskControl.TaskControlID);
            }
            else  // Pager
            {
                searchIndividual.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                searchIndividual.DataSource = (DataTable)Session["DtTask"];
                searchIndividual.DataBind();
            }
        }

        protected void btnAssignCustNo_Click(object sender, EventArgs e)
        {
            try
            {
                Customer.Customer customer = (Customer.Customer)Session["Customer"];

                if (txtControlNo.Text.Trim() == "")
                {
                    throw new Exception("The Control Number is empty.");
                }

                Customer.Customer.AssignCustomerNoToControlNo(int.Parse(txtControlNo.Text.Trim()), customer.CustomerNo, customer.ProspectID);
               
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Customer No. was assigned to the Control No.: " + txtControlNo.Text.Trim());
                this.litPopUp.Visible = true;

                txtControlNo.Text = "";

                customer.Mode = (int)Customer.Customer.CustomerMode.CLEAR;
                Session["Customer"] = customer;

                Session.Remove("Address1");
                NavegationCustomers("");
                DisableControls();
            }
            catch (Exception ex)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(ex.Message.ToString());
                this.litPopUp.Visible = true;
            }
        }
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (TxtCustomerNo.Text == String.Empty)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Empty Customer No. provided.");
                this.litPopUp.Visible = true;
                return;
            }
            
            if (TxtProspectID.Text == String.Empty)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Empty Prospect ID provided.");
                this.litPopUp.Visible = true;
                return;
            }

            try
            {
                Customer.Customer customer = (Customer.Customer)Session["Customer"];
                DataTable DtCusotmer = TaskControl.TaskControl.GetTaskControlByCustomerNo(customer.CustomerNo); //(TxtCustomerNo.Text);
                DataTable DtProspect = TaskControl.TaskControl.GetTaskControlByProspectID(customer.ProspectID);

                if (DtCusotmer.Rows.Count <= 0)
                {
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("There are no cases with the provided Customer No.");
                    this.litPopUp.Visible = true;
                    return;
                }

                if (DtProspect.Rows.Count <= 0)
                {
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("There are no cases with the provided Prospect ID.");
                    this.litPopUp.Visible = true;
                    return;
                }

                foreach (DataRow dr in DtCusotmer.Rows)
                {
                    if (!(dr[5].ToString().Contains(TxtFirstName.Text) && dr[5].ToString().Contains(txtLastname1.Text)
                    || dr[5].ToString().Contains(txtLastname2.Text)))
                    {
                        this.litPopUp.Text = Utilities.MakeLiteralPopUpString("One or more cases with the provided Customer No." +  
                        " does not belong to Dr. " + TxtFirstName.Text + " " + txtLastname1.Text + " " + txtLastname2.Text +
                        "." + Environment.NewLine + "Customer No: " + TxtCustomerNo.Text + " Name: Dr." + dr[5].ToString().Trim());
                        this.litPopUp.Visible = true;
                        return;
                    }

                }

                foreach (DataRow dr in DtProspect.Rows)
                {
                    if (!(dr[1].ToString().Contains(TxtFirstName.Text) && dr[1].ToString().Contains(txtLastname1.Text)
                    || dr[1].ToString().Contains(txtLastname2.Text)))
                    {
                        this.litPopUp.Text = Utilities.MakeLiteralPopUpString("One or more cases with the provided Prospect ID" +
                        " does not belong to Dr. " + TxtFirstName.Text + " " + txtLastname1.Text + " " + txtLastname2.Text +
                        "."+Environment.NewLine+"Prospect ID: " + TxtProspectID.Text + " Name: Dr." + dr[1].ToString().Trim());
                        this.litPopUp.Visible = true;
                        return;
                    }

                }

                customer.UpdateCustomerNoAndProspectID(TxtCustomerNo.Text.Trim(), int.Parse(TxtProspectID.Text.Trim()),
                    customer.CustomerNo, customer.ProspectID);
                RefreshCustomerField();
                FillTextControl();
                DisableControls();

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Successfully changed Customer No/Prospect ID");
                this.litPopUp.Visible = true;

            }
            catch (Exception ex)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(ex.Message);
                this.litPopUp.Visible = true;
            }
        }

        private void RefreshCustomerField()
        {
          Customer.Customer customer = (Customer.Customer)Session["Customer"];

          customer.CustomerNo = TxtCustomerNo.Text;
          customer.ProspectID = int.Parse(TxtProspectID.Text);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Customer.Customer customer = (Customer.Customer)Session["Customer"];
                Login.Login cp = HttpContext.Current.User as Login.Login;
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

                bool validate = true;

                if (searchIndividual.Items.Count > 0)
                {
                    validate = false;
                }

                if (validate)
                {
                    string note;
                    note = "[DELETED CUSTOMER]: " + "\r\n"
                            + "CUSTOMER NUM: " + customer.CustomerNo + "\r\n"
                            + "CUSTOMER NAME: " + customer.FirstName.Trim() + customer.Initial.Trim() + customer.LastName1.Trim() + customer.LastName2.Trim() + "\r\n";

                    History(customer.CustomerNo, userID, "DELETE", "CUSTOMER", note);

                    customer.Mode = 3;
                    customer.Save(userID);
                    Response.Redirect("MainMenu.aspx");
                }
                else
                    throw new Exception("Unable to delete customer with attached Policies.");
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

            //try
            //{
            //    if (searchIndividual.Items.Count > 0)
            //    {
            //        throw new Exception("Unable to delete customer with policies still attached to it.");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(ex.Message);
            //    this.litPopUp.Visible = true;
            //}
        }
        protected void btnShowSocSec_Click(object sender, EventArgs e)
        {
            //pnlMessage.Visible = true;
            //mpeSeleccion.Show();
        }
        protected void txtPass_TextChanged(object sender, EventArgs e)
        {
            Customer.Customer customer = (Customer.Customer)Session["Customer"];
            DataTable dt = GetSocSecPassword();

            if (dt.Rows.Count > 0)
            {
                if (txtPass.Text == dt.Rows[0]["Password"].ToString().Trim())
                {
                    EncryptClass.EncryptClass encrypt = new EncryptClass.EncryptClass();
                    if (customer.SocialSecurity.Trim() != "")
                    {
                        txtSocialSecurity.Text = encrypt.Decrypt(customer.SocialSecurity);
                        //txtSocialSecurity.Text = new string('*', txtSocialSecurity.Text.Trim().Length - 4) + txtSocialSecurity.Text.Trim().Substring(txtSocialSecurity.Text.Trim().Length - 4);
                        //MaskedEditExtenderSS.Mask = "???-??-9999";

                    }

                    if (customer.EmployerSocialSecurity.Trim() != "")
                    {
                        txtEmployerSocSec.Text = encrypt.Decrypt(customer.EmployerSocialSecurity);
                        //txtEmployerSocSec.Text = new string('*', txtEmployerSocSec.Text.Trim().Length - 4) + txtEmployerSocSec.Text.Trim().Substring(txtEmployerSocSec.Text.Trim().Length - 4);
                        //MaskedEditExtenderSS2.Mask = "???-??-9999";

                    }

                }
                else
                {
                    txtSocialSecurity.Text = "";
                    txtEmployerSocSec.Text = "";
                }
            }

        }

        public static DataTable GetSocSecPassword()
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[0];


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

            DataTable dt = exec.GetQuery("GetSocSecPassword", xmlDoc);

            return dt;
        }
        protected void btnValidate_Click(object sender, EventArgs e)
        {
            Customer.Customer customer = (Customer.Customer)Session["Customer"];
            DataTable dt = GetSocSecPassword();

            BtnActivateDeleteSoSec.Visible = true;


            if (dt.Rows.Count > 0)
            {
                if (txtPass.Text == dt.Rows[0]["Password"].ToString().Trim())
                {
                    EncryptClass.EncryptClass encrypt = new EncryptClass.EncryptClass();
                    if (customer.SocialSecurity.Trim() != "")
                    {
                        txtSocialSecurity.Text = encrypt.Decrypt(customer.SocialSecurity);
                        //txtSocialSecurity.Text = new string('*', txtSocialSecurity.Text.Trim().Length - 4) + txtSocialSecurity.Text.Trim().Substring(txtSocialSecurity.Text.Trim().Length - 4);
                        //MaskedEditExtenderSS.Mask = "???-??-9999";
                        txtSocialSecurity.Enabled = true;

                    }

                    if (customer.EmployerSocialSecurity.Trim() != "")
                    {
                        txtEmployerSocSec.Text = encrypt.Decrypt(customer.EmployerSocialSecurity);
                        //txtEmployerSocSec.Text = new string('*', txtEmployerSocSec.Text.Trim().Length - 4) + txtEmployerSocSec.Text.Trim().Substring(txtEmployerSocSec.Text.Trim().Length - 4);
                        //MaskedEditExtenderSS2.Mask = "???-??-9999";
                        txtEmployerSocSec.Enabled = true;

                    }

                    
                    if (customer.Ssnselect == "Patronal")
                    {
                        chkssnselect.Items[0].Selected = true;
                        chkssnselect.Items[1].Selected = false;
                    }
                    else if (customer.Ssnselect == "Personal")
                    {
                        chkssnselect.Items[0].Selected = false;
                        chkssnselect.Items[1].Selected = true;
                    }
                    else 
                    {
                        //if (txtSocialSecurity.Text == "" && txtEmployerSocSec.Text != "" )
                        //{
                        //    chkssnselect.Items[0].Selected = true;
                        //    chkssnselect.Items[1].Selected = false;
                        //}
                        //else
                        //{
                        //    chkssnselect.Items[0].Selected = false;
                        //    chkssnselect.Items[1].Selected = true;
                        //}
                    }
                }
                else
                {
                    txtSocialSecurity.Text = "";
                    txtEmployerSocSec.Text = "";
                }
            }
        }

        protected void BtnActivateDeleteSoSec_Click(object sender, EventArgs e)
        {
            mpeSocSec.Show();
        }

        protected void btnDeleteSoSec_Click(object sender, EventArgs e)
        {
            Customer.Customer customer = (Customer.Customer)Session["Customer"];

            DeleteCustomerSocSecByCustomerNo(customer.CustomerNo, "Personal");
            txtSocialSecurity.Text = "";
            customer.SocialSecurity = "";

            Session["Customer"] = customer;
        }

        protected void btnDeleteEmployerSoSec_Click(object sender, EventArgs e)
        {
            Customer.Customer customer = (Customer.Customer)Session["Customer"];

            DeleteCustomerSocSecByCustomerNo(customer.CustomerNo,"Employer");
            txtEmployerSocSec.Text = "";
            customer.EmployerSocialSecurity = "";

            Session["Customer"] = customer;
        }

        public static DataTable DeleteCustomerSocSecByCustomerNo(string CustomerNo, string Type)
        {
            

            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];
            DbRequestXmlCooker.AttachCookItem("CustomerNo", SqlDbType.VarChar, 25, CustomerNo.ToString(), ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Type", SqlDbType.VarChar, 25, Type.ToString(), ref cookItems);


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

            DataTable dt = exec.GetQuery("DeleteCustomerSocSecByCustomerNo", xmlDoc);

            return dt;
        }

        private void History(string taskControlID, int userID, string action, string subject, string note)
        {
            Audit.History history = new Audit.History();
            //TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];

            history.Actions = action;
            history.KeyID = taskControlID.ToString();
            history.Subject = subject;
            //history.BuildNotesForHistory("TaskControlID.", "", taskControlID.ToString(), 7);  //7 = mode NOTICEOFCANC
            history.UsersID = userID;
            history.Notes = note + "\r\n";
            history.GetSaveHistory();
        }

        
}
}
