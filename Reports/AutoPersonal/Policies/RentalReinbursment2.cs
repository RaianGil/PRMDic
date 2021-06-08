using System;
using System.Data;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using DataDynamics;
using System.Drawing;
using EPolicy.TaskControl;
using EPolicy.Quotes;
using EPolicy.Customer;
using EPolicy.LookupTables;

namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for RentalReinbursment2.
    /// </summary>
    public partial class RentalReinbursment2 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.QuoteAuto _policy;
        private string _CopyValue;

        public RentalReinbursment2(EPolicy.TaskControl.QuoteAuto taskcontrol, string copyValue)
        {
            _policy = taskcontrol;
            _CopyValue = copyValue;
            InitializeComponent();
        }
    }
}
