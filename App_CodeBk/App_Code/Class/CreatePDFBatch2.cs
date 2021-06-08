using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace EPolicy
{
    public class CreatePDFBatch2
    {
        public CreatePDFBatch2()
        {

        }

        public string AppendTextToPDF(string ProcessedPath, string ClientName, string finalFile)
        {
            try
            {
                List<string> mergePaths = new List<string>();
                
                string NewFilePath = Path.Combine(ProcessedPath, finalFile + "_new.pdf");
                PdfReader reader = new PdfReader(ProcessedPath + finalFile);
                FileStream fs = new FileStream(NewFilePath, FileMode.Append, FileAccess.Write);
                PdfStamper stamper = null;
                stamper = new PdfStamper(reader, fs);
                


                for (int i = 2; i <= reader.NumberOfPages; i++)
                {
                    PdfContentByte cb = stamper.GetUnderContent(i);
                    cb.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, false), 10f);
                    cb.BeginText();

                   

                   
                        cb.ShowTextAligned(1, "Page " + (i - 1) + " of " + (reader.NumberOfPages - 1).ToString(), 552, 40, 0);

                   
                    
                    cb.EndText();
                }
                   
                    stamper.FormFlattening = true;
                    stamper.Writer.CloseStream = false;
                    stamper.Close();
                    reader.Close();
                    fs.Close();


                    mergePaths.Add(NewFilePath);
                   
               


                // Call the merge function               
                string mergePath = MergePDFFiles(mergePaths, ProcessedPath, ClientName);
                // result = true;
                return mergePath;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error", ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public string MergePDFFiles(List<string> mergePaths, string ProcessedPath, string CustomerName)
        {
            Document document = new Document(PageSize.LETTER);
            string onlyFileName = CustomerName + " " + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year
                /*DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + +DateTime.Now.Second +*/ + ".pdf";

            string destinationBatchfile = Path.Combine(ProcessedPath, onlyFileName);
            bool result = false;
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(destinationBatchfile, FileMode.Create));
                document.Open();

                PdfContentByte cb = writer.DirectContent;
                PdfImportedPage page;
                int n = 0;
                int rotation = 0;

                foreach (string filename in mergePaths)
                {
                    PdfReader reader = new PdfReader(filename);

                    n = reader.NumberOfPages;
                    int i = 0;

                    while (i < n)
                    {
                        i++;
                        document.SetPageSize(reader.GetPageSizeWithRotation(1));
                        document.NewPage();
                        //Insert to Destination on the first page
                        if (i == 1)
                        {
                            Chunk fileRef = new Chunk(" ");
                            fileRef.SetLocalDestination(filename);
                            document.Add(fileRef);
                        }

                        page = writer.GetImportedPage(reader, i);
                        rotation = reader.GetPageRotation(i);

                        if (rotation == 90 || rotation == 270)
                        {
                            cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                        }
                        else
                        {
                            cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                        }
                        document.SetPageSize(PageSize.LETTER);
                    }
                   // reader.Close();
                }
                //close the batch file
                document.Close();

                foreach (var path in mergePaths)
                { File.Delete(path); }
                // result = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return onlyFileName;
        }
    }
}
