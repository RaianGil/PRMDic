using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using EPolicy;
using EPolicy.LookupTables;
using EPolicy.XmlCooker;
using EPolicy.TaskControl;
using EPolicy.Audit;
using System.Xml;
using Microsoft.Reporting.WebForms;
using System.ComponentModel;
using System.Web.SessionState;
using Baldrich.DBRequest;


public partial class LPManager : System.Web.UI.Page
{
    private static int taskControlID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Visible = false;
        this.litPopUp.Visible = false;

        Control Banner = new Control();
        Banner = LoadControl(@"TopBanner1.ascx");
        this.phTopBanner.Controls.Add(Banner);

        /*//Setup Left-side Banner			
        Control LeftMenu = new Control();
        LeftMenu = LoadControl(@"LeftMenu.ascx");
        phTopBanner1.Controls.Add(LeftMenu);*/


        if (!IsPostBack)
        {
            btnImportPayment.Visible = true;
            btnDelete.Visible = true;
            btnPrint.Visible = true;
            BtnExit.Visible = true;

            dtLossPaymentManager.Columns[9].Visible = false;

            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;

            

            int userID = 0;

            if (cp == null)
            {
                Response.Redirect("Default.aspx?001");
            }
            else
            {
                if (!cp.IsInRole("PAYMENTS") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    Response.Redirect("Default.aspx?001");
                }

                if (!cp.IsInRole("ADMINISTRATOR") && !cp.IsInRole("ACCOUNTING"))
                {
                    btnDelete.Visible = false;
                }

                if(userID == 158 || userID == 159 || userID == 238)
                {
                    btnDelete.Visible = false;
                }
            }

            if (cp != null)
            {
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
            }
            DataTable dt = EPolicy.LookupTables.LookupTables.GetTable("PaymentImportLossManager");
            if (dt.Rows.Count > 0)
            {
                dtLossPaymentManager.DataSource = dt;
                dtLossPaymentManager.DataBind();
            }
            else
                dtLossPaymentManager.Visible = false;
        }
    }
    protected void btnManageLossPayments_Click(object sender, EventArgs e)
    {

    }
    protected void btnImportPayment_Click(object sender, EventArgs e)
    {
        Response.Redirect("CertificateFileUpload.aspx");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (dtLossPaymentManager.Items.Count == 0)
        {
            lblError.Visible = true;
            lblError.Text = "No data to Delete";
        }
        else
        {
            bool ver = false;

            lblError.Visible = false;
            int id = 0;

            for (int i = 0; i < dtLossPaymentManager.Items.Count; i++)
            {
                //if (((System.Web.UI.WebControls.CheckBox)dtLossPaymentManager.Items[i].Cells[10].FindControl("chkSelect")).Checked)
                if ((dtLossPaymentManager.Items[i].FindControl("chkSelect") as CheckBox).Checked)
                {
                    id = int.Parse(dtLossPaymentManager.Items[i].Cells[9].Text);
                    ver = true;
                    EPolicy.TaskControl.Payments payments = new EPolicy.TaskControl.Payments();
                    payments.UpdatePolicyPaymentLoss(id, true);
                }
            }

            if (ver == false)
            {
                lblError.Text = "Select at least one item.";
                lblError.Visible = true;
            }
            DataTable dt = EPolicy.LookupTables.LookupTables.GetTable("PaymentImportLossManager");
            dtLossPaymentManager.DataSource = dt;
            dtLossPaymentManager.CurrentPageIndex = 0;
            dtLossPaymentManager.DataBind();
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
            string userName = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();

            ReportViewer2.Reset();
            ReportViewer2.LocalReport.ReportPath = ("Reports/LossPaymentsReport.rdlc");
            ReportViewer2.LocalReport.DataSources.Clear();
            ReportViewer2.ProcessingMode = ProcessingMode.Local;

            LossPaymentTableAdapters.GetPaymentImportLossTableAdapter ta1 =
                new LossPaymentTableAdapters.GetPaymentImportLossTableAdapter();

            LossPayment.GetPaymentImportLossDataTable reportDt1 =
                new LossPayment.GetPaymentImportLossDataTable();

            ta1.Fill(reportDt1);

            Microsoft.Reporting.WebForms.ReportDataSource rptDataSource1 =
            new Microsoft.Reporting.WebForms.ReportDataSource("LossPayment_GetPaymentImportLoss", (DataTable)reportDt1);

            ReportParameter[] param = new ReportParameter[1];
            param[0] = new ReportParameter("userName", userName);

            ReportViewer2.LocalReport.SetParameters(param);

            ReportViewer2.LocalReport.DataSources.Add(rptDataSource1);
            ReportViewer2.LocalReport.Refresh();
            ReportViewer2.Visible = true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    protected void BtnExit_Click(object sender, EventArgs e)
    {

    }
    protected void dtLossPaymentManager_DeleteCommand(object source, DataGridCommandEventArgs e)
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

        int index = Int32.Parse(e.CommandArgument.ToString());
        int i = int.Parse(dtLossPaymentManager.Items[index].Cells[9].Text);

        EPolicy.TaskControl.Payments payments = new EPolicy.TaskControl.Payments();
        payments.UpdatePolicyPaymentLoss(i, true);

        DataTable dt = EPolicy.LookupTables.LookupTables.GetTable("PaymentImportLossManager");
        dtLossPaymentManager.DataSource = dt;
        dtLossPaymentManager.DataBind();
    } 
    protected void dtLossPaymentManager_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Page":
                {
                    EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
                    int userID = 0;

                    try
                    {
                        userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Could not parse user id from cp.Identity.Name.", ex);
                    }

                    dtLossPaymentManager.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                    DataTable dt = EPolicy.LookupTables.LookupTables.GetTable("PaymentImportLossManager");
                    dtLossPaymentManager.DataSource = dt;
                    dtLossPaymentManager.DataBind();
              
                    break;
                }
            default:
                break;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (dtLossPaymentManager.Items.Count == 0)
        {
            lblError.Visible = true;
            lblError.Text = "No data to Select";
        }
        else
        {
            lblError.Visible = false;
            for (int i = 0; i < dtLossPaymentManager.Items.Count; i++)
            {
                (dtLossPaymentManager.Items[i].FindControl("chkSelect") as CheckBox).Checked = true; ;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (dtLossPaymentManager.Items.Count == 0)
        {
            lblError.Visible = true;
            lblError.Text = "No data to Deselect";
        }
        else
        {
            lblError.Visible = false;
            for (int i = 0; i < dtLossPaymentManager.Items.Count; i++)
            {
                (dtLossPaymentManager.Items[i].FindControl("chkSelect") as CheckBox).Checked = false;
            }
        }
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        if (dtLossPaymentManager.Items.Count == 0)
        {
            lblError.Visible = true;
            lblError.Text = "No data to Select";
        }
        else
        {
            lblError.Visible = false;
            for (int i = 0; i < dtLossPaymentManager.Items.Count; i++)
            {
                (dtLossPaymentManager.Items[i].FindControl("chkSelect") as CheckBox).Checked = true; ;
            }
        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        if (dtLossPaymentManager.Items.Count == 0)
        {
            lblError.Visible = true;
            lblError.Text = "No data to Deselect";
        }
        else
        {
            lblError.Visible = false;
            for (int i = 0; i < dtLossPaymentManager.Items.Count; i++)
            {
                (dtLossPaymentManager.Items[i].FindControl("chkSelect") as CheckBox).Checked = false;
            }
        }
    }
    protected void btnReapply_Click(object sender, EventArgs e)
    {
        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        int userID = 0;
        bool ver = false;

        if (cp != null)
        {
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
        }

        try
        {
            EPolicy.TaskControl.Payments payments = new EPolicy.TaskControl.Payments();
            payments.DeletePaymentImport();

            for (int i = 0; i < dtLossPaymentManager.Items.Count; i++)
            {
                //if (((System.Web.UI.WebControls.CheckBox)dtLossPaymentManager.Items[i].Cells[10].FindControl("chkSelect")).Checked)
                if ((dtLossPaymentManager.Items[i].FindControl("chkSelect") as CheckBox).Checked)
                {
                    ver = true;
                    string[] line2 = new string[7];
                    string[] temp = dtLossPaymentManager.Items[i].Cells[5].Text.Split('-');
                    line2[0] = dtLossPaymentManager.Items[i].Cells[1].Text;
                    line2[1] = dtLossPaymentManager.Items[i].Cells[0].Text;
                    line2[2] = dtLossPaymentManager.Items[i].Cells[2].Text.Remove(0,1);
                    line2[3] = dtLossPaymentManager.Items[i].Cells[3].Text;
                    line2[4] = temp[0];
                    line2[5] = temp[1];
                    line2[6] = dtLossPaymentManager.Items[i].Cells[6].Text;


                    //PolicyType, PolicyNo, EffetiveYear
                    DataTable dt = EPolicy.TaskControl.Payments.GetPolicyForPaymentImport(line2[4], line2[5], dtLossPaymentManager.Items[i].Cells[6].Text);

                    if (dt.Rows.Count > 0)
                    {
                        EPolicy.TaskControl.TaskControl taskControl = EPolicy.TaskControl.Policy.GetTaskControlByTaskControlID((int)dt.Rows[0]["TaskControlID"], userID);

                        if ((double)((Policy)taskControl).CancellationAmount > 0.00)
                        {
                            payments.InsertPolicyPaymentImport(i, dtLossPaymentManager.Items[i].Cells[0].Text,
                            dtLossPaymentManager.Items[i].Cells[1].Text, float.Parse(dtLossPaymentManager.Items[i].Cells[2].Text.Remove(0, 1)).ToString(),
                            dtLossPaymentManager.Items[i].Cells[3].Text, dtLossPaymentManager.Items[i].Cells[4].Text,
                            line2[4], line2[5], dtLossPaymentManager.Items[i].Cells[6].Text, "This Policy is cancelled.", "0");
                        }
                        else if ((double)((Policy)taskControl).PaymentsDetail.TotalPaid >= ((Policy)taskControl).TotalPremium + ((Policy)taskControl).Charge)
                        {
                            payments.InsertPolicyPaymentImport(i, dtLossPaymentManager.Items[i].Cells[0].Text,
                            dtLossPaymentManager.Items[i].Cells[1].Text, float.Parse(dtLossPaymentManager.Items[i].Cells[2].Text.Remove(0, 1)).ToString(),
                            dtLossPaymentManager.Items[i].Cells[3].Text, dtLossPaymentManager.Items[i].Cells[4].Text,
                            line2[4], line2[5], dtLossPaymentManager.Items[i].Cells[6].Text, "This Policy is already paid.", "0");
                        }
                        else
                        {
                            AddCertificate(line2, i);
                            taskControl = Policy.GetTaskControlByTaskControlID((int)dt.Rows[0]["TaskControlID"], userID);

                            if ((double)((Policy)taskControl).PaymentsDetail.TotalPaid >= ((Policy)taskControl).TotalPremium + ((Policy)taskControl).Charge)
                            {
                                DataTable payDt = EPolicy.TaskControl.Payments.GetPaymentImportLossByCriteria(line2[1], line2[0], line2[2], line2[3], line2[1], line2[4],
                                    line2[5], line2[6]);

                                    /*(dtLossPaymentManager.Items[i].Cells[0].Text,
                            dtLossPaymentManager.Items[i].Cells[1].Text, float.Parse(dtLossPaymentManager.Items[i].Cells[2].Text.Remove(0, 1)).ToString(),
                            dtLossPaymentManager.Items[i].Cells[3].Text, dtLossPaymentManager.Items[i].Cells[4].Text,
                            line2[4], line2[5], dtLossPaymentManager.Items[i].Cells[6].Text);*/

                                payments.InsertPolicyPaymentImport(i, dtLossPaymentManager.Items[i].Cells[0].Text,
                            dtLossPaymentManager.Items[i].Cells[1].Text, float.Parse(dtLossPaymentManager.Items[i].Cells[2].Text.Remove(0, 1)).ToString(),
                            dtLossPaymentManager.Items[i].Cells[3].Text, dtLossPaymentManager.Items[i].Cells[4].Text,
                            line2[4], line2[5], dtLossPaymentManager.Items[i].Cells[6].Text, "Payment Complete!", "1");

                                if (payDt.Rows.Count > 0)
                                    payments.UpdatePolicyPaymentLoss(int.Parse(payDt.Rows[0]["PaymentImportID"].ToString()), true);
                            }
                            else
                            {
                                DataTable payDt = EPolicy.TaskControl.Payments.GetPaymentImportLossByCriteria(line2[1], line2[0], line2[2], line2[3], line2[1], line2[4],
                                    line2[5], line2[6]);

                                payments.InsertPolicyPaymentImport(i, dtLossPaymentManager.Items[i].Cells[0].Text,
                            dtLossPaymentManager.Items[i].Cells[1].Text, float.Parse(dtLossPaymentManager.Items[i].Cells[2].Text.Remove(0, 1)).ToString(),
                            dtLossPaymentManager.Items[i].Cells[3].Text, dtLossPaymentManager.Items[i].Cells[4].Text,
                            line2[4], line2[5], dtLossPaymentManager.Items[i].Cells[6].Text, "Payment Pending: $" + ((((Policy)taskControl).TotalPremium + ((Policy)taskControl).Charge) - (double)((Policy)taskControl).PaymentsDetail.TotalPaid).ToString("###,###,##0.00"), "2");

                                if (payDt.Rows.Count > 0)
                                    payments.UpdatePolicyPaymentLoss(int.Parse(payDt.Rows[0]["PaymentImportID"].ToString()), true);
                            }

                        }
                    }
                    else
                    {
                        //0, PaymentDate, PaymentCheck, PaymentAmount, name, DepositDate, policyType, policyNo, effectiveDate
                        payments.InsertPolicyPaymentImport(i, dtLossPaymentManager.Items[i].Cells[0].Text,
                            dtLossPaymentManager.Items[i].Cells[1].Text, float.Parse(dtLossPaymentManager.Items[i].Cells[2].Text.Remove(0, 1)).ToString(),
                            dtLossPaymentManager.Items[i].Cells[3].Text, dtLossPaymentManager.Items[i].Cells[4].Text,
                            line2[4], line2[5], dtLossPaymentManager.Items[i].Cells[6].Text, "Policy not found.", "0");

                        //payments.DeletePaymentImport(0, "");
                    }
                }
            }

            if (ver == false)
            {
                lblError.Text = "Select at least one item.";
                lblError.Visible = true;
            }
            else
            {
                DataTable dt = EPolicy.LookupTables.LookupTables.GetTable("PaymentImportLossManager");
                dtLossPaymentManager.DataSource = dt;
                dtLossPaymentManager.DataBind();

                PrintReport();

                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Payments processed successfully.");
                this.litPopUp.Visible = true;
            }
        }
        catch (Exception ex)
        {
            EPolicy.TaskControl.Payments payments = new EPolicy.TaskControl.Payments();
            payments.DeletePaymentImport();
            this.litPopUp.Text = Utilities.MakeLiteralPopUpString(ex.Message);
            this.litPopUp.Visible = true;

            //string[] line3 = temp.Split(',');
            //payments.InsertPolicyPaymentImport(i, line3[1], line3[0], line3[3], line3[4], line3[1], line3[5], line3[6], line3[7], ex.Message, "FAIL");
            //payments.DeletePaymentImport(0, "");
        }
    }

    private void FillProperties(string[] line2)
    {
        string line = "";
        try
        {
            //Payments taskControl = (Payments)Session["TaskControl"];
            EPolicy.TaskControl.Payments taskControl = new EPolicy.TaskControl.Payments();

            DataTable dt = EPolicy.TaskControl.Payments.GetPolicyForPaymentImport(line2[4], line2[5], line2[6]);
            EPolicy.TaskControl.TaskControl task = EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(int.Parse(dt.Rows[0][1].ToString()), 1);
            EPolicy.TaskControl.Policy policy = new EPolicy.TaskControl.Policy();
            EPolicy.TaskControl.Policy.GetPolicyByTaskControlID(task.TaskControlID, policy);


            //taskControl.PolicyClassID = ddlPolicyClass.SelectedItem.Value != "" ? int.Parse(ddlPolicyClass.SelectedItem.Value.ToString()) : 0;
            //taskControl.OriginalPolicyNo = txtOriginalPolicyNo.Text.ToUpper();
            //taskControl.PolicyType = TxtPolicyType.Text.ToUpper();
            //taskControl.PolicyNo = txtPolicyNo.Text.ToUpper();
            //taskControl.Certificate = txtCertificate.Text.ToUpper();
            //taskControl.Sufijo = TxtSuffix.Text.ToUpper();
            //taskControl.LoanNumber = TxtLoanNo.Text.ToUpper();
            //taskControl.Comments = txtComments.Text.ToUpper();
            ////taskControl.Comments1		= TxtComments1.Text.ToUpper();
            //taskControl.TaskStatusID = ddlTaskStatus.SelectedItem.Value != "" ? int.Parse(ddlTaskStatus.SelectedItem.Value.ToString()) : 0;
            //taskControl.CustomerNo = TxtCustomerNo.Text.ToUpper();
            //taskControl.Bank = ddlBank.SelectedItem.Value != "" ? ddlBank.SelectedItem.Value : "000";
            //taskControl.Licence = ChkSRO.Checked;
            //taskControl.DepositDate = txtDepositDate.Text;
            //taskControl.PaymentDate = TxtPaymentDate.Text;
            //taskControl.CheckNo = TxtPaymentCheck.Text.ToUpper();
            //taskControl.CreditDebitID = ddlCreditDebit.SelectedItem.Value != "" ? int.Parse(ddlCreditDebit.SelectedItem.Value) : 0;
            //taskControl.Name = TxtNamePayee.Text.ToUpper();
            //taskControl.MultiplePayment = ChkMultiple.Checked;
            //taskControl.IsNewTransaction = ChkIsNEwTransaction.Checked;

            taskControl.CheckNo = line2[0];
            taskControl.PaymentDate = line2[1];
            taskControl.DepositDate = line2[1];
            taskControl.Name = line2[3];
            taskControl.PolicyType = line2[4];
            taskControl.PolicyNo = line2[5];
            string policyYear = line2[6];

            taskControl.OriginalPolicyNo = line2[5];
            taskControl.PolicyClassID = task.PolicyClassID;
            taskControl.Certificate = policy.Certificate;
            taskControl.Sufijo = policy.Suffix;
            taskControl.LoanNumber = policy.LoanNo;
            taskControl.Comments = "";
            //taskControl.TaskStatusID = task.TaskStatusID;
            taskControl.CustomerNo = task.CustomerNo;
            taskControl.Bank = task.Bank;
            taskControl.Licence = false;
            taskControl.CreditDebitID = 1;
            taskControl.MultiplePayment = false;
            taskControl.IsNewTransaction = true;
            taskControl.Mode = 1;

            if (//taskControl.Mode == (int)TaskControl.TaskControl.TaskControlMode.ADD
                taskControl.Mode == (int)EPolicy.TaskControl.TaskControl.TaskControlMode.ADD)
            {
                //Login.Login cp = HttpContext.Current.User as Login.Login;
                EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
                taskControl.EnteredBy = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();
            }

            bool error = false;
            //string payAmt = TxtPaymentAmount.Text.Trim();
            string payAmt = line2[2].Trim();

            for (int i = 0; i <= payAmt.Length - 1; i++)
            {
                if (System.Char.IsDigit(payAmt, i) || Char.Parse(payAmt.Substring(i, 1)) == '.' || Char.Parse(payAmt.Substring(i, 1)) == ',' || Char.Parse(payAmt.Substring(i, 1)) == '-')
                {
                    error = false;
                }
                else
                {
                    error = true;
                    //i = TxtPaymentAmount.Text.Trim().Length - 1;
                    i = line.Length - 1;
                }
            }

            if (error)
            {
                throw new Exception("Payment Amount must be numeric digit.");
            }

            if (//TxtPaymentAmount.Text != ""
                payAmt != "")
                //taskControl.PaymentAmount = Decimal.Parse(TxtPaymentAmount.Text.Replace(",", ""));
                taskControl.PaymentAmount = Decimal.Parse(payAmt.Replace(",", ""));

            Session.Add("TaskControl", taskControl);
        }
        catch (Exception exp)
        {
            //this.litPopUp.Text = Utilities.MakeLiteralPopUpString("A problem occured filling class properties.");
            this.litPopUp.Visible = true;
        }
    }

    private void AddCertificate(string[] line2, int i)
    {
        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        int userID = 0;

        if (cp != null)
        {
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
        }

        FillProperties(line2);
        EPolicy.TaskControl.Payments taskControl = (EPolicy.TaskControl.Payments)Session["TaskControl"];

        if (taskControlID != 0)
        {
            taskControl.TaskControlID = taskControlID;
            Session["TaskControl"] = taskControl;
        }

        taskControl.Save(userID);

        //Luego de aplicar el pago, el sistema verifica el PaidAmount de la tabla de policy y lo actualiza

        EPolicy.TaskControl.TaskControl taskControlpol = EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControl.TaskControlID, 1);
        Policy pol = new Policy();
        DataTable dt = EPolicy.TaskControl.Payments.GetPolicyForPaymentImport(taskControl.PolicyType, taskControl.PolicyNo, line2[6]);
        pol = Policy.GetPolicyByTaskControlID(int.Parse(dt.Rows[0]["TaskControlID"].ToString()), pol);
        //(Policy)taskControlpol;

        //double payAmount = double.Parse(TxtPaymentAmount.Text);
        double payAmount = double.Parse(taskControl.PaymentAmount.ToString());

        History(pol.TaskControlID, userID, "ADD", "PAYMENTS", "ADDED PAYMENT" + System.Environment.NewLine + "CHECK NO: " + taskControl.CheckNo.ToString()
        + System.Environment.NewLine + "NAME: " + taskControl.Name.ToString() + System.Environment.NewLine + "AMOUNT: " + payAmount.ToString("$###,###")
        + System.Environment.NewLine + "CHECK TYPE: " + "CREDIT" + System.Environment.NewLine + "PAYMENT DATE: " + taskControl.PaymentDate.ToString() + System.Environment.NewLine +
        "DEPOSIT DATE: " + taskControl.PaymentDate.ToString());

        PaymentPolicy pp = PaymentPolicy.GetPaymentsByTaskControlID(pol);

        string paidAmtST = pp.TotalPaid.ToString("###,###.00");
        double paidAmt = double.Parse(paidAmtST);
        PaymentPolicy.UpdatePolicyPaidAmount(pol.TaskControlID, paidAmt);
    }

    private void History(int taskControlID, int userID, string action, string subject, string note)
    {
        History history = new History();
        //TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];

        EPolicy.TaskControl.TaskControl taskControlpol = EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControlID, 1);
        Policy pol = (Policy)taskControlpol;

        history.Actions = action;
        history.KeyID = taskControlpol.TaskControlID.ToString();
        history.Subject = subject;
        //history.BuildNotesForHistory("TaskControlID.", "", taskControlID.ToString(), 7);  //7 = mode NOTICEOFCANC
        history.UsersID = userID;
        history.Notes = note + "\r\n";
        history.GetSaveHistory();
    }

    protected void PrintReport()
    {
        try
        {
            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
            string userName = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();

            ReportViewer2.Reset();
            ReportViewer2.LocalReport.ReportPath = ("Reports/ImportPaymentStatus.rdlc");
            ReportViewer2.LocalReport.DataSources.Clear();
            ReportViewer2.ProcessingMode = ProcessingMode.Local;

            ImportPaymentStatusTableAdapters.GetPaymentImportByStatusCompletedTableAdapter ta1 =
                new ImportPaymentStatusTableAdapters.GetPaymentImportByStatusCompletedTableAdapter();

            ImportPaymentStatus.GetPaymentImportByStatusCompletedDataTable reportDt1 =
                new ImportPaymentStatus.GetPaymentImportByStatusCompletedDataTable();

            ImportPaymentStatusTableAdapters.GetPaymentImportByStatusPendingTableAdapter ta2 =
                new ImportPaymentStatusTableAdapters.GetPaymentImportByStatusPendingTableAdapter();

            ImportPaymentStatus.GetPaymentImportByStatusPendingDataTable reportDt2 =
                new ImportPaymentStatus.GetPaymentImportByStatusPendingDataTable();

            ImportPaymentStatusTableAdapters.GetPaymentImportByStatusFailedTableAdapter ta3 =
                new ImportPaymentStatusTableAdapters.GetPaymentImportByStatusFailedTableAdapter();

            ImportPaymentStatus.GetPaymentImportByStatusFailedDataTable reportDt3 =
                new ImportPaymentStatus.GetPaymentImportByStatusFailedDataTable();

            ta1.Fill(reportDt1, "1");
            ta2.Fill(reportDt2, "2");
            ta3.Fill(reportDt3, "0");

            Microsoft.Reporting.WebForms.ReportDataSource rptDataSource1 =
            new Microsoft.Reporting.WebForms.ReportDataSource("ImportPaymentStatus_GetPaymentImportByStatusCompleted", (DataTable)reportDt1);

            Microsoft.Reporting.WebForms.ReportDataSource rptDataSource2 =
            new Microsoft.Reporting.WebForms.ReportDataSource("ImportPaymentStatus_GetPaymentImportByStatusPending", (DataTable)reportDt2);

            Microsoft.Reporting.WebForms.ReportDataSource rptDataSource3 =
            new Microsoft.Reporting.WebForms.ReportDataSource("ImportPaymentStatus_GetPaymentImportByStatusFailed", (DataTable)reportDt3);

            ReportParameter[] param = new ReportParameter[1];
            param[0] = new ReportParameter("userName", userName);

            ReportViewer2.LocalReport.SetParameters(param);

            ReportViewer2.LocalReport.DataSources.Add(rptDataSource1);
            ReportViewer2.LocalReport.DataSources.Add(rptDataSource2);
            ReportViewer2.LocalReport.DataSources.Add(rptDataSource3);
            ReportViewer2.LocalReport.Refresh();
            ReportViewer2.Visible = true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


}
