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
    /// Summary description for Solicitud11.
    /// </summary>
    public partial class Solicitud11 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Application _taskcontrol;

        public Solicitud11(EPolicy.TaskControl.Application taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void Solicitud11_ReportStart(object sender, EventArgs e)
        {

            if (_taskcontrol.Mca48b)
            {
                chkMca48bY.Checked = true;
                chkMca48bN.Checked = false;
            }
            else
            {
                chkMca48bY.Checked = false;
                chkMca48bN.Checked = true;
            }

            if (_taskcontrol.Mca48c)
            {
                chkMca48cY.Checked = true;
                chkMca48cN.Checked = false;
            }
            else
            {
                chkMca48cY.Checked = false;
                chkMca48cN.Checked = true;
            }

            if (_taskcontrol.Mca49)
            {
                chkMca49Y.Checked = true;
                chkMca49N.Checked = false;
            }
            else
            {
                chkMca49Y.Checked = false;
                chkMca49N.Checked = true;
            }

            if (_taskcontrol.Mca50)
            {
                chkMca50Y.Checked = true;
                chkMca50N.Checked = false;
            }
            else
            {
                chkMca50Y.Checked = false;
                chkMca50N.Checked = true;
            }

            if (_taskcontrol.Mca51)
            {
                chkMca51Y.Checked = true;
                chkMca51N.Checked = false;
            }
            else
            {
                chkMca51Y.Checked = false;
                chkMca51N.Checked = true;
            }

            if (_taskcontrol.Mca52)
            {
                chkMca52Y.Checked = true;
                chkMca52N.Checked = false;
            }
            else
            {
                chkMca52Y.Checked = false;
                chkMca52N.Checked = true;
            }

            if (_taskcontrol.Mca53)
            {
                chkMca53Y.Checked = true;
                chkMca53N.Checked = false;
            }
            else
            {
                chkMca53Y.Checked = false;
                chkMca53N.Checked = true;
            }

            if (_taskcontrol.Mca54)
            {
                chkMca54Y.Checked = true;
                chkMca54N.Checked = false;
            }
            else
            {
                chkMca54Y.Checked = false;
                chkMca54N.Checked = true;
            }

            if (_taskcontrol.Mca55)
            {
                chkMca55Y.Checked = true;
                chkMca55N.Checked = false;
            }
            else
            {
                chkMca55Y.Checked = false;
                chkMca55N.Checked = true;
            }

            if (_taskcontrol.Mca56)
            {
                chkMca56Y.Checked = true;
                chkMca56N.Checked = false;
            }
            else
            {
                chkMca56Y.Checked = false;
                chkMca56N.Checked = true;
            }

            if (_taskcontrol.Mca56First)
            {
                chkMca56FirstY.Checked = true;
                chkMca56FirstN.Checked = false;
            }
            else
            {
                chkMca56FirstY.Checked = false;
                chkMca56FirstN.Checked = true;
            }

            if (_taskcontrol.Mca56Second)
            {
                chkMca56SecondY.Checked = true;
                chkMca56SecondN.Checked = false;
            }
            else
            {
                chkMca56SecondY.Checked = false;
                chkMca56SecondN.Checked = true;
            }

            if (_taskcontrol.Mca56Third)
            {
                chkMca56ThirdY.Checked = true;
                chkMca56ThirdN.Checked = false;
            }
            else
            {
                chkMca56ThirdY.Checked = false;
                chkMca56ThirdN.Checked = true;
            }

            if (_taskcontrol.Mca57)
            {
                chkMca57Y.Checked = true;
                chkMca57N.Checked = false;
            }
            else
            {
                chkMca57Y.Checked = false;
                chkMca57N.Checked = true;
            }


            this.txt48Addr.Text = _taskcontrol.App648Addr;
            this.txt48Ent.Text = _taskcontrol.App648Ent;
            this.txt49Desc.Text = _taskcontrol.App648Ent;
            this.txt50Desc.Text = _taskcontrol.App650Desc;
            this.txt54b.Text = _taskcontrol.App654b;
            this.txt54c.Text = _taskcontrol.App654c;
            this.txt54d.Text = _taskcontrol.App654d;
            this.txt55Desc.Text = _taskcontrol.App655Desc;
            this.txtDesc56A.Text = _taskcontrol.Desc56A;
            this.txtDesc56B.Text = _taskcontrol.Desc56B;
            this.txtDesc56C.Text = _taskcontrol.Desc56C;     
            
            //Falta crear propiedad txt56Whom y campo en tabla application6
        }
    }
}
