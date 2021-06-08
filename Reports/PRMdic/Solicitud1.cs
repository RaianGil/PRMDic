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
    /// Summary description for Solicitud1.
    /// </summary>
    public partial class Solicitud1 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Application _taskcontrol;

        public Solicitud1(EPolicy.TaskControl.Application taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void Solicitud1_ReportStart(object sender, EventArgs e)
        {
            txtLastName.Text = _taskcontrol.Customer.LastName1.Trim();
        }
    }
}
