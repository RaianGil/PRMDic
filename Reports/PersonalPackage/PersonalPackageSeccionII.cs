using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.Customer;
using EPolicy.LookupTables;
using EPolicy.TaskControl;

namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for PersonalPackageSeccionII.
    /// </summary>
    public partial class PersonalPackageSeccionII : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.OptimaPersonalPackage _taskcontrol;
        private double _PremTotal = 0.00;
        private double _MedicalPrem = 0.00;
 
        public PersonalPackageSeccionII(EPolicy.TaskControl.OptimaPersonalPackage taskcontrol, string copy)
        {
            _taskcontrol = taskcontrol;
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void PersonalPackageSeccionII_ReportStart(object sender, EventArgs e)
        {
            txtPolicyNo.Text = _taskcontrol.PolicyType.ToString().ToUpper().Trim() + " " + _taskcontrol.PolicyNo.ToString().Trim() + " " + _taskcontrol.Certificate.ToString().Trim();
            txtEffectiveDate.Text = _taskcontrol.EffectiveDate.ToString();
            txtExpirationDate.Text = _taskcontrol.ExpirationDate.ToString();
            txtEmision.Text = _taskcontrol.EntryDate.ToShortDateString();
            txtLiabEnd.Text = "OPP RP 0001 07 07; " +_taskcontrol.LiabEnd.Trim();
            txtCustomerName.Text = _taskcontrol.Customer.FirstName.Trim() + " " + _taskcontrol.Customer.Initial.Trim() + " " +
                        _taskcontrol.Customer.LastName1.Trim() + " " + _taskcontrol.Customer.LastName2.Trim();

            if (_taskcontrol.EnteredBy.Trim() != "")
                lblEnteredBy.Text = "Por: " + _taskcontrol.EnteredBy.Trim();
            else
                lblEnteredBy.Text = "";

            //Seccion II
            if (_taskcontrol.PersonalLiabilityCollection.Rows.Count > 0)
            {
                int med = (int)_taskcontrol.PersonalLiabilityCollection.Rows[0]["MedicalPayment1"];
                int per = (int)_taskcontrol.PersonalLiabilityCollection.Rows[0]["PersonalLiability1"];
                txtMedicalLimit.Text = med.ToString("###,###,###");
                txtLiabilityLimit.Text = per.ToString("###,###,###");

                _MedicalPrem = 0.0;
                _MedicalPrem = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["MedicalPrem1"];
                _MedicalPrem = _MedicalPrem + (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["MedicalPrem2"];
                _MedicalPrem = _MedicalPrem + (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["MedicalPrem3"];
                _MedicalPrem = _MedicalPrem + (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["MedicalPrem4"];
                txtMedicalPremium.Text = _MedicalPrem.ToString("###,###.00");

                _PremTotal = 0.0;
                _PremTotal = (double)_taskcontrol.PersonalLiabilityCollection.Rows[0]["TotalPremium"];
                double Premium = _PremTotal - _MedicalPrem;

                txtPremium.Text = Premium.ToString("###,###.00");
                TxtPrimaTotalSeccionII.Text = _PremTotal.ToString("###,###.00");
                
                TxtRes1.Text = "";
                TxtRes2.Text = "";
                TxtRes3.Text = "";
                TxtRes4.Text = "";
            
                for (int b = 0; b <= _taskcontrol.PropertiesCollection.Rows.Count - 1; b++)
                {
                    if (_taskcontrol.PropertiesCollection.Rows[b]["Address1"].ToString().Trim() == _taskcontrol.PersonalLiabilityCollection.Rows[0]["Residence1"].ToString().Trim())
                    {
                        TxtRes1.Text = _taskcontrol.PropertiesCollection.Rows[b]["Address1"].ToString().Trim() + " " +
                            _taskcontrol.PropertiesCollection.Rows[b]["Address2"].ToString().Trim();
                        TxtRes1B.Text = _taskcontrol.PropertiesCollection.Rows[b]["City"].ToString().Trim() + " " +
                            _taskcontrol.PropertiesCollection.Rows[b]["State"].ToString().Trim()+ " " +
                            _taskcontrol.PropertiesCollection.Rows[b]["ZipCode"].ToString().Trim();
                    }
                }

                for (int b = 0; b <= _taskcontrol.PropertiesCollection.Rows.Count - 1; b++)
                {
                    if (_taskcontrol.PropertiesCollection.Rows[b]["Address1"].ToString().Trim() == _taskcontrol.PersonalLiabilityCollection.Rows[0]["Residence2"].ToString().Trim())
                    {
                        TxtRes2.Text = _taskcontrol.PropertiesCollection.Rows[b]["Address1"].ToString().Trim() + " " +
                            _taskcontrol.PropertiesCollection.Rows[b]["Address2"].ToString().Trim();
                        TxtRes2B.Text = _taskcontrol.PropertiesCollection.Rows[b]["City"].ToString().Trim() + " " +
                            _taskcontrol.PropertiesCollection.Rows[b]["State"].ToString().Trim() + " " +
                            _taskcontrol.PropertiesCollection.Rows[b]["ZipCode"].ToString().Trim();
                    }
                }

                for (int b = 0; b <= _taskcontrol.PropertiesCollection.Rows.Count - 1; b++)
                {
                    if (_taskcontrol.PropertiesCollection.Rows[b]["Address1"].ToString().Trim() == _taskcontrol.PersonalLiabilityCollection.Rows[0]["Residence3"].ToString().Trim())
                    {
                        TxtRes3.Text = _taskcontrol.PropertiesCollection.Rows[b]["Address1"].ToString().Trim() + " " +
                            _taskcontrol.PropertiesCollection.Rows[b]["Address2"].ToString().Trim();
                        TxtRes3B.Text = _taskcontrol.PropertiesCollection.Rows[b]["City"].ToString().Trim() + " " +
                            _taskcontrol.PropertiesCollection.Rows[b]["State"].ToString().Trim() + " " +
                            _taskcontrol.PropertiesCollection.Rows[b]["ZipCode"].ToString().Trim();
                    }
                }

                for (int b = 0; b <= _taskcontrol.PropertiesCollection.Rows.Count - 1; b++)
                {
                    if (_taskcontrol.PropertiesCollection.Rows[b]["Address1"].ToString().Trim() == _taskcontrol.PersonalLiabilityCollection.Rows[0]["Residence4"].ToString().Trim())
                    {
                        TxtRes4.Text = _taskcontrol.PropertiesCollection.Rows[b]["Address1"].ToString().Trim() + " " +
                            _taskcontrol.PropertiesCollection.Rows[b]["Address2"].ToString().Trim();
                        TxtRes4B.Text = _taskcontrol.PropertiesCollection.Rows[b]["City"].ToString().Trim() + " " +
                            _taskcontrol.PropertiesCollection.Rows[b]["State"].ToString().Trim() + " " +
                            _taskcontrol.PropertiesCollection.Rows[b]["ZipCode"].ToString().Trim();
                    }
                }

                //TxtRes1.Text = _taskcontrol.PersonalLiabilityCollection.Rows[0]["Residence1"].ToString();
                //TxtRes2.Text = _taskcontrol.PersonalLiabilityCollection.Rows[0]["Residence2"].ToString();
                //TxtRes3.Text = _taskcontrol.PersonalLiabilityCollection.Rows[0]["Residence3"].ToString();
                //TxtRes4.Text = _taskcontrol.PersonalLiabilityCollection.Rows[0]["Residence4"].ToString();

                if(TxtRes1.Text.Trim() != "")
                    txtFam1.Text = _taskcontrol.PersonalLiabilityCollection.Rows[0]["Families1"].ToString();

                if (TxtRes2.Text.Trim() != "")
                    txtFam2.Text = _taskcontrol.PersonalLiabilityCollection.Rows[0]["Families2"].ToString();

                if (TxtRes3.Text.Trim() != "")
                    txtFam3.Text = _taskcontrol.PersonalLiabilityCollection.Rows[0]["Families3"].ToString();

                if (TxtRes4.Text.Trim() != "")
                    txtFam4.Text = _taskcontrol.PersonalLiabilityCollection.Rows[0]["Families4"].ToString();

                if (_taskcontrol.AdditionalCoveragesLiabilityCollection.Rows.Count > 0)
                {
                    txtAddCover1.Text = "1. " +_taskcontrol.AdditionalCoveragesLiabilityCollection.Rows[0]["AdditionalCoverageLiabilityDesc"].ToString();
                }

                if (_taskcontrol.AdditionalCoveragesLiabilityCollection.Rows.Count > 1)
                {
                    txtAddCover2.Text = "2. " + _taskcontrol.AdditionalCoveragesLiabilityCollection.Rows[1]["AdditionalCoverageLiabilityDesc"].ToString();
                }

                if (_taskcontrol.AdditionalCoveragesLiabilityCollection.Rows.Count > 2)
                {
                    txtAddCover3.Text = "3. " + _taskcontrol.AdditionalCoveragesLiabilityCollection.Rows[2]["AdditionalCoverageLiabilityDesc"].ToString();
                }

                if (_taskcontrol.AdditionalCoveragesLiabilityCollection.Rows.Count > 3)
                {
                    txtAddCover4.Text = "4. " + _taskcontrol.AdditionalCoveragesLiabilityCollection.Rows[3]["AdditionalCoverageLiabilityDesc"].ToString();
                }

                if (_taskcontrol.AdditionalCoveragesLiabilityCollection.Rows.Count > 4)
                {
                    txtAddCover5.Text = "5. " + _taskcontrol.AdditionalCoveragesLiabilityCollection.Rows[4]["AdditionalCoverageLiabilityDesc"].ToString();
                }

                if (_taskcontrol.AdditionalCoveragesLiabilityCollection.Rows.Count > 5)
                {
                    txtAddCover6.Text = "6. " + _taskcontrol.AdditionalCoveragesLiabilityCollection.Rows[5]["AdditionalCoverageLiabilityDesc"].ToString();
                }
            }
            else
            {
                txtMedicalPremium.Text = "$0.00";
                TxtPrimaTotalSeccionII.Text = "$0.00";
            }
        }
    }
}
