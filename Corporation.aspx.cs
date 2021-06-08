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
    public partial class Corporation : System.Web.UI.Page
    {
        private Control LeftMenu;

	    #region Enumerations

	    public enum UserAction{ADD = 1, VIEW = 2, SAVE = 3, EDIT = 4, CANCEL = 5};
    	
	    #endregion

       
	    private void SetCorporationEnumerationLabel()
	    {
		    LookupTables.MasterPolicy corporation =
                (LookupTables.MasterPolicy)Session["Corporation"];

            this.lblCorporationID.Text = (corporation.MasterPolicyID != "") ?
                corporation.MasterPolicyID.ToString() :
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
               if (!cp.IsInRole("LIMITEDLOOKUPTABLE"))
               {
                   if (!cp.IsInRole("AGENT") && !cp.IsInRole("ADMINISTRATOR"))
                   {
                       Response.Redirect("HomePage.aspx?001");
                   }
               }
	       }

	       if(!Page.IsPostBack)
	       {
               LookupTables.MasterPolicy corporation = new LookupTables.MasterPolicy();

		       if(Request.QueryString["item"] != null &&																	
			       Request.QueryString["item"].ToString() != String.Empty)
		       {	
			       try
			       {
                       corporation.GetMasterPolicy(Request.QueryString["item"].ToString());
				       corporation.ActionMode = 2; //UPDATE
				       corporation.NavigationViewModelTable = 
					       (DataTable)Session["DtRecordsForNonValuePairLookupTable"];
                       Session["Corporation"] = corporation;
			       }
			       catch(Exception ex)
			       {
				       this.ShowMessage("There is no Corporation for the supplied " +
					       "ID. " + ex.Message);
			       }
		       }
		       else
		       {
			       corporation.ActionMode = 1; //ADD
                   Session["Corporation"] = corporation;
		       }
    			
	       }

           if (Session["Corporation"] != null)
	       {
               LookupTables.MasterPolicy corporation =
                   (LookupTables.MasterPolicy)Session["Corporation"];

		       this.InitializeControls();

               switch (corporation.ActionMode)
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
    		
		   /*LeftMenu = new Control();
		    LeftMenu = LoadControl(@"LeftMenu.ascx");
		    phTopBanner1.Controls.Add(LeftMenu);*/
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
            //this.btnPrint1.Click += new System.Web.UI.ImageClickEventHandler(this.btnPrint_Click);
            //this.btnAuditTrail1.Click += new System.Web.UI.ImageClickEventHandler(this.btnAuditTrail_Click);
		    this.BtnExit1.Click += new System.Web.UI.ImageClickEventHandler(this.BtnExit_Click);

	    }
	    #endregion

	    private void InitializeControls()
	    {
            this.SetCorporationEnumerationLabel();
		    this.litPopUp.Visible = false;
	    }

	    private void SetControlState(int Action)
	    {
		    switch(Action)
		    {
			    case 1: //ADD ACTION
				    this.EnableInputControls(true);
				    this.btnEdit.Visible = false;
                    this.btnAuditTrail.Visible = false;
				    this.BtnSave.Visible = true;
				    this.cmdCancel.Visible = true;
				    this.btnAddNew.Visible = false;
				    this.btnSearch.Visible = false;
				    this.BtnExit.Visible = false;
				    break;
			    case 2: //VIEW ACTION
				    this.EnableInputControls(false);
                    this.btnAuditTrail.Visible = true;
				    this.btnEdit.Visible = true;
				    this.BtnSave.Visible = false;
				    this.cmdCancel.Visible = false;
				    this.btnAddNew.Visible = true;
				    this.btnSearch.Visible = true;
				    this.BtnExit.Visible = true;
				    break;
			    case 3: //SAVE ACTION
				    this.SetControlState((int)UserAction.VIEW);
				    break; 
			    case 4: //EDIT ACTION
				    this.EnableInputControls(true);
                    this.btnAuditTrail.Visible = false;
				    this.btnEdit.Visible = false;
				    this.BtnSave.Visible = true;
				    this.cmdCancel.Visible = true;
				    this.btnAddNew.Visible = false;
				    this.btnSearch.Visible = false;
				    this.BtnExit.Visible = false;
				    break;
			    default: //CANCEL ACTION
                    LookupTables.MasterPolicy corporation =
                        (LookupTables.MasterPolicy)Session["Corporation"];
                    if (corporation.ActionMode == 0) //ADD
				    {
                        Session["Corporation"] = null;
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
                this.txtCorporationDescription.Enabled = true;
			    this.txtPolicyType.Enabled = true;
			    this.txtPrimaryDiscount.Enabled = true;
                this.txtExcessDiscount.Enabled = true;
			    this.chkIsGroup.Enabled = true;

		    }
		    else
		    {
                this.txtCorporationDescription.Enabled = false;
                this.txtPolicyType.Enabled = false;
                this.txtPrimaryDiscount.Enabled = false;
                this.txtExcessDiscount.Enabled = false;
                this.chkIsGroup.Enabled = false;
		    }
	    }

	    private void FillControls()
	    {
            LookupTables.MasterPolicy corporation =
                        (LookupTables.MasterPolicy)Session["Corporation"];


            this.txtCorporationDescription.Text = (corporation.MasterPolicyDesc != "" ?
                corporation.MasterPolicyDesc.ToString() :
			    String.Empty);

            this.txtPolicyType.Text = (corporation.pol_type != "" || corporation.pol_type != "0" ?
                corporation.pol_type.ToString() :
                String.Empty);

		    this.chkIsGroup.Checked = 
			    corporation.IsGroup;

            this.txtPrimaryDiscount.Text =
                corporation.DescuentoPrimario.ToString().Trim();

            this.txtExcessDiscount.Text =
                corporation.DescuentoExcess.ToString().Trim();
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

		    LookupTables.MasterPolicy corporation =
                (LookupTables.MasterPolicy)Session["Corporation"];
		    try
		    {
                switch (corporation.ActionMode)
			    {
				    case 1: //ADD
                        this.FillProperties(ref corporation);
                        corporation.Save(userID);
					    break;
				    case 3: //DELETE
					    break;
				    case 4: //CLEAR
					    break;
				    default: //UPDATE
                        this.FillProperties(ref corporation);
                        corporation.Save(userID);
                        Session["Corporation"] = corporation;
					    this.SetControlState((int)UserAction.VIEW);
					    break;
			    }
			    this.litPopUp.Text = 
				    Utilities.MakeLiteralPopUpString(
				    "The Agent information saved successfully.");
			    this.litPopUp.Visible = true;
			    this.SetCorporationEnumerationLabel();
			    this.SetControlState((int)UserAction.SAVE);

                Session["Corporation"] = corporation;
		    }
		    catch(Exception xcp)
		    {
			    this.ShowMessage("Unable to save or modify Corporation. " + xcp.Message);
		    }
	    }//End BtnSave_Click



	    private void ShowMessage(string MessageText)
	    {
		    this.litPopUp.Text = 
			    Utilities.MakeLiteralPopUpString(MessageText);
		    this.litPopUp.Visible = true;
	    }

        private void FillProperties(ref LookupTables.MasterPolicy corporation)
	    {	
		    try
		    {
                corporation.MasterPolicyDesc = (this.txtCorporationDescription.Text.ToString().ToUpper());
		    }
		    catch
		    {
			    this.ShowMessage("Could not fill 'Corporation Description' property. " +
				    "Please enter a valid value for this field.");
		    }

            if (txtPolicyType.Text.ToString() != "CE" && txtPolicyType.Text.ToString() != "CE" &&
                txtPolicyType.Text.ToString() != "PP" && txtPolicyType.Text.ToString() != "PE")
                corporation.pol_type = "0";
            else
                corporation.pol_type = this.txtPolicyType.Text.ToString().ToUpper();

            corporation.IsGroup = this.chkIsGroup.Checked;
            if (txtPrimaryDiscount.Text.ToString() != String.Empty && txtExcessDiscount.Text.ToString() != String.Empty)
            {
            corporation.DescuentoPrimario = double.Parse(this.txtPrimaryDiscount.Text.ToString());
            corporation.DescuentoExcess = double.Parse(this.txtExcessDiscount.Text.ToString());
            }
            else
            {
            corporation.DescuentoPrimario = 0;
            corporation.DescuentoExcess = 0;
            }

            corporation.Members = 0;
            corporation.MemberRequired = 0;
            corporation.pol_agency = "0";
            corporation.pol_agent = "0";
            corporation.pol_bank = "0";
            corporation.pol_cert = false;
            corporation.pol_end = 0;
            corporation.pol_insco = "0";
            corporation.pol_number = "0";
            corporation.pol_seq = 0;
	    }

      
    		
	    protected void BtnExit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
	    {
            LookupTables.MasterPolicy corporation =
                (LookupTables.MasterPolicy)Session["Corporation"];

            if (corporation.ActionMode == 1) //ADD
			    Response.Redirect("LookupTableMaintenance.aspx");
		    else
		    {
			    Response.Redirect(
				    "SearchLookupTableDescriptions.aspx?SelectedItem=" + 
				    LookupTables.LookupTables.GetLookupTableIdFromTableName(
				    "MasterPolicy").ToString());
		    }
	    }


	    protected void cmdCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
	    {
		    this.SetControlState((int)UserAction.CANCEL);
	    }

	    protected void btnEdit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
	    {
            LookupTables.MasterPolicy corporation =
			    (LookupTables.MasterPolicy)Session["Corporation"];
            corporation.ActionMode = 2;
            Session["Corporation"] = corporation;
		    this.SetControlState((int)UserAction.EDIT);
	    }

	    private bool IsNavigationTableNull()
	    {
            LookupTables.MasterPolicy corporation =
                (LookupTables.MasterPolicy)Session["Corporation"];
            if (corporation.NavigationViewModelTable == null)
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
		    Response.Redirect("Corporation.aspx");
	    }

	    protected void btnSearch_Click(object sender, System.Web.UI.ImageClickEventArgs e)
	    {
		    Response.Redirect(
			    "SearchLookupTableDescriptions.aspx?SelectedItem=" + 
			    LookupTables.LookupTables.GetLookupTableIdFromTableName(
			    "MasterPolicy").ToString());
        }

        //protected void btnPrint_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    EPolicy2.Reports.AdministrativeTools atreport = new EPolicy2.Reports.AdministrativeTools();
        //    DataTable dt = atreport.AgentList();

        //    DataDynamics.ActiveReports.ActiveReport3 rpt = new  GeneralList("Agent");
    		
        //    //rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;

        //    rpt.DataSource = dt;
        //    rpt.DataMember = "Report";
        //    rpt.Run(false);

        //    Session.Add("Report",rpt);
        //    Session.Add("FromPage",LookupTables.LookupTables.GetTableMaintenancePathFromTableID(26)+ "?item=" + this.lblAgentID.Text);
        //    Response.Redirect("ActiveXViewer.aspx",false);
        //}

	    protected void btnAddNew_Click(object sender, System.EventArgs e)
	    {
		    Response.Redirect("Corporation.aspx");
	    }

	    protected void btnEdit_Click(object sender, System.EventArgs e)
	    {
            LookupTables.MasterPolicy corporation =
                (LookupTables.MasterPolicy)Session["Corporation"];
            corporation.ActionMode = 2;
            Session["Corporation"] = corporation;
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

            LookupTables.MasterPolicy corporation =
                (LookupTables.MasterPolicy)Session["Corporation"];
		    try
		    {
                switch (corporation.ActionMode)
			    {
				    case 1: //ADD
                        this.FillProperties(ref corporation);
                        corporation.Save(userID);
					    break;
				    case 3: //DELETE
					    break;
				    case 4: //CLEAR
					    break;
				    default: //UPDATE
                        this.FillProperties(ref corporation);
                        corporation.Save(userID);
                        Session["Corporation"] = corporation;
					    this.SetControlState((int)UserAction.VIEW);
					    break;
			    }
			    this.litPopUp.Text = 
				    Utilities.MakeLiteralPopUpString(
				    "The Corporation information was saved successfully.");
			    this.litPopUp.Visible = true;
			    this.SetCorporationEnumerationLabel();
			    this.SetControlState((int)UserAction.SAVE);

                Session["Corporation"] = corporation;
		    }
		    catch(Exception xcp)
		    {
			    this.ShowMessage("Unable to save or modify Corporation. " + xcp.Message);
		    }
	    }

	    protected void btnSearch_Click(object sender, System.EventArgs e)
	    {
		    Response.Redirect(
			    "SearchLookupTableDescriptions.aspx?SelectedItem=" + 
			    LookupTables.LookupTables.GetLookupTableIdFromTableName(
			    "MasterPolicy").ToString());
	    }

	    protected void cmdCancel_Click(object sender, System.EventArgs e)
	    {
            LookupTables.MasterPolicy corporation =
                (LookupTables.MasterPolicy)Session["Corporation"];

            if (corporation.ActionMode == 1) //ADD
			    Response.Redirect("LookupTableMaintenance.aspx");
		    else
		    {
			    this.SetControlState((int)UserAction.CANCEL);
		    }
	    }

	    protected void btnAuditTrail_Click(object sender, System.EventArgs e)
	    {
		    if(Session["Corporation"] != null)
		    {
                LookupTables.MasterPolicy corporation =
                (LookupTables.MasterPolicy)Session["Corporation"];
			    Response.Redirect("SearchAuditItems.aspx?type=11&MasterPolicyID=" +
                    corporation.MasterPolicyID.Trim());
		    }
	    }

	    protected void BtnExit_Click(object sender, System.EventArgs e)
	    {
            LookupTables.MasterPolicy corporation =
                (LookupTables.MasterPolicy)Session["Corporation"];

            if (corporation.ActionMode == 1) //ADD
			    Response.Redirect("LookupTableMaintenance.aspx");
		    else
		    {
			    Response.Redirect(
				    "SearchLookupTableDescriptions.aspx?SelectedItem=" + 
				    LookupTables.LookupTables.GetLookupTableIdFromTableName(
				    "MasterPolicy").ToString());
		    }
	    }

	    protected void btnAuditTrail_Click(object sender, System.Web.UI.ImageClickEventArgs e)
	    {
            if (Session["Corporation"] != null)
            {
                LookupTables.MasterPolicy corporation =
                (LookupTables.MasterPolicy)Session["Corporation"];
                Response.Redirect("SearchAuditItems.aspx?type=4&agentID=" +
                    corporation.MasterPolicyID.Trim());
            }
	    }

        //protected void btnCommission_Click(object sender, System.EventArgs e)
        //{
        //    LookupTables.Agent agent = (LookupTables.Agent) Session["Agent"];
        //    Response.Redirect("CommissionAgent.aspx?" +agent.AgentID);
        //}

        //protected void btnPrint_Click(object sender, System.EventArgs e)
        //{
        //    EPolicy2.Reports.AdministrativeTools atreport = new EPolicy2.Reports.AdministrativeTools();
        //    DataTable dt = atreport.AgentList();

        //    DataDynamics.ActiveReports.ActiveReport3 rpt = new  GeneralList("Agent");
    		
        //    //rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;

        //    rpt.DataSource = dt;
        //    rpt.DataMember = "Report";
        //    rpt.Run(false);

        //    Session.Add("Report",rpt);
        //    Session.Add("FromPage",LookupTables.LookupTables.GetTableMaintenancePathFromTableID(26)+ "?item=" + this.lblAgentID.Text);
        //    Response.Redirect("ActiveXViewer.aspx",false);
        //}	
}
}