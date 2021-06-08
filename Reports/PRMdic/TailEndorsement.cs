using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for TailEndorsement.
    /// </summary>
    public partial class TailEndorsement : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;
        public TailEndorsement(EPolicy.TaskControl.Policy taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void TailEndorsement_ReportStart(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToShortDateString();
            txtPolicyNo.Text = _taskcontrol.PolicyType.Substring(0,2) +" - " + _taskcontrol.PolicyNo;

            if (_taskcontrol.PolicyType.Trim().Substring(0, 2) != "CP" && _taskcontrol.PolicyType.Trim().Substring(0, 2) != "CE")
            {
                if (_taskcontrol.Customer.Initial != "")
                    txtCustomer.Text = "Dr. " + _taskcontrol.Customer.FirstName + " " + _taskcontrol.Customer.Initial + ". " +
                    _taskcontrol.Customer.LastName1 + " " + _taskcontrol.Customer.LastName2;
                else
                    txtCustomer.Text = "Dr. " + _taskcontrol.Customer.FirstName + " " +
                    _taskcontrol.Customer.LastName1 + " " + _taskcontrol.Customer.LastName2;
            }
            else
                txtCustomer.Text = _taskcontrol.Customer.FirstName + " " + _taskcontrol.Customer.Initial + ". " +
                    _taskcontrol.Customer.LastName1 + " " + _taskcontrol.Customer.LastName2;

            txtPremium.Text = _taskcontrol.TotalPremium.ToString("$###,###.00");
            txtEffDate.Text = _taskcontrol.EffectiveDate;

            if (_taskcontrol.InsuranceCompany == "002")
            {
                picture1.Visible = true;
                picture2.Visible = false;
                txtEndorsement.Visible = false;
                label15.Text = "175 Capital Blvd. Suite 100, Rocky Hill CT, 06067";
                label24.Text = "Tel: (787)999.7763 • Fax: (787)993.7763  • aspen@prmdic.com";
            }
        }
    }
}
