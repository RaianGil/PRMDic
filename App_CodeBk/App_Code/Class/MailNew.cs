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
using System.Security.AccessControl;
using System.Collections.Generic;

namespace EPolicy
{
    /// <summary>
    /// Summary description for Mail.
    /// </summary>
    public class MailNew
    {
        public MailNew()
        {

        }

        //private string _PDFPathName = ConfigurationSettings.AppSettings["PDFPathName"];
        private string _MailFrom = "";
        private string _MailTo = "";
        private string[] _MailToCollection;
        private List<string> _MailToCollection2;
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
        public List<string> MailToCollection2
        {
            get
            {
                return _MailToCollection2;
            }
            set
            {
                _MailToCollection2 = value;
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

        public string SendHTMLMailforGotPassword(string email)
        {
            string msg = "";
            MailMessage mailMessage = new MailMessage();
            fail = false;

            //EncryptClass.EncryptClass encrypt = new EncryptClass.EncryptClass();
            string encryptST = email.ToString();
            string url = ConfigurationManager.AppSettings["URL"].ToString().Trim();     

            string html = @"<html><body>"+
            "<div align="+"center"+">"+
            "<br /> <br /><br /><br />"+
            "<img src=" + "cid:companyLogo" + " width=" + "200" + " height=" + "35" + ">" +
            "<br /><br />"+
            "<p style=" + "font-family:Helvetica;font-size:30px;color:Black;" + ">Desea cambiar su contrase&ntilde;a?</p>" + 
            "<br />"+
            "<a href=" + url + "/ConfirmPassword.aspx?Jjxg6hdj98dlqo9542u0908gVa=" + encryptST + "><img src=" + "cid:btnChangePassword" + " width=" + "225px" + " height=" + "50px" + "></a>" +
            "<br /><br /><br /><br />"+
            "<img src=" + "cid:GreyLine" + " width=" + "350x" + " height=" + "4px" + ">" +
            "<p style=" + "font-family:Helvetica;font-size:10px;color:Black;" + "><a href=" + "https://www.google.com" + ">Cancelar suscripci&oacute;n</a>" +
            "<br /><br />"+
             "Ver nuestra politica de privacidad. © 2016, Stop 'n View, Inc.<br /><br /></p>" +
            "<br /><br />"+
            "</div>"+
            "</body></html>";
            
            mailMessage.To.Add(MailTo);
            mailMessage.From = new System.Net.Mail.MailAddress(MailFrom);
            mailMessage.Subject = MailSubject;

            // if(MailAttachment.Trim()!="")
            // mailMessage.Attachments.Add(new Attachment(MailAttachment));
            mailMessage.Body = MailBody + "\r\n";
            mailMessage.Body += html;

            AlternateView av = AlternateView.CreateAlternateViewFromString(mailMessage.Body, new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Html));
            av.TransferEncoding = System.Net.Mime.TransferEncoding.SevenBit;
            LinkedResource logo = new LinkedResource(ConfigurationManager.AppSettings["ImagePathName"].ToString().Trim() + "StopnViewGreen.png", MediaTypeNames.Image.Jpeg);
            logo.ContentId = "companyLogo";
            av.LinkedResources.Add(logo);
            //mailMessage.AlternateViews.Add(av);

            LinkedResource logo2 = new LinkedResource(ConfigurationManager.AppSettings["ImagePathName"].ToString().Trim() + "BtnChangePassword.png", MediaTypeNames.Image.Jpeg);
            logo2.ContentId = "btnChangePassword";
            av.LinkedResources.Add(logo2);
            //mailMessage.AlternateViews.Add(av);

            LinkedResource logo3 = new LinkedResource(ConfigurationManager.AppSettings["ImagePathName"].ToString().Trim() + "GreyLine.png", MediaTypeNames.Image.Jpeg);
            logo3.ContentId = "GreyLine";
            av.LinkedResources.Add(logo3);
            mailMessage.AlternateViews.Add(av);

            try
            {                
                string emailNoreplay = ConfigurationManager.AppSettings["EmailNoReplay"].ToString().Trim(); // "mail.puertoricohosting.com";
                string emailNoreplayPass = ConfigurationManager.AppSettings["EmailNoReplayPass"].ToString().Trim(); // "mail.puertoricohosting.com";

                SmtpClient client = new SmtpClient();
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(emailNoreplay, emailNoreplayPass);
                client.Host = ConfigurationManager.AppSettings["IPMail"].ToString().Trim();    //client.Host = "smtp.gmail.com";
                client.Port = 587; // 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(mailMessage);
                msg = "0001";
            }
            catch (Exception exc)
            {
                fail = true;
                msg = exc.InnerException.ToString() + " " + exc.Message;
            }

            return msg;
        }

        public string SendHTMLMailNewRegister(int IndID, List<string> emailList, string pdfName)
        {
            string msg = "";
            MailMessage mailMessage = new MailMessage();
            fail = false;

           // EncryptClass.EncryptClass encrypt = new EncryptClass.EncryptClass();
            string encryptST = IndID.ToString();
            //string url = ConfigurationManager.AppSettings["URL"].ToString().Trim();          

            //string html = @"<html><body>" +
            //"<div align=" + "center" + ">" +
            //"<br /> <br /><br /><br />" +
            //"<img src=" + "cid:companyLogo" + " width=" + "200" + " height=" + "35" + ">" +
            //"<br /><br />" +
            //"<p style=" + "font-family:Helvetica;font-size:30px;color:Black;" + ">Stop 'n View le da la m&aacute;s cordial bienvenida a ser parte de nuestro equipo y gozar de los descuentos ofrecidos por nuestros socios de negocios.</p>" +
            //"<br /><br />" +
            // "<p style=" + "font-family:Helvetica;font-size:30px;color:Black;" + ">Y participar diariamente en certificados de regalos.</p>" +
            //"<br /><br />" +
            //"<p style=" + "font-family:Helvetica;font-size:30px;color:Black;" + ">Para validar y activar su cuenta, y poder recibir las ofertas, favor de oprimir el bot&oacute;n de abajo.</p>" +
            //"<br />" +
            //"<a href=" + url + "/CuentaIndActiva.aspx?Jjxg6hdj98dlqo9542u0908gVa=" + encryptST + "><img src=" + "cid:BtnActivarCuenta" + " width=" + "225px" + " height=" + "50px" + "></a>" +
            //"<br /><br /><br /><br />" +
            //"<img src=" + "cid:GreyLine" + " width=" + "350x" + " height=" + "4px" + ">" +
            //"<p style=" + "font-family:Helvetica;font-size:10px;color:Black;" + "><a href=" + "https://www.google.com" + ">Cancelar suscripci&oacute;n</a>" +
            //"<br /><br />" +
            //"Ver nuestra politica de privacidad. © 2016, Stop 'n View, Inc.<br /><br /></p>" +
            //"<br /><br />" +
            //"</div>" +
            //"</body></html>";
            for (int i = 0; i < MailToCollection2.Count; i++)
            {
                mailMessage.To.Add(MailToCollection2[i].ToString());
            }
            
            mailMessage.From = new System.Net.Mail.MailAddress(MailFrom);
            mailMessage.Subject = MailSubject;

            // if(MailAttachment.Trim()!="")
            // mailMessage.Attachments.Add(new Attachment(MailAttachment));
           // mailMessage.Body = MailBody + "\r\n";
            mailMessage.Body += "";//html;
            mailMessage.Attachments.Add(new Attachment(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + pdfName));
            //AlternateView av = AlternateView.CreateAlternateViewFromString(mailMessage.Body, new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Html));
            //av.TransferEncoding = System.Net.Mime.TransferEncoding.SevenBit;
            //LinkedResource logo = new LinkedResource(ConfigurationManager.AppSettings["ImagePathName"].ToString().Trim() + "StopnViewGreen.png", MediaTypeNames.Image.Jpeg);
            //logo.ContentId = "companyLogo";
            //av.LinkedResources.Add(logo);
            ////mailMessage.AlternateViews.Add(av);

            //LinkedResource logo2 = new LinkedResource(ConfigurationManager.AppSettings["ImagePathName"].ToString().Trim() + "BtnActivarCuenta.png", MediaTypeNames.Image.Jpeg);
            //logo2.ContentId = "BtnActivarCuenta";
            //av.LinkedResources.Add(logo2);
            ////mailMessage.AlternateViews.Add(av);

            //LinkedResource logo3 = new LinkedResource(ConfigurationManager.AppSettings["ImagePathName"].ToString().Trim() + "GreyLine.png", MediaTypeNames.Image.Jpeg);
            //logo3.ContentId = "GreyLine";
            //av.LinkedResources.Add(logo3);
            //mailMessage.AlternateViews.Add(av);

            try
            {
                string emailNoreplay = ConfigurationManager.AppSettings["EmailNotice"].ToString().Trim(); // "mail.puertoricohosting.com";
                string emailNoreplayPass = ConfigurationManager.AppSettings["EmailNoticePWD"].ToString().Trim(); // "mail.puertoricohosting.com";

                SmtpClient client = new SmtpClient();
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("lsemailservice@gmail.com", "L@nzasoft1$");
                client.Host = "smtp.gmail.com";//ConfigurationManager.AppSettings["IPMail"].ToString().Trim();    //client.Host = "smtp.gmail.com";
                client.Port = 587; // 25;
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(mailMessage);
                msg = "0001";
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
