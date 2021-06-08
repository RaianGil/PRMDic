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
    /// Summary description for Solicitud15.
    /// </summary>
    public partial class Solicitud15 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Application _taskcontrol;

        public Solicitud15(EPolicy.TaskControl.Application taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void Solicitud15_ReportStart(object sender, EventArgs e)
        {

            if (_taskcontrol.Mca73e)
            {
                chkMca73eY.Checked = true;
                chkMca73eN.Checked = false;
            }
            else
            {
                chkMca73eY.Checked = false;
                chkMca73eN.Checked = true;
            }

            if (_taskcontrol.Mca73f)
            {
                chkMca73fY.Checked = true;
                chkMca73fN.Checked = false;
            }
            else
            {
                chkMca73fY.Checked = false;
                chkMca73fN.Checked = true;
            }
        }
    }
}
