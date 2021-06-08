using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using EPolicy.TaskControl;
using Baldrich.DBRequest;
using EPolicy.XmlCooker;
using System.Xml;
using System.Windows.Forms;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using EPolicy.Audit;
using EPolicy;
using System.Net.Mail;

public partial class FinancialCancellations : System.Web.UI.Page
{
    static int financialCancellationID = 0;
    static string oldComments = String.Empty;
    static string financialCancellationType = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Policy taskControl = (Policy)Session["TaskControl"];
            DataTable dtHistoryTable = Policy.GetCertificateHistoryForTable(taskControl.PolicyType, taskControl.PolicyNo);
            grdCancNotice.DataSource = dtHistoryTable;
            grdCancNotice.DataBind();

            if (dtHistoryTable.Rows.Count > 0)
            {
                grdCancNotice.Visible = true;
                Label1.Visible = true;
            }
            else
            {
                grdCancNotice.Visible = false;
                Label1.Visible = false;
            }

            this.SetReferringPage();
            DisableControls();
            FillDDLControls();
            FillTextControl();
        }
        this.litPopUp.Visible = false;
    }

    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        try
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);

            System.Web.UI.Control Banner = new System.Web.UI.Control();
            Banner = LoadControl(@"TopBanner.ascx");
            this.Placeholder1.Controls.Add(Banner);

            //Setup Left-side Banner			
            System.Web.UI.Control LeftMenu = new System.Web.UI.Control();
            LeftMenu = LoadControl(@"LeftMenu.ascx");
            phTopBanner1.Controls.Add(LeftMenu);
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

            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString(exp.Message);
            this.litPopUp.Visible = true;
        }

    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {

    }
    #endregion

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

    protected void DisableControls()
    {
        Policy taskControl = (Policy)Session["TaskControl"];

        btnSave.Visible = false;
        BtnCancel.Visible = false;
        btnReinst.Visible = false;
        ddlFinancial.Enabled = false;
        txtFinancialPhoneNo.Enabled = false;
        txtContractNo.Enabled = false;
        txtPolicyNo.Enabled = false;
        txtInstallmentNum.Enabled = false;
        txtPayment.Enabled = false;
        txtEffDate.Enabled = false;
        txtInstallment.Enabled = false;
        txtTotalToPay.Enabled = false;
        chkEnable.Visible = false;
        pnlCancellations.Visible = false;

        DataTable dt = GetNoticeCancellationByTaskControlID(taskControl.TaskControlID);
        if (dt.Rows.Count > 0)
        {
            btnPrintAll.Visible = true;
        }
        else
        {
            btnPrintAll.Visible = false;
        } 

        
    }
    protected void FillDDLControls()
    {
        DataTable dtFinancial = EPolicy.LookupTables.LookupTables.GetTable("Financial");
        DataTable dtAgency = EPolicy.LookupTables.LookupTables.GetTable("Agency");
        DataTable dtAgent = EPolicy.LookupTables.LookupTables.GetTable("Agent");

        ddlFinancial.DataSource = dtFinancial;
        ddlFinancial.DataTextField = "FinancialDesc";
        ddlFinancial.DataValueField = "FinancialID";
        ddlFinancial.DataBind();
        ddlFinancial.SelectedIndex = -1;

        ddlFinancial0.DataSource = dtFinancial;
        ddlFinancial0.DataTextField = "FinancialDesc";
        ddlFinancial0.DataValueField = "FinancialID";
        ddlFinancial0.DataBind();
        ddlFinancial0.SelectedIndex = -1;

        //Agency
        ddlAgency.DataSource = dtAgency;
        ddlAgency.DataTextField = "AgencyDesc";
        ddlAgency.DataValueField = "AgencyID";
        ddlAgency.DataBind();
        ddlAgency.SelectedIndex = -1;
        ddlAgency.Items.Insert(0, "");

        //Agent
        ddlAgent.DataSource = dtAgent;
        ddlAgent.DataTextField = "AgentDesc";
        ddlAgent.DataValueField = "AgentID";
        ddlAgent.DataBind();
        ddlAgent.SelectedIndex = -1;
        ddlAgent.Items.Insert(0, "");
    }
    protected void FillTextControl()
    {
        Policy taskControl = (Policy)Session["TaskControl"];
        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;


        if (taskControl.FinancialID != 0)
        {
            //ddlFinancial0.SelectedIndex = ddlFinancial0.Items.IndexOf(
            //    ddlFinancial0.Items.FindByValue(taskControl.FinancialID.ToString()));

            ddlFinancial.SelectedIndex = ddlFinancial.Items.IndexOf(
                ddlFinancial.Items.FindByValue(taskControl.FinancialID.ToString()));

            DataTable tmpDt = GetFinancialPhoneNo(taskControl.FinancialID);

            txtFinancialPhoneNo.Text = tmpDt.Rows[0]["FinancialPhoneNo"].ToString();
        }

        if (taskControl.Agency != "0")
            ddlAgency.SelectedIndex = ddlAgency.Items.IndexOf(
                ddlAgency.Items.FindByValue(taskControl.Agency));

        if (taskControl.Agent != "0")
            ddlAgent.SelectedIndex = ddlAgent.Items.IndexOf(
                ddlAgent.Items.FindByValue(taskControl.Agent));

        if(taskControl.Customer.Initial != "")
        txtCustomerName.Text = taskControl.Customer.FirstName + " " + taskControl.Customer.Initial + ". " + 
            taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2;
        else
            txtCustomerName.Text = taskControl.Customer.FirstName + " " +
            taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2;

        if (taskControl.PolicyType.Trim() != "CP" && taskControl.PolicyType.Trim() != "CE" && taskControl.PolicyType.Trim() != "APC" && taskControl.PolicyType.Trim() != "AEC")
        {
            if (taskControl.Customer.Sex == "M")
                txtCustomerName.Text = "DR. " + txtCustomerName.Text;
            else
                txtCustomerName.Text = "DRA. " + txtCustomerName.Text;
        }

        txtPolicyNo.Text = taskControl.PolicyType.Trim() +"-" + taskControl.PolicyNo.Trim();

        txtEffDate.Text = taskControl.EffectiveDate;

        txtTotalToPay.Text = (taskControl.TotalPremium + taskControl.Charge).ToString();

        DataTable dt = GetFinancialContract(taskControl.TaskControlID);

        if (dt.Rows.Count > 0)
        {
            txtContractNo.Text = dt.Rows[0]["ContractNo"].ToString();
            txtInstallmentNum.Text = dt.Rows[0]["FinancialInstallments"].ToString();
            txtPayment.Text = dt.Rows[0]["FinancialDownPayment"].ToString();
            txtFinancialPhoneNo.Text = dt.Rows[0]["FinancialPhoneNumber"].ToString();
            txtEffDate.Text = dt.Rows[0]["FinancialEffDate"].ToString();
            txtTotalToPay.Text = dt.Rows[0]["FinancialTotalToPay"].ToString();
            txtPolicyNo.Text = dt.Rows[0]["FinancialPolicyNo"].ToString();
            if(txtTotalToPay.Text != "" && txtPayment.Text != "")
                txtRemainingBalance.Text = (float.Parse(txtTotalToPay.Text) - float.Parse(txtPayment.Text)).ToString("###,###.00");
        }

        dt = GetFinancialCancellations(taskControl.TaskControlID);


 
        if (dt.Rows.Count != 0)
        {
            lblPendingItems.Visible = true;
            grdPendingItems.Visible = true;

            grdPendingItems.DataSource = dt;
            grdPendingItems.DataBind();

            if (!cp.IsInRole("ADMINISTRATOR"))
            {
                grdPendingItems.Columns[11].Visible = false;
            }

            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(
                ddlStatus.Items.FindByValue(dt.Rows[dt.Rows.Count - 1]["FinancialCancellationsType"].ToString()));

            if (ddlStatus.SelectedItem.Value == "R")
            {
                btnNew.Visible = true;
                btnReinst.Visible = false;
            }
            else
            {
                btnNew.Visible = false;
                btnReinst.Visible = true;
            }
        }
        else
        {
            lblPendingItems.Visible = true;
            grdPendingItems.Visible = false;
        }

        Session.Remove("DtHistory");
        Session.Add("DtHistory", dt);



        //if (dt.Rows.Count != 0)
        //{
        //    lblHistory.Visible = true;
        //    grdAuditItems.Visible = true;

        //    grdAuditItems.DataSource = dt;
        //    grdAuditItems.DataBind();


        //}
        //else
        //{
        //    lblHistory.Visible = false;
        //    grdAuditItems.Visible = false;
        //}

        //txtBalance.Text =((taskControl.TotalPremium - taskControl.PaidAmount)).ToString("$####.00");

        //if ((taskControl.TotalPremium - taskControl.PaidAmount) < 0) //Overpayed
        //    txtBalance.Text = "$0.00";

    }

    public void grdAuditItems_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        Policy taskControl = (Policy)Session["TaskControl"];
        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        int userID = 0;
        userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

        if (e.CommandName == "Select") // Select
        {
            //ddlFinancial.Enabled = false;
            //ddlFinancial.SelectedIndex = ddlFinancial.Items.IndexOf(
            //    ddlFinancial.Items.FindByText(e.Item.Cells[4].Text));

            //txtContractNo.Enabled = false;
            //txtContractNo.Text = e.Item.Cells[8].Text;

            //txtFinancialPhoneNo.Enabled = false;    
            //txtFinancialPhoneNo.Text = e.Item.Cells[9].Text;

            //if (e.Item.Cells[11].Text == "True")
            //{
            //    chkExpTerms.Checked = true;
            //    lblEntryDate.Text = "Expired Term*";
            //}
            //else
            //{
            //    chkExpTerms.Checked = false ;
            //    lblEntryDate.Text = "Balance*";
            //}

            //chkEnable.Checked = false;
            //txtPolicyNo.Text = e.Item.Cells[12].Text;

            pnlCancellations.Visible = true;   

            txtInstallment.Enabled = false;
            txtInstallment.Text = e.Item.Cells[4].Text;

            txtDate.Enabled = false;
            txtDate.Text = e.Item.Cells[3].Text;

            txtBalance.Enabled = false;
            txtBalance.Text = e.Item.Cells[5].Text;

            txtComments.Text = e.Item.Cells[6].Text;
            txtComments.Enabled = false;
            //oldComments = e.Item.Cells[6].Text + " - " + EPolicy.Audit.History.ObtainUser();

            financialCancellationID = int.Parse(e.Item.Cells[1].Text);
            lblSelectedID.Text = financialCancellationID.ToString();
            financialCancellationType = e.Item.Cells[2].Text.Substring(0, 1);
            lblSelectedType.Text = financialCancellationType;

            //if (e.Item.Cells[10].Text != userID.ToString())
            //    btnModify.Enabled = false;
        }
        else if (e.CommandName == "Edit") // Select
        {
            //ddlFinancial.Enabled = false;
            //ddlFinancial.SelectedIndex = ddlFinancial.Items.IndexOf(
            //    ddlFinancial.Items.FindByText(e.Item.Cells[4].Text));

            //txtContractNo.Enabled = false;
            //txtContractNo.Text = e.Item.Cells[8].Text;

            //txtFinancialPhoneNo.Enabled = false;    
            //txtFinancialPhoneNo.Text = e.Item.Cells[9].Text;

            //if (e.Item.Cells[11].Text == "True")
            //{
            //    chkExpTerms.Checked = true;
            //    lblEntryDate.Text = "Expired Term*";
            //}
            //else
            //{
            //    chkExpTerms.Checked = false ;
            //    lblEntryDate.Text = "Balance*";
            //}

            //chkEnable.Checked = false;
            //txtPolicyNo.Text = e.Item.Cells[12].Text;

            pnlCancellations.Visible = true;

            txtInstallment.Enabled = true;
            txtInstallment.Text = e.Item.Cells[4].Text;

            txtDate.Enabled = true;
            txtDate.Text = e.Item.Cells[3].Text;

            txtBalance.Enabled = true;
            txtBalance.Text = e.Item.Cells[5].Text;

            txtComments.Text = e.Item.Cells[6].Text;
            txtComments.Enabled = true;
            //oldComments = e.Item.Cells[6].Text + " - " + EPolicy.Audit.History.ObtainUser();

            financialCancellationID = int.Parse(e.Item.Cells[1].Text);
            lblSelectedID.Text = financialCancellationID.ToString();
            financialCancellationType = e.Item.Cells[2].Text.Substring(0, 1);
            lblSelectedType.Text = financialCancellationType;

            btnNew.Visible = false;
            btnModify.Visible = false;
            btnReinst.Visible = false;
            btnPrint.Visible = false;
            btnSave.Visible = true;
            BtnCancel.Visible = true;
            BtnExit.Visible = false;

            if (e.Item.Cells[9].Text != userID.ToString())
                btnModify.Enabled = false;
        }
        else if (e.CommandName.ToString() == "Delete")
        {
            int i = int.Parse(e.Item.Cells[1].Text);
            DeleteFinancialCancellation(i);

            DataTable dt = GetFinancialContract(taskControl.TaskControlID);

            dt = GetFinancialCancellations(taskControl.TaskControlID);


            if (dt.Rows.Count != 0)
            {
                lblPendingItems.Visible = true;
                grdPendingItems.Visible = true;

                grdPendingItems.DataSource = dt;
                grdPendingItems.DataBind();

                ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(
                    ddlStatus.Items.FindByValue(dt.Rows[dt.Rows.Count - 1]["FinancialCancellationsType"].ToString()));
            }
        }
                
        else  // Pager
        {
            grdPendingItems.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

            grdPendingItems.DataSource = (DataTable)Session["DtHistory"];
            grdPendingItems.DataBind();
        }
    }

    public DataTable DeleteFinancialCancellation(int FinancialCancellationsID)
    {
        DataTable dt = null;


            DbRequestXmlCookRequestItem[] cookItems = new DbRequestXmlCookRequestItem[1];
            DbRequestXmlCooker.AttachCookItem("FinancialCancellationsID", SqlDbType.Int, 0, FinancialCancellationsID.ToString(), ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;
            xmlDoc = DbRequestXmlCooker.Cook(cookItems);

            dt = exec.GetQuery("DeleteFinancialCancellations", xmlDoc);
            return dt;
        
        return dt;
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        int userID = 0;
        userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

        if (!pnlCancellations.Visible)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Please select an entry.");
            this.litPopUp.Visible = true;
        }
        else if (lblSelectedType.Text != "R")
        {
            if (ddlFinancial.SelectedItem.Text == String.Empty)
            {
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Please provide a Financial Institution.");
                this.litPopUp.Visible = true;
                return;
            }

            if (txtFinancialPhoneNo.Text == String.Empty)
            {
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Please provide the Financial Institution's Phone Number.");
                this.litPopUp.Visible = true;
                return;
            }

            if (txtContractNo.Text == String.Empty)
            {
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Please provide a Contract Number.");
                this.litPopUp.Visible = true;
                return;
            }
            double tempResult = 0.0;

            if (txtBalance.Text == String.Empty || !double.TryParse(txtBalance.Text.Replace("$", ""), out tempResult))
            {
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Please provide a valid balance.");
                this.litPopUp.Visible = true;
                return;
            }

            Policy taskControl = (Policy)Session["TaskControl"];
            string finalFile = String.Empty;

            string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];
            //List<string> mergePaths = new List<string>();
            ReportViewer viewer = new ReportViewer();
            viewer.LocalReport.DataSources.Clear();
            viewer.ProcessingMode = ProcessingMode.Local;

            finalFile = Print();

            if (txtComments.Text.Trim() == String.Empty)
                txtComments.Text = "PRINTED DOCUMENT";

            EPolicy.Audit.History.GetSaveFinancialCancellation(false, 0, taskControl.TaskControlID, ddlFinancial.SelectedItem.Text.Trim(), txtFinancialPhoneNo.Text.Trim(),
                txtContractNo.Text.Trim(), txtBalance.Text.Trim(), DateTime.Now, userID, txtComments.Text.Trim(), "", txtPolicyNo.Text, chkExpTerms.Checked);

            History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED FINANCIAL CANCELLATION.");

            FillTextControl();
            btnNew.Visible = true;
            btnModify.Visible = true;

            ddlFinancial.Enabled = false;
            txtBalance.Enabled = false;
            txtContractNo.Enabled = false;
            txtFinancialPhoneNo.Enabled = false;
            txtComments.Enabled = false;

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + finalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
            return;
        }
        else
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Selected entry is a Reinstatement.");
            this.litPopUp.Visible = true;
        }
    }

    private string Print()
    {
        Policy taskControl = (Policy)Session["TaskControl"];

        try
        {
            ReportViewer viewer = new ReportViewer();
            viewer.LocalReport.ReportPath = Server.MapPath("Reports/CancellationNoticeFinancials.rdlc");
            viewer.LocalReport.DataSources.Clear();
            viewer.ProcessingMode = ProcessingMode.Local;

            ReportParameter rp6 = new ReportParameter(); 
            ReportParameter rp10 = new ReportParameter();

            ReportParameterInfoCollection paramCol = viewer.LocalReport.GetParameters();
            ReportParameter rp1 = new ReportParameter(paramCol[0].Name, ddlFinancial.SelectedItem.Text.Trim());
            ReportParameter rp2 = new ReportParameter(paramCol[1].Name, txtFinancialPhoneNo.Text.Trim());
            ReportParameter rp3 = new ReportParameter(paramCol[2].Name, txtContractNo.Text.Trim());
            ReportParameter rp4 = new ReportParameter(paramCol[3].Name, txtPolicyNo.Text.Trim());
            ReportParameter rp5 = new ReportParameter(paramCol[4].Name, txtEffDate.Text.Trim());
            ReportParameter rp12 = new ReportParameter(paramCol[11].Name, txtDate.Text.Trim());
            rp6 = new ReportParameter(paramCol[5].Name, txtCustomerName.Text.Trim());

            if (!txtBalance.Text.Contains("."))
                txtBalance.Text += ".00";

            txtBalance.Text = double.Parse(txtBalance.Text.Replace("$","")).ToString("$###,##0.00");

            ReportParameter rp7 = new ReportParameter(paramCol[6].Name, txtBalance.Text.Trim());
            ReportParameter rp8 = new ReportParameter(paramCol[7].Name, ddlAgency.SelectedItem.Text.Trim());
            ReportParameter rp9 = new ReportParameter(paramCol[8].Name, ddlAgent.SelectedItem.Text.Trim());
            

            if(chkExpTerms.Checked)
                rp10 = new ReportParameter(paramCol[9].Name, "Balance Plazos Vencidos: ");
            else
                rp10 = new ReportParameter(paramCol[9].Name, "Balance Pendiente de Pago: ");

            ReportParameter rp11 = new ReportParameter(paramCol[10].Name, taskControl.InsuranceCompany);

            viewer.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12});
            viewer.LocalReport.Refresh();

            // Variables 
            Warning[] warnings;
            string[] streamIds;
            string mimeType;
            string encoding = string.Empty;
            string extension;
            string fileName = "Financial Cancellation " + taskControl.PolicyType.Trim() + "-" + taskControl.PolicyNo.Trim();
            string _FileName = "Financial Cancellation " + taskControl.PolicyType.Trim() + "-" + taskControl.PolicyNo.Trim() + ".pdf";
            //Ññ
            if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

            byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }

            //CreatePDFBatch pdfbatch = new CreatePDFBatch();
            //string reportList = pdfbatch.AppendTextToPDF(SetContractNoArray(), "Ciudad Jardin", "Calle Cundeamor #168", "Gurabo, P.R. 00778",
            //System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, ddlMedico.SelectedItem.Text.Trim());

            //string onlyFileName = System.IO.Path.GetFileName(reportList);
            return _FileName;
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('Processed/" + onlyFileName + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
        }
        catch (Exception ecp)
        {
            throw new Exception(ecp.Message);
        }
    }

    protected void BtnExit_Click(object sender, EventArgs e)
    {
        Session.Remove("FromUI");
        Session.Remove("CancellationEdit");
        ReturnToReferringPage();
    }

    private void SetReferringPage()
    {
        if ((Session["FromUI"] != null) && (Session["FromUI"].ToString() != ""))
        {
            this.ReferringPage = Session["FromUI"].ToString();
            //Session.Remove("FromUI");
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

    protected void btnNew_Click(object sender, EventArgs e)
    {
        financialCancellationType = "C";
        
        btnNew.Visible = false;
        btnReinst.Visible = false;
        btnSave.Visible = false;
        btnModify.Visible = false;
        BtnCancel.Visible = true;
        btnPrint.Visible = false;
        btnSave.Visible = true;
        BtnCancel.Visible = true;

        pnlCancellations.Visible = true;

        txtDate.Enabled = true;
        txtInstallment.Enabled = true;
        txtBalance.Enabled = true;
        txtComments.Enabled = true;

        //txtBalance.Enabled = true;
        //txtBalance.Text = String.Empty;

        //txtFinancialPhoneNo.Enabled = true;
        //txtFinancialPhoneNo.Text = String.Empty;

        //txtContractNo.Enabled = true;
        //txtContractNo.Text = String.Empty;

        //ddlFinancial.Enabled = true;
        //ddlFinancial.SelectedIndex = -1;

        //txtComments.Text = String.Empty;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
        try
        {
            Policy taskControl = (Policy)Session["TaskControl"];

            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
            int userID = 0;
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

            EPolicy.Audit.History.GetSaveFinancialCancellation(true, financialCancellationID, taskControl.TaskControlID, ddlFinancial.SelectedItem.Text.Trim(), txtFinancialPhoneNo.Text.Trim(),
               txtContractNo.Text.Trim(), txtBalance.Text.Trim(), DateTime.Now, userID, oldComments, txtComments.Text.Trim(), txtPolicyNo.Text,chkExpTerms.Checked);

            if (pnlCancellations.Visible == false)
            {
                Executor.BeginTrans();
                Executor.Insert("AddFinancialContract", this.GetInsertFinancialContract());
                Executor.CommitTrans();

                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Financial Contract saved successfully.");
                this.litPopUp.Visible = true;

                //ddlFinancial0.SelectedIndex = ddlFinancial0.Items.IndexOf(
                //ddlFinancial0.Items.FindByText(ddlFinancial.SelectedItem.Text));              

                taskControl.FinancialID = int.Parse(ddlFinancial.SelectedItem.Value);

                //if(taskControl.PolicyType.Trim() == "PP" || taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "AAP" || taskControl.PolicyType.Trim() == "AAE")
                //taskControl.SavePol(userID);

                UpdatePolicyFinancial(taskControl.TaskControlID, taskControl.FinancialID);
                //else
                //    taskControl.SaveCorporatePolicy(userID);
            }
            else
            {
                Executor.BeginTrans();
                Executor.Insert("AddFinancialCancellations", this.GetInsertFinancialCancellations());
                Executor.CommitTrans();

                txtComments.Text = "";
                txtBalance.Text = "";
                txtDate.Text = "";
                txtInstallment.Text = "";
                lblSelectedID.Text = "0";

                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Information saved successfully.");
                this.litPopUp.Visible = true;
            }

            FillTextControl();
            btnNew.Visible = true;
            btnModify.Visible = true;
            btnSave.Visible = false;
            BtnCancel.Visible = false;
            btnPrint.Visible = true;
            BtnExit.Visible = true;

            DisableControls();


            ddlFinancial.Enabled = false;
            txtBalance.Enabled = false;
            txtContractNo.Enabled = false;
            txtFinancialPhoneNo.Enabled = false;
            txtComments.Enabled = false;

            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Information saved successfully.");
            this.litPopUp.Visible = true;
        }
        catch (Exception ex)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString(ex.Message);
            this.litPopUp.Visible = true;

        }

    }
    private void UpdatePolicyFinancial(int taskControlID, int financialID)
    {
        DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[2];

        DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, taskControlID.ToString(), ref cookItems);
        DbRequestXmlCooker.AttachCookItem("FinancialID", SqlDbType.Int, 0, financialID.ToString(), ref cookItems);

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
            exec.Update("UpdatePolicyFinancialByTaskControlID", xmlDoc);
        }
        catch (Exception ex)
        {
            this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Could not update Policy Financial.");
            this.litPopUp.Visible = true;
        }
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
        btnNew.Visible = false;
        btnSave.Visible = true;
        BtnCancel.Visible = true;
        btnPrint.Visible = false;
        btnModify.Visible = false;
        btnReinst.Visible = false;
        txtComments.Enabled = false;
        chkEnable.Visible = true;

        ddlFinancial.Enabled = true;
        txtFinancialPhoneNo.Enabled = true;
        txtContractNo.Enabled = true;
        //txtPolicyNo.Enabled = true;
        txtInstallmentNum.Enabled = true;
        txtPayment.Enabled = true;
        txtEffDate.Enabled = true;
        txtTotalToPay.Enabled = true;
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        DisableControls();

        btnNew.Visible = true;
        btnReinst.Visible = true;
        btnModify.Visible = true;
        btnPrint.Visible = true;
        BtnExit.Visible = true;

        txtComments.Text = "";
        txtBalance.Text = "";
        txtDate.Text = "";
        txtInstallment.Text = "";
        txtRemainingBalance.Text = "";
        txtPayment.Text = "";
        lblSelectedID.Text = "0";

        FillDDLControls();
        FillTextControl();

        //if (txtBalance.Text == String.Empty || txtContractNo.Text == String.Empty || txtFinancialPhoneNo.Text == String.Empty ||
        //    ddlFinancial.SelectedIndex == -1)
        //{
        //    btnModify.Visible = false;
        //    btnPrint.Visible = false;

        //}
    }
    protected void ddlFinancial_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFinancial.SelectedValue != "")
        {
            DataTable tmpDt = GetFinancialPhoneNo(int.Parse(ddlFinancial.SelectedValue));
            txtFinancialPhoneNo.Text = tmpDt.Rows[0]["FinancialPhoneNo"].ToString();
        }
    }
    protected void chkExpTerms_CheckedChanged(object sender, EventArgs e)
    {
        if (chkExpTerms.Checked)
            lblEntryDate.Text = "Expired Term*";
        else
            lblEntryDate.Text = "Balance*";
    }
    protected void chkEnable_CheckedChanged(object sender, EventArgs e)
    {
        EPolicy.TaskControl.Policy taskControl = (EPolicy.TaskControl.Policy)Session["TaskControl"];

        if (chkEnable.Checked)
        {
            txtPolicyNo.Enabled = true;
            txtTotalToPay.Enabled = true;
            txtTotalToPay.Text = "0";
            txtRemainingBalance.Text = "";
        }
        else
        {
            txtPolicyNo.Enabled = false;
            txtTotalToPay.Text = (taskControl.TotalPremium + taskControl.Charge).ToString();

            if (txtPayment.Text != "")
                txtRemainingBalance.Text = (float.Parse((taskControl.TotalPremium + taskControl.Charge).ToString()) - float.Parse(txtPayment.Text)).ToString();
        }
    }

    private XmlDocument GetInsertFinancialContract()
    {
        EPolicy.TaskControl.TaskControl taskControl = (EPolicy.TaskControl.TaskControl)Session["TaskControl"];

        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;

        int userID = 0;
        if (cp != null)
        {
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
        }

        DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[9];

        DbRequestXmlCooker.AttachCookItem("TaskControlID",
            SqlDbType.Int, 0, taskControl.TaskControlID.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("ContractNo",
            SqlDbType.VarChar, 20, txtContractNo.Text,
            ref cookItems);

        DataTable dtFinancial = EPolicy.LookupTables.LookupTables.GetTable("Financial");
        int financialID = 0;

        for (int i = 0; i < dtFinancial.Rows.Count; i++)
        {
            if (dtFinancial.Rows[i][1].ToString() == ddlFinancial.SelectedItem.Text)
            {
                financialID = int.Parse(dtFinancial.Rows[i][0].ToString());
                break;
            }
        }

        DbRequestXmlCooker.AttachCookItem("FinancialID",
            SqlDbType.Int, 0, financialID.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("FinancialInstallments",
                SqlDbType.Int, 0, txtInstallmentNum.Text,
                ref cookItems);

        DbRequestXmlCooker.AttachCookItem("FinancialDownPayment",
            SqlDbType.Float,0, txtPayment.Text,
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("FinancialEffDate",
            SqlDbType.VarChar, 20, txtEffDate.Text,
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("FinancialPhoneNumber",
            SqlDbType.VarChar, 20, txtFinancialPhoneNo.Text,
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("FinancialPolicyNo",
            SqlDbType.VarChar, 1000, txtPolicyNo.Text,
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("FinancialTotalToPay",
            SqlDbType.Float, 0, txtTotalToPay.Text,
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

    private XmlDocument GetInsertFinancialCancellations()
    {
        EPolicy.TaskControl.TaskControl taskControl = (EPolicy.TaskControl.TaskControl)Session["TaskControl"];

        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;

        int userID = 0;
        if (cp != null)
        {
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
        }

        DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[8];

        DbRequestXmlCooker.AttachCookItem("FinancialCancellationsID",
            SqlDbType.Int, 0, lblSelectedID.Text,
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("FinancialCancellationsDate",
            SqlDbType.VarChar, 20, txtDate.Text,
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("FinancialCancellationsInstallment",
                SqlDbType.VarChar, 10, txtInstallment.Text,
                ref cookItems);

        DbRequestXmlCooker.AttachCookItem("FinancialCancellationsType",
                SqlDbType.Char, 1, financialCancellationType,
                ref cookItems);

        DbRequestXmlCooker.AttachCookItem("FinancialCancellationsBalance",
            SqlDbType.Float, 0, txtBalance.Text,
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("FinancialCancellationsComments",
            SqlDbType.VarChar, 1000, txtComments.Text,
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

    protected DataTable GetFinancialContract(int TaskControlID)
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

        DataTable dt = exec.GetQuery("GetFinancialContractByTaskControlID", xmlDoc);
        return dt;
    }

    protected DataTable GetFinancialPhoneNo(int FinancialID)
    {
        DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[1];

        DbRequestXmlCooker.AttachCookItem("FinancialID",
            SqlDbType.Int, 0, FinancialID.ToString(),
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

        DataTable dt = exec.GetQuery("GetFinancialPhoneNoByFinancialID", xmlDoc);
        return dt;
    }

    protected void btnReinst_Click(object sender, EventArgs e)
    {
        try
        {
            if(!pnlCancellations.Visible)
                throw new Exception("Please select a cancellation.");

            if(lblSelectedType.Text == "R")
                throw new Exception("Selected entry is a Reinstatement.");

            if (ddlStatus.SelectedItem.Text == "Pending Cancellation")
            {
                financialCancellationType = "R";
                lblSelectedType.Text = financialCancellationType;
                financialCancellationID = 0;
                lblSelectedID.Text = financialCancellationID.ToString();

                btnNew.Visible = false;
                btnReinst.Visible = false;
                btnSave.Visible = false;
                btnModify.Visible = false;
                BtnCancel.Visible = true;
                btnPrint.Visible = false;
                btnSave.Visible = true;
                BtnCancel.Visible = true;

                pnlCancellations.Visible = true;

                txtDate.Enabled = true;
                txtInstallment.Enabled = false;
                txtBalance.Enabled = false;
                txtComments.Enabled = true;

                //txtBalance.Enabled = true;
                //txtBalance.Text = String.Empty;

                //txtFinancialPhoneNo.Enabled = true;
                //txtFinancialPhoneNo.Text = String.Empty;

                //txtContractNo.Enabled = true;
                //txtContractNo.Text = String.Empty;

                //ddlFinancial.Enabled = true;
                //ddlFinancial.SelectedIndex = -1;

                //txtComments.Text = String.Empty;
            }
            else
            {
                throw new Exception("Financial Contract is not cancelled.  Please verify.");
            }
        }
        catch (Exception ex)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString(ex.Message);
            this.litPopUp.Visible = true;

        }
    }
    protected void txtRemainingBalance_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtPayment_TextChanged(object sender, EventArgs e)
    {
        Policy taskControl = (Policy)Session["TaskControl"];
        float output = 0;

        if (float.TryParse(txtPayment.Text, out output) && float.TryParse(txtTotalToPay.Text, out output))
            txtRemainingBalance.Text = (float.Parse(txtTotalToPay.Text) - float.Parse(txtPayment.Text)).ToString("###,###.00");
        else
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Invalid or missing payment amount detected.");
            this.litPopUp.Visible = true;
            txtPayment.Text = "";
        }
    }
    protected DataTable GetFinancialCancellations(int TaskControlID)
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

        DataTable dt = exec.GetQuery("GetFinancialCancellationsByTaskControlID", xmlDoc);
        return dt;
    }

    private void History(int taskControlID, int userID, string action, string subject, string note)
    {
        EPolicy.Audit.History history = new EPolicy.Audit.History();
        EPolicy.TaskControl.Policy taskControl = (EPolicy.TaskControl.Policy)Session["TaskControl"];

        history.Actions = action;
        history.KeyID = taskControlID.ToString();
        history.Subject = subject;
        //history.BuildNotesForHistory("TaskControlID.", "", taskControlID.ToString(), 7);  //7 = mode NOTICEOFCANC
        history.UsersID = userID;
        history.Notes = note + "\r\n";
        history.GetSaveHistory();
    }
    protected void txtPayment_TextChanged1(object sender, EventArgs e)
    {

    }
    protected void btnAvisoCanc_Click(object sender, EventArgs e)
    {
        EPolicy.TaskControl.Policy taskControl = (EPolicy.TaskControl.Policy)Session["TaskControl"];

        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        int userID = 0;
        userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]); 

        DataTable dtCertLocHist = Policy.GetCertificateHistoryForTable(taskControl.PolicyType, taskControl.PolicyNo);
        List<string> verifyLocation = new List<string>();

        try
        {
            string FinalFile = "";
            for (int i = 0; i < dtCertLocHist.Rows.Count; i++)
            {
                string email1 = dtCertLocHist.Rows[i]["CertificateLocationEmail"].ToString().Trim();
                string email2 = dtCertLocHist.Rows[i]["CertificateLocationEmail2"].ToString().Trim();
                string email3 = dtCertLocHist.Rows[i]["CertificateLocationEmail3"].ToString().Trim();
                string certificateLocation = dtCertLocHist.Rows[i]["CertificateLocationDesc"].ToString().Trim();
                
                List<string> emailList = new List<string>();
                emailList.Add(email1);
                emailList.Add(email2);
                emailList.Add(email3);

                if (email1 == "")
                    emailList.Remove(email1);
                if (email2 == "")
                    emailList.Remove(email2);
                if (email3 == "")
                    emailList.Remove(email3);

                if (emailList.Count != 0)
                    Session.Add("ListCount", emailList.Count);

                List<string> mergePaths = new List<string>();
                string ProcessedPath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"];
                EPolicy2.Reports.ExportFile expFile = new EPolicy2.Reports.ExportFile();
                string _FileName = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"];

                if (emailList.Count != 0)
                {
                    mergePaths.Add(PrintAvisoCanc("AvisoCancelacion.rdlc", certificateLocation));

                    string NameFile = "AvisoDeCancelación" + taskControl.TaskControlID.ToString() + "-" + i.ToString();
                    EPolicy.CreatePDFBatch mergeFinal = new EPolicy.CreatePDFBatch();

                    FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, NameFile);

                    string emailNoreplay = System.Configuration.ConfigurationManager.AppSettings["EmailNotice"].ToString().Trim();

                    string msg = "";

                    MailNew SM = new MailNew();
                    SM.MailSubject = "Aviso de Cancelación";

                    SM.MailFrom = emailNoreplay;

                    SM.MailBody = "";

                    SM.MailToCollection2 = emailList;//Email.Trim();

                    try
                    {
                        msg = SM.SendHTMLMailNewRegister(1, emailList, FinalFile);
                        HistoryForTable(taskControl.TaskControlID, userID, dtCertLocHist.Rows[i]["CertificateLocationDesc"].ToString(), emailList.Count);
                        SaveCancellationNotice(dtCertLocHist.Rows[i]["CertificateHistoryID"].ToString(), taskControl.TaskControlID, dtCertLocHist.Rows[i]["CertificateLocationDesc"].ToString(), email1, email2, email3, msg);
                        UpdateCertificateHistoryForTale(msg, taskControl.TaskControlID);
                    }
                    catch
                    {
                        verifyLocation.Add(certificateLocation);
                    }
                    
                }


            }

            if (int.Parse(Session["ListCount"].ToString()) != 0)
            {
                string popUpString = "";

                if (verifyLocation.Count > 0)
                {
                    foreach (string message in verifyLocation)
                    {
                        popUpString += message + " ";
                    }
                }

                if (popUpString == "")
                    popUpString = "N/A";
               
                lblRecHeader.Text = "Success! To verify your report go to: " + "\r\n"
                    + "Reports tab ->" + "Cancellation Notice" + "\r\n"
                    + "Error Emails to: " + popUpString;
                mpeSeleccion.Show();
            }
        }
        catch(Exception xp)
        {
            lblRecHeader.Text = "Error while sending emails. Check if the Certificate Location(s) have valid email(s).";
            mpeSeleccion.Show();
        }
    }
    private string PrintAvisoCanc(string rdlcDoc, string certLocation)
    {
        try
        {
            EPolicy.TaskControl.Policy taskControl = (EPolicy.TaskControl.Policy)Session["TaskControl"];
            ReportViewer viewer = new ReportViewer();
            string ProcessedPath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"];

            viewer.LocalReport.DataSources.Clear();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = Server.MapPath("Reports/" + rdlcDoc);

            if (rdlcDoc == "AvisoCancelacion.rdlc")
            {
                ReportParameter[] param = new ReportParameter[5];
                param[0] = new ReportParameter("PolicyNo", taskControl.PolicyType.ToString() + " " + taskControl.PolicyNo.ToString());
                param[1] = new ReportParameter("EffectiveDate", taskControl.EffectiveDate.ToString());
                param[2] = new ReportParameter("CustomerName", taskControl.Customer.FirstName + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2);
                param[3] = new ReportParameter("CancellationDate", taskControl.CancellationEntryDate.ToString());
                param[4] = new ReportParameter("CertificateLocationDesc", certLocation.ToUpper());
                viewer.LocalReport.SetParameters(param);
                viewer.LocalReport.Refresh();
            }
            Warning[] warnings;
            string[] streamIds;
            string mimeType;
            string encoding = string.Empty;
            string extension;

            string _FileName = rdlcDoc + certLocation + ".pdf";

            if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

            byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
                //fs.Close();
            }
            Session.Add("PDFPath", _FileName);
            return ProcessedPath + _FileName;
           
        }
        catch
        {
            return "";
        }
    }
    public static void SaveCancellationNotice(string certID, int taskControlID, string cartLocDesc,string email1, string email2,string email3 , string msg)
    {
        DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[7];

        DbRequestXmlCooker.AttachCookItem("CertificateHistoryID",
            SqlDbType.VarChar, 5, certID.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("TaskControlID",
            SqlDbType.Int, 0, taskControlID.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("CertificateLocationDesc",
            SqlDbType.VarChar, 100, cartLocDesc.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Email1",
            SqlDbType.VarChar, 50, email1.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Email2",
            SqlDbType.VarChar, 50, email2.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Email3",
            SqlDbType.VarChar, 50, email3.ToString(),
            ref cookItems);

        string sent = "";

        if (msg == "0001")
            sent = "true";
        else
            sent = "false";

        DbRequestXmlCooker.AttachCookItem("Sent",
            SqlDbType.VarChar, 50, sent.ToString(),
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

        Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

        exec.Insert("AddCancellationNotice", xmlDoc);
    }
    public static void UpdateCancellationNotice(int certID, string email1, string email2, string email3, string certLocDesc, string msg)
    {
        DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[6];

        DbRequestXmlCooker.AttachCookItem("CertificateHistoryID",
            SqlDbType.Int, 0, certID.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("email1",
           SqlDbType.VarChar, 50, email1.ToString(),
           ref cookItems);
        DbRequestXmlCooker.AttachCookItem("email2",
          SqlDbType.VarChar, 50, email2.ToString(),
          ref cookItems);
        DbRequestXmlCooker.AttachCookItem("email3",
          SqlDbType.VarChar, 50, email3.ToString(),
          ref cookItems);
        DbRequestXmlCooker.AttachCookItem("certLocDesc",
         SqlDbType.VarChar, 50, certLocDesc.ToString(),
         ref cookItems);

        bool sent;

        if (msg == "0001")
            sent = true;
        else
            sent = false;

        DbRequestXmlCooker.AttachCookItem("Sent",
            SqlDbType.Bit, 0, sent.ToString(),
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

        Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

        exec.Insert("UpdateCancellationNotice", xmlDoc);
    }
    public static void UpdateCertificateHistoryForTale(string msg, int taskControlID)
    {
        DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[2];

        string sent = "";

        if (msg == "0001")
            sent = "true";
        else
            sent = "false";

        DbRequestXmlCooker.AttachCookItem("Sent",
            SqlDbType.VarChar, 50, sent.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("TaskControlID",
            SqlDbType.Int, 0, taskControlID.ToString(),
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

        Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

        exec.Update("UpdateCertificateHistoryForTable", xmlDoc);
    }
    private void HistoryForTable(int taskControlID, int userID, string certLoc, int emailCountt)
    {
        History history = new History();
        EPolicy.TaskControl.Policy taskControl = (EPolicy.TaskControl.Policy)Session["TaskControl"];
       // DataTable historyDt = Policy.GetCertificateHistoryByTaskControlID(taskControl.TaskControlID);
        string subject;

        history.Actions = "PRINT";
        subject = "PRINT NOTICE CANC. " + "\r\n"
                + "EMAILS SENT:" + emailCountt + "\r\n"
                + "CERT. LOCATION: " + certLoc.Trim() + "\r\n";
                
        history.KeyID = taskControlID.ToString();
        history.Subject = "POLICIES";
        //history.BuildNotesForHistory("TaskControlID.", "", taskControlID.ToString(), 7);  //7 = mode NOTICEOFCANC
        history.UsersID = userID;
        history.Notes = "[CERTIFICATE] " + subject + "\r\n";
        history.GetSaveHistory();
    }


    protected void grdCancNotice_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        EPolicy.TaskControl.Policy taskControl = (EPolicy.TaskControl.Policy)Session["TaskControl"];
        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        int userID = 0;
        userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]); 

        int CertLocationID = int.Parse(e.Item.Cells[0].Text.ToString());
        DataTable dt = GetIndividualCertificateLocationForEmail(CertLocationID);
        List<string> verifyLocation = new List<string>();

        try
        {
            if (dt.Rows.Count > 0)
            {
                string FinalFile = "";

                string email1 = dt.Rows[0]["CertificateLocationEmail"].ToString().Trim();
                string email2 = dt.Rows[0]["CertificateLocationEmail2"].ToString().Trim();
                string email3 = dt.Rows[0]["CertificateLocationEmail3"].ToString().Trim();
                string certificateLocation = dt.Rows[0]["CertificateLocationDesc"].ToString().Trim();

                List<string> emailList = new List<string>();
                emailList.Add(email1);
                emailList.Add(email2);
                emailList.Add(email3);

                if (email1 == "")
                    emailList.Remove(email1);
                if (email2 == "")
                    emailList.Remove(email2);
                if (email3 == "")
                    emailList.Remove(email3);

                if (emailList.Count != 0)
                    Session.Add("ListCount", emailList.Count);

                List<string> mergePaths = new List<string>();
                string ProcessedPath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"];
                EPolicy2.Reports.ExportFile expFile = new EPolicy2.Reports.ExportFile();
                string _FileName = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"];

                if (emailList.Count != 0)
                {
                    mergePaths.Add(PrintAvisoCanc("AvisoCancelacion.rdlc", certificateLocation));

                    string NameFile = "AvisoDeCancelación" + taskControl.TaskControlID.ToString();
                    EPolicy.CreatePDFBatch mergeFinal = new EPolicy.CreatePDFBatch();

                    FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, NameFile);

                    string emailNoreplay = System.Configuration.ConfigurationManager.AppSettings["EmailNotice"].ToString().Trim();

                    string msg = "";

                    MailNew SM = new MailNew();
                    SM.MailSubject = "Aviso de Cancelación";

                    SM.MailFrom = emailNoreplay;

                    SM.MailBody = "";

                    SM.MailToCollection2 = emailList;//Email.Trim();

                    try
                    {
                        msg = SM.SendHTMLMailNewRegister(1, emailList, FinalFile);
                        HistoryForTable(taskControl.TaskControlID, userID, dt.Rows[0]["CertificateLocationDesc"].ToString(), emailList.Count);
                        UpdateCancellationNotice(CertLocationID, email1, email2, email3, certificateLocation,  msg);
                        UpdateCertificateHistoryForTale(msg, taskControl.TaskControlID);
                    }
                    catch
                    {
                        verifyLocation.Add(certificateLocation);
                    }

                }
                if (int.Parse(Session["ListCount"].ToString()) != 0)
                {
                    string popUpString = "";

                    if (verifyLocation.Count > 0)
                    {
                        foreach (string message in verifyLocation)
                        {
                            popUpString += message + " ";
                        }
                    }

                    if (popUpString == "")
                        popUpString = "N/A";

                    lblRecHeader.Text = "Success! To verify your report go to: " + "\r\n"
                        + "Reports tab ->" + "Cancellation Notice" + "\r\n"
                        + "Error Emails to: " + popUpString;
                    mpeSeleccion.Show();
                }
            }
        }
        catch (Exception xp)
        {
            lblRecHeader.Text = "Error while sending emails. Check if the Certificate Location have valid email(s).";
            mpeSeleccion.Show();
        }
        
    }
    private DataTable GetIndividualCertificateLocationForEmail(int certLocationID)
    {
        DataTable dt;

        DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[1];

      

        DbRequestXmlCooker.AttachCookItem("CertificateHistoryID",
            SqlDbType.Int, 0, certLocationID.ToString(),
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

        Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

       dt = exec.GetQuery("GetIndividualCertificateLocation", xmlDoc);

        return dt;
    }
    protected void btnPrintAll_Click(object sender, EventArgs e)
    {
        EPolicy.TaskControl.Policy taskControl = (EPolicy.TaskControl.Policy)Session["TaskControl"];
        List<string> mergePaths = new List<string>();
        string ProcessedPath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"];
        EPolicy2.Reports.ExportFile expFile = new EPolicy2.Reports.ExportFile();
        string _FileName = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"];

        DataTable dt = GetNoticeCancellationByTaskControlID(taskControl.TaskControlID);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                mergePaths.Add(PrintAvisoCancByTaskControlID("AvisoCancelacion.rdlc", dt.Rows[i]));
            }

            string NameFile = "AvisosDeCancelacion" + dt.Rows[0]["TaskControlID"].ToString();
            EPolicy.CreatePDFBatch mergeFinal = new EPolicy.CreatePDFBatch();
            string FinalFile = "";

            FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, NameFile);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
        }
        else
        {
            lblRecHeader.Text = "No cancellation notice have been sent in this policy. Please send a email cancellation notice before the attempt to print.";
            mpeSeleccion.Show();
        }
    }

    private DataTable GetNoticeCancellationByTaskControlID(int tcID)
    {
        DbRequestXmlCookRequestItem[] cookItems = new DbRequestXmlCookRequestItem[1];

        DbRequestXmlCooker.AttachCookItem("TaskControlID",
            SqlDbType.Int, 0, tcID.ToString(),
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

        Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
        DataTable dt = exec.GetQuery("GetCancellationNoticeByTaskControlID", xmlDoc);

        return dt;
    }
    private string PrintAvisoCancByTaskControlID(string rdlcDoc, DataRow dr)
    {
        try
        {
            EPolicy.TaskControl.Policy taskControl = (EPolicy.TaskControl.Policy)Session["TaskControl"];
            ReportViewer viewer = new ReportViewer();
            string ProcessedPath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"];

            viewer.LocalReport.DataSources.Clear();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = Server.MapPath("Reports/" + rdlcDoc);


            if (rdlcDoc == "AvisoCancelacion.rdlc")
            {
                ReportParameter[] param = new ReportParameter[5];
                param[0] = new ReportParameter("PolicyNo", dr["PolicyType"].ToString());
                param[1] = new ReportParameter("EffectiveDate", DateTime.Parse(dr["EffectiveDate"].ToString()).ToShortDateString());
                param[2] = new ReportParameter("CustomerName", dr["CustomerName"].ToString());
                param[3] = new ReportParameter("CancellationDate", dr["CancellationEntryDate"].ToString());
                param[4] = new ReportParameter("CertificateLocationDesc", dr["CertificateLocationDesc"].ToString().ToUpper());

                viewer.LocalReport.SetParameters(param);
                viewer.LocalReport.Refresh();
            }
            Warning[] warnings;
            string[] streamIds;
            string mimeType;
            string encoding = string.Empty;
            string extension;

            string _FileName = rdlcDoc + dr["NoticeIndex"].ToString() + ".pdf";

            if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

            byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
                //fs.Close();
            }
            Session.Add("PDFPath", _FileName);
            return ProcessedPath + _FileName;

        }
        catch
        {
            return "";
        }
    }
}

