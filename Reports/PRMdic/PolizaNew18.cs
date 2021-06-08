using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for PolizaNew18.
    /// </summary>
    public partial class PolizaNew18 : DataDynamics.ActiveReports.ActiveReport3
    {

        public PolizaNew18()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void PolizaNew18_ReportStart(object sender, EventArgs e)
        {
            txtEntryDate.Text = DateTime.Now.ToShortDateString();//_taskcontrol.EntryDate.ToShortDateString();
        }
    }
}
