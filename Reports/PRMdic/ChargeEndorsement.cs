using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for ActOfWar.
    /// </summary>
    public partial class ChargeEndorsement : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;
        public ChargeEndorsement(EPolicy.TaskControl.Policy taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void ChargeEndorsement_ReportStart(object sender, EventArgs e)
        {
            if (_taskcontrol.PolicyType.Trim() == "PP" || _taskcontrol.PolicyType.Trim() == "CP")
                txtEndorsement.Text = "P-114 " + DateTime.Now.ToString("MM/YYYY");
            else txtEndorsement.Text = "E-114 " + DateTime.Now.ToString("MM/YYYY"); 
        }
    }
}
