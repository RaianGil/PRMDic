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

public partial class TailQuote : System.Web.UI.Page
{
    EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
    private int userID = 0;
    static int roundedUp = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.Control Banner = new System.Web.UI.Control();
        Banner = LoadControl(@"TopBanner1.ascx");
        this.Placeholder1.Controls.Add(Banner);
        //if (cp == null)
        //{
        //    Response.Redirect("HomePage.aspx?001");
        //}
        //else
        //{
        //    if (!cp.IsInRole("POLICYREPORT") && !cp.IsInRole("ADMINISTRATOR"))
        //    {
        //        Response.Redirect("HomePage.aspx?001");
        //    }
        //}
        //INIT EJC200
        /*if (!IsPostBack)
        {
            Policy buffer = (Policy)Session["TaskControl"];

            //if (buffer.PolicyType.Trim() == "AAP")
            //    buffer.PolicyType = "PP";

            //if (buffer.PolicyType.Trim() == "AAE")
            //    buffer.PolicyType = "PE";
            //else if (buffer.PolicyType.Trim() == "AAP")
            //    buffer.PolicyType = "PP";
            //else if (buffer.PolicyType.Trim() == "AEC")
            //    buffer.PolicyType = "CE";
            //else if (buffer.PolicyType.Trim() == "APC")
            //    buffer.PolicyType = "CP";

            if (buffer.PolicyType.Trim() == "PP" || buffer.PolicyType.Trim() == "PE" || buffer.PolicyType.Trim() == "AAP" || buffer.PolicyType.Trim() == "AAE" || buffer.PolicyType.Trim() == "PAH" || buffer.PolicyType.Trim() == "IF")
            {
                Policies taskControl = (Policies)Session["TaskControl"];

                DateTime retroDate = Convert.ToDateTime(taskControl.RetroactiveDate);
                TimeSpan result = DateTime.Now - retroDate;

                lblPolicyNo.Text += taskControl.PolicyType.ToString().Trim() + "-" + taskControl.PolicyNo;
                lblCustomerName.Text += taskControl.Customer.FirstName.ToString().Trim() + " "
                                     + taskControl.Customer.LastName1.ToString().Trim() + " "
                                     + taskControl.Customer.LastName2.ToString().Trim();

                if (result.TotalDays >= 1460)
                {
                    double tailRate = 1.85;

                    double tailPremium = tailRate * taskControl.TotalPremium; //tailRate * taskControl.TotalPremium; 2-17-2017 //taskControl.TotalPrimary;
                    roundedUp = (int)Math.Ceiling(tailPremium);

                    txtTailRate.Text = tailRate.ToString();
                    txtMCMRate.Text = taskControl.TotalPremium.ToString("$###,###.00");
                    txtTailPremium.Text = roundedUp.ToString("$###,###.00");

                    if (taskControl.Bank != "000")
                    {
                        txtTailPremium.ToolTip = "Discount Applied";
                    }

                    this.litPopUp.Visible = false;
                    txtTailPremium.Visible = true;
                    txtTailRate.Visible = true;
                    txtMCMRate.Visible = true;
                    Label10.Visible = true;
                    Label11.Visible = true;
                    Label8.Visible = true;
                    Label9.Visible = true;
                    btnPrint.Visible = true;
                    btnCalculate.Enabled = false;
                    btnConvert.Visible = true;

                }
            }
            else if (buffer.PolicyType.Trim() == "CP" || buffer.PolicyType.Trim() == "CE" || buffer.PolicyType.Trim() == "AEC" || buffer.PolicyType.Trim() == "CPA" || buffer.PolicyType.Trim() == "APC" || buffer.PolicyType.Trim() == "CF")
            {
                CorporatePolicyQuote taskControl = (CorporatePolicyQuote)Session["TaskControl"];

                DateTime retroDate = Convert.ToDateTime(taskControl.RetroactiveDate);
                TimeSpan result = DateTime.Now - retroDate;

                lblPolicyNo.Text += taskControl.PolicyType.ToString().Trim() + "-" + taskControl.PolicyNo;
                lblCustomerName.Text += taskControl.Customer.FirstName.ToString().Trim() + " "
                                     + taskControl.Customer.LastName1.ToString().Trim() + " "
                                     + taskControl.Customer.LastName2.ToString().Trim();

                if (result.TotalDays >= 1460)
                {
                    double tailRate = 1.85; //2

                    double tailPremium = tailRate * taskControl.TotalPrimaryCorporate;
                    if (taskControl.PolicyType.Trim() == "CE" || taskControl.PolicyType.Trim() == "AEC") //A~adi aqui
                        tailPremium = tailRate * taskControl.TotalExcessCorporate;

                    roundedUp = (int)Math.Ceiling(tailPremium);

                    txtTailRate.Text = tailRate.ToString();

                    txtMCMRate.Text = taskControl.TotalPrimaryCorporate.ToString("$###,###.00");
                    if (taskControl.PolicyType.Trim() == "CE" || taskControl.PolicyType.Trim() == "AEC")
                        txtMCMRate.Text = taskControl.TotalExcessCorporate.ToString("$###,###.00");

                    txtTailPremium.Text = roundedUp.ToString("$###,###.00");

                    if (taskControl.Bank != "000")
                    {
                        txtTailPremium.ToolTip = "Discount Applied";
                    }

                    this.litPopUp.Visible = false;
                    txtTailPremium.Visible = true;
                    txtTailRate.Visible = true;
                    txtMCMRate.Visible = true;
                    Label10.Visible = true;
                    Label11.Visible = true;
                    Label8.Visible = true;
                    Label9.Visible = true;
                    btnPrint.Visible = true;
                    btnCalculate.Enabled = false;
                    btnConvert.Visible = true;
                }
            }
            else if (buffer.PolicyType.Trim() == "CLP" || buffer.PolicyType.Trim() == "CLE" || buffer.PolicyType.Trim() == "ALE")
            {
                Laboratory taskControl = (Laboratory)Session["TaskControl"];

                DateTime retroDate = Convert.ToDateTime(taskControl.RetroactiveDate);
                TimeSpan result = DateTime.Now - retroDate;

                lblPolicyNo.Text += taskControl.PolicyType.ToString().Trim() + "-" + taskControl.PolicyNo;
                lblCustomerName.Text += taskControl.Customer.FirstName.ToString().Trim() + " "
                                     + taskControl.Customer.LastName1.ToString().Trim() + " "
                                     + taskControl.Customer.LastName2.ToString().Trim();

                if (result.TotalDays >= 1460)
                {
                    double tailRate = 1.85; 

                    double tailPremium = tailRate * taskControl.TotalPremium;

                    roundedUp = (int)Math.Ceiling(tailPremium);

                    txtTailRate.Text = tailRate.ToString();

                    txtMCMRate.Text = taskControl.TotalPremium.ToString("$###,###.00");

                    txtTailPremium.Text = roundedUp.ToString("$###,###.00");

                    if (taskControl.Bank != "000")
                    {
                        txtTailPremium.ToolTip = "Discount Applied";
                    }

                    this.litPopUp.Visible = false;
                    txtTailPremium.Visible = true;
                    txtTailRate.Visible = true;
                    txtMCMRate.Visible = true;
                    Label10.Visible = true;
                    Label11.Visible = true;
                    Label8.Visible = true;
                    Label9.Visible = true;
                    btnPrint.Visible = true;
                    btnCalculate.Enabled = false; //false
                    btnConvert.Visible = true;
                }
            }
            else
            {
                Cyber taskControl = (Cyber)Session["TaskControl"];

                DateTime retroDate = Convert.ToDateTime(taskControl.RetroactiveDate);
                TimeSpan result = DateTime.Now - retroDate;

                lblPolicyNo.Text += taskControl.PolicyType.ToString().Trim() + "-" + taskControl.PolicyNo;
                lblCustomerName.Text += taskControl.Customer.FirstName.ToString().Trim();
                ////                     + taskControl.Customer.LastName1.ToString().Trim() + " "
                ////                     + taskControl.Customer.LastName2.ToString().Trim();

                //////if (result.TotalDays >= 1460)
                //////{
                //////    double tailRate = 2;

                //////    double tailPremium = tailRate * taskControl.TotalPremium;

                //////    roundedUp = (int)Math.Ceiling(tailPremium);

                //    txtTailRate.Text ="";;

                //    txtMCMRate.Text = "";

                //    txtTailPremium.Text = "";

                //if (taskControl.Bank != "000")
                //{
                //    txtTailPremium.ToolTip = "Discount Applied";
                //}

                this.litPopUp.Visible = false;
                txtTailPremium.Visible = true;
                txtTailRate.Visible = false;
                txtMCMRate.Visible = false;
                Label10.Visible = false;
                Label11.Visible = true;
                Label8.Visible = true;
                Label9.Visible = false;
                btnPrint.Visible = true;
                btnCalculate.Enabled = true;
                btnConvert.Visible = true;
                RadioButtonListCyber.Visible = true;
                Label12.Visible = true;                
                
            }

        }
        this.litPopUp.Visible = false;*/
        //END EJC200
    }
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        if (txtSearchDate.Text == String.Empty)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Please select a cancellation date.");
            this.litPopUp.Visible = true;
            return;
        }

        Policy buffer = (Policy)Session["TaskControl"];



        if (buffer.PolicyType.Trim() == "PP" || buffer.PolicyType.Trim() == "PE" || buffer.PolicyType.Trim() == "AAP" || buffer.PolicyType.Trim() == "AAE" || buffer.PolicyType.Trim() == "PAH" || buffer.PolicyType.Trim() == "IF")
        {
            Policies taskControl = (Policies)Session["TaskControl"];

            DateTime effectiveDate = Convert.ToDateTime(taskControl.EffectiveDate.ToString());
            DateTime expirationDate = Convert.ToDateTime(taskControl.ExpirationDate.ToString());
            DateTime cancelationDate = Convert.ToDateTime(txtSearchDate.Text.ToString());
            DateTime retroActiveDate = Convert.ToDateTime(taskControl.RetroactiveDate);

            if (cancelationDate < effectiveDate || cancelationDate > expirationDate)
            {
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Selected date must be within current policy's effective and expiration dates.");
                this.litPopUp.Visible = true;
                return;
            }

            TimeSpan result = cancelationDate - retroActiveDate;
            double days = result.TotalDays;
            double tailRate = 0.00;

            if (days == 366 || days == 731 || days == 1096)
                days -= 1;

            if (days <= 365)
                tailRate = 0.95;
            else if (days > 365 && days <= 730)
                tailRate = 1.35;
            else if (days > 730 && days <= 1095)
                tailRate = 1.85;
            else
                tailRate = 1.85;

            taskControl.InvoiceNumber = "0"; //Discount
            if (taskControl.Bank != "000") //Bank = Group
            {
                EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                master = master.GetMasterPolicyDiscount(taskControl.Bank, taskControl.EffectiveDate);
                txtTailPremium.ToolTip = "Discount Applied";

                if (taskControl.PolicyType.Trim() == "PE") //Excess
                {
                    taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                    double totprem = Math.Round(taskControl.TotalPremium - (taskControl.TotalPremium * (Math.Round(master.DescuentoExcess / 100, 2))), 0);
                    taskControl.TotalPremium = totprem;
                }
                else // Primary
                {
                    taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                    double totprem = Math.Round(taskControl.TotalPremium - (taskControl.TotalPremium * (Math.Round(master.DescuentoPrimario / 100, 2))), 0);
                    taskControl.TotalPremium = totprem;
                }
            }

            double tailPremium = tailRate * taskControl.MCMRate;
            roundedUp = (int)Math.Ceiling(tailPremium);

            txtTailRate.Text = tailRate.ToString();
            txtMCMRate.Text = taskControl.MCMRate.ToString("$###,###.00");
            txtTailPremium.Text = roundedUp.ToString("$###,###.00");

            this.litPopUp.Visible = false;
            txtTailPremium.Visible = true;
            txtTailRate.Visible = true;
            txtMCMRate.Visible = true;
            Label10.Visible = true;
            Label11.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;
            btnPrint.Visible = true;
            btnConvert.Visible = true;
        }
        else if (buffer.PolicyType.Trim() == "CP" || buffer.PolicyType.Trim() == "CE" || buffer.PolicyType.Trim() == "CPA" || buffer.PolicyType.Trim() == "CF")
        {
            CorporatePolicyQuote taskControl = (CorporatePolicyQuote)Session["TaskControl"];

            DateTime effectiveDate = Convert.ToDateTime(taskControl.EffectiveDate.ToString());
            DateTime expirationDate = Convert.ToDateTime(taskControl.ExpirationDate.ToString());
            DateTime cancelationDate = Convert.ToDateTime(txtSearchDate.Text.ToString());
            DateTime retroActiveDate = Convert.ToDateTime(taskControl.RetroactiveDate);

            if (cancelationDate < effectiveDate || cancelationDate > expirationDate)
            {
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Selected date must be within current policy's effective and expiration dates.");
                this.litPopUp.Visible = true;
                return;
            }

            TimeSpan result = cancelationDate - retroActiveDate;
            double days = result.TotalDays;
            double tailRate = 0.00;

            if (days == 366 || days == 731 || days == 1096)
                days -= 1;

            if (days <= 365)
                tailRate = 0.95;
            else if (days > 365 && days <= 730)
                tailRate = 1.35;
            else if (days > 730 && days <= 1095)
                tailRate = 1.85;
            else
                tailRate = 1.85;

            taskControl.InvoiceNumber = "0"; //Discount
            if (taskControl.Bank != "000") //Bank = Group
            {
                EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                master = master.GetMasterPolicyDiscount(taskControl.Bank, taskControl.EffectiveDate);
                txtTailPremium.ToolTip = "Discount Applied";

                if (taskControl.PolicyType.Trim() == "CE") //Excess
                {
                    taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                    double totprem = Math.Round(taskControl.TotalPremium - (taskControl.TotalPremium * (Math.Round(master.DescuentoExcess / 100, 2))), 0);
                    taskControl.TotalPremium = totprem;
                }
                else // Primary
                {
                    taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                    double totprem = Math.Round(taskControl.TotalPremium - (taskControl.TotalPremium * (Math.Round(master.DescuentoPrimario / 100, 2))), 0);
                    taskControl.TotalPremium = totprem;
                }
            }

            double tailPremium = tailRate * taskControl.TotalPrimaryCorporate;
            if (taskControl.PolicyType.Trim() == "CE")
                tailPremium = tailRate * taskControl.TotalExcessCorporate;

            roundedUp = (int)Math.Ceiling(tailPremium);

            txtTailRate.Text = tailRate.ToString();

            txtMCMRate.Text = taskControl.TotalPrimaryCorporate.ToString("$###,###.00");
            if (taskControl.PolicyType.Trim() == "CE")
                txtMCMRate.Text = taskControl.TotalExcessCorporate.ToString("$###,###.00");

            txtTailPremium.Text = roundedUp.ToString("$###,###.00");

            this.litPopUp.Visible = false;
            txtTailPremium.Visible = true;
            txtTailRate.Visible = true;
            txtMCMRate.Visible = true;
            Label10.Visible = true;
            Label11.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;
            btnPrint.Visible = true;
            btnConvert.Visible = true;
        }
        else if (buffer.PolicyType.Trim() == "CLP" || buffer.PolicyType.Trim() == "CLE")
        {
            Laboratory taskControl = (Laboratory)Session["TaskControl"];

            DateTime effectiveDate = Convert.ToDateTime(taskControl.EffectiveDate.ToString());
            DateTime expirationDate = Convert.ToDateTime(taskControl.ExpirationDate.ToString());
            DateTime cancelationDate = Convert.ToDateTime(txtSearchDate.Text.ToString());
            DateTime retroActiveDate = Convert.ToDateTime(taskControl.RetroactiveDate);

            if (cancelationDate < effectiveDate || cancelationDate > expirationDate)
            {
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Selected date must be within current policy's effective and expiration dates.");
                this.litPopUp.Visible = true;
                return;
            }

            TimeSpan result = cancelationDate - retroActiveDate;
            double days = result.TotalDays;
            double tailRate = 0.00;

            if (days == 366 || days == 731 || days == 1096)
                days -= 1;

            if (days <= 365)
                tailRate = 0.95;
            else if (days > 365 && days <= 730)
                tailRate = 1.35;
            else if (days > 730 && days <= 1095)
                tailRate = 1.85;
            else
                tailRate = 1.85;

            taskControl.InvoiceNumber = "0"; //Discount
            if (taskControl.Bank != "000") //Bank = Group
            {
                EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
                master = master.GetMasterPolicyDiscount(taskControl.Bank, taskControl.EffectiveDate);
                txtTailPremium.ToolTip = "Discount Applied";

                taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
                double totprem = Math.Round(taskControl.TotalPremium - (taskControl.TotalPremium * (Math.Round(master.DescuentoPrimario / 100, 2))), 0);
                taskControl.TotalPremium = totprem;
            }

            double tailPremium = tailRate * taskControl.TotalPremium;

            roundedUp = (int)Math.Ceiling(tailPremium);

            txtTailRate.Text = tailRate.ToString();

            txtMCMRate.Text = taskControl.TotalPremium.ToString("$###,###.00");

            txtTailPremium.Text = roundedUp.ToString("$###,###.00");

            this.litPopUp.Visible = false;
            txtTailPremium.Visible = true;
            txtTailRate.Visible = true;
            txtMCMRate.Visible = true;
            Label10.Visible = true;
            Label11.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;
            btnPrint.Visible = true;
            btnConvert.Visible = true;
        }
        else
        {
            Cyber taskControl = (Cyber)Session["TaskControl"];          

            DateTime effectiveDate = Convert.ToDateTime(taskControl.EffectiveDate.ToString());
            DateTime expirationDate = Convert.ToDateTime(taskControl.ExpirationDate.ToString());
            DateTime cancelationDate = Convert.ToDateTime(txtSearchDate.Text.ToString());
            DateTime retroActiveDate = Convert.ToDateTime(taskControl.RetroactiveDate);

            if (cancelationDate < effectiveDate || cancelationDate > expirationDate)
            {
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Selected date must be within current policy's effective and expiration dates.");
                this.litPopUp.Visible = true;
                return;
            }

            //TimeSpan result = cancelationDate - retroActiveDate;
            //double days = result.TotalDays;
            //double tailRate = 0.00;

            //if (days == 366 || days == 731 || days == 1096)
            //    days -= 1;

            //if (days <= 365)
            //    tailRate = 0.95;
            //else if (days > 365 && days <= 730)
            //    tailRate = 1.35;
            //else if (days > 730 && days <= 1095)
            //    tailRate = 1.85;
            //else
            //    tailRate = 2;

            //taskControl.InvoiceNumber = "0"; //Discount
            //if (taskControl.Bank != "000") //Bank = Group
            //{
            //    EPolicy.LookupTables.MasterPolicy master = new EPolicy.LookupTables.MasterPolicy();
            //    master = master.GetMasterPolicyDiscount(taskControl.Bank, taskControl.EffectiveDate);
            //    txtTailPremium.ToolTip = "Discount Applied";

            //    taskControl.InvoiceNumber = master.DescuentoExcess.ToString();
            //    double totprem = Math.Round(taskControl.TotalPremium - (taskControl.TotalPremium * (Math.Round(master.DescuentoPrimario / 100, 2))), 0);
            //    taskControl.TotalPremium = totprem;
            //}

            //double tailPremium = tailRate * taskControl.TotalPremium;

            //roundedUp = (int)Math.Ceiling(tailPremium);

            txtTailRate.Text = "";
            txtMCMRate.Text = "";
            txtCyberPercent.Text = taskControl.TotalPremium.ToString("$###,###.00");

            if (RadioButtonListCyber.SelectedIndex == 0)
            {
                txtTailPremium.Text = (taskControl.TotalPremium.ToString("$###,###.00"));
            }
            else
            {
                txtTailPremium.Text = (2 * taskControl.TotalPremium).ToString("$###,###.00");
            }


            if (RadioButtonListCyber.SelectedIndex == 0)
            {
                txtCyberPercent.Text = "100%";
            }
            else if (RadioButtonListCyber.SelectedIndex == 1)
            {
                txtCyberPercent.Text = "200%";
            }
            else
            {
                txtCyberPercent.Text = "";
            }


           // roundedUp = int.Parse(txtTailPremium.Text);

            this.litPopUp.Visible = false;
            txtTailPremium.Visible = true;
            txtTailRate.Visible = false;
            txtMCMRate.Visible = false;
            Label10.Visible = false;
            Label11.Visible = true;
            Label8.Visible = true;
            Label9.Visible = false;
            btnPrint.Visible = true;
            btnConvert.Visible = true;
            txtCyberPercent.Visible = true;
 
        }

    }

    private List<string> WriteRdlcToPDF(ReportViewer viewer, EPolicy.TaskControl.Laboratory taskControl, List<string> mergePaths, int index)
    {
        Warning[] warnings = null;
        string[] streamIds = null;
        string mimeType = string.Empty;
        string encoding = string.Empty;
        string extension = string.Empty;
        string filetype = string.Empty;


        string fileName1 = "FileNo-" + index.ToString();
        string _FileName1 = "FileNo-" + index.ToString() + ".pdf";

        if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName1))
            File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName1);

        byte[] bytes1 = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

        using (FileStream fs1 = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName1, FileMode.Create))
        {
            fs1.Write(bytes1, 0, bytes1.Length);
        }

        try
        {
            mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName1);
        }
        catch (Exception ecp)
        {
           // ShowMessage(ecp.Message);

        }
        return mergePaths;
    }
    public static DataTable GetAgencyDesc(string AgencyID)
    {
        DataTable dt = new DataTable();

        DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[1];

        DbRequestXmlCooker.AttachCookItem("AgencyID",
            SqlDbType.VarChar, 10, AgencyID.ToString(),
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

        dt = exec.GetQuery("GetAgencyDesc", xmlDoc);
        return dt;
    }
    public static DataTable GetAgentDesc(int AgentID)
    {
        DataTable dt = new DataTable();

        DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[1];

        DbRequestXmlCooker.AttachCookItem("AgentID",
            SqlDbType.Int, 0, AgentID.ToString(),
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

        dt = exec.GetQuery("GetAgentByAgentID", xmlDoc);
        return dt;
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Policy taskControl = (Policy)Session["TaskControl"];
        string finalFile = String.Empty;

        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        int userID = cp.UserID;

        if (Validate())
        {
            string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];
            //List<string> mergePaths = new List<string>();
            ReportViewer viewer = new ReportViewer();
            viewer.LocalReport.DataSources.Clear();
            viewer.ProcessingMode = ProcessingMode.Local;

            finalFile = PrintQuote();

            History(taskControl.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED TAIL QUOTE");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + finalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
        }
        return;
    }
    protected void BtnExit_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();</" + "script>");
        Response.End();
    }
    private string PrintQuote()
    {
        Policy taskControlVali = (Policy)Session["TaskControl"];

        if (taskControlVali.PolicyType == "CLP" || taskControlVali.PolicyType == "CLE")
        {
            EPolicy.TaskControl.Laboratory taskControl2 = (EPolicy.TaskControl.Laboratory)Session["TaskControl"];
            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
            string userName = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();
            List<string> mergePaths = new List<string>();
            string ProcessedPath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"];

            DataTable dtAgency = GetAgencyDesc(taskControlVali.Agency.ToString());
            DataTable dtAgent = GetAgentDesc(int.Parse(taskControlVali.Agent.ToString()));

            ReportViewer viewer = new ReportViewer();
            viewer.LocalReport.ReportPath = Server.MapPath("Reports/ExtendedReportingPeriodQuote.rdlc");
            viewer.LocalReport.DataSources.Clear();
            viewer.ProcessingMode = ProcessingMode.Local;


            ReportParameter[] param = new ReportParameter[15];
            param[0] = new ReportParameter("PolicyID", taskControl2.PolicyNo.ToString().Trim());
            param[1] = new ReportParameter("EffectiveDate", DateTime.Parse(taskControl2.EffectiveDate).ToString("MMMM dd, yyyy"));
            param[2] = new ReportParameter("ExpirationDate", DateTime.Parse(taskControl2.ExpirationDate).ToString("MMMM dd, yyyy"));
            param[3] = new ReportParameter("Agency", dtAgency.Rows[0]["AgencyDesc"].ToString());
            param[4] = new ReportParameter("Agent", dtAgent.Rows[0]["AgentDesc"].ToString());
            param[5] = new ReportParameter("Customer", taskControl2.Customer.FirstName + " " + taskControl2.Customer.LastName1 + " " + taskControl2.Customer.LastName2);

            if (taskControl2.Customer.Address2 != String.Empty)
                param[6] = new ReportParameter("Address", taskControl2.Customer.Address1 + " \r\n" + taskControl2.Customer.Address2 + " \r\n" +
                                           taskControl2.Customer.City + " " + taskControl2.Customer.State + " " + taskControl2.Customer.ZipCode);
            else
                param[6] = new ReportParameter("Address", taskControl2.Customer.Address1 + " \r\n" +
                                               taskControl2.Customer.City + " " + taskControl2.Customer.State + " " + taskControl2.Customer.ZipCode);
            string CancDate = "";

            if (taskControl2.CancellationDate.ToString() != "")
                CancDate = DateTime.Parse(taskControl2.CancellationDate).ToString("MMMM dd, yyyy");

            param[7] = new ReportParameter("CancellationDate", CancDate.ToString());

            if (taskControl2.ReturnPremium != 0.00 && taskControl2.ReturnCharge != 0.00)
            {
                param[8] = new ReportParameter("ReturnPremium", (taskControl2.ReturnPremium + taskControl2.ReturnCharge).ToString("$###,##0.00"));
            }
            else
            {
                if (txtTailPremium.Text != "")
                {
                    param[8] = new ReportParameter("ReturnPremium", txtTailPremium.Text.Trim());
                }
                else
                    param[8] = new ReportParameter("ReturnPremium", (taskControl2.ReturnPremium + taskControl2.ReturnCharge).ToString("$###,##0.00"));
            }
            
            param[9] = new ReportParameter("PolicyType", taskControl2.PolicyType.ToString().Trim());

            if (taskControl2.CancellationMethod == 1)
            {
                param[10] = new ReportParameter("MOC3", "X");
                param[11] = new ReportParameter("MOC5Exp", "");
            }
            else if (taskControl2.CancellationMethod == 2)
            {
                param[10] = new ReportParameter("MOC2", "X");
                param[11] = new ReportParameter("MOC5Exp", "");
            }
            else if (taskControl2.CancellationMethod == 3)
            {
                param[10] = new ReportParameter("MOC1", "X");
                param[11] = new ReportParameter("MOC5Exp", "");
            }
            else if (taskControl2.CancellationMethod == 4)
            {
                param[10] = new ReportParameter("MOC4", "X");
                param[11] = new ReportParameter("MOC5Exp", "");
            }
            else
            {
                param[10] = new ReportParameter("MOC5", "X");
                param[11] = new ReportParameter("MOC5Exp", taskControl2.CancellationMethodDesc.ToString());
            }

            if (taskControl2.CancellationReason == 6)
            {
                param[12] = new ReportParameter("RSC1", "X");
                param[13] = new ReportParameter("RSC4Date", "");
            }
            else if (taskControl2.CancellationReason == 5 || taskControl2.CancellationReason == 10
                     || taskControl2.CancellationReason == 14)
            {
                param[12] = new ReportParameter("RSC2", "X");
                param[13] = new ReportParameter("RSC4Date", "");
            }
            else if (taskControl2.CancellationReason == 26)
            {
                param[12] = new ReportParameter("RSC3", "X");
                param[13] = new ReportParameter("RSC3Date", DateTime.Parse(taskControl2.CancellationReasonDesc).ToString("MMMM dd, yyyy"));
            }
            else if (taskControl2.CancellationReason == 27)
            {
                param[12] = new ReportParameter("RSC4", "X");
                param[13] = new ReportParameter("RSC4Date", DateTime.Parse(taskControl2.CancellationReasonDesc).ToString("MMMM dd, yyyy"));
            }
            else
            {
                param[12] = new ReportParameter("RSC5", "X");
                param[13] = new ReportParameter("RSC5Exp", taskControl2.CancellationReasonDesc.ToString());
            }

            param[14] = new ReportParameter("insuranceCompany", taskControl2.InsuranceCompany.ToString());

            viewer.LocalReport.SetParameters(param);
            viewer.LocalReport.Refresh();

            Warning[] warnings;
            string[] streamIds;
            string mimeType;
            string encoding = string.Empty;
            string extension;
            string fileName = userName;
            string _FileName = userName + ".pdf";

            _FileName = _FileName.Replace(",", "");
            _FileName = _FileName.Replace("&", "");
            _FileName = _FileName.Replace("/", "");

            if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

            byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }

            History(taskControlVali.TaskControlID, userID, "PRINT", "POLICIES", "PRINTED CANCELLATION CREDIT");


            mergePaths = WriteRdlcToPDF(viewer, taskControl2, mergePaths, 0);

            //viewer = new ReportViewer();
            //viewer.LocalReport.DataSources.Clear();
            //viewer.ProcessingMode = ProcessingMode.Local;
            //viewer.LocalReport.ReportPath = Server.MapPath("Reports/ExtendedReportingPeriodQuote.rdlc");
            //viewer.LocalReport.SetParameters(param);
            //viewer.LocalReport.Refresh();
            // mergePaths = WriteRdlcToPDF(viewer, taskControl2, mergePaths, 1);

            EPolicy.CreatePDFBatch mergeFinal = new EPolicy.CreatePDFBatch();
            string FinalFile = "";
            DateTime Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, taskControl2.PolicyType.ToString() + " " + taskControl2.PolicyNo.ToString() + " Tail Quote " + "" + DateTime.Now.ToShortDateString().Replace('/', '-') + "");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + _FileName + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
            return _FileName;        
        }
        else
        {
            Policy taskControl = (Policy)Session["TaskControl"];
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
                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.ReportPath = Server.MapPath("Reports/TailQuote.rdlc");
                viewer.LocalReport.DataSources.Clear();
                viewer.ProcessingMode = ProcessingMode.Local;

                GetCertificateInformationTableAdapters.GetCustomerCertificateInfoTableAdapter ta =
                new GetCertificateInformationTableAdapters.GetCustomerCertificateInfoTableAdapter();

                GetCertificateInformation.GetCustomerCertificateInfoDataTable cusDt =
                new GetCertificateInformation.GetCustomerCertificateInfoDataTable();

                ta.Fill(cusDt, taskControl.TaskControlID);

                if (taskControl.PolicyType.ToString().Trim() == "PP" || taskControl.PolicyType.ToString().Trim() == "PE")
                    cusDt.Rows[0]["CustomerName"] = "Dr. " + cusDt.Rows[0]["CustomerName"];

                string name = GetUserByUserID(userID);
                Regex initials = new Regex(@"(\b[a-zA-Z])[a-zA-Z]* ?");
                string init = initials.Replace(name, "$1");

                ReportParameterInfoCollection paramCol = viewer.LocalReport.GetParameters();
                ReportParameter rp1 = new ReportParameter(paramCol[0].Name, txtTailPremium.Text.Trim());
                ReportParameter rp2 = new ReportParameter(paramCol[1].Name, ConvertDates(cusDt, txtSearchDate.Text.Trim()));
                ReportParameter rp3 = new ReportParameter(paramCol[2].Name, taskControl.Customer.Address1.ToString().Trim());
                ReportParameter rp4 = new ReportParameter();
                ReportParameter rp5 = new ReportParameter();
                ReportParameter rp6 = new ReportParameter(paramCol[5].Name, init + "-" + userID);
                ReportParameter rp7 = new ReportParameter(paramCol[6].Name, taskControl.InsuranceCompany);

                if (taskControl.Customer.Address2.ToString().Trim() == String.Empty)
                {
                    rp4 = new ReportParameter(paramCol[3].Name, taskControl.Customer.City.ToString().Trim() + ","
                       + taskControl.Customer.State.ToString().Trim() + " " + taskControl.Customer.ZipCode.ToString().Trim());
                    rp5 = new ReportParameter(paramCol[4].Name, " ");
                }
                else
                {
                    rp4 = new ReportParameter(paramCol[3].Name, taskControl.Customer.Address2.ToString().Trim());
                    rp5 = new ReportParameter(paramCol[4].Name, taskControl.Customer.City.ToString().Trim() + ","
                       + taskControl.Customer.State.ToString().Trim() + " " + taskControl.Customer.ZipCode.ToString().Trim());
                }

                viewer.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7 });

                Microsoft.Reporting.WebForms.ReportDataSource rptDataSource =
                new Microsoft.Reporting.WebForms.ReportDataSource("GetCertificateInformation_GetCustomerCertificateInfo", cusDt);

                viewer.LocalReport.DataSources.Add(rptDataSource);
                viewer.LocalReport.Refresh();

                // Variables 
                Warning[] warnings;
                string[] streamIds;
                string mimeType;
                string encoding = string.Empty;
                string extension;
                string fileName = taskControl.PolicyType.Trim() + taskControl.PolicyNo.Trim() + " Tail Quote" + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString();
                string _FileName = taskControl.PolicyType.Trim() + taskControl.PolicyNo.Trim() + " Tail Quote" + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString() + ".pdf";
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
    }
    private static string ConvertDates(GetCertificateInformation.GetCustomerCertificateInfoDataTable dt, string searchDate)
    {
        DateTime parsedDate = Convert.ToDateTime(dt.Rows[0]["EffectiveDate"]);
        dt.Rows[0]["EffectiveDate"] = parsedDate.ToString("MMMM dd, yyyy");

        parsedDate = Convert.ToDateTime(dt.Rows[0]["RetroactiveDate"]);
        dt.Rows[0]["RetroactiveDate"] = parsedDate.ToString("MMMM dd, yyyy");

        parsedDate = Convert.ToDateTime(searchDate);

        return parsedDate.ToString("MMMM dd, yyyy");
    }
    private string GetUserByUserID(int userID)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        XmlDocument xmlDoc = new XmlDocument();

        sb.Append("<parameters>");
        sb.Append("<parameter>");
        sb.Append("<name>UserID</name>");
        sb.Append("<type>int</type>");
        sb.Append("<value>" + userID + "</value>");
        sb.Append("</parameter>");
        sb.Append("</parameters>");
        xmlDoc.InnerXml = sb.ToString();
        sb = null;

        DBRequest exec = new DBRequest();

        DataTable dt = exec.GetQuery("GetAuthenticatedUserByUserID", xmlDoc);
        string name = String.Empty;

        if (dt != null)
        {
            if (dt.Rows.Count != 0)
            {
                name = dt.Rows[0]["FirstName"].ToString().Trim() + " " +
                    dt.Rows[0]["LastName"].ToString().Trim();
            }
        }
        return name;
    }
    protected void btnConvert_Click(object sender, EventArgs e)
    {
        Policy buffer = (Policy)Session["TaskControl"];

        if (buffer.PolicyType.Trim() == "PP" || buffer.PolicyType.Trim() == "PE" || buffer.PolicyType.Trim() == "AAP" || buffer.PolicyType.Trim() == "AAE" || buffer.PolicyType.Trim() == "PAH" || buffer.PolicyType.Trim() == "IF")
        {
            EPolicy.TaskControl.Policies taskControl = (EPolicy.TaskControl.Policies)Session["TaskControl"];
            EPolicy.TaskControl.Policies task = (EPolicy.TaskControl.Policies)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControl.TaskControlID, 1);
            DataTable dtCharge = EPolicy.LookupTables.LookupTables.GetTable("Charge");
            int result = 0;


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

            if (Validate())
            {

                for (int i = 0; i < dtCharge.Rows.Count; i++)
                {
                    result = DateTime.Compare(DateTime.Parse(txtSearchDate.Text.ToString().Trim()),
                             DateTime.Parse(dtCharge.Rows[i]["effectiveDate"].ToString()));

                    if (result == 0 || result == 1)
                    {
                        taskControl.TotalPremium = (double)roundedUp + ((double)roundedUp * double.Parse(dtCharge.Rows[i]["chargePercent"].ToString()));//taskControl.Charge;
                        taskControl.Charge = ((double)roundedUp * double.Parse(dtCharge.Rows[i]["chargePercent"].ToString()));
                    }
                    else
                    {
                        taskControl.TotalPremium = (double)roundedUp;
                    }
                }

                taskControl.Mode = 1; //ADD

                if (taskControl.PolicyType.Trim() == "PP")
                    taskControl.PolicyType = "PPT";
                else if (taskControl.PolicyType.Trim() == "PE")
                    taskControl.PolicyType = "PET";
                else if (taskControl.PolicyType.Trim() == "PAH")
                    taskControl.PolicyType = "PAHT";
                else if (taskControl.PolicyType.Trim() == "AAP")
                    taskControl.PolicyType = "AAPT";
                else if (taskControl.PolicyType.Trim() == "IF")
                    taskControl.PolicyType = "IFT";
                else
                    taskControl.PolicyType = "AAET";

                taskControl.EffectiveDate = txtSearchDate.Text.ToString().Trim();
                //taskControl.TotalPremium = (double)roundedUp + taskControl.Charge;
                taskControl.Status = "Inforce";
                //taskControl.Suffix = ((int.Parse(taskControl.Suffix.Trim())) + 1).ToString("D2").Trim();

                int msufijo;
                int sufijo = int.Parse(taskControl.Suffix);
                msufijo = sufijo + 1;
                if (msufijo < 10)
                    taskControl.Suffix = "0".ToString() + msufijo.ToString();
                else
                    taskControl.Suffix = msufijo.ToString();
                taskControl.ExpirationDate = txtSearchDate.Text.ToString().Trim();
                taskControl.PRMedicalLimit = task.PRMedicalLimit;
                taskControl.CancellationDate = txtSearchDate.Text.ToString().Trim();
                taskControl.CancellationEntryDate = DateTime.Now.ToShortDateString();
                taskControl.EntryDate = DateTime.Now;
                taskControl.CancellationAmount = 0;
                taskControl.PaidAmount = 0;

                taskControl.CancellationMethod = 0;
                taskControl.CancellationReason = 0;
                taskControl.CancellationUnearnedPercent = 0.00;
                taskControl.ReturnPremium = 0.00;
                taskControl.ReturnCharge = 0.00;
                taskControl.CancellationReasonDesc = "";
                taskControl.CancellationMethodDesc = "";

                //Save History on old Policy
                History(taskControl.TaskControlID, userID, "EDIT", "POLICIES", "CONVERTED POLICY INTO TAIL POLICY.");

                //Save New Tail Policy.
                taskControl.SavePol(userID);  //(userID);

                //Revert any cancellations made.
                taskControl.SaveCancellation(userID);

                //Update Inception Payment Amount
                UpdateInceptionPartialPayments(taskControl.TaskControlID, taskControl.TotalPremium);



                Session.Remove("TaskControl");
                Session["TaskControl"] = taskControl;

                //Server.Transfer("~/Policies.aspx", true);
                //Response.Write("<script>window.opener.location.href="+"~/Policies.aspx"+"; window.close();</" + "script>");
                //Response.End();

                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Tail Conversion was succesful.");
                this.litPopUp.Visible = true;
            }
        }
        else if (buffer.PolicyType.Trim() == "CP" || buffer.PolicyType.Trim() == "CE" || buffer.PolicyType.Trim() == "AEC" || buffer.PolicyType.Trim() == "CPA" || buffer.PolicyType.Trim() == "APC" || buffer.PolicyType.Trim() == "CF") //Add ard
        {
            EPolicy.TaskControl.CorporatePolicyQuote taskControl = (EPolicy.TaskControl.CorporatePolicyQuote)Session["TaskControl"];
            EPolicy.TaskControl.CorporatePolicyQuote task = (EPolicy.TaskControl.CorporatePolicyQuote)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControl.TaskControlID, 1);

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

            if (Validate())
            {

                taskControl.Mode = 1; //ADD

                if (taskControl.PolicyType.Trim() == "CP")
                    taskControl.PolicyType = "CPT";
                else if (taskControl.PolicyType.Trim() == "CE")
                    taskControl.PolicyType = "CET";
                else if (taskControl.PolicyType.Trim() == "CPA")
                    taskControl.PolicyType = "CPAT";
                else if (taskControl.PolicyType.Trim() == "ALE")
                    taskControl.PolicyType = "ALET";
                else if (taskControl.PolicyType.Trim() == "AEC") //Add ard
                    taskControl.PolicyType = "AECT"; //add ard
                else if (taskControl.PolicyType.Trim() == "APC")
                    taskControl.PolicyType = "APCT";
                else if (taskControl.PolicyType.Trim() == "CF")
                    taskControl.PolicyType = "CFT";
                else
                    taskControl.PolicyType = "AECT";
                

                taskControl.EffectiveDate = txtSearchDate.Text.ToString().Trim();
                taskControl.TotalPremium = (double)roundedUp + taskControl.Charge;
                taskControl.Status = "Inforce";
                //taskControl.Suffix = (int.Parse(taskControl.Suffix.Trim() + 1).ToString("D2").Trim());

                int msufijo;
                int sufijo = int.Parse(taskControl.Suffix);
                msufijo = sufijo + 1;
                if (msufijo < 10)
                    taskControl.Suffix = "0".ToString() + msufijo.ToString();
                else
                    taskControl.Suffix = msufijo.ToString();

                taskControl.ExpirationDate = txtSearchDate.Text.ToString().Trim();
                //taskControl.PRMedicalLimit = task.PRMedicalLimit;
                taskControl.CancellationDate = txtSearchDate.Text.ToString().Trim();
                taskControl.CancellationEntryDate = DateTime.Now.ToShortDateString();
                taskControl.EntryDate = DateTime.Now;
                taskControl.CancellationAmount = 0;
                taskControl.PaidAmount = 0;

                taskControl.CancellationMethod = 0;
                taskControl.CancellationReason = 0;
                taskControl.CancellationUnearnedPercent = 0.00;
                taskControl.ReturnPremium = 0.00;
                taskControl.ReturnCharge = 0.00;
                taskControl.CancellationReasonDesc = "";
                taskControl.CancellationMethodDesc = "";

                taskControl.SaveCorporatePolicy(userID);  //(userID);

                //Revert any cancellations made.
                taskControl.SaveCancellation(userID);

                if (taskControl.IsPolicy)
                {
                    //Update Inception Payment Amount
                    UpdateInceptionPartialPayments(taskControl.TaskControlID, (taskControl.TotalPremium + taskControl.Charge));
                }

                Session.Remove("TaskControl");
                Session["TaskControl"] = taskControl;

                //Server.Transfer("~/Policies.aspx", true);
                //Response.Write("<script>window.opener.location.href="+"~/Policies.aspx"+"; window.close();</" + "script>");
                //Response.End();

                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Tail Conversion was succesful.");
                this.litPopUp.Visible = true;
            }
        }
        else if (buffer.PolicyType.Trim() == "CLP" || buffer.PolicyType.Trim() == "CLE" || buffer.PolicyType.Trim() == "ALE")
        {
            Laboratory taskControl = (Laboratory)Session["TaskControl"];
            Laboratory task = (Laboratory)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControl.TaskControlID, 1);

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

            if (Validate())
            {

                taskControl.Mode = 1; //ADD

                if (taskControl.PolicyType.Trim() == "CLP")
                    taskControl.PolicyType = "CLPT";
                if (taskControl.PolicyType.Trim() == "ALE")
                    taskControl.PolicyType = "ALET";

                taskControl.EffectiveDate = txtSearchDate.Text.ToString().Trim();
                taskControl.TotalPremium = (double)roundedUp + taskControl.Charge;
                taskControl.Status = "Inforce";
                //taskControl.Suffix = (int.Parse(taskControl.Suffix.Trim() + 1).ToString("D2").Trim());
                int msufijo;
                int sufijo = int.Parse(taskControl.Suffix);
                msufijo = sufijo + 1;
                if (msufijo < 10)
                    taskControl.Suffix = "0".ToString() + msufijo.ToString();
                else
                    taskControl.Suffix = msufijo.ToString();

                taskControl.ExpirationDate = txtSearchDate.Text.ToString().Trim();
                //taskControl.PRMedicalLimit = task.PRMedicalLimit;
                taskControl.CancellationDate = txtSearchDate.Text.ToString().Trim();
                taskControl.CancellationEntryDate = DateTime.Now.ToShortDateString();
                taskControl.EntryDate = DateTime.Now;
                taskControl.CancellationAmount = 0;
                taskControl.PaidAmount = 0;

                taskControl.CancellationMethod = 0;
                taskControl.CancellationReason = 0;
                taskControl.CancellationUnearnedPercent = 0.00;
                taskControl.ReturnPremium = 0.00;
                taskControl.ReturnCharge = 0.00;
                taskControl.CancellationReasonDesc = "";
                taskControl.CancellationMethodDesc = "";

                taskControl.SaveLaboratory();  //(userID);

                //Revert any cancellations made.
                taskControl.SaveCancellation(userID);

                if (taskControl.IsPolicy)
                {
                    //Update Inception Payment Amount
                    UpdateInceptionPartialPayments(taskControl.TaskControlID, (taskControl.TotalPremium + taskControl.Charge));
                }

                Session.Remove("TaskControl");
                Session["TaskControl"] = taskControl;

                //Server.Transfer("~/Policies.aspx", true);
                //Response.Write("<script>window.opener.location.href="+"~/Policies.aspx"+"; window.close();</" + "script>");
                //Response.End();

                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Tail Conversion was succesful.");
                this.litPopUp.Visible = true;
            }
        }
        else
        {
            Cyber taskControl = (Cyber)Session["TaskControl"];
            Cyber task = (Cyber)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControl.TaskControlID, 1);

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

            if (Validate())
            {

                taskControl.Mode = 1; //ADD

                if (taskControl.PolicyType.Trim() == "EMD")                
                    taskControl.PolicyType = "EMDT";
                
                //else if (taskControl.PolicyType.Trim() == "ICE")
                //{
                //    taskControl.PolicyType = "ICET";
                //}

                taskControl.EffectiveDate = txtSearchDate.Text.ToString().Trim();
                taskControl.TotalPremium = double.Parse(txtTailPremium.Text.Replace("$", "")) + taskControl.Charge;
                taskControl.Status = "Inforce";
                //taskControl.Suffix = (int.Parse(taskControl.Suffix.Trim() + 1).ToString("D2").Trim());
                int msufijo;
                int sufijo = int.Parse(taskControl.Suffix);
                msufijo = sufijo + 1;
                if (msufijo < 10)
                    taskControl.Suffix = "0".ToString() + msufijo.ToString();
                else
                    taskControl.Suffix = msufijo.ToString();

                taskControl.ExpirationDate = txtSearchDate.Text.ToString().Trim();
                //taskControl.PRMedicalLimit = task.PRMedicalLimit;
                taskControl.CancellationDate = txtSearchDate.Text.ToString().Trim();
                taskControl.CancellationEntryDate = DateTime.Now.ToShortDateString();
                taskControl.EntryDate = DateTime.Now;
                taskControl.CancellationAmount = 0;
                taskControl.PaidAmount = 0;

                taskControl.CancellationMethod = 0;
                taskControl.CancellationReason = 0;
                taskControl.CancellationUnearnedPercent = 0.00;
                taskControl.ReturnPremium = 0.00;
                taskControl.ReturnCharge = 0.00;
                taskControl.CancellationReasonDesc = "";
                taskControl.CancellationMethodDesc = "";

                taskControl.SaveCyber();  //(userID);

                //Revert any cancellations made.
                taskControl.SaveCancellation(userID);

                if (taskControl.IsPolicy)
                {
                    //Update Inception Payment Amount
                    UpdateInceptionPartialPayments(taskControl.TaskControlID, (taskControl.TotalPremium + taskControl.Charge));
                }

                Session.Remove("TaskControl");
                Session["TaskControl"] = taskControl;

                //Server.Transfer("~/Policies.aspx", true);
                //Response.Write("<script>window.opener.location.href="+"~/Policies.aspx"+"; window.close();</" + "script>");
                //Response.End();

                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Tail Conversion was succesful.");
                this.litPopUp.Visible = true;
            }
 
        }
        return;
    }
    private void UpdateInceptionPartialPayments(int taskControlID, double totprem)
    {
        DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[2];

        decimal prem = decimal.Parse(totprem.ToString());
        prem = prem * -1;

        DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, taskControlID.ToString(), ref cookItems);
        DbRequestXmlCooker.AttachCookItem("TransactionAmount", SqlDbType.Money, 0, prem.ToString(), ref cookItems);

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
            exec.Update("UpdateInceptionPartialPayments", xmlDoc);
        }
        catch (Exception ex)
        {
            throw new Exception("Could not update Partial Payment.", ex);
        }
    }
    private bool Validate()
    {
        Policy taskControl = (Policy)Session["TaskControl"];

        if (txtSearchDate.Text == String.Empty)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Please provide a cancellation date.");
            this.litPopUp.Visible = true;
            return false;
        }

        if (lblPolicyNo.Text.Trim() != "Policy No:" + taskControl.PolicyType.ToString().Trim() + "-" + taskControl.PolicyNo.ToString().Trim())
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("WARNING! Policy Session changed!  Go back and select the previous policy or re-open this window.");
            this.litPopUp.Visible = true;
            return false;
        }

        DateTime effectiveDate = Convert.ToDateTime(taskControl.EffectiveDate.ToString());
        DateTime expirationDate = Convert.ToDateTime(taskControl.ExpirationDate.ToString());
        DateTime cancelationDate = Convert.ToDateTime(txtSearchDate.Text.ToString());
        DateTime retroActiveDate = Convert.ToDateTime(taskControl.RetroactiveDate);

        if (cancelationDate < effectiveDate || cancelationDate > expirationDate)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Selected date must be within current policy's effective and expiration dates.");
            this.litPopUp.Visible = true;
            return false;
        }

        return true;
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
}
