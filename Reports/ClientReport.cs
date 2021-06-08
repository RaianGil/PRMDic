using System;
using System.Data;
using System.Xml;
using Baldrich.DBRequest;

namespace EPolicy2.Reports
{

	public class ClientReport
	{
		public ClientReport()
		{

		}

		public DataTable CustomerLaberDataTable
		{
			get 
			{
				return this.CustomerLaberDataTable;
			}
			set
			{
				this.CustomerLaberDataTable = value;
			}
		}

		public DataTable GetDataTableCustomerLabel(EPolicy.Customer.Customer customer)
		{
			DataTable dt = new DataTable();


			this.CustomerLaberDataTable = dt;

			return this.CustomerLaberDataTable;

		}
	}
}
