using System;
using System.Data;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using DataDynamics;
using System.Drawing;
using EPolicy.TaskControl;
using EPolicy.Quotes;
using EPolicy.Customer;
using EPolicy.LookupTables;

namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for AutoMasterPolicyDI.
    /// </summary>
    public partial class AutoMasterPolicyDI : DataDynamics.ActiveReports.ActiveReport3
    {
        private int CountDataIndex;
        private int index;
        private string _CopyValue;
        //private         PolManager.QuoteAuto _policy ;
        private EPolicy.TaskControl.QuoteAuto _policy;
        private int GroupCount = 1;
        bool Visible = false;
        private PrintPolicy end = new PrintPolicy();
        private decimal _VehicleTotal = 0;
        private decimal _VehicleGrandTotal = 0;

        public AutoMasterPolicyDI(EPolicy.TaskControl.QuoteAuto taskcontrol, string copyValue)
        {
            _policy = taskcontrol;
            _CopyValue = copyValue;
            InitializeComponent();
        }

        private void AutoMasterPolicyDI_DataInitialize(object sender, EventArgs e)
        {
            this.Fields.Clear();

            EPolicy.Quotes.AutoCover AC = null;
            AC = (EPolicy.Quotes.AutoCover)_policy.AutoCovers[0];

            EPolicy.Quotes.CoverBreakdown CB = new EPolicy.Quotes.CoverBreakdown();
            CB.Type = (int)EPolicy.Quotes.Enumerators.Premiums.Comprehensive;
            EPolicy.Quotes.CoverBreakdown CBPrem = (EPolicy.Quotes.CoverBreakdown)AC.Breakdown[AC.Breakdown.IndexOf(CB)];

            for (int i = 1; i <= CBPrem.Breakdown.Count; i++)
            {
                this.Fields.Add("Comprehensive" + i.ToString());
                this.Fields.Add("Collision" + i.ToString());
                this.Fields.Add("Depreciation" + i.ToString());
                this.Fields.Add("AnnualPremium" + i.ToString());
                this.Fields.Add("DeducibleCompLimit" + i.ToString());
                this.Fields.Add("DeducibleCollLimit" + i.ToString());
                this.Fields.Add("LeaseLoanGap" + i.ToString());
            }
            this.Fields.Add("Charge");
            this.Fields.Add("TotalPremium");


            for (int i = 1; i <= CBPrem.Breakdown.Count; i++)
            {
                this.Fields["Comprehensive" + i.ToString()].Value = "";
                this.Fields["Collision" + i.ToString()].Value = "";
                this.Fields["Depreciation" + i.ToString()].Value = "";
                this.Fields["AnnualPremium" + i.ToString()].Value = "";
                this.Fields["DeducibleCompLimit" + i.ToString()].Value = "";
                this.Fields["DeducibleCollLimit" + i.ToString()].Value = "";
                this.Fields["LeaseLoanGap" + i.ToString()].Value = "";
                this.Fields["Charge"].Value = "";
                this.Fields["TotalPremium"].Value = "";

            }
            CountDataIndex = 1;
            index = 0;
        }

        private void AutoMasterPolicyDI_ReportStart(object sender, EventArgs e)
        {
            txtPolicyNo.Text = _policy.Policy.PolicyNo.ToString().Trim();
            txtCertificate.Text = _policy.Policy.PolicyType.ToString().Trim() + " - " + _policy.Policy.Certificate.ToString().Trim();
            txtEffectiveDate.Text = _policy.EffectiveDate.ToString();
            txtExpirationDate.Text = _policy.ExpirationDate.ToString();
            txtEmision.Text = _policy.EffectiveDate.ToString();

            txtCustomerName.Text = _policy.Customer.FirstName.Trim() + ' ' + _policy.Customer.Initial.Trim() + ' ' + _policy.Customer.LastName1.Trim() + ' ' + _policy.Customer.LastName2.Trim();
            txtCustomerAddr1.Text = _policy.Customer.Address1.Trim() + ' ' + _policy.Customer.Address2.Trim();
            txtCustomerAddr2.Text = _policy.Customer.City.Trim() + ' ' + _policy.Customer.State.Trim() + ' ' + _policy.Customer.ZipCode.Trim();
            txtCustomerAddr3.Text = _policy.Customer.AddressPhysical1.Trim() + ' ' + _policy.Customer.AddressPhysical2.Trim();
            txtCustomerAddr4.Text = _policy.Customer.CityPhysical.Trim() + ' ' + _policy.Customer.StatePhysical.Trim() + ' ' + _policy.Customer.ZipPhysical.Trim();

            EPolicy.LookupTables.Agency agency = new EPolicy.LookupTables.Agency();
            agency = agency.GetAgency(_policy.Agency);
            txtAgencyDesc.Text = agency.AgencyDesc.ToString().Trim();
            txtAgencyAddr1.Text = agency.agy_addr1.Trim() + " -  " + agency.agy_addr2.ToString().Trim();
            txtAgencyAddr2.Text = agency.agy_city.Trim() + " -  " + agency.agy_st.ToString().Trim() + " -  " + agency.agy_zip.ToString().Trim();

            txtAutoEnd.Text = "IL 00 17 11 98, IL 00 21 04 98, CA 01 14 01 98, IL 01 36 05 04, CA 23 57 12 02, CA 00 01 01 87, CA 23 01 01 87, CA 99 44 01 87,  CA 99 29 02 91, CA 00 10 01 87, CA 00 29 12 88, CA 23 05 01 87,  OPT 2003 (09/05), OPT 0002 (09/05)";
            EPolicy.LookupTables.Bank bank = new Bank();
            bank = bank.GetBank(_policy.Bank);
            txtBank.Text = bank.BankID.Trim() + " -  " + bank.BankDesc.ToString().Trim();

            EPolicy.LookupTables.Agent agent = new Agent();
            agent = agent.GetAgent(_policy.Agent);
            txtAgent.Text = agent.CarsID.Trim() + " -  " + agent.AgentDesc.ToString().Trim();
        }

        private void AutoMasterPolicyDI_FetchData(object sender, FetchEventArgs eArgs)
        {
            try
            {
                if (this.CountDataIndex <= _policy.AutoCovers.Count)
                {
                    eArgs.EOF = false;

                    EPolicy.Quotes.AutoCover AC = null;
                    AC = (EPolicy.Quotes.AutoCover)_policy.AutoCovers[index];

                    TxtVehicleCount.Text = CountDataIndex.ToString();
                    TxtVehicleYear.Text = LookupTables.GetDescription("VehicleYear", AC.VehicleYear.ToString());
                    TxtMake.Text = LookupTables.GetDescription("VehicleMake", AC.VehicleMake.ToString()).Trim();
                    TxtModel.Text = LookupTables.GetDescription("VehicleModel", AC.VehicleModel.ToString()).Trim();
                    TxtVinNo.Text = AC.VIN;

                    EPolicy.Quotes.CoverBreakdown CB = new EPolicy.Quotes.CoverBreakdown();
                    CB.Type = (int)EPolicy.Quotes.Enumerators.Premiums.IsoCode;
                    EPolicy.Quotes.CoverBreakdown ISOC = (EPolicy.Quotes.CoverBreakdown)AC.Breakdown[AC.Breakdown.IndexOf(CB)];
                    //ISOC.Breakdown[0].ToString();

                    if (ISOC.Breakdown[0].ToString() == null || ISOC.Breakdown[0].ToString() == "")
                    {
                        TxtIsoCode.Text = "";
                    }
                    else
                    {
                        TxtIsoCode.Text = ISOC.Breakdown[0].ToString();
                    }

                    if (AC.Cost.ToString() == "")
                        TxtVehicleCost.Value = "";
                    else
                        TxtVehicleCost.Value = AC.Cost.ToString();

                    //if (AC.PurchaseDate == "")
                    //    TxtPurchaserDate.Text = "";
                    //else
                    //    TxtPurchaserDate.Text = DateTime.Parse(AC.PurchaseDate).Month.ToString() + " / " + DateTime.Parse(AC.PurchaseDate).Year.ToString();

                    //if (AC.NewUse == 1)
                    //    txtNewUse.Value = "USADO";
                    //else
                    //    txtNewUse.Value = "NUEVO";

                    txtNewUse.Text = LookupTables.GetDescription("Territory", AC.Territory.ToString()).Trim();
                    txtAlarm.Text = LookupTables.GetDescription("AlarmType", AC.AlarmType.ToString()).Trim();

                    //GroupData();
                    //TotalPremiumByVehicle(AC);

                    TxtCopyValue.Text = _CopyValue;

                    if (CountDataIndex == 1)
                    {
                        //Endosos();
                        //this.Fields["Refrendata"].Value = _policy.EntryDate.ToShortDateString();
                    }

                    if (this.CountDataIndex == _policy.AutoCovers.Count)
                    {
                        txtPremium.Text = _policy.TotalPremium.ToString();
                        txtCharge.Text = _policy.Charge.ToString();
                        decimal totprem = _policy.TotalPremium + _policy.Charge;   //_policy.TotalPremium + _policy.Charge;
                        txtTotalPremium.Text = totprem.ToString();
                    }
   

                    //////////////////
                    //EPolicy.Quotes.AutoCover AC = null;
                    AC = (EPolicy.Quotes.AutoCover)_policy.AutoCovers[0];

                    //FillDate(AC);
                    FillBreakDownByType(AC);

                    this.Fields["Charge"].Value = _policy.Charge.ToString();
                    decimal totprem3 = _policy.TotalPremium + _policy.Charge;
                    this.Fields["TotalPremium"].Value = totprem3.ToString();

                    txtDedColl.Text = "$ " + EPolicy.LookupTables.LookupTables.GetDescription("CollisionDeductible", AC.CollisionDeductible.ToString()).Trim();
                    txtDedComp.Text = "$ " + EPolicy.LookupTables.LookupTables.GetDescription("ComprehensiveDeductible", AC.ComprehensiveDeductible.ToString()).Trim();
                    txtPremium.Text = AC.TotalAmount.ToString("$ #,##0.00").Trim();
                    txtCharge.Text = AC.Charge.ToString("$ #,##0.00").Trim();
                    decimal totprem2 = AC.TotalAmount + AC.Charge;
                    txtTotalPremium.Text = totprem2.ToString("$ #,##0.00");

                    EPolicy.Quotes.CoverBreakdown CB2 = (EPolicy.Quotes.CoverBreakdown)AC.Breakdown[0];
                    string BRType = EPolicy.Quotes.Enumerators.DecodePremiums(CB2.Type);

                    EPolicy.Quotes.CoverBreakdown ISOC2 = (EPolicy.Quotes.CoverBreakdown)AC.Breakdown[AC.Breakdown.IndexOf(CB2)];
                    ISOC2.Breakdown[0].ToString();

                    DateTime date = DateTime.Now;
                    txtEmision.Text = date.ToShortDateString().Trim();

                    for (int a = 1; a <= CB.Breakdown.Count; a++)
                    {

                        this.groupFooter1.Controls["txtComp" + a.ToString()].Visible = true;
                        this.groupFooter1.Controls["txtColl" + a.ToString()].Visible = true;
                        this.groupFooter1.Controls["txtOther" + a.ToString()].Visible = true;
                        this.groupFooter1.Controls["txtTotal" + a.ToString()].Visible = true;

                        //eArgs.EOF = true;
                    }

                }
                else
                {
                    eArgs.EOF = true;
                }

                this.CountDataIndex++;
                this.index++;
            }
            catch (Exception exc)
            {
                if (eArgs != null)
                    eArgs.EOF = true;
            }
        }

        private void FillBreakDownByType(EPolicy.Quotes.AutoCover AC)
        {
            for (int a = 1; a < AC.Breakdown.Count; a++)
            {
                EPolicy.Quotes.CoverBreakdown CB = (EPolicy.Quotes.CoverBreakdown)AC.Breakdown[a - 1];
                string BRType = EPolicy.Quotes.Enumerators.DecodePremiums(CB.Type);

                switch (BRType)
                {
                    case "Depreciation":
                    case "Comprehensive":
                    case "Collision":
                    case "Annual Premium":
                        for (int i = 1; i <= CB.Breakdown.Count; i++)
                        {
                            this.Fields[BRType.Replace(" ", "") + i.ToString()].Value = System.Math.Round((decimal)CB.Breakdown[i - 1], 0).ToString();

                            if (BRType != "Depreciation")
                            {
                                decimal tot = 0;
                                if (this.Fields["AnnualPremium" + i.ToString()].Value.ToString() == "")
                                {
                                    tot = 0;
                                }
                                else
                                {
                                    tot = decimal.Parse(this.Fields["AnnualPremium" + i.ToString()].Value.ToString());
                                }
                                tot = tot + System.Math.Round(decimal.Parse(CB.Breakdown[i - 1].ToString()));
                                this.Fields["AnnualPremium" + i.ToString()].Value = tot.ToString();
                            }
                        }
                        break;

                    case "Lease Loan Gap":
                    case "Towing":
                    case "Assistance": 
                    case "Vehicle Rental":
                        for (int i = 1; i <= CB.Breakdown.Count; i++)
                        {
                            decimal tot = 0;
                            if (this.Fields["LeaseLoanGap" + i.ToString()].Value.ToString() == "")
                            {
                                tot = 0;
                            }
                            else
                            {
                                tot = decimal.Parse(this.Fields["LeaseLoanGap" + i.ToString()].Value.ToString());
                            }
                            tot = tot + System.Math.Round(decimal.Parse(CB.Breakdown[i - 1].ToString()));
                            this.Fields["LeaseLoanGap" + i.ToString()].Value = tot.ToString();


                            decimal tot2 = 0;
                            if (this.Fields["AnnualPremium" + i.ToString()].Value.ToString() == "")
                            {
                                tot2 = 0;
                            }
                            else
                            {
                                tot2 = decimal.Parse(this.Fields["AnnualPremium" + i.ToString()].Value.ToString());
                            }
                            tot2 = tot2 + System.Math.Round(decimal.Parse(CB.Breakdown[i - 1].ToString()));
                            this.Fields["AnnualPremium" + i.ToString()].Value = tot2.ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
