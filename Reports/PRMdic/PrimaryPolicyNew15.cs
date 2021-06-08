using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for PrimaryPolicyNew15.
    /// </summary>
    public partial class PrimaryPolicyNew15 : DataDynamics.ActiveReports.ActiveReport3
    {

        public PrimaryPolicyNew15()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void PrimaryPolicyNew15_ReportStart(object sender, EventArgs e)
        {
            txtEntryDate.Text = DateTime.Now.ToShortDateString();//_taskcontrol.EntryDate.ToShortDateString();
        }
    }
}
