using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.Customer;
using EPolicy.LookupTables;
using EPolicy.TaskControl;

namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for CLAUSULAHURACAN.
    /// </summary>
    public partial class CLAUSULAHURACAN : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.OptimaPersonalPackage _taskcontrol;
        private int _index = 0;

        public CLAUSULAHURACAN(EPolicy.TaskControl.OptimaPersonalPackage taskcontrol, string copy, int index)
        {
            _taskcontrol = taskcontrol;
            _index = index;
            InitializeComponent();
        }

        private void CLAUSULAHURACAN_ReportStart(object sender, EventArgs e)
        {
            txtPolicyNo.Text = _taskcontrol.PolicyType.ToString().ToUpper().Trim() + " " + _taskcontrol.PolicyNo.ToString().Trim() + " " + _taskcontrol.Certificate.ToString().Trim();
        }
    }
}
