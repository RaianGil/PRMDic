using System;
using System.Xml;
using System.Data;
using Baldrich.DBRequest;
using EPolicy.Audit;
using System.Data.SqlClient;
using System.Collections;
using EPolicy.XmlCooker;


namespace EPolicy.LookupTables
{
    /// <summary>
    /// Summary description for Agent.
    /// </summary>
    public class Charge
    {
        public Charge()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Enumerations

        public enum Mode { ADD = 1, UPDATE = 2, DELETE = 3, CLEAR = 4 };

        #endregion

        #region Variables

        //private Agent  oldAgent = null;
        private DataTable _navigationViewModelTable;
        private int _actionMode = (int)Mode.UPDATE;
        private int _chargeID = 0;
        private string _effectiveDate = String.Empty;
        private float _chargePercent = 0.00F;
        private int _policyType = 0;
        private bool _renewalsOnly = false;
 
        #endregion

        #region Properties

        public DataTable NavigationViewModelTable
        {
            get
            {
                return this._navigationViewModelTable;
            }
            set
            {
                this._navigationViewModelTable = value;
            }
        }

        public int ActionMode
        {
            get
            {
                return this._actionMode;
            }
            set
            {
                this._actionMode = value;
            }
        }

        public int ChargeID
        {
            get
            {
                return this._chargeID;
            }
            set
            {
                this._chargeID = value;
            }
        }


        public string EffectiveDate
        {
            get
            {
                return this._effectiveDate;
            }
            set
            {
                this._effectiveDate = value;
            }
        }

        public float ChargePercent
        {
            get
            {
                return this._chargePercent;
            }
            set
            {
                this._chargePercent = value;
            }
        }

        public int PolicyType
        {
            get
            {
                return this._policyType;
            }
            set
            {
                this._policyType = value;
            }
        }

        public bool RenewalsOnly
        {
            get
            {
                return this._renewalsOnly;
            }
            set
            {
                this._renewalsOnly = value;
            }
        }

        #endregion

        #region Public Methods

        private string GetNextChargeID()
        {
            DataTable dt = LookupTables.GetTable("Charge");
            DataRow[] dr = dt.Select("", "chargeID");

            DataTable dt2 = dt.Clone();

            for (int rec = 0; rec <= dr.Length - 1; rec++)
            {
                DataRow myRow = dt2.NewRow();
                myRow["chargeID"] = dr[rec].ItemArray[0].ToString();
                myRow["effectiveDate"] = dr[rec].ItemArray[1].ToString();
                myRow["chargePercent"] = dr[rec].ItemArray[2].ToString();
                myRow["policyType"] = dr[rec].ItemArray[3].ToString();
                myRow["renewalsOnly"] = dr[rec].ItemArray[4].ToString();

                dt2.Rows.Add(myRow);
                dt2.AcceptChanges();
            }

            int ID = 0;

            ID = int.Parse(dt2.Rows[dt2.Rows.Count - 1]["chargeID"].ToString()) + 1;

            return (ID.ToString().PadLeft(3, '0'));
        }
        #endregion

        #region Public Functions

        public void Delete(string ChargeID)
        {
            try
            {
                Baldrich.DBRequest.DBRequest executor = new Baldrich.DBRequest.DBRequest();
                executor.Delete("DeleteChargeID",
                    this.GetDeleteChargeXml(ChargeID));
            }
            catch (Exception ex)
            {
                this.HandleDeleteError(ex);
            }
        }

        public void Save(int UserID)
        {
            this.Validate();
            Baldrich.DBRequest.DBRequest executor = new Baldrich.DBRequest.DBRequest();
            try
            {
                executor.BeginTrans();

                switch (this.ActionMode)
                {
                    case 1: //ADD
                        this.ChargeID = int.Parse(GetNextChargeID().ToString().Trim());
                        executor.Update("AddCharge", this.GetInsertChargeXml());
                        this.History(this._actionMode, UserID);
                        //						this.AuditInsert(UserID);
                        //						this.CommitAudit();
                        break;
                    case 3: //DELETE
                        break;
                    case 4: //CLEAR
                        break;
                    default: //UPDATE
                        this.History(this._actionMode, UserID);
                        //						this.AuditUpdate(UserID);
                        executor.Update("UpdateCharge", this.GetUpdateChargeXml());
                        //						this.CommitAudit();//Commit audit;
                        break;
                }
                executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                executor.RollBackTrans();
                this.HandleSaveError(xcp);
            }
        }

        public Charge GetCharge(string ChargeID)
        {
            try
            {
                DataTable dtCharge = new DataTable();
                Charge charge = new Charge();
                this.ChargeID = int.Parse(ChargeID);

                Baldrich.DBRequest.DBRequest executor = new Baldrich.DBRequest.DBRequest();

                dtCharge = executor.GetQuery("GetChargebyChargeID",
                    this.GetChargebyChargeIDXml());

                this.EffectiveDate =
                    dtCharge.Rows[0]["effectiveDate"].ToString().Trim();

                this.ChargePercent =
                    float.Parse(dtCharge.Rows[0]["chargePercent"].ToString().Trim());

                this.PolicyType =
                    int.Parse(dtCharge.Rows[0]["policyType"].ToString().Trim());

                this.RenewalsOnly =
                    bool.Parse(dtCharge.Rows[0]["renewalsOnly"].ToString().Trim());

                return this;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Could not retrieve information for this Charge.", ex);
            }
        }

        #endregion

        #region Private Functions

        private void HandleSaveError(Exception Ex)
        {
            switch (Ex.GetBaseException().GetType().FullName)
            {
                case "System.Data.SqlClient.SqlException":
                    SqlException sqlException = (SqlException)Ex.GetBaseException();
                    switch (sqlException.Number)
                    {
                        case 547:
                            throw new Exception("The Charge entry you are attempting to " +
                                "relate to this record does not exist.", Ex);
                        default:
                            throw new Exception("An database server error ocurred while " +
                                "saving the Charge definition.", Ex);
                    }
                default:
                    throw new Exception("An error ocurred while saving " +
                        " the Charge definition.", Ex);
            }
        }

        private void HandleDeleteError(Exception Ex)
        {
            switch (Ex.GetBaseException().GetType().FullName)
            {
                case "System.Data.SqlClient.SqlException":
                    SqlException sqlException = (SqlException)Ex.GetBaseException();
                    switch (sqlException.Number)
                    {
                        case 547:
                            throw new Exception("The Charge entry you are attempting to " +
                                "delete is being referenced by one or more database " +
                                "entities. Please delete any existing references to " +
                                "this Charge entry before attempting to delete it.", Ex);
                        default:
                            throw new Exception("An database server error ocurred while " +
                                "deleting the Charge.", Ex);
                    }
                default:
                    throw new Exception("An error ocurred while deleting " +
                        " the Charge.", Ex);
            }
        }

        private XmlDocument GetDeleteChargeXml(string AgentID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("ChargeID",
                SqlDbType.Int, 0, this.ChargeID.ToString(),
                ref cookItems);

            try
            {
                return DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

        }

        private XmlDocument GetInsertChargeXml()
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[5];


            DbRequestXmlCooker.AttachCookItem("chargeID",
                SqlDbType.Int, 0, this.ChargeID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("effectiveDate",
                SqlDbType.DateTime, 0, this.EffectiveDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("chargePercent",
                SqlDbType.Float, 0, this.ChargePercent.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("policyType",
                SqlDbType.Int, 0, this.PolicyType.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("renewalsOnly",
                SqlDbType.Bit, 0, this.RenewalsOnly.ToString(),
                ref cookItems);
            try
            {
                return DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
        }

        private XmlDocument GetUpdateChargeXml()
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[5];

            DbRequestXmlCooker.AttachCookItem("chargeID",
                SqlDbType.Int, 0, this.ChargeID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("effectiveDate",
                SqlDbType.DateTime, 0, this.EffectiveDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("chargePercent",
                SqlDbType.Float, 0, this.ChargePercent.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("policyType",
                SqlDbType.Int, 0, this.PolicyType.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("renewalsOnly",
                SqlDbType.Bit, 0, this.RenewalsOnly.ToString(),
                ref cookItems);

            try
            {
                return DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }


        }

        private XmlDocument GetChargebyChargeIDXml()
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("chargeID",
                SqlDbType.Int,0, this.ChargeID.ToString(),
                ref cookItems);

            try
            {
                return DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

        }

        private void Validate()
        {
            string errorMessage = String.Empty;
            bool found = false;

            if (this.EffectiveDate == "")
            {
                errorMessage += "The Effective Date cannot be empty.  ";
                found = true;
            }

            DataTable dt = LookupTables.GetTable("Charge");

            if (this.ActionMode == 1)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    if (dt.Rows[i]["effectiveDate"].ToString().Trim().ToUpper() == this.EffectiveDate.Trim().ToUpper())
                    {
                        errorMessage = "This Effective Date already exists.";
                        found = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    if (dt.Rows[i]["effectiveDate"].ToString().Trim() == this.EffectiveDate.Trim() && dt.Rows[i]["chargeID"].ToString().Trim() != this.ChargeID.ToString().Trim())
                    {
                        errorMessage = "This Effective Date already exists.";
                        found = true;
                    }
                }
            }

            if (found == true)
            {
                throw new Exception(errorMessage);
            }
        }

        #region History
        
        
        private void History(int mode, int userID)
        {
            Audit.History history = new Audit.History();

            if (_actionMode == 2)
            {
                EPolicy.LookupTables.Charge oldCharge = new EPolicy.LookupTables.Charge();
                oldCharge = oldCharge.GetCharge(this.ChargeID.ToString().Trim());//userID);

                history.BuildNotesForHistory("Effective Date", oldCharge.EffectiveDate.ToString().Trim(), this.EffectiveDate.ToString().Trim(), mode);
                history.BuildNotesForHistory("Charge Percent", oldCharge.ChargePercent.ToString().Trim(), this.ChargePercent.ToString().Trim(), mode);
                
                history.Actions = "EDIT";
            }
            else  //ADD & DELETE
            {
                history.BuildNotesForHistory("ChargeID.", "", this.ChargeID.ToString(), mode);
                history.Actions = "ADD";
            }

            history.KeyID = this.ChargeID.ToString();
            history.Subject = "CHARGE";
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
        
        #endregion

    }
}
