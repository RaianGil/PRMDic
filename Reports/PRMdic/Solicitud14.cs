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
    /// Summary description for Solicitud14.
    /// </summary>
    public partial class Solicitud14 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Application _taskcontrol;
        public Solicitud14(EPolicy.TaskControl.Application taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void Solicitud14_ReportStart(object sender, EventArgs e)
        {

            if (_taskcontrol.Mca70)
            {
                chkMca70Y.Checked = true;
                chkMca70N.Checked = false;
            }
            else
            {
                chkMca70Y.Checked = false;
                chkMca70N.Checked = true;
            }

            if (_taskcontrol.Mca71)
            {
                chkMca71Y.Checked = true;
                chkMca71N.Checked = false;
            }
            else
            {
                chkMca71Y.Checked = false;
                chkMca71N.Checked = true;
            }

            if (_taskcontrol.Mca72)
            {
                chkMca72Y.Checked = true;
                chkMca72N.Checked = false;
            }
            else
            {
                chkMca72Y.Checked = false;
                chkMca72N.Checked = true;
            }

            if (_taskcontrol.Mca73a)
            {
                chkMca73aY.Checked = true;
                chkMca73aN.Checked = false;
            }
            else
            {
                chkMca73aY.Checked = false;
                chkMca73aN.Checked = true;
            }

            if (_taskcontrol.Mca73b)
            {
                chkMca73bY.Checked = true;
                chkMca73bN.Checked = false;
            }
            else
            {
                chkMca73bY.Checked = false;
                chkMca73bN.Checked = true;
            }

            if (_taskcontrol.Mca73c)
            {
                chkMca73cY.Checked = true;
                chkMca73cN.Checked = false;
            }
            else
            {
                chkMca73cY.Checked = false;
                chkMca73cN.Checked = true;
            }

            if (_taskcontrol.Mca73d)
            {
                chkMca73dY.Checked = true;
                chkMca73dN.Checked = false;
            }
            else
            {
                chkMca73dY.Checked = false;
                chkMca73dN.Checked = true;
            }
        }
    }
}
