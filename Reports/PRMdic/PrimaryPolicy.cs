using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for PrimaryPolicy.
    /// </summary>
    public partial class PrimaryPolicy : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;
        public PrimaryPolicy(EPolicy.TaskControl.Policy taskcontrol)
        {
            //
            // Required for Windows Form Designer support
            //
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void PrimaryPolicy_ReportStart(object sender, EventArgs e)
        {
        }

        private void PrimaryPolicy_ReportStart_1(object sender, EventArgs e)
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
