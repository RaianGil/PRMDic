using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for PremiumWrittenbyAgent2.
    /// </summary>
    public partial class PremiumWrittenbyAgent2 : DataDynamics.ActiveReports.ActiveReport3
    {
        string _FromDate;
        string _ToDate;
        string _ReportType;
        bool _Summary = false;
        private Label Label275;
        string _mHeadCompany = "";

        public PremiumWrittenbyAgent2(string FromDate, string ToDate, string ReportType, bool Summary, string mHeadCompany)
        {
            _FromDate = FromDate;
            _ToDate = ToDate;
            _ReportType = ReportType;
            _Summary = Summary;
            _mHeadCompany = mHeadCompany;
            InitializeComponent();
        }

        private void PremiumWrittenbyAgent2_ReportStart(object sender, EventArgs e)
        {
            if (_Summary)
            {
                this.detail.Visible = false;
            }

            //this.Label275.Text =  _mHeadCompany;
            this.lblDate.Text = "Date:" + DateTime.Now.ToShortDateString();
            this.lblTime.Text = "Time:" + DateTime.Now.ToShortTimeString();

            if (!_FromDate.Trim().Equals("") || (!_FromDate.Trim().Equals("")))
            {
                this.lblCriterias.Text = _ReportType + " From: " + _FromDate + " To: " + _ToDate;
            }
        }
    }
}
