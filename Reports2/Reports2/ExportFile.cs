using System;
using System.IO;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Export;
using DataDynamics.ActiveReports.Export.Pdf;
using DataDynamics.ActiveReports.Export.Html;
using DataDynamics.ActiveReports.Export.Rtf;
using DataDynamics.ActiveReports.Export.Text;
using DataDynamics.ActiveReports.Export.Tiff;
using DataDynamics.ActiveReports.Export.Xls;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Net;

namespace EPolicy2.Reports
{
	public class ExportFile
	{
		public ExportFile()
		{			
			
		}

		public void ExportToPDF(DataDynamics.ActiveReports.Document.Document doc, string pathPDF)
		{
			DataDynamics.ActiveReports.Export.Pdf.PdfExport xPDF= new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
			//DataDynamics.ActiveReports.Export.Rtf.RtfExport xPDF= new DataDynamics.ActiveReports.Export.Rtf.RtfExport();
			//PdfExport xPDF = new PdfExport();
			
			try 
			{				
				xPDF.Export(doc,@pathPDF);
			}
			catch(Exception exc)
			{
				string a = exc.Message;
			}	
		}

		public void ExportToExcel(DataDynamics.ActiveReports.Document.Document doc, string pathPDF)
		{
			//ExcelExport xExcel = new ExcelExport();
			DataDynamics.ActiveReports.Export.Xls.XlsExport xExcel= new DataDynamics.ActiveReports.Export.Xls.XlsExport();
			try 
			{				
				xExcel.Export(doc,@pathPDF);
			}
			catch(Exception exc)
			{
				string a = exc.Message;
			}	
		}
	}
}


