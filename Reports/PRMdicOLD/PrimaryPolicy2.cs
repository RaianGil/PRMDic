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
    /// Summary description for PrimaryPolicy2.
    /// </summary>
    public partial class PrimaryPolicy2 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;

        public PrimaryPolicy2(EPolicy.TaskControl.Policy taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void PrimaryPolicy2_ReportStart(object sender, EventArgs e)
        {
            //rbtSpecialty.Clear();
            rbtSpecialty2.Clear();

            string currentSpecialty = String.Empty;
            EPolicy.TaskControl.CorporatePolicyQuote tcCorp = null;
            EPolicy.TaskControl.Policies _taskcontrol2 = null;

            if (_taskcontrol.PolicyType.Trim() == "CP")
                tcCorp = EPolicy.TaskControl.CorporatePolicyQuote.GetCorporatePolicyQuote(_taskcontrol.TaskControlID, true);
            else
                _taskcontrol2 = EPolicy.TaskControl.Policies.GetPolicies(_taskcontrol.TaskControlID);

            txtEntryDate.Text = _taskcontrol.EntryDate.ToShortDateString();

            //CAMBIO DAVID
            if (_taskcontrol.PolicyType.Trim() == "CP" || _taskcontrol.PolicyType.Trim() == "CE") //If Corporate, Licence="N/A"
                txtLicence.Text = "N/A";
            else
                txtLicence.Text = _taskcontrol.Customer.License.Trim();
            //CAMBIO


            if (_taskcontrol.PolicyType.Trim() == "CP")
            {
                label43.Text = tcCorp.CorporatePolicyDetailCollection.Rows.Count.ToString().Trim();
                label50.Text = tcCorp.QuantityTN6.ToString();
                rbtSpecialty2.Text = "The insured is engaged in practice as a: ";

                DataTable dt = EPolicy.TaskControl.Application.GetPRMEDICRATEPRIMARYBYISOCODE(0, tcCorp.CorporatePolicyDetailCollection.Rows[0]["IsoCode"].ToString().Trim());
                DataTable dtOtherSpecialty = EPolicy.TaskControl.Application.GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID(tcCorp.OtherSpecialtyID);
                //rbtSpecialty.Text = dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code: " + tcCorp.CorporatePolicyDetailCollection.Rows[0]["IsoCode"].ToString().Trim();
                if (tcCorp.OtherSpecialtyID != 0)
                {
                    rbtSpecialty2.Text = rbtSpecialty2.Text + dtOtherSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString()
                                    + " / " + dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code:" + tcCorp.CorporatePolicyDetailCollection.Rows[0]["IsoCode"].ToString().Trim();

                    currentSpecialty = dtOtherSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString()
                                    + " / " + dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code:" + tcCorp.CorporatePolicyDetailCollection.Rows[0]["IsoCode"].ToString().Trim();

                    rbtSpecialty2.Text = rbtSpecialty2.Text + " and is fully registered and licensed to practice his profession under"
                                                            + " the laws of the Commonwealth of Puerto Rico.";
                    this.rbtSpecialty2.SelectionStart = 41;
                    this.rbtSpecialty2.SelectionLength = (dtOtherSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString()
                                    +" / " + dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code:" + tcCorp.CorporatePolicyDetailCollection.Rows[0]["IsoCode"].ToString().Trim()).Length;
                    rbtSpecialty2.SelectionFont = new Font(rbtSpecialty2.SelectionFont, FontStyle.Underline);
                    this.rbtSpecialty2.SelectionLength = 0;
                }
                else
                {
                    rbtSpecialty2.Text = rbtSpecialty2.Text + dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code:" + tcCorp.CorporatePolicyDetailCollection.Rows[0]["IsoCode"].ToString().Trim();
                    currentSpecialty = dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code:" + tcCorp.CorporatePolicyDetailCollection.Rows[0]["IsoCode"].ToString().Trim();

                    rbtSpecialty2.Text = rbtSpecialty2.Text + " and is fully registered and licensed to practice his profession under"
                                                            + " the laws of the Commonwealth of Puerto Rico.";
                    
                    this.rbtSpecialty2.SelectionStart = 41;
                    this.rbtSpecialty2.SelectionLength = (dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code:" + tcCorp.CorporatePolicyDetailCollection.Rows[0]["IsoCode"].ToString().Trim()).Length;
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
                label43.Text = "NOT COVERED";
                label50.Text = "NOT COVERED";
                rbtSpecialty2.Text = "The insured is engaged in practice as a: ";

                DataTable dt = EPolicy.TaskControl.Application.GetPRMEDICRATEPRIMARYBYISOCODE(0, _taskcontrol2.IsoCode);
                DataTable dtOtherSpecialty = EPolicy.TaskControl.Application.GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID(_taskcontrol2.OtherSpecialtyID);
                //TxtSpecialty.Text = dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code: " + _taskcontrol2.IsoCode.Trim();

                if (_taskcontrol2.OtherSpecialtyID != 0)
                {
                    rbtSpecialty2.Text = rbtSpecialty2.Text + dtOtherSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString()
                                    +" / " + dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code:" + _taskcontrol2.IsoCode;

                    currentSpecialty = dtOtherSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString()
                                    + " / " + dt.Rows[0]["PRMEDICRATEDESC"].ToString() + " Class Code:" + _taskcontrol2.IsoCode;

                    rbtSpecialty2.Text = rbtSpecialty2.Text + " and is fully registered and licensed to practice his profession under"
                                                            + " the laws of the Commonwealth of Puerto Rico.";

                    this.rbtSpecialty2.SelectionStart = 41;
                    this.rbtSpecialty2.SelectionLength = ( dtOtherSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString() + " / "
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


                /*if (dtOtherSpecialty.Rows[0]["PRMEDICSpecialtyDesc"].ToString() > 45 && _taskcontrol2.OtherSpecialtyID != 0)
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
                }*/
              }

                txtEntryDate.Text = _taskcontrol.EntryDate.ToShortDateString();

                if (currentSpecialty.Trim().ToUpper().Contains("NS") || currentSpecialty.Trim().ToUpper().Contains("NO SURGERY"))
                    txtException.Text = "N/A";
                else
                    if (currentSpecialty.Trim().ToUpper().Contains("MS"))
                        txtException.Text = "4";
                    else
                        if (currentSpecialty.Trim().ToUpper().Contains("NO MAJOR")) //Emergency Medicine No Major
                            txtException.Text = "4";
                        else
                            if (currentSpecialty.Trim().ToUpper().Contains("SURGERY"))
                                txtException.Text = "3,4";
                            else
                                if (currentSpecialty.Trim().ToUpper().Contains("MAJOR SURGERY"))
                                    txtException.Text = "N/A";
                                //CAMBIO DAVID
                                else
                                    if (currentSpecialty.Trim().ToUpper().Contains("ANGIOGRAPHY"))
                                        txtException.Text = "4";
                //TERMINA CAMBIO
            }

    }
}