using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for Charge.
    /// </summary>
    public partial class ChargeEng : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;
        public ChargeEng(EPolicy.TaskControl.Policy taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void ChargeEng_ReportStart(object sender, EventArgs e)
        {
            if (_taskcontrol.PolicyType.Trim() == "PP" || _taskcontrol.PolicyType.Trim() == "CP")
                txtEndorsement.Text = "PRMD Form P-114 (09/2013).";
            else txtEndorsement.Text = "PRMD Form E-114 (09/2013)."; 
        }
    }
}
