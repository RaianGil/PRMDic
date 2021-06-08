using System;
using System.Data;
using System.Xml;
using Baldrich.DBRequest;

namespace EPolicy2.Reports
{

	public class ProspectReport
	{
		public ProspectReport()
		{
	
		}

		public DataTable ProspectsList(bool IsBusiness, string BegDate, string EndDate)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
			sb.Append("<parameter>");
			sb.Append("<name>IsBusiness</name>");
			sb.Append("<type>bit</type>");
			sb.Append("<value>"+IsBusiness+"</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>BegDate</name>");
			sb.Append("<type>varchar</type>");
			sb.Append("<Length>10</Length>");
			sb.Append("<value>"+BegDate+"</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>EndDate</name>");
			sb.Append("<type>varchar</type>");
			sb.Append("<Length>10</Length>");
			sb.Append("<value>"+EndDate+"</value>");
			sb.Append("</parameter>");
			sb.Append("</parameters>");
			xmlDoc.InnerXml = sb.ToString();
			sb = null;

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetProspectsList",xmlDoc);
			return dt;
		}

		public DataTable ProspectWithTasks(bool IsBusiness, string BegDate, string EndDate)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
			sb.Append("<parameter>");
			sb.Append("<name>IsBusiness</name>");
			sb.Append("<type>bit</type>");
			sb.Append("<value>"+IsBusiness+"</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>BegDate</name>");
			sb.Append("<type>varchar</type>");
			sb.Append("<Length>10</Length>");
			sb.Append("<value>"+BegDate+"</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>EndDate</name>");
			sb.Append("<type>varchar</type>");
			sb.Append("<Length>10</Length>");
			sb.Append("<value>"+EndDate+"</value>");
			sb.Append("</parameter>");
			sb.Append("</parameters>");
			xmlDoc.InnerXml = sb.ToString();
			sb = null;

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetProspectWithTasks",xmlDoc);
			return dt;
		}

		public DataTable ProspectWithQuotes(bool IsBusiness, string BegDate, string EndDate)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
			sb.Append("<parameter>");
			sb.Append("<name>IsBusiness</name>");
			sb.Append("<type>bit</type>");
			sb.Append("<value>"+IsBusiness+"</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>BegDate</name>");
			sb.Append("<type>varchar</type>");
			sb.Append("<Length>10</Length>");
			sb.Append("<value>"+BegDate+"</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>EndDate</name>");
			sb.Append("<type>varchar</type>");
			sb.Append("<Length>10</Length>");
			sb.Append("<value>"+EndDate+"</value>");
			sb.Append("</parameter>");
			sb.Append("</parameters>");
			xmlDoc.InnerXml = sb.ToString();
			sb = null;

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetProspectWithQuotes",xmlDoc);
			return dt;
		}

		public DataTable ProspectWithoutQuotes(bool IsBusiness, string BegDate, string EndDate)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
			sb.Append("<parameter>");
			sb.Append("<name>IsBusiness</name>");
			sb.Append("<type>bit</type>");
			sb.Append("<value>"+IsBusiness+"</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>BegDate</name>");
			sb.Append("<type>varchar</type>");
			sb.Append("<Length>10</Length>");
			sb.Append("<value>"+BegDate+"</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>EndDate</name>");
			sb.Append("<type>varchar</type>");
			sb.Append("<Length>10</Length>");
			sb.Append("<value>"+EndDate+"</value>");
			sb.Append("</parameter>");
			sb.Append("</parameters>");
			xmlDoc.InnerXml = sb.ToString();
			sb = null;

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetProspectWithoutQuotes",xmlDoc);
			return dt;
		}

		public DataTable ProspectConvertedToClient(bool IsBusiness, string BegDate, string EndDate)
        {
			DateTime mBegDate = DateTime.Parse(BegDate);
			DateTime mEndDate = DateTime.Parse(EndDate);

			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
			sb.Append("<parameter>");
			sb.Append("<name>IsBusiness</name>");
			sb.Append("<type>bit</type>");
			sb.Append("<value>"+IsBusiness+"</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>BegDate</name>");
			sb.Append("<type>DateTime</type>");
			sb.Append("<value>"+mBegDate+"</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>EndDate</name>");
			sb.Append("<type>DateTime</type>");
			sb.Append("<value>"+mEndDate+"</value>");
			sb.Append("</parameter>");
			sb.Append("</parameters>");
			xmlDoc.InnerXml = sb.ToString();
			sb = null;

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetProspectConvertedToClient",xmlDoc);
			return dt;
		}
	}
}
