using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.XmlCooker;
using System.Data;
using Baldrich.DBRequest;
using EPolicy;
using EPolicy.TaskControl;
using EPolicy.LookupTables;
using EPolicy.Quotes;
using EPolicy.Customer;

namespace EPolicy2.Reports
{
	/// <summary>
	/// Summary description for rptQuoteAutoCover.
	/// </summary>
	public class rptQuoteAutoCover : DataDynamics.ActiveReports.ActiveReport3
	{


        private int _iRow = 0;
        private System.Collections.ArrayList _autoCover = null;
        private EPolicy.Quotes.AssignedDriver _primaryAssignedDriver = null;
        private EPolicy.Quotes.CoverBreakdown _breakdown = null;
        private EPolicy.TaskControl.QuoteAuto _policy;

        public rptQuoteAutoCover(System.Collections.ArrayList AutoCover, EPolicy.TaskControl.QuoteAuto taskControl)
        {
            _policy = taskControl;
            this._iRow = 0;
            this._autoCover = AutoCover;

            InitializeComponent();			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
			}
			base.Dispose( disposing );
		}

		#region Report Designer generated code

        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.Label Label8;
        private DataDynamics.ActiveReports.Label lblMake;
        private DataDynamics.ActiveReports.Label Label9;
        private DataDynamics.ActiveReports.Label lblModel;
        private DataDynamics.ActiveReports.Label Label10;
        private DataDynamics.ActiveReports.Label lblYear;
        private DataDynamics.ActiveReports.Label Label7;
        private DataDynamics.ActiveReports.TextBox txtVIN;
        private DataDynamics.ActiveReports.Label Label12;
        private DataDynamics.ActiveReports.TextBox txtVehicleAge;
        private DataDynamics.ActiveReports.Label Label13;
        private DataDynamics.ActiveReports.TextBox txtNewUsed;
        private DataDynamics.ActiveReports.Label Label14;
        private DataDynamics.ActiveReports.TextBox txtCost;
        private DataDynamics.ActiveReports.Label Label15;
        private DataDynamics.ActiveReports.TextBox txtActualValue;
        private DataDynamics.ActiveReports.Label Label18;
        private DataDynamics.ActiveReports.TextBox txtClass;
        private DataDynamics.ActiveReports.Label Label19;
        private DataDynamics.ActiveReports.TextBox txtTerritory;
        private DataDynamics.ActiveReports.Label Label20;
        private DataDynamics.ActiveReports.TextBox txtAlarmType;
        private DataDynamics.ActiveReports.Label Label21;
        private DataDynamics.ActiveReports.TextBox txtDepreciation1st;
        private DataDynamics.ActiveReports.Label Label23;
        private DataDynamics.ActiveReports.TextBox txtMedicalLimit;
        private DataDynamics.ActiveReports.Label Label27;
        private DataDynamics.ActiveReports.TextBox txtLeaseLoanGap;
        private DataDynamics.ActiveReports.Label Label30;
        private DataDynamics.ActiveReports.TextBox txtCollision;
        private DataDynamics.ActiveReports.Label Label31;
        private DataDynamics.ActiveReports.TextBox txtComprehensive;
        private DataDynamics.ActiveReports.Label Label32;
        private DataDynamics.ActiveReports.TextBox txtDiscountCollComp;
        private DataDynamics.ActiveReports.Label Label33;
        private DataDynamics.ActiveReports.TextBox txtBiLimit;
        private DataDynamics.ActiveReports.Label Label34;
        private DataDynamics.ActiveReports.TextBox txtPdLimit;
        private DataDynamics.ActiveReports.Label Label35;
        private DataDynamics.ActiveReports.TextBox txtCslLimit;
        private DataDynamics.ActiveReports.Label Label36;
        private DataDynamics.ActiveReports.TextBox txtDiscountBiPd;
        private DataDynamics.ActiveReports.Label Label37;
        private DataDynamics.ActiveReports.TextBox txtPremium;
        private DataDynamics.ActiveReports.Label Label39;
        private DataDynamics.ActiveReports.Label Label40;
        private DataDynamics.ActiveReports.TextBox txtName;
        private DataDynamics.ActiveReports.TextBox TextBox1;
        private DataDynamics.ActiveReports.TextBox txtBirthdate;
        private DataDynamics.ActiveReports.Label Label6;
        private DataDynamics.ActiveReports.TextBox txtMaritalStatus;
        private DataDynamics.ActiveReports.Label Label41;
        private DataDynamics.ActiveReports.TextBox txtGender;
        private DataDynamics.ActiveReports.Label Label42;
        private DataDynamics.ActiveReports.Label Label43;
        private DataDynamics.ActiveReports.Label Label44;
        private DataDynamics.ActiveReports.Label txt;
        private DataDynamics.ActiveReports.Label Label45;
        private DataDynamics.ActiveReports.Label Label46;
        private DataDynamics.ActiveReports.Label Label47;
        private DataDynamics.ActiveReports.Label Label48;
        private DataDynamics.ActiveReports.TextBox txtTotalComp;
        private DataDynamics.ActiveReports.TextBox txtTotalColl;
        private DataDynamics.ActiveReports.TextBox txtTotalBI;
        private DataDynamics.ActiveReports.TextBox txtTotalPD;
        private DataDynamics.ActiveReports.TextBox txtTotalCSL;
        private DataDynamics.ActiveReports.Label Label49;
        private DataDynamics.ActiveReports.Label Label50;
        private DataDynamics.ActiveReports.Label Label51;
        private DataDynamics.ActiveReports.Label Label53;
        private DataDynamics.ActiveReports.TextBox txtTotalLeaseLoanGap;
        private DataDynamics.ActiveReports.TextBox txtTowing;
        private DataDynamics.ActiveReports.TextBox txtAssistance;
        private DataDynamics.ActiveReports.TextBox txtPAR;
        private DataDynamics.ActiveReports.TextBox txtSeatbelt;
        private DataDynamics.ActiveReports.Label Label54;
        private DataDynamics.ActiveReports.Label Label56;
        private DataDynamics.ActiveReports.TextBox txtYear;
        private DataDynamics.ActiveReports.Label Label57;
        private DataDynamics.ActiveReports.TextBox txtAge;
        private DataDynamics.ActiveReports.Label Label58;
        private DataDynamics.ActiveReports.TextBox txtOnlyOperator;
        private DataDynamics.ActiveReports.Line Line1;
        private DataDynamics.ActiveReports.Label Label59;
        private DataDynamics.ActiveReports.TextBox txtPrincipalOperator;
        private DataDynamics.ActiveReports.Label Label60;
        private DataDynamics.ActiveReports.TextBox txtPhone;
        private DataDynamics.ActiveReports.Label Label61;
        private DataDynamics.ActiveReports.Label LblOwner;
        private DataDynamics.ActiveReports.Label Label62;
        private DataDynamics.ActiveReports.TextBox txtISOcode;
        private DataDynamics.ActiveReports.Label Label63;
        private DataDynamics.ActiveReports.Label LblVehicleCount;
        private DataDynamics.ActiveReports.Label Label64;
        private DataDynamics.ActiveReports.TextBox TxtVehicleRental;
        private DataDynamics.ActiveReports.Line Line2;

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptQuoteAutoCover));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.Label8 = new DataDynamics.ActiveReports.Label();
            this.lblMake = new DataDynamics.ActiveReports.Label();
            this.Label9 = new DataDynamics.ActiveReports.Label();
            this.lblModel = new DataDynamics.ActiveReports.Label();
            this.Label10 = new DataDynamics.ActiveReports.Label();
            this.lblYear = new DataDynamics.ActiveReports.Label();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.txtVIN = new DataDynamics.ActiveReports.TextBox();
            this.Label12 = new DataDynamics.ActiveReports.Label();
            this.txtVehicleAge = new DataDynamics.ActiveReports.TextBox();
            this.Label13 = new DataDynamics.ActiveReports.Label();
            this.txtNewUsed = new DataDynamics.ActiveReports.TextBox();
            this.Label14 = new DataDynamics.ActiveReports.Label();
            this.txtCost = new DataDynamics.ActiveReports.TextBox();
            this.Label15 = new DataDynamics.ActiveReports.Label();
            this.txtActualValue = new DataDynamics.ActiveReports.TextBox();
            this.Label18 = new DataDynamics.ActiveReports.Label();
            this.txtClass = new DataDynamics.ActiveReports.TextBox();
            this.Label19 = new DataDynamics.ActiveReports.Label();
            this.txtTerritory = new DataDynamics.ActiveReports.TextBox();
            this.Label20 = new DataDynamics.ActiveReports.Label();
            this.txtAlarmType = new DataDynamics.ActiveReports.TextBox();
            this.Label21 = new DataDynamics.ActiveReports.Label();
            this.txtDepreciation1st = new DataDynamics.ActiveReports.TextBox();
            this.Label23 = new DataDynamics.ActiveReports.Label();
            this.txtMedicalLimit = new DataDynamics.ActiveReports.TextBox();
            this.Label27 = new DataDynamics.ActiveReports.Label();
            this.txtLeaseLoanGap = new DataDynamics.ActiveReports.TextBox();
            this.Label30 = new DataDynamics.ActiveReports.Label();
            this.txtCollision = new DataDynamics.ActiveReports.TextBox();
            this.Label31 = new DataDynamics.ActiveReports.Label();
            this.txtComprehensive = new DataDynamics.ActiveReports.TextBox();
            this.Label32 = new DataDynamics.ActiveReports.Label();
            this.txtDiscountCollComp = new DataDynamics.ActiveReports.TextBox();
            this.Label33 = new DataDynamics.ActiveReports.Label();
            this.txtBiLimit = new DataDynamics.ActiveReports.TextBox();
            this.Label34 = new DataDynamics.ActiveReports.Label();
            this.txtPdLimit = new DataDynamics.ActiveReports.TextBox();
            this.Label35 = new DataDynamics.ActiveReports.Label();
            this.txtCslLimit = new DataDynamics.ActiveReports.TextBox();
            this.Label36 = new DataDynamics.ActiveReports.Label();
            this.txtDiscountBiPd = new DataDynamics.ActiveReports.TextBox();
            this.Label37 = new DataDynamics.ActiveReports.Label();
            this.txtPremium = new DataDynamics.ActiveReports.TextBox();
            this.Label39 = new DataDynamics.ActiveReports.Label();
            this.Label40 = new DataDynamics.ActiveReports.Label();
            this.txtName = new DataDynamics.ActiveReports.TextBox();
            this.TextBox1 = new DataDynamics.ActiveReports.TextBox();
            this.txtBirthdate = new DataDynamics.ActiveReports.TextBox();
            this.Label6 = new DataDynamics.ActiveReports.Label();
            this.txtMaritalStatus = new DataDynamics.ActiveReports.TextBox();
            this.Label41 = new DataDynamics.ActiveReports.Label();
            this.txtGender = new DataDynamics.ActiveReports.TextBox();
            this.Label42 = new DataDynamics.ActiveReports.Label();
            this.Label43 = new DataDynamics.ActiveReports.Label();
            this.Label44 = new DataDynamics.ActiveReports.Label();
            this.txt = new DataDynamics.ActiveReports.Label();
            this.Label45 = new DataDynamics.ActiveReports.Label();
            this.Label46 = new DataDynamics.ActiveReports.Label();
            this.Label47 = new DataDynamics.ActiveReports.Label();
            this.Label48 = new DataDynamics.ActiveReports.Label();
            this.txtTotalComp = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalColl = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalBI = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalPD = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalCSL = new DataDynamics.ActiveReports.TextBox();
            this.Label49 = new DataDynamics.ActiveReports.Label();
            this.Label50 = new DataDynamics.ActiveReports.Label();
            this.Label51 = new DataDynamics.ActiveReports.Label();
            this.Label53 = new DataDynamics.ActiveReports.Label();
            this.txtTotalLeaseLoanGap = new DataDynamics.ActiveReports.TextBox();
            this.txtTowing = new DataDynamics.ActiveReports.TextBox();
            this.txtAssistance = new DataDynamics.ActiveReports.TextBox();
            this.txtPAR = new DataDynamics.ActiveReports.TextBox();
            this.txtSeatbelt = new DataDynamics.ActiveReports.TextBox();
            this.Label54 = new DataDynamics.ActiveReports.Label();
            this.Label56 = new DataDynamics.ActiveReports.Label();
            this.txtYear = new DataDynamics.ActiveReports.TextBox();
            this.Label57 = new DataDynamics.ActiveReports.Label();
            this.txtAge = new DataDynamics.ActiveReports.TextBox();
            this.Label58 = new DataDynamics.ActiveReports.Label();
            this.txtOnlyOperator = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Label59 = new DataDynamics.ActiveReports.Label();
            this.txtPrincipalOperator = new DataDynamics.ActiveReports.TextBox();
            this.Label60 = new DataDynamics.ActiveReports.Label();
            this.txtPhone = new DataDynamics.ActiveReports.TextBox();
            this.Label61 = new DataDynamics.ActiveReports.Label();
            this.LblOwner = new DataDynamics.ActiveReports.Label();
            this.Label62 = new DataDynamics.ActiveReports.Label();
            this.txtISOcode = new DataDynamics.ActiveReports.TextBox();
            this.Label63 = new DataDynamics.ActiveReports.Label();
            this.LblVehicleCount = new DataDynamics.ActiveReports.Label();
            this.Label64 = new DataDynamics.ActiveReports.Label();
            this.TxtVehicleRental = new DataDynamics.ActiveReports.TextBox();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehicleAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewUsed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActualValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTerritory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlarmType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepreciation1st)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMedicalLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeaseLoanGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCollision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComprehensive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountCollComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBiLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPdLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCslLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountBiPd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPremium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirthdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaritalStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalColl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalBI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalLeaseLoanGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTowing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAssistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeatbelt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnlyOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrincipalOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblOwner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtISOcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblVehicleCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVehicleRental)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label8,
            this.lblMake,
            this.Label9,
            this.lblModel,
            this.Label10,
            this.lblYear,
            this.Label7,
            this.txtVIN,
            this.Label12,
            this.txtVehicleAge,
            this.Label13,
            this.txtNewUsed,
            this.Label14,
            this.txtCost,
            this.Label15,
            this.txtActualValue,
            this.Label18,
            this.txtClass,
            this.Label19,
            this.txtTerritory,
            this.Label20,
            this.txtAlarmType,
            this.Label21,
            this.txtDepreciation1st,
            this.Label23,
            this.txtMedicalLimit,
            this.Label27,
            this.txtLeaseLoanGap,
            this.Label30,
            this.txtCollision,
            this.Label31,
            this.txtComprehensive,
            this.Label32,
            this.txtDiscountCollComp,
            this.Label33,
            this.txtBiLimit,
            this.Label34,
            this.txtPdLimit,
            this.Label35,
            this.txtCslLimit,
            this.Label36,
            this.txtDiscountBiPd,
            this.Label37,
            this.txtPremium,
            this.Label39,
            this.Label40,
            this.txtName,
            this.TextBox1,
            this.txtBirthdate,
            this.Label6,
            this.txtMaritalStatus,
            this.Label41,
            this.txtGender,
            this.Label42,
            this.Label43,
            this.Label44,
            this.txt,
            this.Label45,
            this.Label46,
            this.Label47,
            this.Label48,
            this.txtTotalComp,
            this.txtTotalColl,
            this.txtTotalBI,
            this.txtTotalPD,
            this.txtTotalCSL,
            this.Label49,
            this.Label50,
            this.Label51,
            this.Label53,
            this.txtTotalLeaseLoanGap,
            this.txtTowing,
            this.txtAssistance,
            this.txtPAR,
            this.txtSeatbelt,
            this.Label54,
            this.Label56,
            this.txtYear,
            this.Label57,
            this.txtAge,
            this.Label58,
            this.txtOnlyOperator,
            this.Line1,
            this.Label59,
            this.txtPrincipalOperator,
            this.Label60,
            this.txtPhone,
            this.Label61,
            this.LblOwner,
            this.Label62,
            this.txtISOcode,
            this.Label63,
            this.LblVehicleCount,
            this.Label64,
            this.TxtVehicleRental,
            this.Line2});
            this.Detail.Height = 4.83125F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
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
            this.Label8.HyperLink = null;
            this.Label8.Left = 1.5F;
            this.Label8.Name = "Label8";
            this.Label8.Style = "color: Black; font-weight: bold; ";
            this.Label8.Text = "Make:";
            this.Label8.Top = 0.125F;
            this.Label8.Width = 0.4375F;
            // 
            // lblMake
            // 
            this.lblMake.Border.BottomColor = System.Drawing.Color.Black;
            this.lblMake.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblMake.Border.LeftColor = System.Drawing.Color.Black;
            this.lblMake.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblMake.Border.RightColor = System.Drawing.Color.Black;
            this.lblMake.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblMake.Border.TopColor = System.Drawing.Color.Black;
            this.lblMake.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblMake.Height = 0.2F;
            this.lblMake.HyperLink = null;
            this.lblMake.Left = 1.9375F;
            this.lblMake.Name = "lblMake";
            this.lblMake.Style = "";
            this.lblMake.Text = "lblMake";
            this.lblMake.Top = 0.125F;
            this.lblMake.Width = 1.25F;
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
            this.Label9.HyperLink = null;
            this.Label9.Left = 3.3125F;
            this.Label9.Name = "Label9";
            this.Label9.Style = "color: Black; font-weight: bold; ";
            this.Label9.Text = "Model:";
            this.Label9.Top = 0.125F;
            this.Label9.Width = 0.5F;
            // 
            // lblModel
            // 
            this.lblModel.Border.BottomColor = System.Drawing.Color.Black;
            this.lblModel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblModel.Border.LeftColor = System.Drawing.Color.Black;
            this.lblModel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblModel.Border.RightColor = System.Drawing.Color.Black;
            this.lblModel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblModel.Border.TopColor = System.Drawing.Color.Black;
            this.lblModel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblModel.Height = 0.2F;
            this.lblModel.HyperLink = null;
            this.lblModel.Left = 3.8125F;
            this.lblModel.Name = "lblModel";
            this.lblModel.Style = "";
            this.lblModel.Text = "lblModel";
            this.lblModel.Top = 0.125F;
            this.lblModel.Width = 1.25F;
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
            this.Label10.HyperLink = null;
            this.Label10.Left = 5.25F;
            this.Label10.Name = "Label10";
            this.Label10.Style = "color: Black; font-weight: bold; ";
            this.Label10.Text = "Year:";
            this.Label10.Top = 0.125F;
            this.Label10.Width = 0.4375F;
            // 
            // lblYear
            // 
            this.lblYear.Border.BottomColor = System.Drawing.Color.Black;
            this.lblYear.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblYear.Border.LeftColor = System.Drawing.Color.Black;
            this.lblYear.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblYear.Border.RightColor = System.Drawing.Color.Black;
            this.lblYear.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblYear.Border.TopColor = System.Drawing.Color.Black;
            this.lblYear.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblYear.Height = 0.2F;
            this.lblYear.HyperLink = null;
            this.lblYear.Left = 5.6875F;
            this.lblYear.Name = "lblYear";
            this.lblYear.Style = "";
            this.lblYear.Text = "lblYear";
            this.lblYear.Top = 0.125F;
            this.lblYear.Width = 1F;
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
            this.Label7.HyperLink = null;
            this.Label7.Left = 3F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label7.Text = "VIN:";
            this.Label7.Top = 0.6875F;
            this.Label7.Width = 0.75F;
            // 
            // txtVIN
            // 
            this.txtVIN.Border.BottomColor = System.Drawing.Color.Black;
            this.txtVIN.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVIN.Border.LeftColor = System.Drawing.Color.Black;
            this.txtVIN.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVIN.Border.RightColor = System.Drawing.Color.Black;
            this.txtVIN.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVIN.Border.TopColor = System.Drawing.Color.Black;
            this.txtVIN.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVIN.Height = 0.2F;
            this.txtVIN.Left = 3.75F;
            this.txtVIN.MultiLine = false;
            this.txtVIN.Name = "txtVIN";
            this.txtVIN.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtVIN.Text = "012345678901";
            this.txtVIN.Top = 0.6875F;
            this.txtVIN.Width = 0.875F;
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
            this.Label12.HyperLink = null;
            this.Label12.Left = 3F;
            this.Label12.Name = "Label12";
            this.Label12.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label12.Text = "Vehicle Age:";
            this.Label12.Top = 1.4375F;
            this.Label12.Width = 0.75F;
            // 
            // txtVehicleAge
            // 
            this.txtVehicleAge.Border.BottomColor = System.Drawing.Color.Black;
            this.txtVehicleAge.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVehicleAge.Border.LeftColor = System.Drawing.Color.Black;
            this.txtVehicleAge.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVehicleAge.Border.RightColor = System.Drawing.Color.Black;
            this.txtVehicleAge.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVehicleAge.Border.TopColor = System.Drawing.Color.Black;
            this.txtVehicleAge.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVehicleAge.Height = 0.2F;
            this.txtVehicleAge.Left = 3.75F;
            this.txtVehicleAge.MultiLine = false;
            this.txtVehicleAge.Name = "txtVehicleAge";
            this.txtVehicleAge.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtVehicleAge.Text = "txtVehicleAge";
            this.txtVehicleAge.Top = 1.4375F;
            this.txtVehicleAge.Width = 0.875F;
            // 
            // Label13
            // 
            this.Label13.Border.BottomColor = System.Drawing.Color.Black;
            this.Label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.LeftColor = System.Drawing.Color.Black;
            this.Label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.RightColor = System.Drawing.Color.Black;
            this.Label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.TopColor = System.Drawing.Color.Black;
            this.Label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Height = 0.2F;
            this.Label13.HyperLink = null;
            this.Label13.Left = 3F;
            this.Label13.Name = "Label13";
            this.Label13.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label13.Text = "New/Used:";
            this.Label13.Top = 0.9375F;
            this.Label13.Width = 0.75F;
            // 
            // txtNewUsed
            // 
            this.txtNewUsed.Border.BottomColor = System.Drawing.Color.Black;
            this.txtNewUsed.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNewUsed.Border.LeftColor = System.Drawing.Color.Black;
            this.txtNewUsed.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNewUsed.Border.RightColor = System.Drawing.Color.Black;
            this.txtNewUsed.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNewUsed.Border.TopColor = System.Drawing.Color.Black;
            this.txtNewUsed.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNewUsed.Height = 0.2F;
            this.txtNewUsed.Left = 3.75F;
            this.txtNewUsed.MultiLine = false;
            this.txtNewUsed.Name = "txtNewUsed";
            this.txtNewUsed.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtNewUsed.Text = "txtNewUsed";
            this.txtNewUsed.Top = 0.9375F;
            this.txtNewUsed.Width = 0.875F;
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
            this.Label14.HyperLink = null;
            this.Label14.Left = 3F;
            this.Label14.Name = "Label14";
            this.Label14.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label14.Text = "Cost:";
            this.Label14.Top = 1.6875F;
            this.Label14.Width = 0.75F;
            // 
            // txtCost
            // 
            this.txtCost.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCost.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCost.Border.RightColor = System.Drawing.Color.Black;
            this.txtCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCost.Border.TopColor = System.Drawing.Color.Black;
            this.txtCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCost.Height = 0.2F;
            this.txtCost.Left = 3.75F;
            this.txtCost.MultiLine = false;
            this.txtCost.Name = "txtCost";
            this.txtCost.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtCost.Text = "txtCost";
            this.txtCost.Top = 1.6875F;
            this.txtCost.Width = 0.875F;
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
            this.Label15.HyperLink = null;
            this.Label15.Left = 2.8125F;
            this.Label15.Name = "Label15";
            this.Label15.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label15.Text = "Actual Value:";
            this.Label15.Top = 1.931F;
            this.Label15.Width = 0.9375F;
            // 
            // txtActualValue
            // 
            this.txtActualValue.Border.BottomColor = System.Drawing.Color.Black;
            this.txtActualValue.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualValue.Border.LeftColor = System.Drawing.Color.Black;
            this.txtActualValue.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualValue.Border.RightColor = System.Drawing.Color.Black;
            this.txtActualValue.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualValue.Border.TopColor = System.Drawing.Color.Black;
            this.txtActualValue.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualValue.Height = 0.2F;
            this.txtActualValue.Left = 3.75F;
            this.txtActualValue.MultiLine = false;
            this.txtActualValue.Name = "txtActualValue";
            this.txtActualValue.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtActualValue.Text = "txtActualValue";
            this.txtActualValue.Top = 1.931F;
            this.txtActualValue.Width = 0.875F;
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
            this.Label18.HyperLink = null;
            this.Label18.Left = 3.0005F;
            this.Label18.Name = "Label18";
            this.Label18.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label18.Text = "Class:";
            this.Label18.Top = 2.174F;
            this.Label18.Width = 0.75F;
            // 
            // txtClass
            // 
            this.txtClass.Border.BottomColor = System.Drawing.Color.Black;
            this.txtClass.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtClass.Border.LeftColor = System.Drawing.Color.Black;
            this.txtClass.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtClass.Border.RightColor = System.Drawing.Color.Black;
            this.txtClass.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtClass.Border.TopColor = System.Drawing.Color.Black;
            this.txtClass.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtClass.Height = 0.2F;
            this.txtClass.Left = 3.75F;
            this.txtClass.MultiLine = false;
            this.txtClass.Name = "txtClass";
            this.txtClass.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtClass.Text = "txtClass";
            this.txtClass.Top = 2.174F;
            this.txtClass.Width = 0.875F;
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
            this.Label19.HyperLink = null;
            this.Label19.Left = 2.75F;
            this.Label19.Name = "Label19";
            this.Label19.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label19.Text = "Territory:";
            this.Label19.Top = 2.417F;
            this.Label19.Width = 1F;
            // 
            // txtTerritory
            // 
            this.txtTerritory.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTerritory.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTerritory.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTerritory.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTerritory.Border.RightColor = System.Drawing.Color.Black;
            this.txtTerritory.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTerritory.Border.TopColor = System.Drawing.Color.Black;
            this.txtTerritory.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTerritory.Height = 0.2F;
            this.txtTerritory.Left = 3.75F;
            this.txtTerritory.MultiLine = false;
            this.txtTerritory.Name = "txtTerritory";
            this.txtTerritory.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtTerritory.Text = "txtTerritory";
            this.txtTerritory.Top = 2.417F;
            this.txtTerritory.Width = 0.875F;
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
            this.Label20.HyperLink = null;
            this.Label20.Left = 2.75F;
            this.Label20.Name = "Label20";
            this.Label20.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label20.Text = "Alarm Type:";
            this.Label20.Top = 2.66F;
            this.Label20.Width = 1F;
            // 
            // txtAlarmType
            // 
            this.txtAlarmType.Border.BottomColor = System.Drawing.Color.Black;
            this.txtAlarmType.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAlarmType.Border.LeftColor = System.Drawing.Color.Black;
            this.txtAlarmType.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAlarmType.Border.RightColor = System.Drawing.Color.Black;
            this.txtAlarmType.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAlarmType.Border.TopColor = System.Drawing.Color.Black;
            this.txtAlarmType.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAlarmType.Height = 0.2F;
            this.txtAlarmType.Left = 3.75F;
            this.txtAlarmType.MultiLine = false;
            this.txtAlarmType.Name = "txtAlarmType";
            this.txtAlarmType.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtAlarmType.Text = "txtAlarmType";
            this.txtAlarmType.Top = 2.66F;
            this.txtAlarmType.Width = 0.875F;
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
            this.Label21.HyperLink = null;
            this.Label21.Left = 2.5625F;
            this.Label21.Name = "Label21";
            this.Label21.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label21.Text = "Depreciation:";
            this.Label21.Top = 2.903F;
            this.Label21.Width = 1.188F;
            // 
            // txtDepreciation1st
            // 
            this.txtDepreciation1st.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDepreciation1st.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDepreciation1st.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDepreciation1st.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDepreciation1st.Border.RightColor = System.Drawing.Color.Black;
            this.txtDepreciation1st.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDepreciation1st.Border.TopColor = System.Drawing.Color.Black;
            this.txtDepreciation1st.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDepreciation1st.Height = 0.2F;
            this.txtDepreciation1st.Left = 3.75F;
            this.txtDepreciation1st.MultiLine = false;
            this.txtDepreciation1st.Name = "txtDepreciation1st";
            this.txtDepreciation1st.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtDepreciation1st.Text = "txtDepreciation1st";
            this.txtDepreciation1st.Top = 2.903F;
            this.txtDepreciation1st.Width = 0.875F;
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
            this.Label23.HyperLink = null;
            this.Label23.Left = 5.125F;
            this.Label23.Name = "Label23";
            this.Label23.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label23.Text = "Medical Limit:";
            this.Label23.Top = 1.924F;
            this.Label23.Width = 1F;
            // 
            // txtMedicalLimit
            // 
            this.txtMedicalLimit.Border.BottomColor = System.Drawing.Color.Black;
            this.txtMedicalLimit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMedicalLimit.Border.LeftColor = System.Drawing.Color.Black;
            this.txtMedicalLimit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMedicalLimit.Border.RightColor = System.Drawing.Color.Black;
            this.txtMedicalLimit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMedicalLimit.Border.TopColor = System.Drawing.Color.Black;
            this.txtMedicalLimit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMedicalLimit.Height = 0.2F;
            this.txtMedicalLimit.Left = 6.125F;
            this.txtMedicalLimit.MultiLine = false;
            this.txtMedicalLimit.Name = "txtMedicalLimit";
            this.txtMedicalLimit.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtMedicalLimit.Text = "txtMedicalLimit";
            this.txtMedicalLimit.Top = 1.924F;
            this.txtMedicalLimit.Width = 0.875F;
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
            this.Label27.HyperLink = null;
            this.Label27.Left = 5.125F;
            this.Label27.Name = "Label27";
            this.Label27.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label27.Text = "Lease/Loan Gap:";
            this.Label27.Top = 2.167F;
            this.Label27.Width = 1F;
            // 
            // txtLeaseLoanGap
            // 
            this.txtLeaseLoanGap.Border.BottomColor = System.Drawing.Color.Black;
            this.txtLeaseLoanGap.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLeaseLoanGap.Border.LeftColor = System.Drawing.Color.Black;
            this.txtLeaseLoanGap.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLeaseLoanGap.Border.RightColor = System.Drawing.Color.Black;
            this.txtLeaseLoanGap.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLeaseLoanGap.Border.TopColor = System.Drawing.Color.Black;
            this.txtLeaseLoanGap.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLeaseLoanGap.Height = 0.2F;
            this.txtLeaseLoanGap.Left = 6.125F;
            this.txtLeaseLoanGap.MultiLine = false;
            this.txtLeaseLoanGap.Name = "txtLeaseLoanGap";
            this.txtLeaseLoanGap.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtLeaseLoanGap.Text = "txtLeaseLoanGap";
            this.txtLeaseLoanGap.Top = 2.167F;
            this.txtLeaseLoanGap.Width = 0.875F;
            // 
            // Label30
            // 
            this.Label30.Border.BottomColor = System.Drawing.Color.Black;
            this.Label30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label30.Border.LeftColor = System.Drawing.Color.Black;
            this.Label30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label30.Border.RightColor = System.Drawing.Color.Black;
            this.Label30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label30.Border.TopColor = System.Drawing.Color.Black;
            this.Label30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label30.Height = 0.2F;
            this.Label30.HyperLink = null;
            this.Label30.Left = 5.125F;
            this.Label30.Name = "Label30";
            this.Label30.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label30.Text = "Collision:";
            this.Label30.Top = 0.9375F;
            this.Label30.Width = 1F;
            // 
            // txtCollision
            // 
            this.txtCollision.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCollision.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCollision.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCollision.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCollision.Border.RightColor = System.Drawing.Color.Black;
            this.txtCollision.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCollision.Border.TopColor = System.Drawing.Color.Black;
            this.txtCollision.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCollision.Height = 0.2F;
            this.txtCollision.Left = 6.125F;
            this.txtCollision.MultiLine = false;
            this.txtCollision.Name = "txtCollision";
            this.txtCollision.Style = "font-weight: normal; font-size: 8.25pt; vertical-align: top; ";
            this.txtCollision.Text = "txtCollision";
            this.txtCollision.Top = 0.9375F;
            this.txtCollision.Width = 0.875F;
            // 
            // Label31
            // 
            this.Label31.Border.BottomColor = System.Drawing.Color.Black;
            this.Label31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label31.Border.LeftColor = System.Drawing.Color.Black;
            this.Label31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label31.Border.RightColor = System.Drawing.Color.Black;
            this.Label31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label31.Border.TopColor = System.Drawing.Color.Black;
            this.Label31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label31.Height = 0.2F;
            this.Label31.HyperLink = null;
            this.Label31.Left = 5.125F;
            this.Label31.Name = "Label31";
            this.Label31.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label31.Text = "Comprehensive:";
            this.Label31.Top = 0.6875F;
            this.Label31.Width = 1F;
            // 
            // txtComprehensive
            // 
            this.txtComprehensive.Border.BottomColor = System.Drawing.Color.Black;
            this.txtComprehensive.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtComprehensive.Border.LeftColor = System.Drawing.Color.Black;
            this.txtComprehensive.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtComprehensive.Border.RightColor = System.Drawing.Color.Black;
            this.txtComprehensive.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtComprehensive.Border.TopColor = System.Drawing.Color.Black;
            this.txtComprehensive.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtComprehensive.Height = 0.2F;
            this.txtComprehensive.Left = 6.125F;
            this.txtComprehensive.MultiLine = false;
            this.txtComprehensive.Name = "txtComprehensive";
            this.txtComprehensive.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtComprehensive.Text = "txtComprehensive";
            this.txtComprehensive.Top = 0.6875F;
            this.txtComprehensive.Width = 0.875F;
            // 
            // Label32
            // 
            this.Label32.Border.BottomColor = System.Drawing.Color.Black;
            this.Label32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label32.Border.LeftColor = System.Drawing.Color.Black;
            this.Label32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label32.Border.RightColor = System.Drawing.Color.Black;
            this.Label32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label32.Border.TopColor = System.Drawing.Color.Black;
            this.Label32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label32.Height = 0.2150001F;
            this.Label32.HyperLink = null;
            this.Label32.Left = 4.875F;
            this.Label32.Name = "Label32";
            this.Label32.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label32.Text = "Discount Coll\\Comp:";
            this.Label32.Top = 2.404783F;
            this.Label32.Width = 1.25F;
            // 
            // txtDiscountCollComp
            // 
            this.txtDiscountCollComp.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDiscountCollComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDiscountCollComp.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDiscountCollComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDiscountCollComp.Border.RightColor = System.Drawing.Color.Black;
            this.txtDiscountCollComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDiscountCollComp.Border.TopColor = System.Drawing.Color.Black;
            this.txtDiscountCollComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDiscountCollComp.Height = 0.2F;
            this.txtDiscountCollComp.Left = 6.125F;
            this.txtDiscountCollComp.MultiLine = false;
            this.txtDiscountCollComp.Name = "txtDiscountCollComp";
            this.txtDiscountCollComp.Style = "font-weight: normal; font-size: 8.25pt; vertical-align: top; ";
            this.txtDiscountCollComp.Text = "txtDiscountCollComp";
            this.txtDiscountCollComp.Top = 2.404783F;
            this.txtDiscountCollComp.Width = 0.875F;
            // 
            // Label33
            // 
            this.Label33.Border.BottomColor = System.Drawing.Color.Black;
            this.Label33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label33.Border.LeftColor = System.Drawing.Color.Black;
            this.Label33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label33.Border.RightColor = System.Drawing.Color.Black;
            this.Label33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label33.Border.TopColor = System.Drawing.Color.Black;
            this.Label33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label33.Height = 0.2F;
            this.Label33.HyperLink = null;
            this.Label33.Left = 5.125F;
            this.Label33.Name = "Label33";
            this.Label33.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label33.Text = "BI Limit:";
            this.Label33.Top = 1.1875F;
            this.Label33.Width = 1F;
            // 
            // txtBiLimit
            // 
            this.txtBiLimit.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBiLimit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBiLimit.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBiLimit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBiLimit.Border.RightColor = System.Drawing.Color.Black;
            this.txtBiLimit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBiLimit.Border.TopColor = System.Drawing.Color.Black;
            this.txtBiLimit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBiLimit.Height = 0.2F;
            this.txtBiLimit.Left = 6.125F;
            this.txtBiLimit.MultiLine = false;
            this.txtBiLimit.Name = "txtBiLimit";
            this.txtBiLimit.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtBiLimit.Text = "txtBiLimit";
            this.txtBiLimit.Top = 1.1875F;
            this.txtBiLimit.Width = 0.875F;
            // 
            // Label34
            // 
            this.Label34.Border.BottomColor = System.Drawing.Color.Black;
            this.Label34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label34.Border.LeftColor = System.Drawing.Color.Black;
            this.Label34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label34.Border.RightColor = System.Drawing.Color.Black;
            this.Label34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label34.Border.TopColor = System.Drawing.Color.Black;
            this.Label34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label34.Height = 0.2F;
            this.Label34.HyperLink = null;
            this.Label34.Left = 5.125F;
            this.Label34.Name = "Label34";
            this.Label34.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label34.Text = "PD Limit:";
            this.Label34.Top = 1.4375F;
            this.Label34.Width = 1F;
            // 
            // txtPdLimit
            // 
            this.txtPdLimit.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPdLimit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPdLimit.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPdLimit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPdLimit.Border.RightColor = System.Drawing.Color.Black;
            this.txtPdLimit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPdLimit.Border.TopColor = System.Drawing.Color.Black;
            this.txtPdLimit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPdLimit.Height = 0.2F;
            this.txtPdLimit.Left = 6.125F;
            this.txtPdLimit.MultiLine = false;
            this.txtPdLimit.Name = "txtPdLimit";
            this.txtPdLimit.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtPdLimit.Text = "txtPdLimit";
            this.txtPdLimit.Top = 1.4375F;
            this.txtPdLimit.Width = 0.875F;
            // 
            // Label35
            // 
            this.Label35.Border.BottomColor = System.Drawing.Color.Black;
            this.Label35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label35.Border.LeftColor = System.Drawing.Color.Black;
            this.Label35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label35.Border.RightColor = System.Drawing.Color.Black;
            this.Label35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label35.Border.TopColor = System.Drawing.Color.Black;
            this.Label35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label35.Height = 0.2F;
            this.Label35.HyperLink = null;
            this.Label35.Left = 5.125F;
            this.Label35.Name = "Label35";
            this.Label35.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label35.Text = "CSL Limit:";
            this.Label35.Top = 1.681F;
            this.Label35.Width = 1F;
            // 
            // txtCslLimit
            // 
            this.txtCslLimit.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCslLimit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCslLimit.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCslLimit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCslLimit.Border.RightColor = System.Drawing.Color.Black;
            this.txtCslLimit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCslLimit.Border.TopColor = System.Drawing.Color.Black;
            this.txtCslLimit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCslLimit.Height = 0.2F;
            this.txtCslLimit.Left = 6.125F;
            this.txtCslLimit.MultiLine = false;
            this.txtCslLimit.Name = "txtCslLimit";
            this.txtCslLimit.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtCslLimit.Text = "txtCslLimit";
            this.txtCslLimit.Top = 1.681F;
            this.txtCslLimit.Width = 0.875F;
            // 
            // Label36
            // 
            this.Label36.Border.BottomColor = System.Drawing.Color.Black;
            this.Label36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label36.Border.LeftColor = System.Drawing.Color.Black;
            this.Label36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label36.Border.RightColor = System.Drawing.Color.Black;
            this.Label36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label36.Border.TopColor = System.Drawing.Color.Black;
            this.Label36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label36.Height = 0.2F;
            this.Label36.HyperLink = null;
            this.Label36.Left = 5.125F;
            this.Label36.Name = "Label36";
            this.Label36.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label36.Text = "Discount BI\\PD:";
            this.Label36.Top = 2.6625F;
            this.Label36.Width = 1F;
            // 
            // txtDiscountBiPd
            // 
            this.txtDiscountBiPd.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDiscountBiPd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDiscountBiPd.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDiscountBiPd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDiscountBiPd.Border.RightColor = System.Drawing.Color.Black;
            this.txtDiscountBiPd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDiscountBiPd.Border.TopColor = System.Drawing.Color.Black;
            this.txtDiscountBiPd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDiscountBiPd.Height = 0.2F;
            this.txtDiscountBiPd.Left = 6.125501F;
            this.txtDiscountBiPd.MultiLine = false;
            this.txtDiscountBiPd.Name = "txtDiscountBiPd";
            this.txtDiscountBiPd.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtDiscountBiPd.Text = "txtDiscountBiPd";
            this.txtDiscountBiPd.Top = 2.6625F;
            this.txtDiscountBiPd.Width = 0.875F;
            // 
            // Label37
            // 
            this.Label37.Border.BottomColor = System.Drawing.Color.Black;
            this.Label37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label37.Border.LeftColor = System.Drawing.Color.Black;
            this.Label37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label37.Border.RightColor = System.Drawing.Color.Black;
            this.Label37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label37.Border.TopColor = System.Drawing.Color.Black;
            this.Label37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label37.Height = 0.2F;
            this.Label37.HyperLink = null;
            this.Label37.Left = 5.1875F;
            this.Label37.Name = "Label37";
            this.Label37.Style = "text-align: right; font-weight: bold; font-size: 10pt; ";
            this.Label37.Text = "Premium:";
            this.Label37.Top = 3.3125F;
            this.Label37.Width = 0.875F;
            // 
            // txtPremium
            // 
            this.txtPremium.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPremium.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPremium.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPremium.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPremium.Border.RightColor = System.Drawing.Color.Black;
            this.txtPremium.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPremium.Border.TopColor = System.Drawing.Color.Black;
            this.txtPremium.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPremium.Height = 0.2F;
            this.txtPremium.Left = 6.0625F;
            this.txtPremium.MultiLine = false;
            this.txtPremium.Name = "txtPremium";
            this.txtPremium.Style = "font-weight: bold; font-size: 10pt; ";
            this.txtPremium.Text = "$9,999.00";
            this.txtPremium.Top = 3.3125F;
            this.txtPremium.Width = 0.875F;
            // 
            // Label39
            // 
            this.Label39.Border.BottomColor = System.Drawing.Color.Black;
            this.Label39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label39.Border.LeftColor = System.Drawing.Color.Black;
            this.Label39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label39.Border.RightColor = System.Drawing.Color.Black;
            this.Label39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label39.Border.TopColor = System.Drawing.Color.Black;
            this.Label39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label39.Height = 0.2F;
            this.Label39.HyperLink = null;
            this.Label39.Left = 0.0625F;
            this.Label39.Name = "Label39";
            this.Label39.Style = "color: Black; font-weight: bold; ";
            this.Label39.Text = "Driver Information";
            this.Label39.Top = 0.6875F;
            this.Label39.Width = 1.9375F;
            // 
            // Label40
            // 
            this.Label40.Border.BottomColor = System.Drawing.Color.Black;
            this.Label40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label40.Border.LeftColor = System.Drawing.Color.Black;
            this.Label40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label40.Border.RightColor = System.Drawing.Color.Black;
            this.Label40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label40.Border.TopColor = System.Drawing.Color.Black;
            this.Label40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label40.Height = 0.2F;
            this.Label40.HyperLink = null;
            this.Label40.Left = 0.1875F;
            this.Label40.Name = "Label40";
            this.Label40.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label40.Text = "Name:";
            this.Label40.Top = 0.9416667F;
            this.Label40.Width = 0.875F;
            // 
            // txtName
            // 
            this.txtName.Border.BottomColor = System.Drawing.Color.Black;
            this.txtName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName.Border.LeftColor = System.Drawing.Color.Black;
            this.txtName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName.Border.RightColor = System.Drawing.Color.Black;
            this.txtName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName.Border.TopColor = System.Drawing.Color.Black;
            this.txtName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName.Height = 0.2F;
            this.txtName.Left = 1.0625F;
            this.txtName.MultiLine = false;
            this.txtName.Name = "txtName";
            this.txtName.Style = "font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.txtName.Text = "txtName";
            this.txtName.Top = 0.9375F;
            this.txtName.Width = 1.625F;
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
            this.TextBox1.Left = 0.1875F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.TextBox1.Text = "Birthdate:";
            this.TextBox1.Top = 1.191667F;
            this.TextBox1.Width = 0.875F;
            // 
            // txtBirthdate
            // 
            this.txtBirthdate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBirthdate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBirthdate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBirthdate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBirthdate.Border.RightColor = System.Drawing.Color.Black;
            this.txtBirthdate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBirthdate.Border.TopColor = System.Drawing.Color.Black;
            this.txtBirthdate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBirthdate.Height = 0.2F;
            this.txtBirthdate.Left = 1.0625F;
            this.txtBirthdate.Name = "txtBirthdate";
            this.txtBirthdate.Style = "font-size: 8.25pt; ";
            this.txtBirthdate.Text = "txtBirthdate";
            this.txtBirthdate.Top = 1.1875F;
            this.txtBirthdate.Width = 1F;
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
            this.Label6.HyperLink = null;
            this.Label6.Left = 0.1875F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label6.Text = "Marital Status:";
            this.Label6.Top = 1.691667F;
            this.Label6.Width = 0.875F;
            // 
            // txtMaritalStatus
            // 
            this.txtMaritalStatus.Border.BottomColor = System.Drawing.Color.Black;
            this.txtMaritalStatus.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMaritalStatus.Border.LeftColor = System.Drawing.Color.Black;
            this.txtMaritalStatus.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMaritalStatus.Border.RightColor = System.Drawing.Color.Black;
            this.txtMaritalStatus.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMaritalStatus.Border.TopColor = System.Drawing.Color.Black;
            this.txtMaritalStatus.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMaritalStatus.Height = 0.2F;
            this.txtMaritalStatus.Left = 1.0625F;
            this.txtMaritalStatus.Name = "txtMaritalStatus";
            this.txtMaritalStatus.Style = "font-size: 8.25pt; ";
            this.txtMaritalStatus.Text = "txtMaritalStatus";
            this.txtMaritalStatus.Top = 1.6875F;
            this.txtMaritalStatus.Width = 1F;
            // 
            // Label41
            // 
            this.Label41.Border.BottomColor = System.Drawing.Color.Black;
            this.Label41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label41.Border.LeftColor = System.Drawing.Color.Black;
            this.Label41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label41.Border.RightColor = System.Drawing.Color.Black;
            this.Label41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label41.Border.TopColor = System.Drawing.Color.Black;
            this.Label41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label41.Height = 0.2F;
            this.Label41.HyperLink = null;
            this.Label41.Left = 0.1875F;
            this.Label41.Name = "Label41";
            this.Label41.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label41.Text = "Gender:";
            this.Label41.Top = 1.941667F;
            this.Label41.Width = 0.875F;
            // 
            // txtGender
            // 
            this.txtGender.Border.BottomColor = System.Drawing.Color.Black;
            this.txtGender.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGender.Border.LeftColor = System.Drawing.Color.Black;
            this.txtGender.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGender.Border.RightColor = System.Drawing.Color.Black;
            this.txtGender.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGender.Border.TopColor = System.Drawing.Color.Black;
            this.txtGender.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGender.Height = 0.2F;
            this.txtGender.Left = 1.0625F;
            this.txtGender.Name = "txtGender";
            this.txtGender.Style = "font-size: 8.25pt; ";
            this.txtGender.Text = "txtGender";
            this.txtGender.Top = 1.9375F;
            this.txtGender.Width = 1F;
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
            this.Label42.HyperLink = null;
            this.Label42.Left = 3F;
            this.Label42.Name = "Label42";
            this.Label42.Style = "color: Black; font-weight: bold; ";
            this.Label42.Text = "Auto Information";
            this.Label42.Top = 0.4375001F;
            this.Label42.Width = 1.25F;
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
            this.Label43.HyperLink = null;
            this.Label43.Left = 5.1875F;
            this.Label43.Name = "Label43";
            this.Label43.Style = "color: Black; font-weight: bold; ";
            this.Label43.Text = "Limits/Deductibles";
            this.Label43.Top = 0.4375001F;
            this.Label43.Width = 1.4375F;
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
            this.Label44.HyperLink = null;
            this.Label44.Left = 0.0625F;
            this.Label44.Name = "Label44";
            this.Label44.Style = "color: Black; font-weight: bold; ";
            this.Label44.Text = "Premium Breakdown";
            this.Label44.Top = 3.2805F;
            this.Label44.Width = 1.4375F;
            // 
            // txt
            // 
            this.txt.Border.BottomColor = System.Drawing.Color.Black;
            this.txt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt.Border.LeftColor = System.Drawing.Color.Black;
            this.txt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt.Border.RightColor = System.Drawing.Color.Black;
            this.txt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt.Border.TopColor = System.Drawing.Color.Black;
            this.txt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt.Height = 0.2F;
            this.txt.HyperLink = null;
            this.txt.Left = 0.063F;
            this.txt.Name = "txt";
            this.txt.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.txt.Text = "Comprehensive:";
            this.txt.Top = 3.5345F;
            this.txt.Width = 0.9375F;
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
            this.Label45.HyperLink = null;
            this.Label45.Left = 0.063F;
            this.Label45.Name = "Label45";
            this.Label45.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label45.Text = "Collision:";
            this.Label45.Top = 3.7775F;
            this.Label45.Width = 0.9375F;
            // 
            // Label46
            // 
            this.Label46.Border.BottomColor = System.Drawing.Color.Black;
            this.Label46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label46.Border.LeftColor = System.Drawing.Color.Black;
            this.Label46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label46.Border.RightColor = System.Drawing.Color.Black;
            this.Label46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label46.Border.TopColor = System.Drawing.Color.Black;
            this.Label46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label46.Height = 0.2F;
            this.Label46.HyperLink = null;
            this.Label46.Left = 0.063F;
            this.Label46.Name = "Label46";
            this.Label46.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label46.Text = "BI:";
            this.Label46.Top = 4.020501F;
            this.Label46.Width = 0.9375F;
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
            this.Label47.HyperLink = null;
            this.Label47.Left = 0.063F;
            this.Label47.Name = "Label47";
            this.Label47.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label47.Text = "CSL:";
            this.Label47.Top = 4.5065F;
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
            this.Label48.HyperLink = null;
            this.Label48.Left = 0.063F;
            this.Label48.Name = "Label48";
            this.Label48.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label48.Text = "PD:";
            this.Label48.Top = 4.263499F;
            this.Label48.Width = 0.9375F;
            // 
            // txtTotalComp
            // 
            this.txtTotalComp.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalComp.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalComp.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalComp.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalComp.Height = 0.2F;
            this.txtTotalComp.Left = 1F;
            this.txtTotalComp.MultiLine = false;
            this.txtTotalComp.Name = "txtTotalComp";
            this.txtTotalComp.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; ";
            this.txtTotalComp.Text = "txtTotalComp";
            this.txtTotalComp.Top = 3.5345F;
            this.txtTotalComp.Width = 0.875F;
            // 
            // txtTotalColl
            // 
            this.txtTotalColl.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalColl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalColl.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalColl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalColl.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalColl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalColl.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalColl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalColl.Height = 0.2F;
            this.txtTotalColl.Left = 1F;
            this.txtTotalColl.MultiLine = false;
            this.txtTotalColl.Name = "txtTotalColl";
            this.txtTotalColl.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; ";
            this.txtTotalColl.Text = "txtTotalColl";
            this.txtTotalColl.Top = 3.7775F;
            this.txtTotalColl.Width = 0.875F;
            // 
            // txtTotalBI
            // 
            this.txtTotalBI.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalBI.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalBI.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalBI.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalBI.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalBI.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalBI.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalBI.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalBI.Height = 0.2F;
            this.txtTotalBI.Left = 1F;
            this.txtTotalBI.MultiLine = false;
            this.txtTotalBI.Name = "txtTotalBI";
            this.txtTotalBI.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; ";
            this.txtTotalBI.Text = "txtTotalBI";
            this.txtTotalBI.Top = 4.020501F;
            this.txtTotalBI.Width = 0.875F;
            // 
            // txtTotalPD
            // 
            this.txtTotalPD.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalPD.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalPD.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalPD.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalPD.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalPD.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalPD.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalPD.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalPD.Height = 0.2F;
            this.txtTotalPD.Left = 1F;
            this.txtTotalPD.MultiLine = false;
            this.txtTotalPD.Name = "txtTotalPD";
            this.txtTotalPD.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; ";
            this.txtTotalPD.Text = "txtTotalPD";
            this.txtTotalPD.Top = 4.263499F;
            this.txtTotalPD.Width = 0.875F;
            // 
            // txtTotalCSL
            // 
            this.txtTotalCSL.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalCSL.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalCSL.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalCSL.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalCSL.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalCSL.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalCSL.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalCSL.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalCSL.Height = 0.2F;
            this.txtTotalCSL.Left = 1F;
            this.txtTotalCSL.MultiLine = false;
            this.txtTotalCSL.Name = "txtTotalCSL";
            this.txtTotalCSL.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; ";
            this.txtTotalCSL.Text = "txtTotalCSL";
            this.txtTotalCSL.Top = 4.5065F;
            this.txtTotalCSL.Width = 0.875F;
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
            this.Label49.HyperLink = null;
            this.Label49.Left = 1.875F;
            this.Label49.Name = "Label49";
            this.Label49.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label49.Text = "Lease/Loan Gap:";
            this.Label49.Top = 3.5345F;
            this.Label49.Width = 1F;
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
            this.Label50.HyperLink = null;
            this.Label50.Left = 1.9375F;
            this.Label50.Name = "Label50";
            this.Label50.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label50.Text = "Towing:";
            this.Label50.Top = 3.7775F;
            this.Label50.Width = 0.9375F;
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
            this.Label51.HyperLink = null;
            this.Label51.Left = 1.9375F;
            this.Label51.Name = "Label51";
            this.Label51.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label51.Text = "Assistance:";
            this.Label51.Top = 4.020501F;
            this.Label51.Width = 0.9375F;
            // 
            // Label53
            // 
            this.Label53.Border.BottomColor = System.Drawing.Color.Black;
            this.Label53.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label53.Border.LeftColor = System.Drawing.Color.Black;
            this.Label53.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label53.Border.RightColor = System.Drawing.Color.Black;
            this.Label53.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label53.Border.TopColor = System.Drawing.Color.Black;
            this.Label53.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label53.Height = 0.2F;
            this.Label53.HyperLink = null;
            this.Label53.Left = 1.9375F;
            this.Label53.Name = "Label53";
            this.Label53.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label53.Text = "PAR:";
            this.Label53.Top = 4.263499F;
            this.Label53.Width = 0.9375F;
            // 
            // txtTotalLeaseLoanGap
            // 
            this.txtTotalLeaseLoanGap.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalLeaseLoanGap.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalLeaseLoanGap.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalLeaseLoanGap.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalLeaseLoanGap.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalLeaseLoanGap.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalLeaseLoanGap.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalLeaseLoanGap.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalLeaseLoanGap.Height = 0.2F;
            this.txtTotalLeaseLoanGap.Left = 2.8745F;
            this.txtTotalLeaseLoanGap.MultiLine = false;
            this.txtTotalLeaseLoanGap.Name = "txtTotalLeaseLoanGap";
            this.txtTotalLeaseLoanGap.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; ";
            this.txtTotalLeaseLoanGap.Text = "txtTotalLeaseLoanGap";
            this.txtTotalLeaseLoanGap.Top = 3.5345F;
            this.txtTotalLeaseLoanGap.Width = 0.875F;
            // 
            // txtTowing
            // 
            this.txtTowing.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTowing.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTowing.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTowing.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTowing.Border.RightColor = System.Drawing.Color.Black;
            this.txtTowing.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTowing.Border.TopColor = System.Drawing.Color.Black;
            this.txtTowing.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTowing.Height = 0.2F;
            this.txtTowing.Left = 2.8745F;
            this.txtTowing.MultiLine = false;
            this.txtTowing.Name = "txtTowing";
            this.txtTowing.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; ";
            this.txtTowing.Text = "txtTowing";
            this.txtTowing.Top = 3.7775F;
            this.txtTowing.Width = 0.875F;
            // 
            // txtAssistance
            // 
            this.txtAssistance.Border.BottomColor = System.Drawing.Color.Black;
            this.txtAssistance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAssistance.Border.LeftColor = System.Drawing.Color.Black;
            this.txtAssistance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAssistance.Border.RightColor = System.Drawing.Color.Black;
            this.txtAssistance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAssistance.Border.TopColor = System.Drawing.Color.Black;
            this.txtAssistance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAssistance.Height = 0.2F;
            this.txtAssistance.Left = 2.8745F;
            this.txtAssistance.MultiLine = false;
            this.txtAssistance.Name = "txtAssistance";
            this.txtAssistance.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; ";
            this.txtAssistance.Text = "txtAssistance";
            this.txtAssistance.Top = 4.020501F;
            this.txtAssistance.Width = 0.875F;
            // 
            // txtPAR
            // 
            this.txtPAR.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPAR.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPAR.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPAR.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPAR.Border.RightColor = System.Drawing.Color.Black;
            this.txtPAR.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPAR.Border.TopColor = System.Drawing.Color.Black;
            this.txtPAR.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPAR.Height = 0.2F;
            this.txtPAR.Left = 2.8745F;
            this.txtPAR.MultiLine = false;
            this.txtPAR.Name = "txtPAR";
            this.txtPAR.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; ";
            this.txtPAR.Text = "txtPAR";
            this.txtPAR.Top = 4.263499F;
            this.txtPAR.Width = 0.875F;
            // 
            // txtSeatbelt
            // 
            this.txtSeatbelt.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSeatbelt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSeatbelt.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSeatbelt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSeatbelt.Border.RightColor = System.Drawing.Color.Black;
            this.txtSeatbelt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSeatbelt.Border.TopColor = System.Drawing.Color.Black;
            this.txtSeatbelt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSeatbelt.Height = 0.2F;
            this.txtSeatbelt.Left = 2.8745F;
            this.txtSeatbelt.MultiLine = false;
            this.txtSeatbelt.Name = "txtSeatbelt";
            this.txtSeatbelt.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; ";
            this.txtSeatbelt.Text = "txtSeatbelt";
            this.txtSeatbelt.Top = 4.5065F;
            this.txtSeatbelt.Width = 0.875F;
            // 
            // Label54
            // 
            this.Label54.Border.BottomColor = System.Drawing.Color.Black;
            this.Label54.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label54.Border.LeftColor = System.Drawing.Color.Black;
            this.Label54.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label54.Border.RightColor = System.Drawing.Color.Black;
            this.Label54.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label54.Border.TopColor = System.Drawing.Color.Black;
            this.Label54.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label54.Height = 0.2F;
            this.Label54.HyperLink = null;
            this.Label54.Left = 1.9375F;
            this.Label54.Name = "Label54";
            this.Label54.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label54.Text = "Seatbelt:";
            this.Label54.Top = 4.5F;
            this.Label54.Width = 0.9375F;
            // 
            // Label56
            // 
            this.Label56.Border.BottomColor = System.Drawing.Color.Black;
            this.Label56.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label56.Border.LeftColor = System.Drawing.Color.Black;
            this.Label56.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label56.Border.RightColor = System.Drawing.Color.Black;
            this.Label56.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label56.Border.TopColor = System.Drawing.Color.Black;
            this.Label56.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label56.Height = 0.2F;
            this.Label56.HyperLink = null;
            this.Label56.Left = 2.5625F;
            this.Label56.Name = "Label56";
            this.Label56.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label56.Text = "Year:";
            this.Label56.Top = 1.1875F;
            this.Label56.Width = 1.188F;
            // 
            // txtYear
            // 
            this.txtYear.Border.BottomColor = System.Drawing.Color.Black;
            this.txtYear.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtYear.Border.LeftColor = System.Drawing.Color.Black;
            this.txtYear.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtYear.Border.RightColor = System.Drawing.Color.Black;
            this.txtYear.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtYear.Border.TopColor = System.Drawing.Color.Black;
            this.txtYear.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtYear.Height = 0.2F;
            this.txtYear.Left = 3.75F;
            this.txtYear.MultiLine = false;
            this.txtYear.Name = "txtYear";
            this.txtYear.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtYear.Text = "txtYear";
            this.txtYear.Top = 1.1875F;
            this.txtYear.Width = 0.875F;
            // 
            // Label57
            // 
            this.Label57.Border.BottomColor = System.Drawing.Color.Black;
            this.Label57.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label57.Border.LeftColor = System.Drawing.Color.Black;
            this.Label57.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label57.Border.RightColor = System.Drawing.Color.Black;
            this.Label57.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label57.Border.TopColor = System.Drawing.Color.Black;
            this.Label57.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label57.Height = 0.2F;
            this.Label57.HyperLink = null;
            this.Label57.Left = 0.3125F;
            this.Label57.Name = "Label57";
            this.Label57.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label57.Text = "Age:";
            this.Label57.Top = 1.4375F;
            this.Label57.Width = 0.75F;
            // 
            // txtAge
            // 
            this.txtAge.Border.BottomColor = System.Drawing.Color.Black;
            this.txtAge.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAge.Border.LeftColor = System.Drawing.Color.Black;
            this.txtAge.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAge.Border.RightColor = System.Drawing.Color.Black;
            this.txtAge.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAge.Border.TopColor = System.Drawing.Color.Black;
            this.txtAge.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAge.Height = 0.2F;
            this.txtAge.Left = 1.0625F;
            this.txtAge.MultiLine = false;
            this.txtAge.Name = "txtAge";
            this.txtAge.Style = "font-weight: normal; font-size: 7.8pt; ";
            this.txtAge.Text = "txtAge";
            this.txtAge.Top = 1.4375F;
            this.txtAge.Width = 0.875F;
            // 
            // Label58
            // 
            this.Label58.Border.BottomColor = System.Drawing.Color.Black;
            this.Label58.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label58.Border.LeftColor = System.Drawing.Color.Black;
            this.Label58.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label58.Border.RightColor = System.Drawing.Color.Black;
            this.Label58.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label58.Border.TopColor = System.Drawing.Color.Black;
            this.Label58.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label58.Height = 0.2F;
            this.Label58.HyperLink = null;
            this.Label58.Left = 0.1875F;
            this.Label58.MultiLine = false;
            this.Label58.Name = "Label58";
            this.Label58.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label58.Text = "Only Operator:";
            this.Label58.Top = 2.181F;
            this.Label58.Width = 0.875F;
            // 
            // txtOnlyOperator
            // 
            this.txtOnlyOperator.Border.BottomColor = System.Drawing.Color.Black;
            this.txtOnlyOperator.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOnlyOperator.Border.LeftColor = System.Drawing.Color.Black;
            this.txtOnlyOperator.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOnlyOperator.Border.RightColor = System.Drawing.Color.Black;
            this.txtOnlyOperator.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOnlyOperator.Border.TopColor = System.Drawing.Color.Black;
            this.txtOnlyOperator.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOnlyOperator.Height = 0.2F;
            this.txtOnlyOperator.Left = 1.0625F;
            this.txtOnlyOperator.MultiLine = false;
            this.txtOnlyOperator.Name = "txtOnlyOperator";
            this.txtOnlyOperator.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtOnlyOperator.Text = "txtOnlyOperator";
            this.txtOnlyOperator.Top = 2.181F;
            this.txtOnlyOperator.Width = 0.875F;
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
            this.Line1.Left = 0.0625F;
            this.Line1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Line1.LineWeight = 2F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 3.1875F;
            this.Line1.Width = 6.9375F;
            this.Line1.X1 = 0.0625F;
            this.Line1.X2 = 7F;
            this.Line1.Y1 = 3.1875F;
            this.Line1.Y2 = 3.1875F;
            // 
            // Label59
            // 
            this.Label59.Border.BottomColor = System.Drawing.Color.Black;
            this.Label59.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label59.Border.LeftColor = System.Drawing.Color.Black;
            this.Label59.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label59.Border.RightColor = System.Drawing.Color.Black;
            this.Label59.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label59.Border.TopColor = System.Drawing.Color.Black;
            this.Label59.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label59.Height = 0.2F;
            this.Label59.HyperLink = null;
            this.Label59.Left = -0.0625F;
            this.Label59.MultiLine = false;
            this.Label59.Name = "Label59";
            this.Label59.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label59.Text = "Principal Operator:";
            this.Label59.Top = 2.431F;
            this.Label59.Width = 1.125F;
            // 
            // txtPrincipalOperator
            // 
            this.txtPrincipalOperator.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPrincipalOperator.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPrincipalOperator.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPrincipalOperator.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPrincipalOperator.Border.RightColor = System.Drawing.Color.Black;
            this.txtPrincipalOperator.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPrincipalOperator.Border.TopColor = System.Drawing.Color.Black;
            this.txtPrincipalOperator.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPrincipalOperator.Height = 0.2F;
            this.txtPrincipalOperator.Left = 1.0625F;
            this.txtPrincipalOperator.MultiLine = false;
            this.txtPrincipalOperator.Name = "txtPrincipalOperator";
            this.txtPrincipalOperator.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtPrincipalOperator.Text = "txtPrincipalOperator";
            this.txtPrincipalOperator.Top = 2.431F;
            this.txtPrincipalOperator.Width = 0.875F;
            // 
            // Label60
            // 
            this.Label60.Border.BottomColor = System.Drawing.Color.Black;
            this.Label60.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label60.Border.LeftColor = System.Drawing.Color.Black;
            this.Label60.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label60.Border.RightColor = System.Drawing.Color.Black;
            this.Label60.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label60.Border.TopColor = System.Drawing.Color.Black;
            this.Label60.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label60.Height = 0.2F;
            this.Label60.HyperLink = null;
            this.Label60.Left = 0.4375F;
            this.Label60.MultiLine = false;
            this.Label60.Name = "Label60";
            this.Label60.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label60.Text = "Phone:";
            this.Label60.Top = 2.681F;
            this.Label60.Width = 0.625F;
            // 
            // txtPhone
            // 
            this.txtPhone.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPhone.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPhone.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPhone.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPhone.Border.RightColor = System.Drawing.Color.Black;
            this.txtPhone.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPhone.Border.TopColor = System.Drawing.Color.Black;
            this.txtPhone.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPhone.Height = 0.2F;
            this.txtPhone.Left = 1.0625F;
            this.txtPhone.MultiLine = false;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtPhone.Text = "TextBox2";
            this.txtPhone.Top = 2.681F;
            this.txtPhone.Width = 0.875F;
            // 
            // Label61
            // 
            this.Label61.Border.BottomColor = System.Drawing.Color.Black;
            this.Label61.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label61.Border.LeftColor = System.Drawing.Color.Black;
            this.Label61.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label61.Border.RightColor = System.Drawing.Color.Black;
            this.Label61.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label61.Border.TopColor = System.Drawing.Color.Black;
            this.Label61.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label61.Height = 0.2F;
            this.Label61.HyperLink = null;
            this.Label61.Left = 0.0625F;
            this.Label61.Name = "Label61";
            this.Label61.Style = "color: Black; font-weight: bold; ";
            this.Label61.Text = "Owner:";
            this.Label61.Top = 0.4375F;
            this.Label61.Width = 0.5625F;
            // 
            // LblOwner
            // 
            this.LblOwner.Border.BottomColor = System.Drawing.Color.Black;
            this.LblOwner.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblOwner.Border.LeftColor = System.Drawing.Color.Black;
            this.LblOwner.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblOwner.Border.RightColor = System.Drawing.Color.Black;
            this.LblOwner.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblOwner.Border.TopColor = System.Drawing.Color.Black;
            this.LblOwner.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblOwner.Height = 0.2F;
            this.LblOwner.HyperLink = null;
            this.LblOwner.Left = 0.5625F;
            this.LblOwner.Name = "LblOwner";
            this.LblOwner.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; vertical-align: middle; ";
            this.LblOwner.Text = "LblOwner";
            this.LblOwner.Top = 0.4375F;
            this.LblOwner.Width = 2.0625F;
            // 
            // Label62
            // 
            this.Label62.Border.BottomColor = System.Drawing.Color.Black;
            this.Label62.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label62.Border.LeftColor = System.Drawing.Color.Black;
            this.Label62.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label62.Border.RightColor = System.Drawing.Color.Black;
            this.Label62.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label62.Border.TopColor = System.Drawing.Color.Black;
            this.Label62.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label62.Height = 0.2F;
            this.Label62.HyperLink = null;
            this.Label62.Left = 4.125F;
            this.Label62.Name = "Label62";
            this.Label62.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label62.Text = "ISO Code:";
            this.Label62.Top = 3.7775F;
            this.Label62.Width = 1F;
            // 
            // txtISOcode
            // 
            this.txtISOcode.Border.BottomColor = System.Drawing.Color.Black;
            this.txtISOcode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtISOcode.Border.LeftColor = System.Drawing.Color.Black;
            this.txtISOcode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtISOcode.Border.RightColor = System.Drawing.Color.Black;
            this.txtISOcode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtISOcode.Border.TopColor = System.Drawing.Color.Black;
            this.txtISOcode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtISOcode.Height = 0.2F;
            this.txtISOcode.Left = 5.1875F;
            this.txtISOcode.MultiLine = false;
            this.txtISOcode.Name = "txtISOcode";
            this.txtISOcode.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; ";
            this.txtISOcode.Text = "txtISOcode";
            this.txtISOcode.Top = 3.7775F;
            this.txtISOcode.Width = 0.875F;
            // 
            // Label63
            // 
            this.Label63.Border.BottomColor = System.Drawing.Color.Black;
            this.Label63.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label63.Border.LeftColor = System.Drawing.Color.Black;
            this.Label63.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label63.Border.RightColor = System.Drawing.Color.Black;
            this.Label63.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label63.Border.TopColor = System.Drawing.Color.Black;
            this.Label63.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label63.Height = 0.2F;
            this.Label63.HyperLink = null;
            this.Label63.Left = 0.125F;
            this.Label63.Name = "Label63";
            this.Label63.Style = "color: Black; font-weight: bold; ";
            this.Label63.Text = "Vehicle:";
            this.Label63.Top = 0.125F;
            this.Label63.Width = 0.5625F;
            // 
            // LblVehicleCount
            // 
            this.LblVehicleCount.Border.BottomColor = System.Drawing.Color.Black;
            this.LblVehicleCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblVehicleCount.Border.LeftColor = System.Drawing.Color.Black;
            this.LblVehicleCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblVehicleCount.Border.RightColor = System.Drawing.Color.Black;
            this.LblVehicleCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblVehicleCount.Border.TopColor = System.Drawing.Color.Black;
            this.LblVehicleCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblVehicleCount.Height = 0.2F;
            this.LblVehicleCount.HyperLink = null;
            this.LblVehicleCount.Left = 0.6875F;
            this.LblVehicleCount.Name = "LblVehicleCount";
            this.LblVehicleCount.Style = "";
            this.LblVehicleCount.Text = "LblVehicleCount";
            this.LblVehicleCount.Top = 0.125F;
            this.LblVehicleCount.Width = 0.25F;
            // 
            // Label64
            // 
            this.Label64.Border.BottomColor = System.Drawing.Color.Black;
            this.Label64.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label64.Border.LeftColor = System.Drawing.Color.Black;
            this.Label64.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label64.Border.RightColor = System.Drawing.Color.Black;
            this.Label64.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label64.Border.TopColor = System.Drawing.Color.Black;
            this.Label64.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label64.Height = 0.2F;
            this.Label64.HyperLink = null;
            this.Label64.Left = 4.125F;
            this.Label64.Name = "Label64";
            this.Label64.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; ";
            this.Label64.Text = "Rental:";
            this.Label64.Top = 3.5345F;
            this.Label64.Width = 1F;
            // 
            // TxtVehicleRental
            // 
            this.TxtVehicleRental.Border.BottomColor = System.Drawing.Color.Black;
            this.TxtVehicleRental.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVehicleRental.Border.LeftColor = System.Drawing.Color.Black;
            this.TxtVehicleRental.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVehicleRental.Border.RightColor = System.Drawing.Color.Black;
            this.TxtVehicleRental.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVehicleRental.Border.TopColor = System.Drawing.Color.Black;
            this.TxtVehicleRental.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TxtVehicleRental.Height = 0.2F;
            this.TxtVehicleRental.Left = 5.187F;
            this.TxtVehicleRental.MultiLine = false;
            this.TxtVehicleRental.Name = "TxtVehicleRental";
            this.TxtVehicleRental.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; ";
            this.TxtVehicleRental.Text = "TxtVehicleRental";
            this.TxtVehicleRental.Top = 3.5345F;
            this.TxtVehicleRental.Width = 0.875F;
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
            this.Line2.Left = 0.07638889F;
            this.Line2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Line2.LineWeight = 2F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0.3888889F;
            this.Line2.Width = 6.9375F;
            this.Line2.X1 = 0.07638889F;
            this.Line2.X2 = 7.013889F;
            this.Line2.Y1 = 0.3888889F;
            this.Line2.Y2 = 0.3888889F;
            // 
            // rptQuoteAutoCover
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.7F;
            this.PageSettings.Margins.Left = 0.8F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 6.983333F;
            this.Sections.Add(this.Detail);
            this.ShowParameterUI = false;
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.rptQuoteAutoCover_FetchData);
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehicleAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewUsed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActualValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTerritory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlarmType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepreciation1st)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMedicalLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeaseLoanGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCollision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComprehensive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountCollComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBiLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPdLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCslLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountBiPd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPremium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirthdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaritalStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalColl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalBI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalLeaseLoanGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTowing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAssistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeatbelt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnlyOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrincipalOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblOwner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtISOcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblVehicleCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVehicleRental)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
		#endregion

        private void Detail_Format(object sender, EventArgs e)
        {

        }

        private int GetPrimaryAssignedDriverIndex(
    EPolicy.Quotes.AutoCover AutoCover)
        {
            EPolicy.Quotes.AssignedDriver driver = null;

            for (int i = 0; i < AutoCover.AssignedDrivers.Count; i++)
            {
                driver = (EPolicy.Quotes.AssignedDriver)AutoCover.AssignedDrivers[i];
                //Se comento ya que solo va haber un solo driver asignado a cada vehiculo
                //if(driver.PrincipalOperator)  
                return i;
            }
            return -1;
        }

        private string GetFirstPeriodIsoCode(EPolicy.Quotes.AutoCover AutoCover)
        {
            EPolicy.Quotes.CoverBreakdown srch = new
                EPolicy.Quotes.CoverBreakdown();
            srch.Type = (int)EPolicy.Quotes.Enumerators.Premiums.IsoCode;
            EPolicy.Quotes.CoverBreakdown ISOC = (EPolicy.Quotes.CoverBreakdown)
                AutoCover.Breakdown[AutoCover.Breakdown.IndexOf(srch)];
            return (string)ISOC.Breakdown[0];
        }

        private void rptQuoteAutoCover_FetchData(object sender, FetchEventArgs eArgs)
        {
            if (this._iRow >= this._autoCover.Count)
            {
                eArgs.EOF = true;
                return;
            }

            //Owner
            EPolicy.Quotes.AutoDriver AD;
            for (int i = 0; i < _policy.Drivers.Count; i++)
            {
                AD = (EPolicy.Quotes.AutoDriver)_policy.Drivers[i];

                if (_policy.Prospect.ProspectID == AD.ProspectID)
                {
                    LblOwner.Text = AD.FirstName.Trim() + " " +
                        AD.LastName1.Trim() + " " + AD.LastName2.Trim();
                }
            }

            EPolicy.Quotes.AutoCover autoCover = (EPolicy.Quotes.AutoCover)this._autoCover[this._iRow];

            int mcount = this._iRow + 1;
            this.LblVehicleCount.Text = mcount.ToString().Trim();

            this._primaryAssignedDriver = (EPolicy.Quotes.AssignedDriver)
                autoCover.AssignedDrivers[this.GetPrimaryAssignedDriverIndex(autoCover)];
            this._breakdown = (EPolicy.Quotes.CoverBreakdown)autoCover.Breakdown[0];

            this.lblMake.Text = LookupTables.GetDescription("VehicleMake",
                autoCover.VehicleMake.ToString());
            this.lblModel.Text = LookupTables.GetDescription("VehicleModel",
                autoCover.VehicleModel.ToString());
            this.lblYear.Text = LookupTables.GetDescription("VehicleYear",
                autoCover.VehicleYear.ToString());

            this.txtName.Text = this._primaryAssignedDriver.AutoDriver.FirstName.Trim() +
                " " + this._primaryAssignedDriver.AutoDriver.LastName1.Trim() +
                " " + this._primaryAssignedDriver.AutoDriver.LastName2.Trim();
            this.txtBirthdate.Text = this._primaryAssignedDriver.AutoDriver.BirthDate.Trim();
            this.txtMaritalStatus.Text = LookupTables.GetDescription("MaritalStatus",
                _primaryAssignedDriver.AutoDriver.MaritalStatus.ToString());
            this.txtGender.Text = LookupTables.GetDescription("Gender",
                _primaryAssignedDriver.AutoDriver.Gender.ToString());

            this.txtVIN.Text = autoCover.VIN.Trim() == string.Empty ?
                "Not entered." : autoCover.VIN.Trim();
            //this.txtPlate.Text = autoCover.Plate.Trim();
            this.txtVehicleAge.Text = autoCover.VehicleAge.ToString() == "0" ? "New" :
                autoCover.VehicleAge.ToString() + " years";
            this.txtNewUsed.Text = autoCover.NewUse == 1 ? "Used" : "New";
            this.txtCost.Text = String.Format("{0:c}", autoCover.Cost);

            if (autoCover.ActualValue != 0)
            {
                //this.txtActualValue.Text = String.Format("{0:c}", autoCover.ActualValue);
                this.txtActualValue.Text = String.Format("{0:c}", autoCover.ActualValue);
            }
            else
            {
                this.txtActualValue.Text = "N/A";
            }

            /*this.txtHome.Text = 
                this.GetDescFromID(this._autoCover[this._iRow].HomeCity,
                (int)Tables.CITY);
            this.txtWork.Text = 
                this.GetDescFromID(this._autoCover[this._iRow].WorkCity,
                (int)Tables.CITY);*/
            this.txtClass.Text = this.GetVehicleClassDescFromID(autoCover.VehicleClass);
            this.txtTerritory.Text =
                this.GetDescFromID(autoCover.Territory,
                (int)Tables.TERRITORY);
            this.txtAlarmType.Text =
                this.GetDescFromID(autoCover.AlarmType,
                (int)Tables.ALARM_TYPE);
            this.txtDepreciation1st.Text =
                autoCover.Depreciation1stYear.ToString() == "0" ?
                "N/A" : autoCover.Depreciation1stYear.ToString() + "%";
            /*this.txtDepreciationOther.Text = 
                this._autoCover[this._iRow].DepreciationAllYear.ToString();*/
            this.txtMedicalLimit.Text =
                this.GetDescFromID(
                autoCover.MedicalLimit,
                (int)Tables.MEDICAL_LIMIT) == string.Empty ? "0" :
                this.GetDescFromID(autoCover.MedicalLimit,
                (int)Tables.MEDICAL_LIMIT).Trim();
            this.txtAssistance.Text = String.Format("{0:c}", autoCover.AssistancePremium);
            this.txtTowing.Text = String.Format("{0:c}", autoCover.TowingPremium);
            this.TxtVehicleRental.Text = String.Format("{0:c}", autoCover.VehicleRental);

            this.txtLeaseLoanGap.Text = this.GetDescFromID(autoCover.LeaseLoanGapId,
                (int)Tables.LEASE_LOAN_GAP) == string.Empty ? "No" :
                "Yes";

            //			this.txtLeaseLoanGap.Text = this.GetDescFromID(autoCover.LeaseLoanGapId,
            //				(int)Tables.LEASE_LOAN_GAP) == string.Empty ? "0%" : 
            //				this.GetDescFromID(autoCover.LeaseLoanGapId,(int)Tables.LEASE_LOAN_GAP) + "%";
            this.txtSeatbelt.Text = String.Format("{0:c}", autoCover.SeatBelt);
            this.txtPAR.Text = String.Format("{0:c}", autoCover.PersonalAccidentRider);
            this.txtCollision.Text = this.GetDescFromID(
                autoCover.CollisionDeductible,
                (int)Tables.COLLISION_DEDUCTIBLE) == string.Empty ?
                "0" : this.GetDescFromID(
                autoCover.CollisionDeductible,
                (int)Tables.COLLISION_DEDUCTIBLE);
            this.txtComprehensive.Text = this.GetDescFromID(
                autoCover.ComprehensiveDeductible,
                (int)Tables.COMPREHENSIVE_DEDUCTIBLE) == string.Empty ?
                "0" : this.GetDescFromID(
                autoCover.ComprehensiveDeductible,
                (int)Tables.COMPREHENSIVE_DEDUCTIBLE);
            this.txtDiscountCollComp.Text =
                autoCover.DiscountCompColl.ToString();
            this.txtBiLimit.Text = this.GetDescFromID(
                autoCover.BodilyInjuryLimit,
                (int)Tables.BODILY_INJURY_LIMIT) == string.Empty ?
                "0" : this.GetDescFromID(
                autoCover.BodilyInjuryLimit,
                (int)Tables.BODILY_INJURY_LIMIT);
            this.txtPdLimit.Text = this.GetDescFromID(
                autoCover.PropertyDamageLimit,
                (int)Tables.PROPERTY_DAMAGE_LIMIT) == string.Empty ?
                "0" : this.GetDescFromID(
                autoCover.PropertyDamageLimit,
                (int)Tables.PROPERTY_DAMAGE_LIMIT);
            this.txtCslLimit.Text =
                this.GetDescFromID(
                autoCover.CombinedSingleLimit,
                (int)Tables.COMBINED_SINGLE_LIMIT) == string.Empty ?
                "0" : this.GetDescFromID(
                autoCover.CombinedSingleLimit,
                (int)Tables.COMBINED_SINGLE_LIMIT);
            this.txtDiscountBiPd.Text =
                autoCover.DiscountBIPD.ToString();
            /*this.txtPrimaryDriver.Text = 
                this.GetPrimaryDriverFullName(this._autoCover[this._iRow]);*/
            this.txtPremium.Text = String.Format("{0:c}",
                autoCover.TotalAmount);
            this.txtISOcode.Text =
                this.GetFirstPeriodIsoCode(autoCover);
            this.txtTotalComp.Text = String.Format("{0:c}",
                autoCover.ComprehensivePremium());
            this.txtTotalColl.Text = String.Format("{0:c}",
                autoCover.CollisionPremium());
            this.txtTotalBI.Text = String.Format("{0:c}",
                autoCover.BodilyInjuryPremium());
            this.txtTotalPD.Text = String.Format("{0:c}",
                autoCover.PropertyDamagePremium());
            this.txtTotalCSL.Text = String.Format("{0:c}",
                autoCover.CombinedSinglePremium());
            this.txtTotalLeaseLoanGap.Text = String.Format("{0:c}",
                autoCover.LeaseLoanGapPremium());

            this.txtAge.Text =
                this._primaryAssignedDriver.AutoDriver.BirthDate ==
                string.Empty ?
                string.Empty :
                Customer.GetAge(
                DateTime.Parse(
                this._primaryAssignedDriver.AutoDriver.BirthDate)).ToString();

            if (this._primaryAssignedDriver.OnlyOperator)
            {
                //this.txtOnlyOperator.Text = this._primaryAssignedDriver.OnlyOperator.ToString();
                this.txtOnlyOperator.Text = "Yes";
            }
            else
            {
                this.txtOnlyOperator.Text = "No";
            }

            if (this._primaryAssignedDriver.PrincipalOperator)
            {
                //this.txtPrincipalOperator.Text = this._primaryAssignedDriver.PrincipalOperator.ToString();
                this.txtPrincipalOperator.Text = "Yes";
            }
            else
            {
                this.txtPrincipalOperator.Text = "No";
            }

            this.txtYear.Text =
                autoCover.VehicleYear == 0 ? string.Empty :
                LookupTables.GetDescription("VehicleYear", autoCover.VehicleYear.ToString());
            this.txtPhone.Text =
                this._primaryAssignedDriver.AutoDriver.HomePhone.ToString();

            this._iRow++;
            eArgs.EOF = false;
        }

        private enum Tables
        {
            CITY, TERRITORY, ALARM_TYPE,
            MEDICAL_LIMIT, LEASE_LOAN_GAP, COLLISION_DEDUCTIBLE,
            COMPREHENSIVE_DEDUCTIBLE, BODILY_INJURY_LIMIT,
            PROPERTY_DAMAGE_LIMIT, COMBINED_SINGLE_LIMIT, VEHICLECLASS
        };

        private string GetPrimaryDriverFullName(EPolicy.Quotes.AutoCover AutoCover)
        {
            foreach (EPolicy.Quotes.AssignedDriver driver in
                AutoCover.AssignedDrivers)
            {
                if (driver.PrincipalOperator)
                {
                    return driver.AutoDriver.FirstName.Trim() + " " +
                        driver.AutoDriver.LastName1.Trim() + " " +
                        driver.AutoDriver.LastName2.Trim();
                }
            }
            return string.Empty;
        }

        private string GetDescFromID(int ID, int Table)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];
            string sProc = string.Empty;
            Baldrich.DBRequest.DBRequest dbReq = new Baldrich.DBRequest.DBRequest();

            DbRequestXmlCooker.AttachCookItem("ID", SqlDbType.Int,
                0, ID.ToString(), ref cookItems);

            switch (Table)
            {
                case (int)Tables.CITY:
                    sProc = "GetCityByID";
                    break;
                case (int)Tables.TERRITORY:
                    sProc = "GetTerritoryByID";
                    break;
                case (int)Tables.ALARM_TYPE:
                    sProc = "GetAlarmTypeByID";
                    break;
                case (int)Tables.MEDICAL_LIMIT:
                    sProc = "GetMedicalLimitByID";
                    break;
                case (int)Tables.LEASE_LOAN_GAP:
                    sProc = "GetLeaseLoanGapByID";
                    break;
                case (int)Tables.COLLISION_DEDUCTIBLE:
                    sProc = "GetCollisionDeductibleByID";
                    break;
                case (int)Tables.COMPREHENSIVE_DEDUCTIBLE:
                    sProc = "GetComprehensiveDeductibleByID";
                    break;
                case (int)Tables.BODILY_INJURY_LIMIT:
                    sProc = "GetBodilyInjuryLimitByID";
                    break;
                case (int)Tables.PROPERTY_DAMAGE_LIMIT:
                    sProc = "GetPropertyDamageLimitByID";
                    break;
                case (int)Tables.COMBINED_SINGLE_LIMIT:
                    sProc = "GetCombinedSingleLimitByID";
                    break;
                default:
                    return string.Empty;
            }

            DataTable dt = dbReq.GetQuery(sProc,
                DbRequestXmlCooker.Cook(cookItems));

            if (dt.Rows != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            return string.Empty;
        }

        private string GetVehicleClassDescFromID(string ID)
        {
            DbRequestXmlCookRequestItem[] cookItems = new DbRequestXmlCookRequestItem[1];
            string sProc = "GetVehicleClassByVehicleClassID";
            Baldrich.DBRequest.DBRequest dbReq = new Baldrich.DBRequest.DBRequest();

            DbRequestXmlCooker.AttachCookItem("ID", SqlDbType.Char,
                2, ID.ToString(), ref cookItems);

            DataTable dt = dbReq.GetQuery(sProc,
                DbRequestXmlCooker.Cook(cookItems));

            if (dt.Rows != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            return string.Empty;
        }

	}
}
