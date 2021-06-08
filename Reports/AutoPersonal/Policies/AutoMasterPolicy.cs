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
    /// Summary description for AutoMasterPolicy.
    /// </summary>
    public partial class AutoMasterPolicy : DataDynamics.ActiveReports.ActiveReport3
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

        public AutoMasterPolicy(EPolicy.TaskControl.QuoteAuto taskcontrol, string copyValue)
        {
            _policy = taskcontrol;
            _CopyValue = copyValue;
            InitializeComponent();
        }

        private void AutoMasterPolicy_DataInitialize(object sender, EventArgs e)
        {
            this.Fields.Clear();

            for (int i = 1; i <= _policy.AutoCovers.Count; i++)
            {
                this.Fields.Add("BodilyInjuryLimit" + i.ToString());
                this.Fields.Add("CSLorBD" + i.ToString());
                this.Fields.Add("PropertyDamageLimit" + i.ToString());
                this.Fields.Add("MedicalLimit" + i.ToString());
                this.Fields.Add("CompLimit" + i.ToString());
                this.Fields.Add("CollLimit" + i.ToString());
                this.Fields.Add("BodilyInjuryPrem" + i.ToString());
                this.Fields.Add("CSLPrem" + i.ToString());
                this.Fields.Add("PropertyDamagePrem" + i.ToString());
                this.Fields.Add("MedicalPrem" + i.ToString());
                this.Fields.Add("CompPrem" + i.ToString());
                this.Fields.Add("CollPrem" + i.ToString());
                this.Fields.Add("LLoanGapPrem" + i.ToString());
                this.Fields.Add("AssistancePrem" + i.ToString());
                this.Fields.Add("TowingPrem" + i.ToString());
                this.Fields.Add("SeatBeltPrem" + i.ToString());
                this.Fields.Add("AutoTotPrem" + i.ToString());
            }

            this.Fields.Add("Charge");
            this.Fields.Add("TotalPremium");
            this.Fields.Add("SetPageByTwoVehicle");
            this.Fields.Add("Refrendata");

            for (int i = 1; i <= _policy.AutoCovers.Count; i++)
            {
                this.Fields["BodilyInjuryLimit" + i.ToString()].Value = "";
                this.Fields["CSLorBD" + i.ToString()].Value = "";
                this.Fields["PropertyDamageLimit" + i.ToString()].Value = "";
                this.Fields["MedicalLimit" + i.ToString()].Value = "";
                this.Fields["CompLimit" + i.ToString()].Value = "";
                this.Fields["CollLimit" + i.ToString()].Value = "";
                this.Fields["BodilyInjuryPrem" + i.ToString()].Value = "";
                this.Fields["CSLPrem" + i.ToString()].Value = "";
                this.Fields["PropertyDamagePrem" + i.ToString()].Value = "";
                this.Fields["MedicalPrem" + i.ToString()].Value = "";
                this.Fields["CompPrem" + i.ToString()].Value = "";
                this.Fields["CollPrem" + i.ToString()].Value = "";
                this.Fields["LLoanGapPrem" + i.ToString()].Value = "";
                this.Fields["AssistancePrem" + i.ToString()].Value = "";
                this.Fields["TowingPrem" + i.ToString()].Value = "";
                this.Fields["SeatBeltPrem" + i.ToString()].Value = "";
                this.Fields["AutoTotPrem" + i.ToString()].Value = "";
                this.Fields["Charge"].Value = "";
                this.Fields["TotalPremium"].Value = "";
            }
            CountDataIndex = 1;
            index = 0;
        }

        private void AutoMasterPolicy_FetchData(object sender, FetchEventArgs eArgs)
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

                    txtACV.Value = AC.ActualValue.ToString();

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

                    GroupData();
                    TotalPremiumByVehicle(AC);

                    TxtCopyValue.Text = _CopyValue;

                    if (CountDataIndex == 1)
                    {
                        //Endosos();
                        this.Fields["Refrendata"].Value = _policy.EntryDate.ToShortDateString();
                    }

                    if (this.CountDataIndex == _policy.AutoCovers.Count)
                    {
                        this.Fields["Charge"].Value = _policy.Charge.ToString();
                        decimal totprem = _VehicleGrandTotal + _policy.Charge;   //_policy.TotalPremium + _policy.Charge;
                        this.Fields["TotalPremium"].Value = totprem.ToString();
                    }
                }
                else
                {
                    //TxtCopyValue.Text = _CopyValue;
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

        private void TotalPremiumByVehicle(EPolicy.Quotes.AutoCover AC)
        {
            _VehicleTotal = 0;
            if (AC.AutoPolicyType == "FULL COVER" || AC.AutoPolicyType == "LIABILITY")
            {

                if (AC.BodilyInjuryPremium() != 0)
                {
                    string bodilyInjuryLimit = LookupTables.GetDescription("BodilyInjuryLimit", AC.BodilyInjuryLimit.ToString()).Trim();
                    int BILength = bodilyInjuryLimit.IndexOf("/", 0);

                    int bodilyInjury = Int32.Parse(LookupTables.GetDescription("BodilyInjuryLimit", AC.BodilyInjuryLimit.ToString()).Substring(0, BILength)) * 1000;
                    this.Fields["BodilyInjuryLimit" + CountDataIndex.ToString()].Value = bodilyInjury.ToString();
                    this.Fields["BodilyInjuryPrem" + CountDataIndex.ToString()].Value = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.BodilyInjury, AC);//AC.BodilyInjuryPremium().ToString();
                }

                int CSLorBI = 0;
                if (AC.CombinedSinglePremium() != 0)
                {
                    string combinedSingleLimit = LookupTables.GetDescription("CombinedSingleLimit", AC.CombinedSingleLimit.ToString()).Trim();
                    int CLLength = combinedSingleLimit.IndexOf("/", 0);
                    CSLorBI = Int32.Parse(LookupTables.GetDescription("CombinedSingleLimit", AC.CombinedSingleLimit.ToString()).Substring(0, CLLength)) * 1000;
                    this.Fields["CSLPrem" + CountDataIndex.ToString()].Value = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.CombinedSingle, AC);//AC.CombinedSinglePremium().ToString();
                }
                else
                {
                    string bodilyInjuryLimit = LookupTables.GetDescription("BodilyInjuryLimit", AC.BodilyInjuryLimit.ToString()).Trim();
                    int BILength = bodilyInjuryLimit.IndexOf("/", 0);
                    bodilyInjuryLimit = LookupTables.GetDescription("BodilyInjuryLimit", AC.BodilyInjuryLimit.ToString()).Substring(BILength + 1);
                    CSLorBI = Int32.Parse(bodilyInjuryLimit) * 1000;
                }
                this.Fields["CSLorBD" + CountDataIndex.ToString()].Value = CSLorBI.ToString();

                if (AC.CombinedSinglePremium() == 0)
                {
                    string propertyDamageLimit = LookupTables.GetDescription("PropertyDamageLimit", AC.PropertyDamageLimit.ToString()).Trim();
                    int PDLength = propertyDamageLimit.Length;  //.IndexOf("/",0);

                    int propertyDamage = Int32.Parse(LookupTables.GetDescription("PropertyDamageLimit", AC.PropertyDamageLimit.ToString()).Substring(0, PDLength)) * 1000;
                    this.Fields["PropertyDamageLimit" + CountDataIndex.ToString()].Value = propertyDamage.ToString();
                    this.Fields["PropertyDamagePrem" + CountDataIndex.ToString()].Value = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.PropertyDamage, AC);//AC.PropertyDamagePremium().ToString();
                }
            }

            //if (_policy.policyClass == "FullCoverPolicy" || _policy.policyClass == "DoubleInterestPolicy")

            if (AC.AutoPolicyType == "FULL COVER" || AC.AutoPolicyType == "DOUBLE INTEREST")
            {
                if (AC.CollisionDeductible != 0)
                {
                    this.Fields["CollLimit" + CountDataIndex.ToString()].Value = LookupTables.GetDescription("CollisionDeductible", AC.CollisionDeductible.ToString()).Trim();
                    this.Fields["CollPrem" + CountDataIndex.ToString()].Value = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.Collision, AC);//AC.CollisionPremium().ToString();
                }

                if (AC.ComprehensiveDeductible != 0)
                {
                    this.Fields["CompLimit" + CountDataIndex.ToString()].Value = LookupTables.GetDescription("ComprehensiveDeductible", AC.ComprehensiveDeductible.ToString()).Trim();
                    this.Fields["CompPrem" + CountDataIndex.ToString()].Value = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.Comprehensive, AC);//AC.ComprehensivePremium().ToString();
                }
            }

            if (AC.MedicalPremium() != 0)
            {
                string medicalLimit = LookupTables.GetDescription("MedicalLimit", AC.MedicalLimit.ToString()).Trim();
                int MDLength = medicalLimit.Length;

                int MedicalLimit = Int32.Parse(LookupTables.GetDescription("MedicalLimit", AC.MedicalLimit.ToString()));//.Substring(0,MDLength))*1000;
                //				int MedicalLimit = AC.MedicalLimit*1000;
                //this.Fields["MedicalLimit"+CountDataIndex.ToString()].Value = MedicalLimit.ToString();
                this.Fields["MedicalLimit1"].Value = MedicalLimit.ToString();

                this.Fields["MedicalPrem" + CountDataIndex.ToString()].Value = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.Medical, AC);//AC.MedicalPremium().ToString();

                //				int MedicalLimit = AC.MedicalLimit*1000;
                //				this.Fields["MedicalLimit"+CountDataIndex.ToString()].Value = MedicalLimit.ToString();
                //				this.Fields["MedicalPrem"+CountDataIndex.ToString()].Value = GetBreakDownByTypeAndAnniversary(Quotes.Enumerators.Premiums.Medical,AC);//AC.MedicalPremium().ToString();
            }
            else
            {
                this.Fields["MedicalLimit1"].Value = "";
            }

            if (AC.LeaseLoanGapPremium() != 0)
            {
                this.Fields["LLoanGapPrem" + CountDataIndex.ToString()].Value = System.Math.Round(decimal.Parse(GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.LeaseLoanGap, AC)), 0);//System.Math.Round(AC.LeaseLoanGapPremium(),0);
            }
            else
            {
                this.Fields["LLoanGapPrem" + CountDataIndex.ToString()].Value = "";
            }

            if (AC.AssistancePremium != 0)
            {
                this.Fields["AssistancePrem" + CountDataIndex.ToString()].Value = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.Assistance, AC);//AC.AssistancePremium.ToString();
            }
            else
            {
                this.Fields["AssistancePrem" + CountDataIndex.ToString()].Value = "";
            }

            if (AC.VehicleRental != 0)
            {
                label44.Visible = true;
                label44.Text = LookupTables.GetID("VehicleRental", AC.VehicleRental.ToString("###,###")).Trim();
                this.Fields["SeatBeltPrem" + CountDataIndex.ToString()].Value = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.VehicleRental, AC);
            }
            else
            {
                label44.Visible = false;
                label44.Text = "";
                this.Fields["SeatBeltPrem" + CountDataIndex.ToString()].Value = "";
            }

            if (AC.TowingPremium != 0)
            {
                this.Fields["TowingPrem" + CountDataIndex.ToString()].Value = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.Towing, AC);//AC.TowingPremium.ToString();
            }
            else
            {
                this.Fields["TowingPrem" + CountDataIndex.ToString()].Value = "";
            }

            //if (AC.SeatBeltPremium() != 0)
            //{
            //    this.Fields["SeatBeltPrem" + CountDataIndex.ToString()].Value = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.SeatBelt, AC);//AC.SeatBeltPremium().ToString();
            //}

            this.Fields["AutoTotPrem" + CountDataIndex.ToString()].Value = _VehicleTotal.ToString(); //AC.TotalAmount.ToString();
        }

        private string GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums Type, AutoCover ac)
        {
            EPolicy.Quotes.CoverBreakdown CB = new EPolicy.Quotes.CoverBreakdown();
            CB.Type = (int)Type;
            EPolicy.Quotes.CoverBreakdown CB2 = (EPolicy.Quotes.CoverBreakdown)ac.Breakdown[ac.Breakdown.IndexOf(CB)];

            if ((int)Type == 5) //Para Lease Loan Gap
            {
                _VehicleTotal += System.Math.Round((decimal)CB2.Breakdown[0]);
                _VehicleGrandTotal += System.Math.Round((decimal)CB2.Breakdown[0]);
            }
            else
            {
                System.Type typeByBC2 = CB2.Breakdown[0].GetType();
                object obj = CB2.Breakdown.GetByIndex(0);
                if (obj is int)
                {
                    _VehicleTotal += (decimal)((int)CB2.Breakdown[0]);
                    _VehicleGrandTotal += (decimal)((int)CB2.Breakdown[0]);
                }
                else
                {
                    _VehicleTotal += (decimal)CB2.Breakdown[0];
                    _VehicleGrandTotal += (decimal)CB2.Breakdown[0];
                }
            }
            return CB2.Breakdown[0].ToString();
        }

        private void VisibleTextBox()
        {
            for (int i = 1; i <= _policy.AutoCovers.Count; i++)
            {
                groupFooter1.Controls["TxtBodilyInjuryLimit" + i.ToString()].Visible = true;
                groupFooter1.Controls["TxtCSLorBD" + i.ToString()].Visible = true;
                groupFooter1.Controls["TxtPropertyDamageLimit" + i.ToString()].Visible = true;
                groupFooter1.Controls["TxtMedicalLimit" + i.ToString()].Visible = true;
                groupFooter1.Controls["TxtColl" + i.ToString()].Visible = true;
                groupFooter1.Controls["TxtComp" + i.ToString()].Visible = true;
                groupFooter1.Controls["TxtBodilyInjuryPrem" + i.ToString()].Visible = true;
                groupFooter1.Controls["TxtCSLPrem" + i.ToString()].Visible = true;
                groupFooter1.Controls["TxtPropertyDamagePrem" + i.ToString()].Visible = true;
                groupFooter1.Controls["TxtMedicalPrem" + i.ToString()].Visible = true;
                groupFooter1.Controls["TxtCollPrem" + i.ToString()].Visible = true;
                groupFooter1.Controls["TxtCompPrem" + i.ToString()].Visible = true;
                groupFooter1.Controls["TxtLLoanGapPrem" + i.ToString()].Visible = true;
                groupFooter1.Controls["TxtAssistancePrem" + i.ToString()].Visible = true;
                groupFooter1.Controls["TxtTowingPrem" + i.ToString()].Visible = true;
                groupFooter1.Controls["TxtSeatBeltPrem" + i.ToString()].Visible = true;
                groupFooter1.Controls["TxtAutoTotPrem" + i.ToString()].Visible = true;
            }
        }

        private void InvisibleTextBox(int i)
        {
            groupFooter1.Controls["TxtBodilyInjuryLimit" + i.ToString()].Visible = false;
            groupFooter1.Controls["TxtCSLorBD" + i.ToString()].Visible = false;
            groupFooter1.Controls["TxtPropertyDamageLimit" + i.ToString()].Visible = false;
            groupFooter1.Controls["TxtMedicalLimit" + i.ToString()].Visible = false;
            groupFooter1.Controls["TxtColl" + i.ToString()].Visible = false;
            groupFooter1.Controls["TxtComp" + i.ToString()].Visible = false;
            groupFooter1.Controls["TxtBodilyInjuryPrem" + i.ToString()].Visible = false;
            groupFooter1.Controls["TxtCSLPrem" + i.ToString()].Visible = false;
            groupFooter1.Controls["TxtPropertyDamagePrem" + i.ToString()].Visible = false;
            groupFooter1.Controls["TxtMedicalPrem" + i.ToString()].Visible = false;
            groupFooter1.Controls["TxtCollPrem" + i.ToString()].Visible = false;
            groupFooter1.Controls["TxtCompPrem" + i.ToString()].Visible = false;
            groupFooter1.Controls["TxtLLoanGapPrem" + i.ToString()].Visible = false;
            groupFooter1.Controls["TxtAssistancePrem" + i.ToString()].Visible = false;
            groupFooter1.Controls["TxtTowingPrem" + i.ToString()].Visible = false;
            groupFooter1.Controls["TxtSeatBeltPrem" + i.ToString()].Visible = false;
            groupFooter1.Controls["TxtAutoTotPrem" + i.ToString()].Visible = false;
        }

        private void GroupData()
        {
            this.Fields["SetPageByTwoVehicle"].Value =
                (CountDataIndex + CountDataIndex % 2) / 2;
        }

        private void groupFooter1_Format(object sender, EventArgs e)
        {
            if (!Visible)
            {
                VisibleTextBox();
                Visible = true;
            }

            int startIndex = 2 * GroupCount - 3;

            if (GroupCount != 1)
            {
                InvisibleTextBox(startIndex);
                InvisibleTextBox(startIndex + 1);
            }

            LblAuto1.Text = "AUTO " + (startIndex + 2).ToString();
            LblAuto2.Text = "AUTO " + (startIndex + 3).ToString();

            //Para poner invisible los labels
            if ((_policy.AutoCovers.Count == 1 && GroupCount == 1) || (_policy.AutoCovers.Count == 3 && GroupCount == 2) || (_policy.AutoCovers.Count == 5 && GroupCount == 2))
            {
                LblAuto2.Visible = false;
                label41.Visible = false;
                label42.Visible = false;
                label43.Visible = false;
                label50.Visible = false;
                label45.Visible = false;
                label46.Visible = false;
                label47.Visible = false;
                label48.Visible = false;
            }

            label25.Visible = false;
            label30.Visible = false;
            label31.Visible = false;
            label44.Visible = false;
            label62.Visible = false;
            label68.Visible = false;

            int vehcount = 0;
            int autonumber = 0;

            if (_policy.AutoCovers.Count == 1 && GroupCount == 1)
            {
                vehcount = 0;
                autonumber = 0;
            }
            if (_policy.AutoCovers.Count >= 2 && GroupCount == 1)
            {
                vehcount = 1;
                autonumber = 0;
            }
            if (_policy.AutoCovers.Count == 3 && GroupCount == 2)
            {
                vehcount = 0;
                autonumber = 2;
            }
            if (_policy.AutoCovers.Count >= 4 && GroupCount == 2)
            {
                vehcount = 1;
                autonumber = 2;
            }
            if (_policy.AutoCovers.Count == 5 && GroupCount == 3)
            {
                vehcount = 0;
                autonumber = 4;
            }
            if (_policy.AutoCovers.Count >= 6 && GroupCount == 3)
            {
                vehcount = 1;
                autonumber = 4;
            }

            for (int i = 0; i <= vehcount; i++)
            {
                EPolicy.Quotes.AutoCover AC = null;
                AC = (EPolicy.Quotes.AutoCover)_policy.AutoCovers[autonumber];

                if (AC.MedicalPremium() != 0)
                {
                    label25.Visible = true;
                }
                else
                {
                    //label25.Visible = false;
                }

                if (AC.LeaseLoanGapPremium() != 0)
                {
                    label31.Visible = true;
                }
                else
                {
                    //label31.Visible = false;
                }

                if (AC.AssistancePremium != 0)
                {
                    label62.Visible = true;
                }
                else
                {
                    //label62.Visible = false;
                }

                if (AC.VehicleRental != 0)
                {
                    label44.Visible = true;
                    label68.Visible = true;
                }
                else
                {
                    //label44.Visible = false;
                    //label68.Visible = false;
                }

                if (AC.TowingPremium != 0)
                {
                    label30.Visible = true;
                }
                else
                {
                     //label30.Visible = false;
                }

                autonumber = autonumber + 1;
            }

            GroupCount++;
        }

        private void RightColumnLocation(int a)
        {
            PointF loc = new PointF();

            loc.X = 4.9F;
            loc.Y = 1.13F;
            groupFooter1.Controls["TxtBodilyInjuryLimit" + a.ToString()].Location = loc;

            loc.X = 4.9F;
            loc.Y = 1.28F;
            groupFooter1.Controls["TxtCSLorBD" + a.ToString()].Location = loc;

            loc.X = 4.9F;
            loc.Y = 1.52F;
            groupFooter1.Controls["TxtPropertyDamageLimit" + a.ToString()].Location = loc;

            loc.X = 4.9F;
            loc.Y = 1.752F;
            groupFooter1.Controls["TxtMedicalLimit" + a.ToString()].Location = loc;

            loc.X = 6.08F;
            loc.Y = 2.26F;
            groupFooter1.Controls["TxtColl" + a.ToString()].Location = loc;

            loc.X = 6.08F;
            loc.Y = 2.56F;
            groupFooter1.Controls["TxtComp" + a.ToString()].Location = loc;

            loc.X = 7.36F;
            loc.Y = 1.13F;
            groupFooter1.Controls["TxtBodilyInjuryPrem" + a.ToString()].Location = loc;

            loc.X = 7.33F;
            loc.Y = 1.25F;
            groupFooter1.Controls["TxtCSLPrem" + a.ToString()].Location = loc;

            loc.X = 7.33F;
            loc.Y = 1.50F;
            groupFooter1.Controls["TxtPropertyDamagePrem" + a.ToString()].Location = loc;

            loc.X = 7.33F;
            loc.Y = 1.75F;
            groupFooter1.Controls["TxtMedicalPrem" + a.ToString()].Location = loc;

            loc.X = 7.33F;
            loc.Y = 2.26F;
            groupFooter1.Controls["TxtCollPrem" + a.ToString()].Location = loc;

            loc.X = 7.33F;
            loc.Y = 2.565F;
            groupFooter1.Controls["TxtCompPrem" + a.ToString()].Location = loc;

            loc.X = 7.33F;
            loc.Y = 3.19F;
            groupFooter1.Controls["TxtLLoanGapPrem" + a.ToString()].Location = loc;

            loc.X = 7.33F;
            loc.Y = 2.740F; //loc.Y = 2.700F; //loc.Y = 2.700F;
            groupFooter1.Controls["TxtAssistancePrem" + a.ToString()].Location = loc;

            loc.X = 7.33F;
            loc.Y = 2.88F;
            groupFooter1.Controls["TxtTowingPrem" + a.ToString()].Location = loc;

            loc.X = 7.33F;
            loc.Y = 3.025F; //loc.Y = 3.125F;
            groupFooter1.Controls["TxtSeatBeltPrem" + a.ToString()].Location = loc;

            loc.X = 7.33F;
            loc.Y = 3.38F;
            groupFooter1.Controls["TxtAutoTotPrem" + a.ToString()].Location = loc;
        }

        private void LeftColumnLocation(int a)
        {
            PointF loc = new PointF();

            loc.X = 2.059F;
            loc.Y = 1.126F;
            groupFooter1.Controls["TxtBodilyInjuryLimit" + a.ToString()].Location = loc;

            loc.X = 2.059F;
            loc.Y = 1.28F;
            groupFooter1.Controls["TxtCSLorBD" + a.ToString()].Location = loc;

            loc.X = 2.059F;
            loc.Y = 1.52F;
            groupFooter1.Controls["TxtPropertyDamageLimit" + a.ToString()].Location = loc;

            loc.X = 2.059F;
            loc.Y = 1.752F;
            groupFooter1.Controls["TxtMedicalLimit" + a.ToString()].Location = loc;

            loc.X = 2.933F;
            loc.Y = 2.26F;
            groupFooter1.Controls["TxtColl" + a.ToString()].Location = loc;

            loc.X = 2.933F;
            loc.Y = 2.565F;
            groupFooter1.Controls["TxtComp" + a.ToString()].Location = loc;

            loc.X = 4.35F;
            loc.Y = 1.13F;
            groupFooter1.Controls["TxtBodilyInjuryPrem" + a.ToString()].Location = loc;

            loc.X = 4.35F;
            loc.Y = 1.25F;
            groupFooter1.Controls["TxtCSLPrem" + a.ToString()].Location = loc;

            loc.X = 4.35F;
            loc.Y = 1.50F;
            groupFooter1.Controls["TxtPropertyDamagePrem" + a.ToString()].Location = loc;

            loc.X = 4.38F;
            loc.Y = 1.75F;
            groupFooter1.Controls["TxtMedicalPrem" + a.ToString()].Location = loc;

            loc.X = 4.35F;
            loc.Y = 2.25F;
            groupFooter1.Controls["TxtCollPrem" + a.ToString()].Location = loc;

            loc.X = 4.35F;
            loc.Y = 2.56F;
            groupFooter1.Controls["TxtCompPrem" + a.ToString()].Location = loc;

            loc.X = 4.35F;
            loc.Y = 3.19F;
            groupFooter1.Controls["TxtLLoanGapPrem" + a.ToString()].Location = loc;

            loc.X = 4.35F;
            loc.Y = 2.740F; //2.675F;
            groupFooter1.Controls["TxtAssistancePrem" + a.ToString()].Location = loc;

            loc.X = 4.35F;
            loc.Y = 2.88F;
            groupFooter1.Controls["TxtTowingPrem" + a.ToString()].Location = loc;

            loc.X = 4.35F;
            loc.Y = 3.025F;
            groupFooter1.Controls["TxtSeatBeltPrem" + a.ToString()].Location = loc;

            loc.X = 4.35F;
            loc.Y = 3.38F;
            groupFooter1.Controls["TxtAutoTotPrem" + a.ToString()].Location = loc;
        }

        private void AutoMasterPolicy_ReportStart(object sender, EventArgs e)
        {
            txtPolicyNo.Text = _policy.Policy.PolicyNo.ToString().Trim();
            txtCertificate.Text = _policy.Policy.PolicyType.ToString().Trim()+" - "+ _policy.Policy.Certificate.ToString().Trim();
            txtEffectiveDate.Text = _policy.EffectiveDate.ToString();
            txtExpirationDate.Text = _policy.ExpirationDate.ToString();
            txtEmision.Text = _policy.EffectiveDate.ToString();
            
            txtCustomerName.Text = _policy.Customer.FirstName.Trim() + ' ' + _policy.Customer.Initial.Trim() + ' ' + _policy.Customer.LastName1.Trim() + ' ' + _policy.Customer.LastName2.Trim();
            txtCustomerAddr1.Text = _policy.Customer.Address1.Trim() + ' ' + _policy.Customer.Address2.Trim();
            txtCustomerAddr2.Text = _policy.Customer.City.Trim() + ' ' + _policy.Customer.State.Trim() + ' ' + _policy.Customer.ZipCode.Trim();
            txtCustomerAddr3.Text = _policy.Customer.AddressPhysical1.Trim() + ' ' + _policy.Customer.AddressPhysical2.Trim();
            txtCustomerAddr4.Text = _policy.Customer.CityPhysical.Trim() + ' ' + _policy.Customer.StatePhysical.Trim() + ' ' + _policy.Customer.ZipPhysical.Trim();

            EPolicy.LookupTables.Bank bank = new Bank();
            bank = bank.GetBank(_policy.Bank);
            txtBank.Text = bank.BankID.Trim() + " -  " + bank.BankDesc.ToString().Trim();

            EPolicy.LookupTables.Agency agency = new EPolicy.LookupTables.Agency();
            agency = agency.GetAgency(_policy.Agency);
            txtAgencyDesc.Text = agency.AgencyDesc.ToString().Trim();
            txtAgencyAddr1.Text = agency.agy_addr1.Trim() + " -  " + agency.agy_addr2.ToString().Trim();
            txtAgencyAddr2.Text = agency.agy_city.Trim() + " -  " + agency.agy_st.ToString().Trim() + " -  " + agency.agy_zip.ToString().Trim();

            txtAutoEnd.Text = "IL 01 36 05 04, CA 23 57 12 02, CA 00 01 01 87, IL 00 17 11 98, IL  00 21 04 98,CA 01 14 01 98, CA 23 01 01 87, IL 09 01 01 98, IL 00 24 01 99, CA 99 29 02 91, CA 23 05 01 87, CA 00 29 12 88, CA 23 84 01 06, CA 99 28 01 87, OPT 0002 (09/05), OPT 2003 (09/05)";
            EPolicy.LookupTables.Agent agent = new Agent();
            agent = agent.GetAgent(_policy.Agent);
            txtAgent.Text = agent.CarsID.Trim() + " -  " + agent.AgentDesc.ToString().Trim();

            txtLoanNo.Text = _policy.Policy.LoanNo.Trim();
            txtPremium.Text = _policy.TotalPremium.ToString("$ #,##0.00").Trim();
            txtCharge.Text = _policy.Charge.ToString("$ #,##0.00").Trim();
            decimal totprem2 = _policy.TotalPremium + _policy.Charge;
            txtTotalPremium.Text = totprem2.ToString("$ #,##0.00");

            bool Left = true;
            Font font = new Font("Arial", 8);
            SizeF size = new SizeF();

            for (int i = 1; i <= _policy.AutoCovers.Count; i++)
            {
                TextBox Txt1 = new TextBox();
                TextBox Txt2 = new TextBox();
                TextBox Txt3 = new TextBox();
                TextBox Txt4 = new TextBox();
                TextBox Txt5 = new TextBox();
                TextBox Txt6 = new TextBox();
                TextBox Txt7 = new TextBox();
                TextBox Txt8 = new TextBox();
                TextBox Txt9 = new TextBox();
                TextBox Txt10 = new TextBox();
                TextBox Txt11 = new TextBox();
                TextBox Txt12 = new TextBox();
                TextBox Txt13 = new TextBox();
                TextBox Txt14 = new TextBox();
                TextBox Txt15 = new TextBox();
                TextBox Txt16 = new TextBox();
                TextBox Txt17 = new TextBox();

                Txt1.Text = "TxtBodilyInjuryLimit" + i.ToString();
                Txt1.Name = "TxtBodilyInjuryLimit" + i.ToString();
                Txt1.Alignment = TextAlignment.Right;
                Txt1.Font = font;
                Txt1.OutputFormat = "$#,##0.00";
                groupFooter1.Controls.Add(Txt1);
                groupFooter1.Controls["TxtBodilyInjuryLimit" + i.ToString()].DataField = "BodilyInjuryLimit" + i.ToString();
                groupFooter1.Controls["TxtBodilyInjuryLimit" + i.ToString()].Visible = false;
                size.Height = .02F;
                size.Width = 1F;
                groupFooter1.Controls["TxtBodilyInjuryLimit" + i.ToString()].Size = size;

                Txt2.Text = "TxtCSLorBD" + i.ToString();
                Txt2.Name = "TxtCSLorBD" + i.ToString();
                Txt2.Alignment = TextAlignment.Right;
                Txt2.Font = font;
                Txt2.OutputFormat = "$#,##0.00";
                groupFooter1.Controls.Add(Txt2);
                groupFooter1.Controls["TxtCSLorBD" + i.ToString()].DataField = "CSLorBD" + i.ToString();
                groupFooter1.Controls["TxtCSLorBD" + i.ToString()].Visible = false;
                size.Height = .02F;
                size.Width = 1F;
                groupFooter1.Controls["TxtCSLorBD" + i.ToString()].Size = size;

                Txt3.Text = "TxtPropertyDamageLimit" + i.ToString();
                Txt3.Name = "TxtPropertyDamageLimit" + i.ToString();
                Txt3.Alignment = TextAlignment.Right;
                Txt3.Font = font;
                Txt3.OutputFormat = "$#,##0.00";
                groupFooter1.Controls.Add(Txt3);
                groupFooter1.Controls["TxtPropertyDamageLimit" + i.ToString()].DataField = "PropertyDamageLimit" + i.ToString();
                groupFooter1.Controls["TxtPropertyDamageLimit" + i.ToString()].Visible = false;
                size.Height = .02F;
                size.Width = 1F;
                groupFooter1.Controls["TxtPropertyDamageLimit" + i.ToString()].Size = size;

                Txt4.Text = "TxtMedicalLimit" + i.ToString();
                Txt4.Name = "TxtMedicalLimit" + i.ToString();
                Txt4.Alignment = TextAlignment.Right;
                Txt4.Font = font;
                Txt4.OutputFormat = "$#,##0.00";
                groupFooter1.Controls.Add(Txt4);
                groupFooter1.Controls["TxtMedicalLimit" + i.ToString()].DataField = "MedicalLimit" + i.ToString();
                groupFooter1.Controls["TxtMedicalLimit" + i.ToString()].Visible = false;
                size.Height = .02F;
                size.Width = 1F;
                groupFooter1.Controls["TxtMedicalLimit" + i.ToString()].Size = size;

                Txt5.Text = "TxtColl" + i.ToString();
                Txt5.Name = "TxtColl" + i.ToString();
                Txt5.Alignment = TextAlignment.Right;
                Txt5.Font = font;
                Txt5.OutputFormat = "$#,##0.00";
                groupFooter1.Controls.Add(Txt5);
                groupFooter1.Controls["TxtColl" + i.ToString()].DataField = "CollLimit" + i.ToString();
                groupFooter1.Controls["TxtColl" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .455F;
                groupFooter1.Controls["TxtColl" + i.ToString()].Size = size;

                Txt6.Text = "TxtComp" + i.ToString();
                Txt6.Name = "TxtComp" + i.ToString();
                Txt6.Alignment = TextAlignment.Right;
                Txt6.Font = font;
                Txt6.OutputFormat = "$#,##0.00";
                groupFooter1.Controls.Add(Txt6);
                groupFooter1.Controls["TxtComp" + i.ToString()].DataField = "CompLimit" + i.ToString();
                groupFooter1.Controls["TxtComp" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .455F;
                groupFooter1.Controls["TxtComp" + i.ToString()].Size = size;

                Txt7.Text = "TxtBodilyInjuryPrem" + i.ToString();
                Txt7.Name = "TxtBodilyInjuryPrem" + i.ToString();
                Txt7.Alignment = TextAlignment.Right;
                Txt7.Font = font;
                Txt7.OutputFormat = "$#,##0.00";
                groupFooter1.Controls.Add(Txt7);
                groupFooter1.Controls["TxtBodilyInjuryPrem" + i.ToString()].DataField = "BodilyInjuryPrem" + i.ToString();
                groupFooter1.Controls["TxtBodilyInjuryPrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                groupFooter1.Controls["TxtBodilyInjuryPrem" + i.ToString()].Size = size;

                Txt8.Text = "TxtCSLPrem" + i.ToString();
                Txt8.Name = "TxtCSLPrem" + i.ToString();
                Txt8.Alignment = TextAlignment.Right;
                Txt8.OutputFormat = "$#,##0.00";
                Txt8.Font = font;
                groupFooter1.Controls.Add(Txt8);
                groupFooter1.Controls["TxtCSLPrem" + i.ToString()].DataField = "CSLPrem" + i.ToString();
                groupFooter1.Controls["TxtCSLPrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                groupFooter1.Controls["TxtCSLPrem" + i.ToString()].Size = size;

                Txt9.Text = "TxtPropertyDamagePrem" + i.ToString();
                Txt9.Name = "TxtPropertyDamagePrem" + i.ToString();
                Txt9.Alignment = TextAlignment.Right;
                Txt9.Font = font;
                Txt9.OutputFormat = "$#,##0.00";
                groupFooter1.Controls.Add(Txt9);
                groupFooter1.Controls["TxtPropertyDamagePrem" + i.ToString()].DataField = "PropertyDamagePrem" + i.ToString();
                groupFooter1.Controls["TxtPropertyDamagePrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                groupFooter1.Controls["TxtPropertyDamagePrem" + i.ToString()].Size = size;

                Txt10.Text = "TxtMedicalPrem" + i.ToString();
                Txt10.Name = "TxtMedicalPrem" + i.ToString();
                Txt10.Alignment = TextAlignment.Right;
                Txt10.Font = font;
                Txt10.OutputFormat = "$#,##0.00";
                groupFooter1.Controls.Add(Txt10);
                groupFooter1.Controls["TxtMedicalPrem" + i.ToString()].DataField = "MedicalPrem" + i.ToString();
                groupFooter1.Controls["TxtMedicalPrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                groupFooter1.Controls["TxtMedicalPrem" + i.ToString()].Size = size;

                Txt11.Text = "TxtCollPrem" + i.ToString();
                Txt11.Name = "TxtCollPrem" + i.ToString();
                Txt11.Alignment = TextAlignment.Right;
                Txt11.Font = font;
                Txt11.OutputFormat = "$#,##0.00";
                groupFooter1.Controls.Add(Txt11);
                groupFooter1.Controls["TxtCollPrem" + i.ToString()].DataField = "CollPrem" + i.ToString();
                groupFooter1.Controls["TxtCollPrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                groupFooter1.Controls["TxtCollPrem" + i.ToString()].Size = size;

                Txt12.Text = "TxtCompPrem" + i.ToString();
                Txt12.Name = "TxtCompPrem" + i.ToString();
                Txt12.Alignment = TextAlignment.Right;
                Txt12.Font = font;
                Txt12.OutputFormat = "$#,##0.00";
                groupFooter1.Controls.Add(Txt12);
                groupFooter1.Controls["TxtCompPrem" + i.ToString()].DataField = "CompPrem" + i.ToString();
                groupFooter1.Controls["TxtCompPrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                groupFooter1.Controls["TxtCompPrem" + i.ToString()].Size = size;

                Txt13.Text = "TxtLLoanGapPrem" + i.ToString();
                Txt13.Name = "TxtLLoanGapPrem" + i.ToString();
                Txt13.Alignment = TextAlignment.Right;
                Txt13.Font = font;
                Txt13.OutputFormat = "$#,##0.00";
                groupFooter1.Controls.Add(Txt13);
                groupFooter1.Controls["TxtLLoanGapPrem" + i.ToString()].DataField = "LLoanGapPrem" + i.ToString();
                groupFooter1.Controls["TxtLLoanGapPrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                groupFooter1.Controls["TxtLLoanGapPrem" + i.ToString()].Size = size;

                Txt14.Text = "TxtAssistancePrem" + i.ToString();
                Txt14.Name = "TxtAssistancePrem" + i.ToString();
                Txt14.Alignment = TextAlignment.Right;
                Txt14.Font = font;
                Txt14.OutputFormat = "$#,##0.00";
                groupFooter1.Controls.Add(Txt14);
                groupFooter1.Controls["TxtAssistancePrem" + i.ToString()].DataField = "AssistancePrem" + i.ToString();
                groupFooter1.Controls["TxtAssistancePrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                groupFooter1.Controls["TxtAssistancePrem" + i.ToString()].Size = size;

                Txt15.Text = "TxtTowingPrem" + i.ToString();
                Txt15.Name = "TxtTowingPrem" + i.ToString();
                Txt15.Alignment = TextAlignment.Right;
                Txt15.Font = font;
                Txt15.OutputFormat = "$#,##0.00";
                groupFooter1.Controls.Add(Txt15);
                groupFooter1.Controls["TxtTowingPrem" + i.ToString()].DataField = "TowingPrem" + i.ToString();
                groupFooter1.Controls["TxtTowingPrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                groupFooter1.Controls["TxtTowingPrem" + i.ToString()].Size = size;

                Txt16.Text = "TxtSeatBeltPrem" + i.ToString();
                Txt16.Name = "TxtSeatBeltPrem" + i.ToString();
                Txt16.Alignment = TextAlignment.Right;
                Txt16.Font = font;
                Txt16.OutputFormat = "$#,##0.00";
                groupFooter1.Controls.Add(Txt16);
                groupFooter1.Controls["TxtSeatBeltPrem" + i.ToString()].DataField = "SeatBeltPrem" + i.ToString();
                groupFooter1.Controls["TxtSeatBeltPrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                groupFooter1.Controls["TxtSeatBeltPrem" + i.ToString()].Size = size;

                Txt17.Text = "TxtAutoTotPrem" + i.ToString();
                Txt17.Name = "TxtAutoTotPrem" + i.ToString();
                Txt17.Alignment = TextAlignment.Right;
                Txt17.Font = font;
                Txt17.OutputFormat = "$#,##0.00";
                groupFooter1.Controls.Add(Txt17);
                groupFooter1.Controls["TxtAutoTotPrem" + i.ToString()].DataField = "AutoTotPrem" + i.ToString();
                groupFooter1.Controls["TxtAutoTotPrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                groupFooter1.Controls["TxtAutoTotPrem" + i.ToString()].Size = size;

                if (Left)
                {
                    LeftColumnLocation(i);
                    Left = false;
                }
                else
                {
                    RightColumnLocation(i);
                    Left = true;
                }
            }
        }


    }
}
