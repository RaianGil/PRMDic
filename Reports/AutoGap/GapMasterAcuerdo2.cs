using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for GapMasterAcuerdo2.
    /// </summary>
    public partial class GapMasterAcuerdo2 : DataDynamics.ActiveReports.ActiveReport3
    {
        private string _CopyValue;
        private EPolicy.TaskControl.Policies _taskcontrol;

        public GapMasterAcuerdo2(EPolicy.TaskControl.Policies taskcontrol, string CopyValue)
        {
            _taskcontrol = taskcontrol;
            _CopyValue = CopyValue;

            InitializeComponent();
        }
    }
}
