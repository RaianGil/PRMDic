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

public partial class RDLCReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string dateFrom = (String)Session["dateFrom"];
                string dateTo = (String)Session["dateTo"];
                string agency = (String)Session["Agency"];
                string userName = (String)Session["userName"];

                if (agency == null)
                {
                    ReportViewer1.LocalReport.ReportPath = ("Reports/EndorsementsReport.rdlc");
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;

                    ReportParameterInfoCollection paramCol = ReportViewer1.LocalReport.GetParameters();
                    ReportParameter rp1 = new ReportParameter(paramCol[0].Name, userName);

                    ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1 });

                    EndorsementsReportTableAdapters.GetEndorsementsReportTableAdapter ta =
                    new EndorsementsReportTableAdapters.GetEndorsementsReportTableAdapter();

                    EndorsementsReport.GetEndorsementsReportDataTable reportDt =
                    new EndorsementsReport.GetEndorsementsReportDataTable();

                    ta.Fill(reportDt, dateFrom, dateTo);

                    Microsoft.Reporting.WebForms.ReportDataSource rptDataSource =
                    new Microsoft.Reporting.WebForms.ReportDataSource("EndorsementsReport_GetEndorsementsReport", (DataTable)reportDt);

                    ReportViewer1.LocalReport.DataSources.Add(rptDataSource);
                    ReportViewer1.LocalReport.Refresh();
                    ReportViewer1.Visible = true;
                }

                else if(agency == "financialcancellation"){

                    ReportViewer1.LocalReport.ReportPath = ("Reports/FinancialNoticeAgning.rdlc");
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;

                    ReportParameterInfoCollection paramCol = ReportViewer1.LocalReport.GetParameters();
                    ReportParameter rp1 = new ReportParameter(paramCol[0].Name, userName);

                    ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1 });

                    FinancialNoticeAgningTableAdapters.GetFinancialCancellationAgningTableAdapter ta = 
                    new FinancialNoticeAgningTableAdapters.GetFinancialCancellationAgningTableAdapter();
                    //EndorsementsReportTableAdapters.GetEndorsementsReportTableAdapter ta =
                    //new EndorsementsReportTableAdapters.GetEndorsementsReportTableAdapter();

                    FinancialNoticeAgning.GetFinancialCancellationAgningDataTable reportDt =
                    new FinancialNoticeAgning.GetFinancialCancellationAgningDataTable();
                    //EndorsementsReport.GetEndorsementsReportDataTable reportDt =
                    //new EndorsementsReport.GetEndorsementsReportDataTable();

                    ta.Fill(reportDt);

                    Microsoft.Reporting.WebForms.ReportDataSource rptDataSource =
                    new Microsoft.Reporting.WebForms.ReportDataSource("FinancialNoticeAgning_GetFinancialCancellationAgning", (DataTable)reportDt);

                    ReportViewer1.LocalReport.DataSources.Add(rptDataSource);
                    ReportViewer1.LocalReport.Refresh();
                    ReportViewer1.Visible = true;
                }
                else
                {
                    ReportViewer1.LocalReport.ReportPath = ("Reports/ComissionAging.rdlc");
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    string agencyDescription = "";

                    EPolicy.LookupTables.Agency agencyDesc = new EPolicy.LookupTables.Agency();
                    agencyDesc = agencyDesc.GetAgency(agency);
                    agencyDescription = agencyDesc.AgencyDesc;

                    ReportParameterInfoCollection paramCol = ReportViewer1.LocalReport.GetParameters();
                    ReportParameter rp1 = new ReportParameter(paramCol[0].Name, userName);
                    ReportParameter rp2 = new ReportParameter(paramCol[1].Name, agencyDescription);

                    ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1,rp2 });

                    GetComissionAgingTableAdapters.GetComissionAgingTableAdapter ta =
                    new GetComissionAgingTableAdapters.GetComissionAgingTableAdapter();

                    GetComissionAging.GetComissionAgingDataTable reportDt =
                    new GetComissionAging.GetComissionAgingDataTable();

                    ta.Fill(reportDt, dateFrom, agency);

                    Microsoft.Reporting.WebForms.ReportDataSource rptDataSource =
                    new Microsoft.Reporting.WebForms.ReportDataSource("GetComissionAging_GetComissionAging", (DataTable)reportDt);

                    ReportViewer1.LocalReport.DataSources.Add(rptDataSource);
                    ReportViewer1.LocalReport.Refresh();
                    ReportViewer1.Visible = true;
                }

            }
        }
}