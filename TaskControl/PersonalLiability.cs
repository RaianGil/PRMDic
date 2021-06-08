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
    public class PersonalLiability
    {
        public PersonalLiability()
        {

        }

        #region Variable

        private int _PersonalLiabilityID = 0;
        private int _TaskControlID = 0;
        private AdditionalCoverageLiability _AdditionalCoverageLiability = null;

        private string _Residence1 = "";
        private string _Residence2 = "";
        private string _Residence3 = "";
        private string _Residence4 = "";

        private bool _SwimmingPool1 = false;
        private bool _SwimmingPool2 = false;
        private bool _SwimmingPool3 = false;
        private bool _SwimmingPool4 = false;

        private int _Families1 = 0;
        private int _MedicalPayment1 = 0;
        private int _PersonalLiability1 = 0;
        private bool _Rented1 = false;

        private int _Families2 = 0;
        private int _MedicalPayment2 = 0;
        private int _PersonalLiability2 = 0;
        private bool _Rented2 = false;

        private int _Families3 = 0;
        private int _MedicalPayment3 = 0;
        private int _PersonalLiability3 = 0;
        private bool _Rented3 = false;

        private int _Families4 = 0;
        private int _MedicalPayment4 = 0;
        private int _PersonalLiability4 = 0;
        private bool _Rented4 = false;

        private double _BasicRate1 = 0.00;
        private double _IncreaseLimit1 = 0.00;
        private double _BasicPremium1 = 0.00;
        private double _MedicalPrem1 = 0.00;
        private double _DiscountFactor1 = 0.00;
        private double _Premium1 = 0.00;

        private double _BasicRate2 = 0.00;
        private double _IncreaseLimit2 = 0.00;
        private double _BasicPremium2 = 0.00;
        private double _MedicalPrem2 = 0.00;
        private double _DiscountFactor2 = 0.00;
        private double _Premium2 = 0.00;

        private double _BasicRate3 = 0.00;
        private double _IncreaseLimit3 = 0.00;
        private double _BasicPremium3 = 0.00;
        private double _MedicalPrem3 = 0.00;
        private double _DiscountFactor3 = 0.00;
        private double _Premium3 = 0.00;

        private double _BasicRate4 = 0.00;
        private double _IncreaseLimit4 = 0.00;
        private double _BasicPremium4 = 0.00;
        private double _MedicalPrem4 = 0.00;
        private double _DiscountFactor4 = 0.00;
        private double _Premium4 = 0.00;

        private double _TotalLiabilityPremium = 0.00;
        private Double _ExperienceCredit = 0;
        private double _SubTotalPremium = 0.00;
        private double _Charge = 0.00;
        private double _TotalPremium = 0.00;
        private int _mode = (int)PersonalLiabilityMode.CLEAR;

        #endregion

        #region Public Enumeration

        public enum PersonalLiabilityMode { ADD = 1, UPDATE = 2, DELETE = 3, CLEAR = 4 };

        #endregion

        #region Properties

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

        public AdditionalCoverageLiability AdditionalCoverageLiability
        {
            get
            {
                if (this._AdditionalCoverageLiability == null)
                    this._AdditionalCoverageLiability = new AdditionalCoverageLiability();
                return (this._AdditionalCoverageLiability);
            }
            set
            {
                this._AdditionalCoverageLiability = value;
            }
        }

        public string Residence1
        {
            get
            {
                return this._Residence1;
            }
            set
            {
                this._Residence1 = value;
            }
        }
        public string Residence2
        {
            get
            {
                return this._Residence2;
            }
            set
            {
                this._Residence2 = value;
            }
        }
        public string Residence3
        {
            get
            {
                return this._Residence3;
            }
            set
            {
                this._Residence3 = value;
            }
        }
        public string Residence4
        {
            get
            {
                return this._Residence4;
            }
            set
            {
                this._Residence4 = value;
            }
        }

        public bool SwimmingPool1
        {
            get
            {
                return this._SwimmingPool1;
            }
            set
            {
                this._SwimmingPool1 = value;
            }
        }
        public bool SwimmingPool2
        {
            get
            {
                return this._SwimmingPool2;
            }
            set
            {
                this._SwimmingPool2 = value;
            }
        }
        public bool SwimmingPool3
        {
            get
            {
                return this._SwimmingPool3;
            }
            set
            {
                this._SwimmingPool3 = value;
            }
        }
        public bool SwimmingPool4
        {
            get
            {
                return this._SwimmingPool4;
            }
            set
            {
                this._SwimmingPool4 = value;
            }
        }

        public int Families1
        {
            get
            {
                return this._Families1;
            }
            set
            {
                this._Families1 = value;
            }
        }
        public int MedicalPayment1
        {
            get
            {
                return this._MedicalPayment1;
            }
            set
            {
                this._MedicalPayment1 = value;
            }
        }
        public int PersonalLiability1
        {
            get
            {
                return this._PersonalLiability1;
            }
            set
            {
                this._PersonalLiability1 = value;
            }
        }
        public bool Rented1
        {
            get
            {
                return this._Rented1;
            }
            set
            {
                this._Rented1 = value;
            }
        }

        public int Families2
        {
            get
            {
                return this._Families2;
            }
            set
            {
                this._Families2 = value;
            }
        }
        public int MedicalPayment2
        {
            get
            {
                return this._MedicalPayment2;
            }
            set
            {
                this._MedicalPayment2 = value;
            }
        }
        public int PersonalLiability2
        {
            get
            {
                return this._PersonalLiability2;
            }
            set
            {
                this._PersonalLiability2 = value;
            }
        }
        public bool Rented2
        {
            get
            {
                return this._Rented2;
            }
            set
            {
                this._Rented2 = value;
            }
        }

        public int Families3
        {
            get
            {
                return this._Families3;
            }
            set
            {
                this._Families3 = value;
            }
        }
        public int MedicalPayment3
        {
            get
            {
                return this._MedicalPayment3;
            }
            set
            {
                this._MedicalPayment3 = value;
            }
        }
        public int PersonalLiability3
        {
            get
            {
                return this._PersonalLiability3;
            }
            set
            {
                this._PersonalLiability3 = value;
            }
        }
        public bool Rented3
        {
            get
            {
                return this._Rented3;
            }
            set
            {
                this._Rented3 = value;
            }
        }

        public int Families4
        {
            get
            {
                return this._Families4;
            }
            set
            {
                this._Families4 = value;
            }
        }
        public int MedicalPayment4
        {
            get
            {
                return this._MedicalPayment4;
            }
            set
            {
                this._MedicalPayment4 = value;
            }
        }
        public int PersonalLiability4
        {
            get
            {
                return this._PersonalLiability4;
            }
            set
            {
                this._PersonalLiability4 = value;
            }
        }
        public bool Rented4
        {
            get
            {
                return this._Rented4;
            }
            set
            {
                this._Rented4 = value;
            }
        }

        public double TotalLiabilityPremium
        {
            get
            {
                return this._TotalLiabilityPremium;
            }
            set
            {
                this._TotalLiabilityPremium = value;
            }
        }
        public Double ExperienceCredit
        {
            get
            {
                return this._ExperienceCredit;
            }
            set
            {
                this._ExperienceCredit = value;
            }
        }
        public double SubTotalPremium
        {
            get
            {
                return this._SubTotalPremium;
            }
            set
            {
                this._SubTotalPremium = value;
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
        public double TotalPremium
        {
            get
            {
                return this._TotalPremium;
            }
            set
            {
                this._TotalPremium = value;
            }
        }

        public int Mode
        {
            get
            {
                return this._mode;
            }
            set
            {
                this._mode = value;
            }
        }

        private double BasicRate1
        {
            get
            {
                return this._BasicRate1;
            }
            set
            {
                this._BasicRate1 = value;
            }
        }
        private double IncreaseLimit1
        {
            get
            {
                return this._IncreaseLimit1;
            }
            set
            {
                this._IncreaseLimit1 = value;
            }
        }
        private double BasicPremium1
        {
            get
            {
                return this._BasicPremium1;
            }
            set
            {
                this._BasicPremium1 = value;
            }
        }
        private double MedicalPrem1
        {
            get
            {
                return this._MedicalPrem1;
            }
            set
            {
                this._MedicalPrem1 = value;
            }
        }
        private double DiscountFactor1
        {
            get
            {
                return this._DiscountFactor1;
            }
            set
            {
                this._DiscountFactor1 = value;
            }
        }
        private double Premium1
        {
            get
            {
                return this._Premium1;
            }
            set
            {
                this._Premium1 = value;
            }
        }

        private double BasicRate2
        {
            get
            {
                return this._BasicRate2;
            }
            set
            {
                this._BasicRate2 = value;
            }
        }
        private double IncreaseLimit2
        {
            get
            {
                return this._IncreaseLimit2;
            }
            set
            {
                this._IncreaseLimit2 = value;
            }
        }
        private double BasicPremium2
        {
            get
            {
                return this._BasicPremium2;
            }
            set
            {
                this._BasicPremium2 = value;
            }
        }
        private double MedicalPrem2
        {
            get
            {
                return this._MedicalPrem2;
            }
            set
            {
                this._MedicalPrem2 = value;
            }
        }
        private double DiscountFactor2
        {
            get
            {
                return this._DiscountFactor2;
            }
            set
            {
                this._DiscountFactor2 = value;
            }
        }
        private double Premium2
        {
            get
            {
                return this._Premium2;
            }
            set
            {
                this._Premium2 = value;
            }
        }

        private double BasicRate3
        {
            get
            {
                return this._BasicRate3;
            }
            set
            {
                this._BasicRate3 = value;
            }
        }
        private double IncreaseLimit3
        {
            get
            {
                return this._IncreaseLimit3;
            }
            set
            {
                this._IncreaseLimit3 = value;
            }
        }
        private double BasicPremium3
        {
            get
            {
                return this._BasicPremium3;
            }
            set
            {
                this._BasicPremium3 = value;
            }
        }
        private double MedicalPrem3
        {
            get
            {
                return this._MedicalPrem3;
            }
            set
            {
                this._MedicalPrem3 = value;
            }
        }
        private double DiscountFactor3
        {
            get
            {
                return this._DiscountFactor3;
            }
            set
            {
                this._DiscountFactor3 = value;
            }
        }
        private double Premium3
        {
            get
            {
                return this._Premium3;
            }
            set
            {
                this._Premium3 = value;
            }
        }

        private double BasicRate4
        {
            get
            {
                return this._BasicRate4;
            }
            set
            {
                this._BasicRate4 = value;
            }
        }
        private double IncreaseLimit4
        {
            get
            {
                return this._IncreaseLimit4;
            }
            set
            {
                this._IncreaseLimit4 = value;
            }
        }
        private double BasicPremium4
        {
            get
            {
                return this._BasicPremium4;
            }
            set
            {
                this._BasicPremium4 = value;
            }
        }
        private double MedicalPrem4
        {
            get
            {
                return this._MedicalPrem4;
            }
            set
            {
                this._MedicalPrem4 = value;
            }
        }
        private double DiscountFactor4
        {
            get
            {
                return this._DiscountFactor4;
            }
            set
            {
                this._DiscountFactor4 = value;
            }
        }
        private double Premium4
        {
            get
            {
                return this._Premium4;
            }
            set
            {
                this._Premium4 = value;
            }
        }

        #endregion

        #region Public Methods

        public void SavePersonalLiability(int UserID, DataTable PersonaLiabilityTableTemp, int taskControlID, bool IsOPPQuote)
        {
            DBRequest Executor = new DBRequest();
            Executor.Update("DeletePersonalLiabilityByTaskControlID", DeletePersonalLiabilityByTaskControlIDXml(taskControlID, IsOPPQuote));

            //DataTable dt = PersonaLiabilityTableTemp;
            for (int i = 0; i < PersonaLiabilityTableTemp.Rows.Count; i++)
            {
                this.TaskControlID = taskControlID;
                this.Residence1 = PersonaLiabilityTableTemp.Rows[i]["Residence1"].ToString();
                this.Residence2 = PersonaLiabilityTableTemp.Rows[i]["Residence2"].ToString();
                this.Residence3 = PersonaLiabilityTableTemp.Rows[i]["Residence3"].ToString();
                this.Residence4 = PersonaLiabilityTableTemp.Rows[i]["Residence4"].ToString();
                this.SwimmingPool1 = bool.Parse(PersonaLiabilityTableTemp.Rows[i]["SwimmingPool1"].ToString());
                this.SwimmingPool2 = bool.Parse(PersonaLiabilityTableTemp.Rows[i]["SwimmingPool2"].ToString());
                this.SwimmingPool3 = bool.Parse(PersonaLiabilityTableTemp.Rows[i]["SwimmingPool3"].ToString());
                this.SwimmingPool4 = bool.Parse(PersonaLiabilityTableTemp.Rows[i]["SwimmingPool4"].ToString());
                this.Families1 = int.Parse(PersonaLiabilityTableTemp.Rows[i]["Families1"].ToString());
                this.Families2 = int.Parse(PersonaLiabilityTableTemp.Rows[i]["Families2"].ToString());
                this.Families3 = int.Parse(PersonaLiabilityTableTemp.Rows[i]["Families3"].ToString());
                this.Families4 = int.Parse(PersonaLiabilityTableTemp.Rows[i]["Families4"].ToString());
                this.MedicalPayment1 = int.Parse(PersonaLiabilityTableTemp.Rows[i]["MedicalPayment1"].ToString());
                this.MedicalPayment2 = int.Parse(PersonaLiabilityTableTemp.Rows[i]["MedicalPayment2"].ToString());
                this.MedicalPayment3 = int.Parse(PersonaLiabilityTableTemp.Rows[i]["MedicalPayment3"].ToString());
                this.MedicalPayment4 = int.Parse(PersonaLiabilityTableTemp.Rows[i]["MedicalPayment4"].ToString());
                this.PersonalLiability1 = int.Parse(PersonaLiabilityTableTemp.Rows[i]["PersonalLiability1"].ToString());
                this.PersonalLiability2 = int.Parse(PersonaLiabilityTableTemp.Rows[i]["PersonalLiability2"].ToString());
                this.PersonalLiability3 = int.Parse(PersonaLiabilityTableTemp.Rows[i]["PersonalLiability3"].ToString());
                this.PersonalLiability4 = int.Parse(PersonaLiabilityTableTemp.Rows[i]["PersonalLiability4"].ToString());
                this.Rented1 = bool.Parse(PersonaLiabilityTableTemp.Rows[i]["Rented1"].ToString());
                this.Rented2 = bool.Parse(PersonaLiabilityTableTemp.Rows[i]["Rented2"].ToString());
                this.Rented3 = bool.Parse(PersonaLiabilityTableTemp.Rows[i]["Rented3"].ToString());
                this.Rented4 = bool.Parse(PersonaLiabilityTableTemp.Rows[i]["Rented4"].ToString());
                this.TotalLiabilityPremium = double.Parse(PersonaLiabilityTableTemp.Rows[i]["TotalLiabilityPremium"].ToString());
                this.ExperienceCredit = Double.Parse(PersonaLiabilityTableTemp.Rows[i]["ExperienceCredit"].ToString());
                this.Charge = double.Parse(PersonaLiabilityTableTemp.Rows[i]["Charge"].ToString());
                this.SubTotalPremium = double.Parse(PersonaLiabilityTableTemp.Rows[i]["SubTotalPremium"].ToString());
                this.TotalPremium = double.Parse(PersonaLiabilityTableTemp.Rows[i]["TotalPremium"].ToString());

                this.BasicRate1 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["BasicRate1"].ToString());
                this.IncreaseLimit1 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["IncreaseLimit1"].ToString());
                this.BasicPremium1 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["BasicPremium1"].ToString());
                this.MedicalPrem1 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["MedicalPrem1"].ToString());
                this.DiscountFactor1 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["DiscountFactor1"].ToString());
                this.Premium1 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["Premium1"].ToString());

                this.BasicRate2 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["BasicRate2"].ToString());
                this.IncreaseLimit2 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["IncreaseLimit2"].ToString());
                this.BasicPremium2 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["BasicPremium2"].ToString());
                this.MedicalPrem2 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["MedicalPrem2"].ToString());
                this.DiscountFactor2 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["DiscountFactor2"].ToString());
                this.Premium2 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["Premium2"].ToString());

                this.BasicRate3 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["BasicRate3"].ToString());
                this.IncreaseLimit3 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["IncreaseLimit3"].ToString());
                this.BasicPremium3 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["BasicPremium3"].ToString());
                this.MedicalPrem3 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["MedicalPrem3"].ToString());
                this.DiscountFactor3 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["DiscountFactor3"].ToString());
                this.Premium3 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["Premium3"].ToString());

                this.BasicRate4 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["BasicRate4"].ToString());
                this.IncreaseLimit4 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["IncreaseLimit4"].ToString());
                this.BasicPremium4 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["BasicPremium4"].ToString());
                this.MedicalPrem4 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["MedicalPrem4"].ToString());
                this.DiscountFactor4 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["DiscountFactor4"].ToString());
                this.Premium4 = double.Parse(PersonaLiabilityTableTemp.Rows[i]["Premium4"].ToString());

                this.Mode = 1; //Add
                this.SavePersonalLiability(UserID, IsOPPQuote);
            }

            this.Mode = (int) PersonalLiabilityMode.CLEAR;
        }

        public static DataTable GetPersonalLiabilityByTaskControlID(int TaskControlID, bool IsOPPQuote)
        {
            DataTable dt = GetPersonalLiabilityByTaskControlIDDB(TaskControlID, IsOPPQuote);
            return dt;
        }

        public static DataTable GetPersonalLiabilityByPersonalLiabilityID(int personalLiabilityID, bool IsOPPQuote)
        {
            DataTable dt = GetPersonalLiabilityByPersonalLiabilityIDDB(personalLiabilityID, IsOPPQuote);
            return dt;
        }

        #endregion

        #region Private Methods

        private XmlDocument DeletePersonalLiabilityByTaskControlIDXml(int taskControlID, bool IsOppQuote)
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

        public static DataTable GetPersonalLiabilityByTaskControlIDDB(int taskControlID, bool IsOPPQuote)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, taskControlID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("IsOppQuote",
                 SqlDbType.Bit, 0, IsOPPQuote.ToString(),
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

            DataTable dt = exec.GetQuery("GetPersonalLiabilityByTaskControlID", xmlDoc);

            return dt;
        }

        private static DataTable GetPersonalLiabilityByPersonalLiabilityIDDB(int PersonalLiabilityID, bool IsOPPQuote)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("PersonalLiabilityID",
                SqlDbType.Int, 0, PersonalLiabilityID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("IsOppQuote",
                  SqlDbType.Bit, 0, IsOPPQuote.ToString(),
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

            DataTable dt = exec.GetQuery("GetPersonalLiabilityByPersonalLiabilityID", xmlDoc);
            return dt;
        }

        private void SavePersonalLiability(int UserID, bool IsOPPQuote)
        {
            Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
            try
            {
                Executor.BeginTrans();
                switch (this.Mode)
                {
                    case 1:  //ADD
                        this.PersonalLiabilityID = Executor.Insert("AddPersonalLiability", this.GetInsertPersonalLiabilityXml(IsOPPQuote));
                        //this.History(this._mode, UserID);
                        break;

                    case 3:  //DELETE
                        //Executor.Update("DeleteAutoGuardServicesContract",this.GetDeletePoliciesXml(IsOPPQuote));
                        break;

                    case 4:  //CLEAR						
                        break;

                    default: //UPDATE
                        //this.History(this._mode, UserID);
                        //Executor.Update("UpdateProperties", this.GetUpdatePropertiesXml(IsOPPQuote));
                        break;
                }
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error while trying to save the Personal Liability. " + xcp.Message, xcp);
            }
        } 

        private XmlDocument GetInsertPersonalLiabilityXml(bool IsOppQuote)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[55];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, this.TaskControlID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Residence1",
                SqlDbType.VarChar, 100, this.Residence1.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Residence2",
                SqlDbType.VarChar, 100, this.Residence2.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Residence3",
                SqlDbType.VarChar, 100, this.Residence3.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Residence4",
                SqlDbType.VarChar, 100, this.Residence4.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("SwimmingPool1",
                SqlDbType.Bit, 0, this.SwimmingPool1.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("SwimmingPool2",
                SqlDbType.Bit, 0, this.SwimmingPool2.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("SwimmingPool3",
                SqlDbType.Bit, 0, this.SwimmingPool3.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("SwimmingPool4",
                SqlDbType.Bit, 0, this.SwimmingPool4.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Families1",
                SqlDbType.Int, 0, this.Families1.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Families2",
                SqlDbType.Int, 0, this.Families2.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Families3",
                SqlDbType.Int, 0, this.Families3.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Families4",
                SqlDbType.Int, 0, this.Families4.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("MedicalPayment1",
                SqlDbType.Int, 0, this.MedicalPayment1.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("MedicalPayment2",
                SqlDbType.Int, 0, this.MedicalPayment2.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("MedicalPayment3",
                SqlDbType.Int, 0, this.MedicalPayment3.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("MedicalPayment4",
                SqlDbType.Int, 0, this.MedicalPayment4.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PersonalLiability1",
                SqlDbType.Int, 0, this.PersonalLiability1.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PersonalLiability2",
                SqlDbType.Int, 0, this.PersonalLiability2.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PersonalLiability3",
                SqlDbType.Int, 0, this.PersonalLiability3.ToString(),
                ref cookItems);

               DbRequestXmlCooker.AttachCookItem("PersonalLiability4",
                SqlDbType.Int, 0, this.PersonalLiability4.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Rented1",
                SqlDbType.Bit, 0, this.Rented1.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Rented2",
                SqlDbType.Bit, 0, this.Rented2.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Rented3",
                SqlDbType.Bit, 0, this.Rented3.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Rented4",
                SqlDbType.Bit, 0, this.Rented4.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("ExperienceCredit",
                SqlDbType.Float, 0, this.ExperienceCredit.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("BasicRate1",
                SqlDbType.Float, 0, this.BasicRate1.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("IncreaseLimit1",
                SqlDbType.Float, 0, this.IncreaseLimit1.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("BasicPremium1",
                SqlDbType.Float, 0, this.BasicPremium1.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("MedicalPrem1",
                SqlDbType.Float, 0, this.MedicalPrem1.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("DiscountFactor1",
                 SqlDbType.Float, 0, this.DiscountFactor1.ToString(),
                 ref cookItems);

             DbRequestXmlCooker.AttachCookItem("Premium1",
                  SqlDbType.Float, 0, this.Premium1.ToString(),
                  ref cookItems);

             DbRequestXmlCooker.AttachCookItem("BasicRate2",
                 SqlDbType.Float, 0, this.BasicRate2.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("IncreaseLimit2",
                SqlDbType.Float, 0, this.IncreaseLimit2.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("BasicPremium2",
                SqlDbType.Float, 0, this.BasicPremium2.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("MedicalPrem2",
                SqlDbType.Float, 0, this.MedicalPrem2.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("DiscountFactor2",
                 SqlDbType.Float, 0, this.DiscountFactor2.ToString(),
                 ref cookItems);

             DbRequestXmlCooker.AttachCookItem("Premium2",
                  SqlDbType.Float, 0, this.Premium2.ToString(),
                  ref cookItems);

             DbRequestXmlCooker.AttachCookItem("BasicRate3",
                   SqlDbType.Float, 0, this.BasicRate3.ToString(),
                  ref cookItems);

             DbRequestXmlCooker.AttachCookItem("IncreaseLimit3",
                SqlDbType.Float, 0, this.IncreaseLimit3.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("BasicPremium3",
                SqlDbType.Float, 0, this.BasicPremium3.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("MedicalPrem3",
                SqlDbType.Float, 0, this.MedicalPrem3.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("DiscountFactor3",
                 SqlDbType.Float, 0, this.DiscountFactor3.ToString(),
                 ref cookItems);

             DbRequestXmlCooker.AttachCookItem("Premium3",
                  SqlDbType.Float, 0, this.Premium3.ToString(),
                  ref cookItems);

             DbRequestXmlCooker.AttachCookItem("BasicRate4",
                   SqlDbType.Float, 0, this.BasicRate4.ToString(),
                  ref cookItems);

             DbRequestXmlCooker.AttachCookItem("IncreaseLimit4",
                SqlDbType.Float, 0, this.IncreaseLimit4.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("BasicPremium4",
                SqlDbType.Float, 0, this.BasicPremium4.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("MedicalPrem4",
                SqlDbType.Float, 0, this.MedicalPrem4.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("DiscountFactor4",
                 SqlDbType.Float, 0, this.DiscountFactor4.ToString(),
                 ref cookItems);

             DbRequestXmlCooker.AttachCookItem("Premium4",
                  SqlDbType.Float, 0, this.Premium4.ToString(),
                  ref cookItems);

            DbRequestXmlCooker.AttachCookItem("TotalLiabilityPremium",
                SqlDbType.Float, 0, this.TotalLiabilityPremium.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("SubTotalPremium",
                SqlDbType.Float, 0, this.SubTotalPremium.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Charge",
                 SqlDbType.Float, 0, this.Charge.ToString(),
                 ref cookItems);

            DbRequestXmlCooker.AttachCookItem("TotalPremium",
                 SqlDbType.Float, 0, this.TotalPremium.ToString(),
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

        #endregion

    }
}
