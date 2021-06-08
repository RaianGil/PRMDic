using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for PrimaryPolicy1.
    /// </summary>
    public partial class PrimaryPolicy1 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;

        public PrimaryPolicy1(EPolicy.TaskControl.Policy taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void PrimaryPolicy1_PageStart(object sender, EventArgs e)
        {
            EPolicy.TaskControl.CorporatePolicyQuote tcCorp = null;
            EPolicy.TaskControl.Policies _taskcontrol2 = null;         

            txtPolNumber.Text = _taskcontrol.PolicyType.ToString().Trim() + "-" + _taskcontrol.PolicyNo.ToString().Trim() + " " + _taskcontrol.Certificate.ToString().Trim();

            //Customer and Postal Address
            txtName.Text = _taskcontrol.Customer.FirstName.Trim() + " " + _taskcontrol.Customer.Initial.Trim()+" "+
            _taskcontrol.Customer.LastName1.Trim()+" " +_taskcontrol.Customer.LastName2.Trim();

            txtAddress.Text = _taskcontrol.Customer.Address1.ToString().Trim();
            txtAddress2.Text = _taskcontrol.Customer.Address2.ToString().Trim() + " " +
            _taskcontrol.Customer.City.ToString().Trim() + " " +
            _taskcontrol.Customer.State.ToString() + ", " + _taskcontrol.Customer.ZipCode.ToString().Trim();

            txtAgency.Text = EPolicy.LookupTables.LookupTables.GetDescription("Agency", _taskcontrol.Agency.Trim());
            txtAgent.Text = EPolicy.LookupTables.LookupTables.GetDescription("Agent",_taskcontrol.Agent.Trim());

            txtFrom.Text = LongDateEnglish(DateTime.Parse(_taskcontrol.EffectiveDate.ToString()));
            txtTo.Text = LongDateEnglish(DateTime.Parse(_taskcontrol.ExpirationDate.ToString()));
            txtRetroDate.Text = LongDateEnglish(DateTime.Parse(_taskcontrol.RetroactiveDate.ToString()));

            string limit = "";
            if (_taskcontrol.PolicyType.Trim() == "CP")
            {
                txtPartnership.Text = _taskcontrol.Customer.FirstName.Trim() + " " + _taskcontrol.Customer.Initial.Trim() + " " +
                    _taskcontrol.Customer.LastName1.Trim() + " " + _taskcontrol.Customer.LastName2.Trim();
                tcCorp = EPolicy.TaskControl.CorporatePolicyQuote.GetCorporatePolicyQuote(_taskcontrol.TaskControlID, true);
                txtLimitA.Text = "$" + tcCorp.CorporatePolicyDetailCollection.Rows[0]["PrimaryRate"].ToString().Trim();
                txtLimitA.Text = txtLimitA.Text.Replace("/", "/$");
                limit = tcCorp.CorporatePolicyDetailCollection.Rows[0]["PrimaryRate"].ToString().Trim();
            }
            else
            {
                txtPartnership.Text = "N/A";
                _taskcontrol2 = EPolicy.TaskControl.Policies.GetPolicies(_taskcontrol.TaskControlID);
                txtLimitA.Text = "$" + EPolicy.LookupTables.LookupTables.GetDescriptionToPRPrimaryLimit("PRPrimaryLimit", _taskcontrol2.PRMedicalLimit.ToString());
                txtLimitA.Text = txtLimitA.Text.Replace("/", "/$");
                limit = EPolicy.LookupTables.LookupTables.GetDescriptionToPRPrimaryLimit("PRPrimaryLimit", _taskcontrol2.PRMedicalLimit.ToString());
            }

            if (_taskcontrol.EffectiveDate.Trim() != _taskcontrol.RetroactiveDate.Trim())
            {
                label44.Visible = true;
                //label43.Visible = true;
            }
            else
            {
                label44.Visible = false;
                //label43.Visible = false; 
            }

            int index = limit.IndexOf("/");
            string limitA1 = limit.Substring(0, index);
            string limitA2 = limit.Substring(index+1);            

            if (_taskcontrol.PolicyType.Trim() == "CP")
            {
                label37.Text = "$" + limitA1.Trim();
                txtLimitA.Text = txtLimitA1.Text.Replace("/", "/$");
                label38.Text = "$" + limitA2.Trim();
                txtLimitA.Text = txtLimitA2.Text.Replace("/", "/$");
                txtLimitA1.Text = "$ NOT COVERED";
                txtLimitA2.Text = "$ NOT COVERED";
            
            }
            else
            {
                txtLimitA1.Text = "$" + limitA1.Trim();
                txtLimitA1.Text = txtLimitA1.Text.Replace("/", "/$");
                txtLimitA2.Text = "$" + limitA2.Trim();
                txtLimitA2.Text = txtLimitA2.Text.Replace("/", "/$");
                label37.Text = "$ NOT COVERED";
                label38.Text = "$ NOT COVERED";
            }

            double totPrem = _taskcontrol.TotalPremium + _taskcontrol.Charge;

            if (_taskcontrol.PolicyType.Trim() == "CP")
            {
                txtTotal1.Text = "$ NOT COVERED";
                label39.Text = totPrem.ToString("$###,###.00");
            }
            else
            {
                txtTotal1.Text = totPrem.ToString("$###,###.00");
                label39.Text = "$ NOT COVERED";
            }

            txtTotal2.Text = totPrem.ToString("$###,###.00");

            //txtCobA.Text = EPolicy.LookupTables.LookupTables.GetDescription("PRMedicalLimit", _taskcontrol.PRMedicalLimit.ToString());
            //txtRetro.Text = _taskcontrol.RetroactiveDate.ToString();

            //if (_taskcontrol2.ApplicationID != 0)
            //{
                //EPolicy.TaskControl.Application tc = (EPolicy.TaskControl.Application) EPolicy.TaskControl.TaskControl.GetTaskControlByTaskControlID(_taskcontrol2.ApplicationID, 1);
                //txtUnderPol.Text = tc.PriCarierName1;
            //}
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
    }
}
