using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Web.SessionState;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for Invoice.
    /// </summary>
    public partial class Invoice : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;
        private bool _email;

        public Invoice(EPolicy.TaskControl.Policy taskcontrol, bool email)
        {
            _taskcontrol = taskcontrol;
            _email = email;
            InitializeComponent();
        }

        private void Invoice_ReportStart(object sender, EventArgs e)
        {
            txtReceiptPolicyNo.Text = _taskcontrol.Anniversary.ToString().Trim();
            txtEntryDate.Text = _taskcontrol.EntryDate.ToShortDateString();

            if (_taskcontrol.PolicyType.Trim().Substring(0, 1) == "P")
            {
                if (_taskcontrol.PolicyType.Trim() == "PE")
                    txtPolicyType.Text = "Excess Policy:" + _taskcontrol.PolicyType.Trim() + "-" + _taskcontrol.PolicyNo.ToString().Trim();
                else
                    txtPolicyType.Text = "Primary Policy:" + _taskcontrol.PolicyType.Trim() + "-" + _taskcontrol.PolicyNo.ToString().Trim();
            }
            else //Corporate
            {
                if (_taskcontrol.PolicyType.Trim() == "CE")
                    txtPolicyType.Text = "Corporate Excess Policy:" + _taskcontrol.PolicyType.Trim() + "-" + _taskcontrol.PolicyNo.ToString().Trim();
                else
                    txtPolicyType.Text = "Corporate Primary Policy:" + _taskcontrol.PolicyType.Trim() + "-" + _taskcontrol.PolicyNo.ToString().Trim();

            }

            TxtIndividualName.Text = "To: "+_taskcontrol.Customer.FirstName.Trim() + " " + _taskcontrol.Customer.Initial.Trim() + " " +
            _taskcontrol.Customer.LastName1.Trim() + " " + _taskcontrol.Customer.LastName2.Trim();

            txtAddress.Text = _taskcontrol.Customer.Address1.ToString().Trim();
            txtAddress2.Text = _taskcontrol.Customer.Address2.ToString().Trim();
            txtAddress3.Text = _taskcontrol.Customer.City.ToString().Trim() + " " +
           _taskcontrol.Customer.State.ToString() + ", " + _taskcontrol.Customer.ZipCode.ToString().Trim();

            txtReceiptNoDetail.Text = _taskcontrol.Anniversary.ToString().Trim();
            txtEffectiveDate.Text = _taskcontrol.EffectiveDate.Trim();

            if (_taskcontrol.PolicyType.Trim().Substring(0, 1) == "C")
            {
                if (_taskcontrol.PolicyType.Trim() == "CE")
                    txtDesc.Text = "Excess Policy:" + _taskcontrol.PolicyType.Trim() + "-" + _taskcontrol.PolicyNo.ToString().Trim() +
                        " Effective From " + _taskcontrol.EffectiveDate.Trim() + " to " + _taskcontrol.ExpirationDate.Trim();
                else
                    txtDesc.Text = "Primary Policy:" + _taskcontrol.PolicyType.Trim() + "-" + _taskcontrol.PolicyNo.ToString().Trim() +
                        " Effective From " + _taskcontrol.EffectiveDate.Trim() + " to " + _taskcontrol.ExpirationDate.Trim();
            }
            else
                if (_taskcontrol.PolicyType.Trim() == "PE")
                    txtDesc.Text = "Excess Policy:" + _taskcontrol.PolicyType.Trim() + "-" + _taskcontrol.PolicyNo.ToString().Trim()+
                        " Effective From "+_taskcontrol.EffectiveDate.Trim()+" to " +_taskcontrol.ExpirationDate.Trim();
                else
                    txtDesc.Text = "Primary Policy:" + _taskcontrol.PolicyType.Trim() + "-" + _taskcontrol.PolicyNo.ToString().Trim() +
                        " Effective From " + _taskcontrol.EffectiveDate.Trim() + " to " + _taskcontrol.ExpirationDate.Trim();

            if (_email) 
            {
                double totPrem = _taskcontrol.TotalPremium + _taskcontrol.Charge - _taskcontrol.PaidAmount;
                txtTotAmountHeader.Text = "Total Amount: " + totPrem.ToString("$###,###.00");
                txtPremium.Text = _taskcontrol.TotalPremium.ToString("$###,###.00");
                TxtTotal.Text = totPrem.ToString("$###,###.00");
            }
            else
            {
                double totPrem = _taskcontrol.TotalPremium + _taskcontrol.Charge;
                txtTotAmountHeader.Text = "Total Amount: " + totPrem.ToString("$###,###.00");
                txtPremium.Text = _taskcontrol.TotalPremium.ToString("$###,###.00");
                TxtTotal.Text = totPrem.ToString("$###,###.00");
            }

            if (_taskcontrol.Charge != 0)
            {
                string omeNum = string.Empty;

                if (_taskcontrol.PolicyType.Trim() == "PP" || _taskcontrol.PolicyType.Trim() == "CP")
                    omeNum = "P-114";
                else omeNum = "E-144";

                txtSurchargeDesc.Visible = true;
                lblSurchargeDesc2.Visible = true;
                txtSurcharge.Visible = true;
                txtSurchargeDesc.Text = "*Surcharge (0.9%)";

                lblSurchargeDesc2.Text = "*  This amount in order to recover the amounts previously paid by Puerto Rico Medical Defense Insurance Company to the Puerto Rico Property & Casualty Insurance Guaranty Association.  Please refer to the Official Mandatory Endorsement Number " + omeNum + ", attached to and made part of this policy.";
                txtSurcharge.Text = _taskcontrol.Charge.ToString("$###,###.00");
            }
            else
            {
                txtSurchargeDesc.Visible = false;
                lblSurchargeDesc2.Visible = false;
                txtSurcharge.Visible = false;
            }
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {

        }
    }
}
