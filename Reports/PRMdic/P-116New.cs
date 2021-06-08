using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for P_116New.
    /// </summary>
    public partial class P_116New : DataDynamics.ActiveReports.ActiveReport3
    {

        private EPolicy.TaskControl.Policy _taskcontrol;

        public P_116New(EPolicy.TaskControl.Policy taskcontrol)
        {
            //
            // Required for Windows Form Designer support
            //
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void P_116_New_ReportStart(object sender, EventArgs e)
        {
            txtPolicyNo.Text = _taskcontrol.PolicyType.Trim() + '-' + _taskcontrol.PolicyNo.ToString().Trim();

            txtCustomerName.Text = _taskcontrol.Customer.FirstName.Trim() + ' ' + _taskcontrol.Customer.Initial.Trim()
                                    + ' ' + _taskcontrol.Customer.LastName1.Trim() + ' ' + _taskcontrol.Customer.LastName2.Trim();

            txtEntryDate.Text = DateTime.Now.ToShortDateString(); //_taskcontrol.EntryDate.ToString().Trim();

            if (_taskcontrol.Agency == "017")
            {
                imgFirmaResolve.Visible = true;
                imgFirmaPRMDC.Visible = false;
                imgFirmaColonial.Visible = false;
                txtNombreResolve.Visible = true;
                txtNombrePRMDC.Visible = false;
                txtNombreColonial.Visible = false;
                txtUnderwriter.Visible = false;
            }
            else if (_taskcontrol.Agency == "001" && _taskcontrol.City == 80)
            {
                imgFirmaColonial.Visible = true;
                imgFirmaResolve.Visible = false;
                imgFirmaPRMDC.Visible = false;
                txtNombreColonial.Visible = true;
                txtNombreResolve.Visible = false;
                txtNombrePRMDC.Visible = false;
                txtUnderwriter.Visible = false;
            }
            else
            {
                imgFirmaPRMDC.Visible = false;
                imgFirmaResolve.Visible = false;
                imgFirmaColonial.Visible = false;
                txtNombrePRMDC.Visible = false;
                txtNombreResolve.Visible = false;
                txtNombreColonial.Visible = false;
                txtUnderwriter.Visible = true;
            }
        }
    }
}
