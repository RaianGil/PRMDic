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

public partial class CertificateFileUpload : System.Web.UI.Page
{
    private static int taskControlID;

    #region Protected Methods

    protected void Page_Load(object sender, EventArgs e)
    {
        this.litPopUp.Visible = false;
        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;

        Control Banner = new Control();
        Banner = LoadControl(@"TopBanner1.ascx");
        this.Placeholder1.Controls.Add(Banner);

        /*//Setup Left-side Banner			
        Control LeftMenu = new Control();
        LeftMenu = LoadControl(@"LeftMenu.ascx");
        phTopBanner1.Controls.Add(LeftMenu);*/

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
        }

        if (cp != null)
        {
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.PostedFile.FileName == "")
            {
                throw new Exception("Please select a file with browse button.");
            }

            string extension = FileUpload1.PostedFile.FileName.Substring(FileUpload1.PostedFile.FileName.Length - 4);

            if (extension != ".csv" && extension != ".CSV")
            {
                throw new Exception("Please select a CSV file.");
            }

            if (rblPaymentType.SelectedItem.Value == "0") //Policy Payment
            {
                try
                {
                    if (Path.GetFileName(FileUpload1.PostedFile.FileName) != "")  //Si no existe file no hace ninguna funcion.
                    {
                        if (FileUpload1.PostedFile != null)
                        {
                            EPolicy.TaskControl.Payments payments = new EPolicy.TaskControl.Payments();
                            payments.DeletePaymentImport();

                            string newnm = Path.GetFileName(FileUpload1.PostedFile.FileName);

                            FileUpload1.PostedFile.SaveAs(@System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + "Payment_Import" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".csv");
                            //FileUpload1.PostedFile.SaveAs(@"C:\Upload\" + newnm);
                            newnm = "Payment_Import" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".csv";
                            string testPath = @System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + newnm;
                            //ReviewFile(newnm);
                            ProcessFile(newnm);
                        }

                        PrintReport();

                        string attachedFile = Path.GetFileName(FileUpload1.PostedFile.FileName);
                        this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("File loaded and processed.");
                        this.litPopUp.Visible = true;
                    }
                }
                catch (Exception exp)
                {
                    this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("" + exp.Message);
                    this.litPopUp.Visible = true;
                    return;
                }
            }
            else if (rblPaymentType.SelectedItem.Value == "1") //Commission Payment
            {
                if (Path.GetFileName(FileUpload1.PostedFile.FileName) != "")  //Si no existe file no hace ninguna funcion.
                {
                    try
                    {
                        if (FileUpload1.PostedFile != null)
                        {
                            EPolicy.TaskControl.Payments payments = new EPolicy.TaskControl.Payments();
                            payments.DeletePaymentImport();

                            string newnm = Path.GetFileName(FileUpload1.PostedFile.FileName);

                            FileUpload1.PostedFile.SaveAs(@System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + "Payment_Import" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".csv");
                            //FileUpload1.PostedFile.SaveAs(@"C:\Upload\" + newnm);
                            newnm = "Payment_Import" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".csv";
                            string testPath = @System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + newnm;
                            //ReviewFile(newnm);
                            ProcessComissionFile(newnm);
                        }

                        PrintComissionReport();

                        string attachedFile = Path.GetFileName(FileUpload1.PostedFile.FileName);
                        this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("File loaded and processed.");
                        this.litPopUp.Visible = true;
                    }
                    catch (Exception exp)
                    {
                        this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("" + exp.Message);
                        this.litPopUp.Visible = true;
                        return;
                    }
                }
            }
        }
        catch (Exception exp)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("" + exp.Message);
            this.litPopUp.Visible = true;
            return;
        }
    }

    protected void PrintReport()
    {
        try
        {
            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
            string userName = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();

            ReportViewer1.Reset();
            ReportViewer1.LocalReport.ReportPath = ("Reports/ImportPaymentStatus.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;

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

            ReportViewer1.LocalReport.SetParameters(param);

            ReportViewer1.LocalReport.DataSources.Add(rptDataSource1);
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource2);
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource3);
            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.Visible = true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void PrintComissionReport()
    {
        try
        {
            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
            string userName = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();

            ReportViewer1.Reset();
            ReportViewer1.LocalReport.ReportPath = ("Reports/ImportComissionStatus.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;

            ImportPaymentStatusTableAdapters.GetPaymentImportByStatusCompletedTableAdapter ta1 =
                new ImportPaymentStatusTableAdapters.GetPaymentImportByStatusCompletedTableAdapter();

            ImportPaymentStatus.GetPaymentImportByStatusCompletedDataTable reportDt1 =
                new ImportPaymentStatus.GetPaymentImportByStatusCompletedDataTable();

            //ImportPaymentStatusTableAdapters.GetPaymentImportByStatusPendingTableAdapter ta2 =
            //    new ImportPaymentStatusTableAdapters.GetPaymentImportByStatusPendingTableAdapter();

            //ImportPaymentStatus.GetPaymentImportByStatusPendingDataTable reportDt2 =
            //    new ImportPaymentStatus.GetPaymentImportByStatusPendingDataTable();

            ImportPaymentStatusTableAdapters.GetPaymentImportByStatusFailedTableAdapter ta3 =
                new ImportPaymentStatusTableAdapters.GetPaymentImportByStatusFailedTableAdapter();

            ImportPaymentStatus.GetPaymentImportByStatusFailedDataTable reportDt3 =
                new ImportPaymentStatus.GetPaymentImportByStatusFailedDataTable();

            ta1.Fill(reportDt1, "1");
            //ta2.Fill(reportDt2, "2");
            ta3.Fill(reportDt3, "0");

            Microsoft.Reporting.WebForms.ReportDataSource rptDataSource1 =
            new Microsoft.Reporting.WebForms.ReportDataSource("ImportPaymentStatus_GetPaymentImportByStatusCompleted", (DataTable)reportDt1);

            //Microsoft.Reporting.WebForms.ReportDataSource rptDataSource2 =
            //new Microsoft.Reporting.WebForms.ReportDataSource("ImportPaymentStatus_GetPaymentImportByStatusPending", (DataTable)reportDt2);

            Microsoft.Reporting.WebForms.ReportDataSource rptDataSource3 =
            new Microsoft.Reporting.WebForms.ReportDataSource("ImportPaymentStatus_GetPaymentImportByStatusFailed", (DataTable)reportDt3);

            ReportParameter[] param = new ReportParameter[1];
            param[0] = new ReportParameter("userName", userName);

            ReportViewer1.LocalReport.SetParameters(param);

            ReportViewer1.LocalReport.DataSources.Add(rptDataSource1);
            //ReportViewer1.LocalReport.DataSources.Add(rptDataSource2);
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource3);
            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.Visible = true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void BtnExit_Click(object sender, EventArgs e)
    {
        RemoveSessionLookUp();
        Session.Clear();
        Response.Redirect("MainMenu.aspx");
    }

    #endregion

    #region Private Methods

    private void ProcessFile(string newnm)
    {
        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        int userID = 0;
        if (cp != null)
        {
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
        }

        try
        {
        StreamReader sr = File.OpenText(@System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + newnm);
        sr.ReadLine(); //Headers

            string temp = "";
            EPolicy.TaskControl.Payments payments = new EPolicy.TaskControl.Payments();

            for (int i = 0; i < 100000; i++)
            {
                
                    string line = "";
                    line = sr.ReadLine();
                    line = line.Replace('"', ' ');
                    temp = line.Replace('"', ' ');
                    //line = line.Replace(" ", "");

                    string[] line2 = line.Split(',');

                    DataTable dt = EPolicy.TaskControl.Payments.GetPolicyForPaymentImport(line2[4], line2[5], line2[6]);

                    if (dt.Rows.Count > 0)
                    {
                        EPolicy.TaskControl.TaskControl taskControl = Policy.GetTaskControlByTaskControlID((int)dt.Rows[0]["TaskControlID"], userID);
                        EPolicy.TaskControl.Policies policies = null;
                        EPolicy.TaskControl.CorporatePolicyQuote corPolicies = null;
                        EPolicy.TaskControl.Laboratory labPolicies = null;
                        EPolicy.TaskControl.Cyber cyberPolicies = null;
                        EPolicy.TaskControl.PaymentPolicy payDetails = new EPolicy.TaskControl.PaymentPolicy();

                        payDetails = PaymentPolicy.GetPaymentsByTaskControlID((Policy)taskControl);
                        DataTable DtTask = payDetails.PaymentsCollection;
                        bool exists = false;



                        if (line2[4] == "PP" || line2[4] == "PE" || line2[4] == "PPT" || line2[4] == "PET" || line2[4] == "AAP" || line2[4] == "AAE" || line2[4] == "AAPT" || line2[4] == "AAET")
                            policies = Policies.GetPolicies((int)dt.Rows[0]["TaskControlID"]);
                        else if (line2[4] == "CLP" || line2[4] == "CLE")
                            labPolicies = EPolicy.TaskControl.Laboratory.GetLaboratoryPolicy((int)dt.Rows[0]["TaskControlID"]);
                        else if (line2[4] == "CP" || line2[4] == "CE")
                            corPolicies = EPolicy.TaskControl.CorporatePolicyQuote.GetCorporatePolicyQuote((int)dt.Rows[0]["TaskControlID"], true);
                        else
                            cyberPolicies = EPolicy.TaskControl.Cyber.GetCyberPolicy((int)dt.Rows[0]["TaskControlID"]);

                        string reinstatement = "";

                        if (policies != null)
                            reinstatement = policies.Ren_Rei;
                        else if (corPolicies != null)
                            reinstatement = corPolicies.Ren_Rei;
                        else if (labPolicies != null)
                            reinstatement = labPolicies.Ren_Rei;

                        foreach (DataRow row in DtTask.Rows)
                        {
                            if (DateTime.Parse(row[3].ToString()).ToShortDateString() == DateTime.Parse(line2[1].ToString()).ToShortDateString() && float.Parse(row[4].ToString()) == float.Parse(line2[2].ToString()) && row[5].ToString().Trim() == line2[0].ToString().Trim())
                                exists = true;
                            
                            if(exists) break;
                        }

                        if(exists)
                            payments.InsertPolicyPaymentImport(i, line2[1], line2[0], line2[2], line2[3], line2[1], line2[4], line2[5], line2[6], "This payment already exists.", "0");
                        else if ((double)((Policy)taskControl).CancellationAmount > 0.00 && reinstatement != "RI")  //Se modifico para que acepte las polizas Reinstated
                        {
                            payments.InsertPolicyPaymentImport(i, line2[1], line2[0], line2[2], line2[3], line2[1], line2[4], line2[5], line2[6], "This Policy is cancelled.", "0");
                        }
                        //else if ((double)((Policy)taskControl).PaymentsDetail.TotalPaid >= ((Policy)taskControl).TotalPremium + ((Policy)taskControl).Charge)
                        //{
                        //    payments.InsertPolicyPaymentImport(i, line2[1], line2[0], line2[2], line2[3], line2[1], line2[4], line2[5], line2[6], "This Policy is already paid.", "0");
                        //}  ELIMINADO YA QUE SE ACEPTAN OVERPAYMENTS, 1-22-2014
                        else
                        {
                            AddCertificate(line2, i);
                            taskControl = Policy.GetTaskControlByTaskControlID((int)dt.Rows[0]["TaskControlID"], userID);
                            if ((double)((Policy)taskControl).PaymentsDetail.TotalPaid >= ((Policy)taskControl).TotalPremium + ((Policy)taskControl).Charge)
                            {
                                DataTable payDt = EPolicy.TaskControl.Payments.GetPaymentImportLossByCriteria(line2[1], line2[0], line2[2], line2[3], line2[1], line2[4], line2[5], line2[6]);
                                payments.InsertPolicyPaymentImport(i, line2[1], line2[0], line2[2], line2[3], line2[1], line2[4], line2[5], line2[6], "Payment Complete!", "1");

                                if(payDt.Rows.Count > 0)
                                    payments.UpdatePolicyPaymentLoss(int.Parse(payDt.Rows[0]["PaymentImportID"].ToString()), true);
                            }
                            else
                            {
                                payments.InsertPolicyPaymentImport(i, line2[1], line2[0], line2[2], line2[3], line2[1], line2[4], line2[5], line2[6], "Payment Pending: $" + ((((Policy)taskControl).TotalPremium + ((Policy)taskControl).Charge) - (double)((Policy)taskControl).PaymentsDetail.TotalPaid).ToString("###,###,##0.00"), "2");
                            }

                        }
                    }
                    else
                    {
                        payments.InsertPolicyPaymentImport(i, line2[1], line2[0], line2[2], line2[3], line2[1], line2[4], line2[5], line2[6], "Policy not found.", "0");
                        DataTable payDt = EPolicy.TaskControl.Payments.GetPaymentImportLossByCriteria(line2[1], line2[0], line2[2], line2[3], line2[1], line2[4], line2[5], line2[6]);
                        int result = 0;
                        
                        if ((line2[4] == "PP" || line2[4] == "PE" || line2[4] == "CP" || line2[4] == "CE" || line2[4] == "PPT" || line2[4] == "PET" || line2[4] == "CPT" || line2[4] == "CET" || line2[4] == "AAP" || line2[4] == "AEP" || line2[4] == "APC" || line2[4] == "AEC" || line2[4] == "AAPT" || line2[4] == "AEPT" || line2[4] == "APCT" || line2[4] == "AECT" || line2[4] == "CLP") 
                            && int.TryParse(line2[5], out result) && line2[5].Length <= 5 && payDt.Rows.Count == 0)
                        {
                            payments.InsertPolicyPaymentLoss(0, line2[1], line2[0], line2[2], line2[3], line2[1], line2[4], line2[5], line2[6], "Policy not found.", "0", false, userID, DateTime.Now.ToShortDateString());
                        }
                            
                        //payments.DeletePaymentImport(0, "");
                    }

                    if (sr.EndOfStream)
                    {
                        i = 100000;
                        sr.Close();
                    }
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

    private void ProcessComissionFile(string newnm)
    {
        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        int userID = 0;
        if (cp != null)
        {
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
        }

        try
        {
            StreamReader sr = File.OpenText(@System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + newnm);
            sr.ReadLine(); //Headers

            string temp = "";
            EPolicy.TaskControl.Payments payments = new EPolicy.TaskControl.Payments();
            

            for (int i = 0; i < 100000; i++)
            {

                string line = "";
                line = sr.ReadLine();
                line = line.Replace('"', ' ');
                temp = line.Replace('"', ' ');
                //line = line.Replace(" ", "");

                string[] line2 = line.Split(',');

                DataTable dt = EPolicy.TaskControl.Payments.GetPolicyForPaymentImport(line2[4], line2[5], line2[6]);

                if (dt.Rows.Count > 0)
                {
                    EPolicy.TaskControl.TaskControl taskControl = Policy.GetTaskControlByTaskControlID((int)dt.Rows[0]["TaskControlID"], userID);
                    DataTable dtComm = ObtainCommissionPayment(taskControl.TaskControlID);
                    EPolicy.LookupTables.Agent agent = new EPolicy.LookupTables.Agent();
                    agent = agent.GetAgent(taskControl.Agent);

                    if (((Policy)taskControl).PaidAmount < (((Policy)taskControl).TotalPremium + ((Policy)taskControl).Charge))
                    {
                        payments.InsertPolicyPaymentImport(i, line2[1], line2[0], line2[2], agent.AgentDesc, line2[1], line2[4], line2[5], line2[6], "Cannot apply comission payment to this policy's agent.", "0");
                    }
                    else if (dtComm.Rows.Count > 0)
                    {
                        payments.InsertPolicyPaymentImport(i, line2[1], line2[0], line2[2], agent.AgentDesc, line2[1], line2[4], line2[5], line2[6], "Comission payment already paid to this policy's agent.", "0");
                    }
                    else
                    {
                        taskControl = Policy.GetTaskControlByTaskControlID((int)dt.Rows[0]["TaskControlID"], userID);
                        FillProperties(line2);
                        payments = (EPolicy.TaskControl.Payments)Session["TaskControl"];

                        Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
                        try
                        {
                            Executor.BeginTrans();
                            Executor.Insert("AddComissionPayments",
                            GetInsertComissionPaymentsXml(taskControl,payments));
                            Executor.CommitTrans();
                        }
                        catch (Exception xcp)
                        {
                            Executor.RollBackTrans();
                            throw new Exception("Error while trying to update the payment. " + xcp.Message, xcp);
                        }

                        payments.InsertPolicyPaymentImport(i, line2[1], line2[0], line2[2], agent.AgentDesc, line2[1], line2[4], line2[5], line2[6], "Comission Payment Applied!", "1");
                    }
                }
                else
                {
                    payments.InsertPolicyPaymentImport(i, line2[1], line2[0], line2[2], "", line2[1], line2[4], line2[5], line2[6], "Policy not found.", "0");
                    //DataTable payDt = EPolicy.TaskControl.Payments.GetPaymentImportLossByCriteria(line2[1], line2[0], line2[2], line2[3], line2[1], line2[4], line2[5], line2[6]);
                    //int result = 0;

                    //if ((line2[4] == "PP" || line2[4] == "PE" || line2[4] == "CP" || line2[4] == "CE") && int.TryParse(line2[5], out result) && line2[5].Length <= 5 && payDt.Rows.Count == 0)
                    //{
                    //    payments.InsertPolicyPaymentLoss(0, line2[1], line2[0], line2[2], line2[3], line2[1], line2[4], line2[5], line2[6], "Policy not found.", "0", false, userID, DateTime.Now.ToShortDateString());
                    //}

                    ////payments.DeletePaymentImport(0, "");
                }

                if (sr.EndOfStream)
                {
                    i = 100000;
                    sr.Close();
                }
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

        taskControl.Save(158);

        //Luego de aplicar el pago, el sistema verifica el PaidAmount de la tabla de policy y lo actualiza

        EPolicy.TaskControl.TaskControl taskControlpol = EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(taskControl.TaskControlID, 1);
        Policy pol = new Policy();
        DataTable dt = EPolicy.TaskControl.Payments.GetPolicyForPaymentImport(taskControl.PolicyType, taskControl.PolicyNo, line2[6]);
        pol = Policy.GetPolicyByTaskControlID(int.Parse(dt.Rows[0]["TaskControlID"].ToString()), pol);
        //(Policy)taskControlpol;

        //double payAmount = double.Parse(TxtPaymentAmount.Text);
        double payAmount = double.Parse(taskControl.PaymentAmount.ToString());

        History(pol.TaskControlID, 158, "ADD", "PAYMENTS", "ADDED PAYMENT" + System.Environment.NewLine + "CHECK NO: " + taskControl.CheckNo.ToString()
        + System.Environment.NewLine + "NAME: " + taskControl.Name.ToString() + System.Environment.NewLine + "AMOUNT: " + payAmount.ToString("$###,###")
        + System.Environment.NewLine + "CHECK TYPE: " + "CREDIT" + System.Environment.NewLine + "PAYMENT DATE: " + taskControl.PaymentDate.ToString() + System.Environment.NewLine +
        "DEPOSIT DATE: " + taskControl.PaymentDate.ToString());

        PaymentPolicy pp = PaymentPolicy.GetPaymentsByTaskControlID(pol);

        string paidAmtST = pp.TotalPaid.ToString("###,###.00");
        double paidAmt = double.Parse(paidAmtST);
        PaymentPolicy.UpdatePolicyPaidAmount(pol.TaskControlID, paidAmt);
    }

    private void ReviewFile(string newnm)
    {
        string FileName = @System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + "\fileTemp.txt";
        //FileName = @"C:\Inetpub\wwwroot\Optima\VSC\OP" + file.Trim() + seq.ToString() + ".txt";
        StreamWriter sw;
        sw = File.CreateText(FileName);

        StreamReader sr = File.OpenText(@System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + newnm);
        string line = "";

        for (int i = 0; i < 100000; i++)
        {
            line = sr.ReadLine();
            line = line.Replace('"', ' ');
            line = line.Replace(" ", "");

            sw.WriteLine(line);

            if (sr.EndOfStream)
                i = 100000;
        }
        sw.Close();
        sr.Close();

        File.Copy(@System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + "\fileTemp.txt", @System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + newnm, true);
    }

    private void RemoveSessionLookUp()
    {
        Session.Remove("LookUpTables");
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
            Policy policy = new Policy();
            Policy.GetPolicyByTaskControlID(task.TaskControlID, policy);


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

            if (taskControl.PaymentAmount < 0)
                taskControl.CreditDebitID = 2;

            Session.Add("TaskControl", taskControl);
        }
        catch (Exception exp)
        {
            //this.litPopUp.Text = Utilities.MakeLiteralPopUpString("A problem occured filling class properties.");
            this.litPopUp.Visible = true;
        }
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

    #endregion

    protected void btnImportPayment_Click(object sender, EventArgs e)
    {
        pnlImportPayment.Visible = true;
        btnManageLossPayments.Visible = true;
    }
    protected void btnManageLossPayments_Click(object sender, EventArgs e)
    {
        Response.Redirect("LPManager.aspx");
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
       
    }
    protected void dtLossPaymentManager_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
       
    }
    protected void dtLossPaymentManager_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void dtLossPaymentManager_ItemCommand(object source, DataGridCommandEventArgs e)
    {
       
    }
    protected void btnDelete_Click1(object sender, EventArgs e)
    {
 
    }

    private XmlDocument GetInsertComissionPaymentsXml(EPolicy.TaskControl.TaskControl taskControl, EPolicy.TaskControl.Payments payments)
    {
        Policy policy = (Policy)taskControl;
        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        
        int userID = 0;
        if (cp != null)
        {
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
        }

        DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[9];

        DbRequestXmlCooker.AttachCookItem("ComissionPaymentID",
            SqlDbType.Int, 0, "0",
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("TaskControlID",
            SqlDbType.Int, 0, policy.TaskControlID.ToString(),
            ref cookItems);

        DateTime date = DateTime.Parse(payments.PaymentDate + " 12:01:00 AM");

        DbRequestXmlCooker.AttachCookItem("TransactionDate",
            SqlDbType.DateTime, 8, date.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("PaymentDate",
                SqlDbType.DateTime, 8, date.ToString(),
                ref cookItems);

        decimal PayAmt = 0;
        if (payments.CreditDebitID == 2) // Debit
        {
            PayAmt = Math.Abs((decimal)payments.PaymentAmount) * -1;
        }
        else
        {
            PayAmt = Math.Abs((decimal)payments.PaymentAmount);
        }

        DbRequestXmlCooker.AttachCookItem("TransactionAmount",
            SqlDbType.Money, 8, PayAmt.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("CheckNumber",
            SqlDbType.Char, 10, payments.CheckNo.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("CreditDebitID",
            SqlDbType.Int, 0, payments.CreditDebitID.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("DepositDate",
            SqlDbType.DateTime, 8, date.ToString(),
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
}
