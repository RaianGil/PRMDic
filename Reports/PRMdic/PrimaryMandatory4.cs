using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for PrimaryMandatory3.
    /// </summary>
    public partial class PrimaryMandatory4 : DataDynamics.ActiveReports.ActiveReport3
    {
        //private EPolicy.TaskControl.Policy _taskcontrol;
        public PrimaryMandatory4()//EPolicy.TaskControl.Policy taskcontrol)
        {
            //_taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void PrimaryMandatory4_ReportStart(object sender, EventArgs e)
        {
            //if (_taskcontrol.PolicyType.Trim() == "PP" || _taskcontrol.PolicyType.Trim() == "CP")
                txtEndorsement.Text = "P-115 " ;//+ DateTime.Now.ToString("MM/YYYY");
            //else txtEndorsement.Text = "E-114 ";//+DateTime.Now.ToString("MM/YYYY");
        }
    }
}
