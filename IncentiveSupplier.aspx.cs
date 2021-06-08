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
	/// Summary description for IncentiveSupplier.
	/// </summary>
	public partial class IncentiveSupplier : System.Web.UI.Page
	{
		private Control LeftMenu;

		#region Enumerations

		public enum UserAction{ADD = 1, VIEW = 2, SAVE = 3, EDIT = 4, CANCEL = 5};
		
		#endregion

		private void SetIncentiveSupplierNumerationLabel()
		{
			LookupTables.Supplier supplier = 
				(LookupTables.Supplier)Session["Supplier"];
            
            this.lblSupplierID.Text = (supplier.SupplierID != "") ?
               supplier.SupplierID.ToString():
               String.Empty;
		}
	
		private void InitializeControls()
		{
			this.SetIncentiveSupplierNumerationLabel();
			this.litPopUp.Visible = false;
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
				if(!cp.IsInRole("INCENTIVESUPPLIER") && !cp.IsInRole("ADMINISTRATOR"))
				{
					Response.Redirect("HomePage.aspx?001");
				}
			}

			if(!Page.IsPostBack)
			{
				EPolicy.LookupTables.IncentiveSupplier incentiveSupplier = new EPolicy.LookupTables.IncentiveSupplier();

				if(Request.QueryString["item"] != null &&																	
					Request.QueryString["item"].ToString() != String.Empty)
				{	
					try
					{
						incentiveSupplier.GetIncentiveSupplierByIncentiveSupplierID(int.Parse(Request.QueryString["item"].ToString()));
						incentiveSupplier.ActionMode = 4; //UPDATE
						incentiveSupplier.NavigationViewModelTable = 
							(DataTable)Session["DtRecordsForNonValuePairLookupTable"];
						Session["IncentiveSupplier"] = incentiveSupplier;
					}
					catch(Exception ex)
					{
						this.ShowMessage("There is no Incentive Supplier for the supplied " +
							"ID. " + ex.Message);
					}
				}
				else
				{
					incentiveSupplier.ActionMode = 1; //ADD
					Session["IncentiveSupplier"] = incentiveSupplier;
				}
				
			}

			if(Session["IncentiveSupplier"] != null)
			{
				LookupTables.IncentiveSupplier incentiveSupplier = 
					(LookupTables.IncentiveSupplier)Session["IncentiveSupplier"];

				this.InitializeControls();
			
				switch(incentiveSupplier.ActionMode)
				{
					case 1: //ADD
						this.SetControlState((int)UserAction.ADD);
						if(!Page.IsPostBack)
						{
							this.FillTextControl();
						}
						break;
					
					default: //UPDATE
						if(!Page.IsPostBack)
						{
							this.FillTextControl();
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
			//((Baldrich.BaldrichWeb.Components.TopBanner)Banner).SelectedOption = (int)Baldrich.HeadBanner.MenuOptions.Home;
			this.Placeholder1.Controls.Add(Banner);

			//Setup Left-side Banner
			
            //LeftMenu = new Control();
            //LeftMenu = LoadControl(@"LeftMenu.ascx");
            ////((Baldrich.BaldrichWeb.Components.MenuCustomers)LeftMenu).Height = "534px";
            //phTopBanner1.Controls.Add(LeftMenu);

			//Load DownDropList
			DataTable dtPolicyClass	        = LookupTables.LookupTables.GetTable("PolicyClass");
			DataTable dtInsuranceCompany	= LookupTables.LookupTables.GetTable("InsuranceCompany");

			//PolicyClass
			ddlPolicyID.DataSource = dtPolicyClass;
			ddlPolicyID.DataTextField = "PolicyClassDesc";
			ddlPolicyID.DataValueField = "PolicyClassID";
			ddlPolicyID.DataBind();
			ddlPolicyID.SelectedIndex = -1;
			ddlPolicyID.Items.Insert(0,"");

			//InsuranceCompany
			ddlInsuranceCompany.DataSource = dtInsuranceCompany;
			ddlInsuranceCompany.DataTextField = "InsuranceCompanyDesc";
			ddlInsuranceCompany.DataValueField = "InsuranceCompanyID";
			ddlInsuranceCompany.DataBind();
			ddlInsuranceCompany.SelectedIndex = -1;
			ddlInsuranceCompany.Items.Insert(0,"");
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.searchIncentive.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.searchIncentive_ItemCommand);
			this.searchIncentive.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.searchIncentive_ItemDataBound);

		}
		#endregion

		private void FillTextControl()
		{
			LookupTables.IncentiveSupplier incentiveSupplier = (LookupTables.IncentiveSupplier) Session["IncentiveSupplier"];
			LookupTables.Supplier supplier = (LookupTables.Supplier) Session["Supplier"];

            
			DataTable dt = LookupTables.IncentiveSupplier.GetIncentiveSupplierBySupplierID(supplier.SupplierID);

            Session.Add("dtIncentiveSupplier",dt);
            searchIncentive.DataSource = dt;
            searchIncentive.DataBind();

			Baldrich.DBRequest.DBRequest executor = new Baldrich.DBRequest.DBRequest();

			Session.Add("IncentiveSupplier", incentiveSupplier);

			//Policy
			ddlPolicyID.SelectedIndex = 0;
			if (incentiveSupplier.PolicyClassID != 0)
			{
				for(int i = 0;ddlPolicyID.Items.Count-1 >= i ;i++)
				{
					if (ddlPolicyID.Items[i].Value == incentiveSupplier.PolicyClassID.ToString())
					{
						ddlPolicyID.SelectedIndex = i;
						i = ddlPolicyID.Items.Count-1;
					}
				}
			}
		
			//Insurance Company
			ddlInsuranceCompany.SelectedIndex = 0;
			if(incentiveSupplier.InsuranceCompanyID != "000")
			{
				for(int i = 0;ddlInsuranceCompany.Items.Count-1 >= i ;i++)
				{
					if (ddlInsuranceCompany.Items[i].Value == incentiveSupplier.InsuranceCompanyID.ToString())
					{
						ddlInsuranceCompany.SelectedIndex = i;
						i = ddlInsuranceCompany.Items.Count-1;
					}
				}
			}

//			//Bank
//			ddlBankID.SelectedIndex = 0;
//			if(commissionAgent.BankID!= "000")
//			{
//				for(int i = 0;ddlBankID.Items.Count-1 >= i ;i++)
//				{
//					if (ddlBankID.Items[i].Value == commissionAgent.BankID.ToString())
//					{
//						ddlBankID.SelectedIndex = i;
//						i = ddlBankID.Items.Count-1;
//					}
//				}
//			}
//		
//			//CompanyDealer
//			ddlDealerID.SelectedIndex = 0;
//			if(commissionAgent.CompanyDealerID != "000")
//			{
//				for(int i = 0;ddlDealerID.Items.Count-1 >= i ;i++)
//				{
//					if (ddlDealerID.Items[i].Value == commissionAgent.CompanyDealerID.ToString())
//					{
//						ddlDealerID.SelectedIndex = i;
//						i = ddlDealerID.Items.Count-1;
//					}
//				}
//			}
			
			this.lblSupplierID.Text       = supplier.SupplierID;
			this.txtPolicyType.Text      = incentiveSupplier.PolicyType ;
			this.txtRate.Text            = incentiveSupplier.IncentiveRate;
			this.txtEffectiveDate.Text   = incentiveSupplier.EffectiveDate;
			this.txtEntryDate.Text       = incentiveSupplier.IncentiveEntryDate;
			this.txtSupplierLevel.Text   = incentiveSupplier.SupplierLevel.ToString().Trim();
			this.txtIncentiveAmount.Text = incentiveSupplier.IncentiveAmount.ToString().Trim();
            
			if (incentiveSupplier.RateAmt)
			{
				this.RdbIncentiveAmount.Checked   = false;
				this.RdbRate.Checked			   = true;
			} 
			else
			{
				this.RdbIncentiveAmount.Checked   = true;
				this.RdbRate.Checked               = false;	
			}

			this.RbdButtons();
		}

		private void RbdButtons()
		{
			if(this.RdbRate.Checked == true)
			{
				this.lblIncentiveRate.Visible   = true;
				this.txtRate.Visible            = true;
				this.txtIncentiveAmount.Visible = false;
				this.lblIncentiveAmount.Visible = false;
			}
			else
			{
				this.lblIncentiveRate.Visible    = false;
				this.txtRate.Visible             = false;
				this.txtIncentiveAmount.Visible = true;
				this.lblIncentiveAmount.Visible  = true;
			}
		}

		private void searchIncentive_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.Item.ItemType.ToString() != "Pager") // Select
			{
				int i = int.Parse(e.Item.Cells[1].Text);
				LookupTables.IncentiveSupplier incentiveSupplier = new LookupTables.IncentiveSupplier();
				incentiveSupplier.GetIncentiveSupplierByIncentiveSupplierID(i);

				incentiveSupplier.ActionMode = 4;
				Session.Add("IncentiveSupplier", incentiveSupplier);
				FillTextControl();
				this.EnableInputControls(false);	
				this.SetControlState((int)UserAction.VIEW);	
			}
			else  // Pager
			{
				searchIncentive.CurrentPageIndex = int.Parse(e.CommandArgument.ToString())-1;
		
				searchIncentive.DataSource = (DataTable) Session["dtIncentiveSupplier"];
				searchIncentive.DataBind();
			}		
		}

		private void FillProperties(ref EPolicy.LookupTables.IncentiveSupplier incentiveSupplier)
		{	
			try
			{
				incentiveSupplier.SupplierID =  (this.lblSupplierID.Text.ToString());
			}
			catch
			{
				this.ShowMessage("Could not fill 'Incentive' property. " +
					"Please enter a valid value for this field.");
			}
			
			incentiveSupplier.PolicyClassID       = this.ddlPolicyID.SelectedItem.Value != "" ?int.Parse(ddlPolicyID.SelectedItem.Value):0;
			incentiveSupplier.PolicyType          = this.txtPolicyType.Text.ToString().ToUpper();
			incentiveSupplier.InsuranceCompanyID  = this.ddlInsuranceCompany.SelectedItem.Value != "" ?(ddlInsuranceCompany.SelectedItem.Value):"000";
			//incentiveSupplier.BankID               = this.ddlBankID.SelectedItem.Value != "" ?(ddlBankID.SelectedItem.Value):"000";
			//incentiveSupplier.CompanyDealerID      = this.ddlDealerID.SelectedItem.Value != ""?(ddlDealerID.SelectedItem.Value):"000";
			incentiveSupplier.IncentiveRate       = (this.txtRate.Text.ToString().Trim());
			incentiveSupplier.EffectiveDate       = (this.txtEffectiveDate.Text);
			incentiveSupplier.IncentiveEntryDate  = (this.txtEntryDate.Text);
			incentiveSupplier.SupplierLevel       = (int.Parse(this.txtSupplierLevel.Text.ToString().Trim()));
			incentiveSupplier.IncentiveAmount     = (float.Parse(this.txtIncentiveAmount.Text.ToString().Trim()));
			incentiveSupplier.RateAmt             = this.RdbRate.Checked;
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
					this.btnAuditTrail.Visible = false;
					this.btnPrint.Visible = false;
					this.Button2.Visible = false;
					break;
				case 2: //VIEW ACTION
					this.EnableInputControls(false);
					this.btnEdit.Visible = true;
					this.BtnSave.Visible = false;
					this.cmdCancel.Visible = false;
					this.btnAddNew.Visible = true;
					this.btnAuditTrail.Visible = true;
					this.btnPrint.Visible = true;
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
					this.btnAuditTrail.Visible = false;
					this.btnPrint.Visible = false;
					this.Button2.Visible = false;
					break;
				default: //CANCEL ACTION
					LookupTables.IncentiveSupplier incentiveSupplier = 
						(LookupTables.IncentiveSupplier)Session["incentiveSupplier"];
					if(incentiveSupplier.ActionMode == 0) //ADD
					{
						Session["IncentiveSupplier"] = null;
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
				this.ddlPolicyID.Enabled         = true;
				this.txtPolicyType.Enabled       = true;
				this.ddlInsuranceCompany.Enabled = true;
				//this.ddlBankID.Enabled           = true;
				//this.ddlDealerID.Enabled         = true;
				this.txtRate.Enabled             = true;
				this.txtEffectiveDate.Enabled    = true;
				this.txtEntryDate.Enabled        = false;
				this.txtSupplierLevel.Enabled    = true;
				this.Button1.Visible             = true;
				this.txtIncentiveAmount.Enabled  = true;
				this.RdbRate.Enabled             = true;
				this.RdbIncentiveAmount.Enabled  = true;

			}
			else
			{
				this.ddlPolicyID.Enabled         = false;
				this.txtPolicyType.Enabled       = false;
				this.ddlInsuranceCompany.Enabled = false;
				//this.ddlBankID.Enabled           = false;
				//this.ddlDealerID.Enabled         = false;
				this.txtRate.Enabled             = false;
				this.txtEffectiveDate.Enabled    = false;
				this.txtEntryDate.Enabled        = false;
				this.txtSupplierLevel.Enabled    = false;
				this.Button1.Visible             = false;
				this.txtIncentiveAmount.Enabled  = false;
				this.RdbRate.Enabled             = false;
				this.RdbIncentiveAmount.Enabled  = false;

			}
		}

		private void BtnExit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			LookupTables.IncentiveSupplier incentiveSupplier = 
				(LookupTables.IncentiveSupplier)Session["IncentiveSupplier"];
			LookupTables.Supplier supplier = (LookupTables.Supplier) Session["Supplier"];
			
			Response.Redirect(
				LookupTables.LookupTables.GetTableMaintenancePathFromTableID(75) + "?item=" + this.lblSupplierID.Text);
		
		}

		private void ShowMessage(string MessageText)
		{
			this.litPopUp.Text = 
				Utilities.MakeLiteralPopUpString(MessageText);
			this.litPopUp.Visible = true;
		}

		private bool IsNavigationTableNull()
		{
			LookupTables.IncentiveSupplier incentiveSupplier = 
				(LookupTables.IncentiveSupplier)Session["incentiveSupplier"];
			if(incentiveSupplier.NavigationViewModelTable == null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected void RdbIncentiveAmount_CheckedChanged(object sender, System.EventArgs e)
		{
			txtRate.Visible            = false;
			lblIncentiveRate.Visible   = false;
			txtIncentiveAmount.Visible = true;
			lblIncentiveAmount.Visible = true;

		}

		protected void RdbRate_CheckedChanged(object sender, System.EventArgs e)
		{
			txtRate.Visible            = true; 
			lblIncentiveRate.Visible   = true;
			txtIncentiveAmount.Visible = false;
			lblIncentiveAmount.Visible = false;
		}
		

		private void searchIncentive_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			LookupTables.IncentiveSupplier incentiveSupplier = (LookupTables.IncentiveSupplier) Session["IncentiveSupplier"];
			DataTable dtIncentiveSupplier = LookupTables.LookupTables.GetTable("IncentiveSupplier");

			DataColumnCollection dc = dtIncentiveSupplier.Columns;

			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				DateTime EffectiveDateField;
				DateTime EntryDateField;

				if (DataBinder.Eval(e.Item.DataItem,"EffectiveDate") != "")
				{
					EffectiveDateField = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem,"EffectiveDate","{0:MM/dd/yyyy}"));
					e.Item.Cells[10].Text = EffectiveDateField.ToShortDateString();
				}

				if (DataBinder.Eval(e.Item.DataItem,"IncentiveEntryDate") != "")
				{
					EntryDateField = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem,"IncentiveEntryDate","{0:MM/dd/yyyy}"));
					e.Item.Cells[11].Text = EntryDateField.ToShortDateString();
				}
			}
		}

		protected void btnAddNew_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("IncentiveSupplier.aspx");
		}

		protected void btnEdit_Click(object sender, System.EventArgs e)
		{
			LookupTables.IncentiveSupplier incentiveSupplier = (LookupTables.IncentiveSupplier)Session["IncentiveSupplier"];			
			incentiveSupplier.ActionMode = 2;
			Session["IncentiveSupplier"] = incentiveSupplier;
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

			LookupTables.IncentiveSupplier incentiveSupplier = 
				(LookupTables.IncentiveSupplier)Session["IncentiveSupplier"];
			try
			{
				switch(incentiveSupplier.ActionMode)
				{
					case 1: //ADD
						this.FillProperties(ref incentiveSupplier);
						incentiveSupplier.Save(userID);
						break;
					case 3: //DELETE
						break;
					case 4: //CLEAR
						break;
					default: //UPDATE
						this.FillProperties(ref incentiveSupplier);
						incentiveSupplier.Save(userID);
						Session["IncentiveSupplier"] = incentiveSupplier;
						this.SetControlState((int)UserAction.VIEW);
						break;
				}
				this.litPopUp.Text = 
					Utilities.MakeLiteralPopUpString(
					"The Incentive Supplier information saved successfully.");
				this.litPopUp.Visible = true;
				this.SetIncentiveSupplierNumerationLabel();
				this.SetControlState((int)UserAction.SAVE);

                FillTextControl();

				Session["IncentiveSupplier"] = incentiveSupplier;
			}
			catch(Exception xcp)
			{
				this.ShowMessage("Unable to save or modify Incentive Supplier. " + xcp.Message);
			}
		}

		protected void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.SetControlState((int)UserAction.CANCEL);
		}

		protected void btnPrint_Click(object sender, System.EventArgs e)
		{
			LookupTables.Supplier supplier = (LookupTables.Supplier) Session["Supplier"];

            DataDynamics.ActiveReports.ActiveReport3 rpt = new CommissionList("Incentive Supplier", supplier.SupplierDesc, supplier.SupplierID);
	
			rpt.DataSource = ( DataTable) Session["dtIncentiveSupplier"];
			rpt.DataMember = "Report";
			rpt.Run(false);

			Session.Add("Report",rpt);
			Session.Add("FromPage","IncentiveSupplier.aspx?item= + this.lblSupplierID.Text");
			Response.Redirect("ActiveXViewer.aspx",false);
		}

		protected void btnAuditTrail_Click(object sender, System.EventArgs e)
		{
			if(Session["IncentiveSupplier"] != null)
			{
				LookupTables.IncentiveSupplier incentiveSupplier = (LookupTables.IncentiveSupplier) Session["IncentiveSupplier"];
				Response.Redirect("SearchAuditItems.aspx?type=19&incentiveSupplierID=" + 
					incentiveSupplier.IncentiveSupplierID.ToString());
			}		
		}

		protected void Button2_Click(object sender, System.EventArgs e)
		{
			LookupTables.IncentiveSupplier incentiveSupplier = 
				(LookupTables.IncentiveSupplier)Session["IncentiveSupplier"];
			LookupTables.Supplier supplier = (LookupTables.Supplier) Session["Supplier"];
			
			Response.Redirect(
				LookupTables.LookupTables.GetTableMaintenancePathFromTableID(75) + "?item=" + this.lblSupplierID.Text);
		}		
	}
}
