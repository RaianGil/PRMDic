using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Web;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy;
using EPolicy.Login;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for Requisitos1.
    /// </summary>
    public partial class Requisitos : DataDynamics.ActiveReports.ActiveReport3
    {
        public Requisitos()
        {
            InitializeComponent();

            Login cp = HttpContext.Current.User as Login;
            string filename = cp.Identity.Name.Split("|".ToCharArray())[0].ToString().Trim().Replace(" ", "") + "2.bmp";
            filename = "C:\\Webs\\prmdic.net\\Sign\\" + filename;

            if (System.IO.File.Exists(filename))
            {
                GC.Collect();
                Picture p = (Picture)picture2;
                picture2.Image = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(filename);
                GC.Collect();
                //System.IO.File.Delete(filename);
            }
        }
    }
}
