namespace EPolicy
{
	using System;
	using System.Configuration;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using EPolicy;
    using System.Globalization;
    using System.Web.Security;
    using EPolicy.TaskControl;

	/// <summary>
	///		Summary description for TopBanner.
	/// </summary>
	public partial  class TopBanner2: System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.ImageButton imgReport;
		//int locationID = 0;

		protected void Page_Load(object sender, System.EventArgs e)
		{		
			//LblDate.Text = Utilities.LongDateSpanish(DateTime.Now);
			this.lblUserName.Text = "USER: ";

			Login.Login cp = HttpContext.Current.User as Login.Login;

            if (cp != null && cp.Identity.Name != string.Empty)
            {
                this.lblUserName.Visible = true;
                this.lblUserName.Text = cp.Identity.Name.Split("|".ToCharArray())[0];
                //NavigationMenu.Visible = true;
                //navBarMenu.Visible = true;
                imgGuessWho.Visible = true;
                VerifyAccess(cp);
               // this.Img1.Visible = false;
                //this.Img2.Visible = true;
                //this.Img3.Visible = true;
                //LblOficina.Text = LookupTables.LookupTables.GetDescription("Location",locationID.ToString());
            }
            else
            {
                HttpCookie authCookies = new HttpCookie(FormsAuthentication.FormsCookieName, null);
                FormsAuthentication.SignOut();
                Response.Cookies.Add(authCookies);

                this.lblUserName.Visible = true;
                this.lblUserName.Text = string.Empty;
                //NavigationMenu.Visible = false;
                //navBarMenu.Visible = false;
                imgGuessWho.Visible = false;
                //this.Img1.Visible = true;
                //this.Img2.Visible = false;
                //this.Img3.Visible = false;
                //LblOficina.Text = string.Empty;
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
		}
		
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{			

		}
		#endregion

        private void VerifyAccess(EPolicy.Login.Login cp)
        {
            if (!cp.IsInRole("ADMINISTRATOR"))
            {
                NavigationMenu.Items.Remove(NavigationMenu.FindItem("Administration"));
                //liAdministration.Visible = false;
            }
            else
            {
                if (!cp.IsInRole("ADMINISTRATOR"))
                {
                    MenuItem item = null;
                    if (!cp.IsInRole("BTNPAYMENTEXPRESSLEFTMENU") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        item = NavigationMenu.FindItem("Administration/Payment Express");
                        item.Parent.ChildItems.Remove(item);
                        //liPaymentExpress.Visible = false;
                    }

                    if (!cp.IsInRole("MARKETING") && cp.UserID != 331)
                    {
                        item = NavigationMenu.FindItem("Administration/Import Payment");
                        item.Parent.ChildItems.Remove(item);
                        //liImportPayment.Visible = false;
                    }

                    if (!cp.IsInRole("USER PROPERTIES LIST MAIN MENU") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        item = NavigationMenu.FindItem("Administration/User Properties List");
                        item.Parent.ChildItems.Remove(item);
                        //liUserPropertiesList.Visible = false;
                    }

                    if (!cp.IsInRole("BTNLOOKUPTABLELEFTMENU") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        item = NavigationMenu.FindItem("Administration/Lookup Tables");
                        item.Parent.ChildItems.Remove(item);
                        //liLookupTables.Visible = false;
                    }

                    if (!cp.IsInRole("BTNADDUSERLEFTMENU") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        item = NavigationMenu.FindItem("Administration/Add User");
                        item.Parent.ChildItems.Remove(item);
                        //liAddUser.Visible = false;
                    }

                    if (!cp.IsInRole("MARKETING") && !cp.IsInRole("ADMINISTRATOR") && cp.UserID != 331)
                    {
                        item = NavigationMenu.FindItem("Administration/User Properties List");
                       item.Parent.ChildItems.Remove(item);
                        //liUserPropertiesList.Visible = false;
                    }

                    if (!cp.IsInRole("BTNPROCESS") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        item = NavigationMenu.FindItem("Administration/Email Notification");
                       item.Parent.ChildItems.Remove(item);
                        //liEmailNotification.Visible = false;
                    }

                    item = NavigationMenu.FindItem("Administration/PdfGenerator");
                    item.Parent.ChildItems.Remove(item);
                    
                }
            }

            if (!cp.IsInRole("BTNREPORTLEFTMENU") && !cp.IsInRole("ADMINISTRATOR"))
            {
                NavigationMenu.Items.Remove(NavigationMenu.FindItem("Reports"));
                //liReports.Visible = false;
            }
            else
            {
                if (!cp.IsInRole("ADMINISTRATOR"))
                {
                    MenuItem item = null;

                    if (!cp.IsInRole("BTNCLIENTREPORTSLEFTREPORTMENU") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        item = NavigationMenu.FindItem("Reports/Client Reports"); //
                        item.Parent.ChildItems.Remove(item);
                        //liClientReports.Visible = false;
                    }

                    if (!cp.IsInRole("BTNPAYMENTREPORTSLEFTREPORTMENU") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        item = NavigationMenu.FindItem("Reports/Payment Reports"); //
                       item.Parent.ChildItems.Remove(item);
                        //liPaymentReports.Visible = false;
                    }

                    if (!cp.IsInRole("BTNRENEWALREPORTSLEFTREPORTMENU") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        item = NavigationMenu.FindItem("Reports/Renewal Payment"); //
                        item.Parent.ChildItems.Remove(item);
                        //liRenewalReports.Visible = false;
                    }

                    if (!cp.IsInRole("BTNCOMMISSIONREPORTSLEFTREPORTMENU") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        item = NavigationMenu.FindItem("Reports/Commission Reports"); //
                        item.Parent.ChildItems.Remove(item);
                        //liCommissionReports.Visible = false;
                    }
                }
            }


            if (!cp.IsInRole("BTNREPORTLEFTMENU") && !cp.IsInRole("ADMINISTRATOR"))
            {
                NavigationMenu.Items.Remove(NavigationMenu.FindItem("New Transaction"));
                //liNewTransaction.Visible = false;
            }
            else
            {
                if (!cp.IsInRole("ADMINISTRATOR"))
                {
                    MenuItem item = null;

                    if (!cp.IsInRole("BTNPROSPECTMAINMENU") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        item = NavigationMenu.FindItem("New Transaction/Prospect"); //
                        item.Parent.ChildItems.Remove(item);
                        //liProspect.Visible = false;
                    }

                    if (!cp.IsInRole("BTNCUSTOMERMAINMENU") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        item = NavigationMenu.FindItem("New Transaction/Customers"); //
                        item.Parent.ChildItems.Remove(item);
                        //liCustomers.Visible = false;
                    }

                    if (!cp.IsInRole("BTNRENEWALREPORTSLEFTREPORTMENU") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        item = NavigationMenu.FindItem("New Transaction/ASPEN Quotes"); //
                        item.Parent.ChildItems.Remove(item);
                        //liASPENQuotes.Visible = false;
                    }

                    if (!cp.IsInRole("BTNCOMMISSIONREPORTSLEFTREPORTMENU") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        item = NavigationMenu.FindItem("New Transaction/Laboratories Quotes"); //
                        item.Parent.ChildItems.Remove(item);
                        //liLaboratoriesQuotes.Visible = false;
                    }

                    if (!cp.IsInRole("BTNCOMMISSIONREPORTSLEFTREPORTMENU") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        item = NavigationMenu.FindItem("New Transaction/Corporate Policy Quotes"); //
                        item.Parent.ChildItems.Remove(item);
                        //liCorporatePolicyQuotes.Visible = false;
                    }

                    if (!cp.IsInRole("BTNRENEWALREPORTSLEFTREPORTMENU") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        item = NavigationMenu.FindItem("New Transaction/Cyber Policy Quotes"); //
                        item.Parent.ChildItems.Remove(item);
                        //liCyberPolicyQuotes.Visible = false;
                    }

                    if (!cp.IsInRole("BTNCOMMISSIONREPORTSLEFTREPORTMENU") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        item = NavigationMenu.FindItem("New Transaction/ASPEN Corporate Policy Quotes"); //
                        item.Parent.ChildItems.Remove(item);
                        ///liASPENCorporatePolicyQuotes.Visible = false;
                    }

                    if (!cp.IsInRole("BTNCOMMISSIONREPORTSLEFTREPORTMENU") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        item = NavigationMenu.FindItem("New Transaction/Application Requirements"); //
                        item.Parent.ChildItems.Remove(item);
                        //liApplicationRequirements.Visible = false;
                    }
                }
            }

            if (!cp.IsInRole("SEARCH MAIN MENU") && !cp.IsInRole("ADMINISTRATOR"))
            {
                NavigationMenu.Items.Remove(NavigationMenu.FindItem("Search"));
                //liSearch.Visible = false;
            }
            else
            {
                MenuItem item = null;

                if (!cp.IsInRole("SEARCH CONTROL MAIN MENU") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    item = NavigationMenu.FindItem("Search/Search by ControlID"); //Search by ControlID
                    item.Parent.ChildItems.Remove(item);
                    //liSearchByControlID.Visible = false;
                }

                if (!cp.IsInRole("SEARCH PROSPECT MAIN MENU") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    item = NavigationMenu.FindItem("Search/Search by Prospects"); //Search by Prospects
                    item.Parent.ChildItems.Remove(item);
                    //liSearchByProspects.Visible = false;
                }

                if (!cp.IsInRole("SEARCH CUSTOMER MAIN MENU") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    item = NavigationMenu.FindItem("Search/Search by Customers"); //Search by Customers
                    item.Parent.ChildItems.Remove(item);
                    //liSearchByCustomers.Visible = false;
                }

                if (!cp.IsInRole("SEARCH POLICIES MAIN MENU") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    item = NavigationMenu.FindItem("Search/Search by Policies"); //Search by Policies
                    item.Parent.ChildItems.Remove(item);
                    //liSearchByPolicies.Visible = false;
                }

                if (!cp.IsInRole("SEARCH QUOTES MAIN MENU") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    item = NavigationMenu.FindItem("Search/Search by Directory"); //Search by Directory
                    item.Parent.ChildItems.Remove(item);
                    //liSearchByDirectory.Visible = false;
                }

                if (!cp.IsInRole("SEARCH QUOTES MAIN MENU") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    item = NavigationMenu.FindItem("Search/Search by Groups"); //Search by Groups
                    item.Parent.ChildItems.Remove(item);
                    //liSearchByGroups.Visible = false;
                }
            }
        }

        protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            //Search
            if (e.Item.Text.Trim() == "Search by ControlID" || e.Item.Text.Trim() == "Main Menu")
            {
                Session.Clear();
                Response.Redirect("Search.aspx");
            }

            if (e.Item.Text.Trim() == "Search by Prospects")
            {
                Session.Clear();
                Response.Redirect("SearchProspect.aspx");
            }

            if (e.Item.Text.Trim() == "Search by Customers")
            {
                Session.Clear();
                Response.Redirect("SearchClient.aspx");
            }

            if (e.Item.Text.Trim() == "Search by Policies")
            {
                Session.Clear();
                Response.Redirect("SearchPolicies.aspx");
            }

            if (e.Item.Text.Trim() == "Search by Directory")
            {
                Session.Clear();
                Response.Redirect("Directorio.aspx");
            }

            if (e.Item.Text.Trim() == "Search by Groups")
            {
                Session.Clear();
                Response.Redirect("SearchGroup.aspx");
            }

            //Administration
            if (e.Item.Text.Trim() == "Payment Express")
            {
                Session.Clear();
                Response.Redirect("PaymentVSC.aspx");
            }

            if (e.Item.Text.Trim() == "Import Payment")
            {
                Response.Redirect("CertificateFileUpload.aspx");
            }

            if (e.Item.Text.Trim() == "Lookup Tables")
            {
                Session.Clear();
                Response.Redirect("LookupTableMaintenance.aspx");
            }

            if (e.Item.Text.Trim() == "User Properties List")
            {
                Session.Clear();
                Response.Redirect("UserPropertiesList.aspx");
            }

            if (e.Item.Text.Trim() == "Email Notification")
            {
                Session.Clear();
                Response.Redirect("PolicyReport.aspx");
            }

            //Reports
            if (e.Item.Text.Trim() == "Client Reports")
            {
                Session.Clear();
                Response.Redirect("ClientReport.aspx");
            }

            if (e.Item.Text.Trim() == "Policies Reports")
            {
                Session.Clear();
                Response.Redirect("PoliciesReports.aspx");
            }

            if (e.Item.Text.Trim() == "Renewal Reports")
            {
                Session.Clear();
                Response.Redirect("RenewalReport.aspx");
            }

            if (e.Item.Text.Trim() == "Payment Reports")
            {
                Session.Clear();
                Response.Redirect("PaymentsReport.aspx");
            }

            if (e.Item.Text.Trim() == "Commission Reports")
            {
                Session.Clear();
                Response.Redirect("CommissionReport.aspx");
            }
			
			//Transaction
			
			if (e.Item.Text.Trim() == "Prospect")
            {
				Session.Clear();
				Customer.Prospect prospect = new Customer.Prospect();
				prospect.Mode = 1;
				prospect.IsBusiness = false;
				Session["Prospect"] = prospect;
				Response.Redirect("ProspectIndividual.aspx");
			}
			
			if (e.Item.Text.Trim() == "Customers")
            {
				Session.Clear();

				Customer.Customer customer = new Customer.Customer();
				customer.Mode = (int) Customer.Customer.CustomerMode.ADD;
				Session.Add("Customer",customer);
				
				Response.Redirect("ClientIndividual.aspx");
			}
			
			if (e.Item.Text.Trim() == "Quotes")
            {
				Session.Clear();
                EPolicy.TaskControl.Application taskControl = new EPolicy.TaskControl.Application();

                taskControl.Mode = 1; //ADD
                taskControl.ApplicationMode = "ADD";
                taskControl.Residency = "001";

                Session.Add("TaskControl", taskControl);
                Response.Redirect("Application1.aspx", false);
			}
			
			if (e.Item.Text.Trim() == "First Dollar Quotes")
            {
				Session.Clear();
				EPolicy.TaskControl.Application taskControl = new EPolicy.TaskControl.Application();

				taskControl.Mode = 1; //ADD
				taskControl.ApplicationMode = "ADD";
				taskControl.Residency = "001";
				taskControl.TaskControlTypeID = 26;

				Session.Add("TaskControl", taskControl);
				Response.Redirect("FirstDollarQuotes.aspx", false);
			}
			
			if (e.Item.Text.Trim() == "First Dollar Corporate Quotes")
            {
				Session.Clear();
				EPolicy.TaskControl.CorporatePolicyQuote taskControl = new EPolicy.TaskControl.CorporatePolicyQuote(false);

				taskControl.Mode = 1; //ADD
				taskControl.InsuranceCompany = "001";
				taskControl.TaskControlTypeID = 28;

				Session.Add("TaskControl", taskControl);

				Response.Redirect("FirstDollarCorporate.aspx", false);
			}
		
			 if (e.Item.Text.Trim() == "ASPEN Quotes")
            {
                Session.Clear();
				EPolicy.TaskControl.Application taskControl = new EPolicy.TaskControl.Application();

				taskControl.Mode = 1; //ADD
				taskControl.ApplicationMode = "ADD";
				taskControl.Residency = "002";

				Session.Add("TaskControl", taskControl);
				Response.Redirect("Application1.aspx", false);
            }
			
			if (e.Item.Text.Trim() == "Laboratories Quotes")
            {
				Session.Clear();
				EPolicy.TaskControl.Laboratory taskControl = new EPolicy.TaskControl.Laboratory(false);

				taskControl.Mode = 1;
				taskControl.TaskControlTypeID = 19;

				Session.Add("TaskControl", taskControl);
				Response.Redirect("LaboratoryApplication1.aspx", false);
			}
			
			if (e.Item.Text.Trim() == "Corporate Policy Quotes")
            {
				Session.Clear();
				EPolicy.TaskControl.CorporatePolicyQuote taskControl = new EPolicy.TaskControl.CorporatePolicyQuote(false);
				taskControl.Mode = 1; //ADD
				taskControl.InsuranceCompany = "001";
				Session.Add("TaskControl", taskControl);
				Response.Redirect("CorporatePolicyQuote.aspx", false);
			}
			
			if (e.Item.Text.Trim() == "Cyber Policy Quotes")
            {
				Session.Clear();
				EPolicy.TaskControl.Cyber taskControl = new EPolicy.TaskControl.Cyber(false);

				taskControl.Mode = 1;
				taskControl.TaskControlTypeID = 21;
				Session.Add("TaskControl", taskControl);
				Response.Redirect("CyberApplication.aspx", false);
			}
			
			if (e.Item.Text.Trim() == "AHP Individual Quotes")
            {
				Session.Clear();
				EPolicy.TaskControl.Application taskControl = new EPolicy.TaskControl.Application();

				taskControl.Mode = 1; //ADD
				taskControl.ApplicationMode = "ADD";
				taskControl.Residency = "001";
				taskControl.TaskControlTypeID = 96;
				Session.Add("TaskControl", taskControl);
				Response.Redirect("AHCPrimaryQuotes.aspx", false);
			}
			
			if (e.Item.Text.Trim() == "AHC Corporate Quotes")
            {
				Session.Clear();
				EPolicy.TaskControl.CorporatePolicyQuote taskControl = new EPolicy.TaskControl.CorporatePolicyQuote(false);

				taskControl.Mode = 1; //ADD
				taskControl.InsuranceCompany = "001";
				taskControl.TaskControlTypeID = 96;

				Session.Add("TaskControl", taskControl);
				Response.Redirect("AHCCorporateQuotes.aspx", false);
			}
			
			if (e.Item.Text.Trim() == "ASPEN Corporate Policy Quotes")
            {
				Session.Clear();
				EPolicy.TaskControl.CorporatePolicyQuote taskControl = new EPolicy.TaskControl.CorporatePolicyQuote(false);
				taskControl.Mode = 1; //ADD
				taskControl.InsuranceCompany = "002";
				Session.Add("TaskControl", taskControl);
				Response.Redirect("CorporatePolicyQuote.aspx", false);
			}
			
			if (e.Item.Text.Trim() == "Application Requirements")
            {
				DataDynamics.ActiveReports.ActiveReport3 rpt = new EPolicy2.Reports.PRMdic.Requisitos();               
				rpt.Document.Printer.PrinterName = "";
				rpt.Run(false);

				Session.Add("Report", rpt);
				Session.Add("FromPage", "MainMenu.aspx");
				Response.Redirect("ActiveXViewer.aspx");
			}
			
			//Logout
			 if (e.Item.Text.Trim() == "Logout")
            {
				HttpCookie authCookies = new HttpCookie(FormsAuthentication.FormsCookieName, null);
				FormsAuthentication.SignOut();
				Response.Cookies.Add(authCookies);

				Session.Clear();
				Response.Redirect("Default.aspx?004");
			}
			
			if (e.Item.Text.Trim() == "Add User")
            {
                Session.Clear();
                EPolicy.Login.Login login = new EPolicy.Login.Login();
                login.Mode = (int)EPolicy.Login.Login.LoginMode.ADD;
                Session.Add("Login", login);
                Response.Redirect("UsersProperties.aspx");
			}
        }

        protected void btnLogout_Click(object sender, System.EventArgs e)
        {
            //Logout
            //if (e.Item.Text.Trim() == "Logout")
            //{
            
            HttpCookie authCookies = new HttpCookie(FormsAuthentication.FormsCookieName, null);
            FormsAuthentication.SignOut();
            Response.Cookies.Add(authCookies);

            Session.Clear();
            Response.Redirect("Default.aspx?004");
            
        }

        protected void btnProspect_Click(object sender, System.EventArgs e)
        {
                    //New Transaction
            //if (e.Item.Text.Trim() == "Prospect")
            //{
            Session.Clear();
            Customer.Prospect prospect = new Customer.Prospect();
            prospect.Mode = 1;
            prospect.IsBusiness = false;
            Session["Prospect"] = prospect;
            Response.Redirect("ProspectIndividual.aspx");
            
        }

        protected void btnCustomers_Click(object sender, System.EventArgs e)
        {
            //if (e.Item.Text.Trim() == "Customers")
            //{
            Session.Clear();
            Customer.Customer customer = new Customer.Customer();
            customer.Mode = (int)Customer.Customer.CustomerMode.ADD;
            Session.Add("Customer", customer);
            Response.Redirect("ClientIndividual.aspx");
        }
        protected void btnASPENQuotes_Click(object sender, System.EventArgs e)
        {
            //if (e.Item.Text.Trim() == "ASPEN Quotes")
            //{
            Session.Clear();
            EPolicy.TaskControl.Application taskControl = new EPolicy.TaskControl.Application();

            taskControl.Mode = 1; //ADD
            taskControl.ApplicationMode = "ADD";
            taskControl.Residency = "002";

            Session.Add("TaskControl", taskControl);
            Response.Redirect("Application1.aspx", false);
        }
        protected void btnLaboratoriesQuotes_Click(object sender, System.EventArgs e)
        {
            //if (e.Item.Text.Trim() == "Laboratories Quotes")
            //{
            Session.Clear();
            EPolicy.TaskControl.Laboratory taskControl = new EPolicy.TaskControl.Laboratory(false);

            taskControl.Mode = 1;
            taskControl.TaskControlTypeID = 19;

            Session.Add("TaskControl", taskControl);
            Response.Redirect("LaboratoryApplication1.aspx", false);
        }
        protected void btnCorporatePolicyQuotes_Click(object sender, System.EventArgs e)
        {
            //if (e.Item.Text.Trim() == "Corporate Policy Quotes")
            //{
            Session.Clear();
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = new EPolicy.TaskControl.CorporatePolicyQuote(false);
            taskControl.Mode = 1; //ADD
            taskControl.InsuranceCompany = "001";
            Session.Add("TaskControl", taskControl);
            Response.Redirect("CorporatePolicyQuote.aspx", false);
        }
        protected void btnCyberPolicyQuotes_Click(object sender, System.EventArgs e)
        {
            //if (e.Item.Text.Trim() == "Cyber Policy Quotes")
            //{
            Session.Clear();
            EPolicy.TaskControl.Cyber taskControl = new EPolicy.TaskControl.Cyber(false);

            taskControl.Mode = 1;
            taskControl.TaskControlTypeID = 21;

            Session.Add("TaskControl", taskControl);
            Response.Redirect("CyberApplication.aspx", false);
        }
        protected void btnASPENCorporatePolicyQuotes_Click(object sender, System.EventArgs e)
        {
            //if (e.Item.Text.Trim() == "ASPEN Corporate Policy Quotes")
            //{
            Session.Clear();
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = new EPolicy.TaskControl.CorporatePolicyQuote(false);
            taskControl.Mode = 1; //ADD
            taskControl.InsuranceCompany = "002";
            Session.Add("TaskControl", taskControl);
            Response.Redirect("CorporatePolicyQuote.aspx", false);
        }
        protected void btnAddUser_Click(object sender, System.EventArgs e)
        {
            //if (e.Item.Text.Trim() == "Add User")
            //{
                Session.Clear();
                EPolicy.Login.Login login = new EPolicy.Login.Login();
                login.Mode = (int)EPolicy.Login.Login.LoginMode.ADD;
                Session.Add("Login", login);
                Response.Redirect("UsersProperties.aspx");
        }
        protected void btnApplicationRequirements_Click(object sender, System.EventArgs e)
        {
            //if (e.Item.Text.Trim() == "Application Requirements")
            //{
            DataDynamics.ActiveReports.ActiveReport3 rpt = new EPolicy2.Reports.PRMdic.Requisitos();               
            rpt.Document.Printer.PrinterName = "";
            rpt.Run(false);

            Session.Add("Report", rpt);
            Session.Add("FromPage", "MainMenu.aspx");
            Response.Redirect("ActiveXViewer.aspx");
        }

	}
}