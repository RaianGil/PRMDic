using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.Customer;
using EPolicy.LookupTables;
using EPolicy.TaskControl;
using System.Data;

namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for PersonalPackageSeccionI.
    /// </summary>
    public partial class PersonalPackageSeccionI : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.OptimaPersonalPackage _taskcontrol;
        private double _PremTotal = 0.00;
        private double _BuildingPremiumTotal = 0.00;
        private double _ContentsPremiumTotal = 0.00;
        private double _AdditionalCoveragesPremiumTotal = 0.00;
        private int _index = 0;

        public PersonalPackageSeccionI(EPolicy.TaskControl.OptimaPersonalPackage taskcontrol,string copy, int index)
        {
            _taskcontrol = taskcontrol;
            _index = index;
            InitializeComponent();
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {

        }

        private void PersonalPackageSeccionI_PageStart(object sender, EventArgs e)
        {
            txtPolicyNo.Text = _taskcontrol.PolicyType.ToString().ToUpper().Trim() + " " + _taskcontrol.PolicyNo.ToString().Trim() + " " + _taskcontrol.Certificate.ToString().Trim();
            txtEffectiveDate.Text = _taskcontrol.EffectiveDate.ToString();
            txtExpirationDate.Text = _taskcontrol.ExpirationDate.ToString();
            txtEmision.Text = _taskcontrol.EntryDate.ToShortDateString();
            txtPropEnd.Text = "OPP PP 0001 07 07; OPP PP 0003 07 07; OPP PP 0027 07 07; "+_taskcontrol.PropEnd.Trim();

            //Seccion I
            if (_index == 1) //(_taskcontrol.PropertiesCollection.Rows.Count > 0)
            {
                TxtDeducible.Text = _taskcontrol.PropertiesCollection.Rows[_index-1]["Deductible"].ToString();

                TxtRes1.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["Address1"].ToString();
                TxtRes2.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["Address2"].ToString();
                TxtRes3.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["City"].ToString() + ",  " +
                    _taskcontrol.PropertiesCollection.Rows[_index - 1]["State"].ToString() + "  " +
                    _taskcontrol.PropertiesCollection.Rows[_index - 1]["ZipCode"].ToString();
                _PremTotal = (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["TotalPremium"];

                //_BuildingPremiumTotal = (double)_taskcontrol.PropertiesCollection.Rows[0]["BuildingPremiumTotal"];
                //_ContentsPremiumTotal = (double)_taskcontrol.PropertiesCollection.Rows[0]["ContentsPremiumTotal"];
                _BuildingPremiumTotal = (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["BuildingLimitFire"];
                _ContentsPremiumTotal = (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["ContentsLimitFire"];
                _AdditionalCoveragesPremiumTotal = SetAdditionalCoverageTotalPremium(_taskcontrol.AdditionalCoveragesPropertiesCollection1);

                TxtLoanNo1.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["LoanNo"].ToString();
                TxtBank1.Text = LookupTables.GetDescription("Bank", _taskcontrol.PropertiesCollection.Rows[_index - 1]["Bank"].ToString().Trim());

                TxtRes4.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["Description"].ToString().Trim();
            }

            if (_index == 2) //(_taskcontrol.PropertiesCollection.Rows.Count > 1)
            {
                TxtDeducible.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["Deductible"].ToString();

                TxtRes1.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["Address1"].ToString();
                TxtRes2.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["Address2"].ToString();
                TxtRes3.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["City"].ToString() + ",  " +
                    _taskcontrol.PropertiesCollection.Rows[_index - 1]["State"].ToString() + "  " +
                    _taskcontrol.PropertiesCollection.Rows[_index - 1]["ZipCode"].ToString();
                _PremTotal = (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["TotalPremium"];

                _BuildingPremiumTotal = _BuildingPremiumTotal + (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["BuildingLimitFire"];
                _ContentsPremiumTotal = _ContentsPremiumTotal + (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["ContentsLimitFire"];
                _AdditionalCoveragesPremiumTotal = _AdditionalCoveragesPremiumTotal + SetAdditionalCoverageTotalPremium(_taskcontrol.AdditionalCoveragesPropertiesCollection2);

                TxtLoanNo1.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["LoanNo"].ToString();
                TxtBank1.Text = LookupTables.GetDescription("Bank", _taskcontrol.PropertiesCollection.Rows[_index - 1]["Bank"].ToString().Trim());

                TxtRes4.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["Description"].ToString().Trim();
            }

            if (_index == 3) // (_taskcontrol.PropertiesCollection.Rows.Count > 2)
            {
                TxtDeducible.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["Deductible"].ToString();

                TxtRes1.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["Address1"].ToString();
                TxtRes2.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["Address2"].ToString();
                TxtRes3.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["City"].ToString() + ",  " +
                    _taskcontrol.PropertiesCollection.Rows[_index - 1]["State"].ToString() + "  " +
                    _taskcontrol.PropertiesCollection.Rows[_index - 1]["ZipCode"].ToString();
                _PremTotal = (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["TotalPremium"];

                _BuildingPremiumTotal = _BuildingPremiumTotal + (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["BuildingLimitFire"];
                _ContentsPremiumTotal = _ContentsPremiumTotal + (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["ContentsLimitFire"];
                _AdditionalCoveragesPremiumTotal = _AdditionalCoveragesPremiumTotal + SetAdditionalCoverageTotalPremium(_taskcontrol.AdditionalCoveragesPropertiesCollection3);

                TxtLoanNo1.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["LoanNo"].ToString();
                TxtBank1.Text = LookupTables.GetDescription("Bank", _taskcontrol.PropertiesCollection.Rows[_index - 1]["Bank"].ToString().Trim());

                TxtRes4.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["Description"].ToString().Trim();
            }

            if (_index == 4) // (_taskcontrol.PropertiesCollection.Rows.Count > 3)
            {
                TxtDeducible.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["Deductible"].ToString();

                TxtRes1.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["Address1"].ToString();
                TxtRes2.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["Address2"].ToString();
                TxtRes3.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["City"].ToString() + ",  " +
                    _taskcontrol.PropertiesCollection.Rows[_index - 1]["State"].ToString() + "  " +
                    _taskcontrol.PropertiesCollection.Rows[_index - 1]["ZipCode"].ToString();
                _PremTotal = (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["TotalPremium"];

                _BuildingPremiumTotal = _BuildingPremiumTotal + (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["BuildingLimitFire"];
                _ContentsPremiumTotal = _ContentsPremiumTotal + (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["ContentsLimitFire"];
                _AdditionalCoveragesPremiumTotal = _AdditionalCoveragesPremiumTotal + SetAdditionalCoverageTotalPremium(_taskcontrol.AdditionalCoveragesPropertiesCollection4);

                TxtLoanNo1.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["LoanNo"].ToString();
                TxtBank1.Text = LookupTables.GetDescription("Bank", _taskcontrol.PropertiesCollection.Rows[_index - 1]["Bank"].ToString().Trim());

                TxtRes4.Text = _taskcontrol.PropertiesCollection.Rows[_index - 1]["Description"].ToString().Trim();
            }
  
            //TxtBuildingPremiumTotal.Text = _BuildingPremiumTotal.ToString("$##,###,###.00");
            //TxtContentsPremiumTotal.Text = _ContentsPremiumTotal.ToString("$##,###,###.00");
            //TxtAdditionalCoveragesPremiumTotal.Text = _AdditionalCoveragesPremiumTotal.ToString("$##,###,###.00");  
            TxtBuildingPremiumTotal.Text = _BuildingPremiumTotal.ToString("##,###,###");
            double BuildingPercent = _BuildingPremiumTotal * .10;
            if (BuildingPercent == 0)
                TxtBuilding10.Text = "";
            else
                TxtBuilding10.Text = BuildingPercent.ToString("##,###,###");

            double ContentsPercent = 0.00;
            if(_BuildingPremiumTotal > 0.00) //Si existe prima de estructura se calcula en base a la estructura, de lo contrario se calcula en base al contenido.
                ContentsPercent = _BuildingPremiumTotal * .20;
            else
                 ContentsPercent = _ContentsPremiumTotal * .20;

            TxtContentsPremiumTotal.Text = _ContentsPremiumTotal.ToString("##,###,###");
           
            if (ContentsPercent == 0)
                TxtContents10.Text = "";
            else
                TxtContents10.Text = ContentsPercent.ToString("##,###,###");
            
            TxtAdditionalCoveragesPremiumTotal.Text = "";
            TxtPrimaTotalSeccionI.Text = _taskcontrol.PropertiesPremium.ToString("$##,###,###.00");


            if (_taskcontrol.EnteredBy.Trim() != "")
                lblEnteredBy.Text = "Por: " + _taskcontrol.EnteredBy.Trim();
            else
                lblEnteredBy.Text = "";
        }

        private double SetAdditionalCoverageTotalPremium(DataTable dt)
        {
            double prem = 0.00;
            for (int a = 0; dt.Rows.Count - 1 >= a; a++)
            {
                prem = prem + double.Parse(dt.Rows[a]["Premium"].ToString());
            }
            return prem;
        }
    }
}
