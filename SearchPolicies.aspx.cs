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
using System.IO;
using EPolicy.TaskControl;

namespace EPolicy
{
	/// <summary>
	/// Summary description for SearchPolicies.
	/// </summary>
    public partial class SearchPolicies : System.Web.UI.Page
    {
        private DataTable DtTaskPolicy;

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
            DataTable dtPolicyClass = LookupTables.LookupTables.GetTable("PolicyClass");

            //PolicyClass
            ddlPolicyClass.DataSource = dtPolicyClass;
            ddlPolicyClass.DataTextField = "PolicyClassDesc";
            ddlPolicyClass.DataValueField = "PolicyClassID";
            ddlPolicyClass.DataBind();
            ddlPolicyClass.SelectedIndex = -1;
            ddlPolicyClass.Items.Insert(0, "");
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DtSearchPayments.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DtSearchPayments_ItemCommand);
            this.DtSearchAll.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DtSearchAll_ItemCommand);

        }
        #endregion

        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.litPopUp.Visible = false;
            Page.Form.DefaultButton = Imagebutton1.UniqueID;

            Login.Login cp = HttpContext.Current.User as Login.Login;
            ddlPolicyClass.Items.Remove(ddlPolicyClass.Items.FindByText("CyberQuote"));
            ddlPolicyClass.Items.Remove(ddlPolicyClass.Items.FindByText("LaboratoryQuote"));
            ddlPolicyClass.Items.Remove(ddlPolicyClass.Items.FindByText("CorporatePolicyQuote"));
            if (cp == null)
            {
                Response.Redirect("Default.aspx?001");
            }
            else
            {
                if (!cp.IsInRole("SEARCHPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    Response.Redirect("Default.aspx?001");
                }
            }
            if (!IsPostBack)
            {
                this.lblVIN.Visible = false;
                this.txtVIN.Visible = false;
            }

        }

        private void ClearTextBox()
        {
            DtSearchPayments.Visible = false;
            DtSearchAll.Visible = false;
            DtSearchPayments.DataSource = null;
            DtSearchAll = null;

            LblTotalCases.Text = "Total Cases: 0";

            TxtPolicyNo.Text = "";
            TxtPolicyType.Text = "";
            TxtCertificate.Text = "";
            TxtSuffix.Text = "";
            TxtBank.Text = "";
            TxtLoanNo.Text = "";
            txtVIN.Text = "";
            txtVIN.Visible = false;
            lblVIN.Visible = false;

            ddlPolicyClass.SelectedIndex = 0;
        }

        private void GoToSpecificWebPage()
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

            DataTable dtSpec = (DataTable)Session["DtTaskPolicy"];

            int i = (int)dtSpec.Rows[0]["TaskControlID"];
            TaskControl.TaskControl taskControl = TaskControl.TaskControl.GetTaskControlByTaskControlID(i, userID);

            Session["Prospect"] = taskControl.Prospect;

            if (Session["DtTaskPolicy"] != null)
            {
                DataTable dtFilter = (DataTable)Session["DtTaskPolicy"];

                DataTable dt = dtFilter.Clone();

                DataRow[] dr = dtFilter.Select("TaskControlTypeID = " + taskControl.TaskControlTypeID, "TaskControlID");

                /*for (int rec = 0; rec <= dr.Length - 1; rec++)
                {
                    DataRow myRow = dt.NewRow();
                    myRow["TaskControlID"] = (int)dr[rec].ItemArray[0];
                    myRow["TaskStatusID"] = (int)dr[rec].ItemArray[1];
                    myRow["TaskControlTypeID"] = (int)dr[rec].ItemArray[2];
                    myRow["TaskControlID1"] = (int)dr[rec].ItemArray[0];
                    myRow["TotalPremium"] = (double)dr[rec].ItemArray[18];
                    myRow["CyberEndorsementPremium"] = (double)dr[rec].ItemArray[20];

                    dt.Rows.Add(myRow);
                    dt.AcceptChanges();
                }*/

                taskControl.NavegationTaskControlTable = dt;

                string ToPage; //alo

                if (Session["ToPage"] == null && (taskControl.GetType().Name.Trim() != "Laboratory" && taskControl.GetType().Name.Trim() != "Cyber" && taskControl.TaskControlTypeID != 24 && taskControl.TaskControlTypeID != 23 && taskControl.TaskControlTypeID != 28 && taskControl.TaskControlTypeID != 27))
                {
                    ToPage = taskControl.GetType().Name.Trim() + ".aspx";
                }
                else if (Session["ToPage"] == null && taskControl.GetType().Name.Trim() == "Cyber")
                {
                    ToPage = "CyberApplication.aspx";
                }
                else if (Session["ToPage"] == null && taskControl.GetType().Name.Trim() == "Laboratory")
                {
                    ToPage = taskControl.GetType().Name.Trim() + "Application1.aspx";
                }

                else if (Session["ToPage"] == null && taskControl.TaskControlTypeID == 24)
                {
                    ToPage = "AHCCorporateQuotes.aspx";                
                }
                else if (Session["ToPage"] == null && taskControl.TaskControlTypeID == 23)
                {
                    ToPage = "AHCPrimaryPolicies.aspx";                
                }
                else if (Session["ToPage"] == null && taskControl.TaskControlTypeID == 27)
                {
                    ToPage = "FirstDollarPolicies.aspx";
                }
                    else if (Session["ToPage"] == null && taskControl.TaskControlTypeID == 28)
                {
                    ToPage = "FirstDollarCorporate.aspx";
                }
                else
                {
                    ToPage = Session["ToPage"].ToString();
                }

                if (Session["TaskControl"] == null)
                    Session.Add("TaskControl", taskControl);
                else
                    Session["TaskControl"] = taskControl;

                Session.Remove("DtTaskPolicy");

                Response.Redirect(ToPage + "?" + taskControl.TaskControlID);  
            }
        }

        private void DtSearchPayments_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            //RPR 2004-05-17
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

                Session["Prospect"] = taskControl.Prospect;

                if (Session["DtTaskPolicy"] != null)
                {
                    DataTable dtFilter = (DataTable)Session["DtTaskPolicy"];

                    DataTable dt = dtFilter.Clone();

                    DataRow[] dr = dtFilter.Select("TaskControlTypeID = " + taskControl.TaskControlTypeID, "TaskControlID");

                    /*for (int rec = 0; rec <= dr.Length - 1; rec++)
                    {
                        DataRow myRow = dt.NewRow();
                        myRow["TaskControlID"] = (int)dr[rec].ItemArray[0];
                        myRow["TaskStatusID"] = (int)dr[rec].ItemArray[1];
                        myRow["TaskControlTypeID"] = (int)dr[rec].ItemArray[2];
                        myRow["TaskControlID1"] = (int)dr[rec].ItemArray[0];
                        myRow["TotalPremium"] = (double)dr[rec].ItemArray[18];
                        myRow["CyberEndorsementPremium"] = (double)dr[rec].ItemArray[20];

                        dt.Rows.Add(myRow);
                        dt.AcceptChanges();
                    }*/

                    taskControl.NavegationTaskControlTable = dt;

                    string ToPage;

                    if (Session["ToPage"] == null)
                    {
                        ToPage = taskControl.GetType().Name.Trim() + ".aspx";
                    }
                    else
                    {
                        ToPage = Session["ToPage"].ToString();
                    }

                    if (Session["TaskControl"] == null)
                        Session.Add("TaskControl", taskControl);
                    else
                        Session["TaskControl"] = taskControl;

                    Session.Remove("DtTaskPolicy");

                    Response.Redirect(ToPage + "?" + taskControl.TaskControlID);
                }
            }
            else  // Pager
            {
                DtSearchPayments.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                DtSearchPayments.DataSource = (DataTable)Session["DtTaskPolicy"];
                DtSearchPayments.DataBind();
            }
        }

        protected void ddlPolicyClass_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //			if(this.ddlPolicyClass.SelectedItem.Value == "10" )
            //			{
            //				this.lblVIN.Visible = true;
            //				this.txtVIN.Visible = true;
            //			}
            //			else
            //			{
            //				this.lblVIN.Visible = false;
            //				this.txtVIN.Visible = false;
            //			}
            //			txtVIN.Text = "";
        }

        private void DtSearchAll_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
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

                Session["Prospect"] = taskControl.Prospect;

                if (Session["DtTaskPolicy"] != null)
                {
                    DataTable dtFilter = (DataTable)Session["DtTaskPolicy"];

                    DataTable dt = dtFilter.Clone();

                    DataRow[] dr = dtFilter.Select("TaskControlTypeID = " + taskControl.TaskControlTypeID, "TaskControlID");

                    /*for (int rec = 0; rec <= dr.Length - 1; rec++)
                    {
                        DataRow myRow = dt.NewRow();
                        myRow["TaskControlID"] = (int)dr[rec].ItemArray[0];
                        myRow["TaskStatusID"] = (int)dr[rec].ItemArray[1];
                        myRow["TaskControlTypeID"] = (int)dr[rec].ItemArray[2];
                        myRow["TaskControlID1"] = (int)dr[rec].ItemArray[0];
                        myRow["TotalPremium"] = (double)dr[rec].ItemArray[18];
                        myRow["CyberEndorsementPremium"] = (double)dr[rec].ItemArray[20];

                        dt.Rows.Add(myRow);
                        dt.AcceptChanges();
                    }*/

                    taskControl.NavegationTaskControlTable = dt;

                    string ToPage;

                    if (Session["ToPage"] == null)
                    {
                        ToPage = taskControl.GetType().Name.Trim() + ".aspx";
                    }
                    else
                    {
                        ToPage = Session["ToPage"].ToString();
                    }

                    if (Session["TaskControl"] == null)
                        Session.Add("TaskControl", taskControl);
                    else
                        Session["TaskControl"] = taskControl;

                    Session.Remove("DtTaskPolicy");

                    Response.Redirect(ToPage + "?" + taskControl.TaskControlID);
                }
            }
            else  // Pager
            {
                DtSearchAll.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                DtSearchAll.DataSource = (DataTable)Session["DtTaskPolicy"];
                DtSearchAll.DataBind();
            }
        }

        protected void Imagebutton1_Click(object sender, System.EventArgs e)
        {
            try
            {
                FieldVerify();
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
                return;
            }
            try
            {

                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = 0;
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                if (ddlPolicyClass.SelectedItem.Value != "10")
                {
                    DtSearchPayments.Visible = true;
                    DtSearchAll.Visible = false;
                    LblError.Visible = false;
                    DtSearchPayments.DataSource = null;
                    DtTaskPolicy = null;

                    DtSearchPayments.CurrentPageIndex = 0;

                    DtSearchPayments.Visible = false;

                    int policyClass = 0;
                    if (ddlPolicyClass.SelectedItem.Value.ToString() != "")
                        policyClass = int.Parse(ddlPolicyClass.SelectedItem.Value.ToString());

                    DtTaskPolicy = TaskControl.Policy.GetPolicies(policyClass, TxtPolicyType.Text.Trim(),
                        TxtPolicyNo.Text.Trim(), TxtCertificate.Text.Trim(), TxtSuffix.Text.Trim(),
                        TxtLoanNo.Text.Trim(), TxtBank.Text.Trim(), userID);//,txtVIN.Text.Trim());

                    Session.Remove("DtTaskPolicy");
                    Session.Add("DtTaskPolicy", DtTaskPolicy);

                    if (DtTaskPolicy.Rows.Count != 0)
                    {
                        DtSearchPayments.Visible = true;
                        DtSearchPayments.DataSource = DtTaskPolicy;
                        DtSearchPayments.DataBind();

                    }
                    else
                    {
                        DtSearchPayments.DataSource = null;
                        DtSearchPayments.DataBind();

                        LblError.Visible = true;
                        LblError.Text = "Could not find a match for your search criteria, please try again.";
                    }

                    LblTotalCases.Text = "Total Cases: " + DtTaskPolicy.Rows.Count.ToString();
                    //Si tiene un solo record se va a dirigir a la pantalla correspondiente.
                    if (DtTaskPolicy.Rows.Count == 1)
                        GoToSpecificWebPage();
                }
                else
                {
                    DtSearchPayments.Visible = false;
                    DtSearchAll.Visible = true;
                    LblError.Visible = false;
                    DtSearchPayments.DataSource = null;
                    DtTaskPolicy = null;

                    DtSearchAll.CurrentPageIndex = 0;

                    DtSearchAll.Visible = false;

                    int policyClass = 0;
                    if (ddlPolicyClass.SelectedItem.Value.ToString() != "")
                        policyClass = int.Parse(ddlPolicyClass.SelectedItem.Value.ToString());

                    DtTaskPolicy = TaskControl.Policy.GetPolicies(policyClass, TxtPolicyType.Text.Trim(),
                        TxtPolicyNo.Text.Trim(), TxtCertificate.Text.Trim(), TxtSuffix.Text.Trim(),
                        TxtLoanNo.Text.Trim(), TxtBank.Text.Trim(), txtVIN.Text.Trim(), userID);

                    Session.Remove("DtTaskPolicy");
                    Session.Add("DtTaskPolicy", DtTaskPolicy);

                    if (DtTaskPolicy.Rows.Count != 0)
                    {
                        DtSearchAll.Visible = true;
                        DtSearchAll.DataSource = DtTaskPolicy;
                        DtSearchAll.DataBind();

                    }
                    else
                    {

                        DtSearchAll.DataSource = null;
                        DtSearchAll.DataBind();

                        LblError.Visible = true;
                        LblError.Text = "Could not find a match for your search criteria, please try again.";
                    }

                    LblTotalCases.Text = "Total Cases: " + DtTaskPolicy.Rows.Count.ToString();

                    //Si tiene un solo record se va a dirigir a la pantalla correspondiente.
                    if (DtTaskPolicy.Rows.Count == 1)
                        GoToSpecificWebPage();
                }
            }
            catch (Exception exp)
            {
                //LogError(exp);
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
                return;
            }
        }

        private void FieldVerify()
        {
            string errorMessage = String.Empty;
            //bool found = false;

            if (ddlPolicyClass.SelectedItem.Text.Trim() == "" &&
                TxtPolicyNo.Text.Trim() == "" && TxtPolicyType.Text.Trim() == "" &&
                TxtCertificate.Text.Trim() == "" & TxtSuffix.Text.Trim() == "" &&
                TxtBank.Text.Trim() == "" && TxtLoanNo.Text.Trim() == "")
            {
                errorMessage = "Please choose fill one field.";
                //found = true;
            }

            //throw the exception.
            if (errorMessage != String.Empty)
            {
                throw new Exception(errorMessage);
            }
        }

        protected void Imagebutton2_Click(object sender, System.EventArgs e)
        {
            ClearTextBox();
        }
        protected void DtSearchPayments_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataTable dtCol = (DataTable)Session["DtTaskPolicy"];
            DataColumnCollection dc = dtCol.Columns;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DateTime EffectiveDate;

                if ((string)DataBinder.Eval(e.Item.DataItem, "EffectiveDate") != "")
                {
                    EffectiveDate = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "EffectiveDate", "{0:MM/dd/yyyy}"));
                    e.Item.Cells[8].Text = EffectiveDate.ToShortDateString();
                }

                double TotalPremium;

                if ((double)DataBinder.Eval(e.Item.DataItem, "TotalPremium") != 0.0)
                {
                    TotalPremium = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "TotalPremium"));
                    e.Item.Cells[9].Text = TotalPremium.ToString("###,###.00");
                }
            }
        }
        protected void DtSearchPayments_ItemCommand1(object source, DataGridCommandEventArgs e)
        {
            //RPR 2004-05-17
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
                try
                {
                    int i = int.Parse(e.Item.Cells[1].Text);
                    TaskControl.TaskControl taskControl =
                        TaskControl.TaskControl.GetTaskControlByTaskControlID(i, userID);

                    Session["Prospect"] = taskControl.Prospect;

                    if (Session["DtTaskPolicy"] != null)
                    {
                        DataTable dtFilter = (DataTable)Session["DtTaskPolicy"];

                        DataTable dt = dtFilter.Clone();

                        DataRow[] dr = dtFilter.Select("TaskControlTypeID = " + taskControl.TaskControlTypeID, "TaskControlID");

                        /*for (int rec = 0; rec <= dr.Length - 1; rec++)
                        {
                            DataRow myRow = dt.NewRow();
                            myRow["TaskControlID"] = (int)dr[rec].ItemArray[0];
                            myRow["TaskStatusID"] = (int)dr[rec].ItemArray[1];
                            myRow["TaskControlTypeID"] = (int)dr[rec].ItemArray[2];
                            myRow["TaskControlID1"] = (int)dr[rec].ItemArray[0];
                            myRow["TotalPremium"] = (double)dr[rec].ItemArray[18];
                            myRow["CyberEndorsementPremium"] = (double)dr[rec].ItemArray[20];
                            dt.Rows.Add(myRow);
                            dt.AcceptChanges();
                        }*/

                        taskControl.NavegationTaskControlTable = dt;

                        string ToPage;

                        if (Session["ToPage"] == null)
                        {
                            if (taskControl.TaskControlTypeID == 19 || taskControl.TaskControlTypeID == 20)
                                ToPage = "LaboratoryApplication1.aspx";
                            else if (taskControl.TaskControlTypeID == 21 || taskControl.TaskControlTypeID == 22)
                                ToPage = "CyberApplication.aspx";
                            else if (taskControl.TaskControlTypeID == 23)
                            {
                                ToPage = "AHCPrimaryPolicies.aspx";
                            }
                            else if (taskControl.TaskControlTypeID == 24)
                            {
                                ToPage = "AHCCorporateQuotes.aspx";
                            }
                            else if (taskControl.TaskControlTypeID == 27)
                            {
                                ToPage = "FirstDollarPolicies.aspx";
                            }
                            else if (taskControl.TaskControlTypeID == 28)
                            {
                                ToPage = "FirstDollarCorporate.aspx";
                            }
                            else
                                ToPage = taskControl.GetType().Name.Trim() + ".aspx";
                        }
                        else
                        {
                            ToPage = Session["ToPage"].ToString();
                        }

                        if (Session["TaskControl"] == null)
                            Session.Add("TaskControl", taskControl);
                        else
                            Session["TaskControl"] = taskControl;

                        Session.Remove("DtTaskPolicy");

                        Response.Redirect(ToPage + "?" + taskControl.TaskControlID,false);
                    }
                }
                catch (Exception ex)
                {
                    //LogError(ex);
                    throw new Exception("Error while trying to select Policy.", ex);
                }
            }
            else  // Pager
            {
                DtSearchPayments.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                DtSearchPayments.DataSource = (DataTable)Session["DtTaskPolicy"];
                DtSearchPayments.DataBind();
            }
        }
        private void LogError(Exception exp)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", exp.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", exp.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", exp.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", exp.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = Server.MapPath("~/ErrorLog/ErrorLog.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
}
}
