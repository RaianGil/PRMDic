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
    public partial class Charge : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;
        public Charge(EPolicy.TaskControl.Policy taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void Charge_ReportStart(object sender, EventArgs e)
        {
            if (_taskcontrol.PolicyType.Trim() == "PP" || _taskcontrol.PolicyType.Trim() == "CP")
                txtEndorsement.Text = "P-114 (" + DateTime.Now.ToString("MM/yyyy") + ")";
            else txtEndorsement.Text = "E-114 (" + DateTime.Now.ToString("MM/yyyy") + ")"; 
        }
    }
}
