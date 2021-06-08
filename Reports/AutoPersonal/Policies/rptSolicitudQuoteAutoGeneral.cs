using System;
using System.Configuration;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.TaskControl;
using EPolicy.Quotes;
using EPolicy.LookupTables;
using EPolicy;
using EPolicy.Login;
using System.Web;

namespace EPolicy2.Reports
{
    /// <summary>
    /// Summary description for rptSolicitudQuoteAutoGeneral.
    /// </summary>
    public partial class rptSolicitudQuoteAutoGeneral : DataDynamics.ActiveReports.ActiveReport3
    {

        public rptSolicitudQuoteAutoGeneral(EPolicy.TaskControl.QuoteAuto taskcontrol, string copyValue)
        {
            try
            {
 
                InitializeComponent();

                Login cp = HttpContext.Current.User as Login;
                string filename = cp.Identity.Name.Split("|".ToCharArray())[0].ToString().Trim().Replace(" ", "") + ".bmp";
                filename = "C:\\Inetpub\\wwwroot\\Optima\\Sign\\" + filename;

                if (System.IO.File.Exists(filename))
                {
                    Picture p = (Picture)picture1;
                    picture1.Image = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(filename);
                }
            }
            catch (Exception xcp)
            {
                string a = xcp.Message;
            }
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {

        }
    }
}
