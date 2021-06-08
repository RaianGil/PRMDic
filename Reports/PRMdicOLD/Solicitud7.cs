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
    /// Summary description for Solicitud7.
    /// </summary>
    public partial class Solicitud7 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Application _taskcontrol;

        public Solicitud7(EPolicy.TaskControl.Application taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void Solicitud7_ReportStart(object sender, EventArgs e)
        {
            if (_taskcontrol.McaLab)
                this.chkMcaLab.Checked = true;

            if (_taskcontrol.McaPhy)
                this.chkMcaPhy.Checked = true;

            if (_taskcontrol.McaXray)
                this.chkMcaXray.Checked = true;

            if (_taskcontrol.McaOther)
                this.chkMcaOther.Checked = true;

            if (_taskcontrol.McaNurseAnes)
                this.chkMcaNurseAnes.Checked = true;

            if (_taskcontrol.McaNurseMid)
                this.chkMcaNurseMid.Checked = true;

            if (_taskcontrol.McaNursePerf)
                this.chkMcaNursePerf.Checked = true;

            if (_taskcontrol.McaNursePrac)
                this.chkMcaNursePrac.Checked = true;

            if (_taskcontrol.McaOpto)
                this.chkMcaOpto.Checked = true;

            if (_taskcontrol.McaPhyAss)
                this.chkMcaPhyAss.Checked = true;

            if (_taskcontrol.McaPsych)
                this.chkMcaPsych.Checked = true;

            if (_taskcontrol.McaScrub)
                this.chkMcaScrub.Checked = true;

            if (_taskcontrol.McaSurgical)
                this.chkMcaSurgical.Checked = true;

            if (_taskcontrol.McaBlood)
                this.chkMcaBlood.Checked = true;

            if (_taskcontrol.McaBirthing)
                this.chkMcaBirthing.Checked = true;

            if (_taskcontrol.McaCity)
                this.chkMcaCity.Checked = true;

            if (_taskcontrol.McaClinic)
                this.chkMcaClinic.Checked = true;

            if (_taskcontrol.McaEmergency)
                this.chkMcaEmergency.Checked = true;

            if (_taskcontrol.McaEmerHospital)
                this.chkMcaEmerHospital.Checked = true;

            if (_taskcontrol.McaFreeStanding)
                this.chkMcaFreeStanding.Checked = true;

            if (_taskcontrol.McaHospital)
                this.chkMcaHospital.Checked = true;

            if (_taskcontrol.McaConva)
                this.chkMcaConva.Checked = true;

            if (_taskcontrol.McaPsy)
                this.chkMcaPsy.Checked = true;

            if (_taskcontrol.McaInd)
                this.chkMcaInd.Checked = true;

            if (_taskcontrol.McaLaboratory)
                this.chkMcaLaboratory.Checked = true;

            if (_taskcontrol.McaNursing)
                this.chkMcaNursing.Checked = true;

            if (_taskcontrol.McaSanitarium)
                this.chkMcaSanitarium.Checked = true;

            if (_taskcontrol.McaUrgent)
                this.chkMcaUrgent.Checked = true;

            if (_taskcontrol.McaXrayFacility)
                this.chkMcaXrayFacility.Checked = true;

            if (_taskcontrol.McaOtherHC)
                this.chkMcaOtherHC.Checked = true;

            this.txtHCInsured1.Text = _taskcontrol.HCInsured1;
            this.txtHCInsured2.Text = _taskcontrol.HCInsured2;
            this.txtHCInsured3.Text = _taskcontrol.HCInsured3;
            this.txtHCLimits1.Text = _taskcontrol.HCLimits1;
            this.txtHCLimits2.Text = _taskcontrol.HCLimits2;
            this.txtHCLimits3.Text = _taskcontrol.HCLimits3;
            this.txtHCName1.Text = _taskcontrol.HCName1;
            this.txtHCName2.Text = _taskcontrol.HCName2;
            this.txtHCName3.Text = _taskcontrol.HCName3;
            this.txtHCSpeciality1.Text = _taskcontrol.HCSpeciality1;
            this.txtHCSpecialty2.Text = _taskcontrol.HCSpecialty2;
            this.txtHCSpecialty3.Text = _taskcontrol.HCSpecialty3;
            this.txtLabEmp.Text = _taskcontrol.LabEmp;
            this.txtLabHours.Text = _taskcontrol.LabHours;
            this.txtNurseAnesEmp.Text = _taskcontrol.NurseAnesEmp;
            this.txtNurseAnesHours.Text = _taskcontrol.NurseAnesHours;
            this.txtNurseMidEmp.Text = _taskcontrol.NurseMidEmp;
            this.txtNurseMidHours.Text = _taskcontrol.NurseMidHours;
            this.txtNursePerfEmp.Text = _taskcontrol.NursePerfEmp;
            this.txtNursePerfHours.Text = _taskcontrol.NursePerfHours;
            this.txtNursePracEmp.Text = _taskcontrol.NursePracEmp;
            this.txtNursePracHours.Text = _taskcontrol.NursePracHours;
            this.txtOptoEmp.Text = _taskcontrol.OptoEmp;
            this.txtOptoHours.Text = _taskcontrol.OptoHours;
            this.txtOtherEmp.Text = _taskcontrol.OtherEmp;
            this.txtOtherHours.Text = _taskcontrol.OtherHours;
            this.txtPhyAssEmp.Text = _taskcontrol.PhyAssEmp;
            this.txtPhyAssHours.Text = _taskcontrol.PhyAssHours;
            this.txtPhyEmp.Text = _taskcontrol.PhyEmp;
            this.txtPhyHours.Text = _taskcontrol.PhyHours;
            this.txtPsychEmp.Text = _taskcontrol.PsychEmp;
            this.txtPsychHours.Text = _taskcontrol.PsychHours;
            this.txtScrubEmp.Text = _taskcontrol.ScrubEmp;
            this.txtScrubHours.Text = _taskcontrol.ScrubHours;
            this.txtSurgicalEmp.Text = _taskcontrol.SurgicalEmp;
            this.txtSurgicalHours.Text = _taskcontrol.SurgicalHours;
            this.txtXrayEmp.Text = _taskcontrol.XrayEmp;
            this.txtXrayHours.Text = _taskcontrol.XrayHours;        

        }
    }
}
