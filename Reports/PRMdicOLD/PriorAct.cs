using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for PriorAct.
    /// </summary>
    public partial class PriorAct : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;
        public PriorAct(EPolicy.TaskControl.Policy taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void PriorAct_ReportStart(object sender, EventArgs e)
        {
            txtpolNo.Text = _taskcontrol.PolicyType.ToString().Trim() + "-" + _taskcontrol.PolicyNo.ToString().Trim() + " " + _taskcontrol.Certificate.ToString().Trim();
            txtEffectiveDate.Text = _taskcontrol.EffectiveDate.ToString();
            txtRetro.Text = _taskcontrol.RetroactiveDate.ToString();
            txtEntryDate.Text = _taskcontrol.EntryDate.ToShortDateString();
            txtEntryDate2.Text = _taskcontrol.EntryDate.ToShortDateString();
            textBox1.Text = _taskcontrol.RetroactiveDate.ToString();

        }
    }
}
