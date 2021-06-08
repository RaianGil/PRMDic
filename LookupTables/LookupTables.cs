using System;
using System.Data;
using Baldrich.DBRequest;
using System.Xml;
using EPolicy.XmlCooker;

namespace EPolicy.LookupTables
{
 	public class LookupTables
	{
		
		#region Public operators
		
		public LookupTables()
		{
		}

		public static DataTable GetTableTaskStatusByTaskType(int TaskType)
		{		
			DataTable dt = GetTableTaskStatusByTaskTypeDB(TaskType);
			return dt;
		}

		public static DataTable GetTable(string tableName)
		{		
			DataTable dt = GetTableByTableName(tableName);
			return dt;
		}

		public static string GetID(string tableName, string description)
		{
			DataTable dt = GetTableByTableName(tableName);
			
			string IDCode ="";

			for(int i=0;i<= dt.Rows.Count-1; i++)
			{
				if (description.ToUpper().Trim() == 
					dt.Rows[i][tableName+"Desc"].ToString().ToUpper().Trim())
				{
					IDCode = dt.Rows[i][tableName+"ID"].ToString().Trim();
				}
			}
			return IDCode;
		}

		public static string GetDescription(string tableName, string ID)
		{
			DataTable dt = GetTableByTableName(tableName);
			
			string description ="";

			for(int i=0;i<= dt.Rows.Count-1; i++)
			{
				if (ID.ToUpper().Trim() == 
					dt.Rows[i][tableName+"ID"].ToString().ToUpper().Trim())
				{
					description = dt.Rows[i][tableName+"Desc"].ToString().Trim();
				}
			}
			return description;
		}

        public static string GetDescriptionToPRPrimaryLimit(string tableName, string ID)
        {
            DataTable dt = GetTableByTableName(tableName);

            string description = "";

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                if (ID.ToUpper().Trim() ==
                    dt.Rows[i]["PRMedicalLimitID"].ToString().ToUpper().Trim())
                {
                    description = dt.Rows[i]["PRMedicalLimitDesc"].ToString().Trim();
                }
            }
            return description;
        }

        public static string GetDescriptionToVSCVehicleMake(string tableName, string ID)
        {
            DataTable dt = GetTableByTableName(tableName);

            string description = "";

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                if (ID.ToUpper().Trim() ==
                    dt.Rows[i]["VehicleMakeID"].ToString().ToUpper().Trim())
                {
                    description = dt.Rows[i]["VehicleMakeDesc"].ToString().Trim();
                }
            }
            return description;
        }

        public static string GetDescriptionToVSCVehicleModel(string tableName, string ID)
        {
            DataTable dt = GetTableByTableName(tableName);

            string description = "";

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                if (ID.ToUpper().Trim() ==
                    dt.Rows[i]["VehicleModelID"].ToString().ToUpper().Trim())
                {
                    description = dt.Rows[i]["VehicleModelDesc"].ToString().Trim();
                }
            }
            return description;
        }

        public static string GetFBRegionDescription(string ID)
        {
            DataTable dt = GetTableByTableNameFBRegion(ID);

            string description = "";

            if (dt.Rows.Count != 0)
            {
                description = dt.Rows[0]["FBRegionDesc"].ToString().Trim();
            }
            return description;
        }

		public static DataTable GetLookupTableFromSP(int LookupTableID, string SPname)
		{
			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dtResult = 
				exec.GetQuery(SPname, 
				GetRetrieveLookupTableFromSPxml(LookupTableID));
			return dtResult;
		}
		
		public static DataTable GetLookupTableFromSP(string LookupTableName, string SPname)
		{   
			return GetLookupTableFromSP(
				GetLookupTableIdFromTableName(LookupTableName), SPname);
		}

		public static int Add(int LookupTableID, string Description)
		{
			Validate(LookupTableID, 0, Description, true);

			return ExecuteAddQuery(GetAddXml(LookupTableID, Description));
		}

		public static int Add(string LookupTableName, string Description)
		{
			return Add(
				GetLookupTableIdFromTableName(LookupTableName.Trim()), 
				Description);
		}

		public static void Update(
			int LookupTableID, int DescriptionID, string Description)
		{
			Validate(LookupTableID, DescriptionID, Description, false);
			
			ExecuteUpdateQuery(
				GetUpdateLookupTableDescriptionXml(LookupTableID, DescriptionID,
				Description));
		}

		public static void Update(string LookupTableName, int DescriptionID, string Description)
		{
			Update(GetLookupTableIdFromTableName(LookupTableName.Trim()), DescriptionID,
				Description);
		}

		public static void Delete(int LookupTableID, int DescriptionID)
		{
			ExecuteDeleteQuery(GetDeleteLookupTableDescriptionXml(
				LookupTableID, DescriptionID));
		}

		public static void Delete(string LookupTableName, int DescriptionID)
		{
			Delete(GetLookupTableIdFromTableName(LookupTableName), DescriptionID);
		}

		public static void Delete(
			string LookupTableName, int DescriptionID, bool LookupTableMetadataDescription)
		{
			if(LookupTableMetadataDescription)
			{
				Delete(GetLookupTableIdFromTableName(LookupTableName), DescriptionID, true);
			}
			else
			{
				Delete(LookupTableName, DescriptionID);
			}
		}
		
		public static void Delete(
			int LookupTableID, int DescriptionID, bool LookupTableMetadataDescription)
		{
			if(LookupTableMetadataDescription)
			{
				ExecuteDeleteQuery(GetDeleteLookupTableDescriptionXml(
					LookupTableID, DescriptionID), true);
			}
			else
			{
				Delete(LookupTableID, DescriptionID);
			}
		}

		public static string GetTableMaintenancePathFromTableID(int TableID)
		{
			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
			try
			{
				DataTable dtResult = 
					exec.GetQuery("GetLookupTableMaintenancePathFromLookupTableID",
					GetTableMaintenancePathFromTableIdXml(TableID));
				return dtResult.Rows[0]["MaintenancePagePath"].ToString();
			}
			catch (Exception ex)
			{
				throw new Exception("Could not retrieve maintenance path for this id.", ex);
			}
		}

		public static DataTable GetValuePairLookupTableNames()
		{
            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
			
			return exec.GetQuery("GetValuePairLookupTableNames", 
				GetValuePairLookupTableNamesXml());
		}

		public static DataTable GetNonValuePairLookupTableNames()
		{
			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
			
			return exec.GetQuery("GetNonValuePairLookupTableNames",
				GetNonValuePairLookupTableNamesXml());
		}

		public static DataTable GetLookupTableNameFromTableID(int LookupTableID)
		{
			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
			
			return exec.GetQuery("GetLookupTableNameFromTableID",
				GetLookupTableNameFromTableIdXml(LookupTableID));
		}

		public static DataTable GetNonValuePairLookupTableSearchFields(
			int LookupTableID, int Top, bool IsTopNull)
		{
            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			return exec.GetQuery("GetNonValuePairLookupTableSearchFields", 
				GetNonValuePairLookupTableSearchFieldsXml(LookupTableID,
				Top, IsTopNull));
		}

		public static DataTable GetRecordsForNonValuePairLookupTable(
			int LookupTableID, string SearchFieldA, string SearchCriterionA,
			string SearchFieldB, string SearchCriterionB, bool Metadata)
		{
			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			return exec.GetQuery("GetNonValuePairLookupTableRecordByCriteria", 
				GetRecordsForNonValuePairLookupTableXml(LookupTableID,
				SearchFieldA, SearchCriterionA,	SearchFieldB, SearchCriterionB, Metadata));
		}

		public static DataTable GetLookupTableNamesNotInMetadataStore()
		{
			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			return exec.GetQuery("GetLookupTableNamesNotInMetadataStore", 
				GetLookupTableNamesNotInMetadataStoreXml());
		}

		public static int GetLookupTableIdFromTableName(string TableName)
		{
            if (TableName == "MasterPolicy")
                TableName = "Corporation";

			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("LookupTableName",
				SqlDbType.VarChar, 50, TableName.Trim(),
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
			DataTable dtResult = null;
			try
			{
				dtResult = exec.GetQuery("GetLookupTableIdFromTableName", xmlDoc);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not retrieve prospect by criteria.", ex);
			}


            
			if(dtResult.Rows != null)
			{
				return int.Parse(dtResult.Rows[0]["LookupTableID"].ToString());
			}
			else
			{
				return 0;
			}
		}//End GetLookupTableIdFromTableName

		public static DataTable GetLookupTableNames()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[0];

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
			DataTable dtResult = null;
			try
			{
				dtResult = exec.GetQuery("GetLookupTableNames", xmlDoc);
				return dtResult;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not retrieve prospect by criteria.", ex);
			}
		}

		

		public static DataTable GetLookupTableColumnsByLookupTableID(int LookupTableID)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("LookupTableID",
				SqlDbType.Int, 0, LookupTableID.ToString(),
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
			DataTable dtResult = null;
			try
			{
				dtResult = exec.GetQuery("GetLookupTableColumnsByLookupTableID", xmlDoc);
				return dtResult;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not retrieve prospect by criteria.", ex);
			}

		}

		#endregion

		#region Private operators
        
		private static int ExecuteAddQuery(XmlDocument XmlDoc)
		{
			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
			return exec.Insert("AddLookupTableDescription", XmlDoc);
		}

		private static void ExecuteUpdateQuery(XmlDocument XmlDoc)
		{
			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
			exec.Update("UpdateLookupTableDescription", XmlDoc);
		}

		private static void ExecuteDeleteQuery(XmlDocument XmlDoc)
		{
			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
			exec.Delete("DeleteLookupTableDescription", XmlDoc);
		}

		private static void ExecuteDeleteQuery(
			XmlDocument XmlDoc, bool LookupTableMetadataDescription)
		{
			if(LookupTableMetadataDescription)
			{
				Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
				exec.Delete("DeleteLookupTableMetadataDescription", XmlDoc);
			}
			else
			{
				ExecuteDeleteQuery(XmlDoc);
			}
		}

		private static XmlDocument GetRecordsForNonValuePairLookupTableXml(
			int LookupTableID, string SearchFieldA, string SearchCriterionA,
			string SearchFieldB, string SearchCriterionB, bool Metadata)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[6];

			DbRequestXmlCooker.AttachCookItem("LookupTableID",
				SqlDbType.Int, 0, LookupTableID.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("SearchFieldA",
				SqlDbType.VarChar, 50, SearchFieldA.Trim(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("SearchCriterionA",
				SqlDbType.VarChar, 50, SearchCriterionA.Trim(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("SearchFieldB",
				SqlDbType.VarChar, 50, SearchFieldB.Trim(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("SearchCriterionB",
				SqlDbType.VarChar, 50, SearchCriterionB.Trim(),
				ref cookItems);
			

			DbRequestXmlCooker.AttachCookItem("Metadata",
				SqlDbType.Bit, 0, Metadata.ToString(),
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

		private static XmlDocument GetNonValuePairLookupTableSearchFieldsXml(
			int LookupTableID, int Top, bool IsTopNull)
		{

		  DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[2];
			
			DbRequestXmlCooker.AttachCookItem("LookupTableID",
				SqlDbType.Int, 0, LookupTableID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Top",
				SqlDbType.Int, 0, IsTopNull ? "NuLL": Top.ToString(),
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

		private static XmlDocument GetLookupTableNameFromTableIdXml(int LookupTableID)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			
			DbRequestXmlCooker.AttachCookItem("LookupTableID",
				SqlDbType.Int, 0, LookupTableID.ToString(),
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

		private static XmlDocument GetLookupTableNamesNotInMetadataStoreXml()
		{

			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[0];

			try
			{
				return DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}

		}

		private static XmlDocument GetValuePairLookupTableNamesXml()
		{

			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[0];

			try
			{
				return DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}

		}

		private static XmlDocument GetNonValuePairLookupTableNamesXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[0];

			try
			{
				return DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}


		}

		private static XmlDocument GetTableMaintenancePathFromTableIdXml(int LookupTableID)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];
			
			DbRequestXmlCooker.AttachCookItem("LookupTableID",
				SqlDbType.Int, 0, LookupTableID.ToString(),
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

		private static XmlDocument GetDeleteLookupTableDescriptionXml(int LookupTableID,
			int DescriptionID)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[2];
			
			DbRequestXmlCooker.AttachCookItem("LookupTableID",
				SqlDbType.Int, 0, LookupTableID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("DescriptionID",
				SqlDbType.Int, 0, DescriptionID.ToString(),
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

		private static XmlDocument GetUpdateLookupTableDescriptionXml(int LookupTableID,
			int DescriptionID, string Description)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[3];

			DbRequestXmlCooker.AttachCookItem("LookupTableID",
				SqlDbType.Int, 0, LookupTableID.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("DescriptionID",
				SqlDbType.Int, 0, DescriptionID.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Description",
				SqlDbType.VarChar, 50, Description.ToString(),
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

		private static XmlDocument GetRetrieveLookupTableFromSPxml(int LookupTableID)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("LookupTableID",
				SqlDbType.Int, 0, LookupTableID.ToString(),
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

		private static XmlDocument GetAddXml(int LookupTableID, string Description)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[2];

			DbRequestXmlCooker.AttachCookItem("LookupTableID",
				SqlDbType.Int, 0, LookupTableID.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Description",
				SqlDbType.VarChar, 50, Description.Trim(),
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
		
		private static DataTable GetTableByTableName(string TableName)
		{
			
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[0];

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
				dt = exec.GetQuery("Get" + TableName, xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not retrieve prospect by criteria.", ex);
			}
		
		}
        public static DataTable GetLookUpTable(bool LimitedLookUpTable)
        {

            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("isLimited",
                 SqlDbType.Bit, 0, LimitedLookUpTable.ToString(),
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
                dt = exec.GetQuery("GetLookupTableMetadata", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve prospect by criteria.", ex);
            }

        }

        private static DataTable GetTableByTableNameFBRegion(string ID)
        {

            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("FBRegionID",
                SqlDbType.Int, 0, ID.ToString(),
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
                dt = exec.GetQuery("GetFBRegionByFBRegionID", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve prospect by criteria.", ex);
            }

        }

		private static DataTable GetTableTaskStatusByTaskTypeDB(int TaskTypeID)
		{
			
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("TaskTypeID",
				SqlDbType.Int, 0, TaskTypeID.ToString(),
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
				 dt = exec.GetQuery("GetTableTaskStatusByTaskType", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not retrieve prospect by criteria.", ex);
			}
		
		}

		private static void Validate(
			int LookupTableID, int DescriptionID, string Description, bool Add)
		{
			string errorMessage = String.Empty;
			bool found = false;

			DataTable dt =  
				GetTable(
				GetLookupTableNameFromTableID(LookupTableID).Rows[0]["TableName"].ToString()); 

			if (Add)
			{
				for (int i=0; i<=dt.Rows.Count-1; i++)
				{
					if(dt.Rows[i][1].ToString().Trim().ToUpper() == Description.Trim().ToUpper())
					{
						errorMessage += "This Description is Already exist.";
						found = true;
					}
				}
			}
			else
			{
				for (int i=0; i<=dt.Rows.Count-1; i++)
				{
					if(dt.Rows[i][1].ToString().Trim().ToUpper() == Description.Trim().ToUpper() && dt.Rows[i][0].ToString().Trim() != DescriptionID.ToString().Trim())
					{
						errorMessage += "This Description is Already exist.";
						found = true;
					}
				}
			}

			if (found == true)
			{
				throw new Exception(errorMessage);
			}
		}
		#endregion
	}
}
