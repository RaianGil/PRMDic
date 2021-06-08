using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.Customer;
using EPolicy.LookupTables;
using EPolicy.TaskControl;

namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for Agreement4.
    /// </summary>
    public partial class Agreement4 : DataDynamics.ActiveReports.ActiveReport3
    {
        private string _CopyValue;
        private EPolicy.TaskControl.Policies _taskcontrol;

        public Agreement4(EPolicy.TaskControl.Policies taskcontrol, string CopyValue)
        {
            _taskcontrol = taskcontrol;
            _CopyValue = CopyValue;
            InitializeComponent();
        }

        private void detail_Format(object sender, EventArgs e)
        {

        }
    }
}
