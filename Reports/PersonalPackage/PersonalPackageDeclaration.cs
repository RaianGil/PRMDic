using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.Customer;
using EPolicy.LookupTables;
using EPolicy.TaskControl;

namespace EPolicy2.Reports
{
    public partial class PersonalPackageDeclaration : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.OptimaPersonalPackage _taskcontrol;
        private int CountDataIndex;

        public PersonalPackageDeclaration(EPolicy.TaskControl.OptimaPersonalPackage taskcontrol, string copy)
        {
            _taskcontrol = taskcontrol;

            InitializeComponent();
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {

        }

        private void PersonalPackageDeclaration_DataInitialize(object sender, EventArgs e)
        {
            txtPolicyNo.Text = "";
            txtCustomerName.Text = "";
            txtAdds1.Text = "";
            txtAdds2.Text = "";
            txtCustomerNo.Text = "";
            txtEffectiveDate.Text = "";
            txtExpirationDate.Text = "";
            txtPropertiesPremium.Text = "";
            txtLiabilityPremium.Text = "";
            txtAutoPremium.Text = "";
            txtUmbrellaPremium.Text = "";
            txtTotalPremium.Text = "";
            txtAgency.Text = "";
            txtAgent.Text = "";
            txtEmision.Text = "";
            lblEnteredBy.Text = "";
 
            CountDataIndex = 0;
        }

        private void PersonalPackageDeclaration_FetchData(object sender, FetchEventArgs eArgs)
        {
            try
            {
                if (this.CountDataIndex == 0)
                {
                    txtPolicyNo.Text = _taskcontrol.PolicyType.ToString().ToUpper().Trim() + " " + _taskcontrol.PolicyNo.ToString().Trim() + " " + _taskcontrol.Certificate.ToString().Trim();
                    txtCustomerName.Text = _taskcontrol.Customer.FirstName.Trim() + " " + _taskcontrol.Customer.Initial.Trim() + " " +
                        _taskcontrol.Customer.LastName1.Trim() + " " + _taskcontrol.Customer.LastName2.Trim();
                    txtAdds1.Text = _taskcontrol.Customer.Address1.Trim().ToUpper() + " " + _taskcontrol.Customer.Address2.Trim().ToUpper();
                    txtAdds2.Text = _taskcontrol.Customer.City.Trim() + " " + _taskcontrol.Customer.State.ToString().Trim() + " " + _taskcontrol.Customer.ZipCode.Trim();
                    txtEffectiveDate.Text = _taskcontrol.EffectiveDate.ToString();
                    txtExpirationDate.Text = _taskcontrol.ExpirationDate.ToString();
                    txtCustomerNo.Text = _taskcontrol.Customer.CustomerNo.Trim();

                    txtPropertiesPremium.Text = _taskcontrol.PropertiesPremium.ToString("$#,##0.00");
                    txtLiabilityPremium.Text = _taskcontrol.LiabilityPremium.ToString("$#,##0.00");
                    txtAutoPremium.Text = _taskcontrol.AutoPremium.ToString("$#,##0.00");
                    txtUmbrellaPremium.Text = _taskcontrol.UmbrellaPremium.ToString("$#,##0.00");
                    txtTotalPremium.Text = _taskcontrol.TotalPremium.ToString("$#,##0.00");

                    EPolicy.LookupTables.Agency agency = new Agency();
                    agency = agency.GetAgency(_taskcontrol.Agency);
                    txtAgency.Text = _taskcontrol.Agency + " -  " + agency.AgencyDesc.ToString().Trim();

                    EPolicy.LookupTables.Agent agent = new Agent();
                    agent = agent.GetAgent(_taskcontrol.Agent);
                    txtAgent.Text = agent.CarsID.Trim() + " -  " + agent.AgentDesc.ToString().Trim();

                    txtEmision.Text = _taskcontrol.EntryDate.ToShortDateString();

                    if (_taskcontrol.EnteredBy.Trim() != "")
                        lblEnteredBy.Text = "Por: "+_taskcontrol.EnteredBy.Trim();
                    else
                        lblEnteredBy.Text = "";
                }
                else
                {
                    eArgs.EOF = true;
                }

                this.CountDataIndex++;
            }
            catch (Exception)
            {
                if (eArgs != null)
                    eArgs.EOF = true;
            }
        }
    }
}
