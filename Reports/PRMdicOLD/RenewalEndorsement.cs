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
    /// Summary description for RenewalEndorsement.
    /// </summary>
    public partial class RenewalEndorsement : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;

        public RenewalEndorsement(EPolicy.TaskControl.Policy taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void RenewalEndorsement_ReportStart(object sender, EventArgs e)
        {
            EPolicy.TaskControl.CorporatePolicyQuote tcCorp = null;
            EPolicy.TaskControl.Policies _taskcontrol2 = null;

            if (_taskcontrol.PolicyType.Trim().Substring(0, 1) == "C")
            {
                tcCorp = EPolicy.TaskControl.CorporatePolicyQuote.GetCorporatePolicyQuote(_taskcontrol.TaskControlID, true);
            }
            else
            {
                _taskcontrol2 = EPolicy.TaskControl.Policies.GetPolicies(_taskcontrol.TaskControlID);
            }

            txtPolNumber.Text = _taskcontrol.PolicyType.ToString().Trim() + " - " + _taskcontrol.PolicyNo.ToString().Trim();

            txtAgency.Text = EPolicy.LookupTables.LookupTables.GetDescription("Agency", _taskcontrol.Agency.Trim());
            txtAgent.Text = EPolicy.LookupTables.LookupTables.GetDescription("Agent", _taskcontrol.Agent.Trim());

            //Customer and Postal Address
            txtInsured.Text = _taskcontrol.Customer.FirstName.Trim() + " " + _taskcontrol.Customer.Initial.Trim() + " " +
            _taskcontrol.Customer.LastName1.Trim() + " " + _taskcontrol.Customer.LastName2.Trim();

            txtAddress1.Text = _taskcontrol.Customer.Address1.ToString().Trim();
            txtAddress2.Text = _taskcontrol.Customer.Address2.ToString().Trim();
            txtAddress3.Text = _taskcontrol.Customer.City.ToString().Trim() + " " +
            _taskcontrol.Customer.State.ToString() + ", " + _taskcontrol.Customer.ZipCode.ToString().Trim();

            txtProfessional.Text = "NONE";
            txtAudit.Text = "ANNUALLY";

            DataTable dt = null;
            DataTable dtOtherSpecialty = null;


            if (_taskcontrol.PolicyType.Trim().Substring(0, 1) == "C")
            {
                if (_taskcontrol.PolicyType.Trim() == "CP")
                {
                    dt = EPolicy.TaskControl.Application.GetPRMEDICRATEPRIMARYBYISOCODE(0, tcCorp.CorporatePolicyDetailCollection.Rows[0]["IsoCode"].ToString().Trim());
                    dtOtherSpecialty = EPolicy.TaskControl.Application.GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID(tcCorp.OtherSpecialtyID);
                    txtSpecialty.Text = dt.Rows[0]["PRMEDICRATEDESC"].ToString();
                }
                else
                {
                    dt = EPolicy.TaskControl.Application.GetPRMEDICRATEBYISOCODE(0, tcCorp.CorporatePolicyDetailCollection.Rows[0]["IsoCode"].ToString().Trim());
                    dtOtherSpecialty = EPolicy.TaskControl.Application.GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID(tcCorp.OtherSpecialtyID);
                    txtSpecialty.Text = dt.Rows[0]["PRMEDICRATEDESC"].ToString();
                }

                if (tcCorp.OtherSpecialtyID != 0)
                    txtSpecialty.Text = dtOtherSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString() + " / " + txtSpecialty.Text;

                txtIsoCode.Text = tcCorp.CorporatePolicyDetailCollection.Rows[0]["IsoCode"].ToString().Trim();
                txtLicense.Text = "N/A";
            }
            else
            {
                if (_taskcontrol.PolicyType.Trim() == "PE")
                {
                    dt = EPolicy.TaskControl.Application.GetPRMEDICRATEBYISOCODE(0, _taskcontrol2.IsoCode);
                    dtOtherSpecialty = EPolicy.TaskControl.Application.GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID(_taskcontrol2.OtherSpecialtyID);
                }
                else
                {
                    dt = EPolicy.TaskControl.Application.GetPRMEDICRATEPRIMARYBYISOCODE(0, _taskcontrol2.IsoCode);
                    dtOtherSpecialty = EPolicy.TaskControl.Application.GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID(_taskcontrol2.OtherSpecialtyID);
                }        
   
                if (dt.Rows.Count > 0)
                    txtSpecialty.Text = dt.Rows[0]["PRMEDICRATEDESC"].ToString();
                else
                    txtSpecialty.Text = "";

                if (_taskcontrol2.OtherSpecialtyID != 0)
                    txtSpecialty.Text = dtOtherSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString() + " / " + txtSpecialty.Text;

                txtIsoCode.Text = _taskcontrol2.IsoCode;
                txtLicense.Text = _taskcontrol.Customer.License.Trim();
            }                                                      
            
            txtFrom.Text = LongDateEnglish(DateTime.Parse(_taskcontrol.EffectiveDate));
            txtTo.Text = LongDateEnglish(DateTime.Parse(_taskcontrol.ExpirationDate));
            txtRetro.Text = LongDateEnglish(DateTime.Parse(_taskcontrol.RetroactiveDate));

            if (_taskcontrol.PolicyType.Trim().Substring(0, 1) == "C")
            {
                if (_taskcontrol.PolicyType.Trim() == "CE")
                    txtLimits.Text = tcCorp.CorporatePolicyDetailCollection.Rows[0]["ExcessRate"].ToString().Trim();
                else
                    txtLimits.Text = tcCorp.CorporatePolicyDetailCollection.Rows[0]["PrimaryRate"].ToString().Trim();
            }
            else
            {
                if (_taskcontrol.PolicyType.Trim() == "PE")
                    txtLimits.Text = EPolicy.LookupTables.LookupTables.GetDescription("PRMedicalLimit", _taskcontrol2.PRMedicalLimit.ToString());
                else
                    txtLimits.Text = EPolicy.LookupTables.LookupTables.GetDescriptionToPRPrimaryLimit("PRPrimaryLimit", _taskcontrol2.PRMedicalLimit.ToString());
            }

            double totPrem = _taskcontrol.TotalPremium; //+ _taskcontrol.Charge;
            txtAdvancePremium.Text = totPrem.ToString("$###,###.00");

            txtCounter.Text = _taskcontrol.EntryDate.ToShortDateString();

            if (txtSpecialty.Text.Trim().ToUpper().Contains("NS") || txtSpecialty.Text.Trim().ToUpper().Contains("NO SURGERY"))
                txtExeptions2.Text = "N/A";
            else
                if (txtSpecialty.Text.Trim().ToUpper().Contains("MS"))
                    txtExeptions2.Text = "D";
                else
                    if (txtSpecialty.Text.Trim().ToUpper().Contains("NO MAJOR")) //Emergency Medicine No Major
                        txtExeptions2.Text = "D";
                    else
                        if (txtSpecialty.Text.Trim().ToUpper().Contains("SURGERY"))
                            txtExeptions2.Text = "C,D";
                        else
                            if (txtSpecialty.Text.Trim().ToUpper().Contains("MAJOR SURGERY"))
                                txtExeptions2.Text = "N/A";

            if (_taskcontrol.PolicyType.Trim().Substring(0, 1) == "C")
            {
                if (_taskcontrol.PolicyType.Trim() == "CE")
                //CAMBIO
                {
                    txtFormNumber.Text = "Forms: SED-E;E-102;E-103;R-109;E110";
                    txtCoverage.Text = "A. Individual Professional Excess Liability";
                }
                else
                    txtFormNumber.Text = "Forms: SED-P; P-101; P-102; P-103; P-109; P-110; P-111";

                if (_taskcontrol.PolicyType.Trim() == "CE")
                    label16.Text = "Form No. E-104    (01/2012)";
                else
                    label16.Text = "PRMD Form P-104    (06/2011)";
            }
            else
            {
                if (_taskcontrol.PolicyType.Trim() == "PE")
                    //CAMBIO
                {
                    txtFormNumber.Text = "Forms: SED-E;E-102;E-103;R-109;E110";
                    txtCoverage.Text = "A. Individual Professional Excess Liability";
                }
                else
                    txtFormNumber.Text = "Forms: SED-P; P-101; P-102; P-103; P-109; P-110; P-111";

                if (_taskcontrol.PolicyType.Trim() == "PE") 
                    label16.Text = "Form No. E-104    (01/2012)";

                else
                    label16.Text = "PRMD Form P-104    (06/2011)";
            }

            DateTime retroDate = Convert.ToDateTime(_taskcontrol.RetroactiveDate);

            if (_taskcontrol.PolicyType.Trim() == "PP" || _taskcontrol.PolicyType.Trim() == "CP")
                if(retroDate.Month >= 11)
                    txtFormNumber.Text = txtFormNumber.Text + "; P-114";
            else 
                if(retroDate.Month >= 11) 
                    txtFormNumber.Text = txtFormNumber.Text + "; E-114";
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
