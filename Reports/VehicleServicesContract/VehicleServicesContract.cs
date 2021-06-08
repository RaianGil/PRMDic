using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.Customer;
using EPolicy.LookupTables;
using EPolicy.TaskControl;

namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for VehicleServicesContract.
    /// </summary>
    public partial class VehicleServicesContract : DataDynamics.ActiveReports.ActiveReport3
    {
        private string _CopyValue;
        private EPolicy.TaskControl.Policies _taskcontrol;

        public VehicleServicesContract(EPolicy.TaskControl.Policies taskcontrol, string CopyValue)
        {
            _taskcontrol = taskcontrol;
            _CopyValue = CopyValue;
            InitializeComponent();
        }

        private void VehicleServicesContract_DataInitialize(object sender, EventArgs e)
        {
            
        }

        private void VehicleServicesContract_ReportStart(object sender, EventArgs e)
        {
            TxtContractNo.Text = _taskcontrol.PolicyNo.Trim().ToUpper();
            TxtVIN.Text = _taskcontrol.VIN.Trim();
            TxtYear.Text = EPolicy.LookupTables.LookupTables.GetDescription("VehicleYear", _taskcontrol.VehicleYearID.ToString()).Trim();
            TxtMake.Text = EPolicy.LookupTables.LookupTables.GetDescriptionToVSCVehicleMake("VSCVehicleMake", _taskcontrol.VehicleMakeID.ToString())+" / "+
                EPolicy.LookupTables.LookupTables.GetDescriptionToVSCVehicleModel("VSCVehicleModel", _taskcontrol.VehicleModelID.ToString());
            TxtMilleage.Text = _taskcontrol.Milleages.ToString();            
            TxtVehicleClass.Text = _taskcontrol.VehicleClass.ToString();

            if (_taskcontrol.VehicleCode.Trim() != "")
            {
                if(_taskcontrol.VehicleCode.Trim().Length >=1)
                    TxtVehicleCode1.Text = _taskcontrol.VehicleCode.ToString().Trim().Substring(0,1);
                if (_taskcontrol.VehicleCode.Trim().Length >= 2)
                    TxtVehicleCode2.Text = _taskcontrol.VehicleCode.ToString().Trim().Substring(1, 1);
                if (_taskcontrol.VehicleCode.Trim().Length >= 3)
                    TxtVehicleCode3.Text = _taskcontrol.VehicleCode.ToString().Trim().Substring(2, 1);
                if (_taskcontrol.VehicleCode.Trim().Length >= 4)
                    TxtVehicleCode4.Text = _taskcontrol.VehicleCode.ToString().Trim().Substring(3, 1);
                if (_taskcontrol.VehicleCode.Trim().Length == 5)
                    TxtVehicleCode5.Text = _taskcontrol.VehicleCode.ToString().Trim().Substring(4, 1);
            }
            else
            {
                TxtVehicleCode1.Text = "";
                TxtVehicleCode2.Text = "";
                TxtVehicleCode3.Text = "";
                TxtVehicleCode4.Text = "";
                TxtVehicleCode5.Text = "";
            }

            if (_taskcontrol.Diesel)
                TxtDiesel.Text = "X";
            if (_taskcontrol.WD4)
                TxtWD4.Text = "X";
            if (_taskcontrol.Turbo)
                TxtTurbo.Text = "X";

            TxtCustomerName.Text = _taskcontrol.Customer.FirstName.Trim().ToUpper() + " " + _taskcontrol.Customer.LastName1.Trim().ToUpper() + " " + _taskcontrol.Customer.LastName2.Trim().ToUpper();
            TxtAdds1.Text = _taskcontrol.Customer.Address1.Trim().ToUpper() + " " + _taskcontrol.Customer.Address2.Trim().ToUpper();
            TxtCity.Text = _taskcontrol.Customer.City.Trim().ToUpper();
            TxtState.Text = _taskcontrol.Customer.State.Trim().ToUpper();
            TxtZipCode.Text = _taskcontrol.Customer.ZipCode;

            if (_taskcontrol.Customer.HomePhone.Trim() != "")
            {
                TxtTel1.Text = _taskcontrol.Customer.HomePhone.Trim().Substring(1, 3);
                TxtTelefono.Text = _taskcontrol.Customer.HomePhone.Trim().Substring(6,8);
            }

            if (_taskcontrol.Customer.JobPhone.Trim() != "")
            {
                TxtTel2.Text = _taskcontrol.Customer.JobPhone.Trim().Substring(1, 3);
                TxtWokPhone.Text = _taskcontrol.Customer.JobPhone.Trim().Substring(6, 8);
            }

            TxtTerm.Text = _taskcontrol.Term.ToString();
            //TxtMonth.Text = _taskcontrol.Term.ToString();
            TxtMiles.Text = _taskcontrol.Miles.ToString("#,##0");

            if(_taskcontrol.CoveragePlan == 1)
                TxtPowerTrain.Text = "X";
            if (_taskcontrol.CoveragePlan == 2)
                TxtSilver.Text = "X";
            if (_taskcontrol.CoveragePlan == 3)
                TxtGold.Text = "X";
            if (_taskcontrol.CoveragePlan == 4)
                TxtPlatinum.Text = "X";
            
            if(_taskcontrol.CommercialUse)
                TxtCommercialUse.Text = "X";

            if(_taskcontrol.Charge != 0)
                TxtDeductible.Text = "X";
            else
                TxtDeductible.Text = "";

            TxtTotalPremium.Text = _taskcontrol.TotalPremium.ToString("$##,###.00");

            EPolicy.LookupTables.CompanyDealer cd = new EPolicy.LookupTables.CompanyDealer();
            cd = cd.GetCompanyDealer(_taskcontrol.CompanyDealer);
            TxtDealerDesc.Text = cd.CompanyDealerDesc.Trim().ToUpper();
            TxtDealerID.Text = cd.CompanyDealerID.Trim().ToUpper();

            TxtDealerAdds1.Text = cd.dea_add1.Trim().ToUpper() + " " + cd.dea_add2.Trim().ToUpper();
            TxtDealerCity.Text = cd.dea_city.Trim().ToUpper();
            TxtDealerState.Text = cd.dea_state.Trim().ToUpper();
            TxtDealerZipCode.Text = cd.dea_zip.Trim().ToUpper();

            EPolicy.LookupTables.Bank bank = new EPolicy.LookupTables.Bank();
            bank = bank.GetBank(_taskcontrol.Bank);

            TxtBankDesc.Text = bank.BankDesc.Trim().ToUpper();
            TxtBankAdds1.Text = bank.Address1.Trim().ToUpper() + " " + bank.Address2.Trim().ToUpper() + " " + bank.City.Trim().ToUpper() + " " + bank.State.Trim().ToUpper() + " " + bank.ZipCode.Trim(); ;

            TxtEffectiveDate.Text = _taskcontrol.EffectiveDate;
 
            TxtCopyName.Text = _CopyValue;
        }

        private void detail_Format(object sender, EventArgs e)
        {

        }
    }
}
