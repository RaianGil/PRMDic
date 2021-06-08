using System;
using System.Data;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Text.RegularExpressions;
using EPolicy.Customer;
//using EPolicy.PolicyManagement;
using EPolicy.LookupTables;
using EPolicy.TaskControl;

namespace EPolicy2.Reports
{
	public class CustomerProfile : DataDynamics.ActiveReports.ActiveReport3
	{

		private int index = 0;
		private double _TotalBalance=0;
		private EPolicy.Customer.Customer _customer;
		private DataTable _dtPolicies;

		public CustomerProfile(EPolicy.Customer.Customer customer)
		{
			_customer = customer;
			_dtPolicies = Policy.GetPoliciesByCustomerNo(_customer.CustomerNo);
			//_dtPolicies = TaskControl.GetPoliciesFromHdpolicyByCustomerNo(_customer.CustomerNo);
			InitializeComponent();
		}

		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
		 
			
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{

		}

		private void CustomerProfile_DataInitialize(object sender, System.EventArgs eArgs)
		{ 
			ChbMarketingBlock.Checked				= false;
			ChbNoticeOfCancellation.Checked			= false;
			TxtHomePhone.Text						= "";
			TxtJobPhone.Text						= "";
			TxtGender.Text							= "";
			TxtSocialSecurity.Text					= "";
			TxtName.Text							= "";
			TxtOccupation.Text						= "";
			TxtMaritalStatus.Text				    = "";
			TxtEmail.Text							= "";
			TxtCustomerNo.Text						= "";							  
			TxtLicense.Text							= "";
			TxtBirthdate.Text						= "";		
			TxtPostalAddress1.Text					= "";
			TxtPostalAddress2.Text					= "";
			TxtPostalCity.Text						= "";
			TxtPostalState.Text						= "";
			TxtPostalZipcode.Text					= "";
			TxtPhysicalZipCode.Text  				= "";
			TxtPhysicalAddress1.Text				= "";
			TxtPhysicalAddress2.Text				= "";
			TxtPhysicalCity.Text					= "";
			TxtPhysicalState.Text					= "";
			TxtPhysicalZipCode.Text					= "";
			TxtCompanyName.Text						= "";
			TxtEmplCity.Text						= "";
			
			this.Fields.Clear();
			this.Fields.Add("Status");
			this.Fields.Add("EffectiveDate");
			this.Fields.Add("PolicyClass");
			this.Fields.Add("ExpirationDate");
			this.Fields.Add("TotalPremium");
			this.Fields.Add("TotalPaid");
			this.Fields.Add("Balance");
			this.Fields.Add("TotalBalance");
			TxtCount.Text							= "0";
		}

		private void CustomerProfile_FetchData(object sender, DataDynamics.ActiveReports.ActiveReport3.FetchEventArgs eArgs)
		{
			
			if (index <= _dtPolicies.Rows.Count-1)
			{
				eArgs.EOF = false;

				this.Fields["PolicyClass"].Value = _dtPolicies.Rows[index]["PolicyNo"].ToString().Trim()+" "+
				 _dtPolicies.Rows[index]["Certificate"].ToString().Trim()+" "+
				 _dtPolicies.Rows[index]["Sufijo"].ToString().Trim();

				string effDate	= ((DateTime) _dtPolicies.Rows[index]["Effectivedate"]).ToShortDateString();
				//effDate     	= effDate.Substring(0,4)=="1899" ? "":effDate.Substring(5,2)+"/"+effDate.Substring(8,2)+"/"+effDate.Substring(0,4);

                string expDate = ((DateTime)_dtPolicies.Rows[index]["ExpirationDate"]).ToShortDateString();
				//expDate     	= expDate.Substring(0,4)=="1899" ? "":expDate.Substring(5,2)+"/"+expDate.Substring(8,2)+"/"+expDate.Substring(0,4);

				this.Fields["EffectiveDate"].Value   = effDate;
				//this.Fields["PolicyClass"].Value     = _dtPolicies.Rows[index]["PolicyClass"];
				this.Fields["ExpirationDate"].Value  = expDate;
				this.Fields["Status"].Value			 = _dtPolicies.Rows[index]["Status"];

				string charge			= (_dtPolicies.Rows[index]["Charge"]!=System.DBNull.Value) ? _dtPolicies.Rows[index]["Charge"].ToString().Trim():"0.00";
				string premium			= (_dtPolicies.Rows[index]["TotalPremium"]!=System.DBNull.Value) ?  _dtPolicies.Rows[index]["TotalPremium"].ToString().Trim():"0.00";
				decimal charge1			= decimal.Parse(charge);
				decimal premium1		= decimal.Parse(premium);
				decimal totpremium		= charge1 + premium1;
			
				string paymentAmount	= _dtPolicies.Rows[index]["PaidAmount"].ToString();
				decimal paymentAmount1 = decimal.Parse(paymentAmount);

				this.Fields["TotalPremium"].Value    = totpremium;
				this.Fields["TotalPaid"].Value       = paymentAmount1;
				this.Fields["Balance"].Value         = totpremium - paymentAmount1;
	
				double TotalBalance = double.Parse(_dtPolicies.Rows[index]["TotalPremium"].ToString());
				_TotalBalance = _TotalBalance+TotalBalance;
				
				this.Fields["TotalBalance"].Value =_TotalBalance;//.ToString("###,###.00");

				int count = index +1;
				TxtCount.Text	= count.ToString();
			}
			else
			{
				eArgs.EOF = true;
			}				
			
			if (index==0)
			{	
				if (_customer.OptOut)
				{
					ChbMarketingBlock.Checked = true;
				}
				else
				{
					ChbMarketingBlock.Checked = false;
				}

				if (_customer.NoticeCancellation)
				{
					ChbNoticeOfCancellation.Checked = true;
				}
				else
				{
					ChbNoticeOfCancellation.Checked = false;
				}

				if(Regex.IsMatch(_customer.HomePhone,"[0-9]{10}"))
				{
					TxtHomePhone.Text = "(" + (_customer.HomePhone).Substring(0,3)+ ") " +  
						(_customer.HomePhone).Substring(3,3) + " - " + 
						(_customer.HomePhone).Substring(6,4);
				}
				else
				{
					TxtHomePhone.Text =_customer.HomePhone;
				}

				if(Regex.IsMatch(_customer.JobPhone,"[0-9]{10}"))
				{
					TxtJobPhone.Text = "(" + (_customer.JobPhone).Substring(0,3)+ ") " +  
						(_customer.JobPhone).Substring(3,3) + " - " + 
						(_customer.JobPhone).Substring(6,4);
				}
				else
				{
					TxtJobPhone.Text = _customer.JobPhone;
				}

					
				if(Regex.IsMatch(_customer.SocialSecurity,"[0-9]{9}"))
				{
					TxtSocialSecurity.Text = (_customer.SocialSecurity).Substring(0,3) + "-" + 
						(_customer.SocialSecurity).Substring(3,2) + "-" + 
						(_customer.SocialSecurity).Substring(5,4);
				}
				else
				{
					TxtSocialSecurity.Text = _customer.SocialSecurity;
				}

				TxtName.Text							= _customer.FirstName.Trim() + " " + _customer.Initial.Trim() + " " + _customer.LastName1.Trim() + " " + _customer.LastName2.Trim(); 
				
				if (_customer.IsBusiness)
				{
					Label9.Visible = false;
					Label6.Visible = false;
					TextBox1.Visible = false;
					Label14.Visible = false;
					Label15.Visible = false;
				}
				else
				{
					TxtMaritalStatus.Text				    = LookupTables.GetDescription("MaritalStatus", _customer.MaritalStatus.ToString());
					TxtBirthdate.Text						= _customer.Birthday;	
					TxtOccupation.Text						= _customer.Occupation;
					TxtLicense.Text							= _customer.Licence;

					if (_customer.Sex == "M") 
					{
						TxtGender.Text = "Male";
					}
					else 
					{
						if (_customer.Sex == "F")
						{
							TxtGender.Text = "Female";
						}
					}
				}

				TxtEmail.Text							= _customer.Email;
				TxtCustomerNo.Text						= _customer.CustomerNo;								  

				TxtPostalAddress1.Text					= _customer.Address1;
				TxtPostalAddress2.Text					= _customer.Address2;
				TxtPostalCity.Text						=_customer.City;
				TxtPostalState.Text						= _customer.State;
				TxtPhysicalZipCode.Text  				= _customer.ZipCode;
				TxtPhysicalAddress1.Text				= _customer.AddressPhysical1;
				TxtPhysicalAddress2.Text				= _customer.AddressPhysical2;
				TxtPhysicalCity.Text					= _customer.CityPhysical;
				TxtPhysicalState.Text					= _customer.StatePhysical;
				TxtPhysicalZipCode.Text					= _customer.ZipPhysical;
				TxtCompanyName.Text						= _customer.EmplName;
				TxtEmplCity.Text						= _customer.EmplCity;
			}
			
			index ++;
		}
		#region ActiveReports Designer generated code
		private PageHeader PageHeader = null;
		private Label Label1 = null;
		private Line Line2 = null;
		private Label Label5 = null;
		private Label Label6 = null;
		private TextBox TextBox1 = null;
		private TextBox TxtName = null;
		private Label Label7 = null;
		private Label Label8 = null;
		private Label Label9 = null;
		private Label Label10 = null;
		private Label Label11 = null;
		private Label Label12 = null;
		private Label Label14 = null;
		private Label Label15 = null;
		private TextBox TxtOccupation = null;
		private TextBox TxtHomePhone = null;
		private TextBox TxtJobPhone = null;
		private TextBox TxtEmail = null;
		private TextBox TxtSocialSecurity = null;
		private TextBox TxtMaritalStatus = null;
		private TextBox TxtGender = null;
		private TextBox TxtLicense = null;
		private TextBox TxtBirthdate = null;
		private Label Label17 = null;
		private Label Label18 = null;
		private Label Label19 = null;
		private Label Label20 = null;
		private Label Label21 = null;
		private TextBox TxtPostalAddress1 = null;
		private TextBox TxtPostalAddress2 = null;
		private TextBox TxtPostalCity = null;
		private TextBox TxtPostalState = null;
		private TextBox TxtPostalZipcode = null;
		private Label Label22 = null;
		private TextBox TxtCompanyName = null;
		private Label Label23 = null;
		private Label Label24 = null;
		private Label Label25 = null;
		private Label Label26 = null;
		private Label Label27 = null;
		private TextBox TxtPhysicalAddress1 = null;
		private TextBox TxtPhysicalAddress2 = null;
		private TextBox TxtPhysicalCity = null;
		private TextBox TxtPhysicalState = null;
		private TextBox TxtPhysicalZipCode = null;
		private Label Label28 = null;
		private Label Label29 = null;
		private Label Label42 = null;
		private TextBox TxtCustomerNo = null;
		private Label Label43 = null;
		private Label Label44 = null;
		private Label Label45 = null;
		private Label Label47 = null;
		private Label Label48 = null;
		private Label Label49 = null;
		private Label Label50 = null;
		private Line Line1 = null;
		private Line Line3 = null;
		private Line Line4 = null;
		private Label Label51 = null;
		private CheckBox ChbMarketingBlock = null;
		private TextBox TxtEmplCity = null;
		private CheckBox ChbNoticeOfCancellation = null;
		private Label Label75 = null;
		private Label Label77 = null;
		private GroupHeader GroupHeader1 = null;
		private Detail Detail = null;
		private TextBox TextBox35 = null;
		private TextBox TextBox36 = null;
		private TextBox TextBox37 = null;
		private TextBox TextBox39 = null;
		private TextBox TextBox40 = null;
		private TextBox txtTotalPaid = null;
		private TextBox TextBox41 = null;
		private TextBox TextBox42 = null;
		private GroupFooter GroupFooter1 = null;
		private TextBox TxtTotBalance = null;
		private TextBox TxtTotTotalPrem = null;
		private Label Label78 = null;
		private Line Line5 = null;
		private TextBox TxtCount = null;
		private TextBox TxtTotTotalPaid = null;
		private PageFooter PageFooter = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerProfile));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.TextBox35 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox36 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox37 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox39 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox40 = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalPaid = new DataDynamics.ActiveReports.TextBox();
            this.TextBox41 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox42 = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.Label5 = new DataDynamics.ActiveReports.Label();
            this.Label6 = new DataDynamics.ActiveReports.Label();
            this.TextBox1 = new DataDynamics.ActiveReports.TextBox();
            this.TxtName = new DataDynamics.ActiveReports.TextBox();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.Label8 = new DataDynamics.ActiveReports.Label();
            this.Label9 = new DataDynamics.ActiveReports.Label();
            this.Label10 = new DataDynamics.ActiveReports.Label();
            this.Label11 = new DataDynamics.ActiveReports.Label();
            this.Label12 = new DataDynamics.ActiveReports.Label();
            this.Label14 = new DataDynamics.ActiveReports.Label();
            this.Label15 = new DataDynamics.ActiveReports.Label();
            this.TxtOccupation = new DataDynamics.ActiveReports.TextBox();
            this.TxtHomePhone = new DataDynamics.ActiveReports.TextBox();
            this.TxtJobPhone = new DataDynamics.ActiveReports.TextBox();
            this.TxtEmail = new DataDynamics.ActiveReports.TextBox();
            this.TxtSocialSecurity = new DataDynamics.ActiveReports.TextBox();
            this.TxtMaritalStatus = new DataDynamics.ActiveReports.TextBox();
            this.TxtGender = new DataDynamics.ActiveReports.TextBox();
            this.TxtLicense = new DataDynamics.ActiveReports.TextBox();
            this.TxtBirthdate = new DataDynamics.ActiveReports.TextBox();
            this.Label17 = new DataDynamics.ActiveReports.Label();
            this.Label18 = new DataDynamics.ActiveReports.Label();
            this.Label19 = new DataDynamics.ActiveReports.Label();
            this.Label20 = new DataDynamics.ActiveReports.Label();
            this.Label21 = new DataDynamics.ActiveReports.Label();
            this.TxtPostalAddress1 = new DataDynamics.ActiveReports.TextBox();
            this.TxtPostalAddress2 = new DataDynamics.ActiveReports.TextBox();
            this.TxtPostalCity = new DataDynamics.ActiveReports.TextBox();
            this.TxtPostalState = new DataDynamics.ActiveReports.TextBox();
            this.TxtPostalZipcode = new DataDynamics.ActiveReports.TextBox();
            this.Label22 = new DataDynamics.ActiveReports.Label();
            this.TxtCompanyName = new DataDynamics.ActiveReports.TextBox();
            this.Label23 = new DataDynamics.ActiveReports.Label();
            this.Label24 = new DataDynamics.ActiveReports.Label();
            this.Label25 = new DataDynamics.ActiveReports.Label();
            this.Label26 = new DataDynamics.ActiveReports.Label();
            this.Label27 = new DataDynamics.ActiveReports.Label();
            this.TxtPhysicalAddress1 = new DataDynamics.ActiveReports.TextBox();
            this.TxtPhysicalAddress2 = new DataDynamics.ActiveReports.TextBox();
            this.TxtPhysicalCity = new DataDynamics.ActiveReports.TextBox();
            this.TxtPhysicalState = new DataDynamics.ActiveReports.TextBox();
            this.TxtPhysicalZipCode = new DataDynamics.ActiveReports.TextBox();
            this.Label28 = new DataDynamics.ActiveReports.Label();
            this.Label29 = new DataDynamics.ActiveReports.Label();
            this.Label42 = new DataDynamics.ActiveReports.Label();
            this.TxtCustomerNo = new DataDynamics.ActiveReports.TextBox();
            this.Label43 = new DataDynamics.ActiveReports.Label();
            this.Label44 = new DataDynamics.ActiveReports.Label();
            this.Label45 = new DataDynamics.ActiveReports.Label();
            this.Label47 = new DataDynamics.ActiveReports.Label();
            this.Label48 = new DataDynamics.ActiveReports.Label();
            this.Label49 = new DataDynamics.ActiveReports.Label();
            this.Label50 = new DataDynamics.ActiveReports.Label();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Line3 = new DataDynamics.ActiveReports.Line();
            this.Line4 = new DataDynamics.ActiveReports.Line();
            this.Label51 = new DataDynamics.ActiveReports.Label();
            this.ChbMarketingBlock = new DataDynamics.ActiveReports.CheckBox();
            this.TxtEmplCity = new DataDynamics.ActiveReports.TextBox();
            this.ChbNoticeOfCancellation = new DataDynamics.ActiveReports.CheckBox();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label77 = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.GroupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.GroupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.TxtTotBalance = new DataDynamics.ActiveReports.TextBox();
            this.TxtTotTotalPrem = new DataDynamics.ActiveReports.TextBox();
            this.Label78 = new DataDynamics.ActiveReports.Label();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.TxtCount = new DataDynamics.ActiveReports.TextBox();
            this.TxtTotTotalPaid = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPaid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOccupation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtHomePhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtJobPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSocialSecurity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMaritalStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtGender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBirthdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPostalAddress1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPostalAddress2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPostalCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPostalState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPostalZipcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCompanyName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPhysicalAddress1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPhysicalAddress2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPhysicalCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPhysicalState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPhysicalZipCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChbMarketingBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEmplCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChbNoticeOfCancellation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotTotalPrem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label78)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotTotalPaid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TextBox35,
            this.TextBox36,
            this.TextBox37,
            this.TextBox39,
            this.TextBox40,
            this.txtTotalPaid,
            this.TextBox41,
            this.TextBox42});
            this.Detail.Height = 0.2291667F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // TextBox35
            // 
            this.TextBox35.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox35.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox35.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox35.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox35.DataField = "EffectiveDate";
            this.TextBox35.Height = 0.2F;
            this.TextBox35.Left = 2.260417F;
            this.TextBox35.Name = "TextBox35";
            this.TextBox35.OutputFormat = resources.GetString("TextBox35.OutputFormat");
            this.TextBox35.Style = "font-size: 8.25pt; ";
            this.TextBox35.Text = "TextBox35";
            this.TextBox35.Top = 0F;
            this.TextBox35.Width = 0.75F;
            // 
            // TextBox36
            // 
            this.TextBox36.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox36.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox36.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox36.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox36.DataField = "PolicyClass";
            this.TextBox36.Height = 0.2F;
            this.TextBox36.Left = 0.5625F;
            this.TextBox36.Name = "TextBox36";
            this.TextBox36.Style = "font-size: 8.25pt; ";
            this.TextBox36.Text = "TextBox36";
            this.TextBox36.Top = 0F;
            this.TextBox36.Width = 1.625F;
            // 
            // TextBox37
            // 
            this.TextBox37.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox37.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox37.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox37.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox37.DataField = "ExpirationDate";
            this.TextBox37.Height = 0.2F;
            this.TextBox37.Left = 3.3125F;
            this.TextBox37.Name = "TextBox37";
            this.TextBox37.OutputFormat = resources.GetString("TextBox37.OutputFormat");
            this.TextBox37.Style = "font-size: 8.25pt; ";
            this.TextBox37.Text = "TextBox37";
            this.TextBox37.Top = 0F;
            this.TextBox37.Width = 0.75F;
            // 
            // TextBox39
            // 
            this.TextBox39.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox39.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox39.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox39.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox39.DataField = "TotalPremium";
            this.TextBox39.Height = 0.2F;
            this.TextBox39.Left = 5.0625F;
            this.TextBox39.Name = "TextBox39";
            this.TextBox39.OutputFormat = resources.GetString("TextBox39.OutputFormat");
            this.TextBox39.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox39.Text = "TextBox39";
            this.TextBox39.Top = 0F;
            this.TextBox39.Width = 1F;
            // 
            // TextBox40
            // 
            this.TextBox40.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox40.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox40.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox40.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox40.DataField = "Balance";
            this.TextBox40.Height = 0.2F;
            this.TextBox40.Left = 7.375F;
            this.TextBox40.Name = "TextBox40";
            this.TextBox40.OutputFormat = resources.GetString("TextBox40.OutputFormat");
            this.TextBox40.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox40.Text = "TextBox40";
            this.TextBox40.Top = 0F;
            this.TextBox40.Width = 0.8125F;
            // 
            // txtTotalPaid
            // 
            this.txtTotalPaid.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalPaid.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalPaid.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalPaid.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalPaid.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalPaid.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalPaid.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalPaid.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalPaid.DataField = "TotalPaid";
            this.txtTotalPaid.Height = 0.2F;
            this.txtTotalPaid.Left = 6.25F;
            this.txtTotalPaid.Name = "txtTotalPaid";
            this.txtTotalPaid.OutputFormat = resources.GetString("txtTotalPaid.OutputFormat");
            this.txtTotalPaid.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtTotalPaid.Text = "TextBox41";
            this.txtTotalPaid.Top = 0F;
            this.txtTotalPaid.Width = 0.875F;
            // 
            // TextBox41
            // 
            this.TextBox41.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox41.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox41.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox41.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox41.DataField = "Status";
            this.TextBox41.Height = 0.2F;
            this.TextBox41.Left = 4.3125F;
            this.TextBox41.Name = "TextBox41";
            this.TextBox41.OutputFormat = resources.GetString("TextBox41.OutputFormat");
            this.TextBox41.Style = "font-size: 8.25pt; ";
            this.TextBox41.Text = "TextBox41";
            this.TextBox41.Top = 0F;
            this.TextBox41.Width = 1F;
            // 
            // TextBox42
            // 
            this.TextBox42.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox42.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox42.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox42.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox42.DataField = "TotalPaid";
            this.TextBox42.Height = 0.2F;
            this.TextBox42.Left = 6.1875F;
            this.TextBox42.Name = "TextBox42";
            this.TextBox42.OutputFormat = resources.GetString("TextBox42.OutputFormat");
            this.TextBox42.Style = "font-size: 8.25pt; ";
            this.TextBox42.Text = "TextBox41";
            this.TextBox42.Top = 0.5F;
            this.TextBox42.Width = 0.875F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label1,
            this.Line2,
            this.Label5,
            this.Label6,
            this.TextBox1,
            this.TxtName,
            this.Label7,
            this.Label8,
            this.Label9,
            this.Label10,
            this.Label11,
            this.Label12,
            this.Label14,
            this.Label15,
            this.TxtOccupation,
            this.TxtHomePhone,
            this.TxtJobPhone,
            this.TxtEmail,
            this.TxtSocialSecurity,
            this.TxtMaritalStatus,
            this.TxtGender,
            this.TxtLicense,
            this.TxtBirthdate,
            this.Label17,
            this.Label18,
            this.Label19,
            this.Label20,
            this.Label21,
            this.TxtPostalAddress1,
            this.TxtPostalAddress2,
            this.TxtPostalCity,
            this.TxtPostalState,
            this.TxtPostalZipcode,
            this.Label22,
            this.TxtCompanyName,
            this.Label23,
            this.Label24,
            this.Label25,
            this.Label26,
            this.Label27,
            this.TxtPhysicalAddress1,
            this.TxtPhysicalAddress2,
            this.TxtPhysicalCity,
            this.TxtPhysicalState,
            this.TxtPhysicalZipCode,
            this.Label28,
            this.Label29,
            this.Label42,
            this.TxtCustomerNo,
            this.Label43,
            this.Label44,
            this.Label45,
            this.Label47,
            this.Label48,
            this.Label49,
            this.Label50,
            this.Line1,
            this.Line3,
            this.Line4,
            this.Label51,
            this.ChbMarketingBlock,
            this.TxtEmplCity,
            this.ChbNoticeOfCancellation,
            this.Label75,
            this.Label77});
            this.PageHeader.Height = 5.395833F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // Label1
            // 
            this.Label1.Border.BottomColor = System.Drawing.Color.Black;
            this.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.LeftColor = System.Drawing.Color.Black;
            this.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.RightColor = System.Drawing.Color.Black;
            this.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.TopColor = System.Drawing.Color.Black;
            this.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Height = 0.1875F;
            this.Label1.HyperLink = "";
            this.Label1.Left = 1.6875F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 11pt; ";
            this.Label1.Text = "CUSTOMER PROFILE";
            this.Label1.Top = 0.5625F;
            this.Label1.Width = 5.125F;
            // 
            // Line2
            // 
            this.Line2.Border.BottomColor = System.Drawing.Color.Black;
            this.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.LeftColor = System.Drawing.Color.Black;
            this.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.RightColor = System.Drawing.Color.Black;
            this.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.TopColor = System.Drawing.Color.Black;
            this.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Height = 0F;
            this.Line2.Left = 0.375F;
            this.Line2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 3.3125F;
            this.Line2.Width = 7.9375F;
            this.Line2.X1 = 0.375F;
            this.Line2.X2 = 8.3125F;
            this.Line2.Y1 = 3.3125F;
            this.Line2.Y2 = 3.3125F;
            // 
            // Label5
            // 
            this.Label5.Border.BottomColor = System.Drawing.Color.Black;
            this.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label5.Border.LeftColor = System.Drawing.Color.Black;
            this.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label5.Border.RightColor = System.Drawing.Color.Black;
            this.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label5.Border.TopColor = System.Drawing.Color.Black;
            this.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label5.Height = 0.2F;
            this.Label5.HyperLink = "";
            this.Label5.Left = 4.5F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label5.Text = "Social Security";
            this.Label5.Top = 1.5625F;
            this.Label5.Width = 1F;
            // 
            // Label6
            // 
            this.Label6.Border.BottomColor = System.Drawing.Color.Black;
            this.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.LeftColor = System.Drawing.Color.Black;
            this.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.RightColor = System.Drawing.Color.Black;
            this.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.TopColor = System.Drawing.Color.Black;
            this.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Height = 0.2F;
            this.Label6.HyperLink = "";
            this.Label6.Left = 4.5F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label6.Text = "Marital Status:";
            this.Label6.Top = 1.8125F;
            this.Label6.Width = 1F;
            // 
            // TextBox1
            // 
            this.TextBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Height = 0.2F;
            this.TextBox1.Left = 4.5F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.TextBox1.Text = "Birthdate:";
            this.TextBox1.Top = 2.75F;
            this.TextBox1.Width = 0.625F;
            // 
            // TxtName
            // 
            this.TxtName.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtName.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtName.Border.RightColor = System.Drawing.Color.Black;
            this.TxtName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtName.Border.TopColor = System.Drawing.Color.Black;
            this.TxtName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtName.Height = 0.2F;
            this.TxtName.Left = 1.6875F;
            this.TxtName.MultiLine = false;
            this.TxtName.Name = "TxtName";
            this.TxtName.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.TxtName.Text = "TxtName";
            this.TxtName.Top = 1.3125F;
            this.TxtName.Width = 2.375F;
            // 
            // Label7
            // 
            this.Label7.Border.BottomColor = System.Drawing.Color.Black;
            this.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.LeftColor = System.Drawing.Color.Black;
            this.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.RightColor = System.Drawing.Color.Black;
            this.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.TopColor = System.Drawing.Color.Black;
            this.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Height = 0.2F;
            this.Label7.HyperLink = "";
            this.Label7.Left = 0.5F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label7.Text = "Name:";
            this.Label7.Top = 1.3125F;
            this.Label7.Width = 1F;
            // 
            // Label8
            // 
            this.Label8.Border.BottomColor = System.Drawing.Color.Black;
            this.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.LeftColor = System.Drawing.Color.Black;
            this.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.RightColor = System.Drawing.Color.Black;
            this.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.TopColor = System.Drawing.Color.Black;
            this.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Height = 0.2F;
            this.Label8.HyperLink = "";
            this.Label8.Left = 0.4375F;
            this.Label8.Name = "Label8";
            this.Label8.Style = "color: Black; font-weight: bold; ";
            this.Label8.Text = "Customer Information";
            this.Label8.Top = 1F;
            this.Label8.Width = 1.5625F;
            // 
            // Label9
            // 
            this.Label9.Border.BottomColor = System.Drawing.Color.Black;
            this.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.LeftColor = System.Drawing.Color.Black;
            this.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.RightColor = System.Drawing.Color.Black;
            this.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.TopColor = System.Drawing.Color.Black;
            this.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Height = 0.2F;
            this.Label9.HyperLink = "";
            this.Label9.Left = 0.5F;
            this.Label9.Name = "Label9";
            this.Label9.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label9.Text = "Occupation:";
            this.Label9.Top = 1.5625F;
            this.Label9.Width = 1F;
            // 
            // Label10
            // 
            this.Label10.Border.BottomColor = System.Drawing.Color.Black;
            this.Label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.LeftColor = System.Drawing.Color.Black;
            this.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.RightColor = System.Drawing.Color.Black;
            this.Label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.TopColor = System.Drawing.Color.Black;
            this.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Height = 0.2F;
            this.Label10.HyperLink = "";
            this.Label10.Left = 0.5F;
            this.Label10.Name = "Label10";
            this.Label10.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label10.Text = "Home Phone:";
            this.Label10.Top = 2.25F;
            this.Label10.Width = 1F;
            // 
            // Label11
            // 
            this.Label11.Border.BottomColor = System.Drawing.Color.Black;
            this.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.LeftColor = System.Drawing.Color.Black;
            this.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.RightColor = System.Drawing.Color.Black;
            this.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.TopColor = System.Drawing.Color.Black;
            this.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Height = 0.2F;
            this.Label11.HyperLink = "";
            this.Label11.Left = 0.5F;
            this.Label11.Name = "Label11";
            this.Label11.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label11.Text = "Work Phone:";
            this.Label11.Top = 2.5F;
            this.Label11.Width = 1F;
            // 
            // Label12
            // 
            this.Label12.Border.BottomColor = System.Drawing.Color.Black;
            this.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label12.Border.LeftColor = System.Drawing.Color.Black;
            this.Label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label12.Border.RightColor = System.Drawing.Color.Black;
            this.Label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label12.Border.TopColor = System.Drawing.Color.Black;
            this.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label12.Height = 0.2F;
            this.Label12.HyperLink = "";
            this.Label12.Left = 0.5F;
            this.Label12.Name = "Label12";
            this.Label12.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label12.Text = "E-mail:";
            this.Label12.Top = 2.75F;
            this.Label12.Width = 1F;
            // 
            // Label14
            // 
            this.Label14.Border.BottomColor = System.Drawing.Color.Black;
            this.Label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.LeftColor = System.Drawing.Color.Black;
            this.Label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.RightColor = System.Drawing.Color.Black;
            this.Label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.TopColor = System.Drawing.Color.Black;
            this.Label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Height = 0.2F;
            this.Label14.HyperLink = "";
            this.Label14.Left = 4.5F;
            this.Label14.Name = "Label14";
            this.Label14.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label14.Text = "Gender:";
            this.Label14.Top = 2.25F;
            this.Label14.Width = 1F;
            // 
            // Label15
            // 
            this.Label15.Border.BottomColor = System.Drawing.Color.Black;
            this.Label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.LeftColor = System.Drawing.Color.Black;
            this.Label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.RightColor = System.Drawing.Color.Black;
            this.Label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.TopColor = System.Drawing.Color.Black;
            this.Label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Height = 0.2F;
            this.Label15.HyperLink = "";
            this.Label15.Left = 4.5F;
            this.Label15.Name = "Label15";
            this.Label15.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label15.Text = "License:";
            this.Label15.Top = 2.5F;
            this.Label15.Width = 1F;
            // 
            // TxtOccupation
            // 
            this.TxtOccupation.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtOccupation.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtOccupation.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtOccupation.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtOccupation.Border.RightColor = System.Drawing.Color.Black;
            this.TxtOccupation.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtOccupation.Border.TopColor = System.Drawing.Color.Black;
            this.TxtOccupation.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtOccupation.Height = 0.2F;
            this.TxtOccupation.Left = 1.6875F;
            this.TxtOccupation.Name = "TxtOccupation";
            this.TxtOccupation.Style = "font-size: 8.25pt; ";
            this.TxtOccupation.Text = "TxtOccupation";
            this.TxtOccupation.Top = 1.5625F;
            this.TxtOccupation.Width = 1F;
            // 
            // TxtHomePhone
            // 
            this.TxtHomePhone.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtHomePhone.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtHomePhone.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtHomePhone.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtHomePhone.Border.RightColor = System.Drawing.Color.Black;
            this.TxtHomePhone.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtHomePhone.Border.TopColor = System.Drawing.Color.Black;
            this.TxtHomePhone.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtHomePhone.Height = 0.2F;
            this.TxtHomePhone.Left = 1.6875F;
            this.TxtHomePhone.Name = "TxtHomePhone";
            this.TxtHomePhone.OutputFormat = resources.GetString("TxtHomePhone.OutputFormat");
            this.TxtHomePhone.Style = "font-size: 8.25pt; ";
            this.TxtHomePhone.Text = "TxtHomePhone";
            this.TxtHomePhone.Top = 2.25F;
            this.TxtHomePhone.Width = 1F;
            // 
            // TxtJobPhone
            // 
            this.TxtJobPhone.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtJobPhone.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtJobPhone.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtJobPhone.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtJobPhone.Border.RightColor = System.Drawing.Color.Black;
            this.TxtJobPhone.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtJobPhone.Border.TopColor = System.Drawing.Color.Black;
            this.TxtJobPhone.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtJobPhone.Height = 0.2F;
            this.TxtJobPhone.Left = 1.6875F;
            this.TxtJobPhone.Name = "TxtJobPhone";
            this.TxtJobPhone.Style = "font-size: 8.25pt; ";
            this.TxtJobPhone.Text = "TxtJobPhone";
            this.TxtJobPhone.Top = 2.5F;
            this.TxtJobPhone.Width = 1F;
            // 
            // TxtEmail
            // 
            this.TxtEmail.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtEmail.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEmail.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtEmail.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEmail.Border.RightColor = System.Drawing.Color.Black;
            this.TxtEmail.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEmail.Border.TopColor = System.Drawing.Color.Black;
            this.TxtEmail.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEmail.Height = 0.2F;
            this.TxtEmail.Left = 1.6875F;
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Style = "font-size: 8.25pt; ";
            this.TxtEmail.Text = "TxtEmail";
            this.TxtEmail.Top = 2.75F;
            this.TxtEmail.Width = 2.5625F;
            // 
            // TxtSocialSecurity
            // 
            this.TxtSocialSecurity.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtSocialSecurity.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSocialSecurity.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtSocialSecurity.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSocialSecurity.Border.RightColor = System.Drawing.Color.Black;
            this.TxtSocialSecurity.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSocialSecurity.Border.TopColor = System.Drawing.Color.Black;
            this.TxtSocialSecurity.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtSocialSecurity.Height = 0.2F;
            this.TxtSocialSecurity.Left = 5.625F;
            this.TxtSocialSecurity.Name = "TxtSocialSecurity";
            this.TxtSocialSecurity.Style = "font-size: 8.25pt; ";
            this.TxtSocialSecurity.Text = "TxtSocialSecurity";
            this.TxtSocialSecurity.Top = 1.5625F;
            this.TxtSocialSecurity.Width = 1F;
            // 
            // TxtMaritalStatus
            // 
            this.TxtMaritalStatus.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtMaritalStatus.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMaritalStatus.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtMaritalStatus.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMaritalStatus.Border.RightColor = System.Drawing.Color.Black;
            this.TxtMaritalStatus.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMaritalStatus.Border.TopColor = System.Drawing.Color.Black;
            this.TxtMaritalStatus.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtMaritalStatus.Height = 0.2F;
            this.TxtMaritalStatus.Left = 5.625F;
            this.TxtMaritalStatus.Name = "TxtMaritalStatus";
            this.TxtMaritalStatus.Style = "font-size: 8.25pt; ";
            this.TxtMaritalStatus.Text = "TxtMaritalStatus";
            this.TxtMaritalStatus.Top = 1.8125F;
            this.TxtMaritalStatus.Width = 1F;
            // 
            // TxtGender
            // 
            this.TxtGender.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtGender.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtGender.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtGender.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtGender.Border.RightColor = System.Drawing.Color.Black;
            this.TxtGender.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtGender.Border.TopColor = System.Drawing.Color.Black;
            this.TxtGender.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtGender.Height = 0.2F;
            this.TxtGender.Left = 5.625F;
            this.TxtGender.Name = "TxtGender";
            this.TxtGender.Style = "font-size: 8.25pt; ";
            this.TxtGender.Text = "TxtGender";
            this.TxtGender.Top = 2.25F;
            this.TxtGender.Width = 1F;
            // 
            // TxtLicense
            // 
            this.TxtLicense.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtLicense.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLicense.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtLicense.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLicense.Border.RightColor = System.Drawing.Color.Black;
            this.TxtLicense.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLicense.Border.TopColor = System.Drawing.Color.Black;
            this.TxtLicense.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtLicense.Height = 0.2F;
            this.TxtLicense.Left = 5.625F;
            this.TxtLicense.Name = "TxtLicense";
            this.TxtLicense.Style = "font-size: 8.25pt; ";
            this.TxtLicense.Text = "TxtLicense";
            this.TxtLicense.Top = 2.5F;
            this.TxtLicense.Width = 1F;
            // 
            // TxtBirthdate
            // 
            this.TxtBirthdate.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtBirthdate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBirthdate.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtBirthdate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBirthdate.Border.RightColor = System.Drawing.Color.Black;
            this.TxtBirthdate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBirthdate.Border.TopColor = System.Drawing.Color.Black;
            this.TxtBirthdate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtBirthdate.Height = 0.2F;
            this.TxtBirthdate.Left = 5.625F;
            this.TxtBirthdate.Name = "TxtBirthdate";
            this.TxtBirthdate.Style = "font-size: 8.25pt; ";
            this.TxtBirthdate.Text = "TxtBirthdate";
            this.TxtBirthdate.Top = 2.75F;
            this.TxtBirthdate.Width = 1F;
            // 
            // Label17
            // 
            this.Label17.Border.BottomColor = System.Drawing.Color.Black;
            this.Label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label17.Border.LeftColor = System.Drawing.Color.Black;
            this.Label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label17.Border.RightColor = System.Drawing.Color.Black;
            this.Label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label17.Border.TopColor = System.Drawing.Color.Black;
            this.Label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label17.Height = 0.2F;
            this.Label17.HyperLink = "";
            this.Label17.Left = 0.5F;
            this.Label17.Name = "Label17";
            this.Label17.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label17.Text = "Address1:";
            this.Label17.Top = 3.4375F;
            this.Label17.Width = 0.5625F;
            // 
            // Label18
            // 
            this.Label18.Border.BottomColor = System.Drawing.Color.Black;
            this.Label18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label18.Border.LeftColor = System.Drawing.Color.Black;
            this.Label18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label18.Border.RightColor = System.Drawing.Color.Black;
            this.Label18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label18.Border.TopColor = System.Drawing.Color.Black;
            this.Label18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label18.Height = 0.2F;
            this.Label18.HyperLink = "";
            this.Label18.Left = 0.5F;
            this.Label18.Name = "Label18";
            this.Label18.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label18.Text = "Address2:";
            this.Label18.Top = 3.6875F;
            this.Label18.Width = 0.5625F;
            // 
            // Label19
            // 
            this.Label19.Border.BottomColor = System.Drawing.Color.Black;
            this.Label19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label19.Border.LeftColor = System.Drawing.Color.Black;
            this.Label19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label19.Border.RightColor = System.Drawing.Color.Black;
            this.Label19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label19.Border.TopColor = System.Drawing.Color.Black;
            this.Label19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label19.Height = 0.2F;
            this.Label19.HyperLink = "";
            this.Label19.Left = 0.5F;
            this.Label19.Name = "Label19";
            this.Label19.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label19.Text = "City:";
            this.Label19.Top = 3.9375F;
            this.Label19.Width = 0.5625F;
            // 
            // Label20
            // 
            this.Label20.Border.BottomColor = System.Drawing.Color.Black;
            this.Label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label20.Border.LeftColor = System.Drawing.Color.Black;
            this.Label20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label20.Border.RightColor = System.Drawing.Color.Black;
            this.Label20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label20.Border.TopColor = System.Drawing.Color.Black;
            this.Label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label20.Height = 0.2F;
            this.Label20.HyperLink = "";
            this.Label20.Left = 0.5F;
            this.Label20.Name = "Label20";
            this.Label20.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label20.Text = "State:";
            this.Label20.Top = 4.1875F;
            this.Label20.Width = 0.5625F;
            // 
            // Label21
            // 
            this.Label21.Border.BottomColor = System.Drawing.Color.Black;
            this.Label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.LeftColor = System.Drawing.Color.Black;
            this.Label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.RightColor = System.Drawing.Color.Black;
            this.Label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.TopColor = System.Drawing.Color.Black;
            this.Label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Height = 0.2F;
            this.Label21.HyperLink = "";
            this.Label21.Left = 0.5F;
            this.Label21.Name = "Label21";
            this.Label21.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label21.Text = "Zip Code:";
            this.Label21.Top = 4.4375F;
            this.Label21.Width = 0.5625F;
            // 
            // TxtPostalAddress1
            // 
            this.TxtPostalAddress1.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtPostalAddress1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPostalAddress1.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtPostalAddress1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPostalAddress1.Border.RightColor = System.Drawing.Color.Black;
            this.TxtPostalAddress1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPostalAddress1.Border.TopColor = System.Drawing.Color.Black;
            this.TxtPostalAddress1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPostalAddress1.Height = 0.2F;
            this.TxtPostalAddress1.Left = 1.125F;
            this.TxtPostalAddress1.Name = "TxtPostalAddress1";
            this.TxtPostalAddress1.Style = "font-size: 8.25pt; ";
            this.TxtPostalAddress1.Text = "TxtPostalAddress1";
            this.TxtPostalAddress1.Top = 3.4375F;
            this.TxtPostalAddress1.Width = 2.0625F;
            // 
            // TxtPostalAddress2
            // 
            this.TxtPostalAddress2.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtPostalAddress2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPostalAddress2.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtPostalAddress2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPostalAddress2.Border.RightColor = System.Drawing.Color.Black;
            this.TxtPostalAddress2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPostalAddress2.Border.TopColor = System.Drawing.Color.Black;
            this.TxtPostalAddress2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPostalAddress2.Height = 0.2F;
            this.TxtPostalAddress2.Left = 1.125F;
            this.TxtPostalAddress2.Name = "TxtPostalAddress2";
            this.TxtPostalAddress2.Style = "font-size: 8.25pt; ";
            this.TxtPostalAddress2.Text = "TxtPostalAddress2";
            this.TxtPostalAddress2.Top = 3.6875F;
            this.TxtPostalAddress2.Width = 2.0625F;
            // 
            // TxtPostalCity
            // 
            this.TxtPostalCity.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtPostalCity.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPostalCity.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtPostalCity.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPostalCity.Border.RightColor = System.Drawing.Color.Black;
            this.TxtPostalCity.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPostalCity.Border.TopColor = System.Drawing.Color.Black;
            this.TxtPostalCity.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPostalCity.Height = 0.2F;
            this.TxtPostalCity.Left = 1.125F;
            this.TxtPostalCity.Name = "TxtPostalCity";
            this.TxtPostalCity.Style = "font-size: 8.25pt; ";
            this.TxtPostalCity.Text = "TxtPostalCity";
            this.TxtPostalCity.Top = 3.9375F;
            this.TxtPostalCity.Width = 2.0625F;
            // 
            // TxtPostalState
            // 
            this.TxtPostalState.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtPostalState.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPostalState.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtPostalState.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPostalState.Border.RightColor = System.Drawing.Color.Black;
            this.TxtPostalState.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPostalState.Border.TopColor = System.Drawing.Color.Black;
            this.TxtPostalState.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPostalState.Height = 0.2F;
            this.TxtPostalState.Left = 1.125F;
            this.TxtPostalState.Name = "TxtPostalState";
            this.TxtPostalState.Style = "font-size: 8.25pt; ";
            this.TxtPostalState.Text = "TxtPostalState";
            this.TxtPostalState.Top = 4.1875F;
            this.TxtPostalState.Width = 2.0625F;
            // 
            // TxtPostalZipcode
            // 
            this.TxtPostalZipcode.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtPostalZipcode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPostalZipcode.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtPostalZipcode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPostalZipcode.Border.RightColor = System.Drawing.Color.Black;
            this.TxtPostalZipcode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPostalZipcode.Border.TopColor = System.Drawing.Color.Black;
            this.TxtPostalZipcode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPostalZipcode.Height = 0.2F;
            this.TxtPostalZipcode.Left = 1.125F;
            this.TxtPostalZipcode.Name = "TxtPostalZipcode";
            this.TxtPostalZipcode.Style = "font-size: 8.25pt; ";
            this.TxtPostalZipcode.Text = "TxtPostalZipcode";
            this.TxtPostalZipcode.Top = 4.4375F;
            this.TxtPostalZipcode.Width = 2.0625F;
            // 
            // Label22
            // 
            this.Label22.Border.BottomColor = System.Drawing.Color.Black;
            this.Label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.LeftColor = System.Drawing.Color.Black;
            this.Label22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.RightColor = System.Drawing.Color.Black;
            this.Label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.TopColor = System.Drawing.Color.Black;
            this.Label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Height = 0.2F;
            this.Label22.HyperLink = "";
            this.Label22.Left = 0.5F;
            this.Label22.Name = "Label22";
            this.Label22.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label22.Text = "Company Name:";
            this.Label22.Top = 1.8125F;
            this.Label22.Width = 1F;
            // 
            // TxtCompanyName
            // 
            this.TxtCompanyName.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCompanyName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCompanyName.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCompanyName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCompanyName.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCompanyName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCompanyName.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCompanyName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCompanyName.Height = 0.2F;
            this.TxtCompanyName.Left = 1.6875F;
            this.TxtCompanyName.Name = "TxtCompanyName";
            this.TxtCompanyName.Style = "font-size: 8.25pt; ";
            this.TxtCompanyName.Text = "TxtCompanyName";
            this.TxtCompanyName.Top = 1.8125F;
            this.TxtCompanyName.Width = 2.3125F;
            // 
            // Label23
            // 
            this.Label23.Border.BottomColor = System.Drawing.Color.Black;
            this.Label23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.LeftColor = System.Drawing.Color.Black;
            this.Label23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.RightColor = System.Drawing.Color.Black;
            this.Label23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.TopColor = System.Drawing.Color.Black;
            this.Label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Height = 0.2F;
            this.Label23.HyperLink = "";
            this.Label23.Left = 3.625F;
            this.Label23.Name = "Label23";
            this.Label23.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label23.Text = "Address1:";
            this.Label23.Top = 3.4375F;
            this.Label23.Width = 0.5625F;
            // 
            // Label24
            // 
            this.Label24.Border.BottomColor = System.Drawing.Color.Black;
            this.Label24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.LeftColor = System.Drawing.Color.Black;
            this.Label24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.RightColor = System.Drawing.Color.Black;
            this.Label24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.TopColor = System.Drawing.Color.Black;
            this.Label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Height = 0.2F;
            this.Label24.HyperLink = "";
            this.Label24.Left = 3.625F;
            this.Label24.Name = "Label24";
            this.Label24.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label24.Text = "Address2:";
            this.Label24.Top = 3.6875F;
            this.Label24.Width = 0.5625F;
            // 
            // Label25
            // 
            this.Label25.Border.BottomColor = System.Drawing.Color.Black;
            this.Label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.LeftColor = System.Drawing.Color.Black;
            this.Label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.RightColor = System.Drawing.Color.Black;
            this.Label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.TopColor = System.Drawing.Color.Black;
            this.Label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Height = 0.2F;
            this.Label25.HyperLink = "";
            this.Label25.Left = 3.625F;
            this.Label25.Name = "Label25";
            this.Label25.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label25.Text = "City:";
            this.Label25.Top = 3.9375F;
            this.Label25.Width = 0.5625F;
            // 
            // Label26
            // 
            this.Label26.Border.BottomColor = System.Drawing.Color.Black;
            this.Label26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.LeftColor = System.Drawing.Color.Black;
            this.Label26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.RightColor = System.Drawing.Color.Black;
            this.Label26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.TopColor = System.Drawing.Color.Black;
            this.Label26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Height = 0.2F;
            this.Label26.HyperLink = "";
            this.Label26.Left = 3.625F;
            this.Label26.Name = "Label26";
            this.Label26.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label26.Text = "State:";
            this.Label26.Top = 4.1875F;
            this.Label26.Width = 0.5625F;
            // 
            // Label27
            // 
            this.Label27.Border.BottomColor = System.Drawing.Color.Black;
            this.Label27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.LeftColor = System.Drawing.Color.Black;
            this.Label27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.RightColor = System.Drawing.Color.Black;
            this.Label27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.TopColor = System.Drawing.Color.Black;
            this.Label27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Height = 0.2F;
            this.Label27.HyperLink = "";
            this.Label27.Left = 3.625F;
            this.Label27.Name = "Label27";
            this.Label27.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label27.Text = "Zip Code:";
            this.Label27.Top = 4.4375F;
            this.Label27.Width = 0.5625F;
            // 
            // TxtPhysicalAddress1
            // 
            this.TxtPhysicalAddress1.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtPhysicalAddress1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhysicalAddress1.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtPhysicalAddress1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhysicalAddress1.Border.RightColor = System.Drawing.Color.Black;
            this.TxtPhysicalAddress1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhysicalAddress1.Border.TopColor = System.Drawing.Color.Black;
            this.TxtPhysicalAddress1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhysicalAddress1.Height = 0.2F;
            this.TxtPhysicalAddress1.Left = 4.25F;
            this.TxtPhysicalAddress1.Name = "TxtPhysicalAddress1";
            this.TxtPhysicalAddress1.Style = "font-size: 8.25pt; ";
            this.TxtPhysicalAddress1.Text = "TxtPhysicalAddress1";
            this.TxtPhysicalAddress1.Top = 3.4375F;
            this.TxtPhysicalAddress1.Width = 2.0625F;
            // 
            // TxtPhysicalAddress2
            // 
            this.TxtPhysicalAddress2.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtPhysicalAddress2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhysicalAddress2.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtPhysicalAddress2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhysicalAddress2.Border.RightColor = System.Drawing.Color.Black;
            this.TxtPhysicalAddress2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhysicalAddress2.Border.TopColor = System.Drawing.Color.Black;
            this.TxtPhysicalAddress2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhysicalAddress2.Height = 0.2F;
            this.TxtPhysicalAddress2.Left = 4.25F;
            this.TxtPhysicalAddress2.Name = "TxtPhysicalAddress2";
            this.TxtPhysicalAddress2.Style = "font-size: 8.25pt; ";
            this.TxtPhysicalAddress2.Text = "TxtPhysicalAddress2";
            this.TxtPhysicalAddress2.Top = 3.6875F;
            this.TxtPhysicalAddress2.Width = 2.0625F;
            // 
            // TxtPhysicalCity
            // 
            this.TxtPhysicalCity.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtPhysicalCity.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhysicalCity.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtPhysicalCity.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhysicalCity.Border.RightColor = System.Drawing.Color.Black;
            this.TxtPhysicalCity.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhysicalCity.Border.TopColor = System.Drawing.Color.Black;
            this.TxtPhysicalCity.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhysicalCity.Height = 0.2F;
            this.TxtPhysicalCity.Left = 4.25F;
            this.TxtPhysicalCity.Name = "TxtPhysicalCity";
            this.TxtPhysicalCity.Style = "font-size: 8.25pt; ";
            this.TxtPhysicalCity.Text = "TxtPhysicalCity";
            this.TxtPhysicalCity.Top = 3.9375F;
            this.TxtPhysicalCity.Width = 2.0625F;
            // 
            // TxtPhysicalState
            // 
            this.TxtPhysicalState.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtPhysicalState.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhysicalState.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtPhysicalState.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhysicalState.Border.RightColor = System.Drawing.Color.Black;
            this.TxtPhysicalState.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhysicalState.Border.TopColor = System.Drawing.Color.Black;
            this.TxtPhysicalState.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhysicalState.Height = 0.2F;
            this.TxtPhysicalState.Left = 4.25F;
            this.TxtPhysicalState.Name = "TxtPhysicalState";
            this.TxtPhysicalState.Style = "font-size: 8.25pt; ";
            this.TxtPhysicalState.Text = "TxtPhysicalState";
            this.TxtPhysicalState.Top = 4.1875F;
            this.TxtPhysicalState.Width = 2.0625F;
            // 
            // TxtPhysicalZipCode
            // 
            this.TxtPhysicalZipCode.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtPhysicalZipCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhysicalZipCode.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtPhysicalZipCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhysicalZipCode.Border.RightColor = System.Drawing.Color.Black;
            this.TxtPhysicalZipCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhysicalZipCode.Border.TopColor = System.Drawing.Color.Black;
            this.TxtPhysicalZipCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtPhysicalZipCode.Height = 0.2F;
            this.TxtPhysicalZipCode.Left = 4.25F;
            this.TxtPhysicalZipCode.Name = "TxtPhysicalZipCode";
            this.TxtPhysicalZipCode.Style = "font-size: 8.25pt; ";
            this.TxtPhysicalZipCode.Text = "TxtPhysicalZipCode";
            this.TxtPhysicalZipCode.Top = 4.4375F;
            this.TxtPhysicalZipCode.Width = 2.0625F;
            // 
            // Label28
            // 
            this.Label28.Border.BottomColor = System.Drawing.Color.Black;
            this.Label28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label28.Border.LeftColor = System.Drawing.Color.Black;
            this.Label28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label28.Border.RightColor = System.Drawing.Color.Black;
            this.Label28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label28.Border.TopColor = System.Drawing.Color.Black;
            this.Label28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label28.Height = 0.2F;
            this.Label28.HyperLink = "";
            this.Label28.Left = 0.4375F;
            this.Label28.Name = "Label28";
            this.Label28.Style = "color: Black; font-weight: bold; ";
            this.Label28.Text = "Home Postal Address";
            this.Label28.Top = 3.0625F;
            this.Label28.Width = 1.875F;
            // 
            // Label29
            // 
            this.Label29.Border.BottomColor = System.Drawing.Color.Black;
            this.Label29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label29.Border.LeftColor = System.Drawing.Color.Black;
            this.Label29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label29.Border.RightColor = System.Drawing.Color.Black;
            this.Label29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label29.Border.TopColor = System.Drawing.Color.Black;
            this.Label29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label29.Height = 0.2F;
            this.Label29.HyperLink = "";
            this.Label29.Left = 3.5F;
            this.Label29.Name = "Label29";
            this.Label29.Style = "color: Black; font-weight: bold; ";
            this.Label29.Text = "Home Physical Address";
            this.Label29.Top = 3.0625F;
            this.Label29.Width = 1.875F;
            // 
            // Label42
            // 
            this.Label42.Border.BottomColor = System.Drawing.Color.Black;
            this.Label42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label42.Border.LeftColor = System.Drawing.Color.Black;
            this.Label42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label42.Border.RightColor = System.Drawing.Color.Black;
            this.Label42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label42.Border.TopColor = System.Drawing.Color.Black;
            this.Label42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label42.Height = 0.2F;
            this.Label42.HyperLink = "";
            this.Label42.Left = 4.5F;
            this.Label42.Name = "Label42";
            this.Label42.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label42.Text = "Customer No.:";
            this.Label42.Top = 1.3125F;
            this.Label42.Width = 1F;
            // 
            // TxtCustomerNo
            // 
            this.TxtCustomerNo.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCustomerNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerNo.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCustomerNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerNo.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCustomerNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerNo.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCustomerNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCustomerNo.Height = 0.2F;
            this.TxtCustomerNo.Left = 5.625F;
            this.TxtCustomerNo.Name = "TxtCustomerNo";
            this.TxtCustomerNo.Style = "color: Black; font-weight: bold; font-size: 8.25pt; ";
            this.TxtCustomerNo.Text = "TxtCustomerNo";
            this.TxtCustomerNo.Top = 1.3125F;
            this.TxtCustomerNo.Width = 1F;
            // 
            // Label43
            // 
            this.Label43.Border.BottomColor = System.Drawing.Color.Black;
            this.Label43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label43.Border.LeftColor = System.Drawing.Color.Black;
            this.Label43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label43.Border.RightColor = System.Drawing.Color.Black;
            this.Label43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label43.Border.TopColor = System.Drawing.Color.Black;
            this.Label43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label43.Height = 0.2F;
            this.Label43.HyperLink = "";
            this.Label43.Left = 2.125F;
            this.Label43.Name = "Label43";
            this.Label43.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label43.Text = "Effective Date";
            this.Label43.Top = 5.1875F;
            this.Label43.Width = 1F;
            // 
            // Label44
            // 
            this.Label44.Border.BottomColor = System.Drawing.Color.Black;
            this.Label44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label44.Border.LeftColor = System.Drawing.Color.Black;
            this.Label44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label44.Border.RightColor = System.Drawing.Color.Black;
            this.Label44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label44.Border.TopColor = System.Drawing.Color.Black;
            this.Label44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label44.Height = 0.2F;
            this.Label44.HyperLink = "";
            this.Label44.Left = 0.5625F;
            this.Label44.Name = "Label44";
            this.Label44.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.Label44.Text = "Policy No.";
            this.Label44.Top = 5.1875F;
            this.Label44.Width = 1.4375F;
            // 
            // Label45
            // 
            this.Label45.Border.BottomColor = System.Drawing.Color.Black;
            this.Label45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label45.Border.LeftColor = System.Drawing.Color.Black;
            this.Label45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label45.Border.RightColor = System.Drawing.Color.Black;
            this.Label45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label45.Border.TopColor = System.Drawing.Color.Black;
            this.Label45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label45.Height = 0.2F;
            this.Label45.HyperLink = "";
            this.Label45.Left = 3.125F;
            this.Label45.Name = "Label45";
            this.Label45.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label45.Text = "Expiration Date";
            this.Label45.Top = 5.1875F;
            this.Label45.Width = 1F;
            // 
            // Label47
            // 
            this.Label47.Border.BottomColor = System.Drawing.Color.Black;
            this.Label47.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label47.Border.LeftColor = System.Drawing.Color.Black;
            this.Label47.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label47.Border.RightColor = System.Drawing.Color.Black;
            this.Label47.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label47.Border.TopColor = System.Drawing.Color.Black;
            this.Label47.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label47.Height = 0.2F;
            this.Label47.HyperLink = "";
            this.Label47.Left = 5.1875F;
            this.Label47.Name = "Label47";
            this.Label47.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label47.Text = "Total Premium";
            this.Label47.Top = 5.1875F;
            this.Label47.Width = 0.9375F;
            // 
            // Label48
            // 
            this.Label48.Border.BottomColor = System.Drawing.Color.Black;
            this.Label48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label48.Border.LeftColor = System.Drawing.Color.Black;
            this.Label48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label48.Border.RightColor = System.Drawing.Color.Black;
            this.Label48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label48.Border.TopColor = System.Drawing.Color.Black;
            this.Label48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label48.Height = 0.2F;
            this.Label48.HyperLink = "";
            this.Label48.Left = 7.5F;
            this.Label48.Name = "Label48";
            this.Label48.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label48.Text = "Balance";
            this.Label48.Top = 5.1875F;
            this.Label48.Width = 0.75F;
            // 
            // Label49
            // 
            this.Label49.Border.BottomColor = System.Drawing.Color.Black;
            this.Label49.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label49.Border.LeftColor = System.Drawing.Color.Black;
            this.Label49.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label49.Border.RightColor = System.Drawing.Color.Black;
            this.Label49.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label49.Border.TopColor = System.Drawing.Color.Black;
            this.Label49.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label49.Height = 0.2F;
            this.Label49.HyperLink = "";
            this.Label49.Left = 6.3125F;
            this.Label49.Name = "Label49";
            this.Label49.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label49.Text = "Total Paid";
            this.Label49.Top = 5.1875F;
            this.Label49.Width = 0.875F;
            // 
            // Label50
            // 
            this.Label50.Border.BottomColor = System.Drawing.Color.Black;
            this.Label50.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label50.Border.LeftColor = System.Drawing.Color.Black;
            this.Label50.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label50.Border.RightColor = System.Drawing.Color.Black;
            this.Label50.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label50.Border.TopColor = System.Drawing.Color.Black;
            this.Label50.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label50.Height = 0.2F;
            this.Label50.HyperLink = "";
            this.Label50.Left = 4.375F;
            this.Label50.Name = "Label50";
            this.Label50.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label50.Text = "Status";
            this.Label50.Top = 5.1875F;
            this.Label50.Width = 0.5625F;
            // 
            // Line1
            // 
            this.Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.RightColor = System.Drawing.Color.Black;
            this.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.TopColor = System.Drawing.Color.Black;
            this.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Height = 0F;
            this.Line1.Left = 0.375F;
            this.Line1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 1.25F;
            this.Line1.Width = 7.9375F;
            this.Line1.X1 = 0.375F;
            this.Line1.X2 = 8.3125F;
            this.Line1.Y1 = 1.25F;
            this.Line1.Y2 = 1.25F;
            // 
            // Line3
            // 
            this.Line3.Border.BottomColor = System.Drawing.Color.Black;
            this.Line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.LeftColor = System.Drawing.Color.Black;
            this.Line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.RightColor = System.Drawing.Color.Black;
            this.Line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.TopColor = System.Drawing.Color.Black;
            this.Line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Height = 0F;
            this.Line3.Left = 0.4375F;
            this.Line3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 5.125F;
            this.Line3.Width = 7.875F;
            this.Line3.X1 = 0.4375F;
            this.Line3.X2 = 8.3125F;
            this.Line3.Y1 = 5.125F;
            this.Line3.Y2 = 5.125F;
            // 
            // Line4
            // 
            this.Line4.Border.BottomColor = System.Drawing.Color.Black;
            this.Line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.LeftColor = System.Drawing.Color.Black;
            this.Line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.RightColor = System.Drawing.Color.Black;
            this.Line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.TopColor = System.Drawing.Color.Black;
            this.Line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Height = 0F;
            this.Line4.Left = 0.4375F;
            this.Line4.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 4.8125F;
            this.Line4.Width = 7.875F;
            this.Line4.X1 = 0.4375F;
            this.Line4.X2 = 8.3125F;
            this.Line4.Y1 = 4.8125F;
            this.Line4.Y2 = 4.8125F;
            // 
            // Label51
            // 
            this.Label51.Border.BottomColor = System.Drawing.Color.Black;
            this.Label51.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label51.Border.LeftColor = System.Drawing.Color.Black;
            this.Label51.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label51.Border.RightColor = System.Drawing.Color.Black;
            this.Label51.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label51.Border.TopColor = System.Drawing.Color.Black;
            this.Label51.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label51.Height = 0.2F;
            this.Label51.HyperLink = "";
            this.Label51.Left = 0.4375F;
            this.Label51.Name = "Label51";
            this.Label51.Style = "color: Black; font-weight: bold; ";
            this.Label51.Text = "Active Policies";
            this.Label51.Top = 4.875F;
            this.Label51.Width = 1.875F;
            // 
            // ChbMarketingBlock
            // 
            this.ChbMarketingBlock.Border.BottomColor = System.Drawing.Color.Black;
            this.ChbMarketingBlock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ChbMarketingBlock.Border.LeftColor = System.Drawing.Color.Black;
            this.ChbMarketingBlock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ChbMarketingBlock.Border.RightColor = System.Drawing.Color.Black;
            this.ChbMarketingBlock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ChbMarketingBlock.Border.TopColor = System.Drawing.Color.Black;
            this.ChbMarketingBlock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ChbMarketingBlock.Height = 0.2F;
            this.ChbMarketingBlock.Left = 6.8125F;
            this.ChbMarketingBlock.Name = "ChbMarketingBlock";
            this.ChbMarketingBlock.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.ChbMarketingBlock.Text = "OptOut";
            this.ChbMarketingBlock.Top = 1.3125F;
            this.ChbMarketingBlock.Width = 1.4375F;
            // 
            // TxtEmplCity
            // 
            this.TxtEmplCity.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtEmplCity.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEmplCity.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtEmplCity.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEmplCity.Border.RightColor = System.Drawing.Color.Black;
            this.TxtEmplCity.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEmplCity.Border.TopColor = System.Drawing.Color.Black;
            this.TxtEmplCity.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtEmplCity.DataField = "EmplCity";
            this.TxtEmplCity.Height = 0.2F;
            this.TxtEmplCity.Left = 1.6875F;
            this.TxtEmplCity.Name = "TxtEmplCity";
            this.TxtEmplCity.Style = "font-size: 8.25pt; ";
            this.TxtEmplCity.Text = "TxtEmplCity";
            this.TxtEmplCity.Top = 2F;
            this.TxtEmplCity.Width = 2.3125F;
            // 
            // ChbNoticeOfCancellation
            // 
            this.ChbNoticeOfCancellation.Border.BottomColor = System.Drawing.Color.Black;
            this.ChbNoticeOfCancellation.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ChbNoticeOfCancellation.Border.LeftColor = System.Drawing.Color.Black;
            this.ChbNoticeOfCancellation.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ChbNoticeOfCancellation.Border.RightColor = System.Drawing.Color.Black;
            this.ChbNoticeOfCancellation.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ChbNoticeOfCancellation.Border.TopColor = System.Drawing.Color.Black;
            this.ChbNoticeOfCancellation.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ChbNoticeOfCancellation.Height = 0.2F;
            this.ChbNoticeOfCancellation.Left = 6.8125F;
            this.ChbNoticeOfCancellation.Name = "ChbNoticeOfCancellation";
            this.ChbNoticeOfCancellation.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.ChbNoticeOfCancellation.Text = "Notice of Cancellation";
            this.ChbNoticeOfCancellation.Top = 1.5625F;
            this.ChbNoticeOfCancellation.Width = 1.4375F;
            // 
            // Label75
            // 
            this.Label75.Border.BottomColor = System.Drawing.Color.Black;
            this.Label75.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label75.Border.LeftColor = System.Drawing.Color.Black;
            this.Label75.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label75.Border.RightColor = System.Drawing.Color.Black;
            this.Label75.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label75.Border.TopColor = System.Drawing.Color.Black;
            this.Label75.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label75.Height = 0.1875F;
            this.Label75.HyperLink = "";
            this.Label75.Left = 1.6875F;
            this.Label75.MultiLine = false;
            this.Label75.Name = "Label75";
            this.Label75.Style = "text-align: center; font-weight: bold; font-size: 11.25pt; font-family: Times New" +
                " Roman; ";
            this.Label75.Text = "PUERTO RICO MEDICAL DEFENSE INSURANCE COMPANY";
            this.Label75.Top = 0.125F;
            this.Label75.Width = 5.125F;
            // 
            // Label77
            // 
            this.Label77.Border.BottomColor = System.Drawing.Color.Black;
            this.Label77.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label77.Border.LeftColor = System.Drawing.Color.Black;
            this.Label77.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label77.Border.RightColor = System.Drawing.Color.Black;
            this.Label77.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label77.Border.TopColor = System.Drawing.Color.Black;
            this.Label77.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label77.Height = 0.1875F;
            this.Label77.HyperLink = "";
            this.Label77.Left = 1.6875F;
            this.Label77.MultiLine = false;
            this.Label77.Name = "Label77";
            this.Label77.Style = "text-align: center; font-weight: bold; font-size: 6pt; font-family: Times New Rom" +
                "an; ";
            this.Label77.Text = "";
            this.Label77.Top = 0.359375F;
            this.Label77.Width = 5.125F;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Height = 0F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TxtTotBalance,
            this.TxtTotTotalPrem,
            this.Label78,
            this.Line5,
            this.TxtCount,
            this.TxtTotTotalPaid});
            this.GroupFooter1.Height = 0.2708333F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // TxtTotBalance
            // 
            this.TxtTotBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtTotBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtTotBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotBalance.Border.RightColor = System.Drawing.Color.Black;
            this.TxtTotBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotBalance.Border.TopColor = System.Drawing.Color.Black;
            this.TxtTotBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotBalance.DataField = "Balance";
            this.TxtTotBalance.Height = 0.2F;
            this.TxtTotBalance.Left = 7.0625F;
            this.TxtTotBalance.MultiLine = false;
            this.TxtTotBalance.Name = "TxtTotBalance";
            this.TxtTotBalance.OutputFormat = resources.GetString("TxtTotBalance.OutputFormat");
            this.TxtTotBalance.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; vertical-align: middle; " +
                "";
            this.TxtTotBalance.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TxtTotBalance.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TxtTotBalance.Tag = "";
            this.TxtTotBalance.Text = "TxtTotBalance";
            this.TxtTotBalance.Top = 0.0625F;
            this.TxtTotBalance.Width = 1.125F;
            // 
            // TxtTotTotalPrem
            // 
            this.TxtTotTotalPrem.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtTotTotalPrem.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotTotalPrem.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtTotTotalPrem.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotTotalPrem.Border.RightColor = System.Drawing.Color.Black;
            this.TxtTotTotalPrem.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotTotalPrem.Border.TopColor = System.Drawing.Color.Black;
            this.TxtTotTotalPrem.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotTotalPrem.DataField = "TotalPremium";
            this.TxtTotTotalPrem.Height = 0.2F;
            this.TxtTotTotalPrem.Left = 5.0625F;
            this.TxtTotTotalPrem.MultiLine = false;
            this.TxtTotTotalPrem.Name = "TxtTotTotalPrem";
            this.TxtTotTotalPrem.OutputFormat = resources.GetString("TxtTotTotalPrem.OutputFormat");
            this.TxtTotTotalPrem.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; vertical-align: middle; " +
                "";
            this.TxtTotTotalPrem.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TxtTotTotalPrem.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TxtTotTotalPrem.Text = "TxtTotTotalPrem";
            this.TxtTotTotalPrem.Top = 0.0625F;
            this.TxtTotTotalPrem.Width = 1F;
            // 
            // Label78
            // 
            this.Label78.Border.BottomColor = System.Drawing.Color.Black;
            this.Label78.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label78.Border.LeftColor = System.Drawing.Color.Black;
            this.Label78.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label78.Border.RightColor = System.Drawing.Color.Black;
            this.Label78.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label78.Border.TopColor = System.Drawing.Color.Black;
            this.Label78.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label78.Height = 0.2F;
            this.Label78.HyperLink = "";
            this.Label78.Left = 0.5625F;
            this.Label78.Name = "Label78";
            this.Label78.Style = "color: Black; text-align: left; font-weight: bold; font-size: 10pt; ";
            this.Label78.Text = "Total:";
            this.Label78.Top = 0.0625F;
            this.Label78.Width = 0.4375F;
            // 
            // Line5
            // 
            this.Line5.Border.BottomColor = System.Drawing.Color.Black;
            this.Line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.LeftColor = System.Drawing.Color.Black;
            this.Line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.RightColor = System.Drawing.Color.Black;
            this.Line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.TopColor = System.Drawing.Color.Black;
            this.Line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Height = 0F;
            this.Line5.Left = 0.4375F;
            this.Line5.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Line5.LineWeight = 1F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 0.0625F;
            this.Line5.Width = 7.875F;
            this.Line5.X1 = 0.4375F;
            this.Line5.X2 = 8.3125F;
            this.Line5.Y1 = 0.0625F;
            this.Line5.Y2 = 0.0625F;
            // 
            // TxtCount
            // 
            this.TxtCount.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCount.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCount.Border.RightColor = System.Drawing.Color.Black;
            this.TxtCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCount.Border.TopColor = System.Drawing.Color.Black;
            this.TxtCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtCount.Height = 0.2F;
            this.TxtCount.Left = 1.25F;
            this.TxtCount.Name = "TxtCount";
            this.TxtCount.OutputFormat = resources.GetString("TxtCount.OutputFormat");
            this.TxtCount.Style = "font-weight: bold; font-size: 8.25pt; vertical-align: middle; ";
            this.TxtCount.Text = "TxtCount";
            this.TxtCount.Top = 0.0625F;
            this.TxtCount.Width = 0.625F;
            // 
            // TxtTotTotalPaid
            // 
            this.TxtTotTotalPaid.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtTotTotalPaid.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotTotalPaid.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtTotTotalPaid.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotTotalPaid.Border.RightColor = System.Drawing.Color.Black;
            this.TxtTotTotalPaid.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotTotalPaid.Border.TopColor = System.Drawing.Color.Black;
            this.TxtTotTotalPaid.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtTotTotalPaid.DataField = "TotalPaid";
            this.TxtTotTotalPaid.Height = 0.2F;
            this.TxtTotTotalPaid.Left = 6.125F;
            this.TxtTotTotalPaid.MultiLine = false;
            this.TxtTotTotalPaid.Name = "TxtTotTotalPaid";
            this.TxtTotTotalPaid.OutputFormat = resources.GetString("TxtTotTotalPaid.OutputFormat");
            this.TxtTotTotalPaid.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; vertical-align: middle; " +
                "";
            this.TxtTotTotalPaid.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TxtTotTotalPaid.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TxtTotTotalPaid.Text = "TextBox43";
            this.TxtTotTotalPaid.Top = 0.0625F;
            this.TxtTotTotalPaid.Width = 1F;
            // 
            // CustomerProfile
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.416667F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.GroupHeader1);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GroupFooter1);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.CustomerProfile_FetchData);
            this.DataInitialize += new System.EventHandler(this.CustomerProfile_DataInitialize);
            ((System.ComponentModel.ISupportInitialize)(this.TextBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPaid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOccupation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtHomePhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtJobPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSocialSecurity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMaritalStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtGender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBirthdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPostalAddress1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPostalAddress2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPostalCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPostalState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPostalZipcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCompanyName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPhysicalAddress1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPhysicalAddress2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPhysicalCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPhysicalState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPhysicalZipCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCustomerNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChbMarketingBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEmplCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChbNoticeOfCancellation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotTotalPrem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label78)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotTotalPaid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
