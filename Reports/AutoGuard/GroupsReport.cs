using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for GroupsReport.
    /// </summary>
    public partial class GroupsReport : DataDynamics.ActiveReports.ActiveReport3
    {
        string _FromDate;
        string _ToDate;
        string _ReportType;
        bool _Summary = false;
        string _mHeadCompany = "";

        public GroupsReport(string FromDate, string ToDate, string ReportType, bool Summary, string mHeadCompany)
        {
            _FromDate = FromDate;
            _ToDate = ToDate;
            _ReportType = ReportType;
            _Summary = Summary;
            _mHeadCompany = mHeadCompany;

            InitializeComponent();
        }

        private void GroupsReport_ReportStart_2(object sender, EventArgs e)
        {
            if (_Summary)
            {
                this.detail.Visible = false;
            }

            this.LblCompanyHeader.Text = _mHeadCompany;
            this.lblDate.Text = "Date:" + DateTime.Now.ToShortDateString();
            this.lblTime.Text = "Time:" + DateTime.Now.ToShortTimeString();

            //if (!_FromDate.Trim().Equals("") || (!_FromDate.Trim().Equals("")))
            //{
            this.lblCriterias.Text = "Entry Date From: " + _FromDate + " To: " + _ToDate;
            this.Label77.Text = _ReportType;
            //}
        }
    }
}
