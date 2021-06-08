using System;
using System.Data;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.Customer;
using EPolicy.LookupTables;
using EPolicy.TaskControl;

namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for PersonalPackageQuote.
    /// </summary>
    public partial class PersonalPackageQuote : DataDynamics.ActiveReports.ActiveReport3
    {
        private int CountDataIndex = 1;
        private int index = 0;
        private double _PremTotal;
        private EPolicy.TaskControl.OptimaPersonalPackage _taskcontrol;

        public PersonalPackageQuote(EPolicy.TaskControl.OptimaPersonalPackage taskcontrol)
        {
            _taskcontrol = taskcontrol;            
            InitializeComponent();
        }

        private void PersonalPackageQuote_ReportStart(object sender, EventArgs e)
        {
            //Header
            txtCotizacionNo.Text = _taskcontrol.TaskControlID.ToString().Trim();
            TxtFecha.Text = _taskcontrol.EntryDate.ToShortDateString();
            TxtCustomerName.Text = _taskcontrol.Prospect.FirstName.Trim() + " " + _taskcontrol.Prospect.LastName1.Trim() + " " +
                _taskcontrol.Prospect.LastName2.Trim();

            if (_taskcontrol.PropertiesCollection.Rows.Count != 0)
            {
                for (int i = 0; i < _taskcontrol.PropertiesCollection.Rows.Count; i++)
                {
                    if ((bool)_taskcontrol.PropertiesCollection.Rows[i]["Primary"] == true)
                    {
                        TxtAdds1.Text = _taskcontrol.PropertiesCollection.Rows[i]["Address1"].ToString().Trim();
                        if (_taskcontrol.PropertiesCollection.Rows[i]["Address2"].ToString().Trim() != "")
                        {
                            TxtAdds2.Text = _taskcontrol.PropertiesCollection.Rows[i]["Address2"].ToString().Trim();
                            TxtCitySTZip.Text = _taskcontrol.PropertiesCollection.Rows[i]["City"].ToString().Trim() + ", " +
                            _taskcontrol.PropertiesCollection.Rows[i]["State"].ToString().Trim() + "  " +
                            _taskcontrol.PropertiesCollection.Rows[i]["ZipCode"].ToString().Trim();
                        }
                        else
                        {
                            TxtAdds2.Text = _taskcontrol.PropertiesCollection.Rows[i]["City"].ToString().Trim() + ", " +
                            _taskcontrol.PropertiesCollection.Rows[i]["State"].ToString().Trim() + "  " +
                            _taskcontrol.PropertiesCollection.Rows[i]["ZipCode"].ToString().Trim();
                            TxtCitySTZip.Text = "";
                        }

                    }
                }
            }
        }

        private void PersonalPackageQuote_FetchData(object sender, FetchEventArgs eArgs)
        {
            try
            {
                if (this.CountDataIndex <= _taskcontrol.PropertiesCollection.Rows.Count)
                {
                    eArgs.EOF = false;
                    LblResidencia.Text = "Residencia #"+CountDataIndex.ToString();

                    TxtRes1.Text = _taskcontrol.PropertiesCollection.Rows[index]["Address1"].ToString() + " " +
                    _taskcontrol.PropertiesCollection.Rows[index]["Address2"].ToString() + " " +
                    _taskcontrol.PropertiesCollection.Rows[index]["City"].ToString() + ",  " +
                    _taskcontrol.PropertiesCollection.Rows[index]["State"].ToString() + "  " +
                    _taskcontrol.PropertiesCollection.Rows[index]["ZipCode"].ToString();

                    txtDeductible.Text = ((int) _taskcontrol.PropertiesCollection.Rows[index]["Deductible"]).ToString().Trim()+"%";
                    switch ((int)_taskcontrol.PropertiesCollection.Rows[index]["ConstructionType"])
                    {
                        case 1:
                            TxtConstructionType.Text = "Concrete";
                            break;
                        case 2:
                            TxtConstructionType.Text = "Masonry";
                            break;
                        case 3:
                            TxtConstructionType.Text = "Frame";
                            break;
                    }


                    //Building
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingLimitFire"]);
                    TxtBuildingLimitFire.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingLimitExtCoverage"]);
                    TxtBuildingLimitExtCov.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingLimitVandalism"]);
                    TxtBuildingLimitVandalism.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingLimitEarthquake"]);
                    TxtBuildingLimitEarthquake.Text = _PremTotal.ToString("###,###.00");

                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingRateFire"]);
                    TxtBuildingRateFire.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingRateExtCoverage"]);
                    TxtBuildingRateExtCov.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingRateVandalism"]);
                    TxtBuildingRateVandalism.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingRateEarthquake"]);
                    TxtBuildingRateEarthquake.Text = _PremTotal.ToString("###,###.00");

                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingFactorFire"]);
                    TxtBuildingFactorFire.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingFactorExtCoverage"]);
                    TxtBuildingFactorExtCov.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingFactorVandalism"]);
                    TxtBuildingFactorVandalism.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingFactorEarthquake"]);
                    TxtBuildingFactorEarthquake.Text = _PremTotal.ToString("###,###.00");

                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingTotalFire"]);
                    TxtBuildingTotalRateFire.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingTotalExtCoverage"]);
                    TxtBuildingTotalRateExtCov.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingTotalVandalism"]);
                    TxtBuildingTotalRateVandalism.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingTotalEarthquake"]);
                    TxtBuildingTotalRateEarthquake.Text = _PremTotal.ToString("###,###.00");

                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingPremiumFire"]);
                    TxtBuildingPremiumFire.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingPremiumExtCoverage"]);
                    TxtBuildingPremiumExtCov.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingPremiumVandalism"]);
                    TxtBuildingPremiumVandalism.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingPremiumEarthquake"]);
                    TxtBuildingPremiumEarthquake.Text = _PremTotal.ToString("###,###.00");

                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["BuildingPremiumTotal"]);
                    TxtBuildingTotalPremium.Text = _PremTotal.ToString("###,###.00");
                    

                    //Contents
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsLimitFire"]);
                    TxtContentLimitFire.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsLimitExtCoverage"]);
                    TxtContentLimitExtCov.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsLimitVandalism"]);
                    TxtContentLimitVandalism.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsLimitEarthquake"]);
                    TxtContentLimitEarthquake.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsLimitAOP"]);
                    TxtContentLimitAOP.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsLimitExcessAOP"]);
                    TxtContentLimitExcess.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsLimitTheft"]);
                    TxtContentLimitTheft.Text = _PremTotal.ToString("###,###.00");

                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsRateFire"]);
                    TxtContentRateFire.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsRateExtCoverage"]);
                    TxtContentRateExtCov.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsRateVandalism"]);
                    TxtContentRateVandalism.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsRateEarthquake"]);
                    TxtContentRateEartquake.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsRateAOP"]);
                    TxtContentRateAOP.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsRateExcessAOP"]);
                    TxtContentRateExcess.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsRateTheft"]);
                    TxtContentRateTheft.Text = _PremTotal.ToString("###,###.00");

                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsFactorFire"]);
                    TxtContentFactorFire.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsFactorExtCoverage"]);
                    TxtContentFactorExtCov.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsFactorVandalism"]);
                    TxtContentFactorVandalism.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsFactorEarthquake"]);
                    TxtContentFactorEarthquake.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsFactorAOP"]);
                    TxtContentFactorAOP.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsFactorExcessAOP"]);
                    TxtContentFactorExcess.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsFactorTheft"]);
                    TxtContentFactorTheft.Text = _PremTotal.ToString("###,###.00");

                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsTotalFire"]);
                    TxtContentTotalRateFire.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsTotalExtCoverage"]);
                    TxtContentTotalRateExtCov.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsTotalVandalism"]);
                    TxtContentTotalRateVandalism.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsTotalEarthquake"]);
                    TxtContentTotalRateEarthquake.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsTotalAOP"]);
                    TxtContentTotalRateAOP.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsTotalExcessAOP"]);
                    TxtContentTotalRateExcess.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsTotalTheft"]);
                    TxtContentTotalRateTheft.Text = _PremTotal.ToString("###,###.00");

                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsPremiumFire"]);
                    TxtContentPremiumFire.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsPremiumExtCoverage"]);
                    TxtContentPremiumExtCov.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsPremiumVandalism"]);
                    TxtContentPremiumVandalism.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsPremiumEarthquake"]);
                    TxtContentPremiumEarthquake.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsPremiumAOP"]);
                    TxtContentPremiumAOP.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsPremiumExcessAOP"]);
                    TxtContentPremiumExcessAOP.Text = _PremTotal.ToString("###,###.00");
                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsPremiumTheft"]);
                    TxtContentPremiumTheft.Text = _PremTotal.ToString("###,###.00");

                    _PremTotal = ((double)_taskcontrol.PropertiesCollection.Rows[index]["ContentsPremiumTotal"]);
                    TxtContentsTotalPremium.Text = _PremTotal.ToString("###,###.00");

                    if (CountDataIndex == 1)
                        TxtTotalAdditionalCoverage.Text = SetAdditionalCoverageTotalPremium(_taskcontrol.AdditionalCoveragesPropertiesCollection1).ToString("###,###,###.00");

                    if (CountDataIndex == 2)
                        TxtTotalAdditionalCoverage.Text = SetAdditionalCoverageTotalPremium(_taskcontrol.AdditionalCoveragesPropertiesCollection2).ToString("###,###,###.00");

                    if (CountDataIndex == 3)
                        TxtTotalAdditionalCoverage.Text = SetAdditionalCoverageTotalPremium(_taskcontrol.AdditionalCoveragesPropertiesCollection3).ToString("###,###,###.00");

                    if (CountDataIndex == 4)
                        TxtTotalAdditionalCoverage.Text = SetAdditionalCoverageTotalPremium(_taskcontrol.AdditionalCoveragesPropertiesCollection4).ToString("###,###,###.00");

                    TxtSubTotalPrem.Text = ((double)_taskcontrol.PropertiesCollection.Rows[index]["SubTotalPremium"]).ToString("###,###.00");
                    txtCharge.Text = ((double)_taskcontrol.PropertiesCollection.Rows[index]["Charge"]).ToString("###,###.00");
                    TxtPrimaRes.Text = ((double)_taskcontrol.PropertiesCollection.Rows[index]["TotalPremium"]).ToString("###,###.00");

                    if (_taskcontrol.PropertiesCollection.Rows[index]["ExperienceCredit"].ToString().Trim() != "0")
                    {
                        int credit1 = (int)_taskcontrol.PropertiesCollection.Rows[index]["ExperienceCredit"];
                        double credit = Math.Round(double.Parse(TxtSubTotalPrem.Text) * ((double.Parse(credit1.ToString())) / 100), 0);
                        credit = credit * -1;
                        TxtExperienceCredit.Text = credit.ToString("##,###.00");
                    }

                    _PremTotal = (double)_taskcontrol.PropertiesCollection.Rows[index]["TotalPremium"];
                    TxtPrimaRes.Text = _PremTotal.ToString("###,###.00");

                    SetPremiumNet(TxtPrimaRes.Text, TxtSubTotalPrem.Text);
                    SetPointCode(_taskcontrol.PropertiesCollection.Rows[index]["City"].ToString());

                    if (this.CountDataIndex == _taskcontrol.PropertiesCollection.Rows.Count)
                    {
                        lblPrimaSeccionI.Visible = true;
                        txtPropertiesPremium.Visible = true;
                        this.shape7.Visible = true;
                        txtPropertiesPremium.Text = _taskcontrol.PropertiesPremium.ToString("$###,###.00");
                    }
                }
                else
                {
                    //TxtCopyValue.Text = _CopyValue;
                    eArgs.EOF = true;
                }

                this.CountDataIndex++;
                this.index++;
            }
            catch (Exception exc)
            {
                if (eArgs != null)
                    eArgs.EOF = true;
            }
        }

        private void SetPremiumNet(string TotPrima, string SubTotalPrima)
        {
            double sumaPrem = 0.00;
            double tempTot = 0.00;
            double totprem = double.Parse(TotPrima);
            double subtotprem = double.Parse(SubTotalPrima);
            double percent = totprem / double.Parse(SubTotalPrima);
            percent = Math.Round(percent, 4);

            tempTot = 0.00;
            tempTot = Math.Round(double.Parse(TxtBuildingPremiumFire.Text) * percent,0);
            sumaPrem = sumaPrem + tempTot;
            txtNeto1.Text = tempTot.ToString("###,###.00");

            tempTot = 0.00;
            tempTot = Math.Round(double.Parse(TxtBuildingPremiumExtCov.Text) * percent,0);
            sumaPrem = sumaPrem + tempTot;
            txtNeto2.Text = tempTot.ToString("###,###.00");

            tempTot = 0.00;
            tempTot = Math.Round(double.Parse(TxtBuildingPremiumVandalism.Text) * percent,0);
            sumaPrem = sumaPrem + tempTot;
            txtNeto3.Text = tempTot.ToString("###,###.00");

            tempTot = 0.00;
            tempTot = Math.Round(double.Parse(TxtBuildingPremiumEarthquake.Text) * percent,0);
            sumaPrem = sumaPrem + tempTot;
            txtNeto4.Text = tempTot.ToString("###,###.00");

            tempTot = 0.00;
            //tempTot = Math.Round(double.Parse(TxtBuildingTotalPremium.Text) * percent, 0);
            txtNeto5.Text = sumaPrem.ToString("###,###.00");  // tempTot.ToString("###,###.00");

            sumaPrem = 0.00;
            tempTot = 0.00;
            tempTot = Math.Round(double.Parse(TxtContentPremiumFire.Text) * percent, 0);
            sumaPrem = sumaPrem + tempTot;
            txtNeto6.Text = tempTot.ToString("###,###.00");

            tempTot = 0.00;
            tempTot = Math.Round(double.Parse(TxtContentPremiumExtCov.Text) * percent, 0);
            sumaPrem = sumaPrem + tempTot;
            txtNeto7.Text = tempTot.ToString("###,###.00");

            tempTot = 0.00;
            tempTot = Math.Round(double.Parse(TxtContentPremiumVandalism.Text) * percent, 0);
            sumaPrem = sumaPrem + tempTot;
            txtNeto8.Text = tempTot.ToString("###,###.00");

            tempTot = 0.00;
            tempTot = Math.Round(double.Parse(TxtContentPremiumEarthquake.Text) * percent, 0);
            sumaPrem = sumaPrem + tempTot;
            txtNeto9.Text = tempTot.ToString("###,###.00");

            tempTot = 0.00;
            tempTot = Math.Round(double.Parse(TxtContentPremiumAOP.Text) * percent, 0);
            sumaPrem = sumaPrem + tempTot;
            txtNeto10.Text = tempTot.ToString("###,###.00");

            tempTot = 0.00;
            tempTot = Math.Round(double.Parse(TxtContentPremiumExcessAOP.Text) * percent, 0);
            sumaPrem = sumaPrem + tempTot;
            txtNeto11.Text = tempTot.ToString("###,###.00");

            tempTot = 0.00;
            tempTot = Math.Round(double.Parse(TxtContentPremiumTheft.Text) * percent, 0);
            sumaPrem = sumaPrem + tempTot;
            txtNeto12.Text = tempTot.ToString("###,###.00");

            tempTot = 0.00;
            tempTot = Math.Round(double.Parse(TxtContentsTotalPremium.Text) * percent, 0);
            txtNeto13.Text = sumaPrem.ToString("###,###.00");  //tempTot.ToString("###,###.00");

            tempTot = 0.00;
            tempTot = Math.Round(double.Parse(TxtTotalAdditionalCoverage.Text) * percent, 0);
            txtNeto14.Text = tempTot.ToString("###,###.00");

            if (double.Parse(TxtPrimaRes.Text) != double.Parse(txtNeto5.Text) + double.Parse(txtNeto13.Text) + double.Parse(txtNeto14.Text))
            {
                double sumaSubTot = double.Parse(txtNeto5.Text) + double.Parse(txtNeto13.Text) + double.Parse(txtNeto14.Text);
                double sumaTot = double.Parse(TxtPrimaRes.Text);
                double dif = sumaTot - sumaSubTot;

                if (double.Parse(TxtPrimaRes.Text) > double.Parse(txtNeto5.Text) + double.Parse(txtNeto13.Text) + double.Parse(txtNeto14.Text))
                {
                    if (double.Parse(TxtContentsTotalPremium.Text.Trim()) > 0)
                    {
                        sumaSubTot = double.Parse(txtNeto12.Text) + Math.Abs(dif);
                        txtNeto12.Text = sumaSubTot.ToString("###,###.00");

                        sumaSubTot = double.Parse(txtNeto13.Text) + Math.Abs(dif);
                        txtNeto13.Text = sumaSubTot.ToString("###,###.00");
                    }
                    else
                    {
                        if (double.Parse(TxtBuildingTotalPremium.Text.Trim()) > 0)
                        {
                            sumaSubTot = double.Parse(txtNeto4.Text) + Math.Abs(dif);
                            txtNeto4.Text = sumaSubTot.ToString("###,###.00");

                            sumaSubTot = double.Parse(txtNeto5.Text) + Math.Abs(dif);
                            txtNeto5.Text = sumaSubTot.ToString("###,###.00");
                        }
                    }
                }
                else
                {
                    if (double.Parse(TxtContentsTotalPremium.Text.Trim()) > 0)
                    {
                        sumaSubTot = double.Parse(txtNeto12.Text) - Math.Abs(dif);
                        txtNeto12.Text = sumaSubTot.ToString("###,###.00");

                        sumaSubTot = double.Parse(txtNeto13.Text) - Math.Abs(dif);
                        txtNeto13.Text = sumaSubTot.ToString("###,###.00");
                    }
                    else
                    {
                        if (double.Parse(TxtBuildingTotalPremium.Text.Trim()) > 0)
                        {
                            sumaSubTot = double.Parse(txtNeto4.Text) - Math.Abs(dif);
                            txtNeto4.Text = sumaSubTot.ToString("###,###.00");

                            sumaSubTot = double.Parse(txtNeto5.Text) - Math.Abs(dif);
                            txtNeto5.Text = sumaSubTot.ToString("###,###.00");
                        }
                    }
                }
            }
        }

        private void SetPointCode(string City)
        {
            if (City.Trim() == "SAN JUAN")
            {
                txtTerr1.Text = "030";
                txtTerr2.Text = "030";
            }
            else
            {
                if (City.Trim() == "PONCE")
                {
                    txtTerr1.Text = "031";
                    txtTerr2.Text = "031";
                }
                else
                {
                    txtTerr1.Text = "032";
                    txtTerr2.Text = "032";
                }
            }              


            txtPCFire1.Text = PrintPolicy.GetPointCode("Properties", "Building", "Fire") + " - " +
                PrintPolicy.GetPointCode("Properties", "Properties", "Fire");
            txtPCExtCov1.Text = PrintPolicy.GetPointCode("Properties", "Building", "ExtendedCoverage") + " - " + 
                PrintPolicy.GetPointCode("Properties", "Properties", "ExtendedCoverage");
            txtPCVandalism1.Text = PrintPolicy.GetPointCode("Properties", "Building", "Vandalism") + " - " + 
                PrintPolicy.GetPointCode("Properties", "Properties", "Vandalism");
            txtPCEarthquake1.Text = PrintPolicy.GetPointCode("Properties", "Building", "Earthquake") + " - " + 
                PrintPolicy.GetPointCode("Properties", "Properties", "Earthquake");

            txtPCFire2.Text = PrintPolicy.GetPointCode("Properties", "Contents", "Fire") + " - " + 
                PrintPolicy.GetPointCode("Properties", "Properties", "Fire");
            txtPCExtCov2.Text = PrintPolicy.GetPointCode("Properties", "Contents", "ExtendedCoverage") + " - " + 
                PrintPolicy.GetPointCode("Properties", "Properties", "ExtendedCoverage");
            txtPCVandalism2.Text = PrintPolicy.GetPointCode("Properties", "Contents", "Vandalism") + " - " + 
                PrintPolicy.GetPointCode("Properties", "Properties", "Vandalism");
            txtPCEarthquake2.Text = PrintPolicy.GetPointCode("Properties", "Contents", "Earthquake") + " - " + 
                PrintPolicy.GetPointCode("Properties", "Properties", "Earthquake");
            txtPCAOP2.Text = PrintPolicy.GetPointCode("Properties", "Contents", "AOP") + " - " + 
                PrintPolicy.GetPointCode("Properties", "Properties", "AOP");
            txtPCTheft2.Text = PrintPolicy.GetPointCode("Properties", "Contents", "Theft") + " - " + 
                PrintPolicy.GetPointCode("Properties", "Properties", "Theft");

            txtPCExcessAOP2.Text = ""; //PrintPolicy.GetPointCode("Properties", "Properties", "Fire");

            string deduc = _taskcontrol.PropertiesCollection.Rows[index]["Deductible"].ToString();
            double temp = (double.Parse(deduc)) / 100;
            temp = temp * double.Parse(TxtContentLimitFire.Text);
            txtPCContentDed2.Text = temp.ToString("###,###,###.00");
            temp = double.Parse(TxtContentLimitFire.Text) * .05;
            txtPCContentDed5.Text = temp.ToString("###,###,###.00");


            deduc = _taskcontrol.PropertiesCollection.Rows[index]["Deductible"].ToString();
            temp = (double.Parse(deduc)) / 100;
            temp = temp * double.Parse(TxtBuildingLimitFire.Text);
            txtPCBuildingDed2.Text = temp.ToString("###,###,###.00");
            temp = double.Parse(TxtBuildingLimitFire.Text) * .05;
            txtPCBuildingDed5.Text = temp.ToString("###,###,###.00");
            
            switch ((int)_taskcontrol.PropertiesCollection.Rows[index]["ConstructionType"])
            {
                case 1:
                    txtPCConsType.Text = "4";
                    break;
                case 2:
                    txtPCConsType.Text = "3";
                    break;
                case 3:
                    txtPCConsType.Text = "1";
                    break;
            }

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
