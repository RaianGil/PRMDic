using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.Payments
{
	public class PaymentReceipt : DataDynamics.ActiveReports.ActiveReport3
	{
        private EPolicy.TaskControl.Payments _payments;
        private int index = 0;

        public PaymentReceipt(EPolicy.TaskControl.Payments payments)
		{
            _payments = payments;

			InitializeComponent();
		}

		#region ActiveReports Designer generated code
		private PageHeader PageHeader = null;
		private Shape Shape11 = null;
		private Shape Shape8 = null;
		private Label Label159 = null;
		private Label Label140 = null;
		private Shape Shape3 = null;
		private Label Label121 = null;
		private TextBox txtPolicyNumber = null;
		private Shape Shape10 = null;
		private Shape Shape7 = null;
		private Shape Shape5 = null;
		private Label lblDate = null;
		private Label lblTime = null;
		private Label lblCriterias = null;
		private Line Line11 = null;
		private Line Line14 = null;
		private Label LblPolicyClass = null;
		private Shape Shape4 = null;
		private Line Line18 = null;
		private Line Line19 = null;
		private Label Label7 = null;
		private Label Label108 = null;
		private Label Label109 = null;
		private TextBox txtName = null;
		private TextBox txtPayment = null;
		private TextBox txtPaid = null;
		private Label Label114 = null;
		private Label Label115 = null;
		private Label Label116 = null;
		private Label Label117 = null;
		private TextBox txtCustomer = null;
		private TextBox txtProducer = null;
		private Line Line24 = null;
		private Line Line25 = null;
		private Line Line26 = null;
		private Line Line27 = null;
		private TextBox txtReceived = null;
		private Line Line28 = null;
		private Line Line29 = null;
		private TextBox txtNumber = null;
		private Line Line30 = null;
		private Label Label118 = null;
		private Line Line31 = null;
		private Line Line32 = null;
		private Line Line33 = null;
		private Line Line36 = null;
		private Line Line44 = null;
		private Line Line49 = null;
		private Line Line57 = null;
		private Line Line46 = null;
		private Line Line38 = null;
		private Line Line59 = null;
		private Line Line60 = null;
		private Line Line61 = null;
		private Line Line62 = null;
		private Label Label119 = null;
		private Label Label120 = null;
		private Label lblDate1 = null;
		private Label lblTime1 = null;
		private Label Label127 = null;
		private Line Line63 = null;
		private Line Line64 = null;
		private Label LblPolicyClass2 = null;
		private Shape Shape6 = null;
		private Line Line65 = null;
		private Line Line66 = null;
		private Label Label130 = null;
		private Label Label131 = null;
		private Label Label132 = null;
		private TextBox txtName1 = null;
		private TextBox txtPayment1 = null;
		private TextBox txtPaid1 = null;
		private Label Label133 = null;
		private Label Label134 = null;
		private Label Label135 = null;
		private Label Label136 = null;
		private TextBox txtCustomer1 = null;
		private TextBox txtProducer1 = null;
		private Line Line68 = null;
		private Line Line69 = null;
		private Line Line70 = null;
		private TextBox txtPolicyNumber1 = null;
		private TextBox txtReceived1 = null;
		private Line Line71 = null;
		private Line Line72 = null;
		private TextBox txtNumber1 = null;
		private Line Line73 = null;
		private Label Label137 = null;
		private Line Line74 = null;
		private Line Line75 = null;
		private Line Line76 = null;
		private Line Line77 = null;
		private Line Line78 = null;
		private Line Line79 = null;
		private Line Line80 = null;
		private Line Line81 = null;
		private Line Line82 = null;
		private Line Line83 = null;
		private Line Line84 = null;
		private Line Line85 = null;
		private Label Label138 = null;
		private Label Label139 = null;
		private Label lblDate2 = null;
		private Label lblTime2 = null;
		private Label Label146 = null;
		private Line Line86 = null;
		private Line Line87 = null;
		private Label LblPolicyClass3 = null;
		private Shape Shape9 = null;
		private Line Line88 = null;
		private Line Line89 = null;
		private Label Label149 = null;
		private Label Label150 = null;
		private Label Label151 = null;
		private TextBox txtName2 = null;
		private TextBox txtPayment2 = null;
		private TextBox txtPaid2 = null;
		private Label Label152 = null;
		private Label Label153 = null;
		private Label Label154 = null;
		private Label Label155 = null;
		private TextBox txtCustomer2 = null;
		private TextBox txtProducer2 = null;
		private Line Line91 = null;
		private Line Line92 = null;
		private Line Line93 = null;
		private TextBox txtPolicyNumber2 = null;
		private TextBox txtReceived2 = null;
		private Line Line94 = null;
		private Line Line95 = null;
		private TextBox txtNumber2 = null;
		private Line Line96 = null;
		private Label Label156 = null;
		private Line Line98 = null;
		private Line Line99 = null;
		private Line Line100 = null;
		private Line Line101 = null;
		private Line Line102 = null;
		private Line Line103 = null;
		private Line Line104 = null;
		private Line Line106 = null;
		private Line Line107 = null;
		private Line Line108 = null;
		private Label Label157 = null;
		private Label Label158 = null;
		private Line Line109 = null;
		private Line Line110 = null;
		private Line Line111 = null;
		private Line Line112 = null;
		private Line Line90 = null;
		private Label LblTaskControlID = null;
		private Label LblTaskControl1ID = null;
		private Label LblTaskControl2ID = null;
        private Label Label75 = null;
        private Label Label = null;
        private Label Label2 = null;
		private Detail Detail = null;
		private PageFooter PageFooter = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentReceipt));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Shape11 = new DataDynamics.ActiveReports.Shape();
            this.Shape8 = new DataDynamics.ActiveReports.Shape();
            this.Label159 = new DataDynamics.ActiveReports.Label();
            this.Label140 = new DataDynamics.ActiveReports.Label();
            this.Shape3 = new DataDynamics.ActiveReports.Shape();
            this.Label121 = new DataDynamics.ActiveReports.Label();
            this.txtPolicyNumber = new DataDynamics.ActiveReports.TextBox();
            this.Shape10 = new DataDynamics.ActiveReports.Shape();
            this.Shape7 = new DataDynamics.ActiveReports.Shape();
            this.Shape5 = new DataDynamics.ActiveReports.Shape();
            this.lblDate = new DataDynamics.ActiveReports.Label();
            this.lblTime = new DataDynamics.ActiveReports.Label();
            this.lblCriterias = new DataDynamics.ActiveReports.Label();
            this.Line11 = new DataDynamics.ActiveReports.Line();
            this.Line14 = new DataDynamics.ActiveReports.Line();
            this.LblPolicyClass = new DataDynamics.ActiveReports.Label();
            this.Shape4 = new DataDynamics.ActiveReports.Shape();
            this.Line18 = new DataDynamics.ActiveReports.Line();
            this.Line19 = new DataDynamics.ActiveReports.Line();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.Label108 = new DataDynamics.ActiveReports.Label();
            this.Label109 = new DataDynamics.ActiveReports.Label();
            this.txtName = new DataDynamics.ActiveReports.TextBox();
            this.txtPayment = new DataDynamics.ActiveReports.TextBox();
            this.txtPaid = new DataDynamics.ActiveReports.TextBox();
            this.Label114 = new DataDynamics.ActiveReports.Label();
            this.Label115 = new DataDynamics.ActiveReports.Label();
            this.Label116 = new DataDynamics.ActiveReports.Label();
            this.Label117 = new DataDynamics.ActiveReports.Label();
            this.txtCustomer = new DataDynamics.ActiveReports.TextBox();
            this.txtProducer = new DataDynamics.ActiveReports.TextBox();
            this.Line24 = new DataDynamics.ActiveReports.Line();
            this.Line25 = new DataDynamics.ActiveReports.Line();
            this.Line26 = new DataDynamics.ActiveReports.Line();
            this.Line27 = new DataDynamics.ActiveReports.Line();
            this.txtReceived = new DataDynamics.ActiveReports.TextBox();
            this.Line28 = new DataDynamics.ActiveReports.Line();
            this.Line29 = new DataDynamics.ActiveReports.Line();
            this.txtNumber = new DataDynamics.ActiveReports.TextBox();
            this.Line30 = new DataDynamics.ActiveReports.Line();
            this.Label118 = new DataDynamics.ActiveReports.Label();
            this.Line31 = new DataDynamics.ActiveReports.Line();
            this.Line32 = new DataDynamics.ActiveReports.Line();
            this.Line33 = new DataDynamics.ActiveReports.Line();
            this.Line36 = new DataDynamics.ActiveReports.Line();
            this.Line44 = new DataDynamics.ActiveReports.Line();
            this.Line49 = new DataDynamics.ActiveReports.Line();
            this.Line57 = new DataDynamics.ActiveReports.Line();
            this.Line46 = new DataDynamics.ActiveReports.Line();
            this.Line38 = new DataDynamics.ActiveReports.Line();
            this.Line59 = new DataDynamics.ActiveReports.Line();
            this.Line60 = new DataDynamics.ActiveReports.Line();
            this.Line61 = new DataDynamics.ActiveReports.Line();
            this.Line62 = new DataDynamics.ActiveReports.Line();
            this.Label119 = new DataDynamics.ActiveReports.Label();
            this.Label120 = new DataDynamics.ActiveReports.Label();
            this.lblDate1 = new DataDynamics.ActiveReports.Label();
            this.lblTime1 = new DataDynamics.ActiveReports.Label();
            this.Label127 = new DataDynamics.ActiveReports.Label();
            this.Line63 = new DataDynamics.ActiveReports.Line();
            this.Line64 = new DataDynamics.ActiveReports.Line();
            this.LblPolicyClass2 = new DataDynamics.ActiveReports.Label();
            this.Shape6 = new DataDynamics.ActiveReports.Shape();
            this.Line65 = new DataDynamics.ActiveReports.Line();
            this.Line66 = new DataDynamics.ActiveReports.Line();
            this.Label130 = new DataDynamics.ActiveReports.Label();
            this.Label131 = new DataDynamics.ActiveReports.Label();
            this.Label132 = new DataDynamics.ActiveReports.Label();
            this.txtName1 = new DataDynamics.ActiveReports.TextBox();
            this.txtPayment1 = new DataDynamics.ActiveReports.TextBox();
            this.txtPaid1 = new DataDynamics.ActiveReports.TextBox();
            this.Label133 = new DataDynamics.ActiveReports.Label();
            this.Label134 = new DataDynamics.ActiveReports.Label();
            this.Label135 = new DataDynamics.ActiveReports.Label();
            this.Label136 = new DataDynamics.ActiveReports.Label();
            this.txtCustomer1 = new DataDynamics.ActiveReports.TextBox();
            this.txtProducer1 = new DataDynamics.ActiveReports.TextBox();
            this.Line68 = new DataDynamics.ActiveReports.Line();
            this.Line69 = new DataDynamics.ActiveReports.Line();
            this.Line70 = new DataDynamics.ActiveReports.Line();
            this.txtPolicyNumber1 = new DataDynamics.ActiveReports.TextBox();
            this.txtReceived1 = new DataDynamics.ActiveReports.TextBox();
            this.Line71 = new DataDynamics.ActiveReports.Line();
            this.Line72 = new DataDynamics.ActiveReports.Line();
            this.txtNumber1 = new DataDynamics.ActiveReports.TextBox();
            this.Line73 = new DataDynamics.ActiveReports.Line();
            this.Label137 = new DataDynamics.ActiveReports.Label();
            this.Line74 = new DataDynamics.ActiveReports.Line();
            this.Line75 = new DataDynamics.ActiveReports.Line();
            this.Line76 = new DataDynamics.ActiveReports.Line();
            this.Line77 = new DataDynamics.ActiveReports.Line();
            this.Line78 = new DataDynamics.ActiveReports.Line();
            this.Line79 = new DataDynamics.ActiveReports.Line();
            this.Line80 = new DataDynamics.ActiveReports.Line();
            this.Line81 = new DataDynamics.ActiveReports.Line();
            this.Line82 = new DataDynamics.ActiveReports.Line();
            this.Line83 = new DataDynamics.ActiveReports.Line();
            this.Line84 = new DataDynamics.ActiveReports.Line();
            this.Line85 = new DataDynamics.ActiveReports.Line();
            this.Label138 = new DataDynamics.ActiveReports.Label();
            this.Label139 = new DataDynamics.ActiveReports.Label();
            this.lblDate2 = new DataDynamics.ActiveReports.Label();
            this.lblTime2 = new DataDynamics.ActiveReports.Label();
            this.Label146 = new DataDynamics.ActiveReports.Label();
            this.Line86 = new DataDynamics.ActiveReports.Line();
            this.Line87 = new DataDynamics.ActiveReports.Line();
            this.LblPolicyClass3 = new DataDynamics.ActiveReports.Label();
            this.Shape9 = new DataDynamics.ActiveReports.Shape();
            this.Line88 = new DataDynamics.ActiveReports.Line();
            this.Line89 = new DataDynamics.ActiveReports.Line();
            this.Label149 = new DataDynamics.ActiveReports.Label();
            this.Label150 = new DataDynamics.ActiveReports.Label();
            this.Label151 = new DataDynamics.ActiveReports.Label();
            this.txtName2 = new DataDynamics.ActiveReports.TextBox();
            this.txtPayment2 = new DataDynamics.ActiveReports.TextBox();
            this.txtPaid2 = new DataDynamics.ActiveReports.TextBox();
            this.Label152 = new DataDynamics.ActiveReports.Label();
            this.Label153 = new DataDynamics.ActiveReports.Label();
            this.Label154 = new DataDynamics.ActiveReports.Label();
            this.Label155 = new DataDynamics.ActiveReports.Label();
            this.txtCustomer2 = new DataDynamics.ActiveReports.TextBox();
            this.txtProducer2 = new DataDynamics.ActiveReports.TextBox();
            this.Line91 = new DataDynamics.ActiveReports.Line();
            this.Line92 = new DataDynamics.ActiveReports.Line();
            this.Line93 = new DataDynamics.ActiveReports.Line();
            this.txtPolicyNumber2 = new DataDynamics.ActiveReports.TextBox();
            this.txtReceived2 = new DataDynamics.ActiveReports.TextBox();
            this.Line94 = new DataDynamics.ActiveReports.Line();
            this.Line95 = new DataDynamics.ActiveReports.Line();
            this.txtNumber2 = new DataDynamics.ActiveReports.TextBox();
            this.Line96 = new DataDynamics.ActiveReports.Line();
            this.Label156 = new DataDynamics.ActiveReports.Label();
            this.Line98 = new DataDynamics.ActiveReports.Line();
            this.Line99 = new DataDynamics.ActiveReports.Line();
            this.Line100 = new DataDynamics.ActiveReports.Line();
            this.Line101 = new DataDynamics.ActiveReports.Line();
            this.Line102 = new DataDynamics.ActiveReports.Line();
            this.Line103 = new DataDynamics.ActiveReports.Line();
            this.Line104 = new DataDynamics.ActiveReports.Line();
            this.Line106 = new DataDynamics.ActiveReports.Line();
            this.Line107 = new DataDynamics.ActiveReports.Line();
            this.Line108 = new DataDynamics.ActiveReports.Line();
            this.Label157 = new DataDynamics.ActiveReports.Label();
            this.Label158 = new DataDynamics.ActiveReports.Label();
            this.Line109 = new DataDynamics.ActiveReports.Line();
            this.Line110 = new DataDynamics.ActiveReports.Line();
            this.Line111 = new DataDynamics.ActiveReports.Line();
            this.Line112 = new DataDynamics.ActiveReports.Line();
            this.Line90 = new DataDynamics.ActiveReports.Line();
            this.LblTaskControlID = new DataDynamics.ActiveReports.Label();
            this.LblTaskControl1ID = new DataDynamics.ActiveReports.Label();
            this.LblTaskControl2ID = new DataDynamics.ActiveReports.Label();
            this.Label75 = new DataDynamics.ActiveReports.Label();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.Label159)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label140)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label121)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPolicyNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblPolicyClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label114)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label115)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label116)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label117)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProducer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceived)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label118)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label119)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label120)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label127)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblPolicyClass2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayment1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label136)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProducer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPolicyNumber1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceived1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label137)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label138)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label139)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label146)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblPolicyClass3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label149)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label150)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label151)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayment2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label152)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label153)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label154)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label155)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProducer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPolicyNumber2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceived2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label156)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label157)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label158)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblTaskControlID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblTaskControl1ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblTaskControl2ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Height = 0F;
            this.Detail.Name = "Detail";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Shape11,
            this.Shape8,
            this.Label159,
            this.Label140,
            this.Shape3,
            this.Label121,
            this.txtPolicyNumber,
            this.Shape10,
            this.Shape7,
            this.Shape5,
            this.lblDate,
            this.lblTime,
            this.lblCriterias,
            this.Line11,
            this.Line14,
            this.LblPolicyClass,
            this.Shape4,
            this.Line18,
            this.Line19,
            this.Label7,
            this.Label108,
            this.Label109,
            this.txtName,
            this.txtPayment,
            this.txtPaid,
            this.Label114,
            this.Label115,
            this.Label116,
            this.Label117,
            this.txtCustomer,
            this.txtProducer,
            this.Line24,
            this.Line25,
            this.Line26,
            this.Line27,
            this.txtReceived,
            this.Line28,
            this.Line29,
            this.txtNumber,
            this.Line30,
            this.Label118,
            this.Line31,
            this.Line32,
            this.Line33,
            this.Line36,
            this.Line44,
            this.Line49,
            this.Line57,
            this.Line46,
            this.Line38,
            this.Line59,
            this.Line60,
            this.Line61,
            this.Line62,
            this.Label119,
            this.Label120,
            this.lblDate1,
            this.lblTime1,
            this.Label127,
            this.Line63,
            this.Line64,
            this.LblPolicyClass2,
            this.Shape6,
            this.Line65,
            this.Line66,
            this.Label130,
            this.Label131,
            this.Label132,
            this.txtName1,
            this.txtPayment1,
            this.txtPaid1,
            this.Label133,
            this.Label134,
            this.Label135,
            this.Label136,
            this.txtCustomer1,
            this.txtProducer1,
            this.Line68,
            this.Line69,
            this.Line70,
            this.txtPolicyNumber1,
            this.txtReceived1,
            this.Line71,
            this.Line72,
            this.txtNumber1,
            this.Line73,
            this.Label137,
            this.Line74,
            this.Line75,
            this.Line76,
            this.Line77,
            this.Line78,
            this.Line79,
            this.Line80,
            this.Line81,
            this.Line82,
            this.Line83,
            this.Line84,
            this.Line85,
            this.Label138,
            this.Label139,
            this.lblDate2,
            this.lblTime2,
            this.Label146,
            this.Line86,
            this.Line87,
            this.LblPolicyClass3,
            this.Shape9,
            this.Line88,
            this.Line89,
            this.Label149,
            this.Label150,
            this.Label151,
            this.txtName2,
            this.txtPayment2,
            this.txtPaid2,
            this.Label152,
            this.Label153,
            this.Label154,
            this.Label155,
            this.txtCustomer2,
            this.txtProducer2,
            this.Line91,
            this.Line92,
            this.Line93,
            this.txtPolicyNumber2,
            this.txtReceived2,
            this.Line94,
            this.Line95,
            this.txtNumber2,
            this.Line96,
            this.Label156,
            this.Line98,
            this.Line99,
            this.Line100,
            this.Line101,
            this.Line102,
            this.Line103,
            this.Line104,
            this.Line106,
            this.Line107,
            this.Line108,
            this.Label157,
            this.Label158,
            this.Line109,
            this.Line110,
            this.Line111,
            this.Line112,
            this.Line90,
            this.LblTaskControlID,
            this.LblTaskControl1ID,
            this.LblTaskControl2ID,
            this.Label75,
            this.Label,
            this.Label2});
            this.PageHeader.Height = 9.84375F;
            this.PageHeader.Name = "PageHeader";
            // 
            // Shape11
            // 
            this.Shape11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(227)))), ((int)(((byte)(234)))));
            this.Shape11.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape11.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape11.Border.RightColor = System.Drawing.Color.Black;
            this.Shape11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape11.Border.TopColor = System.Drawing.Color.Black;
            this.Shape11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape11.Height = 0.3125F;
            this.Shape11.Left = 5.1875F;
            this.Shape11.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Shape11.Name = "Shape11";
            this.Shape11.RoundingRadius = 9.999999F;
            this.Shape11.Top = 7.625F;
            this.Shape11.Width = 2.625F;
            // 
            // Shape8
            // 
            this.Shape8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(227)))), ((int)(((byte)(234)))));
            this.Shape8.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape8.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape8.Border.RightColor = System.Drawing.Color.Black;
            this.Shape8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape8.Border.TopColor = System.Drawing.Color.Black;
            this.Shape8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape8.Height = 0.3125F;
            this.Shape8.Left = 5.25F;
            this.Shape8.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Shape8.Name = "Shape8";
            this.Shape8.RoundingRadius = 9.999999F;
            this.Shape8.Top = 4.25F;
            this.Shape8.Width = 2.625F;
            // 
            // Label159
            // 
            this.Label159.Border.BottomColor = System.Drawing.Color.Black;
            this.Label159.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label159.Border.LeftColor = System.Drawing.Color.Black;
            this.Label159.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label159.Border.RightColor = System.Drawing.Color.Black;
            this.Label159.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label159.Border.TopColor = System.Drawing.Color.Black;
            this.Label159.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label159.Height = 0.1875F;
            this.Label159.HyperLink = "";
            this.Label159.Left = 7F;
            this.Label159.MultiLine = false;
            this.Label159.Name = "Label159";
            this.Label159.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label159.Text = "RECEIPT NO.";
            this.Label159.Top = 7.6875F;
            this.Label159.Width = 0.8125F;
            // 
            // Label140
            // 
            this.Label140.Border.BottomColor = System.Drawing.Color.Black;
            this.Label140.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label140.Border.LeftColor = System.Drawing.Color.Black;
            this.Label140.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label140.Border.RightColor = System.Drawing.Color.Black;
            this.Label140.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label140.Border.TopColor = System.Drawing.Color.Black;
            this.Label140.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label140.Height = 0.1875F;
            this.Label140.HyperLink = "";
            this.Label140.Left = 7.0625F;
            this.Label140.MultiLine = false;
            this.Label140.Name = "Label140";
            this.Label140.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label140.Text = "RECEIPT NO.";
            this.Label140.Top = 4.3125F;
            this.Label140.Width = 0.8125F;
            // 
            // Shape3
            // 
            this.Shape3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(227)))), ((int)(((byte)(234)))));
            this.Shape3.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.RightColor = System.Drawing.Color.Black;
            this.Shape3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.TopColor = System.Drawing.Color.Black;
            this.Shape3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Height = 0.3125F;
            this.Shape3.Left = 5.3125F;
            this.Shape3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Shape3.Name = "Shape3";
            this.Shape3.RoundingRadius = 9.999999F;
            this.Shape3.Top = 0.8125F;
            this.Shape3.Width = 2.625F;
            // 
            // Label121
            // 
            this.Label121.Border.BottomColor = System.Drawing.Color.Black;
            this.Label121.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label121.Border.LeftColor = System.Drawing.Color.Black;
            this.Label121.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label121.Border.RightColor = System.Drawing.Color.Black;
            this.Label121.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label121.Border.TopColor = System.Drawing.Color.Black;
            this.Label121.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label121.Height = 0.1875F;
            this.Label121.HyperLink = "";
            this.Label121.Left = 7.125F;
            this.Label121.MultiLine = false;
            this.Label121.Name = "Label121";
            this.Label121.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label121.Text = "RECEIPT NO.";
            this.Label121.Top = 0.875F;
            this.Label121.Width = 0.8125F;
            // 
            // txtPolicyNumber
            // 
            this.txtPolicyNumber.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPolicyNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyNumber.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPolicyNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyNumber.Border.RightColor = System.Drawing.Color.Black;
            this.txtPolicyNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyNumber.Border.TopColor = System.Drawing.Color.Black;
            this.txtPolicyNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyNumber.Height = 0.1875F;
            this.txtPolicyNumber.Left = 0.75F;
            this.txtPolicyNumber.MultiLine = false;
            this.txtPolicyNumber.Name = "txtPolicyNumber";
            this.txtPolicyNumber.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtPolicyNumber.Text = "txtPolicyNumber";
            this.txtPolicyNumber.Top = 1.8125F;
            this.txtPolicyNumber.Width = 2.375F;
            // 
            // Shape10
            // 
            this.Shape10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(227)))), ((int)(((byte)(234)))));
            this.Shape10.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape10.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape10.Border.RightColor = System.Drawing.Color.Black;
            this.Shape10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape10.Border.TopColor = System.Drawing.Color.Black;
            this.Shape10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape10.Height = 0.25F;
            this.Shape10.Left = 0.5F;
            this.Shape10.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Shape10.Name = "Shape10";
            this.Shape10.RoundingRadius = 9.999999F;
            this.Shape10.Top = 8.8125F;
            this.Shape10.Width = 7.3125F;
            // 
            // Shape7
            // 
            this.Shape7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(227)))), ((int)(((byte)(234)))));
            this.Shape7.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape7.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape7.Border.RightColor = System.Drawing.Color.Black;
            this.Shape7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape7.Border.TopColor = System.Drawing.Color.Black;
            this.Shape7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape7.Height = 0.25F;
            this.Shape7.Left = 0.5625F;
            this.Shape7.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Shape7.Name = "Shape7";
            this.Shape7.RoundingRadius = 9.999999F;
            this.Shape7.Top = 5.4375F;
            this.Shape7.Width = 7.3125F;
            // 
            // Shape5
            // 
            this.Shape5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(227)))), ((int)(((byte)(234)))));
            this.Shape5.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape5.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape5.Border.RightColor = System.Drawing.Color.Black;
            this.Shape5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape5.Border.TopColor = System.Drawing.Color.Black;
            this.Shape5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape5.Height = 0.25F;
            this.Shape5.Left = 0.625F;
            this.Shape5.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Shape5.Name = "Shape5";
            this.Shape5.RoundingRadius = 9.999999F;
            this.Shape5.Top = 2F;
            this.Shape5.Width = 7.3125F;
            // 
            // lblDate
            // 
            this.lblDate.Border.BottomColor = System.Drawing.Color.Black;
            this.lblDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDate.Border.LeftColor = System.Drawing.Color.Black;
            this.lblDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDate.Border.RightColor = System.Drawing.Color.Black;
            this.lblDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDate.Border.TopColor = System.Drawing.Color.Black;
            this.lblDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDate.Height = 0.2F;
            this.lblDate.HyperLink = "";
            this.lblDate.Left = 5.3125F;
            this.lblDate.Name = "lblDate";
            this.lblDate.Style = "text-align: center; font-size: 8pt; ";
            this.lblDate.Text = "lblDate";
            this.lblDate.Top = 1.125F;
            this.lblDate.Width = 0.9090909F;
            // 
            // lblTime
            // 
            this.lblTime.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTime.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTime.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTime.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTime.Border.RightColor = System.Drawing.Color.Black;
            this.lblTime.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTime.Border.TopColor = System.Drawing.Color.Black;
            this.lblTime.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTime.Height = 0.2F;
            this.lblTime.HyperLink = "";
            this.lblTime.Left = 6.1875F;
            this.lblTime.Name = "lblTime";
            this.lblTime.Style = "text-align: center; font-size: 8pt; ";
            this.lblTime.Text = "lblTime";
            this.lblTime.Top = 1.125F;
            this.lblTime.Width = 0.9090909F;
            // 
            // lblCriterias
            // 
            this.lblCriterias.Border.BottomColor = System.Drawing.Color.Black;
            this.lblCriterias.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCriterias.Border.LeftColor = System.Drawing.Color.Black;
            this.lblCriterias.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCriterias.Border.RightColor = System.Drawing.Color.Black;
            this.lblCriterias.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCriterias.Border.TopColor = System.Drawing.Color.Black;
            this.lblCriterias.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCriterias.Height = 0.1875F;
            this.lblCriterias.HyperLink = "";
            this.lblCriterias.Left = 3.1875F;
            this.lblCriterias.MultiLine = false;
            this.lblCriterias.Name = "lblCriterias";
            this.lblCriterias.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.lblCriterias.Text = "RECEIPT";
            this.lblCriterias.Top = 1F;
            this.lblCriterias.Width = 1.6875F;
            // 
            // Line11
            // 
            this.Line11.Border.BottomColor = System.Drawing.Color.Black;
            this.Line11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11.Border.LeftColor = System.Drawing.Color.Black;
            this.Line11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11.Border.RightColor = System.Drawing.Color.Black;
            this.Line11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11.Border.TopColor = System.Drawing.Color.Black;
            this.Line11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11.Height = 0F;
            this.Line11.Left = 5.3125F;
            this.Line11.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line11.LineWeight = 1F;
            this.Line11.Name = "Line11";
            this.Line11.Top = 0.8125F;
            this.Line11.Width = 2.625F;
            this.Line11.X1 = 5.3125F;
            this.Line11.X2 = 7.9375F;
            this.Line11.Y1 = 0.8125F;
            this.Line11.Y2 = 0.8125F;
            // 
            // Line14
            // 
            this.Line14.Border.BottomColor = System.Drawing.Color.Black;
            this.Line14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14.Border.LeftColor = System.Drawing.Color.Black;
            this.Line14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14.Border.RightColor = System.Drawing.Color.Black;
            this.Line14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14.Border.TopColor = System.Drawing.Color.Black;
            this.Line14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14.Height = 0.5F;
            this.Line14.Left = 6.1875F;
            this.Line14.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line14.LineWeight = 1F;
            this.Line14.Name = "Line14";
            this.Line14.Top = 0.8125F;
            this.Line14.Width = 0F;
            this.Line14.X1 = 6.1875F;
            this.Line14.X2 = 6.1875F;
            this.Line14.Y1 = 1.3125F;
            this.Line14.Y2 = 0.8125F;
            // 
            // LblPolicyClass
            // 
            this.LblPolicyClass.Border.BottomColor = System.Drawing.Color.Black;
            this.LblPolicyClass.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblPolicyClass.Border.LeftColor = System.Drawing.Color.Black;
            this.LblPolicyClass.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblPolicyClass.Border.RightColor = System.Drawing.Color.Black;
            this.LblPolicyClass.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblPolicyClass.Border.TopColor = System.Drawing.Color.Black;
            this.LblPolicyClass.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblPolicyClass.Height = 0.2F;
            this.LblPolicyClass.HyperLink = "";
            this.LblPolicyClass.Left = 0.625F;
            this.LblPolicyClass.Name = "LblPolicyClass";
            this.LblPolicyClass.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.LblPolicyClass.Text = "Auto";
            this.LblPolicyClass.Top = 1.25F;
            this.LblPolicyClass.Width = 1.5625F;
            // 
            // Shape4
            // 
            this.Shape4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(227)))), ((int)(((byte)(234)))));
            this.Shape4.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape4.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape4.Border.RightColor = System.Drawing.Color.Black;
            this.Shape4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape4.Border.TopColor = System.Drawing.Color.Black;
            this.Shape4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape4.Height = 0.25F;
            this.Shape4.Left = 0.625F;
            this.Shape4.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Shape4.Name = "Shape4";
            this.Shape4.RoundingRadius = 9.999999F;
            this.Shape4.Top = 1.5F;
            this.Shape4.Width = 7.3125F;
            // 
            // Line18
            // 
            this.Line18.Border.BottomColor = System.Drawing.Color.Black;
            this.Line18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line18.Border.LeftColor = System.Drawing.Color.Black;
            this.Line18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line18.Border.RightColor = System.Drawing.Color.Black;
            this.Line18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line18.Border.TopColor = System.Drawing.Color.Black;
            this.Line18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line18.Height = 0F;
            this.Line18.Left = 0.625F;
            this.Line18.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line18.LineWeight = 1F;
            this.Line18.Name = "Line18";
            this.Line18.Top = 1.5F;
            this.Line18.Width = 7.3125F;
            this.Line18.X1 = 0.625F;
            this.Line18.X2 = 7.9375F;
            this.Line18.Y1 = 1.5F;
            this.Line18.Y2 = 1.5F;
            // 
            // Line19
            // 
            this.Line19.Border.BottomColor = System.Drawing.Color.Black;
            this.Line19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line19.Border.LeftColor = System.Drawing.Color.Black;
            this.Line19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line19.Border.RightColor = System.Drawing.Color.Black;
            this.Line19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line19.Border.TopColor = System.Drawing.Color.Black;
            this.Line19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line19.Height = 0F;
            this.Line19.Left = 0.625F;
            this.Line19.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line19.LineWeight = 1F;
            this.Line19.Name = "Line19";
            this.Line19.Top = 2F;
            this.Line19.Width = 7.3125F;
            this.Line19.X1 = 0.625F;
            this.Line19.X2 = 7.9375F;
            this.Line19.Y1 = 2F;
            this.Line19.Y2 = 2F;
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
            this.Label7.Height = 0.1875F;
            this.Label7.HyperLink = "";
            this.Label7.Left = 3.3125F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label7.Text = "NAME";
            this.Label7.Top = 1.5625F;
            this.Label7.Width = 1F;
            // 
            // Label108
            // 
            this.Label108.Border.BottomColor = System.Drawing.Color.Black;
            this.Label108.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label108.Border.LeftColor = System.Drawing.Color.Black;
            this.Label108.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label108.Border.RightColor = System.Drawing.Color.Black;
            this.Label108.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label108.Border.TopColor = System.Drawing.Color.Black;
            this.Label108.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label108.Height = 0.1375001F;
            this.Label108.HyperLink = "";
            this.Label108.Left = 3.3125F;
            this.Label108.Name = "Label108";
            this.Label108.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label108.Text = "CHECK NO.";
            this.Label108.Top = 2.05F;
            this.Label108.Width = 1.1875F;
            // 
            // Label109
            // 
            this.Label109.Border.BottomColor = System.Drawing.Color.Black;
            this.Label109.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Border.LeftColor = System.Drawing.Color.Black;
            this.Label109.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Border.RightColor = System.Drawing.Color.Black;
            this.Label109.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Border.TopColor = System.Drawing.Color.Black;
            this.Label109.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Height = 0.2F;
            this.Label109.HyperLink = "";
            this.Label109.Left = 6.25F;
            this.Label109.Name = "Label109";
            this.Label109.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label109.Text = "PAID AMOUNT";
            this.Label109.Top = 1.5625F;
            this.Label109.Width = 1F;
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
            this.txtName.Left = 3.3125F;
            this.txtName.MultiLine = false;
            this.txtName.Name = "txtName";
            this.txtName.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtName.Text = "txtName";
            this.txtName.Top = 1.8125F;
            this.txtName.Width = 2.375F;
            // 
            // txtPayment
            // 
            this.txtPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPayment.Border.RightColor = System.Drawing.Color.Black;
            this.txtPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPayment.Border.TopColor = System.Drawing.Color.Black;
            this.txtPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPayment.Height = 0.2F;
            this.txtPayment.Left = 3.3125F;
            this.txtPayment.MultiLine = false;
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtPayment.Text = "txtPayment";
            this.txtPayment.Top = 2.3625F;
            this.txtPayment.Width = 2F;
            // 
            // txtPaid
            // 
            this.txtPaid.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPaid.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPaid.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPaid.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPaid.Border.RightColor = System.Drawing.Color.Black;
            this.txtPaid.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPaid.Border.TopColor = System.Drawing.Color.Black;
            this.txtPaid.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPaid.Height = 0.2F;
            this.txtPaid.Left = 6.25F;
            this.txtPaid.MultiLine = false;
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.OutputFormat = resources.GetString("txtPaid.OutputFormat");
            this.txtPaid.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtPaid.Text = "txtPaid";
            this.txtPaid.Top = 1.8125F;
            this.txtPaid.Width = 1.25F;
            // 
            // Label114
            // 
            this.Label114.Border.BottomColor = System.Drawing.Color.Black;
            this.Label114.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label114.Border.LeftColor = System.Drawing.Color.Black;
            this.Label114.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label114.Border.RightColor = System.Drawing.Color.Black;
            this.Label114.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label114.Border.TopColor = System.Drawing.Color.Black;
            this.Label114.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label114.Height = 0.125F;
            this.Label114.HyperLink = "";
            this.Label114.Left = 0.75F;
            this.Label114.Name = "Label114";
            this.Label114.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label114.Text = " CUSTOMER";
            this.Label114.Top = 2.0625F;
            this.Label114.Width = 1F;
            // 
            // Label115
            // 
            this.Label115.Border.BottomColor = System.Drawing.Color.Black;
            this.Label115.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label115.Border.LeftColor = System.Drawing.Color.Black;
            this.Label115.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label115.Border.RightColor = System.Drawing.Color.Black;
            this.Label115.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label115.Border.TopColor = System.Drawing.Color.Black;
            this.Label115.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label115.Height = 0.125F;
            this.Label115.HyperLink = "";
            this.Label115.Left = 2F;
            this.Label115.Name = "Label115";
            this.Label115.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label115.Text = " PRODUCER";
            this.Label115.Top = 2.0625F;
            this.Label115.Width = 1F;
            // 
            // Label116
            // 
            this.Label116.Border.BottomColor = System.Drawing.Color.Black;
            this.Label116.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label116.Border.LeftColor = System.Drawing.Color.Black;
            this.Label116.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label116.Border.RightColor = System.Drawing.Color.Black;
            this.Label116.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label116.Border.TopColor = System.Drawing.Color.Black;
            this.Label116.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label116.Height = 0.125F;
            this.Label116.HyperLink = "";
            this.Label116.Left = 0.75F;
            this.Label116.Name = "Label116";
            this.Label116.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label116.Text = "POLICY NUMBER";
            this.Label116.Top = 1.5625F;
            this.Label116.Width = 1.375F;
            // 
            // Label117
            // 
            this.Label117.Border.BottomColor = System.Drawing.Color.Black;
            this.Label117.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label117.Border.LeftColor = System.Drawing.Color.Black;
            this.Label117.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label117.Border.RightColor = System.Drawing.Color.Black;
            this.Label117.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label117.Border.TopColor = System.Drawing.Color.Black;
            this.Label117.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label117.Height = 0.1875F;
            this.Label117.HyperLink = "";
            this.Label117.Left = 5.75F;
            this.Label117.Name = "Label117";
            this.Label117.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label117.Text = " RECEIVED BY";
            this.Label117.Top = 2.0625F;
            this.Label117.Width = 1F;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCustomer.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomer.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCustomer.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomer.Border.RightColor = System.Drawing.Color.Black;
            this.txtCustomer.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomer.Border.TopColor = System.Drawing.Color.Black;
            this.txtCustomer.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomer.Height = 0.1875F;
            this.txtCustomer.Left = 0.75F;
            this.txtCustomer.MultiLine = false;
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtCustomer.Text = "txtCustomer";
            this.txtCustomer.Top = 2.375F;
            this.txtCustomer.Width = 1.125F;
            // 
            // txtProducer
            // 
            this.txtProducer.Border.BottomColor = System.Drawing.Color.Black;
            this.txtProducer.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProducer.Border.LeftColor = System.Drawing.Color.Black;
            this.txtProducer.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProducer.Border.RightColor = System.Drawing.Color.Black;
            this.txtProducer.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProducer.Border.TopColor = System.Drawing.Color.Black;
            this.txtProducer.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProducer.Height = 0.1875F;
            this.txtProducer.Left = 2.0625F;
            this.txtProducer.MultiLine = false;
            this.txtProducer.Name = "txtProducer";
            this.txtProducer.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtProducer.Text = "txtProducer";
            this.txtProducer.Top = 2.375F;
            this.txtProducer.Width = 1.125F;
            // 
            // Line24
            // 
            this.Line24.Border.BottomColor = System.Drawing.Color.Black;
            this.Line24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line24.Border.LeftColor = System.Drawing.Color.Black;
            this.Line24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line24.Border.RightColor = System.Drawing.Color.Black;
            this.Line24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line24.Border.TopColor = System.Drawing.Color.Black;
            this.Line24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line24.Height = 1.0625F;
            this.Line24.Left = 3.25F;
            this.Line24.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line24.LineWeight = 1F;
            this.Line24.Name = "Line24";
            this.Line24.Top = 1.5F;
            this.Line24.Width = 0F;
            this.Line24.X1 = 3.25F;
            this.Line24.X2 = 3.25F;
            this.Line24.Y1 = 2.5625F;
            this.Line24.Y2 = 1.5F;
            // 
            // Line25
            // 
            this.Line25.Border.BottomColor = System.Drawing.Color.Black;
            this.Line25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line25.Border.LeftColor = System.Drawing.Color.Black;
            this.Line25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line25.Border.RightColor = System.Drawing.Color.Black;
            this.Line25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line25.Border.TopColor = System.Drawing.Color.Black;
            this.Line25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line25.Height = 0.5625F;
            this.Line25.Left = 2F;
            this.Line25.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line25.LineWeight = 1F;
            this.Line25.Name = "Line25";
            this.Line25.Top = 2F;
            this.Line25.Width = 0F;
            this.Line25.X1 = 2F;
            this.Line25.X2 = 2F;
            this.Line25.Y1 = 2.5625F;
            this.Line25.Y2 = 2F;
            // 
            // Line26
            // 
            this.Line26.Border.BottomColor = System.Drawing.Color.Black;
            this.Line26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line26.Border.LeftColor = System.Drawing.Color.Black;
            this.Line26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line26.Border.RightColor = System.Drawing.Color.Black;
            this.Line26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line26.Border.TopColor = System.Drawing.Color.Black;
            this.Line26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line26.Height = 0.5625F;
            this.Line26.Left = 5.75F;
            this.Line26.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line26.LineWeight = 1F;
            this.Line26.Name = "Line26";
            this.Line26.Top = 2F;
            this.Line26.Width = 0F;
            this.Line26.X1 = 5.75F;
            this.Line26.X2 = 5.75F;
            this.Line26.Y1 = 2.5625F;
            this.Line26.Y2 = 2F;
            // 
            // Line27
            // 
            this.Line27.Border.BottomColor = System.Drawing.Color.Black;
            this.Line27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line27.Border.LeftColor = System.Drawing.Color.Black;
            this.Line27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line27.Border.RightColor = System.Drawing.Color.Black;
            this.Line27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line27.Border.TopColor = System.Drawing.Color.Black;
            this.Line27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line27.Height = 1.0625F;
            this.Line27.Left = 7.9375F;
            this.Line27.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line27.LineWeight = 1F;
            this.Line27.Name = "Line27";
            this.Line27.Top = 1.5F;
            this.Line27.Width = 0F;
            this.Line27.X1 = 7.9375F;
            this.Line27.X2 = 7.9375F;
            this.Line27.Y1 = 2.5625F;
            this.Line27.Y2 = 1.5F;
            // 
            // txtReceived
            // 
            this.txtReceived.Border.BottomColor = System.Drawing.Color.Black;
            this.txtReceived.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReceived.Border.LeftColor = System.Drawing.Color.Black;
            this.txtReceived.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReceived.Border.RightColor = System.Drawing.Color.Black;
            this.txtReceived.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReceived.Border.TopColor = System.Drawing.Color.Black;
            this.txtReceived.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReceived.Height = 0.1875F;
            this.txtReceived.Left = 5.8125F;
            this.txtReceived.MultiLine = false;
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtReceived.Text = "txtReceived";
            this.txtReceived.Top = 2.375F;
            this.txtReceived.Width = 2.0625F;
            // 
            // Line28
            // 
            this.Line28.Border.BottomColor = System.Drawing.Color.Black;
            this.Line28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line28.Border.LeftColor = System.Drawing.Color.Black;
            this.Line28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line28.Border.RightColor = System.Drawing.Color.Black;
            this.Line28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line28.Border.TopColor = System.Drawing.Color.Black;
            this.Line28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line28.Height = 0F;
            this.Line28.Left = 0.625F;
            this.Line28.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line28.LineWeight = 1F;
            this.Line28.Name = "Line28";
            this.Line28.Top = 2.5625F;
            this.Line28.Width = 7.3125F;
            this.Line28.X1 = 0.625F;
            this.Line28.X2 = 7.9375F;
            this.Line28.Y1 = 2.5625F;
            this.Line28.Y2 = 2.5625F;
            // 
            // Line29
            // 
            this.Line29.Border.BottomColor = System.Drawing.Color.Black;
            this.Line29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line29.Border.LeftColor = System.Drawing.Color.Black;
            this.Line29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line29.Border.RightColor = System.Drawing.Color.Black;
            this.Line29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line29.Border.TopColor = System.Drawing.Color.Black;
            this.Line29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line29.Height = 1.0625F;
            this.Line29.Left = 0.625F;
            this.Line29.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line29.LineWeight = 1F;
            this.Line29.Name = "Line29";
            this.Line29.Top = 1.5F;
            this.Line29.Width = 0F;
            this.Line29.X1 = 0.625F;
            this.Line29.X2 = 0.625F;
            this.Line29.Y1 = 2.5625F;
            this.Line29.Y2 = 1.5F;
            // 
            // txtNumber
            // 
            this.txtNumber.Border.BottomColor = System.Drawing.Color.Black;
            this.txtNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumber.Border.LeftColor = System.Drawing.Color.Black;
            this.txtNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumber.Border.RightColor = System.Drawing.Color.Black;
            this.txtNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumber.Border.TopColor = System.Drawing.Color.Black;
            this.txtNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumber.Height = 0.1875F;
            this.txtNumber.Left = 7.125F;
            this.txtNumber.MultiLine = false;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.txtNumber.Text = "txtNumber";
            this.txtNumber.Top = 1.125F;
            this.txtNumber.Width = 0.75F;
            // 
            // Line30
            // 
            this.Line30.Border.BottomColor = System.Drawing.Color.Black;
            this.Line30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line30.Border.LeftColor = System.Drawing.Color.Black;
            this.Line30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line30.Border.RightColor = System.Drawing.Color.Black;
            this.Line30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line30.Border.TopColor = System.Drawing.Color.Black;
            this.Line30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line30.Height = 0F;
            this.Line30.Left = 5.3125F;
            this.Line30.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line30.LineWeight = 1F;
            this.Line30.Name = "Line30";
            this.Line30.Top = 1.3125F;
            this.Line30.Width = 2.625F;
            this.Line30.X1 = 5.3125F;
            this.Line30.X2 = 7.9375F;
            this.Line30.Y1 = 1.3125F;
            this.Line30.Y2 = 1.3125F;
            // 
            // Label118
            // 
            this.Label118.Border.BottomColor = System.Drawing.Color.Black;
            this.Label118.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label118.Border.LeftColor = System.Drawing.Color.Black;
            this.Label118.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label118.Border.RightColor = System.Drawing.Color.Black;
            this.Label118.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label118.Border.TopColor = System.Drawing.Color.Black;
            this.Label118.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label118.Height = 0.1875F;
            this.Label118.HyperLink = "";
            this.Label118.Left = 0.625F;
            this.Label118.MultiLine = false;
            this.Label118.Name = "Label118";
            this.Label118.Style = "text-align: left; font-weight: bold; font-size: 9.75pt; ";
            this.Label118.Text = "ACCOUNTING";
            this.Label118.Top = 2.6875F;
            this.Label118.Width = 1.6875F;
            // 
            // Line31
            // 
            this.Line31.Border.BottomColor = System.Drawing.Color.Black;
            this.Line31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line31.Border.LeftColor = System.Drawing.Color.Black;
            this.Line31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line31.Border.RightColor = System.Drawing.Color.Black;
            this.Line31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line31.Border.TopColor = System.Drawing.Color.Black;
            this.Line31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line31.Height = 0F;
            this.Line31.Left = 0.4444444F;
            this.Line31.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line31.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
            this.Line31.LineWeight = 1F;
            this.Line31.Name = "Line31";
            this.Line31.Top = 3.194444F;
            this.Line31.Width = 7.6875F;
            this.Line31.X1 = 0.4444444F;
            this.Line31.X2 = 8.131945F;
            this.Line31.Y1 = 3.194444F;
            this.Line31.Y2 = 3.194444F;
            // 
            // Line32
            // 
            this.Line32.Border.BottomColor = System.Drawing.Color.Black;
            this.Line32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line32.Border.LeftColor = System.Drawing.Color.Black;
            this.Line32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line32.Border.RightColor = System.Drawing.Color.Black;
            this.Line32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line32.Border.TopColor = System.Drawing.Color.Black;
            this.Line32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line32.Height = 0F;
            this.Line32.Left = 5.3125F;
            this.Line32.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line32.LineWeight = 1F;
            this.Line32.Name = "Line32";
            this.Line32.Top = 0.8125F;
            this.Line32.Width = 2.625F;
            this.Line32.X1 = 5.3125F;
            this.Line32.X2 = 7.9375F;
            this.Line32.Y1 = 0.8125F;
            this.Line32.Y2 = 0.8125F;
            // 
            // Line33
            // 
            this.Line33.Border.BottomColor = System.Drawing.Color.Black;
            this.Line33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line33.Border.LeftColor = System.Drawing.Color.Black;
            this.Line33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line33.Border.RightColor = System.Drawing.Color.Black;
            this.Line33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line33.Border.TopColor = System.Drawing.Color.Black;
            this.Line33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line33.Height = 0.5F;
            this.Line33.Left = 6.1875F;
            this.Line33.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line33.LineWeight = 1F;
            this.Line33.Name = "Line33";
            this.Line33.Top = 0.8125F;
            this.Line33.Width = 0F;
            this.Line33.X1 = 6.1875F;
            this.Line33.X2 = 6.1875F;
            this.Line33.Y1 = 1.3125F;
            this.Line33.Y2 = 0.8125F;
            // 
            // Line36
            // 
            this.Line36.Border.BottomColor = System.Drawing.Color.Black;
            this.Line36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line36.Border.LeftColor = System.Drawing.Color.Black;
            this.Line36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line36.Border.RightColor = System.Drawing.Color.Black;
            this.Line36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line36.Border.TopColor = System.Drawing.Color.Black;
            this.Line36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line36.Height = 0F;
            this.Line36.Left = 0.625F;
            this.Line36.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line36.LineWeight = 1F;
            this.Line36.Name = "Line36";
            this.Line36.Top = 1.5F;
            this.Line36.Width = 7.3125F;
            this.Line36.X1 = 0.625F;
            this.Line36.X2 = 7.9375F;
            this.Line36.Y1 = 1.5F;
            this.Line36.Y2 = 1.5F;
            // 
            // Line44
            // 
            this.Line44.Border.BottomColor = System.Drawing.Color.Black;
            this.Line44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Border.LeftColor = System.Drawing.Color.Black;
            this.Line44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Border.RightColor = System.Drawing.Color.Black;
            this.Line44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Border.TopColor = System.Drawing.Color.Black;
            this.Line44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Height = 0F;
            this.Line44.Left = 5.3125F;
            this.Line44.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line44.LineWeight = 1F;
            this.Line44.Name = "Line44";
            this.Line44.Top = 1.3125F;
            this.Line44.Width = 2.625F;
            this.Line44.X1 = 5.3125F;
            this.Line44.X2 = 7.9375F;
            this.Line44.Y1 = 1.3125F;
            this.Line44.Y2 = 1.3125F;
            // 
            // Line49
            // 
            this.Line49.Border.BottomColor = System.Drawing.Color.Black;
            this.Line49.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line49.Border.LeftColor = System.Drawing.Color.Black;
            this.Line49.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line49.Border.RightColor = System.Drawing.Color.Black;
            this.Line49.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line49.Border.TopColor = System.Drawing.Color.Black;
            this.Line49.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line49.Height = 0F;
            this.Line49.Left = 0.625F;
            this.Line49.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line49.LineWeight = 1F;
            this.Line49.Name = "Line49";
            this.Line49.Top = 1.5F;
            this.Line49.Width = 7.3125F;
            this.Line49.X1 = 0.625F;
            this.Line49.X2 = 7.9375F;
            this.Line49.Y1 = 1.5F;
            this.Line49.Y2 = 1.5F;
            // 
            // Line57
            // 
            this.Line57.Border.BottomColor = System.Drawing.Color.Black;
            this.Line57.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line57.Border.LeftColor = System.Drawing.Color.Black;
            this.Line57.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line57.Border.RightColor = System.Drawing.Color.Black;
            this.Line57.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line57.Border.TopColor = System.Drawing.Color.Black;
            this.Line57.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line57.Height = 0F;
            this.Line57.Left = 5.3125F;
            this.Line57.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line57.LineWeight = 1F;
            this.Line57.Name = "Line57";
            this.Line57.Top = 1.3125F;
            this.Line57.Width = 2.625F;
            this.Line57.X1 = 5.3125F;
            this.Line57.X2 = 7.9375F;
            this.Line57.Y1 = 1.3125F;
            this.Line57.Y2 = 1.3125F;
            // 
            // Line46
            // 
            this.Line46.Border.BottomColor = System.Drawing.Color.Black;
            this.Line46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line46.Border.LeftColor = System.Drawing.Color.Black;
            this.Line46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line46.Border.RightColor = System.Drawing.Color.Black;
            this.Line46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line46.Border.TopColor = System.Drawing.Color.Black;
            this.Line46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line46.Height = 0.5F;
            this.Line46.Left = 6.1875F;
            this.Line46.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line46.LineWeight = 1F;
            this.Line46.Name = "Line46";
            this.Line46.Top = 0.8125F;
            this.Line46.Width = 0F;
            this.Line46.X1 = 6.1875F;
            this.Line46.X2 = 6.1875F;
            this.Line46.Y1 = 1.3125F;
            this.Line46.Y2 = 0.8125F;
            // 
            // Line38
            // 
            this.Line38.Border.BottomColor = System.Drawing.Color.Black;
            this.Line38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line38.Border.LeftColor = System.Drawing.Color.Black;
            this.Line38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line38.Border.RightColor = System.Drawing.Color.Black;
            this.Line38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line38.Border.TopColor = System.Drawing.Color.Black;
            this.Line38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line38.Height = 0.5F;
            this.Line38.Left = 5.75F;
            this.Line38.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line38.LineWeight = 1F;
            this.Line38.Name = "Line38";
            this.Line38.Top = 1.506944F;
            this.Line38.Width = 0F;
            this.Line38.X1 = 5.75F;
            this.Line38.X2 = 5.75F;
            this.Line38.Y1 = 2.006944F;
            this.Line38.Y2 = 1.506944F;
            // 
            // Line59
            // 
            this.Line59.Border.BottomColor = System.Drawing.Color.Black;
            this.Line59.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line59.Border.LeftColor = System.Drawing.Color.Black;
            this.Line59.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line59.Border.RightColor = System.Drawing.Color.Black;
            this.Line59.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line59.Border.TopColor = System.Drawing.Color.Black;
            this.Line59.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line59.Height = 0.5F;
            this.Line59.Left = 7.125F;
            this.Line59.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line59.LineWeight = 1F;
            this.Line59.Name = "Line59";
            this.Line59.Top = 0.8125F;
            this.Line59.Width = 0F;
            this.Line59.X1 = 7.125F;
            this.Line59.X2 = 7.125F;
            this.Line59.Y1 = 1.3125F;
            this.Line59.Y2 = 0.8125F;
            // 
            // Line60
            // 
            this.Line60.Border.BottomColor = System.Drawing.Color.Black;
            this.Line60.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line60.Border.LeftColor = System.Drawing.Color.Black;
            this.Line60.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line60.Border.RightColor = System.Drawing.Color.Black;
            this.Line60.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line60.Border.TopColor = System.Drawing.Color.Black;
            this.Line60.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line60.Height = 0F;
            this.Line60.Left = 5.3125F;
            this.Line60.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line60.LineWeight = 1F;
            this.Line60.Name = "Line60";
            this.Line60.Top = 0.8125F;
            this.Line60.Width = 2.625F;
            this.Line60.X1 = 5.3125F;
            this.Line60.X2 = 7.9375F;
            this.Line60.Y1 = 0.8125F;
            this.Line60.Y2 = 0.8125F;
            // 
            // Line61
            // 
            this.Line61.Border.BottomColor = System.Drawing.Color.Black;
            this.Line61.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line61.Border.LeftColor = System.Drawing.Color.Black;
            this.Line61.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line61.Border.RightColor = System.Drawing.Color.Black;
            this.Line61.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line61.Border.TopColor = System.Drawing.Color.Black;
            this.Line61.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line61.Height = 0.5F;
            this.Line61.Left = 5.3125F;
            this.Line61.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line61.LineWeight = 1F;
            this.Line61.Name = "Line61";
            this.Line61.Top = 0.8125F;
            this.Line61.Width = 0F;
            this.Line61.X1 = 5.3125F;
            this.Line61.X2 = 5.3125F;
            this.Line61.Y1 = 1.3125F;
            this.Line61.Y2 = 0.8125F;
            // 
            // Line62
            // 
            this.Line62.Border.BottomColor = System.Drawing.Color.Black;
            this.Line62.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line62.Border.LeftColor = System.Drawing.Color.Black;
            this.Line62.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line62.Border.RightColor = System.Drawing.Color.Black;
            this.Line62.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line62.Border.TopColor = System.Drawing.Color.Black;
            this.Line62.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line62.Height = 0.5F;
            this.Line62.Left = 7.9375F;
            this.Line62.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line62.LineWeight = 1F;
            this.Line62.Name = "Line62";
            this.Line62.Top = 0.8125F;
            this.Line62.Width = 0F;
            this.Line62.X1 = 7.9375F;
            this.Line62.X2 = 7.9375F;
            this.Line62.Y1 = 1.3125F;
            this.Line62.Y2 = 0.8125F;
            // 
            // Label119
            // 
            this.Label119.Border.BottomColor = System.Drawing.Color.Black;
            this.Label119.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label119.Border.LeftColor = System.Drawing.Color.Black;
            this.Label119.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label119.Border.RightColor = System.Drawing.Color.Black;
            this.Label119.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label119.Border.TopColor = System.Drawing.Color.Black;
            this.Label119.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label119.Height = 0.1875F;
            this.Label119.HyperLink = "";
            this.Label119.Left = 5.4375F;
            this.Label119.Name = "Label119";
            this.Label119.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label119.Text = "DATE";
            this.Label119.Top = 0.875F;
            this.Label119.Width = 0.5F;
            // 
            // Label120
            // 
            this.Label120.Border.BottomColor = System.Drawing.Color.Black;
            this.Label120.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label120.Border.LeftColor = System.Drawing.Color.Black;
            this.Label120.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label120.Border.RightColor = System.Drawing.Color.Black;
            this.Label120.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label120.Border.TopColor = System.Drawing.Color.Black;
            this.Label120.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label120.Height = 0.1875F;
            this.Label120.HyperLink = "";
            this.Label120.Left = 6.375F;
            this.Label120.Name = "Label120";
            this.Label120.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label120.Text = "TIME";
            this.Label120.Top = 0.875F;
            this.Label120.Width = 0.5F;
            // 
            // lblDate1
            // 
            this.lblDate1.Border.BottomColor = System.Drawing.Color.Black;
            this.lblDate1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDate1.Border.LeftColor = System.Drawing.Color.Black;
            this.lblDate1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDate1.Border.RightColor = System.Drawing.Color.Black;
            this.lblDate1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDate1.Border.TopColor = System.Drawing.Color.Black;
            this.lblDate1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDate1.Height = 0.2F;
            this.lblDate1.HyperLink = "";
            this.lblDate1.Left = 5.25F;
            this.lblDate1.Name = "lblDate1";
            this.lblDate1.Style = "text-align: center; font-size: 8pt; ";
            this.lblDate1.Text = "lblDate1";
            this.lblDate1.Top = 4.5625F;
            this.lblDate1.Width = 0.9090909F;
            // 
            // lblTime1
            // 
            this.lblTime1.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTime1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTime1.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTime1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTime1.Border.RightColor = System.Drawing.Color.Black;
            this.lblTime1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTime1.Border.TopColor = System.Drawing.Color.Black;
            this.lblTime1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTime1.Height = 0.2F;
            this.lblTime1.HyperLink = "";
            this.lblTime1.Left = 6.125F;
            this.lblTime1.Name = "lblTime1";
            this.lblTime1.Style = "text-align: center; font-size: 8pt; ";
            this.lblTime1.Text = "lblTime1";
            this.lblTime1.Top = 4.5625F;
            this.lblTime1.Width = 0.9090909F;
            // 
            // Label127
            // 
            this.Label127.Border.BottomColor = System.Drawing.Color.Black;
            this.Label127.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label127.Border.LeftColor = System.Drawing.Color.Black;
            this.Label127.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label127.Border.RightColor = System.Drawing.Color.Black;
            this.Label127.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label127.Border.TopColor = System.Drawing.Color.Black;
            this.Label127.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label127.Height = 0.1875F;
            this.Label127.HyperLink = "";
            this.Label127.Left = 3.125F;
            this.Label127.MultiLine = false;
            this.Label127.Name = "Label127";
            this.Label127.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label127.Text = "RECEIPT";
            this.Label127.Top = 4.4375F;
            this.Label127.Width = 1.6875F;
            // 
            // Line63
            // 
            this.Line63.Border.BottomColor = System.Drawing.Color.Black;
            this.Line63.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line63.Border.LeftColor = System.Drawing.Color.Black;
            this.Line63.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line63.Border.RightColor = System.Drawing.Color.Black;
            this.Line63.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line63.Border.TopColor = System.Drawing.Color.Black;
            this.Line63.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line63.Height = 0F;
            this.Line63.Left = 5.25F;
            this.Line63.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line63.LineWeight = 1F;
            this.Line63.Name = "Line63";
            this.Line63.Top = 4.25F;
            this.Line63.Width = 2.625F;
            this.Line63.X1 = 5.25F;
            this.Line63.X2 = 7.875F;
            this.Line63.Y1 = 4.25F;
            this.Line63.Y2 = 4.25F;
            // 
            // Line64
            // 
            this.Line64.Border.BottomColor = System.Drawing.Color.Black;
            this.Line64.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line64.Border.LeftColor = System.Drawing.Color.Black;
            this.Line64.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line64.Border.RightColor = System.Drawing.Color.Black;
            this.Line64.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line64.Border.TopColor = System.Drawing.Color.Black;
            this.Line64.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line64.Height = 0.5F;
            this.Line64.Left = 6.125F;
            this.Line64.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line64.LineWeight = 1F;
            this.Line64.Name = "Line64";
            this.Line64.Top = 4.25F;
            this.Line64.Width = 0F;
            this.Line64.X1 = 6.125F;
            this.Line64.X2 = 6.125F;
            this.Line64.Y1 = 4.75F;
            this.Line64.Y2 = 4.25F;
            // 
            // LblPolicyClass2
            // 
            this.LblPolicyClass2.Border.BottomColor = System.Drawing.Color.Black;
            this.LblPolicyClass2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblPolicyClass2.Border.LeftColor = System.Drawing.Color.Black;
            this.LblPolicyClass2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblPolicyClass2.Border.RightColor = System.Drawing.Color.Black;
            this.LblPolicyClass2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblPolicyClass2.Border.TopColor = System.Drawing.Color.Black;
            this.LblPolicyClass2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblPolicyClass2.Height = 0.2F;
            this.LblPolicyClass2.HyperLink = "";
            this.LblPolicyClass2.Left = 0.5625F;
            this.LblPolicyClass2.Name = "LblPolicyClass2";
            this.LblPolicyClass2.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.LblPolicyClass2.Text = "Auto";
            this.LblPolicyClass2.Top = 4.6875F;
            this.LblPolicyClass2.Width = 1.5625F;
            // 
            // Shape6
            // 
            this.Shape6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(227)))), ((int)(((byte)(234)))));
            this.Shape6.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape6.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape6.Border.RightColor = System.Drawing.Color.Black;
            this.Shape6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape6.Border.TopColor = System.Drawing.Color.Black;
            this.Shape6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape6.Height = 0.25F;
            this.Shape6.Left = 0.5625F;
            this.Shape6.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Shape6.Name = "Shape6";
            this.Shape6.RoundingRadius = 9.999999F;
            this.Shape6.Top = 4.9375F;
            this.Shape6.Width = 7.3125F;
            // 
            // Line65
            // 
            this.Line65.Border.BottomColor = System.Drawing.Color.Black;
            this.Line65.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line65.Border.LeftColor = System.Drawing.Color.Black;
            this.Line65.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line65.Border.RightColor = System.Drawing.Color.Black;
            this.Line65.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line65.Border.TopColor = System.Drawing.Color.Black;
            this.Line65.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line65.Height = 0F;
            this.Line65.Left = 0.5625F;
            this.Line65.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line65.LineWeight = 1F;
            this.Line65.Name = "Line65";
            this.Line65.Top = 4.9375F;
            this.Line65.Width = 7.3125F;
            this.Line65.X1 = 0.5625F;
            this.Line65.X2 = 7.875F;
            this.Line65.Y1 = 4.9375F;
            this.Line65.Y2 = 4.9375F;
            // 
            // Line66
            // 
            this.Line66.Border.BottomColor = System.Drawing.Color.Black;
            this.Line66.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line66.Border.LeftColor = System.Drawing.Color.Black;
            this.Line66.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line66.Border.RightColor = System.Drawing.Color.Black;
            this.Line66.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line66.Border.TopColor = System.Drawing.Color.Black;
            this.Line66.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line66.Height = 0F;
            this.Line66.Left = 0.5625F;
            this.Line66.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line66.LineWeight = 1F;
            this.Line66.Name = "Line66";
            this.Line66.Top = 5.4375F;
            this.Line66.Width = 7.3125F;
            this.Line66.X1 = 0.5625F;
            this.Line66.X2 = 7.875F;
            this.Line66.Y1 = 5.4375F;
            this.Line66.Y2 = 5.4375F;
            // 
            // Label130
            // 
            this.Label130.Border.BottomColor = System.Drawing.Color.Black;
            this.Label130.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label130.Border.LeftColor = System.Drawing.Color.Black;
            this.Label130.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label130.Border.RightColor = System.Drawing.Color.Black;
            this.Label130.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label130.Border.TopColor = System.Drawing.Color.Black;
            this.Label130.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label130.Height = 0.1875F;
            this.Label130.HyperLink = "";
            this.Label130.Left = 3.3125F;
            this.Label130.Name = "Label130";
            this.Label130.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label130.Text = "NAME";
            this.Label130.Top = 5.0125F;
            this.Label130.Width = 1F;
            // 
            // Label131
            // 
            this.Label131.Border.BottomColor = System.Drawing.Color.Black;
            this.Label131.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label131.Border.LeftColor = System.Drawing.Color.Black;
            this.Label131.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label131.Border.RightColor = System.Drawing.Color.Black;
            this.Label131.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label131.Border.TopColor = System.Drawing.Color.Black;
            this.Label131.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label131.Height = 0.125F;
            this.Label131.HyperLink = "";
            this.Label131.Left = 3.375F;
            this.Label131.Name = "Label131";
            this.Label131.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label131.Text = "CHECK NO.";
            this.Label131.Top = 5.5F;
            this.Label131.Width = 1.1875F;
            // 
            // Label132
            // 
            this.Label132.Border.BottomColor = System.Drawing.Color.Black;
            this.Label132.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label132.Border.LeftColor = System.Drawing.Color.Black;
            this.Label132.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label132.Border.RightColor = System.Drawing.Color.Black;
            this.Label132.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label132.Border.TopColor = System.Drawing.Color.Black;
            this.Label132.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label132.Height = 0.2F;
            this.Label132.HyperLink = "";
            this.Label132.Left = 6.1875F;
            this.Label132.Name = "Label132";
            this.Label132.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label132.Text = "PAID AMOUNT";
            this.Label132.Top = 5F;
            this.Label132.Width = 1F;
            // 
            // txtName1
            // 
            this.txtName1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtName1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtName1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName1.Border.RightColor = System.Drawing.Color.Black;
            this.txtName1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName1.Border.TopColor = System.Drawing.Color.Black;
            this.txtName1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName1.Height = 0.2F;
            this.txtName1.Left = 3.3125F;
            this.txtName1.MultiLine = false;
            this.txtName1.Name = "txtName1";
            this.txtName1.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtName1.Text = "txtName1";
            this.txtName1.Top = 5.25F;
            this.txtName1.Width = 2.375F;
            // 
            // txtPayment1
            // 
            this.txtPayment1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPayment1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPayment1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPayment1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPayment1.Border.RightColor = System.Drawing.Color.Black;
            this.txtPayment1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPayment1.Border.TopColor = System.Drawing.Color.Black;
            this.txtPayment1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPayment1.Height = 0.2F;
            this.txtPayment1.Left = 3.3125F;
            this.txtPayment1.MultiLine = false;
            this.txtPayment1.Name = "txtPayment1";
            this.txtPayment1.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtPayment1.Text = "txtPayment1";
            this.txtPayment1.Top = 5.8125F;
            this.txtPayment1.Width = 2F;
            // 
            // txtPaid1
            // 
            this.txtPaid1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPaid1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPaid1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPaid1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPaid1.Border.RightColor = System.Drawing.Color.Black;
            this.txtPaid1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPaid1.Border.TopColor = System.Drawing.Color.Black;
            this.txtPaid1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPaid1.Height = 0.2F;
            this.txtPaid1.Left = 6.1875F;
            this.txtPaid1.MultiLine = false;
            this.txtPaid1.Name = "txtPaid1";
            this.txtPaid1.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtPaid1.Text = "txtPaid1";
            this.txtPaid1.Top = 5.25F;
            this.txtPaid1.Width = 1.25F;
            // 
            // Label133
            // 
            this.Label133.Border.BottomColor = System.Drawing.Color.Black;
            this.Label133.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label133.Border.LeftColor = System.Drawing.Color.Black;
            this.Label133.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label133.Border.RightColor = System.Drawing.Color.Black;
            this.Label133.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label133.Border.TopColor = System.Drawing.Color.Black;
            this.Label133.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label133.Height = 0.125F;
            this.Label133.HyperLink = "";
            this.Label133.Left = 0.6875F;
            this.Label133.Name = "Label133";
            this.Label133.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label133.Text = " CUSTOMER";
            this.Label133.Top = 5.5F;
            this.Label133.Width = 1F;
            // 
            // Label134
            // 
            this.Label134.Border.BottomColor = System.Drawing.Color.Black;
            this.Label134.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label134.Border.LeftColor = System.Drawing.Color.Black;
            this.Label134.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label134.Border.RightColor = System.Drawing.Color.Black;
            this.Label134.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label134.Border.TopColor = System.Drawing.Color.Black;
            this.Label134.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label134.Height = 0.125F;
            this.Label134.HyperLink = "";
            this.Label134.Left = 1.9375F;
            this.Label134.Name = "Label134";
            this.Label134.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label134.Text = " PRODUCER";
            this.Label134.Top = 5.5F;
            this.Label134.Width = 1F;
            // 
            // Label135
            // 
            this.Label135.Border.BottomColor = System.Drawing.Color.Black;
            this.Label135.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label135.Border.LeftColor = System.Drawing.Color.Black;
            this.Label135.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label135.Border.RightColor = System.Drawing.Color.Black;
            this.Label135.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label135.Border.TopColor = System.Drawing.Color.Black;
            this.Label135.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label135.Height = 0.1750002F;
            this.Label135.HyperLink = "";
            this.Label135.Left = 0.75F;
            this.Label135.Name = "Label135";
            this.Label135.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label135.Text = "POLICY NUMBER";
            this.Label135.Top = 5.025F;
            this.Label135.Width = 1.375F;
            // 
            // Label136
            // 
            this.Label136.Border.BottomColor = System.Drawing.Color.Black;
            this.Label136.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label136.Border.LeftColor = System.Drawing.Color.Black;
            this.Label136.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label136.Border.RightColor = System.Drawing.Color.Black;
            this.Label136.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label136.Border.TopColor = System.Drawing.Color.Black;
            this.Label136.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label136.Height = 0.1875F;
            this.Label136.HyperLink = "";
            this.Label136.Left = 5.6875F;
            this.Label136.Name = "Label136";
            this.Label136.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label136.Text = " RECEIVED BY";
            this.Label136.Top = 5.5F;
            this.Label136.Width = 1F;
            // 
            // txtCustomer1
            // 
            this.txtCustomer1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCustomer1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomer1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCustomer1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomer1.Border.RightColor = System.Drawing.Color.Black;
            this.txtCustomer1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomer1.Border.TopColor = System.Drawing.Color.Black;
            this.txtCustomer1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomer1.Height = 0.1875F;
            this.txtCustomer1.Left = 0.6875F;
            this.txtCustomer1.MultiLine = false;
            this.txtCustomer1.Name = "txtCustomer1";
            this.txtCustomer1.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtCustomer1.Text = "txtCustomer1";
            this.txtCustomer1.Top = 5.8125F;
            this.txtCustomer1.Width = 1.125F;
            // 
            // txtProducer1
            // 
            this.txtProducer1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtProducer1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProducer1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtProducer1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProducer1.Border.RightColor = System.Drawing.Color.Black;
            this.txtProducer1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProducer1.Border.TopColor = System.Drawing.Color.Black;
            this.txtProducer1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProducer1.Height = 0.1875F;
            this.txtProducer1.Left = 2F;
            this.txtProducer1.MultiLine = false;
            this.txtProducer1.Name = "txtProducer1";
            this.txtProducer1.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtProducer1.Text = "txtProducer1";
            this.txtProducer1.Top = 5.8125F;
            this.txtProducer1.Width = 1.125F;
            // 
            // Line68
            // 
            this.Line68.Border.BottomColor = System.Drawing.Color.Black;
            this.Line68.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line68.Border.LeftColor = System.Drawing.Color.Black;
            this.Line68.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line68.Border.RightColor = System.Drawing.Color.Black;
            this.Line68.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line68.Border.TopColor = System.Drawing.Color.Black;
            this.Line68.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line68.Height = 1.0625F;
            this.Line68.Left = 3.1875F;
            this.Line68.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line68.LineWeight = 1F;
            this.Line68.Name = "Line68";
            this.Line68.Top = 4.9375F;
            this.Line68.Width = 0F;
            this.Line68.X1 = 3.1875F;
            this.Line68.X2 = 3.1875F;
            this.Line68.Y1 = 6F;
            this.Line68.Y2 = 4.9375F;
            // 
            // Line69
            // 
            this.Line69.Border.BottomColor = System.Drawing.Color.Black;
            this.Line69.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line69.Border.LeftColor = System.Drawing.Color.Black;
            this.Line69.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line69.Border.RightColor = System.Drawing.Color.Black;
            this.Line69.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line69.Border.TopColor = System.Drawing.Color.Black;
            this.Line69.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line69.Height = 0.5625F;
            this.Line69.Left = 1.9375F;
            this.Line69.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line69.LineWeight = 1F;
            this.Line69.Name = "Line69";
            this.Line69.Top = 5.4375F;
            this.Line69.Width = 0F;
            this.Line69.X1 = 1.9375F;
            this.Line69.X2 = 1.9375F;
            this.Line69.Y1 = 6F;
            this.Line69.Y2 = 5.4375F;
            // 
            // Line70
            // 
            this.Line70.Border.BottomColor = System.Drawing.Color.Black;
            this.Line70.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line70.Border.LeftColor = System.Drawing.Color.Black;
            this.Line70.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line70.Border.RightColor = System.Drawing.Color.Black;
            this.Line70.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line70.Border.TopColor = System.Drawing.Color.Black;
            this.Line70.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line70.Height = 0.5625F;
            this.Line70.Left = 5.694445F;
            this.Line70.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line70.LineWeight = 1F;
            this.Line70.Name = "Line70";
            this.Line70.Top = 5.4375F;
            this.Line70.Width = 0F;
            this.Line70.X1 = 5.694445F;
            this.Line70.X2 = 5.694445F;
            this.Line70.Y1 = 6F;
            this.Line70.Y2 = 5.4375F;
            // 
            // txtPolicyNumber1
            // 
            this.txtPolicyNumber1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPolicyNumber1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyNumber1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPolicyNumber1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyNumber1.Border.RightColor = System.Drawing.Color.Black;
            this.txtPolicyNumber1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyNumber1.Border.TopColor = System.Drawing.Color.Black;
            this.txtPolicyNumber1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyNumber1.Height = 0.1875F;
            this.txtPolicyNumber1.Left = 0.75F;
            this.txtPolicyNumber1.MultiLine = false;
            this.txtPolicyNumber1.Name = "txtPolicyNumber1";
            this.txtPolicyNumber1.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtPolicyNumber1.Text = "txtPolicyNumber1";
            this.txtPolicyNumber1.Top = 5.2625F;
            this.txtPolicyNumber1.Width = 2.1875F;
            // 
            // txtReceived1
            // 
            this.txtReceived1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtReceived1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReceived1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtReceived1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReceived1.Border.RightColor = System.Drawing.Color.Black;
            this.txtReceived1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReceived1.Border.TopColor = System.Drawing.Color.Black;
            this.txtReceived1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReceived1.Height = 0.1875F;
            this.txtReceived1.Left = 5.75F;
            this.txtReceived1.MultiLine = false;
            this.txtReceived1.Name = "txtReceived1";
            this.txtReceived1.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtReceived1.Text = "txtReceived1";
            this.txtReceived1.Top = 5.8125F;
            this.txtReceived1.Width = 2.0625F;
            // 
            // Line71
            // 
            this.Line71.Border.BottomColor = System.Drawing.Color.Black;
            this.Line71.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line71.Border.LeftColor = System.Drawing.Color.Black;
            this.Line71.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line71.Border.RightColor = System.Drawing.Color.Black;
            this.Line71.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line71.Border.TopColor = System.Drawing.Color.Black;
            this.Line71.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line71.Height = 0F;
            this.Line71.Left = 0.5625F;
            this.Line71.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line71.LineWeight = 1F;
            this.Line71.Name = "Line71";
            this.Line71.Top = 6F;
            this.Line71.Width = 7.3125F;
            this.Line71.X1 = 0.5625F;
            this.Line71.X2 = 7.875F;
            this.Line71.Y1 = 6F;
            this.Line71.Y2 = 6F;
            // 
            // Line72
            // 
            this.Line72.Border.BottomColor = System.Drawing.Color.Black;
            this.Line72.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line72.Border.LeftColor = System.Drawing.Color.Black;
            this.Line72.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line72.Border.RightColor = System.Drawing.Color.Black;
            this.Line72.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line72.Border.TopColor = System.Drawing.Color.Black;
            this.Line72.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line72.Height = 1.0625F;
            this.Line72.Left = 0.5625F;
            this.Line72.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line72.LineWeight = 1F;
            this.Line72.Name = "Line72";
            this.Line72.Top = 4.9375F;
            this.Line72.Width = 0F;
            this.Line72.X1 = 0.5625F;
            this.Line72.X2 = 0.5625F;
            this.Line72.Y1 = 6F;
            this.Line72.Y2 = 4.9375F;
            // 
            // txtNumber1
            // 
            this.txtNumber1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtNumber1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumber1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtNumber1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumber1.Border.RightColor = System.Drawing.Color.Black;
            this.txtNumber1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumber1.Border.TopColor = System.Drawing.Color.Black;
            this.txtNumber1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumber1.Height = 0.1875F;
            this.txtNumber1.Left = 7.0625F;
            this.txtNumber1.MultiLine = false;
            this.txtNumber1.Name = "txtNumber1";
            this.txtNumber1.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.txtNumber1.Text = "txtNumber1";
            this.txtNumber1.Top = 4.5625F;
            this.txtNumber1.Width = 0.75F;
            // 
            // Line73
            // 
            this.Line73.Border.BottomColor = System.Drawing.Color.Black;
            this.Line73.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line73.Border.LeftColor = System.Drawing.Color.Black;
            this.Line73.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line73.Border.RightColor = System.Drawing.Color.Black;
            this.Line73.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line73.Border.TopColor = System.Drawing.Color.Black;
            this.Line73.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line73.Height = 0F;
            this.Line73.Left = 5.25F;
            this.Line73.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line73.LineWeight = 1F;
            this.Line73.Name = "Line73";
            this.Line73.Top = 4.75F;
            this.Line73.Width = 2.625F;
            this.Line73.X1 = 5.25F;
            this.Line73.X2 = 7.875F;
            this.Line73.Y1 = 4.75F;
            this.Line73.Y2 = 4.75F;
            // 
            // Label137
            // 
            this.Label137.Border.BottomColor = System.Drawing.Color.Black;
            this.Label137.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label137.Border.LeftColor = System.Drawing.Color.Black;
            this.Label137.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label137.Border.RightColor = System.Drawing.Color.Black;
            this.Label137.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label137.Border.TopColor = System.Drawing.Color.Black;
            this.Label137.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label137.Height = 0.1875F;
            this.Label137.HyperLink = "";
            this.Label137.Left = 0.5F;
            this.Label137.MultiLine = false;
            this.Label137.Name = "Label137";
            this.Label137.Style = "text-align: left; font-weight: bold; font-size: 9.75pt; ";
            this.Label137.Text = "CUSTOMER";
            this.Label137.Top = 9.5625F;
            this.Label137.Width = 1.6875F;
            // 
            // Line74
            // 
            this.Line74.Border.BottomColor = System.Drawing.Color.Black;
            this.Line74.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line74.Border.LeftColor = System.Drawing.Color.Black;
            this.Line74.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line74.Border.RightColor = System.Drawing.Color.Black;
            this.Line74.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line74.Border.TopColor = System.Drawing.Color.Black;
            this.Line74.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line74.Height = 0F;
            this.Line74.Left = 0.3819444F;
            this.Line74.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line74.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
            this.Line74.LineWeight = 1F;
            this.Line74.Name = "Line74";
            this.Line74.Top = 6.631945F;
            this.Line74.Width = 7.6875F;
            this.Line74.X1 = 0.3819444F;
            this.Line74.X2 = 8.069445F;
            this.Line74.Y1 = 6.631945F;
            this.Line74.Y2 = 6.631945F;
            // 
            // Line75
            // 
            this.Line75.Border.BottomColor = System.Drawing.Color.Black;
            this.Line75.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line75.Border.LeftColor = System.Drawing.Color.Black;
            this.Line75.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line75.Border.RightColor = System.Drawing.Color.Black;
            this.Line75.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line75.Border.TopColor = System.Drawing.Color.Black;
            this.Line75.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line75.Height = 0F;
            this.Line75.Left = 5.25F;
            this.Line75.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line75.LineWeight = 1F;
            this.Line75.Name = "Line75";
            this.Line75.Top = 4.25F;
            this.Line75.Width = 2.625F;
            this.Line75.X1 = 5.25F;
            this.Line75.X2 = 7.875F;
            this.Line75.Y1 = 4.25F;
            this.Line75.Y2 = 4.25F;
            // 
            // Line76
            // 
            this.Line76.Border.BottomColor = System.Drawing.Color.Black;
            this.Line76.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line76.Border.LeftColor = System.Drawing.Color.Black;
            this.Line76.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line76.Border.RightColor = System.Drawing.Color.Black;
            this.Line76.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line76.Border.TopColor = System.Drawing.Color.Black;
            this.Line76.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line76.Height = 0.5F;
            this.Line76.Left = 6.125F;
            this.Line76.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line76.LineWeight = 1F;
            this.Line76.Name = "Line76";
            this.Line76.Top = 4.25F;
            this.Line76.Width = 0F;
            this.Line76.X1 = 6.125F;
            this.Line76.X2 = 6.125F;
            this.Line76.Y1 = 4.75F;
            this.Line76.Y2 = 4.25F;
            // 
            // Line77
            // 
            this.Line77.Border.BottomColor = System.Drawing.Color.Black;
            this.Line77.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line77.Border.LeftColor = System.Drawing.Color.Black;
            this.Line77.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line77.Border.RightColor = System.Drawing.Color.Black;
            this.Line77.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line77.Border.TopColor = System.Drawing.Color.Black;
            this.Line77.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line77.Height = 0F;
            this.Line77.Left = 0.5625F;
            this.Line77.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line77.LineWeight = 1F;
            this.Line77.Name = "Line77";
            this.Line77.Top = 4.9375F;
            this.Line77.Width = 7.3125F;
            this.Line77.X1 = 0.5625F;
            this.Line77.X2 = 7.875F;
            this.Line77.Y1 = 4.9375F;
            this.Line77.Y2 = 4.9375F;
            // 
            // Line78
            // 
            this.Line78.Border.BottomColor = System.Drawing.Color.Black;
            this.Line78.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line78.Border.LeftColor = System.Drawing.Color.Black;
            this.Line78.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line78.Border.RightColor = System.Drawing.Color.Black;
            this.Line78.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line78.Border.TopColor = System.Drawing.Color.Black;
            this.Line78.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line78.Height = 0F;
            this.Line78.Left = 5.25F;
            this.Line78.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line78.LineWeight = 1F;
            this.Line78.Name = "Line78";
            this.Line78.Top = 4.75F;
            this.Line78.Width = 2.625F;
            this.Line78.X1 = 5.25F;
            this.Line78.X2 = 7.875F;
            this.Line78.Y1 = 4.75F;
            this.Line78.Y2 = 4.75F;
            // 
            // Line79
            // 
            this.Line79.Border.BottomColor = System.Drawing.Color.Black;
            this.Line79.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line79.Border.LeftColor = System.Drawing.Color.Black;
            this.Line79.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line79.Border.RightColor = System.Drawing.Color.Black;
            this.Line79.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line79.Border.TopColor = System.Drawing.Color.Black;
            this.Line79.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line79.Height = 0F;
            this.Line79.Left = 0.5625F;
            this.Line79.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line79.LineWeight = 1F;
            this.Line79.Name = "Line79";
            this.Line79.Top = 4.9375F;
            this.Line79.Width = 7.3125F;
            this.Line79.X1 = 0.5625F;
            this.Line79.X2 = 7.875F;
            this.Line79.Y1 = 4.9375F;
            this.Line79.Y2 = 4.9375F;
            // 
            // Line80
            // 
            this.Line80.Border.BottomColor = System.Drawing.Color.Black;
            this.Line80.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line80.Border.LeftColor = System.Drawing.Color.Black;
            this.Line80.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line80.Border.RightColor = System.Drawing.Color.Black;
            this.Line80.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line80.Border.TopColor = System.Drawing.Color.Black;
            this.Line80.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line80.Height = 0F;
            this.Line80.Left = 5.25F;
            this.Line80.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line80.LineWeight = 1F;
            this.Line80.Name = "Line80";
            this.Line80.Top = 4.75F;
            this.Line80.Width = 2.625F;
            this.Line80.X1 = 5.25F;
            this.Line80.X2 = 7.875F;
            this.Line80.Y1 = 4.75F;
            this.Line80.Y2 = 4.75F;
            // 
            // Line81
            // 
            this.Line81.Border.BottomColor = System.Drawing.Color.Black;
            this.Line81.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line81.Border.LeftColor = System.Drawing.Color.Black;
            this.Line81.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line81.Border.RightColor = System.Drawing.Color.Black;
            this.Line81.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line81.Border.TopColor = System.Drawing.Color.Black;
            this.Line81.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line81.Height = 0.5F;
            this.Line81.Left = 6.125F;
            this.Line81.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line81.LineWeight = 1F;
            this.Line81.Name = "Line81";
            this.Line81.Top = 4.25F;
            this.Line81.Width = 0F;
            this.Line81.X1 = 6.125F;
            this.Line81.X2 = 6.125F;
            this.Line81.Y1 = 4.75F;
            this.Line81.Y2 = 4.25F;
            // 
            // Line82
            // 
            this.Line82.Border.BottomColor = System.Drawing.Color.Black;
            this.Line82.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line82.Border.LeftColor = System.Drawing.Color.Black;
            this.Line82.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line82.Border.RightColor = System.Drawing.Color.Black;
            this.Line82.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line82.Border.TopColor = System.Drawing.Color.Black;
            this.Line82.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line82.Height = 0.5F;
            this.Line82.Left = 5.70139F;
            this.Line82.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line82.LineWeight = 1F;
            this.Line82.Name = "Line82";
            this.Line82.Top = 4.944445F;
            this.Line82.Width = 0F;
            this.Line82.X1 = 5.70139F;
            this.Line82.X2 = 5.70139F;
            this.Line82.Y1 = 5.444445F;
            this.Line82.Y2 = 4.944445F;
            // 
            // Line83
            // 
            this.Line83.Border.BottomColor = System.Drawing.Color.Black;
            this.Line83.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line83.Border.LeftColor = System.Drawing.Color.Black;
            this.Line83.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line83.Border.RightColor = System.Drawing.Color.Black;
            this.Line83.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line83.Border.TopColor = System.Drawing.Color.Black;
            this.Line83.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line83.Height = 0.5F;
            this.Line83.Left = 7.0625F;
            this.Line83.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line83.LineWeight = 1F;
            this.Line83.Name = "Line83";
            this.Line83.Top = 4.25F;
            this.Line83.Width = 0F;
            this.Line83.X1 = 7.0625F;
            this.Line83.X2 = 7.0625F;
            this.Line83.Y1 = 4.75F;
            this.Line83.Y2 = 4.25F;
            // 
            // Line84
            // 
            this.Line84.Border.BottomColor = System.Drawing.Color.Black;
            this.Line84.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line84.Border.LeftColor = System.Drawing.Color.Black;
            this.Line84.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line84.Border.RightColor = System.Drawing.Color.Black;
            this.Line84.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line84.Border.TopColor = System.Drawing.Color.Black;
            this.Line84.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line84.Height = 0F;
            this.Line84.Left = 5.25F;
            this.Line84.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line84.LineWeight = 1F;
            this.Line84.Name = "Line84";
            this.Line84.Top = 4.25F;
            this.Line84.Width = 2.625F;
            this.Line84.X1 = 5.25F;
            this.Line84.X2 = 7.875F;
            this.Line84.Y1 = 4.25F;
            this.Line84.Y2 = 4.25F;
            // 
            // Line85
            // 
            this.Line85.Border.BottomColor = System.Drawing.Color.Black;
            this.Line85.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line85.Border.LeftColor = System.Drawing.Color.Black;
            this.Line85.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line85.Border.RightColor = System.Drawing.Color.Black;
            this.Line85.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line85.Border.TopColor = System.Drawing.Color.Black;
            this.Line85.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line85.Height = 0.5F;
            this.Line85.Left = 5.25F;
            this.Line85.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line85.LineWeight = 1F;
            this.Line85.Name = "Line85";
            this.Line85.Top = 4.25F;
            this.Line85.Width = 0F;
            this.Line85.X1 = 5.25F;
            this.Line85.X2 = 5.25F;
            this.Line85.Y1 = 4.75F;
            this.Line85.Y2 = 4.25F;
            // 
            // Label138
            // 
            this.Label138.Border.BottomColor = System.Drawing.Color.Black;
            this.Label138.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label138.Border.LeftColor = System.Drawing.Color.Black;
            this.Label138.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label138.Border.RightColor = System.Drawing.Color.Black;
            this.Label138.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label138.Border.TopColor = System.Drawing.Color.Black;
            this.Label138.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label138.Height = 0.1875F;
            this.Label138.HyperLink = "";
            this.Label138.Left = 5.375F;
            this.Label138.Name = "Label138";
            this.Label138.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label138.Text = "DATE";
            this.Label138.Top = 4.3125F;
            this.Label138.Width = 0.5F;
            // 
            // Label139
            // 
            this.Label139.Border.BottomColor = System.Drawing.Color.Black;
            this.Label139.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label139.Border.LeftColor = System.Drawing.Color.Black;
            this.Label139.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label139.Border.RightColor = System.Drawing.Color.Black;
            this.Label139.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label139.Border.TopColor = System.Drawing.Color.Black;
            this.Label139.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label139.Height = 0.1875F;
            this.Label139.HyperLink = "";
            this.Label139.Left = 6.3125F;
            this.Label139.Name = "Label139";
            this.Label139.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label139.Text = "TIME";
            this.Label139.Top = 4.3125F;
            this.Label139.Width = 0.5F;
            // 
            // lblDate2
            // 
            this.lblDate2.Border.BottomColor = System.Drawing.Color.Black;
            this.lblDate2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDate2.Border.LeftColor = System.Drawing.Color.Black;
            this.lblDate2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDate2.Border.RightColor = System.Drawing.Color.Black;
            this.lblDate2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDate2.Border.TopColor = System.Drawing.Color.Black;
            this.lblDate2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDate2.Height = 0.2F;
            this.lblDate2.HyperLink = "";
            this.lblDate2.Left = 5.1875F;
            this.lblDate2.Name = "lblDate2";
            this.lblDate2.Style = "text-align: center; font-size: 8pt; ";
            this.lblDate2.Text = "lblDate2";
            this.lblDate2.Top = 7.9375F;
            this.lblDate2.Width = 0.9090909F;
            // 
            // lblTime2
            // 
            this.lblTime2.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTime2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTime2.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTime2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTime2.Border.RightColor = System.Drawing.Color.Black;
            this.lblTime2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTime2.Border.TopColor = System.Drawing.Color.Black;
            this.lblTime2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTime2.Height = 0.2F;
            this.lblTime2.HyperLink = "";
            this.lblTime2.Left = 6.0625F;
            this.lblTime2.Name = "lblTime2";
            this.lblTime2.Style = "text-align: center; font-size: 8pt; ";
            this.lblTime2.Text = "lblTime2";
            this.lblTime2.Top = 7.9375F;
            this.lblTime2.Width = 0.9090909F;
            // 
            // Label146
            // 
            this.Label146.Border.BottomColor = System.Drawing.Color.Black;
            this.Label146.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label146.Border.LeftColor = System.Drawing.Color.Black;
            this.Label146.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label146.Border.RightColor = System.Drawing.Color.Black;
            this.Label146.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label146.Border.TopColor = System.Drawing.Color.Black;
            this.Label146.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label146.Height = 0.1875F;
            this.Label146.HyperLink = "";
            this.Label146.Left = 3.0625F;
            this.Label146.MultiLine = false;
            this.Label146.Name = "Label146";
            this.Label146.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label146.Text = "RECEIPT";
            this.Label146.Top = 7.8125F;
            this.Label146.Width = 1.6875F;
            // 
            // Line86
            // 
            this.Line86.Border.BottomColor = System.Drawing.Color.Black;
            this.Line86.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line86.Border.LeftColor = System.Drawing.Color.Black;
            this.Line86.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line86.Border.RightColor = System.Drawing.Color.Black;
            this.Line86.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line86.Border.TopColor = System.Drawing.Color.Black;
            this.Line86.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line86.Height = 0F;
            this.Line86.Left = 5.1875F;
            this.Line86.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line86.LineWeight = 1F;
            this.Line86.Name = "Line86";
            this.Line86.Top = 7.625F;
            this.Line86.Width = 2.625F;
            this.Line86.X1 = 5.1875F;
            this.Line86.X2 = 7.8125F;
            this.Line86.Y1 = 7.625F;
            this.Line86.Y2 = 7.625F;
            // 
            // Line87
            // 
            this.Line87.Border.BottomColor = System.Drawing.Color.Black;
            this.Line87.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line87.Border.LeftColor = System.Drawing.Color.Black;
            this.Line87.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line87.Border.RightColor = System.Drawing.Color.Black;
            this.Line87.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line87.Border.TopColor = System.Drawing.Color.Black;
            this.Line87.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line87.Height = 0.5F;
            this.Line87.Left = 6.0625F;
            this.Line87.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line87.LineWeight = 1F;
            this.Line87.Name = "Line87";
            this.Line87.Top = 7.625F;
            this.Line87.Width = 0F;
            this.Line87.X1 = 6.0625F;
            this.Line87.X2 = 6.0625F;
            this.Line87.Y1 = 8.125F;
            this.Line87.Y2 = 7.625F;
            // 
            // LblPolicyClass3
            // 
            this.LblPolicyClass3.Border.BottomColor = System.Drawing.Color.Black;
            this.LblPolicyClass3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblPolicyClass3.Border.LeftColor = System.Drawing.Color.Black;
            this.LblPolicyClass3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblPolicyClass3.Border.RightColor = System.Drawing.Color.Black;
            this.LblPolicyClass3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblPolicyClass3.Border.TopColor = System.Drawing.Color.Black;
            this.LblPolicyClass3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblPolicyClass3.Height = 0.2F;
            this.LblPolicyClass3.HyperLink = "";
            this.LblPolicyClass3.Left = 0.5F;
            this.LblPolicyClass3.Name = "LblPolicyClass3";
            this.LblPolicyClass3.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; ";
            this.LblPolicyClass3.Text = "Auto";
            this.LblPolicyClass3.Top = 8.0625F;
            this.LblPolicyClass3.Width = 1.5625F;
            // 
            // Shape9
            // 
            this.Shape9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(227)))), ((int)(((byte)(234)))));
            this.Shape9.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape9.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape9.Border.RightColor = System.Drawing.Color.Black;
            this.Shape9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape9.Border.TopColor = System.Drawing.Color.Black;
            this.Shape9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape9.Height = 0.25F;
            this.Shape9.Left = 0.5F;
            this.Shape9.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Shape9.Name = "Shape9";
            this.Shape9.RoundingRadius = 9.999999F;
            this.Shape9.Top = 8.3125F;
            this.Shape9.Width = 7.3125F;
            // 
            // Line88
            // 
            this.Line88.Border.BottomColor = System.Drawing.Color.Black;
            this.Line88.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line88.Border.LeftColor = System.Drawing.Color.Black;
            this.Line88.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line88.Border.RightColor = System.Drawing.Color.Black;
            this.Line88.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line88.Border.TopColor = System.Drawing.Color.Black;
            this.Line88.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line88.Height = 0F;
            this.Line88.Left = 0.5F;
            this.Line88.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line88.LineWeight = 1F;
            this.Line88.Name = "Line88";
            this.Line88.Top = 8.3125F;
            this.Line88.Width = 7.3125F;
            this.Line88.X1 = 0.5F;
            this.Line88.X2 = 7.8125F;
            this.Line88.Y1 = 8.3125F;
            this.Line88.Y2 = 8.3125F;
            // 
            // Line89
            // 
            this.Line89.Border.BottomColor = System.Drawing.Color.Black;
            this.Line89.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line89.Border.LeftColor = System.Drawing.Color.Black;
            this.Line89.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line89.Border.RightColor = System.Drawing.Color.Black;
            this.Line89.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line89.Border.TopColor = System.Drawing.Color.Black;
            this.Line89.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line89.Height = 0F;
            this.Line89.Left = 0.5F;
            this.Line89.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line89.LineWeight = 1F;
            this.Line89.Name = "Line89";
            this.Line89.Top = 8.8125F;
            this.Line89.Width = 7.3125F;
            this.Line89.X1 = 0.5F;
            this.Line89.X2 = 7.8125F;
            this.Line89.Y1 = 8.8125F;
            this.Line89.Y2 = 8.8125F;
            // 
            // Label149
            // 
            this.Label149.Border.BottomColor = System.Drawing.Color.Black;
            this.Label149.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label149.Border.LeftColor = System.Drawing.Color.Black;
            this.Label149.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label149.Border.RightColor = System.Drawing.Color.Black;
            this.Label149.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label149.Border.TopColor = System.Drawing.Color.Black;
            this.Label149.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label149.Height = 0.1875F;
            this.Label149.HyperLink = "";
            this.Label149.Left = 3.3125F;
            this.Label149.Name = "Label149";
            this.Label149.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label149.Text = "NAME";
            this.Label149.Top = 8.375F;
            this.Label149.Width = 1F;
            // 
            // Label150
            // 
            this.Label150.Border.BottomColor = System.Drawing.Color.Black;
            this.Label150.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label150.Border.LeftColor = System.Drawing.Color.Black;
            this.Label150.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label150.Border.RightColor = System.Drawing.Color.Black;
            this.Label150.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label150.Border.TopColor = System.Drawing.Color.Black;
            this.Label150.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label150.Height = 0.125F;
            this.Label150.HyperLink = "";
            this.Label150.Left = 3.3125F;
            this.Label150.Name = "Label150";
            this.Label150.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label150.Text = "CHECK NO.";
            this.Label150.Top = 8.8875F;
            this.Label150.Width = 1.1875F;
            // 
            // Label151
            // 
            this.Label151.Border.BottomColor = System.Drawing.Color.Black;
            this.Label151.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label151.Border.LeftColor = System.Drawing.Color.Black;
            this.Label151.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label151.Border.RightColor = System.Drawing.Color.Black;
            this.Label151.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label151.Border.TopColor = System.Drawing.Color.Black;
            this.Label151.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label151.Height = 0.2F;
            this.Label151.HyperLink = "";
            this.Label151.Left = 6.125F;
            this.Label151.Name = "Label151";
            this.Label151.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label151.Text = "PAID AMOUNT";
            this.Label151.Top = 8.375F;
            this.Label151.Width = 1F;
            // 
            // txtName2
            // 
            this.txtName2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtName2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtName2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName2.Border.RightColor = System.Drawing.Color.Black;
            this.txtName2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName2.Border.TopColor = System.Drawing.Color.Black;
            this.txtName2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName2.Height = 0.2F;
            this.txtName2.Left = 3.3125F;
            this.txtName2.MultiLine = false;
            this.txtName2.Name = "txtName2";
            this.txtName2.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtName2.Text = "txtName2";
            this.txtName2.Top = 8.625F;
            this.txtName2.Width = 2.375F;
            // 
            // txtPayment2
            // 
            this.txtPayment2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPayment2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPayment2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPayment2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPayment2.Border.RightColor = System.Drawing.Color.Black;
            this.txtPayment2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPayment2.Border.TopColor = System.Drawing.Color.Black;
            this.txtPayment2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPayment2.Height = 0.2F;
            this.txtPayment2.Left = 3.3125F;
            this.txtPayment2.MultiLine = false;
            this.txtPayment2.Name = "txtPayment2";
            this.txtPayment2.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtPayment2.Text = "txtPayment2";
            this.txtPayment2.Top = 9.1875F;
            this.txtPayment2.Width = 2F;
            // 
            // txtPaid2
            // 
            this.txtPaid2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPaid2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPaid2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPaid2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPaid2.Border.RightColor = System.Drawing.Color.Black;
            this.txtPaid2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPaid2.Border.TopColor = System.Drawing.Color.Black;
            this.txtPaid2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPaid2.Height = 0.2F;
            this.txtPaid2.Left = 6.125F;
            this.txtPaid2.MultiLine = false;
            this.txtPaid2.Name = "txtPaid2";
            this.txtPaid2.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtPaid2.Text = "txtPaid2";
            this.txtPaid2.Top = 8.625F;
            this.txtPaid2.Width = 1.25F;
            // 
            // Label152
            // 
            this.Label152.Border.BottomColor = System.Drawing.Color.Black;
            this.Label152.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label152.Border.LeftColor = System.Drawing.Color.Black;
            this.Label152.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label152.Border.RightColor = System.Drawing.Color.Black;
            this.Label152.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label152.Border.TopColor = System.Drawing.Color.Black;
            this.Label152.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label152.Height = 0.125F;
            this.Label152.HyperLink = "";
            this.Label152.Left = 0.625F;
            this.Label152.Name = "Label152";
            this.Label152.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label152.Text = " CUSTOMER";
            this.Label152.Top = 8.875F;
            this.Label152.Width = 1F;
            // 
            // Label153
            // 
            this.Label153.Border.BottomColor = System.Drawing.Color.Black;
            this.Label153.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label153.Border.LeftColor = System.Drawing.Color.Black;
            this.Label153.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label153.Border.RightColor = System.Drawing.Color.Black;
            this.Label153.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label153.Border.TopColor = System.Drawing.Color.Black;
            this.Label153.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label153.Height = 0.125F;
            this.Label153.HyperLink = "";
            this.Label153.Left = 1.875F;
            this.Label153.Name = "Label153";
            this.Label153.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label153.Text = " PRODUCER";
            this.Label153.Top = 8.875F;
            this.Label153.Width = 1F;
            // 
            // Label154
            // 
            this.Label154.Border.BottomColor = System.Drawing.Color.Black;
            this.Label154.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label154.Border.LeftColor = System.Drawing.Color.Black;
            this.Label154.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label154.Border.RightColor = System.Drawing.Color.Black;
            this.Label154.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label154.Border.TopColor = System.Drawing.Color.Black;
            this.Label154.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label154.Height = 0.1875F;
            this.Label154.HyperLink = "";
            this.Label154.Left = 0.75F;
            this.Label154.Name = "Label154";
            this.Label154.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label154.Text = "POLICY NUMBER";
            this.Label154.Top = 8.375F;
            this.Label154.Width = 1.5F;
            // 
            // Label155
            // 
            this.Label155.Border.BottomColor = System.Drawing.Color.Black;
            this.Label155.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label155.Border.LeftColor = System.Drawing.Color.Black;
            this.Label155.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label155.Border.RightColor = System.Drawing.Color.Black;
            this.Label155.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label155.Border.TopColor = System.Drawing.Color.Black;
            this.Label155.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label155.Height = 0.1875F;
            this.Label155.HyperLink = "";
            this.Label155.Left = 5.625F;
            this.Label155.Name = "Label155";
            this.Label155.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label155.Text = " RECEIVED BY";
            this.Label155.Top = 8.875F;
            this.Label155.Width = 1F;
            // 
            // txtCustomer2
            // 
            this.txtCustomer2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCustomer2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomer2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCustomer2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomer2.Border.RightColor = System.Drawing.Color.Black;
            this.txtCustomer2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomer2.Border.TopColor = System.Drawing.Color.Black;
            this.txtCustomer2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomer2.Height = 0.1875F;
            this.txtCustomer2.Left = 0.625F;
            this.txtCustomer2.MultiLine = false;
            this.txtCustomer2.Name = "txtCustomer2";
            this.txtCustomer2.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtCustomer2.Text = "txtCustomer2";
            this.txtCustomer2.Top = 9.1875F;
            this.txtCustomer2.Width = 1.125F;
            // 
            // txtProducer2
            // 
            this.txtProducer2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtProducer2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProducer2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtProducer2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProducer2.Border.RightColor = System.Drawing.Color.Black;
            this.txtProducer2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProducer2.Border.TopColor = System.Drawing.Color.Black;
            this.txtProducer2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProducer2.Height = 0.1875F;
            this.txtProducer2.Left = 1.9375F;
            this.txtProducer2.MultiLine = false;
            this.txtProducer2.Name = "txtProducer2";
            this.txtProducer2.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtProducer2.Text = "txtProducer2";
            this.txtProducer2.Top = 9.1875F;
            this.txtProducer2.Width = 1.125F;
            // 
            // Line91
            // 
            this.Line91.Border.BottomColor = System.Drawing.Color.Black;
            this.Line91.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line91.Border.LeftColor = System.Drawing.Color.Black;
            this.Line91.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line91.Border.RightColor = System.Drawing.Color.Black;
            this.Line91.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line91.Border.TopColor = System.Drawing.Color.Black;
            this.Line91.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line91.Height = 1.0625F;
            this.Line91.Left = 3.125F;
            this.Line91.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line91.LineWeight = 1F;
            this.Line91.Name = "Line91";
            this.Line91.Top = 8.3125F;
            this.Line91.Width = 0F;
            this.Line91.X1 = 3.125F;
            this.Line91.X2 = 3.125F;
            this.Line91.Y1 = 9.375F;
            this.Line91.Y2 = 8.3125F;
            // 
            // Line92
            // 
            this.Line92.Border.BottomColor = System.Drawing.Color.Black;
            this.Line92.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line92.Border.LeftColor = System.Drawing.Color.Black;
            this.Line92.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line92.Border.RightColor = System.Drawing.Color.Black;
            this.Line92.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line92.Border.TopColor = System.Drawing.Color.Black;
            this.Line92.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line92.Height = 0.5625F;
            this.Line92.Left = 1.875F;
            this.Line92.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line92.LineWeight = 1F;
            this.Line92.Name = "Line92";
            this.Line92.Top = 8.8125F;
            this.Line92.Width = 0F;
            this.Line92.X1 = 1.875F;
            this.Line92.X2 = 1.875F;
            this.Line92.Y1 = 9.375F;
            this.Line92.Y2 = 8.8125F;
            // 
            // Line93
            // 
            this.Line93.Border.BottomColor = System.Drawing.Color.Black;
            this.Line93.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line93.Border.LeftColor = System.Drawing.Color.Black;
            this.Line93.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line93.Border.RightColor = System.Drawing.Color.Black;
            this.Line93.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line93.Border.TopColor = System.Drawing.Color.Black;
            this.Line93.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line93.Height = 0.5625F;
            this.Line93.Left = 5.631945F;
            this.Line93.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line93.LineWeight = 1F;
            this.Line93.Name = "Line93";
            this.Line93.Top = 8.8125F;
            this.Line93.Width = 0F;
            this.Line93.X1 = 5.631945F;
            this.Line93.X2 = 5.631945F;
            this.Line93.Y1 = 9.375F;
            this.Line93.Y2 = 8.8125F;
            // 
            // txtPolicyNumber2
            // 
            this.txtPolicyNumber2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPolicyNumber2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyNumber2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPolicyNumber2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyNumber2.Border.RightColor = System.Drawing.Color.Black;
            this.txtPolicyNumber2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyNumber2.Border.TopColor = System.Drawing.Color.Black;
            this.txtPolicyNumber2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPolicyNumber2.Height = 0.1875F;
            this.txtPolicyNumber2.Left = 0.75F;
            this.txtPolicyNumber2.MultiLine = false;
            this.txtPolicyNumber2.Name = "txtPolicyNumber2";
            this.txtPolicyNumber2.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtPolicyNumber2.Text = "txtPolicyNumber2";
            this.txtPolicyNumber2.Top = 8.6375F;
            this.txtPolicyNumber2.Width = 2.375F;
            // 
            // txtReceived2
            // 
            this.txtReceived2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtReceived2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReceived2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtReceived2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReceived2.Border.RightColor = System.Drawing.Color.Black;
            this.txtReceived2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReceived2.Border.TopColor = System.Drawing.Color.Black;
            this.txtReceived2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReceived2.Height = 0.1875F;
            this.txtReceived2.Left = 5.6875F;
            this.txtReceived2.MultiLine = false;
            this.txtReceived2.Name = "txtReceived2";
            this.txtReceived2.Style = "font-weight: normal; font-size: 8.25pt; ";
            this.txtReceived2.Text = "txtReceived2";
            this.txtReceived2.Top = 9.1875F;
            this.txtReceived2.Width = 2.0625F;
            // 
            // Line94
            // 
            this.Line94.Border.BottomColor = System.Drawing.Color.Black;
            this.Line94.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line94.Border.LeftColor = System.Drawing.Color.Black;
            this.Line94.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line94.Border.RightColor = System.Drawing.Color.Black;
            this.Line94.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line94.Border.TopColor = System.Drawing.Color.Black;
            this.Line94.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line94.Height = 0F;
            this.Line94.Left = 0.5F;
            this.Line94.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line94.LineWeight = 1F;
            this.Line94.Name = "Line94";
            this.Line94.Top = 9.375F;
            this.Line94.Width = 7.3125F;
            this.Line94.X1 = 0.5F;
            this.Line94.X2 = 7.8125F;
            this.Line94.Y1 = 9.375F;
            this.Line94.Y2 = 9.375F;
            // 
            // Line95
            // 
            this.Line95.Border.BottomColor = System.Drawing.Color.Black;
            this.Line95.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line95.Border.LeftColor = System.Drawing.Color.Black;
            this.Line95.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line95.Border.RightColor = System.Drawing.Color.Black;
            this.Line95.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line95.Border.TopColor = System.Drawing.Color.Black;
            this.Line95.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line95.Height = 1.0625F;
            this.Line95.Left = 0.5F;
            this.Line95.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line95.LineWeight = 1F;
            this.Line95.Name = "Line95";
            this.Line95.Top = 8.3125F;
            this.Line95.Width = 0F;
            this.Line95.X1 = 0.5F;
            this.Line95.X2 = 0.5F;
            this.Line95.Y1 = 9.375F;
            this.Line95.Y2 = 8.3125F;
            // 
            // txtNumber2
            // 
            this.txtNumber2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtNumber2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumber2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtNumber2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumber2.Border.RightColor = System.Drawing.Color.Black;
            this.txtNumber2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumber2.Border.TopColor = System.Drawing.Color.Black;
            this.txtNumber2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumber2.Height = 0.1875F;
            this.txtNumber2.Left = 7F;
            this.txtNumber2.MultiLine = false;
            this.txtNumber2.Name = "txtNumber2";
            this.txtNumber2.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; ";
            this.txtNumber2.Text = "txtNumber2";
            this.txtNumber2.Top = 7.9375F;
            this.txtNumber2.Width = 0.75F;
            // 
            // Line96
            // 
            this.Line96.Border.BottomColor = System.Drawing.Color.Black;
            this.Line96.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line96.Border.LeftColor = System.Drawing.Color.Black;
            this.Line96.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line96.Border.RightColor = System.Drawing.Color.Black;
            this.Line96.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line96.Border.TopColor = System.Drawing.Color.Black;
            this.Line96.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line96.Height = 0F;
            this.Line96.Left = 5.1875F;
            this.Line96.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line96.LineWeight = 1F;
            this.Line96.Name = "Line96";
            this.Line96.Top = 8.125F;
            this.Line96.Width = 2.625F;
            this.Line96.X1 = 5.1875F;
            this.Line96.X2 = 7.8125F;
            this.Line96.Y1 = 8.125F;
            this.Line96.Y2 = 8.125F;
            // 
            // Label156
            // 
            this.Label156.Border.BottomColor = System.Drawing.Color.Black;
            this.Label156.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label156.Border.LeftColor = System.Drawing.Color.Black;
            this.Label156.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label156.Border.RightColor = System.Drawing.Color.Black;
            this.Label156.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label156.Border.TopColor = System.Drawing.Color.Black;
            this.Label156.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label156.Height = 0.1875F;
            this.Label156.HyperLink = "";
            this.Label156.Left = 0.5625F;
            this.Label156.MultiLine = false;
            this.Label156.Name = "Label156";
            this.Label156.Style = "text-align: left; font-weight: bold; font-size: 9.75pt; ";
            this.Label156.Text = "FILE";
            this.Label156.Top = 6.125F;
            this.Label156.Width = 1.6875F;
            // 
            // Line98
            // 
            this.Line98.Border.BottomColor = System.Drawing.Color.Black;
            this.Line98.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line98.Border.LeftColor = System.Drawing.Color.Black;
            this.Line98.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line98.Border.RightColor = System.Drawing.Color.Black;
            this.Line98.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line98.Border.TopColor = System.Drawing.Color.Black;
            this.Line98.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line98.Height = 0F;
            this.Line98.Left = 5.1875F;
            this.Line98.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line98.LineWeight = 1F;
            this.Line98.Name = "Line98";
            this.Line98.Top = 7.625F;
            this.Line98.Width = 2.625F;
            this.Line98.X1 = 5.1875F;
            this.Line98.X2 = 7.8125F;
            this.Line98.Y1 = 7.625F;
            this.Line98.Y2 = 7.625F;
            // 
            // Line99
            // 
            this.Line99.Border.BottomColor = System.Drawing.Color.Black;
            this.Line99.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line99.Border.LeftColor = System.Drawing.Color.Black;
            this.Line99.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line99.Border.RightColor = System.Drawing.Color.Black;
            this.Line99.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line99.Border.TopColor = System.Drawing.Color.Black;
            this.Line99.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line99.Height = 0.5F;
            this.Line99.Left = 6.0625F;
            this.Line99.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line99.LineWeight = 1F;
            this.Line99.Name = "Line99";
            this.Line99.Top = 7.625F;
            this.Line99.Width = 0F;
            this.Line99.X1 = 6.0625F;
            this.Line99.X2 = 6.0625F;
            this.Line99.Y1 = 8.125F;
            this.Line99.Y2 = 7.625F;
            // 
            // Line100
            // 
            this.Line100.Border.BottomColor = System.Drawing.Color.Black;
            this.Line100.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line100.Border.LeftColor = System.Drawing.Color.Black;
            this.Line100.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line100.Border.RightColor = System.Drawing.Color.Black;
            this.Line100.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line100.Border.TopColor = System.Drawing.Color.Black;
            this.Line100.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line100.Height = 0F;
            this.Line100.Left = 0.5F;
            this.Line100.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line100.LineWeight = 1F;
            this.Line100.Name = "Line100";
            this.Line100.Top = 8.3125F;
            this.Line100.Width = 7.3125F;
            this.Line100.X1 = 0.5F;
            this.Line100.X2 = 7.8125F;
            this.Line100.Y1 = 8.3125F;
            this.Line100.Y2 = 8.3125F;
            // 
            // Line101
            // 
            this.Line101.Border.BottomColor = System.Drawing.Color.Black;
            this.Line101.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line101.Border.LeftColor = System.Drawing.Color.Black;
            this.Line101.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line101.Border.RightColor = System.Drawing.Color.Black;
            this.Line101.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line101.Border.TopColor = System.Drawing.Color.Black;
            this.Line101.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line101.Height = 0F;
            this.Line101.Left = 5.1875F;
            this.Line101.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line101.LineWeight = 1F;
            this.Line101.Name = "Line101";
            this.Line101.Top = 8.125F;
            this.Line101.Width = 2.625F;
            this.Line101.X1 = 5.1875F;
            this.Line101.X2 = 7.8125F;
            this.Line101.Y1 = 8.125F;
            this.Line101.Y2 = 8.125F;
            // 
            // Line102
            // 
            this.Line102.Border.BottomColor = System.Drawing.Color.Black;
            this.Line102.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line102.Border.LeftColor = System.Drawing.Color.Black;
            this.Line102.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line102.Border.RightColor = System.Drawing.Color.Black;
            this.Line102.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line102.Border.TopColor = System.Drawing.Color.Black;
            this.Line102.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line102.Height = 0F;
            this.Line102.Left = 0.5F;
            this.Line102.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line102.LineWeight = 1F;
            this.Line102.Name = "Line102";
            this.Line102.Top = 8.3125F;
            this.Line102.Width = 7.3125F;
            this.Line102.X1 = 0.5F;
            this.Line102.X2 = 7.8125F;
            this.Line102.Y1 = 8.3125F;
            this.Line102.Y2 = 8.3125F;
            // 
            // Line103
            // 
            this.Line103.Border.BottomColor = System.Drawing.Color.Black;
            this.Line103.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line103.Border.LeftColor = System.Drawing.Color.Black;
            this.Line103.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line103.Border.RightColor = System.Drawing.Color.Black;
            this.Line103.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line103.Border.TopColor = System.Drawing.Color.Black;
            this.Line103.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line103.Height = 0F;
            this.Line103.Left = 5.1875F;
            this.Line103.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line103.LineWeight = 1F;
            this.Line103.Name = "Line103";
            this.Line103.Top = 8.125F;
            this.Line103.Width = 2.625F;
            this.Line103.X1 = 5.1875F;
            this.Line103.X2 = 7.8125F;
            this.Line103.Y1 = 8.125F;
            this.Line103.Y2 = 8.125F;
            // 
            // Line104
            // 
            this.Line104.Border.BottomColor = System.Drawing.Color.Black;
            this.Line104.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line104.Border.LeftColor = System.Drawing.Color.Black;
            this.Line104.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line104.Border.RightColor = System.Drawing.Color.Black;
            this.Line104.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line104.Border.TopColor = System.Drawing.Color.Black;
            this.Line104.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line104.Height = 0.5F;
            this.Line104.Left = 6.0625F;
            this.Line104.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line104.LineWeight = 1F;
            this.Line104.Name = "Line104";
            this.Line104.Top = 7.625F;
            this.Line104.Width = 0F;
            this.Line104.X1 = 6.0625F;
            this.Line104.X2 = 6.0625F;
            this.Line104.Y1 = 8.125F;
            this.Line104.Y2 = 7.625F;
            // 
            // Line106
            // 
            this.Line106.Border.BottomColor = System.Drawing.Color.Black;
            this.Line106.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line106.Border.LeftColor = System.Drawing.Color.Black;
            this.Line106.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line106.Border.RightColor = System.Drawing.Color.Black;
            this.Line106.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line106.Border.TopColor = System.Drawing.Color.Black;
            this.Line106.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line106.Height = 0.5F;
            this.Line106.Left = 7F;
            this.Line106.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line106.LineWeight = 1F;
            this.Line106.Name = "Line106";
            this.Line106.Top = 7.625F;
            this.Line106.Width = 0F;
            this.Line106.X1 = 7F;
            this.Line106.X2 = 7F;
            this.Line106.Y1 = 8.125F;
            this.Line106.Y2 = 7.625F;
            // 
            // Line107
            // 
            this.Line107.Border.BottomColor = System.Drawing.Color.Black;
            this.Line107.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line107.Border.LeftColor = System.Drawing.Color.Black;
            this.Line107.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line107.Border.RightColor = System.Drawing.Color.Black;
            this.Line107.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line107.Border.TopColor = System.Drawing.Color.Black;
            this.Line107.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line107.Height = 0F;
            this.Line107.Left = 5.1875F;
            this.Line107.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line107.LineWeight = 1F;
            this.Line107.Name = "Line107";
            this.Line107.Top = 7.625F;
            this.Line107.Width = 2.625F;
            this.Line107.X1 = 5.1875F;
            this.Line107.X2 = 7.8125F;
            this.Line107.Y1 = 7.625F;
            this.Line107.Y2 = 7.625F;
            // 
            // Line108
            // 
            this.Line108.Border.BottomColor = System.Drawing.Color.Black;
            this.Line108.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line108.Border.LeftColor = System.Drawing.Color.Black;
            this.Line108.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line108.Border.RightColor = System.Drawing.Color.Black;
            this.Line108.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line108.Border.TopColor = System.Drawing.Color.Black;
            this.Line108.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line108.Height = 0.5F;
            this.Line108.Left = 5.1875F;
            this.Line108.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line108.LineWeight = 1F;
            this.Line108.Name = "Line108";
            this.Line108.Top = 7.625F;
            this.Line108.Width = 0F;
            this.Line108.X1 = 5.1875F;
            this.Line108.X2 = 5.1875F;
            this.Line108.Y1 = 8.125F;
            this.Line108.Y2 = 7.625F;
            // 
            // Label157
            // 
            this.Label157.Border.BottomColor = System.Drawing.Color.Black;
            this.Label157.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label157.Border.LeftColor = System.Drawing.Color.Black;
            this.Label157.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label157.Border.RightColor = System.Drawing.Color.Black;
            this.Label157.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label157.Border.TopColor = System.Drawing.Color.Black;
            this.Label157.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label157.Height = 0.1875F;
            this.Label157.HyperLink = "";
            this.Label157.Left = 5.3125F;
            this.Label157.Name = "Label157";
            this.Label157.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label157.Text = "DATE";
            this.Label157.Top = 7.6875F;
            this.Label157.Width = 0.5F;
            // 
            // Label158
            // 
            this.Label158.Border.BottomColor = System.Drawing.Color.Black;
            this.Label158.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label158.Border.LeftColor = System.Drawing.Color.Black;
            this.Label158.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label158.Border.RightColor = System.Drawing.Color.Black;
            this.Label158.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label158.Border.TopColor = System.Drawing.Color.Black;
            this.Label158.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label158.Height = 0.1875F;
            this.Label158.HyperLink = "";
            this.Label158.Left = 6.25F;
            this.Label158.Name = "Label158";
            this.Label158.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.Label158.Text = "TIME";
            this.Label158.Top = 7.6875F;
            this.Label158.Width = 0.5F;
            // 
            // Line109
            // 
            this.Line109.Border.BottomColor = System.Drawing.Color.Black;
            this.Line109.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line109.Border.LeftColor = System.Drawing.Color.Black;
            this.Line109.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line109.Border.RightColor = System.Drawing.Color.Black;
            this.Line109.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line109.Border.TopColor = System.Drawing.Color.Black;
            this.Line109.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line109.Height = 0.5F;
            this.Line109.Left = 7.875F;
            this.Line109.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line109.LineWeight = 1F;
            this.Line109.Name = "Line109";
            this.Line109.Top = 4.25F;
            this.Line109.Width = 0F;
            this.Line109.X1 = 7.875F;
            this.Line109.X2 = 7.875F;
            this.Line109.Y1 = 4.75F;
            this.Line109.Y2 = 4.25F;
            // 
            // Line110
            // 
            this.Line110.Border.BottomColor = System.Drawing.Color.Black;
            this.Line110.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line110.Border.LeftColor = System.Drawing.Color.Black;
            this.Line110.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line110.Border.RightColor = System.Drawing.Color.Black;
            this.Line110.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line110.Border.TopColor = System.Drawing.Color.Black;
            this.Line110.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line110.Height = 0.5F;
            this.Line110.Left = 7.8125F;
            this.Line110.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line110.LineWeight = 1F;
            this.Line110.Name = "Line110";
            this.Line110.Top = 7.625F;
            this.Line110.Width = 0F;
            this.Line110.X1 = 7.8125F;
            this.Line110.X2 = 7.8125F;
            this.Line110.Y1 = 8.125F;
            this.Line110.Y2 = 7.625F;
            // 
            // Line111
            // 
            this.Line111.Border.BottomColor = System.Drawing.Color.Black;
            this.Line111.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line111.Border.LeftColor = System.Drawing.Color.Black;
            this.Line111.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line111.Border.RightColor = System.Drawing.Color.Black;
            this.Line111.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line111.Border.TopColor = System.Drawing.Color.Black;
            this.Line111.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line111.Height = 1.0625F;
            this.Line111.Left = 7.875F;
            this.Line111.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line111.LineWeight = 1F;
            this.Line111.Name = "Line111";
            this.Line111.Top = 4.9375F;
            this.Line111.Width = 0F;
            this.Line111.X1 = 7.875F;
            this.Line111.X2 = 7.875F;
            this.Line111.Y1 = 6F;
            this.Line111.Y2 = 4.9375F;
            // 
            // Line112
            // 
            this.Line112.Border.BottomColor = System.Drawing.Color.Black;
            this.Line112.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line112.Border.LeftColor = System.Drawing.Color.Black;
            this.Line112.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line112.Border.RightColor = System.Drawing.Color.Black;
            this.Line112.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line112.Border.TopColor = System.Drawing.Color.Black;
            this.Line112.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line112.Height = 1.0625F;
            this.Line112.Left = 7.8125F;
            this.Line112.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line112.LineWeight = 1F;
            this.Line112.Name = "Line112";
            this.Line112.Top = 8.3125F;
            this.Line112.Width = 0F;
            this.Line112.X1 = 7.8125F;
            this.Line112.X2 = 7.8125F;
            this.Line112.Y1 = 9.375F;
            this.Line112.Y2 = 8.3125F;
            // 
            // Line90
            // 
            this.Line90.Border.BottomColor = System.Drawing.Color.Black;
            this.Line90.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line90.Border.LeftColor = System.Drawing.Color.Black;
            this.Line90.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line90.Border.RightColor = System.Drawing.Color.Black;
            this.Line90.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line90.Border.TopColor = System.Drawing.Color.Black;
            this.Line90.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line90.Height = 0.5F;
            this.Line90.Left = 5.631945F;
            this.Line90.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(123)))), ((int)(((byte)(159)))));
            this.Line90.LineWeight = 1F;
            this.Line90.Name = "Line90";
            this.Line90.Top = 8.319445F;
            this.Line90.Width = 0F;
            this.Line90.X1 = 5.631945F;
            this.Line90.X2 = 5.631945F;
            this.Line90.Y1 = 8.819445F;
            this.Line90.Y2 = 8.319445F;
            // 
            // LblTaskControlID
            // 
            this.LblTaskControlID.Border.BottomColor = System.Drawing.Color.Black;
            this.LblTaskControlID.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblTaskControlID.Border.LeftColor = System.Drawing.Color.Black;
            this.LblTaskControlID.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblTaskControlID.Border.RightColor = System.Drawing.Color.Black;
            this.LblTaskControlID.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblTaskControlID.Border.TopColor = System.Drawing.Color.Black;
            this.LblTaskControlID.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblTaskControlID.Height = 0.1875F;
            this.LblTaskControlID.HyperLink = "";
            this.LblTaskControlID.Left = 6.1875F;
            this.LblTaskControlID.MultiLine = false;
            this.LblTaskControlID.Name = "LblTaskControlID";
            this.LblTaskControlID.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.LblTaskControlID.Text = "Task Control #:";
            this.LblTaskControlID.Top = 2.6875F;
            this.LblTaskControlID.Width = 1.6875F;
            // 
            // LblTaskControl1ID
            // 
            this.LblTaskControl1ID.Border.BottomColor = System.Drawing.Color.Black;
            this.LblTaskControl1ID.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblTaskControl1ID.Border.LeftColor = System.Drawing.Color.Black;
            this.LblTaskControl1ID.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblTaskControl1ID.Border.RightColor = System.Drawing.Color.Black;
            this.LblTaskControl1ID.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblTaskControl1ID.Border.TopColor = System.Drawing.Color.Black;
            this.LblTaskControl1ID.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblTaskControl1ID.Height = 0.1875F;
            this.LblTaskControl1ID.HyperLink = "";
            this.LblTaskControl1ID.Left = 6.1875F;
            this.LblTaskControl1ID.MultiLine = false;
            this.LblTaskControl1ID.Name = "LblTaskControl1ID";
            this.LblTaskControl1ID.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.LblTaskControl1ID.Text = "Task Control #:";
            this.LblTaskControl1ID.Top = 6.125F;
            this.LblTaskControl1ID.Width = 1.6875F;
            // 
            // LblTaskControl2ID
            // 
            this.LblTaskControl2ID.Border.BottomColor = System.Drawing.Color.Black;
            this.LblTaskControl2ID.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblTaskControl2ID.Border.LeftColor = System.Drawing.Color.Black;
            this.LblTaskControl2ID.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblTaskControl2ID.Border.RightColor = System.Drawing.Color.Black;
            this.LblTaskControl2ID.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblTaskControl2ID.Border.TopColor = System.Drawing.Color.Black;
            this.LblTaskControl2ID.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LblTaskControl2ID.Height = 0.1875F;
            this.LblTaskControl2ID.HyperLink = "";
            this.LblTaskControl2ID.Left = 6.1875F;
            this.LblTaskControl2ID.MultiLine = false;
            this.LblTaskControl2ID.Name = "LblTaskControl2ID";
            this.LblTaskControl2ID.Style = "text-align: left; font-weight: normal; font-size: 8pt; ";
            this.LblTaskControl2ID.Text = "Task Control #:";
            this.LblTaskControl2ID.Top = 9.5625F;
            this.LblTaskControl2ID.Width = 1.6875F;
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
            this.Label75.Top = 0.1875F;
            this.Label75.Width = 5.125F;
            // 
            // Label
            // 
            this.Label.Border.BottomColor = System.Drawing.Color.Black;
            this.Label.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.LeftColor = System.Drawing.Color.Black;
            this.Label.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.RightColor = System.Drawing.Color.Black;
            this.Label.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.TopColor = System.Drawing.Color.Black;
            this.Label.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Height = 0.1875F;
            this.Label.HyperLink = "";
            this.Label.Left = 1.6875F;
            this.Label.MultiLine = false;
            this.Label.Name = "Label";
            this.Label.Style = "text-align: center; font-weight: bold; font-size: 11.25pt; font-family: Times New" +
                " Roman; ";
            this.Label.Text = "PUERTO RICO MEDICAL DEFENSE INSURANCE COMPANY";
            this.Label.Top = 3.5625F;
            this.Label.Width = 5.125F;
            // 
            // Label2
            // 
            this.Label2.Border.BottomColor = System.Drawing.Color.Black;
            this.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.LeftColor = System.Drawing.Color.Black;
            this.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.RightColor = System.Drawing.Color.Black;
            this.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.TopColor = System.Drawing.Color.Black;
            this.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Height = 0.1875F;
            this.Label2.HyperLink = "";
            this.Label2.Left = 1.6875F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "text-align: center; font-weight: bold; font-size: 11.25pt; font-family: Times New" +
                " Roman; ";
            this.Label2.Text = "PUERTO RICO MEDICAL DEFENSE INSURANCE COMPANY";
            this.Label2.Top = 6.9375F;
            this.Label2.Width = 5.125F;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0.05138889F;
            this.PageFooter.Name = "PageFooter";
            // 
            // PaymentReceipt
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
            this.PrintWidth = 8.25F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.PaymentReceipt_FetchData);
            this.DataInitialize += new System.EventHandler(this.PaymentReceipt_DataInitialize);
            this.ReportStart += new System.EventHandler(this.PaymentReceipt_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.Label159)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label140)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label121)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPolicyNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblPolicyClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label114)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label115)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label116)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label117)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProducer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceived)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label118)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label119)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label120)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label127)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblPolicyClass2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label130)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label131)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label132)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayment1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label134)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label135)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label136)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProducer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPolicyNumber1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceived1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label137)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label138)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label139)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label146)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblPolicyClass3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label149)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label150)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label151)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayment2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label152)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label153)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label154)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label155)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProducer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPolicyNumber2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceived2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label156)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label157)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label158)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblTaskControlID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblTaskControl1ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblTaskControl2ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

		#endregion

        private void PaymentReceipt_ReportStart(object sender, EventArgs e)
        {
            string _mHeadCompany = EPolicy.LookupTables.LookupTables.GetDescription("InsuranceCompany", _payments.InsuranceCompany.ToString());
            this.Label75.Text = _mHeadCompany;
            this.Label.Text = _mHeadCompany;
            this.Label2.Text = _mHeadCompany;

            this.lblDate.Text = DateTime.Now.ToShortDateString();
            this.lblDate1.Text = DateTime.Now.ToShortDateString();
            this.lblDate2.Text = DateTime.Now.ToShortDateString();
            this.lblTime.Text = DateTime.Now.ToShortTimeString();
            this.lblTime1.Text = DateTime.Now.ToShortTimeString();
            this.lblTime2.Text = DateTime.Now.ToShortTimeString();
        }

        private void PaymentReceipt_DataInitialize(object sender, EventArgs e)
        {
            txtNumber.Text = "";
            txtNumber1.Text = "";
            txtNumber2.Text = "";
            txtName.Text = "";
            txtName1.Text = "";
            txtName2.Text = "";
            txtPayment.Text = "";
            txtPayment1.Text = "";
            txtPayment2.Text = "";
            txtPaid.Text = "";
            txtPaid1.Text = "";
            txtPaid2.Text = "";
            txtCustomer.Text = "";
            txtCustomer1.Text = "";
            txtCustomer2.Text = "";
            txtProducer.Text = "";
            txtProducer1.Text = "";
            txtProducer2.Text = "";
            txtPolicyNumber.Text = "";
            txtPolicyNumber1.Text = "";
            txtPolicyNumber2.Text = "";
            txtReceived.Text = "";
            txtReceived1.Text = "";
            txtReceived2.Text = "";
        }

        private void PaymentReceipt_FetchData(object sender, FetchEventArgs eArgs)
        {
            string receiptNo = "";

            if (_payments.ReceiptNo == "")
            {
                receiptNo = _payments.AddReceiptNo();
            }
            else
            {
                receiptNo = _payments.ReceiptNo;
            }
            txtNumber.Text = receiptNo;
            txtNumber1.Text = receiptNo;
            txtNumber2.Text = receiptNo;
            txtName.Text = _payments.Name;
            txtName1.Text = _payments.Name;
            txtName2.Text = _payments.Name;
            txtPayment.Text = _payments.CheckNo;
            txtPayment1.Text = _payments.CheckNo;
            txtPayment2.Text = _payments.CheckNo;
            txtPaid.Text = _payments.PaymentAmount.ToString("###,###.00");
            txtPaid1.Text = _payments.PaymentAmount.ToString("###,###.00");
            txtPaid2.Text = _payments.PaymentAmount.ToString("###,###.00");
            txtCustomer.Text = _payments.CustomerNo;
            txtCustomer1.Text = _payments.CustomerNo;
            txtCustomer2.Text = _payments.CustomerNo;
            txtProducer.Text = _payments.Agent;
            txtProducer1.Text = _payments.Agent;
            txtProducer2.Text = _payments.Agent;
            txtPolicyNumber.Text = _payments.PolicyType.Trim() + " " + _payments.PolicyNo.Trim() + " " + _payments.Certificate.Trim();
            txtPolicyNumber1.Text = _payments.PolicyType.Trim() + " " + _payments.PolicyNo.Trim() + " " + _payments.Certificate.Trim(); ;
            txtPolicyNumber2.Text = _payments.PolicyType.Trim() + " " + _payments.PolicyNo.Trim() + " " + _payments.Certificate.Trim(); ;
            txtReceived.Text = _payments.EnteredBy;
            txtReceived1.Text = _payments.EnteredBy;
            txtReceived2.Text = _payments.EnteredBy;
            LblTaskControlID.Text = LblTaskControlID.Text + " " + _payments.TaskControlID.ToString().Trim();
            LblTaskControl1ID.Text = LblTaskControl1ID.Text + " " + _payments.TaskControlID.ToString().Trim();
            LblTaskControl2ID.Text = LblTaskControl2ID.Text + " " + _payments.TaskControlID.ToString().Trim();

            LblPolicyClass.Text = EPolicy.LookupTables.LookupTables.GetDescription("PolicyClass", _payments.PolicyClassID.ToString());
            LblPolicyClass2.Text = LblPolicyClass.Text;
            LblPolicyClass3.Text = LblPolicyClass.Text;

            eArgs.EOF = true;

            index++;
        }
	}
}
