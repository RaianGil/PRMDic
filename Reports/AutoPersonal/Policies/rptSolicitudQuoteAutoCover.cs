using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.XmlCooker;
using System.Data;
using Baldrich.DBRequest;
using EPolicy;
using EPolicy.TaskControl;
using EPolicy.LookupTables;
using EPolicy.Quotes;
using EPolicy.Customer;

namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for rptSolicitudQuoteAutoCover.
    /// </summary>
    public partial class rptSolicitudQuoteAutoCover : DataDynamics.ActiveReports.ActiveReport3
    {
        private int _iRow = 0;
        private System.Collections.ArrayList _autoCover = null;
        private EPolicy.Quotes.AssignedDriver _primaryAssignedDriver = null;
        private EPolicy.Quotes.CoverBreakdown _breakdown = null;
        private EPolicy.TaskControl.QuoteAuto _policy;

        public rptSolicitudQuoteAutoCover(System.Collections.ArrayList AutoCover, EPolicy.TaskControl.QuoteAuto taskControl)
        {
            _policy = taskControl;
            this._iRow = 0;
            this._autoCover = AutoCover;
            InitializeComponent();
        }

        private int GetPrimaryAssignedDriverIndex(EPolicy.Quotes.AutoCover AutoCover)
        {
            EPolicy.Quotes.AssignedDriver driver = null;

            for (int i = 0; i < AutoCover.AssignedDrivers.Count; i++)
            {
                driver = (EPolicy.Quotes.AssignedDriver)AutoCover.AssignedDrivers[i];
                //Se comento ya que solo va haber un solo driver asignado a cada vehiculo
                //if(driver.PrincipalOperator)  
                return i;
            }
            return -1;
        }

        private string GetFirstPeriodIsoCode(EPolicy.Quotes.AutoCover AutoCover)
        {
            EPolicy.Quotes.CoverBreakdown srch = new
                EPolicy.Quotes.CoverBreakdown();
            srch.Type = (int)EPolicy.Quotes.Enumerators.Premiums.IsoCode;
            EPolicy.Quotes.CoverBreakdown ISOC = (EPolicy.Quotes.CoverBreakdown)
                AutoCover.Breakdown[AutoCover.Breakdown.IndexOf(srch)];
            return (string)ISOC.Breakdown[0];
        }

        private void rptSolicitudQuoteAutoCover_FetchData(object sender, FetchEventArgs eArgs)
        {
            if (this._iRow >= this._autoCover.Count)
            {
                eArgs.EOF = true;
                return;
            }

            //Owner
            EPolicy.Quotes.AutoDriver AD;
            for (int i = 0; i < _policy.Drivers.Count; i++)
            {
                AD = (EPolicy.Quotes.AutoDriver)_policy.Drivers[i];

                if (_policy.Prospect.ProspectID == AD.ProspectID)
                {
                    LblOwner.Text = AD.FirstName.Trim() + " " +
                        AD.LastName1.Trim() + " " + AD.LastName2.Trim();
                }
            }

            EPolicy.Quotes.AutoCover autoCover = (EPolicy.Quotes.AutoCover)this._autoCover[this._iRow];

            int mcount = this._iRow + 1;
            this.LblVehicleCount.Text = mcount.ToString().Trim();

            this._primaryAssignedDriver = (EPolicy.Quotes.AssignedDriver)
                autoCover.AssignedDrivers[this.GetPrimaryAssignedDriverIndex(autoCover)];
            this._breakdown = (EPolicy.Quotes.CoverBreakdown)autoCover.Breakdown[0];

            this.lblMake.Text = LookupTables.GetDescription("VehicleMake",
                autoCover.VehicleMake.ToString());
            this.lblModel.Text = LookupTables.GetDescription("VehicleModel",
                autoCover.VehicleModel.ToString());
            this.lblYear.Text = LookupTables.GetDescription("VehicleYear",
                autoCover.VehicleYear.ToString());

            this.txtName.Text = this._primaryAssignedDriver.AutoDriver.FirstName.Trim() +
                " " + this._primaryAssignedDriver.AutoDriver.LastName1.Trim() +
                " " + this._primaryAssignedDriver.AutoDriver.LastName2.Trim();
            this.txtBirthdate.Text = this._primaryAssignedDriver.AutoDriver.BirthDate.Trim();
            this.txtMaritalStatus.Text = LookupTables.GetDescription("MaritalStatus",
                _primaryAssignedDriver.AutoDriver.MaritalStatus.ToString());
            this.txtGender.Text = LookupTables.GetDescription("Gender",
                _primaryAssignedDriver.AutoDriver.Gender.ToString());

            this.txtVIN.Text = autoCover.VIN.Trim() == string.Empty ?
                "Not entered." : autoCover.VIN.Trim();
            //this.txtPlate.Text = autoCover.Plate.Trim();
            this.txtVehicleAge.Text = autoCover.VehicleAge.ToString() == "0" ? "New" :
                autoCover.VehicleAge.ToString() + " years";
            this.txtNewUsed.Text = autoCover.NewUse == 1 ? "Used" : "New";
            this.txtCost.Text = String.Format("{0:c}", autoCover.Cost);

            if (autoCover.ActualValue != 0)
            {
                //this.txtActualValue.Text = String.Format("{0:c}", autoCover.ActualValue);
                this.txtActualValue.Text = String.Format("{0:c}", autoCover.ActualValue);
            }
            else
            {
                this.txtActualValue.Text = "N/A";
            }

            /*this.txtHome.Text = 
                this.GetDescFromID(this._autoCover[this._iRow].HomeCity,
                (int)Tables.CITY);
            this.txtWork.Text = 
                this.GetDescFromID(this._autoCover[this._iRow].WorkCity,
                (int)Tables.CITY);*/
            this.txtClass.Text = this.GetVehicleClassDescFromID(autoCover.VehicleClass);
            this.txtTerritory.Text =
                this.GetDescFromID(autoCover.Territory,
                (int)Tables.TERRITORY);
            this.txtAlarmType.Text =
                this.GetDescFromID(autoCover.AlarmType,
                (int)Tables.ALARM_TYPE);
            this.txtDepreciation1st.Text =
                autoCover.Depreciation1stYear.ToString() == "0" ?
                "N/A" : autoCover.Depreciation1stYear.ToString() + "%";
            /*this.txtDepreciationOther.Text = 
                this._autoCover[this._iRow].DepreciationAllYear.ToString();*/
            this.txtMedicalLimit.Text =
                this.GetDescFromID(
                autoCover.MedicalLimit,
                (int)Tables.MEDICAL_LIMIT) == string.Empty ? "0" :
                this.GetDescFromID(autoCover.MedicalLimit,
                (int)Tables.MEDICAL_LIMIT).Trim();
            this.txtAssistance.Text = String.Format("{0:c}", autoCover.AssistancePremium);
            this.txtTowing.Text = String.Format("{0:c}", autoCover.TowingPremium);
            this.TxtVehicleRental.Text = String.Format("{0:c}", autoCover.VehicleRental);

            this.txtLeaseLoanGap.Text = this.GetDescFromID(autoCover.LeaseLoanGapId,
                (int)Tables.LEASE_LOAN_GAP) == string.Empty ? "No" :
                "Yes";

            //			this.txtLeaseLoanGap.Text = this.GetDescFromID(autoCover.LeaseLoanGapId,
            //				(int)Tables.LEASE_LOAN_GAP) == string.Empty ? "0%" : 
            //				this.GetDescFromID(autoCover.LeaseLoanGapId,(int)Tables.LEASE_LOAN_GAP) + "%";
            //this.txtSeatbelt.Text = String.Format("{0:c}", autoCover.SeatBelt);
            //this.txtPAR.Text = String.Format("{0:c}", autoCover.PersonalAccidentRider);
            this.txtCollision.Text = this.GetDescFromID(
                autoCover.CollisionDeductible,
                (int)Tables.COLLISION_DEDUCTIBLE) == string.Empty ?
                "0" : this.GetDescFromID(
                autoCover.CollisionDeductible,
                (int)Tables.COLLISION_DEDUCTIBLE);
            this.txtComprehensive.Text = this.GetDescFromID(
                autoCover.ComprehensiveDeductible,
                (int)Tables.COMPREHENSIVE_DEDUCTIBLE) == string.Empty ?
                "0" : this.GetDescFromID(
                autoCover.ComprehensiveDeductible,
                (int)Tables.COMPREHENSIVE_DEDUCTIBLE);
            //this.txtDiscountCollComp.Text =
            //    autoCover.DiscountCompColl.ToString();
            this.txtBiLimit.Text = this.GetDescFromID(
                autoCover.BodilyInjuryLimit,
                (int)Tables.BODILY_INJURY_LIMIT) == string.Empty ?
                "0" : this.GetDescFromID(
                autoCover.BodilyInjuryLimit,
                (int)Tables.BODILY_INJURY_LIMIT);
            this.txtPdLimit.Text = this.GetDescFromID(
                autoCover.PropertyDamageLimit,
                (int)Tables.PROPERTY_DAMAGE_LIMIT) == string.Empty ?
                "0" : this.GetDescFromID(
                autoCover.PropertyDamageLimit,
                (int)Tables.PROPERTY_DAMAGE_LIMIT);
            this.txtCslLimit.Text =
                this.GetDescFromID(
                autoCover.CombinedSingleLimit,
                (int)Tables.COMBINED_SINGLE_LIMIT) == string.Empty ?
                "0" : this.GetDescFromID(
                autoCover.CombinedSingleLimit,
                (int)Tables.COMBINED_SINGLE_LIMIT);
            //this.txtDiscountBiPd.Text =
            //    autoCover.DiscountBIPD.ToString();
            /*this.txtPrimaryDriver.Text = 
                this.GetPrimaryDriverFullName(this._autoCover[this._iRow]);*/
            this.txtPremium.Text = String.Format("{0:c}",
                autoCover.TotalAmount);
            this.txtISOcode.Text =
                this.GetFirstPeriodIsoCode(autoCover);
            this.txtTotalComp.Text = String.Format("{0:c}",
                autoCover.ComprehensivePremium());
            this.txtTotalColl.Text = String.Format("{0:c}",
                autoCover.CollisionPremium());
            this.txtTotalBI.Text = String.Format("{0:c}",
                autoCover.BodilyInjuryPremium());
            this.txtTotalPD.Text = String.Format("{0:c}",
                autoCover.PropertyDamagePremium());
            this.txtTotalCSL.Text = String.Format("{0:c}",
                autoCover.CombinedSinglePremium());
            this.txtTotalLeaseLoanGap.Text = String.Format("{0:c}",
                autoCover.LeaseLoanGapPremium());

            this.txtAge.Text =
                this._primaryAssignedDriver.AutoDriver.BirthDate ==
                string.Empty ?
                string.Empty :
                Customer.GetAge(
                DateTime.Parse(
                this._primaryAssignedDriver.AutoDriver.BirthDate)).ToString();

            if (this._primaryAssignedDriver.OnlyOperator)
            {
                //this.txtOnlyOperator.Text = this._primaryAssignedDriver.OnlyOperator.ToString();
                this.txtOnlyOperator.Text = "Yes";
            }
            else
            {
                this.txtOnlyOperator.Text = "No";
            }

            if (this._primaryAssignedDriver.PrincipalOperator)
            {
                //this.txtPrincipalOperator.Text = this._primaryAssignedDriver.PrincipalOperator.ToString();
                this.txtPrincipalOperator.Text = "Yes";
            }
            else
            {
                this.txtPrincipalOperator.Text = "No";
            }

            this.txtYear.Text =
                autoCover.VehicleYear == 0 ? string.Empty :
                LookupTables.GetDescription("VehicleYear", autoCover.VehicleYear.ToString());
            this.txtPhone.Text =
                this._primaryAssignedDriver.AutoDriver.HomePhone.ToString();

            this._iRow++;
            eArgs.EOF = false;
        }

        private enum Tables
        {
            CITY, TERRITORY, ALARM_TYPE,
            MEDICAL_LIMIT, LEASE_LOAN_GAP, COLLISION_DEDUCTIBLE,
            COMPREHENSIVE_DEDUCTIBLE, BODILY_INJURY_LIMIT,
            PROPERTY_DAMAGE_LIMIT, COMBINED_SINGLE_LIMIT, VEHICLECLASS
        };

        private string GetPrimaryDriverFullName(EPolicy.Quotes.AutoCover AutoCover)
        {
            foreach (EPolicy.Quotes.AssignedDriver driver in
                AutoCover.AssignedDrivers)
            {
                if (driver.PrincipalOperator)
                {
                    return driver.AutoDriver.FirstName.Trim() + " " +
                        driver.AutoDriver.LastName1.Trim() + " " +
                        driver.AutoDriver.LastName2.Trim();
                }
            }
            return string.Empty;
        }

        private string GetDescFromID(int ID, int Table)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];
            string sProc = string.Empty;
            Baldrich.DBRequest.DBRequest dbReq = new Baldrich.DBRequest.DBRequest();

            DbRequestXmlCooker.AttachCookItem("ID", SqlDbType.Int,
                0, ID.ToString(), ref cookItems);

            switch (Table)
            {
                case (int)Tables.CITY:
                    sProc = "GetCityByID";
                    break;
                case (int)Tables.TERRITORY:
                    sProc = "GetTerritoryByID";
                    break;
                case (int)Tables.ALARM_TYPE:
                    sProc = "GetAlarmTypeByID";
                    break;
                case (int)Tables.MEDICAL_LIMIT:
                    sProc = "GetMedicalLimitByID";
                    break;
                case (int)Tables.LEASE_LOAN_GAP:
                    sProc = "GetLeaseLoanGapByID";
                    break;
                case (int)Tables.COLLISION_DEDUCTIBLE:
                    sProc = "GetCollisionDeductibleByID";
                    break;
                case (int)Tables.COMPREHENSIVE_DEDUCTIBLE:
                    sProc = "GetComprehensiveDeductibleByID";
                    break;
                case (int)Tables.BODILY_INJURY_LIMIT:
                    sProc = "GetBodilyInjuryLimitByID";
                    break;
                case (int)Tables.PROPERTY_DAMAGE_LIMIT:
                    sProc = "GetPropertyDamageLimitByID";
                    break;
                case (int)Tables.COMBINED_SINGLE_LIMIT:
                    sProc = "GetCombinedSingleLimitByID";
                    break;
                default:
                    return string.Empty;
            }

            DataTable dt = dbReq.GetQuery(sProc,
                DbRequestXmlCooker.Cook(cookItems));

            if (dt.Rows != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            return string.Empty;
        }

        private string GetVehicleClassDescFromID(string ID)
        {
            DbRequestXmlCookRequestItem[] cookItems = new DbRequestXmlCookRequestItem[1];
            string sProc = "GetVehicleClassByVehicleClassID";
            Baldrich.DBRequest.DBRequest dbReq = new Baldrich.DBRequest.DBRequest();

            DbRequestXmlCooker.AttachCookItem("ID", SqlDbType.Char,
                2, ID.ToString(), ref cookItems);

            DataTable dt = dbReq.GetQuery(sProc,
                DbRequestXmlCooker.Cook(cookItems));

            if (dt.Rows != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            return string.Empty;
        }
    }
}
