using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for CorporateQuote.
    /// </summary>
    public partial class CorporateQuote : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.CorporatePolicyQuote _taskcontrol;
        private int CountDataIndex=1;
        private int index=0;

        public CorporateQuote(EPolicy.TaskControl.CorporatePolicyQuote taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void CorporateQuote_ReportStart(object sender, EventArgs e)
        {
            lblQuoteNo.Text = "Quote No.: " + _taskcontrol.TaskControlID.ToString().Trim();

            txtCorporate.Text = _taskcontrol.Corporate.Trim();

            string month = _taskcontrol.EntryDate.Month.ToString();
            string day = _taskcontrol.EntryDate.Day.ToString();
            string year = _taskcontrol.EntryDate.Year.ToString();

            month = month.PadLeft(2, '0');
            day = day.PadLeft(2, '0');
            year = year.Substring(2, 2);

            txtIssuedDate.Text = month + '/' + day + '/' + year;
            txtIssuedDate.OutputFormat = "MM/dd/yy";

            txtAgent.Text = EPolicy.LookupTables.LookupTables.GetDescription("Agent", _taskcontrol.Agent);
            txtAgeny.Text = EPolicy.LookupTables.LookupTables.GetDescription("Agency", _taskcontrol.Agent);

            txtTotalPrimaryCorporate.Text = _taskcontrol.TotalPrimaryCorporate.ToString("$###,###.00");
            txtTotalExcesoCorporate.Text = _taskcontrol.TotalExcessCorporate.ToString("$###,###.00");

            double totprem = _taskcontrol.TotalPrimaryCorporate+_taskcontrol.TotalExcessCorporate;
            txtTotalPremium.Text = totprem.ToString("$###,###.00");

            txtOP1.Text = _taskcontrol.QuantityTN1.ToString();
            txtOP2.Text = _taskcontrol.QuantityTN2.ToString();
            txtOP3.Text = _taskcontrol.QuantityTN3.ToString();
            txtOP4.Text = _taskcontrol.QuantityTN4.ToString();
            txtOP5.Text = _taskcontrol.QuantityTN5.ToString();

            //Primary
            txtLimitA.Text = _taskcontrol.CorporatePolicyDetailCollection.Rows[0]["PrimaryRate"].ToString();

            //Excess
            txtLimitA.Text = _taskcontrol.CorporatePolicyDetailCollection.Rows[0]["ExcessRate"].ToString();            
        }

        private void CorporateQuote_FetchData(object sender, FetchEventArgs eArgs)
        {
            try
            {
                if (this.CountDataIndex <= _taskcontrol.CorporatePolicyDetailCollection.Rows.Count)
                {
                    eArgs.EOF = false;
                    txtNombre.Text = _taskcontrol.CorporatePolicyDetailCollection.Rows[index]["CustomerName"].ToString();
                    txtSpecialty.Text = _taskcontrol.CorporatePolicyDetailCollection.Rows[index]["Specialty"].ToString();
                    txtIsoCode.Text = _taskcontrol.CorporatePolicyDetailCollection.Rows[index]["IsoCode"].ToString();

                    this.CountDataIndex++;
                    this.index++;
                }
            }
            catch (Exception exc)
            {
                if (eArgs != null)
                    eArgs.EOF = true;
            }
        }
    }
}
