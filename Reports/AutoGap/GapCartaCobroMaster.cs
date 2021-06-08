using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for GapCartaCobroMaster.
    /// </summary>
    public partial class GapCartaCobroMaster : DataDynamics.ActiveReports.ActiveReport3
    {
        private string _CopyValue;
        private EPolicy.TaskControl.Policies _taskcontrol;

        public GapCartaCobroMaster(EPolicy.TaskControl.Policies taskcontrol, string CopyValue)
        {
            _taskcontrol = taskcontrol;
            _CopyValue = CopyValue;

            InitializeComponent();
        }

        private void GapCartaCobroMaster_ReportStart(object sender, EventArgs e)
        {
            TxtEfectiveDate.Text = _taskcontrol.EffectiveDate;

            EPolicy.LookupTables.Bank bank = new EPolicy.LookupTables.Bank();
            bank = bank.GetBank(_taskcontrol.Bank);

            TxtBankName.Text = bank.BankDesc.Trim().ToUpper();
            TxtBankAdds1.Text = bank.Address1.Trim().ToUpper();
            TxtBankAdds2.Text = bank.Address2.Trim().ToUpper();
            TxtBankAdds3.Text = bank.City.Trim().ToUpper() + " " + bank.State.Trim().ToUpper() + " " + bank.ZipCode.Trim();
            TxtNombreAsegurado.Text = _taskcontrol.Customer.FirstName.Trim().ToUpper() + " " + _taskcontrol.Customer.LastName1.Trim().ToUpper() + " " + _taskcontrol.Customer.LastName2.Trim().ToUpper();
            TxtPolicyNo.Text = _taskcontrol.PolicyType.Trim().ToUpper() + " " + _taskcontrol.PolicyNo.Trim();
            TxtCertificate.Text = _taskcontrol.Certificate.Trim().ToUpper().Trim();
            TxtEfective.Text = _taskcontrol.EffectiveDate + "  Hasta: " + _taskcontrol.ExpirationDate;
            TxtVehicleYear.Text = EPolicy.LookupTables.LookupTables.GetDescription("VehicleYear", _taskcontrol.VehicleYearID.ToString()).Trim();
            TxtMakeModel.Text = EPolicy.LookupTables.LookupTables.GetDescription("VehicleMake", _taskcontrol.VehicleMakeID.ToString()) + " / " +
                                    EPolicy.LookupTables.LookupTables.GetDescription("VehicleModel", _taskcontrol.VehicleModelID.ToString());
            TxtVIN.Text = _taskcontrol.VIN.Trim().ToUpper();
            TxtTotPremium.Text = _taskcontrol.TotalPremium.ToString("$###,###.00");	
        }
    }
}
