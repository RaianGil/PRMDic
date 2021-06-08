using System;
using System.Data;
using System.Xml;
using Baldrich.DBRequest;
using EPolicy2.Reports;
using EPolicy;

namespace EPolicy2.Reports
{
	/// <summary>
	/// Summary description for Payments.
	/// </summary>
	public class PaymentsReports
	{
		public PaymentsReports()
		{

		}

		public DataTable PaymentsList(string BegDate, string EndDate, string PolicyClassID, string DateType)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
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
			sb.Append("<parameter>");
			sb.Append("<name>PolicyClassID</name>");
			sb.Append("<type>varchar</type>");
			sb.Append("<Length>10</Length>");
			sb.Append("<value>"+PolicyClassID+"</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>DateType</name>");
			sb.Append("<type>char</type>");
			sb.Append("<Length>1</Length>");
			sb.Append("<value>"+DateType+"</value>");
			sb.Append("</parameter>");
			sb.Append("</parameters>");
			xmlDoc.InnerXml = sb.ToString();
			sb = null;

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetPaymentsList",xmlDoc);
			return dt;
		}

		public DataTable PaymentsByCheckNo(string BegDate, string EndDate, string CheckNo)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
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
			sb.Append("<parameter>");
			sb.Append("<name>CheckNo</name>");
			sb.Append("<type>char</type>");
			sb.Append("<Length>10</Length>");
			sb.Append("<value>"+CheckNo+"</value>");
			sb.Append("</parameter>");
			sb.Append("</parameters>");
			xmlDoc.InnerXml = sb.ToString();
			sb = null;

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetPaymentsByCheckNo",xmlDoc);
			return dt;
		}

		public DataTable PaymentsSRO(string BegDate, string EndDate, bool SRO)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
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
			sb.Append("<parameter>");
			sb.Append("<name>SRO</name>");
			sb.Append("<type>bit</type>");
			sb.Append("<value>"+SRO+"</value>");
			sb.Append("</parameter>");
			sb.Append("</parameters>");
			xmlDoc.InnerXml = sb.ToString();
			sb = null;

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetPaymentsSRO",xmlDoc);
			return dt;
		}
	}
}
