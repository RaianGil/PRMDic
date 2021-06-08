using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for PrimaryPriorAct.
    /// </summary>
    public partial class PrimaryPriorAct : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;

        public PrimaryPriorAct(EPolicy.TaskControl.Policy taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void PrimaryPriorAct_ReportStart(object sender, EventArgs e)
        {
            txtpolNo.Text = _taskcontrol.PolicyType.Trim() + "-" + _taskcontrol.PolicyNo.Trim();
            txtEffectiveDate.Text = _taskcontrol.EffectiveDate.Trim();
            txtRetro.Text = _taskcontrol.RetroactiveDate.Trim();
            txtEntryDate.Text = _taskcontrol.EntryDate.ToShortDateString();
            txtEntryDate2.Text = DateTime.Now.ToShortDateString();
        }
    }
}
