using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for PrimaryActOfWar.
    /// </summary>
    public partial class PrimaryActOfWar : DataDynamics.ActiveReports.ActiveReport3
    {

        public PrimaryActOfWar(EPolicy.TaskControl.Policy taskcontrol,bool certificate)
        {
            //
            // Required for Windows Form Designer support
            //
            if (certificate)
            {
                lblCertificate.Visible = true;
                lblCertificate.Text = "Hereby it is certified that this is an exact and true copy of the original Policy No. " +
                    taskcontrol.PolicyType.Trim() + "-" + taskcontrol.PolicyNo.Trim() + " issued by PRMDIC in favor of Dr. " +
                    taskcontrol.Customer.FirstName + " " + taskcontrol.Customer.LastName1 + " " + taskcontrol.Customer.LastName2 + ".";
            }
            InitializeComponent();
        }
    }
}
