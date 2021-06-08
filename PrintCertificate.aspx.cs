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
using Baldrich.DBRequest;
using EPolicy.XmlCooker;
using System.Xml;
using System.Windows.Forms;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace EPolicy
{
    public partial class PrintCertificate : System.Web.UI.Page
    {


       public bool mergePathNew = true; //Para que el merge de PrintCertificate no de reset

       override protected void OnInit(EventArgs e)
       {
           //
           // CODEGEN: This call is required by the ASP.NET Web Form Designer.
           //
           InitializeComponent();
           base.OnInit(e);

           System.Web.UI.Control Banner = new System.Web.UI.Control();
           Banner = LoadControl(@"TopBanner1.ascx");
           //((Baldrich.BaldrichWeb.Components.TopBanner)Banner).SelectedOption = (int)Baldrich.HeadBanner.MenuOptions.Home;
           this.Placeholder1.Controls.Add(Banner);
       }
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
                DataTable dt = new DataTable();
                //EJC200
                DataTable historyDt = null;// Policy.GetCertificateHistoryByTaskControlID(taskControl.TaskControlID);
                DataTable dtHistoryTable = null;// Policy.GetCertificateHistoryForTable(taskControl.PolicyType, taskControl.PolicyNo);
                
                dtCertificateHistory.DataSource = dtHistoryTable;
                dtCertificateHistory.DataBind();
                //EJC200
                /*if (dtHistoryTable.Rows.Count > 0)
                {
                    dtCertificateHistory.Visible = true;
                    btnPrintAll.Visible = true;
                }
                else
                {
                    dtCertificateHistory.Visible = false;
                    btnPrintAll.Visible = false;
                }
                if (historyDt.Rows.Count != 0)
                {
                    dt.Columns.Add("Certificate Location");

                    for (int i = 0; i < historyDt.Rows.Count; i++)
                        dt.Rows.Add();

                    this.dtGridCertificateLocations.DataSource = dt;
                    this.dtGridCertificateLocations.DataBind();

                    for (int i = 0; i < historyDt.Rows.Count; i++)
                        ((DropDownList)dtGridCertificateLocations.Items[i].Cells[0].FindControl("ddlCertificateLocation")).SelectedIndex =
                        ((DropDownList)dtGridCertificateLocations.Items[i].Cells[0].FindControl("ddlCertificateLocation")).Items.IndexOf
                        (((DropDownList)dtGridCertificateLocations.Items[i].Cells[0].FindControl("ddlCertificateLocation")).Items.FindByValue
                        (historyDt.Rows[i]["CertificateLocationID"].ToString()));

                }
                else
                {
                    dt.Columns.Add("Certificate Location");

                    for (int i = 0; i < 1; i++)
                        dt.Rows.Add();

                    this.dtGridCertificateLocations.DataSource = dt;
                    this.dtGridCertificateLocations.DataBind();
                }

                lblPolicyNo.Text = "Policy No:" + taskControl.PolicyNo.ToString();
                txtGridCount.Text = dtGridCertificateLocations.Items.Count.ToString().Trim();
                EnableControls();*/
            }

            this.litPopUp.Visible = false;
        }

        private void InitializeComponent()
        {

        }
        protected void btnPrint_Click(object sender, System.EventArgs e)
        {
            TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
            string finalFile = String.Empty;

            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = 0;

            string errorMessage = String.Empty;

            try
            {
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Could not parse user id from cp.Identity.Name.", ex);
            }

            if (lblPolicyNo.Text.Trim() != "Policy No:" + taskControl.PolicyNo.ToString().Trim())
            {
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("WARNING! Policy Session changed!  Go back and select the previous policy or re-open this window.");
                this.litPopUp.Visible = true;
                return;
            }
            try
            {
                string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];
                List<string> mergePaths = new List<string>();
                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.DataSources.Clear();
                viewer.ProcessingMode = ProcessingMode.Local;

                if (txtGridCount.Text.Trim() == "")
                    txtGridCount.Text = "1";
                List<string> mergePathsCertificate = new List<string>();
                if (!chkSameAddress.Checked)
                {
                    for (int i = 0; i < dtGridCertificateLocations.Items.Count; i++)
                    {
                        if (!chkCancPrint.Checked && !chkRegPrint.Checked)
                        {
                            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("You must select a Print type.");
                            this.litPopUp.Visible = true;
                            return;
                        }
                        else
                        { //ARD
                           mergePaths = PrintCertificateReports(((DropDownList)dtGridCertificateLocations.Items[i].Cells[0].FindControl("ddlCertificateLocation")).SelectedValue.ToString(), i, mergePathsCertificate); //mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] +
                         
                           string CertificateID = ((DropDownList)dtGridCertificateLocations.Items[i].Cells[0].FindControl("ddlCertificateLocation")).SelectedValue.ToString();
                           DataTable dtGetExistNew = Policy.GetCertificateHistoryForTableExist(taskControl.PolicyType, taskControl.PolicyNo,int.Parse(CertificateID));

                               if (dtGetExistNew.Rows.Count <= 0)
                               {
                                   Policy.SaveCertificateHistory(taskControl.TaskControlID, ((DropDownList)dtGridCertificateLocations.Items[i].Cells[0].FindControl("ddlCertificateLocation")).SelectedValue.ToString());
                                   Policy.SaveCertificateHistoryForTable(taskControl.TaskControlID, ((DropDownList)dtGridCertificateLocations.Items[i].Cells[0].FindControl("ddlCertificateLocation")).SelectedValue.ToString(), "fasle");
                               }
                        }
                    }
                    History(taskControl.TaskControlID, userID);
                }
                else
                {
                    for (int i = 0; i < int.Parse(txtGridCount.Text.Trim()); i++)
                    {
                        if (!chkCancPrint.Checked && !chkRegPrint.Checked)
                        {
                            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("You must select a Print type.");
                            this.litPopUp.Visible = true;
                            return;
                        }
                        else
                        {
                            mergePaths = PrintCertificateReports(((DropDownList)dtGridCertificateLocations.Items[0].Cells[0].FindControl("ddlCertificateLocation")).SelectedValue.ToString(), i, mergePathsCertificate);  //mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] +
                            Policy.SaveCertificateHistory(taskControl.TaskControlID, ((DropDownList)dtGridCertificateLocations.Items[0].Cells[0].FindControl("ddlCertificateLocation")).SelectedValue.ToString());
                            Policy.SaveCertificateHistoryForTable(taskControl.TaskControlID, ((DropDownList)dtGridCertificateLocations.Items[i].Cells[0].FindControl("ddlCertificateLocation")).SelectedValue.ToString(), "false");
                        }
                    }
                    History(taskControl.TaskControlID, userID);
                }

                CreatePDFBatch mergeFinal = new CreatePDFBatch();

                finalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, "Certificado Poliza Primaria " + taskControl.PolicyNo.ToString().Trim());

                DataTable dtHistoryTable = Policy.GetCertificateHistoryForTable(taskControl.PolicyType, taskControl.PolicyNo);

                dtCertificateHistory.DataSource = dtHistoryTable;
                dtCertificateHistory.DataBind();

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + finalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
            }
            catch (Exception xp)
            {
                lblRecHeader.Text = xp.Message.ToString();
                mpeSeleccion.Show();
            }
        }
        protected void btnUpdate_Click(object sender, System.EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Certificate Location");

            if (chkSameAddress.Checked)
            {
                for (int i = 0; i < 1; i++)
                    dt.Rows.Add();

                this.dtGridCertificateLocations.DataSource = dt;
                this.dtGridCertificateLocations.DataBind();
            }
            else
            {
                try
                {
                    int index = int.Parse(txtGridCount.Text.Trim());

                    for (int i = 0; i < index; i++)
                    {
                        dt.Rows.Add();
                    }
                    this.dtGridCertificateLocations.DataSource = dt;
                    this.dtGridCertificateLocations.DataBind();

                    txtGridCount.Text = index.ToString();
                }
                catch
                {
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Empty or unknown number of certificates.");
                    this.litPopUp.Visible = true;
                    return;
                }
            }
        }
        protected void BtnExit_Click(object sender, System.EventArgs e)
        {
            Response.Write("<script>window.close();</" + "script>");
            Response.End();
        }
        private List<string> PrintCertificateReports(string certID, int counter, List<string> mergePaths)
        {
          
            TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];            
            
            //TaskControl.Laboratory taskControlLab = (TaskControl.Laboratory)Session["TaskControl"];
            //TaskControl.Cyber taskControlCyber = (TaskControl.Cyber)Session["TaskControl"];
            string _FileName = String.Empty;



            try
            {

                if (chkRegPrint.Checked)
                {
                    string ReportPath = "";
                    if (taskControl.PolicyType.Trim() == "PAH" || taskControl.PolicyType.Trim() == "CPA")
                    {
                        ReportPath = "Reports/Allied/AlliedPolicyCertificate.rdlc";
                    }
                    else
                    {
                       ReportPath = "Reports/PolicyCertificate.rdlc";
                    }
                    if (taskControl.PolicyType.Trim() == "CLP" || taskControl.PolicyType.Trim() == "CLE" || taskControl.PolicyType.Trim() == "ALP" || taskControl.PolicyType.Trim() == "ALE")
                    {
                        ReportPath = "Reports/LaboratoryPolicyCertificate.rdlc";
                    }
                    if (taskControl.PolicyType.Trim() == "CF" || taskControl.PolicyType.Trim() == "CFT" || taskControl.PolicyType.Trim() == "IF" || taskControl.PolicyType.Trim() == "IFT")
                    {
                        ReportPath = "Reports/FirstDollarPolicyCertificate.rdlc";
                    }

                    ReportViewer viewer = new ReportViewer();
                    viewer.LocalReport.ReportPath = Server.MapPath(ReportPath);
                    viewer.LocalReport.DataSources.Clear();
                    viewer.ProcessingMode = ProcessingMode.Local;


                    GetCertificateInformationTableAdapters.GetCertificateLocationByCertificateLocationIDTableAdapter ta1 =
                    new GetCertificateInformationTableAdapters.GetCertificateLocationByCertificateLocationIDTableAdapter();
                    GetCertificateInformationTableAdapters.GetCustomerCertificateInfoTableAdapter ta2 =
                    new GetCertificateInformationTableAdapters.GetCustomerCertificateInfoTableAdapter();
                    GetCertificateInformationTableAdapters.GetCertificateHistoryTableAdapter ta3 =
                    new GetCertificateInformationTableAdapters.GetCertificateHistoryTableAdapter();
                    GetCertificateInformationTableAdapters.GetPRMEDICSpecialtyByTaskControlIDTableAdapter ta4 =
                    new GetCertificateInformationTableAdapters.GetPRMEDICSpecialtyByTaskControlIDTableAdapter();

                    GetCustomerCertificatedInfoAlliedTableAdapters.GetCustomerCertificateInfoAlliedTableAdapter ta5 =
                    new GetCustomerCertificatedInfoAlliedTableAdapters.GetCustomerCertificateInfoAlliedTableAdapter();

                    GetCertificateInformation.GetCertificateLocationByCertificateLocationIDDataTable certDt =
                    new GetCertificateInformation.GetCertificateLocationByCertificateLocationIDDataTable();
                    GetCertificateInformation.GetCustomerCertificateInfoDataTable cusDt =
                    new GetCertificateInformation.GetCustomerCertificateInfoDataTable();
                    GetCertificateInformation.GetCertificateHistoryDataTable hisDt =
                    new GetCertificateInformation.GetCertificateHistoryDataTable();
                    GetCertificateInformation.GetPRMEDICSpecialtyByTaskControlIDDataTable specDt =
                    new GetCertificateInformation.GetPRMEDICSpecialtyByTaskControlIDDataTable();

                    GetCustomerCertificatedInfoAllied.GetCustomerCertificateInfoAlliedDataTable cusDt2 =
                    new GetCustomerCertificatedInfoAllied.GetCustomerCertificateInfoAlliedDataTable();

                    ta1.Fill(certDt, certID);
                    ta2.Fill(cusDt, taskControl.TaskControlID);
                    ta3.Fill(hisDt);
                    ta5.Fill(cusDt2, taskControl.TaskControlID);
                   // ta5.Fill(taskControl.TaskControlID);
                    string tempPolType = String.Empty;
                    if (taskControl.PolicyType.Trim() == "AAP" || taskControl.PolicyType.Trim() == "AAE")
                        tempPolType = "PP";
                    else if (taskControl.PolicyType.Trim() == "APC")
                        tempPolType = "CP";
                    else
                        tempPolType = taskControl.PolicyType.Trim();

                    ta4.Fill(specDt, tempPolType.Trim(), taskControl.TaskControlID);

                    if (taskControl.PolicyType.ToString().Trim() == "PP" || taskControl.PolicyType.ToString().Trim() == "PE" || taskControl.PolicyType.ToString().Trim() == "AAP" || taskControl.PolicyType.ToString().Trim() == "AAE")
                        cusDt.Rows[0]["CustomerName"] = "Dr. " + cusDt.Rows[0]["CustomerName"];
                    if (taskControl.PolicyType.Trim() == "EMD" || taskControl.PolicyType.Trim() == "EMDT")
                    {

                    }
                    else if (specDt.Rows.Count > 0)
                    {
                        if (specDt.Rows[0]["Other Specialty"].ToString() == "")
                            specDt.Rows[0]["Other Specialty"] = " ";
                        else specDt.Rows[0]["Other Specialty"] += " /";
                    }
                    else { }


                    Microsoft.Reporting.WebForms.ReportDataSource rptDataSource1 =
                    new Microsoft.Reporting.WebForms.ReportDataSource("GetCertificateInformation_GetCertificateLocationByCertificateLocationID", certDt);
                    Microsoft.Reporting.WebForms.ReportDataSource rptDataSource2 =
                    new Microsoft.Reporting.WebForms.ReportDataSource("GetCertificateInformation_GetCustomerCertificateInfo", cusDt);
                    Microsoft.Reporting.WebForms.ReportDataSource rptDataSource3 =
                    new Microsoft.Reporting.WebForms.ReportDataSource("GetCertificateInformation_GetCertificateHistory", hisDt);
                    Microsoft.Reporting.WebForms.ReportDataSource rptDataSource4 =
                    new Microsoft.Reporting.WebForms.ReportDataSource("GetCertificateInformation_GetPRMEDICSpecialtyByTaskControlID", specDt);
                    Microsoft.Reporting.WebForms.ReportDataSource rptDataSource5 =
                    new Microsoft.Reporting.WebForms.ReportDataSource("GetCustomerCertificatedInfoAllied_GetCustomerCertificateInfoAllied", cusDt2);
                    string agencydesc = "";
                    DataTable dt = new DataTable();
                    dt = GetAgencyDesc(taskControl.Agency);
                    agencydesc = dt.Rows[0]["AgencyDesc"].ToString().Trim();
                    string agentdesc = "";
                    DataTable dtagent = new DataTable();
                    dtagent = GetAgentDesc(int.Parse(taskControl.Agent));
                    agentdesc = dtagent.Rows[0]["AgentDesc"].ToString().Trim();


                    #region Gap Dates
                    if (taskControl.PolicyType.Trim() == "PP" || taskControl.PolicyType.Trim() == "PE" || taskControl.PolicyType.Trim() == "PPT" || taskControl.PolicyType.Trim() == "PET" || taskControl.PolicyType.Trim() == "AAP" || taskControl.PolicyType.Trim() == "AAPT" || taskControl.PolicyType.Trim() == "PAH" || taskControl.PolicyType.Trim() == "IF" || taskControl.PolicyType.Trim() == "AAE")
                    {
                        //-------Initialize reports parameters----
                        ReportParameter[] param = new ReportParameter[11];
                        //--------------------prueba certificado gap dates de PP------------------
                        if (taskControl.GapBegDate == "" || taskControl.GapEndDate == "")
                        {
                            param[0] = new ReportParameter("gapbegdate", "");
                            param[1] = new ReportParameter("gapenddate", "");
                        }
                        else
                        {
                            param[0] = new ReportParameter("gapbegdate", taskControl.GapBegDate.ToString().Trim());
                            param[1] = new ReportParameter("gapenddate", taskControl.GapEndDate.ToString().Trim());
                        }
                        if (taskControl.GapBegDate2 == "" || taskControl.GapEndDate2 == "")
                        {
                            param[2] = new ReportParameter("gapbegdate2", "");
                            param[3] = new ReportParameter("gapenddate2", "");

                        }
                        else
                        {
                            param[2] = new ReportParameter("gapbegdate2", taskControl.GapBegDate2.ToString().Trim());
                            param[3] = new ReportParameter("gapenddate2", taskControl.GapEndDate2.ToString().Trim());
                        }
                        if (taskControl.GapBegDate3 == "" || taskControl.GapEndDate3 == "")
                        {
                            param[4] = new ReportParameter("gapbegdate3", "");
                            param[5] = new ReportParameter("gapenddate3", "");
                        }
                        else
                        {
                            param[4] = new ReportParameter("gapbegdate3", taskControl.GapBegDate3.ToString().Trim());
                            param[5] = new ReportParameter("gapenddate3", taskControl.GapEndDate3.ToString().Trim());
                        }
                        if (taskControl.NumberOfEmployees == "")
                        {
                            param[6] = new ReportParameter("numberEmp", "0");
                        }
                        else
                        { 
                            param[6] = new ReportParameter("numberEmp", taskControl.NumberOfEmployees.ToString());
                        }

                         TaskControl.Policies taskControl2 = (TaskControl.Policies)Session["TaskControl"];
                         if (taskControl2.TotPremTN1 <= 0 && taskControl2.TotPremTN2 <= 0 && taskControl2.TotPremTN3 <= 0 && taskControl2.TotPremTN4 <= 0 && taskControl2.TotPremTN5 <= 0)
                        {
                            param[7] = new ReportParameter("otherPersonel", "0");
                        }
                        else
                        {

                             double Equantity1 = taskControl2.QuantityTN1;// == 0.0 ? 0.0 : 1.0 ;
                             double Equantity2 = taskControl2.QuantityTN2;// == 0.0 ? 0.0 : 1.0;
                             double Equantity3 = taskControl2.QuantityTN3;// == 0.0 ? 0.0 : 1.0;
                             double Equantity4 =  taskControl2.QuantityTN4;// == 0.0 ? 0.0 : 1.0;
                             double Equantity5 = taskControl2.QuantityTN5;// == 0.0 ? 0.0 : 1.0;
                             double EquantityLast = taskControl2.QuantityTN6;// == 0.0 ? 0.0 : 1.0;


                             string LastResult = EquantityLast.ToString();


                             param[7] = new ReportParameter("otherPersonel", LastResult);

                        }
                        param[8] = new ReportParameter("agencydesc", agencydesc);
                        param[9] = new ReportParameter("agentdesc", agentdesc);
                        param[10] = new ReportParameter("addName", taskControl.AdditionalName.ToString().Trim());
                        //---------------------------termina prueba certificado gap dates------------
                        viewer.LocalReport.SetParameters(param);
                        viewer.LocalReport.Refresh();
                    }
                    else if (taskControl.PolicyType.Trim() == "CP" || taskControl.PolicyType.Trim() == "CE" || taskControl.PolicyType.Trim() == "CPT" || taskControl.PolicyType.Trim() == "CET" || taskControl.PolicyType.Trim() == "APC" || taskControl.PolicyType.Trim() == "CPA" || taskControl.PolicyType.Trim() == "CF" || taskControl.PolicyType.Trim() == "CFT")
                    {
                        TaskControl.CorporatePolicyQuote taskControlCorporate = (TaskControl.CorporatePolicyQuote)Session["TaskControl"];
                        //-------Initialize reports parameters----
                        ReportParameter[] param = new ReportParameter[11];
                        //--------------------prueba certificado gap dates de CP------------------
                        if (taskControlCorporate.GapBegDate == "" || taskControlCorporate.GapEndDate == "")
                        {
                            param[0] = new ReportParameter("gapbegdate", "");
                            param[1] = new ReportParameter("gapenddate", "");
                        }
                        else
                        {
                            param[0] = new ReportParameter("gapbegdate", taskControlCorporate.GapBegDate.ToString());
                            param[1] = new ReportParameter("gapenddate", taskControlCorporate.GapEndDate.ToString());
                        }
                        if (taskControlCorporate.GapBegDate2 == "" || taskControlCorporate.GapEndDate2 == "")
                        {
                            param[2] = new ReportParameter("gapbegdate2", "");
                            param[3] = new ReportParameter("gapenddate2", "");

                        }
                        else
                        {
                            param[2] = new ReportParameter("gapbegdate2", taskControlCorporate.GapBegDate2.ToString());
                            param[3] = new ReportParameter("gapenddate2", taskControlCorporate.GapEndDate2.ToString());
                        }
                        if (taskControlCorporate.GapBegDate3 == "" || taskControlCorporate.GapEndDate3 == "")
                        {
                            param[4] = new ReportParameter("gapbegdate3", "");
                            param[5] = new ReportParameter("gapenddate3", "");
                        }
                        else
                        {
                            param[4] = new ReportParameter("gapbegdate3", taskControlCorporate.GapBegDate3.ToString());
                            param[5] = new ReportParameter("gapenddate3", taskControlCorporate.GapEndDate3.ToString());
                        }
                        if (taskControlCorporate.NumberOfEmployees == "")
                        {
                            param[6] = new ReportParameter("numberEmp", "");
                        }
                        else
                        {
                            param[6] = new ReportParameter("numberEmp", taskControlCorporate.NumberOfEmployees.ToString());
                        }
                        if (taskControlCorporate.OtherPersonel == "")
                        {
                            param[7] = new ReportParameter("otherPersonel", "0");
                        }
                        else
                        {
                            param[7] = new ReportParameter("otherPersonel", taskControlCorporate.OtherPersonel.ToString());
                        }
                        param[8] = new ReportParameter("agencydesc", agencydesc);
                        param[9] = new ReportParameter("agentdesc", agentdesc);
                        param[10] = new ReportParameter("addName", taskControlCorporate.AdditionalName.ToString().Trim());
                        //---------------------------termina prueba certificado gap dates------------
                        viewer.LocalReport.SetParameters(param);
                        viewer.LocalReport.Refresh();
                    }
                    else if (taskControl.PolicyType.Trim() == "CLP" || taskControl.PolicyType.Trim() == "CLE" || taskControl.PolicyType.Trim() == "CLPT" || taskControl.PolicyType.Trim() == "CLET" || taskControl.PolicyType.Trim() == "ALP")
                    {
                        TaskControl.Laboratory taskControlLab = (TaskControl.Laboratory)Session["TaskControl"];
                        //-------Initialize reports parameters----
                        ReportParameter[] param = new ReportParameter[12];

                        //--------------------prueba certificado gap dates de CLP------------------
                        if (taskControlLab.GapBegDate == "" || taskControlLab.GapEndDate == "")
                        {
                            param[0] = new ReportParameter("gapbegdate", "");
                            param[1] = new ReportParameter("gapenddate", "");
                        }
                        else
                        {
                            param[0] = new ReportParameter("gapbegdate", taskControlLab.GapBegDate.ToString());
                            param[1] = new ReportParameter("gapenddate", taskControlLab.GapEndDate.ToString());
                        }
                        if (taskControlLab.GapBegDate2 == "" || taskControlLab.GapEndDate2 == "")
                        {
                            param[2] = new ReportParameter("gapbegdate2", "");
                            param[3] = new ReportParameter("gapenddate2", "");

                        }
                        else
                        {
                            param[2] = new ReportParameter("gapbegdate2", taskControlLab.GapBegDate2.ToString());
                            param[3] = new ReportParameter("gapenddate2", taskControlLab.GapEndDate2.ToString());
                        }
                        if (taskControlLab.GapBegDate3 == "" || taskControlLab.GapEndDate3 == "")
                        {
                            param[4] = new ReportParameter("gapbegdate3", "");
                            param[5] = new ReportParameter("gapenddate3", "");
                        }
                        else
                        {
                            param[4] = new ReportParameter("gapbegdate3", taskControlLab.GapBegDate3.ToString());
                            param[5] = new ReportParameter("gapenddate3", taskControlLab.GapEndDate3.ToString());
                        }
                        if (taskControlLab.NumberOfEmployees == "")
                        {
                            param[6] = new ReportParameter("numberEmp", "");
                        }
                        else
                        {
                            param[6] = new ReportParameter("numberEmp", taskControlLab.NumberOfEmployees.ToString());
                        }

                        param[7] = new ReportParameter("limitDesc1", taskControlLab.LimitsDesc.Split('/')[0].ToString());
                        param[8] = new ReportParameter("limitDesc2", taskControlLab.LimitsDesc.Split('/')[1].ToString());
                        param[9] = new ReportParameter("agencydesc", agencydesc);
                        param[10] = new ReportParameter("agentdesc", agentdesc);
                        param[11] = new ReportParameter("addName", taskControlLab.AdditionalName.ToString().Trim());
                        //---------------------------termina prueba certificado gap dates------------
                        viewer.LocalReport.SetParameters(param);
                        viewer.LocalReport.Refresh();
                    }
                    else
                    {
                        TaskControl.Cyber taskControlCyber = (TaskControl.Cyber)Session["TaskControl"];
                        //-------Initialize reports parameters----
                        ReportParameter[] param = new ReportParameter[9];
                        //--------------------prueba certificado gap dates de PP------------------
                        if (taskControlCyber.GapBegDate == "" || taskControlCyber.GapEndDate == "")
                        {
                            param[0] = new ReportParameter("gapbegdate", "");
                            param[1] = new ReportParameter("gapenddate", "");
                        }
                        else
                        {
                            param[0] = new ReportParameter("gapbegdate", taskControlCyber.GapBegDate.ToString());
                            param[1] = new ReportParameter("gapenddate", taskControlCyber.GapEndDate.ToString());
                        }
                        if (taskControlCyber.GapBegDate2 == "" || taskControlCyber.GapEndDate2 == "")
                        {
                            param[2] = new ReportParameter("gapbegdate2", "");
                            param[3] = new ReportParameter("gapenddate2", "");

                        }
                        else
                        {
                            param[2] = new ReportParameter("gapbegdate2", taskControlCyber.GapBegDate2.ToString());
                            param[3] = new ReportParameter("gapenddate2", taskControlCyber.GapEndDate2.ToString());
                        }
                        if (taskControlCyber.GapBegDate3 == "" || taskControlCyber.GapEndDate3 == "")
                        {
                            param[4] = new ReportParameter("gapbegdate3", "");
                            param[5] = new ReportParameter("gapenddate3", "");
                        }
                        else
                        {
                            param[4] = new ReportParameter("gapbegdate3", taskControlCyber.GapBegDate3.ToString());
                            param[5] = new ReportParameter("gapenddate3", taskControlCyber.GapEndDate3.ToString());
                        }
                        param[6] = new ReportParameter("agencydesc", agencydesc);
                        param[7] = new ReportParameter("agentdesc", agentdesc);
                        param[8] = new ReportParameter("addName", taskControlCyber.AdditionalName.ToString().Trim());
                        //---------------------------termina prueba certificado gap dates------------
                        viewer.LocalReport.SetParameters(param);
                        viewer.LocalReport.Refresh();
                    }
                    #endregion

                    viewer.LocalReport.DataSources.Add(rptDataSource1);
                    viewer.LocalReport.DataSources.Add(rptDataSource2);
                    viewer.LocalReport.DataSources.Add(rptDataSource3);
                    viewer.LocalReport.DataSources.Add(rptDataSource4);
                    viewer.LocalReport.DataSources.Add(rptDataSource5);
                    viewer.LocalReport.Refresh();

                    ReportParameterInfoCollection paramCol = viewer.LocalReport.GetParameters();
                    ReportParameter rp1 = new ReportParameter(paramCol[0].Name, certID);
                    ReportParameter rp2 = new ReportParameter(paramCol[1].Name, taskControl.InsuranceCompany);

                    viewer.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2 });

                    // Variables 
                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType;
                    string encoding = string.Empty;
                    string extension;
                    string fileName = VerifyFileName(@cusDt.Rows[0]["CustomerName"].ToString().Trim() + counter);
                    _FileName = VerifyFileName(@cusDt.Rows[0]["CustomerName"].ToString().Trim() + counter + ".pdf");

                    //Ññ
                    if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                        File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

                    byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                    using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }
                    mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

                }
                if (chkCancPrint.Checked)
                {
                    ReportViewer viewer = new ReportViewer();
                    viewer.LocalReport.ReportPath = Server.MapPath("Reports/CancellationCertificate.rdlc");
                    viewer.LocalReport.DataSources.Clear();
                    viewer.ProcessingMode = ProcessingMode.Local;

                    GetCertificateInformationTableAdapters.GetCertificateLocationByCertificateLocationIDTableAdapter ta1 =
                    new GetCertificateInformationTableAdapters.GetCertificateLocationByCertificateLocationIDTableAdapter();
                    GetCertificateInformationTableAdapters.GetCustomerCertificateInfoTableAdapter ta2 =
                    new GetCertificateInformationTableAdapters.GetCustomerCertificateInfoTableAdapter();
                    GetCertificateInformationTableAdapters.GetCertificateHistoryTableAdapter ta3 =
                    new GetCertificateInformationTableAdapters.GetCertificateHistoryTableAdapter();
                    GetCertificateInformationTableAdapters.GetPRMEDICSpecialtyByTaskControlIDTableAdapter ta4 =
                    new GetCertificateInformationTableAdapters.GetPRMEDICSpecialtyByTaskControlIDTableAdapter();

                    GetCertificateInformation.GetCertificateLocationByCertificateLocationIDDataTable certDt =
                    new GetCertificateInformation.GetCertificateLocationByCertificateLocationIDDataTable();
                    GetCertificateInformation.GetCustomerCertificateInfoDataTable cusDt =
                    new GetCertificateInformation.GetCustomerCertificateInfoDataTable();
                    GetCertificateInformation.GetCertificateHistoryDataTable hisDt =
                    new GetCertificateInformation.GetCertificateHistoryDataTable();
                    GetCertificateInformation.GetPRMEDICSpecialtyByTaskControlIDDataTable specDt =
                    new GetCertificateInformation.GetPRMEDICSpecialtyByTaskControlIDDataTable();

                    ta1.Fill(certDt, certID);
                    ta2.Fill(cusDt, taskControl.TaskControlID);
                    ta3.Fill(hisDt);
                    ta4.Fill(specDt, taskControl.PolicyType.ToString().Trim(), taskControl.TaskControlID);

                    Microsoft.Reporting.WebForms.ReportDataSource rptDataSource1 =
                    new Microsoft.Reporting.WebForms.ReportDataSource("GetCertificateInformation_GetCertificateLocationByCertificateLocationID", certDt);
                    Microsoft.Reporting.WebForms.ReportDataSource rptDataSource2 =
                    new Microsoft.Reporting.WebForms.ReportDataSource("GetCertificateInformation_GetCustomerCertificateInfo", cusDt);
                    Microsoft.Reporting.WebForms.ReportDataSource rptDataSource3 =
                    new Microsoft.Reporting.WebForms.ReportDataSource("GetCertificateInformation_GetCertificateHistory", hisDt);
                    Microsoft.Reporting.WebForms.ReportDataSource rptDataSource4 =
                    new Microsoft.Reporting.WebForms.ReportDataSource("GetCertificateInformation_GetPRMEDICSpecialtyByTaskControlID", specDt);

                    ReportParameter[] param = new ReportParameter[6];
                    param[0] = new ReportParameter("PolicyID", taskControl.PolicyType.Trim() + "-" + taskControl.PolicyNo.ToString().Trim());
                    param[1] = new ReportParameter("EffectiveDate", taskControl.EffectiveDate.ToString());
                    param[2] = new ReportParameter("CancellationDate", taskControl.CancellationDate.ToString());
                    param[3] = new ReportParameter("SpanishDate", DateTime.Now.ToString("dd \\de MMMM \\de yyyy", new CultureInfo("es-ES")));
                    param[4] = new ReportParameter("ExpirationDate", taskControl.ExpirationDate.ToString());
                    param[5] = new ReportParameter("insuranceCompany", taskControl.InsuranceCompany.ToString());

                    viewer.LocalReport.SetParameters(param);
                    viewer.LocalReport.Refresh();

                    viewer.LocalReport.DataSources.Add(rptDataSource1);
                    viewer.LocalReport.DataSources.Add(rptDataSource2);
                    viewer.LocalReport.DataSources.Add(rptDataSource3);
                    viewer.LocalReport.DataSources.Add(rptDataSource4);
                    viewer.LocalReport.Refresh();

                    // Variables 
                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType;
                    string encoding = string.Empty;
                    string extension;
                    string fileName = VerifyFileName(@cusDt.Rows[0]["CustomerName"].ToString().Trim() + counter);
                    _FileName = VerifyFileName(@cusDt.Rows[0]["CustomerName"].ToString().Trim() + counter + ".pdf");
                    //Ññ
                    if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                        File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

                    byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                    using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }
                    mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

                }
               
            }
            catch (Exception ecp)
            {
                throw new Exception(ecp.Message + "/" + ecp.InnerException);
            }

            return mergePaths;
        }
        private void History(int taskControlID, int userID)
        {
            Audit.History history = new Audit.History();
            TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
            DataTable historyDt = Policy.GetCertificateHistoryByTaskControlID(taskControl.TaskControlID);
            string subject;

            history.Actions = "PRINT";
            subject = "PRINT CERTIFICATE " + "\r\n"
                    + "COPIES: " + txtGridCount.Text.Trim() + "\r\n"
                    + "CERTIFICATE IDs: " + "\r\n";

            if (chkSameAddress.Checked)
                for (int i = 0; i < int.Parse(txtGridCount.Text.ToString().Trim()); i++)
                    subject += ((DropDownList)dtGridCertificateLocations.Items[0].Cells[0].FindControl("ddlCertificateLocation")).SelectedValue.ToString().Trim() + " " + ((DropDownList)dtGridCertificateLocations.Items[0].Cells[0].FindControl("ddlCertificateLocation")).SelectedItem.ToString().Trim() + "\r\n";
            else
                for (int i = 0; i < int.Parse(txtGridCount.Text.ToString().Trim()); i++)
                    subject += ((DropDownList)dtGridCertificateLocations.Items[i].Cells[0].FindControl("ddlCertificateLocation")).SelectedValue.ToString().Trim() + " " + ((DropDownList)dtGridCertificateLocations.Items[i].Cells[0].FindControl("ddlCertificateLocation")).SelectedItem.ToString().Trim() + "\r\n";

            history.KeyID = taskControlID.ToString();
            history.Subject = "POLICIES";
            //history.BuildNotesForHistory("TaskControlID.", "", taskControlID.ToString(), 7);  //7 = mode NOTICEOFCANC
            history.UsersID = userID;
            history.Notes = "[CERTIFICATE] " + subject + "\r\n";
            history.GetSaveHistory();
        }
        private void HistoryPrintAll(int taskControlID, int userID)
        {
            Audit.History history = new Audit.History();
            TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
            DataTable historyDt = Policy.GetCertificateHistoryForTable(taskControl.PolicyType, taskControl.PolicyNo);
            string subject;

            history.Actions = "PRINT";
            subject = "PRINT CERTIFICATE " + "\r\n"
                    + "COPIES: " + historyDt.Rows.Count + "\r\n"
                    + "CERTIFICATE IDs: " + "\r\n";


            for (int i = 0; i < historyDt.Rows.Count; i++)
                    subject += (historyDt.Rows[i]["CertificateLocationID"].ToString() + " " + historyDt.Rows[i]["CertificateLocationDesc"].ToString() + "\r\n");

            history.KeyID = taskControlID.ToString();
            history.Subject = "POLICIES";
            //history.BuildNotesForHistory("TaskControlID.", "", taskControlID.ToString(), 7);  //7 = mode NOTICEOFCANC
            history.UsersID = userID;
            history.Notes = "[CERTIFICATE] " + subject + "\r\n";
            history.GetSaveHistory();
        }
        
        private string VerifyFileName(string fileName)
        {
            if (fileName.Contains("/"))
            {
                fileName = fileName.Replace("/", "_");
            }

            if (fileName.Contains("\\"))
            {
                fileName = fileName.Replace("\\", "_");
            }

            if (fileName.Contains("|"))
            {
                fileName = fileName.Replace("|", "_");
            }

            if (fileName.Contains(":"))
            {
                fileName = fileName.Replace(":", "_");
            }

            if (fileName.Contains("*"))
            {
                fileName = fileName.Replace("*", "_");
            }

            if (fileName.Contains("?"))
            {
                fileName = fileName.Replace("?", "_");
            }

            if (fileName.Contains("\""))
            {
                fileName = fileName.Replace("\"", "_");
            }

            if (fileName.Contains("<"))
            {
                fileName = fileName.Replace("<", "_");
            }

            if (fileName.Contains(">"))
            {
                fileName = fileName.Replace(">", "_");
            }

            return fileName;
        }

        //protected void FieldVerify()
        //{
        //    string errorMessage = String.Empty;
        //    for (int i = 0; i <= dtGridCertificateLocations.Items.Count - 1; i++)
        //    {
        //        if (((DropDownList)dtGridCertificateLocations.Items[i].Cells[0].FindControl("ddlCertificateLocation")).SelectedIndex == 0)
        //            errorMessage = "One or more fields on the grid are empty.";
        //    }


        //    if (errorMessage != String.Empty)
        //    {
        //this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + errorMessage);
        //        this.litPopUp.Visible = true;
        //        return;
        //    }
        //}
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
        private void EnableControls()
        {
            TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];

            if (taskControl.CancellationEntryDate != "")
            {
                chkCancPrint.Visible = true;
            }
            else
            {
                chkCancPrint.Visible = false;
            }
        }
        protected void dtCertificateHistory_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = 0;
            userID = cp.UserID;
               

            switch(e.CommandName)
            {
                case "Delete":
                    {
                        int certificateID = int.Parse(e.Item.Cells[0].Text.ToString()); //Certificate History ID
                        Policy.DeleteCertificateHistoryForTable(certificateID);
                        //dtCertificateHistory.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;
                        DataTable dtHistoryTable = Policy.GetCertificateHistoryForTable(taskControl.PolicyType, taskControl.PolicyNo);
                        dtCertificateHistory.DataSource = dtHistoryTable;
                        dtCertificateHistory.DataBind();

                        if (dtHistoryTable.Rows.Count > 0)
                            dtCertificateHistory.Visible = true;
                        else
                            dtCertificateHistory.Visible = false;
                    }
                    break;
                case "Print":
                    {
                        if (!chkCancPrint.Checked && !chkRegPrint.Checked)
                        {
                            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("You must select a Print type.");
                            this.litPopUp.Visible = true;
                            return;
                        }
                        else
                        {
                            string finalFile = String.Empty;
                            string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];
                            List<string> mergePaths = new List<string>();
                            List<string> mergePathsCertificate = new List<string>();
                            mergePaths = PrintCertificateReports(e.Item.Cells[2].Text.ToString(), 1, mergePathsCertificate);

                            CreatePDFBatch mergeFinal = new CreatePDFBatch();

                            finalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, "Certificado Poliza Primaria " + taskControl.TaskControlID);

                            Audit.History history = new Audit.History();
                            string subject = "";
                            subject = "PRINT CERTIFICATE " + "\r\n"
                                      + "COPIES: " + "1" + "\r\n"
                                      + "CERTIFICATE IDs: " + "\r\n";
                            subject += e.Item.Cells[2].Text.ToString() + " " + e.Item.Cells[1].Text.ToString();
                            history.KeyID = taskControl.TaskControlID.ToString() ;
                            history.Subject = "POLICIES";
                            history.Actions = "PRINT";
                            history.UsersID = userID;
                            history.Notes = "[CERTIFICATE] " + subject + "\r\n";
                            history.GetSaveHistory();



                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + finalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
                        }
                    }
                    break;
                default://Pager
                    {                        
                        dtCertificateHistory.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                        DataTable dtHistoryTable = Policy.GetCertificateHistoryForTable(taskControl.PolicyType, taskControl.PolicyNo);
                        dtCertificateHistory.DataSource = dtHistoryTable;
                        dtCertificateHistory.DataBind();
                    }
                    break;
            }
                
            
        }

        protected void btnPrintAll_Click(object sender, EventArgs e)
        {
            TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
            Login.Login cp = HttpContext.Current.User as Login.Login;
            int userID = 0;
            userID = cp.UserID;

            if (!chkCancPrint.Checked && !chkRegPrint.Checked)
            {
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("You must select a Print type.");
                this.litPopUp.Visible = true;
                return;
            }
            else
            {
                string finalFile = String.Empty;
                string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];
                List<string> mergePaths = new List<string>();
                List<string> mergePathsCertificate = new List<string>();
                int counter = 0;
                DataTable dtHistoryTable = Policy.GetCertificateHistoryForTable(taskControl.PolicyType, taskControl.PolicyNo);

                for (int i = 0; i < dtHistoryTable.Rows.Count; i++)
                {
                    mergePaths = PrintCertificateReports(dtHistoryTable.Rows[i]["CertificateLocationID"].ToString(), counter + i, mergePathsCertificate);
                }
                CreatePDFBatch mergeFinal = new CreatePDFBatch();

                finalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, "Certificado Poliza Primaria " + taskControl.TaskControlID);

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + finalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);

                HistoryPrintAll(taskControl.TaskControlID, userID);
            }
        }
}

}
