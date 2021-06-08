using System;
using System.Data;
using Baldrich.DBRequest;
using System.Xml;
using EPolicy.Customer;
using EPolicy.LookupTables;
using EPolicy.Audit;
using EPolicy.XmlCooker;


namespace EPolicy.TaskControl
{
	/// <summary>
	/// Summary description for Payments.
	/// </summary>
	public class Payments:TaskControl
	{
		public Payments()
		{
			this.PolicyClassID	  = 0;
			this.PolicyID         = 0;
			this.InsuranceCompany = "000";
			this.Agency           = "001";
			this.Agent            = "001";
			this.Bank			  = "000";
			this.Dealer			  = "000";
			this.CompanyDealer	  = "000";
			this.TaskStatusID     = 11; //Unapplied //int.Parse(LookupTables.LookupTables.GetID("TaskStatus","Open"));
			this.TaskControlTypeID = int.Parse(LookupTables.LookupTables.GetID("TaskControlType","Payments"));
			this._mode =(int) TaskControlMode.ADD;
		}

		#region Variables

		private Payments  oldPayment = null;
		private DataTable _dtPayments ;
		private int		_TaskPaymentID    = 0;
		private string	_PolicyType    	  = "";
		private string	_OriginalPolicyNo = "";
		private string	_PolicyNo		 = "";
		private string	_Certificate  	 = "";
		private string	_Sufijo    		 = "";
		private string	_LoanNo			 = "";
		private decimal _PaymentAmount	 = 0;
		private string	_CheckNo		 = "";
		private string  _PaymentDate	 = "";
		private int     _CreditDebitID   = 1;
		private string  _Comments        = "";
		private string  _Comments1        = "";
		private bool    _PaymentApplied  = false;
		private string  _AppliedDate	 = "";
		private bool    _License		 = false;
		private string  _DepositDate	 = "";
		private string	_InvoiceNo 		 = "";
		private double	_CommissionAgency  = 0.00;
		private double	_CommissionAgent   = 0.00;
		private double	_CommissionPremium = 0.00;
		private bool	_IsNewTransaction  = false;
		private bool    _Modify			   = true;
		private decimal _TotalAmount	   = 0;
		private int     _TotalCheck		   = 0;
		private bool	_MultiplePayment   = false;
		private string	_ReceiptNo		   = "";
		private string  _Name			   = "";
		private DateTime _ReceiptTime;
		//private string  _EnteredBy	       = "";
		private int _mode = (int) TaskControlMode.CLEAR;
		private string _OldPolicyType	   = "";
		private string _OldPolicyNo		   = "";
		private string _OldSufijo    	   = "";
		private string _AuthorizeUserName  = "";

		#endregion

		#region Properties

		public int TaskPaymentID
		{
			get
			{
				return this._TaskPaymentID;
			}
			set 
			{
				this._TaskPaymentID = value;
			}
		}
 
		public string AuthorizeUserName
		{
			get
			{
				return this._AuthorizeUserName;
			}
			set 
			{
				this._AuthorizeUserName = value;
			}
		}

		public string PolicyType		
		{
			get
			{
				return this._PolicyType;
			}
			set
			{
				this._PolicyType = value;
			}
		}

		public string OriginalPolicyNo		
		{
			get
			{
				return this._OriginalPolicyNo;
			}
			set
			{
				this._OriginalPolicyNo = value;
			}
		}

		public string PolicyNo		
		{
			get
			{
				return this._PolicyNo;
			}
			set
			{
				this._PolicyNo = value;
			}
		}

		public string Certificate		
		{
			get
			{
				return this._Certificate;
			}
			set
			{
				this._Certificate = value;
			}
		}

		public string Sufijo		
		{
			get
			{
				return this._Sufijo;
			}
			set
			{
				this._Sufijo = value;
			}
		}

		public string LoanNumber		
		{
			get
			{
				return this._LoanNo;
			}
			set
			{
				this._LoanNo = value;
			}
		}
		 
		public decimal PaymentAmount		
		{
			get
			{
				return this._PaymentAmount;
			}
			set
			{
				this._PaymentAmount = value;
			}
		}

		public string CheckNo		
		{
			get
			{
				return this._CheckNo;
			}
			set
			{
				this._CheckNo = value;
			}
		}

		public string PaymentDate		
		{
			get
			{
				return this._PaymentDate;
			}
			set
			{
				this._PaymentDate = value;
			}
		}

		public int CreditDebitID		
		{
			get
			{
				return this._CreditDebitID;
			}
			set
			{
				this._CreditDebitID = value;
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

		public string Comments1		
		{
			get
			{
				return this._Comments1;
			}
			set
			{
				this._Comments1 = value;
			}
		}

		public bool PaymentApplied		
		{
			get
			{
				return this._PaymentApplied;
			}
			set
			{
				this._PaymentApplied = value;
			}
		}

		public string AppliedDate		
		{
			get
			{
				return this._AppliedDate;
			}
			set
			{
				this._AppliedDate = value;
			}
		}

		public bool Licence		
		{
			get
			{
				return this._License;
			}
			set
			{
				this._License = value;
			}
		}

		public string DepositDate		
		{
			get
			{
				return this._DepositDate;
			}
			set
			{
				this._DepositDate = value;
			}
		}

		public string InvoiceNo		
		{
			get
			{
				return this._InvoiceNo;
			}
			set
			{
				this._InvoiceNo = value;
			}
		}

		public double CommissionAgency		
		{
			get
			{
				return this._CommissionAgency;
			}
			set
			{
				this._CommissionAgency = value;
			}
		}

		public double CommissionAgent		
		{
			get
			{
				return this._CommissionAgent;
			}
			set
			{
				this._CommissionAgent = value;
			}
		}

		public double CommissionPremium
		{
			get
			{
				return this._CommissionPremium;
			}
			set
			{
				this._CommissionPremium = value;
			}
		}

		public bool IsNewTransaction		
		{
			get
			{
				return this._IsNewTransaction;
			}
			set
			{
				this._IsNewTransaction = value;
			}
		}

		public decimal TotalAmount		
		{
			get
			{
				return this._TotalAmount;
			}
			set
			{
				this._TotalAmount = value;
			}
		}

		public int TotalCheck		
		{
			get
			{
				return this._TotalCheck;
			}
			set
			{
				this._TotalCheck = value;
			}
		}

		public bool MultiplePayment
		{
			get
			{
				return this._MultiplePayment;
			}
			set
			{
				this._MultiplePayment= value;                
			}
		}

		public string ReceiptNo
		{
			get
			{
				return this._ReceiptNo;
			}
			set
			{
				this._ReceiptNo= value;                
			}
		}

		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				this._Name= value;                
			}
		}

		public DateTime ReceiptTime
		{
			get
			{
				return this._ReceiptTime;
			}
			set
			{
				this._ReceiptTime= value;                
			}
		}

//		public string EnteredBy
//		{
//			get
//			{
//				return this._EnteredBy;
//			}
//			set
//			{
//				this._EnteredBy = value;                
//			}
//		}
		
		#endregion

		#region Public Methods

		 public override void Save(int UserID)
		{
			this._mode = (int) this.Mode;  // Se le asigna el mode de taskControl.

            //if (this._mode == 2)
            //{
            //    oldPayment = (Payments)Payments.GetTaskControlByTaskControlID(this.TaskControlID, UserID);
                
            //    base.Save(UserID);	             // Validate and Save TaskControl
            //    SaveTaskPayment(UserID);		 // Save TaskPayment

            //    SaveTaskPaymentToClose(UserID);  //Actualiza el record en TaskPayment si el pago es aplicado.
            //    SaveTaskControlToClose(UserID);  //Se vuelve a salvar para actualizar el record de taskPayment y cerrar el task (Close).

            //    this.IsNewTransaction = false;
            //}
            //else
            //{
                base.Validate();
                this.Validate();

                ApplyPayment(UserID);

                base.Save(UserID);	             // Validate and Save TaskControl
                SaveTaskPayment(UserID);		 // Save TaskPayment

                SaveTaskPaymentToClose(UserID);  //Actualiza el record en TaskPayment si el pago es aplicado.
                SaveTaskControlToClose(UserID);  //Se vuelve a salvar para actualizar el record de taskPayment y cerrar el task (Close).

                this.IsNewTransaction = false;
                this._mode = (int)TaskControlMode.UPDATE;
                this.Mode = (int)TaskControlMode.CLEAR;

                if (this.DepositDate != "")
                    SaveTaskPaymentDepositDate();
            //}

            this.Mode = (int)TaskControlMode.CLEAR;
		}

		private void ApplyPayment(int UserID)
		{	
			DataTable dt = Policy.GetPoliciesPayment(this.PolicyClassID,this.PolicyType.Trim(),this.PolicyNo.Trim(),this.Certificate.Trim(),this.Sufijo.Trim(),"",this.Bank.Trim(),UserID);

			if (dt.Rows.Count != 0)
			{
				TaskControl taskControl = Policy.GetTaskControlByTaskControlID((int) dt.Rows[0]["TaskControlID"], UserID);

                if (this.CreditDebitID == 1 && this.Mode != 2) //Solo aplica cuando es credito.
                {
                    //if ((double)((Policy)taskControl).PaymentsDetail.TotalPaid >= ((Policy)taskControl).TotalPremium + ((Policy)taskControl).Charge)
                    //{
                    //    throw new Exception("This Certificate is already paid.");
                    //}  
                    // Validación eliminada por el momento.  Petición hecha el 9/11/2014 para poder aplicar pagos en polizas ya pagadas, para crear overpayments.
                    // 

                    //if ((double)((Policy)taskControl).CancellationAmount > 0.00)
                    //{
                    //    throw new Exception("This Certificate is already cancelled.");
                    //}
                }

				PaymentPolicy pp = new PaymentPolicy();
				pp.InsertPartialPayment(taskControl, this);
				
				SaveTaskControlToClose(UserID,taskControl);  //Se vuelve a salvar para actualizar el record de la póliza y cierra el task (Close).
				SaveCommAgencyPolicy(UserID, taskControl);
			}
			else
			{
				throw new Exception("Can't found the policy. Please verify the policy number.");
			}
		}

		public override void Validate()
		{
			string errorMessage = String.Empty;
			bool found = false;

			if (this.PolicyClassID == 0 && found == false)
			{
				errorMessage = "The line of business is missing or wrong.";
				found = true;
			}

			if (this.PaymentDate == "" && found == false)
			{
				errorMessage = "Payment Date is missing or wrong.";
				found = true;
			}

			if (this.PaymentDate == "" && this.Licence == false && found == false)
			{
				errorMessage = "Payment Date is missing or wrong.";
				found = true;
			}
			else
			{
				if(this.PaymentDate == "" && this.Licence && this.CreditDebitID == 1 && found == false)
				{
					errorMessage = "Expiration Date is missing or wrong.";
					found = true;
				}
			}

			if (this.CheckNo == "" && found == false)
			{
				errorMessage = "Payment Check is missing or wrong.";
				found = true;
			}

//			if (this.PaymentAmount <= 0 && found == false)
//			{
//				errorMessage = "Payment Amount is missing or wrong.";
//				found = true;
//			}

			if (this.CreditDebitID == 0 && found == false)
			{
				errorMessage = "Credit / Debit is missing or wrong.";
				found = true;
			}

			if(DateTime.Parse(this.PaymentDate) > DateTime.Parse(DateTime.Now.ToShortDateString()) && this.Licence == false && found == false)
			{
				errorMessage = "The payment date must be equal or smallest than today.";
				found = true;
			}

			if (this.DepositDate != "" && this.Licence == false && found == false)
			{
				if(DateTime.Parse(this.PaymentDate) > DateTime.Parse(this.DepositDate) && found == false)
				{
					errorMessage = "The deposit date must be equal or great than payment date.";
					found = true;
				}
			}
				
			if (this.PaymentApplied == true && 
				(this.PolicyType != this._OldPolicyType || this.PolicyNo != this._OldPolicyNo)&& 
				found == false)
			{
				errorMessage = "This payment is already applied to this policy "+ this._OldPolicyType.Trim()+" "+this._OldPolicyNo.Trim()+" "+this._OldSufijo.Trim()+"\r\n"+
					"Please verify or must make another transaction.";
				found = true;
			}

			//throw the exception.
			if (errorMessage != String.Empty)
			{
				throw new Exception(errorMessage);
			}
		}

		public string AddReceiptNo()
		{
			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();
				int receipt = Executor.Insert("AddTaskPaymentReceipt",this.AddReceiptNoXml());
				this.ReceiptNo = receipt.ToString();
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error while trying to add the receipt number. "+xcp.Message,xcp);
			}
			return this.ReceiptNo;
		}

		public static DataTable GetTaskPaymentByCriteria(string taskStatusID, string paymentCheck, string Date, string DateType, string customerNo)
		{
			DataTable dt = GetTaskPaymentByCriteriaDB(taskStatusID, paymentCheck, Date, DateType, customerNo);
		          
			return dt;
		}

		public static Payments GetPayments(int taskControlID)
		{
			Payments payments = null;

			DataTable dt = GetTaskPaymentByTaskControlID(taskControlID);

			payments = new Payments();
			payments._dtPayments = dt;

			payments = FillProperties(payments);

			return payments;
		}

        private static DataTable GetPolicyForPaymentImportByCriteria(string policyYear, string policyType, string policyNo)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[3];

            DbRequestXmlCooker.AttachCookItem("PolicyYear",
                SqlDbType.Char, 4, policyYear.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyType",
                SqlDbType.Char, 2, policyType.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyNo",
                SqlDbType.VarChar, 10, policyNo.ToString(),
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

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

            DataTable dt = exec.GetQuery("GetPolicyForPaymentImport", xmlDoc);
            return dt;
        }

		public void GetTotalAmount(string CheckNo, string BegDate, string EndDate)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[3];

			DbRequestXmlCooker.AttachCookItem("CheckNo",
				SqlDbType.Char, 10, CheckNo.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("BegDate",
				SqlDbType.VarChar, 10, BegDate.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("EndDate",
				SqlDbType.VarChar, 10, EndDate.ToString(),
				ref cookItems);
			
			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
			XmlDocument xmlDoc;
			
			try
			{
				xmlDoc = DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}

			DataTable dt = null;

			try
			{
				dt = exec.GetQuery("GetTotalPaymentByCheckNo", xmlDoc);
			   
			}
			catch(Exception ex)
			{
				throw new Exception("Could not retrieve prospect by criteria.", ex);
			}			

			
			if (dt.Rows.Count !=0)
			{
				this.TotalAmount = (dt.Rows[0]["TotalAmount"]!=System.DBNull.Value)?
					((decimal) dt.Rows[0]["TotalAmount"]):0;
				this.TotalCheck =  (dt.Rows[0]["ListCount"]!=System.DBNull.Value)?
					((int) dt.Rows[0]["ListCount"]):0;
			}

		}

		public DataTable GetPaymentFileForBank(string Bank, string BegDate, string EndDate)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[3];

			DbRequestXmlCooker.AttachCookItem("Bank",
				SqlDbType.Char, 3, Bank.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("BegDate",
				SqlDbType.VarChar, 10, BegDate.ToString(),
				ref cookItems);
			
			
			DbRequestXmlCooker.AttachCookItem("EndDate",
				SqlDbType.VarChar, 10, EndDate.ToString(),
				ref cookItems);
			
			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
			XmlDocument xmlDoc;
			
			try
			{
				xmlDoc = DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}
			DataTable dt = null;
			try
			{
				 dt = exec.GetQuery("GetPaymentFileForBank", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not retrieve prospect by criteria.", ex);
			}			
		}

        public string GetTaskPaymentID(string policyNo, string paymentDate)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("PolicyNo",
                SqlDbType.Char, 11, policyNo.ToString().Trim(),
                ref cookItems);

            DateTime date2;
            date2 = DateTime.Parse(paymentDate + " 00:01:00 AM");

            DbRequestXmlCooker.AttachCookItem("PaymentDate",
                SqlDbType.DateTime, 0, date2.ToString(),
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
                dt = exec.GetQuery("GetTaskPaymentID", xmlDoc);
                
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve TaskPaymentID.", ex);
            }

            string taskPaymentID = String.Empty;

            if (dt.Rows.Count != 0)
            {
                taskPaymentID = ((int)dt.Rows[0]["TaskPaymentID"]).ToString();
                
            }
            return taskPaymentID;
        }

        public void UpdateCheckNoAndDepositDate(string oldCheckNo, string checkNo, string depositDate,
        string policyNo, string paymentDate, string namePayee)
        {
            string taskPaymentID = GetTaskPaymentID(policyNo, paymentDate);

            Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
            try
            {
                Executor.BeginTrans();
                Executor.Update("UpdateCheckNoAndDepositDate",
                this.GetUpdateCheckNoAndDepositDateXml(oldCheckNo, checkNo, depositDate, taskPaymentID, namePayee));
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error while trying to update the payment. " + xcp.Message, xcp);
            }
        }

        public void InsertPolicyPaymentImport(int paymentImportID, string paymentDate, string paymentCheck, string paymentAmount, string name, string depositDate, string policyType, string policyNo, string effectiveDate, string description, string status)
        {
            Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
            try
            {
                Executor.BeginTrans();
                Executor.Insert("AddPaymentImport",
                this.GetInsertPolicyPaymentImport(paymentImportID,paymentDate, paymentCheck, paymentAmount, name, depositDate, policyType, policyNo, effectiveDate, description, status));
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error while trying to update the payment. " + xcp.Message, xcp);
            }
        }

        public void InsertPolicyPaymentLoss(int paymentImportID, string paymentDate, string paymentCheck, string paymentAmount, string name, string depositDate, string policyType, string policyNo, string effectiveDate, string description, string status, bool disabled, int userID, string date)
        {
            Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
            try
            {
                Executor.BeginTrans();
                Executor.Insert("AddPaymentImportLoss",
                this.GetInsertPolicyPaymentLoss(paymentImportID, paymentDate, paymentCheck, paymentAmount, name, depositDate, policyType, policyNo, effectiveDate, description, status, disabled, userID, date));
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error while trying to save the payment. " + xcp.Message, xcp);
            }
        }

        public void UpdatePolicyPaymentLoss(int paymentImportID, bool disabled)
        {
            Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
            try
            {
                Executor.BeginTrans();
                Executor.Insert("UpdatePaymentImportLoss",
                this.GetUpdatePolicyPaymentImport(paymentImportID, disabled));
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error while trying to update the payment. " + xcp.Message, xcp);
            }
        }

        public void DeletePaymentImport()
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[0];

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception xcp)
            {
                throw new Exception("Unable to cook document. " + xcp.Message, xcp);
            }

            Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
            try
            {
                Executor.BeginTrans();
                Executor.Update("DeletePaymentImport", xmlDoc);
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error while trying to update the payment. " + xcp.Message, xcp);
            }
        }

        public static DataTable GetPaymentImport()
        {

            DataTable dt = GetPaymentImports();
            return dt;
        }

        public static DataTable GetPaymentImportLoss()
        {

            DataTable dt = GetPaymentImportLosses();
            return dt;
        }

        public static DataTable GetPaymentImportLossByCriteria(string paymentDate, string paymentCheck, string paymentAmount, string name, string depositDate, string policyType, string policyNo, string effectiveDate)
        {

            DataTable dt = GetPaymentImportLossesByCriteria(paymentDate, paymentCheck, paymentAmount, name, depositDate, policyType, policyNo, effectiveDate);
            return dt;
        }

        public static DataTable GetPolicyForPaymentImport(string policyType, string policyNo, string effectiveYear)
        {

            DataTable dt = GetPolicyForPaymentImports(policyType, policyNo, effectiveYear);
            return dt;
        }

		#endregion

        #region Private Methods

		private static DataTable  GetTaskPaymentByCriteriaDB(string taskStatusID, string paymentCheck, string Date, string DateType, string customerNo)

		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[5];

			DbRequestXmlCooker.AttachCookItem("TaskStatusID",
				SqlDbType.VarChar, 10, taskStatusID.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("PaymentCheck",
				SqlDbType.VarChar, 10, paymentCheck.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Date",
				SqlDbType.VarChar, 10, Date.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("DateType",
				SqlDbType.Char, 1, DateType.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("CustomerNo",
				SqlDbType.VarChar, 10, customerNo.ToString(),
				ref cookItems);
			
			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
			XmlDocument xmlDoc;
			
			try
			{
				xmlDoc = DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}
			DataTable dt = null;
			try
			{
				 dt = exec.GetQuery("GetTaskPaymentByCriteria", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not retrieve prospect by criteria.", ex);
			}			
		}

		private static DataTable GetTaskPaymentByTaskControlID(int taskControlID)
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
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}
			DataTable dt = null;
			try
			{
				 dt = exec.GetQuery("GetTaskPaymentByTaskControlID", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not retrieve prospect by criteria.", ex);
			}			
		}
		
		private void SaveTaskPayment(int UserID)
		{
			this._Modify = false;

			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();
				switch (this._mode)
				{
					case 1:  //ADD
						this.TaskPaymentID = 
							Executor.Insert("AddTaskPayment",this.GetInsertTaskPaymentXml());
						this.History(this._mode,UserID);
						break;

					case 3:  //DELETE
						Executor.Update("DeleteTaskPayment",this.GetDeleteTaskPaymentXml());
						this.History(this._mode,UserID);
						break;

					case 4:  //CLEAR						
						break;

					default: //UPDATE
						//this.History(this._mode,UserID);
						Executor.Update("UpdateTaskPayment",this.GetUpdateTaskPaymentXml());
						break;
				}
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error while trying to save the Payment. "+xcp.Message,xcp);
			}
		}

		public void DeleteTaskPayment(int UserID)
		{
			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();
				Executor.Update("DeleteTaskPayment",this.GetDeleteTaskPaymentXml());
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error while trying to save the Payment. "+xcp.Message,xcp);
			}
		}

		private void SaveTaskPaymentToClose(int UserID)
		{
			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();
				Executor.Update("UpdateSaveTaskPaymentToClose",this.SaveTaskPaymentToCloseXml());
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error while trying to update the Task Payment (Close Field). "+xcp.Message,xcp);
			}
		}

		private void SaveTaskControlToClose(int UserID)
		{
			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();
				Executor.Update("UpdateSaveTaskControlToClose",this.SaveTaskControlToCloseXml());
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error while trying to update the Task Payment (Close Field). "+xcp.Message,xcp);
			}
		}

		private void SaveTaskControlToClose(int UserID,TaskControl taskControl)
		{
			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();
				Executor.Update("UpdateSaveTaskControlToClose",this.SaveTaskControlToCloseXml(taskControl));
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error while trying to update the Task Payment (Close Field). "+xcp.Message,xcp);
			}
		}

		private void SaveCommAgencyPolicy(int UserID, TaskControl taskControl)
		{
			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();
				Executor.Update("UpdateCommAgencyPolicy",this.SaveCommAgencyPolicyXml(taskControl));
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error while trying to update the Policy. "+xcp.Message,xcp);
			}
		}

		private void SaveTaskPaymentDepositDate()
		{
			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();
				Executor.Update("UpdateTaskPaymentDepositDate",this.AddTaskPaymentDepositDateXml());
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error while trying to update the deposit date. "+xcp.Message,xcp);
			}
		}

		private XmlDocument GetDeleteTaskPaymentXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, this.TaskControlID.ToString(),
				ref cookItems);

			try
			{
				return DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}			
		}

		private XmlDocument GetUpdateTaskPaymentXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[27];
			
			DbRequestXmlCooker.AttachCookItem("TaskPaymentID",
				SqlDbType.Int, 0, this.TaskPaymentID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, this.TaskControlID.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("PolicyType",
				SqlDbType.Char, 3, this.PolicyType.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("OriginalPolicyNo",
				SqlDbType.Char, 11, this.OriginalPolicyNo.ToString(),
				ref cookItems);
						
			DbRequestXmlCooker.AttachCookItem("PolicyNo",
				SqlDbType.Char, 11, this.PolicyNo.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Certificate",
				SqlDbType.Char, 10, this.Certificate.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Sufijo",
				SqlDbType.Char, 2, this.Sufijo.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("LoanNo",
				SqlDbType.Char, 15, this.LoanNumber.ToString(),
				ref cookItems);			
			
			DbRequestXmlCooker.AttachCookItem("PaymentAmount",
				SqlDbType.Money, 0, this.PaymentAmount.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("CheckNo",
				SqlDbType.Char, 10, this.CheckNo.ToString(),
				ref cookItems);

			DateTime date = DateTime.Parse(this.PaymentDate+" 12:01:00 AM");

			DbRequestXmlCooker.AttachCookItem("PaymentDate",
				SqlDbType.DateTime, 8,date.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("CreditDebitID",
				SqlDbType.Int, 0, this.CreditDebitID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Comments",
				SqlDbType.VarChar, 500, this.Comments.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Comments1",
				SqlDbType.VarChar, 500, this.Comments1.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("PaymentApplied",
				SqlDbType.Bit, 0, this.PaymentApplied.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("AppliedDate",
				SqlDbType.DateTime, 0, this.AppliedDate.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("License",
				SqlDbType.Bit, 0, this.Licence.ToString(),
				ref cookItems);

			if (this.DepositDate !="")
			{
				DateTime date2;
				date2 = DateTime.Parse(this.DepositDate+" 12:01:00 AM");
				DbRequestXmlCooker.AttachCookItem("DepositDate",
					SqlDbType.DateTime, 0, date2.ToString(),
					ref cookItems);
			}
			else
			{
				DbRequestXmlCooker.AttachCookItem("DepositDate",
					SqlDbType.DateTime, 0, "",
					ref cookItems);
			}	
			
			DbRequestXmlCooker.AttachCookItem("InvoiceNo",
				SqlDbType.Char, 7, this.InvoiceNo.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("CommissionAgency",
				SqlDbType.Float, 0, this.CommissionAgency.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("CommissionAgent",
				SqlDbType.Float, 0, this.CommissionAgent.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("CommissionPremium",
				SqlDbType.Float, 0, this.CommissionPremium.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("IsNewTransaction",
				SqlDbType.Bit, 0, this.IsNewTransaction.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Name",
				SqlDbType.VarChar, 75, this.Name.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("EnteredBy",
				SqlDbType.Char, 30, this.EnteredBy.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("AuthorizeUserName",
				SqlDbType.Char, 40, this.AuthorizeUserName.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Modify",
				SqlDbType.Bit, 0, this._Modify.ToString(),
				ref cookItems);
			try
			{
				return DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}
		}

		private XmlDocument GetInsertTaskPaymentXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[26];
			
			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, this.TaskControlID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("PolicyType",
				SqlDbType.Char, 3, this.PolicyType.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("OriginalPolicyNo",
				SqlDbType.Char, 11, this.OriginalPolicyNo.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("PolicyNo",
				SqlDbType.Char, 11, this.PolicyNo.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Certificate",
				SqlDbType.Char, 10, this.Certificate.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Sufijo",
				SqlDbType.Char, 2, this.Sufijo.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("LoanNo",
				SqlDbType.Char, 15, this.LoanNumber.ToString(),
				ref cookItems);
			

			if (this.CreditDebitID == 2) // Debit
			{
				this.PaymentAmount = Math.Abs((decimal)this.PaymentAmount) * -1;
			}

			DbRequestXmlCooker.AttachCookItem("PaymentAmount",
				SqlDbType.Money, 0, this.PaymentAmount.ToString(),
				ref cookItems);
			

			DbRequestXmlCooker.AttachCookItem("CheckNo",
				SqlDbType.Char, 10, this.CheckNo.ToString(),
				ref cookItems);
			
			DateTime date = DateTime.Parse(this.PaymentDate+" 12:01:00 AM");

			DbRequestXmlCooker.AttachCookItem("PaymentDate",
				SqlDbType.DateTime, 8,date.ToString(),
				ref cookItems);
		
			DbRequestXmlCooker.AttachCookItem("CreditDebitID",
				SqlDbType.Int, 0, this.CreditDebitID.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Comments",
				SqlDbType.VarChar, 500, this.Comments.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Comments1",
				SqlDbType.VarChar, 500, this.Comments1.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("PaymentApplied",
				SqlDbType.Bit, 0, this.PaymentApplied.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("AppliedDate",
				SqlDbType.DateTime, 0, this.AppliedDate.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("License",
				SqlDbType.Bit, 0, this.Licence.ToString(),
				ref cookItems);
						
			if (this.DepositDate !="")
			{
				DateTime date2;
				date2 = DateTime.Parse(this.DepositDate+" 12:01:00 AM");
				DbRequestXmlCooker.AttachCookItem("DepositDate",
					SqlDbType.DateTime, 0, date2.ToString(),
					ref cookItems);
			}
			else
			{
				DbRequestXmlCooker.AttachCookItem("DepositDate",
					SqlDbType.DateTime, 0, "",
					ref cookItems);
			}	
			
			DbRequestXmlCooker.AttachCookItem("InvoiceNo",
				SqlDbType.Char, 7, this.InvoiceNo.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("CommissionAgency",
				SqlDbType.Float, 0, this.CommissionAgency.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("CommissionAgent",
				SqlDbType.Float, 0, this.CommissionAgent.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("CommissionPremium",
				SqlDbType.Float, 0, this.CommissionPremium.ToString(),
				ref cookItems);
			
			if (this._mode ==1)
				this.IsNewTransaction = true;
		
			DbRequestXmlCooker.AttachCookItem("IsNewTransaction",
				SqlDbType.Bit, 0, IsNewTransaction.ToString(),
				ref cookItems);
					
			DbRequestXmlCooker.AttachCookItem("Name",
				SqlDbType.VarChar, 75, this.Name.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("EnteredBy",
				SqlDbType.Char, 30, this.EnteredBy.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("AuthorizeUserName",
				SqlDbType.Char, 40, this.AuthorizeUserName.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Modify",
				SqlDbType.Bit, 0, this._Modify.ToString(),
				ref cookItems);

			try
			{
				return DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}
		}

		private XmlDocument SaveTaskControlToCloseXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[3];
			
			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, this.TaskControlID.ToString(),
				ref cookItems);
			
			this.TaskStatusID = 2; //Close
			DbRequestXmlCooker.AttachCookItem("TaskStatusID",
				SqlDbType.Int, 0, this.TaskStatusID.ToString(),
				ref cookItems);			

			this.CloseDate = DateTime.Now.ToShortDateString();
			DateTime date2;
			date2 = DateTime.Parse(this.CloseDate+" 12:01:00 AM");
			DbRequestXmlCooker.AttachCookItem("CloseDate",
				SqlDbType.DateTime, 0, date2.ToString(),
				ref cookItems);

			try
			{
				return DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}
		}

		private XmlDocument SaveTaskControlToCloseXml(TaskControl taskControl)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[3];
			
			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, taskControl.TaskControlID.ToString(),
				ref cookItems);
			
			this.TaskStatusID = 2; //Close

			DbRequestXmlCooker.AttachCookItem("TaskStatusID",
				SqlDbType.Int, 0, this.TaskStatusID.ToString(),
				ref cookItems);			

			this.CloseDate = DateTime.Now.ToShortDateString();
			DateTime date2;
			date2 = DateTime.Parse(this.CloseDate+" 12:01:00 AM");
			DbRequestXmlCooker.AttachCookItem("CloseDate",
				SqlDbType.DateTime, 0, date2.ToString(),
				ref cookItems);

			try
			{
				return DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}
		}

		private XmlDocument SaveTaskPaymentToCloseXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[5];
			
			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, this.TaskControlID.ToString(),
				ref cookItems);
			
			this.PaymentApplied = true;
			DbRequestXmlCooker.AttachCookItem("PaymentApplied",
				SqlDbType.Bit, 0, this.PaymentApplied.ToString(),
				ref cookItems);			

			this.AppliedDate = DateTime.Now.ToShortDateString();
				DateTime date2;
				date2 = DateTime.Parse(this.AppliedDate+" 12:01:00 AM");
				DbRequestXmlCooker.AttachCookItem("AppliedDate",
					SqlDbType.DateTime, 0, date2.ToString(),
					ref cookItems);
				
			this.IsNewTransaction = false;
			DbRequestXmlCooker.AttachCookItem("IsNewTransaction",
				SqlDbType.Bit, 0, this.IsNewTransaction.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Comments",
				SqlDbType.VarChar, 500, this.Comments.ToString(),
				ref cookItems);
			
			try
			{
				return DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}
		}

		private XmlDocument SaveCommAgencyPolicyXml(TaskControl taskControl)
		{
			Policy pol = (Policy) taskControl;

			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[5];
			
			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, pol.TaskControlID.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("CommissionAgency",
				SqlDbType.Float, 0, pol.CommissionAgency.ToString(),
				ref cookItems);		
			
			DateTime date2;
			date2 = DateTime.Parse(pol.CommissionDate+" 12:01:00 AM");
			DbRequestXmlCooker.AttachCookItem("CommissionDate",
				SqlDbType.DateTime, 0, date2.ToString(),
				ref cookItems);

			if (this.CreditDebitID == 2) // Debit
			{
				this.PaymentAmount = Math.Abs((decimal)this.PaymentAmount) * -1;
			}
			
			double paidAmt = pol.PaidAmount + double.Parse(this.PaymentAmount.ToString());

			DbRequestXmlCooker.AttachCookItem("PaidAmount",
				SqlDbType.Float, 0, paidAmt.ToString(),
				ref cookItems);

			date2 = DateTime.Parse(pol.PaidDate+" 12:01:00 AM");
			DbRequestXmlCooker.AttachCookItem("PaidDate",
				SqlDbType.DateTime, 0, date2.ToString(),
				ref cookItems);

			try
			{
				return DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}
		}

        private XmlDocument GetUpdateCheckNoAndDepositDateXml(string oldCheckNo, string checkNo, string depositDate,
            string taskPaymentID, string namePayee)
        {
            
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[6];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, TaskControlID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CheckNo",
                SqlDbType.Char, 10, checkNo.Trim(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("OldCheckNo",
                SqlDbType.Char, 10, oldCheckNo.Trim(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("TaskPaymentID",
                SqlDbType.Int, 0, taskPaymentID.Trim(),
                ref cookItems);

            DateTime date2;
            date2 = DateTime.Parse(depositDate + " 00:01:00 AM");

            DbRequestXmlCooker.AttachCookItem("DepositDate",
                SqlDbType.DateTime, 0, date2.ToString(),
                ref cookItems);
            DbRequestXmlCooker.AttachCookItem("NamePayee",
               SqlDbType.VarChar, 75,  namePayee.Trim(),
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

        private static DataTable GetPolicyForPaymentImports(string policyType, string policyNo, string effectiveYear)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[3];

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            DbRequestXmlCooker.AttachCookItem("PolicyType",
                SqlDbType.Char, 3, policyType.Trim(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyNo",
               SqlDbType.VarChar, 10, policyNo.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyYear",
                SqlDbType.Char, 4, effectiveYear.Trim(),
                ref cookItems);

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
                dt = exec.GetQuery("GetPolicyForPaymentImport", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve imported payments.", ex);
            }
        }

        private static DataTable GetPaymentImports()
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[0];

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
                dt = exec.GetQuery("GetPaymentImport", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve imported payments.", ex);
            }
        }

        private static DataTable GetPaymentImportLosses()
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[0];

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
                dt = exec.GetQuery("GetPaymentImportLoss", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve imported payments.", ex);
            }
        }

        private static DataTable GetPaymentImportLossesByCriteria(string paymentDate, string paymentCheck, string paymentAmount, string name, string depositDate, string policyType, string policyNo, string effectiveDate)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[8];

            DbRequestXmlCooker.AttachCookItem("PaymentDate",
                SqlDbType.VarChar, 15, paymentDate.Trim(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PaymentCheck",
               SqlDbType.VarChar, 50, paymentCheck.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PaymentAmount",
                SqlDbType.VarChar, 50, paymentAmount.Trim(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Name",
               SqlDbType.VarChar, 100, name.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("DepositDate",
               SqlDbType.VarChar, 10, depositDate.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyType",
                SqlDbType.Char, 3, policyType.Trim(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyNo",
               SqlDbType.VarChar, 10, policyNo.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EffectiveYear",
                SqlDbType.Char, 4, effectiveDate.Trim(),
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
                dt = exec.GetQuery("GetPaymentImportLossByCriteria", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve imported payments.", ex);
            }
        }

        private XmlDocument GetInsertPolicyPaymentImport(int paymentImportID, string paymentDate, string paymentCheck, string paymentAmount, string name, string depositDate, string policyType, string policyNo, string effectiveDate, string description, string status)
        {

            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[11];

            DbRequestXmlCooker.AttachCookItem("PaymentImportID",
                SqlDbType.Int, 0, paymentImportID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PaymentDate",
                SqlDbType.VarChar, 15, paymentDate.Trim(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PaymentCheck",
               SqlDbType.VarChar, 50, paymentCheck.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PaymentAmount",
                SqlDbType.VarChar, 50, paymentAmount.Trim(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Name",
               SqlDbType.VarChar, 100, name.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("DepositDate",
               SqlDbType.VarChar, 10, depositDate.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyType",
                SqlDbType.Char, 3, policyType.Trim(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyNo",
               SqlDbType.VarChar, 10, policyNo.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EffectiveYear",
                SqlDbType.Char, 4, effectiveDate.Trim(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Description",
               SqlDbType.VarChar, 500, description.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Status",
                SqlDbType.Char, 1, status.Trim(),
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

        private XmlDocument GetInsertPolicyPaymentLoss(int paymentImportID, string paymentDate, string paymentCheck, string paymentAmount, string name, string depositDate, string policyType, string policyNo, string effectiveDate, string description, string status, bool disabled, int userID, string date)
        {

            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[14];

            DbRequestXmlCooker.AttachCookItem("PaymentImportID",
                SqlDbType.Int, 0, paymentImportID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PaymentDate",
                SqlDbType.VarChar, 15, paymentDate.Trim(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PaymentCheck",
               SqlDbType.VarChar, 50, paymentCheck.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PaymentAmount",
                SqlDbType.VarChar, 50, paymentAmount.Trim(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Name",
               SqlDbType.VarChar, 100, name.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("DepositDate",
               SqlDbType.VarChar, 10, depositDate.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyType",
                SqlDbType.Char, 3, policyType.Trim(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyNo",
               SqlDbType.VarChar, 10, policyNo.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EffectiveYear",
                SqlDbType.Char, 4, effectiveDate.Trim(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Description",
               SqlDbType.VarChar, 500, description.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Status",
                SqlDbType.Char, 1, status.Trim(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Disabled",
                SqlDbType.Bit, 0, disabled.ToString().Trim(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("UserID",
                SqlDbType.Int, 0, userID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Date",
               SqlDbType.VarChar, 15, date.ToString(),
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

        private XmlDocument GetUpdatePolicyPaymentImport(int paymentImportID, bool disabled)
        {

            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("PaymentImportID",
                SqlDbType.Int, 0, paymentImportID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Disabled",
                SqlDbType.Bit, 0, disabled.ToString().Trim(),
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

		private XmlDocument AddReceiptNoXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[2];
			
			DbRequestXmlCooker.AttachCookItem("TaskPaymentID",
				SqlDbType.Int, 0, this.TaskPaymentID.ToString(),
				ref cookItems);
		
			DbRequestXmlCooker.AttachCookItem("ReceiptTime",
				SqlDbType.DateTime, 8, DateTime.Now.ToString(),
				ref cookItems);

			try
			{
				return DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}
		}

		private XmlDocument AddTaskPaymentDepositDateXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[3];
			
			DbRequestXmlCooker.AttachCookItem("CheckNo",
				SqlDbType.Char, 10, this.CheckNo.ToString(),
				ref cookItems);
		
			DbRequestXmlCooker.AttachCookItem("PaymentDate",
				SqlDbType.DateTime, 8, this.PaymentDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("DepositDate",
				SqlDbType.DateTime, 8, this.DepositDate.ToString(),
				ref cookItems);

			try
			{
				return DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}
		}

		private static string GetReceiptNo(int taskPaymentID)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("TaskPaymentID",
				SqlDbType.Int, 0, taskPaymentID.ToString(),
				ref cookItems);

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
			XmlDocument xmlDoc;
			
			try
			{
				xmlDoc = DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}
			DataTable dt = null;
			string receipt = "";

			try
			{
				dt = exec.GetQuery("GetTaskPaymentReceiptByTaskPaymentID", xmlDoc);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not retrieve the receipt number.", ex);
			}			

			if (dt.Rows.Count != 0)
			{
				receipt = ((int) dt.Rows[0]["TaskPaymentReceiptID"]).ToString();

			}	
			return receipt;
		}

		private static Payments FillProperties(Payments payment)
		{
			payment.TaskPaymentID     = (int)  payment._dtPayments.Rows[0]["TaskPaymentID"];
			payment.PolicyType		  = payment._dtPayments.Rows[0]["PolicyType"].ToString();
			payment.OriginalPolicyNo  = payment._dtPayments.Rows[0]["OriginalPolicyNo"].ToString();
			payment.PolicyNo		  = payment._dtPayments.Rows[0]["PolicyNo"].ToString();
			payment.Certificate		  = payment._dtPayments.Rows[0]["Certificate"].ToString();
			payment.Sufijo			  = payment._dtPayments.Rows[0]["Sufijo"].ToString();
			payment.LoanNumber		  = payment._dtPayments.Rows[0]["LoanNo"].ToString();
			payment.PaymentAmount	  = (payment._dtPayments.Rows[0]["PaymentAmount"]!=System.DBNull.Value)? ((decimal) payment._dtPayments.Rows[0]["PaymentAmount"]):0;
			payment.CheckNo			  = payment._dtPayments.Rows[0]["CheckNo"].ToString();
			payment.PaymentDate		  = (payment._dtPayments.Rows[0]["PaymentDate"]!=System.DBNull.Value)? ((DateTime) payment._dtPayments.Rows[0]["PaymentDate"]).ToShortDateString():"";
			payment.CreditDebitID	  = (int) payment._dtPayments.Rows[0]["CreditDebitID"];
			payment.Comments		  = payment._dtPayments.Rows[0]["Comments"].ToString();
			payment.Comments1		  = payment._dtPayments.Rows[0]["Comments1"].ToString();
			payment.PaymentApplied    = (bool) payment._dtPayments.Rows[0]["PaymentApplied"];
			payment.AppliedDate		  = (payment._dtPayments.Rows[0]["AppliedDate"]!=System.DBNull.Value)? ((DateTime) payment._dtPayments.Rows[0]["AppliedDate"]).ToShortDateString():"";
			payment.Licence			  = (payment._dtPayments.Rows[0]["License"]!=System.DBNull.Value)? ((bool) payment._dtPayments.Rows[0]["License"]):false;
			payment.DepositDate		  = (payment._dtPayments.Rows[0]["DepositDate"]!=System.DBNull.Value)? ((DateTime) payment._dtPayments.Rows[0]["DepositDate"]).ToShortDateString():"";
			payment.InvoiceNo		  = payment._dtPayments.Rows[0]["InvoiceNo"].ToString();
			payment.CommissionAgency  = (payment._dtPayments.Rows[0]["CommissionAgency"]!=System.DBNull.Value)? ((double) payment._dtPayments.Rows[0]["CommissionAgency"]):0.00;
			payment.CommissionAgent	  = (payment._dtPayments.Rows[0]["CommissionAgent"]!=System.DBNull.Value)? ((double) payment._dtPayments.Rows[0]["CommissionAgent"]):0.00;
			payment.CommissionPremium = (payment._dtPayments.Rows[0]["CommissionPremium"]!=System.DBNull.Value)? ((double) payment._dtPayments.Rows[0]["CommissionPremium"]):0.00;
			payment.IsNewTransaction  = (payment._dtPayments.Rows[0]["IsNewTransaction"] !=System.DBNull.Value)? ((bool) payment._dtPayments.Rows[0]["IsNewTransaction"]):false;
			payment.ReceiptNo		  = GetReceiptNo(payment.TaskPaymentID);
			payment.Name			  = payment._dtPayments.Rows[0]["Name"].ToString();
			payment.EnteredBy		  = payment._dtPayments.Rows[0]["EnteredBy"].ToString();
			payment.AuthorizeUserName = (payment._dtPayments.Rows[0]["AuthorizeUserName"] !=System.DBNull.Value)? payment._dtPayments.Rows[0]["AuthorizeUserName"].ToString():"";

			payment._OldPolicyType	  = payment.PolicyType;
			payment._OldPolicyNo	  = payment.PolicyNo;
			payment._OldSufijo		  = payment.Sufijo;

			return payment;
		}

		#region History

		private void History(int mode, int userID)
		{
			Audit.History history = new Audit.History();
			
			if(_mode == 2)
			{
                //Payment oldPayment = null;
			    
             //Campos de TaskControl
                history.BuildNotesForHistory("TaskControlTypeID",
                    LookupTables.LookupTables.GetDescription("TaskControlType",oldPayment.TaskControlTypeID.ToString()),
                    LookupTables.LookupTables.GetDescription("TaskControlType",this.TaskControlTypeID.ToString()),
                    mode);
                history.BuildNotesForHistory("TaskStatusID",
                    LookupTables.LookupTables.GetDescription("TaskStatus",oldPayment.TaskStatusID.ToString()),
                    LookupTables.LookupTables.GetDescription("TaskStatus",this.TaskStatusID.ToString()),
                    mode);	
                history.BuildNotesForHistory("ProspectID",oldPayment.ProspectID.ToString(),this.ProspectID.ToString(),mode);							
                history.BuildNotesForHistory("CustomerNo",oldPayment.CustomerNo,this.CustomerNo,mode);
                history.BuildNotesForHistory("PolicyID",oldPayment.PolicyID.ToString(),this.PolicyID.ToString(),mode);							
                history.BuildNotesForHistory("PolicyClassID",
                    LookupTables.LookupTables.GetDescription("PolicyClass",oldPayment.PolicyClassID.ToString()),
                    LookupTables.LookupTables.GetDescription("PolicyClass",this.PolicyClassID.ToString()),
                    mode);	
                history.BuildNotesForHistory("Agency",oldPayment.Agent,this.Agent,mode);
                history.BuildNotesForHistory("Agent",oldPayment.Agent,this.Agent,mode);
                history.BuildNotesForHistory("Bank",
                    LookupTables.LookupTables.GetDescription("Bank",oldPayment.Bank.ToString()),
                    LookupTables.LookupTables.GetDescription("Bank",this.Bank.ToString()),
                    mode);	
                history.BuildNotesForHistory("InsuranceCompany",oldPayment.InsuranceCompany,this.InsuranceCompany,mode);
                history.BuildNotesForHistory("Dealer",oldPayment.Dealer,this.Dealer,mode);
                history.BuildNotesForHistory("CompanyDealer",
                    LookupTables.LookupTables.GetDescription("CompanyDealer",oldPayment.CompanyDealer.ToString()),
                    LookupTables.LookupTables.GetDescription("CompanyDealer",this.CompanyDealer.ToString()),
                    mode);	
                //history.BuildNotesForHistory("EntryDate",oldPayment.EntryDate.t,this.EntryDate,mode);
                history.BuildNotesForHistory("CloseDate",oldPayment.CloseDate,this.CloseDate,mode);
                history.BuildNotesForHistory("EnteredBy",oldPayment.EnteredBy,this.EnteredBy,mode);
            // Terminan Campos TaskControl

                history.BuildNotesForHistory("AppliedDate",oldPayment.AppliedDate,this.AppliedDate,mode);
				
                history.BuildNotesForHistory("Certificate",oldPayment.Certificate,this.Certificate,mode);
                history.BuildNotesForHistory("CheckNo",oldPayment.CheckNo,this.CheckNo,mode);
                history.BuildNotesForHistory("Comments1",oldPayment.Comments1.ToString(),this.Comments1.ToString(),mode);
                history.BuildNotesForHistory("CommissionAgency",oldPayment.CommissionAgency.ToString(),this.CommissionAgency.ToString(),mode);
                history.BuildNotesForHistory("CommissionAgent",oldPayment.CommissionAgent.ToString(),this.CommissionAgent.ToString(),mode);
                history.BuildNotesForHistory("CommissionPremium",oldPayment.CommissionPremium.ToString(),this.CommissionPremium.ToString(),mode);
                history.BuildNotesForHistory("CreditDebitID",oldPayment.CreditDebitID.ToString(),this.CreditDebitID.ToString(),mode);

                history.BuildNotesForHistory("DepositDate",oldPayment.DepositDate,this.DepositDate,mode);

                history.BuildNotesForHistory("InvoiceNo",oldPayment.InvoiceNo,this.InvoiceNo,mode);
                history.BuildNotesForHistory("IsNewTransaction",oldPayment.IsNewTransaction.ToString(),this.IsNewTransaction.ToString(),mode);
                history.BuildNotesForHistory("Licence",oldPayment.Licence.ToString(),this.Licence.ToString(),mode);
                history.BuildNotesForHistory("LoanNumber",oldPayment.LoanNumber,this.LoanNumber,mode);
                history.BuildNotesForHistory("OriginalPolicyNo",oldPayment.OriginalPolicyNo,this.OriginalPolicyNo,mode);
                history.BuildNotesForHistory("PaymentAmount",oldPayment.PaymentAmount.ToString("###,###.00"),this.PaymentAmount.ToString("###,###.00"),mode);
                history.BuildNotesForHistory("PaymentApplied",oldPayment.PaymentApplied.ToString(),this.PaymentApplied.ToString(),mode);

                history.BuildNotesForHistory("PaymentDate",oldPayment.PaymentDate,this.PaymentDate,mode);

                history.BuildNotesForHistory("PolicyNo",oldPayment.PolicyNo,this.PolicyNo,mode);
                history.BuildNotesForHistory("PolicyType",oldPayment.PolicyType,this.PolicyType,mode);
                history.BuildNotesForHistory("Sufijo",oldPayment.Sufijo,this.Sufijo,mode);
                history.BuildNotesForHistory("TaskPaymentID",oldPayment.TaskPaymentID.ToString(),this.TaskPaymentID.ToString(),mode);

				history.Actions = "EDIT";
			}
			else  //ADD & DELETE
			{
				history.BuildNotesForHistory("TaskControlID.","",this.TaskControlID.ToString(),mode);
				history.Actions = "ADD";
			}

			history.KeyID = this.TaskControlID.ToString();
			history.Subject = "PAYMENTS";			
			history.UsersID =  userID;
			history.GetSaveHistory();
		}


		private object SafeConvertToDateTime(string StringObject)
		{
			if(StringObject != string.Empty)
			{
				try	{return DateTime.Parse(StringObject);}
				catch{/*Write to error logging sub-system.*/}
			}
			return StringObject;
		}

		#endregion

		#endregion
	}
}
