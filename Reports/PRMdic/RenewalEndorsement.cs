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
        int _employeeCount;

        public RenewalEndorsement(EPolicy.TaskControl.Policy taskcontrol, int employeeCount)
        {
            _taskcontrol = taskcontrol;
            _employeeCount = employeeCount;
            InitializeComponent();
        }

        private void RenewalEndorsement_ReportStart(object sender, EventArgs e)
        {
            EPolicy.TaskControl.CorporatePolicyQuote tcCorp = null;
            EPolicy.TaskControl.Policies _taskcontrol2 = null;

            if (_taskcontrol.PolicyType.Trim().Contains("C"))
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

            lblProfessional.Text = "NONE";

            if (_taskcontrol.PolicyType.Trim().Contains("C"))
            {
                int empSum = (tcCorp.QuantityTN1 + tcCorp.QuantityTN2 + tcCorp.QuantityTN3 + tcCorp.QuantityTN4 + tcCorp.QuantityTN5);
                int empESum = (tcCorp.EQuantityTN1 + tcCorp.EQuantityTN2 + tcCorp.EQuantityTN3 + tcCorp.EQuantityTN4 + tcCorp.EQuantityTN5);

                lblProfessional2.Visible = true;
                lblProfessional3.Visible = true;

                txtProfessional.Visible = true;
                txtProfessional2.Visible = true;
                txtProfessional3.Visible = true;

                lblProfessional.Text = "Number of Employees:";
                txtProfessional.Text = _employeeCount.ToString();


                if ((_taskcontrol.PolicyType.Trim() == "CP" || _taskcontrol.PolicyType.Trim() == "AEC" || _taskcontrol.PolicyType.Trim() == "APC") && (empSum != 0 || _employeeCount != 0))
                {
                    txtProfessional2.Text = "Physicians Assistant: " + tcCorp.QuantityTN1 + " Nurse Midwife: " + tcCorp.QuantityTN2 + " Nurse Anesthetist: " + tcCorp.QuantityTN3 +
                                           " Nurse Practitioner: " + tcCorp.QuantityTN4 + " All Other Personel: " + tcCorp.QuantityTN5;

                    txtProfessional3.Text = (empSum + _employeeCount).ToString();


                    //txtProfessional.Text = "Physicians Assistant:   " + tcCorp.QuantityTN1 + "    Nurse Practitioner:     " + tcCorp.QuantityTN4 + "\r\n" +
                    //                       "Nurse Midwife:            " + tcCorp.QuantityTN2 + "    All Other Personel:     " + tcCorp.QuantityTN5 + "\r\n" +
                    //                       "Nurse Anesthetist:       " + tcCorp.QuantityTN3 + "\r\n" +
                    //                       "TOTAL:                  " + empSum;

                }
                else if (empESum != 0 || _employeeCount != 0)
                {
                    txtProfessional2.Text = "Physicians Assistant: " + tcCorp.EQuantityTN1 + " Nurse Midwife: " + tcCorp.EQuantityTN2 + " Nurse Anesthetist: " + tcCorp.EQuantityTN3 +
                                           " Nurse Practitioner: " + tcCorp.EQuantityTN4 + " All Other Personel: " + tcCorp.EQuantityTN5;

                    txtProfessional3.Text = (empESum + _employeeCount).ToString();

                    //txtProfessional.Text = "Physicians Assistant:   " + tcCorp.EQuantityTN1 + "    Nurse Practitioner:     " + tcCorp.EQuantityTN4 + "\r\n" +
                    //                       "Nurse Midwife:            " + tcCorp.EQuantityTN2 + "    All Other Personel:     " + tcCorp.EQuantityTN5 + "\r\n" +
                    //                       "Nurse Anesthetist:       " + tcCorp.EQuantityTN3 + "\r\n" +
                    //                       "TOTAL:                  " + empESum;
                }
            }
            else if (_taskcontrol.PolicyType.Trim() == "PE" || _taskcontrol.PolicyType.Trim() == "PP" || _taskcontrol.PolicyType.Trim() == "AAP" || _taskcontrol.PolicyType.Trim() == "AAE")
            {
                int empSum = (_taskcontrol2.QuantityTN1 + _taskcontrol2.QuantityTN2 + _taskcontrol2.QuantityTN3 + _taskcontrol2.QuantityTN4 + _taskcontrol2.QuantityTN5);
                int empESum = (_taskcontrol2.EQuantityTN1 + _taskcontrol2.EQuantityTN2 + _taskcontrol2.EQuantityTN3 + _taskcontrol2.EQuantityTN4 + _taskcontrol2.EQuantityTN5);

                lblProfessional2.Visible = true;
                lblProfessional3.Visible = true;

                txtProfessional.Visible = false;
                txtProfessional2.Visible = true;
                txtProfessional3.Visible = true;

                lblProfessional.Text = "";


                if ((_taskcontrol.PolicyType.Trim() == "PP" || _taskcontrol.PolicyType.Trim() == "AAP") && empSum != 0)
                {
                    txtProfessional2.Text = "Physicians Assistant: " + _taskcontrol2.QuantityTN1 + " Nurse Midwife: " + _taskcontrol2.QuantityTN2 + " Nurse Anesthetist: " + _taskcontrol2.QuantityTN3 +
                                           " Nurse Practitioner: " + _taskcontrol2.QuantityTN4 + " All Other Personel: " + _taskcontrol2.QuantityTN5;

                    txtProfessional3.Text = (empSum + _employeeCount).ToString();


                    //txtProfessional.Text = "Physicians Assistant:   " + tcCorp.QuantityTN1 + "    Nurse Practitioner:     " + tcCorp.QuantityTN4 + "\r\n" +
                    //                       "Nurse Midwife:            " + tcCorp.QuantityTN2 + "    All Other Personel:     " + tcCorp.QuantityTN5 + "\r\n" +
                    //                       "Nurse Anesthetist:       " + tcCorp.QuantityTN3 + "\r\n" +
                    //                       "TOTAL:                  " + empSum;

                }
                else if (empESum != 0)
                {
                    txtProfessional2.Text = "Physicians Assistant: " + _taskcontrol2.EQuantityTN1 + " Nurse Midwife: " + _taskcontrol2.EQuantityTN2 + " Nurse Anesthetist: " + _taskcontrol2.EQuantityTN3 +
                                           " Nurse Practitioner: " + _taskcontrol2.EQuantityTN4 + " All Other Personel: " + _taskcontrol2.EQuantityTN5;

                    txtProfessional3.Text = (empESum + _employeeCount).ToString();

                    //txtProfessional.Text = "Physicians Assistant:   " + tcCorp.EQuantityTN1 + "    Nurse Practitioner:     " + tcCorp.EQuantityTN4 + "\r\n" +
                    //                       "Nurse Midwife:            " + tcCorp.EQuantityTN2 + "    All Other Personel:     " + tcCorp.EQuantityTN5 + "\r\n" +
                    //                       "Nurse Anesthetist:       " + tcCorp.EQuantityTN3 + "\r\n" +
                    //                       "TOTAL:                  " + empESum;
                }
            }

            txtAudit.Text = "ANNUALLY";

            DataTable dt = null;
            DataTable dtOtherSpecialty = null;


            if (_taskcontrol.PolicyType.Trim() == "CP" || _taskcontrol.PolicyType.Trim() == "CE" || _taskcontrol.PolicyType.Trim() == "APC" || _taskcontrol.PolicyType.Trim() == "AEC")
            {
                if (_taskcontrol.PolicyType.Trim() == "CP" || _taskcontrol.PolicyType.Trim() == "APC")
                {
                    DataTable dtMainSpecialty = EPolicy.TaskControl.Application.GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID(tcCorp.MainSpecialtyID);
                    DataTable dtOtherSpecialtyA = EPolicy.TaskControl.Application.GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID(tcCorp.OtherSpecialtyIDA);
                    DataTable dtOtherSpecialtyB = EPolicy.TaskControl.Application.GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID(tcCorp.OtherSpecialtyIDB);
                    dt = EPolicy.TaskControl.Application.GetPRMEDICRATEPRIMARYBYISOCODE(0, dtMainSpecialty.Rows[0]["IsoCode"].ToString().Trim());
                    //txtSpecialty.Text = dt.Rows[0]["PRMEDICRATEDESC"].ToString();

                    if (tcCorp.OtherSpecialtyIDA != 0 || tcCorp.OtherSpecialtyIDB != 0)
                    {
                        if (tcCorp.OtherSpecialtyIDA != 0)
                        {
                            txtSpecialty.Text = txtSpecialty.Text + dtOtherSpecialtyA.Rows[0]["PRMEDICSpecialtyDesc"].ToString();
                        }

                        if (tcCorp.OtherSpecialtyIDB != 0 && tcCorp.OtherSpecialtyIDA == 0)
                        {
                            txtSpecialty.Text = txtSpecialty.Text + dtOtherSpecialtyB.Rows[0]["PRMEDICSpecialtyDesc"].ToString();
                            //currentSpecialty = currentSpecialty + dtOtherSpecialtyB.Rows[0]["PRMEDICSpecialtyDesc"].ToString(); 
                        }
                        else if (tcCorp.OtherSpecialtyIDB != 0)
                        {
                            txtSpecialty.Text = txtSpecialty.Text + " / " + dtOtherSpecialtyB.Rows[0]["PRMEDICSpecialtyDesc"].ToString();
                            //currentSpecialty = currentSpecialty + " / " + dtOtherSpecialtyB.Rows[0]["PRMEDICSpecialtyDesc"].ToString(); 
                        }
                        txtSpecialty.Text = txtSpecialty.Text + " / " + dtMainSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString();
                    }
                    else
                    {
                        dtMainSpecialty = EPolicy.TaskControl.Application.GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID(tcCorp.MainSpecialtyID);
                        txtSpecialty.Text = dtMainSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString();
                    }

                    txtIsoCode.Text = dtMainSpecialty.Rows[0]["IsoCode"].ToString().Trim();
                    txtLicense.Text = "N/A";
                }
                else
                {

                    DataTable dtMainSpecialty = EPolicy.TaskControl.Application.GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID(tcCorp.MainSpecialtyID);
                    DataTable dtOtherSpecialtyA = EPolicy.TaskControl.Application.GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID(tcCorp.OtherSpecialtyIDA);
                    DataTable dtOtherSpecialtyB = EPolicy.TaskControl.Application.GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID(tcCorp.OtherSpecialtyIDB);
                    dt = EPolicy.TaskControl.Application.GetPRMEDICRATEBYISOCODE(0, dtMainSpecialty.Rows[0]["IsoCode"].ToString().Trim());
                    //txtSpecialty.Text = dt.Rows[0]["PRMEDICRATEDESC"].ToString();

                    if (tcCorp.OtherSpecialtyIDA != 0 || tcCorp.OtherSpecialtyIDB != 0)
                    {
                        if (tcCorp.OtherSpecialtyIDA != 0)
                        {
                            txtSpecialty.Text = txtSpecialty.Text + dtOtherSpecialtyA.Rows[0]["PRMEDICSpecialtyDesc"].ToString();
                        }

                        if (tcCorp.OtherSpecialtyIDB != 0 && tcCorp.OtherSpecialtyIDA == 0)
                        {
                            txtSpecialty.Text = txtSpecialty.Text + dtOtherSpecialtyB.Rows[0]["PRMEDICSpecialtyDesc"].ToString();
                            //currentSpecialty = currentSpecialty + dtOtherSpecialtyB.Rows[0]["PRMEDICSpecialtyDesc"].ToString(); 
                        }
                        else if (tcCorp.OtherSpecialtyIDB != 0)
                        {
                            txtSpecialty.Text = txtSpecialty.Text + " / " + dtOtherSpecialtyB.Rows[0]["PRMEDICSpecialtyDesc"].ToString();
                            //currentSpecialty = currentSpecialty + " / " + dtOtherSpecialtyB.Rows[0]["PRMEDICSpecialtyDesc"].ToString(); 
                        }
                        txtSpecialty.Text = txtSpecialty.Text + " / " + dtMainSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString();
                    }
                    else
                    {
                        dtMainSpecialty = EPolicy.TaskControl.Application.GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID(tcCorp.MainSpecialtyID);
                        txtSpecialty.Text = dtMainSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString();
                    }

                    txtIsoCode.Text = dtMainSpecialty.Rows[0]["IsoCode"].ToString().Trim();
                    txtLicense.Text = "N/A";
                }
            }
            else
            {
                if (_taskcontrol.PolicyType.Trim() == "PE" || _taskcontrol.PolicyType.Trim() == "AAE")
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

            if (_taskcontrol.PolicyType.Trim().Contains("C"))
            {
                if ((_taskcontrol.PolicyType.Trim() == "CE" || _taskcontrol.PolicyType.Trim() == "AEC") && _taskcontrol.PolicyNo.Trim() == "10026")
                    txtLimits.Text = "1,000,000/1,000,000";
                else if ((_taskcontrol.PolicyType.Trim() == "CE" || _taskcontrol.PolicyType.Trim() == "AEC"))
                    txtLimits.Text = tcCorp.CorporatePolicyDetailCollection.Rows[0]["ExcessRate"].ToString().Trim();
                else
                    txtLimits.Text = tcCorp.CorporatePolicyDetailCollection.Rows[0]["PrimaryRate"].ToString().Trim();
            }
            else
            {
                if (_taskcontrol.PolicyType.Trim() == "PE" || _taskcontrol.PolicyType.Trim() == "AAE")
                    txtLimits.Text = EPolicy.LookupTables.LookupTables.GetDescription("PRMedicalLimit", _taskcontrol2.PRMedicalLimit.ToString());
                else
                    txtLimits.Text = EPolicy.LookupTables.LookupTables.GetDescriptionToPRPrimaryLimit("PRPrimaryLimit", _taskcontrol2.PRMedicalLimit.ToString());
            }

            double totPrem = _taskcontrol.TotalPremium; //+ _taskcontrol.Charge;
            txtAdvancePremium.Text = totPrem.ToString("$###,###.00");

            txtCounter.Text = DateTime.Now.ToShortDateString();//_taskcontrol.EntryDate.ToShortDateString();

            if (_taskcontrol.PolicyType.Trim().Contains("C"))
            {
                if (txtSpecialty.Text.Trim().ToUpper().Contains("NS") || txtSpecialty.Text.Trim().ToUpper().Contains("NO SURGERY"))
                    txtExeptions2.Text = "N/A";

                if (txtSpecialty.Text.Trim().ToUpper().Contains("MS"))
                    txtExeptions2.Text = "D";

                if (txtSpecialty.Text.Trim().ToUpper().Contains("NO MAJOR")) //Emergency Medicine No Major
                    txtExeptions2.Text = "D";

                if (txtSpecialty.Text.Trim().ToUpper().Contains("SURGERY"))
                    txtExeptions2.Text = "C,D";

                if (txtSpecialty.Text.Trim().ToUpper().Contains("MAJOR SURGERY"))
                    txtExeptions2.Text = "N/A";

                if (txtSpecialty.Text.Trim().ToUpper().Contains("ANGIOGRAPHY, ARTERIOGRAPHY, CATHE."))
                    txtExeptions2.Text = "D";
            }
            else
            {
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
                                else
                                    if (txtSpecialty.Text.Trim().ToUpper().Contains("ANGIOGRAPHY, ARTERIOGRAPHY, CATHE."))
                                        txtExeptions2.Text = "D";
            }

            if (_taskcontrol.PolicyType.Trim().Contains("C"))
            {
                if (_taskcontrol.PolicyType.Trim() == "CE" || _taskcontrol.PolicyType.Trim() == "AEC")
                //CAMBIO
                {
                    txtFormNumber.Text = "Forms: SED-E;E-102;E-103;R-109;E110";
                    txtCoverage.Text = "Corporate Excess Liability";
                }
                else
                {
                    txtFormNumber.Text = "Forms: SED-P; P-101; P-102; P-103; P-109; P-110; P-111";
                    txtCoverage.Text = "Corporate Primary Liability";
                }

                if (_taskcontrol.PolicyType.Trim() == "CE" || _taskcontrol.PolicyType.Trim() == "AEC")
                    label16.Text = "PRMD Form CE-104    (07/2013)";
                else
                    label16.Text = "PRMD Form CP-104    (07/2013)";
            }
            else
            {
                if (_taskcontrol.PolicyType.Trim() == "PE" || _taskcontrol.PolicyType.Trim() == "AAE")
                //CAMBIO
                {
                    txtFormNumber.Text = "Forms: SED-E;E-102;E-103;R-109;E110";
                    txtCoverage.Text = "A. Individual Professional Excess Liability";
                }
                else
                    txtFormNumber.Text = "Forms: SED-P; P-101; P-102; P-103; P-109; P-110; P-111";

                if (_taskcontrol.PolicyType.Trim() == "PE" || _taskcontrol.PolicyType.Trim() == "AAE")
                    label16.Text = "Form No. E-104    (01/2012)";

                else
                    label16.Text = "PRMD Form P-104    (06/2011)";
            }

            DateTime retroDate = Convert.ToDateTime(_taskcontrol.EffectiveDate);

            if (_taskcontrol.PolicyType.Trim() == "PP" || _taskcontrol.PolicyType.Trim() == "CP" || _taskcontrol.PolicyType.Trim() == "ACP" || _taskcontrol.PolicyType.Trim() == "AAP")
                if (_taskcontrol.Charge != 0)
                    txtFormNumber.Text = txtFormNumber.Text + "; P-115";

            if (_taskcontrol.PolicyType.Trim() == "PE" || _taskcontrol.PolicyType.Trim() == "CE" | _taskcontrol.PolicyType.Trim() == "AAE" || _taskcontrol.PolicyType.Trim() == "AEC")
                if (_taskcontrol.Charge != 0)
                    txtFormNumber.Text = txtFormNumber.Text + "; E-114";

            if (_taskcontrol.InsuranceCompany == "002")
            {
                picture1.Visible = true;
                picture2.Visible = false;
                label16.Text = "ASPMM083 0814";
            }

            if (_taskcontrol.Agency == "017")
            {
                imgFirmaResolve.Visible = true;
                imgFirmaColonial.Visible = false;
            }
            else if (_taskcontrol.Agency == "001" && _taskcontrol.City == 80)
            {
                imgFirmaResolve.Visible = false;
                imgFirmaColonial.Visible = true;
            }
            else
            {
                imgFirmaResolve.Visible = false;
                imgFirmaColonial.Visible = false;
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
    }
}
