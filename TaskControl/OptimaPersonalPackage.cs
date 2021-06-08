using System;
using System.Data;
using Baldrich.DBRequest;
using System.Xml;
using EPolicy.Customer;
using EPolicy.LookupTables;
using EPolicy.Quotes;
using EPolicy.Audit;
using EPolicy.XmlCooker;

namespace EPolicy.TaskControl
{
    public class OptimaPersonalPackage : Policy
    {
        public OptimaPersonalPackage(bool isOPPQuote)
        {
            this.IsOPPQuote = isOPPQuote;
            this.AgentList = Policy.GetAgentListByPolicyClassID(12);
            //this.SupplierList	  = Policy.GetSupplierListByPolicyClassID(0);
            this.DepartmentID = 0;
            this.PolicyClassID = 12;
            this.PolicyType = "OPP";
            this.InsuranceCompany = "001";
            this.Agency = "001";
            this.Agent = "";
            this.SupplierID = "000";
            this.Bank = "000";
            this.Dealer = "000";
            this.CompanyDealer = "000";
            this.Status = "Inforce";
            this.Term = 12;
            this.EffectiveDate = DateTime.Now.ToShortDateString();
            this.ExpirationDate = DateTime.Now.AddMonths(12).ToShortDateString();
            this.TaskStatusID = int.Parse(LookupTables.LookupTables.GetID("TaskStatus", "Open"));

            if (this.IsOPPQuote)
                this.TaskControlTypeID = int.Parse(LookupTables.LookupTables.GetID("TaskControlType", "Optima Personal Package Quote"));
            else
            {
                this.DepartmentID = 2;
                this.TaskControlTypeID = int.Parse(LookupTables.LookupTables.GetID("TaskControlType", "Optima Personal Package"));
            }
           
            // Para el History
            this._mode = (int)TaskControlMode.ADD;
        }

        #region Variable

        private OptimaPersonalPackage oldOptimaPersonalPackage = null;
        private Properties _Properties = null;
        private DataTable  _PropertiesCollection = null;
        private DataTable _AdditionalCoveragesPropertiesCollection1 = null;
        private DataTable _AdditionalCoveragesPropertiesCollection2 = null;
        private DataTable _AdditionalCoveragesPropertiesCollection3 = null;
        private DataTable _AdditionalCoveragesPropertiesCollection4 = null;
        private PersonalLiability _PersonalLiability = null;
        private DataTable _PersonalLiabilityCollection = null;
        private DataTable _AdditionalCoveragesLiabilityCollection = null;
        private DataTable _dtOptimaPersonalPackage;
        private Umbrella _Umbrella = null;
        private QuoteAuto _QuoteAuto = null;
        private int _OptimaPersonalPackageID = 0;
        private double _PropertiesPremium = 0.00;
        private double _LiabilityPremium = 0.00;
        private double _AutoPremium = 0.00;
        private double _UmbrellaPremium = 0.00;
        private bool _IsOPPQuote = false;
        private int _TaskControlIDQuoteAuto = 0;
        private string _PropEnd = "";
        private string _LiabEnd = "";
        private string _AutoEnd = "";
        private string _UmbEnd = "";
        private int _mode = (int)TaskControlMode.CLEAR;

        #endregion

        #region Properties
        public bool IsOPPQuote
        {
            get
            {
                return (this._IsOPPQuote);
            }
            set
            {
                this._IsOPPQuote = value;
            }
        }

        public DataTable PropertiesCollection
        {
            get
            {
                if (this._PropertiesCollection == null)
                    this._PropertiesCollection = DataTablePropertiesTemp();
                return (this._PropertiesCollection);
            }
            set
            {
                this._PropertiesCollection = value;
            }
        }

        public DataTable PersonalLiabilityCollection
        {
            get
            {
                if (this._PersonalLiabilityCollection == null)
                    this._PersonalLiabilityCollection = DataTablePersonalLiabilityTemp();
                return (this._PersonalLiabilityCollection);
            }
            set
            {
                this._PersonalLiabilityCollection = value;
            }
        }

        public DataTable AdditionalCoveragesPropertiesCollection1
        {
            get
            {
                if (this._AdditionalCoveragesPropertiesCollection1 == null)
                    this._AdditionalCoveragesPropertiesCollection1 = DataTableAdditionalCoveragePropertiesTemp();
                return (this._AdditionalCoveragesPropertiesCollection1);
            }
            set
            {
                this._AdditionalCoveragesPropertiesCollection1 = value;
            }
        }

        public DataTable AdditionalCoveragesPropertiesCollection2
        {
            get
            {
                if (this._AdditionalCoveragesPropertiesCollection2 == null)
                    this._AdditionalCoveragesPropertiesCollection2 = DataTableAdditionalCoveragePropertiesTemp();
                return (this._AdditionalCoveragesPropertiesCollection2);
            }
            set
            {
                this._AdditionalCoveragesPropertiesCollection2 = value;
            }
        }

        public DataTable AdditionalCoveragesPropertiesCollection3
        {
            get
            {
                if (this._AdditionalCoveragesPropertiesCollection3 == null)
                    this._AdditionalCoveragesPropertiesCollection3 = DataTableAdditionalCoveragePropertiesTemp();
                return (this._AdditionalCoveragesPropertiesCollection3);
            }
            set
            {
                this._AdditionalCoveragesPropertiesCollection3 = value;
            }
        }

        public DataTable AdditionalCoveragesPropertiesCollection4
        {
            get
            {
                if (this._AdditionalCoveragesPropertiesCollection4 == null)
                    this._AdditionalCoveragesPropertiesCollection4 = DataTableAdditionalCoveragePropertiesTemp();
                return (this._AdditionalCoveragesPropertiesCollection4);
            }
            set
            {
                this._AdditionalCoveragesPropertiesCollection4 = value;
            }
        }

        public Properties Properties
        {
            get
            {
                if (this._Properties == null)
                    this._Properties = new Properties();
                return (this._Properties);
            }
            set
            {
                this._Properties = value;
            }
        }

        public PersonalLiability PersonalLiability
        {
            get
            {
                if (this._PersonalLiability == null)
                    this._PersonalLiability = new PersonalLiability();
                return (this._PersonalLiability);
            }
            set
            {
                this._PersonalLiability = value;
            }
        }

        public DataTable AdditionalCoveragesLiabilityCollection
        {
            get
            {
                if (this._AdditionalCoveragesLiabilityCollection == null)
                    this._AdditionalCoveragesLiabilityCollection = DataTableAdditionalCoverageLiabilityTemp();
                return (this._AdditionalCoveragesLiabilityCollection);
            }
            set
            {
                this._AdditionalCoveragesLiabilityCollection = value;
            }
        }

        public Umbrella Umbrella
        {
            get
            {
                if (this._Umbrella == null)
                    this._Umbrella = new Umbrella();
                return (this._Umbrella);
            }
            set
            {
                this._Umbrella = value;
            }
        }

        public QuoteAuto QuoteAuto
        {
            get
            {
                if (this._QuoteAuto == null)
                    this._QuoteAuto = new QuoteAuto(false);
                return (this._QuoteAuto);
            }
            set
            {
                this._QuoteAuto = value;
            }
        }

        public int OptimaPersonalPackageID
        {
            get
            {
                return this._OptimaPersonalPackageID;
            }
            set
            {
                this._OptimaPersonalPackageID = value;
            }
        }

        public double PropertiesPremium
        {
            get
            { 
                double totprem = 0.00;
                if (this._PropertiesCollection != null)
                {
                    for (int i = 0; this._PropertiesCollection.Rows.Count - 1 >= i; i++)
                    {
                        totprem = totprem + double.Parse(this._PropertiesCollection.Rows[i]["TotalPremium"].ToString());
                    }
                }
                
                this._PropertiesPremium = totprem;                
                return this._PropertiesPremium;
            }
            set
            {
                this._PropertiesPremium = value;
            }
        }

        public double LiabilityPremium
        {
            get
            {
                double totprem = 0.00;
                if (this._PersonalLiabilityCollection != null)
                {
                    for (int i = 0; this._PersonalLiabilityCollection.Rows.Count - 1 >= i; i++)
                    {
                        totprem = totprem + double.Parse(this._PersonalLiabilityCollection.Rows[i]["TotalPremium"].ToString());
                    }
                }
                this._LiabilityPremium = totprem; 
                return this._LiabilityPremium;
            }
            set
            {
                this._LiabilityPremium = value;
            }
        }

        public double AutoPremium
        {
            get
            {
                double totprem = 0.00;
                if (this._QuoteAuto != null)
                {
                    totprem = double.Parse(this._QuoteAuto.TotalPremium.ToString());
                }
                this._AutoPremium = totprem;
                return this._AutoPremium;
            }
            set
            {
                this._AutoPremium = value;
            }
        }

        public double UmbrellaPremium
        {
            get
            {
                double totprem = 0.00;
                if (this._Umbrella != null)
                {
                    totprem = this._Umbrella.TotalUmbrellaPremium;
                }
                this._UmbrellaPremium = totprem;
                return this._UmbrellaPremium;
            }
            set
            {
                this._UmbrellaPremium = value;
            }
        }

        public int TaskControlIDQuoteAuto
        {
            get
            {
                return this._TaskControlIDQuoteAuto;
            }
            set
            {
                this._TaskControlIDQuoteAuto = value;
            }
        }

        public string PropEnd
        {
            get
            {
                return this._PropEnd;
            }
            set
            {
                this._PropEnd = value;
            }
        }
        public string LiabEnd
        {
            get
            {
                return this._LiabEnd;
            }
            set
            {
                this._LiabEnd = value;
            }
        }
        public string AutoEnd
        {
            get
            {
                return this._AutoEnd;
            }
            set
            {
                this._AutoEnd = value;
            }
        }
        public string UmbEnd
        {
            get
            {
                return this._UmbEnd;
            }
            set
            {
                this._UmbEnd = value;
            }
        }

        #endregion

        #region Public Methods

        public void SaveOptimaPersonalPackage(int UserID)
        {
            this.SavePol(UserID);
        }

        //public Properties GetProperties(int propertiesID)
        //{
        //    this.Properties = Properties.GetProperties(propertiesID,this.IsOPPQuote);
        //    return this.Properties;
        //}

        public override void SavePol(int UserID)
        {
            this._mode = (int)this.Mode;  // Se le asigna el mode de taskControl.
            this.PolicyMode = (int)this.Mode;  // Se le asigna el mode de taskControl.

            if (IsOPPQuote)
            {
                this.ValidateQuote();
                if (this.Prospect.ProspectID == 0)
                    this.Prospect.Mode = 1;
                else
                    this.Prospect.Mode = 2;

                this.Prospect.IsBusiness = false;
                this.Prospect.LocationID = this.OriginatedAt;
                this.Prospect.SaveProspect(UserID);

                this.ProspectID = this.Prospect.ProspectID;
            }
            else
            {
                this.Validate();
                base.ValidatePolicy();

                if (this._mode == 2)
                    oldOptimaPersonalPackage = (OptimaPersonalPackage)OptimaPersonalPackage.GetTaskControlByTaskControlID(this.TaskControlID, UserID);

                if (this.Customer.CustomerNo.Trim() == "")
                    this.Customer.Mode = 1;
                else
                    this.Customer.Mode = 2;

                this.Customer.IsBusiness = false;
                this.Customer.Save(UserID);

                this.CustomerNo = this.Customer.CustomerNo;
                this.ProspectID = this.Customer.ProspectID;
            }

            base.Save();

            if (IsOPPQuote)
                base.SaveOPPQuote(UserID);    // Validate and Save Quote in Policy Class
            else
                base.SavePol(UserID);	// Validate and Save Policy

            SaveOptimaPersonalPackageDB(UserID);  // Save Policies

            //Salva Properties
             this.Properties.SaveProperties(UserID, this.PropertiesCollection, this.TaskControlID, this.IsOPPQuote); //Save Properties

             //Antes de salvar la Propiedades elimina las cubiertas adiconales para anadirlas con los nuevos cambios.
             this.Properties.AditionalCoveragecs.DeleteAditionalCoveragePropertiesByTaskControlID(this.TaskControlID, this.IsOPPQuote);

            //Salva Additional Coverages for Properties
            this.Properties.AditionalCoveragecs.AditionalCoverageTableTemp = this.AdditionalCoveragesPropertiesCollection1;
            this.Properties.AditionalCoveragecs.SaveAditionalCoverage(UserID,this.Properties.PropertiesID, this.TaskControlID, IsOPPQuote);

            this.Properties.AditionalCoveragecs.AditionalCoverageTableTemp = this.AdditionalCoveragesPropertiesCollection2;
            this.Properties.AditionalCoveragecs.SaveAditionalCoverage(UserID, this.Properties.PropertiesID2, this.TaskControlID, IsOPPQuote);

            this.Properties.AditionalCoveragecs.AditionalCoverageTableTemp = this.AdditionalCoveragesPropertiesCollection3;
            this.Properties.AditionalCoveragecs.SaveAditionalCoverage(UserID, this.Properties.PropertiesID3, this.TaskControlID, IsOPPQuote);

            this.Properties.AditionalCoveragecs.AditionalCoverageTableTemp = this.AdditionalCoveragesPropertiesCollection4;
            this.Properties.AditionalCoveragecs.SaveAditionalCoverage(UserID, this.Properties.PropertiesID4, this.TaskControlID, IsOPPQuote);

            //Salva PersonalLiability
            this.PersonalLiability.SavePersonalLiability(UserID, this.PersonalLiabilityCollection, this.TaskControlID, this.IsOPPQuote); //Save Properties

            //Antes de salvar la Propiedades elimina las cubiertas adiconales para anadirlas con los nuevos cambios.
            this.PersonalLiability.AdditionalCoverageLiability.DeleteAdditionalCoverageLiabilityByTaskControlID(this.TaskControlID, this.IsOPPQuote);

            //Salva Additional Coverages for Properties
            this.PersonalLiability.AdditionalCoverageLiability.AdditionalCoverageLiabilityTableTemp = this.AdditionalCoveragesLiabilityCollection;
            this.PersonalLiability.AdditionalCoverageLiability.SaveAdditionalCoverageLiability(UserID, this.PersonalLiability.PersonalLiabilityID, this.TaskControlID, IsOPPQuote);

            //Salva Umbrella Policy
            Umbrella.DeleteUmbrellaByTaskControlID(TaskControlID, this.IsOPPQuote);

            if(this.Umbrella.TaskControlID != 0) //Solamente guarda cuando existe el umbrella.
                this.Umbrella.SaveUmbrella(UserID, this.IsOPPQuote);

            //Salva Auto Policy
            QuoteAuto.Save();

            this._mode = (int)TaskControlMode.UPDATE;
            this.Mode = (int)TaskControlMode.CLEAR;
        }

        public void ValidateQuote()
        {
            string errorMessage = String.Empty;

            if (this.EffectiveDate == "")
                errorMessage = "Effective Date is missing or wrong.";
            else
                if (this.Term == 0)
                    errorMessage = "Term is missing or wrong.";
                else
                    if (this.Prospect.FirstName == "")
                        errorMessage = "First Name is missing or wrong.";
                    else
                        if (this.Prospect.LastName1 == "")
                            errorMessage = "Last Name is missing or wrong.";
                        else
                            if (this.OriginatedAt == 0)
                                errorMessage = "Originated is missing.";
                            else
                                if (this.TotalPremium == 0)
                                    errorMessage = "TotalPremium must be greater than 0.";
                 
            //throw the exception.
            if (errorMessage != String.Empty)
            {
                throw new Exception(errorMessage);
            }
        }

        public override void Validate()
        {
            string errorMessage = String.Empty;

            if (this.EffectiveDate == "")
                errorMessage = "Effective Date is missing or wrong.";
            else
                if (this.PolicyClassID == 0)
                    errorMessage = "Line of Business is missing or wrong.";
                else
                    if (this.Customer.FirstName == "")
                        errorMessage = "First Name is missing or wrong.";
                    else
                        if (this.Customer.LastName1 == "")
                            errorMessage = "Last Name is missing or wrong.";
                        else
                            if (this.OriginatedAt == 0)
                                errorMessage = "Originated is missing.";
                            else
                                if (this.TotalPremium == 0)
                                    errorMessage = "TotalPremium must be greater than 0.";


            //throw the exception.
            if (errorMessage != String.Empty)
            {
                throw new Exception(errorMessage);
            }
        }

        public static OptimaPersonalPackage GetOptimaPersonalPackage(int TaskControlID, bool IsOppQuote)
        {
            OptimaPersonalPackage optimaPersonalPackage = null;

            DataTable dt = GetOptimaPersonalPackageByTaskControlID(TaskControlID, IsOppQuote);

            optimaPersonalPackage = new OptimaPersonalPackage(IsOppQuote);

            if(IsOppQuote)
                optimaPersonalPackage = (OptimaPersonalPackage)Policy.GetPolicyQuoteByTaskControlID(TaskControlID, optimaPersonalPackage);  //PolicyQuote
            else
                optimaPersonalPackage = (OptimaPersonalPackage)Policy.GetPolicyByTaskControlID(TaskControlID, optimaPersonalPackage);  //Policy

            optimaPersonalPackage._dtOptimaPersonalPackage = dt;

            optimaPersonalPackage = FillProperties(optimaPersonalPackage, TaskControlID, IsOppQuote);

            return optimaPersonalPackage;
        }

        public static void DeleteOptimaPersonalPackageByTaskControlID(int taskControlID, bool IsOPPQuote)
        {
            DBRequest Executor = new DBRequest();

            try
            {
                Executor.BeginTrans();
                Executor.Update("DeleteOptimaPersonalPackage", DeleteOptimaPersonalPackageByTaskControlIDXml(taskControlID,IsOPPQuote));
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error, Please try again. " + xcp.Message, xcp);
            }
        }

        public static DataTable GetOPPByTaskControlID(int taskControlID)
        {
            DBRequest Executor = new DBRequest();

            try
            {
                
                DataTable dt = GetOPPByTaskControlIDDB(taskControlID);
                return dt;
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error, Please try again. " + xcp.Message, xcp);
            }
        }

        #endregion

        #region Private Methods

        public void CalculatePremium()
        {
            //			Quotes.MBIQuote MbiQuotes = new Quotes.MBIQuote();
            //			MbiQuotes.Calculate(this.PolicyType.Trim(),this.Model.Trim(),this.Make.Trim(),this.Term);
            //
            //			if(this.InsuranceCompany == "097")
            //			{
            //				this.TotalPremium = 175.00;
            //			}
            //			else
            //			{
            //				this.TotalPremium = MbiQuotes.premium;
            //			}
            //
            //			this.VehicleClass = MbiQuotes.classification;
            //			this.Mileage      = MbiQuotes.plan;		
        }

        private static DataTable GetOPPByTaskControlIDDB(int TaskControlID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, TaskControlID.ToString(),
                ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            DataTable dt = exec.GetQuery("GetOPPByTaskControlID", xmlDoc);
            return dt;
        }

        private static DataTable GetOptimaPersonalPackageByTaskControlID(int TaskControlID, bool IsOppQuote)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, TaskControlID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("IsOppQuote",
                SqlDbType.Bit, 0, IsOppQuote.ToString(),
                ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            DataTable dt = exec.GetQuery("GetOptimaPersonalPackageByTaskControlID", xmlDoc);
            return dt;
        }

        private void SaveOptimaPersonalPackageDB(int UserID)
        {
            Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
            try
            {
                Executor.BeginTrans();
                switch (this.Mode)
                {
                    case 1:  //ADD
                        this.OptimaPersonalPackageID = Executor.Insert("AddOptimaPersonalPackage", this.GetInsertOptimaPersonalPackageXml());
                        //this.History(this._mode, UserID);
                        break;

                    case 3:  //DELETE
                        //Executor.Update("DeleteAutoGuardServicesContract",this.GetDeletePoliciesXml());
                        break;

                    case 4:  //CLEAR						
                        break;

                    default: //UPDATE
                        //this.History(this._mode, UserID);
                        Executor.Update("UpdateOptimaPersonalPackage", this.GetUpdateOptimaPersonalPackageXml());
                        break;
                }
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error while trying to save the Policy. " + xcp.Message, xcp);
            }
        }

        private static XmlDocument DeleteOptimaPersonalPackageByTaskControlIDXml(int taskControlID, bool IsOPPQuote)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, taskControlID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("IsOppQuote",
                SqlDbType.Bit, 0, IsOPPQuote.ToString(),
                ref cookItems);

            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            return xmlDoc;
        }

        private XmlDocument GetUpdateOptimaPersonalPackageXml()
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[12];

            DbRequestXmlCooker.AttachCookItem("OptimaPersonalPackageID",
                SqlDbType.Int, 0, this.OptimaPersonalPackageID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, this.TaskControlID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PropertiesPremium",
                 SqlDbType.Float, 0, this.PropertiesPremium.ToString(),
                 ref cookItems);

            DbRequestXmlCooker.AttachCookItem("LiabilityPremium",
                SqlDbType.Float, 0, this.LiabilityPremium.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("AutoPremium",
                SqlDbType.Float, 0, this.AutoPremium.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("UmbrellaPremium",
                SqlDbType.Float, 0, this.UmbrellaPremium.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("IsOppQuote",
                SqlDbType.Bit, 0, this.IsOPPQuote.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("TaskControlIDQuoteAuto",
                SqlDbType.Int, 0, this.TaskControlIDQuoteAuto.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PropEnd",
                SqlDbType.VarChar, 300, this.PropEnd.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("LiabEnd",
                SqlDbType.VarChar, 300, this.LiabEnd.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("AutoEnd",
                SqlDbType.VarChar, 300, this.AutoEnd.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("UmbEnd",
                SqlDbType.VarChar, 300, this.UmbEnd.ToString(),
                ref cookItems);

            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            return xmlDoc;
        }


        private XmlDocument GetInsertOptimaPersonalPackageXml()
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[11];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
               SqlDbType.Int, 0, this.TaskControlID.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PropertiesPremium",
                 SqlDbType.Float, 0, this.PropertiesPremium.ToString(),
                 ref cookItems);

            DbRequestXmlCooker.AttachCookItem("LiabilityPremium",
                SqlDbType.Float, 0, this.LiabilityPremium.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("AutoPremium",
                SqlDbType.Float, 0, this.AutoPremium.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("UmbrellaPremium",
                SqlDbType.Float, 0, this.UmbrellaPremium.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("IsOppQuote",
                SqlDbType.Bit, 0, this.IsOPPQuote.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("TaskControlIDQuoteAuto",
                SqlDbType.Int, 0, this.TaskControlIDQuoteAuto.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PropEnd",
               SqlDbType.VarChar, 300, this.PropEnd.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("LiabEnd",
                SqlDbType.VarChar, 300, this.LiabEnd.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("AutoEnd",
                SqlDbType.VarChar, 300, this.AutoEnd.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("UmbEnd",
                SqlDbType.VarChar, 300, this.UmbEnd.ToString(),
                ref cookItems);

            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            return xmlDoc;
        }

        private static OptimaPersonalPackage FillProperties(OptimaPersonalPackage optimaPersonalPackage, int taskControlID, bool IsOppQuote)
        {
            optimaPersonalPackage.OptimaPersonalPackageID = (int)optimaPersonalPackage._dtOptimaPersonalPackage.Rows[0]["OptimaPersonalPackageID"];
            optimaPersonalPackage.PropertiesPremium = (double)optimaPersonalPackage._dtOptimaPersonalPackage.Rows[0]["PropertiesPremium"];
            optimaPersonalPackage.LiabilityPremium = (double)optimaPersonalPackage._dtOptimaPersonalPackage.Rows[0]["LiabilityPremium"];
            optimaPersonalPackage.AutoPremium = (double)optimaPersonalPackage._dtOptimaPersonalPackage.Rows[0]["AutoPremium"];
            optimaPersonalPackage.UmbrellaPremium = (double)optimaPersonalPackage._dtOptimaPersonalPackage.Rows[0]["UmbrellaPremium"];
            optimaPersonalPackage.TaskControlIDQuoteAuto = (int)optimaPersonalPackage._dtOptimaPersonalPackage.Rows[0]["TaskControlIDQuoteAuto"];
            optimaPersonalPackage.PropEnd = optimaPersonalPackage._dtOptimaPersonalPackage.Rows[0]["PropEnd"].ToString().Trim();
            optimaPersonalPackage.LiabEnd = optimaPersonalPackage._dtOptimaPersonalPackage.Rows[0]["LiabEnd"].ToString().Trim();
            optimaPersonalPackage.AutoEnd = optimaPersonalPackage._dtOptimaPersonalPackage.Rows[0]["AutoEnd"].ToString().Trim();
            optimaPersonalPackage.UmbEnd = optimaPersonalPackage._dtOptimaPersonalPackage.Rows[0]["UmbEnd"].ToString().Trim();

            optimaPersonalPackage.PropertiesCollection = Properties.GetPropertiesByTaskControlID(taskControlID, IsOppQuote);           

            if(optimaPersonalPackage.PropertiesCollection.Rows.Count >= 1)
            {
                optimaPersonalPackage.AdditionalCoveragesPropertiesCollection1 = AditionalCoveragecs.GetAditionalCoverageTableTempLoaded((int)optimaPersonalPackage.PropertiesCollection.Rows[0]["PropertiesID"], IsOppQuote);
            }

            if (optimaPersonalPackage.PropertiesCollection.Rows.Count >= 2)
            {
                optimaPersonalPackage.AdditionalCoveragesPropertiesCollection2 = AditionalCoveragecs.GetAditionalCoverageTableTempLoaded((int)optimaPersonalPackage.PropertiesCollection.Rows[1]["PropertiesID"], IsOppQuote);
            }

            if (optimaPersonalPackage.PropertiesCollection.Rows.Count >= 3)
            {
                optimaPersonalPackage.AdditionalCoveragesPropertiesCollection3 = AditionalCoveragecs.GetAditionalCoverageTableTempLoaded((int)optimaPersonalPackage.PropertiesCollection.Rows[2]["PropertiesID"], IsOppQuote);
            }

            if (optimaPersonalPackage.PropertiesCollection.Rows.Count >= 4)
            {
                optimaPersonalPackage.AdditionalCoveragesPropertiesCollection4 = AditionalCoveragecs.GetAditionalCoverageTableTempLoaded((int)optimaPersonalPackage.PropertiesCollection.Rows[3]["PropertiesID"], IsOppQuote);
            }

            optimaPersonalPackage.PersonalLiabilityCollection = PersonalLiability.GetPersonalLiabilityByTaskControlID(taskControlID, IsOppQuote);
            if (optimaPersonalPackage.PersonalLiabilityCollection.Rows.Count >= 1)
            {
                optimaPersonalPackage.AdditionalCoveragesLiabilityCollection = AdditionalCoverageLiability.GetAdditionalCoverageLiabilityTableTempLoaded((int)optimaPersonalPackage.PersonalLiabilityCollection.Rows[0]["PersonalLiabilityID"], IsOppQuote);
            }

            optimaPersonalPackage.Umbrella = Umbrella.GetUmbrellaByTaskControlID(taskControlID, IsOppQuote);

            optimaPersonalPackage.QuoteAuto = EPolicy.TaskControl.QuoteAuto.GetQuoteAuto(optimaPersonalPackage.TaskControlIDQuoteAuto, 1, false);
            optimaPersonalPackage.QuoteAuto.Calculate();

            return optimaPersonalPackage;
        }

        private DataTable DataTableAdditionalCoveragePropertiesTemp()
        {
            DataTable myDataTable = new DataTable("AditionalCoverageTemp");
            DataColumn myDataColumn;

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "AdditionalCoveragesID";
            myDataColumn.AutoIncrement = true;
            myDataColumn.ReadOnly = true;
            myDataColumn.Unique = true;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "TaskControlID";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "TaskControlID";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "PropertiesID";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "PropertiesID";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "AdditionalCoveragesDesc";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "AditionalCoverageDesc";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "Premium";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Premium";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = myDataTable.Columns["ID"];
            myDataTable.PrimaryKey = PrimaryKeyColumns;

            return myDataTable;
        }

        private DataTable DataTablePropertiesTemp()
        {
    		DataTable myDataTable = new DataTable("DataTablePropertiesTemp");
			DataColumn myDataColumn;
 
			myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Int32");
			myDataColumn.ColumnName = "PropertiesID";
			myDataColumn.AutoIncrement = true;
            myDataColumn.AutoIncrementSeed = 1;
            myDataColumn.AutoIncrementStep = 1;
            myDataColumn.AllowDBNull = false;
			myDataColumn.ReadOnly = true;
			myDataColumn.Unique = true;
			myDataTable.Columns.Add(myDataColumn);

			myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Int32");
			myDataColumn.ColumnName = "Families";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "Families";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

			myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Int32");
			myDataColumn.ColumnName = "ConstructionType";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ConstructionType";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

			myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Int32");
			myDataColumn.ColumnName = "ExperienceCredit";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ExperienceCredit";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "Bank";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Bank";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

			myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.String");
			myDataColumn.ColumnName = "City";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "City";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

			myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Boolean");
			myDataColumn.ColumnName = "Building";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "Building";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

			myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Boolean");
			myDataColumn.ColumnName = "Contents";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "Contents";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

			myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Boolean");
			myDataColumn.ColumnName = "Another";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "Another";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

			myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Boolean");
			myDataColumn.ColumnName = "Rented";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "Rented";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

			myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Boolean");
			myDataColumn.ColumnName = "Pool";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "Pool";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "LoanNo";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "LoanNo";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

			myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Int32");
			myDataColumn.ColumnName = "Deductible";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "Deductible";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

			myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Boolean");
			myDataColumn.ColumnName = "Primary";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "Primary";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Boolean");
			myDataColumn.ColumnName = "Secondary";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "Secondary";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

			myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.String");
			myDataColumn.ColumnName = "Address1";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "Address1";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

			myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.String");
			myDataColumn.ColumnName = "Address2";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "Address2";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

			myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.String");
			myDataColumn.ColumnName = "State";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "State";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

			myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.String");
			myDataColumn.ColumnName = "ZipCode";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ZipCode";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.String");
			myDataColumn.ColumnName = "Description";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "Description";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingLimitFire";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingLimitFire";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingLimitExtCoverage";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingLimitExtCoverage";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingLimitVandalism";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingLimitVandalism";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingLimitEarthquake";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingLimitEarthquake";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);
            
            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingLimitAOP";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingLimitAOP";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingLimitExcessAOP";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingLimitExcessAOP";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingLimitTheft";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingLimitTheft";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingRateFire";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingRateFire";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingFactorFire";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingFactorFire";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingTotalFire";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingTotalFire";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingPremiumFire";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingPremiumFire";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingRateExtCoverage";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingRateExtCoverage";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingFactorExtCoverage";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingFactorExtCoverage";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingTotalExtCoverage";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingTotalExtCoverage";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingPremiumExtCoverage";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingPremiumExtCoverage";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingRateVandalism";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingRateVandalism";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingFactorVandalism";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingFactorVandalism";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingTotalVandalism";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingTotalVandalism";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingPremiumVandalism";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingPremiumVandalism";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingRateEarthquake";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingRateEarthquake";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingFactorEarthquake";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingFactorEarthquake";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingTotalEarthquake";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingTotalEarthquake";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingPremiumEarthquake";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingPremiumEarthquake";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingRateAOP";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingRateAOP";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingFactorAOP";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingFactorAOP";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingTotalAOP";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingTotalAOP";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingPremiumAOP";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingPremiumAOP";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingRateExcessAOP";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingRateExcessAOP";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingFactorExcessAOP";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingFactorExcessAOP";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingTotalExcessAOP";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingTotalExcessAOP";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingPremiumExcessAOP";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingPremiumExcessAOP";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingRateTheft";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingRateTheft";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingFactorTheft";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingFactorTheft";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingTotalTheft";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingTotalTheft";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingPremiumTheft";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingPremiumTheft";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsLimitFire";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsLimitFire";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsLimitExtCoverage";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsLimitExtCoverage";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsLimitVandalism";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsLimitVandalism";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsLimitEarthquake";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsLimitEarthquake";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsLimitAOP";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsLimitAOP";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsLimitExcessAOP";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsLimitExcessAOP";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsLimitTheft";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsLimitTheft";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsRateFire";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsRateFire";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsFactorFire";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsFactorFire";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsTotalFire";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsTotalFire";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsPremiumFire";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsPremiumFire";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsRateExtCoverage";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsRateExtCoverage";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsFactorExtCoverage";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsFactorExtCoverage";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsTotalExtCoverage";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsTotalExtCoverage";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsPremiumExtCoverage";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsPremiumExtCoverage";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsRateVandalism";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsRateVandalism";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsFactorVandalism";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsFactorVandalism";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsTotalVandalism";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsTotalVandalism";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsPremiumVandalism";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsPremiumVandalism";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsRateEarthquake";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsRateEarthquake";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsFactorEarthquake";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsFactorEarthquake";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsTotalEarthquake";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsTotalEarthquake";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsPremiumEarthquake";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsPremiumEarthquake";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsRateAOP";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsRateAOP";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsFactorAOP";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsFactorAOP";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsTotalAOP";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsTotalAOP";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsPremiumAOP";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsPremiumAOP";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsRateExcessAOP";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsRateExcessAOP";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsFactorExcessAOP";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsFactorExcessAOP";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsTotalExcessAOP";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsTotalExcessAOP";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsPremiumExcessAOP";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsPremiumExcessAOP";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsRateTheft";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsRateTheft";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsFactorTheft";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsFactorTheft";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsTotalTheft";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsTotalTheft";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsPremiumTheft";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsPremiumTheft";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "BuildingPremiumTotal";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "BuildingPremiumTotal";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "ContentsPremiumTotal";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ContentsPremiumTotal";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "Charge";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "Charge";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "SubTotalPremium";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "SubTotalPremium";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Double");
			myDataColumn.ColumnName = "TotalPremium";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "TotalPremium";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			myDataTable.Columns.Add(myDataColumn);


			// Make the ID column the primary key column.
			DataColumn[] PrimaryKeyColumns = new DataColumn[1];
			PrimaryKeyColumns[0] = myDataTable.Columns["ID"];
			myDataTable.PrimaryKey = PrimaryKeyColumns;

			return myDataTable;

        }

        private DataTable DataTablePersonalLiabilityTemp()
        {
            DataTable myDataTable = new DataTable("DataTablePropertiesTemp");
            DataColumn myDataColumn;
   
            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "PersonalLiabilityID";
            myDataColumn.AutoIncrement = true;
            myDataColumn.AutoIncrementSeed = 1;
            myDataColumn.AutoIncrementStep = 1;
            myDataColumn.AllowDBNull = false;
            myDataColumn.ReadOnly = true;
            myDataColumn.Unique = true;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "Residence1";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Residence1";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "Residence2";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Residence2";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "Residence3";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Residence3";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "Residence4";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Residence4";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Boolean");
            myDataColumn.ColumnName = "SwimmingPool1";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "SwimmingPool1";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Boolean");
            myDataColumn.ColumnName = "SwimmingPool2";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "SwimmingPool2";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Boolean");
            myDataColumn.ColumnName = "SwimmingPool3";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "SwimmingPool3";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Boolean");
            myDataColumn.ColumnName = "SwimmingPool4";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "SwimmingPool4";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "Families1";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Families1";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "Families2";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Families2";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "Families3";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Families3";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "Families4";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Families4";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "MedicalPayment1";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "MedicalPayment1";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "MedicalPayment2";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "MedicalPayment2";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "MedicalPayment3";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "MedicalPayment3";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "MedicalPayment4";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "MedicalPayment4";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);


            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "PersonalLiability1";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "PersonalLiability1";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "PersonalLiability2";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "PersonalLiability2";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "PersonalLiability3";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "PersonalLiability3";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "PersonalLiability4";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "PersonalLiability4";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Boolean");
            myDataColumn.ColumnName = "Rented1";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Rented1";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Boolean");
            myDataColumn.ColumnName = "Rented2";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Rented2";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Boolean");
            myDataColumn.ColumnName = "Rented3";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Rented3";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Boolean");
            myDataColumn.ColumnName = "Rented4";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Rented4";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "BasicRate1";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "BasicRate1";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "IncreaseLimit1";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "IncreaseLimit1";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "BasicPremium1";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "BasicPremium1";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "MedicalPrem1";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "MedicalPrem1";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "DiscountFactor1";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "DiscountFactor1";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "Premium1";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Premium1";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);




            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "BasicRate2";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "BasicRate2";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "IncreaseLimit2";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "IncreaseLimit2";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "BasicPremium2";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "BasicPremium2";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "MedicalPrem2";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "MedicalPrem2";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "DiscountFactor2";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "DiscountFactor2";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "Premium2";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Premium2";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "BasicRate3";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "BasicRate3";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "IncreaseLimit3";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "IncreaseLimit3";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "BasicPremium3";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "BasicPremium3";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "MedicalPrem3";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "MedicalPrem3";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "DiscountFactor3";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "DiscountFactor3";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "Premium3";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Premium3";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "BasicRate4";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "BasicRate4";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "IncreaseLimit4";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "IncreaseLimit4";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "BasicPremium4";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "BasicPremium4";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "MedicalPrem4";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "MedicalPrem4";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "DiscountFactor4";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "DiscountFactor4";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "Premium4";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Premium4";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "ExperienceCredit";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "ExperienceCredit";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "TotalLiabilityPremium";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "TotalLiabilityPremium";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "Charge";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Charge";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "SubTotalPremium";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "SubTotalPremium";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "TotalPremium";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "TotalPremium";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);


            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = myDataTable.Columns["ID"];
            myDataTable.PrimaryKey = PrimaryKeyColumns;

            return myDataTable;

        }

        private DataTable DataTableAdditionalCoverageLiabilityTemp()
        {
            DataTable myDataTable = new DataTable("AditionalCoverageLiability");
            DataColumn myDataColumn;

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "AdditionalCoverage2ID";
            myDataColumn.AutoIncrement = true;
            myDataColumn.ReadOnly = true;
            myDataColumn.Unique = true;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "TaskControlID";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "TaskControlID";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "PersonalLiabilityID";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "PersonalLiabilityID";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "AdditionalCoverageLiabilityDesc";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "AdditionalCoverageLiabilityDesc";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Double");
            myDataColumn.ColumnName = "Premium";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Premium";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = myDataTable.Columns["ID"];
            myDataTable.PrimaryKey = PrimaryKeyColumns;

            return myDataTable;
        }

        #endregion
    }
}
