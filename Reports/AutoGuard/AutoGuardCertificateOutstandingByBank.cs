using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for AutoGuardCertificateOutstandingByBank.
    /// </summary>
    public partial class AutoGuardCertificateOutstandingByBank : DataDynamics.ActiveReports.ActiveReport3
    {
        string _ToDate;
        string _ReportType;
        bool _Summary = false;
        private Label LabelCom;
        string _mHeadCompany;
        public AutoGuardCertificateOutstandingByBank(string ToDate, string ReportType, bool Summary, string mHeadCompany)
        {
            _ToDate = ToDate;
            _ReportType = ReportType;
            _Summary = Summary;
            _mHeadCompany = mHeadCompany;

            InitializeComponent();
        }

        private void AutoGuardCertificateOutstandingByBank_ReportStart(object sender, EventArgs e)
        {
            LabelCom.Text = _mHeadCompany;
            if (_Summary)
            {
                this.detail.Visible = false;
            }

            this.lblDate.Text = "Date:" + DateTime.Now.ToShortDateString();
            this.lblTime.Text = "Time:" + DateTime.Now.ToShortTimeString();

            if (!_ToDate.Trim().Equals(""))
            {
                this.lblCriterias.Text = _ReportType + " As of: " + _ToDate;
            }
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {

        }
    }
}
