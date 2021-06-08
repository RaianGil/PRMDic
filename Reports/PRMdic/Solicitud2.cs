using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy;
using EPolicy.TaskControl;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for Solicitud2.
    /// </summary>
    public partial class Solicitud2 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Application _taskcontrol;

        public Solicitud2(EPolicy.TaskControl.Application taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void Solicitud2_ReportStart(object sender, EventArgs e)
        {
            txtLastName.Text = _taskcontrol.Customer.LastName1.Trim();
            //Customer and Postal Address
            txtName.Text = _taskcontrol.Customer.FirstName.Trim() + " " + _taskcontrol.Customer.Initial.Trim() + " " +
            _taskcontrol.Customer.LastName1.Trim() + " " + _taskcontrol.Customer.LastName2.Trim();

            txtDateBirth.Text = _taskcontrol.Customer.Birthday;
            txtPlaceofBirth.Text = _taskcontrol.Customer.Description;
            txtSocSec.Text = _taskcontrol.Customer.SocialSecurity;

            if (_taskcontrol.Customer.Sex == "F")
            {
                ChkFemale.Checked = true;
                chkMale.Checked = false;
            }
            else
            {
                ChkFemale.Checked = false;
                chkMale.Checked = true;
            }

            txtOfficeAdds1.Text = _taskcontrol.Customer.Address1.ToString().Trim() + " " +
            _taskcontrol.Customer.Address2.ToString().Trim() + " " +
            _taskcontrol.Customer.City.ToString().Trim() + " " +
            _taskcontrol.Customer.State.ToString() + ", " + _taskcontrol.Customer.ZipCode.ToString().Trim();

            txtOfficePhone.Text = _taskcontrol.Customer.JobPhone;
            TxtHomePhone.Text = _taskcontrol.Customer.HomePhone;
            txtOfficeFax.Text = _taskcontrol.Customer.Cellular;
            txtEmail.Text = _taskcontrol.Customer.Email;

            txtCarrier1.Text = _taskcontrol.PriCarierName1;
            txtCarrier2.Text = _taskcontrol.PriCarierName2;
            txtCarrier3.Text = _taskcontrol.PriCarierName3;

            txtPolEffective1.Text = _taskcontrol.PriPolEffecDate1;
            txtPolEffective2.Text = _taskcontrol.PriPolEffecDate2;
            txtPolEffective3.Text = _taskcontrol.PriPolEffecDate3;

            txtLimits1.Text = _taskcontrol.PriPolLimits1;
            txtLimits2.Text = _taskcontrol.PriPolLimits2;
            txtLimits3.Text = _taskcontrol.PriPolLimits3;

            txtClaim1.Text = _taskcontrol.PriClaims1;
            txtClaim2.Text = _taskcontrol.PriClaims2;
            txtClaim3.Text = _taskcontrol.PriClaims3;

            txtExcess1.Text = _taskcontrol.ExcCarierName1;
            txtExcess2.Text = _taskcontrol.ExcCarierName2;
            txtExcess3.Text = _taskcontrol.ExcCarierName3;


            txtExcessPolicy1.Text = _taskcontrol.ExcPolEffecDate1;
            txtExcessPolicy2.Text = _taskcontrol.ExcPolEffecDate2;
            txtExcessPolicy3.Text = _taskcontrol.ExcPolEffecDate3;

            txtExcessLimit1.Text = _taskcontrol.ExcPolLimits1;
            txtExcessLimit2.Text = _taskcontrol.ExcPolLimits2;
            txtExcessLimit3.Text = _taskcontrol.ExcPolLimits3;

            txtExcessClaim1.Text = _taskcontrol.ExcClaims1;
            txtExcessClaim2.Text = _taskcontrol.ExcClaims2;
            txtExcessClaim3.Text = _taskcontrol.ExcClaims3;

            if (_taskcontrol.McaInsuranceCia)
            {
                chkYes.Checked = true;
                chkNo.Checked = false;
            }
            else
            {
                chkYes.Checked = false;
                chkNo.Checked = true;
            }
        }
    }
}
