using System;
using System.Data;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using DataDynamics;
using System.Drawing;
using EPolicy.TaskControl;
using EPolicy.Quotes;
using EPolicy.Customer;
using EPolicy.LookupTables;

namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for EndosoConfiscacion.
    /// </summary>
    public partial class EndosoConfiscacion : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.QuoteAuto _policy;
        private string _CopyValue;

        public EndosoConfiscacion(EPolicy.TaskControl.QuoteAuto taskcontrol, string copyValue)
        {
            _policy = taskcontrol;
            _CopyValue = copyValue;
            InitializeComponent();
        }

        private void EndosoConfiscacion_ReportStart(object sender, EventArgs e)
        {
            txtPolicyNo.Text = _policy.Policy.PolicyNo.ToString().Trim();
            txtCertificate.Text = _policy.Policy.PolicyType.ToString().Trim() + " - " + _policy.Policy.Certificate.Trim();
            txtEffectiveDate.Text = _policy.EffectiveDate.ToString();
            txtCustomerName.Text = _policy.Customer.FirstName.Trim() + ' ' + _policy.Customer.Initial.Trim() + ' ' + _policy.Customer.LastName1.Trim() + ' ' + _policy.Customer.LastName2.Trim();
            
            EPolicy.LookupTables.Bank bank = new Bank();
            bank = bank.GetBank(_policy.Bank);
            txtBank.Text = bank.BankDesc.ToString().Trim();
        }
    }
}
