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
    public class CertificateLocation
    {
        public CertificateLocation()
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
        private string _certificateLocationID = String.Empty;
        private string _certificateLocationDesc = String.Empty;
        private string _certificateLocationaddr1 = String.Empty;
        private string _certificateLocationaddr2 = String.Empty;
        private string _certificateLocationcity = String.Empty;
        private string _certificateLocationst = String.Empty;
        private string _certificateLocationzip = String.Empty;
        private string _certificateLocationphone = String.Empty;
        private string _certificateLocationEmail = String.Empty;
        private string _certificateLocationEmail2 = String.Empty;
        private string _certificateLocationEmail3 = String.Empty;

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

        public string CertificateLocationID
        {
            get
            {
                return this._certificateLocationID;
            }
            set
            {
                this._certificateLocationID = value;
            }
        }


        public string CertificateLocationDesc
        {
            get
            {
                return this._certificateLocationDesc;
            }
            set
            {
                this._certificateLocationDesc = value;
            }
        }

        public string certificateLocationaddr1
        {
            get
            {
                return this._certificateLocationaddr1;
            }
            set
            {
                this._certificateLocationaddr1 = value;
            }
        }

        public string certificateLocationaddr2
        {
            get
            {
                return this._certificateLocationaddr2;
            }
            set
            {
                this._certificateLocationaddr2 = value;
            }
        }

        public string certificateLocationcity
        {
            get
            {
                return this._certificateLocationcity;
            }
            set
            {
                this._certificateLocationcity = value;
            }
        }

        public string certificateLocationst
        {
            get
            {
                return this._certificateLocationst;
            }
            set
            {
                this._certificateLocationst = value;
            }
        }

        public string certificateLocationzip
        {
            get
            {
                return this._certificateLocationzip;
            }
            set
            {
                this._certificateLocationzip = value;
            }
        }


        public string certificateLocationphone
        {
            get
            {
                return this._certificateLocationphone;
            }
            set
            {
                this._certificateLocationphone = value;
            }
        }
        public string certificateLocationEmail
        {
            get
            {
                return this._certificateLocationEmail;
            }
            set
            {
                this._certificateLocationEmail = value;
            }
        }
        public string certificateLocationEmail2
        {
            get
            {
                return this._certificateLocationEmail2;
            }
            set
            {
                this._certificateLocationEmail2 = value;
            }
        }
        public string certificateLocationEmail3
        {
            get
            {
                return this._certificateLocationEmail3;
            }
            set
            {
                this._certificateLocationEmail3 = value;
            }
        }
        #endregion

        #region Public Methods

        private string GetNextCertificateLocationID()
        {
            DataTable dt = LookupTables.GetTable("CertificateLocation");
            DataRow[] dr = dt.Select("", "CertificateLocationID");

            DataTable dt2 = dt.Clone();
            

            for (int rec = 0; rec <= dr.Length -1; rec++)
            {
                DataRow myRow = dt2.NewRow();
                myRow["CertificateLocationID"] = dr[rec].ItemArray[0].ToString();
                myRow["CertificateLocationDesc"] = dr[rec].ItemArray[1].ToString();

                dt2.Rows.Add(myRow);
                dt2.AcceptChanges();
            }
            dt2.DefaultView.Sort = "CertificateLocationID";
            int ID = 0;

            ID = int.Parse(dt2.Rows[dt2.Rows.Count -1]["CertificateLocationID"].ToString()) + 1;

            return (ID.ToString().PadLeft(4, '0'));
        }
        #endregion

        #region Public Functions

        /*public void Delete(string AgentID)
        {
            try
            {
                Baldrich.DBRequest.DBRequest executor = new Baldrich.DBRequest.DBRequest();
                executor.Delete("DeleteAgentID",
                    this.GetDeleteAgentXml(AgentID));
            }
            catch (Exception ex)
            {
                this.HandleDeleteError(ex);
            }
        }*/

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
                        this.CertificateLocationID = GetNextCertificateLocationID();
                        executor.Insert("AddCertificateLocation", this.GetInsertCertificateLocationXml());
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
                        executor.Update("UpdateCertificateLocation", this.GetUpdateCertificateLocationXml());
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

        public CertificateLocation GetCertificateLocation(string CertificateLocationID)
        {
            try
            {
                DataTable dtCertificateLocation = new DataTable();
                CertificateLocation certificateLocation = new CertificateLocation();
                this.CertificateLocationID = CertificateLocationID;

                Baldrich.DBRequest.DBRequest executor = new Baldrich.DBRequest.DBRequest();

                dtCertificateLocation = executor.GetQuery("GetCertificateLocationByCertificateLocationID",
                    this.GetCertificateLocationByCertificateLocationIDXml());

                this.CertificateLocationDesc =
                    dtCertificateLocation.Rows[0]["CertificateLocationDesc"].ToString().Trim();

                this.certificateLocationaddr1 =
                    dtCertificateLocation.Rows[0]["CertificateLocationAdd1"].ToString().Trim();

                this.CertificateLocationID =
                    dtCertificateLocation.Rows[0]["CertificateLocationID"].ToString().Trim();

                this.certificateLocationaddr2 =
                    dtCertificateLocation.Rows[0]["CertificateLocationAdd2"].ToString().Trim();

                this.certificateLocationcity =
                    dtCertificateLocation.Rows[0]["CertificateLocationCity"].ToString().Trim();

                this.certificateLocationst =
                    dtCertificateLocation.Rows[0]["CertificateLocationState"].ToString().Trim();

                this.certificateLocationzip =
                    dtCertificateLocation.Rows[0]["CertificateLocationZip"].ToString().Trim();

                this.certificateLocationphone =
                    dtCertificateLocation.Rows[0]["CertificateLocationPhone"].ToString().Trim();

                this.certificateLocationEmail =
                    dtCertificateLocation.Rows[0]["CertificateLocationEmail"].ToString().Trim();

                this.certificateLocationEmail2 =
                    dtCertificateLocation.Rows[0]["certificateLocationEmail2"].ToString().Trim();

                this.certificateLocationEmail3 =
                    dtCertificateLocation.Rows[0]["certificateLocationEmail3"].ToString().Trim();

                return this;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Could not retrieve information for this Certificate Location.", ex);
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
                            throw new Exception("The Certificate Location make you are attempting to " +
                                "relate to this Agent does not exist.", Ex);
                        default:
                            throw new Exception("An database server error ocurred while " +
                                "saving the Certificate Location.", Ex);
                    }
                default:
                    throw new Exception("An error ocurred while saving " +
                        " the Certificate Location.", Ex);
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
                            throw new Exception("The Certificate Location you are attempting to " +
                                "delete is being referenced by one or more database " +
                                "entities. Please delete any existing references to " +
                                "this Certificate Location before attempting to delete it.", Ex);
                        default:
                            throw new Exception("An database server error ocurred while " +
                                "deleting the Certificate Location.", Ex);
                    }
                default:
                    throw new Exception("An error ocurred while deleting " +
                        " the Certificate Location.", Ex);
            }
        }

        private XmlDocument GetDeleteCertificateLocationXml(string CertificateLocationID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("CertificateLocationID",
                SqlDbType.VarChar, 3, this.CertificateLocationID.ToString(),
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

        private XmlDocument GetInsertCertificateLocationXml()
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[11];


            DbRequestXmlCooker.AttachCookItem("CertificateLocationID",
                SqlDbType.VarChar, 4, this.CertificateLocationID.ToString().Trim(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CertificateLocationDesc",
                SqlDbType.VarChar, 150, this.CertificateLocationDesc.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CertificateLocationAdd1",
                SqlDbType.VarChar, 150, this.certificateLocationaddr1.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CertificateLocationAdd2",
                SqlDbType.VarChar, 150, this.certificateLocationaddr2.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CertificateLocationCity",
                SqlDbType.VarChar, 50, this.certificateLocationcity.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CertificateLocationState",
                SqlDbType.VarChar, 2, this.certificateLocationst.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CertificateLocationZip",
                SqlDbType.VarChar, 10, this.certificateLocationzip.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CertificateLocationPhone",
                SqlDbType.VarChar, 15, this.certificateLocationphone.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CertificateLocationEmail",
               SqlDbType.VarChar, 50, this.certificateLocationEmail.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CertificateLocationEmail2",
               SqlDbType.VarChar, 50, this.certificateLocationEmail2.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CertificateLocationEmail3",
               SqlDbType.VarChar, 50, this.certificateLocationEmail3.ToString(),
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

        private XmlDocument GetUpdateCertificateLocationXml()
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[11];


            DbRequestXmlCooker.AttachCookItem("CertificateLocationID",
                SqlDbType.VarChar, 4, this.CertificateLocationID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CertificateLocationDesc",
                SqlDbType.VarChar, 150, this.CertificateLocationDesc.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CertificateLocationAdd1",
                SqlDbType.VarChar, 150, this.certificateLocationaddr1.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CertificateLocationAdd2",
                SqlDbType.VarChar, 150, this.certificateLocationaddr2.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CertificateLocationCity",
                SqlDbType.VarChar, 50, this.certificateLocationcity.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CertificateLocationState",
                SqlDbType.VarChar, 2, this.certificateLocationst.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CertificateLocationZip",
                SqlDbType.VarChar, 10, this.certificateLocationzip.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CertificateLocationPhone",
                SqlDbType.VarChar, 15, this.certificateLocationphone.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CertificateLocationEmail",
               SqlDbType.VarChar, 50, this.certificateLocationEmail.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CertificateLocationEmail2",
               SqlDbType.VarChar, 50, this.certificateLocationEmail2.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CertificateLocationEmail3",
               SqlDbType.VarChar, 50, this.certificateLocationEmail3.ToString(),
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

        private XmlDocument GetCertificateLocationByCertificateLocationIDXml()
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("CertificateLocationID",
                SqlDbType.VarChar, 3, this.CertificateLocationID.ToString(),
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

            if (this.CertificateLocationDesc == "")
            {
                errorMessage += "The Certificate Location cannot be empty.  ";
                found = true;
            }

            DataTable dt = LookupTables.GetTable("CertificateLocation");

            if (this.ActionMode == 1)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    if (dt.Rows[i]["CertificateLocationDesc"].ToString().Trim().ToUpper() == this.CertificateLocationDesc.Trim().ToUpper())
                    {
                        errorMessage = "This Certificate Location Description already exists.";
                        found = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    if (dt.Rows[i]["CertificateLocationDesc"].ToString().Trim() == this.CertificateLocationDesc.Trim()
                        && dt.Rows[i]["CertificateLocationID"].ToString().Trim() != this.CertificateLocationID.ToString().Trim())
                    {
                        errorMessage = "The Certificate Location Description already exists.";
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
                EPolicy.LookupTables.CertificateLocation oldCertificateLocation = new EPolicy.LookupTables.CertificateLocation();
                oldCertificateLocation = oldCertificateLocation.GetCertificateLocation(this.CertificateLocationID);//userID);

                history.BuildNotesForHistory("CertificateLocationDesc", oldCertificateLocation.CertificateLocationDesc, this.CertificateLocationDesc, mode);
                history.BuildNotesForHistory("CertificateLocationAdd1", oldCertificateLocation.certificateLocationaddr1, this.certificateLocationaddr1, mode);
                history.BuildNotesForHistory("CertificateLocationAdd2", oldCertificateLocation.certificateLocationaddr2, this.certificateLocationaddr2, mode);
                history.BuildNotesForHistory("CertificateLocationCity", oldCertificateLocation.certificateLocationcity, this.certificateLocationcity, mode);
                history.BuildNotesForHistory("CertificateLocationState", oldCertificateLocation.certificateLocationst, this.certificateLocationst, mode);
                history.BuildNotesForHistory("CertificateLocationZip", oldCertificateLocation.certificateLocationzip, this.certificateLocationzip, mode);
                history.BuildNotesForHistory("CertificateLocationPhone", oldCertificateLocation.certificateLocationphone, this.certificateLocationphone, mode);

                history.BuildNotesForHistory("CertificateLocationEmail", oldCertificateLocation.certificateLocationEmail, this.certificateLocationEmail, mode);
                history.BuildNotesForHistory("CertificateLocationEmail2", oldCertificateLocation.certificateLocationEmail2, this.certificateLocationEmail2, mode);
                history.BuildNotesForHistory("CertificateLocationEmail3", oldCertificateLocation.certificateLocationEmail3, this.certificateLocationEmail3, mode);


                history.Actions = "EDIT";
            }
            else  //ADD & DELETE
            {
                history.BuildNotesForHistory("CertificateLocationID.", "", this.CertificateLocationID.ToString(), mode);
                history.Actions = "ADD";
            }

            history.KeyID = this.CertificateLocationID.ToString();
            history.Subject = "CERT. LOCATION";
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
