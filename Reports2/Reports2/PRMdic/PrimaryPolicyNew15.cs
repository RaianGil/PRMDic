using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports2.PRMdic
{
    /// <summary>
    /// Summary description for PrimaryPolicyNew15.
    /// </summary>
    public partial class PrimaryPolicyNew15 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;

        public PrimaryPolicyNew15(EPolicy.TaskControl.Policy taskcontrol)
        {
            //
            // Required for Windows Form Designer support
            //
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void PrimaryPolicyNew15_ReportStart(object sender, EventArgs e)
        {
            txtEntryDate.Text = DateTime.Now.ToShortDateString();//_taskcontrol.EntryDate.ToShortDateString();
            
            //Firma Resolve General Agency
            if (_taskcontrol.Agency == "017")
            {
                imgFirmaResolve.Visible = true;
                txtNombreResolve.Visible = true;
            }
            else
            {
                imgFirmaResolve.Visible = false;
                txtNombreResolve.Visible = false;
            }

            //Firma Colonial Insurance sucursal San Juan y Hato Rey            
            if (_taskcontrol.Agency == "001" && (_taskcontrol.City == 80 || _taskcontrol.City == 66))
            {
                imgFirmaColonial.Visible = true;
                txtNombreColonial.Visible = true;
            }
            else
            {
                imgFirmaColonial.Visible = false;
                txtNombreColonial.Visible = false;
            }

        }
    }
}
