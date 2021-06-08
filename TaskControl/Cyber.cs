using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
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
    public class Cyber : Policy
    {
        public Cyber()
       { }

        public Cyber(bool IsPolicy)
        {
            this.AgentList = Policy.GetAgentListByPolicyClassID(0);
            this.IsPolicy = IsPolicy;
            this.InsuranceCompany = "000";
            this.Agency = "000";
            this.Agent = "000";
            this.Bank = "000";
            this.Dealer = "000";
            this.CompanyDealer = "000";
            this.TaskStatusID = int.Parse(LookupTables.LookupTables.GetID("TaskStatus", "Open"));

            if (this.IsPolicy)
            {
                this.TaskControlTypeID = int.Parse(LookupTables.LookupTables.GetID("TaskControlType", "CyberPolicy"));
                this.PolicyClassID = 19;
                //this.PolicyType = "ICP";
                //this.DepartmentID = 2;
            }
            else
            {
               
                this.TaskControlTypeID = int.Parse(LookupTables.LookupTables.GetID("TaskControlType", "CyberQuotes"));
                InitializeValue();
            }
        }

        #region Variables

        public bool IsPolicy { get; set; }
        //public bool IsEndorsement { get; set; }
        public int UserID { get; set; }
        public string Code { get; set; }
        public string Coverage { get; set; }
        public int SpecialtyID { get; set; }
        public string SpecialtyDesc { get; set; }
        public int LimitsID { get; set; }
        public string LimitsDesc { get; set; }
        public double EstimatedGrossReceipts { get; set; }
        public string RetroDate { get; set; }
        public int _FinancialID { get; set; }
        public string FinancialDesc { get; set; }
        public int _OtherSpecialtyID { get; set; }
        public int OtherSpecialty2ID { get; set; }
        public string OtherSpecialtyDesc { get; set; }
        public string OtherSpecialtyDesc2 { get; set; }
        public string ProfessionalLiabilityCoverage { get; set; }
        public double Factor { get; set; }
        public double Charger { get; set; }
        public double Premium { get; set; }
        public double _TotalPremium { get; set; }
        public string Comment { get; set; }
        public int CyberID { get; set; }
        private int _Mode = (int)TaskControlMode.CLEAR;
        public double TotalPremium1 { get; set; }
        public double TotalPremium2 { get; set; }
        public double TotalPremium3 { get; set; }
        public double TotalPremium4 { get; set; }
        public bool limitReduced { get; set; }
        public int EnityID { get; set; }
        public string EnityDesc { get; set; }
        public string otherEnity { get; set; }
        public int practiceHistoryID { get; set; }
        public string practiceHistoryDesc { get; set; }
        public string numberPatients { get; set; }
        public int numberPhysiciansID { get; set; }
        public string numberPhysiciansDesc { get; set; }
        public bool privacyOfficer { get; set; }
        public bool privacyPractice { get; set; }
        public bool awerenessTrain { get; set; }
        public bool techPerson { get; set; }
        public bool privacyBreach { get; set; }
        public bool gmail { get; set; }
        //public bool paperRec { get; set; }
        public bool lockedCab { get; set; }
        public bool paperRetention { get; set; }
        public bool shredDoc { get; set; }
        public bool itNetworkEncrypted { get; set; }
        public bool itNetworkAccesible { get; set; }
        public bool elecRecOnline { get; set; }
        public bool elecRecWeb { get; set; }
        public int totalDebit { get; set; }
        public int totalCredit { get; set; }
        public int totalCreditDebit { get; set; }
        public string GapBegDate { get; set; }
        public string GapEndDate { get; set; }
        public string GapBegDate2 { get; set; }
        public string GapEndDate2 { get; set; }
        public string GapBegDate3 { get; set; }
        public string GapEndDate3 { get; set; }
        public string NumberOfEmployees { get; set; }


        private bool _isEndorsement = false;
        private DataTable _EndorsementCollection = null;
        private DataTable _Endorsement;


        private DataTable CyberFillproperties = new DataTable();
        #endregion

        private void InitializeValue()
        {
            this.CyberID = 0;
            this.TaskControlID = 0;
            this.InsuranceCompany = "001";
            this.IsPolicy = false;
            this.isEndorsement = false;
            this.SpecialtyID = 0;
            this.SpecialtyDesc = "";
            this.Code = "";
            this.Coverage = "";
            this.RetroDate = "";
            this.EffectiveDate = DateTime.Now.ToShortDateString();
            this.ExpirationDate = DateTime.Now.AddYears(1).ToShortDateString();
            this.Term = 12;
            this.FinancialID = 0;
            this.FinancialDesc = "";
            this.OtherSpecialtyID = 0;
            this.OtherSpecialtyDesc = "";
            this.OtherSpecialty2ID = 0;
            this.OtherSpecialtyDesc2 = "";
            this.ProfessionalLiabilityCoverage = "";
            this.EstimatedGrossReceipts = 0;
            this.LimitsID = 0;
            this.LimitsDesc = "";
            this.Factor = 0;
            this.Charge = 0;
            this.Premium = 0;
            this.TotalPremium = 0;
            this.Comment = "";
            this.EntryDate = DateTime.Now;
            this.AutoAssignPolicy = false;
            this.Mode = 1;
            this.PolicyClassID = 18;
            this.Code = "80715";
            this.Coverage = "Claims Made";
            this.TotalPremium1 = 0;
            this.TotalPremium2 = 0;
            this.TotalPremium3 = 0;
            this.TotalPremium4 = 0;
            this.limitReduced = false;
            this.EnityID = 0;
            this.EnityDesc = "";
            this.otherEnity = "";
            this.practiceHistoryID = 0;
            this.practiceHistoryDesc = "";
            this.numberPatients = "";
            this.numberPhysiciansID = 0;
            this.numberPhysiciansDesc = "";
            this._Mode = 1;
            this.privacyOfficer = false;
            this.privacyPractice = false;
            this.awerenessTrain = false;
            this.techPerson = false;
            this.privacyBreach = false;
            this.gmail = false;
            //this.paperRec = false;
            this.lockedCab = false;
            this.paperRetention = false;
            this.shredDoc = false;
            this.itNetworkEncrypted =false;
            this.itNetworkAccesible = false;
            this.elecRecOnline = false;
            this.elecRecWeb = false;
            this.totalCredit = 0;
            this.totalDebit = 0;
            this.totalCreditDebit = 0;
            //-----variables Gap
            this.GapBegDate = "";
            this.GapEndDate = "";
            this.GapBegDate2 = "";
            this.GapEndDate2 = "";
            this.GapBegDate3 = "";
            this.GapEndDate3 = "";
            this.NumberOfEmployees = "";
        }

        #region Properties

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


        #endregion

        public static Cyber GetCyberQuotes(int _TaskControlID)
        {
            Cyber cq = new Cyber();
            cq.CyberFillproperties = Cyber.GetCyberQuoteDB(_TaskControlID);
            cq.FillProperties(cq);
            return cq;
        }

        public static Cyber GetCyberPolicy(int _TaskControlID)
        {
            Cyber cq = new Cyber();
            cq = (Cyber)Policy.GetPolicyByTaskControlID(_TaskControlID, cq);
            cq.CyberFillproperties = Cyber.GetCyberPolicyDB(_TaskControlID);
            cq.FillProperties(cq);
            return cq;
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

        private void SaveCyberQuotes()
        {
            try
            {
                DBRequest executor = new DBRequest();
                executor.Insert("AddCyberQuotes", GetXmlCyber());
                this._Mode = 2;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void SaveCyberPolicy()
        {
            try
            {
                DBRequest executor = new DBRequest();
                executor.Insert("AddCyberPolicy", GetXmlCyber());
                this._Mode = 2;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void SaveCyber()
        {
            try
            {
                SaveCyber2();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void SaveCyber2()
        {
            try
            {
                this._Mode = (int)this.Mode;  // Se le asigna el mode de taskControl.
                this.PolicyMode = (int)this.Mode;  // Se le asigna el mode de taskControl.

                if (this.Customer.CustomerNo.Trim() == "")
                    this.Customer.Mode = 1;
                else
                    this.Customer.Mode = 2;

                this.Customer.Save(UserID);

                this.CustomerNo = Customer.CustomerNo;
                //this.ProspectID = Prospect.ProspectID;

                base.Save();

                // base.SavePol(UserID); // Save in policy

                if (this.IsPolicy)
                {
                    SaveCyberPolicy();
                    base.SavePol(UserID);
                }
                else if (!this.isEndorsement)
                    SaveCyberQuotes();

                this.Mode = 2; //Update
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static XmlDocument DeleteCyberPolicyByTaskControlIDXml(int taskControlID, bool IsPolicy)
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

        public static void DeleteCyberPolicyByTaskControlID(int taskControlID, bool IsPolicy)
        {
            DBRequest Executor = new DBRequest();

            try
            {
                Executor.BeginTrans();
                Executor.Update("DeleteCyberPolicy", DeleteCyberPolicyByTaskControlIDXml(taskControlID, IsPolicy));
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error, Please try again. " + xcp.Message, xcp);
            }
        }
        private static DataTable GetCyberPolicyDB(int _TaskControlID)
        {
            XmlDocument xml = null;
            DataTable dt = null;
            try
            {
                DbRequestXmlCookRequestItem[] cooker = new DbRequestXmlCookRequestItem[1];
                DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, _TaskControlID.ToString(), ref cooker);

                xml = DbRequestXmlCooker.Cook(cooker);

                DBRequest executor = new DBRequest();
                dt = executor.GetQuery("GetCyberPolicy", xml);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        private static DataTable GetCyberQuoteDB(int _TaskControlID)
        {
            XmlDocument xml = null;
            DataTable dt = null;
            try
            {
                DbRequestXmlCookRequestItem[] cooker = new DbRequestXmlCookRequestItem[1];
                DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, _TaskControlID.ToString(), ref cooker);

                xml = DbRequestXmlCooker.Cook(cooker);

                DBRequest executor = new DBRequest();
                dt = executor.GetQuery("GetCyberQuotes", xml);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

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

       

        private XmlDocument GetXmlCyber()
        {
            XmlDocument xml = null;
            try
            {
                DBRequest executor = new DBRequest();
                DbRequestXmlCookRequestItem[] cooker = new DbRequestXmlCookRequestItem[61];

                DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, this.TaskControlID.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("IsPolicy", SqlDbType.Bit, 0, this.IsPolicy.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("IsEndorsement", SqlDbType.Bit, 0, this.isEndorsement.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("SpecialtyID", SqlDbType.Int, 0, this.SpecialtyID.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("SpecialtyDesc", SqlDbType.VarChar, 100, this.SpecialtyDesc.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("Code", SqlDbType.VarChar, 10, this.Code.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("Coverage", SqlDbType.VarChar, 25, this.Coverage.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("RetroDate", SqlDbType.VarChar, 25, this.RetroDate.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("EffectiveDate", SqlDbType.VarChar, 25, this.EffectiveDate.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("ExpirationDate", SqlDbType.VarChar, 25, this.ExpirationDate.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("ProfessionalLiabilityCoverage", SqlDbType.VarChar, 100, this.ProfessionalLiabilityCoverage.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("EstimatedGrossReceipts", SqlDbType.Float, 0, this.EstimatedGrossReceipts.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("LimitsID", SqlDbType.Int, 0, this.LimitsID.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("LimitDesc", SqlDbType.VarChar, 100, this.LimitsDesc.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("Factor", SqlDbType.Float, 0, this.Factor.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("Charge", SqlDbType.Float, 0, this.Charge.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("Premium", SqlDbType.Float, 0, this.Premium.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("TotalPremium", SqlDbType.Float, 0, this.TotalPremium.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("Comment", SqlDbType.VarChar, 1000, this.Comment.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("Mode", SqlDbType.Int, 0, this._Mode.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("FinancialID", SqlDbType.Int, 0, this.FinancialID.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("FinancialDesc", SqlDbType.VarChar, 100, this.FinancialDesc.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("OtherSpecialtyID", SqlDbType.Int, 0, this.OtherSpecialtyID.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("OtherSpecialtyDesc", SqlDbType.VarChar, 100, this.OtherSpecialtyDesc.ToString(), ref cooker);
                //DbRequestXmlCooker.AttachCookItem("OtherSpecialty2ID", SqlDbType.Int, 0, this.OtherSpecialty2ID.ToString(), ref cooker);
                //DbRequestXmlCooker.AttachCookItem("OtherSpecialty2Desc", SqlDbType.VarChar, 100, this.OtherSpecialtyDesc2.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("TotalPremium1", SqlDbType.Float, 0, this.TotalPremium1.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("TotalPremium2", SqlDbType.Float, 0, this.TotalPremium2.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("TotalPremium3", SqlDbType.Float, 0, this.TotalPremium3.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("TotalPremium4", SqlDbType.Float, 0, this.TotalPremium4.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("Term", SqlDbType.Int, 0, this.Term.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("IsLimitReduced", SqlDbType.Bit, 0, this.limitReduced.ToString(), ref cooker);

                DbRequestXmlCooker.AttachCookItem("EnityID", SqlDbType.Int, 0, this.EnityID.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("EnityDesc", SqlDbType.VarChar, 100, this.EnityDesc.ToString().Trim(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("OtherEnity", SqlDbType.VarChar, 50, this.otherEnity.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("PracticeHistoryID", SqlDbType.Int, 0, this.practiceHistoryID.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("PracticeHistoryDesc", SqlDbType.VarChar, 100, this.practiceHistoryDesc.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("NumberOfPatients", SqlDbType.VarChar, 50, this.numberPatients.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("NumberOfPhysiciansID", SqlDbType.Int, 0, this.numberPhysiciansID.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("NumberOfPhysiciansDesc", SqlDbType.VarChar, 50, this.numberPhysiciansDesc.ToString(), ref cooker);

                DbRequestXmlCooker.AttachCookItem("PrivacyOfficer", SqlDbType.Bit, 0, this.privacyOfficer.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("PrivacyPractice", SqlDbType.Bit, 0, this.privacyPractice.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("PrivacyRiskAwerTraining", SqlDbType.Bit, 0, this.privacyBreach.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("TechPersonManager", SqlDbType.Bit, 0, this.techPerson.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("SecurityBreach", SqlDbType.Bit, 0, this.privacyBreach.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("WebBasedEmail", SqlDbType.Bit, 0, this.gmail.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("LockedCabRoom", SqlDbType.Bit, 0, this.lockedCab.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("PaperRetentionPol", SqlDbType.Bit, 0, this.paperRetention.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("DestroyDocuments", SqlDbType.Bit, 0, this.shredDoc.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("NetworkEncrypted", SqlDbType.Bit, 0, this.itNetworkEncrypted.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("NetworkAccesible", SqlDbType.Bit, 0, this.itNetworkAccesible.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("CloudRecord", SqlDbType.Bit, 0, this.elecRecOnline.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("WebBasedStandAlone", SqlDbType.Bit, 0, this.elecRecWeb.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("TotalDebit", SqlDbType.Int, 0, this.totalDebit.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("TotalCredit", SqlDbType.Int, 0, this.totalCredit.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("TotalCreditDebit", SqlDbType.Int, 0, this.totalCreditDebit.ToString(), ref cooker);
                //----prueba Gap
                DbRequestXmlCooker.AttachCookItem("GapBegDate", SqlDbType.VarChar, 15, this.GapBegDate.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("GapEndDate", SqlDbType.VarChar, 15, this.GapEndDate.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("GapBegDate2", SqlDbType.VarChar, 15, this.GapBegDate2.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("GapEndDate2", SqlDbType.VarChar, 15, this.GapEndDate2.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("GapBegDate3", SqlDbType.VarChar, 15, this.GapBegDate3.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("GapEndDate3", SqlDbType.VarChar, 15, this.GapEndDate3.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("NumberOfEmployees", SqlDbType.VarChar, 10, this.NumberOfEmployees.ToString(), ref cooker);
                

                xml = DbRequestXmlCooker.Cook(cooker);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return xml;
        }

        private void FillProperties(Cyber cb)
        {
            Cyber cb2 = cb;
            if (cb2.CyberFillproperties.Rows.Count > 0)
            {
                cb2.CyberID = int.Parse(cb2.CyberFillproperties.Rows[0]["CyberID"].ToString().Trim());
                cb2.TaskControlID = int.Parse(cb2.CyberFillproperties.Rows[0]["TaskControlID"].ToString().Trim());
                
                cb2.IsPolicy = bool.Parse(cb2.CyberFillproperties.Rows[0]["IsPolicy"].ToString().Trim());
                cb2.isEndorsement = bool.Parse(cb2.CyberFillproperties.Rows[0]["IsEndorsement"].ToString().Trim());
                cb2.SpecialtyID = int.Parse(cb2.CyberFillproperties.Rows[0]["SpecialtyID"].ToString().Trim());
                cb2.SpecialtyDesc = cb2.CyberFillproperties.Rows[0]["SpecialtyDesc"].ToString().Trim();
                cb2.Code = cb2.CyberFillproperties.Rows[0]["Code"].ToString().Trim();
                cb2.Coverage = cb2.CyberFillproperties.Rows[0]["Coverage"].ToString().Trim();
                cb2.RetroDate = cb2.CyberFillproperties.Rows[0]["RetroDate"].ToString().Trim();
                cb2.EffectiveDate = cb2.CyberFillproperties.Rows[0]["EffectiveDate"].ToString().Trim();
                cb2.ExpirationDate = cb2.CyberFillproperties.Rows[0]["ExpirationDate"].ToString().Trim();
                cb2.FinancialID = int.Parse(cb2.CyberFillproperties.Rows[0]["FinancialID"].ToString().Trim());
                cb2.FinancialDesc = cb2.CyberFillproperties.Rows[0]["FinancialDesc"].ToString().Trim();
                cb2.OtherSpecialtyID = int.Parse(cb2.CyberFillproperties.Rows[0]["OtherSpecialtyID"].ToString().Trim());
                cb2.OtherSpecialtyDesc = cb2.CyberFillproperties.Rows[0]["OtherSpecialtyDesc"].ToString().Trim();
                //cb2.OtherSpecialty2ID = int.Parse(cb2.CyberFillproperties.Rows[0]["OtherSpecialty2ID"].ToString().Trim());
                //cb2.OtherSpecialtyDesc2 = cb2.CyberFillproperties.Rows[0]["OtherSpecialtyDesc2"].ToString().Trim();
                cb2.ProfessionalLiabilityCoverage = cb2.CyberFillproperties.Rows[0]["ProfessionalLiabilityCoverage"].ToString().Trim();
                cb2.EstimatedGrossReceipts = double.Parse(cb2.CyberFillproperties.Rows[0]["EstimatedGrossReceipts"].ToString().Trim());
                cb2.LimitsID = int.Parse(cb2.CyberFillproperties.Rows[0]["LimitsID"].ToString().Trim());
                cb2.LimitsDesc = cb2.CyberFillproperties.Rows[0]["LimitsDesc"].ToString().Trim();
                cb2.Factor = double.Parse(cb2.CyberFillproperties.Rows[0]["Factor"].ToString().Trim());
                cb2.Charge = double.Parse(cb2.CyberFillproperties.Rows[0]["Charge"].ToString().Trim());
                cb2.Premium = double.Parse(cb2.CyberFillproperties.Rows[0]["Premium"].ToString().Trim());
                cb2.TotalPremium = double.Parse(cb2.CyberFillproperties.Rows[0]["TotalPremium"].ToString().Trim());
                cb2.Comment = cb2.CyberFillproperties.Rows[0]["Comment"].ToString().Trim();
                cb2.Term = int.Parse(cb2.CyberFillproperties.Rows[0]["Term"].ToString().Trim());
                cb2.TotalPremium1 = double.Parse(cb2.CyberFillproperties.Rows[0]["TotalPremium1"].ToString().Trim());
                cb2.TotalPremium2 = double.Parse(cb2.CyberFillproperties.Rows[0]["TotalPremium2"].ToString().Trim());
                cb2.TotalPremium3 = double.Parse(cb2.CyberFillproperties.Rows[0]["TotalPremium3"].ToString().Trim());
                cb2.TotalPremium4 = double.Parse(cb2.CyberFillproperties.Rows[0]["TotalPremium4"].ToString().Trim());
                cb2.limitReduced = bool.Parse(cb2.CyberFillproperties.Rows[0]["IsLimitReduced"].ToString().Trim());
                cb2.EnityID = int.Parse(cb2.CyberFillproperties.Rows[0]["EnityID"].ToString().Trim());
                cb2.EnityDesc = cb2.CyberFillproperties.Rows[0]["EnityDesc"].ToString().Trim();
                cb2.otherEnity = cb2.CyberFillproperties.Rows[0]["OtherEnity"].ToString().Trim();
                cb2.practiceHistoryDesc = cb2.CyberFillproperties.Rows[0]["PracticeHistoryDesc"].ToString().Trim();
                cb2.practiceHistoryID = int.Parse(cb2.CyberFillproperties.Rows[0]["PracticeHistoryID"].ToString().Trim());
                cb2.numberPatients = cb2.CyberFillproperties.Rows[0]["NumberOfPatients"].ToString().Trim();
                cb2.numberPhysiciansID = int.Parse(cb2.CyberFillproperties.Rows[0]["NumberOfPhysiciansID"].ToString().Trim());
                cb2.numberPhysiciansDesc = cb2.CyberFillproperties.Rows[0]["NumberOfPhysiciansDesc"].ToString().Trim();
                cb2.privacyOfficer = bool.Parse(cb2.CyberFillproperties.Rows[0]["PrivacyOfficer"].ToString().Trim());
                cb2.privacyPractice = bool.Parse(cb2.CyberFillproperties.Rows[0]["PrivacyPractice"].ToString().Trim());
                cb2.awerenessTrain = bool.Parse(cb2.CyberFillproperties.Rows[0]["PrivacyRiskAwerTraining"].ToString().Trim());
                cb2.privacyBreach = bool.Parse(cb2.CyberFillproperties.Rows[0]["SecurityBreach"].ToString().Trim());
                cb2.techPerson = bool.Parse(cb2.CyberFillproperties.Rows[0]["TechPersonManager"].ToString().Trim());
                cb2.gmail = bool.Parse(cb2.CyberFillproperties.Rows[0]["WebBasedEmail"].ToString().Trim());
                cb2.lockedCab = bool.Parse(cb2.CyberFillproperties.Rows[0]["LockedCabRoom"].ToString().Trim());
                cb2.paperRetention = bool.Parse(cb2.CyberFillproperties.Rows[0]["PaperRetentionPol"].ToString().Trim());
                cb2.shredDoc = bool.Parse(cb2.CyberFillproperties.Rows[0]["DestroyDocuments"].ToString().Trim());
                cb2.itNetworkEncrypted = bool.Parse(cb2.CyberFillproperties.Rows[0]["NetworkEncrypted"].ToString().Trim());
                cb2.itNetworkAccesible = bool.Parse(cb2.CyberFillproperties.Rows[0]["NetworkAccesible"].ToString().Trim());
                cb2.elecRecOnline = bool.Parse(cb2.CyberFillproperties.Rows[0]["CloudRecord"].ToString().Trim());
                cb2.elecRecWeb = bool.Parse(cb2.CyberFillproperties.Rows[0]["WebBasedStandAlone"].ToString().Trim());
                cb2.totalDebit = int.Parse(cb2.CyberFillproperties.Rows[0]["TotalDebit"].ToString().Trim()); 
                cb2.totalCredit = int.Parse(cb2.CyberFillproperties.Rows[0]["TotalCredit"].ToString().Trim());
                cb2.totalCreditDebit = int.Parse(cb2.CyberFillproperties.Rows[0]["TotalCreditDebit"].ToString().Trim());
                //--------prueba Gap
                cb2.GapBegDate = cb2.CyberFillproperties.Rows[0]["GapBegDate"].ToString().Trim();
                cb2.GapEndDate = cb2.CyberFillproperties.Rows[0]["GapEndDate"].ToString().Trim();
                cb2.GapBegDate2 = cb2.CyberFillproperties.Rows[0]["GapBegDate2"].ToString().Trim();
                cb2.GapEndDate2 = cb2.CyberFillproperties.Rows[0]["GapEndDate2"].ToString().Trim();
                cb2.GapBegDate3 = cb2.CyberFillproperties.Rows[0]["GapBegDate3"].ToString().Trim();
                cb2.GapEndDate3 = cb2.CyberFillproperties.Rows[0]["GapEndDate3"].ToString().Trim();
                cb2.NumberOfEmployees = cb2.CyberFillproperties.Rows[0]["NumberOfEmployees"].ToString().Trim();

                this._Mode = 2;
            }
            cb = cb2;
        }

        public bool PolicyCanRenewDt(int _TaskControlID, int _Suffix)
        {
            DataTable dt = new DataTable();
            dt = PolicyCanRenew(_TaskControlID);

            if (dt.Rows.Count != 0)
            {
                if (_Suffix < int.Parse(dt.Rows[0]["MaxSuffix"].ToString()))
                {
                    return false;
                }
            }

            return true;
        }

        private DataTable PolicyCanRenew(int _TaskControlID)
        {

            XmlDocument xml = null;
            DataTable dt = null;
            try
            {
                DbRequestXmlCookRequestItem[] cooker = new DbRequestXmlCookRequestItem[1];
                DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, _TaskControlID.ToString(), ref cooker);

                xml = DbRequestXmlCooker.Cook(cooker);

                DBRequest executor = new DBRequest();
                dt = executor.GetQuery("GetPolicyRenewalCheck", xml);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public static void InsertInsuranceHistory(int UserID, int TaskControlID, string InsuranceCarrier, string EffectiveDate, string LimitDesc, string PolicyNo)
        {
            try
            {

                DbRequestXmlCookRequestItem[] cookItems =
                    new DbRequestXmlCookRequestItem[6];


                DbRequestXmlCooker.AttachCookItem("UserID",
                    SqlDbType.Int, 0, UserID.ToString(),
                    ref cookItems);

                DbRequestXmlCooker.AttachCookItem("TaskControlID",
                    SqlDbType.Int, 0, TaskControlID.ToString(),
                    ref cookItems);

                DbRequestXmlCooker.AttachCookItem("InsuranceCarrier",
                   SqlDbType.VarChar,50, InsuranceCarrier.ToString(),
                   ref cookItems);

                DbRequestXmlCooker.AttachCookItem("EffectiveDate",
                    SqlDbType.VarChar, 50, EffectiveDate.ToString(),
                    ref cookItems);

                DbRequestXmlCooker.AttachCookItem("LimitDesc",
                    SqlDbType.VarChar, 50, LimitDesc.ToString(),
                    ref cookItems);

                DbRequestXmlCooker.AttachCookItem("PolicyNo",
                    SqlDbType.VarChar, 50, PolicyNo.ToString(),
                    ref cookItems);




                XmlDocument xmldoc;

                try
                {
                    xmldoc = DbRequestXmlCooker.Cook(cookItems);

                }
                catch (Exception ex)
                {
                    throw new Exception("Could not cook items.", ex);
                }

                Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
                Executor.Insert("AddInsuranceHistory", xmldoc);


            }
            catch (Exception xcp)
            {
                throw new Exception("Could not get the comments.", xcp);
            }
        }

        public static DataTable GetInsuranceHistory(int TaskControlID)
        {
            DataTable dt = new DataTable();
            try
            {
                DbRequestXmlCookRequestItem[] cookItems =
                    new DbRequestXmlCookRequestItem[1];

                DbRequestXmlCooker.AttachCookItem("TaskControlID",
                    SqlDbType.Int, 0, TaskControlID.ToString(),
                    ref cookItems);

                XmlDocument xmldoc;


                try
                {
                    xmldoc = DbRequestXmlCooker.Cook(cookItems);
                }

                catch (Exception ex)
                {
                    throw new Exception("Could not cook items.", ex);
                }
                Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();

                dt = Executor.GetQuery("GetInsuranceHistoryByTaskControlID", xmldoc);


            }

            catch (Exception xcp)
            {
                throw new Exception("Could not get comments.", xcp);
            }
            return dt;
        }

        public static DataTable GetCyberPremium(string doctorsDesc, string LimitDesc, int practiceID)
        {
            DataTable dt = new DataTable();

            try
            {
                DbRequestXmlCookRequestItem[] cookItems =
                    new DbRequestXmlCookRequestItem[3];

                DbRequestXmlCooker.AttachCookItem("DoctorsDesc",
                    SqlDbType.VarChar, 10, doctorsDesc.ToString(),
                    ref cookItems);

                DbRequestXmlCooker.AttachCookItem("LimitDesc",
                    SqlDbType.VarChar, 25, LimitDesc.ToString(),
                    ref cookItems);

                DbRequestXmlCooker.AttachCookItem("PracticeID",
                    SqlDbType.Int, 0, practiceID.ToString(),
                    ref cookItems);

                XmlDocument xmldoc;

                try
                {
                    xmldoc = DbRequestXmlCooker.Cook(cookItems);
                }
                catch (Exception ex)
                {
                    throw new Exception("Could not cook items.", ex); 
                }
                Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();

                dt = Executor.GetQuery("GetCyberPremium", xmldoc);

            }
            catch (Exception xcp)
            {
                throw new Exception("Could not get Premium.", xcp);
            }
            return dt;
        }

        public static DataTable VerifiPolicyNo(string policyNo)
        {
            DataTable dt = new DataTable();
            try
            {
                DbRequestXmlCookRequestItem[] cookItems =
                    new DbRequestXmlCookRequestItem[1];

                DbRequestXmlCooker.AttachCookItem("PolicyNo",
                    SqlDbType.VarChar, 11, policyNo.ToString(),
                    ref cookItems);

                XmlDocument xmlDoc;
                try
                {
                    xmlDoc = DbRequestXmlCooker.Cook(cookItems);

                }
                catch(Exception ex)
                {
                    throw new Exception("Could not get policy number", ex);
                }
                Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();

                dt = Executor.GetQuery("GetPolicyNo", xmlDoc);
            }
            catch(Exception xp)
            {
                throw new Exception("Could not get policy number", xp); 
            }
            return dt;
        }

        public static void UpdateCyberInsuranceHistory(int _liabilityID, int _taskcontrolID, int _userID, string _insuranceCarrier, string _effDate, string _limitDesc, string _policyNo)
        {
            try
            {
                DbRequestXmlCookRequestItem[] cookItems =
                    new DbRequestXmlCookRequestItem[7];

                DbRequestXmlCooker.AttachCookItem("LiabilityID",
                    SqlDbType.Int, 0, _liabilityID.ToString(),
                    ref cookItems);

                DbRequestXmlCooker.AttachCookItem("TaskControlID",
                    SqlDbType.Int, 0, _taskcontrolID.ToString(),
                    ref cookItems);

                DbRequestXmlCooker.AttachCookItem("UserID",
                    SqlDbType.Int, 0, _userID.ToString(),
                    ref cookItems);

                DbRequestXmlCooker.AttachCookItem("InsuranceCarrier",
                    SqlDbType.VarChar, 50, _insuranceCarrier.ToString(),
                    ref cookItems);

                DbRequestXmlCooker.AttachCookItem("EffectiveDate",
                    SqlDbType.VarChar, 50, _effDate.ToString(),
                    ref cookItems);

                DbRequestXmlCooker.AttachCookItem("LimitDesc",
                    SqlDbType.VarChar, 50, _limitDesc.ToString(),
                    ref cookItems);

                DbRequestXmlCooker.AttachCookItem("PolicyNo",
                    SqlDbType.VarChar, 50, _policyNo.ToString(),
                    ref cookItems);


                XmlDocument xmldoc;

                try
                {
                    xmldoc = DbRequestXmlCooker.Cook(cookItems);
                }
                catch (Exception ex)
                {
                    throw new Exception("Could not cook items.", ex);
                }
                Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();

                Executor.BeginTrans();
                Executor.Update("UpdateCyberInsuranceHistory", xmldoc);
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {               
                throw new Exception("Error, Please try again. " + xcp.Message, xcp);
            }
 
        }
    }
}
