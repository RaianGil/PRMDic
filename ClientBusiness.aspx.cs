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
//using Baldrich.AddressVerify;
using Baldrich.DBRequest;
using EPolicy2.Reports;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.LookupTables;
using System.Text.RegularExpressions;

namespace EPolicy
{
	/// <summary>
	/// Summary description for ClientIndividual.
	/// </summary>
	public partial class ClientBusiness : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox ss;

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
			DataTable dtBusinessType    = LookupTables.LookupTables.GetTable("BusinessType");
			DataTable dtLocation		= LookupTables.LookupTables.GetTable("Location");
			DataTable dtMasterCustomer	= LookupTables.LookupTables.GetTable("MasterCustomer");
			DataTable dtRelatedTo		= LookupTables.LookupTables.GetTable("RelatedTo");

			//HouseHoldIncome
			ddlBusinessType.DataSource = dtBusinessType;
			ddlBusinessType.DataTextField = "BusinessTypeDesc";
			ddlBusinessType.DataValueField = "BusinessTypeID";
			ddlBusinessType.DataBind();
			ddlBusinessType.SelectedIndex = -1;
			ddlBusinessType.Items.Insert(0,"");

			//Location (Originated At)
			ddlOriginatedAt.DataSource = dtLocation;
			ddlOriginatedAt.DataTextField = "LocationDesc";
			ddlOriginatedAt.DataValueField = "LocationID";
			ddlOriginatedAt.DataBind();

			//MasterCustomer
			ddlMasterCustomer.DataSource = dtMasterCustomer;
			ddlMasterCustomer.DataTextField = "MasterCustomerDesc";
			ddlMasterCustomer.DataValueField = "MasterCustomerID";
			ddlMasterCustomer.DataBind();
			ddlMasterCustomer.SelectedIndex = -1;
			ddlMasterCustomer.Items.Insert(0,"");

			//RelatedTo
			ddlRelatedTo.DataSource = dtRelatedTo;
			ddlRelatedTo.DataTextField  = "RelatedToDesc";
			ddlRelatedTo.DataValueField = "RelatedToID";
			ddlRelatedTo.DataBind();
			ddlRelatedTo.SelectedIndex = -1;
			ddlRelatedTo.Items.Insert(0,"");

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
				if(!cp.IsInRole("CLIENTBUSINESS") && !cp.IsInRole("ADMINISTRATOR"))
				{
					Response.Redirect("Default.aspx?001");
				}
			}

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
				NavegationCustomers("");
				FillTextControl();
				EnableControls();
				Session.Remove("AutoPostBack");
			}
		}

	
		private void FillTextControl()
		{
			Customer.Customer customer = (Customer.Customer) Session["Customer"];

			//BusinessType
			ddlBusinessType.SelectedIndex = 0;
			if(customer.BusinessType != 0)
			{
				for(int i = 0;ddlBusinessType.Items.Count-1 >= i ;i++)
				{
					if (ddlBusinessType.Items[i].Value == customer.BusinessType.ToString())
					{
						ddlBusinessType.SelectedIndex = i;
						i = ddlBusinessType.Items.Count-1;
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
			TxtLastName1.Text		= customer.LastName1;
			TxtLastName2.Text		= customer.LastName2;
			TxtPosition.Text		= customer.EmpPosition;

			bool skip = false;
  
			if (LoadVerifyAddress())
			{
				skip = true;
			}
	
			if (skip==false)
			{
				customer = (Customer.Customer) Session["Customer"];
				txtHomeUrb1.Text		= customer.Address1.Trim();
				txtAddress1.Text		= customer.Address2.Trim();
				//txtAddress2.Text     	= customer.Address2.Trim();
				txtCity.Text			= customer.City.Trim();
				txtState.Text			= customer.State.Trim();
				txtZipCode.Text			= customer.ZipCode.Trim();
			}

			txtAddress1Phys.Text	= customer.AddressPhysical1.Trim();
			txtAddress2Phys.Text	= customer.AddressPhysical2.Trim();
			txtCityPhys.Text    = customer.CityPhysical.Trim();
			txtStatePhys.Text   = customer.StatePhysical.Trim();
			txtZipCodePhys.Text		= customer.ZipPhysical.Trim();

			if(txtAddress1Phys.Text.Trim() == txtAddress1.Text.Trim() && (txtAddress1Phys.Text.Trim() != "" && txtAddress1.Text != ""))
			{
				chkSameAddr.Checked = true;
			}
			else
			{
				chkSameAddr.Checked = false;
			}

			TxtBusinessName.Text	= customer.EmplName;
			TxtBusinessName1.Text   = customer.BusinessName1;
			TxtBusinessName2.Text   = customer.BusinessName2;
			TxtBusinessName3.Text   = customer.BusinessName3;
			txtSocialSecurity.Text  = customer.EmployerSocialSecurity;
			txtCellular.Text		= customer.Cellular;
			TxtWorkPhone.Text		= customer.JobPhone;
			txtEmail.Text			= customer.Email;
			txtComments.Text		= customer.Comments;
			TxtDescription.Text		= customer.Description;
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
				customer  = Customer.Customer.GetCustomer(customerNo, userID);
			
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

			if (customer.NavegationCustomerTable.Rows.Count > 1)
			{
				//LblView.Visible			= false;
				//DtGridPolicy.DataSource = null;
				//DtGridPolicy.Visible    = false;
				//DtGridPolicy.Refresh();
			}
		}

		private void BtnBegin_Click(object sender, System.EventArgs e)
		{
			Session.Remove("Address1");
			NavegationCustomers("Begin");
		}

		private void BtnPrevious_Click(object sender, System.EventArgs e)
		{
			Session.Remove("Address1");
			NavegationCustomers("Previous");
		}

		private void BtnNext_Click(object sender, System.EventArgs e)
		{
			Session.Remove("Address1");
			NavegationCustomers("Next");
		}

		private void BtnEnd_Click(object sender, System.EventArgs e)
		{
			Session.Remove("Address1");
			NavegationCustomers("End");
		}

		private void UpdatedProspectData(Customer.Prospect prospect, Customer.Customer customer, int userID)
		{
			//Actualizo la data del prospecto.
			prospect.ConvertToClient = DateTime.Now;
			prospect.BusinessName	 = customer.EmplName;
			prospect.FirstName	= customer.FirstName;
			prospect.LastName1	= customer.LastName1;
			prospect.LastName2	= customer.LastName2;
			prospect.WorkPhone	= customer.JobPhone;
			prospect.Cellular   = customer.Cellular;
			prospect.Email		= customer.Email;

			prospect.SaveProspect(userID);
		}

		private void FillProperties()
		{
			Customer.Customer customer = (Customer.Customer) Session["Customer"];

			if(Session["Prospect"] !=null)
			{
				Customer.Prospect prospect = (Customer.Prospect) Session["Prospect"];

				customer.ProspectID		= prospect.ProspectID;
				
				Session["Prospect"]		= prospect;
			}

			customer.CustomerNo			= lblCustNumber.Text.Trim().ToUpper();
			customer.FirstName			= TxtFirstName.Text.Trim().ToUpper();
			customer.LastName1			= TxtLastName1.Text.Trim().ToUpper();
			customer.LastName2			= TxtLastName2.Text.Trim().ToUpper();
			customer.EmpPosition		= TxtPosition.Text.Trim().ToUpper();
			customer.Address1			= txtHomeUrb1.Text.Trim().ToUpper();
			customer.Address2			= txtAddress1.Text.Trim().ToUpper();
			//customer.Address2			= txtAddress2.Text.Trim().ToUpper();
			customer.City				= txtCity.Text.Trim().ToUpper();
			customer.State				= txtState.Text.Trim().ToUpper();
			customer.ZipCode			= txtZipCode.Text.Trim().ToUpper();
			customer.AddressPhysical1	= txtAddress1Phys.Text.Trim().ToUpper();
			customer.AddressPhysical2	= txtAddress2Phys.Text.Trim().ToUpper();
			customer.CityPhysical		= txtCityPhys.Text.Trim().ToUpper();
			customer.StatePhysical		= txtStatePhys.Text.Trim().ToUpper();
			customer.ZipPhysical		= txtZipCodePhys.Text.Trim().ToUpper();

			customer.MasterCustomer = ddlMasterCustomer.SelectedItem.Value != "" ?int.Parse(ddlMasterCustomer.SelectedItem.Value):0;
			customer.BusinessType	= ddlBusinessType.SelectedItem.Value != "" ?int.Parse(ddlBusinessType.SelectedItem.Value):0;
			customer.EmplName		= TxtBusinessName1.Text.Trim().ToUpper()+" "+TxtBusinessName2.Text.Trim().ToUpper()+" "+TxtBusinessName3.Text.Trim().ToUpper();
			customer.BusinessName1  = TxtBusinessName1.Text.Trim().ToUpper();
			customer.BusinessName2  = TxtBusinessName2.Text.Trim().ToUpper();
			customer.BusinessName3  = TxtBusinessName3.Text.Trim().ToUpper();
			customer.EmployerSocialSecurity = txtSocialSecurity.Text.Trim();
			customer.Cellular		= txtCellular.Text.Trim();
			customer.JobPhone		= TxtWorkPhone.Text.Trim();
			customer.Email			= txtEmail.Text.Trim().ToUpper();
			customer.Comments		= txtComments.Text.Trim().ToUpper();
			customer.Description	= TxtDescription.Text.Trim().ToUpper();
			customer.LocationID		= ddlOriginatedAt.SelectedItem.Value != "" ?int.Parse(ddlOriginatedAt.SelectedItem.Value):0;
			customer.RelatedToID   = ddlRelatedTo.SelectedItem.Value != "" ? int.Parse(ddlRelatedTo.SelectedItem.Value):0;
			customer.OptOut			= ChkOptOut.Checked;
			if (ChkNoticeOfCancellation.Checked)
			{
				customer.NoticeCancellation = true;
			}
			else
			{
				customer.NoticeCancellation = false;
			}

			Session.Add("Customer",customer);
		}

		private bool LoadVerifyAddress()
		{
			if ((Convert.ToString(Session["Address1"])!= ""))
			{
				if(Convert.ToString(Session["ZipCode"]) != "")
				{
					this.txtAddress1.Text = Convert.ToString(Session["Address2"]);
					this.txtAddress2.Text = Convert.ToString(Session["Address2"]);
					this.txtCity.Text     = Convert.ToString(Session["CityName"]);
					this.txtState.Text    = "PR";
					this.txtZipCode.Text  = Convert.ToString(Session["ZipCode"]);
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
				txtAddress1Phys.Text	= txtAddress1.Text;
				txtAddress2Phys.Text	= txtAddress2.Text;
				txtCityPhys.Text		= txtCity.Text;
				txtStatePhys.Text		= txtState.Text;
				txtZipCodePhys.Text		= txtZipCode.Text;
			}
		}

		private void EnableControls()
		{
			btnEdit.Visible		= false;
			BtnExit.Visible		= false;
			btnProfile.Visible	= false;
			BtnSave.Visible		= true;
			btnCancel.Visible	= true;
			btnAuditTrail.Visible = false;
			BtnViewTask.Visible   = false;
						
			ChkOptOut.Enabled		= true;
			ChkNoticeOfCancellation.Enabled = true;
			chkSameAddr.Enabled		= true;

			ddlBusinessType.Enabled = true;
			ddlMasterCustomer.Enabled = true;
			ddlRelatedTo.Enabled = true;
			ddlOriginatedAt.Enabled = true;
			
			TxtBusinessName.Enabled= false;
			TxtBusinessName1.Enabled = true;
			TxtBusinessName2.Enabled = true;
			TxtBusinessName3.Enabled = true;
			TxtDescription.Enabled	= true;
			txtSocialSecurity.Enabled = true;
			txtComments.Enabled	= true;
			TxtFirstName.Enabled	= true;
			TxtLastName1.Enabled	= true;
			TxtLastName2.Enabled	= true;
			txtCellular.Enabled	= true;
			TxtWorkPhone.Enabled	= true;
			txtEmail.Enabled		= true;
			TxtPosition.Enabled	= true;
			
			txtHomeUrb1.Enabled	= true;
			txtAddress1.Enabled	= true;
			txtAddress2.Enabled	= true;
			txtCity.Enabled		= true;
			txtState.Enabled		= true;
			txtZipCode.Enabled		= true;
			txtAddress1Phys.Enabled = true;
			txtAddress2Phys.Enabled = true;
			txtCityPhys.Enabled	= true;
			txtStatePhys.Enabled	= true;
			txtZipCodePhys.Enabled	= true;
		}

		private void DisableControls()
		{
			btnEdit.Visible		= true;
			BtnExit.Visible		= true;
			btnProfile.Visible	= true;
			BtnSave.Visible		= false;
			btnCancel.Visible	= false;
			btnAuditTrail.Visible = true;
			BtnViewTask.Visible   = true;

			ChkOptOut.Enabled		= false;
			ChkNoticeOfCancellation.Enabled = false;
			chkSameAddr.Enabled		= false;

			ddlBusinessType.Enabled = false;
			ddlMasterCustomer.Enabled = false;
			ddlRelatedTo.Enabled = false;
			ddlOriginatedAt.Enabled = false;	

			TxtBusinessName.Enabled= false;
			TxtBusinessName1.Enabled = false;
			TxtBusinessName2.Enabled = false;
			TxtBusinessName3.Enabled = false;
			TxtDescription.Enabled	= false;
			txtSocialSecurity.Enabled = false;
			txtComments.Enabled	= false;
			TxtFirstName.Enabled	= false;
			TxtLastName1.Enabled	= false;
			TxtLastName2.Enabled	= false;
			txtCellular.Enabled	= false;
			TxtWorkPhone.Enabled	= false;
			txtEmail.Enabled		= false;
			TxtPosition.Enabled	= false;
			
			txtHomeUrb1.Enabled	= false;
			txtAddress1.Enabled	= false;
			txtAddress2.Enabled	= false;
			txtCity.Enabled		= false;
			txtState.Enabled		= false;
			txtZipCode.Enabled		= false;
			txtAddress1Phys.Enabled = false;
			txtAddress2Phys.Enabled = false;
			txtCityPhys.Enabled	= false;
			txtStatePhys.Enabled	= false;
			txtZipCodePhys.Enabled	= false;
		}

		protected void BtnViewTask_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ClientTasks.aspx");
		}

		protected void btnNew_Click(object sender, System.EventArgs e)
		{
			Session.Clear();

			Customer.Customer customer = new Customer.Customer();
			customer.Mode = (int) Customer.Customer.CustomerMode.ADD;
			Session.Add("Customer",customer);

			Response.Redirect("ClientBusiness.aspx");
		}

		protected void btnAuditTrail_Click(object sender, System.EventArgs e)
		{
			if(Session["Customer"] != null)
			{
				Customer.Customer customer = (Customer.Customer) Session["Customer"];
				Response.Redirect("SearchAuditItems.aspx?type=1&customerNo=" + 
					customer.CustomerNo.Trim());
			}
		}

		protected void btnProfile_Click(object sender, System.EventArgs e)
		{
			Customer.Customer customer = (Customer.Customer) Session["Customer"];

			CustomerProfile rpt = new CustomerProfile(customer);				
			rpt.Run(false);

			Session.Add("Report",rpt);

			Session.Add("FromPage","ClientBusiness.aspx");

			Response.Redirect("ActiveXViewer.aspx",false);
		}

		protected void btnEdit_Click(object sender, System.EventArgs e)
		{
			Customer.Customer customer = (Customer.Customer) Session["Customer"];
			customer.Mode		= (int) Customer.Customer.CustomerMode.UPDATE;

			Session.Add("Customer",customer);

			EnableControls();
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

				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Customer information saved successfully.");
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

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			this.litPopUp.Visible = false;
			Session.Clear();
			Response.Redirect("SearchClient.aspx");
		}

		protected void BtnViewTask_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ClientTasks.aspx");
		}

		
	}
}
