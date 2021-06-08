using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for P_116.
    /// </summary>
    public partial class P_116 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;

        public P_116(EPolicy.TaskControl.Policy taskcontrol)
        {
            //
            // Required for Windows Form Designer support
            //
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void P_116_ReportStart(object sender, EventArgs e)
        {
            txtPolicyNo.Text = _taskcontrol.PolicyType.Trim() + '-' + _taskcontrol.PolicyNo.ToString().Trim();

            txtCustomerName.Text = _taskcontrol.Customer.FirstName.Trim() + ' ' + _taskcontrol.Customer.Initial.Trim()
                                    + ' ' + _taskcontrol.Customer.LastName1.Trim() + ' ' + _taskcontrol.Customer.LastName2.Trim();

            txtEntryDate.Text = DateTime.Now.ToShortDateString(); //_taskcontrol.EntryDate.ToString().Trim();
        }
    }
}
