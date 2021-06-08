using System;
using System.Data;
using System.Xml;
using Baldrich.DBRequest;
using EPolicy.XmlCooker;

namespace EPolicy2.Reports
{
	/// <summary>
	/// Summary description for AutoPolicy.
	/// </summary>
	public class AutoPolicy
	{
		public AutoPolicy()
		{
			
		}

		public DataTable AutoPolicyReport(string BegDate, string EndDate, string CompanyDealerID, string InsuranceCompanyID, string DataType)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[5];

			DbRequestXmlCooker.AttachCookItem("CompanyDealerID",
				SqlDbType.Char, 3, CompanyDealerID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("BegDate",
				SqlDbType.VarChar, 10, BegDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("EndDate",
				SqlDbType.VarChar, 10, EndDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("InsuranceCompanyID",
				SqlDbType.Char, 3, InsuranceCompanyID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("DataType",
				SqlDbType.Char, 1, DataType.ToString(),
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
				dt = exec.GetQuery("GetAutoPolicyReport", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not validated the Auto Policy.", ex);
			}
		}


		public DataTable PaymentCertificationLetterReport(string BegDate, string EndDate)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[2];

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
				dt = exec.GetQuery("GetPaymentCertificateLetterReport", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not validated the Auto Policy.", ex);
			}
		}

	}
}
