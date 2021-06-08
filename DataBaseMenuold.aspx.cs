using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Xml;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using EPolicy.TaskControl;
using EPolicy.XmlCooker;
using Baldrich.DBRequest;
using EPolicy.Audit;
//using OPPReport;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using Microsoft.Reporting.WebForms;
using System.IO;

public partial class DataBaseMenu : System.Web.UI.Page
{

    #region Variables

//    private DailyTransactionLimiter dtl;
    private HttpApplicationState app;
    private static string aesServer = ConfigurationManager.AppSettings["ConnectionString"];
    private static string aesPort   = "7500"; //ConfigurationManager.AppSettings["DefaultServerPort"];
    
    #endregion

    #region Protected Methods

    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        //InitializeComponent();
        base.OnInit(e);

        //Control Banner = new Control();
        //Banner = LoadControl(@"TopBanner.ascx");
        //this.phTopBanner.Controls.Add(Banner);

        //if (Page.IsPostBack)
        //{
        //    if (Session["TaskControl"] == null)
        //    {
        //        Response.Redirect("Default.aspx?007");
        //    }
        //}

        //if (Session["LookUpTables"] == null)
        //{
        //    EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        //    int userID = 0;
        //    if (cp != null)
        //        userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

        //    EPolicy.TaskControl.DataBaseMenu taskControl = (EPolicy.TaskControl.DataBaseMenu)Session["TaskControl"];

        //    Session.Add("LookUpTables", "In");
        //}
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        app = HttpContext.Current.Application;

        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;

        if (cp == null)
        {
            Response.Redirect("Default.aspx?001");
        }
        else
        {
            if (!cp.IsInRole("ADMINISTRATOR"))
            {
                Response.Redirect("Default.aspx?001");
            }
        }
    }

    protected void BtnExecute_Click(object sender, EventArgs e)
    {
        try
        {
            System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);//(txtConnectionString.Text.Trim());
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader reader;

            if (txtQuery.Text == "")
            {
                throw new Exception("Missing query.");
            }
            else
            {
                cmd.CommandText = txtQuery.Text.Trim();
            }

            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            List<string> _items = new List<string>();
            List<string> _itemsForGrid = new List<string>();
            string values = "";
            int count = 0;

            DataTable dt = new DataTable();
            DataTable dt1 = dt;

            //Adds columns to the DT depending on how many columns the query brings
            for (int i = 0; i < reader.FieldCount; i++)
            {
                //dt.Columns.Add("Column" + i, typeof(String));
                dt.Columns.Add(reader.GetName(i).ToString(), typeof(String));
            }

            while (reader.Read())
            {
                _items.Add("[Row# " + count + "]");
                //_itemsForGrid.Add("[Row# " + count + "]");

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    _items.Add("[" + reader.GetFieldType(i).ToString() + "] " + reader.GetName(i).ToString() + ": " + reader[i].ToString());
                    _itemsForGrid.Add(reader[i].ToString());
                }

                _items.Add("");
                _itemsForGrid.Add("end");

                ListBox1.DataSource = _items;
                ListBox1.DataBind();

                count++;
            }

            int cont = 0;

            for (int i = 0; i < count; i++)
            {
                int colCount = 0;

                dt.Rows.Add();

                while (_itemsForGrid[colCount] != "end")
                {
                    dt.Rows[i][colCount] = _itemsForGrid[cont]; 
                    colCount++;
                    cont++;
                }
                cont++;
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            sqlConnection1.Close();
        }
        catch (Exception exp)
        {
            lblRecHeader.Text = "Unable to execute. " + exp.Message;
            mpeSeleccion.Show();
        }
    }

    protected void BtnExit_Click(object sender, EventArgs e)
    {
        RemoveSessionLookUp();
        Session.Clear();
        Response.Redirect("Default.aspx");
    }

    #endregion

    #region Private Methods

    private void RemoveSessionLookUp()
    {
        Session.Remove("LookUpTables");
    }

    #endregion
}
