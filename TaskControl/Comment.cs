using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SqlClient;
using EPolicy.XmlCooker;
using System.Data;


namespace EPolicy.TaskControl
{
    public class Comment:TaskControl
    {
        public Comment() 
        { }

        #region Variables

        public int UserID { get; set; }
        public int TaskControlID { get; set; }
        public string Comments { get; set; }
        public int User { get; set; }
        public string Date { get; set; }
        public string PolicyNo { get; set; }
        public int Disabled { get; set; }


        #endregion

        public void InitializeValue()
        {
            UserID = 0;
            TaskControlID = 0;
            Comments = "";
            Date = "";
            PolicyNo = "";
      
        }

       // DataTable dt = new DataTable();
        // dt = Ececutor.GetQuery("",xml);

        public static DataTable GetComment(int TaskControlID)
        {
            DataTable dt = new DataTable();
            try
            {
                DbRequestXmlCookRequestItem[] cookItems =
                    new DbRequestXmlCookRequestItem[1];

                DbRequestXmlCooker.AttachCookItem("TaskControlID",
                    SqlDbType.Int, 0, TaskControlID.ToString(),
                    ref cookItems);

                XmlDocument xmldoc;


                try
                {
                    xmldoc = DbRequestXmlCooker.Cook(cookItems);
                }

                catch (Exception ex)
                {
                    throw new Exception("Could not cook items.", ex);
                }
                Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();

                dt = Executor.GetQuery("GetCommentByTaskControlID", xmldoc);
                

            }

            catch (Exception xcp)
            {
                throw new Exception("Could not get comments.", xcp);
            }
            return dt;
        }

        
        public static void InsertComment(int UserID, int TaskControlID, string Comments)
        {
            try
            {
                
                DbRequestXmlCookRequestItem[] cookItems =
                    new DbRequestXmlCookRequestItem[4];


                DbRequestXmlCooker.AttachCookItem("TaskControlID",
                    SqlDbType.Int, 0, TaskControlID.ToString(),
                    ref cookItems);

                DbRequestXmlCooker.AttachCookItem("UserID",
                    SqlDbType.Int, 0, UserID.ToString(),
                    ref cookItems);

                DbRequestXmlCooker.AttachCookItem("Comments",
                    SqlDbType.VarChar, 500, Comments.ToString(),
                    ref cookItems);

             /*   DbRequestXmlCooker.AttachCookItem("Disabled",
                    SqlDbType.Bit, 1, Disabled.ToString(),
                    ref cookItems);*/

               

                XmlDocument xmldoc;

                try
                {
                    xmldoc = DbRequestXmlCooker.Cook(cookItems);
                    
                }
                catch (Exception ex)
                {
                    throw new Exception("Could not cook items.", ex);
                }

                Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
               Executor.Insert("AddComments", xmldoc);

                
            }
            catch (Exception xcp)
            {
                throw new Exception("Could not get the comments.", xcp);
            }
        }
    }
}