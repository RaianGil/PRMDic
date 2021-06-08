using System;
using System.Data;
using System.Data.SqlClient;
using Baldrich.DBRequest;
using System.Xml;
using EPolicy.LookupTables;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Reflection;
using EPolicy2.Reports;
using EPolicy;
using EPolicy.Audit;
using DataDynamics;
using EPolicy.XmlCooker;
using EPolicy.TaskControl;

namespace EPolicy2.Reports
{
	/// <summary>
	/// Summary description for PrintPolicy.
	/// </summary>
	public class PrintPolicy
	{
		public PrintPolicy()
		{

		}

		private DataTable _dtGeneral = new DataTable();
		
		#region Public Methods

		public ActiveReport3 SetPrintPolicy(EPolicy.TaskControl.Policy taskControl,int userID)
		{
			ActiveReport3 rpt = new ActiveReport3();
			bool FirstDocument = false;
			string ReportName = "";

			//Copy Count
			if (taskControl.PrintCopyReady.Rows.Count !=0)
			{
				string CopyValue="";
				for (int i = 0; i <= taskControl.PrintCopyReady.Rows.Count -1; i++)
				{
					CopyValue = taskControl.PrintCopyReady.Rows[i]["ReportCopyFooter"].ToString();
		
					//Report Count
					if (taskControl.PrintPolicyReady.Rows.Count != 0)
					{
						for (int a = 0; a <= taskControl.PrintPolicyReady.Rows.Count -1; a++)
						{
                            if (!FirstDocument)
                            {
                                //ReportName = "EPolicy2.PrintPolicyManagement."+policy.PrintPolicyReady.Rows[a]["ReportFileName"].ToString();
                                ReportName = "EPolicy2.Reports." + taskControl.PrintPolicyReady.Rows[a]["ReportFileName"].ToString().Trim();

                                Type report = Type.GetType(ReportName, true);
                                rpt = (ActiveReport3)Activator.CreateInstance(report, new Object[2] { taskControl, CopyValue });

                                //rpt = EPolicy2.Reports.VehicleServicesContract.VehicleServicesContract
                                rpt.Document.Printer.PrinterName = "";

                                rpt.Run();
                                FirstDocument = true;
                            }
                            else
                            {
                                ActiveReport3 rpt1 = new ActiveReport3();
                                //ReportName = "Epolicy2.Reports."+policy.PrintPolicyReady.Rows[a]["ReportFileName"].ToString();
                                ReportName = "EPolicy2.Reports." + taskControl.PrintPolicyReady.Rows[a]["ReportFileName"].ToString().Trim();
                                Type report = Type.GetType(ReportName, true);

                                rpt1 = (ActiveReport3)Activator.CreateInstance(report, new Object[2] { taskControl, CopyValue });

                                rpt1.Document.Printer.PrinterName = "";

                                rpt1.Run();

                                rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt1.Document.Pages);
                            }							
						}
					}
				}
			}
			return (rpt);
		}

		public ActiveReport3 SetPrintPolicy(EPolicy.TaskControl.Policy taskControl,EPolicy.TaskControl.QuoteAuto QAuto,int userID)
		{
            ActiveReport3 rpt = new ActiveReport3();
			bool FirstDocument = false;
			string ReportName = "";

			//Copy Count
			if (taskControl.PrintCopyReady.Rows.Count !=0)
			{
				string CopyValue="";
				for (int i = 0; i <= taskControl.PrintCopyReady.Rows.Count -1; i++)
				{
					CopyValue = taskControl.PrintCopyReady.Rows[i]["ReportCopyFooter"].ToString();
		
					//Report Count
					if (taskControl.PrintPolicyReady.Rows.Count != 0)
					{
						for (int a = 0; a <= taskControl.PrintPolicyReady.Rows.Count -1; a++)
						{
							if (!FirstDocument)
							{
								//ReportName = "EPolicy.PrintPolicyManagement."+policy.PrintPolicyReady.Rows[a]["ReportFileName"].ToString();
								ReportName = "EPolicy2.Reports."+taskControl.PrintPolicyReady.Rows[a]["ReportFileName"].ToString().Trim();
								Type report = Type.GetType(ReportName,true);
								
								//rpt = new PolicyPRAICO(QAuto,CopyValue);

                                rpt = (ActiveReport3)Activator.CreateInstance(report, new Object[2] { QAuto, CopyValue });

                                rpt.Document.Printer.PrinterName = ""; 

								rpt.Run();
								FirstDocument = true;
							}
							else
							{
                                ActiveReport3 rpt1 = new ActiveReport3();
								//ReportName = "Epolicy.Reports."+policy.PrintPolicyReady.Rows[a]["ReportFileName"].ToString();
								ReportName = "EPolicy2.Reports."+taskControl.PrintPolicyReady.Rows[a]["ReportFileName"].ToString().Trim();
								Type report = Type.GetType(ReportName,true);

                                //if ((ReportName != "EndosoConfiscacion") || (ReportName == "EndosoConfiscacion" && taskControl.Bank != ""))
                                //{

                                    rpt1 = (ActiveReport3)
                                        Activator.CreateInstance(report, new Object[2] { QAuto, CopyValue });

                                    rpt1.Document.Printer.PrinterName = "";

                                    rpt1.Run();

                                    rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt1.Document.Pages);
                                //}


								//Formas para Leasing solamente				
                                //if (a == taskControl.PrintPolicyReady.Rows.Count -1 && taskControl.Bank != "")
                                //{
                                //    EPolicy.LookupTables.Bank bank = new Bank();
                                //    bank = bank.GetBank(QAuto.Bank);
                                //    if(bank.MasterPolicyID.Trim()!= "")
                                //    {
                                //        rpt1 = new ActiveReport3();
                                //        //ReportName = "Epolicy.Reports."+policy.PrintPolicyReady.Rows[a]["ReportFileName"].ToString();
                                //        //ReportName = "Epolicy.Reports."+taskControl.PrintPolicyReady.Rows[a]["ReportFileName"].ToString().Trim();
                                //        //Type report = Type.GetType(ReportName,true);

                                //        rpt1 = new EndosoConfiscacion(QAuto,CopyValue);

                                //        rpt1.Document.Printer.PrinterName = ""; 

                                //        rpt1.Run();
	
                                //        rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count,rpt1.Document.Pages);
                                //    }
                                //}
							}							
						}
					}
				}
			}
			return (rpt);
		}

		public string[,] EndorsementsCollection(EPolicy.TaskControl.QuoteAuto policy)
		{	
			EPolicy.Quotes.AutoCover AC = null;
			AC = (EPolicy.Quotes.AutoCover)policy.AutoCovers[0];

			string[,] endorsement = new string[19,3];

			endorsement[0,0]="04-060";
			endorsement[0,1]="11/01";
			endorsement[0,2]="ALL";

			endorsement[1,0]="IL-0136";
			endorsement[1,1]="02/96";
			endorsement[1,2]="ALL";

			endorsement[2,0]="PP-0170";
			endorsement[2,1]="06/94";
			endorsement[2,2]="ALL";

			endorsement[3,0]="PP-0001";
			endorsement[3,1]="06/94";
			endorsement[3,2]="ALL";

			endorsement[4,0]="U-189";
			endorsement[4,1]=" ";
			endorsement[4,2]="ALL";

			endorsement[5,0]="04.122";
			endorsement[5,1]="01/99";
			endorsement[5,2]="ALL";
			
			int i=5;

			if (AC.AutoPolicyType=="DOUBLE INTEREST")  
			{
				endorsement[6,0]="OCS38160";
				endorsement[6,1]="07/98";
				endorsement[6,2]="ALL";

				endorsement[7,0]="01.016";
				endorsement[7,1]="02/96";
				endorsement[7,2]="ALL";
				   
				endorsement[8,0]="E-085";
				endorsement[8,1]="02/75";
				endorsement[8,2]="ALL";
				   
				endorsement[9,0]="PP-0305";
				endorsement[9,1]="08/86";
				endorsement[9,2]="ALL";
				   
				endorsement[10,0]="PP-0310";
				endorsement[10,1]="02/76";
				endorsement[10,2]="ALL";

				endorsement[11,0]="U-505";
				endorsement[11,1]="03/98";
				endorsement[11,2]="ALL";

				endorsement[12,0]="01.66";
				endorsement[12,1]=" ";
				endorsement[12,2]=" ";

				i=12;
			}        
		   
				
			if (AC.AutoPolicyType=="LIABILITY" || AC.AutoPolicyType=="FULL COVER")
			{
				endorsement[i+1,0]="U-805";
				endorsement[i+1,1]="11/90";
				endorsement[i+1,2]="ALL";
			   
				endorsement[i+2,0]="PP-0309";
				endorsement[i+2,1]="08/86";
				endorsement[i+2,2]="ALL";
			   
				endorsement[i+3,0]="PP-0326";
				endorsement[i+3,1]="06/94";
				endorsement[i+3,2]="ALL";
			        
				i=i+3 ;    
			}

			if (AC.AutoPolicyType=="FULL COVER")  
			{
				endorsement[i+1,0]="PP-0319";
				endorsement[i+1,1]="08/86";
				endorsement[i+1,2]="ALL";
				i=i+1;
				//				if (fpol.losspayee != "000") //  Leasing
				//				{
//				endorsement[i+1,0]="01.016";
//				endorsement[i+1,1]="02/96";
//				endorsement[i+1,2]="ALL";
//				     
//				endorsement[i+2,0]="E-085";
//				endorsement[i+2,1]="02/75";
//				endorsement[i+2,2]="ALL";
//				      
//				endorsement[i+3,0]="PP-0305";
//				endorsement[i+3,1]="08/86";
//				endorsement[i+3,2]="ALL";
//				i=i+3;
				//				}
			}
			else 
			{ 
				if (AC.AutoPolicyType!="LIABILITY") // && Chequea_arrendador())
				{
//					endorsement[i+1,0]="PP-0319";
//					endorsement[i+1,1]="08/86";
//					endorsement[i+1,2]="ALL";
//					i=i+1;
				}
			}
			
			if (AC.AssistancePremium != 0)             //mpp_prem  Assistance 
			{
				endorsement[i+1,0]="04.001";
				endorsement[i+1,1]="10/96";
				endorsement[i+1,2]="ALL";
				i=i+1;
			}
			
			if (AC.MedicalPremium() != 0)                //md_prem  Medical Premium
			{
				endorsement[i+1,0]="U-605";
				endorsement[i+1,1]="   ";
				endorsement[i+1,2]="ALL";
				i=i+1;
			}
			
			if (AC.TowingPremium != 0)                 //Towing
			{
				endorsement[i+1,0]="PP-0303";
				endorsement[i+1,1]="08/86";
				endorsement[i+1,2]="ALL";
				i=i+1;
			}

			return (endorsement);
		}

		public int GetUpdateControl(int TaskControlID)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];			
			XmlDocument xmlDoc;

			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, TaskControlID.ToString(),
				ref cookItems);

			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();

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
				dt = Executor.GetQuery("UpdateControl",xmlDoc);
				
				return (dt.Rows[0]["InvoiceNo"]!=System.DBNull.Value)?
					((int) dt.Rows[0]["InvoiceNo"]):0;

				//AddTaskPaymentReceipt
			   
			}
			catch(Exception ex)
			{
				throw new Exception("Could not retrieve prospect by criteria.", ex);
			}	

			//			if (dt.Rows.Count !=0)
			//			{
			//				return (dt.Rows[0]["InvoiceNo"]!=System.DBNull.Value)?
			//					((int) dt.Rows[0]["InvoiceNo"]):0;
			//			}
		}

        public static string GetPointCode(string LineOfBusiness, string TableName, string OptimaCode)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[3];
            XmlDocument xmlDoc;

            DbRequestXmlCooker.AttachCookItem("LineOfBusiness",
            SqlDbType.VarChar, 50, LineOfBusiness.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("TableName",
              SqlDbType.VarChar, 50, TableName.ToString(),
              ref cookItems);

            DbRequestXmlCooker.AttachCookItem("OptimaCode",
              SqlDbType.VarChar, 50, OptimaCode.ToString(),
              ref cookItems);

            Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();

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
                dt = Executor.GetQuery("GetPointCode", xmlDoc);

                if (dt.Rows.Count != 0)
                    return (dt.Rows[0]["PointCode"] != System.DBNull.Value) ? (dt.Rows[0]["PointCode"].ToString().Trim()) : "";
                else
                    return "";
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve prospect by criteria.", ex);
            }
        }
		#endregion
	}
}
