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

namespace EPolicy
{
	/// <summary>
	/// Summary description for UserPropertiesList.
	/// </summary>
	public partial class UploadSS : System.Web.UI.Page
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{

            //Label2.Visible = false;
            //txtFrom.Visible = false;

            //Label3.Visible = false;
            //txtTo.Visible = false;

			Login.Login cp = HttpContext.Current.User as Login.Login;
			if (cp == null)
			{
				Response.Redirect("Default.aspx?001");
			}
			else
			{
				if(!cp.IsInRole("USERPROPERTIESLIST") && !cp.IsInRole("ADMINISTRATOR"))
				{
					Response.Redirect("Default.aspx?001");
				}
			}

			if(!IsPostBack)
			{
                //if (cp.UserID == 1)
                //{
                //    txtInupt.Visible = true;
                //    BtnEncrypt.Visible = true;
                //    BtnDecrypt.Visible = true;
                //    txtResult.Visible = true;
                //}
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
            this.DGSocSec.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGSocSec_ItemCommand);
            this.DGErrorCases.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGErrorCases_ItemCommand);
            

		}
		#endregion

		private void FillGrid(System.Data.DataTable dt)
		{
            DGSocSec.DataSource = null;
            DGSocSec.CurrentPageIndex = 0;
					

			if (dt.Rows.Count != 0)
			{
                DGSocSec.DataSource = dt;
                DGSocSec.DataBind();
			}
			else
			{
                DGSocSec.DataSource = null;
                DGSocSec.DataBind();
			}

			//LblTotalCases.Text = "Total Users: "+dt.Rows.Count.ToString();	
		}
        private void FillGridAnalysis(System.Data.DataTable dt)
        {
            DGAnalisys.DataSource = null;
            DGAnalisys.CurrentPageIndex = 0;


            if (dt.Rows.Count != 0)
            {
                DGAnalisys.DataSource = dt;
                DGAnalisys.DataBind();
            }
            else
            {
                DGAnalisys.DataSource = null;
                DGAnalisys.DataBind();
            }

            //LblTotalCases.Text = "Total Users: "+dt.Rows.Count.ToString();	
        }

        private void FillGridErrorCases(System.Data.DataTable dt)
        {
            DGErrorCases.DataSource = null;
            DGErrorCases.CurrentPageIndex = 0;


            if (dt.Rows.Count != 0)
            {
                DGErrorCases.DataSource = dt;
                DGErrorCases.DataBind();
            }
            else
            {
                DGErrorCases.DataSource = null;
                DGErrorCases.DataBind();
            }

            //LblTotalCases.Text = "Total Users: "+dt.Rows.Count.ToString();	
        }

        private void DGSocSec_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.Item.ItemType.ToString() != "Pager") // Select
			{
				
			}
			else  // Pager
			{
                DGSocSec.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                DGSocSec.DataSource = (System.Data.DataTable)Session["dtSS"];
                DGSocSec.DataBind();
			}
		}

        private void DGErrorCases_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.Item.ItemType.ToString() != "Pager") // Select
            {

            }
            else  // Pager
            {
                DGErrorCases.CurrentPageIndex = int.Parse(e.CommandArgument.ToString()) - 1;

                DGErrorCases.DataSource = (System.Data.DataTable)Session["dtErrorCases"];
                DGErrorCases.DataBind();
            }
        }

		protected void BtnExit_Click(object sender, System.EventArgs e)
		{
			Session.Clear();
			Response.Redirect("MainMenu.aspx");
		}
        protected void BtnEncryptAndDecrypt_Click(object sender, System.EventArgs e)
        {
            EncryptClass.EncryptClass encrypt = new EncryptClass.EncryptClass();

            if (txtInupt.Text.Trim() != "")
            {
                if (((System.Web.UI.WebControls.Button)sender).ID.ToString() == "BtnEncrypt")
                {
                    txtResult.Text = encrypt.Encrypt(txtInupt.Text.Trim());
                }
                else
                {
                    txtResult.Text = encrypt.Decrypt(txtInupt.Text.Trim());
                }
            }
        }

        protected void BtnCheckPassword_Click(object sender, System.EventArgs e)
        {

            System.Data.DataTable dt = GetSocSecPassword();

            if (dt.Rows.Count > 0)
            {
                if (txtPassWord.Text == dt.Rows[0]["Password"].ToString().Trim()) 
                {
                    FileUpload1.Enabled = true;
                    BtnUpload.Enabled = true;
                    BtnDownloadCustomer840Info.Enabled = true;
                    BtnDownloadCustomer840Info2020.Enabled = true;
                }
            }
        }
        

        protected void BtnExportResult_Click(object sender, System.EventArgs e)
        {
            string CsvPath = System.Configuration.ConfigurationManager.AppSettings["ExcelFilesPathName"].ToString()
                                     + "SocSecErrorCases" + DateTime.Now.ToShortDateString().Replace("/", "-") + "-"
                                     + DateTime.Now.Hour.ToString()
                                     + DateTime.Now.Minute.ToString()
                                     + DateTime.Now.Second.ToString()
                                     + ".csv";

            CreateCSV(GetSocSecUpdateErrorCases(), CsvPath);
            DownLoadFile(CsvPath);
        }

        protected void BtnExportUpdatedResult_Click(object sender, System.EventArgs e)
        {
            string CsvPath = System.Configuration.ConfigurationManager.AppSettings["ExcelFilesPathName"].ToString()
                                     + "SocSecUpdatedCases" + DateTime.Now.ToShortDateString().Replace("/", "-") + "-"
                                     + DateTime.Now.Hour.ToString()
                                     + DateTime.Now.Minute.ToString()
                                     + DateTime.Now.Second.ToString()
                                     + ".csv";

            CreateCSV(GetSocSecUpdatedCases(), CsvPath);
            DownLoadFile(CsvPath);
        }

        protected void BtnDownloadCustomer840Info_Click(object sender, System.EventArgs e)
        {
            try
            {
                string CsvPath = System.Configuration.ConfigurationManager.AppSettings["ExcelFilesPathName"].ToString()
                             + "Customer480Info" + DateTime.Now.ToShortDateString().Replace("/", "-") + "-"
                             + DateTime.Now.Hour.ToString()
                             + DateTime.Now.Minute.ToString()
                             + DateTime.Now.Second.ToString()
                             + ".xlsx";

                //if (txtFrom.Text.Trim() == "")
                //{
                //    throw new Exception("From Date missing...");
                //}
                //if (txtTo.Text.Trim() == "")
                //{
                //    txtTo.Text = DateTime.Now.ToShortDateString();
                //}
                //CreateCSVFor480(GetCustomer480Info(txtFrom.Text.Trim(), txtTo.Text.Trim()), CsvPath);
                System.Data.DataTable dt = new System.Data.DataTable();
                dt = null;
                dt = GetCustomer480Info(txtFrom.Text.Trim(), txtTo.Text.Trim());
                System.Data.DataSet ds = new DataSet();
                while (ds.Tables.Count > 0)
                {
                    System.Data.DataTable table = ds.Tables[0];
                    if (ds.Tables.CanRemove(table))
                    {
                        ds.Tables.Remove(table);
                    }
                }
                ds.Tables.Add(dt.Copy());
                //CreateCSV(dt, _FileName,doc.Name);
                ExportDataSet(ds, CsvPath);
                DownLoadFile(CsvPath);
            }
            catch(Exception ex)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(ex.Message);
                this.litPopUp.Visible = true;
            }
        }
        protected void BtnDownloadCustomer840Info2020_Click(object sender, System.EventArgs e)
        {
            try
            {
                string CsvPath = System.Configuration.ConfigurationManager.AppSettings["ExcelFilesPathName"].ToString()
                             + "Customer480Info" + DateTime.Now.ToShortDateString().Replace("/", "-") + "-"
                             + DateTime.Now.Hour.ToString()
                             + DateTime.Now.Minute.ToString()
                             + DateTime.Now.Second.ToString()
                             + ".xlsx";

                //if (txtFrom.Text.Trim() == "")
                //{
                //    throw new Exception("From Date missing...");
                //}
                //if (txtTo.Text.Trim() == "")
                //{
                //    txtTo.Text = DateTime.Now.ToShortDateString();
                //}
                //CreateCSVFor480(GetCustomer480Info(txtFrom.Text.Trim(), txtTo.Text.Trim()), CsvPath);
                System.Data.DataTable dt = new System.Data.DataTable();
                //dt = null;
                //dt.EnforceConstraints = false;
                //dt.Constraints.Clear();
                dt = GetCustomer480_2020_Info(txtFrom.Text.Trim(), txtTo.Text.Trim());
                dt.Columns.RemoveAt(dt.Columns.IndexOf("TaskControlID"));
                System.Data.DataSet ds = new DataSet();
                //ds.EnforceConstraints = false;
                while (ds.Tables.Count > 0)
                {
                    System.Data.DataTable table = ds.Tables[0];
                    if (ds.Tables.CanRemove(table))
                    {
                        ds.Tables.Remove(table);
                    }
                }
                ds.Tables.Add(dt.Copy());
                //CreateCSV(dt, _FileName,doc.Name);
                ExportDataSet(ds, CsvPath);
                DownLoadFile(CsvPath);
            }
            catch (Exception ex)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(ex.Message);
                this.litPopUp.Visible = true;
            }
        }

        
        

        protected void BtnUpload_Click(object sender, System.EventArgs e)
        {
            System.Data.DataTable dt=null;
            System.Data.DataTable dtAnalysis=null;
            System.Data.DataTable dtErrorCases = null;
            
            string worksheetName = "";// FINAL GVA CLAIMS PRMD 05-20
            //string path = System.Configuration.ConfigurationManager.AppSettings["ExcelFilesPathName"].ToString() + "LEY60-DIRECTORIO-FINAL(2).xlsx";
            //string path = @"C:\Inetpub\wwwroot\PRMDic\ExportFiles\MDSCLAIMSCONVERSION.xlsx";

            string path = "";
            if (FileUpload1.PostedFile.FileName.Trim() == "")
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Please select a file to upload.");
                this.litPopUp.Visible = true;

            }
            else
            {
                try
                {
                    var watch = new System.Diagnostics.Stopwatch();
                    watch.Start();

                    path = System.Configuration.ConfigurationManager.AppSettings["ExcelFilesPathName"].ToString() + FileUpload1.PostedFile.FileName.Trim();


                    if (!path.Contains(".xlsx"))
                    {
                        throw new Exception("The uploaded file is not in the correct format");
                    }
                    FileUpload1.PostedFile.SaveAs(path);

                    TruncateSocSecUpdate();
                    dt = ReadExcelToDatatble(worksheetName, path, 1, 1);

                    LblTotalCases.Visible = true;
                    LblTotalCases.Text = LblTotalCases.Text + dt.Rows.Count.ToString();
                    //Session.Add("dtSS", dt);
                    //FillGrid(dt);

                    AddTableToDbByDataTable(dt,"SocSecUpdate");


                    dtAnalysis = GetSocSecUpdateAnalysis();
                    FillGridAnalysis(dtAnalysis);

                    dtErrorCases = GetSocSecUpdateErrorCases();
                    Session.Add("dtErrorCases", dtErrorCases);
                    FillGridErrorCases(dtErrorCases);

                    UpdateCustomerSocSecFromSocSecUpdate();

                    watch.Stop();

                    BtnExportResult.Visible = true;
                    BtnExportUpdatedResult.Visible = true;
                    DeleteFiles();
                    
                }

                catch (Exception ex)
                {
                    LogError(ex);
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(ex.Message);
                    this.litPopUp.Visible = true;
                }
            }
        }
        public System.Data.DataTable ReadExcelToDatatble(string worksheetName, string saveAsLocation, int HeaderLine, int ColumnStart)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel._Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range range;
            EncryptClass.EncryptClass encrypt = new EncryptClass.EncryptClass();

            try
            {
                // Get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Open(saveAsLocation,  //Open(saveAsLocation);        
                                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
                                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
                                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
                                                        Type.Missing, Type.Missing);

                
                
               
                // Work sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)
                     excelworkBook.Worksheets.get_Item(1);
                  // excelworkBook.Worksheets.get_Item(worksheetName);


                       //excelworkBook.Worksheets.Item[worksheetName];

                range = excelSheet.UsedRange;
            }
            catch (Exception ex)
            {
                throw new Exception("Error trying to acess excell" + ex.Message);
            }

            try
            {

                int cl = range.Columns.Count; //The complete Columns of the excel
                List<string> ListBlankSpaces = new List<string>();
                int rowcount = range.Rows.Count;  //ALL of the Rows of the excel

                try
                {

                    //  -- Sets The Columms with Headers
                    for (int j = ColumnStart; j <= cl; j++)
                    {
                        var value = (Microsoft.Office.Interop.Excel.Range)excelSheet.Cells[HeaderLine, j];
                        //dataTable.Columns.Add(Convert.ToString(value.Value2), typeof(string)); 

                        if (value.Value2 != null)
                        {
                            DataColumn Column = new DataColumn();
                            Column.ColumnName = ClearString(value.Value2.ToString());
                            // Column.DataType = Type.GetType(GetDataTypeForColumns(Column.ColumnName));
                            dataTable.Columns.Add(Column);
                        }
                        else
                        {

                            DataColumn Column = new DataColumn();
                            Column.ColumnName = "BLANKSPACE" + j.ToString();
                            ListBlankSpaces.Add(Column.ColumnName);
                            // Column.DataType = Type.GetType(GetDataTypeForColumns(Column.ColumnName));
                            dataTable.Columns.Add(Column);
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error Reading Colums. The File cannot contain duplicate header titles.");
                }

                DataColumnCollection columns = dataTable.Columns;

                //filling the table from  excel file   
                try
                {
                    for (int i = HeaderLine + 1; i <= rowcount; i++)
                    {
                        System.Data.DataRow dr = dataTable.NewRow();

                        for (int j = ColumnStart; j <= cl; j++)
                        {
                            if (columns[j - ColumnStart].ColumnName == "SECCIONATIPODEID" || columns[j - ColumnStart].ColumnName == "CUSTOMERNUMBER" || columns[j - ColumnStart].ColumnName == "NUMERODEIDENTIFICACIONPATRONALOSEGUROSOCIAL")
                            {


                                var value = (Microsoft.Office.Interop.Excel.Range)excelSheet.Cells[i, j];
                                if (value.Value2 != null)
                                {
                                    if (columns[j - ColumnStart].ColumnName == "NUMERODEIDENTIFICACIONPATRONALOSEGUROSOCIAL")
                                    {
                                        dr[j - ColumnStart] = encrypt.Encrypt(value.Value2.ToString());
                                    }
                                    else
                                    { dr[j - ColumnStart] = value.Value2.ToString(); }//ValueConverter(value.Value2.ToString(), columns[j - ColumnStart].ColumnName);//columns[j-1].ColumnName);
                                }
                                else
                                    dr[j - ColumnStart] = "";//ValueConverter("", columns[j - 1].ColumnName);
                            }

                        }

                        dataTable.Rows.InsertAt(dr, dataTable.Rows.Count + 1);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error populating data - " + ex.Message);
                }

                //now close the workbook and make the function return the data table
                //excelworkBook.Close();
                excelworkBook.Close(Type.Missing, Type.Missing, Type.Missing);
                excel.Quit();

                //if (ListBlankSpaces.Count > 0)
                //{
                //    foreach (string BlankSpace in ListBlankSpaces)
                //    {
                //        //DataColumnCollection columns = dataTable.Columns;
                //        if (columns.Contains(BlankSpace))
                //        {
                //            dataTable.Columns.Remove(BlankSpace);
                //        }
                //    }
                //}


                for (int i = 0; i < dataTable.Columns.Count; i++)
                {

                    if (dataTable.Columns[i].ColumnName != "SECCIONATIPODEID" && dataTable.Columns[i].ColumnName != "CUSTOMERNUMBER" && dataTable.Columns[i].ColumnName != "NUMERODEIDENTIFICACIONPATRONALOSEGUROSOCIAL")
                    {
                        dataTable.Columns.Remove(dataTable.Columns[i].ColumnName);
                        i = 0;
                    }
                    
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

                excelSheet = null;
                range = null;
                excelworkBook = null;

            }
        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {

            System.Threading.Thread.Sleep(3000);
        
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

        #region OpenXml
        //private System.Data.DataTable ImportToDataTable(string destination, string sheetname)
        //{
        //    System.Data.DataTable dt = new System.Data.DataTable();

        //    using (DocumentFormat.OpenXml.Packaging.SpreadsheetDocument spreadSheetDocument = DocumentFormat.OpenXml.Packaging.SpreadsheetDocument.Open(destination, false))
        //    {

        //        WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
        //        System.Collections.Generic.IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>().Elements<Sheet>();
        //        string relationshipId = workbookPart.Workbook.Descendants<Sheet>().First(s => sheetname.Equals(s.Name)).Id; //sheets.First().Id.Value;
        //        WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
        //        DocumentFormat.OpenXml.Spreadsheet.Worksheet workSheet = worksheetPart.Worksheet;
        //        SheetData sheetData = workSheet.GetFirstChild<SheetData>();
        //        System.Collections.Generic.IEnumerable<Row> rows = sheetData.Descendants<Row>();

        //        int test = rows.Count();

        //        int starting_point = 0;
        //        string Ending_Col = "";

        //        //if (sheetname == "CLAIMS PRMD 05-20")
        //        //{
        //        //    starting_point = 1;
        //        //    Ending_Col = "RESVDATE";
        //        //}
        //        //else if (sheetname == "Reserve Adjustment PRMD")
        //        //{
        //        //    starting_point = 3;
        //        //    Ending_Col = "";//txtReserveDate.Text.Trim();
        //        //}



        //        foreach (Cell cell in rows.ElementAt(starting_point))//0
        //        {
        //            string ColumName = ""; //aqui

        //            if (GetCellValue(spreadSheetDocument, cell) != "")
        //            {

        //                ColumName = GetCellValue(spreadSheetDocument, cell);//ConvertExcelDate(ClearString(GetCellValue(spreadSheetDocument, cell).ToString()));
        //            }
        //            else
        //            {
        //                if (ColumName == "")
        //                {
        //                    ColumName = "BLANKSPACE" + cell.GetEnumerator().ToString(); 
        //                }
                       
        //            }
        //            dt.Columns.Add(ColumName);

        //            if (ColumName == Ending_Col)
        //            {
        //                break;
        //            }
        //        }

        //        DataColumnCollection columns = dt.Columns;

        //        foreach (Row row in rows) //this will also include your header row...
        //        {
        //            DataRow tempRow = dt.NewRow();

        //            for (int i = 0; i < dt.Columns.Count; i++) // row.Descendants<Cell>().Count()= Columnas completas  
        //            {
        //                tempRow[i] = GetCellValue(spreadSheetDocument, row.Descendants<Cell>().ElementAt(i));//ValueConverter(GetCellValue(spreadSheetDocument, row.Descendants<Cell>().ElementAt(i)), columns[i].ColumnName); //i-1 
        //            }
        //            //if (sheetname == "Reserve Adjustment PRMD" && tempRow[0].ToString() == "TOTAL")
        //            //{
        //            //    break;
        //            //}
        //            dt.Rows.Add(tempRow);
        //        }

        //    }
        //    dt.Rows.RemoveAt(0);//removes header
        //    //if (sheetname == "CLAIMS PRMD 05-20")
        //    //{
        //    //    dt.Rows.RemoveAt(0);
        //    //}
        //    //else if (sheetname == "Reserve Adjustment PRMD")
        //    //{
        //    //    for (int i = 0; i < 4; i++)
        //    //    {
        //    //        dt.Rows.RemoveAt(0);
        //    //    }
        //    //    dt.Rows.RemoveAt(dt.Rows.Count - 1);

        //    //}


        //    return dt;
        //}

        //public static string GetCellValue(SpreadsheetDocument document, Cell cell)
        //{
        //    SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
        //    if (cell.CellValue != null)
        //    {
        //        string value = cell.CellValue.InnerXml;

        //        if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
        //        {
        //            if (stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText != null)
        //            {
        //                value = stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
        //            }
        //            else
        //            {
        //                value = "";
        //            }

        //            return value;
        //        }
        //        else
        //        {
        //            return value;
        //        }
        //    }
        //    else return "";
        //}
        #endregion OpenXml

        private void AddTableToDbByDataTable(System.Data.DataTable dt, string Name)
        {
            string connectionString = GetConnectionString();
            // Open a sourceConnection to the AdventureWorks database.
            using (SqlConnection sourceConnection =
                       new SqlConnection(connectionString))
            {
                sourceConnection.Open();

                // Perform an initial count on the destination table.
                SqlCommand commandRowCount = new SqlCommand(
                    "SELECT COUNT(*) FROM " +
                    "dbo." + Name + ";",
                    sourceConnection);

                using (SqlConnection destinationConnection =
                           new SqlConnection(connectionString))
                {
                    destinationConnection.Open();

                    // Set up the bulk copy object.
                    // Note that the column positions in the source
                    // data reader match the column positions in
                    // the destination table so there is no need to
                    // map columns.
                    using (SqlBulkCopy bulkCopy =
                               new SqlBulkCopy(destinationConnection))
                    {
                        //bulkCopy.DestinationTableName = "dbo.ClaimConversionCopy";
                        bulkCopy.DestinationTableName = Name;

                        System.Data.DataTable ClaimConversion = new System.Data.DataTable();

                        ClaimConversion = dt;
                        ClaimConversion.TableName = Name;

                        try
                        {
                            // Write from the source to the destination.
                            foreach (var column in ClaimConversion.Columns)
                                bulkCopy.ColumnMappings.Add(column.ToString(), column.ToString());

                            bulkCopy.WriteToServer(ClaimConversion);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                        }
                    }
                }
            }
        }
        private void CreateCSV(System.Data.DataTable dt, string filename)
        {
            StringBuilder sb = new StringBuilder();

            DataColumnCollection Colums = dt.Columns;
            string[] columnNames = new string[Colums.Count];

            for (int i = 0; i < Colums.Count; i++)
            {
                columnNames[i] = Colums[i].ColumnName;
            }

            sb.AppendLine(string.Join(",", columnNames));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string[] fields = new string[dt.Columns.Count]; 
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    {
                        fields[j] = dt.Rows[i][j].ToString().Trim().Replace(",", "");
                    }

                }
                sb.AppendLine(string.Join(",", fields));
            }
            File.WriteAllText(filename, sb.ToString());
        }

        private void CreateCSVFor480(System.Data.DataTable dt, string filename)
        {
            StringBuilder sb = new StringBuilder();
            EncryptClass.EncryptClass encrypt = new EncryptClass.EncryptClass();


            DataColumnCollection Colums = dt.Columns;
            string[] columnNames = new string[Colums.Count];

            for (int i = 0; i < Colums.Count; i++)
            {
                columnNames[i] = Colums[i].ColumnName;
            }

            sb.AppendLine(string.Join(",", columnNames));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string[] fields = new string[dt.Columns.Count];
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    {
                        if (dt.Columns[j].ColumnName == "Nombre de Compa�ia")
                        {
                            fields[j] = ClearString2(dt.Rows[i][j].ToString().Trim().Replace(",", ""));
                        }
                        if (dt.Columns[j].ColumnName == "Customer Name")
                        {
                            fields[j] = ClearString2(dt.Rows[i][j].ToString().Trim().Replace(",", ""));
                        }
                        else if (dt.Columns[j].ColumnName == "Nombre")
                        {
                            fields[j] = ClearString2(dt.Rows[i][j].ToString().Trim().Replace(",", ""));
                        }
                        else if (dt.Columns[j].ColumnName == "Inicial")
                        {
                            fields[j] = ClearString2(dt.Rows[i][j].ToString().Trim().Replace(",", "")).ToUpper();
                        }
                        else if (dt.Columns[j].ColumnName == "Apellido Paterno")
                        {
                            fields[j] = ClearString2(dt.Rows[i][j].ToString().Trim().Replace(",", ""));
                        }
                        else if (dt.Columns[j].ColumnName == "Apellido Materno")
                        {
                            fields[j] = ClearString2(dt.Rows[i][j].ToString().Trim().Replace(",", ""));
                        }
                        else if (dt.Columns[j].ColumnName == "Numero de Identificacion Patronal o Seguro Social")
                        {
                            if (dt.Rows[i][j].ToString().Trim().Replace(",", "") != "")
                            {
                                fields[j] = encrypt.Decrypt(dt.Rows[i][j].ToString().Trim().Replace(",", "")); //aqui  
                            }
                            else
                                fields[j] = "";
                            
                        }
                        else
                        {
                            fields[j] = dt.Rows[i][j].ToString().Trim().Replace(",", "");
                        }
                    }

                }
                sb.AppendLine(string.Join(",", fields));
            }
            File.WriteAllText(filename, sb.ToString());
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
                                if (table.Columns[i].ColumnName == "Nombre de Compa�ia" || table.Columns[i].ColumnName == "Customer Name" || table.Columns[i].ColumnName == "Nombre" || table.Columns[i].ColumnName == "Apellido Paterno" || table.Columns[i].ColumnName == "Apellido Materno")
                                {
                                    cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(ClearString2(dsrow[i].ToString().Replace(",", "")));
                                }
                                else if (table.Columns[i].ColumnName == "Inicial")
                                {
                                    cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(ClearString2(dsrow[i].ToString().Replace(",", "")));
                                }
                                else if (table.Columns[i].ColumnName == "Correo Electr�nico")
                                {
                                    cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[i].ToString().Replace(",", ""));
                                }
                                else if (table.Columns[i].ColumnName == "Codigo Postal")
                                {
                                    text = ClearString2(dsrow[i].ToString().Replace(",", ""));
                                    if (text.Length > 4)
                                    {
                                        //text = String.Format("{0:(###) ###-####}", 8005551212);
                                        text = String.Format("{0:#####-####}", text);
                                    }
                                    cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[i].ToString().Replace(",", ""));
                                }
                                else if (table.Columns[i].ColumnName == "Tel�fono 1")
                                {
                                    text = ClearString2(dsrow[i].ToString().Replace(",", ""));
                                    text = String.Format("{0:(###) ###-####}", text);

                                    cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[i].ToString().Replace(",", ""));
                                }
                                else if (table.Columns[i].ColumnName == "Tel�fono 2")
                                {
                                    text = ClearString2(dsrow[i].ToString().Replace(",", ""));
                                    text = String.Format("{0:(###) ###-####}", text);
                                        

                                    cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[i].ToString().Replace(",", ""));
                                }
                                else if (table.Columns[i].ColumnName == "PolicyNumber")
                                {
                                    cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[i].ToString().Replace(",", ""));
                                }
                                else if (table.Columns[i].ColumnName == "N�mero de Identificaci�n Patronal o Seguro Social")
                                {
                                    //cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[i].ToString().Replace(",", ""));

                                    if (ClearString2(dsrow[i].ToString()).Replace(",", "") != "" && ClearString2(dsrow[i].ToString()).Replace(",", "").ToUpper() != "UNDECIDED")
                                    {
                                        txtPassWord.Text = dsrow[i].ToString() + "     " + i.ToString();
                                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(encrypt.Decrypt(dsrow[i].ToString().Trim())); 
                                    }
                                    else
                                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("");
                                }
                                else
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
            Response.End();
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["PRMDICConnectionString"].ConnectionString;
        }

        public static void TruncateSocSecUpdate()
        {
            DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[0];

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

            try
            {
                exec.GetQuery("TruncateSocSecUpdate", xmlDoc);


            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }

        public static System.Data.DataTable GetSocSecUpdateErrorCases()
        {
            DbRequestXmlCookRequestItem[] cookItems =
           new DbRequestXmlCookRequestItem[0];

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
            System.Data.DataTable dt = null;
            try
            {
                dt = exec.GetQuery("GetSocSecUpdateErrorCases", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }

        public static System.Data.DataTable GetCustomer480Info(string BeginDate ,string EndDate)
        {
            DbRequestXmlCookRequestItem[] cookItems =
           new DbRequestXmlCookRequestItem[2];

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            DbRequestXmlCooker.AttachCookItem("BeginDate", SqlDbType.DateTime, 0, BeginDate, ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EndDate", SqlDbType.DateTime, 0, EndDate, ref cookItems);

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
            System.Data.DataTable dt = null;
            try
            {
                dt = exec.GetQuery("GetCustomer480Info", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }

        public static System.Data.DataTable GetCustomer480_2020_Info(string BeginDate, string EndDate)
        {
            DbRequestXmlCookRequestItem[] cookItems =
           new DbRequestXmlCookRequestItem[2];


            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            DbRequestXmlCooker.AttachCookItem("BeginDate", SqlDbType.DateTime, 0, BeginDate, ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EndDate", SqlDbType.DateTime, 0, EndDate, ref cookItems);

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
            System.Data.DataTable dt = new System.Data.DataTable();
            //dt.Constraints.Clear();
            try
            {
                
                dt = exec.GetQuery("GetCustomer480_2020_Info", xmlDoc);
                //dt.GetErrors();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }
        
        public static System.Data.DataTable GetSocSecUpdatedCases()
        {
            DbRequestXmlCookRequestItem[] cookItems =
           new DbRequestXmlCookRequestItem[0];

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
            System.Data.DataTable dt = null;
            try
            {
                dt = exec.GetQuery("GetSocSecUpdatedCases", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }

        public static System.Data.DataTable GetSocSecUpdateAnalysis()
        {
            DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[0];

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
            System.Data.DataTable dt = null;
            try
            {
                dt = exec.GetQuery("GetSocSecUpdateAnalysis", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }
        public static System.Data.DataTable GetSocSecPassword()
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[0];


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

            System.Data.DataTable dt = exec.GetQuery("GetSocSecPassword", xmlDoc);

            return dt;
        }

        public static void UpdateCustomerSocSecFromSocSecUpdate()
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[0];


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

            try
            {
                System.Data.DataTable dt = exec.GetQuery("UpdateCustomerSocSecFromSocSecUpdate", xmlDoc);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating Customer Social Number", ex);
            }
        }


        public static void DeleteFiles()
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(System.Configuration.ConfigurationManager.AppSettings["ExcelFilesPathName"].ToString());
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
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
