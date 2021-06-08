using System;
using System.Data;
using Baldrich.DBRequest;
using System.Xml;
using EPolicy.XmlCooker;

namespace EPolicy.TaskControl
{
    public class AdditionalCoverageLiability
    {
        public AdditionalCoverageLiability()
        {

        }

        #region Variables

        private DataTable _AdditionalCoverageLiability;
        private PolicyDetailcs oldAdditionalCoverageLiability = null;
        private DataTable _AdditionalCoverageLiabilityTableTemp = null;
        private int _AdditionalCoverageLiabilityID = 0;
        private int _AditionalCoverage2ID = 0;
        private int _TaskControlID = 0;
        private int _PersonalLiabilityID = 0;
        private string _AdditionalCoverageLiabilityDesc = "";
        private double _Premium = 0.00;
        private int _Mode = (int)AdditionalCoverageLiabilityMode.CLEAR;

        #endregion

        #region Public Enumeration

        public enum AdditionalCoverageLiabilityMode { ADD = 1, UPDATE = 2, DELETE = 3, CLEAR = 4 };

        #endregion

        #region Properties

        public DataTable AdditionalCoverageLiabilityTableTemp
        {
            get
            {
                return (this._AdditionalCoverageLiabilityTableTemp);
            }
            set
            {
                this._AdditionalCoverageLiabilityTableTemp = value;
            }
        }

        public int Mode
        {
            get
            {
                return this._Mode;
            }
            set
            {
                this._Mode = value;
            }
        }

        public int AdditionalCoverageLiabilityID
        {
            get
            {
                return this._AdditionalCoverageLiabilityID;
            }
            set
            {
                this._AdditionalCoverageLiabilityID = value;
            }
        }
        public int AditionalCoverage2ID
        {
            get
            {
                return this._AditionalCoverage2ID;
            }
            set
            {
                this._AditionalCoverage2ID = value;
            }
        }

        public int TaskControlID
        {
            get
            {
                return this._TaskControlID;
            }
            set
            {
                this._TaskControlID = value;
            }
        }

        public int PersonalLiabilityID
        {
            get
            {
                return this._PersonalLiabilityID;
            }
            set
            {
                this._PersonalLiabilityID = value;
            }
        }

        private string AdditionalCoverageLiabilityDesc
        {
            get
            {
                return this._AdditionalCoverageLiabilityDesc;
            }
            set
            {
                this._AdditionalCoverageLiabilityDesc = value;
            }
        }

        private double Premium
        {
            get
            {
                return this._Premium;
            }
            set
            {
                this._Premium = value;
            }
        }

        #endregion

        #region Public Methods

        public static DataTable GetAdditionalCoverageLiabilityTableTempLoaded(int personalLiabilityID, bool IsOppQuote)
        {
            DataTable dt = GetAdditionalCoverageLiabilityByPersonalLiabilityIDDB(personalLiabilityID, IsOppQuote);
            return dt;
        }

        public void SaveAdditionalCoverageLiability(int UserID, int personalLiabilityID, int taskControlID, bool IsOppQuote)
        {
            DataTable dt = this.AdditionalCoverageLiabilityTableTemp;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.PersonalLiabilityID = personalLiabilityID;
                this.TaskControlID = taskControlID;
                this.AditionalCoverage2ID = (int)this.AdditionalCoverageLiabilityTableTemp.Rows[i]["AdditionalCoverage2ID"];
                this.AdditionalCoverageLiabilityDesc = this.AdditionalCoverageLiabilityTableTemp.Rows[i]["AdditionalCoverageLiabilityDesc"].ToString();
                this.Premium = double.Parse(this.AdditionalCoverageLiabilityTableTemp.Rows[i]["Premium"].ToString());

                this.Mode = 1; //Add
                this.Save(UserID, IsOppQuote);
            }
        }

        public void DeleteAdditionalCoverageLiabilityByTaskControlID(int taskControlID, bool IsOppQuote)
        {
            Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();

            Executor.BeginTrans();
            Executor.Delete("DeleteAdditionalCoverageLiabilityByTaskControlID", DeleteAdditionalCoverageLiabilityByTaskControlIDXml(taskControlID, IsOppQuote));
            Executor.CommitTrans();
        }

        #endregion

        #region Private Methods
        private void Save(int UserID, bool IsOppQuote)
        {
            //if (this.Mode ==2) //Para el History
            //	oldF1500Detailcs = (F1500Detailcs) GetF1500DetailByF1500DetailID(this.F1500DetailID);

            Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
            try
            {
                Executor.BeginTrans();
                switch (this.Mode)
                {
                    case 1:  //ADD
                        this.AdditionalCoverageLiabilityID = Executor.Insert("AddAdditionalCoverageLiability", this.GetInsertAdditionalCoverageLiabilityXml(IsOppQuote));
                        break;
                }
                Executor.CommitTrans();

                if (this.Mode == 1)  //ADD
                {
                    this.History(this.Mode, UserID);
                }
            }

            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error please try again. " + xcp.Message, xcp);
            }

            this.Mode = 4;
        }

        private XmlDocument DeleteAdditionalCoverageLiabilityByTaskControlIDXml(int taskControlID, bool IsOppQuote)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, taskControlID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("IsOppQuote",
                SqlDbType.Bit, 0, IsOppQuote.ToString(),
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

        private static DataTable GetAdditionalCoverageLiabilityByPersonalLiabilityIDDB(int personalLiabilityID, bool IsOppQuote)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("PersonalLiabilityID",
                SqlDbType.Int, 0, personalLiabilityID.ToString(),
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
            DataTable dt = null;
            try
            {
                dt = exec.GetQuery("GetAdditionalCoverageLiabilityByPersonalLiabilityID", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Can not found the record in the Databases.", ex);
            }
        }

        private XmlDocument GetInsertAdditionalCoverageLiabilityXml(bool IsOppQuote)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[6];

            DbRequestXmlCooker.AttachCookItem("AditionalCoverage2ID",
                SqlDbType.Int, 0, this.AditionalCoverage2ID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, this.TaskControlID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PersonalLiabilityID",
                SqlDbType.Int, 0, this.PersonalLiabilityID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("AdditionalCoverageLiabilityDesc",
                SqlDbType.VarChar, 100, this.AdditionalCoverageLiabilityDesc.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Premium",
                SqlDbType.Float, 0, this.Premium.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("IsOppQuote",
                SqlDbType.Bit, 0, IsOppQuote.ToString(),
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

        private void History(int mode, int userID)
        {
            //Audit.History history = new Audit.History();

            //if (mode == 2)
            //{
            //    history.BuildNotesForHistory("PolicyDetailsID", oldPolicyDetailcs.PolicyDetailsID.ToString(), this.PolicyDetailsID.ToString(), mode);
            //    history.BuildNotesForHistory("TaskControlID", oldPolicyDetailcs.TaskControlID.ToString(), this.TaskControlID.ToString(), mode);
            //    history.BuildNotesForHistory("Year", oldPolicyDetailcs.YearID.ToString(), this.YearID.ToString(), mode);
            //    history.BuildNotesForHistory("CoversID", oldPolicyDetailcs.CoversID.ToString(), this.CoversID.ToString(), mode);
            //    history.BuildNotesForHistory("LimitID", oldPolicyDetailcs.LimitsID.ToString(), this.LimitsID.ToString(), mode);
            //    history.BuildNotesForHistory("Premium", oldPolicyDetailcs.Premium.ToString(), this.Premium.ToString(), mode);

            //    history.Actions = "MODIFICAR";
            //}
            //else  //ADD & DELETE
            //{
            //    history.BuildNotesForHistory("TASKCONTROLID", "", this.TaskControlID.ToString(), mode);
            //    history.Actions = "A�ADIR";
            //}

            //history.KeyID = this.TaskControlID.ToString();
            //history.Subject = "POLICIES";
            //history.UsersID = userID;
            //history.GetSaveHistory();
        }

        #endregion

    }
}
