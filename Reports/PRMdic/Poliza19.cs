using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for Poliza19.
    /// </summary>
    public partial class Poliza19 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;

        public Poliza19(EPolicy.TaskControl.Policy taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void Poliza19_ReportStart(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToShortDateString(); //_taskcontrol.EntryDate.ToShortDateString();

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
