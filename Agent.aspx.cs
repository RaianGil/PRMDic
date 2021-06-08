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
	/// Summary description for Agent.
	/// </summary>
	public partial class Agent : System.Web.UI.Page
	{
	    private Control LeftMenu;

		#region Enumerations

		public enum UserAction{ADD = 1, VIEW = 2, SAVE = 3, EDIT = 4, CANCEL = 5};
		
		#endregion

       
		private void SetAgentNumerationLabel()
		{
			LookupTables.Agent agent = 
				(LookupTables.Agent)Session["Agent"];

			this.lblAgentID.Text = (agent.AgentID != "") ?
				agent.AgentID.ToString():
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
			   if(!cp.IsInRole("AGENT") && !cp.IsInRole("ADMINISTRATOR"))
			   {
				   Response.Redirect("HomePage.aspx?001");
			   }
		   }

		   if(!Page.IsPostBack)
		   {
               DataTable dtAgency = LookupTables.LookupTables.GetTable("Agency");
               ddlAgency.DataSource = dtAgency;
               ddlAgency.DataTextField = "AgencyDesc";
               ddlAgency.DataValueField = "AgencyID";
               ddlAgency.DataBind();
               ddlAgency.SelectedIndex = -1;
               ddlAgency.Items.Insert(0, "");

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
							
			   LookupTables.Agent agent = new LookupTables.Agent();
               
			   if(Request.QueryString["item"] != null &&																	
				   Request.QueryString["item"].ToString() != String.Empty)
			   {	
				   try
				   {
					   agent.GetAgent(Request.QueryString["item"].ToString());
					   agent.ActionMode = 2; //UPDATE
					   agent.NavigationViewModelTable = 
						   (DataTable)Session["DtRecordsForNonValuePairLookupTable"];
					   Session["Agent"] = agent;
				   }
				   catch(Exception ex)
				   {
					   this.ShowMessage("There is no Agent for the supplied " +
						   "ID. " + ex.Message);
				   }
			   }
			   else
			   {
				   agent.ActionMode = 1; //ADD
				   Session["Agent"] = agent;
			   }
				
		   }

		   if(Session["Agent"] != null)
		   {
			   LookupTables.Agent agent = 
				   (LookupTables.Agent)Session["Agent"];


			   this.InitializeControls();
			
			   switch(agent.ActionMode)
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
                       LoadAgencyGrid();
                       
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
            //phTopBanner1.Controls.Add(LeftMenu);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{   
			this.btnEdit1.Click += new System.Web.UI.ImageClickEventHandler(this.btnEdit_Click);
			this.BtnSave1.Click += new System.Web.UI.ImageClickEventHandler(this.BtnSave_Click);
			this.btnSearch1.Click += new System.Web.UI.ImageClickEventHandler(this.btnSearch_Click);
			this.cmdCancel1.Click += new System.Web.UI.ImageClickEventHandler(this.cmdCancel_Click);
			this.btnPrint1.Click += new System.Web.UI.ImageClickEventHandler(this.btnPrint_Click);
			this.btnAuditTrail1.Click += new System.Web.UI.ImageClickEventHandler(this.btnAuditTrail_Click);
			this.BtnExit1.Click += new System.Web.UI.ImageClickEventHandler(this.BtnExit_Click);

		}
		#endregion

		
		
		
		private void InitializeControls()
		{
			this.SetAgentNumerationLabel();
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
					this.btnAuditTrail.Visible = false;
					this.btnPrint.Visible = false;
					this.btnSearch.Visible = false;
					this.BtnExit.Visible = false;
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
					this.BtnExit.Visible = true;
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
					this.BtnExit.Visible = false;
					break;
				default: //CANCEL ACTION
					LookupTables.Agent agent = 
						(LookupTables.Agent)Session["Agent"];
					if(agent.ActionMode == 0) //ADD
					{
						Session["Agent"] = null;
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
                this.txtAgentDescription.Enabled = true;
				this.txtAddress1.Enabled = true;
                ////---------------textbox nuevos----------------
                this.txtlast1.Enabled = true;
                this.txtlast2.Enabled = true;
                this.txtsales.Enabled = true;
                this.txtacco.Enabled = true;
                this.txtemail1.Enabled = true;
                this.txtemail2.Enabled = true;
                this.txtemail3.Enabled = true;
                this.txtemail4.Enabled = true;
                this.txtemail5.Enabled = true;
                this.txtoff1.Enabled = true;
                this.txtoff2.Enabled = true;
                this.txtfax.Enabled = true;
                this.txtlicexp.Enabled = true;
                this.txtphone2.Enabled = true;

                this.txtwebsite.Enabled = true;
                this.txtfacebook.Enabled = true;
                this.txtinstagram.Enabled = true;
                this.txttwitter.Enabled = true;
                this.txtlinkedin.Enabled = true;
                this.txtothersm.Enabled = true;
                ////------------------------------
                this.txtinicial.Enabled = true;
				this.txtAddress2.Enabled = true;
				this.txtCity.Enabled = true;
				this.txtSt.Enabled = true;
				this.txtZipCode.Enabled = true;
                //-------------
                this.txtaddresssec1.Enabled = true;
                this.txtaddresssec2.Enabled = true;
                this.txtcity2.Enabled = true;
                this.txtstate2.Enabled = true;
                this.txtzip2.Enabled = true;

				this.txtPhone.Enabled = true;
				//this.txtEntryDate.Enabled = true;
                this.txtEmail.Enabled = true;
                this.txtSocialSecurity.Enabled = true;
                txtLicenseNum.Enabled = true;
                txtLicenseNumExpDate.Enabled = true;
                this.chkAllComm.Enabled = true;
                this.chkAccountType.Enabled = true;
                this.txtBanco.Enabled = true;
                this.txtNumCuenta.Enabled = true;
                this.txtNumRuta.Enabled = true;
                //--------------ddl nuevos-------------------
                this.ddltypelic.Enabled = true;
                this.ddlappl.Enabled = true;
                this.ddlocsa.Enabled = true;
                this.ddlcomm.Enabled = true;
                this.ddltaxwai.Enabled = true;
                this.ddleopolicy.Enabled = true;
                this.ddlmerchregis.Enabled = true;
                this.ddlpaymet.Enabled = true;
                //----------------opc sent to---------------
                this.rbsentto.Enabled = true;
                //------------------------------------------
                this.ddlAgency.Enabled = true;
			}
			else
			{
                this.txtAgentDescription.Enabled = false;
				this.txtAddress1.Enabled = false;
                this.txtinicial.Enabled = false;
                ////--------------textbox nuevos---------------
                this.txtlast1.Enabled = false;
                this.txtlast2.Enabled = false;
                this.txtsales.Enabled = false;
                this.txtacco.Enabled = false;
                this.txtemail1.Enabled = false;
                this.txtemail2.Enabled = false;
                this.txtemail3.Enabled = false;
                this.txtemail4.Enabled = false;
                this.txtemail5.Enabled = false;
                this.txtoff1.Enabled = false;
                this.txtoff2.Enabled = false;
                this.txtfax.Enabled = false;
                this.txtlicexp.Enabled = false;
                this.txtphone2.Enabled = false;

                this.txtwebsite.Enabled = false;
                this.txtfacebook.Enabled = false;
                this.txtinstagram.Enabled = false;
                this.txttwitter.Enabled = false;
                this.txtlinkedin.Enabled = false;
                this.txtothersm.Enabled = false;
                ////-----------------------------
				this.txtAddress2.Enabled = false;
				this.txtCity.Enabled = false;
				this.txtSt.Enabled = false;
				this.txtZipCode.Enabled = false;
                //---------------
                this.txtaddresssec1.Enabled = false;
                this.txtaddresssec2.Enabled = false;
                this.txtcity2.Enabled = false;
                this.txtstate2.Enabled = false;
                this.txtzip2.Enabled = false;

				this.txtPhone.Enabled = false;
				this.txtEntryDate.Enabled = false;
                this.txtEmail.Enabled = false;
                this.txtSocialSecurity.Enabled = false;
                this.txtLicenseNum.Enabled = false;
                this.txtLicenseNumExpDate.Enabled = false;
                this.chkAllComm.Enabled = false;
                this.chkAccountType.Enabled = false;
                this.txtBanco.Enabled = false;
                this.txtNumCuenta.Enabled = false;
                this.txtNumRuta.Enabled = false;
                //--------------ddl nuevos-------------------
                this.ddltypelic.Enabled = false;
                this.ddlappl.Enabled = false;
                this.ddlocsa.Enabled = false;
                this.ddlcomm.Enabled = false;
                this.ddltaxwai.Enabled = false;
                this.ddleopolicy.Enabled = false;
                this.ddlmerchregis.Enabled = false;
                this.ddlpaymet.Enabled = false;
                //----------------opc sent to---------------
                this.rbsentto.Enabled = false;
                //------------------------------------------
                this.ddlAgency.Enabled = false;
			}
		}

		private void FillControls()
		{	
			LookupTables.Agent agent =
				(LookupTables.Agent)Session["Agent"];


            this.txtAgentDescription.Text = (agent.AgentDesc != "" ?
				agent.AgentDesc.ToString():
				String.Empty);
			
			this.txtAddress1.Text = 
				agent.agt_addr1.Trim();

            this.txtinicial.Text =
            agent.agt_inicial.Trim();

            ////--------------------------
            this.txtlast1.Text =
            agent.agt_lastname1.Trim();

            this.txtlast2.Text =
            agent.agt_lastname2.Trim();

            this.txtsales.Text =
            agent.agt_salescontact.Trim();

            this.txtacco.Text =
            agent.agt_AccoContact.Trim();

            this.txtemail1.Text =
            agent.agt_ContactEmail1.Trim();

            this.txtemail2.Text =
            agent.agt_ContactEmail2.Trim();

            this.txtemail3.Text =
            agent.agt_ContactEmail3.Trim();

            this.txtemail4.Text =
            agent.agt_ContactEmail4.Trim();

            this.txtemail5.Text =
            agent.agt_ContactEmail5.Trim();

            this.txtoff1.Text =
            agent.agt_OfficePhone1.Trim();

            this.txtoff2.Text =
            agent.agt_OfficePhone2.Trim();

            this.txtphone2.Text =
            agent.agt_phone2.Trim();

            this.txtfax.Text =
            agent.agt_OfficeFax.Trim();

            this.txtlicexp.Text =
            agent.agt_LicenseExpDate.Trim();


            this.txtwebsite.Text =
            agent.agt_website.Trim();

            this.txtfacebook.Text =
            agent.agt_facebook.Trim();

            this.txtinstagram.Text =
            agent.agt_instagram.Trim();

            this.txttwitter.Text =
            agent.agt_twitter.Trim();

            this.txtlinkedin.Text =
            agent.agt_linkedin.Trim();

            this.txtothersm.Text =
            agent.agt_othersm.Trim();

            ////----------------------------

			this.txtAddress2.Text = 
				agent.agt_addr2.Trim();

			this.txtCity.Text =
				agent.agt_city.Trim();

			this.txtSt.Text = 
				agent.agt_st.Trim();

			this.txtZipCode.Text = 
				agent.agt_zip.Trim();

            //----------------
            this.txtaddresssec1.Text =
                agent.agt_addresssec1.Trim();
            this.txtaddresssec2.Text =
                agent.agt_addresssec2.Trim();
            this.txtcity2.Text =
                agent.agt_city2.Trim();
            this.txtstate2.Text =
                agent.agt_state2.Trim();
            this.txtzip2.Text =
                agent.agt_zip2.Trim();


			this.txtPhone.Text = 
				agent.agt_phone.Trim();

			this.txtEntryDate.Text = 
				agent.agt_actdt.Trim();

            this.txtEmail.Text =
                agent.agt_email.Trim();

            this.txtSocialSecurity.Text =
                agent.agt_socialsecurity.Trim();

            this.txtLicenseNum.Text =
                agent.agt_licensenum.Trim();

            this.txtLicenseNumExpDate.Text =
                agent.agt_licensenumexpdate.Trim();

            this.chkAllComm.Checked = agent.AllComm;
            this.chkAccountType.SelectedIndex = chkAccountType.Items.IndexOf(chkAccountType.Items.FindByValue(agent.AccountType));
            //-------------chk nuevo---------------------
            this.rbsentto.SelectedIndex = rbsentto.Items.IndexOf(rbsentto.Items.FindByValue(agent.agt_sent));
            //-------------------------------------------
            this.txtBanco.Text = agent.Banco.ToString().Trim();
            this.txtNumRuta.Text = agent.NumRuta.ToString().Trim();
            this.txtNumCuenta.Text = agent.NumCuenta.ToString().Trim();
            //-------------ddl nuevos--------------------
            this.ddltypelic.SelectedIndex = ddltypelic.Items.IndexOf(ddltypelic.Items.FindByValue(agent.agt_TypeLicense));
            this.ddlappl.SelectedIndex = ddlappl.Items.IndexOf(ddlappl.Items.FindByValue(agent.agt_Application));
            this.ddlocsa.SelectedIndex = ddlocsa.Items.IndexOf(ddlocsa.Items.FindByValue(agent.agt_OCSApp));
            this.ddlcomm.SelectedIndex = ddlcomm.Items.IndexOf(ddlcomm.Items.FindByValue(agent.agt_CommAgree));
            this.ddltaxwai.SelectedIndex = ddltaxwai.Items.IndexOf(ddltaxwai.Items.FindByValue(agent.agt_TaxWaiver));
            this.ddleopolicy.SelectedIndex = ddleopolicy.Items.IndexOf(ddleopolicy.Items.FindByValue(agent.agt_EOPolicy));
            this.ddlmerchregis.SelectedIndex = ddlmerchregis.Items.IndexOf(ddlmerchregis.Items.FindByValue(agent.agt_MerchRegis));
            this.ddlpaymet.SelectedIndex = ddlpaymet.Items.IndexOf(ddlpaymet.Items.FindByValue(agent.agt_PaymentMethod));
            //-------------------------------------------
            this.ddlAgency.SelectedIndex = ddlAgency.Items.IndexOf(ddlAgency.Items.FindByValue(agent.Agency));
            GridAgency.Visible = true;
            LoadAgencyGrid();
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

			LookupTables.Agent agent = 
				(LookupTables.Agent)Session["Agent"];
			try
			{
				switch(agent.ActionMode)
				{
					case 1: //ADD
						this.FillProperties(ref agent);
						agent.Save(userID);
						break;
					case 3: //DELETE
						break;
					case 4: //CLEAR
						break;
					default: //UPDATE
						this.FillProperties(ref agent);
						agent.Save(userID);
						Session["Agent"] = agent;
						this.SetControlState((int)UserAction.VIEW);
						break;
				}
				this.litPopUp.Text = 
					Utilities.MakeLiteralPopUpString(
					"The Agent information saved successfully.");
				this.litPopUp.Visible = true;
				this.SetAgentNumerationLabel();
				this.SetControlState((int)UserAction.SAVE);

				Session["Agent"] = agent;
			}
			catch(Exception xcp)
			{
				this.ShowMessage("Unable to save or modify Agent. " + xcp.Message);
			}
		}//End BtnSave_Click



		private void ShowMessage(string MessageText)
		{
			this.litPopUp.Text = 
				Utilities.MakeLiteralPopUpString(MessageText);
			this.litPopUp.Visible = true;
		}

		private void FillProperties(ref LookupTables.Agent agent)
		{	
			try
			{
                agent.AgentDesc = (this.txtAgentDescription.Text.ToString().ToUpper());
			}
			catch
			{
				this.ShowMessage("Could not fill 'AgentID' property. " +
					"Please enter a valid value for this field.");
			}
			agent.agt_addr1 = this.txtAddress1.Text.ToString().ToUpper();
            agent.agt_inicial = this.txtinicial.Text.ToString().ToUpper();
            ////----------------------------
            agent.agt_lastname1 = this.txtlast1.Text.ToString().ToUpper();
            agent.agt_lastname2 = this.txtlast2.Text.ToString().ToUpper();
            agent.agt_salescontact = this.txtsales.Text.ToString().ToUpper();
            agent.agt_AccoContact = this.txtacco.Text.ToString().ToUpper();
            agent.agt_ContactEmail1 = this.txtemail1.Text.ToString().ToUpper();
            agent.agt_ContactEmail2 = this.txtemail2.Text.ToString().ToUpper();
            agent.agt_ContactEmail3 = this.txtemail3.Text.ToString().ToUpper();
            agent.agt_ContactEmail4 = this.txtemail4.Text.ToString().ToUpper();
            agent.agt_ContactEmail5 = this.txtemail5.Text.ToString().ToUpper();
            agent.agt_OfficePhone1 = this.txtoff1.Text.ToString().ToUpper();
            agent.agt_OfficePhone2 = this.txtoff2.Text.ToString().ToUpper();
            agent.agt_phone2 = this.txtphone2.Text.ToString().ToUpper();
            agent.agt_OfficeFax = this.txtfax.Text.ToString().ToUpper();
            agent.agt_LicenseExpDate = this.txtlicexp.Text.ToString().ToUpper();

            agent.agt_website = this.txtwebsite.Text.ToString().ToUpper();
            agent.agt_facebook = this.txtfacebook.Text.ToString().ToUpper();
            agent.agt_instagram = this.txtinstagram.Text.ToString().ToUpper();
            agent.agt_twitter = this.txttwitter.Text.ToString().ToUpper();
            agent.agt_linkedin = this.txtlinkedin.Text.ToString().ToUpper();
            agent.agt_othersm = this.txtothersm.Text.ToString().ToUpper();
            //----------------------------
			agent.agt_addr2 = this.txtAddress2.Text.ToString().ToUpper();
			agent.agt_city = this.txtCity.Text.ToString().ToUpper();
			agent.agt_st = this.txtSt.Text.ToString().ToUpper();
			agent.agt_zip = this.txtZipCode.Text;
            //--------------
            agent.agt_addresssec1 = this.txtaddresssec1.Text.ToString().ToUpper();
            agent.agt_addresssec2 = this.txtaddresssec2.Text.ToString().ToUpper();
            agent.agt_city2 = this.txtcity2.Text.ToString().ToUpper();
            agent.agt_state2 = this.txtstate2.Text.ToString().ToUpper();
            agent.agt_zip2 = this.txtzip2.Text.ToString().ToUpper();

			agent.agt_phone = this.txtPhone.Text;
			agent.agt_actdt = this.txtEntryDate.Text;
            agent.agt_email = this.txtEmail.Text;
            agent.agt_socialsecurity = this.txtSocialSecurity.Text;
            agent.agt_licensenum = this.txtLicenseNum.Text;
            agent.agt_licensenumexpdate = this.txtLicenseNumExpDate.Text;
            agent.AllComm = this.chkAllComm.Checked;
            if (chkAccountType.SelectedItem != null)
                agent.AccountType = this.chkAccountType.SelectedItem.Value.Trim();
            else
                agent.AccountType = "";
            //----------------chk nuevo-----------------------
            if (rbsentto.SelectedItem != null)
                agent.agt_sent = this.rbsentto.SelectedItem.Value.Trim();
            else
                agent.agt_sent = "";
            //-----------------------------------------------
            agent.Banco = this.txtBanco.Text.ToString().Trim();
            agent.NumCuenta = this.txtNumCuenta.Text.ToString().Trim();
            agent.NumRuta = this.txtNumRuta.Text.ToString().Trim();
            //----------------nuevos ddl---------------------
            agent.agt_TypeLicense = ddltypelic.SelectedValue.ToString().Trim();
            agent.agt_Application = ddlappl.SelectedValue.ToString().Trim();
            agent.agt_OCSApp = ddlocsa.SelectedValue.ToString().Trim();
            agent.agt_CommAgree = ddlcomm.SelectedValue.ToString().Trim();
            agent.agt_TaxWaiver = ddltaxwai.SelectedValue.ToString().Trim();
            agent.agt_EOPolicy = ddleopolicy.SelectedValue.ToString().Trim();
            agent.agt_MerchRegis = ddlmerchregis.SelectedValue.ToString().Trim();
            agent.agt_PaymentMethod = ddlpaymet.SelectedValue.ToString().Trim();
            //-----------------------------------------------
            agent.Agency = ddlAgency.SelectedValue.ToString().Trim();
		}

	  
			
		protected void BtnExit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			LookupTables.Agent agent = 
				(LookupTables.Agent)Session["Agent"];
			
			if(agent.ActionMode == 1) //ADD
				Response.Redirect("LookupTableMaintenance.aspx");
			else
			{
				Response.Redirect(
					"SearchLookupTableDescriptions.aspx?SelectedItem=" + 
					LookupTables.LookupTables.GetLookupTableIdFromTableName(
					"Agent").ToString());
			}
		}


		protected void cmdCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.SetControlState((int)UserAction.CANCEL);
		}

		protected void btnEdit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			LookupTables.Agent agent =
				(LookupTables.Agent)Session["Agent"];			
			agent.ActionMode = 2;
			Session["Agent"] = agent;
			this.SetControlState((int)UserAction.EDIT);
		}

		private bool IsNavigationTableNull()
		{
			LookupTables.Agent agent = 
				(LookupTables.Agent)Session["agent"];
			if(agent.NavigationViewModelTable == null)
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
			Response.Redirect("Agent.aspx");
		}

		protected void btnSearch_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect(
				"SearchLookupTableDescriptions.aspx?SelectedItem=" + 
				LookupTables.LookupTables.GetLookupTableIdFromTableName(
				"Agent").ToString());
		}

		protected void btnPrint_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			EPolicy2.Reports.AdministrativeTools atreport = new EPolicy2.Reports.AdministrativeTools();
			DataTable dt = atreport.AgentList();
	
			DataDynamics.ActiveReports.ActiveReport3 rpt = new  GeneralList("Agent");
			
			//rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;

			rpt.DataSource = dt;
			rpt.DataMember = "Report";
			rpt.Run(false);

			Session.Add("Report",rpt);
			Session.Add("FromPage",LookupTables.LookupTables.GetTableMaintenancePathFromTableID(26)+ "?item=" + this.lblAgentID.Text);
			Response.Redirect("ActiveXViewer.aspx",false);
		}

		protected void btnAddNew_Click(object sender, System.EventArgs e) // Alexis Nuevo para Kayla
		{
            try
            {
                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
                LookupTables.Agent agent = (LookupTables.Agent)Session["Agent"];
                DataTable dtAgency = null;

                if (agent.AgentID != null && agent.AgentID.ToString() != "")
                {
                    agent.AddAgencyBelongsTo(agent.AgentID, ddlAgency.SelectedItem.Value);
                    GridAgency.CurrentPageIndex = 0;
                    GridAgency.Visible = true;
                    dtAgency = agent.GetAgencyBelongsTo(agent.AgentID);    //, ddlAgency.SelectedItem.Text);
                }
                else
                {
                    throw new Exception("Please save the current agent before adding a new agency.");
                }
                if (dtAgency.Rows.Count != 0)
                {
                    GridAgency.Visible = true;
                    GridAgency.DataSource = dtAgency;
                    GridAgency.DataBind();
                }
            }
            catch (Exception ex)
            {
              this.ShowMessage(ex.Message);
            }
            

		}

        protected void LoadAgencyGrid() // Alexis Nuevo para Kayla
		{
        
            DataTable dtAgency = null;
            LookupTables.Agent agent = (LookupTables.Agent)Session["Agent"];
            dtAgency = agent.GetAgencyBelongsTo(agent.AgentID);

            GridAgency.CurrentPageIndex = 0;
            GridAgency.Visible = true;

            if (dtAgency.Rows.Count != 0)
            {
                GridAgency.Visible = true;
                GridAgency.DataSource = dtAgency;
                GridAgency.DataBind();
            }

        }

		protected void btnEdit_Click(object sender, System.EventArgs e)
		{
			LookupTables.Agent agent =
				(LookupTables.Agent)Session["Agent"];			
			agent.ActionMode = 2;
			Session["Agent"] = agent;
			this.SetControlState((int)UserAction.EDIT);
         
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

			LookupTables.Agent agent = 
				(LookupTables.Agent)Session["Agent"];
			try
			{
				switch(agent.ActionMode)
				{
					case 1: //ADD
						this.FillProperties(ref agent);
						agent.Save(userID);
						break;
					case 3: //DELETE
						break;
					case 4: //CLEAR
						break;
					default: //UPDATE
						this.FillProperties(ref agent);
						agent.Save(userID);
						Session["Agent"] = agent;
						this.SetControlState((int)UserAction.VIEW);
						break;
				}
				this.litPopUp.Text = 
					Utilities.MakeLiteralPopUpString(
					"The Agent information saved successfully.");
				this.litPopUp.Visible = true;
				this.SetAgentNumerationLabel();
				this.SetControlState((int)UserAction.SAVE);

				Session["Agent"] = agent;
			}
			catch(Exception xcp)
			{
				this.ShowMessage("Unable to save or modify Agent. " + xcp.Message);
			}
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(
				"SearchLookupTableDescriptions.aspx?SelectedItem=" + 
				LookupTables.LookupTables.GetLookupTableIdFromTableName(
				"Agent").ToString());
		}

		protected void cmdCancel_Click(object sender, System.EventArgs e)
		{		
			LookupTables.Agent agent = (LookupTables.Agent)Session["Agent"];
			
			if(agent.ActionMode == 1) //ADD
				Response.Redirect("LookupTableMaintenance.aspx");
			else
			{
				this.SetControlState((int)UserAction.CANCEL);
			}
		}

		protected void btnAuditTrail_Click(object sender, System.EventArgs e)
		{
			if(Session["Agent"] != null)
			{
				LookupTables.Agent agent = (LookupTables.Agent) Session["Agent"];
				Response.Redirect("SearchAuditItems.aspx?type=4&agentID=" + 
					agent.AgentID.Trim());
			}
		}

		protected void BtnExit_Click(object sender, System.EventArgs e)
		{
			LookupTables.Agent agent = 
				(LookupTables.Agent)Session["Agent"];
			
			if(agent.ActionMode == 1) //ADD
				Response.Redirect("LookupTableMaintenance.aspx");
			else
			{
				Response.Redirect(
					"SearchLookupTableDescriptions.aspx?SelectedItem=" + 
					LookupTables.LookupTables.GetLookupTableIdFromTableName(
					"Agent").ToString());
			}
		}

		protected void btnAuditTrail_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(Session["Agent"] != null)
			{
				LookupTables.Agent agent = (LookupTables.Agent) Session["Agent"];
				Response.Redirect("SearchAuditItems.aspx?type=4&agentID=" + 
					agent.AgentID.Trim());
			}
		}

		protected void btnCommission_Click(object sender, System.EventArgs e)
		{
			LookupTables.Agent agent = (LookupTables.Agent) Session["Agent"];
			Response.Redirect("CommissionAgent.aspx?" +agent.AgentID);
		}

		protected void btnPrint_Click(object sender, System.EventArgs e)
		{
			EPolicy2.Reports.AdministrativeTools atreport = new EPolicy2.Reports.AdministrativeTools();
			DataTable dt = atreport.AgentList();
	
			DataDynamics.ActiveReports.ActiveReport3 rpt = new  GeneralList("Agent");
			
			//rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;

			rpt.DataSource = dt;
			rpt.DataMember = "Report";
			rpt.Run(false);

			Session.Add("Report",rpt);
			Session.Add("FromPage",LookupTables.LookupTables.GetTableMaintenancePathFromTableID(26)+ "?item=" + this.lblAgentID.Text);
			Response.Redirect("ActiveXViewer.aspx",false);
		}

        protected void btnAddBelongsTo_Click(object sender, EventArgs e)
        {
            //TaskControl.Agent taskControl = (TaskControl.Agent)Session["TaskControl"];


        }


        
        protected void GridAgency_ItemCommand(object source, DataGridCommandEventArgs e) // Alexis Nuevo para Kayla
		{
        {
            LookupTables.Agent agent = (LookupTables.Agent)Session["Agent"];
            switch (e.CommandName)
            {
                case "Select": 
                    break;
                case "Delete":
                    agent.DeleteAgencyBelongsTo(int.Parse(e.Item.Cells[0].Text));
                    //GridAgency.DataBind();
                    break;
            }

            LoadAgencyGrid();
             }
        }
        protected void GridAgency_DeleteCommand(object source, DataGridCommandEventArgs e)
        {

        }
}
}


	

