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
    public partial class CorporateQuotes : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.CorporatePolicyQuote _taskcontrol;
        private string _ERate150_200;
        private string _ERate1M_3M;
        private string _ERate250_500;
        private string _ERate400_700;
        private string _ERate500_1M;
        private string _PRate;
        private string _TotPremTN6;
        private string _ETotPremTN6;
        private string _DiscountP;
        private string _Discount;
        private int _Count;
        private string _specialty;
        private string _isoCode;
        private string[] index1 = new string[7];
        private string[] index2 = new string[7];
        private string[] index3 = new string[7];
        private string[] index4 = new string[7];
        private string[] index5 = new string[7];
        private string[] index6 = new string[7];

        public CorporateQuotes(EPolicy.TaskControl.CorporatePolicyQuote taskcontrol,
        string ERate150_200,string ERate1M_3M, string ERate250_500, string ERate400_700, 
        string ERate500_1M, string PRate, string TotPremTN6 , string ETotPremTN6, string DiscountP,
        string Discount, int Count, string specialty, string isoCode)
        {
            _taskcontrol = taskcontrol;
            _ERate150_200 = ERate150_200;
            _ERate1M_3M = ERate1M_3M;
            _ERate250_500 = ERate250_500;
            _ERate400_700 = ERate400_700;
            _ERate500_1M = ERate500_1M;
            _PRate = PRate;
            _TotPremTN6 = TotPremTN6;
            _ETotPremTN6 = ETotPremTN6;
            _DiscountP = DiscountP;
            _Discount = Discount;
            _Count = Count;
            _specialty = specialty;
            _isoCode = isoCode;

            InitializeComponent();
        }

        private void CorporateQuotes_ReportStart(object sender, EventArgs e)
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
            txtName.Text = _taskcontrol.Corporate.Trim();//Customer.FirstName.Trim() + " " + _taskcontrol.Customer.LastName1.Trim() + " " +
            //_taskcontrol.Customer.LastName2.Trim();

            //txtAddress.Text = _taskcontrol.Customer.Address1.ToString().Trim() + " " +
            //_taskcontrol.Customer.Address2.ToString().Trim();
            //txtAddress2.Text = _taskcontrol.Customer.City.ToString().Trim() + " " +
            //_taskcontrol.Customer.State.ToString() + ", " + _taskcontrol.Customer.ZipCode.ToString().Trim();

            txtAgent.Text = EPolicy.LookupTables.LookupTables.GetDescription("Agent", _taskcontrol.Agent);

            //DataTable dt = EPolicy.TaskControl.Application.GetPRMEDICRATEByPRMEDICRATEID(_taskcontrol.PRMEDICRATEID);
            TxtSpecialty.Text = _specialty;//dt.Rows[0]["PRMEDICRATEDESC"].ToString();
            txtIsoCode.Text = _isoCode;//_taskcontrol.IsoCode;

            //Primary
            //DataTable dt2 = EPolicy.LookupTables.LookupTables.GetTable("PRPrimaryLimit");
            //for (int i = 0; i < dt2.Rows.Count; i++)
            //{
            //    if (_taskcontrol.PRPrimaryLimitID.ToString().Trim() == dt2.Rows[i]["PRMedicalLimitID"].ToString().Trim())
            //    {
                    //txtLimitA.Text = "$" + dt2.Rows[i]["PRMedicalLimitDesc"].ToString();
                    txtLimitA.Text = "$100,000/$300,000";//txtLimitA.Text.Replace("/", "/$");
                    //i = dt2.Rows.Count;
                //}
            //}

            //txtPrimaryRetroDate.Text = _taskcontrol.PrimaryRetroDate.Trim();
            //txtExcessRetroDate.Text = _taskcontrol.ExcessRetroDate.Trim();

            //Primary
            double totPrem = 0.0;
            double totPrem2 = 0.0;
            double totPrem3 = 0.0;
            double totPrem4 = 0.0;
            double totPrem5 = 0.0;

            totPrem = (((double.Parse(_PRate) * 0.6) * (double.Parse(_DiscountP) / 100)) + double.Parse(_TotPremTN6));
            totPrem2 = (((double.Parse(_PRate) * 0.8) * (double.Parse(_DiscountP) / 100)) + double.Parse(_TotPremTN6));
            totPrem3 = (((double.Parse(_PRate) * 0.9) * (double.Parse(_DiscountP) / 100)) + double.Parse(_TotPremTN6));
            totPrem4 = (((double.Parse(_PRate) * 1) * (double.Parse(_DiscountP) / 100)) + double.Parse(_TotPremTN6));

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
            SetRateExcessOrder(4, 3);
            SetRateExcessOrder(5, 4);
            SetRateExcessOrder(2, 5);
            SetRateExcessOrder(6, 6); //YA PRMDIC NO OFRECE ESTA CUBIERTA!

            SetPremiumByRetroDate();
            //CalculateCharge(0.009);
            SetEmployeeCount();

            if (_taskcontrol.InsuranceCompany == "002")
            {
                picture1.Visible = true;
                picture2.Visible = false;
                textBox10.Text = 
                    "It's a prerequisite for the issuance and renewal of the corporate policy that all physicians be insured in their individual character for the same limit as the corporation, preferably with ASPEN American Insurance Company, and evidence of such coverage must be presented.  We have included a 'Quick Quote' for each specialty as reference.  For an official individual quote for each physician, please contact your agent or the insurance comapny at (787) 999 - 7763 / aspen@prmdic.net.";

                label33.Text =
                    "This quote is an indication of tariff applicable to the classification selected and does not constitute an acceptance of the application nor is a final quote. Following our Underwriting Guidelines ASPEN  will evaluate the application submitted, and determine the correct classification (specialty), calculating tariff  based on actual procedures performed by the prospect insured.";

                label10.Text = "175 Capital Blvd. • Suite 100 • Rocky Hill • CT, 06067";
                label24.Text = "Tel. 787-999-7763 • Fax: 787-993-7763 • aspen@prmdic.com";

            }
        }

        private void SetRateExcessOrder(int ID, int order)
        {
            string limit = "";
            double totPrem = 0.0;
            double totPrem2 = 0.0;
            double totPrem3 = 0.0;
            double totPrem4 = 0.0;


            if (ID == 1)
            {
                totPrem = (((double.Parse(_ERate1M_3M) * 0.6) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));
                totPrem2 = (((double.Parse(_ERate1M_3M) * 0.8) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));
                totPrem3 = (((double.Parse(_ERate1M_3M) * 0.9) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));
                totPrem4 = (((double.Parse(_ERate1M_3M) * 1) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));

                index1[0] = "1";
                index1[1] = order.ToString();
                index1[2] = "1,000,000/3,000,000";//EPolicy.LookupTables.LookupTables.GetDescription("PRMedicalLimit", _taskcontrol.PRMedicalLimitID.ToString());
                index1[3] = totPrem.ToString("$###,###");
                index1[4] = totPrem2.ToString("$###,###");
                index1[5] = totPrem3.ToString("$###,###");
                index1[6] = totPrem4.ToString("$###,###");
                SetExcessValue(order);
            }


            if (ID == 7)
            {
                totPrem = (((double.Parse(_ERate500_1M) * 0.6) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));
                totPrem2 = (((double.Parse(_ERate500_1M) * 0.8) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));
                totPrem3 = (((double.Parse(_ERate500_1M) * 0.9) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));
                totPrem4 = (((double.Parse(_ERate500_1M) * 1) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));

                index1[0] = "6";
                index1[1] = order.ToString();
                index1[2] = "500,000/1,000,000";//EPolicy.LookupTables.LookupTables.GetDescription("PRMedicalLimit", _taskcontrol.PRMedicalLimit6ID.ToString());
                index1[3] = totPrem.ToString("$###,###");
                index1[4] = totPrem2.ToString("$###,###");
                index1[5] = totPrem3.ToString("$###,###");
                index1[6] = totPrem4.ToString("$###,###");
                SetExcessValue(order);
            }

            if (ID == 5)
            {
                totPrem = (((double.Parse(_ERate250_500) * 0.6) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));
                totPrem2 = (((double.Parse(_ERate250_500) * 0.8) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));
                totPrem3 = (((double.Parse(_ERate250_500) * 0.9) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));
                totPrem4 = (((double.Parse(_ERate250_500) * 1) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));

                index1[0] = "5";
                index1[1] = order.ToString();
                index1[2] = "250,000/500,000"; //EPolicy.LookupTables.LookupTables.GetDescription("PRMedicalLimit", _taskcontrol.PRMedicalLimit5ID.ToString());
                index1[3] = totPrem.ToString("$###,###");
                index1[4] = totPrem2.ToString("$###,###");
                index1[5] = totPrem3.ToString("$###,###");
                index1[6] = totPrem4.ToString("$###,###");
                SetExcessValue(order);
            }

            if (ID == 4)
            {
                totPrem = (((double.Parse(_ERate400_700) * 0.6) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));
                totPrem2 = (((double.Parse(_ERate400_700) * 0.8) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));
                totPrem3 = (((double.Parse(_ERate400_700) * 0.9) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));
                totPrem4 = (((double.Parse(_ERate400_700) * 1) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));

                index1[0] = "4";
                index1[1] = order.ToString();
                index1[2] = "400,000/700,000";//EPolicy.LookupTables.LookupTables.GetDescription("PRMedicalLimit", _taskcontrol.PRMedicalLimit4ID.ToString());
                index1[3] = totPrem.ToString("$###,###");
                index1[4] = totPrem2.ToString("$###,###");
                index1[5] = totPrem3.ToString("$###,###");
                index1[6] = totPrem4.ToString("$###,###");
                SetExcessValue(order);
            }

            if (ID == 3)
            {
                totPrem = (((double.Parse(_ERate250_500) * 0.6) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));
                totPrem2 = (((double.Parse(_ERate250_500) * 0.8) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));
                totPrem3 = (((double.Parse(_ERate250_500) * 0.9) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));
                totPrem4 = (((double.Parse(_ERate250_500) * 1) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));

                index1[0] = "3";
                index1[1] = order.ToString();
                index1[2] = "250,000/500,000";//EPolicy.LookupTables.LookupTables.GetDescription("PRMedicalLimit", _taskcontrol.PRMedicalLimit3ID.ToString());
                index1[3] = totPrem.ToString("$###,###");
                index1[4] = totPrem2.ToString("$###,###");
                index1[5] = totPrem3.ToString("$###,###");
                index1[6] = totPrem4.ToString("$###,###");
                SetExcessValue(order);
            }

            if (ID == 2)
            {
                totPrem = (((double.Parse(_ERate150_200) * 0.6) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));
                totPrem2 = (((double.Parse(_ERate150_200) * 0.8) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));
                totPrem3 = (((double.Parse(_ERate150_200) * 0.9) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));
                totPrem4 = (((double.Parse(_ERate150_200) * 1) * (double.Parse(_Discount) / 100)) + double.Parse(_ETotPremTN6));

                index1[0] = "2";
                index1[1] = order.ToString();
                index1[2] = "150,000/200,000";//limit = EPolicy.LookupTables.LookupTables.GetDescription("PRMedicalLimit", _taskcontrol.PRMedicalLimit2ID.ToString());
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
                //txtLimit6.Text = "$" + index1[2];
                //txtLimit6.Text = txtLimit6.Text.Replace("/", "/$");
                //txtRate16.Text = index1[3];
                //txtRate26.Text = index1[4];
                //txtRate36.Text = index1[5];
                //txtRate46.Text = index1[6];
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
            PrimaryRetroYear = _taskcontrol.EntryDate.Year - DateTime.Parse(_taskcontrol.RetroactiveDate.Trim()).Year;
            ExcessRetroYear = _taskcontrol.EntryDate.Year - DateTime.Parse(_taskcontrol.RetroactiveDate.Trim()).Year;

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
            //OLD TEXT: An additional surcharge of 0.9%  of the premium quoted will be charged on new business issued with effective date on or after October 1, 2013.   The additional amount to be charged was determined by the Commissioner of Insurance of Puerto Rico for the purpose of recovering the unreimbursed assessments paid by Puerto Rico Medical Defense Insurance Company (PRMD) to the Puerto Rico Property and Casualty Insurance Guaranty Association.   As required by the Commissioner of Insurance of Puerto Rico, once the policy is issued this surcharge will be segregated from the premium. 
            //label46.Text = "Premium quoted includes a surcharge of 0.9% determined by the Commissioner of Insurance of Puerto Rico for the purpose of recovering the unreimbursed assessments paid by Puerto Rico Medical Defense Insurance Company to the Puerto Rico Property and Casualty Insurance Guaranty Association.   As required by the Commissioner of Insurance of Puerto Rico, once the policy is issued the surcharge will be segregated from the premium. ";
            
             
            
            
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

        private void SetEmployeeCount()
        {
            int total = _Count + _taskcontrol.QuantityTN1 + _taskcontrol.QuantityTN2 + _taskcontrol.QuantityTN3 + _taskcontrol.QuantityTN4 + _taskcontrol.QuantityTN5;

            txtQuantityTN1.Text = _Count.ToString();

            txtQuantityTN2.Text = _taskcontrol.QuantityTN1.ToString();
            txtQuantityTN3.Text = _taskcontrol.QuantityTN2.ToString();
            txtQuantityTN4.Text = _taskcontrol.QuantityTN3.ToString();
            txtQuantityTN5.Text = _taskcontrol.QuantityTN4.ToString();
            txtQuantityTN6.Text = _taskcontrol.QuantityTN5.ToString();

            txtQuantityTN7.Text = total.ToString();
        }

    }
}
