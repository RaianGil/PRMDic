using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for PrimarySchedulerEndorsement.
    /// </summary>
    public partial class PrimarySchedulerEndorsement : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;

        public PrimarySchedulerEndorsement(EPolicy.TaskControl.Policy taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void PrimarySchedulerEndorsement_ReportStart(object sender, EventArgs e)
        {
            textBox1.Text = _taskcontrol.EffectiveDate.Trim();
            textBox2.Text = _taskcontrol.PolicyType.Trim() + "-" + _taskcontrol.PolicyNo.Trim();
           
            if (_taskcontrol.Charge != 0)
            {
                txtSurcharge1.Visible = true;
                txtSurcharge2.Visible = true;
                txtSurcharge3.Visible = true;
            }
        }
    }
}
