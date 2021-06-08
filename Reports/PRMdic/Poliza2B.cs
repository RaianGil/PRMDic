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
    /// Summary description for Poliza2B.
    /// </summary>
    public partial class Poliza2B : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;
        private bool _certificate;

        public Poliza2B(EPolicy.TaskControl.Policy taskcontrol, bool certificate)
        {
            _taskcontrol = taskcontrol;
            _certificate = certificate;
            InitializeComponent();
        }

        private void Poliza2B_ReportStart(object sender, EventArgs e)
        {
            //rbtSpecialty.Clear();
            rbtSpecialty2.Clear();

            string currentSpecialty = String.Empty;
            string isoCode = String.Empty;
            EPolicy.TaskControl.CorporatePolicyQuote tcCorp = null;
            EPolicy.TaskControl.Policies _taskcontrol2 = null;

            if (_taskcontrol.PolicyType.Trim() == "CE" || _taskcontrol.PolicyType.Trim() == "AEC")
                tcCorp = EPolicy.TaskControl.CorporatePolicyQuote.GetCorporatePolicyQuote(_taskcontrol.TaskControlID, true);
            else
                _taskcontrol2 = EPolicy.TaskControl.Policies.GetPolicies(_taskcontrol.TaskControlID);

            if (_taskcontrol.EffectiveDate.Trim() != _taskcontrol.RetroactiveDate.Trim())
                label59.Visible = true;
            else
                label59.Visible = false;


            if (_taskcontrol.PolicyType.Trim() == "CE" || _taskcontrol.PolicyType.Trim() == "AEC")
            {
                isoCode = tcCorp.CorporatePolicyDetailCollection.Rows[0]["IsoCode"].ToString().Trim();
                label30.Text = tcCorp.CorporatePolicyDetailCollection.Rows.Count.ToString().Trim();
                label38.Text = tcCorp.QuantityTN6.ToString();
                rbtSpecialty2.Text = "The insured is engaged in practice as a: ";

                txtLicence.Text = "N/A";
                DataTable dt = EPolicy.TaskControl.Application.GetPRMEDICRATEBYISOCODE(0, tcCorp.CorporatePolicyDetailCollection.Rows[0]["IsoCode"].ToString().Trim());
                DataTable dtMainSpecialty = EPolicy.TaskControl.Application.GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID(tcCorp.MainSpecialtyID);
                DataTable dtOtherSpecialtyA = EPolicy.TaskControl.Application.GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID(tcCorp.OtherSpecialtyIDA);
                DataTable dtOtherSpecialtyB = EPolicy.TaskControl.Application.GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID(tcCorp.OtherSpecialtyIDB);
                //rbtSpecialty.Text = dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code: " + tcCorp.CorporatePolicyDetailCollection.Rows[0]["IsoCode"].ToString().Trim();

                if (tcCorp.OtherSpecialtyIDA != 0 || tcCorp.OtherSpecialtyIDB != 0)
                {
                    if (tcCorp.OtherSpecialtyIDA != 0)
                    {
                        rbtSpecialty2.Text = rbtSpecialty2.Text + dtOtherSpecialtyA.Rows[0]["PRMEDICSpecialtyDesc"].ToString();
                        currentSpecialty = dtOtherSpecialtyA.Rows[0]["PRMEDICSpecialtyDesc"].ToString();
                    }
                    if (tcCorp.OtherSpecialtyIDB != 0 && tcCorp.OtherSpecialtyIDA == 0)
                    {
                        rbtSpecialty2.Text = rbtSpecialty2.Text + dtOtherSpecialtyB.Rows[0]["PRMEDICSpecialtyDesc"].ToString();
                        currentSpecialty = currentSpecialty + dtOtherSpecialtyB.Rows[0]["PRMEDICSpecialtyDesc"].ToString(); 
                    }
                    else if (tcCorp.OtherSpecialtyIDB != 0)
                    {
                        rbtSpecialty2.Text = rbtSpecialty2.Text + " / " + dtOtherSpecialtyB.Rows[0]["PRMEDICSpecialtyDesc"].ToString();
                        currentSpecialty = currentSpecialty + " / " + dtOtherSpecialtyB.Rows[0]["PRMEDICSpecialtyDesc"].ToString(); 
                    }

                    rbtSpecialty2.Text = rbtSpecialty2.Text + " / " + dtMainSpecialty.Rows[0]["PRMEDICSpecialtydesc"].ToString() + " Class Code:" + dtMainSpecialty.Rows[0]["IsoCode"].ToString().Trim();

                    currentSpecialty = currentSpecialty + " / " + dtMainSpecialty.Rows[0]["PRMEDICSpecialtydesc"].ToString() + " Class Code:" + dtMainSpecialty.Rows[0]["IsoCode"].ToString().Trim();

                    rbtSpecialty2.Text = rbtSpecialty2.Text + " and is fully registered and licensed to practice his profession under"
                    + " the laws of the Commonwealth of Puerto Rico.";

                    this.rbtSpecialty2.SelectionStart = 41;
                    this.rbtSpecialty2.SelectionLength = currentSpecialty.Trim().Length;
                    rbtSpecialty2.SelectionFont = new Font(rbtSpecialty2.SelectionFont, FontStyle.Underline);
                    this.rbtSpecialty2.SelectionLength = 0;
                }
                else
                {
                    rbtSpecialty2.Text = rbtSpecialty2.Text + dtMainSpecialty.Rows[0]["PRMEDICSpecialtydesc"].ToString() + " Class Code:" + dtMainSpecialty.Rows[0]["IsoCode"].ToString().Trim();
                    currentSpecialty = dtMainSpecialty.Rows[0]["PRMEDICSpecialtydesc"].ToString() + " Class Code:" + dtMainSpecialty.Rows[0]["IsoCode"].ToString().Trim();

                    rbtSpecialty2.Text = rbtSpecialty2.Text + " and is fully registered and licensed to practice his profession under"
                    + " the laws of the Commonwealth of Puerto Rico.";
                    
                    this.rbtSpecialty2.SelectionStart = 41;
                    this.rbtSpecialty2.SelectionLength = currentSpecialty.Trim().Length;
                    rbtSpecialty2.SelectionFont = new Font(rbtSpecialty2.SelectionFont, FontStyle.Underline);
                    this.rbtSpecialty2.SelectionLength = 0;
                }


                /*if (dtOtherSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString().Length >= 45 && tcCorp.OtherSpecialtyID != 0)
                {
                    rbtSpecialty.Text = dtOtherSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString();
                    rbtSpecialty2.Text = " / " + dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code:" + tcCorp.CorporatePolicyDetailCollection.Rows[0]["IsoCode"].ToString().Trim()
                                        + " and is fully registered and licensed to practice his profession under"
                                        + " the laws of the Commonwealth of Puerto Rico.";

                    this.rbtSpecialty2.SelectionStart = 0;
                    this.rbtSpecialty2.SelectionLength = (dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code:" + tcCorp.CorporatePolicyDetailCollection.Rows[0]["IsoCode"].ToString().Trim()).Length + 3;
                    rbtSpecialty2.SelectionFont = new Font(rbtSpecialty.SelectionFont, FontStyle.Underline);
                    this.rbtSpecialty2.SelectionLength = 0;

                    this.rbtSpecialty.SelectionStart = 0;
                    this.rbtSpecialty.SelectionLength = (" / " + dtOtherSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString()).Length;
                    rbtSpecialty.SelectionFont = new Font(rbtSpecialty2.SelectionFont, FontStyle.Underline);
                    this.rbtSpecialty.SelectionLength = 0;
                }*/

                
            }
            else
            {
                isoCode = _taskcontrol2.IsoCode.ToString().Trim();
                label30.Text = "Not Covered";
                label38.Text = "Not Covered";
                //label39.Text = "1";

                if(_taskcontrol2.QuantityTN6.ToString() == "0")
                    label29.Text = "Not Covered";
                else
                    label29.Text = _taskcontrol2.QuantityTN6.ToString();

                rbtSpecialty2.Text = "The insured is engaged in practice as a: ";

                txtLicence.Text = _taskcontrol.Customer.License.Trim();
                DataTable dt = EPolicy.TaskControl.Application.GetPRMEDICRATEBYISOCODE(0, _taskcontrol2.IsoCode);
                DataTable dtOtherSpecialty = EPolicy.TaskControl.Application.GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID(_taskcontrol2.OtherSpecialtyID);
                //TxtSpecialty.Text = dt.Rows[0]["PRMEDICRATEDESC"].ToString() + "; Class Code:" + _taskcontrol2.IsoCode;

                if (_taskcontrol2.OtherSpecialtyID != 0)
                {
                    rbtSpecialty2.Text = rbtSpecialty2.Text + dtOtherSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString()
                                    + " / " + dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code:" + _taskcontrol2.IsoCode;
                    
                    currentSpecialty = dtOtherSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString()
                                    + " / " + dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code:" + _taskcontrol2.IsoCode;

                    rbtSpecialty2.Text = rbtSpecialty2.Text + " and is fully registered and licensed to practice his profession under"
                    + " the laws of the Commonwealth of Puerto Rico.";

                    this.rbtSpecialty2.SelectionStart = 41;
                    this.rbtSpecialty2.SelectionLength = (dtOtherSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString() + " / "
                                                             + dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code:" + _taskcontrol2.IsoCode).Length;
                    rbtSpecialty2.SelectionFont = new Font(rbtSpecialty2.SelectionFont, FontStyle.Underline);
                    this.rbtSpecialty2.SelectionLength = 0;
                }
                else
                {
                    rbtSpecialty2.Text = rbtSpecialty2.Text + dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code:" + _taskcontrol2.IsoCode;

                    currentSpecialty = dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code:" + _taskcontrol2.IsoCode;

                    rbtSpecialty2.Text = rbtSpecialty2.Text + " and is fully registered and licensed to practice his profession under"
                    + " the laws of the Commonwealth of Puerto Rico.";

                    this.rbtSpecialty2.SelectionStart = 41;
                    this.rbtSpecialty2.SelectionLength = (dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code:" + _taskcontrol2.IsoCode).Length;
                    rbtSpecialty2.SelectionFont = new Font(rbtSpecialty2.SelectionFont, FontStyle.Underline);
                    this.rbtSpecialty2.SelectionLength = 0;
                }

                /*if (dtOtherSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString().Length >= 45 && _taskcontrol2.OtherSpecialtyID != 0)
                {
                    rbtSpecialty.Text = dtOtherSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString();
                    rbtSpecialty2.Text = " / " + dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code:" + _taskcontrol2.IsoCode
                                        + " and is fully registered and licensed to practice his profession under"
                                        + " the laws of the Commonwealth of Puerto Rico.";

                    this.rbtSpecialty2.SelectionStart = 0;
                    this.rbtSpecialty2.SelectionLength = (" / " + dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code:" + _taskcontrol2.IsoCode).Length;
                    rbtSpecialty2.SelectionFont = new Font(rbtSpecialty.SelectionFont, FontStyle.Underline);
                    this.rbtSpecialty2.SelectionLength = 0;

                    this.rbtSpecialty.SelectionStart = 0;
                    this.rbtSpecialty.SelectionLength = (dtOtherSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString()).Length;
                    rbtSpecialty.SelectionFont = new Font(rbtSpecialty2.SelectionFont, FontStyle.Underline);
                    this.rbtSpecialty.SelectionLength = 0;
                }
                else
                {
                    lblUnderflow.Text = "and is fully registered and licensed to practice his profession under the laws of the Commonwealth";
                    label44.Text = "of Puerto Rico.";
                }*/

                
            }

            txtEntryDate.Text = DateTime.Now.ToShortDateString();//_taskcontrol.EntryDate.ToShortDateString();
            //if (_taskcontrol.PRMedicalLimit != 0)
            //{
            //    txtLimit.Text = EPolicy.LookupTables.LookupTables.GetDescription("PRMedicalLimit", _taskcontrol.PRMedicalLimit.ToString());
            //}

            //double totPrem = _taskcontrol.TotalPremium + _taskcontrol.Charge;
            //txtPremium.Text = totPrem.ToString("$###,###.00");
            //TxtTotal.Text = totPrem.ToString("$###,###.00");

            if (_certificate)
            {
                lblCertificate.Visible = true;
                lblCertificate.Text = "Hereby it is certified that this is an exact and true copy of the original Policy No. " +
                    _taskcontrol.PolicyType.Trim() + "-" + _taskcontrol.PolicyNo.Trim() + " issued by PRMDIC in favor of " +
                    (_taskcontrol.PolicyType.Contains("C") ? "" : "DR. ") +
                    _taskcontrol.Customer.FirstName.Trim() + " " + _taskcontrol.Customer.LastName1.Trim() + " " + _taskcontrol.Customer.LastName2.Trim() + ".";
            }

            if (currentSpecialty.Trim().ToUpper().Contains("NS") || currentSpecialty.Trim().ToUpper().Contains("NO SURGERY"))
                txtException.Text = "N/A";
            else
                if (currentSpecialty.Trim().ToUpper().Contains("MS"))
                    txtException.Text = "4";
                else
                    if (currentSpecialty.Trim().ToUpper().Contains("NO MAJOR")) //Emergency Medicine No Major
                        txtException.Text = "4";
                    else
                        if (isoCode == "80422")
                            txtException.Text = "4";
                        else
                            if (currentSpecialty.Trim().ToUpper().Contains("SURGERY"))
                                txtException.Text = "3,4";
                            else
                                if (currentSpecialty.Trim().ToUpper().Contains("MAJOR SURGERY"))
                                    txtException.Text = "N/A";
                                else
                                    if (currentSpecialty.Trim().ToUpper().Contains("ANGIOGRAPHY"))
                                        txtException.Text = "4";
                                    else
                                        if (currentSpecialty.Trim().ToUpper().Contains("NUCLEAR MEDICINE"))
                                            txtException.Text = "N/A";

            if (_taskcontrol.InsuranceCompany == "002")
            {
                label1.Text = "ASPEN AMERICAN INSURANCE COMPANY";
                label42.Text = "175 Capital Blvd. • Suite 100 • Rocky Hill • CT, 06067";
                label9.Text = "-Refer to the Schedule of Endorsements (ASPMME093):";
                label59.Visible = false;
                label58.Text = "Aspen American Insurance Company";
                textBox3.Text = "ASPMME091 0814"; 
            }

            if (_taskcontrol.Agency == "017")
            {
                imgFirmaResolve.Visible = true;
                imgFirmaColonial.Visible = false;
            }
            else if (_taskcontrol.Agency == "001" && _taskcontrol.City == 80)
            {
                imgFirmaColonial.Visible = true;
                imgFirmaResolve.Visible = false;
            }
            else
            {
                imgFirmaResolve.Visible = false;
                imgFirmaColonial.Visible = false;
            }

        }
    }
}
