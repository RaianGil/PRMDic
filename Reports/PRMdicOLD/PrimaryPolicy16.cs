using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for PrimaryPolicy16.
    /// </summary>
    public partial class PrimaryPolicy16 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;

        public PrimaryPolicy16(EPolicy.TaskControl.Policy taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void PrimaryPolicy16_ReportStart(object sender, EventArgs e)
        {
            textBox1.Text = _taskcontrol.EntryDate.ToShortDateString();
        }
    }
}
