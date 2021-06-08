using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Reporting.WebForms;
using System.ComponentModel;
using System.Web.SessionState;
using Baldrich.DBRequest;

public partial class RenewedPoliciesToPrint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = (DataTable)Session["RenewalPoliciesToPrint"];

            {
                ReportViewer.Reset();
                ReportViewer.LocalReport.ReportPath = ("Reports/RenewedPoliciesToPrint.rdlc");
                ReportViewer.LocalReport.DataSources.Clear();
                ReportViewer.ProcessingMode = ProcessingMode.Local;

                Microsoft.Reporting.WebForms.ReportDataSource rptDataSource1 =
                new Microsoft.Reporting.WebForms.ReportDataSource("GetRenewalsPoliciesToPrint_GetRenewedPoliciesToPrint", (DataTable)dt);

                ReportViewer.LocalReport.DataSources.Add(rptDataSource1);
                ReportViewer.LocalReport.Refresh();
                ReportViewer.Visible = true;
            }
        }
    }
}
