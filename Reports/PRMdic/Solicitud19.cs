using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy;
using EPolicy.TaskControl;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for Solicitud19.
    /// </summary>
    public partial class Solicitud19 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Application _taskcontrol;

        public Solicitud19(EPolicy.TaskControl.Application taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }
    }
}
