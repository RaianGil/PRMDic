using System;
using System.Xml;
using System.Data;
using Baldrich.DBRequest;
using System.Data.SqlClient;
using EPolicy.XmlCooker;
using EPolicy.Audit;

namespace EPolicy.LookupTables
{
    public class VSCRate
    {
        public VSCRate()
        {
        }

        #region Enumerations

        public enum VSCRateMode { ADD = 1, UPDATE = 2, DELETE = 3, CLEAR = 4 };

        #endregion

        #region Variables
        private VSCRate oldVSCRate = null;
        private DataTable _dtVSCRate;
        private int _VSCRateID = 0;
        private string _EffectiveDate = DateTime.Now.ToShortDateString();
        private int _CoveragePlanID = 0;
        private int _NewUse = 0;
        private int _MilleageFrom = 0;
        private int _MilleageTo = 0;
        private int _Term = 0;
        private int _Miles = 0;
        private int _VehicleMakeID = 0;
        private int _VehicleModelID = 0;
        private int _VehicleYearID = 0;
        private bool _Turbo = false;
        private bool _WD4 = false;
        private bool _Diesel = false;
        private string _Code = "";
        private string _Class = "";
        private double _LossFund = 0.00;
        private double _OverHead = 40.00;
        private double _BankFee = 50.00;
        private double _Concurso = 50.00;
        private double _Profit = 0.00;
        private double _DealerCost = 0.00;
        private double _DealerProfit = 0.00;
        private double _TotalPrice = 0.00;
        private double _CanReserve = 150.00;
        private double _DealerNet = 0.00;
        private string _CanPercent = "0";
        private bool _PowerTrain = false;
        private string _CompanyDealer = "000";
        private double _Charge = 0.00;
        private int _Mode = (int)VSCRateMode.CLEAR;

        #endregion

        #region Properties

        public int VSCRateID
        {
            get
            {
                return this._VSCRateID;
            }
            set
            {
                this._VSCRateID = value;
            }
        }

        public string EffectiveDate
        {
            get
            {
                return this._EffectiveDate;
            }
            set
            {
                this._EffectiveDate = value;
            }
        }

        public int CoveragePlanID
        {
            get
            {
                return this._CoveragePlanID;
            }
            set
            {
                this._CoveragePlanID = value;
            }
        }

        public int NewUse
        {
            get
            {
                return this._NewUse;
            }
            set
            {
                this._NewUse = value;
            }
        }

        public int MilleageFrom
        {
            get
            {
                return this._MilleageFrom;
            }
            set
            {
                this._MilleageFrom = value;
            }
        }

        public int MilleageTo
        {
            get
            {
                return this._MilleageTo;
            }
            set
            {
                this._MilleageTo = value;
            }
        }

        public int Term
        {
            get
            {
                return this._Term;
            }
            set
            {
                this._Term = value;
            }
        }

        public int Miles
        {
            get
            {
                return this._Miles;
            }
            set
            {
                this._Miles = value;
            }
        }

        public int VehicleMakeID
        {
            get
            {
                return this._VehicleMakeID;
            }
            set
            {
                this._VehicleMakeID = value;
            }
        }

        public int VehicleModelID
        {
            get
            {
                return this._VehicleModelID;
            }
            set
            {
                this._VehicleModelID = value;
            }
        }

        public int VehicleYearID
        {
            get
            {
                return this._VehicleYearID;
            }
            set
            {
                this._VehicleYearID = value;
            }
        }

        public bool Turbo
        {
            get
            {
                return this._Turbo;
            }
            set
            {
                this._Turbo = value;
            }
        }

        public bool Diesel
        {
            get
            {
                return this._Diesel;
            }
            set
            {
                this._Diesel = value;
            }
        }

        public bool WD4
        {
            get
            {
                return this._WD4;
            }
            set
            {
                this._WD4 = value;
            }
        }

        public string Code
        {
            get
            {
                return this._Code;
            }
            set
            {
                this._Code = value;
            }
        }

        public string Class
        {
            get
            {
                return this._Class;
            }
            set
            {
                this._Class = value;
            }
        }

        public double LossFund
        {
            get
            {
                return this._LossFund;
            }
            set
            {
                this._LossFund = value;
            }
        }

        public double OverHead
        {
            get
            {
                return this._OverHead;
            }
            set
            {
                this._OverHead = value;
            }
        }

        public double BankFee
        {
            get
            {
                return this._BankFee;
            }
            set
            {
                this._BankFee = value;
            }
        }

        public double Concurso
        {
            get
            {
                return this._Concurso;
            }
            set
            {
                this._Concurso = value;
            }
        }

        public double Profit
        {
            get
            {
                return this._Profit;
            }
            set
            {
                this._Profit = value;
            }
        }

        public double DealerCost
        {
            get
            {
                return this._DealerCost;
            }
            set
            {
                this._DealerCost = value;
            }
        }

        public double DealerProfit
        {
            get
            {
                return this._DealerProfit;
            }
            set
            {
                this._DealerProfit = value;
            }
        }

        public double TotalPrice
        {
            get
            {
                return this._TotalPrice;
            }
            set
            {
                this._TotalPrice = value;
            }
        }

        public double CanReserve
        {
            get
            {
                return this._CanReserve;
            }
            set
            {
                this._CanReserve = value;
            }
        }

        public double DealerNet
        {
            get
            {
                return this._DealerNet;
            }
            set
            {
                this._DealerNet = value;
            }
        }

        public string CanPercent
        {
            get
            {
                return this._CanPercent;
            }
            set
            {
                this._CanPercent = value;
            }
        }

        public bool PowerTrain
        {
            get
            {
                return this._PowerTrain;
            }
            set
            {
                this._PowerTrain = value;
            }
        }

        public double Charge
        {
            get
            {
                return this._Charge;
            }
            set
            {
                this._Charge = value;
            }
        }

        public string CompanyDealer
        {
            get
            {
                return this._CompanyDealer;
            }
            set
            {
                this._CompanyDealer = value;
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

        #endregion

        #region Public Methods

        public static DataTable GetVSCRateByCriteria(int vehicleMake, int vehicleModel, int coveragePlanID)
        {
            DataTable dt = GetVSCRateByCriteriaDB(vehicleMake, vehicleModel, coveragePlanID);

            return dt;
        }

        public static DataTable GetVSCRateByClass(string Class, int MakeID)
        {
            DataTable dt = GetVSCRateByClassDB(Class, MakeID);

            if(dt.Rows.Count != 0)
            {
                dt = SetRows(dt);
            }

            return dt;
        }

        public static DataTable GetVSCRateToExceptionByCriteria(string DealerID, int CoveragePlanID, int MakeID, int ModelID, int NewUse)
        {
            DataTable dt = GetVSCRateToExceptionByCriteriaDB(DealerID, CoveragePlanID, MakeID, ModelID, NewUse);

            if (dt.Rows.Count != 0)
            {
                dt = SetRows(dt);
            }

            return dt;
        }

        public static DataTable GetVSCAdmin(string EffectiveDate)
        {
            DataTable dt = GetVSCAdminDB(EffectiveDate);

            return dt;
        }

        public static VSCRate GetVSCRateByVSCRateID(int VSCRateID, int UserID)
        {
            VSCRate vscRate = null;

            DataTable dt = GetVSCRateByVSCRateIDDB(VSCRateID);
            vscRate = new VSCRate();

            vscRate._dtVSCRate = dt;
            vscRate = FillProperties(vscRate, UserID);

            return vscRate;
        }


        public void SaveVSCRate(int UserID)
        {
            this.Save(UserID);
        }

        public static void DeleteVSCRateByVSCRateID(int vscRateID)
        {
            DBRequest Executor = new DBRequest();
            Executor.Update("DeleteVSCRate", DeleteVSCRateByVSCRateIDXml(vscRateID));
        }

        #endregion

        #region Private Methods

        private static DataTable SetRows(DataTable dt)
        {
            DataTable dtnew = new DataTable();
            dtnew = dt.Clone();

            string covPlan = "";
            int Term = 0;
            int Miles = 0;
            int MilleageFrom = 0;
            int MilleageTo = 0;
            int newuse = 0;

            for(int i=0; i <= dt.Rows.Count -1; i ++)
            {
                if (covPlan != dt.Rows[i]["CoveragePlanDesc"].ToString() ||
                   Term != (int)dt.Rows[i]["Term"] ||
                   Miles != (int)dt.Rows[i]["Miles"] ||
                   MilleageFrom != (int)dt.Rows[i]["MilleageFrom"] ||
                   MilleageTo != (int)dt.Rows[i]["MilleageTo"] ||
                   newuse != (int)dt.Rows[i]["NewUse"])
                {
                    DataRow myRow = dtnew.NewRow();
                    myRow["VSCRateID"] = (int)dt.Rows[i]["VSCRateID"];

                    if (covPlan != dt.Rows[i]["CoveragePlanDesc"].ToString())
                        myRow["CoveragePlanDesc"] = dt.Rows[i]["CoveragePlanDesc"].ToString();
                    else
                        myRow["CoveragePlanDesc"] = "";

                    myRow["EffectiveDate"] = dt.Rows[i]["EffectiveDate"].ToString();
                    myRow["NewUse"] = (int)dt.Rows[i]["NewUse"];
                    myRow["Term"] = (int)dt.Rows[i]["Term"];
                    myRow["MilleageFrom"] = (int)dt.Rows[i]["MilleageFrom"];
                    myRow["MilleageTo"] = (int)dt.Rows[i]["MilleageTo"];
                    myRow["Miles"] = (int)dt.Rows[i]["Miles"];
                    myRow["WD4"] = (bool)dt.Rows[i]["WD4"];
                    myRow["Turbo"] = (bool)dt.Rows[i]["Turbo"];
                    myRow["Diesel"] = (bool)dt.Rows[i]["Diesel"];
                    myRow["LossFund"] = (double)dt.Rows[i]["LossFund"];
                    myRow["Overhead"] = (double)dt.Rows[i]["Overhead"];
                    myRow["BankFee"] = (double)dt.Rows[i]["BankFee"];
                    myRow["Concurso"] = (double)dt.Rows[i]["Concurso"];
                    myRow["Profit"] = (double)dt.Rows[i]["Profit"];
                    myRow["DealerCost"] = (double)dt.Rows[i]["DealerCost"];
                    myRow["DealerProfit"] = (double)dt.Rows[i]["DealerProfit"];
                    myRow["DealerNet"] = (double)dt.Rows[i]["DealerNet"];
                    myRow["CanPercent"] = dt.Rows[i]["CanPercent"].ToString();
                    myRow["CancReserve"] = (double) dt.Rows[i]["CancReserve"];
                    myRow["SuggestedPrice"] = (double)dt.Rows[i]["SuggestedPrice"];
                    myRow["PowerTrain"] = (bool)dt.Rows[i]["PowerTrain"];
                    myRow["CoveragePlanID"] = (int)dt.Rows[i]["CoveragePlanID"];
                    myRow["Code"] = dt.Rows[i]["Code"].ToString();
                    myRow["Class"] = dt.Rows[i]["Class"].ToString();
                    myRow["Charge"] = (double) dt.Rows[i]["Charge"];
                    myRow["VehicleMakeDesc"] = dt.Rows[i]["VehicleMakeDesc"].ToString();
                    myRow["VehicleModelDesc"] = dt.Rows[i]["VehicleModelDesc"].ToString();
                    myRow["VehicleMakeID"] = dt.Rows[i]["VehicleMakeID"].ToString();
                    myRow["VehicleModelID"] = dt.Rows[i]["VehicleModelID"].ToString();

                    dtnew.Rows.Add(myRow);
                    dtnew.AcceptChanges();

                    covPlan = dt.Rows[i]["CoveragePlanDesc"].ToString();
                    Term = (int)dt.Rows[i]["Term"];
                    Miles = (int)dt.Rows[i]["Miles"];
                    MilleageFrom = (int)dt.Rows[i]["MilleageFrom"];
                    MilleageTo = (int)dt.Rows[i]["MilleageTo"];
                    newuse = (int)dt.Rows[i]["NewUse"];
                }
            }

            return dtnew;
        }

        public DataTable IsExceptionRateExistByDealer()
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[9];

            DbRequestXmlCooker.AttachCookItem("CoveragePlanID",
                SqlDbType.Int, 0, this.CoveragePlanID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("NewUse",
                SqlDbType.Int, 200, this.NewUse.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Term",
                SqlDbType.Int, 0, this.Term.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Miles",
                SqlDbType.Int, 0, this.Miles.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("VehicleMakeID",
                 SqlDbType.Int, 0, this.VehicleMakeID.ToString(),
                 ref cookItems);

            DbRequestXmlCooker.AttachCookItem("VehicleModelID",
                SqlDbType.Int, 0, this.VehicleModelID.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("MilleageFrom",
                SqlDbType.Int, 200, this.MilleageFrom.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("MilleageTo",
                SqlDbType.Int, 0, this.MilleageTo.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CompanyDealer",
                SqlDbType.Char, 3, this.CompanyDealer.ToString(),
                ref cookItems);

            DBRequest exec = new DBRequest();
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
                dt = exec.GetQuery("GetVSCExceptionRATEVerify", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve the rate to verify.", ex);
            }
        }

        public bool IsRateExist()
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[8];

            DbRequestXmlCooker.AttachCookItem("CoveragePlanID",
                SqlDbType.Int, 0, this.CoveragePlanID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("NewUse",
                SqlDbType.Int, 200, this.NewUse.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Term",
                SqlDbType.Int, 0, this.Term.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Miles",
                SqlDbType.Int, 0, this.Miles.ToString(),
                ref cookItems);

           DbRequestXmlCooker.AttachCookItem("VehicleMakeID",
                SqlDbType.Int, 0, this.VehicleMakeID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("VehicleModelID",
                SqlDbType.Int, 0, this.VehicleModelID.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("MilleageFrom",
                SqlDbType.Int, 200, this.MilleageFrom.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("MilleageTo",
                SqlDbType.Int, 0, this.MilleageTo.ToString(),
                ref cookItems);

            DBRequest exec = new DBRequest();
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
                dt = exec.GetQuery("GetVSCRATEVerify", xmlDoc);

                if(dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve the rate to verify.", ex);
            } 
        }

        private static XmlDocument DeleteVSCRateByVSCRateIDXml(int vscRateID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("VSCRateID",
                SqlDbType.Int, 0, vscRateID.ToString(),
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

        private void Save(int UserID)
        {
            if (this.Mode == 2)
                oldVSCRate = (VSCRate)VSCRate.GetVSCRateByVSCRateID(this.VSCRateID, UserID);

            DBRequest Executor = new DBRequest();
            try
            {
                Executor.BeginTrans();
                switch (this.Mode)
                {
                    case 1:  //ADD
                        this.VSCRateID = Executor.Insert("AddVSCRate", this.GetInsertVSCRateXml());
                        this.History(this.Mode, UserID);
                        break;

                    default: //UPDATE
                        this.History(this.Mode, UserID);
                        Executor.Update("UpdateVSCRate", this.GetUpdateVSCRateXml());
                        break;
                }
                Executor.CommitTrans();
            }

            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error while trying to save this rate. " + xcp.Message, xcp);
            }

            this.Mode = 4;
        }

        private XmlDocument GetUpdateVSCRateXml()
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[30];

            DbRequestXmlCooker.AttachCookItem("VSCRateID",
                SqlDbType.Int, 0, this.VSCRateID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EffectiveDate",
                SqlDbType.DateTime, 0, this.EffectiveDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CoveragePlanID",
                SqlDbType.Int, 0, this.CoveragePlanID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("NewUse",
                SqlDbType.Int, 200, this.NewUse.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("MilleageFrom",
                SqlDbType.Int, 200, this.MilleageFrom.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("MilleageTo",
                SqlDbType.Int, 0, this.MilleageTo.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Term",
                SqlDbType.Int, 0, this.Term.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Miles",
                SqlDbType.Int, 0, this.Miles.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("VehicleMakeID",
                SqlDbType.Int, 0, this.VehicleMakeID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("VehicleModelID",
                SqlDbType.Int, 0, this.VehicleModelID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("VehicleYearID",
                SqlDbType.Int, 0, this.VehicleYearID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Turbo",
                SqlDbType.Bit, 0, this.Turbo.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("WD4",
                SqlDbType.Bit, 0, this.WD4.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Diesel",
                SqlDbType.Bit, 0, this.Diesel.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Code",
                SqlDbType.VarChar, 20, this.Code.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Class",
                SqlDbType.VarChar, 20, this.Class.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("LossFund",
                SqlDbType.Float, 0, this.LossFund.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("OverHead",
                SqlDbType.Float, 0, this.OverHead.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("BankFee",
                SqlDbType.Float, 0, this.BankFee.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Concurso",
                SqlDbType.Float, 0, this.Concurso.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Profit",
                SqlDbType.Float, 0, this.Profit.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("DealerCost",
                SqlDbType.Float, 0, this.DealerCost.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("DealerProfit",
                SqlDbType.Float, 0, this.DealerProfit.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("TotalPrice",
                SqlDbType.Float, 0, this.TotalPrice.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CanReserve",
                SqlDbType.Float, 0, this.CanReserve.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("DealerNet",
                SqlDbType.Float, 0, this.DealerNet.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CanPercent",
                SqlDbType.Char, 3, this.CanPercent.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PowerTrain",
                SqlDbType.Bit, 0, this.PowerTrain.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CompanyDealer",
                SqlDbType.Char, 3, this.CompanyDealer.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Charge",
                SqlDbType.Float, 0, this.Charge.ToString(),
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

        private XmlDocument GetInsertVSCRateXml()
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[29];

            DbRequestXmlCooker.AttachCookItem("EffectiveDate",
              SqlDbType.DateTime, 0, this.EffectiveDate.ToString(),
              ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CoveragePlanID",
                SqlDbType.Int, 0, this.CoveragePlanID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("NewUse",
                SqlDbType.Int, 200, this.NewUse.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("MilleageFrom",
                SqlDbType.Int, 200, this.MilleageFrom.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("MilleageTo",
                SqlDbType.Int, 0, this.MilleageTo.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Term",
                SqlDbType.Int, 0, this.Term.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Miles",
                SqlDbType.Int, 0, this.Miles.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("VehicleMakeID",
                SqlDbType.Int, 0, this.VehicleMakeID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("VehicleModelID",
                SqlDbType.Int, 0, this.VehicleModelID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("VehicleYearID",
                SqlDbType.Int, 0, this.VehicleYearID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Turbo",
                SqlDbType.Bit, 0, this.Turbo.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("WD4",
                SqlDbType.Bit, 0, this.WD4.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Diesel",
                SqlDbType.Bit, 0, this.Diesel.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Code",
                SqlDbType.VarChar, 20, this.Code.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Class",
                SqlDbType.VarChar, 20, this.Class.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("LossFund",
                SqlDbType.Float, 0, this.LossFund.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("OverHead",
                SqlDbType.Float, 0, this.OverHead.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("BankFee",
                SqlDbType.Float, 0, this.BankFee.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Concurso",
                SqlDbType.Float, 0, this.Concurso.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Profit",
                SqlDbType.Float, 0, this.Profit.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("DealerCost",
                SqlDbType.Float, 0, this.DealerCost.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("DealerProfit",
                SqlDbType.Float, 0, this.DealerProfit.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("TotalPrice",
                SqlDbType.Float, 0, this.TotalPrice.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CanReserve",
                SqlDbType.Float, 0, this.CanReserve.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("DealerNet",
                SqlDbType.Float, 0, this.DealerNet.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CanPercent",
                SqlDbType.Char, 3, this.CanPercent.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PowerTrain",
                SqlDbType.Bit, 0, this.PowerTrain.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CompanyDealer",
                SqlDbType.Char, 3, this.CompanyDealer.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Charge",
                SqlDbType.Float, 0, this.Charge.ToString(),
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

        private static DataTable GetVSCAdminDB(string EffectiveDate)
        {
            DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("EffectiveDate",
                SqlDbType.VarChar, 20, EffectiveDate.ToString(),
                ref cookItems);

            DBRequest exec = new DBRequest();
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
                dt = exec.GetQuery("GetVSCAdmin", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve the orders by criteria.", ex);
            }
        }

        private static DataTable GetVSCRateToExceptionByCriteriaDB(string DealerID, int CoveragePlanID, int MakeID, int ModelID, int NewUse)
        {
            DbRequestXmlCookRequestItem[] cookItems =
      new DbRequestXmlCookRequestItem[5];

            DbRequestXmlCooker.AttachCookItem("DealerID",
                SqlDbType.Char, 3, DealerID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CoveragePlanID",
                SqlDbType.Int, 0, CoveragePlanID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("VehicleMakeID",
                SqlDbType.Int, 0, MakeID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("VehicleModelID",
                SqlDbType.Int, 0, ModelID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("NewUse",
                SqlDbType.Int, 0, NewUse.ToString(),
                ref cookItems);

            DBRequest exec = new DBRequest();
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
                dt = exec.GetQuery("GetVSCRateToExceptionByCriteria", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve the orders by criteria.", ex);
            }
        }

        private static DataTable GetVSCRateByClassDB(string Class, int MakeId)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("Class",
                SqlDbType.VarChar, 20, Class.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("VehicleMakeID",
                SqlDbType.Int, 0, MakeId.ToString(),
                ref cookItems);

            DBRequest exec = new DBRequest();
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
                dt = exec.GetQuery("GetVSCRateByClass", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve the orders by criteria.", ex);
            }
        }

        private static DataTable GetVSCRateByCriteriaDB(int vehicleMake, int vehicleModel, int coveragePlanID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[3];

            DbRequestXmlCooker.AttachCookItem("VehicleMakeID",
                SqlDbType.Int, 0, vehicleMake.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("VehicleModelID",
                SqlDbType.Int, 0, vehicleModel.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CoveragePlanID",
                SqlDbType.Int, 0, coveragePlanID.ToString(),
                ref cookItems);

            DBRequest exec = new DBRequest();
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
                dt = exec.GetQuery("GetVSCRateByCriteria", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve the orders by criteria.", ex);
            }
        }

        public static DataTable GetVSCRateByVSCRateIDDB(int vscRateID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("VSCRateID",
                SqlDbType.Int, 0, vscRateID.ToString(),
                ref cookItems);

            DBRequest exec = new DBRequest();
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
                dt = exec.GetQuery("GetVSCRateByVSCRateID", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve the order status by criteria.", ex);
            }
        }

        private void History(int mode, int userID)
        {
            //Audit.Audit history = new Audit.Audit();

            //if (mode == 2)
            //{
            //    history.BuildNotesForHistory("LocationID",
            //        LookupTables.LookupTables.GetDescription("Location", oldOrdersStatuscs.LocationID.ToString()),
            //        LookupTables.LookupTables.GetDescription("Location", this.LocationID.ToString()),
            //        mode);
            //    history.BuildNotesForHistory("PONumber", oldOrdersStatuscs.PONumber.ToString(), this.PONumber.ToString(), mode);
            //    history.BuildNotesForHistory("Description", oldOrdersStatuscs.Description, this.Description, mode);
            //    history.BuildNotesForHistory("PartNumber", oldOrdersStatuscs.PartNumber.ToString(), this.PartNumber.ToString(), mode);
            //    history.BuildNotesForHistory("Quantity", oldOrdersStatuscs.Quantity.ToString(), this.Quantity.ToString(), mode);
            //    history.BuildNotesForHistory("ShippingMethods", oldOrdersStatuscs.ShippingMethods.ToString(), this.ShippingMethods.ToString(), mode);
            //    history.BuildNotesForHistory("ShippingDate", oldOrdersStatuscs.ShippingDate.ToString(), this.ShippingDate.ToString(), mode);
            //    history.BuildNotesForHistory("AdditionalInformation", oldOrdersStatuscs.AdditionalInformation.ToString(), this.AdditionalInformation.ToString(), mode);
            //    history.BuildNotesForHistory("Shipped", oldOrdersStatuscs.Shipped.ToString(), this.Shipped.ToString(), mode);
            //    history.BuildNotesForHistory("PHCPO", oldOrdersStatuscs.PHCPO.ToString(), this.PHCPO.ToString(), mode);
            //    history.BuildNotesForHistory("PHCReceived", oldOrdersStatuscs.PHCReceived.ToString(), this.PHCReceived.ToString(), mode);

            //    history.BuildNotesForHistory("PHCAmount", oldOrdersStatuscs.PHCAmount.ToString("###,###.00"), this.PHCAmount.ToString("###,###.00"), mode);
            //    history.BuildNotesForHistory("ReceivedBy", oldOrdersStatuscs.ReceivedBy.ToString(), this.ReceivedBy.ToString(), mode);

            //    history.Actions = "EDIT";
            //}
            //else  //ADD & DELETE
            //{
            //    history.BuildNotesForHistory("OrdersID.", "", this.OrdersID.ToString(), mode);
            //    history.Actions = "ADD";
            //}

            //history.KeyID = this.OrdersID.ToString();
            //history.Subject = "0RDERSSTATUS";
            //history.UsersID = userID;
            //history.GetSaveHistory();
        }

        private static VSCRate FillProperties(VSCRate vscRate, int UserID)
        {
            vscRate.VSCRateID = (vscRate._dtVSCRate.Rows[0]["VSCRateID"] != System.DBNull.Value) ? (int)vscRate._dtVSCRate.Rows[0]["VSCRateID"] : 0;
            vscRate.EffectiveDate = (vscRate._dtVSCRate.Rows[0]["EffectiveDate"] != System.DBNull.Value) ? ((DateTime)vscRate._dtVSCRate.Rows[0]["EffectiveDate"]).ToShortDateString() : "";
            vscRate.CoveragePlanID = (vscRate._dtVSCRate.Rows[0]["CoveragePlanID"] != System.DBNull.Value) ? (int)vscRate._dtVSCRate.Rows[0]["CoveragePlanID"] : 0;
            vscRate.NewUse = (vscRate._dtVSCRate.Rows[0]["NewUse"] != System.DBNull.Value) ? (int)vscRate._dtVSCRate.Rows[0]["NewUse"] : 0;
            vscRate.MilleageFrom = (vscRate._dtVSCRate.Rows[0]["MilleageFrom"] != System.DBNull.Value) ? (int)vscRate._dtVSCRate.Rows[0]["MilleageFrom"] : 0;
            vscRate.MilleageTo = (vscRate._dtVSCRate.Rows[0]["MilleageTo"] != System.DBNull.Value) ? (int)vscRate._dtVSCRate.Rows[0]["MilleageTo"] : 0;
            vscRate.Term = (vscRate._dtVSCRate.Rows[0]["Term"] != System.DBNull.Value) ? (int)vscRate._dtVSCRate.Rows[0]["Term"] : 0;
            vscRate.Miles = (vscRate._dtVSCRate.Rows[0]["Miles"] != System.DBNull.Value) ? (int)vscRate._dtVSCRate.Rows[0]["Miles"] : 0;
            vscRate.VehicleMakeID = (vscRate._dtVSCRate.Rows[0]["VehicleMakeID"] != System.DBNull.Value) ? (int)vscRate._dtVSCRate.Rows[0]["VehicleMakeID"] : 0;
            vscRate.VehicleModelID = (vscRate._dtVSCRate.Rows[0]["VehicleModelID"] != System.DBNull.Value) ? (int)vscRate._dtVSCRate.Rows[0]["VehicleModelID"] : 0;
            vscRate.VehicleYearID = (vscRate._dtVSCRate.Rows[0]["VehicleYearID"] != System.DBNull.Value) ? (int)vscRate._dtVSCRate.Rows[0]["VehicleYearID"] : 0;
            vscRate.Turbo = (vscRate._dtVSCRate.Rows[0]["Turbo"] != System.DBNull.Value) ? (bool)vscRate._dtVSCRate.Rows[0]["Turbo"] : false;
            vscRate.WD4 = (vscRate._dtVSCRate.Rows[0]["WD4"] != System.DBNull.Value) ? (bool)vscRate._dtVSCRate.Rows[0]["WD4"] : false;
            vscRate.Diesel = (vscRate._dtVSCRate.Rows[0]["Diesel"] != System.DBNull.Value) ? (bool)vscRate._dtVSCRate.Rows[0]["Diesel"] : false;
            vscRate.Code = vscRate._dtVSCRate.Rows[0]["Code"].ToString().Trim();
            vscRate.Class = vscRate._dtVSCRate.Rows[0]["Class"].ToString().Trim();
            vscRate.LossFund = (double)vscRate._dtVSCRate.Rows[0]["LossFund"];
            vscRate.OverHead = (double)vscRate._dtVSCRate.Rows[0]["OverHead"];
            vscRate.BankFee = (double)vscRate._dtVSCRate.Rows[0]["BankFee"];
            vscRate.Concurso = (double)vscRate._dtVSCRate.Rows[0]["Concurso"];
            vscRate.Profit = (double)vscRate._dtVSCRate.Rows[0]["Profit"];
            vscRate.DealerCost = (double)vscRate._dtVSCRate.Rows[0]["DealerCost"];
            vscRate.DealerProfit = (double)vscRate._dtVSCRate.Rows[0]["DealerProfit"];
            vscRate.TotalPrice = (double)vscRate._dtVSCRate.Rows[0]["SuggestedPrice"];
            vscRate.CanReserve = (double)vscRate._dtVSCRate.Rows[0]["CancReserve"];
            vscRate.DealerNet = (double)vscRate._dtVSCRate.Rows[0]["DealerNet"];
            vscRate.CanPercent = vscRate._dtVSCRate.Rows[0]["CanPercent"].ToString().Trim();
            vscRate.PowerTrain = (vscRate._dtVSCRate.Rows[0]["PowerTrain"] != System.DBNull.Value) ? (bool)vscRate._dtVSCRate.Rows[0]["PowerTrain"] : false;
            vscRate.CompanyDealer = vscRate._dtVSCRate.Rows[0]["CompanyDealer"].ToString().Trim();
            vscRate.Charge = (double)vscRate._dtVSCRate.Rows[0]["Charge"];
            return vscRate;
        }

        #endregion
    }
}