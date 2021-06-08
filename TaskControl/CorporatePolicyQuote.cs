using System;
using System.Data;
using System.Text;
using System.IO;
using Baldrich.DBRequest;
using System.Xml;
using EPolicy.Customer;
using System.Reflection;
using EPolicy.TaskControl;
using EPolicy.Audit;
using EPolicy.XmlCooker;
using System.Web.UI.WebControls;
using System.Configuration;

namespace EPolicy.TaskControl
{
    public class CorporatePolicyQuote : Policy
    {
        
        public CorporatePolicyQuote(bool isOPPQuote)
        {
            this.AgentList = Policy.GetAgentListByPolicyClassID(0);
            this.IsPolicy = isOPPQuote;
            this.PolicyClassID = 15;
            this.InsuranceCompany = "000";
            this.Agency = "000";
            this.Agent = "000";
            this.Bank = "000";
            this.Dealer = "000";
            this.CompanyDealer = "000";
            //this.IsPolicy = true;
            this.TaskStatusID = int.Parse(LookupTables.LookupTables.GetID("TaskStatus", "Open"));

            if (this.IsPolicy)
            {
                this.TaskControlTypeID = int.Parse(LookupTables.LookupTables.GetID("TaskControlType", "CorporatePolicy"));
                this.DepartmentID = 2;
            }
            else
            {
                this.TaskControlTypeID = int.Parse(LookupTables.LookupTables.GetID("TaskControlType", "CorporatePolicyQuote"));
            }
        }

        #region Variable

        private CorporatePolicyQuote oldCorporatePolicyQuote = null;
        private DataTable _dtCorporatePolicyQuote;
        private DataTable _CorporatePolicyDetailCollection = null;
        private int _CorporatePolicyQuoteID = 0;
        private string _Corporate = "";
        private double _DiscountP = 0.00;
        private double _Discount = 0.00;
        private double _TotalPrimaryPremium = 0.00;
        private double _TotalExcessPremium = 0.00;
        private double _PrimaryTN1 = 0.00;
        private double _PrimaryTN2 = 0.00;
        private double _PrimaryTN3 = 0.00;
        private double _PrimaryTN4 = 0.00;
        private double _PrimaryTN5 = 0.00;
        private double _RateTN1 = 0.00;
        private double _RateTN2 = 0.00;
        private double _RateTN3 = 0.00;
        private double _RateTN4 = 0.00;
        private double _RateTN5 = 0.00;
        private double _RateTN6 = 0.00;
        private double _PremiumTN1 = 0.00;
        private double _PremiumTN2 = 0.00;
        private double _PremiumTN3 = 0.00;
        private double _PremiumTN4 = 0.00;
        private double _PremiumTN5 = 0.00;
        private int _QuantityTN1 = 0;
        private int _QuantityTN2 = 0;
        private int _QuantityTN3 = 0;
        private int _QuantityTN4 = 0;
        private int _QuantityTN5 = 0;
        private int _QuantityTN6 = 0;
        private double _TotPremTN1 = 0.00;
        private double _TotPremTN2 = 0.00;
        private double _TotPremTN3 = 0.00;
        private double _TotPremTN4 = 0.00;
        private double _TotPremTN5 = 0.00;
        private double _TotPremTN6 = 0.00;
        private double _ExcessTN1 = 0.00;
        private double _ExcessTN2 = 0.00;
        private double _ExcessTN3 = 0.00;
        private double _ExcessTN4 = 0.00;
        private double _ExcessTN5 = 0.00;
        private double _ERateTN1 = 0.00;
        private double _ERateTN2 = 0.00;
        private double _ERateTN3 = 0.00;
        private double _ERateTN4 = 0.00;
        private double _ERateTN5 = 0.00;
        private double _ERateTN6 = 0.00;
        private double _EPremiumTN1 = 0.00;
        private double _EPremiumTN2 = 0.00;
        private double _EPremiumTN3 = 0.00;
        private double _EPremiumTN4 = 0.00;
        private double _EPremiumTN5 = 0.00;
        private int _EQuantityTN1 = 0;
        private int _EQuantityTN2 = 0;
        private int _EQuantityTN3 = 0;
        private int _EQuantityTN4 = 0;
        private int _EQuantityTN5 = 0;
        private int _EQuantityTN6 = 0;
        private double _ETotPremTN1 = 0.00;
        private double _ETotPremTN2 = 0.00;
        private double _ETotPremTN3 = 0.00;
        private double _ETotPremTN4 = 0.00;
        private double _ETotPremTN5 = 0.00;
        private double _ETotPremTN6 = 0.00;
        private double _TotalPrimaryCorporate = 0.00;
        private double _TotalExcessCorporate = 0.00;
        private int _FinancialID = 0;
        private int _MainSpecialtyID = 0;
        private int _OtherSpecialtyIDA = 0;
        private int _OtherSpecialtyIDB = 0;
        private bool _Notification30Flag = false;
        private bool _Notification15Flag = false;
        private bool _CancellationFlag = false;
        private bool _UpdateForm = false;
        private int _mode = (int)TaskControlMode.CLEAR;
        private bool _IsPolicy = false;
        private string _Comments = "";
        private string _RetroDate = "";

        private string _priCarierName1;
        private string _priPolEffecDate1;
        private string _priPolLimits1;
        private string _priClaims1;
        private string _prmedicalLimit;

        private bool _isEndorsement = false;
        private DataTable _EndorsementCollection = null;
        private DataTable _Endorsement;
        //-----variables Gap
        private string _GapBegDate = "";
        private string _GapEndDate = "";
        private string _GapBegDate2 = "";
        private string _GapEndDate2 = "";
        private string _GapBegDate3 = "";
        private string _GapEndDate3 = "";
        private string _NumberOfEmployees = "";
        private string _OtherPersonel = "";

      

        #endregion

        #region Properties

        public DataTable CorporatePolicyDetailCollection
        {
            get
            {
                if (this._CorporatePolicyDetailCollection == null)
                    this._CorporatePolicyDetailCollection = DataTableCorporatePolicyDetailTemp();
                return (this._CorporatePolicyDetailCollection);
            }
            set
            {
                this._CorporatePolicyDetailCollection = value;
            }
        }
        public string OtherPersonel
        {
            get { return _OtherPersonel; }
            set { _OtherPersonel = value; }
        }
        public int CorporatePolicyQuoteID
        {
            get { return (this._CorporatePolicyQuoteID);}
            set {this._CorporatePolicyQuoteID = value; }
        }
        public string Corporate
        {
            get { return this._Corporate; }
            set { this._Corporate = value; }
        }
        public double DiscountP
        {
            get { return this._DiscountP; }
            set { this._DiscountP = value; }
        }
        public double Discount
        {
            get { return this._Discount; }
            set { this._Discount = value; }
        }
        public double TotalPrimaryPremium
        {
            get { return this._TotalPrimaryPremium; }
            set { this._TotalPrimaryPremium = value; }
        }
        public double TotalExcessPremium
        {
            get { return this._TotalExcessPremium; }
            set { this._TotalExcessPremium = value; }
        }
        public double PrimaryTN1
        {
            get { return this._PrimaryTN1; }
            set { this._PrimaryTN1 = value; }
        }
        public double PrimaryTN2
        {
            get { return this._PrimaryTN2; }
            set { this._PrimaryTN2 = value; }
        }
        public double PrimaryTN3
        {
            get { return this._PrimaryTN3; }
            set { this._PrimaryTN3 = value; }
        }
        public double PrimaryTN4
        {
            get { return this._PrimaryTN4; }
            set { this._PrimaryTN4 = value; }
        }
        public double PrimaryTN5
        {
            get { return this._PrimaryTN5; }
            set { this._PrimaryTN5 = value; }
        }
        public double RateTN1
        {
            get { return this._RateTN1; }
            set { this._RateTN1 = value; }
        }
        public double RateTN2
        {
            get { return this._RateTN2; }
            set { this._RateTN2 = value; }
        }
        public double RateTN3
        {
            get { return this._RateTN3; }
            set { this._RateTN3 = value; }
        }
        public double RateTN4
        {
            get { return this._RateTN4; }
            set { this._RateTN4 = value; }
        }
        public double RateTN5
        {
            get { return this._RateTN5; }
            set { this._RateTN5 = value; }
        }
        public double RateTN6
        {
            get { return this._RateTN6; }
            set { this._RateTN6 = value; }
        }
        public double PremiumTN1
        {
            get { return this._PremiumTN1; }
            set { this._PremiumTN1 = value; }
        }
        public double PremiumTN2
        {
            get { return this._PremiumTN2; }
            set { this._PremiumTN2 = value; }
        }
        public double PremiumTN3
        {
            get { return this._PremiumTN3; }
            set { this._PremiumTN3 = value; }
        }
        public double PremiumTN4
        {
            get { return this._PremiumTN4; }
            set { this._PremiumTN4 = value; }
        }
        public double PremiumTN5
        {
            get { return this._PremiumTN5; }
            set { this._PremiumTN5 = value; }
        }
        public int QuantityTN1
        {
            get { return this._QuantityTN1; }
            set { this._QuantityTN1 = value; }
        }
        public int QuantityTN2
        {
            get { return this._QuantityTN2; }
            set { this._QuantityTN2 = value; }
        }
        public int QuantityTN3
        {
            get { return this._QuantityTN3; }
            set { this._QuantityTN3 = value; }
        }
        public int QuantityTN4
        {
            get { return this._QuantityTN4; }
            set { this._QuantityTN4 = value; }
        }
        public int QuantityTN5
        {
            get { return this._QuantityTN5; }
            set { this._QuantityTN5 = value; }
        }
        public int QuantityTN6
        {
            get { return this._QuantityTN6; }
            set { this._QuantityTN6 = value; }
        }
        public double TotPremTN1
        {
            get { return this._TotPremTN1; }
            set { this._TotPremTN1 = value; }
        }
        public double TotPremTN2
        {
            get { return this._TotPremTN2; }
            set { this._TotPremTN2 = value; }
        }
        public double TotPremTN3
        {
            get { return this._TotPremTN3; }
            set { this._TotPremTN3 = value; }
        }
        public double TotPremTN4
        {
            get { return this._TotPremTN4; }
            set { this._TotPremTN4 = value; }
        }
        public double TotPremTN5
        {
            get { return this._TotPremTN5; }
            set { this._TotPremTN5 = value; }
        }
        public double TotPremTN6
        {
            get { return this._TotPremTN6; }
            set { this._TotPremTN6 = value; }
        }
        public double ExcessTN1
        {
            get { return this._ExcessTN1; }
            set { this._ExcessTN1 = value; }
        }
        public double ExcessTN2
        {
            get { return this._ExcessTN2; }
            set { this._ExcessTN2 = value; }
        }
        public double ExcessTN3
        {
            get { return this._ExcessTN3; }
            set { this._ExcessTN3 = value; }
        }
        public double ExcessTN4
        {
            get { return this._ExcessTN4; }
            set { this._ExcessTN4 = value; }
        }
        public double ExcessTN5
        {
            get { return this._ExcessTN5; }
            set { this._ExcessTN5 = value; }
        }
        public double ERateTN1
        {
            get { return this._ERateTN1; }
            set { this._ERateTN1 = value; }
        }
        public double ERateTN2
        {
            get { return this._ERateTN2; }
            set { this._ERateTN2 = value; }
        }
        public double ERateTN3
        {
            get { return this._ERateTN3; }
            set { this._ERateTN3 = value; }
        }
        public double ERateTN4
        {
            get { return this._ERateTN4; }
            set { this._ERateTN4 = value; }
        }
        public double ERateTN5
        {
            get { return this._ERateTN5; }
            set { this._ERateTN5 = value; }
        }
        public double ERateTN6
        {
            get { return this._ERateTN6; }
            set { this._ERateTN6 = value; }
        }
        public double EPremiumTN1
        {
            get { return this._EPremiumTN1; }
            set { this._EPremiumTN1 = value; }
        }
        public double EPremiumTN2
        {
            get { return this._EPremiumTN2; }
            set { this._EPremiumTN2 = value; }
        }
        public double EPremiumTN3
        {
            get { return this._EPremiumTN3; }
            set { this._EPremiumTN3 = value; }
        }
        public double EPremiumTN4
        {
            get { return this._EPremiumTN4; }
            set { this._EPremiumTN4 = value; }
        }
        public double EPremiumTN5
        {
            get { return this._EPremiumTN5; }
            set { this._EPremiumTN5 = value; }
        }
        public int EQuantityTN1
        {
            get { return this._EQuantityTN1; }
            set { this._EQuantityTN1 = value; }
        }
        public int EQuantityTN2
        {
            get { return this._EQuantityTN2; }
            set { this._EQuantityTN2 = value; }
        }
        public int EQuantityTN3
        {
            get { return this._EQuantityTN3; }
            set { this._EQuantityTN3 = value; }
        }
        public int EQuantityTN4
        {
            get { return this._EQuantityTN4; }
            set { this._EQuantityTN4 = value; }
        }
        public int EQuantityTN5
        {
            get { return this._EQuantityTN5; }
            set { this._EQuantityTN5 = value; }
        }
        public int EQuantityTN6
        {
            get { return this._EQuantityTN6; }
            set { this._EQuantityTN6 = value; }
        }
        public double ETotPremTN1
        {
            get { return this._ETotPremTN1; }
            set { this._ETotPremTN1 = value; }
        }
        public double ETotPremTN2
        {
            get { return this._ETotPremTN2; }
            set { this._ETotPremTN2 = value; }
        }
        public double ETotPremTN3
        {
            get { return this._ETotPremTN3; }
            set { this._ETotPremTN3 = value; }
        }
        public double ETotPremTN4
        {
            get { return this._ETotPremTN4; }
            set { this._ETotPremTN4 = value; }
        }
        public double ETotPremTN5
        {
            get { return this._ETotPremTN5; }
            set { this._ETotPremTN5 = value; }
        }
        public double ETotPremTN6
        {
            get { return this._ETotPremTN6; }
            set { this._ETotPremTN6 = value; }
        }
        public double TotalPrimaryCorporate
        {
            get { return this._TotalPrimaryCorporate; }
            set { this._TotalPrimaryCorporate = value; }
        }

        public double TotalExcessCorporate
        {
            get { return this._TotalExcessCorporate; }
            set { this._TotalExcessCorporate = value; }
        }

        public string PriPolEffecDate1
        {
            get { return _priPolEffecDate1; }
            set { _priPolEffecDate1 = value; }
        }

        public string PriPolLimits1
        {
            get { return _priPolLimits1; }
            set { _priPolLimits1 = value; }
        }
        public string PrMedicalLimit
        {
            get { return _prmedicalLimit; }
            set { _prmedicalLimit = value; }
        }


        public string PriCarierName1
        {
            get { return _priCarierName1; }
            set { _priCarierName1 = value; }
        }

        public string PriClaims1
        {
            get { return _priClaims1; }
            set { _priClaims1 = value; }
        }

        public int FinancialID
        {
            get
            {
                return this._FinancialID;
            }
            set
            {
                this._FinancialID = value;
            }
        }

        public int MainSpecialtyID
        {
            get
            {
                return this._MainSpecialtyID;
            }
            set
            {
                this._MainSpecialtyID = value;
            }
        }

        public int OtherSpecialtyIDA
        {
            get
            {
                return this._OtherSpecialtyIDA;
            }
            set
            {
                this._OtherSpecialtyIDA = value;
            }
        }

        public int OtherSpecialtyIDB
        {
            get
            {
                return this._OtherSpecialtyIDB;
            }
            set
            {
                this._OtherSpecialtyIDB = value;
            }
        }

        public bool Notification30Flag
        {
            get
            {
                return this._Notification30Flag;
            }
            set
            {
                this._Notification30Flag = value;
            }
        }

        public bool Notification15Flag
        {
            get
            {
                return this._Notification15Flag;
            }
            set
            {
                this._Notification15Flag = value;
            }
        }

        public bool CancellationFlag
        {
            get
            {
                return this._CancellationFlag;
            }
            set
            {
                this._CancellationFlag = value;
            }
        }

        public bool UpdateForm
        {
            get
            {
                return this._UpdateForm;
            }
            set
            {
                this._UpdateForm = value;
            }
        }

        public string Comments
        {
            get { return this._Comments; }
            set { this._Comments = value; }
        }

        public string RetroDate
        {
            get { return this._RetroDate; }
            set { this._RetroDate = value; }
        }

        public bool IsPolicy
        {
            get { return this._IsPolicy; }
            set { this._IsPolicy = value; }
        }

        public DataTable EndorsementCollection
        {
            get
            {
                if (this._EndorsementCollection == null)
                    this._EndorsementCollection = DataTableEndorsementTemp();
                return (this._EndorsementCollection);
            }
            set
            {
                this._EndorsementCollection = value;
            }
        }

        public DataTable Endorsement
        {
            get
            {
                this._Endorsement = GetEndorsementDetailByTaskControlID(TaskControlID);
                return (this._Endorsement);
            }
            set
            {
                this._Endorsement = value;
            }
        }

        public bool isEndorsement
        {
            get
            {
                return this._isEndorsement;
            }
            set
            {
                this._isEndorsement = value;
            }
        }
        public string GapBegDate
        {
            get
            {
                return this._GapBegDate;
            }
            set
            {
                this._GapBegDate = value;
            }
        }
        public string GapEndDate
        {
            get
            {
                return this._GapEndDate;
            }
            set
            {
                this._GapEndDate = value;
            }
        }
        public string GapBegDate2
        {
            get
            {
                return this._GapBegDate2;
            }
            set
            {
                this._GapBegDate2 = value;
            }
        }
        public string GapEndDate2
        {
            get
            {
                return this._GapEndDate2;
            }
            set
            {
                this._GapEndDate2 = value;
            }
        }
        public string GapBegDate3
        {
            get
            {
                return this._GapBegDate3;
            }
            set
            {
                this._GapBegDate3 = value;
            }
        }
        public string GapEndDate3
        {
            get
            {
                return this._GapEndDate3;
            }
            set
            {
                this._GapEndDate3 = value;
            }
        }
        public string NumberOfEmployees
        {
            get
            {
                return this._NumberOfEmployees;
            }
            set
            {
                this._NumberOfEmployees = value;
            }
        }

        #endregion

        #region Public Methods


        //private static DataTable GetPolicyByExactCriteria(int policyClass, string policyType, string policyNo, string certificate, string sufijo, string loanNo, string bank, string VIN, int UserID)
        //{
        //    DbRequestXmlCookRequestItem[] cookItems =
        //        new DbRequestXmlCookRequestItem[9];

        //    DbRequestXmlCooker.AttachCookItem("PolicyClass",
        //        SqlDbType.VarChar, 10, policyClass.ToString(),
        //        ref cookItems);

        //    DbRequestXmlCooker.AttachCookItem("PolicyType",
        //        SqlDbType.VarChar, 3, policyType.ToString(),
        //        ref cookItems);

        //    DbRequestXmlCooker.AttachCookItem("PolicyNo",
        //        SqlDbType.VarChar, 11, policyNo.ToString(),
        //        ref cookItems);

        //    DbRequestXmlCooker.AttachCookItem("Sufijo",
        //        SqlDbType.VarChar, 2, sufijo.ToString(),
        //        ref cookItems);

        //    DbRequestXmlCooker.AttachCookItem("Certificate",
        //        SqlDbType.VarChar, 10, certificate.ToString(),
        //        ref cookItems);

        //    DbRequestXmlCooker.AttachCookItem("LoanNo",
        //        SqlDbType.VarChar, 15, loanNo.ToString(),
        //        ref cookItems);

        //    DbRequestXmlCooker.AttachCookItem("Bank",
        //        SqlDbType.VarChar, 3, bank.ToString(),
        //        ref cookItems);

        //    DbRequestXmlCooker.AttachCookItem("VIN",
        //        SqlDbType.Char, 18, VIN.ToString(),
        //        ref cookItems);

        //    DbRequestXmlCooker.AttachCookItem("UserID",
        //        SqlDbType.Int, 0, UserID.ToString(),
        //        ref cookItems);
        //    XmlDocument xmlDoc;

        //    try
        //    {
        //        xmlDoc = DbRequestXmlCooker.Cook(cookItems);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Could not cook items.", ex);
        //    }

        //    Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

        //    DataTable dt = exec.GetQuery("GetPolicyByExactCriteria", xmlDoc);
        //    return dt;  //ard
        //}


        //public static DataTable GetExactPolicies(int policyClass, string policyType, string policyNo, string certificate, string sufijo, string loanNo, string bank, int UserID)
        //{
        //    string VIN = "";
        //    DataTable dt = GetPolicyByExactCriteria(policyClass, policyType, policyNo, certificate, sufijo, loanNo, bank, VIN, UserID);

        //    return dt;
        //}  //ard nuevo


        public static DataTable GetAgentByAgency(string AgencyID) ///alexis
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("AgencyID",
            SqlDbType.VarChar, 4, AgencyID.ToString(),
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

            DataTable dt = exec.GetQuery("GetAgentByAgency", xmlDoc);

            return dt;
        }

        public static DataTable GetAgent() ///alexis
        {


            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook();
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            DataTable dt = exec.GetQuery("GetAgent", xmlDoc);

            return dt;
        }



        public static DataTable GetEndorsementDetailByTaskControlID(int TaskControlID)
        {
            DataTable dt = GetEndorsementDetailByTaskControlIDDB(TaskControlID);
            return dt;
        }

        private static DataTable GetEndorsementDetailByTaskControlIDDB(int taskControlID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, taskControlID.ToString(),
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

            DataTable dt = exec.GetQuery("GetEnvironmentalPPLLocationDetailByTaskControlID", xmlDoc);

            return dt;
        }

        public void SaveCorporatePolicy(int UserID)
        {
            this.SavePol(UserID);
        }

        public override void SavePol(int UserID)
        {
            this._mode = (int)this.Mode;  // Se le asigna el mode de taskControl.
            this.PolicyMode = (int)this.Mode;  // Se le asigna el mode de taskControl.

            this.Validate();

            if(IsPolicy)
                base.ValidatePolicy();

            if (this._mode == 2)
                oldCorporatePolicyQuote = (CorporatePolicyQuote)CorporatePolicyQuote.GetTaskControlByTaskControlID(this.TaskControlID, UserID);

            if (this.Customer.CustomerNo.Trim() == "")
                this.Customer.Mode = 1;
            else
                this.Customer.Mode = 2;

            this.Customer.IsBusiness = false;
            this.Customer.Save(UserID);

            this.CustomerNo = this.Customer.CustomerNo;
            this.ProspectID = this.Customer.ProspectID;

            base.Save();

            if (this.IsPolicy)
                base.SavePol(UserID);

            SaveCorporatePolicyDB(UserID);  // Save CorporatePolicy
            SaveCorporatePolicyDetail(UserID, this.TaskControlID);  // Save CorporatePolicyDetail

            this._mode = (int)TaskControlMode.UPDATE;
            this.Mode = (int)TaskControlMode.CLEAR;
        }

        public override void Validate()
        {
            string errorMessage = String.Empty;

            //if (this.EffectiveDate == "")
            //    errorMessage = "Debes de entrar la fecha de efectividad.";
            //else
            //    if (this.PolicyClassID == 0)
            //        errorMessage = "Debes de escoger la linea de negocio.";
            //    else
            //        if (this.Customer.FirstName == "")
            //            errorMessage = "Debes de entrar el nombre.";
            //        else
            //            if (this.Customer.LastName1 == "")
            //                errorMessage = "Debes de entrar el primer apellido.";
            //            else
            //                if (this.OriginatedAt == 0)
            //                    errorMessage = "Debes de escoger Originado en.";
            //                else
            //                    if (this.TotalPremium == 0)
            //                        errorMessage = "La prima debe ser mayor que cero.";


            //throw the exception.
            if (errorMessage != String.Empty)
            {
                throw new Exception(errorMessage);
            }
        }

        public static CorporatePolicyQuote GetCorporatePolicyQuote(int taskControlID, bool IsPolicy)
        {
            CorporatePolicyQuote corporatePolicyQuote = null;

            DataTable dt = GetCorporatePolicyByTaskControlID(taskControlID,IsPolicy);

            corporatePolicyQuote = new CorporatePolicyQuote(IsPolicy);

            if (IsPolicy)
                corporatePolicyQuote = (CorporatePolicyQuote)Policy.GetPolicyByTaskControlID(taskControlID, corporatePolicyQuote);  //Policy

            corporatePolicyQuote._dtCorporatePolicyQuote = dt;

            corporatePolicyQuote = FillProperties(corporatePolicyQuote, taskControlID, IsPolicy);

            return corporatePolicyQuote;
        }

        public static CorporatePolicyQuote GetCorporatePolicyByAlexis(int taskControlID, bool IsPolicy)//Alexis
        {
            CorporatePolicyQuote corporatePolicyQuote = null;

            DataTable dt = GetCorporatePolicyByTaskControlIDByAlexis(taskControlID, IsPolicy);

            corporatePolicyQuote = new CorporatePolicyQuote(IsPolicy);

            if (IsPolicy)
                corporatePolicyQuote = (CorporatePolicyQuote)Policy.GetPolicyByTaskControlID(taskControlID, corporatePolicyQuote);  //Policy

            corporatePolicyQuote._dtCorporatePolicyQuote = dt;

            corporatePolicyQuote = FillProperties(corporatePolicyQuote, taskControlID, IsPolicy);

            return corporatePolicyQuote;
        }

        public static DataTable GetCorporatePolicy(int taskControlID, bool IsPolicy)
        {
            return GetCorporatePolicyByTaskControlID(taskControlID, IsPolicy);
        }

        public static void DeleteCorporatePolicyByTaskControlID(int taskControlID, bool IsPolicy)
        {
            DBRequest Executor = new DBRequest();

            try
            {
                Executor.BeginTrans();
                Executor.Update("DeleteCorporatePolicy", DeleteCorporatePolicyByTaskControlIDXml(taskControlID, IsPolicy));
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error, Please try again. " + xcp.Message, xcp);
            }
        }

        public static DataTable GetPRMEDICRATEPRIMARYByClassAndLimitID(string classs,int limitID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("class",
                SqlDbType.VarChar, 5, classs.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("prmedicallimitid",
                SqlDbType.Int, 0, limitID.ToString(),
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

            DataTable dt = exec.GetQuery("GetPRMEDICRATEPRIMARYByClassAndLimitID", xmlDoc);

            return dt;
        }

        public static DataTable GetPRMEDICRATEByClassAndLimitID(string classs,int limitID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("class",
                SqlDbType.VarChar, 5, classs.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("prmedicallimitid",
                SqlDbType.Int, 0, limitID.ToString(),
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

            DataTable dt = exec.GetQuery("GetPRMEDICRATEByClassAndLimitID", xmlDoc);

            return dt;
        }
        #endregion

        #region Private Methods


        private static DataTable GetCorporatePolicyByTaskControlID(int TaskControlID, bool IsPolicy)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",SqlDbType.Int, 0, TaskControlID.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("IsPolicy", SqlDbType.Bit, 0, IsPolicy.ToString(), ref cookItems);


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

            DataTable dt = exec.GetQuery("GetCorporatePolicyByTaskControlID", xmlDoc);
            return dt;
        }

        private static DataTable GetCorporatePolicyByTaskControlIDByAlexis(int TaskControlID, bool IsPolicy)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, TaskControlID.ToString(), ref cookItems);


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

            DataTable dt = exec.GetQuery("GetCorporatePolicyByTaskControlIDAlexisTest", xmlDoc);
            return dt;
        }

        private void SaveCorporatePolicyDB(int UserID)
        {
            Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
            try
            {
                Executor.BeginTrans();
                switch (this.Mode)
                {
                    case 1:  //ADD
                       this.CorporatePolicyQuoteID = Executor.Insert("AddCorporatePolicy", this.GetInsertCorporatePolicyXml());
                       this.History(this._mode, UserID);
                        break;

                    case 3:  //DELETE
                        //Executor.Update("DeleteAutoGuardServicesContract",this.GetDeletePoliciesXml());
                        break;

                    case 4:  //CLEAR						
                        break;

                    default: //UPDATE
                        this.History(this._mode, UserID);
                        this.CorporatePolicyQuoteID = Executor.Insert("AddCorporatePolicy", this.GetInsertCorporatePolicyXml());
                        break;
                }
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error tratando de salvar la poliza. " + xcp.Message, xcp);
            }
        }

        private static XmlDocument DeleteCorporatePolicyByTaskControlIDXml(int taskControlID, bool IsPolicy)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, taskControlID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("IsPolicy",
                SqlDbType.Bit, 0, IsPolicy.ToString(),
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

        private XmlDocument GetInsertCorporatePolicyXml()
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[89];

            DbRequestXmlCooker.AttachCookItem("CorporatePolicyQuoteID",SqlDbType.Int, 0, this.CorporatePolicyQuoteID.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TaskControlID",SqlDbType.Int, 0, this.TaskControlID.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Corporate", SqlDbType.VarChar, 100, this.Corporate.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("DiscountP", SqlDbType.Float, 0, this.DiscountP.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Discount", SqlDbType.Float, 0, this.Discount.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TotalPrimaryPremium", SqlDbType.Float, 0, this.TotalPrimaryPremium.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TotalExcessPremium", SqlDbType.Float, 0, this.TotalExcessPremium.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PrimaryTN1", SqlDbType.Float, 0, this.PrimaryTN1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PrimaryTN2", SqlDbType.Float, 0, this.PrimaryTN2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PrimaryTN3", SqlDbType.Float, 0, this.PrimaryTN3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PrimaryTN4", SqlDbType.Float, 0, this.PrimaryTN4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PrimaryTN5", SqlDbType.Float, 0, this.PrimaryTN5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("RateTN1", SqlDbType.Float, 0, this.RateTN1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("RateTN2", SqlDbType.Float, 0, this.RateTN2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("RateTN3", SqlDbType.Float, 0, this.RateTN3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("RateTN4", SqlDbType.Float, 0, this.RateTN4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("RateTN5", SqlDbType.Float, 0, this.RateTN5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("RateTN6", SqlDbType.Float, 0, this.RateTN6.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PremiumTN1", SqlDbType.Float, 0, this.PremiumTN1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PremiumTN2", SqlDbType.Float, 0, this.PremiumTN2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PremiumTN3", SqlDbType.Float, 0, this.PremiumTN3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PremiumTN4", SqlDbType.Float, 0, this.PremiumTN4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PremiumTN5", SqlDbType.Float, 0, this.PremiumTN5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("QuantityTN1", SqlDbType.Float, 0, this.QuantityTN1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("QuantityTN2", SqlDbType.Float, 0, this.QuantityTN2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("QuantityTN3", SqlDbType.Float, 0, this.QuantityTN3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("QuantityTN4", SqlDbType.Float, 0, this.QuantityTN4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("QuantityTN5", SqlDbType.Float, 0, this.QuantityTN5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("QuantityTN6", SqlDbType.Float, 0, this.QuantityTN6.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TotPremTN1", SqlDbType.Float, 0, this.TotPremTN1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TotPremTN2", SqlDbType.Float, 0, this.TotPremTN2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TotPremTN3", SqlDbType.Float, 0, this.TotPremTN3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TotPremTN4", SqlDbType.Float, 0, this.TotPremTN4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TotPremTN5", SqlDbType.Float, 0, this.TotPremTN5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TotPremTN6", SqlDbType.Float, 0, this.TotPremTN6.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcessTN1", SqlDbType.Float, 0, this.ExcessTN1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcessTN2", SqlDbType.Float, 0, this.ExcessTN2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcessTN3", SqlDbType.Float, 0, this.ExcessTN3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcessTN4", SqlDbType.Float, 0, this.ExcessTN4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcessTN5", SqlDbType.Float, 0, this.ExcessTN5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ERateTN1", SqlDbType.Float, 0, this.ERateTN1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ERateTN2", SqlDbType.Float, 0, this.ERateTN2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ERateTN3", SqlDbType.Float, 0, this.ERateTN3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ERateTN4", SqlDbType.Float, 0, this.ERateTN4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ERateTN5", SqlDbType.Float, 0, this.ERateTN5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ERateTN6", SqlDbType.Float, 0, this.ERateTN6.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EPremiumTN1", SqlDbType.Float, 0, this.EPremiumTN1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EPremiumTN2", SqlDbType.Float, 0, this.EPremiumTN2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EPremiumTN3", SqlDbType.Float, 0, this.EPremiumTN3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EPremiumTN4", SqlDbType.Float, 0, this.EPremiumTN4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EPremiumTN5", SqlDbType.Float, 0, this.EPremiumTN5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EQuantityTN1", SqlDbType.Float, 0, this.EQuantityTN1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EQuantityTN2", SqlDbType.Float, 0, this.EQuantityTN2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EQuantityTN3", SqlDbType.Float, 0, this.EQuantityTN3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EQuantityTN4", SqlDbType.Float, 0, this.EQuantityTN4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EQuantityTN5", SqlDbType.Float, 0, this.EQuantityTN5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EQuantityTN6", SqlDbType.Float, 0, this.EQuantityTN6.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ETotPremTN1", SqlDbType.Float, 0, this.ETotPremTN1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ETotPremTN2", SqlDbType.Float, 0, this.ETotPremTN2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ETotPremTN3", SqlDbType.Float, 0, this.ETotPremTN3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ETotPremTN4", SqlDbType.Float, 0, this.ETotPremTN4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ETotPremTN5", SqlDbType.Float, 0, this.ETotPremTN5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ETotPremTN6", SqlDbType.Float, 0, this.ETotPremTN6.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TotalPrimaryCorporate", SqlDbType.Float, 0, this.TotalPrimaryCorporate.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TotalExcessCorporate", SqlDbType.Float, 0, this.TotalExcessCorporate.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("IsPolicy",SqlDbType.Bit, 0, this.IsPolicy.ToString(),ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Comments", SqlDbType.VarChar, 200, this.Comments.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("FinancialID",SqlDbType.Int, 0, this.FinancialID.ToString(),ref cookItems);
            DbRequestXmlCooker.AttachCookItem("MainSpecialtyID", SqlDbType.Int, 0, this.MainSpecialtyID.ToString(),ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OtherSpecialtyIDA", SqlDbType.Int, 0, this.OtherSpecialtyIDA.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OtherSpecialtyIDB", SqlDbType.Int, 0, this.OtherSpecialtyIDB.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Notification30Flag",SqlDbType.Bit, 0, this.Notification30Flag.ToString(),ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Notification15Flag",SqlDbType.Bit, 0, this.Notification15Flag.ToString(),ref cookItems);
            DbRequestXmlCooker.AttachCookItem("CancellationFlag",SqlDbType.Bit, 0, this.CancellationFlag.ToString(),ref cookItems);
            DbRequestXmlCooker.AttachCookItem("UpdateForm", SqlDbType.Bit, 0, this.UpdateForm.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("GapBegDate", SqlDbType.VarChar, 15, this.GapBegDate.ToString(),ref cookItems);
            DbRequestXmlCooker.AttachCookItem("GapEndDate", SqlDbType.VarChar, 15, this.GapEndDate.ToString(),ref cookItems);
            DbRequestXmlCooker.AttachCookItem("GapBegDate2",SqlDbType.VarChar, 15, this.GapBegDate2.ToString(),ref cookItems);
            DbRequestXmlCooker.AttachCookItem("GapEndDate2",SqlDbType.VarChar, 15, this.GapEndDate2.ToString(),ref cookItems);
            DbRequestXmlCooker.AttachCookItem("GapBegDate3",SqlDbType.VarChar, 15, this.GapBegDate3.ToString(),ref cookItems);
            DbRequestXmlCooker.AttachCookItem("GapEndDate3",SqlDbType.VarChar, 15, this.GapEndDate3.ToString(),ref cookItems);
            DbRequestXmlCooker.AttachCookItem("NumberOfEmployees", SqlDbType.VarChar, 10, this.NumberOfEmployees.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriCarierName1", SqlDbType.VarChar, 75, this.PriCarierName1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriPolEffecDate1", SqlDbType.VarChar, 8, this.PriPolEffecDate1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriPolLimits1", SqlDbType.VarChar, 50, this.PriPolLimits1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriClaims1", SqlDbType.VarChar, 50, this.PriClaims1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("RetroDate", SqlDbType.VarChar, 20, this.RetroDate.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PrMedicalLimit", SqlDbType.VarChar, 20, this.PrMedicalLimit.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OtherPersonel", SqlDbType.VarChar, 15, this.OtherPersonel.ToString(), ref cookItems);
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

        private static CorporatePolicyQuote FillProperties(CorporatePolicyQuote corporatePolicyQuote, int taskControlID,bool IsPolicy)
        {
            corporatePolicyQuote.CorporatePolicyQuoteID = (int)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["CorporatePolicyQuoteID"];
            corporatePolicyQuote.TaskControlID = (int)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["TaskControlID"];
            corporatePolicyQuote.Corporate = corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["Corporate"].ToString();
            corporatePolicyQuote.DiscountP = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["DiscountP"];
            corporatePolicyQuote.Discount = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["Discount"];            
            corporatePolicyQuote.TotalPrimaryPremium = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["TotalPrimaryPremium"];
            corporatePolicyQuote.TotalExcessPremium = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["TotalExcessPremium"];
            corporatePolicyQuote.PrimaryTN1 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["PrimaryTN1"];
            corporatePolicyQuote.PrimaryTN2 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["PrimaryTN2"];
            corporatePolicyQuote.PrimaryTN3 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["PrimaryTN3"];
            corporatePolicyQuote.PrimaryTN4 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["PrimaryTN4"];
            corporatePolicyQuote.PrimaryTN5 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["PrimaryTN5"];
            corporatePolicyQuote.RateTN1 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["RateTN1"];
            corporatePolicyQuote.RateTN2 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["RateTN2"];
            corporatePolicyQuote.RateTN3 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["RateTN3"];
            corporatePolicyQuote.RateTN4 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["RateTN4"];
            corporatePolicyQuote.RateTN5 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["RateTN5"];
            corporatePolicyQuote.RateTN6 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["RateTN6"];
            corporatePolicyQuote.PremiumTN1 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["PremiumTN1"];
            corporatePolicyQuote.PremiumTN2 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["PremiumTN2"];
            corporatePolicyQuote.PremiumTN3 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["PremiumTN3"];
            corporatePolicyQuote.PremiumTN4 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["PremiumTN4"];
            corporatePolicyQuote.PremiumTN5 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["PremiumTN5"];
            corporatePolicyQuote.QuantityTN1 = (int)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["QuantityTN1"];
            corporatePolicyQuote.QuantityTN2 = (int)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["QuantityTN2"];
            corporatePolicyQuote.QuantityTN3 = (int)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["QuantityTN3"];
            corporatePolicyQuote.QuantityTN4 = (int)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["QuantityTN4"];
            corporatePolicyQuote.QuantityTN5 = (int)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["QuantityTN5"];
            corporatePolicyQuote.QuantityTN6 = (int)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["QuantityTN6"];
            corporatePolicyQuote.TotPremTN1 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["TotPremTN1"];
            corporatePolicyQuote.TotPremTN2 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["TotPremTN2"];
            corporatePolicyQuote.TotPremTN3 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["TotPremTN3"];
            corporatePolicyQuote.TotPremTN4 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["TotPremTN4"];
            corporatePolicyQuote.TotPremTN5 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["TotPremTN5"];
            corporatePolicyQuote.TotPremTN6 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["TotPremTN6"];
            corporatePolicyQuote.ExcessTN1 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["ExcessTN1"];
            corporatePolicyQuote.ExcessTN2 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["ExcessTN2"];
            corporatePolicyQuote.ExcessTN3 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["ExcessTN3"];
            corporatePolicyQuote.ExcessTN4 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["ExcessTN4"];
            corporatePolicyQuote.ExcessTN5 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["ExcessTN5"];
            corporatePolicyQuote.ERateTN1 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["ERateTN1"];
            corporatePolicyQuote.ERateTN2 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["ERateTN2"];
            corporatePolicyQuote.ERateTN3 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["ERateTN3"];
            corporatePolicyQuote.ERateTN4 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["ERateTN4"];
            corporatePolicyQuote.ERateTN5 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["ERateTN5"];
            corporatePolicyQuote.ERateTN6 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["ERateTN6"];
            corporatePolicyQuote.EPremiumTN1 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["EPremiumTN1"];
            corporatePolicyQuote.EPremiumTN2 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["EPremiumTN2"];
            corporatePolicyQuote.EPremiumTN3 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["EPremiumTN3"];
            corporatePolicyQuote.EPremiumTN4 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["EPremiumTN4"];
            corporatePolicyQuote.EPremiumTN5 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["EPremiumTN5"];
            corporatePolicyQuote.EQuantityTN1 = (int)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["EQuantityTN1"];
            corporatePolicyQuote.EQuantityTN2 = (int)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["EQuantityTN2"];
            corporatePolicyQuote.EQuantityTN3 = (int)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["EQuantityTN3"];
            corporatePolicyQuote.EQuantityTN4 = (int)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["EQuantityTN4"];
            corporatePolicyQuote.EQuantityTN5 = (int)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["EQuantityTN5"];
            corporatePolicyQuote.EQuantityTN6 = (int)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["EQuantityTN6"];
            corporatePolicyQuote.ETotPremTN1 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["ETotPremTN1"];
            corporatePolicyQuote.ETotPremTN2 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["ETotPremTN2"];
            corporatePolicyQuote.ETotPremTN3 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["ETotPremTN3"];
            corporatePolicyQuote.ETotPremTN4 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["ETotPremTN4"];
            corporatePolicyQuote.ETotPremTN5 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["ETotPremTN5"];
            corporatePolicyQuote.ETotPremTN6 = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["ETotPremTN6"];
            corporatePolicyQuote.TotalPrimaryCorporate = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["TotalPrimaryCorporate"];
            corporatePolicyQuote.TotalExcessCorporate = (double)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["TotalExcessCorporate"];
            corporatePolicyQuote.Comments = corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["Comments"].ToString();

            corporatePolicyQuote.IsPolicy = IsPolicy;

            if (IsPolicy)
            {
                corporatePolicyQuote.FinancialID = (corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["FinancialID"] != System.DBNull.Value) ? (int)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["FinancialID"] : 0;
                corporatePolicyQuote.MainSpecialtyID = (corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["MainSpecialtyID"] != System.DBNull.Value) ? (int)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["MainSpecialtyID"] : 0;
                corporatePolicyQuote.OtherSpecialtyIDA = (corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["OtherSpecialtyIDA"] != System.DBNull.Value) ? (int)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["OtherSpecialtyIDA"] : 0;
                corporatePolicyQuote.OtherSpecialtyIDB = (corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["OtherSpecialtyIDB"] != System.DBNull.Value) ? (int)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["OtherSpecialtyIDB"] : 0;
                corporatePolicyQuote.Notification30Flag = (corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["Notification30Flag"] != System.DBNull.Value) ? (bool)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["Notification30Flag"] : false;
                corporatePolicyQuote.Notification15Flag = (corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["Notification15Flag"] != System.DBNull.Value) ? (bool)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["Notification15Flag"] : false;
                corporatePolicyQuote.CancellationFlag = (corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["CancellationFlag"] != System.DBNull.Value) ? (bool)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["CancellationFlag"] : false;
                corporatePolicyQuote.UpdateForm = (corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["UpdateForm"] != System.DBNull.Value) ? (bool)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["UpdateForm"] : false;
                corporatePolicyQuote.GapBegDate = corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["GapBegDate"].ToString();
                corporatePolicyQuote.GapEndDate = corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["GapEndDate"].ToString();
                corporatePolicyQuote.GapBegDate2 = corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["GapBegDate2"].ToString();
                corporatePolicyQuote.GapEndDate2 = corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["GapEndDate2"].ToString();
                corporatePolicyQuote.GapBegDate3 = corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["GapBegDate3"].ToString();
                corporatePolicyQuote.GapEndDate3 = corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["GapEndDate3"].ToString();
                corporatePolicyQuote.NumberOfEmployees = corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["NumberOfEmployees"].ToString();
                corporatePolicyQuote.PriCarierName1 = corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["PriCarierName1"].ToString();
                corporatePolicyQuote.PriPolEffecDate1 = (corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["PriPolEffecDate1"] != System.DBNull.Value) ? ((DateTime)corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["PriPolEffecDate1"]).ToShortDateString() : "";
                corporatePolicyQuote.PriPolLimits1 = corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["PriPolLimits1"].ToString();
                corporatePolicyQuote.PriClaims1 = corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["PriClaims1"].ToString();
                corporatePolicyQuote.PrMedicalLimit = (corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["PrMedicalLimit"] != System.DBNull.Value) ? corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["PrMedicalLimit"].ToString() : "";
                corporatePolicyQuote.OtherPersonel = (corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["OtherPersonel"] != System.DBNull.Value) ? corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["OtherPersonel"].ToString() : "";
            }
            else
                corporatePolicyQuote.RetroDate = corporatePolicyQuote._dtCorporatePolicyQuote.Rows[0]["RetroDate"].ToString();

            corporatePolicyQuote.CorporatePolicyDetailCollection = GetCorporatePolicyDetailByTaskControlID(taskControlID,IsPolicy);

            return corporatePolicyQuote;
        }

        #endregion

        public void SaveCorporatePolicyDetail(int UserID, int taskControlID)
        {
            DBRequest Executor = new DBRequest();
            Executor.Update("DeleteCorporatePolicyDetailByTaskControlID", DeleteCorporatePolicyDetailByTaskControlIDXml(taskControlID));

            for (int i = 0; i < CorporatePolicyDetailCollection.Rows.Count; i++)
            {
                this.Mode = 1; //Add

                Executor.BeginTrans();
                int dependienteID = Executor.Insert("AddCorporatePolicyDetail", this.GetInsertCorporatePolicyDetailXml(i));
                Executor.CommitTrans();
            }

            //this.Mode = (int)DwellingPropertiesMode.CLEAR;
        }

        private XmlDocument DeleteCorporatePolicyDetailByTaskControlIDXml(int taskControlID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, taskControlID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("IsPolicy", 
                SqlDbType.Bit, 0, this.IsPolicy.ToString(), 
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

        private XmlDocument GetInsertCorporatePolicyDetailXml(int index)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[10];

            DbRequestXmlCooker.AttachCookItem("CorporatePolicyDetailQuoteID",SqlDbType.Int, 0, CorporatePolicyDetailCollection.Rows[index]["CorporatePolicyDetailQuoteID"].ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TaskControlID",SqlDbType.Int, 0, this.TaskControlID.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("CustomerName", SqlDbType.VarChar, 75, CorporatePolicyDetailCollection.Rows[index]["CustomerName"].ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PrimaryRate", SqlDbType.VarChar, 20, CorporatePolicyDetailCollection.Rows[index]["PrimaryRate"].ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcessRate", SqlDbType.VarChar, 20, CorporatePolicyDetailCollection.Rows[index]["ExcessRate"].ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Specialty", SqlDbType.VarChar, 75, CorporatePolicyDetailCollection.Rows[index]["Specialty"].ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("IsoCode", SqlDbType.VarChar, 20, CorporatePolicyDetailCollection.Rows[index]["IsoCode"].ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TotalPrimaryPremium", SqlDbType.VarChar, 20, CorporatePolicyDetailCollection.Rows[index]["TotalPrimaryPremium"].ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TotalExcessPremium", SqlDbType.VarChar, 20, CorporatePolicyDetailCollection.Rows[index]["TotalExcessPremium"].ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("IsPolicy", SqlDbType.Bit, 0, this.IsPolicy.ToString(), ref cookItems);

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

        public static DataTable GetCorporatePolicyDetailByTaskControlID(int TaskControlID, bool IsPolicy)
        {
            DataTable dt = GetCorporatePolicyDetailByTaskControlIDDB(TaskControlID,IsPolicy);
            return dt;
        }

        private static DataTable GetCorporatePolicyDetailByTaskControlIDDB(int taskControlID, bool IsPolicy)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, taskControlID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("IsPolicy",
            SqlDbType.Bit, 0, IsPolicy.ToString(),
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

            DataTable dt = exec.GetQuery("GetCorporatePolicyDetailByTaskControlID", xmlDoc);

            return dt;
        }

        private DataTable DataTableCorporatePolicyDetailTemp() //temp
        {
            DataTable myDataTable = new DataTable("DataTableCorporatePoliciesTemp");
            DataColumn myDataColumn;

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "CorporatePolicyDetailQuoteID";
            myDataColumn.AutoIncrement = true;
            myDataColumn.AutoIncrementSeed = 1;
            myDataColumn.AutoIncrementStep = 1;
            myDataColumn.AllowDBNull = false;
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
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "CustomerName";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "CustomerName";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "PrimaryRate";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "PrimaryRate";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "ExcessRate";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "ExcessRate";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "Specialty";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "Specialty";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "IsoCode";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "IsoCode";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "TotalPrimaryPremium";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "TotalPrimaryPremium";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "TotalExcessPremium";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "TotalExcessPremium";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = myDataTable.Columns["ID"];
            myDataTable.PrimaryKey = PrimaryKeyColumns;

            return myDataTable;
        }

        private DataTable DataTableEndorsementTemp()
        {
            DataTable myDataTable = new DataTable("DataTableEndorsementTemp");
            DataColumn myDataColumn;

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "TaskControlID";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "TaskControlID";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "EndorseNo";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "EndorseNo";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "EndorsePrepDt";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "EndorsePrepDt";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "EndorseEffDt";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "EndorseEffDt";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Float");
            myDataColumn.ColumnName = "EndorsePrem";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "EndorsePrem";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "EndorseType";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "EndorseType";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "EndorseComment";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "EndorseComment";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "LocationID";
            myDataColumn.AutoIncrement = true;
            myDataColumn.AutoIncrementSeed = 1;
            myDataColumn.AutoIncrementStep = 1;
            myDataColumn.AllowDBNull = false;
            myDataColumn.ReadOnly = true;
            myDataColumn.Unique = true;
            myDataTable.Columns.Add(myDataColumn);

            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[8];
            PrimaryKeyColumns[0] = myDataTable.Columns["EndorsementDetailID"];
            myDataTable.PrimaryKey = PrimaryKeyColumns;

            return myDataTable;
        }

        #region History

        private void History(int mode, int userID)
        {
            Audit.History history = new Audit.History();
            LookupTables.Agency agencyOld = new LookupTables.Agency();
            LookupTables.Agency agency = new LookupTables.Agency();
            LookupTables.Agent agentOld = new LookupTables.Agent();
            LookupTables.Agent agent = new LookupTables.Agent();

            if (_mode == 2)
            {
                

                // Campos de TaskControl
                history.BuildNotesForHistory("TaskControlTypeID",
                    LookupTables.LookupTables.GetDescription("TaskControlType", oldCorporatePolicyQuote.TaskControlTypeID.ToString()),
                    LookupTables.LookupTables.GetDescription("TaskControlType", this.TaskControlTypeID.ToString()),
                    mode);
                history.BuildNotesForHistory("TaskStatusID",
                    LookupTables.LookupTables.GetDescription("TaskStatus", oldCorporatePolicyQuote.TaskStatusID.ToString()),
                    LookupTables.LookupTables.GetDescription("TaskStatus", this.TaskStatusID.ToString()),
                    mode);
                history.BuildNotesForHistory("ProspectID", oldCorporatePolicyQuote.ProspectID.ToString(), this.ProspectID.ToString(), mode);
                history.BuildNotesForHistory("CustomerNo", oldCorporatePolicyQuote.CustomerNo, this.CustomerNo, mode);
                history.BuildNotesForHistory("PolicyID", oldCorporatePolicyQuote.PolicyID.ToString(), this.PolicyID.ToString(), mode);
                history.BuildNotesForHistory("PolicyClassID",
                    LookupTables.LookupTables.GetDescription("PolicyClass", oldCorporatePolicyQuote.PolicyClassID.ToString()),
                    LookupTables.LookupTables.GetDescription("PolicyClass", this.PolicyClassID.ToString()),
                    mode);

                agencyOld.GetAgency(oldCorporatePolicyQuote.Agency.ToString());
                agency.GetAgency(this.Agency.ToString());
                history.BuildNotesForHistory("Agency", agencyOld.AgencyDesc, agency.AgencyDesc, mode);

                agentOld.GetAgent(oldCorporatePolicyQuote.Agent.ToString());
                agent.GetAgent(this.Agent.ToString());
                history.BuildNotesForHistory("Agent", agentOld.AgentDesc, agent.AgentDesc, mode);

                history.BuildNotesForHistory("SupplierID", oldCorporatePolicyQuote.SupplierID, this.SupplierID, mode);
                history.BuildNotesForHistory("Group",
                    LookupTables.LookupTables.GetDescription("MasterPolicy", oldCorporatePolicyQuote.Bank.ToString()),
                    LookupTables.LookupTables.GetDescription("MasterPolicy", this.Bank.ToString()),
                    mode);
                history.BuildNotesForHistory("InsuranceCompany",
                    LookupTables.LookupTables.GetDescription("InsuranceCompany", oldCorporatePolicyQuote.InsuranceCompany.ToString()),
                    LookupTables.LookupTables.GetDescription("InsuranceCompany", this.InsuranceCompany.ToString()),
                    mode);
                history.BuildNotesForHistory("Dealer", oldCorporatePolicyQuote.Dealer, this.Dealer, mode);
                history.BuildNotesForHistory("Corporation",
                    LookupTables.LookupTables.GetDescription("MasterPolicy", oldCorporatePolicyQuote.CompanyDealer.ToString()),
                    LookupTables.LookupTables.GetDescription("MasterPolicy", this.CompanyDealer.ToString()),
                    mode);
                history.BuildNotesForHistory("CloseDate", oldCorporatePolicyQuote.CloseDate, this.CloseDate, mode);
                history.BuildNotesForHistory("EnteredBy", oldCorporatePolicyQuote.EnteredBy, this.EnteredBy, mode);
                // Terminan Campos TaskControl

                // Campos de CorporatePolicy
                //history.BuildNotesForHistory("Additional Carrier Name", oldCorporatePolicyQuote.PriCarierName1.ToString(), this.PriCarierName1.ToString(), mode);
                //history.BuildNotesForHistory("Additional Effective Date", oldCorporatePolicyQuote.PriPolEffecDate1.ToString(), this.PriPolEffecDate1.ToString(), mode);
                //history.BuildNotesForHistory("Additional Policy Limits", oldCorporatePolicyQuote.PriPolLimits1.ToString(), this.PriPolLimits1.ToString(), mode);
                //history.BuildNotesForHistory("Additional Policy No.", oldCorporatePolicyQuote.PriClaims1, this.PriClaims1, mode);
                    //Campo de Empleados Primaria
                history.BuildNotesForHistory("Primary Physician Assistant Rate", oldCorporatePolicyQuote.RateTN1.ToString().Trim(), this.RateTN1.ToString().Trim(), mode);
                history.BuildNotesForHistory("Primary Nurse Midwife Rate", oldCorporatePolicyQuote.RateTN2.ToString().Trim(), this.RateTN2.ToString().Trim(), mode);
                history.BuildNotesForHistory("Primary Nurse Anesthetist Rate", oldCorporatePolicyQuote.RateTN3.ToString().Trim(), this.RateTN3.ToString().Trim(), mode);
                history.BuildNotesForHistory("Primary Nurse Practitioner Rate", oldCorporatePolicyQuote.RateTN4.ToString().Trim(), this.RateTN4.ToString().Trim(), mode);
                history.BuildNotesForHistory("Primary All Other Personel Rate", oldCorporatePolicyQuote.RateTN5.ToString().Trim(), this.RateTN5.ToString().Trim(), mode);
                history.BuildNotesForHistory("Primary Physician Assistant Qty.", oldCorporatePolicyQuote.QuantityTN1.ToString().Trim(), this.QuantityTN1.ToString().Trim(), mode);
                history.BuildNotesForHistory("Primary Nurse Midwife Qty.", oldCorporatePolicyQuote.QuantityTN2.ToString().Trim(), this.QuantityTN2.ToString().Trim(), mode);
                history.BuildNotesForHistory("Primary Nurse Anesthetist Qty.", oldCorporatePolicyQuote.QuantityTN3.ToString().Trim(), this.QuantityTN3.ToString().Trim(), mode);
                history.BuildNotesForHistory("Primary Nurse Practitioner Qty.", oldCorporatePolicyQuote.QuantityTN4.ToString().Trim(), this.QuantityTN4.ToString().Trim(), mode);
                history.BuildNotesForHistory("Primary All Other Personel Qty.", oldCorporatePolicyQuote.QuantityTN5.ToString().Trim(), this.QuantityTN5.ToString().Trim(), mode);
                    //Campo de Empleados Excess
                history.BuildNotesForHistory("Excess Physician Assistant Rate", oldCorporatePolicyQuote.ERateTN1.ToString().Trim(), this.ERateTN1.ToString().Trim(), mode);
                history.BuildNotesForHistory("Excess Nurse Midwife Rate", oldCorporatePolicyQuote.ERateTN2.ToString().Trim(), this.ERateTN2.ToString().Trim(), mode);
                history.BuildNotesForHistory("Excess Nurse Anesthetist Rate", oldCorporatePolicyQuote.ERateTN3.ToString().Trim(), this.ERateTN3.ToString().Trim(), mode);
                history.BuildNotesForHistory("Excess Nurse Practitioner Rate", oldCorporatePolicyQuote.ERateTN4.ToString().Trim(), this.ERateTN4.ToString().Trim(), mode);
                history.BuildNotesForHistory("Excess All Other Personel Rate", oldCorporatePolicyQuote.ERateTN5.ToString().Trim(), this.ERateTN5.ToString().Trim(), mode);
                history.BuildNotesForHistory("Excess Physician Assistant Qty.", oldCorporatePolicyQuote.EQuantityTN1.ToString().Trim(), this.EQuantityTN1.ToString().Trim(), mode);
                history.BuildNotesForHistory("Excess Nurse Midwife Qty.", oldCorporatePolicyQuote.EQuantityTN2.ToString().Trim(), this.EQuantityTN2.ToString().Trim(), mode);
                history.BuildNotesForHistory("Excess Nurse Anesthetist Qty.", oldCorporatePolicyQuote.EQuantityTN3.ToString().Trim(), this.EQuantityTN3.ToString().Trim(), mode);
                history.BuildNotesForHistory("Excess Nurse Practitioner Qty.", oldCorporatePolicyQuote.EQuantityTN4.ToString().Trim(), this.EQuantityTN4.ToString().Trim(), mode);
                history.BuildNotesForHistory("Excess All Other Personel Qty.", oldCorporatePolicyQuote.EQuantityTN5.ToString().Trim(), this.EQuantityTN5.ToString().Trim(), mode);
                // Terminan Campos CorporatePolicy

                // Campos de Policy
                if (this.IsPolicy)
                {
                    history.BuildNotesForHistory("DepartmentID",
                        LookupTables.LookupTables.GetDescription("Department", oldCorporatePolicyQuote.DepartmentID.ToString()),
                        LookupTables.LookupTables.GetDescription("Department", this.DepartmentID.ToString()),
                        mode);
                    history.BuildNotesForHistory("PolicyType", oldCorporatePolicyQuote.PolicyType, this.PolicyType, mode);
                    history.BuildNotesForHistory("PolicyNo", oldCorporatePolicyQuote.PolicyNo, this.PolicyNo, mode);
                    history.BuildNotesForHistory("Certificate", oldCorporatePolicyQuote.Certificate, this.Certificate, mode);
                    history.BuildNotesForHistory("Suffix", oldCorporatePolicyQuote.Suffix, this.Suffix, mode);
                    history.BuildNotesForHistory("LoanNo", oldCorporatePolicyQuote.LoanNo.ToString(), this.LoanNo.ToString(), mode);
                    history.BuildNotesForHistory("Term", oldCorporatePolicyQuote.Term.ToString(), this.Term.ToString(), mode);
                    history.BuildNotesForHistory("EffectiveDate", DateTime.Parse(oldCorporatePolicyQuote.EffectiveDate.ToString()).ToShortDateString(), DateTime.Parse(this.EffectiveDate.ToString()).ToShortDateString(), mode);
                    history.BuildNotesForHistory("ExpirationDate", oldCorporatePolicyQuote.ExpirationDate.ToString(), this.ExpirationDate.ToString(), mode);
                   //03/22/2016
                    history.BuildNotesForHistory("GapBegDate1", oldCorporatePolicyQuote.GapBegDate.ToString(), this.GapBegDate.ToString(), mode);
                    history.BuildNotesForHistory("GapBegDate2", oldCorporatePolicyQuote.GapBegDate2.ToString(), this.GapBegDate2.ToString(), mode);
                    history.BuildNotesForHistory("GapBegDate3", oldCorporatePolicyQuote.GapBegDate3.ToString(), this.GapBegDate3.ToString(), mode);
                    history.BuildNotesForHistory("GapEndDate1", oldCorporatePolicyQuote.GapEndDate.ToString(), this.GapEndDate.ToString(), mode);
                    history.BuildNotesForHistory("GapEndDate2", oldCorporatePolicyQuote.GapEndDate2.ToString(), this.GapEndDate2.ToString(), mode);
                    history.BuildNotesForHistory("GapEndDate3", oldCorporatePolicyQuote.GapEndDate3.ToString(), this.GapEndDate3.ToString(), mode);
                    history.BuildNotesForHistory("Anniversariy", oldCorporatePolicyQuote.Anniversary.ToString(), this.Anniversary.ToString(), mode);
                    history.BuildNotesForHistory("Employees No.", oldCorporatePolicyQuote.NumberOfEmployees.ToString(), this.NumberOfEmployees.ToString(), mode);
                    history.BuildNotesForHistory("Update Form", oldCorporatePolicyQuote.UpdateForm.ToString(), this.UpdateForm.ToString(), mode);
                    history.BuildNotesForHistory("Limit", oldCorporatePolicyQuote.PrMedicalLimit.ToString(), this.PrMedicalLimit.ToString(), mode);
                    //-
                    history.BuildNotesForHistory("PolicyLimit", oldCorporatePolicyQuote.PrMedicalLimit.ToString(), this.PrMedicalLimit.ToString(), mode);
                    history.BuildNotesForHistory("Charge", oldCorporatePolicyQuote.Charge.ToString(), this.Charge.ToString(), mode);
                    history.BuildNotesForHistory("TotalPremium", oldCorporatePolicyQuote.TotalPremium.ToString(), this.TotalPremium.ToString(), mode);
                    history.BuildNotesForHistory("Status", oldCorporatePolicyQuote.Status.ToString(), this.Status.ToString(), mode);
                    history.BuildNotesForHistory("CommissionAgency", oldCorporatePolicyQuote.CommissionAgency.ToString(), this.CommissionAgency.ToString(), mode);
                    history.BuildNotesForHistory("CommissionAgencyPercent", oldCorporatePolicyQuote.CommissionAgencyPercent.ToString(), this.CommissionAgencyPercent.ToString(), mode);
                    history.BuildNotesForHistory("CommissionAgent", oldCorporatePolicyQuote.CommissionAgent.ToString(), this.CommissionAgent.ToString(), mode);
                    history.BuildNotesForHistory("CommissionAgentPercent", oldCorporatePolicyQuote.CommissionAgentPercent.ToString(), this.CommissionAgentPercent.ToString(), mode);
                    history.BuildNotesForHistory("CommissionDate", oldCorporatePolicyQuote.CommissionDate.ToString(), this.CommissionDate.ToString(), mode);
                    history.BuildNotesForHistory("CancellationDate", oldCorporatePolicyQuote.CancellationDate.ToString(), this.CancellationDate.ToString(), mode);
                    history.BuildNotesForHistory("CancellationEntryDate", oldCorporatePolicyQuote.CancellationEntryDate.ToString(), this.CancellationEntryDate.ToString(), mode);
                    history.BuildNotesForHistory("CancellationUnearnedPercent", oldCorporatePolicyQuote.CancellationUnearnedPercent.ToString(), this.CancellationUnearnedPercent.ToString(), mode);
                    history.BuildNotesForHistory("ReturnPremium", oldCorporatePolicyQuote.ReturnPremium.ToString(), this.ReturnPremium.ToString(), mode);
                    history.BuildNotesForHistory("ReturnCharge", oldCorporatePolicyQuote.ReturnCharge.ToString(), this.ReturnCharge.ToString(), mode);
                    history.BuildNotesForHistory("CancellationAmount", oldCorporatePolicyQuote.CancellationAmount.ToString(), this.CancellationAmount.ToString(), mode);
                    history.BuildNotesForHistory("CancellationMethod", oldCorporatePolicyQuote.CancellationMethod.ToString(), this.CancellationMethod.ToString(), mode);
                    history.BuildNotesForHistory("CancellationReason", oldCorporatePolicyQuote.CancellationReason.ToString(), this.CancellationReason.ToString(), mode);
                    history.BuildNotesForHistory("ReturnCommissionAgency", oldCorporatePolicyQuote.ReturnCommissionAgency.ToString(), this.ReturnCommissionAgency.ToString(), mode);
                    history.BuildNotesForHistory("ReturnCommissionAgent", oldCorporatePolicyQuote.ReturnCommissionAgent.ToString(), this.ReturnCommissionAgent.ToString(), mode);
                    history.BuildNotesForHistory("PaidAmount", oldCorporatePolicyQuote.PaidAmount.ToString(), this.PaidAmount.ToString(), mode);
                    history.BuildNotesForHistory("PaidDate", oldCorporatePolicyQuote.PaidDate.ToString(), this.PaidDate.ToString(), mode);
                    history.BuildNotesForHistory("AutoAssignPolicy", oldCorporatePolicyQuote.AutoAssignPolicy.ToString(), this.AutoAssignPolicy.ToString(), mode);
                    history.BuildNotesForHistory("Group Disc.", oldCorporatePolicyQuote.InvoiceNumber.ToString(), this.InvoiceNumber.ToString(), mode);
                    history.BuildNotesForHistory("FileNumber", oldCorporatePolicyQuote.FileNumber.ToString(), this.FileNumber.ToString(), mode);
                    history.BuildNotesForHistory("IsLeasing", oldCorporatePolicyQuote.IsLeasing.ToString(), this.IsLeasing.ToString(), mode);
                    history.BuildNotesForHistory("PaymentType", oldCorporatePolicyQuote.PaymentType.ToString(), this.PaymentType.ToString(), mode);
                    history.BuildNotesForHistory("IsMaster", oldCorporatePolicyQuote.IsMaster.ToString(), this.IsMaster.ToString(), mode);
                    history.BuildNotesForHistory("TCIDApplicationAuto", oldCorporatePolicyQuote.TCIDApplicationAuto.ToString(), this.TCIDApplicationAuto.ToString(), mode);
                    history.BuildNotesForHistory("TCIDQuote", oldCorporatePolicyQuote.TCIDQuotes.ToString(), this.TCIDQuotes.ToString(), mode);
                    history.BuildNotesForHistory("PrintPolicy", oldCorporatePolicyQuote.PrintPolicy.ToString(), this.PrintPolicy.ToString(), mode);
                   
                    history.BuildNotesForHistory("MasterPolicyID",
                        LookupTables.LookupTables.GetDescription("MasterPolicy", oldCorporatePolicyQuote.MasterPolicyID.ToString()),
                        LookupTables.LookupTables.GetDescription("MasterPolicy", this.MasterPolicyID.ToString()),
                        mode);
                    history.BuildNotesForHistory("Prem_Mes", oldCorporatePolicyQuote.Prem_Mes.ToString(), this.Prem_Mes.ToString(), mode);
                    history.BuildNotesForHistory("PMT1", oldCorporatePolicyQuote.PMT1.ToString(), this.PMT1.ToString(), mode);
                    history.BuildNotesForHistory("PrintDate", oldCorporatePolicyQuote.PrintDate.ToString(), this.PrintDate.ToString(), mode);
                    history.BuildNotesForHistory("OriginatedAt", oldCorporatePolicyQuote.OriginatedAt.ToString(), this.OriginatedAt.ToString(), mode);
                }
                // Terminan Campos Policy


                history.Actions = "EDIT";
            }
            else  //ADD & DELETE
            {
                history.BuildNotesForHistory("TaskControlID.", "", this.TaskControlID.ToString(), mode);
                history.Actions = "ADD";
            }

            history.KeyID = this.TaskControlID.ToString();
            history.Subject = "POLICIES";
            history.UsersID = userID;
            history.GetSaveHistory();
        }


        private object SafeConvertToDateTime(string StringObject)
        {
            if (StringObject != string.Empty)
            {
                try { return DateTime.Parse(StringObject); }
                catch {/*Write to error logging sub-system.*/}
            }
            return StringObject;
        }


        #endregion
    }
}
