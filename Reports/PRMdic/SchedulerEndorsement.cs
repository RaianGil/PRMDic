using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for SchedulerEndorsement.
    /// </summary>
    public partial class SchedulerEndorsement : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;
        private bool _certificate;

        public SchedulerEndorsement(EPolicy.TaskControl.Policy taskcontrol, bool certificate)
        {
            _taskcontrol = taskcontrol;
            _certificate = certificate;
            InitializeComponent();
        }

        private void SchedulerEndorsement_ReportStart(object sender, EventArgs e)
        {
            textBox1.Text = _taskcontrol.EffectiveDate.Trim();
            textBox2.Text = _taskcontrol.PolicyType.Trim() + "-" + _taskcontrol.PolicyNo.Trim();

            if (_taskcontrol.Charge != 0)
            {
                txtSurcharge1.Visible = true;
                txtSurcharge2.Visible = true;
                txtSurcharge3.Visible = true;
            }

            if (_certificate)
            {
                lblCertificate.Visible = true;
                lblCertificate.Text = "Hereby it is certified that this is an exact and true copy of the original Policy No. " +
                    _taskcontrol.PolicyType.Trim() + "-" + _taskcontrol.PolicyNo.Trim() + " issued by PRMDIC in favor of " +
                    (_taskcontrol.PolicyType.Contains("C") ? "" : "DR. ") +
                    _taskcontrol.Customer.FirstName.Trim() + " " + _taskcontrol.Customer.LastName1.Trim() + " " + _taskcontrol.Customer.LastName2.Trim() + ".";
            }

            if (_taskcontrol.Agency == "017")
            {
                imgFirmaResolve.Visible = true;
                imgFirmaColonial.Visible = false;
            }
            else if (_taskcontrol.Agency == "001" && _taskcontrol.City == 80)
            {
                imgFirmaColonial.Visible = true;
                imgFirmaResolve.Visible = false;
            }
            else
            {
                imgFirmaResolve.Visible = false;
                imgFirmaColonial.Visible = false;
            }
        }
    }
}
