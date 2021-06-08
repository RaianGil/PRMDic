using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.Customer;
using EPolicy.LookupTables;
using EPolicy.TaskControl;

namespace EPolicy2.Reports
{
    public partial class DEDUCIBLESSECCION : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.OptimaPersonalPackage _taskcontrol;
        private int _index = 0;

        public DEDUCIBLESSECCION(EPolicy.TaskControl.OptimaPersonalPackage taskcontrol,string copy, int index)
        {
            _taskcontrol = taskcontrol;
            _index = index;

            InitializeComponent();
        }

        private void DEDUCIBLESSECCION_ReportStart(object sender, EventArgs e)
        {
            //Seccion I
            //if (_index == 1) //(_taskcontrol.PropertiesCollection.Rows.Count > 0)
            //{

            double amt2 = 0.00;
            amt2 = (double) _taskcontrol.PropertiesCollection.Rows[_index - 1]["BuildingLimitFire"];
            Txt1.Text = amt2.ToString("$###,###,###");

            amt2 = 0.00;
            amt2 = (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["BuildingLimitExtCoverage"];
            txt2.Text = amt2.ToString("$###,###,###");

            amt2 = 0.00;
            amt2 = (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["BuildingLimitTheft"];
            txt3.Text = amt2.ToString("$###,###,###");

            amt2 = 0.00;
            amt2 = (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["BuildingLimitEarthquake"];
            txt4.Text = amt2.ToString("$###,###,###");

            amt2 = 0.00;
            amt2 = (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["ContentsLimitFire"];
            txt5.Text = amt2.ToString("$###,###,###");

            amt2 = 0.00;
            amt2 = (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["ContentsLimitExtCoverage"];
            txt6.Text = amt2.ToString("$###,###,###");

            amt2 = 0.00;
            amt2 = (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["ContentsLimitTheft"];
            txt7.Text = amt2.ToString("$###,###,###");

            amt2 = 0.00;
            amt2 = (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["ContentsLimitEarthquake"];
            txt8.Text = amt2.ToString("$###,###,###");

                double Building10 = (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["BuildingLimitFire"];
                Building10 = Building10 * .10;

               if (Building10 == 0)
               {
                   txt9.Text = "";
                   txt10.Text = "";
                   txt11.Text = "";
                   txt12.Text = "";
               }
               else
               {
                   txt9.Text = Building10.ToString("$###,###,###");
                   txt10.Text = Building10.ToString("$###,###,###");
                   txt11.Text = Building10.ToString("$###,###,###");
                   txt12.Text = Building10.ToString("$###,###,###");
               }


                if((double) _taskcontrol.PropertiesCollection.Rows[_index-1]["BuildingLimitFire"] > 0)
                {
                  double Building20 = (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["BuildingLimitFire"];
                  Building20 = Building20 * .20;

                  txt13.Text = Building20.ToString("$###,###,###");
                  txt14.Text = Building20.ToString("$###,###,###");
                  txt15.Text = Building20.ToString("$###,###,###");
                }
                else
                {
                    double Contents20 = (double)_taskcontrol.PropertiesCollection.Rows[_index - 1]["ContentsLimitFire"];
                    Contents20 = Contents20 * .20;
                    
                  txt13.Text = Contents20.ToString("##,###,###");
                  txt14.Text = Contents20.ToString("##,###,###");
                  txt15.Text = Contents20.ToString("##,###,###");
                }
           //}
        }
    }
}
