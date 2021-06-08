using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.Customer;
using EPolicy.LookupTables;
using EPolicy.TaskControl;

namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for AutoGapCertificate.
    /// </summary>
    public partial class AutoGapCertificate : DataDynamics.ActiveReports.ActiveReport3
    {
        private string _CopyValue;
        //private Label lblAutoLoan;
        //private Label lblLeasing;
        //private Picture Picture1;
        private EPolicy.TaskControl.Policies _taskcontrol;

        public AutoGapCertificate(EPolicy.TaskControl.Policies taskcontrol, string CopyValue)
        {
            _taskcontrol = taskcontrol;
            _CopyValue = CopyValue;
            
            InitializeComponent();
        }

        private void AutoGapCertificate_ReportStart(object sender, EventArgs e)
        {
            EPolicy.LookupTables.MasterPolicy mp = new EPolicy.LookupTables.MasterPolicy();
            mp = mp.GetMasterPolicy(_taskcontrol.MasterPolicyID);
            TxtMasterPolicy.Text = _taskcontrol.PolicyType.Trim().ToUpper() + "-" + mp.pol_number.Trim();

            TxtPolicyNo.Text =  _taskcontrol.Certificate.Trim().ToUpper();
            TxtTotalPremium.Text = _taskcontrol.TotalPremium.ToString("$##,###.00");
            TxtEffectiveDate.Text = _taskcontrol.EffectiveDate;
            TxtExpirationDate.Text = _taskcontrol.ExpirationDate;
            TxtTerm.Text = _taskcontrol.Term.ToString();
            TxtCustomerName.Text = _taskcontrol.Customer.FirstName.Trim().ToUpper() + " " + _taskcontrol.Customer.Initial.Trim().ToUpper() + " " + _taskcontrol.Customer.LastName1.Trim().ToUpper() + " " + _taskcontrol.Customer.LastName2.Trim().ToUpper();
            TxtSocialSecurity.Text = _taskcontrol.Customer.SocialSecurity;
            TxtAdds1.Text = _taskcontrol.Customer.Address1.Trim().ToUpper() + " " + _taskcontrol.Customer.Address2.Trim().ToUpper();
            TxtCity.Text = _taskcontrol.Customer.City.Trim().ToUpper();
            TxtState.Text = _taskcontrol.Customer.State.Trim().ToUpper();
            TxtZipCode.Text = _taskcontrol.Customer.ZipCode;
            TxtTelefono.Text = _taskcontrol.Customer.HomePhone.Trim();

            EPolicy.LookupTables.Bank bank = new EPolicy.LookupTables.Bank();
            bank = bank.GetBank(_taskcontrol.Bank);

            TxtBankName.Text = bank.BankDesc.Trim().ToUpper();
            TxtBankAds1.Text = bank.Address1.Trim().ToUpper() + " " + bank.Address2.Trim().ToUpper();
            TxtBankCity.Text = bank.City.Trim().ToUpper();
            TxtBankState.Text = bank.State.Trim().ToUpper();
            TxtBankZip.Text = bank.ZipCode.Trim();
            TxtBankTel.Text = bank.Phone.Trim();
            TxtPurchaserDate.Text = _taskcontrol.PurchaseDate.Trim();
            TxtTerm2.Text = _taskcontrol.Term.ToString();
            TxtFinanceAmt.Text = _taskcontrol.FinanceAmt.ToString("$###,###.00");

            TxtCost.Text = _taskcontrol.Cost.ToString("$###,###.00");
            TxtVehicleYear.Text = EPolicy.LookupTables.LookupTables.GetDescription("VehicleYear", _taskcontrol.VehicleYearID.ToString()).Trim();
            TxtVehicleMake.Text = EPolicy.LookupTables.LookupTables.GetDescription("VehicleMake", _taskcontrol.VehicleMakeID.ToString());
            TxtVehicleModel.Text = EPolicy.LookupTables.LookupTables.GetDescription("VehicleModel", _taskcontrol.VehicleModelID.ToString());
            TxtVin.Text = _taskcontrol.VIN.Trim().ToUpper();
            TxtMilleage.Text = _taskcontrol.Milleages.ToString().Trim().ToUpper();

            EPolicy.LookupTables.CompanyDealer cd = new EPolicy.LookupTables.CompanyDealer();
            cd = cd.GetCompanyDealer(_taskcontrol.CompanyDealer);

            TxtDealerNAme.Text = cd.CompanyDealerDesc.Trim().ToUpper();
            TxtDealerID.Text = cd.CompanyDealerID.Trim().ToUpper();

            TxtInsCompany.Text = LookupTables.GetDescription("InsuranceCompany2", _taskcontrol.InsuranceCompanyPrimaria.Trim());
            TxtCompanyPolicyNo.Text = _taskcontrol.NumeroPolizaPrimaria.Trim();

            TxtEntryDate.Text = DateTime.Now.ToShortDateString();

            EPolicy.LookupTables.Agent ag = new EPolicy.LookupTables.Agent();
            ag = ag.GetAgent(_taskcontrol.Agent);
            TxtAgentID.Text = ag.CarsID.Trim();

            if (_taskcontrol.PrestamoArrenda)
            {
                lblAutoLoan.Visible = true;
                lblLeasing.Visible = false;
            }
            else
            {
                lblLeasing.Visible = true;
                lblAutoLoan.Visible = false;
            }

            TxtCopyName.Text = "Copia: "+_CopyValue;
        }
    }
}
