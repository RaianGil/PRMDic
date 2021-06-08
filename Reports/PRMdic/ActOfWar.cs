using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for ActOfWar.
    /// </summary>
    public partial class ActOfWar : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;
        public ActOfWar(EPolicy.TaskControl.Policy taskcontrol)
        {
            //
            // Required for Windows Form Designer support
            //
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void Charge_ReportStart(object sender, EventArgs e)
        {
            if (_taskcontrol.InsuranceCompany == "002")
            {
                picture2.Visible = true;
                textBox1.Visible = true;
            }
            else
            {
                picture2.Visible = false;
                textBox1.Visible = false;
            }
        }
    }
}
