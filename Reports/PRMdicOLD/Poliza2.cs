using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for Poliza2.
    /// </summary>
    public partial class Poliza2 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policies _taskcontrol;

        public Poliza2(EPolicy.TaskControl.Policies taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void Poliza2_ReportStart(object sender, EventArgs e)
        {
            TxtIndividualName.Text = _taskcontrol.Customer.FirstName.Trim() + " " + _taskcontrol.Customer.Initial.Trim() + " " +
            _taskcontrol.Customer.LastName1.Trim() + " " + _taskcontrol.Customer.LastName2.Trim();

            if (_taskcontrol.PRMedicRATEID != 0)
            {
                DataTable dt = EPolicy.TaskControl.Application.GetPRMEDICRATEBYISOCODE(0, _taskcontrol.IsoCode);
                TxtSpecialty.Text = dt.Rows[0]["PRMEDICRATEDESC"].ToString();
                txtIsoCode.Text = _taskcontrol.IsoCode;
            }

            if (_taskcontrol.PRMedicalLimit != 0)
            {
                txtLimit.Text = EPolicy.LookupTables.LookupTables.GetDescription("PRMedicalLimit", _taskcontrol.PRMedicalLimit.ToString());
            }

            double totPrem = _taskcontrol.TotalPremium + _taskcontrol.Charge;
            txtPremium.Text = totPrem.ToString("$###,###.00");
            TxtTotal.Text = totPrem.ToString("$###,###.00");

            txtEntityName.Text = "Not Covered";
            TxtSpecialty2.Text = "Not Covered";
            txtPremium2.Text = "Not Covered";
            TxtTotal2.Text = "Not Covered";
        }
    }
}
