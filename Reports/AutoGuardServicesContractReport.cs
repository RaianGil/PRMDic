using System;
using System.Data;
using System.Xml;
using Baldrich.DBRequest;
//using Baldrich.XmlCooker;
using EPolicy.XmlCooker;


namespace EPolicy2.Reports
{
	/// <summary>
	/// Summary description for AutoGuardServicesContract.
	/// </summary>
	public class AutoGuardServicesContractReport
	{
		public AutoGuardServicesContractReport()
		{
		
		}

        public DataTable AutoGuardPremiumWritten(string BegDate, string EndDate, string agency,
            string dateType, string policyType, int UserID, string filter, string groupID)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[8];

			DbRequestXmlCooker.AttachCookItem("BegDate",
				SqlDbType.VarChar, 10, BegDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("EndDate",
				SqlDbType.VarChar, 10, EndDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Agency",
				SqlDbType.Char, 3, agency.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("DateType",
				SqlDbType.Char, 1, dateType.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("UserID",
				SqlDbType.Int, 0, UserID.ToString(),
				ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Filter",
                SqlDbType.Char, 3, filter.ToString(),
                ref cookItems);
            
            DbRequestXmlCooker.AttachCookItem("PolicyType",
                SqlDbType.Char, 3, policyType.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("GroupID",
                SqlDbType.Char, 3, groupID.ToString(),
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
				dt = exec.GetQuery("GetAutoGuardPremiumWritten", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not validated the Report.", ex);
			}
		}

        public DataTable GetAutoGuardPremiumWrittenEndorsement(string BegDate, string EndDate, string agency,
            string dateType, string policyType, int UserID, string filter, string groupID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[8];

            DbRequestXmlCooker.AttachCookItem("BegDate",
                SqlDbType.VarChar, 10, BegDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndDate",
                SqlDbType.VarChar, 10, EndDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Agency",
                SqlDbType.Char, 3, agency.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("DateType",
                SqlDbType.Char, 1, dateType.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("UserID",
                SqlDbType.Int, 0, UserID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Filter",
                SqlDbType.Char, 3, filter.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyType",
                SqlDbType.Char, 3, policyType.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("GroupID",
                SqlDbType.Char, 3, groupID.ToString(),
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
                dt = exec.GetQuery("GetAutoGuardPremiumWrittenEndorsement", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not validated the Report.", ex);
            }
        }

        public DataTable AutoGuardPremiumWrittenToDealer(string BegDate, string EndDate, string companyDealer, string dateType, string policyClass, int UserID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[6];

            DbRequestXmlCooker.AttachCookItem("BegDate",
                SqlDbType.VarChar, 10, BegDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndDate",
                SqlDbType.VarChar, 10, EndDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CompanyDealerID",
                SqlDbType.Char, 3, companyDealer.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("DateType",
                SqlDbType.Char, 1, dateType.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyClassID",
                SqlDbType.Char, 4, policyClass.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("UserID",
                SqlDbType.Int, 0, UserID.ToString(),
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
                dt = exec.GetQuery("GetAutoGuardPremiumWrittenToDealer", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not validated the Report.", ex);
            }
        }

        public DataTable AutoGuardPremiumRenewal(string BegDate, string EndDate, string agency, string policyType, int UserID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[5];

            DbRequestXmlCooker.AttachCookItem("BegDate",
                SqlDbType.VarChar, 10, BegDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndDate",
                SqlDbType.VarChar, 10, EndDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Agency",
                SqlDbType.Char, 3, agency.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyType",
                SqlDbType.Char, 3, policyType.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("UserID",
                SqlDbType.Int, 0, UserID.ToString(),
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
                dt = exec.GetQuery("GetAutoGuardPremiumRenewal", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not validated the Report.", ex);
            }
        }

		public DataTable AutoGuardCertificatePaid(string BegDate, string EndDate, string agency)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[3];

			DbRequestXmlCooker.AttachCookItem("BegDate",
				SqlDbType.VarChar, 10, BegDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("EndDate",
				SqlDbType.VarChar, 10, EndDate.ToString(),
				ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Agency",
                SqlDbType.Char, 3, agency.ToString(),
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
				dt = exec.GetQuery("GetAutoGuardCertificatePaid", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not validated the Auto Guard Report.", ex);
			}
		}

		public DataTable AutoGuardCertificateOutstanding(string EndDate, int TaskControlTypeID, string agency, bool partialPayment, int reportType)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[5];

			DbRequestXmlCooker.AttachCookItem("EndDate",
				SqlDbType.VarChar, 10, EndDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("TaskControlTypeID",
				SqlDbType.Int, 0, TaskControlTypeID.ToString(),
				ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Agency",
                SqlDbType.Char, 3, agency.ToString(),
				ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PartialPayment",
                SqlDbType.Bit, 0, partialPayment.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("ReportType",
                SqlDbType.Int, 0, reportType.ToString(),
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
				dt = exec.GetQuery("GetAutoGuardCertificateOutstanding", xmlDoc);

				if (dt.Rows.Count !=0)
				{
					dt = ApplyAging(dt,EndDate,true);
				}

				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not validated the Auto Guard Report.", ex);
			}
		}

		public DataTable CancellationNotice()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DateTime date2;
			string date3 = DateTime.Now.ToShortDateString().Trim();

			date2 = DateTime.Parse(date3+" 12:01:00 AM");
			DbRequestXmlCooker.AttachCookItem("Today",
				SqlDbType.VarChar, 10, date2.ToString(),
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
				dt = exec.GetQuery("GetAutoGuardCancellationNotice", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not validated the Auto Guard Report.", ex);
			}
		}


		private DataTable ApplyAging(DataTable dt, string EndDate, bool isCertificate)
		{   
			DataColumn dc = new DataColumn();
			dc.ColumnName = "Days30";
			dc.DataType = System.Type.GetType("System.Double");
			dt.Columns.Add(dc);
			dt.AcceptChanges();

			dc = new DataColumn();
			dc.ColumnName = "Days60";
			dc.DataType = System.Type.GetType("System.Double");
			dt.Columns.Add(dc);
			dt.AcceptChanges();		

			dc = new DataColumn();
			dc.ColumnName = "Days90";
			dc.DataType = System.Type.GetType("System.Double");
			dt.Columns.Add(dc);
			dt.AcceptChanges();	

			dc = new DataColumn();
			dc.ColumnName = "Over90";
			dc.DataType = System.Type.GetType("System.Double");
			dt.Columns.Add(dc);
			dt.AcceptChanges();	

			System.TimeSpan  mdays;

			for (int i = 0; i<=dt.Rows.Count - 1; i++)
			{
				DateTime dtime = DateTime.Parse(EndDate);

				DateTime dtime2;

				if (isCertificate)
				{
					dtime2 =((DateTime) dt.Rows[i]["EffectiveDate"]);
				}
				else
				{
					dtime2 =((DateTime) dt.Rows[i]["AssingDate"]);
				}

				mdays = (dtime).Subtract(dtime2);
				int mdays1 = 0;
				if (dtime == dtime2)
					mdays1 = mdays.Days;
				else
					mdays1 = mdays.Days + 1;
				
				double mamt = 0.00;

				if (isCertificate)
				{
					mamt = (double)dt.Rows[i]["TotalPremium"]+(
						double)dt.Rows[i]["Charge"] - (double) dt.Rows[i]["PaidAmount"];
				}
				else
				{
					//mamt = (decimal)dt.Rows[i]["DealerCost"].ToString() - (float) dt.Rows[i]["PaymentAmount"].ToString();
					
					string Sdealer = dt.Rows[i]["DealerCost"].ToString();      
					string SPayment = "0.00";    //dt.Rows[i]["PaymentAmount"].ToString();
					if(SPayment == "")
					{
						SPayment = "0.00";
					}
					
					float dealer = (float.Parse(Sdealer));      
					float Payment = (float.Parse(SPayment));
					
					mamt = dealer - Payment;
				}

				if (mdays1 < 31)
					dt.Rows[i]["Days30"] = mamt;
				else
					if (mdays1 < 61)
					dt.Rows[i]["Days60"] = mamt;
				else
					if (mdays1 < 91)
					dt.Rows[i]["Days90"] = mamt;
				else
					if (mdays1 > 90)
					dt.Rows[i]["Over90"] = mamt;
			}

			return dt;
		}


		public DataTable AutoGuardFollowUpCancellation(string BegDate)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("BegDate",
				SqlDbType.VarChar, 10, BegDate.ToString(),
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
				dt = exec.GetQuery("GetAutoGuardFollowUpCancellation", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not validated the Auto Guard Report.", ex);
			}
		}

		public DataTable AutoGuardTodayPayments(string BegDate)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("BegDate",
				SqlDbType.VarChar, 10, BegDate.ToString(),
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
				dt = exec.GetQuery("GetAutoGuardTodayPayments", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not validated the Auto Guard Report.", ex);
			}
		}


		public DataTable AutoGuardCertificatePaidAndEffectivity(string BegDate, string EndDate, string companyDealer,string mcancDate)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[4];

			DbRequestXmlCooker.AttachCookItem("BegDate",
				SqlDbType.VarChar, 10, BegDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("EndDate",
				SqlDbType.VarChar, 10, EndDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("CompanyDealerID",
				SqlDbType.Char, 3, companyDealer.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("mcancDate",
				SqlDbType.VarChar, 10, mcancDate.ToString(),
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
				dt = exec.GetQuery("GetAutoGuardCertificatePaidAndEffetivity", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not validated the Auto Guard Report.", ex);
			}
		}

		public DataTable AutoGuardPremiumAndCommissionEarned(string BegDate, string EndDate, string cancDate, string policyType)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[4];

			DbRequestXmlCooker.AttachCookItem("BegDate",
				SqlDbType.VarChar, 10, BegDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("EndDate",
				SqlDbType.VarChar, 10, EndDate.ToString(),
				ref cookItems);

            //DbRequestXmlCooker.AttachCookItem("InsuranceCompanyID",
            //    SqlDbType.Char, 3, insuranceCompany.ToString(),
            //    ref cookItems);

            //DbRequestXmlCooker.AttachCookItem("DateType",
            //    SqlDbType.Char, 1, dateType.ToString(),
            //    ref cookItems);

			DbRequestXmlCooker.AttachCookItem("mcancDate",
				SqlDbType.VarChar, 10, cancDate.ToString(),
				ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyType",
                SqlDbType.Char, 3, policyType.ToString(),
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
				dt = exec.GetQuery("GetAutoGuardPremiumAndCommissionEarned", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not validated the Auto Guard Report.", ex);
			}
		}

		public DataTable MonthlyPolicyProduction(string Month, string Year, string policyClass)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[3];

			DbRequestXmlCooker.AttachCookItem("Month",
				SqlDbType.VarChar, 2, Month.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Year",
				SqlDbType.VarChar, 4, Year.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("PolicyClassID",
				SqlDbType.VarChar, 4, policyClass.ToString(),
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
				dt = exec.GetQuery("sp_Monthly_Policies_Prod", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not validated the Auto Monthly Policy Production Report.", ex);
			}
		}
		
		public DataTable AnualPolicyProduction(string Year, string policyClass)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[2];

			DbRequestXmlCooker.AttachCookItem("Year",
				SqlDbType.VarChar, 4, Year.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("PolicyClassID",
				SqlDbType.VarChar, 4, policyClass.ToString(),
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
				dt = exec.GetQuery("sp_Anual_Policies_Prod", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not validated the Auto Anual Policy Production Report.", ex);
			}
		}

		public DataTable CommissionReportByAgent(string BegDate, string EndDate, string agent, string dateType, string policyClass, int agentLevel)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[6];

			DbRequestXmlCooker.AttachCookItem("BegDate",
				SqlDbType.VarChar, 10, BegDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("EndDate",
				SqlDbType.VarChar, 10, EndDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("AgentID",
				SqlDbType.Char, 3, agent.ToString(),
				ref cookItems);

            DbRequestXmlCooker.AttachCookItem("AgentLevel",
                SqlDbType.Int, 0, agentLevel.ToString(),
                ref cookItems);

			DbRequestXmlCooker.AttachCookItem("DateType",
				SqlDbType.Char, 1, dateType.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("PolicyClassID",
				SqlDbType.Char, 4, policyClass.ToString(),
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
				dt = exec.GetQuery("GetPolicyCommissionAgent", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not validated the Auto Guard Report.", ex);
			}
		}

        public DataTable CommissionReportByAgency(string BegDate, string EndDate, string agency, string dateType, string policyClass)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[5];

            DbRequestXmlCooker.AttachCookItem("BegDate",
                SqlDbType.VarChar, 10, BegDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndDate",
                SqlDbType.VarChar, 10, EndDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("AgencyID",
                SqlDbType.Char, 3, agency.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("DateType",
                SqlDbType.Char, 1, dateType.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyClassID",
                SqlDbType.Char, 4, policyClass.ToString(),
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
                dt = exec.GetQuery("GetPolicyCommissionAgency", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not validated the Commission Report.", ex);
            }
        }

        public DataTable RenewalPendingReport(string BegDate, string EndDate)
        {
            DbRequestXmlCookRequestItem[] cookItems = new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("BegDate", SqlDbType.VarChar, 10, BegDate.ToString(), ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndDate", SqlDbType.VarChar, 10, EndDate.ToString(), ref cookItems);

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
                dt = exec.GetQuery("GetRenewalPendingPolicies", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not validated the Renewal Report.", ex);
            }
        }

        public DataTable RenewalPendingPrint(string BegDate, string EndDate, string Status)
        {
            DbRequestXmlCookRequestItem[] cookItems = new DbRequestXmlCookRequestItem[3];

            DbRequestXmlCooker.AttachCookItem("BegDate", SqlDbType.VarChar, 10, BegDate.ToString(), ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndDate", SqlDbType.VarChar, 10, EndDate.ToString(), ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Status", SqlDbType.VarChar, 10, Status.ToString(), ref cookItems);

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
                dt = exec.GetQuery("GetRenewalPendingPrinting", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not validated the Renewal Report.", ex);
            }
        }

		public DataTable IncentiveReportBySupplier(string BegDate, string EndDate, string supplier, string dateType, string policyClass)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[5];

			DbRequestXmlCooker.AttachCookItem("BegDate",
				SqlDbType.VarChar, 10, BegDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("EndDate",
				SqlDbType.VarChar, 10, EndDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("SupplierID",
				SqlDbType.Char, 3, supplier.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("DateType",
				SqlDbType.Char, 1, dateType.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("PolicyClassID",
				SqlDbType.Char, 4, policyClass.ToString(),
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
				dt = exec.GetQuery("GetPolicyIncentiveSupplier", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not validated the Auto Guard Report.", ex);
			}
		}
	}
}
