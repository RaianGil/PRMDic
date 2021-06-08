using System;
using System.Configuration;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.TaskControl;
using EPolicy.Quotes;
using EPolicy.LookupTables;
using EPolicy;

namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for rptSolicitudQuoteAuto.
    /// </summary>
    public partial class rptSolicitudQuoteAuto : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.Collections.ArrayList _autoCovers = null;
        private EPolicy.TaskControl.QuoteAuto _policy;

        public rptSolicitudQuoteAuto(EPolicy.TaskControl.QuoteAuto AutoQuote, string UserName)
        {
            InitializeComponent();
            _policy = AutoQuote;
            this._autoCovers = AutoQuote.AutoCovers;
            this.FillFields(AutoQuote, UserName);
        }

        private void detail_Format(object sender, EventArgs e)
        {
            rptSolicitudQuoteAutoCover rptAC = new rptSolicitudQuoteAutoCover(this._autoCovers, _policy);
            this.subCovers.Report = rptAC;
        }

        private void FillFields(EPolicy.TaskControl.QuoteAuto AutoQuote,
string UserName)
        {
            TaskControl tc = new TaskControl();


            EPolicy.Quotes.AutoDriver mainProspectDriver =
                (EPolicy.Quotes.AutoDriver)AutoQuote.Drivers[0];
            DateTime birthDate =
                DateTime.Parse(mainProspectDriver.BirthDate.Trim());
            decimal charges = 0.0m;
            decimal totalPremium = 0.0m;

            this.lblDate.Text = DateTime.Today.ToShortDateString();
            this.lblTime.Text = DateTime.Now.ToShortTimeString();
            //this.txtPageNumber.Text = ;
            this.txtQuotation.Text = AutoQuote.Policy.PolicyNo.Trim() + " " + AutoQuote.Policy.PolicyType.Trim() + " " + AutoQuote.Policy.Certificate.Trim();
            //this.txtPreparedBy.Text = AutoQuote.EnteredBy.Trim();	//UserName.Trim();

            /*this.txtName.Text = AutoQuote.Prospect.FirstName.Trim() +
                " " + AutoQuote.Prospect.LastName1.Trim() + 
                " " + AutoQuote.Prospect.LastName2.Trim();
            this.txtBirthdate.Text = birthDate.ToShortDateString();
            this.txtAge.Text = 
                Customer.Customer.GetAge(birthDate).ToString();
            this.txtMaritalStatus.Text = 
                LookupTables.GetDescription("MaritalStatus",
                mainProspectDriver.MaritalStatus.ToString());
            this.txtGender.Text = 
                LookupTables.GetDescription("Gender",
                mainProspectDriver.Gender.ToString());*/
            this.txtPosicion.Text = LookupTables.GetDescription("FBPosition", AutoQuote.Policy.FBPositionID.ToString());

            if (AutoQuote.Policy.FBSubsidiaryID == 5)
            {
                this.txtSucursal.Text = LookupTables.GetDescription("FBBranches", AutoQuote.Policy.FBBranchesID.ToString());
                this.txtRegion.Text = LookupTables.GetFBRegionDescription(AutoQuote.Policy.FBBranchesID.ToString());
            }
            else
            {
                this.txtSucursal.Text = "";
                this.txtRegion.Text = "";
            }

            this.txtEffectiveDate.Text =
                AutoQuote.EffectiveDate.Trim();
            this.txtTerm.Text = AutoQuote.Term.ToString() + " meses";
            this.txtExpirationDate.Text = AutoQuote.ExpirationDate.Trim();
            //this.txtEntryDate.Text = AutoQuote.EntryDate.ToShortDateString();

            this.txtCollision.Text = String.Format("{0:c}",
                this.GetPremiumTotal(AutoQuote,
                (int)EPolicy.Quotes.Enumerators.Premiums.Collision));
            this.txtComprehensive.Text =
                String.Format("{0:c}", this.GetPremiumTotal(AutoQuote,
                (int)EPolicy.Quotes.Enumerators.Premiums.Comprehensive));
            this.txtBodilyInjury.Text = String.Format("{0:c}",
                this.GetPremiumTotal(AutoQuote,
                (int)EPolicy.Quotes.Enumerators.Premiums.BodilyInjury));
            this.txtPropertyDmg.Text = String.Format("{0:c}",
                this.GetPremiumTotal(AutoQuote,
                (int)EPolicy.Quotes.Enumerators.Premiums.PropertyDamage));
            this.txtLeaseLoanGap.Text = String.Format("{0:c}",
                this.GetPremiumTotal(AutoQuote,
                (int)EPolicy.Quotes.Enumerators.Premiums.LeaseLoanGap));
            //this.txtPAR.Text = String.Format("{0:c}",
            //   this.GetPremiumTotal(AutoQuote,
            //    (int) EPolicy.Quotes.Enumerators.Premiums.PersonalAccidentRider));
            this.txtAssist.Text = String.Format("{0:c}",
                this.GetPremiumTotal(AutoQuote,
                (int)EPolicy.Quotes.Enumerators.Premiums.Assistance));

            this.txtTowing.Text = String.Format("{0:c}",
                this.GetPremiumTotal(AutoQuote,
                (int)EPolicy.Quotes.Enumerators.Premiums.Towing));
            //this.TxtSeatBelt.Text = String.Format("{0:c}",
            //    this.GetPremiumTotal(AutoQuote,
            //    (int)EPolicy.Quotes.Enumerators.Premiums.SeatBelt));
            this.TxtRental.Text = String.Format("{0:c}",
                this.GetPremiumTotal(AutoQuote,
                (int)EPolicy.Quotes.Enumerators.Premiums.VehicleRental));

            this.txtLeaseLoanGap.Text = String.Format("{0:c}",
                this.GetPremiumTotal(AutoQuote,
                (int)EPolicy.Quotes.Enumerators.Premiums.LeaseLoanGap));

            this.txtPremium.Text =
                String.Format("{0:c}",
                this.GetPremium(AutoQuote));

            charges = this.GetCharges(AutoQuote);
            this.txtCharge.Text = String.Format("{0:c}",
                charges);

            totalPremium = charges + AutoQuote.TotalPremium;

            this.txtTotalPremium.Text = String.Format("{0:c}",
                totalPremium);

            //			this.txtTotalToPay.Text = String.Format("{0:c}", 
            //				totalPremium);
        }

        private decimal GetPremiumTotal(
            EPolicy.TaskControl.QuoteAuto AutoQuote, int Type)
        {
            decimal collTotal = 0.0m;
            EPolicy.Quotes.AutoCover cover = null;
            System.Collections.ArrayList breakdownList = null;
            EPolicy.Quotes.CoverBreakdown breakdown = null;


            for (int i = 0; i < AutoQuote.AutoCovers.Count; i++)
            {
                cover = (EPolicy.Quotes.AutoCover)AutoQuote.AutoCovers[i];
                breakdownList = cover.Breakdown;

                for (int j = 0; j < breakdownList.Count; j++)
                {
                    breakdown = (EPolicy.Quotes.CoverBreakdown)breakdownList[j];
                    if (breakdown.Type == Type)
                    {
                        for (int k = 0; k < breakdown.Breakdown.Count; k++)
                        {
                            collTotal += Math.Round(decimal.Parse(breakdown.Breakdown.GetByIndex(k).ToString()), 0);
                        }
                    }
                }
            }
            return collTotal;
        }

        private decimal GetPremium(EPolicy.TaskControl.QuoteAuto AutoQuote)
        {
            decimal premium = 0.0m;
            EPolicy.Quotes.AutoCover cover = null;

            for (int i = 0; i < AutoQuote.AutoCovers.Count; i++)
            {
                cover = (EPolicy.Quotes.AutoCover)AutoQuote.AutoCovers[i];
                premium += cover.TotalAmount;
            }
            return premium;
        }

        private decimal GetCharges(EPolicy.TaskControl.QuoteAuto AutoQuote)
        {
            decimal charges = 0.0m;
            EPolicy.Quotes.AutoCover cover = null;

            for (int i = 0; i < AutoQuote.AutoCovers.Count; i++)
            {
                cover = (EPolicy.Quotes.AutoCover)AutoQuote.AutoCovers[i];
                charges += cover.Charge;
            }
            return charges;
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
            if (_policy.InsuranceCompany != "000")
            {
                //Insurance Company
                EPolicy.LookupTables.InsuranceCompany ins = new InsuranceCompany();
                ins = ins.GetInsuranceCompany(_policy.InsuranceCompany);
            }
            else
            {
                //this.LblQuoteBy.Visible = false;
            }
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {

        }

    }
}
