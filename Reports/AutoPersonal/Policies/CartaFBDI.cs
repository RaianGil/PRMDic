using System;
using System.Configuration;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.TaskControl;
using EPolicy.Quotes;
using EPolicy.LookupTables;
using EPolicy;
using EPolicy.Login;
using System.Web;

namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for CartaFBDI.
    /// </summary>
    public partial class CartaFBDI : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.Collections.ArrayList _autoCovers = null;
        private EPolicy.TaskControl.QuoteAuto _policy;

        public CartaFBDI(EPolicy.TaskControl.QuoteAuto taskcontrol, string copyValue)
        {
            _policy = taskcontrol;
            InitializeComponent();
        }

        private void CartaFBDI_ReportStart(object sender, EventArgs e)
        {
            txtEntryDate.Text = _policy.EntryDate.ToShortDateString();

            Bank bank = new Bank();
            bank.GetBank(_policy.Bank.Trim());
            txtBank.Text = bank.BankDesc.Trim();
            txtBankAdds1.Text = bank.Address1.Trim() + " " + bank.Address2.Trim();
            txtBankAdds2.Text = bank.City.Trim() + " " + bank.State.Trim() + " " + bank.ZipCode.Trim();
            
            txtCustomerName.Text = _policy.Customer.FirstName.Trim() + " " + _policy.Customer.Initial.Trim() + " " + _policy.Customer.LastName1.Trim() + " " + _policy.Customer.LastName2.Trim();
            txtPolicyNo.Text = _policy.Policy.PolicyNo.Trim();
            txtCertificate.Text = _policy.Policy.PolicyType.ToString().Trim() + " - " + _policy.Policy.Certificate.Trim();
            txtEffectiveDate.Text = _policy.EffectiveDate + " a "+ _policy.ExpirationDate;

            decimal amt = _policy.TotalPremium + _policy.Charge;
            txtTotPrem.Text = amt.ToString("$###,###,###.00");
        }
    }
}
