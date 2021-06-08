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
    /// Summary description for Solicitud12.
    /// </summary>
    public partial class Solicitud12 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Application _taskcontrol;
        public Solicitud12(EPolicy.TaskControl.Application taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void Solicitud12_ReportStart(object sender, EventArgs e)
        {

            if (_taskcontrol.Mca58)
            {
                chkMca58Y.Checked = true;
                chkMca58N.Checked = false;
            }
            else
            {
                chkMca58Y.Checked = false;
                chkMca58N.Checked = true;
            }

            if (_taskcontrol.Mca59)
            {
                chkMca59Y.Checked = true;
                chkMca59N.Checked = false;
            }
            else
            {
                chkMca59Y.Checked = false;
                chkMca59N.Checked = true;
            }

            if (_taskcontrol.Mca60)
            {
                chkMca60Y.Checked = true;
                chkMca60N.Checked = false;
            }
            else
            {
                chkMca60Y.Checked = false;
                chkMca60N.Checked = true;
            }

            if (_taskcontrol.Mca61)
            {
                chkMca61Y.Checked = true;
                chkMca61N.Checked = false;
            }
            else
            {
                chkMca61Y.Checked = false;
                chkMca61N.Checked = true;
            }

            if (_taskcontrol.Mca62)
            {
                chkMca62Y.Checked = true;
                chkMca62N.Checked = false;
            }
            else
            {
                chkMca62Y.Checked = false;
                chkMca62N.Checked = true;
            }

            if (_taskcontrol.Mca63)
            {
                chkMca63Y.Checked = true;
                chkMca63N.Checked = false;
            }
            else
            {
                chkMca63Y.Checked = false;
                chkMca63N.Checked = true;
            }


            this.txt57DescA.Text = _taskcontrol.App657DescA;
            this.txt57DescB.Text = _taskcontrol.App657DescB;
            this.txt58DescA.Text = _taskcontrol.App658DescA;


        }
    }
}
