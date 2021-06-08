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
    /// Summary description for Solicitud6.
    /// </summary>
    public partial class Solicitud6 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Application _taskcontrol;

        public Solicitud6(EPolicy.TaskControl.Application taskcontrol)
        {
            _taskcontrol = taskcontrol;

            InitializeComponent();
        }

        private void Solicitud6_ReportStart(object sender, EventArgs e)
        {
            this.txtEntAddr3.Text = _taskcontrol.EntAddr3;
            this.txtEntAddr4.Text = _taskcontrol.EntAddr4;
            this.txtEntAddr5.Text = _taskcontrol.EntAddr5;
            this.txtEntDate3.Text = _taskcontrol.EntDate3;
            this.txtEntDate4.Text = _taskcontrol.EntDate4;
            this.txtEntDate5.Text = _taskcontrol.EntDate5;
            this.txtEntName3.Text = _taskcontrol.EntName3;
            this.txtEntName4.Text = _taskcontrol.EntName4;
            this.txtEntName5.Text = _taskcontrol.EntName5;
            this.txtEntSpecialty3.Text = _taskcontrol.EntSpecialty3;
            this.txtEntSpecialty4.Text = _taskcontrol.EntSpecialty4;
            this.txtEntSpecialty5.Text = _taskcontrol.EntSpecialty5;
            this.txtPhyAssoc.Text = _taskcontrol.PhyAssoc;
            this.txtPhyEntName.Text = _taskcontrol.PhyEntName;
            this.txtPhyName.Text = _taskcontrol.PhyName;
            this.txtPhyPartners.Text = _taskcontrol.PhyPartners;
            this.txtPhyStatus.Text = _taskcontrol.PhyStatus;
            this.txtRefferralDesc.Text = _taskcontrol.RefferralDesc;

            if (_taskcontrol.McaOtherPhy)
            {
                chkMcaOtherPhyY.Checked = true;
                chkMcaOtherPhyN.Checked = false;
            }
            else
            {
                chkMcaOtherPhyY.Checked = false;
                chkMcaOtherPhyN.Checked = true;
            }

            if (_taskcontrol.McaRefferral)
            {
                chkMcaRefferralY.Checked = true;
                chkMcaRefferralN.Checked = false;
            }
            else
            {
                chkMcaRefferralY.Checked = false;
                chkMcaRefferralN.Checked = true;
            }



            ////
            if (_taskcontrol.McaPhysician)
            {
                chkMcaPhysician.Checked = true;
            }
            else
            {
                chkMcaPhysician.Checked = false;
            }

            if (_taskcontrol.McaEmpPhysician)
            {
                chkMcaEmpPhysician.Checked = true;
            }
            else
            {
                chkMcaEmpPhysician.Checked = false;
            }

            if (_taskcontrol.McaProfAss)
            {
                chkMcaProfAss.Checked = true;
            }
            else
            {
                chkMcaProfAss.Checked = false;
            }

            if (_taskcontrol.McaOther)
            {
                chkMcaOther.Checked = true;
            }
            else
            {
                chkMcaOther.Checked = false;
            }

            if (_taskcontrol.McaPartnership)
            {
                chkMcaPartnership.Checked = true;
            }
            else
            {
                chkMcaPartnership.Checked = false;
            }

            if (_taskcontrol.McaGroup)
            {
                chkMcaGroup.Checked = true;
            }
            else
            {
                chkMcaGroup.Checked = false;
            }

            if (_taskcontrol.McaProfCorp)
            {
                chkMcaProfCorp.Checked = true;
            }
            else
            {
                chkMcaProfCorp.Checked = false;
            }
        }
    }
}
