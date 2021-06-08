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
    class LaboratoryQuote : Policy
    {
        public LaboratoryQuote(bool isOPPQuote)
        {
            this.AgentList = Policy.GetAgentListByPolicyClassID(0);
            this.IsPolicy = isOPPQuote;
            this.PolicyClassID = 16;
            this.InsuranceCompany = "000";
            this.Agency = "000";
            this.Agent = "000";
            this.Bank = "000";
            this.Dealer = "000";
            this.CompanyDealer = "000";
            this.IsPolicy = false;
            this.TaskStatusID = int.Parse(LookupTables.LookupTables.GetID("TaskStatus", "Open"));

            if (this.IsPolicy)
            {
                this.TaskControlTypeID = int.Parse(LookupTables.LookupTables.GetID("TaskControlType", "LaboratoryQuote"));
                this.DepartmentID = 2;
            }
            else
            {
                this.TaskControlTypeID = int.Parse(LookupTables.LookupTables.GetID("TaskControlType", "LaboratoryQuote"));
            }
        }

        #region Variables

        private LaboratoryQuote oldLaboratoryQuote = null;
        private DataTable _dtLaboratoryQuote;
        private DataTable _LaboratoryQuoteDetailCollection = null;
        private int _LaboratoryQuoteID = 0;
        private string _Laboratory = "";
        private int _FinancialID = 0;
        private int _SpecialtyID = 0;
        private int _mode = (int)TaskControlMode.CLEAR;
        private bool _IsPolicy = false;
        private string _Comments = "";
        private string _RetroDate = "";

        #endregion

        #region Properties

        public DataTable LaboratoryQuoteDetailCollection
        {
            get
            {
                //if (this._LaboratoryQuoteDetailCollection == null)
                    //this._LaboratoryQuoteDetailCollection = DataTableCorporatePolicyDetailTemp();
                return (this._LaboratoryQuoteDetailCollection);
            }
            set
            {
                this._LaboratoryQuoteDetailCollection = value;
            }
        }

        public int LaboratoryQuoteID
        {
            get { return (this._LaboratoryQuoteID); }
            set { this._LaboratoryQuoteID = value; }
        }

        public string Laboratory
        {
            get { return this._Laboratory; }
            set { this._Laboratory = value; }
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

        public int SpecialtyID
        {
            get
            {
                return this._SpecialtyID;
            }
            set
            {
                this._SpecialtyID = value;
            }
        }

        public string Comments
        {
            get 
            { 
                return this._Comments; 
            }
            set 
            { 
                this._Comments = value; 
            }
        }

        public string RetroDate
        {
            get 
            { 
                return this._RetroDate; 
            }
            set 
            { 
                this._RetroDate = value; 
            }
        }

        public bool IsPolicy
        {
            get 
            { 
                return this._IsPolicy; 
            }
            set 
            { 
                this._IsPolicy = value; 
            }
        }

        #endregion

        #region Public Methods

        #endregion
    }
}
