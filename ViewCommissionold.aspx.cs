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
using EPolicy;
using EPolicy.TaskControl;
using System.Xml;
using EPolicy.XmlCooker;
using Baldrich.DBRequest;

namespace EPolicy
{
	/// <summary>
	/// Summary description for ViewCommission.
	/// </summary>
    public partial class ViewCommission : System.Web.UI.Page
    {
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
            Banner = LoadControl(@"TopBanner.ascx");
            this.Placeholder1.Controls.Add(Banner);

            //Setup Left-side Banner
            Control LeftMenu = new Control();
            LeftMenu = LoadControl(@"LeftMenu.ascx");
            this.phTopBanner1.Controls.Add(LeftMenu);

        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.searchIndividualOld.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.searchIndividual_ItemDataBound);

        }
        #endregion

        protected void Page_Load(object sender, System.EventArgs e)
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
            this.litPopUp.Visible = false;

            if (cp == null)
            {
                Response.Redirect("Default.aspx?001");
            }
            else
            {
                if (!cp.IsInRole("VIEWINCENTIVE") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    Response.Redirect("Default.aspx?001");
                }
            }

            if (!IsPostBack)
            {
                this.SetReferringPage();

                TaskControl.Policy taskControl;
                if (Session["TaskControlCommission"] != null)
                {
                    taskControl = (TaskControl.Policy)Session["TaskControlCommission"];
                }
                else
                {
                    taskControl = (TaskControl.Policy)Session["TaskControl"];
                    Session.Add("TaskControlCommission", taskControl);
                }

                LookupTables.Agent agent = new LookupTables.Agent();
                LookupTables.Agent agent2 = new LookupTables.Agent();

                ddlAgent.Items.Clear();

                /*RG01
                 * agent = agent.GetAgent(taskControl.Agent);
                ddlAgent.Items.Insert(0, agent.AgentDesc);

                if (taskControl.Agent2 == String.Empty || taskControl.Agent2 == "000")
                {
                    lblAgent.Visible = false;
                    ddlAgent.Visible = false;
                }
                else
                {
                    lblAgent.Visible = true;
                    ddlAgent.Visible = true;

                    ddlAgent.Items.Clear();

                    agent = agent.GetAgent(taskControl.Agent);
                    ddlAgent.Items.Insert(0, agent.AgentDesc);

                    agent2 = agent2.GetAgent(taskControl.Agent2);
                    ddlAgent.Items.Insert(1, agent2.AgentDesc);
                }

                LblCustomerName.Text = "Policy No.: " + taskControl.PolicyType.Trim() + " " + taskControl.PolicyNo.Trim() + " " + taskControl.Certificate.Trim() + " " + taskControl.Suffix.Trim();

                DataTable dtCreditDebit = LookupTables.LookupTables.GetTable("CreditDebit");

                //CreditDebit
                ddlCreditDebit.DataSource = dtCreditDebit;
                ddlCreditDebit.DataTextField = "CreditDebitDesc";
                ddlCreditDebit.DataValueField = "CreditDebitID";
                ddlCreditDebit.DataBind();
                ddlCreditDebit.SelectedIndex = -1;
                //ddlCreditDebit.Items.Insert(0,"");

                FillDataGrid();
                FillTextControl();*/
            }
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

        private void SetReferringPage()
        {
            if ((Session["FromPage"] != null) && (Session["FromPage"].ToString() != ""))
            {
                this.ReferringPage = Session["FromPage"].ToString();
                Session.Remove("FromPage");
            }
        }

        private void ReturnToReferringPage()
        {
            if (this.ReferringPage != "")
            {
                Response.Redirect(this.ReferringPage);
            }
            Response.Redirect("HomePage.aspx");
        }

        private void FillTextControl()
        {
            TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControlCommission"];

            LookupTables.Agent agent = new LookupTables.Agent();
            LookupTables.Agent agent2 = new LookupTables.Agent();

            agent = agent.GetAgent(taskControl.Agent);

            if (taskControl.Agent2 != String.Empty && taskControl.Agent2 != "000")
            {
                agent2 = agent.GetAgent(taskControl.Agent2);
            }

            if(ddlAgent.SelectedValue == agent.AgentDesc || ddlAgent.SelectedValue == "")
            {
                string tempPolType;

                if (taskControl.PolicyType.Trim() == "AAE")
                    tempPolType = "PE";
                else if (taskControl.PolicyType.Trim() == "AAP")
                    tempPolType = "PP";
                else if (taskControl.PolicyType.Trim() == "AEC")
                    tempPolType = "CE";
                else if (taskControl.PolicyType.Trim() == "APC")
                    tempPolType = "CP";
                else if (taskControl.PolicyType.Trim() == "PAH")
                    tempPolType = "PP";
                else if (taskControl.PolicyType.Trim() == "CPA")
                    tempPolType = "CP"; 
                
                else
                    tempPolType = taskControl.PolicyType.Trim();   
                
                    DataTable agentComm = TaskControl.Policy.ObtainAgentPercent(taskControl.Agent, tempPolType.Trim());
                //tempPolType.Substring(0, 2)

                LblStatus.Text = taskControl.Status;

                double commPercent = double.Parse(taskControl.CommissionAgencyPercent);
                commPercent = double.Parse(agentComm.Rows[0][7].ToString())/10;//commPercent / 10;
                TxtCommPercent.Text = commPercent.ToString();
                commPercent = commPercent / 100;
                TxtCommPercent.Text = TxtCommPercent.Text.Trim() + "%";
                TxtCommAmt.Text = (taskControl.TotalPremium * commPercent).ToString("###,##0.00");//int.Parse(agentComm.Rows[0][12].ToString()).ToString("###,##0.00");//taskControl.CommissionAgency.ToString("###,##0.00");

                if (taskControl.CheckNumber.ToString() != "" && taskControl.CheckDate.ToString() != "" && taskControl.CheckAmount.ToString() != "0.0")
                {
                    //txtCheckNumber.Text = taskControl.CheckNumber.ToString();
                    //txtCheckDate.Text = taskControl.CheckDate.ToString();
                    txtCheckAmount.Text = taskControl.CheckAmount.ToString("###,#0.00");
                    DataTable dt = new DataTable();
                    dt = ObtainCommissionPayment(taskControl.TaskControlID);
                    if (dt.Rows.Count > 0)
                    {
                        //txtCheckNumber.Text = dt.Rows[0][4].ToString().Trim();
                        //txtCheckDate.Text = DateTime.Parse(dt.Rows[0][6].ToString()).ToShortDateString().Trim();
                        float total = 0;

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            total = total + float.Parse(dt.Rows[i][3].ToString());
                        }
                        txtCheckAmount.Text = total.ToString("$###,###.00");// float.Parse(dt.Rows[0][3].ToString()).ToString("###,#0.00").Trim();
                        txtBalance.Text = Math.Round(((taskControl.TotalPremium * commPercent) - total)).ToString("$###,###.00");
                    }
                    else
                    { }

                }

                else
                {
                    DataTable dt = new DataTable();
                    dt = ObtainCommissionPayment(taskControl.TaskControlID);

                    if (dt.Rows.Count > 0)
                    {
                        //txtCheckNumber.Text = dt.Rows[0][4].ToString().Trim();
                        //txtCheckDate.Text = DateTime.Parse(dt.Rows[0][6].ToString()).ToShortDateString().Trim();
                        float total = 0;

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            total = total + float.Parse(dt.Rows[i][3].ToString());
                        }
                        txtCheckAmount.Text = total.ToString("$###,###.00");// float.Parse(dt.Rows[0][3].ToString()).ToString("###,#0.00").Trim();
                        txtBalance.Text = ((taskControl.TotalPremium * commPercent) - total).ToString("$###,###.00");
                    }
                    else
                    {
                        //txtCheckNumber.Text = "";
                        //txtCheckDate.Text = "";
                        txtCheckAmount.Text = "";

                    }
                }

            }
            else
            {
                DataTable agentComm = TaskControl.Policy.ObtainAgentPercent(taskControl.Agent2, taskControl.PolicyType.Substring(0, 2));
                int index = 0;

                for (int i = 0; i < agentComm.Rows.Count; i++)
                {
                    if (agentComm.Rows[i][10].ToString() == "2")
                    {
                        index = i;
                        break;
                    }

                }

                LblStatus.Text = taskControl.Status;

                double commPercent = double.Parse(taskControl.CommissionAgencyPercent);
                commPercent = double.Parse(agentComm.Rows[index][7].ToString()) / 10;//commPercent / 10;
                TxtCommPercent.Text = commPercent.ToString();
                commPercent = commPercent / 100;
                TxtCommPercent.Text = TxtCommPercent.Text.Trim() + "%";
                TxtCommAmt.Text = (taskControl.TotalPremium * commPercent).ToString("###,##0.00");//int.Parse(agentComm.Rows[0][12].ToString()).ToString("###,##0.00");//taskControl.CommissionAgency.ToString("###,##0.00");
                //txtCheckNumber.Text = taskControl.CheckNumber2.ToString();
                //txtCheckDate.Text = taskControl.CheckDate2.ToString();
                txtCheckAmount.Text = taskControl.CheckAmount2.ToString("###,#0.00");
            }
        }

        private void FillDataGrid()
        {
            TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControlCommission"];

            LblError.Visible = false;
            searchIndividual.DataSource = null;
            DtTask = null;

            DtTask = ObtainCommissionPayment(taskControl.TaskControlID);

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
                LblError.Text = "Unable to find any comission paid to this agent.";
            }

            LblTotalCases.Text = "Total Cases: " + DtTask.Rows.Count.ToString();
        }

        private void searchIndividual_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            
        }

        protected void btnClose_Click(object sender, System.EventArgs e)
        {
            if (btnClose.Text == "Exit")
                ReturnToReferringPage();
            else
            {
                FillTextControl();
                //txtCheckNumber.Enabled = false;
                //txtCheckDate.Enabled = false;
                txtCheckAmount.Enabled = false;
                //btnEdit.Visible = true; //UNCOMMENT WHEN YOU HAVE EDIT COMISSION INFO
                btnNew.Visible = true;
                //btnUpdate.Visible = false; //UNCOMMENT WHEN YOU HAVE EDIT COMISSION INFO
                btnSave.Visible = false;
                ddlAgent.Enabled = true;
                pnlComissionPayment.Visible = false;

                searchIndividual.Columns[8].Visible = true;
                searchIndividual.Columns[9].Visible = true;

                lblSelectedComissionPaymentID.Text = "0";

                txtDepositDate.Text = "";
                //txtCheckAmount.Text = "";
                TxtPaymentAmount.Text = "";
                TxtPaymentCheck.Text = "";
                txtPaymentDate.Text = "";
                ddlCreditDebit.SelectedIndex = -1;

                TxtCommAmt.Enabled = false;
                TxtCommPercent.Enabled = false;

                btnClose.Text = "Exit";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
            try
            {

                TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
                LookupTables.Agent agent = new LookupTables.Agent();
                LookupTables.Agent agent2 = new LookupTables.Agent();

                agent = agent.GetAgent(taskControl.Agent);

                if (taskControl.Agent2 != String.Empty && taskControl.Agent2 != "000")
                {
                    agent2 = agent.GetAgent(taskControl.Agent2);
                }

                if (ddlAgent.SelectedItem.Value == agent.AgentDesc || ddlAgent.SelectedItem.Value == "")
                {
                    Executor.BeginTrans();
                    Executor.Update("UpdateViewComission", this.GetUpdateViewComissionXml(1));
                    Executor.CommitTrans();

                    //taskControl.CheckNumber = txtCheckNumber.Text.Trim();
                    //taskControl.CheckDate = txtCheckDate.Text.Trim();

                    if (txtCheckAmount.Text.Trim() == "")
                        txtCheckAmount.Text = "0.0";

                    taskControl.CheckAmount = double.Parse(txtCheckAmount.Text.Trim());
                }
                else
                {
                    Executor.BeginTrans();
                    Executor.Update("UpdateViewComission", this.GetUpdateViewComissionXml(2));
                    Executor.CommitTrans();

                    //taskControl.CheckNumber2 = txtCheckNumber.Text.Trim();
                    //taskControl.CheckDate2 = txtCheckDate.Text.Trim();

                    if (txtCheckAmount.Text.Trim() == "")
                        txtCheckAmount.Text = "0.0";

                    taskControl.CheckAmount2 = double.Parse(txtCheckAmount.Text.Trim());
                }
              
                //taskControl.CheckNumber = txtCheckNumber.Text.Trim();
                //taskControl.CheckDate = txtCheckDate.Text.Trim();

                //if (txtCheckAmount.Text.Trim() == "")
                //    txtCheckAmount.Text = "0.0";

                //taskControl.CheckAmount = double.Parse(txtCheckAmount.Text.Trim());

                //txtCheckNumber.Enabled = false;
                //txtCheckDate.Enabled = false;
                txtCheckAmount.Enabled = false;
                //btnEdit.Visible = true; //UNCOMMENT WHEN YOU HAVE EDIT COMISSION INFO
                //btnUpdate.Visible = false; //UNCOMMENT WHEN YOU HAVE EDIT COMISSION INFO
                ddlAgent.Enabled = true;
                btnClose.Text = "Exit";


                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Update saved successfully.");
                this.litPopUp.Visible = true;

            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error while trying to update new fields." + xcp.Message, xcp);
            }
        }

        private XmlDocument GetUpdateViewComissionXml(int agentLvl)
        {
            DbRequestXmlCookRequestItem[] cookItems = 
                new DbRequestXmlCookRequestItem[5];

            TaskControl.TaskControl taskControl = (TaskControl.TaskControl)Session["TaskControl"];

            DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, taskControl.TaskControlID.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("AgentLevel", SqlDbType.Int, 0, agentLvl.ToString(), ref cookItems);
            //DbRequestXmlCooker.AttachCookItem("CheckNumber", SqlDbType.VarChar, 20, txtCheckNumber.Text.Trim(), ref cookItems);
            //DbRequestXmlCooker.AttachCookItem("CheckDate", SqlDbType.VarChar, 20, txtCheckDate.Text.Trim(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("CheckAmount", SqlDbType.Float, 0, txtCheckAmount.Text.Trim(), ref cookItems);
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            return xmlDoc;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtCheckAmount.Text == "0.00" && txtCheckAmount.Text != TxtCommAmt.Text)
                txtCheckAmount.Text = TxtCommAmt.Text;

            btnUpdate.Visible = true;
            ddlAgent.Enabled = false;
            TxtCommAmt.Enabled = true;
            TxtCommPercent.Enabled = true;
            //txtCheckAmount.Enabled = true;
            //txtCheckDate.Enabled = true;
            //txtCheckNumber.Enabled = true;
            btnEdit.Visible = false;
            btnNew.Visible = false;
            btnClose.Text = "Cancel";
        }
        protected void ddlAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillTextControl();
        }

        protected DataTable ObtainCommissionPayment(int TaskControlID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, TaskControlID.ToString(),
                ref cookItems);

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

            DataTable dt = exec.GetQuery("GetCommissionPaymentsByTaskControlID", xmlDoc);
            return dt;
        }
        protected void searchIndividual_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToString() == "Delete")
                {
                    lblSelectedComissionPaymentID.Text = e.Item.Cells[0].Text.Trim();
                    DeleteComissionPayment(lblSelectedComissionPaymentID.Text);

                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Comission Payment deleted.");
                    this.litPopUp.Visible = true;

                    FillDataGrid();
                    FillTextControl();
                }
                else //Edit
                {
                    lblSelectedComissionPaymentID.Text = e.Item.Cells[0].Text.Trim();
                    txtPaymentDate.Text = e.Item.Cells[3].Text.Trim(); 
                    TxtPaymentCheck.Text = e.Item.Cells[1].Text.Trim();
                    TxtPaymentAmount.Text = e.Item.Cells[7].Text.Replace('$',' ').Replace('(', ' ').Replace(')', ' ').Trim();
                    TxtNamePayee.Text = e.Item.Cells[6].Text.Trim();

                    for (int i = 0; ddlCreditDebit.Items.Count - 1 >= i; i++)
                    {
                        if (ddlCreditDebit.Items[i].Text == e.Item.Cells[4].Text.Trim())
                        {
                            ddlCreditDebit.SelectedIndex = i;
                            i = ddlCreditDebit.Items.Count - 1;
                        }
                    }


                    txtDepositDate.Text = e.Item.Cells[5].Text.Trim();

                    TaskControl.TaskControl taskControl = (TaskControl.TaskControl)Session["TaskControl"];
                    EPolicy.LookupTables.Agent agent = new EPolicy.LookupTables.Agent();
                    agent = agent.GetAgent(taskControl.Agent);

                    lblAddNewComission.Text = "Edit Comission Payment: " + e.Item.Cells[6].Text.Trim();
                    pnlComissionPayment.Visible = true;
                    btnClose.Text = "Cancel";
                    //btnEdit.Visible = false; //UNCOMMENT WHEN YOU HAVE EDIT COMISSION INFO
                    btnSave.Visible = true;
                    btnNew.Visible = false;

                    searchIndividual.Columns[8].Visible = false;
                    searchIndividual.Columns[9].Visible = false;
                }
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to execute grid command. " + exp.Message);
                this.litPopUp.Visible = true;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
            try
            {
                if (Validate())
                {
                    TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
                    LookupTables.Agent agent = new LookupTables.Agent();
                    LookupTables.Agent agent2 = new LookupTables.Agent();

                    agent = agent.GetAgent(taskControl.Agent);

                    if (lblSelectedComissionPaymentID.Text == "0")
                    {

                        Executor.BeginTrans();
                        Executor.Insert("AddComissionPayments", this.GetInsertComissionPaymentsXml());
                        Executor.CommitTrans();

                        this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Comission Payment saved successfully.");
                        this.litPopUp.Visible = true;
                    }
                    else
                    {

                        Executor.BeginTrans();
                        Executor.Update("AddComissionPayments", this.GetInsertComissionPaymentsXml());
                        Executor.CommitTrans();

                        this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Comission Payment updated successfully.");
                        this.litPopUp.Visible = true;
                    }

                    pnlComissionPayment.Visible = false;
                    btnClose.Text = "Exit";
                    //btnEdit.Visible = true; //UNCOMMENT WHEN YOU HAVE EDIT COMISSION INFO
                    btnSave.Visible = false;
                    btnNew.Visible = true;

                    searchIndividual.Columns[8].Visible = true;
                    searchIndividual.Columns[9].Visible = true;

                    FillDataGrid();
                    FillTextControl();
                }
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Comission Payment saved successfully.");
                this.litPopUp.Visible = true;

            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(xcp.Message);
                this.litPopUp.Visible = true;
            }
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            TaskControl.TaskControl taskControl = (TaskControl.TaskControl)Session["TaskControl"];
            EPolicy.LookupTables.Agent agent = new EPolicy.LookupTables.Agent();
            agent = agent.GetAgent(taskControl.Agent);

            lblAddNewComission.Text = "Add New Comission Payment: " + agent.AgentDesc;
            TxtNamePayee.Text = agent.AgentDesc;
            pnlComissionPayment.Visible = true;
            btnClose.Text = "Cancel";
            btnEdit.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = false;
            lblSelectedComissionPaymentID.Text = "0";

            searchIndividual.Columns[8].Visible = false;
            searchIndividual.Columns[9].Visible = false;

            txtDepositDate.Text = "";
            //txtCheckAmount.Text = "";
            TxtPaymentAmount.Text = "";
            TxtPaymentCheck.Text = "";
            txtPaymentDate.Text = "";
            ddlCreditDebit.SelectedIndex = -1;
        }
        protected bool Validate()
        {
            DateTime result;

            if (txtPaymentDate.Text == "")
                throw new Exception("Please enter a payment date.");

            if(!DateTime.TryParse(txtPaymentDate.Text,out result))
                throw new Exception("Invalid payment date entered.");

            if (TxtPaymentCheck.Text == "")
                throw new Exception("Please enter a valid Check Number.");

            if (TxtPaymentAmount.Text == "")
                throw new Exception("Please enter a valid Payment Amount.");

            if (ddlCreditDebit.SelectedItem.Value != "1" && ddlCreditDebit.SelectedItem.Value != "2")
                throw new Exception("Please select a valid check type.");

            if (txtDepositDate.Text == "")
                throw new Exception("Please enter a deposit date.");

            if (!DateTime.TryParse(txtDepositDate.Text, out result))
                throw new Exception("Invalid deposit date entered.");

            return true;
        }

        private XmlDocument GetInsertComissionPaymentsXml()
        {
            TaskControl.TaskControl taskControl = (TaskControl.TaskControl)Session["TaskControl"];

            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;

            int userID = 0;
            if (cp != null)
            {
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
            }

            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[9];

            DbRequestXmlCooker.AttachCookItem("ComissionPaymentID",
                SqlDbType.Int, 0, lblSelectedComissionPaymentID.Text,
                ref cookItems);

            DateTime date = DateTime.Parse(txtPaymentDate.Text + " 12:01:00 AM");

            DbRequestXmlCooker.AttachCookItem("TransactionDate",
                SqlDbType.DateTime, 8, DateTime.Now.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PaymentDate",
                    SqlDbType.DateTime, 8, date.ToString(),
                    ref cookItems);

            decimal PayAmt = 0;
            if (ddlCreditDebit.SelectedItem.Value == "2") // Debit
            {
                PayAmt = Math.Abs(decimal.Parse(TxtPaymentAmount.Text)) * -1;
            }
            else
            {
                PayAmt = Math.Abs(decimal.Parse(TxtPaymentAmount.Text));
            }

            DbRequestXmlCooker.AttachCookItem("TransactionAmount",
                SqlDbType.Money, 8, PayAmt.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CheckNumber",
                SqlDbType.Char, 10,TxtPaymentCheck.Text.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CreditDebitID",
                SqlDbType.Int, 0, ddlCreditDebit.SelectedItem.Value.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("DepositDate",
                SqlDbType.DateTime, 8, txtDepositDate.Text.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
            SqlDbType.Int, 0, taskControl.TaskControlID.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("UserID",
            SqlDbType.Int, 0, userID.ToString(),
            ref cookItems);

            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
            return xmlDoc;
        }

        static void DeleteComissionPayment(string comissionPaymentID)
        {
            DBRequest Executor = new DBRequest();

            try
            {
                Executor.BeginTrans();
                Executor.Update("DeleteComissionPayments", DeleteComissionPaymentXml(comissionPaymentID));
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error, Please try again. " + xcp.Message, xcp);
            }
        }
        private static XmlDocument DeleteComissionPaymentXml(string comissionPaymentID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("ComissionPaymentID",
                SqlDbType.Int, 0, comissionPaymentID,
                ref cookItems);

            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            return xmlDoc;
        }
}
}
