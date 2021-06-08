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
using Baldrich.DBRequest;
using EPolicy.XmlCooker;
using System.Xml;

public partial class PaymentVSC : System.Web.UI.Page
{
    private Control LeftMenu;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region Web Form Designer generated code
        Control Banner = new Control();
        Banner = LoadControl(@"TopBanner1.ascx");
        //((Baldrich.BaldrichWeb.Components.TopBanner)Banner).SelectedOption = (int)Baldrich.HeadBanner.MenuOptions.Home;
        this.Placeholder1.Controls.Add(Banner);

        //Setup Left-side Banner

        //LeftMenu = new Control();
        //LeftMenu = LoadControl(@"LeftMenu.ascx");
        //phTopBanner1.Controls.Add(LeftMenu);
        #endregion

        this.litPopUp.Visible = false;

        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        if (cp == null)
        {
            Response.Redirect("HomePage.aspx?001");
        }
        else
        {
            if (!cp.IsInRole("PAYMENTS") && !cp.IsInRole("ADMINISTRATOR"))
            {
                Response.Redirect("HomePage.aspx?001");
            }
        }

        if (Session["AutoPostBack"] == null)
        {
            if (!IsPostBack)
            {
                DataTable dtCreditDebit = EPolicy.LookupTables.LookupTables.GetTable("CreditDebit");
                //CreditDebit
                ddlCreditDebit.DataSource = dtCreditDebit;
                ddlCreditDebit.DataTextField = "CreditDebitDesc";
                ddlCreditDebit.DataValueField = "CreditDebitID";
                ddlCreditDebit.DataBind();
                ddlCreditDebit.SelectedIndex = -1;
                ddlCreditDebit.Items.Insert(0, "");

                TxtPolicyType.Text = "PE ";
                txtPolicyNo.Text = "";
                TxtSuffix.Text = "00";
                txtDepositDate.Text = "";
                TxtPaymentDate.Text = "";
                TxtPaymentCheck.Text = "";
                TxtPaymentAmount.Text = "";
                txtTotalPayment.Text = "0.00";
            }
        }

    }
    protected void Button6_Click(object sender, EventArgs e)
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

        try
        {
            FillProperties();
            EPolicy.TaskControl.Payments taskControl = (EPolicy.TaskControl.Payments)Session["TaskControl"];

            taskControl.Save(userID);
            if (txtTCIDPolicy.Text.Trim() != "")
            {
                EPolicy.TaskControl.TaskControl taskControlpol = EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(int.Parse(txtTCIDPolicy.Text.Trim()), 1);

                EPolicy.TaskControl.Policy pol = (EPolicy.TaskControl.Policy)taskControlpol;
                EPolicy.TaskControl.PaymentPolicy pp = EPolicy.TaskControl.PaymentPolicy.GetPaymentsByTaskControlID(pol);

                string paidAmtST = pp.TotalPaid.ToString("###,###.00");
                double paidAmt = double.Parse(paidAmtST);
                EPolicy.TaskControl.PaymentPolicy.UpdatePolicyPaidAmount(pol.TaskControlID, paidAmt);
            }

            FillDataGrid(taskControl);

            SumPaymentTotal(true, TxtPaymentAmount.Text.Trim());

            Session.Remove("TaskControl");
            TxtPaymentAmount.Text = "";
            txtPolicyNo.Text = "";
        }
        catch (Exception exp)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Unable to save this Task." + "\r\n" + exp.Message);
            this.litPopUp.Visible = true;
        }
    }

    private void FillDataGrid(EPolicy.TaskControl.Payments taskControl)
    {
        DataTable dt = AddRowInTable(taskControl);

        this.gdVscQuote.DataSource = null;
        this.gdVscQuote.CurrentPageIndex = 0;
        this.gdVscQuote.Visible = false;

        if (dt.Rows.Count != 0)
        {
            this.gdVscQuote.Visible = true;

            this.gdVscQuote.DataSource = dt;
            this.gdVscQuote.DataBind();
        }
        else
        {
            this.gdVscQuote.DataSource = null;
            this.gdVscQuote.DataBind();
        }     
    }

    private DataTable AddRowInTable(EPolicy.TaskControl.Payments taskControl)
    {
        DataTable aTable;
        if (Session["DtVscPayment"] == null)
        {
            aTable = new DataTable();
            aTable.Columns.Add("TaskControlID", typeof(int));
            aTable.Columns.Add("PolicyType", typeof(string));
            aTable.Columns.Add("PolicyNo", typeof(string));
            aTable.Columns.Add("TotalPaid", typeof(string));
            aTable.Columns.Add("PaymentApplied", typeof(string)); 
        }
        else
        {
            aTable = (DataTable)Session["DtVscPayment"];
        }

        DataRow dr; 
        dr = aTable.NewRow();
        dr[0] = taskControl.TaskControlID;
        dr[1] = taskControl.PolicyType.Trim();
        dr[2] = taskControl.PolicyNo.Trim();
        dr[3] = taskControl.PaymentAmount.ToString("###,###.00");
        //dr[2] = taskControl.PaymentAmount.ToString();

        if(taskControl.PaymentApplied)
            dr[4] = "Yes"; 
        else
            dr[4] = "No"; 

        aTable.Rows.Add(dr);

        //aTable.ImportRow(myRow);
        aTable.AcceptChanges();

        if (Session["DtVscPayment"] == null)
        {
            Session.Add("DtVscPayment", aTable);
        }
        else
        {
            Session["DtVscPayment"] = aTable;
        }

        return aTable;
    }

    private void FillProperties()
    {
        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        int userID = 0;
        userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

        EPolicy.TaskControl.Payments taskControl = new EPolicy.TaskControl.Payments();

        taskControl.Mode = 1;
        taskControl.PolicyClassID = 9; //PRMDIC
        taskControl.OriginalPolicyNo = txtPolicyNo.Text.ToUpper();
        taskControl.PolicyType = TxtPolicyType.Text.ToUpper();
        taskControl.PolicyNo = txtPolicyNo.Text.ToUpper().Trim();
        taskControl.Certificate = "";
        taskControl.Sufijo = TxtSuffix.Text.ToUpper().Trim();
        taskControl.LoanNumber = "";
        taskControl.Comments = "";
        taskControl.TaskStatusID = 0;

        taskControl.Licence = false;
        taskControl.DepositDate = txtDepositDate.Text;
        taskControl.PaymentDate = TxtPaymentDate.Text;
        taskControl.CheckNo = TxtPaymentCheck.Text.ToUpper();
        taskControl.CreditDebitID = ddlCreditDebit.SelectedItem.Value != "" ? int.Parse(ddlCreditDebit.SelectedItem.Value) : 0;
        taskControl.Name = txtName.Text.Trim().ToUpper();
        taskControl.MultiplePayment = false;
        taskControl.IsNewTransaction = false;

        DataTable dt = EPolicy.TaskControl.Policy.GetPolicyByPolicyNo(taskControl.PolicyType, taskControl.PolicyNo, "", taskControl.Sufijo);

        if (dt.Rows.Count != 0)
        {
            EPolicy.TaskControl.TaskControl tc = EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID((int)dt.Rows[0]["TaskControlID"], userID);
            taskControl.CustomerNo = tc.CustomerNo.Trim();
            taskControl.Bank = tc.Bank.Trim();
            taskControl.InsuranceCompany = tc.InsuranceCompany.Trim();
            txtTCIDPolicy.Text = tc.TaskControlID.ToString();
        }
        else
        {
            taskControl.CustomerNo = "";
            taskControl.Bank = "000";
        }

        taskControl.EnteredBy = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();        

        bool error = false;
        string payAmt = TxtPaymentAmount.Text.Trim();

        for (int i = 0; i <= payAmt.Length - 1; i++)
        {
            if (System.Char.IsDigit(payAmt, i) || Char.Parse(payAmt.Substring(i, 1)) == '.' || Char.Parse(payAmt.Substring(i, 1)) == ',' || Char.Parse(payAmt.Substring(i, 1)) == '-')
            {
                error = false;
            }
            else
            {
                error = true;
                i = TxtPaymentAmount.Text.Trim().Length - 1;
            }
        }

        if (error)
        {
            throw new Exception("Payment Amount must be numeric digit.");
        }

        if (TxtPaymentAmount.Text != "")
            taskControl.PaymentAmount = Decimal.Parse(TxtPaymentAmount.Text.Replace(",", ""));

        Session.Add("TaskControl", taskControl);
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        TxtPolicyType.Text = "PE ";
        txtPolicyNo.Text = "";
        txtName.Text = "";
        TxtSuffix.Text = "00";
        txtDepositDate.Text = "";
        TxtPaymentDate.Text = "";
        TxtPaymentCheck.Text = "";
        TxtPaymentAmount.Text = "";
        txtTotalPayment.Text = "0.00";
        this.lblNotFound.Visible = false;
        this.pnlInfo.Visible = false;

        ddlCreditDebit.SelectedIndex = -1;

        Session.Remove("DtVscPayment");

        this.gdVscQuote.DataSource = null;
        this.gdVscQuote.DataBind();
        this.gdVscQuote.CurrentPageIndex = 0;
        this.gdVscQuote.Visible = false;

    }
    protected void BtnExit_Click(object sender, EventArgs e)
    {

    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        pnlInfo.Visible = false;
    }

    private static DataTable GetVSCPoliciesByContractNo(string ContractNo, string PolicyType)
    {
        DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[2];

        DbRequestXmlCooker.AttachCookItem("PolicyType",
                    SqlDbType.VarChar, 3, PolicyType.ToString(),
                    ref cookItems);

        DbRequestXmlCooker.AttachCookItem("PolicyNo",
            SqlDbType.VarChar, 10, ContractNo.ToString(),
            ref cookItems);

        DBRequest exec = new DBRequest();
        XmlDocument xmlDoc;

        try
        {
            xmlDoc = DbRequestXmlCooker.Cook(cookItems);
        }
        catch (Exception ex)
        {
            throw new Exception("Could not cook items.", ex);
        }
        DataTable dt = null;
        try
        {
            dt = exec.GetQuery("GetPoliciesByPolicyTypePolicyNo", xmlDoc);
            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception("Could not retrieve the policies by criteria.", ex);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (this.txtPolicyNo.Text.Trim() == "")
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Enter the contract number.");
            this.litPopUp.Visible = true;
        }

        DataTable dt = GetVSCPoliciesByContractNo(this.txtPolicyNo.Text, this.TxtPolicyType.Text);

        if (dt.Rows.Count != 0)
        {
            this.TxtContractNo.Text = this.txtPolicyNo.Text;
            this.txtCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
            this.TxtTotalPrice.Text = dt.Rows[0]["TotalPremium"].ToString();
            this.TxtSuffix.Text = dt.Rows[0]["Sufijo"].ToString();

            this.pnlInfo.Visible = true;
            this.lblNotFound.Visible = false;
        }
        else
        {
            this.TxtContractNo.Text = "";
            this.txtCustomerName.Text = "";
            this.TxtTotalPrice.Text = "";

            this.pnlInfo.Visible = false;
            this.lblNotFound.Visible = true;
        }
    }
    protected void BtnExit_Click1(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("MainMenu.aspx", false);
    }

    private void SumPaymentTotal(bool IsCalculate, string payAmt)
    {
        if (IsCalculate)
        {
            double prem = double.Parse(TxtPaymentAmount.Text.Trim());
            double tot = double.Parse(txtTotalPayment.Text.Trim());

            if (ddlCreditDebit.SelectedItem.Value.Trim() == "2") // Debit
                prem = Math.Abs(prem) * -1;
             else
                prem = Math.Abs(prem);

            tot = tot + prem;

            txtTotalPayment.Text = tot.ToString("###,###.00");
        }
        else
        {
            txtTotalPayment.Text = "0.00";
        }
    }
    protected void txtTotalPayment_TextChanged(object sender, EventArgs e)
    {

    }
}
