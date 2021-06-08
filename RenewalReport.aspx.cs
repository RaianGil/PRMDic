using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServerControls = System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using EPolicy2.Reports;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace EPolicy
{

    public partial class RenewalReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.litPopUp.Visible = false;

            Login.Login cp = HttpContext.Current.User as Login.Login;
            if (cp == null)
            {
                Response.Redirect("HomePage.aspx?001");
            }
            else
            {
                if (!cp.IsInRole("RENEWALREPORT") && !cp.IsInRole("ADMINISTRATOR") && !cp.IsInRole("REPORTRENEWAL"))
                {
                    Response.Redirect("HomePage.aspx?001");
                }
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

            Control Banner = new Control();
            Banner = LoadControl(@"TopBanner1.ascx");
            //((Baldrich.BaldrichWeb.Components.TopBanner)Banner).SelectedOption = (int)Baldrich.HeadBanner.MenuOptions.Home;
            this.Placeholder1.Controls.Add(Banner);

            //Setup Left-side Banner

            /*Control LeftMenu = new Control();
            LeftMenu = LoadControl(@"LeftReportMenu.ascx");
            //((Baldrich.BaldrichWeb.Components.MenuEventControl)LeftMenu).Height = "534px";
            phTopBanner1.Controls.Add(LeftMenu);*/
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion

        protected void BtnPrint_Click(object sender, System.EventArgs e)
        {
            try
            {
                FieldVerify();
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
                return;
            }

            switch (rblReportList.SelectedItem.Value)
            {
                case "0":
                    PoliciesPendingRenewal();
                    break;

                case "1":
                    RenewedPoliciesToPrint();
                    break;
            }
        }

        private void RenewedPoliciesToPrint()
        {
            try
            {
                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = 0;
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                //EPolicy2.Reports.AutoGuardServicesContractReport appAutoreport = new EPolicy2.Reports.AutoGuardServicesContractReport();
                DataTable dt = new DataTable();

                dt = ExecutePoliciesToPrint();


                Session.Add("RenewalPoliciesToPrint", dt);

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('RenewedPoliciesToPrintRDLC.aspx','Reports','addressbar=no,status=1,menubar=0,scrollbars=0,resizable=0,copyhistory=no,width=900,height=640');", true);


            }
            catch (Exception exp)
            {
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
            }
        }

        private void PoliciesPendingRenewal()
        {
            try
            {
                Login.Login cp = HttpContext.Current.User as Login.Login;
                int userID = 0;
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                //EPolicy2.Reports.AutoGuardServicesContractReport appAutoreport = new EPolicy2.Reports.AutoGuardServicesContractReport();
                DataTable dt = new DataTable();

                dt = ExecutePendingRenewalReport();
             

                Session.Add("RenewalPolicies", dt);

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('RenewalPoliciesRDLC.aspx','Reports','addressbar=no,status=1,menubar=0,scrollbars=0,resizable=0,copyhistory=no,width=900,height=640');", true);
                
                
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("" + exp.Message);
                this.litPopUp.Visible = true;
            }
        }


        //Renewed Policies To Ptrint Function
        protected DataTable ExecutePoliciesToPrint()
        {
            //string connString = "user id=prmdic;password=hLcoG28V;data source=sql2k5.prmdic.net;connect timeout=0;initial catalog=prmdic;";
            string connString = ConfigurationManager.ConnectionStrings["PRMDICConnectionString"].ToString();
            string sql = "GetRenewedPoliciesToPrint";
            DataTable dt = null;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand(sql, conn);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;

                        da.SelectCommand.Parameters.Add("@BegDate", SqlDbType.VarChar).Value = txtBegDate.Text.ToString();
                        da.SelectCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = TxtEndDate.Text.ToString();
                        da.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = ddlStatus.SelectedItem.Text.ToString();
                        da.SelectCommand.CommandTimeout = 1;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "policies_to_print");

                        dt = ds.Tables["policies_to_print"];

                        foreach (DataRow row in dt.Rows)
                        {
                            //manipulate your data
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Could not cook items.", ex);
                }
                return dt;
            }
        
        }

        
        protected DataTable ExecutePendingRenewalReport()
        {          
            //string connString = "user id=prmdic;password=hLcoG28V;data source=sql2k5.prmdic.net;connect timeout=0;initial catalog=prmdic;";
            string connString = ConfigurationManager.ConnectionStrings["PRMDICConnectionString"].ToString();
            string sql = "GetRenewalPendingPolicies";

            DataTable dt = null;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand(sql, conn);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;

                        da.SelectCommand.Parameters.Add("@BegDate", SqlDbType.VarChar).Value =  txtBegDate.Text.ToString();
                        da.SelectCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = TxtEndDate.Text.ToString();

                        da.SelectCommand.CommandTimeout = 0;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "result_name");

                        dt = ds.Tables["result_name"];

                        foreach (DataRow row in dt.Rows)
                        {
                            //manipulate your data
                        }
                    }
                }


                catch (Exception ex)
                {
                    throw new Exception("Could not cook items.", ex);
                }
                return dt;
            }
        }

        private void FieldVerify()
        {
            string errorMessage = String.Empty;
            bool found = false;

            if (this.txtBegDate.Text == "" && this.TxtEndDate.Text != "" &&
                found == false)
            {
                errorMessage = "Please enter the beginning date.";
                found = true;
            }
            if (this.txtBegDate.Text != "" && this.TxtEndDate.Text == "" &&
                found == false)
            {
                errorMessage = "Please enter the ending date.";
                found = true;
            }
            else if (this.txtBegDate.Text == "" && this.TxtEndDate.Text == "" &&
                found == false)
            {
                errorMessage = "Please enter the beginning date and ending date.";
                found = true;
            }
            else if ((this.txtBegDate.Text != "" && this.TxtEndDate.Text != "" &&
                DateTime.Parse(this.txtBegDate.Text) > DateTime.Parse(this.TxtEndDate.Text)) && found == false)
            {
                errorMessage = "The Ending Date must be great than beginning date .";
                found = true;
            }

            //throw the exception.
            if (errorMessage != String.Empty)
            {
                throw new Exception(errorMessage);
            }
        }

        protected void BtnExit_Click(object sender, System.EventArgs e)
        {
            Session.Clear();
            Response.Redirect("MainMenu.aspx");
        }

        protected void rblReportList_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableControl();
        }

        private void EnableControl()
        {
            Login.Login cp = HttpContext.Current.User as Login.Login;
            if (cp == null)
            {
                Response.Redirect("HomePage.aspx?001");
            }
            else
            {
                if (!cp.IsInRole("RENEWALREPORTS") && !cp.IsInRole("ADMINISTRATOR") && !cp.IsInRole("REPORTRENEWAL"))
                {
                    Response.Redirect("HomePage.aspx?001");
                }
            }

            switch (rblReportList.SelectedItem.Value)
            {
                case "0":			//PoliciesPendingRenewal
                    lblStatus.Visible = false;
                    ddlStatus.Visible = false;
                    break;

                case "1":			//PoliciesPendingPrint
                    lblStatus.Visible = true;
                    ddlStatus.Visible = true;
                    break;
            }
        }

    }
}