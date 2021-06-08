using System;
using System.Collections;
using System.Globalization;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EPolicy.XmlCooker;
using EPolicy.Audit;
using EPolicy;
using System.Xml;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.IO;
using Baldrich.DBRequest;
using System.Collections.Generic;
using EPolicy2.Reports;
using DataDynamics.ActiveReports;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.Linq;


public partial class AutomaticFinancialCancellation : System.Web.UI.Page
{
    #region Web Form Designer generated code

    override protected void OnInit(EventArgs e)
    {
        try
        {
            InitializeValue();
            GetCancellation(CancellationEffectiveDate.ToString());



            base.OnInit(e);
        }
        catch (Exception exp)
        {

        }

    }

    #endregion

    public string CancellationEffectiveDate { get; set; }
    private int userID;
    string finalFile = String.Empty;
    List<string> mergePaths = new List<string>();

    public void InitializeValue()
    {
        CancellationEffectiveDate = "10/12/2015";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
            if (cp == null)
            {
                Response.Redirect("HomePage.aspx?001");
            }
            else
            {
                if (!cp.IsInRole("AUTOMATICFINANCIALCANCELLATION") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    Response.Redirect("HomePage.aspx?001");
                }
            }

            userID = cp.UserID;

            if (!IsPostBack)
            {


                EPolicy.TaskControl.Policy taskControl;

                if (Session["TaskControl"] != null)
                {
                    taskControl = (EPolicy.TaskControl.Policy)Session["TaskControl"];
                }
                else
                {
                    taskControl = (EPolicy.TaskControl.Policy)Session["TaskControl"];
                    Session.Add("TaskControl", taskControl);
                }

                DataTable dt = GetCancellation(CancellationEffectiveDate);
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    DataRow dr = dt.Rows[i];


                    finalFile = Print(dr["FinancialDesc"].ToString(), dr["FinancialPhoneNo"].ToString(),
                    dr["ContractNo"].ToString(), dr["PolicyNo"].ToString(),
                    dr["FinancialCancellationsDate"].ToString(), dr["Firstna"].ToString().Trim(),
                    dr["Lastna1"].ToString().Trim(), dr["FinancialCancellationsBalance"].ToString(),
                    dr["AgencyDesc"].ToString(), dr["AgentDesc"].ToString(), dr["Term"].ToString(),
                    dr["InsuranceCompany"].ToString(), dr["PolicyType"].ToString(), dt.Rows.Count);
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + finalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);                    

                }
            }

        }
        catch (Exception exp)
        {

        }


    }

    public static DataTable GetCancellation(string CancellationEffectiveDate)
    {
        DataTable dt = new DataTable();

        try
        {
            DbRequestXmlCookRequestItem[] cookItems = new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("CancellationEffectiveDate",
                SqlDbType.VarChar, 15, CancellationEffectiveDate.ToString(),
                ref cookItems);

            XmlDocument xmldoc;

            try
            {
                xmldoc = DbRequestXmlCooker.Cook(cookItems);
            }

            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);

            }

            Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();

            dt = Executor.GetQuery("GetAutomaticFinancialByEffectiveDate", xmldoc);
        }
        catch (Exception xcp)
        {
            throw new Exception("Could not get report", xcp);
        }
        return dt;
    }

    private string Print(string FinancialDesc, string FinancialPhoneNo, string ContractNo, string PolicyNo, string FinancialCancellationDate, string Firstna, string Lastna1,
        string FinancialCancellationsBalance, string AgencyDesc, string AgentDesc, string Term, string InsuranceCompany, string PolicyType, int rowsCount)
    {
        EPolicy.TaskControl.Policy taskControl = (EPolicy.TaskControl.Policy)Session["TaskControl"];        
        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;        
        string _userID = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();
        _userID = _userID.ToString().Replace(" ", "");

        

       // string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];     

        try
        {
            string _FileName = "";

            //mergePaths.Add(_FileName);

            ReportViewer viewer = new ReportViewer();
            viewer.LocalReport.DataSources.Clear();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = Server.MapPath("Reports/CancellationNoticeFinancials.rdlc");
            viewer.LocalReport.DataSources.Clear();
            viewer.ProcessingMode = ProcessingMode.Local;
            


            ReportParameterInfoCollection paramCol = viewer.LocalReport.GetParameters();
            ReportParameter rp1 = new ReportParameter(paramCol[0].Name, FinancialDesc);
            ReportParameter rp2 = new ReportParameter(paramCol[1].Name, FinancialPhoneNo);
            ReportParameter rp3 = new ReportParameter(paramCol[2].Name, ContractNo);
            ReportParameter rp4 = new ReportParameter(paramCol[3].Name, PolicyNo);
            ReportParameter rp5 = new ReportParameter(paramCol[4].Name, FinancialCancellationDate);
            ReportParameter rp6 = new ReportParameter(paramCol[5].Name, Firstna + " " + Lastna1);


            //ReportParameter rp6 = new ReportParameter(paramCol[5].Name, taskControl.Customer.FirstName.ToString().Trim() + " " + taskControl.Customer.LastName1.ToString().Trim());


            if (!FinancialCancellationsBalance.Contains("."))
                FinancialCancellationsBalance += ".00";



            FinancialCancellationsBalance = double.Parse(FinancialCancellationsBalance.Replace("$", "")).ToString("$###,##0.00");

            ReportParameter rp7 = new ReportParameter(paramCol[6].Name, FinancialCancellationsBalance);
            ReportParameter rp8 = new ReportParameter(paramCol[7].Name, AgencyDesc);
            ReportParameter rp9 = new ReportParameter(paramCol[8].Name, AgentDesc);
            ReportParameter rp10 = new ReportParameter(paramCol[9].Name, Term);
            ReportParameter rp11 = new ReportParameter(paramCol[10].Name, InsuranceCompany);


            /*if (chkExpTerms.Checked)
                rp10 = new ReportParameter(paramCol[9].Name, "Balance Plazos Vencidos: ");
            else
                rp10 = new ReportParameter(paramCol[9].Name, "Balance Pendiente de Pago: ");*/



            viewer.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11 });
            viewer.LocalReport.Refresh();

            Warning[] warnings;
            string[] streamIds;
            string mimeType;
            string encoding = string.Empty;
            string extension;
            //------
            //string _FileName = "Financial Cancellation " + PolicyType.Trim() + "-" + PolicyNo.Trim() + "-" + DateTime.Now.Month.ToString().Trim() + "-" + DateTime.Now.Day.ToString().Trim() + "-" + DateTime.Now.Year.ToString().Trim() + ".pdf";
            string _FileNameNew = "FinancialCancellation" + PolicyType.Trim() + PolicyNo.Trim() + ".PDF";
            //------
            //Path added to exportfiles. Folder FinancialCancellation have todays date
            //-------------------------------+ "-" + DateTime.Now.Month.ToString().Trim() + "-" + DateTime.Now.Day.ToString().Trim() + "-" + DateTime.Now.Year.ToString().Trim()
            string path = @"C:\inetpub\wwwroot\PRMdic\exportfiles\FinancialCancellations\";

            _FileNameNew = _FileNameNew.Replace(",", "");
            _FileNameNew = _FileNameNew.Replace("&", "");
            _FileNameNew = _FileNameNew.Replace("/", "");

            if (File.Exists(_FileNameNew))
                File.Delete(_FileNameNew);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);              

            //using (FileStream fs = new FileStream(Path.Combine(path, _FileNameNew), FileMode.Create))
            using (FileStream fs = new FileStream(Server.MapPath("ExportFiles\\FinancialCancellations\\" + _FileNameNew), FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
                fs.Dispose();
                fs.Close();                
            }
            mergePaths.Add(Server.MapPath("ExportFiles\\FinancialCancellations\\" + _FileNameNew));

            EPolicy.CreatePDFBatch mergeFinal = new CreatePDFBatch();
            
            string _FinalFile = "";
            
            if (mergePaths.Count == rowsCount)
            {
                _FinalFile = mergeFinal.MergePDFFiles(mergePaths, path, "Financial Cancellations");
            }
                return _FileName;
            
  
        }
        
        catch (Exception ecp)
        {
            throw new Exception(ecp.Message);
        }
    }

}
