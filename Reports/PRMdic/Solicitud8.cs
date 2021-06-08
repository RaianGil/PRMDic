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
    /// Summary description for Solicitud8.
    /// </summary>
    public partial class Solicitud8 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Application _taskcontrol;

        public Solicitud8(EPolicy.TaskControl.Application taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void Solicitud8_ReportStart(object sender, EventArgs e)
        {
            this.txt39Hours1.Text = _taskcontrol.App339Hours1;
            this.txt39Hours2.Text = _taskcontrol.App339Hours2;
            this.txt39Hours3.Text = _taskcontrol.App339Hours3;
            this.txt39Hours4.Text = _taskcontrol.App339Hours4;
            this.txt39Hours5.Text = _taskcontrol.App339Hours5;
            this.txt39Hours6.Text = _taskcontrol.App339Hours6;
            this.txt39Number1.Text = _taskcontrol.App339Number1;
            this.txt39Number2.Text = _taskcontrol.App339Number2;
            this.txt39Number3.Text = _taskcontrol.App339Number3;
            this.txt39Number4.Text = _taskcontrol.App339Number4;
            this.txt39Number5.Text = _taskcontrol.App339Number5;
            this.txt39Number6.Text = _taskcontrol.App339Number6;
            this.txtActDesc.Text = _taskcontrol.ActDesc;
            this.txtDaysPWeek.Text = _taskcontrol.DaysPWeek;
            this.txtFacilityAddr1.Text = _taskcontrol.FacilityAddr1;
            this.txtFacilityAddr2.Text = _taskcontrol.FacilityAddr2;
            this.txtFacilityDuties1.Text = _taskcontrol.FacilityDuties1;
            this.txtFacilityDuties2.Text = _taskcontrol.FacilityDuties2;
            this.txtFacilityName1.Text = _taskcontrol.FacilityName1;
            this.txtFacilityName2.Text = _taskcontrol.FacilityName2;
            this.txtFacilityNumbers1.Text = _taskcontrol.FacilityNumbers1;
            this.txtFacilityNumbers2.Text = _taskcontrol.FacilityNumbers2;
            this.txtFacilityType1.Text = _taskcontrol.FacilityType1;
            this.txtFacilityType2.Text = _taskcontrol.FacilityType2;
            this.txtHoursPDayHosp.Text = _taskcontrol.HoursPDayHosp;
            this.txtHoursPDayOffice.Text = _taskcontrol.HoursPDayOffice;
            this.txtPatienPWeek.Text = _taskcontrol.PatienPWeek;

            if (_taskcontrol.McaProfLiab)
            {
                chkMcaProfLiabY.Checked = true;
                chkMcaProfLiabN.Checked = false;
            }
            else
            {
                chkMcaProfLiabY.Checked = false;
                chkMcaProfLiabN.Checked = true;
            }

            if (_taskcontrol.McaExtendedCov)
            {
                chkMcaExtendedCovY.Checked = true;
                chkMcaExtendedCovN.Checked = false;
            }
            else
            {
                chkMcaExtendedCovY.Checked = false;
                chkMcaExtendedCovN.Checked = true;
            }

            if (_taskcontrol.McaFullTimeCov)
            {
                chkMcaFullTimeCovY.Checked = true;
                chkMcaFullTimeCovN.Checked = false;
            }
            else
            {
                chkMcaFullTimeCovY.Checked = false;
                chkMcaFullTimeCovN.Checked = true;
            }

            if (_taskcontrol.McaPartTimeCov)
            {
                chkMcaPartTimeCovY.Checked = true;
                chkMcaPartTimeCovN.Checked = false;
            }
            else
            {
                chkMcaPartTimeCovY.Checked = false;
                chkMcaPartTimeCovN.Checked = true;
            }
             
        }
    }
}
