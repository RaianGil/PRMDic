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
    /// Summary description for Solicitud10.
    /// </summary>
    public partial class Solicitud10 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Application _taskcontrol;

        public Solicitud10(EPolicy.TaskControl.Application taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void Solicitud10_ReportStart(object sender, EventArgs e)
        {
            if (_taskcontrol.McaSpinLumbar)
                this.chkMcaSpinLumbar.Checked = true;

            if (_taskcontrol.McaSpinOther)
                this.chkMcaSpinOther.Checked = true;

            if (_taskcontrol.McaThora)
                this.chkMcaThora.Checked = true;

            if (_taskcontrol.McaUro)
                this.chkMcaUro.Checked = true;

            if (_taskcontrol.McaVas)
                this.chkMcaVas.Checked = true;

            if (_taskcontrol.Mca42a)
            {
                chkMca42aY.Checked = true;
                chkMca42aN.Checked = false;
            }
            else
            {
                chkMca42aY.Checked = false;
                chkMca42aN.Checked = true;
            }

            if (_taskcontrol.Mca42b)
            {
                chkMca42bY.Checked = true;
                chkMca42bN.Checked = false;
            }
            else
            {
                chkMca42bY.Checked = false;
                chkMca42bN.Checked = true;
            }

            if (_taskcontrol.Mca42c)
            {
                chkMca42cY.Checked = true;
                chkMca42cN.Checked = false;
            }
            else
            {
                chkMca42cY.Checked = false;
                chkMca42cN.Checked = true;
            }

            if (_taskcontrol.Mca42d)
            {
                chkMca42dY.Checked = true;
                chkMca42dN.Checked = false;
            }
            else
            {
                chkMca42dY.Checked = false;
                chkMca42dN.Checked = true;
            }

            if (_taskcontrol.Mca42e)
            {
                chkMca42eY.Checked = true;
                chkMca42eN.Checked = false;
            }
            else
            {
                chkMca42eY.Checked = false;
                chkMca42eN.Checked = true;
            }

            if (_taskcontrol.Mca42f)
            {
                chkMca42fY.Checked = true;
                chkMca42fN.Checked = false;
            }
            else
            {
                chkMca42fY.Checked = false;
                chkMca42fN.Checked = true;
            }

            if (_taskcontrol.Mca42h)
            {
                chkMca42hY.Checked = true;
                chkMca42hN.Checked = false;
            }
            else
            {
                chkMca42hY.Checked = false;
                chkMca42hN.Checked = true;
            }

            if (_taskcontrol.Mca42i)
            {
                chkMca42iY.Checked = true;
                chkMca42iN.Checked = false;
            }
            else
            {
                chkMca42iY.Checked = false;
                chkMca42iN.Checked = true;
            }

            if (_taskcontrol.Mca42j)
            {
                chkMca42jY.Checked = true;
                chkMca42jN.Checked = false;
            }
            else
            {
                chkMca42jY.Checked = false;
                chkMca42jN.Checked = true;
            }


            if (_taskcontrol.Mca42k)
            {
                chkMca42kY.Checked = true;
                chkMca42kN.Checked = false;
            }
            else
            {
                chkMca42kY.Checked = false;
                chkMca42kN.Checked = true;
            }

            if (_taskcontrol.Mca42l)
            {
                chkMca42lY.Checked = true;
                chkMca42lN.Checked = false;
            }
            else
            {
                chkMca42lY.Checked = false;
                chkMca42lN.Checked = true;
            }

            if (_taskcontrol.Mca44)
            {
                chkMca44Y.Checked = true;
                chkMca44N.Checked = false;
            }
            else
            {
                chkMca44Y.Checked = false;
                chkMca44N.Checked = true;
            }

            if (_taskcontrol.Mca45)
            {
                chkMca45Y.Checked = true;
                chkMca45N.Checked = false;
            }
            else
            {
                chkMca45Y.Checked = false;
                chkMca45N.Checked = true;
            }

            if (_taskcontrol.Mca46)
            {
                chkMca46Y.Checked = true;
                chkMca46N.Checked = false;
            }
            else
            {
                chkMca46Y.Checked = false;
                chkMca46N.Checked = true;
            }

            if (_taskcontrol.Mca47)
            {
                chkMca47Y.Checked = true;
                chkMca47N.Checked = false;
            }
            else
            {
                chkMca47Y.Checked = false;
                chkMca47N.Checked = true;
            }

            if (_taskcontrol.Mca47b)
            {
                chkMca47bY.Checked = true;
                chkMca47bN.Checked = false;
            }
            else
            {
                chkMca47bY.Checked = false;
                chkMca47bN.Checked = true;
            }

            if (_taskcontrol.Mca48)
            {
                chkMca48Y.Checked = true;
                chkMca48N.Checked = false;
            }
            else
            {
                chkMca48Y.Checked = false;
                chkMca48N.Checked = true;
            }



            this.txt43Desc.Text = _taskcontrol.App643Desc;
            this.txt44Desc.Text = _taskcontrol.App644Desc;
            this.txt47Addr.Text = _taskcontrol.App647Addr;
            this.txt47bPercent.Text = _taskcontrol.App647bPercent;
            this.txt47Inst.Text = _taskcontrol.App647Inst;
            this.txtMca42g.Text = _taskcontrol.Mca42g;
            this.txtMca42kDesc.Text = _taskcontrol.Mca42kDesc;
            this.txtMca42lDesc.Text = _taskcontrol.Mca42lDesc;
            this.txtSpinLumbarPercent.Text = _taskcontrol.SpinLumbarPercent;
            this.txtSpinLumbarYear.Text = _taskcontrol.SpinLumbarYear;
            this.txtSpinOtherPercent.Text = _taskcontrol.SpinOtherPercent;
            this.txtSpinOtherYear.Text = _taskcontrol.SpinOtherYear;
            this.txtThoraPercent.Text = _taskcontrol.ThoraPercent;
            this.txtThoraYear.Text = _taskcontrol.ThoraYear;
            this.txtUroPercent.Text = _taskcontrol.UroPercent;
            this.txtUroYear.Text = _taskcontrol.UroYear;
            this.txtVasPercent.Text = _taskcontrol.VasPercent;
            this.txtVasYear.Text = _taskcontrol.VasYear;
            

        }
    }
}
