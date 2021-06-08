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
using EPolicy2.Reports;

namespace EPolicy
{
	/// <summary>
	/// Summary description for Agency.
	/// </summary>
	public partial class Agency : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton BtnExit;
		private Control LeftMenu;


		#region Enumerations

		public enum UserAction{ADD = 1, VIEW = 2, SAVE = 3, EDIT = 4, CANCEL = 5};
		
		#endregion

		private void SetAgencyNumerationLabel()
		{
			LookupTables.Agency agency = 
				(LookupTables.Agency)Session["Agency"];

			this.lblAgencyID.Text = (agency.AgencyID != "") ?
				agency.AgencyID.ToString():
				String.Empty;
		}


		protected void Page_Load(object sender, System.EventArgs e)
		{
			Login.Login cp = HttpContext.Current.User as Login.Login;
			if (cp == null)
			{
				Response.Redirect("HomePage.aspx?001");
			}
			else
			{
				if(!cp.IsInRole("AGENCY") && !cp.IsInRole("ADMINISTRATOR"))
				{
					Response.Redirect("HomePage.aspx?001");
				}
			}

			if(!Page.IsPostBack)
			{
				LookupTables.Agency agency = new LookupTables.Agency();

                DataTable dtType = LookupTables.LookupTables.GetTable("TypeofLicenseForAgent");
                ddltypelic.DataSource = dtType;
                ddltypelic.DataTextField = "TypeLicense";
                ddltypelic.DataValueField = "ID";
                ddltypelic.DataBind();
                ddltypelic.SelectedIndex = -1;
                ddltypelic.Items.Insert(0, "");

                ddlappl.SelectedIndex = -1;
                ddlappl.Items.Insert(0, "");

                ddlocsa.SelectedIndex = -1;
                ddlocsa.Items.Insert(0, "");

                ddlcomm.SelectedIndex = -1;
                ddlcomm.Items.Insert(0, "");

                ddltaxwai.SelectedIndex = -1;
                ddltaxwai.Items.Insert(0, "");

                ddleopolicy.SelectedIndex = -1;
                ddleopolicy.Items.Insert(0, "");

                ddlmerchregis.SelectedIndex = -1;
                ddlmerchregis.Items.Insert(0, "");

                ddlpaymet.SelectedIndex = -1;
                ddlpaymet.Items.Insert(0, "");

				if(Request.QueryString["item"] != null &&																	
					Request.QueryString["item"].ToString() != String.Empty)
				{	
					try
					{
						agency.GetAgency(Request.QueryString["item"].ToString());
						agency.ActionMode = 2; //UPDATE
						agency.NavigationViewModelTable = 
							(DataTable)Session["DtRecordsForNonValuePairLookupTable"];
						Session["Agency"] = agency;
					}
					catch(Exception ex)
					{
						this.ShowMessage("There is no agency for the supplied " +
							"ID. " + ex.Message);
					}
				}
				else
				{
					agency.ActionMode = 1; //ADD
					Session["Agency"] = agency;
				}
				
			}

			if(Session["Agency"] != null)
			{
				LookupTables.Agency agency = 
					(LookupTables.Agency)Session["Agency"];

				this.InitializeControls();
			
				switch(agency.ActionMode)
				{
					case 1: //ADD
						this.SetControlState((int)UserAction.ADD);
						if(!Page.IsPostBack)
						{
							this.FillControls();
						}
						break;
					
					default: //UPDATE
						if(!Page.IsPostBack)
						{
							this.FillControls();
							this.SetControlState((int)UserAction.VIEW);

						}
						break;
				}
			}
		}

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

			//Setup Left-side Banner
            //LeftMenu = new Control();
            //LeftMenu = LoadControl(@"LeftMenu.ascx");
            ////((Baldrich.Components.MenuTaskControl)LeftMenu).Height = "534px";
            //phTopBanner1.Controls.Add(LeftMenu);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{   

		}
		#endregion

		
		private void InitializeControls()
		{
			this.SetAgencyNumerationLabel();
			this.litPopUp.Visible = false;
		}

		private void SetControlState(int Action)
		{
			switch(Action)
			{
				case 1: //ADD ACTION
					this.EnableInputControls(true);
					this.btnEdit.Visible = false;
					this.BtnSave.Visible = true;
					this.cmdCancel.Visible = true;
					this.btnAddNew.Visible = false;
					this.btnCommission.Visible = false;
					this.txtEntryDate.Enabled = false;
					this.btnAuditTrail.Visible = false;
					this.btnPrint.Visible = false;
					this.btnSearch.Visible = false;
					this.Button2.Visible = false;
					break;
				case 2: //VIEW ACTION
					this.EnableInputControls(false);
					this.btnEdit.Visible = true;
					this.BtnSave.Visible = false;
					this.cmdCancel.Visible = false;
					this.btnAddNew.Visible = true;
					this.btnCommission.Visible = true;
					this.btnAuditTrail.Visible = true;
					this.btnPrint.Visible = true;
					this.btnSearch.Visible = true;
					this.Button2.Visible = true;
					break;
				case 3: //SAVE ACTION
					this.SetControlState((int)UserAction.VIEW);
					break; 
				case 4: //EDIT ACTION
					this.EnableInputControls(true);
					this.btnEdit.Visible = false;
					this.BtnSave.Visible = true;
					this.cmdCancel.Visible = true;
					this.btnAddNew.Visible = false;
					this.btnCommission.Visible = false;
					this.txtEntryDate.Enabled = false;
					this.btnAuditTrail.Visible = false;
					this.btnPrint.Visible = false;
					this.btnSearch.Visible = false;
					this.Button2.Visible = false;
					break;
				default: //CANCEL ACTION
					LookupTables.Agency agency = 
						(LookupTables.Agency)Session["Agency"];
					if(agency.ActionMode == 0) //ADD
					{
						Session["Agency"] = null;
						Response.Redirect("SearchLookupTableDescriptions.aspx");
					}
					else
					{
						this.SetControlState((int)UserAction.VIEW);
					}
					break;
			}
		}// End SetControlState

		private void EnableInputControls(bool State)
		{
			if(State)
			{
				this.txtAgencyDescription.Enabled = true;
				this.txtAddress1.Enabled = true;
				this.txtAddress2.Enabled = true;
				this.txtCity.Enabled = true;
				this.txtSt.Enabled = true;
				this.txtZipCode.Enabled = true;
				this.txtPhone.Enabled = true;
				this.txtEntryDate.Enabled = true;
                //-------------
                this.txtaddresssec1.Enabled = true;
                this.txtaddresssec2.Enabled = true;
                this.txtcity2.Enabled = true;
                this.txtstate2.Enabled = true;
                this.txtzip2.Enabled = true;

                this.txtwebsite.Enabled = true;
                this.txtfacebook.Enabled = true;
                this.txtinstagram.Enabled = true;
                this.txttwitter.Enabled = true;
                this.txtlinkedin.Enabled = true;
                this.txtothersm.Enabled = true;
                //------------new textbox-------------------
                this.txtname.Enabled = true;
                this.txtlast1.Enabled = true;
                this.txtlast2.Enabled = true;
                this.txtpostal.Enabled = true;
                this.txtoffice1.Enabled = true;
                this.txtoffice2.Enabled = true;
                this.txtphone2.Enabled = true;
                this.txtfax.Enabled = true;
                this.txtsale.Enabled = true;
                this.txtacco.Enabled = true;
                this.txtemail1.Enabled = true;
                this.txtemail2.Enabled = true;
                this.txtemail3.Enabled = true;
                this.txtemail4.Enabled = true;
                this.txtemail5.Enabled = true;
                this.txtssn.Enabled = true;
                this.txtlicexp.Enabled = true;
                this.txtlicnum.Enabled = true;
                this.ddltypelic.Enabled = true;
                this.ddlappl.Enabled = true;
                this.ddlocsa.Enabled = true;
                this.ddlcomm.Enabled = true;
                this.ddltaxwai.Enabled = true;
                this.ddleopolicy.Enabled = true;
                this.ddlmerchregis.Enabled = true;
                this.ddlpaymet.Enabled = true;
                //------------------------------------------

			}
			else
			{
				this.txtAgencyDescription.Enabled = false;
				this.txtAddress1.Enabled = false;
				this.txtAddress2.Enabled = false;
				this.txtCity.Enabled = false;
				this.txtSt.Enabled = false;
				this.txtZipCode.Enabled = false;
				this.txtPhone.Enabled = false;
				this.txtEntryDate.Enabled = false;
                //---------------
                this.txtaddresssec1.Enabled = false;
                this.txtaddresssec2.Enabled = false;
                this.txtcity2.Enabled = false;
                this.txtstate2.Enabled = false;
                this.txtzip2.Enabled = false;

                this.txtwebsite.Enabled = false;
                this.txtfacebook.Enabled = false;
                this.txtinstagram.Enabled = false;
                this.txttwitter.Enabled = false;
                this.txtlinkedin.Enabled = false;
                this.txtothersm.Enabled = false;
                //------------new textbox-------------------
                this.txtname.Enabled = false;
                this.txtlast1.Enabled = false;
                this.txtlast2.Enabled = false;
                this.txtpostal.Enabled = false;
                this.txtoffice1.Enabled = false;
                this.txtoffice2.Enabled = false;
                this.txtphone2.Enabled = false;
                this.txtfax.Enabled = false;
                this.txtsale.Enabled = false;
                this.txtacco.Enabled = false;
                this.txtemail1.Enabled = false;
                this.txtemail2.Enabled = false;
                this.txtemail3.Enabled = false;
                this.txtemail4.Enabled = false;
                this.txtemail5.Enabled = false;
                this.txtssn.Enabled = false;
                this.txtlicexp.Enabled = false;
                this.txtlicnum.Enabled = false;
                this.ddltypelic.Enabled = false;
                this.ddlappl.Enabled = false;
                this.ddlocsa.Enabled = false;
                this.ddlcomm.Enabled = false;
                this.ddltaxwai.Enabled = false;
                this.ddleopolicy.Enabled = false;
                this.ddlmerchregis.Enabled = false;
                this.ddlpaymet.Enabled = false;
                //------------------------------------------
			}
		}

		private void FillControls()
		{	
			LookupTables.Agency agency =
				(LookupTables.Agency)Session["Agency"];
			
			
			this.txtAgencyDescription.Text = (agency.AgencyDesc != "" ?
				agency.AgencyDesc.ToString():
				String.Empty);
			
			this.txtAddress1.Text = 
				agency.agy_addr1.Trim();

			this.txtAddress2.Text = 
				agency.agy_addr2.Trim();

			this.txtCity.Text =
				agency.agy_city.Trim();

            this.txtSt.Text = 
				agency.agy_st.Trim();

            this.txtZipCode.Text = 
				agency.agy_zip.Trim();

            this.txtPhone.Text = 
				agency.agy_phone.Trim();

            this.txtEntryDate.Text = 
				agency.agy_actdt.Trim();
            //----------------
             this.txtaddresssec1.Text = agency.agy_addresssec1.Trim();
            this.txtaddresssec2.Text = agency.agy_addresssec2.Trim();
            // this.txtcity2.Text =
            //     agency.agy_city2.Trim();
            // this.txtstate2.Text =
            //     agency.agy_state2.Trim();
            // this.txtzip2.Text =
            //     agency.agy_zip2.Trim();

            // this.txtwebsite.Text =
            //     agency.agy_website.Trim();
            // this.txtfacebook.Text =
            //     agency.agy_facebook.Trim();
            // this.txtinstagram.Text =
            //     agency.agy_instagram.Trim();
            // this.txttwitter.Text =
            //     agency.agy_twitter.Trim();
            // this.txtlinkedin.Text =
            //     agency.agy_linkedin.Trim();
            // this.txtothersm.Text =
            //     agency.agy_othersm.Trim();
            //------------new textbox-------------------
            // this.txtname.Text =
            //     agency.agy_name.Trim();

            // this.txtlast1.Text =
            //     agency.agy_lastname1.Trim();

            // this.txtlast2.Text =
            //     agency.agy_lastname2.Trim();

            // this.txtpostal.Text =
            //     agency.agy_AddPostal.Trim();

            // this.txtoffice1.Text =
            //     agency.agy_OfficePhone1.Trim();

            // this.txtoffice2.Text =
            //     agency.agy_OfficePhone2.Trim();

            // this.txtphone2.Text =
            //     agency.agy_phone2.Trim();

            // this.txtfax.Text =
            //     agency.agy_OfficeFax.Trim();

            // this.txtsale.Text =
            //     agency.agy_SalesCont.Trim();

            // this.txtacco.Text =
            //     agency.agy_AccoCont.Trim();

            // this.txtemail1.Text =
            //     agency.agy_ContEmail1.Trim();

            // this.txtemail2.Text =
            //     agency.agy_ContEmail2.Trim();

            // this.txtemail3.Text =
            //     agency.agy_ContEmail3.Trim();

            // this.txtemail4.Text =
            //     agency.agy_ContEmail4.Trim();

            // this.txtemail5.Text =
            //     agency.agy_ContEmail5.Trim();

            // this.txtssn.Text =
            //     agency.agy_ssn.Trim();

            // this.txtlicexp.Text =
            //     agency.agy_LicenseExpDate.Trim();

            // this.txtlicnum.Text =
            //     agency.agy_LicenseNumber.Trim();

            // this.ddltypelic.Text =
            //     agency.agy_TypeLicense.Trim();

            // this.ddlappl.Text =
            //     agency.agy_Application.Trim();

            // this.ddlocsa.Text =
            //     agency.agy_OCSApp.Trim();

            // this.ddlcomm.Text =
            //     agency.agy_CommAgree.Trim();

            // this.ddltaxwai.Text =
            //     agency.agy_TaxWaiver.Trim();

            // this.ddleopolicy.Text =
            //     agency.agy_EOPolicy.Trim();

            // this.ddlmerchregis.Text =
            //     agency.agy_MerchRegis.Trim();

            // this.ddlpaymet.Text =
            //     agency.agy_PaymentMethod.Trim();*/
            //------------------------------------------


		}
		protected void BtnSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
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

			LookupTables.Agency agency = 
				(LookupTables.Agency)Session["Agency"];
			try
			{
				switch(agency.ActionMode)
				{
					case 1: //ADD
						this.FillProperties(ref agency);
						agency.Save(userID);
						break;
					case 3: //DELETE
						break;
					case 4: //CLEAR
						break;
					default: //UPDATE
						this.FillProperties(ref agency);
						agency.Save(userID);
						Session["Agency"] = agency;
						this.SetControlState((int)UserAction.VIEW);
						break;
				}
				this.litPopUp.Text = 
					Utilities.MakeLiteralPopUpString(
					"The Agency information saved successfully.");
				this.litPopUp.Visible = true;
				this.SetAgencyNumerationLabel();
				this.SetControlState((int)UserAction.SAVE);

				Session["Agency"] = agency;
			}
			catch(Exception xcp)
			{
				this.ShowMessage("Unable to save or modify Agency. " + xcp.Message);
			}
		}

		private void cmdCancel1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		
		}

		protected void cmdCancel_Click(object sender, System.EventArgs e)
		{		
			LookupTables.Agency agency = (LookupTables.Agency)Session["Agency"];
			
			if(agency.ActionMode == 1) //ADD
				Response.Redirect("LookupTableMaintenance.aspx");
			else
			{
				this.SetControlState((int)UserAction.CANCEL);
			}
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(
				"SearchLookupTableDescriptions.aspx?SelectedItem=" + 
				LookupTables.LookupTables.GetLookupTableIdFromTableName(
				"Agency").ToString());
		}

		protected void btnAddNew_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Agency.aspx");
		}

		protected void btnEdit_Click(object sender, System.EventArgs e)
		{
			LookupTables.Agency agency =
				(LookupTables.Agency)Session["Agency"];			
			agency.ActionMode = 2;
			Session["Agency"] = agency;
			this.SetControlState((int)UserAction.EDIT);
		}

		protected void btnPrint_Click(object sender, System.EventArgs e)
		{
			EPolicy2.Reports.AdministrativeTools atreport = new EPolicy2.Reports.AdministrativeTools();
			DataTable dt = atreport.AgencyList();

            DataDynamics.ActiveReports.ActiveReport3 rpt = new GeneralList("Agency");
			
			//rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;

			rpt.DataSource = dt;
			rpt.DataMember = "Report";
			rpt.Run(false);

			Session.Add("Report",rpt);
			Session.Add("FromPage",LookupTables.LookupTables.GetTableMaintenancePathFromTableID(25)+ "?item=" + this.lblAgencyID.Text);
			Response.Redirect("ActiveXViewer.aspx",false);		
		}

		protected void btnCommission_Click(object sender, System.EventArgs e)
		{
			LookupTables.Agency agency = (LookupTables.Agency) Session["Agency"];

			Response.Redirect("CommissionAgency.aspx?" +agency.AgencyID);		
		}

		protected void btnAuditTrail_Click(object sender, System.EventArgs e)
		{
			if(Session["Agency"] != null)
			{
				LookupTables.Agency agency = (LookupTables.Agency) Session["Agency"];
				Response.Redirect("SearchAuditItems.aspx?type=3&agencyID=" + 
					agency.AgencyID.Trim());
			}
		}

	
		protected void Button2_Click(object sender, System.EventArgs e)
		{
			LookupTables.Agency agency = (LookupTables.Agency)Session["Agency"];
			
			if(agency.ActionMode == 1) //ADD
				Response.Redirect("LookupTableMaintenance.aspx");
			else
			{
				Response.Redirect(
					"SearchLookupTableDescriptions.aspx?SelectedItem=" + 
					LookupTables.LookupTables.GetLookupTableIdFromTableName(
					"Agency").ToString());
			}
		}//End BtnSave_Click

		
		
		private void ShowMessage(string MessageText)
		{
			this.litPopUp.Text = 
				Utilities.MakeLiteralPopUpString(MessageText);
			this.litPopUp.Visible = true;
		}

		private void FillProperties(ref LookupTables.Agency Agency)
		{	
			try
			{
				Agency.AgencyDesc = (this.txtAgencyDescription.Text.ToString().ToUpper());
			}
			catch
			{
				this.ShowMessage("Could not fill 'AgencyID' property. " +
					"Please enter a valid value for this field.");
			}
			
			Agency.agy_addr1 = this.txtAddress1.Text.ToString().ToUpper();
			Agency.agy_addr2 = this.txtAddress2.Text.ToString().ToUpper();
			Agency.agy_city = this.txtCity.Text.ToString().ToUpper();
			Agency.agy_st = this.txtSt.Text.ToString().ToUpper();
			Agency.agy_zip = this.txtZipCode.Text;
			Agency.agy_phone = this.txtPhone.Text;
			Agency.agy_actdt = this.txtEntryDate.Text;
            //--------------
            Agency.agy_addresssec1 = this.txtaddresssec1.Text.ToString().ToUpper();
            Agency.agy_addresssec2 = this.txtaddresssec2.Text.ToString().ToUpper();
            Agency.agy_city2 = this.txtcity2.Text.ToString().ToUpper();
            Agency.agy_state2 = this.txtstate2.Text.ToString().ToUpper();
            Agency.agy_zip2 = this.txtzip2.Text.ToString().ToUpper();

            Agency.agy_website = this.txtwebsite.Text.ToString().ToUpper();
            Agency.agy_facebook = this.txtfacebook.Text.ToString().ToUpper();
            Agency.agy_instagram = this.txtinstagram.Text.ToString().ToUpper();
            Agency.agy_twitter = this.txttwitter.Text.ToString().ToUpper();
            Agency.agy_linkedin = this.txtlinkedin.Text.ToString().ToUpper();
            Agency.agy_othersm = this.txtothersm.Text.ToString().ToUpper();
            //------------new textbox-------------------
            Agency.agy_name = this.txtname.Text.ToString().ToUpper();
            Agency.agy_lastname1 = this.txtlast1.Text.ToString().ToUpper();
            Agency.agy_lastname2 = this.txtlast2.Text.ToString().ToUpper();
            Agency.agy_AddPostal = this.txtpostal.Text.ToString().ToUpper();
            Agency.agy_OfficePhone1 = this.txtoffice1.Text.ToString().ToUpper();
            Agency.agy_OfficePhone2 = this.txtoffice2.Text.ToString().ToUpper();
            Agency.agy_phone2 = this.txtphone2.Text.ToString().ToUpper();
            Agency.agy_OfficeFax = this.txtfax.Text.ToString().ToUpper();
            Agency.agy_SalesCont = this.txtsale.Text.ToString().ToUpper();
            Agency.agy_AccoCont = this.txtacco.Text.ToString().ToUpper();
            Agency.agy_ContEmail1 = this.txtemail1.Text.ToString().ToUpper();
            Agency.agy_ContEmail2 = this.txtemail2.Text.ToString().ToUpper();
            Agency.agy_ContEmail3 = this.txtemail3.Text.ToString().ToUpper();
            Agency.agy_ContEmail4 = this.txtemail4.Text.ToString().ToUpper();
            Agency.agy_ContEmail5 = this.txtemail5.Text.ToString().ToUpper();
            Agency.agy_ssn = this.txtssn.Text.ToString().ToUpper();
            Agency.agy_LicenseExpDate = this.txtlicexp.Text.ToString().ToUpper();
            Agency.agy_LicenseNumber = this.txtlicnum.Text.ToString().ToUpper();
            
            Agency.agy_TypeLicense = this.ddltypelic.Text.ToString();
            Agency.agy_Application = this.ddlappl.Text.ToString();
            Agency.agy_OCSApp = this.ddlocsa.Text.ToString();
            Agency.agy_CommAgree = this.ddlcomm.Text.ToString();
            Agency.agy_TaxWaiver = this.ddltaxwai.Text.ToString();
            Agency.agy_EOPolicy = this.ddleopolicy.Text.ToString();
            Agency.agy_MerchRegis = this.ddlmerchregis.Text.ToString();
            Agency.agy_PaymentMethod = this.ddlpaymet.Text.ToString();
            //------------------------------------------

}

	  
			
			private void BtnExit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			LookupTables.Agency agency = 
				(LookupTables.Agency)Session["Agency"];
			
			if(agency.ActionMode == 1) //ADD
				Response.Redirect("LookupTableMaintenance.aspx");
			else
			{
				Response.Redirect(
					"SearchLookupTableDescriptions.aspx?SelectedItem=" + 
					LookupTables.LookupTables.GetLookupTableIdFromTableName(
					"Agency").ToString());
			}
		}


       protected void cmdCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.SetControlState((int)UserAction.CANCEL);
		}

		protected void btnEdit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			LookupTables.Agency agency =
				(LookupTables.Agency)Session["Agency"];			
			agency.ActionMode = 2;
			Session["Agency"] = agency;
			this.SetControlState((int)UserAction.EDIT);
		}

		private bool IsNavigationTableNull()
		{
			LookupTables.Agency agency = 
				(LookupTables.Agency)Session["agency"];
			if(agency.NavigationViewModelTable == null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected void btnAddNew_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("Agency.aspx");
		}

		protected void btnSearch_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect(
				"SearchLookupTableDescriptions.aspx?SelectedItem=" + 
				LookupTables.LookupTables.GetLookupTableIdFromTableName(
				"Agency").ToString());
		}

		protected void btnCommission_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			LookupTables.Agency agency = (LookupTables.Agency) Session["Agency"];

			Response.Redirect("CommissionAgency.aspx?" +agency.AgencyID);
		}

		protected void btnPrint_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			EPolicy2.Reports.AdministrativeTools atreport = new EPolicy2.Reports.AdministrativeTools();
			DataTable dt = atreport.AgencyList();

            DataDynamics.ActiveReports.ActiveReport3 rpt = new GeneralList("Agency");
			
			//rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;

			rpt.DataSource = dt;
			rpt.DataMember = "Report";
			rpt.Run(false);

			Session.Add("Report",rpt);
			Session.Add("FromPage",LookupTables.LookupTables.GetTableMaintenancePathFromTableID(25)+ "?item=" + this.lblAgencyID.Text);
			Response.Redirect("ActiveXViewer.aspx",false);

		}

		protected void btnAuditTrail_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(Session["Agency"] != null)
			{
				LookupTables.Agency agency = (LookupTables.Agency) Session["Agency"];
				Response.Redirect("SearchAuditItems.aspx?type=3&agencyID=" + 
					agency.AgencyID.Trim());
			}
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

			LookupTables.Agency agency = 
				(LookupTables.Agency)Session["Agency"];
			try
			{
				switch(agency.ActionMode)
				{
					case 1: //ADD
						this.FillProperties(ref agency);
						agency.Save(userID);
						break;
					case 3: //DELETE
						break;
					case 4: //CLEAR
						break;
					default: //UPDATE
						this.FillProperties(ref agency);
						agency.Save(userID);
						Session["Agency"] = agency;
						this.SetControlState((int)UserAction.VIEW);
						break;
				}
				this.litPopUp.Text = 
					Utilities.MakeLiteralPopUpString(
					"The Agency information saved successfully.");
				this.litPopUp.Visible = true;
				this.SetAgencyNumerationLabel();
				this.SetControlState((int)UserAction.SAVE);

				Session["Agency"] = agency;
			}
			catch(Exception xcp)
			{
				this.ShowMessage("Unable to save or modify Agency. " + xcp.Message);
			}
		}



}
	}





