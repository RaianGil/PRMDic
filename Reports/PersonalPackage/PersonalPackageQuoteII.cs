using System;
using System.Data;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.Customer;
using EPolicy.LookupTables;
using EPolicy.TaskControl;

namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for PersonalPackageQuoteII.
    /// </summary>
    public partial class PersonalPackageQuoteII : DataDynamics.ActiveReports.ActiveReport3
    {
        private int CountDataIndex = 1;
        private int index = 0;
        private Label lblLeasing;
        private decimal _VehicleTotal;
        private double _PremTotal;
        private EPolicy.TaskControl.OptimaPersonalPackage _taskcontrol;

        public PersonalPackageQuoteII(EPolicy.TaskControl.OptimaPersonalPackage taskcontrol)
        {
            _taskcontrol = taskcontrol;     
            InitializeComponent();
        }

        private void PersonalPackageQuoteII_ReportStart(object sender, EventArgs e)
        {
            txtCotizacionNo.Text = _taskcontrol.TaskControlID.ToString().Trim();
            TxtFecha.Text = _taskcontrol.EntryDate.ToShortDateString();

            //Seccion II
            if (_taskcontrol.PersonalLiabilityCollection.Rows.Count > 0)
            {
                int medpay = 0;
                medpay = (int) _taskcontrol.PersonalLiabilityCollection.Rows[0]["PersonalLiability1"];

                switch ((int)_taskcontrol.PersonalLiabilityCollection.Rows[0]["PersonalLiability1"])
                {
                    case 100000:
                        TxtPersonalLiability.Text = medpay.ToString("###,###,###") + "  -  3";
                        break;

                    case 200000:
                        TxtPersonalLiability.Text = medpay.ToString("###,###,###") + "  -  4";
                        break;

                    case 300000:
                        TxtPersonalLiability.Text = medpay.ToString("###,###,###") + "  -  5";
                        break;

                    case 400000:
                        TxtPersonalLiability.Text = medpay.ToString("###,###,###") + "  -  6";
                        break;

                    case 500000:
                        TxtPersonalLiability.Text = medpay.ToString("###,###,###") + "  -  7";
                        break;
                }
                
                medpay = (int)_taskcontrol.PersonalLiabilityCollection.Rows[0]["MedicalPayment1"];
                TxtMedicalPayments.Text = medpay.ToString("###,###,###");

                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["BasicRate1"];
                TxtBasicRate1.Text = _PremTotal.ToString("###,###.00");
                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["BasicRate2"];
                TxtBasicRate2.Text = _PremTotal.ToString("###,###.00");
                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["BasicRate3"];
                TxtBasicRate3.Text = _PremTotal.ToString("###,###.00");
                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["BasicRate4"];
                TxtBasicRate4.Text = _PremTotal.ToString("###,###.00");

                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["IncreaseLimit1"];
                TxtIncreaseLimit1.Text = _PremTotal.ToString("###,###.00");
                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["IncreaseLimit2"];
                TxtIncreaseLimit.Text = _PremTotal.ToString("###,###.00");
                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["IncreaseLimit3"];
                TxtIncreaseLimit3.Text = _PremTotal.ToString("###,###.00");
                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["IncreaseLimit4"];
                TxtIncreaseLimit4.Text = _PremTotal.ToString("###,###.00");

                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["BasicPremium1"];
                TxtBasicPremium1.Text = _PremTotal.ToString("###,###.00");
                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["BasicPremium2"];
                TxtBasicPremium2.Text = _PremTotal.ToString("###,###.00");
                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["BasicPremium3"];
                TxtBasicPremium3.Text = _PremTotal.ToString("###,###.00");
                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["BasicPremium4"];
                TxtBasicPremium4.Text = _PremTotal.ToString("###,###.00");

                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["MedicalPrem1"];
                TxtMedicalPrem1.Text = _PremTotal.ToString("###,###.00");
                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["MedicalPrem2"];
                TxtMedicalPrem2.Text = _PremTotal.ToString("###,###.00");
                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["MedicalPrem3"];
                TxtMedicalPrem3.Text = _PremTotal.ToString("###,###.00");
                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["MedicalPrem4"];
                TxtMedicalPrem4.Text = _PremTotal.ToString("###,###.00");

                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["DiscountFactor1"];
                TxtDiscountFactor1.Text = _PremTotal.ToString("###,###.00");
                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["DiscountFactor2"];
                TxtDiscountFactor2.Text = _PremTotal.ToString("###,###.00");
                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["DiscountFactor3"];
                TxtDiscountFactor3.Text = _PremTotal.ToString("###,###.00");
                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["DiscountFactor4"];
                TxtDiscountFactor4.Text = _PremTotal.ToString("###,###.00");

                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["Premium1"];
                TxtPremium1.Text = _PremTotal.ToString("###,###.00");
                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["Premium2"];
                TxtPremium2.Text = _PremTotal.ToString("###,###.00");
                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["Premium3"];
                TxtPremium3.Text = _PremTotal.ToString("###,###.00");
                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["Premium4"];
                TxtPremium4.Text = _PremTotal.ToString("###,###.00");

                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["TotalLiabilityPremium"];
                TxtPremium5.Text = _PremTotal.ToString("###,###.00");

                TxtTotalAdditionalCoverage.Text = SetAdditionalCoverageTotalPremium(_taskcontrol.AdditionalCoveragesLiabilityCollection).ToString("###,###,###.00");


                TxtSubTotalPrem.Text = ((double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["SubTotalPremium"]).ToString("###,###.00");
                txtCharge.Text = ((double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["Charge"]).ToString("###,###.00");
                TxtPrimaRes.Text = ((double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["TotalPremium"]).ToString("###,###.00");

                SetPointCode();

                if (_taskcontrol.PersonalLiabilityCollection.Rows[0]["ExperienceCredit"].ToString().Trim() != "0")
                {
                    double credit1 = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["ExperienceCredit"];
                    double credit = Math.Round(double.Parse(TxtSubTotalPrem.Text) * ((double.Parse(credit1.ToString())) / 100), 0);
                    credit = credit * -1;
                    TxtExperienceCredit.Text = credit.ToString("##,###.00");
                }

                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["TotalPremium"];
                TxtLiabilityPremium.Text = _PremTotal.ToString("###,###.00");

                SetPremiumNet(TxtPrimaRes.Text, TxtSubTotalPrem.Text);
            }
            else
            {
                TxtTotalAdditionalCoverage.Text = "0.00";
                TxtLiabilityPremium.Text = "0.00";
            }
        }

        private void SetPremiumNet(string TotPrima, string SubTotalPrima)
        {
            double sumaPrem = 0.00;
            double tempTot = 0.00;
            double totprem = double.Parse(TotPrima);
            double subtotprem = double.Parse(SubTotalPrima);
            double percent = totprem / double.Parse(SubTotalPrima);
            percent = Math.Round(percent, 4);

            tempTot = 0.00;
            tempTot = Math.Round(double.Parse(TxtPremium1.Text) * percent,0);
            sumaPrem = sumaPrem + tempTot;
            txtNeto1.Text = tempTot.ToString("###,###.00");

            tempTot = 0.00;
            tempTot = Math.Round(double.Parse(TxtPremium2.Text) * percent,0);
            sumaPrem = sumaPrem + tempTot;
            txtNeto2.Text = tempTot.ToString("###,###.00");

            tempTot = 0.00;
            tempTot = Math.Round(double.Parse(TxtPremium3.Text) * percent,0);
            sumaPrem = sumaPrem + tempTot;
            txtNeto3.Text = tempTot.ToString("###,###.00");

            tempTot = 0.00;
            tempTot = Math.Round(double.Parse(TxtPremium4.Text) * percent,0);
            sumaPrem = sumaPrem + tempTot;
            txtNeto4.Text = tempTot.ToString("###,###.00");

            tempTot = 0.00;
            //tempTot = Math.Round(double.Parse(TxtPremium5.Text) * percent, 0);
            txtNeto5.Text = sumaPrem.ToString("###,###.00");  //tempTot.ToString("###,###.00");

            tempTot = 0.00;
            tempTot = Math.Round(double.Parse(TxtTotalAdditionalCoverage.Text) * percent, 0);
            txtNeto6.Text = tempTot.ToString("###,###.00");

            if (double.Parse(TxtPrimaRes.Text) != double.Parse(txtNeto5.Text) + double.Parse(txtNeto6.Text))
            {
                double sumaSubTot = double.Parse(txtNeto5.Text) + double.Parse(txtNeto6.Text);
                double sumaTot = double.Parse(TxtPrimaRes.Text);
                double dif = sumaTot - sumaSubTot;

                if (double.Parse(TxtPrimaRes.Text) > double.Parse(txtNeto5.Text))
                {
                    sumaSubTot = double.Parse(txtNeto1.Text) + Math.Abs(dif);
                    txtNeto1.Text = sumaSubTot.ToString("$###,###.00");

                    sumaSubTot = double.Parse(txtNeto5.Text) + Math.Abs(dif);
                    txtNeto5.Text = sumaSubTot.ToString("$###,###.00");
                }
                else
                {
                    sumaSubTot = double.Parse(txtNeto1.Text) - Math.Abs(dif);
                    txtNeto1.Text = sumaSubTot.ToString("$###,###.00");

                    sumaSubTot = double.Parse(txtNeto5.Text) - Math.Abs(dif);
                    txtNeto5.Text = sumaSubTot.ToString("$###,###.00");
                }
            }
        }

        private void SetPointCode()
        {
            txtTerr1.Text = "032";

            if((int) _taskcontrol.PersonalLiabilityCollection.Rows[0]["PersonalLiability1"] < 1000000)
                txtCovLimit.Text = PrintPolicy.GetPointCode("Liability", "LiabilityPersonalLimitMenor", "1000000");
            else
                txtCovLimit.Text = PrintPolicy.GetPointCode("Liability", "LiabilityPersonalLimitMayor", "1000000");

            
            txtPCRes1.Text = PrintPolicy.GetPointCode("Liability", "Liabilit Subline", "480") + " - " +
                PrintPolicy.GetPointCode("Liability", "LiabilityRes1Fam", ((int) _taskcontrol.PersonalLiabilityCollection.Rows[0]["Families1"]).ToString().Trim());

            if ((double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["BasicRate2"] != 0)
            {
                if ((bool)_taskcontrol.PersonalLiabilityCollection.Rows[0]["Rented2"] == true)
                    txtPCRes2.Text = PrintPolicy.GetPointCode("Liability", "Liabilit Subline", "480") + " - " +
                        PrintPolicy.GetPointCode("Liability", "LiabilityRes2FamRented", ((int)_taskcontrol.PersonalLiabilityCollection.Rows[0]["Families1"]).ToString().Trim());
                else
                {
                    txtPCRes2.Text = PrintPolicy.GetPointCode("Liability", "Liabilit Subline", "480") + " - " +
                        PrintPolicy.GetPointCode("Liability", "LiabilityRes2Fam", ((int)_taskcontrol.PersonalLiabilityCollection.Rows[0]["Families1"]).ToString().Trim());
                }
            }

            if ((double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["BasicRate3"] != 0)
            {
                if ((bool)_taskcontrol.PersonalLiabilityCollection.Rows[0]["Rented3"] == true)
                    txtPCRes3.Text = PrintPolicy.GetPointCode("Liability", "Liabilit Subline", "480") + " - " +
                        PrintPolicy.GetPointCode("Liability", "LiabilityRes2FamRented", ((int)_taskcontrol.PersonalLiabilityCollection.Rows[0]["Families1"]).ToString().Trim());
                else
                {
                    txtPCRes3.Text = PrintPolicy.GetPointCode("Liability", "Liabilit Subline", "480") + " - " +
                        PrintPolicy.GetPointCode("Liability", "LiabilityRes2Fam", ((int)_taskcontrol.PersonalLiabilityCollection.Rows[0]["Families1"]).ToString().Trim());
                }
            }

            if ((double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["BasicRate4"] != 0)
            {
                if ((bool)_taskcontrol.PersonalLiabilityCollection.Rows[0]["Rented4"] == true)
                    txtPCRes4.Text = PrintPolicy.GetPointCode("Liability", "Liabilit Subline", "480") + " - " +
                        PrintPolicy.GetPointCode("Liability", "LiabilityRes2FamRented", ((int)_taskcontrol.PersonalLiabilityCollection.Rows[0]["Families1"]).ToString().Trim());
                else
                {
                    txtPCRes4.Text = PrintPolicy.GetPointCode("Liability", "Liabilit Subline", "480") + " - " +
                        PrintPolicy.GetPointCode("Liability", "LiabilityRes2Fam", ((int)_taskcontrol.PersonalLiabilityCollection.Rows[0]["Families1"]).ToString().Trim());
                }
            }
        }

        private double SetAdditionalCoverageTotalPremium(DataTable dt)
        {
            double prem = 0.00;
            for (int a = 0; dt.Rows.Count - 1 >= a; a++)
            {
                prem = prem + double.Parse(dt.Rows[a]["Premium"].ToString());
            }
            return prem;
        }

        private void TotalPremiumByVehicle(EPolicy.Quotes.AutoCover AC)
        {
            _VehicleTotal = 0;

            if (AC.BodilyInjuryPremium() != 0)
            {
                string test = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.BodilyInjury, AC);
            }

            if (AC.CombinedSinglePremium() != 0)
            {
                string test = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.CombinedSingle, AC);
            }

            if (AC.CombinedSinglePremium() == 0)
            {
                string test = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.PropertyDamage, AC);
            }

            if (AC.CollisionDeductible != 0)
            {
                string test = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.Collision, AC);
            }

            if (AC.ComprehensiveDeductible != 0)
            {
                string test = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.Comprehensive, AC);
            }

            if (AC.MedicalPremium() != 0)
            {
                string test = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.Medical, AC);
            }

            if (AC.LeaseLoanGapPremium() != 0)
            {
                string test = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.LeaseLoanGap, AC);
            }

            if (AC.AssistancePremium != 0)
            {
                string test = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.Assistance, AC);
            }

            if (AC.TowingPremium != 0)
            {
                string test = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.Towing, AC);
            }

            if (AC.SeatBeltPremium() != 0)
            {
                string test = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.SeatBelt, AC);
            }
        }

        private string GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums Type, EPolicy.Quotes.AutoCover ac)
        {
            EPolicy.Quotes.CoverBreakdown CB = new EPolicy.Quotes.CoverBreakdown();
            CB.Type = (int)Type;
            EPolicy.Quotes.CoverBreakdown CB2 = (EPolicy.Quotes.CoverBreakdown)ac.Breakdown[ac.Breakdown.IndexOf(CB)];

            if ((int)Type == 5) //Para Lease Loan Gap
            {
                _VehicleTotal += System.Math.Round((decimal)CB2.Breakdown[0]);
            }
            else
            {
                System.Type typeByBC2 = CB2.Breakdown[0].GetType();
                object obj = CB2.Breakdown.GetByIndex(0);
                if (obj is int)
                {
                    _VehicleTotal += (decimal)((int)CB2.Breakdown[0]);
                }
                else
                {
                    _VehicleTotal += (decimal)CB2.Breakdown[0];
                }
            }
            return CB2.Breakdown[0].ToString();
        }
    }
}
