using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using EPolicy.LookupTables;
using EPolicy.Login;
using Baldrich.DBRequest;
using EPolicy.XmlCooker;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Validation;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.IO;
using System.IO.Compression;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Runtime.InteropServices;
using Ionic.Zip;




namespace EPolicy
{
	/// <summary>
	/// Summary description for UserPropertiesList.
	/// </summary>
    public partial class FileManager : System.Web.UI.Page
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
          
			Login.Login cp = HttpContext.Current.User as Login.Login;
			if (cp == null)
			{
				Response.Redirect("Default.aspx?001");
			}
			else
			{
                if (!cp.IsInRole("ADMINISTRATOR") && !cp.IsInRole("FILEMANAGER"))
				{
					Response.Redirect("Default.aspx?001");
				}
			}

            if (!IsPostBack)
            {
                //if (cp.UserID == 1)
                //{
                //    txtInupt.Visible = true;
                //    BtnEncrypt.Visible = true;
                //    BtnDecrypt.Visible = true;
                //    txtResult.Visible = true;
                //}
            }
            else 
            {
            }
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);

            System.Web.UI.Control Banner = new System.Web.UI.Control();
			Banner = LoadControl(@"TopBanner1.ascx");
			this.Placeholder1.Controls.Add(Banner);

			/*//Setup Left-side Banner
            System.Web.UI.Control LeftMenu = new System.Web.UI.Control();
			LeftMenu = LoadControl(@"LeftMenu.ascx");
			this.phTopBanner1.Controls.Add(LeftMenu);*/
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            //this.ToRenew.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ToRenew_ItemCommand);
            //this.PreviewRenew.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.PreviewRenew_ItemCommand);
		}
		#endregion




        protected void BtBackUp_Click(object sender, System.EventArgs e)
        {
            int files = 0;
            string sourcePath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"].ToString();
            string ServertargetPath = @"C:\Inetpub\wwwroot\PRMDic\exportfilesBKP\";
            string UserTargetPath = "";//Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory).ToString();
            //System.IO.Directory.CreateDirectory(Path.Combine(UserTargetPath, "exportfilesBKP"));
            //UserTargetPath = UserTargetPath + @"\exportfilesBKP";
            LblTotalCases.Text = "Total Files: ";

            try
            {
                files = CopyFiles(sourcePath, ServertargetPath);
                LblTotalCases.Text = LblTotalCases.Text + files.ToString();
                LblTotalCases.Visible = true;
                CompressFolder(@"C:\Inetpub\wwwroot\PRMDic\exportfilesBKP", sourcePath);
                DownLoadFile(sourcePath + "exportfilesBKP.zip");

                //DeleteFiles(sourcePath);

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Files backup successful");
                this.litPopUp.Visible = true;
            }

            catch (Exception exc)
            {
                LogError(exc);
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exc.Message);
                this.litPopUp.Visible = true;
            }
           
        }


        protected int CopyFiles(string sourcePath, string targetPath)
        {
            int count = 0;
            string fileName = "";
            string destFile = "";

            try
            {
                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);

                    // Copy the files and overwrite destination files if they already exist.
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        fileName = System.IO.Path.GetFileName(s);
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(s, destFile, true);
                        count++;
                    }
                }
                else
                {
                    throw new Exception("Path could not be found");
                }

                
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }

            return count;
        }

        public static void DeleteFiles(string Path)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(Path);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }

        private void DownLoadFile(string filename)
        {
            string FileNameOf = filename;//Request.MapPath("ExportFiles")+"/"+filename;
            FileInfo myFile = new FileInfo(FileNameOf);

            Response.ClearHeaders();
            Response.Expires = 0;
            Response.Buffer = true;
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + myFile.Name.Replace(".resources", ""));
            Response.AddHeader("Content-Length", myFile.Length.ToString());
            Response.ContentType = "application/octet-stream";

            Response.Flush();

            Response.WriteFile(myFile.FullName);
            Response.Flush();
            //Response.End();
        }

        protected static void CompressFolder(string directory,string EndingPath)
        {
                using (ZipFile zip = new ZipFile())
                {
                    zip.UseUnicodeAsNecessary = true;
                    zip.AddDirectory(directory);
                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                    zip.Comment = "This zip was created at " + System.DateTime.Now.ToString();
                    zip.Save(EndingPath + "exportfilesBKP.zip");
                }
        }

        protected static void Compress(DirectoryInfo directorySelected)
        {
            foreach (FileInfo fileToCompress in directorySelected.GetFiles())
            {
                using (System.IO.FileStream originalFileStream = fileToCompress.OpenRead())
                {
                    if ((File.GetAttributes(fileToCompress.FullName) &
                       FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                    {
                        using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                        {
                            using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                               CompressionMode.Compress))
                            {
                                //originalFileStream.CopyTo(compressionStream);
                                CopyTo(originalFileStream,compressionStream);
                            }
                        }
                        FileInfo info = new FileInfo(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"].ToString() + Path.DirectorySeparatorChar + fileToCompress.Name + ".gz");
                    }
                }
            }
        }

        protected static void CopyTo(Stream source, Stream destination)
        {
            int bufferSize = 81920;
            byte[] array = new byte[bufferSize];
            int count;
            while ((count = source.Read(array, 0, array.Length)) != 0)
            {
               destination.Write(array, 0, count);
            }
        }


		protected void BtnExit_Click(object sender, System.EventArgs e)
		{
			Session.Clear();
			Response.Redirect("MainMenu.aspx");
		}


        protected string ClearString(string value)
        {
            byte[] tempBytes;
            tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(value.ToString().Trim().Replace(",", "").Replace("\n", "").Replace("\r", "")); // Remueve acentos 
            value = System.Text.Encoding.UTF8.GetString(tempBytes);
            value = value.Replace(" ", "").Replace("-", "").Replace(".", "").Replace("(", "").Replace(")", "").Replace("@", "").Replace("*", "").ToUpper().Trim();
            return value;
        }

        protected string ClearString2(string value)
        {
            byte[] tempBytes;
            tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(value.ToString().Trim().Replace(",", "").Replace("\n", "").Replace("\r", "")); // Remueve acentos 
            value = System.Text.Encoding.UTF8.GetString(tempBytes);
            value = value.Replace("-", "").Replace(".", "").Replace("(", "").Replace(")", "").Replace("@", "").Replace("*", "").Replace("&", " and ").Replace("/", " ").Replace(@"\", " ").ToUpper().Trim();
            return value;
        }

        private void ExportDataSet(DataSet ds, string destination)
        {
            try
            {
                EncryptClass.EncryptClass encrypt = new EncryptClass.EncryptClass();
                string text="";

                using (var workbook = SpreadsheetDocument.Create(destination, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
                //using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(destination, true)) //To open existing file
                {
                    var workbookPart = workbook.AddWorkbookPart(); //Comment line if using existing file

                    workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();

                    workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();

                    foreach (System.Data.DataTable table in ds.Tables)
                    {

                        var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                        var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();
                        sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);

                        DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
                        string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                        uint sheetId = 1;
                        if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
                        {
                            sheetId =
                                sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                        }

                        DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipId, SheetId = sheetId, Name = table.TableName };
                        sheets.Append(sheet);

                        DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

                        List<String> columns = new List<string>();
                        foreach (System.Data.DataColumn column in table.Columns)
                        {
                            columns.Add(column.ColumnName);

                            DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);
                            headerRow.AppendChild(cell);
                        }

                        sheetData.AppendChild(headerRow);

                        foreach (System.Data.DataRow dsrow in table.Rows)
                        {
                            DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                            //foreach (String col in columns)
                            for (int i = 0; i < table.Columns.Count; i++)
                            {
                                DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                                cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;

                                cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(ClearString2(dsrow[i].ToString().Replace(",", "")));

                                newRow.AppendChild(cell);
                            }

                            sheetData.AppendChild(newRow);
                        }

                    }
                }
            }
            catch (Exception exp)
            {
                LogError(exp);
                throw new Exception(exp.InnerException.Message);
            }
        }

        
        private void LogError(Exception exp)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", exp.Message);
            message += Environment.NewLine;
            message += string.Format("InnerException: {0}", exp.InnerException);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", exp.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", exp.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", exp.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = Server.MapPath("~/ErrorLog/ErrorLog.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

	}
}
