using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for PriorAct.
    /// </summary>
    public partial class PriorAct : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;
        private bool _certificate;
        public PriorAct(EPolicy.TaskControl.Policy taskcontrol, bool certificate)
        {
            _taskcontrol = taskcontrol;
            _certificate = certificate;
            InitializeComponent();
        }

        private void PriorAct_ReportStart(object sender, EventArgs e)
        {
            txtpolNo.Text = _taskcontrol.PolicyType.ToString().Trim() + "-" + _taskcontrol.PolicyNo.ToString().Trim() + " " + _taskcontrol.Certificate.ToString().Trim();
            txtEffectiveDate.Text = _taskcontrol.EffectiveDate.ToString();
            txtRetro.Text = _taskcontrol.RetroactiveDate.ToString();
            txtEntryDate.Text = _taskcontrol.EntryDate.ToShortDateString();
            txtEntryDate2.Text = _taskcontrol.EntryDate.ToShortDateString();
            textBox1.Text = _taskcontrol.RetroactiveDate.ToString();

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
                txtNombreResolve.Visible = true;
                imgFirmaColonial.Visible = false;
                txtNombreColonial.Visible = false;
            }
            else if (_taskcontrol.Agency == "001" && _taskcontrol.City == 80)
            {
                imgFirmaResolve.Visible = false;
                txtNombreResolve.Visible = false;
                imgFirmaColonial.Visible = true;
                txtNombreColonial.Visible = true;
            }
            else
            {
                imgFirmaResolve.Visible = false;
                txtNombreResolve.Visible = false;
                imgFirmaColonial.Visible = false;
                txtNombreColonial.Visible = false;
            }
        }
    }
}
