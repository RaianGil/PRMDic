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
using System.IO;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Microsoft.Reporting.WebForms;
using EPolicy.Login;
using EPolicy2.Reports;
using System.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace EPolicy
{
	/// <summary>
	/// Summary description for ActiveXExport.
	/// </summary>
	public partial class ActiveXViewer : System.Web.UI.Page
	{
		ActiveReport3 rpt = null;
        static bool renewal = false;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			this.litPopUp.Visible = false;
           

            Login.Login cp = HttpContext.Current.User as Login.Login;
            if (cp == null)
            {
                Response.Redirect("Default.aspx?001");
            }
            else
            {
                if (!cp.IsInRole("REPORTVIEWER") && !cp.IsInRole("ADMINISTRATOR"))
                {
                    Response.Redirect("Default.aspx?001");
                }
            }

            

			if(!IsPostBack)
			{	
				this.SetReferringPage();
	 	
				string sReturnReport = this.Page.Request.QueryString["ReturnReport"];

                if (this.Request.QueryString.ToString().Trim() == "true" ) //Es renovacion poliza PP o PE.
                {
                    TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
                    if(taskControl.PolicyType.Trim() != "CP" && taskControl.PolicyType.Trim() != "CE")
                        renewal = true;
                }

				if ( (sReturnReport != null) && (sReturnReport.Trim() != string.Empty) )
				{
					this.Page.Response.Buffer = true;
					
					try
					{
						rpt = (ActiveReport3) Session["Report"];
						//Session.Remove("Report");
					
						//rpt.Run(false);					
					}
					catch (Exception eRunReport)
					{
						this.Trace.Warn("Report failed to run:\n" + eRunReport.ToString());
					}
				
					MemoryStream outStream = new MemoryStream();
					rpt.Document.Save(outStream,DataDynamics.ActiveReports.Document.RdfFormat.AR20);

					outStream.Seek(0, SeekOrigin.Begin);

					byte[] bytes = new byte[outStream.Length];
					outStream.Read(bytes, 0, (int)outStream.Length);

					this.Page.Response.ClearContent();
					this.Page.Response.ClearHeaders();

					this.Page.Response.BinaryWrite(bytes);
					this.Page.Response.End();
				}
			}
		}

		private string ReferringPage
		{
			get
			{
				return ((ViewState["referringPage"] != null)?
					ViewState["referringPage"].ToString():"");
			}
			set
			{
				ViewState["referringPage"] = value;
			}
		}

		private void SetReferringPage()
		{
			if((Session["FromPage"] != null) && (Session["FromPage"].ToString() != ""))
			{
				this.ReferringPage = Session["FromPage"].ToString();
				Session.Remove("FromPage");
			}
		}

		private void ReturnToReferringPage()
		{
			if(this.ReferringPage != "")
			{
				Response.Redirect(this.ReferringPage);
			}
			Response.Redirect("Default.aspx");
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//


			this.InitializeComponent();
			base.OnInit(e);

            System.Web.UI.Control Banner = new System.Web.UI.Control();
			Banner = LoadControl(@"TopBanner.ascx");
			this.Placeholder1.Controls.Add(Banner);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		private void btnPrint_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(Valid())
			{
				ExportFile(true);
			}
			else
			{
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Please select one report format.");
				this.litPopUp.Visible = true;
			}
		}

		private bool Valid()
		{
            if (!rblReports.Items[0].Selected && !rblReports.Items[1].Selected && !rblReports.Items[2].Selected)
				return false;
			else
				return true;
		}

        private void ExportFile(bool isEmail)
		{
			Login.Login cp = HttpContext.Current.User as Login.Login;
			string _userID   = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();
			string _file     = _userID.ToString().Replace(" ","");
			string _FileName = ConfigurationSettings.AppSettings["ExportsFilesPathName"];
            TaskControl.TaskControl taskControl = (TaskControl.TaskControl)Session["TaskControl"];
            TaskControl.Policy task = new TaskControl.Policy();

            if(taskControl != null)
                if(taskControl.TaskControlTypeID == 12 || taskControl.TaskControlTypeID == 18)
                    task = (TaskControl.Policy)Session["TaskControl"];

			_FileName= _FileName + _file;

            ActiveReport3 doc = (ActiveReport3)Session["Report"];
			
			if (rblReports.Items[0].Selected)
			{
				ExportFile expFile = new ExportFile();
				
				try
				{
                    List<string> mergePaths = new List<string>();
                    string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

					
                    _FileName = _FileName + ".PDF";
					expFile.ExportToPDF(doc.Document,_FileName);

                    if ((task.PolicyType.Trim() == "PP" || task.PolicyType.Trim() == "PE") && task.Anniversary != "01")
                    {
                        _FileName = PrintRegistryDocument(_FileName);
                    }


                    if (int.Parse(task.Suffix) > 0)
                    {
                        mergePaths.Add(_FileName);

                        if(task.InsuranceCompany != "002")
                            mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + ImprimirCartaDeptDefensa());

                        if (task.Anniversary != "01")
                        {
                            if (DateTime.Parse(task.EffectiveDate) >= DateTime.Parse("01/01/2015") && task.InsuranceCompany != "002")
                            {
                                mergePaths.Add(imprimirF102B("F102BA"));
                                mergePaths.Add(imprimirF102B("F102BB"));
                                mergePaths.Add(imprimirF102B("F102BC"));
                                mergePaths.Add(imprimirF102B("F102BD"));
                            }
                        }

                        if (task.Charge > 0)//TxtCharge.Text != ".00")
                        {
                            var currentApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath.ToString();
                            string fullFilePath = currentApplicationPath + "Reports\\Word\\Files\\CN-2021-299-D_ENDOSO_DERRAMAS.pdf";
                            string copyToPath = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + "CN-2021-299-D_ENDOSO_DERRAMAS.pdf";
                            File.Copy(fullFilePath, copyToPath, true);
                            mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + "CN-2021-299-D_ENDOSO_DERRAMAS.pdf");
                        }

                        CreatePDFBatch mergeFinal = new CreatePDFBatch();
                        string FinalFile = "";
                        FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, _file + "-" + taskControl.TaskControlID.ToString());

                        FinalFile = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + FinalFile;

                        if (isEmail)
                            SendEmail(FinalFile);
                        else
                            DownLoadFile(FinalFile);
                    }
                    else
                    {
                        if (isEmail)
                            SendEmail(_FileName);
                        else
                            DownLoadFile(_FileName);
                    }
				}
				catch (Exception exp)
				{
					this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
					this.litPopUp.Visible = true;
					return;
				}
			}

            else if (rblReports.Items[2].Selected)
            {
                _FileName = _FileName + ".xlsx";
                System.Data.DataTable dt = new System.Data.DataTable();
                dt = null;
                dt = (DataTable)doc.DataSource;
                System.Data.DataSet ds = new DataSet();

                if (doc.Name == "PremiumWritten")
                {
                    int CanAmOrdinal = 0;
                    CanAmOrdinal = dt.Columns["CancellationAmount"].Ordinal;
                    dt.Columns["PremNet"].SetOrdinal(CanAmOrdinal + 1);
                    int desiredSize = dt.Columns["OtherSpecialty2"].Ordinal + 1; //se supone que sean 31 columnas. El final siendo OtherSpecialty2
                    while (dt.Columns.Count > desiredSize)
                    {
                        dt.Columns.RemoveAt(desiredSize);
                    }
                    
                    while (ds.Tables.Count > 0)
                    {
                        DataTable table = ds.Tables[0];
                        if (ds.Tables.CanRemove(table))
                        {
                            ds.Tables.Remove(table);
                        }
                    }
                }

                ds.Tables.Add(dt.Copy());

                //CreateCSV(dt, _FileName,doc.Name);
                ExportDataSet(ds, _FileName);
                if (isEmail)
                    SendEmail(_FileName);
                else
                    DownLoadFile(_FileName);

                ds.Clear();
                dt = null;
                dt.Clear();

                
            }
			else
			{
				ExportFile expFile = new ExportFile();
				
				try
				{
					_FileName= _FileName + ".XLS";
                    //_FileName = _FileName + ".xlsx";
					expFile.ExportToExcel(doc.Document,_FileName);
                    

					if(isEmail)
						SendEmail(_FileName);
					else
						DownLoadFile(_FileName);	
				}
				catch (Exception exp)
				{

                    
					this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
					this.litPopUp.Visible = true;
					return;
				}
			}	

			//this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Export File Sucessffully...");
			//this.litPopUp.Visible = true;
			return;	
		}

        private string PrintRegistryDocument(string fileName)
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
            string _userID = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();
            string _file = _userID.ToString().Replace(" ", "");
            TaskControl.TaskControl taskControl = (TaskControl.TaskControl)Session["TaskControl"];
            Customer.Registry registry = Customer.Registry.GetRegistryByCustomerNo(int.Parse(taskControl.CustomerNo));
            TaskControl.Policy policy = new TaskControl.Policy();
            policy = TaskControl.Policy.GetPolicyByTaskControlID(taskControl.TaskControlID, policy);

            List<string> mergePaths = new List<string>();
            string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];

            mergePaths = imprimirRegister(mergePaths);

            //FileInfo mFileIndex = new FileInfo("C:\\Inetpub\\wwwroot\\PRMDic\\Reports\\Registry.pdf");

            mergePaths.Add(fileName);

            //if (DateTime.Parse(policy.EffectiveDate) >= DateTime.Parse("01/01/2015"))
            //{
            //    mergePaths.Add(imprimirF102B("F102BA"));
            //    mergePaths.Add(imprimirF102B("F102BB"));
            //    mergePaths.Add(imprimirF102B("F102BC"));
            //    mergePaths.Add(imprimirF102B("F102BD"));
            //}

            CreatePDFBatch mergeFinal = new CreatePDFBatch();
            string FinalFile = "";
            FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, "F102B");

            return System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"] + FinalFile;

        }

        private List<string> imprimirRegister(List<string> mergePaths)
        {

            int compareResultASSMCA = 0;
            int compareResultTribunal = 0;
            int compareResultCDM = 0;
            int compareResultGS = 0;
            int compareResultLicense = 0;
            int compareResultDEA = 0;
            string tp6 = "";
            string assmcadate = "";
            string juntaLicenciamiento = "";
            string cdmdate = "";
            string gstandingdate = "";
            string licenseexpdate = "";
            string deadate = "";

            try
            {

                TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
                Customer.Registry registry = Customer.Registry.GetRegistryByCustomerNo(int.Parse(taskControl.CustomerNo));

                ReportViewer viewer = new ReportViewer();

                viewer.LocalReport.DataSources.Clear();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportPath = Server.MapPath("Reports/Report2.rdlc");


                #region values for parameters
                if (registry.ASSMCAExpDate != "")
                {
                    compareResultASSMCA = DateTime.Compare(DateTime.Parse(registry.ASSMCAExpDate.Trim()), DateTime.Now);

                    if (compareResultASSMCA < 0)
                    {
                        assmcadate = "(EXP) " + registry.ASSMCAExpDate.Trim();
                    }
                }
                else
                    assmcadate = "X";
                //if (registry.TribunalExpDate != "")
                //{
                //    compareResultTribunal = DateTime.Compare(DateTime.Parse(registry.TribunalExpDate.Trim()), DateTime.Now);

                //    if (compareResultTribunal < 0)
                //    {
                //        tribunaldate = "(EXP) " + registry.TribunalExpDate.Trim();
                //    }
                //}
                //else
                //    tribunaldate = "X";
                if (registry.JuntaLicenciamiento == true)
                {
                    juntaLicenciamiento = "";
                }
                else
                {
                    juntaLicenciamiento = "X";
                }
                
                if (registry.CDMExpDate != "")
                {
                    compareResultCDM = DateTime.Compare(DateTime.Parse(registry.CDMExpDate.Trim()), DateTime.Now);

                    if (compareResultCDM < 0)
                    {
                        cdmdate = "(EXP) " + registry.CDMExpDate.Trim();
                    }
                }
                else
                    cdmdate = "X";
                if (registry.GoodStandingExpDate != "")
                {
                    compareResultGS = DateTime.Compare(DateTime.Parse(registry.GoodStandingExpDate.Trim()), DateTime.Now);

                    if (compareResultGS < 0)
                    {
                        gstandingdate = "(EXP) " + registry.GoodStandingExpDate.Trim();
                    }
                }
                else
                    gstandingdate = "X";
                if (registry.LicenseExpDate != "")
                {
                    compareResultLicense = DateTime.Compare(DateTime.Parse(registry.LicenseExpDate.Trim()), DateTime.Now);

                    if (compareResultLicense < 0)
                    {
                        licenseexpdate = "(EXP) " + registry.LicenseExpDate.Trim();
                    }
                }
                else
                    licenseexpdate = "X";
                if (registry.DEAExpDate != "")
                {
                    compareResultDEA = DateTime.Compare(DateTime.Parse(registry.DEAExpDate.Trim()), DateTime.Now);

                    if (compareResultDEA < 0)
                    {
                        deadate = "(EXP) " + registry.DEAExpDate.Trim();
                    }
                }
                else
                    deadate = "X";
                if (!registry.CV)
                {
                    tp6 = "X";
                }

                if (compareResultASSMCA > 0 && compareResultTribunal > 0 && compareResultCDM > 0 && compareResultGS > 0 && compareResultLicense > 0 && compareResultDEA > 0)
                    return mergePaths;

                #endregion

                ReportParameter p1 = new ReportParameter("ASSMCADate", assmcadate);
                ReportParameter p2 = new ReportParameter("JuntaLicenciamiento", juntaLicenciamiento);
                ReportParameter p3 = new ReportParameter("CDMDate", cdmdate);
                ReportParameter p4 = new ReportParameter("GStandingDate", gstandingdate);
                ReportParameter p5 = new ReportParameter("LicenseExpDate", licenseexpdate);
                ReportParameter p6 = new ReportParameter("CVDate", tp6);
                ReportParameter p7 = new ReportParameter("DEADate", deadate);

                ReportParameter p8 = new ReportParameter("Asegurado", taskControl.Customer.FirstName + " " + taskControl.Customer.Initial + " " + taskControl.Customer.LastName1 + " " + taskControl.Customer.LastName2);
                ReportParameter p9 = new ReportParameter("PolizaNo", taskControl.PolicyType.Trim() + "-" + taskControl.PolicyNo);

                LookupTables.Agency agency = new LookupTables.Agency();

                agency = agency.GetAgency(taskControl.Agency);

                ReportParameter p10 = new ReportParameter("Agency", agency.AgencyDesc);

                LookupTables.Agent agent = new LookupTables.Agent();

                agent = agent.GetAgent(taskControl.Agent);

                ReportParameter p11 = new ReportParameter("Productor", agent.AgentDesc);
                ReportParameter p12 = new ReportParameter("EffDt", taskControl.EffectiveDate);

                DataTable DtTask = TaskControl.TaskControl.GetTaskControlByCustomerNo(taskControl.Customer.CustomerNo);
                bool validate = true;

                for (int i = 0; i < DtTask.Rows.Count; i++)
                {
                    if (DtTask.Rows[i][1].ToString().Trim() == "PP")
                        validate = false;
                }

                ReportParameter p13 = new ReportParameter();

                if (validate)
                    p13 = new ReportParameter("EntryDt", "X");
                else
                    p13 = new ReportParameter("EntryDt", "");



                agent = agent.GetAgent(taskControl.Agent);

                viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13 });
                viewer.LocalReport.Refresh();

                // Variables 
                Warning[] warnings;
                string[] streamIds;
                string mimeType;
                string encoding = string.Empty;
                string extension;
                string _FileName = "Registry-" + registry.RegistryID.ToString().Trim() + ".pdf";

                if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                    File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }

                mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);
                return mergePaths;
            }
            catch (Exception ex)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(ex.Message + " " + ex.InnerException + " " + ex.Source);
                this.litPopUp.Visible = true;
                return mergePaths;
            }
        }

        private string ImprimirCartaDeptDefensa()
        {
            try
            {
                TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];
                Customer.Registry registry = Customer.Registry.GetRegistryByCustomerNo(int.Parse(taskControl.CustomerNo));
                ReportViewer viewer = new ReportViewer();

                viewer.LocalReport.DataSources.Clear();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportPath = Server.MapPath("Reports/Carta_Dept_Defensa.rdlc");

                // Variables 
                Warning[] warnings;
                string[] streamIds;
                string mimeType;
                string encoding = string.Empty;
                string extension;
                string _FileName = "CDD-" + registry.RegistryID.ToString().Trim() + ".pdf";

                if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                    File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }

                return _FileName;
            }
            catch (Exception exp)
            {
                return "";
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
			Response.AddHeader("Content-Disposition", "attachment; filename="+ myFile.Name.Replace(".resources",""));
			Response.AddHeader("Content-Length", myFile.Length.ToString());
			Response.ContentType = "application/octet-stream";

			Response.Flush();
			
			Response.WriteFile(myFile.FullName);
			Response.Flush();			
			Response.End();
		}

		private void SendEmail(string filename)
		{
			Session.Add("FileNameEmail",filename);

			string js = "<script language=javascript> javascript:popwindow=window.open('FollowUp.aspx','popwindow','toolbar=no,location=center,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,copyhistory=no,width=734,height=425');popwindow.focus(); </script>";
			Response.Write(js);
		}

		protected void rblReports_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void BtnExit_Click(object sender, System.EventArgs e)
		{
			Session.Remove("Report");
			Session.Remove("FromPage");
			ReturnToReferringPage();
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			if(Valid())
			{
				ExportFile(false);
			}
			else
			{
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Please select one report format.");
				this.litPopUp.Visible = true;
			}
		}

		private void btn_Download_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		
		}

		protected void btnEMail_Click(object sender, System.EventArgs e)
		{
			if(Valid())
			{
				ExportFile(true);
			}
			else
			{
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Please select one report format.");
				this.litPopUp.Visible = true;
			}
		}
        private string imprimirF102B(string rdlcReport)
        {
            TaskControl.TaskControl taskControl = (TaskControl.TaskControl)Session["TaskControl"];
            ReportViewer viewer = new ReportViewer();

            viewer.LocalReport.DataSources.Clear();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = Server.MapPath("Reports/" + rdlcReport + ".rdlc");
            viewer.LocalReport.Refresh();

            Warning[] warnings;
            string[] streamIds;
            string mimeType;
            string encoding = string.Empty;
            string extension;
            string _FileName = rdlcReport + taskControl.TaskControlID + ".pdf";

            if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

            byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }

            return System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName;
        }

        private void CreateCSV(DataTable dt, string filename,string report)
        {
            if (report == "PremiumWritten")
            {
                dt.Columns.Add("Net", typeof(string));
                dt.Columns[dt.Columns.Count - 1].SetOrdinal(21);
            }


            StringBuilder sb = new StringBuilder();
            DataTable dtPolicyClass = LookupTables.LookupTables.GetTable("PolicyClass");

            DataColumnCollection Colums = dt.Columns;
            string[] columnNames= new string[Colums.Count];
            int Ending_Index = 0;
            for (int i = 0; i < Colums.Count; i++)
            {
                if (Colums[i].ColumnName.ToUpper().Trim() == "POLICYCLASSID" && report == "PremiumWritten")
                {
                    Ending_Index = i;
                    i = Colums.Count;
                }
                else
                {
                    columnNames[i] = Colums[i].ColumnName;
                    Ending_Index = i;
                }
            }

            if (report != "PremiumWritten")
            {
                Ending_Index += 1; 
            }

            sb.AppendLine(string.Join(",", columnNames));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string[] fields = new string[Ending_Index]; //Ending_Index = solo hasta la ultima olumna del reporte // dt.Columns.Count el data set completo
                for (int j = 0; j < Ending_Index; j++) //Ending_Index = solo hasta la ultima olumna del reporte // dt.Columns.Count el data set completo
                {
                    //if (PolicyClassID_Index == j)
                    //{
                    //    for (int x = 0; x < dtPolicyClass.Rows.Count; x++)
                    //    {
                    //        if (dtPolicyClass.Rows[x]["PolicyClassID"].ToString() == dt.Rows[i][j].ToString().Trim().Replace(",", ""))
                    //        {
                    //            fields[j] = dtPolicyClass.Rows[x]["PolicyClassDesc"].ToString().Trim();
                    //        }
                    //    }
                    //}
                    //else
                    {
                        fields[j] = dt.Rows[i][j].ToString().Trim().Replace(",", "");
                    }
                    
                }
                sb.AppendLine(string.Join(",", fields));
            }


            File.WriteAllText(filename, sb.ToString());
        }

        private void ExportDataSet(DataSet ds, string destination)
        {
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
                            if (table.Columns[i].ColumnName == "TotalPremium" || table.Columns[i].ColumnName == "CyberEndorsementPremium" || table.Columns[i].ColumnName == "PaidAmount" || table.Columns[i].ColumnName == "CancellationAmount")
	                            {
                                    cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue((string.Format("{0:C}", decimal.Parse(dsrow[i].ToString()))).Replace("$","")); //
	                            }
                            else
                                cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[i].ToString()); 

                            newRow.AppendChild(cell);
                        }

                        sheetData.AppendChild(newRow);
                    }

                }
            }
        }
	}
}
