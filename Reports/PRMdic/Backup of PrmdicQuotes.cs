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
    /// Summary description for PrmdicQuotes.
    /// </summary>
    public partial class PrmdicQuotes : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Application _taskcontrol;
        private string[] index1 = new string[7];
        private string[] index2 = new string[7];
        private string[] index3 = new string[7];
        private string[] index4 = new string[7];
        private string[] index5 = new string[7];
        private string[] index6 = new string[7];

        public PrmdicQuotes(EPolicy.TaskControl.Application taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void PrmdicQuotes_ReportStart(object sender, EventArgs e)
        {

            lblQuoteNo.Text = "Quote No.: " + _taskcontrol.TaskControlID.ToString().Trim();
            string month = _taskcontrol.EntryDate.Month.ToString();
            string day = _taskcontrol.EntryDate.Day.ToString();
            string year = _taskcontrol.EntryDate.Year.ToString();

            month = month.PadLeft(2, '0');
            day = day.PadLeft(2, '0');
            year = year.Substring(2, 2);

            txtIssuedDate.Text = month + '/' + day + '/' + year;
            txtIssuedDate.OutputFormat = "MM/dd/yy";
            //String.Format("{0:MM/dd/yy}", txtIssuedDate.Text);
            //Customer and Postal Address
            txtName.Text = _taskcontrol.Customer.FirstName.Trim() + " " + _taskcontrol.Customer.LastName1.Trim() + " " +
            _taskcontrol.Customer.LastName2.Trim();

            txtAddress.Text = _taskcontrol.Customer.Address1.ToString().Trim() + " " +
            _taskcontrol.Customer.Address2.ToString().Trim();
            txtAddress2.Text = _taskcontrol.Customer.City.ToString().Trim() + " " +
            _taskcontrol.Customer.State.ToString() + ", " + _taskcontrol.Customer.ZipCode.ToString().Trim();

            txtAgent.Text = EPolicy.LookupTables.LookupTables.GetDescription("Agent", _taskcontrol.Agent);

            DataTable dt = EPolicy.TaskControl.Application.GetPRMEDICRATEByPRMEDICRATEID(_taskcontrol.PRMEDICRATEID);
            TxtSpecialty.Text = dt.Rows[0]["PRMEDICRATEDESC"].ToString();
            txtIsoCode.Text = _taskcontrol.IsoCode;

            //Primary
            DataTable dt2 = EPolicy.LookupTables.LookupTables.GetTable("PRPrimaryLimit");
            for(int i=0; i < dt2.Rows.Count;i++)
            {
                if (_taskcontrol.PRPrimaryLimitID.ToString().Trim() == dt2.Rows[i]["PRMedicalLimitID"].ToString().Trim())
                {
                    txtLimitA.Text = dt2.Rows[i]["PRMedicalLimitDesc"].ToString();
                    i = dt2.Rows.Count;
                }
            }

            txtPrimaryRetroDate.Text = _taskcontrol.PrimaryRetroDate.Trim();
            txtExcessRetroDate.Text = _taskcontrol.ExcessRetroDate.Trim();

            //Primary
            double totPrem = 0.0;
            double totPrem2 = 0.0;
            double totPrem3 = 0.0;
            double totPrem4 = 0.0;
            double totPrem5 = 0.0;

            totPrem = _taskcontrol.PRateYear1;
            totPrem2 = _taskcontrol.PRateYear2;
            totPrem3 = _taskcontrol.PRateYear3;
            totPrem4 = _taskcontrol.PRateYear4;

            txtTotal1.Text = totPrem.ToString("$###,###.00");
            txtTotal2.Text = totPrem2.ToString("$###,###.00");
            txtTotal3.Text = totPrem3.ToString("$###,###.00");
            txtTotal4.Text = totPrem4.ToString("$###,###.00");

            //Excess
            //1-	1,000,000/3,000,000
            //2-	150,000/200,000
            //3-	400,000/700,000
            //5-	250,000/500,000
            //6-	300,000/1,000,000
            //7-	500,000/1,000,000

            SetRateExcessOrder(1,1);
            SetRateExcessOrder(7,2);
            SetRateExcessOrder(3,3);
            SetRateExcessOrder(6,4);
            SetRateExcessOrder(5,5);
            SetRateExcessOrder(2,6);

            SetPremiumByRetroDate();
        }

        private void SetRateExcessOrder(int ID, int order)
        {
            string limit = "";
            double totPrem = 0.0;
            double totPrem2 = 0.0;
            double totPrem3 = 0.0;
            double totPrem4 = 0.0;


            if (_taskcontrol.PRMedicalLimitID == ID)
            {
                totPrem = _taskcontrol.RateYear1;
                totPrem2 = _taskcontrol.RateYear2;
                totPrem3 = _taskcontrol.RateYear3;
                totPrem4 = _taskcontrol.MCMRate;
                index1[0] = "1";
                index1[1] = order.ToString();
                index1[2] = EPolicy.LookupTables.LookupTables.GetDescription("PRMedicalLimit", _taskcontrol.PRMedicalLimitID.ToString());
                index1[3] = totPrem.ToString("$###,###.00");
                index1[4] = totPrem2.ToString("$###,###.00");
                index1[5] = totPrem3.ToString("$###,###.00");
                index1[6] = totPrem4.ToString("$###,###.00");
                SetExcessValue(order);
            }


            if (_taskcontrol.PRMedicalLimit6ID == ID)
            {
                totPrem = _taskcontrol.RateYear16;
                totPrem2 = _taskcontrol.RateYear26;
                totPrem3 = _taskcontrol.RateYear36;
                totPrem4 = _taskcontrol.RateYear46;
                index1[0] = "6";
                index1[1] = order.ToString();
                index1[2] = EPolicy.LookupTables.LookupTables.GetDescription("PRMedicalLimit", _taskcontrol.PRMedicalLimit6ID.ToString());
                index1[3] = totPrem.ToString("$###,###.00");
                index1[4] = totPrem2.ToString("$###,###.00");
                index1[5] = totPrem3.ToString("$###,###.00");
                index1[6] = totPrem4.ToString("$###,###.00");
                SetExcessValue(order);
            }

            if (_taskcontrol.PRMedicalLimit5ID == ID)
            {
                totPrem = _taskcontrol.RateYear15;
                totPrem2 = _taskcontrol.RateYear25;
                totPrem3 = _taskcontrol.RateYear35;
                totPrem4 = _taskcontrol.RateYear45;
                index1[0] = "5";
                index1[1] = order.ToString();
                index1[2] = EPolicy.LookupTables.LookupTables.GetDescription("PRMedicalLimit", _taskcontrol.PRMedicalLimit5ID.ToString());
                index1[3] = totPrem.ToString("$###,###.00");
                index1[4] = totPrem2.ToString("$###,###.00");
                index1[5] = totPrem3.ToString("$###,###.00");
                index1[6] = totPrem4.ToString("$###,###.00");
                SetExcessValue(order);
            }

            if (_taskcontrol.PRMedicalLimit4ID == ID)
            {
                totPrem = _taskcontrol.RateYear14;
                totPrem2 = _taskcontrol.RateYear24;
                totPrem3 = _taskcontrol.RateYear34;
                totPrem4 = _taskcontrol.RateYear44;
                index1[0] = "4";
                index1[1] = order.ToString();
                index1[2] = EPolicy.LookupTables.LookupTables.GetDescription("PRMedicalLimit", _taskcontrol.PRMedicalLimit4ID.ToString());
                index1[3] = totPrem.ToString("$###,###.00");
                index1[4] = totPrem2.ToString("$###,###.00");
                index1[5] = totPrem3.ToString("$###,###.00");
                index1[6] = totPrem4.ToString("$###,###.00");
                SetExcessValue(order);
            }

            if (_taskcontrol.PRMedicalLimit3ID == ID)
            {
                totPrem = _taskcontrol.RateYear13;
                totPrem2 = _taskcontrol.RateYear23;
                totPrem3 = _taskcontrol.RateYear33;
                totPrem4 = _taskcontrol.RateYear43;
                index1[0] = "3";
                index1[1] = order.ToString();
                index1[2] = EPolicy.LookupTables.LookupTables.GetDescription("PRMedicalLimit", _taskcontrol.PRMedicalLimit3ID.ToString());
                index1[3] = totPrem.ToString("$###,###.00");
                index1[4] = totPrem2.ToString("$###,###.00");
                index1[5] = totPrem3.ToString("$###,###.00");
                index1[6] = totPrem4.ToString("$###,###.00");
                SetExcessValue(order);
            }

            if (_taskcontrol.PRMedicalLimit2ID == ID)
            {
                totPrem = _taskcontrol.RateYear12;
                totPrem2 = _taskcontrol.RateYear22;
                totPrem3 = _taskcontrol.RateYear32;
                totPrem4 = _taskcontrol.RateYear42;
                index1[0] = "2";
                index1[1] = order.ToString();
                index1[2] = limit = EPolicy.LookupTables.LookupTables.GetDescription("PRMedicalLimit", _taskcontrol.PRMedicalLimit2ID.ToString());
                index1[3] = totPrem.ToString("$###,###.00");
                index1[4] = totPrem2.ToString("$###,###.00");
                index1[5] = totPrem3.ToString("$###,###.00");
                index1[6] = totPrem4.ToString("$###,###.00");
                SetExcessValue(order);
            }
        }

        private void SetExcessValue(int order)
        {
            if (order == 1)
            {
                txtLimit1.Text = index1[2];
                txtRate11.Text = index1[3];
                txtRate21.Text = index1[4];
                txtRate31.Text = index1[5];
                txtRate41.Text = index1[6];
            }

            if (order == 2)
            {
                txtLimit2.Text = index1[2];
                txtRate12.Text = index1[3];
                txtRate22.Text = index1[4];
                txtRate32.Text = index1[5];
                txtRate42.Text = index1[6];
            }

            if (order == 3)
            {
                txtLimit3.Text = index1[2];
                txtRate13.Text = index1[3];
                txtRate23.Text = index1[4];
                txtRate33.Text = index1[5];
                txtRate43.Text = index1[6];
            }

            if (order == 4)
            {
                txtLimit4.Text = index1[2];
                txtRate14.Text = index1[3];
                txtRate24.Text = index1[4];
                txtRate34.Text = index1[5];
                txtRate44.Text = index1[6];
            }

            if (order == 5)
            {
                txtLimit5.Text = index1[2];
                txtRate15.Text = index1[3];
                txtRate25.Text = index1[4];
                txtRate35.Text = index1[5];
                txtRate45.Text = index1[6];
            }

            if (order == 6)
            {
                txtLimit6.Text = index1[2];
                txtRate16.Text = index1[3];
                txtRate26.Text = index1[4];
                txtRate36.Text = index1[5];
                txtRate46.Text = index1[6];
            }
        }

        private void SetPremiumByRetroDate()
        {
            //Set Premium by Retro Date
            txtTotal1.BackColor = Color.White;
            txtTotal1.ForeColor = Color.Black;
            txtTotal2.BackColor = Color.White;
            txtTotal2.ForeColor = Color.Black;
            txtTotal3.BackColor = Color.White;
            txtTotal3.ForeColor = Color.Black;
            txtTotal4.BackColor = Color.White;
            txtTotal4.ForeColor = Color.Black;

            txtRate11.BackColor = Color.White;
            txtRate11.ForeColor = Color.Black;
            txtRate21.BackColor = Color.White;
            txtRate21.ForeColor = Color.Black;
            txtRate31.BackColor = Color.White;
            txtRate31.ForeColor = Color.Black;
            txtRate41.BackColor = Color.White;
            txtRate41.ForeColor = Color.Black;

            int PrimaryRetroYear = 0;
            int ExcessRetroYear = 0;
            PrimaryRetroYear = _taskcontrol.EntryDate.Year - DateTime.Parse(txtPrimaryRetroDate.Text.Trim()).Year;
            ExcessRetroYear = _taskcontrol.EntryDate.Year - DateTime.Parse(txtExcessRetroDate.Text.Trim()).Year;

            switch (PrimaryRetroYear)
            {
                case 0:
                    txtTotal1.BackColor = Color.Navy;
                    txtTotal1.ForeColor = Color.White;
                    break;
                case 1:
                    txtTotal2.BackColor = Color.Navy;
                    txtTotal2.ForeColor = Color.White;
                    break;
                case 2:
                    txtTotal3.BackColor = Color.Navy;
                    txtTotal3.ForeColor = Color.White;
                    break;
                default:
                    txtTotal4.BackColor = Color.Navy;
                    txtTotal4.ForeColor = Color.White;
                    break;
            }

            switch (ExcessRetroYear)
            {
                case 0:
                    txtRate11.BackColor = Color.Navy;
                    txtRate11.ForeColor = Color.White;
                    break;
                case 1:
                    txtRate21.BackColor = Color.Navy;
                    txtRate21.ForeColor = Color.White;
                    break;
                case 2:
                    txtRate31.BackColor = Color.Navy;
                    txtRate31.ForeColor = Color.White;
                    break;
                default:
                    txtRate41.BackColor = Color.Navy;
                    txtRate41.ForeColor = Color.White;
                    break;
            }
        }
    }
}
