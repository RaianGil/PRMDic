using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.Customer;
using EPolicy.LookupTables;
using EPolicy.TaskControl;
using System.Data;

namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for PlanDiferido2Out.
    /// </summary>
    public partial class PlanDiferido2Out : DataDynamics.ActiveReports.ActiveReport3
    {
        private string _CopyValue;
        private EPolicy.TaskControl.Policy _policy;
        EPolicy.TaskControl.DeferredPayment deferredPayment;

        public PlanDiferido2Out(EPolicy.TaskControl.Policy taskcontrol, EPolicy.TaskControl.DeferredPayment _deferredPayment, string copyValue)
        {
            _policy = taskcontrol;
            deferredPayment = _deferredPayment;
            _CopyValue = copyValue;
            InitializeComponent();
        }

        private void PlanDiferido2Out_ReportStart(object sender, EventArgs e)
        {
            txtPolicyNo.Text = _policy.PolicyNo.ToString().Trim();
            txtCertificate.Text = _policy.PolicyType.ToString().Trim() + " - " + _policy.Certificate.ToString().Trim();

            txtCustomerName.Text = _policy.Customer.FirstName.Trim() + ' ' + _policy.Customer.Initial.Trim() + ' ' + _policy.Customer.LastName1.Trim() + ' ' + _policy.Customer.LastName2.Trim();
            txtCustomerAddr1.Text = _policy.Customer.Address1.Trim() + ' ' + _policy.Customer.Address2.Trim();
            txtCustomerAddr2.Text = _policy.Customer.City.Trim() + ' ' + _policy.Customer.State.Trim() + ' ' + _policy.Customer.ZipCode.Trim();

            //EPolicy.LookupTables.Agency agency = new EPolicy.LookupTables.Agency();
            //agency = agency.GetAgency(_policy.Agency);
            //txtAgencyDesc.Text = agency.AgencyDesc.ToString().Trim();

            //EPolicy.LookupTables.Agent agent = new Agent();
            //agent = agent.GetAgent(_policy.Agent);
            //txtAgent.Text = agent.CarsID.Trim() + " -  " + agent.AgentDesc.ToString().Trim();

            //EPolicy.TaskControl.DeferredPayment deferredPayment = EPolicy.TaskControl.DeferredPayment.GetDeferredPaymentByTaskControlID(_policy.TaskControlID);

            txtTotalPrem.Text = deferredPayment.TotalPremium.ToString("###,###.00");
            double totInteres = deferredPayment.Rate2 + deferredPayment.Rate3 + deferredPayment.Rate4;
            txtTotalInteres.Text = totInteres.ToString("###,###.00");

            txtDownPayment.Text = deferredPayment.TotalDownPayment.ToString("###,###.00");
            txtPaymentAmt2.Text = deferredPayment.PaymentAmt2.ToString("###,###.00");
            txtPaymentAmt3.Text = deferredPayment.PaymentAmt3.ToString("###,###.00");
            txtPaymentAmt4.Text = deferredPayment.PaymentAmt4.ToString("###,###.00");

            txtPaymentDate2.Text = deferredPayment.PaymentDate2.ToString();
            txtPaymentDate3.Text = deferredPayment.PaymentDate3.ToString();
            txtPaymentDate4.Text = deferredPayment.PaymentDate4.ToString();
        }
    }
}
