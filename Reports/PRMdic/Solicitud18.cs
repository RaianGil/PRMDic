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
    /// Summary description for Solicitud18.
    /// </summary>
    public partial class Solicitud18 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Application _taskcontrol;

        public Solicitud18(EPolicy.TaskControl.Application taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void Solicitud18_ReportStart(object sender, EventArgs e)
        {
            this.txt8ePayment.Text = _taskcontrol.App88ePayment.ToString();
            this.txt8fDate.Text = _taskcontrol.App88fDate;
            this.txt8fPaid.Text = _taskcontrol.App88fPaid.ToString();
            this.txt9Desc.Text = _taskcontrol.App89Desc;
            this.txtAllegation.Text = _taskcontrol.Allegation;
            this.txtConditionPatient.Text = _taskcontrol.ConditionPatient;
            this.txtDateOfIncident.Text = _taskcontrol.DateOfIncident;
            this.txtDateReported.Text = _taskcontrol.DateReported;
            this.txtInsuranceNameCarrier.Text = _taskcontrol.InsuranceNameCarrier;
            this.txtPatientName.Text = _taskcontrol.PatientName;

            if (_taskcontrol.Mca7)
            {
                chkMca7Y.Checked = true;
                chkMca7N.Checked = false;
            }
            else
            {
                chkMca7N.Checked = true;
                chkMca7Y.Checked = false;
            }

            if (_taskcontrol.Mca8a)
            {
                chkMca8a.Checked = true;
            }
            else
            {
                chkMca8a.Checked = false;
            }

            if (_taskcontrol.Mca8b)
            {
                chkMca8b.Checked = true;
            }
            else
            {
                chkMca8b.Checked = false;
            }

            if (_taskcontrol.Mca8c)
            {
                chkMca8c.Checked = true;
            }
            else
            {
                chkMca8c.Checked = false;
            }

            if (_taskcontrol.Mca8d)
            {
                chkMca8d.Checked = true;
            }
            else
            {
                chkMca8d.Checked = false;
            }

            if (_taskcontrol.Mca8e)
            {
                chkMca8e.Checked = true;
            }
            else
            {
                chkMca8e.Checked = false;
            }

            if (_taskcontrol.Mca8f)
            {
                chkMca8f.Checked = true;
            }
            else
            {
                chkMca8f.Checked = false;
            }

            if (_taskcontrol.Mca8g)
            {
                chkMca8g.Checked = true;
            }
            else
            {
                chkMca8g.Checked = false;
            }

            if (_taskcontrol.Mca8h)
            {
                chkMca8h.Checked = true;
            }
            else
            {
                chkMca8h.Checked = false;
            }

            if (_taskcontrol.Mca8i)
            {
                chkMca8i.Checked = true;
            }
            else
            {
                chkMca8i.Checked = false;
            }

            if (_taskcontrol.Mca8j)
            {
                chkMca8j.Checked = true;
            }
            else
            {
                chkMca8j.Checked = false;
            }

            if (_taskcontrol.Mca8k)
            {
                chkMca8k.Checked = true;
            }
            else
            {
                chkMca8k.Checked = false;
            }

            if (_taskcontrol.Mca8fc)
            {
                chkMca8fcY.Checked = true;
                chkMca8fcN.Checked = false;
            }
            else
            {
                chkMca8fcY.Checked = false;
                chkMca8fcN.Checked = true;
            }

            if (_taskcontrol.Mca8l)
            {
                chkMca8lY.Checked = true;
                chkMca8lN.Checked = false;
            }
            else
            {
                chkMca8lY.Checked = false;
                chkMca8lN.Checked = true;
            }

            if (_taskcontrol.Mca8m)
            {
                chkMca8mY.Checked = true;
                chkMca8mN.Checked = false;
            }
            else
            {
                chkMca8mY.Checked = false;
                chkMca8mN.Checked = true;
            }

        }
    }
}
