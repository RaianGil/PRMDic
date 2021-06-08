using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for Poliza.
    /// </summary>
    public partial class Poliza : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;
        public Poliza(EPolicy.TaskControl.Policy taskcontrol)
        {
            //
            // Required for Windows Form Designer support
            //
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void Poliza_ReportStart(object sender, EventArgs e)
        {
            if (_taskcontrol.InsuranceCompany == "002")
            {
                picture1.Visible = true;
            }
            else
            {
                picture1.Visible = false;
            }
        }
    }
}
