using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports2.PRMdic
{
    /// <summary>
    /// Summary description for PolizaNew18.
    /// </summary>
    public partial class PolizaNew18 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Policy _taskcontrol;

        public PolizaNew18(EPolicy.TaskControl.Policy taskcontrol)
        {
            //
            // Required for Windows Form Designer support
            //
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void PolizaNew18_ReportStart(object sender, EventArgs e)
        {
            txtEntryDate.Text = DateTime.Now.ToShortDateString();//_taskcontrol.EntryDate.ToShortDateString();

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
        }
    }
}
