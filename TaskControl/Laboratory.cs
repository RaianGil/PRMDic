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
   public class Laboratory : Policy
    {
       public Laboratory()
       { }
        public Laboratory(bool IsPolicy)
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
                this.TaskControlTypeID = int.Parse(LookupTables.LookupTables.GetID("TaskControlType", "LaboratoryPolicy"));
                this.PolicyClassID = 16;
                if (this.InsuranceCompany != "002")
                    this.PolicyType = "CLP";
                else
                    this.PolicyType = "ALP";
                //this.DepartmentID = 2;
            }
            else
            {
                this.TaskControlTypeID = int.Parse(LookupTables.LookupTables.GetID("TaskControlType", "LaboratoryQuotes"));
                InicializeValue();
            }
        }

        #region Variables

        public bool IsPolicy { get; set; }
        //public bool IsEndorsement { get; set; }
        public int UserID { get; set; }
        public string Code { get; set; }
        public string Coverage { get; set; }
        public int SpecialtyID {get; set;}
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
        public int LaboratoryID { get; set; }
        private int _Mode = (int)TaskControlMode.CLEAR;
        public double TotalPremium1 { get; set; }
        public double TotalPremium2 { get; set; }
        public double TotalPremium3 { get; set; }
        public double TotalPremium4 { get; set; }
        public bool limitReduced { get; set; }
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
       

        private DataTable LaboratoryFillproperties = new DataTable();
        #endregion
       

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

        #region Public Methods
        public static Laboratory GetLaboratoryQuotes(int _TaskControlID)
        {
            Laboratory lq = new Laboratory();
            lq.LaboratoryFillproperties = Laboratory.GetLaboratoryQuoteDB(_TaskControlID);
            lq.FillProperties(lq);
            return lq;
        }

        public static Laboratory GetLaboratoryPolicy(int _TaskControlID)
        {
            Laboratory lq = new Laboratory();
            lq = (Laboratory)Policy.GetPolicyByTaskControlID(_TaskControlID, lq);
            lq.LaboratoryFillproperties = Laboratory.GetLaboratoryPolicyDB(_TaskControlID);
            lq.FillProperties(lq);
            return lq;
        }

        public static void DeleteLaboratoryPolicyByTaskControlID(int taskControlID, bool IsPolicy)
        {
            DBRequest Executor = new DBRequest();

            try
            {
                Executor.BeginTrans();
                Executor.Update("DeleteLaboratoryPolicy", DeleteLaboratoryPolicyByTaskControlIDXml(taskControlID, IsPolicy));
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error, Please try again. " + xcp.Message, xcp);
            }
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

        public void SaveLaboratory()
        {
            try
            {
                SaveLaboratory2();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        #endregion

        #region Private Methods
       // Get Endorsement Collection
        private DataTable GetEndorsementCollection()
        {
            DataTable dt = null;
            return dt;
        }

        private void SaveLaboratory2()
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
                    SaveLaboratoryPolicy();
                    base.SavePol(UserID);
                }
                else if (!this.isEndorsement)
                    SaveLaboratoryQuotes();

                this.Mode = 2; //Update
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void DeleteByError()
        {
            XmlDocument xml = null;
            DataTable dt = null;
            try
            {
                DbRequestXmlCookRequestItem[] cooker = new DbRequestXmlCookRequestItem[1];
                DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, this.TaskControlID.ToString(), ref cooker);

                xml = DbRequestXmlCooker.Cook(cooker);

                DBRequest executor = new DBRequest();

                executor.Delete("", xml);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void SaveLaboratoryQuotes()
        {
            try
            {
                DBRequest executor = new DBRequest();
                executor.Insert("AddLaboratoryQuotes", GetXmlLaboratory());
                this._Mode = 2;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void SaveLaboratoryPolicy()
        {
            try
            {
                DBRequest executor = new DBRequest();
                executor.Insert("AddLaboratoryPolicy", GetXmlLaboratory());
                this._Mode = 2;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }

        private static XmlDocument DeleteLaboratoryPolicyByTaskControlIDXml(int taskControlID, bool IsPolicy)
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

        private static DataTable GetLaboratoryPolicyDB(int _TaskControlID)
        {
            XmlDocument xml = null;
            DataTable dt = null;
            try
            {
                DbRequestXmlCookRequestItem[] cooker = new DbRequestXmlCookRequestItem[1];
                DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, _TaskControlID.ToString(), ref cooker);

                xml = DbRequestXmlCooker.Cook(cooker);

                DBRequest executor = new DBRequest();
                dt = executor.GetQuery("GetLaboratoryPolicy", xml);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        private static DataTable GetLaboratoryQuoteDB(int _TaskControlID)
        {
            XmlDocument xml = null;
            DataTable dt = null;
            try
            {
                DbRequestXmlCookRequestItem[] cooker = new DbRequestXmlCookRequestItem[1];
                DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, _TaskControlID.ToString(), ref cooker);

                xml = DbRequestXmlCooker.Cook(cooker);

                DBRequest executor = new DBRequest();
                dt = executor.GetQuery("GetLaboratoryQuotes", xml);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
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


        private XmlDocument GetXmlLaboratory()
        {
            XmlDocument xml = null;
            try
            {
                DBRequest executor = new DBRequest();
                DbRequestXmlCookRequestItem[] cooker = new DbRequestXmlCookRequestItem[39];

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
                DbRequestXmlCooker.AttachCookItem("FinancialDesc",SqlDbType.VarChar, 100, this.FinancialDesc.ToString(), ref cooker);

                DbRequestXmlCooker.AttachCookItem("OtherSpecialtyID", SqlDbType.Int, 0, this.OtherSpecialtyID.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("OtherSpecialtyDesc", SqlDbType.VarChar, 100, this.OtherSpecialtyDesc.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("OtherSpecialty2ID", SqlDbType.Int, 0, this.OtherSpecialty2ID.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("OtherSpecialty2Desc", SqlDbType.VarChar, 100, this.OtherSpecialtyDesc2.ToString(), ref cooker);

                DbRequestXmlCooker.AttachCookItem("TotalPremium1", SqlDbType.Float, 0, this.TotalPremium1.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("TotalPremium2", SqlDbType.Float, 0, this.TotalPremium2.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("TotalPremium3", SqlDbType.Float, 0, this.TotalPremium3.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("TotalPremium4", SqlDbType.Float, 0, this.TotalPremium4.ToString(), ref cooker);

                DbRequestXmlCooker.AttachCookItem("Term", SqlDbType.Int, 0, this.Term.ToString(), ref cooker);

                DbRequestXmlCooker.AttachCookItem("IsLimitReduced", SqlDbType.Bit, 0, this.limitReduced.ToString(), ref cooker);
                //----prueba Gap
                DbRequestXmlCooker.AttachCookItem("GapBegDate", SqlDbType.VarChar, 15, this.GapBegDate.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("GapEndDate", SqlDbType.VarChar, 15, this.GapEndDate.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("GapBegDate2", SqlDbType.VarChar, 15, this.GapBegDate2.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("GapEndDate2", SqlDbType.VarChar, 15, this.GapEndDate2.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("GapBegDate3", SqlDbType.VarChar, 15, this.GapBegDate3.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("GapEndDate3", SqlDbType.VarChar, 15, this.GapEndDate3.ToString(), ref cooker);
                DbRequestXmlCooker.AttachCookItem("NumberOfEmployees", SqlDbType.VarChar, 15, this.NumberOfEmployees.ToString(), ref cooker);

                xml = DbRequestXmlCooker.Cook(cooker);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return xml;
        }
        private void FillProperties(Laboratory lb)
        {
            Laboratory lb2 = lb;
            if (lb2.LaboratoryFillproperties.Rows.Count > 0)
            {
                lb2.LaboratoryID = int.Parse(lb2.LaboratoryFillproperties.Rows[0]["LaboratoryID"].ToString().Trim());
                lb2.TaskControlID = int.Parse(lb2.LaboratoryFillproperties.Rows[0]["TaskControlID"].ToString().Trim());
                lb2.IsPolicy = bool.Parse(lb2.LaboratoryFillproperties.Rows[0]["IsPolicy"].ToString().Trim());
                lb2.isEndorsement = bool.Parse(lb2.LaboratoryFillproperties.Rows[0]["IsEndorsement"].ToString().Trim());
                lb2.SpecialtyID = int.Parse(lb2.LaboratoryFillproperties.Rows[0]["SpecialtyID"].ToString().Trim());
                lb2.SpecialtyDesc = lb2.LaboratoryFillproperties.Rows[0]["SpecialtyDesc"].ToString().Trim();
                lb2.Code = lb2.LaboratoryFillproperties.Rows[0]["Code"].ToString().Trim();
                lb2.Coverage = lb2.LaboratoryFillproperties.Rows[0]["Coverage"].ToString().Trim();
                lb2.RetroDate = lb2.LaboratoryFillproperties.Rows[0]["RetroDate"].ToString().Trim();
                lb2.EffectiveDate = lb2.LaboratoryFillproperties.Rows[0]["EffectiveDate"].ToString().Trim();
                lb2.ExpirationDate = lb2.LaboratoryFillproperties.Rows[0]["ExpirationDate"].ToString().Trim();
                lb2.FinancialID = int.Parse(lb2.LaboratoryFillproperties.Rows[0]["FinancialID"].ToString().Trim());
                lb2.FinancialDesc = lb2.LaboratoryFillproperties.Rows[0]["FinancialDesc"].ToString().Trim();
                lb2.OtherSpecialtyID = int.Parse(lb2.LaboratoryFillproperties.Rows[0]["OtherSpecialtyID"].ToString().Trim());
                lb2.OtherSpecialtyDesc = lb2.LaboratoryFillproperties.Rows[0]["OtherSpecialtyDesc"].ToString().Trim();
                lb2.OtherSpecialty2ID = int.Parse(lb2.LaboratoryFillproperties.Rows[0]["OtherSpecialty2ID"].ToString().Trim());
                lb2.OtherSpecialtyDesc2 = lb2.LaboratoryFillproperties.Rows[0]["OtherSpecialtyDesc2"].ToString().Trim();
                lb2.ProfessionalLiabilityCoverage = lb2.LaboratoryFillproperties.Rows[0]["ProfessionalLiabilityCoverage"].ToString().Trim();
                lb2.EstimatedGrossReceipts = double.Parse(lb2.LaboratoryFillproperties.Rows[0]["EstimatedGrossReceipts"].ToString().Trim());
                lb2.LimitsID = int.Parse(lb2.LaboratoryFillproperties.Rows[0]["LimitsID"].ToString().Trim());
                lb2.LimitsDesc = lb2.LaboratoryFillproperties.Rows[0]["LimitsDesc"].ToString().Trim();
                lb2.Factor = double.Parse(lb2.LaboratoryFillproperties.Rows[0]["Factor"].ToString().Trim());
                lb2.Charge = double.Parse(lb2.LaboratoryFillproperties.Rows[0]["Charge"].ToString().Trim());
                lb2.Premium = double.Parse(lb2.LaboratoryFillproperties.Rows[0]["Premium"].ToString().Trim());
                lb2.TotalPremium = double.Parse(lb2.LaboratoryFillproperties.Rows[0]["TotalPremium"].ToString().Trim());
                lb2.Comment = lb2.LaboratoryFillproperties.Rows[0]["Comment"].ToString().Trim();
                lb2.Term = int.Parse(lb2.LaboratoryFillproperties.Rows[0]["Term"].ToString().Trim());
                lb2.TotalPremium1 = double.Parse(lb2.LaboratoryFillproperties.Rows[0]["TotalPremium1"].ToString().Trim());
                lb2.TotalPremium2 = double.Parse(lb2.LaboratoryFillproperties.Rows[0]["TotalPremium2"].ToString().Trim());
                lb2.TotalPremium3 = double.Parse(lb2.LaboratoryFillproperties.Rows[0]["TotalPremium3"].ToString().Trim());
                lb2.TotalPremium4 = double.Parse(lb2.LaboratoryFillproperties.Rows[0]["TotalPremium4"].ToString().Trim());
                lb2.limitReduced = bool.Parse(lb2.LaboratoryFillproperties.Rows[0]["IsLimitReduced"].ToString().Trim());
                //--------prueba Gap
                lb2.GapBegDate = lb2.LaboratoryFillproperties.Rows[0]["GapBegDate"].ToString().Trim();
                lb2.GapEndDate = lb2.LaboratoryFillproperties.Rows[0]["GapEndDate"].ToString().Trim();
                lb2.GapBegDate2 = lb2.LaboratoryFillproperties.Rows[0]["GapBegDate2"].ToString().Trim();
                lb2.GapEndDate2 = lb2.LaboratoryFillproperties.Rows[0]["GapEndDate2"].ToString().Trim();
                lb2.GapBegDate3 = lb2.LaboratoryFillproperties.Rows[0]["GapBegDate3"].ToString().Trim();
                lb2.GapEndDate3 = lb2.LaboratoryFillproperties.Rows[0]["GapEndDate3"].ToString().Trim();
                lb2.NumberOfEmployees = lb2.LaboratoryFillproperties.Rows[0]["NumberOfEmployees"].ToString().Trim();
                this._Mode = 2;
            }
            lb = lb2;
        }

        private void InicializeValue()
        {
            this.LaboratoryID = 0;
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
            this.PolicyClassID = 16;
            this.Code = "80715";
            this.Coverage = "Claims Made";
            this.TotalPremium1 = 0;
            this.TotalPremium2 = 0;
            this.TotalPremium3 = 0;
            this.TotalPremium4 = 0;
            this.limitReduced = false;
            this._Mode = 1;
            //-----variables Gap
            this.GapBegDate = "";
            this.GapEndDate = "";
            this.GapBegDate2 = "";
            this.GapEndDate2 = "";
            this.GapBegDate3 = "";
            this.GapEndDate3 = "";
            this.NumberOfEmployees = "";
        }
        #endregion
    }
}
