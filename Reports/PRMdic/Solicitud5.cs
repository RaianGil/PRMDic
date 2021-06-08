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
    /// Summary description for Solicitud5.
    /// </summary>
    public partial class Solicitud5 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Application _taskcontrol;

        public Solicitud5(EPolicy.TaskControl.Application taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void Solicitud5_ReportStart(object sender, EventArgs e)
        {
            this.txtCity1.Text = _taskcontrol.City1;
            this.txtCity2.Text = _taskcontrol.City2;
            this.txtCity3.Text = _taskcontrol.City3;
            this.txtCity4.Text = _taskcontrol.City4;
            this.txtEntAddr1.Text = _taskcontrol.EntAddr1;
            this.txtEntAddr2.Text = _taskcontrol.EntAddr2;
            this.txtEntDate1.Text = _taskcontrol.EntDate1;            
            this.txtEntDate2.Text = _taskcontrol.EntDate2;
            this.txtEntName1.Text = _taskcontrol.EntName1;
            this.txtEntName2.Text = _taskcontrol.EntName2;
            this.txtEntSpecialty1.Text = _taskcontrol.EntSpecialty1;
            this.txtEntSpecialty2.Text = _taskcontrol.EntSpecialty2;
            this.txtHospital1.Text = _taskcontrol.Hospital1;
            this.txtHospital2.Text = _taskcontrol.Hospital2;
            this.txtHospital3.Text = _taskcontrol.Hospital3;
            this.txtHospital4.Text = _taskcontrol.Hospital4;
            this.txtOficeAddr1.Text = _taskcontrol.OficeAddr1;
            this.txtOficeAddr2.Text = _taskcontrol.OficeAddr2;
            this.txtOficeAddr3.Text = _taskcontrol.OficeAddr3;
            this.txtOficeCity1.Text = _taskcontrol.OficeCity1;
            this.txtOficeCity2.Text = _taskcontrol.OficeCity2;
            this.txtOficeCity3.Text = _taskcontrol.OficeCity3;
            this.txtOficeCountry1.Text = _taskcontrol.OficeCountry1;
            this.txtOficeCountry2.Text = _taskcontrol.OficeCountry2;
            this.txtOficeCountry3.Text = _taskcontrol.OficeCountry3;
            this.txtPrivileges1.Text = _taskcontrol.Privileges1;
            this.txtPrivileges2.Text = _taskcontrol.Privileges2;
            this.txtPrivileges3.Text = _taskcontrol.Privileges3;
            this.txtPrivileges4.Text = _taskcontrol.Privileges4;
            this.txtRestrictions1.Text = _taskcontrol.Restrictions1;
            this.txtRestrictions2.Text = _taskcontrol.Restrictions2;
            this.txtRestrictions3.Text = _taskcontrol.Restrictions3;            
        }
    }
}
