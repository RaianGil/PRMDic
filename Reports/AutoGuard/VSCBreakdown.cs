using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.AutoGuard
{
    /// <summary>
    /// Summary description for VSCBreakdown.
    /// </summary>
    public partial class VSCBreakdown : DataDynamics.ActiveReports.ActiveReport3
    {
        string _FromDate;
        string _ToDate;
        string _ReportType;
        bool _Summary = false;
        string _mHeadCompany;

        public VSCBreakdown(string FromDate, string ToDate, string ReportType, bool Summary, string mHeadCompany)
        {
            _FromDate = FromDate;
            _ToDate = ToDate;
            _ReportType = ReportType;
            _Summary = Summary;
            _mHeadCompany = mHeadCompany;

            InitializeComponent();
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {

        }

        private void VSCBreakdown_ReportStart(object sender, EventArgs e)
        {
            this.LblCompanyHeader.Text = _mHeadCompany;
            if (_Summary)
            {
                this.detail.Visible = false;
            }
            this.lblDate.Text = "Date:" + DateTime.Now.ToShortDateString();
            this.lblTime.Text = "Time:" + DateTime.Now.ToShortTimeString();

            if (!_FromDate.Trim().Equals("") || (!_FromDate.Trim().Equals("")))
            {
                this.lblCriterias.Text = _ReportType + " From: " + _FromDate + " To: " + _ToDate;
            }
        }
    }
}
