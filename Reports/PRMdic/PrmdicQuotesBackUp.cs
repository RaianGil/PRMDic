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

            txtQuoteNumber.Text = _taskcontrol.TaskControlID.ToString().Trim();
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
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                if (_taskcontrol.PRPrimaryLimitID.ToString().Trim() == dt2.Rows[i]["PRMedicalLimitID"].ToString().Trim())
                {
                    txtLimitA.Text = "$" + dt2.Rows[i]["PRMedicalLimitDesc"].ToString();
                    txtLimitA.Text = txtLimitA.Text.Replace("/", "/$");
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

            txtTotal1.Text = totPrem.ToString("$###,###");
            txtTotal2.Text = totPrem2.ToString("$###,###");
            txtTotal3.Text = totPrem3.ToString("$###,###");
            txtTotal4.Text = totPrem4.ToString("$###,###");

            //Excess
            //1-	1,000,000/3,000,000
            //2-	150,000/200,000
            //3-	400,000/700,000
            //5-	250,000/500,000
            //6-	300,000/1,000,000
            //7-	500,000/1,000,000

            SetRateExcessOrder(1, 1);
            SetRateExcessOrder(7, 2);
            SetRateExcessOrder(3, 3);
            SetRateExcessOrder(5, 4);
            SetRateExcessOrder(2, 5);
            SetRateExcessOrder(6, 6); //YA PRMDIC NO OFRECE ESTA CUBIERTA!

            SetPremiumByRetroDate();
            CalculateCharge(0.009);
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
                index1[3] = totPrem.ToString("$###,###");
                index1[4] = totPrem2.ToString("$###,###");
                index1[5] = totPrem3.ToString("$###,###");
                index1[6] = totPrem4.ToString("$###,###");
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
                index1[3] = totPrem.ToString("$###,###");
                index1[4] = totPrem2.ToString("$###,###");
                index1[5] = totPrem3.ToString("$###,###");
                index1[6] = totPrem4.ToString("$###,###");
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
                index1[3] = totPrem.ToString("$###,###");
                index1[4] = totPrem2.ToString("$###,###");
                index1[5] = totPrem3.ToString("$###,###");
                index1[6] = totPrem4.ToString("$###,###");
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
                index1[3] = totPrem.ToString("$###,###");
                index1[4] = totPrem2.ToString("$###,###");
                index1[5] = totPrem3.ToString("$###,###");
                index1[6] = totPrem4.ToString("$###,###");
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
                index1[3] = totPrem.ToString("$###,###");
                index1[4] = totPrem2.ToString("$###,###");
                index1[5] = totPrem3.ToString("$###,###");
                index1[6] = totPrem4.ToString("$###,###");
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
                index1[3] = totPrem.ToString("$###,###");
                index1[4] = totPrem2.ToString("$###,###");
                index1[5] = totPrem3.ToString("$###,###");
                index1[6] = totPrem4.ToString("$###,###");
                SetExcessValue(order);
            }
        }

        private void SetExcessValue(int order)
        {
            if (order == 1)
            {
                txtLimit1.Text = "$" + index1[2];
                txtLimit1.Text = txtLimit1.Text.Replace("/", "/$");
                txtRate11.Text = index1[3];
                txtRate21.Text = index1[4];
                txtRate31.Text = index1[5];
                txtRate41.Text = index1[6];
            }

            if (order == 2)
            {
                txtLimit2.Text = "$" + index1[2];
                txtLimit2.Text = txtLimit2.Text.Replace("/", "/$");
                txtRate12.Text = index1[3];
                txtRate22.Text = index1[4];
                txtRate32.Text = index1[5];
                txtRate42.Text = index1[6];
            }

            if (order == 3)
            {
                txtLimit3.Text = "$" + index1[2];
                txtLimit3.Text = txtLimit3.Text.Replace("/", "/$");
                txtRate13.Text = index1[3];
                txtRate23.Text = index1[4];
                txtRate33.Text = index1[5];
                txtRate43.Text = index1[6];
            }

            if (order == 4)
            {
                txtLimit4.Text = "$" + index1[2];
                txtLimit4.Text = txtLimit4.Text.Replace("/", "/$");
                txtRate14.Text = index1[3];
                txtRate24.Text = index1[4];
                txtRate34.Text = index1[5];
                txtRate44.Text = index1[6];
            }

            if (order == 5)
            {
                txtLimit5.Text = "$" + index1[2];
                txtLimit5.Text = txtLimit5.Text.Replace("/", "/$");
                txtRate15.Text = index1[3];
                txtRate25.Text = index1[4];
                txtRate35.Text = index1[5];
                txtRate45.Text = index1[6];
            }

            if (order == 6)
            {
                txtLimit6.Text = "$" + index1[2];
                txtLimit6.Text = txtLimit6.Text.Replace("/", "/$");
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
        private void CalculateCharge(double charge)
        {
            //DateTime primaryDate = Convert.ToDateTime(txtPrimaryRetroDate.Text + " 1:00:00 AM");
            //DateTime excessDate = Convert.ToDateTime(txtExcessRetroDate.Text + " 1:00:00 AM");
            //int resultPrimary = DateTime.Compare(primaryDate,
            //                     DateTime.Parse("10/01/2013"));

            //int resultExcess = DateTime.Compare(excessDate,
            //                     DateTime.Parse("10/01/2013"));

            //if ((resultPrimary == 0 || resultPrimary == 1) || (resultExcess == 0 || resultExcess == 1))
            //{
                label46.Text = "Premium quoted includes a surcharge of 0.9% determined by the Commissioner of Insurance of Puerto Rico for the purpose of recovering the unreimbursed assessments paid by Puerto Rico Medical Defense Insurance Company (the Company) to the Puerto Rico Property and Casualty Insurance Guaranty Association.   As required by the Commissioner of Insurance of Puerto Rico, once the policy is issued this surcharge will be segregated from the premium. ";

                txtTotal1.Text = ((int)Math.Ceiling(double.Parse(txtTotal1.Text.Substring(1)) + double.Parse(txtTotal1.Text.Substring(1)) * charge)).ToString("$###,###");
                txtTotal2.Text = ((int)Math.Ceiling(double.Parse(txtTotal2.Text.Substring(1)) + double.Parse(txtTotal2.Text.Substring(1)) * charge)).ToString("$###,###");
                txtTotal3.Text = ((int)Math.Ceiling(double.Parse(txtTotal3.Text.Substring(1)) + double.Parse(txtTotal3.Text.Substring(1)) * charge)).ToString("$###,###");
                txtTotal4.Text = ((int)Math.Ceiling(double.Parse(txtTotal4.Text.Substring(1)) + double.Parse(txtTotal4.Text.Substring(1)) * charge)).ToString("$###,###");

                txtRate11.Text = ((int)Math.Ceiling(double.Parse(txtRate11.Text.Substring(1)) + double.Parse(txtRate11.Text.Substring(1)) * charge)).ToString("$###,###");
                txtRate21.Text = ((int)Math.Ceiling(double.Parse(txtRate21.Text.Substring(1)) + double.Parse(txtRate21.Text.Substring(1)) * charge)).ToString("$###,###");
                txtRate31.Text = ((int)Math.Ceiling(double.Parse(txtRate31.Text.Substring(1)) + double.Parse(txtRate31.Text.Substring(1)) * charge)).ToString("$###,###");
                txtRate41.Text = ((int)Math.Ceiling(double.Parse(txtRate41.Text.Substring(1)) + double.Parse(txtRate41.Text.Substring(1)) * charge)).ToString("$###,###");

                txtRate12.Text = ((int)Math.Ceiling(double.Parse(txtRate12.Text.Substring(1)) + double.Parse(txtRate12.Text.Substring(1)) * charge)).ToString("$###,###");
                txtRate22.Text = ((int)Math.Ceiling(double.Parse(txtRate22.Text.Substring(1)) + double.Parse(txtRate22.Text.Substring(1)) * charge)).ToString("$###,###");
                txtRate32.Text = ((int)Math.Ceiling(double.Parse(txtRate32.Text.Substring(1)) + double.Parse(txtRate32.Text.Substring(1)) * charge)).ToString("$###,###");
                txtRate42.Text = ((int)Math.Ceiling(double.Parse(txtRate42.Text.Substring(1)) + double.Parse(txtRate42.Text.Substring(1)) * charge)).ToString("$###,###");

                txtRate13.Text = ((int)Math.Ceiling(double.Parse(txtRate13.Text.Substring(1)) + double.Parse(txtRate13.Text.Substring(1)) * charge)).ToString("$###,###");
                txtRate23.Text = ((int)Math.Ceiling(double.Parse(txtRate23.Text.Substring(1)) + double.Parse(txtRate23.Text.Substring(1)) * charge)).ToString("$###,###");
                txtRate33.Text = ((int)Math.Ceiling(double.Parse(txtRate33.Text.Substring(1)) + double.Parse(txtRate33.Text.Substring(1)) * charge)).ToString("$###,###");
                txtRate43.Text = ((int)Math.Ceiling(double.Parse(txtRate43.Text.Substring(1)) + double.Parse(txtRate43.Text.Substring(1)) * charge)).ToString("$###,###");

                txtRate14.Text = ((int)Math.Ceiling(double.Parse(txtRate14.Text.Substring(1)) + double.Parse(txtRate14.Text.Substring(1)) * charge)).ToString("$###,###");
                txtRate24.Text = ((int)Math.Ceiling(double.Parse(txtRate24.Text.Substring(1)) + double.Parse(txtRate24.Text.Substring(1)) * charge)).ToString("$###,###");
                txtRate34.Text = ((int)Math.Ceiling(double.Parse(txtRate34.Text.Substring(1)) + double.Parse(txtRate34.Text.Substring(1)) * charge)).ToString("$###,###");
                txtRate44.Text = ((int)Math.Ceiling(double.Parse(txtRate44.Text.Substring(1)) + double.Parse(txtRate44.Text.Substring(1)) * charge)).ToString("$###,###");

                txtRate15.Text = ((int)Math.Ceiling(double.Parse(txtRate15.Text.Substring(1)) + double.Parse(txtRate15.Text.Substring(1)) * charge)).ToString("$###,###");
                txtRate25.Text = ((int)Math.Ceiling(double.Parse(txtRate25.Text.Substring(1)) + double.Parse(txtRate25.Text.Substring(1)) * charge)).ToString("$###,###");
                txtRate35.Text = ((int)Math.Ceiling(double.Parse(txtRate35.Text.Substring(1)) + double.Parse(txtRate35.Text.Substring(1)) * charge)).ToString("$###,###");
                txtRate45.Text = ((int)Math.Ceiling(double.Parse(txtRate45.Text.Substring(1)) + double.Parse(txtRate45.Text.Substring(1)) * charge)).ToString("$###,###");

                //txtRate16.Text = ((int)Math.Ceiling(double.Parse(txtRate16.Text.Substring(1)) + double.Parse(txtRate16.Text.Substring(1)) * charge)).ToString("$###,###");
                //txtRate26.Text = ((int)Math.Ceiling(double.Parse(txtRate26.Text.Substring(1)) + double.Parse(txtRate26.Text.Substring(1)) * charge)).ToString("$###,###");
                //txtRate36.Text = ((int)Math.Ceiling(double.Parse(txtRate36.Text.Substring(1)) + double.Parse(txtRate36.Text.Substring(1)) * charge)).ToString("$###,###");
                //txtRate46.Text = ((int)Math.Ceiling(double.Parse(txtRate46.Text.Substring(1)) + double.Parse(txtRate46.Text.Substring(1)) * charge)).ToString("$###,###");
            //}
        }
    }
}
