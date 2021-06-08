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

    public partial class SearchGroup : System.Web.UI.Page
    {
        private DataTable DtTaskControl;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
            this.litPopUp.Visible = false;
            Page.Form.DefaultButton = btnSearch.UniqueID;

            Control Banner = new Control();
            Banner = LoadControl(@"TopBanner1.ascx");
            this.Placeholder1.Controls.Add(Banner);

            /*//Setup Left-side Banner
            Control LeftMenu = new Control();
            LeftMenu = LoadControl(@"LeftMenu.ascx");
            this.phTopBanner1.Controls.Add(LeftMenu);*/

           
            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
            if (cp == null)
            {
                Response.Redirect("Default.aspx?001");
            }
            else
            {
                if (!cp.IsInRole("TASKCONTROL") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    Response.Redirect("Default.aspx?001");
                }
            }

            if (!Page.IsPostBack)
            {
                //Load DownDropList	
                EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                DataTable dtGroup = master.GetMasterPolicyByIsGroup(true);
                DataTable dtCorporation = master.GetMasterPolicyByIsGroup(false);

                //Corporation
                ddlCorporation.DataSource = dtCorporation;
                ddlCorporation.DataTextField = "MasterPolicyDesc";
                ddlCorporation.DataValueField = "MasterPolicyID";
                ddlCorporation.DataBind();
                ddlCorporation.SelectedIndex = -1;
                ddlCorporation.Items.Insert(0, "");

                //Group
                ddlGroup.DataSource = dtGroup;
                ddlGroup.DataTextField = "MasterPolicyDesc";
                ddlGroup.DataValueField = "MasterPolicyID";
                ddlGroup.DataBind();
                ddlGroup.SelectedIndex = -1;
                ddlGroup.Items.Insert(0, "");

                MultipleSelection1.CreateCheckBox(dtGroup, "MasterPolicyDesc", "MasterPolicyDesc");
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
            DataTable dtGroup = master.GetMasterPolicyByIsGroup(true);
            MultipleSelection1.CreateCheckBox(dtGroup, "MasterPolicyDesc", "MasterPolicyDesc");

            rblFilter.SelectedIndex = 0;
            ddlCorporation.Visible = false;
            //ddlGroup.Visible = true;
            LblLineOfBusiness.Text = "Group:";

            ClearTextBox();
        }

        private void ClearTextBox()
        {
            searchIndividual.Visible = false;
            searchIndividual.DataSource = null;

            txtBegDate.Text = "";
            TxtEndDate.Text = "";

            LblTotalCases.Text = "Total Cases: 0";

            //TxtTaskControlID.Text = "";
            ddlGroup.SelectedIndex = -1;
            ddlCorporation.SelectedIndex = -1;

            btnPrint.Visible = false;
            LblError.Visible = false;
        }

        protected void searchIndividual_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
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
                EPolicy.TaskControl.TaskControl taskControl = EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(i, userID);

                //RPR 2004-03-25
                Session["Prospect"] = taskControl.Prospect;

                //RPR 2004-03-26
                if (Session["DtTaskControl"] != null)
                {
                    DataTable dtFilter = (DataTable)Session["DtTaskControl"];

                    DataTable dt = dtFilter.Clone();

                    DataRow[] dr =
                        dtFilter.Select("TaskControlTypeID = " + taskControl.TaskControlTypeID, "TaskControlID");

                    for (int rec = 0; rec <= dr.Length - 1; rec++)
                    {
                        DataRow myRow = dt.NewRow();
                        myRow["TaskControlID"] = (int)dr[rec].ItemArray[0];
                        myRow["TaskControlTypeID"] = (int)dr[rec].ItemArray[3];
                        myRow["AgentDesc"] = (string)dr[rec].ItemArray[16];
                        myRow["AgencyDesc"] = (string)dr[rec].ItemArray[17];
                        myRow["GroupID"] = (string)dr[rec].ItemArray[8];
                        myRow["GroupDesc"] = (string)dr[rec].ItemArray[25];

                        dt.Rows.Add(myRow);
                        dt.AcceptChanges();
                    }

                    taskControl.NavegationTaskControlTable = dt;

                    string ToPage;

                    if (Session["ToPage"] == null)
                    {
                        if (taskControl.TaskControlTypeID == 16)
                        {
                            ToPage = "Application1.aspx";
                        }
                        else
                            if (taskControl.TaskControlTypeID == 4)
                            {
                                ToPage = "ExpressAutoQuote.aspx";
                            }
                            else
                            {
                                if (taskControl.TaskControlTypeID == 15) //OptimaPersonalPackageQuote
                                {
                                    ToPage = "OptimaPersonalPackage.aspx";
                                }
                                else
                                {
                                    ToPage = taskControl.GetType().Name.Trim() + ".aspx";
                                }
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
            }
            else  // Pager
            {
                searchIndividual.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                searchIndividual.DataSource = (DataTable)Session["DtTaskControl"];
                searchIndividual.DataBind();
            }
        }
        protected void searchIndividual_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataTable dtCol = (DataTable)Session["DtTaskControl"];
            DataColumnCollection dc = dtCol.Columns;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DateTime EntryDateField;
                DateTime CloseDateField;

                if ((string)DataBinder.Eval(e.Item.DataItem, "EntryDate") != "")
                {
                    EntryDateField = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "EntryDate", "{0:MM/dd/yyyy}"));
                    e.Item.Cells[8].Text = EntryDateField.ToShortDateString();
                }

                if ((string)DataBinder.Eval(e.Item.DataItem, "CloseDate") != "")
                {
                    CloseDateField = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "CloseDate", "{0:MM/dd/yyyy}"));
                    e.Item.Cells[9].Text = CloseDateField.ToShortDateString();
                }
            }
        }
        protected void ddlTaskControlType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FieldVerify()
        {
            string errorMessage = String.Empty;
            bool found = false;

            if (TxtEndDate.Text == "")
            {
                errorMessage = "Please enter an end date.";
                found = true;
            }

            if(this.txtBegDate.Text == "")
            {
                errorMessage = "Please enter a start date.";
                found = true;
            }

            //if (this.ddlGroup.SelectedItem.Value.Trim() == "" && this.ddlCorporation.SelectedItem.Value.Trim() == "")
            if(MultipleSelection1.sText.Trim() == "")
            {
                errorMessage = "Please choose a Group or Corporation.";
            }

            //throw the exception.
            if (errorMessage != String.Empty)
            {
                throw new Exception(errorMessage);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                FieldVerify();
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
                return;
            }

            LblError.Visible = false;
            searchIndividual.DataSource = null;
            DtTaskControl = null;

            searchIndividual.CurrentPageIndex = 0;
            searchIndividual.Visible = false;

            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
            int userID = 0;
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

            string group = "";
            //if(ddlGroup.SelectedItem.Value.Trim()!="")
            //    group= ddlGroup.SelectedItem.Value.Trim();
            if (MultipleSelection1.sText.Trim() != "" && rblFilter.SelectedValue == "0")
            {
                string[] agencydesc = MultipleSelection1.sText.Split(',');
                
                for (int i = 0;  i <= agencydesc.Length - 1 ; i++)
                {
                    
                    ddlGroup.SelectedIndex = ddlGroup.Items.IndexOf(ddlGroup.Items.FindByText(agencydesc[i].Trim()));
                    if (i == 0)
                        group = "'" + ddlGroup.SelectedValue.Trim() + "'";//ObtainGroupID(agencydesc[i]) + "'";
                    else
                        group = group + " or T.Bank LIKE '" + ddlGroup.SelectedValue.Trim() + "' ";//ObtainGroupID(agencydesc[i]) + "'";
                }

                group = " (T.Bank LIKE " + @group + ")";
            }
            
            string corporation = "";
            //if (ddlCorporation.SelectedItem.Value.Trim() != "")
            //    corporation = ddlCorporation.SelectedItem.Value.Trim();
            if (MultipleSelection1.sText.Trim() != "" && rblFilter.SelectedValue == "1")
            {
                string[] agencydesc = MultipleSelection1.sText.Split(',');

                for (int i = 0; i <= agencydesc.Length - 1 ; i++)
                {
                    ddlCorporation.SelectedIndex = ddlCorporation.Items.IndexOf(ddlCorporation.Items.FindByText(agencydesc[i].Trim()));
                    if (i == 0)
                        corporation = "'" + ddlCorporation.SelectedValue.Trim() + "'";
                    else
                        corporation = corporation + " or T.CompanyDealer LIKE '" + ddlCorporation.SelectedValue.Trim() + "' ";
                }
                group = " (T.CompanyDealer Like " + corporation + ")";
            }

            DtTaskControl = EPolicy.TaskControl.TaskControl.GetTaskControlByGroup(group,corporation, userID, txtBegDate.Text, TxtEndDate.Text);

            Session.Remove("DtTaskControl");                                 
            Session.Add("DtTaskControl", DtTaskControl);

            if (DtTaskControl.Rows.Count != 0)
            {
                searchIndividual.Visible = true;

                searchIndividual.DataSource = DtTaskControl;
                searchIndividual.DataBind();

                btnPrint.Visible = true;
            }
            else
            {
                searchIndividual.DataSource = null;
                searchIndividual.DataBind();

                LblError.Visible = true;
                LblError.Text = "Could not find a match for your search criteria, please try again.";
            }

            LblTotalCases.Text = "Total Cases: " + DtTaskControl.Rows.Count.ToString();

            //Si tiene un solo record se va a dirigir a la pantalla correspondiente.
            //if (DtTaskControl.Rows.Count == 1)
            //    GoToSpecificWebPage();
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
                int userID = 0;
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                EPolicy2.Reports.AutoGuardServicesContractReport appAutoreport = new EPolicy2.Reports.AutoGuardServicesContractReport();
                DataTable dt = null;
                DataDynamics.ActiveReports.ActiveReport3 rpt = null;

                string mHead = "";
                string CompanyHead = "";

                if(ddlCorporation.SelectedIndex != 0)
                    mHead = "Corporations Report";
                else 
                    mHead = "Groups Report";

                string PolicyType = "";

                string group = "";
                //if(ddlGroup.SelectedItem.Value.Trim()!="")
                //    group= ddlGroup.SelectedItem.Value.Trim();
                if (MultipleSelection1.sText.Trim() != "" && rblFilter.SelectedValue == "0")
                {
                    string[] agencydesc = MultipleSelection1.sText.Split(',');

                    for (int i = 0; i <= agencydesc.Length - 1; i++)
                    {

                        ddlGroup.SelectedIndex = ddlGroup.Items.IndexOf(ddlGroup.Items.FindByText(agencydesc[i].Trim()));
                        if (i == 0)
                            group = "'" + ddlGroup.SelectedValue.Trim() + "'";//ObtainGroupID(agencydesc[i]) + "'";
                        else
                            group = group + " or T.Bank LIKE '" + ddlGroup.SelectedValue.Trim() + "' ";//ObtainGroupID(agencydesc[i]) + "'";
                    }

                    group = " (T.Bank LIKE " + @group + ")";
                }

                string corporation = "";
                //if (ddlCorporation.SelectedItem.Value.Trim() != "")
                //    corporation = ddlCorporation.SelectedItem.Value.Trim();
                if (MultipleSelection1.sText.Trim() != "" && rblFilter.SelectedValue == "1")
                {
                    string[] agencydesc = MultipleSelection1.sText.Split(',');

                    for (int i = 0; i <= agencydesc.Length - 1; i++)
                    {
                        ddlCorporation.SelectedIndex = ddlCorporation.Items.IndexOf(ddlCorporation.Items.FindByText(agencydesc[i].Trim()));
                        if (i == 0)
                            corporation = "'" + ddlCorporation.SelectedValue.Trim() + "'";
                        else
                            corporation = corporation + " or T.CompanyDealer LIKE '" + ddlCorporation.SelectedValue.Trim() + "' ";
                    }
                    group = " (T.CompanyDealer Like " + corporation + ")";
                }
                
                dt = EPolicy.TaskControl.TaskControl.GetTaskControlByGroup(group,corporation, userID, txtBegDate.Text, TxtEndDate.Text);;

                //if (ddlPolicyClass.SelectedItem.Value.Trim() != "")
                //{
                //    if (dt.Rows.Count != 0)
                //    {
                //        CompanyHead = dt.Rows[0]["InsuranceCompanyDesc"].ToString().Trim();
                //    }
                //}
                //else
                //{
                CompanyHead = "PUERTO RICO MEDICAL DEFENSE INSURANCE COMPANY";
                //}

                rpt = new EPolicy2.Reports.PRMdic.GroupsReport(txtBegDate.Text.Trim(), TxtEndDate.Text.Trim(), mHead, false, CompanyHead);

                if (dt.Rows.Count == 0)
                {
                    throw new Exception("Unable to generate this report.");
                }

                rpt.DataSource = dt;
                rpt.DataMember = "Report";

                rpt.Document.Printer.PrinterName = "";

                rpt.Run(false);

                Session.Add("Report", rpt);
                Session.Add("FromPage", "SearchGroup.aspx");
                Response.Redirect("ActiveXViewer.aspx", false);
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
                return;
            }
        }
        protected void rblFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblFilter.SelectedValue == "1")
            {
                EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                DataTable dtCorporation = master.GetMasterPolicyByIsGroup(false);

                //Corporation
                ddlCorporation.DataSource = dtCorporation;
                ddlCorporation.DataTextField = "MasterPolicyDesc";
                ddlCorporation.DataValueField = "MasterPolicyID";
                ddlCorporation.DataBind();
                ddlCorporation.SelectedIndex = -1;
                ddlCorporation.Items.Insert(0, "");

                MultipleSelection1.CreateCheckBox(dtCorporation, "MasterPolicyDesc", "MasterPolicyDesc");

                LblLineOfBusiness.Text = "Corporation:";
                //ddlCorporation.Visible = true;
                //ddlGroup.Visible = false;
                ddlGroup.SelectedIndex = -1;

                ClearTextBox();
            }
            else
            {
                EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                DataTable dtGroup = master.GetMasterPolicyByIsGroup(true);

                //Group
                ddlGroup.DataSource = dtGroup;
                ddlGroup.DataTextField = "MasterPolicyDesc";
                ddlGroup.DataValueField = "MasterPolicyID";
                ddlGroup.DataBind();
                ddlGroup.SelectedIndex = -1;
                ddlGroup.Items.Insert(0, "");

                MultipleSelection1.CreateCheckBox(dtGroup, "MasterPolicyDesc", "MasterPolicyDesc");

                LblLineOfBusiness.Text = "Group:";
                //ddlCorporation.Visible = false;
                ddlCorporation.SelectedIndex = -1;
                //ddlGroup.Visible = true;

                ClearTextBox();
            }
        }

        protected string ObtainGroupID(string searchItem)
        {
            EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
            DataTable dtCorporation = master.GetMasterPolicyByIsGroup(false);
            DataTable dtGroup = master.GetMasterPolicyByIsGroup(true);
            DataRow[] dtSearch;

            if (rblFilter.SelectedValue == "0")
                dtSearch = dtGroup.Select("MasterPolicyDesc LIKE '%" + searchItem + "%'");
            else
                dtSearch = dtCorporation.Select("MasterPolicyDesc LIKE '%" + searchItem + "%'");

            return dtSearch[0][1].ToString();
        }
}