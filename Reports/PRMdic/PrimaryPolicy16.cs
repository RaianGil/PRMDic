using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for PrimaryPolicy16.
    /// </summary>
    public partial class PrimaryPolicy16 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;

        public PrimaryPolicy16(EPolicy.TaskControl.Policy taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void PrimaryPolicy16_ReportStart(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToShortDateString();//_taskcontrol.EntryDate.ToShortDateString();

            if (_taskcontrol.InsuranceCompany == "002")
            {
                label1.Text = "ASPEN AMERICAN INSURANCE COMPANY";
                label1.Visible = true;
                label2.Text = "175 Capital Blvd. • Suite 100 • Rocky Hill • CT, 06067";
                label1.Visible = true;
                picture2.Visible = true;
                picture4.Visible = true;
                line1.Visible = true;
                line2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                shape1.Visible = true;
            }

            if (_taskcontrol.Agency == "017")
            {
                imgFirmaResolve.Visible = true;
                txtNombreResolve.Visible = true;
                imgFirmaColonial.Visible = false;
                txtNombreColonial.Visible = false;
            }
            else if (_taskcontrol.Agency == "001" && _taskcontrol.City == 80)
            {
                imgFirmaColonial.Visible = true;
                imgFirmaResolve.Visible = false;
                txtNombreColonial.Visible = true;
                txtNombreResolve.Visible = false;
            }
            else
            {
                imgFirmaResolve.Visible = false;
                txtNombreResolve.Visible = false;
                imgFirmaColonial.Visible = false;
                txtNombreColonial.Visible = false;
            }
        }
    }
}
