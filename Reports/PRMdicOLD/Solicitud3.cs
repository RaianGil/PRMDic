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
    /// Summary description for Solicitud3.
    /// </summary>
    public partial class Solicitud3 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Application _taskcontrol;

        public Solicitud3(EPolicy.TaskControl.Application taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void Solicitud3_ReportStart(object sender, EventArgs e)
        {
            this.txtBoardCertifiedDesc1.Text = _taskcontrol.BoardCertifiedDesc1;
            this.txtBoardCertifiedDesc2.Text = _taskcontrol.BoardCertifiedDesc2;
            this.txtBoardCertifiedDesc3.Text = _taskcontrol.BoardCertifiedDesc3;
            this.txtBoardCertifiedDesc4.Text = _taskcontrol.BoardCertifiedDesc4;
            this.txtBoardCertifiedDesc5.Text = _taskcontrol.BoardCertifiedDesc5;
            this.txtBoardCertifiedDesc6.Text = _taskcontrol.BoardCertifiedDesc6;
            this.txtBoardCertifiedDesc7.Text = _taskcontrol.BoardCertifiedDesc7;
            this.txtBoardCertifiedDesc8.Text = _taskcontrol.BoardCertifiedDesc8;
            this.txtBoardCertifiedDesc9.Text = _taskcontrol.BoardCertifiedDesc9;
            this.txtBoardCertifiedDesc10.Text = _taskcontrol.BoardCertifiedDesc10;
            this.txtBoardCertifiedDesc11.Text = _taskcontrol.BoardCertifiedDesc11;
            this.txtBoardCertifiedDesc12.Text = _taskcontrol.BoardCertifiedDesc12;

            this.txtEleExpDate.Text = _taskcontrol.EleExpDate;
            this.txtExpiredWhy.Text = _taskcontrol.ExpiredWhy;
            this.txtFellCity.Text = _taskcontrol.FellCity;
            this.txtFellDegree.Text = _taskcontrol.FellDegree;
            this.txtFellFrom.Text = _taskcontrol.FellFrom;
            this.txtFellSchool.Text = _taskcontrol.FellSchool;
            this.txtIntCity.Text = _taskcontrol.IntCity;
            this.txtIntDegree.Text = _taskcontrol.IntDegree;
            this.txtIntFrom.Text = _taskcontrol.IntFrom;
            this.txtIntSchool.Text = _taskcontrol.IntSchool;
            this.txtMedCity.Text = _taskcontrol.MedCity;
            this.txtMedDegree.Text = _taskcontrol.MedDegree;
            this.txtMedFrom.Text = _taskcontrol.MedFrom;
            this.txtMedSchool.Text = _taskcontrol.MedSchool;
            this.txtOCity.Text = _taskcontrol.OCity;
            this.txtOSchool.Text = _taskcontrol.OSchool;
            this.txtOCity.Text = _taskcontrol.OCity;
            this.txtODegree.Text = _taskcontrol.MedDegree;
            this.txtOFrom.Text = _taskcontrol.MedFrom;
            this.txtOSchool.Text = _taskcontrol.OSchool;

            this.txtPracticeLimitDesc.Text = _taskcontrol.PracticeLimitDesc;
            this.txtPriPractice.Text = _taskcontrol.PriPractice;
            this.txtPriSpecialty.Text = _taskcontrol.PriSpecialty;
            this.txtResCity.Text = _taskcontrol.ResCity;
            this.txtResDegree.Text = _taskcontrol.ResDegree;
            this.txtResFrom.Text = _taskcontrol.ResFrom;
            this.txtResSchool.Text = _taskcontrol.ResSchool;
            this.txtSecPractice.Text = _taskcontrol.SecPractice;
            this.txtSecSpecialty.Text = _taskcontrol.SecSpecialty;

            if (_taskcontrol.McaBoardCertified)
            {
                ChkMcaBoardCertifiedY.Checked = true;
                ChkMcaBoardCertifiedN.Checked = false;
            }
            else
            {
                ChkMcaBoardCertifiedY.Checked = false;
                ChkMcaBoardCertifiedN.Checked = true;
            }

            if (_taskcontrol.McaCertified)
            {
                chkMcaCertifiedY.Checked = true;
                ChkMcaCertifiedN.Checked = false;
            }
            else
            {
                chkMcaCertifiedY.Checked = false;
                ChkMcaCertifiedN.Checked = true;
            }

            if (_taskcontrol.McaResTraining)
            {
                chkMcaResTrainingY.Checked = true;
                ChkMcaResTrainingN.Checked = false;
            }
            else
            {
                chkMcaResTrainingY.Checked = false;
                ChkMcaResTrainingN.Checked = true;
            }

            if (_taskcontrol.McaPracticeLimit)
            {
                ChkMcaPracticeLimitY.Checked = true;
                ChkMcaPracticeLimitN.Checked = false;
            }
            else
            {
                ChkMcaPracticeLimitY.Checked = false;
                ChkMcaPracticeLimitN.Checked = true;
            }                        
        }
    }
}
