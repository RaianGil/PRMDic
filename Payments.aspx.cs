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
using EPolicy.TaskControl;
using EPolicy.Audit;
using EPolicy2.Reports;

namespace EPolicy
{
	/// <summary>
	/// Summary description for Payments.
	/// </summary>
	public partial class Payments : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TxtPayeeName;
		private Control LeftMenu;
        private static int taskControlID;
        private static string oldCheckNo;
        private static string oldDepositDate;

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

            /*LeftMenu = new Control();
            LeftMenu = LoadControl(@"LeftMenu.ascx");
            phTopBanner1.Controls.Add(LeftMenu);*/

			//Load DownDropList
			DataTable dtPolicyClass			= LookupTables.LookupTables.GetTable("PolicyClass");
			DataTable dtCreditDebit			= LookupTables.LookupTables.GetTable("CreditDebit");
			DataTable dtTaskStatus			= LookupTables.LookupTables.GetTable("TaskStatus"); //LookupTables.LookupTables.GetTableTaskStatusByTaskType(3);
			DataTable dtBank				= LookupTables.LookupTables.GetTable("Bank");

			//PolicyClass
			ddlPolicyClass.DataSource = dtPolicyClass;
			ddlPolicyClass.DataTextField = "PolicyClassDesc";
			ddlPolicyClass.DataValueField = "PolicyClassID";
			ddlPolicyClass.DataBind();
			ddlPolicyClass.SelectedIndex = -1;
			ddlPolicyClass.Items.Insert(0,"");

			//CreditDebit
			ddlCreditDebit.DataSource = dtCreditDebit;
			ddlCreditDebit.DataTextField = "CreditDebitDesc";
			ddlCreditDebit.DataValueField = "CreditDebitID";
			ddlCreditDebit.DataBind();
			ddlCreditDebit.SelectedIndex = -1;
			ddlCreditDebit.Items.Insert(0,"");

			//TaskStatus
			ddlTaskStatus.DataSource = dtTaskStatus;
			ddlTaskStatus.DataTextField = "TaskStatusDesc";
			ddlTaskStatus.DataValueField = "TaskStatusID";
			ddlTaskStatus.DataBind();
			ddlTaskStatus.SelectedIndex = -1;
			ddlTaskStatus.Items.Insert(0,"");

			//Bank
			ddlBank.DataSource = dtBank;
			ddlBank.DataTextField = "BankDesc";
			ddlBank.DataValueField = "BankID";
			ddlBank.DataBind();
			ddlBank.SelectedIndex = -1;
			ddlBank.Items.Insert(0,"");
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
            try
            {
                this.litPopUp.Visible = false;

                Login.Login cp = HttpContext.Current.User as Login.Login;
                if (cp == null)
                {
                    Response.Redirect("HomePage.aspx?001");
                }
                else
                {
                    if (!cp.IsInRole("PAYMENTS") && !cp.IsInRole("ADMINISTRATOR"))
                    {
                        Response.Redirect("HomePage.aspx?001");
                    }
                }

                if (Session["AutoPostBack"] == null)
                {
                    if (!IsPostBack)
                    {
                        if (Session["TaskControl"] != null)
                        {
                            TaskControl.Payments taskControl = (TaskControl.Payments)Session["TaskControl"];

                            switch (taskControl.Mode)
                            {
                                case 1:  //ADD
                                    //Verifica si puede a�adir o modificar pagos.
                                    if (!cp.IsInRole("EDITPAYMENTS") && !cp.IsInRole("ADMINISTRATOR"))
                                    {
                                        Response.Redirect("HomePage.aspx?001");
                                    }

                                    FillTextControl();
                                    EnableControls();
                                    break;

                                case 2: //Update
                                    FillTextControl();
                                    EnableControls();
                                    break;

                                default:

                                    FillTextControl();
                                    DisableControls();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (Session["TaskControl"] != null)
                        {
                            TaskControl.Payments taskControl = (TaskControl.Payments)Session["TaskControl"];
                            if (taskControl.Mode == 4)
                            {
                                DisableControls();
                            }
                        }
                    }
                }
                else
                {
                    FillTextControl();
                    EnableControls();
                    Session.Remove("AutoPostBack");
                }
            }
            catch (Exception exp)
            {
                if (exp.InnerException == null)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
                else if (exp.InnerException.InnerException == null)
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
                else
                    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

                this.litPopUp.Visible = true;
            }
		}

		public void FillTextControl()
		{
            try
            {
                TaskControl.Payments payments = (TaskControl.Payments)Session["TaskControl"];

                //PolicyClass
                ddlPolicyClass.SelectedIndex = 0;
                if (payments.PolicyClassID != 0)
                {
                    for (int i = 0; ddlPolicyClass.Items.Count - 1 >= i; i++)
                    {
                        if (ddlPolicyClass.Items[i].Value == payments.PolicyClassID.ToString())
                        {
                            ddlPolicyClass.SelectedIndex = i;
                            i = ddlPolicyClass.Items.Count - 1;
                        }
                    }
                }

                //CreditDebit
                ddlCreditDebit.SelectedIndex = 0;
                if (payments.CreditDebitID != 0)
                {
                    for (int i = 0; ddlCreditDebit.Items.Count - 1 >= i; i++)
                    {
                        if (ddlCreditDebit.Items[i].Value == payments.CreditDebitID.ToString())
                        {
                            ddlCreditDebit.SelectedIndex = i;
                            i = ddlCreditDebit.Items.Count - 1;
                        }
                    }
                }

                //TaskStatus
                ddlTaskStatus.SelectedIndex = 0;
                if (payments.TaskStatusID != 0)
                {
                    for (int i = 0; ddlTaskStatus.Items.Count - 1 >= i; i++)
                    {
                        if (ddlTaskStatus.Items[i].Value == payments.TaskStatusID.ToString())
                        {
                            ddlTaskStatus.SelectedIndex = i;
                            i = ddlTaskStatus.Items.Count - 1;
                        }
                    }
                }

                //Bank
                ddlBank.SelectedIndex = 0;
                if (payments.Bank != "000")
                {
                    for (int i = 0; ddlBank.Items.Count - 1 >= i; i++)
                    {
                        if (ddlBank.Items[i].Value == payments.Bank.ToString())
                        {
                            ddlBank.SelectedIndex = i;
                            i = ddlBank.Items.Count - 1;
                        }
                    }
                }

                if (Session["PolicyInfo"] != null) //Obtiene informacion desde la poliza (hdpolicy). Desde ViewOtherPaymentInfo.aspx.
                {
                    string[] policyInfo = (string[])Session["PolicyInfo"];

                    Session.Remove("PolicyInfo");

                    TxtPolicyType.Text = policyInfo[0].ToString();
                    txtPolicyNo.Text = policyInfo[1].ToString();
                    txtCertificate.Text = policyInfo[2].ToString();
                    TxtSuffix.Text = policyInfo[3].ToString();
                    TxtCustomerNo.Text = policyInfo[4].ToString();
                    TxtName.Text = policyInfo[5].ToString();
                    TxtLastName1.Text = policyInfo[6].ToString();
                    TxtLastName2.Text = policyInfo[7].ToString();
                    TxtLoanNo.Text = policyInfo[8].ToString();
                    payments.Bank = policyInfo[9].ToString();
                    payments.PolicyClassID = int.Parse(policyInfo[10].ToString());
                    TxtPaymentAmount.Text = policyInfo[11].ToString();
                    txtTCIDPolicy.Text = policyInfo[12].ToString();
                    taskControlID = int.Parse(policyInfo[12].ToString());

                    ddlBank.SelectedIndex = 0;
                    if (payments.Bank != "000")
                    {
                        for (int i = 0; ddlBank.Items.Count - 1 >= i; i++)
                        {
                            if (ddlBank.Items[i].Value == payments.Bank.ToString())
                            {
                                ddlBank.SelectedIndex = i;
                                i = ddlBank.Items.Count - 1;
                            }
                        }
                    }

                    //PolicyClass
                    ddlPolicyClass.SelectedIndex = 0;
                    if (payments.PolicyClassID != 0)
                    {
                        for (int i = 0; ddlPolicyClass.Items.Count - 1 >= i; i++)
                        {
                            if (ddlPolicyClass.Items[i].Value == payments.PolicyClassID.ToString())
                            {
                                ddlPolicyClass.SelectedIndex = i;
                                i = ddlPolicyClass.Items.Count - 1;
                            }
                        }
                    }

                    payments.CustomerNo = TxtCustomerNo.Text.ToUpper();
                    payments.Customer.CustomerNo = TxtCustomerNo.Text;
                    payments.Customer.FirstName = TxtName.Text;
                    payments.Customer.LastName1 = TxtLastName1.Text;
                    payments.Customer.LastName2 = TxtLastName2.Text;
                    payments.Customer.SocialSecurity = TxtSocialSecurity.Text;

                    Session.Add("TaskControl", payments);

                    if (policyInfo.Length > 13)
                    {
                        //taskControlID = int.Parse(policyInfo[17].ToString().Trim());
                        TxtPaymentDate.Text = policyInfo[13].ToString();
                        TxtPaymentCheck.Text = policyInfo[14].ToString();
                        oldCheckNo = policyInfo[14].ToString();
                        TxtNamePayee.Text = policyInfo[15].ToString();
                        txtDepositDate.Text = policyInfo[16].ToString();
                        oldDepositDate = policyInfo[16].ToString();
                        //txtDepositDate.Text = payments.DepositDate;
                        //TxtPaymentDate.Text = payments.PaymentDate;
                        //TxtPaymentCheck.Text = payments.CheckNo;
                        //TxtNamePayee.Text = payments.Name;
                    }
                }
                else
                {
                    txtPolicyNo.Text = payments.PolicyNo;
                    TxtPolicyType.Text = payments.PolicyType;
                    txtCertificate.Text = payments.Certificate;
                    TxtSuffix.Text = payments.Sufijo;
                    TxtLoanNo.Text = payments.LoanNumber;
                    TxtPaymentAmount.Text = payments.PaymentAmount.ToString("###,###.00");
                }

                lblTaskControlID.Text = payments.TaskControlID.ToString();
                txtOriginalPolicyNo.Text = payments.OriginalPolicyNo;
                txtComments.Text = payments.Comments;
                //TxtComments1.Text	= payments.Comments1;           

                if (payments.CustomerNo != "")
                {
                    TxtCustomerNo.Text = payments.Customer.CustomerNo;
                    TxtName.Text = payments.Customer.FirstName;
                    TxtLastName1.Text = payments.Customer.LastName1;
                    TxtLastName2.Text = payments.Customer.LastName2;
                    TxtSocialSecurity.Text = payments.Customer.SocialSecurity;
                }
                else
                {
                    TxtCustomerNo.Text = "";
                    TxtName.Text = "";
                    TxtLastName1.Text = "";
                    TxtLastName2.Text = "";
                    TxtSocialSecurity.Text = "";
                }

                TxtAging.Text = payments.Aging.ToString();
                TxtEntryDate.Text = payments.EntryDate.ToShortDateString();
                TxtCloseDate.Text = payments.CloseDate;

                TxtReceiptNo.Text = payments.ReceiptNo;

                ChkSRO.Checked = payments.Licence;
                ChkIsNEwTransaction.Checked = payments.IsNewTransaction;

                TxtEntryDate.Text = payments.EntryDate.ToShortDateString();

                payments.GetTotalAmount(payments.CheckNo, payments.PaymentDate, payments.PaymentDate);
                TxtCheckNo.Text = payments.CheckNo;
                TxtTotalAmount.Text = payments.TotalAmount.ToString("###,###.00");
                LblTotalCases.Text = LblTotalCases.Text + " " + payments.TotalCheck.ToString();
                TxtAuthorizeBy.Text = payments.AuthorizeUserName.Trim();

                if (Session["OldPayment"] != null)
                {
                    TaskControl.Payments OldPayment = (TaskControl.Payments)Session["OldPayment"];

                    if (OldPayment.CheckNo != payments.CheckNo)
                    {
                        ChkMultiple.Checked = false;
                    }
                    else
                    {
                        ChkMultiple.Checked = true;
                    }
                }
            }
            catch (Exception exp)
            {
                //if (exp.InnerException == null)
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine);
                //else if (exp.InnerException.InnerException == null)
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message);
                //else
                //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message + System.Environment.NewLine + " " + exp.InnerException.Message +
                //         System.Environment.NewLine + "  " + exp.InnerException.InnerException.Message);

                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("A problem occured while assigning data to the webpage controls.");
                this.litPopUp.Visible = true;
            }
		}
		
		private void BtnBegin_Click(object sender, System.EventArgs e)
		{
			Session.Remove("Address1");
		}

		private void BtnPrevious_Click(object sender, System.EventArgs e)
		{
			Session.Remove("Address1");
		}

		private void BtnNext_Click(object sender, System.EventArgs e)
		{
			Session.Remove("Address1");
		}

		private void BtnEnd_Click(object sender, System.EventArgs e)
		{
			Session.Remove("Address1");
		}

		private void BtnSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Customer.Prospect prospect = (Customer.Prospect)Session["Prospect"];
			Login.Login cp = HttpContext.Current.User as Login.Login;
			int userID = 0;

			try
			{
				userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
			}
			catch(Exception ex)
			{
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("UCould not parse user id from cp.Identity.Name.");
                this.litPopUp.Visible = true;
                //throw new Exception(
                //    "Could not parse user id from cp.Identity.Name.", ex);
			}

			try
			{
				FillProperties();
				TaskControl.Payments taskControl = (TaskControl.Payments) Session["TaskControl"];

				taskControl.Save(userID);
				FillTextControl();
				DisableControls();
	
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Task Control information saved successfully.");
				this.litPopUp.Visible = true;
			}
			catch (Exception exp)
			{
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to save this Payment." +"\r\n"+ exp.Message);
				this.litPopUp.Visible = true;
			}
		}

		private void FillProperties()
		{
            try
            {
                TaskControl.Payments taskControl = (TaskControl.Payments)Session["TaskControl"];

                taskControl.PolicyClassID = ddlPolicyClass.SelectedItem.Value != "" ? int.Parse(ddlPolicyClass.SelectedItem.Value.ToString()) : 0;
                taskControl.OriginalPolicyNo = txtOriginalPolicyNo.Text.ToUpper();
                taskControl.PolicyType = TxtPolicyType.Text.ToUpper();
                taskControl.PolicyNo = txtPolicyNo.Text.ToUpper().Trim();
                taskControl.Certificate = txtCertificate.Text.ToUpper();
                taskControl.Sufijo = TxtSuffix.Text.ToUpper();
                taskControl.LoanNumber = TxtLoanNo.Text.ToUpper();
                taskControl.Comments = txtComments.Text.ToUpper();
                //taskControl.Comments1		= TxtComments1.Text.ToUpper();
                taskControl.TaskStatusID = ddlTaskStatus.SelectedItem.Value != "" ? int.Parse(ddlTaskStatus.SelectedItem.Value.ToString()) : 0;
                taskControl.CustomerNo = TxtCustomerNo.Text.ToUpper();
                taskControl.Bank = ddlBank.SelectedItem.Value != "" ? ddlBank.SelectedItem.Value : "000";
                taskControl.Licence = ChkSRO.Checked;
                taskControl.DepositDate = txtDepositDate.Text;
                taskControl.PaymentDate = TxtPaymentDate.Text;
                taskControl.CheckNo = TxtPaymentCheck.Text.ToUpper();
                taskControl.CreditDebitID = ddlCreditDebit.SelectedItem.Value != "" ? int.Parse(ddlCreditDebit.SelectedItem.Value) : 0;
                taskControl.Name = TxtNamePayee.Text.ToUpper();
                taskControl.MultiplePayment = ChkMultiple.Checked;
                taskControl.IsNewTransaction = ChkIsNEwTransaction.Checked;

                if (taskControl.Mode == (int)TaskControl.TaskControl.TaskControlMode.ADD)
                {
                    Login.Login cp = HttpContext.Current.User as Login.Login;
                    taskControl.EnteredBy = cp.Identity.Name.Split("|".ToCharArray())[0].ToString();
                }

                bool error = false;
                string payAmt = TxtPaymentAmount.Text.Trim();

                for (int i = 0; i <= payAmt.Length - 1; i++)
                {
                    if (System.Char.IsDigit(payAmt, i) || Char.Parse(payAmt.Substring(i, 1)) == '.' || Char.Parse(payAmt.Substring(i, 1)) == ',' || Char.Parse(payAmt.Substring(i, 1)) == '-')
                    {
                        error = false;
                    }
                    else
                    {
                        error = true;
                        i = TxtPaymentAmount.Text.Trim().Length - 1;
                    }
                }

                if (error)
                {
                    throw new Exception("Payment Amount must be numeric digit.");
                }

                if (TxtPaymentAmount.Text != "")
                    taskControl.PaymentAmount = Decimal.Parse(TxtPaymentAmount.Text.Replace(",", ""));

                Session.Add("TaskControl", taskControl);
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("A problem occured filling class properties.");
                this.litPopUp.Visible = true;
            }
		}

		private void BtnExit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.litPopUp.Visible = false;
			Session.Clear();
			Response.Redirect("TaskControl.aspx");
		}

	
		private void btnEdit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			bool privilege = false;
			try
			{
				Login.Login cp = HttpContext.Current.User as Login.Login;
				if (cp == null)
				{
					Response.Redirect("HomePage.aspx?001");
				}
				else
				{
					if(!cp.IsInRole("EDITPAYMENTS") && !cp.IsInRole("ADMINISTRATOR"))
					{
						privilege = true;
						throw new Exception("Don't have privilege to add or modify payments.");
						//Response.Redirect("HomePage.aspx?001");
					}
				}
			}
			catch (Exception exp)
			{
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
				this.litPopUp.Visible = true;
			}

			if (privilege == false)
			{
				TaskControl.Payments taskControl = (TaskControl.Payments) Session["TaskControl"];
				taskControl.Mode		= (int) TaskControl.TaskControl.TaskControlMode.UPDATE;

				Session.Add("TaskControl",taskControl);

				EnableControls();

				if (decimal.Parse(TxtPaymentAmount.Text) > 0 && taskControl.PaymentApplied)
				{
					TxtPaymentAmount.Enabled	= false;
					ddlCreditDebit.Enabled		= false;
				}
			}
		}

		private void btnCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			TaskControl.Payments taskControl = (TaskControl.Payments) Session["TaskControl"];

			if(taskControl.Mode == 1) //ADD
			{
				Session.Clear();
				Response.Redirect("TaskControl.aspx");
			}
			else
			{
				taskControl.Mode		= (int) TaskControl.TaskControl.TaskControlMode.CLEAR;
				Session["TaskControl"] = taskControl;

				DisableControls();
			}
		}

		private void EnableControls()
		{
			TaskControl.Payments taskControl = (TaskControl.Payments) Session["TaskControl"];

            btnEdit.Visible     = false ;
			BtnExit.Visible		= false;
			BtnSave.Visible		= true;
			btnCancel.Visible	= true;
			btnAuditTrail.Visible = false;

			btnCalendar.Visible = true;
			Button1.Visible	    = true;
			BtnNewPayment.Visible = false;
			btnReceipt.Visible  = false;
			btnDelete.Visible	= false;

			//DisableDeleteBtn(); //Verifica si tiene permiso para el boton de delete.
	
			VerifyChkIsNEwTransaction(); //Verifica si tiene permiso para el CHK IsNewTransaction.
			ChkIsNEwTransaction.Enabled =false ;
			ChkMultiple.Enabled = false;
			ChkSRO.Enabled	    = true;

			ddlTaskStatus.Enabled		= false;
			ddlCreditDebit.Enabled		= true;
			ddlPolicyClass.Enabled		= false;//Estefania lo mando a cambiar 2018
			ddlBank.Enabled		  	    = true;

			txtOriginalPolicyNo.Enabled	= true;
            TxtPolicyType.Enabled       = false;//Estefania lo mando a cambiar 2018
            txtPolicyNo.Enabled         = false;//Estefania lo mando a cambiar 2018
			TxtAging.Enabled			= false;
			TxtEntryDate.Enabled		= false;
			TxtCloseDate.Enabled		= false;
            txtCertificate.Enabled      = false;//Estefania lo mando a cambiar 2018
            TxtSuffix.Enabled           = false;//Estefania lo mando a cambiar 2018
            TxtLoanNo.Enabled           = false;//Estefania lo mando a cambiar 2018
			txtComments.Enabled			= false;
			//TxtComments1.Enabled		= true;
			TxtCustomerNo.Enabled		= false;
			TxtName.Enabled				= false;
			TxtLastName1.Enabled		= false;
			TxtLastName2.Enabled		= false;
			TxtSocialSecurity.Enabled	= false;
			TxtReceiptNo.Enabled		= false;
			TxtNamePayee.Enabled		= true;
			TxtAuthorizeBy.Enabled		= false;

			TxtPaymentDate.Enabled		= true;
			TxtPaymentCheck.Enabled		= true;
			TxtPaymentAmount.Enabled	= true;
			txtDepositDate.Enabled		= true;
			TxtCheckNo.Enabled			= false;
			TxtTotalAmount.Enabled		= false;

            if (taskControl.Mode == 2)
            {
                DisableControls();
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnBack.Visible = false;
                BtnExit.Visible = true;
                BtnSave.Visible = true;
                btnCancel.Visible = true;

                //this.BtnGo.Visible = true;
                //this.BtnGo2.Visible = true;

                ChkSRO.Enabled = false;
                ChkMultiple.Enabled = false;
                BtnNewPayment.Enabled = false;
                btnCalendar.Visible = false;
                Button1.Visible = true;
                TxtPaymentCheck.Enabled = true;
                txtDepositDate.Enabled = true;
                TxtNamePayee.Enabled = true;
                //TxtPaymentDate.Enabled = false;
                //TxtPaymentCheck.Enabled = false;
                //TxtPaymentAmount.Enabled = false;
                //ddlCreditDebit.Enabled = false;
            }
		}

		private void DisableControls()
		{
			btnEdit.Visible		= true;
            btnBack.Visible     = true;
			BtnExit.Visible		= true;
			BtnSave.Visible		= false;
			btnCancel.Visible	= false;
			//btnAuditTrail.Visible = true;

			btnCalendar.Visible = false;
			Button1.Visible	    = false;
			BtnNewPayment.Visible = false;
			btnReceipt.Visible  = false;
			BtnGo.Visible       = false;
			BtnGo2.Visible       = false;
            btnDelete.Visible = false;
			
			//DisableDeleteBtn(); //Verifica si tiene permiso para el boton de delete.

			VerifyChkIsNEwTransaction(); //Verifica si tiene permiso para el CHK IsNewTransaction.
			ChkIsNEwTransaction.Enabled = false;
			ChkMultiple.Enabled = true;
			ChkSRO.Enabled	    = false;

			ddlTaskStatus.Enabled		= false;
			ddlCreditDebit.Enabled		= false;
			ddlPolicyClass.Enabled		= false;
			ddlBank.Enabled		  	    = false;

			txtOriginalPolicyNo.Enabled	= false;
			TxtPolicyType.Enabled		= false;
			txtPolicyNo.Enabled			= false;
			TxtAging.Enabled			= false;
			TxtEntryDate.Enabled		= false;
			TxtCloseDate.Enabled		= false;
			txtCertificate.Enabled		= false;
			TxtSuffix.Enabled			= false;
			TxtLoanNo.Enabled			= false;
			txtComments.Enabled			= false;
			//TxtComments1.Enabled		= false;
			TxtCustomerNo.Enabled		= false;
			TxtName.Enabled				= false;
			TxtLastName1.Enabled		= false;
			TxtLastName2.Enabled		= false;
			TxtSocialSecurity.Enabled	= false;
			TxtReceiptNo.Enabled		= false;
			TxtNamePayee.Enabled     	= false;
			TxtAuthorizeBy.Enabled		= false;

			TxtPaymentDate.Enabled		= false;
			TxtPaymentCheck.Enabled		= false;
			TxtPaymentAmount.Enabled	= false;
			txtDepositDate.Enabled		= false;
			TxtCheckNo.Enabled			= false;
			TxtTotalAmount.Enabled		= false;
		}

	
		private void btnAuditTrail_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(Session["TaskControl"] != null)
			{
				TaskControl.Payments payments = (TaskControl.Payments) Session["TaskControl"];
				Response.Redirect("SearchAuditItems.aspx?type=2&taskControlID=" + 
					payments.TaskControlID.ToString());
			}
		}

		protected void BtnGo2_Click(object sender, System.EventArgs e)
		{
			TaskControl.Payments taskControl = (TaskControl.Payments) Session["TaskControl"];
			try
			{
				ValidateInfo(true);

				string PolClassID = "";	

				switch (int.Parse(ddlPolicyClass.SelectedItem.Value.ToString()))
				{
					case 3:				// AUTO
						PolClassID = "A";
						break;
					case 4:				// DWELLING
						PolClassID = "D";
						break;
					case 5:				// BOND
						PolClassID = "B";
						break;
					case 6:				// CONDOMINIUM
						PolClassID = "O";
						break;
					case 7:				// YACHT
						PolClassID = "Y";
						break;
					case 8:				// OTHER
						PolClassID = "O";
						break;
					case 11:			// FLOOD
						PolClassID = "F";
						break;
				}                            
	
				DataTable dtHd;
				dtHd = TaskControl.TaskControl.GetPoliciesFromHdpolicyByLoanNoDB(PolClassID,TxtLoanNo.Text.ToUpper().Trim());
			
				if ( dtHd != null)
				{
					if (dtHd.Rows.Count != 0)
					{
						FillProperties();
						Session.Add("DtHD",dtHd);
						Response.Redirect("ViewOtherPaymentInfo.aspx");	
					}
					else
						throw new Exception("This Loan Number is not found in our databases, Please verify.");
				}
				else
					throw new Exception("This Loan Number is not found in our databases, Please verify.");
			}
			catch (Exception exp)
			{
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
				this.litPopUp.Visible = true;
			}
		}

		protected void BtnGo_Click(object sender, System.EventArgs e)
		{
			TaskControl.Payments taskControl = (TaskControl.Payments) Session["TaskControl"];
			try
			{
				ValidateInfo(false);

				string PolClassID = "";	

				switch (int.Parse(ddlPolicyClass.SelectedItem.Value.ToString()))
				{
					case 3:				// AUTO
						PolClassID = "A";
						break;
					case 4:				// DWELLING
						PolClassID = "D";
						break;
					case 5:				// BOND
						PolClassID = "B";
						break;
					case 6:				// CONDOMINIUM
						PolClassID = "O";
						break;
					case 7:				// YACHT
						PolClassID = "Y";
						break;
					case 8:				// OTHER
						PolClassID = "O";
						break;
					case 11:			// FLOOD
						PolClassID = "F";
						break;
				}                            
	
				DataTable dtHd;
				dtHd = TaskControl.TaskControl.GetPoliciesFromHdpolicyByPolicyNoDB(PolClassID,TxtPolicyType.Text.ToUpper().Trim(),
					txtPolicyNo.Text.ToUpper().Trim(), txtCertificate.Text.ToUpper().Trim());
			
				if ( dtHd != null)
				{
					if (dtHd.Rows.Count != 0)
					{
						FillProperties();
						Session.Add("DtHD",dtHd);
						Response.Redirect("ViewOtherPaymentInfo.aspx");	
					}
					else
						throw new Exception("This Policy Number is not found in our databases, Please verify.");
				}
				else
					throw new Exception("This Policy Number is not found in our databases, Please verify.");
			}
			catch (Exception exp)
			{
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
				this.litPopUp.Visible = true;
			}
		}

		protected void ChkSRO_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ChkSRO.Checked && this.ddlCreditDebit.SelectedItem.Text == "CREDIT")
			{
				LblPaymentDate.Text = "Expiration Date";
			}
			else
			{
				LblPaymentDate.Text = "Payment Date";
			}
		}

		private void ddlCreditDebit_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ChkSRO.Checked && this.ddlCreditDebit.SelectedItem.Text == "CREDIT")
			{
				LblPaymentDate.Text = "Expiration Date";
			}
			else
			{
				LblPaymentDate.Text = "Payment Date";
			}
		}

		private void txtPolicyNo_TextChanged(object sender, System.EventArgs e)
		{

		}

		protected void txtCertificate_TextChanged(object sender, System.EventArgs e)
		{
			//			TaskControl.Payments taskControl = (TaskControl.Payments) Session["TaskControl"];
			//			if (taskControl.Mode == 1)
			//			{
			//				string custno = TaskControl.TaskControl.GetPoliciesFromHdpolicyByPolicyNoDB(TxtPolicyType.Text.ToUpper().Trim(),
			//					txtPolicyNo.Text.ToUpper().Trim(), txtCertificate.Text.ToUpper().Trim());
			//				taskControl.CustomerNo		= custno.ToUpper();
			//			}
		}

		protected void ddlPolicyClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
//			switch (int.Parse(ddlPolicyClass.SelectedItem.Value))
//			{
//				case 10:  //Etch
//					this.TxtPolicyType.Text		= "ETC";
//					this.TxtSuffix.Text			= "00";
//					this.TxtPaymentAmount.Text	= "299.00";
//					this.BtnGo.Visible       = false;
//					this.BtnGo2.Visible       = false;
//					break;
//				case 1:  //AG
//					this.TxtPolicyType.Text		= "AG";
//					this.TxtSuffix.Text			= "00";
//					this.TxtPaymentAmount.Text	= "";
//					this.BtnGo.Visible       = false;
//					this.BtnGo2.Visible       = false;
//					break;
//				default:
//					this.TxtPolicyType.Text		= "";
//					this.TxtSuffix.Text			= "";
//					this.TxtPaymentAmount.Text	= "";
//					this.BtnGo.Visible          = true;
//					this.BtnGo2.Visible          = true;
//					break;
//			}
		}

		private void btnDelete_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Login.Login cp = HttpContext.Current.User as Login.Login;
			int userID = 0;

			try
			{
				userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
			}
			catch(Exception ex)
			{
				throw new Exception(
					"Could not parse user id from cp.Identity.Name.", ex);
			}

			try
			{
				TaskControl.Payments taskControl = (TaskControl.Payments) Session["TaskControl"];
				taskControl.DeleteTaskPayment(userID);
				
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Deleted Payment successfully.");
				this.litPopUp.Visible = true;
			}
			catch (Exception exp)
			{
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to delete this Payment. " + exp.Message);
				this.litPopUp.Visible = true;
			}
						
		}

		private void VerifyChkIsNEwTransaction()
		{
			Login.Login cp = HttpContext.Current.User as Login.Login;
			if (cp == null)
			{
				Response.Redirect("HomePage.aspx?001");
			}
			else
			{
				if(cp.IsInRole("PAYMENTISNEWTRANS") || cp.IsInRole("ADMINISTRATOR"))
				{
					this.ChkIsNEwTransaction.Visible = false;
				}
				else
				{
					this.ChkIsNEwTransaction.Visible = false;
				}
			}
		}

		private void DisableDeleteBtn()
		{
			Login.Login cp = HttpContext.Current.User as Login.Login;
			if (cp == null)
			{
				Response.Redirect("HomePage.aspx?001");
			}
			else
			{
				if(cp.IsInRole("TASKPAYMENTDELETE") || cp.IsInRole("ADMINISTRATOR"))
				{
					this.btnDelete.Visible = true;
				}
				else
				{
					this.btnDelete.Visible = false;
				}
			}
		}

		private void ValidateInfo(bool byLoanNo)
		{
            try
            {
                string errorMessage = String.Empty;

                if (ddlPolicyClass.SelectedItem.Value == "")
                    errorMessage = "The line of business is missing or wrong. Please choose a line of businees.";

                if (byLoanNo)
                {
                    if (TxtLoanNo.Text.Trim() == "")
                        errorMessage = "The loan number is missing or wrong. Please verify.";
                }
                else
                {
                    if (TxtPolicyType.Text.Trim() == "")
                        errorMessage = "The policy type is missing or wrong. Please verify.";
                    else
                        if (txtPolicyNo.Text.Trim() == "")
                            errorMessage = "The policy number is missing or wrong. Please verify.";
                }

                //throw the exception.
                if (errorMessage != String.Empty)
                {
                    throw new Exception(errorMessage);
                }
            }
            catch (Exception exp)
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
                this.litPopUp.Visible = true;
            }
		}

		protected void TxtSuffix_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void Button3_Click(object sender, System.EventArgs e)
		{
			if(Session["TaskControl"] != null)
			{
                //TaskControl.Policy task = new TaskControl.Policy();
                //TaskControl.Policy.GetPolicyByTaskControlID(taskControlID, task);
                //Session["TaskControl"] = TaskControl.TaskControl.GetTaskControlByTaskControlID(task.TaskControlID, 1);
                

				//TaskControl.Payments payments = (TaskControl.Payments) Session["TaskControl"];

                Session.Add("TaskControlID", taskControlID);

				Response.Redirect("SearchAuditItems.aspx?type=2&taskControlID=" + 
					taskControlID.ToString());
			}
		}

		protected void BtnDele_Click(object sender, System.EventArgs e)
		{
			Login.Login cp = HttpContext.Current.User as Login.Login;
			int userID = 0;

			try
			{
				userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
			}
			catch(Exception ex)
			{
				throw new Exception(
					"Could not parse user id from cp.Identity.Name.", ex);
			}

			try
			{
				TaskControl.Payments taskControl = (TaskControl.Payments) Session["TaskControl"];
				taskControl.DeleteTaskPayment(userID);
				
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Deleted Payment successfully.");
				this.litPopUp.Visible = true;
			}
			catch (Exception exp)
			{
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to delete this Payment. " + exp.Message);
				this.litPopUp.Visible = true;
			}
		}

		protected void btnReceip_Click(object sender, System.EventArgs e)
		{
//			TaskControl.Payments taskControl = (TaskControl.Payments) Session["TaskControl"];
//
//			PaymentReceipt rpt = new PaymentReceipt(taskControl);				
//			rpt.Run(false);
//
//			Session.Add("Report",rpt);
//
//			Session.Add("FromPage","Payments.aspx");
//
//			Response.Redirect("ActiveXViewer.aspx",false);
		}

		protected void Button2_Click(object sender, System.EventArgs e)
		{
			this.litPopUp.Visible = false;
            
            TaskControl.Policies task = new TaskControl.Policies();
            TaskControl.Policy.GetPolicyByTaskControlID(taskControlID, task);
            Session["TaskControl"] = TaskControl.TaskControl.GetTaskControlByTaskControlID(task.TaskControlID, 1);
            //Session["TaskControl"] = task;
            //Session.Clear();

            if (task.PolicyType.ToString().Trim().Contains("PP") || task.PolicyType.ToString().Trim().Contains("PE"))
                Response.Redirect("Policies.aspx");
            //Session.Add("FromPage", "Policies.aspx");
            else if (task.PolicyType.ToString().Trim() == "CP" || task.PolicyType.ToString().Trim() == "CE")
                Response.Redirect("CorporatePolicyQuote.aspx");
            else if (task.PolicyType.ToString().Trim().Contains("CLP") || task.PolicyType.ToString().Trim().Contains("CLE"))
                Response.Redirect("LaboratoryApplication1.aspx");
            else if (task.PolicyType.ToString().Trim().Contains("EMD")) //|| task.PolicyType.ToString().Trim().Contains("EMDT"))
                Response.Redirect("CyberApplication.aspx");
            else if (task.PolicyType.ToString().Trim() == "PAH")
                Session.Add("FromPage", "AHCPrimaryPolicies.aspx");
            else if (task.PolicyType.ToString().Trim() == "CPA")
                Session.Add("FromPage", "AHCCorporateQuotes.aspx");
            else if (task.PolicyType.ToString().Trim() == "IF" || task.PolicyType.ToString().Trim() == "IFT")
                //Session.Add("FromPage", "FirstDollarPolicies.aspx");
                Response.Redirect("FirstDollarPolicies.aspx");
            else if (task.PolicyType.ToString().Trim() == "CF" || task.PolicyType.ToString().Trim() == "CFT")
                //Session.Add("FromPage", "FirstDollarCorporate.aspx");
                Response.Redirect("FirstDollarCorporate.aspx");
            else
                Response.Redirect("MainMenu.aspx");
                //Session.Add("FromPage", "CorporatePolicyQuote.aspx");

                //Response.Redirect("ViewPayment.aspx");

                //Session.Clear();
                //
            
		}

		protected void Button5_Click(object sender, System.EventArgs e)
		{
			TaskControl.Payments taskControl = (TaskControl.Payments) Session["TaskControl"];

            //if(taskControl.Mode == 1) //ADD
            //{
            //    Session.Clear();
            //    Response.Redirect("MainMenu.aspx");
            //}
            //else //if (taskControl.Mode == 2)
            //{
                TaskControl.Policies task = new TaskControl.Policies();
                TaskControl.Policy.GetPolicyByTaskControlID(taskControlID, task);
                Session["TaskControl"] = TaskControl.TaskControl.GetTaskControlByTaskControlID(task.TaskControlID, 1);
                //Session["TaskControl"] = task;
                //Session.Clear();

                if (task.PolicyType.ToString().Trim() == "PP" || task.PolicyType.ToString().Trim() == "PE")
                    Session.Add("FromPage", "Policies.aspx");
                else if (task.PolicyType.ToString().Trim() == "CLP")
                    Session.Add("FromPage", "LaboratoryApplication1.aspx");
                else if (task.PolicyType.ToString().Trim() == "PAH")
                    Session.Add("FromPage", "AHCPrimaryPolicies.aspx");
                else if (task.PolicyType.ToString().Trim() == "CPA")
                    Session.Add("FromPage", "AHCCorporateQuotes.aspx");
                else if (task.PolicyType.ToString().Trim() == "IF")
                    Session.Add("FromPage", "FirstDollarPolicies.aspx");
                else if (task.PolicyType.ToString().Trim() == "CF")
                    Session.Add("FromPage", "FirstDollarCorporate.aspx");
                    
                else
                    Session.Add("FromPage", "CorporatePolicyQuote.aspx");

                Response.Redirect("ViewPayment.aspx");
           // }
            //else
            //{
            //    taskControl.Mode		= (int) TaskControl.TaskControl.TaskControlMode.CLEAR;
            //    Session["TaskControl"] = taskControl;

            //    DisableControls();
            //}
		}

		protected void Button6_Click(object sender, System.EventArgs e)
		{
			Customer.Prospect prospect = (Customer.Prospect)Session["Prospect"];
			Login.Login cp = HttpContext.Current.User as Login.Login;
			int userID = 0;

			try
			{
				userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
			}
			catch(Exception ex)
			{
				throw new Exception(
					"Could not parse user id from cp.Identity.Name.", ex);
			}

			try
			{
				FillProperties();
				TaskControl.Payments taskControl = (TaskControl.Payments) Session["TaskControl"];
                
                if (taskControlID != 0)
                {
                    taskControl.TaskControlID = taskControlID;
                    Session["TaskControl"] = taskControl;
                }

                if (taskControl.Mode == 1) 
                {
                    if (taskControl.Certificate.Trim()=="")
                    {
                        taskControl.Certificate = "";
                    }
                    taskControl.Save(userID);

                    //Luego de aplicar el pago, el sistema verifica el PaidAmount de la tabla de policy y lo actualiza
                    if (txtTCIDPolicy.Text.Trim() != "" && taskControl.Mode != 2)
                    {
                        TaskControl.TaskControl taskControlpol = TaskControl.TaskControl.GetTaskControlByTaskControlID(int.Parse(txtTCIDPolicy.Text.Trim()), 1);
                        Policy pol = (Policy)taskControlpol;

                        double payAmount = double.Parse(TxtPaymentAmount.Text);

                        History(pol.TaskControlID, userID, "ADD","PAYMENTS","ADDED PAYMENT" + System.Environment.NewLine + "CHECK NO: " + TxtPaymentCheck.Text
                        + System.Environment.NewLine + "NAME: " + TxtNamePayee.Text + System.Environment.NewLine + "AMOUNT: " + payAmount.ToString("$###,###")
                        + System.Environment.NewLine + "CHECK TYPE: " + ddlCreditDebit.SelectedItem.Text +System.Environment.NewLine + "PAYMENT DATE: " + TxtPaymentDate.Text + System.Environment.NewLine + "DEPOSIT DATE: " + txtDepositDate.Text);
                        PaymentPolicy pp = PaymentPolicy.GetPaymentsByTaskControlID(pol);

                        string paidAmtST = pp.TotalPaid.ToString("###,###.00");
                        double paidAmt = double.Parse(paidAmtST);
                        PaymentPolicy.UpdatePolicyPaidAmount(pol.TaskControlID, paidAmt);
                    }
                }
                else
                {
                    Audit.History history = new Audit.History();
                    TaskControl.TaskControl taskControlpol = TaskControl.TaskControl.GetTaskControlByTaskControlID(int.Parse(txtTCIDPolicy.Text.Trim()), 1);
                    Policy pol = (Policy)taskControlpol;
                    //string subject;

                    history.BuildNotesForHistory("CheckNo , Deposit Date", oldCheckNo + " , " + oldDepositDate, TxtPaymentCheck.Text.ToString().Trim() + " , " + txtDepositDate.Text.ToString().Trim(), taskControl.Mode);

                    taskControl.UpdateCheckNoAndDepositDate(oldCheckNo,
                    TxtPaymentCheck.Text.ToString().Trim(), txtDepositDate.Text.ToString().Trim(),
                    taskControl.PolicyNo, TxtPaymentDate.Text.ToString().Trim(), TxtNamePayee.Text.ToString().Trim());

                    //history.BuildNotesForHistory("DepositDate", taskControl.DepositDate, txtDepositDate.Text.ToString().Trim(), taskControl.Mode);

                    //subject = "CHECK NO./ DEPOSIT DATE CHANGE" + "\r\n"
                    //+ "CheckNo: " + oldCheckNo + " to " + TxtPaymentCheck.Text.ToString().Trim() + "\r\n"
                    //+ "DepositDate: " + taskControl.DepositDate + " to " + txtDepositDate.Text.ToString().Trim() + "\r\n";

                    //history.Notes = "[PAYMENTS] " + subject.Trim();
                    history.Actions = "EDIT";
                    history.KeyID = taskControlpol.TaskControlID.ToString();
                    history.Subject = "PAYMENTS";
                    history.UsersID = userID;
                    history.GetSaveHistory();
                }


				FillTextControl();
				DisableControls();

                //taskControlID = taskControl.TaskControlID;
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Task Control information saved successfully.");
				this.litPopUp.Visible = true;
			}
			catch (Exception exp)
			{
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Unable to save this Payment." +"\r\n"+ exp.Message);
				this.litPopUp.Visible = true;
			}
		}

		protected void Button4_Click(object sender, System.EventArgs e)
		{
			bool privilege = false;
			try
			{
				Login.Login cp = HttpContext.Current.User as Login.Login;
				if (cp == null)
				{
					Response.Redirect("HomePage.aspx?001");
				}
				else
				{
					if(!cp.IsInRole("EDITPAYMENTS") && !cp.IsInRole("ADMINISTRATOR"))
					{
						privilege = true;
						throw new Exception("Don't have privilege to add or modify payments.");
						//Response.Redirect("HomePage.aspx?001");
					}
				}
			}
			catch (Exception exp)
			{
				this.litPopUp.Text = Utilities.MakeLiteralPopUpString(exp.Message);
				this.litPopUp.Visible = true;
			}

			if (privilege == false)
			{
				TaskControl.Payments taskControl = (TaskControl.Payments) Session["TaskControl"];
				taskControl.Mode		= (int) TaskControl.TaskControl.TaskControlMode.UPDATE;

				Session.Add("TaskControl",taskControl);

				EnableControls();
                btnAuditTrail.Visible = false;

				if (decimal.Parse(TxtPaymentAmount.Text) > 0 && taskControl.PaymentApplied)
				{
					TxtPaymentAmount.Enabled	= false;
					ddlCreditDebit.Enabled		= false;
				}
			}
		}

		protected void BtnNewPayment_Click(object sender, System.EventArgs e)
		{
			TaskControl.Payments taskControl = new TaskControl.Payments();
			TaskControl.Payments OldPayment = (TaskControl.Payments) Session["TaskControl"];
			
			if (ChkMultiple.Checked)
			{
//				switch (int.Parse(ddlPolicyClass.SelectedItem.Value))
//				{
//					case 10:  //Etch
//						taskControl.PaymentAmount	= OldPayment.PaymentAmount;
//						break;
//				}
				
				taskControl.PolicyClassID	= OldPayment.PolicyClassID;
				taskControl.CheckNo			= OldPayment.CheckNo;
				taskControl.PaymentDate		= OldPayment.PaymentDate;
				taskControl.TotalAmount		= OldPayment.TotalAmount;
			}

			taskControl.MultiplePayment = ChkMultiple.Checked;

			taskControl.Mode = 1;
			Session.Add("TaskControl",taskControl);
			Session.Add("OldPayment",OldPayment);
			Response.Redirect("Payments.aspx",false);
		}

        protected void btnReceipt_Click(object sender, EventArgs e)
        {
            TaskControl.Payments taskControl = (TaskControl.Payments)Session["TaskControl"];

            EPolicy2.Reports.Payments.PaymentReceipt rpt = new EPolicy2.Reports.Payments.PaymentReceipt(taskControl);
            rpt.Run(false);

            Session.Add("Report", rpt);

            Session.Add("FromPage", "Payments.aspx");

            Response.Redirect("ActiveXViewer.aspx", false);
        }

        private void History(int taskControlID, int userID, string action, string subject, string note)
        {
            Audit.History history = new Audit.History();
            //TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];

            TaskControl.TaskControl taskControlpol = TaskControl.TaskControl.GetTaskControlByTaskControlID(int.Parse(txtTCIDPolicy.Text.Trim()), 1);
            Policy pol = (Policy)taskControlpol;

            history.Actions = action;
            history.KeyID = taskControlpol.TaskControlID.ToString();
            history.Subject = subject;
            //history.BuildNotesForHistory("TaskControlID.", "", taskControlID.ToString(), 7);  //7 = mode NOTICEOFCANC
            history.UsersID = userID;
            history.Notes = note + "\r\n";
            history.GetSaveHistory();
        }
}
}
