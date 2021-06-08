using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for Renewal.
    /// </summary>
    public partial class Renewal : DataDynamics.ActiveReports.ActiveReport3
    {
        string _FromDate;
        string _ToDate;
        string _ReportType;
        bool _Summary = false;
        string _mHeadCompany = "";

        public Renewal(string FromDate, string ToDate, string ReportType, bool Summary, string mHeadCompany)
        {
            _FromDate = FromDate;
            _ToDate = ToDate;
            _ReportType = ReportType;
            _Summary = Summary;
            _mHeadCompany = mHeadCompany;

            InitializeComponent();
        }

        private void Renewal_ReportStart(object sender, System.EventArgs eArgs)
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
            this.lblCriterias.Text = _ReportType; // +" From: " + _FromDate + " To: " + _ToDate;
            //}
        }

        private void Renewal_ReportStart_1(object sender, EventArgs e)
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
            this.lblCriterias.Text = _ReportType; // +" From: " + _FromDate + " To: " + _ToDate;
            //}
        }
    }
}
