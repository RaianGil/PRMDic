using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for PrimaryStatementAcceptance.
    /// </summary>
    public partial class PrimaryStatementAcceptance : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;
        private bool _certificate;

        public PrimaryStatementAcceptance(EPolicy.TaskControl.Policy taskcontrol,bool certificate)
        {
            //
            // Required for Windows Form Designer support
            //

            _taskcontrol = taskcontrol;
            _certificate = certificate;
            InitializeComponent();
        }

        private void PrimaryStatementAcceptance_ReportStart(object sender, EventArgs e)
        {
            if (_certificate)
            {
                lblCertificate.Visible = true;
                lblCertificate.Text = "Hereby it is certified that this is an exact and true copy of the original Policy No. " +
                    _taskcontrol.PolicyType.Trim() + "-" + _taskcontrol.PolicyNo.Trim() + " issued by PRMDIC in favor of " +
                    (_taskcontrol.PolicyType.Contains("C") ? "" : "Dr. ") +
                    _taskcontrol.Customer.FirstName + " " + _taskcontrol.Customer.LastName1 + " " + _taskcontrol.Customer.LastName2 + ".";
            }
        }
    }
}
