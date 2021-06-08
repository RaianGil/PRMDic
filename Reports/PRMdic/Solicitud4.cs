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
    /// Summary description for Solicitud4.
    /// </summary>
    public partial class Solicitud4 : DataDynamics.ActiveReports.ActiveReport3
    {

        private EPolicy.TaskControl.Application _taskcontrol;
        public Solicitud4(EPolicy.TaskControl.Application taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void Solicitud4_ReportStart(object sender, EventArgs e)
        {
            this.txtBoardDate.Text = _taskcontrol.BoardDate;
            this.txtBoardExamDesc.Text = _taskcontrol.BoardExamDesc;
            this.txtBoardFailedSpecialty.Text = _taskcontrol.BoardFailedSpecialty;
            this.txtLicNumber1.Text = _taskcontrol.LicNumber1;
            this.txtLicNumber2.Text = _taskcontrol.LicNumber2;
            this.txtLicNumber3.Text = _taskcontrol.LicNumber3;
            this.txtLicState1.Text = _taskcontrol.LicState1;
            this.txtLicState2.Text = _taskcontrol.LicState2;
            this.txtLicState3.Text = _taskcontrol.LicState3;
            this.txtLicStatus1.Text = _taskcontrol.LicStatus1;
            this.txtLicStatus2.Text = _taskcontrol.LicStatus2;
            this.txtLicStatus3.Text = _taskcontrol.LicStatus3;
            this.txtLicYear1.Text = _taskcontrol.LicYear1;
            this.txtLicYear2.Text = _taskcontrol.LicYear2;
            this.txtLicYear3.Text = _taskcontrol.LicYear3;
            this.txtMedSocietiesDesc.Text = _taskcontrol.MedSocietiesDesc;
            this.txtMilitaryDesc.Text = _taskcontrol.MilitaryDesc;
            this.txtNationalSocietiesDesc.Text = _taskcontrol.NationalSocietiesDesc;
            this.txtOralResult.Text = _taskcontrol.OralResult;
            this.txtOralWhen.Text = _taskcontrol.OralWhen;
            this.txtWrittenResult.Text = _taskcontrol.WrittenResult;
            this.txtWrittenWhen.Text = _taskcontrol.WrittenWhen;

            if (_taskcontrol.McaBoardExam)
            {
                ChkMcaBoardExamY.Checked = true;
                ChkMcaBoardExamN.Checked = false;
            }
            else
            {
                ChkMcaBoardExamY.Checked = false;
                ChkMcaBoardExamN.Checked = true;
            }

            if (_taskcontrol.McaFailedBoardExam)
            {
                ChkMcaFailedBoardExamY.Checked = true;
                ChkMcaFailedBoardExamN.Checked = false;
            }
            else
            {
                ChkMcaFailedBoardExamY.Checked = false;
                ChkMcaFailedBoardExamN.Checked = true;
            }

            if (_taskcontrol.McaMilitary)
            {
                ChkMcaMilitaryY.Checked = true;
                ChkMcaMilitaryN.Checked = false;
            }
            else
            {
                ChkMcaMilitaryY.Checked = false;
                ChkMcaMilitaryN.Checked = true;
            }

            if (_taskcontrol.McaMilitaryReserve)
            {
                ChkMcaMilitaryReserveY.Checked = true;
                ChkMcaMilitaryReserveN.Checked = false;
            }
            else
            {
                ChkMcaMilitaryReserveY.Checked = false;
                ChkMcaMilitaryReserveN.Checked = true;
            }

            if (_taskcontrol.McaMedSocieties)
            {
                ChkMcaMedSocietiesY.Checked = true;
                ChkMcaMedSocietiesN.Checked = false;
            }
            else
            {
                ChkMcaMedSocietiesY.Checked = false;
                ChkMcaMedSocietiesN.Checked = true;
            }

            if (_taskcontrol.McaNationalSocieties)
            {
                ChkMcaNationalSocietiesY.Checked = true;
                ChkMcaNationalSocietiesN.Checked = false;
            }
            else
            {
                ChkMcaNationalSocietiesY.Checked = false;
                ChkMcaNationalSocietiesN.Checked = true;
            }

            if (_taskcontrol.McaStateMedSocieties)
            {
                ChkMcaStateMedSocietiesY.Checked = true;
                ChkMcaStateMedSocietiesN.Checked = false;
            }
            else
            {
                ChkMcaStateMedSocietiesY.Checked = false;
                ChkMcaStateMedSocietiesN.Checked = true;
            }

            if (_taskcontrol.McaLocalMedSocieties)
            {
                ChkMcaLocalMedSocietiesY.Checked = true;
                ChkMcaLocalMedSocietiesN.Checked = false;
            }
            else
            {
                ChkMcaLocalMedSocietiesY.Checked = false;
                ChkMcaLocalMedSocietiesN.Checked = true;
            }

            if (_taskcontrol.McaWrittenExam)
            {
                ChkMcaWrittenExam.Checked = true;     
            }
            else
            {
                ChkMcaWrittenExam.Checked = false;
            }

            if (_taskcontrol.McaOralExam)
            {
                ChkMcaOralExam.Checked = true;
            }
            else
            {
                ChkMcaOralExam.Checked = false;
            }
        }
    }
}
