using System;
using System.Data;
using System.Xml;
using Baldrich.DBRequest;

namespace EPolicy2.Reports
{
	/// <summary>
	/// Summary description for AdministrativeTools.
	/// </summary>
	public class AdministrativeTools
	{
		public AdministrativeTools()
		{
			
		}
		public DataTable BankList()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
			sb.Append("</parameters>");
			xmlDoc.InnerXml = sb.ToString();
			sb = null;

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetBankList",xmlDoc);
			return dt;
		}

		public DataTable AgencyList()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
			sb.Append("</parameters>");
			xmlDoc.InnerXml = sb.ToString();
			sb = null;

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetAgencyList",xmlDoc);
			return dt;
		}

		public DataTable AgentList()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
			sb.Append("</parameters>");  
			xmlDoc.InnerXml = sb.ToString();
			sb = null;

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetAgentList",xmlDoc);
			return dt;
		}


		public DataTable CompanyDealerList()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
			sb.Append("</parameters>");  
			xmlDoc.InnerXml = sb.ToString();
			sb = null;

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetCompanyDealerList",xmlDoc);
			return dt;
		}
	
		public DataTable InsuranceCompanyList()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
			sb.Append("</parameters>");  
			xmlDoc.InnerXml = sb.ToString();
			sb = null;

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetInsuranceCompanyList",xmlDoc);
			return dt;
		}

		public DataTable MasterPolicyList()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
			sb.Append("</parameters>");  
			xmlDoc.InnerXml = sb.ToString();
			sb = null;

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetMasterPolicyList",xmlDoc);
			return dt;
		}

		public DataTable CustomerCounterList()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
			sb.Append("</parameters>");  
			xmlDoc.InnerXml = sb.ToString();
			sb = null;

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetCustomerCounterList",xmlDoc);
			return dt;
		}

		public DataTable LocationList()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
			sb.Append("</parameters>");  
			xmlDoc.InnerXml = sb.ToString();
			sb = null;

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetLocationList",xmlDoc);
			return dt;
		}
		
		public DataTable VehicleModelList()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
			sb.Append("</parameters>");  
			xmlDoc.InnerXml = sb.ToString();
			sb = null;

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetVehicleModelList",xmlDoc);
			return dt;
		}

		public DataTable SupplierList()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
			sb.Append("</parameters>");  
			xmlDoc.InnerXml = sb.ToString();
			sb = null;

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetSupplierList",xmlDoc);
			return dt;
		}



	
	}
}
