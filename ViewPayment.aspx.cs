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
using Baldrich.DBRequest;
using EPolicy.TaskControl;

namespace EPolicy
{
	/// <summary>
	/// Summary description for ViewPayment.
	/// </summary>
	public partial class ViewPayment : System.Web.UI.Page
	{
		private Control LeftMenu;
		private DataTable DtTask;
        private int userID;

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
			this.searchIndividual.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.searchIndividual_ItemCommand);
			this.searchIndividual.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.searchIndividual_ItemDataBound);

		}
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
            try
            {
                Login.Login cp = HttpContext.Current.User as Login.Login;
                if (cp == null)
                {
                    Response.Redirect("HomePage.aspx?001");
                }
                else
                {
                    if (!cp.IsInRole("VIEWPAYMENT") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        Response.Redirect("HomePage.aspx?001");
                    }
                }


                if (!cp.IsInRole("ACCOUNTING") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    btnHistory.Visible = false;
                    btnApply.Visible = false;
                    searchIndividual.Columns[10].Visible = false;
                    searchIndividual.Columns[11].Visible = false;
                }
                else
                {
                    btnHistory.Visible = true;
                    btnApply.Visible = true;
                    searchIndividual.Columns[10].Visible = true;
                    searchIndividual.Columns[11].Visible = true;
                }

                userID = cp.UserID;

                if (!IsPostBack)
                {
                    this.SetReferringPage();

                    TaskControl.Policy taskControl;
                    if (Session["TaskControlPayment"] != null)
                    {
                        taskControl = (TaskControl.Policy)Session["TaskControlPayment"];
                    }
                    else
                    {
                        taskControl = (TaskControl.Policy)Session["TaskControl"];
                        Session.Add("TaskControlPayment", taskControl);
                    }

                    LblCustomerName.Text = "Policy No.: " + taskControl.PolicyType.Trim() + " " + taskControl.PolicyNo.Trim() + " " + taskControl.Certificate.Trim() + " " + taskControl.Suffix.Trim();

                    FillDataGrid();
                    FillTextControl();
                }
                this.litPopUp.Visible = false;
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
		}

		private void FillTextControl() //Alexis
		{
            try
            {
                TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControlPayment"];

                TxtTotalPremium.Enabled = false;
                TxtTotalPaid.Enabled = false;
                TxtBalance.Enabled = false;

                /*RG01
                TxtTotalPremium.Text = (taskControl.TotalPremium + taskControl.Charge + taskControl.CyberEndorsementPremium).ToString("###,###.00");*/
                TxtTotalPaid.Text = taskControl.PaymentsDetail.TotalPaid.ToString("###,###.00");
                TxtBalance.Text = (taskControl.PaymentsDetail.Balance).ToString("###,###.00");
                //(taskControl.TotalPremium + taskControl.Charge)
                if (taskControl.CancellationMethod == 3)
                {
                    TxtTotalPaid.Text = (taskControl.TotalPremium + taskControl.Charge).ToString("###,###.00");
                    TxtBalance.Text = "0.00";
                }


                //if (taskControl.TaskControlID == 44590)
                //{
                //    TxtTotalPaid.Text = (taskControl.TotalPremium + taskControl.Charge).ToString("###,###.00");
                //    TxtBalance.Text = "0.00";
                //}

                if (taskControl.CancellationMethod == 2 && taskControl.TaskControlID == 44361)
                {
                    TxtTotalPaid.Text = (taskControl.TotalPremium + taskControl.Charge).ToString("###,###.00");
                    TxtBalance.Text = "0.00";
                }
                if (taskControl.TaskControlID == 49565)
                {
                    TxtTotalPaid.Text = (taskControl.TotalPremium + taskControl.Charge).ToString("###,###.00");
                    TxtBalance.Text = "0.00";
                
                }

                //TxtBalance.Text = ((taskControl.TotalPremium + taskControl.Charge) - (double)taskControl.PaymentsDetail.TotalPaid).ToString("###,###.00");// Alexis rosado

            }
            catch (Exception exp)
            {
                //if (exp.InnerException == null)
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
                //else if (exp.InnerException.InnerException == null)
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
                //else
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                //         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("A problem occured while assigning data to webpage controls.");
                this.litPopUp.Visible = true;
            }

		}

		private void FillDataGrid()
		{
            try
            {
                TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControlPayment"];

                LblError.Visible = false;
                searchIndividual.DataSource = null;
                DtTask = null;

                taskControl.PaymentsDetail = PaymentPolicy.GetPaymentsByTaskControlID(taskControl);

                DtTask = taskControl.PaymentsDetail.PaymentsCollection;
                DataRow DtTaskRow = DtTask.NewRow();

                //if (taskControl.CancellationMethod == 3)
                //{
                //    DtTaskRow["PartialPaymentID"] = 0;
                //    DtTaskRow["TaskControlID"] = taskControl.TaskControlID;
                //    DtTaskRow["PolicyID"] = 0;
                //    DtTaskRow["PaymentDate"] = taskControl.CancellationDate.ToString().Trim();
                //    DtTaskRow["CheckNumber"] = "Cancel(F)";
                //    DtTaskRow["CreditDebitDesc"] = "CREDIT";
                //    DtTaskRow["TransactionDate"] = taskControl.CancellationDate.ToString().Trim();
                //    DtTaskRow["DepositDate"] = "";
                //    DtTaskRow["Name"] = "";
                //    DtTaskRow["TransactionAmount"] = (taskControl.TotalPremium + taskControl.Charge).ToString("###,###.00");

                //    DtTask.Rows.Add(DtTaskRow);
                //}

                Session.Remove("DtTask");
                Session.Add("DtTask", DtTask);

                //Se actualiza session.
                Session["TaskControl"] = taskControl;

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
            catch (Exception exp)
            {
                //if (exp.InnerException == null)
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
                //else if (exp.InnerException.InnerException == null)
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
                //else
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                //         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("A problem occured while assigning data to webpage controls.");
                this.litPopUp.Visible = true;
            }
		}

		private string ReferringPage
		{
			get
			{
				return ((ViewState["referringPage"] != null)?
					ViewState["referringPage"].ToString():"");
			}
			set
			{
				ViewState["referringPage"] = value;
			}
		}

		private void SetReferringPage()
		{
			if((Session["FromPage"] != null) && (Session["FromPage"].ToString() != ""))
			{
				this.ReferringPage = Session["FromPage"].ToString();
				Session.Remove("FromPage");
			}
		}

		private void ReturnToReferringPage()
		{
			if(this.ReferringPage != "")
			{
				Response.Redirect(this.ReferringPage);
			}
			Response.Redirect("HomePage.aspx");
		}

		private void btnClose_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Session.Remove("TaskControlPayment");
			ReturnToReferringPage();
		}

		private void searchIndividual_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
            try
            {
                TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControlPayment"];
                DataTable dtCol = taskControl.PaymentsDetail.PaymentsCollection;

                DataColumnCollection dc = dtCol.Columns;

                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    DateTime PaymentDateField;
                    DateTime EntryDateField;
                    DateTime DepositDateField;

                    if (DataBinder.Eval(e.Item.DataItem, "PaymentDate") != "")
                    {
                        PaymentDateField = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "PaymentDate", "{0:MM/dd/yyyy}"));
                        e.Item.Cells[5].Text = PaymentDateField.ToShortDateString();
                    }

                    if (DataBinder.Eval(e.Item.DataItem, "TransactionDate") != "")
                    {
                        EntryDateField = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "TransactionDate", "{0:MM/dd/yyyy}"));
                        e.Item.Cells[4].Text = EntryDateField.ToShortDateString();
                    }

                    if (DataBinder.Eval(e.Item.DataItem, "DepositDate") != "")
                    {
                        DepositDateField = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "DepositDate", "{0:MM/dd/yyyy}"));
                        e.Item.Cells[7].Text = DepositDateField.ToShortDateString();
                    }
                }
            }
            catch (Exception exp)
            {
                //if (exp.InnerException == null)
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
                //else if (exp.InnerException.InnerException == null)
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
                //else
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                //         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("An error occurred in webpage grid.");
                this.litPopUp.Visible = true;
            }
		}

		protected void BtnExit_Click(object sender, System.EventArgs e)
		{
           TaskControl.Policy task = (TaskControl.Policy) Session["TaskControl"];

           Session.Remove("TaskControlPayment");
           Session["TaskControl"] = TaskControl.TaskControl.GetTaskControlByTaskControlID(task.TaskControlID, 1);
           ReturnToReferringPage(); 
		}

		private void searchIndividual_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
            //try
            //{
            //    if(e.CommandName.ToString() == "Delete") // Select
            //    {
					
            //        TaskControl.Policy taskControl = (TaskControl.Policy) Session["TaskControlPayment"];
            //        int i = int.Parse(e.Item.Cells[1].Text);
	
            //        PaymentPolicy.DeletePartialPayment(i);

            //        //El pago credito debe de actualizar el paid amount de Policy.
            //        if (e.Item.Cells[6].Text.Trim() == "CREDIT")
            //        {
            //            string pa = e.Item.Cells[7].Text.Substring(1,e.Item.Cells[7].Text.Length-1);
            //            double paidAmt = 0.00;
            //            if (taskControl.PaidAmount <= double.Parse(pa)) // Debit
            //            {
            //                paidAmt = 0.00;
            //            }
            //            else
            //            {
            //                //paidAmt = taskControl.PaidAmount - double.Parse(pa);
            //                paidAmt = double.Parse(TxtTotalPaid.Text) - double.Parse(pa);
            //            }
            //            PaymentPolicy.UpdatePolicyPaidAmount(taskControl.TaskControlID,paidAmt);
            //        }

            //        Session.Remove("DtTask");

            //        FillDataGrid();
            //        FillTextControl();					
            //    }
            //}
            //catch (Exception exp)
            //{
            //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Can not save the information. " + exp.Message);
            //    this.litPopUp.Visible = true;
            //}
		}
        protected void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControlPayment"];

                string[] policyInfo = new string[13];
                policyInfo[0] = taskControl.PolicyType.ToString();
                policyInfo[1] = taskControl.PolicyNo.ToString();
                policyInfo[2] = taskControl.Certificate.ToString();
                policyInfo[3] = taskControl.Suffix.ToString();
                policyInfo[4] = taskControl.Customer.CustomerNo.ToString();
                policyInfo[5] = taskControl.Customer.FirstName.ToString();
                policyInfo[6] = taskControl.Customer.LastName1.ToString();
                policyInfo[7] = taskControl.Customer.LastName2.ToString();
                policyInfo[8] = taskControl.LoanNo.ToString();
                policyInfo[9] = taskControl.Bank.ToString();
                policyInfo[10] = taskControl.PolicyClassID.ToString();
                double prem = taskControl.TotalPremium + taskControl.Charge;
                policyInfo[11] = prem.ToString();
                policyInfo[12] = taskControl.TaskControlID.ToString();

                Session.Clear();

                EPolicy.TaskControl.TaskControl task;
                EPolicy.TaskControl.Payments pay = new EPolicy.TaskControl.Payments();
                task = (TaskControl.TaskControl)pay;
                task.Mode = 1; //ADD
                Session["TaskControl"] = task;

                Session.Add("PolicyInfo", policyInfo);
                Response.Redirect("Payments.aspx");
            }
            catch (Exception exp)
            {
                //if (exp.InnerException == null)
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
                //else if (exp.InnerException.InnerException == null)
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
                //else
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                //         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to transfer to Payments webpage.");
                this.litPopUp.Visible = true;
            }
        }

        protected void searchIndividual_ItemCommand1(object source, DataGridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToString() == "Delete")
                {

                    TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControlPayment"];

                    if (e.Item.Cells[2].Text.Trim() == "Cancelled")//"Cancel(F)")
                    {
                        this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Unable to delete system generated payment. Cancellation Method: " + taskControl.CancellationMethod.ToString());
                        this.litPopUp.Visible = true;
                        return;
                    }

                    if (e.Item.Cells[2].Text.Trim() == "Inception" || e.Item.Cells[2].Text.Trim() == "System")
                    {
                        this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Unable to delete system generated payment.");
                        this.litPopUp.Visible = true;
                        return;
                    }

                    int i = int.Parse(e.Item.Cells[1].Text);

                    History(taskControl.TaskControlID, userID, "DELETE", "PAYMENTS", "DELETED PAYMENT" + System.Environment.NewLine + "CHECK NO: " + e.Item.Cells[2].Text
                        + System.Environment.NewLine + "NAME: " + e.Item.Cells[8].Text + System.Environment.NewLine + "CHECK TYPE: " + e.Item.Cells[6].Text + System.Environment.NewLine + "AMOUNT: " + e.Item.Cells[9].Text
                        + System.Environment.NewLine + "PAYMENT DATE: " + e.Item.Cells[5].Text + System.Environment.NewLine + "DEPOSIT DATE: " + e.Item.Cells[7].Text);

                    PaymentPolicy.DeletePartialPayment(i);

                    //El pago credito debe de actualizar el paid amount de Policy.
                    //if (e.Item.Cells[6].Text.Trim() == "CREDIT")
                    //{
                    //string pa = e.Item.Cells[9].Text.Substring(1, e.Item.Cells[9].Text.Length - 1);
                    //double paidAmt = 0.00;
                    //if (taskControl.PaidAmount <= double.Parse(pa)) // Debit
                    //{
                    //    paidAmt = 0.00;
                    //}
                    //else
                    //{
                    //    //paidAmt = taskControl.PaidAmount - double.Parse(pa);
                    //    paidAmt = double.Parse(TxtTotalPaid.Text) - double.Parse(pa);
                    //}
                    //PaymentPolicy.UpdatePolicyPaidAmount(taskControl.TaskControlID, paidAmt);

                    EPolicy.TaskControl.TaskControl taskControlpol = EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControl.TaskControlID, 1);
                    EPolicy.TaskControl.Policy pol = (EPolicy.TaskControl.Policy)taskControlpol;
                    EPolicy.TaskControl.PaymentPolicy pp = EPolicy.TaskControl.PaymentPolicy.GetPaymentsByTaskControlID(pol);

                    string paidAmtST = pp.TotalPaid.ToString("###,###.00");
                    double paidAmt = double.Parse(paidAmtST);
                    EPolicy.TaskControl.PaymentPolicy.UpdatePolicyPaidAmount(pol.TaskControlID, paidAmt);
                    //}

                    Session.Remove("DtTask");

                    FillDataGrid();
                    FillTextControl();
                }
                else //Edit
                {
                    TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControlPayment"];

                    if (e.Item.Cells[2].Text.Trim() == "Cancelled" && taskControl.CancellationMethod == 3)//"Cancel(F)")
                    {
                        this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Unable to select system generated payment.");
                        this.litPopUp.Visible = true;
                        return;
                    }

                    if (e.Item.Cells[2].Text.Trim() == "Inception" || e.Item.Cells[2].Text.Trim() == "System")
                    {
                        this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Unable to select payment as it was created by the system.");
                        this.litPopUp.Visible = true;
                        return;
                    }

                    string[] policyInfo = new string[18];
                    policyInfo[0] = taskControl.PolicyType.ToString();
                    policyInfo[1] = taskControl.PolicyNo.ToString();
                    policyInfo[2] = taskControl.Certificate.ToString();
                    policyInfo[3] = taskControl.Suffix.ToString();
                    policyInfo[4] = taskControl.Customer.CustomerNo.ToString();
                    policyInfo[5] = taskControl.Customer.FirstName.ToString();
                    policyInfo[6] = taskControl.Customer.LastName1.ToString();
                    policyInfo[7] = taskControl.Customer.LastName2.ToString();
                    policyInfo[8] = taskControl.LoanNo.ToString();
                    policyInfo[9] = taskControl.Bank.ToString();
                    policyInfo[10] = taskControl.PolicyClassID.ToString();
                    //double prem = taskControl.TotalPremium + taskControl.Charge;
                    policyInfo[11] = taskControl.PaidAmount.ToString();
                    policyInfo[12] = taskControl.TaskControlID.ToString();
                    policyInfo[13] = e.Item.Cells[5].Text.Trim(); //Payment Date
                    policyInfo[14] = e.Item.Cells[2].Text.Trim(); //Check No.
                    policyInfo[15] = e.Item.Cells[8].Text.Trim(); //Name
                    policyInfo[16] = e.Item.Cells[7].Text.Trim(); //Deposit Date
                    policyInfo[17] = taskControl.TaskControlID.ToString();

                    Session.Clear();

                    EPolicy.TaskControl.TaskControl task;
                    EPolicy.TaskControl.Payments pay = new EPolicy.TaskControl.Payments();
                    task = (TaskControl.TaskControl)pay;
                    task.Mode = 4;
                    task.TaskControlID = taskControl.TaskControlID;
                    Session["TaskControl"] = task;

                    Session.Add("PolicyInfo", policyInfo);
                    Response.Redirect("Payments.aspx");
                    //string js = "<script language=javascript> javascript:popwindow=window.open('Payments.aspx','popwindow','toolbar=no,location=center,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,copyhistory=no,width=1010,height=610');popwindow.focus();</script>";

                    //string js = "<script language=javascript> javascript:window.opener.location.href = Payments.aspx; window.opener.location.reload(true); </script>";
                    //Session.Clear();
                    //Session["TaskControl"] = taskControl;
                    //Response.Redirect("Policies.aspx?" + taskControl.TaskControlID, true);

                    //Response.Write(js);

                }
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to execute grid command. " + exp.Message);
                this.litPopUp.Visible = true;
            }
        }
        protected void btnHistory_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["TaskControl"] != null)
                {
                    TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControlPayment"];
                    //TaskControl.Policy task = new TaskControl.Policy();
                    //TaskControl.Policy.GetPolicyByTaskControlID(taskControl.TaskControlID, task);
                    //Session.Clear();
                    //Session["TaskControl"] = TaskControl.TaskControl.GetTaskControlByTaskControlID(task.TaskControlID, 1);


                    //TaskControl.Payments payments = (TaskControl.Payments)Session["TaskControl"];

                    Session.Add("TaskControlID", taskControl.TaskControlID);

                    if (taskControl.PolicyType.Trim() == "PP" || taskControl.PolicyType.Trim() == "PE")
                        Response.Redirect("SearchAuditItems.aspx?type=25&taskControlID=" + taskControl.TaskControlID.ToString());
                    else if (taskControl.PolicyType.Trim() == "CP" || taskControl.PolicyType.Trim() == "CE" || taskControl.PolicyType.Trim() == "APC" || taskControl.PolicyType.Trim() == "AEC")
                        Response.Redirect("SearchAuditItems.aspx?type=26&taskControlID=" + taskControl.TaskControlID.ToString());
                    else if (taskControl.PolicyType.Trim() == "CLP" || taskControl.PolicyType.Trim() == "CLE")
                        Response.Redirect("SearchAuditItems.aspx?type=29&taskControlID=" + taskControl.TaskControlID.ToString());
                    else if (taskControl.PolicyType.Trim() == "IF")
                        Response.Redirect("SearchAuditItems.aspx?type=33&taskControlID=" + taskControl.TaskControlID.ToString());
                    else if (taskControl.PolicyType.Trim() == "CF")
                        Response.Redirect("SearchAuditItems.aspx?type=34&taskControlID=" + taskControl.TaskControlID.ToString()); 

                    else
                        Response.Redirect("SearchAuditItems.aspx?type=30&taskControlID=" + taskControl.TaskControlID.ToString());
                        
                }
            }
            catch (Exception exp)
            {
                //if (exp.InnerException == null)
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
                //else if (exp.InnerException.InnerException == null)
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
                //else
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                //         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to transfer to History page.");
                this.litPopUp.Visible = true;
            }
        }
        private void History(int taskControlID, int userID, string action, string subject, string note)
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

        protected void searchIndividual_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
}
}
