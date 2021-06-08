using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy;

namespace EPolicy2.Reports.PRMdic
{
    public partial class Poliza1 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;
        private bool _certificate;

        public Poliza1(EPolicy.TaskControl.Policy taskcontrol, bool certificate)
        {
            _taskcontrol = taskcontrol;
            _certificate = certificate;
            InitializeComponent();
        }

        private void Poliza1_ReportStart(object sender, EventArgs e)
        {
            EPolicy.TaskControl.CorporatePolicyQuote tcCorp = null;
            EPolicy.TaskControl.Policies _taskcontrol2 = null;

            if (_taskcontrol.PolicyType.Trim() == "CE" || _taskcontrol.PolicyType.Trim() == "AEC")
                tcCorp = EPolicy.TaskControl.CorporatePolicyQuote.GetCorporatePolicyQuote(_taskcontrol.TaskControlID, true);
            else
                _taskcontrol2 = EPolicy.TaskControl.Policies.GetPolicies(_taskcontrol.TaskControlID);

            txtPolNumber.Text = _taskcontrol.PolicyType.Trim() + "-" + _taskcontrol.PolicyNo.ToString().Trim() + " " + _taskcontrol.Certificate.ToString().Trim();

            //Customer and Postal Address
            txtName.Text = _taskcontrol.Customer.FirstName.Trim() + " " + _taskcontrol.Customer.Initial.Trim()+" "+
            _taskcontrol.Customer.LastName1.Trim()+" " +_taskcontrol.Customer.LastName2.Trim();

            txtAddress.Text = _taskcontrol.Customer.Address1.ToString().Trim() + " " +
            _taskcontrol.Customer.Address2.ToString().Trim() + " " +
            _taskcontrol.Customer.City.ToString().Trim() + " " +
            _taskcontrol.Customer.State.ToString() + ", " + _taskcontrol.Customer.ZipCode.ToString().Trim();

            txtAgency.Text = EPolicy.LookupTables.LookupTables.GetDescription("Agency",_taskcontrol.Agency.Trim());
            txtAgent.Text = EPolicy.LookupTables.LookupTables.GetDescription("Agent", _taskcontrol.Agent.Trim());

            txtFrom.Text = LongDateEnglish(DateTime.Parse(_taskcontrol.EffectiveDate.ToString()));
            txtTo.Text = LongDateEnglish(DateTime.Parse(_taskcontrol.ExpirationDate.ToString()));

            if (_taskcontrol.PolicyType.Trim() == "CE" || _taskcontrol.PolicyType.Trim() == "AEC")
            {
                tcCorp = EPolicy.TaskControl.CorporatePolicyQuote.GetCorporatePolicyQuote(_taskcontrol.TaskControlID, true);
                label7.Text = "$" + tcCorp.CorporatePolicyDetailCollection.Rows[0]["ExcessRate"].ToString().Trim();
                txtLimitTot.Text = "$" + tcCorp.CorporatePolicyDetailCollection.Rows[0]["ExcessRate"].ToString().Trim();
                txtLimitTot.Text = txtLimitTot.Text.Replace("/", "/$");
                txtLimitA.Text = "Not Covered";
                txtLimitA.Text = txtLimitA.Text.Replace("/", "/$");
                label44.Text = _taskcontrol.Customer.FirstName.Trim() + " " + _taskcontrol.Customer.Initial.Trim() + " " +
                                _taskcontrol.Customer.LastName1.Trim() + " " + _taskcontrol.Customer.LastName2.Trim();
            }
            else
            {
                _taskcontrol2 = EPolicy.TaskControl.Policies.GetPolicies(_taskcontrol.TaskControlID);
                txtLimitA.Text = "$" + (EPolicy.LookupTables.LookupTables.GetDescription("PRMedicalLimit", _taskcontrol2.PRMedicalLimit.ToString())).Trim();
                txtLimitA.Text = txtLimitA.Text.Replace("/", "/$");
                txtLimitTot.Text = "$" + (EPolicy.LookupTables.LookupTables.GetDescription("PRMedicalLimit", _taskcontrol2.PRMedicalLimit.ToString())).Trim();
                txtLimitTot.Text = txtLimitTot.Text.Replace("/", "/$");
                label7.Text = "Not Covered";
            }


            double totPrem = _taskcontrol.TotalPremium;// +_taskcontrol.Charge;
            if (_taskcontrol.PolicyType.Trim() == "CE" || _taskcontrol.PolicyType.Trim() == "AEC")
            {
                label39.Text = totPrem.ToString("$###,###.00");
                txtTotal1.Text = "Not Covered";
            }
            else
            {
                txtTotal1.Text = totPrem.ToString("$###,###.00");
                label39.Text = "Not Covered";
            }

            txtTotal2.Text = totPrem.ToString("$###,###.00");

            //txtCobA.Text = EPolicy.LookupTables.LookupTables.GetDescription("PRMedicalLimit", _taskcontrol.PRMedicalLimit.ToString());
            txtRetro.Text = LongDateEnglish(DateTime.Parse(_taskcontrol.RetroactiveDate.ToString()));

            if (_taskcontrol.PolicyType.Trim() == "PE" || _taskcontrol.PolicyType.Trim() == "AAE")
            {
                txtUnderPol.Text = _taskcontrol2.PriCarierName1.Trim() + " / " + _taskcontrol2.PriClaims1.Trim();
                txtCobA.Text = _taskcontrol2.PriPolLimits1.Trim();
                txtCobB.Text = "Not Covered";

                if (_taskcontrol2.PriPolEffecDate1.Trim() != "")
                    txtUnderFrom.Text = _taskcontrol2.PriPolEffecDate1.Trim() + " To: " + DateTime.Parse(_taskcontrol2.PriPolEffecDate1).AddMonths(12).ToShortDateString();
                else
                    txtUnderFrom.Text = "";

                //if (_taskcontrol2.ApplicationID != 0)
                //{
                //    EPolicy.TaskControl.Application tc = (EPolicy.TaskControl.Application)EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(_taskcontrol2.ApplicationID, 1);
                //    txtUnderPol.Text = tc.PriCarierName1;
                //}
            }
            else
            {
                txtUnderPol.Text = tcCorp.PriCarierName1.Trim() + " / " + tcCorp.PriClaims1.Trim();
                txtCobB.Text = tcCorp.PriPolLimits1.Trim();
                txtCobA.Text = "Not Covered";

                if (tcCorp.PriPolEffecDate1.Trim() != "")
                    txtUnderFrom.Text = tcCorp.PriPolEffecDate1.Trim() + " To: " + DateTime.Parse(tcCorp.PriPolEffecDate1).AddMonths(12).ToShortDateString();
                else
                    txtUnderFrom.Text = "";
            }

            if (_certificate)
            {
                lblCertificate.Visible = true;
                lblCertificate.Text = "Hereby it is certified that this is an exact and true copy of the original Policy No. " +
                    _taskcontrol.PolicyType.Trim() + "-" + _taskcontrol.PolicyNo.Trim() + " issued by PRMDIC in favor of " +
                    (_taskcontrol.PolicyType.Contains("C") ? "" : "DR. ") +
                    _taskcontrol.Customer.FirstName.Trim() + " " + _taskcontrol.Customer.LastName1.Trim() + " " + _taskcontrol.Customer.LastName2.Trim() + ".";
            }

            if (_taskcontrol.InsuranceCompany == "002")
            {
                label1.Text = "ASPEN AMERICAN INSURANCE COMPANY";
                label42.Text = "175 Capital Blvd. • Suite 100 • Rocky Hill • CT, 06067";
                textBox3.Text = "ASPMME091 0814";
            }
        }

        public static string LongDateEnglish(DateTime datetime)
        {
            string Dayweek = datetime.DayOfWeek.ToString().Trim().ToUpper();
            string Day = datetime.Day.ToString();
            string Month = MonthNameEnglish(datetime.Month);
            string Year = datetime.Year.ToString();

            //return Dayweek + ", " + Month + " " + Day + ", " + Year;
            return Month + " " + Day + ", " + Year;
        }

        public static string MonthNameEnglish(int month)
        {
            string monthName = "";

            switch (month)
            {
                case 1:
                    monthName = "JANUARY";
                    break;
                case 2:
                    monthName = "FEBRUARY";
                    break;
                case 3:
                    monthName = "MARCH";
                    break;
                case 4:
                    monthName = "APRIL";
                    break;
                case 5:
                    monthName = "MAY";
                    break;
                case 6:
                    monthName = "JUNE";
                    break;
                case 7:
                    monthName = "JULY";
                    break;
                case 8:
                    monthName = "AUGUST";
                    break;
                case 9:
                    monthName = "SEPTEMBER";
                    break;
                case 10:
                    monthName = "OCTOBER";
                    break;
                case 11:
                    monthName = "NOVEMBER";
                    break;
                case 12:
                    monthName = "DECEMBER";
                    break;
            }
            return monthName;
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {

        }
    }
}
