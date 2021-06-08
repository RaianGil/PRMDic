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
    /// Summary description for Solicitud13.
    /// </summary>
    public partial class Solicitud13 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Application _taskcontrol;
        public Solicitud13(EPolicy.TaskControl.Application taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void Solicitud13_ReportStart(object sender, EventArgs e)
        {
            if (_taskcontrol.Mca64)
            {
                chkMca64Y.Checked = true;
                chkMca64N.Checked = false;
            }
            else
            {
                chkMca64Y.Checked = false;
                chkMca64N.Checked = true;
            }

            if (_taskcontrol.Mca65)
            {
                chkMca65Y.Checked = true;
                chkMca65N.Checked = false;
            }
            else
            {
                chkMca65Y.Checked = false;
                chkMca65N.Checked = true;
            }

            if (_taskcontrol.Mca66)
            {
                chkMca66Y.Checked = true;
                chkMca66N.Checked = false;
            }
            else
            {
                chkMca66Y.Checked = false;
                chkMca66N.Checked = true;
            }

            if (_taskcontrol.Mca67)
            {
                chkMca67Y.Checked = true;
                chkMca67N.Checked = false;
            }
            else
            {
                chkMca67Y.Checked = false;
                chkMca67N.Checked = true;
            }

            if (_taskcontrol.Mca68)
            {
                chkMca68Y.Checked = true;
                chkMca68N.Checked = false;
            }
            else
            {
                chkMca68Y.Checked = false;
                chkMca68N.Checked = true;
            }

            if (_taskcontrol.Mca69)
            {
                chkMca69Y.Checked = true;
                chkMca69N.Checked = false;
            }
            else
            {
                chkMca69Y.Checked = false;
                chkMca69N.Checked = true;
            }
        }
    }
}
