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
    /// Summary description for PersoanalPackageSeccionIII.
    /// </summary>
    public partial class PersonalPackageSeccionIII : DataDynamics.ActiveReports.ActiveReport3
    {
        private int CountDataIndex;
        private int index;
        private string _CopyValue;
        //private         PolManager.QuoteAuto _policy ;
        private EPolicy.TaskControl.OptimaPersonalPackage _policy;
        private int GroupCount = 1;
        bool Visible = false;
        private PrintPolicy end = new PrintPolicy();
        private decimal _VehicleTotal = 0;
        private decimal _VehicleGrandTotal = 0;

        public PersonalPackageSeccionIII(EPolicy.TaskControl.OptimaPersonalPackage taskcontrol, string copyValue)
        {
            _policy = taskcontrol;
            _CopyValue = copyValue;
            InitializeComponent();
        }

        private void PersonalPackageSeccionIII_DataInitialize(object sender, EventArgs e)
        {
            this.Fields.Clear();

            for (int i = 1; i <= _policy.QuoteAuto.AutoCovers.Count; i++)
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

            for (int i = 1; i <= _policy.QuoteAuto.AutoCovers.Count; i++)
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

        private void PersonalPackageSeccionIII_FetchData(object sender, FetchEventArgs eArgs)
        {
            try
            {
                if (this.CountDataIndex <= _policy.QuoteAuto.AutoCovers.Count)
                {
                    eArgs.EOF = false;

                    EPolicy.Quotes.AutoCover AC = null;
                    AC = (EPolicy.Quotes.AutoCover)_policy.QuoteAuto.AutoCovers[index];

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

                    if (AC.NewUse == 2) //New
                    {
                        if (AC.Cost.ToString() == "")
                            TxtVehicleCost.Value = "";
                        else
                            TxtVehicleCost.Value = AC.Cost.ToString();
                    }
                    else
                    {
                        if (AC.ActualValue.ToString() == "")
                            TxtVehicleCost.Value = "";
                        else
                            TxtVehicleCost.Value = AC.ActualValue.ToString();
                    }

                    if (AC.PurchaseDate == "")
                        TxtPurchaserDate.Text = "";
                    else
                        TxtPurchaserDate.Text = DateTime.Parse(AC.PurchaseDate).Month.ToString() + " / " + DateTime.Parse(AC.PurchaseDate).Year.ToString();

                    if (AC.NewUse == 1)
                        txtNewUse.Value = "USADO";
                    else
                        txtNewUse.Value = "NUEVO";

                    GroupData();
                    TotalPremiumByVehicle(AC);

                    //TxtCopyValue.Text = _CopyValue;

                    if (CountDataIndex == 1)
                    {
                        //Endosos();
                        this.Fields["Refrendata"].Value = _policy.QuoteAuto.EntryDate.ToShortDateString();
                    }

                    if (this.CountDataIndex == _policy.QuoteAuto.AutoCovers.Count)
                    {
                        this.Fields["Charge"].Value = _policy.QuoteAuto.Charge.ToString();
                        decimal totprem = _VehicleGrandTotal + _policy.QuoteAuto.Charge;   //_policy.TotalPremium + _policy.Charge;
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
            if (AC.AutoPolicyType == "") //AC.AutoPolicyType == "FULL COVER" || AC.AutoPolicyType == "LIABILITY")
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

            if (AC.AutoPolicyType == "") //AC.AutoPolicyType == "FULL COVER" || AC.AutoPolicyType == "DOUBLE INTEREST")
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
                this.Fields["MedicalLimit"+CountDataIndex.ToString()].Value = MedicalLimit.ToString();
                //this.Fields["MedicalLimit1"].Value = MedicalLimit.ToString();

                this.Fields["MedicalPrem" + CountDataIndex.ToString()].Value = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.Medical, AC);//AC.MedicalPremium().ToString();

                //				int MedicalLimit = AC.MedicalLimit*1000;
                //				this.Fields["MedicalLimit"+CountDataIndex.ToString()].Value = MedicalLimit.ToString();
                //				this.Fields["MedicalPrem"+CountDataIndex.ToString()].Value = GetBreakDownByTypeAndAnniversary(Quotes.Enumerators.Premiums.Medical,AC);//AC.MedicalPremium().ToString();
            }

            if (AC.LeaseLoanGapPremium() != 0)
            {
                this.Fields["LLoanGapPrem" + CountDataIndex.ToString()].Value = System.Math.Round(decimal.Parse(GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.LeaseLoanGap, AC)), 0);//System.Math.Round(AC.LeaseLoanGapPremium(),0);
            }

            if (AC.AssistancePremium != 0)
            {
                this.Fields["AssistancePrem" + CountDataIndex.ToString()].Value = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.Assistance, AC);//AC.AssistancePremium.ToString();
            }

            if (AC.VehicleRental != 0)
            {
                this.Fields["SeatBeltPrem" + CountDataIndex.ToString()].Value = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.VehicleRental, AC);
            }

            if (AC.TowingPremium != 0)
            {
                this.Fields["TowingPrem" + CountDataIndex.ToString()].Value = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.Towing, AC);//AC.TowingPremium.ToString();
            }

            if (AC.SeatBeltPremium() != 0)
            {
                this.Fields["SeatBeltPrem" + CountDataIndex.ToString()].Value = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.SeatBelt, AC);//AC.SeatBeltPremium().ToString();
            }

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
            for (int i = 1; i <= _policy.QuoteAuto.AutoCovers.Count; i++)
            {
                GroupFooter1.Controls["TxtBodilyInjuryLimit" + i.ToString()].Visible = true;
                GroupFooter1.Controls["TxtCSLorBD" + i.ToString()].Visible = true;
                GroupFooter1.Controls["TxtPropertyDamageLimit" + i.ToString()].Visible = true;
                GroupFooter1.Controls["TxtMedicalLimit" + i.ToString()].Visible = true;
                GroupFooter1.Controls["TxtColl" + i.ToString()].Visible = true;
                GroupFooter1.Controls["TxtComp" + i.ToString()].Visible = true;
                GroupFooter1.Controls["TxtBodilyInjuryPrem" + i.ToString()].Visible = true;
                GroupFooter1.Controls["TxtCSLPrem" + i.ToString()].Visible = true;
                GroupFooter1.Controls["TxtPropertyDamagePrem" + i.ToString()].Visible = true;
                GroupFooter1.Controls["TxtMedicalPrem" + i.ToString()].Visible = true;
                GroupFooter1.Controls["TxtCollPrem" + i.ToString()].Visible = true;
                GroupFooter1.Controls["TxtCompPrem" + i.ToString()].Visible = true;
                GroupFooter1.Controls["TxtLLoanGapPrem" + i.ToString()].Visible = true;
                GroupFooter1.Controls["TxtAssistancePrem" + i.ToString()].Visible = true;
                GroupFooter1.Controls["TxtTowingPrem" + i.ToString()].Visible = true;
                GroupFooter1.Controls["TxtSeatBeltPrem" + i.ToString()].Visible = true;
                GroupFooter1.Controls["TxtAutoTotPrem" + i.ToString()].Visible = true;
            }
        }

        private void InvisibleTextBox(int i)
        {
            GroupFooter1.Controls["TxtBodilyInjuryLimit" + i.ToString()].Visible = false;
            GroupFooter1.Controls["TxtCSLorBD" + i.ToString()].Visible = false;
            GroupFooter1.Controls["TxtPropertyDamageLimit" + i.ToString()].Visible = false;
            GroupFooter1.Controls["TxtMedicalLimit" + i.ToString()].Visible = false;
            GroupFooter1.Controls["TxtColl" + i.ToString()].Visible = false;
            GroupFooter1.Controls["TxtComp" + i.ToString()].Visible = false;
            GroupFooter1.Controls["TxtBodilyInjuryPrem" + i.ToString()].Visible = false;
            GroupFooter1.Controls["TxtCSLPrem" + i.ToString()].Visible = false;
            GroupFooter1.Controls["TxtPropertyDamagePrem" + i.ToString()].Visible = false;
            GroupFooter1.Controls["TxtMedicalPrem" + i.ToString()].Visible = false;
            GroupFooter1.Controls["TxtCollPrem" + i.ToString()].Visible = false;
            GroupFooter1.Controls["TxtCompPrem" + i.ToString()].Visible = false;
            GroupFooter1.Controls["TxtLLoanGapPrem" + i.ToString()].Visible = false;
            GroupFooter1.Controls["TxtAssistancePrem" + i.ToString()].Visible = false;
            GroupFooter1.Controls["TxtTowingPrem" + i.ToString()].Visible = false;
            GroupFooter1.Controls["TxtSeatBeltPrem" + i.ToString()].Visible = false;
            GroupFooter1.Controls["TxtAutoTotPrem" + i.ToString()].Visible = false;
        }

        private void GroupData()
        {
            this.Fields["SetPageByTwoVehicle"].Value =
                (CountDataIndex + CountDataIndex % 2) / 2;
        }

        private void GroupFooter1_Format(object sender, EventArgs e)
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

            GroupCount++;
        }

        private void RightColumnLocation(int a)
        {
            PointF loc = new PointF();

            loc.X = 4.9F;
            loc.Y = 1.13F;
            GroupFooter1.Controls["TxtBodilyInjuryLimit" + a.ToString()].Location = loc;

            loc.X = 4.9F;
            loc.Y = 1.28F;
            GroupFooter1.Controls["TxtCSLorBD" + a.ToString()].Location = loc;

            loc.X = 4.9F;
            loc.Y = 1.52F;
            GroupFooter1.Controls["TxtPropertyDamageLimit" + a.ToString()].Location = loc;

            loc.X = 4.9F;
            loc.Y = 1.752F;
            GroupFooter1.Controls["TxtMedicalLimit" + a.ToString()].Location = loc;

            loc.X = 6.08F;
            loc.Y = 2.26F;
            GroupFooter1.Controls["TxtColl" + a.ToString()].Location = loc;

            loc.X = 6.08F;
            loc.Y = 2.56F;
            GroupFooter1.Controls["TxtComp" + a.ToString()].Location = loc;

            loc.X = 7.36F;
            loc.Y = 1.13F;
            GroupFooter1.Controls["TxtBodilyInjuryPrem" + a.ToString()].Location = loc;

            loc.X = 7.33F;
            loc.Y = 1.25F;
            GroupFooter1.Controls["TxtCSLPrem" + a.ToString()].Location = loc;

            loc.X = 7.33F;
            loc.Y = 1.50F;
            GroupFooter1.Controls["TxtPropertyDamagePrem" + a.ToString()].Location = loc;

            loc.X = 7.33F;
            loc.Y = 1.75F;
            GroupFooter1.Controls["TxtMedicalPrem" + a.ToString()].Location = loc;

            loc.X = 7.33F;
            loc.Y = 2.26F;
            GroupFooter1.Controls["TxtCollPrem" + a.ToString()].Location = loc;

            loc.X = 7.33F;
            loc.Y = 2.565F;
            GroupFooter1.Controls["TxtCompPrem" + a.ToString()].Location = loc;

            loc.X = 7.33F;
            loc.Y = 3.19F;
            GroupFooter1.Controls["TxtLLoanGapPrem" + a.ToString()].Location = loc;

            loc.X = 7.33F;
            loc.Y = 2.740F;  //loc.Y = 2.875F;
            GroupFooter1.Controls["TxtAssistancePrem" + a.ToString()].Location = loc;

            loc.X = 7.33F;
            loc.Y = 2.88F;
            GroupFooter1.Controls["TxtTowingPrem" + a.ToString()].Location = loc;

            loc.X = 7.33F;
            loc.Y = 3.125F;
            GroupFooter1.Controls["TxtSeatBeltPrem" + a.ToString()].Location = loc;

            loc.X = 7.33F;
            loc.Y = 3.38F;
            GroupFooter1.Controls["TxtAutoTotPrem" + a.ToString()].Location = loc;
        }

        private void LeftColumnLocation(int a)
        {
            PointF loc = new PointF();

            loc.X = 2.059F;
            loc.Y = 1.126F;
            GroupFooter1.Controls["TxtBodilyInjuryLimit" + a.ToString()].Location = loc;

            loc.X = 2.059F;
            loc.Y = 1.28F;
            GroupFooter1.Controls["TxtCSLorBD" + a.ToString()].Location = loc;

            loc.X = 2.059F;
            loc.Y = 1.52F;
            GroupFooter1.Controls["TxtPropertyDamageLimit" + a.ToString()].Location = loc;

            loc.X = 2.059F;
            loc.Y = 1.752F;
            GroupFooter1.Controls["TxtMedicalLimit" + a.ToString()].Location = loc;

            loc.X = 2.933F;
            loc.Y = 2.26F;
            GroupFooter1.Controls["TxtColl" + a.ToString()].Location = loc;

            loc.X = 2.933F;
            loc.Y = 2.565F;
            GroupFooter1.Controls["TxtComp" + a.ToString()].Location = loc;

            loc.X = 4.35F;
            loc.Y = 1.13F;
            GroupFooter1.Controls["TxtBodilyInjuryPrem" + a.ToString()].Location = loc;

            loc.X = 4.35F;
            loc.Y = 1.25F;
            GroupFooter1.Controls["TxtCSLPrem" + a.ToString()].Location = loc;

            loc.X = 4.35F;
            loc.Y = 1.50F;
            GroupFooter1.Controls["TxtPropertyDamagePrem" + a.ToString()].Location = loc;

            loc.X = 4.38F;
            loc.Y = 1.75F;
            GroupFooter1.Controls["TxtMedicalPrem" + a.ToString()].Location = loc;

            loc.X = 4.35F;
            loc.Y = 2.25F;
            GroupFooter1.Controls["TxtCollPrem" + a.ToString()].Location = loc;

            loc.X = 4.35F;
            loc.Y = 2.56F;
            GroupFooter1.Controls["TxtCompPrem" + a.ToString()].Location = loc;

            loc.X = 4.35F;
            loc.Y = 3.19F;
            GroupFooter1.Controls["TxtLLoanGapPrem" + a.ToString()].Location = loc;

            loc.X = 4.35F;
            loc.Y = 2.740F; //2.675F;
            GroupFooter1.Controls["TxtAssistancePrem" + a.ToString()].Location = loc;

            loc.X = 4.35F;
            loc.Y = 2.88F;
            GroupFooter1.Controls["TxtTowingPrem" + a.ToString()].Location = loc;

            loc.X = 4.35F;
            loc.Y = 3.025F;
            GroupFooter1.Controls["TxtSeatBeltPrem" + a.ToString()].Location = loc;

            loc.X = 4.35F;
            loc.Y = 3.38F;
            GroupFooter1.Controls["TxtAutoTotPrem" + a.ToString()].Location = loc;
        }

        private void PersonalPackageSeccionIII_ReportStart(object sender, EventArgs e)
        {
            txtPolicyNo.Text = _policy.PolicyType.ToString().ToUpper().Trim() + " " + _policy.PolicyNo.ToString().Trim() + " " + _policy.Certificate.ToString().Trim();
            txtEffectiveDate.Text = _policy.EffectiveDate.ToString();
            txtExpirationDate.Text = _policy.ExpirationDate.ToString();
            txtEmision.Text = _policy.EntryDate.ToShortDateString();
            txtAutoEnd.Text = "OPP AP 0001 07 07; "+_policy.AutoEnd.Trim();

            txtPremium.Text = _policy.AutoPremium.ToString("$ #,##0.00").Trim();
            txtCharge.Text = _policy.Charge.ToString("$ #,##0.00").Trim();
            double totprem2 = _policy.AutoPremium + _policy.Charge;
            txtTotalPremium.Text = totprem2.ToString("$ #,##0.00");

            EPolicy.Quotes.AutoCover AC = null;
            AC = (EPolicy.Quotes.AutoCover)_policy.QuoteAuto.AutoCovers[0];
            EPolicy.LookupTables.Bank bank = new Bank();
            bank = bank.GetBank(AC.Bank);
            txtBank.Text = bank.BankID.Trim() + " -  " + bank.BankDesc.ToString().Trim();

            if (_policy.EnteredBy.Trim() != "")
                lblEnteredBy.Text = "Por: " + _policy.EnteredBy.Trim();
            else
                lblEnteredBy.Text = "";

            bool Left = true;
            Font font = new Font("Arial", 8);
            SizeF size = new SizeF();

            for (int i = 1; i <= _policy.QuoteAuto.AutoCovers.Count; i++)
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
                GroupFooter1.Controls.Add(Txt1);
                GroupFooter1.Controls["TxtBodilyInjuryLimit" + i.ToString()].DataField = "BodilyInjuryLimit" + i.ToString();
                GroupFooter1.Controls["TxtBodilyInjuryLimit" + i.ToString()].Visible = false;
                size.Height = .02F;
                size.Width = 1F;
                GroupFooter1.Controls["TxtBodilyInjuryLimit" + i.ToString()].Size = size;

                Txt2.Text = "TxtCSLorBD" + i.ToString();
                Txt2.Name = "TxtCSLorBD" + i.ToString();
                Txt2.Alignment = TextAlignment.Right;
                Txt2.Font = font;
                Txt2.OutputFormat = "$#,##0.00";
                GroupFooter1.Controls.Add(Txt2);
                GroupFooter1.Controls["TxtCSLorBD" + i.ToString()].DataField = "CSLorBD" + i.ToString();
                GroupFooter1.Controls["TxtCSLorBD" + i.ToString()].Visible = false;
                size.Height = .02F;
                size.Width = 1F;
                GroupFooter1.Controls["TxtCSLorBD" + i.ToString()].Size = size;

                Txt3.Text = "TxtPropertyDamageLimit" + i.ToString();
                Txt3.Name = "TxtPropertyDamageLimit" + i.ToString();
                Txt3.Alignment = TextAlignment.Right;
                Txt3.Font = font;
                Txt3.OutputFormat = "$#,##0.00";
                GroupFooter1.Controls.Add(Txt3);
                GroupFooter1.Controls["TxtPropertyDamageLimit" + i.ToString()].DataField = "PropertyDamageLimit" + i.ToString();
                GroupFooter1.Controls["TxtPropertyDamageLimit" + i.ToString()].Visible = false;
                size.Height = .02F;
                size.Width = 1F;
                GroupFooter1.Controls["TxtPropertyDamageLimit" + i.ToString()].Size = size;

                Txt4.Text = "TxtMedicalLimit" + i.ToString();
                Txt4.Name = "TxtMedicalLimit" + i.ToString();
                Txt4.Alignment = TextAlignment.Right;
                Txt4.Font = font;
                Txt4.OutputFormat = "$#,##0.00";
                GroupFooter1.Controls.Add(Txt4);
                GroupFooter1.Controls["TxtMedicalLimit" + i.ToString()].DataField = "MedicalLimit" + i.ToString();
                GroupFooter1.Controls["TxtMedicalLimit" + i.ToString()].Visible = false;
                size.Height = .02F;
                size.Width = 1F;
                GroupFooter1.Controls["TxtMedicalLimit" + i.ToString()].Size = size;

                Txt5.Text = "TxtColl" + i.ToString();
                Txt5.Name = "TxtColl" + i.ToString();
                Txt5.Alignment = TextAlignment.Right;
                Txt5.Font = font;
                Txt5.OutputFormat = "$#,##0.00";
                GroupFooter1.Controls.Add(Txt5);
                GroupFooter1.Controls["TxtColl" + i.ToString()].DataField = "CollLimit" + i.ToString();
                GroupFooter1.Controls["TxtColl" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .455F;
                GroupFooter1.Controls["TxtColl" + i.ToString()].Size = size;

                Txt6.Text = "TxtComp" + i.ToString();
                Txt6.Name = "TxtComp" + i.ToString();
                Txt6.Alignment = TextAlignment.Right;
                Txt6.Font = font;
                Txt6.OutputFormat = "$#,##0.00";
                GroupFooter1.Controls.Add(Txt6);
                GroupFooter1.Controls["TxtComp" + i.ToString()].DataField = "CompLimit" + i.ToString();
                GroupFooter1.Controls["TxtComp" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .455F;
                GroupFooter1.Controls["TxtComp" + i.ToString()].Size = size;

                Txt7.Text = "TxtBodilyInjuryPrem" + i.ToString();
                Txt7.Name = "TxtBodilyInjuryPrem" + i.ToString();
                Txt7.Alignment = TextAlignment.Right;
                Txt7.Font = font;
                Txt7.OutputFormat = "$#,##0.00";
                GroupFooter1.Controls.Add(Txt7);
                GroupFooter1.Controls["TxtBodilyInjuryPrem" + i.ToString()].DataField = "BodilyInjuryPrem" + i.ToString();
                GroupFooter1.Controls["TxtBodilyInjuryPrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                GroupFooter1.Controls["TxtBodilyInjuryPrem" + i.ToString()].Size = size;

                Txt8.Text = "TxtCSLPrem" + i.ToString();
                Txt8.Name = "TxtCSLPrem" + i.ToString();
                Txt8.Alignment = TextAlignment.Right;
                Txt8.OutputFormat = "$#,##0.00";
                Txt8.Font = font;
                GroupFooter1.Controls.Add(Txt8);
                GroupFooter1.Controls["TxtCSLPrem" + i.ToString()].DataField = "CSLPrem" + i.ToString();
                GroupFooter1.Controls["TxtCSLPrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                GroupFooter1.Controls["TxtCSLPrem" + i.ToString()].Size = size;

                Txt9.Text = "TxtPropertyDamagePrem" + i.ToString();
                Txt9.Name = "TxtPropertyDamagePrem" + i.ToString();
                Txt9.Alignment = TextAlignment.Right;
                Txt9.Font = font;
                Txt9.OutputFormat = "$#,##0.00";
                GroupFooter1.Controls.Add(Txt9);
                GroupFooter1.Controls["TxtPropertyDamagePrem" + i.ToString()].DataField = "PropertyDamagePrem" + i.ToString();
                GroupFooter1.Controls["TxtPropertyDamagePrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                GroupFooter1.Controls["TxtPropertyDamagePrem" + i.ToString()].Size = size;

                Txt10.Text = "TxtMedicalPrem" + i.ToString();
                Txt10.Name = "TxtMedicalPrem" + i.ToString();
                Txt10.Alignment = TextAlignment.Right;
                Txt10.Font = font;
                Txt10.OutputFormat = "$#,##0.00";
                GroupFooter1.Controls.Add(Txt10);
                GroupFooter1.Controls["TxtMedicalPrem" + i.ToString()].DataField = "MedicalPrem" + i.ToString();
                GroupFooter1.Controls["TxtMedicalPrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                GroupFooter1.Controls["TxtMedicalPrem" + i.ToString()].Size = size;

                Txt11.Text = "TxtCollPrem" + i.ToString();
                Txt11.Name = "TxtCollPrem" + i.ToString();
                Txt11.Alignment = TextAlignment.Right;
                Txt11.Font = font;
                Txt11.OutputFormat = "$#,##0.00";
                GroupFooter1.Controls.Add(Txt11);
                GroupFooter1.Controls["TxtCollPrem" + i.ToString()].DataField = "CollPrem" + i.ToString();
                GroupFooter1.Controls["TxtCollPrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                GroupFooter1.Controls["TxtCollPrem" + i.ToString()].Size = size;

                Txt12.Text = "TxtCompPrem" + i.ToString();
                Txt12.Name = "TxtCompPrem" + i.ToString();
                Txt12.Alignment = TextAlignment.Right;
                Txt12.Font = font;
                Txt12.OutputFormat = "$#,##0.00";
                GroupFooter1.Controls.Add(Txt12);
                GroupFooter1.Controls["TxtCompPrem" + i.ToString()].DataField = "CompPrem" + i.ToString();
                GroupFooter1.Controls["TxtCompPrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                GroupFooter1.Controls["TxtCompPrem" + i.ToString()].Size = size;

                Txt13.Text = "TxtLLoanGapPrem" + i.ToString();
                Txt13.Name = "TxtLLoanGapPrem" + i.ToString();
                Txt13.Alignment = TextAlignment.Right;
                Txt13.Font = font;
                Txt13.OutputFormat = "$#,##0.00";
                GroupFooter1.Controls.Add(Txt13);
                GroupFooter1.Controls["TxtLLoanGapPrem" + i.ToString()].DataField = "LLoanGapPrem" + i.ToString();
                GroupFooter1.Controls["TxtLLoanGapPrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                GroupFooter1.Controls["TxtLLoanGapPrem" + i.ToString()].Size = size;

                Txt14.Text = "TxtAssistancePrem" + i.ToString();
                Txt14.Name = "TxtAssistancePrem" + i.ToString();
                Txt14.Alignment = TextAlignment.Right;
                Txt14.Font = font;
                Txt14.OutputFormat = "$#,##0.00";
                GroupFooter1.Controls.Add(Txt14);
                GroupFooter1.Controls["TxtAssistancePrem" + i.ToString()].DataField = "AssistancePrem" + i.ToString();
                GroupFooter1.Controls["TxtAssistancePrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                GroupFooter1.Controls["TxtAssistancePrem" + i.ToString()].Size = size;

                Txt15.Text = "TxtTowingPrem" + i.ToString();
                Txt15.Name = "TxtTowingPrem" + i.ToString();
                Txt15.Alignment = TextAlignment.Right;
                Txt15.Font = font;
                Txt15.OutputFormat = "$#,##0.00";
                GroupFooter1.Controls.Add(Txt15);
                GroupFooter1.Controls["TxtTowingPrem" + i.ToString()].DataField = "TowingPrem" + i.ToString();
                GroupFooter1.Controls["TxtTowingPrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                GroupFooter1.Controls["TxtTowingPrem" + i.ToString()].Size = size;

                Txt16.Text = "TxtSeatBeltPrem" + i.ToString();
                Txt16.Name = "TxtSeatBeltPrem" + i.ToString();
                Txt16.Alignment = TextAlignment.Right;
                Txt16.Font = font;
                Txt16.OutputFormat = "$#,##0.00";
                GroupFooter1.Controls.Add(Txt16);
                GroupFooter1.Controls["TxtSeatBeltPrem" + i.ToString()].DataField = "SeatBeltPrem" + i.ToString();
                GroupFooter1.Controls["TxtSeatBeltPrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                GroupFooter1.Controls["TxtSeatBeltPrem" + i.ToString()].Size = size;

                Txt17.Text = "TxtAutoTotPrem" + i.ToString();
                Txt17.Name = "TxtAutoTotPrem" + i.ToString();
                Txt17.Alignment = TextAlignment.Right;
                Txt17.Font = font;
                Txt17.OutputFormat = "$#,##0.00";
                GroupFooter1.Controls.Add(Txt17);
                GroupFooter1.Controls["TxtAutoTotPrem" + i.ToString()].DataField = "AutoTotPrem" + i.ToString();
                GroupFooter1.Controls["TxtAutoTotPrem" + i.ToString()].Visible = false;
                size.Height = .2F;
                size.Width = .608F;
                GroupFooter1.Controls["TxtAutoTotPrem" + i.ToString()].Size = size;

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
