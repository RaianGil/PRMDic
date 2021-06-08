using System;
using WebMail = System.Web.Mail;
using System.Configuration;
using System.IO;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.UI;

namespace EPolicy.TaskControl
{
    /// <summary>
    /// Summary description for Mail.
    /// </summary>
    public class Mail
    {
        public Mail()
        {

        }

        //private string _PDFPathName = ConfigurationSettings.AppSettings["PDFPathName"];
        private string _MailFrom = "";
        private string _MailTo = "";
        private string[] _MailToCollection;
        private string _MailSubject = "";
        private string _MailBody = "";
        private ListBox _MailAttach = null;
        private bool _fail = false;
        private string _MailAttachment = null;

        #region Properties

        public string MailFrom
        {
            get
            {
                return (string)_MailFrom;
            }
            set
            {
                _MailFrom = value;
            }
        }

        public string MailTo
        {
            get
            {
                return (string)_MailTo;
            }
            set
            {
                _MailTo = value;
            }
        }

        public string[] MailToCollection
        {
            get
            {
                return _MailToCollection;
            }
            set
            {
                _MailToCollection = value;
            }
        }


        public string MailSubject
        {
            get
            {
                return (string)_MailSubject;
            }
            set
            {
                _MailSubject = value;
            }
        }

        public ListBox MailAttach
        {
            get
            {
                return _MailAttach;
            }
            set
            {
                _MailAttach = value;
            }
        }

        public string MailAttachment
        {
            get
            {
                return _MailAttachment;
            }
            set
            {
                _MailAttachment = value;
            }
        }

        public string MailBody
        {
            get
            {
                return (string)_MailBody;
            }
            set
            {
                _MailBody = value;
            }
        }

        public bool fail
        {
            get
            {
                return (bool)_fail;
            }
            set
            {
                _fail = value;
            }
        }

        #endregion

        private void SendMailExample()
        {
            //Set Mailer = Server.CreateObject("SMTPsvg.Mailer")

            //Mailer.RemoteHost  = "mail.phcpr.com"
            //
            //Mailer.FromName    = "Webserver Form"
            //Mailer.FromAddress = "webserver@phcpr.com"
            //Mailer.AddRecipient "Victor Lanza", "victor@phcpr.com"
            //Mailer.Subject     = "Contact Us Page has been submitted"
            //
            //strMsgHeader = "Form Information Follows: " & vbCrLf
            //for i = 1 to Request.Form.Count
            //  strMsgInfo = strMsgInfo & Request.Form.Key(i) & " - " &  Request.Form.Item(i) & vbCrLf
            //next
            //strMsgFooter = vbCrLf & "End of form information"
            //Mailer.BodyText = strMsgHeader & strMsgInfo & strMsgFooter
            //
            //if not Mailer.SendMail then
            //  Response.Write " Mailing Failed... Error is: <br>"
            //  Response.Write Mailer.Response
            //else
            //  Response.redirect "/thankyou.htm"
            //end if
        }

            //string strMailContent = "Welcome new user";
            //string fromAddress = "yourname@yoursite.com";
            //string toAddress = "newuser@hisdomain.com";
            //string contentId = "image1";
            //string path = Server.MapPath(@"images/Logo.jpg"); // my logo is placed in images folder
            //MailMessage mailMessage = new MailMessage(fromAddress, toAddress);
            //mailMessage.Bcc.Add("inkrajesh@hotmail.com"); // put your id here
            //mailMessage.Subject = "Welcome new User";


            //LinkedResource logo = new LinkedResource(path);
            //logo.ContentId = "companylogo";
            //// done HTML formatting in the next line to display my logo
            //AlternateView av1 = AlternateView.CreateAlternateViewFromString("<html><body><img src=cid:companylogo/><br></body></html>" + strMailContent, null, MediaTypeNames.Text.Html);
            //av1.LinkedResources.Add(logo);


            //mailMessage.AlternateViews.Add(av1);
            //mailMessage.IsBodyHtml = true;
            //SmtpClient mailSender = new SmtpClient("localhost"); //use this if you are in the development server
            //mailSender.Send(mailMessage);

        public string SendMail()
        {
            string msg = "";
            WebMail.MailMessage mailMessage = new WebMail.MailMessage();

            mailMessage.From = MailFrom;
            mailMessage.To = MailTo;
            mailMessage.Subject = MailSubject;
            mailMessage.Body = MailBody;
            mailMessage.BodyFormat = WebMail.MailFormat.Text;

            WebMail.MailAttachment attachment = null;
            // check to see if there are any attachments or not
            //if (MailAttach.Items.Count > 0)
            //{
            //    foreach (ListItem l in MailAttach.Items)
            //    {
            //        // Attaches a new attachment contained in the List
            //        Page page = new Page();
            //        attachment = new WebMail.MailAttachment(@"\attach\" + l.Text);
            //        mailMessage.Attachments.Add(attachment);
            //        //													
            //        //					//Console.Write("\nPlease enter the URL to post data to : ");
            //        //					string uriString = "\\victorlanza"; //Console.ReadLine();
            //        //					WebClient myWebClient = new WebClient();
            //        //					string fileName = l.Text.Trim();  //Console.ReadLine();
            //        //					//Console.WriteLine("Uploading {0} to {1} ...",fileName,uriString);                  
            //        //					// Upload the file to the URL using the HTTP 1.0 POST.
            //        //					byte[] responseArray = myWebClient.UploadFile(uriString,"POST",fileName);
            //        //					// Decode and display the response.
            //        //					//Console.WriteLine("\nResponse Received.The contents of the file uploaded are: \n{0}",Encoding.ASCII.GetString(responseArray));
            //    }
            //}


            try
            {
                //mail.prmdic.net
                string IPMail = "smtp.gmail.com";//"mail.puertoricohosting.com";  //ConfigurationSettings.AppSettings["SMTPMail"];
                WebMail.SmtpMail.SmtpServer = IPMail; //"Baexch";  "12.174.230.85";
                WebMail.SmtpMail.Send(mailMessage);

                msg = "Message has been sent successfully.";
            }
            catch (Exception exc)
            {
                msg = exc.InnerException.ToString() + " " + exc.Message;
            }

            return msg;
        }

        /*public string SendHTMLMail() 
        {
            string msg = "";
            WebMail.MailMessage mailMessage = new WebMail.MailMessage();
            
            fail = false;

            mailMessage.To = MailTo;
            mailMessage.From = MailFrom;
            mailMessage.Subject = MailSubject;
            mailMessage.BodyFormat = WebMail.MailFormat.Html;
            mailMessage.Body = MailBody;
            mailMessage.Attachments.Add(MailAttachment);

            try
            {
                //mail.prmdic.net
                string IPMail = "mail.puertoricohosting.com";  //ConfigurationSettings.AppSettings["SMTPMail"];
                WebMail.SmtpMail.SmtpServer = IPMail; //"Baexch";  "12.174.230.85";
                WebMail.SmtpMail.Send(mailMessage);

                msg = "Message has been sent successfully.";
                
            }
            catch (Exception exc)
            {   
                fail = true;
                msg = exc.InnerException.ToString() + " " + exc.Message;
            }

            return msg;
        }*/

        public string SendHTMLMail()
        {
            string msg = "";
            MailMessage mailMessage = new MailMessage();
            fail = false;
            string html = @"<html><body><img src=" + "cid:companyLogo" + " width=" + "142" + " height=" + "72" + ">" + "\r\n" +
            "<p>" + "\r\n" +
                "<span style=" + "font-size:10px;" + ">Este es un mensaje enviado por el Sistema Autom&aacute;tico de mensaje de ePMS.</span></p>" + "\r\n" +
            "<p>" + "\r\n" +
                "<br />" + "\r\n" +
                "<span style=" + "font-size:10px;" + "><strong>AVISO DE CONFIDENCIALIDAD</strong>: Esta comunicaci&oacute;n contiene&nbsp; informacion&nbsp; propiedad&nbsp; de&nbsp; Puerto Rico Medical Defense Insurance Company clasificada como privilegiada, confidencial y exenta de divulgaci&oacute;n. La informaci&oacute;n es para uso exclusivo del individuo o entidad a quien est&aacute; dirigida. Si usted no es el destinatario, el empleado o el agente a quien se&nbsp; le&nbsp; confi&oacute; la responsabilidad de hacer llegar el mensaje al destinatario, debe percatarse que la divulgaci&oacute;n, copia, distribuci&oacute;n o accion tomaba basada en el contenido de esta transmisi&oacute;n est&aacute; estrictamente prohibida. Si ha recibido esta comunicaci&oacute;n por error,&nbsp; favor de borrarla&nbsp; y&nbsp; notificar al remitente inmediatamente.&nbsp; Cualquier uso indebido&nbsp; de&nbsp; la&nbsp; informaci&oacute;n contenida&nbsp; en&nbsp; este mensaje ser&aacute; sancionado bajo las leyes aplicables.</span></p>" + "\r\n" +
            "<p>" + "\r\n" +
                "<br />" + "\r\n" +
                "<span style=" + "font-size:10px;" + "><strong>CONFIDENTIALITY NOTE</strong>: This communication and any attachments here to contain information property&nbsp; of&nbsp; Puerto Rico Medical Defense Insurance Company, classified as privileged, confidential and exempt from disclosure. The information is intended solely&nbsp; for the use of the individual&nbsp; or&nbsp; entity to which it is addressed.&nbsp; If you&nbsp; are&nbsp; not the intended&nbsp; recipient&nbsp; or&nbsp; the&nbsp; employee or agent entrusted with the responsibility of delivering the message&nbsp; to&nbsp; the intended recipient,&nbsp; be aware that any disclosure,&nbsp; copying, distribution&nbsp; or&nbsp; action taken in based on the contents&nbsp; of&nbsp; this transmission&nbsp; is&nbsp; strictly&nbsp; prohibited. If&nbsp; you&nbsp; have received this communication by mistake,&nbsp; please&nbsp; delete and notify&nbsp; the&nbsp; sender&nbsp; immediately.&nbsp; Any unauthorized&nbsp; use&nbsp; of&nbsp; the information contained herein will be sanctioned under applicable laws.</span></p>" + "\r\n" +
            "<hr />" + "\r\n" +
           "</body></html>";

            mailMessage.To.Add(MailTo);
            mailMessage.Subject = MailSubject;
            mailMessage.Attachments.Add(new Attachment(MailAttachment));
            mailMessage.Body += html;

            AlternateView av = AlternateView.CreateAlternateViewFromString(mailMessage.Body, new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Html));
            av.TransferEncoding = System.Net.Mime.TransferEncoding.SevenBit;
            LinkedResource logo = new LinkedResource("C:\\Inetpub\\wwwroot\\PRMDic\\Images2\\PRMEDICALNEWLOGO.jpg", MediaTypeNames.Image.Jpeg);
            logo.ContentId = "companyLogo";
            av.LinkedResources.Add(logo);
            mailMessage.AlternateViews.Add(av);

            try
            {
                //mail.prmdic.net
                /*string IPMail = "mail.puertoricohosting.com";  //ConfigurationSettings.AppSettings["SMTPMail"];
                WebMail.SmtpMail.SmtpServer = IPMail; //"Baexch";  "12.174.230.85";
                WebMail.SmtpMail.Send(mailMessage);*/

                SmtpClient client = new SmtpClient();
                client.Send(mailMessage);

                msg = "Message has been sent successfully.";

            }
            catch (Exception exc)
            {
                fail = true;
                msg = exc.InnerException.ToString() + " " + exc.Message;
            }

            return msg;
        }
    }
}
