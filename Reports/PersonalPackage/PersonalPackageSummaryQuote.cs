using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.Customer;
using EPolicy.LookupTables;
using EPolicy.TaskControl;

namespace EPolicy2.Reports
{
    public partial class PersonalPackageSummaryQuote : DataDynamics.ActiveReports.ActiveReport3
    {
        //private string _CopyValue;
        private Label lblAutoLoan;
        private Label lblLeasing;
        private Picture Picture1;
        private decimal _VehicleTotal;
        private double _PremTotal;
        private EPolicy.TaskControl.OptimaPersonalPackage _taskcontrol;

        public PersonalPackageSummaryQuote(EPolicy.TaskControl.OptimaPersonalPackage taskcontrol)
        {
            _taskcontrol = taskcontrol;
            //_CopyValue = CopyValue;
            InitializeComponent();
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {

        }

        private void PersonalPackageSummaryQuote_ReportStart(object sender, EventArgs e)
        {
            //Header
            txtCotizacionNo.Text = _taskcontrol.TaskControlID.ToString().Trim();
            TxtFecha.Text = _taskcontrol.EntryDate.ToShortDateString();
            TxtCustomerName.Text = _taskcontrol.Prospect.FirstName.Trim() + " " + _taskcontrol.Prospect.LastName1.Trim() + " " +
                _taskcontrol.Prospect.LastName2.Trim();

            if (_taskcontrol.PropertiesCollection.Rows.Count != 0)
            {
                for (int i = 0; i < _taskcontrol.PropertiesCollection.Rows.Count; i++)
                {
                    if ((bool) _taskcontrol.PropertiesCollection.Rows[i]["Primary"] == true)
                    {
                        TxtAdds1.Text = _taskcontrol.PropertiesCollection.Rows[i]["Address1"].ToString().Trim();
                        if (_taskcontrol.PropertiesCollection.Rows[i]["Address2"].ToString().Trim() != "")
                        {
                            TxtAdds2.Text = _taskcontrol.PropertiesCollection.Rows[i]["Address2"].ToString().Trim();
                            TxtCitySTZip.Text = _taskcontrol.PropertiesCollection.Rows[i]["City"].ToString().Trim() + ", " +
                            _taskcontrol.PropertiesCollection.Rows[i]["State"].ToString().Trim() + "  " +
                            _taskcontrol.PropertiesCollection.Rows[i]["ZipCode"].ToString().Trim();
                        }
                        else
                        {
                            TxtAdds2.Text = _taskcontrol.PropertiesCollection.Rows[i]["City"].ToString().Trim() + ", " +
                            _taskcontrol.PropertiesCollection.Rows[i]["State"].ToString().Trim() + "  " +
                            _taskcontrol.PropertiesCollection.Rows[i]["ZipCode"].ToString().Trim();
                            TxtCitySTZip.Text = "";
                        }
                        
                    }
                }
            }

            //Seccion I
            if (_taskcontrol.PropertiesCollection.Rows.Count > 0)
            {
                TxtRes1.Text = _taskcontrol.PropertiesCollection.Rows[0]["Address1"].ToString() + " " +
                    _taskcontrol.PropertiesCollection.Rows[0]["Address2"].ToString() + " " +
                    _taskcontrol.PropertiesCollection.Rows[0]["City"].ToString() + ",  " +
                    _taskcontrol.PropertiesCollection.Rows[0]["State"].ToString() + "  " +
                    _taskcontrol.PropertiesCollection.Rows[0]["ZipCode"].ToString();
                _PremTotal = (double)_taskcontrol.PropertiesCollection.Rows[0]["TotalPremium"];
                TxtPrimaRes1.Text = _PremTotal.ToString("$###,###.00");
            }
            else
            {
                TxtPrimaRes1.Text = "$0.00";
            }

            if (_taskcontrol.PropertiesCollection.Rows.Count >1)
            {
                TxtRes2.Text = _taskcontrol.PropertiesCollection.Rows[1]["Address1"].ToString()+" "+
                    _taskcontrol.PropertiesCollection.Rows[1]["Address2"].ToString()+" "+
                    _taskcontrol.PropertiesCollection.Rows[1]["City"].ToString()+",  "+
                    _taskcontrol.PropertiesCollection.Rows[1]["State"].ToString() + "  " +
                    _taskcontrol.PropertiesCollection.Rows[1]["ZipCode"].ToString();
                _PremTotal = (double)_taskcontrol.PropertiesCollection.Rows[1]["TotalPremium"];
                TxtPrimaRes2.Text = _PremTotal.ToString("$###,###.00");
            }
            else
            {
                TxtPrimaRes2.Text = "$0.00";
            }

            if (_taskcontrol.PropertiesCollection.Rows.Count > 2)
            {
                TxtRes3.Text = _taskcontrol.PropertiesCollection.Rows[2]["Address1"].ToString() + " " +
                    _taskcontrol.PropertiesCollection.Rows[2]["Address2"].ToString() + " " +
                    _taskcontrol.PropertiesCollection.Rows[2]["City"].ToString() + ",  " +
                    _taskcontrol.PropertiesCollection.Rows[2]["State"].ToString() + "  " +
                    _taskcontrol.PropertiesCollection.Rows[2]["ZipCode"].ToString();
                _PremTotal = (double)_taskcontrol.PropertiesCollection.Rows[2]["TotalPremium"];
                TxtPrimaRes3.Text = _PremTotal.ToString("$###,###.00");
            }
            else
            {
                TxtPrimaRes3.Text = "$0.00";
            }

            if (_taskcontrol.PropertiesCollection.Rows.Count > 3)
            {
                TxtRes4.Text = _taskcontrol.PropertiesCollection.Rows[3]["Address1"].ToString() + " " +
                    _taskcontrol.PropertiesCollection.Rows[3]["Address2"].ToString() + " " +
                    _taskcontrol.PropertiesCollection.Rows[3]["City"].ToString() + ",  " +
                    _taskcontrol.PropertiesCollection.Rows[3]["State"].ToString() + "  " +
                    _taskcontrol.PropertiesCollection.Rows[3]["ZipCode"].ToString();
                _PremTotal = (double)_taskcontrol.PropertiesCollection.Rows[3]["TotalPremium"];
                TxtPrimaRes4.Text = _PremTotal.ToString("$###,###.00");
            }
            else
            {
                TxtPrimaRes4.Text = "$0.00";
            }

            TxtPrimaTotalSeccionI.Text = _taskcontrol.PropertiesPremium.ToString("$###,###.00");


            //Seccion II
            if (_taskcontrol.PersonalLiabilityCollection.Rows.Count > 0)
            {
                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["TotalPremium"];
                TxtPrimaPersonal.Text = _PremTotal.ToString("$###,###.00");

                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["TotalPremium"];
                TxtPrimaTotalSeccionII.Text = _PremTotal.ToString("$###,###.00");
            }
            else
            {
                TxtPrimaPersonal.Text = "$0.00";
                TxtPrimaTotalSeccionII.Text = "$0.00";
            }

            //Seccion III            
            if (_taskcontrol.QuoteAuto.VehicleCount > 0)
            {
                EPolicy.Quotes.AutoCover AC = (EPolicy.Quotes.AutoCover)_taskcontrol.QuoteAuto.AutoCovers[0];

                TxtAutoDesc1.Text = EPolicy.LookupTables.LookupTables.GetDescription("VehicleMake", AC.VehicleMake.ToString()) + " / " +
                 EPolicy.LookupTables.LookupTables.GetDescription("VehicleModel", AC.VehicleModel.ToString()) + " / " +
                 EPolicy.LookupTables.LookupTables.GetDescription("VehicleYear", AC.VehicleYear.ToString());

                _VehicleTotal = 0;
                this.TotalPremiumByVehicle(AC);
                TxtPrimaAuto1.Text = _VehicleTotal.ToString("$###,###.00");
            }
            else
            {
                TxtPrimaAuto1.Text = "$0.00";
            }
            

            if (_taskcontrol.QuoteAuto.VehicleCount > 1)
            {
                EPolicy.Quotes.AutoCover AC = (EPolicy.Quotes.AutoCover)_taskcontrol.QuoteAuto.AutoCovers[1];

                TxtAutoDesc2.Text = EPolicy.LookupTables.LookupTables.GetDescription("VehicleMake", AC.VehicleMake.ToString()) + " / " +
                 EPolicy.LookupTables.LookupTables.GetDescription("VehicleModel", AC.VehicleModel.ToString()) + " / " +
                 EPolicy.LookupTables.LookupTables.GetDescription("VehicleYear", AC.VehicleYear.ToString());

                _VehicleTotal = 0;
                this.TotalPremiumByVehicle(AC);
                TxtPrimaAuto2.Text = _VehicleTotal.ToString("$###,###.00");
            }
            else
            {
                TxtPrimaAuto2.Text = "$0.00";
            }

            if (_taskcontrol.QuoteAuto.VehicleCount > 2)
            {
                EPolicy.Quotes.AutoCover AC = (EPolicy.Quotes.AutoCover)_taskcontrol.QuoteAuto.AutoCovers[2];

                TxtAutoDesc3.Text = EPolicy.LookupTables.LookupTables.GetDescription("VehicleMake", AC.VehicleMake.ToString()) + " / " +
                 EPolicy.LookupTables.LookupTables.GetDescription("VehicleModel", AC.VehicleModel.ToString()) + " / " +
                 EPolicy.LookupTables.LookupTables.GetDescription("VehicleYear", AC.VehicleYear.ToString());

                _VehicleTotal = 0;
                this.TotalPremiumByVehicle(AC);
                TxtPrimaAuto3.Text = _VehicleTotal.ToString("$###,###.00");
            }
            else
            {
                TxtPrimaAuto3.Text = "$0.00";
            }

            if (_taskcontrol.QuoteAuto.VehicleCount > 3)
            {
                EPolicy.Quotes.AutoCover AC = (EPolicy.Quotes.AutoCover)_taskcontrol.QuoteAuto.AutoCovers[3];

                TxtAutoDesc4.Text = EPolicy.LookupTables.LookupTables.GetDescription("VehicleMake", AC.VehicleMake.ToString()) + " / " +
                 EPolicy.LookupTables.LookupTables.GetDescription("VehicleModel", AC.VehicleModel.ToString()) + " / " +
                 EPolicy.LookupTables.LookupTables.GetDescription("VehicleYear", AC.VehicleYear.ToString());

                _VehicleTotal = 0;
                this.TotalPremiumByVehicle(AC);
                TxtPrimaAuto4.Text = _VehicleTotal.ToString("$###,###.00");
            }
            else
            {
                TxtPrimaAuto4.Text = "$0.00";
            }

            TxtPrimaTotalSeccionIII.Text = _taskcontrol.AutoPremium.ToString("$###,###.00");

            //Seccion IV
            TxtPrimaTotalSeccionIV.Text = _taskcontrol.UmbrellaPremium.ToString("$###,###.00");

            //TotalPremium
            TxtPrimaTotalSeccion.Text = _taskcontrol.TotalPremium.ToString("$###,###.00");

            if (_taskcontrol.EnteredBy.Trim() != "")
                lblEnteredBy.Text = "Por: " + _taskcontrol.EnteredBy.Trim();
            else
                lblEnteredBy.Text = "";
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

            if (AC.VehicleRental != 0)
            {
                string test = GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums.VehicleRental, AC);
            }
        }

        private string GetBreakDownByTypeAndAnniversary(EPolicy.Quotes.Enumerators.Premiums Type, EPolicy.Quotes.AutoCover ac)
        {
            EPolicy.Quotes.CoverBreakdown CB = new EPolicy.Quotes.CoverBreakdown();
            CB.Type = (int)Type;
            EPolicy.Quotes.CoverBreakdown CB2 = (EPolicy.Quotes.CoverBreakdown) ac.Breakdown[ac.Breakdown.IndexOf(CB)];

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
